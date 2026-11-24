// house-idle.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_house_idle_js
    {

        public static void Run()
        {
Call(Named(boot_22 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V R_8 = default;
V H_9 = default;
V TL_10 = default;
V hand_11 = default;
V both_12 = default;
V SIDE_13 = default;
V BEAT_14 = default;
V o_15 = default;
V REST_16 = default;
V sp_17 = default;
V SB_18 = default;
V FID_19 = default;
V SHARED_20 = default;
V W_21 = default;
if (_self1.IsNullish) _self1 = GlobalV;
R_8 = Get(G("window"), "RiveRig");
if (((!(Truthy(R_8)) || !(Truthy(Get(R_8, "HOUSE")))) || !(Truthy(Get(R_8, "FIDK"))))) {
Call(G("setTimeout"), V.Undef, boot_22.v, ((V)(30D)));
return default;
}
if (Truthy(Get(R_8, "idleV"))) {
return default;
}
Set(R_8, "idleV", ((V)(1D)));
H_9 = Get(R_8, "HOUSE");
{ V _t23 = H_9;
if (_t23.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t23));
{ V _t24 = Get(_t23, "TL");
TL_10 = _t24; }
{ V _t25 = Get(_t23, "hand");
hand_11 = _t25; }
{ V _t26 = Get(_t23, "both");
both_12 = _t26; }
{ V _t27 = Get(_t23, "SIDE");
SIDE_13 = _t27; }
{ V _t28 = Get(_t23, "BEAT");
BEAT_14 = _t28; }
{ V _t29 = Get(_t23, "o");
o_15 = _t29; } }
REST_16 = Get(R_8, "REST");
sp_17 = Fn((V _self1, int _argc30, V t_36, V v_37, V d_38, V hold_39, V[] _rest31) => {
V b_40 = default;
b_40 = NewObj(0).V;
Invoke(Object_keys(v_37), "forEach", Fn((V _self1, int _argc41, V k_47, V _a44, V _a45, V _a46, V[] _rest42) => {
return SetK(b_40, k_47, (!GetK(REST_16, k_47).IsNullish ? GetK(REST_16, k_47) : ((V)(0D))));
}, 1, "", true));
Invoke(Invoke(Invoke(t_36, "to", ((V)((ToNum((d_38 is var _t50 && Truthy(_t50) ? _t50 : ((V)(700D)))) * 0.4))), v_37, ((V)("o"))), "wait", (hold_39 is var _t49 && Truthy(_t49) ? _t49 : ((V)(300D)))), "to", ((V)((ToNum((d_38 is var _t48 && Truthy(_t48) ? _t48 : ((V)(700D)))) * 0.6))), b_40, ((V)("io")));
return t_36;
return default;
}, 4, "", true);
SB_18 = NewObj(24).Put("scratch", Fn((V _self51, int _argc52, V t_58, V s_59, V _a56, V _a57, V[] _rest53) => {
V K_60 = default;
if (_self51.IsNullish) _self51 = GlobalV;
s_59 = (s_59 is var _t61 && Truthy(_t61) ? _t61 : ((V)(1D)));
K_60 = Call(SIDE_13, V.Undef, s_59);
Invoke(Invoke(Invoke(Invoke(t_58, "to", ((V)(380D)), Call(o_15, V.Undef, Call(hand_11, V.Undef, s_59, ((V)((-6D))), ((V)((-26D)))), NewObj(6).PutK(Get(K_60, "arm"), ((V)(35D))).Put("htilt", ((V)((ToNum(s_59) * 10D)))).Put("lean", ((V)((ToNum(s_59) * 1.2)))).PutK(Get(K_60, "wink"), ((V)(1D))).Put("tongue", ((V)(0.3))).PutK(Get(K_60, "foot"), ((V)(1.2))).V), ((V)("io"))), "osc", ((V)(1300D)), ((V)(7D)), NewObj(2).PutK(Get(K_60, "hy"), ((V)((-30D)))).PutK(Get(K_60, "ear"), ((V)(8D))).V, NewObj(2).PutK(Get(K_60, "hy"), ((V)((-24D)))).PutK(Get(K_60, "ear"), ((V)((-2D)))).V, ((V)("l"))), "to", ((V)(280D)), Call(o_15, V.Undef, Call(hand_11, V.Undef, s_59, ((V)(0D)), ((V)(0D))), NewObj(8).PutK(Get(K_60, "arm"), ((V)(0D))).PutK(Get(K_60, "wink"), ((V)(0D))).Put("tongue", ((V)(0D))).PutK(Get(K_60, "foot"), ((V)(0D))).Put("htilt", ((V)(0D))).Put("lean", ((V)(0D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V), ((V)("io"))), "osc", ((V)(500D)), ((V)(3D)), NewObj(1).Put("htilt", ((V)(4D))).V, NewObj(1).Put("htilt", ((V)((-4D)))).V, ((V)("s")));
return t_58;
return default;
}, 2, "scratch", false)).Put("groom", Fn((V _self62, int _argc63, V t_69, V _a66, V _a67, V _a68, V[] _rest64) => {
if (_self62.IsNullish) _self62 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_69, "to", ((V)(380D)), Call(o_15, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(12D)), ((V)((-14D)))), NewObj(3).Put("armR", ((V)(32D))).Put("close", ((V)(0.6))).Put("pitch", ((V)((-0.08)))).V), ((V)("io"))), "osc", ((V)(1100D)), ((V)(5D)), NewObj(2).Put("tongue", ((V)(0.7))).Put("hRy", ((V)((-16D)))).V, NewObj(2).Put("tongue", ((V)(0.15))).Put("hRy", ((V)((-13D)))).V, ((V)("l"))), "to", ((V)(300D)), Call(o_15, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-24D)))), NewObj(3).Put("tongue", ((V)(0D))).Put("close", ((V)(0.8))).Put("htilt", ((V)(7D))).V), ((V)("io"))), "osc", ((V)(1000D)), ((V)(3D)), NewObj(2).Put("hRx", ((V)(2D))).Put("hRy", ((V)((-26D)))).V, NewObj(2).Put("hRx", ((V)((-6D)))).Put("hRy", ((V)((-20D)))).V, ((V)("s"))), "to", ((V)(260D)), NewObj(2).Put("hap", ((V)(0.5))).Put("smile", ((V)(0.8))).V);
return t_69;
return default;
}, 1, "groom", false)).Put("stretch", Fn((V _self70, int _argc71, V t_77, V _a74, V _a75, V _a76, V[] _rest72) => {
if (_self70.IsNullish) _self70 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_77, "to", ((V)(620D)), NewObj(9).Put("armL", ((V)(160D))).Put("armR", ((V)(160D))).Put("hLy", ((V)((-4D)))).Put("hRy", ((V)((-4D)))).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(1.6))).Put("close", ((V)(0.85))).Put("pitch", ((V)(0.3))).Put("open", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(350D))), "osc", ((V)(560D)), ((V)(2D)), NewObj(1).Put("tilt", ((V)(1.6))).V, NewObj(1).Put("tilt", ((V)((-1.6)))).V, ((V)("s"))), "to", ((V)(420D)), NewObj(10).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("sq", ((V)(0.06))).Put("lift", ((V)(0D))).Put("pitch", ((V)(0D))).Put("open", ((V)(0D))).Put("close", ((V)(0.3))).Put("tilt", ((V)(0D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(4).Put("sq", ((V)(0D))).Put("close", ((V)(0D))).Put("hap", ((V)(0.5))).Put("smile", ((V)(0.8))).V, ((V)("o"))), "e", ((V)("blink2")));
return t_77;
return default;
}, 1, "stretch", false)).Put("hops", Fn((V _self78, int _argc79, V t_85, V n_86, V _a83, V _a84, V[] _rest80) => {
if (_self78.IsNullish) _self78 = GlobalV;
n_86 = (n_86 is var _t87 && Truthy(_t87) ? _t87 : ((V)(3D)));
Invoke(t_85, "to", ((V)(160D)), NewObj(3).Put("hap", ((V)(0.9))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).V);
{
double i_88 = 0;
i_88 = 0D;
while (true) {
if (!(Lt(((V)(i_88)), n_86))) break;
Invoke(Invoke(Invoke(t_85, "to", ((V)(110D)), NewObj(2).Put("sq", ((V)(0.1))).Put("lift", ((V)(0D))).V, ((V)("i"))), "to", ((V)(190D)), NewObj(6).Put("sq", ((V)((-0.07)))).Put("lift", ((V)(5D))).Put("footL", ((V)(1.5))).Put("footR", ((V)(1.5))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(6).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("i")));
i_88++;
}
}
Invoke(t_85, "to", ((V)(140D)), NewObj(1).Put("sq", ((V)(0.06))).V, ((V)("o")));
return t_85;
return default;
}, 2, "hops", false)).Put("twirl", Fn((V _self90, int _argc91, V t_97, V d_98, V _a95, V _a96, V[] _rest92) => {
if (_self90.IsNullish) _self90 = GlobalV;
d_98 = (d_98 is var _t99 && Truthy(_t99) ? _t99 : ((V)(1D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_97, "to", ((V)(160D)), NewObj(6).Put("sq", ((V)(0.07))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("io"))), "to", ((V)(760D)), NewObj(3).Put("spin", ((V)((ToNum(d_98) * 360D)))).Put("lift", ((V)(3D))).Put("sq", ((V)((-0.05)))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "to", ((V)(170D)), NewObj(4).Put("lift", ((V)(0D))).Put("sq", ((V)(0.07))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("o"))), "e", ((V)("blink")));
return t_97;
return default;
}, 2, "twirl", false)).Put("sniff", Fn((V _self100, int _argc101, V t_107, V _a104, V _a105, V _a106, V[] _rest102) => {
if (_self100.IsNullish) _self100 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_107, "to", ((V)(420D)), NewObj(4).Put("pitch", ((V)((-0.28)))).Put("ly", ((V)(0.9))).Put("lean", ((V)(0.8))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "osc", ((V)(1000D)), ((V)(7D)), NewObj(3).Put("mw", ((V)(0.55))).Put("sq", ((V)(0.05))).Put("puff", ((V)(0.2))).V, NewObj(3).Put("mw", ((V)(1D))).Put("sq", ((V)(0.03))).Put("puff", ((V)(0D))).V, ((V)("l"))), "to", ((V)(300D)), NewObj(2).Put("lx", ((V)(0.7))).Put("turn", ((V)(0.2))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(5D)), NewObj(1).Put("mw", ((V)(0.55))).V, NewObj(1).Put("mw", ((V)(1D))).V, ((V)("l"))), "to", ((V)(220D)), NewObj(7).Put("ly", ((V)((-0.2)))).Put("pitch", ((V)(0.08))).Put("lx", ((V)(0D))).Put("turn", ((V)(0D))).Put("wide", ((V)(0.5))).Put("lean", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(200D))), "to", ((V)(240D)), NewObj(3).Put("wide", ((V)(0D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(0.8))).V);
return t_107;
return default;
}, 1, "sniff", false)).Put("shake", Fn((V _self108, int _argc109, V t_115, V _a112, V _a113, V _a114, V[] _rest110) => {
if (_self108.IsNullish) _self108 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_115, "to", ((V)(360D)), NewObj(4).Put("sq", ((V)(0.1))).Put("close", ((V)(0.6))).Put("earL", ((V)(6D))).Put("earR", ((V)(6D))).V, ((V)("io"))), "osc", ((V)(1200D)), ((V)(8D)), NewObj(3).Put("spin", ((V)(24D))).Put("htilt", ((V)((-8D)))).Put("sqz", ((V)(1D))).V, NewObj(2).Put("spin", ((V)((-24D)))).Put("htilt", ((V)(8D))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(8).Put("spin", ((V)(0D))).Put("htilt", ((V)(0D))).Put("sqz", ((V)(0D))).Put("close", ((V)(0D))).Put("sq", ((V)((-0.05)))).Put("wide", ((V)(0.6))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(4).Put("wide", ((V)(0D))).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
return t_115;
return default;
}, 1, "shake", false)).Put("tap", Fn((V _self116, int _argc117, V t_123, V _a120, V _a121, V _a122, V[] _rest118) => {
if (_self116.IsNullish) _self116 = GlobalV;
Invoke(t_123, "to", ((V)(320D)), NewObj(4).Put("lx", ((V)(0.9))).Put("turn", ((V)(0.25))).Put("htilt", ((V)(5D))).Put("mw", ((V)(0.6))).V, ((V)("io")));
{
double i_124 = 0;
i_124 = 0D;
while (true) {
if (!((i_124 < 4D))) break;
Invoke(Invoke(Invoke(t_123, "to", ((V)(130D)), NewObj(1).Put("footR", ((V)(2.4))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(2).Put("footR", ((V)(0D))).Put("sq", ((V)(0.02))).V, ((V)("i"))), "to", ((V)(60D)), NewObj(1).Put("sq", ((V)(0D))).V);
i_124++;
}
}
Invoke(Invoke(t_123, "to", ((V)(300D)), NewObj(3).Put("lx", ((V)((-0.6)))).Put("turn", ((V)((-0.15)))).Put("htilt", ((V)((-3D)))).V, ((V)("io"))), "wait", ((V)(300D)));
return t_123;
return default;
}, 1, "tap", false)).Put("ponder", Fn((V _self126, int _argc127, V t_133, V _a130, V _a131, V _a132, V[] _rest128) => {
if (_self126.IsNullish) _self126 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_133, "to", ((V)(420D)), Call(o_15, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(10D)), ((V)((-12D)))), NewObj(6).Put("armR", ((V)(30D))).Put("ly", ((V)((-1D)))).Put("lx", ((V)(0.5))).Put("htilt", ((V)(7D))).Put("mw", ((V)(0.5))).Put("pitch", ((V)(0.12))).V), ((V)("io"))), "wait", ((V)(1100D))), "to", ((V)(200D)), NewObj(3).Put("wide", ((V)(0.7))).Put("open", ((V)(0.3))).Put("ly", ((V)((-0.4)))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(3).Put("armR", ((V)(90D))).Put("hRy", ((V)((-6D)))).Put("hRx", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(400D))), "to", ((V)(260D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
return t_133;
return default;
}, 1, "ponder", false)).Put("sneeze", Fn((V _self134, int _argc135, V t_141, V _a138, V _a139, V _a140, V[] _rest136) => {
if (_self134.IsNullish) _self134 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_141, "to", ((V)(500D)), NewObj(4).Put("pitch", ((V)(0.35))).Put("open", ((V)(0.45))).Put("close", ((V)(0.7))).Put("sq", ((V)((-0.06)))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("pitch", ((V)(0.45))).Put("open", ((V)(0.6))).V), "to", ((V)(90D)), NewObj(6).Put("pitch", ((V)((-0.4)))).Put("open", ((V)(0.9))).Put("sqz", ((V)(1D))).Put("close", ((V)(0D))).Put("sq", ((V)(0.2))).Put("lean", ((V)(0.4))).V, ((V)("o"))), "fx", ((V)("sneeze")), ((V)("nose"))), "to", ((V)(260D)), NewObj(4).Put("pitch", ((V)(0D))).Put("open", ((V)(0.1))).Put("sq", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(3).Put("sqz", ((V)(0D))).Put("open", ((V)(0D))).Put("blush", ((V)(0.7))).V), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(3).Put("blush", ((V)(0D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(0.8))).V);
return t_141;
return default;
}, 1, "sneeze", false)).Put("rub", Fn((V _self142, int _argc143, V t_149, V _a146, V _a147, V _a148, V[] _rest144) => {
if (_self142.IsNullish) _self142 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_149, "to", ((V)(380D)), Call(o_15, V.Undef, Call(both_12, V.Undef, ((V)(6D)), ((V)((-18D)))), NewObj(4).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).Put("close", ((V)(1D))).Put("mw", ((V)(0.6))).V), ((V)("io"))), "osc", ((V)(1100D)), ((V)(4D)), NewObj(2).Put("hLy", ((V)((-21D)))).Put("hRy", ((V)((-16D)))).V, NewObj(2).Put("hLy", ((V)((-16D)))).Put("hRy", ((V)((-21D)))).V, ((V)("s"))), "to", ((V)(300D)), Call(o_15, V.Undef, Call(both_12, V.Undef, ((V)(0D)), ((V)(0D))), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("close", ((V)(0D))).Put("wide", ((V)(0.5))).V, ((V)("o"))), "e", ((V)("blink2"))), "to", ((V)(260D)), NewObj(1).Put("wide", ((V)(0D))).V);
return t_149;
return default;
}, 1, "rub", false)).Put("shimmy", Fn((V _self150, int _argc151, V t_157, V _a154, V _a155, V _a156, V[] _rest152) => {
if (_self150.IsNullish) _self150 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_157, "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V), "fx", ((V)("note")), ((V)("head"))), "osc", ((V)(1600D)), ((V)(4D)), NewObj(5).Put("x", ((V)(1.4))).Put("tilt", ((V)(4D))).Put("armL", ((V)(60D))).Put("armR", ((V)(10D))).Put("htilt", ((V)(4D))).V, NewObj(5).Put("x", ((V)((-1.4)))).Put("tilt", ((V)((-4D)))).Put("armL", ((V)(10D))).Put("armR", ((V)(60D))).Put("htilt", ((V)((-4D)))).V, ((V)("s"))), "fx", ((V)("note")), ((V)("head")));
return t_157;
return default;
}, 1, "shimmy", false)).Put("clap", Fn((V _self158, int _argc159, V t_165, V _a162, V _a163, V _a164, V[] _rest160) => {
if (_self158.IsNullish) _self158 = GlobalV;
Invoke(Invoke(Invoke(t_165, "to", ((V)(300D)), Call(o_15, V.Undef, Call(both_12, V.Undef, ((V)(4D)), ((V)((-8D)))), NewObj(5).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).V), ((V)("io"))), "osc", ((V)(1100D)), ((V)(5D)), Call(o_15, V.Undef, Call(both_12, V.Undef, ((V)(13D)), ((V)((-9D)))), NewObj(1).Put("sq", ((V)(0.02))).V), Call(o_15, V.Undef, Call(both_12, V.Undef, ((V)(4D)), ((V)((-8D)))), NewObj(1).Put("sq", ((V)(0D))).V), ((V)("o"))), "fx", ((V)("spark")), ((V)("pawR")), ((V)(3D)));
return t_165;
return default;
}, 1, "clap", false)).Put("rock", Fn((V _self166, int _argc167, V t_173, V _a170, V _a171, V _a172, V[] _rest168) => {
if (_self166.IsNullish) _self166 = GlobalV;
Invoke(Invoke(t_173, "osc", ((V)(1800D)), ((V)(3D)), NewObj(4).Put("pitch", ((V)(0.12))).Put("lift", ((V)(0.8))).Put("footL", ((V)(0.6))).Put("footR", ((V)(0.6))).V, NewObj(4).Put("pitch", ((V)((-0.08)))).Put("lift", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("s"))), "to", ((V)(220D)), NewObj(2).Put("smile", ((V)(0.8))).Put("close", ((V)(0.4))).V);
return t_173;
return default;
}, 1, "rock", false)).Put("behind", Fn((V _self174, int _argc175, V t_181, V s_182, V _a179, V _a180, V[] _rest176) => {
if (_self174.IsNullish) _self174 = GlobalV;
s_182 = (s_182 is var _t183 && Truthy(_t183) ? _t183 : ((V)(1D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_181, "to", ((V)(500D)), NewObj(4).Put("spin", ((V)((ToNum(s_182) * 120D)))).Put("turn", ((V)((ToNum(s_182) * 0.3)))).Put("lean", ((V)(((-ToNum(s_182)) * 0.8)))).PutK(Get(Call(SIDE_13, V.Undef, s_182), "foot"), ((V)(1.6))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).PutK(Get(Call(SIDE_13, V.Undef, s_182), "foot"), ((V)(0D))).V), "wait", ((V)(700D))), "to", ((V)(160D)), NewObj(1).Put("wide", ((V)(0.6))).V), "to", ((V)(520D)), NewObj(3).Put("spin", ((V)(0D))).Put("turn", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(3).Put("wide", ((V)(0D))).Put("hap", ((V)(0.5))).Put("smile", ((V)(0.8))).V);
return t_181;
return default;
}, 2, "behind", false)).Put("shy", Fn((V _self184, int _argc185, V t_191, V _a188, V _a189, V _a190, V[] _rest186) => {
if (_self184.IsNullish) _self184 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_191, "to", ((V)(420D)), Call(o_15, V.Undef, Call(both_12, V.Undef, ((V)(10D)), ((V)((-14D)))), NewObj(6).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("blush", ((V)(1D))).Put("sq", ((V)(0.05))).Put("close", ((V)(0.5))).Put("htilt", ((V)(6D))).V), ((V)("io"))), "wait", ((V)(800D))), "to", ((V)(260D)), NewObj(4).Put("hLx", ((V)(4D))).Put("ly", ((V)(0.4))).Put("lx", ((V)((-0.6)))).Put("close", ((V)(0D))).V), "wait", ((V)(600D))), "to", ((V)(220D)), NewObj(1).Put("hLx", ((V)(10D))).V), "wait", ((V)(300D)));
return t_191;
return default;
}, 1, "shy", false)).Put("kiss", Fn((V _self192, int _argc193, V t_199, V _a196, V _a197, V _a198, V[] _rest194) => {
if (_self192.IsNullish) _self192 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_199, "to", ((V)(360D)), Call(o_15, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(11D)), ((V)((-13D)))), NewObj(4).Put("armR", ((V)(30D))).Put("mw", ((V)(0.35))).Put("open", ((V)(0.12))).Put("close", ((V)(0.6))).V), ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(260D)), Call(o_15, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)((-4D))), ((V)((-6D)))), NewObj(6).Put("armR", ((V)(80D))).Put("mw", ((V)(1D))).Put("open", ((V)(0.3))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("winkR", ((V)(1D))).V), ((V)("o"))), "fx", ((V)("heart")), ((V)("mouth")), ((V)(2D))), "wait", ((V)(600D)));
return t_199;
return default;
}, 1, "kiss", false)).Put("peekaboo", Fn((V _self200, int _argc201, V t_207, V _a204, V _a205, V _a206, V[] _rest202) => {
if (_self200.IsNullish) _self200 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_207, "to", ((V)(380D)), Call(o_15, V.Undef, Call(both_12, V.Undef, ((V)(6D)), ((V)((-20D)))), NewObj(4).Put("armL", ((V)(34D))).Put("armR", ((V)(34D))).Put("close", ((V)(1D))).Put("sq", ((V)(0.04))).V), ((V)("io"))), "wait", ((V)(900D))), "to", ((V)(180D)), Call(o_15, V.Undef, Call(both_12, V.Undef, ((V)((-6D))), ((V)((-12D)))), NewObj(9).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).Put("close", ((V)(0D))).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(2D))).V), ((V)("o"))), "wait", ((V)(500D)));
return t_207;
return default;
}, 1, "peekaboo", false)).Put("stomp", Fn((V _self208, int _argc209, V t_215, V _a212, V _a213, V _a214, V[] _rest210) => {
if (_self208.IsNullish) _self208 = GlobalV;
Invoke(Arr(((V)(1D)), ((V)((-1D))), ((V)(1D))), "forEach", Fn((V _self208, int _argc216, V s_222, V _a219, V _a220, V _a221, V[] _rest217) => {
V K_223 = default;
K_223 = Call(SIDE_13, V.Undef, s_222);
Invoke(Invoke(Invoke(Invoke(t_215, "to", ((V)(240D)), NewObj(3).PutK(Get(K_223, "foot"), ((V)(3.6))).Put("tilt", ((V)((ToNum(s_222) * 4D)))).Put("lift", ((V)(1.4))).V, ((V)("o"))), "to", ((V)(130D)), NewObj(4).PutK(Get(K_223, "foot"), ((V)(0D))).Put("tilt", ((V)(0D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.1))).V, ((V)("i"))), "fx", ((V)("dust")), ((V)((LtN(s_222, 0D) ? "footL" : "footR"))), ((V)(3D))), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "", true));
Invoke(t_215, "to", ((V)(220D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V);
return t_215;
return default;
}, 1, "stomp", false)).Put("flap", Fn((V _self224, int _argc225, V t_231, V _a228, V _a229, V _a230, V[] _rest226) => {
if (_self224.IsNullish) _self224 = GlobalV;
Invoke(Invoke(t_231, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "osc", ((V)(1100D)), ((V)(6D)), NewObj(3).Put("armL", ((V)(48D))).Put("armR", ((V)(48D))).Put("lift", ((V)(1.2))).V, NewObj(3).Put("armL", ((V)(6D))).Put("armR", ((V)(6D))).Put("lift", ((V)(0D))).V, ((V)("o")));
return t_231;
return default;
}, 1, "flap", false)).Put("bow", Fn((V _self232, int _argc233, V t_239, V _a236, V _a237, V _a238, V[] _rest234) => {
if (_self232.IsNullish) _self232 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_239, "to", ((V)(500D)), NewObj(6).Put("pitch", ((V)((-0.4)))).Put("lean", ((V)(0.6))).Put("close", ((V)(0.8))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).Put("sq", ((V)(0.04))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(400D)), NewObj(8).Put("pitch", ((V)(0.05))).Put("lean", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("winkR", ((V)(1D))).V), "wait", ((V)(300D)));
return t_239;
return default;
}, 1, "bow", false)).Put("curtsy", Fn((V _self240, int _argc241, V t_247, V _a244, V _a245, V _a246, V[] _rest242) => {
if (_self240.IsNullish) _self240 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_247, "to", ((V)(500D)), NewObj(9).Put("sq", ((V)(0.1))).Put("lift", ((V)((-1.2)))).Put("pitch", ((V)((-0.15)))).Put("htilt", ((V)(6D))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).Put("armL", ((V)(26D))).Put("armR", ((V)(26D))).Put("footR", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(400D)), NewObj(9).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("footR", ((V)(0D))).Put("hap", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("winkL", ((V)(1D))).V), "wait", ((V)(300D)));
return t_247;
return default;
}, 1, "curtsy", false)).Put("belly", Fn((V _self248, int _argc249, V t_255, V _a252, V _a253, V _a254, V[] _rest250) => {
if (_self248.IsNullish) _self248 = GlobalV;
Invoke(Invoke(Invoke(t_255, "to", ((V)(400D)), Call(o_15, V.Undef, Call(both_12, V.Undef, ((V)(6D)), ((V)(6D))), NewObj(4).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).Put("close", ((V)(0.5))).Put("smile", ((V)(1D))).V), ((V)("io"))), "osc", ((V)(1200D)), ((V)(4D)), NewObj(3).Put("hLy", ((V)(9D))).Put("hRy", ((V)(5D))).Put("sq", ((V)(0.02))).V, NewObj(3).Put("hLy", ((V)(5D))).Put("hRy", ((V)(9D))).Put("sq", ((V)(0D))).V, ((V)("s"))), "to", ((V)(200D)), NewObj(1).Put("hap", ((V)(0.7))).V);
return t_255;
return default;
}, 1, "belly", false)).Put("jump", Fn((V _self256, int _argc257, V t_263, V _a260, V _a261, V _a262, V[] _rest258) => {
if (_self256.IsNullish) _self256 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_263, "to", ((V)(260D)), NewObj(4).Put("sq", ((V)(0.14))).Put("lift", ((V)((-1D)))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(10).Put("sq", ((V)((-0.12)))).Put("lift", ((V)(10D))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.5))).Put("wide", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(7).Put("lift", ((V)(0D))).Put("sq", ((V)(0.1))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("i"))), "fx", ((V)("spark")), ((V)("head")), ((V)(4D))), "to", ((V)(220D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("o")));
return t_263;
return default;
}, 1, "jump", false)).V;
Invoke(Arr(((V)("look")), ((V)("wiggle")), ((V)("hum")), ((V)("ears")), ((V)("wag")), ((V)("giggle")), ((V)("bounce")), ((V)("wave")), ((V)("nod"))), "forEach", Fn((V _self1, int _argc264, V n_270, V _a267, V _a268, V _a269, V[] _rest265) => {
if (!(Truthy(GetK(SB_18, n_270)))) {
SetK(SB_18, n_270, GetK(BEAT_14, n_270));
}
return default;
}, 1, "", true));
FID_19 = Get(R_8, "FIDK");
SHARED_20 = Arr(((V)("idle_look")), ((V)("idle_yawn")), ((V)("idle_waveR")));
Invoke(Arr(((V)("wiggle")), ((V)("hum")), ((V)("nod")), ((V)("ears")), ((V)("giggle")), ((V)("bounce"))), "forEach", Fn((V _self1, int _argc271, V n_277, V i_278, V _a275, V _a276, V[] _rest272) => {
V t_279 = default;
t_279 = Call(TL_10, V.Undef, REST_16);
InvokeK(SB_18, n_277, t_279);
Invoke(t_279, "back", ((V)(320D)));
SetK(Get(R_8, "STATES"), ((V)(string.Concat("hf", ToStr(Add(i_278, ((V)(1D))))))), Invoke(t_279, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(220D))).V));
return default;
}, 2, "", true));
W_21 = Set(G("window"), "HouseIdle", NewObj(4).Put("SB", SB_18).Put("sp", sp_17).Put("PROF", NewObj(0).V).Put("build", Fn((V _self280, int _argc281, V key_287, V list_288, V X_289, V _a286, V[] _rest282) => {
V S_290 = default;
V names_291 = default;
if (_self280.IsNullish) _self280 = GlobalV;
X_289 = (X_289 is var _t292 && Truthy(_t292) ? _t292 : NewObj(0).V);
S_290 = NewObj(0).V;
names_291 = Arr();
Invoke(list_288, "forEach", Fn((V _self280, int _argc293, V b_299, V i_300, V _a297, V _a298, V[] _rest294) => {
V t_301 = default;
V nm_302 = default;
t_301 = Call(TL_10, V.Undef, REST_16);
Invoke(t_301, "e", ((V)("blink")));
if (string.Equals(Typeof(b_299), "function")) {
Call(b_299, V.Undef, t_301);
} else {
V n_303 = default;
V a_304 = default;
{ V _t305 = ((b_299.O is JsArray) ? b_299 : Arr(b_299));
{ V _t306 = ListOf(_t305);
{ V _t307 = GetIdx(_t306, 0D);
n_303 = _t307; }
{ V _t308 = GetIdx(_t306, 1D);
a_304 = _t308; }
} }
Call((GetK(SB_18, n_303) is var _t309 && Truthy(_t309) ? _t309 : Get(SB_18, "look")), V.Undef, t_301, a_304);
}
Invoke(t_301, "back", ((V)(320D)));
nm_302 = ((V)(string.Concat("hf", ToStr(Add(i_300, ((V)(1D)))))));
SetK(S_290, ((V)(string.Concat(ToStr(nm_302), "@", ToStr(key_287)))), Invoke(t_301, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(220D))).V));
Invoke(names_291, "push", nm_302);
return default;
}, 2, "", true));
Invoke(R_8, "add", S_290);
Set(R_8, "HS", Object_assign((Get(R_8, "HS") is var _t310 && Truthy(_t310) ? _t310 : NewObj(0).V), S_290));
SetK(FID_19, key_287, Invoke(names_291, "concat", (Truthy(Get(X_289, "skip")) ? Invoke(SHARED_20, "filter", Fn((V _self280, int _argc311, V n_317, V _a314, V _a315, V _a316, V[] _rest312) => {
return (!(Truthy(Invoke(Get(X_289, "skip"), "includes", n_317))) ? V.True : V.False);
}, 1, "", true)) : SHARED_20)));
SetK(Get(W_21, "PROF"), key_287, Get(list_288, "length"));
return default;
}, 3, "build", false)).V);
Invoke((Get(G("window"), "HouseIdleC") is var _t325 && Truthy(_t325) ? _t325 : Arr()), "forEach", Fn((V _self1, int _argc318, V f_324, V _a321, V _a322, V _a323, V[] _rest319) => {
return Call(f_324, V.Undef, W_21);
}, 1, "", true));
Set(G("window"), "HouseIdleC", NewObj(1).Put("push", Fn((V _self1, int _argc326, V f_332, V _a329, V _a330, V _a331, V[] _rest327) => {
return Call(f_332, V.Undef, W_21);
}, 1, "push", true)).V);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
