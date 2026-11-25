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
st_146 = (Truthy(Get(G_98, "stars")) ? Get(Invoke(Get(G_98, "stars"), "filter", Fn((V _arrowThis159, int _argc152, V v_158, V _a155, V _a156, V _a157, V[] _rest153) => {
return (Ge(score_119, v_158) ? V.True : V.False);
}, 1, "", true)), "length") : ((V)(0D)));
if (Truthy((nb_145 is var _t160 && Truthy(_t160) ? _t160 : (GeN(st_146, 2D) ? V.True : V.False)))) {
Invoke(SFX_30, "win");
}
Set(ov_108, "innerHTML", ((V)("")));
Set(ov_108, "className", ((V)("yg-ov yg-show")));
card_147 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-card yg-res"))).V, ov_108);
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-res-t"))).V, card_147, (Get(extra_143, "title") is var _t161 && Truthy(_t161) ? _t161 : ((V)((GeN(st_146, 3D) ? "Amazing!" : (SEqN(st_146, 2D) ? "Great job!" : (SEqN(st_146, 1D) ? "Nice!" : "Good try!")))))));
sr_148 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-stars"))).V, card_147);
{
double i_162 = 0;
i_162 = 0D;
while (true) {
if (!((i_162 < 3D))) break;
Call(D_14, V.Undef, ((V)("span")), NewObj(2).Put("cls", ((V)(string.Concat("yg-star", (Lt(((V)(i_162)), st_146) ? " on" : ""))))).Put("style", ((V)(JsStrBuf.Begin().S("animation-delay:").N(((i_162 * 0.15) + 0.1)).S("s").End()))).V, sr_148, ((V)("\u2605")));
i_162++;
}
}
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-res-score"))).V, card_147, ((V)(ToStrS(score_119))));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-res-sub"))).V, card_147, ((V)(string.Concat((Truthy(Get(extra_143, "sub")) ? JsStrBuf.Begin().V(Get(extra_143, "sub")).S(" \u00b7 ").End() : ""), (Truthy(nb_145) ? "New best!" : JsStrBuf.Begin().S("Best ").V(best_144).End())))));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-res-coins"))).V, card_147, ((V)(JsStrBuf.Begin().S("+").N(Max(1D, Round((ToNum(score_119) * ToNum((Get(G_98, "coinK") is var _t164 && Truthy(_t164) ? _t164 : ((V)(1D)))))))).S(" coins (preview)").End())));
row_149 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-row"))).V, card_147);
Call(D_14, V.Undef, ((V)("button")), NewObj(2).Put("cls", ((V)("yg-btn yg-ghost"))).Put("onclick", Fn((V _arrowThis171, int _argc165, V _a167, V _a168, V _a169, V _a170, V[] _rest166) => {
return Invoke(app_97, "hub");
}, 0, "onclick", true)).V, row_149, ((V)((Truthy(Get(G("window"), "SquishApp")) ? "Yard games" : "Yard"))));
Call(D_14, V.Undef, ((V)("button")), NewObj(2).Put("cls", ((V)("yg-btn"))).Put("onclick", Fn((V _arrowThis178, int _argc172, V _a174, V _a175, V _a176, V _a177, V[] _rest173) => {
return Invoke(app_97, "play", G_98);
}, 0, "onclick", true)).V, row_149, ((V)("Play again")));
if (Truthy((Get(G("window"), "SquishApp") is var _t179 && !Truthy(_t179) ? _t179 : Get(Get(G("window"), "SquishApp"), "yardPopup")))) {
try {
Invoke(Get(G("window"), "SquishApp"), "yardPopup", card_147, ((V)("result")), st_146);
} catch (System.Exception _ex180) {
V e_181 = default;
e_181 = Caught(_ex180);
Invoke(G("console"), "warn", ((V)("[yard popup]")), e_181);
}
}
if (Truthy((inst_123 is var _t182 && !Truthy(_t182) ? _t182 : Get(inst_123, "celebrate")))) {
try {
Invoke(inst_123, "celebrate", st_146);
} catch (System.Exception _ex183) {
V e_184 = default;
e_184 = Caught(_ex183);

}
}
return default;
}, 1, "results", false);
opts_129 = Fn((V _self185, int _argc186, V card_192, V _a189, V _a190, V _a191, V[] _rest187) => {
V op_193 = default;
if (_self185.IsNullish) _self185 = GlobalV;
if (!(Truthy(Get(G_98, "options")))) {
return default;
}
op_193 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-opts"))).V, card_192);
Invoke(Get(G_98, "options"), "forEach", Fn((V _arrowThis201, int _argc194, V o2_200, V _a197, V _a198, V _a199, V[] _rest195) => {
V b_202 = default;
b_202 = Call(D_14, V.Undef, ((V)("button")), NewObj(2).Put("cls", ((V)(string.Concat("yg-opt", ((SEq(Get(G_98, "_opt"), Get(o2_200, "id")) || (!(Truthy(Get(G_98, "_opt"))) && SEq(o2_200, GetIdx(Get(G_98, "options"), 0D)))) ? " on" : ""))))).Put("onclick", Fn((V _arrowThis209, int _argc203, V _a205, V _a206, V _a207, V _a208, V[] _rest204) => {
Set(G_98, "_opt", Get(o2_200, "id"));
Invoke(new ArrBuilder().Spread(Get(op_193, "children")).V, "forEach", Fn((V _arrowThis217, int _argc210, V x_216, V _a213, V _a214, V _a215, V[] _rest211) => {
return Invoke(Get(x_216, "classList"), "remove", ((V)("on")));
}, 1, "", true));
Invoke(Get(b_202, "classList"), "add", ((V)("on")));
if (Truthy((inst_123 is var _t218 && !Truthy(_t218) ? _t218 : Get(inst_123, "option")))) {
Invoke(inst_123, "option", Get(o2_200, "id"));
}
return default;
}, 0, "onclick", true)).V, op_193, Get(o2_200, "label"));
return default;
}, 1, "", true));
return default;
}, 1, "opts", false);
intro_130 = Fn((V _self219, int _argc220, V _a222, V _a223, V _a224, V _a225, V[] _rest221) => {
V PO_226 = default;
V art_227 = default;
V card_228 = default;
V ic_229 = default;
V ul_230 = default;
if (_self219.IsNullish) _self219 = GlobalV;
Set(ov_108, "innerHTML", ((V)("")));
PO_226 = (Get(YG_12, "POSTER") is var _t231 && !Truthy(_t231) ? _t231 : GetK(Get(YG_12, "POSTER"), Get(G_98, "id")));
art_227 = ((V)(""));
if (Truthy(PO_226)) {
try {
art_227 = Call(PO_226, V.Undef, ((V)(JsStrBuf.Begin().S("ygp").N(++pid_32).S("_").End())), NewObj(2).Put("src", Call(thumb_36, V.Undef, pl_100)).Put("name", Get(pl_100, "name")).V);
} catch (System.Exception _ex232) {
V e_233 = default;
e_233 = Caught(_ex232);
Invoke(G("console"), "warn", ((V)("YardGames poster")), Get(G_98, "id"), e_233);
}
}
if (Truthy(art_227)) {
V artEl_234 = default;
V sh_235 = default;
V ul_236 = default;
Set(ov_108, "className", ((V)("yg-ov yg-show yg-intro")));
Invoke(Get(ov_108, "style"), "setProperty", ((V)("--gc")), (Get(G_98, "color") is var _t237 && Truthy(_t237) ? _t237 : ((V)("#ff8a3d"))));
Invoke(Get(Get(app_97, "root"), "classList"), "add", ((V)("yg-introing")));
artEl_234 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-iart"))).V, ov_108);
Set(artEl_234, "innerHTML", art_227);
if (Truthy(Get(YG_12, "posterRig"))) {
try {
Invoke(YG_12, "posterRig", artEl_234, Get(pl_100, "key"), NewObj(1).Put("opp", (inst_123 is var _t238 && !Truthy(_t238) ? _t238 : Get(inst_123, "oppKey"))).V);
} catch (System.Exception _ex239) {
V e_240 = default;
e_240 = Caught(_ex239);
Invoke(G("console"), "warn", ((V)("YardGames poster rig")), e_240);
}
}
Call(D_14, V.Undef, ((V)("button")), NewObj(3).Put("cls", ((V)("yg-iback"))).Put("aria-label", ((V)("Back to the yard"))).Put("onclick", Fn((V _arrowThis247, int _argc241, V _a243, V _a244, V _a245, V _a246, V[] _rest242) => {
return Invoke(app_97, "hub");
}, 0, "onclick", true)).V, ov_108, ((V)("\u2039")));
sh_235 = Call(D_14, V.Undef, ((V)("div")), NewObj(3).Put("cls", ((V)("yg-isheet"))).Put("role", ((V)("dialog"))).Put("aria-label", Get(G_98, "name")).V, ov_108);
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-ihead"))).V, sh_235, ((V)("How to play")));
ul_236 = Call(D_14, V.Undef, ((V)("ul")), NewObj(1).Put("cls", ((V)("yg-how"))).V, sh_235);
Invoke((Get(G_98, "how") is var _t256 && Truthy(_t256) ? _t256 : Arr()), "forEach", Fn((V _arrowThis255, int _argc248, V t_254, V _a251, V _a252, V _a253, V[] _rest249) => {
return Call(D_14, V.Undef, ((V)("li")), NewObj(0).V, ul_236, t_254);
}, 1, "", true));
Call(opts_129, V.Undef, sh_235);
Call(D_14, V.Undef, ((V)("button")), NewObj(2).Put("cls", ((V)("yg-btn yg-go"))).Put("onclick", Fn((V _arrowThis263, int _argc257, V _a259, V _a260, V _a261, V _a262, V[] _rest258) => {
Call(ac_27, V.Undef);
Set(ov_108, "className", ((V)("yg-ov")));
Invoke(Get(Get(app_97, "root"), "classList"), "remove", ((V)("yg-introing")));
Call(start_131, V.Undef);
return default;
}, 0, "onclick", true)).V, sh_235, ((V)("Play")));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-best"))).V, sh_235, ((V)((Truthy(GetK(Get(SAVE_23, "best"), Get(G_98, "id"))) ? JsStrBuf.Begin().S("Best ").V(GetK(Get(SAVE_23, "best"), Get(G_98, "id"))).End() : "No best yet"))));
if (Truthy((Get(G("window"), "SquishApp") is var _t264 && !Truthy(_t264) ? _t264 : Get(Get(G("window"), "SquishApp"), "yardPopup")))) {
try {
Invoke(Get(G("window"), "SquishApp"), "yardPopup", sh_235, ((V)("intro")));
} catch (System.Exception _ex265) {
V e_266 = default;
e_266 = Caught(_ex265);
Invoke(G("console"), "warn", ((V)("[yard popup]")), e_266);
}
}
return default;
}
Set(ov_108, "className", ((V)("yg-ov yg-show")));
card_228 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-card"))).V, ov_108);
ic_229 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-ic"))).V, card_228);
Set(ic_229, "innerHTML", (Get(G_98, "icon") is var _t267 && Truthy(_t267) ? _t267 : ((V)(""))));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-card-t"))).V, card_228, Get(G_98, "name"));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-card-s"))).V, card_228, ((V)(JsStrBuf.Begin().S("Yard: ").V(Get(G_98, "item")).End())));
ul_230 = Call(D_14, V.Undef, ((V)("ul")), NewObj(1).Put("cls", ((V)("yg-how"))).V, card_228);
Invoke((Get(G_98, "how") is var _t276 && Truthy(_t276) ? _t276 : Arr()), "forEach", Fn((V _arrowThis275, int _argc268, V t_274, V _a271, V _a272, V _a273, V[] _rest269) => {
return Call(D_14, V.Undef, ((V)("li")), NewObj(0).V, ul_230, t_274);
}, 1, "", true));
Call(opts_129, V.Undef, card_228);
Call(D_14, V.Undef, ((V)("button")), NewObj(2).Put("cls", ((V)("yg-btn yg-go"))).Put("onclick", Fn((V _arrowThis283, int _argc277, V _a279, V _a280, V _a281, V _a282, V[] _rest278) => {
Call(ac_27, V.Undef);
Set(ov_108, "className", ((V)("yg-ov")));
Call(start_131, V.Undef);
return default;
}, 0, "onclick", true)).V, card_228, ((V)("Play")));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-best"))).V, card_228, ((V)((Truthy(GetK(Get(SAVE_23, "best"), Get(G_98, "id"))) ? JsStrBuf.Begin().S("Best ").V(GetK(Get(SAVE_23, "best"), Get(G_98, "id"))).End() : "No best yet"))));
return default;
}, 0, "intro", false);
start_131 = Fn((V _self284, int _argc285, V _a287, V _a288, V _a289, V _a290, V[] _rest286) => {
if (_self284.IsNullish) _self284 = GlobalV;
playing_118 = (true ? V.True : V.False);
ended_126 = (false ? V.True : V.False);
score_119 = ((V)(0D));
Set(scP_113, "textContent", ((V)("0")));
left_120 = (Get(G_98, "dur") is var _t291 && Truthy(_t291) ? _t291 : ((V)(0D)));
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
hint_115 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-hint"))).V, hud_106, (Get(G_98, "hint") is var _t292 && Truthy(_t292) ? _t292 : ((V)(""))));
toastL_116 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-toasts"))).V, stageWrap_101);
alive_117 = (true ? V.True : V.False);
playing_118 = (false ? V.True : V.False);
score_119 = ((V)(0D));
left_120 = (Get(G_98, "dur") is var _t293 && Truthy(_t293) ? _t293 : ((V)(0D)));
raf_121 = ((V)(0D));
last_122 = ((V)(0D));
inst_123 = V.Null;
parts_124 = Arr();
creatures_125 = Arr();
ended_126 = (false ? V.True : V.False);
ctx_127 = NewObj(27).Put("W", ((V)(W_10))).Put("H", ((V)(H_11))).Put("bg", bg_103).Put("fg", fg_105).Put("crl", crL_104).Put("G", G_98).Put("S", S_13).Put("D", D_14).Put("YG", YG_12).Put("SFX", SFX_30).Put("playerKey", Get(pl_100, "key")).Put("playerName", Get(pl_100, "name")).Put("creature", Fn((V _self294, int _argc295, V key_301, V o_302, V _a299, V _a300, V[] _rest296) => {
V c_303 = default;
if (_self294.IsNullish) _self294 = GlobalV;
c_303 = Invoke(YG_12, "creature", crL_104, key_301, o_302);
Invoke(creatures_125, "push", c_303);
return c_303;
return default;
}, 2, "creature", false)).Put("opponent", Fn((V _self304, int _argc305, V n_311, V _a308, V _a309, V _a310, V[] _rest306) => {
V pool_312 = default;
V @out_313 = default;
if (_self304.IsNullish) _self304 = GlobalV;
pool_312 = Invoke(Invoke(Call(roster_34, V.Undef), "map", Fn((V _arrowThis330, int _argc323, V c_329, V _a326, V _a327, V _a328, V[] _rest324) => {
return Get(c_329, "key");
}, 1, "", true)), "filter", Fn((V _arrowThis321, int _argc314, V k_320, V _a317, V _a318, V _a319, V[] _rest315) => {
return (k_320 is var _t322 && !Truthy(_t322) ? _t322 : (!SEq(k_320, Get(pl_100, "key")) ? V.True : V.False));
}, 1, "", true));
@out_313 = Arr();
while (Truthy(((Lt(Get(@out_313, "length"), (n_311 is var _t331 && Truthy(_t331) ? _t331 : ((V)(1D)))) ? V.True : V.False) is var _t332 && !Truthy(_t332) ? _t332 : Get(pool_312, "length")))) {
Invoke(@out_313, "push", GetIdx(Invoke(pool_312, "splice", ((V)(System.Math.Floor((ToNum(Invoke(G("Math"), "random")) * ToNum(Get(pool_312, "length")))))), ((V)(1D))), 0D));
}
return (Truthy(n_311) ? @out_313 : GetIdx(@out_313, 0D));
return default;
}, 1, "opponent", false)).Put("nameOf", Fn((V _self333, int _argc334, V key_340, V _a337, V _a338, V _a339, V[] _rest335) => {
V c_341 = default;
if (_self333.IsNullish) _self333 = GlobalV;
c_341 = (R_99 is var _t351 && !Truthy(_t351) ? _t351 : Invoke(Get(R_99, "ROSTER"), "find", Fn((V _arrowThis349, int _argc342, V x_348, V _a345, V _a346, V _a347, V[] _rest343) => {
return (x_348 is var _t350 && !Truthy(_t350) ? _t350 : (SEq(Get(x_348, "key"), key_340) ? V.True : V.False));
}, 1, "", true)));
return (Truthy(c_341) ? Get(c_341, "name") : key_340);
return default;
}, 1, "nameOf", false)).Getter("score", Fn((V _self352, int _argc353, V _a355, V _a356, V _a357, V _a358, V[] _rest354) => {
if (_self352.IsNullish) _self352 = GlobalV;
return score_119;
return default;
}, 0, "score", false)).Put("add", Fn((V _self359, int _argc360, V n_366, V x_367, V y_368, V txt_369, V[] _rest361) => {
V col_370 = default;
if (_self359.IsNullish) _self359 = GlobalV;
col_370 = (_argc360 > 4 ? _rest361[0] : V.Undef);
score_119 = ((V)(Max(0D, ToNum(Add(score_119, n_366)))));
Set(scP_113, "textContent", score_119);
Invoke(Get(scP_113, "classList"), "remove", ((V)("yg-bump")));
_ = Get(scP_113, "offsetWidth");
Invoke(Get(scP_113, "classList"), "add", ((V)("yg-bump")));
if (Truthy(txt_369)) {
Invoke(ctx_127, "toast", txt_369, x_367, y_368, col_370);
}
return default;
}, 5, "add", false)).Put("setScore", Fn((V _self371, int _argc372, V n_378, V _a375, V _a376, V _a377, V[] _rest373) => {
if (_self371.IsNullish) _self371 = GlobalV;
score_119 = n_378;
Set(scP_113, "textContent", score_119);
return default;
}, 1, "setScore", false)).Put("addTime", Fn((V _self379, int _argc380, V s_386, V _a383, V _a384, V _a385, V[] _rest381) => {
if (_self379.IsNullish) _self379 = GlobalV;
if (Truthy((Get(G_98, "dur") is var _t387 && !Truthy(_t387) ? _t387 : playing_118))) {
left_120 = Add(left_120, s_386);
Invoke(Get(tmP_114, "classList"), "remove", ((V)("yg-hurry")));
}
return default;
}, 1, "addTime", false)).Put("timer", Fn((V _self388, int _argc389, V txt_395, V _a392, V _a393, V _a394, V[] _rest390) => {
if (_self388.IsNullish) _self388 = GlobalV;
Set(tmP_114, "textContent", txt_395);
Set(Get(tmP_114, "style"), "display", ((V)((Truthy(txt_395) ? "" : "none"))));
return default;
}, 1, "timer", false)).Put("hint", Fn((V _self396, int _argc397, V t_403, V _a400, V _a401, V _a402, V[] _rest398) => {
if (_self396.IsNullish) _self396 = GlobalV;
Set(hint_115, "textContent", (t_403 is var _t404 && Truthy(_t404) ? _t404 : ((V)(""))));
return default;
}, 1, "hint", false)).Getter("time", Fn((V _self405, int _argc406, V _a408, V _a409, V _a410, V _a411, V[] _rest407) => {
if (_self405.IsNullish) _self405 = GlobalV;
return left_120;
return default;
}, 0, "time", false)).Getter("playing", Fn((V _self412, int _argc413, V _a415, V _a416, V _a417, V _a418, V[] _rest414) => {
if (_self412.IsNullish) _self412 = GlobalV;
return playing_118;
return default;
}, 0, "playing", false)).Put("toast", Fn((V _self419, int _argc420, V txt_426, V x_427, V y_428, V col_429, V[] _rest421) => {
V e_431 = default;
V big_430 = default;
if (_self419.IsNullish) _self419 = GlobalV;
big_430 = (_argc420 > 4 ? _rest421[0] : V.Undef);
e_431 = Call(D_14, V.Undef, ((V)("div")), NewObj(2).Put("cls", ((V)(string.Concat("yg-toast", (Truthy(big_430) ? " yg-big" : ""))))).Put("style", ((V)(JsStrBuf.Begin().S("left:").V(Call(r2_18, V.Undef, ((V)(((ToNum((x_427.IsNullish ? ((V)((W_10 / 2D))) : x_427)) / W_10) * 100D))))).S("%;top:").V(Call(r2_18, V.Undef, ((V)(((ToNum((y_428.IsNullish ? ((V)((H_11 * 0.4))) : y_428)) / H_11) * 100D))))).S("%;color:").V((col_429 is var _t432 && Truthy(_t432) ? _t432 : ((V)("#ffffff")))).End()))).V, toastL_116, txt_426);
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis446, int _argc440, V _a442, V _a443, V _a444, V _a445, V[] _rest441) => {
return Invoke(e_431, "remove");
}, 0, "", true), ((V)((Truthy(big_430) ? 1400D : 1000D))));
return default;
}, 5, "toast", false)).Put("burst", Fn((V _self447, int _argc448, V x_454, V y_455, V kind_456, V n_457, V[] _rest449) => {
V o_458 = default;
if (_self447.IsNullish) _self447 = GlobalV;
o_458 = (_argc448 > 4 ? _rest449[0] : V.Undef);
o_458 = (o_458 is var _t459 && Truthy(_t459) ? _t459 : NewObj(0).V);
{
double i_460 = 0;
i_460 = 0D;
while (true) {
if (!(Lt(((V)(i_460)), (n_457 is var _t462 && Truthy(_t462) ? _t462 : ((V)(10D)))))) break;
V a_463 = default;
double v_464 = 0;
V col_465 = default;
V e_466 = default;
a_463 = Add((!Get(o_458, "dir").IsNullish ? Get(o_458, "dir") : ((V)(((-System.Math.PI) / 2D)))), ((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * ToNum((Get(o_458, "spread") is var _t467 && Truthy(_t467) ? _t467 : ((V)(TAU_9))))))));
v_464 = (ToNum((Get(o_458, "v") is var _t468 && Truthy(_t468) ? _t468 : ((V)(120D)))) * (0.5 + (ToNum(Invoke(G("Math"), "random")) * 0.7)));
col_465 = (Get(o_458, "col") is var _t469 && Truthy(_t469) ? _t469 : (SEqS(kind_456, "drop") ? ((V)("#8fd3ff")) : (SEqS(kind_456, "dust") ? ((V)("#d8c7a8")) : GetIdx(Arr(((V)("#ffd84a")), ((V)("#ff8fc8")), ((V)("#8fe0ff")), ((V)("#b6f07a")), ((V)("#ffffff"))), (i_460 % 5D)))));
e_466 = ((SEqS(kind_456, "star") || SEqS(kind_456, "spark")) ? Call(S_13, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)("M0-5L1.4-1.4L5 0L1.4 1.4L0 5L-1.4 1.4L-5 0L-1.4-1.4Z"))).Put("fill", col_465).V, (Get(o_458, "layer") is var _t470 && Truthy(_t470) ? _t470 : fg_105)) : (SEqS(kind_456, "confetti") ? Call(S_13, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-2.5)))).Put("y", ((V)((-1.5)))).Put("width", ((V)(5D))).Put("height", ((V)(3D))).Put("fill", col_465).V, (Get(o_458, "layer") is var _t471 && Truthy(_t471) ? _t471 : fg_105)) : Call(S_13, V.Undef, ((V)("circle")), NewObj(3).Put("r", ((V)((SEqS(kind_456, "dust") ? 4D : 2.6)))).Put("fill", col_465).Put("opacity", ((V)(0.9))).V, (Get(o_458, "layer") is var _t472 && Truthy(_t472) ? _t472 : fg_105))));
Invoke(parts_124, "push", NewObj(11).Put("e", e_466).Put("x", x_454).Put("y", y_455).Put("vx", ((V)((FdLibm.Cos(ToNum(a_463)) * v_464)))).Put("vy", ((V)((FdLibm.Sin(ToNum(a_463)) * v_464)))).Put("g", (!Get(o_458, "g").IsNullish ? Get(o_458, "g") : ((V)((SEqS(kind_456, "dust") ? (-20D) : 260D))))).Put("life", ((V)((ToNum((Get(o_458, "life") is var _t473 && Truthy(_t473) ? _t473 : ((V)(0.8)))) * (0.7 + (ToNum(Invoke(G("Math"), "random")) * 0.5)))))).Put("t", ((V)(0D))).Put("rot", ((V)((ToNum(Invoke(G("Math"), "random")) * 360D)))).Put("vr", ((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 600D)))).Put("k", (Get(o_458, "k") is var _t474 && Truthy(_t474) ? _t474 : ((V)((SEqS(kind_456, "dust") ? 1.8 : 1D))))).V);
i_460++;
}
}
return default;
}, 5, "burst", false)).Put("finish", Fn((V _self475, int _argc476, V extra_482, V _a479, V _a480, V _a481, V[] _rest477) => {
if (_self475.IsNullish) _self475 = GlobalV;
if (Truthy(ended_126)) {
return default;
}
ended_126 = (true ? V.True : V.False);
playing_118 = (false ? V.True : V.False);
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis498, int _argc492, V _a494, V _a495, V _a496, V _a497, V[] _rest493) => {
return Call(results_128, V.Undef, (extra_482 is var _t499 && Truthy(_t499) ? _t499 : NewObj(0).V));
}, 0, "", true), (Truthy((extra_482 is var _t500 && !Truthy(_t500) ? _t500 : (!Get(extra_482, "delay").IsNullish ? V.True : V.False))) ? Get(extra_482, "delay") : ((V)(700D))));
return default;
}, 1, "finish", false)).Put("on", Fn((V _arrowThis509, int _argc501, V ev_507, V fn_508, V _a505, V _a506, V[] _rest502) => {
return SetK(ctx_127, ((V)(JsStrBuf.Begin().S("_").V(ev_507).End())), fn_508);
}, 2, "on", true)).V;
loop_132 = Fn((V _arrowThis517, int _argc510, V t_516, V _a513, V _a514, V _a515, V[] _rest511) => {
double dt_518 = 0;
if (!(Truthy(alive_117))) {
return default;
}
dt_518 = Min(0.05, (Truthy(last_122) ? ((ToNum(t_516) - ToNum(last_122)) / 1000D) : 0.016));
last_122 = t_516;
if (Truthy((playing_118 is var _t519 && !Truthy(_t519) ? _t519 : Get(G_98, "dur")))) {
double pl0_520 = 0;
pl0_520 = System.Math.Ceiling(ToNum(left_120));
left_120 = ((V)(Max(0D, (ToNum(left_120) - dt_518))));
if ((((System.Math.Ceiling(ToNum(left_120)) != pl0_520) && LeN(left_120, 5D)) && GtN(left_120, 0D))) {
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
Invoke(inst_123, "update", ((V)(dt_518)), t_516);
} catch (System.Exception _ex521) {
V e_522 = default;
e_522 = Caught(_ex521);
if (!(Truthy(Get(loop_132, "err")))) {
Set(loop_132, "err", ((V)(1D)));
Invoke(G("console"), "error", ((V)("YardGames")), Get(G_98, "id"), e_522);
}
}
{
double i_523 = 0;
i_523 = (ToNum(Get(parts_124, "length")) - 1D);
while (true) {
if (!((i_523 >= 0D))) break;
V q_525 = default;
double u_526 = 0;
q_525 = GetIdx(parts_124, i_523);
OpSet(q_525, "t", 0, ((V)(dt_518)));
if (Ge(Get(q_525, "t"), Get(q_525, "life"))) {
Invoke(Get(q_525, "e"), "remove");
Invoke(parts_124, "splice", ((V)(i_523)), ((V)(1D)));
goto _cont524;
}
OpSet(q_525, "vy", 0, ((V)((ToNum(Get(q_525, "g")) * dt_518))));
OpSet(q_525, "x", 0, ((V)((ToNum(Get(q_525, "vx")) * dt_518))));
OpSet(q_525, "y", 0, ((V)((ToNum(Get(q_525, "vy")) * dt_518))));
OpSet(q_525, "rot", 0, ((V)((ToNum(Get(q_525, "vr")) * dt_518))));
u_526 = (ToNum(Get(q_525, "t")) / ToNum(Get(q_525, "life")));
Invoke(Get(q_525, "e"), "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_18, V.Undef, Get(q_525, "x"))).S(" ").V(Call(r2_18, V.Undef, Get(q_525, "y"))).S(") rotate(").N(Round(ToNum(Get(q_525, "rot")))).S(") scale(").V(Call(r2_18, V.Undef, ((V)(((1D - (u_526 * 0.5)) * ToNum(Get(q_525, "k"))))))).S(")").End())));
Invoke(Get(q_525, "e"), "setAttribute", ((V)("opacity")), Call(r2_18, V.Undef, ((V)((1D - (u_526 * u_526))))));
_cont524: ;
i_523--;
}
}
raf_121 = Call(G("requestAnimationFrame"), V.Undef, loop_132);
return default;
}, 1, "", true);
pt_133 = Fn((V _arrowThis534, int _argc527, V e_533, V _a530, V _a531, V _a532, V[] _rest528) => {
V r_535 = default;
r_535 = Invoke(inp_107, "getBoundingClientRect");
return NewObj(4).Put("x", ((V)((((ToNum(Get(e_533, "clientX")) - ToNum(Get(r_535, "left"))) / ToNum(Get(r_535, "width"))) * W_10)))).Put("y", ((V)((((ToNum(Get(e_533, "clientY")) - ToNum(Get(r_535, "top"))) / ToNum(Get(r_535, "height"))) * H_11)))).Put("t", Invoke(G("performance"), "now")).Put("id", Get(e_533, "pointerId")).V;
return default;
}, 1, "", true);
Invoke(inp_107, "addEventListener", ((V)("pointerdown")), Fn((V _arrowThis543, int _argc536, V e_542, V _a539, V _a540, V _a541, V[] _rest537) => {
if (!(Truthy(playing_118))) {
return default;
}
Invoke(e_542, "preventDefault");
try {
Invoke(inp_107, "setPointerCapture", Get(e_542, "pointerId"));
} catch (System.Exception _ex544) {
V x_545 = default;
x_545 = Caught(_ex544);

}
Call(ac_27, V.Undef);
if (Truthy(Get(inst_123, "down"))) {
Invoke(inst_123, "down", Call(pt_133, V.Undef, e_542));
}
return default;
}, 1, "", true));
Invoke(inp_107, "addEventListener", ((V)("pointermove")), Fn((V _arrowThis553, int _argc546, V e_552, V _a549, V _a550, V _a551, V[] _rest547) => {
if (!(Truthy(playing_118))) {
return default;
}
if (Truthy(Get(inst_123, "move"))) {
Invoke(inst_123, "move", Call(pt_133, V.Undef, e_552));
}
return default;
}, 1, "", true));
up_134 = Fn((V _arrowThis561, int _argc554, V e_560, V _a557, V _a558, V _a559, V[] _rest555) => {
if (!(Truthy(playing_118))) {
return default;
}
if (Truthy(Get(inst_123, "up"))) {
Invoke(inst_123, "up", Call(pt_133, V.Undef, e_560));
}
return default;
}, 1, "", true);
Invoke(inp_107, "addEventListener", ((V)("pointerup")), up_134);
Invoke(inp_107, "addEventListener", ((V)("pointercancel")), up_134);
key_135 = Fn((V _arrowThis569, int _argc562, V e_568, V _a565, V _a566, V _a567, V[] _rest563) => {
if ((!(Truthy(playing_118)) || !(Truthy(Get(inst_123, "key"))))) {
return default;
}
if (Truthy(Invoke(inst_123, "key", Get(e_568, "key"), (SEqS(Get(e_568, "type"), "keydown") ? V.True : V.False)))) {
Invoke(e_568, "preventDefault");
}
return default;
}, 1, "", true);
Invoke(G("window"), "addEventListener", ((V)("keydown")), key_135);
Invoke(G("window"), "addEventListener", ((V)("keyup")), key_135);
Invoke(back_110, "addEventListener", ((V)("click")), Fn((V _arrowThis576, int _argc570, V _a572, V _a573, V _a574, V _a575, V[] _rest571) => {
return Invoke(app_97, "hub");
}, 0, "", true));
Invoke(ctx_127, "timer", ((V)((Truthy(Get(G_98, "dur")) ? JsStrBuf.Begin().V(Get(G_98, "dur")).S("s").End() : ""))));
inst_123 = (Invoke(G_98, "make", ctx_127) is var _t577 && Truthy(_t577) ? _t577 : NewObj(0).V);
if (!(Truthy(Get(inst_123, "update")))) {
Set(inst_123, "update", Fn((V _arrowThis584, int _argc578, V _a580, V _a581, V _a582, V _a583, V[] _rest579) => {

return default;
}, 0, "", true));
}
Call(intro_130, V.Undef);
raf_121 = Call(G("requestAnimationFrame"), V.Undef, loop_132);
Set(YG_12, "_cur", NewObj(6).Put("G", G_98).Put("ctx", ctx_127).Put("inst", inst_123).Getter("score", Fn((V _self585, int _argc586, V _a588, V _a589, V _a590, V _a591, V[] _rest587) => {
if (_self585.IsNullish) _self585 = GlobalV;
return score_119;
return default;
}, 0, "score", false)).Put("start", Fn((V _arrowThis598, int _argc592, V _a594, V _a595, V _a596, V _a597, V[] _rest593) => {
Set(ov_108, "className", ((V)("yg-ov")));
Invoke(Get(Get(app_97, "root"), "classList"), "remove", ((V)("yg-introing")));
Call(start_131, V.Undef);
return default;
}, 0, "start", true)).Put("step", V.Null).V);
return Fn((V _arrowThis605, int _argc599, V _a601, V _a602, V _a603, V _a604, V[] _rest600) => {
alive_117 = (false ? V.True : V.False);
Call(G("cancelAnimationFrame"), V.Undef, raf_121);
Invoke(Get(Get(app_97, "root"), "classList"), "remove", ((V)("yg-introing")));
Invoke(G("window"), "removeEventListener", ((V)("keydown")), key_135);
Invoke(G("window"), "removeEventListener", ((V)("keyup")), key_135);
try {
if (Truthy(Get(inst_123, "destroy"))) {
Invoke(inst_123, "destroy");
}
} catch (System.Exception _ex606) {
V e_607 = default;
e_607 = Caught(_ex606);

}
Invoke(creatures_125, "forEach", Fn((V _arrowThis615, int _argc608, V c_614, V _a611, V _a612, V _a613, V[] _rest609) => {
return Invoke(c_614, "destroy");
}, 1, "", true));
Invoke(Get(Get(app_97, "root"), "classList"), "remove", ((V)("yg-playing")));
Set(YG_12, "_cur", V.Null);
return default;
}, 0, "", true);
return default;
}, 2, "run", false);
roster_34 = Fn((V _self616, int _argc617, V _a619, V _a620, V _a621, V _a622, V[] _rest618) => {
V R_623 = default;
if (_self616.IsNullish) _self616 = GlobalV;
R_623 = Get(G("window"), "SquishSquad");
if (!(Truthy(R_623))) {
return Arr();
}
return Invoke(Get(R_623, "ROSTER"), "filter", Fn((V _arrowThis631, int _argc624, V c_630, V _a627, V _a628, V _a629, V[] _rest625) => {
return ((c_630 is var _t632 && !Truthy(_t632) ? _t632 : Invoke(R_623, "src", Get(c_630, "id"))) is var _t633 && !Truthy(_t633) ? _t633 : Invoke(Get(YG_12, "SETS"), "includes", Get(c_630, "set")));
}, 1, "", true));
return default;
}, 0, "roster", false);
playerC_35 = Fn((V _self634, int _argc635, V _a637, V _a638, V _a639, V _a640, V[] _rest636) => {
V L_641 = default;
if (_self634.IsNullish) _self634 = GlobalV;
L_641 = Call(roster_34, V.Undef);
return ((Invoke(L_641, "find", Fn((V _arrowThis649, int _argc642, V c_648, V _a645, V _a646, V _a647, V[] _rest643) => {
return (SEq(Get(c_648, "id"), Get(SAVE_23, "player")) ? V.True : V.False);
}, 1, "", true)) is var _t658 && Truthy(_t658) ? _t658 : Invoke(L_641, "find", Fn((V _arrowThis657, int _argc650, V c_656, V _a653, V _a654, V _a655, V[] _rest651) => {
return (SEqS(Get(c_656, "key"), "mittens") ? V.True : V.False);
}, 1, "", true))) is var _t659 && Truthy(_t659) ? _t659 : GetIdx(L_641, 0D));
return default;
}, 0, "playerC", false);
NS_8 = ((V)("http://www.w3.org/2000/svg"));
TAU_9 = (System.Math.PI * 2D);
W_10 = 780D;
H_11 = 360D;
YG_12 = Set(G("window"), "YardGames", (Get(G("window"), "YardGames") is var _t660 && Truthy(_t660) ? _t660 : NewObj(1).Put("GAMES", Arr()).V));
Set(YG_12, "W", ((V)(W_10)));
Set(YG_12, "H", ((V)(H_11)));
Set(YG_12, "add", Fn((V _arrowThis668, int _argc661, V g_667, V _a664, V _a665, V _a666, V[] _rest662) => {
V i_669 = default;
i_669 = Invoke(Get(YG_12, "GAMES"), "findIndex", Fn((V _arrowThis677, int _argc670, V x_676, V _a673, V _a674, V _a675, V[] _rest671) => {
return (SEq(Get(x_676, "id"), Get(g_667, "id")) ? V.True : V.False);
}, 1, "", true));
if (GeN(i_669, 0D)) {
SetK(Get(YG_12, "GAMES"), i_669, g_667);
} else {
Invoke(Get(YG_12, "GAMES"), "push", g_667);
}
if (Truthy(Get(YG_12, "_hub"))) {
Invoke(YG_12, "_hub");
}
return default;
}, 1, "", true));
S_13 = Fn((V _arrowThis687, int _argc678, V tag_684, V a_685, V p_686, V _a683, V[] _rest679) => {
V e_688 = default;
e_688 = Invoke(G("document"), "createElementNS", NS_8, tag_684);
if (Truthy(a_685)) {
{
foreach (V _k689 in ForInKeys(a_685)) {
V k_690 = default;
k_690 = _k689;
if (!GetK(a_685, k_690).IsNullish) {
Invoke(e_688, "setAttribute", k_690, GetK(a_685, k_690));
}
}
}
}
if (Truthy(p_686)) {
Invoke(p_686, "appendChild", e_688);
}
return e_688;
return default;
}, 3, "", true);
D_14 = Fn((V _arrowThis701, int _argc691, V tag_697, V a_698, V p_699, V txt_700, V[] _rest692) => {
V e_702 = default;
e_702 = Invoke(G("document"), "createElement", tag_697);
if (Truthy(a_698)) {
{
foreach (V _k703 in ForInKeys(a_698)) {
V k_704 = default;
k_704 = _k703;
if (SEqS(k_704, "style")) {
Set(Get(e_702, "style"), "cssText", GetK(a_698, k_704));
} else {
if (SEqS(k_704, "cls")) {
Set(e_702, "className", GetK(a_698, k_704));
} else {
if (Truthy(Invoke(k_704, "startsWith", ((V)("on"))))) {
Invoke(e_702, "addEventListener", Invoke(k_704, "slice", ((V)(2D))), GetK(a_698, k_704));
} else {
Invoke(e_702, "setAttribute", k_704, GetK(a_698, k_704));
}
}
}
}
}
}
if (!txt_700.IsNullish) {
Set(e_702, "textContent", txt_700);
}
if (Truthy(p_699)) {
Invoke(p_699, "appendChild", e_702);
}
return e_702;
return default;
}, 4, "", true);
cl_15 = Fn((V _arrowThis714, int _argc705, V v_711, V a_712, V b_713, V _a710, V[] _rest706) => {
return (Lt(v_711, a_712) ? a_712 : (Gt(v_711, b_713) ? b_713 : v_711));
}, 3, "", true);
lerp_16 = Fn((V _arrowThis724, int _argc715, V a_721, V b_722, V u_723, V _a720, V[] _rest716) => {
return Add(a_721, ((V)(((ToNum(b_722) - ToNum(a_721)) * ToNum(u_723)))));
}, 3, "", true);
SM_17 = Fn((V _arrowThis732, int _argc725, V u_731, V _a728, V _a729, V _a730, V[] _rest726) => {
u_731 = Call(cl_15, V.Undef, u_731, ((V)(0D)), ((V)(1D)));
return ((V)(((ToNum(u_731) * ToNum(u_731)) * (3D - (2D * ToNum(u_731))))));
return default;
}, 1, "", true);
r2_18 = Fn((V _arrowThis740, int _argc733, V v_739, V _a736, V _a737, V _a738, V[] _rest734) => {
return ((V)((Round((ToNum(v_739) * 100D)) / 100D)));
}, 1, "", true);
set_19 = Fn((V _arrowThis750, int _argc741, V e_747, V k_748, V v_749, V _a746, V[] _rest742) => {
if (SEq(Get(e_747, "_c"), V.Undef)) {
Set(e_747, "_c", NewObj(0).V);
}
if (!SEq(GetK(Get(e_747, "_c"), k_748), v_749)) {
SetK(Get(e_747, "_c"), k_748, v_749);
Invoke(e_747, "setAttribute", k_748, v_749);
}
return default;
}, 3, "", true);
ease_20 = NewObj(4).Put("o", Fn((V _arrowThis758, int _argc751, V u_757, V _a754, V _a755, V _a756, V[] _rest752) => {
return ((V)((1D - ((1D - ToNum(u_757)) * (1D - ToNum(u_757))))));
}, 1, "o", true)).Put("i", Fn((V _arrowThis766, int _argc759, V u_765, V _a762, V _a763, V _a764, V[] _rest760) => {
return ((V)((ToNum(u_765) * ToNum(u_765))));
}, 1, "i", true)).Put("io", Fn((V _arrowThis774, int _argc767, V u_773, V _a770, V _a771, V _a772, V[] _rest768) => {
return ((V)((LtN(u_773, 0.5) ? ((2D * ToNum(u_773)) * ToNum(u_773)) : (1D - ((2D * (1D - ToNum(u_773))) * (1D - ToNum(u_773)))))));
}, 1, "io", true)).Put("back", Fn((V _arrowThis782, int _argc775, V u_781, V _a778, V _a779, V _a780, V[] _rest776) => {
double c_783 = 0;
c_783 = 1.7;
return ((V)(((1D + ((c_783 + 1D) * Pow((ToNum(u_781) - 1D), 3D))) + (c_783 * Pow((ToNum(u_781) - 1D), 2D)))));
return default;
}, 1, "back", true)).V;
track_21 = Fn((V _arrowThis792, int _argc784, V keys_790, V t_791, V _a788, V _a789, V[] _rest785) => {
V o_793 = default;
V chs_794 = default;
o_793 = NewObj(0).V;
chs_794 = New(G("Set"));
Invoke(keys_790, "forEach", Fn((V _arrowThis802, int _argc795, V k_801, V _a798, V _a799, V _a800, V[] _rest796) => {
return Invoke(Object_keys(GetIdx(k_801, 1D)), "forEach", Fn((V _arrowThis810, int _argc803, V c_809, V _a806, V _a807, V _a808, V[] _rest804) => {
return Invoke(chs_794, "add", c_809);
}, 1, "", true));
}, 1, "", true));
Invoke(chs_794, "forEach", Fn((V _arrowThis818, int _argc811, V c_817, V _a814, V _a815, V _a816, V[] _rest812) => {
V a_819 = default;
V b_820 = default;
a_819 = V.Null;
b_820 = V.Null;
{
foreach (V _k821 in new JsIter(keys_790)) {
V k_822 = default;
k_822 = _k821;
if (GetK(GetIdx(k_822, 1D), c_817).IsNullish) {
continue;
}
if (Le(GetIdx(k_822, 0D), t_791)) {
a_819 = k_822;
} else {
b_820 = k_822;
break;
}
}
}
SetK(o_793, c_817, (!(Truthy(a_819)) ? (Truthy(b_820) ? GetK(GetIdx(b_820, 1D), c_817) : ((V)(0D))) : (!(Truthy(b_820)) ? GetK(GetIdx(a_819, 1D), c_817) : Call(lerp_16, V.Undef, GetK(GetIdx(a_819, 1D), c_817), GetK(GetIdx(b_820, 1D), c_817), Invoke(ease_20, "io", ((V)(((ToNum(t_791) - ToNum(GetIdx(a_819, 0D))) / Max(1D, (ToNum(GetIdx(b_820, 0D)) - ToNum(GetIdx(a_819, 0D))))))))))));
return default;
}, 1, "", true));
return o_793;
return default;
}, 2, "", true);
Object_assign(YG_12, NewObj(10).Put("S", S_13).Put("D", D_14).Put("cl", cl_15).Put("lerp", lerp_16).Put("SM", SM_17).Put("r2", r2_18).Put("set", set_19).Put("ease", ease_20).Put("track", track_21).Put("TAU", ((V)(TAU_9))).V);
LS_22 = ((V)("yardgames.v1"));
SAVE_23 = NewObj(3).Put("best", NewObj(0).V).Put("player", V.Null).Put("plays", NewObj(0).V).V;
try {
V s_823 = default;
s_823 = Invoke(G("JSON"), "parse", (Invoke(G("localStorage"), "getItem", LS_22) is var _t824 && Truthy(_t824) ? _t824 : ((V)("null"))));
if (Truthy((s_823 is var _t825 && !Truthy(_t825) ? _t825 : Get(s_823, "best")))) {
SAVE_23 = Object_assign(SAVE_23, s_823);
}
} catch (System.Exception _ex826) {
V e_827 = default;
e_827 = Caught(_ex826);

}
save_24 = Fn((V _arrowThis834, int _argc828, V _a830, V _a831, V _a832, V _a833, V[] _rest829) => {
try {
Invoke(G("localStorage"), "setItem", LS_22, Invoke(G("JSON"), "stringify", SAVE_23));
} catch (System.Exception _ex835) {
V e_836 = default;
e_836 = Caught(_ex835);

}
return default;
}, 0, "", true);
AC_25 = V.Null;
muted_26 = (false ? V.True : V.False);
try {
muted_26 = (SEqS(Invoke(G("localStorage"), "getItem", ((V)(JsStrBuf.Begin().V(LS_22).S(".mute").End()))), "1") ? V.True : V.False);
} catch (System.Exception _ex837) {
V e_838 = default;
e_838 = Caught(_ex837);

}
ac_27 = Fn((V _arrowThis845, int _argc839, V _a841, V _a842, V _a843, V _a844, V[] _rest840) => {
if (Truthy(muted_26)) {
return V.Null;
}
try {
if (!(Truthy(AC_25))) {
AC_25 = New((Get(G("window"), "AudioContext") is var _t846 && Truthy(_t846) ? _t846 : Get(G("window"), "webkitAudioContext")));
}
if (SEqS(Get(AC_25, "state"), "suspended")) {
Invoke(AC_25, "resume");
}
} catch (System.Exception _ex847) {
V e_848 = default;
e_848 = Caught(_ex847);
AC_25 = V.Null;
}
return AC_25;
return default;
}, 0, "", true);
SFX_30 = NewObj(12).Put("pop", Fn((V _arrowThis855, int _argc849, V _a851, V _a852, V _a853, V _a854, V[] _rest850) => {
return Call(tone_28, V.Undef, ((V)(520D)), ((V)(880D)), ((V)(0.09)), ((V)("sine")), ((V)(0.16)));
}, 0, "pop", true)).Put("boing", Fn((V _arrowThis862, int _argc856, V _a858, V _a859, V _a860, V _a861, V[] _rest857) => {
return Call(tone_28, V.Undef, ((V)(180D)), ((V)(520D)), ((V)(0.22)), ((V)("triangle")), ((V)(0.18)));
}, 0, "boing", true)).Put("thud", Fn((V _arrowThis869, int _argc863, V _a865, V _a866, V _a867, V _a868, V[] _rest864) => {
Call(tone_28, V.Undef, ((V)(140D)), ((V)(60D)), ((V)(0.12)), ((V)("sine")), ((V)(0.22)));
Call(noise_29, V.Undef, ((V)(0.08)), ((V)(0.12)), ((V)(600D)));
return default;
}, 0, "thud", true)).Put("swish", Fn((V _arrowThis876, int _argc870, V _a872, V _a873, V _a874, V _a875, V[] _rest871) => {
return Call(noise_29, V.Undef, ((V)(0.22)), ((V)(0.16)), ((V)(3200D)));
}, 0, "swish", true)).Put("score", Fn((V _arrowThis883, int _argc877, V _a879, V _a880, V _a881, V _a882, V[] _rest878) => {
Call(tone_28, V.Undef, ((V)(660D)), ((V)(0D)), ((V)(0.1)), ((V)("triangle")), ((V)(0.16)));
Call(tone_28, V.Undef, ((V)(880D)), ((V)(0D)), ((V)(0.12)), ((V)("triangle")), ((V)(0.16)), ((V)(0.08)));
Call(tone_28, V.Undef, ((V)(1320D)), ((V)(0D)), ((V)(0.16)), ((V)("triangle")), ((V)(0.14)), ((V)(0.16)));
return default;
}, 0, "score", true)).Put("miss", Fn((V _arrowThis890, int _argc884, V _a886, V _a887, V _a888, V _a889, V[] _rest885) => {
return Call(tone_28, V.Undef, ((V)(330D)), ((V)(180D)), ((V)(0.25)), ((V)("sine")), ((V)(0.14)));
}, 0, "miss", true)).Put("tick", Fn((V _arrowThis897, int _argc891, V _a893, V _a894, V _a895, V _a896, V[] _rest892) => {
return Call(tone_28, V.Undef, ((V)(1200D)), ((V)(0D)), ((V)(0.04)), ((V)("square")), ((V)(0.05)));
}, 0, "tick", true)).Put("splash", Fn((V _arrowThis904, int _argc898, V _a900, V _a901, V _a902, V _a903, V[] _rest899) => {
Call(noise_29, V.Undef, ((V)(0.45)), ((V)(0.22)), ((V)(1400D)));
Call(tone_28, V.Undef, ((V)(300D)), ((V)(120D)), ((V)(0.2)), ((V)("sine")), ((V)(0.1)));
return default;
}, 0, "splash", true)).Put("clang", Fn((V _arrowThis911, int _argc905, V _a907, V _a908, V _a909, V _a910, V[] _rest906) => {
Call(tone_28, V.Undef, ((V)(900D)), ((V)(860D)), ((V)(0.25)), ((V)("triangle")), ((V)(0.1)));
Call(tone_28, V.Undef, ((V)(1340D)), ((V)(1300D)), ((V)(0.2)), ((V)("sine")), ((V)(0.06)));
return default;
}, 0, "clang", true)).Put("whoosh", Fn((V _arrowThis918, int _argc912, V _a914, V _a915, V _a916, V _a917, V[] _rest913) => {
return Call(noise_29, V.Undef, ((V)(0.3)), ((V)(0.1)), ((V)(900D)));
}, 0, "whoosh", true)).Put("tap", Fn((V _arrowThis925, int _argc919, V _a921, V _a922, V _a923, V _a924, V[] _rest920) => {
return Call(tone_28, V.Undef, ((V)(760D)), ((V)(0D)), ((V)(0.05)), ((V)("sine")), ((V)(0.1)));
}, 0, "tap", true)).Put("win", Fn((V _arrowThis932, int _argc926, V _a928, V _a929, V _a930, V _a931, V[] _rest927) => {
return Invoke(Arr(((V)(523D)), ((V)(659D)), ((V)(784D)), ((V)(1046D))), "forEach", Fn((V _arrowThis941, int _argc933, V f_939, V i_940, V _a937, V _a938, V[] _rest934) => {
return Call(tone_28, V.Undef, f_939, ((V)(0D)), ((V)(0.18)), ((V)("triangle")), ((V)(0.14)), ((V)((ToNum(i_940) * 0.1))));
}, 2, "", true));
}, 0, "win", true)).V;
Set(YG_12, "SFX", SFX_30);
Set(YG_12, "creature", Fn((V _self942, int _argc943, V layer_949, V key_950, V o_951, V _a948, V[] _rest944) => {
V host_952 = default;
V R_953 = default;
V ctrl_954 = default;
V I_955 = default;
V E_956 = default;
V c_957 = default;
if (_self942.IsNullish) _self942 = GlobalV;
o_951 = (o_951 is var _t958 && Truthy(_t958) ? _t958 : NewObj(0).V);
host_952 = Call(D_14, V.Undef, ((V)("div")), NewObj(2).Put("cls", ((V)("yg-cr"))).Put("style", ((V)("position:absolute;pointer-events:none;"))).V, layer_949);
R_953 = Get(G("window"), "RiveRig");
ctrl_954 = V.Null;
try {
ctrl_954 = Invoke(R_953, "mount", host_952, key_950, NewObj(1).Put("fidgets", (false ? V.True : V.False)).V);
} catch (System.Exception _ex959) {
V e_960 = default;
e_960 = Caught(_ex959);
Invoke(G("console"), "warn", ((V)("YardGames rig")), key_950, e_960);
}
I_955 = (ctrl_954 is var _t961 && !Truthy(_t961) ? _t961 : Get(ctrl_954, "_I"));
E_956 = NewObj(0).V;
if (Truthy(I_955)) {
Set(I_955, "ext", E_956);
Set(I_955, "fidgets", (false ? V.True : V.False));
Set(I_955, "ptr", NewObj(2).Put("x", ((V)(0D))).Put("y", ((V)(0D))).V);
}
c_957 = NewObj(22).Put("key", key_950).Put("host", host_952).Put("ctrl", ctrl_954).Put("I", I_955).Put("E", E_956).Put("x", ((V)(0D))).Put("y", ((V)(0D))).Put("size", ((V)(100D))).Put("r", ((V)(0D))).Put("ox", ((V)(50D))).Put("oy", ((V)(93D))).Put("ws", NewObj(0).V).Put("z", ((V)(0D))).Put("set", Fn((V _self962, int _argc963, V x_969, V y_970, V size_971, V _a968, V[] _rest964) => {
V s_972 = default;
if (_self962.IsNullish) _self962 = GlobalV;
if (!x_969.IsNullish) {
Set(_self962, "x", x_969);
}
if (!y_970.IsNullish) {
Set(_self962, "y", y_970);
}
if (!size_971.IsNullish) {
Set(_self962, "size", size_971);
}
s_972 = Get(_self962, "size");
Set(Get(host_952, "style"), "left", ((V)(JsStrBuf.Begin().V(Call(r2_18, V.Undef, ((V)((((ToNum(Get(_self962, "x")) - (ToNum(s_972) / 2D)) / W_10) * 100D))))).S("%").End())));
Set(Get(host_952, "style"), "top", ((V)(JsStrBuf.Begin().V(Call(r2_18, V.Undef, ((V)((((ToNum(Get(_self962, "y")) - (ToNum(s_972) * 0.93)) / H_11) * 100D))))).S("%").End())));
Set(Get(host_952, "style"), "width", ((V)(JsStrBuf.Begin().V(Call(r2_18, V.Undef, ((V)(((ToNum(s_972) / W_10) * 100D))))).S("%").End())));
Set(Get(host_952, "style"), "height", ((V)(JsStrBuf.Begin().V(Call(r2_18, V.Undef, ((V)(((ToNum(s_972) / H_11) * 100D))))).S("%").End())));
return _self962;
return default;
}, 3, "set", false)).Put("rot", Fn((V _self973, int _argc974, V deg_980, V ox_981, V oy_982, V _a979, V[] _rest975) => {
if (_self973.IsNullish) _self973 = GlobalV;
Set(_self973, "r", deg_980);
if (!ox_981.IsNullish) {
Set(_self973, "ox", ox_981);
Set(_self973, "oy", oy_982);
}
Set(Get(host_952, "style"), "transformOrigin", ((V)(JsStrBuf.Begin().V(Get(_self973, "ox")).S("% ").V(Get(_self973, "oy")).S("%").End())));
Set(Get(host_952, "style"), "transform", ((V)((Truthy(deg_980) ? JsStrBuf.Begin().S("rotate(").V(Call(r2_18, V.Undef, deg_980)).S("deg)").End() : ""))));
return _self973;
return default;
}, 3, "rot", false)).Put("yaw", Fn((V _self983, int _argc984, V deg_990, V _a987, V _a988, V _a989, V[] _rest985) => {
if (_self983.IsNullish) _self983 = GlobalV;
if (Truthy(I_955)) {
Set(I_955, "spinOff", deg_990);
}
return _self983;
return default;
}, 1, "yaw", false)).Put("play", Fn((V _self991, int _argc992, V n_998, V _a995, V _a996, V _a997, V[] _rest993) => {
if (_self991.IsNullish) _self991 = GlobalV;
if (Truthy(ctrl_954)) {
Invoke(ctrl_954, "play", n_998);
}
return _self991;
return default;
}, 1, "play", false)).Put("pose", Fn((V _self999, int _argc1000, V p_1006, V _a1003, V _a1004, V _a1005, V[] _rest1001) => {
if (_self999.IsNullish) _self999 = GlobalV;
{
foreach (V _k1007 in ForInKeys(E_956)) {
V k_1008 = default;
k_1008 = _k1007;
SetK(E_956, k_1008, ((V)(0D)));
}
}
if (Truthy(p_1006)) {
Object_assign(E_956, p_1006);
}
return _self999;
return default;
}, 1, "pose", false)).Put("walk", Fn((V _self1009, int _argc1010, V dt_1016, V w_1017, V spin_1018, V _a1015, V[] _rest1011) => {
if (_self1009.IsNullish) _self1009 = GlobalV;
if (Truthy(((GtN(w_1017, 0.01) ? V.True : V.False) is var _t1019 && !Truthy(_t1019) ? _t1019 : Get(G("window"), "HouseWalk")))) {
try {
Invoke(Get(G("window"), "HouseWalk"), "step", key_950, Get(_self1009, "ws"), E_956, w_1017, dt_1016, ((V)(1D)), (spin_1018 is var _t1020 && Truthy(_t1020) ? _t1020 : ((V)(0D))));
} catch (System.Exception _ex1021) {
V e_1022 = default;
e_1022 = Caught(_ex1021);

}
}
return _self1009;
return default;
}, 3, "walk", false)).Put("depth", Fn((V _self1023, int _argc1024, V z_1030, V _a1027, V _a1028, V _a1029, V[] _rest1025) => {
if (_self1023.IsNullish) _self1023 = GlobalV;
Set(_self1023, "z", z_1030);
Set(Get(host_952, "style"), "zIndex", ((V)(Round(ToNum(z_1030)))));
return _self1023;
return default;
}, 1, "depth", false)).Put("hide", Fn((V _self1031, int _argc1032, V v_1038, V _a1035, V _a1036, V _a1037, V[] _rest1033) => {
if (_self1031.IsNullish) _self1031 = GlobalV;
Set(Get(host_952, "style"), "visibility", ((V)((Truthy(v_1038) ? "hidden" : ""))));
return _self1031;
return default;
}, 1, "hide", false)).Put("destroy", Fn((V _self1039, int _argc1040, V _a1042, V _a1043, V _a1044, V _a1045, V[] _rest1041) => {
if (_self1039.IsNullish) _self1039 = GlobalV;
try {
if (Truthy(ctrl_954)) {
Invoke(ctrl_954, "destroy");
}
} catch (System.Exception _ex1046) {
V e_1047 = default;
e_1047 = Caught(_ex1046);

}
Invoke(host_952, "remove");
return default;
}, 0, "destroy", false)).V;
if (Truthy(((I_955 is var _t1048 && !Truthy(_t1048) ? _t1048 : Get(I_955, "shadow")) is var _t1049 && !Truthy(_t1049) ? _t1049 : (!(Truthy(Get(o_951, "shadow"))) ? V.True : V.False)))) {
Set(Get(Get(I_955, "shadow"), "style"), "display", ((V)("none")));
Invoke(Get(I_955, "shadow"), "setAttribute", ((V)("rx")), ((V)(0D)));
}
if (!Get(o_951, "yaw").IsNullish) {
Invoke(c_957, "yaw", Get(o_951, "yaw"));
}
Invoke(c_957, "set", (Get(o_951, "x") is var _t1050 && Truthy(_t1050) ? _t1050 : ((V)((W_10 / 2D)))), (Get(o_951, "y") is var _t1051 && Truthy(_t1051) ? _t1051 : ((V)((H_11 - 60D)))), (Get(o_951, "size") is var _t1052 && Truthy(_t1052) ? _t1052 : ((V)(140D))));
return c_957;
return default;
}, 3, "", false));
Set(YG_12, "cam", Fn((V _arrowThis1063, int _argc1053, V Dc_1059, V CH_1060, V HY_1061, V K_1062, V[] _rest1054) => {
return Fn((V _arrowThis1073, int _argc1064, V x_1070, V y_1071, V z_1072, V _a1069, V[] _rest1065) => {
double s_1074 = 0;
s_1074 = (ToNum(Dc_1059) / ToNum(Add(Dc_1059, z_1072)));
return Arr(((V)(((W_10 / 2D) + ((ToNum(x_1070) * s_1074) * ToNum(K_1062))))), Add(HY_1061, ((V)((((ToNum(CH_1060) - ToNum(y_1071)) * s_1074) * ToNum(K_1062))))), ((V)((s_1074 * ToNum(K_1062)))));
return default;
}, 3, "", true);
}, 4, "", true));
Set(YG_12, "shadow", Fn((V _arrowThis1086, int _argc1075, V p_1081, V x_1082, V y_1083, V rx_1084, V[] _rest1076) => {
V op_1085 = default;
op_1085 = (_argc1075 > 4 ? _rest1076[0] : V.Undef);
return Call(S_13, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", x_1082).Put("cy", y_1083).Put("rx", rx_1084).Put("ry", ((V)((ToNum(rx_1084) * 0.22)))).Put("fill", ((V)("#3a2a55"))).Put("opacity", (op_1085.IsNullish ? ((V)(0.18)) : op_1085)).V, p_1081);
}, 5, "", true));
Set(YG_12, "yard", Fn((V _self1087, int _argc1088, V p_1094, V o_1095, V _a1092, V _a1093, V[] _rest1089) => {
V hz_1096 = default;
double kw_1097 = 0;
double sd_1098 = 0;
V rnd_1099 = default;
V tg_1100 = default;
if (_self1087.IsNullish) _self1087 = GlobalV;
o_1095 = (o_1095 is var _t1101 && Truthy(_t1101) ? _t1101 : NewObj(0).V);
hz_1096 = (Get(o_1095, "hz") is var _t1102 && Truthy(_t1102) ? _t1102 : ((V)(250D)));
if (!SEq(Get(o_1095, "sky"), (false ? V.True : V.False))) {
Call(S_13, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-20D)))).Put("y", ((V)((-20D)))).Put("width", ((V)((W_10 + 40D)))).Put("height", Add(hz_1096, ((V)(40D)))).Put("fill", ((V)("url(#ygSky)"))).V, p_1094);
}
kw_1097 = (W_10 / 360D);
if (!SEq(Get(o_1095, "sky"), (false ? V.True : V.False))) {
Invoke(((kw_1097 > 1.5) ? Arr(Arr(((V)(60D)), ((V)(70D)), ((V)(1D))), Arr(((V)(250D)), ((V)(46D)), ((V)(0.8))), Arr(((V)(320D)), ((V)(120D)), ((V)(0.6))), Arr(((V)(140D)), ((V)(140D)), ((V)(0.55))), Arr(((V)(470D)), ((V)(60D)), ((V)(0.9))), Arr(((V)(610D)), ((V)(110D)), ((V)(0.6))), Arr(((V)(730D)), ((V)(40D)), ((V)(0.75)))) : Arr(Arr(((V)(60D)), ((V)(70D)), ((V)(1D))), Arr(((V)(250D)), ((V)(46D)), ((V)(0.8))), Arr(((V)(320D)), ((V)(120D)), ((V)(0.6))), Arr(((V)(140D)), ((V)(140D)), ((V)(0.55))))), "forEach", Fn((V _arrowThis1116, int _argc1103, V _a1105, V _a1106, V _a1107, V _a1108, V[] _rest1104) => {
V g_1117 = default;
V x_1111 = default;
V y_1113 = default;
V k_1115 = default;
{ V _t1109 = ListOf(_a1105);
{ V _t1110 = GetIdx(_t1109, 0D);
x_1111 = _t1110; }
{ V _t1112 = GetIdx(_t1109, 1D);
y_1113 = _t1112; }
{ V _t1114 = GetIdx(_t1109, 2D);
k_1115 = _t1114; }
}
g_1117 = Call(S_13, V.Undef, ((V)("g")), NewObj(2).Put("opacity", ((V)(0.92))).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(x_1111).S(" ").N(((ToNum(y_1113) * ToNum(hz_1096)) / 250D)).S(") scale(").V(k_1115).S(")").End()))).V, p_1094);
Invoke(Arr(Arr(((V)((-26D))), ((V)(4D)), ((V)(18D))), Arr(((V)(0D)), ((V)((-6D))), ((V)(24D))), Arr(((V)(26D)), ((V)(4D)), ((V)(18D))), Arr(((V)(10D)), ((V)(8D)), ((V)(18D))), Arr(((V)((-12D))), ((V)(9D)), ((V)(16D)))), "forEach", Fn((V _arrowThis1131, int _argc1118, V _a1120, V _a1121, V _a1122, V _a1123, V[] _rest1119) => {
V a_1126 = default;
V b_1128 = default;
V r_1130 = default;
{ V _t1124 = ListOf(_a1120);
{ V _t1125 = GetIdx(_t1124, 0D);
a_1126 = _t1125; }
{ V _t1127 = GetIdx(_t1124, 1D);
b_1128 = _t1127; }
{ V _t1129 = GetIdx(_t1124, 2D);
r_1130 = _t1129; }
}
return Call(S_13, V.Undef, ((V)("circle")), NewObj(4).Put("cx", a_1126).Put("cy", b_1128).Put("r", r_1130).Put("fill", ((V)("#ffffff"))).V, g_1117);
}, 1, "", true));
return default;
}, 1, "", true));
}
if (!SEq(Get(o_1095, "trees"), (false ? V.True : V.False))) {
Invoke(((kw_1097 > 1.5) ? Arr(Arr(((V)(18D)), ((V)(0.9))), Arr(((V)(120D)), ((V)(0.75))), Arr(((V)(250D)), ((V)(1.05))), Arr(((V)(520D)), ((V)(0.8))), Arr(((V)(640D)), ((V)(1.1))), Arr(((V)(690D)), ((V)(0.7))), Arr(((V)(762D)), ((V)(0.95)))) : Arr(Arr(((V)(18D)), ((V)(0.9))), Arr(((V)(342D)), ((V)(1.1))), Arr(((V)(300D)), ((V)(0.7))))), "forEach", Fn((V _arrowThis1143, int _argc1132, V _a1134, V _a1135, V _a1136, V _a1137, V[] _rest1133) => {
V g_1144 = default;
V x_1140 = default;
V k_1142 = default;
{ V _t1138 = ListOf(_a1134);
{ V _t1139 = GetIdx(_t1138, 0D);
x_1140 = _t1139; }
{ V _t1141 = GetIdx(_t1138, 1D);
k_1142 = _t1141; }
}
g_1144 = Call(S_13, V.Undef, ((V)("g")), NewObj(1).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(x_1140).S(" ").N((ToNum(hz_1096) - 6D)).S(") scale(").V(k_1142).S(")").End()))).V, p_1094);
Call(S_13, V.Undef, ((V)("rect")), NewObj(6).Put("x", ((V)((-4D)))).Put("y", ((V)((-34D)))).Put("width", ((V)(8D))).Put("height", ((V)(36D))).Put("rx", ((V)(3D))).Put("fill", ((V)("#8a5a34"))).V, g_1144);
Invoke(Arr(Arr(((V)((-14D))), ((V)((-44D))), ((V)(18D))), Arr(((V)(12D)), ((V)((-46D))), ((V)(20D))), Arr(((V)(0D)), ((V)((-62D))), ((V)(22D))), Arr(((V)((-4D))), ((V)((-40D))), ((V)(16D)))), "forEach", Fn((V _arrowThis1158, int _argc1145, V _a1147, V _a1148, V _a1149, V _a1150, V[] _rest1146) => {
V a_1153 = default;
V b_1155 = default;
V r_1157 = default;
{ V _t1151 = ListOf(_a1147);
{ V _t1152 = GetIdx(_t1151, 0D);
a_1153 = _t1152; }
{ V _t1154 = GetIdx(_t1151, 1D);
b_1155 = _t1154; }
{ V _t1156 = GetIdx(_t1151, 2D);
r_1157 = _t1156; }
}
return Call(S_13, V.Undef, ((V)("circle")), NewObj(4).Put("cx", a_1153).Put("cy", b_1155).Put("r", r_1157).Put("fill", ((V)("#57a854"))).V, g_1144);
}, 1, "", true));
Call(S_13, V.Undef, ((V)("circle")), NewObj(5).Put("cx", ((V)((-6D)))).Put("cy", ((V)((-66D)))).Put("r", ((V)(9D))).Put("fill", ((V)("#7cc46a"))).Put("opacity", ((V)(0.8))).V, g_1144);
return default;
}, 1, "", true));
}
if (!SEq(Get(o_1095, "fence"), (false ? V.True : V.False))) {
double fy_1159 = 0;
V g_1160 = default;
fy_1159 = (ToNum(hz_1096) - 34D);
g_1160 = Call(S_13, V.Undef, ((V)("g")), NewObj(0).V, p_1094);
Call(S_13, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-10D)))).Put("y", ((V)((fy_1159 + 10D)))).Put("width", ((V)((W_10 + 20D)))).Put("height", ((V)(6D))).Put("fill", ((V)("#f3e8da"))).V, g_1160);
Call(S_13, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-10D)))).Put("y", ((V)((fy_1159 + 26D)))).Put("width", ((V)((W_10 + 20D)))).Put("height", ((V)(6D))).Put("fill", ((V)("#f3e8da"))).V, g_1160);
{
double x_1161 = 0;
x_1161 = (-6D);
while (true) {
if (!((x_1161 < (W_10 + 10D)))) break;
Call(S_13, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(JsStrBuf.Begin().S("M").N(x_1161).S(" ").N((fy_1159 + 38D)).S("V").N((fy_1159 + 6D)).S("L").N((x_1161 + 6D)).S(" ").N(fy_1159).S("L").N((x_1161 + 12D)).S(" ").N((fy_1159 + 6D)).S("V").N((fy_1159 + 38D)).S("Z").End()))).Put("fill", ((V)("#fff8ee"))).Put("stroke", ((V)("#e2cfb8"))).Put("stroke-width", ((V)(1D))).V, g_1160);
x_1161 = (x_1161 + 18D);
}
}
}
Call(S_13, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-20D)))).Put("y", hz_1096).Put("width", ((V)((W_10 + 40D)))).Put("height", ((V)(((H_11 - ToNum(hz_1096)) + 20D)))).Put("fill", ((V)("url(#ygGrass)"))).V, p_1094);
sd_1098 = 7D;
rnd_1099 = Fn((V _arrowThis1169, int _argc1163, V _a1165, V _a1166, V _a1167, V _a1168, V[] _rest1164) => {
return ((V)(((sd_1098 = (((sd_1098 * 9301D) + 49297D) % 233280D)) / 233280D)));
}, 0, "", true);
tg_1100 = Call(S_13, V.Undef, ((V)("g")), NewObj(1).Put("opacity", ((V)(0.55))).V, p_1094);
{
double i_1170 = 0;
i_1170 = 0D;
while (true) {
if (!((i_1170 < Round((46D * kw_1097))))) break;
double x_1172 = 0;
V y_1173 = default;
double k_1174 = 0;
x_1172 = (ToNum(Call(rnd_1099, V.Undef)) * W_10);
y_1173 = Add(Add(hz_1096, ((V)(8D))), ((V)((ToNum(Call(rnd_1099, V.Undef)) * ((H_11 - ToNum(hz_1096)) - 10D)))));
k_1174 = (0.6 + (((ToNum(y_1173) - ToNum(hz_1096)) / (H_11 - ToNum(hz_1096))) * 0.9));
Call(S_13, V.Undef, ((V)("path")), NewObj(2).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_18, V.Undef, ((V)((x_1172 - (3D * k_1174)))))).S(" ").V(Call(r2_18, V.Undef, y_1173)).S("q").V(Call(r2_18, V.Undef, ((V)((1D * k_1174))))).S(" ").V(Call(r2_18, V.Undef, ((V)(((-6D) * k_1174))))).S(" ").V(Call(r2_18, V.Undef, ((V)((2D * k_1174))))).S(" ").V(Call(r2_18, V.Undef, ((V)(((-8D) * k_1174))))).S("q").V(Call(r2_18, V.Undef, ((V)((0.5 * k_1174))))).S(" ").V(Call(r2_18, V.Undef, ((V)((5D * k_1174))))).S(" ").V(Call(r2_18, V.Undef, ((V)((1.6 * k_1174))))).S(" ").V(Call(r2_18, V.Undef, ((V)((8D * k_1174))))).S("q").V(Call(r2_18, V.Undef, ((V)((1D * k_1174))))).S(" ").V(Call(r2_18, V.Undef, ((V)(((-5D) * k_1174))))).S(" ").V(Call(r2_18, V.Undef, ((V)((3D * k_1174))))).S(" ").V(Call(r2_18, V.Undef, ((V)(((-7D) * k_1174))))).S("q").V(Call(r2_18, V.Undef, ((V)(((-0.6) * k_1174))))).S(" ").V(Call(r2_18, V.Undef, ((V)((5D * k_1174))))).S(" ").V(Call(r2_18, V.Undef, ((V)((0.4 * k_1174))))).S(" ").V(Call(r2_18, V.Undef, ((V)((7D * k_1174))))).S("Z").End()))).Put("fill", ((V)("#4f9a3e"))).V, tg_1100);
i_1170++;
}
}
if (!SEq(Get(o_1095, "flowers"), (false ? V.True : V.False))) {
{
double i_1175 = 0;
i_1175 = 0D;
while (true) {
if (!((i_1175 < Round((9D * kw_1097))))) break;
double x_1177 = 0;
V y_1178 = default;
double k_1179 = 0;
V c_1180 = default;
x_1177 = (ToNum(Call(rnd_1099, V.Undef)) * W_10);
y_1178 = Add(Add(hz_1096, ((V)(14D))), ((V)((ToNum(Call(rnd_1099, V.Undef)) * ((H_11 - ToNum(hz_1096)) - 30D)))));
k_1179 = (0.7 + (((ToNum(y_1178) - ToNum(hz_1096)) / (H_11 - ToNum(hz_1096))) * 0.8));
c_1180 = GetIdx(Arr(((V)("#ffd1e8")), ((V)("#fff3a8")), ((V)("#ffffff")), ((V)("#d9c8ff"))), (i_1175 % 4D));
{
double j_1181 = 0;
j_1181 = 0D;
while (true) {
if (!((j_1181 < 5D))) break;
Call(S_13, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_18, V.Undef, ((V)((x_1177 + ((FdLibm.Cos((j_1181 * 1.2566)) * 2.6) * k_1179)))))).Put("cy", Call(r2_18, V.Undef, Add(y_1178, ((V)(((FdLibm.Sin((j_1181 * 1.2566)) * 2.6) * k_1179)))))).Put("r", Call(r2_18, V.Undef, ((V)((1.9 * k_1179))))).Put("fill", c_1180).V, p_1094);
j_1181++;
}
}
Call(S_13, V.Undef, ((V)("circle")), NewObj(4).Put("cx", Call(r2_18, V.Undef, ((V)(x_1177)))).Put("cy", Call(r2_18, V.Undef, y_1178)).Put("r", Call(r2_18, V.Undef, ((V)((1.3 * k_1179))))).Put("fill", ((V)("#ffb84a"))).V, p_1094);
i_1175++;
}
}
}
return default;
}, 2, "", false));
Call(Fn((V _self1183, int _argc1184, V _a1186, V _a1187, V _a1188, V _a1189, V[] _rest1185) => {
V st_1190 = default;
if (_self1183.IsNullish) _self1183 = GlobalV;
if (Truthy(Invoke(G("document"), "getElementById", ((V)("yg-land-css"))))) {
return default;
}
st_1190 = Invoke(G("document"), "createElement", ((V)("style")));
Set(st_1190, "id", ((V)("yg-land-css")));
Set(st_1190, "textContent", ((V)(".yg-frame:not(.yg-port) .yg-top{gap:2cqh;padding:2.6cqh 3cqh}.yg-frame:not(.yg-port) .yg-back{width:10cqh;height:10cqh;font:700 8cqh/1 'Fredoka',sans-serif;box-shadow:0 0.8cqh 0 #c9b6f2;padding:0 0 1cqh}.yg-frame:not(.yg-port) .yg-ttl{font:700 5.2cqh/1.1 'Fredoka',sans-serif}.yg-frame:not(.yg-port) .yg-pills{gap:1.6cqh}.yg-frame:not(.yg-port) .yg-pill{min-width:11cqh;padding:1.4cqh 2.8cqh;font:700 4.4cqh/1 'Fredoka',sans-serif;box-shadow:0 0.8cqh 0 rgba(106,47,176,0.25)}.yg-frame:not(.yg-port) .yg-hint{left:4cqh;right:4cqh;bottom:3.5cqh;font:800 3.6cqh/1.25 'Nunito',sans-serif}.yg-frame:not(.yg-port) .yg-toast{font:700 6cqh/1 'Fredoka',sans-serif;-webkit-text-stroke:0.5cqh #4a1a73}.yg-frame:not(.yg-port) .yg-toast.yg-big{font-size:12cqh}.yg-frame:not(.yg-port) .yg-ov{padding:6cqh}.yg-frame:not(.yg-port) .yg-card{border-radius:7cqh;padding:6cqh 6cqh 5cqh;box-shadow:0 2cqh 0 #c9b6f2, 0 6cqh 16cqh rgba(40,10,80,0.3)}.yg-frame:not(.yg-port) .yg-ic{width:34cqh;height:24cqh;margin:-2cqh auto 1cqh}.yg-frame:not(.yg-port) .yg-card-t{font:700 8cqh/1.05 'Fredoka',sans-serif}.yg-frame:not(.yg-port) .yg-card-s{font:800 3.4cqh/1.3 'Nunito',sans-serif;margin-top:1cqh}.yg-frame:not(.yg-port) .yg-how{margin:4cqh 0 2cqh;padding:0 0 0 5cqh;font:700 3.9cqh/1.35 'Nunito',sans-serif}.yg-frame:not(.yg-port) .yg-how li{margin:1cqh 0}.yg-frame:not(.yg-port) .yg-opts{gap:2cqh;margin:2cqh 0 1cqh}.yg-frame:not(.yg-port) .yg-opt{border:0.6cqh solid #e0d2f7;padding:1.6cqh 3.4cqh;font:800 3.6cqh/1 'Nunito',sans-serif}.yg-frame:not(.yg-port) .yg-btn{padding:3.2cqh 7cqh;font:700 5.4cqh/1 'Fredoka',sans-serif;box-shadow:0 1.4cqh 0 #a8287a}.yg-frame:not(.yg-port) .yg-btn:active{transform:translateY(1cqh);box-shadow:0 0.4cqh 0 #a8287a}.yg-frame:not(.yg-port) .yg-ghost{box-shadow:0 1.4cqh 0 #c9b6f2}.yg-frame:not(.yg-port) .yg-go{margin-top:3cqh;padding:3.6cqh 14cqh;font-size:6.4cqh}.yg-frame:not(.yg-port) .yg-best{margin-top:3cqh;font:800 3.4cqh/1 'Nunito',sans-serif}.yg-frame:not(.yg-port) .yg-res-t{font:700 8.6cqh/1.05 'Fredoka',sans-serif}.yg-frame:not(.yg-port) .yg-stars{gap:2cqh;margin:2cqh 0 1cqh}.yg-frame:not(.yg-port) .yg-star{font-size:11cqh}.yg-frame:not(.yg-port) .yg-star.on{text-shadow:0 0.8cqh 0 #e09a14}.yg-frame:not(.yg-port) .yg-res-score{font:700 14cqh/1 'Fredoka',sans-serif}.yg-frame:not(.yg-port) .yg-res-sub{font:800 3.8cqh/1.3 'Nunito',sans-serif;margin-top:1cqh}.yg-frame:not(.yg-port) .yg-res-coins{margin:3cqh 0 4cqh;padding:1.6cqh 4cqh;font:800 3.6cqh/1 'Nunito',sans-serif}.yg-frame:not(.yg-port) .yg-row{gap:3cqh}.yg-frame:not(.yg-port) .yg-hubwrap{padding:0 0 4cqh}.yg-frame:not(.yg-port) .yg-hhead{padding:5cqh 5cqh 1cqh}.yg-frame:not(.yg-port) .yg-htitle{font:700 10cqh/1 'Fredoka',sans-serif;-webkit-text-stroke:1cqh #6a2fb0;text-shadow:0 1.2cqh 0 #6a2fb0}.yg-frame:not(.yg-port) .yg-hsub{margin-top:2cqh;font:800 3.6cqh/1.2 'Nunito',sans-serif}.yg-frame:not(.yg-port) .yg-mute{right:3cqh;top:3cqh;width:10cqh;height:10cqh;font-size:5cqh}.yg-frame:not(.yg-port) .yg-me{gap:3cqh;margin:2cqh 4cqh 0;padding:2cqh 4cqh 2cqh 2cqh;border-radius:6cqh;box-shadow:0 1.2cqh 0 rgba(80,140,60,0.35)}.yg-frame:not(.yg-port) .yg-me-st{width:28cqh;height:28cqh;border-radius:5cqh}.yg-frame:not(.yg-port) .yg-me-k{font:800 3.2cqh/1 'Nunito',sans-serif}.yg-frame:not(.yg-port) .yg-me-n{font:700 7.2cqh/1.1 'Fredoka',sans-serif;margin:1cqh 0}.yg-frame:not(.yg-port) .yg-me-h{font:700 3.4cqh/1.2 'Nunito',sans-serif}.yg-frame:not(.yg-port) .yg-strip{gap:2cqh;padding:3cqh 4cqh 3cqh}.yg-frame:not(.yg-port) .yg-pick{width:15cqh;height:15cqh;border:0.8cqh solid #ffffff;box-shadow:0 0.8cqh 0 rgba(60,110,40,0.35)}.yg-frame:not(.yg-port) .yg-pick.on{box-shadow:0 0 0 0.8cqh #ffffff, 0 1.2cqh 0 rgba(60,110,40,0.35)}.yg-frame:not(.yg-port) .yg-grid{gap:3.4cqh;padding:1cqh 4cqh 2cqh}.yg-frame:not(.yg-port) .yg-gcard{border-radius:6cqh;padding:2.6cqh 2.6cqh 3cqh;box-shadow:0 1.4cqh 0 color-mix(in srgb, var(--gc) 55%, #3b2457)}.yg-frame:not(.yg-port) .yg-gcard:active{transform:translateY(1cqh);box-shadow:0 0.4cqh 0 color-mix(in srgb, var(--gc) 55%, #3b2457)}.yg-frame:not(.yg-port) .yg-gic{height:22cqh;border-radius:4cqh}.yg-frame:not(.yg-port) .yg-gname{margin-top:2cqh;font:700 4.8cqh/1.05 'Fredoka',sans-serif}.yg-frame:not(.yg-port) .yg-gitem{margin-top:0.6cqh;font:800 2.9cqh/1.2 'Nunito',sans-serif}.yg-frame:not(.yg-port) .yg-gbest{top:3.6cqh;right:3.6cqh;padding:0.8cqh 2cqh;font:800 2.7cqh/1 'Nunito',sans-serif;box-shadow:0 0.4cqh 0 rgba(0,0,0,0.1)}.yg-frame:not(.yg-port) .yg-foot{margin:2cqh 6cqh 0;font:700 3cqh/1.35 'Nunito',sans-serif}.yg-frame:not(.yg-port) .yg-iback{left:3cqh;top:3cqh;width:10cqh;height:10cqh;font:700 8cqh/1 Fredoka,sans-serif;box-shadow:0 0.8cqh 0 rgba(40,10,80,0.35);padding:0 0 1cqh}.yg-frame:not(.yg-port) .yg-isheet{left:4cqh;right:4cqh;bottom:4cqh;border-radius:7cqh;padding:3.4cqh 5cqh 3.4cqh;box-shadow:0 1.6cqh 0 color-mix(in srgb,var(--gc) 60%,#3b2457),0 5cqh 14cqh rgba(30,8,60,0.35)}.yg-frame:not(.yg-port) .yg-ihead{gap:2.4cqh;font:800 3.1cqh/1 Nunito,sans-serif}.yg-frame:not(.yg-port) .yg-ihead::before,.yg-frame:not(.yg-port) .yg-ihead::after{height:0.5cqh;border-radius:1cqh}.yg-frame:not(.yg-port) .yg-isheet .yg-how{margin:2cqh 0 0.4cqh;font-size:3.4cqh}.yg-frame:not(.yg-port) .yg-isheet .yg-how li{margin:0.6cqh 0}.yg-frame:not(.yg-port) .yg-isheet .yg-opts{margin:1.4cqh 0 0.2cqh}.yg-frame:not(.yg-port) .yg-isheet .yg-go{margin-top:2cqh;padding:3cqh 13cqh;font-size:6cqh}.yg-frame:not(.yg-port) .yg-isheet .yg-best{margin-top:1.8cqh}.yg-frame:not(.yg-port){width:min(900px,calc(100vw - 24px),calc((100dvh - 24px) * 2.1667));aspect-ratio:780/360;container-type:size;border-radius:26px;}.yg-frame:not(.yg-port) .yg-isheet{left:auto;right:3cqh;top:3cqh;bottom:3cqh;width:43%;display:flex;flex-direction:column;justify-content:center;padding:3.4cqh 5cqh;border-radius:7cqh;}.yg-frame:not(.yg-port) .yg-isheet .yg-how{margin:2.4cqh 0 0.6cqh;font-size:3.7cqh;}.yg-frame:not(.yg-port) .yg-ov:not(.yg-intro){padding:4cqh;}.yg-frame:not(.yg-port) .yg-card{width:auto;min-width:46%;max-width:60%;padding:4.4cqh 7cqh 4cqh;}.yg-frame:not(.yg-port) .yg-hubwrap{display:grid;grid-template-columns:37% minmax(0,1fr);grid-template-rows:auto auto auto 1fr;overflow:hidden;padding:0;background:linear-gradient(180deg,#8fd0ff 0%,#bfe6ff 30%,#bfe6ff 32%,#a8dc8a 32.2%,#8fcf73 100%);}.yg-frame:not(.yg-port) .yg-hhead{grid-column:1;grid-row:1;padding:4.5cqh 4cqh 1cqh;}.yg-frame:not(.yg-port) .yg-htitle{font-size:9cqh;}.yg-frame:not(.yg-port) .yg-hsub{font-size:3.4cqh;margin-top:1.6cqh;}.yg-frame:not(.yg-port) .yg-mute{right:auto;left:3cqh;top:3cqh;width:9cqh;height:9cqh;font-size:4.4cqh;}.yg-frame:not(.yg-port) .yg-me{grid-column:1;grid-row:2;margin:1.6cqh 3cqh 0 4cqh;}.yg-frame:not(.yg-port) .yg-me-st{width:25cqh;height:25cqh;}.yg-frame:not(.yg-port) .yg-strip{grid-column:1;grid-row:3;padding:2.6cqh 3cqh 2cqh 4cqh;}.yg-frame:not(.yg-port) .yg-foot{grid-column:1;grid-row:4;align-self:end;margin:0 4cqh 3cqh;font-size:2.7cqh;}.yg-frame:not(.yg-port) .yg-grid{grid-column:2;grid-row:1 / 5;overflow-y:auto;align-content:start;grid-template-columns:repeat(3,minmax(0,1fr));gap:3cqh;padding:4cqh 4cqh 5cqh 1cqh;scrollbar-width:thin;}.yg-frame:not(.yg-port) .yg-gic{height:19cqh;}.yg-frame:not(.yg-port) .yg-hint{left:auto;right:3cqh;bottom:2.6cqh;max-width:44%;text-align:right;}")));
Invoke(Get(G("document"), "head"), "appendChild", st_1190);
return default;
}, 0, "cssL", false), V.Undef);
Call(Fn((V _self1191, int _argc1192, V _a1194, V _a1195, V _a1196, V _a1197, V[] _rest1193) => {
V st_1198 = default;
if (_self1191.IsNullish) _self1191 = GlobalV;
if (Truthy(Invoke(G("document"), "getElementById", ((V)("yg-v2-css"))))) {
return default;
}
st_1198 = Invoke(G("document"), "createElement", ((V)("style")));
Set(st_1198, "id", ((V)("yg-v2-css")));
Set(st_1198, "textContent", ((V)(JsStrBuf.Begin().S(".yg-ov.yg-show.yg-intro{display:block;padding:0;background:#24103e;}").S(".yg-iart{position:absolute;inset:0;}.yg-iart svg{width:100%;height:100%;display:block;}").S(".yg-iback{position:absolute;left:3cqw;top:3cqw;z-index:2;width:10cqw;height:10cqw;border-radius:50%;border:0;background:#ffffff;color:#6a2fb0;font:700 8cqw/1 Fredoka,sans-serif;box-shadow:0 0.8cqw 0 rgba(40,10,80,0.35);cursor:pointer;padding:0 0 1cqw;}").S(".yg-iback:focus-visible{outline:3px solid #ffffff;outline-offset:2px;}").S(".yg-isheet{position:absolute;left:4cqw;right:4cqw;bottom:4cqw;box-sizing:border-box;background:rgba(255,255,255,0.97);border-radius:7cqw;padding:3.4cqw 5cqw 3.4cqw;text-align:center;").S("box-shadow:0 1.6cqw 0 color-mix(in srgb,var(--gc) 60%,#3b2457),0 5cqw 14cqw rgba(30,8,60,0.35);animation:ygPop .35s cubic-bezier(.2,1.4,.4,1);}").S(".yg-ihead{display:flex;align-items:center;gap:2.4cqw;font:800 3.1cqw/1 Nunito,sans-serif;letter-spacing:0.12em;text-transform:uppercase;color:color-mix(in srgb,var(--gc) 50%,#3b2457);}").S(".yg-ihead::before,.yg-ihead::after{content:\"\";height:0.5cqw;flex:1;border-radius:1cqw;background:color-mix(in srgb,var(--gc) 40%,#ffffff);}").S(".yg-isheet .yg-how{margin:2cqw 0 0.4cqw;font-size:3.4cqw;line-height:1.25;}.yg-isheet .yg-how li{margin:0.6cqw 0;}").S(".yg-isheet .yg-opts{margin:1.4cqw 0 0.2cqw;}.yg-isheet .yg-go{margin-top:2cqw;padding:3cqw 13cqw;font-size:6cqw;}.yg-isheet .yg-best{margin-top:1.8cqw;}").S(".yg-introing .yg-top,.yg-introing .yg-hint{visibility:hidden;}").End())));
Invoke(Get(G("document"), "head"), "appendChild", st_1198);
return default;
}, 0, "css", false), V.Undef);
pid_32 = 0D;
Set(YG_12, "SETS", Arr(((V)("snack")), ((V)("fruit")), ((V)("pet"))));
thumb_36 = Fn((V _arrowThis1206, int _argc1199, V c_1205, V _a1202, V _a1203, V _a1204, V[] _rest1200) => {
V R_1207 = default;
V s_1208 = default;
R_1207 = Get(G("window"), "SquishSquad");
s_1208 = Invoke(R_1207, "src", Get(c_1205, "id"));
return ((Get(G("window"), "SQ_THUMBS") is var _t1209 && !Truthy(_t1209) ? _t1209 : GetK(Get(G("window"), "SQ_THUMBS"), s_1208)) is var _t1210 && Truthy(_t1210) ? _t1210 : s_1208);
return default;
}, 1, "", true);
Set(YG_12, "mount", Fn((V _self1211, int _argc1212, V el_1218, V _a1215, V _a1216, V _a1217, V[] _rest1213) => {
V root_1219 = default;
V app_1220 = default;
V stop_1221 = default;
V hubC_1222 = default;
V frame_1223 = default;
V hubEl_1224 = default;
V drawHub_1225 = default;
if (_self1211.IsNullish) _self1211 = GlobalV;
drawHub_1225 = Fn((V _self1226, int _argc1227, V _a1229, V _a1230, V _a1231, V _a1232, V[] _rest1228) => {
V pc_1233 = default;
V head_1234 = default;
V mute_1235 = default;
V me_1236 = default;
V meSt_1237 = default;
V meTx_1238 = default;
V strip_1239 = default;
V grid_1240 = default;
if (_self1226.IsNullish) _self1226 = GlobalV;
if (Truthy(hubC_1222)) {
Invoke(hubC_1222, "destroy");
hubC_1222 = V.Null;
}
Set(hubEl_1224, "innerHTML", ((V)("")));
pc_1233 = Call(playerC_35, V.Undef);
head_1234 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-hhead"))).V, hubEl_1224);
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-htitle"))).V, head_1234, ((V)("Yard Games")));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-hsub"))).V, head_1234, ((V)("Play with the games in your backyard")));
mute_1235 = Call(D_14, V.Undef, ((V)("button")), NewObj(3).Put("cls", ((V)("yg-mute"))).Put("aria-label", ((V)("Sound on or off"))).Put("onclick", Fn((V _arrowThis1247, int _argc1241, V _a1243, V _a1244, V _a1245, V _a1246, V[] _rest1242) => {
muted_26 = (!(Truthy(muted_26)) ? V.True : V.False);
try {
Invoke(G("localStorage"), "setItem", ((V)(JsStrBuf.Begin().V(LS_22).S(".mute").End())), ((V)((Truthy(muted_26) ? "1" : "0"))));
} catch (System.Exception _ex1248) {
V e_1249 = default;
e_1249 = Caught(_ex1248);

}
Set(mute_1235, "textContent", ((V)((Truthy(muted_26) ? "\ud83d\udd07" : "\ud83d\udd0a"))));
return default;
}, 0, "onclick", true)).V, head_1234, ((V)((Truthy(muted_26) ? "\ud83d\udd07" : "\ud83d\udd0a"))));
me_1236 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-me"))).V, hubEl_1224);
meSt_1237 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-me-st"))).V, me_1236);
meTx_1238 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-me-tx"))).V, me_1236);
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-me-k"))).V, meTx_1238, ((V)("Your player")));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-me-n"))).V, meTx_1238, (Truthy(pc_1233) ? Get(pc_1233, "name") : ((V)("\u2026"))));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-me-h"))).V, meTx_1238, ((V)("Pick anyone below")));
if (Truthy(pc_1233)) {
hubC_1222 = Invoke(YG_12, "creature", meSt_1237, Get(pc_1233, "key"), NewObj(4).Put("x", ((V)((W_10 / 2D)))).Put("y", ((V)((H_11 * 0.92)))).Put("size", ((V)((H_11 * 0.95)))).Put("shadow", ((V)(1D))).V);
OpSet(Get(Get(hubC_1222, "host"), "style"), "cssText", 0, ((V)(";left:0;top:0;width:100%;height:100%;")));
Invoke(hubC_1222, "play", ((V)("happy")));
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis1264, int _argc1258, V _a1260, V _a1261, V _a1262, V _a1263, V[] _rest1259) => {
return (hubC_1222 is var _t1265 && !Truthy(_t1265) ? _t1265 : Invoke(hubC_1222, "play", ((V)("idle"))));
}, 0, "", true), ((V)(2400D)));
}
strip_1239 = Call(D_14, V.Undef, ((V)("div")), NewObj(2).Put("cls", ((V)("yg-strip"))).Put("role", ((V)("list"))).V, hubEl_1224);
Invoke(Call(roster_34, V.Undef), "forEach", Fn((V _arrowThis1273, int _argc1266, V c_1272, V _a1269, V _a1270, V _a1271, V[] _rest1267) => {
V b_1274 = default;
b_1274 = Call(D_14, V.Undef, ((V)("button")), NewObj(5).Put("cls", ((V)(string.Concat("yg-pick", (Truthy((pc_1233 is var _t1275 && !Truthy(_t1275) ? _t1275 : (SEq(Get(c_1272, "id"), Get(pc_1233, "id")) ? V.True : V.False))) ? " on" : ""))))).Put("aria-label", Get(c_1272, "name")).Put("title", Get(c_1272, "name")).Put("role", ((V)("listitem"))).Put("onclick", Fn((V _arrowThis1282, int _argc1276, V _a1278, V _a1279, V _a1280, V _a1281, V[] _rest1277) => {
Set(SAVE_23, "player", Get(c_1272, "id"));
Call(save_24, V.Undef);
Invoke(SFX_30, "pop");
Call(drawHub_1225, V.Undef);
return default;
}, 0, "onclick", true)).V, strip_1239);
Call(D_14, V.Undef, ((V)("img")), NewObj(3).Put("src", Call(thumb_36, V.Undef, c_1272)).Put("alt", ((V)(""))).Put("loading", ((V)("lazy"))).V, b_1274);
return default;
}, 1, "", true));
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis1297, int _argc1291, V _a1293, V _a1294, V _a1295, V _a1296, V[] _rest1292) => {
V on_1290 = default;
on_1290 = Invoke(strip_1239, "querySelector", ((V)(".on")));
if (Truthy(on_1290)) {
Set(strip_1239, "scrollLeft", ((V)(((ToNum(Get(on_1290, "offsetLeft")) - (ToNum(Get(strip_1239, "clientWidth")) / 2D)) + (ToNum(Get(on_1290, "offsetWidth")) / 2D)))));
}
return default;
}, 0, "", true), ((V)(30D)));
grid_1240 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-grid"))).V, hubEl_1224);
Invoke(Get(YG_12, "GAMES"), "forEach", Fn((V _arrowThis1305, int _argc1298, V G_1304, V _a1301, V _a1302, V _a1303, V[] _rest1299) => {
V b_1306 = default;
V ic_1307 = default;
b_1306 = Call(D_14, V.Undef, ((V)("button")), NewObj(3).Put("cls", ((V)("yg-gcard"))).Put("style", ((V)(JsStrBuf.Begin().S("--gc:").V((Get(G_1304, "color") is var _t1308 && Truthy(_t1308) ? _t1308 : ((V)("#ff8a3d")))).End()))).Put("onclick", Fn((V _arrowThis1315, int _argc1309, V _a1311, V _a1312, V _a1313, V _a1314, V[] _rest1310) => {
Invoke(SFX_30, "pop");
Invoke(app_1220, "play", G_1304);
return default;
}, 0, "onclick", true)).V, grid_1240);
ic_1307 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-gic"))).V, b_1306);
Set(ic_1307, "innerHTML", (Get(G_1304, "icon") is var _t1316 && Truthy(_t1316) ? _t1316 : ((V)(""))));
if (Truthy((Get(ic_1307, "firstChild") is var _t1317 && !Truthy(_t1317) ? _t1317 : Get(Get(ic_1307, "firstChild"), "setAttribute")))) {
Invoke(Get(ic_1307, "firstChild"), "setAttribute", ((V)("preserveAspectRatio")), ((V)("xMidYMid slice")));
}
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-gname"))).V, b_1306, Get(G_1304, "name"));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-gitem"))).V, b_1306, Get(G_1304, "item"));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-gbest"))).V, b_1306, ((V)((Truthy(GetK(Get(SAVE_23, "best"), Get(G_1304, "id"))) ? JsStrBuf.Begin().S("\u2605 Best ").V(GetK(Get(SAVE_23, "best"), Get(G_1304, "id"))).End() : "New!"))));
return default;
}, 1, "", true));
Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-foot"))).V, hubEl_1224, ((V)("Examples of the backyard mini games. Coins are shown as a preview and not added to your wallet.")));
return default;
}, 0, "drawHub", false);
Set(el_1218, "innerHTML", ((V)("")));
root_1219 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-root"))).V, el_1218);
app_1220 = NewObj(1).Put("root", root_1219).V;
stop_1221 = V.Null;
hubC_1222 = V.Null;
frame_1223 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-frame"))).V, root_1219);
Set(app_1220, "frame", frame_1223);
Set(app_1220, "stage", Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-stage"))).V, frame_1223));
hubEl_1224 = Call(D_14, V.Undef, ((V)("div")), NewObj(1).Put("cls", ((V)("yg-hubwrap"))).V, frame_1223);
Set(app_1220, "hub", Fn((V _arrowThis1324, int _argc1318, V _a1320, V _a1321, V _a1322, V _a1323, V[] _rest1319) => {
if (Truthy(stop_1221)) {
Call(stop_1221, V.Undef);
stop_1221 = V.Null;
}
W_10 = 780D;
H_11 = 360D;
Set(YG_12, "W", ((V)(W_10)));
Set(YG_12, "H", ((V)(H_11)));
Invoke(Get(frame_1223, "classList"), "remove", ((V)("yg-port")));
Set(Get(app_1220, "stage"), "innerHTML", ((V)("")));
Set(Get(Get(app_1220, "stage"), "style"), "display", ((V)("none")));
Set(Get(hubEl_1224, "style"), "display", ((V)("")));
Call(drawHub_1225, V.Undef);
return default;
}, 0, "", true));
Set(app_1220, "play", Fn((V _arrowThis1332, int _argc1325, V G_1331, V _a1328, V _a1329, V _a1330, V[] _rest1326) => {
if (Truthy(stop_1221)) {
Call(stop_1221, V.Undef);
stop_1221 = V.Null;
}
if (Truthy(hubC_1222)) {
Invoke(hubC_1222, "destroy");
hubC_1222 = V.Null;
}
Invoke(Get(frame_1223, "classList"), "toggle", ((V)("yg-port")), (!(Truthy(Get(G_1331, "land"))) ? V.True : V.False));
Set(Get(hubEl_1224, "style"), "display", ((V)("none")));
Set(Get(Get(app_1220, "stage"), "style"), "display", ((V)("")));
stop_1221 = Call(run_33, V.Undef, app_1220, G_1331);
return default;
}, 1, "", true));
Set(YG_12, "_hub", Fn((V _arrowThis1339, int _argc1333, V _a1335, V _a1336, V _a1337, V _a1338, V[] _rest1334) => {
if (!(Truthy(stop_1221))) {
Call(drawHub_1225, V.Undef);
}
return default;
}, 0, "", true));
Set(YG_12, "_app", app_1220);
Invoke(app_1220, "hub");
return app_1220;
return default;
}, 1, "", false));
return default;
}, 0, "", false), V.Undef);
        }
    }
}
