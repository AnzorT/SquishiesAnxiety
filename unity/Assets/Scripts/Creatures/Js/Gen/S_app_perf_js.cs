// app/perf.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_app_perf_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("<(animate|animateTransform|animateMotion|animateColor|set)\\b[^>]*\\/>", "g");
        static readonly System.Text.RegularExpressions.Regex RX1 = JsRegExp.Compile("<(animate|animateTransform|animateMotion|animateColor)\\b[^>]*>[\\s\\S]*?<\\/\\1>", "g");
        static readonly System.Text.RegularExpressions.Regex RX2 = JsRegExp.Compile("%[0-9a-fA-F]{2}", "");
        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V W_8 = default;
V perf_9 = default;
V N_10 = default;
V asleep_11 = default;
V slept_12 = default;
V fellAt_13 = default;
V subs_14 = default;
V S_15 = default;
V vnow_16 = default;
V fid_17 = default;
V frames_18 = default;
V held_19 = default;
V runFrame_20 = default;
V tid_21 = default;
V timers_22 = default;
V arm_23 = default;
V timersSleep_24 = default;
V timersWake_25 = default;
V media_26 = default;
V contexts_27 = default;
V wantPlay_28 = default;
V wantResume_29 = default;
V MP_30 = default;
V play_31 = default;
V BAC_32 = default;
V resume_33 = default;
V EP_34 = default;
V anims_35 = default;
V animate_36 = default;
V svgs_37 = default;
V style_38 = default;
V sleep_39 = default;
V wake_40 = default;
if (_self1.IsNullish) _self1 = GlobalV;
runFrame_20 = Fn((V _self41, int _argc42, V id_48, V cb_49, V _a46, V _a47, V[] _rest43) => {
if (_self41.IsNullish) _self41 = GlobalV;
return Fn((V _self50, int _argc51, V ts_57, V _a54, V _a55, V _a56, V[] _rest52) => {
if (_self50.IsNullish) _self50 = GlobalV;
DeleteK(frames_18, id_48);
if (Truthy(asleep_11)) {
SetK(held_19, id_48, cb_49);
return default;
}
Call(cb_49, V.Undef, ((V)((ToNum(ts_57) - ToNum(slept_12)))));
return default;
}, 1, "", false);
return default;
}, 2, "runFrame", false);
arm_23 = Fn((V _self58, int _argc59, V T_65, V d_66, V _a63, V _a64, V[] _rest60) => {
if (_self58.IsNullish) _self58 = GlobalV;
Set(T_65, "n", Invoke(N_10, "setTimeout", Fn((V _self67, int _argc68, V _a70, V _a71, V _a72, V _a73, V[] _rest69) => {
if (_self67.IsNullish) _self67 = GlobalV;
Set(T_65, "n", ((V)(0D)));
if (!(Truthy(asleep_11))) {
Invoke(T_65, "run");
}
return default;
}, 0, "", false), d_66));
return default;
}, 2, "arm", false);
timersSleep_24 = Fn((V _self74, int _argc75, V _a77, V _a78, V _a79, V _a80, V[] _rest76) => {
if (_self74.IsNullish) _self74 = GlobalV;
Invoke(Object_keys(timers_22), "forEach", Fn((V _self81, int _argc82, V id_88, V _a85, V _a86, V _a87, V[] _rest83) => {
V T_89 = default;
if (_self81.IsNullish) _self81 = GlobalV;
T_89 = GetK(timers_22, id_88);
if (Truthy(Get(T_89, "tick"))) {
if (Truthy(Get(T_89, "iv"))) {
Invoke(N_10, "clearInterval", Get(T_89, "iv"));
Set(T_89, "iv", ((V)(0D)));
}
} else {
if (Truthy(Get(T_89, "n"))) {
Invoke(N_10, "clearTimeout", Get(T_89, "n"));
Set(T_89, "n", ((V)(0D)));
}
}
return default;
}, 1, "", false));
return default;
}, 0, "timersSleep", false);
timersWake_25 = Fn((V _self90, int _argc91, V _a93, V _a94, V _a95, V _a96, V[] _rest92) => {
V now_97 = default;
if (_self90.IsNullish) _self90 = GlobalV;
now_97 = Call(vnow_16, V.Undef);
Invoke(Object_keys(timers_22), "forEach", Fn((V _self98, int _argc99, V id_105, V _a102, V _a103, V _a104, V[] _rest100) => {
V T_106 = default;
if (_self98.IsNullish) _self98 = GlobalV;
T_106 = GetK(timers_22, id_105);
if (Truthy(Get(T_106, "tick"))) {
if (!(Truthy(Get(T_106, "iv")))) {
Set(T_106, "iv", Invoke(N_10, "setInterval", Get(T_106, "tick"), Get(T_106, "ms")));
}
} else {
if (!(Truthy(Get(T_106, "n")))) {
Call(arm_23, V.Undef, T_106, ((V)(Max(0D, (ToNum(Get(T_106, "due")) - ToNum(now_97))))));
}
}
return default;
}, 1, "", false));
return default;
}, 0, "timersWake", false);
sleep_39 = Fn((V _self107, int _argc108, V _a110, V _a111, V _a112, V _a113, V[] _rest109) => {
V root_114 = default;
if (_self107.IsNullish) _self107 = GlobalV;
if (Truthy(asleep_11)) {
return default;
}
fellAt_13 = Invoke(N_10, "now");
asleep_11 = (true ? V.True : V.False);
root_114 = Get(G("document"), "documentElement");
if (!(Truthy(style_38))) {
style_38 = Invoke(G("document"), "createElement", ((V)("style")));
Set(style_38, "textContent", ((V)("html.sq-sleep *,html.sq-sleep *::before,html.sq-sleep *::after{animation-play-state:paused !important;}")));
Invoke((Get(G("document"), "head") is var _t115 && Truthy(_t115) ? _t115 : root_114), "appendChild", style_38);
}
Invoke(Get(root_114, "classList"), "add", ((V)("sq-sleep")));
anims_35 = Arr();
try {
Invoke(Invoke(G("document"), "getAnimations"), "forEach", Fn((V _self116, int _argc117, V a_123, V _a120, V _a121, V _a122, V[] _rest118) => {
if (_self116.IsNullish) _self116 = GlobalV;
if ((SEqS(Get(a_123, "playState"), "running") && !(Truthy((Get(W_8, "CSSAnimation") is var _t124 && !Truthy(_t124) ? _t124 : (InstanceOf(a_123, Get(W_8, "CSSAnimation")) ? V.True : V.False)))))) {
Invoke(a_123, "pause");
Invoke(anims_35, "push", a_123);
}
return default;
}, 1, "", false));
} catch (System.Exception _ex125) {
V e_126 = default;
e_126 = Caught(_ex125);

}
svgs_37 = Arr();
Invoke(Invoke(G("document"), "querySelectorAll", ((V)("animate,animateTransform,animateMotion,set"))), "forEach", Fn((V _self127, int _argc128, V e_134, V _a131, V _a132, V _a133, V[] _rest129) => {
V s_135 = default;
if (_self127.IsNullish) _self127 = GlobalV;
s_135 = Get(e_134, "ownerSVGElement");
while (Truthy((s_135 is var _t136 && !Truthy(_t136) ? _t136 : Get(s_135, "ownerSVGElement")))) {
s_135 = Get(s_135, "ownerSVGElement");
}
if (Truthy((((s_135 is var _t137 && !Truthy(_t137) ? _t137 : (LtN(Invoke(svgs_37, "indexOf", s_135), 0D) ? V.True : V.False)) is var _t138 && !Truthy(_t138) ? _t138 : Get(s_135, "pauseAnimations")) is var _t139 && !Truthy(_t139) ? _t139 : (!(Truthy(Invoke(s_135, "animationsPaused"))) ? V.True : V.False)))) {
Invoke(s_135, "pauseAnimations");
Invoke(svgs_37, "push", s_135);
}
return default;
}, 1, "", false));
wantPlay_28 = Arr();
if (Truthy(media_26)) {
Invoke(Invoke(G("document"), "querySelectorAll", ((V)("video,audio"))), "forEach", Fn((V _self140, int _argc141, V m_147, V _a144, V _a145, V _a146, V[] _rest142) => {
if (_self140.IsNullish) _self140 = GlobalV;
Invoke(media_26, "add", m_147);
return default;
}, 1, "", false));
Invoke(media_26, "forEach", Fn((V _self148, int _argc149, V m_155, V _a152, V _a153, V _a154, V[] _rest150) => {
if (_self148.IsNullish) _self148 = GlobalV;
if ((!(Truthy(Get(m_155, "paused"))) && !(Truthy(Get(m_155, "ended"))))) {
Invoke(m_155, "pause");
Invoke(wantPlay_28, "push", m_155);
}
return default;
}, 1, "", false));
}
wantResume_29 = Arr();
Invoke(contexts_27, "forEach", Fn((V _self156, int _argc157, V c_163, V _a160, V _a161, V _a162, V[] _rest158) => {
if (_self156.IsNullish) _self156 = GlobalV;
if (SEqS(Get(c_163, "state"), "running")) {
try {
Invoke(c_163, "suspend");
Invoke(wantResume_29, "push", c_163);
} catch (System.Exception _ex164) {
V e_165 = default;
e_165 = Caught(_ex164);

}
}
return default;
}, 1, "", false));
Call(timersSleep_24, V.Undef);
Invoke(subs_14, "forEach", Fn((V _self166, int _argc167, V f_173, V _a170, V _a171, V _a172, V[] _rest168) => {
if (_self166.IsNullish) _self166 = GlobalV;
try {
Call(f_173, V.Undef, (true ? V.True : V.False));
} catch (System.Exception _ex174) {
V e_175 = default;
e_175 = Caught(_ex174);
Invoke(G("console"), "error", ((V)("[SquishSleep]")), e_175);
}
return default;
}, 1, "", false));
return default;
}, 0, "sleep", false);
wake_40 = Fn((V _self176, int _argc177, V _a179, V _a180, V _a181, V _a182, V[] _rest178) => {
V h_183 = default;
if (_self176.IsNullish) _self176 = GlobalV;
if (!(Truthy(asleep_11))) {
return default;
}
slept_12 = Add(slept_12, ((V)((ToNum(Invoke(N_10, "now")) - ToNum(fellAt_13)))));
asleep_11 = (false ? V.True : V.False);
Invoke(Get(Get(G("document"), "documentElement"), "classList"), "remove", ((V)("sq-sleep")));
Invoke(anims_35, "forEach", Fn((V _self184, int _argc185, V a_191, V _a188, V _a189, V _a190, V[] _rest186) => {
if (_self184.IsNullish) _self184 = GlobalV;
try {
if (SEqS(Get(a_191, "playState"), "paused")) {
Invoke(a_191, "play");
}
} catch (System.Exception _ex192) {
V e_193 = default;
e_193 = Caught(_ex192);

}
return default;
}, 1, "", false));
anims_35 = Arr();
Invoke(svgs_37, "forEach", Fn((V _self194, int _argc195, V s_201, V _a198, V _a199, V _a200, V[] _rest196) => {
if (_self194.IsNullish) _self194 = GlobalV;
try {
Invoke(s_201, "unpauseAnimations");
} catch (System.Exception _ex202) {
V e_203 = default;
e_203 = Caught(_ex202);

}
return default;
}, 1, "", false));
svgs_37 = Arr();
Invoke(wantPlay_28, "forEach", Fn((V _self204, int _argc205, V m_211, V _a208, V _a209, V _a210, V[] _rest206) => {
if (_self204.IsNullish) _self204 = GlobalV;
if (Truthy((Get(m_211, "isConnected") is var _t212 && Truthy(_t212) ? _t212 : (SEqS(Get(m_211, "tagName"), "AUDIO") ? V.True : V.False)))) {
try {
Invoke(Invoke(Get(S_15, "_play"), "call", m_211), "catch", Fn((V _self213, int _argc214, V _a216, V _a217, V _a218, V _a219, V[] _rest215) => {
if (_self213.IsNullish) _self213 = GlobalV;

return default;
}, 0, "", false));
} catch (System.Exception _ex220) {
V e_221 = default;
e_221 = Caught(_ex220);

}
}
return default;
}, 1, "", false));
wantPlay_28 = Arr();
Invoke(wantResume_29, "forEach", Fn((V _self222, int _argc223, V c_229, V _a226, V _a227, V _a228, V[] _rest224) => {
if (_self222.IsNullish) _self222 = GlobalV;
try {
if (SEqS(Get(c_229, "state"), "suspended")) {
Invoke(resume_33, "call", c_229);
}
} catch (System.Exception _ex230) {
V e_231 = default;
e_231 = Caught(_ex230);

}
return default;
}, 1, "", false));
wantResume_29 = Arr();
h_183 = held_19;
held_19 = NewObj(0).V;
Invoke(Object_keys(h_183), "forEach", Fn((V _self232, int _argc233, V id_239, V _a236, V _a237, V _a238, V[] _rest234) => {
if (_self232.IsNullish) _self232 = GlobalV;
SetK(frames_18, id_239, Invoke(N_10, "raf", Call(runFrame_20, V.Undef, id_239, GetK(h_183, id_239))));
return default;
}, 1, "", false));
Call(timersWake_25, V.Undef);
Invoke(subs_14, "forEach", Fn((V _self240, int _argc241, V f_247, V _a244, V _a245, V _a246, V[] _rest242) => {
if (_self240.IsNullish) _self240 = GlobalV;
try {
Call(f_247, V.Undef, (false ? V.True : V.False));
} catch (System.Exception _ex248) {
V e_249 = default;
e_249 = Caught(_ex248);
Invoke(G("console"), "error", ((V)("[SquishSleep]")), e_249);
}
return default;
}, 1, "", false));
return default;
}, 0, "wake", false);
W_8 = G("window");
perf_9 = Get(W_8, "performance");
N_10 = NewObj(7).Put("raf", (Get(W_8, "requestAnimationFrame") is var _t250 && !Truthy(_t250) ? _t250 : Invoke(Get(W_8, "requestAnimationFrame"), "bind", W_8))).Put("caf", (Get(W_8, "cancelAnimationFrame") is var _t251 && !Truthy(_t251) ? _t251 : Invoke(Get(W_8, "cancelAnimationFrame"), "bind", W_8))).Put("setTimeout", Invoke(Get(W_8, "setTimeout"), "bind", W_8)).Put("clearTimeout", Invoke(Get(W_8, "clearTimeout"), "bind", W_8)).Put("setInterval", Invoke(Get(W_8, "setInterval"), "bind", W_8)).Put("clearInterval", Invoke(Get(W_8, "clearInterval"), "bind", W_8)).Put("now", Invoke(Get(perf_9, "now"), "bind", perf_9)).V;
asleep_11 = (false ? V.True : V.False);
slept_12 = ((V)(0D));
fellAt_13 = ((V)(0D));
subs_14 = Arr();
S_15 = Set(W_8, "SquishSleep", NewObj(4).Put("native", N_10).Getter("asleep", Fn((V _self252, int _argc253, V _a255, V _a256, V _a257, V _a258, V[] _rest254) => {
if (_self252.IsNullish) _self252 = GlobalV;
return asleep_11;
return default;
}, 0, "asleep", false)).Put("sleptMs", Fn((V _self259, int _argc260, V _a262, V _a263, V _a264, V _a265, V[] _rest261) => {
if (_self259.IsNullish) _self259 = GlobalV;
return slept_12;
return default;
}, 0, "sleptMs", false)).Put("on", Fn((V _self266, int _argc267, V f_273, V _a270, V _a271, V _a272, V[] _rest268) => {
if (_self266.IsNullish) _self266 = GlobalV;
Invoke(subs_14, "push", f_273);
return default;
}, 1, "on", false)).V);
vnow_16 = Fn((V _self274, int _argc275, V _a277, V _a278, V _a279, V _a280, V[] _rest276) => {
if (_self274.IsNullish) _self274 = GlobalV;
return ((V)((ToNum((Truthy(asleep_11) ? fellAt_13 : Invoke(N_10, "now"))) - ToNum(slept_12))));
return default;
}, 0, "", false);
try {
Set(perf_9, "now", vnow_16);
} catch (System.Exception _ex281) {
V e_282 = default;
e_282 = Caught(_ex281);

}
fid_17 = ((V)(1000000000D));
frames_18 = NewObj(0).V;
held_19 = NewObj(0).V;
if (Truthy(Get(N_10, "raf"))) {
Set(W_8, "requestAnimationFrame", Fn((V _self283, int _argc284, V cb_290, V _a287, V _a288, V _a289, V[] _rest285) => {
V id_291 = default;
if (_self283.IsNullish) _self283 = GlobalV;
id_291 = ((V)(PreInc(ref fid_17, 1D)));
if (Truthy(asleep_11)) {
SetK(held_19, id_291, cb_290);
} else {
SetK(frames_18, id_291, Invoke(N_10, "raf", Call(runFrame_20, V.Undef, id_291, cb_290)));
}
return id_291;
return default;
}, 1, "", false));
Set(W_8, "cancelAnimationFrame", Fn((V _self292, int _argc293, V id_299, V _a296, V _a297, V _a298, V[] _rest294) => {
if (_self292.IsNullish) _self292 = GlobalV;
if (Truthy(GetK(held_19, id_299))) {
DeleteK(held_19, id_299);
return default;
}
if (!GetK(frames_18, id_299).IsNullish) {
Invoke(N_10, "caf", GetK(frames_18, id_299));
DeleteK(frames_18, id_299);
} else {
if (LtN(id_299, 1000000000D)) {
Invoke(N_10, "caf", id_299);
}
}
return default;
}, 1, "", false));
}
tid_21 = ((V)(1000000000D));
timers_22 = NewObj(0).V;
Set(W_8, "setTimeout", Fn((V _self300, int _argc301, V cb_307, V ms_308, V _a305, V _a306, V[] _rest302) => {
V id_310 = default;
V args_311 = default;
V d_312 = default;
V T_313 = default;
if (_self300.IsNullish) _self300 = GlobalV;
V _arguments309 = Arguments(_argc301, cb_307, ms_308, _a305, _a306, _rest302);
if (!string.Equals(Typeof(cb_307), "function")) {
return Invoke(Get(N_10, "setTimeout"), "apply", W_8, _arguments309);
}
id_310 = ((V)(PreInc(ref tid_21, 1D)));
args_311 = Invoke(Get(Get(G("Array"), "prototype"), "slice"), "call", _arguments309, ((V)(2D)));
d_312 = ((V)(Max(0D, ToNum((((V)(ToNum(ms_308))) is var _t314 && Truthy(_t314) ? _t314 : ((V)(0D)))))));
T_313 = SetK(timers_22, id_310, NewObj(3).Put("due", Add(Call(vnow_16, V.Undef), d_312)).Put("n", ((V)(0D))).Put("run", Fn((V _self315, int _argc316, V _a318, V _a319, V _a320, V _a321, V[] _rest317) => {
if (_self315.IsNullish) _self315 = GlobalV;
DeleteK(timers_22, id_310);
Invoke(cb_307, "apply", W_8, args_311);
return default;
}, 0, "run", false)).V);
if (!(Truthy(asleep_11))) {
Call(arm_23, V.Undef, T_313, d_312);
}
return id_310;
return default;
}, 2, "", false));
Set(W_8, "setInterval", Fn((V _self322, int _argc323, V cb_329, V ms_330, V _a327, V _a328, V[] _rest324) => {
V id_332 = default;
V args_333 = default;
V T_334 = default;
if (_self322.IsNullish) _self322 = GlobalV;
V _arguments331 = Arguments(_argc323, cb_329, ms_330, _a327, _a328, _rest324);
if (!string.Equals(Typeof(cb_329), "function")) {
return Invoke(Get(N_10, "setInterval"), "apply", W_8, _arguments331);
}
id_332 = ((V)(PreInc(ref tid_21, 1D)));
args_333 = Invoke(Get(Get(G("Array"), "prototype"), "slice"), "call", _arguments331, ((V)(2D)));
T_334 = SetK(timers_22, id_332, NewObj(3).Put("ms", ms_330).Put("tick", Fn((V _self335, int _argc336, V _a338, V _a339, V _a340, V _a341, V[] _rest337) => {
if (_self335.IsNullish) _self335 = GlobalV;
if (!(Truthy(asleep_11))) {
Invoke(cb_329, "apply", W_8, args_333);
}
return default;
}, 0, "tick", false)).Put("iv", ((V)(0D))).V);
if (!(Truthy(asleep_11))) {
Set(T_334, "iv", Invoke(N_10, "setInterval", Get(T_334, "tick"), ms_330));
}
return id_332;
return default;
}, 2, "", false));
Set(W_8, "clearTimeout", Set(W_8, "clearInterval", Fn((V _self342, int _argc343, V id_349, V _a346, V _a347, V _a348, V[] _rest344) => {
V T_350 = default;
if (_self342.IsNullish) _self342 = GlobalV;
T_350 = GetK(timers_22, id_349);
if (!(Truthy(T_350))) {
if (Truthy((id_349 is var _t351 && !Truthy(_t351) ? _t351 : (LtN(id_349, 1000000000D) ? V.True : V.False)))) {
Invoke(N_10, "clearTimeout", id_349);
}
return default;
}
DeleteK(timers_22, id_349);
if (Truthy(Get(T_350, "tick"))) {
if (Truthy(Get(T_350, "iv"))) {
Invoke(N_10, "clearInterval", Get(T_350, "iv"));
}
} else {
if (Truthy(Get(T_350, "n"))) {
Invoke(N_10, "clearTimeout", Get(T_350, "n"));
}
}
return default;
}, 1, "", false)));
media_26 = (string.Equals(GTypeof("Set"), "function") ? New(G("Set")) : V.Null);
contexts_27 = Arr();
wantPlay_28 = Arr();
wantResume_29 = Arr();
MP_30 = (Get(W_8, "HTMLMediaElement") is var _t352 && !Truthy(_t352) ? _t352 : Get(Get(W_8, "HTMLMediaElement"), "prototype"));
if (Truthy((MP_30 is var _t353 && !Truthy(_t353) ? _t353 : media_26))) {
play_31 = Get(MP_30, "play");
Set(MP_30, "play", Fn((V _self354, int _argc355, V _a357, V _a358, V _a359, V _a360, V[] _rest356) => {
if (_self354.IsNullish) _self354 = GlobalV;
V _arguments361 = Arguments(_argc355, _a357, _a358, _a359, _a360, _rest356);
if (GtN(Get(media_26, "size"), 40D)) {
Invoke(media_26, "forEach", Fn((V _self362, int _argc363, V m_369, V _a366, V _a367, V _a368, V[] _rest364) => {
if (_self362.IsNullish) _self362 = GlobalV;
if (Truthy(((!(Truthy(Get(m_369, "isConnected"))) ? V.True : V.False) is var _t370 && !Truthy(_t370) ? _t370 : Get(m_369, "paused")))) {
Invoke(media_26, "delete", m_369);
}
return default;
}, 1, "", false));
}
Invoke(media_26, "add", _self354);
if (Truthy(asleep_11)) {
if (LtN(Invoke(wantPlay_28, "indexOf", _self354), 0D)) {
Invoke(wantPlay_28, "push", _self354);
}
return Invoke(G("Promise"), "resolve");
}
return Invoke(play_31, "apply", _self354, _arguments361);
return default;
}, 0, "", false));
Set(S_15, "_play", play_31);
}
Invoke(Arr(((V)("AudioContext")), ((V)("webkitAudioContext"))), "forEach", Fn((V _self371, int _argc372, V k_378, V _a375, V _a376, V _a377, V[] _rest373) => {
V C_379 = default;
V Wrapped_380 = default;
if (_self371.IsNullish) _self371 = GlobalV;
C_379 = GetK(W_8, k_378);
if (Truthy(((!string.Equals(Typeof(C_379), "function") ? V.True : V.False) is var _t381 && Truthy(_t381) ? _t381 : Get(C_379, "__sq")))) {
return default;
}
Wrapped_380 = Fn((V _self382, int _argc383, V _a385, V _a386, V _a387, V _a388, V[] _rest384) => {
V c_390 = default;
if (_self382.IsNullish) _self382 = GlobalV;
V _arguments389 = Arguments(_argc383, _a385, _a386, _a387, _a388, _rest384);
c_390 = New(Invoke(Get(Get(G("Function"), "prototype"), "bind"), "apply", C_379, Invoke(Arr(V.Null), "concat", Invoke(Get(Get(G("Array"), "prototype"), "slice"), "call", _arguments389))));
Invoke(contexts_27, "push", c_390);
if (Truthy((asleep_11 is var _t391 && !Truthy(_t391) ? _t391 : (SEqS(Get(c_390, "state"), "running") ? V.True : V.False)))) {
Invoke(c_390, "suspend");
Invoke(wantResume_29, "push", c_390);
}
return c_390;
return default;
}, 0, "", false);
Set(Wrapped_380, "prototype", Get(C_379, "prototype"));
Set(Wrapped_380, "__sq", (true ? V.True : V.False));
try {
SetK(W_8, k_378, Wrapped_380);
} catch (System.Exception _ex392) {
V e_393 = default;
e_393 = Caught(_ex392);

}
return default;
}, 1, "", false));
BAC_32 = (Get(W_8, "BaseAudioContext") is var _t394 && Truthy(_t394) ? _t394 : Get(W_8, "AudioContext"));
resume_33 = (BAC_32 is var _t395 && !Truthy(_t395) ? _t395 : Get(Get(BAC_32, "prototype"), "resume"));
if (Truthy(resume_33)) {
Set(Get(BAC_32, "prototype"), "resume", Fn((V _self396, int _argc397, V _a399, V _a400, V _a401, V _a402, V[] _rest398) => {
if (_self396.IsNullish) _self396 = GlobalV;
V _arguments403 = Arguments(_argc397, _a399, _a400, _a401, _a402, _rest398);
if (Truthy(asleep_11)) {
if (LtN(Invoke(wantResume_29, "indexOf", _self396), 0D)) {
Invoke(wantResume_29, "push", _self396);
}
return Invoke(G("Promise"), "resolve");
}
return Invoke(resume_33, "apply", _self396, _arguments403);
return default;
}, 0, "", false));
}
EP_34 = (Get(W_8, "Element") is var _t404 && !Truthy(_t404) ? _t404 : Get(Get(W_8, "Element"), "prototype"));
anims_35 = Arr();
if (Truthy((EP_34 is var _t405 && !Truthy(_t405) ? _t405 : Get(EP_34, "animate")))) {
animate_36 = Get(EP_34, "animate");
Set(EP_34, "animate", Fn((V _self406, int _argc407, V _a409, V _a410, V _a411, V _a412, V[] _rest408) => {
V a_414 = default;
if (_self406.IsNullish) _self406 = GlobalV;
V _arguments413 = Arguments(_argc407, _a409, _a410, _a411, _a412, _rest408);
a_414 = Invoke(animate_36, "apply", _self406, _arguments413);
if (Truthy(asleep_11)) {
try {
Invoke(a_414, "pause");
Invoke(anims_35, "push", a_414);
} catch (System.Exception _ex415) {
V e_416 = default;
e_416 = Caught(_ex415);

}
}
return a_414;
return default;
}, 0, "", false));
}
svgs_37 = Arr();
style_38 = V.Null;
Set(S_15, "set", Fn((V _self417, int _argc418, V on_424, V _a421, V _a422, V _a423, V[] _rest419) => {
if (_self417.IsNullish) _self417 = GlobalV;
if (Truthy(on_424)) {
Call(sleep_39, V.Undef);
} else {
Call(wake_40, V.Undef);
}
return default;
}, 1, "", false));
return default;
}, 0, "", false), V.Undef);
Call(Fn((V _self425, int _argc426, V _a428, V _a429, V _a430, V _a431, V[] _rest427) => {
V weak_432 = default;
V P_433 = default;
V t0_434 = default;
V n_435 = default;
V slow_436 = default;
V k_437 = default;
V last_438 = default;
V watching_439 = default;
V watch_440 = default;
V begin_441 = default;
V quiet_442 = default;
V scopes_443 = default;
V scopeName_444 = default;
V @base_445 = default;
V rc_446 = default;
V rn_447 = default;
V rt_448 = default;
V upTried_449 = default;
V trialUntil_450 = default;
V post_451 = default;
V stills_452 = default;
V SMIL1_453 = default;
V SMIL2_454 = default;
V mt_455 = default;
V mlast_456 = default;
V mn_457 = default;
V mworst_458 = default;
V mid_459 = default;
V meter_460 = default;
if (_self425.IsNullish) _self425 = GlobalV;
watch_440 = Fn((V _self461, int _argc462, V now_468, V _a465, V _a466, V _a467, V[] _rest463) => {
V back_469 = default;
V fps_470 = default;
V trial_471 = default;
if (_self461.IsNullish) _self461 = GlobalV;
if (GeN(Get(P_433, "step"), 3D)) {
watching_439 = (false ? V.True : V.False);
return default;
}
if (Truthy(Get(P_433, "freeze"))) {
watching_439 = (false ? V.True : V.False);
t0_434 = ((V)(0D));
slow_436 = ((V)(0D));
back_469 = Fn((V _self472, int _argc473, V _a475, V _a476, V _a477, V _a478, V[] _rest474) => {
if (_self472.IsNullish) _self472 = GlobalV;
if (Truthy(Get(P_433, "freeze"))) {
Call(G("setTimeout"), V.Undef, back_469, ((V)(250D)));
return default;
}
if ((!(Truthy(watching_439)) && LtN(Get(P_433, "step"), 3D))) {
watching_439 = (true ? V.True : V.False);
Call(G("requestAnimationFrame"), V.Undef, watch_440);
}
return default;
}, 0, "", false);
Call(G("setTimeout"), V.Undef, back_469, ((V)(250D)));
return default;
}
watching_439 = (true ? V.True : V.False);
Call(G("requestAnimationFrame"), V.Undef, watch_440);
if ((((ToNum(now_468) - ToNum(last_438)) > 1000D) || Lt(now_468, quiet_442))) {
t0_434 = ((V)(0D));
}
last_438 = now_468;
if (!(Truthy(t0_434))) {
t0_434 = now_468;
n_435 = ((V)(0D));
return default;
}
PostInc(ref n_435, 1D);
if (((ToNum(now_468) - ToNum(t0_434)) < 1000D)) {
return default;
}
fps_470 = ((V)(((ToNum(n_435) * 1000D) / (ToNum(now_468) - ToNum(t0_434)))));
Set(P_433, "fps", fps_470);
t0_434 = now_468;
n_435 = ((V)(0D));
trial_471 = ((SEqN(Get(P_433, "step"), 1D) ? V.True : V.False) is var _t481 && !Truthy(_t481) ? _t481 : ((Lt(now_468, trialUntil_450) ? V.True : V.False) is var _t480 && Truthy(_t480) ? _t480 : ((SEqS(scopeName_444, "house") ? V.True : V.False) is var _t479 && !Truthy(_t479) ? _t479 : Get(upTried_449, "house"))));
slow_436 = (LtN(fps_470, (Truthy(trial_471) ? 58D : (SEqN(Get(P_433, "step"), 1D) ? 55D : 45D))) ? Add(slow_436, ((V)(1D))) : ((V)(0D)));
if (GeN(slow_436, (Truthy(trial_471) ? 1D : (SEqN(Get(P_433, "step"), 1D) ? 2D : 3D)))) {
trialUntil_450 = ((V)(0D));
IncM(P_433, "step", 1D, false);
slow_436 = ((V)(0D));
try {
Invoke(G("localStorage"), "setItem", ((V)("sq.perfStep")), Invoke(G("JSON"), "stringify", NewObj(2).Put("step", Get(P_433, "step")).Put("t", Invoke(G("Date"), "now")).V));
} catch (System.Exception _ex482) {
V e_483 = default;
e_483 = Caught(_ex482);

}
}
return default;
}, 1, "watch", false);
begin_441 = Fn((V _self484, int _argc485, V _a487, V _a488, V _a489, V _a490, V[] _rest486) => {
if (_self484.IsNullish) _self484 = GlobalV;
Call(G("setTimeout"), V.Undef, Fn((V _self498, int _argc499, V _a501, V _a502, V _a503, V _a504, V[] _rest500) => {
if (_self498.IsNullish) _self498 = GlobalV;
if (!(Truthy(watching_439))) {
watching_439 = (true ? V.True : V.False);
Call(G("requestAnimationFrame"), V.Undef, watch_440);
}
return default;
}, 0, "", false), ((V)(4000D)));
return default;
}, 0, "begin", false);
meter_460 = Fn((V _self505, int _argc506, V now_512, V _a509, V _a510, V _a511, V[] _rest507) => {
V dt_513 = default;
V m_514 = default;
if (_self505.IsNullish) _self505 = GlobalV;
mid_459 = Call(G("requestAnimationFrame"), V.Undef, meter_460);
if (!(Truthy(mt_455))) {
mt_455 = (mlast_456 = now_512);
mn_457 = ((V)(0D));
mworst_458 = ((V)(0D));
return default;
}
dt_513 = ((V)((ToNum(now_512) - ToNum(mlast_456))));
mlast_456 = now_512;
PostInc(ref mn_457, 1D);
if (Gt(dt_513, mworst_458)) {
mworst_458 = dt_513;
}
if (((ToNum(now_512) - ToNum(mt_455)) < 500D)) {
return default;
}
m_514 = NewObj(3).Put("fps", ((V)(Round(((ToNum(mn_457) * 1000D) / (ToNum(now_512) - ToNum(mt_455))))))).Put("low", ((V)(Round((1000D / Max(ToNum(mworst_458), 1D)))))).Put("lite", (GtN(Get(P_433, "step"), 1D) ? V.True : V.False)).V;
mt_455 = now_512;
mn_457 = ((V)(0D));
mworst_458 = ((V)(0D));
if (Truthy(Get(G("window"), "ReactNativeWebView"))) {
Invoke(Get(G("window"), "ReactNativeWebView"), "postMessage", Invoke(G("JSON"), "stringify", NewObj(2).Put("type", ((V)("fps"))).Put("payload", m_514).V));
}
return default;
}, 1, "meter", false);
weak_432 = ((Get(G("navigator"), "deviceMemory") is var _t515 && !Truthy(_t515) ? _t515 : (LeN(Get(G("navigator"), "deviceMemory"), 2D) ? V.True : V.False)) is var _t517 && Truthy(_t517) ? _t517 : (Get(G("navigator"), "hardwareConcurrency") is var _t516 && !Truthy(_t516) ? _t516 : (LeN(Get(G("navigator"), "hardwareConcurrency"), 2D) ? V.True : V.False)));
P_433 = Set(G("window"), "SquishPerf", NewObj(2).Put("step", ((V)((Truthy(weak_432) ? 2D : 1D)))).Put("fps", ((V)(0D))).V);
Object_defineProperty(P_433, ((V)("half")), NewObj(1).Put("get", Fn((V _self518, int _argc519, V _a521, V _a522, V _a523, V _a524, V[] _rest520) => {
if (_self518.IsNullish) _self518 = GlobalV;
return (GtN(Get(P_433, "step"), 1D) ? V.True : V.False);
return default;
}, 0, "get", false)).V);
t0_434 = ((V)(0D));
n_435 = ((V)(0D));
slow_436 = ((V)(0D));
k_437 = ((V)(0D));
last_438 = ((V)(0D));
watching_439 = (false ? V.True : V.False);
if (SEqS(Get(G("document"), "readyState"), "complete")) {
Call(begin_441, V.Undef);
} else {
Invoke(G("window"), "addEventListener", ((V)("load")), begin_441);
}
Invoke(G("document"), "addEventListener", ((V)("visibilitychange")), Fn((V _self525, int _argc526, V _a528, V _a529, V _a530, V _a531, V[] _rest527) => {
if (_self525.IsNullish) _self525 = GlobalV;
t0_434 = ((V)(0D));
slow_436 = ((V)(0D));
mt_455 = ((V)(0D));
return default;
}, 0, "", false));
quiet_442 = ((V)(0D));
if (Truthy(Get(G("window"), "SquishSleep"))) {
Invoke(Get(G("window"), "SquishSleep"), "on", Fn((V _self532, int _argc533, V on_539, V _a536, V _a537, V _a538, V[] _rest534) => {
if (_self532.IsNullish) _self532 = GlobalV;
t0_434 = ((V)(0D));
slow_436 = ((V)(0D));
mt_455 = ((V)(0D));
if (!(Truthy(on_539))) {
quiet_442 = Add(Invoke(G("performance"), "now"), ((V)(2500D)));
}
return default;
}, 1, "", false));
}
Set(P_433, "quiet", Fn((V _self540, int _argc541, V ms_547, V _a544, V _a545, V _a546, V[] _rest542) => {
if (_self540.IsNullish) _self540 = GlobalV;
quiet_442 = ((V)(Max(ToNum(quiet_442), ToNum(Add(Invoke(G("performance"), "now"), (ms_547 is var _t548 && Truthy(_t548) ? _t548 : ((V)(0D))))))));
t0_434 = ((V)(0D));
slow_436 = ((V)(0D));
return default;
}, 1, "", false));
scopes_443 = NewObj(0).V;
scopeName_444 = ((V)("menu"));
@base_445 = Get(P_433, "step");
Set(P_433, "scope", Fn((V _self549, int _argc550, V name_556, V _a553, V _a554, V _a555, V[] _rest551) => {
if (_self549.IsNullish) _self549 = GlobalV;
if ((!(Truthy(name_556)) || SEq(name_556, scopeName_444))) {
return default;
}
SetK(scopes_443, scopeName_444, Get(P_433, "step"));
scopeName_444 = name_556;
Set(P_433, "step", (GetK(scopes_443, name_556) is var _t557 && Truthy(_t557) ? _t557 : (SEqS(name_556, "house") ? ((V)(Max(ToNum(@base_445), 2D))) : @base_445)));
t0_434 = ((V)(0D));
slow_436 = ((V)(0D));
rc_446 = ((V)(0D));
rn_447 = ((V)(0D));
trialUntil_450 = ((V)(0D));
quiet_442 = ((V)(Max(ToNum(quiet_442), ToNum(Add(Invoke(G("performance"), "now"), ((V)(1500D)))))));
if (((LtN(Get(P_433, "step"), 3D) && !(Truthy(watching_439))) && SEqS(Get(G("document"), "readyState"), "complete"))) {
watching_439 = (true ? V.True : V.False);
Call(G("requestAnimationFrame"), V.Undef, watch_440);
}
return default;
}, 1, "", false));
Set(P_433, "skipRig", Fn((V _self558, int _argc559, V _a561, V _a562, V _a563, V _a564, V[] _rest560) => {
if (_self558.IsNullish) _self558 = GlobalV;
if (SEqN(Get(P_433, "step"), 1D)) {
return (false ? V.True : V.False);
}
k_437 = ((V)((ToNum(Add(k_437, ((V)(1D)))) % ToNum(Get(P_433, "step")))));
return (!SEqN(k_437, 0D) ? V.True : V.False);
return default;
}, 0, "", false));
Set(P_433, "rigStride", Fn((V _self565, int _argc566, V _a568, V _a569, V _a570, V _a571, V[] _rest567) => {
if (_self565.IsNullish) _self565 = GlobalV;
return Get(P_433, "step");
return default;
}, 0, "", false));
Set(P_433, "freeze", (false ? V.True : V.False));
rc_446 = ((V)(0D));
rn_447 = ((V)(0D));
rt_448 = ((V)(0D));
upTried_449 = NewObj(0).V;
trialUntil_450 = ((V)(0D));
Set(P_433, "rigCost", Fn((V _self572, int _argc573, V ms_579, V N_580, V _a577, V _a578, V[] _rest574) => {
V now_581 = default;
if (_self572.IsNullish) _self572 = GlobalV;
if (Truthy((((!SEqN(Get(P_433, "step"), 2D) ? V.True : V.False) is var _t582 && Truthy(_t582) ? _t582 : GetK(upTried_449, scopeName_444)) is var _t583 && Truthy(_t583) ? _t583 : (Lt(Invoke(G("performance"), "now"), quiet_442) ? V.True : V.False)))) {
rc_446 = ((V)(0D));
rn_447 = ((V)(0D));
rt_448 = ((V)(0D));
return default;
}
now_581 = Invoke(G("performance"), "now");
if (!(Truthy(rt_448))) {
rt_448 = now_581;
}
rc_446 = Add(rc_446, ((V)((ToNum(ms_579) * ToNum(N_580)))));
PostInc(ref rn_447, 1D);
if (((ToNum(now_581) - ToNum(rt_448)) < 3000D)) {
return default;
}
if ((GtN(rn_447, 60D) && ((ToNum(rc_446) / ToNum(rn_447)) < 7D))) {
SetK(upTried_449, scopeName_444, (true ? V.True : V.False));
Set(P_433, "step", ((V)(1D)));
slow_436 = ((V)(0D));
t0_434 = ((V)(0D));
trialUntil_450 = Add(now_581, ((V)(6000D)));
if (!(Truthy(watching_439))) {
watching_439 = (true ? V.True : V.False);
Call(G("requestAnimationFrame"), V.Undef, watch_440);
}
}
rc_446 = ((V)(0D));
rn_447 = ((V)(0D));
rt_448 = now_581;
return default;
}, 2, "", false));
post_451 = Call(Fn((V _self584, int _argc585, V _a587, V _a588, V _a589, V _a590, V[] _rest586) => {
V q_591 = default;
V ch_592 = default;
if (_self584.IsNullish) _self584 = GlobalV;
if (!string.Equals(GTypeof("MessageChannel"), "function")) {
return Fn((V _self593, int _argc594, V f_600, V _a597, V _a598, V _a599, V[] _rest595) => {
if (_self593.IsNullish) _self593 = GlobalV;
Call(G("setTimeout"), V.Undef, f_600, ((V)(0D)));
return default;
}, 1, "", false);
}
q_591 = Arr();
ch_592 = New(G("MessageChannel"));
Set(Get(ch_592, "port1"), "onmessage", Fn((V _self601, int _argc602, V _a604, V _a605, V _a606, V _a607, V[] _rest603) => {
V f_608 = default;
if (_self601.IsNullish) _self601 = GlobalV;
f_608 = Invoke(q_591, "shift");
if (Truthy(f_608)) {
Call(f_608, V.Undef);
}
return default;
}, 0, "", false));
return Fn((V _self609, int _argc610, V f_616, V _a613, V _a614, V _a615, V[] _rest611) => {
if (_self609.IsNullish) _self609 = GlobalV;
Invoke(q_591, "push", f_616);
Invoke(Get(ch_592, "port2"), "postMessage", ((V)(0D)));
return default;
}, 1, "", false);
return default;
}, 0, "", false), V.Undef);
Set(P_433, "post", post_451);
Set(P_433, "painted", Fn((V _self617, int _argc618, V fn_624, V _a621, V _a622, V _a623, V[] _rest619) => {
if (_self617.IsNullish) _self617 = GlobalV;
Call(G("requestAnimationFrame"), V.Undef, Fn((V _self632, int _argc633, V _a635, V _a636, V _a637, V _a638, V[] _rest634) => {
if (_self632.IsNullish) _self632 = GlobalV;
Call(post_451, V.Undef, fn_624);
return default;
}, 0, "", false));
return default;
}, 1, "", false));
stills_452 = (string.Equals(GTypeof("Map"), "function") ? New(G("Map")) : V.Null);
SMIL1_453 = NewRegExp(RX0, "<(animate|animateTransform|animateMotion|animateColor|set)\\b[^>]*\\/>", "g");
SMIL2_454 = NewRegExp(RX1, "<(animate|animateTransform|animateMotion|animateColor)\\b[^>]*>[\\s\\S]*?<\\/\\1>", "g");
Set(G("window"), "SquishStill", Fn((V _self639, int _argc640, V src_646, V _a643, V _a644, V _a645, V[] _rest641) => {
V @out_647 = default;
V i_648 = default;
V head_649 = default;
V body_650 = default;
V enc_651 = default;
V svg_652 = default;
if (_self639.IsNullish) _self639 = GlobalV;
if (((!(Truthy(src_646)) || !string.Equals(Typeof(src_646), "string")) || !SEqN(Invoke(src_646, "indexOf", ((V)("data:image/svg+xml"))), 0D))) {
return src_646;
}
if ((((LtN(Invoke(src_646, "indexOf", ((V)("%3Canimate"))), 0D) && LtN(Invoke(src_646, "indexOf", ((V)("%3Cset"))), 0D)) && LtN(Invoke(src_646, "indexOf", ((V)("<animate"))), 0D)) && LtN(Invoke(src_646, "indexOf", ((V)("<set"))), 0D))) {
return src_646;
}
if (Truthy((stills_452 is var _t653 && !Truthy(_t653) ? _t653 : Invoke(stills_452, "has", src_646)))) {
return Invoke(stills_452, "get", src_646);
}
@out_647 = src_646;
try {
i_648 = Invoke(src_646, "indexOf", ((V)(",")));
head_649 = Invoke(src_646, "slice", ((V)(0D)), Add(i_648, ((V)(1D))));
body_650 = Invoke(src_646, "slice", Add(i_648, ((V)(1D))));
enc_651 = Invoke(NewRegExp(RX2, "%[0-9a-fA-F]{2}", ""), "test", body_650);
svg_652 = (Truthy(enc_651) ? Call(G("decodeURIComponent"), V.Undef, body_650) : body_650);
svg_652 = Invoke(Invoke(svg_652, "replace", SMIL1_453, ((V)(""))), "replace", SMIL2_454, ((V)("")));
@out_647 = Add(head_649, (Truthy(enc_651) ? Call(G("encodeURIComponent"), V.Undef, svg_652) : svg_652));
} catch (System.Exception _ex654) {
V e_655 = default;
e_655 = Caught(_ex654);
@out_647 = src_646;
}
if (Truthy(stills_452)) {
if (GtN(Get(stills_452, "size"), 400D)) {
Invoke(stills_452, "clear");
}
Invoke(stills_452, "set", src_646, @out_647);
}
return @out_647;
return default;
}, 1, "", false));
Set(P_433, "steady", Fn((V _self656, int _argc657, V fn_663, V max_664, V n_665, V _a662, V[] _rest658) => {
V start_666 = default;
V last_667 = default;
V good_668 = default;
V done_669 = default;
V go_670 = default;
V f_671 = default;
if (_self656.IsNullish) _self656 = GlobalV;
go_670 = Fn((V _self672, int _argc673, V _a675, V _a676, V _a677, V _a678, V[] _rest674) => {
if (_self672.IsNullish) _self672 = GlobalV;
if (Truthy(done_669)) {
return default;
}
done_669 = (true ? V.True : V.False);
Call(fn_663, V.Undef);
return default;
}, 0, "go", false);
f_671 = Fn((V _self679, int _argc680, V now_686, V _a683, V _a684, V _a685, V[] _rest681) => {
if (_self679.IsNullish) _self679 = GlobalV;
if (Truthy(done_669)) {
return default;
}
if (Truthy((last_667 is var _t687 && !Truthy(_t687) ? _t687 : (((ToNum(now_686) - ToNum(last_667)) < 34D) ? V.True : V.False)))) {
PostInc(ref good_668, 1D);
} else {
good_668 = ((V)(0D));
}
last_667 = now_686;
if ((Ge(good_668, n_665) || Gt(((V)((ToNum(now_686) - ToNum(start_666)))), max_664))) {
Call(go_670, V.Undef);
} else {
Call(G("requestAnimationFrame"), V.Undef, f_671);
}
return default;
}, 1, "f", false);
max_664 = (max_664 is var _t688 && Truthy(_t688) ? _t688 : ((V)(2000D)));
n_665 = (n_665 is var _t689 && Truthy(_t689) ? _t689 : ((V)(3D)));
start_666 = Invoke(G("performance"), "now");
last_667 = ((V)(0D));
good_668 = ((V)(0D));
done_669 = (false ? V.True : V.False);
Call(G("requestAnimationFrame"), V.Undef, f_671);
return default;
}, 3, "", false));
Set(P_433, "slices", Fn((V _self690, int _argc691, V steps_697, V budget_698, V _a695, V _a696, V[] _rest692) => {
V i_699 = default;
if (_self690.IsNullish) _self690 = GlobalV;
budget_698 = (budget_698 is var _t700 && Truthy(_t700) ? _t700 : ((V)(6D)));
i_699 = ((V)(0D));
return New(G("Promise"), Fn((V _self701, int _argc702, V res_708, V _a705, V _a706, V _a707, V[] _rest703) => {
V run_709 = default;
if (_self701.IsNullish) _self701 = GlobalV;
run_709 = Fn((V _self710, int _argc711, V _a713, V _a714, V _a715, V _a716, V[] _rest712) => {
V t0_717 = default;
V r_718 = default;
if (_self710.IsNullish) _self710 = GlobalV;
t0_717 = Invoke(G("performance"), "now");
while (Lt(i_699, Get(steps_697, "length"))) {

try {
r_718 = InvokeK(steps_697, ((V)(PostInc(ref i_699, 1D))));
} catch (System.Exception _ex719) {
V e_720 = default;
e_720 = Caught(_ex719);
Invoke(G("console"), "error", ((V)("[SquishPerf.slices]")), e_720);
}
if (SEq(r_718, (false ? V.True : V.False))) {
i_699 = Get(steps_697, "length");
break;
}
if (Gt(((V)((ToNum(Invoke(G("performance"), "now")) - ToNum(t0_717)))), budget_698)) {
break;
}
}
if (Lt(i_699, Get(steps_697, "length"))) {
Invoke(P_433, "painted", run_709);
} else {
Call(res_708, V.Undef);
}
return default;
}, 0, "run", false);
Invoke(P_433, "painted", run_709);
return default;
}, 1, "", false));
return default;
}, 2, "", false));
mt_455 = ((V)(0D));
mlast_456 = ((V)(0D));
mn_457 = ((V)(0D));
mworst_458 = ((V)(0D));
mid_459 = ((V)(0D));
Set(P_433, "meter", Fn((V _self721, int _argc722, V on_728, V _a725, V _a726, V _a727, V[] _rest723) => {
if (_self721.IsNullish) _self721 = GlobalV;
if (Truthy((on_728 is var _t729 && !Truthy(_t729) ? _t729 : (!(Truthy(mid_459)) ? V.True : V.False)))) {
mt_455 = ((V)(0D));
mid_459 = Call(G("requestAnimationFrame"), V.Undef, meter_460);
} else {
if (Truthy(((!(Truthy(on_728)) ? V.True : V.False) is var _t730 && !Truthy(_t730) ? _t730 : mid_459))) {
Call(G("cancelAnimationFrame"), V.Undef, mid_459);
mid_459 = ((V)(0D));
}
}
return default;
}, 1, "", false));
return default;
}, 0, "", false), V.Undef);
Call(Fn((V _self731, int _argc732, V _a734, V _a735, V _a736, V _a737, V[] _rest733) => {
V pend_738 = default;
V done_739 = default;
V TABLE_740 = default;
V wrap_741 = default;
if (_self731.IsNullish) _self731 = GlobalV;
wrap_741 = Fn((V _self742, int _argc743, V fn_749, V H_750, V name_751, V _a748, V[] _rest744) => {
if (_self742.IsNullish) _self742 = GlobalV;
return Fn((V _self752, int _argc753, V key_759, V X_760, V _a757, V _a758, V[] _rest754) => {
V self_762 = default;
V args_763 = default;
V T_764 = default;
if (_self752.IsNullish) _self752 = GlobalV;
V _arguments761 = Arguments(_argc753, key_759, X_760, _a757, _a758, _rest754);
if (Truthy((((key_759.IsNullish || SEqS(key_759, "")) ? V.True : V.False) is var _t765 && Truthy(_t765) ? _t765 : GetK(done_739, key_759)))) {
return Invoke(fn_749, "apply", _self752, _arguments761);
}
self_762 = _self752;
args_763 = _arguments761;
T_764 = GetK(H_750, GetK(TABLE_740, name_751));
if (Truthy((T_764 is var _t766 && !Truthy(_t766) ? _t766 : (!(HasProperty(T_764, key_759)) ? V.True : V.False)))) {
SetK(T_764, key_759, (X_760 is var _t767 && Truthy(_t767) ? _t767 : NewObj(0).V));
}
Invoke((GetK(pend_738, key_759) is var _t775 && Truthy(_t775) ? _t775 : SetK(pend_738, key_759, Arr())), "push", Fn((V _self768, int _argc769, V _a771, V _a772, V _a773, V _a774, V[] _rest770) => {
if (_self768.IsNullish) _self768 = GlobalV;
Invoke(fn_749, "apply", self_762, args_763);
return default;
}, 0, "", false));
return default;
}, 2, "", false);
return default;
}, 3, "wrap", false);
pend_738 = NewObj(0).V;
done_739 = NewObj(0).V;
TABLE_740 = NewObj(6).Put("build", ((V)("PROF"))).Put("bedBuild", ((V)("BED"))).Put("waterBuild", ((V)("WAT"))).Put("playBuild", ((V)("PLY"))).Put("bBuild", ((V)("BB"))).Put("cBuild", ((V)("CX"))).V;
Set(G("window"), "SquishLazy", NewObj(3).Put("house", Fn((V _self776, int _argc777, V H_783, V _a780, V _a781, V _a782, V[] _rest778) => {
V cb_784 = default;
if (_self776.IsNullish) _self776 = GlobalV;
Invoke(Arr(((V)("build")), ((V)("bedBuild")), ((V)("waterBuild")), ((V)("playBuild")), ((V)("bBuild"))), "forEach", Fn((V _self785, int _argc786, V n_792, V _a789, V _a790, V _a791, V[] _rest787) => {
if (_self785.IsNullish) _self785 = GlobalV;
if (string.Equals(Typeof(GetK(H_783, n_792)), "function")) {
SetK(H_783, n_792, Call(wrap_741, V.Undef, GetK(H_783, n_792), H_783, n_792));
}
return default;
}, 1, "", false));
cb_784 = (string.Equals(Typeof(Get(H_783, "cBuild")), "function") ? Call(wrap_741, V.Undef, Get(H_783, "cBuild"), H_783, ((V)("cBuild"))) : Get(H_783, "cBuild"));
Object_defineProperty(H_783, ((V)("cBuild")), NewObj(4).Put("configurable", (true ? V.True : V.False)).Put("enumerable", (true ? V.True : V.False)).Put("get", Fn((V _self793, int _argc794, V _a796, V _a797, V _a798, V _a799, V[] _rest795) => {
if (_self793.IsNullish) _self793 = GlobalV;
return cb_784;
return default;
}, 0, "get", false)).Put("set", Fn((V _self800, int _argc801, V f_807, V _a804, V _a805, V _a806, V[] _rest802) => {
if (_self800.IsNullish) _self800 = GlobalV;
cb_784 = (string.Equals(Typeof(f_807), "function") ? Call(wrap_741, V.Undef, f_807, H_783, ((V)("cBuild"))) : f_807);
return default;
}, 1, "set", false)).V);
return default;
}, 1, "house", false)).Put("need", Fn((V _self808, int _argc809, V key_815, V _a812, V _a813, V _a814, V[] _rest810) => {
V q_816 = default;
if (_self808.IsNullish) _self808 = GlobalV;
if (Truthy(((!(Truthy(key_815)) ? V.True : V.False) is var _t817 && Truthy(_t817) ? _t817 : GetK(done_739, key_815)))) {
return default;
}
SetK(done_739, key_815, ((V)(1D)));
q_816 = GetK(pend_738, key_815);
if (!(Truthy(q_816))) {
return default;
}
DeleteK(pend_738, key_815);
Invoke(q_816, "forEach", Fn((V _self818, int _argc819, V f_825, V _a822, V _a823, V _a824, V[] _rest820) => {
if (_self818.IsNullish) _self818 = GlobalV;
try {
Call(f_825, V.Undef);
} catch (System.Exception _ex826) {
V e_827 = default;
e_827 = Caught(_ex826);
Invoke(G("console"), "error", ((V)("[SquishLazy]")), key_815, e_827);
}
return default;
}, 1, "", false));
return default;
}, 1, "need", false)).Put("pending", Fn((V _self828, int _argc829, V _a831, V _a832, V _a833, V _a834, V[] _rest830) => {
if (_self828.IsNullish) _self828 = GlobalV;
return Get(Object_keys(pend_738), "length");
return default;
}, 0, "pending", false)).V);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
