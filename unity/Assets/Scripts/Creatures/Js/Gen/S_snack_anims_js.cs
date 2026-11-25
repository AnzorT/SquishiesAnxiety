// snack-anims.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_snack_anims_js
    {

        public static void Run()
        {
Call(Named(boot_31 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
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
V land_20 = default;
V install_21 = default;
V KEYS_22 = default;
V natF_23 = default;
V CARDS_24 = default;
V para_25 = default;
V loopN_26 = default;
V blink2_27 = default;
V MOVES_28 = default;
V eyes_29 = default;
V DANCES_30 = default;
if (_self1.IsNullish) _self1 = GlobalV;
R_8 = Get(G("window"), "RiveRig");
if ((((!(Truthy(R_8)) || !(Truthy(Get(R_8, "PETLIB")))) || !(Truthy(Get(Get(R_8, "PETLIB"), "install")))) || !(Truthy(Get(R_8, "SOFT"))))) {
Call(G("setTimeout"), V.Undef, boot_31.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_8, "snackV"))) {
return default;
}
Set(R_8, "snackV", ((V)(1D)));
{ V _t32 = Get(R_8, "PETLIB");
if (_t32.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t32));
{ V _t33 = Get(_t32, "TL");
TL_9 = _t33; }
{ V _t34 = Get(_t32, "S");
S_10 = _t34; }
{ V _t35 = Get(_t32, "hand");
hand_11 = _t35; }
{ V _t36 = Get(_t32, "both");
both_12 = _t36; }
{ V _t37 = Get(_t32, "o");
o_13 = _t37; }
{ V _t38 = Get(_t32, "NOHANDS");
NOHANDS_14 = _t38; }
{ V _t39 = Get(_t32, "jump");
jump_15 = _t39; }
{ V _t40 = Get(_t32, "shake");
shake_16 = _t40; }
{ V _t41 = Get(_t32, "swing");
swing_17 = _t41; }
{ V _t42 = Get(_t32, "steps");
steps_18 = _t42; }
{ V _t43 = Get(_t32, "jelly");
jelly_19 = _t43; }
{ V _t44 = Get(_t32, "land");
land_20 = _t44; }
{ V _t45 = Get(_t32, "install");
install_21 = _t45; } }
KEYS_22 = Arr(((V)("mallow")), ((V)("bao")), ((V)("dunkie")), ((V)("frybo")), ((V)("bunbun")), ((V)("choco")), ((V)("scoop")), ((V)("boba")), ((V)("chefbun")));
Invoke(KEYS_22, "forEach", Fn((V _arrowThis53, int _argc46, V k_52, V _a49, V _a50, V _a51, V[] _rest47) => {
return Invoke(Get(R_8, "SOFT"), "add", k_52);
}, 1, "", true));
natF_23 = Fn((V _arrowThis62, int _argc54, V k_60, V J_61, V _a58, V _a59, V[] _rest55) => {
V t_63 = default;
V dip_64 = default;
V bw_65 = default;
double lead_66 = 0;
V turn_67 = default;
V e_68 = default;
J_61 = (J_61 is var _t69 && Truthy(_t69) ? _t69 : NewObj(0).V);
t_63 = Call(TL_9, V.Undef);
dip_64 = (Get(J_61, "dip").IsNullish ? ((V)(0.045)) : Get(J_61, "dip"));
bw_65 = (Get(J_61, "bend").IsNullish ? ((V)(5D)) : Get(J_61, "bend"));
lead_66 = (0.18 * ToNum(k_60));
turn_67 = Fn((V _arrowThis81, int _argc70, V T_76, V from_77, V to_78, V d1_79, V[] _rest71) => {
V s_82 = default;
double dir_83 = 0;
double bendTo_84 = 0;
V e1_85 = default;
V e2_86 = default;
V d2_80 = default;
d2_80 = (_argc70 > 4 ? _rest71[0] : V.Undef);
s_82 = (((V)(Sign((ToNum(to_78) - ToNum(from_77))))) is var _t87 && Truthy(_t87) ? _t87 : ((V)(1D)));
dir_83 = Sign(ToNum(to_78));
bendTo_84 = (((dir_83 * ToNum(bw_65)) * System.Math.Abs(ToNum(to_78))) / 0.6);
Invoke(Invoke(Invoke(Invoke(Invoke(t_63, "at", T_76), "to", ((V)(110D)), NewObj(1).Put("lx", ((V)((dir_83 * 0.9)))).V, ((V)("o"))), "e", ((V)("blink"))), "to", Add(d1_79, d2_80), NewObj(1).Put("hyaw", ((V)(((dir_83 * lead_66) + (ToNum(s_82) * 0.04))))).V, ((V)("o"))), "to", ((V)(420D)), NewObj(1).Put("hyaw", ((V)(((dir_83 * lead_66) * 0.35)))).V, ((V)("io")));
e1_85 = Get(t_63, "t");
Invoke(Invoke(Invoke(Invoke(t_63, "at", Add(T_76, ((V)(150D)))), "to", d1_79, NewObj(3).Put("turn", ((V)((ToNum(Add(from_77, to_78)) / 2D)))).Put("sq", dip_64).Put("tilt", ((V)((ToNum(s_82) * 1.5)))).V, ((V)("i"))), "to", d2_80, NewObj(3).Put("turn", Add(to_78, ((V)((ToNum(s_82) * 0.07))))).Put("sq", ((V)(((-ToNum(dip_64)) * 0.5)))).Put("tilt", ((V)(((-ToNum(s_82)) * 0.8)))).V, ((V)("o"))), "to", ((V)(330D)), NewObj(3).Put("turn", to_78).Put("sq", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io")));
e2_86 = Get(t_63, "t");
Invoke(Invoke(Invoke(t_63, "at", Add(T_76, ((V)(260D)))), "to", Add(d1_79, d2_80), NewObj(3).Put("bend", ((V)((bendTo_84 + (ToNum(s_82) * 1.5))))).Put("armL", ((V)((ToNum(s_82) * 8D)))).Put("armR", ((V)(((-ToNum(s_82)) * 8D)))).V, ((V)("io"))), "to", ((V)(380D)), NewObj(3).Put("bend", ((V)(bendTo_84))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return ((V)(Max(ToNum(e1_85), ToNum(e2_86), ToNum(Get(t_63, "t")))));
return default;
}, 5, "", true);
Invoke(t_63, "to", ((V)(1D)), NewObj(1).Put("lean", ((V)(0D))).V);
e_68 = Call(turn_67, V.Undef, ((V)(250D)), ((V)(0D)), ((V)(((-0.6) * ToNum(k_60)))), ((V)(170D)), ((V)(220D)));
e_68 = Call(turn_67, V.Undef, Add(e_68, ((V)(900D))), ((V)(((-0.6) * ToNum(k_60)))), ((V)((0.6 * ToNum(k_60)))), ((V)(210D)), ((V)(250D)));
e_68 = Call(turn_67, V.Undef, Add(e_68, ((V)(900D))), ((V)((0.6 * ToNum(k_60)))), ((V)(0D)), ((V)(170D)), ((V)(210D)));
Invoke(Invoke(t_63, "at", Add(e_68, ((V)(200D)))), "to", ((V)(300D)), NewObj(2).Put("lx", ((V)(0D))).Put("hyaw", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_63, "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.6))).Put("stretch", ((V)(0D))).V);
return default;
}, 2, "", true);
CARDS_24 = NewObj(9).Put("mallow", NewObj(3).Put("T", ((V)(1.15))).Put("b", ((V)(1.4))).Put("s", ((V)(1.1))).V).Put("bao", NewObj(3).Put("T", ((V)(1D))).Put("b", ((V)(1.25))).Put("s", ((V)(1D))).V).Put("dunkie", NewObj(3).Put("T", ((V)(0.92))).Put("b", ((V)(1.1))).Put("s", ((V)(1.25))).V).Put("frybo", NewObj(4).Put("T", ((V)(0.85))).Put("b", ((V)(1D))).Put("s", ((V)(1D))).Put("e", ((V)(1.3))).V).Put("bunbun", NewObj(3).Put("T", ((V)(0.95))).Put("b", ((V)(1.15))).Put("s", ((V)(1.05))).V).Put("choco", NewObj(3).Put("T", ((V)(1D))).Put("b", ((V)(0.85))).Put("s", ((V)(0.9))).V).Put("scoop", NewObj(3).Put("T", ((V)(1.05))).Put("b", ((V)(1.15))).Put("s", ((V)(1.1))).V).Put("boba", NewObj(3).Put("T", ((V)(0.95))).Put("b", ((V)(1.05))).Put("s", ((V)(1D))).V).Put("chefbun", NewObj(3).Put("T", ((V)(1D))).Put("b", ((V)(1.1))).Put("s", ((V)(1D))).V).V;
para_25 = Fn((V _arrowThis97, int _argc88, V t_94, V from_95, V fn_96, V _a93, V[] _rest89) => {
V e_98 = default;
e_98 = Get(t_94, "t");
Invoke(t_94, "at", from_95);
Call(fn_96, V.Undef, t_94);
return Invoke(t_94, "at", ((V)(Max(ToNum(e_98), ToNum(Get(t_94, "t"))))));
return default;
}, 3, "", true);
loopN_26 = Fn((V _arrowThis107, int _argc99, V t_105, V n_106, V _a103, V _a104, V[] _rest100) => {
return Object_assign(Invoke(t_105, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_105, "t")) * ToNum((n_106 is var _t108 && Truthy(_t108) ? _t108 : ((V)(3D)))))))).V);
}, 2, "", true);
blink2_27 = Fn((V _arrowThis116, int _argc109, V t_115, V _a112, V _a113, V _a114, V[] _rest110) => {
return Invoke(t_115, "e", ((V)("blink2")));
}, 1, "", true);
MOVES_28 = NewObj(9).Put("mallow", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis123, int _argc117, V _a119, V _a120, V _a121, V _a122, V[] _rest118) => {
V t_124 = default;
t_124 = Call(TL_9, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(t_124, "to", ((V)(420D)), NewObj(5).Put("sq", ((V)((-0.16)))).Put("lift", ((V)(2D))).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).Put("wide", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(200D)));
Invoke(t_124, "to", ((V)(260D)), NewObj(5).Put("sq", ((V)(0.2))).Put("lift", ((V)(0D))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).Put("wide", ((V)(0D))).V, ((V)("i")));
Call(land_20, V.Undef, t_124, ((V)(0.12)), ((V)(4D)), ((V)(300D)));
return Call(loopN_26, V.Undef, t_124);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Puffs up tall and fluffy with sparkles, then sinks back into a soft wobble.")))).Put("surprised", Arr(Call(Fn((V _arrowThis131, int _argc125, V _a127, V _a128, V _a129, V _a130, V[] _rest126) => {
V t_132 = default;
t_132 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_132, "wait", ((V)(150D))), "to", ((V)(100D)), NewObj(3).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(4).Put("sq", ((V)((-0.24)))).Put("lift", ((V)(4D))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("o"))), "wait", ((V)(500D))), "to", ((V)(1400D)), NewObj(7).Put("sq", ((V)(0.04))).Put("lift", ((V)(0D))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).Put("wide", ((V)(0.3))).Put("open", ((V)(0.1))).Put("mw", ((V)(1D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("blink"))), "to", ((V)(300D)), NewObj(3).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(300D)));
return Invoke(Invoke(t_132, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Puffs up big in surprise, then slowly deflates like memory foam.")))).Put("squish", Arr(Call(Fn((V _arrowThis139, int _argc133, V _a135, V _a136, V _a137, V _a138, V[] _rest134) => {
V t_140 = default;
t_140 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(t_140, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.44))).Put("hap", ((V)(0.9))).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).V, ((V)("io"))), "wait", ((V)(300D)));
Invoke(Invoke(t_140, "to", ((V)(1500D)), NewObj(5).Put("sq", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("smile", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_140);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed flat, then rises back slowly like memory foam.")))).Put("quirk", Arr(Call(Fn((V _arrowThis147, int _argc141, V _a143, V _a144, V _a145, V _a146, V[] _rest142) => {
V t_148 = default;
t_148 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_148, "to", ((V)(500D)), NewObj(6).Put("sq", ((V)((-0.12)))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("close", ((V)(0.8))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.9))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(300D)), NewObj(2).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io"))), "to", ((V)(900D)), NewObj(5).Put("sq", ((V)(0.08))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0.4))).Put("hap", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_148, "osc", ((V)(1200D)), ((V)(2D)), NewObj(2).Put("sq", ((V)(0.1))).Put("close", ((V)(0.6))).V, NewObj(2).Put("sq", ((V)(0.07))).Put("close", ((V)(0.4))).V, ((V)("s"))), "to", ((V)(400D)), NewObj(4).Put("sq", ((V)(0D))).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_148, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Cosy stretch")), ((V)("A big tall stretch and yawn, then sinks down cosy and breathes slowly.")))).Put("press", NewObj(1).Put("hap", ((V)(0.5))).V).Put("rel", NewObj(2).Put("dur", ((V)(1700D))).Put("k", NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(0.22)), ((V)("o"))), Arr(((V)(1500D)), ((V)(0.02)), ((V)("o"))), Arr(((V)(1700D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(1D)), ((V)("io"))), Arr(((V)(1300D)), ((V)(1D))), Arr(((V)(1700D)), ((V)(0D)), ((V)("io"))))).V).V).V).Put("bao", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis155, int _argc149, V _a151, V _a152, V _a153, V _a154, V[] _rest150) => {
V t_156 = default;
t_156 = Call(TL_9, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Call(jump_15, V.Undef, t_156, NewObj(7).Put("h", ((V)(7D))).Put("ant", ((V)(180D))).Put("up", ((V)(220D))).Put("c", ((V)(0.2))).Put("arm", ((V)(40D))).Put("chain", (true ? V.True : V.False)).Put("ev", Arr(Arr(((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D))))).V);
Call(land_20, V.Undef, t_156, ((V)(0.08)), ((V)(2D)), ((V)(240D)));
Call(jump_15, V.Undef, t_156, NewObj(6).Put("h", ((V)(8D))).Put("ant", ((V)(160D))).Put("up", ((V)(230D))).Put("c", ((V)(0.2))).Put("arm", ((V)(46D))).Put("ev", Arr(Arr(((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D))))).V);
return Call(loopN_26, V.Undef, t_156);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Pillowy hops with little puffs of steam from his knot.")))).Put("surprised", Arr(Call(Fn((V _arrowThis163, int _argc157, V _a159, V _a160, V _a161, V _a162, V[] _rest158) => {
V t_164 = default;
t_164 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_164, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(3).Put("wide", ((V)(1D))).Put("sq", ((V)(0.1))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(4).Put("sq", ((V)((-0.18)))).Put("lift", ((V)(6D))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(6D))), "to", ((V)(220D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.14))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_164, "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(7).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_164, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Steam bursts out of his knot like a kettle, a little hop, then he looks around.")))).Put("squish", Arr(Call(Fn((V _arrowThis171, int _argc165, V _a167, V _a168, V _a169, V _a170, V[] _rest166) => {
V t_172 = default;
t_172 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_172, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.4))).Put("hap", ((V)(0.9))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(4D))), "wait", ((V)(300D)));
Invoke(t_172, "to", ((V)(120D)), NewObj(6).Put("sq", ((V)((-0.18)))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_19, V.Undef, t_172, ((V)(0.1)), ((V)(3D)), ((V)(260D)));
Invoke(t_172, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_172);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("A pillowy squash that puffs steam out of his knot, then a soft bounce back.")))).Put("quirk", Arr(Call(Fn((V _arrowThis179, int _argc173, V _a175, V _a176, V _a177, V _a178, V[] _rest174) => {
V t_180 = default;
t_180 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(t_180, "to", ((V)(300D)), NewObj(3).Put("pitch", ((V)(0.1))).Put("ly", ((V)((-0.9)))).Put("lx", ((V)(0.1))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D))), "wait", ((V)(500D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_180, "to", ((V)(250D)), NewObj(2).Put("sq", ((V)(0.05))).Put("puff", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(4).Put("puff", ((V)((-0.3)))).Put("open", ((V)(0.4))).Put("mw", ((V)(0.5))).Put("sq", ((V)((-0.03)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(4).Put("puff", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(5).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("lx", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Invoke(t_180, "osc", ((V)(800D)), ((V)(2D)), NewObj(1).Put("tilt", ((V)(3D))).V, NewObj(1).Put("tilt", ((V)((-3D)))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_180, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Steam puff")), ((V)("Looks up at the steam rising from his knot and blows a little puff, pleased with himself.")))).Put("press", NewObj(1).Put("puff", ((V)(0.3))).V).Put("rel", NewObj(3).Put("dur", ((V)(1100D))).Put("k", NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.18))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.09)), ((V)("io"))), Arr(((V)(390D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(800D)), ((V)(1D))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("steam")), ((V)("head")), ((V)(4D))))).V).V).Put("dunkie", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis187, int _argc181, V _a183, V _a184, V _a185, V _a186, V[] _rest182) => {
V t_188 = default;
t_188 = Call(TL_9, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Call(swing_17, V.Undef, t_188, ((V)(1400D)), ((V)(3D)), NewObj(3).Put("tilt", ((V)(12D))).Put("x", ((V)(3D))).Put("lean", ((V)(2D))).V, ((V)("io")));
Call(jump_15, V.Undef, t_188, NewObj(6).Put("h", ((V)(7D))).Put("ant", ((V)(150D))).Put("up", ((V)(210D))).Put("c", ((V)(0.16))).Put("arm", ((V)(40D))).Put("ev", Arr(Arr(((V)("emit")), ((V)("sprinkle")), ((V)("head")), ((V)(3D))))).V);
return Call(loopN_26, V.Undef, t_188);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Rocks side to side like a rolling wheel, then hops with sprinkles flying.")))).Put("surprised", Arr(Call(Fn((V _arrowThis195, int _argc189, V _a191, V _a192, V _a193, V _a194, V[] _rest190) => {
V t_196 = default;
t_196 = Call(TL_9, V.Undef);
Invoke(Invoke(t_196, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(4).Put("wide", ((V)(1D))).Put("sq", ((V)(0.1))).Put("open", ((V)(0.45))).Put("mw", ((V)(0.7))).V, ((V)("o")));
Call(jump_15, V.Undef, t_196, NewObj(9).Put("h", ((V)(8D))).Put("ant", ((V)(60D))).Put("up", ((V)(210D))).Put("c", ((V)(0.08))).Put("arm", ((V)(50D))).Put("x", ((V)((-5D)))).Put("air", NewObj(1).Put("tilt", ((V)((-10D)))).V).Put("fall", NewObj(1).Put("tilt", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("sprinkle")), ((V)("head")), ((V)(5D))))).V);
Invoke(Invoke(Invoke(Invoke(t_196, "wait", ((V)(200D))), "to", ((V)(400D)), NewObj(3).Put("lx", ((V)(0.7))).Put("ly", ((V)((-0.6)))).Put("htilt", ((V)(6D))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(400D)), NewObj(1).Put("htilt", ((V)((-4D)))).V, ((V)("io")));
Invoke(t_196, "to", ((V)(500D)), NewObj(9).Put("x", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("htilt", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_196, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Jumps back with sprinkles flying off, then checks his bite mark.")))).Put("squish", Arr(Call(Fn((V _arrowThis203, int _argc197, V _a199, V _a200, V _a201, V _a202, V[] _rest198) => {
V t_204 = default;
t_204 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_204, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(4).Put("sq", ((V)(0.38))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("body")), ((V)(4D))), "wait", ((V)(300D)));
Invoke(Invoke(t_204, "to", ((V)(120D)), NewObj(6).Put("sq", ((V)((-0.18)))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("sprinkle")), ((V)("head")), ((V)(4D)));
Call(jelly_19, V.Undef, t_204, ((V)(0.08)), ((V)(3D)), ((V)(230D)));
Invoke(t_204, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_204);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("A crunchy squash with crumbs, springs back and sprinkles fly.")))).Put("quirk", Arr(Call(Fn((V _arrowThis211, int _argc205, V _a207, V _a208, V _a209, V _a210, V[] _rest206) => {
V t_212 = default;
t_212 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(t_212, "to", ((V)(400D)), NewObj(4).Put("lx", ((V)(0.8))).Put("ly", ((V)((-0.7)))).Put("htilt", ((V)(8D))).Put("hyaw", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(400D))), "e", ((V)("blink")));
Invoke(Invoke(Invoke(Invoke(t_212, "to", ((V)(300D)), NewObj(2).Put("frown", ((V)(0.3))).Put("puff", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(320D)), NewObj(2).Put("armR", ((V)(138D))).Put("bend", ((V)((-2D)))).V, ((V)("io"))), "osc", ((V)(560D)), ((V)(2D)), NewObj(1).Put("armR", ((V)(122D))).V, NewObj(1).Put("armR", ((V)(138D))).V, ((V)("io"))), "to", ((V)(320D)), NewObj(8).Put("armR", ((V)(0D))).Put("bend", ((V)(0D))).Put("frown", ((V)(0D))).Put("puff", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hyaw", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_212, "to", ((V)(250D)), NewObj(5).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("sq", ((V)(0.04))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_212, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Bite check")), ((V)("Looks up at his bite mark, pats it, then shrugs and smiles.")))).Put("press", NewObj(1).Put("hap", ((V)(0.4))).V).Put("rel", NewObj(3).Put("dur", ((V)(1000D))).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.2))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.1)), ((V)("io"))), Arr(((V)(390D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(3D)), ((V)("o"))), Arr(((V)(270D)), ((V)(0D)), ((V)("i"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(700D)), ((V)(1D))), Arr(((V)(1000D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("sprinkle")), ((V)("head")), ((V)(4D))))).V).V).Put("frybo", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis219, int _argc213, V _a215, V _a216, V _a217, V _a218, V[] _rest214) => {
V t_220 = default;
V a_221 = default;
t_220 = Call(TL_9, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).V);
a_221 = Get(t_220, "t");
Call(jump_15, V.Undef, t_220, NewObj(8).Put("h", ((V)(8D))).Put("ant", ((V)(130D))).Put("up", ((V)(180D))).Put("c", ((V)(0.14))).Put("arm", ((V)(50D))).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(2).Put("earL", ((V)((-14D)))).Put("earR", ((V)((-14D)))).V).Put("fall", NewObj(2).Put("earL", ((V)(6D))).Put("earR", ((V)(6D))).V).V);
Call(jump_15, V.Undef, t_220, NewObj(8).Put("h", ((V)(8D))).Put("ant", ((V)(110D))).Put("up", ((V)(180D))).Put("c", ((V)(0.14))).Put("arm", ((V)(50D))).Put("air", NewObj(2).Put("earL", ((V)((-14D)))).Put("earR", ((V)((-14D)))).V).Put("fall", NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("salt")), ((V)("head")), ((V)(4D))))).V);
Call(para_25, V.Undef, t_220, a_221, Fn((V _arrowThis229, int _argc222, V u_228, V _a225, V _a226, V _a227, V[] _rest223) => {
return Invoke(u_228, "to", ((V)((ToNum(Get(t_220, "t")) - ToNum(a_221)))), NewObj(1).Put("fw", ((V)(1.2))).V, ((V)("io")));
}, 1, "", true));
Invoke(t_220, "to", ((V)(300D)), NewObj(1).Put("fw", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_220);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Two quick hops with his fries fanning up and waving, a sprinkle of salt.")))).Put("surprised", Arr(Call(Fn((V _arrowThis236, int _argc230, V _a232, V _a233, V _a234, V _a235, V[] _rest231) => {
V t_237 = default;
t_237 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_237, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(6).Put("wide", ((V)(1D))).Put("sq", ((V)(0.08))).Put("earL", ((V)((-22D)))).Put("earR", ((V)((-22D)))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(5D))).Put("sq", ((V)((-0.12)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(600D)));
Invoke(Invoke(t_237, "to", ((V)(500D)), NewObj(4).Put("earL", ((V)(8D))).Put("earR", ((V)(8D))).Put("open", ((V)(0.1))).Put("mw", ((V)(1D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("wide", ((V)(0.3))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_237, "to", ((V)(400D)), NewObj(1).Put("lx", ((V)((-0.7)))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(400D)), NewObj(1).Put("lx", ((V)(0.7))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(4).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_237, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His fries shoot straight up like hair standing on end, then flop back down.")))).Put("squish", Arr(Call(Fn((V _arrowThis244, int _argc238, V _a240, V _a241, V _a242, V _a243, V[] _rest239) => {
V t_245 = default;
t_245 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(t_245, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(7).Put("sq", ((V)(0.36))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).Put("earL", ((V)(12D))).Put("earR", ((V)(12D))).Put("fw", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(300D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_245, "to", ((V)(110D)), NewObj(8).Put("sq", ((V)((-0.2)))).Put("earL", ((V)((-16D)))).Put("earR", ((V)((-16D)))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("salt")), ((V)("head")), ((V)(4D))), "to", ((V)(160D)), NewObj(3).Put("sq", ((V)(0.07))).Put("earL", ((V)(4D))).Put("earR", ((V)(4D))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(3).Put("sq", ((V)((-0.02)))).Put("earL", ((V)((-2D)))).Put("earR", ((V)((-2D)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(8).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("fw", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_245);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("His fries squeeze together with a crispy rustle, then pop back up with a sprinkle of salt.")))).Put("quirk", Arr(Call(Fn((V _arrowThis252, int _argc246, V _a248, V _a249, V _a250, V _a251, V[] _rest247) => {
V t_253 = default;
t_253 = Call(TL_9, V.Undef);
Invoke(t_253, "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.06))).Put("close", ((V)(0.6))).V, ((V)("io")));
Call(shake_16, V.Undef, t_253, NewObj(7).Put("P", ((V)(85D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.9)), ((V)(0.6)), ((V)(0.3)))).Put("head", ((V)(0.1))).Put("roll", ((V)(3D))).Put("ear", ((V)(16D))).Put("chest", ((V)(0.05))).Put("body", ((V)(0.8))).V);
Invoke(Invoke(t_253, "e", ((V)("emit")), ((V)("salt")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(2).Put("sq", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_253, "to", ((V)(400D)), NewObj(4).Put("armL", ((V)(142D))).Put("armR", ((V)(142D))).Put("ly", ((V)((-0.8)))).Put("sq", ((V)((-0.04)))).V, ((V)("io"))), "osc", ((V)(640D)), ((V)(2D)), NewObj(5).Put("armL", ((V)(124D))).Put("armR", ((V)(124D))).Put("earL", ((V)((-7D)))).Put("earR", ((V)((-7D)))).Put("fw", ((V)(0.8))).V, NewObj(5).Put("armL", ((V)(142D))).Put("armR", ((V)(142D))).Put("earL", ((V)(2D))).Put("earR", ((V)(2D))).Put("fw", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(380D)), NewObj(9).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("fw", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_253, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Fry fluff")), ((V)("Shakes his box so the fries rustle and settle, a sprinkle of salt, then fluffs his fries with both paws.")))).Put("press", NewObj(3).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).Put("fw", ((V)(0.6))).V).Put("rel", NewObj(3).Put("dur", ((V)(1000D))).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)((-0.2))), ((V)("o"))), Arr(((V)(240D)), ((V)(0.08)), ((V)("io"))), Arr(((V)(380D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(520D)), ((V)(0D)), ((V)("io"))))).Put("earL", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)((-16D))), ((V)("o"))), Arr(((V)(280D)), ((V)(6D)), ((V)("io"))), Arr(((V)(460D)), ((V)((-2D))), ((V)("io"))), Arr(((V)(620D)), ((V)(0D)), ((V)("io"))))).Put("earR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)((-16D))), ((V)("o"))), Arr(((V)(280D)), ((V)(6D)), ((V)("io"))), Arr(((V)(460D)), ((V)((-2D))), ((V)("io"))), Arr(((V)(620D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("salt")), ((V)("head")), ((V)(3D))))).V).V).Put("bunbun", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis260, int _argc254, V _a256, V _a257, V _a258, V _a259, V[] _rest255) => {
V t_261 = default;
t_261 = Call(TL_9, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).V);
Call(jump_15, V.Undef, t_261, NewObj(7).Put("h", ((V)(9D))).Put("ant", ((V)(150D))).Put("up", ((V)(220D))).Put("c", ((V)(0.16))).Put("arm", ((V)(45D))).Put("air", NewObj(1).Put("split", ((V)(0.5))).V).Put("fall", NewObj(1).Put("split", ((V)(0D))).V).V);
Call(swing_17, V.Undef, t_261, ((V)(1000D)), ((V)(3D)), NewObj(2).Put("fan", ((V)(0.6))).Put("tilt", ((V)(4D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_261);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A hop where his layers lift apart in the air and stack back, then a happy fan sway.")))).Put("surprised", Arr(Call(Fn((V _arrowThis268, int _argc262, V _a264, V _a265, V _a266, V _a267, V[] _rest263) => {
V t_269 = default;
t_269 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_269, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(4).Put("wide", ((V)(1D))).Put("open", ((V)(0.45))).Put("mw", ((V)(0.7))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(3).Put("split", ((V)(1.1))).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.08)))).V, ((V)("o"))), "wait", ((V)(350D))), "to", ((V)(140D)), NewObj(3).Put("split", ((V)(0D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.16))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(3D))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_269, "wait", ((V)(200D))), "to", ((V)(300D)), NewObj(1).Put("lx", ((V)((-0.7)))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(1).Put("lx", ((V)(0.7))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(6).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_269, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His layers jump apart in fright and slam back together into a stack.")))).Put("squish", Arr(Call(Fn((V _arrowThis276, int _argc270, V _a272, V _a273, V _a274, V _a275, V[] _rest271) => {
V t_277 = default;
t_277 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_277, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(5).Put("sq", ((V)(0.4))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).Put("fan", ((V)(0.4))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("note")), ((V)("head")), ((V)(1D))), "wait", ((V)(300D)));
Invoke(t_277, "to", ((V)(120D)), NewObj(7).Put("sq", ((V)((-0.18)))).Put("fan", ((V)((-0.3)))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o")));
Call(jelly_19, V.Undef, t_277, ((V)(0.1)), ((V)(3D)), ((V)(230D)));
Invoke(t_277, "to", ((V)(220D)), NewObj(5).Put("fan", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_277);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("His stack squashes with a squeaky-cheese squeak, the layers fan out and wobble back.")))).Put("quirk", Arr(Call(Fn((V _arrowThis284, int _argc278, V _a280, V _a281, V _a282, V _a283, V[] _rest279) => {
V t_285 = default;
t_285 = Call(TL_9, V.Undef);
Invoke(t_285, "to", ((V)(400D)), NewObj(2).Put("ly", ((V)(0.8))).Put("pitch", ((V)((-0.2)))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_285, "to", ((V)(300D)), NewObj(1).Put("shuf", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("shuf", ((V)((-0.8)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("shuf", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("shuf", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_285, "to", ((V)(260D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(10D)), ((V)(2D))), NewObj(2).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).V), ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(2).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).V, NewObj(2).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_13, V.Undef, NOHANDS_14, NewObj(6).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io")));
return Invoke(Invoke(Invoke(t_285, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Restack")), ((V)("Looks down at his stack, the layers shuffle like cards, and he pats them back into a neat burger.")))).Put("press", NewObj(1).Put("fan", ((V)(0.3))).V).Put("rel", NewObj(3).Put("dur", ((V)(1100D))).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.18))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.1)), ((V)("io"))), Arr(((V)(390D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))))).Put("split", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(0.5)), ((V)("o"))), Arr(((V)(400D)), ((V)(0D)), ((V)("i"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(800D)), ((V)(1D))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("note")), ((V)("head")), ((V)(1D))))).V).V).Put("choco", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis292, int _argc286, V _a288, V _a289, V _a290, V _a291, V[] _rest287) => {
V t_293 = default;
t_293 = Call(TL_9, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(t_293, "to", ((V)(200D)), NewObj(1).Put("tw", ((V)(1.2))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D)));
Call(jump_15, V.Undef, t_293, NewObj(5).Put("h", ((V)(7D))).Put("ant", ((V)(140D))).Put("up", ((V)(200D))).Put("c", ((V)(0.1))).Put("arm", ((V)(50D))).V);
Invoke(t_293, "to", ((V)(400D)), NewObj(1).Put("tw", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_293);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("His segments twinkle and he does a crisp little hop.")))).Put("surprised", Arr(Call(Fn((V _arrowThis300, int _argc294, V _a296, V _a297, V _a298, V _a299, V[] _rest295) => {
V t_301 = default;
t_301 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_301, "wait", ((V)(150D))), "to", ((V)(60D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.45))).Put("mw", ((V)(0.7))).Put("sq", ((V)((-0.06)))).Put("tw", ((V)(1.4))).Put("lift", ((V)(2D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "wait", ((V)(500D))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("tw", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_301, "to", ((V)(900D)), NewObj(4).Put("melt", ((V)(0.5))).Put("sq", ((V)(0.08))).Put("wide", ((V)(0.4))).Put("frown", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(8).Put("melt", ((V)(0D))).Put("sq", ((V)(0D))).Put("frown", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("o")));
return Invoke(Invoke(t_301, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Snaps stiff with his segments flashing, goes a little gooey, then pulls himself together.")))).Put("squish", Arr(Call(Fn((V _arrowThis308, int _argc302, V _a304, V _a305, V _a306, V _a307, V[] _rest303) => {
V t_309 = default;
t_309 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(t_309, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(3).Put("sq", ((V)(0.3))).Put("melt", ((V)(0.8))).Put("hap", ((V)(0.9))).V, ((V)("io"))), "wait", ((V)(350D)));
Invoke(Invoke(Invoke(Invoke(t_309, "to", ((V)(120D)), NewObj(6).Put("sq", ((V)((-0.12)))).Put("melt", ((V)(0D))).Put("tw", ((V)(1D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0.04))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(4).Put("sq", ((V)(0D))).Put("tw", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_309);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Melts into a gooey puddle when squashed, then snaps back into shape.")))).Put("quirk", Arr(Call(Fn((V _arrowThis316, int _argc310, V _a312, V _a313, V _a314, V _a315, V[] _rest311) => {
V t_317 = default;
t_317 = Call(TL_9, V.Undef);
Invoke(Invoke(t_317, "to", ((V)(1200D)), NewObj(4).Put("melt", ((V)(0.45))).Put("sq", ((V)(0.06))).Put("close", ((V)(0.5))).Put("hap", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(300D)));
Invoke(t_317, "to", ((V)(150D)), NewObj(2).Put("wide", ((V)(0.8))).Put("close", ((V)(0D))).V, ((V)("o")));
Call(shake_16, V.Undef, t_317, NewObj(6).Put("P", ((V)(80D))).Put("env", Arr(((V)(0.5)), ((V)(1D)), ((V)(0.8)), ((V)(0.4)))).Put("head", ((V)(0.12))).Put("roll", ((V)(3D))).Put("ear", ((V)(0D))).Put("body", ((V)(0.6))).V);
Invoke(Invoke(t_317, "to", ((V)(200D)), NewObj(3).Put("melt", ((V)(0D))).Put("sq", ((V)((-0.04)))).Put("tw", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(5).Put("sq", ((V)(0D))).Put("tw", ((V)(0D))).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_317, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Melty moment")), ((V)("Slowly starts to melt in the warmth, notices, shakes it off and firms back up.")))).Put("press", NewObj(1).Put("melt", ((V)(0.6))).V).Put("rel", NewObj(3).Put("dur", ((V)(900D))).Put("k", NewObj(3).Put("melt", Arr(Arr(((V)(0D)), ((V)(0.4))), Arr(((V)(180D)), ((V)(0D)), ((V)("o"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)((-0.14))), ((V)("o"))), Arr(((V)(240D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(380D)), ((V)(0D)), ((V)("io"))))).Put("tw", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)(1.1)), ((V)("o"))), Arr(((V)(600D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("spark")), ((V)("head")), ((V)(2D))))).V).V).Put("scoop", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis324, int _argc318, V _a320, V _a321, V _a322, V _a323, V[] _rest319) => {
V t_325 = default;
V a_326 = default;
t_325 = Call(TL_9, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
a_326 = Get(t_325, "t");
Call(swing_17, V.Undef, t_325, ((V)(1400D)), ((V)(3D)), NewObj(3).Put("tilt", ((V)(6D))).Put("x", ((V)(1.5))).Put("bend", ((V)(3D))).V, ((V)("io")));
Call(para_25, V.Undef, t_325, a_326, Fn((V _arrowThis334, int _argc327, V u_333, V _a330, V _a331, V _a332, V[] _rest328) => {
return Invoke(u_333, "osc", ((V)(1400D)), ((V)(4D)), NewObj(1).Put("chb", ((V)(1D))).V, NewObj(1).Put("chb", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
Invoke(Invoke(Invoke(t_325, "to", ((V)(150D)), NewObj(1).Put("chy", ((V)(1D))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("chy", ((V)(0D))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
return Call(loopN_26, V.Undef, t_325);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Sways side to side with his cherry bopping, then the cherry pops up and lands with a heart.")))).Put("surprised", Arr(Call(Fn((V _arrowThis341, int _argc335, V _a337, V _a338, V _a339, V _a340, V[] _rest336) => {
V t_342 = default;
t_342 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_342, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(4).Put("wide", ((V)(1D))).Put("open", ((V)(0.45))).Put("mw", ((V)(0.7))).Put("sq", ((V)(0.08))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(2).Put("chy", ((V)(1.2))).Put("sq", ((V)((-0.1)))).V, ((V)("o"))), "wait", ((V)(150D))), "to", ((V)(300D)), NewObj(2).Put("chy", ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(t_342, "to", ((V)(200D)), NewObj(1).Put("close", ((V)(0.4))).V, ((V)("io")));
Call(shake_16, V.Undef, t_342, NewObj(6).Put("P", ((V)(70D))).Put("env", Arr(((V)(0.4)), ((V)(0.8)), ((V)(1D)), ((V)(0.8)), ((V)(0.5)), ((V)(0.25)))).Put("head", ((V)(0.1))).Put("roll", ((V)(2D))).Put("ear", ((V)(0D))).Put("body", ((V)(0.6))).V);
Invoke(t_342, "to", ((V)(400D)), NewObj(6).Put("close", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_342, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His cherry jumps up off his head and lands back, then a cold little shiver.")))).Put("squish", Arr(Call(Fn((V _arrowThis349, int _argc343, V _a345, V _a346, V _a347, V _a348, V[] _rest344) => {
V t_350 = default;
t_350 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(t_350, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.4))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "wait", ((V)(300D)));
Invoke(Invoke(t_350, "to", ((V)(110D)), NewObj(7).Put("sq", ((V)((-0.18)))).Put("chy", ((V)(0.8))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(1).Put("chy", ((V)(0D))).V, ((V)("i")));
Call(jelly_19, V.Undef, t_350, ((V)(0.1)), ((V)(3D)), ((V)(240D)));
Invoke(t_350, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_350);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("His soft scoop squishes on the cone, then springs back and the cherry pops up.")))).Put("quirk", Arr(Call(Fn((V _arrowThis357, int _argc351, V _a353, V _a354, V _a355, V _a356, V[] _rest352) => {
V t_358 = default;
t_358 = Call(TL_9, V.Undef);
Invoke(Invoke(t_358, "to", ((V)(400D)), NewObj(3).Put("lx", ((V)(0.2))).Put("ly", ((V)((-0.9)))).Put("pitch", ((V)(0.15))).V, ((V)("io"))), "wait", ((V)(200D)));
Invoke(t_358, "osc", ((V)(900D)), ((V)(3D)), NewObj(2).Put("chb", ((V)(1.2))).Put("htilt", ((V)(3D))).V, NewObj(2).Put("chb", ((V)(0D))).Put("htilt", ((V)((-3D)))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_358, "to", ((V)(150D)), NewObj(1).Put("chy", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("chy", ((V)(0D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(6).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("lx", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_358, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Cherry flip")), ((V)("Looks up at his cherry, wiggles it, then flips it up and catches it.")))).Put("press", NewObj(1).Put("chb", ((V)(0.6))).V).Put("rel", NewObj(2).Put("dur", ((V)(1000D))).Put("k", NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.18))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.09)), ((V)("io"))), Arr(((V)(390D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))))).Put("chy", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(0.9)), ((V)("o"))), Arr(((V)(380D)), ((V)(0D)), ((V)("i"))))).V).V).V).Put("boba", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis365, int _argc359, V _a361, V _a362, V _a363, V _a364, V[] _rest360) => {
V t_366 = default;
V a_367 = default;
t_366 = Call(TL_9, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
a_367 = Get(t_366, "t");
Call(jump_15, V.Undef, t_366, NewObj(6).Put("h", ((V)(8D))).Put("ant", ((V)(140D))).Put("up", ((V)(200D))).Put("c", ((V)(0.14))).Put("arm", ((V)(45D))).Put("chain", (true ? V.True : V.False)).V);
Call(jump_15, V.Undef, t_366, NewObj(5).Put("h", ((V)(8D))).Put("ant", ((V)(120D))).Put("up", ((V)(200D))).Put("c", ((V)(0.14))).Put("arm", ((V)(45D))).V);
Call(para_25, V.Undef, t_366, a_367, Fn((V _arrowThis375, int _argc368, V u_374, V _a371, V _a372, V _a373, V[] _rest369) => {
return Invoke(Invoke(u_374, "to", ((V)(300D)), NewObj(3).Put("pop", ((V)(1.5))).Put("swirl", ((V)(1.5))).Put("stw", ((V)(1D))).V, ((V)("o"))), "to", ((V)(((ToNum(Get(t_366, "t")) - ToNum(a_367)) - 300D))), NewObj(1).Put("pop", ((V)(0.4))).V, ((V)("io")));
}, 1, "", true));
Invoke(t_366, "to", ((V)(400D)), NewObj(3).Put("pop", ((V)(0D))).Put("swirl", ((V)(0D))).Put("stw", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_366);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Bouncy hops with his pearls popping and swirling and his straw wiggling.")))).Put("surprised", Arr(Call(Fn((V _arrowThis382, int _argc376, V _a378, V _a379, V _a380, V _a381, V[] _rest377) => {
V t_383 = default;
t_383 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_383, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.45))).Put("mw", ((V)(0.7))).Put("sq", ((V)(0.08))).Put("sup", ((V)(1.4))).Put("pop", ((V)(2D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.1)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0D))).Put("pop", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(400D)));
Invoke(Invoke(Invoke(Invoke(t_383, "to", ((V)(500D)), NewObj(3).Put("sup", ((V)(0D))).Put("pop", ((V)(0D))).Put("wide", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("lx", ((V)((-0.7)))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(6).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_383, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His straw shoots up and the pearls jump, then everything settles back down.")))).Put("squish", Arr(Call(Fn((V _arrowThis390, int _argc384, V _a386, V _a387, V _a388, V _a389, V[] _rest385) => {
V t_391 = default;
t_391 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(t_391, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(5).Put("sq", ((V)(0.36))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).Put("slurp", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(400D)));
Invoke(Invoke(Invoke(Invoke(t_391, "to", ((V)(110D)), NewObj(7).Put("sq", ((V)((-0.16)))).Put("slurp", ((V)(0D))).Put("sup", ((V)(0.8))).Put("pop", ((V)(1.5))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(2).Put("sup", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(6).Put("sq", ((V)(0D))).Put("pop", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_391);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed, a pearl rides up his straw and pops out the top with bubbles.")))).Put("quirk", Arr(Call(Fn((V _arrowThis398, int _argc392, V _a394, V _a395, V _a396, V _a397, V[] _rest393) => {
V t_399 = default;
t_399 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_399, "to", ((V)(350D)), NewObj(3).Put("lx", ((V)(0.3))).Put("ly", ((V)((-0.8)))).Put("pitch", ((V)(0.1))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("slurp", ((V)(1D))).Put("mw", ((V)(0.5))).Put("open", ((V)(0.1))).V, ((V)("io"))), "wait", ((V)(900D))), "to", ((V)(200D)), NewObj(4).Put("slurp", ((V)(0D))).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).Put("puff", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("io"))), "e", ((V)("gulp")));
Invoke(Invoke(Invoke(t_399, "to", ((V)(300D)), NewObj(7).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("lx", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("swirl", ((V)(1.5))).V, ((V)("io"))), "wait", ((V)(600D))), "to", ((V)(400D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_399, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Slurp")), ((V)("Sips from his own straw (a pearl rides up), gulps, and his pearls swirl happily.")))).Put("press", NewObj(2).Put("slurp", ((V)(0.8))).Put("pop", ((V)(0.6))).V).Put("rel", NewObj(3).Put("dur", ((V)(1000D))).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.16))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.07)), ((V)("io"))), Arr(((V)(390D)), ((V)((-0.02))), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))))).Put("sup", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(0.8)), ((V)("o"))), Arr(((V)(500D)), ((V)(0D)), ((V)("io"))))).Put("pop", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)(1.5)), ((V)("o"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("bubble")), ((V)("head")), ((V)(2D))))).V).V).Put("chefbun", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis406, int _argc400, V _a402, V _a403, V _a404, V _a405, V[] _rest401) => {
V t_407 = default;
t_407 = Call(TL_9, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.25))).V);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_407, "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-15D)))), NewObj(2).Put("armR", ((V)(20D))).Put("close", ((V)(0.9))).V), ((V)("io"))), "to", ((V)(140D)), NewObj(3).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).Put("puff", ((V)((-0.2)))).V, ((V)("o"))), "to", ((V)(220D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)((-4D))), ((V)((-10D)))), NewObj(4).Put("armR", ((V)(80D))).Put("open", ((V)(0.25))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).V), ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("pawR")), ((V)(3D))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(300D))), "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D))), NewObj(2).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).V), ((V)("io")));
Call(jump_15, V.Undef, t_407, NewObj(5).Put("h", ((V)(5D))).Put("ant", ((V)(140D))).Put("up", ((V)(180D))).Put("c", ((V)(0.12))).Put("arm", ((V)(30D))).V);
return Call(loopN_26, V.Undef, t_407);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A chef's kiss - fingers to his lips and flung open with sparkles - then a proud little hop.")))).Put("surprised", Arr(Call(Fn((V _arrowThis414, int _argc408, V _a410, V _a411, V _a412, V _a413, V[] _rest409) => {
V t_415 = default;
t_415 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_415, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(4).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("sq", ((V)(0.08))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(4).Put("lift", ((V)(5D))).Put("sq", ((V)((-0.12)))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i")));
Invoke(Invoke(Invoke(t_415, "to", ((V)(300D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)((-4D))), ((V)((-30D)))), NewObj(4).Put("sq", ((V)(0D))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("htilt", ((V)(4D))).V), ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(3).Put("htilt", ((V)(6D))).Put("armL", ((V)(142D))).Put("armR", ((V)(142D))).V, NewObj(3).Put("htilt", ((V)(2D))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).V, ((V)("io"))), "to", ((V)(350D)), Call(o_13, V.Undef, NOHANDS_14, NewObj(8).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("htilt", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io")));
return Invoke(Invoke(t_415, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Jumps and grabs his chef hat with both paws to keep it on, then straightens it.")))).Put("squish", Arr(Call(Fn((V _arrowThis422, int _argc416, V _a418, V _a419, V _a420, V _a421, V[] _rest417) => {
V t_423 = default;
t_423 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_423, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.42))).Put("hap", ((V)(0.9))).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(3D))), "wait", ((V)(300D)));
Invoke(t_423, "to", ((V)(300D)), NewObj(4).Put("sq", ((V)(0.1))).Put("hap", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
{
double i_424 = 0;
i_424 = 0D;
while (true) {
if (!((i_424 < 2D))) break;
Invoke(Invoke(t_423, "to", ((V)(150D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(8D)), ((V)(4D))), NewObj(1).Put("sq", ((V)(0.12))).V), ((V)("io"))), "to", ((V)(180D)), Call(o_13, V.Undef, NOHANDS_14, NewObj(1).Put("sq", ((V)((0.04 * (1D - i_424))))).V), ((V)("io")));
i_424++;
}
}
Invoke(Invoke(t_423, "to", ((V)(200D)), NewObj(3).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_423);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Flattened like dough with a puff of flour, then pats himself back into shape.")))).Put("quirk", Arr(Call(Fn((V _arrowThis432, int _argc426, V _a428, V _a429, V _a430, V _a431, V[] _rest427) => {
V t_433 = default;
t_433 = Call(TL_9, V.Undef);
Invoke(Invoke(t_433, "to", ((V)(350D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-15D)))), NewObj(3).Put("armR", ((V)(20D))).Put("pitch", ((V)((-0.05)))).Put("ly", ((V)(0.4))).V), ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(2).Put("open", ((V)(0.2))).Put("tongue", ((V)(0.6))).V, NewObj(2).Put("open", ((V)(0D))).Put("tongue", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_433, "to", ((V)(400D)), NewObj(3).Put("close", ((V)(0.85))).Put("htilt", ((V)(6D))).Put("pitch", ((V)(0.1))).V, ((V)("io"))), "wait", ((V)(400D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_433, "to", ((V)(140D)), NewObj(3).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).Put("puff", ((V)((-0.2)))).V, ((V)("o"))), "to", ((V)(220D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)((-4D))), ((V)((-10D)))), NewObj(7).Put("armR", ((V)(80D))).Put("open", ((V)(0.25))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).Put("close", ((V)(0D))).Put("htilt", ((V)(0D))).Put("pitch", ((V)(0D))).V), ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("pawR")), ((V)(3D))), "wait", ((V)(300D))), "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D))), NewObj(4).Put("armR", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("ly", ((V)(0D))).V), ((V)("io")));
return Invoke(Invoke(Invoke(t_433, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Taste test")), ((V)("Tastes something from his paw, thinks about it, then a proud chef's kiss.")))).Put("press", NewObj(1).Put("hap", ((V)(0.4))).V).Put("rel", NewObj(3).Put("dur", ((V)(1100D))).Put("k", NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.18))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.08)), ((V)("io"))), Arr(((V)(390D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(800D)), ((V)(1D))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("dust")), ((V)("body")), ((V)(2D))))).V).V).V;
eyes_29 = Fn((V _arrowThis442, int _argc434, V t_440, V d_441, V _a438, V _a439, V[] _rest435) => {
return Invoke(Invoke(t_440, "to", ((V)(110D)), NewObj(1).Put("lx", ((V)((ToNum(d_441) * 0.9)))).V, ((V)("o"))), "e", ((V)("blink")));
}, 2, "", true);
DANCES_30 = NewObj(9).Put("mallow", Arr(Call(Fn((V _arrowThis449, int _argc443, V _a445, V _a446, V _a447, V _a448, V[] _rest444) => {
V t_450 = default;
double B_451 = 0;
V a_452 = default;
t_450 = Call(TL_9, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_451 = 520D;
Invoke(Arr(((V)(0.12)), ((V)(0.24)), ((V)(0.36))), "forEach", Fn((V _arrowThis461, int _argc453, V v_459, V i_460, V _a457, V _a458, V[] _rest454) => {
return Invoke(Invoke(t_450, "to", ((V)(200D)), NewObj(4).Put("sq", v_459).Put("armL", ((V)((20D - (ToNum(i_460) * 10D))))).Put("armR", ((V)((20D - (ToNum(i_460) * 10D))))).Put("close", ((V)((SEqN(i_460, 2D) ? 0.6 : 0D)))).V, ((V)("o"))), "wait", ((V)((B_451 - 200D))));
}, 2, "", true));
Invoke(Invoke(Invoke(Invoke(t_450, "to", ((V)(1400D)), NewObj(6).Put("sq", ((V)((-0.2)))).Put("lift", ((V)(2D))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("close", ((V)(0D))).Put("wide", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(240D)), NewObj(1).Put("sq", ((V)((-0.24)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("sq", ((V)((-0.19)))).V, ((V)("io")));
Call(swing_17, V.Undef, t_450, ((V)(2000D)), ((V)(3D)), NewObj(5).Put("bend", ((V)(7D))).Put("x", ((V)(1.4))).Put("htilt", ((V)((-3D)))).Put("armL", ((V)(12D))).Put("armR", ((V)((-12D)))).V, ((V)("io")));
Invoke(t_450, "to", ((V)(320D)), NewObj(5).Put("sq", ((V)(0.14))).Put("lift", ((V)(0D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("wide", ((V)(0D))).V, ((V)("i")));
Call(land_20, V.Undef, t_450, ((V)(0.16)), ((V)(4D)), ((V)(360D)));
Call(eyes_29, V.Undef, t_450, ((V)(1D)));
a_452 = Get(t_450, "t");
Invoke(Invoke(t_450, "to", ((V)(1800D)), NewObj(3).Put("spin", ((V)(360D))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(t_450, "at", a_452);
Call(steps_18, V.Undef, t_450, ((V)(1800D)), ((V)(4D)), ((V)(2D)));
Invoke(Arr(((V)(0D)), ((V)(600D)), ((V)(1200D))), "forEach", Fn((V _arrowThis469, int _argc462, V d_468, V _a465, V _a466, V _a467, V[] _rest463) => {
return Invoke(Invoke(t_450, "at", Add(a_452, d_468)), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D)));
}, 1, "", true));
Invoke(Invoke(t_450, "at", Add(a_452, ((V)(1801D)))), "to", ((V)(250D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_450, "to", ((V)(300D)), NewObj(4).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(2D))).Put("armL", ((V)(165D))).Put("armR", ((V)(165D))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(5).Put("sq", ((V)(0.45))).Put("lift", ((V)(0D))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).Put("close", ((V)(1D))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("dust")), ((V)("footL")), ((V)(3D))), "e", ((V)("emit")), ((V)("dust")), ((V)("footR")), ((V)(3D))), "wait", ((V)(400D)));
Invoke(Invoke(Invoke(t_450, "to", ((V)(1500D)), NewObj(4).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(2D))), "wait", ((V)(250D)));
return Invoke(Invoke(t_450, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Marshmallow Mellow")), ((V)("Memory-foam steps down, one long slow rise to tall, a taffy stretch sway, a pillow flop, turns on the roasting stick in a puff of steam, gets squashed into a s'more and slowly rises again.")))).Put("bao", Arr(Call(Fn((V _arrowThis476, int _argc470, V _a472, V _a473, V _a474, V _a475, V[] _rest471) => {
V t_477 = default;
double B_478 = 0;
t_477 = Call(TL_9, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_478 = 500D;
Invoke(Invoke(t_477, "to", ((V)(300D)), NewObj(4).Put("sq", ((V)(0.22))).Put("armL", ((V)((-6D)))).Put("armR", ((V)((-6D)))).Put("close", ((V)(0.5))).V, ((V)("io"))), "wait", ((V)(200D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_477, "to", ((V)(700D)), NewObj(3).Put("sq", ((V)(0.08))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D))), "wait", ((V)(150D))), "to", ((V)(800D)), NewObj(6).Put("sq", ((V)((-0.12)))).Put("lift", ((V)(1D))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("close", ((V)(0D))).Put("wide", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(2).Put("sq", ((V)((-0.08)))).Put("wide", ((V)(0D))).V, ((V)("io")));
{
double i_479 = 0;
i_479 = 0D;
while (true) {
if (!((i_479 < 4D))) break;
double d_481 = 0;
d_481 = (NumTruthy((i_479 % 2D)) ? 1D : (-1D));
Call(jump_15, V.Undef, t_477, NewObj(9).Put("h", ((V)(5D))).Put("ant", ((V)(120D))).Put("up", ((V)(170D))).Put("c", ((V)(0.14))).Put("arm", ((V)(50D))).Put("chain", ((i_479 < 3D) ? V.True : V.False)).Put("air", NewObj(2).Put("tilt", ((V)((d_481 * 5D)))).Put("htilt", ((V)(((-d_481) * 3D)))).V).Put("fall", NewObj(2).Put("tilt", ((V)(0D))).Put("htilt", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D))))).V);
i_479++;
}
}
Call(swing_17, V.Undef, t_477, ((V)(2000D)), ((V)(3D)), NewObj(5).Put("twist", ((V)(0.55))).Put("htilt", ((V)(5D))).Put("bend", ((V)((-2D)))).Put("armL", ((V)(25D))).Put("armR", ((V)((-25D)))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_477, "to", ((V)(500D)), NewObj(4).Put("puff", ((V)(1D))).Put("sq", ((V)((-0.05)))).Put("lift", ((V)(1D))).Put("close", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(4).Put("puff", ((V)((-0.2)))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.45))).Put("close", ((V)(0.8))).V, ((V)("o"))), "em", ((V)(1000D)), ((V)(140D)), ((V)("steam")), ((V)("head")), ((V)(1D))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "osc", ((V)(1000D)), ((V)(5D)), NewObj(2).Put("lift", ((V)(2.2))).Put("sq", ((V)((-0.08)))).V, NewObj(2).Put("lift", ((V)(1D))).Put("sq", ((V)((-0.04)))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(300D)), NewObj(6).Put("puff", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("close", ((V)(0D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(t_477, "to", ((V)(260D)), NewObj(5).Put("sq", ((V)(0.18))).Put("bend", ((V)((-6D)))).Put("x", ((V)((-1.5)))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("i")));
Call(jelly_19, V.Undef, t_477, ((V)(0.12)), ((V)(3D)), ((V)(320D)));
Invoke(t_477, "to", ((V)(300D)), NewObj(4).Put("bend", ((V)(0D))).Put("x", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(jump_15, V.Undef, t_477, NewObj(6).Put("h", ((V)(8D))).Put("ant", ((V)(200D))).Put("up", ((V)(240D))).Put("c", ((V)(0.2))).Put("arm", ((V)(70D))).Put("ev", Arr(Arr(((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(2D))), Arr(((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(3D))))).V);
return Invoke(Invoke(t_477, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Steamer Proof")), ((V)("Rises like proofing dough in two steamy breaths, bounces in the steamer basket, wrings his pleats in a pinch-and-twist, whistles like a kettle with steam streaming out, a pillowy plop and a proud hop.")))).Put("dunkie", Arr(Call(Fn((V _arrowThis488, int _argc482, V _a484, V _a485, V _a486, V _a487, V[] _rest483) => {
V t_489 = default;
double B_490 = 0;
V a_491 = default;
t_489 = Call(TL_9, V.Undef, NewObj(1).Put("smile", ((V)(0.9))).V);
B_490 = 500D;
Call(eyes_29, V.Undef, t_489, ((V)((-1D))));
Invoke(Invoke(Invoke(t_489, "to", ((V)(200D)), NewObj(2).Put("tilt", ((V)(6D))).Put("sq", ((V)(0.06))).V, ((V)("io"))), "to", ((V)(900D)), NewObj(3).Put("x", ((V)((-6D)))).Put("tilt", ((V)((-32D)))).Put("footL", ((V)(2D))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(2).Put("tilt", ((V)((-28D)))).Put("footL", ((V)(0D))).V, ((V)("io")));
Call(eyes_29, V.Undef, t_489, ((V)(1D)));
Invoke(Invoke(Invoke(Invoke(t_489, "to", ((V)(1200D)), NewObj(3).Put("x", ((V)(6D))).Put("tilt", ((V)(32D))).Put("footR", ((V)(2D))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(2).Put("tilt", ((V)(28D))).Put("footR", ((V)(0D))).V, ((V)("io"))), "to", ((V)(800D)), NewObj(3).Put("x", ((V)(0D))).Put("tilt", ((V)((-4D)))).Put("lx", ((V)(0D))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io")));
Invoke(t_489, "to", ((V)(260D)), NewObj(4).Put("twist", ((V)((-0.4)))).Put("sq", ((V)(0.1))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("io")));
a_491 = Get(t_489, "t");
Invoke(Invoke(t_489, "to", ((V)(1500D)), NewObj(4).Put("spin", ((V)(1080D))).Put("lift", ((V)(2D))).Put("twist", ((V)(0D))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(t_489, "at", Add(a_491, ((V)(1300D))));
Invoke(Arr(((V)(10D)), ((V)((-8D))), ((V)(6D)), ((V)((-4D))), ((V)(2D)), ((V)(0D))), "forEach", Fn((V _arrowThis499, int _argc492, V v_498, V _a495, V _a496, V _a497, V[] _rest493) => {
return Invoke(t_489, "to", ((V)(140D)), NewObj(3).Put("tilt", v_498).Put("lift", ((V)((Truthy(v_498) ? 1D : 0D)))).Put("cross", ((V)((Truthy(v_498) ? 0.6 : 0D)))).V, ((V)("io")));
}, 1, "", true));
Invoke(Invoke(t_489, "to", ((V)(200D)), NewObj(3).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("sprinkle")), ((V)("head")), ((V)(3D)));
{
double i_500 = 0;
i_500 = 0D;
while (true) {
if (!((i_500 < 8D))) break;
double an_502 = 0;
an_502 = (((i_500 + 1D) * System.Math.PI) / 2D);
Invoke(t_489, "to", ((V)((B_490 / 2D))), NewObj(5).Put("x", ((V)((3D * FdLibm.Sin(an_502))))).Put("bend", ((V)((5D * FdLibm.Cos(an_502))))).Put("htilt", ((V)(((-2D) * FdLibm.Sin(an_502))))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)("io")));
i_500++;
}
}
Invoke(t_489, "to", ((V)(250D)), NewObj(5).Put("x", ((V)(0D))).Put("bend", ((V)(0D))).Put("htilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_489, "to", ((V)(300D)), NewObj(3).Put("sq", ((V)(0.28))).Put("pitch", ((V)((-0.25)))).Put("lift", ((V)((-1D)))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("coffee")), ((V)("body")), ((V)(4D))), "wait", ((V)(200D))), "to", ((V)(240D)), NewObj(3).Put("sq", ((V)((-0.08)))).Put("pitch", ((V)(0.05))).Put("lift", ((V)(1D))).V, ((V)("o")));
Call(shake_16, V.Undef, t_489, NewObj(6).Put("P", ((V)(85D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.8)), ((V)(0.5)), ((V)(0.25)))).Put("head", ((V)(0.2))).Put("roll", ((V)(4D))).Put("body", ((V)(1D))).Put("chest", ((V)(0.1))).V);
Invoke(Invoke(t_489, "e", ((V)("emit")), ((V)("coffee")), ((V)("body")), ((V)(3D))), "e", ((V)("emit")), ((V)("sprinkle")), ((V)("head")), ((V)(3D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_489, "to", ((V)(200D)), NewObj(3).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("winkR", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(300D))), "to", ((V)(200D)), NewObj(1).Put("winkR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_489, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Coin Spin Roll")), ((V)("Rolls away like a wheel and back, spins like a coin on a table (front, thin edge, back) and wobbles down like one, a bit dizzy, hula-hoops with his whole ring, dunks in coffee, shakes it off and winks.")))).Put("frybo", Arr(Call(Fn((V _arrowThis509, int _argc503, V _a505, V _a506, V _a507, V _a508, V[] _rest504) => {
V t_510 = default;
double B_511 = 0;
t_510 = Call(TL_9, V.Undef, NewObj(1).Put("smile", ((V)(0.9))).V);
B_511 = 480D;
{
double i_512 = 0;
i_512 = 0D;
while (true) {
if (!((i_512 < 4D))) break;
Invoke(Invoke(t_510, "to", ((V)(150D)), NewObj(6).Put("earL", ((V)(22D))).Put("earR", ((V)(22D))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(1.2))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)("o"))), "to", ((V)((B_511 - 150D))), NewObj(6).Put("earL", ((V)((-14D)))).Put("earR", ((V)((-14D)))).Put("sq", ((V)(0.08))).Put("lift", ((V)(0D))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).V, ((V)("io")));
i_512++;
}
}
Invoke(t_510, "to", ((V)(200D)), NewObj(3).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Arr(((V)(1D)), ((V)((-1D)))), "forEach", Fn((V _arrowThis521, int _argc514, V d_520, V _a517, V _a518, V _a519, V[] _rest515) => {
Call(eyes_29, V.Undef, t_510, d_520);
Invoke(Invoke(Invoke(Invoke(t_510, "to", ((V)(200D)), NewObj(4).Put("earL", ((V)((ToNum(d_520) * 8D)))).Put("earR", ((V)(((-ToNum(d_520)) * 8D)))).Put("htilt", ((V)(((-ToNum(d_520)) * 3D)))).Put("tilt", ((V)(((-ToNum(d_520)) * 2D)))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(6).Put("earL", ((V)(((-ToNum(d_520)) * 24D)))).Put("earR", ((V)((ToNum(d_520) * 24D)))).Put("htilt", ((V)((ToNum(d_520) * 7D)))).Put("tilt", ((V)((ToNum(d_520) * 4D)))).Put("armL", ((V)((LtN(d_520, 0D) ? 70D : 10D)))).Put("armR", ((V)((GtN(d_520, 0D) ? 70D : 10D)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(4).Put("earL", ((V)(((-ToNum(d_520)) * 18D)))).Put("earR", ((V)((ToNum(d_520) * 18D)))).Put("htilt", ((V)((ToNum(d_520) * 5D)))).Put("tilt", ((V)((ToNum(d_520) * 3D)))).V, ((V)("io"))), "wait", ((V)(200D)));
return default;
}, 1, "", true));
Invoke(t_510, "to", ((V)(300D)), NewObj(7).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("htilt", ((V)(0D))).Put("tilt", ((V)(0D))).Put("lx", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_510, "to", ((V)(300D)), NewObj(6).Put("armL", ((V)(140D))).Put("armR", ((V)(140D))).Put("fw", ((V)(1.5))).Put("earL", ((V)(8D))).Put("earR", ((V)(8D))).Put("hap", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(1400D)), ((V)(7D)), NewObj(2).Put("armL", ((V)(128D))).Put("armR", ((V)(152D))).V, NewObj(2).Put("armL", ((V)(152D))).Put("armR", ((V)(128D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(6).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("fw", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
Call(eyes_29, V.Undef, t_510, ((V)(1D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_510, "to", ((V)(260D)), NewObj(2).Put("tilt", ((V)((-4D)))).Put("sq", ((V)(0.06))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(5).Put("tilt", ((V)(28D))).Put("x", ((V)(3D))).Put("earL", ((V)((-20D)))).Put("earR", ((V)(20D))).Put("lift", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("salt")), ((V)("head")), ((V)(4D))), "wait", ((V)(250D))), "to", ((V)(380D)), NewObj(5).Put("tilt", ((V)((-5D)))).Put("x", ((V)(0D))).Put("earL", ((V)(8D))).Put("earR", ((V)((-8D)))).Put("lift", ((V)(0D))).V, ((V)("io"))), "to", ((V)(280D)), NewObj(5).Put("tilt", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("lx", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(t_510, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.05))).V, ((V)("io")));
Call(shake_16, V.Undef, t_510, NewObj(7).Put("P", ((V)(80D))).Put("env", Arr(((V)(0.5)), ((V)(0.9)), ((V)(1D)), ((V)(0.9)), ((V)(0.6)), ((V)(0.3)))).Put("head", ((V)(0.12))).Put("roll", ((V)(3D))).Put("ear", ((V)(14D))).Put("body", ((V)(1D))).Put("chest", ((V)(0.06))).V);
Invoke(t_510, "e", ((V)("emit")), ((V)("salt")), ((V)("head")), ((V)(5D)));
Invoke(t_510, "to", ((V)(200D)), NewObj(3).Put("earL", ((V)((-16D)))).Put("earR", ((V)((-16D)))).Put("sq", ((V)(0.12))).V, ((V)("io")));
Call(jump_15, V.Undef, t_510, NewObj(8).Put("h", ((V)(8D))).Put("ant", ((V)(140D))).Put("up", ((V)(220D))).Put("c", ((V)(0.16))).Put("arm", ((V)(80D))).Put("air", NewObj(2).Put("earL", ((V)(24D))).Put("earR", ((V)(24D))).V).Put("fall", NewObj(2).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))))).V);
Invoke(t_510, "to", ((V)(300D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_510, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Fry Fan Flip")), ((V)("His fries fan open and bunch shut on the beat, a hair flip one way then the other, a fry wave with jazz hands, he tips his box to pour and rights it, a salt-shaker shimmy and a fan-open ta-da.")))).Put("bunbun", Arr(Call(Fn((V _arrowThis528, int _argc522, V _a524, V _a525, V _a526, V _a527, V[] _rest523) => {
V t_529 = default;
double B_530 = 0;
t_529 = Call(TL_9, V.Undef, NewObj(1).Put("smile", ((V)(0.9))).V);
B_530 = 500D;
{
double i_531 = 0;
i_531 = 0D;
while (true) {
if (!((i_531 < 4D))) break;
double d_533 = 0;
d_533 = (NumTruthy((i_531 % 2D)) ? 1D : (-1D));
Invoke(Invoke(Invoke(t_529, "to", ((V)((B_530 / 2D))), NewObj(7).Put("split", ((V)(0.8))).Put("sq", ((V)((-0.08)))).Put("tilt", ((V)((d_533 * 4D)))).Put("armL", ((V)(55D))).Put("armR", ((V)(55D))).Put("open", ((V)(0.4))).Put("hap", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head")), ((V)(1D))), "to", ((V)((B_530 / 2D))), NewObj(6).Put("split", ((V)(0D))).Put("sq", ((V)(0.1))).Put("tilt", ((V)(0D))).Put("armL", ((V)(5D))).Put("armR", ((V)(5D))).Put("open", ((V)(0D))).V, ((V)("io")));
i_531++;
}
}
Invoke(t_529, "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
Call(eyes_29, V.Undef, t_529, ((V)((-1D))));
Invoke(Invoke(t_529, "to", ((V)(500D)), NewObj(3).Put("fan", ((V)((-1.2)))).Put("htilt", ((V)((-5D)))).Put("tilt", ((V)((-3D)))).V, ((V)("io"))), "wait", ((V)(150D)));
Call(eyes_29, V.Undef, t_529, ((V)(1D)));
Invoke(Invoke(Invoke(t_529, "to", ((V)(700D)), NewObj(3).Put("fan", ((V)(1.2))).Put("htilt", ((V)(5D))).Put("tilt", ((V)(3D))).V, ((V)("io"))), "wait", ((V)(150D))), "to", ((V)(450D)), NewObj(4).Put("fan", ((V)(0D))).Put("htilt", ((V)(0D))).Put("tilt", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("io")));
{
double i_534 = 0;
i_534 = 0D;
while (true) {
if (!((i_534 < 4D))) break;
Invoke(Invoke(t_529, "to", ((V)(110D)), NewObj(2).Put("shuf", ((V)((NumTruthy((i_534 % 2D)) ? (-0.9) : 0.9)))).Put("sq", ((V)(0.03))).V, ((V)("o"))), "to", ((V)(110D)), NewObj(2).Put("shuf", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
i_534++;
}
}
Invoke(t_529, "e", ((V)("emit")), ((V)("crumb")), ((V)("body")), ((V)(2D)));
Call(eyes_29, V.Undef, t_529, ((V)(1D)));
Call(jump_15, V.Undef, t_529, NewObj(8).Put("h", ((V)(14D))).Put("ant", ((V)(240D))).Put("up", ((V)(330D))).Put("c", ((V)(0.24))).Put("arm", ((V)(90D))).Put("spin", ((V)(360D))).Put("air", NewObj(1).Put("split", ((V)(1.2))).V).Put("fall", NewObj(1).Put("split", ((V)(0.3))).V).V);
Invoke(Invoke(Invoke(Invoke(t_529, "to", ((V)(80D)), NewObj(2).Put("split", ((V)(0D))).Put("sq", ((V)(0.25))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("body")), ((V)(4D))), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(3D))), "to", ((V)(160D)), NewObj(2).Put("sq", ((V)((-0.06)))).Put("lx", ((V)(0D))).V, ((V)("io")));
Call(jelly_19, V.Undef, t_529, ((V)(0.08)), ((V)(3D)), ((V)(260D)));
Invoke(Invoke(Invoke(t_529, "to", ((V)(220D)), NewObj(1).Put("fan", ((V)(0.35))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("fan", ((V)((-0.2)))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(1).Put("fan", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_529, "to", ((V)(160D)), NewObj(2).Put("winkR", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(300D))), "to", ((V)(200D)), NewObj(1).Put("winkR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_529, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Burger Accordion")), ((V)("Squeezes his stack like an accordion (the layers open and shut, notes fly), fans his layers like a hand of cards, riffles them, flips like a patty with his layers spinning apart, slams the stack back and winks.")))).Put("choco", Arr(Call(Fn((V _arrowThis542, int _argc536, V _a538, V _a539, V _a540, V _a541, V[] _rest537) => {
V t_543 = default;
double B_544 = 0;
V pops_545 = default;
V a_546 = default;
t_543 = Call(TL_9, V.Undef, NewObj(1).Put("smile", ((V)(0.85))).V);
B_544 = 450D;
pops_545 = Arr(NewObj(3).Put("tilt", ((V)(6D))).Put("armL", ((V)(90D))).Put("armR", ((V)(0D))).V, NewObj(3).Put("tilt", ((V)((-6D)))).Put("armL", ((V)(0D))).Put("armR", ((V)(90D))).V, NewObj(4).Put("tilt", ((V)(0D))).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).Put("lift", ((V)(1D))).V, NewObj(4).Put("tilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lift", ((V)(0D))).V);
{
double r_547 = 0;
r_547 = 0D;
while (true) {
if (!((r_547 < 2D))) break;
Invoke(pops_545, "forEach", Fn((V _arrowThis556, int _argc549, V p_555, V _a552, V _a553, V _a554, V[] _rest550) => {
return Invoke(Invoke(Invoke(t_543, "to", ((V)(70D)), Call(o_13, V.Undef, p_555, NewObj(2).Put("tw", ((V)(1.3))).Put("sq", ((V)((-0.03)))).V), ((V)("l"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(1D))), "to", ((V)((B_544 - 70D))), NewObj(2).Put("tw", ((V)(0.2))).Put("sq", ((V)(0D))).V, ((V)("o")));
}, 1, "", true));
r_547++;
}
}
Invoke(Invoke(t_543, "osc", ((V)(1800D)), ((V)(6D)), NewObj(2).Put("tw", ((V)(1.5))).Put("sq", ((V)((-0.02)))).V, NewObj(2).Put("tw", ((V)(0D))).Put("sq", ((V)(0.02))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(t_543, "to", ((V)(1400D)), NewObj(5).Put("melt", ((V)(1D))).Put("sq", ((V)(0.2))).Put("close", ((V)(0.6))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io")));
Call(swing_17, V.Undef, t_543, ((V)(1600D)), ((V)(3D)), NewObj(3).Put("bend", ((V)(8D))).Put("x", ((V)(1.5))).Put("htilt", ((V)((-4D)))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_543, "to", ((V)(90D)), NewObj(7).Put("melt", ((V)(0D))).Put("sq", ((V)((-0.1)))).Put("tw", ((V)(1.5))).Put("close", ((V)(0D))).Put("wide", ((V)(0.6))).Put("armL", ((V)(80D))).Put("armR", ((V)(80D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(180D)), NewObj(2).Put("sq", ((V)(0.04))).Put("tw", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(5).Put("sq", ((V)(0D))).Put("tw", ((V)(0D))).Put("wide", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(eyes_29, V.Undef, t_543, ((V)(1D)));
a_546 = Get(t_543, "t");
Invoke(Invoke(t_543, "to", ((V)(1600D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(t_543, "at", a_546), "to", ((V)(700D)), NewObj(1).Put("wrap", ((V)(0.7))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_543, "at", Add(a_546, ((V)(1601D)))), "to", ((V)(250D)), NewObj(3).Put("blush", ((V)(0.9))).Put("wide", ((V)(0.5))).Put("lx", ((V)(0D))).V, ((V)("o"))), "to", ((V)(500D)), NewObj(3).Put("wrap", ((V)(0D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_543, "to", ((V)(70D)), NewObj(3).Put("tw", ((V)(1.2))).Put("tilt", ((V)(4D))).Put("armR", ((V)(90D))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(2).Put("tw", ((V)(0D))).Put("winkR", ((V)(1D))).V, ((V)("o"))), "wait", ((V)(300D))), "to", ((V)(250D)), NewObj(4).Put("tilt", ((V)(0D))).Put("armR", ((V)(0D))).Put("winkR", ((V)(0D))).Put("blush", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_543, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Snap and Melt")), ((V)("Stiff robot snaps with his segments flashing (a bar can't bend), a segment light show, melts into a gooey sway, SNAPS back into a bar, a foil twirl where his wrapper slips and he tugs it back up blushing, then a snap pose and a wink.")))).Put("scoop", Arr(Call(Fn((V _arrowThis563, int _argc557, V _a559, V _a560, V _a561, V _a562, V[] _rest558) => {
V t_564 = default;
double B_565 = 0;
V a_566 = default;
t_564 = Call(TL_9, V.Undef, NewObj(1).Put("smile", ((V)(0.9))).V);
B_565 = 500D;
{
double i_567 = 0;
i_567 = 0D;
while (true) {
if (!((i_567 < 4D))) break;
double d_569 = 0;
d_569 = (NumTruthy((i_567 % 2D)) ? 1D : (-1D));
Call(eyes_29, V.Undef, t_564, ((V)(d_569)));
Invoke(t_564, "to", ((V)((B_565 - 110D))), NewObj(5).Put("tilt", ((V)((d_569 * 13D)))).Put("armL", ((V)(((d_569 > 0D) ? 70D : 10D)))).Put("armR", ((V)(((d_569 < 0D) ? 70D : 10D)))).Put("chb", ((V)(1D))).Put("htilt", ((V)(((-d_569) * 4D)))).V, ((V)("io")));
i_567++;
}
}
Invoke(t_564, "to", ((V)(350D)), NewObj(6).Put("tilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("chb", ((V)(0D))).Put("htilt", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("io")));
Invoke(t_564, "to", ((V)(260D)), NewObj(2).Put("twist", ((V)((-0.4)))).Put("sq", ((V)(0.08))).V, ((V)("io")));
a_566 = Get(t_564, "t");
Invoke(Invoke(t_564, "to", ((V)(1800D)), NewObj(5).Put("spin", ((V)(1080D))).Put("twist", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("o"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(t_564, "at", a_566), "osc", ((V)(1800D)), ((V)(6D)), NewObj(2).Put("tilt", ((V)(5D))).Put("chb", ((V)(1D))).V, NewObj(2).Put("tilt", ((V)((-5D)))).Put("chb", ((V)(0D))).V, ((V)("io")));
Invoke(t_564, "at", Add(a_566, ((V)(1801D))));
Invoke(Arr(((V)(8D)), ((V)((-6D))), ((V)(4D)), ((V)((-2D))), ((V)(0D))), "forEach", Fn((V _arrowThis577, int _argc570, V v_576, V _a573, V _a574, V _a575, V[] _rest571) => {
return Invoke(t_564, "to", ((V)(150D)), NewObj(1).Put("tilt", v_576).V, ((V)("io")));
}, 1, "", true));
Invoke(t_564, "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
a_566 = Get(t_564, "t");
Invoke(Invoke(Invoke(Invoke(t_564, "to", ((V)(1400D)), NewObj(6).Put("sq", ((V)((-0.16)))).Put("lift", ((V)(3D))).Put("spin", ((V)(360D))).Put("armL", ((V)(140D))).Put("armR", ((V)(140D))).Put("hap", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(4).Put("sq", ((V)(0.06))).Put("lift", ((V)(0D))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("i"))), "to", ((V)(250D)), NewObj(4).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
{
double i_578 = 0;
i_578 = 0D;
while (true) {
if (!((i_578 < 3D))) break;
Invoke(Invoke(t_564, "to", ((V)(140D)), NewObj(4).Put("chy", ((V)(1.1))).Put("ly", ((V)((-0.9)))).Put("pitch", ((V)(0.12))).Put("sq", ((V)(0.04))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(4).Put("chy", ((V)(0D))).Put("ly", ((V)((-0.2)))).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i")));
i_578++;
}
}
Invoke(t_564, "to", ((V)(150D)), NewObj(2).Put("ly", ((V)(0D))).Put("close", ((V)(0.4))).V, ((V)("io")));
Call(shake_16, V.Undef, t_564, NewObj(5).Put("P", ((V)(70D))).Put("env", Arr(((V)(0.4)), ((V)(0.8)), ((V)(1D)), ((V)(0.7)), ((V)(0.4)), ((V)(0.2)))).Put("head", ((V)(0.1))).Put("roll", ((V)(2D))).Put("body", ((V)(0.5))).V);
Invoke(Invoke(Invoke(Invoke(t_564, "to", ((V)(160D)), NewObj(2).Put("close", ((V)(0D))).Put("winkR", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(300D))), "to", ((V)(200D)), NewObj(1).Put("winkR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_564, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Spinning Top Swirl")), ((V)("Rocks on the point of his cone with his arms out for balance, spins like a spinning top and wobbles down, swirls up tall like soft-serve, juggles his cherry, a cold shiver and a wink.")))).Put("boba", Arr(Call(Fn((V _arrowThis586, int _argc580, V _a582, V _a583, V _a584, V _a585, V[] _rest581) => {
V t_587 = default;
double B_588 = 0;
V a_589 = default;
t_587 = Call(TL_9, V.Undef, NewObj(1).Put("smile", ((V)(0.9))).V);
B_588 = 500D;
Invoke(t_587, "to", ((V)(200D)), NewObj(4).Put("sq", ((V)(0.1))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("hap", ((V)(1D))).V, ((V)("io")));
Invoke(t_587, "osc", ((V)(1600D)), ((V)(8D)), NewObj(4).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.08)))).Put("pop", ((V)(2D))).Put("swirl", ((V)(1.5))).V, NewObj(4).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).Put("pop", ((V)(0.5))).Put("swirl", ((V)((-1.5)))).V, ((V)("io")));
Invoke(t_587, "to", ((V)(250D)), NewObj(7).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).Put("pop", ((V)(0D))).Put("swirl", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
Invoke(t_587, "to", ((V)(300D)), NewObj(2).Put("sup", ((V)(1.4))).Put("ly", ((V)((-0.6)))).V, ((V)("o")));
Call(eyes_29, V.Undef, t_587, ((V)((-1D))));
Invoke(Invoke(t_587, "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(1D))).Put("hyaw", ((V)((-0.15)))).V, ((V)("io"))), "wait", ((V)(300D)));
Call(eyes_29, V.Undef, t_587, ((V)(1D)));
Invoke(Invoke(Invoke(t_587, "to", ((V)(500D)), NewObj(2).Put("stw", ((V)((-1D)))).Put("hyaw", ((V)(0.15))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(400D)), NewObj(5).Put("sup", ((V)(0D))).Put("stw", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_587, "to", ((V)(300D)), NewObj(3).Put("slurp", ((V)(1D))).Put("mw", ((V)(0.5))).Put("sq", ((V)(0.06))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(100D)), NewObj(6).Put("slurp", ((V)(0D))).Put("sup", ((V)(0.9))).Put("pop", ((V)(1.5))).Put("sq", ((V)((-0.08)))).Put("mw", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(4D))), "to", ((V)(350D)), NewObj(4).Put("sup", ((V)(0D))).Put("pop", ((V)(0D))).Put("sq", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
Call(eyes_29, V.Undef, t_587, ((V)(1D)));
a_589 = Get(t_587, "t");
Invoke(Invoke(Invoke(t_587, "to", ((V)(1500D)), NewObj(2).Put("spin", ((V)(360D))).Put("swirl", ((V)(3D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "to", ((V)(500D)), NewObj(2).Put("swirl", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("io")));
{
double i_590 = 0;
i_590 = 0D;
while (true) {
if (!((i_590 < 4D))) break;
double d_592 = 0;
d_592 = (NumTruthy((i_590 % 2D)) ? 1D : (-1D));
Invoke(Invoke(t_587, "to", ((V)(120D)), NewObj(5).Put("pop", ((V)(2D))).Put("sq", ((V)(0.08))).Put("tilt", ((V)((d_592 * 3D)))).Put("armL", ((V)(((d_592 < 0D) ? 60D : 0D)))).Put("armR", ((V)(((d_592 > 0D) ? 60D : 0D)))).V, ((V)("o"))), "to", ((V)((B_588 - 120D))), NewObj(3).Put("pop", ((V)(0.2))).Put("sq", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io")));
i_590++;
}
}
Invoke(t_587, "to", ((V)(200D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("pop", ((V)(0D))).V, ((V)("io")));
Call(jump_15, V.Undef, t_587, NewObj(8).Put("h", ((V)(7D))).Put("ant", ((V)(150D))).Put("up", ((V)(200D))).Put("c", ((V)(0.14))).Put("arm", ((V)(70D))).Put("air", NewObj(2).Put("pop", ((V)(1.6))).Put("stw", ((V)(1D))).V).Put("fall", NewObj(2).Put("pop", ((V)(0D))).Put("stw", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))))).V);
return Invoke(Invoke(t_587, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Bubble Tea Shaker")), ((V)("Shakes himself like a cocktail shaker with his pearls flying, his straw rises like a periscope and looks around, slurps a pearl up the straw and pops it out, a whirlpool twirl with the pearls swirling, pearl drums and a hop.")))).Put("chefbun", Arr(Call(Fn((V _arrowThis599, int _argc593, V _a595, V _a596, V _a597, V _a598, V[] _rest594) => {
V t_600 = default;
double B_601 = 0;
V a_602 = default;
t_600 = Call(TL_9, V.Undef, NewObj(1).Put("smile", ((V)(0.9))).V);
B_601 = 500D;
{
double i_603 = 0;
i_603 = 0D;
while (true) {
if (!((i_603 < 4D))) break;
Invoke(Invoke(Invoke(t_600, "to", ((V)(180D)), NewObj(4).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("sq", ((V)((-0.04)))).Put("hap", ((V)(1D))).V, ((V)("io"))), "to", ((V)((B_601 - 180D))), NewObj(4).Put("armL", ((V)(15D))).Put("armR", ((V)(15D))).Put("sq", ((V)(0.24))).Put("close", ((V)(0.5))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(1D)));
i_603++;
}
}
Invoke(t_600, "to", ((V)(250D)), NewObj(3).Put("sq", ((V)(0.1))).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
Call(eyes_29, V.Undef, t_600, ((V)(1D)));
Invoke(t_600, "to", ((V)(260D)), NewObj(5).Put("sq", ((V)(0.26))).Put("pitch", ((V)((-0.1)))).Put("armL", ((V)((-8D)))).Put("armR", ((V)((-8D)))).Put("lx", ((V)(0D))).V, ((V)("io")));
a_602 = Get(t_600, "t");
Invoke(Invoke(t_600, "to", ((V)(380D)), NewObj(1).Put("lift", ((V)(10D))).V, ((V)("o"))), "to", ((V)(380D)), NewObj(1).Put("lift", ((V)(0D))).V, ((V)("i")));
Invoke(Invoke(Invoke(Invoke(t_600, "at", a_602), "to", ((V)(70D)), NewObj(1).Put("sq", ((V)((-0.14)))).V, ((V)("o"))), "to", ((V)(230D)), NewObj(4).Put("sq", ((V)(0.32))).Put("armL", ((V)(165D))).Put("armR", ((V)(165D))).Put("wide", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(460D)), NewObj(3).Put("sq", ((V)(0.26))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).V, ((V)("io")));
Invoke(Invoke(t_600, "at", a_602), "to", ((V)(760D)), NewObj(1).Put("spin", ((V)(720D))).V, ((V)("io")));
Invoke(Invoke(t_600, "at", Add(a_602, ((V)(760D)))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(t_600, "to", ((V)(80D)), NewObj(3).Put("sq", ((V)(0.36))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(4D))), "to", ((V)(150D)), NewObj(5).Put("sq", ((V)((-0.12)))).Put("pitch", ((V)(0D))).Put("wide", ((V)(0D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("o")));
Call(jelly_19, V.Undef, t_600, ((V)(0.09)), ((V)(3D)), ((V)(260D)));
Invoke(t_600, "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
{
double i_605 = 0;
i_605 = 0D;
while (true) {
if (!((i_605 < 4D))) break;
double d_607 = 0;
d_607 = (NumTruthy((i_605 % 2D)) ? 1D : (-1D));
Invoke(Invoke(t_600, "to", ((V)(140D)), NewObj(5).Put("earL", ((V)(((-d_607) * 26D)))).Put("earR", ((V)((d_607 * 26D)))).Put("htilt", ((V)((d_607 * 4D)))).Put("lx", ((V)((d_607 * 0.7)))).Put("ly", ((V)((-0.6)))).V, ((V)("o"))), "to", ((V)((B_601 - 140D))), NewObj(2).Put("earL", ((V)(((-d_607) * 18D)))).Put("earR", ((V)((d_607 * 18D)))).V, ((V)("io")));
i_605++;
}
}
Invoke(t_600, "to", ((V)(250D)), NewObj(5).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("htilt", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
Invoke(t_600, "to", ((V)(250D)), NewObj(2).Put("armR", ((V)(70D))).Put("armL", ((V)(40D))).V, ((V)("io")));
a_602 = Get(t_600, "t");
Invoke(t_600, "osc", ((V)(1400D)), ((V)(7D)), NewObj(2).Put("armR", ((V)(100D))).Put("twist", ((V)(0.12))).V, NewObj(2).Put("armR", ((V)(45D))).Put("twist", ((V)((-0.12)))).V, ((V)("io")));
Invoke(t_600, "at", a_602);
Call(steps_18, V.Undef, t_600, ((V)(1400D)), ((V)(4D)), ((V)(1.8)));
Invoke(t_600, "to", ((V)(250D)), NewObj(3).Put("armR", ((V)(0D))).Put("armL", ((V)(0D))).Put("twist", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_600, "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-15D)))), NewObj(2).Put("armR", ((V)(20D))).Put("close", ((V)(0.9))).V), ((V)("io"))), "to", ((V)(140D)), NewObj(3).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).Put("puff", ((V)((-0.2)))).V, ((V)("o"))), "to", ((V)(220D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)((-4D))), ((V)((-10D)))), NewObj(4).Put("armR", ((V)(80D))).Put("open", ((V)(0.2))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).V), ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("pawR")), ((V)(3D))), "wait", ((V)(250D))), "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D))), NewObj(3).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).Put("open", ((V)(0D))).V), ((V)("io")));
Invoke(Invoke(Invoke(t_600, "to", ((V)(400D)), NewObj(5).Put("pitch", ((V)((-0.25)))).Put("sq", ((V)(0.06))).Put("earL", ((V)(20D))).Put("earR", ((V)((-20D)))).Put("armL", ((V)(40D))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(400D)), NewObj(5).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("armL", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_600, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Pizza Dough Twirl")), ((V)("Kneads himself, gets tossed and spins flat like pizza dough in the air, pops back into a bun, his chef hat tips side to side on the beat, whisks and stirs, a chef's kiss and a hat-tip bow.")))).V;
Invoke(KEYS_22, "forEach", Fn((V _arrowThis615, int _argc608, V k_614, V _a611, V _a612, V _a613, V[] _rest609) => {
Set(GetK(MOVES_28, k_614), "dance", GetK(DANCES_30, k_614));
return default;
}, 1, "", true));
Invoke(KEYS_22, "forEach", Fn((V _arrowThis623, int _argc616, V k_622, V _a619, V _a620, V _a621, V[] _rest617) => {
Set(GetK(MOVES_28, k_622), "look", Call(natF_23, V.Undef, ((V)(1D))));
return default;
}, 1, "", true));
Set(R_8, "SNACKLIB", NewObj(2).Put("natF", natF_23).Put("KEYS", KEYS_22).V);
Call(install_21, V.Undef, MOVES_28, CARDS_24);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
