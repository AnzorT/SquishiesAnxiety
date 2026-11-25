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
sp_17 = Fn((V _arrowThis40, int _argc30, V t_36, V v_37, V d_38, V hold_39, V[] _rest31) => {
V b_41 = default;
b_41 = NewObj(0).V;
Invoke(Object_keys(v_37), "forEach", Fn((V _arrowThis49, int _argc42, V k_48, V _a45, V _a46, V _a47, V[] _rest43) => {
return SetK(b_41, k_48, (!GetK(REST_16, k_48).IsNullish ? GetK(REST_16, k_48) : ((V)(0D))));
}, 1, "", true));
Invoke(Invoke(Invoke(t_36, "to", ((V)((ToNum((d_38 is var _t52 && Truthy(_t52) ? _t52 : ((V)(700D)))) * 0.4))), v_37, ((V)("o"))), "wait", (hold_39 is var _t51 && Truthy(_t51) ? _t51 : ((V)(300D)))), "to", ((V)((ToNum((d_38 is var _t50 && Truthy(_t50) ? _t50 : ((V)(700D)))) * 0.6))), b_41, ((V)("io")));
return t_36;
return default;
}, 4, "", true);
SB_18 = NewObj(24).Put("scratch", Fn((V _self53, int _argc54, V t_60, V s_61, V _a58, V _a59, V[] _rest55) => {
V K_62 = default;
if (_self53.IsNullish) _self53 = GlobalV;
s_61 = (s_61 is var _t63 && Truthy(_t63) ? _t63 : ((V)(1D)));
K_62 = Call(SIDE_13, V.Undef, s_61);
Invoke(Invoke(Invoke(Invoke(t_60, "to", ((V)(380D)), Call(o_15, V.Undef, Call(hand_11, V.Undef, s_61, ((V)((-6D))), ((V)((-26D)))), NewObj(6).PutK(Get(K_62, "arm"), ((V)(35D))).Put("htilt", ((V)((ToNum(s_61) * 10D)))).Put("lean", ((V)((ToNum(s_61) * 1.2)))).PutK(Get(K_62, "wink"), ((V)(1D))).Put("tongue", ((V)(0.3))).PutK(Get(K_62, "foot"), ((V)(1.2))).V), ((V)("io"))), "osc", ((V)(1300D)), ((V)(7D)), NewObj(2).PutK(Get(K_62, "hy"), ((V)((-30D)))).PutK(Get(K_62, "ear"), ((V)(8D))).V, NewObj(2).PutK(Get(K_62, "hy"), ((V)((-24D)))).PutK(Get(K_62, "ear"), ((V)((-2D)))).V, ((V)("l"))), "to", ((V)(280D)), Call(o_15, V.Undef, Call(hand_11, V.Undef, s_61, ((V)(0D)), ((V)(0D))), NewObj(8).PutK(Get(K_62, "arm"), ((V)(0D))).PutK(Get(K_62, "wink"), ((V)(0D))).Put("tongue", ((V)(0D))).PutK(Get(K_62, "foot"), ((V)(0D))).Put("htilt", ((V)(0D))).Put("lean", ((V)(0D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V), ((V)("io"))), "osc", ((V)(500D)), ((V)(3D)), NewObj(1).Put("htilt", ((V)(4D))).V, NewObj(1).Put("htilt", ((V)((-4D)))).V, ((V)("s")));
return t_60;
return default;
}, 2, "scratch", false)).Put("groom", Fn((V _self64, int _argc65, V t_71, V _a68, V _a69, V _a70, V[] _rest66) => {
if (_self64.IsNullish) _self64 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_71, "to", ((V)(380D)), Call(o_15, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(12D)), ((V)((-14D)))), NewObj(3).Put("armR", ((V)(32D))).Put("close", ((V)(0.6))).Put("pitch", ((V)((-0.08)))).V), ((V)("io"))), "osc", ((V)(1100D)), ((V)(5D)), NewObj(2).Put("tongue", ((V)(0.7))).Put("hRy", ((V)((-16D)))).V, NewObj(2).Put("tongue", ((V)(0.15))).Put("hRy", ((V)((-13D)))).V, ((V)("l"))), "to", ((V)(300D)), Call(o_15, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-24D)))), NewObj(3).Put("tongue", ((V)(0D))).Put("close", ((V)(0.8))).Put("htilt", ((V)(7D))).V), ((V)("io"))), "osc", ((V)(1000D)), ((V)(3D)), NewObj(2).Put("hRx", ((V)(2D))).Put("hRy", ((V)((-26D)))).V, NewObj(2).Put("hRx", ((V)((-6D)))).Put("hRy", ((V)((-20D)))).V, ((V)("s"))), "to", ((V)(260D)), NewObj(2).Put("hap", ((V)(0.5))).Put("smile", ((V)(0.8))).V);
return t_71;
return default;
}, 1, "groom", false)).Put("stretch", Fn((V _self72, int _argc73, V t_79, V _a76, V _a77, V _a78, V[] _rest74) => {
if (_self72.IsNullish) _self72 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_79, "to", ((V)(620D)), NewObj(9).Put("armL", ((V)(160D))).Put("armR", ((V)(160D))).Put("hLy", ((V)((-4D)))).Put("hRy", ((V)((-4D)))).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(1.6))).Put("close", ((V)(0.85))).Put("pitch", ((V)(0.3))).Put("open", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(350D))), "osc", ((V)(560D)), ((V)(2D)), NewObj(1).Put("tilt", ((V)(1.6))).V, NewObj(1).Put("tilt", ((V)((-1.6)))).V, ((V)("s"))), "to", ((V)(420D)), NewObj(10).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("sq", ((V)(0.06))).Put("lift", ((V)(0D))).Put("pitch", ((V)(0D))).Put("open", ((V)(0D))).Put("close", ((V)(0.3))).Put("tilt", ((V)(0D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(4).Put("sq", ((V)(0D))).Put("close", ((V)(0D))).Put("hap", ((V)(0.5))).Put("smile", ((V)(0.8))).V, ((V)("o"))), "e", ((V)("blink2")));
return t_79;
return default;
}, 1, "stretch", false)).Put("hops", Fn((V _self80, int _argc81, V t_87, V n_88, V _a85, V _a86, V[] _rest82) => {
if (_self80.IsNullish) _self80 = GlobalV;
n_88 = (n_88 is var _t89 && Truthy(_t89) ? _t89 : ((V)(3D)));
Invoke(t_87, "to", ((V)(160D)), NewObj(3).Put("hap", ((V)(0.9))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).V);
{
double i_90 = 0;
i_90 = 0D;
while (true) {
if (!(Lt(((V)(i_90)), n_88))) break;
Invoke(Invoke(Invoke(t_87, "to", ((V)(110D)), NewObj(2).Put("sq", ((V)(0.1))).Put("lift", ((V)(0D))).V, ((V)("i"))), "to", ((V)(190D)), NewObj(6).Put("sq", ((V)((-0.07)))).Put("lift", ((V)(5D))).Put("footL", ((V)(1.5))).Put("footR", ((V)(1.5))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(6).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("i")));
i_90++;
}
}
Invoke(t_87, "to", ((V)(140D)), NewObj(1).Put("sq", ((V)(0.06))).V, ((V)("o")));
return t_87;
return default;
}, 2, "hops", false)).Put("twirl", Fn((V _self92, int _argc93, V t_99, V d_100, V _a97, V _a98, V[] _rest94) => {
if (_self92.IsNullish) _self92 = GlobalV;
d_100 = (d_100 is var _t101 && Truthy(_t101) ? _t101 : ((V)(1D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_99, "to", ((V)(160D)), NewObj(6).Put("sq", ((V)(0.07))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("io"))), "to", ((V)(760D)), NewObj(3).Put("spin", ((V)((ToNum(d_100) * 360D)))).Put("lift", ((V)(3D))).Put("sq", ((V)((-0.05)))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "to", ((V)(170D)), NewObj(4).Put("lift", ((V)(0D))).Put("sq", ((V)(0.07))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("o"))), "e", ((V)("blink")));
return t_99;
return default;
}, 2, "twirl", false)).Put("sniff", Fn((V _self102, int _argc103, V t_109, V _a106, V _a107, V _a108, V[] _rest104) => {
if (_self102.IsNullish) _self102 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_109, "to", ((V)(420D)), NewObj(4).Put("pitch", ((V)((-0.28)))).Put("ly", ((V)(0.9))).Put("lean", ((V)(0.8))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "osc", ((V)(1000D)), ((V)(7D)), NewObj(3).Put("mw", ((V)(0.55))).Put("sq", ((V)(0.05))).Put("puff", ((V)(0.2))).V, NewObj(3).Put("mw", ((V)(1D))).Put("sq", ((V)(0.03))).Put("puff", ((V)(0D))).V, ((V)("l"))), "to", ((V)(300D)), NewObj(2).Put("lx", ((V)(0.7))).Put("turn", ((V)(0.2))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(5D)), NewObj(1).Put("mw", ((V)(0.55))).V, NewObj(1).Put("mw", ((V)(1D))).V, ((V)("l"))), "to", ((V)(220D)), NewObj(7).Put("ly", ((V)((-0.2)))).Put("pitch", ((V)(0.08))).Put("lx", ((V)(0D))).Put("turn", ((V)(0D))).Put("wide", ((V)(0.5))).Put("lean", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(200D))), "to", ((V)(240D)), NewObj(3).Put("wide", ((V)(0D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(0.8))).V);
return t_109;
return default;
}, 1, "sniff", false)).Put("shake", Fn((V _self110, int _argc111, V t_117, V _a114, V _a115, V _a116, V[] _rest112) => {
if (_self110.IsNullish) _self110 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_117, "to", ((V)(360D)), NewObj(4).Put("sq", ((V)(0.1))).Put("close", ((V)(0.6))).Put("earL", ((V)(6D))).Put("earR", ((V)(6D))).V, ((V)("io"))), "osc", ((V)(1200D)), ((V)(8D)), NewObj(3).Put("spin", ((V)(24D))).Put("htilt", ((V)((-8D)))).Put("sqz", ((V)(1D))).V, NewObj(2).Put("spin", ((V)((-24D)))).Put("htilt", ((V)(8D))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(8).Put("spin", ((V)(0D))).Put("htilt", ((V)(0D))).Put("sqz", ((V)(0D))).Put("close", ((V)(0D))).Put("sq", ((V)((-0.05)))).Put("wide", ((V)(0.6))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(4).Put("wide", ((V)(0D))).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
return t_117;
return default;
}, 1, "shake", false)).Put("tap", Fn((V _self118, int _argc119, V t_125, V _a122, V _a123, V _a124, V[] _rest120) => {
if (_self118.IsNullish) _self118 = GlobalV;
Invoke(t_125, "to", ((V)(320D)), NewObj(4).Put("lx", ((V)(0.9))).Put("turn", ((V)(0.25))).Put("htilt", ((V)(5D))).Put("mw", ((V)(0.6))).V, ((V)("io")));
{
double i_126 = 0;
i_126 = 0D;
while (true) {
if (!((i_126 < 4D))) break;
Invoke(Invoke(Invoke(t_125, "to", ((V)(130D)), NewObj(1).Put("footR", ((V)(2.4))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(2).Put("footR", ((V)(0D))).Put("sq", ((V)(0.02))).V, ((V)("i"))), "to", ((V)(60D)), NewObj(1).Put("sq", ((V)(0D))).V);
i_126++;
}
}
Invoke(Invoke(t_125, "to", ((V)(300D)), NewObj(3).Put("lx", ((V)((-0.6)))).Put("turn", ((V)((-0.15)))).Put("htilt", ((V)((-3D)))).V, ((V)("io"))), "wait", ((V)(300D)));
return t_125;
return default;
}, 1, "tap", false)).Put("ponder", Fn((V _self128, int _argc129, V t_135, V _a132, V _a133, V _a134, V[] _rest130) => {
if (_self128.IsNullish) _self128 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_135, "to", ((V)(420D)), Call(o_15, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(10D)), ((V)((-12D)))), NewObj(6).Put("armR", ((V)(30D))).Put("ly", ((V)((-1D)))).Put("lx", ((V)(0.5))).Put("htilt", ((V)(7D))).Put("mw", ((V)(0.5))).Put("pitch", ((V)(0.12))).V), ((V)("io"))), "wait", ((V)(1100D))), "to", ((V)(200D)), NewObj(3).Put("wide", ((V)(0.7))).Put("open", ((V)(0.3))).Put("ly", ((V)((-0.4)))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(3).Put("armR", ((V)(90D))).Put("hRy", ((V)((-6D)))).Put("hRx", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(400D))), "to", ((V)(260D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
return t_135;
return default;
}, 1, "ponder", false)).Put("sneeze", Fn((V _self136, int _argc137, V t_143, V _a140, V _a141, V _a142, V[] _rest138) => {
if (_self136.IsNullish) _self136 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_143, "to", ((V)(500D)), NewObj(4).Put("pitch", ((V)(0.35))).Put("open", ((V)(0.45))).Put("close", ((V)(0.7))).Put("sq", ((V)((-0.06)))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("pitch", ((V)(0.45))).Put("open", ((V)(0.6))).V), "to", ((V)(90D)), NewObj(6).Put("pitch", ((V)((-0.4)))).Put("open", ((V)(0.9))).Put("sqz", ((V)(1D))).Put("close", ((V)(0D))).Put("sq", ((V)(0.2))).Put("lean", ((V)(0.4))).V, ((V)("o"))), "fx", ((V)("sneeze")), ((V)("nose"))), "to", ((V)(260D)), NewObj(4).Put("pitch", ((V)(0D))).Put("open", ((V)(0.1))).Put("sq", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(3).Put("sqz", ((V)(0D))).Put("open", ((V)(0D))).Put("blush", ((V)(0.7))).V), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(3).Put("blush", ((V)(0D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(0.8))).V);
return t_143;
return default;
}, 1, "sneeze", false)).Put("rub", Fn((V _self144, int _argc145, V t_151, V _a148, V _a149, V _a150, V[] _rest146) => {
if (_self144.IsNullish) _self144 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_151, "to", ((V)(380D)), Call(o_15, V.Undef, Call(both_12, V.Undef, ((V)(6D)), ((V)((-18D)))), NewObj(4).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).Put("close", ((V)(1D))).Put("mw", ((V)(0.6))).V), ((V)("io"))), "osc", ((V)(1100D)), ((V)(4D)), NewObj(2).Put("hLy", ((V)((-21D)))).Put("hRy", ((V)((-16D)))).V, NewObj(2).Put("hLy", ((V)((-16D)))).Put("hRy", ((V)((-21D)))).V, ((V)("s"))), "to", ((V)(300D)), Call(o_15, V.Undef, Call(both_12, V.Undef, ((V)(0D)), ((V)(0D))), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("close", ((V)(0D))).Put("wide", ((V)(0.5))).V, ((V)("o"))), "e", ((V)("blink2"))), "to", ((V)(260D)), NewObj(1).Put("wide", ((V)(0D))).V);
return t_151;
return default;
}, 1, "rub", false)).Put("shimmy", Fn((V _self152, int _argc153, V t_159, V _a156, V _a157, V _a158, V[] _rest154) => {
if (_self152.IsNullish) _self152 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_159, "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V), "fx", ((V)("note")), ((V)("head"))), "osc", ((V)(1600D)), ((V)(4D)), NewObj(5).Put("x", ((V)(1.4))).Put("tilt", ((V)(4D))).Put("armL", ((V)(60D))).Put("armR", ((V)(10D))).Put("htilt", ((V)(4D))).V, NewObj(5).Put("x", ((V)((-1.4)))).Put("tilt", ((V)((-4D)))).Put("armL", ((V)(10D))).Put("armR", ((V)(60D))).Put("htilt", ((V)((-4D)))).V, ((V)("s"))), "fx", ((V)("note")), ((V)("head")));
return t_159;
return default;
}, 1, "shimmy", false)).Put("clap", Fn((V _self160, int _argc161, V t_167, V _a164, V _a165, V _a166, V[] _rest162) => {
if (_self160.IsNullish) _self160 = GlobalV;
Invoke(Invoke(Invoke(t_167, "to", ((V)(300D)), Call(o_15, V.Undef, Call(both_12, V.Undef, ((V)(4D)), ((V)((-8D)))), NewObj(5).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).V), ((V)("io"))), "osc", ((V)(1100D)), ((V)(5D)), Call(o_15, V.Undef, Call(both_12, V.Undef, ((V)(13D)), ((V)((-9D)))), NewObj(1).Put("sq", ((V)(0.02))).V), Call(o_15, V.Undef, Call(both_12, V.Undef, ((V)(4D)), ((V)((-8D)))), NewObj(1).Put("sq", ((V)(0D))).V), ((V)("o"))), "fx", ((V)("spark")), ((V)("pawR")), ((V)(3D)));
return t_167;
return default;
}, 1, "clap", false)).Put("rock", Fn((V _self168, int _argc169, V t_175, V _a172, V _a173, V _a174, V[] _rest170) => {
if (_self168.IsNullish) _self168 = GlobalV;
Invoke(Invoke(t_175, "osc", ((V)(1800D)), ((V)(3D)), NewObj(4).Put("pitch", ((V)(0.12))).Put("lift", ((V)(0.8))).Put("footL", ((V)(0.6))).Put("footR", ((V)(0.6))).V, NewObj(4).Put("pitch", ((V)((-0.08)))).Put("lift", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("s"))), "to", ((V)(220D)), NewObj(2).Put("smile", ((V)(0.8))).Put("close", ((V)(0.4))).V);
return t_175;
return default;
}, 1, "rock", false)).Put("behind", Fn((V _self176, int _argc177, V t_183, V s_184, V _a181, V _a182, V[] _rest178) => {
if (_self176.IsNullish) _self176 = GlobalV;
s_184 = (s_184 is var _t185 && Truthy(_t185) ? _t185 : ((V)(1D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_183, "to", ((V)(500D)), NewObj(4).Put("spin", ((V)((ToNum(s_184) * 120D)))).Put("turn", ((V)((ToNum(s_184) * 0.3)))).Put("lean", ((V)(((-ToNum(s_184)) * 0.8)))).PutK(Get(Call(SIDE_13, V.Undef, s_184), "foot"), ((V)(1.6))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).PutK(Get(Call(SIDE_13, V.Undef, s_184), "foot"), ((V)(0D))).V), "wait", ((V)(700D))), "to", ((V)(160D)), NewObj(1).Put("wide", ((V)(0.6))).V), "to", ((V)(520D)), NewObj(3).Put("spin", ((V)(0D))).Put("turn", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(3).Put("wide", ((V)(0D))).Put("hap", ((V)(0.5))).Put("smile", ((V)(0.8))).V);
return t_183;
return default;
}, 2, "behind", false)).Put("shy", Fn((V _self186, int _argc187, V t_193, V _a190, V _a191, V _a192, V[] _rest188) => {
if (_self186.IsNullish) _self186 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_193, "to", ((V)(420D)), Call(o_15, V.Undef, Call(both_12, V.Undef, ((V)(10D)), ((V)((-14D)))), NewObj(6).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("blush", ((V)(1D))).Put("sq", ((V)(0.05))).Put("close", ((V)(0.5))).Put("htilt", ((V)(6D))).V), ((V)("io"))), "wait", ((V)(800D))), "to", ((V)(260D)), NewObj(4).Put("hLx", ((V)(4D))).Put("ly", ((V)(0.4))).Put("lx", ((V)((-0.6)))).Put("close", ((V)(0D))).V), "wait", ((V)(600D))), "to", ((V)(220D)), NewObj(1).Put("hLx", ((V)(10D))).V), "wait", ((V)(300D)));
return t_193;
return default;
}, 1, "shy", false)).Put("kiss", Fn((V _self194, int _argc195, V t_201, V _a198, V _a199, V _a200, V[] _rest196) => {
if (_self194.IsNullish) _self194 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_201, "to", ((V)(360D)), Call(o_15, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(11D)), ((V)((-13D)))), NewObj(4).Put("armR", ((V)(30D))).Put("mw", ((V)(0.35))).Put("open", ((V)(0.12))).Put("close", ((V)(0.6))).V), ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(260D)), Call(o_15, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)((-4D))), ((V)((-6D)))), NewObj(6).Put("armR", ((V)(80D))).Put("mw", ((V)(1D))).Put("open", ((V)(0.3))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("winkR", ((V)(1D))).V), ((V)("o"))), "fx", ((V)("heart")), ((V)("mouth")), ((V)(2D))), "wait", ((V)(600D)));
return t_201;
return default;
}, 1, "kiss", false)).Put("peekaboo", Fn((V _self202, int _argc203, V t_209, V _a206, V _a207, V _a208, V[] _rest204) => {
if (_self202.IsNullish) _self202 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_209, "to", ((V)(380D)), Call(o_15, V.Undef, Call(both_12, V.Undef, ((V)(6D)), ((V)((-20D)))), NewObj(4).Put("armL", ((V)(34D))).Put("armR", ((V)(34D))).Put("close", ((V)(1D))).Put("sq", ((V)(0.04))).V), ((V)("io"))), "wait", ((V)(900D))), "to", ((V)(180D)), Call(o_15, V.Undef, Call(both_12, V.Undef, ((V)((-6D))), ((V)((-12D)))), NewObj(9).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).Put("close", ((V)(0D))).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(2D))).V), ((V)("o"))), "wait", ((V)(500D)));
return t_209;
return default;
}, 1, "peekaboo", false)).Put("stomp", Fn((V _self210, int _argc211, V t_217, V _a214, V _a215, V _a216, V[] _rest212) => {
if (_self210.IsNullish) _self210 = GlobalV;
Invoke(Arr(((V)(1D)), ((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis225, int _argc218, V s_224, V _a221, V _a222, V _a223, V[] _rest219) => {
V K_226 = default;
K_226 = Call(SIDE_13, V.Undef, s_224);
Invoke(Invoke(Invoke(Invoke(t_217, "to", ((V)(240D)), NewObj(3).PutK(Get(K_226, "foot"), ((V)(3.6))).Put("tilt", ((V)((ToNum(s_224) * 4D)))).Put("lift", ((V)(1.4))).V, ((V)("o"))), "to", ((V)(130D)), NewObj(4).PutK(Get(K_226, "foot"), ((V)(0D))).Put("tilt", ((V)(0D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.1))).V, ((V)("i"))), "fx", ((V)("dust")), ((V)((LtN(s_224, 0D) ? "footL" : "footR"))), ((V)(3D))), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "", true));
Invoke(t_217, "to", ((V)(220D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V);
return t_217;
return default;
}, 1, "stomp", false)).Put("flap", Fn((V _self227, int _argc228, V t_234, V _a231, V _a232, V _a233, V[] _rest229) => {
if (_self227.IsNullish) _self227 = GlobalV;
Invoke(Invoke(t_234, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "osc", ((V)(1100D)), ((V)(6D)), NewObj(3).Put("armL", ((V)(48D))).Put("armR", ((V)(48D))).Put("lift", ((V)(1.2))).V, NewObj(3).Put("armL", ((V)(6D))).Put("armR", ((V)(6D))).Put("lift", ((V)(0D))).V, ((V)("o")));
return t_234;
return default;
}, 1, "flap", false)).Put("bow", Fn((V _self235, int _argc236, V t_242, V _a239, V _a240, V _a241, V[] _rest237) => {
if (_self235.IsNullish) _self235 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_242, "to", ((V)(500D)), NewObj(6).Put("pitch", ((V)((-0.4)))).Put("lean", ((V)(0.6))).Put("close", ((V)(0.8))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).Put("sq", ((V)(0.04))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(400D)), NewObj(8).Put("pitch", ((V)(0.05))).Put("lean", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("winkR", ((V)(1D))).V), "wait", ((V)(300D)));
return t_242;
return default;
}, 1, "bow", false)).Put("curtsy", Fn((V _self243, int _argc244, V t_250, V _a247, V _a248, V _a249, V[] _rest245) => {
if (_self243.IsNullish) _self243 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_250, "to", ((V)(500D)), NewObj(9).Put("sq", ((V)(0.1))).Put("lift", ((V)((-1.2)))).Put("pitch", ((V)((-0.15)))).Put("htilt", ((V)(6D))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).Put("armL", ((V)(26D))).Put("armR", ((V)(26D))).Put("footR", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(400D)), NewObj(9).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("footR", ((V)(0D))).Put("hap", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("winkL", ((V)(1D))).V), "wait", ((V)(300D)));
return t_250;
return default;
}, 1, "curtsy", false)).Put("belly", Fn((V _self251, int _argc252, V t_258, V _a255, V _a256, V _a257, V[] _rest253) => {
if (_self251.IsNullish) _self251 = GlobalV;
Invoke(Invoke(Invoke(t_258, "to", ((V)(400D)), Call(o_15, V.Undef, Call(both_12, V.Undef, ((V)(6D)), ((V)(6D))), NewObj(4).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).Put("close", ((V)(0.5))).Put("smile", ((V)(1D))).V), ((V)("io"))), "osc", ((V)(1200D)), ((V)(4D)), NewObj(3).Put("hLy", ((V)(9D))).Put("hRy", ((V)(5D))).Put("sq", ((V)(0.02))).V, NewObj(3).Put("hLy", ((V)(5D))).Put("hRy", ((V)(9D))).Put("sq", ((V)(0D))).V, ((V)("s"))), "to", ((V)(200D)), NewObj(1).Put("hap", ((V)(0.7))).V);
return t_258;
return default;
}, 1, "belly", false)).Put("jump", Fn((V _self259, int _argc260, V t_266, V _a263, V _a264, V _a265, V[] _rest261) => {
if (_self259.IsNullish) _self259 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_266, "to", ((V)(260D)), NewObj(4).Put("sq", ((V)(0.14))).Put("lift", ((V)((-1D)))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(10).Put("sq", ((V)((-0.12)))).Put("lift", ((V)(10D))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.5))).Put("wide", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(7).Put("lift", ((V)(0D))).Put("sq", ((V)(0.1))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("i"))), "fx", ((V)("spark")), ((V)("head")), ((V)(4D))), "to", ((V)(220D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("o")));
return t_266;
return default;
}, 1, "jump", false)).V;
Invoke(Arr(((V)("look")), ((V)("wiggle")), ((V)("hum")), ((V)("ears")), ((V)("wag")), ((V)("giggle")), ((V)("bounce")), ((V)("wave")), ((V)("nod"))), "forEach", Fn((V _arrowThis274, int _argc267, V n_273, V _a270, V _a271, V _a272, V[] _rest268) => {
if (!(Truthy(GetK(SB_18, n_273)))) {
SetK(SB_18, n_273, GetK(BEAT_14, n_273));
}
return default;
}, 1, "", true));
FID_19 = Get(R_8, "FIDK");
SHARED_20 = Arr(((V)("idle_look")), ((V)("idle_yawn")), ((V)("idle_waveR")));
Invoke(Arr(((V)("wiggle")), ((V)("hum")), ((V)("nod")), ((V)("ears")), ((V)("giggle")), ((V)("bounce"))), "forEach", Fn((V _arrowThis283, int _argc275, V n_281, V i_282, V _a279, V _a280, V[] _rest276) => {
V t_284 = default;
t_284 = Call(TL_10, V.Undef, REST_16);
InvokeK(SB_18, n_281, t_284);
Invoke(t_284, "back", ((V)(320D)));
SetK(Get(R_8, "STATES"), ((V)(JsStrBuf.Begin().S("hf").V(Add(i_282, ((V)(1D)))).End())), Invoke(t_284, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(220D))).V));
return default;
}, 2, "", true));
W_21 = Set(G("window"), "HouseIdle", NewObj(4).Put("SB", SB_18).Put("sp", sp_17).Put("PROF", NewObj(0).V).Put("build", Fn((V _self285, int _argc286, V key_292, V list_293, V X_294, V _a291, V[] _rest287) => {
V S_295 = default;
V names_296 = default;
if (_self285.IsNullish) _self285 = GlobalV;
X_294 = (X_294 is var _t297 && Truthy(_t297) ? _t297 : NewObj(0).V);
S_295 = NewObj(0).V;
names_296 = Arr();
Invoke(list_293, "forEach", Fn((V _arrowThis306, int _argc298, V b_304, V i_305, V _a302, V _a303, V[] _rest299) => {
V t_307 = default;
V nm_308 = default;
t_307 = Call(TL_10, V.Undef, REST_16);
Invoke(t_307, "e", ((V)("blink")));
if (string.Equals(Typeof(b_304), "function")) {
Call(b_304, V.Undef, t_307);
} else {
V n_309 = default;
V a_310 = default;
{ V _t311 = ((b_304.O is JsArray) ? b_304 : Arr(b_304));
{ V _t312 = ListOf(_t311);
{ V _t313 = GetIdx(_t312, 0D);
n_309 = _t313; }
{ V _t314 = GetIdx(_t312, 1D);
a_310 = _t314; }
} }
Call((GetK(SB_18, n_309) is var _t315 && Truthy(_t315) ? _t315 : Get(SB_18, "look")), V.Undef, t_307, a_310);
}
Invoke(t_307, "back", ((V)(320D)));
nm_308 = ((V)(JsStrBuf.Begin().S("hf").V(Add(i_305, ((V)(1D)))).End()));
SetK(S_295, ((V)(JsStrBuf.Begin().V(nm_308).S("@").V(key_292).End())), Invoke(t_307, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(220D))).V));
Invoke(names_296, "push", nm_308);
return default;
}, 2, "", true));
Invoke(R_8, "add", S_295);
Set(R_8, "HS", Object_assign((Get(R_8, "HS") is var _t316 && Truthy(_t316) ? _t316 : NewObj(0).V), S_295));
SetK(FID_19, key_292, Invoke(names_296, "concat", (Truthy(Get(X_294, "skip")) ? Invoke(SHARED_20, "filter", Fn((V _arrowThis324, int _argc317, V n_323, V _a320, V _a321, V _a322, V[] _rest318) => {
return (!(Truthy(Invoke(Get(X_294, "skip"), "includes", n_323))) ? V.True : V.False);
}, 1, "", true)) : SHARED_20)));
SetK(Get(W_21, "PROF"), key_292, Get(list_293, "length"));
return default;
}, 3, "build", false)).V);
Invoke((Get(G("window"), "HouseIdleC") is var _t333 && Truthy(_t333) ? _t333 : Arr()), "forEach", Fn((V _arrowThis332, int _argc325, V f_331, V _a328, V _a329, V _a330, V[] _rest326) => {
return Call(f_331, V.Undef, W_21);
}, 1, "", true));
Set(G("window"), "HouseIdleC", NewObj(1).Put("push", Fn((V _arrowThis341, int _argc334, V f_340, V _a337, V _a338, V _a339, V[] _rest335) => {
return Call(f_340, V.Undef, W_21);
}, 1, "push", true)).V);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
