// tv-sound.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_tv_sound_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V AC_8 = default;
V M_9 = default;
V NB_10 = default;
V P_11 = default;
V ctx_12 = default;
V mid_13 = default;
V tone_14 = default;
V thump_15 = default;
V noiseBuf_16 = default;
V clap_17 = default;
V SONG_18 = default;
V step_19 = default;
V play_20 = default;
V stop_21 = default;
if (_self1.IsNullish) _self1 = GlobalV;
step_19 = Fn((V _self22, int _argc23, V o_29, V _a26, V _a27, V _a28, V[] _rest24) => {
V t_30 = default;
V i_31 = default;
if (_self22.IsNullish) _self22 = GlobalV;
t_30 = Get(o_29, "next");
i_31 = Get(o_29, "i");
if (SEqN(Get(o_29, "ch"), 2D)) {
double k_32 = 0;
k_32 = (ToNum(i_31) % 64D);
if ((((k_32 % 8D) == 0D) || ((k_32 % 8D) == 3D))) {
Call(thump_15, V.Undef, Get(o_29, "out"), t_30, ((V)(0.5)));
}
if (((k_32 % 8D) == 6D)) {
Call(clap_17, V.Undef, Get(o_29, "out"), t_30, ((V)(0.35)));
}
if (((k_32 == 2D) || (k_32 == 48D))) {
Invoke(Arr(((V)(0D)), ((V)(0.09)), ((V)(0.18))), "forEach", Fn((V _arrowThis40, int _argc33, V d_39, V _a36, V _a37, V _a38, V[] _rest34) => {
return Call(tone_14, V.Undef, Get(o_29, "out"), Add(t_30, d_39), ((V)(2900D)), ((V)(0.07)), ((V)("sine")), ((V)(0.12)));
}, 1, "", true));
}
if ((k_32 == 40D)) {
V g_41 = default;
g_41 = Get(Get(o_29, "cg"), "gain");
Invoke(g_41, "cancelScheduledValues", t_30);
Invoke(g_41, "setValueAtTime", Get(g_41, "value"), t_30);
Invoke(g_41, "linearRampToValueAtTime", ((V)(0.75)), Add(t_30, ((V)(0.25))));
Invoke(g_41, "linearRampToValueAtTime", ((V)(0.75)), Add(t_30, ((V)(1.6))));
Invoke(g_41, "linearRampToValueAtTime", ((V)(0.22)), Add(t_30, ((V)(2.6))));
Invoke(Arr(((V)(72D)), ((V)(76D)), ((V)(79D)), ((V)(84D))), "forEach", Fn((V _arrowThis50, int _argc42, V n_48, V j_49, V _a46, V _a47, V[] _rest43) => {
return Call(tone_14, V.Undef, Get(o_29, "out"), Add(Add(t_30, ((V)(0.1))), ((V)((ToNum(j_49) * 0.12)))), Call(mid_13, V.Undef, n_48), ((V)(0.3)), ((V)("square")), ((V)(0.08)));
}, 2, "", true));
}
OpSet(o_29, "next", 0, ((V)(0.125)));
} else {
V S_51 = default;
V n_52 = default;
V b_53 = default;
S_51 = (GetK(SONG_18, Get(o_29, "ch")) is var _t54 && Truthy(_t54) ? _t54 : GetIdx(SONG_18, 1D));
n_52 = GetIdx(Get(S_51, "lead"), (ToNum(i_31) % ToNum(Get(Get(S_51, "lead"), "length"))));
b_53 = GetIdx(Get(S_51, "bass"), (((double)(ToInt32(ToNum(i_31)) >> (int)(ToUint32(1D) & 31))) % ToNum(Get(Get(S_51, "bass"), "length"))));
if (Truthy(n_52)) {
Call(tone_14, V.Undef, (Truthy(Get(o_29, "fx")) ? Arr(Get(o_29, "out"), Get(o_29, "fx")) : Get(o_29, "out")), t_30, Call(mid_13, V.Undef, n_52), ((V)((ToNum(Get(S_51, "st")) * (SEqN(Get(o_29, "ch"), 3D) ? 2.2 : 0.9)))), Get(S_51, "lt"), Get(S_51, "lv"));
}
if (Truthy((b_53 is var _t55 && !Truthy(_t55) ? _t55 : (((ToNum(i_31) % 2D) == 0D) ? V.True : V.False)))) {
Call(tone_14, V.Undef, Get(o_29, "out"), t_30, Call(mid_13, V.Undef, b_53), ((V)((ToNum(Get(S_51, "st")) * (SEqN(Get(o_29, "ch"), 3D) ? 7D : 1.6)))), Get(S_51, "bt"), Get(S_51, "bv"));
}
if ((SEqN(Get(o_29, "ch"), 1D) && ((ToNum(i_31) % 4D) == 2D))) {
Call(clap_17, V.Undef, Get(o_29, "out"), t_30, ((V)(0.12)));
}
OpSet(o_29, "next", 0, Get(S_51, "st"));
}
IncM(o_29, "i", 1D, false);
return default;
}, 1, "step", false);
play_20 = Fn((V _self56, int _argc57, V key_63, V ch_64, V _a61, V _a62, V[] _rest58) => {
V cur_65 = default;
V @out_66 = default;
V o_67 = default;
if (_self56.IsNullish) _self56 = GlobalV;
if (!(Truthy(Call(ctx_12, V.Undef)))) {
return default;
}
cur_65 = Invoke(P_11, "get", key_63);
if (Truthy((cur_65 is var _t68 && !Truthy(_t68) ? _t68 : (SEq(Get(cur_65, "ch"), ch_64) ? V.True : V.False)))) {
return default;
}
if (Truthy(cur_65)) {
Call(stop_21, V.Undef, key_63);
}
@out_66 = Invoke(AC_8, "createGain");
Invoke(Get(@out_66, "gain"), "setValueAtTime", ((V)(0.0001)), Get(AC_8, "currentTime"));
Invoke(Get(@out_66, "gain"), "exponentialRampToValueAtTime", ((V)(1D)), Add(Get(AC_8, "currentTime"), ((V)(0.3))));
Invoke(@out_66, "connect", M_9);
o_67 = NewObj(5).Put("ch", ch_64).Put("out", @out_66).Put("i", ((V)(0D))).Put("next", Add(Get(AC_8, "currentTime"), ((V)(0.08)))).Put("nodes", Arr()).V;
if (SEqN(ch_64, 2D)) {
V s_69 = default;
V f_70 = default;
V g_71 = default;
s_69 = Invoke(AC_8, "createBufferSource");
f_70 = Invoke(AC_8, "createBiquadFilter");
g_71 = Invoke(AC_8, "createGain");
Set(s_69, "buffer", Call(noiseBuf_16, V.Undef));
Set(s_69, "loop", (true ? V.True : V.False));
Set(f_70, "type", ((V)("bandpass")));
Set(Get(f_70, "frequency"), "value", ((V)(900D)));
Set(Get(f_70, "Q"), "value", ((V)(0.6)));
Set(Get(g_71, "gain"), "value", ((V)(0.22)));
Invoke(s_69, "connect", f_70);
Invoke(f_70, "connect", g_71);
Invoke(g_71, "connect", @out_66);
Invoke(s_69, "start");
Set(o_67, "cg", g_71);
Invoke(Get(o_67, "nodes"), "push", s_69);
}
if (SEqN(ch_64, 3D)) {
V d_72 = default;
V fb_73 = default;
d_72 = Invoke(AC_8, "createDelay", ((V)(1D)));
fb_73 = Invoke(AC_8, "createGain");
Set(Get(d_72, "delayTime"), "value", ((V)(0.33)));
Set(Get(fb_73, "gain"), "value", ((V)(0.38)));
Invoke(d_72, "connect", fb_73);
Invoke(fb_73, "connect", d_72);
Invoke(d_72, "connect", @out_66);
Set(o_67, "fx", d_72);
}
Set(o_67, "tm", Call(G("setInterval"), V.Undef, Fn((V _arrowThis87, int _argc81, V _a83, V _a84, V _a85, V _a86, V[] _rest82) => {
while (Lt(Get(o_67, "next"), Add(Get(AC_8, "currentTime"), ((V)(0.2))))) {
Call(step_19, V.Undef, o_67);
}
return default;
}, 0, "", true), ((V)(40D))));
Invoke(P_11, "set", key_63, o_67);
return default;
}, 2, "play", false);
stop_21 = Fn((V _self88, int _argc89, V key_95, V _a92, V _a93, V _a94, V[] _rest90) => {
V o_96 = default;
V t_97 = default;
if (_self88.IsNullish) _self88 = GlobalV;
o_96 = Invoke(P_11, "get", key_95);
if (!(Truthy(o_96))) {
return default;
}
Invoke(P_11, "delete", key_95);
Call(G("clearInterval"), V.Undef, Get(o_96, "tm"));
t_97 = Get(AC_8, "currentTime");
Invoke(Get(Get(o_96, "out"), "gain"), "cancelScheduledValues", t_97);
Invoke(Get(Get(o_96, "out"), "gain"), "setValueAtTime", Get(Get(Get(o_96, "out"), "gain"), "value"), t_97);
Invoke(Get(Get(o_96, "out"), "gain"), "linearRampToValueAtTime", ((V)(0.0001)), Add(t_97, ((V)(0.25))));
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis123, int _argc117, V _a119, V _a120, V _a121, V _a122, V[] _rest118) => {
Invoke(Get(o_96, "nodes"), "forEach", Fn((V _arrowThis130, int _argc124, V n_111, V _a127, V _a128, V _a129, V[] _rest125) => {
try {
Invoke(n_111, "stop");
} catch (System.Exception _ex131) {
V e_114 = default;
e_114 = Caught(_ex131);

}
return default;
}, 1, "", true));
try {
Invoke(Get(o_96, "out"), "disconnect");
} catch (System.Exception _ex132) {
V e_116 = default;
e_116 = Caught(_ex132);

}
return default;
}, 0, "", true), ((V)(400D)));
return default;
}, 1, "stop", false);
if (Truthy(Get(G("window"), "TvSound"))) {
return default;
}
AC_8 = V.Null;
M_9 = V.Null;
NB_10 = V.Null;
P_11 = New(G("Map"));
ctx_12 = Fn((V _arrowThis139, int _argc133, V _a135, V _a136, V _a137, V _a138, V[] _rest134) => {
if (!(Truthy(AC_8))) {
V A_140 = default;
A_140 = (Get(G("window"), "AudioContext") is var _t141 && Truthy(_t141) ? _t141 : Get(G("window"), "webkitAudioContext"));
if (!(Truthy(A_140))) {
return V.Null;
}
AC_8 = New(A_140);
M_9 = Invoke(AC_8, "createGain");
Set(Get(M_9, "gain"), "value", ((V)(0.2)));
Invoke(M_9, "connect", Get(AC_8, "destination"));
}
if (SEqS(Get(AC_8, "state"), "suspended")) {
Invoke(AC_8, "resume");
}
return AC_8;
return default;
}, 0, "", true);
mid_13 = Fn((V _arrowThis149, int _argc142, V n_148, V _a145, V _a146, V _a147, V[] _rest143) => {
return ((V)((440D * Pow(2D, ((ToNum(n_148) - 69D) / 12D)))));
}, 1, "", true);
tone_14 = Fn((V _arrowThis162, int _argc150, V dest_156, V t_157, V f_158, V d_159, V[] _rest151) => {
V os_163 = default;
V g_164 = default;
V type_160 = default;
V v_161 = default;
type_160 = (_argc150 > 4 ? _rest151[0] : V.Undef);
v_161 = (_argc150 > 5 ? _rest151[1] : V.Undef);
os_163 = Invoke(AC_8, "createOscillator");
g_164 = Invoke(AC_8, "createGain");
Set(os_163, "type", type_160);
Invoke(Get(os_163, "frequency"), "setValueAtTime", f_158, t_157);
Invoke(Get(g_164, "gain"), "setValueAtTime", ((V)(0.0001)), t_157);
Invoke(Get(g_164, "gain"), "exponentialRampToValueAtTime", v_161, Add(t_157, ((V)(0.012))));
Invoke(Get(g_164, "gain"), "exponentialRampToValueAtTime", ((V)(0.0001)), Add(t_157, d_159));
Invoke(os_163, "connect", g_164);
Invoke(((dest_156.O is JsArray) ? dest_156 : Arr(dest_156)), "forEach", Fn((V _arrowThis172, int _argc165, V x_171, V _a168, V _a169, V _a170, V[] _rest166) => {
return Invoke(g_164, "connect", x_171);
}, 1, "", true));
Invoke(os_163, "start", t_157);
Invoke(os_163, "stop", Add(Add(t_157, d_159), ((V)(0.05))));
return default;
}, 6, "", true);
thump_15 = Fn((V _arrowThis182, int _argc173, V dest_179, V t_180, V v_181, V _a178, V[] _rest174) => {
V os_183 = default;
V g_184 = default;
os_183 = Invoke(AC_8, "createOscillator");
g_184 = Invoke(AC_8, "createGain");
Set(os_183, "type", ((V)("sine")));
Invoke(Get(os_183, "frequency"), "setValueAtTime", ((V)(140D)), t_180);
Invoke(Get(os_183, "frequency"), "exponentialRampToValueAtTime", ((V)(48D)), Add(t_180, ((V)(0.18))));
Invoke(Get(g_184, "gain"), "setValueAtTime", v_181, t_180);
Invoke(Get(g_184, "gain"), "exponentialRampToValueAtTime", ((V)(0.0001)), Add(t_180, ((V)(0.25))));
Invoke(os_183, "connect", g_184);
Invoke(g_184, "connect", dest_179);
Invoke(os_183, "start", t_180);
Invoke(os_183, "stop", Add(t_180, ((V)(0.3))));
return default;
}, 3, "", true);
noiseBuf_16 = Fn((V _arrowThis191, int _argc185, V _a187, V _a188, V _a189, V _a190, V[] _rest186) => {
V d_192 = default;
if (Truthy(NB_10)) {
return NB_10;
}
NB_10 = Invoke(AC_8, "createBuffer", ((V)(1D)), ((V)((ToNum(Get(AC_8, "sampleRate")) * 2D))), Get(AC_8, "sampleRate"));
d_192 = Invoke(NB_10, "getChannelData", ((V)(0D)));
{
double i_193 = 0;
i_193 = 0D;
while (true) {
if (!(Lt(((V)(i_193)), Get(d_192, "length")))) break;
SetIdx(d_192, i_193, ((V)(((ToNum(Invoke(G("Math"), "random")) * 2D) - 1D))));
i_193++;
}
}
return NB_10;
return default;
}, 0, "", true);
clap_17 = Fn((V _arrowThis204, int _argc195, V dest_201, V t_202, V v_203, V _a200, V[] _rest196) => {
V s_205 = default;
V f_206 = default;
V g_207 = default;
s_205 = Invoke(AC_8, "createBufferSource");
f_206 = Invoke(AC_8, "createBiquadFilter");
g_207 = Invoke(AC_8, "createGain");
Set(s_205, "buffer", Call(noiseBuf_16, V.Undef));
Set(f_206, "type", ((V)("bandpass")));
Set(Get(f_206, "frequency"), "value", ((V)(1500D)));
Invoke(Get(g_207, "gain"), "setValueAtTime", v_203, t_202);
Invoke(Get(g_207, "gain"), "exponentialRampToValueAtTime", ((V)(0.0001)), Add(t_202, ((V)(0.12))));
Invoke(s_205, "connect", f_206);
Invoke(f_206, "connect", g_207);
Invoke(g_207, "connect", dest_201);
Invoke(s_205, "start", t_202, Invoke(G("Math"), "random"));
Invoke(s_205, "stop", Add(t_202, ((V)(0.15))));
return default;
}, 3, "", true);
SONG_18 = NewObj(2).Put("1", NewObj(7).Put("st", ((V)(((60D / 132D) / 2D)))).Put("lead", Arr(((V)(72D)), ((V)(76D)), ((V)(79D)), ((V)(76D)), ((V)(74D)), ((V)(77D)), ((V)(81D)), ((V)(77D)), ((V)(76D)), ((V)(79D)), ((V)(84D)), ((V)(79D)), ((V)(77D)), ((V)(74D)), ((V)(72D)), ((V)(0D)), ((V)(72D)), ((V)(72D)), ((V)(76D)), ((V)(79D)), ((V)(81D)), ((V)(79D)), ((V)(77D)), ((V)(76D)), ((V)(74D)), ((V)(77D)), ((V)(76D)), ((V)(74D)), ((V)(72D)), ((V)(0D)), ((V)(67D)), ((V)(0D)))).Put("bass", Arr(((V)(48D)), ((V)(0D)), ((V)(55D)), ((V)(0D)), ((V)(50D)), ((V)(0D)), ((V)(57D)), ((V)(0D)), ((V)(52D)), ((V)(0D)), ((V)(55D)), ((V)(0D)), ((V)(53D)), ((V)(0D)), ((V)(48D)), ((V)(0D)))).Put("lt", ((V)("triangle"))).Put("bt", ((V)("square"))).Put("lv", ((V)(0.35))).Put("bv", ((V)(0.1))).V).Put("3", NewObj(7).Put("st", ((V)(((60D / 96D) / 2D)))).Put("lead", Arr(((V)(64D)), ((V)(71D)), ((V)(76D)), ((V)(79D)), ((V)(76D)), ((V)(71D)), ((V)(67D)), ((V)(74D)), ((V)(79D)), ((V)(83D)), ((V)(79D)), ((V)(74D)), ((V)(64D)), ((V)(71D)), ((V)(76D)), ((V)(79D)), ((V)(62D)), ((V)(69D)), ((V)(74D)), ((V)(78D)), ((V)(74D)), ((V)(69D)), ((V)(66D)), ((V)(73D)), ((V)(78D)), ((V)(81D)), ((V)(78D)), ((V)(73D)), ((V)(62D)), ((V)(69D)), ((V)(74D)), ((V)(0D)))).Put("bass", Arr(((V)(40D)), ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(43D)), ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(47D)), ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(45D)), ((V)(0D)), ((V)(0D)), ((V)(0D)))).Put("lt", ((V)("sine"))).Put("bt", ((V)("sine"))).Put("lv", ((V)(0.28))).Put("bv", ((V)(0.22))).V).V;
Set(G("window"), "TvSound", NewObj(5).Put("play", play_20).Put("stop", stop_21).Put("isOn", Fn((V _arrowThis215, int _argc208, V k_214, V _a211, V _a212, V _a213, V[] _rest209) => {
return Invoke(P_11, "has", k_214);
}, 1, "isOn", true)).Put("stopAll", Fn((V _arrowThis222, int _argc216, V _a218, V _a219, V _a220, V _a221, V[] _rest217) => {
return Invoke(new ArrBuilder().Spread(Invoke(P_11, "keys")).V, "forEach", stop_21);
}, 0, "stopAll", true)).Put("keys", Fn((V _arrowThis229, int _argc223, V _a225, V _a226, V _a227, V _a228, V[] _rest224) => {
return new ArrBuilder().Spread(Invoke(P_11, "keys")).V;
}, 0, "keys", true)).V);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
