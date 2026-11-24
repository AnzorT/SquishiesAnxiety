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
Invoke(KEYS_22, "forEach", Fn((V _self1, int _argc46, V k_52, V _a49, V _a50, V _a51, V[] _rest47) => {
return Invoke(Get(R_8, "SOFT"), "add", k_52);
}, 1, "", true));
natF_23 = Fn((V _self1, int _argc53, V k_59, V J_60, V _a57, V _a58, V[] _rest54) => {
V t_61 = default;
V dip_62 = default;
V bw_63 = default;
double lead_64 = 0;
V turn_65 = default;
V e_66 = default;
J_60 = (J_60 is var _t67 && Truthy(_t67) ? _t67 : NewObj(0).V);
t_61 = Call(TL_9, V.Undef);
dip_62 = (Get(J_60, "dip").IsNullish ? ((V)(0.045)) : Get(J_60, "dip"));
bw_63 = (Get(J_60, "bend").IsNullish ? ((V)(5D)) : Get(J_60, "bend"));
lead_64 = (0.18 * ToNum(k_59));
turn_65 = Fn((V _self1, int _argc68, V T_74, V from_75, V to_76, V d1_77, V[] _rest69) => {
V s_79 = default;
double dir_80 = 0;
double bendTo_81 = 0;
V e1_82 = default;
V e2_83 = default;
V d2_78 = default;
d2_78 = (_argc68 > 4 ? _rest69[0] : V.Undef);
s_79 = (((V)(Sign((ToNum(to_76) - ToNum(from_75))))) is var _t84 && Truthy(_t84) ? _t84 : ((V)(1D)));
dir_80 = Sign(ToNum(to_76));
bendTo_81 = (((dir_80 * ToNum(bw_63)) * System.Math.Abs(ToNum(to_76))) / 0.6);
Invoke(Invoke(Invoke(Invoke(Invoke(t_61, "at", T_74), "to", ((V)(110D)), NewObj(1).Put("lx", ((V)((dir_80 * 0.9)))).V, ((V)("o"))), "e", ((V)("blink"))), "to", Add(d1_77, d2_78), NewObj(1).Put("hyaw", ((V)(((dir_80 * lead_64) + (ToNum(s_79) * 0.04))))).V, ((V)("o"))), "to", ((V)(420D)), NewObj(1).Put("hyaw", ((V)(((dir_80 * lead_64) * 0.35)))).V, ((V)("io")));
e1_82 = Get(t_61, "t");
Invoke(Invoke(Invoke(Invoke(t_61, "at", Add(T_74, ((V)(150D)))), "to", d1_77, NewObj(3).Put("turn", ((V)((ToNum(Add(from_75, to_76)) / 2D)))).Put("sq", dip_62).Put("tilt", ((V)((ToNum(s_79) * 1.5)))).V, ((V)("i"))), "to", d2_78, NewObj(3).Put("turn", Add(to_76, ((V)((ToNum(s_79) * 0.07))))).Put("sq", ((V)(((-ToNum(dip_62)) * 0.5)))).Put("tilt", ((V)(((-ToNum(s_79)) * 0.8)))).V, ((V)("o"))), "to", ((V)(330D)), NewObj(3).Put("turn", to_76).Put("sq", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io")));
e2_83 = Get(t_61, "t");
Invoke(Invoke(Invoke(t_61, "at", Add(T_74, ((V)(260D)))), "to", Add(d1_77, d2_78), NewObj(3).Put("bend", ((V)((bendTo_81 + (ToNum(s_79) * 1.5))))).Put("armL", ((V)((ToNum(s_79) * 8D)))).Put("armR", ((V)(((-ToNum(s_79)) * 8D)))).V, ((V)("io"))), "to", ((V)(380D)), NewObj(3).Put("bend", ((V)(bendTo_81))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return ((V)(Max(ToNum(e1_82), ToNum(e2_83), ToNum(Get(t_61, "t")))));
return default;
}, 5, "", true);
Invoke(t_61, "to", ((V)(1D)), NewObj(1).Put("lean", ((V)(0D))).V);
e_66 = Call(turn_65, V.Undef, ((V)(250D)), ((V)(0D)), ((V)(((-0.6) * ToNum(k_59)))), ((V)(170D)), ((V)(220D)));
e_66 = Call(turn_65, V.Undef, Add(e_66, ((V)(900D))), ((V)(((-0.6) * ToNum(k_59)))), ((V)((0.6 * ToNum(k_59)))), ((V)(210D)), ((V)(250D)));
e_66 = Call(turn_65, V.Undef, Add(e_66, ((V)(900D))), ((V)((0.6 * ToNum(k_59)))), ((V)(0D)), ((V)(170D)), ((V)(210D)));
Invoke(Invoke(t_61, "at", Add(e_66, ((V)(200D)))), "to", ((V)(300D)), NewObj(2).Put("lx", ((V)(0D))).Put("hyaw", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_61, "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.6))).Put("stretch", ((V)(0D))).V);
return default;
}, 2, "", true);
CARDS_24 = NewObj(9).Put("mallow", NewObj(3).Put("T", ((V)(1.15))).Put("b", ((V)(1.4))).Put("s", ((V)(1.1))).V).Put("bao", NewObj(3).Put("T", ((V)(1D))).Put("b", ((V)(1.25))).Put("s", ((V)(1D))).V).Put("dunkie", NewObj(3).Put("T", ((V)(0.92))).Put("b", ((V)(1.1))).Put("s", ((V)(1.25))).V).Put("frybo", NewObj(4).Put("T", ((V)(0.85))).Put("b", ((V)(1D))).Put("s", ((V)(1D))).Put("e", ((V)(1.3))).V).Put("bunbun", NewObj(3).Put("T", ((V)(0.95))).Put("b", ((V)(1.15))).Put("s", ((V)(1.05))).V).Put("choco", NewObj(3).Put("T", ((V)(1D))).Put("b", ((V)(0.85))).Put("s", ((V)(0.9))).V).Put("scoop", NewObj(3).Put("T", ((V)(1.05))).Put("b", ((V)(1.15))).Put("s", ((V)(1.1))).V).Put("boba", NewObj(3).Put("T", ((V)(0.95))).Put("b", ((V)(1.05))).Put("s", ((V)(1D))).V).Put("chefbun", NewObj(3).Put("T", ((V)(1D))).Put("b", ((V)(1.1))).Put("s", ((V)(1D))).V).V;
para_25 = Fn((V _self1, int _argc85, V t_91, V from_92, V fn_93, V _a90, V[] _rest86) => {
V e_94 = default;
e_94 = Get(t_91, "t");
Invoke(t_91, "at", from_92);
Call(fn_93, V.Undef, t_91);
return Invoke(t_91, "at", ((V)(Max(ToNum(e_94), ToNum(Get(t_91, "t"))))));
return default;
}, 3, "", true);
loopN_26 = Fn((V _self1, int _argc95, V t_101, V n_102, V _a99, V _a100, V[] _rest96) => {
return Object_assign(Invoke(t_101, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_101, "t")) * ToNum((n_102 is var _t103 && Truthy(_t103) ? _t103 : ((V)(3D)))))))).V);
}, 2, "", true);
blink2_27 = Fn((V _self1, int _argc104, V t_110, V _a107, V _a108, V _a109, V[] _rest105) => {
return Invoke(t_110, "e", ((V)("blink2")));
}, 1, "", true);
MOVES_28 = NewObj(9).Put("mallow", NewObj(6).Put("happy", Arr(Call(Fn((V _self1, int _argc111, V _a113, V _a114, V _a115, V _a116, V[] _rest112) => {
V t_117 = default;
t_117 = Call(TL_9, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(t_117, "to", ((V)(420D)), NewObj(5).Put("sq", ((V)((-0.16)))).Put("lift", ((V)(2D))).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).Put("wide", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(200D)));
Invoke(t_117, "to", ((V)(260D)), NewObj(5).Put("sq", ((V)(0.2))).Put("lift", ((V)(0D))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).Put("wide", ((V)(0D))).V, ((V)("i")));
Call(land_20, V.Undef, t_117, ((V)(0.12)), ((V)(4D)), ((V)(300D)));
return Call(loopN_26, V.Undef, t_117);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Puffs up tall and fluffy with sparkles, then sinks back into a soft wobble.")))).Put("surprised", Arr(Call(Fn((V _self1, int _argc118, V _a120, V _a121, V _a122, V _a123, V[] _rest119) => {
V t_124 = default;
t_124 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_124, "wait", ((V)(150D))), "to", ((V)(100D)), NewObj(3).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(4).Put("sq", ((V)((-0.24)))).Put("lift", ((V)(4D))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("o"))), "wait", ((V)(500D))), "to", ((V)(1400D)), NewObj(7).Put("sq", ((V)(0.04))).Put("lift", ((V)(0D))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).Put("wide", ((V)(0.3))).Put("open", ((V)(0.1))).Put("mw", ((V)(1D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("blink"))), "to", ((V)(300D)), NewObj(3).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(300D)));
return Invoke(Invoke(t_124, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Puffs up big in surprise, then slowly deflates like memory foam.")))).Put("squish", Arr(Call(Fn((V _self1, int _argc125, V _a127, V _a128, V _a129, V _a130, V[] _rest126) => {
V t_131 = default;
t_131 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(t_131, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.44))).Put("hap", ((V)(0.9))).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).V, ((V)("io"))), "wait", ((V)(300D)));
Invoke(Invoke(t_131, "to", ((V)(1500D)), NewObj(5).Put("sq", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("smile", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_131);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed flat, then rises back slowly like memory foam.")))).Put("quirk", Arr(Call(Fn((V _self1, int _argc132, V _a134, V _a135, V _a136, V _a137, V[] _rest133) => {
V t_138 = default;
t_138 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_138, "to", ((V)(500D)), NewObj(6).Put("sq", ((V)((-0.12)))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("close", ((V)(0.8))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.9))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(300D)), NewObj(2).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io"))), "to", ((V)(900D)), NewObj(5).Put("sq", ((V)(0.08))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0.4))).Put("hap", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_138, "osc", ((V)(1200D)), ((V)(2D)), NewObj(2).Put("sq", ((V)(0.1))).Put("close", ((V)(0.6))).V, NewObj(2).Put("sq", ((V)(0.07))).Put("close", ((V)(0.4))).V, ((V)("s"))), "to", ((V)(400D)), NewObj(4).Put("sq", ((V)(0D))).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_138, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Cosy stretch")), ((V)("A big tall stretch and yawn, then sinks down cosy and breathes slowly.")))).Put("press", NewObj(1).Put("hap", ((V)(0.5))).V).Put("rel", NewObj(2).Put("dur", ((V)(1700D))).Put("k", NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(0.22)), ((V)("o"))), Arr(((V)(1500D)), ((V)(0.02)), ((V)("o"))), Arr(((V)(1700D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(1D)), ((V)("io"))), Arr(((V)(1300D)), ((V)(1D))), Arr(((V)(1700D)), ((V)(0D)), ((V)("io"))))).V).V).V).Put("bao", NewObj(6).Put("happy", Arr(Call(Fn((V _self1, int _argc139, V _a141, V _a142, V _a143, V _a144, V[] _rest140) => {
V t_145 = default;
t_145 = Call(TL_9, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Call(jump_15, V.Undef, t_145, NewObj(7).Put("h", ((V)(7D))).Put("ant", ((V)(180D))).Put("up", ((V)(220D))).Put("c", ((V)(0.2))).Put("arm", ((V)(40D))).Put("chain", (true ? V.True : V.False)).Put("ev", Arr(Arr(((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D))))).V);
Call(land_20, V.Undef, t_145, ((V)(0.08)), ((V)(2D)), ((V)(240D)));
Call(jump_15, V.Undef, t_145, NewObj(6).Put("h", ((V)(8D))).Put("ant", ((V)(160D))).Put("up", ((V)(230D))).Put("c", ((V)(0.2))).Put("arm", ((V)(46D))).Put("ev", Arr(Arr(((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D))))).V);
return Call(loopN_26, V.Undef, t_145);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Pillowy hops with little puffs of steam from his knot.")))).Put("surprised", Arr(Call(Fn((V _self1, int _argc146, V _a148, V _a149, V _a150, V _a151, V[] _rest147) => {
V t_152 = default;
t_152 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_152, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(3).Put("wide", ((V)(1D))).Put("sq", ((V)(0.1))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(4).Put("sq", ((V)((-0.18)))).Put("lift", ((V)(6D))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(6D))), "to", ((V)(220D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.14))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_152, "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(7).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_152, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Steam bursts out of his knot like a kettle, a little hop, then he looks around.")))).Put("squish", Arr(Call(Fn((V _self1, int _argc153, V _a155, V _a156, V _a157, V _a158, V[] _rest154) => {
V t_159 = default;
t_159 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_159, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.4))).Put("hap", ((V)(0.9))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(4D))), "wait", ((V)(300D)));
Invoke(t_159, "to", ((V)(120D)), NewObj(6).Put("sq", ((V)((-0.18)))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_19, V.Undef, t_159, ((V)(0.1)), ((V)(3D)), ((V)(260D)));
Invoke(t_159, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_159);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("A pillowy squash that puffs steam out of his knot, then a soft bounce back.")))).Put("quirk", Arr(Call(Fn((V _self1, int _argc160, V _a162, V _a163, V _a164, V _a165, V[] _rest161) => {
V t_166 = default;
t_166 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(t_166, "to", ((V)(300D)), NewObj(3).Put("pitch", ((V)(0.1))).Put("ly", ((V)((-0.9)))).Put("lx", ((V)(0.1))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D))), "wait", ((V)(500D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_166, "to", ((V)(250D)), NewObj(2).Put("sq", ((V)(0.05))).Put("puff", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(4).Put("puff", ((V)((-0.3)))).Put("open", ((V)(0.4))).Put("mw", ((V)(0.5))).Put("sq", ((V)((-0.03)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(4).Put("puff", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(5).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("lx", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Invoke(t_166, "osc", ((V)(800D)), ((V)(2D)), NewObj(1).Put("tilt", ((V)(3D))).V, NewObj(1).Put("tilt", ((V)((-3D)))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_166, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Steam puff")), ((V)("Looks up at the steam rising from his knot and blows a little puff, pleased with himself.")))).Put("press", NewObj(1).Put("puff", ((V)(0.3))).V).Put("rel", NewObj(3).Put("dur", ((V)(1100D))).Put("k", NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.18))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.09)), ((V)("io"))), Arr(((V)(390D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(800D)), ((V)(1D))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("steam")), ((V)("head")), ((V)(4D))))).V).V).Put("dunkie", NewObj(6).Put("happy", Arr(Call(Fn((V _self1, int _argc167, V _a169, V _a170, V _a171, V _a172, V[] _rest168) => {
V t_173 = default;
t_173 = Call(TL_9, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Call(swing_17, V.Undef, t_173, ((V)(1400D)), ((V)(3D)), NewObj(3).Put("tilt", ((V)(12D))).Put("x", ((V)(3D))).Put("lean", ((V)(2D))).V, ((V)("io")));
Call(jump_15, V.Undef, t_173, NewObj(6).Put("h", ((V)(7D))).Put("ant", ((V)(150D))).Put("up", ((V)(210D))).Put("c", ((V)(0.16))).Put("arm", ((V)(40D))).Put("ev", Arr(Arr(((V)("emit")), ((V)("sprinkle")), ((V)("head")), ((V)(3D))))).V);
return Call(loopN_26, V.Undef, t_173);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Rocks side to side like a rolling wheel, then hops with sprinkles flying.")))).Put("surprised", Arr(Call(Fn((V _self1, int _argc174, V _a176, V _a177, V _a178, V _a179, V[] _rest175) => {
V t_180 = default;
t_180 = Call(TL_9, V.Undef);
Invoke(Invoke(t_180, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(4).Put("wide", ((V)(1D))).Put("sq", ((V)(0.1))).Put("open", ((V)(0.45))).Put("mw", ((V)(0.7))).V, ((V)("o")));
Call(jump_15, V.Undef, t_180, NewObj(9).Put("h", ((V)(8D))).Put("ant", ((V)(60D))).Put("up", ((V)(210D))).Put("c", ((V)(0.08))).Put("arm", ((V)(50D))).Put("x", ((V)((-5D)))).Put("air", NewObj(1).Put("tilt", ((V)((-10D)))).V).Put("fall", NewObj(1).Put("tilt", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("sprinkle")), ((V)("head")), ((V)(5D))))).V);
Invoke(Invoke(Invoke(Invoke(t_180, "wait", ((V)(200D))), "to", ((V)(400D)), NewObj(3).Put("lx", ((V)(0.7))).Put("ly", ((V)((-0.6)))).Put("htilt", ((V)(6D))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(400D)), NewObj(1).Put("htilt", ((V)((-4D)))).V, ((V)("io")));
Invoke(t_180, "to", ((V)(500D)), NewObj(9).Put("x", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("htilt", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_180, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Jumps back with sprinkles flying off, then checks his bite mark.")))).Put("squish", Arr(Call(Fn((V _self1, int _argc181, V _a183, V _a184, V _a185, V _a186, V[] _rest182) => {
V t_187 = default;
t_187 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_187, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(4).Put("sq", ((V)(0.38))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("body")), ((V)(4D))), "wait", ((V)(300D)));
Invoke(Invoke(t_187, "to", ((V)(120D)), NewObj(6).Put("sq", ((V)((-0.18)))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("sprinkle")), ((V)("head")), ((V)(4D)));
Call(jelly_19, V.Undef, t_187, ((V)(0.08)), ((V)(3D)), ((V)(230D)));
Invoke(t_187, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_187);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("A crunchy squash with crumbs, springs back and sprinkles fly.")))).Put("quirk", Arr(Call(Fn((V _self1, int _argc188, V _a190, V _a191, V _a192, V _a193, V[] _rest189) => {
V t_194 = default;
t_194 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(t_194, "to", ((V)(400D)), NewObj(4).Put("lx", ((V)(0.8))).Put("ly", ((V)((-0.7)))).Put("htilt", ((V)(8D))).Put("hyaw", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(400D))), "e", ((V)("blink")));
Invoke(Invoke(Invoke(Invoke(t_194, "to", ((V)(300D)), NewObj(2).Put("frown", ((V)(0.3))).Put("puff", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(320D)), NewObj(2).Put("armR", ((V)(138D))).Put("bend", ((V)((-2D)))).V, ((V)("io"))), "osc", ((V)(560D)), ((V)(2D)), NewObj(1).Put("armR", ((V)(122D))).V, NewObj(1).Put("armR", ((V)(138D))).V, ((V)("io"))), "to", ((V)(320D)), NewObj(8).Put("armR", ((V)(0D))).Put("bend", ((V)(0D))).Put("frown", ((V)(0D))).Put("puff", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hyaw", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_194, "to", ((V)(250D)), NewObj(5).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("sq", ((V)(0.04))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_194, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Bite check")), ((V)("Looks up at his bite mark, pats it, then shrugs and smiles.")))).Put("press", NewObj(1).Put("hap", ((V)(0.4))).V).Put("rel", NewObj(3).Put("dur", ((V)(1000D))).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.2))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.1)), ((V)("io"))), Arr(((V)(390D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(3D)), ((V)("o"))), Arr(((V)(270D)), ((V)(0D)), ((V)("i"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(700D)), ((V)(1D))), Arr(((V)(1000D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("sprinkle")), ((V)("head")), ((V)(4D))))).V).V).Put("frybo", NewObj(6).Put("happy", Arr(Call(Fn((V _self1, int _argc195, V _a197, V _a198, V _a199, V _a200, V[] _rest196) => {
V t_201 = default;
V a_202 = default;
t_201 = Call(TL_9, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).V);
a_202 = Get(t_201, "t");
Call(jump_15, V.Undef, t_201, NewObj(8).Put("h", ((V)(8D))).Put("ant", ((V)(130D))).Put("up", ((V)(180D))).Put("c", ((V)(0.14))).Put("arm", ((V)(50D))).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(2).Put("earL", ((V)((-14D)))).Put("earR", ((V)((-14D)))).V).Put("fall", NewObj(2).Put("earL", ((V)(6D))).Put("earR", ((V)(6D))).V).V);
Call(jump_15, V.Undef, t_201, NewObj(8).Put("h", ((V)(8D))).Put("ant", ((V)(110D))).Put("up", ((V)(180D))).Put("c", ((V)(0.14))).Put("arm", ((V)(50D))).Put("air", NewObj(2).Put("earL", ((V)((-14D)))).Put("earR", ((V)((-14D)))).V).Put("fall", NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("salt")), ((V)("head")), ((V)(4D))))).V);
Call(para_25, V.Undef, t_201, a_202, Fn((V _self1, int _argc203, V u_209, V _a206, V _a207, V _a208, V[] _rest204) => {
return Invoke(u_209, "to", ((V)((ToNum(Get(t_201, "t")) - ToNum(a_202)))), NewObj(1).Put("fw", ((V)(1.2))).V, ((V)("io")));
}, 1, "", true));
Invoke(t_201, "to", ((V)(300D)), NewObj(1).Put("fw", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_201);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Two quick hops with his fries fanning up and waving, a sprinkle of salt.")))).Put("surprised", Arr(Call(Fn((V _self1, int _argc210, V _a212, V _a213, V _a214, V _a215, V[] _rest211) => {
V t_216 = default;
t_216 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_216, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(6).Put("wide", ((V)(1D))).Put("sq", ((V)(0.08))).Put("earL", ((V)((-22D)))).Put("earR", ((V)((-22D)))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(5D))).Put("sq", ((V)((-0.12)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(600D)));
Invoke(Invoke(t_216, "to", ((V)(500D)), NewObj(4).Put("earL", ((V)(8D))).Put("earR", ((V)(8D))).Put("open", ((V)(0.1))).Put("mw", ((V)(1D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("wide", ((V)(0.3))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_216, "to", ((V)(400D)), NewObj(1).Put("lx", ((V)((-0.7)))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(400D)), NewObj(1).Put("lx", ((V)(0.7))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(4).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_216, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His fries shoot straight up like hair standing on end, then flop back down.")))).Put("squish", Arr(Call(Fn((V _self1, int _argc217, V _a219, V _a220, V _a221, V _a222, V[] _rest218) => {
V t_223 = default;
t_223 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(t_223, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(7).Put("sq", ((V)(0.36))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).Put("earL", ((V)(12D))).Put("earR", ((V)(12D))).Put("fw", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(300D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_223, "to", ((V)(110D)), NewObj(8).Put("sq", ((V)((-0.2)))).Put("earL", ((V)((-16D)))).Put("earR", ((V)((-16D)))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("salt")), ((V)("head")), ((V)(4D))), "to", ((V)(160D)), NewObj(3).Put("sq", ((V)(0.07))).Put("earL", ((V)(4D))).Put("earR", ((V)(4D))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(3).Put("sq", ((V)((-0.02)))).Put("earL", ((V)((-2D)))).Put("earR", ((V)((-2D)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(8).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("fw", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_223);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("His fries squeeze together with a crispy rustle, then pop back up with a sprinkle of salt.")))).Put("quirk", Arr(Call(Fn((V _self1, int _argc224, V _a226, V _a227, V _a228, V _a229, V[] _rest225) => {
V t_230 = default;
t_230 = Call(TL_9, V.Undef);
Invoke(t_230, "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.06))).Put("close", ((V)(0.6))).V, ((V)("io")));
Call(shake_16, V.Undef, t_230, NewObj(7).Put("P", ((V)(85D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.9)), ((V)(0.6)), ((V)(0.3)))).Put("head", ((V)(0.1))).Put("roll", ((V)(3D))).Put("ear", ((V)(16D))).Put("chest", ((V)(0.05))).Put("body", ((V)(0.8))).V);
Invoke(Invoke(t_230, "e", ((V)("emit")), ((V)("salt")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(2).Put("sq", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_230, "to", ((V)(400D)), NewObj(4).Put("armL", ((V)(142D))).Put("armR", ((V)(142D))).Put("ly", ((V)((-0.8)))).Put("sq", ((V)((-0.04)))).V, ((V)("io"))), "osc", ((V)(640D)), ((V)(2D)), NewObj(5).Put("armL", ((V)(124D))).Put("armR", ((V)(124D))).Put("earL", ((V)((-7D)))).Put("earR", ((V)((-7D)))).Put("fw", ((V)(0.8))).V, NewObj(5).Put("armL", ((V)(142D))).Put("armR", ((V)(142D))).Put("earL", ((V)(2D))).Put("earR", ((V)(2D))).Put("fw", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(380D)), NewObj(9).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("fw", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_230, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Fry fluff")), ((V)("Shakes his box so the fries rustle and settle, a sprinkle of salt, then fluffs his fries with both paws.")))).Put("press", NewObj(3).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).Put("fw", ((V)(0.6))).V).Put("rel", NewObj(3).Put("dur", ((V)(1000D))).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)((-0.2))), ((V)("o"))), Arr(((V)(240D)), ((V)(0.08)), ((V)("io"))), Arr(((V)(380D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(520D)), ((V)(0D)), ((V)("io"))))).Put("earL", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)((-16D))), ((V)("o"))), Arr(((V)(280D)), ((V)(6D)), ((V)("io"))), Arr(((V)(460D)), ((V)((-2D))), ((V)("io"))), Arr(((V)(620D)), ((V)(0D)), ((V)("io"))))).Put("earR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)((-16D))), ((V)("o"))), Arr(((V)(280D)), ((V)(6D)), ((V)("io"))), Arr(((V)(460D)), ((V)((-2D))), ((V)("io"))), Arr(((V)(620D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("salt")), ((V)("head")), ((V)(3D))))).V).V).Put("bunbun", NewObj(6).Put("happy", Arr(Call(Fn((V _self1, int _argc231, V _a233, V _a234, V _a235, V _a236, V[] _rest232) => {
V t_237 = default;
t_237 = Call(TL_9, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).V);
Call(jump_15, V.Undef, t_237, NewObj(7).Put("h", ((V)(9D))).Put("ant", ((V)(150D))).Put("up", ((V)(220D))).Put("c", ((V)(0.16))).Put("arm", ((V)(45D))).Put("air", NewObj(1).Put("split", ((V)(0.5))).V).Put("fall", NewObj(1).Put("split", ((V)(0D))).V).V);
Call(swing_17, V.Undef, t_237, ((V)(1000D)), ((V)(3D)), NewObj(2).Put("fan", ((V)(0.6))).Put("tilt", ((V)(4D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_237);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A hop where his layers lift apart in the air and stack back, then a happy fan sway.")))).Put("surprised", Arr(Call(Fn((V _self1, int _argc238, V _a240, V _a241, V _a242, V _a243, V[] _rest239) => {
V t_244 = default;
t_244 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_244, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(4).Put("wide", ((V)(1D))).Put("open", ((V)(0.45))).Put("mw", ((V)(0.7))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(3).Put("split", ((V)(1.1))).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.08)))).V, ((V)("o"))), "wait", ((V)(350D))), "to", ((V)(140D)), NewObj(3).Put("split", ((V)(0D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.16))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(3D))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_244, "wait", ((V)(200D))), "to", ((V)(300D)), NewObj(1).Put("lx", ((V)((-0.7)))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(1).Put("lx", ((V)(0.7))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(6).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_244, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His layers jump apart in fright and slam back together into a stack.")))).Put("squish", Arr(Call(Fn((V _self1, int _argc245, V _a247, V _a248, V _a249, V _a250, V[] _rest246) => {
V t_251 = default;
t_251 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_251, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(5).Put("sq", ((V)(0.4))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).Put("fan", ((V)(0.4))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("note")), ((V)("head")), ((V)(1D))), "wait", ((V)(300D)));
Invoke(t_251, "to", ((V)(120D)), NewObj(7).Put("sq", ((V)((-0.18)))).Put("fan", ((V)((-0.3)))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o")));
Call(jelly_19, V.Undef, t_251, ((V)(0.1)), ((V)(3D)), ((V)(230D)));
Invoke(t_251, "to", ((V)(220D)), NewObj(5).Put("fan", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_251);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("His stack squashes with a squeaky-cheese squeak, the layers fan out and wobble back.")))).Put("quirk", Arr(Call(Fn((V _self1, int _argc252, V _a254, V _a255, V _a256, V _a257, V[] _rest253) => {
V t_258 = default;
t_258 = Call(TL_9, V.Undef);
Invoke(t_258, "to", ((V)(400D)), NewObj(2).Put("ly", ((V)(0.8))).Put("pitch", ((V)((-0.2)))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_258, "to", ((V)(300D)), NewObj(1).Put("shuf", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("shuf", ((V)((-0.8)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("shuf", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("shuf", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_258, "to", ((V)(260D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(10D)), ((V)(2D))), NewObj(2).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).V), ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(2).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).V, NewObj(2).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_13, V.Undef, NOHANDS_14, NewObj(6).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io")));
return Invoke(Invoke(Invoke(t_258, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Restack")), ((V)("Looks down at his stack, the layers shuffle like cards, and he pats them back into a neat burger.")))).Put("press", NewObj(1).Put("fan", ((V)(0.3))).V).Put("rel", NewObj(3).Put("dur", ((V)(1100D))).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.18))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.1)), ((V)("io"))), Arr(((V)(390D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))))).Put("split", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(0.5)), ((V)("o"))), Arr(((V)(400D)), ((V)(0D)), ((V)("i"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(800D)), ((V)(1D))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("note")), ((V)("head")), ((V)(1D))))).V).V).Put("choco", NewObj(6).Put("happy", Arr(Call(Fn((V _self1, int _argc259, V _a261, V _a262, V _a263, V _a264, V[] _rest260) => {
V t_265 = default;
t_265 = Call(TL_9, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(t_265, "to", ((V)(200D)), NewObj(1).Put("tw", ((V)(1.2))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D)));
Call(jump_15, V.Undef, t_265, NewObj(5).Put("h", ((V)(7D))).Put("ant", ((V)(140D))).Put("up", ((V)(200D))).Put("c", ((V)(0.1))).Put("arm", ((V)(50D))).V);
Invoke(t_265, "to", ((V)(400D)), NewObj(1).Put("tw", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_265);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("His segments twinkle and he does a crisp little hop.")))).Put("surprised", Arr(Call(Fn((V _self1, int _argc266, V _a268, V _a269, V _a270, V _a271, V[] _rest267) => {
V t_272 = default;
t_272 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_272, "wait", ((V)(150D))), "to", ((V)(60D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.45))).Put("mw", ((V)(0.7))).Put("sq", ((V)((-0.06)))).Put("tw", ((V)(1.4))).Put("lift", ((V)(2D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "wait", ((V)(500D))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("tw", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_272, "to", ((V)(900D)), NewObj(4).Put("melt", ((V)(0.5))).Put("sq", ((V)(0.08))).Put("wide", ((V)(0.4))).Put("frown", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(8).Put("melt", ((V)(0D))).Put("sq", ((V)(0D))).Put("frown", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("o")));
return Invoke(Invoke(t_272, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Snaps stiff with his segments flashing, goes a little gooey, then pulls himself together.")))).Put("squish", Arr(Call(Fn((V _self1, int _argc273, V _a275, V _a276, V _a277, V _a278, V[] _rest274) => {
V t_279 = default;
t_279 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(t_279, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(3).Put("sq", ((V)(0.3))).Put("melt", ((V)(0.8))).Put("hap", ((V)(0.9))).V, ((V)("io"))), "wait", ((V)(350D)));
Invoke(Invoke(Invoke(Invoke(t_279, "to", ((V)(120D)), NewObj(6).Put("sq", ((V)((-0.12)))).Put("melt", ((V)(0D))).Put("tw", ((V)(1D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0.04))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(4).Put("sq", ((V)(0D))).Put("tw", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_279);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Melts into a gooey puddle when squashed, then snaps back into shape.")))).Put("quirk", Arr(Call(Fn((V _self1, int _argc280, V _a282, V _a283, V _a284, V _a285, V[] _rest281) => {
V t_286 = default;
t_286 = Call(TL_9, V.Undef);
Invoke(Invoke(t_286, "to", ((V)(1200D)), NewObj(4).Put("melt", ((V)(0.45))).Put("sq", ((V)(0.06))).Put("close", ((V)(0.5))).Put("hap", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(300D)));
Invoke(t_286, "to", ((V)(150D)), NewObj(2).Put("wide", ((V)(0.8))).Put("close", ((V)(0D))).V, ((V)("o")));
Call(shake_16, V.Undef, t_286, NewObj(6).Put("P", ((V)(80D))).Put("env", Arr(((V)(0.5)), ((V)(1D)), ((V)(0.8)), ((V)(0.4)))).Put("head", ((V)(0.12))).Put("roll", ((V)(3D))).Put("ear", ((V)(0D))).Put("body", ((V)(0.6))).V);
Invoke(Invoke(t_286, "to", ((V)(200D)), NewObj(3).Put("melt", ((V)(0D))).Put("sq", ((V)((-0.04)))).Put("tw", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(5).Put("sq", ((V)(0D))).Put("tw", ((V)(0D))).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_286, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Melty moment")), ((V)("Slowly starts to melt in the warmth, notices, shakes it off and firms back up.")))).Put("press", NewObj(1).Put("melt", ((V)(0.6))).V).Put("rel", NewObj(3).Put("dur", ((V)(900D))).Put("k", NewObj(3).Put("melt", Arr(Arr(((V)(0D)), ((V)(0.4))), Arr(((V)(180D)), ((V)(0D)), ((V)("o"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)((-0.14))), ((V)("o"))), Arr(((V)(240D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(380D)), ((V)(0D)), ((V)("io"))))).Put("tw", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)(1.1)), ((V)("o"))), Arr(((V)(600D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("spark")), ((V)("head")), ((V)(2D))))).V).V).Put("scoop", NewObj(6).Put("happy", Arr(Call(Fn((V _self1, int _argc287, V _a289, V _a290, V _a291, V _a292, V[] _rest288) => {
V t_293 = default;
V a_294 = default;
t_293 = Call(TL_9, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
a_294 = Get(t_293, "t");
Call(swing_17, V.Undef, t_293, ((V)(1400D)), ((V)(3D)), NewObj(3).Put("tilt", ((V)(6D))).Put("x", ((V)(1.5))).Put("bend", ((V)(3D))).V, ((V)("io")));
Call(para_25, V.Undef, t_293, a_294, Fn((V _self1, int _argc295, V u_301, V _a298, V _a299, V _a300, V[] _rest296) => {
return Invoke(u_301, "osc", ((V)(1400D)), ((V)(4D)), NewObj(1).Put("chb", ((V)(1D))).V, NewObj(1).Put("chb", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
Invoke(Invoke(Invoke(t_293, "to", ((V)(150D)), NewObj(1).Put("chy", ((V)(1D))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("chy", ((V)(0D))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
return Call(loopN_26, V.Undef, t_293);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Sways side to side with his cherry bopping, then the cherry pops up and lands with a heart.")))).Put("surprised", Arr(Call(Fn((V _self1, int _argc302, V _a304, V _a305, V _a306, V _a307, V[] _rest303) => {
V t_308 = default;
t_308 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_308, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(4).Put("wide", ((V)(1D))).Put("open", ((V)(0.45))).Put("mw", ((V)(0.7))).Put("sq", ((V)(0.08))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(2).Put("chy", ((V)(1.2))).Put("sq", ((V)((-0.1)))).V, ((V)("o"))), "wait", ((V)(150D))), "to", ((V)(300D)), NewObj(2).Put("chy", ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(t_308, "to", ((V)(200D)), NewObj(1).Put("close", ((V)(0.4))).V, ((V)("io")));
Call(shake_16, V.Undef, t_308, NewObj(6).Put("P", ((V)(70D))).Put("env", Arr(((V)(0.4)), ((V)(0.8)), ((V)(1D)), ((V)(0.8)), ((V)(0.5)), ((V)(0.25)))).Put("head", ((V)(0.1))).Put("roll", ((V)(2D))).Put("ear", ((V)(0D))).Put("body", ((V)(0.6))).V);
Invoke(t_308, "to", ((V)(400D)), NewObj(6).Put("close", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_308, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His cherry jumps up off his head and lands back, then a cold little shiver.")))).Put("squish", Arr(Call(Fn((V _self1, int _argc309, V _a311, V _a312, V _a313, V _a314, V[] _rest310) => {
V t_315 = default;
t_315 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(t_315, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.4))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "wait", ((V)(300D)));
Invoke(Invoke(t_315, "to", ((V)(110D)), NewObj(7).Put("sq", ((V)((-0.18)))).Put("chy", ((V)(0.8))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(1).Put("chy", ((V)(0D))).V, ((V)("i")));
Call(jelly_19, V.Undef, t_315, ((V)(0.1)), ((V)(3D)), ((V)(240D)));
Invoke(t_315, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_315);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("His soft scoop squishes on the cone, then springs back and the cherry pops up.")))).Put("quirk", Arr(Call(Fn((V _self1, int _argc316, V _a318, V _a319, V _a320, V _a321, V[] _rest317) => {
V t_322 = default;
t_322 = Call(TL_9, V.Undef);
Invoke(Invoke(t_322, "to", ((V)(400D)), NewObj(3).Put("lx", ((V)(0.2))).Put("ly", ((V)((-0.9)))).Put("pitch", ((V)(0.15))).V, ((V)("io"))), "wait", ((V)(200D)));
Invoke(t_322, "osc", ((V)(900D)), ((V)(3D)), NewObj(2).Put("chb", ((V)(1.2))).Put("htilt", ((V)(3D))).V, NewObj(2).Put("chb", ((V)(0D))).Put("htilt", ((V)((-3D)))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_322, "to", ((V)(150D)), NewObj(1).Put("chy", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("chy", ((V)(0D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(6).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("lx", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_322, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Cherry flip")), ((V)("Looks up at his cherry, wiggles it, then flips it up and catches it.")))).Put("press", NewObj(1).Put("chb", ((V)(0.6))).V).Put("rel", NewObj(2).Put("dur", ((V)(1000D))).Put("k", NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.18))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.09)), ((V)("io"))), Arr(((V)(390D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))))).Put("chy", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(0.9)), ((V)("o"))), Arr(((V)(380D)), ((V)(0D)), ((V)("i"))))).V).V).V).Put("boba", NewObj(6).Put("happy", Arr(Call(Fn((V _self1, int _argc323, V _a325, V _a326, V _a327, V _a328, V[] _rest324) => {
V t_329 = default;
V a_330 = default;
t_329 = Call(TL_9, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
a_330 = Get(t_329, "t");
Call(jump_15, V.Undef, t_329, NewObj(6).Put("h", ((V)(8D))).Put("ant", ((V)(140D))).Put("up", ((V)(200D))).Put("c", ((V)(0.14))).Put("arm", ((V)(45D))).Put("chain", (true ? V.True : V.False)).V);
Call(jump_15, V.Undef, t_329, NewObj(5).Put("h", ((V)(8D))).Put("ant", ((V)(120D))).Put("up", ((V)(200D))).Put("c", ((V)(0.14))).Put("arm", ((V)(45D))).V);
Call(para_25, V.Undef, t_329, a_330, Fn((V _self1, int _argc331, V u_337, V _a334, V _a335, V _a336, V[] _rest332) => {
return Invoke(Invoke(u_337, "to", ((V)(300D)), NewObj(3).Put("pop", ((V)(1.5))).Put("swirl", ((V)(1.5))).Put("stw", ((V)(1D))).V, ((V)("o"))), "to", ((V)(((ToNum(Get(t_329, "t")) - ToNum(a_330)) - 300D))), NewObj(1).Put("pop", ((V)(0.4))).V, ((V)("io")));
}, 1, "", true));
Invoke(t_329, "to", ((V)(400D)), NewObj(3).Put("pop", ((V)(0D))).Put("swirl", ((V)(0D))).Put("stw", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_329);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Bouncy hops with his pearls popping and swirling and his straw wiggling.")))).Put("surprised", Arr(Call(Fn((V _self1, int _argc338, V _a340, V _a341, V _a342, V _a343, V[] _rest339) => {
V t_344 = default;
t_344 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_344, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.45))).Put("mw", ((V)(0.7))).Put("sq", ((V)(0.08))).Put("sup", ((V)(1.4))).Put("pop", ((V)(2D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.1)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0D))).Put("pop", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(400D)));
Invoke(Invoke(Invoke(Invoke(t_344, "to", ((V)(500D)), NewObj(3).Put("sup", ((V)(0D))).Put("pop", ((V)(0D))).Put("wide", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("lx", ((V)((-0.7)))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(6).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_344, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His straw shoots up and the pearls jump, then everything settles back down.")))).Put("squish", Arr(Call(Fn((V _self1, int _argc345, V _a347, V _a348, V _a349, V _a350, V[] _rest346) => {
V t_351 = default;
t_351 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(t_351, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(5).Put("sq", ((V)(0.36))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).Put("slurp", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(400D)));
Invoke(Invoke(Invoke(Invoke(t_351, "to", ((V)(110D)), NewObj(7).Put("sq", ((V)((-0.16)))).Put("slurp", ((V)(0D))).Put("sup", ((V)(0.8))).Put("pop", ((V)(1.5))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(2).Put("sup", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(6).Put("sq", ((V)(0D))).Put("pop", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_351);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed, a pearl rides up his straw and pops out the top with bubbles.")))).Put("quirk", Arr(Call(Fn((V _self1, int _argc352, V _a354, V _a355, V _a356, V _a357, V[] _rest353) => {
V t_358 = default;
t_358 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_358, "to", ((V)(350D)), NewObj(3).Put("lx", ((V)(0.3))).Put("ly", ((V)((-0.8)))).Put("pitch", ((V)(0.1))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("slurp", ((V)(1D))).Put("mw", ((V)(0.5))).Put("open", ((V)(0.1))).V, ((V)("io"))), "wait", ((V)(900D))), "to", ((V)(200D)), NewObj(4).Put("slurp", ((V)(0D))).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).Put("puff", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("io"))), "e", ((V)("gulp")));
Invoke(Invoke(Invoke(t_358, "to", ((V)(300D)), NewObj(7).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("lx", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("swirl", ((V)(1.5))).V, ((V)("io"))), "wait", ((V)(600D))), "to", ((V)(400D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_358, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Slurp")), ((V)("Sips from his own straw (a pearl rides up), gulps, and his pearls swirl happily.")))).Put("press", NewObj(2).Put("slurp", ((V)(0.8))).Put("pop", ((V)(0.6))).V).Put("rel", NewObj(3).Put("dur", ((V)(1000D))).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.16))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.07)), ((V)("io"))), Arr(((V)(390D)), ((V)((-0.02))), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))))).Put("sup", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(0.8)), ((V)("o"))), Arr(((V)(500D)), ((V)(0D)), ((V)("io"))))).Put("pop", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)(1.5)), ((V)("o"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("bubble")), ((V)("head")), ((V)(2D))))).V).V).Put("chefbun", NewObj(6).Put("happy", Arr(Call(Fn((V _self1, int _argc359, V _a361, V _a362, V _a363, V _a364, V[] _rest360) => {
V t_365 = default;
t_365 = Call(TL_9, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.25))).V);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_365, "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-15D)))), NewObj(2).Put("armR", ((V)(20D))).Put("close", ((V)(0.9))).V), ((V)("io"))), "to", ((V)(140D)), NewObj(3).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).Put("puff", ((V)((-0.2)))).V, ((V)("o"))), "to", ((V)(220D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)((-4D))), ((V)((-10D)))), NewObj(4).Put("armR", ((V)(80D))).Put("open", ((V)(0.25))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).V), ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("pawR")), ((V)(3D))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(300D))), "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D))), NewObj(2).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).V), ((V)("io")));
Call(jump_15, V.Undef, t_365, NewObj(5).Put("h", ((V)(5D))).Put("ant", ((V)(140D))).Put("up", ((V)(180D))).Put("c", ((V)(0.12))).Put("arm", ((V)(30D))).V);
return Call(loopN_26, V.Undef, t_365);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A chef's kiss - fingers to his lips and flung open with sparkles - then a proud little hop.")))).Put("surprised", Arr(Call(Fn((V _self1, int _argc366, V _a368, V _a369, V _a370, V _a371, V[] _rest367) => {
V t_372 = default;
t_372 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_372, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(4).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("sq", ((V)(0.08))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(4).Put("lift", ((V)(5D))).Put("sq", ((V)((-0.12)))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i")));
Invoke(Invoke(Invoke(t_372, "to", ((V)(300D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)((-4D))), ((V)((-30D)))), NewObj(4).Put("sq", ((V)(0D))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("htilt", ((V)(4D))).V), ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(3).Put("htilt", ((V)(6D))).Put("armL", ((V)(142D))).Put("armR", ((V)(142D))).V, NewObj(3).Put("htilt", ((V)(2D))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).V, ((V)("io"))), "to", ((V)(350D)), Call(o_13, V.Undef, NOHANDS_14, NewObj(8).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("htilt", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io")));
return Invoke(Invoke(t_372, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Jumps and grabs his chef hat with both paws to keep it on, then straightens it.")))).Put("squish", Arr(Call(Fn((V _self1, int _argc373, V _a375, V _a376, V _a377, V _a378, V[] _rest374) => {
V t_379 = default;
t_379 = Call(TL_9, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_379, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.42))).Put("hap", ((V)(0.9))).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(3D))), "wait", ((V)(300D)));
Invoke(t_379, "to", ((V)(300D)), NewObj(4).Put("sq", ((V)(0.1))).Put("hap", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
{
double i_380 = 0;
i_380 = 0D;
while (true) {
if (!((i_380 < 2D))) break;
Invoke(Invoke(t_379, "to", ((V)(150D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(8D)), ((V)(4D))), NewObj(1).Put("sq", ((V)(0.12))).V), ((V)("io"))), "to", ((V)(180D)), Call(o_13, V.Undef, NOHANDS_14, NewObj(1).Put("sq", ((V)((0.04 * (1D - i_380))))).V), ((V)("io")));
i_380++;
}
}
Invoke(Invoke(t_379, "to", ((V)(200D)), NewObj(3).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_379);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Flattened like dough with a puff of flour, then pats himself back into shape.")))).Put("quirk", Arr(Call(Fn((V _self1, int _argc382, V _a384, V _a385, V _a386, V _a387, V[] _rest383) => {
V t_388 = default;
t_388 = Call(TL_9, V.Undef);
Invoke(Invoke(t_388, "to", ((V)(350D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-15D)))), NewObj(3).Put("armR", ((V)(20D))).Put("pitch", ((V)((-0.05)))).Put("ly", ((V)(0.4))).V), ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(2).Put("open", ((V)(0.2))).Put("tongue", ((V)(0.6))).V, NewObj(2).Put("open", ((V)(0D))).Put("tongue", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_388, "to", ((V)(400D)), NewObj(3).Put("close", ((V)(0.85))).Put("htilt", ((V)(6D))).Put("pitch", ((V)(0.1))).V, ((V)("io"))), "wait", ((V)(400D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_388, "to", ((V)(140D)), NewObj(3).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).Put("puff", ((V)((-0.2)))).V, ((V)("o"))), "to", ((V)(220D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)((-4D))), ((V)((-10D)))), NewObj(7).Put("armR", ((V)(80D))).Put("open", ((V)(0.25))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).Put("close", ((V)(0D))).Put("htilt", ((V)(0D))).Put("pitch", ((V)(0D))).V), ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("pawR")), ((V)(3D))), "wait", ((V)(300D))), "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D))), NewObj(4).Put("armR", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("ly", ((V)(0D))).V), ((V)("io")));
return Invoke(Invoke(Invoke(t_388, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Taste test")), ((V)("Tastes something from his paw, thinks about it, then a proud chef's kiss.")))).Put("press", NewObj(1).Put("hap", ((V)(0.4))).V).Put("rel", NewObj(3).Put("dur", ((V)(1100D))).Put("k", NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.18))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.08)), ((V)("io"))), Arr(((V)(390D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(800D)), ((V)(1D))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("dust")), ((V)("body")), ((V)(2D))))).V).V).V;
eyes_29 = Fn((V _self1, int _argc389, V t_395, V d_396, V _a393, V _a394, V[] _rest390) => {
return Invoke(Invoke(t_395, "to", ((V)(110D)), NewObj(1).Put("lx", ((V)((ToNum(d_396) * 0.9)))).V, ((V)("o"))), "e", ((V)("blink")));
}, 2, "", true);
DANCES_30 = NewObj(9).Put("mallow", Arr(Call(Fn((V _self1, int _argc397, V _a399, V _a400, V _a401, V _a402, V[] _rest398) => {
V t_403 = default;
double B_404 = 0;
V a_405 = default;
t_403 = Call(TL_9, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_404 = 520D;
Invoke(Arr(((V)(0.12)), ((V)(0.24)), ((V)(0.36))), "forEach", Fn((V _self1, int _argc406, V v_412, V i_413, V _a410, V _a411, V[] _rest407) => {
return Invoke(Invoke(t_403, "to", ((V)(200D)), NewObj(4).Put("sq", v_412).Put("armL", ((V)((20D - (ToNum(i_413) * 10D))))).Put("armR", ((V)((20D - (ToNum(i_413) * 10D))))).Put("close", ((V)((SEqN(i_413, 2D) ? 0.6 : 0D)))).V, ((V)("o"))), "wait", ((V)((B_404 - 200D))));
}, 2, "", true));
Invoke(Invoke(Invoke(Invoke(t_403, "to", ((V)(1400D)), NewObj(6).Put("sq", ((V)((-0.2)))).Put("lift", ((V)(2D))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("close", ((V)(0D))).Put("wide", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(240D)), NewObj(1).Put("sq", ((V)((-0.24)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("sq", ((V)((-0.19)))).V, ((V)("io")));
Call(swing_17, V.Undef, t_403, ((V)(2000D)), ((V)(3D)), NewObj(5).Put("bend", ((V)(7D))).Put("x", ((V)(1.4))).Put("htilt", ((V)((-3D)))).Put("armL", ((V)(12D))).Put("armR", ((V)((-12D)))).V, ((V)("io")));
Invoke(t_403, "to", ((V)(320D)), NewObj(5).Put("sq", ((V)(0.14))).Put("lift", ((V)(0D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("wide", ((V)(0D))).V, ((V)("i")));
Call(land_20, V.Undef, t_403, ((V)(0.16)), ((V)(4D)), ((V)(360D)));
Call(eyes_29, V.Undef, t_403, ((V)(1D)));
a_405 = Get(t_403, "t");
Invoke(Invoke(t_403, "to", ((V)(1800D)), NewObj(3).Put("spin", ((V)(360D))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(t_403, "at", a_405);
Call(steps_18, V.Undef, t_403, ((V)(1800D)), ((V)(4D)), ((V)(2D)));
Invoke(Arr(((V)(0D)), ((V)(600D)), ((V)(1200D))), "forEach", Fn((V _self1, int _argc414, V d_420, V _a417, V _a418, V _a419, V[] _rest415) => {
return Invoke(Invoke(t_403, "at", Add(a_405, d_420)), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D)));
}, 1, "", true));
Invoke(Invoke(t_403, "at", Add(a_405, ((V)(1801D)))), "to", ((V)(250D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_403, "to", ((V)(300D)), NewObj(4).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(2D))).Put("armL", ((V)(165D))).Put("armR", ((V)(165D))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(5).Put("sq", ((V)(0.45))).Put("lift", ((V)(0D))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).Put("close", ((V)(1D))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("dust")), ((V)("footL")), ((V)(3D))), "e", ((V)("emit")), ((V)("dust")), ((V)("footR")), ((V)(3D))), "wait", ((V)(400D)));
Invoke(Invoke(Invoke(t_403, "to", ((V)(1500D)), NewObj(4).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(2D))), "wait", ((V)(250D)));
return Invoke(Invoke(t_403, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Marshmallow Mellow")), ((V)("Memory-foam steps down, one long slow rise to tall, a taffy stretch sway, a pillow flop, turns on the roasting stick in a puff of steam, gets squashed into a s'more and slowly rises again.")))).Put("bao", Arr(Call(Fn((V _self1, int _argc421, V _a423, V _a424, V _a425, V _a426, V[] _rest422) => {
V t_427 = default;
double B_428 = 0;
t_427 = Call(TL_9, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_428 = 500D;
Invoke(Invoke(t_427, "to", ((V)(300D)), NewObj(4).Put("sq", ((V)(0.22))).Put("armL", ((V)((-6D)))).Put("armR", ((V)((-6D)))).Put("close", ((V)(0.5))).V, ((V)("io"))), "wait", ((V)(200D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_427, "to", ((V)(700D)), NewObj(3).Put("sq", ((V)(0.08))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D))), "wait", ((V)(150D))), "to", ((V)(800D)), NewObj(6).Put("sq", ((V)((-0.12)))).Put("lift", ((V)(1D))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("close", ((V)(0D))).Put("wide", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(2).Put("sq", ((V)((-0.08)))).Put("wide", ((V)(0D))).V, ((V)("io")));
{
double i_429 = 0;
i_429 = 0D;
while (true) {
if (!((i_429 < 4D))) break;
double d_431 = 0;
d_431 = (NumTruthy((i_429 % 2D)) ? 1D : (-1D));
Call(jump_15, V.Undef, t_427, NewObj(9).Put("h", ((V)(5D))).Put("ant", ((V)(120D))).Put("up", ((V)(170D))).Put("c", ((V)(0.14))).Put("arm", ((V)(50D))).Put("chain", ((i_429 < 3D) ? V.True : V.False)).Put("air", NewObj(2).Put("tilt", ((V)((d_431 * 5D)))).Put("htilt", ((V)(((-d_431) * 3D)))).V).Put("fall", NewObj(2).Put("tilt", ((V)(0D))).Put("htilt", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D))))).V);
i_429++;
}
}
Call(swing_17, V.Undef, t_427, ((V)(2000D)), ((V)(3D)), NewObj(5).Put("twist", ((V)(0.55))).Put("htilt", ((V)(5D))).Put("bend", ((V)((-2D)))).Put("armL", ((V)(25D))).Put("armR", ((V)((-25D)))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_427, "to", ((V)(500D)), NewObj(4).Put("puff", ((V)(1D))).Put("sq", ((V)((-0.05)))).Put("lift", ((V)(1D))).Put("close", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(4).Put("puff", ((V)((-0.2)))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.45))).Put("close", ((V)(0.8))).V, ((V)("o"))), "em", ((V)(1000D)), ((V)(140D)), ((V)("steam")), ((V)("head")), ((V)(1D))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "osc", ((V)(1000D)), ((V)(5D)), NewObj(2).Put("lift", ((V)(2.2))).Put("sq", ((V)((-0.08)))).V, NewObj(2).Put("lift", ((V)(1D))).Put("sq", ((V)((-0.04)))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(300D)), NewObj(6).Put("puff", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("close", ((V)(0D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(t_427, "to", ((V)(260D)), NewObj(5).Put("sq", ((V)(0.18))).Put("bend", ((V)((-6D)))).Put("x", ((V)((-1.5)))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("i")));
Call(jelly_19, V.Undef, t_427, ((V)(0.12)), ((V)(3D)), ((V)(320D)));
Invoke(t_427, "to", ((V)(300D)), NewObj(4).Put("bend", ((V)(0D))).Put("x", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(jump_15, V.Undef, t_427, NewObj(6).Put("h", ((V)(8D))).Put("ant", ((V)(200D))).Put("up", ((V)(240D))).Put("c", ((V)(0.2))).Put("arm", ((V)(70D))).Put("ev", Arr(Arr(((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(2D))), Arr(((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(3D))))).V);
return Invoke(Invoke(t_427, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Steamer Proof")), ((V)("Rises like proofing dough in two steamy breaths, bounces in the steamer basket, wrings his pleats in a pinch-and-twist, whistles like a kettle with steam streaming out, a pillowy plop and a proud hop.")))).Put("dunkie", Arr(Call(Fn((V _self1, int _argc432, V _a434, V _a435, V _a436, V _a437, V[] _rest433) => {
V t_438 = default;
double B_439 = 0;
V a_440 = default;
t_438 = Call(TL_9, V.Undef, NewObj(1).Put("smile", ((V)(0.9))).V);
B_439 = 500D;
Call(eyes_29, V.Undef, t_438, ((V)((-1D))));
Invoke(Invoke(Invoke(t_438, "to", ((V)(200D)), NewObj(2).Put("tilt", ((V)(6D))).Put("sq", ((V)(0.06))).V, ((V)("io"))), "to", ((V)(900D)), NewObj(3).Put("x", ((V)((-6D)))).Put("tilt", ((V)((-32D)))).Put("footL", ((V)(2D))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(2).Put("tilt", ((V)((-28D)))).Put("footL", ((V)(0D))).V, ((V)("io")));
Call(eyes_29, V.Undef, t_438, ((V)(1D)));
Invoke(Invoke(Invoke(Invoke(t_438, "to", ((V)(1200D)), NewObj(3).Put("x", ((V)(6D))).Put("tilt", ((V)(32D))).Put("footR", ((V)(2D))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(2).Put("tilt", ((V)(28D))).Put("footR", ((V)(0D))).V, ((V)("io"))), "to", ((V)(800D)), NewObj(3).Put("x", ((V)(0D))).Put("tilt", ((V)((-4D)))).Put("lx", ((V)(0D))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io")));
Invoke(t_438, "to", ((V)(260D)), NewObj(4).Put("twist", ((V)((-0.4)))).Put("sq", ((V)(0.1))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("io")));
a_440 = Get(t_438, "t");
Invoke(Invoke(t_438, "to", ((V)(1500D)), NewObj(4).Put("spin", ((V)(1080D))).Put("lift", ((V)(2D))).Put("twist", ((V)(0D))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(t_438, "at", Add(a_440, ((V)(1300D))));
Invoke(Arr(((V)(10D)), ((V)((-8D))), ((V)(6D)), ((V)((-4D))), ((V)(2D)), ((V)(0D))), "forEach", Fn((V _self1, int _argc441, V v_447, V _a444, V _a445, V _a446, V[] _rest442) => {
return Invoke(t_438, "to", ((V)(140D)), NewObj(3).Put("tilt", v_447).Put("lift", ((V)((Truthy(v_447) ? 1D : 0D)))).Put("cross", ((V)((Truthy(v_447) ? 0.6 : 0D)))).V, ((V)("io")));
}, 1, "", true));
Invoke(Invoke(t_438, "to", ((V)(200D)), NewObj(3).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("sprinkle")), ((V)("head")), ((V)(3D)));
{
double i_448 = 0;
i_448 = 0D;
while (true) {
if (!((i_448 < 8D))) break;
double an_450 = 0;
an_450 = (((i_448 + 1D) * System.Math.PI) / 2D);
Invoke(t_438, "to", ((V)((B_439 / 2D))), NewObj(5).Put("x", ((V)((3D * FdLibm.Sin(an_450))))).Put("bend", ((V)((5D * FdLibm.Cos(an_450))))).Put("htilt", ((V)(((-2D) * FdLibm.Sin(an_450))))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)("io")));
i_448++;
}
}
Invoke(t_438, "to", ((V)(250D)), NewObj(5).Put("x", ((V)(0D))).Put("bend", ((V)(0D))).Put("htilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_438, "to", ((V)(300D)), NewObj(3).Put("sq", ((V)(0.28))).Put("pitch", ((V)((-0.25)))).Put("lift", ((V)((-1D)))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("coffee")), ((V)("body")), ((V)(4D))), "wait", ((V)(200D))), "to", ((V)(240D)), NewObj(3).Put("sq", ((V)((-0.08)))).Put("pitch", ((V)(0.05))).Put("lift", ((V)(1D))).V, ((V)("o")));
Call(shake_16, V.Undef, t_438, NewObj(6).Put("P", ((V)(85D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.8)), ((V)(0.5)), ((V)(0.25)))).Put("head", ((V)(0.2))).Put("roll", ((V)(4D))).Put("body", ((V)(1D))).Put("chest", ((V)(0.1))).V);
Invoke(Invoke(t_438, "e", ((V)("emit")), ((V)("coffee")), ((V)("body")), ((V)(3D))), "e", ((V)("emit")), ((V)("sprinkle")), ((V)("head")), ((V)(3D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_438, "to", ((V)(200D)), NewObj(3).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("winkR", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(300D))), "to", ((V)(200D)), NewObj(1).Put("winkR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_438, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Coin Spin Roll")), ((V)("Rolls away like a wheel and back, spins like a coin on a table (front, thin edge, back) and wobbles down like one, a bit dizzy, hula-hoops with his whole ring, dunks in coffee, shakes it off and winks.")))).Put("frybo", Arr(Call(Fn((V _self1, int _argc451, V _a453, V _a454, V _a455, V _a456, V[] _rest452) => {
V t_457 = default;
double B_458 = 0;
t_457 = Call(TL_9, V.Undef, NewObj(1).Put("smile", ((V)(0.9))).V);
B_458 = 480D;
{
double i_459 = 0;
i_459 = 0D;
while (true) {
if (!((i_459 < 4D))) break;
Invoke(Invoke(t_457, "to", ((V)(150D)), NewObj(6).Put("earL", ((V)(22D))).Put("earR", ((V)(22D))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(1.2))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)("o"))), "to", ((V)((B_458 - 150D))), NewObj(6).Put("earL", ((V)((-14D)))).Put("earR", ((V)((-14D)))).Put("sq", ((V)(0.08))).Put("lift", ((V)(0D))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).V, ((V)("io")));
i_459++;
}
}
Invoke(t_457, "to", ((V)(200D)), NewObj(3).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Arr(((V)(1D)), ((V)((-1D)))), "forEach", Fn((V _self1, int _argc461, V d_467, V _a464, V _a465, V _a466, V[] _rest462) => {
Call(eyes_29, V.Undef, t_457, d_467);
Invoke(Invoke(Invoke(Invoke(t_457, "to", ((V)(200D)), NewObj(4).Put("earL", ((V)((ToNum(d_467) * 8D)))).Put("earR", ((V)(((-ToNum(d_467)) * 8D)))).Put("htilt", ((V)(((-ToNum(d_467)) * 3D)))).Put("tilt", ((V)(((-ToNum(d_467)) * 2D)))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(6).Put("earL", ((V)(((-ToNum(d_467)) * 24D)))).Put("earR", ((V)((ToNum(d_467) * 24D)))).Put("htilt", ((V)((ToNum(d_467) * 7D)))).Put("tilt", ((V)((ToNum(d_467) * 4D)))).Put("armL", ((V)((LtN(d_467, 0D) ? 70D : 10D)))).Put("armR", ((V)((GtN(d_467, 0D) ? 70D : 10D)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(4).Put("earL", ((V)(((-ToNum(d_467)) * 18D)))).Put("earR", ((V)((ToNum(d_467) * 18D)))).Put("htilt", ((V)((ToNum(d_467) * 5D)))).Put("tilt", ((V)((ToNum(d_467) * 3D)))).V, ((V)("io"))), "wait", ((V)(200D)));
return default;
}, 1, "", true));
Invoke(t_457, "to", ((V)(300D)), NewObj(7).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("htilt", ((V)(0D))).Put("tilt", ((V)(0D))).Put("lx", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_457, "to", ((V)(300D)), NewObj(6).Put("armL", ((V)(140D))).Put("armR", ((V)(140D))).Put("fw", ((V)(1.5))).Put("earL", ((V)(8D))).Put("earR", ((V)(8D))).Put("hap", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(1400D)), ((V)(7D)), NewObj(2).Put("armL", ((V)(128D))).Put("armR", ((V)(152D))).V, NewObj(2).Put("armL", ((V)(152D))).Put("armR", ((V)(128D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(6).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("fw", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
Call(eyes_29, V.Undef, t_457, ((V)(1D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_457, "to", ((V)(260D)), NewObj(2).Put("tilt", ((V)((-4D)))).Put("sq", ((V)(0.06))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(5).Put("tilt", ((V)(28D))).Put("x", ((V)(3D))).Put("earL", ((V)((-20D)))).Put("earR", ((V)(20D))).Put("lift", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("salt")), ((V)("head")), ((V)(4D))), "wait", ((V)(250D))), "to", ((V)(380D)), NewObj(5).Put("tilt", ((V)((-5D)))).Put("x", ((V)(0D))).Put("earL", ((V)(8D))).Put("earR", ((V)((-8D)))).Put("lift", ((V)(0D))).V, ((V)("io"))), "to", ((V)(280D)), NewObj(5).Put("tilt", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("lx", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(t_457, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.05))).V, ((V)("io")));
Call(shake_16, V.Undef, t_457, NewObj(7).Put("P", ((V)(80D))).Put("env", Arr(((V)(0.5)), ((V)(0.9)), ((V)(1D)), ((V)(0.9)), ((V)(0.6)), ((V)(0.3)))).Put("head", ((V)(0.12))).Put("roll", ((V)(3D))).Put("ear", ((V)(14D))).Put("body", ((V)(1D))).Put("chest", ((V)(0.06))).V);
Invoke(t_457, "e", ((V)("emit")), ((V)("salt")), ((V)("head")), ((V)(5D)));
Invoke(t_457, "to", ((V)(200D)), NewObj(3).Put("earL", ((V)((-16D)))).Put("earR", ((V)((-16D)))).Put("sq", ((V)(0.12))).V, ((V)("io")));
Call(jump_15, V.Undef, t_457, NewObj(8).Put("h", ((V)(8D))).Put("ant", ((V)(140D))).Put("up", ((V)(220D))).Put("c", ((V)(0.16))).Put("arm", ((V)(80D))).Put("air", NewObj(2).Put("earL", ((V)(24D))).Put("earR", ((V)(24D))).V).Put("fall", NewObj(2).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))))).V);
Invoke(t_457, "to", ((V)(300D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_457, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Fry Fan Flip")), ((V)("His fries fan open and bunch shut on the beat, a hair flip one way then the other, a fry wave with jazz hands, he tips his box to pour and rights it, a salt-shaker shimmy and a fan-open ta-da.")))).Put("bunbun", Arr(Call(Fn((V _self1, int _argc468, V _a470, V _a471, V _a472, V _a473, V[] _rest469) => {
V t_474 = default;
double B_475 = 0;
t_474 = Call(TL_9, V.Undef, NewObj(1).Put("smile", ((V)(0.9))).V);
B_475 = 500D;
{
double i_476 = 0;
i_476 = 0D;
while (true) {
if (!((i_476 < 4D))) break;
double d_478 = 0;
d_478 = (NumTruthy((i_476 % 2D)) ? 1D : (-1D));
Invoke(Invoke(Invoke(t_474, "to", ((V)((B_475 / 2D))), NewObj(7).Put("split", ((V)(0.8))).Put("sq", ((V)((-0.08)))).Put("tilt", ((V)((d_478 * 4D)))).Put("armL", ((V)(55D))).Put("armR", ((V)(55D))).Put("open", ((V)(0.4))).Put("hap", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head")), ((V)(1D))), "to", ((V)((B_475 / 2D))), NewObj(6).Put("split", ((V)(0D))).Put("sq", ((V)(0.1))).Put("tilt", ((V)(0D))).Put("armL", ((V)(5D))).Put("armR", ((V)(5D))).Put("open", ((V)(0D))).V, ((V)("io")));
i_476++;
}
}
Invoke(t_474, "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
Call(eyes_29, V.Undef, t_474, ((V)((-1D))));
Invoke(Invoke(t_474, "to", ((V)(500D)), NewObj(3).Put("fan", ((V)((-1.2)))).Put("htilt", ((V)((-5D)))).Put("tilt", ((V)((-3D)))).V, ((V)("io"))), "wait", ((V)(150D)));
Call(eyes_29, V.Undef, t_474, ((V)(1D)));
Invoke(Invoke(Invoke(t_474, "to", ((V)(700D)), NewObj(3).Put("fan", ((V)(1.2))).Put("htilt", ((V)(5D))).Put("tilt", ((V)(3D))).V, ((V)("io"))), "wait", ((V)(150D))), "to", ((V)(450D)), NewObj(4).Put("fan", ((V)(0D))).Put("htilt", ((V)(0D))).Put("tilt", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("io")));
{
double i_479 = 0;
i_479 = 0D;
while (true) {
if (!((i_479 < 4D))) break;
Invoke(Invoke(t_474, "to", ((V)(110D)), NewObj(2).Put("shuf", ((V)((NumTruthy((i_479 % 2D)) ? (-0.9) : 0.9)))).Put("sq", ((V)(0.03))).V, ((V)("o"))), "to", ((V)(110D)), NewObj(2).Put("shuf", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
i_479++;
}
}
Invoke(t_474, "e", ((V)("emit")), ((V)("crumb")), ((V)("body")), ((V)(2D)));
Call(eyes_29, V.Undef, t_474, ((V)(1D)));
Call(jump_15, V.Undef, t_474, NewObj(8).Put("h", ((V)(14D))).Put("ant", ((V)(240D))).Put("up", ((V)(330D))).Put("c", ((V)(0.24))).Put("arm", ((V)(90D))).Put("spin", ((V)(360D))).Put("air", NewObj(1).Put("split", ((V)(1.2))).V).Put("fall", NewObj(1).Put("split", ((V)(0.3))).V).V);
Invoke(Invoke(Invoke(Invoke(t_474, "to", ((V)(80D)), NewObj(2).Put("split", ((V)(0D))).Put("sq", ((V)(0.25))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("body")), ((V)(4D))), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(3D))), "to", ((V)(160D)), NewObj(2).Put("sq", ((V)((-0.06)))).Put("lx", ((V)(0D))).V, ((V)("io")));
Call(jelly_19, V.Undef, t_474, ((V)(0.08)), ((V)(3D)), ((V)(260D)));
Invoke(Invoke(Invoke(t_474, "to", ((V)(220D)), NewObj(1).Put("fan", ((V)(0.35))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("fan", ((V)((-0.2)))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(1).Put("fan", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_474, "to", ((V)(160D)), NewObj(2).Put("winkR", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(300D))), "to", ((V)(200D)), NewObj(1).Put("winkR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_474, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Burger Accordion")), ((V)("Squeezes his stack like an accordion (the layers open and shut, notes fly), fans his layers like a hand of cards, riffles them, flips like a patty with his layers spinning apart, slams the stack back and winks.")))).Put("choco", Arr(Call(Fn((V _self1, int _argc481, V _a483, V _a484, V _a485, V _a486, V[] _rest482) => {
V t_487 = default;
double B_488 = 0;
V pops_489 = default;
V a_490 = default;
t_487 = Call(TL_9, V.Undef, NewObj(1).Put("smile", ((V)(0.85))).V);
B_488 = 450D;
pops_489 = Arr(NewObj(3).Put("tilt", ((V)(6D))).Put("armL", ((V)(90D))).Put("armR", ((V)(0D))).V, NewObj(3).Put("tilt", ((V)((-6D)))).Put("armL", ((V)(0D))).Put("armR", ((V)(90D))).V, NewObj(4).Put("tilt", ((V)(0D))).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).Put("lift", ((V)(1D))).V, NewObj(4).Put("tilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lift", ((V)(0D))).V);
{
double r_491 = 0;
r_491 = 0D;
while (true) {
if (!((r_491 < 2D))) break;
Invoke(pops_489, "forEach", Fn((V _self1, int _argc493, V p_499, V _a496, V _a497, V _a498, V[] _rest494) => {
return Invoke(Invoke(Invoke(t_487, "to", ((V)(70D)), Call(o_13, V.Undef, p_499, NewObj(2).Put("tw", ((V)(1.3))).Put("sq", ((V)((-0.03)))).V), ((V)("l"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(1D))), "to", ((V)((B_488 - 70D))), NewObj(2).Put("tw", ((V)(0.2))).Put("sq", ((V)(0D))).V, ((V)("o")));
}, 1, "", true));
r_491++;
}
}
Invoke(Invoke(t_487, "osc", ((V)(1800D)), ((V)(6D)), NewObj(2).Put("tw", ((V)(1.5))).Put("sq", ((V)((-0.02)))).V, NewObj(2).Put("tw", ((V)(0D))).Put("sq", ((V)(0.02))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(t_487, "to", ((V)(1400D)), NewObj(5).Put("melt", ((V)(1D))).Put("sq", ((V)(0.2))).Put("close", ((V)(0.6))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io")));
Call(swing_17, V.Undef, t_487, ((V)(1600D)), ((V)(3D)), NewObj(3).Put("bend", ((V)(8D))).Put("x", ((V)(1.5))).Put("htilt", ((V)((-4D)))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_487, "to", ((V)(90D)), NewObj(7).Put("melt", ((V)(0D))).Put("sq", ((V)((-0.1)))).Put("tw", ((V)(1.5))).Put("close", ((V)(0D))).Put("wide", ((V)(0.6))).Put("armL", ((V)(80D))).Put("armR", ((V)(80D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(180D)), NewObj(2).Put("sq", ((V)(0.04))).Put("tw", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(5).Put("sq", ((V)(0D))).Put("tw", ((V)(0D))).Put("wide", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(eyes_29, V.Undef, t_487, ((V)(1D)));
a_490 = Get(t_487, "t");
Invoke(Invoke(t_487, "to", ((V)(1600D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(t_487, "at", a_490), "to", ((V)(700D)), NewObj(1).Put("wrap", ((V)(0.7))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_487, "at", Add(a_490, ((V)(1601D)))), "to", ((V)(250D)), NewObj(3).Put("blush", ((V)(0.9))).Put("wide", ((V)(0.5))).Put("lx", ((V)(0D))).V, ((V)("o"))), "to", ((V)(500D)), NewObj(3).Put("wrap", ((V)(0D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_487, "to", ((V)(70D)), NewObj(3).Put("tw", ((V)(1.2))).Put("tilt", ((V)(4D))).Put("armR", ((V)(90D))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(2).Put("tw", ((V)(0D))).Put("winkR", ((V)(1D))).V, ((V)("o"))), "wait", ((V)(300D))), "to", ((V)(250D)), NewObj(4).Put("tilt", ((V)(0D))).Put("armR", ((V)(0D))).Put("winkR", ((V)(0D))).Put("blush", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_487, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Snap and Melt")), ((V)("Stiff robot snaps with his segments flashing (a bar can't bend), a segment light show, melts into a gooey sway, SNAPS back into a bar, a foil twirl where his wrapper slips and he tugs it back up blushing, then a snap pose and a wink.")))).Put("scoop", Arr(Call(Fn((V _self1, int _argc500, V _a502, V _a503, V _a504, V _a505, V[] _rest501) => {
V t_506 = default;
double B_507 = 0;
V a_508 = default;
t_506 = Call(TL_9, V.Undef, NewObj(1).Put("smile", ((V)(0.9))).V);
B_507 = 500D;
{
double i_509 = 0;
i_509 = 0D;
while (true) {
if (!((i_509 < 4D))) break;
double d_511 = 0;
d_511 = (NumTruthy((i_509 % 2D)) ? 1D : (-1D));
Call(eyes_29, V.Undef, t_506, ((V)(d_511)));
Invoke(t_506, "to", ((V)((B_507 - 110D))), NewObj(5).Put("tilt", ((V)((d_511 * 13D)))).Put("armL", ((V)(((d_511 > 0D) ? 70D : 10D)))).Put("armR", ((V)(((d_511 < 0D) ? 70D : 10D)))).Put("chb", ((V)(1D))).Put("htilt", ((V)(((-d_511) * 4D)))).V, ((V)("io")));
i_509++;
}
}
Invoke(t_506, "to", ((V)(350D)), NewObj(6).Put("tilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("chb", ((V)(0D))).Put("htilt", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("io")));
Invoke(t_506, "to", ((V)(260D)), NewObj(2).Put("twist", ((V)((-0.4)))).Put("sq", ((V)(0.08))).V, ((V)("io")));
a_508 = Get(t_506, "t");
Invoke(Invoke(t_506, "to", ((V)(1800D)), NewObj(5).Put("spin", ((V)(1080D))).Put("twist", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("o"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(t_506, "at", a_508), "osc", ((V)(1800D)), ((V)(6D)), NewObj(2).Put("tilt", ((V)(5D))).Put("chb", ((V)(1D))).V, NewObj(2).Put("tilt", ((V)((-5D)))).Put("chb", ((V)(0D))).V, ((V)("io")));
Invoke(t_506, "at", Add(a_508, ((V)(1801D))));
Invoke(Arr(((V)(8D)), ((V)((-6D))), ((V)(4D)), ((V)((-2D))), ((V)(0D))), "forEach", Fn((V _self1, int _argc512, V v_518, V _a515, V _a516, V _a517, V[] _rest513) => {
return Invoke(t_506, "to", ((V)(150D)), NewObj(1).Put("tilt", v_518).V, ((V)("io")));
}, 1, "", true));
Invoke(t_506, "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
a_508 = Get(t_506, "t");
Invoke(Invoke(Invoke(Invoke(t_506, "to", ((V)(1400D)), NewObj(6).Put("sq", ((V)((-0.16)))).Put("lift", ((V)(3D))).Put("spin", ((V)(360D))).Put("armL", ((V)(140D))).Put("armR", ((V)(140D))).Put("hap", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(4).Put("sq", ((V)(0.06))).Put("lift", ((V)(0D))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("i"))), "to", ((V)(250D)), NewObj(4).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
{
double i_519 = 0;
i_519 = 0D;
while (true) {
if (!((i_519 < 3D))) break;
Invoke(Invoke(t_506, "to", ((V)(140D)), NewObj(4).Put("chy", ((V)(1.1))).Put("ly", ((V)((-0.9)))).Put("pitch", ((V)(0.12))).Put("sq", ((V)(0.04))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(4).Put("chy", ((V)(0D))).Put("ly", ((V)((-0.2)))).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i")));
i_519++;
}
}
Invoke(t_506, "to", ((V)(150D)), NewObj(2).Put("ly", ((V)(0D))).Put("close", ((V)(0.4))).V, ((V)("io")));
Call(shake_16, V.Undef, t_506, NewObj(5).Put("P", ((V)(70D))).Put("env", Arr(((V)(0.4)), ((V)(0.8)), ((V)(1D)), ((V)(0.7)), ((V)(0.4)), ((V)(0.2)))).Put("head", ((V)(0.1))).Put("roll", ((V)(2D))).Put("body", ((V)(0.5))).V);
Invoke(Invoke(Invoke(Invoke(t_506, "to", ((V)(160D)), NewObj(2).Put("close", ((V)(0D))).Put("winkR", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(300D))), "to", ((V)(200D)), NewObj(1).Put("winkR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_506, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Spinning Top Swirl")), ((V)("Rocks on the point of his cone with his arms out for balance, spins like a spinning top and wobbles down, swirls up tall like soft-serve, juggles his cherry, a cold shiver and a wink.")))).Put("boba", Arr(Call(Fn((V _self1, int _argc521, V _a523, V _a524, V _a525, V _a526, V[] _rest522) => {
V t_527 = default;
double B_528 = 0;
V a_529 = default;
t_527 = Call(TL_9, V.Undef, NewObj(1).Put("smile", ((V)(0.9))).V);
B_528 = 500D;
Invoke(t_527, "to", ((V)(200D)), NewObj(4).Put("sq", ((V)(0.1))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("hap", ((V)(1D))).V, ((V)("io")));
Invoke(t_527, "osc", ((V)(1600D)), ((V)(8D)), NewObj(4).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.08)))).Put("pop", ((V)(2D))).Put("swirl", ((V)(1.5))).V, NewObj(4).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).Put("pop", ((V)(0.5))).Put("swirl", ((V)((-1.5)))).V, ((V)("io")));
Invoke(t_527, "to", ((V)(250D)), NewObj(7).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).Put("pop", ((V)(0D))).Put("swirl", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
Invoke(t_527, "to", ((V)(300D)), NewObj(2).Put("sup", ((V)(1.4))).Put("ly", ((V)((-0.6)))).V, ((V)("o")));
Call(eyes_29, V.Undef, t_527, ((V)((-1D))));
Invoke(Invoke(t_527, "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(1D))).Put("hyaw", ((V)((-0.15)))).V, ((V)("io"))), "wait", ((V)(300D)));
Call(eyes_29, V.Undef, t_527, ((V)(1D)));
Invoke(Invoke(Invoke(t_527, "to", ((V)(500D)), NewObj(2).Put("stw", ((V)((-1D)))).Put("hyaw", ((V)(0.15))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(400D)), NewObj(5).Put("sup", ((V)(0D))).Put("stw", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_527, "to", ((V)(300D)), NewObj(3).Put("slurp", ((V)(1D))).Put("mw", ((V)(0.5))).Put("sq", ((V)(0.06))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(100D)), NewObj(6).Put("slurp", ((V)(0D))).Put("sup", ((V)(0.9))).Put("pop", ((V)(1.5))).Put("sq", ((V)((-0.08)))).Put("mw", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(4D))), "to", ((V)(350D)), NewObj(4).Put("sup", ((V)(0D))).Put("pop", ((V)(0D))).Put("sq", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
Call(eyes_29, V.Undef, t_527, ((V)(1D)));
a_529 = Get(t_527, "t");
Invoke(Invoke(Invoke(t_527, "to", ((V)(1500D)), NewObj(2).Put("spin", ((V)(360D))).Put("swirl", ((V)(3D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "to", ((V)(500D)), NewObj(2).Put("swirl", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("io")));
{
double i_530 = 0;
i_530 = 0D;
while (true) {
if (!((i_530 < 4D))) break;
double d_532 = 0;
d_532 = (NumTruthy((i_530 % 2D)) ? 1D : (-1D));
Invoke(Invoke(t_527, "to", ((V)(120D)), NewObj(5).Put("pop", ((V)(2D))).Put("sq", ((V)(0.08))).Put("tilt", ((V)((d_532 * 3D)))).Put("armL", ((V)(((d_532 < 0D) ? 60D : 0D)))).Put("armR", ((V)(((d_532 > 0D) ? 60D : 0D)))).V, ((V)("o"))), "to", ((V)((B_528 - 120D))), NewObj(3).Put("pop", ((V)(0.2))).Put("sq", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io")));
i_530++;
}
}
Invoke(t_527, "to", ((V)(200D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("pop", ((V)(0D))).V, ((V)("io")));
Call(jump_15, V.Undef, t_527, NewObj(8).Put("h", ((V)(7D))).Put("ant", ((V)(150D))).Put("up", ((V)(200D))).Put("c", ((V)(0.14))).Put("arm", ((V)(70D))).Put("air", NewObj(2).Put("pop", ((V)(1.6))).Put("stw", ((V)(1D))).V).Put("fall", NewObj(2).Put("pop", ((V)(0D))).Put("stw", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))))).V);
return Invoke(Invoke(t_527, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Bubble Tea Shaker")), ((V)("Shakes himself like a cocktail shaker with his pearls flying, his straw rises like a periscope and looks around, slurps a pearl up the straw and pops it out, a whirlpool twirl with the pearls swirling, pearl drums and a hop.")))).Put("chefbun", Arr(Call(Fn((V _self1, int _argc533, V _a535, V _a536, V _a537, V _a538, V[] _rest534) => {
V t_539 = default;
double B_540 = 0;
V a_541 = default;
t_539 = Call(TL_9, V.Undef, NewObj(1).Put("smile", ((V)(0.9))).V);
B_540 = 500D;
{
double i_542 = 0;
i_542 = 0D;
while (true) {
if (!((i_542 < 4D))) break;
Invoke(Invoke(Invoke(t_539, "to", ((V)(180D)), NewObj(4).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("sq", ((V)((-0.04)))).Put("hap", ((V)(1D))).V, ((V)("io"))), "to", ((V)((B_540 - 180D))), NewObj(4).Put("armL", ((V)(15D))).Put("armR", ((V)(15D))).Put("sq", ((V)(0.24))).Put("close", ((V)(0.5))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(1D)));
i_542++;
}
}
Invoke(t_539, "to", ((V)(250D)), NewObj(3).Put("sq", ((V)(0.1))).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
Call(eyes_29, V.Undef, t_539, ((V)(1D)));
Invoke(t_539, "to", ((V)(260D)), NewObj(5).Put("sq", ((V)(0.26))).Put("pitch", ((V)((-0.1)))).Put("armL", ((V)((-8D)))).Put("armR", ((V)((-8D)))).Put("lx", ((V)(0D))).V, ((V)("io")));
a_541 = Get(t_539, "t");
Invoke(Invoke(t_539, "to", ((V)(380D)), NewObj(1).Put("lift", ((V)(10D))).V, ((V)("o"))), "to", ((V)(380D)), NewObj(1).Put("lift", ((V)(0D))).V, ((V)("i")));
Invoke(Invoke(Invoke(Invoke(t_539, "at", a_541), "to", ((V)(70D)), NewObj(1).Put("sq", ((V)((-0.14)))).V, ((V)("o"))), "to", ((V)(230D)), NewObj(4).Put("sq", ((V)(0.32))).Put("armL", ((V)(165D))).Put("armR", ((V)(165D))).Put("wide", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(460D)), NewObj(3).Put("sq", ((V)(0.26))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).V, ((V)("io")));
Invoke(Invoke(t_539, "at", a_541), "to", ((V)(760D)), NewObj(1).Put("spin", ((V)(720D))).V, ((V)("io")));
Invoke(Invoke(t_539, "at", Add(a_541, ((V)(760D)))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(t_539, "to", ((V)(80D)), NewObj(3).Put("sq", ((V)(0.36))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(4D))), "to", ((V)(150D)), NewObj(5).Put("sq", ((V)((-0.12)))).Put("pitch", ((V)(0D))).Put("wide", ((V)(0D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("o")));
Call(jelly_19, V.Undef, t_539, ((V)(0.09)), ((V)(3D)), ((V)(260D)));
Invoke(t_539, "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
{
double i_544 = 0;
i_544 = 0D;
while (true) {
if (!((i_544 < 4D))) break;
double d_546 = 0;
d_546 = (NumTruthy((i_544 % 2D)) ? 1D : (-1D));
Invoke(Invoke(t_539, "to", ((V)(140D)), NewObj(5).Put("earL", ((V)(((-d_546) * 26D)))).Put("earR", ((V)((d_546 * 26D)))).Put("htilt", ((V)((d_546 * 4D)))).Put("lx", ((V)((d_546 * 0.7)))).Put("ly", ((V)((-0.6)))).V, ((V)("o"))), "to", ((V)((B_540 - 140D))), NewObj(2).Put("earL", ((V)(((-d_546) * 18D)))).Put("earR", ((V)((d_546 * 18D)))).V, ((V)("io")));
i_544++;
}
}
Invoke(t_539, "to", ((V)(250D)), NewObj(5).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("htilt", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
Invoke(t_539, "to", ((V)(250D)), NewObj(2).Put("armR", ((V)(70D))).Put("armL", ((V)(40D))).V, ((V)("io")));
a_541 = Get(t_539, "t");
Invoke(t_539, "osc", ((V)(1400D)), ((V)(7D)), NewObj(2).Put("armR", ((V)(100D))).Put("twist", ((V)(0.12))).V, NewObj(2).Put("armR", ((V)(45D))).Put("twist", ((V)((-0.12)))).V, ((V)("io")));
Invoke(t_539, "at", a_541);
Call(steps_18, V.Undef, t_539, ((V)(1400D)), ((V)(4D)), ((V)(1.8)));
Invoke(t_539, "to", ((V)(250D)), NewObj(3).Put("armR", ((V)(0D))).Put("armL", ((V)(0D))).Put("twist", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_539, "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-15D)))), NewObj(2).Put("armR", ((V)(20D))).Put("close", ((V)(0.9))).V), ((V)("io"))), "to", ((V)(140D)), NewObj(3).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).Put("puff", ((V)((-0.2)))).V, ((V)("o"))), "to", ((V)(220D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)((-4D))), ((V)((-10D)))), NewObj(4).Put("armR", ((V)(80D))).Put("open", ((V)(0.2))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).V), ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("pawR")), ((V)(3D))), "wait", ((V)(250D))), "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D))), NewObj(3).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).Put("open", ((V)(0D))).V), ((V)("io")));
Invoke(Invoke(Invoke(t_539, "to", ((V)(400D)), NewObj(5).Put("pitch", ((V)((-0.25)))).Put("sq", ((V)(0.06))).Put("earL", ((V)(20D))).Put("earR", ((V)((-20D)))).Put("armL", ((V)(40D))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(400D)), NewObj(5).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("armL", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_539, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Pizza Dough Twirl")), ((V)("Kneads himself, gets tossed and spins flat like pizza dough in the air, pops back into a bun, his chef hat tips side to side on the beat, whisks and stirs, a chef's kiss and a hat-tip bow.")))).V;
Invoke(KEYS_22, "forEach", Fn((V _self1, int _argc547, V k_553, V _a550, V _a551, V _a552, V[] _rest548) => {
Set(GetK(MOVES_28, k_553), "dance", GetK(DANCES_30, k_553));
return default;
}, 1, "", true));
Invoke(KEYS_22, "forEach", Fn((V _self1, int _argc554, V k_560, V _a557, V _a558, V _a559, V[] _rest555) => {
Set(GetK(MOVES_28, k_560), "look", Call(natF_23, V.Undef, ((V)(1D))));
return default;
}, 1, "", true));
Set(R_8, "SNACKLIB", NewObj(2).Put("natF", natF_23).Put("KEYS", KEYS_22).V);
Call(install_21, V.Undef, MOVES_28, CARDS_24);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
