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
Invoke(Set(G("window"), "HouseCreatures", (Get(G("window"), "HouseCreatures") is var _t330 && Truthy(_t330) ? _t330 : Arr())), "push", Fn((V _self10, int _argc11, V H_17, V _a14, V _a15, V _a16, V[] _rest12) => {
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
sp_24 = Fn((V _arrowThis56, int _argc46, V t_52, V v_53, V d_54, V hold_55, V[] _rest47) => {
V b_57 = default;
b_57 = NewObj(0).V;
Invoke(Object_keys(v_53), "forEach", Fn((V _arrowThis65, int _argc58, V k_64, V _a61, V _a62, V _a63, V[] _rest59) => {
return SetK(b_57, k_64, (!GetK(Get(t_52, "B"), k_64).IsNullish ? GetK(Get(t_52, "B"), k_64) : ((V)(0D))));
}, 1, "", true));
Invoke(Invoke(Invoke(t_52, "to", ((V)((ToNum((d_54 is var _t68 && Truthy(_t68) ? _t68 : ((V)(700D)))) * 0.4))), v_53, ((V)("o"))), "wait", (hold_55 is var _t67 && Truthy(_t67) ? _t67 : ((V)(300D)))), "to", ((V)((ToNum((d_54 is var _t66 && Truthy(_t66) ? _t66 : ((V)(700D)))) * 0.6))), b_57, ((V)("io")));
return t_52;
return default;
}, 4, "", true);
bk_25 = Fn((V _arrowThis77, int _argc69, V t_75, V d_76, V _a73, V _a74, V[] _rest70) => {
return Invoke(t_75, "back", (d_76 is var _t78 && Truthy(_t78) ? _t78 : ((V)(420D))));
}, 2, "", true);
hop_26 = NewObj(2).Put("dn", ((V)("hop"))).Put("up", ((V)("hop"))).V;
RL_27 = NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V;
mk_28 = Fn((V _arrowThis88, int _argc79, V key_85, V @base_86, V P_87, V _a84, V[] _rest80) => {
return Call(build_18, V.Undef, key_85, Call(o_23, V.Undef, @base_86, P_87, NewObj(2).Put("pose", Call(o_23, V.Undef, (Get(@base_86, "pose") is var _t89 && Truthy(_t89) ? _t89 : NewObj(0).V), (Get(P_87, "pose") is var _t90 && Truthy(_t90) ? _t90 : NewObj(0).V))).Put("lpose", Call(o_23, V.Undef, (Get(@base_86, "lpose") is var _t91 && Truthy(_t91) ? _t91 : NewObj(0).V), RL_27, (Get(P_87, "lpose") is var _t92 && Truthy(_t92) ? _t92 : NewObj(0).V))).V));
}, 3, "", true);
SIG_29 = NewObj(11).Put("nana", Fn((V _arrowThis100, int _argc93, V t_99, V _a96, V _a97, V _a98, V[] _rest94) => {
Invoke(Invoke(t_99, "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("cv", ((V)(0.6))).V, NewObj(1).Put("cv", ((V)((-0.4)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("cv", ((V)(0D))).V);
return Call(bk_25, V.Undef, t_99);
return default;
}, 1, "nana", true)).Put("bing", Fn((V _arrowThis108, int _argc101, V t_107, V _a104, V _a105, V _a106, V[] _rest102) => {
Invoke(Invoke(Invoke(t_107, "to", ((V)(700D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(500D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
return Call(bk_25, V.Undef, t_107);
return default;
}, 1, "bing", true)).Put("plummy", Fn((V _arrowThis116, int _argc109, V t_115, V _a112, V _a113, V _a114, V[] _rest110) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_115, "to", ((V)(700D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(500D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("pol", ((V)(1D))).V, ((V)("io"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(1000D)), NewObj(1).Put("pol", ((V)(0D))).V, ((V)("io")));
return Call(bk_25, V.Undef, t_115);
return default;
}, 1, "plummy", true)).Put("clemmy", Fn((V _arrowThis124, int _argc117, V t_123, V _a120, V _a121, V _a122, V[] _rest118) => {
Invoke(Invoke(Invoke(Invoke(t_123, "to", ((V)(800D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("zest")), ((V)("head")), ((V)(3D)));
return Call(bk_25, V.Undef, t_123);
return default;
}, 1, "clemmy", true)).Put("appy", Fn((V _arrowThis132, int _argc125, V t_131, V _a128, V _a129, V _a130, V[] _rest126) => {
Invoke(Invoke(Invoke(t_131, "to", ((V)(200D)), NewObj(1).Put("lf", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("lf", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
return Call(bk_25, V.Undef, t_131);
return default;
}, 1, "appy", true)).Put("blueby", Fn((V _arrowThis140, int _argc133, V t_139, V _a136, V _a137, V _a138, V[] _rest134) => {
Invoke(Invoke(t_139, "osc", ((V)(1200D)), ((V)(2D)), NewObj(2).Put("rl", ((V)(16D))).Put("x", Add((Get(Get(t_139, "B"), "x") is var _t142 && Truthy(_t142) ? _t142 : ((V)(0D))), ((V)(2D)))).V, NewObj(2).Put("rl", ((V)((-16D)))).Put("x", ((V)((ToNum((Get(Get(t_139, "B"), "x") is var _t143 && Truthy(_t143) ? _t143 : ((V)(0D)))) - 2D)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", (Get(Get(t_139, "B"), "x") is var _t141 && Truthy(_t141) ? _t141 : ((V)(0D)))).V, ((V)("io")));
return Call(bk_25, V.Undef, t_139);
return default;
}, 1, "blueby", true)).Put("coco", Fn((V _arrowThis151, int _argc144, V t_150, V _a147, V _a148, V _a149, V[] _rest145) => {
Invoke(Invoke(Invoke(t_150, "to", ((V)(150D)), NewObj(1).Put("fz", ((V)(0.9))).V, ((V)("o"))), "fx", ((V)("knock")), ((V)("head")), ((V)(1D))), "to", ((V)(500D)), NewObj(1).Put("fz", ((V)(0D))).V, ((V)("io")));
return Call(bk_25, V.Undef, t_150);
return default;
}, 1, "coco", true)).Put("perry", Fn((V _arrowThis159, int _argc152, V t_158, V _a155, V _a156, V _a157, V[] _rest153) => {
Invoke(Invoke(Invoke(Invoke(t_158, "to", ((V)(300D)), NewObj(1).Put("tilt", Add((Get(Get(t_158, "B"), "tilt") is var _t163 && Truthy(_t163) ? _t163 : ((V)(0D))), ((V)(8D)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("tilt", ((V)((ToNum((Get(Get(t_158, "B"), "tilt") is var _t162 && Truthy(_t162) ? _t162 : ((V)(0D)))) - 5D)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("tilt", Add((Get(Get(t_158, "B"), "tilt") is var _t161 && Truthy(_t161) ? _t161 : ((V)(0D))), ((V)(2D)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("tilt", (Get(Get(t_158, "B"), "tilt") is var _t160 && Truthy(_t160) ? _t160 : ((V)(0D)))).V, ((V)("io")));
return Call(bk_25, V.Undef, t_158);
return default;
}, 1, "perry", true)).Put("grana", Fn((V _arrowThis171, int _argc164, V t_170, V _a167, V _a168, V _a169, V[] _rest165) => {
Invoke(Invoke(Invoke(Invoke(t_170, "to", ((V)(900D)), NewObj(2).Put("stw", ((V)(1D))).Put("crf", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(0D))).Put("crf", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("arils")), ((V)("head")), ((V)(3D)));
return Call(bk_25, V.Undef, t_170);
return default;
}, 1, "grana", true)).Put("mangie", Fn((V _arrowThis179, int _argc172, V t_178, V _a175, V _a176, V _a177, V[] _rest173) => {
return Call(sp_24, V.Undef, t_178, NewObj(4).Put("lf", ((V)(1D))).Put("close", ((V)(0.6))).Put("blush", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1200D)), ((V)(800D)));
}, 1, "mangie", true)).Put("razzy", Fn((V _arrowThis187, int _argc180, V t_186, V _a183, V _a184, V _a185, V[] _rest181) => {
Invoke(Invoke(Invoke(t_186, "to", ((V)(200D)), NewObj(1).Put("jig", ((V)(1.3))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(700D)), NewObj(1).Put("jig", ((V)(0D))).V, ((V)("io")));
return Call(bk_25, V.Undef, t_186);
return default;
}, 1, "razzy", true)).V;
SLEEPY_30 = NewObj(11).Put("nana", Fn((V _arrowThis195, int _argc188, V t_194, V _a191, V _a192, V _a193, V[] _rest189) => {
return Call(sp_24, V.Undef, t_194, NewObj(2).Put("cv", ((V)(0.8))).Put("close", ((V)(1D))).V, ((V)(1800D)), ((V)(1600D)));
}, 1, "nana", true)).Put("bing", Fn((V _arrowThis203, int _argc196, V t_202, V _a199, V _a200, V _a201, V[] _rest197) => {
return Call(sp_24, V.Undef, t_202, NewObj(2).Put("lf", ((V)(0.4))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "bing", true)).Put("plummy", Fn((V _arrowThis211, int _argc204, V t_210, V _a207, V _a208, V _a209, V[] _rest205) => {
return Call(sp_24, V.Undef, t_210, NewObj(2).Put("lf", ((V)(0.4))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "plummy", true)).Put("clemmy", Fn((V _arrowThis219, int _argc212, V t_218, V _a215, V _a216, V _a217, V[] _rest213) => {
return Call(sp_24, V.Undef, t_218, NewObj(2).Put("lf", ((V)(0.4))).Put("close", ((V)(0.9))).V, ((V)(1400D)), ((V)(1200D)));
}, 1, "clemmy", true)).Put("appy", Fn((V _arrowThis227, int _argc220, V t_226, V _a223, V _a224, V _a225, V[] _rest221) => {
return Call(sp_24, V.Undef, t_226, NewObj(2).Put("lf", ((V)(0.3))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "appy", true)).Put("blueby", Fn((V _arrowThis235, int _argc228, V t_234, V _a231, V _a232, V _a233, V[] _rest229) => {
return Call(sp_24, V.Undef, t_234, NewObj(2).Put("rl", ((V)(12D))).Put("close", ((V)(1D))).V, ((V)(1800D)), ((V)(1600D)));
}, 1, "blueby", true)).Put("coco", Fn((V _arrowThis243, int _argc236, V t_242, V _a239, V _a240, V _a241, V[] _rest237) => {
return Call(sp_24, V.Undef, t_242, NewObj(2).Put("fz", ((V)(0.3))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D)));
}, 1, "coco", true)).Put("perry", Fn((V _arrowThis251, int _argc244, V t_250, V _a247, V _a248, V _a249, V[] _rest245) => {
return Call(sp_24, V.Undef, t_250, NewObj(2).Put("tilt", ((V)(6D))).Put("close", ((V)(1D))).V, ((V)(1800D)), ((V)(1600D)));
}, 1, "perry", true)).Put("grana", Fn((V _arrowThis259, int _argc252, V t_258, V _a255, V _a256, V _a257, V[] _rest253) => {
return Call(sp_24, V.Undef, t_258, NewObj(2).Put("crf", ((V)((-0.3)))).Put("close", ((V)(0.9))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "grana", true)).Put("mangie", Fn((V _arrowThis267, int _argc260, V t_266, V _a263, V _a264, V _a265, V[] _rest261) => {
return Call(sp_24, V.Undef, t_266, NewObj(3).Put("lf", ((V)(0.5))).Put("close", ((V)(1D))).Put("blush", ((V)(0.4))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "mangie", true)).Put("razzy", Fn((V _arrowThis275, int _argc268, V t_274, V _a271, V _a272, V _a273, V[] _rest269) => {
return Call(sp_24, V.Undef, t_274, NewObj(2).Put("jig", ((V)(0.3))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "razzy", true)).V;
Call(mk_28, V.Undef, ((V)("nana")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "nana"), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), Get(SLEEPY_30, "nana"), ((V)("doze")), ((V)("stretch")))).V);
Call(mk_28, V.Undef, ((V)("bing")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "bing"), ((V)("swing")), ((V)("kick")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "bing"), ((V)("belly")))).V);
NOLEG_31 = NewObj(2).Put("perry", ((V)(1D))).Put("coco", ((V)(1D))).V;
Call(mk_28, V.Undef, ((V)("plummy")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "plummy"), ((V)("swing")), ((V)("kick")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "plummy"), ((V)("stretch")))).V);
Call(mk_28, V.Undef, ((V)("clemmy")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "clemmy"), ((V)("kick")), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "clemmy"), ((V)("stretch")))).V);
Call(mk_28, V.Undef, ((V)("appy")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "appy"), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "appy"), ((V)("stretch")))).V);
Call(mk_28, V.Undef, ((V)("blueby")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "blueby"), ((V)("swing")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "blueby"), ((V)("belly")))).V);
Call(mk_28, V.Undef, ((V)("coco")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "coco"), ((V)("pat")), Fn((V _arrowThis283, int _argc276, V t_282, V _a279, V _a280, V _a281, V[] _rest277) => {
Invoke(Invoke(Invoke(t_282, "to", ((V)(500D)), NewObj(2).Put("rl", ((V)(18D))).Put("x", Add((Get(Get(t_282, "B"), "x") is var _t286 && Truthy(_t286) ? _t286 : ((V)(0D))), ((V)(2D)))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(2).Put("rl", ((V)((-10D)))).Put("x", ((V)((ToNum((Get(Get(t_282, "B"), "x") is var _t285 && Truthy(_t285) ? _t285 : ((V)(0D)))) - 1D)))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", (Get(Get(t_282, "B"), "x") is var _t284 && Truthy(_t284) ? _t284 : ((V)(0D)))).V, ((V)("io")));
return Call(bk_25, V.Undef, t_282);
return default;
}, 1, "", true))).Put("lf", Arr(((V)("sigh")), Get(SLEEPY_30, "coco"), ((V)("doze")), ((V)("belly")))).V);
Call(mk_28, V.Undef, ((V)("perry")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "perry"), ((V)("hum")), ((V)("pat")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "perry"), ((V)("belly")))).V);
Call(mk_28, V.Undef, ((V)("grana")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "grana"), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "grana"), ((V)("stretch")))).V);
Call(mk_28, V.Undef, ((V)("mangie")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "mangie"), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), Get(SLEEPY_30, "mangie"), ((V)("doze")), ((V)("stretch")))).V);
Call(mk_28, V.Undef, ((V)("razzy")), hop_26, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_29, "razzy"), ((V)("swing")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "razzy"), ((V)("belly")))).V);
DR_32 = NewObj(11).Put("nana", ((V)("sun"))).Put("bing", ((V)("cherry"))).Put("plummy", ((V)("star"))).Put("clemmy", ((V)("sun"))).Put("appy", ((V)("apple"))).Put("blueby", ((V)("berry"))).Put("coco", ((V)("shell"))).Put("perry", ((V)("leaf"))).Put("grana", ((V)("crown"))).Put("mangie", ((V)("sun"))).Put("razzy", ((V)("star"))).V;
WK_33 = NewObj(11).Put("nana", NewObj(1).Put("cv", ((V)((-0.8)))).V).Put("bing", NewObj(2).Put("stw", ((V)(0.6))).Put("lf", ((V)(1D))).V).Put("plummy", NewObj(2).Put("lf", ((V)(1D))).Put("stw", ((V)(0.4))).V).Put("clemmy", NewObj(1).Put("lf", ((V)(1D))).V).Put("appy", NewObj(1).Put("lf", ((V)(1D))).V).Put("blueby", NewObj(1).Put("crf", ((V)(0.8))).V).Put("coco", NewObj(1).Put("fz", ((V)(1D))).V).Put("perry", NewObj(1).Put("lf", ((V)(1D))).V).Put("grana", NewObj(1).Put("crf", ((V)(1D))).V).Put("mangie", NewObj(1).Put("lf", ((V)(1D))).V).Put("razzy", NewObj(1).Put("jig", ((V)(1D))).V).V;
Invoke(K_8, "forEach", Fn((V _arrowThis294, int _argc287, V k_293, V _a290, V _a291, V _a292, V[] _rest288) => {
return Call(bedBuild_19, V.Undef, k_293, NewObj(3).Put("dr", GetK(DR_32, k_293)).Put("wk", GetK(WK_33, k_293)).Put("s", GetK(SLEEPY_30, k_293)).V);
}, 1, "", true));
SW_34 = NewObj(11).Put("nana", ((V)("float"))).Put("bing", ((V)("bob"))).Put("plummy", ((V)("bob"))).Put("clemmy", ((V)("bob"))).Put("appy", ((V)("bob"))).Put("blueby", ((V)("bob"))).Put("coco", ((V)("float"))).Put("perry", ((V)("bob"))).Put("grana", ((V)("bob"))).Put("mangie", ((V)("float"))).Put("razzy", ((V)("bob"))).V;
Invoke(K_8, "forEach", Fn((V _arrowThis302, int _argc295, V k_301, V _a298, V _a299, V _a300, V[] _rest296) => {
return Call(waterBuild_20, V.Undef, k_301, NewObj(3).Put("sw", GetK(SW_34, k_301)).Put("k", NewObj(3).Put("a", GetK(WK_33, k_301)).Put("b", NewObj(0).V).Put("f", GetK(WK_33, k_301)).V).Put("s", GetK(SIG_29, k_301)).V);
}, 1, "", true));
SN_35 = NewObj(11).Put("nana", ((V)("honey"))).Put("bing", ((V)("cherry"))).Put("plummy", ((V)("candy"))).Put("clemmy", ((V)("drop"))).Put("appy", ((V)("apple"))).Put("blueby", ((V)("berry"))).Put("coco", ((V)("cup"))).Put("perry", ((V)("honey"))).Put("grana", ((V)("cake"))).Put("mangie", ((V)("drop"))).Put("razzy", ((V)("candy"))).V;
CHEER_36 = NewObj(11).Put("nana", NewObj(1).Put("cheer", NewObj(1).Put("cv", ((V)((-0.8)))).V).V).Put("bing", NewObj(1).Put("cheer", NewObj(2).Put("lf", ((V)(1D))).Put("stw", ((V)(0.6))).V).V).Put("plummy", NewObj(2).Put("cheer", NewObj(2).Put("lf", ((V)(1D))).Put("stw", ((V)(0.6))).V).Put("cheerFx", Arr(((V)("pljuice")), ((V)("head")))).V).Put("clemmy", NewObj(2).Put("cheer", NewObj(1).Put("lf", ((V)(1D))).V).Put("cheerFx", Arr(((V)("zest")), ((V)("head")))).V).Put("appy", NewObj(2).Put("cheer", NewObj(1).Put("lf", ((V)(1D))).V).Put("cheerFx", Arr(((V)("spark")), ((V)("head")))).V).Put("blueby", NewObj(1).Put("cheer", NewObj(1).Put("crf", ((V)(1D))).V).V).Put("coco", NewObj(2).Put("cheer", NewObj(1).Put("fz", ((V)(1D))).V).Put("cheerFx", Arr(((V)("knock")), ((V)("head")))).V).Put("perry", NewObj(1).Put("cheer", NewObj(1).Put("lf", ((V)(1D))).V).V).Put("grana", NewObj(2).Put("cheer", NewObj(1).Put("crf", ((V)(1D))).V).Put("cheerFx", Arr(((V)("arils")), ((V)("head")))).V).Put("mangie", NewObj(2).Put("cheer", NewObj(1).Put("lf", ((V)(1D))).V).Put("cheerFx", Arr(((V)("mjuice")), ((V)("head")))).V).Put("razzy", NewObj(2).Put("cheer", NewObj(1).Put("jig", ((V)(1.3))).V).Put("cheerFx", Arr(((V)("spark")), ((V)("head")))).V).V;
Invoke(K_8, "forEach", Fn((V _arrowThis310, int _argc303, V k_309, V _a306, V _a307, V _a308, V[] _rest304) => {
return Call(playBuild_21, V.Undef, k_309, Call(o_23, V.Undef, GetK(CHEER_36, k_309), NewObj(3).Put("sn", GetK(SN_35, k_309)).Put("p", GetK(SIG_29, k_309)).Put("sp", NewObj(6).Put("armL", ((V)(42D))).Put("armR", ((V)(42D))).Put("hLy", ((V)((-7D)))).Put("hRy", ((V)((-7D)))).Put("hLx", ((V)(1D))).Put("hRx", ((V)((-1D)))).V).V, (Truthy(GetK(NOLEG_31, k_309)) ? NewObj(1).Put("swingOrd", Arr(((V)("wheee")), ((V)("peek")), ((V)("sig")), ((V)("breeze")), ((V)("onehand")), ((V)("higher")), ((V)("giggle")))).V : NewObj(0).V)));
}, 1, "", true));
FC_37 = NewObj(11).Put("nana", ((V)("leaf"))).Put("bing", ((V)("cherry"))).Put("plummy", ((V)("star"))).Put("clemmy", ((V)("leaf"))).Put("appy", ((V)("apple"))).Put("blueby", ((V)("pearl"))).Put("coco", ((V)("shell"))).Put("perry", ((V)("leaf"))).Put("grana", ((V)("crown"))).Put("mangie", ((V)("flower"))).Put("razzy", ((V)("star"))).V;
TBC_38 = Arr(((V)("#5fb8e8")), ((V)("#7cc35a")), ((V)("#ff8fa8")), ((V)("#ffcc3a")), ((V)("#b98ae8")), ((V)("#ff8a4a")));
Invoke(K_8, "forEach", Fn((V _arrowThis319, int _argc311, V k_317, V i_318, V _a315, V _a316, V[] _rest312) => {
return Call(bBuild_22, V.Undef, k_317, Call(o_23, V.Undef, GetK(CHEER_36, k_317), NewObj(4).Put("fc", GetK(FC_37, k_317)).Put("tk", Call(o_23, V.Undef, GetK(WK_33, k_317))).Put("tb", GetIdx(TBC_38, (ToNum(i_318) % ToNum(Get(TBC_38, "length"))))).Put("sn", GetK(SN_35, k_317)).V));
}, 2, "", true));
if (Truthy(Get(H_17, "cBuild"))) {
Invoke(K_8, "forEach", Fn((V _arrowThis327, int _argc320, V k_326, V _a323, V _a324, V _a325, V[] _rest321) => {
return Invoke(H_17, "cBuild", k_326, NewObj(4).Put("ks", ((V)((Truthy(((SEqS(k_326, "blueby") ? V.True : V.False) is var _t328 && Truthy(_t328) ? _t328 : GetK(NOLEG_31, k_326))) ? "body" : "foot")))).Put("pc", ((V)("#7cc35a"))).Put("hc", ((V)("#7cc35a"))).Put("mc", ((V)("#3b3b4a"))).V);
}, 1, "", true));
}
Set(G("window"), "HouseWalkRUN", Object_assign((Get(G("window"), "HouseWalkRUN") is var _t329 && Truthy(_t329) ? _t329 : NewObj(0).V), NewObj(5).Put("plummy", NewObj(1).Put("lf", ((V)(0.6))).V).Put("razzy", NewObj(1).Put("jig", ((V)(0.6))).V).Put("bing", NewObj(1).Put("lf", ((V)(0.6))).V).Put("clemmy", NewObj(1).Put("lf", ((V)(0.6))).V).Put("nana", NewObj(1).Put("cv", ((V)(0.3))).V).V));
return default;
}, 1, "", false));
walks_9 = Fn((V _arrowThis338, int _argc331, V W_337, V _a334, V _a335, V _a336, V[] _rest332) => {
V d_339 = default;
d_339 = Fn((V _arrowThis348, int _argc340, V k_346, V P_347, V _a344, V _a345, V[] _rest341) => {
return Invoke(W_337, "def", k_346, P_347);
}, 2, "", true);
Call(d_339, V.Undef, ((V)("nana")), NewObj(3).Put("g", ((V)("waddle"))).Put("a", ((V)(0.85))).Put("x", NewObj(1).Put("cv", Arr(((V)(0.35)), ((V)(1D)), ((V)(0D)), ((V)(0D)))).V).V);
Call(d_339, V.Undef, ((V)("bing")), NewObj(3).Put("g", ((V)("bounce"))).Put("a", ((V)(0.9))).Put("x", NewObj(1).Put("lf", Arr(((V)(0.5)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_339, V.Undef, ((V)("plummy")), NewObj(3).Put("g", ((V)("prance"))).Put("a", ((V)(0.85))).Put("x", NewObj(1).Put("lf", Arr(((V)(0.5)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_339, V.Undef, ((V)("clemmy")), NewObj(3).Put("g", ((V)("bounce"))).Put("a", ((V)(0.95))).Put("x", NewObj(1).Put("lf", Arr(((V)(0.4)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_339, V.Undef, ((V)("appy")), NewObj(3).Put("g", ((V)("shuffle"))).Put("a", ((V)(0.85))).Put("x", NewObj(1).Put("lf", Arr(((V)(0.3)), ((V)(1D)), ((V)(0D)), ((V)(0D)))).V).V);
Call(d_339, V.Undef, ((V)("blueby")), NewObj(2).Put("g", ((V)("eggroll"))).Put("a", ((V)(0.8))).V);
Call(d_339, V.Undef, ((V)("coco")), NewObj(2).Put("g", ((V)("eggroll"))).Put("a", ((V)(0.8))).V);
Call(d_339, V.Undef, ((V)("perry")), NewObj(3).Put("g", ((V)("roll"))).Put("a", ((V)(0.9))).Put("x", NewObj(1).Put("lf", Arr(((V)(0.3)), ((V)(1D)), ((V)(0D)), ((V)(0D)))).V).V);
Call(d_339, V.Undef, ((V)("grana")), NewObj(2).Put("g", ((V)("prance"))).Put("a", ((V)(0.75))).V);
Call(d_339, V.Undef, ((V)("mangie")), NewObj(3).Put("g", ((V)("prance"))).Put("a", ((V)(0.9))).Put("x", NewObj(1).Put("lf", Arr(((V)(0.4)), ((V)(1D)), ((V)(0D)), ((V)(0D)))).V).V);
Call(d_339, V.Undef, ((V)("razzy")), NewObj(3).Put("g", ((V)("bounce"))).Put("a", ((V)(0.9))).Put("x", NewObj(1).Put("jig", Arr(((V)(0.6)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Set(Get(W_337, "G"), "eggroll", (Get(Get(W_337, "G"), "eggroll") is var _t359 && Truthy(_t359) ? _t359 : NewObj(3).Put("r", ((V)(0.9))).Put("dl", ((V)(0D))).Put("f", Fn((V _self349, int _argc350, V p_356, V A_357, V o_358, V _a355, V[] _rest351) => {
if (_self349.IsNullish) _self349 = GlobalV;
Set(o_358, "armL", ((V)((24D + ((7D * ToNum(A_357)) * FdLibm.Sin(ToNum(p_356)))))));
Set(o_358, "armR", ((V)((24D - ((7D * ToNum(A_357)) * FdLibm.Sin(ToNum(p_356)))))));
Set(o_358, "sq", ((V)(((0.02 * ToNum(A_357)) * FdLibm.Sin((2D * ToNum(p_356)))))));
return default;
}, 3, "f", false)).V));
if (!(Truthy(Get(W_337, "__frRoll")))) {
V st0_360 = default;
Set(W_337, "__frRoll", ((V)(1D)));
st0_360 = Get(W_337, "step");
Set(W_337, "step", Fn((V _self361, int _argc362, V key_368, V st_369, V E_370, V w_371, V[] _rest363) => {
V r_376 = default;
double dir_377 = 0;
V mv_378 = default;
V dt_372 = default;
V spd_373 = default;
V spin_374 = default;
if (_self361.IsNullish) _self361 = GlobalV;
dt_372 = (_argc362 > 4 ? _rest363[0] : V.Undef);
spd_373 = (_argc362 > 5 ? _rest363[1] : V.Undef);
spin_374 = (_argc362 > 6 ? _rest363[2] : V.Undef);
V _arguments375 = Arguments(_argc362, key_368, st_369, E_370, w_371, _rest363);
r_376 = Invoke(st0_360, "apply", _self361, _arguments375);
if ((!SEqS(key_368, "blueby") && !SEqS(key_368, "coco"))) {
return r_376;
}
dir_377 = FdLibm.Sin(((ToNum((spin_374 is var _t379 && Truthy(_t379) ? _t379 : ((V)(0D)))) * System.Math.PI) / 180D));
mv_378 = ((GtN((spd_373 is var _t380 && Truthy(_t380) ? _t380 : ((V)(0D))), 0D) && GtN(w_371, 0.3)) ? V.True : V.False);
Set(st_369, "ra", (Get(st_369, "ra") is var _t381 && Truthy(_t381) ? _t381 : ((V)(0D))));
Set(st_369, "rv", (Get(st_369, "rv") is var _t382 && Truthy(_t382) ? _t382 : ((V)(0D))));
if (Truthy(mv_378)) {
double tv_383 = 0;
tv_383 = (((300D * ToNum(spd_373)) * (Truthy(Get(st_369, "run")) ? 1.6 : 1D)) * ((System.Math.Abs(dir_377) < 0.3) ? ((dir_377 < 0D) ? (-0.3) : 0.3) : dir_377));
OpSet(st_369, "rv", 0, ((V)(((tv_383 - ToNum(Get(st_369, "rv"))) * Min(1D, (ToNum(dt_372) * 6D))))));
OpSet(st_369, "ra", 0, ((V)((ToNum(Get(st_369, "rv")) * ToNum(dt_372)))));
} else {
double tg_384 = 0;
tg_384 = (Round((ToNum(Get(st_369, "ra")) / 360D)) * 360D);
OpSet(st_369, "rv", 0, ((V)(((((tg_384 - ToNum(Get(st_369, "ra"))) * 60D) - (ToNum(Get(st_369, "rv")) * 7D)) * Min(ToNum(dt_372), 0.05)))));
OpSet(st_369, "ra", 0, ((V)((ToNum(Get(st_369, "rv")) * Min(ToNum(dt_372), 0.05)))));
if (((System.Math.Abs((tg_384 - ToNum(Get(st_369, "ra")))) < 0.3) && (System.Math.Abs(ToNum(Get(st_369, "rv"))) < 2D))) {
Set(st_369, "ra", ((V)(0D)));
Set(st_369, "rv", ((V)(0D)));
}
}
Set(E_370, "rl", ((V)((ToNum(Add((Get(E_370, "rl") is var _t385 && Truthy(_t385) ? _t385 : ((V)(0D))), ((V)((((ToNum(Get(st_369, "ra")) % 360D) + 540D) % 360D))))) - 180D))));
return r_376;
return default;
}, 7, "", false));
}
return default;
}, 1, "", true);
if (Truthy(Get(G("window"), "HouseWalk"))) {
Call(walks_9, V.Undef, Get(G("window"), "HouseWalk"));
} else {
Invoke(Set(G("window"), "HouseWalkC", (Get(G("window"), "HouseWalkC") is var _t386 && Truthy(_t386) ? _t386 : Arr())), "push", walks_9);
}
Invoke(Set(G("window"), "HouseIdleC", (Get(G("window"), "HouseIdleC") is var _t534 && Truthy(_t534) ? _t534 : Arr())), "push", Fn((V _self387, int _argc388, V W_394, V _a391, V _a392, V _a393, V[] _rest389) => {
V sp_395 = default;
V d_396 = default;
if (_self387.IsNullish) _self387 = GlobalV;
sp_395 = Get(W_394, "sp");
d_396 = Fn((V _arrowThis405, int _argc397, V k_403, V L_404, V _a401, V _a402, V[] _rest398) => {
return Invoke(W_394, "build", k_403, L_404);
}, 2, "", true);
Call(d_396, V.Undef, ((V)("nana")), Arr(Fn((V _arrowThis413, int _argc406, V t_412, V _a409, V _a410, V _a411, V[] _rest407) => {
Invoke(Invoke(t_412, "osc", ((V)(1400D)), ((V)(3D)), NewObj(2).Put("cv", ((V)(0.6))).Put("x", ((V)(1D))).V, NewObj(2).Put("cv", ((V)((-0.4)))).Put("x", ((V)((-1D)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("cv", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), Fn((V _arrowThis421, int _argc414, V t_420, V _a417, V _a418, V _a419, V[] _rest415) => {
return Call(sp_395, V.Undef, t_420, NewObj(4).Put("cv", ((V)((-0.9)))).Put("lift", ((V)(2D))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).V, ((V)(1400D)), ((V)(500D)));
}, 1, "", true), ((V)("hum"))));
Call(d_396, V.Undef, ((V)("bing")), Arr(Fn((V _arrowThis429, int _argc422, V t_428, V _a425, V _a426, V _a427, V[] _rest423) => {
Invoke(Invoke(Invoke(t_428, "to", ((V)(700D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(500D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), ((V)("bounce")), ((V)("giggle"))));
Call(d_396, V.Undef, ((V)("plummy")), Arr(Fn((V _arrowThis437, int _argc430, V t_436, V _a433, V _a434, V _a435, V[] _rest431) => {
Invoke(Invoke(Invoke(Invoke(t_436, "to", ((V)(260D)), NewObj(4).Put("lift", ((V)(1.5))).Put("sq", ((V)((-0.04)))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).V, ((V)("io"))), "to", ((V)(800D)), NewObj(2).Put("spin", ((V)(360D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "to", ((V)(260D)), NewObj(5).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), Fn((V _arrowThis445, int _argc438, V t_444, V _a441, V _a442, V _a443, V[] _rest439) => {
Invoke(Invoke(Invoke(Invoke(t_444, "to", ((V)(320D)), NewObj(1).Put("pol", ((V)(1D))).V, ((V)("io"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D))), "wait", ((V)(400D))), "to", ((V)(1200D)), NewObj(1).Put("pol", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), ((V)("curtsy"))));
Call(d_396, V.Undef, ((V)("clemmy")), Arr(Fn((V _arrowThis453, int _argc446, V t_452, V _a449, V _a450, V _a451, V[] _rest447) => {
Invoke(Invoke(Invoke(Invoke(t_452, "to", ((V)(800D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("zest")), ((V)("head")), ((V)(3D)));
return default;
}, 1, "", true), Arr(((V)("twirl")), ((V)(1D))), ((V)("bounce"))));
Call(d_396, V.Undef, ((V)("appy")), Arr(Fn((V _arrowThis461, int _argc454, V t_460, V _a457, V _a458, V _a459, V[] _rest455) => {
Invoke(Invoke(Invoke(t_460, "to", ((V)(200D)), NewObj(1).Put("lf", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("lf", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
return default;
}, 1, "", true), ((V)("clap")), ((V)("hum"))));
Call(d_396, V.Undef, ((V)("blueby")), Arr(Fn((V _arrowThis469, int _argc462, V t_468, V _a465, V _a466, V _a467, V[] _rest463) => {
Invoke(Invoke(t_468, "osc", ((V)(1400D)), ((V)(3D)), NewObj(2).Put("rl", ((V)(16D))).Put("x", ((V)(3D))).V, NewObj(2).Put("rl", ((V)((-16D)))).Put("x", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), Fn((V _arrowThis477, int _argc470, V t_476, V _a473, V _a474, V _a475, V[] _rest471) => {
Invoke(Invoke(Invoke(t_476, "to", ((V)(600D)), NewObj(2).Put("stw", ((V)(1D))).Put("crf", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(0D))).Put("crf", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), ((V)("curtsy"))));
Call(d_396, V.Undef, ((V)("coco")), Arr(Fn((V _arrowThis485, int _argc478, V t_484, V _a481, V _a482, V _a483, V[] _rest479) => {
Invoke(Invoke(Invoke(t_484, "to", ((V)(150D)), NewObj(1).Put("fz", ((V)(0.9))).V, ((V)("o"))), "fx", ((V)("knock")), ((V)("head")), ((V)(1D))), "to", ((V)(500D)), NewObj(1).Put("fz", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), Fn((V _arrowThis493, int _argc486, V t_492, V _a489, V _a490, V _a491, V[] _rest487) => {
Invoke(Invoke(Invoke(Invoke(t_492, "to", ((V)(700D)), NewObj(2).Put("rl", ((V)(360D))).Put("x", ((V)(6D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "to", ((V)(700D)), NewObj(2).Put("rl", ((V)((-360D)))).Put("x", ((V)(0D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l")));
return default;
}, 1, "", true), ((V)("nod"))));
Call(d_396, V.Undef, ((V)("perry")), Arr(Fn((V _arrowThis501, int _argc494, V t_500, V _a497, V _a498, V _a499, V[] _rest495) => {
Invoke(Invoke(Invoke(Invoke(t_500, "to", ((V)(400D)), NewObj(1).Put("tilt", ((V)(10D))).V, ((V)("o"))), "to", ((V)(380D)), NewObj(1).Put("tilt", ((V)((-6D)))).V, ((V)("io"))), "to", ((V)(360D)), NewObj(1).Put("tilt", ((V)(3D))).V, ((V)("io"))), "to", ((V)(340D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), Fn((V _arrowThis509, int _argc502, V t_508, V _a505, V _a506, V _a507, V[] _rest503) => {
Invoke(Invoke(t_508, "osc", ((V)(1600D)), ((V)(4D)), NewObj(2).Put("tilt", ((V)(6D))).Put("turn", ((V)(0.12))).V, NewObj(2).Put("tilt", ((V)((-6D)))).Put("turn", ((V)((-0.12)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("tilt", ((V)(0D))).Put("turn", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), ((V)("hum"))));
Call(d_396, V.Undef, ((V)("grana")), Arr(Fn((V _arrowThis517, int _argc510, V t_516, V _a513, V _a514, V _a515, V[] _rest511) => {
Invoke(Invoke(Invoke(Invoke(t_516, "to", ((V)(900D)), NewObj(2).Put("stw", ((V)(1D))).Put("crf", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(0D))).Put("crf", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("arils")), ((V)("head")), ((V)(3D)));
return default;
}, 1, "", true), ((V)("bow")), ((V)("nod"))));
Call(d_396, V.Undef, ((V)("mangie")), Arr(Fn((V _arrowThis525, int _argc518, V t_524, V _a521, V _a522, V _a523, V[] _rest519) => {
return Call(sp_395, V.Undef, t_524, NewObj(4).Put("lf", ((V)(1D))).Put("close", ((V)(0.6))).Put("blush", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1200D)), ((V)(800D)));
}, 1, "", true), Arr(((V)("twirl")), ((V)(1D))), ((V)("curtsy"))));
Call(d_396, V.Undef, ((V)("razzy")), Arr(Fn((V _arrowThis533, int _argc526, V t_532, V _a529, V _a530, V _a531, V[] _rest527) => {
Invoke(Invoke(Invoke(t_532, "to", ((V)(200D)), NewObj(1).Put("jig", ((V)(1.3))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(700D)), NewObj(1).Put("jig", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), Arr(((V)("twirl")), ((V)(1D))), ((V)("giggle"))));
return default;
}, 1, "", false));
return default;
}, 0, "", false), V.Undef);
        }
    }
}
