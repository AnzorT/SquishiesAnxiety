// movie-night.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_movie_night_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
double BEAT_8 = 0;
double DIM_9 = 0;
double AD_10 = 0;
double UP_11 = 0;
double STEP_12 = 0;
V INK_13 = default;
V NOTE_14 = default;
V NC_15 = default;
V csrc_16 = default;
V cl_17 = default;
V E_18 = default;
V P_19 = default;
V A_20 = default;
V CUR_21 = default;
V ac_22 = default;
V mtof_23 = default;
V env_24 = default;
V tone_25 = default;
V noise_26 = default;
V kick_27 = default;
V snare_28 = default;
V hat_29 = default;
V bass_30 = default;
V lead_31 = default;
V bell_32 = default;
V chord_33 = default;
V crash_34 = default;
V squishS_35 = default;
V PROG_36 = default;
V MEL_37 = default;
V groove_38 = default;
V K_39 = default;
V J_40 = default;
V startJam_41 = default;
V stopJam_42 = default;
V resetEl_43 = default;
V toggle_44 = default;
V stop_45 = default;
V TH_46 = default;
V L_47 = default;
V RM_48 = default;
V prevReady_49 = default;
V SH_50 = default;
V ART_51 = default;
V FZ_52 = default;
double FZD_53 = 0;
V noProp_54 = default;
V el_55 = default;
V nodes_56 = default;
V ovl_57 = default;
V focus_58 = default;
V fsApi_59 = default;
V fzOff_60 = default;
V fzEnd_61 = default;
V bk_62 = default;
V fzStep_63 = default;
V theater_64 = default;
V centerOf_65 = default;
V quad_66 = default;
V hull_67 = default;
V ML_68 = default;
V AdMv_69 = default;
V lsG_70 = default;
V lsS_71 = default;
V fmt_72 = default;
V REACT_73 = default;
V CAST_74 = default;
V unlocked_75 = default;
V pickMv_76 = default;
V mkFilm_77 = default;
V mkBus_78 = default;
V killBus_79 = default;
V idxOf_80 = default;
V savePos_81 = default;
V play_82 = default;
V setPause_83 = default;
V sched_84 = default;
V cues_85 = default;
V popOut_86 = default;
V confetti_87 = default;
V stopShow_88 = default;
V ICON_89 = default;
V mkUI_90 = default;
V menu_91 = default;
V uiUpd_92 = default;
V adAudio_93 = default;
V OUT_94 = default;
V mkVideo_95 = default;
V RAF_96 = default;
V TO_97 = default;
V loop_98 = default;
V spawn_99 = default;
V bounce_100 = default;
V frame_101 = default;
V subs_102 = default;
V emit_103 = default;
if (_self1.IsNullish) _self1 = GlobalV;
ac_22 = Fn((V _self104, int _argc105, V _a107, V _a108, V _a109, V _a110, V[] _rest106) => {
V AC_111 = default;
V c_112 = default;
V comp_113 = default;
V n_114 = default;
V b_115 = default;
V d_116 = default;
if (_self104.IsNullish) _self104 = GlobalV;
if (Truthy(Get(A_20, "ctx"))) {
if (SEqS(Get(Get(A_20, "ctx"), "state"), "suspended")) {
Invoke(Get(A_20, "ctx"), "resume");
}
return Get(A_20, "ctx");
}
AC_111 = (Get(G("window"), "AudioContext") is var _t117 && Truthy(_t117) ? _t117 : Get(G("window"), "webkitAudioContext"));
if (!(Truthy(AC_111))) {
return V.Null;
}
c_112 = Set(A_20, "ctx", New(AC_111));
comp_113 = Invoke(c_112, "createDynamicsCompressor");
Set(Get(comp_113, "threshold"), "value", ((V)((-14D))));
Set(Get(comp_113, "ratio"), "value", ((V)(4D)));
Invoke(comp_113, "connect", Get(c_112, "destination"));
Set(A_20, "out", Invoke(c_112, "createGain"));
Set(Get(Get(A_20, "out"), "gain"), "value", ((V)(0.5)));
Invoke(Get(A_20, "out"), "connect", comp_113);
n_114 = Get(c_112, "sampleRate");
b_115 = Invoke(c_112, "createBuffer", ((V)(1D)), n_114, n_114);
d_116 = Invoke(b_115, "getChannelData", ((V)(0D)));
{
double i_118 = 0;
i_118 = 0D;
while (true) {
if (!(Lt(((V)(i_118)), n_114))) break;
SetIdx(d_116, i_118, ((V)(((ToNum(Invoke(G("Math"), "random")) * 2D) - 1D))));
i_118++;
}
}
Set(A_20, "nb", b_115);
return c_112;
return default;
}, 0, "ac", false);
env_24 = Fn((V _self120, int _argc121, V g_127, V t_128, V v_129, V at_130, V[] _rest122) => {
V dur_131 = default;
V sus_132 = default;
if (_self120.IsNullish) _self120 = GlobalV;
dur_131 = (_argc121 > 4 ? _rest122[0] : V.Undef);
sus_132 = (_argc121 > 5 ? _rest122[1] : V.Undef);
Invoke(Get(g_127, "gain"), "setValueAtTime", ((V)(0.0001)), t_128);
Invoke(Get(g_127, "gain"), "exponentialRampToValueAtTime", ((V)(Max(ToNum(v_129), 0.0002))), Add(t_128, at_130));
if (Truthy(sus_132)) {
double h_133 = 0;
h_133 = Max(ToNum(Add(t_128, at_130)), ToNum(Add(t_128, ((V)((ToNum(dur_131) * 0.72))))));
Invoke(Get(g_127, "gain"), "setValueAtTime", ((V)(Max(ToNum(v_129), 0.0002))), ((V)(h_133)));
}
Invoke(Get(g_127, "gain"), "exponentialRampToValueAtTime", ((V)(0.0001)), Add(t_128, dur_131));
return default;
}, 6, "env", false);
tone_25 = Fn((V _self134, int _argc135, V t_141, V f_142, V dur_143, V _a140, V[] _rest136) => {
V c_146 = default;
V os_147 = default;
V g_148 = default;
V node_149 = default;
V o_145 = default;
if (_self134.IsNullish) _self134 = GlobalV;
{ V _t144 = _a140; if (_t144.IsUndef) _t144 = NewObj(0).V;
o_145 = _t144; }
c_146 = Get(A_20, "ctx");
if (!(Truthy(c_146))) {
return default;
}
os_147 = Invoke(c_146, "createOscillator");
g_148 = Invoke(c_146, "createGain");
Set(os_147, "type", (Get(o_145, "type") is var _t150 && Truthy(_t150) ? _t150 : ((V)("sine"))));
Invoke(Get(os_147, "frequency"), "setValueAtTime", f_142, t_141);
if (Truthy(Get(o_145, "to"))) {
Invoke(Get(os_147, "frequency"), "exponentialRampToValueAtTime", Get(o_145, "to"), Add(t_141, (Get(o_145, "slide") is var _t151 && Truthy(_t151) ? _t151 : dur_143)));
}
if (Truthy(Get(o_145, "vib"))) {
V lf_152 = default;
V lg_153 = default;
lf_152 = Invoke(c_146, "createOscillator");
lg_153 = Invoke(c_146, "createGain");
Set(Get(lf_152, "frequency"), "value", GetIdx(Get(o_145, "vib"), 0D));
Invoke(Get(lg_153, "gain"), "setValueAtTime", ((V)(0D)), t_141);
Invoke(Get(lg_153, "gain"), "linearRampToValueAtTime", GetIdx(Get(o_145, "vib"), 1D), Add(t_141, ((V)(Min(0.35, (ToNum(dur_143) * 0.4))))));
Invoke(lf_152, "connect", lg_153);
Invoke(lg_153, "connect", Get(os_147, "frequency"));
Invoke(lf_152, "start", t_141);
Invoke(lf_152, "stop", Add(Add(t_141, dur_143), ((V)(0.05))));
}
node_149 = os_147;
if (Truthy(Get(o_145, "lp"))) {
V lp_154 = default;
lp_154 = Invoke(c_146, "createBiquadFilter");
Set(lp_154, "type", ((V)("lowpass")));
Set(Get(lp_154, "frequency"), "value", Get(o_145, "lp"));
Invoke(os_147, "connect", lp_154);
node_149 = lp_154;
}
Invoke(node_149, "connect", g_148);
Invoke(g_148, "connect", (CUR_21 is var _t155 && Truthy(_t155) ? _t155 : Get(A_20, "out")));
Call(env_24, V.Undef, g_148, t_141, (Get(o_145, "vol") is var _t156 && Truthy(_t156) ? _t156 : ((V)(0.2))), (Get(o_145, "at") is var _t157 && Truthy(_t157) ? _t157 : ((V)(0.005))), dur_143, Get(o_145, "sus"));
Invoke(os_147, "start", t_141);
Invoke(os_147, "stop", Add(Add(t_141, dur_143), ((V)(0.05))));
return default;
}, 4, "tone", false);
noise_26 = Fn((V _self158, int _argc159, V t_165, V dur_166, V _a163, V _a164, V[] _rest160) => {
V c_169 = default;
V s_170 = default;
V f_171 = default;
V g_172 = default;
V o_168 = default;
if (_self158.IsNullish) _self158 = GlobalV;
{ V _t167 = _a163; if (_t167.IsUndef) _t167 = NewObj(0).V;
o_168 = _t167; }
c_169 = Get(A_20, "ctx");
if (!(Truthy(c_169))) {
return default;
}
s_170 = Invoke(c_169, "createBufferSource");
Set(s_170, "buffer", Get(A_20, "nb"));
f_171 = Invoke(c_169, "createBiquadFilter");
Set(f_171, "type", (Get(o_168, "ft") is var _t173 && Truthy(_t173) ? _t173 : ((V)("highpass"))));
Invoke(Get(f_171, "frequency"), "setValueAtTime", (Get(o_168, "f") is var _t174 && Truthy(_t174) ? _t174 : ((V)(6000D))), t_165);
if (Truthy(Get(o_168, "fTo"))) {
Invoke(Get(f_171, "frequency"), "exponentialRampToValueAtTime", Get(o_168, "fTo"), Add(t_165, dur_166));
}
Set(Get(f_171, "Q"), "value", (Get(o_168, "q") is var _t175 && Truthy(_t175) ? _t175 : ((V)(0.7))));
g_172 = Invoke(c_169, "createGain");
Invoke(s_170, "connect", f_171);
Invoke(f_171, "connect", g_172);
Invoke(g_172, "connect", (CUR_21 is var _t176 && Truthy(_t176) ? _t176 : Get(A_20, "out")));
Call(env_24, V.Undef, g_172, t_165, (Get(o_168, "vol") is var _t177 && Truthy(_t177) ? _t177 : ((V)(0.1))), (Get(o_168, "at") is var _t178 && Truthy(_t178) ? _t178 : ((V)(0.002))), dur_166, Get(o_168, "sus"));
Invoke(s_170, "start", t_165, ((V)((ToNum(Invoke(G("Math"), "random")) * 0.5))));
Invoke(s_170, "stop", Add(Add(t_165, dur_166), ((V)(0.05))));
return default;
}, 3, "noise", false);
groove_38 = Fn((V _self179, int _argc180, V t_186, V s_187, V _a184, V _a185, V[] _rest181) => {
double bar_188 = 0;
double i_189 = 0;
V rt_190 = default;
V m_191 = default;
if (_self179.IsNullish) _self179 = GlobalV;
bar_188 = (System.Math.Floor((ToNum(s_187) / 16D)) % 4D);
i_189 = (ToNum(s_187) % 16D);
rt_190 = GetIdx(GetIdx(PROG_36, bar_188), 0D);
if (((i_189 % 4D) == 0D)) {
Call(kick_27, V.Undef, t_186, ((V)(0.85)));
}
if (((bar_188 == 3D) && (i_189 == 14D))) {
Call(kick_27, V.Undef, t_186, ((V)(0.55)));
}
if (((i_189 == 4D) || (i_189 == 12D))) {
Call(snare_28, V.Undef, t_186);
}
if (((i_189 % 2D) == 1D)) {
Call(hat_29, V.Undef, t_186, ((V)((((i_189 % 4D) == 3D) ? 0.09 : 0.05))));
}
if (((i_189 % 2D) == 0D)) {
Call(bass_30, V.Undef, t_186, Add(rt_190, ((V)((((i_189 % 8D) == 6D) ? 12D : 0D)))));
}
if ((i_189 == 0D)) {
Call(chord_33, V.Undef, t_186, GetIdx(GetIdx(PROG_36, bar_188), 1D), ((V)(0.9)), ((V)(0.03)));
}
m_191 = GetIdx(MEL_37, ((i_189 + (bar_188 * 5D)) % 16D));
if (Truthy((m_191 is var _t192 && !Truthy(_t192) ? _t192 : (((bar_188 != 3D) || (i_189 < 10D)) ? V.True : V.False)))) {
Call(lead_31, V.Undef, t_186, m_191);
}
return default;
}, 2, "groove", false);
startJam_41 = Fn((V _self193, int _argc194, V _a196, V _a197, V _a198, V _a199, V[] _rest195) => {
V c_200 = default;
if (_self193.IsNullish) _self193 = GlobalV;
if (Truthy((Get(J_40, "on") is var _t201 && Truthy(_t201) ? _t201 : SH_50))) {
return default;
}
Set(J_40, "on", (true ? V.True : V.False));
Set(J_40, "p0", Add(Invoke(G("performance"), "now"), ((V)(60D))));
Set(J_40, "step", ((V)(0D)));
c_200 = Call(ac_22, V.Undef);
if (Truthy(c_200)) {
V tick_202 = default;
Set(J_40, "bus", Invoke(c_200, "createGain"));
Set(Get(Get(J_40, "bus"), "gain"), "value", ((V)((Truthy(Get(J_40, "mute")) ? 0.0001 : 1D))));
Invoke(Get(J_40, "bus"), "connect", Get(A_20, "out"));
Set(J_40, "t0", Add(Get(c_200, "currentTime"), ((V)(0.06))));
tick_202 = Fn((V _arrowThis209, int _argc203, V _a205, V _a206, V _a207, V _a208, V[] _rest204) => {
CUR_21 = Get(J_40, "bus");
while (Lt(Add(Get(J_40, "t0"), ((V)((ToNum(Get(J_40, "step")) * STEP_12)))), Add(Get(c_200, "currentTime"), ((V)(0.2))))) {
Call(groove_38, V.Undef, Add(Get(J_40, "t0"), ((V)((ToNum(Get(J_40, "step")) * STEP_12)))), Get(J_40, "step"));
IncM(J_40, "step", 1D, false);
}
CUR_21 = V.Null;
return default;
}, 0, "", true);
Call(tick_202, V.Undef);
Set(J_40, "timer", Call(G("setInterval"), V.Undef, tick_202, ((V)(40D))));
}
return default;
}, 0, "startJam", false);
stopJam_42 = Fn((V _self210, int _argc211, V _a213, V _a214, V _a215, V _a216, V[] _rest212) => {
V b_217 = default;
V c_218 = default;
if (_self210.IsNullish) _self210 = GlobalV;
if (!(Truthy(Get(J_40, "on")))) {
return default;
}
Set(J_40, "on", (false ? V.True : V.False));
Call(G("clearInterval"), V.Undef, Get(J_40, "timer"));
b_217 = Get(J_40, "bus");
c_218 = Get(A_20, "ctx");
Set(J_40, "bus", V.Null);
if (Truthy((b_217 is var _t219 && !Truthy(_t219) ? _t219 : c_218))) {
Invoke(Get(b_217, "gain"), "setTargetAtTime", ((V)(0.0001)), Get(c_218, "currentTime"), ((V)(0.05)));
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis235, int _argc229, V _a231, V _a232, V _a233, V _a234, V[] _rest230) => {
try {
Invoke(b_217, "disconnect");
} catch (System.Exception _ex236) {
V e_228 = default;
e_228 = Caught(_ex236);

}
return default;
}, 0, "", true), ((V)(400D)));
}
return default;
}, 0, "stopJam", false);
resetEl_43 = Fn((V _self237, int _argc238, V el_244, V _a241, V _a242, V _a243, V[] _rest239) => {
if (_self237.IsNullish) _self237 = GlobalV;
if (Truthy(el_244)) {
Set(Get(el_244, "style"), "transform", ((V)("")));
Set(el_244, "_mnB", V.Undef);
}
return default;
}, 1, "resetEl", false);
toggle_44 = Fn((V _self245, int _argc246, V key_252, V get_253, V _a250, V _a251, V[] _rest247) => {
if (_self245.IsNullish) _self245 = GlobalV;
if (Truthy(Invoke(K_39, "has", key_252))) {
Call(stop_45, V.Undef, key_252);
return (false ? V.True : V.False);
}
Invoke(K_39, "set", key_252, get_253);
Call(startJam_41, V.Undef);
Call(emit_103, V.Undef);
Call(loop_98, V.Undef);
return (true ? V.True : V.False);
return default;
}, 2, "toggle", false);
stop_45 = Fn((V _self254, int _argc255, V key_261, V _a258, V _a259, V _a260, V[] _rest256) => {
V g_262 = default;
V o_263 = default;
if (_self254.IsNullish) _self254 = GlobalV;
g_262 = Invoke(K_39, "get", key_261);
if (!(Truthy(g_262))) {
return default;
}
o_263 = Call(g_262, V.Undef);
if (Truthy(o_263)) {
Call(resetEl_43, V.Undef, Get(o_263, "el"));
}
Invoke(K_39, "delete", key_261);
if (!(Truthy(Get(K_39, "size")))) {
Call(stopJam_42, V.Undef);
}
Call(emit_103, V.Undef);
return default;
}, 1, "stop", false);
el_55 = Fn((V _self264, int _argc265, V tag_271, V css_272, V parent_273, V txt_274, V[] _rest266) => {
V n_275 = default;
if (_self264.IsNullish) _self264 = GlobalV;
n_275 = Invoke(G("document"), "createElement", tag_271);
if (Truthy(css_272)) {
Set(Get(n_275, "style"), "cssText", css_272);
}
if (!txt_274.IsNullish) {
Set(n_275, "textContent", txt_274);
}
if (Truthy(parent_273)) {
Invoke(parent_273, "appendChild", n_275);
}
return n_275;
return default;
}, 4, "el", false);
nodes_56 = Fn((V _self276, int _argc277, V _a279, V _a280, V _a281, V _a282, V[] _rest278) => {
V N_283 = default;
if (_self276.IsNullish) _self276 = GlobalV;
if (Truthy(Get(L_47, "_mn"))) {
return Get(L_47, "_mn");
}
N_283 = NewObj(0).V;
Set(N_283, "dim", Call(el_55, V.Undef, ((V)("div")), ((V)("position:absolute;inset:-60px;opacity:0;")), L_47));
Set(N_283, "svg", Invoke(G("document"), "createElementNS", ((V)("http://www.w3.org/2000/svg")), ((V)("svg"))));
Invoke(Get(N_283, "svg"), "setAttribute", ((V)("style")), ((V)("position:absolute;left:0;top:0;width:100%;height:100%;overflow:visible;")));
Invoke(L_47, "appendChild", Get(N_283, "svg"));
Set(Get(N_283, "svg"), "innerHTML", ((V)("<defs><linearGradient id=\"mnBeam\" gradientUnits=\"userSpaceOnUse\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.8\"></stop><stop offset=\"1\" stop-color=\"#d6ecff\" stop-opacity=\"0.14\"></stop></linearGradient></defs><polygon fill=\"url(#mnBeam)\" opacity=\"0\"></polygon><g></g>")));
Set(N_283, "grad", Invoke(Get(N_283, "svg"), "querySelector", ((V)("linearGradient"))));
Set(N_283, "beam", Invoke(Get(N_283, "svg"), "querySelector", ((V)("polygon"))));
Set(N_283, "links", Invoke(Get(N_283, "svg"), "querySelector", ((V)("g"))));
Set(N_283, "vh", Call(el_55, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;")), L_47));
Set(N_283, "fb", Call(el_55, V.Undef, ((V)("button")), ((V)("position:absolute;left:0;top:0;width:34px;height:34px;border-radius:50%;border:2px solid #8a6420;background:#e2b14a;color:#3a1a5c;display:flex;align-items:center;justify-content:center;cursor:pointer;padding:0;pointer-events:none;opacity:0;transform:scale(0.6);transition:opacity .25s ease, transform .25s cubic-bezier(.3,1.6,.5,1);box-shadow:0 3px 0 rgba(90,58,30,0.35), 0 0 0 3px rgba(255,236,170,0.3);z-index:4;")), L_47));
Set(Get(N_283, "fb"), "innerHTML", Get(ICON_89, "full"));
Set(Get(N_283, "fb"), "title", ((V)("Watch full screen")));
Invoke(Get(N_283, "fb"), "setAttribute", ((V)("aria-label")), ((V)("Watch full screen")));
Call(noProp_54, V.Undef, Get(N_283, "fb"));
Set(Get(N_283, "fb"), "onclick", Fn((V _arrowThis290, int _argc284, V _a286, V _a287, V _a288, V _a289, V[] _rest285) => {
return Call(focus_58, V.Undef, (true ? V.True : V.False));
}, 0, "", true));
Set(L_47, "_mn", N_283);
Call(mkUI_90, V.Undef, N_283);
return N_283;
return default;
}, 0, "nodes", false);
ovl_57 = Fn((V _self291, int _argc292, V N_298, V _a295, V _a296, V _a297, V[] _rest293) => {
V ov_299 = default;
if (_self291.IsNullish) _self291 = GlobalV;
if (Truthy(Get(N_298, "ov"))) {
return Get(N_298, "ov");
}
ov_299 = Set(N_298, "ov", Call(el_55, V.Undef, ((V)("div")), ((V)("position:fixed;left:0;top:0;width:100vw;height:100vh;z-index:2147483000;display:none;pointer-events:auto;overflow:hidden;")), Get(G("document"), "body")));
Set(N_298, "bd", Call(el_55, V.Undef, ((V)("div")), ((V)("position:absolute;inset:0;background:rgba(0,0,0,0);")), ov_299));
Set(N_298, "fv", Call(el_55, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;")), ov_299));
Set(N_298, "gl", Call(el_55, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;width:0;height:0;pointer-events:none;opacity:0;background:linear-gradient(105deg,rgba(255,255,255,0) 40%,rgba(255,255,255,0.3) 50%,rgba(255,255,255,0) 60%);background-size:300% 100%;background-repeat:no-repeat;")), ov_299));
Set(N_298, "xb", Call(el_55, V.Undef, ((V)("button")), ((V)("position:absolute;top:22px;right:28px;width:40px;height:40px;border-radius:50%;border:2px solid #8a6420;background:#e2b14a;color:#3a1a5c;display:flex;align-items:center;justify-content:center;cursor:pointer;padding:0;opacity:0;transition:opacity .3s ease;box-shadow:0 3px 0 rgba(0,0,0,0.45);")), ov_299));
Set(Get(N_298, "xb"), "innerHTML", Get(ICON_89, "shrink"));
Set(Get(N_298, "xb"), "title", ((V)("Back to the room")));
Invoke(Get(N_298, "xb"), "setAttribute", ((V)("aria-label")), ((V)("Back to the room")));
Set(Get(N_298, "xb"), "onclick", Fn((V _arrowThis306, int _argc300, V _a302, V _a303, V _a304, V _a305, V[] _rest301) => {
return Call(focus_58, V.Undef, (false ? V.True : V.False));
}, 0, "", true));
Call(noProp_54, V.Undef, ov_299);
Invoke(Arr(((V)("pointermove")), ((V)("pointerdown"))), "forEach", Fn((V _arrowThis314, int _argc307, V ev_313, V _a310, V _a311, V _a312, V[] _rest308) => {
return Invoke(ov_299, "addEventListener", ev_313, Fn((V _arrowThis321, int _argc315, V _a317, V _a318, V _a319, V _a320, V[] _rest316) => {
Set(FZ_52, "ctl", Invoke(G("performance"), "now"));
return default;
}, 0, "", true));
}, 1, "", true));
return ov_299;
return default;
}, 1, "ovl", false);
focus_58 = Fn((V _self322, int _argc323, V on_329, V _a326, V _a327, V _a328, V[] _rest324) => {
V N_330 = default;
V c_331 = default;
if (_self322.IsNullish) _self322 = GlobalV;
N_330 = (L_47 is var _t332 && !Truthy(_t332) ? _t332 : Get(L_47, "_mn"));
if (!(Truthy(N_330))) {
return default;
}
on_329 = (!(!(Truthy(on_329))) ? V.True : V.False);
if (Truthy((on_329 is var _t333 && !Truthy(_t333) ? _t333 : (((!(Truthy(SH_50)) || !(Truthy(TH_46))) || !(Truthy(Get(TH_46, "screen")))) ? V.True : V.False)))) {
return default;
}
if (SEq(on_329, Get(FZ_52, "on"))) {
return default;
}
Set(FZ_52, "on", on_329);
Set(FZ_52, "last", Set(FZ_52, "ctl", Invoke(G("performance"), "now")));
Call(fsApi_59, V.Undef, on_329);
if (Truthy(on_329)) {
V ov_334 = default;
ov_334 = Call(ovl_57, V.Undef, N_330);
Set(Get(ov_334, "style"), "display", ((V)("block")));
Set(Get(ov_334, "style"), "opacity", ((V)("1")));
Set(FZ_52, "gd", ((V)(0D)));
Set(Get(Get(N_330, "gl"), "style"), "opacity", ((V)("0")));
Invoke(Get(N_330, "fv"), "appendChild", Get(Get(SH_50, "vid"), "root"));
Invoke(ov_334, "appendChild", Get(N_330, "ui"));
Set(Get(Get(N_330, "ui"), "style"), "transition", ((V)("opacity .3s ease")));
Set(Get(Get(N_330, "fb"), "style"), "opacity", ((V)("0")));
Set(Get(Get(N_330, "fb"), "style"), "pointerEvents", ((V)("none")));
Call(menu_91, V.Undef, (false ? V.True : V.False));
}
c_331 = Get(A_20, "ctx");
if (Truthy(c_331)) {
V t_335 = default;
t_335 = Get(c_331, "currentTime");
Call(noise_26, V.Undef, t_335, ((V)(0.5)), NewObj(6).Put("ft", ((V)("bandpass"))).Put("f", ((V)((Truthy(on_329) ? 500D : 2600D)))).Put("fTo", ((V)((Truthy(on_329) ? 3000D : 420D)))).Put("q", ((V)(1.1))).Put("vol", ((V)(0.05))).Put("at", ((V)(0.22))).V);
}
Call(emit_103, V.Undef);
Call(loop_98, V.Undef);
return default;
}, 1, "focus", false);
fsApi_59 = Fn((V _self336, int _argc337, V on_343, V _a340, V _a341, V _a342, V[] _rest338) => {
if (_self336.IsNullish) _self336 = GlobalV;
try {
V d_344 = default;
V cur_345 = default;
d_344 = G("document");
cur_345 = (Get(d_344, "fullscreenElement") is var _t346 && Truthy(_t346) ? _t346 : Get(d_344, "webkitFullscreenElement"));
if (Truthy((on_343 is var _t347 && !Truthy(_t347) ? _t347 : (!(Truthy(cur_345)) ? V.True : V.False)))) {
V r_348 = default;
V f_349 = default;
r_348 = Get(d_344, "documentElement");
f_349 = (Get(r_348, "requestFullscreen") is var _t350 && Truthy(_t350) ? _t350 : Get(r_348, "webkitRequestFullscreen"));
if (Truthy(f_349)) {
V p_351 = default;
p_351 = Invoke(f_349, "call", r_348);
if (Truthy((p_351 is var _t352 && !Truthy(_t352) ? _t352 : Get(p_351, "catch")))) {
Invoke(p_351, "catch", Fn((V _arrowThis359, int _argc353, V _a355, V _a356, V _a357, V _a358, V[] _rest354) => {

return default;
}, 0, "", true));
}
}
} else {
if (Truthy(((!(Truthy(on_343)) ? V.True : V.False) is var _t360 && !Truthy(_t360) ? _t360 : cur_345))) {
V f_361 = default;
f_361 = (Get(d_344, "exitFullscreen") is var _t362 && Truthy(_t362) ? _t362 : Get(d_344, "webkitExitFullscreen"));
if (Truthy(f_361)) {
V p_363 = default;
p_363 = Invoke(f_361, "call", d_344);
if (Truthy((p_363 is var _t364 && !Truthy(_t364) ? _t364 : Get(p_363, "catch")))) {
Invoke(p_363, "catch", Fn((V _arrowThis371, int _argc365, V _a367, V _a368, V _a369, V _a370, V[] _rest366) => {

return default;
}, 0, "", true));
}
}
}
}
} catch (System.Exception _ex372) {
V e_373 = default;
e_373 = Caught(_ex372);

}
return default;
}, 1, "fsApi", false);
fzOff_60 = Fn((V _self374, int _argc375, V N_381, V _a378, V _a379, V _a380, V[] _rest376) => {
if (_self374.IsNullish) _self374 = GlobalV;
if (Truthy(Get(N_381, "ov"))) {
Set(Get(Get(N_381, "ov"), "style"), "display", ((V)("none")));
Set(Get(Get(N_381, "ov"), "style"), "opacity", ((V)("1")));
}
if (Truthy((SH_50 is var _t382 && !Truthy(_t382) ? _t382 : (!SEq(Get(Get(Get(SH_50, "vid"), "root"), "parentNode"), Get(N_381, "vh")) ? V.True : V.False)))) {
Invoke(Get(N_381, "vh"), "appendChild", Get(Get(SH_50, "vid"), "root"));
}
if (!SEq(Get(Get(N_381, "ui"), "parentNode"), L_47)) {
Invoke(L_47, "appendChild", Get(N_381, "ui"));
}
Set(Get(Get(N_381, "ui"), "style"), "opacity", ((V)("")));
Set(Get(Get(N_381, "ui"), "style"), "pointerEvents", ((V)("auto")));
Set(Get(Get(N_381, "ui"), "style"), "transition", ((V)("")));
return default;
}, 1, "fzOff", false);
fzEnd_61 = Fn((V _self383, int _argc384, V N_390, V _a387, V _a388, V _a389, V[] _rest385) => {
V was_391 = default;
if (_self383.IsNullish) _self383 = GlobalV;
was_391 = (Get(N_390, "ov") is var _t392 && !Truthy(_t392) ? _t392 : (!SEqS(Get(Get(Get(N_390, "ov"), "style"), "display"), "none") ? V.True : V.False));
Set(FZ_52, "on", (false ? V.True : V.False));
Set(FZ_52, "p", ((V)(0D)));
if (!SEq(Get(Get(N_390, "ui"), "parentNode"), L_47)) {
Invoke(L_47, "appendChild", Get(N_390, "ui"));
}
Set(Get(Get(N_390, "ui"), "style"), "opacity", ((V)("")));
Set(Get(Get(N_390, "ui"), "style"), "pointerEvents", ((V)("auto")));
Set(Get(Get(N_390, "ui"), "style"), "transition", ((V)("")));
if (Truthy(was_391)) {
Set(Invoke(Get(N_390, "ov"), "animate", Arr(NewObj(1).Put("opacity", ((V)(1D))).V, NewObj(1).Put("opacity", ((V)(0D))).V), NewObj(2).Put("duration", ((V)(450D))).Put("easing", ((V)("ease-out"))).V), "onfinish", Fn((V _arrowThis399, int _argc393, V _a395, V _a396, V _a397, V _a398, V[] _rest394) => {
if (!(Truthy(Get(FZ_52, "on")))) {
Call(fzOff_60, V.Undef, N_390);
}
return default;
}, 0, "", true));
}
return default;
}, 1, "fzEnd", false);
fzStep_63 = Fn((V _self400, int _argc401, V N_407, V now_408, V _a405, V _a406, V[] _rest402) => {
double dt_409 = 0;
V p_410 = default;
V e_411 = default;
V show_412 = default;
V op_413 = default;
if (_self400.IsNullish) _self400 = GlobalV;
if ((!(Truthy(Get(FZ_52, "on"))) && SEqN(Get(FZ_52, "p"), 0D))) {
if (Truthy((Get(N_407, "ov") is var _t414 && !Truthy(_t414) ? _t414 : (!SEqS(Get(Get(Get(N_407, "ov"), "style"), "display"), "none") ? V.True : V.False)))) {
Call(fzOff_60, V.Undef, N_407);
}
return ((V)(0D));
}
dt_409 = Min(0.1, Max(0D, ((ToNum(now_408) - ToNum((Get(FZ_52, "last") is var _t415 && Truthy(_t415) ? _t415 : now_408))) / 1000D)));
Set(FZ_52, "last", now_408);
Set(FZ_52, "p", Call(cl_17, V.Undef, Add(Get(FZ_52, "p"), ((V)(((Truthy(Get(FZ_52, "on")) ? dt_409 : (-dt_409)) / FZD_53))))));
if ((!(Truthy(Get(FZ_52, "on"))) && SEqN(Get(FZ_52, "p"), 0D))) {
Call(fzOff_60, V.Undef, N_407);
return ((V)(0D));
}
p_410 = Get(FZ_52, "p");
e_411 = Call(bk_62, V.Undef, ((V)(((ToNum(p_410) * ToNum(p_410)) * (3D - (2D * ToNum(p_410)))))));
Set(Get(Get(N_407, "bd"), "style"), "background", ((V)(JsStrBuf.Begin().S("rgba(0,0,0,").V(Invoke(Call(cl_17, V.Undef, ((V)((ToNum(p_410) * 1.4)))), "toFixed", ((V)(3D)))).S(")").End())));
Set(Get(Get(N_407, "bd"), "style"), "backdropFilter", Set(Get(Get(N_407, "bd"), "style"), "webkitBackdropFilter", ((V)(JsStrBuf.Begin().S("blur(").V(Invoke(((V)((10D * ToNum(p_410)))), "toFixed", ((V)(1D)))).S("px)").End()))));
show_412 = ((Get(FZ_52, "on") is var _t416 && !Truthy(_t416) ? _t416 : (GtN(p_410, 0.85) ? V.True : V.False)) is var _t420 && !Truthy(_t420) ? _t420 : (((((ToNum(now_408) - ToNum(Get(FZ_52, "ctl"))) < 2600D) ? V.True : V.False) is var _t418 && Truthy(_t418) ? _t418 : (SH_50 is var _t417 && !Truthy(_t417) ? _t417 : Get(SH_50, "pause"))) is var _t419 && Truthy(_t419) ? _t419 : (!SEqS(Get(Get(Get(N_407, "menu"), "style"), "display"), "none") ? V.True : V.False)));
op_413 = ((V)((Truthy(show_412) ? "1" : "0")));
if (!SEq(Get(Get(Get(N_407, "xb"), "style"), "opacity"), op_413)) {
Set(Get(Get(N_407, "xb"), "style"), "opacity", op_413);
Set(Get(Get(N_407, "ui"), "style"), "opacity", op_413);
Set(Get(Get(N_407, "xb"), "style"), "pointerEvents", Set(Get(Get(N_407, "ui"), "style"), "pointerEvents", ((V)((Truthy(show_412) ? "auto" : "none")))));
Set(Get(Get(N_407, "ov"), "style"), "cursor", ((V)((Truthy((show_412 is var _t421 && Truthy(_t421) ? _t421 : (!(Truthy(Get(FZ_52, "on"))) ? V.True : V.False))) ? "" : "none"))));
}
if (Truthy((((Get(FZ_52, "on") is var _t422 && !Truthy(_t422) ? _t422 : (SEqN(p_410, 1D) ? V.True : V.False)) is var _t423 && !Truthy(_t423) ? _t423 : (!(Truthy(Get(FZ_52, "gd"))) ? V.True : V.False)) is var _t424 && !Truthy(_t424) ? _t424 : Get(FZ_52, "box")))) {
V b_425 = default;
Set(FZ_52, "gd", ((V)(1D)));
b_425 = Get(FZ_52, "box");
Object_assign(Get(Get(N_407, "gl"), "style"), NewObj(4).Put("left", ((V)(JsStrBuf.Begin().V(GetIdx(b_425, 0D)).S("px").End()))).Put("top", ((V)(JsStrBuf.Begin().V(GetIdx(b_425, 1D)).S("px").End()))).Put("width", ((V)(JsStrBuf.Begin().V(GetIdx(b_425, 2D)).S("px").End()))).Put("height", ((V)(JsStrBuf.Begin().V(GetIdx(b_425, 3D)).S("px").End()))).V);
Invoke(Get(N_407, "gl"), "animate", Arr(NewObj(2).Put("opacity", ((V)(0D))).Put("backgroundPosition", ((V)("100% 0"))).V, NewObj(2).Put("opacity", ((V)(1D))).Put("offset", ((V)(0.2))).V, NewObj(2).Put("opacity", ((V)(0D))).Put("backgroundPosition", ((V)("0% 0"))).V), NewObj(2).Put("duration", ((V)(950D))).Put("easing", ((V)("ease-out"))).V);
}
return e_411;
return default;
}, 2, "fzStep", false);
theater_64 = Fn((V _self426, int _argc427, V layer_433, V room_434, V info_435, V art_436, V[] _rest428) => {
if (_self426.IsNullish) _self426 = GlobalV;
if (Truthy(art_436)) {
ART_51 = art_436;
}
if ((!(Truthy(layer_433)) || !(Truthy(info_435)))) {
if (Truthy(SH_50)) {
Set(SH_50, "done", (true ? V.True : V.False));
Call(stopShow_88, V.Undef);
}
Invoke(Call(ML_68, V.Undef), "forEach", Fn((V _arrowThis444, int _argc437, V m_443, V _a440, V _a441, V _a442, V[] _rest438) => {
return Call(lsS_71, V.Undef, ((V)(JsStrBuf.Begin().S("mn.pos.").V(Get(m_443, "id")).End())), V.Null);
}, 1, "", true));
if (Truthy((L_47 is var _t445 && !Truthy(_t445) ? _t445 : Get(L_47, "_mn")))) {
Set(Get(Get(L_47, "_mn"), "links"), "innerHTML", ((V)("")));
}
TH_46 = V.Null;
L_47 = (layer_433 is var _t446 && Truthy(_t446) ? _t446 : V.Null);
RM_48 = (room_434 is var _t447 && Truthy(_t447) ? _t447 : V.Null);
prevReady_49 = (false ? V.True : V.False);
return default;
}
L_47 = layer_433;
RM_48 = room_434;
TH_46 = info_435;
Call(nodes_56, V.Undef);
if (Truthy((SH_50 is var _t448 && !Truthy(_t448) ? _t448 : (!(Truthy(Get(info_435, "ready"))) ? V.True : V.False)))) {
Call(stopShow_88, V.Undef);
}
if (Truthy(((Get(info_435, "ready") is var _t449 && !Truthy(_t449) ? _t449 : (!(Truthy(prevReady_49)) ? V.True : V.False)) is var _t450 && !Truthy(_t450) ? _t450 : (!(Truthy(SH_50)) ? V.True : V.False)))) {
Call(play_82, V.Undef);
}
prevReady_49 = Get(info_435, "ready");
Call(loop_98, V.Undef);
return default;
}, 4, "theater", false);
centerOf_65 = Fn((V _self451, int _argc452, V u_458, V fy_459, V _a456, V _a457, V[] _rest453) => {
V n_460 = default;
if (_self451.IsNullish) _self451 = GlobalV;
n_460 = (RM_48 is var _t461 && !Truthy(_t461) ? _t461 : Invoke(RM_48, "querySelector", ((V)(JsStrBuf.Begin().S("[data-u=\"").V(u_458).S("\"]").End()))));
if (!(Truthy(n_460))) {
return V.Null;
}
return Arr(Add(Get(n_460, "offsetLeft"), ((V)((ToNum(Get(n_460, "offsetWidth")) / 2D)))), Add(Get(n_460, "offsetTop"), ((V)((ToNum(Get(n_460, "offsetHeight")) * ToNum((fy_459.IsNullish ? ((V)(0.5)) : fy_459)))))));
return default;
}, 2, "centerOf", false);
quad_66 = Fn((V _self462, int _argc463, V sc_469, V _a466, V _a467, V _a468, V[] _rest464) => {
V m_470 = default;
if (_self462.IsNullish) _self462 = GlobalV;
m_470 = Get(sc_469, "m");
return Invoke(Arr(Arr(((V)(0D)), ((V)(0D))), Arr(Get(sc_469, "w"), ((V)(0D))), Arr(Get(sc_469, "w"), Get(sc_469, "h")), Arr(((V)(0D)), Get(sc_469, "h"))), "map", Fn((V _arrowThis482, int _argc471, V _a473, V _a474, V _a475, V _a476, V[] _rest472) => {
V x_479 = default;
V y_481 = default;
{ V _t477 = ListOf(_a473);
{ V _t478 = GetIdx(_t477, 0D);
x_479 = _t478; }
{ V _t480 = GetIdx(_t477, 1D);
y_481 = _t480; }
}
return Arr(Add(((V)(((ToNum(GetIdx(m_470, 0D)) * ToNum(x_479)) + (ToNum(GetIdx(m_470, 2D)) * ToNum(y_481))))), GetIdx(m_470, 4D)), Add(((V)(((ToNum(GetIdx(m_470, 1D)) * ToNum(x_479)) + (ToNum(GetIdx(m_470, 3D)) * ToNum(y_481))))), GetIdx(m_470, 5D)));
}, 1, "", true));
return default;
}, 1, "quad", false);
hull_67 = Fn((V _self483, int _argc484, V pts_490, V _a487, V _a488, V _a489, V[] _rest485) => {
V p_491 = default;
V cr_492 = default;
V lo_493 = default;
V up_494 = default;
if (_self483.IsNullish) _self483 = GlobalV;
p_491 = Invoke(Invoke(pts_490, "slice"), "sort", Fn((V _arrowThis503, int _argc495, V a_501, V b_502, V _a499, V _a500, V[] _rest496) => {
return (((V)((ToNum(GetIdx(a_501, 0D)) - ToNum(GetIdx(b_502, 0D))))) is var _t504 && Truthy(_t504) ? _t504 : ((V)((ToNum(GetIdx(a_501, 1D)) - ToNum(GetIdx(b_502, 1D))))));
}, 2, "", true));
cr_492 = Fn((V _arrowThis514, int _argc505, V o_511, V a_512, V b_513, V _a510, V[] _rest506) => {
return ((V)((((ToNum(GetIdx(a_512, 0D)) - ToNum(GetIdx(o_511, 0D))) * (ToNum(GetIdx(b_513, 1D)) - ToNum(GetIdx(o_511, 1D)))) - ((ToNum(GetIdx(a_512, 1D)) - ToNum(GetIdx(o_511, 1D))) * (ToNum(GetIdx(b_513, 0D)) - ToNum(GetIdx(o_511, 0D)))))));
}, 3, "", true);
lo_493 = Arr();
up_494 = Arr();
Invoke(p_491, "forEach", Fn((V _arrowThis522, int _argc515, V q_521, V _a518, V _a519, V _a520, V[] _rest516) => {
while ((GtN(Get(lo_493, "length"), 1D) && LeN(Call(cr_492, V.Undef, GetIdx(lo_493, (ToNum(Get(lo_493, "length")) - 2D)), GetIdx(lo_493, (ToNum(Get(lo_493, "length")) - 1D)), q_521), 0D))) {
Invoke(lo_493, "pop");
}
Invoke(lo_493, "push", q_521);
return default;
}, 1, "", true));
Invoke(Invoke(Invoke(p_491, "slice"), "reverse"), "forEach", Fn((V _arrowThis530, int _argc523, V q_529, V _a526, V _a527, V _a528, V[] _rest524) => {
while ((GtN(Get(up_494, "length"), 1D) && LeN(Call(cr_492, V.Undef, GetIdx(up_494, (ToNum(Get(up_494, "length")) - 2D)), GetIdx(up_494, (ToNum(Get(up_494, "length")) - 1D)), q_529), 0D))) {
Invoke(up_494, "pop");
}
Invoke(up_494, "push", q_529);
return default;
}, 1, "", true));
return Invoke(Invoke(lo_493, "slice", ((V)(0D)), ((V)((-1D)))), "concat", Invoke(up_494, "slice", ((V)(0D)), ((V)((-1D)))));
return default;
}, 1, "hull", false);
unlocked_75 = Fn((V _self531, int _argc532, V _a534, V _a535, V _a536, V _a537, V[] _rest533) => {
V tr_538 = default;
if (_self531.IsNullish) _self531 = GlobalV;
tr_538 = ((TH_46 is var _t539 && !Truthy(_t539) ? _t539 : Get(TH_46, "tier")) is var _t540 && Truthy(_t540) ? _t540 : ((V)(1D)));
return Invoke(Call(ML_68, V.Undef), "filter", Fn((V _arrowThis548, int _argc541, V m_547, V _a544, V _a545, V _a546, V[] _rest542) => {
return (Get(m_547, "mk") is var _t549 && !Truthy(_t549) ? _t549 : (Le(Get(m_547, "tier"), tr_538) ? V.True : V.False));
}, 1, "", true));
return default;
}, 0, "unlocked", false);
pickMv_76 = Fn((V _self550, int _argc551, V id_557, V _a554, V _a555, V _a556, V[] _rest552) => {
V A_558 = default;
V w_559 = default;
if (_self550.IsNullish) _self550 = GlobalV;
A_558 = Call(unlocked_75, V.Undef);
if (!(Truthy(Get(A_558, "length")))) {
return AdMv_69;
}
w_559 = (id_557 is var _t560 && Truthy(_t560) ? _t560 : Call(lsG_70, V.Undef, ((V)("mn.pick"))));
return (Invoke(A_558, "find", Fn((V _arrowThis568, int _argc561, V m_567, V _a564, V _a565, V _a566, V[] _rest562) => {
return (SEq(Get(m_567, "id"), w_559) ? V.True : V.False);
}, 1, "", true)) is var _t569 && Truthy(_t569) ? _t569 : GetIdx(A_558, (ToNum(Get(A_558, "length")) - 1D)));
return default;
}, 1, "pickMv", false);
mkFilm_77 = Fn((V _self570, int _argc571, V mv_577, V _a574, V _a575, V _a576, V[] _rest572) => {
V root_578 = default;
V st_579 = default;
V F_580 = default;
V LK_581 = default;
if (_self570.IsNullish) _self570 = GlobalV;
root_578 = Call(el_55, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;transform-origin:0 0;overflow:hidden;background:#05030a;border-radius:1px;")));
st_579 = Call(el_55, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;width:320px;height:180px;transform-origin:0 0;overflow:hidden;")), root_578);
F_580 = Invoke(mv_577, "mk", (ART_51 is var _t582 && Truthy(_t582) ? _t582 : NewObj(0).V));
Invoke(st_579, "appendChild", Get(F_580, "root"));
LK_581 = Invoke(Get(G("window"), "SquadMovies"), "look", ((TH_46 is var _t583 && !Truthy(_t583) ? _t583 : Get(TH_46, "tier")) is var _t584 && Truthy(_t584) ? _t584 : ((V)(1D))), st_579, Get(F_580, "root"));
return NewObj(3).Put("root", root_578).Put("st", st_579).Put("upd", Fn((V _arrowThis592, int _argc585, V t_591, V _a588, V _a589, V _a590, V[] _rest586) => {
V o_593 = default;
o_593 = Invoke(F_580, "upd", t_591);
Invoke(LK_581, "upd", Invoke(G("performance"), "now"));
return o_593;
return default;
}, 1, "upd", true)).V;
return default;
}, 1, "mkFilm", false);
mkBus_78 = Fn((V _self594, int _argc595, V c_601, V mv_602, V _a599, V _a600, V[] _rest596) => {
V g_603 = default;
if (_self594.IsNullish) _self594 = GlobalV;
g_603 = Invoke(c_601, "createGain");
if (Truthy(Get(mv_602, "old"))) {
V hp_604 = default;
V lp_605 = default;
hp_604 = Invoke(c_601, "createBiquadFilter");
lp_605 = Invoke(c_601, "createBiquadFilter");
Set(hp_604, "type", ((V)("highpass")));
Set(Get(hp_604, "frequency"), "value", ((V)(180D)));
Set(lp_605, "type", ((V)("lowpass")));
Set(Get(lp_605, "frequency"), "value", ((V)(3400D)));
Invoke(g_603, "connect", hp_604);
Invoke(hp_604, "connect", lp_605);
Invoke(lp_605, "connect", Get(A_20, "out"));
Set(g_603, "_ch", Arr(hp_604, lp_605));
} else {
Invoke(g_603, "connect", Get(A_20, "out"));
}
return g_603;
return default;
}, 2, "mkBus", false);
killBus_79 = Fn((V _self606, int _argc607, V b_613, V _a610, V _a611, V _a612, V[] _rest608) => {
V c_614 = default;
if (_self606.IsNullish) _self606 = GlobalV;
c_614 = Get(A_20, "ctx");
if ((!(Truthy(b_613)) || !(Truthy(c_614)))) {
return default;
}
Invoke(Get(b_613, "gain"), "setTargetAtTime", ((V)(0.0001)), Get(c_614, "currentTime"), ((V)(0.06)));
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis639, int _argc633, V _a635, V _a636, V _a637, V _a638, V[] _rest634) => {
try {
Invoke(b_613, "disconnect");
Invoke((Get(b_613, "_ch") is var _t647 && Truthy(_t647) ? _t647 : Arr()), "forEach", Fn((V _arrowThis646, int _argc640, V n_628, V _a643, V _a644, V _a645, V[] _rest641) => {
return Invoke(n_628, "disconnect");
}, 1, "", true));
} catch (System.Exception _ex648) {
V e_632 = default;
e_632 = Caught(_ex648);

}
return default;
}, 0, "", true), ((V)(600D)));
return default;
}, 1, "killBus", false);
idxOf_80 = Fn((V _self649, int _argc650, V mv_656, V t_657, V _a654, V _a655, V[] _rest651) => {
V R_658 = default;
double i_659 = 0;
if (_self649.IsNullish) _self649 = GlobalV;
if (Truthy(Get(mv_656, "ad"))) {
return ((V)(0D));
}
R_658 = Invoke(Get(G("window"), "SquadMovies"), "record", mv_656);
i_659 = 0D;
while ((Lt(((V)(i_659)), Get(R_658, "length")) && LtN(GetIdx(GetIdx(R_658, i_659), 0D), (ToNum(t_657) - 0.001)))) {
i_659++;
}
return ((V)(i_659));
return default;
}, 2, "idxOf", false);
savePos_81 = Fn((V _self660, int _argc661, V s_667, V _a664, V _a665, V _a666, V[] _rest662) => {
V m_668 = default;
if (_self660.IsNullish) _self660 = GlobalV;
if (Truthy(((!(Truthy(s_667)) ? V.True : V.False) is var _t669 && Truthy(_t669) ? _t669 : Get(Get(s_667, "mv"), "ad")))) {
return default;
}
m_668 = Get(s_667, "mt");
Call(lsS_71, V.Undef, ((V)(JsStrBuf.Begin().S("mn.pos.").V(Get(Get(s_667, "mv"), "id")).End())), (((!(Truthy(Get(s_667, "done"))) && GtN(m_668, 2D)) && LtN(m_668, (ToNum(Get(Get(s_667, "mv"), "dur")) - 3D))) ? Invoke(m_668, "toFixed", ((V)(1D))) : V.Null));
return default;
}, 1, "savePos", false);
play_82 = Fn((V _self670, int _argc671, V id_677, V _a674, V _a675, V _a676, V[] _rest672) => {
V mv_678 = default;
double pos_679 = 0;
V c_680 = default;
V N_681 = default;
if (_self670.IsNullish) _self670 = GlobalV;
if (((!(Truthy(TH_46)) || !(Truthy(Get(TH_46, "synced")))) || !(Truthy(L_47)))) {
return default;
}
mv_678 = Call(pickMv_76, V.Undef, id_677);
if (Truthy(SH_50)) {
Call(stopShow_88, V.Undef, (true ? V.True : V.False));
}
Call(stopJam_42, V.Undef);
if (!(Truthy(Get(mv_678, "ad")))) {
Call(lsS_71, V.Undef, ((V)("mn.pick")), Get(mv_678, "id"));
}
pos_679 = (Truthy(Get(mv_678, "ad")) ? 0D : ToNum((Call(lsG_70, V.Undef, ((V)(JsStrBuf.Begin().S("mn.pos.").V(Get(mv_678, "id")).End()))) is var _t682 && Truthy(_t682) ? _t682 : ((V)(0D)))));
if (!(((pos_679 > 2D) && (pos_679 < (ToNum(Get(mv_678, "dur")) - 3D))))) {
pos_679 = 0D;
}
c_680 = Call(ac_22, V.Undef);
N_681 = Call(nodes_56, V.Undef);
SH_50 = NewObj(14).Put("mv", mv_678).Put("vid", (Truthy(Get(mv_678, "ad")) ? Call(mkVideo_95, V.Undef, (ART_51 is var _t683 && Truthy(_t683) ? _t683 : NewObj(0).V)) : Call(mkFilm_77, V.Undef, mv_678))).Put("mt", ((V)((pos_679 - DIM_9)))).Put("age", ((V)(0D))).Put("pause", (false ? V.True : V.False)).Put("last", Invoke(G("performance"), "now")).Put("done", (false ? V.True : V.False)).Put("endA", ((V)(0D))).Put("bus", V.Null).Put("ei", ((V)(0D))).Put("a0", ((V)(0D))).Put("sv", ((V)((-1D)))).Put("msg", ((V)((NumTruthy(pos_679) ? JsStrBuf.Begin().S("Resuming at ").V(Call(fmt_72, V.Undef, ((V)(pos_679)))).End() : "")))).Put("msgT", ((V)(3D))).V;
Invoke((Truthy((Get(FZ_52, "on") is var _t684 && !Truthy(_t684) ? _t684 : Get(N_681, "fv"))) ? Get(N_681, "fv") : Get(N_681, "vh")), "appendChild", Get(Get(SH_50, "vid"), "root"));
if (Truthy(c_680)) {
V t_685 = default;
Set(SH_50, "bus", Call(mkBus_78, V.Undef, c_680, mv_678));
CUR_21 = Get(SH_50, "bus");
t_685 = Get(c_680, "currentTime");
Call(noise_26, V.Undef, t_685, ((V)(1.1)), NewObj(5).Put("ft", ((V)("lowpass"))).Put("f", ((V)(1400D))).Put("fTo", ((V)(160D))).Put("vol", ((V)(0.06))).Put("at", ((V)(0.3))).V);
Call(noise_26, V.Undef, ((V)((ToNum(Add(t_685, ((V)(DIM_9)))) - 0.18))), ((V)(0.03)), NewObj(4).Put("ft", ((V)("bandpass"))).Put("f", ((V)(3200D))).Put("q", ((V)(2D))).Put("vol", ((V)(0.25))).V);
if (Truthy(Get(mv_678, "ad"))) {
Call(adAudio_93, V.Undef, Add(t_685, ((V)(DIM_9))));
}
CUR_21 = V.Null;
Set(SH_50, "a0", ((V)((ToNum(t_685) - ToNum(Get(SH_50, "mt"))))));
Set(SH_50, "ei", Call(idxOf_80, V.Undef, mv_678, ((V)(pos_679))));
}
Call(menu_91, V.Undef, (false ? V.True : V.False));
Call(emit_103, V.Undef);
Call(loop_98, V.Undef);
return default;
}, 1, "play", false);
setPause_83 = Fn((V _self686, int _argc687, V p_693, V _a690, V _a691, V _a692, V[] _rest688) => {
V c_694 = default;
if (_self686.IsNullish) _self686 = GlobalV;
if (Truthy((((!(Truthy(SH_50)) ? V.True : V.False) is var _t695 && Truthy(_t695) ? _t695 : Get(SH_50, "done")) is var _t696 && Truthy(_t696) ? _t696 : (SEq(Get(SH_50, "pause"), (!(!(Truthy(p_693))) ? V.True : V.False)) ? V.True : V.False)))) {
return default;
}
Set(SH_50, "pause", (!(!(Truthy(p_693))) ? V.True : V.False));
c_694 = Get(A_20, "ctx");
if (Truthy(p_693)) {
Call(killBus_79, V.Undef, Get(SH_50, "bus"));
Set(SH_50, "bus", V.Null);
Call(savePos_81, V.Undef, SH_50);
} else {
Set(SH_50, "last", Invoke(G("performance"), "now"));
if (Truthy((c_694 is var _t697 && !Truthy(_t697) ? _t697 : (!(Truthy(Get(Get(SH_50, "mv"), "ad"))) ? V.True : V.False)))) {
Call(ac_22, V.Undef);
Set(SH_50, "bus", Call(mkBus_78, V.Undef, c_694, Get(SH_50, "mv")));
Set(SH_50, "a0", ((V)((ToNum(Get(c_694, "currentTime")) - ToNum(Get(SH_50, "mt"))))));
Set(SH_50, "ei", Call(idxOf_80, V.Undef, Get(SH_50, "mv"), ((V)(Max(0D, ToNum(Get(SH_50, "mt")))))));
}
}
Call(emit_103, V.Undef);
Call(loop_98, V.Undef);
return default;
}, 1, "setPause", false);
sched_84 = Fn((V _self698, int _argc699, V s_705, V _a702, V _a703, V _a704, V[] _rest700) => {
V c_706 = default;
V R_707 = default;
V ah_708 = default;
if (_self698.IsNullish) _self698 = GlobalV;
c_706 = Get(A_20, "ctx");
R_707 = Invoke(Get(G("window"), "SquadMovies"), "record", Get(s_705, "mv"));
if (!SEqS(Get(c_706, "state"), "running")) {
while ((Lt(Get(s_705, "ei"), Get(R_707, "length")) && Lt(GetIdx(GetK(R_707, Get(s_705, "ei")), 0D), Get(s_705, "mt")))) {
IncM(s_705, "ei", 1D, false);
}
Set(s_705, "a0", ((V)((ToNum(Get(c_706, "currentTime")) - ToNum(Get(s_705, "mt"))))));
return default;
}
if ((System.Math.Abs(((ToNum(Get(c_706, "currentTime")) - ToNum(Get(s_705, "a0"))) - ToNum(Get(s_705, "mt")))) > 0.12)) {
Set(s_705, "a0", ((V)((ToNum(Get(c_706, "currentTime")) - ToNum(Get(s_705, "mt"))))));
}
ah_708 = Add(Get(s_705, "mt"), ((V)(0.3)));
CUR_21 = Get(s_705, "bus");
while ((Lt(Get(s_705, "ei"), Get(R_707, "length")) && Lt(GetIdx(GetK(R_707, Get(s_705, "ei")), 0D), ah_708))) {
V r_709 = default;
V w_710 = default;
double at_711 = 0;
r_709 = GetIdx(R_707, IncM(s_705, "ei", 1D, false));
w_710 = Add(Get(s_705, "a0"), GetIdx(r_709, 0D));
if (LtN(w_710, (ToNum(Get(c_706, "currentTime")) - 0.05))) {
continue;
}
at_711 = Max(ToNum(w_710), ToNum(Get(c_706, "currentTime")));
if (SEqS(GetIdx(r_709, 1D), "t")) {
Call(tone_25, V.Undef, ((V)(at_711)), GetIdx(r_709, 2D), GetIdx(r_709, 3D), GetIdx(r_709, 4D));
} else {
Call(noise_26, V.Undef, ((V)(at_711)), GetIdx(r_709, 2D), GetIdx(r_709, 3D));
}
}
CUR_21 = V.Null;
return default;
}, 1, "sched", false);
cues_85 = Fn((V _self712, int _argc713, V m0_719, V m1_720, V _a717, V _a718, V[] _rest714) => {
V C_721 = default;
if (_self712.IsNullish) _self712 = GlobalV;
C_721 = (SH_50 is var _t722 && !Truthy(_t722) ? _t722 : Get(Get(SH_50, "mv"), "cues"));
if ((!(Truthy(C_721)) || ((ToNum(m1_720) - ToNum(m0_719)) > 1D))) {
return default;
}
Invoke(C_721, "forEach", Fn((V _arrowThis738, int _argc723, V _a725, V _a726, V _a727, V _a728, V[] _rest724) => {
V t_731 = default;
V k_733 = default;
V a1_735 = default;
V a2_737 = default;
{ V _t729 = ListOf(_a725);
{ V _t730 = GetIdx(_t729, 0D);
t_731 = _t730; }
{ V _t732 = GetIdx(_t729, 1D);
k_733 = _t732; }
{ V _t734 = GetIdx(_t729, 2D);
a1_735 = _t734; }
{ V _t736 = GetIdx(_t729, 3D);
a2_737 = _t736; }
}
if ((Gt(t_731, m0_719) && Le(t_731, m1_720))) {
if (SEqS(k_733, "confetti")) {
Call(confetti_87, V.Undef);
} else {
if (SEqS(k_733, "pop")) {
Call(popOut_86, V.Undef, a1_735, a2_737);
} else {
if (Truthy(REACT_73)) {
try {
Call(REACT_73, V.Undef, k_733);
} catch (System.Exception _ex739) {
V e_740 = default;
e_740 = Caught(_ex739);

}
}
}
}
}
return default;
}, 1, "", true));
return default;
}, 2, "cues", false);
popOut_86 = Fn((V _self741, int _argc742, V key_748, V x_749, V _a746, V _a747, V[] _rest743) => {
V sc_750 = default;
V q_751 = default;
double u_752 = 0;
V px_753 = default;
V py_754 = default;
double hs_755 = 0;
double sz_756 = 0;
double cx_757 = 0;
double dx_758 = 0;
V f_759 = default;
V im_760 = default;
V C_761 = default;
if (_self741.IsNullish) _self741 = GlobalV;
sc_750 = (TH_46 is var _t762 && !Truthy(_t762) ? _t762 : Get(TH_46, "screen"));
if (Truthy(((((!(Truthy(sc_750)) || !(Truthy(L_47))) ? V.True : V.False) is var _t763 && Truthy(_t763) ? _t763 : Get(FZ_52, "on")) is var _t764 && Truthy(_t764) ? _t764 : (!(Truthy(key_748)) ? V.True : V.False)))) {
return default;
}
q_751 = Call(quad_66, V.Undef, sc_750);
u_752 = Max(0D, Min(1D, (ToNum((x_749.IsNullish ? ((V)(160D)) : x_749)) / 320D)));
px_753 = Add(GetIdx(GetIdx(q_751, 0D), 0D), ((V)(((ToNum(GetIdx(GetIdx(q_751, 1D), 0D)) - ToNum(GetIdx(GetIdx(q_751, 0D), 0D))) * u_752))));
py_754 = Add(GetIdx(GetIdx(q_751, 0D), 1D), ((V)(((ToNum(GetIdx(GetIdx(q_751, 1D), 1D)) - ToNum(GetIdx(GetIdx(q_751, 0D), 1D))) * u_752))));
hs_755 = Hypot((ToNum(GetIdx(GetIdx(q_751, 3D), 0D)) - ToNum(GetIdx(GetIdx(q_751, 0D), 0D))), (ToNum(GetIdx(GetIdx(q_751, 3D), 1D)) - ToNum(GetIdx(GetIdx(q_751, 0D), 1D))));
sz_756 = Max(40D, (hs_755 * 0.8));
cx_757 = (ToNum(Add(GetIdx(GetIdx(q_751, 0D), 0D), GetIdx(GetIdx(q_751, 2D), 0D))) / 2D);
dx_758 = ((cx_757 - ToNum(px_753)) * 0.25);
f_759 = Fn((V _arrowThis772, int _argc765, V v_771, V _a768, V _a769, V _a770, V[] _rest766) => {
return Invoke(v_771, "toFixed", ((V)(0D)));
}, 1, "", true);
im_760 = Call(el_55, V.Undef, ((V)("img")), ((V)(JsStrBuf.Begin().S("position:absolute;left:").V(Call(f_759, V.Undef, ((V)((ToNum(px_753) - (sz_756 / 2D)))))).S("px;top:").V(Call(f_759, V.Undef, ((V)((ToNum(py_754) - (sz_756 * 0.94)))))).S("px;width:").V(Call(f_759, V.Undef, ((V)(sz_756)))).S("px;height:").V(Call(f_759, V.Undef, ((V)(sz_756)))).S("px;transform-origin:50% 94%;pointer-events:none;opacity:0;filter:drop-shadow(0 0 3px rgba(150,240,255,0.95)) drop-shadow(0 8px 6px rgba(0,0,0,0.35));").End())), L_47);
Set(im_760, "alt", ((V)("")));
Set(im_760, "onerror", Fn((V _arrowThis779, int _argc773, V _a775, V _a776, V _a777, V _a778, V[] _rest774) => {
return Invoke(im_760, "remove");
}, 0, "", true));
Set(im_760, "src", ((V)(JsStrBuf.Begin().S("export/tripo/").V(key_748).S("/").V(key_748).S("-front.svg").End())));
Set(Invoke(im_760, "animate", Arr(NewObj(2).Put("transform", ((V)(JsStrBuf.Begin().S("translate(0px,").V(Call(f_759, V.Undef, ((V)((sz_756 * 0.55))))).S("px) scale(0.45)").End()))).Put("opacity", ((V)(0D))).V, NewObj(4).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(Call(f_759, V.Undef, ((V)((dx_758 * 0.3))))).S("px,").V(Call(f_759, V.Undef, ((V)(((-sz_756) * 0.2))))).S("px) scale(1.05) rotate(-8deg)").End()))).Put("opacity", ((V)(1D))).Put("offset", ((V)(0.18))).Put("easing", ((V)("ease-out"))).V, NewObj(3).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(Call(f_759, V.Undef, ((V)((dx_758 * 0.7))))).S("px,").V(Call(f_759, V.Undef, ((V)(((-sz_756) * 0.42))))).S("px) scale(1.15) rotate(8deg)").End()))).Put("opacity", ((V)(1D))).Put("offset", ((V)(0.5))).V, NewObj(4).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(Call(f_759, V.Undef, ((V)(dx_758)))).S("px,").V(Call(f_759, V.Undef, ((V)(((-sz_756) * 0.3))))).S("px) scale(1.08) rotate(-3deg)").End()))).Put("opacity", ((V)(1D))).Put("offset", ((V)(0.78))).Put("easing", ((V)("ease-in"))).V, NewObj(2).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(Call(f_759, V.Undef, ((V)((dx_758 * 0.4))))).S("px,").V(Call(f_759, V.Undef, ((V)((sz_756 * 0.7))))).S("px) scale(0.5)").End()))).Put("opacity", ((V)(0D))).V), NewObj(4).Put("duration", ((V)(1650D))).Put("delay", ((V)(380D))).Put("easing", ((V)("ease-in-out"))).Put("fill", ((V)("both"))).V), "onfinish", Fn((V _arrowThis786, int _argc780, V _a782, V _a783, V _a784, V _a785, V[] _rest781) => {
return Invoke(im_760, "remove");
}, 0, "", true));
Invoke(Arr(((V)(380D)), ((V)(1880D))), "forEach", Fn((V _arrowThis794, int _argc787, V dl_793, V _a790, V _a791, V _a792, V[] _rest788) => {
V rg_795 = default;
rg_795 = Call(el_55, V.Undef, ((V)("div")), ((V)(JsStrBuf.Begin().S("position:absolute;left:").V(Call(f_759, V.Undef, ((V)((ToNum(px_753) - (sz_756 * 0.4)))))).S("px;top:").V(Call(f_759, V.Undef, ((V)((ToNum(py_754) - (sz_756 * 0.08)))))).S("px;width:").V(Call(f_759, V.Undef, ((V)((sz_756 * 0.8))))).S("px;height:").V(Call(f_759, V.Undef, ((V)((sz_756 * 0.16))))).S("px;border-radius:50%;border:2px solid rgba(160,240,255,0.95);box-sizing:border-box;box-shadow:0 0 10px rgba(140,230,255,0.8);pointer-events:none;opacity:0;").End())), L_47);
Set(Invoke(rg_795, "animate", Arr(NewObj(2).Put("transform", ((V)("scale(0.3)"))).Put("opacity", ((V)(0.95))).V, NewObj(2).Put("transform", ((V)("scale(1.6)"))).Put("opacity", ((V)(0D))).V), NewObj(4).Put("duration", ((V)(700D))).Put("delay", dl_793).Put("easing", ((V)("ease-out"))).Put("fill", ((V)("both"))).V), "onfinish", Fn((V _arrowThis802, int _argc796, V _a798, V _a799, V _a800, V _a801, V[] _rest797) => {
return Invoke(rg_795, "remove");
}, 0, "", true));
return default;
}, 1, "", true));
C_761 = Arr(((V)("#ffffff")), ((V)("#a6f4ff")), ((V)("#ffd66b")), ((V)("#ff8fb8")));
{
double i_803 = 0;
i_803 = 0D;
while (true) {
if (!((i_803 < 14D))) break;
V p_805 = default;
double a_806 = 0;
double sp_807 = 0;
p_805 = Call(el_55, V.Undef, ((V)("div")), ((V)(JsStrBuf.Begin().S("position:absolute;left:").V(Call(f_759, V.Undef, px_753)).S("px;top:").V(Call(f_759, V.Undef, py_754)).S("px;width:4px;height:4px;border-radius:50%;background:").V(GetIdx(C_761, (i_803 % 4D))).S(";box-shadow:0 0 4px ").V(GetIdx(C_761, (i_803 % 4D))).S(";pointer-events:none;opacity:0;").End())), L_47);
a_806 = (System.Math.PI + (ToNum(Invoke(G("Math"), "random")) * System.Math.PI));
sp_807 = (sz_756 * (0.3 + (ToNum(Invoke(G("Math"), "random")) * 0.5)));
Set(Invoke(p_805, "animate", Arr(NewObj(2).Put("transform", ((V)("translate(0,0) scale(1)"))).Put("opacity", ((V)(1D))).V, NewObj(2).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(Call(f_759, V.Undef, ((V)((FdLibm.Cos(a_806) * sp_807))))).S("px,").V(Call(f_759, V.Undef, ((V)(((FdLibm.Sin(a_806) * sp_807) * 0.8))))).S("px) scale(0.3)").End()))).Put("opacity", ((V)(0D))).V), NewObj(4).Put("duration", ((V)((600D + (ToNum(Invoke(G("Math"), "random")) * 300D))))).Put("delay", ((V)(400D))).Put("easing", ((V)("ease-out"))).Put("fill", ((V)("both"))).V), "onfinish", Fn((V _arrowThis814, int _argc808, V _a810, V _a811, V _a812, V _a813, V[] _rest809) => {
return Invoke(p_805, "remove");
}, 0, "", true));
i_803++;
}
}
return default;
}, 2, "popOut", false);
confetti_87 = Fn((V _self815, int _argc816, V _a818, V _a819, V _a820, V _a821, V[] _rest817) => {
V sc_822 = default;
V q_823 = default;
double cx_824 = 0;
double cy_825 = 0;
V H_826 = default;
V C_827 = default;
if (_self815.IsNullish) _self815 = GlobalV;
sc_822 = (TH_46 is var _t828 && !Truthy(_t828) ? _t828 : Get(TH_46, "screen"));
if ((!(Truthy(sc_822)) || !(Truthy(L_47)))) {
return default;
}
q_823 = Call(quad_66, V.Undef, sc_822);
cx_824 = (ToNum(Add(GetIdx(GetIdx(q_823, 0D), 0D), GetIdx(GetIdx(q_823, 2D), 0D))) / 2D);
cy_825 = (ToNum(Add(GetIdx(GetIdx(q_823, 0D), 1D), GetIdx(GetIdx(q_823, 2D), 1D))) / 2D);
H_826 = (Get(L_47, "offsetHeight") is var _t829 && Truthy(_t829) ? _t829 : ((V)(393D)));
C_827 = Arr(((V)("#ffd66b")), ((V)("#ff8fb8")), ((V)("#8fe8ff")), ((V)("#a6f06a")), ((V)("#c9a6ff")), ((V)("#ffb36b")));
{
double i_830 = 0;
i_830 = 0D;
while (true) {
if (!((i_830 < 70D))) break;
double w_832 = 0;
V p_833 = default;
double a_834 = 0;
double sp_835 = 0;
double dx_836 = 0;
double up_837 = 0;
double fall_838 = 0;
double d_839 = 0;
double r_840 = 0;
w_832 = (4D + (ToNum(Invoke(G("Math"), "random")) * 5D));
p_833 = Call(el_55, V.Undef, ((V)("div")), ((V)(JsStrBuf.Begin().S("position:absolute;left:").V(Invoke(((V)(cx_824)), "toFixed", ((V)(0D)))).S("px;top:").V(Invoke(((V)(cy_825)), "toFixed", ((V)(0D)))).S("px;width:").V(Invoke(((V)(w_832)), "toFixed", ((V)(1D)))).S("px;height:").V(Invoke(((V)((w_832 * 0.55))), "toFixed", ((V)(1D)))).S("px;border-radius:1px;background:").V(GetIdx(C_827, (i_830 % 6D))).S(";pointer-events:none;").End())), L_47);
a_834 = ((ToNum(Invoke(G("Math"), "random")) * System.Math.PI) * 2D);
sp_835 = (80D + (ToNum(Invoke(G("Math"), "random")) * 260D));
dx_836 = (FdLibm.Cos(a_834) * sp_835);
up_837 = ((((-System.Math.Abs(FdLibm.Sin(a_834))) * sp_835) * 0.6) - 40D);
fall_838 = ((ToNum(H_826) - cy_825) + 40D);
d_839 = (2600D + (ToNum(Invoke(G("Math"), "random")) * 2200D));
r_840 = ((ToNum(Invoke(G("Math"), "random")) - 0.5) * 1400D);
Set(Invoke(p_833, "animate", Arr(NewObj(2).Put("transform", ((V)("translate(0,0) rotate(0deg)"))).Put("opacity", ((V)(1D))).V, NewObj(3).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(Invoke(((V)((dx_836 * 0.7))), "toFixed", ((V)(0D)))).S("px,").V(Invoke(((V)(up_837)), "toFixed", ((V)(0D)))).S("px) rotate(").V(Invoke(((V)((r_840 * 0.3))), "toFixed", ((V)(0D)))).S("deg)").End()))).Put("opacity", ((V)(1D))).Put("offset", ((V)(0.25))).V, NewObj(2).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(Invoke(((V)((dx_836 + (FdLibm.Sin((a_834 * 5D)) * 30D)))), "toFixed", ((V)(0D)))).S("px,").V(Invoke(((V)(fall_838)), "toFixed", ((V)(0D)))).S("px) rotate(").V(Invoke(((V)(r_840)), "toFixed", ((V)(0D)))).S("deg)").End()))).Put("opacity", ((V)(0.85))).V), NewObj(2).Put("duration", ((V)(d_839))).Put("easing", ((V)("cubic-bezier(.2,.6,.4,1)"))).V), "onfinish", Fn((V _arrowThis847, int _argc841, V _a843, V _a844, V _a845, V _a846, V[] _rest842) => {
return Invoke(p_833, "remove");
}, 0, "", true));
i_830++;
}
}
return default;
}, 0, "confetti", false);
stopShow_88 = Fn((V _self848, int _argc849, V keep_855, V _a852, V _a853, V _a854, V[] _rest850) => {
V s_856 = default;
if (_self848.IsNullish) _self848 = GlobalV;
if (!(Truthy(SH_50))) {
return default;
}
s_856 = SH_50;
Call(savePos_81, V.Undef, s_856);
SH_50 = V.Null;
Call(killBus_79, V.Undef, Get(s_856, "bus"));
if (Truthy(Get(Get(Get(s_856, "vid"), "root"), "parentNode"))) {
Invoke(Get(Get(Get(s_856, "vid"), "root"), "parentNode"), "removeChild", Get(Get(s_856, "vid"), "root"));
}
if (Truthy((L_47 is var _t857 && !Truthy(_t857) ? _t857 : Get(L_47, "_mn")))) {
V N_858 = default;
N_858 = Get(L_47, "_mn");
Set(Get(Get(N_858, "dim"), "style"), "opacity", ((V)("0")));
Invoke(Get(N_858, "beam"), "setAttribute", ((V)("opacity")), ((V)("0")));
Set(Get(Get(N_858, "fb"), "style"), "opacity", ((V)("0")));
Set(Get(Get(N_858, "fb"), "style"), "pointerEvents", ((V)("none")));
if (!SEq(keep_855, (true ? V.True : V.False))) {
Call(fzEnd_61, V.Undef, N_858);
}
}
if (Truthy(RM_48)) {
Invoke(Invoke(RM_48, "querySelectorAll", ((V)("[data-kind=\"spk\"],[data-kind=\"crew\"]"))), "forEach", Fn((V _arrowThis866, int _argc859, V n_865, V _a862, V _a863, V _a864, V[] _rest860) => {
return Call(resetEl_43, V.Undef, Get(n_865, "firstElementChild"));
}, 1, "", true));
}
Call(menu_91, V.Undef, (false ? V.True : V.False));
Call(uiUpd_92, V.Undef);
if (Truthy(REACT_73)) {
try {
Call(REACT_73, V.Undef, ((V)("end")));
} catch (System.Exception _ex867) {
V e_868 = default;
e_868 = Caught(_ex867);

}
}
if (Truthy(Get(K_39, "size"))) {
Call(startJam_41, V.Undef);
}
Call(emit_103, V.Undef);
Call(loop_98, V.Undef);
return default;
}, 1, "stopShow", false);
mkUI_90 = Fn((V _self869, int _argc870, V N_876, V _a873, V _a874, V _a875, V[] _rest871) => {
V u_877 = default;
V B_878 = default;
V mid_879 = default;
V row_880 = default;
V bar_881 = default;
if (_self869.IsNullish) _self869 = GlobalV;
u_877 = Set(N_876, "ui", Call(el_55, V.Undef, ((V)("div")), ((V)("position:absolute;left:50%;bottom:12px;transform:translateX(-50%);display:none;align-items:center;gap:8px;padding:5px 6px;border-radius:999px;background:#f6ead2;border:2px solid #c9ad86;box-shadow:0 3px 0 rgba(90,58,30,0.28);pointer-events:auto;font-family:'Fredoka',sans-serif;font-weight:600;color:#5a3a1e;user-select:none;-webkit-user-select:none;z-index:5;")), L_47));
Invoke(Arr(((V)("pointerdown")), ((V)("pointerup")), ((V)("click")), ((V)("mousedown")), ((V)("touchstart")), ((V)("wheel"))), "forEach", Fn((V _arrowThis889, int _argc882, V ev_888, V _a885, V _a886, V _a887, V[] _rest883) => {
return Invoke(u_877, "addEventListener", ev_888, Fn((V _arrowThis897, int _argc890, V e_896, V _a893, V _a894, V _a895, V[] _rest891) => {
return Invoke(e_896, "stopPropagation");
}, 1, "", true));
}, 1, "", true));
B_878 = Fn((V _arrowThis907, int _argc898, V ic_904, V tip_905, V main_906, V _a903, V[] _rest899) => {
V b_908 = default;
b_908 = Call(el_55, V.Undef, ((V)("button")), ((V)(JsStrBuf.Begin().S("width:34px;height:34px;border-radius:50%;border:2px solid ").S((Truthy(main_906) ? "#8a6420" : "#c9ad86")).S(";background:").S((Truthy(main_906) ? "#e2b14a" : "#fbf3e3")).S(";color:#3a1a5c;display:flex;align-items:center;justify-content:center;cursor:pointer;padding:0;flex:none;").End())), u_877);
Set(b_908, "innerHTML", GetK(ICON_89, ic_904));
Set(b_908, "_ic", ic_904);
Set(b_908, "title", tip_905);
return b_908;
return default;
}, 3, "", true);
Set(N_876, "pp", Call(B_878, V.Undef, ((V)("pause")), ((V)("Pause")), (true ? V.True : V.False)));
mid_879 = Call(el_55, V.Undef, ((V)("div")), ((V)("display:flex;flex-direction:column;gap:4px;width:180px;")), u_877);
row_880 = Call(el_55, V.Undef, ((V)("div")), ((V)("display:flex;align-items:baseline;justify-content:space-between;gap:6px;")), mid_879);
Set(N_876, "ttl", Call(el_55, V.Undef, ((V)("div")), ((V)("font-size:12px;line-height:1.15;white-space:nowrap;overflow:hidden;text-overflow:ellipsis;min-width:0;")), row_880));
Set(N_876, "tm", Call(el_55, V.Undef, ((V)("div")), ((V)("font-size:10.5px;line-height:1.15;white-space:nowrap;font-variant-numeric:tabular-nums;color:#8a5a2e;flex:none;")), row_880));
bar_881 = Call(el_55, V.Undef, ((V)("div")), ((V)("height:7px;border-radius:99px;background:#e2cfa8;overflow:hidden;")), mid_879);
Set(N_876, "fill", Call(el_55, V.Undef, ((V)("div")), ((V)("height:100%;width:0;border-radius:99px;background:#8a6420;")), bar_881));
Set(N_876, "ls", Call(B_878, V.Undef, ((V)("list")), ((V)("Pick a movie"))));
Set(N_876, "fs", Call(B_878, V.Undef, ((V)("full")), ((V)("Watch full screen"))));
Set(N_876, "sk", Call(B_878, V.Undef, ((V)("skip")), ((V)("End the movie"))));
Set(Get(N_876, "fs"), "onclick", Fn((V _arrowThis915, int _argc909, V _a911, V _a912, V _a913, V _a914, V[] _rest910) => {
return Call(focus_58, V.Undef, (!(Truthy(Get(FZ_52, "on"))) ? V.True : V.False));
}, 0, "", true));
Set(N_876, "menu", Call(el_55, V.Undef, ((V)("div")), ((V)("position:absolute;right:0;bottom:48px;width:270px;display:none;flex-direction:column;gap:3px;padding:8px;border-radius:18px;background:#fbf3e3;border:2px solid #c9ad86;box-shadow:0 4px 0 rgba(90,58,30,0.25);")), u_877));
Set(Get(N_876, "pp"), "onclick", Fn((V _arrowThis922, int _argc916, V _a918, V _a919, V _a920, V _a921, V[] _rest917) => {
if (Truthy(SH_50)) {
Call(setPause_83, V.Undef, (!(Truthy(Get(SH_50, "pause"))) ? V.True : V.False));
}
return default;
}, 0, "", true));
Set(Get(N_876, "sk"), "onclick", Fn((V _arrowThis929, int _argc923, V _a925, V _a926, V _a927, V _a928, V[] _rest924) => {
if (Truthy(SH_50)) {
Call(stopShow_88, V.Undef);
}
return default;
}, 0, "", true));
Set(Get(N_876, "ls"), "onclick", Fn((V _arrowThis936, int _argc930, V _a932, V _a933, V _a934, V _a935, V[] _rest931) => {
return Call(menu_91, V.Undef, (SEqS(Get(Get(Get(N_876, "menu"), "style"), "display"), "none") ? V.True : V.False));
}, 0, "", true));
return default;
}, 1, "mkUI", false);
menu_91 = Fn((V _self937, int _argc938, V on_944, V _a941, V _a942, V _a943, V[] _rest939) => {
V N_945 = default;
V tr_946 = default;
if (_self937.IsNullish) _self937 = GlobalV;
N_945 = (L_47 is var _t947 && !Truthy(_t947) ? _t947 : Get(L_47, "_mn"));
if ((!(Truthy(N_945)) || !(Truthy(Get(N_945, "menu"))))) {
return default;
}
if (!(Truthy(on_944))) {
Set(Get(Get(N_945, "menu"), "style"), "display", ((V)("none")));
return default;
}
Set(Get(N_945, "menu"), "innerHTML", ((V)("")));
Call(el_55, V.Undef, ((V)("div")), ((V)("font-size:12px;color:#8a5a2e;padding:2px 6px 3px;")), Get(N_945, "menu"), ((V)("Movies")));
tr_946 = ((TH_46 is var _t948 && !Truthy(_t948) ? _t948 : Get(TH_46, "tier")) is var _t949 && Truthy(_t949) ? _t949 : ((V)(1D)));
Invoke(Call(ML_68, V.Undef), "forEach", Fn((V _arrowThis957, int _argc950, V m_956, V _a953, V _a954, V _a955, V[] _rest951) => {
V ok_958 = default;
V cur_959 = default;
V rs_960 = default;
V sub_961 = default;
V b_962 = default;
V tx_963 = default;
ok_958 = ((!(!(Truthy(Get(m_956, "mk")))) && Le(Get(m_956, "tier"), tr_946)) ? V.True : V.False);
cur_959 = (!(!(Truthy((SH_50 is var _t964 && !Truthy(_t964) ? _t964 : (SEq(Get(Get(SH_50, "mv"), "id"), Get(m_956, "id")) ? V.True : V.False))))) ? V.True : V.False);
rs_960 = ((ToNum((Call(lsG_70, V.Undef, ((V)(JsStrBuf.Begin().S("mn.pos.").V(Get(m_956, "id")).End()))) is var _t965 && Truthy(_t965) ? _t965 : ((V)(0D)))) > 2D) ? V.True : V.False);
sub_961 = ((V)((Gt(Get(m_956, "tier"), tr_946) ? JsStrBuf.Begin().S("Needs a tier ").V(Get(m_956, "tier")).S(" screen").End() : (!(Truthy(Get(m_956, "mk"))) ? "Unlocked \u00b7 movie coming soon" : (Truthy(cur_959) ? "Now showing" : JsStrBuf.Begin().N(Round((ToNum(Get(m_956, "dur")) / 60D))).S(" min").S((Truthy(rs_960) ? " \u00b7 resumes where you left off" : "")).End())))));
b_962 = Call(el_55, V.Undef, ((V)("button")), ((V)(JsStrBuf.Begin().S("display:flex;align-items:center;gap:8px;text-align:left;padding:6px 9px;min-height:42px;border-radius:12px;border:2px solid ").S((Truthy(cur_959) ? "#8a6420" : "transparent")).S(";background:").S((Truthy(cur_959) ? "#f3dca6" : (Truthy(ok_958) ? "#ffffff" : "transparent"))).S(";cursor:").S((Truthy((ok_958 is var _t966 && !Truthy(_t966) ? _t966 : (!(Truthy(cur_959)) ? V.True : V.False))) ? "pointer" : "default")).S(";font-family:'Fredoka',sans-serif;color:").S((Truthy(ok_958) ? "#3a1a5c" : "#9a8262")).S(";").End())), Get(N_945, "menu"));
Call(el_55, V.Undef, ((V)("div")), ((V)(string.Concat("width:22px;height:22px;border-radius:50%;flex:none;display:flex;align-items:center;justify-content:center;font-size:11px;font-weight:700;background:", (Truthy(ok_958) ? "#e2b14a" : "#eadcc2"), ";color:#3a1a5c;"))), b_962, ((V)(ToStrS(Get(m_956, "tier")))));
tx_963 = Call(el_55, V.Undef, ((V)("div")), ((V)("display:flex;flex-direction:column;gap:1px;min-width:0;")), b_962);
Call(el_55, V.Undef, ((V)("div")), ((V)("font-size:12.5px;font-weight:600;line-height:1.15;")), tx_963, Get(m_956, "title"));
Call(el_55, V.Undef, ((V)("div")), ((V)(string.Concat("font-size:10.5px;font-weight:500;line-height:1.15;color:", (Truthy(ok_958) ? "#8a5a2e" : "#a8916f"), ";"))), tx_963, sub_961);
if (Truthy((ok_958 is var _t967 && !Truthy(_t967) ? _t967 : (!(Truthy(cur_959)) ? V.True : V.False)))) {
Set(b_962, "onclick", Fn((V _arrowThis974, int _argc968, V _a970, V _a971, V _a972, V _a973, V[] _rest969) => {
Call(menu_91, V.Undef, (false ? V.True : V.False));
Call(play_82, V.Undef, Get(m_956, "id"));
return default;
}, 0, "", true));
}
return default;
}, 1, "", true));
Set(Get(Get(N_945, "menu"), "style"), "display", ((V)("flex")));
return default;
}, 1, "menu", false);
uiUpd_92 = Fn((V _self975, int _argc976, V _a978, V _a979, V _a980, V _a981, V[] _rest977) => {
V N_982 = default;
V on_983 = default;
V d_984 = default;
V mv_985 = default;
double m_986 = 0;
V ttl_987 = default;
V tm_988 = default;
V ic_989 = default;
if (_self975.IsNullish) _self975 = GlobalV;
N_982 = (L_47 is var _t990 && !Truthy(_t990) ? _t990 : Get(L_47, "_mn"));
if ((!(Truthy(N_982)) || !(Truthy(Get(N_982, "ui"))))) {
return default;
}
on_983 = (!(!(Truthy(SH_50))) ? V.True : V.False);
d_984 = ((V)((Truthy(on_983) ? "flex" : "none")));
if (!SEq(Get(Get(Get(N_982, "ui"), "style"), "display"), d_984)) {
Set(Get(Get(N_982, "ui"), "style"), "display", d_984);
}
if (!(Truthy(on_983))) {
return default;
}
{
V fr_991 = default;
V rr_992 = default;
double k_993 = 0;
V top_994 = default;
fr_991 = Invoke(L_47, "getBoundingClientRect");
rr_992 = (Truthy(RM_48) ? Invoke(RM_48, "getBoundingClientRect") : fr_991);
k_993 = (Truthy(Get(fr_991, "height")) ? (ToNum(Get(L_47, "offsetHeight")) / ToNum(Get(fr_991, "height"))) : 1D);
top_994 = ((V)(JsStrBuf.Begin().V(Invoke(((V)((!SEq(Get(Get(N_982, "ui"), "parentNode"), L_47) ? (ToNum(Get(G("window"), "innerHeight")) - 70D) : (((ToNum(Get(rr_992, "bottom")) - ToNum(Get(fr_991, "top"))) * k_993) - 104D)))), "toFixed", ((V)(0D)))).S("px").End()));
if (!SEq(Get(Get(Get(N_982, "ui"), "style"), "top"), top_994)) {
Set(Get(Get(N_982, "ui"), "style"), "top", top_994);
Set(Get(Get(N_982, "ui"), "style"), "bottom", ((V)("auto")));
}
}
{
V fi_995 = default;
fi_995 = ((V)((Truthy(Get(FZ_52, "on")) ? "shrink" : "full")));
if (Truthy((Get(N_982, "fs") is var _t996 && !Truthy(_t996) ? _t996 : (!SEq(Get(Get(N_982, "fs"), "_ic"), fi_995) ? V.True : V.False)))) {
Set(Get(N_982, "fs"), "_ic", fi_995);
Set(Get(N_982, "fs"), "innerHTML", GetK(ICON_89, fi_995));
Set(Get(N_982, "fs"), "title", ((V)((Truthy(Get(FZ_52, "on")) ? "Back to the room" : "Watch full screen"))));
}
}
mv_985 = Get(SH_50, "mv");
m_986 = Max(0D, Min(ToNum(Get(mv_985, "dur")), ToNum(Get(SH_50, "mt"))));
ttl_987 = (Truthy(((GtN(Get(SH_50, "msgT"), 0D) ? V.True : V.False) is var _t997 && !Truthy(_t997) ? _t997 : Get(SH_50, "msg"))) ? Get(SH_50, "msg") : Get(mv_985, "title"));
tm_988 = ((V)(JsStrBuf.Begin().V(Call(fmt_72, V.Undef, ((V)(m_986)))).S(" / ").V(Call(fmt_72, V.Undef, Get(mv_985, "dur"))).End()));
ic_989 = ((V)((Truthy(Get(SH_50, "pause")) ? "play" : "pause")));
if (!SEq(Get(Get(N_982, "ttl"), "textContent"), ttl_987)) {
Set(Get(N_982, "ttl"), "textContent", ttl_987);
}
if (!SEq(Get(Get(N_982, "tm"), "textContent"), tm_988)) {
Set(Get(N_982, "tm"), "textContent", tm_988);
}
Set(Get(Get(N_982, "fill"), "style"), "width", ((V)(JsStrBuf.Begin().V(Invoke(((V)(((100D * m_986) / ToNum(Get(mv_985, "dur"))))), "toFixed", ((V)(2D)))).S("%").End())));
if (!SEq(Get(Get(N_982, "pp"), "_ic"), ic_989)) {
Set(Get(N_982, "pp"), "_ic", ic_989);
Set(Get(N_982, "pp"), "innerHTML", GetK(ICON_89, ic_989));
Set(Get(N_982, "pp"), "title", ((V)((Truthy(Get(SH_50, "pause")) ? "Play" : "Pause"))));
}
return default;
}, 0, "uiUpd", false);
adAudio_93 = Fn((V _self998, int _argc999, V t0_1005, V _a1002, V _a1003, V _a1004, V[] _rest1000) => {
if (_self998.IsNullish) _self998 = GlobalV;
Call(noise_26, V.Undef, t0_1005, ((V)(0.5)), NewObj(6).Put("ft", ((V)("bandpass"))).Put("f", ((V)(400D))).Put("fTo", ((V)(5000D))).Put("q", ((V)(1.2))).Put("vol", ((V)(0.12))).Put("at", ((V)(0.4))).V);
Call(tone_25, V.Undef, ((V)((ToNum(t0_1005) - 0.3))), ((V)(58D)), ((V)(10.8)), NewObj(2).Put("vol", ((V)(0.02))).Put("at", ((V)(0.3))).V);
Call(kick_27, V.Undef, Add(t0_1005, ((V)(0.5))), ((V)(1D)));
Call(crash_34, V.Undef, Add(t0_1005, ((V)(0.5))));
Call(chord_33, V.Undef, Add(t0_1005, ((V)(0.5))), Arr(((V)(60D)), ((V)(64D)), ((V)(67D)), ((V)(72D))), ((V)(0.9)));
Invoke(Arr(((V)(84D)), ((V)(88D)), ((V)(91D)), ((V)(96D))), "forEach", Fn((V _arrowThis1014, int _argc1006, V m_1012, V i_1013, V _a1010, V _a1011, V[] _rest1007) => {
return Call(bell_32, V.Undef, Add(Add(t0_1005, ((V)(0.62))), ((V)((ToNum(i_1013) * 0.06)))), m_1012, ((V)(0.6)), ((V)(0.06)));
}, 2, "", true));
Call(kick_27, V.Undef, Add(t0_1005, ((V)(1D))), ((V)(0.6)));
Call(kick_27, V.Undef, Add(t0_1005, ((V)(1.5))), ((V)(0.6)));
Call(hat_29, V.Undef, Add(t0_1005, ((V)(1.25))));
Call(hat_29, V.Undef, Add(t0_1005, ((V)(1.75))));
{
double s_1015 = 0;
s_1015 = 0D;
while (true) {
if (!((s_1015 < 52D))) break;
Call(groove_38, V.Undef, Add(Add(t0_1005, ((V)(2D))), ((V)((s_1015 * STEP_12)))), ((V)(s_1015)));
s_1015++;
}
}
Invoke(Arr(((V)(2.5)), ((V)(3D)), ((V)(3.5)), ((V)(4D))), "forEach", Fn((V _arrowThis1025, int _argc1017, V x_1023, V k_1024, V _a1021, V _a1022, V[] _rest1018) => {
return Call(squishS_35, V.Undef, Add(t0_1005, x_1023), k_1024);
}, 2, "", true));
Invoke(Arr(((V)(72D)), ((V)(74D)), ((V)(76D)), ((V)(79D)), ((V)(81D)), ((V)(84D))), "forEach", Fn((V _arrowThis1034, int _argc1026, V m_1032, V i_1033, V _a1030, V _a1031, V[] _rest1027) => {
return Call(bell_32, V.Undef, Add(Add(t0_1005, ((V)(4.6))), ((V)((0.16 * ToNum(i_1033))))), m_1032, ((V)(0.4)), ((V)(0.14)));
}, 2, "", true));
Call(tone_25, V.Undef, Add(t0_1005, ((V)(7D))), ((V)(180D)), ((V)(0.4)), NewObj(4).Put("to", ((V)(420D))).Put("slide", ((V)(0.25))).Put("vol", ((V)(0.2))).Put("type", ((V)("triangle"))).V);
Call(kick_27, V.Undef, Add(t0_1005, ((V)(8.5))), ((V)(1D)));
Call(crash_34, V.Undef, Add(t0_1005, ((V)(8.5))));
Call(chord_33, V.Undef, Add(t0_1005, ((V)(8.5))), Arr(((V)(60D)), ((V)(64D)), ((V)(67D)), ((V)(72D))), ((V)(1.3)));
Invoke(Arr(((V)(72D)), ((V)(76D)), ((V)(79D)), ((V)(84D)), ((V)(88D))), "forEach", Fn((V _arrowThis1043, int _argc1035, V m_1041, V i_1042, V _a1039, V _a1040, V[] _rest1036) => {
return Call(lead_31, V.Undef, Add(Add(t0_1005, ((V)(8.6))), ((V)((ToNum(i_1042) * 0.1)))), m_1041, ((V)(0.25)), ((V)(0.1)));
}, 2, "", true));
Call(kick_27, V.Undef, Add(t0_1005, ((V)(9D))), ((V)(0.7)));
Call(snare_28, V.Undef, Add(t0_1005, ((V)(9.25))), ((V)(0.25)));
Call(kick_27, V.Undef, Add(t0_1005, ((V)(9.5))), ((V)(0.9)));
Call(chord_33, V.Undef, Add(t0_1005, ((V)(9.5))), Arr(((V)(48D)), ((V)(55D)), ((V)(60D)), ((V)(64D)), ((V)(67D)), ((V)(72D))), ((V)(1.2)), ((V)(0.045)));
Invoke(Arr(((V)(96D)), ((V)(100D)), ((V)(103D)), ((V)(108D))), "forEach", Fn((V _arrowThis1052, int _argc1044, V m_1050, V i_1051, V _a1048, V _a1049, V[] _rest1045) => {
return Call(bell_32, V.Undef, Add(Add(t0_1005, ((V)(9.6))), ((V)((ToNum(i_1051) * 0.05)))), m_1050, ((V)(0.7)), ((V)(0.05)));
}, 2, "", true));
return default;
}, 1, "adAudio", false);
mkVideo_95 = Fn((V _self1053, int _argc1054, V art_1060, V _a1057, V _a1058, V _a1059, V[] _rest1055) => {
V root_1061 = default;
V st_1062 = default;
V bg_1063 = default;
V rays_1064 = default;
V sc_1065 = default;
V T_1066 = default;
V I_1067 = default;
V put_1068 = default;
V foot_1069 = default;
V star_1070 = default;
V V_1071 = default;
V so_1072 = default;
V leader_1073 = default;
V flash_1074 = default;
V blk_1075 = default;
V BG_1076 = default;
V SPILL_1077 = default;
V press_1078 = default;
V upd_1079 = default;
if (_self1053.IsNullish) _self1053 = GlobalV;
upd_1079 = Fn((V _self1080, int _argc1081, V t_1087, V _a1084, V _a1085, V _a1086, V[] _rest1082) => {
double si_1088 = 0;
double ph_1089 = 0;
double bn_1090 = 0;
double bp_1091 = 0;
double hop_1092 = 0;
double fl_1093 = 0;
if (_self1080.IsNullish) _self1080 = GlobalV;
si_1088 = (LtN(t_1087, 2D) ? 0D : (LtN(t_1087, 4.5) ? 1D : (LtN(t_1087, 7D) ? 2D : (LtN(t_1087, 8.5) ? 3D : 4D))));
ph_1089 = ((((ToNum(t_1087) % BEAT_8) + BEAT_8) % BEAT_8) / BEAT_8);
bn_1090 = System.Math.Floor((ToNum(t_1087) / BEAT_8));
bp_1091 = FdLibm.Exp(((-ph_1089) * 5D));
hop_1092 = FdLibm.Sin((System.Math.PI * ph_1089));
Invoke(sc_1065, "forEach", Fn((V _arrowThis1102, int _argc1094, V s_1100, V i_1101, V _a1098, V _a1099, V[] _rest1095) => {
Set(Get(s_1100, "style"), "display", ((V)(((GeN(t_1087, 0D) && SEqN(i_1101, si_1088)) ? "block" : "none"))));
return default;
}, 2, "", true));
Set(Get(bg_1063, "style"), "background", (LtN(t_1087, 0D) ? ((V)("#05030a")) : GetIdx(BG_1076, si_1088)));
Set(Get(bg_1063, "style"), "opacity", ((si_1088 == 0D) ? Call(P_19, V.Undef, t_1087, ((V)(0D)), ((V)(0.4))) : ((V)(1D))));
Set(Get(rays_1064, "style"), "display", ((V)(((GeN(t_1087, 0D) && ((si_1088 == 0D) || (si_1088 == 4D))) ? "block" : "none"))));
Set(Get(rays_1064, "style"), "opacity", ((V)((0.12 + (0.08 * bp_1091)))));
Set(Get(rays_1064, "style"), "transform", ((V)(JsStrBuf.Begin().S("rotate(").N((ToNum(t_1087) * 25D)).S("deg)").End())));
Call(put_1068, V.Undef, leader_1073, ((V)(160D)), ((V)(90D)), ((V)(1D)), ((V)(0D)), ((V)((LtN(t_1087, 0D) ? (ToNum(Call(P_19, V.Undef, t_1087, ((V)((-1D))), ((V)((-0.6))))) * (1D - ToNum(Call(P_19, V.Undef, t_1087, ((V)((-0.25))), ((V)(0D)))))) : 0D))));
if ((si_1088 == 0D)) {
V k1_1103 = default;
V k2_1104 = default;
double pu_1105 = 0;
V ex_1106 = default;
k1_1103 = Call(P_19, V.Undef, t_1087, ((V)(0.42)), ((V)(0.85)), Get(E_18, "back"));
k2_1104 = Call(P_19, V.Undef, t_1087, ((V)(0.6)), ((V)(1.02)), Get(E_18, "back"));
pu_1105 = (GtN(t_1087, 1D) ? (1D + (0.05 * bp_1091)) : 1D);
ex_1106 = Call(P_19, V.Undef, t_1087, ((V)(1.8)), ((V)(2D)));
Call(put_1068, V.Undef, Get(V_1071, "a1"), ((V)(160D)), ((V)(70D)), ((V)(((ToNum(k1_1103) * pu_1105) * (1D + (ToNum(ex_1106) * 0.3))))), ((V)(((-4D) * (1D - ToNum(k1_1103))))), ((V)((GtN(k1_1103, 0D) ? (1D - ToNum(ex_1106)) : 0D))));
Call(put_1068, V.Undef, Get(V_1071, "a2"), ((V)(160D)), ((V)(116D)), ((V)(((ToNum(k2_1104) * pu_1105) * (1D + (ToNum(ex_1106) * 0.3))))), ((V)((3D * (1D - ToNum(k2_1104))))), ((V)((GtN(k2_1104, 0D) ? (1D - ToNum(ex_1106)) : 0D))));
Call(foot_1069, V.Undef, GetIdx(Get(V_1071, "ap"), 0D), ((V)(56D)), ((V)((214D - (54D * ToNum(Call(P_19, V.Undef, t_1087, ((V)(1D)), ((V)(1.35)), Get(E_18, "back"))))))), ((V)(1D)), ((V)(1D)), ((V)((-8D))));
Call(foot_1069, V.Undef, GetIdx(Get(V_1071, "ap"), 1D), ((V)(264D)), ((V)((214D - (54D * ToNum(Call(P_19, V.Undef, t_1087, ((V)(1.1)), ((V)(1.45)), Get(E_18, "back"))))))), ((V)(1D)), ((V)(1D)), ((V)(8D)));
Invoke(Arr(Arr(((V)(50D)), ((V)(38D))), Arr(((V)(272D)), ((V)(34D))), Arr(((V)(32D)), ((V)(124D))), Arr(((V)(290D)), ((V)(130D)))), "forEach", Fn((V _arrowThis1119, int _argc1107, V _a1109, V i_1113, V _a1111, V _a1112, V[] _rest1108) => {
V x_1116 = default;
V y_1118 = default;
{ V _t1114 = ListOf(_a1109);
{ V _t1115 = GetIdx(_t1114, 0D);
x_1116 = _t1115; }
{ V _t1117 = GetIdx(_t1114, 1D);
y_1118 = _t1117; }
}
return Call(put_1068, V.Undef, GetK(Get(V_1071, "as"), i_1113), x_1116, y_1118, ((V)((0.8 + (0.4 * FdLibm.Sin(((ToNum(t_1087) * 9D) + (ToNum(i_1113) * 2D))))))), ((V)(0D)), ((V)((ToNum(Call(P_19, V.Undef, t_1087, ((V)(0.5)), ((V)(0.7)))) * (0.55 + (0.45 * FdLibm.Sin(ToNum(Add(((V)((ToNum(t_1087) * 7D))), i_1113)))))))));
}, 2, "", true));
}
if ((si_1088 == 1D)) {
V pr_1120 = default;
V en_1121 = default;
V rd_1122 = default;
V W_1123 = default;
pr_1120 = Call(press_1078, V.Undef, t_1087, Arr(((V)(2.5)), ((V)(3D)), ((V)(3.5)), ((V)(4D))));
en_1121 = Call(P_19, V.Undef, t_1087, ((V)(2D)), ((V)(2.35)), Get(E_18, "back"));
Call(put_1068, V.Undef, Get(V_1071, "bc"), ((V)(160D)), ((V)(24D)), Call(P_19, V.Undef, t_1087, ((V)(2D)), ((V)(2.3)), Get(E_18, "back")), ((V)(0D)), ((V)(1D)));
Call(foot_1069, V.Undef, Get(V_1071, "bm"), ((V)(160D)), ((V)(((178D + (70D * (1D - ToNum(en_1121)))) - (Truthy(Get(pr_1120, "n")) ? 0D : (4D * hop_1092))))), ((V)((1D + (0.32 * ToNum(Get(pr_1120, "sq")))))), ((V)((1D - (0.3 * ToNum(Get(pr_1120, "sq")))))), ((V)(0D)), ((V)(1D)));
rd_1122 = Call(cl_17, V.Undef, ((V)((ToNum(Get(pr_1120, "d")) / 0.45))));
Set(Get(Get(V_1071, "br"), "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(160px,112px) translate(-50%,-50%) scale(").N((0.3 + (1.6 * ToNum(rd_1122)))).S(")").End())));
Set(Get(Get(V_1071, "br"), "style"), "opacity", ((V)((Truthy(Get(pr_1120, "n")) ? (0.85 * (1D - ToNum(rd_1122))) : 0D))));
W_1123 = GetIdx(Arr(Arr(((V)(250D)), ((V)(66D)), ((V)(12D))), Arr(((V)(72D)), ((V)(70D)), ((V)((-12D)))), Arr(((V)(252D)), ((V)(100D)), ((V)(10D))), Arr(((V)(70D)), ((V)(104D)), ((V)((-10D))))), Max(0D, (ToNum(Get(pr_1120, "n")) - 1D)));
Call(put_1068, V.Undef, Get(V_1071, "bw"), GetIdx(W_1123, 0D), GetIdx(W_1123, 1D), Call(P_19, V.Undef, Get(pr_1120, "d"), ((V)(0D)), ((V)(0.2)), Get(E_18, "back")), GetIdx(W_1123, 2D), ((V)((Truthy(Get(pr_1120, "n")) ? (1D - ToNum(Call(P_19, V.Undef, Get(pr_1120, "d"), ((V)(0.32)), ((V)(0.5))))) : 0D))));
Set(Get(V_1071, "bx"), "textContent", ((V)(JsStrBuf.Begin().S("COMBO x").N(Max(1D, ToNum(Get(pr_1120, "n")))).End())));
Call(put_1068, V.Undef, Get(V_1071, "bx"), ((V)(262D)), ((V)(156D)), ((V)((1D + (0.4 * FdLibm.Exp(((-ToNum(Get(pr_1120, "d"))) * 8D)))))), ((V)((-4D))), ((V)((Truthy(Get(pr_1120, "n")) ? 1D : 0D))));
}
if ((si_1088 == 2D)) {
Call(put_1068, V.Undef, Get(V_1071, "cc"), ((V)(160D)), ((V)(26D)), Call(P_19, V.Undef, t_1087, ((V)(4.5)), ((V)(4.8)), Get(E_18, "back")), ((V)(0D)), ((V)(1D)));
Invoke(Get(V_1071, "ck"), "forEach", Fn((V _arrowThis1132, int _argc1124, V n_1130, V i_1131, V _a1128, V _a1129, V[] _rest1125) => {
double a_1133 = 0;
V k_1134 = default;
double h_1135 = 0;
double x_1136 = 0;
double y_1137 = 0;
a_1133 = (4.6 + (0.16 * ToNum(i_1131)));
k_1134 = Call(P_19, V.Undef, t_1087, ((V)(a_1133)), ((V)((a_1133 + 0.32))), Get(E_18, "back"));
h_1135 = (NumTruthy((ToNum(Add(((V)(bn_1090)), i_1131)) % 2D)) ? 0D : ((hop_1092 * 7D) * (GtN(t_1087, 5.6) ? 1D : 0D)));
x_1136 = (38D + (48.8 * ToNum(i_1131)));
y_1137 = (150D + (NumTruthy((ToNum(i_1131) % 2D)) ? 14D : 0D));
Call(foot_1069, V.Undef, n_1130, ((V)(x_1136)), ((V)((y_1137 - h_1135))), k_1134, k_1134, ((V)(((NumTruthy((ToNum(i_1131) % 2D)) ? 4D : (-4D)) * hop_1092))), ((V)((GtN(k_1134, 0.01) ? 1D : 0D))));
Call(put_1068, V.Undef, GetK(Get(V_1071, "cs"), i_1131), ((V)((x_1136 + 18D))), ((V)((y_1137 - 52D))), Add(((V)(0.6)), Call(P_19, V.Undef, t_1087, ((V)(a_1133)), ((V)((a_1133 + 0.2))))), ((V)(0D)), ((V)((GtN(t_1087, a_1133) ? (1D - ToNum(Call(P_19, V.Undef, t_1087, ((V)((a_1133 + 0.15))), ((V)((a_1133 + 0.5)))))) : 0D))));
return default;
}, 2, "", true));
}
if ((si_1088 == 3D)) {
V k_1138 = default;
V seats_1139 = default;
Call(put_1068, V.Undef, Get(V_1071, "dc"), ((V)(160D)), ((V)(24D)), Call(P_19, V.Undef, t_1087, ((V)(7D)), ((V)(7.3)), Get(E_18, "back")), ((V)(0D)), ((V)(1D)));
k_1138 = Call(P_19, V.Undef, t_1087, ((V)(7D)), ((V)(7.32)), Get(E_18, "back"));
seats_1139 = Arr(Arr(((V)(112D)), ((V)(140D))), Arr(((V)(160D)), ((V)(140D))), Arr(((V)(208D)), ((V)(140D))));
if (Truthy(Get(V_1071, "ds"))) {
double s_1140 = 0;
double w_1141 = 0;
double h_1142 = 0;
double x0_1143 = 0;
double y0_1144 = 0;
double cw_1145 = 0;
s_1140 = Min((210D / ToNum(Get(so_1072, "w"))), (108D / ToNum(Get(so_1072, "h"))));
w_1141 = (ToNum(Get(so_1072, "w")) * s_1140);
h_1142 = (ToNum(Get(so_1072, "h")) * s_1140);
x0_1143 = (160D - (w_1141 / 2D));
y0_1144 = (172D - h_1142);
Set(Get(Get(V_1071, "ds"), "style"), "width", ((V)(JsStrBuf.Begin().N(w_1141).S("px").End())));
Set(Get(Get(V_1071, "ds"), "style"), "height", ((V)(JsStrBuf.Begin().N(h_1142).S("px").End())));
Set(Get(Get(V_1071, "ds"), "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").N(x0_1143).S("px,").N(y0_1144).S("px) scale(").V(k_1138).S(")").End())));
Set(Get(Get(V_1071, "ds"), "style"), "opacity", ((V)((GtN(k_1138, 0.01) ? 1D : 0D))));
if (Truthy((Get(so_1072, "seats") is var _t1146 && !Truthy(_t1146) ? _t1146 : (GeN(Get(Get(so_1072, "seats"), "length"), 3D) ? V.True : V.False)))) {
V bb_1147 = default;
V pick_1148 = default;
bb_1147 = (Get(so_1072, "bb") is var _t1149 && Truthy(_t1149) ? _t1149 : Arr(((V)(0D)), ((V)(0D)), Get(so_1072, "w"), Get(so_1072, "h")));
pick_1148 = (GtN(Get(Get(so_1072, "seats"), "length"), 3D) ? Arr(((V)(0D)), ((V)(System.Math.Floor((ToNum(Get(Get(so_1072, "seats"), "length")) / 2D)))), ((V)((ToNum(Get(Get(so_1072, "seats"), "length")) - 1D)))) : Arr(((V)(0D)), ((V)(1D)), ((V)(2D))));
seats_1139 = Invoke(pick_1148, "map", Fn((V _arrowThis1157, int _argc1150, V j_1156, V _a1153, V _a1154, V _a1155, V[] _rest1151) => {
return Arr(((V)((x0_1143 + ((ToNum(Get(GetK(Get(so_1072, "seats"), j_1156), "x")) - ToNum(GetIdx(bb_1147, 0D))) * s_1140)))), ((V)((y0_1144 + ((ToNum(Get(GetK(Get(so_1072, "seats"), j_1156), "y")) - ToNum(GetIdx(bb_1147, 1D))) * s_1140)))));
}, 1, "", true));
}
cw_1145 = Max(44D, Min(72D, (78D * s_1140)));
Invoke(Get(V_1071, "dk"), "forEach", Fn((V _arrowThis1165, int _argc1158, V n_1164, V _a1161, V _a1162, V _a1163, V[] _rest1159) => {
Set(n_1164, "_w", ((V)(cw_1145)));
Set(Get(n_1164, "style"), "width", ((V)(JsStrBuf.Begin().N(cw_1145).S("px").End())));
Set(Get(n_1164, "style"), "height", ((V)(JsStrBuf.Begin().N(cw_1145).S("px").End())));
return default;
}, 1, "", true));
}
Invoke(Get(V_1071, "dk"), "forEach", Fn((V _arrowThis1174, int _argc1166, V n_1172, V i_1173, V _a1170, V _a1171, V[] _rest1167) => {
double a_1175 = 0;
V d_1176 = default;
double h_1177 = 0;
V x_1178 = default;
V y_1179 = default;
a_1175 = (7.2 + (0.15 * ToNum(i_1173)));
d_1176 = Call(P_19, V.Undef, t_1087, ((V)(a_1175)), ((V)((a_1175 + 0.3))), Get(E_18, "back"));
h_1177 = (NumTruthy((ToNum(Add(((V)(bn_1090)), i_1173)) % 2D)) ? 0D : ((hop_1092 * 4D) * (GtN(t_1087, 7.7) ? 1D : 0D)));
{ V _t1180 = GetK(seats_1139, i_1173);
{ V _t1181 = ListOf(_t1180);
{ V _t1182 = GetIdx(_t1181, 0D);
x_1178 = _t1182; }
{ V _t1183 = GetIdx(_t1181, 1D);
y_1179 = _t1183; }
} }
Call(foot_1069, V.Undef, n_1172, x_1178, ((V)(((ToNum(y_1179) - (70D * (1D - ToNum(d_1176)))) - h_1177))), ((V)(1D)), ((V)(1D)), ((V)(0D)), ((V)((GtN(t_1087, a_1175) ? 1D : 0D))));
return default;
}, 2, "", true));
}
if ((si_1088 == 4D)) {
V k_1184 = default;
k_1184 = Call(P_19, V.Undef, t_1087, ((V)(8.5)), ((V)(8.85)), Get(E_18, "back"));
Call(put_1068, V.Undef, Get(V_1071, "e1"), ((V)(160D)), ((V)(52D)), ((V)((ToNum(k_1184) * (1D + (0.04 * bp_1091))))), ((V)(0D)), ((V)((GtN(k_1184, 0.01) ? 1D : 0D))));
Call(put_1068, V.Undef, Get(V_1071, "e2"), ((V)(160D)), ((V)(86D)), ((V)(1D)), ((V)(0D)), Call(P_19, V.Undef, t_1087, ((V)(8.8)), ((V)(9D))));
Call(put_1068, V.Undef, Get(V_1071, "eb"), ((V)(160D)), ((V)(126D)), ((V)((ToNum(Call(P_19, V.Undef, t_1087, ((V)(8.9)), ((V)(9.2)), Get(E_18, "back"))) * (1D + (0.07 * bp_1091))))), ((V)(0D)), ((V)((GtN(t_1087, 8.9) ? 1D : 0D))));
Call(foot_1069, V.Undef, GetIdx(Get(V_1071, "ek"), 0D), ((V)((46D - (90D * (1D - ToNum(Call(P_19, V.Undef, t_1087, ((V)(8.6)), ((V)(8.95)), Get(E_18, "back")))))))), ((V)((186D - (NumTruthy((bn_1090 % 2D)) ? 0D : (hop_1092 * 6D))))), ((V)(1D)), ((V)(1D)), ((V)((-6D))));
Call(foot_1069, V.Undef, GetIdx(Get(V_1071, "ek"), 1D), ((V)((274D + (90D * (1D - ToNum(Call(P_19, V.Undef, t_1087, ((V)(8.65)), ((V)(9D)), Get(E_18, "back")))))))), ((V)((186D - (NumTruthy((bn_1090 % 2D)) ? (hop_1092 * 6D) : 0D)))), ((V)(1D)), ((V)(1D)), ((V)(6D)));
Invoke(Arr(Arr(((V)(118D)), ((V)(18D))), Arr(((V)(212D)), ((V)(22D))), Arr(((V)(252D)), ((V)(92D)))), "forEach", Fn((V _arrowThis1197, int _argc1185, V _a1187, V i_1191, V _a1189, V _a1190, V[] _rest1186) => {
V x_1194 = default;
V y_1196 = default;
{ V _t1192 = ListOf(_a1187);
{ V _t1193 = GetIdx(_t1192, 0D);
x_1194 = _t1193; }
{ V _t1195 = GetIdx(_t1192, 1D);
y_1196 = _t1195; }
}
return Call(put_1068, V.Undef, GetK(Get(V_1071, "es"), i_1191), x_1194, y_1196, ((V)((0.8 + (0.4 * FdLibm.Sin(((ToNum(t_1087) * 9D) + (ToNum(i_1191) * 2D))))))), ((V)(0D)), ((V)((ToNum(Call(P_19, V.Undef, t_1087, ((V)(9D)), ((V)(9.2)))) * (0.55 + (0.45 * FdLibm.Sin(ToNum(Add(((V)((ToNum(t_1087) * 7D))), i_1191)))))))));
}, 2, "", true));
}
fl_1093 = 0D;
Invoke(Arr(((V)(2D)), ((V)(4.5)), ((V)(7D)), ((V)(8.5))), "forEach", Fn((V _arrowThis1205, int _argc1198, V c_1204, V _a1201, V _a1202, V _a1203, V[] _rest1199) => {
fl_1093 = Max(fl_1093, (1D - (System.Math.Abs((ToNum(t_1087) - ToNum(c_1204))) / 0.1)));
return default;
}, 1, "", true));
Set(Get(flash_1074, "style"), "opacity", ((V)((0.85 * ToNum(Call(cl_17, V.Undef, ((V)(fl_1093))))))));
Set(Get(blk_1075, "style"), "opacity", Call(P_19, V.Undef, t_1087, ((V)(AD_10)), ((V)((AD_10 + 0.5)))));
return NewObj(2).Put("rgb", (LtN(t_1087, 0D) ? ((V)("200,210,255")) : GetIdx(SPILL_1077, si_1088))).Put("lit", ((V)((LtN(t_1087, 0D) ? 0.25 : (((1D - ToNum(Call(P_19, V.Undef, t_1087, ((V)(AD_10)), ((V)((AD_10 + 0.5)))))) * (0.85 + (0.15 * bp_1091))) + (fl_1093 * 0.6)))))).V;
return default;
}, 1, "upd", false);
root_1061 = Call(el_55, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;transform-origin:0 0;overflow:hidden;background:#05030a;border-radius:1px;")));
st_1062 = Call(el_55, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;width:320px;height:180px;transform-origin:0 0;overflow:hidden;font-family:'Fredoka',sans-serif;font-weight:700;")), root_1061);
bg_1063 = Call(el_55, V.Undef, ((V)("div")), ((V)("position:absolute;inset:0;")), st_1062);
rays_1064 = Call(el_55, V.Undef, ((V)("div")), ((V)("position:absolute;left:-40px;top:-110px;width:400px;height:400px;")), st_1062);
Set(rays_1064, "innerHTML", ((V)(JsStrBuf.Begin().S("<svg viewBox=\"-200 -200 400 400\" width=\"400\" height=\"400\">").V(Invoke(Array_from(NewObj(1).Put("length", ((V)(12D))).V, Fn((V _arrowThis1214, int _argc1206, V __1212, V i_1213, V _a1210, V _a1211, V[] _rest1207) => {
double a_1215 = 0;
double b_1216 = 0;
a_1215 = (((ToNum(i_1213) / 12D) * System.Math.PI) * 2D);
b_1216 = (a_1215 + (System.Math.PI / 12D));
return ((V)(JsStrBuf.Begin().S("<path d=\"M0 0L").V(Invoke(((V)((FdLibm.Cos(a_1215) * 260D))), "toFixed", ((V)(1D)))).S(" ").V(Invoke(((V)((FdLibm.Sin(a_1215) * 260D))), "toFixed", ((V)(1D)))).S("L").V(Invoke(((V)((FdLibm.Cos(b_1216) * 260D))), "toFixed", ((V)(1D)))).S(" ").V(Invoke(((V)((FdLibm.Sin(b_1216) * 260D))), "toFixed", ((V)(1D)))).S("Z\" fill=\"#ffffff\"></path>").End()));
return default;
}, 2, "", true)), "join", ((V)("")))).S("</svg>").End())));
sc_1065 = Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(4D))), "map", Fn((V _arrowThis1223, int _argc1217, V _a1219, V _a1220, V _a1221, V _a1222, V[] _rest1218) => {
return Call(el_55, V.Undef, ((V)("div")), ((V)("position:absolute;inset:0;display:none;")), st_1062);
}, 0, "", true));
T_1066 = Fn((V _arrowThis1236, int _argc1224, V p_1230, V s_1231, V size_1232, V col_1233, V[] _rest1225) => {
V sh_1234 = default;
V extra_1235 = default;
sh_1234 = (_argc1224 > 4 ? _rest1225[0] : V.Undef);
extra_1235 = (_argc1224 > 5 ? _rest1225[1] : V.Undef);
return Call(el_55, V.Undef, ((V)("div")), ((V)(JsStrBuf.Begin().S("position:absolute;left:0;top:0;white-space:nowrap;line-height:1;font-size:").V(size_1232).S("px;color:").V(col_1233).S(";text-shadow:").V(sh_1234).S(";").V((extra_1235 is var _t1237 && Truthy(_t1237) ? _t1237 : ((V)("")))).End())), p_1230, s_1231);
}, 6, "", true);
I_1067 = Fn((V _arrowThis1247, int _argc1238, V p_1244, V k_1245, V w_1246, V _a1243, V[] _rest1239) => {
V n_1248 = default;
n_1248 = Call(el_55, V.Undef, ((V)("img")), ((V)(JsStrBuf.Begin().S("position:absolute;left:0;top:0;width:").V(w_1246).S("px;height:").V(w_1246).S("px;transform-origin:50% 94%;filter:drop-shadow(0 4px 4px rgba(20,8,40,0.35));").End())), p_1244);
Set(n_1248, "src", Call(csrc_16, V.Undef, k_1245));
Set(n_1248, "alt", ((V)("")));
Set(n_1248, "_w", w_1246);
return n_1248;
return default;
}, 3, "", true);
put_1068 = Fn((V _arrowThis1264, int _argc1249, V n_1255, V x_1256, V y_1257, V _a1254, V[] _rest1250) => {
V k_1259 = default;
V r_1261 = default;
V o_1263 = default;
{ V _t1258 = _a1254; if (_t1258.IsUndef) _t1258 = ((V)(1D));
k_1259 = _t1258; }
{ V _t1260 = (_argc1249 > 4 ? _rest1250[0] : V.Undef); if (_t1260.IsUndef) _t1260 = ((V)(0D));
r_1261 = _t1260; }
{ V _t1262 = (_argc1249 > 5 ? _rest1250[1] : V.Undef); if (_t1262.IsUndef) _t1262 = ((V)(1D));
o_1263 = _t1262; }
Set(Get(n_1255, "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").V(x_1256).S("px,").V(y_1257).S("px) translate(-50%,-50%) rotate(").V(r_1261).S("deg) scale(").V(k_1259).S(")").End())));
Set(Get(n_1255, "style"), "opacity", o_1263);
return default;
}, 6, "", true);
foot_1069 = Fn((V _arrowThis1282, int _argc1265, V n_1271, V x_1272, V y_1273, V _a1270, V[] _rest1266) => {
V w_1283 = default;
V sx_1275 = default;
V sy_1277 = default;
V r_1279 = default;
V o_1281 = default;
{ V _t1274 = _a1270; if (_t1274.IsUndef) _t1274 = ((V)(1D));
sx_1275 = _t1274; }
{ V _t1276 = (_argc1265 > 4 ? _rest1266[0] : V.Undef); if (_t1276.IsUndef) _t1276 = ((V)(1D));
sy_1277 = _t1276; }
{ V _t1278 = (_argc1265 > 5 ? _rest1266[1] : V.Undef); if (_t1278.IsUndef) _t1278 = ((V)(0D));
r_1279 = _t1278; }
{ V _t1280 = (_argc1265 > 6 ? _rest1266[2] : V.Undef); if (_t1280.IsUndef) _t1280 = ((V)(1D));
o_1281 = _t1280; }
w_1283 = Get(n_1271, "_w");
Set(Get(n_1271, "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").N((ToNum(x_1272) - (ToNum(w_1283) / 2D))).S("px,").N((ToNum(y_1273) - (ToNum(w_1283) * 0.94))).S("px) rotate(").V(r_1279).S("deg) scale(").V(sx_1275).S(",").V(sy_1277).S(")").End())));
Set(Get(n_1271, "style"), "opacity", o_1281);
return default;
}, 7, "", true);
star_1070 = Fn((V _arrowThis1292, int _argc1284, V p_1290, V c_1291, V _a1288, V _a1289, V[] _rest1285) => {
return Call(T_1066, V.Undef, p_1290, ((V)("\u2726")), ((V)(14D)), (c_1291 is var _t1293 && Truthy(_t1293) ? _t1293 : ((V)("#fff"))), ((V)("0 0 6px rgba(255,255,255,0.8)")));
}, 2, "", true);
V_1071 = NewObj(0).V;
Set(V_1071, "a1", Call(T_1066, V.Undef, GetIdx(sc_1065, 0D), ((V)("SQUISH")), ((V)(54D)), ((V)("#ffd66b")), Call(OUT_94, V.Undef, INK_13, ((V)(3D)))));
Set(V_1071, "a2", Call(T_1066, V.Undef, GetIdx(sc_1065, 0D), ((V)("SQUAD")), ((V)(46D)), ((V)("#ffffff")), Call(OUT_94, V.Undef, INK_13, ((V)(3D)))));
Set(V_1071, "ap", Arr(Call(I_1067, V.Undef, GetIdx(sc_1065, 0D), ((V)("mittens")), ((V)(78D))), Call(I_1067, V.Undef, GetIdx(sc_1065, 0D), ((V)("pip")), ((V)(72D)))));
Set(V_1071, "as", Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D))), "map", Fn((V _arrowThis1300, int _argc1294, V _a1296, V _a1297, V _a1298, V _a1299, V[] _rest1295) => {
return Call(star_1070, V.Undef, GetIdx(sc_1065, 0D));
}, 0, "", true)));
Set(V_1071, "bc", Call(T_1066, V.Undef, GetIdx(sc_1065, 1D), ((V)("SQUISH THEM!")), ((V)(22D)), ((V)("#ffffff")), Call(OUT_94, V.Undef, INK_13, ((V)(2.5)))));
Set(V_1071, "br", Call(el_55, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;width:100px;height:100px;border-radius:50%;border:3px solid #ffffff;box-sizing:border-box;")), GetIdx(sc_1065, 1D)));
Set(V_1071, "bm", Call(I_1067, V.Undef, GetIdx(sc_1065, 1D), ((V)("mittens")), ((V)(128D))));
Set(V_1071, "bw", Call(T_1066, V.Undef, GetIdx(sc_1065, 1D), ((V)("SQUISH!")), ((V)(28D)), ((V)("#ffd66b")), Call(OUT_94, V.Undef, INK_13, ((V)(2.5)))));
Set(V_1071, "bx", Call(T_1066, V.Undef, GetIdx(sc_1065, 1D), ((V)("COMBO x1")), ((V)(18D)), ((V)("#a6f06a")), Call(OUT_94, V.Undef, INK_13, ((V)(2D)))));
Set(V_1071, "cc", Call(T_1066, V.Undef, GetIdx(sc_1065, 2D), ((V)("COLLECT THEM ALL!")), ((V)(21D)), INK_13, Call(OUT_94, V.Undef, ((V)("#ffffff")), ((V)(2.5)))));
Set(V_1071, "ck", Invoke(Arr(((V)("mochi")), ((V)("boba")), ((V)("kiwi")), ((V)("floof")), ((V)("gumdrop")), ((V)("mallow"))), "map", Fn((V _arrowThis1308, int _argc1301, V k_1307, V _a1304, V _a1305, V _a1306, V[] _rest1302) => {
return Call(I_1067, V.Undef, GetIdx(sc_1065, 2D), k_1307, ((V)(58D)));
}, 1, "", true)));
Set(V_1071, "cs", Invoke(Get(V_1071, "ck"), "map", Fn((V _arrowThis1315, int _argc1309, V _a1311, V _a1312, V _a1313, V _a1314, V[] _rest1310) => {
return Call(star_1070, V.Undef, GetIdx(sc_1065, 2D), ((V)("#fff8d0")));
}, 0, "", true)));
Set(V_1071, "dc", Call(T_1066, V.Undef, GetIdx(sc_1065, 3D), ((V)("BUILD YOUR SQUAD HOUSE")), ((V)(19D)), ((V)("#ffffff")), Call(OUT_94, V.Undef, INK_13, ((V)(2.5)))));
so_1072 = Get(art_1060, "sofa");
if (Truthy((so_1072 is var _t1316 && !Truthy(_t1316) ? _t1316 : Get(so_1072, "src")))) {
Set(V_1071, "ds", Call(el_55, V.Undef, ((V)("img")), ((V)("position:absolute;left:0;top:0;transform-origin:50% 100%;filter:drop-shadow(0 5px 5px rgba(0,30,30,0.35));")), GetIdx(sc_1065, 3D)));
Set(Get(V_1071, "ds"), "src", Get(so_1072, "src"));
Set(Get(V_1071, "ds"), "alt", ((V)("")));
}
Set(V_1071, "dk", Invoke(Arr(((V)("pip")), ((V)("mittens")), ((V)("boba"))), "map", Fn((V _arrowThis1324, int _argc1317, V k_1323, V _a1320, V _a1321, V _a1322, V[] _rest1318) => {
return Call(I_1067, V.Undef, GetIdx(sc_1065, 3D), k_1323, ((V)(60D)));
}, 1, "", true)));
Set(V_1071, "e1", Call(T_1066, V.Undef, GetIdx(sc_1065, 4D), ((V)("SQUISH SQUAD")), ((V)(38D)), ((V)("#ffd66b")), Call(OUT_94, V.Undef, INK_13, ((V)(3D)))));
Set(V_1071, "e2", Call(T_1066, V.Undef, GetIdx(sc_1065, 4D), ((V)("FREE TO PLAY")), ((V)(13D)), ((V)("#ffffff")), Call(OUT_94, V.Undef, INK_13, ((V)(1.5))), ((V)("letter-spacing:2px;"))));
Set(V_1071, "eb", Call(el_55, V.Undef, ((V)("div")), ((V)(JsStrBuf.Begin().S("position:absolute;left:0;top:0;width:132px;height:36px;border-radius:999px;border:3px solid #ffffff;box-sizing:border-box;background:linear-gradient(#ffe27a,#f5b02a);box-shadow:0 4px 0 ").V(INK_13).S(";display:flex;align-items:center;justify-content:center;font-size:17px;color:").V(INK_13).S(";").End())), GetIdx(sc_1065, 4D), ((V)("PLAY NOW"))));
Set(V_1071, "ek", Arr(Call(I_1067, V.Undef, GetIdx(sc_1065, 4D), ((V)("mittens")), ((V)(88D))), Call(I_1067, V.Undef, GetIdx(sc_1065, 4D), ((V)("boba")), ((V)(84D)))));
Set(V_1071, "es", Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis1331, int _argc1325, V _a1327, V _a1328, V _a1329, V _a1330, V[] _rest1326) => {
return Call(star_1070, V.Undef, GetIdx(sc_1065, 4D));
}, 0, "", true)));
leader_1073 = Call(T_1066, V.Undef, st_1062, ((V)("NOW SHOWING")), ((V)(16D)), ((V)("#ffffff")), ((V)("none")), ((V)("letter-spacing:3px;")));
flash_1074 = Call(el_55, V.Undef, ((V)("div")), ((V)("position:absolute;inset:0;background:#ffffff;opacity:0;")), st_1062);
blk_1075 = Call(el_55, V.Undef, ((V)("div")), ((V)("position:absolute;inset:0;background:#05030a;opacity:0;")), st_1062);
BG_1076 = Arr(((V)("radial-gradient(circle at 50% 45%, #8a4ad8, #2a0f4f 75%)")), ((V)("radial-gradient(circle at 50% 55%, #5a74ee, #1d2a7a 78%)")), ((V)("radial-gradient(circle at 50% 60%, #ffe58a, #f59a2a 80%)")), ((V)("radial-gradient(circle at 50% 60%, #5fe0c8, #0f6a6a 80%)")), ((V)("radial-gradient(circle at 50% 45%, #8a4ad8, #2a0f4f 75%)")));
SPILL_1077 = Arr(((V)("155,92,240")), ((V)("90,116,238")), ((V)("255,207,74")), ((V)("63,208,184")), ((V)("155,92,240")));
press_1078 = Fn((V _arrowThis1340, int _argc1332, V t_1338, V list_1339, V _a1336, V _a1337, V[] _rest1333) => {
V last_1341 = default;
double d_1342 = 0;
V n_1343 = default;
last_1341 = V.Null;
Invoke(list_1339, "forEach", Fn((V _arrowThis1351, int _argc1344, V p_1350, V _a1347, V _a1348, V _a1349, V[] _rest1345) => {
if (Ge(t_1338, p_1350)) {
last_1341 = p_1350;
}
return default;
}, 1, "", true));
if (SEq(last_1341, V.Null)) {
return NewObj(3).Put("sq", ((V)(0D))).Put("n", ((V)(0D))).Put("d", ((V)(99D))).V;
}
d_1342 = (ToNum(t_1338) - ToNum(last_1341));
n_1343 = Get(Invoke(list_1339, "filter", Fn((V _arrowThis1359, int _argc1352, V p_1358, V _a1355, V _a1356, V _a1357, V[] _rest1353) => {
return (Ge(t_1338, p_1358) ? V.True : V.False);
}, 1, "", true)), "length");
return NewObj(3).Put("sq", ((V)(((d_1342 < 0.08) ? (d_1342 / 0.08) : ((d_1342 < 0.15) ? 1D : Max(0D, (FdLibm.Cos(((d_1342 - 0.15) * 14D)) * FdLibm.Exp(((-(d_1342 - 0.15)) * 7D))))))))).Put("n", n_1343).Put("d", ((V)(d_1342))).V;
return default;
}, 2, "", true);
return NewObj(3).Put("root", root_1061).Put("st", st_1062).Put("upd", upd_1079).V;
return default;
}, 1, "mkVideo", false);
loop_98 = Fn((V _self1360, int _argc1361, V _a1363, V _a1364, V _a1365, V _a1366, V[] _rest1362) => {
if (_self1360.IsNullish) _self1360 = GlobalV;
if (Truthy(RAF_96)) {
return default;
}
RAF_96 = Call(G("requestAnimationFrame"), V.Undef, frame_101);
TO_97 = Call(G("setTimeout"), V.Undef, frame_101, ((V)(60D)));
return default;
}, 0, "loop", false);
spawn_99 = Fn((V _self1367, int _argc1368, V fx_1374, V tgt_1375, V n_1376, V _a1373, V[] _rest1369) => {
V a_1377 = default;
V b_1378 = default;
double cx_1379 = 0;
double cy_1380 = 0;
double w_1381 = 0;
V c_1382 = default;
V r_1383 = default;
double sz_1384 = 0;
double dx_1385 = 0;
V s_1386 = default;
if (_self1367.IsNullish) _self1367 = GlobalV;
if ((!(Truthy(fx_1374)) || !(Truthy(Get(fx_1374, "isConnected"))))) {
return default;
}
a_1377 = Invoke(tgt_1375, "getBoundingClientRect");
b_1378 = Invoke(fx_1374, "getBoundingClientRect");
if (!(Truthy(Get(a_1377, "width")))) {
return default;
}
cx_1379 = ((ToNum(Get(a_1377, "left")) - ToNum(Get(b_1378, "left"))) + (ToNum(Get(a_1377, "width")) / 2D));
cy_1380 = ((ToNum(Get(a_1377, "top")) - ToNum(Get(b_1378, "top"))) + (ToNum(Get(a_1377, "height")) * 0.45));
w_1381 = Max(24D, (ToNum(Get(a_1377, "width")) * 0.7));
c_1382 = GetIdx(NC_15, (ToNum(n_1376) % ToNum(Get(NC_15, "length"))));
r_1383 = Call(el_55, V.Undef, ((V)("div")), ((V)(JsStrBuf.Begin().S("position:absolute;left:").N((cx_1379 - (w_1381 / 2D))).S("px;top:").N((cy_1380 - (w_1381 / 2D))).S("px;width:").N(w_1381).S("px;height:").N(w_1381).S("px;border-radius:50%;border:2.5px solid ").V(c_1382).S(";box-sizing:border-box;pointer-events:none;").End())), fx_1374);
Set(Invoke(r_1383, "animate", Arr(NewObj(2).Put("transform", ((V)("scale(0.35)"))).Put("opacity", ((V)(0.9))).V, NewObj(2).Put("transform", ((V)("scale(1.7)"))).Put("opacity", ((V)(0D))).V), NewObj(2).Put("duration", ((V)(620D))).Put("easing", ((V)("ease-out"))).V), "onfinish", Fn((V _arrowThis1393, int _argc1387, V _a1389, V _a1390, V _a1391, V _a1392, V[] _rest1388) => {
return Invoke(r_1383, "remove");
}, 0, "", true));
sz_1384 = Max(15D, Min(34D, (ToNum(Get(a_1377, "width")) * 0.3)));
dx_1385 = ((NumTruthy((ToNum(n_1376) % 2D)) ? 1D : (-1D)) * ((ToNum(Get(a_1377, "width")) * 0.35) + (ToNum(Invoke(G("Math"), "random")) * 10D)));
s_1386 = Call(el_55, V.Undef, ((V)("span")), ((V)(JsStrBuf.Begin().S("position:absolute;left:").N((cx_1379 - (sz_1384 / 3D))).S("px;top:").N((((ToNum(Get(a_1377, "top")) - ToNum(Get(b_1378, "top"))) + (ToNum(Get(a_1377, "height")) * 0.2)) - (sz_1384 / 2D))).S("px;font-family:'Fredoka',sans-serif;font-weight:700;font-size:").N(sz_1384).S("px;line-height:1;color:").V(c_1382).S(";text-shadow:0 2px 0 ").V(INK_13).S(";pointer-events:none;").End())), fx_1374, GetIdx(NOTE_14, (ToNum(n_1376) % 3D)));
Set(Invoke(s_1386, "animate", Arr(NewObj(2).Put("transform", ((V)("translate(0,0) rotate(0deg) scale(0.6)"))).Put("opacity", ((V)(0D))).V, NewObj(3).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").N((dx_1385 * 0.4)).S("px,").N(((-ToNum(Get(a_1377, "height"))) * 0.35)).S("px) rotate(").N(((dx_1385 > 0D) ? 10D : (-10D))).S("deg) scale(1.1)").End()))).Put("opacity", ((V)(1D))).Put("offset", ((V)(0.25))).V, NewObj(2).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").N(dx_1385).S("px,").N((((-ToNum(Get(a_1377, "height"))) * 0.95) - 20D)).S("px) rotate(").N(((dx_1385 > 0D) ? (-12D) : 12D)).S("deg) scale(0.9)").End()))).Put("opacity", ((V)(0D))).V), NewObj(2).Put("duration", ((V)(1300D))).Put("easing", ((V)("ease-out"))).V), "onfinish", Fn((V _arrowThis1400, int _argc1394, V _a1396, V _a1397, V _a1398, V _a1399, V[] _rest1395) => {
return Invoke(s_1386, "remove");
}, 0, "", true));
return default;
}, 3, "spawn", false);
bounce_100 = Fn((V _self1401, int _argc1402, V tgt_1408, V fx_1409, V ph_1410, V n_1411, V[] _rest1403) => {
double hop_1414 = 0;
double sq_1415 = 0;
double big_1416 = 0;
V H_1417 = default;
double jx_1418 = 0;
double jy_1419 = 0;
double ty_1420 = 0;
double sx_1421 = 0;
double sy_1422 = 0;
double rot_1423 = 0;
V now_1412 = default;
V amp_1413 = default;
if (_self1401.IsNullish) _self1401 = GlobalV;
now_1412 = (_argc1402 > 4 ? _rest1403[0] : V.Undef);
amp_1413 = (_argc1402 > 5 ? _rest1403[1] : V.Undef);
hop_1414 = FdLibm.Sin((System.Math.PI * ToNum(ph_1410)));
sq_1415 = FdLibm.Exp(((-ToNum(ph_1410)) * 9D));
big_1416 = (((ToNum(n_1411) % 4D) == 0D) ? 1.6 : 1D);
H_1417 = (Get(tgt_1408, "offsetHeight") is var _t1424 && Truthy(_t1424) ? _t1424 : ((V)(60D)));
jx_1418 = (((FdLibm.Sin((ToNum(now_1412) * 0.11)) * 1.5) * ToNum(amp_1413)) * (0.35 + sq_1415));
jy_1419 = (((FdLibm.Cos((ToNum(now_1412) * 0.137)) * 0.9) * ToNum(amp_1413)) * (0.35 + sq_1415));
ty_1420 = (((((-hop_1414) * ToNum(H_1417)) * 0.1) * big_1416) * ToNum(amp_1413));
sx_1421 = ((1D + ((0.14 * sq_1415) * ToNum(amp_1413))) - (0.04 * hop_1414));
sy_1422 = ((1D - ((0.14 * sq_1415) * ToNum(amp_1413))) + ((0.06 * hop_1414) * ToNum(amp_1413)));
rot_1423 = (((((NumTruthy((ToNum(n_1411) % 2D)) ? 1D : (-1D)) * 3D) * hop_1414) * ToNum(amp_1413)) * big_1416);
Set(Get(tgt_1408, "style"), "transformOrigin", ((V)("50% 100%")));
Set(Get(tgt_1408, "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").V(Invoke(((V)(jx_1418)), "toFixed", ((V)(2D)))).S("px,").V(Invoke(((V)((ty_1420 + jy_1419))), "toFixed", ((V)(2D)))).S("px) rotate(").V(Invoke(((V)(rot_1423)), "toFixed", ((V)(2D)))).S("deg) scale(").V(Invoke(((V)(sx_1421)), "toFixed", ((V)(3D)))).S(",").V(Invoke(((V)(sy_1422)), "toFixed", ((V)(3D)))).S(")").End())));
if (!SEq(Get(tgt_1408, "_mnB"), n_1411)) {
Set(tgt_1408, "_mnB", n_1411);
Call(spawn_99, V.Undef, fx_1409, tgt_1408, n_1411);
}
return default;
}, 6, "bounce", false);
frame_101 = Fn((V _self1425, int _argc1426, V _a1428, V _a1429, V _a1430, V _a1431, V[] _rest1427) => {
V now_1432 = default;
V beat_1433 = default;
V list_1434 = default;
V dead_1435 = default;
if (_self1425.IsNullish) _self1425 = GlobalV;
Call(G("cancelAnimationFrame"), V.Undef, RAF_96);
Call(G("clearTimeout"), V.Undef, TO_97);
RAF_96 = ((V)(0D));
now_1432 = Invoke(G("performance"), "now");
beat_1433 = V.Null;
if (Truthy(SH_50)) {
double dt_1436 = 0;
dt_1436 = Min(0.25, Max(0D, ((ToNum(now_1432) - ToNum(Get(SH_50, "last"))) / 1000D)));
Set(SH_50, "last", now_1432);
if (!(Truthy(Get(SH_50, "pause")))) {
OpSet(SH_50, "age", 0, ((V)(dt_1436)));
if (!(Truthy(Get(SH_50, "done")))) {
V m0_1437 = default;
m0_1437 = Get(SH_50, "mt");
OpSet(SH_50, "mt", 0, ((V)(dt_1436)));
if (Ge(Get(SH_50, "mt"), Get(Get(SH_50, "mv"), "dur"))) {
Set(SH_50, "mt", Get(Get(SH_50, "mv"), "dur"));
Set(SH_50, "done", (true ? V.True : V.False));
}
Call(cues_85, V.Undef, m0_1437, Get(SH_50, "mt"));
if (!SEqN(Get(SH_50, "sv"), System.Math.Floor(ToNum(Get(SH_50, "mt"))))) {
Set(SH_50, "sv", ((V)(System.Math.Floor(ToNum(Get(SH_50, "mt"))))));
Call(savePos_81, V.Undef, SH_50);
}
} else {
OpSet(SH_50, "endA", 0, ((V)(dt_1436)));
}
if ((GtN(Get(SH_50, "msgT"), 0D) && GtN(Get(SH_50, "mt"), 0D))) {
OpSet(SH_50, "msgT", 1, ((V)(dt_1436)));
}
}
if (Truthy((Get(SH_50, "done") is var _t1438 && !Truthy(_t1438) ? _t1438 : (GtN(Get(SH_50, "endA"), (UP_11 + 0.6)) ? V.True : V.False)))) {
Call(stopShow_88, V.Undef);
}
}
if (Truthy((((SH_50 is var _t1439 && !Truthy(_t1439) ? _t1439 : (!(Truthy(Get(SH_50, "pause"))) ? V.True : V.False)) is var _t1440 && !Truthy(_t1440) ? _t1440 : (!(Truthy(Get(SH_50, "done"))) ? V.True : V.False)) is var _t1441 && !Truthy(_t1441) ? _t1441 : (GeN(Get(SH_50, "mt"), 0D) ? V.True : V.False)))) {
if (Truthy(Get(Get(SH_50, "mv"), "ad"))) {
double b_1442 = 0;
b_1442 = (ToNum(Get(SH_50, "mt")) / BEAT_8);
beat_1433 = NewObj(3).Put("n", ((V)(System.Math.Floor(b_1442)))).Put("ph", ((V)((b_1442 - System.Math.Floor(b_1442))))).Put("amp", ((V)((LtN(Get(SH_50, "mt"), 2D) ? 0.55 : 1D)))).V;
} else {
if (Truthy(Get(Get(SH_50, "mv"), "beat"))) {
beat_1433 = Invoke(Get(SH_50, "mv"), "beat", Get(SH_50, "mt"));
}
}
} else {
if (Truthy(((!(Truthy(SH_50)) ? V.True : V.False) is var _t1443 && !Truthy(_t1443) ? _t1443 : Get(J_40, "on")))) {
double b_1444 = 0;
b_1444 = Max(0D, ((ToNum(now_1432) - ToNum(Get(J_40, "p0"))) / 500D));
beat_1433 = NewObj(3).Put("n", ((V)(System.Math.Floor(b_1444)))).Put("ph", ((V)((b_1444 - System.Math.Floor(b_1444))))).Put("amp", ((V)(1D))).V;
}
}
if (Truthy(((((SH_50 is var _t1445 && !Truthy(_t1445) ? _t1445 : (!(Truthy(Get(SH_50, "pause"))) ? V.True : V.False)) is var _t1446 && !Truthy(_t1446) ? _t1446 : (!(Truthy(Get(Get(SH_50, "mv"), "ad"))) ? V.True : V.False)) is var _t1447 && !Truthy(_t1447) ? _t1447 : Get(SH_50, "bus")) is var _t1448 && !Truthy(_t1448) ? _t1448 : Get(A_20, "ctx")))) {
Call(sched_84, V.Undef, SH_50);
}
list_1434 = Arr();
dead_1435 = Arr();
Invoke(K_39, "forEach", Fn((V _arrowThis1457, int _argc1449, V g_1455, V key_1456, V _a1453, V _a1454, V[] _rest1450) => {
V o_1458 = default;
o_1458 = Call(g_1455, V.Undef);
if (((!(Truthy(o_1458)) || !(Truthy(Get(o_1458, "el")))) || !(Truthy(Get(Get(o_1458, "el"), "isConnected"))))) {
Invoke(dead_1435, "push", key_1456);
} else {
Invoke(list_1434, "push", o_1458);
}
return default;
}, 2, "", true));
Invoke(dead_1435, "forEach", Fn((V _arrowThis1466, int _argc1459, V k_1465, V _a1462, V _a1463, V _a1464, V[] _rest1460) => {
return Call(stop_45, V.Undef, k_1465);
}, 1, "", true));
if (Truthy((SH_50 is var _t1467 && !Truthy(_t1467) ? _t1467 : RM_48))) {
Invoke(Invoke(RM_48, "querySelectorAll", ((V)("[data-kind=\"spk\"]"))), "forEach", Fn((V _arrowThis1475, int _argc1468, V n_1474, V _a1471, V _a1472, V _a1473, V[] _rest1469) => {
V t_1476 = default;
t_1476 = Get(n_1474, "firstElementChild");
if (Truthy((t_1476 is var _t1485 && !Truthy(_t1485) ? _t1485 : (!(Truthy(Invoke(list_1434, "some", Fn((V _arrowThis1484, int _argc1477, V o_1483, V _a1480, V _a1481, V _a1482, V[] _rest1478) => {
return (SEq(Get(o_1483, "el"), t_1476) ? V.True : V.False);
}, 1, "", true)))) ? V.True : V.False)))) {
Invoke(list_1434, "push", NewObj(2).Put("el", t_1476).Put("fx", L_47).V);
}
return default;
}, 1, "", true));
}
Invoke(list_1434, "forEach", Fn((V _arrowThis1493, int _argc1486, V o_1492, V _a1489, V _a1490, V _a1491, V[] _rest1487) => {
if (Truthy(beat_1433)) {
Call(bounce_100, V.Undef, Get(o_1492, "el"), Get(o_1492, "fx"), Get(beat_1433, "ph"), Get(beat_1433, "n"), now_1432, Get(beat_1433, "amp"));
} else {
Call(resetEl_43, V.Undef, Get(o_1492, "el"));
}
return default;
}, 1, "", true));
if (Truthy(((SH_50 is var _t1494 && !Truthy(_t1494) ? _t1494 : RM_48) is var _t1495 && !Truthy(_t1495) ? _t1495 : beat_1433))) {
Invoke(Invoke(RM_48, "querySelectorAll", ((V)("[data-kind=\"crew\"]"))), "forEach", Fn((V _arrowThis1504, int _argc1496, V n_1502, V i_1503, V _a1500, V _a1501, V[] _rest1497) => {
V t_1505 = default;
double h_1506 = 0;
V H_1507 = default;
t_1505 = Get(n_1502, "firstElementChild");
if (!(Truthy(t_1505))) {
return default;
}
h_1506 = (NumTruthy((ToNum(Add(Get(beat_1433, "n"), i_1503)) % 2D)) ? 0D : FdLibm.Sin((System.Math.PI * ToNum(Get(beat_1433, "ph")))));
H_1507 = (Get(t_1505, "offsetHeight") is var _t1508 && Truthy(_t1508) ? _t1508 : ((V)(40D)));
Set(Get(t_1505, "style"), "transformOrigin", ((V)("50% 90%")));
Set(Get(t_1505, "style"), "transform", ((V)(JsStrBuf.Begin().S("translateY(").V(Invoke(((V)((((-h_1506) * ToNum(H_1507)) * 0.08))), "toFixed", ((V)(2D)))).S("px) scale(").N((1D + (0.04 * h_1506))).S(",").N((1D - (0.03 * h_1506))).S(")").End())));
return default;
}, 2, "", true));
}
if (Truthy(((TH_46 is var _t1509 && !Truthy(_t1509) ? _t1509 : L_47) is var _t1510 && !Truthy(_t1510) ? _t1510 : Get(L_47, "_mn")))) {
V N_1511 = default;
V sc_1512 = default;
V q_1513 = default;
V cen_1514 = default;
V pl_1515 = default;
N_1511 = Get(L_47, "_mn");
sc_1512 = Get(TH_46, "screen");
q_1513 = (Truthy(sc_1512) ? Call(quad_66, V.Undef, sc_1512) : V.Null);
cen_1514 = (Truthy(q_1513) ? Arr(((V)((ToNum(Add(GetIdx(GetIdx(q_1513, 0D), 0D), GetIdx(GetIdx(q_1513, 2D), 0D))) / 2D))), ((V)((ToNum(Add(GetIdx(GetIdx(q_1513, 0D), 1D), GetIdx(GetIdx(q_1513, 2D), 1D))) / 2D)))) : V.Null);
pl_1515 = (Truthy(Get(TH_46, "player")) ? Call(centerOf_65, V.Undef, Get(TH_46, "player"), ((V)(0.35))) : V.Null);
if (Truthy((((Get(TH_46, "synced") is var _t1516 && !Truthy(_t1516) ? _t1516 : (!SEq(Get(TH_46, "edit"), (false ? V.True : V.False)) ? V.True : V.False)) is var _t1517 && !Truthy(_t1517) ? _t1517 : (!(Truthy(SH_50)) ? V.True : V.False)) is var _t1518 && !Truthy(_t1518) ? _t1518 : cen_1514))) {
V pts_1519 = default;
double pu_1520 = 0;
V off_1521 = default;
JsStrBuf s_1522 = null;
pts_1519 = Invoke(Arr(cen_1514), "concat", Invoke(Invoke((Get(TH_46, "spk") is var _t1531 && Truthy(_t1531) ? _t1531 : Arr()), "map", Fn((V _arrowThis1530, int _argc1523, V u_1529, V _a1526, V _a1527, V _a1528, V[] _rest1524) => {
return Call(centerOf_65, V.Undef, u_1529, ((V)(0.4)));
}, 1, "", true)), "filter", G("Boolean")));
pu_1520 = FdLibm.Exp(((-((ToNum(now_1432) / 500D) % 1D)) * 4D));
off_1521 = Invoke(((V)(((-ToNum(now_1432)) * 0.03))), "toFixed", ((V)(1D)));
s_1522 = new JsStrBuf("");
if (Truthy(pl_1515)) {
Invoke(pts_1519, "forEach", Fn((V _arrowThis1539, int _argc1532, V p_1538, V _a1535, V _a1536, V _a1537, V[] _rest1533) => {
s_1522.S("<line x1=\"").V(Invoke(GetIdx(pl_1515, 0D), "toFixed", ((V)(1D)))).S("\" y1=\"").V(Invoke(GetIdx(pl_1515, 1D), "toFixed", ((V)(1D)))).S("\" x2=\"").V(Invoke(GetIdx(p_1538, 0D), "toFixed", ((V)(1D)))).S("\" y2=\"").V(Invoke(GetIdx(p_1538, 1D), "toFixed", ((V)(1D)))).S("\" stroke=\"#6fe39a\" stroke-width=\"2\" stroke-dasharray=\"5 6\" stroke-dashoffset=\"").V(off_1521).S("\" stroke-linecap=\"round\" opacity=\"0.75\"></line>");
return default;
}, 1, "", true));
}
Invoke(Invoke((Truthy(pl_1515) ? Arr(pl_1515) : Arr()), "concat", pts_1519), "forEach", Fn((V _arrowThis1547, int _argc1540, V p_1546, V _a1543, V _a1544, V _a1545, V[] _rest1541) => {
s_1522.S("<circle cx=\"").V(Invoke(GetIdx(p_1546, 0D), "toFixed", ((V)(1D)))).S("\" cy=\"").V(Invoke(GetIdx(p_1546, 1D), "toFixed", ((V)(1D)))).S("\" r=\"").V(Invoke(((V)((6D + (6D * pu_1520)))), "toFixed", ((V)(1D)))).S("\" fill=\"#6fe39a\" opacity=\"").V(Invoke(((V)((0.25 * pu_1520))), "toFixed", ((V)(2D)))).S("\"></circle><circle cx=\"").V(Invoke(GetIdx(p_1546, 0D), "toFixed", ((V)(1D)))).S("\" cy=\"").V(Invoke(GetIdx(p_1546, 1D), "toFixed", ((V)(1D)))).S("\" r=\"3.5\" fill=\"#6fe39a\" stroke=\"#1e4a2a\" stroke-width=\"1.5\"></circle>");
return default;
}, 1, "", true));
Set(Get(N_1511, "links"), "innerHTML", ((V)(s_1522.Str)));
} else {
Set(Get(N_1511, "links"), "innerHTML", ((V)("")));
}
Call(uiUpd_92, V.Undef);
if (Truthy((SH_50 is var _t1548 && !Truthy(_t1548) ? _t1548 : q_1513))) {
V dOp_1549 = default;
V v_1550 = default;
V m_1551 = default;
double s_1552 = 0;
double fin_1553 = 0;
V fe_1554 = default;
V o_1555 = default;
V on_1556 = default;
double R_1557 = 0;
dOp_1549 = (Truthy(Get(SH_50, "done")) ? ((V)((1D - ToNum(Call(cl_17, V.Undef, ((V)((ToNum(Get(SH_50, "endA")) / UP_11)))))))) : Invoke(E_18, "out", Call(cl_17, V.Undef, ((V)((ToNum(Get(SH_50, "age")) / DIM_9))))));
v_1550 = Get(SH_50, "vid");
m_1551 = Get(sc_1512, "m");
s_1552 = Max((ToNum(Get(sc_1512, "w")) / 320D), (ToNum(Get(sc_1512, "h")) / 180D));
fin_1553 = (Truthy(Get(SH_50, "done")) ? (1D - ToNum(Call(cl_17, V.Undef, ((V)(((ToNum(Get(SH_50, "endA")) - 0.5) / 0.6)))))) : 1D);
fe_1554 = Call(fzStep_63, V.Undef, N_1511, now_1432);
if (LeN(fe_1554, 0D)) {
Set(Get(Get(v_1550, "root"), "style"), "width", ((V)(JsStrBuf.Begin().V(Get(sc_1512, "w")).S("px").End())));
Set(Get(Get(v_1550, "root"), "style"), "height", ((V)(JsStrBuf.Begin().V(Get(sc_1512, "h")).S("px").End())));
Set(Get(Get(v_1550, "root"), "style"), "transform", ((V)(JsStrBuf.Begin().S("matrix(").V(Invoke(Invoke(m_1551, "map", Fn((V _arrowThis1565, int _argc1558, V x_1564, V _a1561, V _a1562, V _a1563, V[] _rest1559) => {
return Invoke(x_1564, "toFixed", ((V)(4D)));
}, 1, "", true)), "join", ((V)(",")))).S(")").End())));
Set(Get(Get(v_1550, "st"), "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").V(Invoke(((V)(((ToNum(Get(sc_1512, "w")) - (320D * s_1552)) / 2D))), "toFixed", ((V)(2D)))).S("px,").V(Invoke(((V)(((ToNum(Get(sc_1512, "h")) - (180D * s_1552)) / 2D))), "toFixed", ((V)(2D)))).S("px) scale(").V(Invoke(((V)(s_1552)), "toFixed", ((V)(4D)))).S(")").End())));
} else {
V m0_1566 = default;
V LR_1567 = default;
double kk_1568 = 0;
V mm_1569 = default;
V W_1570 = default;
V Hh_1571 = default;
V sx_1572 = default;
V sy_1573 = default;
V Wt_1574 = default;
V Ht_1575 = default;
double tx_1576 = 0;
double ty_1577 = 0;
double s1_1578 = 0;
V lp_1579 = default;
m0_1566 = ((((ToNum(GetIdx(m_1551, 0D)) * ToNum(GetIdx(m_1551, 3D))) - (ToNum(GetIdx(m_1551, 1D)) * ToNum(GetIdx(m_1551, 2D)))) < 0D) ? Arr(((V)((-ToNum(GetIdx(m_1551, 0D))))), ((V)((-ToNum(GetIdx(m_1551, 1D))))), GetIdx(m_1551, 2D), GetIdx(m_1551, 3D), Add(GetIdx(m_1551, 4D), ((V)((ToNum(GetIdx(m_1551, 0D)) * ToNum(Get(sc_1512, "w")))))), Add(GetIdx(m_1551, 5D), ((V)((ToNum(GetIdx(m_1551, 1D)) * ToNum(Get(sc_1512, "w"))))))) : m_1551);
LR_1567 = Invoke(L_47, "getBoundingClientRect");
kk_1568 = (ToNum(Get(LR_1567, "width")) / ToNum(((Get(L_47, "offsetWidth") is var _t1580 && Truthy(_t1580) ? _t1580 : Get(LR_1567, "width")) is var _t1581 && Truthy(_t1581) ? _t1581 : ((V)(1D)))));
mm_1569 = Arr(((V)((ToNum(GetIdx(m0_1566, 0D)) * kk_1568))), ((V)((ToNum(GetIdx(m0_1566, 1D)) * kk_1568))), ((V)((ToNum(GetIdx(m0_1566, 2D)) * kk_1568))), ((V)((ToNum(GetIdx(m0_1566, 3D)) * kk_1568))), Add(Get(LR_1567, "left"), ((V)((ToNum(GetIdx(m0_1566, 4D)) * kk_1568)))), Add(Get(LR_1567, "top"), ((V)((ToNum(GetIdx(m0_1566, 5D)) * kk_1568)))));
W_1570 = (Get(G("window"), "innerWidth") is var _t1582 && Truthy(_t1582) ? _t1582 : ((V)(852D)));
Hh_1571 = (Get(G("window"), "innerHeight") is var _t1583 && Truthy(_t1583) ? _t1583 : ((V)(393D)));
sx_1572 = (((V)(Hypot(ToNum(GetIdx(mm_1569, 0D)), ToNum(GetIdx(mm_1569, 1D))))) is var _t1584 && Truthy(_t1584) ? _t1584 : ((V)(1D)));
sy_1573 = (((V)(Hypot(ToNum(GetIdx(mm_1569, 2D)), ToNum(GetIdx(mm_1569, 3D))))) is var _t1585 && Truthy(_t1585) ? _t1585 : ((V)(1D)));
Wt_1574 = ((V)(((ToNum(Hh_1571) * 16D) / 9D)));
Ht_1575 = Hh_1571;
if (Gt(Wt_1574, W_1570)) {
Wt_1574 = W_1570;
Ht_1575 = ((V)(((ToNum(W_1570) * 9D) / 16D)));
}
tx_1576 = ((ToNum(W_1570) - ToNum(Wt_1574)) / 2D);
ty_1577 = ((ToNum(Hh_1571) - ToNum(Ht_1575)) / 2D);
s1_1578 = Min((ToNum(Wt_1574) / 320D), (ToNum(Ht_1575) / 180D));
lp_1579 = Fn((V _arrowThis1594, int _argc1586, V a_1592, V b_1593, V _a1590, V _a1591, V[] _rest1587) => {
return Add(a_1592, ((V)(((ToNum(b_1593) - ToNum(a_1592)) * ToNum(fe_1554)))));
}, 2, "", true);
Set(FZ_52, "box", Arr(((V)(tx_1576)), ((V)(ty_1577)), Wt_1574, Ht_1575));
Set(Get(Get(v_1550, "root"), "style"), "width", ((V)(JsStrBuf.Begin().V(Invoke(Call(lp_1579, V.Undef, ((V)((ToNum(Get(sc_1512, "w")) * ToNum(sx_1572)))), Wt_1574), "toFixed", ((V)(2D)))).S("px").End())));
Set(Get(Get(v_1550, "root"), "style"), "height", ((V)(JsStrBuf.Begin().V(Invoke(Call(lp_1579, V.Undef, ((V)((ToNum(Get(sc_1512, "h")) * ToNum(sy_1573)))), Ht_1575), "toFixed", ((V)(2D)))).S("px").End())));
Set(Get(Get(v_1550, "root"), "style"), "transform", ((V)(JsStrBuf.Begin().S("matrix(").V(Invoke(Invoke(Arr(Call(lp_1579, V.Undef, ((V)((ToNum(GetIdx(mm_1569, 0D)) / ToNum(sx_1572)))), ((V)(1D))), Call(lp_1579, V.Undef, ((V)((ToNum(GetIdx(mm_1569, 1D)) / ToNum(sx_1572)))), ((V)(0D))), Call(lp_1579, V.Undef, ((V)((ToNum(GetIdx(mm_1569, 2D)) / ToNum(sy_1573)))), ((V)(0D))), Call(lp_1579, V.Undef, ((V)((ToNum(GetIdx(mm_1569, 3D)) / ToNum(sy_1573)))), ((V)(1D))), Call(lp_1579, V.Undef, GetIdx(mm_1569, 4D), ((V)(tx_1576))), Call(lp_1579, V.Undef, GetIdx(mm_1569, 5D), ((V)(ty_1577)))), "map", Fn((V _arrowThis1602, int _argc1595, V x_1601, V _a1598, V _a1599, V _a1600, V[] _rest1596) => {
return Invoke(x_1601, "toFixed", ((V)(4D)));
}, 1, "", true)), "join", ((V)(",")))).S(")").End())));
Set(Get(Get(v_1550, "st"), "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").V(Invoke(Call(lp_1579, V.Undef, ((V)((((ToNum(Get(sc_1512, "w")) - (320D * s_1552)) / 2D) * ToNum(sx_1572)))), ((V)(((ToNum(Wt_1574) - (320D * s1_1578)) / 2D)))), "toFixed", ((V)(2D)))).S("px,").V(Invoke(Call(lp_1579, V.Undef, ((V)((((ToNum(Get(sc_1512, "h")) - (180D * s_1552)) / 2D) * ToNum(sy_1573)))), ((V)(((ToNum(Ht_1575) - (180D * s1_1578)) / 2D)))), "toFixed", ((V)(2D)))).S("px) scale(").V(Invoke(Call(lp_1579, V.Undef, ((V)((s_1552 * ToNum(sx_1572)))), ((V)(s1_1578))), "toFixed", ((V)(4D)))).S(",").V(Invoke(Call(lp_1579, V.Undef, ((V)((s_1552 * ToNum(sy_1573)))), ((V)(s1_1578))), "toFixed", ((V)(4D)))).S(")").End())));
}
o_1555 = Invoke(v_1550, "upd", Get(SH_50, "mt"));
on_1556 = Call(cl_17, V.Undef, ((V)((((ToNum(Get(SH_50, "age")) - DIM_9) + 0.6) / 0.6))));
Set(Get(Get(v_1550, "root"), "style"), "opacity", Invoke(((V)((ToNum(on_1556) * fin_1553))), "toFixed", ((V)(3D))));
Set(Get(Get(v_1550, "root"), "style"), "boxShadow", ((V)((GtN(fe_1554, 0D) ? JsStrBuf.Begin().S("0 0 ").V(Invoke(((V)((50D * ToNum(fe_1554)))), "toFixed", ((V)(1D)))).S("px ").V(Invoke(((V)((8D * ToNum(fe_1554)))), "toFixed", ((V)(1D)))).S("px rgba(").V(Get(o_1555, "rgb")).S(",").V(Invoke(((V)((((0.4 * ToNum(Get(o_1555, "lit"))) * ToNum(on_1556)) * Min(1D, ToNum(fe_1554))))), "toFixed", ((V)(2D)))).S(")").End() : JsStrBuf.Begin().S("0 0 ").V(Invoke(((V)((8D / Max(0.3, System.Math.Abs(ToNum(GetIdx(m_1551, 0D))))))), "toFixed", ((V)(1D)))).S("px 2px rgba(").V(Get(o_1555, "rgb")).S(",").V(Invoke(((V)(((0.7 * ToNum(Get(o_1555, "lit"))) * ToNum(on_1556)))), "toFixed", ((V)(2D)))).S(")").End()))));
{
V fbOn_1603 = default;
V b_1604 = default;
V bo_1605 = default;
fbOn_1603 = (false ? V.True : V.False);
b_1604 = Get(N_1511, "fb");
if (Truthy(fbOn_1603)) {
V a_1606 = default;
V d1_1607 = default;
V d2_1608 = default;
V l1_1609 = default;
V l2_1610 = default;
double i1_1611 = 0;
double i2_1612 = 0;
a_1606 = GetIdx(q_1513, 1D);
d1_1607 = Arr(((V)((ToNum(GetIdx(GetIdx(q_1513, 0D), 0D)) - ToNum(GetIdx(a_1606, 0D))))), ((V)((ToNum(GetIdx(GetIdx(q_1513, 0D), 1D)) - ToNum(GetIdx(a_1606, 1D))))));
d2_1608 = Arr(((V)((ToNum(GetIdx(GetIdx(q_1513, 2D), 0D)) - ToNum(GetIdx(a_1606, 0D))))), ((V)((ToNum(GetIdx(GetIdx(q_1513, 2D), 1D)) - ToNum(GetIdx(a_1606, 1D))))));
l1_1609 = (((V)(Hypot(ToNum(GetIdx(d1_1607, 0D)), ToNum(GetIdx(d1_1607, 1D))))) is var _t1613 && Truthy(_t1613) ? _t1613 : ((V)(1D)));
l2_1610 = (((V)(Hypot(ToNum(GetIdx(d2_1608, 0D)), ToNum(GetIdx(d2_1608, 1D))))) is var _t1614 && Truthy(_t1614) ? _t1614 : ((V)(1D)));
i1_1611 = (Min(24D, (ToNum(l1_1609) * 0.2)) / ToNum(l1_1609));
i2_1612 = (Min(24D, (ToNum(l2_1610) * 0.25)) / ToNum(l2_1610));
Set(Get(b_1604, "style"), "left", ((V)(JsStrBuf.Begin().V(Invoke(((V)((ToNum(Add(Add(GetIdx(a_1606, 0D), ((V)((ToNum(GetIdx(d1_1607, 0D)) * i1_1611)))), ((V)((ToNum(GetIdx(d2_1608, 0D)) * i2_1612))))) - 17D))), "toFixed", ((V)(1D)))).S("px").End())));
Set(Get(b_1604, "style"), "top", ((V)(JsStrBuf.Begin().V(Invoke(((V)((ToNum(Add(Add(GetIdx(a_1606, 1D), ((V)((ToNum(GetIdx(d1_1607, 1D)) * i1_1611)))), ((V)((ToNum(GetIdx(d2_1608, 1D)) * i2_1612))))) - 17D))), "toFixed", ((V)(1D)))).S("px").End())));
}
bo_1605 = ((V)((Truthy(fbOn_1603) ? "1" : "0")));
if (!SEq(Get(Get(b_1604, "style"), "opacity"), bo_1605)) {
Set(Get(b_1604, "style"), "opacity", bo_1605);
Set(Get(b_1604, "style"), "transform", ((V)((Truthy(fbOn_1603) ? "scale(1)" : "scale(0.6)"))));
Set(Get(b_1604, "style"), "pointerEvents", ((V)((Truthy(fbOn_1603) ? "auto" : "none"))));
}
}
R_1557 = (Max(System.Math.Abs((ToNum(GetIdx(GetIdx(q_1513, 1D), 0D)) - ToNum(GetIdx(GetIdx(q_1513, 0D), 0D)))), 80D) * 1.4);
Set(Get(Get(N_1511, "dim"), "style"), "opacity", Invoke(dOp_1549, "toFixed", ((V)(3D))));
Set(Get(Get(N_1511, "dim"), "style"), "background", ((V)(JsStrBuf.Begin().S("radial-gradient(circle at ").V(Invoke(Add(GetIdx(cen_1514, 0D), ((V)(60D))), "toFixed", ((V)(0D)))).S("px ").V(Invoke(Add(GetIdx(cen_1514, 1D), ((V)(60D))), "toFixed", ((V)(0D)))).S("px, rgba(").V(Get(o_1555, "rgb")).S(",").V(Invoke(((V)(((0.3 * ToNum(Get(o_1555, "lit"))) * ToNum(on_1556)))), "toFixed", ((V)(2D)))).S(") 0, rgba(").V(Get(o_1555, "rgb")).S(",0) ").V(Invoke(((V)(R_1557)), "toFixed", ((V)(0D)))).S("px), radial-gradient(ellipse at ").V(Invoke(Add(GetIdx(cen_1514, 0D), ((V)(60D))), "toFixed", ((V)(0D)))).S("px ").V(Invoke(Add(GetIdx(cen_1514, 1D), ((V)(60D))), "toFixed", ((V)(0D)))).S("px, rgba(8,5,18,0.5), rgba(8,5,18,0.88) 70%)").End())));
if (Truthy(pl_1515)) {
Invoke(Get(N_1511, "beam"), "setAttribute", ((V)("points")), Invoke(Invoke(Call(hull_67, V.Undef, Invoke(Arr(pl_1515), "concat", q_1513)), "map", Fn((V _arrowThis1622, int _argc1615, V p_1621, V _a1618, V _a1619, V _a1620, V[] _rest1616) => {
return ((V)(JsStrBuf.Begin().V(Invoke(GetIdx(p_1621, 0D), "toFixed", ((V)(1D)))).S(",").V(Invoke(GetIdx(p_1621, 1D), "toFixed", ((V)(1D)))).End()));
}, 1, "", true)), "join", ((V)(" "))));
Invoke(Get(N_1511, "grad"), "setAttribute", ((V)("x1")), GetIdx(pl_1515, 0D));
Invoke(Get(N_1511, "grad"), "setAttribute", ((V)("y1")), GetIdx(pl_1515, 1D));
Invoke(Get(N_1511, "grad"), "setAttribute", ((V)("x2")), GetIdx(cen_1514, 0D));
Invoke(Get(N_1511, "grad"), "setAttribute", ((V)("y2")), GetIdx(cen_1514, 1D));
Invoke(Get(N_1511, "beam"), "setAttribute", ((V)("opacity")), Invoke(((V)((((0.32 * ToNum(on_1556)) * Min(1D, ToNum(Add(Get(o_1555, "lit"), ((V)(0.2)))))) * (Truthy(Get(SH_50, "done")) ? (1D - ToNum(Call(cl_17, V.Undef, ((V)((ToNum(Get(SH_50, "endA")) / 0.6)))))) : 1D)))), "toFixed", ((V)(3D))));
} else {
Invoke(Get(N_1511, "beam"), "setAttribute", ((V)("opacity")), ((V)("0")));
}
}
}
if (Truthy(((Get(K_39, "size") is var _t1623 && Truthy(_t1623) ? _t1623 : SH_50) is var _t1625 && Truthy(_t1625) ? _t1625 : (TH_46 is var _t1624 && !Truthy(_t1624) ? _t1624 : Get(TH_46, "synced"))))) {
Call(loop_98, V.Undef);
}
return default;
}, 0, "frame", false);
emit_103 = Fn((V _self1626, int _argc1627, V _a1629, V _a1630, V _a1631, V _a1632, V[] _rest1628) => {
if (_self1626.IsNullish) _self1626 = GlobalV;
Invoke(subs_102, "forEach", Fn((V _arrowThis1640, int _argc1633, V f_1639, V _a1636, V _a1637, V _a1638, V[] _rest1634) => {
try {
Call(f_1639, V.Undef);
} catch (System.Exception _ex1641) {
V e_1642 = default;
e_1642 = Caught(_ex1641);

}
return default;
}, 1, "", true));
return default;
}, 0, "emit", false);
if (Truthy(Get(G("window"), "MovieNight"))) {
return default;
}
BEAT_8 = 0.5;
DIM_9 = 1.2;
AD_10 = 10D;
UP_11 = 1.2;
STEP_12 = (BEAT_8 / 4D);
INK_13 = ((V)("#3a1a5c"));
NOTE_14 = Arr(((V)("\u266a")), ((V)("\u266b")), ((V)("\u266c")));
NC_15 = Arr(((V)("#ffd66b")), ((V)("#8fe8ff")), ((V)("#a6f06a")), ((V)("#ffb36b")), ((V)("#c9a6ff")));
csrc_16 = Fn((V _arrowThis1650, int _argc1643, V k_1649, V _a1646, V _a1647, V _a1648, V[] _rest1644) => {
return ((V)(JsStrBuf.Begin().S("export/tripo/").V(k_1649).S("/").V(k_1649).S("-front.svg").End()));
}, 1, "", true);
cl_17 = Fn((V _arrowThis1662, int _argc1651, V v_1657, V _a1654, V _a1655, V _a1656, V[] _rest1652) => {
V a_1659 = default;
V b_1661 = default;
{ V _t1658 = _a1654; if (_t1658.IsUndef) _t1658 = ((V)(0D));
a_1659 = _t1658; }
{ V _t1660 = _a1655; if (_t1660.IsUndef) _t1660 = ((V)(1D));
b_1661 = _t1660; }
return ((V)(Max(ToNum(a_1659), Min(ToNum(b_1661), ToNum(v_1657)))));
}, 3, "", true);
E_18 = NewObj(2).Put("out", Fn((V _arrowThis1670, int _argc1663, V x_1669, V _a1666, V _a1667, V _a1668, V[] _rest1664) => {
return ((V)((1D - Pow((1D - ToNum(x_1669)), 3D))));
}, 1, "out", true)).Put("back", Fn((V _arrowThis1678, int _argc1671, V x_1677, V _a1674, V _a1675, V _a1676, V[] _rest1672) => {
double c1_1679 = 0;
double c3_1680 = 0;
c1_1679 = 1.70158;
c3_1680 = (c1_1679 + 1D);
return ((V)(((1D + (c3_1680 * Pow((ToNum(x_1677) - 1D), 3D))) + (c1_1679 * Pow((ToNum(x_1677) - 1D), 2D)))));
return default;
}, 1, "back", true)).V;
P_19 = Fn((V _arrowThis1692, int _argc1681, V t_1687, V a_1688, V b_1689, V _a1686, V[] _rest1682) => {
V e_1691 = default;
{ V _t1690 = _a1686; if (_t1690.IsUndef) _t1690 = Get(E_18, "out");
e_1691 = _t1690; }
return Call(e_1691, V.Undef, Call(cl_17, V.Undef, ((V)(((ToNum(t_1687) - ToNum(a_1688)) / (ToNum(b_1689) - ToNum(a_1688)))))));
}, 4, "", true);
A_20 = NewObj(3).Put("ctx", V.Null).Put("out", V.Null).Put("nb", V.Null).V;
CUR_21 = V.Null;
Invoke(Arr(((V)("pointerdown")), ((V)("keydown")), ((V)("touchstart"))), "forEach", Fn((V _arrowThis1700, int _argc1693, V ev_1699, V _a1696, V _a1697, V _a1698, V[] _rest1694) => {
return Invoke(G("window"), "addEventListener", ev_1699, Fn((V _arrowThis1707, int _argc1701, V _a1703, V _a1704, V _a1705, V _a1706, V[] _rest1702) => {
return Call(ac_22, V.Undef);
}, 0, "", true), NewObj(2).Put("capture", (true ? V.True : V.False)).Put("passive", (true ? V.True : V.False)).V);
}, 1, "", true));
mtof_23 = Fn((V _arrowThis1715, int _argc1708, V m_1714, V _a1711, V _a1712, V _a1713, V[] _rest1709) => {
return ((V)((440D * Pow(2D, ((ToNum(m_1714) - 69D) / 12D)))));
}, 1, "", true);
kick_27 = Fn((V _arrowThis1725, int _argc1716, V t_1722, V _a1719, V _a1720, V _a1721, V[] _rest1717) => {
V v_1724 = default;
{ V _t1723 = _a1719; if (_t1723.IsUndef) _t1723 = ((V)(0.9));
v_1724 = _t1723; }
return Call(tone_25, V.Undef, t_1722, ((V)(150D)), ((V)(0.32)), NewObj(4).Put("to", ((V)(42D))).Put("slide", ((V)(0.12))).Put("vol", v_1724).Put("at", ((V)(0.002))).V);
}, 2, "", true);
snare_28 = Fn((V _arrowThis1735, int _argc1726, V t_1732, V _a1729, V _a1730, V _a1731, V[] _rest1727) => {
V v_1734 = default;
{ V _t1733 = _a1729; if (_t1733.IsUndef) _t1733 = ((V)(0.32));
v_1734 = _t1733; }
Call(noise_26, V.Undef, t_1732, ((V)(0.16)), NewObj(4).Put("ft", ((V)("bandpass"))).Put("f", ((V)(1800D))).Put("q", ((V)(0.8))).Put("vol", v_1734).V);
Call(tone_25, V.Undef, t_1732, ((V)(220D)), ((V)(0.08)), NewObj(3).Put("to", ((V)(160D))).Put("vol", ((V)((ToNum(v_1734) * 0.5)))).Put("type", ((V)("triangle"))).V);
return default;
}, 2, "", true);
hat_29 = Fn((V _arrowThis1745, int _argc1736, V t_1742, V _a1739, V _a1740, V _a1741, V[] _rest1737) => {
V v_1744 = default;
{ V _t1743 = _a1739; if (_t1743.IsUndef) _t1743 = ((V)(0.07));
v_1744 = _t1743; }
return Call(noise_26, V.Undef, t_1742, ((V)(0.04)), NewObj(2).Put("f", ((V)(7500D))).Put("vol", v_1744).V);
}, 2, "", true);
bass_30 = Fn((V _arrowThis1756, int _argc1746, V t_1752, V m_1753, V _a1750, V _a1751, V[] _rest1747) => {
V v_1755 = default;
{ V _t1754 = _a1750; if (_t1754.IsUndef) _t1754 = ((V)(0.26));
v_1755 = _t1754; }
return Call(tone_25, V.Undef, t_1752, Call(mtof_23, V.Undef, m_1753), ((V)(0.2)), NewObj(4).Put("type", ((V)("sawtooth"))).Put("lp", ((V)(520D))).Put("vol", v_1755).Put("at", ((V)(0.008))).V);
}, 3, "", true);
lead_31 = Fn((V _arrowThis1769, int _argc1757, V t_1763, V m_1764, V _a1761, V _a1762, V[] _rest1758) => {
V d_1766 = default;
V v_1768 = default;
{ V _t1765 = _a1761; if (_t1765.IsUndef) _t1765 = ((V)(0.18));
d_1766 = _t1765; }
{ V _t1767 = _a1762; if (_t1767.IsUndef) _t1767 = ((V)(0.1));
v_1768 = _t1767; }
Call(tone_25, V.Undef, t_1763, Call(mtof_23, V.Undef, m_1764), d_1766, NewObj(4).Put("type", ((V)("square"))).Put("lp", ((V)(2600D))).Put("vol", v_1768).Put("at", ((V)(0.006))).V);
Call(tone_25, V.Undef, t_1763, Call(mtof_23, V.Undef, Add(m_1764, ((V)(12D)))), ((V)((ToNum(d_1766) * 0.7))), NewObj(2).Put("type", ((V)("triangle"))).Put("vol", ((V)((ToNum(v_1768) * 0.4)))).V);
return default;
}, 4, "", true);
bell_32 = Fn((V _arrowThis1782, int _argc1770, V t_1776, V m_1777, V _a1774, V _a1775, V[] _rest1771) => {
V d_1779 = default;
V v_1781 = default;
{ V _t1778 = _a1774; if (_t1778.IsUndef) _t1778 = ((V)(0.5));
d_1779 = _t1778; }
{ V _t1780 = _a1775; if (_t1780.IsUndef) _t1780 = ((V)(0.12));
v_1781 = _t1780; }
Call(tone_25, V.Undef, t_1776, Call(mtof_23, V.Undef, m_1777), d_1779, NewObj(1).Put("vol", v_1781).V);
Call(tone_25, V.Undef, t_1776, ((V)((ToNum(Call(mtof_23, V.Undef, m_1777)) * 2.76))), ((V)((ToNum(d_1779) * 0.4))), NewObj(1).Put("vol", ((V)((ToNum(v_1781) * 0.25)))).V);
return default;
}, 4, "", true);
chord_33 = Fn((V _arrowThis1794, int _argc1783, V t_1789, V ms_1790, V d_1791, V _a1788, V[] _rest1784) => {
V v_1793 = default;
{ V _t1792 = _a1788; if (_t1792.IsUndef) _t1792 = ((V)(0.06));
v_1793 = _t1792; }
return Invoke(ms_1790, "forEach", Fn((V _arrowThis1802, int _argc1795, V m_1801, V _a1798, V _a1799, V _a1800, V[] _rest1796) => {
return Call(tone_25, V.Undef, t_1789, Call(mtof_23, V.Undef, m_1801), d_1791, NewObj(4).Put("type", ((V)("sawtooth"))).Put("lp", ((V)(1800D))).Put("vol", v_1793).Put("at", ((V)(0.01))).V);
}, 1, "", true));
}, 4, "", true);
crash_34 = Fn((V _arrowThis1812, int _argc1803, V t_1809, V _a1806, V _a1807, V _a1808, V[] _rest1804) => {
V v_1811 = default;
{ V _t1810 = _a1806; if (_t1810.IsUndef) _t1810 = ((V)(0.18));
v_1811 = _t1810; }
return Call(noise_26, V.Undef, t_1809, ((V)(1.3)), NewObj(2).Put("f", ((V)(5000D))).Put("vol", v_1811).V);
}, 2, "", true);
squishS_35 = Fn((V _arrowThis1821, int _argc1813, V t_1819, V k_1820, V _a1817, V _a1818, V[] _rest1814) => {
Call(tone_25, V.Undef, t_1819, ((V)((280D - (ToNum(k_1820) * 10D)))), ((V)(0.2)), NewObj(3).Put("to", ((V)(90D))).Put("slide", ((V)(0.15))).Put("vol", ((V)(0.5))).V);
Call(tone_25, V.Undef, Add(t_1819, ((V)(0.04))), ((V)((520D + (ToNum(k_1820) * 80D)))), ((V)(0.1)), NewObj(3).Put("to", ((V)((1100D + (ToNum(k_1820) * 120D))))).Put("slide", ((V)(0.07))).Put("vol", ((V)(0.18))).V);
return default;
}, 2, "", true);
PROG_36 = Arr(Arr(((V)(36D)), Arr(((V)(60D)), ((V)(64D)), ((V)(67D)))), Arr(((V)(33D)), Arr(((V)(57D)), ((V)(60D)), ((V)(64D)))), Arr(((V)(29D)), Arr(((V)(53D)), ((V)(57D)), ((V)(60D)))), Arr(((V)(31D)), Arr(((V)(55D)), ((V)(59D)), ((V)(62D)))));
MEL_37 = Arr(((V)(76D)), ((V)(0D)), ((V)(79D)), ((V)(0D)), ((V)(81D)), ((V)(79D)), ((V)(76D)), ((V)(0D)), ((V)(74D)), ((V)(0D)), ((V)(76D)), ((V)(72D)), ((V)(0D)), ((V)(74D)), ((V)(76D)), ((V)(0D)));
K_39 = New(G("Map"));
J_40 = NewObj(6).Put("on", (false ? V.True : V.False)).Put("timer", ((V)(0D))).Put("t0", ((V)(0D))).Put("step", ((V)(0D))).Put("p0", ((V)(0D))).Put("bus", V.Null).V;
TH_46 = V.Null;
L_47 = V.Null;
RM_48 = V.Null;
prevReady_49 = (false ? V.True : V.False);
SH_50 = V.Null;
ART_51 = V.Null;
FZ_52 = NewObj(6).Put("on", (false ? V.True : V.False)).Put("p", ((V)(0D))).Put("last", ((V)(0D))).Put("ctl", ((V)(0D))).Put("gd", ((V)(0D))).Put("box", V.Null).V;
FZD_53 = 0.75;
noProp_54 = Fn((V _arrowThis1829, int _argc1822, V n_1828, V _a1825, V _a1826, V _a1827, V[] _rest1823) => {
return Invoke(Arr(((V)("pointerdown")), ((V)("pointerup")), ((V)("click")), ((V)("mousedown")), ((V)("touchstart")), ((V)("wheel")), ((V)("contextmenu"))), "forEach", Fn((V _arrowThis1837, int _argc1830, V ev_1836, V _a1833, V _a1834, V _a1835, V[] _rest1831) => {
return Invoke(n_1828, "addEventListener", ev_1836, Fn((V _arrowThis1845, int _argc1838, V e_1844, V _a1841, V _a1842, V _a1843, V[] _rest1839) => {
return Invoke(e_1844, "stopPropagation");
}, 1, "", true));
}, 1, "", true));
}, 1, "", true);
Invoke(Arr(((V)("fullscreenchange")), ((V)("webkitfullscreenchange"))), "forEach", Fn((V _arrowThis1853, int _argc1846, V ev_1852, V _a1849, V _a1850, V _a1851, V[] _rest1847) => {
return Invoke(G("document"), "addEventListener", ev_1852, Fn((V _arrowThis1860, int _argc1854, V _a1856, V _a1857, V _a1858, V _a1859, V[] _rest1855) => {
if (Truthy((((!(Truthy((Get(G("document"), "fullscreenElement") is var _t1861 && Truthy(_t1861) ? _t1861 : Get(G("document"), "webkitFullscreenElement")))) ? V.True : V.False) is var _t1862 && !Truthy(_t1862) ? _t1862 : Get(FZ_52, "on")) is var _t1863 && !Truthy(_t1863) ? _t1863 : (((ToNum(Invoke(G("performance"), "now")) - ToNum(Get(FZ_52, "last"))) > 400D) ? V.True : V.False)))) {
Call(focus_58, V.Undef, (false ? V.True : V.False));
}
return default;
}, 0, "", true));
}, 1, "", true));
bk_62 = Fn((V _arrowThis1871, int _argc1864, V x_1870, V _a1867, V _a1868, V _a1869, V[] _rest1865) => {
return ((V)(((1D + (2D * Pow((ToNum(x_1870) - 1D), 3D))) + Pow((ToNum(x_1870) - 1D), 2D))));
}, 1, "", true);
ML_68 = Fn((V _arrowThis1878, int _argc1872, V _a1874, V _a1875, V _a1876, V _a1877, V[] _rest1873) => {
return ((Get(G("window"), "SquadMovies") is var _t1879 && !Truthy(_t1879) ? _t1879 : Get(Get(G("window"), "SquadMovies"), "list")) is var _t1880 && Truthy(_t1880) ? _t1880 : Arr());
}, 0, "", true);
AdMv_69 = NewObj(5).Put("id", ((V)("ad"))).Put("tier", ((V)(0D))).Put("title", ((V)("Squish Squad trailer"))).Put("dur", ((V)(AD_10))).Put("ad", (true ? V.True : V.False)).V;
lsG_70 = Fn((V _arrowThis1888, int _argc1881, V k_1887, V _a1884, V _a1885, V _a1886, V[] _rest1882) => {
try {
return Invoke(G("localStorage"), "getItem", k_1887);
} catch (System.Exception _ex1889) {
V e_1890 = default;
e_1890 = Caught(_ex1889);
return V.Null;
}
return default;
}, 1, "", true);
lsS_71 = Fn((V _arrowThis1899, int _argc1891, V k_1897, V v_1898, V _a1895, V _a1896, V[] _rest1892) => {
try {
if (v_1898.IsNullish) {
Invoke(G("localStorage"), "removeItem", k_1897);
} else {
Invoke(G("localStorage"), "setItem", k_1897, ((V)(ToStrS(v_1898))));
}
} catch (System.Exception _ex1900) {
V e_1901 = default;
e_1901 = Caught(_ex1900);

}
return default;
}, 2, "", true);
fmt_72 = Fn((V _arrowThis1909, int _argc1902, V s_1908, V _a1905, V _a1906, V _a1907, V[] _rest1903) => {
return ((V)(JsStrBuf.Begin().N(System.Math.Floor((ToNum(s_1908) / 60D))).S(":").V(Invoke(((V)(ToStrS(((V)(System.Math.Floor((ToNum(s_1908) % 60D))))))), "padStart", ((V)(2D)), ((V)("0")))).End()));
}, 1, "", true);
REACT_73 = V.Null;
CAST_74 = Arr();
ICON_89 = NewObj(6).Put("pause", ((V)("<svg viewBox=\"0 0 16 16\" width=\"14\" height=\"14\"><rect x=\"3\" y=\"2\" width=\"3.6\" height=\"12\" rx=\"1.2\" fill=\"currentColor\"></rect><rect x=\"9.4\" y=\"2\" width=\"3.6\" height=\"12\" rx=\"1.2\" fill=\"currentColor\"></rect></svg>"))).Put("play", ((V)("<svg viewBox=\"0 0 16 16\" width=\"14\" height=\"14\"><path d=\"M4.5 2.5 L13.5 8 L4.5 13.5Z\" fill=\"currentColor\" stroke=\"currentColor\" stroke-width=\"1.4\" stroke-linejoin=\"round\"></path></svg>"))).Put("list", ((V)("<svg viewBox=\"0 0 16 16\" width=\"15\" height=\"15\"><path d=\"M3 4h10M3 8h10M3 12h10\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\"></path></svg>"))).Put("skip", ((V)("<svg viewBox=\"0 0 16 16\" width=\"14\" height=\"14\"><path d=\"M2.5 3 L8 8 L2.5 13Z M7.5 3 L13 8 L7.5 13Z\" fill=\"currentColor\" stroke=\"currentColor\" stroke-width=\"1\" stroke-linejoin=\"round\"></path><rect x=\"12.6\" y=\"3\" width=\"2\" height=\"10\" rx=\"0.8\" fill=\"currentColor\"></rect></svg>"))).Put("full", ((V)("<svg viewBox=\"0 0 16 16\" width=\"15\" height=\"15\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2.1\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><path d=\"M2.5 6.2V2.5h3.7M9.8 2.5h3.7v3.7M13.5 9.8v3.7H9.8M6.2 13.5H2.5V9.8\"></path></svg>"))).Put("shrink", ((V)("<svg viewBox=\"0 0 16 16\" width=\"15\" height=\"15\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2.1\" stroke-linecap=\"round\" stroke-linejoin=\"round\"><path d=\"M6 2.5V6H2.5M13.5 6H10V2.5M10 13.5V10h3.5M2.5 10H6v3.5\"></path></svg>"))).V;
OUT_94 = Fn((V _arrowThis1918, int _argc1910, V c_1916, V w_1917, V _a1914, V _a1915, V[] _rest1911) => {
return ((V)(JsStrBuf.Begin().V(Invoke(Invoke(Arr(Arr(w_1917, ((V)(0D))), Arr(((V)((-ToNum(w_1917)))), ((V)(0D))), Arr(((V)(0D)), w_1917), Arr(((V)(0D)), ((V)((-ToNum(w_1917))))), Arr(((V)((ToNum(w_1917) * 0.7))), ((V)((ToNum(w_1917) * 0.7)))), Arr(((V)(((-ToNum(w_1917)) * 0.7))), ((V)((ToNum(w_1917) * 0.7)))), Arr(((V)((ToNum(w_1917) * 0.7))), ((V)(((-ToNum(w_1917)) * 0.7)))), Arr(((V)(((-ToNum(w_1917)) * 0.7))), ((V)(((-ToNum(w_1917)) * 0.7))))), "map", Fn((V _arrowThis1930, int _argc1919, V _a1921, V _a1922, V _a1923, V _a1924, V[] _rest1920) => {
V x_1927 = default;
V y_1929 = default;
{ V _t1925 = ListOf(_a1921);
{ V _t1926 = GetIdx(_t1925, 0D);
x_1927 = _t1926; }
{ V _t1928 = GetIdx(_t1925, 1D);
y_1929 = _t1928; }
}
return ((V)(JsStrBuf.Begin().V(x_1927).S("px ").V(y_1929).S("px 0 ").V(c_1916).End()));
}, 1, "", true)), "join", ((V)(",")))).S(",0 ").V(Add(w_1917, ((V)(1.5)))).S("px 0 ").V(c_1916).End()));
}, 2, "", true);
RAF_96 = ((V)(0D));
TO_97 = ((V)(0D));
subs_102 = New(G("Set"));
Set(G("window"), "MovieNight", NewObj(19).Put("jamMute", Fn((V _arrowThis1938, int _argc1931, V v_1937, V _a1934, V _a1935, V _a1936, V[] _rest1932) => {
Set(J_40, "mute", (!(!(Truthy(v_1937))) ? V.True : V.False));
if (Truthy((Get(J_40, "bus") is var _t1939 && !Truthy(_t1939) ? _t1939 : Get(A_20, "ctx")))) {
Invoke(Get(Get(J_40, "bus"), "gain"), "setTargetAtTime", ((V)((Truthy(v_1937) ? 0.0001 : 1D))), Get(Get(A_20, "ctx"), "currentTime"), ((V)(0.05)));
}
return default;
}, 1, "jamMute", true)).Put("toggle", toggle_44).Put("stop", stop_45).Put("isOn", Fn((V _arrowThis1947, int _argc1940, V k_1946, V _a1943, V _a1944, V _a1945, V[] _rest1941) => {
return Invoke(K_39, "has", k_1946);
}, 1, "isOn", true)).Put("theater", theater_64).Put("play", Fn((V _arrowThis1955, int _argc1948, V id_1954, V _a1951, V _a1952, V _a1953, V[] _rest1949) => {
return Call(play_82, V.Undef, id_1954);
}, 1, "play", true)).Put("stopShow", stopShow_88).Put("showing", Fn((V _arrowThis1962, int _argc1956, V _a1958, V _a1959, V _a1960, V _a1961, V[] _rest1957) => {
return (!(!(Truthy(SH_50))) ? V.True : V.False);
}, 0, "showing", true)).Put("paused", Fn((V _arrowThis1969, int _argc1963, V _a1965, V _a1966, V _a1967, V _a1968, V[] _rest1964) => {
return (!(!(Truthy((SH_50 is var _t1970 && !Truthy(_t1970) ? _t1970 : Get(SH_50, "pause"))))) ? V.True : V.False);
}, 0, "paused", true)).Put("pause", Fn((V _arrowThis1977, int _argc1971, V _a1973, V _a1974, V _a1975, V _a1976, V[] _rest1972) => {
return Call(setPause_83, V.Undef, (true ? V.True : V.False));
}, 0, "pause", true)).Put("resume", Fn((V _arrowThis1984, int _argc1978, V _a1980, V _a1981, V _a1982, V _a1983, V[] _rest1979) => {
return Call(setPause_83, V.Undef, (false ? V.True : V.False));
}, 0, "resume", true)).Put("togglePause", Fn((V _arrowThis1991, int _argc1985, V _a1987, V _a1988, V _a1989, V _a1990, V[] _rest1986) => {
if (Truthy(SH_50)) {
Call(setPause_83, V.Undef, (!(Truthy(Get(SH_50, "pause"))) ? V.True : V.False));
}
return default;
}, 0, "togglePause", true)).Put("focus", Fn((V _arrowThis1999, int _argc1992, V v_1998, V _a1995, V _a1996, V _a1997, V[] _rest1993) => {
return Call(focus_58, V.Undef, (SEq(v_1998, V.Undef) ? (!(Truthy(Get(FZ_52, "on"))) ? V.True : V.False) : v_1998));
}, 1, "focus", true)).Put("focused", Fn((V _arrowThis2006, int _argc2000, V _a2002, V _a2003, V _a2004, V _a2005, V[] _rest2001) => {
return Get(FZ_52, "on");
}, 0, "focused", true)).Put("onReact", Fn((V _arrowThis2014, int _argc2007, V f_2013, V _a2010, V _a2011, V _a2012, V[] _rest2008) => {
REACT_73 = f_2013;
return default;
}, 1, "onReact", true)).Put("cast", Fn((V _arrowThis2022, int _argc2015, V v_2021, V _a2018, V _a2019, V _a2020, V[] _rest2016) => {
if (!SEq(v_2021, V.Undef)) {
CAST_74 = ((v_2021.O is JsArray) ? v_2021 : Arr());
}
return CAST_74;
return default;
}, 1, "cast", true)).Put("now", Fn((V _arrowThis2029, int _argc2023, V _a2025, V _a2026, V _a2027, V _a2028, V[] _rest2024) => {
return (SH_50 is var _t2030 && !Truthy(_t2030) ? _t2030 : NewObj(5).Put("id", Get(Get(SH_50, "mv"), "id")).Put("title", Get(Get(SH_50, "mv"), "title")).Put("t", Get(SH_50, "mt")).Put("dur", Get(Get(SH_50, "mv"), "dur")).Put("paused", Get(SH_50, "pause")).V);
}, 0, "now", true)).Put("_seek", Fn((V _arrowThis2038, int _argc2031, V s_2037, V _a2034, V _a2035, V _a2036, V[] _rest2032) => {
if (Truthy(SH_50)) {
Set(SH_50, "mt", s_2037);
Set(SH_50, "age", ((V)(Max(ToNum(Get(SH_50, "age")), (DIM_9 + 1D)))));
if (Truthy((Get(A_20, "ctx") is var _t2039 && !Truthy(_t2039) ? _t2039 : Get(SH_50, "bus")))) {
Set(SH_50, "a0", ((V)((ToNum(Get(Get(A_20, "ctx"), "currentTime")) - ToNum(s_2037)))));
Set(SH_50, "ei", Call(idxOf_80, V.Undef, Get(SH_50, "mv"), s_2037));
}
Call(frame_101, V.Undef);
}
return default;
}, 1, "_seek", true)).Put("sub", Fn((V _arrowThis2047, int _argc2040, V f_2046, V _a2043, V _a2044, V _a2045, V[] _rest2041) => {
Invoke(subs_102, "add", f_2046);
return Fn((V _arrowThis2054, int _argc2048, V _a2050, V _a2051, V _a2052, V _a2053, V[] _rest2049) => {
return Invoke(subs_102, "delete", f_2046);
}, 0, "", true);
return default;
}, 1, "sub", true)).V);
Invoke(G("document"), "addEventListener", ((V)("keydown")), Fn((V _arrowThis2062, int _argc2055, V e_2061, V _a2058, V _a2059, V _a2060, V[] _rest2056) => {
if (Truthy(((SEqS(Get(e_2061, "key"), "Escape") ? V.True : V.False) is var _t2063 && !Truthy(_t2063) ? _t2063 : Get(FZ_52, "on")))) {
Call(focus_58, V.Undef, (false ? V.True : V.False));
}
return default;
}, 1, "", true));
return default;
}, 0, "", false), V.Undef);
        }
    }
}
