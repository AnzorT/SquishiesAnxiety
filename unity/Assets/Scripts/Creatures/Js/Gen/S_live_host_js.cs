// live-host.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_live_host_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("^(hf\\d|idle_)", "");
        static readonly System.Text.RegularExpressions.Regex RX1 = JsRegExp.Compile("\\n", "g");
        static readonly System.Text.RegularExpressions.Regex RX2 = JsRegExp.Compile("href=\"shim-canvas:[^\"]*\"", "g");
        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V G_8, V _a5, V _a6, V _a7, V[] _rest3) => {
V hosts_9 = default;
V seq_10 = default;
V call_11 = default;
call_11 = Fn((V _self12, int _argc13, V f_19, V a_20, V _a17, V _a18, V[] _rest14) => {
return (string.Equals(Typeof(f_19), "function") ? Call(f_19, V.Undef, a_20) : Invoke(f_19, "Invoke", a_20));
return default;
}, 2, "call", false);
hosts_9 = NewObj(0).V;
seq_10 = ((V)(0D));
Set(G_8, "__live", NewObj(12).Put("install", Fn((V _self21, int _argc22, V readFile_28, V _a25, V _a26, V _a27, V[] _rest23) => {
Set(G_8, "__readFile", Fn((V _self29, int _argc30, V p_36, V _a33, V _a34, V _a35, V[] _rest31) => {
return Call(call_11, V.Undef, readFile_28, p_36);
return default;
}, 1, "", false));
Invoke(G("RigDomShim"), "install", G_8, NewObj(1).Put("readFile", Get(G_8, "__readFile")).V);
return default;
}, 1, "install", false)).Put("mount", Fn((V _self37, int _argc38, V key_44, V _a41, V _a42, V _a43, V[] _rest39) => {
V el_45 = default;
V id_46 = default;
V h_47 = default;
el_45 = Invoke(G("document"), "createElement", ((V)("div")));
Invoke(Get(G("document"), "body"), "appendChild", el_45);
id_46 = ((V)(PreInc(ref seq_10, 1D)));
h_47 = SetK(hosts_9, id_46, NewObj(2).Put("el", el_45).Put("ev", Arr()).V);
Set(h_47, "ctl", Invoke(G("RiveRig"), "mount", el_45, key_44, NewObj(1).Put("onState", Fn((V _self48, int _argc49, V n_55, V _a52, V _a53, V _a54, V[] _rest50) => {
Invoke(Get(h_47, "ev"), "push", n_55);
return default;
}, 1, "onState", false)).V));
return id_46;
return default;
}, 1, "mount", false)).Put("play", Fn((V _self56, int _argc57, V id_63, V move_64, V _a61, V _a62, V[] _rest58) => {
V h_65 = default;
h_65 = GetK(hosts_9, id_63);
if (Truthy(((h_65 is var _t66 && !Truthy(_t66) ? _t66 : Get(h_65, "ctl")) is var _t67 && !Truthy(_t67) ? _t67 : Get(Get(h_65, "ctl"), "play")))) {
Invoke(Get(h_65, "ctl"), "play", move_64);
}
return default;
}, 2, "play", false)).Put("ext", Fn((V _self68, int _argc69, V id_75, V json_76, V _a73, V _a74, V[] _rest70) => {
V h_77 = default;
V o_78 = default;
V k_79 = default;
V k2_80 = default;
h_77 = GetK(hosts_9, id_75);
if ((!(Truthy(h_77)) || !(Truthy(Get(h_77, "ctl"))))) {
return default;
}
if (!(Truthy(Get(h_77, "ext")))) {
Set(h_77, "ext", NewObj(0).V);
if (Truthy(Get(Get(h_77, "ctl"), "ext"))) {
Invoke(Get(h_77, "ctl"), "ext", Get(h_77, "ext"));
}
}
o_78 = Invoke(G("JSON"), "parse", json_76);
{
foreach (V _k81 in ForInKeys(Get(h_77, "ext"))) {
k_79 = _k81;
SetK(Get(h_77, "ext"), k_79, ((V)(0D)));
}
}
{
foreach (V _k82 in ForInKeys(o_78)) {
k2_80 = _k82;
SetK(Get(h_77, "ext"), k2_80, GetK(o_78, k2_80));
}
}
return default;
}, 2, "ext", false)).Put("events", Fn((V _self83, int _argc84, V id_90, V _a87, V _a88, V _a89, V[] _rest85) => {
V h_91 = default;
V e_92 = default;
h_91 = GetK(hosts_9, id_90);
if ((!(Truthy(h_91)) || !(Truthy(Get(Get(h_91, "ev"), "length"))))) {
return ((V)("[]"));
}
e_92 = Invoke(G("JSON"), "stringify", Get(h_91, "ev"));
Set(h_91, "ev", Arr());
return e_92;
return default;
}, 1, "events", false)).Put("yaw", Fn((V _self93, int _argc94, V id_100, V deg_101, V _a98, V _a99, V[] _rest95) => {
V h_102 = default;
V I_103 = default;
h_102 = GetK(hosts_9, id_100);
I_103 = ((h_102 is var _t104 && !Truthy(_t104) ? _t104 : Get(h_102, "ctl")) is var _t105 && !Truthy(_t105) ? _t105 : Get(Get(h_102, "ctl"), "_I"));
if (Truthy(I_103)) {
Set(I_103, "spinOff", deg_101);
}
return default;
}, 2, "yaw", false)).Put("fidgets", Fn((V _self106, int _argc107, V id_113, V on_114, V _a111, V _a112, V[] _rest108) => {
V h_115 = default;
V I_116 = default;
h_115 = GetK(hosts_9, id_113);
I_116 = ((h_115 is var _t117 && !Truthy(_t117) ? _t117 : Get(h_115, "ctl")) is var _t118 && !Truthy(_t118) ? _t118 : Get(Get(h_115, "ctl"), "_I"));
if (Truthy(I_116)) {
Set(I_116, "fidgets", (!(!(Truthy(on_114))) ? V.True : V.False));
Set(I_116, "hfid", ((V)(1D)));
}
return default;
}, 2, "fidgets", false)).Put("fidg", Fn((V _self119, int _argc120, V id_126, V _a123, V _a124, V _a125, V[] _rest121) => {
V h_127 = default;
V I_128 = default;
h_127 = GetK(hosts_9, id_126);
I_128 = ((h_127 is var _t129 && !Truthy(_t129) ? _t129 : Get(h_127, "ctl")) is var _t130 && !Truthy(_t130) ? _t130 : Get(Get(h_127, "ctl"), "_I"));
return (!(!(Truthy(((I_128 is var _t131 && !Truthy(_t131) ? _t131 : Get(I_128, "cur")) is var _t132 && !Truthy(_t132) ? _t132 : Invoke(NewRegExp(RX0, "^(hf\\d|idle_)", ""), "test", Get(Get(I_128, "cur"), "name")))))) ? V.True : V.False);
return default;
}, 1, "fidg", false)).Put("frame", Fn((V _self133, int _argc134, V ms_140, V _a137, V _a138, V _a139, V[] _rest135) => {
Invoke(Get(G_8, "__clock"), "frame", ms_140);
return default;
}, 1, "frame", false)).Put("now", Fn((V _self141, int _argc142, V _a144, V _a145, V _a146, V _a147, V[] _rest143) => {
return Get(Get(G_8, "__clock"), "now");
return default;
}, 0, "now", false)).Put("svg", Fn((V _self148, int _argc149, V id_155, V _a152, V _a153, V _a154, V[] _rest150) => {
V h_156 = default;
V s_157 = default;
h_156 = GetK(hosts_9, id_155);
s_157 = (h_156 is var _t158 && !Truthy(_t158) ? _t158 : Invoke(Get(h_156, "el"), "querySelector", ((V)("svg"))));
return (Truthy(s_157) ? Invoke(Invoke(Get(s_157, "outerHTML"), "replace", NewRegExp(RX2, "href=\"shim-canvas:[^\"]*\"", "g"), ((V)("href=\"grain\""))), "replace", NewRegExp(RX1, "\\n", "g"), ((V)(" "))) : V.Null);
return default;
}, 1, "svg", false)).Put("unmount", Fn((V _self159, int _argc160, V id_166, V _a163, V _a164, V _a165, V[] _rest161) => {
V h_167 = default;
h_167 = GetK(hosts_9, id_166);
if (!(Truthy(h_167))) {
return default;
}
try {
if (Truthy((Get(h_167, "ctl") is var _t168 && !Truthy(_t168) ? _t168 : Get(Get(h_167, "ctl"), "destroy")))) {
Invoke(Get(h_167, "ctl"), "destroy");
}
} catch (System.Exception _ex169) {
V e_170 = default;
e_170 = Caught(_ex169);

}
if (Truthy(Get(Get(h_167, "el"), "parentNode"))) {
Invoke(Get(Get(h_167, "el"), "parentNode"), "removeChild", Get(h_167, "el"));
}
DeleteK(hosts_9, id_166);
return default;
}, 1, "unmount", false)).V);
return default;
}, 1, "", false), V.Undef, (!string.Equals(GTypeof("globalThis"), "undefined") ? G("globalThis") : GlobalV));
        }
    }
}
