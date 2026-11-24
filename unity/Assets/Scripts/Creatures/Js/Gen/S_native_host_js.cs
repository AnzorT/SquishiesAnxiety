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
Set(G_8, "__native", NewObj(13).Put("ctl", Fn((V _self65, int _argc66, V id_72, V _a69, V _a70, V _a71, V[] _rest67) => {
return (GetK(ctl_9, id_72) is var _t73 && Truthy(_t73) ? _t73 : V.Null);
return default;
}, 1, "ctl", false)).Put("host", Fn((V _self74, int _argc75, V id_81, V _a78, V _a79, V _a80, V[] _rest76) => {
return (GetK(els_13, id_81) is var _t82 && Truthy(_t82) ? _t82 : V.Null);
return default;
}, 1, "host", false)).Put("ext", Fn((V _self83, int _argc84, V id_90, V o_91, V _a88, V _a89, V[] _rest85) => {
V c_92 = default;
V h_93 = default;
V k_94 = default;
V k2_95 = default;
c_92 = GetK(ctl_9, id_90);
if (!(Truthy(c_92))) {
return default;
}
h_93 = GetK(ext_10, id_90);
if (!(Truthy(h_93))) {
h_93 = SetK(ext_10, id_90, NewObj(0).V);
if (Truthy(Get(c_92, "ext"))) {
Invoke(c_92, "ext", h_93);
}
}
{
foreach (V _k96 in ForInKeys(h_93)) {
k_94 = _k96;
SetK(h_93, k_94, ((V)(0D)));
}
}
{
foreach (V _k97 in ForInKeys(o_91)) {
k2_95 = _k97;
SetK(h_93, k2_95, GetK(o_91, k2_95));
}
}
return default;
}, 2, "ext", false)).Put("events", Fn((V _self98, int _argc99, V id_105, V _a102, V _a103, V _a104, V[] _rest100) => {
return Invoke(G("JSON"), "parse", Invoke(Get(G_8, "__live"), "events", id_105));
return default;
}, 1, "events", false)).Put("walkStep", Fn((V _self106, int _argc107, V id_113, V key_114, V w_115, V dt_116, V[] _rest108) => {
V i_118 = default;
V s_119 = default;
V k_120 = default;
V spin_117 = default;
spin_117 = (_argc107 > 4 ? _rest108[0] : V.Undef);
i_118 = Call(I_18, V.Undef, id_113);
if (!(Truthy(i_118))) {
return default;
}
s_119 = (GetK(walk_11, id_113) is var _t121 && Truthy(_t121) ? _t121 : SetK(walk_11, id_113, NewObj(2).Put("E", NewObj(0).V).Put("ws", NewObj(0).V).V));
if (!SEq(Get(i_118, "ext"), Get(s_119, "E"))) {
Set(i_118, "ext", Get(s_119, "E"));
}
{
foreach (V _k122 in ForInKeys(Get(s_119, "E"))) {
k_120 = _k122;
SetK(Get(s_119, "E"), k_120, ((V)(0D)));
}
}
if (Truthy(((GtN(w_115, 0D) ? V.True : V.False) is var _t123 && !Truthy(_t123) ? _t123 : Get(G_8, "HouseWalk")))) {
try {
Invoke(Get(G_8, "HouseWalk"), "step", key_114, Get(s_119, "ws"), Get(s_119, "E"), w_115, dt_116, ((V)(1D)), spin_117);
} catch (System.Exception _ex124) {
V e_125 = default;
e_125 = Caught(_ex124);

}
}
return default;
}, 5, "walkStep", false)).Put("emit", Fn((V _self126, int _argc127, V id_133, V kind_134, V at_135, V x_136, V[] _rest128) => {
V i_139 = default;
V p_140 = default;
V y_137 = default;
V n_138 = default;
y_137 = (_argc127 > 4 ? _rest128[0] : V.Undef);
n_138 = (_argc127 > 5 ? _rest128[1] : V.Undef);
i_139 = Call(I_18, V.Undef, id_133);
if ((!(Truthy(i_139)) || !(Truthy(Get(Get(G_8, "RiveRig"), "emit"))))) {
return default;
}
p_140 = (Truthy(at_135) ? ((Get(i_139, "W") is var _t141 && !Truthy(_t141) ? _t141 : GetK(Get(i_139, "W"), at_135)) is var _t142 && Truthy(_t142) ? _t142 : Arr(((V)(50D)), ((V)(50D)))) : Arr(x_136, y_137));
Invoke(Get(G_8, "RiveRig"), "emit", i_139, kind_134, p_140, (GtN(n_138, 0D) ? n_138 : ((V)(0D))));
return default;
}, 6, "emit", false)).Put("parkStart", Fn((V _self143, int _argc144, V id_150, V key_151, V enter_152, V _a149, V[] _rest145) => {
V i_153 = default;
V c_154 = default;
V HW_155 = default;
V E_156 = default;
V ws_157 = default;
V prev_158 = default;
V ph_159 = default;
V turn_160 = default;
V walkMs_161 = default;
V dir_162 = default;
i_153 = Call(I_18, V.Undef, id_150);
c_154 = GetK(ctl_9, id_150);
if (!(Truthy(i_153))) {
return default;
}
HW_155 = Get(G_8, "HouseWalk");
E_156 = NewObj(0).V;
ws_157 = NewObj(0).V;
prev_158 = Get(i_153, "ext");
ph_159 = ((V)(0D));
turn_160 = ((V)((Truthy(enter_152) ? 380D : 340D)));
walkMs_161 = ((V)((Truthy(enter_152) ? 2300D : 2100D)));
dir_162 = ((V)((Truthy(enter_152) ? (-90D) : 90D)));
SetK(park_12, id_150, Fn((V _self163, int _argc164, V now_170, V _a167, V _a168, V _a169, V[] _rest165) => {
V tt_171 = default;
V w_172 = default;
V k_173 = default;
V k2_174 = default;
if (SEqN(ph_159, 0D)) {
Invoke(c_154, "play", ((V)("idle")));
ph_159 = ((V)(1D));
}
if (Lt(now_170, turn_160)) {
Set(i_153, "spinOff", ((V)((ToNum(dir_162) * ToNum(Call(EIO_14, V.Undef, ((V)((ToNum(now_170) / ToNum(turn_160))))))))));
return default;
}
if (Lt(now_170, Add(turn_160, walkMs_161))) {
if (!SEq(Get(i_153, "ext"), E_156)) {
Set(i_153, "ext", E_156);
}
tt_171 = ((V)(((ToNum(now_170) - ToNum(turn_160)) / ToNum(walkMs_161))));
w_172 = ((V)(Min(1D, (ToNum(tt_171) / 0.08), ((1D - ToNum(tt_171)) / 0.1))));
{
foreach (V _k175 in ForInKeys(E_156)) {
k_173 = _k175;
SetK(E_156, k_173, ((V)(0D)));
}
}
try {
Invoke(HW_155, "step", key_151, ws_157, E_156, ((V)(Max(0D, ToNum(w_172)))), ((V)(0.016)), ((V)(1D)), dir_162);
} catch (System.Exception _ex176) {
V e_177 = default;
e_177 = Caught(_ex176);

}
Set(i_153, "spinOff", dir_162);
return default;
}
if (SEq(Get(i_153, "ext"), E_156)) {
{
foreach (V _k178 in ForInKeys(E_156)) {
k2_174 = _k178;
SetK(E_156, k2_174, ((V)(0D)));
}
}
Set(i_153, "ext", prev_158);
}
if (Lt(now_170, Add(((V)((2D * ToNum(turn_160)))), walkMs_161))) {
Set(i_153, "spinOff", ((V)((ToNum(dir_162) * (1D - ToNum(Call(EIO_14, V.Undef, ((V)((((ToNum(now_170) - ToNum(turn_160)) - ToNum(walkMs_161)) / ToNum(turn_160)))))))))));
return default;
}
if (SEqN(ph_159, 1D)) {
Set(i_153, "spinOff", ((V)(0D)));
Invoke(c_154, "play", ((V)("happy")));
ph_159 = ((V)(2D));
DeleteK(park_12, id_150);
}
return default;
}, 1, "", false));
return default;
}, 3, "parkStart", false)).Put("parkStep", Fn((V _self179, int _argc180, V id_186, V ms_187, V _a184, V _a185, V[] _rest181) => {
if (Truthy(GetK(park_12, id_186))) {
InvokeK(park_12, id_186, ms_187);
}
return default;
}, 2, "parkStep", false)).Put("pointer", Fn((V _self188, int _argc189, V id_195, V type_196, V x_197, V y_198, V[] _rest190) => {
V el_199 = default;
V w_200 = default;
el_199 = Call(hostEl_16, V.Undef, id_195);
if (!(Truthy(el_199))) {
return default;
}
Set(el_199, "__rect", NewObj(4).Put("left", ((V)(0D))).Put("top", ((V)(0D))).Put("width", ((V)(100D))).Put("height", ((V)(100D))).V);
w_200 = Get(el_199, "firstChild");
if (!(Truthy(w_200))) {
return default;
}
Invoke(w_200, "dispatchEvent", NewObj(6).Put("type", type_196).Put("clientX", x_197).Put("clientY", y_198).Put("pointerId", ((V)(1D))).Put("preventDefault", Fn((V _self201, int _argc202, V _a204, V _a205, V _a206, V _a207, V[] _rest203) => {

return default;
}, 0, "preventDefault", false)).Put("stopPropagation", Fn((V _self208, int _argc209, V _a211, V _a212, V _a213, V _a214, V[] _rest210) => {

return default;
}, 0, "stopPropagation", false)).V);
return default;
}, 4, "pointer", false)).Put("press", Fn((V _self215, int _argc216, V id_222, V _a219, V _a220, V _a221, V[] _rest217) => {
V i_223 = default;
i_223 = Call(I_18, V.Undef, id_222);
if (Truthy(i_223)) {
Set(i_223, "press", (true ? V.True : V.False));
Set(i_223, "pressT", Invoke(Get(G_8, "performance"), "now"));
}
return default;
}, 1, "press", false)).Put("light", Fn((V _self224, int _argc225, V id_231, V json_232, V _a229, V _a230, V[] _rest226) => {
V c_233 = default;
c_233 = GetK(ctl_9, id_231);
if (Truthy((c_233 is var _t234 && !Truthy(_t234) ? _t234 : Get(c_233, "light")))) {
Invoke(c_233, "light", (Truthy(json_232) ? Invoke(G("JSON"), "parse", json_232) : V.Null));
}
return default;
}, 2, "light", false)).Put("state", Fn((V _self235, int _argc236, V id_242, V _a239, V _a240, V _a241, V[] _rest237) => {
V i_243 = default;
i_243 = Call(I_18, V.Undef, id_242);
return (Truthy((i_243 is var _t244 && !Truthy(_t244) ? _t244 : Get(i_243, "cur"))) ? Get(Get(i_243, "cur"), "name") : V.Null);
return default;
}, 1, "state", false)).Put("spinOff", Fn((V _self245, int _argc246, V id_252, V deg_253, V _a250, V _a251, V[] _rest247) => {
V i_254 = default;
i_254 = Call(I_18, V.Undef, id_252);
if (Truthy(i_254)) {
Set(i_254, "spinOff", deg_253);
}
return default;
}, 2, "spinOff", false)).V);
return default;
}, 1, "", false), V.Undef, (!string.Equals(GTypeof("globalThis"), "undefined") ? G("globalThis") : GlobalV));
        }
    }
}
