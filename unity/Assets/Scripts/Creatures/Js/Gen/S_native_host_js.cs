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
V LOOK_19 = default;
V auto_20 = default;
V lookOf_21 = default;
V alive_22 = default;
V R_23 = default;
V rmount_24 = default;
hostEl_16 = Fn((V _self25, int _argc26, V id_32, V _a29, V _a30, V _a31, V[] _rest27) => {
return (GetK(els_13, id_32) is var _t33 && Truthy(_t33) ? _t33 : V.Null);
return default;
}, 1, "hostEl", false);
I_18 = Fn((V _self34, int _argc35, V id_41, V _a38, V _a39, V _a40, V[] _rest36) => {
V c_42 = default;
c_42 = GetK(ctl_9, id_41);
return (c_42 is var _t43 && !Truthy(_t43) ? _t43 : Get(c_42, "_I"));
return default;
}, 1, "I", false);
lookOf_21 = Fn((V _self44, int _argc45, V key_51, V _a48, V _a49, V _a50, V[] _rest46) => {
if (Truthy((Get(LOOK_19, "keys") is var _t52 && !Truthy(_t52) ? _t52 : (LtN(Invoke(Get(LOOK_19, "keys"), "indexOf", key_51), 0D) ? V.True : V.False)))) {
return ((V)(0D));
}
return (!GetK(Get(LOOK_19, "over"), key_51).IsNullish ? ((V)(Max(0D, Min(4D, ((double)(ToInt32(ToNum(GetK(Get(LOOK_19, "over"), key_51))) | ToInt32(0D))))))) : Get(LOOK_19, "n"));
return default;
}, 1, "lookOf", false);
alive_22 = Fn((V _self53, int _argc54, V r_60, V _a57, V _a58, V _a59, V[] _rest55) => {
V s_61 = default;
s_61 = Get(Get(r_60, "I"), "shadow");
return ((!(Truthy(s_61)) ? V.True : V.False) is var _t62 && Truthy(_t62) ? _t62 : Get(s_61, "isConnected"));
return default;
}, 1, "alive", false);
ctl_9 = NewObj(0).V;
ext_10 = NewObj(0).V;
walk_11 = NewObj(0).V;
park_12 = NewObj(0).V;
els_13 = NewObj(0).V;
EIO_14 = Fn((V _self63, int _argc64, V t_70, V _a67, V _a68, V _a69, V[] _rest65) => {
return ((V)((LtN(t_70, 0.5) ? ((2D * ToNum(t_70)) * ToNum(t_70)) : (1D - (Pow((((-2D) * ToNum(t_70)) + 2D), 2D) / 2D)))));
return default;
}, 1, "", false);
mount_15 = Get(Get(G_8, "__live"), "mount");
Set(Get(G_8, "__live"), "mount", Fn((V _self71, int _argc72, V key_78, V _a75, V _a76, V _a77, V[] _rest73) => {
V id_79 = default;
V b_80 = default;
id_79 = Call(mount_15, V.Undef, key_78);
b_80 = Get(Get(Get(G_8, "document"), "body"), "childNodes");
SetK(ctl_9, id_79, (Get(G_8, "RiveRig") is var _t81 && !Truthy(_t81) ? _t81 : Get(Get(G_8, "RiveRig"), "_last")));
SetK(els_13, id_79, GetIdx(b_80, (ToNum(Get(b_80, "length")) - 1D)));
return id_79;
return default;
}, 1, "", false));
unmount_17 = Get(Get(G_8, "__live"), "unmount");
Set(Get(G_8, "__live"), "unmount", Fn((V _self82, int _argc83, V id_89, V _a86, V _a87, V _a88, V[] _rest84) => {
DeleteK(ctl_9, id_89);
DeleteK(ext_10, id_89);
DeleteK(walk_11, id_89);
DeleteK(park_12, id_89);
DeleteK(els_13, id_89);
return Call(unmount_17, V.Undef, id_89);
return default;
}, 1, "", false));
Set(G_8, "__native", NewObj(17).Put("ctl", Fn((V _self90, int _argc91, V id_97, V _a94, V _a95, V _a96, V[] _rest92) => {
return (GetK(ctl_9, id_97) is var _t98 && Truthy(_t98) ? _t98 : V.Null);
return default;
}, 1, "ctl", false)).Put("host", Fn((V _self99, int _argc100, V id_106, V _a103, V _a104, V _a105, V[] _rest101) => {
return (GetK(els_13, id_106) is var _t107 && Truthy(_t107) ? _t107 : V.Null);
return default;
}, 1, "host", false)).Put("ext", Fn((V _self108, int _argc109, V id_115, V o_116, V _a113, V _a114, V[] _rest110) => {
V c_117 = default;
V h_118 = default;
V k_119 = default;
V k2_120 = default;
c_117 = GetK(ctl_9, id_115);
if (!(Truthy(c_117))) {
return default;
}
h_118 = GetK(ext_10, id_115);
if (!(Truthy(h_118))) {
h_118 = SetK(ext_10, id_115, NewObj(0).V);
if (Truthy(Get(c_117, "ext"))) {
Invoke(c_117, "ext", h_118);
}
}
{
foreach (V _k121 in ForInKeys(h_118)) {
k_119 = _k121;
SetK(h_118, k_119, ((V)(0D)));
}
}
{
foreach (V _k122 in ForInKeys(o_116)) {
k2_120 = _k122;
SetK(h_118, k2_120, GetK(o_116, k2_120));
}
}
return default;
}, 2, "ext", false)).Put("events", Fn((V _self123, int _argc124, V id_130, V _a127, V _a128, V _a129, V[] _rest125) => {
return Invoke(G("JSON"), "parse", Invoke(Get(G_8, "__live"), "events", id_130));
return default;
}, 1, "events", false)).Put("walkStep", Fn((V _self131, int _argc132, V id_138, V key_139, V w_140, V dt_141, V[] _rest133) => {
V i_143 = default;
V s_144 = default;
V k_145 = default;
V spin_142 = default;
spin_142 = (_argc132 > 4 ? _rest133[0] : V.Undef);
i_143 = Call(I_18, V.Undef, id_138);
if (!(Truthy(i_143))) {
return default;
}
s_144 = (GetK(walk_11, id_138) is var _t146 && Truthy(_t146) ? _t146 : SetK(walk_11, id_138, NewObj(2).Put("E", NewObj(0).V).Put("ws", NewObj(0).V).V));
if (!SEq(Get(i_143, "ext"), Get(s_144, "E"))) {
Set(i_143, "ext", Get(s_144, "E"));
}
{
foreach (V _k147 in ForInKeys(Get(s_144, "E"))) {
k_145 = _k147;
SetK(Get(s_144, "E"), k_145, ((V)(0D)));
}
}
if (Truthy(((GtN(w_140, 0D) ? V.True : V.False) is var _t148 && !Truthy(_t148) ? _t148 : Get(G_8, "HouseWalk")))) {
try {
Invoke(Get(G_8, "HouseWalk"), "step", key_139, Get(s_144, "ws"), Get(s_144, "E"), w_140, dt_141, ((V)(1D)), spin_142);
} catch (System.Exception _ex149) {
V e_150 = default;
e_150 = Caught(_ex149);

}
}
return default;
}, 5, "walkStep", false)).Put("emit", Fn((V _self151, int _argc152, V id_158, V kind_159, V at_160, V x_161, V[] _rest153) => {
V i_164 = default;
V p_165 = default;
V y_162 = default;
V n_163 = default;
y_162 = (_argc152 > 4 ? _rest153[0] : V.Undef);
n_163 = (_argc152 > 5 ? _rest153[1] : V.Undef);
i_164 = Call(I_18, V.Undef, id_158);
if ((!(Truthy(i_164)) || !(Truthy(Get(Get(G_8, "RiveRig"), "emit"))))) {
return default;
}
p_165 = (Truthy(at_160) ? ((Get(i_164, "W") is var _t166 && !Truthy(_t166) ? _t166 : GetK(Get(i_164, "W"), at_160)) is var _t167 && Truthy(_t167) ? _t167 : Arr(((V)(50D)), ((V)(50D)))) : Arr(x_161, y_162));
Invoke(Get(G_8, "RiveRig"), "emit", i_164, kind_159, p_165, (GtN(n_163, 0D) ? n_163 : ((V)(0D))));
return default;
}, 6, "emit", false)).Put("parkStart", Fn((V _self168, int _argc169, V id_175, V key_176, V enter_177, V _a174, V[] _rest170) => {
V i_178 = default;
V c_179 = default;
V HW_180 = default;
V E_181 = default;
V ws_182 = default;
V prev_183 = default;
V ph_184 = default;
V turn_185 = default;
V walkMs_186 = default;
V dir_187 = default;
i_178 = Call(I_18, V.Undef, id_175);
c_179 = GetK(ctl_9, id_175);
if (!(Truthy(i_178))) {
return default;
}
HW_180 = Get(G_8, "HouseWalk");
E_181 = NewObj(0).V;
ws_182 = NewObj(0).V;
prev_183 = Get(i_178, "ext");
ph_184 = ((V)(0D));
turn_185 = ((V)((Truthy(enter_177) ? 380D : 340D)));
walkMs_186 = ((V)((Truthy(enter_177) ? 2300D : 2100D)));
dir_187 = ((V)((Truthy(enter_177) ? (-90D) : 90D)));
SetK(park_12, id_175, Fn((V _self188, int _argc189, V now_195, V _a192, V _a193, V _a194, V[] _rest190) => {
V tt_196 = default;
V w_197 = default;
V k_198 = default;
V k2_199 = default;
if (SEqN(ph_184, 0D)) {
Invoke(c_179, "play", ((V)("idle")));
ph_184 = ((V)(1D));
}
if (Lt(now_195, turn_185)) {
Set(i_178, "spinOff", ((V)((ToNum(dir_187) * ToNum(Call(EIO_14, V.Undef, ((V)((ToNum(now_195) / ToNum(turn_185))))))))));
return default;
}
if (Lt(now_195, Add(turn_185, walkMs_186))) {
if (!SEq(Get(i_178, "ext"), E_181)) {
Set(i_178, "ext", E_181);
}
tt_196 = ((V)(((ToNum(now_195) - ToNum(turn_185)) / ToNum(walkMs_186))));
w_197 = ((V)(Min(1D, (ToNum(tt_196) / 0.08), ((1D - ToNum(tt_196)) / 0.1))));
{
foreach (V _k200 in ForInKeys(E_181)) {
k_198 = _k200;
SetK(E_181, k_198, ((V)(0D)));
}
}
try {
Invoke(HW_180, "step", key_176, ws_182, E_181, ((V)(Max(0D, ToNum(w_197)))), ((V)(0.016)), ((V)(1D)), dir_187);
} catch (System.Exception _ex201) {
V e_202 = default;
e_202 = Caught(_ex201);

}
Set(i_178, "spinOff", dir_187);
return default;
}
if (SEq(Get(i_178, "ext"), E_181)) {
{
foreach (V _k203 in ForInKeys(E_181)) {
k2_199 = _k203;
SetK(E_181, k2_199, ((V)(0D)));
}
}
Set(i_178, "ext", prev_183);
}
if (Lt(now_195, Add(((V)((2D * ToNum(turn_185)))), walkMs_186))) {
Set(i_178, "spinOff", ((V)((ToNum(dir_187) * (1D - ToNum(Call(EIO_14, V.Undef, ((V)((((ToNum(now_195) - ToNum(turn_185)) - ToNum(walkMs_186)) / ToNum(turn_185)))))))))));
return default;
}
if (SEqN(ph_184, 1D)) {
Set(i_178, "spinOff", ((V)(0D)));
Invoke(c_179, "play", ((V)("happy")));
ph_184 = ((V)(2D));
DeleteK(park_12, id_175);
}
return default;
}, 1, "", false));
return default;
}, 3, "parkStart", false)).Put("parkStep", Fn((V _self204, int _argc205, V id_211, V ms_212, V _a209, V _a210, V[] _rest206) => {
if (Truthy(GetK(park_12, id_211))) {
InvokeK(park_12, id_211, ms_212);
}
return default;
}, 2, "parkStep", false)).Put("pointer", Fn((V _self213, int _argc214, V id_220, V type_221, V x_222, V y_223, V[] _rest215) => {
V el_224 = default;
V w_225 = default;
el_224 = Call(hostEl_16, V.Undef, id_220);
if (!(Truthy(el_224))) {
return default;
}
Set(el_224, "__rect", NewObj(4).Put("left", ((V)(0D))).Put("top", ((V)(0D))).Put("width", ((V)(100D))).Put("height", ((V)(100D))).V);
w_225 = Get(el_224, "firstChild");
if (!(Truthy(w_225))) {
return default;
}
Invoke(w_225, "dispatchEvent", NewObj(6).Put("type", type_221).Put("clientX", x_222).Put("clientY", y_223).Put("pointerId", ((V)(1D))).Put("preventDefault", Fn((V _self226, int _argc227, V _a229, V _a230, V _a231, V _a232, V[] _rest228) => {

return default;
}, 0, "preventDefault", false)).Put("stopPropagation", Fn((V _self233, int _argc234, V _a236, V _a237, V _a238, V _a239, V[] _rest235) => {

return default;
}, 0, "stopPropagation", false)).V);
return default;
}, 4, "pointer", false)).Put("press", Fn((V _self240, int _argc241, V id_247, V _a244, V _a245, V _a246, V[] _rest242) => {
V i_248 = default;
i_248 = Call(I_18, V.Undef, id_247);
if (Truthy(i_248)) {
Set(i_248, "press", (true ? V.True : V.False));
Set(i_248, "pressT", Invoke(Get(G_8, "performance"), "now"));
}
return default;
}, 1, "press", false)).Put("light", Fn((V _self249, int _argc250, V id_256, V json_257, V _a254, V _a255, V[] _rest251) => {
V c_258 = default;
c_258 = GetK(ctl_9, id_256);
if (Truthy((c_258 is var _t259 && !Truthy(_t259) ? _t259 : Get(c_258, "light")))) {
Invoke(c_258, "light", (Truthy(json_257) ? Invoke(G("JSON"), "parse", json_257) : V.Null));
}
return default;
}, 2, "light", false)).Put("restBox", Fn((V _self260, int _argc261, V id_267, V _a264, V _a265, V _a266, V[] _rest262) => {
V c_268 = default;
V i_269 = default;
V el_270 = default;
V svg_271 = default;
V b_272 = default;
c_268 = GetK(ctl_9, id_267);
i_269 = Call(I_18, V.Undef, id_267);
el_270 = GetK(els_13, id_267);
if ((!(Truthy(c_268)) || !(Truthy(el_270)))) {
return V.Null;
}
if (Truthy((Get(i_269, "generic") is var _t273 && !Truthy(_t273) ? _t273 : (!(Truthy(Get(i_269, "ready"))) ? V.True : V.False)))) {
return V.Null;
}
if (!(Truthy(Get(G_8, "__heroPre")))) {
Set(G_8, "__heroPre", ((V)(1D)));
Object_assign(Get(Get(G_8, "RiveRig"), "PRE"), NewObj(2).Put("unDust", NewObj(8).Put("n", ((V)(8D))).Put("sp", ((V)(26D))).Put("vy", ((V)((-5D)))).Put("g", ((V)(10D))).Put("life", ((V)(650D))).Put("r", Arr(((V)(1.4)), ((V)(2.6)))).Put("col", Arr(((V)("#ffffff")), ((V)("#fff6e6")), ((V)("#f6e2c4")))).Put("kind", ((V)("dot"))).V).Put("unSpark", NewObj(8).Put("n", ((V)(8D))).Put("sp", ((V)(34D))).Put("vy", ((V)((-14D)))).Put("g", ((V)(0D))).Put("life", ((V)(800D))).Put("r", Arr(((V)(2.2)), ((V)(3.8)))).Put("col", Arr(((V)("#fff3a0")), ((V)("#ffffff")), ((V)("#ffd23a")), ((V)("#ffd1f5")))).Put("kind", ((V)("star"))).V).V);
}
Invoke(c_268, "_pose", ((V)("idle")), ((V)(0D)));
svg_271 = Invoke(el_270, "querySelector", ((V)("svg")));
b_272 = V.Null;
try {
b_272 = (svg_271 is var _t274 && !Truthy(_t274) ? _t274 : Invoke(svg_271, "getBBox"));
} catch (System.Exception _ex275) {
V e_276 = default;
e_276 = Caught(_ex275);

}
if ((!(Truthy(b_272)) || !(GtN(Get(b_272, "width"), 1D)))) {
return V.Null;
}
return Arr(Get(b_272, "x"), Get(b_272, "y"), Get(b_272, "width"), Get(b_272, "height"));
return default;
}, 1, "restBox", false)).Put("state", Fn((V _self277, int _argc278, V id_284, V _a281, V _a282, V _a283, V[] _rest279) => {
V i_285 = default;
i_285 = Call(I_18, V.Undef, id_284);
return (Truthy((i_285 is var _t286 && !Truthy(_t286) ? _t286 : Get(i_285, "cur"))) ? Get(Get(i_285, "cur"), "name") : V.Null);
return default;
}, 1, "state", false)).Put("spinOff", Fn((V _self287, int _argc288, V id_294, V deg_295, V _a292, V _a293, V[] _rest289) => {
V i_296 = default;
i_296 = Call(I_18, V.Undef, id_294);
if (Truthy(i_296)) {
Set(i_296, "spinOff", deg_295);
}
return default;
}, 2, "spinOff", false)).Put("looks", Fn((V _self297, int _argc298, V n_304, V over_305, V keys_306, V _a303, V[] _rest299) => {
Set(LOOK_19, "n", ((V)((n_304.IsNullish ? 4D : Max(0D, Min(4D, ((double)(ToInt32(ToNum(n_304)) | ToInt32(0D)))))))));
Set(LOOK_19, "over", (Truthy(over_305) ? (Invoke(G("JSON"), "parse", over_305) is var _t307 && Truthy(_t307) ? _t307 : NewObj(0).V) : NewObj(0).V));
Set(LOOK_19, "keys", (Truthy(keys_306) ? Invoke(G("JSON"), "parse", keys_306) : V.Null));
auto_20 = Invoke(auto_20, "filter", alive_22);
Invoke(auto_20, "forEach", Fn((V _self308, int _argc309, V r_315, V _a312, V _a313, V _a314, V[] _rest310) => {
Set(Get(r_315, "I"), "lookM", Call(lookOf_21, V.Undef, Get(r_315, "key")));
return default;
}, 1, "", false));
if (Truthy((Get(G_8, "RiveRig") is var _t316 && !Truthy(_t316) ? _t316 : Get(Get(G_8, "RiveRig"), "setLook")))) {
Invoke(Get(G_8, "RiveRig"), "setLook", Get(LOOK_19, "n"));
}
return default;
}, 3, "looks", false)).Put("lookOf", Fn((V _self317, int _argc318, V key_324, V _a321, V _a322, V _a323, V[] _rest319) => {
return Call(lookOf_21, V.Undef, key_324);
return default;
}, 1, "lookOf", false)).Put("look", Fn((V _self325, int _argc326, V id_332, V n_333, V _a330, V _a331, V[] _rest327) => {
V c_334 = default;
V i_335 = default;
c_334 = GetK(ctl_9, id_332);
i_335 = (c_334 is var _t336 && !Truthy(_t336) ? _t336 : Get(c_334, "_I"));
if (!(Truthy(i_335))) {
return default;
}
auto_20 = Invoke(auto_20, "filter", Fn((V _self337, int _argc338, V r_344, V _a341, V _a342, V _a343, V[] _rest339) => {
return (!SEq(Get(r_344, "I"), i_335) ? V.True : V.False);
return default;
}, 1, "", false));
Set(i_335, "lookM", ((V)(Max(0D, Min(4D, ((double)(ToInt32(ToNum(n_333)) | ToInt32(0D))))))));
if (Truthy(Get(c_334, "light"))) {
Invoke(c_334, "light", (Get(i_335, "sceneL") is var _t345 && Truthy(_t345) ? _t345 : V.Null));
}
return default;
}, 2, "look", false)).V);
LOOK_19 = NewObj(3).Put("n", ((V)(4D))).Put("over", NewObj(0).V).Put("keys", V.Null).V;
auto_20 = Arr();
R_23 = Get(G_8, "RiveRig");
if (Truthy(((R_23 is var _t346 && !Truthy(_t346) ? _t346 : (string.Equals(Typeof(Get(R_23, "mount")), "function") ? V.True : V.False)) is var _t347 && !Truthy(_t347) ? _t347 : (!(Truthy(Get(R_23, "__unityLook"))) ? V.True : V.False)))) {
rmount_24 = Get(R_23, "mount");
Set(R_23, "mount", Fn((V _self348, int _argc349, V host_355, V key_356, V o_357, V _a354, V[] _rest350) => {
V own_358 = default;
V oo_359 = default;
V k_360 = default;
V c_361 = default;
own_358 = (!(!(Truthy((o_357 is var _t362 && !Truthy(_t362) ? _t362 : (!Get(o_357, "look").IsNullish ? V.True : V.False))))) ? V.True : V.False);
oo_359 = o_357;
if (!(Truthy(own_358))) {
oo_359 = NewObj(0).V;
if (Truthy(o_357)) {
{
foreach (V _k363 in ForInKeys(o_357)) {
k_360 = _k363;
SetK(oo_359, k_360, GetK(o_357, k_360));
}
}
}
Set(oo_359, "look", Call(lookOf_21, V.Undef, key_356));
}
c_361 = Invoke(rmount_24, "call", _self348, host_355, key_356, oo_359);
if (Truthy((((!(Truthy(own_358)) ? V.True : V.False) is var _t364 && !Truthy(_t364) ? _t364 : c_361) is var _t365 && !Truthy(_t365) ? _t365 : Get(c_361, "_I")))) {
auto_20 = Invoke(auto_20, "filter", alive_22);
Invoke(auto_20, "push", NewObj(2).Put("I", Get(c_361, "_I")).Put("key", key_356).V);
}
return c_361;
return default;
}, 3, "", false));
Set(R_23, "__unityLook", (true ? V.True : V.False));
if (Truthy(Get(R_23, "setLook"))) {
Invoke(R_23, "setLook", Get(LOOK_19, "n"));
}
}
return default;
}, 1, "", false), V.Undef, (!string.Equals(GTypeof("globalThis"), "undefined") ? G("globalThis") : GlobalV));
        }
    }
}
