// native-host.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_native_host_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V G_8, V _a5, V _a6, V _a7, V[] _rest3) => {
V ctl_9 = default;
V ext_10 = default;
V walk_11 = default;
V park_12 = default;
V els_13 = default;
V EIO_14 = default;
V mount_15 = default;
V hostEl_16 = default;
V unmount_17 = default;
V I_18 = default;
hostEl_16 = Fn((V _self19, int _argc20, V id_26, V _a23, V _a24, V _a25, V[] _rest21) => {
return (GetK(els_13, id_26) is var _t27 && Truthy(_t27) ? _t27 : V.Null);
return default;
}, 1, "hostEl", false);
I_18 = Fn((V _self28, int _argc29, V id_35, V _a32, V _a33, V _a34, V[] _rest30) => {
V c_36 = default;
c_36 = GetK(ctl_9, id_35);
return (c_36 is var _t37 && !Truthy(_t37) ? _t37 : Get(c_36, "_I"));
return default;
}, 1, "I", false);
ctl_9 = NewObj(0).V;
ext_10 = NewObj(0).V;
walk_11 = NewObj(0).V;
park_12 = NewObj(0).V;
els_13 = NewObj(0).V;
EIO_14 = Fn((V _self38, int _argc39, V t_45, V _a42, V _a43, V _a44, V[] _rest40) => {
return ((V)((LtN(t_45, 0.5) ? ((2D * ToNum(t_45)) * ToNum(t_45)) : (1D - (Pow((((-2D) * ToNum(t_45)) + 2D), 2D) / 2D)))));
return default;
}, 1, "", false);
mount_15 = Get(Get(G_8, "__live"), "mount");
Set(Get(G_8, "__live"), "mount", Fn((V _self46, int _argc47, V key_53, V _a50, V _a51, V _a52, V[] _rest48) => {
V id_54 = default;
V b_55 = default;
id_54 = Call(mount_15, V.Undef, key_53);
b_55 = Get(Get(Get(G_8, "document"), "body"), "childNodes");
SetK(ctl_9, id_54, (Get(G_8, "RiveRig") is var _t56 && !Truthy(_t56) ? _t56 : Get(Get(G_8, "RiveRig"), "_last")));
SetK(els_13, id_54, GetIdx(b_55, (ToNum(Get(b_55, "length")) - 1D)));
return id_54;
return default;
}, 1, "", false));
unmount_17 = Get(Get(G_8, "__live"), "unmount");
Set(Get(G_8, "__live"), "unmount", Fn((V _self57, int _argc58, V id_64, V _a61, V _a62, V _a63, V[] _rest59) => {
DeleteK(ctl_9, id_64);
DeleteK(ext_10, id_64);
DeleteK(walk_11, id_64);
DeleteK(park_12, id_64);
DeleteK(els_13, id_64);
return Call(unmount_17, V.Undef, id_64);
return default;
}, 1, "", false));
Set(G_8, "__native", NewObj(12).Put("ctl", Fn((V _self65, int _argc66, V id_72, V _a69, V _a70, V _a71, V[] _rest67) => {
return (GetK(ctl_9, id_72) is var _t73 && Truthy(_t73) ? _t73 : V.Null);
return default;
}, 1, "ctl", false)).Put("ext", Fn((V _self74, int _argc75, V id_81, V o_82, V _a79, V _a80, V[] _rest76) => {
V c_83 = default;
V h_84 = default;
V k_85 = default;
V k2_86 = default;
c_83 = GetK(ctl_9, id_81);
if (!(Truthy(c_83))) {
return default;
}
h_84 = GetK(ext_10, id_81);
if (!(Truthy(h_84))) {
h_84 = SetK(ext_10, id_81, NewObj(0).V);
if (Truthy(Get(c_83, "ext"))) {
Invoke(c_83, "ext", h_84);
}
}
{
foreach (V _k87 in ForInKeys(h_84)) {
k_85 = _k87;
SetK(h_84, k_85, ((V)(0D)));
}
}
{
foreach (V _k88 in ForInKeys(o_82)) {
k2_86 = _k88;
SetK(h_84, k2_86, GetK(o_82, k2_86));
}
}
return default;
}, 2, "ext", false)).Put("events", Fn((V _self89, int _argc90, V id_96, V _a93, V _a94, V _a95, V[] _rest91) => {
return Invoke(G("JSON"), "parse", Invoke(Get(G_8, "__live"), "events", id_96));
return default;
}, 1, "events", false)).Put("walkStep", Fn((V _self97, int _argc98, V id_104, V key_105, V w_106, V dt_107, V[] _rest99) => {
V i_109 = default;
V s_110 = default;
V k_111 = default;
V spin_108 = default;
spin_108 = (_argc98 > 4 ? _rest99[0] : V.Undef);
i_109 = Call(I_18, V.Undef, id_104);
if (!(Truthy(i_109))) {
return default;
}
s_110 = (GetK(walk_11, id_104) is var _t112 && Truthy(_t112) ? _t112 : SetK(walk_11, id_104, NewObj(2).Put("E", NewObj(0).V).Put("ws", NewObj(0).V).V));
if (!SEq(Get(i_109, "ext"), Get(s_110, "E"))) {
Set(i_109, "ext", Get(s_110, "E"));
}
{
foreach (V _k113 in ForInKeys(Get(s_110, "E"))) {
k_111 = _k113;
SetK(Get(s_110, "E"), k_111, ((V)(0D)));
}
}
if (Truthy(((GtN(w_106, 0D) ? V.True : V.False) is var _t114 && !Truthy(_t114) ? _t114 : Get(G_8, "HouseWalk")))) {
try {
Invoke(Get(G_8, "HouseWalk"), "step", key_105, Get(s_110, "ws"), Get(s_110, "E"), w_106, dt_107, ((V)(1D)), spin_108);
} catch (System.Exception _ex115) {
V e_116 = default;
e_116 = Caught(_ex115);

}
}
return default;
}, 5, "walkStep", false)).Put("emit", Fn((V _self117, int _argc118, V id_124, V kind_125, V at_126, V x_127, V[] _rest119) => {
V i_130 = default;
V p_131 = default;
V y_128 = default;
V n_129 = default;
y_128 = (_argc118 > 4 ? _rest119[0] : V.Undef);
n_129 = (_argc118 > 5 ? _rest119[1] : V.Undef);
i_130 = Call(I_18, V.Undef, id_124);
if ((!(Truthy(i_130)) || !(Truthy(Get(Get(G_8, "RiveRig"), "emit"))))) {
return default;
}
p_131 = (Truthy(at_126) ? ((Get(i_130, "W") is var _t132 && !Truthy(_t132) ? _t132 : GetK(Get(i_130, "W"), at_126)) is var _t133 && Truthy(_t133) ? _t133 : Arr(((V)(50D)), ((V)(50D)))) : Arr(x_127, y_128));
Invoke(Get(G_8, "RiveRig"), "emit", i_130, kind_125, p_131, (GtN(n_129, 0D) ? n_129 : ((V)(0D))));
return default;
}, 6, "emit", false)).Put("parkStart", Fn((V _self134, int _argc135, V id_141, V key_142, V enter_143, V _a140, V[] _rest136) => {
V i_144 = default;
V c_145 = default;
V HW_146 = default;
V E_147 = default;
V ws_148 = default;
V prev_149 = default;
V ph_150 = default;
V turn_151 = default;
V walkMs_152 = default;
V dir_153 = default;
i_144 = Call(I_18, V.Undef, id_141);
c_145 = GetK(ctl_9, id_141);
if (!(Truthy(i_144))) {
return default;
}
HW_146 = Get(G_8, "HouseWalk");
E_147 = NewObj(0).V;
ws_148 = NewObj(0).V;
prev_149 = Get(i_144, "ext");
ph_150 = ((V)(0D));
turn_151 = ((V)((Truthy(enter_143) ? 380D : 340D)));
walkMs_152 = ((V)((Truthy(enter_143) ? 2300D : 2100D)));
dir_153 = ((V)((Truthy(enter_143) ? (-90D) : 90D)));
SetK(park_12, id_141, Fn((V _self154, int _argc155, V now_161, V _a158, V _a159, V _a160, V[] _rest156) => {
V tt_162 = default;
V w_163 = default;
V k_164 = default;
V k2_165 = default;
if (SEqN(ph_150, 0D)) {
Invoke(c_145, "play", ((V)("idle")));
ph_150 = ((V)(1D));
}
if (Lt(now_161, turn_151)) {
Set(i_144, "spinOff", ((V)((ToNum(dir_153) * ToNum(Call(EIO_14, V.Undef, ((V)((ToNum(now_161) / ToNum(turn_151))))))))));
return default;
}
if (Lt(now_161, Add(turn_151, walkMs_152))) {
if (!SEq(Get(i_144, "ext"), E_147)) {
Set(i_144, "ext", E_147);
}
tt_162 = ((V)(((ToNum(now_161) - ToNum(turn_151)) / ToNum(walkMs_152))));
w_163 = ((V)(Min(1D, (ToNum(tt_162) / 0.08), ((1D - ToNum(tt_162)) / 0.1))));
{
foreach (V _k166 in ForInKeys(E_147)) {
k_164 = _k166;
SetK(E_147, k_164, ((V)(0D)));
}
}
try {
Invoke(HW_146, "step", key_142, ws_148, E_147, ((V)(Max(0D, ToNum(w_163)))), ((V)(0.016)), ((V)(1D)), dir_153);
} catch (System.Exception _ex167) {
V e_168 = default;
e_168 = Caught(_ex167);

}
Set(i_144, "spinOff", dir_153);
return default;
}
if (SEq(Get(i_144, "ext"), E_147)) {
{
foreach (V _k169 in ForInKeys(E_147)) {
k2_165 = _k169;
SetK(E_147, k2_165, ((V)(0D)));
}
}
Set(i_144, "ext", prev_149);
}
if (Lt(now_161, Add(((V)((2D * ToNum(turn_151)))), walkMs_152))) {
Set(i_144, "spinOff", ((V)((ToNum(dir_153) * (1D - ToNum(Call(EIO_14, V.Undef, ((V)((((ToNum(now_161) - ToNum(turn_151)) - ToNum(walkMs_152)) / ToNum(turn_151)))))))))));
return default;
}
if (SEqN(ph_150, 1D)) {
Set(i_144, "spinOff", ((V)(0D)));
Invoke(c_145, "play", ((V)("happy")));
ph_150 = ((V)(2D));
DeleteK(park_12, id_141);
}
return default;
}, 1, "", false));
return default;
}, 3, "parkStart", false)).Put("parkStep", Fn((V _self170, int _argc171, V id_177, V ms_178, V _a175, V _a176, V[] _rest172) => {
if (Truthy(GetK(park_12, id_177))) {
InvokeK(park_12, id_177, ms_178);
}
return default;
}, 2, "parkStep", false)).Put("pointer", Fn((V _self179, int _argc180, V id_186, V type_187, V x_188, V y_189, V[] _rest181) => {
V el_190 = default;
V w_191 = default;
el_190 = Call(hostEl_16, V.Undef, id_186);
if (!(Truthy(el_190))) {
return default;
}
Set(el_190, "__rect", NewObj(4).Put("left", ((V)(0D))).Put("top", ((V)(0D))).Put("width", ((V)(100D))).Put("height", ((V)(100D))).V);
w_191 = Get(el_190, "firstChild");
if (!(Truthy(w_191))) {
return default;
}
Invoke(w_191, "dispatchEvent", NewObj(6).Put("type", type_187).Put("clientX", x_188).Put("clientY", y_189).Put("pointerId", ((V)(1D))).Put("preventDefault", Fn((V _self192, int _argc193, V _a195, V _a196, V _a197, V _a198, V[] _rest194) => {

return default;
}, 0, "preventDefault", false)).Put("stopPropagation", Fn((V _self199, int _argc200, V _a202, V _a203, V _a204, V _a205, V[] _rest201) => {

return default;
}, 0, "stopPropagation", false)).V);
return default;
}, 4, "pointer", false)).Put("press", Fn((V _self206, int _argc207, V id_213, V _a210, V _a211, V _a212, V[] _rest208) => {
V i_214 = default;
i_214 = Call(I_18, V.Undef, id_213);
if (Truthy(i_214)) {
Set(i_214, "press", (true ? V.True : V.False));
Set(i_214, "pressT", Invoke(Get(G_8, "performance"), "now"));
}
return default;
}, 1, "press", false)).Put("light", Fn((V _self215, int _argc216, V id_222, V json_223, V _a220, V _a221, V[] _rest217) => {
V c_224 = default;
c_224 = GetK(ctl_9, id_222);
if (Truthy((c_224 is var _t225 && !Truthy(_t225) ? _t225 : Get(c_224, "light")))) {
Invoke(c_224, "light", (Truthy(json_223) ? Invoke(G("JSON"), "parse", json_223) : V.Null));
}
return default;
}, 2, "light", false)).Put("state", Fn((V _self226, int _argc227, V id_233, V _a230, V _a231, V _a232, V[] _rest228) => {
V i_234 = default;
i_234 = Call(I_18, V.Undef, id_233);
return (Truthy((i_234 is var _t235 && !Truthy(_t235) ? _t235 : Get(i_234, "cur"))) ? Get(Get(i_234, "cur"), "name") : V.Null);
return default;
}, 1, "state", false)).Put("spinOff", Fn((V _self236, int _argc237, V id_243, V deg_244, V _a241, V _a242, V[] _rest238) => {
V i_245 = default;
i_245 = Call(I_18, V.Undef, id_243);
if (Truthy(i_245)) {
Set(i_245, "spinOff", deg_244);
}
return default;
}, 2, "spinOff", false)).V);
return default;
}, 1, "", false), V.Undef, (!string.Equals(GTypeof("globalThis"), "undefined") ? G("globalThis") : GlobalV));
        }
    }
}
