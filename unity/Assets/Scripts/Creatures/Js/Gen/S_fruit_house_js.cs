// fruit-house.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_fruit_house_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V K_8 = default;
V walks_9 = default;
if (_self1.IsNullish) _self1 = GlobalV;
K_8 = Arr(((V)("nana")), ((V)("bing")), ((V)("plummy")), ((V)("clemmy")), ((V)("appy")), ((V)("blueby")), ((V)("coco")), ((V)("perry")), ((V)("grana")), ((V)("mangie")), ((V)("razzy")));
Invoke(Set(G("window"), "HouseCreatures", (Get(G("window"), "HouseCreatures") is var _t298 && Truthy(_t298) ? _t298 : Arr())), "push", Fn((V _self10, int _argc11, V H_17, V _a14, V _a15, V _a16, V[] _rest12) => {
V build_18 = default;
V bedBuild_19 = default;
V waterBuild_20 = default;
V playBuild_21 = default;
V bBuild_22 = default;
V o_23 = default;
V sp_24 = default;
V bk_25 = default;
V hop_26 = default;
V RL_27 = default;
V mk_28 = default;
V SIG_29 = default;
V SLEEPY_30 = default;
V NOLEG_31 = default;
V DR_32 = default;
V WK_33 = default;
V SW_34 = default;
V SN_35 = default;
V CHEER_36 = default;
V FC_37 = default;
V TBC_38 = default;
if (_self10.IsNullish) _self10 = GlobalV;
{ V _t39 = H_17;
if (_t39.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t39));
{ V _t40 = Get(_t39, "build");
build_18 = _t40; }
{ V _t41 = Get(_t39, "bedBuild");
bedBuild_19 = _t41; }
{ V _t42 = Get(_t39, "waterBuild");
waterBuild_20 = _t42; }
{ V _t43 = Get(_t39, "playBuild");
playBuild_21 = _t43; }
{ V _t44 = Get(_t39, "bBuild");
bBuild_22 = _t44; }
{ V _t45 = Get(_t39, "o");
o_23 = _t45; } }
sp_24 = Fn((V _self10, int _argc46, V t_52, V v_53, V d_54, V hold_55, V[] _rest47) => {
V b_56 = default;
b_56 = NewObj(0).V;
Invoke(Object_keys(v_53), "forEach", Fn((V _self10, int _argc57, V k_63, V _a60, V _a61, V _a62, V[] _rest58) => {
return SetK(b_56, k_63, (!GetK(Get(t_52, "B"), k_63).IsNullish ? GetK(Get(t_52, "B"), k_63) : ((V)(0D))));
}, 1, "", true));
Invoke(Invoke(Invoke(t_52, "to", ((V)((ToNum((d_54 is var _t66 && Truthy(_t66) ? _t66 : ((V)(700D)))) * 0.4))), v_53, ((V)("o"))), "wait", (hold_55 is var _t65 && Truthy(_t65) ? _t65 : ((V)(300D)))), "to", ((V)((ToNum((d_54 is var _t64 && Truthy(_t64) ? _t64 : ((V)(700D)))) * 0.6))), b_56, ((V)("io")));
return t_52;
return default;
}, 4, "", true);
bk_25 = Fn((V _self10, int _argc67, V t_73, V d_74, V _a71, V _a72, V[] _rest68) => {
return Invoke(t_73, "back", (d_74 is var _t75 && Truthy(_t75) ? _t75 : ((V)(420D))));
}, 2, "", true);
hop_26 = NewObj(2).Put("dn", ((V)("hop"))).Put("up", ((V)("hop"))).V;
RL_27 = NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V;
mk_28 = Fn((V _self10, int _argc76, V key_82, V @base_83, V P_84, V _a81, V[] _rest77) => {
return Call(build_18, V.Undef, key_82, Call(o_23, V.Undef, @base_83, P_84, NewObj(2).Put("pose", Call(o_23, V.Undef, (Get(@base_83, "pose") is var _t85 && Truthy(_t85) ? _t85 : NewObj(0).V), (Get(P_84, "pose") is var _t86 && Truthy(_t86) ? _t86 : NewObj(0).V))).Put("lpose", Call(o_23, V.Undef, (Get(@base_83, "lpose") is var _t87 && Truthy(_t87) ? _t87 : NewObj(0).V), RL_27, (Get(P_84, "lpose") is var _t88 && Truthy(_t88) ? _t88 : NewObj(0).V))).V));
}, 3, "", true);
SIG_29 = NewObj(11).Put("nana", Fn((V _self10, int _argc89, V t_95, V _a92, V _a93, V _a94, V[] _rest90) => {
Invoke(Invoke(t_95, "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("cv", ((V)(0.6))).V, NewObj(1).Put("cv", ((V)((-0.4)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("cv", ((V)(0D))).V);
return Call(bk_25, V.Undef, t_95);
return default;
}, 1, "nana", true)).Put("bing", Fn((V _self10, int _argc96, V t_102, V _a99, V _a100, V _a101, V[] _rest97) => {
Invoke(Invoke(Invoke(t_102, "to", ((V)(700D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(500D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
return Call(bk_25, V.Undef, t_102);
return default;
}, 1, "bing", true)).Put("plummy", Fn((V _self10, int _argc103, V t_109, V _a106, V _a107, V _a108, V[] _rest104) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_109, "to", ((V)(700D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(500D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("pol", ((V)(1D))).V, ((V)("io"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(1000D)), NewObj(1).Put("pol", ((V)(0D))).V, ((V)("io")));
return Call(bk_25, V.Undef, t_109);
return default;
}, 1, "plummy", true)).Put("clemmy", Fn((V _self10, int _argc110, V t_116, V _a113, V _a114, V _a115, V[] _rest111) => {
Invoke(Invoke(Invoke(Invoke(t_116, "to", ((V)(800D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("zest")), ((V)("head")), ((V)(3D)));
return Call(bk_25, V.Undef, t_116);
return default;
}, 1, "clemmy", true)).Put("appy", Fn((V _self10, int _argc117, V t_123, V _a120, V _a121, V _a122, V[] _rest118) => {
Invoke(Invoke(Invoke(t_123, "to", ((V)(200D)), NewObj(1).Put("lf", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("lf", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
return Call(bk_25, V.Undef, t_123);
return default;
}, 1, "appy", true)).Put("blueby", Fn((V _self10, int _argc124, V t_130, V _a127, V _a128, V _a129, V[] _rest125) => {
Invoke(Invoke(t_130, "osc", ((V)(1200D)), ((V)(2D)), NewObj(2).Put("rl", ((V)(16D))).Put("x", Add((Get(Get(t_130, "B"), "x") is var _t132 && Truthy(_t132) ? _t132 : ((V)(0D))), ((V)(2D)))).V, NewObj(2).Put("rl", ((V)((-16D)))).Put("x", ((V)((ToNum((Get(Get(t_130, "B"), "x") is var _t133 && Truthy(_t133) ? _t133 : ((V)(0D)))) - 2D)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", (Get(Get(t_130, "B"), "x") is var _t131 && Truthy(_t131) ? _t131 : ((V)(0D)))).V, ((V)("io")));
return Call(bk_25, V.Undef, t_130);
return default;
}, 1, "blueby", true)).Put("coco", Fn((V _self10, int _argc134, V t_140, V _a137, V _a138, V _a139, V[] _rest135) => {
Invoke(Invoke(Invoke(t_140, "to", ((V)(150D)), NewObj(1).Put("fz", ((V)(0.9))).V, ((V)("o"))), "fx", ((V)("knock")), ((V)("head")), ((V)(1D))), "to", ((V)(500D)), NewObj(1).Put("fz", ((V)(0D))).V, ((V)("io")));
return Call(bk_25, V.Undef, t_140);
return default;
}, 1, "coco", true)).Put("perry", Fn((V _self10, int _argc141, V t_147, V _a144, V _a145, V _a146, V[] _rest142) => {
Invoke(Invoke(Invoke(Invoke(t_147, "to", ((V)(300D)), NewObj(1).Put("tilt", Add((Get(Get(t_147, "B"), "tilt") is var _t151 && Truthy(_t151) ? _t151 : ((V)(0D))), ((V)(8D)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("tilt", ((V)((ToNum((Get(Get(t_147, "B"), "tilt") is var _t150 && Truthy(_t150) ? _t150 : ((V)(0D)))) - 5D)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("tilt", Add((Get(Get(t_147, "B"), "tilt") is var _t149 && Truthy(_t149) ? _t149 : ((V)(0D))), ((V)(2D)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("tilt", (Get(Get(t_147, "B"), "tilt") is var _t148 && Truthy(_t148) ? _t148 : ((V)(0D)))).V, ((V)("io")));
return Call(bk_25, V.Undef, t_147);
return default;
}, 1, "perry", true)).Put("grana", Fn((V _self10, int _argc152, V t_158, V _a155, V _a156, V _a157, V[] _rest153) => {
Invoke(Invoke(Invoke(Invoke(t_158, "to", ((V)(900D)), NewObj(2).Put("stw", ((V)(1D))).Put("crf", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(0D))).Put("crf", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("arils")), ((V)("head")), ((V)(3D)));
return Call(bk_25, V.Undef, t_158);
return default;
}, 1, "grana", true)).Put("mangie", Fn((V _self10, int _argc159, V t_165, V _a162, V _a163, V _a164, V[] _rest160) => {
return Call(sp_24, V.Undef, t_165, NewObj(4).Put("lf", ((V)(1D))).Put("close", ((V)(0.6))).Put("blush", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1200D)), ((V)(800D)));
}, 1, "mangie", true)).Put("razzy", Fn((V _self10, int _argc166, V t_172, V _a169, V _a170, V _a171, V[] _rest167) => {
Invoke(Invoke(Invoke(t_172, "to", ((V)(200D)), NewObj(1).Put("jig", ((V)(1.3))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(700D)), NewObj(1).Put("jig", ((V)(0D))).V, ((V)("io")));
return Call(bk_25, V.Undef, t_172);
return default;
}, 1, "razzy", true)).V;
SLEEPY_30 = NewObj(11).Put("nana", Fn((V _self10, int _argc173, V t_179, V _a176, V _a177, V _a178, V[] _rest174) => {
return Call(sp_24, V.Undef, t_179, NewObj(2).Put("cv", ((V)(0.8))).Put("close", ((V)(1D))).V, ((V)(1800D)), ((V)(1600D)));
}, 1, "nana", true)).Put("bing", Fn((V _self10, int _argc180, V t_186, V _a183, V _a184, V _a185, V[] _rest181) => {
return Call(sp_24, V.Undef, t_186, NewObj(2).Put("lf", ((V)(0.4))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "bing", true)).Put("plummy", Fn((V _self10, int _argc187, V t_193, V _a190, V _a191, V _a192, V[] _rest188) => {
return Call(sp_24, V.Undef, t_193, NewObj(2).Put("lf", ((V)(0.4))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "plummy", true)).Put("clemmy", Fn((V _self10, int _argc194, V t_200, V _a197, V _a198, V _a199, V[] _rest195) => {
return Call(sp_24, V.Undef, t_200, NewObj(2).Put("lf", ((V)(0.4))).Put("close", ((V)(0.9))).V, ((V)(1400D)), ((V)(1200D)));
}, 1, "clemmy", true)).Put("appy", Fn((V _self10, int _argc201, V t_207, V _a204, V _a205, V _a206, V[] _rest202) => {
return Call(sp_24, V.Undef, t_207, NewObj(2).Put("lf", ((V)(0.3))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "appy", true)).Put("blueby", Fn((V _self10, int _argc208, V t_214, V _a211, V _a212, V _a213, V[] _rest209) => {
return Call(sp_24, V.Undef, t_214, NewObj(2).Put("rl", ((V)(12D))).Put("close", ((V)(1D))).V, ((V)(1800D)), ((V)(1600D)));
}, 1, "blueby", true)).Put("coco", Fn((V _self10, int _argc215, V t_221, V _a218, V _a219, V _a220, V[] _rest216) => {
return Call(sp_24, V.Undef, t_221, NewObj(2).Put("fz", ((V)(0.3))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D)));
}, 1, "coco", true)).Put("perry", Fn((V _self10, int _argc222, V t_228, V _a225, V _a226, V _a227, V[] _rest223) => {
return Call(sp_24, V.Undef, t_228, NewObj(2).Put("tilt", ((V)(6D))).Put("close", ((V)(1D))).V, ((V)(1800D)), ((V)(1600D)));
}, 1, "perry", true)).Put("grana", Fn((V _self10, int _argc229, V t_235, V _a232, V _a233, V _a234, V[] _rest230) => {
return Call(sp_24, V.Undef, t_235, NewObj(2).Put("crf", ((V)((-0.3)))).Put("close", ((V)(0.9))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "grana", true)).Put("mangie", Fn((V _self10, int _argc236, V t_242, V _a239, V _a240, V _a241, V[] _rest237) => {
return Call(sp_24, V.Undef, t_242, NewObj(3).Put("lf", ((V)(0.5))).Put("close", ((V)(1D))).Put("blush", ((V)(0.4))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "mangie", true)).Put("razzy", Fn((V _self10, int _argc243, V t_249, V _a246, V _a247, V _a248, V[] _rest244) => {
return Call(sp_24, V.Undef, t_249, NewObj(2).Put("jig", ((V)(0.3))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "razzy", true)).V;
Call(mk_28, V.Undef, ((V)("nana")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "nana"), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), Get(SLEEPY_30, "nana"), ((V)("doze")), ((V)("stretch")))).V);
Call(mk_28, V.Undef, ((V)("bing")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "bing"), ((V)("swing")), ((V)("kick")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "bing"), ((V)("belly")))).V);
NOLEG_31 = NewObj(2).Put("perry", ((V)(1D))).Put("coco", ((V)(1D))).V;
Call(mk_28, V.Undef, ((V)("plummy")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "plummy"), ((V)("swing")), ((V)("kick")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "plummy"), ((V)("stretch")))).V);
Call(mk_28, V.Undef, ((V)("clemmy")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "clemmy"), ((V)("kick")), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "clemmy"), ((V)("stretch")))).V);
Call(mk_28, V.Undef, ((V)("appy")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "appy"), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "appy"), ((V)("stretch")))).V);
Call(mk_28, V.Undef, ((V)("blueby")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "blueby"), ((V)("swing")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "blueby"), ((V)("belly")))).V);
Call(mk_28, V.Undef, ((V)("coco")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "coco"), ((V)("pat")), Fn((V _self10, int _argc250, V t_256, V _a253, V _a254, V _a255, V[] _rest251) => {
Invoke(Invoke(Invoke(t_256, "to", ((V)(500D)), NewObj(2).Put("rl", ((V)(18D))).Put("x", Add((Get(Get(t_256, "B"), "x") is var _t259 && Truthy(_t259) ? _t259 : ((V)(0D))), ((V)(2D)))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(2).Put("rl", ((V)((-10D)))).Put("x", ((V)((ToNum((Get(Get(t_256, "B"), "x") is var _t258 && Truthy(_t258) ? _t258 : ((V)(0D)))) - 1D)))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", (Get(Get(t_256, "B"), "x") is var _t257 && Truthy(_t257) ? _t257 : ((V)(0D)))).V, ((V)("io")));
return Call(bk_25, V.Undef, t_256);
return default;
}, 1, "", true))).Put("lf", Arr(((V)("sigh")), Get(SLEEPY_30, "coco"), ((V)("doze")), ((V)("belly")))).V);
Call(mk_28, V.Undef, ((V)("perry")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "perry"), ((V)("hum")), ((V)("pat")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "perry"), ((V)("belly")))).V);
Call(mk_28, V.Undef, ((V)("grana")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "grana"), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "grana"), ((V)("stretch")))).V);
Call(mk_28, V.Undef, ((V)("mangie")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "mangie"), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), Get(SLEEPY_30, "mangie"), ((V)("doze")), ((V)("stretch")))).V);
Call(mk_28, V.Undef, ((V)("razzy")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "razzy"), ((V)("swing")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "razzy"), ((V)("belly")))).V);
DR_32 = NewObj(11).Put("nana", ((V)("sun"))).Put("bing", ((V)("cherry"))).Put("plummy", ((V)("star"))).Put("clemmy", ((V)("sun"))).Put("appy", ((V)("apple"))).Put("blueby", ((V)("berry"))).Put("coco", ((V)("shell"))).Put("perry", ((V)("leaf"))).Put("grana", ((V)("crown"))).Put("mangie", ((V)("sun"))).Put("razzy", ((V)("star"))).V;
WK_33 = NewObj(11).Put("nana", NewObj(1).Put("cv", ((V)((-0.8)))).V).Put("bing", NewObj(2).Put("stw", ((V)(0.6))).Put("lf", ((V)(1D))).V).Put("plummy", NewObj(2).Put("lf", ((V)(1D))).Put("stw", ((V)(0.4))).V).Put("clemmy", NewObj(1).Put("lf", ((V)(1D))).V).Put("appy", NewObj(1).Put("lf", ((V)(1D))).V).Put("blueby", NewObj(1).Put("crf", ((V)(0.8))).V).Put("coco", NewObj(1).Put("fz", ((V)(1D))).V).Put("perry", NewObj(1).Put("lf", ((V)(1D))).V).Put("grana", NewObj(1).Put("crf", ((V)(1D))).V).Put("mangie", NewObj(1).Put("lf", ((V)(1D))).V).Put("razzy", NewObj(1).Put("jig", ((V)(1D))).V).V;
Invoke(K_8, "forEach", Fn((V _self10, int _argc260, V k_266, V _a263, V _a264, V _a265, V[] _rest261) => {
return Call(bedBuild_19, V.Undef, k_266, NewObj(3).Put("dr", GetK(DR_32, k_266)).Put("wk", GetK(WK_33, k_266)).Put("s", GetK(SLEEPY_30, k_266)).V);
}, 1, "", true));
SW_34 = NewObj(11).Put("nana", ((V)("float"))).Put("bing", ((V)("bob"))).Put("plummy", ((V)("bob"))).Put("clemmy", ((V)("bob"))).Put("appy", ((V)("bob"))).Put("blueby", ((V)("bob"))).Put("coco", ((V)("float"))).Put("perry", ((V)("bob"))).Put("grana", ((V)("bob"))).Put("mangie", ((V)("float"))).Put("razzy", ((V)("bob"))).V;
Invoke(K_8, "forEach", Fn((V _self10, int _argc267, V k_273, V _a270, V _a271, V _a272, V[] _rest268) => {
return Call(waterBuild_20, V.Undef, k_273, NewObj(3).Put("sw", GetK(SW_34, k_273)).Put("k", NewObj(3).Put("a", GetK(WK_33, k_273)).Put("b", NewObj(0).V).Put("f", GetK(WK_33, k_273)).V).Put("s", GetK(SIG_29, k_273)).V);
}, 1, "", true));
SN_35 = NewObj(11).Put("nana", ((V)("honey"))).Put("bing", ((V)("cherry"))).Put("plummy", ((V)("candy"))).Put("clemmy", ((V)("drop"))).Put("appy", ((V)("apple"))).Put("blueby", ((V)("berry"))).Put("coco", ((V)("cup"))).Put("perry", ((V)("honey"))).Put("grana", ((V)("cake"))).Put("mangie", ((V)("drop"))).Put("razzy", ((V)("candy"))).V;
CHEER_36 = NewObj(11).Put("nana", NewObj(1).Put("cheer", NewObj(1).Put("cv", ((V)((-0.8)))).V).V).Put("bing", NewObj(1).Put("cheer", NewObj(2).Put("lf", ((V)(1D))).Put("stw", ((V)(0.6))).V).V).Put("plummy", NewObj(2).Put("cheer", NewObj(2).Put("lf", ((V)(1D))).Put("stw", ((V)(0.6))).V).Put("cheerFx", Arr(((V)("pljuice")), ((V)("head")))).V).Put("clemmy", NewObj(2).Put("cheer", NewObj(1).Put("lf", ((V)(1D))).V).Put("cheerFx", Arr(((V)("zest")), ((V)("head")))).V).Put("appy", NewObj(2).Put("cheer", NewObj(1).Put("lf", ((V)(1D))).V).Put("cheerFx", Arr(((V)("spark")), ((V)("head")))).V).Put("blueby", NewObj(1).Put("cheer", NewObj(1).Put("crf", ((V)(1D))).V).V).Put("coco", NewObj(2).Put("cheer", NewObj(1).Put("fz", ((V)(1D))).V).Put("cheerFx", Arr(((V)("knock")), ((V)("head")))).V).Put("perry", NewObj(1).Put("cheer", NewObj(1).Put("lf", ((V)(1D))).V).V).Put("grana", NewObj(2).Put("cheer", NewObj(1).Put("crf", ((V)(1D))).V).Put("cheerFx", Arr(((V)("arils")), ((V)("head")))).V).Put("mangie", NewObj(2).Put("cheer", NewObj(1).Put("lf", ((V)(1D))).V).Put("cheerFx", Arr(((V)("mjuice")), ((V)("head")))).V).Put("razzy", NewObj(2).Put("cheer", NewObj(1).Put("jig", ((V)(1.3))).V).Put("cheerFx", Arr(((V)("spark")), ((V)("head")))).V).V;
Invoke(K_8, "forEach", Fn((V _self10, int _argc274, V k_280, V _a277, V _a278, V _a279, V[] _rest275) => {
return Call(playBuild_21, V.Undef, k_280, Call(o_23, V.Undef, GetK(CHEER_36, k_280), NewObj(3).Put("sn", GetK(SN_35, k_280)).Put("p", GetK(SIG_29, k_280)).Put("sp", NewObj(6).Put("armL", ((V)(42D))).Put("armR", ((V)(42D))).Put("hLy", ((V)((-7D)))).Put("hRy", ((V)((-7D)))).Put("hLx", ((V)(1D))).Put("hRx", ((V)((-1D)))).V).V, (Truthy(GetK(NOLEG_31, k_280)) ? NewObj(1).Put("swingOrd", Arr(((V)("wheee")), ((V)("peek")), ((V)("sig")), ((V)("breeze")), ((V)("onehand")), ((V)("higher")), ((V)("giggle")))).V : NewObj(0).V)));
}, 1, "", true));
FC_37 = NewObj(11).Put("nana", ((V)("leaf"))).Put("bing", ((V)("cherry"))).Put("plummy", ((V)("star"))).Put("clemmy", ((V)("leaf"))).Put("appy", ((V)("apple"))).Put("blueby", ((V)("pearl"))).Put("coco", ((V)("shell"))).Put("perry", ((V)("leaf"))).Put("grana", ((V)("crown"))).Put("mangie", ((V)("flower"))).Put("razzy", ((V)("star"))).V;
TBC_38 = Arr(((V)("#5fb8e8")), ((V)("#7cc35a")), ((V)("#ff8fa8")), ((V)("#ffcc3a")), ((V)("#b98ae8")), ((V)("#ff8a4a")));
Invoke(K_8, "forEach", Fn((V _self10, int _argc281, V k_287, V i_288, V _a285, V _a286, V[] _rest282) => {
return Call(bBuild_22, V.Undef, k_287, Call(o_23, V.Undef, GetK(CHEER_36, k_287), NewObj(4).Put("fc", GetK(FC_37, k_287)).Put("tk", Call(o_23, V.Undef, GetK(WK_33, k_287))).Put("tb", GetIdx(TBC_38, (ToNum(i_288) % ToNum(Get(TBC_38, "length"))))).Put("sn", GetK(SN_35, k_287)).V));
}, 2, "", true));
if (Truthy(Get(H_17, "cBuild"))) {
Invoke(K_8, "forEach", Fn((V _self10, int _argc289, V k_295, V _a292, V _a293, V _a294, V[] _rest290) => {
return Invoke(H_17, "cBuild", k_295, NewObj(4).Put("ks", ((V)((Truthy(((SEqS(k_295, "blueby") ? V.True : V.False) is var _t296 && Truthy(_t296) ? _t296 : GetK(NOLEG_31, k_295))) ? "body" : "foot")))).Put("pc", ((V)("#7cc35a"))).Put("hc", ((V)("#7cc35a"))).Put("mc", ((V)("#3b3b4a"))).V);
}, 1, "", true));
}
Set(G("window"), "HouseWalkRUN", Object_assign((Get(G("window"), "HouseWalkRUN") is var _t297 && Truthy(_t297) ? _t297 : NewObj(0).V), NewObj(5).Put("plummy", NewObj(1).Put("lf", ((V)(0.6))).V).Put("razzy", NewObj(1).Put("jig", ((V)(0.6))).V).Put("bing", NewObj(1).Put("lf", ((V)(0.6))).V).Put("clemmy", NewObj(1).Put("lf", ((V)(0.6))).V).Put("nana", NewObj(1).Put("cv", ((V)(0.3))).V).V));
return default;
}, 1, "", false));
walks_9 = Fn((V _self1, int _argc299, V W_305, V _a302, V _a303, V _a304, V[] _rest300) => {
V d_306 = default;
d_306 = Fn((V _self1, int _argc307, V k_313, V P_314, V _a311, V _a312, V[] _rest308) => {
return Invoke(W_305, "def", k_313, P_314);
}, 2, "", true);
Call(d_306, V.Undef, ((V)("nana")), NewObj(3).Put("g", ((V)("waddle"))).Put("a", ((V)(0.85))).Put("x", NewObj(1).Put("cv", Arr(((V)(0.35)), ((V)(1D)), ((V)(0D)), ((V)(0D)))).V).V);
Call(d_306, V.Undef, ((V)("bing")), NewObj(3).Put("g", ((V)("bounce"))).Put("a", ((V)(0.9))).Put("x", NewObj(1).Put("lf", Arr(((V)(0.5)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_306, V.Undef, ((V)("plummy")), NewObj(3).Put("g", ((V)("prance"))).Put("a", ((V)(0.85))).Put("x", NewObj(1).Put("lf", Arr(((V)(0.5)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_306, V.Undef, ((V)("clemmy")), NewObj(3).Put("g", ((V)("bounce"))).Put("a", ((V)(0.95))).Put("x", NewObj(1).Put("lf", Arr(((V)(0.4)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_306, V.Undef, ((V)("appy")), NewObj(3).Put("g", ((V)("shuffle"))).Put("a", ((V)(0.85))).Put("x", NewObj(1).Put("lf", Arr(((V)(0.3)), ((V)(1D)), ((V)(0D)), ((V)(0D)))).V).V);
Call(d_306, V.Undef, ((V)("blueby")), NewObj(2).Put("g", ((V)("eggroll"))).Put("a", ((V)(0.8))).V);
Call(d_306, V.Undef, ((V)("coco")), NewObj(2).Put("g", ((V)("eggroll"))).Put("a", ((V)(0.8))).V);
Call(d_306, V.Undef, ((V)("perry")), NewObj(3).Put("g", ((V)("roll"))).Put("a", ((V)(0.9))).Put("x", NewObj(1).Put("lf", Arr(((V)(0.3)), ((V)(1D)), ((V)(0D)), ((V)(0D)))).V).V);
Call(d_306, V.Undef, ((V)("grana")), NewObj(2).Put("g", ((V)("prance"))).Put("a", ((V)(0.75))).V);
Call(d_306, V.Undef, ((V)("mangie")), NewObj(3).Put("g", ((V)("prance"))).Put("a", ((V)(0.9))).Put("x", NewObj(1).Put("lf", Arr(((V)(0.4)), ((V)(1D)), ((V)(0D)), ((V)(0D)))).V).V);
Call(d_306, V.Undef, ((V)("razzy")), NewObj(3).Put("g", ((V)("bounce"))).Put("a", ((V)(0.9))).Put("x", NewObj(1).Put("jig", Arr(((V)(0.6)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Set(Get(W_305, "G"), "eggroll", (Get(Get(W_305, "G"), "eggroll") is var _t325 && Truthy(_t325) ? _t325 : NewObj(3).Put("r", ((V)(0.9))).Put("dl", ((V)(0D))).Put("f", Fn((V _self315, int _argc316, V p_322, V A_323, V o_324, V _a321, V[] _rest317) => {
if (_self315.IsNullish) _self315 = GlobalV;
Set(o_324, "armL", ((V)((24D + ((7D * ToNum(A_323)) * FdLibm.Sin(ToNum(p_322)))))));
Set(o_324, "armR", ((V)((24D - ((7D * ToNum(A_323)) * FdLibm.Sin(ToNum(p_322)))))));
Set(o_324, "sq", ((V)(((0.02 * ToNum(A_323)) * FdLibm.Sin((2D * ToNum(p_322)))))));
return default;
}, 3, "f", false)).V));
if (!(Truthy(Get(W_305, "__frRoll")))) {
V st0_326 = default;
Set(W_305, "__frRoll", ((V)(1D)));
st0_326 = Get(W_305, "step");
Set(W_305, "step", Fn((V _self327, int _argc328, V key_334, V st_335, V E_336, V w_337, V[] _rest329) => {
V r_342 = default;
double dir_343 = 0;
V mv_344 = default;
V dt_338 = default;
V spd_339 = default;
V spin_340 = default;
if (_self327.IsNullish) _self327 = GlobalV;
dt_338 = (_argc328 > 4 ? _rest329[0] : V.Undef);
spd_339 = (_argc328 > 5 ? _rest329[1] : V.Undef);
spin_340 = (_argc328 > 6 ? _rest329[2] : V.Undef);
V _arguments341 = Arguments(_argc328, key_334, st_335, E_336, w_337, _rest329);
r_342 = Invoke(st0_326, "apply", _self327, _arguments341);
if ((!SEqS(key_334, "blueby") && !SEqS(key_334, "coco"))) {
return r_342;
}
dir_343 = FdLibm.Sin(((ToNum((spin_340 is var _t345 && Truthy(_t345) ? _t345 : ((V)(0D)))) * System.Math.PI) / 180D));
mv_344 = ((GtN((spd_339 is var _t346 && Truthy(_t346) ? _t346 : ((V)(0D))), 0D) && GtN(w_337, 0.3)) ? V.True : V.False);
Set(st_335, "ra", (Get(st_335, "ra") is var _t347 && Truthy(_t347) ? _t347 : ((V)(0D))));
Set(st_335, "rv", (Get(st_335, "rv") is var _t348 && Truthy(_t348) ? _t348 : ((V)(0D))));
if (Truthy(mv_344)) {
double tv_349 = 0;
tv_349 = (((300D * ToNum(spd_339)) * (Truthy(Get(st_335, "run")) ? 1.6 : 1D)) * ((System.Math.Abs(dir_343) < 0.3) ? ((dir_343 < 0D) ? (-0.3) : 0.3) : dir_343));
OpSet(st_335, "rv", 0, ((V)(((tv_349 - ToNum(Get(st_335, "rv"))) * Min(1D, (ToNum(dt_338) * 6D))))));
OpSet(st_335, "ra", 0, ((V)((ToNum(Get(st_335, "rv")) * ToNum(dt_338)))));
} else {
double tg_350 = 0;
tg_350 = (Round((ToNum(Get(st_335, "ra")) / 360D)) * 360D);
OpSet(st_335, "rv", 0, ((V)(((((tg_350 - ToNum(Get(st_335, "ra"))) * 60D) - (ToNum(Get(st_335, "rv")) * 7D)) * Min(ToNum(dt_338), 0.05)))));
OpSet(st_335, "ra", 0, ((V)((ToNum(Get(st_335, "rv")) * Min(ToNum(dt_338), 0.05)))));
if (((System.Math.Abs((tg_350 - ToNum(Get(st_335, "ra")))) < 0.3) && (System.Math.Abs(ToNum(Get(st_335, "rv"))) < 2D))) {
Set(st_335, "ra", ((V)(0D)));
Set(st_335, "rv", ((V)(0D)));
}
}
Set(E_336, "rl", ((V)((ToNum(Add((Get(E_336, "rl") is var _t351 && Truthy(_t351) ? _t351 : ((V)(0D))), ((V)((((ToNum(Get(st_335, "ra")) % 360D) + 540D) % 360D))))) - 180D))));
return r_342;
return default;
}, 7, "", false));
}
return default;
}, 1, "", true);
if (Truthy(Get(G("window"), "HouseWalk"))) {
Call(walks_9, V.Undef, Get(G("window"), "HouseWalk"));
} else {
Invoke(Set(G("window"), "HouseWalkC", (Get(G("window"), "HouseWalkC") is var _t352 && Truthy(_t352) ? _t352 : Arr())), "push", walks_9);
}
Invoke(Set(G("window"), "HouseIdleC", (Get(G("window"), "HouseIdleC") is var _t483 && Truthy(_t483) ? _t483 : Arr())), "push", Fn((V _self353, int _argc354, V W_360, V _a357, V _a358, V _a359, V[] _rest355) => {
V sp_361 = default;
V d_362 = default;
if (_self353.IsNullish) _self353 = GlobalV;
sp_361 = Get(W_360, "sp");
d_362 = Fn((V _self353, int _argc363, V k_369, V L_370, V _a367, V _a368, V[] _rest364) => {
return Invoke(W_360, "build", k_369, L_370);
}, 2, "", true);
Call(d_362, V.Undef, ((V)("nana")), Arr(Fn((V _self353, int _argc371, V t_377, V _a374, V _a375, V _a376, V[] _rest372) => {
Invoke(Invoke(t_377, "osc", ((V)(1400D)), ((V)(3D)), NewObj(2).Put("cv", ((V)(0.6))).Put("x", ((V)(1D))).V, NewObj(2).Put("cv", ((V)((-0.4)))).Put("x", ((V)((-1D)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("cv", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), Fn((V _self353, int _argc378, V t_384, V _a381, V _a382, V _a383, V[] _rest379) => {
return Call(sp_361, V.Undef, t_384, NewObj(4).Put("cv", ((V)((-0.9)))).Put("lift", ((V)(2D))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).V, ((V)(1400D)), ((V)(500D)));
}, 1, "", true), ((V)("hum"))));
Call(d_362, V.Undef, ((V)("bing")), Arr(Fn((V _self353, int _argc385, V t_391, V _a388, V _a389, V _a390, V[] _rest386) => {
Invoke(Invoke(Invoke(t_391, "to", ((V)(700D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(500D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), ((V)("bounce")), ((V)("giggle"))));
Call(d_362, V.Undef, ((V)("plummy")), Arr(Fn((V _self353, int _argc392, V t_398, V _a395, V _a396, V _a397, V[] _rest393) => {
Invoke(Invoke(Invoke(Invoke(t_398, "to", ((V)(260D)), NewObj(4).Put("lift", ((V)(1.5))).Put("sq", ((V)((-0.04)))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).V, ((V)("io"))), "to", ((V)(800D)), NewObj(2).Put("spin", ((V)(360D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "to", ((V)(260D)), NewObj(5).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), Fn((V _self353, int _argc399, V t_405, V _a402, V _a403, V _a404, V[] _rest400) => {
Invoke(Invoke(Invoke(Invoke(t_405, "to", ((V)(320D)), NewObj(1).Put("pol", ((V)(1D))).V, ((V)("io"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D))), "wait", ((V)(400D))), "to", ((V)(1200D)), NewObj(1).Put("pol", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), ((V)("curtsy"))));
Call(d_362, V.Undef, ((V)("clemmy")), Arr(Fn((V _self353, int _argc406, V t_412, V _a409, V _a410, V _a411, V[] _rest407) => {
Invoke(Invoke(Invoke(Invoke(t_412, "to", ((V)(800D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("zest")), ((V)("head")), ((V)(3D)));
return default;
}, 1, "", true), Arr(((V)("twirl")), ((V)(1D))), ((V)("bounce"))));
Call(d_362, V.Undef, ((V)("appy")), Arr(Fn((V _self353, int _argc413, V t_419, V _a416, V _a417, V _a418, V[] _rest414) => {
Invoke(Invoke(Invoke(t_419, "to", ((V)(200D)), NewObj(1).Put("lf", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("lf", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
return default;
}, 1, "", true), ((V)("clap")), ((V)("hum"))));
Call(d_362, V.Undef, ((V)("blueby")), Arr(Fn((V _self353, int _argc420, V t_426, V _a423, V _a424, V _a425, V[] _rest421) => {
Invoke(Invoke(t_426, "osc", ((V)(1400D)), ((V)(3D)), NewObj(2).Put("rl", ((V)(16D))).Put("x", ((V)(3D))).V, NewObj(2).Put("rl", ((V)((-16D)))).Put("x", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), Fn((V _self353, int _argc427, V t_433, V _a430, V _a431, V _a432, V[] _rest428) => {
Invoke(Invoke(Invoke(t_433, "to", ((V)(600D)), NewObj(2).Put("stw", ((V)(1D))).Put("crf", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(0D))).Put("crf", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), ((V)("curtsy"))));
Call(d_362, V.Undef, ((V)("coco")), Arr(Fn((V _self353, int _argc434, V t_440, V _a437, V _a438, V _a439, V[] _rest435) => {
Invoke(Invoke(Invoke(t_440, "to", ((V)(150D)), NewObj(1).Put("fz", ((V)(0.9))).V, ((V)("o"))), "fx", ((V)("knock")), ((V)("head")), ((V)(1D))), "to", ((V)(500D)), NewObj(1).Put("fz", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), Fn((V _self353, int _argc441, V t_447, V _a444, V _a445, V _a446, V[] _rest442) => {
Invoke(Invoke(Invoke(Invoke(t_447, "to", ((V)(700D)), NewObj(2).Put("rl", ((V)(360D))).Put("x", ((V)(6D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "to", ((V)(700D)), NewObj(2).Put("rl", ((V)((-360D)))).Put("x", ((V)(0D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l")));
return default;
}, 1, "", true), ((V)("nod"))));
Call(d_362, V.Undef, ((V)("perry")), Arr(Fn((V _self353, int _argc448, V t_454, V _a451, V _a452, V _a453, V[] _rest449) => {
Invoke(Invoke(Invoke(Invoke(t_454, "to", ((V)(400D)), NewObj(1).Put("tilt", ((V)(10D))).V, ((V)("o"))), "to", ((V)(380D)), NewObj(1).Put("tilt", ((V)((-6D)))).V, ((V)("io"))), "to", ((V)(360D)), NewObj(1).Put("tilt", ((V)(3D))).V, ((V)("io"))), "to", ((V)(340D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), Fn((V _self353, int _argc455, V t_461, V _a458, V _a459, V _a460, V[] _rest456) => {
Invoke(Invoke(t_461, "osc", ((V)(1600D)), ((V)(4D)), NewObj(2).Put("tilt", ((V)(6D))).Put("turn", ((V)(0.12))).V, NewObj(2).Put("tilt", ((V)((-6D)))).Put("turn", ((V)((-0.12)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("tilt", ((V)(0D))).Put("turn", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), ((V)("hum"))));
Call(d_362, V.Undef, ((V)("grana")), Arr(Fn((V _self353, int _argc462, V t_468, V _a465, V _a466, V _a467, V[] _rest463) => {
Invoke(Invoke(Invoke(Invoke(t_468, "to", ((V)(900D)), NewObj(2).Put("stw", ((V)(1D))).Put("crf", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(0D))).Put("crf", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("arils")), ((V)("head")), ((V)(3D)));
return default;
}, 1, "", true), ((V)("bow")), ((V)("nod"))));
Call(d_362, V.Undef, ((V)("mangie")), Arr(Fn((V _self353, int _argc469, V t_475, V _a472, V _a473, V _a474, V[] _rest470) => {
return Call(sp_361, V.Undef, t_475, NewObj(4).Put("lf", ((V)(1D))).Put("close", ((V)(0.6))).Put("blush", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1200D)), ((V)(800D)));
}, 1, "", true), Arr(((V)("twirl")), ((V)(1D))), ((V)("curtsy"))));
Call(d_362, V.Undef, ((V)("razzy")), Arr(Fn((V _self353, int _argc476, V t_482, V _a479, V _a480, V _a481, V[] _rest477) => {
Invoke(Invoke(Invoke(t_482, "to", ((V)(200D)), NewObj(1).Put("jig", ((V)(1.3))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(700D)), NewObj(1).Put("jig", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), Arr(((V)("twirl")), ((V)(1D))), ((V)("giggle"))));
return default;
}, 1, "", false));
return default;
}, 0, "", false), V.Undef);
        }
    }
}
