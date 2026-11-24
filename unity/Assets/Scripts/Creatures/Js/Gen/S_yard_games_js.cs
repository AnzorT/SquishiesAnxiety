// yard-games.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_yard_games_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V NS_8 = default;
double TAU_9 = 0;
double W_10 = 0;
double H_11 = 0;
V YG_12 = default;
V S_13 = default;
V D_14 = default;
V cl_15 = default;
V lerp_16 = default;
V SM_17 = default;
V r2_18 = default;
V set_19 = default;
V ease_20 = default;
V track_21 = default;
V LS_22 = default;
V SAVE_23 = default;
V save_24 = default;
V AC_25 = default;
V muted_26 = default;
V ac_27 = default;
V tone_28 = default;
V noise_29 = default;
V SFX_30 = default;
V defs_31 = default;
double pid_32 = 0;
V run_33 = default;
V roster_34 = default;
V playerC_35 = default;
V thumb_36 = default;
if (_self1.IsNullish) _self1 = GlobalV;
tone_28 = Fn((V _self37, int _argc38, V f0_44, V f1_45, V dur_46, V type_47, V[] _rest39) => {
V a_50 = default;
V t_51 = default;
V o_52 = default;
V g_53 = default;
V vol_48 = default;
V delay_49 = default;
if (_self37.IsNullish) _self37 = GlobalV;
vol_48 = (_argc38 > 4 ? _rest39[0] : V.Undef);
delay_49 = (_argc38 > 5 ? _rest39[1] : V.Undef);
a_50 = Call(ac_27, V.Undef);
if (!(Truthy(a_50))) {
return default;
}
t_51 = Add(Get(a_50, "currentTime"), (delay_49 is var _t54 && Truthy(_t54) ? _t54 : ((V)(0D))));
o_52 = Invoke(a_50, "createOscillator");
g_53 = Invoke(a_50, "createGain");
Set(o_52, "type", (type_47 is var _t55 && Truthy(_t55) ? _t55 : ((V)("sine"))));
Invoke(Get(o_52, "frequency"), "setValueAtTime", f0_44, t_51);
if (Truthy(f1_45)) {
Invoke(Get(o_52, "frequency"), "exponentialRampToValueAtTime", f1_45, Add(t_51, dur_46));
}
Invoke(Get(g_53, "gain"), "setValueAtTime", ((V)(0.0001)), t_51);
Invoke(Get(g_53, "gain"), "exponentialRampToValueAtTime", (vol_48 is var _t56 && Truthy(_t56) ? _t56 : ((V)(0.18))), Add(t_51, ((V)(0.012))));
Invoke(Get(g_53, "gain"), "exponentialRampToValueAtTime", ((V)(0.0001)), Add(t_51, dur_46));
Invoke(o_52, "connect", g_53);
Invoke(g_53, "connect", Get(a_50, "destination"));
Invoke(o_52, "start", t_51);
Invoke(o_52, "stop", Add(Add(t_51, dur_46), ((V)(0.02))));
return default;
}, 6, "tone", false);
noise_29 = Fn((V _self57, int _argc58, V dur_64, V vol_65, V lp_66, V delay_67, V[] _rest59) => {
V a_68 = default;
V t_69 = default;
double n_70 = 0;
V b_71 = default;
V d_72 = default;
V s_73 = default;
V f_74 = default;
V g_75 = default;
if (_self57.IsNullish) _self57 = GlobalV;
a_68 = Call(ac_27, V.Undef);
if (!(Truthy(a_68))) {
return default;
}
t_69 = Add(Get(a_68, "currentTime"), (delay_67 is var _t76 && Truthy(_t76) ? _t76 : ((V)(0D))));
n_70 = System.Math.Floor((ToNum(Get(a_68, "sampleRate")) * ToNum(dur_64)));
b_71 = Invoke(a_68, "createBuffer", ((V)(1D)), ((V)(n_70)), Get(a_68, "sampleRate"));
d_72 = Invoke(b_71, "getChannelData", ((V)(0D)));
{
double i_77 = 0;
i_77 = 0D;
while (true) {
if (!((i_77 < n_70))) break;
SetIdx(d_72, i_77, ((V)((((ToNum(Invoke(G("Math"), "random")) * 2D) - 1D) * Pow((1D - (i_77 / n_70)), 2D)))));
i_77++;
}
}
s_73 = Invoke(a_68, "createBufferSource");
f_74 = Invoke(a_68, "createBiquadFilter");
g_75 = Invoke(a_68, "createGain");
Set(s_73, "buffer", b_71);
Set(f_74, "type", ((V)("lowpass")));
Set(Get(f_74, "frequency"), "value", (lp_66 is var _t79 && Truthy(_t79) ? _t79 : ((V)(1800D))));
Set(Get(g_75, "gain"), "value", (vol_65 is var _t80 && Truthy(_t80) ? _t80 : ((V)(0.2))));
Invoke(s_73, "connect", f_74);
Invoke(f_74, "connect", g_75);
Invoke(g_75, "connect", Get(a_68, "destination"));
Invoke(s_73, "start", t_69);
return default;
}, 4, "noise", false);
defs_31 = Fn((V _self81, int _argc82, V svg_88, V _a85, V _a86, V _a87, V[] _rest83) => {
V d_89 = default;
if (_self81.IsNullish) _self81 = GlobalV;
d_89 = Call(S_13, V.Undef, ((V)("defs")), NewObj(0).V, svg_88);
Set(d_89, "innerHTML", ((V)(JsStrBuf.Begin().S("<radialGradient id=\"ygBall\" cx=\"35%\" cy=\"30%\" r=\"75%\"><stop offset=\"0\" stop-color=\"#ffb070\"/><stop offset=\"0.55\" stop-color=\"#f07a2e\"/><stop offset=\"1\" stop-color=\"#b44a14\"/></radialGradient>").S("<radialGradient id=\"ygWhite\" cx=\"35%\" cy=\"30%\" r=\"75%\"><stop offset=\"0\" stop-color=\"#ffffff\"/><stop offset=\"0.6\" stop-color=\"#eef0f6\"/><stop offset=\"1\" stop-color=\"#b8bccb\"/></radialGradient>").S("<radialGradient id=\"ygGlow\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fff\" stop-opacity=\"0.95\"/><stop offset=\"1\" stop-color=\"#fff\" stop-opacity=\"0\"/></radialGradient>").S("<linearGradient id=\"ygSky\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#7cc6ff\"/><stop offset=\"0.65\" stop-color=\"#bfe6ff\"/><stop offset=\"1\" stop-color=\"#eaf7ff\"/></linearGradient>").S("<linearGradient id=\"ygGrass\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#9fdc6e\"/><stop offset=\"1\" stop-color=\"#5fb04a\"/></linearGradient>").S("<linearGradient id=\"ygWood\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#c98d54\"/><stop offset=\"0.5\" stop-color=\"#e2ad74\"/><stop offset=\"1\" stop-color=\"#b47740\"/></linearGradient>").S("<filter id=\"ygFuzz\" x=\"-10%\" y=\"-10%\" width=\"120%\" height=\"120%\"><feTurbulence type=\"fractalNoise\" baseFrequency=\"1.6\" numOctaves=\"2\" seed=\"4\"/><feColorMatrix values=\"0 0 0 0 1  0 0 0 0 1  0 0 0 0 1  0 0 0 0.16 0\"/><feComposite in2=\"SourceGraphic\" operator=\"in\"/><feBlend in=\"SourceGraphic\" mode=\"screen\"/></filter>").S("<filter id=\"ygSoft\" x=\"-30%\" y=\"-30%\" width=\"160%\" height=\"160%\"><feGaussianBlur stdDeviation=\"2.2\"/></filter>").End())));
return default;
}, 1, "defs", false);
run_33 = Fn((V _self90, int _argc91, V app_97, V G_98, V _a95, V _a96, V[] _rest92) => {
V R_99 = default;
V pl_100 = default;
V stageWrap_101 = default;
V now0_102 = default;
V bg_103 = default;
V crL_104 = default;
V fg_105 = default;
V hud_106 = default;
V inp_107 = default;
V ov_108 = default;
V top_109 = default;
V back_110 = default;
V ttl_111 = default;
V pills_112 = default;
V scP_113 = default;
V tmP_114 = default;
V hint_115 = default;
V toastL_116 = default;
V alive_117 = default;
V playing_118 = default;
V score_119 = default;
V left_120 = default;
V raf_121 = default;
V last_122 = default;
V inst_123 = default;
V parts_124 = default;
V creatures_125 = default;
V ended_126 = default;
V ctx_127 = default;
V results_128 = default;
V opts_129 = default;
V intro_130 = default;
V start_131 = default;
V loop_132 = default;
V pt_133 = default;
V up_134 = default;
V key_135 = default;
if (_self90.IsNullish) _self90 = GlobalV;
results_128 = Fn((V _self136, int _argc137, V extra_143, V _a140, V _a141, V _a142, V[] _rest138) => {
V best_144 = default;
V nb_145 = default;
V st_146 = default;
V card_147 = default;
V sr_148 = default;
V row_149 = default;
if (_self136.IsNullish) _self136 = GlobalV;
if (!(Truthy(alive_117))) {
return default;
}
best_144 = (GetK(Get(SAVE_23, "best"), Get(G_98, "id")) is var _t150 && Truthy(_t150) ? _t150 : ((V)(0D)));
nb_145 = (Gt(score_119, best_144) ? V.True : V.False);
if (Truthy(nb_145)) {
SetK(Get(SAVE_23, "best"), Get(G_98, "id"), score_119);
}
SetK(Get(SAVE_23, "plays"), Get(G_98, "id"), Add((GetK(Get(SAVE_23, "plays"), Get(G_98, "id")) is var _t151 && Truthy(_t151) ? _t151 : ((V)(0D))), ((V)(1D))));
Call(save_24, V.Undef);
st_146 = (Truthy(Get(G_98, "stars")) ? Get(Invoke(Get(G_98, "stars"), "filter", Fn((V _self136, int _argc152, V v_158, V _a155, V _a156, V _a157, V[] _rest153) => {
return (Ge(score_119, v_158) ? V.True : V.False);
}, 1, "", true)), "length") : ((V)(0D)));
if (Truthy((nb_145 is var _t159 && Truthy(_t159) ? _t159 : (GeN(st_146, 2D) ? V.True : V.False)))) {
Invoke(SFX_30, "win");
}
Set(ov_108, "innerHTML", ((V)("")));
Set(ov_108, "className", ((V)("yg-ov yg-show")));
card_147 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-card yg-res"))).V, ov_108);
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-res-t"))).V, card_147, (Get(extra_143, "title") is var _t160 && Truthy(_t160) ? _t160 : ((V)((GeN(st_146, 3D) ? "Amazing!" : (SEqN(st_146, 2D) ? "Great job!" : (SEqN(st_146, 1D) ? "Nice!" : "Good try!")))))));
sr_148 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-stars"))).V, card_147);
{
double i_161 = 0;
i_161 = 0D;
while (true) {
if (!((i_161 < 3D))) break;
Call(D_14, V.Undef, ((V)("span")), NewObj(2).Put("cls", ((V)(string.Concat("yg-star", (Lt(((V)(i_161)), st_146) ? " on" : ""))))).Put("style", ((V)(JsStrBuf.Begin().S("animation-delay:").N(((i_161 * 0.15) + 0.1)).S("s").End()))).V, sr_148, ((V)("\u2605")));
i_161++;
}
}
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-res-score"))).V, card_147, ((V)(ToStrS(score_119))));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-res-sub"))).V, card_147, ((V)(string.Concat((Truthy(Get(extra_143, "sub")) ? JsStrBuf.Begin().V(Get(extra_143, "sub")).S(" \u00b7 ").End() : ""), (Truthy(nb_145) ? "New best!" : JsStrBuf.Begin().S("Best ").V(best_144).End())))));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-res-coins"))).V, card_147, ((V)(JsStrBuf.Begin().S("+").N(Max(1D, Round((ToNum(score_119) * ToNum((Get(G_98, "coinK") is var _t163 && Truthy(_t163) ? _t163 : ((V)(1D)))))))).S(" coins (preview)").End())));
row_149 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-row"))).V, card_147);
Call(D_14, V.Undef, ((V)("button")), NewObj(2).Put("cls", ((V)("yg-btn yg-ghost"))).Put("onclick", Fn((V _self136, int _argc164, V _a166, V _a167, V _a168, V _a169, V[] _rest165) => {
return Invoke(app_97, "hub");
}, 0, "onclick", true)).V, row_149, ((V)((Truthy(Get(G("window"), "SquishApp")) ? "Yard games" : "Yard"))));
Call(D_14, V.Undef, ((V)("button")), NewObj(2).Put("cls", ((V)("yg-btn"))).Put("onclick", Fn((V _self136, int _argc170, V _a172, V _a173, V _a174, V _a175, V[] _rest171) => {
return Invoke(app_97, "play", G_98);
}, 0, "onclick", true)).V, row_149, ((V)("Play again")));
if (Truthy((Get(G("window"), "SquishApp") is var _t176 && !Truthy(_t176) ? _t176 : Get(Get(G("window"), "SquishApp"), "yardPopup")))) {
try {
Invoke(Get(G("window"), "SquishApp"), "yardPopup", card_147, ((V)("result")), st_146);
} catch (System.Exception _ex177) {
V e_178 = default;
e_178 = Caught(_ex177);
Invoke(G("console"), "warn", ((V)("[yard popup]")), e_178);
}
}
if (Truthy((inst_123 is var _t179 && !Truthy(_t179) ? _t179 : Get(inst_123, "celebrate")))) {
try {
Invoke(inst_123, "celebrate", st_146);
} catch (System.Exception _ex180) {
V e_181 = default;
e_181 = Caught(_ex180);

}
}
return default;
}, 1, "results", false);
opts_129 = Fn((V _self182, int _argc183, V card_189, V _a186, V _a187, V _a188, V[] _rest184) => {
V op_190 = default;
if (_self182.IsNullish) _self182 = GlobalV;
if (!(Truthy(Get(G_98, "options")))) {
return default;
}
op_190 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-opts"))).V, card_189);
Invoke(Get(G_98, "options"), "forEach", Fn((V _self182, int _argc191, V o2_197, V _a194, V _a195, V _a196, V[] _rest192) => {
V b_198 = default;
b_198 = Call(D_14, V.Undef, ((V)("button")), NewObj(2).Put("cls", ((V)(string.Concat("yg-opt", ((SEq(Get(G_98, "_opt"), Get(o2_197, "id")) || (!(Truthy(Get(G_98, "_opt"))) && SEq(o2_197, GetIdx(Get(G_98, "options"), 0D)))) ? " on" : ""))))).Put("onclick", Fn((V _self182, int _argc199, V _a201, V _a202, V _a203, V _a204, V[] _rest200) => {
Set(G_98, "_opt", Get(o2_197, "id"));
Invoke(new ArrBuilder().Spread(Get(op_190, "children")).V, "forEach", Fn((V _self182, int _argc205, V x_211, V _a208, V _a209, V _a210, V[] _rest206) => {
return Invoke(Get(x_211, "classList"), "remove", ((V)("on")));
}, 1, "", true));
Invoke(Get(b_198, "classList"), "add", ((V)("on")));
if (Truthy((inst_123 is var _t212 && !Truthy(_t212) ? _t212 : Get(inst_123, "option")))) {
Invoke(inst_123, "option", Get(o2_197, "id"));
}
return default;
}, 0, "onclick", true)).V, op_190, Get(o2_197, "label"));
return default;
}, 1, "", true));
return default;
}, 1, "opts", false);
intro_130 = Fn((V _self213, int _argc214, V _a216, V _a217, V _a218, V _a219, V[] _rest215) => {
V PO_220 = default;
V art_221 = default;
V card_222 = default;
V ic_223 = default;
V ul_224 = default;
if (_self213.IsNullish) _self213 = GlobalV;
Set(ov_108, "innerHTML", ((V)("")));
PO_220 = (Get(YG_12, "POSTER") is var _t225 && !Truthy(_t225) ? _t225 : GetK(Get(YG_12, "POSTER"), Get(G_98, "id")));
art_221 = ((V)(""));
if (Truthy(PO_220)) {
try {
art_221 = Call(PO_220, V.Undef, ((V)(JsStrBuf.Begin().S("ygp").N(++pid_32).S("_").End())), NewObj(2).Put("src", Call(thumb_36, V.Undef, pl_100)).Put("name", Get(pl_100, "name")).V);
} catch (System.Exception _ex226) {
V e_227 = default;
e_227 = Caught(_ex226);
Invoke(G("console"), "warn", ((V)("YardGames poster")), Get(G_98, "id"), e_227);
}
}
if (Truthy(art_221)) {
V artEl_228 = default;
V sh_229 = default;
V ul_230 = default;
Set(ov_108, "className", ((V)("yg-ov yg-show yg-intro")));
Invoke(Get(ov_108, "style"), "setProperty", ((V)("--gc")), (Get(G_98, "color") is var _t231 && Truthy(_t231) ? _t231 : ((V)("#ff8a3d"))));
Invoke(Get(Get(app_97, "root"), "classList"), "add", ((V)("yg-introing")));
artEl_228 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-iart"))).V, ov_108);
Set(artEl_228, "innerHTML", art_221);
if (Truthy(Get(YG_12, "posterRig"))) {
try {
Invoke(YG_12, "posterRig", artEl_228, Get(pl_100, "key"), NewObj(1).Put("opp", (inst_123 is var _t232 && !Truthy(_t232) ? _t232 : Get(inst_123, "oppKey"))).V);
} catch (System.Exception _ex233) {
V e_234 = default;
e_234 = Caught(_ex233);
Invoke(G("console"), "warn", ((V)("YardGames poster rig")), e_234);
}
}
Call(D_14, V.Undef, ((V)("button")), NewObj(3).Put("cls", ((V)("yg-iback"))).Put("aria-label", ((V)("Back to the yard"))).Put("onclick", Fn((V _self213, int _argc235, V _a237, V _a238, V _a239, V _a240, V[] _rest236) => {
return Invoke(app_97, "hub");
}, 0, "onclick", true)).V, ov_108, ((V)("\u2039")));
sh_229 = Call(D_14, V.Undef, ((V)("div")), NewObj(3).Put("cls", ((V)("yg-isheet"))).Put("role", ((V)("dialog"))).Put("aria-label", Get(G_98, "name")).V, ov_108);
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-ihead"))).V, sh_229, ((V)("How to play")));
ul_230 = Call(D_14, V.Undef, ((V)("ul")), NewObj(1).Put("cls", ((V)("yg-how"))).V, sh_229);
Invoke((Get(G_98, "how") is var _t248 && Truthy(_t248) ? _t248 : Arr()), "forEach", Fn((V _self213, int _argc241, V t_247, V _a244, V _a245, V _a246, V[] _rest242) => {
return Call(D_14, V.Undef, ((V)("li")), NewObj(0).V, ul_230, t_247);
}, 1, "", true));
Call(opts_129, V.Undef, sh_229);
Call(D_14, V.Undef, ((V)("button")), NewObj(2).Put("cls", ((V)("yg-btn yg-go"))).Put("onclick", Fn((V _self213, int _argc249, V _a251, V _a252, V _a253, V _a254, V[] _rest250) => {
Call(ac_27, V.Undef);
Set(ov_108, "className", ((V)("yg-ov")));
Invoke(Get(Get(app_97, "root"), "classList"), "remove", ((V)("yg-introing")));
Call(start_131, V.Undef);
return default;
}, 0, "onclick", true)).V, sh_229, ((V)("Play")));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-best"))).V, sh_229, ((V)((Truthy(GetK(Get(SAVE_23, "best"), Get(G_98, "id"))) ? JsStrBuf.Begin().S("Best ").V(GetK(Get(SAVE_23, "best"), Get(G_98, "id"))).End() : "No best yet"))));
if (Truthy((Get(G("window"), "SquishApp") is var _t255 && !Truthy(_t255) ? _t255 : Get(Get(G("window"), "SquishApp"), "yardPopup")))) {
try {
Invoke(Get(G("window"), "SquishApp"), "yardPopup", sh_229, ((V)("intro")));
} catch (System.Exception _ex256) {
V e_257 = default;
e_257 = Caught(_ex256);
Invoke(G("console"), "warn", ((V)("[yard popup]")), e_257);
}
}
return default;
}
Set(ov_108, "className", ((V)("yg-ov yg-show")));
card_222 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-card"))).V, ov_108);
ic_223 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-ic"))).V, card_222);
Set(ic_223, "innerHTML", (Get(G_98, "icon") is var _t258 && Truthy(_t258) ? _t258 : ((V)(""))));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-card-t"))).V, card_222, Get(G_98, "name"));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-card-s"))).V, card_222, ((V)(JsStrBuf.Begin().S("Yard: ").V(Get(G_98, "item")).End())));
ul_224 = Call(D_14, V.Undef, ((V)("ul")), NewObj(1).Put("cls", ((V)("yg-how"))).V, card_222);
Invoke((Get(G_98, "how") is var _t266 && Truthy(_t266) ? _t266 : Arr()), "forEach", Fn((V _self213, int _argc259, V t_265, V _a262, V _a263, V _a264, V[] _rest260) => {
return Call(D_14, V.Undef, ((V)("li")), NewObj(0).V, ul_224, t_265);
}, 1, "", true));
Call(opts_129, V.Undef, card_222);
Call(D_14, V.Undef, ((V)("button")), NewObj(2).Put("cls", ((V)("yg-btn yg-go"))).Put("onclick", Fn((V _self213, int _argc267, V _a269, V _a270, V _a271, V _a272, V[] _rest268) => {
Call(ac_27, V.Undef);
Set(ov_108, "className", ((V)("yg-ov")));
Call(start_131, V.Undef);
return default;
}, 0, "onclick", true)).V, card_222, ((V)("Play")));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-best"))).V, card_222, ((V)((Truthy(GetK(Get(SAVE_23, "best"), Get(G_98, "id"))) ? JsStrBuf.Begin().S("Best ").V(GetK(Get(SAVE_23, "best"), Get(G_98, "id"))).End() : "No best yet"))));
return default;
}, 0, "intro", false);
start_131 = Fn((V _self273, int _argc274, V _a276, V _a277, V _a278, V _a279, V[] _rest275) => {
if (_self273.IsNullish) _self273 = GlobalV;
playing_118 = (true ? V.True : V.False);
ended_126 = (false ? V.True : V.False);
score_119 = ((V)(0D));
Set(scP_113, "textContent", ((V)("0")));
left_120 = (Get(G_98, "dur") is var _t280 && Truthy(_t280) ? _t280 : ((V)(0D)));
Invoke(ctx_127, "toast", ((V)("Go!")), ((V)((W_10 / 2D))), ((V)((H_11 * 0.42))), ((V)("#ffffff")), (true ? V.True : V.False));
Invoke(SFX_30, "pop");
if (Truthy(Get(inst_123, "start"))) {
Invoke(inst_123, "start");
}
return default;
}, 0, "start", false);
W_10 = (Truthy(Get(G_98, "land")) ? 780D : 360D);
H_11 = (Truthy(Get(G_98, "land")) ? 360D : 640D);
Set(YG_12, "W", ((V)(W_10)));
Set(YG_12, "H", ((V)(H_11)));
R_99 = Get(G("window"), "SquishSquad");
pl_100 = Call(playerC_35, V.Undef);
stageWrap_101 = Get(app_97, "stage");
now0_102 = Invoke(G("performance"), "now");
Set(stageWrap_101, "innerHTML", ((V)("")));
Invoke(Get(Get(app_97, "root"), "classList"), "add", ((V)("yg-playing")));
bg_103 = Call(S_13, V.Undef, ((V)("svg")), NewObj(3).Put("viewBox", ((V)(JsStrBuf.Begin().S("0 0 ").N(W_10).S(" ").N(H_11).End()))).Put("class", ((V)("yg-layer"))).Put("preserveAspectRatio", ((V)("none"))).V, stageWrap_101);
Call(defs_31, V.Undef, bg_103);
crL_104 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-layer yg-crl"))).V, stageWrap_101);
fg_105 = Call(S_13, V.Undef, ((V)("svg")), NewObj(3).Put("viewBox", ((V)(JsStrBuf.Begin().S("0 0 ").N(W_10).S(" ").N(H_11).End()))).Put("class", ((V)("yg-layer"))).Put("preserveAspectRatio", ((V)("none"))).V, stageWrap_101);
hud_106 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-hud"))).V, stageWrap_101);
inp_107 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-input"))).V, stageWrap_101);
ov_108 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-ov"))).V, stageWrap_101);
top_109 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-top"))).V, hud_106);
back_110 = Call(D_14, V.Undef, ((V)("button")), NewObj(2).Put("cls", ((V)("yg-back"))).Put("aria-label", ((V)("Back to the yard"))).V, top_109, ((V)("\u2039")));
ttl_111 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-ttl"))).V, top_109, Get(G_98, "name"));
pills_112 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-pills"))).V, top_109);
scP_113 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-pill yg-score"))).V, pills_112, ((V)("0")));
tmP_114 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-pill yg-time"))).V, pills_112, ((V)("")));
hint_115 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-hint"))).V, hud_106, (Get(G_98, "hint") is var _t281 && Truthy(_t281) ? _t281 : ((V)(""))));
toastL_116 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-toasts"))).V, stageWrap_101);
alive_117 = (true ? V.True : V.False);
playing_118 = (false ? V.True : V.False);
score_119 = ((V)(0D));
left_120 = (Get(G_98, "dur") is var _t282 && Truthy(_t282) ? _t282 : ((V)(0D)));
raf_121 = ((V)(0D));
last_122 = ((V)(0D));
inst_123 = V.Null;
parts_124 = Arr();
creatures_125 = Arr();
ended_126 = (false ? V.True : V.False);
ctx_127 = NewObj(27).Put("W", ((V)(W_10))).Put("H", ((V)(H_11))).Put("bg", bg_103).Put("fg", fg_105).Put("crl", crL_104).Put("G", G_98).Put("S", S_13).Put("D", D_14).Put("YG", YG_12).Put("SFX", SFX_30).Put("playerKey", Get(pl_100, "key")).Put("playerName", Get(pl_100, "name")).Put("creature", Fn((V _self283, int _argc284, V key_290, V o_291, V _a288, V _a289, V[] _rest285) => {
V c_292 = default;
if (_self283.IsNullish) _self283 = GlobalV;
c_292 = Invoke(YG_12, "creature", crL_104, key_290, o_291);
Invoke(creatures_125, "push", c_292);
return c_292;
return default;
}, 2, "creature", false)).Put("opponent", Fn((V _self293, int _argc294, V n_300, V _a297, V _a298, V _a299, V[] _rest295) => {
V pool_301 = default;
V @out_302 = default;
if (_self293.IsNullish) _self293 = GlobalV;
pool_301 = Invoke(Invoke(Call(roster_34, V.Undef), "map", Fn((V _self293, int _argc311, V c_317, V _a314, V _a315, V _a316, V[] _rest312) => {
return Get(c_317, "key");
}, 1, "", true)), "filter", Fn((V _self293, int _argc303, V k_309, V _a306, V _a307, V _a308, V[] _rest304) => {
return (k_309 is var _t310 && !Truthy(_t310) ? _t310 : (!SEq(k_309, Get(pl_100, "key")) ? V.True : V.False));
}, 1, "", true));
@out_302 = Arr();
while (Truthy(((Lt(Get(@out_302, "length"), (n_300 is var _t318 && Truthy(_t318) ? _t318 : ((V)(1D)))) ? V.True : V.False) is var _t319 && !Truthy(_t319) ? _t319 : Get(pool_301, "length")))) {
Invoke(@out_302, "push", GetIdx(Invoke(pool_301, "splice", ((V)(System.Math.Floor((ToNum(Invoke(G("Math"), "random")) * ToNum(Get(pool_301, "length")))))), ((V)(1D))), 0D));
}
return (Truthy(n_300) ? @out_302 : GetIdx(@out_302, 0D));
return default;
}, 1, "opponent", false)).Put("nameOf", Fn((V _self320, int _argc321, V key_327, V _a324, V _a325, V _a326, V[] _rest322) => {
V c_328 = default;
if (_self320.IsNullish) _self320 = GlobalV;
c_328 = (R_99 is var _t337 && !Truthy(_t337) ? _t337 : Invoke(Get(R_99, "ROSTER"), "find", Fn((V _self320, int _argc329, V x_335, V _a332, V _a333, V _a334, V[] _rest330) => {
return (x_335 is var _t336 && !Truthy(_t336) ? _t336 : (SEq(Get(x_335, "key"), key_327) ? V.True : V.False));
}, 1, "", true)));
return (Truthy(c_328) ? Get(c_328, "name") : key_327);
return default;
}, 1, "nameOf", false)).Getter("score", Fn((V _self338, int _argc339, V _a341, V _a342, V _a343, V _a344, V[] _rest340) => {
if (_self338.IsNullish) _self338 = GlobalV;
return score_119;
return default;
}, 0, "score", false)).Put("add", Fn((V _self345, int _argc346, V n_352, V x_353, V y_354, V txt_355, V[] _rest347) => {
V col_356 = default;
if (_self345.IsNullish) _self345 = GlobalV;
col_356 = (_argc346 > 4 ? _rest347[0] : V.Undef);
score_119 = ((V)(Max(0D, ToNum(Add(score_119, n_352)))));
Set(scP_113, "textContent", score_119);
Invoke(Get(scP_113, "classList"), "remove", ((V)("yg-bump")));
_ = Get(scP_113, "offsetWidth");
Invoke(Get(scP_113, "classList"), "add", ((V)("yg-bump")));
if (Truthy(txt_355)) {
Invoke(ctx_127, "toast", txt_355, x_353, y_354, col_356);
}
return default;
}, 5, "add", false)).Put("setScore", Fn((V _self357, int _argc358, V n_364, V _a361, V _a362, V _a363, V[] _rest359) => {
if (_self357.IsNullish) _self357 = GlobalV;
score_119 = n_364;
Set(scP_113, "textContent", score_119);
return default;
}, 1, "setScore", false)).Put("addTime", Fn((V _self365, int _argc366, V s_372, V _a369, V _a370, V _a371, V[] _rest367) => {
if (_self365.IsNullish) _self365 = GlobalV;
if (Truthy((Get(G_98, "dur") is var _t373 && !Truthy(_t373) ? _t373 : playing_118))) {
left_120 = Add(left_120, s_372);
Invoke(Get(tmP_114, "classList"), "remove", ((V)("yg-hurry")));
}
return default;
}, 1, "addTime", false)).Put("timer", Fn((V _self374, int _argc375, V txt_381, V _a378, V _a379, V _a380, V[] _rest376) => {
if (_self374.IsNullish) _self374 = GlobalV;
Set(tmP_114, "textContent", txt_381);
Set(Get(tmP_114, "style"), "display", ((V)((Truthy(txt_381) ? "" : "none"))));
return default;
}, 1, "timer", false)).Put("hint", Fn((V _self382, int _argc383, V t_389, V _a386, V _a387, V _a388, V[] _rest384) => {
if (_self382.IsNullish) _self382 = GlobalV;
Set(hint_115, "textContent", (t_389 is var _t390 && Truthy(_t390) ? _t390 : ((V)(""))));
return default;
}, 1, "hint", false)).Getter("time", Fn((V _self391, int _argc392, V _a394, V _a395, V _a396, V _a397, V[] _rest393) => {
if (_self391.IsNullish) _self391 = GlobalV;
return left_120;
return default;
}, 0, "time", false)).Getter("playing", Fn((V _self398, int _argc399, V _a401, V _a402, V _a403, V _a404, V[] _rest400) => {
if (_self398.IsNullish) _self398 = GlobalV;
return playing_118;
return default;
}, 0, "playing", false)).Put("toast", Fn((V _self405, int _argc406, V txt_412, V x_413, V y_414, V col_415, V[] _rest407) => {
V e_417 = default;
V big_416 = default;
if (_self405.IsNullish) _self405 = GlobalV;
big_416 = (_argc406 > 4 ? _rest407[0] : V.Undef);
e_417 = Call(D_14, V.Undef, ((V)("div")), NewObj(2).Put("cls", ((V)(string.Concat("yg-toast", (Truthy(big_416) ? " yg-big" : ""))))).Put("style", ((V)(JsStrBuf.Begin().S("left:").V(Call(r2_18, V.Undef, ((V)(((ToNum((x_413.IsNullish ? ((V)((W_10 / 2D))) : x_413)) / W_10) * 100D))))).S("%;top:").V(Call(r2_18, V.Undef, ((V)(((ToNum((y_414.IsNullish ? ((V)((H_11 * 0.4))) : y_414)) / H_11) * 100D))))).S("%;color:").V((col_415 is var _t418 && Truthy(_t418) ? _t418 : ((V)("#ffffff")))).End()))).V, toastL_116, txt_412);
Call(G("setTimeout"), V.Undef, Fn((V _self405, int _argc425, V _a427, V _a428, V _a429, V _a430, V[] _rest426) => {
return Invoke(e_417, "remove");
}, 0, "", true), ((V)((Truthy(big_416) ? 1400D : 1000D))));
return default;
}, 5, "toast", false)).Put("burst", Fn((V _self431, int _argc432, V x_438, V y_439, V kind_440, V n_441, V[] _rest433) => {
V o_442 = default;
if (_self431.IsNullish) _self431 = GlobalV;
o_442 = (_argc432 > 4 ? _rest433[0] : V.Undef);
o_442 = (o_442 is var _t443 && Truthy(_t443) ? _t443 : NewObj(0).V);
{
double i_444 = 0;
i_444 = 0D;
while (true) {
if (!(Lt(((V)(i_444)), (n_441 is var _t446 && Truthy(_t446) ? _t446 : ((V)(10D)))))) break;
V a_447 = default;
double v_448 = 0;
V col_449 = default;
V e_450 = default;
a_447 = Add((!Get(o_442, "dir").IsNullish ? Get(o_442, "dir") : ((V)(((-System.Math.PI) / 2D)))), ((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * ToNum((Get(o_442, "spread") is var _t451 && Truthy(_t451) ? _t451 : ((V)(TAU_9))))))));
v_448 = (ToNum((Get(o_442, "v") is var _t452 && Truthy(_t452) ? _t452 : ((V)(120D)))) * (0.5 + (ToNum(Invoke(G("Math"), "random")) * 0.7)));
col_449 = (Get(o_442, "col") is var _t453 && Truthy(_t453) ? _t453 : (SEqS(kind_440, "drop") ? ((V)("#8fd3ff")) : (SEqS(kind_440, "dust") ? ((V)("#d8c7a8")) : GetIdx(Arr(((V)("#ffd84a")), ((V)("#ff8fc8")), ((V)("#8fe0ff")), ((V)("#b6f07a")), ((V)("#ffffff"))), (i_444 % 5D)))));
e_450 = ((SEqS(kind_440, "star") || SEqS(kind_440, "spark")) ? Call(S_13, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)("M0-5L1.4-1.4L5 0L1.4 1.4L0 5L-1.4 1.4L-5 0L-1.4-1.4Z"))).Put("fill", col_449).V, (Get(o_442, "layer") is var _t454 && Truthy(_t454) ? _t454 : fg_105)) : (SEqS(kind_440, "confetti") ? Call(S_13, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-2.5)))).Put("y", ((V)((-1.5)))).Put("width", ((V)(5D))).Put("height", ((V)(3D))).Put("fill", col_449).V, (Get(o_442, "layer") is var _t455 && Truthy(_t455) ? _t455 : fg_105)) : Call(S_13, V.Undef, ((V)("circle")), NewObj(3).Put("r", ((V)((SEqS(kind_440, "dust") ? 4D : 2.6)))).Put("fill", col_449).Put("opacity", ((V)(0.9))).V, (Get(o_442, "layer") is var _t456 && Truthy(_t456) ? _t456 : fg_105))));
Invoke(parts_124, "push", NewObj(11).Put("e", e_450).Put("x", x_438).Put("y", y_439).Put("vx", ((V)((FdLibm.Cos(ToNum(a_447)) * v_448)))).Put("vy", ((V)((FdLibm.Sin(ToNum(a_447)) * v_448)))).Put("g", (!Get(o_442, "g").IsNullish ? Get(o_442, "g") : ((V)((SEqS(kind_440, "dust") ? (-20D) : 260D))))).Put("life", ((V)((ToNum((Get(o_442, "life") is var _t457 && Truthy(_t457) ? _t457 : ((V)(0.8)))) * (0.7 + (ToNum(Invoke(G("Math"), "random")) * 0.5)))))).Put("t", ((V)(0D))).Put("rot", ((V)((ToNum(Invoke(G("Math"), "random")) * 360D)))).Put("vr", ((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 600D)))).Put("k", (Get(o_442, "k") is var _t458 && Truthy(_t458) ? _t458 : ((V)((SEqS(kind_440, "dust") ? 1.8 : 1D))))).V);
i_444++;
}
}
return default;
}, 5, "burst", false)).Put("finish", Fn((V _self459, int _argc460, V extra_466, V _a463, V _a464, V _a465, V[] _rest461) => {
if (_self459.IsNullish) _self459 = GlobalV;
if (Truthy(ended_126)) {
return default;
}
ended_126 = (true ? V.True : V.False);
playing_118 = (false ? V.True : V.False);
Call(G("setTimeout"), V.Undef, Fn((V _self459, int _argc475, V _a477, V _a478, V _a479, V _a480, V[] _rest476) => {
return Call(results_128, V.Undef, (extra_466 is var _t481 && Truthy(_t481) ? _t481 : NewObj(0).V));
}, 0, "", true), (Truthy((extra_466 is var _t482 && !Truthy(_t482) ? _t482 : (!Get(extra_466, "delay").IsNullish ? V.True : V.False))) ? Get(extra_466, "delay") : ((V)(700D))));
return default;
}, 1, "finish", false)).Put("on", Fn((V _self90, int _argc483, V ev_489, V fn_490, V _a487, V _a488, V[] _rest484) => {
return SetK(ctx_127, ((V)(JsStrBuf.Begin().S("_").V(ev_489).End())), fn_490);
}, 2, "on", true)).V;
loop_132 = Fn((V _self90, int _argc491, V t_497, V _a494, V _a495, V _a496, V[] _rest492) => {
double dt_498 = 0;
if (!(Truthy(alive_117))) {
return default;
}
dt_498 = Min(0.05, (Truthy(last_122) ? ((ToNum(t_497) - ToNum(last_122)) / 1000D) : 0.016));
last_122 = t_497;
if (Truthy((playing_118 is var _t499 && !Truthy(_t499) ? _t499 : Get(G_98, "dur")))) {
double pl0_500 = 0;
pl0_500 = System.Math.Ceiling(ToNum(left_120));
left_120 = ((V)(Max(0D, (ToNum(left_120) - dt_498))));
if ((((System.Math.Ceiling(ToNum(left_120)) != pl0_500) && LeN(left_120, 5D)) && GtN(left_120, 0D))) {
Invoke(SFX_30, "tick");
}
Invoke(ctx_127, "timer", ((V)(JsStrBuf.Begin().N(System.Math.Ceiling(ToNum(left_120))).S("s").End())));
Invoke(Get(tmP_114, "classList"), "toggle", ((V)("yg-hurry")), (LeN(left_120, 5D) ? V.True : V.False));
if (LeN(left_120, 0D)) {
if (Truthy(Get(inst_123, "timeUp"))) {
Invoke(inst_123, "timeUp");
} else {
Invoke(ctx_127, "finish");
}
}
}
try {
Invoke(inst_123, "update", ((V)(dt_498)), t_497);
} catch (System.Exception _ex501) {
V e_502 = default;
e_502 = Caught(_ex501);
if (!(Truthy(Get(loop_132, "err")))) {
Set(loop_132, "err", ((V)(1D)));
Invoke(G("console"), "error", ((V)("YardGames")), Get(G_98, "id"), e_502);
}
}
{
double i_503 = 0;
i_503 = (ToNum(Get(parts_124, "length")) - 1D);
while (true) {
if (!((i_503 >= 0D))) break;
V q_505 = default;
double u_506 = 0;
q_505 = GetIdx(parts_124, i_503);
OpSet(q_505, "t", 0, ((V)(dt_498)));
if (Ge(Get(q_505, "t"), Get(q_505, "life"))) {
Invoke(Get(q_505, "e"), "remove");
Invoke(parts_124, "splice", ((V)(i_503)), ((V)(1D)));
goto _cont504;
}
OpSet(q_505, "vy", 0, ((V)((ToNum(Get(q_505, "g")) * dt_498))));
OpSet(q_505, "x", 0, ((V)((ToNum(Get(q_505, "vx")) * dt_498))));
OpSet(q_505, "y", 0, ((V)((ToNum(Get(q_505, "vy")) * dt_498))));
OpSet(q_505, "rot", 0, ((V)((ToNum(Get(q_505, "vr")) * dt_498))));
u_506 = (ToNum(Get(q_505, "t")) / ToNum(Get(q_505, "life")));
Invoke(Get(q_505, "e"), "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_18, V.Undef, Get(q_505, "x"))).S(" ").V(Call(r2_18, V.Undef, Get(q_505, "y"))).S(") rotate(").N(Round(ToNum(Get(q_505, "rot")))).S(") scale(").V(Call(r2_18, V.Undef, ((V)(((1D - (u_506 * 0.5)) * ToNum(Get(q_505, "k"))))))).S(")").End())));
Invoke(Get(q_505, "e"), "setAttribute", ((V)("opacity")), Call(r2_18, V.Undef, ((V)((1D - (u_506 * u_506))))));
_cont504: ;
i_503--;
}
}
raf_121 = Call(G("requestAnimationFrame"), V.Undef, loop_132);
return default;
}, 1, "", true);
pt_133 = Fn((V _self90, int _argc507, V e_513, V _a510, V _a511, V _a512, V[] _rest508) => {
V r_514 = default;
r_514 = Invoke(inp_107, "getBoundingClientRect");
return NewObj(4).Put("x", ((V)((((ToNum(Get(e_513, "clientX")) - ToNum(Get(r_514, "left"))) / ToNum(Get(r_514, "width"))) * W_10)))).Put("y", ((V)((((ToNum(Get(e_513, "clientY")) - ToNum(Get(r_514, "top"))) / ToNum(Get(r_514, "height"))) * H_11)))).Put("t", Invoke(G("performance"), "now")).Put("id", Get(e_513, "pointerId")).V;
return default;
}, 1, "", true);
Invoke(inp_107, "addEventListener", ((V)("pointerdown")), Fn((V _self90, int _argc515, V e_521, V _a518, V _a519, V _a520, V[] _rest516) => {
if (!(Truthy(playing_118))) {
return default;
}
Invoke(e_521, "preventDefault");
try {
Invoke(inp_107, "setPointerCapture", Get(e_521, "pointerId"));
} catch (System.Exception _ex522) {
V x_523 = default;
x_523 = Caught(_ex522);

}
Call(ac_27, V.Undef);
if (Truthy(Get(inst_123, "down"))) {
Invoke(inst_123, "down", Call(pt_133, V.Undef, e_521));
}
return default;
}, 1, "", true));
Invoke(inp_107, "addEventListener", ((V)("pointermove")), Fn((V _self90, int _argc524, V e_530, V _a527, V _a528, V _a529, V[] _rest525) => {
if (!(Truthy(playing_118))) {
return default;
}
if (Truthy(Get(inst_123, "move"))) {
Invoke(inst_123, "move", Call(pt_133, V.Undef, e_530));
}
return default;
}, 1, "", true));
up_134 = Fn((V _self90, int _argc531, V e_537, V _a534, V _a535, V _a536, V[] _rest532) => {
if (!(Truthy(playing_118))) {
return default;
}
if (Truthy(Get(inst_123, "up"))) {
Invoke(inst_123, "up", Call(pt_133, V.Undef, e_537));
}
return default;
}, 1, "", true);
Invoke(inp_107, "addEventListener", ((V)("pointerup")), up_134);
Invoke(inp_107, "addEventListener", ((V)("pointercancel")), up_134);
key_135 = Fn((V _self90, int _argc538, V e_544, V _a541, V _a542, V _a543, V[] _rest539) => {
if ((!(Truthy(playing_118)) || !(Truthy(Get(inst_123, "key"))))) {
return default;
}
if (Truthy(Invoke(inst_123, "key", Get(e_544, "key"), (SEqS(Get(e_544, "type"), "keydown") ? V.True : V.False)))) {
Invoke(e_544, "preventDefault");
}
return default;
}, 1, "", true);
Invoke(G("window"), "addEventListener", ((V)("keydown")), key_135);
Invoke(G("window"), "addEventListener", ((V)("keyup")), key_135);
Invoke(back_110, "addEventListener", ((V)("click")), Fn((V _self90, int _argc545, V _a547, V _a548, V _a549, V _a550, V[] _rest546) => {
return Invoke(app_97, "hub");
}, 0, "", true));
Invoke(ctx_127, "timer", ((V)((Truthy(Get(G_98, "dur")) ? JsStrBuf.Begin().V(Get(G_98, "dur")).S("s").End() : ""))));
inst_123 = (Invoke(G_98, "make", ctx_127) is var _t551 && Truthy(_t551) ? _t551 : NewObj(0).V);
if (!(Truthy(Get(inst_123, "update")))) {
Set(inst_123, "update", Fn((V _self90, int _argc552, V _a554, V _a555, V _a556, V _a557, V[] _rest553) => {

return default;
}, 0, "", true));
}
Call(intro_130, V.Undef);
raf_121 = Call(G("requestAnimationFrame"), V.Undef, loop_132);
Set(YG_12, "_cur", NewObj(6).Put("G", G_98).Put("ctx", ctx_127).Put("inst", inst_123).Getter("score", Fn((V _self558, int _argc559, V _a561, V _a562, V _a563, V _a564, V[] _rest560) => {
if (_self558.IsNullish) _self558 = GlobalV;
return score_119;
return default;
}, 0, "score", false)).Put("start", Fn((V _self90, int _argc565, V _a567, V _a568, V _a569, V _a570, V[] _rest566) => {
Set(ov_108, "className", ((V)("yg-ov")));
Invoke(Get(Get(app_97, "root"), "classList"), "remove", ((V)("yg-introing")));
Call(start_131, V.Undef);
return default;
}, 0, "start", true)).Put("step", V.Null).V);
return Fn((V _self90, int _argc571, V _a573, V _a574, V _a575, V _a576, V[] _rest572) => {
alive_117 = (false ? V.True : V.False);
Call(G("cancelAnimationFrame"), V.Undef, raf_121);
Invoke(Get(Get(app_97, "root"), "classList"), "remove", ((V)("yg-introing")));
Invoke(G("window"), "removeEventListener", ((V)("keydown")), key_135);
Invoke(G("window"), "removeEventListener", ((V)("keyup")), key_135);
try {
if (Truthy(Get(inst_123, "destroy"))) {
Invoke(inst_123, "destroy");
}
} catch (System.Exception _ex577) {
V e_578 = default;
e_578 = Caught(_ex577);

}
Invoke(creatures_125, "forEach", Fn((V _self90, int _argc579, V c_585, V _a582, V _a583, V _a584, V[] _rest580) => {
return Invoke(c_585, "destroy");
}, 1, "", true));
Invoke(Get(Get(app_97, "root"), "classList"), "remove", ((V)("yg-playing")));
Set(YG_12, "_cur", V.Null);
return default;
}, 0, "", true);
return default;
}, 2, "run", false);
roster_34 = Fn((V _self586, int _argc587, V _a589, V _a590, V _a591, V _a592, V[] _rest588) => {
V R_593 = default;
if (_self586.IsNullish) _self586 = GlobalV;
R_593 = Get(G("window"), "SquishSquad");
if (!(Truthy(R_593))) {
return Arr();
}
return Invoke(Get(R_593, "ROSTER"), "filter", Fn((V _self586, int _argc594, V c_600, V _a597, V _a598, V _a599, V[] _rest595) => {
return ((c_600 is var _t601 && !Truthy(_t601) ? _t601 : Invoke(R_593, "src", Get(c_600, "id"))) is var _t602 && !Truthy(_t602) ? _t602 : Invoke(Get(YG_12, "SETS"), "includes", Get(c_600, "set")));
}, 1, "", true));
return default;
}, 0, "roster", false);
playerC_35 = Fn((V _self603, int _argc604, V _a606, V _a607, V _a608, V _a609, V[] _rest605) => {
V L_610 = default;
if (_self603.IsNullish) _self603 = GlobalV;
L_610 = Call(roster_34, V.Undef);
return ((Invoke(L_610, "find", Fn((V _self603, int _argc611, V c_617, V _a614, V _a615, V _a616, V[] _rest612) => {
return (SEq(Get(c_617, "id"), Get(SAVE_23, "player")) ? V.True : V.False);
}, 1, "", true)) is var _t625 && Truthy(_t625) ? _t625 : Invoke(L_610, "find", Fn((V _self603, int _argc618, V c_624, V _a621, V _a622, V _a623, V[] _rest619) => {
return (SEqS(Get(c_624, "key"), "mittens") ? V.True : V.False);
}, 1, "", true))) is var _t626 && Truthy(_t626) ? _t626 : GetIdx(L_610, 0D));
return default;
}, 0, "playerC", false);
NS_8 = ((V)("http://www.w3.org/2000/svg"));
TAU_9 = (System.Math.PI * 2D);
W_10 = 780D;
H_11 = 360D;
YG_12 = Set(G("window"), "YardGames", (Get(G("window"), "YardGames") is var _t627 && Truthy(_t627) ? _t627 : NewObj(1).Put("GAMES", Arr()).V));
Set(YG_12, "W", ((V)(W_10)));
Set(YG_12, "H", ((V)(H_11)));
Set(YG_12, "add", Fn((V _self1, int _argc628, V g_634, V _a631, V _a632, V _a633, V[] _rest629) => {
V i_635 = default;
i_635 = Invoke(Get(YG_12, "GAMES"), "findIndex", Fn((V _self1, int _argc636, V x_642, V _a639, V _a640, V _a641, V[] _rest637) => {
return (SEq(Get(x_642, "id"), Get(g_634, "id")) ? V.True : V.False);
}, 1, "", true));
if (GeN(i_635, 0D)) {
SetK(Get(YG_12, "GAMES"), i_635, g_634);
} else {
Invoke(Get(YG_12, "GAMES"), "push", g_634);
}
if (Truthy(Get(YG_12, "_hub"))) {
Invoke(YG_12, "_hub");
}
return default;
}, 1, "", true));
S_13 = Fn((V _self1, int _argc643, V tag_649, V a_650, V p_651, V _a648, V[] _rest644) => {
V e_652 = default;
e_652 = Invoke(G("document"), "createElementNS", NS_8, tag_649);
if (Truthy(a_650)) {
{
foreach (V _k653 in ForInKeys(a_650)) {
V k_654 = default;
k_654 = _k653;
if (!GetK(a_650, k_654).IsNullish) {
Invoke(e_652, "setAttribute", k_654, GetK(a_650, k_654));
}
}
}
}
if (Truthy(p_651)) {
Invoke(p_651, "appendChild", e_652);
}
return e_652;
return default;
}, 3, "", true);
D_14 = Fn((V _self1, int _argc655, V tag_661, V a_662, V p_663, V txt_664, V[] _rest656) => {
V e_665 = default;
e_665 = Invoke(G("document"), "createElement", tag_661);
if (Truthy(a_662)) {
{
foreach (V _k666 in ForInKeys(a_662)) {
V k_667 = default;
k_667 = _k666;
if (SEqS(k_667, "style")) {
Set(Get(e_665, "style"), "cssText", GetK(a_662, k_667));
} else {
if (SEqS(k_667, "cls")) {
Set(e_665, "className", GetK(a_662, k_667));
} else {
if (Truthy(Invoke(k_667, "startsWith", ((V)("on"))))) {
Invoke(e_665, "addEventListener", Invoke(k_667, "slice", ((V)(2D))), GetK(a_662, k_667));
} else {
Invoke(e_665, "setAttribute", k_667, GetK(a_662, k_667));
}
}
}
}
}
}
if (!txt_664.IsNullish) {
Set(e_665, "textContent", txt_664);
}
if (Truthy(p_663)) {
Invoke(p_663, "appendChild", e_665);
}
return e_665;
return default;
}, 4, "", true);
cl_15 = Fn((V _self1, int _argc668, V v_674, V a_675, V b_676, V _a673, V[] _rest669) => {
return (Lt(v_674, a_675) ? a_675 : (Gt(v_674, b_676) ? b_676 : v_674));
}, 3, "", true);
lerp_16 = Fn((V _self1, int _argc677, V a_683, V b_684, V u_685, V _a682, V[] _rest678) => {
return Add(a_683, ((V)(((ToNum(b_684) - ToNum(a_683)) * ToNum(u_685)))));
}, 3, "", true);
SM_17 = Fn((V _self1, int _argc686, V u_692, V _a689, V _a690, V _a691, V[] _rest687) => {
u_692 = Call(cl_15, V.Undef, u_692, ((V)(0D)), ((V)(1D)));
return ((V)(((ToNum(u_692) * ToNum(u_692)) * (3D - (2D * ToNum(u_692))))));
return default;
}, 1, "", true);
r2_18 = Fn((V _self1, int _argc693, V v_699, V _a696, V _a697, V _a698, V[] _rest694) => {
return ((V)((Round((ToNum(v_699) * 100D)) / 100D)));
}, 1, "", true);
set_19 = Fn((V _self1, int _argc700, V e_706, V k_707, V v_708, V _a705, V[] _rest701) => {
if (SEq(Get(e_706, "_c"), V.Undef)) {
Set(e_706, "_c", NewObj(0).V);
}
if (!SEq(GetK(Get(e_706, "_c"), k_707), v_708)) {
SetK(Get(e_706, "_c"), k_707, v_708);
Invoke(e_706, "setAttribute", k_707, v_708);
}
return default;
}, 3, "", true);
ease_20 = NewObj(4).Put("o", Fn((V _self1, int _argc709, V u_715, V _a712, V _a713, V _a714, V[] _rest710) => {
return ((V)((1D - ((1D - ToNum(u_715)) * (1D - ToNum(u_715))))));
}, 1, "o", true)).Put("i", Fn((V _self1, int _argc716, V u_722, V _a719, V _a720, V _a721, V[] _rest717) => {
return ((V)((ToNum(u_722) * ToNum(u_722))));
}, 1, "i", true)).Put("io", Fn((V _self1, int _argc723, V u_729, V _a726, V _a727, V _a728, V[] _rest724) => {
return ((V)((LtN(u_729, 0.5) ? ((2D * ToNum(u_729)) * ToNum(u_729)) : (1D - ((2D * (1D - ToNum(u_729))) * (1D - ToNum(u_729)))))));
}, 1, "io", true)).Put("back", Fn((V _self1, int _argc730, V u_736, V _a733, V _a734, V _a735, V[] _rest731) => {
double c_737 = 0;
c_737 = 1.7;
return ((V)(((1D + ((c_737 + 1D) * Pow((ToNum(u_736) - 1D), 3D))) + (c_737 * Pow((ToNum(u_736) - 1D), 2D)))));
return default;
}, 1, "back", true)).V;
track_21 = Fn((V _self1, int _argc738, V keys_744, V t_745, V _a742, V _a743, V[] _rest739) => {
V o_746 = default;
V chs_747 = default;
o_746 = NewObj(0).V;
chs_747 = New(G("Set"));
Invoke(keys_744, "forEach", Fn((V _self1, int _argc748, V k_754, V _a751, V _a752, V _a753, V[] _rest749) => {
return Invoke(Object_keys(GetIdx(k_754, 1D)), "forEach", Fn((V _self1, int _argc755, V c_761, V _a758, V _a759, V _a760, V[] _rest756) => {
return Invoke(chs_747, "add", c_761);
}, 1, "", true));
}, 1, "", true));
Invoke(chs_747, "forEach", Fn((V _self1, int _argc762, V c_768, V _a765, V _a766, V _a767, V[] _rest763) => {
V a_769 = default;
V b_770 = default;
a_769 = V.Null;
b_770 = V.Null;
{
foreach (V _k771 in new JsIter(keys_744)) {
V k_772 = default;
k_772 = _k771;
if (GetK(GetIdx(k_772, 1D), c_768).IsNullish) {
continue;
}
if (Le(GetIdx(k_772, 0D), t_745)) {
a_769 = k_772;
} else {
b_770 = k_772;
break;
}
}
}
SetK(o_746, c_768, (!(Truthy(a_769)) ? (Truthy(b_770) ? GetK(GetIdx(b_770, 1D), c_768) : ((V)(0D))) : (!(Truthy(b_770)) ? GetK(GetIdx(a_769, 1D), c_768) : Call(lerp_16, V.Undef, GetK(GetIdx(a_769, 1D), c_768), GetK(GetIdx(b_770, 1D), c_768), Invoke(ease_20, "io", ((V)(((ToNum(t_745) - ToNum(GetIdx(a_769, 0D))) / Max(1D, (ToNum(GetIdx(b_770, 0D)) - ToNum(GetIdx(a_769, 0D))))))))))));
return default;
}, 1, "", true));
return o_746;
return default;
}, 2, "", true);
Object_assign(YG_12, NewObj(10).Put("S", S_13).Put("D", D_14).Put("cl", cl_15).Put("lerp", lerp_16).Put("SM", SM_17).Put("r2", r2_18).Put("set", set_19).Put("ease", ease_20).Put("track", track_21).Put("TAU", ((V)(TAU_9))).V);
LS_22 = ((V)("yardgames.v1"));
SAVE_23 = NewObj(3).Put("best", NewObj(0).V).Put("player", V.Null).Put("plays", NewObj(0).V).V;
try {
V s_773 = default;
s_773 = Invoke(G("JSON"), "parse", (Invoke(G("localStorage"), "getItem", LS_22) is var _t774 && Truthy(_t774) ? _t774 : ((V)("null"))));
if (Truthy((s_773 is var _t775 && !Truthy(_t775) ? _t775 : Get(s_773, "best")))) {
SAVE_23 = Object_assign(SAVE_23, s_773);
}
} catch (System.Exception _ex776) {
V e_777 = default;
e_777 = Caught(_ex776);

}
save_24 = Fn((V _self1, int _argc778, V _a780, V _a781, V _a782, V _a783, V[] _rest779) => {
try {
Invoke(G("localStorage"), "setItem", LS_22, Invoke(G("JSON"), "stringify", SAVE_23));
} catch (System.Exception _ex784) {
V e_785 = default;
e_785 = Caught(_ex784);

}
return default;
}, 0, "", true);
AC_25 = V.Null;
muted_26 = (false ? V.True : V.False);
try {
muted_26 = (SEqS(Invoke(G("localStorage"), "getItem", ((V)(JsStrBuf.Begin().V(LS_22).S(".mute").End()))), "1") ? V.True : V.False);
} catch (System.Exception _ex786) {
V e_787 = default;
e_787 = Caught(_ex786);

}
ac_27 = Fn((V _self1, int _argc788, V _a790, V _a791, V _a792, V _a793, V[] _rest789) => {
if (Truthy(muted_26)) {
return V.Null;
}
try {
if (!(Truthy(AC_25))) {
AC_25 = New((Get(G("window"), "AudioContext") is var _t794 && Truthy(_t794) ? _t794 : Get(G("window"), "webkitAudioContext")));
}
if (SEqS(Get(AC_25, "state"), "suspended")) {
Invoke(AC_25, "resume");
}
} catch (System.Exception _ex795) {
V e_796 = default;
e_796 = Caught(_ex795);
AC_25 = V.Null;
}
return AC_25;
return default;
}, 0, "", true);
SFX_30 = NewObj(12).Put("pop", Fn((V _self1, int _argc797, V _a799, V _a800, V _a801, V _a802, V[] _rest798) => {
return Call(tone_28, V.Undef, ((V)(520D)), ((V)(880D)), ((V)(0.09)), ((V)("sine")), ((V)(0.16)));
}, 0, "pop", true)).Put("boing", Fn((V _self1, int _argc803, V _a805, V _a806, V _a807, V _a808, V[] _rest804) => {
return Call(tone_28, V.Undef, ((V)(180D)), ((V)(520D)), ((V)(0.22)), ((V)("triangle")), ((V)(0.18)));
}, 0, "boing", true)).Put("thud", Fn((V _self1, int _argc809, V _a811, V _a812, V _a813, V _a814, V[] _rest810) => {
Call(tone_28, V.Undef, ((V)(140D)), ((V)(60D)), ((V)(0.12)), ((V)("sine")), ((V)(0.22)));
Call(noise_29, V.Undef, ((V)(0.08)), ((V)(0.12)), ((V)(600D)));
return default;
}, 0, "thud", true)).Put("swish", Fn((V _self1, int _argc815, V _a817, V _a818, V _a819, V _a820, V[] _rest816) => {
return Call(noise_29, V.Undef, ((V)(0.22)), ((V)(0.16)), ((V)(3200D)));
}, 0, "swish", true)).Put("score", Fn((V _self1, int _argc821, V _a823, V _a824, V _a825, V _a826, V[] _rest822) => {
Call(tone_28, V.Undef, ((V)(660D)), ((V)(0D)), ((V)(0.1)), ((V)("triangle")), ((V)(0.16)));
Call(tone_28, V.Undef, ((V)(880D)), ((V)(0D)), ((V)(0.12)), ((V)("triangle")), ((V)(0.16)), ((V)(0.08)));
Call(tone_28, V.Undef, ((V)(1320D)), ((V)(0D)), ((V)(0.16)), ((V)("triangle")), ((V)(0.14)), ((V)(0.16)));
return default;
}, 0, "score", true)).Put("miss", Fn((V _self1, int _argc827, V _a829, V _a830, V _a831, V _a832, V[] _rest828) => {
return Call(tone_28, V.Undef, ((V)(330D)), ((V)(180D)), ((V)(0.25)), ((V)("sine")), ((V)(0.14)));
}, 0, "miss", true)).Put("tick", Fn((V _self1, int _argc833, V _a835, V _a836, V _a837, V _a838, V[] _rest834) => {
return Call(tone_28, V.Undef, ((V)(1200D)), ((V)(0D)), ((V)(0.04)), ((V)("square")), ((V)(0.05)));
}, 0, "tick", true)).Put("splash", Fn((V _self1, int _argc839, V _a841, V _a842, V _a843, V _a844, V[] _rest840) => {
Call(noise_29, V.Undef, ((V)(0.45)), ((V)(0.22)), ((V)(1400D)));
Call(tone_28, V.Undef, ((V)(300D)), ((V)(120D)), ((V)(0.2)), ((V)("sine")), ((V)(0.1)));
return default;
}, 0, "splash", true)).Put("clang", Fn((V _self1, int _argc845, V _a847, V _a848, V _a849, V _a850, V[] _rest846) => {
Call(tone_28, V.Undef, ((V)(900D)), ((V)(860D)), ((V)(0.25)), ((V)("triangle")), ((V)(0.1)));
Call(tone_28, V.Undef, ((V)(1340D)), ((V)(1300D)), ((V)(0.2)), ((V)("sine")), ((V)(0.06)));
return default;
}, 0, "clang", true)).Put("whoosh", Fn((V _self1, int _argc851, V _a853, V _a854, V _a855, V _a856, V[] _rest852) => {
return Call(noise_29, V.Undef, ((V)(0.3)), ((V)(0.1)), ((V)(900D)));
}, 0, "whoosh", true)).Put("tap", Fn((V _self1, int _argc857, V _a859, V _a860, V _a861, V _a862, V[] _rest858) => {
return Call(tone_28, V.Undef, ((V)(760D)), ((V)(0D)), ((V)(0.05)), ((V)("sine")), ((V)(0.1)));
}, 0, "tap", true)).Put("win", Fn((V _self1, int _argc863, V _a865, V _a866, V _a867, V _a868, V[] _rest864) => {
return Invoke(Arr(((V)(523D)), ((V)(659D)), ((V)(784D)), ((V)(1046D))), "forEach", Fn((V _self1, int _argc869, V f_875, V i_876, V _a873, V _a874, V[] _rest870) => {
return Call(tone_28, V.Undef, f_875, ((V)(0D)), ((V)(0.18)), ((V)("triangle")), ((V)(0.14)), ((V)((ToNum(i_876) * 0.1))));
}, 2, "", true));
}, 0, "win", true)).V;
Set(YG_12, "SFX", SFX_30);
Set(YG_12, "creature", Fn((V _self877, int _argc878, V layer_884, V key_885, V o_886, V _a883, V[] _rest879) => {
V host_887 = default;
V R_888 = default;
V ctrl_889 = default;
V I_890 = default;
V E_891 = default;
V c_892 = default;
if (_self877.IsNullish) _self877 = GlobalV;
o_886 = (o_886 is var _t893 && Truthy(_t893) ? _t893 : NewObj(0).V);
host_887 = Call(D_14, V.Undef, ((V)("div")), NewObj(2).Put("cls", ((V)("yg-cr"))).Put("style", ((V)("position:absolute;pointer-events:none;"))).V, layer_884);
R_888 = Get(G("window"), "RiveRig");
ctrl_889 = V.Null;
try {
ctrl_889 = Invoke(R_888, "mount", host_887, key_885, NewObj(1).Put("fidgets", (false ? V.True : V.False)).V);
} catch (System.Exception _ex894) {
V e_895 = default;
e_895 = Caught(_ex894);
Invoke(G("console"), "warn", ((V)("YardGames rig")), key_885, e_895);
}
I_890 = (ctrl_889 is var _t896 && !Truthy(_t896) ? _t896 : Get(ctrl_889, "_I"));
E_891 = NewObj(0).V;
if (Truthy(I_890)) {
Set(I_890, "ext", E_891);
Set(I_890, "fidgets", (false ? V.True : V.False));
Set(I_890, "ptr", NewObj(2).Put("x", ((V)(0D))).Put("y", ((V)(0D))).V);
}
c_892 = NewObj(22).Put("key", key_885).Put("host", host_887).Put("ctrl", ctrl_889).Put("I", I_890).Put("E", E_891).Put("x", ((V)(0D))).Put("y", ((V)(0D))).Put("size", ((V)(100D))).Put("r", ((V)(0D))).Put("ox", ((V)(50D))).Put("oy", ((V)(93D))).Put("ws", NewObj(0).V).Put("z", ((V)(0D))).Put("set", Fn((V _self897, int _argc898, V x_904, V y_905, V size_906, V _a903, V[] _rest899) => {
V s_907 = default;
if (_self897.IsNullish) _self897 = GlobalV;
if (!x_904.IsNullish) {
Set(_self897, "x", x_904);
}
if (!y_905.IsNullish) {
Set(_self897, "y", y_905);
}
if (!size_906.IsNullish) {
Set(_self897, "size", size_906);
}
s_907 = Get(_self897, "size");
Set(Get(host_887, "style"), "left", ((V)(JsStrBuf.Begin().V(Call(r2_18, V.Undef, ((V)((((ToNum(Get(_self897, "x")) - (ToNum(s_907) / 2D)) / W_10) * 100D))))).S("%").End())));
Set(Get(host_887, "style"), "top", ((V)(JsStrBuf.Begin().V(Call(r2_18, V.Undef, ((V)((((ToNum(Get(_self897, "y")) - (ToNum(s_907) * 0.93)) / H_11) * 100D))))).S("%").End())));
Set(Get(host_887, "style"), "width", ((V)(JsStrBuf.Begin().V(Call(r2_18, V.Undef, ((V)(((ToNum(s_907) / W_10) * 100D))))).S("%").End())));
Set(Get(host_887, "style"), "height", ((V)(JsStrBuf.Begin().V(Call(r2_18, V.Undef, ((V)(((ToNum(s_907) / H_11) * 100D))))).S("%").End())));
return _self897;
return default;
}, 3, "set", false)).Put("rot", Fn((V _self908, int _argc909, V deg_915, V ox_916, V oy_917, V _a914, V[] _rest910) => {
if (_self908.IsNullish) _self908 = GlobalV;
Set(_self908, "r", deg_915);
if (!ox_916.IsNullish) {
Set(_self908, "ox", ox_916);
Set(_self908, "oy", oy_917);
}
Set(Get(host_887, "style"), "transformOrigin", ((V)(JsStrBuf.Begin().V(Get(_self908, "ox")).S("% ").V(Get(_self908, "oy")).S("%").End())));
Set(Get(host_887, "style"), "transform", ((V)((Truthy(deg_915) ? JsStrBuf.Begin().S("rotate(").V(Call(r2_18, V.Undef, deg_915)).S("deg)").End() : ""))));
return _self908;
return default;
}, 3, "rot", false)).Put("yaw", Fn((V _self918, int _argc919, V deg_925, V _a922, V _a923, V _a924, V[] _rest920) => {
if (_self918.IsNullish) _self918 = GlobalV;
if (Truthy(I_890)) {
Set(I_890, "spinOff", deg_925);
}
return _self918;
return default;
}, 1, "yaw", false)).Put("play", Fn((V _self926, int _argc927, V n_933, V _a930, V _a931, V _a932, V[] _rest928) => {
if (_self926.IsNullish) _self926 = GlobalV;
if (Truthy(ctrl_889)) {
Invoke(ctrl_889, "play", n_933);
}
return _self926;
return default;
}, 1, "play", false)).Put("pose", Fn((V _self934, int _argc935, V p_941, V _a938, V _a939, V _a940, V[] _rest936) => {
if (_self934.IsNullish) _self934 = GlobalV;
{
foreach (V _k942 in ForInKeys(E_891)) {
V k_943 = default;
k_943 = _k942;
SetK(E_891, k_943, ((V)(0D)));
}
}
if (Truthy(p_941)) {
Object_assign(E_891, p_941);
}
return _self934;
return default;
}, 1, "pose", false)).Put("walk", Fn((V _self944, int _argc945, V dt_951, V w_952, V spin_953, V _a950, V[] _rest946) => {
if (_self944.IsNullish) _self944 = GlobalV;
if (Truthy(((GtN(w_952, 0.01) ? V.True : V.False) is var _t954 && !Truthy(_t954) ? _t954 : Get(G("window"), "HouseWalk")))) {
try {
Invoke(Get(G("window"), "HouseWalk"), "step", key_885, Get(_self944, "ws"), E_891, w_952, dt_951, ((V)(1D)), (spin_953 is var _t955 && Truthy(_t955) ? _t955 : ((V)(0D))));
} catch (System.Exception _ex956) {
V e_957 = default;
e_957 = Caught(_ex956);

}
}
return _self944;
return default;
}, 3, "walk", false)).Put("depth", Fn((V _self958, int _argc959, V z_965, V _a962, V _a963, V _a964, V[] _rest960) => {
if (_self958.IsNullish) _self958 = GlobalV;
Set(_self958, "z", z_965);
Set(Get(host_887, "style"), "zIndex", ((V)(Round(ToNum(z_965)))));
return _self958;
return default;
}, 1, "depth", false)).Put("hide", Fn((V _self966, int _argc967, V v_973, V _a970, V _a971, V _a972, V[] _rest968) => {
if (_self966.IsNullish) _self966 = GlobalV;
Set(Get(host_887, "style"), "visibility", ((V)((Truthy(v_973) ? "hidden" : ""))));
return _self966;
return default;
}, 1, "hide", false)).Put("destroy", Fn((V _self974, int _argc975, V _a977, V _a978, V _a979, V _a980, V[] _rest976) => {
if (_self974.IsNullish) _self974 = GlobalV;
try {
if (Truthy(ctrl_889)) {
Invoke(ctrl_889, "destroy");
}
} catch (System.Exception _ex981) {
V e_982 = default;
e_982 = Caught(_ex981);

}
Invoke(host_887, "remove");
return default;
}, 0, "destroy", false)).V;
if (Truthy(((I_890 is var _t983 && !Truthy(_t983) ? _t983 : Get(I_890, "shadow")) is var _t984 && !Truthy(_t984) ? _t984 : (!(Truthy(Get(o_886, "shadow"))) ? V.True : V.False)))) {
Set(Get(Get(I_890, "shadow"), "style"), "display", ((V)("none")));
Invoke(Get(I_890, "shadow"), "setAttribute", ((V)("rx")), ((V)(0D)));
}
if (!Get(o_886, "yaw").IsNullish) {
Invoke(c_892, "yaw", Get(o_886, "yaw"));
}
Invoke(c_892, "set", (Get(o_886, "x") is var _t985 && Truthy(_t985) ? _t985 : ((V)((W_10 / 2D)))), (Get(o_886, "y") is var _t986 && Truthy(_t986) ? _t986 : ((V)((H_11 - 60D)))), (Get(o_886, "size") is var _t987 && Truthy(_t987) ? _t987 : ((V)(140D))));
return c_892;
return default;
}, 3, "", false));
Set(YG_12, "cam", Fn((V _self1, int _argc988, V Dc_994, V CH_995, V HY_996, V K_997, V[] _rest989) => {
return Fn((V _self1, int _argc998, V x_1004, V y_1005, V z_1006, V _a1003, V[] _rest999) => {
double s_1007 = 0;
s_1007 = (ToNum(Dc_994) / ToNum(Add(Dc_994, z_1006)));
return Arr(((V)(((W_10 / 2D) + ((ToNum(x_1004) * s_1007) * ToNum(K_997))))), Add(HY_996, ((V)((((ToNum(CH_995) - ToNum(y_1005)) * s_1007) * ToNum(K_997))))), ((V)((s_1007 * ToNum(K_997)))));
return default;
}, 3, "", true);
}, 4, "", true));
Set(YG_12, "shadow", Fn((V _self1, int _argc1008, V p_1014, V x_1015, V y_1016, V rx_1017, V[] _rest1009) => {
V op_1018 = default;
op_1018 = (_argc1008 > 4 ? _rest1009[0] : V.Undef);
return Call(S_13, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", x_1015).Put("cy", y_1016).Put("rx", rx_1017).Put("ry", ((V)((ToNum(rx_1017) * 0.22)))).Put("fill", ((V)("#3a2a55"))).Put("opacity", (op_1018.IsNullish ? ((V)(0.18)) : op_1018)).V, p_1014);
}, 5, "", true));
Set(YG_12, "yard", Fn((V _self1019, int _argc1020, V p_1026, V o_1027, V _a1024, V _a1025, V[] _rest1021) => {
V hz_1028 = default;
double kw_1029 = 0;
double sd_1030 = 0;
V rnd_1031 = default;
V tg_1032 = default;
if (_self1019.IsNullish) _self1019 = GlobalV;
o_1027 = (o_1027 is var _t1033 && Truthy(_t1033) ? _t1033 : NewObj(0).V);
hz_1028 = (Get(o_1027, "hz") is var _t1034 && Truthy(_t1034) ? _t1034 : ((V)(250D)));
if (!SEq(Get(o_1027, "sky"), (false ? V.True : V.False))) {
Call(S_13, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-20D)))).Put("y", ((V)((-20D)))).Put("width", ((V)((W_10 + 40D)))).Put("height", Add(hz_1028, ((V)(40D)))).Put("fill", ((V)("url(#ygSky)"))).V, p_1026);
}
kw_1029 = (W_10 / 360D);
if (!SEq(Get(o_1027, "sky"), (false ? V.True : V.False))) {
Invoke(((kw_1029 > 1.5) ? Arr(Arr(((V)(60D)), ((V)(70D)), ((V)(1D))), Arr(((V)(250D)), ((V)(46D)), ((V)(0.8))), Arr(((V)(320D)), ((V)(120D)), ((V)(0.6))), Arr(((V)(140D)), ((V)(140D)), ((V)(0.55))), Arr(((V)(470D)), ((V)(60D)), ((V)(0.9))), Arr(((V)(610D)), ((V)(110D)), ((V)(0.6))), Arr(((V)(730D)), ((V)(40D)), ((V)(0.75)))) : Arr(Arr(((V)(60D)), ((V)(70D)), ((V)(1D))), Arr(((V)(250D)), ((V)(46D)), ((V)(0.8))), Arr(((V)(320D)), ((V)(120D)), ((V)(0.6))), Arr(((V)(140D)), ((V)(140D)), ((V)(0.55))))), "forEach", Fn((V _self1019, int _argc1035, V _a1037, V _a1038, V _a1039, V _a1040, V[] _rest1036) => {
V g_1048 = default;
V x_1043 = default;
V y_1045 = default;
V k_1047 = default;
{ V _t1041 = ListOf(_a1037);
{ V _t1042 = GetIdx(_t1041, 0D);
x_1043 = _t1042; }
{ V _t1044 = GetIdx(_t1041, 1D);
y_1045 = _t1044; }
{ V _t1046 = GetIdx(_t1041, 2D);
k_1047 = _t1046; }
}
g_1048 = Call(S_13, V.Undef, ((V)("g")), NewObj(2).Put("opacity", ((V)(0.92))).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(x_1043).S(" ").N(((ToNum(y_1045) * ToNum(hz_1028)) / 250D)).S(") scale(").V(k_1047).S(")").End()))).V, p_1026);
Invoke(Arr(Arr(((V)((-26D))), ((V)(4D)), ((V)(18D))), Arr(((V)(0D)), ((V)((-6D))), ((V)(24D))), Arr(((V)(26D)), ((V)(4D)), ((V)(18D))), Arr(((V)(10D)), ((V)(8D)), ((V)(18D))), Arr(((V)((-12D))), ((V)(9D)), ((V)(16D)))), "forEach", Fn((V _self1019, int _argc1049, V _a1051, V _a1052, V _a1053, V _a1054, V[] _rest1050) => {
V a_1057 = default;
V b_1059 = default;
V r_1061 = default;
{ V _t1055 = ListOf(_a1051);
{ V _t1056 = GetIdx(_t1055, 0D);
a_1057 = _t1056; }
{ V _t1058 = GetIdx(_t1055, 1D);
b_1059 = _t1058; }
{ V _t1060 = GetIdx(_t1055, 2D);
r_1061 = _t1060; }
}
return Call(S_13, V.Undef, ((V)("circle")), NewObj(4).Put("cx", a_1057).Put("cy", b_1059).Put("r", r_1061).Put("fill", ((V)("#ffffff"))).V, g_1048);
}, 1, "", true));
return default;
}, 1, "", true));
}
if (!SEq(Get(o_1027, "trees"), (false ? V.True : V.False))) {
Invoke(((kw_1029 > 1.5) ? Arr(Arr(((V)(18D)), ((V)(0.9))), Arr(((V)(120D)), ((V)(0.75))), Arr(((V)(250D)), ((V)(1.05))), Arr(((V)(520D)), ((V)(0.8))), Arr(((V)(640D)), ((V)(1.1))), Arr(((V)(690D)), ((V)(0.7))), Arr(((V)(762D)), ((V)(0.95)))) : Arr(Arr(((V)(18D)), ((V)(0.9))), Arr(((V)(342D)), ((V)(1.1))), Arr(((V)(300D)), ((V)(0.7))))), "forEach", Fn((V _self1019, int _argc1062, V _a1064, V _a1065, V _a1066, V _a1067, V[] _rest1063) => {
V g_1073 = default;
V x_1070 = default;
V k_1072 = default;
{ V _t1068 = ListOf(_a1064);
{ V _t1069 = GetIdx(_t1068, 0D);
x_1070 = _t1069; }
{ V _t1071 = GetIdx(_t1068, 1D);
k_1072 = _t1071; }
}
g_1073 = Call(S_13, V.Undef, ((V)("g")), NewObj(1).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(x_1070).S(" ").N((ToNum(hz_1028) - 6D)).S(") scale(").V(k_1072).S(")").End()))).V, p_1026);
Call(S_13, V.Undef, ((V)("rect")), NewObj(6).Put("x", ((V)((-4D)))).Put("y", ((V)((-34D)))).Put("width", ((V)(8D))).Put("height", ((V)(36D))).Put("rx", ((V)(3D))).Put("fill", ((V)("#8a5a34"))).V, g_1073);
Invoke(Arr(Arr(((V)((-14D))), ((V)((-44D))), ((V)(18D))), Arr(((V)(12D)), ((V)((-46D))), ((V)(20D))), Arr(((V)(0D)), ((V)((-62D))), ((V)(22D))), Arr(((V)((-4D))), ((V)((-40D))), ((V)(16D)))), "forEach", Fn((V _self1019, int _argc1074, V _a1076, V _a1077, V _a1078, V _a1079, V[] _rest1075) => {
V a_1082 = default;
V b_1084 = default;
V r_1086 = default;
{ V _t1080 = ListOf(_a1076);
{ V _t1081 = GetIdx(_t1080, 0D);
a_1082 = _t1081; }
{ V _t1083 = GetIdx(_t1080, 1D);
b_1084 = _t1083; }
{ V _t1085 = GetIdx(_t1080, 2D);
r_1086 = _t1085; }
}
return Call(S_13, V.Undef, ((V)("circle")), NewObj(4).Put("cx", a_1082).Put("cy", b_1084).Put("r", r_1086).Put("fill", ((V)("#57a854"))).V, g_1073);
}, 1, "", true));
Call(S_13, V.Undef, ((V)("circle")), NewObj(5).Put("cx", ((V)((-6D)))).Put("cy", ((V)((-66D)))).Put("r", ((V)(9D))).Put("fill", ((V)("#7cc46a"))).Put("opacity", ((V)(0.8))).V, g_1073);
return default;
}, 1, "", true));
}
if (!SEq(Get(o_1027, "fence"), (false ? V.True : V.False))) {
double fy_1087 = 0;
V g_1088 = default;
fy_1087 = (ToNum(hz_1028) - 34D);
g_1088 = Call(S_13, V.Undef, ((V)("g")), NewObj(0).V, p_1026);
Call(S_13, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-10D)))).Put("y", ((V)((fy_1087 + 10D)))).Put("width", ((V)((W_10 + 20D)))).Put("height", ((V)(6D))).Put("fill", ((V)("#f3e8da"))).V, g_1088);
Call(S_13, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-10D)))).Put("y", ((V)((fy_1087 + 26D)))).Put("width", ((V)((W_10 + 20D)))).Put("height", ((V)(6D))).Put("fill", ((V)("#f3e8da"))).V, g_1088);
{
double x_1089 = 0;
x_1089 = (-6D);
while (true) {
if (!((x_1089 < (W_10 + 10D)))) break;
Call(S_13, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").N(x_1089).S(" ").N((fy_1087 + 38D)).S("V").N((fy_1087 + 6D)).S("L").N((x_1089 + 6D)).S(" ").N(fy_1087).S("L").N((x_1089 + 12D)).S(" ").N((fy_1087 + 6D)).S("V").N((fy_1087 + 38D)).S("Z").End()))).Put("fill", ((V)("#fff8ee"))).Put("stroke", ((V)("#e2cfb8"))).Put("stroke-width", ((V)(1D))).V, g_1088);
x_1089 = (x_1089 + 18D);
}
}
}
Call(S_13, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-20D)))).Put("y", hz_1028).Put("width", ((V)((W_10 + 40D)))).Put("height", ((V)(((H_11 - ToNum(hz_1028)) + 20D)))).Put("fill", ((V)("url(#ygGrass)"))).V, p_1026);
sd_1030 = 7D;
rnd_1031 = Fn((V _self1019, int _argc1091, V _a1093, V _a1094, V _a1095, V _a1096, V[] _rest1092) => {
return ((V)(((sd_1030 = (((sd_1030 * 9301D) + 49297D) % 233280D)) / 233280D)));
}, 0, "", true);
tg_1032 = Call(S_13, V.Undef, ((V)("g")), NewObj(1).Put("opacity", ((V)(0.55))).V, p_1026);
{
double i_1097 = 0;
i_1097 = 0D;
while (true) {
if (!((i_1097 < Round((46D * kw_1029))))) break;
double x_1099 = 0;
V y_1100 = default;
double k_1101 = 0;
x_1099 = (ToNum(Call(rnd_1031, V.Undef)) * W_10);
y_1100 = Add(Add(hz_1028, ((V)(8D))), ((V)((ToNum(Call(rnd_1031, V.Undef)) * ((H_11 - ToNum(hz_1028)) - 10D)))));
k_1101 = (0.6 + (((ToNum(y_1100) - ToNum(hz_1028)) / (H_11 - ToNum(hz_1028))) * 0.9));
Call(S_13, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_18, V.Undef, ((V)((x_1099 - (3D * k_1101)))))).S(" ").V(Call(r2_18, V.Undef, y_1100)).S("q").V(Call(r2_18, V.Undef, ((V)((1D * k_1101))))).S(" ").V(Call(r2_18, V.Undef, ((V)(((-6D) * k_1101))))).S(" ").V(Call(r2_18, V.Undef, ((V)((2D * k_1101))))).S(" ").V(Call(r2_18, V.Undef, ((V)(((-8D) * k_1101))))).S("q").V(Call(r2_18, V.Undef, ((V)((0.5 * k_1101))))).S(" ").V(Call(r2_18, V.Undef, ((V)((5D * k_1101))))).S(" ").V(Call(r2_18, V.Undef, ((V)((1.6 * k_1101))))).S(" ").V(Call(r2_18, V.Undef, ((V)((8D * k_1101))))).S("q").V(Call(r2_18, V.Undef, ((V)((1D * k_1101))))).S(" ").V(Call(r2_18, V.Undef, ((V)(((-5D) * k_1101))))).S(" ").V(Call(r2_18, V.Undef, ((V)((3D * k_1101))))).S(" ").V(Call(r2_18, V.Undef, ((V)(((-7D) * k_1101))))).S("q").V(Call(r2_18, V.Undef, ((V)(((-0.6) * k_1101))))).S(" ").V(Call(r2_18, V.Undef, ((V)((5D * k_1101))))).S(" ").V(Call(r2_18, V.Undef, ((V)((0.4 * k_1101))))).S(" ").V(Call(r2_18, V.Undef, ((V)((7D * k_1101))))).S("Z").End()))).Put("fill", ((V)("#4f9a3e"))).V, tg_1032);
i_1097++;
}
}
if (!SEq(Get(o_1027, "flowers"), (false ? V.True : V.False))) {
{
double i_1102 = 0;
i_1102 = 0D;
while (true) {
if (!((i_1102 < Round((9D * kw_1029))))) break;
double x_1104 = 0;
V y_1105 = default;
double k_1106 = 0;
V c_1107 = default;
x_1104 = (ToNum(Call(rnd_1031, V.Undef)) * W_10);
y_1105 = Add(Add(hz_1028, ((V)(14D))), ((V)((ToNum(Call(rnd_1031, V.Undef)) * ((H_11 - ToNum(hz_1028)) - 30D)))));
k_1106 = (0.7 + (((ToNum(y_1105) - ToNum(hz_1028)) / (H_11 - ToNum(hz_1028))) * 0.8));
c_1107 = GetIdx(Arr(((V)("#ffd1e8")), ((V)("#fff3a8")), ((V)("#ffffff")), ((V)("#d9c8ff"))), (i_1102 % 4D));
{
double j_1108 = 0;
j_1108 = 0D;
while (true) {
if (!((j_1108 < 5D))) break;
Call(S_13, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_18, V.Undef, ((V)((x_1104 + ((FdLibm.Cos((j_1108 * 1.2566)) * 2.6) * k_1106)))))).Put("cy", Call(r2_18, V.Undef, Add(y_1105, ((V)(((FdLibm.Sin((j_1108 * 1.2566)) * 2.6) * k_1106)))))).Put("r", Call(r2_18, V.Undef, ((V)((1.9 * k_1106))))).Put("fill", c_1107).V, p_1026);
j_1108++;
}
}
Call(S_13, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_18, V.Undef, ((V)(x_1104)))).Put("cy", Call(r2_18, V.Undef, y_1105)).Put("r", Call(r2_18, V.Undef, ((V)((1.3 * k_1106))))).Put("fill", ((V)("#ffb84a"))).V, p_1026);
i_1102++;
}
}
}
return default;
}, 2, "", false));
Call(Fn((V _self1110, int _argc1111, V _a1113, V _a1114, V _a1115, V _a1116, V[] _rest1112) => {
V st_1117 = default;
if (_self1110.IsNullish) _self1110 = GlobalV;
if (Truthy(Invoke(G("document"), "getElementById", ((V)("yg-land-css"))))) {
return default;
}
st_1117 = Invoke(G("document"), "createElement", ((V)("style")));
Set(st_1117, "id", ((V)("yg-land-css")));
Set(st_1117, "textContent", ((V)(".yg-frame:not(.yg-port) .yg-top{gap:2cqh;padding:2.6cqh 3cqh}.yg-frame:not(.yg-port) .yg-back{width:10cqh;height:10cqh;font:700 8cqh/1 'Fredoka',sans-serif;box-shadow:0 0.8cqh 0 #c9b6f2;padding:0 0 1cqh}.yg-frame:not(.yg-port) .yg-ttl{font:700 5.2cqh/1.1 'Fredoka',sans-serif}.yg-frame:not(.yg-port) .yg-pills{gap:1.6cqh}.yg-frame:not(.yg-port) .yg-pill{min-width:11cqh;padding:1.4cqh 2.8cqh;font:700 4.4cqh/1 'Fredoka',sans-serif;box-shadow:0 0.8cqh 0 rgba(106,47,176,0.25)}.yg-frame:not(.yg-port) .yg-hint{left:4cqh;right:4cqh;bottom:3.5cqh;font:800 3.6cqh/1.25 'Nunito',sans-serif}.yg-frame:not(.yg-port) .yg-toast{font:700 6cqh/1 'Fredoka',sans-serif;-webkit-text-stroke:0.5cqh #4a1a73}.yg-frame:not(.yg-port) .yg-toast.yg-big{font-size:12cqh}.yg-frame:not(.yg-port) .yg-ov{padding:6cqh}.yg-frame:not(.yg-port) .yg-card{border-radius:7cqh;padding:6cqh 6cqh 5cqh;box-shadow:0 2cqh 0 #c9b6f2, 0 6cqh 16cqh rgba(40,10,80,0.3)}.yg-frame:not(.yg-port) .yg-ic{width:34cqh;height:24cqh;margin:-2cqh auto 1cqh}.yg-frame:not(.yg-port) .yg-card-t{font:700 8cqh/1.05 'Fredoka',sans-serif}.yg-frame:not(.yg-port) .yg-card-s{font:800 3.4cqh/1.3 'Nunito',sans-serif;margin-top:1cqh}.yg-frame:not(.yg-port) .yg-how{margin:4cqh 0 2cqh;padding:0 0 0 5cqh;font:700 3.9cqh/1.35 'Nunito',sans-serif}.yg-frame:not(.yg-port) .yg-how li{margin:1cqh 0}.yg-frame:not(.yg-port) .yg-opts{gap:2cqh;margin:2cqh 0 1cqh}.yg-frame:not(.yg-port) .yg-opt{border:0.6cqh solid #e0d2f7;padding:1.6cqh 3.4cqh;font:800 3.6cqh/1 'Nunito',sans-serif}.yg-frame:not(.yg-port) .yg-btn{padding:3.2cqh 7cqh;font:700 5.4cqh/1 'Fredoka',sans-serif;box-shadow:0 1.4cqh 0 #a8287a}.yg-frame:not(.yg-port) .yg-btn:active{transform:translateY(1cqh);box-shadow:0 0.4cqh 0 #a8287a}.yg-frame:not(.yg-port) .yg-ghost{box-shadow:0 1.4cqh 0 #c9b6f2}.yg-frame:not(.yg-port) .yg-go{margin-top:3cqh;padding:3.6cqh 14cqh;font-size:6.4cqh}.yg-frame:not(.yg-port) .yg-best{margin-top:3cqh;font:800 3.4cqh/1 'Nunito',sans-serif}.yg-frame:not(.yg-port) .yg-res-t{font:700 8.6cqh/1.05 'Fredoka',sans-serif}.yg-frame:not(.yg-port) .yg-stars{gap:2cqh;margin:2cqh 0 1cqh}.yg-frame:not(.yg-port) .yg-star{font-size:11cqh}.yg-frame:not(.yg-port) .yg-star.on{text-shadow:0 0.8cqh 0 #e09a14}.yg-frame:not(.yg-port) .yg-res-score{font:700 14cqh/1 'Fredoka',sans-serif}.yg-frame:not(.yg-port) .yg-res-sub{font:800 3.8cqh/1.3 'Nunito',sans-serif;margin-top:1cqh}.yg-frame:not(.yg-port) .yg-res-coins{margin:3cqh 0 4cqh;padding:1.6cqh 4cqh;font:800 3.6cqh/1 'Nunito',sans-serif}.yg-frame:not(.yg-port) .yg-row{gap:3cqh}.yg-frame:not(.yg-port) .yg-hubwrap{padding:0 0 4cqh}.yg-frame:not(.yg-port) .yg-hhead{padding:5cqh 5cqh 1cqh}.yg-frame:not(.yg-port) .yg-htitle{font:700 10cqh/1 'Fredoka',sans-serif;-webkit-text-stroke:1cqh #6a2fb0;text-shadow:0 1.2cqh 0 #6a2fb0}.yg-frame:not(.yg-port) .yg-hsub{margin-top:2cqh;font:800 3.6cqh/1.2 'Nunito',sans-serif}.yg-frame:not(.yg-port) .yg-mute{right:3cqh;top:3cqh;width:10cqh;height:10cqh;font-size:5cqh}.yg-frame:not(.yg-port) .yg-me{gap:3cqh;margin:2cqh 4cqh 0;padding:2cqh 4cqh 2cqh 2cqh;border-radius:6cqh;box-shadow:0 1.2cqh 0 rgba(80,140,60,0.35)}.yg-frame:not(.yg-port) .yg-me-st{width:28cqh;height:28cqh;border-radius:5cqh}.yg-frame:not(.yg-port) .yg-me-k{font:800 3.2cqh/1 'Nunito',sans-serif}.yg-frame:not(.yg-port) .yg-me-n{font:700 7.2cqh/1.1 'Fredoka',sans-serif;margin:1cqh 0}.yg-frame:not(.yg-port) .yg-me-h{font:700 3.4cqh/1.2 'Nunito',sans-serif}.yg-frame:not(.yg-port) .yg-strip{gap:2cqh;padding:3cqh 4cqh 3cqh}.yg-frame:not(.yg-port) .yg-pick{width:15cqh;height:15cqh;border:0.8cqh solid #ffffff;box-shadow:0 0.8cqh 0 rgba(60,110,40,0.35)}.yg-frame:not(.yg-port) .yg-pick.on{box-shadow:0 0 0 0.8cqh #ffffff, 0 1.2cqh 0 rgba(60,110,40,0.35)}.yg-frame:not(.yg-port) .yg-grid{gap:3.4cqh;padding:1cqh 4cqh 2cqh}.yg-frame:not(.yg-port) .yg-gcard{border-radius:6cqh;padding:2.6cqh 2.6cqh 3cqh;box-shadow:0 1.4cqh 0 color-mix(in srgb, var(--gc) 55%, #3b2457)}.yg-frame:not(.yg-port) .yg-gcard:active{transform:translateY(1cqh);box-shadow:0 0.4cqh 0 color-mix(in srgb, var(--gc) 55%, #3b2457)}.yg-frame:not(.yg-port) .yg-gic{height:22cqh;border-radius:4cqh}.yg-frame:not(.yg-port) .yg-gname{margin-top:2cqh;font:700 4.8cqh/1.05 'Fredoka',sans-serif}.yg-frame:not(.yg-port) .yg-gitem{margin-top:0.6cqh;font:800 2.9cqh/1.2 'Nunito',sans-serif}.yg-frame:not(.yg-port) .yg-gbest{top:3.6cqh;right:3.6cqh;padding:0.8cqh 2cqh;font:800 2.7cqh/1 'Nunito',sans-serif;box-shadow:0 0.4cqh 0 rgba(0,0,0,0.1)}.yg-frame:not(.yg-port) .yg-foot{margin:2cqh 6cqh 0;font:700 3cqh/1.35 'Nunito',sans-serif}.yg-frame:not(.yg-port) .yg-iback{left:3cqh;top:3cqh;width:10cqh;height:10cqh;font:700 8cqh/1 Fredoka,sans-serif;box-shadow:0 0.8cqh 0 rgba(40,10,80,0.35);padding:0 0 1cqh}.yg-frame:not(.yg-port) .yg-isheet{left:4cqh;right:4cqh;bottom:4cqh;border-radius:7cqh;padding:3.4cqh 5cqh 3.4cqh;box-shadow:0 1.6cqh 0 color-mix(in srgb,var(--gc) 60%,#3b2457),0 5cqh 14cqh rgba(30,8,60,0.35)}.yg-frame:not(.yg-port) .yg-ihead{gap:2.4cqh;font:800 3.1cqh/1 Nunito,sans-serif}.yg-frame:not(.yg-port) .yg-ihead::before,.yg-frame:not(.yg-port) .yg-ihead::after{height:0.5cqh;border-radius:1cqh}.yg-frame:not(.yg-port) .yg-isheet .yg-how{margin:2cqh 0 0.4cqh;font-size:3.4cqh}.yg-frame:not(.yg-port) .yg-isheet .yg-how li{margin:0.6cqh 0}.yg-frame:not(.yg-port) .yg-isheet .yg-opts{margin:1.4cqh 0 0.2cqh}.yg-frame:not(.yg-port) .yg-isheet .yg-go{margin-top:2cqh;padding:3cqh 13cqh;font-size:6cqh}.yg-frame:not(.yg-port) .yg-isheet .yg-best{margin-top:1.8cqh}.yg-frame:not(.yg-port){width:min(900px,calc(100vw - 24px),calc((100dvh - 24px) * 2.1667));aspect-ratio:780/360;container-type:size;border-radius:26px;}.yg-frame:not(.yg-port) .yg-isheet{left:auto;right:3cqh;top:3cqh;bottom:3cqh;width:43%;display:flex;flex-direction:column;justify-content:center;padding:3.4cqh 5cqh;border-radius:7cqh;}.yg-frame:not(.yg-port) .yg-isheet .yg-how{margin:2.4cqh 0 0.6cqh;font-size:3.7cqh;}.yg-frame:not(.yg-port) .yg-ov:not(.yg-intro){padding:4cqh;}.yg-frame:not(.yg-port) .yg-card{width:auto;min-width:46%;max-width:60%;padding:4.4cqh 7cqh 4cqh;}.yg-frame:not(.yg-port) .yg-hubwrap{display:grid;grid-template-columns:37% minmax(0,1fr);grid-template-rows:auto auto auto 1fr;overflow:hidden;padding:0;background:linear-gradient(180deg,#8fd0ff 0%,#bfe6ff 30%,#bfe6ff 32%,#a8dc8a 32.2%,#8fcf73 100%);}.yg-frame:not(.yg-port) .yg-hhead{grid-column:1;grid-row:1;padding:4.5cqh 4cqh 1cqh;}.yg-frame:not(.yg-port) .yg-htitle{font-size:9cqh;}.yg-frame:not(.yg-port) .yg-hsub{font-size:3.4cqh;margin-top:1.6cqh;}.yg-frame:not(.yg-port) .yg-mute{right:auto;left:3cqh;top:3cqh;width:9cqh;height:9cqh;font-size:4.4cqh;}.yg-frame:not(.yg-port) .yg-me{grid-column:1;grid-row:2;margin:1.6cqh 3cqh 0 4cqh;}.yg-frame:not(.yg-port) .yg-me-st{width:25cqh;height:25cqh;}.yg-frame:not(.yg-port) .yg-strip{grid-column:1;grid-row:3;padding:2.6cqh 3cqh 2cqh 4cqh;}.yg-frame:not(.yg-port) .yg-foot{grid-column:1;grid-row:4;align-self:end;margin:0 4cqh 3cqh;font-size:2.7cqh;}.yg-frame:not(.yg-port) .yg-grid{grid-column:2;grid-row:1 / 5;overflow-y:auto;align-content:start;grid-template-columns:repeat(3,minmax(0,1fr));gap:3cqh;padding:4cqh 4cqh 5cqh 1cqh;scrollbar-width:thin;}.yg-frame:not(.yg-port) .yg-gic{height:19cqh;}.yg-frame:not(.yg-port) .yg-hint{left:auto;right:3cqh;bottom:2.6cqh;max-width:44%;text-align:right;}")));
Invoke(Get(G("document"), "head"), "appendChild", st_1117);
return default;
}, 0, "cssL", false), V.Undef);
Call(Fn((V _self1118, int _argc1119, V _a1121, V _a1122, V _a1123, V _a1124, V[] _rest1120) => {
V st_1125 = default;
if (_self1118.IsNullish) _self1118 = GlobalV;
if (Truthy(Invoke(G("document"), "getElementById", ((V)("yg-v2-css"))))) {
return default;
}
st_1125 = Invoke(G("document"), "createElement", ((V)("style")));
Set(st_1125, "id", ((V)("yg-v2-css")));
Set(st_1125, "textContent", ((V)(JsStrBuf.Begin().S(".yg-ov.yg-show.yg-intro{display:block;padding:0;background:#24103e;}").S(".yg-iart{position:absolute;inset:0;}.yg-iart svg{width:100%;height:100%;display:block;}").S(".yg-iback{position:absolute;left:3cqw;top:3cqw;z-index:2;width:10cqw;height:10cqw;border-radius:50%;border:0;background:#ffffff;color:#6a2fb0;font:700 8cqw/1 Fredoka,sans-serif;box-shadow:0 0.8cqw 0 rgba(40,10,80,0.35);cursor:pointer;padding:0 0 1cqw;}").S(".yg-iback:focus-visible{outline:3px solid #ffffff;outline-offset:2px;}").S(".yg-isheet{position:absolute;left:4cqw;right:4cqw;bottom:4cqw;box-sizing:border-box;background:rgba(255,255,255,0.97);border-radius:7cqw;padding:3.4cqw 5cqw 3.4cqw;text-align:center;").S("box-shadow:0 1.6cqw 0 color-mix(in srgb,var(--gc) 60%,#3b2457),0 5cqw 14cqw rgba(30,8,60,0.35);animation:ygPop .35s cubic-bezier(.2,1.4,.4,1);}").S(".yg-ihead{display:flex;align-items:center;gap:2.4cqw;font:800 3.1cqw/1 Nunito,sans-serif;letter-spacing:0.12em;text-transform:uppercase;color:color-mix(in srgb,var(--gc) 50%,#3b2457);}").S(".yg-ihead::before,.yg-ihead::after{content:\"\";height:0.5cqw;flex:1;border-radius:1cqw;background:color-mix(in srgb,var(--gc) 40%,#ffffff);}").S(".yg-isheet .yg-how{margin:2cqw 0 0.4cqw;font-size:3.4cqw;line-height:1.25;}.yg-isheet .yg-how li{margin:0.6cqw 0;}").S(".yg-isheet .yg-opts{margin:1.4cqw 0 0.2cqw;}.yg-isheet .yg-go{margin-top:2cqw;padding:3cqw 13cqw;font-size:6cqw;}.yg-isheet .yg-best{margin-top:1.8cqw;}").S(".yg-introing .yg-top,.yg-introing .yg-hint{visibility:hidden;}").End())));
Invoke(Get(G("document"), "head"), "appendChild", st_1125);
return default;
}, 0, "css", false), V.Undef);
pid_32 = 0D;
Set(YG_12, "SETS", Arr(((V)("snack")), ((V)("fruit")), ((V)("pet"))));
thumb_36 = Fn((V _self1, int _argc1126, V c_1132, V _a1129, V _a1130, V _a1131, V[] _rest1127) => {
V R_1133 = default;
V s_1134 = default;
R_1133 = Get(G("window"), "SquishSquad");
s_1134 = Invoke(R_1133, "src", Get(c_1132, "id"));
return ((Get(G("window"), "SQ_THUMBS") is var _t1135 && !Truthy(_t1135) ? _t1135 : GetK(Get(G("window"), "SQ_THUMBS"), s_1134)) is var _t1136 && Truthy(_t1136) ? _t1136 : s_1134);
return default;
}, 1, "", true);
Set(YG_12, "mount", Fn((V _self1137, int _argc1138, V el_1144, V _a1141, V _a1142, V _a1143, V[] _rest1139) => {
V root_1145 = default;
V app_1146 = default;
V stop_1147 = default;
V hubC_1148 = default;
V frame_1149 = default;
V hubEl_1150 = default;
V drawHub_1151 = default;
if (_self1137.IsNullish) _self1137 = GlobalV;
drawHub_1151 = Fn((V _self1152, int _argc1153, V _a1155, V _a1156, V _a1157, V _a1158, V[] _rest1154) => {
V pc_1159 = default;
V head_1160 = default;
V mute_1161 = default;
V me_1162 = default;
V meSt_1163 = default;
V meTx_1164 = default;
V strip_1165 = default;
V grid_1166 = default;
if (_self1152.IsNullish) _self1152 = GlobalV;
if (Truthy(hubC_1148)) {
Invoke(hubC_1148, "destroy");
hubC_1148 = V.Null;
}
Set(hubEl_1150, "innerHTML", ((V)("")));
pc_1159 = Call(playerC_35, V.Undef);
head_1160 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-hhead"))).V, hubEl_1150);
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-htitle"))).V, head_1160, ((V)("Yard Games")));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-hsub"))).V, head_1160, ((V)("Play with the games in your backyard")));
mute_1161 = Call(D_14, V.Undef, ((V)("button")), NewObj(3).Put("cls", ((V)("yg-mute"))).Put("aria-label", ((V)("Sound on or off"))).Put("onclick", Fn((V _self1152, int _argc1167, V _a1169, V _a1170, V _a1171, V _a1172, V[] _rest1168) => {
muted_26 = (!(Truthy(muted_26)) ? V.True : V.False);
try {
Invoke(G("localStorage"), "setItem", ((V)(JsStrBuf.Begin().V(LS_22).S(".mute").End())), ((V)((Truthy(muted_26) ? "1" : "0"))));
} catch (System.Exception _ex1173) {
V e_1174 = default;
e_1174 = Caught(_ex1173);

}
Set(mute_1161, "textContent", ((V)((Truthy(muted_26) ? "\ud83d\udd07" : "\ud83d\udd0a"))));
return default;
}, 0, "onclick", true)).V, head_1160, ((V)((Truthy(muted_26) ? "\ud83d\udd07" : "\ud83d\udd0a"))));
me_1162 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-me"))).V, hubEl_1150);
meSt_1163 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-me-st"))).V, me_1162);
meTx_1164 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-me-tx"))).V, me_1162);
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-me-k"))).V, meTx_1164, ((V)("Your player")));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-me-n"))).V, meTx_1164, (Truthy(pc_1159) ? Get(pc_1159, "name") : ((V)("\u2026"))));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-me-h"))).V, meTx_1164, ((V)("Pick anyone below")));
if (Truthy(pc_1159)) {
hubC_1148 = Invoke(YG_12, "creature", meSt_1163, Get(pc_1159, "key"), NewObj(4).Put("x", ((V)((W_10 / 2D)))).Put("y", ((V)((H_11 * 0.92)))).Put("size", ((V)((H_11 * 0.95)))).Put("shadow", ((V)(1D))).V);
OpSet(Get(Get(hubC_1148, "host"), "style"), "cssText", 0, ((V)(";left:0;top:0;width:100%;height:100%;")));
Invoke(hubC_1148, "play", ((V)("happy")));
Call(G("setTimeout"), V.Undef, Fn((V _self1152, int _argc1182, V _a1184, V _a1185, V _a1186, V _a1187, V[] _rest1183) => {
return (hubC_1148 is var _t1188 && !Truthy(_t1188) ? _t1188 : Invoke(hubC_1148, "play", ((V)("idle"))));
}, 0, "", true), ((V)(2400D)));
}
strip_1165 = Call(D_14, V.Undef, ((V)("div")), NewObj(2).Put("cls", ((V)("yg-strip"))).Put("role", ((V)("list"))).V, hubEl_1150);
Invoke(Call(roster_34, V.Undef), "forEach", Fn((V _self1152, int _argc1189, V c_1195, V _a1192, V _a1193, V _a1194, V[] _rest1190) => {
V b_1196 = default;
b_1196 = Call(D_14, V.Undef, ((V)("button")), NewObj(5).Put("cls", ((V)(string.Concat("yg-pick", (Truthy((pc_1159 is var _t1197 && !Truthy(_t1197) ? _t1197 : (SEq(Get(c_1195, "id"), Get(pc_1159, "id")) ? V.True : V.False))) ? " on" : ""))))).Put("aria-label", Get(c_1195, "name")).Put("title", Get(c_1195, "name")).Put("role", ((V)("listitem"))).Put("onclick", Fn((V _self1152, int _argc1198, V _a1200, V _a1201, V _a1202, V _a1203, V[] _rest1199) => {
Set(SAVE_23, "player", Get(c_1195, "id"));
Call(save_24, V.Undef);
Invoke(SFX_30, "pop");
Call(drawHub_1151, V.Undef);
return default;
}, 0, "onclick", true)).V, strip_1165);
Call(D_14, V.Undef, ((V)("img")), NewObj(3).Put("src", Call(thumb_36, V.Undef, c_1195)).Put("alt", ((V)(""))).Put("loading", ((V)("lazy"))).V, b_1196);
return default;
}, 1, "", true));
Call(G("setTimeout"), V.Undef, Fn((V _self1152, int _argc1211, V _a1213, V _a1214, V _a1215, V _a1216, V[] _rest1212) => {
V on_1210 = default;
on_1210 = Invoke(strip_1165, "querySelector", ((V)(".on")));
if (Truthy(on_1210)) {
Set(strip_1165, "scrollLeft", ((V)(((ToNum(Get(on_1210, "offsetLeft")) - (ToNum(Get(strip_1165, "clientWidth")) / 2D)) + (ToNum(Get(on_1210, "offsetWidth")) / 2D)))));
}
return default;
}, 0, "", true), ((V)(30D)));
grid_1166 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-grid"))).V, hubEl_1150);
Invoke(Get(YG_12, "GAMES"), "forEach", Fn((V _self1152, int _argc1217, V G_1223, V _a1220, V _a1221, V _a1222, V[] _rest1218) => {
V b_1224 = default;
V ic_1225 = default;
b_1224 = Call(D_14, V.Undef, ((V)("button")), NewObj(3).Put("cls", ((V)("yg-gcard"))).Put("style", ((V)(JsStrBuf.Begin().S("--gc:").V((Get(G_1223, "color") is var _t1226 && Truthy(_t1226) ? _t1226 : ((V)("#ff8a3d")))).End()))).Put("onclick", Fn((V _self1152, int _argc1227, V _a1229, V _a1230, V _a1231, V _a1232, V[] _rest1228) => {
Invoke(SFX_30, "pop");
Invoke(app_1146, "play", G_1223);
return default;
}, 0, "onclick", true)).V, grid_1166);
ic_1225 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-gic"))).V, b_1224);
Set(ic_1225, "innerHTML", (Get(G_1223, "icon") is var _t1233 && Truthy(_t1233) ? _t1233 : ((V)(""))));
if (Truthy((Get(ic_1225, "firstChild") is var _t1234 && !Truthy(_t1234) ? _t1234 : Get(Get(ic_1225, "firstChild"), "setAttribute")))) {
Invoke(Get(ic_1225, "firstChild"), "setAttribute", ((V)("preserveAspectRatio")), ((V)("xMidYMid slice")));
}
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-gname"))).V, b_1224, Get(G_1223, "name"));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-gitem"))).V, b_1224, Get(G_1223, "item"));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-gbest"))).V, b_1224, ((V)((Truthy(GetK(Get(SAVE_23, "best"), Get(G_1223, "id"))) ? JsStrBuf.Begin().S("\u2605 Best ").V(GetK(Get(SAVE_23, "best"), Get(G_1223, "id"))).End() : "New!"))));
return default;
}, 1, "", true));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-foot"))).V, hubEl_1150, ((V)("Examples of the backyard mini games. Coins are shown as a preview and not added to your wallet.")));
return default;
}, 0, "drawHub", false);
Set(el_1144, "innerHTML", ((V)("")));
root_1145 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-root"))).V, el_1144);
app_1146 = NewObj(1).Put("root", root_1145).V;
stop_1147 = V.Null;
hubC_1148 = V.Null;
frame_1149 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-frame"))).V, root_1145);
Set(app_1146, "frame", frame_1149);
Set(app_1146, "stage", Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-stage"))).V, frame_1149));
hubEl_1150 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-hubwrap"))).V, frame_1149);
Set(app_1146, "hub", Fn((V _self1137, int _argc1235, V _a1237, V _a1238, V _a1239, V _a1240, V[] _rest1236) => {
if (Truthy(stop_1147)) {
Call(stop_1147, V.Undef);
stop_1147 = V.Null;
}
W_10 = 780D;
H_11 = 360D;
Set(YG_12, "W", ((V)(W_10)));
Set(YG_12, "H", ((V)(H_11)));
Invoke(Get(frame_1149, "classList"), "remove", ((V)("yg-port")));
Set(Get(app_1146, "stage"), "innerHTML", ((V)("")));
Set(Get(Get(app_1146, "stage"), "style"), "display", ((V)("none")));
Set(Get(hubEl_1150, "style"), "display", ((V)("")));
Call(drawHub_1151, V.Undef);
return default;
}, 0, "", true));
Set(app_1146, "play", Fn((V _self1137, int _argc1241, V G_1247, V _a1244, V _a1245, V _a1246, V[] _rest1242) => {
if (Truthy(stop_1147)) {
Call(stop_1147, V.Undef);
stop_1147 = V.Null;
}
if (Truthy(hubC_1148)) {
Invoke(hubC_1148, "destroy");
hubC_1148 = V.Null;
}
Invoke(Get(frame_1149, "classList"), "toggle", ((V)("yg-port")), (!(Truthy(Get(G_1247, "land"))) ? V.True : V.False));
Set(Get(hubEl_1150, "style"), "display", ((V)("none")));
Set(Get(Get(app_1146, "stage"), "style"), "display", ((V)("")));
stop_1147 = Call(run_33, V.Undef, app_1146, G_1247);
return default;
}, 1, "", true));
Set(YG_12, "_hub", Fn((V _self1137, int _argc1248, V _a1250, V _a1251, V _a1252, V _a1253, V[] _rest1249) => {
if (!(Truthy(stop_1147))) {
Call(drawHub_1151, V.Undef);
}
return default;
}, 0, "", true));
Set(YG_12, "_app", app_1146);
Invoke(app_1146, "hub");
return app_1146;
return default;
}, 1, "", false));
return default;
}, 0, "", false), V.Undef);
        }
    }
}
