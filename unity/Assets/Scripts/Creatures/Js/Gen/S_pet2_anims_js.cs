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
Invoke(KEYS_8, "forEach", Fn((V _arrowThis87, int _argc80, V k_86, V _a83, V _a84, V _a85, V[] _rest81) => {
return Invoke(Get(R_16, "SOFT"), "add", k_86);
}, 1, "", true));
if (Truthy(Get(R_16, "PRE"))) {
Object_assign(Get(R_16, "PRE"), NewObj(7).Put("featherY", NewObj(8).Put("n", ((V)(2D))).Put("sp", ((V)(10D))).Put("vy", ((V)((-9D)))).Put("g", ((V)(9D))).Put("life", ((V)(1800D))).Put("r", Arr(((V)(0.8)), ((V)(1.1)))).Put("col", Arr(((V)("#ffef9a")), ((V)("#e6e7ee")), ((V)("#cfd0d8")))).Put("kind", ((V)("leaf"))).V).Put("featherG", NewObj(8).Put("n", ((V)(2D))).Put("sp", ((V)(10D))).Put("vy", ((V)((-9D)))).Put("g", ((V)(9D))).Put("life", ((V)(1800D))).Put("r", Arr(((V)(0.8)), ((V)(1.1)))).Put("col", Arr(((V)("#a9e25c")), ((V)("#fff07a")), ((V)("#86c84a")))).Put("kind", ((V)("leaf"))).V).Put("fluffY", NewObj(8).Put("n", ((V)(2D))).Put("sp", ((V)(9D))).Put("vy", ((V)((-8D)))).Put("g", ((V)(8D))).Put("life", ((V)(1700D))).Put("r", Arr(((V)(0.7)), ((V)(1D)))).Put("col", Arr(((V)("#fff6c2")), ((V)("#ffe46a")), ((V)("#ffffff")))).Put("kind", ((V)("leaf"))).V).Put("poof", NewObj(8).Put("n", ((V)(3D))).Put("sp", ((V)(14D))).Put("vy", ((V)((-6D)))).Put("g", ((V)(3D))).Put("life", ((V)(1300D))).Put("r", Arr(((V)(1.8)), ((V)(3.4)))).Put("col", Arr(((V)("#f2f1f7")), ((V)("#e2e1ea")), ((V)("#ffffff")))).Put("kind", ((V)("puff"))).V).Put("dustbath", NewObj(7).Put("n", ((V)(3D))).Put("sp", ((V)(16D))).Put("vy", ((V)((-13D)))).Put("g", ((V)(4D))).Put("life", ((V)(1500D))).Put("r", Arr(((V)(2.8)), ((V)(4.8)))).Put("kind", ((V)("haze"))).V).Put("dustplume", NewObj(7).Put("n", ((V)(1D))).Put("sp", ((V)(5D))).Put("vy", ((V)((-21D)))).Put("g", ((V)((-2D)))).Put("life", ((V)(1900D))).Put("r", Arr(((V)(4D)), ((V)(6.2)))).Put("kind", ((V)("haze"))).V).Put("dustspray", NewObj(8).Put("n", ((V)(4D))).Put("sp", ((V)(24D))).Put("vy", ((V)((-22D)))).Put("g", ((V)(55D))).Put("life", ((V)(900D))).Put("r", Arr(((V)(0.3)), ((V)(0.65)))).Put("col", Arr(((V)("#b5ada1")), ((V)("#d8d1c6")), ((V)("#f3f0ea")))).Put("kind", ((V)("dot"))).V).V);
}
loopN_31 = Fn((V _arrowThis96, int _argc88, V t_94, V n_95, V _a92, V _a93, V[] _rest89) => {
return Object_assign(Invoke(t_94, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_94, "t")) * ToNum((n_95 is var _t97 && Truthy(_t97) ? _t97 : ((V)(3D)))))))).V);
}, 2, "", true);
para_32 = Fn((V _arrowThis107, int _argc98, V t_104, V from_105, V fn_106, V _a103, V[] _rest99) => {
V e_108 = default;
e_108 = Get(t_104, "t");
Invoke(t_104, "at", from_105);
Call(fn_106, V.Undef, t_104);
return Invoke(t_104, "at", ((V)(Max(ToNum(e_108), ToNum(Get(t_104, "t"))))));
return default;
}, 3, "", true);
bob_33 = Fn((V _arrowThis119, int _argc109, V t_115, V n_116, V per_117, V a_118, V[] _rest110) => {
a_118 = (a_118 is var _t120 && Truthy(_t120) ? _t120 : ((V)(0.14)));
{
double i_121 = 0;
i_121 = 0D;
while (true) {
if (!(Lt(((V)(i_121)), n_116))) break;
Invoke(Invoke(t_115, "to", ((V)((ToNum(per_117) * 0.4))), NewObj(2).Put("pitch", ((V)((-ToNum(a_118))))).Put("sq", ((V)(0.025))).V, ((V)("o"))), "to", ((V)((ToNum(per_117) * 0.6))), NewObj(2).Put("pitch", ((V)((ToNum(a_118) * 0.25)))).Put("sq", ((V)(0D))).V, ((V)("io")));
i_121++;
}
}
return Invoke(t_115, "to", ((V)(120D)), NewObj(1).Put("pitch", ((V)(0D))).V, ((V)("io")));
return default;
}, 4, "", true);
crest_34 = Fn((V _arrowThis133, int _argc123, V t_129, V v_130, V d_131, V ez_132, V[] _rest124) => {
return Invoke(t_129, "to", (d_131 is var _t134 && Truthy(_t134) ? _t134 : ((V)(140D))), NewObj(2).Put("earL", v_130).Put("earR", v_130).V, (ez_132 is var _t135 && Truthy(_t135) ? _t135 : ((V)("o"))));
}, 4, "", true);
flap_35 = Fn((V _arrowThis146, int _argc136, V t_142, V n_143, V per_144, V A_145, V[] _rest137) => {
{
double i_147 = 0;
i_147 = 0D;
while (true) {
if (!(Lt(((V)(i_147)), n_143))) break;
Invoke(Invoke(t_142, "to", ((V)((ToNum(per_144) * 0.45))), NewObj(2).Put("armL", A_145).Put("armR", A_145).V, ((V)("o"))), "to", ((V)((ToNum(per_144) * 0.55))), NewObj(2).Put("armL", ((V)((ToNum(A_145) * 0.25)))).Put("armR", ((V)((ToNum(A_145) * 0.25)))).V, ((V)("io")));
i_147++;
}
}
return t_142;
return default;
}, 4, "", true);
chirp_36 = Fn((V _arrowThis157, int _argc149, V t_155, V a_156, V _a153, V _a154, V[] _rest150) => {
return Invoke(Invoke(Invoke(t_155, "to", ((V)(90D)), NewObj(3).Put("open", ((V)((0.5 * ToNum((a_156 is var _t158 && Truthy(_t158) ? _t158 : ((V)(1D)))))))).Put("mw", ((V)(0.6))).Put("pitch", ((V)(0.08))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(140D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 2, "", true);
quack_37 = Fn((V _arrowThis166, int _argc159, V t_165, V _a162, V _a163, V _a164, V[] _rest160) => {
return Invoke(Invoke(Invoke(t_165, "to", ((V)(90D)), NewObj(4).Put("open", ((V)(0.65))).Put("mw", ((V)(1.1))).Put("pitch", ((V)(0.12))).Put("sq", ((V)((-0.03)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(170D)), NewObj(4).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
squeak_38 = Fn((V _arrowThis174, int _argc167, V t_173, V _a170, V _a171, V _a172, V[] _rest168) => {
return Invoke(Invoke(Invoke(t_173, "to", ((V)(70D)), NewObj(4).Put("open", ((V)(0.4))).Put("mw", ((V)(0.55))).Put("pitch", ((V)(0.1))).Put("wide", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(140D)), NewObj(4).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
snort_39 = Fn((V _arrowThis183, int _argc175, V t_181, V n_182, V _a179, V _a180, V[] _rest176) => {
{
double i_184 = 0;
i_184 = 0D;
while (true) {
if (!(Lt(((V)(i_184)), (n_182 is var _t186 && Truthy(_t186) ? _t186 : ((V)(2D)))))) break;
Invoke(Invoke(t_181, "to", ((V)(80D)), NewObj(4).Put("sq", ((V)(0.05))).Put("pitch", ((V)(0.1))).Put("mw", ((V)(0.75))).Put("close", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(4).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("mw", ((V)(1D))).Put("close", ((V)(0D))).V, ((V)("io")));
i_184++;
}
}
return t_181;
return default;
}, 2, "", true);
dook_40 = Fn((V _arrowThis195, int _argc187, V t_193, V n_194, V _a191, V _a192, V[] _rest188) => {
Invoke(t_193, "to", ((V)(120D)), NewObj(3).Put("open", ((V)(0.35))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("o")));
{
double i_196 = 0;
i_196 = 0D;
while (true) {
if (!(Lt(((V)(i_196)), (n_194 is var _t198 && Truthy(_t198) ? _t198 : ((V)(3D)))))) break;
Invoke(Invoke(t_193, "to", ((V)(80D)), NewObj(2).Put("lift", ((V)(1.6))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(90D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("i")));
i_196++;
}
}
Invoke(t_193, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
return Invoke(t_193, "to", ((V)(140D)), NewObj(2).Put("sq", ((V)(0D))).Put("open", ((V)(0.1))).V, ((V)("io")));
return default;
}, 2, "", true);
twitch_41 = Fn((V _arrowThis207, int _argc199, V t_205, V n_206, V _a203, V _a204, V[] _rest200) => {
return Invoke(t_205, "osc", ((V)((ToNum((n_206 is var _t208 && Truthy(_t208) ? _t208 : ((V)(3D)))) * 150D))), (n_206 is var _t209 && Truthy(_t209) ? _t209 : ((V)(3D))), NewObj(2).Put("mw", ((V)(0.7))).Put("pitch", ((V)(0.04))).V, NewObj(2).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("o")));
}, 2, "", true);
flutter_42 = Fn((V _arrowThis221, int _argc210, V t_216, V h_217, V dur_218, V n_219, V[] _rest211) => {
V b_222 = default;
V e_223 = default;
V x_220 = default;
x_220 = (_argc210 > 4 ? _rest211[0] : V.Undef);
Invoke(t_216, "to", ((V)(120D)), NewObj(4).Put("sq", ((V)(0.12))).Put("pitch", ((V)((-0.08)))).Put("armL", ((V)((-6D)))).Put("armR", ((V)((-6D)))).V, ((V)("io")));
b_222 = Get(t_216, "t");
Invoke(Invoke(t_216, "to", ((V)((ToNum(dur_218) * 0.45))), Call(o_21, V.Undef, NewObj(3).Put("lift", h_217).Put("sq", ((V)((-0.08)))).Put("pitch", ((V)(0.06))).V, (x_220 is var _t224 && Truthy(_t224) ? _t224 : NewObj(0).V)), ((V)("o"))), "to", ((V)((ToNum(dur_218) * 0.55))), NewObj(3).Put("lift", ((V)(0D))).Put("sq", ((V)((-0.02)))).Put("pitch", ((V)(0D))).V, ((V)("io")));
e_223 = Get(t_216, "t");
Invoke(t_216, "at", b_222);
Call(flap_35, V.Undef, t_216, n_219, ((V)((ToNum(dur_218) / ToNum(n_219)))), ((V)(115D)));
Invoke(t_216, "at", e_223);
return Invoke(Invoke(t_216, "to", ((V)(90D)), NewObj(3).Put("sq", ((V)(0.1))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(3).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return default;
}, 5, "", true);
stepTo_43 = Fn((V _arrowThis236, int _argc225, V t_231, V xs_232, V per_233, V h_234, V[] _rest226) => {
V x_235 = default;
x_235 = (_argc225 > 4 ? _rest226[0] : V.Undef);
Invoke(xs_232, "forEach", Fn((V _arrowThis245, int _argc237, V X_243, V i_244, V _a241, V _a242, V[] _rest238) => {
V f_246 = default;
f_246 = ((V)((NumTruthy((ToNum(i_244) % 2D)) ? "footL" : "footR")));
Invoke(Invoke(t_231, "to", ((V)((ToNum(per_233) * 0.5))), Call(o_21, V.Undef, NewObj(3).PutK(f_246, (h_234 is var _t247 && Truthy(_t247) ? _t247 : ((V)(3D)))).Put("x", X_243).Put("tilt", ((V)((NumTruthy((ToNum(i_244) % 2D)) ? (-2D) : 2D)))).V, (x_235 is var _t248 && Truthy(_t248) ? _t248 : NewObj(0).V)), ((V)("o"))), "to", ((V)((ToNum(per_233) * 0.5))), NewObj(2).PutK(f_246, ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("i")));
return default;
}, 2, "", true));
return t_231;
return default;
}, 5, "", true);
waddle_44 = Fn((V _arrowThis258, int _argc249, V t_255, V xs_256, V per_257, V _a254, V[] _rest250) => {
Invoke(xs_256, "forEach", Fn((V _arrowThis267, int _argc259, V X_265, V i_266, V _a263, V _a264, V[] _rest260) => {
V f_268 = default;
double d_269 = 0;
f_268 = ((V)((NumTruthy((ToNum(i_266) % 2D)) ? "footL" : "footR")));
d_269 = (NumTruthy((ToNum(i_266) % 2D)) ? (-1D) : 1D);
Invoke(Invoke(t_255, "to", ((V)((ToNum(per_257) * 0.5))), NewObj(5).PutK(f_268, ((V)(2.6))).Put("x", X_265).Put("tilt", ((V)((d_269 * 7D)))).Put("lean", ((V)((d_269 * 1.5)))).Put("wag", ((V)((d_269 * 20D)))).V, ((V)("o"))), "to", ((V)((ToNum(per_257) * 0.5))), NewObj(3).PutK(f_268, ((V)(0D))).Put("tilt", ((V)((d_269 * 2D)))).Put("lean", ((V)(0D))).V, ((V)("i")));
return default;
}, 2, "", true));
return Invoke(t_255, "to", ((V)(160D)), NewObj(2).Put("tilt", ((V)(0D))).Put("wag", ((V)(0D))).V, ((V)("io")));
return default;
}, 3, "", true);
binky_45 = Fn((V _arrowThis279, int _argc270, V t_276, V s_277, V h_278, V _a275, V[] _rest271) => {
return Call(jump_23, V.Undef, t_276, NewObj(7).Put("h", (h_278 is var _t280 && Truthy(_t280) ? _t280 : ((V)(12D)))).Put("ant", ((V)(150D))).Put("up", ((V)(240D))).Put("c", ((V)(0.18))).Put("arm", ((V)(20D))).Put("air", NewObj(6).Put("tilt", ((V)((ToNum(s_277) * 10D)))).Put("turn", ((V)((ToNum(s_277) * 0.35)))).Put("earL", ((V)(28D))).Put("earR", ((V)(28D))).Put("footL", ((V)((LtN(s_277, 0D) ? 3.5 : 0D)))).Put("footR", ((V)((GtN(s_277, 0D) ? 3.5 : 0D)))).V).Put("fall", NewObj(6).Put("tilt", ((V)(0D))).Put("turn", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V).V);
}, 3, "", true);
thump_46 = Fn((V _arrowThis289, int _argc281, V t_287, V s_288, V _a285, V _a286, V[] _rest282) => {
V k_290 = default;
k_290 = Call(S_18, V.Undef, (s_288 is var _t291 && Truthy(_t291) ? _t291 : ((V)(1D))));
return Invoke(Invoke(Invoke(Invoke(t_287, "to", ((V)(200D)), NewObj(5).PutK(Get(k_290, "foot"), ((V)(3.5))).Put("sq", ((V)((-0.03)))).Put("earL", ((V)(18D))).Put("earR", ((V)(18D))).Put("wide", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(70D)), NewObj(2).PutK(Get(k_290, "foot"), ((V)(0D))).Put("sq", ((V)(0.12))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(3D))), "to", ((V)(160D)), NewObj(3).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "", true);
slowBlink_47 = Fn((V _arrowThis299, int _argc292, V t_298, V _a295, V _a296, V _a297, V[] _rest293) => {
return Invoke(Invoke(Invoke(t_298, "to", ((V)(380D)), NewObj(1).Put("close", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(420D)), NewObj(1).Put("close", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
bathIn_48 = Fn((V _arrowThis307, int _argc300, V t_306, V _a303, V _a304, V _a305, V[] _rest301) => {
V a_308 = default;
a_308 = Get(t_306, "t");
Invoke(Invoke(t_306, "to", ((V)(240D)), NewObj(1).Put("dbb", ((V)(1.12))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(1).Put("dbb", ((V)(1D))).V, ((V)("io")));
Invoke(t_306, "at", Add(a_308, ((V)(90D))));
Call(jump_23, V.Undef, t_306, NewObj(5).Put("h", ((V)(8D))).Put("ant", ((V)(120D))).Put("up", ((V)(190D))).Put("c", ((V)(0.12))).Put("arm", ((V)(30D))).V);
return Invoke(Invoke(Invoke(t_306, "to", ((V)(220D)), NewObj(2).Put("lift", ((V)((-2.5)))).Put("sq", ((V)(0.1))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("dustbath")), Arr(((V)(36D)), ((V)(84D))), ((V)(2D))), "e", ((V)("emit")), ((V)("dustbath")), Arr(((V)(64D)), ((V)(84D))), ((V)(2D)));
return default;
}, 1, "", true);
BLIE_49 = NewObj(23).Put("tilt", ((V)(99D))).Put("x", ((V)((-43.5)))).Put("lift", ((V)(26.5))).Put("spin", ((V)((-16D)))).Put("sq", ((V)(0.1))).Put("sit", ((V)(1D))).Put("close", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("earL", ((V)(18D))).Put("earR", ((V)(50D))).Put("footL", ((V)(1.5))).Put("footR", ((V)(1.5))).Put("armL", ((V)((-8D)))).Put("armR", ((V)((-8D)))).Put("htilt", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("bend", ((V)(0D))).Put("twist", ((V)(0D))).Put("lean", ((V)(0D))).Put("wag", ((V)(0D))).Put("dbs", ((V)(1D))).Put("wsk", ((V)(1D))).V;
BA_50 = NewObj(16).Put("tilt", ((V)(105D))).Put("x", ((V)((-42D)))).Put("lift", ((V)(28.5))).Put("spin", ((V)((-82D)))).Put("sq", ((V)(0.18))).Put("footL", ((V)(3.4))).Put("footR", ((V)(1.2))).Put("armL", ((V)((-28D)))).Put("armR", ((V)(6D))).Put("earL", ((V)(27D))).Put("earR", ((V)(50D))).Put("htilt", ((V)((-11D)))).Put("hyaw", ((V)((-0.14)))).Put("bend", ((V)((-14D)))).Put("twist", ((V)((-0.12)))).Put("wag", ((V)((-32D)))).V;
BB_51 = NewObj(16).Put("tilt", ((V)(95D))).Put("x", ((V)((-46D)))).Put("lift", ((V)(25.5))).Put("spin", ((V)(38D))).Put("sq", ((V)(0.18))).Put("footL", ((V)(0.6))).Put("footR", ((V)(3.4))).Put("armL", ((V)(6D))).Put("armR", ((V)((-28D)))).Put("earL", ((V)(26D))).Put("earR", ((V)(55D))).Put("htilt", ((V)(11D))).Put("hyaw", ((V)(0.14))).Put("bend", ((V)(18D))).Put("twist", ((V)(0.12))).Put("wag", ((V)(32D))).V;
bmix_52 = Fn((V _arrowThis317, int _argc309, V o_315, V g_316, V _a313, V _a314, V[] _rest310) => {
V r_318 = default;
r_318 = NewObj(0).V;
{
foreach (V _k319 in ForInKeys(o_315)) {
V k_320 = default;
k_320 = _k319;
SetK(r_318, k_320, Add(GetK(BLIE_49, k_320), ((V)(((ToNum(GetK(o_315, k_320)) - ToNum(GetK(BLIE_49, k_320))) * ToNum(g_316))))));
}
}
return r_318;
return default;
}, 2, "", true);
flopIn_53 = Fn((V _arrowThis328, int _argc321, V t_327, V _a324, V _a325, V _a326, V[] _rest322) => {
return Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_327, "to", ((V)(220D)), NewObj(7).Put("sq", ((V)(0.22))).Put("lift", ((V)((-4D)))).Put("close", ((V)(0.7))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(10).Put("tilt", ((V)(44D))).Put("x", ((V)((-17D)))).Put("lift", ((V)(9D))).Put("spin", ((V)((-6D)))).Put("sq", ((V)(0.06))).Put("sit", ((V)(0.6))).Put("earL", ((V)(18D))).Put("earR", ((V)(18D))).Put("close", ((V)(1D))).Put("wsk", ((V)(0.5))).V, ((V)("i"))), "to", ((V)(190D)), Object_assign(NewObj(0).V, BLIE_49, NewObj(3).Put("tilt", ((V)(105D))).Put("lift", ((V)(25D))).Put("x", ((V)((-42.5)))).V), ((V)("o"))), "e", ((V)("emit")), ((V)("dustbath")), Arr(((V)(26D)), ((V)(83D))), ((V)(3D))), "e", ((V)("emit")), ((V)("dustbath")), Arr(((V)(52D)), ((V)(84D))), ((V)(3D))), "e", ((V)("emit")), ((V)("dustbath")), Arr(((V)(74D)), ((V)(83D))), ((V)(2D))), "e", ((V)("emit")), ((V)("dustspray")), Arr(((V)(20D)), ((V)(82D))), ((V)(3D))), "e", ((V)("emit")), ((V)("dustspray")), Arr(((V)(80D)), ((V)(82D))), ((V)(3D))), "to", ((V)(170D)), NewObj(3).Put("tilt", ((V)(99D))).Put("lift", ((V)(26.5))).Put("x", ((V)((-43.5)))).V, ((V)("io")));
}, 1, "", true);
rolls_54 = Fn((V _arrowThis339, int _argc329, V t_335, V n_336, V P_337, V hz_338, V[] _rest330) => {
V s0_340 = default;
V last_341 = default;
V s1_342 = default;
s0_340 = Get(t_335, "t");
last_341 = BLIE_49;
{
double i_343 = 0;
i_343 = 0D;
while (true) {
if (!(Lt(((V)(i_343)), n_336))) break;
double g_345 = 0;
double big_346 = 0;
double amp_347 = 0;
V A_348 = default;
V q_349 = default;
V mid_350 = default;
g_345 = Min(1D, ((i_343 + 1D) / 3D), ((ToNum(n_336) - i_343) / 3D));
big_346 = ((((i_343 % 8D) == 5D) || ((i_343 % 8D) == 6D)) ? 1.22 : 1D);
amp_347 = ((g_345 * big_346) * (0.88 + (0.12 * FdLibm.Sin((i_343 * 1.7)))));
A_348 = (((i_343 % 2D) == 0D) ? V.True : V.False);
q_349 = Call(bmix_52, V.Undef, (Truthy(A_348) ? BA_50 : BB_51), ((V)(amp_347)));
mid_350 = NewObj(0).V;
{
foreach (V _k351 in ForInKeys(q_349)) {
V k_352 = default;
k_352 = _k351;
SetK(mid_350, k_352, ((V)((ToNum(Add(GetK(last_341, k_352), GetK(q_349, k_352))) / 2D))));
}
}
Object_assign(mid_350, NewObj(5).Put("sq", ((V)((0.1 - (0.09 * g_345))))).Put("lift", Add(Get(mid_350, "lift"), ((V)((2.2 * g_345))))).Put("twist", ((V)(((Truthy(A_348) ? (-0.38) : 0.38) * g_345)))).Put("lean", ((V)(((Truthy(A_348) ? (-3D) : 3D) * g_345)))).Put("bend", ((V)((ToNum(Get(mid_350, "bend")) * 0.4)))).V, (Truthy(A_348) ? NewObj(2).Put("footL", ((V)((1.5 + (3D * g_345))))).Put("footR", ((V)(0D))).V : NewObj(2).Put("footL", ((V)(0D))).Put("footR", ((V)((1.5 + (3D * g_345))))).V));
Invoke(Invoke(t_335, "to", ((V)((ToNum(P_337) / 2D))), mid_350, ((V)("i"))), "to", ((V)((ToNum(P_337) / 2D))), q_349, ((V)("o")));
if (Truthy(A_348)) {
Invoke(Invoke(Invoke(t_335, "e", ((V)("emit")), ((V)("dustbath")), Arr(((V)((17D + ((i_343 * 7D) % 9D)))), ((V)(82D))), ((V)(1D))), "e", ((V)("emit")), ((V)("dustspray")), Arr(((V)(82D)), ((V)(81D))), ((V)(2D))), "e", ((V)("emit")), ((V)("dustplume")), (NumTruthy((i_343 % 4D)) ? Arr(((V)(86D)), ((V)(74D))) : Arr(((V)(14D)), ((V)(74D)))), ((V)(1D)));
} else {
Invoke(Invoke(t_335, "e", ((V)("emit")), ((V)("dustbath")), Arr(((V)((((i_343 % 4D) == 1D) ? 30D : 70D))), ((V)(87D))), ((V)(1D))), "e", ((V)("emit")), ((V)("dustspray")), Arr(((V)(24D)), ((V)(82D))), ((V)(2D)));
}
last_341 = q_349;
i_343++;
}
}
Invoke(t_335, "to", ((V)(200D)), Call(bmix_52, V.Undef, BA_50, ((V)(0D))), ((V)("io")));
s1_342 = Get(t_335, "t");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_335, "at", s0_340), "to", ((V)(Min(700D, ((ToNum(s1_342) - ToNum(s0_340)) * 0.4)))), NewObj(1).Put("dbh", hz_338).V, ((V)("io"))), "at", s0_340), "em", ((V)((ToNum(s1_342) - ToNum(s0_340)))), ((V)(100D)), ((V)("dustbath")), Arr(((V)(24D)), ((V)(83D))), ((V)(1D))), "em", ((V)((ToNum(s1_342) - ToNum(s0_340)))), ((V)(160D)), ((V)("dustbath")), Arr(((V)(50D)), ((V)(88D))), ((V)(1D))), "em", ((V)((ToNum(s1_342) - ToNum(s0_340)))), ((V)(110D)), ((V)("dustbath")), Arr(((V)(74D)), ((V)(83D))), ((V)(1D)));
Invoke(Invoke(t_335, "at", s1_342), "to", ((V)(1100D)), NewObj(1).Put("dbh", ((V)(0D))).V, ((V)("io")));
return Invoke(t_335, "at", s1_342);
return default;
}, 4, "", true);
rollUp_55 = Fn((V _arrowThis360, int _argc353, V t_359, V _a356, V _a357, V _a358, V[] _rest354) => {
return Invoke(Invoke(Invoke(Invoke(Invoke(t_359, "to", ((V)(230D)), NewObj(19).Put("tilt", ((V)(46D))).Put("x", ((V)((-16D)))).Put("lift", ((V)(10D))).Put("spin", ((V)((-6D)))).Put("sit", ((V)(0.4))).Put("sq", ((V)(0.06))).Put("close", ((V)(0.4))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("bend", ((V)(0D))).Put("twist", ((V)(0D))).Put("lean", ((V)(0D))).Put("wag", ((V)(0D))).Put("dbs", ((V)(0D))).Put("wsk", ((V)(0.4))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("dustbath")), Arr(((V)(30D)), ((V)(83D))), ((V)(2D))), "e", ((V)("emit")), ((V)("dustbath")), Arr(((V)(66D)), ((V)(83D))), ((V)(2D))), "to", ((V)(230D)), NewObj(11).Put("tilt", ((V)((-6D)))).Put("x", ((V)(0D))).Put("lift", ((V)((-1D)))).Put("spin", ((V)(0D))).Put("sit", ((V)(0D))).Put("sq", ((V)(0.04))).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("wsk", ((V)(0D))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(3).Put("tilt", ((V)(0D))).Put("lift", ((V)((-2.5)))).Put("sq", ((V)(0.1))).V, ((V)("io")));
}, 1, "", true);
rollBath_56 = Fn((V _arrowThis369, int _argc361, V t_367, V n_368, V _a365, V _a366, V[] _rest362) => {
Call(flopIn_53, V.Undef, t_367);
Call(rolls_54, V.Undef, t_367, n_368, ((V)(170D)), ((V)(0.8)));
return Call(rollUp_55, V.Undef, Invoke(t_367, "wait", ((V)(200D))));
return default;
}, 2, "", true);
dustOff_57 = Fn((V _arrowThis378, int _argc370, V t_376, V d_377, V _a374, V _a375, V[] _rest371) => {
V a_379 = default;
a_379 = Get(t_376, "t");
Invoke(Invoke(Invoke(Invoke(t_376, "e", ((V)("emit")), ((V)("dustbath")), ((V)("head")), ((V)(2D))), "e", ((V)("emit")), ((V)("dustbath")), ((V)("sideL")), ((V)(2D))), "e", ((V)("emit")), ((V)("dustbath")), ((V)("sideR")), ((V)(2D))), "em", (d_377 is var _t380 && Truthy(_t380) ? _t380 : ((V)(500D))), ((V)(90D)), ((V)("dustbath")), ((V)("body")), ((V)(1D)));
return Invoke(t_376, "at", a_379);
return default;
}, 2, "", true);
bathOut_58 = Fn((V _arrowThis388, int _argc381, V t_387, V _a384, V _a385, V _a386, V[] _rest382) => {
V b_389 = default;
V e_390 = default;
b_389 = Get(t_387, "t");
Call(jump_23, V.Undef, t_387, NewObj(6).Put("h", ((V)(10D))).Put("ant", ((V)(130D))).Put("up", ((V)(210D))).Put("c", ((V)(0.14))).Put("arm", ((V)(40D))).Put("ev", Arr(Arr(((V)("emit")), ((V)("dustbath")), Arr(((V)(34D)), ((V)(84D))), ((V)(2D))), Arr(((V)("emit")), ((V)("dustbath")), Arr(((V)(66D)), ((V)(84D))), ((V)(2D))))).V);
e_390 = Get(t_387, "t");
Invoke(Invoke(t_387, "at", Add(b_389, ((V)(230D)))), "to", ((V)(260D)), NewObj(1).Put("dbb", ((V)(0D))).V, ((V)("i")));
return Invoke(t_387, "at", ((V)(Max(ToNum(e_390), ToNum(Get(t_387, "t"))))));
return default;
}, 1, "", true);
eyeLick_59 = Fn((V _arrowThis399, int _argc391, V t_397, V s_398, V _a395, V _a396, V[] _rest392) => {
V k_400 = default;
k_400 = Call(S_18, V.Undef, s_398);
return Invoke(Invoke(Invoke(t_397, "to", ((V)(120D)), NewObj(6).Put("tongue", ((V)(1D))).Put("open", ((V)(0.3))).Put("pitch", ((V)(0.18))).Put("htilt", ((V)((ToNum(s_398) * 8D)))).Put("hyaw", ((V)((ToNum(s_398) * 0.12)))).PutK(Get(k_400, "wink"), ((V)(0.8))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("tongue", ((V)(0.7))).PutK(Get(k_400, "wink"), ((V)(1D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(6).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hyaw", ((V)(0D))).PutK(Get(k_400, "wink"), ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "", true);
headShake_60 = Fn((V _arrowThis409, int _argc401, V t_407, V a_408, V _a405, V _a406, V[] _rest402) => {
return Call(shake_25, V.Undef, t_407, NewObj(6).Put("P", ((V)(95D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.8)), ((V)(0.5)), ((V)(0.25)))).Put("head", ((V)((0.32 * ToNum((a_408 is var _t410 && Truthy(_t410) ? _t410 : ((V)(1D)))))))).Put("roll", ((V)(4D))).Put("ear", ((V)(14D))).Put("chest", ((V)(0.08))).V);
}, 2, "", true);
CARDS_61 = NewObj(9).Put("tilly", NewObj(4).Put("T", ((V)(0.95))).Put("b", ((V)(1.05))).Put("s", ((V)(1.1))).Put("e", ((V)(1.4))).V).Put("pico", NewObj(4).Put("T", ((V)(0.8))).Put("b", ((V)(1.15))).Put("s", ((V)(1D))).Put("e", ((V)(1D))).V).Put("clover", NewObj(4).Put("T", ((V)(1D))).Put("b", ((V)(1.2))).Put("s", ((V)(1D))).Put("e", ((V)(1.4))).V).Put("chilla", NewObj(5).Put("T", ((V)(0.85))).Put("b", ((V)(1.3))).Put("s", ((V)(1.1))).Put("e", ((V)(1.1))).Put("w", ((V)(1.2))).V).Put("mimi", NewObj(5).Put("T", ((V)(0.75))).Put("b", ((V)(0.95))).Put("s", ((V)(0.85))).Put("e", ((V)(1.2))).Put("w", ((V)(1.3))).V).Put("puddles", NewObj(4).Put("T", ((V)(0.95))).Put("b", ((V)(1.1))).Put("s", ((V)(1.3))).Put("w", ((V)(1.6))).V).Put("bean", NewObj(5).Put("T", ((V)(1.05))).Put("b", ((V)(1.2))).Put("s", ((V)(1.15))).Put("w", ((V)(1.8))).Put("e", ((V)(0.7))).V).Put("zippy", NewObj(5).Put("T", ((V)(0.8))).Put("b", ((V)(1.3))).Put("s", ((V)(1.4))).Put("w", ((V)(1.4))).Put("e", ((V)(0.8))).V).Put("mango", NewObj(5).Put("T", ((V)(1.2))).Put("b", ((V)(0.8))).Put("s", ((V)(1.1))).Put("w", ((V)(1.6))).Put("e", ((V)(0D))).V).V;
MOVES_62 = NewObj(9).Put("tilly", NewObj(7).Put("happy", Arr(Call(Fn((V _arrowThis417, int _argc411, V _a413, V _a414, V _a415, V _a416, V[] _rest412) => {
V t_418 = default;
t_418 = Call(TL_17, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Invoke(t_418, "to", ((V)(110D)), NewObj(1).Put("ly", ((V)((-0.4)))).V, ((V)("o")));
Call(crest_34, V.Undef, t_418, ((V)((-24D))), ((V)(170D)));
Invoke(Invoke(t_418, "to", ((V)(150D)), NewObj(4).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).Put("lift", ((V)(1D))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(4).Put("armL", ((V)(96D))).Put("armR", ((V)(96D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.02))).V, ((V)("io")));
Call(bob_33, V.Undef, t_418, ((V)(4D)), ((V)(260D)), ((V)(0.16)));
Call(chirp_36, V.Undef, t_418);
Call(chirp_36, V.Undef, t_418, ((V)(0.7)));
Invoke(t_418, "to", ((V)(240D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
Call(crest_34, V.Undef, t_418, ((V)(0D)), ((V)(280D)), ((V)("io")));
return Call(loopN_31, V.Undef, Invoke(t_418, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Her crest shoots up, she opens her wings in a heart shape, bobs her head and whistles.")))).Put("surprised", Arr(Call(Fn((V _arrowThis425, int _argc419, V _a421, V _a422, V _a423, V _a424, V[] _rest420) => {
V t_426 = default;
t_426 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_426, "wait", ((V)(120D))), "to", ((V)(60D)), NewObj(7).Put("wide", ((V)(1D))).Put("earL", ((V)((-32D)))).Put("earR", ((V)((-32D)))).Put("sq", ((V)((-0.07)))).Put("lift", ((V)(1.5))).Put("armL", ((V)(45D))).Put("armR", ((V)(45D))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(4).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).V, ((V)("i"))), "to", ((V)(150D)), NewObj(3).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("featherY")), ((V)("body")), ((V)(2D)));
Invoke(t_426, "wait", ((V)(280D)));
Call(look_24, V.Undef, t_426, ((V)(0D)), ((V)((-0.55))), NewObj(3).Put("k", ((V)(0.7))).Put("d1", ((V)(140D))).Put("d2", ((V)(170D))).V);
Invoke(t_426, "wait", ((V)(120D)));
Call(look_24, V.Undef, t_426, ((V)((-0.55))), ((V)(0.55)), NewObj(3).Put("k", ((V)(0.7))).Put("d1", ((V)(140D))).Put("d2", ((V)(170D))).V);
Invoke(t_426, "wait", ((V)(120D)));
Call(look_24, V.Undef, t_426, ((V)(0.55)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.7))).V);
Invoke(t_426, "to", ((V)(500D)), NewObj(3).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io")));
Call(chirp_36, V.Undef, t_426, ((V)(0.6)));
return Invoke(Invoke(t_426, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Her crest flies straight up, eyes pop and her wings flick out, a few feathers drift down, she looks around, and the crest slowly lowers.")))).Put("squish", Arr(Call(Fn((V _arrowThis433, int _argc427, V _a429, V _a430, V _a431, V _a432, V[] _rest428) => {
V t_434 = default;
t_434 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_434, "to", ((V)(130D)), NewObj(3).Put("sq", ((V)((-0.04)))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(7).Put("sq", ((V)(0.3))).Put("earL", ((V)(26D))).Put("earR", ((V)(26D))).Put("close", ((V)(0.8))).Put("hap", ((V)(0.6))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "wait", ((V)(320D)));
Invoke(Invoke(Invoke(t_434, "to", ((V)(110D)), NewObj(9).Put("sq", ((V)((-0.16)))).Put("earL", ((V)((-32D)))).Put("earR", ((V)((-32D)))).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).Put("wide", ((V)(0.6))).Put("lift", ((V)(3D))).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("featherY")), ((V)("body")), ((V)(3D))), "to", ((V)(200D)), NewObj(6).Put("sq", ((V)(0.06))).Put("lift", ((V)(0D))).Put("earL", ((V)(8D))).Put("earR", ((V)(8D))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("i")));
Call(jelly_28, V.Undef, t_434, ((V)(0.06)), ((V)(2D)), ((V)(260D)));
Invoke(t_434, "to", ((V)(260D)), NewObj(5).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("wide", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return Call(loopN_31, V.Undef, t_434);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed, she puffs into a fluffy ball with her crest flat; let go and she pops up with her crest springing tall.")))).Put("quirk", Arr(Call(Fn((V _arrowThis441, int _argc435, V _a437, V _a438, V _a439, V _a440, V[] _rest436) => {
V t_442 = default;
t_442 = Call(TL_17, V.Undef);
Invoke(Invoke(t_442, "to", ((V)(180D)), NewObj(2).Put("lx", ((V)((-0.8)))).Put("ly", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(380D)), NewObj(5).Put("hyaw", ((V)((-0.55)))).Put("pitch", ((V)((-0.25)))).Put("htilt", ((V)((-10D)))).Put("armL", ((V)(32D))).Put("twist", ((V)((-0.12)))).V, ((V)("io")));
{
double i_443 = 0;
i_443 = 0D;
while (true) {
if (!((i_443 < 3D))) break;
Invoke(Invoke(t_442, "to", ((V)(120D)), NewObj(3).Put("pitch", ((V)((-0.32)))).Put("open", ((V)(0.25))).Put("mw", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(4).Put("pitch", ((V)((-0.22)))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hyaw", ((V)(((-0.55) + (NumTruthy((i_443 % 2D)) ? 0.05 : (-0.05)))))).V, ((V)("io")));
i_443++;
}
}
Invoke(t_442, "to", ((V)(360D)), NewObj(7).Put("hyaw", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("twist", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
Invoke(t_442, "to", ((V)(220D)), NewObj(4).Put("sq", ((V)(0.12))).Put("earL", ((V)(18D))).Put("earR", ((V)(18D))).Put("close", ((V)(0.6))).V, ((V)("io")));
Call(shake_25, V.Undef, t_442, NewObj(7).Put("P", ((V)(80D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.8)), ((V)(0.5)), ((V)(0.25)))).Put("head", ((V)(0.3))).Put("roll", ((V)(4D))).Put("ear", ((V)((-14D)))).Put("chest", ((V)(0.1))).Put("body", ((V)(0.6))).V);
Invoke(t_442, "e", ((V)("emit")), ((V)("featherY")), ((V)("body")), ((V)(2D)));
Invoke(t_442, "to", ((V)(260D)), NewObj(4).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
Call(chirp_36, V.Undef, t_442, ((V)(0.6)));
return Invoke(Invoke(Invoke(t_442, "wait", ((V)(200D))), "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Preening")), ((V)("Lifts a wing and nibbles along her feathers, then fluffs right up and shakes every feather back into place, a little whistle.")))).Put("press", NewObj(4).Put("sq", ((V)(0.12))).Put("earL", ((V)(24D))).Put("earR", ((V)(24D))).Put("close", ((V)(0.6))).V).Put("rel", NewObj(3).Put("dur", ((V)(1000D))).Put("k", NewObj(6).Put("earL", Arr(Arr(((V)(0D)), ((V)(24D))), Arr(((V)(120D)), ((V)((-32D))), ((V)("o"))), Arr(((V)(420D)), ((V)(6D)), ((V)("io"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).Put("earR", Arr(Arr(((V)(0D)), ((V)(24D))), Arr(((V)(120D)), ((V)((-32D))), ((V)("o"))), Arr(((V)(420D)), ((V)(6D)), ((V)("io"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.12))), Arr(((V)(100D)), ((V)((-0.14))), ((V)("o"))), Arr(((V)(260D)), ((V)(0.06)), ((V)("io"))), Arr(((V)(420D)), ((V)(0D)), ((V)("io"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(100D)), ((V)(0D)), ((V)("o"))))).Put("armL", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(140D)), ((V)(70D)), ((V)("o"))), Arr(((V)(520D)), ((V)(0D)), ((V)("io"))))).Put("armR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(140D)), ((V)(70D)), ((V)("o"))), Arr(((V)(520D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("featherY")), ((V)("body")), ((V)(2D))))).V).Put("look", Call(Fn((V _arrowThis451, int _argc445, V _a447, V _a448, V _a449, V _a450, V[] _rest446) => {
V t_452 = default;
t_452 = Call(TL_17, V.Undef);
Call(look_24, V.Undef, t_452, ((V)(0D)), ((V)((-0.6))), NewObj(1).Put("k", ((V)(0.8))).V);
Invoke(t_452, "wait", ((V)(600D)));
Call(look_24, V.Undef, t_452, ((V)((-0.6))), ((V)(0.6)), NewObj(1).Put("k", ((V)(0.8))).V);
Call(crest_34, V.Undef, t_452, ((V)((-12D))), ((V)(160D)));
Invoke(t_452, "wait", ((V)(500D)));
Call(crest_34, V.Undef, t_452, ((V)(0D)), ((V)(300D)), ((V)("io")));
Call(look_24, V.Undef, t_452, ((V)(0.6)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.8))).V);
return Invoke(Invoke(t_452, "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).Put("pico", NewObj(7).Put("happy", Arr(Call(Fn((V _arrowThis459, int _argc453, V _a455, V _a456, V _a457, V _a458, V[] _rest454) => {
V t_460 = default;
t_460 = Call(TL_17, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Invoke(Invoke(t_460, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "osc", ((V)(900D)), ((V)(6D)), NewObj(3).Put("open", ((V)(0.45))).Put("mw", ((V)(0.6))).Put("pitch", ((V)(0.06))).V, NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("o")));
Call(jump_23, V.Undef, t_460, NewObj(8).Put("h", ((V)(6D))).Put("ant", ((V)(110D))).Put("up", ((V)(160D))).Put("c", ((V)(0.12))).Put("arm", ((V)(70D))).Put("x", ((V)(2.5))).Put("air", NewObj(1).Put("tilt", ((V)(4D))).V).Put("fall", NewObj(1).Put("tilt", ((V)(0D))).V).V);
Call(jump_23, V.Undef, t_460, NewObj(8).Put("h", ((V)(6D))).Put("ant", ((V)(110D))).Put("up", ((V)(160D))).Put("c", ((V)(0.12))).Put("arm", ((V)(70D))).Put("x", ((V)((-2.5)))).Put("air", NewObj(1).Put("tilt", ((V)((-4D)))).V).Put("fall", NewObj(1).Put("tilt", ((V)(0D))).V).V);
Call(jump_23, V.Undef, t_460, NewObj(6).Put("h", ((V)(4D))).Put("ant", ((V)(100D))).Put("up", ((V)(140D))).Put("c", ((V)(0.1))).Put("arm", ((V)(50D))).Put("x", ((V)(0D))).V);
Call(bob_33, V.Undef, t_460, ((V)(3D)), ((V)(200D)), ((V)(0.18)));
return Call(loopN_31, V.Undef, Invoke(t_460, "rest", ((V)(250D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Chatters away, hops right, left and home again, then bobs his head.")))).Put("surprised", Arr(Call(Fn((V _arrowThis467, int _argc461, V _a463, V _a464, V _a465, V _a466, V[] _rest462) => {
V t_468 = default;
t_468 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_468, "wait", ((V)(100D))), "to", ((V)(60D)), NewObj(3).Put("wide", ((V)(1D))).Put("sq", ((V)(0.1))).Put("lift", ((V)(1D))).V, ((V)("o"))), "to", ((V)(120D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("featherG")), ((V)("body")), ((V)(1D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_468, "wait", ((V)(350D))), "to", ((V)(70D)), NewObj(2).Put("hyaw", ((V)((-0.42)))).Put("lx", ((V)((-0.9)))).V, ((V)("o"))), "wait", ((V)(180D))), "to", ((V)(70D)), NewObj(2).Put("hyaw", ((V)(0.42))).Put("lx", ((V)(0.9))).V, ((V)("o"))), "wait", ((V)(180D))), "to", ((V)(70D)), NewObj(2).Put("hyaw", ((V)((-0.2)))).Put("lx", ((V)((-0.4)))).V, ((V)("o"))), "wait", ((V)(140D))), "to", ((V)(90D)), NewObj(2).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("o")));
Invoke(t_468, "to", ((V)(240D)), NewObj(2).Put("sq", ((V)(0D))).Put("wide", ((V)(0.2))).V, ((V)("io")));
Call(chirp_36, V.Undef, t_468, ((V)(0.8)));
Call(chirp_36, V.Undef, t_468, ((V)(0.6)));
return Invoke(Invoke(t_468, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Puffs up with his eyes popping, freezes, snaps his head left, right, left the way birds do, then two little chirps.")))).Put("squish", Arr(Call(Fn((V _arrowThis475, int _argc469, V _a471, V _a472, V _a473, V _a474, V[] _rest470) => {
V t_476 = default;
t_476 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_476, "to", ((V)(120D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(5).Put("sq", ((V)(0.32))).Put("close", ((V)(0.7))).Put("hap", ((V)(0.5))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(80D)), NewObj(5).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).Put("wide", ((V)(0.5))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("o")));
Call(flutter_42, V.Undef, t_476, ((V)(9D)), ((V)(520D)), ((V)(4D)));
Invoke(Invoke(t_476, "e", ((V)("emit")), ((V)("featherG")), ((V)("body")), ((V)(2D))), "to", ((V)(160D)), NewObj(1).Put("wide", ((V)(0D))).V, ((V)("io")));
Call(chirp_36, V.Undef, t_476);
return Call(loopN_31, V.Undef, t_476);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed, he puffs into a round ball; let go and he flutters up and chirps.")))).Put("quirk", Arr(Call(Fn((V _arrowThis483, int _argc477, V _a479, V _a480, V _a481, V _a482, V[] _rest478) => {
V t_484 = default;
t_484 = Call(TL_17, V.Undef);
Call(look_24, V.Undef, t_484, ((V)(0D)), ((V)(0.55)), NewObj(3).Put("k", ((V)(0.8))).Put("d1", ((V)(140D))).Put("d2", ((V)(170D))).V);
Invoke(Invoke(t_484, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "osc", ((V)(1100D)), ((V)(8D)), NewObj(3).Put("open", ((V)(0.4))).Put("mw", ((V)(0.6))).Put("pitch", ((V)(0.05))).V, NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("o")));
Call(bob_33, V.Undef, t_484, ((V)(3D)), ((V)(220D)), ((V)(0.18)));
Invoke(Invoke(Invoke(t_484, "to", ((V)(160D)), NewObj(4).Put("pitch", ((V)((-0.12)))).Put("hyaw", ((V)(0.66))).Put("mw", ((V)(0.5))).Put("open", ((V)(0.15))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "to", ((V)(220D)), NewObj(4).Put("pitch", ((V)(0D))).Put("hyaw", ((V)(0.55))).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).V, ((V)("io")));
Call(look_24, V.Undef, t_484, ((V)(0.55)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.8))).V);
return Invoke(Invoke(t_484, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Mirror chat")), ((V)("Turns to the bird in his mirror, chatters at it, bobs his head and gives it a little kiss.")))).Put("press", NewObj(2).Put("sq", ((V)(0.14))).Put("close", ((V)(0.6))).V).Put("rel", NewObj(3).Put("dur", ((V)(900D))).Put("k", NewObj(5).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(240D)), ((V)(8D)), ((V)("o"))), Arr(((V)(520D)), ((V)(0D)), ((V)("io"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.14))), Arr(((V)(80D)), ((V)((-0.12))), ((V)("o"))), Arr(((V)(500D)), ((V)((-0.02))), ((V)("io"))), Arr(((V)(600D)), ((V)(0.08)), ((V)("o"))), Arr(((V)(760D)), ((V)(0D)), ((V)("io"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(80D)), ((V)(0D)), ((V)("o"))))).Put("armL", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(80D)), ((V)(110D)), ((V)("o"))), Arr(((V)(180D)), ((V)(40D)), ((V)("io"))), Arr(((V)(280D)), ((V)(110D)), ((V)("o"))), Arr(((V)(380D)), ((V)(40D)), ((V)("io"))), Arr(((V)(480D)), ((V)(100D)), ((V)("o"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).Put("armR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(80D)), ((V)(110D)), ((V)("o"))), Arr(((V)(180D)), ((V)(40D)), ((V)("io"))), Arr(((V)(280D)), ((V)(110D)), ((V)("o"))), Arr(((V)(380D)), ((V)(40D)), ((V)("io"))), Arr(((V)(480D)), ((V)(100D)), ((V)("o"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("featherG")), ((V)("body")), ((V)(2D))))).V).Put("look", Call(Fn((V _arrowThis491, int _argc485, V _a487, V _a488, V _a489, V _a490, V[] _rest486) => {
V t_492 = default;
t_492 = Call(TL_17, V.Undef);
Call(look_24, V.Undef, t_492, ((V)(0D)), ((V)((-0.6))), NewObj(3).Put("k", ((V)(0.8))).Put("d1", ((V)(130D))).Put("d2", ((V)(160D))).V);
Invoke(t_492, "wait", ((V)(450D)));
Call(look_24, V.Undef, t_492, ((V)((-0.6))), ((V)(0.6)), NewObj(3).Put("k", ((V)(0.8))).Put("d1", ((V)(130D))).Put("d2", ((V)(160D))).V);
Invoke(t_492, "wait", ((V)(450D)));
Call(look_24, V.Undef, t_492, ((V)(0.6)), ((V)(0D)), NewObj(3).Put("k", ((V)(0.8))).Put("d1", ((V)(130D))).Put("d2", ((V)(160D))).V);
return Invoke(Invoke(t_492, "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).Put("clover", NewObj(7).Put("happy", Arr(Call(Fn((V _arrowThis499, int _argc493, V _a495, V _a496, V _a497, V _a498, V[] _rest494) => {
V t_500 = default;
t_500 = Call(TL_17, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Call(twitch_41, V.Undef, t_500, ((V)(3D)));
Call(binky_45, V.Undef, t_500, ((V)(1D)), ((V)(12D)));
Call(binky_45, V.Undef, t_500, ((V)((-1D))), ((V)(13D)));
Invoke(t_500, "wait", ((V)(120D)));
Call(twitch_41, V.Undef, t_500, ((V)(2D)));
return Call(loopN_31, V.Undef, Invoke(t_500, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Nose twitching, she does two binkies - leaping up with a twist and a kick, her long ears flying out.")))).Put("surprised", Arr(Call(Fn((V _arrowThis507, int _argc501, V _a503, V _a504, V _a505, V _a506, V[] _rest502) => {
V t_508 = default;
t_508 = Call(TL_17, V.Undef);
Invoke(Invoke(t_508, "wait", ((V)(120D))), "to", ((V)(70D)), NewObj(2).Put("wide", ((V)(1D))).Put("sq", ((V)(0.05))).V, ((V)("o")));
Call(thump_46, V.Undef, t_508, ((V)(1D)));
Invoke(t_508, "wait", ((V)(200D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_508, "to", ((V)(200D)), NewObj(2).Put("earL", ((V)((-7D)))).Put("earR", ((V)((-7D)))).V, ((V)("o"))), "wait", ((V)(300D))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(280D))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(280D)));
Call(twitch_41, V.Undef, t_508, ((V)(4D)));
Invoke(t_508, "to", ((V)(300D)), NewObj(4).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_508, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Eyes pop and she thumps a back foot, freezes with her ears pricked straight up while her eyes dart around, then her nose starts twitching again.")))).Put("squish", Arr(Call(Fn((V _arrowThis515, int _argc509, V _a511, V _a512, V _a513, V _a514, V[] _rest510) => {
V t_516 = default;
t_516 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_516, "to", ((V)(120D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(6).Put("sq", ((V)(0.3))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).Put("close", ((V)(0.8))).Put("hap", ((V)(0.6))).Put("pitch", ((V)((-0.08)))).V, ((V)("io"))), "wait", ((V)(320D)));
Invoke(t_516, "to", ((V)(60D)), NewObj(2).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("o")));
Call(binky_45, V.Undef, t_516, ((V)(1D)), ((V)(14D)));
Invoke(t_516, "to", ((V)(200D)), NewObj(3).Put("pitch", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return Call(loopN_31, V.Undef, t_516);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed into a bunny loaf; let go and she binkies straight up.")))).Put("quirk", Arr(Call(Fn((V _arrowThis523, int _argc517, V _a519, V _a520, V _a521, V _a522, V[] _rest518) => {
V t_524 = default;
t_524 = Call(TL_17, V.Undef);
Invoke(t_524, "to", ((V)(300D)), Call(o_21, V.Undef, Call(both_20, V.Undef, ((V)(4D)), ((V)((-16D)))), NewObj(4).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("pitch", ((V)((-0.08)))).Put("close", ((V)(0.8))).V), ((V)("io")));
{
double i_525 = 0;
i_525 = 0D;
while (true) {
if (!((i_525 < 3D))) break;
Invoke(Invoke(t_524, "to", ((V)(220D)), Call(o_21, V.Undef, Call(both_20, V.Undef, ((V)(5D)), ((V)((-22D)))), NewObj(1).Put("pitch", ((V)((-0.12)))).V), ((V)("io"))), "to", ((V)(200D)), Call(o_21, V.Undef, Call(both_20, V.Undef, ((V)(4D)), ((V)((-13D)))), NewObj(1).Put("pitch", ((V)((-0.06)))).V), ((V)("io")));
i_525++;
}
}
Invoke(t_524, "to", ((V)(320D)), Call(o_21, V.Undef, Call(hand_19, V.Undef, ((V)((-1D))), ((V)((-4D))), ((V)((-24D)))), NewObj(7).Put("armL", ((V)(40D))).Put("armR", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("htilt", ((V)((-12D)))).Put("earL", ((V)((-16D)))).Put("close", ((V)(0.5))).V), ((V)("io")));
Invoke(t_524, "osc", ((V)(900D)), ((V)(3D)), NewObj(3).Put("tongue", ((V)(0.8))).Put("open", ((V)(0.2))).Put("hLy", ((V)((-20D)))).V, NewObj(3).Put("tongue", ((V)(0.1))).Put("open", ((V)(0D))).Put("hLy", ((V)((-24D)))).V, ((V)("io")));
Invoke(t_524, "to", ((V)(300D)), Call(o_21, V.Undef, NOHANDS_22, NewObj(7).Put("armL", ((V)(0D))).Put("htilt", ((V)(0D))).Put("earL", ((V)(0D))).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("close", ((V)(0D))).Put("pitch", ((V)(0D))).V), ((V)("io")));
Call(headShake_60, V.Undef, t_524, ((V)(0.7)));
Call(twitch_41, V.Undef, t_524, ((V)(3D)));
return Invoke(Invoke(Invoke(t_524, "wait", ((V)(200D))), "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Face wash")), ((V)("Washes her face with both paws, tips her head and pulls a long ear down to lick it clean, a quick head shake, nose twitch.")))).Put("press", NewObj(4).Put("sq", ((V)(0.14))).Put("earL", ((V)((-8D)))).Put("earR", ((V)((-8D)))).Put("close", ((V)(0.6))).V).Put("rel", NewObj(2).Put("dur", ((V)(1100D))).Put("k", NewObj(6).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)(12D)), ((V)("o"))), Arr(((V)(520D)), ((V)(0D)), ((V)("i"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.14))), Arr(((V)(60D)), ((V)((-0.16))), ((V)("o"))), Arr(((V)(260D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(460D)), ((V)((-0.08))), ((V)("i"))), Arr(((V)(540D)), ((V)(0.16)), ((V)("o"))), Arr(((V)(700D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(840D)), ((V)(0D)), ((V)("io"))))).Put("earL", Arr(Arr(((V)(0D)), ((V)((-8D)))), Arr(((V)(200D)), ((V)(28D)), ((V)("o"))), Arr(((V)(520D)), ((V)((-6D))), ((V)("io"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))).Put("earR", Arr(Arr(((V)(0D)), ((V)((-8D)))), Arr(((V)(200D)), ((V)(28D)), ((V)("o"))), Arr(((V)(520D)), ((V)((-6D))), ((V)("io"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))).Put("tilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(8D)), ((V)("o"))), Arr(((V)(500D)), ((V)(0D)), ((V)("io"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(60D)), ((V)(0D)), ((V)("o"))))).V).V).Put("look", Call(Fn((V _arrowThis533, int _argc527, V _a529, V _a530, V _a531, V _a532, V[] _rest528) => {
V t_534 = default;
t_534 = Call(TL_17, V.Undef);
Call(look_24, V.Undef, t_534, ((V)(0D)), ((V)((-0.6))), NewObj(1).Put("k", ((V)(0.8))).V);
Call(twitch_41, V.Undef, t_534, ((V)(2D)));
Invoke(t_534, "wait", ((V)(500D)));
Call(look_24, V.Undef, t_534, ((V)((-0.6))), ((V)(0.6)), NewObj(1).Put("k", ((V)(0.8))).V);
Call(twitch_41, V.Undef, t_534, ((V)(2D)));
Invoke(t_534, "wait", ((V)(500D)));
Call(look_24, V.Undef, t_534, ((V)(0.6)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.8))).V);
return Invoke(Invoke(t_534, "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).Put("chilla", NewObj(7).Put("happy", Arr(Call(Fn((V _arrowThis541, int _argc535, V _a537, V _a538, V _a539, V _a540, V[] _rest536) => {
V t_542 = default;
t_542 = Call(TL_17, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Call(popcorn_29, V.Undef, t_542, ((V)(13D)), ((V)(1D)), ((V)(520D)));
Invoke(t_542, "wait", ((V)(150D)));
Call(popcorn_29, V.Undef, t_542, ((V)(15D)), ((V)((-1D))), ((V)(540D)));
Invoke(t_542, "e", ((V)("emit")), ((V)("poof")), ((V)("body")), ((V)(2D)));
Invoke(Invoke(t_542, "osc", ((V)(800D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(24D))).V, NewObj(1).Put("wag", ((V)((-24D)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("wag", ((V)(0D))).V, ((V)("io")));
return Call(loopN_31, V.Undef, Invoke(t_542, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Popcorns twice - springing straight up with a twist in the air - and swishes her bushy tail.")))).Put("surprised", Arr(Call(Fn((V _arrowThis549, int _argc543, V _a545, V _a546, V _a547, V _a548, V[] _rest544) => {
V t_550 = default;
t_550 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_550, "wait", ((V)(120D))), "to", ((V)(60D)), NewObj(4).Put("wide", ((V)(1D))).Put("earL", ((V)((-12D)))).Put("earR", ((V)((-12D)))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "wait", ((V)(450D)));
Call(jump_23, V.Undef, t_550, NewObj(6).Put("h", ((V)(7D))).Put("ant", ((V)(60D))).Put("up", ((V)(180D))).Put("c", ((V)(0.1))).Put("arm", ((V)(30D))).Put("x", ((V)((-3D)))).V);
Invoke(t_550, "e", ((V)("emit")), ((V)("poof")), ((V)("body")), ((V)(2D)));
Invoke(Invoke(Invoke(Invoke(t_550, "to", ((V)(90D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(250D)));
Call(stepTo_43, V.Undef, t_550, Arr(((V)((-1.5))), ((V)(0D))), ((V)(220D)), ((V)(2D)));
Invoke(t_550, "to", ((V)(300D)), NewObj(5).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_550, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Freezes with her big ears forward, hops back, eyes darting, then steps back to her spot.")))).Put("squish", Arr(Call(Fn((V _arrowThis557, int _argc551, V _a553, V _a554, V _a555, V _a556, V[] _rest552) => {
V t_558 = default;
t_558 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_558, "to", ((V)(120D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(5).Put("sq", ((V)(0.34))).Put("close", ((V)(0.9))).Put("hap", ((V)(0.8))).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).V, ((V)("io"))), "wait", ((V)(320D))), "to", ((V)(60D)), NewObj(2).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("o")));
Call(popcorn_29, V.Undef, t_558, ((V)(16D)), ((V)(1D)), ((V)(560D)));
Invoke(Invoke(t_558, "e", ((V)("emit")), ((V)("poof")), ((V)("body")), ((V)(3D))), "to", ((V)(260D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return Call(loopN_31, V.Undef, t_558);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed into a soft fluffball; let go and she popcorns up in a puff of dust.")))).Put("quirk", Arr(Call(Fn((V _arrowThis565, int _argc559, V _a561, V _a562, V _a563, V _a564, V[] _rest560) => {
V t_566 = default;
t_566 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_566, "to", ((V)(160D)), NewObj(2).Put("ly", ((V)(0.8))).Put("pitch", ((V)((-0.15)))).V, ((V)("o"))), "wait", ((V)(150D))), "to", ((V)(200D)), NewObj(4).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(bathIn_48, V.Undef, t_566);
Invoke(Invoke(t_566, "osc", ((V)(600D)), ((V)(3D)), NewObj(2).Put("mw", ((V)(0.7))).Put("pitch", ((V)((-0.12)))).V, NewObj(2).Put("mw", ((V)(1D))).Put("pitch", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(1).Put("pitch", ((V)(0D))).V, ((V)("io")));
Call(rollBath_56, V.Undef, t_566, ((V)(12D)));
Invoke(t_566, "wait", ((V)(120D)));
Call(bathOut_58, V.Undef, t_566);
Invoke(t_566, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0.6))).V, ((V)("io")));
Call(dustOff_57, V.Undef, t_566, ((V)(520D)));
Call(shake_25, V.Undef, t_566, NewObj(8).Put("P", ((V)(85D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.85)), ((V)(0.5)), ((V)(0.25)))).Put("head", ((V)(0.3))).Put("roll", ((V)(5D))).Put("ear", ((V)(12D))).Put("chest", ((V)(0.1))).Put("body", ((V)(0.8))).Put("tail", ((V)(30D))).V);
Invoke(Invoke(Invoke(t_566, "e", ((V)("emit")), ((V)("poof")), ((V)("head")), ((V)(2D))), "e", ((V)("emit")), ((V)("poof")), ((V)("sideL")), ((V)(1D))), "e", ((V)("emit")), ((V)("poof")), ((V)("sideR")), ((V)(1D)));
return Invoke(Invoke(Invoke(t_566, "wait", ((V)(200D))), "rest", ((V)(400D))), "done", NewObj(2).Put("stretch", ((V)(0.3))).Put("soft", ((V)(0.45))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Dust bath")), ((V)("Her big dust-bath tub pops in under her: she hops in, sniffs the dust, flops right over onto her side and rolls onto her back and over, feet in the air, dust flying; then she rolls back up, hops out - the tub pops away - and shakes the dust off.")))).Put("press", NewObj(3).Put("sq", ((V)(0.16))).Put("close", ((V)(0.7))).Put("hap", ((V)(0.6))).V).Put("rel", NewObj(3).Put("dur", ((V)(1000D))).Put("k", NewObj(5).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)(15D)), ((V)("o"))), Arr(((V)(520D)), ((V)(0D)), ((V)("i"))))).Put("spin", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(520D)), ((V)(180D)), ((V)("io"))), Arr(((V)(521D)), ((V)((-180D))), ((V)("l"))), Arr(((V)(900D)), ((V)(0D)), ((V)("io"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.16))), Arr(((V)(60D)), ((V)((-0.18))), ((V)("o"))), Arr(((V)(260D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(460D)), ((V)((-0.08))), ((V)("i"))), Arr(((V)(540D)), ((V)(0.18)), ((V)("o"))), Arr(((V)(700D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(840D)), ((V)(0D)), ((V)("io"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0.7))), Arr(((V)(60D)), ((V)(0D)), ((V)("o"))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(60D)), ((V)(1D)), ((V)("o"))), Arr(((V)(900D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("poof")), ((V)("body")), ((V)(3D))))).V).Put("look", Call(Fn((V _arrowThis573, int _argc567, V _a569, V _a570, V _a571, V _a572, V[] _rest568) => {
V t_574 = default;
t_574 = Call(TL_17, V.Undef);
Call(look_24, V.Undef, t_574, ((V)(0D)), ((V)((-0.6))), NewObj(1).Put("k", ((V)(0.8))).V);
Invoke(t_574, "wait", ((V)(500D)));
Call(look_24, V.Undef, t_574, ((V)((-0.6))), ((V)(0.6)), NewObj(1).Put("k", ((V)(0.8))).V);
Invoke(t_574, "wait", ((V)(500D)));
Call(look_24, V.Undef, t_574, ((V)(0.6)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.8))).V);
return Invoke(Invoke(t_574, "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).Put("mimi", NewObj(7).Put("happy", Arr(Call(Fn((V _arrowThis581, int _argc575, V _a577, V _a578, V _a579, V _a580, V[] _rest576) => {
V t_582 = default;
t_582 = Call(TL_17, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Invoke(t_582, "to", ((V)(220D)), NewObj(3).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(1.5))).Put("pitch", ((V)(0.06))).V, ((V)("o")));
Invoke(t_582, "to", ((V)(160D)), Call(both_20, V.Undef, ((V)(6D)), ((V)((-4D)))), ((V)("io")));
{
double i_583 = 0;
i_583 = 0D;
while (true) {
if (!((i_583 < 4D))) break;
Invoke(Invoke(t_582, "to", ((V)(90D)), Call(both_20, V.Undef, ((V)(2D)), ((V)((-5D)))), ((V)("o"))), "to", ((V)(110D)), Call(both_20, V.Undef, ((V)(6D)), ((V)((-4D)))), ((V)("io")));
i_583++;
}
}
Call(squeak_38, V.Undef, t_582);
Invoke(t_582, "osc", ((V)(700D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(28D))).V, NewObj(1).Put("wag", ((V)((-28D)))).V, ((V)("io")));
Invoke(t_582, "to", ((V)(240D)), Call(o_21, V.Undef, NOHANDS_22, NewObj(4).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("pitch", ((V)(0D))).Put("wag", ((V)(0D))).V), ((V)("io")));
return Call(loopN_31, V.Undef, Invoke(t_582, "rest", ((V)(250D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Stands up on her tiptoes, claps her tiny paws, squeaks and wiggles her tail.")))).Put("surprised", Arr(Call(Fn((V _arrowThis591, int _argc585, V _a587, V _a588, V _a589, V _a590, V[] _rest586) => {
V t_592 = default;
t_592 = Call(TL_17, V.Undef);
Invoke(Invoke(t_592, "wait", ((V)(100D))), "to", ((V)(60D)), NewObj(1).Put("wide", ((V)(1D))).V, ((V)("o")));
Call(squeak_38, V.Undef, t_592);
Call(jump_23, V.Undef, t_592, NewObj(6).Put("h", ((V)(9D))).Put("ant", ((V)(50D))).Put("up", ((V)(180D))).Put("c", ((V)(0.1))).Put("arm", ((V)(60D))).Put("st", ((V)(1.2))).V);
Invoke(Invoke(t_592, "to", ((V)(100D)), NewObj(3).Put("sq", ((V)(0.06))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V, ((V)("o"))), "wait", ((V)(450D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_592, "to", ((V)(90D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(200D))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(200D))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)(0D))).V, ((V)("o")));
Invoke(t_592, "osc", ((V)(700D)), ((V)(5D)), NewObj(4).Put("mw", ((V)(0.7))).Put("pitch", ((V)(0.06))).Put("earL", ((V)((-4D)))).Put("earR", ((V)((-4D)))).V, NewObj(4).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V, ((V)("o")));
Invoke(t_592, "to", ((V)(300D)), NewObj(4).Put("wide", ((V)(0D))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_592, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Squeaks and jumps straight up, freezes with her ears forward, eyes darting, then sniffs the air with her whiskers twitching.")))).Put("squish", Arr(Call(Fn((V _arrowThis599, int _argc593, V _a595, V _a596, V _a597, V _a598, V[] _rest594) => {
V t_600 = default;
t_600 = Call(TL_17, V.Undef);
Invoke(Invoke(t_600, "to", ((V)(120D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(5).Put("sq", ((V)(0.3))).Put("close", ((V)(1D))).Put("hap", ((V)(0.6))).Put("earL", ((V)(12D))).Put("earR", ((V)(12D))).V, ((V)("io")));
Call(squeak_38, V.Undef, t_600);
Invoke(Invoke(t_600, "wait", ((V)(200D))), "to", ((V)(60D)), NewObj(2).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("o")));
Call(jump_23, V.Undef, t_600, NewObj(6).Put("h", ((V)(10D))).Put("ant", ((V)(40D))).Put("up", ((V)(200D))).Put("c", ((V)(0.3))).Put("arm", ((V)(50D))).Put("st", ((V)(1.2))).V);
Invoke(t_600, "to", ((V)(220D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return Call(loopN_31, V.Undef, t_600);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed, she squeaks; let go and she springs up.")))).Put("quirk", Arr(Call(Fn((V _arrowThis607, int _argc601, V _a603, V _a604, V _a605, V _a606, V[] _rest602) => {
V t_608 = default;
t_608 = Call(TL_17, V.Undef);
Invoke(t_608, "to", ((V)(240D)), Call(o_21, V.Undef, Call(both_20, V.Undef, ((V)(5D)), ((V)((-15D)))), NewObj(4).Put("armL", ((V)(34D))).Put("armR", ((V)(34D))).Put("sq", ((V)((-0.04)))).Put("pitch", ((V)((-0.06)))).V), ((V)("io")));
{
double i_609 = 0;
i_609 = 0D;
while (true) {
if (!((i_609 < 4D))) break;
Invoke(Invoke(t_608, "to", ((V)(110D)), Call(o_21, V.Undef, Call(both_20, V.Undef, ((V)(9D)), ((V)((-13D)))), NewObj(1).Put("htilt", ((V)((NumTruthy((i_609 % 2D)) ? 4D : (-4D))))).V), ((V)("io"))), "to", ((V)(110D)), Call(both_20, V.Undef, ((V)(4D)), ((V)((-15D)))), ((V)("io")));
i_609++;
}
}
Invoke(t_608, "to", ((V)(240D)), Call(o_21, V.Undef, Call(both_20, V.Undef, ((V)(2D)), ((V)((-13D)))), NewObj(2).Put("pitch", ((V)((-0.12)))).Put("ly", ((V)(0.5))).V), ((V)("io")));
Invoke(Invoke(t_608, "osc", ((V)(900D)), ((V)(6D)), NewObj(3).Put("open", ((V)(0.25))).Put("mw", ((V)(0.6))).Put("puff", ((V)(0.3))).V, NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("head")), ((V)(2D)));
Invoke(t_608, "to", ((V)(260D)), Call(o_21, V.Undef, NOHANDS_22, NewObj(8).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io")));
Call(squeak_38, V.Undef, t_608);
return Invoke(Invoke(Invoke(t_608, "wait", ((V)(200D))), "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Whisker wash")), ((V)("Sits up and gives her whiskers a quick wash with both paws, finds a crumb and nibbles it super fast, then a happy squeak.")))).Put("press", NewObj(4).Put("sq", ((V)(0.14))).Put("close", ((V)(1D))).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).V).Put("rel", NewObj(2).Put("dur", ((V)(900D))).Put("k", NewObj(6).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(220D)), ((V)(10D)), ((V)("o"))), Arr(((V)(440D)), ((V)(0D)), ((V)("i"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.14))), Arr(((V)(60D)), ((V)((-0.14))), ((V)("o"))), Arr(((V)(220D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(400D)), ((V)((-0.06))), ((V)("i"))), Arr(((V)(460D)), ((V)(0.12)), ((V)("o"))), Arr(((V)(620D)), ((V)(0D)), ((V)("io"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(60D)), ((V)(0D)), ((V)("o"))))).Put("earL", Arr(Arr(((V)(0D)), ((V)(10D))), Arr(((V)(220D)), ((V)((-12D))), ((V)("o"))), Arr(((V)(600D)), ((V)(0D)), ((V)("io"))))).Put("earR", Arr(Arr(((V)(0D)), ((V)(10D))), Arr(((V)(220D)), ((V)((-12D))), ((V)("o"))), Arr(((V)(600D)), ((V)(0D)), ((V)("io"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(80D)), ((V)(0.4)), ((V)("o"))), Arr(((V)(260D)), ((V)(0D)), ((V)("io"))))).V).V).Put("look", Call(Fn((V _arrowThis617, int _argc611, V _a613, V _a614, V _a615, V _a616, V[] _rest612) => {
V t_618 = default;
t_618 = Call(TL_17, V.Undef);
Call(look_24, V.Undef, t_618, ((V)(0D)), ((V)((-0.6))), NewObj(3).Put("k", ((V)(0.8))).Put("d1", ((V)(140D))).Put("d2", ((V)(170D))).V);
Invoke(t_618, "osc", ((V)(480D)), ((V)(3D)), NewObj(1).Put("mw", ((V)(0.75))).V, NewObj(1).Put("mw", ((V)(1D))).V, ((V)("o")));
Invoke(t_618, "wait", ((V)(300D)));
Call(look_24, V.Undef, t_618, ((V)((-0.6))), ((V)(0.6)), NewObj(3).Put("k", ((V)(0.8))).Put("d1", ((V)(140D))).Put("d2", ((V)(170D))).V);
Invoke(t_618, "wait", ((V)(450D)));
Call(look_24, V.Undef, t_618, ((V)(0.6)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.8))).V);
return Invoke(Invoke(t_618, "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).Put("puddles", NewObj(7).Put("happy", Arr(Call(Fn((V _arrowThis625, int _argc619, V _a621, V _a622, V _a623, V _a624, V[] _rest620) => {
V t_626 = default;
t_626 = Call(TL_17, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Invoke(Invoke(t_626, "osc", ((V)(700D)), ((V)(5D)), NewObj(1).Put("wag", ((V)(30D))).V, NewObj(1).Put("wag", ((V)((-30D)))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).Put("wag", ((V)(0D))).V, ((V)("io")));
Call(flap_35, V.Undef, t_626, ((V)(3D)), ((V)(260D)), ((V)(100D)));
Invoke(t_626, "to", ((V)(160D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(quack_37, V.Undef, t_626);
Call(jump_23, V.Undef, t_626, NewObj(5).Put("h", ((V)(6D))).Put("ant", ((V)(130D))).Put("up", ((V)(180D))).Put("c", ((V)(0.14))).Put("arm", ((V)(70D))).V);
Call(quack_37, V.Undef, t_626);
return Call(loopN_31, V.Undef, Invoke(t_626, "rest", ((V)(250D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Waggles her little tail, flaps her wings, quacks, a happy hop and another quack.")))).Put("surprised", Arr(Call(Fn((V _arrowThis633, int _argc627, V _a629, V _a630, V _a631, V _a632, V[] _rest628) => {
V t_634 = default;
t_634 = Call(TL_17, V.Undef);
Invoke(Invoke(t_634, "wait", ((V)(100D))), "to", ((V)(60D)), NewObj(3).Put("wide", ((V)(1D))).Put("earL", ((V)((-20D)))).Put("earR", ((V)((-20D)))).V, ((V)("o")));
Call(quack_37, V.Undef, t_634);
Call(jump_23, V.Undef, t_634, NewObj(7).Put("h", ((V)(9D))).Put("ant", ((V)(50D))).Put("up", ((V)(190D))).Put("c", ((V)(0.1))).Put("arm", ((V)(110D))).Put("st", ((V)(1.2))).Put("ev", Arr(Arr(((V)("emit")), ((V)("fluffY")), ((V)("body")), ((V)(2D))))).V);
Invoke(t_634, "wait", ((V)(250D)));
Call(waddle_44, V.Undef, t_634, Arr(((V)((-1.5))), ((V)((-3D))), ((V)((-1.5))), ((V)(0D))), ((V)(260D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_634, "to", ((V)(90D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(220D))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(220D))), "to", ((V)(300D)), NewObj(4).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_634, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Quacks with her head fluff standing up, jumps with her wings out, waddles back a step, eyes darting.")))).Put("squish", Arr(Call(Fn((V _arrowThis641, int _argc635, V _a637, V _a638, V _a639, V _a640, V[] _rest636) => {
V t_642 = default;
t_642 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_642, "to", ((V)(120D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(5).Put("sq", ((V)(0.36))).Put("close", ((V)(1D))).Put("hap", ((V)(0.5))).Put("mw", ((V)(0.6))).Put("open", ((V)(0.3))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "wait", ((V)(280D)));
Invoke(t_642, "to", ((V)(60D)), NewObj(4).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).V, ((V)("o")));
Call(jump_23, V.Undef, t_642, NewObj(6).Put("h", ((V)(10D))).Put("ant", ((V)(40D))).Put("up", ((V)(210D))).Put("c", ((V)(0.34))).Put("arm", ((V)(90D))).Put("st", ((V)(1.25))).V);
Call(quack_37, V.Undef, t_642);
return Call(loopN_31, V.Undef, t_642);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed like a squeaky bath toy - squeak! - let go and she bounces up with a quack.")))).Put("quirk", Arr(Call(Fn((V _arrowThis649, int _argc643, V _a645, V _a646, V _a647, V _a648, V[] _rest644) => {
V t_650 = default;
t_650 = Call(TL_17, V.Undef);
Invoke(Invoke(t_650, "to", ((V)(110D)), NewObj(1).Put("ly", ((V)(0.9))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("pitch", ((V)((-0.22)))).V, ((V)("io")));
{
double i_651 = 0;
i_651 = 0D;
while (true) {
if (!((i_651 < 4D))) break;
V f_653 = default;
f_653 = ((V)((NumTruthy((i_651 % 2D)) ? "footL" : "footR")));
Invoke(Invoke(Invoke(Invoke(t_650, "to", ((V)(140D)), NewObj(3).PutK(f_653, ((V)(3.5))).Put("tilt", ((V)((NumTruthy((i_651 % 2D)) ? (-4D) : 4D)))).Put("sq", ((V)((-0.03)))).V, ((V)("o"))), "to", ((V)(90D)), NewObj(2).PutK(f_653, ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("splash")), ((V)("body")), ((V)(2D))), "to", ((V)(120D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
i_651++;
}
}
Invoke(Invoke(Invoke(t_650, "to", ((V)(260D)), NewObj(6).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("tilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(5D)), NewObj(2).Put("wag", ((V)(30D))).Put("sq", ((V)(0.03))).V, NewObj(2).Put("wag", ((V)((-30D)))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(2).Put("wag", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_650, "wait", ((V)(200D))), "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Puddle stomp")), ((V)("Spots a puddle and stomps in it - splash, splash, splash, splash - then giggles with her tail waggling.")))).Put("press", NewObj(4).Put("sq", ((V)(0.18))).Put("close", ((V)(1D))).Put("mw", ((V)(0.6))).Put("open", ((V)(0.25))).V).Put("rel", NewObj(2).Put("dur", ((V)(1000D))).Put("k", NewObj(8).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(240D)), ((V)(11D)), ((V)("o"))), Arr(((V)(480D)), ((V)(0D)), ((V)("i"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.18))), Arr(((V)(60D)), ((V)((-0.16))), ((V)("o"))), Arr(((V)(240D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(420D)), ((V)((-0.08))), ((V)("i"))), Arr(((V)(500D)), ((V)(0.16)), ((V)("o"))), Arr(((V)(660D)), ((V)(0D)), ((V)("io"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(60D)), ((V)(0D)), ((V)("o"))))).Put("mw", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(80D)), ((V)(1D)), ((V)("o"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0.25))), Arr(((V)(520D)), ((V)(0.6)), ((V)("o"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(520D)), ((V)(30D)), ((V)("io"))), Arr(((V)(640D)), ((V)((-30D))), ((V)("io"))), Arr(((V)(760D)), ((V)(20D)), ((V)("io"))), Arr(((V)(880D)), ((V)(0D)), ((V)("io"))))).Put("armL", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(100D)), ((V)("o"))), Arr(((V)(500D)), ((V)(0D)), ((V)("io"))))).Put("armR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(100D)), ((V)("o"))), Arr(((V)(500D)), ((V)(0D)), ((V)("io"))))).V).V).Put("look", Call(Fn((V _arrowThis660, int _argc654, V _a656, V _a657, V _a658, V _a659, V[] _rest655) => {
V t_661 = default;
t_661 = Call(TL_17, V.Undef);
Call(look_24, V.Undef, t_661, ((V)(0D)), ((V)((-0.6))), NewObj(1).Put("k", ((V)(0.8))).V);
Invoke(t_661, "wait", ((V)(500D)));
Call(look_24, V.Undef, t_661, ((V)((-0.6))), ((V)(0.6)), NewObj(1).Put("k", ((V)(0.8))).V);
Invoke(Invoke(t_661, "osc", ((V)(500D)), ((V)(3D)), NewObj(1).Put("wag", ((V)(20D))).V, NewObj(1).Put("wag", ((V)((-20D)))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).Put("wag", ((V)(0D))).V);
Invoke(t_661, "wait", ((V)(300D)));
Call(look_24, V.Undef, t_661, ((V)(0.6)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.8))).V);
return Invoke(Invoke(t_661, "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).Put("bean", NewObj(7).Put("happy", Arr(Call(Fn((V _arrowThis668, int _argc662, V _a664, V _a665, V _a666, V _a667, V[] _rest663) => {
V t_669 = default;
t_669 = Call(TL_17, V.Undef, NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("tongue", ((V)(0.5))).Put("open", ((V)(0.25))).V);
Call(snort_39, V.Undef, t_669, ((V)(2D)));
Call(swing_26, V.Undef, t_669, ((V)(1400D)), ((V)(7D)), NewObj(4).Put("x", ((V)(1.4))).Put("tilt", ((V)(4D))).Put("wag", ((V)(40D))).Put("bend", ((V)(2D))).V);
Call(jump_23, V.Undef, t_669, NewObj(5).Put("h", ((V)(5D))).Put("ant", ((V)(140D))).Put("up", ((V)(170D))).Put("c", ((V)(0.14))).Put("arm", ((V)(30D))).V);
Call(snort_39, V.Undef, t_669, ((V)(1D)));
return Call(loopN_31, V.Undef, Invoke(t_669, "rest", ((V)(250D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Tongue out, two happy snorts, a big butt wiggle with his curly tail going, a little hop.")))).Put("surprised", Arr(Call(Fn((V _arrowThis676, int _argc670, V _a672, V _a673, V _a674, V _a675, V[] _rest671) => {
V t_677 = default;
t_677 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_677, "wait", ((V)(120D))), "to", ((V)(70D)), NewObj(4).Put("wide", ((V)(1D))).Put("earL", ((V)((-12D)))).Put("earR", ((V)((-12D)))).Put("sq", ((V)(0.04))).V, ((V)("o"))), "wait", ((V)(250D)));
Invoke(Invoke(Invoke(Invoke(t_677, "to", ((V)(320D)), NewObj(3).Put("htilt", ((V)(16D))).Put("hyaw", ((V)(0.1))).Put("lx", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(380D)), NewObj(3).Put("htilt", ((V)((-16D)))).Put("hyaw", ((V)((-0.1)))).Put("lx", ((V)((-0.3)))).V, ((V)("io"))), "wait", ((V)(400D)));
Invoke(t_677, "to", ((V)(260D)), NewObj(3).Put("htilt", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("io")));
Call(snort_39, V.Undef, t_677, ((V)(2D)));
Invoke(t_677, "to", ((V)(300D)), NewObj(4).Put("wide", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_677, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Eyes bulge and his ears perk up, a big puzzled pug head tilt one way, then the other, then two snorts.")))).Put("squish", Arr(Call(Fn((V _arrowThis684, int _argc678, V _a680, V _a681, V _a682, V _a683, V[] _rest679) => {
V t_685 = default;
t_685 = Call(TL_17, V.Undef);
Invoke(Invoke(t_685, "to", ((V)(120D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.3))).Put("close", ((V)(0.8))).Put("puff", ((V)(0.6))).Put("mw", ((V)(0.7))).V, ((V)("io")));
Call(snort_39, V.Undef, t_685, ((V)(1D)));
Invoke(t_685, "wait", ((V)(200D)));
Invoke(t_685, "to", ((V)(60D)), NewObj(6).Put("close", ((V)(0D))).Put("puff", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("tongue", ((V)(0.6))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jump_23, V.Undef, t_685, NewObj(5).Put("h", ((V)(8D))).Put("ant", ((V)(40D))).Put("up", ((V)(200D))).Put("c", ((V)(0.3))).Put("arm", ((V)(40D))).V);
Call(swing_26, V.Undef, t_685, ((V)(700D)), ((V)(3D)), NewObj(2).Put("wag", ((V)(36D))).Put("x", ((V)(1D))).V);
Invoke(t_685, "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(0D))).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_31, V.Undef, t_685);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squished, all his wrinkles bunch up and he snorts; let go and he bounces with his tongue out, tail wiggling.")))).Put("quirk", Arr(Call(Fn((V _arrowThis692, int _argc686, V _a688, V _a689, V _a690, V _a691, V[] _rest687) => {
V t_693 = default;
t_693 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_693, "to", ((V)(120D)), NewObj(2).Put("lx", ((V)(0.8))).Put("ly", ((V)((-0.3)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(3).Put("earL", ((V)((-12D)))).Put("earR", ((V)((-12D)))).Put("hyaw", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(300D)));
Invoke(Invoke(Invoke(Invoke(t_693, "to", ((V)(320D)), NewObj(1).Put("htilt", ((V)(18D))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(360D)), NewObj(2).Put("htilt", ((V)((-12D)))).Put("hyaw", ((V)(0.25))).V, ((V)("io"))), "wait", ((V)(400D)));
Invoke(t_693, "to", ((V)(200D)), NewObj(6).Put("htilt", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_693, "to", ((V)(120D)), NewObj(4).Put("pitch", ((V)(0.12))).Put("close", ((V)(0.6))).Put("mw", ((V)(0.7))).Put("sq", ((V)((-0.03)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(4).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(1).Put("sq", ((V)(0D))).V);
Call(snort_39, V.Undef, t_693, ((V)(2D)));
Invoke(Invoke(Invoke(t_693, "to", ((V)(160D)), NewObj(3).Put("tongue", ((V)(0.7))).Put("open", ((V)(0.2))).Put("hap", ((V)(1D))).V, ((V)("o"))), "wait", ((V)(600D))), "to", ((V)(200D)), NewObj(3).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_693, "wait", ((V)(200D))), "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Head tilt")), ((V)("Hears something - a puzzled head tilt, then the other way - a big pug snort, and he forgets his tongue sticking out.")))).Put("press", NewObj(4).Put("sq", ((V)(0.14))).Put("puff", ((V)(0.5))).Put("close", ((V)(0.7))).Put("mw", ((V)(0.7))).V).Put("rel", NewObj(2).Put("dur", ((V)(1000D))).Put("k", NewObj(8).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(240D)), ((V)(9D)), ((V)("o"))), Arr(((V)(480D)), ((V)(0D)), ((V)("i"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.14))), Arr(((V)(60D)), ((V)((-0.14))), ((V)("o"))), Arr(((V)(240D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(420D)), ((V)((-0.06))), ((V)("i"))), Arr(((V)(500D)), ((V)(0.14)), ((V)("o"))), Arr(((V)(660D)), ((V)(0D)), ((V)("io"))))).Put("puff", Arr(Arr(((V)(0D)), ((V)(0.5))), Arr(((V)(60D)), ((V)(0D)), ((V)("o"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0.7))), Arr(((V)(60D)), ((V)(0D)), ((V)("o"))))).Put("mw", Arr(Arr(((V)(0D)), ((V)(0.7))), Arr(((V)(80D)), ((V)(1D)), ((V)("o"))))).Put("tongue", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0.7)), ((V)("o"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0.3)), ((V)("o"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(500D)), ((V)(36D)), ((V)("io"))), Arr(((V)(620D)), ((V)((-36D))), ((V)("io"))), Arr(((V)(740D)), ((V)(30D)), ((V)("io"))), Arr(((V)(860D)), ((V)(0D)), ((V)("io"))))).V).V).Put("look", Call(Fn((V _arrowThis700, int _argc694, V _a696, V _a697, V _a698, V _a699, V[] _rest695) => {
V t_701 = default;
t_701 = Call(TL_17, V.Undef);
Call(look_24, V.Undef, t_701, ((V)(0D)), ((V)((-0.55))), NewObj(1).Put("k", ((V)(0.8))).V);
Invoke(Invoke(Invoke(t_701, "to", ((V)(260D)), NewObj(1).Put("htilt", ((V)(8D))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(260D)), NewObj(1).Put("htilt", ((V)(0D))).V, ((V)("io")));
Call(look_24, V.Undef, t_701, ((V)((-0.55))), ((V)(0.55)), NewObj(1).Put("k", ((V)(0.8))).V);
Invoke(t_701, "wait", ((V)(500D)));
Call(look_24, V.Undef, t_701, ((V)(0.55)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.8))).V);
return Invoke(Invoke(t_701, "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).Put("zippy", NewObj(7).Put("happy", Arr(Call(Fn((V _arrowThis708, int _argc702, V _a704, V _a705, V _a706, V _a707, V[] _rest703) => {
V t_709 = default;
t_709 = Call(TL_17, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Call(dook_40, V.Undef, t_709, ((V)(3D)));
Invoke(t_709, "wait", ((V)(100D)));
Call(dook_40, V.Undef, t_709, ((V)(4D)));
Invoke(Invoke(t_709, "osc", ((V)(800D)), ((V)(4D)), NewObj(2).Put("wag", ((V)(32D))).Put("x", ((V)(0.8))).V, NewObj(2).Put("wag", ((V)((-32D)))).Put("x", ((V)((-0.8)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(3).Put("wag", ((V)(0D))).Put("x", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_31, V.Undef, Invoke(t_709, "rest", ((V)(250D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Happy ferret chuckles - dook dook dook - bouncing on the spot, his long tail swishing.")))).Put("surprised", Arr(Call(Fn((V _arrowThis716, int _argc710, V _a712, V _a713, V _a714, V _a715, V[] _rest711) => {
V t_717 = default;
t_717 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_717, "wait", ((V)(100D))), "to", ((V)(70D)), NewObj(5).Put("wide", ((V)(1D))).Put("sq", ((V)((-0.12)))).Put("lift", ((V)(2D))).Put("bend", ((V)((-3D)))).Put("wag", ((V)(20D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)((-0.06)))).V, ((V)("i")));
Call(jump_23, V.Undef, t_717, NewObj(8).Put("h", ((V)(6D))).Put("ant", ((V)(60D))).Put("up", ((V)(150D))).Put("c", ((V)(0.08))).Put("arm", ((V)(40D))).Put("x", ((V)((-3D)))).Put("air", NewObj(1).Put("tilt", ((V)((-8D)))).V).Put("fall", NewObj(1).Put("tilt", ((V)(0D))).V).V);
Call(jump_23, V.Undef, t_717, NewObj(8).Put("h", ((V)(6D))).Put("ant", ((V)(60D))).Put("up", ((V)(150D))).Put("c", ((V)(0.08))).Put("arm", ((V)(40D))).Put("x", ((V)(0D))).Put("air", NewObj(1).Put("tilt", ((V)(8D))).V).Put("fall", NewObj(1).Put("tilt", ((V)(0D))).V).V);
Invoke(t_717, "to", ((V)(260D)), NewObj(4).Put("bend", ((V)(0D))).Put("wag", ((V)(0D))).Put("wide", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(dook_40, V.Undef, t_717, ((V)(2D)));
Invoke(t_717, "to", ((V)(200D)), NewObj(3).Put("open", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_717, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Arches up tall with his tail puffed, a startled sideways hop and back, then a little dook.")))).Put("squish", Arr(Call(Fn((V _arrowThis724, int _argc718, V _a720, V _a721, V _a722, V _a723, V[] _rest719) => {
V t_725 = default;
t_725 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_725, "to", ((V)(120D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.32))).Put("close", ((V)(0.9))).Put("hap", ((V)(0.7))).Put("wag", ((V)(18D))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(60D)), NewObj(3).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("o")));
Call(jump_23, V.Undef, t_725, NewObj(7).Put("h", ((V)(12D))).Put("ant", ((V)(40D))).Put("up", ((V)(230D))).Put("c", ((V)(0.32))).Put("arm", ((V)(60D))).Put("st", ((V)(1.3))).Put("spin", ((V)(360D))).V);
Call(dook_40, V.Undef, t_725, ((V)(2D)));
Invoke(t_725, "to", ((V)(200D)), NewObj(4).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).Put("wag", ((V)(0D))).V, ((V)("io")));
return Call(loopN_31, V.Undef, t_725);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squished; let go and he boings up with a spin and a dook.")))).Put("quirk", Arr(Call(Fn((V _arrowThis732, int _argc726, V _a728, V _a729, V _a730, V _a731, V[] _rest727) => {
V t_733 = default;
t_733 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_733, "to", ((V)(120D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("hyaw", ((V)((-0.3)))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(120D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("hyaw", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(200D)));
Invoke(Invoke(Invoke(t_733, "to", ((V)(200D)), NewObj(3).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).Put("pitch", ((V)((-0.1)))).V, ((V)("io"))), "to", ((V)(140D)), Call(o_21, V.Undef, Call(both_20, V.Undef, ((V)(12D)), ((V)((-2D)))), NewObj(4).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).Put("x", ((V)(1.5))).Put("sq", ((V)((-0.04)))).V), ((V)("o"))), "to", ((V)(240D)), Call(o_21, V.Undef, Call(both_20, V.Undef, ((V)((-2D))), ((V)(6D))), NewObj(5).Put("armL", ((V)((-20D)))).Put("armR", ((V)((-20D)))).Put("x", ((V)(0D))).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).V), ((V)("io")));
Invoke(Invoke(t_733, "to", ((V)(220D)), NewObj(5).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.5))).Put("ly", ((V)((-0.5)))).Put("pitch", ((V)(0.1))).V, ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("htilt", ((V)(5D))).V, NewObj(1).Put("htilt", ((V)((-5D)))).V, ((V)("io")));
Invoke(t_733, "to", ((V)(300D)), Call(o_21, V.Undef, NOHANDS_22, NewObj(8).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).Put("smile", ((V)(0D))).Put("hap", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).V), ((V)("io")));
return Invoke(Invoke(Invoke(t_733, "wait", ((V)(200D))), "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Sneaky stash")), ((V)("Shifty eyes - anyone looking? - grabs something, hides it behind his back and looks all innocent.")))).Put("press", NewObj(3).Put("sq", ((V)(0.14))).Put("close", ((V)(0.8))).Put("hap", ((V)(0.5))).V).Put("rel", NewObj(2).Put("dur", ((V)(1000D))).Put("k", NewObj(6).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(250D)), ((V)(13D)), ((V)("o"))), Arr(((V)(500D)), ((V)(0D)), ((V)("i"))))).Put("spin", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(500D)), ((V)(360D)), ((V)("io"))), Arr(((V)(501D)), ((V)(0D)), ((V)("l"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.14))), Arr(((V)(60D)), ((V)((-0.18))), ((V)("o"))), Arr(((V)(250D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(430D)), ((V)((-0.08))), ((V)("i"))), Arr(((V)(510D)), ((V)(0.16)), ((V)("o"))), Arr(((V)(680D)), ((V)(0D)), ((V)("io"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0.8))), Arr(((V)(60D)), ((V)(0D)), ((V)("o"))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0.5))), Arr(((V)(60D)), ((V)(1D)), ((V)("o"))), Arr(((V)(900D)), ((V)(0D)), ((V)("io"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(520D)), ((V)(0.4)), ((V)("o"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))).V).V).Put("look", Call(Fn((V _arrowThis740, int _argc734, V _a736, V _a737, V _a738, V _a739, V[] _rest735) => {
V t_741 = default;
t_741 = Call(TL_17, V.Undef);
Call(look_24, V.Undef, t_741, ((V)(0D)), ((V)((-0.6))), NewObj(3).Put("k", ((V)(0.85))).Put("d1", ((V)(140D))).Put("d2", ((V)(170D))).V);
Invoke(t_741, "wait", ((V)(400D)));
Call(look_24, V.Undef, t_741, ((V)((-0.6))), ((V)(0.6)), NewObj(3).Put("k", ((V)(0.85))).Put("d1", ((V)(140D))).Put("d2", ((V)(170D))).V);
Invoke(t_741, "wait", ((V)(400D)));
Call(look_24, V.Undef, t_741, ((V)(0.6)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.85))).V);
return Invoke(Invoke(t_741, "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).Put("mango", NewObj(7).Put("happy", Arr(Call(Fn((V _arrowThis748, int _argc742, V _a744, V _a745, V _a746, V _a747, V[] _rest743) => {
V t_749 = default;
t_749 = Call(TL_17, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Invoke(t_749, "to", ((V)(500D)), NewObj(2).Put("pitch", ((V)(0.1))).Put("sq", ((V)((-0.03)))).V, ((V)("io")));
Call(slowBlink_47, V.Undef, t_749);
Call(swing_26, V.Undef, t_749, ((V)(1800D)), ((V)(3D)), NewObj(3).Put("wag", ((V)(34D))).Put("tilt", ((V)(2D))).Put("x", ((V)(0.6))).V);
Call(bob_33, V.Undef, t_749, ((V)(2D)), ((V)(500D)), ((V)(0.1)));
return Call(loopN_31, V.Undef, Invoke(t_749, "rest", ((V)(400D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Lifts his chin with a big grin, a slow happy blink, waves his tail slowly and gives two chill nods.")))).Put("surprised", Arr(Call(Fn((V _arrowThis756, int _argc750, V _a752, V _a753, V _a754, V _a755, V[] _rest751) => {
V t_757 = default;
t_757 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_757, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(2).Put("wide", ((V)(1D))).Put("sq", ((V)(0.05))).V, ((V)("o"))), "wait", ((V)(300D)));
Invoke(Invoke(t_757, "osc", ((V)(700D)), ((V)(7D)), NewObj(1).Put("wag", ((V)(10D))).V, NewObj(1).Put("wag", ((V)((-6D)))).V, ((V)("l"))), "to", ((V)(100D)), NewObj(1).Put("wag", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_757, "to", ((V)(110D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(350D))), "to", ((V)(110D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(350D))), "to", ((V)(200D)), NewObj(3).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(slowBlink_47, V.Undef, t_757);
return Invoke(Invoke(t_757, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Freezes, the tip of his tail twitches, his eyes slide left and right, then a slow relaxed blink.")))).Put("squish", Arr(Call(Fn((V _arrowThis764, int _argc758, V _a760, V _a761, V _a762, V _a763, V[] _rest759) => {
V t_765 = default;
t_765 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_765, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.03)))).V, ((V)("o"))), "to", ((V)(360D)), NewObj(3).Put("sq", ((V)(0.3))).Put("close", ((V)(1D))).Put("hap", ((V)(0.7))).V, ((V)("io"))), "wait", ((V)(380D)));
Invoke(Invoke(t_765, "to", ((V)(220D)), NewObj(5).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(2D))).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(2).Put("sq", ((V)(0.05))).Put("lift", ((V)(0D))).V, ((V)("i")));
Call(jelly_28, V.Undef, t_765, ((V)(0.05)), ((V)(2D)), ((V)(360D)));
Call(slowBlink_47, V.Undef, t_765);
Invoke(t_765, "to", ((V)(260D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return Call(loopN_31, V.Undef, t_765);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squishes flat; let go and he puffs back up with a big grin and a slow blink.")))).Put("quirk", Arr(Call(Fn((V _arrowThis772, int _argc766, V _a768, V _a769, V _a770, V _a771, V[] _rest767) => {
V t_773 = default;
t_773 = Call(TL_17, V.Undef);
Call(eyeLick_59, V.Undef, t_773, ((V)(1D)));
Invoke(t_773, "wait", ((V)(200D)));
Call(eyeLick_59, V.Undef, t_773, ((V)((-1D))));
Invoke(Invoke(Invoke(t_773, "to", ((V)(240D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("wag", ((V)(26D))).V, NewObj(1).Put("wag", ((V)((-26D)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(3).Put("wag", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_773, "wait", ((V)(200D))), "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Eye lick")), ((V)("Licks his own eyeball - one, then the other (leopard geckos really do that) - then a grin and a lazy tail wave.")))).Put("press", NewObj(3).Put("sq", ((V)(0.12))).Put("close", ((V)(1D))).Put("hap", ((V)(0.6))).V).Put("rel", NewObj(2).Put("dur", ((V)(1100D))).Put("k", NewObj(5).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.12))), Arr(((V)(200D)), ((V)((-0.08))), ((V)("o"))), Arr(((V)(450D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(2D)), ((V)("o"))), Arr(((V)(450D)), ((V)(0D)), ((V)("i"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(300D)), ((V)(0D)), ((V)("io"))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(300D)), ((V)(1D)), ((V)("io"))), Arr(((V)(1000D)), ((V)(0D)), ((V)("io"))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(400D)), ((V)(30D)), ((V)("io"))), Arr(((V)(700D)), ((V)((-30D))), ((V)("io"))), Arr(((V)(1000D)), ((V)(0D)), ((V)("io"))))).V).V).Put("look", Call(Fn((V _arrowThis780, int _argc774, V _a776, V _a777, V _a778, V _a779, V[] _rest775) => {
V t_781 = default;
t_781 = Call(TL_17, V.Undef);
Call(look_24, V.Undef, t_781, ((V)(0D)), ((V)((-0.55))), NewObj(3).Put("k", ((V)(0.75))).Put("d1", ((V)(220D))).Put("d2", ((V)(260D))).V);
Invoke(t_781, "wait", ((V)(800D)));
Call(look_24, V.Undef, t_781, ((V)((-0.55))), ((V)(0.55)), NewObj(3).Put("k", ((V)(0.75))).Put("d1", ((V)(220D))).Put("d2", ((V)(260D))).V);
Call(slowBlink_47, V.Undef, t_781);
Invoke(t_781, "wait", ((V)(300D)));
Call(look_24, V.Undef, t_781, ((V)(0.55)), ((V)(0D)), NewObj(3).Put("k", ((V)(0.75))).Put("d1", ((V)(220D))).Put("d2", ((V)(260D))).V);
return Invoke(Invoke(t_781, "rest", ((V)(400D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).V;
DANCES_63 = NewObj(9).Put("tilly", Arr(Call(Fn((V _arrowThis788, int _argc782, V _a784, V _a785, V _a786, V _a787, V[] _rest783) => {
V t_789 = default;
double B_790 = 0;
t_789 = Call(TL_17, V.Undef, NewObj(1).Put("smile", ((V)(0.8))).V);
B_790 = 460D;
Invoke(t_789, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
double i_791 = 0;
i_791 = 0D;
while (true) {
if (!((i_791 < 8D))) break;
Invoke(Invoke(t_789, "to", ((V)((B_790 * 0.35))), NewObj(5).Put("pitch", ((V)((-0.16)))).Put("sq", ((V)(0.03))).Put("earL", ((V)((-20D)))).Put("earR", ((V)((-20D)))).Put("x", ((V)(((NumTruthy((i_791 % 2D)) ? 1D : (-1D)) * 0.8)))).V, ((V)("o"))), "to", ((V)((B_790 * 0.65))), NewObj(4).Put("pitch", ((V)(0.04))).Put("sq", ((V)(0D))).Put("earL", ((V)((-4D)))).Put("earR", ((V)((-4D)))).V, ((V)("io")));
if ((i_791 == 3D)) {
Invoke(t_789, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
}
i_791++;
}
}
Invoke(t_789, "to", ((V)(200D)), NewObj(2).Put("x", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_789, "to", ((V)(240D)), NewObj(6).Put("armL", ((V)(100D))).Put("armR", ((V)(100D))).Put("sq", ((V)((-0.04)))).Put("lift", ((V)(1D))).Put("earL", ((V)((-24D)))).Put("earR", ((V)((-24D)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(4).Put("armL", ((V)(92D))).Put("armR", ((V)(92D))).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
Call(swing_26, V.Undef, t_789, ((V)(1600D)), ((V)(3D)), NewObj(3).Put("tilt", ((V)(5D))).Put("x", ((V)(1.5))).Put("htilt", ((V)((-4D)))).V);
Call(chirp_36, V.Undef, t_789);
Call(chirp_36, V.Undef, t_789, ((V)(0.7)));
Invoke(t_789, "to", ((V)(220D)), NewObj(4).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).V, ((V)("io")));
Call(stepTo_43, V.Undef, t_789, Arr(((V)(2D)), ((V)(4D)), ((V)(2D)), ((V)(0D)), ((V)((-2D))), ((V)((-4D))), ((V)((-2D))), ((V)(0D))), ((V)(300D)), ((V)(2.5)));
Invoke(t_789, "to", ((V)(150D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(jump_23, V.Undef, t_789, NewObj(7).Put("h", ((V)(11D))).Put("ant", ((V)(160D))).Put("up", ((V)(290D))).Put("c", ((V)(0.18))).Put("arm", ((V)(120D))).Put("spin", ((V)(360D))).Put("ev", Arr(Arr(((V)("emit")), ((V)("featherY")), ((V)("body")), ((V)(3D))))).V);
Invoke(Invoke(t_789, "osc", ((V)(1000D)), ((V)(6D)), NewObj(2).Put("earL", ((V)((-26D)))).Put("earR", ((V)(6D))).V, NewObj(2).Put("earL", ((V)(6D))).Put("earR", ((V)((-26D)))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Call(chirp_36, V.Undef, t_789);
return Invoke(Invoke(t_789, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Crest Shake Boogie")), ((V)("Bobs her head to the beat with her crest flicking up, opens her wings in a heart and sways, side-steps right and left, a flutter hop with a spin, and shakes her crest from side to side.")))).Put("pico", Arr(Call(Fn((V _arrowThis799, int _argc793, V _a795, V _a796, V _a797, V _a798, V[] _rest794) => {
V t_800 = default;
double B_801 = 0;
t_800 = Call(TL_17, V.Undef, NewObj(2).Put("smile", ((V)(0.8))).Put("hap", ((V)(0.4))).V);
B_801 = 360D;
Invoke(t_800, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
double i_802 = 0;
i_802 = 0D;
while (true) {
if (!((i_802 < 8D))) break;
Invoke(Invoke(t_800, "to", ((V)((B_801 * 0.35))), NewObj(3).Put("pitch", ((V)((-0.18)))).Put("sq", ((V)(0.04))).Put("tilt", ((V)((NumTruthy((i_802 % 2D)) ? 3D : (-3D))))).V, ((V)("o"))), "to", ((V)((B_801 * 0.65))), NewObj(2).Put("pitch", ((V)(0.05))).Put("sq", ((V)(0D))).V, ((V)("io")));
i_802++;
}
}
Invoke(t_800, "to", ((V)(150D)), NewObj(2).Put("tilt", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
{
double i_804 = 0;
i_804 = 0D;
while (true) {
if (!((i_804 < 4D))) break;
V k_806 = default;
V j_807 = default;
k_806 = ((V)((NumTruthy((i_804 % 2D)) ? "armL" : "armR")));
j_807 = ((V)((NumTruthy((i_804 % 2D)) ? "armR" : "armL")));
Invoke(Invoke(t_800, "to", ((V)(140D)), NewObj(3).PutK(k_806, ((V)(110D))).PutK(j_807, ((V)(10D))).Put("htilt", ((V)((NumTruthy((i_804 % 2D)) ? (-6D) : 6D)))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(1).PutK(k_806, ((V)(30D))).V, ((V)("io")));
if (NumTruthy((i_804 % 2D))) {
Invoke(t_800, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
}
i_804++;
}
}
Invoke(t_800, "to", ((V)(150D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io")));
Call(jump_23, V.Undef, t_800, NewObj(8).Put("h", ((V)(6D))).Put("ant", ((V)(110D))).Put("up", ((V)(160D))).Put("c", ((V)(0.12))).Put("arm", ((V)(80D))).Put("x", ((V)(3D))).Put("air", NewObj(1).Put("tilt", ((V)(5D))).V).Put("fall", NewObj(1).Put("tilt", ((V)(0D))).V).V);
Call(jump_23, V.Undef, t_800, NewObj(8).Put("h", ((V)(6D))).Put("ant", ((V)(110D))).Put("up", ((V)(160D))).Put("c", ((V)(0.12))).Put("arm", ((V)(80D))).Put("x", ((V)((-3D)))).Put("air", NewObj(1).Put("tilt", ((V)((-5D)))).V).Put("fall", NewObj(1).Put("tilt", ((V)(0D))).V).V);
Call(jump_23, V.Undef, t_800, NewObj(6).Put("h", ((V)(5D))).Put("ant", ((V)(110D))).Put("up", ((V)(150D))).Put("c", ((V)(0.1))).Put("arm", ((V)(60D))).Put("x", ((V)(0D))).V);
Call(flutter_42, V.Undef, t_800, ((V)(12D)), ((V)(900D)), ((V)(6D)), NewObj(1).Put("spin", ((V)(360D))).V);
Invoke(Invoke(t_800, "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "e", ((V)("emit")), ((V)("featherG")), ((V)("body")), ((V)(3D)));
Invoke(Invoke(t_800, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "osc", ((V)(900D)), ((V)(6D)), NewObj(3).Put("open", ((V)(0.45))).Put("mw", ((V)(0.6))).Put("pitch", ((V)(0.06))).V, NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("o")));
Call(bob_33, V.Undef, t_800, ((V)(3D)), ((V)(220D)), ((V)(0.18)));
return Invoke(Invoke(t_800, "rest", ((V)(250D))), "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Birdie Bop")), ((V)("Bops his head super fast to the beat, flaps one wing then the other, hops right, left and home, flutters up with a spin, then chatters and bobs.")))).Put("clover", Arr(Call(Fn((V _arrowThis814, int _argc808, V _a810, V _a811, V _a812, V _a813, V[] _rest809) => {
V t_815 = default;
t_815 = Call(TL_17, V.Undef, NewObj(1).Put("smile", ((V)(0.8))).V);
Invoke(t_815, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
double i_816 = 0;
i_816 = 0D;
while (true) {
if (!((i_816 < 4D))) break;
Call(jump_23, V.Undef, t_815, NewObj(8).Put("h", ((V)(5D))).Put("ant", ((V)(110D))).Put("up", ((V)(150D))).Put("c", ((V)(0.12))).Put("arm", ((V)(15D))).Put("x", GetIdx(Arr(((V)(2D)), ((V)(0D)), ((V)((-2D))), ((V)(0D))), i_816)).Put("air", NewObj(2).Put("earL", ((V)(20D))).Put("earR", ((V)(20D))).V).Put("fall", NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V).V);
i_816++;
}
}
Call(binky_45, V.Undef, t_815, ((V)(1D)), ((V)(13D)));
Call(binky_45, V.Undef, t_815, ((V)((-1D))), ((V)(14D)));
Invoke(t_815, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
Call(twitch_41, V.Undef, t_815, ((V)(3D)));
Invoke(Invoke(Invoke(t_815, "to", ((V)(320D)), NewObj(8).Put("tilt", ((V)(26D))).Put("sq", ((V)(0.22))).Put("lift", ((V)((-1D)))).Put("close", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("earL", ((V)((-10D)))).Put("earR", ((V)(26D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(900D)));
Invoke(Invoke(t_815, "to", ((V)(200D)), NewObj(4).Put("tilt", ((V)(8D))).Put("sq", ((V)(0.06))).Put("lift", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(5).Put("tilt", ((V)(0D))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
Call(headShake_60, V.Undef, t_815, ((V)(0.8)));
Call(jump_23, V.Undef, t_815, NewObj(8).Put("h", ((V)(15D))).Put("ant", ((V)(170D))).Put("up", ((V)(270D))).Put("c", ((V)(0.2))).Put("arm", ((V)(30D))).Put("spin", ((V)(360D))).Put("air", NewObj(2).Put("earL", ((V)(30D))).Put("earR", ((V)(30D))).V).Put("fall", NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V).V);
return Invoke(Invoke(t_815, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Bunny Hop")), ((V)("Little bunny hops forward and back, two twisting binkies, a nose twitch, the happy bunny flop onto her side, back up with an ear shake, and a big spinning binky.")))).Put("chilla", Arr(Call(Fn((V _arrowThis824, int _argc818, V _a820, V _a821, V _a822, V _a823, V[] _rest819) => {
V t_825 = default;
t_825 = Call(TL_17, V.Undef, NewObj(4).Put("dbb", ((V)(1D))).Put("lift", ((V)((-2.5)))).Put("sq", ((V)(0.1))).Put("smile", ((V)(0.8))).V);
Call(flopIn_53, V.Undef, t_825);
Call(rolls_54, V.Undef, t_825, ((V)(Round((10000D / 170D)))), ((V)(170D)), ((V)(1D)));
Call(rollUp_55, V.Undef, Invoke(t_825, "wait", ((V)(260D))));
Call(dustOff_57, V.Undef, t_825, ((V)(520D)));
Call(shake_25, V.Undef, t_825, NewObj(8).Put("P", ((V)(85D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.85)), ((V)(0.5)), ((V)(0.25)))).Put("head", ((V)(0.3))).Put("roll", ((V)(5D))).Put("ear", ((V)(12D))).Put("chest", ((V)(0.1))).Put("body", ((V)(0.6))).Put("tail", ((V)(30D))).V);
Invoke(Invoke(Invoke(t_825, "e", ((V)("emit")), ((V)("poof")), ((V)("head")), ((V)(2D))), "e", ((V)("emit")), ((V)("poof")), ((V)("sideL")), ((V)(1D))), "e", ((V)("emit")), ((V)("poof")), ((V)("sideR")), ((V)(1D)));
Call(jump_23, V.Undef, t_825, NewObj(6).Put("h", ((V)(7D))).Put("ant", ((V)(130D))).Put("up", ((V)(200D))).Put("c", ((V)(0.12))).Put("arm", ((V)(45D))).Put("ev", Arr(Arr(((V)("emit")), ((V)("dustbath")), Arr(((V)(36D)), ((V)(83D))), ((V)(2D))), Arr(((V)("emit")), ((V)("dustbath")), Arr(((V)(64D)), ((V)(83D))), ((V)(2D))), Arr(((V)("emit")), ((V)("note")), ((V)("head")), ((V)(1D))))).V);
Invoke(t_825, "to", ((V)(220D)), NewObj(2).Put("lift", ((V)((-2.5)))).Put("sq", ((V)(0.1))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_825, "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(350D))), "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(0D))).Put("open", ((V)(0D))).Put("smile", ((V)(0.8))).V, ((V)("io")));
return Invoke(Invoke(t_825, "rest", ((V)(200D))), "loop", NewObj(2).Put("stretch", ((V)(0.3))).Put("soft", ((V)(0.45))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Dust Bath Roll")), ((V)("A big wooden tub of dust stays out the whole dance: she flops right over onto her side in it and rolls - over onto her back with her feet in the air and back over onto her other side, left and right really fast, non stop for 10 seconds, a cloud of dust rising over the tub; then she rolls back up, shakes the dust off, does a happy hop and flops straight back down to go again - over and over until you stop her.")))).Put("mimi", Arr(Call(Fn((V _arrowThis832, int _argc826, V _a828, V _a829, V _a830, V _a831, V[] _rest827) => {
V t_833 = default;
V H_834 = default;
t_833 = Call(TL_17, V.Undef, NewObj(1).Put("smile", ((V)(0.8))).V);
H_834 = Call(both_20, V.Undef, ((V)(4D)), ((V)((-10D))));
Invoke(Invoke(t_833, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(220D)), Call(o_21, V.Undef, H_834, NewObj(2).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V), ((V)("io")));
Call(stepTo_43, V.Undef, t_833, Arr(((V)(1.5)), ((V)(3D)), ((V)(1.5)), ((V)(0D)), ((V)((-1.5))), ((V)((-3D))), ((V)((-1.5))), ((V)(0D))), ((V)(240D)), ((V)(2D)), NewObj(1).Put("wag", ((V)(0D))).V);
Invoke(Invoke(t_833, "osc", ((V)(700D)), ((V)(4D)), NewObj(2).Put("wag", ((V)(30D))).Put("x", ((V)(0.6))).V, NewObj(2).Put("wag", ((V)((-30D)))).Put("x", ((V)((-0.6)))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(2).Put("wag", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
Call(squeak_38, V.Undef, t_833);
Invoke(t_833, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
Invoke(Invoke(t_833, "to", ((V)(900D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Call(para_32, V.Undef, t_833, ((V)((ToNum(Get(t_833, "t")) - 900D))), Fn((V _arrowThis842, int _argc835, V u_841, V _a838, V _a839, V _a840, V[] _rest836) => {
return Call(steps_27, V.Undef, u_841, ((V)(900D)), ((V)(4D)), ((V)(2D)));
}, 1, "", true));
Invoke(t_833, "to", ((V)(220D)), Call(o_21, V.Undef, NOHANDS_22, NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(1.2))).V), ((V)("o")));
{
double i_843 = 0;
i_843 = 0D;
while (true) {
if (!((i_843 < 3D))) break;
Invoke(Invoke(t_833, "to", ((V)(90D)), Call(both_20, V.Undef, ((V)(2D)), ((V)((-6D)))), ((V)("o"))), "to", ((V)(110D)), Call(both_20, V.Undef, ((V)(6D)), ((V)((-4D)))), ((V)("io")));
i_843++;
}
}
Invoke(t_833, "to", ((V)(220D)), Call(o_21, V.Undef, H_834, NewObj(2).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V), ((V)("io")));
Call(squeak_38, V.Undef, t_833);
return Invoke(Invoke(t_833, "rest", ((V)(250D))), "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Cheese Shuffle")), ((V)("Paws together, a tiny shuffle to the right and to the left, a tail swish and a squeak, a twirl on the spot, then up on her tiptoes clapping.")))).Put("puddles", Arr(Call(Fn((V _arrowThis851, int _argc845, V _a847, V _a848, V _a849, V _a850, V[] _rest846) => {
V t_852 = default;
t_852 = Call(TL_17, V.Undef, NewObj(1).Put("smile", ((V)(0.8))).V);
Invoke(t_852, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
Call(waddle_44, V.Undef, t_852, Arr(((V)(1.5)), ((V)(3D)), ((V)(4.5)), ((V)(3D)), ((V)(1.5)), ((V)(0D)), ((V)((-1.5))), ((V)((-3D))), ((V)((-4.5))), ((V)((-3D))), ((V)((-1.5))), ((V)(0D))), ((V)(280D)));
Call(flap_35, V.Undef, t_852, ((V)(3D)), ((V)(260D)), ((V)(105D)));
Invoke(t_852, "to", ((V)(150D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(quack_37, V.Undef, t_852);
Call(jump_23, V.Undef, t_852, NewObj(7).Put("h", ((V)(11D))).Put("ant", ((V)(170D))).Put("up", ((V)(250D))).Put("c", ((V)(0.2))).Put("arm", ((V)(110D))).Put("land", NewObj(1).Put("sq", ((V)(0.3))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("splash")), ((V)("body")), ((V)(2D))), Arr(((V)("emit")), ((V)("splash")), ((V)("body")), ((V)(2D))))).V);
Invoke(Invoke(Invoke(t_852, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(900D)), ((V)(7D)), NewObj(3).Put("wag", ((V)(34D))).Put("x", ((V)(0.8))).Put("tilt", ((V)(3D))).V, NewObj(3).Put("wag", ((V)((-34D)))).Put("x", ((V)((-0.8)))).Put("tilt", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(3).Put("wag", ((V)(0D))).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_852, "to", ((V)(900D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Call(para_32, V.Undef, t_852, ((V)((ToNum(Get(t_852, "t")) - 900D))), Fn((V _arrowThis860, int _argc853, V u_859, V _a856, V _a857, V _a858, V[] _rest854) => {
return Call(steps_27, V.Undef, u_859, ((V)(900D)), ((V)(4D)), ((V)(2D)));
}, 1, "", true));
Call(quack_37, V.Undef, t_852);
Call(quack_37, V.Undef, t_852);
Invoke(t_852, "to", ((V)(150D)), NewObj(1).Put("hap", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_852, "rest", ((V)(250D))), "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Puddle Splash")), ((V)("Waddles right and left, flaps her wings and quacks, jumps into a puddle with a big splash, wiggles her tail feathers, a spin and two quacks.")))).Put("bean", Arr(Call(Fn((V _arrowThis867, int _argc861, V _a863, V _a864, V _a865, V _a866, V[] _rest862) => {
V t_868 = default;
t_868 = Call(TL_17, V.Undef, NewObj(3).Put("smile", ((V)(0.8))).Put("tongue", ((V)(0.5))).Put("open", ((V)(0.2))).V);
Invoke(t_868, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
Call(swing_26, V.Undef, t_868, ((V)(1600D)), ((V)(7D)), NewObj(4).Put("x", ((V)(1.6))).Put("tilt", ((V)(5D))).Put("wag", ((V)(42D))).Put("bend", ((V)(2D))).V);
Call(snort_39, V.Undef, t_868, ((V)(2D)));
Invoke(Invoke(Invoke(t_868, "to", ((V)(260D)), NewObj(6).Put("pitch", ((V)((-0.25)))).Put("sq", ((V)(0.12))).Put("lift", ((V)((-0.6)))).Put("armL", ((V)((-20D)))).Put("armR", ((V)((-20D)))).Put("wag", ((V)(30D))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(4D)), NewObj(1).Put("wag", ((V)((-40D)))).V, NewObj(1).Put("wag", ((V)(40D))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(6).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("wag", ((V)(0D))).V, ((V)("io")));
{
double i_869 = 0;
i_869 = 0D;
while (true) {
if (!((i_869 < 2D))) break;
Invoke(t_868, "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(2D)));
Invoke(Invoke(t_868, "to", ((V)(700D)), NewObj(2).Put("spin", ((V)(360D))).Put("tilt", ((V)(6D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Call(para_32, V.Undef, t_868, ((V)((ToNum(Get(t_868, "t")) - 700D))), Fn((V _arrowThis878, int _argc871, V u_877, V _a874, V _a875, V _a876, V[] _rest872) => {
return Call(steps_27, V.Undef, u_877, ((V)(700D)), ((V)(4D)), ((V)(2.5)));
}, 1, "", true));
i_869++;
}
}
Invoke(t_868, "to", ((V)(150D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io")));
Call(snort_39, V.Undef, t_868, ((V)(2D)));
Call(jump_23, V.Undef, t_868, NewObj(5).Put("h", ((V)(7D))).Put("ant", ((V)(150D))).Put("up", ((V)(190D))).Put("c", ((V)(0.16))).Put("arm", ((V)(40D))).V);
Invoke(t_868, "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
return Invoke(Invoke(t_868, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Pug Wiggle")), ((V)("A big butt wiggle with his curly tail going, two snorts, a play bow, two rounds of zoomies spinning on the spot, more snorts and a happy hop - tongue out the whole time.")))).Put("zippy", Arr(Call(Fn((V _arrowThis885, int _argc879, V _a881, V _a882, V _a883, V _a884, V[] _rest880) => {
V t_886 = default;
t_886 = Call(TL_17, V.Undef, NewObj(3).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.6))).Put("open", ((V)(0.25))).V);
Invoke(t_886, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
double i_887 = 0;
i_887 = 0D;
while (true) {
if (!((i_887 < 6D))) break;
double d_889 = 0;
d_889 = (NumTruthy((i_887 % 2D)) ? (-1D) : 1D);
Call(jump_23, V.Undef, t_886, NewObj(8).Put("h", ((V)(7D))).Put("ant", ((V)(70D))).Put("up", ((V)(150D))).Put("c", ((V)(0.1))).Put("arm", ((V)(50D))).Put("x", GetIdx(Arr(((V)(4D)), ((V)((-4D))), ((V)(5D)), ((V)((-5D))), ((V)(2D)), ((V)(0D))), i_887)).Put("air", NewObj(3).Put("tilt", ((V)((d_889 * 12D)))).Put("bend", ((V)((-3D)))).Put("wag", ((V)((d_889 * 30D)))).V).Put("fall", NewObj(3).Put("tilt", ((V)(0D))).Put("bend", ((V)(0D))).Put("wag", ((V)(0D))).V).V);
i_887++;
}
}
Call(dook_40, V.Undef, t_886, ((V)(3D)));
Invoke(Invoke(t_886, "to", ((V)(200D)), NewObj(3).Put("sq", ((V)((-0.12)))).Put("lift", ((V)(1D))).Put("bend", ((V)((-4D)))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(3).Put("sq", ((V)(0.08))).Put("lift", ((V)(0D))).Put("bend", ((V)(0D))).V, ((V)("i")));
Call(jump_23, V.Undef, t_886, NewObj(9).Put("h", ((V)(9D))).Put("ant", ((V)(70D))).Put("up", ((V)(170D))).Put("c", ((V)(0.12))).Put("arm", ((V)(50D))).Put("x", ((V)(6D))).Put("air", NewObj(1).Put("tilt", ((V)(18D))).V).Put("fall", NewObj(1).Put("tilt", ((V)(26D))).V).Put("land", NewObj(1).Put("sq", ((V)(0.2))).V).V);
Invoke(Invoke(Invoke(t_886, "to", ((V)(120D)), NewObj(4).Put("x", ((V)(6D))).Put("tilt", ((V)(30D))).Put("close", ((V)(1D))).Put("cross", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(500D))), "to", ((V)(260D)), NewObj(2).Put("tilt", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
Call(headShake_60, V.Undef, t_886, ((V)(0.8)));
Invoke(t_886, "to", ((V)(500D)), NewObj(1).Put("x", ((V)(0D))).V, ((V)("io")));
Call(para_32, V.Undef, t_886, ((V)((ToNum(Get(t_886, "t")) - 500D))), Fn((V _arrowThis897, int _argc890, V u_896, V _a893, V _a894, V _a895, V[] _rest891) => {
return Call(steps_27, V.Undef, u_896, ((V)(500D)), ((V)(2D)), ((V)(2.5)));
}, 1, "", true));
Call(jump_23, V.Undef, t_886, NewObj(6).Put("h", ((V)(12D))).Put("ant", ((V)(120D))).Put("up", ((V)(230D))).Put("c", ((V)(0.18))).Put("arm", ((V)(60D))).Put("spin", ((V)(360D))).V);
Call(dook_40, V.Undef, t_886, ((V)(3D)));
Invoke(t_886, "to", ((V)(150D)), NewObj(1).Put("open", ((V)(0.25))).V, ((V)("io")));
return Invoke(Invoke(t_886, "rest", ((V)(250D))), "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Weasel War Dance")), ((V)("Frantic sideways war-dance hops with his back arched and mouth open, dook dook dook, bonks into an invisible wall and flops over, gets up, shakes it off, then a spinning hop and more dooks.")))).Put("mango", Arr(Call(Fn((V _arrowThis904, int _argc898, V _a900, V _a901, V _a902, V _a903, V[] _rest899) => {
V t_905 = default;
double B_906 = 0;
t_905 = Call(TL_17, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.4))).V);
B_906 = 600D;
Invoke(t_905, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
double i_907 = 0;
i_907 = 0D;
while (true) {
if (!((i_907 < 4D))) break;
V f_909 = default;
f_909 = ((V)((NumTruthy((i_907 % 2D)) ? "footL" : "footR")));
Invoke(Invoke(t_905, "to", ((V)((B_906 * 0.35))), NewObj(3).PutK(f_909, ((V)(2.6))).Put("tilt", ((V)((NumTruthy((i_907 % 2D)) ? (-3D) : 3D)))).Put("wag", ((V)((NumTruthy((i_907 % 2D)) ? (-24D) : 24D)))).V, ((V)("o"))), "to", ((V)((B_906 * 0.65))), NewObj(2).PutK(f_909, ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("i")));
i_907++;
}
}
Call(swing_26, V.Undef, t_905, ((V)(2000D)), ((V)(3D)), NewObj(4).Put("x", ((V)(1.5))).Put("tilt", ((V)(4D))).Put("wag", ((V)(34D))).Put("htilt", ((V)((-3D)))).V);
Call(bob_33, V.Undef, t_905, ((V)(2D)), ((V)(500D)), ((V)(0.1)));
Invoke(Invoke(Invoke(t_905, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "osc", ((V)(800D)), ((V)(10D)), NewObj(1).Put("wag", ((V)(12D))).V, NewObj(1).Put("wag", ((V)((-12D)))).V, ((V)("l"))), "to", ((V)(150D)), NewObj(1).Put("wag", ((V)(0D))).V, ((V)("io")));
Call(eyeLick_59, V.Undef, t_905, ((V)(1D)));
Invoke(Invoke(Invoke(t_905, "to", ((V)(220D)), NewObj(3).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(1.5))).Put("pitch", ((V)(0.12))).V, ((V)("o"))), "wait", ((V)(300D))), "to", ((V)(260D)), NewObj(3).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_905, "to", ((V)(1400D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Call(para_32, V.Undef, t_905, ((V)((ToNum(Get(t_905, "t")) - 1400D))), Fn((V _arrowThis917, int _argc910, V u_916, V _a913, V _a914, V _a915, V[] _rest911) => {
return Call(steps_27, V.Undef, u_916, ((V)(1400D)), ((V)(4D)), ((V)(2D)));
}, 1, "", true));
Call(slowBlink_47, V.Undef, t_905);
return Invoke(Invoke(t_905, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Sticky Toe Tap")), ((V)("Taps his sticky toes left and right, sways slowly with his tail swishing, two chill nods, rattles his tail, licks his eye, stands up proud and does a slow turn on the spot.")))).V;
Invoke(KEYS_8, "forEach", Fn((V _arrowThis925, int _argc918, V k_924, V _a921, V _a922, V _a923, V[] _rest919) => {
Set(GetK(MOVES_62, k_924), "dance", GetK(DANCES_63, k_924));
return default;
}, 1, "", true));
Call(install_30, V.Undef, MOVES_62, CARDS_61);
return default;
}, 0, "boot", false)), V.Undef);
Call(Named(boot_977 => Fn((V _self926, int _argc927, V _a929, V _a930, V _a931, V _a932, V[] _rest928) => {
V R_933 = default;
V S_934 = default;
V o_935 = default;
V jump_936 = default;
V shake_937 = default;
V jelly_938 = default;
V popcorn_939 = default;
V both_940 = default;
V hand_941 = default;
V NOHANDS_942 = default;
V see_943 = default;
V unsee_944 = default;
V giggle_945 = default;
V hmph_946 = default;
V sneeze_947 = default;
V sniff_948 = default;
V lick_949 = default;
V para_950 = default;
V leanIn_951 = default;
V swat_952 = default;
V pawShake_953 = default;
V headShake_954 = default;
V snort_955 = default;
V freeze_956 = default;
V curl_957 = default;
V blushy_958 = default;
V happy_959 = default;
V pat_960 = default;
V smooth_961 = default;
V rub_962 = default;
V build_963 = default;
V chirp_964 = default;
V quack_965 = default;
V squeak_966 = default;
V dook_967 = default;
V twitch_968 = default;
V peck_969 = default;
V crest_970 = default;
V flap_971 = default;
V wagT_972 = default;
V eyeLick_973 = default;
V BODY_974 = default;
V RE_975 = default;
V TXT_976 = default;
if (_self926.IsNullish) _self926 = GlobalV;
R_933 = Get(G("window"), "RiveRig");
if ((((!(Truthy(R_933)) || !(Truthy(Get(R_933, "POKELIB")))) || !(Truthy(Get(R_933, "pet2V")))) || !(Truthy(Get(Get(R_933, "STATES"), "poke_head"))))) {
Call(G("setTimeout"), V.Undef, boot_977.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_933, "pet2PokeV"))) {
return default;
}
Set(R_933, "pet2PokeV", ((V)(1D)));
{ V _t978 = Get(R_933, "PETLIB");
if (_t978.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t978));
{ V _t979 = Get(_t978, "S");
S_934 = _t979; }
{ V _t980 = Get(_t978, "o");
o_935 = _t980; }
{ V _t981 = Get(_t978, "jump");
jump_936 = _t981; }
{ V _t982 = Get(_t978, "shake");
shake_937 = _t982; }
{ V _t983 = Get(_t978, "jelly");
jelly_938 = _t983; }
{ V _t984 = Get(_t978, "popcorn");
popcorn_939 = _t984; }
{ V _t985 = Get(_t978, "both");
both_940 = _t985; }
{ V _t986 = Get(_t978, "hand");
hand_941 = _t986; }
{ V _t987 = Get(_t978, "NOHANDS");
NOHANDS_942 = _t987; } }
{ V _t988 = Get(R_933, "POKELIB");
if (_t988.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t988));
{ V _t989 = Get(_t988, "see");
see_943 = _t989; }
{ V _t990 = Get(_t988, "unsee");
unsee_944 = _t990; }
{ V _t991 = Get(_t988, "giggle");
giggle_945 = _t991; }
{ V _t992 = Get(_t988, "hmph");
hmph_946 = _t992; }
{ V _t993 = Get(_t988, "sneeze");
sneeze_947 = _t993; }
{ V _t994 = Get(_t988, "sniff");
sniff_948 = _t994; }
{ V _t995 = Get(_t988, "lick");
lick_949 = _t995; }
{ V _t996 = Get(_t988, "para");
para_950 = _t996; }
{ V _t997 = Get(_t988, "leanIn");
leanIn_951 = _t997; }
{ V _t998 = Get(_t988, "swat");
swat_952 = _t998; }
{ V _t999 = Get(_t988, "pawShake");
pawShake_953 = _t999; }
{ V _t1000 = Get(_t988, "headShake");
headShake_954 = _t1000; }
{ V _t1001 = Get(_t988, "snort");
snort_955 = _t1001; }
{ V _t1002 = Get(_t988, "freeze");
freeze_956 = _t1002; }
{ V _t1003 = Get(_t988, "curl");
curl_957 = _t1003; }
{ V _t1004 = Get(_t988, "blushy");
blushy_958 = _t1004; }
{ V _t1005 = Get(_t988, "happy");
happy_959 = _t1005; }
{ V _t1006 = Get(_t988, "pat");
pat_960 = _t1006; }
{ V _t1007 = Get(_t988, "smooth");
smooth_961 = _t1007; }
{ V _t1008 = Get(_t988, "rub");
rub_962 = _t1008; }
{ V _t1009 = Get(_t988, "build");
build_963 = _t1009; } }
chirp_964 = Fn((V _arrowThis1018, int _argc1010, V t_1016, V a_1017, V _a1014, V _a1015, V[] _rest1011) => {
return Invoke(Invoke(Invoke(t_1016, "to", ((V)(90D)), NewObj(3).Put("open", ((V)((0.5 * ToNum((a_1017 is var _t1019 && Truthy(_t1019) ? _t1019 : ((V)(1D)))))))).Put("mw", ((V)(0.6))).Put("pitch", ((V)(0.08))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(140D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 2, "", true);
quack_965 = Fn((V _arrowThis1027, int _argc1020, V t_1026, V _a1023, V _a1024, V _a1025, V[] _rest1021) => {
return Invoke(Invoke(Invoke(t_1026, "to", ((V)(90D)), NewObj(3).Put("open", ((V)(0.65))).Put("mw", ((V)(1.1))).Put("pitch", ((V)(0.12))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(170D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
squeak_966 = Fn((V _arrowThis1035, int _argc1028, V t_1034, V _a1031, V _a1032, V _a1033, V[] _rest1029) => {
return Invoke(Invoke(Invoke(t_1034, "to", ((V)(70D)), NewObj(3).Put("open", ((V)(0.4))).Put("mw", ((V)(0.55))).Put("pitch", ((V)(0.1))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(140D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
dook_967 = Fn((V _arrowThis1044, int _argc1036, V t_1042, V n_1043, V _a1040, V _a1041, V[] _rest1037) => {
Invoke(t_1042, "to", ((V)(120D)), NewObj(3).Put("open", ((V)(0.35))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("o")));
{
double i_1045 = 0;
i_1045 = 0D;
while (true) {
if (!(Lt(((V)(i_1045)), (n_1043 is var _t1047 && Truthy(_t1047) ? _t1047 : ((V)(3D)))))) break;
Invoke(Invoke(t_1042, "to", ((V)(80D)), NewObj(2).Put("lift", ((V)(1.6))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(90D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("i")));
i_1045++;
}
}
Invoke(t_1042, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
return Invoke(t_1042, "to", ((V)(160D)), NewObj(4).Put("sq", ((V)(0D))).Put("open", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "", true);
twitch_968 = Fn((V _arrowThis1056, int _argc1048, V t_1054, V n_1055, V _a1052, V _a1053, V[] _rest1049) => {
return Invoke(t_1054, "osc", ((V)((ToNum((n_1055 is var _t1057 && Truthy(_t1057) ? _t1057 : ((V)(3D)))) * 150D))), (n_1055 is var _t1058 && Truthy(_t1058) ? _t1058 : ((V)(3D))), NewObj(2).Put("mw", ((V)(0.7))).Put("pitch", ((V)(0.04))).V, NewObj(2).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("o")));
}, 2, "", true);
peck_969 = Fn((V _arrowThis1067, int _argc1059, V t_1065, V n_1066, V _a1063, V _a1064, V[] _rest1060) => {
{
double i_1068 = 0;
i_1068 = 0D;
while (true) {
if (!(Lt(((V)(i_1068)), (n_1066 is var _t1070 && Truthy(_t1070) ? _t1070 : ((V)(2D)))))) break;
Invoke(Invoke(t_1065, "to", ((V)(90D)), NewObj(3).Put("pitch", ((V)((-0.2)))).Put("sq", ((V)(0.04))).Put("open", ((V)(0.2))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(3).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
i_1068++;
}
}
return t_1065;
return default;
}, 2, "", true);
crest_970 = Fn((V _arrowThis1080, int _argc1071, V t_1077, V v_1078, V d_1079, V _a1076, V[] _rest1072) => {
return Invoke(t_1077, "to", (d_1079 is var _t1081 && Truthy(_t1081) ? _t1081 : ((V)(140D))), NewObj(2).Put("earL", v_1078).Put("earR", v_1078).V, ((V)("o")));
}, 3, "", true);
flap_971 = Fn((V _arrowThis1091, int _argc1082, V t_1088, V n_1089, V A_1090, V _a1087, V[] _rest1083) => {
{
double i_1092 = 0;
i_1092 = 0D;
while (true) {
if (!(Lt(((V)(i_1092)), n_1089))) break;
Invoke(Invoke(t_1088, "to", ((V)(110D)), NewObj(2).Put("armL", A_1090).Put("armR", A_1090).V, ((V)("o"))), "to", ((V)(140D)), NewObj(2).Put("armL", ((V)((ToNum(A_1090) * 0.25)))).Put("armR", ((V)((ToNum(A_1090) * 0.25)))).V, ((V)("io")));
i_1092++;
}
}
return Invoke(t_1088, "to", ((V)(150D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return default;
}, 3, "", true);
wagT_972 = Fn((V _arrowThis1104, int _argc1094, V t_1100, V n_1101, V a_1102, V per_1103, V[] _rest1095) => {
return Invoke(Invoke(t_1100, "osc", ((V)((ToNum((per_1103 is var _t1105 && Truthy(_t1105) ? _t1105 : ((V)(160D)))) * ToNum(n_1101)))), n_1101, NewObj(1).Put("wag", (a_1102 is var _t1106 && Truthy(_t1106) ? _t1106 : ((V)(30D)))).V, NewObj(1).Put("wag", ((V)((-ToNum((a_1102 is var _t1107 && Truthy(_t1107) ? _t1107 : ((V)(30D)))))))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(1).Put("wag", ((V)(0D))).V, ((V)("io")));
}, 4, "", true);
eyeLick_973 = Fn((V _arrowThis1116, int _argc1108, V t_1114, V s_1115, V _a1112, V _a1113, V[] _rest1109) => {
V k_1117 = default;
k_1117 = Call(S_934, V.Undef, s_1115);
return Invoke(Invoke(Invoke(t_1114, "to", ((V)(120D)), NewObj(5).Put("tongue", ((V)(1D))).Put("open", ((V)(0.3))).Put("pitch", ((V)(0.18))).Put("htilt", ((V)((ToNum(s_1115) * 8D)))).PutK(Get(k_1117, "wink"), ((V)(0.8))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("tongue", ((V)(0.7))).PutK(Get(k_1117, "wink"), ((V)(1D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(5).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).PutK(Get(k_1117, "wink"), ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "", true);
BODY_974 = NewObj(9).Put("tilly", NewObj(4).Put("ear", ((V)(1.3))).Put("tail", ((V)(1D))).Put("earTap", Arr(((V)(44D)), ((V)(12D)))).Put("lbl", NewObj(4).Put("ear", Fn((V _arrowThis1125, int _argc1118, V s_1124, V _a1121, V _a1122, V _a1123, V[] _rest1119) => {
return ((V)((LtN(s_1124, 0D) ? "Crest (left)" : "Crest (right)")));
}, 1, "ear", true)).Put("side", ((V)("wing"))).Put("tail", ((V)("Tail feathers"))).Put("nose", ((V)("Beak"))).V).V).Put("pico", NewObj(4).Put("ear", ((V)(0D))).Put("tail", ((V)(1D))).Put("earTap", Arr(((V)(30D)), ((V)(30D)))).Put("lbl", NewObj(4).Put("ear", ((V)("head stripes"))).Put("side", ((V)("wing"))).Put("tail", ((V)("Tail feathers"))).Put("nose", ((V)("Beak"))).V).V).Put("clover", NewObj(4).Put("ear", ((V)(1.3))).Put("tail", ((V)(1D))).Put("earTap", Arr(((V)(39D)), ((V)(13D)))).Put("lbl", NewObj(2).Put("ear", ((V)("long ear"))).Put("tail", ((V)("Cotton tail"))).V).V).Put("chilla", NewObj(3).Put("ear", ((V)(1D))).Put("tail", ((V)(1D))).Put("lbl", NewObj(1).Put("tail", ((V)("Bushy tail"))).V).V).Put("mimi", NewObj(2).Put("ear", ((V)(1.1))).Put("tail", ((V)(1D))).V).Put("puddles", NewObj(4).Put("ear", ((V)(0.5))).Put("tail", ((V)(1D))).Put("earTap", Arr(((V)(49D)), ((V)(15D)))).Put("lbl", NewObj(5).Put("ear", Fn((V _arrowThis1133, int _argc1126, V s_1132, V _a1129, V _a1130, V _a1131, V[] _rest1127) => {
return ((V)((LtN(s_1132, 0D) ? "Head fluff (left)" : "Head fluff (right)")));
}, 1, "ear", true)).Put("side", ((V)("wing"))).Put("foot", ((V)("webbed foot"))).Put("nose", ((V)("Bill"))).Put("tail", ((V)("Tail"))).V).V).Put("bean", NewObj(3).Put("ear", ((V)(0.5))).Put("tail", ((V)(1D))).Put("lbl", NewObj(2).Put("tail", ((V)("Curly tail"))).Put("nose", ((V)("Squishy nose"))).V).V).Put("zippy", NewObj(3).Put("ear", ((V)(0.6))).Put("tail", ((V)(1D))).Put("lbl", NewObj(1).Put("tail", ((V)("Fluffy tail"))).V).V).Put("mango", NewObj(5).Put("ear", ((V)(0D))).Put("tail", ((V)(1D))).Put("noWalk", ((V)(1D))).Put("earTap", Arr(((V)(24D)), ((V)(40D)))).Put("lbl", NewObj(3).Put("ear", ((V)("head side"))).Put("foot", ((V)("sticky toes"))).Put("tail", ((V)("Chunky tail"))).V).V).V;
RE_975 = NewObj(9).Put("tilly", NewObj(9).Put("head", Fn((V _arrowThis1142, int _argc1134, V t_1140, V s_1141, V _a1138, V _a1139, V[] _rest1135) => {
Call(crest_970, V.Undef, t_1140, ((V)((-28D))), ((V)(120D)));
Invoke(t_1140, "wait", ((V)(250D)));
Call(see_943, V.Undef, t_1140, ((V)("head")), ((V)(0D)), ((V)(200D)));
Call(unsee_944, V.Undef, t_1140);
Invoke(Invoke(Invoke(t_1140, "to", ((V)(260D)), NewObj(4).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("close", ((V)(0.6))).Put("hap", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(2D)), NewObj(1).Put("pitch", ((V)((-0.12)))).V, NewObj(1).Put("pitch", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1151, int _argc1143, V t_1149, V s_1150, V _a1147, V _a1148, V[] _rest1144) => {
V k_1152 = default;
k_1152 = Call(S_934, V.Undef, s_1150);
Invoke(Invoke(Invoke(t_1149, "to", ((V)(90D)), NewObj(1).PutK(Get(k_1152, "ear"), ((V)((-34D)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).PutK(Get(k_1152, "ear"), ((V)(10D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).PutK(Get(k_1152, "ear"), ((V)(0D))).V, ((V)("io")));
Call(see_943, V.Undef, t_1149, ((V)("ear")), s_1150, ((V)(200D)));
Call(unsee_944, V.Undef, t_1149);
Call(chirp_964, V.Undef, t_1149, ((V)(0.7)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1161, int _argc1153, V t_1159, V s_1160, V _a1157, V _a1158, V[] _rest1154) => {
Invoke(t_1159, "to", ((V)(200D)), NewObj(1).Put("cross", ((V)(1D))).V, ((V)("io")));
Call(peck_969, V.Undef, t_1159, ((V)(2D)));
Invoke(t_1159, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io")));
Call(chirp_964, V.Undef, t_1159);
Invoke(t_1159, "to", ((V)(200D)), NewObj(1).Put("hap", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1170, int _argc1162, V t_1168, V s_1169, V _a1166, V _a1167, V[] _rest1163) => {
V k_1171 = default;
k_1171 = Call(S_934, V.Undef, s_1169);
Invoke(Invoke(Invoke(t_1168, "to", ((V)(200D)), NewObj(3).PutK(Get(k_1171, "wink"), ((V)(1D))).Put("earL", ((V)(16D))).Put("earR", ((V)(16D))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(200D)), NewObj(3).PutK(Get(k_1171, "wink"), ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Call(headShake_954, V.Undef, t_1168, ((V)(0.7)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1180, int _argc1172, V t_1178, V s_1179, V _a1176, V _a1177, V[] _rest1173) => {
Call(leanIn_951, V.Undef, t_1178, s_1179, NewObj(2).Put("earL", ((V)(14D))).Put("earR", ((V)(14D))).V);
Invoke(t_1178, "to", ((V)(200D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1189, int _argc1181, V t_1187, V s_1188, V _a1185, V _a1186, V[] _rest1182) => {
Invoke(t_1187, "to", ((V)(150D)), NewObj(3).Put("sq", ((V)(0.14))).Put("earL", ((V)(18D))).Put("earR", ((V)(18D))).V, ((V)("o")));
Call(giggle_945, V.Undef, t_1187, ((V)(3D)));
Invoke(t_1187, "to", ((V)(200D)), NewObj(3).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1198, int _argc1190, V t_1196, V s_1197, V _a1194, V _a1195, V[] _rest1191) => {
V k_1199 = default;
k_1199 = Call(S_934, V.Undef, s_1197);
Invoke(Invoke(Invoke(t_1196, "to", ((V)(100D)), NewObj(1).PutK(Get(k_1199, "arm"), ((V)(80D))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).PutK(Get(k_1199, "arm"), ((V)(20D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("featherY")), ((V)("body")), ((V)(1D)));
Call(see_943, V.Undef, t_1196, ((V)("side")), s_1197, ((V)(200D)));
Call(unsee_944, V.Undef, t_1196);
Invoke(t_1196, "to", ((V)(150D)), NewObj(1).PutK(Get(k_1199, "arm"), ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1208, int _argc1200, V t_1206, V s_1207, V _a1204, V _a1205, V[] _rest1201) => {
V k_1209 = default;
k_1209 = Call(S_934, V.Undef, s_1207);
Invoke(Invoke(t_1206, "to", ((V)(120D)), NewObj(2).PutK(Get(k_1209, "foot"), ((V)(3D))).Put("lift", ((V)(1D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).PutK(Get(k_1209, "foot"), ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("i")));
Call(see_943, V.Undef, t_1206, ((V)("foot")), s_1207, ((V)(200D)));
Call(unsee_944, V.Undef, t_1206);
Call(chirp_964, V.Undef, t_1206, ((V)(0.5)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1218, int _argc1210, V t_1216, V s_1217, V _a1214, V _a1215, V[] _rest1211) => {
Call(wagT_972, V.Undef, t_1216, ((V)(3D)), ((V)(24D)));
Call(see_943, V.Undef, t_1216, ((V)("tail")), ((V)(1D)), ((V)(300D)));
Call(unsee_944, V.Undef, t_1216);
Call(crest_970, V.Undef, t_1216, ((V)((-18D))), ((V)(140D)));
Invoke(t_1216, "to", ((V)(250D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "tail", true)).V).Put("pico", NewObj(9).Put("head", Fn((V _arrowThis1227, int _argc1219, V t_1225, V s_1226, V _a1223, V _a1224, V[] _rest1220) => {
Invoke(Invoke(t_1225, "to", ((V)(80D)), NewObj(1).Put("sq", ((V)(0.1))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(see_943, V.Undef, t_1225, ((V)("head")), ((V)(0D)), ((V)(150D)));
Call(unsee_944, V.Undef, t_1225);
Call(chirp_964, V.Undef, t_1225);
Call(chirp_964, V.Undef, t_1225, ((V)(0.6)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1236, int _argc1228, V t_1234, V s_1235, V _a1232, V _a1233, V[] _rest1229) => {
Call(see_943, V.Undef, t_1234, ((V)("ear")), s_1235, ((V)(100D)));
Invoke(t_1234, "osc", ((V)(600D)), ((V)(4D)), NewObj(1).Put("htilt", ((V)((ToNum(s_1235) * 10D)))).V, NewObj(1).Put("htilt", ((V)((ToNum(s_1235) * 4D)))).V, ((V)("io")));
Call(unsee_944, V.Undef, t_1234);
Call(chirp_964, V.Undef, t_1234, ((V)(0.7)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1245, int _argc1237, V t_1243, V s_1244, V _a1241, V _a1242, V[] _rest1238) => {
Invoke(t_1243, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(1D))).V, ((V)("io")));
Call(peck_969, V.Undef, t_1243, ((V)(3D)));
Invoke(t_1243, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(0D))).V, ((V)("io")));
Invoke(t_1243, "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
Call(chirp_964, V.Undef, t_1243);
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1254, int _argc1246, V t_1252, V s_1253, V _a1250, V _a1251, V[] _rest1247) => {
V k_1255 = default;
k_1255 = Call(S_934, V.Undef, s_1253);
Invoke(Invoke(Invoke(t_1252, "to", ((V)(180D)), NewObj(1).PutK(Get(k_1255, "wink"), ((V)(1D))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(160D)), NewObj(1).PutK(Get(k_1255, "wink"), ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_1252, "to", ((V)(70D)), NewObj(1).Put("hyaw", ((V)(((-ToNum(s_1253)) * 0.4)))).V, ((V)("o"))), "wait", ((V)(150D))), "to", ((V)(90D)), NewObj(1).Put("hyaw", ((V)(0D))).V, ((V)("o")));
Call(chirp_964, V.Undef, t_1252, ((V)(0.6)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1264, int _argc1256, V t_1262, V s_1263, V _a1260, V _a1261, V[] _rest1257) => {
Call(leanIn_951, V.Undef, t_1262, s_1263);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1273, int _argc1265, V t_1271, V s_1272, V _a1269, V _a1270, V[] _rest1266) => {
Invoke(t_1271, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.12))).V, ((V)("o")));
Call(giggle_945, V.Undef, t_1271, ((V)(3D)));
Call(flap_971, V.Undef, t_1271, ((V)(2D)), ((V)(80D)));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1282, int _argc1274, V t_1280, V s_1281, V _a1278, V _a1279, V[] _rest1275) => {
V k_1283 = default;
k_1283 = Call(S_934, V.Undef, s_1281);
Invoke(Invoke(Invoke(t_1280, "to", ((V)(100D)), NewObj(1).PutK(Get(k_1283, "arm"), ((V)(90D))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(1).PutK(Get(k_1283, "arm"), ((V)(15D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("featherG")), ((V)("body")), ((V)(1D)));
Call(see_943, V.Undef, t_1280, ((V)("side")), s_1281, ((V)(150D)));
Call(unsee_944, V.Undef, t_1280);
Invoke(t_1280, "to", ((V)(120D)), NewObj(1).PutK(Get(k_1283, "arm"), ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1292, int _argc1284, V t_1290, V s_1291, V _a1288, V _a1289, V[] _rest1285) => {
V k_1293 = default;
k_1293 = Call(S_934, V.Undef, s_1291);
Invoke(Invoke(t_1290, "to", ((V)(100D)), NewObj(2).PutK(Get(k_1293, "foot"), ((V)(3D))).Put("lift", ((V)(1D))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(2).PutK(Get(k_1293, "foot"), ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("i")));
Call(see_943, V.Undef, t_1290, ((V)("foot")), s_1291, ((V)(150D)));
Call(unsee_944, V.Undef, t_1290);
Call(chirp_964, V.Undef, t_1290, ((V)(0.5)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1302, int _argc1294, V t_1300, V s_1301, V _a1298, V _a1299, V[] _rest1295) => {
Call(wagT_972, V.Undef, t_1300, ((V)(4D)), ((V)(24D)), ((V)(120D)));
Call(see_943, V.Undef, t_1300, ((V)("tail")), ((V)(1D)), ((V)(200D)));
Call(unsee_944, V.Undef, t_1300);
Call(chirp_964, V.Undef, t_1300);
return default;
}, 2, "tail", true)).V).Put("clover", NewObj(9).Put("head", Fn((V _arrowThis1311, int _argc1303, V t_1309, V s_1310, V _a1307, V _a1308, V[] _rest1304) => {
Invoke(Invoke(Invoke(t_1309, "to", ((V)(260D)), NewObj(7).Put("close", ((V)(0.9))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("earL", ((V)(16D))).Put("earR", ((V)(16D))).Put("pitch", ((V)((-0.12)))).Put("sq", ((V)(0.06))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(260D)), NewObj(7).Put("close", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
Call(twitch_968, V.Undef, t_1309, ((V)(3D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1320, int _argc1312, V t_1318, V s_1319, V _a1316, V _a1317, V[] _rest1313) => {
V k_1321 = default;
k_1321 = Call(S_934, V.Undef, s_1319);
Invoke(Invoke(Invoke(t_1318, "to", ((V)(260D)), NewObj(1).PutK(Get(k_1321, "ear"), ((V)(24D))).V, ((V)("io"))), "wait", ((V)(150D))), "to", ((V)(300D)), NewObj(1).PutK(Get(k_1321, "ear"), ((V)(0D))).V, ((V)("io")));
Call(see_943, V.Undef, t_1318, ((V)("ear")), s_1319, ((V)(150D)));
Call(unsee_944, V.Undef, t_1318);
Call(headShake_954, V.Undef, t_1318, ((V)(0.7)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1330, int _argc1322, V t_1328, V s_1329, V _a1326, V _a1327, V[] _rest1323) => {
Invoke(t_1328, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(1D))).V, ((V)("io")));
Call(twitch_968, V.Undef, t_1328, ((V)(6D)));
Invoke(t_1328, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(0D))).V, ((V)("io")));
Call(lick_949, V.Undef, t_1328, ((V)(1D)));
Invoke(t_1328, "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1339, int _argc1331, V t_1337, V s_1338, V _a1335, V _a1336, V[] _rest1332) => {
V k_1340 = default;
k_1340 = Call(S_934, V.Undef, s_1338);
Invoke(Invoke(Invoke(t_1337, "to", ((V)(200D)), NewObj(1).PutK(Get(k_1340, "wink"), ((V)(1D))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(200D)), NewObj(1).PutK(Get(k_1340, "wink"), ((V)(0D))).V, ((V)("io")));
Call(rub_962, V.Undef, t_1337, s_1338, ((V)("eye")), ((V)(2D)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1349, int _argc1341, V t_1347, V s_1348, V _a1345, V _a1346, V[] _rest1342) => {
Call(leanIn_951, V.Undef, t_1347, s_1348, NewObj(2).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).V);
Invoke(t_1347, "to", ((V)(200D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1358, int _argc1350, V t_1356, V s_1357, V _a1354, V _a1355, V[] _rest1351) => {
Invoke(t_1356, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.1))).V, ((V)("o")));
Call(giggle_945, V.Undef, t_1356, ((V)(3D)));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1367, int _argc1359, V t_1365, V s_1366, V _a1363, V _a1364, V[] _rest1360) => {
Call(see_943, V.Undef, t_1365, ((V)("side")), s_1366, ((V)(150D)));
Call(unsee_944, V.Undef, t_1365);
Call(twitch_968, V.Undef, t_1365, ((V)(2D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1376, int _argc1368, V t_1374, V s_1375, V _a1372, V _a1373, V[] _rest1369) => {
V k_1377 = default;
k_1377 = Call(S_934, V.Undef, s_1375);
Invoke(Invoke(Invoke(Invoke(t_1374, "to", ((V)(200D)), NewObj(3).PutK(Get(k_1377, "foot"), ((V)(3.5))).Put("earL", ((V)(14D))).Put("earR", ((V)(14D))).V, ((V)("io"))), "to", ((V)(70D)), NewObj(2).PutK(Get(k_1377, "foot"), ((V)(0D))).Put("sq", ((V)(0.1))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(2D))), "to", ((V)(160D)), NewObj(3).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Call(see_943, V.Undef, t_1374, ((V)("foot")), s_1375, ((V)(150D)));
Call(unsee_944, V.Undef, t_1374);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1386, int _argc1378, V t_1384, V s_1385, V _a1382, V _a1383, V[] _rest1379) => {
Invoke(Invoke(t_1384, "osc", ((V)(500D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(20D))).V, NewObj(1).Put("wag", ((V)((-20D)))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).Put("wag", ((V)(0D))).V);
Call(see_943, V.Undef, t_1384, ((V)("tail")), ((V)(1D)), ((V)(300D)));
Call(unsee_944, V.Undef, t_1384);
Call(giggle_945, V.Undef, t_1384, ((V)(1D)));
return default;
}, 2, "tail", true)).V).Put("chilla", NewObj(9).Put("head", Fn((V _arrowThis1395, int _argc1387, V t_1393, V s_1394, V _a1391, V _a1392, V[] _rest1388) => {
Invoke(Invoke(Invoke(t_1393, "to", ((V)(250D)), NewObj(5).Put("close", ((V)(0.9))).Put("hap", ((V)(1D))).Put("pitch", ((V)((-0.1)))).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(250D)), NewObj(5).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).Put("pitch", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1404, int _argc1396, V t_1402, V s_1403, V _a1400, V _a1401, V[] _rest1397) => {
V k_1405 = default;
k_1405 = Call(S_934, V.Undef, s_1403);
Invoke(Invoke(t_1402, "osc", ((V)(500D)), ((V)(3D)), NewObj(1).PutK(Get(k_1405, "ear"), ((V)((-14D)))).V, NewObj(1).PutK(Get(k_1405, "ear"), ((V)(8D))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(1).PutK(Get(k_1405, "ear"), ((V)(0D))).V);
Call(see_943, V.Undef, t_1402, ((V)("ear")), s_1403, ((V)(150D)));
Call(unsee_944, V.Undef, t_1402);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1414, int _argc1406, V t_1412, V s_1413, V _a1410, V _a1411, V[] _rest1407) => {
Invoke(t_1412, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(1D))).V, ((V)("io")));
Call(sniff_948, V.Undef, t_1412, ((V)(4D)));
Invoke(t_1412, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(0D))).V, ((V)("io")));
Call(lick_949, V.Undef, t_1412, ((V)(1D)));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1423, int _argc1415, V t_1421, V s_1422, V _a1419, V _a1420, V[] _rest1416) => {
V k_1424 = default;
k_1424 = Call(S_934, V.Undef, s_1422);
Invoke(Invoke(Invoke(t_1421, "to", ((V)(200D)), NewObj(1).PutK(Get(k_1424, "wink"), ((V)(1D))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(200D)), NewObj(1).PutK(Get(k_1424, "wink"), ((V)(0D))).V, ((V)("io")));
Call(rub_962, V.Undef, t_1421, s_1422, ((V)("eye")), ((V)(2D)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1433, int _argc1425, V t_1431, V s_1432, V _a1429, V _a1430, V[] _rest1426) => {
Call(leanIn_951, V.Undef, t_1431, s_1432);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1442, int _argc1434, V t_1440, V s_1441, V _a1438, V _a1439, V[] _rest1435) => {
Invoke(t_1440, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.14))).V, ((V)("o")));
Call(giggle_945, V.Undef, t_1440, ((V)(3D)));
Invoke(t_1440, "e", ((V)("emit")), ((V)("poof")), ((V)("body")), ((V)(2D)));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1451, int _argc1443, V t_1449, V s_1450, V _a1447, V _a1448, V[] _rest1444) => {
Call(popcorn_939, V.Undef, t_1449, ((V)(9D)), ((V)((-ToNum(s_1450)))), ((V)(460D)));
Invoke(t_1449, "e", ((V)("emit")), ((V)("poof")), ((V)("body")), ((V)(2D)));
Call(see_943, V.Undef, t_1449, ((V)("side")), s_1450, ((V)(150D)));
Call(unsee_944, V.Undef, t_1449);
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1460, int _argc1452, V t_1458, V s_1459, V _a1456, V _a1457, V[] _rest1453) => {
Call(pawShake_953, V.Undef, t_1458, s_1459, ((V)(0.8)));
Call(see_943, V.Undef, t_1458, ((V)("foot")), s_1459, ((V)(150D)));
Call(unsee_944, V.Undef, t_1458);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1469, int _argc1461, V t_1467, V s_1468, V _a1465, V _a1466, V[] _rest1462) => {
Invoke(Invoke(t_1467, "osc", ((V)(700D)), ((V)(4D)), NewObj(2).Put("wag", ((V)(30D))).Put("curl", ((V)(0.4))).V, NewObj(2).Put("wag", ((V)((-30D)))).Put("curl", ((V)(0D))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(2).Put("wag", ((V)(0D))).Put("curl", ((V)(0D))).V);
Call(see_943, V.Undef, t_1467, ((V)("tail")), ((V)(1D)), ((V)(300D)));
Call(unsee_944, V.Undef, t_1467);
Call(giggle_945, V.Undef, t_1467, ((V)(1D)));
return default;
}, 2, "tail", true)).V).Put("mimi", NewObj(9).Put("head", Fn((V _arrowThis1478, int _argc1470, V t_1476, V s_1477, V _a1474, V _a1475, V[] _rest1471) => {
Invoke(t_1476, "to", ((V)(120D)), NewObj(3).Put("sq", ((V)(0.12))).Put("earL", ((V)(14D))).Put("earR", ((V)(14D))).V, ((V)("o")));
Call(squeak_966, V.Undef, t_1476);
Invoke(t_1476, "to", ((V)(200D)), NewObj(3).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Call(see_943, V.Undef, t_1476, ((V)("head")), ((V)(0D)), ((V)(150D)));
Call(unsee_944, V.Undef, t_1476);
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1487, int _argc1479, V t_1485, V s_1486, V _a1483, V _a1484, V[] _rest1480) => {
V k_1488 = default;
k_1488 = Call(S_934, V.Undef, s_1486);
Invoke(Invoke(t_1485, "osc", ((V)(400D)), ((V)(3D)), NewObj(1).PutK(Get(k_1488, "ear"), ((V)((-16D)))).V, NewObj(1).PutK(Get(k_1488, "ear"), ((V)(8D))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).PutK(Get(k_1488, "ear"), ((V)(0D))).V);
Call(see_943, V.Undef, t_1485, ((V)("ear")), s_1486, ((V)(150D)));
Call(rub_962, V.Undef, t_1485, s_1486, ((V)("ear")), ((V)(2D)));
Call(unsee_944, V.Undef, t_1485);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1497, int _argc1489, V t_1495, V s_1496, V _a1493, V _a1494, V[] _rest1490) => {
Invoke(t_1495, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(1D))).V, ((V)("io")));
Invoke(t_1495, "osc", ((V)(900D)), ((V)(6D)), NewObj(2).Put("mw", ((V)(0.7))).Put("pitch", ((V)(0.05))).V, NewObj(2).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("o")));
Invoke(t_1495, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(0D))).V, ((V)("io")));
Call(squeak_966, V.Undef, t_1495);
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1506, int _argc1498, V t_1504, V s_1505, V _a1502, V _a1503, V[] _rest1499) => {
V k_1507 = default;
k_1507 = Call(S_934, V.Undef, s_1505);
Invoke(Invoke(Invoke(t_1504, "to", ((V)(160D)), NewObj(1).PutK(Get(k_1507, "wink"), ((V)(1D))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(160D)), NewObj(1).PutK(Get(k_1507, "wink"), ((V)(0D))).V, ((V)("io")));
Call(rub_962, V.Undef, t_1504, s_1505, ((V)("eye")), ((V)(3D)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1516, int _argc1508, V t_1514, V s_1515, V _a1512, V _a1513, V[] _rest1509) => {
Call(leanIn_951, V.Undef, t_1514, s_1515);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1525, int _argc1517, V t_1523, V s_1524, V _a1521, V _a1522, V[] _rest1518) => {
Invoke(t_1523, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.12))).V, ((V)("o")));
Call(giggle_945, V.Undef, t_1523, ((V)(4D)));
Call(squeak_966, V.Undef, t_1523);
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1534, int _argc1526, V t_1532, V s_1533, V _a1530, V _a1531, V[] _rest1527) => {
Invoke(t_1532, "to", ((V)(70D)), NewObj(1).Put("wide", ((V)(1D))).V, ((V)("o")));
Call(squeak_966, V.Undef, t_1532);
Call(see_943, V.Undef, t_1532, ((V)("side")), s_1533, ((V)(150D)));
Call(unsee_944, V.Undef, t_1532);
Invoke(t_1532, "to", ((V)(150D)), NewObj(1).Put("wide", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1543, int _argc1535, V t_1541, V s_1542, V _a1539, V _a1540, V[] _rest1536) => {
Call(pawShake_953, V.Undef, t_1541, s_1542, ((V)(0.7)));
Call(see_943, V.Undef, t_1541, ((V)("foot")), s_1542, ((V)(150D)));
Call(unsee_944, V.Undef, t_1541);
Call(squeak_966, V.Undef, t_1541);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1552, int _argc1544, V t_1550, V s_1551, V _a1548, V _a1549, V[] _rest1545) => {
Invoke(Invoke(t_1550, "osc", ((V)(500D)), ((V)(5D)), NewObj(1).Put("wag", ((V)(34D))).V, NewObj(1).Put("wag", ((V)((-34D)))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).Put("wag", ((V)(0D))).V);
Invoke(t_1550, "to", ((V)(70D)), NewObj(1).Put("wide", ((V)(1D))).V, ((V)("o")));
Call(squeak_966, V.Undef, t_1550);
Call(see_943, V.Undef, t_1550, ((V)("tail")), ((V)(1D)), ((V)(250D)));
Call(unsee_944, V.Undef, t_1550);
Invoke(t_1550, "to", ((V)(150D)), NewObj(1).Put("wide", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "tail", true)).V).Put("puddles", NewObj(9).Put("head", Fn((V _arrowThis1561, int _argc1553, V t_1559, V s_1560, V _a1557, V _a1558, V[] _rest1554) => {
Invoke(Invoke(t_1559, "to", ((V)(80D)), NewObj(3).Put("sq", ((V)(0.14))).Put("earL", ((V)((-16D)))).Put("earR", ((V)((-16D)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(3).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Call(quack_965, V.Undef, t_1559);
Call(see_943, V.Undef, t_1559, ((V)("head")), ((V)(0D)), ((V)(150D)));
Call(unsee_944, V.Undef, t_1559);
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1570, int _argc1562, V t_1568, V s_1569, V _a1566, V _a1567, V[] _rest1563) => {
V k_1571 = default;
k_1571 = Call(S_934, V.Undef, s_1569);
Invoke(Invoke(t_1568, "osc", ((V)(500D)), ((V)(3D)), NewObj(1).PutK(Get(k_1571, "ear"), ((V)((-20D)))).V, NewObj(1).PutK(Get(k_1571, "ear"), ((V)(10D))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).PutK(Get(k_1571, "ear"), ((V)(0D))).V);
Call(see_943, V.Undef, t_1568, ((V)("ear")), s_1569, ((V)(150D)));
Call(unsee_944, V.Undef, t_1568);
Call(giggle_945, V.Undef, t_1568, ((V)(1D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1580, int _argc1572, V t_1578, V s_1579, V _a1576, V _a1577, V[] _rest1573) => {
Invoke(t_1578, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(1D))).V, ((V)("io")));
Call(peck_969, V.Undef, t_1578, ((V)(2D)));
Invoke(t_1578, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(0D))).V, ((V)("io")));
Call(quack_965, V.Undef, t_1578);
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1589, int _argc1581, V t_1587, V s_1588, V _a1585, V _a1586, V[] _rest1582) => {
V k_1590 = default;
k_1590 = Call(S_934, V.Undef, s_1588);
Invoke(Invoke(Invoke(t_1587, "to", ((V)(200D)), NewObj(1).PutK(Get(k_1590, "wink"), ((V)(1D))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(200D)), NewObj(1).PutK(Get(k_1590, "wink"), ((V)(0D))).V, ((V)("io")));
Call(headShake_954, V.Undef, t_1587, ((V)(0.7)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1599, int _argc1591, V t_1597, V s_1598, V _a1595, V _a1596, V[] _rest1592) => {
Call(leanIn_951, V.Undef, t_1597, s_1598);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1608, int _argc1600, V t_1606, V s_1607, V _a1604, V _a1605, V[] _rest1601) => {
Invoke(t_1606, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.12))).V, ((V)("o")));
Call(giggle_945, V.Undef, t_1606, ((V)(3D)));
Call(flap_971, V.Undef, t_1606, ((V)(2D)), ((V)(90D)));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1617, int _argc1609, V t_1615, V s_1616, V _a1613, V _a1614, V[] _rest1610) => {
V k_1618 = default;
k_1618 = Call(S_934, V.Undef, s_1616);
Invoke(Invoke(Invoke(t_1615, "to", ((V)(100D)), NewObj(1).PutK(Get(k_1618, "arm"), ((V)(90D))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(1).PutK(Get(k_1618, "arm"), ((V)(15D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("fluffY")), ((V)("body")), ((V)(1D)));
Call(see_943, V.Undef, t_1615, ((V)("side")), s_1616, ((V)(150D)));
Call(unsee_944, V.Undef, t_1615);
Invoke(t_1615, "to", ((V)(120D)), NewObj(1).PutK(Get(k_1618, "arm"), ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1627, int _argc1619, V t_1625, V s_1626, V _a1623, V _a1624, V[] _rest1620) => {
V k_1628 = default;
k_1628 = Call(S_934, V.Undef, s_1626);
Invoke(Invoke(Invoke(Invoke(t_1625, "to", ((V)(150D)), NewObj(1).PutK(Get(k_1628, "foot"), ((V)(3D))).V, ((V)("o"))), "to", ((V)(80D)), NewObj(2).PutK(Get(k_1628, "foot"), ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("splash")), ((V)("body")), ((V)(2D))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(see_943, V.Undef, t_1625, ((V)("foot")), s_1626, ((V)(150D)));
Call(unsee_944, V.Undef, t_1625);
Call(giggle_945, V.Undef, t_1625, ((V)(1D)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1637, int _argc1629, V t_1635, V s_1636, V _a1633, V _a1634, V[] _rest1630) => {
Call(wagT_972, V.Undef, t_1635, ((V)(5D)), ((V)(34D)), ((V)(120D)));
Call(see_943, V.Undef, t_1635, ((V)("tail")), ((V)(1D)), ((V)(250D)));
Call(unsee_944, V.Undef, t_1635);
Call(quack_965, V.Undef, t_1635);
return default;
}, 2, "tail", true)).V).Put("bean", NewObj(9).Put("head", Fn((V _arrowThis1646, int _argc1638, V t_1644, V s_1645, V _a1642, V _a1643, V[] _rest1639) => {
Invoke(t_1644, "to", ((V)(260D)), NewObj(5).Put("close", ((V)(0.9))).Put("hap", ((V)(1D))).Put("tongue", ((V)(0.6))).Put("open", ((V)(0.25))).Put("pitch", ((V)((-0.08)))).V, ((V)("io")));
Call(wagT_972, V.Undef, t_1644, ((V)(4D)), ((V)(38D)));
Invoke(t_1644, "to", ((V)(250D)), NewObj(5).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1655, int _argc1647, V t_1653, V s_1654, V _a1651, V _a1652, V[] _rest1648) => {
V k_1656 = default;
k_1656 = Call(S_934, V.Undef, s_1654);
Invoke(Invoke(t_1653, "to", ((V)(120D)), NewObj(1).PutK(Get(k_1656, "ear"), ((V)((-14D)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).PutK(Get(k_1656, "ear"), ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_1653, "to", ((V)(300D)), NewObj(1).Put("htilt", ((V)((ToNum(s_1654) * 14D)))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(250D)), NewObj(1).Put("htilt", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1665, int _argc1657, V t_1663, V s_1664, V _a1661, V _a1662, V[] _rest1658) => {
Invoke(t_1663, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(1D))).V, ((V)("io")));
Call(snort_955, V.Undef, t_1663, ((V)(2D)));
Invoke(t_1663, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(0D))).V, ((V)("io")));
Call(lick_949, V.Undef, t_1663, ((V)(2D)));
Invoke(t_1663, "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1674, int _argc1666, V t_1672, V s_1673, V _a1670, V _a1671, V[] _rest1667) => {
V k_1675 = default;
k_1675 = Call(S_934, V.Undef, s_1673);
Invoke(Invoke(Invoke(t_1672, "to", ((V)(200D)), NewObj(1).PutK(Get(k_1675, "wink"), ((V)(1D))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(200D)), NewObj(1).PutK(Get(k_1675, "wink"), ((V)(0D))).V, ((V)("io")));
Call(snort_955, V.Undef, t_1672, ((V)(1D)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1684, int _argc1676, V t_1682, V s_1683, V _a1680, V _a1681, V[] _rest1677) => {
Call(leanIn_951, V.Undef, t_1682, s_1683, NewObj(2).Put("tongue", ((V)(0.5))).Put("open", ((V)(0.2))).V);
Invoke(t_1682, "to", ((V)(200D)), NewObj(2).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1693, int _argc1685, V t_1691, V s_1692, V _a1689, V _a1690, V[] _rest1686) => {
V a_1694 = default;
Invoke(t_1691, "to", ((V)(200D)), NewObj(4).Put("sq", ((V)(0.12))).Put("hap", ((V)(1D))).Put("tongue", ((V)(0.6))).Put("open", ((V)(0.3))).V, ((V)("o")));
a_1694 = Get(t_1691, "t");
Call(giggle_945, V.Undef, t_1691, ((V)(3D)));
Call(para_950, V.Undef, t_1691, a_1694, Fn((V _arrowThis1702, int _argc1695, V u_1701, V _a1698, V _a1699, V _a1700, V[] _rest1696) => {
return Invoke(Invoke(u_1701, "osc", ((V)(800D)), ((V)(4D)), NewObj(2).Put("footL", ((V)(2.5))).Put("footR", ((V)(0D))).V, NewObj(2).Put("footL", ((V)(0D))).Put("footR", ((V)(2.5))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(2).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V);
}, 1, "", true));
Invoke(t_1691, "to", ((V)(200D)), NewObj(3).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1711, int _argc1703, V t_1709, V s_1710, V _a1707, V _a1708, V[] _rest1704) => {
Call(see_943, V.Undef, t_1709, ((V)("side")), s_1710, ((V)(150D)));
Call(unsee_944, V.Undef, t_1709);
Call(snort_955, V.Undef, t_1709, ((V)(1D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1720, int _argc1712, V t_1718, V s_1719, V _a1716, V _a1717, V[] _rest1713) => {
Call(pawShake_953, V.Undef, t_1718, s_1719, ((V)(0.8)));
Call(see_943, V.Undef, t_1718, ((V)("foot")), s_1719, ((V)(150D)));
Call(unsee_944, V.Undef, t_1718);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1729, int _argc1721, V t_1727, V s_1728, V _a1725, V _a1726, V[] _rest1722) => {
Invoke(t_1727, "to", ((V)(300D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(wagT_972, V.Undef, t_1727, ((V)(6D)), ((V)(44D)), ((V)(120D)));
Call(see_943, V.Undef, t_1727, ((V)("tail")), ((V)(1D)), ((V)(200D)));
Call(unsee_944, V.Undef, t_1727);
Invoke(t_1727, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "tail", true)).V).Put("zippy", NewObj(9).Put("head", Fn((V _arrowThis1738, int _argc1730, V t_1736, V s_1737, V _a1734, V _a1735, V[] _rest1731) => {
Call(dook_967, V.Undef, t_1736, ((V)(3D)));
Call(see_943, V.Undef, t_1736, ((V)("head")), ((V)(0D)), ((V)(120D)));
Call(unsee_944, V.Undef, t_1736);
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1747, int _argc1739, V t_1745, V s_1746, V _a1743, V _a1744, V[] _rest1740) => {
V k_1748 = default;
k_1748 = Call(S_934, V.Undef, s_1746);
Invoke(Invoke(t_1745, "to", ((V)(80D)), NewObj(1).PutK(Get(k_1748, "ear"), ((V)((-14D)))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(1).PutK(Get(k_1748, "ear"), ((V)(0D))).V, ((V)("io")));
Call(see_943, V.Undef, t_1745, ((V)("ear")), s_1746, ((V)(100D)));
Call(unsee_944, V.Undef, t_1745);
Call(dook_967, V.Undef, t_1745, ((V)(2D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1757, int _argc1749, V t_1755, V s_1756, V _a1753, V _a1754, V[] _rest1750) => {
Invoke(t_1755, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(1D))).V, ((V)("io")));
Call(sniff_948, V.Undef, t_1755, ((V)(3D)));
Invoke(t_1755, "to", ((V)(150D)), NewObj(1).Put("cross", ((V)(0D))).V, ((V)("io")));
Call(lick_949, V.Undef, t_1755, ((V)(1D)));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1766, int _argc1758, V t_1764, V s_1765, V _a1762, V _a1763, V[] _rest1759) => {
V k_1767 = default;
k_1767 = Call(S_934, V.Undef, s_1765);
Invoke(Invoke(Invoke(t_1764, "to", ((V)(160D)), NewObj(1).PutK(Get(k_1767, "wink"), ((V)(1D))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(160D)), NewObj(1).PutK(Get(k_1767, "wink"), ((V)(0D))).V, ((V)("io")));
Call(headShake_954, V.Undef, t_1764, ((V)(0.8)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1776, int _argc1768, V t_1774, V s_1775, V _a1772, V _a1773, V[] _rest1769) => {
Call(leanIn_951, V.Undef, t_1774, s_1775);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1785, int _argc1777, V t_1783, V s_1784, V _a1781, V _a1782, V[] _rest1778) => {
Invoke(t_1783, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.12))).V, ((V)("o")));
Call(giggle_945, V.Undef, t_1783, ((V)(4D)), ((V)(1.2)));
Call(dook_967, V.Undef, t_1783, ((V)(2D)));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1794, int _argc1786, V t_1792, V s_1793, V _a1790, V _a1791, V[] _rest1787) => {
Call(jump_936, V.Undef, t_1792, NewObj(8).Put("h", ((V)(6D))).Put("ant", ((V)(50D))).Put("up", ((V)(140D))).Put("c", ((V)(0.08))).Put("arm", ((V)(40D))).Put("x", ((V)(((-ToNum(s_1793)) * 3D)))).Put("air", NewObj(1).Put("tilt", ((V)(((-ToNum(s_1793)) * 10D)))).V).Put("fall", NewObj(1).Put("tilt", ((V)(0D))).V).V);
Call(see_943, V.Undef, t_1792, ((V)("side")), s_1793, ((V)(150D)));
Call(unsee_944, V.Undef, t_1792);
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1803, int _argc1795, V t_1801, V s_1802, V _a1799, V _a1800, V[] _rest1796) => {
Call(pawShake_953, V.Undef, t_1801, s_1802, ((V)(0.8)));
Call(see_943, V.Undef, t_1801, ((V)("foot")), s_1802, ((V)(120D)));
Call(unsee_944, V.Undef, t_1801);
Call(dook_967, V.Undef, t_1801, ((V)(2D)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1812, int _argc1804, V t_1810, V s_1811, V _a1808, V _a1809, V[] _rest1805) => {
Invoke(Invoke(Invoke(t_1810, "to", ((V)(70D)), NewObj(2).Put("wide", ((V)(1D))).Put("sq", ((V)((-0.08)))).V, ((V)("o"))), "osc", ((V)(500D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(36D))).V, NewObj(1).Put("wag", ((V)((-36D)))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(2).Put("wag", ((V)(0D))).Put("sq", ((V)(0D))).V);
Call(see_943, V.Undef, t_1810, ((V)("tail")), ((V)(1D)), ((V)(200D)));
Call(unsee_944, V.Undef, t_1810);
Invoke(t_1810, "to", ((V)(150D)), NewObj(1).Put("wide", ((V)(0D))).V, ((V)("io")));
Call(dook_967, V.Undef, t_1810, ((V)(2D)));
return default;
}, 2, "tail", true)).V).Put("mango", NewObj(9).Put("head", Fn((V _arrowThis1821, int _argc1813, V t_1819, V s_1820, V _a1817, V _a1818, V[] _rest1814) => {
Invoke(Invoke(Invoke(Invoke(t_1819, "to", ((V)(300D)), NewObj(4).Put("close", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("pitch", ((V)((-0.06)))).V, ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(400D)), NewObj(2).Put("close", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1830, int _argc1822, V t_1828, V s_1829, V _a1826, V _a1827, V[] _rest1823) => {
Invoke(t_1828, "to", ((V)(300D)), NewObj(1).Put("htilt", ((V)((ToNum(s_1829) * 10D)))).V, ((V)("io")));
Call(see_943, V.Undef, t_1828, ((V)("ear")), s_1829, ((V)(250D)));
Call(unsee_944, V.Undef, t_1828, ((V)(400D)));
Invoke(t_1828, "to", ((V)(250D)), NewObj(1).Put("htilt", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1839, int _argc1831, V t_1837, V s_1838, V _a1835, V _a1836, V[] _rest1832) => {
Invoke(Invoke(Invoke(Invoke(t_1837, "to", ((V)(200D)), NewObj(1).Put("cross", ((V)(1D))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(2).Put("tongue", ((V)(0.9))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("cross", ((V)(0D))).V, ((V)("io")));
Invoke(t_1837, "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1848, int _argc1840, V t_1846, V s_1847, V _a1844, V _a1845, V[] _rest1841) => {
V k_1849 = default;
k_1849 = Call(S_934, V.Undef, s_1847);
Invoke(Invoke(Invoke(t_1846, "to", ((V)(220D)), NewObj(1).PutK(Get(k_1849, "wink"), ((V)(1D))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(200D)), NewObj(1).PutK(Get(k_1849, "wink"), ((V)(0D))).V, ((V)("io")));
Call(eyeLick_973, V.Undef, t_1846, s_1847);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1858, int _argc1850, V t_1856, V s_1857, V _a1854, V _a1855, V[] _rest1851) => {
Call(leanIn_951, V.Undef, t_1856, s_1857);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1867, int _argc1859, V t_1865, V s_1866, V _a1863, V _a1864, V[] _rest1860) => {
Invoke(t_1865, "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0.1))).V, ((V)("o")));
Call(giggle_945, V.Undef, t_1865, ((V)(2D)), ((V)(0.8)));
Invoke(Invoke(t_1865, "osc", ((V)(600D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(20D))).V, NewObj(1).Put("wag", ((V)((-20D)))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).Put("wag", ((V)(0D))).V);
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1876, int _argc1868, V t_1874, V s_1875, V _a1872, V _a1873, V[] _rest1869) => {
Invoke(t_1874, "to", ((V)(300D)), NewObj(2).Put("bend", ((V)((ToNum(s_1875) * 4D)))).Put("wag", ((V)(((-ToNum(s_1875)) * 20D)))).V, ((V)("io")));
Call(see_943, V.Undef, t_1874, ((V)("side")), s_1875, ((V)(300D)));
Call(unsee_944, V.Undef, t_1874, ((V)(400D)));
Invoke(t_1874, "to", ((V)(300D)), NewObj(2).Put("bend", ((V)(0D))).Put("wag", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1885, int _argc1877, V t_1883, V s_1884, V _a1881, V _a1882, V[] _rest1878) => {
V k_1886 = default;
k_1886 = Call(S_934, V.Undef, s_1884);
Invoke(Invoke(Invoke(t_1883, "to", ((V)(260D)), NewObj(1).PutK(Get(k_1886, "foot"), ((V)(3D))).V, ((V)("io"))), "osc", ((V)(500D)), ((V)(3D)), NewObj(1).PutK(Get(k_1886, "foot"), ((V)(3.5))).V, NewObj(1).PutK(Get(k_1886, "foot"), ((V)(2.5))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(1).PutK(Get(k_1886, "foot"), ((V)(0D))).V, ((V)("io")));
Call(see_943, V.Undef, t_1883, ((V)("foot")), s_1884, ((V)(200D)));
Call(unsee_944, V.Undef, t_1883);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1895, int _argc1887, V t_1893, V s_1894, V _a1891, V _a1892, V[] _rest1888) => {
Invoke(Invoke(t_1893, "osc", ((V)(800D)), ((V)(10D)), NewObj(1).Put("wag", ((V)(12D))).V, NewObj(1).Put("wag", ((V)((-12D)))).V, ((V)("l"))), "to", ((V)(100D)), NewObj(1).Put("wag", ((V)(0D))).V);
Call(see_943, V.Undef, t_1893, ((V)("tail")), ((V)(1D)), ((V)(300D)));
Call(unsee_944, V.Undef, t_1893, ((V)(400D)));
return default;
}, 2, "tail", true)).V).V;
TXT_976 = NewObj(9).Put("tilly", NewObj(9).Put("head", ((V)("Her crest pops up, then she bows her head for more scratches."))).Put("ear", ((V)("That crest feather flicks up and back, she looks up and whistles."))).Put("nose", ((V)("Gently nibbles your finger with her beak, then a happy whistle."))).Put("eye", ((V)("Blinks hard with her crest going flat, a little head shake."))).Put("cheek", ((V)("Leans her cheek into your finger, crest flat with bliss."))).Put("belly", ((V)("Fluffs up and giggles, crest flat."))).Put("side", ((V)("Her wing flicks out and a feather drifts down; she looks at the spot."))).Put("foot", ((V)("Lifts that foot, looks down and gives a small whistle."))).Put("tail", ((V)("Her tail feathers wag, she looks back and her crest pops up."))).V).Put("pico", NewObj(9).Put("head", ((V)("Bobs down under your finger, looks up, two chirps."))).Put("ear", ((V)("Tilts his head to show off his stripes, then chirps."))).Put("nose", ((V)("Pecks your finger playfully - peck peck peck - a heart and a chirp."))).Put("eye", ((V)("Blinks, a quick bird head-snap away and back, a chirp."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("Puffs up giggling and flaps his wings."))).Put("side", ((V)("His wing flicks out and a feather drifts down."))).Put("foot", ((V)("Lifts that foot and looks at it, chirp."))).Put("tail", ((V)("Tail flicks fast, he looks back and chirps."))).V).Put("clover", NewObj(9).Put("head", ((V)("Melts flat with her eyes shut and her ears spread - a happy bunny - then her nose twitches."))).Put("ear", ((V)("That long ear flicks back and springs up, then an ear shake."))).Put("nose", ((V)("Her nose twitches like crazy at your finger, then a little lick and a heart."))).Put("eye", ((V)("Blinks and rubs her eye with a paw."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("Giggles."))).Put("side", ((V)("Looks at the spot, nose twitching."))).Put("foot", ((V)("THUMP - stamps that foot and looks down at it."))).Put("tail", ((V)("Her cotton tail wiggles, she looks back and giggles."))).V).Put("chilla", NewObj(9).Put("head", ((V)("Shuts her eyes and leans into the pat."))).Put("ear", ((V)("That big round ear flicks back and forth."))).Put("nose", ((V)("Sniffs your finger and licks it."))).Put("eye", ((V)("Blinks and rubs her eye."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("So fluffy that a little dust puffs out when she giggles."))).Put("side", ((V)("Pops straight up like popcorn."))).Put("foot", ((V)("Shakes that foot."))).Put("tail", ((V)("Her bushy tail swishes, she looks back and giggles."))).V).Put("mimi", NewObj(9).Put("head", ((V)("Squeaks and ducks with her ears out."))).Put("ear", ((V)("That big pink ear flutters, she rubs it."))).Put("nose", ((V)("Sniff-sniff-sniff with her whiskers going, then a squeak."))).Put("eye", ((V)("Blinks and rubs her eye with a tiny paw."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("Giggles and squeaks."))).Put("side", ((V)("Jumps with a squeak, eyes wide."))).Put("foot", ((V)("Shakes that foot and squeaks."))).Put("tail", ((V)("Her tail flicks fast, squeak! - she looks back."))).V).Put("puddles", NewObj(9).Put("head", ((V)("Ducks with her head fluff standing up, then a quack."))).Put("ear", ((V)("Her head fluff wiggles, she giggles."))).Put("nose", ((V)("Nibbles your finger with her bill, quack."))).Put("eye", ((V)("Blinks, a little head shake."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("Giggles and flaps her wings."))).Put("side", ((V)("Her wing flicks out and some fluff floats off."))).Put("foot", ((V)("Stomps that webbed foot - splash - and giggles."))).Put("tail", ((V)("Waggles her tail, looks back, quack."))).V).Put("bean", NewObj(9).Put("head", ((V)("Eyes shut, tongue out, his curly tail going."))).Put("ear", ((V)("His ear perks and he tilts his head, puzzled."))).Put("nose", ((V)("Snorts at your finger, then licks it: a heart."))).Put("eye", ((V)("Blinks hard and snorts."))).Put("cheek", ((V)("Leans into your finger with his tongue out."))).Put("belly", ((V)("Belly rub! Giggles with his back legs kicking."))).Put("side", ((V)("Looks at the spot and snorts."))).Put("foot", ((V)("Shakes that paw."))).Put("tail", ((V)("His curly tail wags like mad."))).V).Put("zippy", NewObj(9).Put("head", ((V)("Happy dooks, bouncing."))).Put("ear", ((V)("His ear flicks, he looks up - dook dook."))).Put("nose", ((V)("Sniffs your finger and licks it."))).Put("eye", ((V)("Blinks and shakes his head."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("Super ticklish: giggles and dooks."))).Put("side", ((V)("A sideways war-dance hop away from the poke."))).Put("foot", ((V)("Shakes that paw, then dooks."))).Put("tail", ((V)("His tail puffs and swishes, he looks back - dook."))).V).Put("mango", NewObj(9).Put("head", ((V)("Shuts his eyes with a big grin for a long happy moment."))).Put("ear", ((V)("Tilts his head slowly toward the poke and looks."))).Put("nose", ((V)("Tastes your finger with his tongue: a heart."))).Put("eye", ((V)("Blinks, then licks that eyeball clean."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("Giggles, tail swishing."))).Put("side", ((V)("Curves away and looks at the spot, slowly."))).Put("foot", ((V)("Peels his sticky toes up and pats them back down."))).Put("tail", ((V)("Rattles the tip of his tail."))).V).V;
Call(build_963, V.Undef, RE_975, TXT_976, BODY_974);
return default;
}, 0, "boot", false)), V.Undef);
Call(Named(boot_1917 => Fn((V _self1896, int _argc1897, V _a1899, V _a1900, V _a1901, V _a1902, V[] _rest1898) => {
V R_1903 = default;
V o_1904 = default;
V jump_1905 = default;
V swing_1906 = default;
V popcorn_1907 = default;
V EAR_1908 = default;
V sniffF_1909 = default;
V lipLick_1910 = default;
V hearts_1911 = default;
V buildAll_1912 = default;
V chirp_1913 = default;
V quack_1914 = default;
V bob_1915 = default;
V CARDS_1916 = default;
if (_self1896.IsNullish) _self1896 = GlobalV;
R_1903 = Get(G("window"), "RiveRig");
if ((((!(Truthy(R_1903)) || !(Truthy(Get(R_1903, "EATKIT")))) || !(Truthy(Get(R_1903, "pet2V")))) || !(Truthy(Get(R_1903, "EATLIB"))))) {
Call(G("setTimeout"), V.Undef, boot_1917.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_1903, "pet2EatV"))) {
return default;
}
Set(R_1903, "pet2EatV", ((V)(1D)));
{ V _t1918 = Get(R_1903, "PETLIB");
if (_t1918.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1918));
{ V _t1919 = Get(_t1918, "o");
o_1904 = _t1919; }
{ V _t1920 = Get(_t1918, "jump");
jump_1905 = _t1920; }
{ V _t1921 = Get(_t1918, "swing");
swing_1906 = _t1921; }
{ V _t1922 = Get(_t1918, "popcorn");
popcorn_1907 = _t1922; } }
{ V _t1923 = Get(R_1903, "EATKIT");
if (_t1923.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1923));
{ V _t1924 = Get(_t1923, "EAR");
EAR_1908 = _t1924; }
{ V _t1925 = Get(_t1923, "sniffF");
sniffF_1909 = _t1925; }
{ V _t1926 = Get(_t1923, "lipLick");
lipLick_1910 = _t1926; }
{ V _t1927 = Get(_t1923, "hearts");
hearts_1911 = _t1927; }
{ V _t1928 = Get(_t1923, "buildAll");
buildAll_1912 = _t1928; } }
Object_assign(EAR_1908, NewObj(9).Put("tilly", ((V)(1D))).Put("pico", ((V)(0D))).Put("clover", ((V)(1.2))).Put("chilla", ((V)(0.9))).Put("mimi", ((V)(1D))).Put("puddles", ((V)(0.4))).Put("bean", ((V)(0.5))).Put("zippy", ((V)(0.6))).Put("mango", ((V)(0D))).V);
chirp_1913 = Fn((V _arrowThis1937, int _argc1929, V t_1935, V a_1936, V _a1933, V _a1934, V[] _rest1930) => {
return Invoke(Invoke(Invoke(t_1935, "to", ((V)(90D)), NewObj(3).Put("open", ((V)((0.5 * ToNum((a_1936 is var _t1938 && Truthy(_t1938) ? _t1938 : ((V)(1D)))))))).Put("mw", ((V)(0.6))).Put("pitch", ((V)(0.08))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(140D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 2, "", true);
quack_1914 = Fn((V _arrowThis1946, int _argc1939, V t_1945, V _a1942, V _a1943, V _a1944, V[] _rest1940) => {
return Invoke(Invoke(Invoke(t_1945, "to", ((V)(90D)), NewObj(3).Put("open", ((V)(0.65))).Put("mw", ((V)(1.1))).Put("pitch", ((V)(0.12))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(170D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
bob_1915 = Fn((V _arrowThis1955, int _argc1947, V t_1953, V n_1954, V _a1951, V _a1952, V[] _rest1948) => {
{
double i_1956 = 0;
i_1956 = 0D;
while (true) {
if (!(Lt(((V)(i_1956)), n_1954))) break;
Invoke(Invoke(t_1953, "to", ((V)(100D)), NewObj(2).Put("pitch", ((V)((-0.14)))).Put("sq", ((V)(0.02))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(2).Put("pitch", ((V)(0.03))).Put("sq", ((V)(0D))).V, ((V)("io")));
i_1956++;
}
}
return Invoke(t_1953, "to", ((V)(100D)), NewObj(1).Put("pitch", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "", true);
CARDS_1916 = NewObj(9).Put("tilly", NewObj(9).Put("chewMs", ((V)(110D))).Put("chewN", ((V)(1.2))).Put("open", ((V)(0.5))).Put("crumbs", ((V)(1D))).Put("txt", ((V)("Crest up with interest, quick little beak nibbles; bobs her head and whistles when she likes it."))).Put("pre", Fn((V _arrowThis1965, int _argc1958, V t_1964, V _a1961, V _a1962, V _a1963, V[] _rest1959) => {
Invoke(t_1964, "to", ((V)(160D)), NewObj(2).Put("earL", ((V)((-20D)))).Put("earR", ((V)((-20D)))).V, ((V)("o")));
Call(sniffF_1909, V.Undef, t_1964, ((V)(1D)));
return default;
}, 1, "pre", true)).Put("post", Fn((V _arrowThis1973, int _argc1966, V t_1972, V _a1969, V _a1970, V _a1971, V[] _rest1967) => {
return Invoke(t_1972, "to", ((V)(250D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis1981, int _argc1974, V t_1980, V _a1977, V _a1978, V _a1979, V[] _rest1975) => {
Invoke(t_1980, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(bob_1915, V.Undef, t_1980, ((V)(3D)));
Call(chirp_1913, V.Undef, t_1980);
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis1989, int _argc1982, V t_1988, V _a1985, V _a1986, V _a1987, V[] _rest1983) => {
Call(hearts_1911, V.Undef, t_1988, ((V)(2D)));
Invoke(t_1988, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(96D))).Put("armR", ((V)(96D))).Put("earL", ((V)((-26D)))).Put("earR", ((V)((-26D)))).V, ((V)("o")));
Call(bob_1915, V.Undef, t_1988, ((V)(3D)));
Invoke(t_1988, "to", ((V)(240D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Call(chirp_1913, V.Undef, t_1988);
return default;
}, 1, "love", true)).V).Put("pico", NewObj(7).Put("chewMs", ((V)(90D))).Put("chewN", ((V)(1.4))).Put("open", ((V)(0.5))).Put("crumbs", ((V)(2D))).Put("txt", ((V)("Pecks at it super fast; chatters and bobs when he likes it."))).Put("yum", Fn((V _arrowThis1997, int _argc1990, V t_1996, V _a1993, V _a1994, V _a1995, V[] _rest1991) => {
Invoke(Invoke(t_1996, "to", ((V)(140D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(5D)), NewObj(2).Put("open", ((V)(0.4))).Put("mw", ((V)(0.6))).V, NewObj(2).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("o")));
Call(bob_1915, V.Undef, t_1996, ((V)(3D)));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis2005, int _argc1998, V t_2004, V _a2001, V _a2002, V _a2003, V[] _rest1999) => {
Call(hearts_1911, V.Undef, t_2004, ((V)(2D)));
Call(jump_1905, V.Undef, t_2004, NewObj(5).Put("h", ((V)(6D))).Put("ant", ((V)(100D))).Put("up", ((V)(160D))).Put("c", ((V)(0.12))).Put("arm", ((V)(90D))).V);
Call(bob_1915, V.Undef, t_2004, ((V)(3D)));
Call(chirp_1913, V.Undef, t_2004);
return default;
}, 1, "love", true)).V).Put("clover", NewObj(7).Put("chewMs", ((V)(95D))).Put("chewN", ((V)(1.5))).Put("open", ((V)(0.4))).Put("txt", ((V)("Sniffs it with her nose twitching, tiny quick bunny nibbles; binkies when she loves it."))).Put("pre", Fn((V _arrowThis2013, int _argc2006, V t_2012, V _a2009, V _a2010, V _a2011, V[] _rest2007) => {
Invoke(t_2012, "osc", ((V)(450D)), ((V)(3D)), NewObj(2).Put("mw", ((V)(0.7))).Put("pitch", ((V)(0.04))).V, NewObj(2).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "pre", true)).Put("yum", Fn((V _arrowThis2021, int _argc2014, V t_2020, V _a2017, V _a2018, V _a2019, V[] _rest2015) => {
Invoke(Invoke(t_2020, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(450D)), ((V)(3D)), NewObj(1).Put("mw", ((V)(0.7))).V, NewObj(1).Put("mw", ((V)(1D))).V, ((V)("o")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis2029, int _argc2022, V t_2028, V _a2025, V _a2026, V _a2027, V[] _rest2023) => {
Call(hearts_1911, V.Undef, t_2028, ((V)(2D)));
Call(jump_1905, V.Undef, t_2028, NewObj(7).Put("h", ((V)(12D))).Put("ant", ((V)(150D))).Put("up", ((V)(240D))).Put("c", ((V)(0.18))).Put("arm", ((V)(20D))).Put("air", NewObj(5).Put("tilt", ((V)(10D))).Put("turn", ((V)(0.35))).Put("earL", ((V)(28D))).Put("earR", ((V)(28D))).Put("footR", ((V)(3.5))).V).Put("fall", NewObj(5).Put("tilt", ((V)(0D))).Put("turn", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("footR", ((V)(0D))).V).V);
return default;
}, 1, "love", true)).V).Put("chilla", NewObj(8).Put("chewMs", ((V)(85D))).Put("chewN", ((V)(1.5))).Put("open", ((V)(0.45))).Put("crumbs", ((V)(1D))).Put("headY", ((V)((-14D)))).Put("txt", ((V)("Holds it up in both paws and nibbles it fast; popcorns when she loves it."))).Put("yum", Fn((V _arrowThis2037, int _argc2030, V t_2036, V _a2033, V _a2034, V _a2035, V[] _rest2031) => {
Invoke(t_2036, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(swing_1906, V.Undef, t_2036, ((V)(700D)), ((V)(3D)), NewObj(1).Put("wag", ((V)(26D))).V);
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis2045, int _argc2038, V t_2044, V _a2041, V _a2042, V _a2043, V[] _rest2039) => {
Call(hearts_1911, V.Undef, t_2044, ((V)(2D)));
Call(popcorn_1907, V.Undef, t_2044, ((V)(13D)), ((V)(1D)), ((V)(520D)));
return default;
}, 1, "love", true)).V).Put("mimi", NewObj(9).Put("chewMs", ((V)(70D))).Put("chewN", ((V)(1.8))).Put("open", ((V)(0.4))).Put("crumbs", ((V)(2D))).Put("headY", ((V)((-14D)))).Put("txt", ((V)("Holds it in her tiny paws and nibbles it super fast, whiskers going; squeaks when she likes it."))).Put("pre", Fn((V _arrowThis2053, int _argc2046, V t_2052, V _a2049, V _a2050, V _a2051, V[] _rest2047) => {
Invoke(t_2052, "osc", ((V)(500D)), ((V)(4D)), NewObj(2).Put("mw", ((V)(0.7))).Put("pitch", ((V)(0.05))).V, NewObj(2).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "pre", true)).Put("yum", Fn((V _arrowThis2061, int _argc2054, V t_2060, V _a2057, V _a2058, V _a2059, V[] _rest2055) => {
Invoke(Invoke(Invoke(t_2060, "to", ((V)(70D)), NewObj(4).Put("open", ((V)(0.4))).Put("mw", ((V)(0.55))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(140D)), NewObj(2).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
Call(swing_1906, V.Undef, t_2060, ((V)(600D)), ((V)(3D)), NewObj(1).Put("wag", ((V)(30D))).V);
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis2069, int _argc2062, V t_2068, V _a2065, V _a2066, V _a2067, V[] _rest2063) => {
Call(hearts_1911, V.Undef, t_2068, ((V)(2D)));
Call(jump_1905, V.Undef, t_2068, NewObj(5).Put("h", ((V)(8D))).Put("ant", ((V)(60D))).Put("up", ((V)(180D))).Put("c", ((V)(0.12))).Put("arm", ((V)(50D))).V);
Invoke(Get(CARDS_1916, "mimi"), "yum", t_2068);
return default;
}, 1, "love", true)).V).Put("puddles", NewObj(8).Put("chewMs", ((V)(100D))).Put("chewN", ((V)(1.1))).Put("open", ((V)(0.6))).Put("crumbs", ((V)(2D))).Put("txt", ((V)("Dabbles at it with her bill, gulps it down; quacks and waggles her tail when she likes it."))).Put("post", Fn((V _arrowThis2077, int _argc2070, V t_2076, V _a2073, V _a2074, V _a2075, V[] _rest2071) => {
return Invoke(Invoke(t_2076, "to", ((V)(120D)), NewObj(2).Put("pitch", ((V)(0.2))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2085, int _argc2078, V t_2084, V _a2081, V _a2082, V _a2083, V[] _rest2079) => {
Invoke(t_2084, "to", ((V)(140D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(quack_1914, V.Undef, t_2084);
Call(swing_1906, V.Undef, t_2084, ((V)(700D)), ((V)(5D)), NewObj(1).Put("wag", ((V)(32D))).V);
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis2093, int _argc2086, V t_2092, V _a2089, V _a2090, V _a2091, V[] _rest2087) => {
Call(hearts_1911, V.Undef, t_2092, ((V)(2D)));
Invoke(Invoke(Invoke(Invoke(t_2092, "to", ((V)(100D)), NewObj(2).Put("armL", ((V)(100D))).Put("armR", ((V)(100D))).V, ((V)("o"))), "to", ((V)(140D)), NewObj(2).Put("armL", ((V)(25D))).Put("armR", ((V)(25D))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(2).Put("armL", ((V)(100D))).Put("armR", ((V)(100D))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Get(CARDS_1916, "puddles"), "yum", t_2092);
return default;
}, 1, "love", true)).V).Put("bean", NewObj(9).Put("chewMs", ((V)(130D))).Put("chewN", ((V)(0.7))).Put("open", ((V)(0.85))).Put("crumbs", ((V)(3D))).Put("txt", ((V)("Snorts at it excitedly and gobbles it in big messy bites; licks his nose and wiggles his butt when he likes it."))).Put("pre", Fn((V _arrowThis2101, int _argc2094, V t_2100, V _a2097, V _a2098, V _a2099, V[] _rest2095) => {
{
double i_2102 = 0;
i_2102 = 0D;
while (true) {
if (!((i_2102 < 2D))) break;
Invoke(Invoke(t_2100, "to", ((V)(80D)), NewObj(3).Put("sq", ((V)(0.05))).Put("pitch", ((V)(0.1))).Put("mw", ((V)(0.75))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(3).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
i_2102++;
}
}
return default;
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2111, int _argc2104, V t_2110, V _a2107, V _a2108, V _a2109, V[] _rest2105) => {
return Invoke(Invoke(Invoke(t_2110, "to", ((V)(150D)), NewObj(3).Put("tongue", ((V)(1D))).Put("open", ((V)(0.35))).Put("pitch", ((V)(0.12))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("tongue", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(3).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2119, int _argc2112, V t_2118, V _a2115, V _a2116, V _a2117, V[] _rest2113) => {
Invoke(t_2118, "to", ((V)(150D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(swing_1906, V.Undef, t_2118, ((V)(1000D)), ((V)(7D)), NewObj(3).Put("x", ((V)(1.4))).Put("tilt", ((V)(4D))).Put("wag", ((V)(40D))).V);
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis2127, int _argc2120, V t_2126, V _a2123, V _a2124, V _a2125, V[] _rest2121) => {
Call(hearts_1911, V.Undef, t_2126, ((V)(2D)));
Invoke(Get(CARDS_1916, "bean"), "yum", t_2126);
return default;
}, 1, "love", true)).V).Put("zippy", NewObj(8).Put("chewMs", ((V)(90D))).Put("chewN", ((V)(1.2))).Put("open", ((V)(0.6))).Put("crumbs", ((V)(2D))).Put("txt", ((V)("Grabs it quick, looks around in case anyone wants it, nibbles fast; dooks and bounces when he likes it."))).Put("pre", Fn((V _arrowThis2135, int _argc2128, V t_2134, V _a2131, V _a2132, V _a2133, V[] _rest2129) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_2134, "to", ((V)(90D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("hyaw", ((V)((-0.2)))).V, ((V)("io"))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(1).Put("hyaw", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("yum", Fn((V _arrowThis2143, int _argc2136, V t_2142, V _a2139, V _a2140, V _a2141, V[] _rest2137) => {
Invoke(t_2142, "to", ((V)(120D)), NewObj(3).Put("open", ((V)(0.35))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("o")));
{
double i_2144 = 0;
i_2144 = 0D;
while (true) {
if (!((i_2144 < 3D))) break;
Invoke(Invoke(t_2142, "to", ((V)(80D)), NewObj(2).Put("lift", ((V)(1.6))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(90D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("i")));
i_2144++;
}
}
Invoke(Invoke(t_2142, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(140D)), NewObj(2).Put("sq", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis2153, int _argc2146, V t_2152, V _a2149, V _a2150, V _a2151, V[] _rest2147) => {
Call(hearts_1911, V.Undef, t_2152, ((V)(2D)));
Call(jump_1905, V.Undef, t_2152, NewObj(6).Put("h", ((V)(10D))).Put("ant", ((V)(100D))).Put("up", ((V)(200D))).Put("c", ((V)(0.14))).Put("arm", ((V)(50D))).Put("spin", ((V)(360D))).V);
Invoke(Get(CARDS_1916, "zippy"), "yum", t_2152);
return default;
}, 1, "love", true)).V).Put("mango", NewObj(9).Put("chewMs", ((V)(170D))).Put("chewN", ((V)(0.8))).Put("open", ((V)(0.7))).Put("crumbs", ((V)(1D))).Put("txt", ((V)("Stalks it slowly with his tail tip twitching, a quick snap, slow chewing; licks his eye and grins when he likes it."))).Put("pre", Fn((V _arrowThis2161, int _argc2154, V t_2160, V _a2157, V _a2158, V _a2159, V[] _rest2155) => {
Invoke(Invoke(Invoke(t_2160, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)((-0.08)))).Put("ly", ((V)(0.5))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(7D)), NewObj(1).Put("wag", ((V)(10D))).V, NewObj(1).Put("wag", ((V)((-6D)))).V, ((V)("l"))), "to", ((V)(100D)), NewObj(3).Put("wag", ((V)(0D))).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2169, int _argc2162, V t_2168, V _a2165, V _a2166, V _a2167, V[] _rest2163) => {
return Call(lipLick_1910, V.Undef, t_2168);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2177, int _argc2170, V t_2176, V _a2173, V _a2174, V _a2175, V[] _rest2171) => {
Invoke(Invoke(Invoke(t_2176, "to", ((V)(300D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(5).Put("tongue", ((V)(1D))).Put("open", ((V)(0.3))).Put("pitch", ((V)(0.18))).Put("htilt", ((V)(8D))).Put("winkR", ((V)(1D))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(5).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io")));
Call(swing_1906, V.Undef, t_2176, ((V)(1400D)), ((V)(3D)), NewObj(1).Put("wag", ((V)(30D))).V);
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis2185, int _argc2178, V t_2184, V _a2181, V _a2182, V _a2183, V[] _rest2179) => {
Call(hearts_1911, V.Undef, t_2184, ((V)(2D)));
Invoke(Get(CARDS_1916, "mango"), "yum", t_2184);
return default;
}, 1, "love", true)).V).V;
Call(buildAll_1912, V.Undef, CARDS_1916);
return default;
}, 0, "boot", false)), V.Undef);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
