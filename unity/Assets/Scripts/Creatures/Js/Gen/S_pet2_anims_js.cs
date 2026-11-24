// pet2-anims.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_pet2_anims_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V KEYS_8 = default;
if (_self1.IsNullish) _self1 = GlobalV;
KEYS_8 = Arr(((V)("tilly")), ((V)("pico")), ((V)("clover")), ((V)("chilla")), ((V)("mimi")), ((V)("puddles")), ((V)("bean")), ((V)("zippy")), ((V)("mango")));
Call(Named(boot_64 => Fn((V _self9, int _argc10, V _a12, V _a13, V _a14, V _a15, V[] _rest11) => {
V R_16 = default;
V TL_17 = default;
V S_18 = default;
V hand_19 = default;
V both_20 = default;
V o_21 = default;
V NOHANDS_22 = default;
V jump_23 = default;
V look_24 = default;
V shake_25 = default;
V swing_26 = default;
V steps_27 = default;
V jelly_28 = default;
V popcorn_29 = default;
V install_30 = default;
V loopN_31 = default;
V para_32 = default;
V bob_33 = default;
V crest_34 = default;
V flap_35 = default;
V chirp_36 = default;
V quack_37 = default;
V squeak_38 = default;
V snort_39 = default;
V dook_40 = default;
V twitch_41 = default;
V flutter_42 = default;
V stepTo_43 = default;
V waddle_44 = default;
V binky_45 = default;
V thump_46 = default;
V slowBlink_47 = default;
V bathIn_48 = default;
V BLIE_49 = default;
V BA_50 = default;
V BB_51 = default;
V bmix_52 = default;
V flopIn_53 = default;
V rolls_54 = default;
V rollUp_55 = default;
V rollBath_56 = default;
V dustOff_57 = default;
V bathOut_58 = default;
V eyeLick_59 = default;
V headShake_60 = default;
V CARDS_61 = default;
V MOVES_62 = default;
V DANCES_63 = default;
if (_self9.IsNullish) _self9 = GlobalV;
R_16 = Get(G("window"), "RiveRig");
if ((((((!(Truthy(R_16)) || !(Truthy(Get(R_16, "PETLIB")))) || !(Truthy(Get(Get(R_16, "PETLIB"), "install")))) || !(Truthy(Get(R_16, "SOFT")))) || !(Truthy(Get(R_16, "DEFS")))) || !(Truthy(Get(Get(R_16, "DEFS"), "mango"))))) {
Call(G("setTimeout"), V.Undef, boot_64.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_16, "pet2V"))) {
return default;
}
Set(R_16, "pet2V", ((V)(1D)));
{ V _t65 = Get(R_16, "PETLIB");
if (_t65.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t65));
{ V _t66 = Get(_t65, "TL");
TL_17 = _t66; }
{ V _t67 = Get(_t65, "S");
S_18 = _t67; }
{ V _t68 = Get(_t65, "hand");
hand_19 = _t68; }
{ V _t69 = Get(_t65, "both");
both_20 = _t69; }
{ V _t70 = Get(_t65, "o");
o_21 = _t70; }
{ V _t71 = Get(_t65, "NOHANDS");
NOHANDS_22 = _t71; }
{ V _t72 = Get(_t65, "jump");
jump_23 = _t72; }
{ V _t73 = Get(_t65, "look");
look_24 = _t73; }
{ V _t74 = Get(_t65, "shake");
shake_25 = _t74; }
{ V _t75 = Get(_t65, "swing");
swing_26 = _t75; }
{ V _t76 = Get(_t65, "steps");
steps_27 = _t76; }
{ V _t77 = Get(_t65, "jelly");
jelly_28 = _t77; }
{ V _t78 = Get(_t65, "popcorn");
popcorn_29 = _t78; }
{ V _t79 = Get(_t65, "install");
install_30 = _t79; } }
Invoke(KEYS_8, "forEach", Fn((V _self9, int _argc80, V k_86, V _a83, V _a84, V _a85, V[] _rest81) => {
return Invoke(Get(R_16, "SOFT"), "add", k_86);
}, 1, "", true));
if (Truthy(Get(R_16, "PRE"))) {
Object_assign(Get(R_16, "PRE"), NewObj(7).Put("featherY", NewObj(8).Put("n", ((V)(2D))).Put("sp", ((V)(10D))).Put("vy", ((V)((-9D)))).Put("g", ((V)(9D))).Put("life", ((V)(1800D))).Put("r", Arr(((V)(0.8)), ((V)(1.1)))).Put("col", Arr(((V)("#ffef9a")), ((V)("#e6e7ee")), ((V)("#cfd0d8")))).Put("kind", ((V)("leaf"))).V).Put("featherG", NewObj(8).Put("n", ((V)(2D))).Put("sp", ((V)(10D))).Put("vy", ((V)((-9D)))).Put("g", ((V)(9D))).Put("life", ((V)(1800D))).Put("r", Arr(((V)(0.8)), ((V)(1.1)))).Put("col", Arr(((V)("#a9e25c")), ((V)("#fff07a")), ((V)("#86c84a")))).Put("kind", ((V)("leaf"))).V).Put("fluffY", NewObj(8).Put("n", ((V)(2D))).Put("sp", ((V)(9D))).Put("vy", ((V)((-8D)))).Put("g", ((V)(8D))).Put("life", ((V)(1700D))).Put("r", Arr(((V)(0.7)), ((V)(1D)))).Put("col", Arr(((V)("#fff6c2")), ((V)("#ffe46a")), ((V)("#ffffff")))).Put("kind", ((V)("leaf"))).V).Put("poof", NewObj(8).Put("n", ((V)(3D))).Put("sp", ((V)(14D))).Put("vy", ((V)((-6D)))).Put("g", ((V)(3D))).Put("life", ((V)(1300D))).Put("r", Arr(((V)(1.8)), ((V)(3.4)))).Put("col", Arr(((V)("#f2f1f7")), ((V)("#e2e1ea")), ((V)("#ffffff")))).Put("kind", ((V)("puff"))).V).Put("dustbath", NewObj(7).Put("n", ((V)(3D))).Put("sp", ((V)(16D))).Put("vy", ((V)((-13D)))).Put("g", ((V)(4D))).Put("life", ((V)(1500D))).Put("r", Arr(((V)(2.8)), ((V)(4.8)))).Put("kind", ((V)("haze"))).V).Put("dustplume", NewObj(7).Put("n", ((V)(1D))).Put("sp", ((V)(5D))).Put("vy", ((V)((-21D)))).Put("g", ((V)((-2D)))).Put("life", ((V)(1900D))).Put("r", Arr(((V)(4D)), ((V)(6.2)))).Put("kind", ((V)("haze"))).V).Put("dustspray", NewObj(8).Put("n", ((V)(4D))).Put("sp", ((V)(24D))).Put("vy", ((V)((-22D)))).Put("g", ((V)(55D))).Put("life", ((V)(900D))).Put("r", Arr(((V)(0.3)), ((V)(0.65)))).Put("col", Arr(((V)("#b5ada1")), ((V)("#d8d1c6")), ((V)("#f3f0ea")))).Put("kind", ((V)("dot"))).V).V);
}
loopN_31 = Fn((V _self9, int _argc87, V t_93, V n_94, V _a91, V _a92, V[] _rest88) => {
return Object_assign(Invoke(t_93, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_93, "t")) * ToNum((n_94 is var _t95 && Truthy(_t95) ? _t95 : ((V)(3D)))))))).V);
}, 2, "", true);
para_32 = Fn((V _self9, int _argc96, V t_102, V from_103, V fn_104, V _a101, V[] _rest97) => {
V e_105 = default;
e_105 = Get(t_102, "t");
Invoke(t_102, "at", from_103);
Call(fn_104, V.Undef, t_102);
return Invoke(t_102, "at", ((V)(Max(ToNum(e_105), ToNum(Get(t_102, "t"))))));
return default;
}, 3, "", true);
bob_33 = Fn((V _self9, int _argc106, V t_112, V n_113, V per_114, V a_115, V[] _rest107) => {
a_115 = (a_115 is var _t116 && Truthy(_t116) ? _t116 : ((V)(0.14)));
{
V i_117 = default;
i_117 = ((V)(0D));
while (true) {
if (!(Lt(i_117, n_113))) break;
Invoke(Invoke(t_112, "to", ((V)((ToNum(per_114) * 0.4))), NewObj(2).Put("pitch", ((V)((-ToNum(a_115))))).Put("sq", ((V)(0.025))).V, ((V)("o"))), "to", ((V)((ToNum(per_114) * 0.6))), NewObj(2).Put("pitch", ((V)((ToNum(a_115) * 0.25)))).Put("sq", ((V)(0D))).V, ((V)("io")));
PostInc(ref i_117, 1D);
}
}
return Invoke(t_112, "to", ((V)(120D)), NewObj(1).Put("pitch", ((V)(0D))).V, ((V)("io")));
return default;
}, 4, "", true);
crest_34 = Fn((V _self9, int _argc119, V t_125, V v_126, V d_127, V ez_128, V[] _rest120) => {
return Invoke(t_125, "to", (d_127 is var _t129 && Truthy(_t129) ? _t129 : ((V)(140D))), NewObj(2).Put("earL", v_126).Put("earR", v_126).V, (ez_128 is var _t130 && Truthy(_t130) ? _t130 : ((V)("o"))));
}, 4, "", true);
flap_35 = Fn((V _self9, int _argc131, V t_137, V n_138, V per_139, V A_140, V[] _rest132) => {
{
V i_141 = default;
i_141 = ((V)(0D));
while (true) {
if (!(Lt(i_141, n_138))) break;
Invoke(Invoke(t_137, "to", ((V)((ToNum(per_139) * 0.45))), NewObj(2).Put("armL", A_140).Put("armR", A_140).V, ((V)("o"))), "to", ((V)((ToNum(per_139) * 0.55))), NewObj(2).Put("armL", ((V)((ToNum(A_140) * 0.25)))).Put("armR", ((V)((ToNum(A_140) * 0.25)))).V, ((V)("io")));
PostInc(ref i_141, 1D);
}
}
return t_137;
return default;
}, 4, "", true);
chirp_36 = Fn((V _self9, int _argc143, V t_149, V a_150, V _a147, V _a148, V[] _rest144) => {
return Invoke(Invoke(Invoke(t_149, "to", ((V)(90D)), NewObj(3).Put("open", ((V)((0.5 * ToNum((a_150 is var _t151 && Truthy(_t151) ? _t151 : ((V)(1D)))))))).Put("mw", ((V)(0.6))).Put("pitch", ((V)(0.08))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(140D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 2, "", true);
quack_37 = Fn((V _self9, int _argc152, V t_158, V _a155, V _a156, V _a157, V[] _rest153) => {
return Invoke(Invoke(Invoke(t_158, "to", ((V)(90D)), NewObj(4).Put("open", ((V)(0.65))).Put("mw", ((V)(1.1))).Put("pitch", ((V)(0.12))).Put("sq", ((V)((-0.03)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(170D)), NewObj(4).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
squeak_38 = Fn((V _self9, int _argc159, V t_165, V _a162, V _a163, V _a164, V[] _rest160) => {
return Invoke(Invoke(Invoke(t_165, "to", ((V)(70D)), NewObj(4).Put("open", ((V)(0.4))).Put("mw", ((V)(0.55))).Put("pitch", ((V)(0.1))).Put("wide", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(140D)), NewObj(4).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
snort_39 = Fn((V _self9, int _argc166, V t_172, V n_173, V _a170, V _a171, V[] _rest167) => {
{
V i_174 = default;
i_174 = ((V)(0D));
while (true) {
if (!(Lt(i_174, (n_173 is var _t176 && Truthy(_t176) ? _t176 : ((V)(2D)))))) break;
Invoke(Invoke(t_172, "to", ((V)(80D)), NewObj(4).Put("sq", ((V)(0.05))).Put("pitch", ((V)(0.1))).Put("mw", ((V)(0.75))).Put("close", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(4).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("mw", ((V)(1D))).Put("close", ((V)(0D))).V, ((V)("io")));
PostInc(ref i_174, 1D);
}
}
return t_172;
return default;
}, 2, "", true);
dook_40 = Fn((V _self9, int _argc177, V t_183, V n_184, V _a181, V _a182, V[] _rest178) => {
Invoke(t_183, "to", ((V)(120D)), NewObj(3).Put("open", ((V)(0.35))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("o")));
{
V i_185 = default;
i_185 = ((V)(0D));
while (true) {
if (!(Lt(i_185, (n_184 is var _t187 && Truthy(_t187) ? _t187 : ((V)(3D)))))) break;
Invoke(Invoke(t_183, "to", ((V)(80D)), NewObj(2).Put("lift", ((V)(1.6))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(90D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("i")));
PostInc(ref i_185, 1D);
}
}
Invoke(t_183, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
return Invoke(t_183, "to", ((V)(140D)), NewObj(2).Put("sq", ((V)(0D))).Put("open", ((V)(0.1))).V, ((V)("io")));
return default;
}, 2, "", true);
twitch_41 = Fn((V _self9, int _argc188, V t_194, V n_195, V _a192, V _a193, V[] _rest189) => {
return Invoke(t_194, "osc", ((V)((ToNum((n_195 is var _t196 && Truthy(_t196) ? _t196 : ((V)(3D)))) * 150D))), (n_195 is var _t197 && Truthy(_t197) ? _t197 : ((V)(3D))), NewObj(2).Put("mw", ((V)(0.7))).Put("pitch", ((V)(0.04))).V, NewObj(2).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("o")));
}, 2, "", true);
flutter_42 = Fn((V _self9, int _argc198, V t_204, V h_205, V dur_206, V n_207, V[] _rest199) => {
V b_209 = default;
V e_210 = default;
V x_208 = default;
x_208 = (_argc198 > 4 ? _rest199[0] : V.Undef);
Invoke(t_204, "to", ((V)(120D)), NewObj(4).Put("sq", ((V)(0.12))).Put("pitch", ((V)((-0.08)))).Put("armL", ((V)((-6D)))).Put("armR", ((V)((-6D)))).V, ((V)("io")));
b_209 = Get(t_204, "t");
Invoke(Invoke(t_204, "to", ((V)((ToNum(dur_206) * 0.45))), Call(o_21, V.Undef, NewObj(3).Put("lift", h_205).Put("sq", ((V)((-0.08)))).Put("pitch", ((V)(0.06))).V, (x_208 is var _t211 && Truthy(_t211) ? _t211 : NewObj(0).V)), ((V)("o"))), "to", ((V)((ToNum(dur_206) * 0.55))), NewObj(3).Put("lift", ((V)(0D))).Put("sq", ((V)((-0.02)))).Put("pitch", ((V)(0D))).V, ((V)("io")));
e_210 = Get(t_204, "t");
Invoke(t_204, "at", b_209);
Call(flap_35, V.Undef, t_204, n_207, ((V)((ToNum(dur_206) / ToNum(n_207)))), ((V)(115D)));
Invoke(t_204, "at", e_210);
return Invoke(Invoke(t_204, "to", ((V)(90D)), NewObj(3).Put("sq", ((V)(0.1))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(3).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return default;
}, 5, "", true);
stepTo_43 = Fn((V _self9, int _argc212, V t_218, V xs_219, V per_220, V h_221, V[] _rest213) => {
V x_222 = default;
x_222 = (_argc212 > 4 ? _rest213[0] : V.Undef);
Invoke(xs_219, "forEach", Fn((V _self9, int _argc223, V X_229, V i_230, V _a227, V _a228, V[] _rest224) => {
V f_231 = default;
f_231 = ((V)((NumTruthy((ToNum(i_230) % 2D)) ? "footL" : "footR")));
Invoke(Invoke(t_218, "to", ((V)((ToNum(per_220) * 0.5))), Call(o_21, V.Undef, NewObj(3).PutK(f_231, (h_221 is var _t232 && Truthy(_t232) ? _t232 : ((V)(3D)))).Put("x", X_229).Put("tilt", ((V)((NumTruthy((ToNum(i_230) % 2D)) ? (-2D) : 2D)))).V, (x_222 is var _t233 && Truthy(_t233) ? _t233 : NewObj(0).V)), ((V)("o"))), "to", ((V)((ToNum(per_220) * 0.5))), NewObj(2).PutK(f_231, ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("i")));
return default;
}, 2, "", true));
return t_218;
return default;
}, 5, "", true);
waddle_44 = Fn((V _self9, int _argc234, V t_240, V xs_241, V per_242, V _a239, V[] _rest235) => {
Invoke(xs_241, "forEach", Fn((V _self9, int _argc243, V X_249, V i_250, V _a247, V _a248, V[] _rest244) => {
V f_251 = default;
V d_252 = default;
f_251 = ((V)((NumTruthy((ToNum(i_250) % 2D)) ? "footL" : "footR")));
d_252 = ((V)((NumTruthy((ToNum(i_250) % 2D)) ? (-1D) : 1D)));
Invoke(Invoke(t_240, "to", ((V)((ToNum(per_242) * 0.5))), NewObj(5).PutK(f_251, ((V)(2.6))).Put("x", X_249).Put("tilt", ((V)((ToNum(d_252) * 7D)))).Put("lean", ((V)((ToNum(d_252) * 1.5)))).Put("wag", ((V)((ToNum(d_252) * 20D)))).V, ((V)("o"))), "to", ((V)((ToNum(per_242) * 0.5))), NewObj(3).PutK(f_251, ((V)(0D))).Put("tilt", ((V)((ToNum(d_252) * 2D)))).Put("lean", ((V)(0D))).V, ((V)("i")));
return default;
}, 2, "", true));
return Invoke(t_240, "to", ((V)(160D)), NewObj(2).Put("tilt", ((V)(0D))).Put("wag", ((V)(0D))).V, ((V)("io")));
return default;
}, 3, "", true);
binky_45 = Fn((V _self9, int _argc253, V t_259, V s_260, V h_261, V _a258, V[] _rest254) => {
return Call(jump_23, V.Undef, t_259, NewObj(7).Put("h", (h_261 is var _t262 && Truthy(_t262) ? _t262 : ((V)(12D)))).Put("ant", ((V)(150D))).Put("up", ((V)(240D))).Put("c", ((V)(0.18))).Put("arm", ((V)(20D))).Put("air", NewObj(6).Put("tilt", ((V)((ToNum(s_260) * 10D)))).Put("turn", ((V)((ToNum(s_260) * 0.35)))).Put("earL", ((V)(28D))).Put("earR", ((V)(28D))).Put("footL", ((V)((LtN(s_260, 0D) ? 3.5 : 0D)))).Put("footR", ((V)((GtN(s_260, 0D) ? 3.5 : 0D)))).V).Put("fall", NewObj(6).Put("tilt", ((V)(0D))).Put("turn", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V).V);
}, 3, "", true);
thump_46 = Fn((V _self9, int _argc263, V t_269, V s_270, V _a267, V _a268, V[] _rest264) => {
V k_271 = default;
k_271 = Call(S_18, V.Undef, (s_270 is var _t272 && Truthy(_t272) ? _t272 : ((V)(1D))));
return Invoke(Invoke(Invoke(Invoke(t_269, "to", ((V)(200D)), NewObj(5).PutK(Get(k_271, "foot"), ((V)(3.5))).Put("sq", ((V)((-0.03)))).Put("earL", ((V)(18D))).Put("earR", ((V)(18D))).Put("wide", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(70D)), NewObj(2).PutK(Get(k_271, "foot"), ((V)(0D))).Put("sq", ((V)(0.12))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(3D))), "to", ((V)(160D)), NewObj(3).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "", true);
slowBlink_47 = Fn((V _self9, int _argc273, V t_279, V _a276, V _a277, V _a278, V[] _rest274) => {
return Invoke(Invoke(Invoke(t_279, "to", ((V)(380D)), NewObj(1).Put("close", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(420D)), NewObj(1).Put("close", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
bathIn_48 = Fn((V _self9, int _argc280, V t_286, V _a283, V _a284, V _a285, V[] _rest281) => {
V a_287 = default;
a_287 = Get(t_286, "t");
Invoke(Invoke(t_286, "to", ((V)(240D)), NewObj(1).Put("dbb", ((V)(1.12))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(1).Put("dbb", ((V)(1D))).V, ((V)("io")));
Invoke(t_286, "at", Add(a_287, ((V)(90D))));
Call(jump_23, V.Undef, t_286, NewObj(5).Put("h", ((V)(8D))).Put("ant", ((V)(120D))).Put("up", ((V)(190D))).Put("c", ((V)(0.12))).Put("arm", ((V)(30D))).V);
return Invoke(Invoke(Invoke(t_286, "to", ((V)(220D)), NewObj(2).Put("lift", ((V)((-2.5)))).Put("sq", ((V)(0.1))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("dustbath")), Arr(((V)(36D)), ((V)(84D))), ((V)(2D))), "e", ((V)("emit")), ((V)("dustbath")), Arr(((V)(64D)), ((V)(84D))), ((V)(2D)));
return default;
}, 1, "", true);
BLIE_49 = NewObj(23).Put("tilt", ((V)(99D))).Put("x", ((V)((-43.5)))).Put("lift", ((V)(26.5))).Put("spin", ((V)((-16D)))).Put("sq", ((V)(0.1))).Put("sit", ((V)(1D))).Put("close", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("earL", ((V)(18D))).Put("earR", ((V)(50D))).Put("footL", ((V)(1.5))).Put("footR", ((V)(1.5))).Put("armL", ((V)((-8D)))).Put("armR", ((V)((-8D)))).Put("htilt", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("bend", ((V)(0D))).Put("twist", ((V)(0D))).Put("lean", ((V)(0D))).Put("wag", ((V)(0D))).Put("dbs", ((V)(1D))).Put("wsk", ((V)(1D))).V;
BA_50 = NewObj(16).Put("tilt", ((V)(105D))).Put("x", ((V)((-42D)))).Put("lift", ((V)(28.5))).Put("spin", ((V)((-82D)))).Put("sq", ((V)(0.18))).Put("footL", ((V)(3.4))).Put("footR", ((V)(1.2))).Put("armL", ((V)((-28D)))).Put("armR", ((V)(6D))).Put("earL", ((V)(27D))).Put("earR", ((V)(50D))).Put("htilt", ((V)((-11D)))).Put("hyaw", ((V)((-0.14)))).Put("bend", ((V)((-14D)))).Put("twist", ((V)((-0.12)))).Put("wag", ((V)((-32D)))).V;
BB_51 = NewObj(16).Put("tilt", ((V)(95D))).Put("x", ((V)((-46D)))).Put("lift", ((V)(25.5))).Put("spin", ((V)(38D))).Put("sq", ((V)(0.18))).Put("footL", ((V)(0.6))).Put("footR", ((V)(3.4))).Put("armL", ((V)(6D))).Put("armR", ((V)((-28D)))).Put("earL", ((V)(26D))).Put("earR", ((V)(55D))).Put("htilt", ((V)(11D))).Put("hyaw", ((V)(0.14))).Put("bend", ((V)(18D))).Put("twist", ((V)(0.12))).Put("wag", ((V)(32D))).V;
bmix_52 = Fn((V _self9, int _argc288, V o_294, V g_295, V _a292, V _a293, V[] _rest289) => {
V r_296 = default;
r_296 = NewObj(0).V;
{
foreach (V _k297 in ForInKeys(o_294)) {
V k_298 = default;
k_298 = _k297;
SetK(r_296, k_298, Add(GetK(BLIE_49, k_298), ((V)(((ToNum(GetK(o_294, k_298)) - ToNum(GetK(BLIE_49, k_298))) * ToNum(g_295))))));
}
}
return r_296;
return default;
}, 2, "", true);
flopIn_53 = Fn((V _self9, int _argc299, V t_305, V _a302, V _a303, V _a304, V[] _rest300) => {
return Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_305, "to", ((V)(220D)), NewObj(7).Put("sq", ((V)(0.22))).Put("lift", ((V)((-4D)))).Put("close", ((V)(0.7))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(10).Put("tilt", ((V)(44D))).Put("x", ((V)((-17D)))).Put("lift", ((V)(9D))).Put("spin", ((V)((-6D)))).Put("sq", ((V)(0.06))).Put("sit", ((V)(0.6))).Put("earL", ((V)(18D))).Put("earR", ((V)(18D))).Put("close", ((V)(1D))).Put("wsk", ((V)(0.5))).V, ((V)("i"))), "to", ((V)(190D)), Object_assign(NewObj(0).V, BLIE_49, NewObj(3).Put("tilt", ((V)(105D))).Put("lift", ((V)(25D))).Put("x", ((V)((-42.5)))).V), ((V)("o"))), "e", ((V)("emit")), ((V)("dustbath")), Arr(((V)(26D)), ((V)(83D))), ((V)(3D))), "e", ((V)("emit")), ((V)("dustbath")), Arr(((V)(52D)), ((V)(84D))), ((V)(3D))), "e", ((V)("emit")), ((V)("dustbath")), Arr(((V)(74D)), ((V)(83D))), ((V)(2D))), "e", ((V)("emit")), ((V)("dustspray")), Arr(((V)(20D)), ((V)(82D))), ((V)(3D))), "e", ((V)("emit")), ((V)("dustspray")), Arr(((V)(80D)), ((V)(82D))), ((V)(3D))), "to", ((V)(170D)), NewObj(3).Put("tilt", ((V)(99D))).Put("lift", ((V)(26.5))).Put("x", ((V)((-43.5)))).V, ((V)("io")));
}, 1, "", true);
rolls_54 = Fn((V _self9, int _argc306, V t_312, V n_313, V P_314, V hz_315, V[] _rest307) => {
V s0_316 = default;
V last_317 = default;
V s1_318 = default;
s0_316 = Get(t_312, "t");
last_317 = BLIE_49;
{
V i_319 = default;
i_319 = ((V)(0D));
while (true) {
if (!(Lt(i_319, n_313))) break;
V g_321 = default;
V big_322 = default;
V amp_323 = default;
V A_324 = default;
V q_325 = default;
V mid_326 = default;
g_321 = ((V)(Min(1D, (ToNum(Add(i_319, ((V)(1D)))) / 3D), ((ToNum(n_313) - ToNum(i_319)) / 3D))));
big_322 = ((V)(((((ToNum(i_319) % 8D) == 5D) || ((ToNum(i_319) % 8D) == 6D)) ? 1.22 : 1D)));
amp_323 = ((V)(((ToNum(g_321) * ToNum(big_322)) * (0.88 + (0.12 * FdLibm.Sin((ToNum(i_319) * 1.7)))))));
A_324 = (((ToNum(i_319) % 2D) == 0D) ? V.True : V.False);
q_325 = Call(bmix_52, V.Undef, (Truthy(A_324) ? BA_50 : BB_51), amp_323);
mid_326 = NewObj(0).V;
{
foreach (V _k327 in ForInKeys(q_325)) {
V k_328 = default;
k_328 = _k327;
SetK(mid_326, k_328, ((V)((ToNum(Add(GetK(last_317, k_328), GetK(q_325, k_328))) / 2D))));
}
}
Object_assign(mid_326, NewObj(5).Put("sq", ((V)((0.1 - (0.09 * ToNum(g_321)))))).Put("lift", Add(Get(mid_326, "lift"), ((V)((2.2 * ToNum(g_321)))))).Put("twist", ((V)(((Truthy(A_324) ? (-0.38) : 0.38) * ToNum(g_321))))).Put("lean", ((V)(((Truthy(A_324) ? (-3D) : 3D) * ToNum(g_321))))).Put("bend", ((V)((ToNum(Get(mid_326, "bend")) * 0.4)))).V, (Truthy(A_324) ? NewObj(2).Put("footL", ((V)((1.5 + (3D * ToNum(g_321)))))).Put("footR", ((V)(0D))).V : NewObj(2).Put("footL", ((V)(0D))).Put("footR", ((V)((1.5 + (3D * ToNum(g_321)))))).V));
Invoke(Invoke(t_312, "to", ((V)((ToNum(P_314) / 2D))), mid_326, ((V)("i"))), "to", ((V)((ToNum(P_314) / 2D))), q_325, ((V)("o")));
if (Truthy(A_324)) {
Invoke(Invoke(Invoke(t_312, "e", ((V)("emit")), ((V)("dustbath")), Arr(((V)((17D + ((ToNum(i_319) * 7D) % 9D)))), ((V)(82D))), ((V)(1D))), "e", ((V)("emit")), ((V)("dustspray")), Arr(((V)(82D)), ((V)(81D))), ((V)(2D))), "e", ((V)("emit")), ((V)("dustplume")), (NumTruthy((ToNum(i_319) % 4D)) ? Arr(((V)(86D)), ((V)(74D))) : Arr(((V)(14D)), ((V)(74D)))), ((V)(1D)));
} else {
Invoke(Invoke(t_312, "e", ((V)("emit")), ((V)("dustbath")), Arr(((V)((((ToNum(i_319) % 4D) == 1D) ? 30D : 70D))), ((V)(87D))), ((V)(1D))), "e", ((V)("emit")), ((V)("dustspray")), Arr(((V)(24D)), ((V)(82D))), ((V)(2D)));
}
last_317 = q_325;
PostInc(ref i_319, 1D);
}
}
Invoke(t_312, "to", ((V)(200D)), Call(bmix_52, V.Undef, BA_50, ((V)(0D))), ((V)("io")));
s1_318 = Get(t_312, "t");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_312, "at", s0_316), "to", ((V)(Min(700D, ((ToNum(s1_318) - ToNum(s0_316)) * 0.4)))), NewObj(1).Put("dbh", hz_315).V, ((V)("io"))), "at", s0_316), "em", ((V)((ToNum(s1_318) - ToNum(s0_316)))), ((V)(100D)), ((V)("dustbath")), Arr(((V)(24D)), ((V)(83D))), ((V)(1D))), "em", ((V)((ToNum(s1_318) - ToNum(s0_316)))), ((V)(160D)), ((V)("dustbath")), Arr(((V)(50D)), ((V)(88D))), ((V)(1D))), "em", ((V)((ToNum(s1_318) - ToNum(s0_316)))), ((V)(110D)), ((V)("dustbath")), Arr(((V)(74D)), ((V)(83D))), ((V)(1D)));
Invoke(Invoke(t_312, "at", s1_318), "to", ((V)(1100D)), NewObj(1).Put("dbh", ((V)(0D))).V, ((V)("io")));
return Invoke(t_312, "at", s1_318);
return default;
}, 4, "", true);
rollUp_55 = Fn((V _self9, int _argc329, V t_335, V _a332, V _a333, V _a334, V[] _rest330) => {
return Invoke(Invoke(Invoke(Invoke(Invoke(t_335, "to", ((V)(230D)), NewObj(19).Put("tilt", ((V)(46D))).Put("x", ((V)((-16D)))).Put("lift", ((V)(10D))).Put("spin", ((V)((-6D)))).Put("sit", ((V)(0.4))).Put("sq", ((V)(0.06))).Put("close", ((V)(0.4))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("bend", ((V)(0D))).Put("twist", ((V)(0D))).Put("lean", ((V)(0D))).Put("wag", ((V)(0D))).Put("dbs", ((V)(0D))).Put("wsk", ((V)(0.4))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("dustbath")), Arr(((V)(30D)), ((V)(83D))), ((V)(2D))), "e", ((V)("emit")), ((V)("dustbath")), Arr(((V)(66D)), ((V)(83D))), ((V)(2D))), "to", ((V)(230D)), NewObj(11).Put("tilt", ((V)((-6D)))).Put("x", ((V)(0D))).Put("lift", ((V)((-1D)))).Put("spin", ((V)(0D))).Put("sit", ((V)(0D))).Put("sq", ((V)(0.04))).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("wsk", ((V)(0D))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(3).Put("tilt", ((V)(0D))).Put("lift", ((V)((-2.5)))).Put("sq", ((V)(0.1))).V, ((V)("io")));
}, 1, "", true);
rollBath_56 = Fn((V _self9, int _argc336, V t_342, V n_343, V _a340, V _a341, V[] _rest337) => {
Call(flopIn_53, V.Undef, t_342);
Call(rolls_54, V.Undef, t_342, n_343, ((V)(170D)), ((V)(0.8)));
return Call(rollUp_55, V.Undef, Invoke(t_342, "wait", ((V)(200D))));
return default;
}, 2, "", true);
dustOff_57 = Fn((V _self9, int _argc344, V t_350, V d_351, V _a348, V _a349, V[] _rest345) => {
V a_352 = default;
a_352 = Get(t_350, "t");
Invoke(Invoke(Invoke(Invoke(t_350, "e", ((V)("emit")), ((V)("dustbath")), ((V)("head")), ((V)(2D))), "e", ((V)("emit")), ((V)("dustbath")), ((V)("sideL")), ((V)(2D))), "e", ((V)("emit")), ((V)("dustbath")), ((V)("sideR")), ((V)(2D))), "em", (d_351 is var _t353 && Truthy(_t353) ? _t353 : ((V)(500D))), ((V)(90D)), ((V)("dustbath")), ((V)("body")), ((V)(1D)));
return Invoke(t_350, "at", a_352);
return default;
}, 2, "", true);
bathOut_58 = Fn((V _self9, int _argc354, V t_360, V _a357, V _a358, V _a359, V[] _rest355) => {
V b_361 = default;
V e_362 = default;
b_361 = Get(t_360, "t");
Call(jump_23, V.Undef, t_360, NewObj(6).Put("h", ((V)(10D))).Put("ant", ((V)(130D))).Put("up", ((V)(210D))).Put("c", ((V)(0.14))).Put("arm", ((V)(40D))).Put("ev", Arr(Arr(((V)("emit")), ((V)("dustbath")), Arr(((V)(34D)), ((V)(84D))), ((V)(2D))), Arr(((V)("emit")), ((V)("dustbath")), Arr(((V)(66D)), ((V)(84D))), ((V)(2D))))).V);
e_362 = Get(t_360, "t");
Invoke(Invoke(t_360, "at", Add(b_361, ((V)(230D)))), "to", ((V)(260D)), NewObj(1).Put("dbb", ((V)(0D))).V, ((V)("i")));
return Invoke(t_360, "at", ((V)(Max(ToNum(e_362), ToNum(Get(t_360, "t"))))));
return default;
}, 1, "", true);
eyeLick_59 = Fn((V _self9, int _argc363, V t_369, V s_370, V _a367, V _a368, V[] _rest364) => {
V k_371 = default;
k_371 = Call(S_18, V.Undef, s_370);
return Invoke(Invoke(Invoke(t_369, "to", ((V)(120D)), NewObj(6).Put("tongue", ((V)(1D))).Put("open", ((V)(0.3))).Put("pitch", ((V)(0.18))).Put("htilt", ((V)((ToNum(s_370) * 8D)))).Put("hyaw", ((V)((ToNum(s_370) * 0.12)))).PutK(Get(k_371, "wink"), ((V)(0.8))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("tongue", ((V)(0.7))).PutK(Get(k_371, "wink"), ((V)(1D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(6).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hyaw", ((V)(0D))).PutK(Get(k_371, "wink"), ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "", true);
headShake_60 = Fn((V _self9, int _argc372, V t_378, V a_379, V _a376, V _a377, V[] _rest373) => {
return Call(shake_25, V.Undef, t_378, NewObj(6).Put("P", ((V)(95D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.8)), ((V)(0.5)), ((V)(0.25)))).Put("head", ((V)((0.32 * ToNum((a_379 is var _t380 && Truthy(_t380) ? _t380 : ((V)(1D)))))))).Put("roll", ((V)(4D))).Put("ear", ((V)(14D))).Put("chest", ((V)(0.08))).V);
}, 2, "", true);
CARDS_61 = NewObj(9).Put("tilly", NewObj(4).Put("T", ((V)(0.95))).Put("b", ((V)(1.05))).Put("s", ((V)(1.1))).Put("e", ((V)(1.4))).V).Put("pico", NewObj(4).Put("T", ((V)(0.8))).Put("b", ((V)(1.15))).Put("s", ((V)(1D))).Put("e", ((V)(1D))).V).Put("clover", NewObj(4).Put("T", ((V)(1D))).Put("b", ((V)(1.2))).Put("s", ((V)(1D))).Put("e", ((V)(1.4))).V).Put("chilla", NewObj(5).Put("T", ((V)(0.85))).Put("b", ((V)(1.3))).Put("s", ((V)(1.1))).Put("e", ((V)(1.1))).Put("w", ((V)(1.2))).V).Put("mimi", NewObj(5).Put("T", ((V)(0.75))).Put("b", ((V)(0.95))).Put("s", ((V)(0.85))).Put("e", ((V)(1.2))).Put("w", ((V)(1.3))).V).Put("puddles", NewObj(4).Put("T", ((V)(0.95))).Put("b", ((V)(1.1))).Put("s", ((V)(1.3))).Put("w", ((V)(1.6))).V).Put("bean", NewObj(5).Put("T", ((V)(1.05))).Put("b", ((V)(1.2))).Put("s", ((V)(1.15))).Put("w", ((V)(1.8))).Put("e", ((V)(0.7))).V).Put("zippy", NewObj(5).Put("T", ((V)(0.8))).Put("b", ((V)(1.3))).Put("s", ((V)(1.4))).Put("w", ((V)(1.4))).Put("e", ((V)(0.8))).V).Put("mango", NewObj(5).Put("T", ((V)(1.2))).Put("b", ((V)(0.8))).Put("s", ((V)(1.1))).Put("w", ((V)(1.6))).Put("e", ((V)(0D))).V).V;
MOVES_62 = NewObj(9).Put("tilly", NewObj(7).Put("happy", Arr(Call(Fn((V _self9, int _argc381, V _a383, V _a384, V _a385, V _a386, V[] _rest382) => {
V t_387 = default;
t_387 = Call(TL_17, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Invoke(t_387, "to", ((V)(110D)), NewObj(1).Put("ly", ((V)((-0.4)))).V, ((V)("o")));
Call(crest_34, V.Undef, t_387, ((V)((-24D))), ((V)(170D)));
Invoke(Invoke(t_387, "to", ((V)(150D)), NewObj(4).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).Put("lift", ((V)(1D))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(4).Put("armL", ((V)(96D))).Put("armR", ((V)(96D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.02))).V, ((V)("io")));
Call(bob_33, V.Undef, t_387, ((V)(4D)), ((V)(260D)), ((V)(0.16)));
Call(chirp_36, V.Undef, t_387);
Call(chirp_36, V.Undef, t_387, ((V)(0.7)));
Invoke(t_387, "to", ((V)(240D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
Call(crest_34, V.Undef, t_387, ((V)(0D)), ((V)(280D)), ((V)("io")));
return Call(loopN_31, V.Undef, Invoke(t_387, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Her crest shoots up, she opens her wings in a heart shape, bobs her head and whistles.")))).Put("surprised", Arr(Call(Fn((V _self9, int _argc388, V _a390, V _a391, V _a392, V _a393, V[] _rest389) => {
V t_394 = default;
t_394 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_394, "wait", ((V)(120D))), "to", ((V)(60D)), NewObj(7).Put("wide", ((V)(1D))).Put("earL", ((V)((-32D)))).Put("earR", ((V)((-32D)))).Put("sq", ((V)((-0.07)))).Put("lift", ((V)(1.5))).Put("armL", ((V)(45D))).Put("armR", ((V)(45D))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(4).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).V, ((V)("i"))), "to", ((V)(150D)), NewObj(3).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("featherY")), ((V)("body")), ((V)(2D)));
Invoke(t_394, "wait", ((V)(280D)));
Call(look_24, V.Undef, t_394, ((V)(0D)), ((V)((-0.55))), NewObj(3).Put("k", ((V)(0.7))).Put("d1", ((V)(140D))).Put("d2", ((V)(170D))).V);
Invoke(t_394, "wait", ((V)(120D)));
Call(look_24, V.Undef, t_394, ((V)((-0.55))), ((V)(0.55)), NewObj(3).Put("k", ((V)(0.7))).Put("d1", ((V)(140D))).Put("d2", ((V)(170D))).V);
Invoke(t_394, "wait", ((V)(120D)));
Call(look_24, V.Undef, t_394, ((V)(0.55)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.7))).V);
Invoke(t_394, "to", ((V)(500D)), NewObj(3).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io")));
Call(chirp_36, V.Undef, t_394, ((V)(0.6)));
return Invoke(Invoke(t_394, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Her crest flies straight up, eyes pop and her wings flick out, a few feathers drift down, she looks around, and the crest slowly lowers.")))).Put("squish", Arr(Call(Fn((V _self9, int _argc395, V _a397, V _a398, V _a399, V _a400, V[] _rest396) => {
V t_401 = default;
t_401 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_401, "to", ((V)(130D)), NewObj(3).Put("sq", ((V)((-0.04)))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(7).Put("sq", ((V)(0.3))).Put("earL", ((V)(26D))).Put("earR", ((V)(26D))).Put("close", ((V)(0.8))).Put("hap", ((V)(0.6))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "wait", ((V)(320D)));
Invoke(Invoke(Invoke(t_401, "to", ((V)(110D)), NewObj(9).Put("sq", ((V)((-0.16)))).Put("earL", ((V)((-32D)))).Put("earR", ((V)((-32D)))).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).Put("wide", ((V)(0.6))).Put("lift", ((V)(3D))).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("featherY")), ((V)("body")), ((V)(3D))), "to", ((V)(200D)), NewObj(6).Put("sq", ((V)(0.06))).Put("lift", ((V)(0D))).Put("earL", ((V)(8D))).Put("earR", ((V)(8D))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("i")));
Call(jelly_28, V.Undef, t_401, ((V)(0.06)), ((V)(2D)), ((V)(260D)));
Invoke(t_401, "to", ((V)(260D)), NewObj(5).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("wide", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return Call(loopN_31, V.Undef, t_401);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed, she puffs into a fluffy ball with her crest flat; let go and she pops up with her crest springing tall.")))).Put("quirk", Arr(Call(Fn((V _self9, int _argc402, V _a404, V _a405, V _a406, V _a407, V[] _rest403) => {
V t_408 = default;
t_408 = Call(TL_17, V.Undef);
Invoke(Invoke(t_408, "to", ((V)(180D)), NewObj(2).Put("lx", ((V)((-0.8)))).Put("ly", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(380D)), NewObj(5).Put("hyaw", ((V)((-0.55)))).Put("pitch", ((V)((-0.25)))).Put("htilt", ((V)((-10D)))).Put("armL", ((V)(32D))).Put("twist", ((V)((-0.12)))).V, ((V)("io")));
{
V i_409 = default;
i_409 = ((V)(0D));
while (true) {
if (!(LtN(i_409, 3D))) break;
Invoke(Invoke(t_408, "to", ((V)(120D)), NewObj(3).Put("pitch", ((V)((-0.32)))).Put("open", ((V)(0.25))).Put("mw", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(4).Put("pitch", ((V)((-0.22)))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hyaw", ((V)(((-0.55) + (NumTruthy((ToNum(i_409) % 2D)) ? 0.05 : (-0.05)))))).V, ((V)("io")));
PostInc(ref i_409, 1D);
}
}
Invoke(t_408, "to", ((V)(360D)), NewObj(7).Put("hyaw", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("twist", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
Invoke(t_408, "to", ((V)(220D)), NewObj(4).Put("sq", ((V)(0.12))).Put("earL", ((V)(18D))).Put("earR", ((V)(18D))).Put("close", ((V)(0.6))).V, ((V)("io")));
Call(shake_25, V.Undef, t_408, NewObj(7).Put("P", ((V)(80D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.8)), ((V)(0.5)), ((V)(0.25)))).Put("head", ((V)(0.3))).Put("roll", ((V)(4D))).Put("ear", ((V)((-14D)))).Put("chest", ((V)(0.1))).Put("body", ((V)(0.6))).V);
Invoke(t_408, "e", ((V)("emit")), ((V)("featherY")), ((V)("body")), ((V)(2D)));
Invoke(t_408, "to", ((V)(260D)), NewObj(4).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
Call(chirp_36, V.Undef, t_408, ((V)(0.6)));
return Invoke(Invoke(Invoke(t_408, "wait", ((V)(200D))), "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Preening")), ((V)("Lifts a wing and nibbles along her feathers, then fluffs right up and shakes every feather back into place, a little whistle.")))).Put("press", NewObj(4).Put("sq", ((V)(0.12))).Put("earL", ((V)(24D))).Put("earR", ((V)(24D))).Put("close", ((V)(0.6))).V).Put("rel", NewObj(3).Put("dur", ((V)(1000D))).Put("k", NewObj(6).Put("earL", Arr(Arr(((V)(0D)), ((V)(24D))), Arr(((V)(120D)), ((V)((-32D))), ((V)("o"))), Arr(((V)(420D)), ((V)(6D)), ((V)("io"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).Put("earR", Arr(Arr(((V)(0D)), ((V)(24D))), Arr(((V)(120D)), ((V)((-32D))), ((V)("o"))), Arr(((V)(420D)), ((V)(6D)), ((V)("io"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.12))), Arr(((V)(100D)), ((V)((-0.14))), ((V)("o"))), Arr(((V)(260D)), ((V)(0.06)), ((V)("io"))), Arr(((V)(420D)), ((V)(0D)), ((V)("io"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(100D)), ((V)(0D)), ((V)("o"))))).Put("armL", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(140D)), ((V)(70D)), ((V)("o"))), Arr(((V)(520D)), ((V)(0D)), ((V)("io"))))).Put("armR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(140D)), ((V)(70D)), ((V)("o"))), Arr(((V)(520D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("featherY")), ((V)("body")), ((V)(2D))))).V).Put("look", Call(Fn((V _self9, int _argc411, V _a413, V _a414, V _a415, V _a416, V[] _rest412) => {
V t_417 = default;
t_417 = Call(TL_17, V.Undef);
Call(look_24, V.Undef, t_417, ((V)(0D)), ((V)((-0.6))), NewObj(1).Put("k", ((V)(0.8))).V);
Invoke(t_417, "wait", ((V)(600D)));
Call(look_24, V.Undef, t_417, ((V)((-0.6))), ((V)(0.6)), NewObj(1).Put("k", ((V)(0.8))).V);
Call(crest_34, V.Undef, t_417, ((V)((-12D))), ((V)(160D)));
Invoke(t_417, "wait", ((V)(500D)));
Call(crest_34, V.Undef, t_417, ((V)(0D)), ((V)(300D)), ((V)("io")));
Call(look_24, V.Undef, t_417, ((V)(0.6)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.8))).V);
return Invoke(Invoke(t_417, "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).Put("pico", NewObj(7).Put("happy", Arr(Call(Fn((V _self9, int _argc418, V _a420, V _a421, V _a422, V _a423, V[] _rest419) => {
V t_424 = default;
t_424 = Call(TL_17, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Invoke(Invoke(t_424, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "osc", ((V)(900D)), ((V)(6D)), NewObj(3).Put("open", ((V)(0.45))).Put("mw", ((V)(0.6))).Put("pitch", ((V)(0.06))).V, NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("o")));
Call(jump_23, V.Undef, t_424, NewObj(8).Put("h", ((V)(6D))).Put("ant", ((V)(110D))).Put("up", ((V)(160D))).Put("c", ((V)(0.12))).Put("arm", ((V)(70D))).Put("x", ((V)(2.5))).Put("air", NewObj(1).Put("tilt", ((V)(4D))).V).Put("fall", NewObj(1).Put("tilt", ((V)(0D))).V).V);
Call(jump_23, V.Undef, t_424, NewObj(8).Put("h", ((V)(6D))).Put("ant", ((V)(110D))).Put("up", ((V)(160D))).Put("c", ((V)(0.12))).Put("arm", ((V)(70D))).Put("x", ((V)((-2.5)))).Put("air", NewObj(1).Put("tilt", ((V)((-4D)))).V).Put("fall", NewObj(1).Put("tilt", ((V)(0D))).V).V);
Call(jump_23, V.Undef, t_424, NewObj(6).Put("h", ((V)(4D))).Put("ant", ((V)(100D))).Put("up", ((V)(140D))).Put("c", ((V)(0.1))).Put("arm", ((V)(50D))).Put("x", ((V)(0D))).V);
Call(bob_33, V.Undef, t_424, ((V)(3D)), ((V)(200D)), ((V)(0.18)));
return Call(loopN_31, V.Undef, Invoke(t_424, "rest", ((V)(250D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Chatters away, hops right, left and home again, then bobs his head.")))).Put("surprised", Arr(Call(Fn((V _self9, int _argc425, V _a427, V _a428, V _a429, V _a430, V[] _rest426) => {
V t_431 = default;
t_431 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_431, "wait", ((V)(100D))), "to", ((V)(60D)), NewObj(3).Put("wide", ((V)(1D))).Put("sq", ((V)(0.1))).Put("lift", ((V)(1D))).V, ((V)("o"))), "to", ((V)(120D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("featherG")), ((V)("body")), ((V)(1D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_431, "wait", ((V)(350D))), "to", ((V)(70D)), NewObj(2).Put("hyaw", ((V)((-0.42)))).Put("lx", ((V)((-0.9)))).V, ((V)("o"))), "wait", ((V)(180D))), "to", ((V)(70D)), NewObj(2).Put("hyaw", ((V)(0.42))).Put("lx", ((V)(0.9))).V, ((V)("o"))), "wait", ((V)(180D))), "to", ((V)(70D)), NewObj(2).Put("hyaw", ((V)((-0.2)))).Put("lx", ((V)((-0.4)))).V, ((V)("o"))), "wait", ((V)(140D))), "to", ((V)(90D)), NewObj(2).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("o")));
Invoke(t_431, "to", ((V)(240D)), NewObj(2).Put("sq", ((V)(0D))).Put("wide", ((V)(0.2))).V, ((V)("io")));
Call(chirp_36, V.Undef, t_431, ((V)(0.8)));
Call(chirp_36, V.Undef, t_431, ((V)(0.6)));
return Invoke(Invoke(t_431, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Puffs up with his eyes popping, freezes, snaps his head left, right, left the way birds do, then two little chirps.")))).Put("squish", Arr(Call(Fn((V _self9, int _argc432, V _a434, V _a435, V _a436, V _a437, V[] _rest433) => {
V t_438 = default;
t_438 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_438, "to", ((V)(120D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(5).Put("sq", ((V)(0.32))).Put("close", ((V)(0.7))).Put("hap", ((V)(0.5))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(80D)), NewObj(5).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).Put("wide", ((V)(0.5))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("o")));
Call(flutter_42, V.Undef, t_438, ((V)(9D)), ((V)(520D)), ((V)(4D)));
Invoke(Invoke(t_438, "e", ((V)("emit")), ((V)("featherG")), ((V)("body")), ((V)(2D))), "to", ((V)(160D)), NewObj(1).Put("wide", ((V)(0D))).V, ((V)("io")));
Call(chirp_36, V.Undef, t_438);
return Call(loopN_31, V.Undef, t_438);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed, he puffs into a round ball; let go and he flutters up and chirps.")))).Put("quirk", Arr(Call(Fn((V _self9, int _argc439, V _a441, V _a442, V _a443, V _a444, V[] _rest440) => {
V t_445 = default;
t_445 = Call(TL_17, V.Undef);
Call(look_24, V.Undef, t_445, ((V)(0D)), ((V)(0.55)), NewObj(3).Put("k", ((V)(0.8))).Put("d1", ((V)(140D))).Put("d2", ((V)(170D))).V);
Invoke(Invoke(t_445, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "osc", ((V)(1100D)), ((V)(8D)), NewObj(3).Put("open", ((V)(0.4))).Put("mw", ((V)(0.6))).Put("pitch", ((V)(0.05))).V, NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("o")));
Call(bob_33, V.Undef, t_445, ((V)(3D)), ((V)(220D)), ((V)(0.18)));
Invoke(Invoke(Invoke(t_445, "to", ((V)(160D)), NewObj(4).Put("pitch", ((V)((-0.12)))).Put("hyaw", ((V)(0.66))).Put("mw", ((V)(0.5))).Put("open", ((V)(0.15))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "to", ((V)(220D)), NewObj(4).Put("pitch", ((V)(0D))).Put("hyaw", ((V)(0.55))).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).V, ((V)("io")));
Call(look_24, V.Undef, t_445, ((V)(0.55)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.8))).V);
return Invoke(Invoke(t_445, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Mirror chat")), ((V)("Turns to the bird in his mirror, chatters at it, bobs his head and gives it a little kiss.")))).Put("press", NewObj(2).Put("sq", ((V)(0.14))).Put("close", ((V)(0.6))).V).Put("rel", NewObj(3).Put("dur", ((V)(900D))).Put("k", NewObj(5).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(240D)), ((V)(8D)), ((V)("o"))), Arr(((V)(520D)), ((V)(0D)), ((V)("io"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.14))), Arr(((V)(80D)), ((V)((-0.12))), ((V)("o"))), Arr(((V)(500D)), ((V)((-0.02))), ((V)("io"))), Arr(((V)(600D)), ((V)(0.08)), ((V)("o"))), Arr(((V)(760D)), ((V)(0D)), ((V)("io"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(80D)), ((V)(0D)), ((V)("o"))))).Put("armL", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(80D)), ((V)(110D)), ((V)("o"))), Arr(((V)(180D)), ((V)(40D)), ((V)("io"))), Arr(((V)(280D)), ((V)(110D)), ((V)("o"))), Arr(((V)(380D)), ((V)(40D)), ((V)("io"))), Arr(((V)(480D)), ((V)(100D)), ((V)("o"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).Put("armR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(80D)), ((V)(110D)), ((V)("o"))), Arr(((V)(180D)), ((V)(40D)), ((V)("io"))), Arr(((V)(280D)), ((V)(110D)), ((V)("o"))), Arr(((V)(380D)), ((V)(40D)), ((V)("io"))), Arr(((V)(480D)), ((V)(100D)), ((V)("o"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("featherG")), ((V)("body")), ((V)(2D))))).V).Put("look", Call(Fn((V _self9, int _argc446, V _a448, V _a449, V _a450, V _a451, V[] _rest447) => {
V t_452 = default;
t_452 = Call(TL_17, V.Undef);
Call(look_24, V.Undef, t_452, ((V)(0D)), ((V)((-0.6))), NewObj(3).Put("k", ((V)(0.8))).Put("d1", ((V)(130D))).Put("d2", ((V)(160D))).V);
Invoke(t_452, "wait", ((V)(450D)));
Call(look_24, V.Undef, t_452, ((V)((-0.6))), ((V)(0.6)), NewObj(3).Put("k", ((V)(0.8))).Put("d1", ((V)(130D))).Put("d2", ((V)(160D))).V);
Invoke(t_452, "wait", ((V)(450D)));
Call(look_24, V.Undef, t_452, ((V)(0.6)), ((V)(0D)), NewObj(3).Put("k", ((V)(0.8))).Put("d1", ((V)(130D))).Put("d2", ((V)(160D))).V);
return Invoke(Invoke(t_452, "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).Put("clover", NewObj(7).Put("happy", Arr(Call(Fn((V _self9, int _argc453, V _a455, V _a456, V _a457, V _a458, V[] _rest454) => {
V t_459 = default;
t_459 = Call(TL_17, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Call(twitch_41, V.Undef, t_459, ((V)(3D)));
Call(binky_45, V.Undef, t_459, ((V)(1D)), ((V)(12D)));
Call(binky_45, V.Undef, t_459, ((V)((-1D))), ((V)(13D)));
Invoke(t_459, "wait", ((V)(120D)));
Call(twitch_41, V.Undef, t_459, ((V)(2D)));
return Call(loopN_31, V.Undef, Invoke(t_459, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Nose twitching, she does two binkies - leaping up with a twist and a kick, her long ears flying out.")))).Put("surprised", Arr(Call(Fn((V _self9, int _argc460, V _a462, V _a463, V _a464, V _a465, V[] _rest461) => {
V t_466 = default;
t_466 = Call(TL_17, V.Undef);
Invoke(Invoke(t_466, "wait", ((V)(120D))), "to", ((V)(70D)), NewObj(2).Put("wide", ((V)(1D))).Put("sq", ((V)(0.05))).V, ((V)("o")));
Call(thump_46, V.Undef, t_466, ((V)(1D)));
Invoke(t_466, "wait", ((V)(200D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_466, "to", ((V)(200D)), NewObj(2).Put("earL", ((V)((-7D)))).Put("earR", ((V)((-7D)))).V, ((V)("o"))), "wait", ((V)(300D))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(280D))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(280D)));
Call(twitch_41, V.Undef, t_466, ((V)(4D)));
Invoke(t_466, "to", ((V)(300D)), NewObj(4).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_466, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Eyes pop and she thumps a back foot, freezes with her ears pricked straight up while her eyes dart around, then her nose starts twitching again.")))).Put("squish", Arr(Call(Fn((V _self9, int _argc467, V _a469, V _a470, V _a471, V _a472, V[] _rest468) => {
V t_473 = default;
t_473 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_473, "to", ((V)(120D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(6).Put("sq", ((V)(0.3))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).Put("close", ((V)(0.8))).Put("hap", ((V)(0.6))).Put("pitch", ((V)((-0.08)))).V, ((V)("io"))), "wait", ((V)(320D)));
Invoke(t_473, "to", ((V)(60D)), NewObj(2).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("o")));
Call(binky_45, V.Undef, t_473, ((V)(1D)), ((V)(14D)));
Invoke(t_473, "to", ((V)(200D)), NewObj(3).Put("pitch", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return Call(loopN_31, V.Undef, t_473);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed into a bunny loaf; let go and she binkies straight up.")))).Put("quirk", Arr(Call(Fn((V _self9, int _argc474, V _a476, V _a477, V _a478, V _a479, V[] _rest475) => {
V t_480 = default;
t_480 = Call(TL_17, V.Undef);
Invoke(t_480, "to", ((V)(300D)), Call(o_21, V.Undef, Call(both_20, V.Undef, ((V)(4D)), ((V)((-16D)))), NewObj(4).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("pitch", ((V)((-0.08)))).Put("close", ((V)(0.8))).V), ((V)("io")));
{
V i_481 = default;
i_481 = ((V)(0D));
while (true) {
if (!(LtN(i_481, 3D))) break;
Invoke(Invoke(t_480, "to", ((V)(220D)), Call(o_21, V.Undef, Call(both_20, V.Undef, ((V)(5D)), ((V)((-22D)))), NewObj(1).Put("pitch", ((V)((-0.12)))).V), ((V)("io"))), "to", ((V)(200D)), Call(o_21, V.Undef, Call(both_20, V.Undef, ((V)(4D)), ((V)((-13D)))), NewObj(1).Put("pitch", ((V)((-0.06)))).V), ((V)("io")));
PostInc(ref i_481, 1D);
}
}
Invoke(t_480, "to", ((V)(320D)), Call(o_21, V.Undef, Call(hand_19, V.Undef, ((V)((-1D))), ((V)((-4D))), ((V)((-24D)))), NewObj(7).Put("armL", ((V)(40D))).Put("armR", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("htilt", ((V)((-12D)))).Put("earL", ((V)((-16D)))).Put("close", ((V)(0.5))).V), ((V)("io")));
Invoke(t_480, "osc", ((V)(900D)), ((V)(3D)), NewObj(3).Put("tongue", ((V)(0.8))).Put("open", ((V)(0.2))).Put("hLy", ((V)((-20D)))).V, NewObj(3).Put("tongue", ((V)(0.1))).Put("open", ((V)(0D))).Put("hLy", ((V)((-24D)))).V, ((V)("io")));
Invoke(t_480, "to", ((V)(300D)), Call(o_21, V.Undef, NOHANDS_22, NewObj(7).Put("armL", ((V)(0D))).Put("htilt", ((V)(0D))).Put("earL", ((V)(0D))).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("close", ((V)(0D))).Put("pitch", ((V)(0D))).V), ((V)("io")));
Call(headShake_60, V.Undef, t_480, ((V)(0.7)));
Call(twitch_41, V.Undef, t_480, ((V)(3D)));
return Invoke(Invoke(Invoke(t_480, "wait", ((V)(200D))), "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Face wash")), ((V)("Washes her face with both paws, tips her head and pulls a long ear down to lick it clean, a quick head shake, nose twitch.")))).Put("press", NewObj(4).Put("sq", ((V)(0.14))).Put("earL", ((V)((-8D)))).Put("earR", ((V)((-8D)))).Put("close", ((V)(0.6))).V).Put("rel", NewObj(2).Put("dur", ((V)(1100D))).Put("k", NewObj(6).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)(12D)), ((V)("o"))), Arr(((V)(520D)), ((V)(0D)), ((V)("i"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.14))), Arr(((V)(60D)), ((V)((-0.16))), ((V)("o"))), Arr(((V)(260D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(460D)), ((V)((-0.08))), ((V)("i"))), Arr(((V)(540D)), ((V)(0.16)), ((V)("o"))), Arr(((V)(700D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(840D)), ((V)(0D)), ((V)("io"))))).Put("earL", Arr(Arr(((V)(0D)), ((V)((-8D)))), Arr(((V)(200D)), ((V)(28D)), ((V)("o"))), Arr(((V)(520D)), ((V)((-6D))), ((V)("io"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))).Put("earR", Arr(Arr(((V)(0D)), ((V)((-8D)))), Arr(((V)(200D)), ((V)(28D)), ((V)("o"))), Arr(((V)(520D)), ((V)((-6D))), ((V)("io"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))).Put("tilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(8D)), ((V)("o"))), Arr(((V)(500D)), ((V)(0D)), ((V)("io"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(60D)), ((V)(0D)), ((V)("o"))))).V).V).Put("look", Call(Fn((V _self9, int _argc483, V _a485, V _a486, V _a487, V _a488, V[] _rest484) => {
V t_489 = default;
t_489 = Call(TL_17, V.Undef);
Call(look_24, V.Undef, t_489, ((V)(0D)), ((V)((-0.6))), NewObj(1).Put("k", ((V)(0.8))).V);
Call(twitch_41, V.Undef, t_489, ((V)(2D)));
Invoke(t_489, "wait", ((V)(500D)));
Call(look_24, V.Undef, t_489, ((V)((-0.6))), ((V)(0.6)), NewObj(1).Put("k", ((V)(0.8))).V);
Call(twitch_41, V.Undef, t_489, ((V)(2D)));
Invoke(t_489, "wait", ((V)(500D)));
Call(look_24, V.Undef, t_489, ((V)(0.6)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.8))).V);
return Invoke(Invoke(t_489, "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).Put("chilla", NewObj(7).Put("happy", Arr(Call(Fn((V _self9, int _argc490, V _a492, V _a493, V _a494, V _a495, V[] _rest491) => {
V t_496 = default;
t_496 = Call(TL_17, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Call(popcorn_29, V.Undef, t_496, ((V)(13D)), ((V)(1D)), ((V)(520D)));
Invoke(t_496, "wait", ((V)(150D)));
Call(popcorn_29, V.Undef, t_496, ((V)(15D)), ((V)((-1D))), ((V)(540D)));
Invoke(t_496, "e", ((V)("emit")), ((V)("poof")), ((V)("body")), ((V)(2D)));
Invoke(Invoke(t_496, "osc", ((V)(800D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(24D))).V, NewObj(1).Put("wag", ((V)((-24D)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("wag", ((V)(0D))).V, ((V)("io")));
return Call(loopN_31, V.Undef, Invoke(t_496, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Popcorns twice - springing straight up with a twist in the air - and swishes her bushy tail.")))).Put("surprised", Arr(Call(Fn((V _self9, int _argc497, V _a499, V _a500, V _a501, V _a502, V[] _rest498) => {
V t_503 = default;
t_503 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_503, "wait", ((V)(120D))), "to", ((V)(60D)), NewObj(4).Put("wide", ((V)(1D))).Put("earL", ((V)((-12D)))).Put("earR", ((V)((-12D)))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "wait", ((V)(450D)));
Call(jump_23, V.Undef, t_503, NewObj(6).Put("h", ((V)(7D))).Put("ant", ((V)(60D))).Put("up", ((V)(180D))).Put("c", ((V)(0.1))).Put("arm", ((V)(30D))).Put("x", ((V)((-3D)))).V);
Invoke(t_503, "e", ((V)("emit")), ((V)("poof")), ((V)("body")), ((V)(2D)));
Invoke(Invoke(Invoke(Invoke(t_503, "to", ((V)(90D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(250D)));
Call(stepTo_43, V.Undef, t_503, Arr(((V)((-1.5))), ((V)(0D))), ((V)(220D)), ((V)(2D)));
Invoke(t_503, "to", ((V)(300D)), NewObj(5).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_503, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Freezes with her big ears forward, hops back, eyes darting, then steps back to her spot.")))).Put("squish", Arr(Call(Fn((V _self9, int _argc504, V _a506, V _a507, V _a508, V _a509, V[] _rest505) => {
V t_510 = default;
t_510 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_510, "to", ((V)(120D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(5).Put("sq", ((V)(0.34))).Put("close", ((V)(0.9))).Put("hap", ((V)(0.8))).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).V, ((V)("io"))), "wait", ((V)(320D))), "to", ((V)(60D)), NewObj(2).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("o")));
Call(popcorn_29, V.Undef, t_510, ((V)(16D)), ((V)(1D)), ((V)(560D)));
Invoke(Invoke(t_510, "e", ((V)("emit")), ((V)("poof")), ((V)("body")), ((V)(3D))), "to", ((V)(260D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return Call(loopN_31, V.Undef, t_510);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed into a soft fluffball; let go and she popcorns up in a puff of dust.")))).Put("quirk", Arr(Call(Fn((V _self9, int _argc511, V _a513, V _a514, V _a515, V _a516, V[] _rest512) => {
V t_517 = default;
t_517 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_517, "to", ((V)(160D)), NewObj(2).Put("ly", ((V)(0.8))).Put("pitch", ((V)((-0.15)))).V, ((V)("o"))), "wait", ((V)(150D))), "to", ((V)(200D)), NewObj(4).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(bathIn_48, V.Undef, t_517);
Invoke(Invoke(t_517, "osc", ((V)(600D)), ((V)(3D)), NewObj(2).Put("mw", ((V)(0.7))).Put("pitch", ((V)((-0.12)))).V, NewObj(2).Put("mw", ((V)(1D))).Put("pitch", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(1).Put("pitch", ((V)(0D))).V, ((V)("io")));
Call(rollBath_56, V.Undef, t_517, ((V)(12D)));
Invoke(t_517, "wait", ((V)(120D)));
Call(bathOut_58, V.Undef, t_517);
Invoke(t_517, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0.6))).V, ((V)("io")));
Call(dustOff_57, V.Undef, t_517, ((V)(520D)));
Call(shake_25, V.Undef, t_517, NewObj(8).Put("P", ((V)(85D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.85)), ((V)(0.5)), ((V)(0.25)))).Put("head", ((V)(0.3))).Put("roll", ((V)(5D))).Put("ear", ((V)(12D))).Put("chest", ((V)(0.1))).Put("body", ((V)(0.8))).Put("tail", ((V)(30D))).V);
Invoke(Invoke(Invoke(t_517, "e", ((V)("emit")), ((V)("poof")), ((V)("head")), ((V)(2D))), "e", ((V)("emit")), ((V)("poof")), ((V)("sideL")), ((V)(1D))), "e", ((V)("emit")), ((V)("poof")), ((V)("sideR")), ((V)(1D)));
return Invoke(Invoke(Invoke(t_517, "wait", ((V)(200D))), "rest", ((V)(400D))), "done", NewObj(2).Put("stretch", ((V)(0.3))).Put("soft", ((V)(0.45))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Dust bath")), ((V)("Her big dust-bath tub pops in under her: she hops in, sniffs the dust, flops right over onto her side and rolls onto her back and over, feet in the air, dust flying; then she rolls back up, hops out - the tub pops away - and shakes the dust off.")))).Put("press", NewObj(3).Put("sq", ((V)(0.16))).Put("close", ((V)(0.7))).Put("hap", ((V)(0.6))).V).Put("rel", NewObj(3).Put("dur", ((V)(1000D))).Put("k", NewObj(5).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)(15D)), ((V)("o"))), Arr(((V)(520D)), ((V)(0D)), ((V)("i"))))).Put("spin", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(520D)), ((V)(180D)), ((V)("io"))), Arr(((V)(521D)), ((V)((-180D))), ((V)("l"))), Arr(((V)(900D)), ((V)(0D)), ((V)("io"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.16))), Arr(((V)(60D)), ((V)((-0.18))), ((V)("o"))), Arr(((V)(260D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(460D)), ((V)((-0.08))), ((V)("i"))), Arr(((V)(540D)), ((V)(0.18)), ((V)("o"))), Arr(((V)(700D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(840D)), ((V)(0D)), ((V)("io"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0.7))), Arr(((V)(60D)), ((V)(0D)), ((V)("o"))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(60D)), ((V)(1D)), ((V)("o"))), Arr(((V)(900D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("poof")), ((V)("body")), ((V)(3D))))).V).Put("look", Call(Fn((V _self9, int _argc518, V _a520, V _a521, V _a522, V _a523, V[] _rest519) => {
V t_524 = default;
t_524 = Call(TL_17, V.Undef);
Call(look_24, V.Undef, t_524, ((V)(0D)), ((V)((-0.6))), NewObj(1).Put("k", ((V)(0.8))).V);
Invoke(t_524, "wait", ((V)(500D)));
Call(look_24, V.Undef, t_524, ((V)((-0.6))), ((V)(0.6)), NewObj(1).Put("k", ((V)(0.8))).V);
Invoke(t_524, "wait", ((V)(500D)));
Call(look_24, V.Undef, t_524, ((V)(0.6)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.8))).V);
return Invoke(Invoke(t_524, "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).Put("mimi", NewObj(7).Put("happy", Arr(Call(Fn((V _self9, int _argc525, V _a527, V _a528, V _a529, V _a530, V[] _rest526) => {
V t_531 = default;
t_531 = Call(TL_17, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Invoke(t_531, "to", ((V)(220D)), NewObj(3).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(1.5))).Put("pitch", ((V)(0.06))).V, ((V)("o")));
Invoke(t_531, "to", ((V)(160D)), Call(both_20, V.Undef, ((V)(6D)), ((V)((-4D)))), ((V)("io")));
{
V i_532 = default;
i_532 = ((V)(0D));
while (true) {
if (!(LtN(i_532, 4D))) break;
Invoke(Invoke(t_531, "to", ((V)(90D)), Call(both_20, V.Undef, ((V)(2D)), ((V)((-5D)))), ((V)("o"))), "to", ((V)(110D)), Call(both_20, V.Undef, ((V)(6D)), ((V)((-4D)))), ((V)("io")));
PostInc(ref i_532, 1D);
}
}
Call(squeak_38, V.Undef, t_531);
Invoke(t_531, "osc", ((V)(700D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(28D))).V, NewObj(1).Put("wag", ((V)((-28D)))).V, ((V)("io")));
Invoke(t_531, "to", ((V)(240D)), Call(o_21, V.Undef, NOHANDS_22, NewObj(4).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("pitch", ((V)(0D))).Put("wag", ((V)(0D))).V), ((V)("io")));
return Call(loopN_31, V.Undef, Invoke(t_531, "rest", ((V)(250D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Stands up on her tiptoes, claps her tiny paws, squeaks and wiggles her tail.")))).Put("surprised", Arr(Call(Fn((V _self9, int _argc534, V _a536, V _a537, V _a538, V _a539, V[] _rest535) => {
V t_540 = default;
t_540 = Call(TL_17, V.Undef);
Invoke(Invoke(t_540, "wait", ((V)(100D))), "to", ((V)(60D)), NewObj(1).Put("wide", ((V)(1D))).V, ((V)("o")));
Call(squeak_38, V.Undef, t_540);
Call(jump_23, V.Undef, t_540, NewObj(6).Put("h", ((V)(9D))).Put("ant", ((V)(50D))).Put("up", ((V)(180D))).Put("c", ((V)(0.1))).Put("arm", ((V)(60D))).Put("st", ((V)(1.2))).V);
Invoke(Invoke(t_540, "to", ((V)(100D)), NewObj(3).Put("sq", ((V)(0.06))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V, ((V)("o"))), "wait", ((V)(450D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_540, "to", ((V)(90D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(200D))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(200D))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)(0D))).V, ((V)("o")));
Invoke(t_540, "osc", ((V)(700D)), ((V)(5D)), NewObj(4).Put("mw", ((V)(0.7))).Put("pitch", ((V)(0.06))).Put("earL", ((V)((-4D)))).Put("earR", ((V)((-4D)))).V, NewObj(4).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V, ((V)("o")));
Invoke(t_540, "to", ((V)(300D)), NewObj(4).Put("wide", ((V)(0D))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_540, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Squeaks and jumps straight up, freezes with her ears forward, eyes darting, then sniffs the air with her whiskers twitching.")))).Put("squish", Arr(Call(Fn((V _self9, int _argc541, V _a543, V _a544, V _a545, V _a546, V[] _rest542) => {
V t_547 = default;
t_547 = Call(TL_17, V.Undef);
Invoke(Invoke(t_547, "to", ((V)(120D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(5).Put("sq", ((V)(0.3))).Put("close", ((V)(1D))).Put("hap", ((V)(0.6))).Put("earL", ((V)(12D))).Put("earR", ((V)(12D))).V, ((V)("io")));
Call(squeak_38, V.Undef, t_547);
Invoke(Invoke(t_547, "wait", ((V)(200D))), "to", ((V)(60D)), NewObj(2).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("o")));
Call(jump_23, V.Undef, t_547, NewObj(6).Put("h", ((V)(10D))).Put("ant", ((V)(40D))).Put("up", ((V)(200D))).Put("c", ((V)(0.3))).Put("arm", ((V)(50D))).Put("st", ((V)(1.2))).V);
Invoke(t_547, "to", ((V)(220D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return Call(loopN_31, V.Undef, t_547);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed, she squeaks; let go and she springs up.")))).Put("quirk", Arr(Call(Fn((V _self9, int _argc548, V _a550, V _a551, V _a552, V _a553, V[] _rest549) => {
V t_554 = default;
t_554 = Call(TL_17, V.Undef);
Invoke(t_554, "to", ((V)(240D)), Call(o_21, V.Undef, Call(both_20, V.Undef, ((V)(5D)), ((V)((-15D)))), NewObj(4).Put("armL", ((V)(34D))).Put("armR", ((V)(34D))).Put("sq", ((V)((-0.04)))).Put("pitch", ((V)((-0.06)))).V), ((V)("io")));
{
V i_555 = default;
i_555 = ((V)(0D));
while (true) {
if (!(LtN(i_555, 4D))) break;
Invoke(Invoke(t_554, "to", ((V)(110D)), Call(o_21, V.Undef, Call(both_20, V.Undef, ((V)(9D)), ((V)((-13D)))), NewObj(1).Put("htilt", ((V)((NumTruthy((ToNum(i_555) % 2D)) ? 4D : (-4D))))).V), ((V)("io"))), "to", ((V)(110D)), Call(both_20, V.Undef, ((V)(4D)), ((V)((-15D)))), ((V)("io")));
PostInc(ref i_555, 1D);
}
}
Invoke(t_554, "to", ((V)(240D)), Call(o_21, V.Undef, Call(both_20, V.Undef, ((V)(2D)), ((V)((-13D)))), NewObj(2).Put("pitch", ((V)((-0.12)))).Put("ly", ((V)(0.5))).V), ((V)("io")));
Invoke(Invoke(t_554, "osc", ((V)(900D)), ((V)(6D)), NewObj(3).Put("open", ((V)(0.25))).Put("mw", ((V)(0.6))).Put("puff", ((V)(0.3))).V, NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("head")), ((V)(2D)));
Invoke(t_554, "to", ((V)(260D)), Call(o_21, V.Undef, NOHANDS_22, NewObj(8).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io")));
Call(squeak_38, V.Undef, t_554);
return Invoke(Invoke(Invoke(t_554, "wait", ((V)(200D))), "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Whisker wash")), ((V)("Sits up and gives her whiskers a quick wash with both paws, finds a crumb and nibbles it super fast, then a happy squeak.")))).Put("press", NewObj(4).Put("sq", ((V)(0.14))).Put("close", ((V)(1D))).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).V).Put("rel", NewObj(2).Put("dur", ((V)(900D))).Put("k", NewObj(6).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(220D)), ((V)(10D)), ((V)("o"))), Arr(((V)(440D)), ((V)(0D)), ((V)("i"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.14))), Arr(((V)(60D)), ((V)((-0.14))), ((V)("o"))), Arr(((V)(220D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(400D)), ((V)((-0.06))), ((V)("i"))), Arr(((V)(460D)), ((V)(0.12)), ((V)("o"))), Arr(((V)(620D)), ((V)(0D)), ((V)("io"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(60D)), ((V)(0D)), ((V)("o"))))).Put("earL", Arr(Arr(((V)(0D)), ((V)(10D))), Arr(((V)(220D)), ((V)((-12D))), ((V)("o"))), Arr(((V)(600D)), ((V)(0D)), ((V)("io"))))).Put("earR", Arr(Arr(((V)(0D)), ((V)(10D))), Arr(((V)(220D)), ((V)((-12D))), ((V)("o"))), Arr(((V)(600D)), ((V)(0D)), ((V)("io"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(80D)), ((V)(0.4)), ((V)("o"))), Arr(((V)(260D)), ((V)(0D)), ((V)("io"))))).V).V).Put("look", Call(Fn((V _self9, int _argc557, V _a559, V _a560, V _a561, V _a562, V[] _rest558) => {
V t_563 = default;
t_563 = Call(TL_17, V.Undef);
Call(look_24, V.Undef, t_563, ((V)(0D)), ((V)((-0.6))), NewObj(3).Put("k", ((V)(0.8))).Put("d1", ((V)(140D))).Put("d2", ((V)(170D))).V);
Invoke(t_563, "osc", ((V)(480D)), ((V)(3D)), NewObj(1).Put("mw", ((V)(0.75))).V, NewObj(1).Put("mw", ((V)(1D))).V, ((V)("o")));
Invoke(t_563, "wait", ((V)(300D)));
Call(look_24, V.Undef, t_563, ((V)((-0.6))), ((V)(0.6)), NewObj(3).Put("k", ((V)(0.8))).Put("d1", ((V)(140D))).Put("d2", ((V)(170D))).V);
Invoke(t_563, "wait", ((V)(450D)));
Call(look_24, V.Undef, t_563, ((V)(0.6)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.8))).V);
return Invoke(Invoke(t_563, "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).Put("puddles", NewObj(7).Put("happy", Arr(Call(Fn((V _self9, int _argc564, V _a566, V _a567, V _a568, V _a569, V[] _rest565) => {
V t_570 = default;
t_570 = Call(TL_17, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Invoke(Invoke(t_570, "osc", ((V)(700D)), ((V)(5D)), NewObj(1).Put("wag", ((V)(30D))).V, NewObj(1).Put("wag", ((V)((-30D)))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).Put("wag", ((V)(0D))).V, ((V)("io")));
Call(flap_35, V.Undef, t_570, ((V)(3D)), ((V)(260D)), ((V)(100D)));
Invoke(t_570, "to", ((V)(160D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(quack_37, V.Undef, t_570);
Call(jump_23, V.Undef, t_570, NewObj(5).Put("h", ((V)(6D))).Put("ant", ((V)(130D))).Put("up", ((V)(180D))).Put("c", ((V)(0.14))).Put("arm", ((V)(70D))).V);
Call(quack_37, V.Undef, t_570);
return Call(loopN_31, V.Undef, Invoke(t_570, "rest", ((V)(250D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Waggles her little tail, flaps her wings, quacks, a happy hop and another quack.")))).Put("surprised", Arr(Call(Fn((V _self9, int _argc571, V _a573, V _a574, V _a575, V _a576, V[] _rest572) => {
V t_577 = default;
t_577 = Call(TL_17, V.Undef);
Invoke(Invoke(t_577, "wait", ((V)(100D))), "to", ((V)(60D)), NewObj(3).Put("wide", ((V)(1D))).Put("earL", ((V)((-20D)))).Put("earR", ((V)((-20D)))).V, ((V)("o")));
Call(quack_37, V.Undef, t_577);
Call(jump_23, V.Undef, t_577, NewObj(7).Put("h", ((V)(9D))).Put("ant", ((V)(50D))).Put("up", ((V)(190D))).Put("c", ((V)(0.1))).Put("arm", ((V)(110D))).Put("st", ((V)(1.2))).Put("ev", Arr(Arr(((V)("emit")), ((V)("fluffY")), ((V)("body")), ((V)(2D))))).V);
Invoke(t_577, "wait", ((V)(250D)));
Call(waddle_44, V.Undef, t_577, Arr(((V)((-1.5))), ((V)((-3D))), ((V)((-1.5))), ((V)(0D))), ((V)(260D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_577, "to", ((V)(90D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(220D))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(220D))), "to", ((V)(300D)), NewObj(4).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_577, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Quacks with her head fluff standing up, jumps with her wings out, waddles back a step, eyes darting.")))).Put("squish", Arr(Call(Fn((V _self9, int _argc578, V _a580, V _a581, V _a582, V _a583, V[] _rest579) => {
V t_584 = default;
t_584 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_584, "to", ((V)(120D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(5).Put("sq", ((V)(0.36))).Put("close", ((V)(1D))).Put("hap", ((V)(0.5))).Put("mw", ((V)(0.6))).Put("open", ((V)(0.3))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "wait", ((V)(280D)));
Invoke(t_584, "to", ((V)(60D)), NewObj(4).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).V, ((V)("o")));
Call(jump_23, V.Undef, t_584, NewObj(6).Put("h", ((V)(10D))).Put("ant", ((V)(40D))).Put("up", ((V)(210D))).Put("c", ((V)(0.34))).Put("arm", ((V)(90D))).Put("st", ((V)(1.25))).V);
Call(quack_37, V.Undef, t_584);
return Call(loopN_31, V.Undef, t_584);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed like a squeaky bath toy - squeak! - let go and she bounces up with a quack.")))).Put("quirk", Arr(Call(Fn((V _self9, int _argc585, V _a587, V _a588, V _a589, V _a590, V[] _rest586) => {
V t_591 = default;
t_591 = Call(TL_17, V.Undef);
Invoke(Invoke(t_591, "to", ((V)(110D)), NewObj(1).Put("ly", ((V)(0.9))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("pitch", ((V)((-0.22)))).V, ((V)("io")));
{
V i_592 = default;
i_592 = ((V)(0D));
while (true) {
if (!(LtN(i_592, 4D))) break;
V f_594 = default;
f_594 = ((V)((NumTruthy((ToNum(i_592) % 2D)) ? "footL" : "footR")));
Invoke(Invoke(Invoke(Invoke(t_591, "to", ((V)(140D)), NewObj(3).PutK(f_594, ((V)(3.5))).Put("tilt", ((V)((NumTruthy((ToNum(i_592) % 2D)) ? (-4D) : 4D)))).Put("sq", ((V)((-0.03)))).V, ((V)("o"))), "to", ((V)(90D)), NewObj(2).PutK(f_594, ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("splash")), ((V)("body")), ((V)(2D))), "to", ((V)(120D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
PostInc(ref i_592, 1D);
}
}
Invoke(Invoke(Invoke(t_591, "to", ((V)(260D)), NewObj(6).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("tilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(5D)), NewObj(2).Put("wag", ((V)(30D))).Put("sq", ((V)(0.03))).V, NewObj(2).Put("wag", ((V)((-30D)))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(2).Put("wag", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_591, "wait", ((V)(200D))), "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Puddle stomp")), ((V)("Spots a puddle and stomps in it - splash, splash, splash, splash - then giggles with her tail waggling.")))).Put("press", NewObj(4).Put("sq", ((V)(0.18))).Put("close", ((V)(1D))).Put("mw", ((V)(0.6))).Put("open", ((V)(0.25))).V).Put("rel", NewObj(2).Put("dur", ((V)(1000D))).Put("k", NewObj(8).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(240D)), ((V)(11D)), ((V)("o"))), Arr(((V)(480D)), ((V)(0D)), ((V)("i"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.18))), Arr(((V)(60D)), ((V)((-0.16))), ((V)("o"))), Arr(((V)(240D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(420D)), ((V)((-0.08))), ((V)("i"))), Arr(((V)(500D)), ((V)(0.16)), ((V)("o"))), Arr(((V)(660D)), ((V)(0D)), ((V)("io"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(60D)), ((V)(0D)), ((V)("o"))))).Put("mw", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(80D)), ((V)(1D)), ((V)("o"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0.25))), Arr(((V)(520D)), ((V)(0.6)), ((V)("o"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(520D)), ((V)(30D)), ((V)("io"))), Arr(((V)(640D)), ((V)((-30D))), ((V)("io"))), Arr(((V)(760D)), ((V)(20D)), ((V)("io"))), Arr(((V)(880D)), ((V)(0D)), ((V)("io"))))).Put("armL", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(100D)), ((V)("o"))), Arr(((V)(500D)), ((V)(0D)), ((V)("io"))))).Put("armR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(100D)), ((V)("o"))), Arr(((V)(500D)), ((V)(0D)), ((V)("io"))))).V).V).Put("look", Call(Fn((V _self9, int _argc595, V _a597, V _a598, V _a599, V _a600, V[] _rest596) => {
V t_601 = default;
t_601 = Call(TL_17, V.Undef);
Call(look_24, V.Undef, t_601, ((V)(0D)), ((V)((-0.6))), NewObj(1).Put("k", ((V)(0.8))).V);
Invoke(t_601, "wait", ((V)(500D)));
Call(look_24, V.Undef, t_601, ((V)((-0.6))), ((V)(0.6)), NewObj(1).Put("k", ((V)(0.8))).V);
Invoke(Invoke(t_601, "osc", ((V)(500D)), ((V)(3D)), NewObj(1).Put("wag", ((V)(20D))).V, NewObj(1).Put("wag", ((V)((-20D)))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).Put("wag", ((V)(0D))).V);
Invoke(t_601, "wait", ((V)(300D)));
Call(look_24, V.Undef, t_601, ((V)(0.6)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.8))).V);
return Invoke(Invoke(t_601, "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).Put("bean", NewObj(7).Put("happy", Arr(Call(Fn((V _self9, int _argc602, V _a604, V _a605, V _a606, V _a607, V[] _rest603) => {
V t_608 = default;
t_608 = Call(TL_17, V.Undef, NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("tongue", ((V)(0.5))).Put("open", ((V)(0.25))).V);
Call(snort_39, V.Undef, t_608, ((V)(2D)));
Call(swing_26, V.Undef, t_608, ((V)(1400D)), ((V)(7D)), NewObj(4).Put("x", ((V)(1.4))).Put("tilt", ((V)(4D))).Put("wag", ((V)(40D))).Put("bend", ((V)(2D))).V);
Call(jump_23, V.Undef, t_608, NewObj(5).Put("h", ((V)(5D))).Put("ant", ((V)(140D))).Put("up", ((V)(170D))).Put("c", ((V)(0.14))).Put("arm", ((V)(30D))).V);
Call(snort_39, V.Undef, t_608, ((V)(1D)));
return Call(loopN_31, V.Undef, Invoke(t_608, "rest", ((V)(250D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Tongue out, two happy snorts, a big butt wiggle with his curly tail going, a little hop.")))).Put("surprised", Arr(Call(Fn((V _self9, int _argc609, V _a611, V _a612, V _a613, V _a614, V[] _rest610) => {
V t_615 = default;
t_615 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_615, "wait", ((V)(120D))), "to", ((V)(70D)), NewObj(4).Put("wide", ((V)(1D))).Put("earL", ((V)((-12D)))).Put("earR", ((V)((-12D)))).Put("sq", ((V)(0.04))).V, ((V)("o"))), "wait", ((V)(250D)));
Invoke(Invoke(Invoke(Invoke(t_615, "to", ((V)(320D)), NewObj(3).Put("htilt", ((V)(16D))).Put("hyaw", ((V)(0.1))).Put("lx", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(380D)), NewObj(3).Put("htilt", ((V)((-16D)))).Put("hyaw", ((V)((-0.1)))).Put("lx", ((V)((-0.3)))).V, ((V)("io"))), "wait", ((V)(400D)));
Invoke(t_615, "to", ((V)(260D)), NewObj(3).Put("htilt", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("io")));
Call(snort_39, V.Undef, t_615, ((V)(2D)));
Invoke(t_615, "to", ((V)(300D)), NewObj(4).Put("wide", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_615, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Eyes bulge and his ears perk up, a big puzzled pug head tilt one way, then the other, then two snorts.")))).Put("squish", Arr(Call(Fn((V _self9, int _argc616, V _a618, V _a619, V _a620, V _a621, V[] _rest617) => {
V t_622 = default;
t_622 = Call(TL_17, V.Undef);
Invoke(Invoke(t_622, "to", ((V)(120D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.3))).Put("close", ((V)(0.8))).Put("puff", ((V)(0.6))).Put("mw", ((V)(0.7))).V, ((V)("io")));
Call(snort_39, V.Undef, t_622, ((V)(1D)));
Invoke(t_622, "wait", ((V)(200D)));
Invoke(t_622, "to", ((V)(60D)), NewObj(6).Put("close", ((V)(0D))).Put("puff", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("tongue", ((V)(0.6))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jump_23, V.Undef, t_622, NewObj(5).Put("h", ((V)(8D))).Put("ant", ((V)(40D))).Put("up", ((V)(200D))).Put("c", ((V)(0.3))).Put("arm", ((V)(40D))).V);
Call(swing_26, V.Undef, t_622, ((V)(700D)), ((V)(3D)), NewObj(2).Put("wag", ((V)(36D))).Put("x", ((V)(1D))).V);
Invoke(t_622, "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(0D))).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_31, V.Undef, t_622);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squished, all his wrinkles bunch up and he snorts; let go and he bounces with his tongue out, tail wiggling.")))).Put("quirk", Arr(Call(Fn((V _self9, int _argc623, V _a625, V _a626, V _a627, V _a628, V[] _rest624) => {
V t_629 = default;
t_629 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_629, "to", ((V)(120D)), NewObj(2).Put("lx", ((V)(0.8))).Put("ly", ((V)((-0.3)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(3).Put("earL", ((V)((-12D)))).Put("earR", ((V)((-12D)))).Put("hyaw", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(300D)));
Invoke(Invoke(Invoke(Invoke(t_629, "to", ((V)(320D)), NewObj(1).Put("htilt", ((V)(18D))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(360D)), NewObj(2).Put("htilt", ((V)((-12D)))).Put("hyaw", ((V)(0.25))).V, ((V)("io"))), "wait", ((V)(400D)));
Invoke(t_629, "to", ((V)(200D)), NewObj(6).Put("htilt", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_629, "to", ((V)(120D)), NewObj(4).Put("pitch", ((V)(0.12))).Put("close", ((V)(0.6))).Put("mw", ((V)(0.7))).Put("sq", ((V)((-0.03)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(4).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(1).Put("sq", ((V)(0D))).V);
Call(snort_39, V.Undef, t_629, ((V)(2D)));
Invoke(Invoke(Invoke(t_629, "to", ((V)(160D)), NewObj(3).Put("tongue", ((V)(0.7))).Put("open", ((V)(0.2))).Put("hap", ((V)(1D))).V, ((V)("o"))), "wait", ((V)(600D))), "to", ((V)(200D)), NewObj(3).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_629, "wait", ((V)(200D))), "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Head tilt")), ((V)("Hears something - a puzzled head tilt, then the other way - a big pug snort, and he forgets his tongue sticking out.")))).Put("press", NewObj(4).Put("sq", ((V)(0.14))).Put("puff", ((V)(0.5))).Put("close", ((V)(0.7))).Put("mw", ((V)(0.7))).V).Put("rel", NewObj(2).Put("dur", ((V)(1000D))).Put("k", NewObj(8).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(240D)), ((V)(9D)), ((V)("o"))), Arr(((V)(480D)), ((V)(0D)), ((V)("i"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.14))), Arr(((V)(60D)), ((V)((-0.14))), ((V)("o"))), Arr(((V)(240D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(420D)), ((V)((-0.06))), ((V)("i"))), Arr(((V)(500D)), ((V)(0.14)), ((V)("o"))), Arr(((V)(660D)), ((V)(0D)), ((V)("io"))))).Put("puff", Arr(Arr(((V)(0D)), ((V)(0.5))), Arr(((V)(60D)), ((V)(0D)), ((V)("o"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0.7))), Arr(((V)(60D)), ((V)(0D)), ((V)("o"))))).Put("mw", Arr(Arr(((V)(0D)), ((V)(0.7))), Arr(((V)(80D)), ((V)(1D)), ((V)("o"))))).Put("tongue", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0.7)), ((V)("o"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0.3)), ((V)("o"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(500D)), ((V)(36D)), ((V)("io"))), Arr(((V)(620D)), ((V)((-36D))), ((V)("io"))), Arr(((V)(740D)), ((V)(30D)), ((V)("io"))), Arr(((V)(860D)), ((V)(0D)), ((V)("io"))))).V).V).Put("look", Call(Fn((V _self9, int _argc630, V _a632, V _a633, V _a634, V _a635, V[] _rest631) => {
V t_636 = default;
t_636 = Call(TL_17, V.Undef);
Call(look_24, V.Undef, t_636, ((V)(0D)), ((V)((-0.55))), NewObj(1).Put("k", ((V)(0.8))).V);
Invoke(Invoke(Invoke(t_636, "to", ((V)(260D)), NewObj(1).Put("htilt", ((V)(8D))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(260D)), NewObj(1).Put("htilt", ((V)(0D))).V, ((V)("io")));
Call(look_24, V.Undef, t_636, ((V)((-0.55))), ((V)(0.55)), NewObj(1).Put("k", ((V)(0.8))).V);
Invoke(t_636, "wait", ((V)(500D)));
Call(look_24, V.Undef, t_636, ((V)(0.55)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.8))).V);
return Invoke(Invoke(t_636, "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).Put("zippy", NewObj(7).Put("happy", Arr(Call(Fn((V _self9, int _argc637, V _a639, V _a640, V _a641, V _a642, V[] _rest638) => {
V t_643 = default;
t_643 = Call(TL_17, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Call(dook_40, V.Undef, t_643, ((V)(3D)));
Invoke(t_643, "wait", ((V)(100D)));
Call(dook_40, V.Undef, t_643, ((V)(4D)));
Invoke(Invoke(t_643, "osc", ((V)(800D)), ((V)(4D)), NewObj(2).Put("wag", ((V)(32D))).Put("x", ((V)(0.8))).V, NewObj(2).Put("wag", ((V)((-32D)))).Put("x", ((V)((-0.8)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(3).Put("wag", ((V)(0D))).Put("x", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_31, V.Undef, Invoke(t_643, "rest", ((V)(250D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Happy ferret chuckles - dook dook dook - bouncing on the spot, his long tail swishing.")))).Put("surprised", Arr(Call(Fn((V _self9, int _argc644, V _a646, V _a647, V _a648, V _a649, V[] _rest645) => {
V t_650 = default;
t_650 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_650, "wait", ((V)(100D))), "to", ((V)(70D)), NewObj(5).Put("wide", ((V)(1D))).Put("sq", ((V)((-0.12)))).Put("lift", ((V)(2D))).Put("bend", ((V)((-3D)))).Put("wag", ((V)(20D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)((-0.06)))).V, ((V)("i")));
Call(jump_23, V.Undef, t_650, NewObj(8).Put("h", ((V)(6D))).Put("ant", ((V)(60D))).Put("up", ((V)(150D))).Put("c", ((V)(0.08))).Put("arm", ((V)(40D))).Put("x", ((V)((-3D)))).Put("air", NewObj(1).Put("tilt", ((V)((-8D)))).V).Put("fall", NewObj(1).Put("tilt", ((V)(0D))).V).V);
Call(jump_23, V.Undef, t_650, NewObj(8).Put("h", ((V)(6D))).Put("ant", ((V)(60D))).Put("up", ((V)(150D))).Put("c", ((V)(0.08))).Put("arm", ((V)(40D))).Put("x", ((V)(0D))).Put("air", NewObj(1).Put("tilt", ((V)(8D))).V).Put("fall", NewObj(1).Put("tilt", ((V)(0D))).V).V);
Invoke(t_650, "to", ((V)(260D)), NewObj(4).Put("bend", ((V)(0D))).Put("wag", ((V)(0D))).Put("wide", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(dook_40, V.Undef, t_650, ((V)(2D)));
Invoke(t_650, "to", ((V)(200D)), NewObj(3).Put("open", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_650, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Arches up tall with his tail puffed, a startled sideways hop and back, then a little dook.")))).Put("squish", Arr(Call(Fn((V _self9, int _argc651, V _a653, V _a654, V _a655, V _a656, V[] _rest652) => {
V t_657 = default;
t_657 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_657, "to", ((V)(120D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.32))).Put("close", ((V)(0.9))).Put("hap", ((V)(0.7))).Put("wag", ((V)(18D))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(60D)), NewObj(3).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("o")));
Call(jump_23, V.Undef, t_657, NewObj(7).Put("h", ((V)(12D))).Put("ant", ((V)(40D))).Put("up", ((V)(230D))).Put("c", ((V)(0.32))).Put("arm", ((V)(60D))).Put("st", ((V)(1.3))).Put("spin", ((V)(360D))).V);
Call(dook_40, V.Undef, t_657, ((V)(2D)));
Invoke(t_657, "to", ((V)(200D)), NewObj(4).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).Put("wag", ((V)(0D))).V, ((V)("io")));
return Call(loopN_31, V.Undef, t_657);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squished; let go and he boings up with a spin and a dook.")))).Put("quirk", Arr(Call(Fn((V _self9, int _argc658, V _a660, V _a661, V _a662, V _a663, V[] _rest659) => {
V t_664 = default;
t_664 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_664, "to", ((V)(120D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("hyaw", ((V)((-0.3)))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(120D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("hyaw", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(200D)));
Invoke(Invoke(Invoke(t_664, "to", ((V)(200D)), NewObj(3).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).Put("pitch", ((V)((-0.1)))).V, ((V)("io"))), "to", ((V)(140D)), Call(o_21, V.Undef, Call(both_20, V.Undef, ((V)(12D)), ((V)((-2D)))), NewObj(4).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).Put("x", ((V)(1.5))).Put("sq", ((V)((-0.04)))).V), ((V)("o"))), "to", ((V)(240D)), Call(o_21, V.Undef, Call(both_20, V.Undef, ((V)((-2D))), ((V)(6D))), NewObj(5).Put("armL", ((V)((-20D)))).Put("armR", ((V)((-20D)))).Put("x", ((V)(0D))).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).V), ((V)("io")));
Invoke(Invoke(t_664, "to", ((V)(220D)), NewObj(5).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.5))).Put("ly", ((V)((-0.5)))).Put("pitch", ((V)(0.1))).V, ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("htilt", ((V)(5D))).V, NewObj(1).Put("htilt", ((V)((-5D)))).V, ((V)("io")));
Invoke(t_664, "to", ((V)(300D)), Call(o_21, V.Undef, NOHANDS_22, NewObj(8).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).Put("smile", ((V)(0D))).Put("hap", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).V), ((V)("io")));
return Invoke(Invoke(Invoke(t_664, "wait", ((V)(200D))), "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Sneaky stash")), ((V)("Shifty eyes - anyone looking? - grabs something, hides it behind his back and looks all innocent.")))).Put("press", NewObj(3).Put("sq", ((V)(0.14))).Put("close", ((V)(0.8))).Put("hap", ((V)(0.5))).V).Put("rel", NewObj(2).Put("dur", ((V)(1000D))).Put("k", NewObj(6).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(250D)), ((V)(13D)), ((V)("o"))), Arr(((V)(500D)), ((V)(0D)), ((V)("i"))))).Put("spin", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(500D)), ((V)(360D)), ((V)("io"))), Arr(((V)(501D)), ((V)(0D)), ((V)("l"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.14))), Arr(((V)(60D)), ((V)((-0.18))), ((V)("o"))), Arr(((V)(250D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(430D)), ((V)((-0.08))), ((V)("i"))), Arr(((V)(510D)), ((V)(0.16)), ((V)("o"))), Arr(((V)(680D)), ((V)(0D)), ((V)("io"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0.8))), Arr(((V)(60D)), ((V)(0D)), ((V)("o"))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0.5))), Arr(((V)(60D)), ((V)(1D)), ((V)("o"))), Arr(((V)(900D)), ((V)(0D)), ((V)("io"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(520D)), ((V)(0.4)), ((V)("o"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))).V).V).Put("look", Call(Fn((V _self9, int _argc665, V _a667, V _a668, V _a669, V _a670, V[] _rest666) => {
V t_671 = default;
t_671 = Call(TL_17, V.Undef);
Call(look_24, V.Undef, t_671, ((V)(0D)), ((V)((-0.6))), NewObj(3).Put("k", ((V)(0.85))).Put("d1", ((V)(140D))).Put("d2", ((V)(170D))).V);
Invoke(t_671, "wait", ((V)(400D)));
Call(look_24, V.Undef, t_671, ((V)((-0.6))), ((V)(0.6)), NewObj(3).Put("k", ((V)(0.85))).Put("d1", ((V)(140D))).Put("d2", ((V)(170D))).V);
Invoke(t_671, "wait", ((V)(400D)));
Call(look_24, V.Undef, t_671, ((V)(0.6)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.85))).V);
return Invoke(Invoke(t_671, "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).Put("mango", NewObj(7).Put("happy", Arr(Call(Fn((V _self9, int _argc672, V _a674, V _a675, V _a676, V _a677, V[] _rest673) => {
V t_678 = default;
t_678 = Call(TL_17, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Invoke(t_678, "to", ((V)(500D)), NewObj(2).Put("pitch", ((V)(0.1))).Put("sq", ((V)((-0.03)))).V, ((V)("io")));
Call(slowBlink_47, V.Undef, t_678);
Call(swing_26, V.Undef, t_678, ((V)(1800D)), ((V)(3D)), NewObj(3).Put("wag", ((V)(34D))).Put("tilt", ((V)(2D))).Put("x", ((V)(0.6))).V);
Call(bob_33, V.Undef, t_678, ((V)(2D)), ((V)(500D)), ((V)(0.1)));
return Call(loopN_31, V.Undef, Invoke(t_678, "rest", ((V)(400D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Lifts his chin with a big grin, a slow happy blink, waves his tail slowly and gives two chill nods.")))).Put("surprised", Arr(Call(Fn((V _self9, int _argc679, V _a681, V _a682, V _a683, V _a684, V[] _rest680) => {
V t_685 = default;
t_685 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_685, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(2).Put("wide", ((V)(1D))).Put("sq", ((V)(0.05))).V, ((V)("o"))), "wait", ((V)(300D)));
Invoke(Invoke(t_685, "osc", ((V)(700D)), ((V)(7D)), NewObj(1).Put("wag", ((V)(10D))).V, NewObj(1).Put("wag", ((V)((-6D)))).V, ((V)("l"))), "to", ((V)(100D)), NewObj(1).Put("wag", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_685, "to", ((V)(110D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(350D))), "to", ((V)(110D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(350D))), "to", ((V)(200D)), NewObj(3).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(slowBlink_47, V.Undef, t_685);
return Invoke(Invoke(t_685, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Freezes, the tip of his tail twitches, his eyes slide left and right, then a slow relaxed blink.")))).Put("squish", Arr(Call(Fn((V _self9, int _argc686, V _a688, V _a689, V _a690, V _a691, V[] _rest687) => {
V t_692 = default;
t_692 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_692, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.03)))).V, ((V)("o"))), "to", ((V)(360D)), NewObj(3).Put("sq", ((V)(0.3))).Put("close", ((V)(1D))).Put("hap", ((V)(0.7))).V, ((V)("io"))), "wait", ((V)(380D)));
Invoke(Invoke(t_692, "to", ((V)(220D)), NewObj(5).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(2D))).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(2).Put("sq", ((V)(0.05))).Put("lift", ((V)(0D))).V, ((V)("i")));
Call(jelly_28, V.Undef, t_692, ((V)(0.05)), ((V)(2D)), ((V)(360D)));
Call(slowBlink_47, V.Undef, t_692);
Invoke(t_692, "to", ((V)(260D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return Call(loopN_31, V.Undef, t_692);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squishes flat; let go and he puffs back up with a big grin and a slow blink.")))).Put("quirk", Arr(Call(Fn((V _self9, int _argc693, V _a695, V _a696, V _a697, V _a698, V[] _rest694) => {
V t_699 = default;
t_699 = Call(TL_17, V.Undef);
Call(eyeLick_59, V.Undef, t_699, ((V)(1D)));
Invoke(t_699, "wait", ((V)(200D)));
Call(eyeLick_59, V.Undef, t_699, ((V)((-1D))));
Invoke(Invoke(Invoke(t_699, "to", ((V)(240D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("wag", ((V)(26D))).V, NewObj(1).Put("wag", ((V)((-26D)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(3).Put("wag", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_699, "wait", ((V)(200D))), "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Eye lick")), ((V)("Licks his own eyeball - one, then the other (leopard geckos really do that) - then a grin and a lazy tail wave.")))).Put("press", NewObj(3).Put("sq", ((V)(0.12))).Put("close", ((V)(1D))).Put("hap", ((V)(0.6))).V).Put("rel", NewObj(2).Put("dur", ((V)(1100D))).Put("k", NewObj(5).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.12))), Arr(((V)(200D)), ((V)((-0.08))), ((V)("o"))), Arr(((V)(450D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(2D)), ((V)("o"))), Arr(((V)(450D)), ((V)(0D)), ((V)("i"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(300D)), ((V)(0D)), ((V)("io"))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(300D)), ((V)(1D)), ((V)("io"))), Arr(((V)(1000D)), ((V)(0D)), ((V)("io"))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(400D)), ((V)(30D)), ((V)("io"))), Arr(((V)(700D)), ((V)((-30D))), ((V)("io"))), Arr(((V)(1000D)), ((V)(0D)), ((V)("io"))))).V).V).Put("look", Call(Fn((V _self9, int _argc700, V _a702, V _a703, V _a704, V _a705, V[] _rest701) => {
V t_706 = default;
t_706 = Call(TL_17, V.Undef);
Call(look_24, V.Undef, t_706, ((V)(0D)), ((V)((-0.55))), NewObj(3).Put("k", ((V)(0.75))).Put("d1", ((V)(220D))).Put("d2", ((V)(260D))).V);
Invoke(t_706, "wait", ((V)(800D)));
Call(look_24, V.Undef, t_706, ((V)((-0.55))), ((V)(0.55)), NewObj(3).Put("k", ((V)(0.75))).Put("d1", ((V)(220D))).Put("d2", ((V)(260D))).V);
Call(slowBlink_47, V.Undef, t_706);
Invoke(t_706, "wait", ((V)(300D)));
Call(look_24, V.Undef, t_706, ((V)(0.55)), ((V)(0D)), NewObj(3).Put("k", ((V)(0.75))).Put("d1", ((V)(220D))).Put("d2", ((V)(260D))).V);
return Invoke(Invoke(t_706, "rest", ((V)(400D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).V;
DANCES_63 = NewObj(9).Put("tilly", Arr(Call(Fn((V _self9, int _argc707, V _a709, V _a710, V _a711, V _a712, V[] _rest708) => {
V t_713 = default;
V B_714 = default;
t_713 = Call(TL_17, V.Undef, NewObj(1).Put("smile", ((V)(0.8))).V);
B_714 = ((V)(460D));
Invoke(t_713, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
V i_715 = default;
i_715 = ((V)(0D));
while (true) {
if (!(LtN(i_715, 8D))) break;
Invoke(Invoke(t_713, "to", ((V)((ToNum(B_714) * 0.35))), NewObj(5).Put("pitch", ((V)((-0.16)))).Put("sq", ((V)(0.03))).Put("earL", ((V)((-20D)))).Put("earR", ((V)((-20D)))).Put("x", ((V)(((NumTruthy((ToNum(i_715) % 2D)) ? 1D : (-1D)) * 0.8)))).V, ((V)("o"))), "to", ((V)((ToNum(B_714) * 0.65))), NewObj(4).Put("pitch", ((V)(0.04))).Put("sq", ((V)(0D))).Put("earL", ((V)((-4D)))).Put("earR", ((V)((-4D)))).V, ((V)("io")));
if (SEqN(i_715, 3D)) {
Invoke(t_713, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
}
PostInc(ref i_715, 1D);
}
}
Invoke(t_713, "to", ((V)(200D)), NewObj(2).Put("x", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_713, "to", ((V)(240D)), NewObj(6).Put("armL", ((V)(100D))).Put("armR", ((V)(100D))).Put("sq", ((V)((-0.04)))).Put("lift", ((V)(1D))).Put("earL", ((V)((-24D)))).Put("earR", ((V)((-24D)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(4).Put("armL", ((V)(92D))).Put("armR", ((V)(92D))).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
Call(swing_26, V.Undef, t_713, ((V)(1600D)), ((V)(3D)), NewObj(3).Put("tilt", ((V)(5D))).Put("x", ((V)(1.5))).Put("htilt", ((V)((-4D)))).V);
Call(chirp_36, V.Undef, t_713);
Call(chirp_36, V.Undef, t_713, ((V)(0.7)));
Invoke(t_713, "to", ((V)(220D)), NewObj(4).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).V, ((V)("io")));
Call(stepTo_43, V.Undef, t_713, Arr(((V)(2D)), ((V)(4D)), ((V)(2D)), ((V)(0D)), ((V)((-2D))), ((V)((-4D))), ((V)((-2D))), ((V)(0D))), ((V)(300D)), ((V)(2.5)));
Invoke(t_713, "to", ((V)(150D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(jump_23, V.Undef, t_713, NewObj(7).Put("h", ((V)(11D))).Put("ant", ((V)(160D))).Put("up", ((V)(290D))).Put("c", ((V)(0.18))).Put("arm", ((V)(120D))).Put("spin", ((V)(360D))).Put("ev", Arr(Arr(((V)("emit")), ((V)("featherY")), ((V)("body")), ((V)(3D))))).V);
Invoke(Invoke(t_713, "osc", ((V)(1000D)), ((V)(6D)), NewObj(2).Put("earL", ((V)((-26D)))).Put("earR", ((V)(6D))).V, NewObj(2).Put("earL", ((V)(6D))).Put("earR", ((V)((-26D)))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Call(chirp_36, V.Undef, t_713);
return Invoke(Invoke(t_713, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Crest Shake Boogie")), ((V)("Bobs her head to the beat with her crest flicking up, opens her wings in a heart and sways, side-steps right and left, a flutter hop with a spin, and shakes her crest from side to side.")))).Put("pico", Arr(Call(Fn((V _self9, int _argc717, V _a719, V _a720, V _a721, V _a722, V[] _rest718) => {
V t_723 = default;
V B_724 = default;
t_723 = Call(TL_17, V.Undef, NewObj(2).Put("smile", ((V)(0.8))).Put("hap", ((V)(0.4))).V);
B_724 = ((V)(360D));
Invoke(t_723, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
V i_725 = default;
i_725 = ((V)(0D));
while (true) {
if (!(LtN(i_725, 8D))) break;
Invoke(Invoke(t_723, "to", ((V)((ToNum(B_724) * 0.35))), NewObj(3).Put("pitch", ((V)((-0.18)))).Put("sq", ((V)(0.04))).Put("tilt", ((V)((NumTruthy((ToNum(i_725) % 2D)) ? 3D : (-3D))))).V, ((V)("o"))), "to", ((V)((ToNum(B_724) * 0.65))), NewObj(2).Put("pitch", ((V)(0.05))).Put("sq", ((V)(0D))).V, ((V)("io")));
PostInc(ref i_725, 1D);
}
}
Invoke(t_723, "to", ((V)(150D)), NewObj(2).Put("tilt", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
{
V i_727 = default;
i_727 = ((V)(0D));
while (true) {
if (!(LtN(i_727, 4D))) break;
V k_729 = default;
V j_730 = default;
k_729 = ((V)((NumTruthy((ToNum(i_727) % 2D)) ? "armL" : "armR")));
j_730 = ((V)((NumTruthy((ToNum(i_727) % 2D)) ? "armR" : "armL")));
Invoke(Invoke(t_723, "to", ((V)(140D)), NewObj(3).PutK(k_729, ((V)(110D))).PutK(j_730, ((V)(10D))).Put("htilt", ((V)((NumTruthy((ToNum(i_727) % 2D)) ? (-6D) : 6D)))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(1).PutK(k_729, ((V)(30D))).V, ((V)("io")));
if (NumTruthy((ToNum(i_727) % 2D))) {
Invoke(t_723, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
}
PostInc(ref i_727, 1D);
}
}
Invoke(t_723, "to", ((V)(150D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io")));
Call(jump_23, V.Undef, t_723, NewObj(8).Put("h", ((V)(6D))).Put("ant", ((V)(110D))).Put("up", ((V)(160D))).Put("c", ((V)(0.12))).Put("arm", ((V)(80D))).Put("x", ((V)(3D))).Put("air", NewObj(1).Put("tilt", ((V)(5D))).V).Put("fall", NewObj(1).Put("tilt", ((V)(0D))).V).V);
Call(jump_23, V.Undef, t_723, NewObj(8).Put("h", ((V)(6D))).Put("ant", ((V)(110D))).Put("up", ((V)(160D))).Put("c", ((V)(0.12))).Put("arm", ((V)(80D))).Put("x", ((V)((-3D)))).Put("air", NewObj(1).Put("tilt", ((V)((-5D)))).V).Put("fall", NewObj(1).Put("tilt", ((V)(0D))).V).V);
Call(jump_23, V.Undef, t_723, NewObj(6).Put("h", ((V)(5D))).Put("ant", ((V)(110D))).Put("up", ((V)(150D))).Put("c", ((V)(0.1))).Put("arm", ((V)(60D))).Put("x", ((V)(0D))).V);
Call(flutter_42, V.Undef, t_723, ((V)(12D)), ((V)(900D)), ((V)(6D)), NewObj(1).Put("spin", ((V)(360D))).V);
Invoke(Invoke(t_723, "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "e", ((V)("emit")), ((V)("featherG")), ((V)("body")), ((V)(3D)));
Invoke(Invoke(t_723, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "osc", ((V)(900D)), ((V)(6D)), NewObj(3).Put("open", ((V)(0.45))).Put("mw", ((V)(0.6))).Put("pitch", ((V)(0.06))).V, NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("o")));
Call(bob_33, V.Undef, t_723, ((V)(3D)), ((V)(220D)), ((V)(0.18)));
return Invoke(Invoke(t_723, "rest", ((V)(250D))), "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Birdie Bop")), ((V)("Bops his head super fast to the beat, flaps one wing then the other, hops right, left and home, flutters up with a spin, then chatters and bobs.")))).Put("clover", Arr(Call(Fn((V _self9, int _argc731, V _a733, V _a734, V _a735, V _a736, V[] _rest732) => {
V t_737 = default;
t_737 = Call(TL_17, V.Undef, NewObj(1).Put("smile", ((V)(0.8))).V);
Invoke(t_737, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
V i_738 = default;
i_738 = ((V)(0D));
while (true) {
if (!(LtN(i_738, 4D))) break;
Call(jump_23, V.Undef, t_737, NewObj(8).Put("h", ((V)(5D))).Put("ant", ((V)(110D))).Put("up", ((V)(150D))).Put("c", ((V)(0.12))).Put("arm", ((V)(15D))).Put("x", GetK(Arr(((V)(2D)), ((V)(0D)), ((V)((-2D))), ((V)(0D))), i_738)).Put("air", NewObj(2).Put("earL", ((V)(20D))).Put("earR", ((V)(20D))).V).Put("fall", NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V).V);
PostInc(ref i_738, 1D);
}
}
Call(binky_45, V.Undef, t_737, ((V)(1D)), ((V)(13D)));
Call(binky_45, V.Undef, t_737, ((V)((-1D))), ((V)(14D)));
Invoke(t_737, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
Call(twitch_41, V.Undef, t_737, ((V)(3D)));
Invoke(Invoke(Invoke(t_737, "to", ((V)(320D)), NewObj(8).Put("tilt", ((V)(26D))).Put("sq", ((V)(0.22))).Put("lift", ((V)((-1D)))).Put("close", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("earL", ((V)((-10D)))).Put("earR", ((V)(26D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(900D)));
Invoke(Invoke(t_737, "to", ((V)(200D)), NewObj(4).Put("tilt", ((V)(8D))).Put("sq", ((V)(0.06))).Put("lift", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(5).Put("tilt", ((V)(0D))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
Call(headShake_60, V.Undef, t_737, ((V)(0.8)));
Call(jump_23, V.Undef, t_737, NewObj(8).Put("h", ((V)(15D))).Put("ant", ((V)(170D))).Put("up", ((V)(270D))).Put("c", ((V)(0.2))).Put("arm", ((V)(30D))).Put("spin", ((V)(360D))).Put("air", NewObj(2).Put("earL", ((V)(30D))).Put("earR", ((V)(30D))).V).Put("fall", NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V).V);
return Invoke(Invoke(t_737, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Bunny Hop")), ((V)("Little bunny hops forward and back, two twisting binkies, a nose twitch, the happy bunny flop onto her side, back up with an ear shake, and a big spinning binky.")))).Put("chilla", Arr(Call(Fn((V _self9, int _argc740, V _a742, V _a743, V _a744, V _a745, V[] _rest741) => {
V t_746 = default;
t_746 = Call(TL_17, V.Undef, NewObj(4).Put("dbb", ((V)(1D))).Put("lift", ((V)((-2.5)))).Put("sq", ((V)(0.1))).Put("smile", ((V)(0.8))).V);
Call(flopIn_53, V.Undef, t_746);
Call(rolls_54, V.Undef, t_746, ((V)(Round((10000D / 170D)))), ((V)(170D)), ((V)(1D)));
Call(rollUp_55, V.Undef, Invoke(t_746, "wait", ((V)(260D))));
Call(dustOff_57, V.Undef, t_746, ((V)(520D)));
Call(shake_25, V.Undef, t_746, NewObj(8).Put("P", ((V)(85D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.85)), ((V)(0.5)), ((V)(0.25)))).Put("head", ((V)(0.3))).Put("roll", ((V)(5D))).Put("ear", ((V)(12D))).Put("chest", ((V)(0.1))).Put("body", ((V)(0.6))).Put("tail", ((V)(30D))).V);
Invoke(Invoke(Invoke(t_746, "e", ((V)("emit")), ((V)("poof")), ((V)("head")), ((V)(2D))), "e", ((V)("emit")), ((V)("poof")), ((V)("sideL")), ((V)(1D))), "e", ((V)("emit")), ((V)("poof")), ((V)("sideR")), ((V)(1D)));
Call(jump_23, V.Undef, t_746, NewObj(6).Put("h", ((V)(7D))).Put("ant", ((V)(130D))).Put("up", ((V)(200D))).Put("c", ((V)(0.12))).Put("arm", ((V)(45D))).Put("ev", Arr(Arr(((V)("emit")), ((V)("dustbath")), Arr(((V)(36D)), ((V)(83D))), ((V)(2D))), Arr(((V)("emit")), ((V)("dustbath")), Arr(((V)(64D)), ((V)(83D))), ((V)(2D))), Arr(((V)("emit")), ((V)("note")), ((V)("head")), ((V)(1D))))).V);
Invoke(t_746, "to", ((V)(220D)), NewObj(2).Put("lift", ((V)((-2.5)))).Put("sq", ((V)(0.1))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_746, "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(350D))), "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(0D))).Put("open", ((V)(0D))).Put("smile", ((V)(0.8))).V, ((V)("io")));
return Invoke(Invoke(t_746, "rest", ((V)(200D))), "loop", NewObj(2).Put("stretch", ((V)(0.3))).Put("soft", ((V)(0.45))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Dust Bath Roll")), ((V)("A big wooden tub of dust stays out the whole dance: she flops right over onto her side in it and rolls - over onto her back with her feet in the air and back over onto her other side, left and right really fast, non stop for 10 seconds, a cloud of dust rising over the tub; then she rolls back up, shakes the dust off, does a happy hop and flops straight back down to go again - over and over until you stop her.")))).Put("mimi", Arr(Call(Fn((V _self9, int _argc747, V _a749, V _a750, V _a751, V _a752, V[] _rest748) => {
V t_753 = default;
V H_754 = default;
t_753 = Call(TL_17, V.Undef, NewObj(1).Put("smile", ((V)(0.8))).V);
H_754 = Call(both_20, V.Undef, ((V)(4D)), ((V)((-10D))));
Invoke(Invoke(t_753, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(220D)), Call(o_21, V.Undef, H_754, NewObj(2).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V), ((V)("io")));
Call(stepTo_43, V.Undef, t_753, Arr(((V)(1.5)), ((V)(3D)), ((V)(1.5)), ((V)(0D)), ((V)((-1.5))), ((V)((-3D))), ((V)((-1.5))), ((V)(0D))), ((V)(240D)), ((V)(2D)), NewObj(1).Put("wag", ((V)(0D))).V);
Invoke(Invoke(t_753, "osc", ((V)(700D)), ((V)(4D)), NewObj(2).Put("wag", ((V)(30D))).Put("x", ((V)(0.6))).V, NewObj(2).Put("wag", ((V)((-30D)))).Put("x", ((V)((-0.6)))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(2).Put("wag", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
Call(squeak_38, V.Undef, t_753);
Invoke(t_753, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
Invoke(Invoke(t_753, "to", ((V)(900D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Call(para_32, V.Undef, t_753, ((V)((ToNum(Get(t_753, "t")) - 900D))), Fn((V _self9, int _argc755, V u_761, V _a758, V _a759, V _a760, V[] _rest756) => {
return Call(steps_27, V.Undef, u_761, ((V)(900D)), ((V)(4D)), ((V)(2D)));
}, 1, "", true));
Invoke(t_753, "to", ((V)(220D)), Call(o_21, V.Undef, NOHANDS_22, NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(1.2))).V), ((V)("o")));
{
V i_762 = default;
i_762 = ((V)(0D));
while (true) {
if (!(LtN(i_762, 3D))) break;
Invoke(Invoke(t_753, "to", ((V)(90D)), Call(both_20, V.Undef, ((V)(2D)), ((V)((-6D)))), ((V)("o"))), "to", ((V)(110D)), Call(both_20, V.Undef, ((V)(6D)), ((V)((-4D)))), ((V)("io")));
PostInc(ref i_762, 1D);
}
}
Invoke(t_753, "to", ((V)(220D)), Call(o_21, V.Undef, H_754, NewObj(2).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V), ((V)("io")));
Call(squeak_38, V.Undef, t_753);
return Invoke(Invoke(t_753, "rest", ((V)(250D))), "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Cheese Shuffle")), ((V)("Paws together, a tiny shuffle to the right and to the left, a tail swish and a squeak, a twirl on the spot, then up on her tiptoes clapping.")))).Put("puddles", Arr(Call(Fn((V _self9, int _argc764, V _a766, V _a767, V _a768, V _a769, V[] _rest765) => {
V t_770 = default;
t_770 = Call(TL_17, V.Undef, NewObj(1).Put("smile", ((V)(0.8))).V);
Invoke(t_770, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
Call(waddle_44, V.Undef, t_770, Arr(((V)(1.5)), ((V)(3D)), ((V)(4.5)), ((V)(3D)), ((V)(1.5)), ((V)(0D)), ((V)((-1.5))), ((V)((-3D))), ((V)((-4.5))), ((V)((-3D))), ((V)((-1.5))), ((V)(0D))), ((V)(280D)));
Call(flap_35, V.Undef, t_770, ((V)(3D)), ((V)(260D)), ((V)(105D)));
Invoke(t_770, "to", ((V)(150D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(quack_37, V.Undef, t_770);
Call(jump_23, V.Undef, t_770, NewObj(7).Put("h", ((V)(11D))).Put("ant", ((V)(170D))).Put("up", ((V)(250D))).Put("c", ((V)(0.2))).Put("arm", ((V)(110D))).Put("land", NewObj(1).Put("sq", ((V)(0.3))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("splash")), ((V)("body")), ((V)(2D))), Arr(((V)("emit")), ((V)("splash")), ((V)("body")), ((V)(2D))))).V);
Invoke(Invoke(Invoke(t_770, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(900D)), ((V)(7D)), NewObj(3).Put("wag", ((V)(34D))).Put("x", ((V)(0.8))).Put("tilt", ((V)(3D))).V, NewObj(3).Put("wag", ((V)((-34D)))).Put("x", ((V)((-0.8)))).Put("tilt", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(3).Put("wag", ((V)(0D))).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_770, "to", ((V)(900D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Call(para_32, V.Undef, t_770, ((V)((ToNum(Get(t_770, "t")) - 900D))), Fn((V _self9, int _argc771, V u_777, V _a774, V _a775, V _a776, V[] _rest772) => {
return Call(steps_27, V.Undef, u_777, ((V)(900D)), ((V)(4D)), ((V)(2D)));
}, 1, "", true));
Call(quack_37, V.Undef, t_770);
Call(quack_37, V.Undef, t_770);
Invoke(t_770, "to", ((V)(150D)), NewObj(1).Put("hap", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_770, "rest", ((V)(250D))), "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Puddle Splash")), ((V)("Waddles right and left, flaps her wings and quacks, jumps into a puddle with a big splash, wiggles her tail feathers, a spin and two quacks.")))).Put("bean", Arr(Call(Fn((V _self9, int _argc778, V _a780, V _a781, V _a782, V _a783, V[] _rest779) => {
V t_784 = default;
t_784 = Call(TL_17, V.Undef, NewObj(3).Put("smile", ((V)(0.8))).Put("tongue", ((V)(0.5))).Put("open", ((V)(0.2))).V);
Invoke(t_784, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
Call(swing_26, V.Undef, t_784, ((V)(1600D)), ((V)(7D)), NewObj(4).Put("x", ((V)(1.6))).Put("tilt", ((V)(5D))).Put("wag", ((V)(42D))).Put("bend", ((V)(2D))).V);
Call(snort_39, V.Undef, t_784, ((V)(2D)));
Invoke(Invoke(Invoke(t_784, "to", ((V)(260D)), NewObj(6).Put("pitch", ((V)((-0.25)))).Put("sq", ((V)(0.12))).Put("lift", ((V)((-0.6)))).Put("armL", ((V)((-20D)))).Put("armR", ((V)((-20D)))).Put("wag", ((V)(30D))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(4D)), NewObj(1).Put("wag", ((V)((-40D)))).V, NewObj(1).Put("wag", ((V)(40D))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(6).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("wag", ((V)(0D))).V, ((V)("io")));
{
V i_785 = default;
i_785 = ((V)(0D));
while (true) {
if (!(LtN(i_785, 2D))) break;
Invoke(t_784, "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(2D)));
Invoke(Invoke(t_784, "to", ((V)(700D)), NewObj(2).Put("spin", ((V)(360D))).Put("tilt", ((V)(6D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Call(para_32, V.Undef, t_784, ((V)((ToNum(Get(t_784, "t")) - 700D))), Fn((V _self9, int _argc787, V u_793, V _a790, V _a791, V _a792, V[] _rest788) => {
return Call(steps_27, V.Undef, u_793, ((V)(700D)), ((V)(4D)), ((V)(2.5)));
}, 1, "", true));
PostInc(ref i_785, 1D);
}
}
Invoke(t_784, "to", ((V)(150D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io")));
Call(snort_39, V.Undef, t_784, ((V)(2D)));
Call(jump_23, V.Undef, t_784, NewObj(5).Put("h", ((V)(7D))).Put("ant", ((V)(150D))).Put("up", ((V)(190D))).Put("c", ((V)(0.16))).Put("arm", ((V)(40D))).V);
Invoke(t_784, "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
return Invoke(Invoke(t_784, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Pug Wiggle")), ((V)("A big butt wiggle with his curly tail going, two snorts, a play bow, two rounds of zoomies spinning on the spot, more snorts and a happy hop - tongue out the whole time.")))).Put("zippy", Arr(Call(Fn((V _self9, int _argc794, V _a796, V _a797, V _a798, V _a799, V[] _rest795) => {
V t_800 = default;
t_800 = Call(TL_17, V.Undef, NewObj(3).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.6))).Put("open", ((V)(0.25))).V);
Invoke(t_800, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
V i_801 = default;
i_801 = ((V)(0D));
while (true) {
if (!(LtN(i_801, 6D))) break;
V d_803 = default;
d_803 = ((V)((NumTruthy((ToNum(i_801) % 2D)) ? (-1D) : 1D)));
Call(jump_23, V.Undef, t_800, NewObj(8).Put("h", ((V)(7D))).Put("ant", ((V)(70D))).Put("up", ((V)(150D))).Put("c", ((V)(0.1))).Put("arm", ((V)(50D))).Put("x", GetK(Arr(((V)(4D)), ((V)((-4D))), ((V)(5D)), ((V)((-5D))), ((V)(2D)), ((V)(0D))), i_801)).Put("air", NewObj(3).Put("tilt", ((V)((ToNum(d_803) * 12D)))).Put("bend", ((V)((-3D)))).Put("wag", ((V)((ToNum(d_803) * 30D)))).V).Put("fall", NewObj(3).Put("tilt", ((V)(0D))).Put("bend", ((V)(0D))).Put("wag", ((V)(0D))).V).V);
PostInc(ref i_801, 1D);
}
}
Call(dook_40, V.Undef, t_800, ((V)(3D)));
Invoke(Invoke(t_800, "to", ((V)(200D)), NewObj(3).Put("sq", ((V)((-0.12)))).Put("lift", ((V)(1D))).Put("bend", ((V)((-4D)))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(3).Put("sq", ((V)(0.08))).Put("lift", ((V)(0D))).Put("bend", ((V)(0D))).V, ((V)("i")));
Call(jump_23, V.Undef, t_800, NewObj(9).Put("h", ((V)(9D))).Put("ant", ((V)(70D))).Put("up", ((V)(170D))).Put("c", ((V)(0.12))).Put("arm", ((V)(50D))).Put("x", ((V)(6D))).Put("air", NewObj(1).Put("tilt", ((V)(18D))).V).Put("fall", NewObj(1).Put("tilt", ((V)(26D))).V).Put("land", NewObj(1).Put("sq", ((V)(0.2))).V).V);
Invoke(Invoke(Invoke(t_800, "to", ((V)(120D)), NewObj(4).Put("x", ((V)(6D))).Put("tilt", ((V)(30D))).Put("close", ((V)(1D))).Put("cross", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(500D))), "to", ((V)(260D)), NewObj(2).Put("tilt", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
Call(headShake_60, V.Undef, t_800, ((V)(0.8)));
Invoke(t_800, "to", ((V)(500D)), NewObj(1).Put("x", ((V)(0D))).V, ((V)("io")));
Call(para_32, V.Undef, t_800, ((V)((ToNum(Get(t_800, "t")) - 500D))), Fn((V _self9, int _argc804, V u_810, V _a807, V _a808, V _a809, V[] _rest805) => {
return Call(steps_27, V.Undef, u_810, ((V)(500D)), ((V)(2D)), ((V)(2.5)));
}, 1, "", true));
Call(jump_23, V.Undef, t_800, NewObj(6).Put("h", ((V)(12D))).Put("ant", ((V)(120D))).Put("up", ((V)(230D))).Put("c", ((V)(0.18))).Put("arm", ((V)(60D))).Put("spin", ((V)(360D))).V);
Call(dook_40, V.Undef, t_800, ((V)(3D)));
Invoke(t_800, "to", ((V)(150D)), NewObj(1).Put("open", ((V)(0.25))).V, ((V)("io")));
return Invoke(Invoke(t_800, "rest", ((V)(250D))), "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Weasel War Dance")), ((V)("Frantic sideways war-dance hops with his back arched and mouth open, dook dook dook, bonks into an invisible wall and flops over, gets up, shakes it off, then a spinning hop and more dooks.")))).Put("mango", Arr(Call(Fn((V _self9, int _argc811, V _a813, V _a814, V _a815, V _a816, V[] _rest812) => {
V t_817 = default;
V B_818 = default;
t_817 = Call(TL_17, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.4))).V);
B_818 = ((V)(600D));
Invoke(t_817, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
V i_819 = default;
i_819 = ((V)(0D));
while (true) {
if (!(LtN(i_819, 4D))) break;
V f_821 = default;
f_821 = ((V)((NumTruthy((ToNum(i_819) % 2D)) ? "footL" : "footR")));
Invoke(Invoke(t_817, "to", ((V)((ToNum(B_818) * 0.35))), NewObj(3).PutK(f_821, ((V)(2.6))).Put("tilt", ((V)((NumTruthy((ToNum(i_819) % 2D)) ? (-3D) : 3D)))).Put("wag", ((V)((NumTruthy((ToNum(i_819) % 2D)) ? (-24D) : 24D)))).V, ((V)("o"))), "to", ((V)((ToNum(B_818) * 0.65))), NewObj(2).PutK(f_821, ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("i")));
PostInc(ref i_819, 1D);
}
}
Call(swing_26, V.Undef, t_817, ((V)(2000D)), ((V)(3D)), NewObj(4).Put("x", ((V)(1.5))).Put("tilt", ((V)(4D))).Put("wag", ((V)(34D))).Put("htilt", ((V)((-3D)))).V);
Call(bob_33, V.Undef, t_817, ((V)(2D)), ((V)(500D)), ((V)(0.1)));
Invoke(Invoke(Invoke(t_817, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "osc", ((V)(800D)), ((V)(10D)), NewObj(1).Put("wag", ((V)(12D))).V, NewObj(1).Put("wag", ((V)((-12D)))).V, ((V)("l"))), "to", ((V)(150D)), NewObj(1).Put("wag", ((V)(0D))).V, ((V)("io")));
Call(eyeLick_59, V.Undef, t_817, ((V)(1D)));
Invoke(Invoke(Invoke(t_817, "to", ((V)(220D)), NewObj(3).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(1.5))).Put("pitch", ((V)(0.12))).V, ((V)("o"))), "wait", ((V)(300D))), "to", ((V)(260D)), NewObj(3).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_817, "to", ((V)(1400D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Call(para_32, V.Undef, t_817, ((V)((ToNum(Get(t_817, "t")) - 1400D))), Fn((V _self9, int _argc822, V u_828, V _a825, V _a826, V _a827, V[] _rest823) => {
return Call(steps_27, V.Undef, u_828, ((V)(1400D)), ((V)(4D)), ((V)(2D)));
}, 1, "", true));
Call(slowBlink_47, V.Undef, t_817);
return Invoke(Invoke(t_817, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Sticky Toe Tap")), ((V)("Taps his sticky toes left and right, sways slowly with his tail swishing, two chill nods, rattles his tail, licks his eye, stands up proud and does a slow turn on the spot.")))).V;
Invoke(KEYS_8, "forEach", Fn((V _self9, int _argc829, V k_835, V _a832, V _a833, V _a834, V[] _rest830) => {
Set(GetK(MOVES_62, k_835), "dance", GetK(DANCES_63, k_835));
return default;
}, 1, "", true));
Call(install_30, V.Undef, MOVES_62, CARDS_61);
return default;
}, 0, "boot", false)), V.Undef);
Call(Named(boot_887 => Fn((V _self836, int _argc837, V _a839, V _a840, V _a841, V _a842, V[] _rest838) => {
V R_843 = default;
V S_844 = default;
V o_845 = default;
V jump_846 = default;
V shake_847 = default;
V jelly_848 = default;
V popcorn_849 = default;
V both_850 = default;
V hand_851 = default;
V NOHANDS_852 = default;
V see_853 = default;
V unsee_854 = default;
V giggle_855 = default;
V hmph_856 = default;
V sneeze_857 = default;
V sniff_858 = default;
V lick_859 = default;
V para_860 = default;
V leanIn_861 = default;
V swat_862 = default;
V pawShake_863 = default;
V headShake_864 = default;
V snort_865 = default;
V freeze_866 = default;
V curl_867 = default;
V blushy_868 = default;
V happy_869 = default;
V pat_870 = default;
V smooth_871 = default;
V rub_872 = default;
V build_873 = default;
V chirp_874 = default;
V quack_875 = default;
V squeak_876 = default;
V dook_877 = default;
V twitch_878 = default;
V peck_879 = default;
V crest_880 = default;
V flap_881 = default;
V wagT_882 = default;
V eyeLick_883 = default;
V BODY_884 = default;
V RE_885 = default;
V TXT_886 = default;
if (_self836.IsNullish) _self836 = GlobalV;
R_843 = Get(G("window"), "RiveRig");
if ((((!(Truthy(R_843)) || !(Truthy(Get(R_843, "POKELIB")))) || !(Truthy(Get(R_843, "pet2V")))) || !(Truthy(Get(Get(R_843, "STATES"), "poke_head"))))) {
Call(G("setTimeout"), V.Undef, boot_887.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_843, "pet2PokeV"))) {
return default;
}
Set(R_843, "pet2PokeV", ((V)(1D)));
{ V _t888 = Get(R_843, "PETLIB");
if (_t888.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t888));
{ V _t889 = Get(_t888, "S");
S_844 = _t889; }
{ V _t890 = Get(_t888, "o");
o_845 = _t890; }
{ V _t891 = Get(_t888, "jump");
jump_846 = _t891; }
{ V _t892 = Get(_t888, "shake");
shake_847 = _t892; }
{ V _t893 = Get(_t888, "jelly");
jelly_848 = _t893; }
{ V _t894 = Get(_t888, "popcorn");
popcorn_849 = _t894; }
{ V _t895 = Get(_t888, "both");
both_850 = _t895; }
{ V _t896 = Get(_t888, "hand");
hand_851 = _t896; }
{ V _t897 = Get(_t888, "NOHANDS");
NOHANDS_852 = _t897; } }
{ V _t898 = Get(R_843, "POKELIB");
if (_t898.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t898));
{ V _t899 = Get(_t898, "see");
see_853 = _t899; }
{ V _t900 = Get(_t898, "unsee");
unsee_854 = _t900; }
{ V _t901 = Get(_t898, "giggle");
giggle_855 = _t901; }
{ V _t902 = Get(_t898, "hmph");
hmph_856 = _t902; }
{ V _t903 = Get(_t898, "sneeze");
sneeze_857 = _t903; }
{ V _t904 = Get(_t898, "sniff");
sniff_858 = _t904; }
{ V _t905 = Get(_t898, "lick");
lick_859 = _t905; }
{ V _t906 = Get(_t898, "para");
para_860 = _t906; }
{ V _t907 = Get(_t898, "leanIn");
leanIn_861 = _t907; }
{ V _t908 = Get(_t898, "swat");
swat_862 = _t908; }
{ V _t909 = Get(_t898, "pawShake");
pawShake_863 = _t909; }
{ V _t910 = Get(_t898, "headShake");
headShake_864 = _t910; }
{ V _t911 = Get(_t898, "snort");
snort_865 = _t911; }
{ V _t912 = Get(_t898, "freeze");
freeze_866 = _t912; }
{ V _t913 = Get(_t898, "curl");
curl_867 = _t913; }
{ V _t914 = Get(_t898, "blushy");
blushy_868 = _t914; }
{ V _t915 = Get(_t898, "happy");
happy_869 = _t915; }
{ V _t916 = Get(_t898, "pat");
pat_870 = _t916; }
{ V _t917 = Get(_t898, "smooth");
smooth_871 = _t917; }
{ V _t918 = Get(_t898, "rub");
rub_872 = _t918; }
{ V _t919 = Get(_t898, "build");
build_873 = _t919; } }
chirp_874 = Fn((V _self836, int _argc920, V t_926, V a_927, V _a924, V _a925, V[] _rest921) => {
return Invoke(Invoke(Invoke(t_926, "to", ((V)(90D)), NewObj(3).Put("open", ((V)((0.5 * ToNum((a_927 is var _t928 && Truthy(_t928) ? _t928 : ((V)(1D)))))))).Put("mw", ((V)(0.6))).Put("pitch", ((V)(0.08))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(140D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 2, "", true);
quack_875 = Fn((V _self836, int _argc929, V t_935, V _a932, V _a933, V _a934, V[] _rest930) => {
return Invoke(Invoke(Invoke(t_935, "to", ((V)(90D)), NewObj(3).Put("open", ((V)(0.65))).Put("mw", ((V)(1.1))).Put("pitch", ((V)(0.12))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(170D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
squeak_876 = Fn((V _self836, int _argc936, V t_942, V _a939, V _a940, V _a941, V[] _rest937) => {
return Invoke(Invoke(Invoke(t_942, "to", ((V)(70D)), NewObj(3).Put("open", ((V)(0.4))).Put("mw", ((V)(0.55))).Put("pitch", ((V)(0.1))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(140D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
dook_877 = Fn((V _self836, int _argc943, V t_949, V n_950, V _a947, V _a948, V[] _rest944) => {
Invoke(t_949, "to", ((V)(120D)), NewObj(3).Put("open", ((V)(0.35))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("o")));
{
V i_951 = default;
i_951 = ((V)(0D));
while (true) {
if (!(Lt(i_951, (n_950 is var _t953 && Truthy(_t953) ? _t953 : ((V)(3D)))))) break;
Invoke(Invoke(t_949, "to", ((V)(80D)), NewObj(2).Put("lift", ((V)(1.6))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(90D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("i")));
PostInc(ref i_951, 1D);
}
}
Invoke(t_949, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
return Invoke(t_949, "to", ((V)(160D)), NewObj(4).Put("sq", ((V)(0D))).Put("open", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "", true);
twitch_878 = Fn((V _self836, int _argc954, V t_960, V n_961, V _a958, V _a959, V[] _rest955) => {
return Invoke(t_960, "osc", ((V)((ToNum((n_961 is var _t962 && Truthy(_t962) ? _t962 : ((V)(3D)))) * 150D))), (n_961 is var _t963 && Truthy(_t963) ? _t963 : ((V)(3D))), NewObj(2).Put("mw", ((V)(0.7))).Put("pitch", ((V)(0.04))).V, NewObj(2).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("o")));
}, 2, "", true);
peck_879 = Fn((V _self836, int _argc964, V t_970, V n_971, V _a968, V _a969, V[] _rest965) => {
{
V i_972 = default;
i_972 = ((V)(0D));
while (true) {
if (!(Lt(i_972, (n_971 is var _t974 && Truthy(_t974) ? _t974 : ((V)(2D)))))) break;
Invoke(Invoke(t_970, "to", ((V)(90D)), NewObj(3).Put("pitch", ((V)((-0.2)))).Put("sq", ((V)(0.04))).Put("open", ((V)(0.2))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(3).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
PostInc(ref i_972, 1D);
}
}
return t_970;
return default;
}, 2, "", true);
crest_880 = Fn((V _self836, int _argc975, V t_981, V v_982, V d_983, V _a980, V[] _rest976) => {
return Invoke(t_981, "to", (d_983 is var _t984 && Truthy(_t984) ? _t984 : ((V)(140D))), NewObj(2).Put("earL", v_982).Put("earR", v_982).V, ((V)("o")));
}, 3, "", true);
flap_881 = Fn((V _self836, int _argc985, V t_991, V n_992, V A_993, V _a990, V[] _rest986) => {
{
V i_994 = default;
i_994 = ((V)(0D));
while (true) {
if (!(Lt(i_994, n_992))) break;
Invoke(Invoke(t_991, "to", ((V)(110D)), NewObj(2).Put("armL", A_993).Put("armR", A_993).V, ((V)("o"))), "to", ((V)(140D)), NewObj(2).Put("armL", ((V)((ToNum(A_993) * 0.25)))).Put("armR", ((V)((ToNum(A_993) * 0.25)))).V, ((V)("io")));
PostInc(ref i_994, 1D);
}
}
return Invoke(t_991, "to", ((V)(150D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return default;
}, 3, "", true);
wagT_882 = Fn((V _self836, int _argc996, V t_1002, V n_1003, V a_1004, V per_1005, V[] _rest997) => {
return Invoke(Invoke(t_1002, "osc", ((V)((ToNum((per_1005 is var _t1006 && Truthy(_t1006) ? _t1006 : ((V)(160D)))) * ToNum(n_1003)))), n_1003, NewObj(1).Put("wag", (a_1004 is var _t1007 && Truthy(_t1007) ? _t1007 : ((V)(30D)))).V, NewObj(1).Put("wag", ((V)((-ToNum((a_1004 is var _t1008 && Truthy(_t1008) ? _t1008 : ((V)(30D)))))))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(1).Put("wag", ((V)(0D))).V, ((V)("io")));
}, 4, "", true);
eyeLick_883 = Fn((V _self836, int _argc1009, V t_1015, V s_1016, V _a1013, V _a1014, V[] _rest1010) => {
V k_1017 = default;
k_1017 = Call(S_844, V.Undef, s_1016);
return Invoke(Invoke(Invoke(t_1015, "to", ((V)(120D)), NewObj(5).Put("tongue", ((V)(1D))).Put("open", ((V)(0.3))).Put("pitch", ((V)(0.18))).Put("htilt", ((V)((ToNum(s_1016) * 8D)))).PutK(Get(k_1017, "wink"), ((V)(0.8))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("tongue", ((V)(0.7))).PutK(Get(k_1017, "wink"), ((V)(1D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(5).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).PutK(Get(k_1017, "wink"), ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "", true);
BODY_884 = NewObj(9).Put("tilly", NewObj(4).Put("ear", ((V)(1.3))).Put("tail", ((V)(1D))).Put("earTap", Arr(((V)(44D)), ((V)(12D)))).Put("lbl", NewObj(4).Put("ear", Fn((V _self836, int _argc1018, V s_1024, V _a1021, V _a1022, V _a1023, V[] _rest1019) => {
return ((V)((LtN(s_1024, 0D) ? "Crest (left)" : "Crest (right)")));
}, 1, "ear", true)).Put("side", ((V)("wing"))).Put("tail", ((V)("Tail feathers"))).Put("nose", ((V)("Beak"))).V).V).Put("pico", NewObj(4).Put("ear", ((V)(0D))).Put("tail", ((V)(1D))).Put("earTap", Arr(((V)(30D)), ((V)(30D)))).Put("lbl", NewObj(4).Put("ear", ((V)("head stripes"))).Put("side", ((V)("wing"))).Put("tail", ((V)("Tail feathers"))).Put("nose", ((V)("Beak"))).V).V).Put("clover", NewObj(4).Put("ear", ((V)(1.3))).Put("tail", ((V)(1D))).Put("earTap", Arr(((V)(39D)), ((V)(13D)))).Put("lbl", NewObj(2).Put("ear", ((V)("long ear"))).Put("tail", ((V)("Cotton tail"))).V).V).Put("chilla", NewObj(3).Put("ear", ((V)(1D))).Put("tail", ((V)(1D))).Put("lbl", NewObj(1).Put("tail", ((V)("Bushy tail"))).V).V).Put("mimi", NewObj(2).Put("ear", ((V)(1.1))).Put("tail", ((V)(1D))).V).Put("puddles", NewObj(4).Put("ear", ((V)(0.5))).Put("tail", ((V)(1D))).Put("earTap", Arr(((V)(49D)), ((V)(15D)))).Put("lbl", NewObj(5).Put("ear", Fn((V _self836, int _argc1025, V s_1031, V _a1028, V _a1029, V _a1030, V[] _rest1026) => {
return ((V)((LtN(s_1031, 0D) ? "Head fluff (left)" : "Head fluff (right)")));
}, 1, "ear", true)).Put("side", ((V)("wing"))).Put("foot", ((V)("webbed foot"))).Put("nose", ((V)("Bill"))).Put("tail", ((V)("Tail"))).V).V).Put("bean", NewObj(3).Put("ear", ((V)(0.5))).Put("tail", ((V)(1D))).Put("lbl", NewObj(2).Put("tail", ((V)("Curly tail"))).Put("nose", ((V)("Squishy nose"))).V).V).Put("zippy", NewObj(3).Put("ear", ((V)(0.6))).Put("tail", ((V)(1D))).Put("lbl", NewObj(1).Put("tail", ((V)("Fluffy tail"))).V).V).Put("mango", NewObj(5).Put("ear", ((V)(0D))).Put("tail", ((V)(1D))).Put("noWalk", ((V)(1D))).Put("earTap", Arr(((V)(24D)), ((V)(40D)))).Put("lbl", NewObj(3).Put("ear", ((V)("head side"))).Put("foot", ((V)("sticky toes"))).Put("tail", ((V)("Chunky tail"))).V).V).V;
RE_885 = NewObj(9).Put("tilly", NewObj(9).Put("head", Fn((V _self836, int _argc1032, V t_1038, V s_1039, V _a1036, V _a1037, V[] _rest1033) => {
Call(crest_880, V.Undef, t_1038, ((V)((-28D))), ((V)(120D)));
Invoke(t_1038, "wait", ((V)(250D)));
Call(see_853, V.Undef, t_1038, ((V)("head")), ((V)(0D)), ((V)(200D)));
Call(unsee_854, V.Undef, t_1038);
Invoke(Invoke(Invoke(t_1038, "to", ((V)(260D)), NewObj(4).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("close", ((V)(0.6))).Put("hap", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(2D)), NewObj(1).Put("pitch", ((V)((-0.12)))).V, NewObj(1).Put("pitch", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self836, int _argc1040, V t_1046, V s_1047, V _a1044, V _a1045, V[] _rest1041) => {
V k_1048 = default;
k_1048 = Call(S_844, V.Undef, s_1047);
Invoke(Invoke(Invoke(t_1046, "to", ((V)(90D)), NewObj(1).PutK(Get(k_1048, "ear"), ((V)((-34D)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).PutK(Get(k_1048, "ear"), ((V)(10D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).PutK(Get(k_1048, "ear"), ((V)(0D))).V, ((V)("io")));
Call(see_853, V.Undef, t_1046, ((V)("ear")), s_1047, ((V)(200D)));
Call(unsee_854, V.Undef, t_1046);
Call(chirp_874, V.Undef, t_1046, ((V)(0.7)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self836, int _argc1049, V t_1055, V s_1056, V _a1053, V _a1054, V[] _rest1050) => {
Invoke(t_1055, "to", ((V)(200D)), NewObj(1).Put("cross", ((V)(1D))).V, ((V)("io")));
Call(peck_879, V.Undef, t_1055, ((V)(2D)));
Invoke(t_1055, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io")));
Call(chirp_874, V.Undef, t_1055);
Invoke(t_1055, "to", ((V)(200D)), NewObj(1).Put("hap", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self836, int _argc1057, V t_1063, V s_1064, V _a1061, V _a1062, V[] _rest1058) => {
V k_1065 = default;
k_1065 = Call(S_844, V.Undef, s_1064);
Invoke(Invoke(Invoke(t_1063, "to", ((V)(200D)), NewObj(3).PutK(Get(k_1065, "wink"), ((V)(1D))).Put("earL", ((V)(16D))).Put("earR", ((V)(16D))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(200D)), NewObj(3).PutK(Get(k_1065, "wink"), ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Call(headShake_864, V.Undef, t_1063, ((V)(0.7)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self836, int _argc1066, V t_1072, V s_1073, V _a1070, V _a1071, V[] _rest1067) => {
Call(leanIn_861, V.Undef, t_1072, s_1073, NewObj(2).Put("earL", ((V)(14D))).Put("earR", ((V)(14D))).V);
Invoke(t_1072, "to", ((V)(200D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self836, int _argc1074, V t_1080, V s_1081, V _a1078, V _a1079, V[] _rest1075) => {
Invoke(t_1080, "to", ((V)(150D)), NewObj(3).Put("sq", ((V)(0.14))).Put("earL", ((V)(18D))).Put("earR", ((V)(18D))).V, ((V)("o")));
Call(giggle_855, V.Undef, t_1080, ((V)(3D)));
Invoke(t_1080, "to", ((V)(200D)), NewObj(3).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self836, int _argc1082, V t_1088, V s_1089, V _a1086, V _a1087, V[] _rest1083) => {
V k_1090 = default;
k_1090 = Call(S_844, V.Undef, s_1089);
Invoke(Invoke(Invoke(t_1088, "to", ((V)(100D)), NewObj(1).PutK(Get(k_1090, "arm"), ((V)(80D))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).PutK(Get(k_1090, "arm"), ((V)(20D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("featherY")), ((V)("body")), ((V)(1D)));
Call(see_853, V.Undef, t_1088, ((V)("side")), s_1089, ((V)(200D)));
Call(unsee_854, V.Undef, t_1088);
Invoke(t_1088, "to", ((V)(150D)), NewObj(1).PutK(Get(k_1090, "arm"), ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self836, int _argc1091, V t_1097, V s_1098, V _a1095, V _a1096, V[] _rest1092) => {
V k_1099 = default;
k_1099 = Call(S_844, V.Undef, s_1098);
Invoke(Invoke(t_1097, "to", ((V)(120D)), NewObj(2).PutK(Get(k_1099, "foot"), ((V)(3D))).Put("lift", ((V)(1D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).PutK(Get(k_1099, "foot"), ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("i")));
Call(see_853, V.Undef, t_1097, ((V)("foot")), s_1098, ((V)(200D)));
Call(unsee_854, V.Undef, t_1097);
Call(chirp_874, V.Undef, t_1097, ((V)(0.5)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self836, int _argc1100, V t_1106, V s_1107, V _a1104, V _a1105, V[] _rest1101) => {
Call(wagT_882, V.Undef, t_1106, ((V)(3D)), ((V)(24D)));
Call(see_853, V.Undef, t_1106, ((V)("tail")), ((V)(1D)), ((V)(300D)));
Call(unsee_854, V.Undef, t_1106);
Call(crest_880, V.Undef, t_1106, ((V)((-18D))), ((V)(140D)));
Invoke(t_1106, "to", ((V)(250D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "tail", true)).V).Put("pico", NewObj(9).Put("head", Fn((V _self836, int _argc1108, V t_1114, V s_1115, V _a1112, V _a1113, V[] _rest1109) => {
Invoke(Invoke(t_1114, "to", ((V)(80D)), NewObj(1).Put("sq", ((V)(0.1))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(see_853, V.Undef, t_1114, ((V)("head")), ((V)(0D)), ((V)(150D)));
Call(unsee_854, V.Undef, t_1114);
Call(chirp_874, V.Undef, t_1114);
Call(chirp_874, V.Undef, t_1114, ((V)(0.6)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self836, int _argc1116, V t_1122, V s_1123, V _a1120, V _a1121, V[] _rest1117) => {
Call(see_853, V.Undef, t_1122, ((V)("ear")), s_1123, ((V)(100D)));
Invoke(t_1122, "osc", ((V)(600D)), ((V)(4D)), NewObj(1).Put("htilt", ((V)((ToNum(s_1123) * 10D)))).V, NewObj(1).Put("htilt", ((V)((ToNum(s_1123) * 4D)))).V, ((V)("io")));
Call(unsee_854, V.Undef, t_1122);
Call(chirp_874, V.Undef, t_1122, ((V)(0.7)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self836, int _argc1124, V t_1130, V s_1131, V _a1128, V _a1129, V[] _rest1125) => {
Invoke(t_1130, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(1D))).V, ((V)("io")));
Call(peck_879, V.Undef, t_1130, ((V)(3D)));
Invoke(t_1130, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(0D))).V, ((V)("io")));
Invoke(t_1130, "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
Call(chirp_874, V.Undef, t_1130);
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self836, int _argc1132, V t_1138, V s_1139, V _a1136, V _a1137, V[] _rest1133) => {
V k_1140 = default;
k_1140 = Call(S_844, V.Undef, s_1139);
Invoke(Invoke(Invoke(t_1138, "to", ((V)(180D)), NewObj(1).PutK(Get(k_1140, "wink"), ((V)(1D))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(160D)), NewObj(1).PutK(Get(k_1140, "wink"), ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_1138, "to", ((V)(70D)), NewObj(1).Put("hyaw", ((V)(((-ToNum(s_1139)) * 0.4)))).V, ((V)("o"))), "wait", ((V)(150D))), "to", ((V)(90D)), NewObj(1).Put("hyaw", ((V)(0D))).V, ((V)("o")));
Call(chirp_874, V.Undef, t_1138, ((V)(0.6)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self836, int _argc1141, V t_1147, V s_1148, V _a1145, V _a1146, V[] _rest1142) => {
Call(leanIn_861, V.Undef, t_1147, s_1148);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self836, int _argc1149, V t_1155, V s_1156, V _a1153, V _a1154, V[] _rest1150) => {
Invoke(t_1155, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.12))).V, ((V)("o")));
Call(giggle_855, V.Undef, t_1155, ((V)(3D)));
Call(flap_881, V.Undef, t_1155, ((V)(2D)), ((V)(80D)));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self836, int _argc1157, V t_1163, V s_1164, V _a1161, V _a1162, V[] _rest1158) => {
V k_1165 = default;
k_1165 = Call(S_844, V.Undef, s_1164);
Invoke(Invoke(Invoke(t_1163, "to", ((V)(100D)), NewObj(1).PutK(Get(k_1165, "arm"), ((V)(90D))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(1).PutK(Get(k_1165, "arm"), ((V)(15D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("featherG")), ((V)("body")), ((V)(1D)));
Call(see_853, V.Undef, t_1163, ((V)("side")), s_1164, ((V)(150D)));
Call(unsee_854, V.Undef, t_1163);
Invoke(t_1163, "to", ((V)(120D)), NewObj(1).PutK(Get(k_1165, "arm"), ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self836, int _argc1166, V t_1172, V s_1173, V _a1170, V _a1171, V[] _rest1167) => {
V k_1174 = default;
k_1174 = Call(S_844, V.Undef, s_1173);
Invoke(Invoke(t_1172, "to", ((V)(100D)), NewObj(2).PutK(Get(k_1174, "foot"), ((V)(3D))).Put("lift", ((V)(1D))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(2).PutK(Get(k_1174, "foot"), ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("i")));
Call(see_853, V.Undef, t_1172, ((V)("foot")), s_1173, ((V)(150D)));
Call(unsee_854, V.Undef, t_1172);
Call(chirp_874, V.Undef, t_1172, ((V)(0.5)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self836, int _argc1175, V t_1181, V s_1182, V _a1179, V _a1180, V[] _rest1176) => {
Call(wagT_882, V.Undef, t_1181, ((V)(4D)), ((V)(24D)), ((V)(120D)));
Call(see_853, V.Undef, t_1181, ((V)("tail")), ((V)(1D)), ((V)(200D)));
Call(unsee_854, V.Undef, t_1181);
Call(chirp_874, V.Undef, t_1181);
return default;
}, 2, "tail", true)).V).Put("clover", NewObj(9).Put("head", Fn((V _self836, int _argc1183, V t_1189, V s_1190, V _a1187, V _a1188, V[] _rest1184) => {
Invoke(Invoke(Invoke(t_1189, "to", ((V)(260D)), NewObj(7).Put("close", ((V)(0.9))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("earL", ((V)(16D))).Put("earR", ((V)(16D))).Put("pitch", ((V)((-0.12)))).Put("sq", ((V)(0.06))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(260D)), NewObj(7).Put("close", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
Call(twitch_878, V.Undef, t_1189, ((V)(3D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self836, int _argc1191, V t_1197, V s_1198, V _a1195, V _a1196, V[] _rest1192) => {
V k_1199 = default;
k_1199 = Call(S_844, V.Undef, s_1198);
Invoke(Invoke(Invoke(t_1197, "to", ((V)(260D)), NewObj(1).PutK(Get(k_1199, "ear"), ((V)(24D))).V, ((V)("io"))), "wait", ((V)(150D))), "to", ((V)(300D)), NewObj(1).PutK(Get(k_1199, "ear"), ((V)(0D))).V, ((V)("io")));
Call(see_853, V.Undef, t_1197, ((V)("ear")), s_1198, ((V)(150D)));
Call(unsee_854, V.Undef, t_1197);
Call(headShake_864, V.Undef, t_1197, ((V)(0.7)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self836, int _argc1200, V t_1206, V s_1207, V _a1204, V _a1205, V[] _rest1201) => {
Invoke(t_1206, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(1D))).V, ((V)("io")));
Call(twitch_878, V.Undef, t_1206, ((V)(6D)));
Invoke(t_1206, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(0D))).V, ((V)("io")));
Call(lick_859, V.Undef, t_1206, ((V)(1D)));
Invoke(t_1206, "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self836, int _argc1208, V t_1214, V s_1215, V _a1212, V _a1213, V[] _rest1209) => {
V k_1216 = default;
k_1216 = Call(S_844, V.Undef, s_1215);
Invoke(Invoke(Invoke(t_1214, "to", ((V)(200D)), NewObj(1).PutK(Get(k_1216, "wink"), ((V)(1D))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(200D)), NewObj(1).PutK(Get(k_1216, "wink"), ((V)(0D))).V, ((V)("io")));
Call(rub_872, V.Undef, t_1214, s_1215, ((V)("eye")), ((V)(2D)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self836, int _argc1217, V t_1223, V s_1224, V _a1221, V _a1222, V[] _rest1218) => {
Call(leanIn_861, V.Undef, t_1223, s_1224, NewObj(2).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).V);
Invoke(t_1223, "to", ((V)(200D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self836, int _argc1225, V t_1231, V s_1232, V _a1229, V _a1230, V[] _rest1226) => {
Invoke(t_1231, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.1))).V, ((V)("o")));
Call(giggle_855, V.Undef, t_1231, ((V)(3D)));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self836, int _argc1233, V t_1239, V s_1240, V _a1237, V _a1238, V[] _rest1234) => {
Call(see_853, V.Undef, t_1239, ((V)("side")), s_1240, ((V)(150D)));
Call(unsee_854, V.Undef, t_1239);
Call(twitch_878, V.Undef, t_1239, ((V)(2D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self836, int _argc1241, V t_1247, V s_1248, V _a1245, V _a1246, V[] _rest1242) => {
V k_1249 = default;
k_1249 = Call(S_844, V.Undef, s_1248);
Invoke(Invoke(Invoke(Invoke(t_1247, "to", ((V)(200D)), NewObj(3).PutK(Get(k_1249, "foot"), ((V)(3.5))).Put("earL", ((V)(14D))).Put("earR", ((V)(14D))).V, ((V)("io"))), "to", ((V)(70D)), NewObj(2).PutK(Get(k_1249, "foot"), ((V)(0D))).Put("sq", ((V)(0.1))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(2D))), "to", ((V)(160D)), NewObj(3).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Call(see_853, V.Undef, t_1247, ((V)("foot")), s_1248, ((V)(150D)));
Call(unsee_854, V.Undef, t_1247);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self836, int _argc1250, V t_1256, V s_1257, V _a1254, V _a1255, V[] _rest1251) => {
Invoke(Invoke(t_1256, "osc", ((V)(500D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(20D))).V, NewObj(1).Put("wag", ((V)((-20D)))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).Put("wag", ((V)(0D))).V);
Call(see_853, V.Undef, t_1256, ((V)("tail")), ((V)(1D)), ((V)(300D)));
Call(unsee_854, V.Undef, t_1256);
Call(giggle_855, V.Undef, t_1256, ((V)(1D)));
return default;
}, 2, "tail", true)).V).Put("chilla", NewObj(9).Put("head", Fn((V _self836, int _argc1258, V t_1264, V s_1265, V _a1262, V _a1263, V[] _rest1259) => {
Invoke(Invoke(Invoke(t_1264, "to", ((V)(250D)), NewObj(5).Put("close", ((V)(0.9))).Put("hap", ((V)(1D))).Put("pitch", ((V)((-0.1)))).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(250D)), NewObj(5).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).Put("pitch", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self836, int _argc1266, V t_1272, V s_1273, V _a1270, V _a1271, V[] _rest1267) => {
V k_1274 = default;
k_1274 = Call(S_844, V.Undef, s_1273);
Invoke(Invoke(t_1272, "osc", ((V)(500D)), ((V)(3D)), NewObj(1).PutK(Get(k_1274, "ear"), ((V)((-14D)))).V, NewObj(1).PutK(Get(k_1274, "ear"), ((V)(8D))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(1).PutK(Get(k_1274, "ear"), ((V)(0D))).V);
Call(see_853, V.Undef, t_1272, ((V)("ear")), s_1273, ((V)(150D)));
Call(unsee_854, V.Undef, t_1272);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self836, int _argc1275, V t_1281, V s_1282, V _a1279, V _a1280, V[] _rest1276) => {
Invoke(t_1281, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(1D))).V, ((V)("io")));
Call(sniff_858, V.Undef, t_1281, ((V)(4D)));
Invoke(t_1281, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(0D))).V, ((V)("io")));
Call(lick_859, V.Undef, t_1281, ((V)(1D)));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self836, int _argc1283, V t_1289, V s_1290, V _a1287, V _a1288, V[] _rest1284) => {
V k_1291 = default;
k_1291 = Call(S_844, V.Undef, s_1290);
Invoke(Invoke(Invoke(t_1289, "to", ((V)(200D)), NewObj(1).PutK(Get(k_1291, "wink"), ((V)(1D))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(200D)), NewObj(1).PutK(Get(k_1291, "wink"), ((V)(0D))).V, ((V)("io")));
Call(rub_872, V.Undef, t_1289, s_1290, ((V)("eye")), ((V)(2D)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self836, int _argc1292, V t_1298, V s_1299, V _a1296, V _a1297, V[] _rest1293) => {
Call(leanIn_861, V.Undef, t_1298, s_1299);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self836, int _argc1300, V t_1306, V s_1307, V _a1304, V _a1305, V[] _rest1301) => {
Invoke(t_1306, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.14))).V, ((V)("o")));
Call(giggle_855, V.Undef, t_1306, ((V)(3D)));
Invoke(t_1306, "e", ((V)("emit")), ((V)("poof")), ((V)("body")), ((V)(2D)));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self836, int _argc1308, V t_1314, V s_1315, V _a1312, V _a1313, V[] _rest1309) => {
Call(popcorn_849, V.Undef, t_1314, ((V)(9D)), ((V)((-ToNum(s_1315)))), ((V)(460D)));
Invoke(t_1314, "e", ((V)("emit")), ((V)("poof")), ((V)("body")), ((V)(2D)));
Call(see_853, V.Undef, t_1314, ((V)("side")), s_1315, ((V)(150D)));
Call(unsee_854, V.Undef, t_1314);
return default;
}, 2, "side", true)).Put("foot", Fn((V _self836, int _argc1316, V t_1322, V s_1323, V _a1320, V _a1321, V[] _rest1317) => {
Call(pawShake_863, V.Undef, t_1322, s_1323, ((V)(0.8)));
Call(see_853, V.Undef, t_1322, ((V)("foot")), s_1323, ((V)(150D)));
Call(unsee_854, V.Undef, t_1322);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self836, int _argc1324, V t_1330, V s_1331, V _a1328, V _a1329, V[] _rest1325) => {
Invoke(Invoke(t_1330, "osc", ((V)(700D)), ((V)(4D)), NewObj(2).Put("wag", ((V)(30D))).Put("curl", ((V)(0.4))).V, NewObj(2).Put("wag", ((V)((-30D)))).Put("curl", ((V)(0D))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(2).Put("wag", ((V)(0D))).Put("curl", ((V)(0D))).V);
Call(see_853, V.Undef, t_1330, ((V)("tail")), ((V)(1D)), ((V)(300D)));
Call(unsee_854, V.Undef, t_1330);
Call(giggle_855, V.Undef, t_1330, ((V)(1D)));
return default;
}, 2, "tail", true)).V).Put("mimi", NewObj(9).Put("head", Fn((V _self836, int _argc1332, V t_1338, V s_1339, V _a1336, V _a1337, V[] _rest1333) => {
Invoke(t_1338, "to", ((V)(120D)), NewObj(3).Put("sq", ((V)(0.12))).Put("earL", ((V)(14D))).Put("earR", ((V)(14D))).V, ((V)("o")));
Call(squeak_876, V.Undef, t_1338);
Invoke(t_1338, "to", ((V)(200D)), NewObj(3).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Call(see_853, V.Undef, t_1338, ((V)("head")), ((V)(0D)), ((V)(150D)));
Call(unsee_854, V.Undef, t_1338);
return default;
}, 2, "head", true)).Put("ear", Fn((V _self836, int _argc1340, V t_1346, V s_1347, V _a1344, V _a1345, V[] _rest1341) => {
V k_1348 = default;
k_1348 = Call(S_844, V.Undef, s_1347);
Invoke(Invoke(t_1346, "osc", ((V)(400D)), ((V)(3D)), NewObj(1).PutK(Get(k_1348, "ear"), ((V)((-16D)))).V, NewObj(1).PutK(Get(k_1348, "ear"), ((V)(8D))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).PutK(Get(k_1348, "ear"), ((V)(0D))).V);
Call(see_853, V.Undef, t_1346, ((V)("ear")), s_1347, ((V)(150D)));
Call(rub_872, V.Undef, t_1346, s_1347, ((V)("ear")), ((V)(2D)));
Call(unsee_854, V.Undef, t_1346);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self836, int _argc1349, V t_1355, V s_1356, V _a1353, V _a1354, V[] _rest1350) => {
Invoke(t_1355, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(1D))).V, ((V)("io")));
Invoke(t_1355, "osc", ((V)(900D)), ((V)(6D)), NewObj(2).Put("mw", ((V)(0.7))).Put("pitch", ((V)(0.05))).V, NewObj(2).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("o")));
Invoke(t_1355, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(0D))).V, ((V)("io")));
Call(squeak_876, V.Undef, t_1355);
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self836, int _argc1357, V t_1363, V s_1364, V _a1361, V _a1362, V[] _rest1358) => {
V k_1365 = default;
k_1365 = Call(S_844, V.Undef, s_1364);
Invoke(Invoke(Invoke(t_1363, "to", ((V)(160D)), NewObj(1).PutK(Get(k_1365, "wink"), ((V)(1D))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(160D)), NewObj(1).PutK(Get(k_1365, "wink"), ((V)(0D))).V, ((V)("io")));
Call(rub_872, V.Undef, t_1363, s_1364, ((V)("eye")), ((V)(3D)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self836, int _argc1366, V t_1372, V s_1373, V _a1370, V _a1371, V[] _rest1367) => {
Call(leanIn_861, V.Undef, t_1372, s_1373);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self836, int _argc1374, V t_1380, V s_1381, V _a1378, V _a1379, V[] _rest1375) => {
Invoke(t_1380, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.12))).V, ((V)("o")));
Call(giggle_855, V.Undef, t_1380, ((V)(4D)));
Call(squeak_876, V.Undef, t_1380);
return default;
}, 2, "belly", true)).Put("side", Fn((V _self836, int _argc1382, V t_1388, V s_1389, V _a1386, V _a1387, V[] _rest1383) => {
Invoke(t_1388, "to", ((V)(70D)), NewObj(1).Put("wide", ((V)(1D))).V, ((V)("o")));
Call(squeak_876, V.Undef, t_1388);
Call(see_853, V.Undef, t_1388, ((V)("side")), s_1389, ((V)(150D)));
Call(unsee_854, V.Undef, t_1388);
Invoke(t_1388, "to", ((V)(150D)), NewObj(1).Put("wide", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self836, int _argc1390, V t_1396, V s_1397, V _a1394, V _a1395, V[] _rest1391) => {
Call(pawShake_863, V.Undef, t_1396, s_1397, ((V)(0.7)));
Call(see_853, V.Undef, t_1396, ((V)("foot")), s_1397, ((V)(150D)));
Call(unsee_854, V.Undef, t_1396);
Call(squeak_876, V.Undef, t_1396);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self836, int _argc1398, V t_1404, V s_1405, V _a1402, V _a1403, V[] _rest1399) => {
Invoke(Invoke(t_1404, "osc", ((V)(500D)), ((V)(5D)), NewObj(1).Put("wag", ((V)(34D))).V, NewObj(1).Put("wag", ((V)((-34D)))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).Put("wag", ((V)(0D))).V);
Invoke(t_1404, "to", ((V)(70D)), NewObj(1).Put("wide", ((V)(1D))).V, ((V)("o")));
Call(squeak_876, V.Undef, t_1404);
Call(see_853, V.Undef, t_1404, ((V)("tail")), ((V)(1D)), ((V)(250D)));
Call(unsee_854, V.Undef, t_1404);
Invoke(t_1404, "to", ((V)(150D)), NewObj(1).Put("wide", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "tail", true)).V).Put("puddles", NewObj(9).Put("head", Fn((V _self836, int _argc1406, V t_1412, V s_1413, V _a1410, V _a1411, V[] _rest1407) => {
Invoke(Invoke(t_1412, "to", ((V)(80D)), NewObj(3).Put("sq", ((V)(0.14))).Put("earL", ((V)((-16D)))).Put("earR", ((V)((-16D)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(3).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Call(quack_875, V.Undef, t_1412);
Call(see_853, V.Undef, t_1412, ((V)("head")), ((V)(0D)), ((V)(150D)));
Call(unsee_854, V.Undef, t_1412);
return default;
}, 2, "head", true)).Put("ear", Fn((V _self836, int _argc1414, V t_1420, V s_1421, V _a1418, V _a1419, V[] _rest1415) => {
V k_1422 = default;
k_1422 = Call(S_844, V.Undef, s_1421);
Invoke(Invoke(t_1420, "osc", ((V)(500D)), ((V)(3D)), NewObj(1).PutK(Get(k_1422, "ear"), ((V)((-20D)))).V, NewObj(1).PutK(Get(k_1422, "ear"), ((V)(10D))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).PutK(Get(k_1422, "ear"), ((V)(0D))).V);
Call(see_853, V.Undef, t_1420, ((V)("ear")), s_1421, ((V)(150D)));
Call(unsee_854, V.Undef, t_1420);
Call(giggle_855, V.Undef, t_1420, ((V)(1D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self836, int _argc1423, V t_1429, V s_1430, V _a1427, V _a1428, V[] _rest1424) => {
Invoke(t_1429, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(1D))).V, ((V)("io")));
Call(peck_879, V.Undef, t_1429, ((V)(2D)));
Invoke(t_1429, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(0D))).V, ((V)("io")));
Call(quack_875, V.Undef, t_1429);
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self836, int _argc1431, V t_1437, V s_1438, V _a1435, V _a1436, V[] _rest1432) => {
V k_1439 = default;
k_1439 = Call(S_844, V.Undef, s_1438);
Invoke(Invoke(Invoke(t_1437, "to", ((V)(200D)), NewObj(1).PutK(Get(k_1439, "wink"), ((V)(1D))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(200D)), NewObj(1).PutK(Get(k_1439, "wink"), ((V)(0D))).V, ((V)("io")));
Call(headShake_864, V.Undef, t_1437, ((V)(0.7)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self836, int _argc1440, V t_1446, V s_1447, V _a1444, V _a1445, V[] _rest1441) => {
Call(leanIn_861, V.Undef, t_1446, s_1447);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self836, int _argc1448, V t_1454, V s_1455, V _a1452, V _a1453, V[] _rest1449) => {
Invoke(t_1454, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.12))).V, ((V)("o")));
Call(giggle_855, V.Undef, t_1454, ((V)(3D)));
Call(flap_881, V.Undef, t_1454, ((V)(2D)), ((V)(90D)));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self836, int _argc1456, V t_1462, V s_1463, V _a1460, V _a1461, V[] _rest1457) => {
V k_1464 = default;
k_1464 = Call(S_844, V.Undef, s_1463);
Invoke(Invoke(Invoke(t_1462, "to", ((V)(100D)), NewObj(1).PutK(Get(k_1464, "arm"), ((V)(90D))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(1).PutK(Get(k_1464, "arm"), ((V)(15D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("fluffY")), ((V)("body")), ((V)(1D)));
Call(see_853, V.Undef, t_1462, ((V)("side")), s_1463, ((V)(150D)));
Call(unsee_854, V.Undef, t_1462);
Invoke(t_1462, "to", ((V)(120D)), NewObj(1).PutK(Get(k_1464, "arm"), ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self836, int _argc1465, V t_1471, V s_1472, V _a1469, V _a1470, V[] _rest1466) => {
V k_1473 = default;
k_1473 = Call(S_844, V.Undef, s_1472);
Invoke(Invoke(Invoke(Invoke(t_1471, "to", ((V)(150D)), NewObj(1).PutK(Get(k_1473, "foot"), ((V)(3D))).V, ((V)("o"))), "to", ((V)(80D)), NewObj(2).PutK(Get(k_1473, "foot"), ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("splash")), ((V)("body")), ((V)(2D))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(see_853, V.Undef, t_1471, ((V)("foot")), s_1472, ((V)(150D)));
Call(unsee_854, V.Undef, t_1471);
Call(giggle_855, V.Undef, t_1471, ((V)(1D)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self836, int _argc1474, V t_1480, V s_1481, V _a1478, V _a1479, V[] _rest1475) => {
Call(wagT_882, V.Undef, t_1480, ((V)(5D)), ((V)(34D)), ((V)(120D)));
Call(see_853, V.Undef, t_1480, ((V)("tail")), ((V)(1D)), ((V)(250D)));
Call(unsee_854, V.Undef, t_1480);
Call(quack_875, V.Undef, t_1480);
return default;
}, 2, "tail", true)).V).Put("bean", NewObj(9).Put("head", Fn((V _self836, int _argc1482, V t_1488, V s_1489, V _a1486, V _a1487, V[] _rest1483) => {
Invoke(t_1488, "to", ((V)(260D)), NewObj(5).Put("close", ((V)(0.9))).Put("hap", ((V)(1D))).Put("tongue", ((V)(0.6))).Put("open", ((V)(0.25))).Put("pitch", ((V)((-0.08)))).V, ((V)("io")));
Call(wagT_882, V.Undef, t_1488, ((V)(4D)), ((V)(38D)));
Invoke(t_1488, "to", ((V)(250D)), NewObj(5).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self836, int _argc1490, V t_1496, V s_1497, V _a1494, V _a1495, V[] _rest1491) => {
V k_1498 = default;
k_1498 = Call(S_844, V.Undef, s_1497);
Invoke(Invoke(t_1496, "to", ((V)(120D)), NewObj(1).PutK(Get(k_1498, "ear"), ((V)((-14D)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).PutK(Get(k_1498, "ear"), ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_1496, "to", ((V)(300D)), NewObj(1).Put("htilt", ((V)((ToNum(s_1497) * 14D)))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(250D)), NewObj(1).Put("htilt", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self836, int _argc1499, V t_1505, V s_1506, V _a1503, V _a1504, V[] _rest1500) => {
Invoke(t_1505, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(1D))).V, ((V)("io")));
Call(snort_865, V.Undef, t_1505, ((V)(2D)));
Invoke(t_1505, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(0D))).V, ((V)("io")));
Call(lick_859, V.Undef, t_1505, ((V)(2D)));
Invoke(t_1505, "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self836, int _argc1507, V t_1513, V s_1514, V _a1511, V _a1512, V[] _rest1508) => {
V k_1515 = default;
k_1515 = Call(S_844, V.Undef, s_1514);
Invoke(Invoke(Invoke(t_1513, "to", ((V)(200D)), NewObj(1).PutK(Get(k_1515, "wink"), ((V)(1D))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(200D)), NewObj(1).PutK(Get(k_1515, "wink"), ((V)(0D))).V, ((V)("io")));
Call(snort_865, V.Undef, t_1513, ((V)(1D)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self836, int _argc1516, V t_1522, V s_1523, V _a1520, V _a1521, V[] _rest1517) => {
Call(leanIn_861, V.Undef, t_1522, s_1523, NewObj(2).Put("tongue", ((V)(0.5))).Put("open", ((V)(0.2))).V);
Invoke(t_1522, "to", ((V)(200D)), NewObj(2).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self836, int _argc1524, V t_1530, V s_1531, V _a1528, V _a1529, V[] _rest1525) => {
V a_1532 = default;
Invoke(t_1530, "to", ((V)(200D)), NewObj(4).Put("sq", ((V)(0.12))).Put("hap", ((V)(1D))).Put("tongue", ((V)(0.6))).Put("open", ((V)(0.3))).V, ((V)("o")));
a_1532 = Get(t_1530, "t");
Call(giggle_855, V.Undef, t_1530, ((V)(3D)));
Call(para_860, V.Undef, t_1530, a_1532, Fn((V _self836, int _argc1533, V u_1539, V _a1536, V _a1537, V _a1538, V[] _rest1534) => {
return Invoke(Invoke(u_1539, "osc", ((V)(800D)), ((V)(4D)), NewObj(2).Put("footL", ((V)(2.5))).Put("footR", ((V)(0D))).V, NewObj(2).Put("footL", ((V)(0D))).Put("footR", ((V)(2.5))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(2).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V);
}, 1, "", true));
Invoke(t_1530, "to", ((V)(200D)), NewObj(3).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self836, int _argc1540, V t_1546, V s_1547, V _a1544, V _a1545, V[] _rest1541) => {
Call(see_853, V.Undef, t_1546, ((V)("side")), s_1547, ((V)(150D)));
Call(unsee_854, V.Undef, t_1546);
Call(snort_865, V.Undef, t_1546, ((V)(1D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self836, int _argc1548, V t_1554, V s_1555, V _a1552, V _a1553, V[] _rest1549) => {
Call(pawShake_863, V.Undef, t_1554, s_1555, ((V)(0.8)));
Call(see_853, V.Undef, t_1554, ((V)("foot")), s_1555, ((V)(150D)));
Call(unsee_854, V.Undef, t_1554);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self836, int _argc1556, V t_1562, V s_1563, V _a1560, V _a1561, V[] _rest1557) => {
Invoke(t_1562, "to", ((V)(300D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(wagT_882, V.Undef, t_1562, ((V)(6D)), ((V)(44D)), ((V)(120D)));
Call(see_853, V.Undef, t_1562, ((V)("tail")), ((V)(1D)), ((V)(200D)));
Call(unsee_854, V.Undef, t_1562);
Invoke(t_1562, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "tail", true)).V).Put("zippy", NewObj(9).Put("head", Fn((V _self836, int _argc1564, V t_1570, V s_1571, V _a1568, V _a1569, V[] _rest1565) => {
Call(dook_877, V.Undef, t_1570, ((V)(3D)));
Call(see_853, V.Undef, t_1570, ((V)("head")), ((V)(0D)), ((V)(120D)));
Call(unsee_854, V.Undef, t_1570);
return default;
}, 2, "head", true)).Put("ear", Fn((V _self836, int _argc1572, V t_1578, V s_1579, V _a1576, V _a1577, V[] _rest1573) => {
V k_1580 = default;
k_1580 = Call(S_844, V.Undef, s_1579);
Invoke(Invoke(t_1578, "to", ((V)(80D)), NewObj(1).PutK(Get(k_1580, "ear"), ((V)((-14D)))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(1).PutK(Get(k_1580, "ear"), ((V)(0D))).V, ((V)("io")));
Call(see_853, V.Undef, t_1578, ((V)("ear")), s_1579, ((V)(100D)));
Call(unsee_854, V.Undef, t_1578);
Call(dook_877, V.Undef, t_1578, ((V)(2D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self836, int _argc1581, V t_1587, V s_1588, V _a1585, V _a1586, V[] _rest1582) => {
Invoke(t_1587, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(1D))).V, ((V)("io")));
Call(sniff_858, V.Undef, t_1587, ((V)(3D)));
Invoke(t_1587, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(0D))).V, ((V)("io")));
Call(lick_859, V.Undef, t_1587, ((V)(1D)));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self836, int _argc1589, V t_1595, V s_1596, V _a1593, V _a1594, V[] _rest1590) => {
V k_1597 = default;
k_1597 = Call(S_844, V.Undef, s_1596);
Invoke(Invoke(Invoke(t_1595, "to", ((V)(160D)), NewObj(1).PutK(Get(k_1597, "wink"), ((V)(1D))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(160D)), NewObj(1).PutK(Get(k_1597, "wink"), ((V)(0D))).V, ((V)("io")));
Call(headShake_864, V.Undef, t_1595, ((V)(0.8)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self836, int _argc1598, V t_1604, V s_1605, V _a1602, V _a1603, V[] _rest1599) => {
Call(leanIn_861, V.Undef, t_1604, s_1605);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self836, int _argc1606, V t_1612, V s_1613, V _a1610, V _a1611, V[] _rest1607) => {
Invoke(t_1612, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.12))).V, ((V)("o")));
Call(giggle_855, V.Undef, t_1612, ((V)(4D)), ((V)(1.2)));
Call(dook_877, V.Undef, t_1612, ((V)(2D)));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self836, int _argc1614, V t_1620, V s_1621, V _a1618, V _a1619, V[] _rest1615) => {
Call(jump_846, V.Undef, t_1620, NewObj(8).Put("h", ((V)(6D))).Put("ant", ((V)(50D))).Put("up", ((V)(140D))).Put("c", ((V)(0.08))).Put("arm", ((V)(40D))).Put("x", ((V)(((-ToNum(s_1621)) * 3D)))).Put("air", NewObj(1).Put("tilt", ((V)(((-ToNum(s_1621)) * 10D)))).V).Put("fall", NewObj(1).Put("tilt", ((V)(0D))).V).V);
Call(see_853, V.Undef, t_1620, ((V)("side")), s_1621, ((V)(150D)));
Call(unsee_854, V.Undef, t_1620);
return default;
}, 2, "side", true)).Put("foot", Fn((V _self836, int _argc1622, V t_1628, V s_1629, V _a1626, V _a1627, V[] _rest1623) => {
Call(pawShake_863, V.Undef, t_1628, s_1629, ((V)(0.8)));
Call(see_853, V.Undef, t_1628, ((V)("foot")), s_1629, ((V)(120D)));
Call(unsee_854, V.Undef, t_1628);
Call(dook_877, V.Undef, t_1628, ((V)(2D)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self836, int _argc1630, V t_1636, V s_1637, V _a1634, V _a1635, V[] _rest1631) => {
Invoke(Invoke(Invoke(t_1636, "to", ((V)(70D)), NewObj(2).Put("wide", ((V)(1D))).Put("sq", ((V)((-0.08)))).V, ((V)("o"))), "osc", ((V)(500D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(36D))).V, NewObj(1).Put("wag", ((V)((-36D)))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(2).Put("wag", ((V)(0D))).Put("sq", ((V)(0D))).V);
Call(see_853, V.Undef, t_1636, ((V)("tail")), ((V)(1D)), ((V)(200D)));
Call(unsee_854, V.Undef, t_1636);
Invoke(t_1636, "to", ((V)(150D)), NewObj(1).Put("wide", ((V)(0D))).V, ((V)("io")));
Call(dook_877, V.Undef, t_1636, ((V)(2D)));
return default;
}, 2, "tail", true)).V).Put("mango", NewObj(9).Put("head", Fn((V _self836, int _argc1638, V t_1644, V s_1645, V _a1642, V _a1643, V[] _rest1639) => {
Invoke(Invoke(Invoke(Invoke(t_1644, "to", ((V)(300D)), NewObj(4).Put("close", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("pitch", ((V)((-0.06)))).V, ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(400D)), NewObj(2).Put("close", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self836, int _argc1646, V t_1652, V s_1653, V _a1650, V _a1651, V[] _rest1647) => {
Invoke(t_1652, "to", ((V)(300D)), NewObj(1).Put("htilt", ((V)((ToNum(s_1653) * 10D)))).V, ((V)("io")));
Call(see_853, V.Undef, t_1652, ((V)("ear")), s_1653, ((V)(250D)));
Call(unsee_854, V.Undef, t_1652, ((V)(400D)));
Invoke(t_1652, "to", ((V)(250D)), NewObj(1).Put("htilt", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self836, int _argc1654, V t_1660, V s_1661, V _a1658, V _a1659, V[] _rest1655) => {
Invoke(Invoke(Invoke(Invoke(t_1660, "to", ((V)(200D)), NewObj(1).Put("cross", ((V)(1D))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(2).Put("tongue", ((V)(0.9))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("cross", ((V)(0D))).V, ((V)("io")));
Invoke(t_1660, "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self836, int _argc1662, V t_1668, V s_1669, V _a1666, V _a1667, V[] _rest1663) => {
V k_1670 = default;
k_1670 = Call(S_844, V.Undef, s_1669);
Invoke(Invoke(Invoke(t_1668, "to", ((V)(220D)), NewObj(1).PutK(Get(k_1670, "wink"), ((V)(1D))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(200D)), NewObj(1).PutK(Get(k_1670, "wink"), ((V)(0D))).V, ((V)("io")));
Call(eyeLick_883, V.Undef, t_1668, s_1669);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self836, int _argc1671, V t_1677, V s_1678, V _a1675, V _a1676, V[] _rest1672) => {
Call(leanIn_861, V.Undef, t_1677, s_1678);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self836, int _argc1679, V t_1685, V s_1686, V _a1683, V _a1684, V[] _rest1680) => {
Invoke(t_1685, "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0.1))).V, ((V)("o")));
Call(giggle_855, V.Undef, t_1685, ((V)(2D)), ((V)(0.8)));
Invoke(Invoke(t_1685, "osc", ((V)(600D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(20D))).V, NewObj(1).Put("wag", ((V)((-20D)))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).Put("wag", ((V)(0D))).V);
return default;
}, 2, "belly", true)).Put("side", Fn((V _self836, int _argc1687, V t_1693, V s_1694, V _a1691, V _a1692, V[] _rest1688) => {
Invoke(t_1693, "to", ((V)(300D)), NewObj(2).Put("bend", ((V)((ToNum(s_1694) * 4D)))).Put("wag", ((V)(((-ToNum(s_1694)) * 20D)))).V, ((V)("io")));
Call(see_853, V.Undef, t_1693, ((V)("side")), s_1694, ((V)(300D)));
Call(unsee_854, V.Undef, t_1693, ((V)(400D)));
Invoke(t_1693, "to", ((V)(300D)), NewObj(2).Put("bend", ((V)(0D))).Put("wag", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self836, int _argc1695, V t_1701, V s_1702, V _a1699, V _a1700, V[] _rest1696) => {
V k_1703 = default;
k_1703 = Call(S_844, V.Undef, s_1702);
Invoke(Invoke(Invoke(t_1701, "to", ((V)(260D)), NewObj(1).PutK(Get(k_1703, "foot"), ((V)(3D))).V, ((V)("io"))), "osc", ((V)(500D)), ((V)(3D)), NewObj(1).PutK(Get(k_1703, "foot"), ((V)(3.5))).V, NewObj(1).PutK(Get(k_1703, "foot"), ((V)(2.5))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(1).PutK(Get(k_1703, "foot"), ((V)(0D))).V, ((V)("io")));
Call(see_853, V.Undef, t_1701, ((V)("foot")), s_1702, ((V)(200D)));
Call(unsee_854, V.Undef, t_1701);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self836, int _argc1704, V t_1710, V s_1711, V _a1708, V _a1709, V[] _rest1705) => {
Invoke(Invoke(t_1710, "osc", ((V)(800D)), ((V)(10D)), NewObj(1).Put("wag", ((V)(12D))).V, NewObj(1).Put("wag", ((V)((-12D)))).V, ((V)("l"))), "to", ((V)(100D)), NewObj(1).Put("wag", ((V)(0D))).V);
Call(see_853, V.Undef, t_1710, ((V)("tail")), ((V)(1D)), ((V)(300D)));
Call(unsee_854, V.Undef, t_1710, ((V)(400D)));
return default;
}, 2, "tail", true)).V).V;
TXT_886 = NewObj(9).Put("tilly", NewObj(9).Put("head", ((V)("Her crest pops up, then she bows her head for more scratches."))).Put("ear", ((V)("That crest feather flicks up and back, she looks up and whistles."))).Put("nose", ((V)("Gently nibbles your finger with her beak, then a happy whistle."))).Put("eye", ((V)("Blinks hard with her crest going flat, a little head shake."))).Put("cheek", ((V)("Leans her cheek into your finger, crest flat with bliss."))).Put("belly", ((V)("Fluffs up and giggles, crest flat."))).Put("side", ((V)("Her wing flicks out and a feather drifts down; she looks at the spot."))).Put("foot", ((V)("Lifts that foot, looks down and gives a small whistle."))).Put("tail", ((V)("Her tail feathers wag, she looks back and her crest pops up."))).V).Put("pico", NewObj(9).Put("head", ((V)("Bobs down under your finger, looks up, two chirps."))).Put("ear", ((V)("Tilts his head to show off his stripes, then chirps."))).Put("nose", ((V)("Pecks your finger playfully - peck peck peck - a heart and a chirp."))).Put("eye", ((V)("Blinks, a quick bird head-snap away and back, a chirp."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("Puffs up giggling and flaps his wings."))).Put("side", ((V)("His wing flicks out and a feather drifts down."))).Put("foot", ((V)("Lifts that foot and looks at it, chirp."))).Put("tail", ((V)("Tail flicks fast, he looks back and chirps."))).V).Put("clover", NewObj(9).Put("head", ((V)("Melts flat with her eyes shut and her ears spread - a happy bunny - then her nose twitches."))).Put("ear", ((V)("That long ear flicks back and springs up, then an ear shake."))).Put("nose", ((V)("Her nose twitches like crazy at your finger, then a little lick and a heart."))).Put("eye", ((V)("Blinks and rubs her eye with a paw."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("Giggles."))).Put("side", ((V)("Looks at the spot, nose twitching."))).Put("foot", ((V)("THUMP - stamps that foot and looks down at it."))).Put("tail", ((V)("Her cotton tail wiggles, she looks back and giggles."))).V).Put("chilla", NewObj(9).Put("head", ((V)("Shuts her eyes and leans into the pat."))).Put("ear", ((V)("That big round ear flicks back and forth."))).Put("nose", ((V)("Sniffs your finger and licks it."))).Put("eye", ((V)("Blinks and rubs her eye."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("So fluffy that a little dust puffs out when she giggles."))).Put("side", ((V)("Pops straight up like popcorn."))).Put("foot", ((V)("Shakes that foot."))).Put("tail", ((V)("Her bushy tail swishes, she looks back and giggles."))).V).Put("mimi", NewObj(9).Put("head", ((V)("Squeaks and ducks with her ears out."))).Put("ear", ((V)("That big pink ear flutters, she rubs it."))).Put("nose", ((V)("Sniff-sniff-sniff with her whiskers going, then a squeak."))).Put("eye", ((V)("Blinks and rubs her eye with a tiny paw."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("Giggles and squeaks."))).Put("side", ((V)("Jumps with a squeak, eyes wide."))).Put("foot", ((V)("Shakes that foot and squeaks."))).Put("tail", ((V)("Her tail flicks fast, squeak! - she looks back."))).V).Put("puddles", NewObj(9).Put("head", ((V)("Ducks with her head fluff standing up, then a quack."))).Put("ear", ((V)("Her head fluff wiggles, she giggles."))).Put("nose", ((V)("Nibbles your finger with her bill, quack."))).Put("eye", ((V)("Blinks, a little head shake."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("Giggles and flaps her wings."))).Put("side", ((V)("Her wing flicks out and some fluff floats off."))).Put("foot", ((V)("Stomps that webbed foot - splash - and giggles."))).Put("tail", ((V)("Waggles her tail, looks back, quack."))).V).Put("bean", NewObj(9).Put("head", ((V)("Eyes shut, tongue out, his curly tail going."))).Put("ear", ((V)("His ear perks and he tilts his head, puzzled."))).Put("nose", ((V)("Snorts at your finger, then licks it: a heart."))).Put("eye", ((V)("Blinks hard and snorts."))).Put("cheek", ((V)("Leans into your finger with his tongue out."))).Put("belly", ((V)("Belly rub! Giggles with his back legs kicking."))).Put("side", ((V)("Looks at the spot and snorts."))).Put("foot", ((V)("Shakes that paw."))).Put("tail", ((V)("His curly tail wags like mad."))).V).Put("zippy", NewObj(9).Put("head", ((V)("Happy dooks, bouncing."))).Put("ear", ((V)("His ear flicks, he looks up - dook dook."))).Put("nose", ((V)("Sniffs your finger and licks it."))).Put("eye", ((V)("Blinks and shakes his head."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("Super ticklish: giggles and dooks."))).Put("side", ((V)("A sideways war-dance hop away from the poke."))).Put("foot", ((V)("Shakes that paw, then dooks."))).Put("tail", ((V)("His tail puffs and swishes, he looks back - dook."))).V).Put("mango", NewObj(9).Put("head", ((V)("Shuts his eyes with a big grin for a long happy moment."))).Put("ear", ((V)("Tilts his head slowly toward the poke and looks."))).Put("nose", ((V)("Tastes your finger with his tongue: a heart."))).Put("eye", ((V)("Blinks, then licks that eyeball clean."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("Giggles, tail swishing."))).Put("side", ((V)("Curves away and looks at the spot, slowly."))).Put("foot", ((V)("Peels his sticky toes up and pats them back down."))).Put("tail", ((V)("Rattles the tip of his tail."))).V).V;
Call(build_873, V.Undef, RE_885, TXT_886, BODY_884);
return default;
}, 0, "boot", false)), V.Undef);
Call(Named(boot_1733 => Fn((V _self1712, int _argc1713, V _a1715, V _a1716, V _a1717, V _a1718, V[] _rest1714) => {
V R_1719 = default;
V o_1720 = default;
V jump_1721 = default;
V swing_1722 = default;
V popcorn_1723 = default;
V EAR_1724 = default;
V sniffF_1725 = default;
V lipLick_1726 = default;
V hearts_1727 = default;
V buildAll_1728 = default;
V chirp_1729 = default;
V quack_1730 = default;
V bob_1731 = default;
V CARDS_1732 = default;
if (_self1712.IsNullish) _self1712 = GlobalV;
R_1719 = Get(G("window"), "RiveRig");
if ((((!(Truthy(R_1719)) || !(Truthy(Get(R_1719, "EATKIT")))) || !(Truthy(Get(R_1719, "pet2V")))) || !(Truthy(Get(R_1719, "EATLIB"))))) {
Call(G("setTimeout"), V.Undef, boot_1733.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_1719, "pet2EatV"))) {
return default;
}
Set(R_1719, "pet2EatV", ((V)(1D)));
{ V _t1734 = Get(R_1719, "PETLIB");
if (_t1734.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1734));
{ V _t1735 = Get(_t1734, "o");
o_1720 = _t1735; }
{ V _t1736 = Get(_t1734, "jump");
jump_1721 = _t1736; }
{ V _t1737 = Get(_t1734, "swing");
swing_1722 = _t1737; }
{ V _t1738 = Get(_t1734, "popcorn");
popcorn_1723 = _t1738; } }
{ V _t1739 = Get(R_1719, "EATKIT");
if (_t1739.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1739));
{ V _t1740 = Get(_t1739, "EAR");
EAR_1724 = _t1740; }
{ V _t1741 = Get(_t1739, "sniffF");
sniffF_1725 = _t1741; }
{ V _t1742 = Get(_t1739, "lipLick");
lipLick_1726 = _t1742; }
{ V _t1743 = Get(_t1739, "hearts");
hearts_1727 = _t1743; }
{ V _t1744 = Get(_t1739, "buildAll");
buildAll_1728 = _t1744; } }
Object_assign(EAR_1724, NewObj(9).Put("tilly", ((V)(1D))).Put("pico", ((V)(0D))).Put("clover", ((V)(1.2))).Put("chilla", ((V)(0.9))).Put("mimi", ((V)(1D))).Put("puddles", ((V)(0.4))).Put("bean", ((V)(0.5))).Put("zippy", ((V)(0.6))).Put("mango", ((V)(0D))).V);
chirp_1729 = Fn((V _self1712, int _argc1745, V t_1751, V a_1752, V _a1749, V _a1750, V[] _rest1746) => {
return Invoke(Invoke(Invoke(t_1751, "to", ((V)(90D)), NewObj(3).Put("open", ((V)((0.5 * ToNum((a_1752 is var _t1753 && Truthy(_t1753) ? _t1753 : ((V)(1D)))))))).Put("mw", ((V)(0.6))).Put("pitch", ((V)(0.08))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(140D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 2, "", true);
quack_1730 = Fn((V _self1712, int _argc1754, V t_1760, V _a1757, V _a1758, V _a1759, V[] _rest1755) => {
return Invoke(Invoke(Invoke(t_1760, "to", ((V)(90D)), NewObj(3).Put("open", ((V)(0.65))).Put("mw", ((V)(1.1))).Put("pitch", ((V)(0.12))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(170D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
bob_1731 = Fn((V _self1712, int _argc1761, V t_1767, V n_1768, V _a1765, V _a1766, V[] _rest1762) => {
{
V i_1769 = default;
i_1769 = ((V)(0D));
while (true) {
if (!(Lt(i_1769, n_1768))) break;
Invoke(Invoke(t_1767, "to", ((V)(100D)), NewObj(2).Put("pitch", ((V)((-0.14)))).Put("sq", ((V)(0.02))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(2).Put("pitch", ((V)(0.03))).Put("sq", ((V)(0D))).V, ((V)("io")));
PostInc(ref i_1769, 1D);
}
}
return Invoke(t_1767, "to", ((V)(100D)), NewObj(1).Put("pitch", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "", true);
CARDS_1732 = NewObj(9).Put("tilly", NewObj(9).Put("chewMs", ((V)(110D))).Put("chewN", ((V)(1.2))).Put("open", ((V)(0.5))).Put("crumbs", ((V)(1D))).Put("txt", ((V)("Crest up with interest, quick little beak nibbles; bobs her head and whistles when she likes it."))).Put("pre", Fn((V _self1712, int _argc1771, V t_1777, V _a1774, V _a1775, V _a1776, V[] _rest1772) => {
Invoke(t_1777, "to", ((V)(160D)), NewObj(2).Put("earL", ((V)((-20D)))).Put("earR", ((V)((-20D)))).V, ((V)("o")));
Call(sniffF_1725, V.Undef, t_1777, ((V)(1D)));
return default;
}, 1, "pre", true)).Put("post", Fn((V _self1712, int _argc1778, V t_1784, V _a1781, V _a1782, V _a1783, V[] _rest1779) => {
return Invoke(t_1784, "to", ((V)(250D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _self1712, int _argc1785, V t_1791, V _a1788, V _a1789, V _a1790, V[] _rest1786) => {
Invoke(t_1791, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(bob_1731, V.Undef, t_1791, ((V)(3D)));
Call(chirp_1729, V.Undef, t_1791);
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1712, int _argc1792, V t_1798, V _a1795, V _a1796, V _a1797, V[] _rest1793) => {
Call(hearts_1727, V.Undef, t_1798, ((V)(2D)));
Invoke(t_1798, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(96D))).Put("armR", ((V)(96D))).Put("earL", ((V)((-26D)))).Put("earR", ((V)((-26D)))).V, ((V)("o")));
Call(bob_1731, V.Undef, t_1798, ((V)(3D)));
Invoke(t_1798, "to", ((V)(240D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Call(chirp_1729, V.Undef, t_1798);
return default;
}, 1, "love", true)).V).Put("pico", NewObj(7).Put("chewMs", ((V)(90D))).Put("chewN", ((V)(1.4))).Put("open", ((V)(0.5))).Put("crumbs", ((V)(2D))).Put("txt", ((V)("Pecks at it super fast; chatters and bobs when he likes it."))).Put("yum", Fn((V _self1712, int _argc1799, V t_1805, V _a1802, V _a1803, V _a1804, V[] _rest1800) => {
Invoke(Invoke(t_1805, "to", ((V)(140D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(5D)), NewObj(2).Put("open", ((V)(0.4))).Put("mw", ((V)(0.6))).V, NewObj(2).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("o")));
Call(bob_1731, V.Undef, t_1805, ((V)(3D)));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1712, int _argc1806, V t_1812, V _a1809, V _a1810, V _a1811, V[] _rest1807) => {
Call(hearts_1727, V.Undef, t_1812, ((V)(2D)));
Call(jump_1721, V.Undef, t_1812, NewObj(5).Put("h", ((V)(6D))).Put("ant", ((V)(100D))).Put("up", ((V)(160D))).Put("c", ((V)(0.12))).Put("arm", ((V)(90D))).V);
Call(bob_1731, V.Undef, t_1812, ((V)(3D)));
Call(chirp_1729, V.Undef, t_1812);
return default;
}, 1, "love", true)).V).Put("clover", NewObj(7).Put("chewMs", ((V)(95D))).Put("chewN", ((V)(1.5))).Put("open", ((V)(0.4))).Put("txt", ((V)("Sniffs it with her nose twitching, tiny quick bunny nibbles; binkies when she loves it."))).Put("pre", Fn((V _self1712, int _argc1813, V t_1819, V _a1816, V _a1817, V _a1818, V[] _rest1814) => {
Invoke(t_1819, "osc", ((V)(450D)), ((V)(3D)), NewObj(2).Put("mw", ((V)(0.7))).Put("pitch", ((V)(0.04))).V, NewObj(2).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "pre", true)).Put("yum", Fn((V _self1712, int _argc1820, V t_1826, V _a1823, V _a1824, V _a1825, V[] _rest1821) => {
Invoke(Invoke(t_1826, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(450D)), ((V)(3D)), NewObj(1).Put("mw", ((V)(0.7))).V, NewObj(1).Put("mw", ((V)(1D))).V, ((V)("o")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1712, int _argc1827, V t_1833, V _a1830, V _a1831, V _a1832, V[] _rest1828) => {
Call(hearts_1727, V.Undef, t_1833, ((V)(2D)));
Call(jump_1721, V.Undef, t_1833, NewObj(7).Put("h", ((V)(12D))).Put("ant", ((V)(150D))).Put("up", ((V)(240D))).Put("c", ((V)(0.18))).Put("arm", ((V)(20D))).Put("air", NewObj(5).Put("tilt", ((V)(10D))).Put("turn", ((V)(0.35))).Put("earL", ((V)(28D))).Put("earR", ((V)(28D))).Put("footR", ((V)(3.5))).V).Put("fall", NewObj(5).Put("tilt", ((V)(0D))).Put("turn", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("footR", ((V)(0D))).V).V);
return default;
}, 1, "love", true)).V).Put("chilla", NewObj(8).Put("chewMs", ((V)(85D))).Put("chewN", ((V)(1.5))).Put("open", ((V)(0.45))).Put("crumbs", ((V)(1D))).Put("headY", ((V)((-14D)))).Put("txt", ((V)("Holds it up in both paws and nibbles it fast; popcorns when she loves it."))).Put("yum", Fn((V _self1712, int _argc1834, V t_1840, V _a1837, V _a1838, V _a1839, V[] _rest1835) => {
Invoke(t_1840, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(swing_1722, V.Undef, t_1840, ((V)(700D)), ((V)(3D)), NewObj(1).Put("wag", ((V)(26D))).V);
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1712, int _argc1841, V t_1847, V _a1844, V _a1845, V _a1846, V[] _rest1842) => {
Call(hearts_1727, V.Undef, t_1847, ((V)(2D)));
Call(popcorn_1723, V.Undef, t_1847, ((V)(13D)), ((V)(1D)), ((V)(520D)));
return default;
}, 1, "love", true)).V).Put("mimi", NewObj(9).Put("chewMs", ((V)(70D))).Put("chewN", ((V)(1.8))).Put("open", ((V)(0.4))).Put("crumbs", ((V)(2D))).Put("headY", ((V)((-14D)))).Put("txt", ((V)("Holds it in her tiny paws and nibbles it super fast, whiskers going; squeaks when she likes it."))).Put("pre", Fn((V _self1712, int _argc1848, V t_1854, V _a1851, V _a1852, V _a1853, V[] _rest1849) => {
Invoke(t_1854, "osc", ((V)(500D)), ((V)(4D)), NewObj(2).Put("mw", ((V)(0.7))).Put("pitch", ((V)(0.05))).V, NewObj(2).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "pre", true)).Put("yum", Fn((V _self1712, int _argc1855, V t_1861, V _a1858, V _a1859, V _a1860, V[] _rest1856) => {
Invoke(Invoke(Invoke(t_1861, "to", ((V)(70D)), NewObj(4).Put("open", ((V)(0.4))).Put("mw", ((V)(0.55))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(140D)), NewObj(2).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
Call(swing_1722, V.Undef, t_1861, ((V)(600D)), ((V)(3D)), NewObj(1).Put("wag", ((V)(30D))).V);
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1712, int _argc1862, V t_1868, V _a1865, V _a1866, V _a1867, V[] _rest1863) => {
Call(hearts_1727, V.Undef, t_1868, ((V)(2D)));
Call(jump_1721, V.Undef, t_1868, NewObj(5).Put("h", ((V)(8D))).Put("ant", ((V)(60D))).Put("up", ((V)(180D))).Put("c", ((V)(0.12))).Put("arm", ((V)(50D))).V);
Invoke(Get(CARDS_1732, "mimi"), "yum", t_1868);
return default;
}, 1, "love", true)).V).Put("puddles", NewObj(8).Put("chewMs", ((V)(100D))).Put("chewN", ((V)(1.1))).Put("open", ((V)(0.6))).Put("crumbs", ((V)(2D))).Put("txt", ((V)("Dabbles at it with her bill, gulps it down; quacks and waggles her tail when she likes it."))).Put("post", Fn((V _self1712, int _argc1869, V t_1875, V _a1872, V _a1873, V _a1874, V[] _rest1870) => {
return Invoke(Invoke(t_1875, "to", ((V)(120D)), NewObj(2).Put("pitch", ((V)(0.2))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _self1712, int _argc1876, V t_1882, V _a1879, V _a1880, V _a1881, V[] _rest1877) => {
Invoke(t_1882, "to", ((V)(140D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(quack_1730, V.Undef, t_1882);
Call(swing_1722, V.Undef, t_1882, ((V)(700D)), ((V)(5D)), NewObj(1).Put("wag", ((V)(32D))).V);
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1712, int _argc1883, V t_1889, V _a1886, V _a1887, V _a1888, V[] _rest1884) => {
Call(hearts_1727, V.Undef, t_1889, ((V)(2D)));
Invoke(Invoke(Invoke(Invoke(t_1889, "to", ((V)(100D)), NewObj(2).Put("armL", ((V)(100D))).Put("armR", ((V)(100D))).V, ((V)("o"))), "to", ((V)(140D)), NewObj(2).Put("armL", ((V)(25D))).Put("armR", ((V)(25D))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(2).Put("armL", ((V)(100D))).Put("armR", ((V)(100D))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Get(CARDS_1732, "puddles"), "yum", t_1889);
return default;
}, 1, "love", true)).V).Put("bean", NewObj(9).Put("chewMs", ((V)(130D))).Put("chewN", ((V)(0.7))).Put("open", ((V)(0.85))).Put("crumbs", ((V)(3D))).Put("txt", ((V)("Snorts at it excitedly and gobbles it in big messy bites; licks his nose and wiggles his butt when he likes it."))).Put("pre", Fn((V _self1712, int _argc1890, V t_1896, V _a1893, V _a1894, V _a1895, V[] _rest1891) => {
{
V i_1897 = default;
i_1897 = ((V)(0D));
while (true) {
if (!(LtN(i_1897, 2D))) break;
Invoke(Invoke(t_1896, "to", ((V)(80D)), NewObj(3).Put("sq", ((V)(0.05))).Put("pitch", ((V)(0.1))).Put("mw", ((V)(0.75))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(3).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
PostInc(ref i_1897, 1D);
}
}
return default;
}, 1, "pre", true)).Put("post", Fn((V _self1712, int _argc1899, V t_1905, V _a1902, V _a1903, V _a1904, V[] _rest1900) => {
return Invoke(Invoke(Invoke(t_1905, "to", ((V)(150D)), NewObj(3).Put("tongue", ((V)(1D))).Put("open", ((V)(0.35))).Put("pitch", ((V)(0.12))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("tongue", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(3).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _self1712, int _argc1906, V t_1912, V _a1909, V _a1910, V _a1911, V[] _rest1907) => {
Invoke(t_1912, "to", ((V)(150D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(swing_1722, V.Undef, t_1912, ((V)(1000D)), ((V)(7D)), NewObj(3).Put("x", ((V)(1.4))).Put("tilt", ((V)(4D))).Put("wag", ((V)(40D))).V);
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1712, int _argc1913, V t_1919, V _a1916, V _a1917, V _a1918, V[] _rest1914) => {
Call(hearts_1727, V.Undef, t_1919, ((V)(2D)));
Invoke(Get(CARDS_1732, "bean"), "yum", t_1919);
return default;
}, 1, "love", true)).V).Put("zippy", NewObj(8).Put("chewMs", ((V)(90D))).Put("chewN", ((V)(1.2))).Put("open", ((V)(0.6))).Put("crumbs", ((V)(2D))).Put("txt", ((V)("Grabs it quick, looks around in case anyone wants it, nibbles fast; dooks and bounces when he likes it."))).Put("pre", Fn((V _self1712, int _argc1920, V t_1926, V _a1923, V _a1924, V _a1925, V[] _rest1921) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_1926, "to", ((V)(90D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("hyaw", ((V)((-0.2)))).V, ((V)("io"))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(1).Put("hyaw", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("yum", Fn((V _self1712, int _argc1927, V t_1933, V _a1930, V _a1931, V _a1932, V[] _rest1928) => {
Invoke(t_1933, "to", ((V)(120D)), NewObj(3).Put("open", ((V)(0.35))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("o")));
{
V i_1934 = default;
i_1934 = ((V)(0D));
while (true) {
if (!(LtN(i_1934, 3D))) break;
Invoke(Invoke(t_1933, "to", ((V)(80D)), NewObj(2).Put("lift", ((V)(1.6))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(90D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("i")));
PostInc(ref i_1934, 1D);
}
}
Invoke(Invoke(t_1933, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(140D)), NewObj(2).Put("sq", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1712, int _argc1936, V t_1942, V _a1939, V _a1940, V _a1941, V[] _rest1937) => {
Call(hearts_1727, V.Undef, t_1942, ((V)(2D)));
Call(jump_1721, V.Undef, t_1942, NewObj(6).Put("h", ((V)(10D))).Put("ant", ((V)(100D))).Put("up", ((V)(200D))).Put("c", ((V)(0.14))).Put("arm", ((V)(50D))).Put("spin", ((V)(360D))).V);
Invoke(Get(CARDS_1732, "zippy"), "yum", t_1942);
return default;
}, 1, "love", true)).V).Put("mango", NewObj(9).Put("chewMs", ((V)(170D))).Put("chewN", ((V)(0.8))).Put("open", ((V)(0.7))).Put("crumbs", ((V)(1D))).Put("txt", ((V)("Stalks it slowly with his tail tip twitching, a quick snap, slow chewing; licks his eye and grins when he likes it."))).Put("pre", Fn((V _self1712, int _argc1943, V t_1949, V _a1946, V _a1947, V _a1948, V[] _rest1944) => {
Invoke(Invoke(Invoke(t_1949, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)((-0.08)))).Put("ly", ((V)(0.5))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(7D)), NewObj(1).Put("wag", ((V)(10D))).V, NewObj(1).Put("wag", ((V)((-6D)))).V, ((V)("l"))), "to", ((V)(100D)), NewObj(3).Put("wag", ((V)(0D))).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _self1712, int _argc1950, V t_1956, V _a1953, V _a1954, V _a1955, V[] _rest1951) => {
return Call(lipLick_1726, V.Undef, t_1956);
}, 1, "post", true)).Put("yum", Fn((V _self1712, int _argc1957, V t_1963, V _a1960, V _a1961, V _a1962, V[] _rest1958) => {
Invoke(Invoke(Invoke(t_1963, "to", ((V)(300D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(5).Put("tongue", ((V)(1D))).Put("open", ((V)(0.3))).Put("pitch", ((V)(0.18))).Put("htilt", ((V)(8D))).Put("winkR", ((V)(1D))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(5).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io")));
Call(swing_1722, V.Undef, t_1963, ((V)(1400D)), ((V)(3D)), NewObj(1).Put("wag", ((V)(30D))).V);
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1712, int _argc1964, V t_1970, V _a1967, V _a1968, V _a1969, V[] _rest1965) => {
Call(hearts_1727, V.Undef, t_1970, ((V)(2D)));
Invoke(Get(CARDS_1732, "mango"), "yum", t_1970);
return default;
}, 1, "love", true)).V).V;
Call(buildAll_1728, V.Undef, CARDS_1732);
return default;
}, 0, "boot", false)), V.Undef);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
