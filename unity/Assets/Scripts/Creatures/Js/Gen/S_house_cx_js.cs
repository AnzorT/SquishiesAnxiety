// house-cx.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_house_cx_js
    {

        public static void Run()
        {
Set(G("window"), "HouseCreatures", (Get(G("window"), "HouseCreatures") is var _t1 && Truthy(_t1) ? _t1 : Arr()));
Invoke(Get(G("window"), "HouseCreatures"), "push", Fn((V _self2, int _argc3, V H_9, V _a6, V _a7, V _a8, V[] _rest4) => {
V R_10 = default;
V REST_11 = default;
V TL_12 = default;
V BEAT_13 = default;
V hand_14 = default;
V both_15 = default;
V SIDE_16 = default;
V SIT0_17 = default;
V PROF_18 = default;
V BB_19 = default;
V ICON_20 = default;
V o_21 = default;
V sitdown_22 = default;
V standup_23 = default;
V gnd_24 = default;
V rside_25 = default;
V G_26 = default;
V facing_27 = default;
V ss_28 = default;
V cl_29 = default;
V r2_30 = default;
V shade_31 = default;
V ci_32 = default;
V pa_33 = default;
V lerp_34 = default;
V okp_35 = default;
V BATH0_36 = default;
V K_37 = default;
V ST0_38 = default;
V S0_39 = default;
V hold_40 = default;
V flyF_41 = default;
V g0_42 = default;
V mid_43 = default;
V hx_44 = default;
V mixC_45 = default;
V push_46 = default;
V cheer_47 = default;
V frown_48 = default;
V COM_49 = default;
V kickCore_50 = default;
V kickMove_51 = default;
V BW0_52 = default;
V BWB_53 = default;
V DS0_54 = default;
V DSB_55 = default;
V PLATE_56 = default;
V SPONGE_57 = default;
V dishProp_58 = default;
V GR0_59 = default;
V GRB_60 = default;
V TONGS_61 = default;
V PATTY_62 = default;
V grillProp_63 = default;
V TW0_64 = default;
V TWB_65 = default;
V TOAST_66 = default;
V toastMove_67 = default;
V POB_68 = default;
V SP0_69 = default;
V SPB_70 = default;
V splashIn_71 = default;
V splashOut_72 = default;
V shellMove_73 = default;
V PF0_74 = default;
V PFB_75 = default;
V MIC_76 = default;
V micProp_77 = default;
V DJ0_78 = default;
V DJB_79 = default;
V phoneProp_80 = default;
V PB0_81 = default;
V PBB_82 = default;
V DC0_83 = default;
V DCB_84 = default;
V HK0_85 = default;
V HKB_86 = default;
V PADDLE_87 = default;
V PPAD_88 = default;
V puckProp_89 = default;
V BL0_90 = default;
V BLB_91 = default;
V cueProp_92 = default;
V ICX_93 = default;
V GOB_94 = default;
V goalProp_95 = default;
V KP0_96 = default;
V dive_97 = default;
V KPB_98 = default;
V keepProp_99 = default;
V HPB_100 = default;
V hoopProp_101 = default;
V GF0_102 = default;
V GFB_103 = default;
V golfProp_104 = default;
V DMU_105 = default;
V DMB_106 = default;
V AGB_107 = default;
V tossB_108 = default;
V aimB_109 = default;
V tossProp_110 = default;
V PG0_111 = default;
V PGB_112 = default;
V TTB_113 = default;
V HSB_114 = default;
V hopProp_115 = default;
V TU0_116 = default;
V TUB_117 = default;
V FRB_118 = default;
V frisbeeProp_119 = default;
V CX_120 = default;
V cBuild_121 = default;
if (_self2.IsNullish) _self2 = GlobalV;
hold_40 = Fn((V _self122, int _argc123, V B_129, V ord_130, V BK_131, V X_132, V[] _rest124) => {
V t_136 = default;
V v_137 = default;
V bt_138 = default;
V rec_139 = default;
V st_140 = default;
V sig_133 = default;
V gaps_134 = default;
V ex_135 = default;
if (_self122.IsNullish) _self122 = GlobalV;
sig_133 = (_argc123 > 4 ? _rest124[0] : V.Undef);
gaps_134 = (_argc123 > 5 ? _rest124[1] : V.Undef);
ex_135 = (_argc123 > 6 ? _rest124[2] : V.Undef);
t_136 = Call(TL_12, V.Undef, B_129);
v_137 = NewObj(0).V;
Invoke(Call(K_37, V.Undef, B_129), "forEach", Fn((V _arrowThis148, int _argc141, V p_147, V _a144, V _a145, V _a146, V[] _rest142) => {
return SetK(v_137, p_147, GetK(B_129, p_147));
}, 1, "", true));
Invoke(t_136, "to", ((V)(10D)), v_137);
Set(t_136, "B", Call(o_21, V.Undef, REST_11, B_129));
bt_138 = Arr();
rec_139 = NewObj(0).V;
Invoke(ord_130, "forEach", Fn((V _arrowThis157, int _argc149, V n_155, V i_156, V _a153, V _a154, V[] _rest150) => {
V a_158 = default;
Invoke(t_136, "wait", GetIdx(gaps_134, (ToNum(i_156) % ToNum(Get(gaps_134, "length")))));
a_158 = Get(t_136, "t");
if (SEqS(n_155, "sig")) {
if (!(Truthy(sig_133))) {
return default;
}
Call(sig_133, V.Undef, t_136);
} else {
if (Truthy(GetK(BK_131, n_155))) {
InvokeK(BK_131, n_155, t_136, X_132, rec_139);
} else {
if (Truthy(GetK(BEAT_13, n_155))) {
InvokeK(BEAT_13, n_155, t_136);
} else {
return default;
}
}
}
Invoke(bt_138, "push", Arr(n_155, a_158, Get(t_136, "t")));
return default;
}, 2, "", true));
Invoke(t_136, "wait", ((V)(800D)));
st_140 = Invoke(t_136, "out", Call(o_21, V.Undef, NewObj(3).Put("breathe", ((V)(0.5))).Put("look", (false ? V.True : V.False)).Put("blend", ((V)(420D))).V, (ex_135 is var _t159 && Truthy(_t159) ? _t159 : NewObj(0).V)), (true ? V.True : V.False));
Set(st_140, "beats", bt_138);
Set(st_140, "rec", rec_139);
return st_140;
return default;
}, 7, "hold", false);
cheer_47 = Fn((V _self160, int _argc161, V t_167, V X_168, V ex_169, V _a166, V[] _rest162) => {
V B_170 = default;
V L_171 = default;
V Q_172 = default;
if (_self160.IsNullish) _self160 = GlobalV;
B_170 = Get(t_167, "B");
L_171 = (Get(B_170, "lift") is var _t173 && Truthy(_t173) ? _t173 : ((V)(0D)));
Q_172 = (Get(B_170, "sq") is var _t174 && Truthy(_t174) ? _t174 : ((V)(0D)));
Invoke(t_167, "to", ((V)(260D)), Call(o_21, V.Undef, NewObj(13).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("hLx", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hLy", ((V)((-4D)))).Put("hRy", ((V)((-4D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(1D))).Put("wide", ((V)(0.4))).Put("sq", ((V)((ToNum(Q_172) - 0.04)))).Put("frown", ((V)(0D))).V, (ex_169 is var _t175 && Truthy(_t175) ? _t175 : NewObj(0).V), Get(X_168, "cheer")), ((V)("o")));
if (Truthy(Get(X_168, "cheerFx"))) {
InvokeSpread(t_167, "fx", new ArrBuilder().Spread(Get(X_168, "cheerFx")).V);
} else {
Invoke(t_167, "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
}
Invoke(Invoke(Invoke(Invoke(t_167, "to", ((V)(150D)), NewObj(2).Put("lift", Add(L_171, ((V)(5D)))).Put("sq", ((V)((ToNum(Q_172) - 0.08)))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(2).Put("lift", L_171).Put("sq", Add(Q_172, ((V)(0.06)))).V, ((V)("i"))), "to", ((V)(150D)), NewObj(1).Put("sq", Q_172).V, ((V)("o"))), "osc", ((V)(800D)), ((V)(3D)), NewObj(2).Put("armL", ((V)(130D))).Put("armR", ((V)(165D))).V, NewObj(2).Put("armL", ((V)(165D))).Put("armR", ((V)(130D))).V, ((V)("io")));
return Invoke(t_167, "back", ((V)(420D)));
return default;
}, 3, "cheer", false);
frown_48 = Fn((V _self176, int _argc177, V t_183, V _a180, V _a181, V _a182, V[] _rest178) => {
V B_184 = default;
V Q_185 = default;
if (_self176.IsNullish) _self176 = GlobalV;
B_184 = Get(t_183, "B");
Q_185 = (Get(B_184, "sq") is var _t186 && Truthy(_t186) ? _t186 : ((V)(0D)));
Invoke(Invoke(Invoke(Invoke(t_183, "to", ((V)(240D)), NewObj(6).Put("frown", ((V)(0.5))).Put("wide", ((V)(0.6))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).Put("sq", Add(Q_185, ((V)(0.05)))).Put("pitch", ((V)((ToNum((Get(B_184, "pitch") is var _t187 && Truthy(_t187) ? _t187 : ((V)(0D)))) - 0.1)))).V, ((V)("o"))), "wait", ((V)(600D))), "to", ((V)(260D)), NewObj(7).Put("frown", ((V)(0D))).Put("sqz", ((V)(0.6))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).Put("wide", ((V)(0D))).Put("open", ((V)(0.25))).Put("mw", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(3D)), NewObj(1).Put("sq", Add(Q_185, ((V)(0.03)))).V, NewObj(1).Put("sq", Q_185).V, ((V)("o")));
return Invoke(t_183, "back", ((V)(380D)));
return default;
}, 1, "frown", false);
kickCore_50 = Fn((V _self188, int _argc189, V t_195, V X_196, V _a193, V _a194, V[] _rest190) => {
V ks_197 = default;
V hit_198 = default;
if (_self188.IsNullish) _self188 = GlobalV;
ks_197 = (Get(X_196, "ks") is var _t199 && Truthy(_t199) ? _t199 : ((V)("foot")));
hit_198 = V.Undef;
if (SEqS(ks_197, "head")) {
Invoke(Invoke(t_195, "to", ((V)(300D)), NewObj(4).Put("pitch", ((V)(0.12))).Put("lean", ((V)((-1D)))).Put("sq", ((V)(0.08))).Put("lift", ((V)((-0.6)))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(5).Put("pitch", ((V)((-0.34)))).Put("lean", ((V)(1.6))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(2.4))).Put("close", ((V)(1D))).V, ((V)("o")));
hit_198 = Get(t_195, "t");
Invoke(Invoke(t_195, "fx", ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(260D)), NewObj(5).Put("pitch", ((V)(0D))).Put("lean", ((V)(0.4))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).Put("close", ((V)(0D))).V, ((V)("io")));
} else {
if (SEqS(ks_197, "tail")) {
Invoke(Invoke(t_195, "to", ((V)(320D)), NewObj(4).Put("spin", ((V)((-40D)))).Put("sq", ((V)(0.06))).Put("wag", ((V)((-20D)))).Put("tsw", ((V)((-0.6)))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(4).Put("spin", ((V)(150D))).Put("wag", ((V)(34D))).Put("tsw", ((V)(1D))).Put("sq", ((V)((-0.04)))).V, ((V)("o")));
hit_198 = ((V)((ToNum(Get(t_195, "t")) - 80D)));
Invoke(Invoke(t_195, "fx", ((V)("splash")), ((V)("body")), ((V)(2D))), "to", ((V)(420D)), NewObj(4).Put("spin", ((V)(0D))).Put("wag", ((V)(0D))).Put("tsw", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
} else {
if (SEqS(ks_197, "body")) {
Invoke(Invoke(t_195, "to", ((V)(320D)), NewObj(4).Put("x", ((V)((-1.6)))).Put("tilt", ((V)((-6D)))).Put("sq", ((V)(0.1))).Put("lean", ((V)((-0.8)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(5).Put("x", ((V)(2.4))).Put("tilt", ((V)(8D))).Put("sq", ((V)((-0.08)))).Put("lean", ((V)(1.4))).Put("lift", ((V)(2D))).V, ((V)("o")));
hit_198 = Get(t_195, "t");
Invoke(Invoke(t_195, "fx", ((V)("dust")), ((V)("belly")), ((V)(3D))), "to", ((V)(300D)), NewObj(5).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("sq", ((V)(0.04))).Put("lean", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("i")));
} else {
if (SEqS(ks_197, "flip")) {
Invoke(Invoke(t_195, "to", ((V)(320D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)((-6D))), ((V)((-2D)))), NewObj(3).Put("armR", ((V)(70D))).Put("lean", ((V)((-0.8)))).Put("tilt", ((V)((-3D)))).V), ((V)("io"))), "to", ((V)(150D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(10D)), ((V)(4D))), NewObj(4).Put("armR", ((V)(18D))).Put("lean", ((V)(1.2))).Put("tilt", ((V)(4D))).Put("sq", ((V)((-0.04)))).V), ((V)("o")));
hit_198 = Get(t_195, "t");
Invoke(t_195, "to", ((V)(300D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D))), NewObj(4).Put("armR", ((V)(20D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("sq", ((V)(0D))).V), ((V)("io")));
} else {
Invoke(Invoke(t_195, "to", ((V)(300D)), NewObj(6).Put("lean", ((V)((-1D)))).Put("footR", ((V)(0.4))).Put("armL", ((V)(50D))).Put("armR", ((V)(4D))).Put("sq", ((V)(0.06))).Put("tilt", ((V)((-2D)))).V, ((V)("io"))), "to", ((V)(130D)), NewObj(7).Put("lean", ((V)(1.4))).Put("footR", ((V)(3.6))).Put("armL", ((V)(10D))).Put("armR", ((V)(64D))).Put("sq", ((V)((-0.05)))).Put("lift", ((V)(1.4))).Put("tilt", ((V)(3D))).V, ((V)("o")));
hit_198 = ((V)((ToNum(Get(t_195, "t")) - 30D)));
Invoke(Invoke(t_195, "fx", ((V)("dust")), ((V)("footR")), ((V)(3D))), "to", ((V)(280D)), NewObj(7).Put("footR", ((V)(0D))).Put("lean", ((V)(0.3))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.03))).Put("tilt", ((V)(0D))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io")));
}
}
}
}
return hit_198;
return default;
}, 2, "kickCore", false);
kickMove_51 = Fn((V _self200, int _argc201, V X_207, V _a204, V _a205, V _a206, V[] _rest202) => {
V t_208 = default;
V hit_209 = default;
V st_210 = default;
if (_self200.IsNullish) _self200 = GlobalV;
t_208 = Call(TL_12, V.Undef, REST_11);
Set(t_208, "B", Call(o_21, V.Undef, REST_11));
Invoke(t_208, "to", ((V)(320D)), NewObj(6).Put("lx", ((V)(0.7))).Put("ly", ((V)(0.6))).Put("pitch", ((V)((-0.1)))).Put("sqz", ((V)(0.3))).Put("smile", ((V)(0.8))).Put("hap", ((V)(0.5))).V, ((V)("io")));
hit_209 = Call(kickCore_50, V.Undef, t_208, X_207);
Invoke(Invoke(t_208, "to", ((V)(320D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-15D)))), NewObj(8).Put("armR", ((V)(118D))).Put("lx", ((V)(0.9))).Put("ly", ((V)((-0.3)))).Put("htilt", ((V)(6D))).Put("wide", ((V)(0.5))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.6))).Put("sqz", ((V)(0D))).V), ((V)("io"))), "wait", ((V)(700D)));
Invoke(Invoke(Invoke(t_208, "to", ((V)(240D)), Call(o_21, V.Undef, NewObj(13).Put("armR", ((V)(150D))).Put("armL", ((V)(150D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)((-4D)))).Put("hLy", ((V)((-4D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("sqz", ((V)(0.7))).Put("open", ((V)(0.4))).Put("mw", ((V)(1D))).Put("htilt", ((V)(0D))).Put("wide", ((V)(0D))).Put("lx", ((V)(0.4))).V, Get(X_207, "cheer")), ((V)("o"))), "to", ((V)(140D)), NewObj(2).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.06)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i")));
Invoke(t_208, "back", ((V)(420D)));
st_210 = Invoke(t_208, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(180D))).V);
Set(st_210, "hit", hit_209);
return st_210;
return default;
}, 1, "kickMove", false);
dishProp_58 = Fn((V _self211, int _argc212, V st_218, V _a215, V _a216, V _a217, V[] _rest213) => {
V R0_219 = default;
if (_self211.IsNullish) _self211 = GlobalV;
R0_219 = Get(st_218, "rec");
return Fn((V _arrowThis228, int _argc220, V I_226, V tt_227, V _a224, V _a225, V[] _rest221) => {
V W_229 = default;
V f0_230 = default;
double tl_231 = 0;
V gx_232 = default;
V gy_233 = default;
V sx_234 = default;
double sy_235 = 0;
V Sk_236 = default;
V done_237 = default;
V cur_238 = default;
V last_239 = default;
V scr_240 = default;
V dirt_241 = default;
JsStrBuf h_242 = null;
W_229 = Get(I_226, "W");
if (((!(Truthy(W_229)) || !(Truthy(Call(okp_35, V.Undef, Get(W_229, "pawL"))))) || !(Truthy(Call(okp_35, V.Undef, Get(W_229, "pawR")))))) {
return ((V)(""));
}
f0_230 = Call(facing_27, V.Undef, I_226);
if (LtN(f0_230, 0.02)) {
return ((V)(""));
}
tl_231 = (ToNum(tt_227) % ToNum(Get(st_218, "loop")));
{ V _t243 = Call(g0_42, V.Undef, I_226);
{ V _t244 = ListOf(_t243);
{ V _t245 = GetIdx(_t244, 0D);
gx_232 = _t245; }
{ V _t246 = GetIdx(_t244, 1D);
gy_233 = _t246; }
} }
sx_234 = Add(Call(rside_25, V.Undef, I_226, gx_232), ((V)(4D)));
sy_235 = (ToNum(gy_233) - 22D);
Sk_236 = (Get(R0_219, "st") is var _t247 && Truthy(_t247) ? _t247 : Arr());
done_237 = Get(Invoke(Sk_236, "filter", Fn((V _arrowThis255, int _argc248, V q_254, V _a251, V _a252, V _a253, V[] _rest249) => {
return (Ge(((V)(tl_231)), GetIdx(q_254, 1D)) ? V.True : V.False);
}, 1, "", true)), "length");
cur_238 = Invoke(Sk_236, "find", Fn((V _arrowThis263, int _argc256, V q_262, V _a259, V _a260, V _a261, V[] _rest257) => {
return ((Ge(((V)(tl_231)), GetIdx(q_262, 0D)) && Lt(((V)(tl_231)), Add(GetIdx(q_262, 1D), ((V)(500D))))) ? V.True : V.False);
}, 1, "", true));
last_239 = ((V)(0D));
Invoke(Sk_236, "forEach", Fn((V _arrowThis271, int _argc264, V q_270, V _a267, V _a268, V _a269, V[] _rest265) => {
if (Ge(((V)(tl_231)), GetIdx(q_270, 1D))) {
last_239 = GetIdx(q_270, 1D);
}
return default;
}, 1, "", true));
scr_240 = ((V)(0D));
Invoke((Get(R0_219, "sc") is var _t284 && Truthy(_t284) ? _t284 : Arr()), "forEach", Fn((V _arrowThis283, int _argc272, V _a274, V _a275, V _a276, V _a277, V[] _rest273) => {
V a_280 = default;
V b_282 = default;
{ V _t278 = ListOf(_a274);
{ V _t279 = GetIdx(_t278, 0D);
a_280 = _t279; }
{ V _t281 = GetIdx(_t278, 1D);
b_282 = _t281; }
}
if ((Gt(b_282, last_239) && LtN(a_280, tl_231))) {
scr_240 = Add(scr_240, Call(cl_29, V.Undef, ((V)(((Min(tl_231, ToNum(b_282)) - Max(ToNum(a_280), ToNum(last_239))) / (ToNum(b_282) - ToNum(a_280))))), ((V)(0D)), ((V)(1D))));
}
return default;
}, 1, "", true));
dirt_241 = Call(cl_29, V.Undef, ((V)((1D - (ToNum(scr_240) * 0.75)))), ((V)(0D)), ((V)(1D)));
h_242 = new JsStrBuf("");
{
double i_285 = 0;
i_285 = 0D;
while (true) {
if (!(Lt(((V)(i_285)), done_237))) break;
h_242.V(Call(G_26, V.Undef, sx_234, ((V)((sy_235 - (i_285 * 1.8)))), ((V)(0D)), ((V)(2.3)), Call(PLATE_56, V.Undef, ((V)(0D)))));
i_285++;
}
}
if (Truthy((cur_238 is var _t287 && !Truthy(_t287) ? _t287 : (Lt(((V)(tl_231)), GetIdx(cur_238, 1D)) ? V.True : V.False)))) {
V u_288 = default;
u_288 = Call(ss_28, V.Undef, ((V)(((tl_231 - ToNum(GetIdx(cur_238, 0D))) / (ToNum(GetIdx(cur_238, 1D)) - ToNum(GetIdx(cur_238, 0D)))))));
h_242.V(Call(G_26, V.Undef, Call(lerp_34, V.Undef, GetIdx(Get(W_229, "pawL"), 0D), sx_234, u_288), Call(lerp_34, V.Undef, ((V)((ToNum(GetIdx(Get(W_229, "pawL"), 1D)) - 1D))), ((V)((sy_235 - (ToNum(done_237) * 1.8)))), u_288), ((V)(0D)), ((V)(2.3)), Call(PLATE_56, V.Undef, ((V)(0D))), f0_230));
} else {
V fi_289 = default;
fi_289 = (Truthy(cur_238) ? Call(ss_28, V.Undef, ((V)((((tl_231 - ToNum(GetIdx(cur_238, 1D))) - 200D) / 300D)))) : ((V)(1D)));
if (GtN(fi_289, 0.02)) {
h_242.V(Call(G_26, V.Undef, GetIdx(Get(W_229, "pawL"), 0D), ((V)((ToNum(GetIdx(Get(W_229, "pawL"), 1D)) - 1D))), ((V)((-8D))), ((V)((2.3 * (0.6 + (0.4 * ToNum(fi_289)))))), Call(PLATE_56, V.Undef, dirt_241), ((V)((ToNum(f0_230) * ToNum(fi_289))))));
}
}
return ((V)(JsStrBuf.Begin().S(h_242.Str).V(Call(G_26, V.Undef, GetIdx(Get(W_229, "pawR"), 0D), ((V)((ToNum(GetIdx(Get(W_229, "pawR"), 1D)) - 1D))), ((V)(10D)), ((V)(2.1)), SPONGE_57, f0_230)).End()));
return default;
}, 2, "", true);
return default;
}, 1, "dishProp", false);
grillProp_63 = Fn((V _self290, int _argc291, V st_297, V _a294, V _a295, V _a296, V[] _rest292) => {
V R0_298 = default;
double TL0_299 = 0;
double an_300 = 0;
if (_self290.IsNullish) _self290 = GlobalV;
R0_298 = Get(st_297, "rec");
TL0_299 = (13D * 1.75);
an_300 = (((-14D) * System.Math.PI) / 180D);
return Fn((V _arrowThis309, int _argc301, V I_307, V tt_308, V _a305, V _a306, V[] _rest302) => {
V W_310 = default;
V f0_311 = default;
double tl_312 = 0;
V p_313 = default;
V tip_314 = default;
V gy_315 = default;
V ck_316 = default;
V sv_317 = default;
V fl_318 = default;
V h_319 = default;
W_310 = Get(I_307, "W");
if ((!(Truthy(W_310)) || !(Truthy(Call(okp_35, V.Undef, Get(W_310, "pawR")))))) {
return ((V)(""));
}
f0_311 = Call(facing_27, V.Undef, I_307);
if (LtN(f0_311, 0.02)) {
return ((V)(""));
}
tl_312 = (ToNum(tt_308) % ToNum(Get(st_297, "loop")));
p_313 = Get(W_310, "pawR");
tip_314 = Arr(Add(GetIdx(p_313, 0D), ((V)((TL0_299 * FdLibm.Cos(an_300))))), Add(GetIdx(p_313, 1D), ((V)((TL0_299 * FdLibm.Sin(an_300))))));
gy_315 = Add(GetIdx(p_313, 1D), ((V)(5D)));
ck_316 = Call(cl_29, V.Undef, ((V)((tl_312 / (ToNum(Get(st_297, "loop")) * 0.8)))), ((V)(0D)), ((V)(1D)));
sv_317 = Invoke((Get(R0_298, "sv") is var _t328 && Truthy(_t328) ? _t328 : Arr()), "find", Fn((V _arrowThis327, int _argc320, V q_326, V _a323, V _a324, V _a325, V[] _rest321) => {
return ((Ge(((V)(tl_312)), GetIdx(q_326, 0D)) && Lt(((V)(tl_312)), Add(GetIdx(q_326, 1D), ((V)(300D))))) ? V.True : V.False);
}, 1, "", true));
fl_318 = Invoke((Get(R0_298, "fl") is var _t337 && Truthy(_t337) ? _t337 : Arr()), "find", Fn((V _arrowThis336, int _argc329, V a_335, V _a332, V _a333, V _a334, V[] _rest330) => {
return ((Ge(((V)(tl_312)), a_335) && Lt(((V)(tl_312)), Add(a_335, ((V)(800D))))) ? V.True : V.False);
}, 1, "", true));
h_319 = Call(G_26, V.Undef, Add(GetIdx(tip_314, 0D), ((V)(12D))), gy_315, ((V)(0D)), ((V)(2D)), Call(PATTY_62, V.Undef, ((V)((ToNum(ck_316) * 0.8)))), f0_311);
if (Truthy(sv_317)) {
h_319 = Add(h_319, Call(G_26, V.Undef, GetIdx(tip_314, 0D), Add(GetIdx(tip_314, 1D), ((V)(0.6))), ((V)(0D)), ((V)(2D)), Call(PATTY_62, V.Undef, ((V)(1D))), f0_311));
} else {
if (!fl_318.IsNullish) {
double u_338 = 0;
u_338 = ((tl_312 - ToNum(fl_318)) / 800D);
h_319 = Add(h_319, Call(G_26, V.Undef, Add(GetIdx(tip_314, 0D), ((V)(1D))), ((V)((ToNum(Call(lerp_34, V.Undef, Add(GetIdx(tip_314, 1D), ((V)(1D))), gy_315, ((V)(u_338)))) - (FdLibm.Sin((System.Math.PI * u_338)) * 16D)))), ((V)((360D * ToNum(Call(ss_28, V.Undef, ((V)(u_338))))))), ((V)(2D)), Call(PATTY_62, V.Undef, ck_316), f0_311));
} else {
h_319 = Add(h_319, Call(G_26, V.Undef, Add(GetIdx(tip_314, 0D), ((V)(1D))), gy_315, ((V)(0D)), ((V)(2D)), Call(PATTY_62, V.Undef, ck_316), f0_311));
}
}
return Add(Call(G_26, V.Undef, GetIdx(p_313, 0D), GetIdx(p_313, 1D), ((V)((-14D))), ((V)(1.75)), TONGS_61, f0_311), h_319);
return default;
}, 2, "", true);
return default;
}, 1, "grillProp", false);
toastMove_67 = Fn((V _self339, int _argc340, V X_346, V _a343, V _a344, V _a345, V[] _rest341) => {
V t_347 = default;
V c_348 = default;
V st_349 = default;
if (_self339.IsNullish) _self339 = GlobalV;
t_347 = Call(TL_12, V.Undef, TW0_64);
Set(t_347, "B", Call(o_21, V.Undef, REST_11, TW0_64));
Invoke(Invoke(t_347, "to", ((V)(90D)), NewObj(9).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.5))).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.08)))).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).Put("lx", ((V)(0.9))).Put("ly", ((V)((-0.6)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i")));
Invoke(t_347, "to", ((V)(260D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(9D)), ((V)((-11D)))), NewObj(4).Put("armL", ((V)(56D))).Put("armR", ((V)(56D))).Put("ly", ((V)((-0.4)))).Put("lx", ((V)(0.3))).V), ((V)("io")));
c_348 = Get(t_347, "t");
Invoke(t_347, "to", ((V)(120D)), NewObj(1).Put("sq", ((V)(0.06))).V, ((V)("i")));
Invoke(Invoke(t_347, "osc", ((V)(1000D)), ((V)(5D)), NewObj(4).Put("hLx", ((V)(12D))).Put("hRx", ((V)((-6D)))).Put("sqz", ((V)(0.8))).Put("tilt", ((V)(2D))).V, NewObj(3).Put("hLx", ((V)(6D))).Put("hRx", ((V)((-12D)))).Put("tilt", ((V)((-2D)))).V, ((V)("l"))), "fx", ((V)("sweat")), ((V)("head")), ((V)(1D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_347, "to", ((V)(200D)), NewObj(5).Put("puff", ((V)(0.8))).Put("open", ((V)(0D))).Put("sqz", ((V)(0D))).Put("ly", ((V)(0.3))).Put("lx", ((V)(0D))).V), "to", ((V)(160D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).Put("mw", ((V)(0.45))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("mouth")), ((V)(1D))), "to", ((V)(200D)), NewObj(2).Put("puff", ((V)(0.7))).Put("open", ((V)(0D))).V), "to", ((V)(160D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("mouth")), ((V)(1D)));
Invoke(Invoke(Invoke(t_347, "to", ((V)(260D)), Call(o_21, V.Undef, NewObj(7).Put("sqz", ((V)(0.7))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("mw", ((V)(1D))).Put("wide", ((V)(0D))).Put("tilt", ((V)(0D))).V, Get(X_346, "cheer")), ((V)("o"))), "fx", ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(300D)));
st_349 = Invoke(t_347, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(160D))).V);
Set(st_349, "prop", Fn((V _arrowThis358, int _argc350, V I_356, V tt_357, V _a354, V _a355, V[] _rest351) => {
V W_359 = default;
double f0_360 = 0;
V m_361 = default;
V gx_362 = default;
V s0_363 = default;
V x_364 = default;
double y_365 = 0;
double r_366 = 0;
W_359 = Get(I_356, "W");
if ((!(Truthy(W_359)) || !(Truthy(Call(okp_35, V.Undef, Get(W_359, "pawR")))))) {
return ((V)(""));
}
f0_360 = Max(0.35, ToNum(Call(facing_27, V.Undef, I_356)));
m_361 = Call(mid_43, V.Undef, W_359);
{ V _t367 = Call(g0_42, V.Undef, I_356);
{ V _t368 = ListOf(_t367);
{ V _t369 = GetIdx(_t368, 0D);
gx_362 = _t369; }
} }
s0_363 = Arr(Add(Call(rside_25, V.Undef, I_356, gx_362), ((V)(2D))), ((V)((ToNum(GetIdx(Get(W_359, "pawR"), 1D)) - 8D))));
x_364 = GetIdx(m_361, 0D);
y_365 = (ToNum(GetIdx(m_361, 1D)) - 3D);
r_366 = 0D;
if (Lt(tt_357, c_348)) {
V u_370 = default;
u_370 = Call(cl_29, V.Undef, ((V)((ToNum(tt_357) / ToNum(c_348)))), ((V)(0D)), ((V)(1D)));
x_364 = Call(lerp_34, V.Undef, GetIdx(s0_363, 0D), GetIdx(m_361, 0D), u_370);
y_365 = (ToNum(Call(lerp_34, V.Undef, GetIdx(s0_363, 1D), ((V)((ToNum(GetIdx(m_361, 1D)) - 3D))), u_370)) - (FdLibm.Sin((System.Math.PI * ToNum(u_370))) * 24D));
r_366 = (400D * ToNum(u_370));
}
return Call(G_26, V.Undef, x_364, ((V)(y_365)), ((V)(r_366)), ((V)(2.6)), TOAST_66, ((V)(f0_360)));
return default;
}, 2, "", true));
return st_349;
return default;
}, 1, "toastMove", false);
splashIn_71 = Fn((V _self371, int _argc372, V B_378, V P_379, V _a376, V _a377, V[] _rest373) => {
V t_380 = default;
V v_381 = default;
if (_self371.IsNullish) _self371 = GlobalV;
t_380 = Call(TL_12, V.Undef, REST_11);
Set(t_380, "B", Call(o_21, V.Undef, REST_11));
if (SEqS(Get(P_379, "dn"), "float")) {
Invoke(Invoke(t_380, "to", ((V)(300D)), NewObj(2).Put("lift", ((V)(6D))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(500D)), Call(o_21, V.Undef, B_378, NewObj(1).Put("lift", ((V)(0D))).V), ((V)("s")));
} else {
Invoke(Invoke(Invoke(Invoke(t_380, "to", ((V)(160D)), NewObj(3).Put("sq", ((V)(0.12))).Put("armL", ((V)((-6D)))).Put("armR", ((V)((-6D)))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(5).Put("lift", ((V)(8D))).Put("sq", ((V)((-0.1)))).Put("footR", ((V)(2.4))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)("o"))), "to", ((V)(220D)), Call(o_21, V.Undef, B_378, NewObj(2).Put("lift", ((V)(0D))).Put("sq", Add((Get(B_378, "sq") is var _t382 && Truthy(_t382) ? _t382 : ((V)(0D))), ((V)(0.1)))).V), ((V)("i"))), "fx", ((V)("splash")), ((V)("body")), ((V)(7D)));
}
v_381 = NewObj(0).V;
Invoke(Call(K_37, V.Undef, B_378), "forEach", Fn((V _arrowThis390, int _argc383, V p_389, V _a386, V _a387, V _a388, V[] _rest384) => {
return SetK(v_381, p_389, GetK(B_378, p_389));
}, 1, "", true));
Invoke(t_380, "to", ((V)(220D)), v_381, ((V)("io")));
return Invoke(t_380, "out", NewObj(2).Put("next", ((V)("splash"))).Put("blend", ((V)(180D))).V);
return default;
}, 2, "splashIn", false);
splashOut_72 = Fn((V _self391, int _argc392, V B_398, V _a395, V _a396, V _a397, V[] _rest393) => {
V t_399 = default;
V z_400 = default;
if (_self391.IsNullish) _self391 = GlobalV;
t_399 = Call(TL_12, V.Undef, B_398);
Set(t_399, "B", Call(o_21, V.Undef, REST_11, B_398));
Invoke(Invoke(Invoke(t_399, "to", ((V)(300D)), NewObj(6).Put("wd", ((V)(0.2))).Put("sk", ((V)(1D))).Put("lift", ((V)(1D))).Put("sq", ((V)((-0.04)))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(6).Put("lift", ((V)(8D))).Put("wd", ((V)(0D))).Put("sk", ((V)(0D))).Put("sit", ((V)(0D))).Put("footL", ((V)(2D))).Put("sq", ((V)((-0.08)))).V, ((V)("o"))), "fx", ((V)("drop")), ((V)("body")), ((V)(5D)));
z_400 = NewObj(0).V;
Invoke(Call(K_37, V.Undef, B_398), "forEach", Fn((V _arrowThis408, int _argc401, V p_407, V _a404, V _a405, V _a406, V[] _rest402) => {
return SetK(z_400, p_407, (GetK(REST_11, p_407) is var _t409 && Truthy(_t409) ? _t409 : ((V)(0D))));
}, 1, "", true));
Invoke(Invoke(Invoke(Invoke(Invoke(t_399, "to", ((V)(240D)), Call(o_21, V.Undef, z_400, NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).V), ((V)("i"))), "to", ((V)(140D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(5D)), NewObj(3).Put("x", ((V)(1.2))).Put("tilt", ((V)(5D))).Put("sqz", ((V)(0.8))).V, NewObj(3).Put("x", ((V)((-1.2)))).Put("tilt", ((V)((-5D)))).Put("sqz", ((V)(0.8))).V, ((V)("l"))), "fx", ((V)("drop")), ((V)("body")), ((V)(6D))), "to", ((V)(200D)), NewObj(5).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("sqz", ((V)(0D))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.8))).V, ((V)("o")));
Invoke(t_399, "back", ((V)(260D)));
return Invoke(t_399, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(160D))).V);
return default;
}, 1, "splashOut", false);
shellMove_73 = Fn((V _self410, int _argc411, V X_417, V _a414, V _a415, V _a416, V[] _rest412) => {
V t_418 = default;
V g_419 = default;
V k_420 = default;
V st_421 = default;
if (_self410.IsNullish) _self410 = GlobalV;
t_418 = Call(TL_12, V.Undef, REST_11);
Set(t_418, "B", Call(o_21, V.Undef, REST_11));
Invoke(Invoke(Invoke(t_418, "to", ((V)(300D)), NewObj(4).Put("lx", ((V)(0.4))).Put("ly", ((V)(0.9))).Put("pitch", ((V)((-0.16)))).Put("wide", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(380D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)((-2D))), ((V)(10D))), NewObj(6).Put("pitch", ((V)((-0.42)))).Put("ly", ((V)(1D))).Put("sq", ((V)(0.1))).Put("lean", ((V)(0.5))).Put("armR", ((V)(12D))).Put("tilt", ((V)(2D))).V), ((V)("io"))), "wait", ((V)(160D)));
g_419 = Get(t_418, "t");
Invoke(Invoke(Invoke(Invoke(Invoke(t_418, "to", ((V)(160D)), NewObj(1).Put("sqz", ((V)(0.3))).V), "to", ((V)(420D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-10D)))), NewObj(12).Put("armR", ((V)(48D))).Put("pitch", ((V)(0.08))).Put("ly", ((V)((-0.1)))).Put("lx", ((V)(0.3))).Put("sq", ((V)(0D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("wide", ((V)(0.8))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.6))).Put("htilt", ((V)(8D))).Put("sqz", ((V)(0D))).V), ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(2).Put("htilt", ((V)((-6D)))).Put("lx", ((V)((-0.3)))).V, ((V)("io"))), "wait", ((V)(300D)));
Invoke(Invoke(Invoke(Invoke(t_418, "to", ((V)(380D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(3D)), ((V)((-16D)))), NewObj(7).Put("armR", ((V)(112D))).Put("htilt", ((V)((-12D)))).Put("close", ((V)(0.7))).Put("smile", ((V)(1D))).Put("open", ((V)(0D))).Put("wide", ((V)(0D))).Put("mw", ((V)(1D))).V), ((V)("io"))), "fx", ((V)("note")), ((V)("head")), ((V)(1D))), "wait", ((V)(900D))), "fx", ((V)("bubble")), ((V)("head")), ((V)(1D)));
Invoke(t_418, "to", ((V)(360D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(8D)), ((V)(3D))), NewObj(7).Put("armL", ((V)(18D))).Put("armR", ((V)(18D))).Put("htilt", ((V)(0D))).Put("close", ((V)(0.4))).Put("blush", ((V)(0.7))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, Get(X_417, "cheer")), ((V)("io")));
k_420 = Get(t_418, "t");
Invoke(Invoke(t_418, "fx", ((V)("heart")), ((V)("head")), ((V)(2D))), "osc", ((V)(700D)), ((V)(3D)), NewObj(2).Put("sq", ((V)(0.04))).Put("tilt", ((V)(2D))).V, NewObj(2).Put("sq", ((V)(0D))).Put("tilt", ((V)((-2D)))).V, ((V)("s")));
Invoke(Invoke(t_418, "to", ((V)(140D)), NewObj(2).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.06)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i")));
Invoke(t_418, "back", ((V)(420D)));
st_421 = Invoke(t_418, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(180D))).V);
Set(st_421, "prop", Fn((V _arrowThis430, int _argc422, V I_428, V tt_429, V _a426, V _a427, V[] _rest423) => {
V W_431 = default;
double f0_432 = 0;
V Bp_433 = default;
V x_434 = default;
V y_435 = default;
double op_436 = 0;
W_431 = Get(I_428, "W");
if (((!(Truthy(W_431)) || !(Truthy(Call(okp_35, V.Undef, Get(W_431, "pawR"))))) || Lt(tt_429, g_419))) {
return ((V)(""));
}
f0_432 = Max(0.3, ToNum(Call(facing_27, V.Undef, I_428)));
Bp_433 = (Truthy(Call(okp_35, V.Undef, Get(W_431, "belly"))) ? Get(W_431, "belly") : Arr(((V)(50D)), ((V)(80D))));
x_434 = GetIdx(Get(W_431, "pawR"), 0D);
y_435 = ((V)((ToNum(GetIdx(Get(W_431, "pawR"), 1D)) - 2.5)));
op_436 = f0_432;
if (Gt(tt_429, k_420)) {
V u_437 = default;
u_437 = Call(ss_28, V.Undef, ((V)(((ToNum(tt_429) - ToNum(k_420)) / 600D))));
x_434 = Call(lerp_34, V.Undef, x_434, GetIdx(Bp_433, 0D), u_437);
y_435 = Call(lerp_34, V.Undef, y_435, GetIdx(Bp_433, 1D), u_437);
op_436 = (op_436 * (1D - ToNum(Call(ss_28, V.Undef, ((V)((((ToNum(tt_429) - ToNum(k_420)) - 400D) / 500D)))))));
}
return ((op_436 < 0.02) ? ((V)("")) : Call(G_26, V.Undef, x_434, y_435, ((V)((-10D))), ((V)(2.4)), (Get(ICON_20, "shell") is var _t438 && Truthy(_t438) ? _t438 : Get(ICON_20, "star")), ((V)(op_436))));
return default;
}, 2, "", true));
return st_421;
return default;
}, 1, "shellMove", false);
puckProp_89 = Fn((V _self439, int _argc440, V st_446, V col_447, V pong_448, V _a445, V[] _rest441) => {
V R0_449 = default;
V PD_450 = default;
if (_self439.IsNullish) _self439 = GlobalV;
R0_449 = Get(st_446, "rec");
PD_450 = (Truthy(pong_448) ? Call(PPAD_88, V.Undef, col_447) : Call(PADDLE_87, V.Undef, col_447));
return Fn((V _arrowThis459, int _argc451, V I_457, V tt_458, V _a455, V _a456, V[] _rest452) => {
V W_460 = default;
double f0_461 = 0;
double tl_462 = 0;
V p_463 = default;
V HS_464 = default;
V h0_465 = default;
V h1_466 = default;
double Tm_467 = 0;
double FAR_468 = 0;
double T_469 = 0;
V d_470 = default;
double op_471 = 0;
double u_472 = 0;
JsStrBuf h_473 = null;
W_460 = Get(I_457, "W");
if ((!(Truthy(W_460)) || !(Truthy(Call(okp_35, V.Undef, Get(W_460, "pawR")))))) {
return ((V)(""));
}
f0_461 = Max(0.4, ToNum(Call(facing_27, V.Undef, I_457)));
tl_462 = (ToNum(tt_458) % ToNum(Get(st_446, "loop")));
p_463 = Get(W_460, "pawR");
HS_464 = Invoke(Invoke((Get(R0_449, "h") is var _t483 && Truthy(_t483) ? _t483 : Arr()), "slice"), "sort", Fn((V _arrowThis482, int _argc474, V a_480, V b_481, V _a478, V _a479, V[] _rest475) => {
return ((V)((ToNum(a_480) - ToNum(b_481))));
}, 2, "", true));
h0_465 = V.Null;
h1_466 = V.Null;
Invoke(HS_464, "forEach", Fn((V _arrowThis491, int _argc484, V v_490, V _a487, V _a488, V _a489, V[] _rest485) => {
if (LeN(v_490, tl_462)) {
h0_465 = v_490;
} else {
if (h1_466.IsNullish) {
h1_466 = v_490;
}
}
return default;
}, 1, "", true));
Tm_467 = (Truthy(pong_448) ? 300D : 450D);
FAR_468 = (Truthy(pong_448) ? 34D : 30D);
T_469 = ((!h0_465.IsNullish && !h1_466.IsNullish) ? Min(Tm_467, ((ToNum(h1_466) - ToNum(h0_465)) / 2D)) : Tm_467);
d_470 = ((V)(5D));
op_471 = 1D;
if (!h0_465.IsNullish) {
d_470 = Call(lerp_34, V.Undef, ((V)(5D)), ((V)(FAR_468)), Call(ss_28, V.Undef, ((V)(((tl_462 - ToNum(h0_465)) / T_469)))));
}
if ((!h1_466.IsNullish && (tl_462 > (ToNum(h1_466) - T_469)))) {
d_470 = Call(lerp_34, V.Undef, ((V)(FAR_468)), ((V)(5D)), Call(ss_28, V.Undef, ((V)(((tl_462 - (ToNum(h1_466) - T_469)) / T_469)))));
}
if (((!h0_465.IsNullish && h1_466.IsNullish) && ((tl_462 - ToNum(h0_465)) > 1200D))) {
op_471 = (1D - ToNum(Call(ss_28, V.Undef, ((V)((((tl_462 - ToNum(h0_465)) - 1200D) / 300D))))));
}
u_472 = ((ToNum(d_470) - 5D) / (FAR_468 - 5D));
h_473 = new JsStrBuf("");
if ((op_471 > 0.02)) {
h_473.S("<g opacity=\"").V(Call(r2_30, V.Undef, ((V)(op_471)))).S("\">").V((Truthy(pong_448) ? Call(ci_32, V.Undef, Call(r2_30, V.Undef, Add(GetIdx(p_463, 0D), d_470)), Call(r2_30, V.Undef, ((V)(((ToNum(GetIdx(p_463, 1D)) - 2D) - (System.Math.Abs(FdLibm.Sin(((System.Math.PI * 2D) * u_472))) * 5D))))), ((V)(1.6)), ((V)("#ffffff")), ((V)("#c9cfdb"))) : ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(r2_30, V.Undef, Add(GetIdx(p_463, 0D), d_470))).S("\" cy=\"").V(Call(r2_30, V.Undef, Add(GetIdx(p_463, 1D), ((V)(2.5))))).S("\" rx=\"4.2\" ry=\"1.6\" fill=\"#2a2a36\" stroke=\"#111\" stroke-width=\"0.3\"/>").End())))).S("</g>");
}
return ((V)(JsStrBuf.Begin().S(h_473.Str).V(Call(G_26, V.Undef, GetIdx(p_463, 0D), GetIdx(p_463, 1D), ((V)((Truthy(pong_448) ? (-20D) : 0D))), ((V)(2.4)), PD_450, ((V)(f0_461)))).End()));
return default;
}, 2, "", true);
return default;
}, 3, "puckProp", false);
cueProp_92 = Fn((V _self492, int _argc493, V st_499, V _a496, V _a497, V _a498, V[] _rest494) => {
if (_self492.IsNullish) _self492 = GlobalV;
return Fn((V _arrowThis508, int _argc500, V I_506, V tt_507, V _a504, V _a505, V[] _rest501) => {
V W_509 = default;
double f0_510 = 0;
double tl_511 = 0;
V a_512 = default;
V b_513 = default;
double dx_514 = 0;
double dy_515 = 0;
double d_516 = 0;
V s0_517 = default;
V tip_518 = default;
V L_519 = default;
JsStrBuf h_520 = null;
V S_521 = default;
V home_522 = default;
V bp_523 = default;
V op_524 = default;
W_509 = Get(I_506, "W");
if (((!(Truthy(W_509)) || !(Truthy(Call(okp_35, V.Undef, Get(W_509, "pawR"))))) || !(Truthy(Call(okp_35, V.Undef, Get(W_509, "pawL")))))) {
return ((V)(""));
}
f0_510 = Max(0.35, ToNum(Call(facing_27, V.Undef, I_506)));
tl_511 = (ToNum(tt_507) % ToNum(Get(st_499, "loop")));
a_512 = Get(W_509, "pawR");
b_513 = Get(W_509, "pawL");
dx_514 = (ToNum(GetIdx(b_513, 0D)) - ToNum(GetIdx(a_512, 0D)));
dy_515 = (ToNum(GetIdx(b_513, 1D)) - ToNum(GetIdx(a_512, 1D)));
d_516 = Hypot(dx_514, dy_515);
if ((d_516 < 4D)) {
dx_514 = (-1D);
dy_515 = 0.2;
d_516 = Hypot(dx_514, dy_515);
}
dx_514 = (dx_514 / d_516);
dy_515 = (dy_515 / d_516);
s0_517 = Arr(((V)((ToNum(GetIdx(a_512, 0D)) - (dx_514 * 16D)))), ((V)((ToNum(GetIdx(a_512, 1D)) - (dy_515 * 16D)))));
tip_518 = Arr(Add(GetIdx(b_513, 0D), ((V)((dx_514 * 14D)))), Add(GetIdx(b_513, 1D), ((V)((dy_515 * 14D)))));
L_519 = Fn((V _arrowThis535, int _argc525, V p_531, V q_532, V c_533, V w_534, V[] _rest526) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(r2_30, V.Undef, GetIdx(p_531, 0D))).S(" ").V(Call(r2_30, V.Undef, GetIdx(p_531, 1D))).S("L").V(Call(r2_30, V.Undef, GetIdx(q_532, 0D))).S(" ").V(Call(r2_30, V.Undef, GetIdx(q_532, 1D))).S("\" stroke=\"").V(c_533).S("\" stroke-width=\"").V(w_534).S("\" stroke-linecap=\"round\"/>").End()));
}, 4, "", true);
h_520 = new JsStrBuf(JsStrBuf.Begin().S("<g opacity=\"").V(Call(r2_30, V.Undef, ((V)(f0_510)))).S("\">").V(Call(L_519, V.Undef, s0_517, tip_518, ((V)("#8a5a2c")), ((V)(2.6)))).V(Call(L_519, V.Undef, s0_517, tip_518, ((V)("#c98a52")), ((V)(1.7)))).V(Call(L_519, V.Undef, s0_517, Arr(Add(GetIdx(s0_517, 0D), ((V)((dx_514 * 12D)))), Add(GetIdx(s0_517, 1D), ((V)((dy_515 * 12D))))), ((V)("#3b2a24")), ((V)(2.8)))).V(Call(ci_32, V.Undef, Call(r2_30, V.Undef, GetIdx(tip_518, 0D)), Call(r2_30, V.Undef, GetIdx(tip_518, 1D)), ((V)(1.1)), ((V)("#5ab4f0")))).S("</g>").End());
S_521 = Invoke(Invoke((Get(Get(st_499, "rec"), "sh") is var _t544 && Truthy(_t544) ? _t544 : Arr()), "filter", Fn((V _arrowThis543, int _argc536, V v_542, V _a539, V _a540, V _a541, V[] _rest537) => {
return (LeN(v_542, tl_511) ? V.True : V.False);
}, 1, "", true)), "pop");
home_522 = Arr(Add(GetIdx(tip_518, 0D), ((V)((dx_514 * 3.6)))), Add(GetIdx(tip_518, 1D), ((V)((dy_515 * 3.6)))));
bp_523 = home_522;
op_524 = ((V)(1D));
if ((!S_521.IsNullish && ((tl_511 - ToNum(S_521)) < 2200D))) {
double e_545 = 0;
e_545 = (tl_511 - ToNum(S_521));
if ((e_545 < 1300D)) {
V u_546 = default;
double v_547 = 0;
u_546 = Call(cl_29, V.Undef, ((V)((e_545 / 900D))), ((V)(0D)), ((V)(1D)));
v_547 = (1D - ((1D - ToNum(u_546)) * (1D - ToNum(u_546))));
bp_523 = Arr(Add(GetIdx(home_522, 0D), ((V)(((dx_514 * 40D) * v_547)))), Add(GetIdx(home_522, 1D), ((V)(((dy_515 * 40D) * v_547)))));
op_524 = ((V)((1D - ToNum(Call(ss_28, V.Undef, ((V)(((e_545 - 900D) / 400D))))))));
} else {
op_524 = Call(ss_28, V.Undef, ((V)(((e_545 - 1700D) / 500D))));
}
}
if (GtN(op_524, 0.02)) {
h_520.S("<g opacity=\"").V(Call(r2_30, V.Undef, op_524)).S("\">").V(Call(ci_32, V.Undef, Call(r2_30, V.Undef, GetIdx(bp_523, 0D)), Call(r2_30, V.Undef, GetIdx(bp_523, 1D)), ((V)(3D)), ((V)("#ffffff")), ((V)("#9aa3b2")))).V(Call(ci_32, V.Undef, Call(r2_30, V.Undef, ((V)((ToNum(GetIdx(bp_523, 0D)) - 1D)))), Call(r2_30, V.Undef, ((V)((ToNum(GetIdx(bp_523, 1D)) - 1D)))), ((V)(0.8)), ((V)("#ffffff")))).S("</g>");
}
return ((V)(h_520.Str));
return default;
}, 2, "", true);
return default;
}, 1, "cueProp", false);
goalProp_95 = Fn((V _self548, int _argc549, V st_555, V _a552, V _a553, V _a554, V[] _rest550) => {
V R0_556 = default;
V HD_557 = default;
if (_self548.IsNullish) _self548 = GlobalV;
R0_556 = Get(st_555, "rec");
HD_557 = (Get(R0_556, "hd") is var _t558 && Truthy(_t558) ? _t558 : Arr());
return Fn((V _arrowThis567, int _argc559, V I_565, V tt_566, V _a563, V _a564, V[] _rest560) => {
V W_568 = default;
double tl_569 = 0;
V gx_570 = default;
V gy_571 = default;
V F_572 = default;
V Hd_573 = default;
V x_574 = default;
V y_575 = default;
double r_576 = 0;
double s_577 = 0;
V op_578 = default;
V dr_579 = default;
V pre_580 = default;
V f_581 = default;
W_568 = (Get(I_565, "W") is var _t582 && Truthy(_t582) ? _t582 : NewObj(0).V);
tl_569 = (ToNum(tt_566) % ToNum(Get(st_555, "loop")));
{ V _t583 = Call(g0_42, V.Undef, I_565);
{ V _t584 = ListOf(_t583);
{ V _t585 = GetIdx(_t584, 0D);
gx_570 = _t585; }
{ V _t586 = GetIdx(_t584, 1D);
gy_571 = _t586; }
} }
F_572 = Arr(Add(gx_570, ((V)(8D))), ((V)((ToNum(gy_571) - 3D))));
Hd_573 = (Truthy(Call(okp_35, V.Undef, Get(W_568, "head"))) ? Get(W_568, "head") : Arr(((V)(50D)), ((V)(20D))));
x_574 = GetIdx(F_572, 0D);
y_575 = GetIdx(F_572, 1D);
r_576 = 0D;
s_577 = 2D;
op_578 = ((V)(1D));
dr_579 = Invoke((Get(R0_556, "dr") is var _t595 && Truthy(_t595) ? _t595 : Arr()), "find", Fn((V _arrowThis594, int _argc587, V q_593, V _a590, V _a591, V _a592, V[] _rest588) => {
return ((Ge(((V)(tl_569)), GetIdx(q_593, 0D)) && Le(((V)(tl_569)), GetIdx(q_593, 1D))) ? V.True : V.False);
}, 1, "", true));
if (Truthy(dr_579)) {
double ph_596 = 0;
ph_596 = (((tl_569 - ToNum(GetIdx(dr_579, 0D))) / 320D) * System.Math.PI);
x_574 = Add(x_574, Add(((V)((FdLibm.Sin(ph_596) * 2.4))), ((Get(I_565, "lastP") is var _t597 && !Truthy(_t597) ? _t597 : Get(Get(I_565, "lastP"), "x")) is var _t598 && Truthy(_t598) ? _t598 : ((V)(0D)))));
y_575 = ((V)((ToNum(y_575) - (System.Math.Abs(FdLibm.Sin((ph_596 * 2D))) * 1.6))));
r_576 = ((tl_569 - ToNum(GetIdx(dr_579, 0D))) * 0.5);
}
pre_580 = Invoke(HD_557, "find", Fn((V _arrowThis606, int _argc599, V v_605, V _a602, V _a603, V _a604, V[] _rest600) => {
return (((tl_569 >= (ToNum(v_605) - 500D)) && Lt(((V)(tl_569)), v_605)) ? V.True : V.False);
}, 1, "", true));
f_581 = Call(flyF_41, V.Undef, Invoke((Get(R0_556, "k") is var _t607 && Truthy(_t607) ? _t607 : Arr()), "concat", HD_557), ((V)(tl_569)), NewObj(3).Put("fly", ((V)(700D))).Put("away", ((V)(1700D))).Put("ret", ((V)(900D))).V);
if (!pre_580.IsNullish) {
V u_608 = default;
u_608 = Call(ss_28, V.Undef, ((V)((((tl_569 - ToNum(pre_580)) + 500D) / 500D))));
x_574 = Call(lerp_34, V.Undef, Add(GetIdx(Hd_573, 0D), ((V)(6D))), GetIdx(Hd_573, 0D), u_608);
y_575 = Call(lerp_34, V.Undef, ((V)((ToNum(GetIdx(Hd_573, 1D)) - 46D))), ((V)((ToNum(GetIdx(Hd_573, 1D)) - 4D))), u_608);
r_576 = (200D * ToNum(u_608));
} else {
if (Truthy(f_581)) {
V ph_609 = default;
V u_610 = default;
V e_611 = default;
V from_612 = default;
{ V _t613 = f_581;
{ V _t614 = ListOf(_t613);
{ V _t615 = GetIdx(_t614, 0D);
ph_609 = _t615; }
{ V _t616 = GetIdx(_t614, 1D);
u_610 = _t616; }
{ V _t617 = GetIdx(_t614, 2D);
e_611 = _t617; }
} }
from_612 = (Truthy(Invoke(HD_557, "includes", e_611)) ? Arr(GetIdx(Hd_573, 0D), ((V)((ToNum(GetIdx(Hd_573, 1D)) - 4D)))) : F_572);
if (SEqS(ph_609, "fly")) {
x_574 = Add(GetIdx(from_612, 0D), ((V)((70D * ToNum(u_610)))));
y_575 = ((V)(((ToNum(GetIdx(from_612, 1D)) - (FdLibm.Sin((System.Math.PI * ToNum(u_610))) * 26D)) + (((ToNum(GetIdx(F_572, 1D)) - 14D) - ToNum(GetIdx(from_612, 1D))) * ToNum(u_610)))));
s_577 = (2D * (1D - (0.45 * ToNum(u_610))));
r_576 = (720D * ToNum(u_610));
if (GtN(u_610, 0.85)) {
op_578 = ((V)((1D - ((ToNum(u_610) - 0.85) / 0.15))));
}
} else {
if (SEqS(ph_609, "away")) {
op_578 = ((V)(0D));
} else {
x_574 = Call(lerp_34, V.Undef, Add(GetIdx(F_572, 0D), ((V)(60D))), GetIdx(F_572, 0D), Call(ss_28, V.Undef, u_610));
r_576 = ((-600D) * (1D - ToNum(u_610)));
op_578 = Call(ss_28, V.Undef, ((V)((ToNum(u_610) / 0.2))));
}
}
}
}
return (LtN(op_578, 0.02) ? ((V)("")) : Call(G_26, V.Undef, x_574, y_575, ((V)(r_576)), ((V)(s_577)), Get(ICX_93, "ball"), op_578));
return default;
}, 2, "", true);
return default;
}, 1, "goalProp", false);
keepProp_99 = Fn((V _self618, int _argc619, V st_625, V _a622, V _a623, V _a624, V[] _rest620) => {
V R0_626 = default;
if (_self618.IsNullish) _self618 = GlobalV;
R0_626 = Get(st_625, "rec");
return Fn((V _arrowThis635, int _argc627, V I_633, V tt_634, V _a631, V _a632, V[] _rest628) => {
V W_636 = default;
double tl_637 = 0;
V c_638 = default;
V p_639 = default;
double u_640 = 0;
W_636 = Get(I_633, "W");
if (((!(Truthy(W_636)) || !(Truthy(Call(okp_35, V.Undef, Get(W_636, "pawL"))))) || !(Truthy(Call(okp_35, V.Undef, Get(W_636, "pawR")))))) {
return ((V)(""));
}
tl_637 = (ToNum(tt_634) % ToNum(Get(st_625, "loop")));
c_638 = Invoke((Get(R0_626, "c") is var _t649 && Truthy(_t649) ? _t649 : Arr()), "find", Fn((V _arrowThis648, int _argc641, V q_647, V _a644, V _a645, V _a646, V[] _rest642) => {
return (((tl_637 >= (ToNum(GetIdx(q_647, 0D)) - 250D)) && Le(((V)(tl_637)), GetIdx(q_647, 1D))) ? V.True : V.False);
}, 1, "", true));
if (Truthy(c_638)) {
V m_650 = default;
V u_651 = default;
m_650 = Call(mid_43, V.Undef, W_636);
u_651 = Call(ss_28, V.Undef, ((V)((((tl_637 - ToNum(GetIdx(c_638, 0D))) + 250D) / 250D))));
return Call(G_26, V.Undef, Call(lerp_34, V.Undef, Add(GetIdx(m_650, 0D), ((V)(10D))), GetIdx(m_650, 0D), u_651), Call(lerp_34, V.Undef, ((V)((ToNum(GetIdx(m_650, 1D)) - 14D))), GetIdx(m_650, 1D), u_651), ((V)(0D)), ((V)((2.2 * (0.6 + (0.4 * ToNum(u_651)))))), Get(ICX_93, "ball"));
}
p_639 = Invoke((Get(R0_626, "pu") is var _t660 && Truthy(_t660) ? _t660 : Arr()), "find", Fn((V _arrowThis659, int _argc652, V v_658, V _a655, V _a656, V _a657, V[] _rest653) => {
return (((tl_637 >= (ToNum(v_658) - 250D)) && Lt(((V)(tl_637)), Add(v_658, ((V)(600D))))) ? V.True : V.False);
}, 1, "", true));
if (p_639.IsNullish) {
return ((V)(""));
}
if (Lt(((V)(tl_637)), p_639)) {
V v_661 = default;
v_661 = Call(ss_28, V.Undef, ((V)((((tl_637 - ToNum(p_639)) + 250D) / 250D))));
return Call(G_26, V.Undef, Add(GetIdx(Get(W_636, "pawR"), 0D), ((V)((12D * (1D - ToNum(v_661)))))), ((V)((ToNum(GetIdx(Get(W_636, "pawR"), 1D)) - (14D * (1D - ToNum(v_661)))))), ((V)(0D)), ((V)(2D)), Get(ICX_93, "ball"), v_661);
}
u_640 = ((tl_637 - ToNum(p_639)) / 600D);
return Call(G_26, V.Undef, Add(GetIdx(Get(W_636, "pawR"), 0D), ((V)((30D * u_640)))), ((V)((ToNum(GetIdx(Get(W_636, "pawR"), 1D)) - (26D * FdLibm.Sin(((System.Math.PI * u_640) * 0.8)))))), ((V)((500D * u_640))), ((V)((2D * (1D - (0.4 * u_640))))), Get(ICX_93, "ball"), ((V)((1D - ToNum(Call(ss_28, V.Undef, ((V)(((u_640 - 0.7) / 0.3)))))))));
return default;
}, 2, "", true);
return default;
}, 1, "keepProp", false);
hoopProp_101 = Fn((V _self662, int _argc663, V st_669, V _a666, V _a667, V _a668, V[] _rest664) => {
V R0_670 = default;
if (_self662.IsNullish) _self662 = GlobalV;
R0_670 = Get(st_669, "rec");
return Fn((V _arrowThis679, int _argc671, V I_677, V tt_678, V _a675, V _a676, V[] _rest672) => {
V W_680 = default;
double tl_681 = 0;
V gx_682 = default;
V gy_683 = default;
V p_684 = default;
double f0_685 = 0;
V m_686 = default;
V mm_687 = default;
V dr_688 = default;
V sp_689 = default;
V f_690 = default;
W_680 = Get(I_677, "W");
if ((!(Truthy(W_680)) || !(Truthy(Call(okp_35, V.Undef, Get(W_680, "pawR")))))) {
return ((V)(""));
}
tl_681 = (ToNum(tt_678) % ToNum(Get(st_669, "loop")));
{ V _t691 = Call(g0_42, V.Undef, I_677);
{ V _t692 = ListOf(_t691);
{ V _t693 = GetIdx(_t692, 0D);
gx_682 = _t693; }
{ V _t694 = GetIdx(_t692, 1D);
gy_683 = _t694; }
} }
p_684 = Get(W_680, "pawR");
f0_685 = Max(0.4, ToNum(Call(facing_27, V.Undef, I_677)));
m_686 = Call(mid_43, V.Undef, W_680);
mm_687 = Arr(GetIdx(m_686, 0D), ((V)((ToNum(GetIdx(m_686, 1D)) - 3D))));
dr_688 = Invoke((Get(R0_670, "dr") is var _t703 && Truthy(_t703) ? _t703 : Arr()), "find", Fn((V _arrowThis702, int _argc695, V q_701, V _a698, V _a699, V _a700, V[] _rest696) => {
return ((Ge(((V)(tl_681)), GetIdx(q_701, 0D)) && Le(((V)(tl_681)), GetIdx(q_701, 1D))) ? V.True : V.False);
}, 1, "", true));
sp_689 = Invoke((Get(R0_670, "sp") is var _t712 && Truthy(_t712) ? _t712 : Arr()), "find", Fn((V _arrowThis711, int _argc704, V q_710, V _a707, V _a708, V _a709, V[] _rest705) => {
return ((Ge(((V)(tl_681)), GetIdx(q_710, 0D)) && Le(((V)(tl_681)), GetIdx(q_710, 1D))) ? V.True : V.False);
}, 1, "", true));
f_690 = Call(flyF_41, V.Undef, Get(R0_670, "sh"), ((V)(tl_681)), NewObj(3).Put("fly", ((V)(900D))).Put("away", ((V)(1500D))).Put("ret", ((V)(600D))).V);
if (Truthy(f_690)) {
V ph_713 = default;
V u_714 = default;
{ V _t715 = f_690;
{ V _t716 = ListOf(_t715);
{ V _t717 = GetIdx(_t716, 0D);
ph_713 = _t717; }
{ V _t718 = GetIdx(_t716, 1D);
u_714 = _t718; }
} }
if (SEqS(ph_713, "fly")) {
return Call(G_26, V.Undef, Add(GetIdx(mm_687, 0D), ((V)((30D * ToNum(u_714))))), ((V)((((ToNum(GetIdx(mm_687, 1D)) - (50D * ToNum(u_714))) - (FdLibm.Sin((System.Math.PI * ToNum(u_714))) * 16D)) + ((40D * ToNum(u_714)) * ToNum(u_714))))), ((V)((600D * ToNum(u_714)))), ((V)((2.4 * (1D - (0.4 * ToNum(u_714)))))), Get(ICX_93, "bball"), ((V)((1D - ToNum(Call(ss_28, V.Undef, ((V)(((ToNum(u_714) - 0.8) / 0.2)))))))));
}
if (SEqS(ph_713, "away")) {
return ((V)(""));
}
return Call(G_26, V.Undef, Call(lerp_34, V.Undef, Add(gx_682, ((V)(50D))), GetIdx(mm_687, 0D), Call(ss_28, V.Undef, u_714)), ((V)((ToNum(Call(lerp_34, V.Undef, ((V)((ToNum(gy_683) - 3D))), GetIdx(mm_687, 1D), Call(ss_28, V.Undef, u_714))) - (FdLibm.Sin((System.Math.PI * ToNum(u_714))) * 10D)))), ((V)(((-400D) * (1D - ToNum(u_714))))), ((V)(2.4)), Get(ICX_93, "bball"), Call(ss_28, V.Undef, ((V)((ToNum(u_714) / 0.25)))));
}
if (Truthy(sp_689)) {
return Call(G_26, V.Undef, GetIdx(p_684, 0D), ((V)((ToNum(GetIdx(p_684, 1D)) - 7D))), ((V)(((tl_681 - ToNum(GetIdx(sp_689, 0D))) * 1.4))), ((V)(2.4)), Get(ICX_93, "bball"), ((V)(f0_685)));
}
if (Truthy(dr_688)) {
double ph_719 = 0;
ph_719 = System.Math.Abs(FdLibm.Sin((((tl_681 - ToNum(GetIdx(dr_688, 0D))) / 300D) * System.Math.PI)));
return Call(G_26, V.Undef, Add(GetIdx(p_684, 0D), ((V)(1D))), Call(lerp_34, V.Undef, Add(GetIdx(p_684, 1D), ((V)(3.5))), ((V)((ToNum(gy_683) - 3D))), ((V)(ph_719))), ((V)(0D)), ((V)(2.4)), Get(ICX_93, "bball"), ((V)(f0_685)));
}
return Call(G_26, V.Undef, GetIdx(mm_687, 0D), GetIdx(mm_687, 1D), ((V)(0D)), ((V)(2.4)), Get(ICX_93, "bball"), ((V)(f0_685)));
return default;
}, 2, "", true);
return default;
}, 1, "hoopProp", false);
golfProp_104 = Fn((V _self720, int _argc721, V st_727, V _a724, V _a725, V _a726, V[] _rest722) => {
if (_self720.IsNullish) _self720 = GlobalV;
return Fn((V _arrowThis736, int _argc728, V I_734, V tt_735, V _a732, V _a733, V[] _rest729) => {
V W_737 = default;
double tl_738 = 0;
V gx_739 = default;
V gy_740 = default;
V m_741 = default;
V hd_742 = default;
JsStrBuf h_743 = null;
V b0_744 = default;
V f_745 = default;
V bx_746 = default;
V op_747 = default;
W_737 = Get(I_734, "W");
if (((!(Truthy(W_737)) || !(Truthy(Call(okp_35, V.Undef, Get(W_737, "pawR"))))) || !(Truthy(Call(okp_35, V.Undef, Get(W_737, "pawL")))))) {
return ((V)(""));
}
tl_738 = (ToNum(tt_735) % ToNum(Get(st_727, "loop")));
{ V _t748 = Call(g0_42, V.Undef, I_734);
{ V _t749 = ListOf(_t748);
{ V _t750 = GetIdx(_t749, 0D);
gx_739 = _t750; }
{ V _t751 = GetIdx(_t749, 1D);
gy_740 = _t751; }
} }
m_741 = Call(mid_43, V.Undef, W_737);
hd_742 = Arr(Add(GetIdx(m_741, 0D), ((V)(3D))), ((V)((ToNum(gy_740) - 1D))));
h_743 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"M").V(Call(r2_30, V.Undef, GetIdx(m_741, 0D))).S(" ").V(Call(r2_30, V.Undef, GetIdx(m_741, 1D))).S("L").V(Call(r2_30, V.Undef, GetIdx(hd_742, 0D))).S(" ").V(Call(r2_30, V.Undef, GetIdx(hd_742, 1D))).S("\" stroke=\"#6a7080\" stroke-width=\"1.5\" stroke-linecap=\"round\"/><rect x=\"").V(Call(r2_30, V.Undef, ((V)((ToNum(GetIdx(hd_742, 0D)) - 1.6))))).S("\" y=\"").V(Call(r2_30, V.Undef, ((V)((ToNum(GetIdx(hd_742, 1D)) - 1.4))))).S("\" width=\"7\" height=\"2.8\" rx=\"0.5\" fill=\"#6a7080\" stroke=\"#3a3a48\" stroke-width=\"0.3\"/>").V(Call(ci_32, V.Undef, Call(r2_30, V.Undef, GetIdx(m_741, 0D)), Call(r2_30, V.Undef, GetIdx(m_741, 1D)), ((V)(1.6)), ((V)("#2a2a36")))).End());
b0_744 = Add(gx_739, ((V)(9D)));
f_745 = Call(flyF_41, V.Undef, Get(Get(st_727, "rec"), "pt"), ((V)(tl_738)), NewObj(3).Put("fly", ((V)(1300D))).Put("away", ((V)(2600D))).Put("ret", ((V)(400D))).V);
bx_746 = b0_744;
op_747 = ((V)(1D));
if (Truthy(f_745)) {
V ph_752 = default;
V u_753 = default;
V d_754 = default;
{ V _t755 = f_745;
{ V _t756 = ListOf(_t755);
{ V _t757 = GetIdx(_t756, 0D);
ph_752 = _t757; }
{ V _t758 = GetIdx(_t756, 1D);
u_753 = _t758; }
{ V _t759 = GetIdx(_t756, 3D);
d_754 = _t759; }
} }
if (SEqS(ph_752, "fly")) {
bx_746 = Add(b0_744, ((V)((44D * (1D - ((1D - ToNum(u_753)) * (1D - ToNum(u_753))))))));
} else {
if (SEqS(ph_752, "away")) {
bx_746 = Add(b0_744, ((V)(44D)));
op_747 = ((V)((1D - ToNum(Call(ss_28, V.Undef, ((V)(((ToNum(d_754) - 1500D) / 500D))))))));
} else {
op_747 = Call(ss_28, V.Undef, u_753);
}
}
}
if (GtN(op_747, 0.02)) {
h_743.S("<g opacity=\"").V(Call(r2_30, V.Undef, op_747)).S("\">").V(Call(ci_32, V.Undef, Call(r2_30, V.Undef, bx_746), Call(r2_30, V.Undef, ((V)((ToNum(gy_740) - 1.8)))), ((V)(1.9)), ((V)("#ffffff")), ((V)("#9aa3b2")))).S("</g>");
}
return ((V)(h_743.Str));
return default;
}, 2, "", true);
return default;
}, 1, "golfProp", false);
tossProp_110 = Fn((V _self760, int _argc761, V st_767, V kind_768, V col_769, V _a766, V[] _rest762) => {
V R0_770 = default;
V IC_771 = default;
V Fp_772 = default;
if (_self760.IsNullish) _self760 = GlobalV;
R0_770 = Get(st_767, "rec");
IC_771 = (SEqS(kind_768, "bag") ? Invoke(ICX_93, "bag", col_769) : (SEqS(kind_768, "shoe") ? Get(ICX_93, "shoe") : Get(ICX_93, "bocce")));
Fp_772 = (SEqS(kind_768, "bocce") ? NewObj(3).Put("fly", ((V)(1500D))).Put("away", ((V)(2600D))).Put("ret", ((V)(400D))).V : NewObj(3).Put("fly", ((V)(800D))).Put("away", ((V)(2400D))).Put("ret", ((V)(400D))).V);
return Fn((V _arrowThis781, int _argc773, V I_779, V tt_780, V _a777, V _a778, V[] _rest774) => {
V W_782 = default;
double tl_783 = 0;
V gx_784 = default;
V gy_785 = default;
V p_786 = default;
double f0_787 = 0;
V f_788 = default;
double s_789 = 0;
V T_790 = default;
V ph_791 = default;
V u_792 = default;
V d_793 = default;
W_782 = Get(I_779, "W");
if ((!(Truthy(W_782)) || !(Truthy(Call(okp_35, V.Undef, Get(W_782, "pawR")))))) {
return ((V)(""));
}
tl_783 = (ToNum(tt_780) % ToNum(Get(st_767, "loop")));
{ V _t794 = Call(g0_42, V.Undef, I_779);
{ V _t795 = ListOf(_t794);
{ V _t796 = GetIdx(_t795, 0D);
gx_784 = _t796; }
{ V _t797 = GetIdx(_t795, 1D);
gy_785 = _t797; }
} }
p_786 = Get(W_782, "pawR");
f0_787 = Max(0.4, ToNum(Call(facing_27, V.Undef, I_779)));
f_788 = Call(flyF_41, V.Undef, Get(R0_770, "ts"), ((V)(tl_783)), Fp_772);
s_789 = 2.8;
T_790 = Arr(Add(gx_784, ((V)(48D))), ((V)((ToNum(gy_785) - 9D))));
if (!(Truthy(f_788))) {
return Call(G_26, V.Undef, GetIdx(p_786, 0D), ((V)((ToNum(GetIdx(p_786, 1D)) - 1D))), ((V)(0D)), ((V)(s_789)), IC_771, ((V)(f0_787)));
}
{ V _t798 = f_788;
{ V _t799 = ListOf(_t798);
{ V _t800 = GetIdx(_t799, 0D);
ph_791 = _t800; }
{ V _t801 = GetIdx(_t799, 1D);
u_792 = _t801; }
{ V _t802 = GetIdx(_t799, 3D);
d_793 = _t802; }
} }
if (SEqS(ph_791, "ret")) {
return Call(G_26, V.Undef, GetIdx(p_786, 0D), ((V)((ToNum(GetIdx(p_786, 1D)) - 1D))), ((V)(0D)), ((V)(s_789)), IC_771, ((V)((f0_787 * ToNum(Call(ss_28, V.Undef, u_792))))));
}
if (SEqS(ph_791, "away")) {
return Call(G_26, V.Undef, GetIdx(T_790, 0D), GetIdx(T_790, 1D), ((V)((SEqS(kind_768, "shoe") ? 0D : 10D))), ((V)((s_789 * 0.75))), IC_771, ((V)((1D - ToNum(Call(ss_28, V.Undef, ((V)((((ToNum(d_793) - ToNum(Get(Fp_772, "away"))) + 500D) / 500D)))))))));
}
if (SEqS(kind_768, "bocce")) {
double v_803 = 0;
v_803 = (1D - ((1D - ToNum(u_792)) * (1D - ToNum(u_792))));
return Call(G_26, V.Undef, Call(lerp_34, V.Undef, GetIdx(p_786, 0D), GetIdx(T_790, 0D), ((V)(v_803))), ((V)((ToNum(Call(lerp_34, V.Undef, GetIdx(p_786, 1D), GetIdx(T_790, 1D), ((V)(v_803)))) - (LtN(u_792, 0.12) ? ((1D - (ToNum(u_792) / 0.12)) * 4D) : 0D)))), ((V)((900D * v_803))), ((V)((s_789 * (1D - (0.25 * v_803))))), IC_771);
}
return Call(G_26, V.Undef, Call(lerp_34, V.Undef, GetIdx(p_786, 0D), GetIdx(T_790, 0D), u_792), ((V)((ToNum(Call(lerp_34, V.Undef, GetIdx(p_786, 1D), GetIdx(T_790, 1D), u_792)) - (FdLibm.Sin((System.Math.PI * ToNum(u_792))) * 24D)))), ((V)(((SEqS(kind_768, "shoe") ? 720D : 300D) * ToNum(u_792)))), ((V)((s_789 * (1D - (0.25 * ToNum(u_792)))))), IC_771);
return default;
}, 2, "", true);
return default;
}, 3, "tossProp", false);
hopProp_115 = Fn((V _self804, int _argc805, V st_811, V _a808, V _a809, V _a810, V[] _rest806) => {
V R0_812 = default;
if (_self804.IsNullish) _self804 = GlobalV;
R0_812 = Get(st_811, "rec");
return Fn((V _arrowThis821, int _argc813, V I_819, V tt_820, V _a817, V _a818, V[] _rest814) => {
V W_822 = default;
double tl_823 = 0;
V gx_824 = default;
V gy_825 = default;
V p_826 = default;
V T_827 = default;
V ts_828 = default;
V pk_829 = default;
double f0_830 = 0;
V u_831 = default;
W_822 = Get(I_819, "W");
if ((!(Truthy(W_822)) || !(Truthy(Call(okp_35, V.Undef, Get(W_822, "pawR")))))) {
return ((V)(""));
}
tl_823 = (ToNum(tt_820) % ToNum(Get(st_811, "loop")));
{ V _t832 = Call(g0_42, V.Undef, I_819);
{ V _t833 = ListOf(_t832);
{ V _t834 = GetIdx(_t833, 0D);
gx_824 = _t834; }
{ V _t835 = GetIdx(_t833, 1D);
gy_825 = _t835; }
} }
p_826 = Get(W_822, "pawR");
T_827 = Arr(Add(gx_824, ((V)(30D))), Add(gy_825, ((V)(1D))));
ts_828 = GetIdx((Get(R0_812, "ts") is var _t836 && Truthy(_t836) ? _t836 : Arr()), 0D);
pk_829 = GetIdx((Get(R0_812, "pk") is var _t837 && Truthy(_t837) ? _t837 : Arr()), 0D);
f0_830 = Max(0.4, ToNum(Call(facing_27, V.Undef, I_819)));
if (((ts_828.IsNullish || Lt(((V)(tl_823)), ts_828)) || (!pk_829.IsNullish && Ge(((V)(tl_823)), pk_829)))) {
return Call(G_26, V.Undef, GetIdx(p_826, 0D), GetIdx(p_826, 1D), ((V)(0D)), ((V)(2.6)), Get(ICX_93, "stone"), ((V)(f0_830)));
}
u_831 = Call(cl_29, V.Undef, ((V)(((tl_823 - ToNum(ts_828)) / 600D))), ((V)(0D)), ((V)(1D)));
return Call(G_26, V.Undef, Call(lerp_34, V.Undef, GetIdx(p_826, 0D), GetIdx(T_827, 0D), u_831), ((V)((ToNum(Call(lerp_34, V.Undef, GetIdx(p_826, 1D), GetIdx(T_827, 1D), u_831)) - (FdLibm.Sin((System.Math.PI * ToNum(u_831))) * 14D)))), ((V)(0D)), ((V)(2.6)), Get(ICX_93, "stone"));
return default;
}, 2, "", true);
return default;
}, 1, "hopProp", false);
frisbeeProp_119 = Fn((V _self838, int _argc839, V st_845, V col_846, V _a843, V _a844, V[] _rest840) => {
V R0_847 = default;
V IC_848 = default;
if (_self838.IsNullish) _self838 = GlobalV;
R0_847 = Get(st_845, "rec");
IC_848 = Invoke(ICX_93, "disc", col_846);
return Fn((V _arrowThis857, int _argc849, V I_855, V tt_856, V _a853, V _a854, V[] _rest850) => {
V W_858 = default;
double tl_859 = 0;
V p_860 = default;
double f0_861 = 0;
V m_862 = default;
V mm_863 = default;
V th_864 = default;
V ca_865 = default;
V e_866 = default;
W_858 = Get(I_855, "W");
if ((!(Truthy(W_858)) || !(Truthy(Call(okp_35, V.Undef, Get(W_858, "pawR")))))) {
return ((V)(""));
}
tl_859 = (ToNum(tt_856) % ToNum(Get(st_845, "loop")));
p_860 = Get(W_858, "pawR");
f0_861 = Max(0.4, ToNum(Call(facing_27, V.Undef, I_855)));
m_862 = Call(mid_43, V.Undef, W_858);
mm_863 = Arr(GetIdx(m_862, 0D), ((V)((ToNum(GetIdx(m_862, 1D)) - 4D))));
th_864 = (Get(R0_847, "th") is var _t867 && Truthy(_t867) ? _t867 : Arr());
ca_865 = (Get(R0_847, "ca") is var _t868 && Truthy(_t868) ? _t868 : Arr());
e_866 = ((V)((-1D)));
Invoke(th_864, "forEach", Fn((V _arrowThis877, int _argc869, V v_875, V i_876, V _a873, V _a874, V[] _rest870) => {
if (((Ge(((V)(tl_859)), v_875) && !GetK(ca_865, i_876).IsNullish) && Lt(((V)(tl_859)), GetK(ca_865, i_876)))) {
e_866 = i_876;
}
return default;
}, 2, "", true));
if (GeN(e_866, 0D)) {
V a_878 = default;
V b_879 = default;
double u_880 = 0;
a_878 = GetK(th_864, e_866);
b_879 = GetK(ca_865, e_866);
u_880 = ((tl_859 - ToNum(a_878)) / (ToNum(b_879) - ToNum(a_878)));
return Call(G_26, V.Undef, Add(Call(lerp_34, V.Undef, GetIdx(p_860, 0D), GetIdx(mm_863, 0D), ((V)(u_880))), ((V)((FdLibm.Sin((System.Math.PI * u_880)) * 56D)))), ((V)(((ToNum(Call(lerp_34, V.Undef, GetIdx(p_860, 1D), GetIdx(mm_863, 1D), ((V)(u_880)))) - (FdLibm.Sin((System.Math.PI * u_880)) * 16D)) - (FdLibm.Sin(((System.Math.PI * 2D) * u_880)) * 6D)))), ((V)((FdLibm.Sin(((System.Math.PI * 2D) * u_880)) * 12D))), ((V)((3D * (1D - (0.35 * FdLibm.Sin((System.Math.PI * u_880))))))), IC_848);
}
return (Truthy(Invoke(ca_865, "some", Fn((V _arrowThis888, int _argc881, V v_887, V _a884, V _a885, V _a886, V[] _rest882) => {
return ((Ge(((V)(tl_859)), v_887) && Lt(((V)(tl_859)), Add(v_887, ((V)(1200D))))) ? V.True : V.False);
}, 1, "", true))) ? Call(G_26, V.Undef, GetIdx(mm_863, 0D), GetIdx(mm_863, 1D), ((V)(0D)), ((V)(3D)), IC_848, ((V)(f0_861))) : Call(G_26, V.Undef, GetIdx(p_860, 0D), GetIdx(p_860, 1D), ((V)((-10D))), ((V)(3D)), IC_848, ((V)(f0_861))));
return default;
}, 2, "", true);
return default;
}, 2, "frisbeeProp", false);
cBuild_121 = Fn((V _self889, int _argc890, V key_896, V X_897, V _a894, V _a895, V[] _rest891) => {
V P_898 = default;
V nm_899 = default;
V S_900 = default;
V SB_901 = default;
V sig_902 = default;
V pc_903 = default;
V H1_904 = default;
V GM_905 = default;
if (_self889.IsNullish) _self889 = GlobalV;
X_897 = Call(o_21, V.Undef, (GetK(BB_19, key_896) is var _t906 && Truthy(_t906) ? _t906 : NewObj(0).V), (X_897 is var _t907 && Truthy(_t907) ? _t907 : NewObj(0).V));
P_898 = (GetK(PROF_18, key_896) is var _t908 && Truthy(_t908) ? _t908 : NewObj(0).V);
nm_899 = Fn((V _arrowThis916, int _argc909, V n_915, V _a912, V _a913, V _a914, V[] _rest910) => {
return (Truthy(key_896) ? ((V)(JsStrBuf.Begin().V(n_915).S("@").V(key_896).End())) : n_915);
}, 1, "", true);
S_900 = NewObj(0).V;
SB_901 = Call(o_21, V.Undef, SIT0_17, (Get(P_898, "pose") is var _t917 && Truthy(_t917) ? _t917 : NewObj(0).V));
sig_902 = ((Get(X_897, "b") is var _t918 && Truthy(_t918) ? _t918 : Get(X_897, "p")) is var _t928 && Truthy(_t928) ? _t928 : Invoke((Get(P_898, "f") is var _t927 && Truthy(_t927) ? _t927 : Arr()), "find", Fn((V _arrowThis926, int _argc919, V f_925, V _a922, V _a923, V _a924, V[] _rest920) => {
return (string.Equals(Typeof(f_925), "function") ? V.True : V.False);
}, 1, "", true)));
pc_903 = (Get(X_897, "pc") is var _t929 && Truthy(_t929) ? _t929 : ((V)("#e8483c")));
H1_904 = Fn((V _arrowThis942, int _argc930, V n_936, V B_937, V ord_938, V BK_939, V[] _rest931) => {
V gaps_940 = default;
V e_941 = default;
gaps_940 = (_argc930 > 4 ? _rest931[0] : V.Undef);
e_941 = (_argc930 > 5 ? _rest931[1] : V.Undef);
return SetK(S_900, Call(nm_899, V.Undef, n_936), Call(hold_40, V.Undef, B_937, ord_938, Call(o_21, V.Undef, COM_49, (BK_939 is var _t943 && Truthy(_t943) ? _t943 : NewObj(0).V)), X_897, sig_902, (gaps_940 is var _t944 && Truthy(_t944) ? _t944 : Arr(((V)(500D)), ((V)(700D)), ((V)(600D)), ((V)(800D)))), (e_941 is var _t945 && Truthy(_t945) ? _t945 : NewObj(1).Put("breathe", ((V)(0.4))).V)));
}, 6, "", true);
SetK(S_900, Call(nm_899, V.Undef, ((V)("kick"))), Call(kickMove_51, V.Undef, X_897));
SetK(S_900, Call(nm_899, V.Undef, ((V)("shellpick"))), Call(shellMove_73, V.Undef, X_897));
Call(H1_904, V.Undef, ((V)("bowl")), Call(o_21, V.Undef, BW0_52, (Get(X_897, "bwp") is var _t946 && Truthy(_t946) ? _t946 : NewObj(0).V)), Arr(((V)("munch")), ((V)("up")), ((V)("munch")), ((V)("slurp")), ((V)("lick")), ((V)("sig")), ((V)("munch")), ((V)("tummy")), ((V)("hic"))), BWB_53, Arr(((V)(300D)), ((V)(500D)), ((V)(400D)), ((V)(600D))));
Set(Call(H1_904, V.Undef, ((V)("dishes")), DS0_54, Arr(((V)("scrub")), ((V)("rinse")), ((V)("squeak")), ((V)("stack")), ((V)("scrub")), ((V)("hum")), ((V)("rinse")), ((V)("stack")), ((V)("bubble")), ((V)("sig")), ((V)("scrub")), ((V)("squeak")), ((V)("stack"))), DSB_55, Arr(((V)(300D)), ((V)(500D)), ((V)(400D)))), "prop", V.Null);
Set(GetK(S_900, Call(nm_899, V.Undef, ((V)("dishes")))), "prop", Call(dishProp_58, V.Undef, GetK(S_900, Call(nm_899, V.Undef, ((V)("dishes"))))));
{
V st_947 = default;
st_947 = Call(H1_904, V.Undef, ((V)("grill")), GR0_59, Arr(((V)("poke")), ((V)("flip")), ((V)("smoke")), ((V)("season")), ((V)("poke")), ((V)("flip")), ((V)("sniff")), ((V)("sig")), ((V)("serve"))), GRB_60, Arr(((V)(400D)), ((V)(600D)), ((V)(500D))));
Set(st_947, "prop", Call(grillProp_63, V.Undef, st_947));
}
Call(H1_904, V.Undef, ((V)("toastwait")), TW0_64, Arr(((V)("tap")), ((V)("peek")), ((V)("rub")), ((V)("hum")), ((V)("look")), ((V)("tap"))), TWB_65, Arr(((V)(600D)), ((V)(900D))));
SetK(S_900, Call(nm_899, V.Undef, ((V)("toast"))), Call(toastMove_67, V.Undef, X_897));
{
V PO_948 = default;
V a_949 = default;
PO_948 = Call(o_21, V.Undef, SB_901, NewObj(1).Put("sq", Add((Get(SB_901, "sq") is var _t950 && Truthy(_t950) ? _t950 : ((V)(0D))), ((V)(0.04)))).V);
Call(H1_904, V.Undef, ((V)("pouf")), PO_948, Arr(((V)("bounce")), ((V)("look")), ((V)("big")), ((V)("wiggle")), ((V)("rock")), ((V)("bounce")), ((V)("sig")), ((V)("spinb")), ((V)("giggle"))), POB_68, Arr(((V)(500D)), ((V)(900D)), ((V)(700D))));
a_949 = Call(sitdown_22, V.Undef, PO_948, P_898);
Set(a_949, "next", ((V)("pouf")));
SetK(S_900, Call(nm_899, V.Undef, ((V)("poufin"))), a_949);
SetK(S_900, Call(nm_899, V.Undef, ((V)("poufout"))), Call(standup_23, V.Undef, PO_948, P_898));
}
{
V SP_951 = default;
SP_951 = Call(o_21, V.Undef, SP0_69, (SEqS(Get(P_898, "dn"), "float") ? NewObj(2).Put("sit", ((V)(0D))).Put("sk", ((V)(3D))).V : NewObj(0).V), (Get(X_897, "spp") is var _t952 && Truthy(_t952) ? _t952 : NewObj(0).V));
Call(H1_904, V.Undef, ((V)("splash")), SP_951, Arr(((V)("slap")), ((V)("kick")), ((V)("duck")), ((V)("atyou")), ((V)("soak")), ((V)("sig")), ((V)("slap")), ((V)("wave"))), SPB_70, Arr(((V)(500D)), ((V)(800D)), ((V)(600D))), NewObj(1).Put("breathe", ((V)(0.5))).V);
SetK(S_900, Call(nm_899, V.Undef, ((V)("splashin"))), Call(splashIn_71, V.Undef, SP_951, P_898));
SetK(S_900, Call(nm_899, V.Undef, ((V)("splashout"))), Call(splashOut_72, V.Undef, SP_951));
}
Set(Call(H1_904, V.Undef, ((V)("perform")), PF0_74, Arr(((V)("sing")), ((V)("step")), ((V)("sing")), ((V)("belt")), ((V)("point")), ((V)("spin")), ((V)("sing")), ((V)("sig")), ((V)("belt")), ((V)("bow"))), PFB_75, Arr(((V)(300D)), ((V)(500D)), ((V)(400D)))), "prop", Call(micProp_77, V.Undef, (Get(X_897, "mc") is var _t953 && Truthy(_t953) ? _t953 : ((V)("#3b3b4a")))));
Set(Call(H1_904, V.Undef, ((V)("dj")), DJ0_78, Arr(((V)("nod")), ((V)("scratch")), ((V)("nod")), ((V)("pump")), ((V)("point")), ((V)("nod")), ((V)("scratch")), ((V)("drop")), ((V)("sig")), ((V)("spin")), ((V)("pump"))), DJB_79, Arr(((V)(200D)), ((V)(300D)))), "prop", Call(phoneProp_80, V.Undef, (Get(X_897, "hc") is var _t954 && Truthy(_t954) ? _t954 : ((V)("#45189a")))));
Call(H1_904, V.Undef, ((V)("pinball")), PB0_81, Arr(((V)("flip")), ((V)("track")), ((V)("flip")), ((V)("nudge")), ((V)("multi")), ((V)("yay")), ((V)("flip")), ((V)("oops")), ((V)("sig"))), PBB_82, Arr(((V)(200D)), ((V)(400D)), ((V)(300D))));
Call(H1_904, V.Undef, ((V)("dancecab")), DC0_83, Arr(((V)("steps")), ((V)("arrows")), ((V)("steps")), ((V)("jump")), ((V)("combo")), ((V)("spin")), ((V)("steps")), ((V)("freeze")), ((V)("sig"))), DCB_84, Arr(((V)(150D)), ((V)(250D))));
{
V st_955 = default;
st_955 = Call(H1_904, V.Undef, ((V)("hockey")), HK0_85, Arr(((V)("ready")), ((V)("hit")), ((V)("ready")), ((V)("block")), ((V)("hit")), ((V)("yay")), ((V)("ready")), ((V)("hit")), ((V)("oops")), ((V)("sig"))), HKB_86, Arr(((V)(300D)), ((V)(500D)), ((V)(400D))));
Set(st_955, "prop", Call(puckProp_89, V.Undef, st_955, pc_903, ((V)(0D))));
}
{
V st_956 = default;
st_956 = Call(H1_904, V.Undef, ((V)("billiards")), BL0_90, Arr(((V)("chalk")), ((V)("aim")), ((V)("shoot")), ((V)("yay")), ((V)("aim")), ((V)("shoot")), ((V)("miss")), ((V)("circle")), ((V)("sig"))), BLB_91, Arr(((V)(500D)), ((V)(500D)), ((V)(0D))));
Set(st_956, "prop", Call(cueProp_92, V.Undef, st_956));
}
GM_905 = Fn((V _arrowThis969, int _argc957, V n_963, V B_964, V ord_965, V BK_966, V[] _rest958) => {
V st_970 = default;
V gaps_967 = default;
V prop_968 = default;
gaps_967 = (_argc957 > 4 ? _rest958[0] : V.Undef);
prop_968 = (_argc957 > 5 ? _rest958[1] : V.Undef);
st_970 = Call(H1_904, V.Undef, ((V)(JsStrBuf.Begin().S("g_").V(n_963).End())), B_964, ord_965, BK_966, gaps_967);
if (Truthy(prop_968)) {
Set(st_970, "prop", Call(prop_968, V.Undef, st_970));
}
return default;
}, 6, "", true);
Call(GM_905, V.Undef, ((V)("goal")), ST0_38, Arr(((V)("dribble")), ((V)("kick")), ((V)("watch")), ((V)("yay")), ((V)("dribble")), ((V)("header")), ((V)("dribble")), ((V)("kick")), ((V)("sig")), ((V)("yay"))), GOB_94, Arr(((V)(400D)), ((V)(600D)), ((V)(500D))), goalProp_95);
Call(GM_905, V.Undef, ((V)("keep")), KP0_96, Arr(((V)("ready")), ((V)("diveL")), ((V)("ready")), ((V)("catch")), ((V)("ready")), ((V)("diveR")), ((V)("punch")), ((V)("sig")), ((V)("ready")), ((V)("catch"))), KPB_98, Arr(((V)(300D)), ((V)(500D))), keepProp_99);
Call(GM_905, V.Undef, ((V)("hoop")), ST0_38, Arr(((V)("dribble")), ((V)("shoot")), ((V)("yay")), ((V)("dribble")), ((V)("spinball")), ((V)("dribble")), ((V)("shoot")), ((V)("oops")), ((V)("sig")), ((V)("dribble")), ((V)("shoot")), ((V)("yay"))), HPB_100, Arr(((V)(300D)), ((V)(500D)), ((V)(400D))), hoopProp_101);
Call(GM_905, V.Undef, ((V)("golf")), GF0_102, Arr(((V)("line")), ((V)("waggle")), ((V)("putt")), ((V)("yay")), ((V)("line")), ((V)("waggle")), ((V)("putt")), ((V)("oops")), ((V)("sig"))), GFB_103, Arr(((V)(400D)), ((V)(300D)), ((V)(300D))), golfProp_104);
Call(GM_905, V.Undef, ((V)("dome")), ST0_38, Arr(((V)("climb")), ((V)("hang")), ((V)("topwave")), ((V)("peek")), ((V)("hang")), ((V)("down")), ((V)("yay")), ((V)("climb")), ((V)("hang")), ((V)("down")), ((V)("sig"))), DMB_106, Arr(((V)(300D)), ((V)(200D))));
Call(GM_905, V.Undef, ((V)("agility")), ST0_38, Arr(((V)("hurdle")), ((V)("weave")), ((V)("pant")), ((V)("tire")), ((V)("ramp")), ((V)("yay")), ((V)("sig")), ((V)("hurdle")), ((V)("pant"))), AGB_107, Arr(((V)(300D)), ((V)(500D))));
Call(GM_905, V.Undef, ((V)("bocce")), ST0_38, Arr(((V)("aim")), ((V)("roll")), ((V)("watch")), ((V)("yay")), ((V)("aim")), ((V)("roll")), ((V)("watch")), ((V)("oops")), ((V)("sig"))), NewObj(2).Put("aim", aimB_109).Put("roll", Call(tossB_108, V.Undef, ((V)("bocce")))).V, Arr(((V)(500D)), ((V)(300D)), ((V)(200D))), Fn((V _arrowThis978, int _argc971, V st_977, V _a974, V _a975, V _a976, V[] _rest972) => {
return Call(tossProp_110, V.Undef, st_977, ((V)("bocce")));
}, 1, "", true));
Call(GM_905, V.Undef, ((V)("cornhole")), ST0_38, Arr(((V)("aim")), ((V)("toss")), ((V)("yay")), ((V)("aim")), ((V)("toss")), ((V)("watch")), ((V)("oops")), ((V)("sig"))), NewObj(2).Put("aim", aimB_109).Put("toss", Call(tossB_108, V.Undef, ((V)("bag")))).V, Arr(((V)(500D)), ((V)(300D)), ((V)(300D))), Fn((V _arrowThis986, int _argc979, V st_985, V _a982, V _a983, V _a984, V[] _rest980) => {
return Call(tossProp_110, V.Undef, st_985, ((V)("bag")), pc_903);
}, 1, "", true));
Call(GM_905, V.Undef, ((V)("shoe")), ST0_38, Arr(((V)("aim")), ((V)("toss")), ((V)("yay")), ((V)("aim")), ((V)("toss")), ((V)("oops")), ((V)("sig"))), NewObj(2).Put("aim", aimB_109).Put("toss", Call(tossB_108, V.Undef, ((V)("shoe")))).V, Arr(((V)(500D)), ((V)(300D)), ((V)(300D))), Fn((V _arrowThis994, int _argc987, V st_993, V _a990, V _a991, V _a992, V[] _rest988) => {
return Call(tossProp_110, V.Undef, st_993, ((V)("shoe")));
}, 1, "", true));
Call(GM_905, V.Undef, ((V)("pong")), PG0_111, Arr(((V)("serve")), ((V)("rally")), ((V)("smash")), ((V)("yay")), ((V)("serve")), ((V)("rally")), ((V)("oops")), ((V)("sig"))), PGB_112, Arr(((V)(300D)), ((V)(0D)), ((V)(0D)), ((V)(400D))), Fn((V _arrowThis1002, int _argc995, V st_1001, V _a998, V _a999, V _a1000, V[] _rest996) => {
return Call(puckProp_89, V.Undef, st_1001, pc_903, ((V)(1D)));
}, 1, "", true));
Call(GM_905, V.Undef, ((V)("tether")), ST0_38, Arr(((V)("punch")), ((V)("track")), ((V)("duck")), ((V)("punch")), ((V)("double")), ((V)("yay")), ((V)("track")), ((V)("sig"))), TTB_113, Arr(((V)(400D)), ((V)(300D))));
Call(GM_905, V.Undef, ((V)("villa")), SB_901, Arr(((V)("look")), ((V)("wave")), ((V)("wiggle")), ((V)("yawn")), ((V)("giggle")), ((V)("sig")), ((V)("doze")), ((V)("nod"))), NewObj(0).V, Arr(((V)(900D)), ((V)(1400D)), ((V)(1100D))));
Call(GM_905, V.Undef, ((V)("hop")), ST0_38, Arr(((V)("toss")), ((V)("hops")), ((V)("twirl")), ((V)("hopback")), ((V)("pick")), ((V)("yay")), ((V)("sig"))), HSB_114, Arr(((V)(400D)), ((V)(200D)), ((V)(200D)), ((V)(200D)), ((V)(300D))));
Call(GM_905, V.Undef, ((V)("tunnel")), TU0_116, Arr(((V)("crawl")), ((V)("peek")), ((V)("crawl")), ((V)("pop")), ((V)("crawl")), ((V)("giggle")), ((V)("sig"))), TUB_117, Arr(((V)(300D)), ((V)(500D))));
Call(GM_905, V.Undef, ((V)("frisbee")), ST0_38, Arr(((V)("throw")), ((V)("catch")), ((V)("yay")), ((V)("throw")), ((V)("catch")), ((V)("sig")), ((V)("throw")), ((V)("catch")), ((V)("clap"))), FRB_118, Arr(((V)(300D)), ((V)(0D)), ((V)(400D))), Fn((V _arrowThis1010, int _argc1003, V st_1009, V _a1006, V _a1007, V _a1008, V[] _rest1004) => {
return Call(frisbeeProp_119, V.Undef, st_1009, (Get(X_897, "fc2") is var _t1011 && Truthy(_t1011) ? _t1011 : ((V)("#ffcc3a"))));
}, 1, "", true));
Call(GM_905, V.Undef, ((V)("cheer")), ST0_38, Arr(((V)("clap")), ((V)("watch")), ((V)("yay")), ((V)("look")), ((V)("clap")), ((V)("sig")), ((V)("wave")), ((V)("oops")), ((V)("clap"))), NewObj(0).V, Arr(((V)(500D)), ((V)(800D)), ((V)(600D))));
Invoke(R_10, "add", S_900);
Set(R_10, "HS", Object_assign((Get(R_10, "HS") is var _t1012 && Truthy(_t1012) ? _t1012 : NewObj(0).V), S_900));
if (Truthy(key_896)) {
SetK(CX_120, key_896, X_897);
}
return default;
}, 2, "cBuild", false);
R_10 = Get(G("window"), "RiveRig");
REST_11 = Get(R_10, "REST");
{ V _t1013 = H_9;
if (_t1013.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1013));
{ V _t1014 = Get(_t1013, "TL");
TL_12 = _t1014; }
{ V _t1015 = Get(_t1013, "BEAT");
BEAT_13 = _t1015; }
{ V _t1016 = Get(_t1013, "hand");
hand_14 = _t1016; }
{ V _t1017 = Get(_t1013, "both");
both_15 = _t1017; }
{ V _t1018 = Get(_t1013, "SIDE");
SIDE_16 = _t1018; }
{ V _t1019 = Get(_t1013, "SIT0");
SIT0_17 = _t1019; }
{ V _t1020 = Get(_t1013, "PROF");
PROF_18 = _t1020; }
{ V _t1021 = Get(_t1013, "BB");
BB_19 = _t1021; }
{ V _t1022 = Get(_t1013, "ICON");
ICON_20 = _t1022; }
{ V _t1023 = Get(_t1013, "o");
o_21 = _t1023; }
{ V _t1024 = Get(_t1013, "sitdown");
sitdown_22 = _t1024; }
{ V _t1025 = Get(_t1013, "standup");
standup_23 = _t1025; }
{ V _t1026 = Get(_t1013, "gnd");
gnd_24 = _t1026; }
{ V _t1027 = Get(_t1013, "rside");
rside_25 = _t1027; }
{ V _t1028 = Get(_t1013, "G");
G_26 = _t1028; }
{ V _t1029 = Get(_t1013, "facing");
facing_27 = _t1029; }
{ V _t1030 = Get(_t1013, "ss");
ss_28 = _t1030; }
{ V _t1031 = Get(_t1013, "cl");
cl_29 = _t1031; }
{ V _t1032 = Get(_t1013, "r2");
r2_30 = _t1032; }
{ V _t1033 = Get(_t1013, "shade");
shade_31 = _t1033; }
{ V _t1034 = Get(_t1013, "ci");
ci_32 = _t1034; }
{ V _t1035 = Get(_t1013, "pa");
pa_33 = _t1035; }
{ V _t1036 = Get(_t1013, "lerp");
lerp_34 = _t1036; }
{ V _t1037 = Get(_t1013, "okp");
okp_35 = _t1037; }
{ V _t1038 = Get(_t1013, "BATH0");
BATH0_36 = _t1038; } }
if ((!(Truthy(sitdown_22)) || !(Truthy(G_26)))) {
Invoke(G("console"), "warn", ((V)("house-cx: house-moves.js too old")));
return default;
}
K_37 = Get(G("Object"), "keys");
ST0_38 = NewObj(31).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("pitch", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("smile", ((V)(0.7))).Put("hap", ((V)(0.3))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).Put("htilt", ((V)(0D))).Put("close", ((V)(0D))).Put("wide", ((V)(0D))).Put("sqz", ((V)(0D))).Put("turn", ((V)(0D))).Put("spin", ((V)(0D))).Put("tongue", ((V)(0D))).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).Put("frown", ((V)(0D))).V;
S0_39 = Fn((V _arrowThis1047, int _argc1039, V x_1045, V _a1042, V _a1043, V _a1044, V[] _rest1040) => {
V a_1046 = default;
a_1046 = RestArgs(1, _argc1039, x_1045, _a1042, _a1043, _a1044, _rest1040);
return CallSpread(o_21, V.Undef, new ArrBuilder().Add(ST0_38).Spread(a_1046).Add((x_1045 is var _t1048 && Truthy(_t1048) ? _t1048 : NewObj(0).V)).V);
}, 2, "", true);
flyF_41 = Fn((V _arrowThis1058, int _argc1049, V L_1055, V tl_1056, V F_1057, V _a1054, V[] _rest1050) => {
V e_1059 = default;
double d_1060 = 0;
e_1059 = V.Null;
Invoke((L_1055 is var _t1069 && Truthy(_t1069) ? _t1069 : Arr()), "forEach", Fn((V _arrowThis1068, int _argc1061, V v_1067, V _a1064, V _a1065, V _a1066, V[] _rest1062) => {
if (Le(v_1067, tl_1056)) {
e_1059 = v_1067;
}
return default;
}, 1, "", true));
if (e_1059.IsNullish) {
return V.Null;
}
d_1060 = (ToNum(tl_1056) - ToNum(e_1059));
if (Lt(((V)(d_1060)), Get(F_1057, "fly"))) {
return Arr(((V)("fly")), ((V)((d_1060 / ToNum(Get(F_1057, "fly"))))), e_1059, ((V)(d_1060)));
}
if (Lt(((V)(d_1060)), Get(F_1057, "away"))) {
return Arr(((V)("away")), ((V)(1D)), e_1059, ((V)(d_1060)));
}
if (Lt(((V)(d_1060)), Add(Get(F_1057, "away"), Get(F_1057, "ret")))) {
return Arr(((V)("ret")), ((V)(((d_1060 - ToNum(Get(F_1057, "away"))) / ToNum(Get(F_1057, "ret"))))), e_1059, ((V)(d_1060)));
}
return V.Null;
return default;
}, 3, "", true);
g0_42 = Fn((V _arrowThis1077, int _argc1070, V I_1076, V _a1073, V _a1074, V _a1075, V[] _rest1071) => {
V gx_1078 = default;
V gy_1079 = default;
{ V _t1080 = Call(gnd_24, V.Undef, I_1076);
{ V _t1081 = ListOf(_t1080);
{ V _t1082 = GetIdx(_t1081, 0D);
gx_1078 = _t1082; }
{ V _t1083 = GetIdx(_t1081, 1D);
gy_1079 = _t1083; }
} }
return Arr(((V)((ToNum(gx_1078) - ToNum(((Get(I_1076, "lastP") is var _t1084 && !Truthy(_t1084) ? _t1084 : Get(Get(I_1076, "lastP"), "x")) is var _t1085 && Truthy(_t1085) ? _t1085 : ((V)(0D))))))), gy_1079);
return default;
}, 1, "", true);
mid_43 = Fn((V _arrowThis1093, int _argc1086, V W_1092, V _a1089, V _a1090, V _a1091, V[] _rest1087) => {
return (Truthy((Call(okp_35, V.Undef, Get(W_1092, "pawL")) is var _t1094 && !Truthy(_t1094) ? _t1094 : Call(okp_35, V.Undef, Get(W_1092, "pawR")))) ? Arr(((V)((ToNum(Add(GetIdx(Get(W_1092, "pawL"), 0D), GetIdx(Get(W_1092, "pawR"), 0D))) / 2D))), ((V)((ToNum(Add(GetIdx(Get(W_1092, "pawL"), 1D), GetIdx(Get(W_1092, "pawR"), 1D))) / 2D)))) : Get(W_1092, "pawR"));
}, 1, "", true);
hx_44 = Fn((V _arrowThis1102, int _argc1095, V h_1101, V _a1098, V _a1099, V _a1100, V[] _rest1096) => {
return Invoke(Arr(((V)(1D)), ((V)(3D)), ((V)(5D))), "map", Fn((V _arrowThis1110, int _argc1103, V i_1109, V _a1106, V _a1107, V _a1108, V[] _rest1104) => {
return ((V)(ParseInt(Invoke(h_1101, "slice", i_1109, Add(i_1109, ((V)(2D)))), ((V)(16D)))));
}, 1, "", true));
}, 1, "", true);
mixC_45 = Fn((V _arrowThis1120, int _argc1111, V a_1117, V b_1118, V u_1119, V _a1116, V[] _rest1112) => {
V A_1121 = default;
V B_1122 = default;
A_1121 = Call(hx_44, V.Undef, a_1117);
B_1122 = Call(hx_44, V.Undef, b_1118);
return ((V)(JsStrBuf.Begin().S("rgb(").V(Invoke(Invoke(A_1121, "map", Fn((V _arrowThis1131, int _argc1123, V v_1129, V i_1130, V _a1127, V _a1128, V[] _rest1124) => {
return ((V)(Round(ToNum(Add(v_1129, ((V)(((ToNum(GetK(B_1122, i_1130)) - ToNum(v_1129)) * ToNum(Call(cl_29, V.Undef, u_1119, ((V)(0D)), ((V)(1D))))))))))));
}, 2, "", true)), "join", ((V)(",")))).S(")").End()));
return default;
}, 3, "", true);
push_46 = Fn((V _arrowThis1141, int _argc1132, V rec_1138, V k_1139, V v_1140, V _a1137, V[] _rest1133) => {
return Invoke(SetK(rec_1138, k_1139, (GetK(rec_1138, k_1139) is var _t1142 && Truthy(_t1142) ? _t1142 : Arr())), "push", v_1140);
}, 3, "", true);
COM_49 = NewObj(5).Put("yay", Fn((V _self1143, int _argc1144, V t_1150, V X_1151, V _a1148, V _a1149, V[] _rest1145) => {
if (_self1143.IsNullish) _self1143 = GlobalV;
Call(cheer_47, V.Undef, t_1150, X_1151);
return t_1150;
return default;
}, 2, "yay", false)).Put("oops", Fn((V _self1152, int _argc1153, V t_1159, V _a1156, V _a1157, V _a1158, V[] _rest1154) => {
if (_self1152.IsNullish) _self1152 = GlobalV;
Call(frown_48, V.Undef, t_1159);
return t_1159;
return default;
}, 1, "oops", false)).Put("watch", Fn((V _self1160, int _argc1161, V t_1167, V _a1164, V _a1165, V _a1166, V[] _rest1162) => {
if (_self1160.IsNullish) _self1160 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_1167, "to", ((V)(320D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-15D)))), NewObj(5).Put("armR", ((V)(118D))).Put("lx", ((V)(0.9))).Put("ly", ((V)((-0.2)))).Put("htilt", ((V)(6D))).Put("lean", ((V)(0.4))).V), ((V)("io"))), "wait", ((V)(900D))), "to", ((V)(240D)), NewObj(2).Put("lx", ((V)(0.6))).Put("ly", ((V)(0.2))).V), "wait", ((V)(400D)));
return Invoke(t_1167, "back", ((V)(380D)));
return default;
}, 1, "watch", false)).Put("pant", Fn((V _self1168, int _argc1169, V t_1175, V _a1172, V _a1173, V _a1174, V[] _rest1170) => {
V Q_1176 = default;
if (_self1168.IsNullish) _self1168 = GlobalV;
Q_1176 = (Get(Get(t_1175, "B"), "sq") is var _t1177 && Truthy(_t1177) ? _t1177 : ((V)(0D)));
Invoke(Invoke(Invoke(t_1175, "to", ((V)(200D)), NewObj(4).Put("open", ((V)(0.45))).Put("mw", ((V)(0.7))).Put("tongue", ((V)(0.4))).Put("close", ((V)(0.3))).V), "osc", ((V)(1200D)), ((V)(8D)), NewObj(1).Put("sq", Add(Q_1176, ((V)(0.03)))).V, NewObj(1).Put("sq", ((V)((ToNum(Q_1176) - 0.01)))).V, ((V)("l"))), "fx", ((V)("sweat")), ((V)("head")), ((V)(1D)));
return Invoke(t_1175, "back", ((V)(300D)));
return default;
}, 1, "pant", false)).Put("clap", Fn((V _self1178, int _argc1179, V t_1185, V _a1182, V _a1183, V _a1184, V[] _rest1180) => {
if (_self1178.IsNullish) _self1178 = GlobalV;
Invoke(t_1185, "to", ((V)(240D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(10D)), ((V)((-6D)))), NewObj(5).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V), ((V)("o")));
{
double i_1186 = 0;
i_1186 = 0D;
while (true) {
if (!((i_1186 < 5D))) break;
Invoke(Invoke(t_1185, "to", ((V)(110D)), NewObj(2).Put("hLx", ((V)(6D))).Put("hRx", ((V)((-6D)))).V, ((V)("l"))), "to", ((V)(110D)), NewObj(2).Put("hLx", ((V)(11D))).Put("hRx", ((V)((-11D)))).V, ((V)("l")));
i_1186++;
}
}
return Invoke(t_1185, "back", ((V)(340D)));
return default;
}, 1, "clap", false)).V;
BW0_52 = Call(S0_39, V.Undef, NewObj(7).Put("pitch", ((V)((-0.3)))).Put("ly", ((V)(0.9))).Put("sq", ((V)(0.07))).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("smile", ((V)(0.8))).Put("hap", ((V)(0.4))).V, Call(both_15, V.Undef, ((V)(4D)), ((V)(4D))));
BWB_53 = NewObj(6).Put("munch", Fn((V _self1188, int _argc1189, V t_1195, V X_1196, V rec_1197, V _a1194, V[] _rest1190) => {
V B_1198 = default;
if (_self1188.IsNullish) _self1188 = GlobalV;
B_1198 = Get(t_1195, "B");
Invoke(t_1195, "to", ((V)(260D)), NewObj(4).Put("pitch", ((V)((ToNum(Get(B_1198, "pitch")) - 0.12)))).Put("sq", Add(Get(B_1198, "sq"), ((V)(0.03)))).Put("lift", ((V)((-0.6)))).Put("open", ((V)(0.4))).V, ((V)("io")));
Call(push_46, V.Undef, rec_1197, ((V)("bite")), Get(t_1195, "t"));
Invoke(Invoke(Invoke(t_1195, "osc", ((V)(1200D)), ((V)(4D)), NewObj(2).Put("open", ((V)(0.42))).Put("puff", ((V)(0.15))).V, NewObj(2).Put("open", ((V)(0D))).Put("puff", ((V)(0.5))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("mouth")), ((V)(3D))), "osc", ((V)(600D)), ((V)(2D)), NewObj(1).Put("open", ((V)(0.38))).V, NewObj(2).Put("open", ((V)(0D))).Put("puff", ((V)(0.4))).V, ((V)("l")));
return Invoke(t_1195, "back", ((V)(300D)));
return default;
}, 3, "munch", false)).Put("up", Fn((V _self1199, int _argc1200, V t_1206, V _a1203, V _a1204, V _a1205, V[] _rest1201) => {
if (_self1199.IsNullish) _self1199 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_1206, "to", ((V)(340D)), NewObj(5).Put("pitch", ((V)(0.04))).Put("ly", ((V)((-0.1)))).Put("lx", ((V)(0.5))).Put("sq", ((V)(0D))).Put("puff", ((V)(0.4))).V, ((V)("io"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(1).Put("puff", ((V)(0.55))).V, NewObj(1).Put("puff", ((V)(0.2))).V, ((V)("l"))), "to", ((V)(420D)), NewObj(2).Put("lx", ((V)((-0.5)))).Put("htilt", ((V)((-4D)))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(3D)), NewObj(1).Put("puff", ((V)(0.5))).V, NewObj(1).Put("puff", ((V)(0.15))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(1).Put("puff", ((V)(0D))).V);
return Invoke(t_1206, "back", ((V)(380D)));
return default;
}, 1, "up", false)).Put("slurp", Fn((V _self1207, int _argc1208, V t_1214, V _a1211, V _a1212, V _a1213, V[] _rest1209) => {
V B_1215 = default;
if (_self1207.IsNullish) _self1207 = GlobalV;
B_1215 = Get(t_1214, "B");
Invoke(Invoke(Invoke(Invoke(t_1214, "to", ((V)(280D)), NewObj(3).Put("pitch", ((V)((ToNum(Get(B_1215, "pitch")) - 0.16)))).Put("sq", Add(Get(B_1215, "sq"), ((V)(0.04)))).Put("close", ((V)(0.6))).V, ((V)("io"))), "osc", ((V)(1100D)), ((V)(6D)), NewObj(2).Put("tongue", ((V)(0.6))).Put("sq", Add(Get(B_1215, "sq"), ((V)(0.05)))).V, NewObj(2).Put("tongue", ((V)(0.1))).Put("sq", Add(Get(B_1215, "sq"), ((V)(0.03)))).V, ((V)("l"))), "fx", ((V)("drop")), ((V)("mouth")), ((V)(3D))), "to", ((V)(160D)), NewObj(1).Put("tongue", ((V)(0D))).V);
return Invoke(t_1214, "back", ((V)(320D)));
return default;
}, 1, "slurp", false)).Put("lick", Fn((V _self1216, int _argc1217, V t_1223, V _a1220, V _a1221, V _a1222, V[] _rest1218) => {
if (_self1216.IsNullish) _self1216 = GlobalV;
Invoke(Invoke(Invoke(t_1223, "to", ((V)(300D)), NewObj(4).Put("pitch", ((V)((-0.04)))).Put("ly", ((V)(0D))).Put("close", ((V)(0.5))).Put("smile", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(1000D)), ((V)(4D)), NewObj(1).Put("tongue", ((V)(0.65))).V, NewObj(1).Put("tongue", ((V)(0.15))).V, ((V)("s"))), "to", ((V)(160D)), NewObj(1).Put("tongue", ((V)(0D))).V);
return Invoke(t_1223, "back", ((V)(360D)));
return default;
}, 1, "lick", false)).Put("tummy", Fn((V _self1224, int _argc1225, V t_1231, V X_1232, V _a1229, V _a1230, V[] _rest1226) => {
if (_self1224.IsNullish) _self1224 = GlobalV;
Invoke(BEAT_13, "belly", t_1231, ((V)((-1D))));
Invoke(Invoke(Invoke(t_1231, "to", ((V)(240D)), Call(o_21, V.Undef, NewObj(3).Put("smile", ((V)(1D))).Put("hap", ((V)(1D))).Put("sqz", ((V)(0.6))).V, Get(X_1232, "cheer")), ((V)("o"))), "fx", ((V)("heart")), ((V)("head")), ((V)(2D))), "wait", ((V)(300D)));
return Invoke(t_1231, "back", ((V)(380D)));
return default;
}, 2, "tummy", false)).Put("hic", Fn((V _self1233, int _argc1234, V t_1240, V _a1237, V _a1238, V _a1239, V[] _rest1235) => {
V B_1241 = default;
if (_self1233.IsNullish) _self1233 = GlobalV;
B_1241 = Get(t_1240, "B");
{
double i_1242 = 0;
i_1242 = 0D;
while (true) {
if (!((i_1242 < 2D))) break;
Invoke(Invoke(Invoke(Invoke(t_1240, "to", ((V)(80D)), NewObj(4).Put("sq", ((V)((ToNum(Get(B_1241, "sq")) - 0.07)))).Put("lift", ((V)(1.8))).Put("wide", ((V)(0.9))).Put("open", ((V)(0.2))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("sq", Get(B_1241, "sq")).Put("lift", ((V)(0D))).V, ((V)("i"))), "fx", ((V)("bubble")), ((V)("mouth")), ((V)(1D))), "wait", ((V)(420D)));
i_1242++;
}
}
Invoke(BEAT_13, "giggle", t_1240, ((V)((-1D))));
return t_1240;
return default;
}, 1, "hic", false)).V;
DS0_54 = Call(S0_39, V.Undef, NewObj(5).Put("pitch", ((V)((-0.16)))).Put("ly", ((V)(0.7))).Put("armL", ((V)(28D))).Put("armR", ((V)(30D))).Put("smile", ((V)(0.6))).V, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(8D)), ((V)((-1D)))), Call(hand_14, V.Undef, ((V)(1D)), ((V)(6D)), ((V)(0D))));
DSB_55 = NewObj(5).Put("scrub", Fn((V _self1244, int _argc1245, V t_1251, V X_1252, V rec_1253, V _a1250, V[] _rest1246) => {
V B_1254 = default;
V a_1255 = default;
if (_self1244.IsNullish) _self1244 = GlobalV;
B_1254 = Get(t_1251, "B");
a_1255 = Get(t_1251, "t");
Invoke(t_1251, "to", ((V)(200D)), NewObj(2).Put("sqz", ((V)(0.3))).Put("smile", ((V)(0.9))).V);
{
double i_1256 = 0;
i_1256 = 0D;
while (true) {
if (!((i_1256 < 8D))) break;
Invoke(Invoke(t_1251, "to", ((V)(115D)), NewObj(2).Put("hRx", ((V)((ToNum(Get(B_1254, "hRx")) - 2.4)))).Put("hRy", ((V)((ToNum(Get(B_1254, "hRy")) - 1.6)))).V, ((V)("l"))), "to", ((V)(115D)), NewObj(2).Put("hRx", Add(Get(B_1254, "hRx"), ((V)(1D)))).Put("hRy", Add(Get(B_1254, "hRy"), ((V)(1.4)))).V, ((V)("l")));
if (((i_1256 % 3D) == 0D)) {
Invoke(t_1251, "fx", ((V)("foam")), ((V)("pawR")), ((V)(2D)));
}
i_1256++;
}
}
Call(push_46, V.Undef, rec_1253, ((V)("sc")), Arr(a_1255, Get(t_1251, "t")));
return Invoke(t_1251, "back", ((V)(260D)));
return default;
}, 3, "scrub", false)).Put("rinse", Fn((V _self1258, int _argc1259, V t_1265, V _a1262, V _a1263, V _a1264, V[] _rest1260) => {
V B_1266 = default;
if (_self1258.IsNullish) _self1258 = GlobalV;
B_1266 = Get(t_1265, "B");
Invoke(Invoke(Invoke(Invoke(t_1265, "to", ((V)(300D)), NewObj(5).Put("hLy", Add(Get(B_1266, "hLy"), ((V)(3D)))).Put("hRy", Add(Get(B_1266, "hRy"), ((V)(3D)))).Put("armL", ((V)(22D))).Put("armR", ((V)(24D))).Put("ly", ((V)(0.9))).V, ((V)("io"))), "osc", ((V)(1100D)), ((V)(4D)), NewObj(2).Put("tilt", ((V)(3D))).Put("hLx", Add(Get(B_1266, "hLx"), ((V)(1.4)))).V, NewObj(2).Put("tilt", ((V)((-3D)))).Put("hLx", ((V)((ToNum(Get(B_1266, "hLx")) - 1D)))).V, ((V)("s"))), "fx", ((V)("drop")), ((V)("pawL")), ((V)(4D))), "fx", ((V)("splash")), ((V)("pawL")), ((V)(2D)));
return Invoke(t_1265, "back", ((V)(320D)));
return default;
}, 1, "rinse", false)).Put("squeak", Fn((V _self1267, int _argc1268, V t_1274, V _a1271, V _a1272, V _a1273, V[] _rest1269) => {
V B_1275 = default;
if (_self1267.IsNullish) _self1267 = GlobalV;
B_1275 = Get(t_1274, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(t_1274, "to", ((V)(380D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)((-11D)))), NewObj(5).Put("armL", ((V)(54D))).Put("pitch", Add(Get(B_1275, "pitch"), ((V)(0.22)))).Put("ly", ((V)((-0.3)))).Put("lx", ((V)((-0.5)))).Put("wide", ((V)(0.5))).V), ((V)("io"))), "fx", ((V)("spark")), ((V)("pawL")), ((V)(4D))), "to", ((V)(200D)), NewObj(4).Put("winkR", ((V)(1D))).Put("sqz", ((V)(0.5))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.7))).V, ((V)("o"))), "wait", ((V)(500D))), "to", ((V)(160D)), NewObj(1).Put("winkR", ((V)(0D))).V);
return Invoke(t_1274, "back", ((V)(400D)));
return default;
}, 1, "squeak", false)).Put("stack", Fn((V _self1276, int _argc1277, V t_1283, V X_1284, V rec_1285, V _a1282, V[] _rest1278) => {
V B_1286 = default;
V a_1287 = default;
if (_self1276.IsNullish) _self1276 = GlobalV;
B_1286 = Get(t_1283, "B");
a_1287 = Get(t_1283, "t");
Invoke(Invoke(t_1283, "to", ((V)(420D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(16D)), ((V)(2D))), NewObj(5).Put("armL", ((V)(34D))).Put("lean", ((V)(0.8))).Put("tilt", ((V)(3D))).Put("lx", ((V)(0.8))).Put("ly", ((V)(0.6))).V), ((V)("io"))), "to", ((V)(140D)), NewObj(2).Put("hLy", ((V)(4D))).Put("sq", Add(Get(B_1286, "sq"), ((V)(0.03)))).V, ((V)("i")));
Call(push_46, V.Undef, rec_1285, ((V)("st")), Arr(a_1287, Get(t_1283, "t")));
Invoke(t_1283, "wait", ((V)(200D)));
return Invoke(t_1283, "back", ((V)(420D)));
return default;
}, 3, "stack", false)).Put("bubble", Fn((V _self1288, int _argc1289, V t_1295, V _a1292, V _a1293, V _a1294, V[] _rest1290) => {
if (_self1288.IsNullish) _self1288 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_1295, "to", ((V)(260D)), NewObj(5).Put("puff", ((V)(0.8))).Put("open", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)((-0.4)))).Put("pitch", ((V)(0.12))).V), "to", ((V)(500D)), NewObj(3).Put("puff", ((V)(0.2))).Put("open", ((V)(0.2))).Put("mw", ((V)(0.4))).V, ((V)("s"))), "fx", ((V)("bubble")), ((V)("mouth")), ((V)(2D))), "to", ((V)(200D)), NewObj(4).Put("wide", ((V)(0.8))).Put("open", ((V)(0.4))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(300D)));
Invoke(BEAT_13, "giggle", t_1295, ((V)(1D)));
return t_1295;
return default;
}, 1, "bubble", false)).V;
PLATE_56 = Fn((V _arrowThis1303, int _argc1296, V d_1302, V _a1299, V _a1300, V _a1301, V[] _rest1297) => {
return ((V)(string.Concat("<ellipse cx=\"0\" cy=\"0\" rx=\"6\" ry=\"2.4\" fill=\"#ffffff\" stroke=\"#9fb4c9\" stroke-width=\"0.45\"/><ellipse cx=\"0\" cy=\"-0.2\" rx=\"3.8\" ry=\"1.3\" fill=\"none\" stroke=\"#5ab4f0\" stroke-width=\"0.4\" opacity=\"0.8\"/>", (GtN(d_1302, 0.03) ? JsStrBuf.Begin().S("<g opacity=\"").V(Call(r2_30, V.Undef, d_1302)).S("\">").V(Call(ci_32, V.Undef, ((V)((-2D))), ((V)((-0.2))), ((V)(0.9)), ((V)("#c9a46a")))).V(Call(ci_32, V.Undef, ((V)(1.6)), ((V)(0.4)), ((V)(0.7)), ((V)("#b9864a")))).V(Call(ci_32, V.Undef, ((V)(0.4)), ((V)((-0.6))), ((V)(0.5)), ((V)("#d9b07a")))).S("</g>").End() : ""))));
}, 1, "", true);
SPONGE_57 = ((V)("<rect x=\"-2.4\" y=\"-1.6\" width=\"4.8\" height=\"3.2\" rx=\"0.7\" fill=\"#ffd24a\" stroke=\"#d9a22a\" stroke-width=\"0.35\"/><rect x=\"-2.4\" y=\"-1.6\" width=\"4.8\" height=\"1.1\" rx=\"0.5\" fill=\"#7cc35a\" stroke=\"#4f8f3a\" stroke-width=\"0.3\"/>"));
GR0_59 = Call(S0_39, V.Undef, NewObj(6).Put("pitch", ((V)((-0.12)))).Put("ly", ((V)(0.6))).Put("armR", ((V)(40D))).Put("armL", ((V)(18D))).Put("smile", ((V)(0.8))).Put("hap", ((V)(0.4))).V, Call(hand_14, V.Undef, ((V)(1D)), ((V)(2D)), ((V)((-4D)))), Call(hand_14, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)(2D))));
GRB_60 = NewObj(6).Put("poke", Fn((V _self1304, int _argc1305, V t_1311, V _a1308, V _a1309, V _a1310, V[] _rest1306) => {
V B_1312 = default;
if (_self1304.IsNullish) _self1304 = GlobalV;
B_1312 = Get(t_1311, "B");
Invoke(Invoke(Invoke(t_1311, "to", ((V)(200D)), NewObj(1).Put("sqz", ((V)(0.2))).V), "osc", ((V)(1000D)), ((V)(4D)), NewObj(2).Put("hRy", Add(Get(B_1312, "hRy"), ((V)(2.4)))).Put("armR", ((V)((ToNum(Get(B_1312, "armR")) - 4D)))).V, NewObj(2).Put("hRy", Get(B_1312, "hRy")).Put("armR", Get(B_1312, "armR")).V, ((V)("io"))), "fx", ((V)("gust")), ((V)("pawR")), ((V)(1D)));
return Invoke(t_1311, "back", ((V)(260D)));
return default;
}, 1, "poke", false)).Put("flip", Fn((V _self1313, int _argc1314, V t_1320, V X_1321, V rec_1322, V _a1319, V[] _rest1315) => {
V B_1323 = default;
if (_self1313.IsNullish) _self1313 = GlobalV;
B_1323 = Get(t_1320, "B");
Invoke(t_1320, "to", ((V)(240D)), NewObj(4).Put("hRy", Add(Get(B_1323, "hRy"), ((V)(3D)))).Put("armR", ((V)((ToNum(Get(B_1323, "armR")) - 8D)))).Put("sq", Add(Get(B_1323, "sq"), ((V)(0.04)))).Put("wide", ((V)(0.3))).V, ((V)("io")));
Call(push_46, V.Undef, rec_1322, ((V)("fl")), Get(t_1320, "t"));
Invoke(t_1320, "to", ((V)(150D)), NewObj(7).Put("hRy", ((V)((ToNum(Get(B_1323, "hRy")) - 7D)))).Put("armR", Add(Get(B_1323, "armR"), ((V)(30D)))).Put("sq", ((V)((ToNum(Get(B_1323, "sq")) - 0.03)))).Put("ly", ((V)((-0.6)))).Put("pitch", Add(Get(B_1323, "pitch"), ((V)(0.2)))).Put("open", ((V)(0.4))).Put("mw", ((V)(0.6))).V, ((V)("o")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_1320, "to", ((V)(320D)), NewObj(3).Put("ly", ((V)((-0.9)))).Put("pitch", Add(Get(B_1323, "pitch"), ((V)(0.28)))).Put("wide", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(330D)), NewObj(4).Put("ly", Get(B_1323, "ly")).Put("pitch", Get(B_1323, "pitch")).Put("hRy", Get(B_1323, "hRy")).Put("armR", Get(B_1323, "armR")).V, ((V)("i"))), "fx", ((V)("gust")), ((V)("pawR")), ((V)(1D))), "to", ((V)(220D)), NewObj(6).Put("sqz", ((V)(0.7))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("mw", ((V)(1D))).Put("wide", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(300D)));
return Invoke(t_1320, "back", ((V)(320D)));
return default;
}, 3, "flip", false)).Put("smoke", Fn((V _self1324, int _argc1325, V t_1331, V _a1328, V _a1329, V _a1330, V[] _rest1326) => {
V B_1332 = default;
if (_self1324.IsNullish) _self1324 = GlobalV;
B_1332 = Get(t_1331, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(t_1331, "to", ((V)(260D)), NewObj(5).Put("lean", ((V)((-1D)))).Put("pitch", Add(Get(B_1332, "pitch"), ((V)(0.14)))).Put("close", ((V)(0.8))).Put("sqz", ((V)(0.9))).Put("puff", ((V)(0.4))).V, ((V)("o"))), "osc", ((V)(1200D)), ((V)(5D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(2D)), ((V)((-6D)))), NewObj(1).Put("armL", ((V)(72D))).V), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(2D)), ((V)((-4D)))), NewObj(1).Put("armL", ((V)(44D))).V), ((V)("io"))), "fx", ((V)("sweat")), ((V)("head")), ((V)(1D))), "to", ((V)(220D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("mouth")), ((V)(1D)));
return Invoke(t_1331, "back", ((V)(400D)));
return default;
}, 1, "smoke", false)).Put("season", Fn((V _self1333, int _argc1334, V t_1340, V _a1337, V _a1338, V _a1339, V[] _rest1335) => {
if (_self1333.IsNullish) _self1333 = GlobalV;
Invoke(Invoke(Invoke(t_1340, "to", ((V)(320D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(4D)), ((V)((-6D)))), NewObj(2).Put("armL", ((V)(64D))).Put("lx", ((V)(0.4))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(5D)), NewObj(2).Put("hLy", ((V)((-8D)))).Put("tilt", ((V)(1D))).V, NewObj(2).Put("hLy", ((V)((-5D)))).Put("tilt", ((V)((-1D)))).V, ((V)("l"))), "fx", ((V)("sand")), ((V)("pawL")), ((V)(4D)));
return Invoke(t_1340, "back", ((V)(320D)));
return default;
}, 1, "season", false)).Put("sniff", Fn((V _self1341, int _argc1342, V t_1348, V _a1345, V _a1346, V _a1347, V[] _rest1343) => {
if (_self1341.IsNullish) _self1341 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_1348, "to", ((V)(380D)), NewObj(5).Put("pitch", ((V)((-0.04)))).Put("close", ((V)(0.7))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.7))).Put("puff", ((V)(0.2))).V, ((V)("s"))), "fx", ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(600D))), "to", ((V)(200D)), NewObj(3).Put("close", ((V)(0D))).Put("wide", ((V)(0.4))).Put("puff", ((V)(0D))).V, ((V)("o")));
return Invoke(t_1348, "back", ((V)(360D)));
return default;
}, 1, "sniff", false)).Put("serve", Fn((V _self1349, int _argc1350, V t_1356, V X_1357, V rec_1358, V _a1355, V[] _rest1351) => {
V a_1359 = default;
if (_self1349.IsNullish) _self1349 = GlobalV;
a_1359 = Get(t_1356, "t");
Invoke(t_1356, "to", ((V)(320D)), Call(o_21, V.Undef, NewObj(9).Put("armR", ((V)(140D))).Put("hRy", ((V)((-10D)))).Put("hRx", ((V)(2D))).Put("ly", ((V)((-0.6)))).Put("pitch", ((V)(0.12))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.5))).Put("wide", ((V)(0.4))).V, Get(X_1357, "cheer")), ((V)("o")));
if (Truthy(Get(X_1357, "cheerFx"))) {
InvokeSpread(t_1356, "fx", new ArrBuilder().Spread(Get(X_1357, "cheerFx")).V);
} else {
Invoke(t_1356, "fx", ((V)("spark")), ((V)("pawR")), ((V)(3D)));
}
Invoke(t_1356, "wait", ((V)(800D)));
Call(push_46, V.Undef, rec_1358, ((V)("sv")), Arr(a_1359, Get(t_1356, "t")));
return Invoke(t_1356, "back", ((V)(420D)));
return default;
}, 3, "serve", false)).V;
TONGS_61 = ((V)("<path d=\"M0-0.6L13-1.6M0 0.6L13 1.6\" stroke=\"#9aa3b2\" stroke-width=\"0.9\" stroke-linecap=\"round\"/><path d=\"M-2.4-0.8H1V0.8H-2.4Z\" fill=\"#3b2a24\"/><path d=\"M12.4-2.4L14.2-1.2M12.4 2.4L14.2 1.2\" stroke=\"#7a8392\" stroke-width=\"0.7\" stroke-linecap=\"round\"/>"));
PATTY_62 = Fn((V _arrowThis1367, int _argc1360, V k_1366, V _a1363, V _a1364, V _a1365, V[] _rest1361) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"0\" cy=\"0\" rx=\"4.4\" ry=\"1.7\" fill=\"").V(Call(mixC_45, V.Undef, ((V)("#e98a8a")), ((V)("#7a4428")), k_1366)).S("\" stroke=\"#5a3018\" stroke-width=\"0.4\"/><path d=\"M-2.6-0.3H2.6M-1.6 0.6H1.8\" stroke=\"#3a1e10\" stroke-width=\"0.45\" opacity=\"").V(Call(r2_30, V.Undef, ((V)((ToNum(k_1366) * 0.8))))).S("\"/><ellipse cx=\"-1.4\" cy=\"-0.7\" rx=\"1.4\" ry=\"0.4\" fill=\"#ffffff\" opacity=\"0.25\"/>").End()));
}, 1, "", true);
TW0_64 = Call(S0_39, V.Undef, NewObj(3).Put("lx", ((V)(0.7))).Put("ly", ((V)(0.4))).Put("pitch", ((V)((-0.04)))).V);
TWB_65 = NewObj(3).Put("tap", Fn((V _self1368, int _argc1369, V t_1375, V _a1372, V _a1373, V _a1374, V[] _rest1370) => {
if (_self1368.IsNullish) _self1368 = GlobalV;
Invoke(Invoke(t_1375, "to", ((V)(300D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(4D)), ((V)(4D))), NewObj(3).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("close", ((V)(0.3))).V)), "osc", ((V)(1500D)), ((V)(6D)), NewObj(1).Put("footR", ((V)(1.4))).V, NewObj(1).Put("footR", ((V)(0D))).V, ((V)("o")));
return Invoke(t_1375, "back", ((V)(300D)));
return default;
}, 1, "tap", false)).Put("peek", Fn((V _self1376, int _argc1377, V t_1383, V _a1380, V _a1381, V _a1382, V[] _rest1378) => {
if (_self1376.IsNullish) _self1376 = GlobalV;
Invoke(Invoke(Invoke(t_1383, "to", ((V)(380D)), NewObj(6).Put("lean", ((V)(0.9))).Put("pitch", ((V)((-0.22)))).Put("lx", ((V)(0.9))).Put("ly", ((V)(0.8))).Put("wide", ((V)(0.6))).Put("sq", ((V)(0.04))).V, ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(200D)), NewObj(1).Put("wide", ((V)(0.2))).V);
return Invoke(t_1383, "back", ((V)(380D)));
return default;
}, 1, "peek", false)).Put("rub", Fn((V _self1384, int _argc1385, V t_1391, V _a1388, V _a1389, V _a1390, V[] _rest1386) => {
if (_self1384.IsNullish) _self1384 = GlobalV;
Invoke(Invoke(t_1391, "to", ((V)(300D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(9D)), ((V)((-5D)))), NewObj(5).Put("armL", ((V)(36D))).Put("armR", ((V)(36D))).Put("sqz", ((V)(0.6))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V), ((V)("io"))), "osc", ((V)(1100D)), ((V)(6D)), NewObj(2).Put("hLx", ((V)(11D))).Put("hRx", ((V)((-7D)))).V, NewObj(2).Put("hLx", ((V)(7D))).Put("hRx", ((V)((-11D)))).V, ((V)("l")));
return Invoke(t_1391, "back", ((V)(340D)));
return default;
}, 1, "rub", false)).V;
TOAST_66 = ((V)("<path d=\"M-3-3Q-3.6-4.6-2-4.8Q0-5.6 2-4.8Q3.6-4.6 3-3V3.2H-3Z\" fill=\"#d9964a\" stroke=\"#9a5a24\" stroke-width=\"0.45\"/><path d=\"M-2.2-2.8Q-2.4-3.8-1.4-3.9Q0-4.5 1.4-3.9Q2.4-3.8 2.2-2.8V2.4H-2.2Z\" fill=\"#f2d08a\"/>"));
POB_68 = NewObj(3).Put("big", Fn((V _self1392, int _argc1393, V t_1399, V X_1400, V _a1397, V _a1398, V[] _rest1394) => {
V B_1401 = default;
V L_1402 = default;
V Q_1403 = default;
if (_self1392.IsNullish) _self1392 = GlobalV;
B_1401 = Get(t_1399, "B");
L_1402 = (Get(B_1401, "lift") is var _t1404 && Truthy(_t1404) ? _t1404 : ((V)(0D)));
Q_1403 = (Get(B_1401, "sq") is var _t1405 && Truthy(_t1405) ? _t1405 : ((V)(0D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_1399, "to", ((V)(160D)), NewObj(2).Put("sq", Add(Q_1403, ((V)(0.14)))).Put("lift", ((V)((ToNum(L_1402) - 1D)))).V, ((V)("i"))), "to", ((V)(300D)), Call(o_21, V.Undef, NewObj(7).Put("sq", ((V)((ToNum(Q_1403) - 0.1)))).Put("lift", Add(L_1402, ((V)(8D)))).Put("armL", ((V)(130D))).Put("armR", ((V)(130D))).Put("open", ((V)(0.5))).Put("hap", ((V)(1D))).Put("wide", ((V)(0.4))).V, (Get(X_1400, "tk") is var _t1406 && Truthy(_t1406) ? _t1406 : NewObj(0).V)), ((V)("o"))), "to", ((V)(280D)), NewObj(4).Put("lift", L_1402).Put("sq", Add(Q_1403, ((V)(0.22)))).Put("armL", Get(B_1401, "armL")).Put("armR", Get(B_1401, "armR")).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)((ToNum(Q_1403) - 0.04)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("sq", Q_1403).V, ((V)("io")));
return Invoke(t_1399, "back", ((V)(300D)));
return default;
}, 2, "big", false)).Put("rock", Fn((V _self1407, int _argc1408, V t_1414, V _a1411, V _a1412, V _a1413, V[] _rest1409) => {
V L_1415 = default;
if (_self1407.IsNullish) _self1407 = GlobalV;
L_1415 = (Get(Get(t_1414, "B"), "lift") is var _t1416 && Truthy(_t1416) ? _t1416 : ((V)(0D)));
Invoke(t_1414, "osc", ((V)(1600D)), ((V)(4D)), NewObj(3).Put("tilt", ((V)(6D))).Put("lift", Add(L_1415, ((V)(1.6)))).Put("x", ((V)(1D))).V, NewObj(3).Put("tilt", ((V)((-6D)))).Put("lift", Add(L_1415, ((V)(1.6)))).Put("x", ((V)((-1D)))).V, ((V)("s")));
return Invoke(t_1414, "back", ((V)(300D)));
return default;
}, 1, "rock", false)).Put("spinb", Fn((V _self1417, int _argc1418, V t_1424, V _a1421, V _a1422, V _a1423, V[] _rest1419) => {
V L_1425 = default;
V Q_1426 = default;
if (_self1417.IsNullish) _self1417 = GlobalV;
L_1425 = (Get(Get(t_1424, "B"), "lift") is var _t1427 && Truthy(_t1427) ? _t1427 : ((V)(0D)));
Q_1426 = (Get(Get(t_1424, "B"), "sq") is var _t1428 && Truthy(_t1428) ? _t1428 : ((V)(0D)));
Invoke(Invoke(Invoke(Invoke(t_1424, "to", ((V)(140D)), NewObj(1).Put("sq", Add(Q_1426, ((V)(0.12)))).V, ((V)("i"))), "to", ((V)(500D)), NewObj(4).Put("spin", ((V)(360D))).Put("lift", Add(L_1425, ((V)(5D)))).Put("sq", ((V)((ToNum(Q_1426) - 0.06)))).Put("hap", ((V)(1D))).V, ((V)("io"))), "to", ((V)(10D)), NewObj(1).Put("spin", ((V)(0D))).V), "to", ((V)(200D)), NewObj(2).Put("lift", L_1425).Put("sq", Add(Q_1426, ((V)(0.12)))).V, ((V)("i")));
return Invoke(t_1424, "back", ((V)(260D)));
return default;
}, 1, "spinb", false)).V;
SP0_69 = Call(o_21, V.Undef, BATH0_36, NewObj(10).Put("wd", ((V)(0.48))).Put("sk", ((V)(5D))).Put("fm", ((V)(0D))).Put("dk", ((V)(0D))).Put("dkx", ((V)(0D))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).Put("close", ((V)(0D))).V, Call(both_15, V.Undef, ((V)(2D)), ((V)((-2D)))));
SPB_70 = NewObj(6).Put("slap", Fn((V _self1429, int _argc1430, V t_1436, V _a1433, V _a1434, V _a1435, V[] _rest1431) => {
V Q_1437 = default;
if (_self1429.IsNullish) _self1429 = GlobalV;
Q_1437 = (Get(Get(t_1436, "B"), "sq") is var _t1438 && Truthy(_t1438) ? _t1438 : ((V)(0D)));
{
double i_1439 = 0;
i_1439 = 0D;
while (true) {
if (!((i_1439 < 3D))) break;
Invoke(Invoke(Invoke(t_1436, "to", ((V)(200D)), NewObj(6).Put("armL", ((V)(96D))).Put("armR", ((V)(96D))).Put("hLy", ((V)((-6D)))).Put("hRy", ((V)((-6D)))).Put("open", ((V)(0.4))).Put("hap", ((V)(1D))).V, ((V)("o"))), "to", ((V)(130D)), NewObj(6).Put("armL", ((V)(26D))).Put("armR", ((V)(26D))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).Put("sq", Add(Q_1437, ((V)(0.05)))).Put("sqz", ((V)(0.6))).V, ((V)("i"))), "fx", ((V)("splash")), ((V)("body")), ((V)(5D)));
i_1439++;
}
}
return Invoke(t_1436, "back", ((V)(320D)));
return default;
}, 1, "slap", false)).Put("kick", Fn((V _self1441, int _argc1442, V t_1448, V _a1445, V _a1446, V _a1447, V[] _rest1443) => {
V B_1449 = default;
V Q_1450 = default;
if (_self1441.IsNullish) _self1441 = GlobalV;
B_1449 = Get(t_1448, "B");
Q_1450 = (Get(B_1449, "sq") is var _t1451 && Truthy(_t1451) ? _t1451 : ((V)(0D)));
Invoke(Invoke(Invoke(Invoke(t_1448, "to", ((V)(200D)), NewObj(2).Put("lean", ((V)((-0.6)))).Put("pitch", Add((Get(B_1449, "pitch") is var _t1452 && Truthy(_t1452) ? _t1452 : ((V)(0D))), ((V)(0.12)))).V), "osc", ((V)(1200D)), ((V)(6D)), NewObj(3).Put("footL", ((V)(3D))).Put("footR", ((V)(0D))).Put("sq", Add(Q_1450, ((V)(0.02)))).V, NewObj(3).Put("footL", ((V)(0D))).Put("footR", ((V)(3D))).Put("sq", Q_1450).V, ((V)("l"))), "fx", ((V)("splash")), ((V)("belly")), ((V)(4D))), "fx", ((V)("drop")), ((V)("belly")), ((V)(3D)));
return Invoke(t_1448, "back", ((V)(320D)));
return default;
}, 1, "kick", false)).Put("soak", Fn((V _self1453, int _argc1454, V t_1460, V _a1457, V _a1458, V _a1459, V[] _rest1455) => {
V B_1461 = default;
if (_self1453.IsNullish) _self1453 = GlobalV;
B_1461 = Get(t_1460, "B");
Invoke(Invoke(t_1460, "to", ((V)(400D)), NewObj(5).Put("pitch", Add((Get(B_1461, "pitch") is var _t1462 && Truthy(_t1462) ? _t1462 : ((V)(0D))), ((V)(0.25)))).Put("close", ((V)(0.7))).Put("wd", Add((Get(B_1461, "wd") is var _t1463 && Truthy(_t1463) ? _t1463 : ((V)(0D))), ((V)(0.18)))).Put("lean", ((V)((-0.6)))).Put("smile", ((V)(1D))).V, ((V)("s"))), "wait", ((V)(900D)));
return Invoke(t_1460, "back", ((V)(400D)), V.Null, ((V)("s")));
return default;
}, 1, "soak", false)).Put("atyou", Fn((V _self1464, int _argc1465, V t_1471, V _a1468, V _a1469, V _a1470, V[] _rest1466) => {
if (_self1464.IsNullish) _self1464 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_1471, "to", ((V)(300D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(10D)), ((V)(2D))), NewObj(7).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("sqz", ((V)(0.5))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).V), ((V)("io"))), "to", ((V)(140D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(8D)), ((V)((-10D)))), NewObj(3).Put("armL", ((V)(80D))).Put("armR", ((V)(80D))).Put("open", ((V)(0.5))).V), ((V)("o"))), "fx", ((V)("splash")), ((V)("head")), ((V)(7D))), "fx", ((V)("drop")), ((V)("head")), ((V)(4D))), "wait", ((V)(200D)));
Invoke(BEAT_13, "giggle", t_1471, ((V)(1D)));
return t_1471;
return default;
}, 1, "atyou", false)).Put("duck", Fn((V _self1472, int _argc1473, V t_1479, V _a1476, V _a1477, V _a1478, V[] _rest1474) => {
if (_self1472.IsNullish) _self1472 = GlobalV;
Invoke(Invoke(Invoke(t_1479, "to", ((V)(300D)), NewObj(5).Put("dk", ((V)(1D))).Put("dkx", ((V)(0.6))).Put("lx", ((V)(0.7))).Put("ly", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(1600D)), ((V)(2D)), NewObj(2).Put("dkx", ((V)((-0.6)))).Put("lx", ((V)((-0.7)))).V, NewObj(2).Put("dkx", ((V)(0.6))).Put("lx", ((V)(0.7))).V, ((V)("s"))), "to", ((V)(300D)), NewObj(2).Put("dk", ((V)(0D))).Put("dkx", ((V)(0D))).V);
return Invoke(t_1479, "back", ((V)(300D)));
return default;
}, 1, "duck", false)).Put("wave", Fn((V _self1480, int _argc1481, V t_1487, V _a1484, V _a1485, V _a1486, V[] _rest1482) => {
if (_self1480.IsNullish) _self1480 = GlobalV;
Invoke(BEAT_13, "wave", t_1487, ((V)(1D)));
return t_1487;
return default;
}, 1, "wave", false)).V;
PF0_74 = Call(S0_39, V.Undef, NewObj(5).Put("armR", ((V)(40D))).Put("armL", ((V)(22D))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.5))).Put("open", ((V)(0.1))).V, Call(hand_14, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-12D)))));
PFB_75 = NewObj(6).Put("sing", Fn((V _self1488, int _argc1489, V t_1495, V _a1492, V _a1493, V _a1494, V[] _rest1490) => {
if (_self1488.IsNullish) _self1488 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_1495, "to", ((V)(220D)), NewObj(3).Put("close", ((V)(0.4))).Put("open", ((V)(0.4))).Put("mw", ((V)(0.7))).V), "fx", ((V)("note")), ((V)("mouth")), ((V)(1D))), "osc", ((V)(2000D)), ((V)(4D)), NewObj(4).Put("htilt", ((V)(6D))).Put("lean", ((V)(0.6))).Put("x", ((V)(0.6))).Put("open", ((V)(0.5))).V, NewObj(4).Put("htilt", ((V)((-6D)))).Put("lean", ((V)((-0.6)))).Put("x", ((V)((-0.6)))).Put("open", ((V)(0.15))).V, ((V)("s"))), "fx", ((V)("note")), ((V)("mouth")), ((V)(1D)));
return Invoke(t_1495, "back", ((V)(360D)));
return default;
}, 1, "sing", false)).Put("belt", Fn((V _self1496, int _argc1497, V t_1503, V _a1500, V _a1501, V _a1502, V[] _rest1498) => {
if (_self1496.IsNullish) _self1496 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_1503, "to", ((V)(360D)), NewObj(9).Put("pitch", ((V)(0.24))).Put("ly", ((V)((-0.6)))).Put("armL", ((V)(128D))).Put("hLy", ((V)((-2D)))).Put("open", ((V)(0.75))).Put("mw", ((V)(0.6))).Put("close", ((V)(0.8))).Put("sq", ((V)((-0.05)))).Put("lean", ((V)((-0.4)))).V, ((V)("io"))), "fx", ((V)("note")), ((V)("mouth")), ((V)(2D))), "osc", ((V)(1200D)), ((V)(8D)), NewObj(1).Put("sq", ((V)((-0.03)))).V, NewObj(1).Put("sq", ((V)((-0.06)))).V, ((V)("l"))), "fx", ((V)("note")), ((V)("mouth")), ((V)(2D))), "to", ((V)(240D)), NewObj(1).Put("open", ((V)(0.2))).V);
return Invoke(t_1503, "back", ((V)(420D)));
return default;
}, 1, "belt", false)).Put("point", Fn((V _self1504, int _argc1505, V t_1511, V _a1508, V _a1509, V _a1510, V[] _rest1506) => {
if (_self1504.IsNullish) _self1504 = GlobalV;
Invoke(Invoke(Invoke(t_1511, "to", ((V)(300D)), NewObj(8).Put("armL", ((V)(150D))).Put("hLx", ((V)((-5D)))).Put("hLy", ((V)((-2D)))).Put("lx", ((V)((-0.7)))).Put("winkL", ((V)(1D))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.8))).Put("htilt", ((V)((-5D)))).V, ((V)("o"))), "wait", ((V)(600D))), "to", ((V)(160D)), NewObj(1).Put("winkL", ((V)(0D))).V);
return Invoke(t_1511, "back", ((V)(360D)));
return default;
}, 1, "point", false)).Put("spin", Fn((V _self1512, int _argc1513, V t_1519, V _a1516, V _a1517, V _a1518, V[] _rest1514) => {
if (_self1512.IsNullish) _self1512 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_1519, "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.06))).V), "to", ((V)(560D)), NewObj(5).Put("spin", ((V)(360D))).Put("armL", ((V)(110D))).Put("sq", ((V)((-0.04)))).Put("hap", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(10D)), NewObj(1).Put("spin", ((V)(0D))).V), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.05))).V, ((V)("o")));
return Invoke(t_1519, "back", ((V)(300D)));
return default;
}, 1, "spin", false)).Put("step", Fn((V _self1520, int _argc1521, V t_1527, V _a1524, V _a1525, V _a1526, V[] _rest1522) => {
V B_1528 = default;
if (_self1520.IsNullish) _self1520 = GlobalV;
B_1528 = Get(t_1527, "B");
{
double i_1529 = 0;
i_1529 = 0D;
while (true) {
if (!((i_1529 < 4D))) break;
double s_1531 = 0;
s_1531 = (NumTruthy((i_1529 % 2D)) ? (-1D) : 1D);
Invoke(t_1527, "to", ((V)(260D)), NewObj(5).Put("x", ((V)((s_1531 * 1.8)))).Put("footL", ((V)(((s_1531 > 0D) ? 2D : 0D)))).Put("footR", ((V)(((s_1531 > 0D) ? 0D : 2D)))).Put("tilt", ((V)((s_1531 * 3D)))).Put("armL", Add(Get(B_1528, "armL"), ((V)(20D)))).V, ((V)("io")));
i_1529++;
}
}
Invoke(t_1527, "fx", ((V)("note")), ((V)("mouth")), ((V)(1D)));
return Invoke(t_1527, "back", ((V)(300D)));
return default;
}, 1, "step", false)).Put("bow", Fn((V _self1532, int _argc1533, V t_1539, V _a1536, V _a1537, V _a1538, V[] _rest1534) => {
V B_1540 = default;
if (_self1532.IsNullish) _self1532 = GlobalV;
B_1540 = Get(t_1539, "B");
Invoke(Invoke(Invoke(t_1539, "to", ((V)(380D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(9D)), ((V)(6D))), NewObj(6).Put("armL", ((V)(14D))).Put("pitch", ((V)((-0.42)))).Put("ly", ((V)(0.8))).Put("sq", ((V)(0.1))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V), ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(320D)), NewObj(4).Put("pitch", Get(B_1540, "pitch")).Put("ly", ((V)(0D))).Put("sq", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
Invoke(BEAT_13, "wave", t_1539, ((V)((-1D))));
Invoke(t_1539, "fx", ((V)("heart")), ((V)("head")), ((V)(3D)));
return t_1539;
return default;
}, 1, "bow", false)).V;
MIC_76 = Fn((V _arrowThis1548, int _argc1541, V c_1547, V _a1544, V _a1545, V _a1546, V[] _rest1542) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"-1\" y=\"-1.1\" width=\"9\" height=\"2.2\" rx=\"1.1\" fill=\"").V(c_1547).S("\" stroke=\"").V(Call(shade_31, V.Undef, c_1547, ((V)(0.6)))).S("\" stroke-width=\"0.4\"/><circle cx=\"10\" cy=\"0\" r=\"2.6\" fill=\"#c9cfdb\" stroke=\"#6a7080\" stroke-width=\"0.45\"/><path d=\"M8.6-1.6L11.4 1.6M8.6 1.6L11.4-1.6M10-2.4V2.4\" stroke=\"#8a90a0\" stroke-width=\"0.3\"/><path d=\"M8.8-1.4Q9.6-2.2 10.8-1.8\" stroke=\"#fff\" stroke-width=\"0.5\" fill=\"none\" opacity=\"0.8\"/>").End()));
}, 1, "", true);
micProp_77 = Fn((V _arrowThis1556, int _argc1549, V col_1555, V _a1552, V _a1553, V _a1554, V[] _rest1550) => {
return Fn((V _arrowThis1564, int _argc1557, V I_1563, V _a1560, V _a1561, V _a1562, V[] _rest1558) => {
V W_1565 = default;
V f0_1566 = default;
V p_1567 = default;
V M_1568 = default;
double d_1569 = 0;
W_1565 = Get(I_1563, "W");
if ((!(Truthy(W_1565)) || !(Truthy(Call(okp_35, V.Undef, Get(W_1565, "pawR")))))) {
return ((V)(""));
}
f0_1566 = Call(facing_27, V.Undef, I_1563);
if (LtN(f0_1566, 0.02)) {
return ((V)(""));
}
p_1567 = Get(W_1565, "pawR");
M_1568 = (Truthy(Call(okp_35, V.Undef, Get(W_1565, "mouth"))) ? Get(W_1565, "mouth") : Arr(((V)((ToNum(GetIdx(p_1567, 0D)) - 8D))), ((V)((ToNum(GetIdx(p_1567, 1D)) - 3D)))));
d_1569 = Hypot((ToNum(GetIdx(M_1568, 0D)) - ToNum(GetIdx(p_1567, 0D))), (ToNum(GetIdx(M_1568, 1D)) - ToNum(GetIdx(p_1567, 1D))));
return Call(G_26, V.Undef, GetIdx(p_1567, 0D), GetIdx(p_1567, 1D), ((V)(((FdLibm.Atan2((ToNum(GetIdx(M_1568, 1D)) - ToNum(GetIdx(p_1567, 1D))), (ToNum(GetIdx(M_1568, 0D)) - ToNum(GetIdx(p_1567, 0D)))) * 180D) / System.Math.PI))), ((V)((ToNum(Call(cl_29, V.Undef, ((V)(((d_1569 - 2D) / 12.6))), ((V)(0.8)), ((V)(1.25)))) * 1.3))), Call(MIC_76, V.Undef, col_1555), f0_1566);
return default;
}, 1, "", true);
}, 1, "", true);
DJ0_78 = Call(S0_39, V.Undef, NewObj(6).Put("armL", ((V)(74D))).Put("armR", ((V)(26D))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.5))).Put("pitch", ((V)((-0.05)))).Put("ly", ((V)(0.3))).V, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(3D)), ((V)((-15D)))), Call(hand_14, V.Undef, ((V)(1D)), ((V)(6D)), ((V)(2D))));
DJB_79 = NewObj(6).Put("nod", Fn((V _self1570, int _argc1571, V t_1577, V _a1574, V _a1575, V _a1576, V[] _rest1572) => {
V B_1578 = default;
if (_self1570.IsNullish) _self1570 = GlobalV;
B_1578 = Get(t_1577, "B");
Invoke(Invoke(t_1577, "osc", ((V)(2000D)), ((V)(8D)), NewObj(3).Put("pitch", ((V)((ToNum(Get(B_1578, "pitch")) - 0.14)))).Put("sq", Add(Get(B_1578, "sq"), ((V)(0.04)))).Put("lift", ((V)((-0.4)))).V, NewObj(3).Put("pitch", Add(Get(B_1578, "pitch"), ((V)(0.03)))).Put("sq", ((V)((ToNum(Get(B_1578, "sq")) - 0.01)))).Put("lift", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("note")), ((V)("head")), ((V)(1D)));
return Invoke(t_1577, "back", ((V)(240D)));
return default;
}, 1, "nod", false)).Put("scratch", Fn((V _self1579, int _argc1580, V t_1586, V _a1583, V _a1584, V _a1585, V[] _rest1581) => {
V B_1587 = default;
if (_self1579.IsNullish) _self1579 = GlobalV;
B_1587 = Get(t_1586, "B");
Invoke(t_1586, "to", ((V)(200D)), NewObj(4).Put("sqz", ((V)(0.5))).Put("lean", ((V)(0.4))).Put("pitch", ((V)((ToNum(Get(B_1587, "pitch")) - 0.1)))).Put("ly", ((V)(0.7))).V);
{
double i_1588 = 0;
i_1588 = 0D;
while (true) {
if (!((i_1588 < 6D))) break;
Invoke(Invoke(t_1586, "to", ((V)(110D)), NewObj(1).Put("hRx", ((V)((ToNum(Get(B_1587, "hRx")) - 3.2)))).V, ((V)("l"))), "to", ((V)(110D)), NewObj(1).Put("hRx", Add(Get(B_1587, "hRx"), ((V)(1.6)))).V, ((V)("l")));
i_1588++;
}
}
Invoke(t_1586, "fx", ((V)("note")), ((V)("pawR")), ((V)(1D)));
return Invoke(t_1586, "back", ((V)(260D)));
return default;
}, 1, "scratch", false)).Put("pump", Fn((V _self1590, int _argc1591, V t_1597, V _a1594, V _a1595, V _a1596, V[] _rest1592) => {
V B_1598 = default;
if (_self1590.IsNullish) _self1590 = GlobalV;
B_1598 = Get(t_1597, "B");
Invoke(t_1597, "to", ((V)(200D)), NewObj(4).Put("armR", ((V)(150D))).Put("hRy", ((V)((-4D)))).Put("open", ((V)(0.4))).Put("hap", ((V)(1D))).V, ((V)("o")));
{
double i_1599 = 0;
i_1599 = 0D;
while (true) {
if (!((i_1599 < 4D))) break;
Invoke(Invoke(t_1597, "to", ((V)(250D)), NewObj(3).Put("armR", ((V)(112D))).Put("sq", Add(Get(B_1598, "sq"), ((V)(0.05)))).Put("lift", ((V)((-0.5)))).V, ((V)("i"))), "to", ((V)(250D)), NewObj(3).Put("armR", ((V)(160D))).Put("sq", ((V)((ToNum(Get(B_1598, "sq")) - 0.03)))).Put("lift", ((V)(1D))).V, ((V)("o")));
i_1599++;
}
}
return Invoke(t_1597, "back", ((V)(320D)));
return default;
}, 1, "pump", false)).Put("point", Fn((V _self1601, int _argc1602, V t_1608, V X_1609, V _a1606, V _a1607, V[] _rest1603) => {
if (_self1601.IsNullish) _self1601 = GlobalV;
Invoke(Invoke(Invoke(t_1608, "to", ((V)(300D)), Call(o_21, V.Undef, NewObj(7).Put("armR", ((V)(140D))).Put("hRx", ((V)(5D))).Put("hRy", ((V)((-2D)))).Put("lx", ((V)(0.6))).Put("winkR", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, Get(X_1609, "cheer")), ((V)("o"))), "wait", ((V)(600D))), "to", ((V)(160D)), NewObj(1).Put("winkR", ((V)(0D))).V);
return Invoke(t_1608, "back", ((V)(340D)));
return default;
}, 2, "point", false)).Put("drop", Fn((V _self1610, int _argc1611, V t_1617, V X_1618, V _a1615, V _a1616, V[] _rest1612) => {
V B_1619 = default;
if (_self1610.IsNullish) _self1610 = GlobalV;
B_1619 = Get(t_1617, "B");
Invoke(Invoke(t_1617, "to", ((V)(500D)), NewObj(4).Put("sq", Add(Get(B_1619, "sq"), ((V)(0.1)))).Put("armR", ((V)(10D))).Put("lift", ((V)((-1D)))).Put("wide", ((V)(0.5))).V, ((V)("i"))), "to", ((V)(200D)), Call(o_21, V.Undef, NewObj(10).Put("armR", ((V)(165D))).Put("armL", ((V)(165D))).Put("hLy", ((V)((-4D)))).Put("hRy", ((V)((-4D)))).Put("hLx", ((V)(0D))).Put("lift", ((V)(7D))).Put("sq", ((V)((-0.08)))).Put("open", ((V)(0.7))).Put("wide", ((V)(0.6))).Put("hap", ((V)(1D))).V, (Get(X_1618, "tk") is var _t1620 && Truthy(_t1620) ? _t1620 : NewObj(0).V)), ((V)("o")));
if (Truthy(Get(X_1618, "cheerFx"))) {
InvokeSpread(t_1617, "fx", new ArrBuilder().Spread(Get(X_1618, "cheerFx")).V);
} else {
Invoke(t_1617, "fx", ((V)("spark")), ((V)("body")), ((V)(5D)));
}
Invoke(Invoke(t_1617, "to", ((V)(220D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(2).Put("sq", Add(Get(B_1619, "sq"), ((V)(0.05)))).Put("pitch", ((V)((ToNum(Get(B_1619, "pitch")) - 0.12)))).V, NewObj(2).Put("sq", Get(B_1619, "sq")).Put("pitch", Add(Get(B_1619, "pitch"), ((V)(0.03)))).V, ((V)("io")));
return Invoke(t_1617, "back", ((V)(400D)));
return default;
}, 2, "drop", false)).Put("spin", Fn((V _self1621, int _argc1622, V t_1628, V _a1625, V _a1626, V _a1627, V[] _rest1623) => {
if (_self1621.IsNullish) _self1621 = GlobalV;
Invoke(Invoke(t_1628, "to", ((V)(560D)), NewObj(3).Put("spin", ((V)(360D))).Put("sq", ((V)((-0.03)))).Put("hap", ((V)(1D))).V, ((V)("io"))), "to", ((V)(10D)), NewObj(1).Put("spin", ((V)(0D))).V);
return Invoke(t_1628, "back", ((V)(240D)));
return default;
}, 1, "spin", false)).V;
phoneProp_80 = Fn((V _arrowThis1636, int _argc1629, V col_1635, V _a1632, V _a1633, V _a1634, V[] _rest1630) => {
return Fn((V _arrowThis1644, int _argc1637, V I_1643, V _a1640, V _a1641, V _a1642, V[] _rest1638) => {
V W_1645 = default;
V f0_1646 = default;
V a_1647 = default;
V b_1648 = default;
double mx_1649 = 0;
double my_1650 = 0;
double d_1651 = 0;
double hw_1652 = 0;
double top_1653 = 0;
double an_1654 = 0;
V arc_1655 = default;
V cup_1656 = default;
W_1645 = (Get(I_1643, "W") is var _t1657 && Truthy(_t1657) ? _t1657 : NewObj(0).V);
f0_1646 = Call(facing_27, V.Undef, I_1643);
if (LtN(f0_1646, 0.05)) {
return ((V)(""));
}
a_1647 = Get(W_1645, "eyeL");
b_1648 = Get(W_1645, "eyeR");
if ((!(Truthy(Call(okp_35, V.Undef, a_1647))) && !(Truthy(Call(okp_35, V.Undef, b_1648))))) {
return ((V)(""));
}
if (!(Truthy(Call(okp_35, V.Undef, a_1647)))) {
a_1647 = b_1648;
}
if (!(Truthy(Call(okp_35, V.Undef, b_1648)))) {
b_1648 = a_1647;
}
mx_1649 = (ToNum(Add(GetIdx(a_1647, 0D), GetIdx(b_1648, 0D))) / 2D);
my_1650 = (ToNum(Add(GetIdx(a_1647, 1D), GetIdx(b_1648, 1D))) / 2D);
d_1651 = Max(Hypot((ToNum(GetIdx(b_1648, 0D)) - ToNum(GetIdx(a_1647, 0D))), (ToNum(GetIdx(b_1648, 1D)) - ToNum(GetIdx(a_1647, 1D)))), 6D);
hw_1652 = ((d_1651 * 1.15) + 5D);
top_1653 = (Truthy(Call(okp_35, V.Undef, Get(W_1645, "head"))) ? Min(((ToNum(GetIdx(Get(W_1645, "head"), 1D)) - my_1650) + 1D), (-6D)) : (((-d_1651) * 1.4) - 5D));
an_1654 = ((FdLibm.Atan2((ToNum(GetIdx(b_1648, 1D)) - ToNum(GetIdx(a_1647, 1D))), (ToNum(GetIdx(b_1648, 0D)) - ToNum(GetIdx(a_1647, 0D)))) * 180D) / System.Math.PI);
arc_1655 = ((V)(JsStrBuf.Begin().S("M").V(Call(r2_30, V.Undef, ((V)((-hw_1652))))).S(" 0C").V(Call(r2_30, V.Undef, ((V)((-hw_1652))))).S(" ").V(Call(r2_30, V.Undef, ((V)((top_1653 * 1.3))))).S(" ").V(Call(r2_30, V.Undef, ((V)(hw_1652)))).S(" ").V(Call(r2_30, V.Undef, ((V)((top_1653 * 1.3))))).S(" ").V(Call(r2_30, V.Undef, ((V)(hw_1652)))).S(" 0").End()));
cup_1656 = Fn((V _arrowThis1665, int _argc1658, V x_1664, V _a1661, V _a1662, V _a1663, V[] _rest1659) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"").V(Call(r2_30, V.Undef, ((V)((ToNum(x_1664) - 2.2))))).S("\" y=\"-2\" width=\"4.4\" height=\"7\" rx=\"2\" fill=\"#2a2440\" stroke=\"#111\" stroke-width=\"0.35\"/><rect x=\"").V(Call(r2_30, V.Undef, ((V)((ToNum(x_1664) - 1.3))))).S("\" y=\"-0.8\" width=\"2.6\" height=\"4.6\" rx=\"1.2\" fill=\"").V(col_1635).S("\"/>").End()));
}, 1, "", true);
return Call(G_26, V.Undef, ((V)(mx_1649)), ((V)((my_1650 + 1D))), ((V)(an_1654)), ((V)(1D)), ((V)(JsStrBuf.Begin().S("<path d=\"").V(arc_1655).S("\" fill=\"none\" stroke=\"#2a2440\" stroke-width=\"2\"/><path d=\"").V(arc_1655).S("\" fill=\"none\" stroke=\"").V(col_1635).S("\" stroke-width=\"0.9\"/>").V(Call(cup_1656, V.Undef, ((V)((-hw_1652))))).V(Call(cup_1656, V.Undef, ((V)(hw_1652)))).End())), ((V)(Min(1D, (ToNum(f0_1646) * 1.3)))));
return default;
}, 1, "", true);
}, 1, "", true);
PB0_81 = Call(S0_39, V.Undef, NewObj(5).Put("pitch", ((V)((-0.12)))).Put("ly", ((V)(0.6))).Put("armL", ((V)(44D))).Put("armR", ((V)(44D))).Put("wide", ((V)(0.2))).V, Call(both_15, V.Undef, ((V)(4D)), ((V)((-4D)))));
PBB_82 = NewObj(4).Put("flip", Fn((V _self1666, int _argc1667, V t_1673, V _a1670, V _a1671, V _a1672, V[] _rest1668) => {
V B_1674 = default;
if (_self1666.IsNullish) _self1666 = GlobalV;
B_1674 = Get(t_1673, "B");
{
double i_1675 = 0;
i_1675 = 0D;
while (true) {
if (!((i_1675 < 8D))) break;
V s_1677 = default;
s_1677 = ((V)((NumTruthy((i_1675 % 2D)) ? "armL" : "armR")));
Invoke(Invoke(t_1673, "to", ((V)(90D)), NewObj(2).PutK(s_1677, Add(GetK(B_1674, s_1677), ((V)(14D)))).Put("sq", Add(Get(B_1674, "sq"), ((V)(0.015)))).V, ((V)("o"))), "to", ((V)(120D)), NewObj(2).PutK(s_1677, GetK(B_1674, s_1677)).Put("sq", Get(B_1674, "sq")).V, ((V)("i")));
i_1675++;
}
}
return Invoke(t_1673, "back", ((V)(260D)));
return default;
}, 1, "flip", false)).Put("track", Fn((V _self1678, int _argc1679, V t_1685, V _a1682, V _a1683, V _a1684, V[] _rest1680) => {
if (_self1678.IsNullish) _self1678 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_1685, "to", ((V)(300D)), NewObj(3).Put("lx", ((V)((-0.8)))).Put("turn", ((V)((-0.12)))).Put("wide", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("lx", ((V)(0.8))).Put("turn", ((V)(0.12))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(2).Put("lx", ((V)((-0.4)))).Put("ly", ((V)(0.9))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("lx", ((V)(0.6))).Put("ly", ((V)(0.3))).V, ((V)("io")));
return Invoke(t_1685, "back", ((V)(300D)));
return default;
}, 1, "track", false)).Put("nudge", Fn((V _self1686, int _argc1687, V t_1693, V _a1690, V _a1691, V _a1692, V[] _rest1688) => {
V Q_1694 = default;
if (_self1686.IsNullish) _self1686 = GlobalV;
Q_1694 = Get(Get(t_1693, "B"), "sq");
Invoke(Invoke(Invoke(Invoke(t_1693, "to", ((V)(140D)), NewObj(4).Put("tilt", ((V)(7D))).Put("x", ((V)(1.4))).Put("sq", Add(Q_1694, ((V)(0.05)))).Put("sqz", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("tilt", ((V)((-3D)))).Put("x", ((V)((-0.4)))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(2).Put("tilt", ((V)(6D))).Put("x", ((V)(1.2))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(3).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("sqz", ((V)(0D))).V, ((V)("io")));
return Invoke(t_1693, "back", ((V)(260D)));
return default;
}, 1, "nudge", false)).Put("multi", Fn((V _self1695, int _argc1696, V t_1702, V _a1699, V _a1700, V _a1701, V[] _rest1697) => {
V B_1703 = default;
if (_self1695.IsNullish) _self1695 = GlobalV;
B_1703 = Get(t_1702, "B");
Invoke(t_1702, "to", ((V)(200D)), NewObj(4).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.6))).Put("pitch", Add(Get(B_1703, "pitch"), ((V)(0.06)))).V, ((V)("o")));
{
double i_1704 = 0;
i_1704 = 0D;
while (true) {
if (!((i_1704 < 10D))) break;
Invoke(t_1702, "to", ((V)(70D)), NewObj(3).Put("armL", Add(Get(B_1703, "armL"), ((V)((NumTruthy((i_1704 % 2D)) ? 14D : 0D))))).Put("armR", Add(Get(B_1703, "armR"), ((V)((NumTruthy((i_1704 % 2D)) ? 0D : 14D))))).Put("lx", ((V)((NumTruthy((i_1704 % 2D)) ? 0.7 : (-0.7))))).V, ((V)("l")));
i_1704++;
}
}
Invoke(Invoke(t_1702, "fx", ((V)("spark")), ((V)("head")), ((V)(3D))), "fx", ((V)("sweat")), ((V)("head")), ((V)(1D)));
return Invoke(t_1702, "back", ((V)(300D)));
return default;
}, 1, "multi", false)).V;
DC0_83 = Call(S0_39, V.Undef, NewObj(4).Put("armL", ((V)(36D))).Put("armR", ((V)(36D))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V);
DCB_84 = NewObj(6).Put("steps", Fn((V _self1706, int _argc1707, V t_1713, V _a1710, V _a1711, V _a1712, V[] _rest1708) => {
if (_self1706.IsNullish) _self1706 = GlobalV;
{
double i_1714 = 0;
i_1714 = 0D;
while (true) {
if (!((i_1714 < 8D))) break;
double s_1716 = 0;
s_1716 = (NumTruthy((i_1714 % 2D)) ? (-1D) : 1D);
Invoke(Invoke(t_1713, "to", ((V)(115D)), NewObj(7).Put("footL", ((V)(((s_1716 > 0D) ? 2.6 : 0D)))).Put("footR", ((V)(((s_1716 > 0D) ? 0D : 2.6)))).Put("x", ((V)((s_1716 * 1.2)))).Put("armL", ((V)(((s_1716 > 0D) ? 60D : 20D)))).Put("armR", ((V)(((s_1716 > 0D) ? 20D : 60D)))).Put("sq", ((V)(0.03))).Put("tilt", ((V)((s_1716 * 2D)))).V, ((V)("o"))), "to", ((V)(115D)), NewObj(3).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i")));
i_1714++;
}
}
return Invoke(t_1713, "back", ((V)(240D)));
return default;
}, 1, "steps", false)).Put("arrows", Fn((V _self1717, int _argc1718, V t_1724, V _a1721, V _a1722, V _a1723, V[] _rest1719) => {
if (_self1717.IsNullish) _self1717 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1724, "to", ((V)(160D)), NewObj(4).Put("x", ((V)((-2.6)))).Put("footL", ((V)(2.4))).Put("tilt", ((V)((-5D)))).Put("armL", ((V)(90D))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("footL", ((V)(0D))).Put("armL", ((V)(36D))).V, ((V)("i"))), "to", ((V)(160D)), NewObj(4).Put("x", ((V)(2.6))).Put("footR", ((V)(2.4))).Put("tilt", ((V)(5D))).Put("armR", ((V)(90D))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("footR", ((V)(0D))).Put("armR", ((V)(36D))).V, ((V)("i"))), "to", ((V)(160D)), NewObj(6).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.06)))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i"))), "to", ((V)(160D)), NewObj(4).Put("sq", ((V)(0.14))).Put("lift", ((V)((-1D)))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
return Invoke(t_1724, "back", ((V)(240D)));
return default;
}, 1, "arrows", false)).Put("jump", Fn((V _self1725, int _argc1726, V t_1732, V _a1729, V _a1730, V _a1731, V[] _rest1727) => {
if (_self1725.IsNullish) _self1725 = GlobalV;
{
double i_1733 = 0;
i_1733 = 0D;
while (true) {
if (!((i_1733 < 2D))) break;
Invoke(Invoke(Invoke(t_1732, "to", ((V)(110D)), NewObj(1).Put("sq", ((V)(0.12))).V, ((V)("i"))), "to", ((V)(220D)), NewObj(7).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(8D))).Put("footL", ((V)(1.6))).Put("footR", ((V)(1.6))).Put("armL", ((V)(130D))).Put("armR", ((V)(130D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(6).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("i")));
i_1733++;
}
}
return Invoke(t_1732, "back", ((V)(240D)));
return default;
}, 1, "jump", false)).Put("combo", Fn((V _self1735, int _argc1736, V t_1742, V X_1743, V _a1740, V _a1741, V[] _rest1737) => {
if (_self1735.IsNullish) _self1735 = GlobalV;
{
double i_1744 = 0;
i_1744 = 0D;
while (true) {
if (!((i_1744 < 12D))) break;
double s_1746 = 0;
s_1746 = (NumTruthy((i_1744 % 2D)) ? (-1D) : 1D);
Invoke(t_1742, "to", ((V)(80D)), NewObj(6).Put("footL", ((V)(((s_1746 > 0D) ? 2.4 : 0D)))).Put("footR", ((V)(((s_1746 > 0D) ? 0D : 2.4)))).Put("x", ((V)((s_1746 * 1.6)))).Put("armL", ((V)(((s_1746 > 0D) ? 90D : 30D)))).Put("armR", ((V)(((s_1746 > 0D) ? 30D : 90D)))).Put("sqz", ((V)(0.5))).V, ((V)("l")));
i_1744++;
}
}
Invoke(t_1742, "fx", ((V)("sweat")), ((V)("head")), ((V)(1D)));
Call(cheer_47, V.Undef, t_1742, X_1743, NewObj(4).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("x", ((V)(0D))).Put("sqz", ((V)(0D))).V);
return t_1742;
return default;
}, 2, "combo", false)).Put("spin", Fn((V _self1747, int _argc1748, V t_1754, V _a1751, V _a1752, V _a1753, V[] _rest1749) => {
if (_self1747.IsNullish) _self1747 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_1754, "to", ((V)(120D)), NewObj(1).Put("sq", ((V)(0.08))).V), "to", ((V)(600D)), NewObj(5).Put("spin", ((V)(360D))).Put("armL", ((V)(100D))).Put("armR", ((V)(100D))).Put("sq", ((V)((-0.04)))).Put("lift", ((V)(2D))).V, ((V)("io"))), "to", ((V)(10D)), NewObj(1).Put("spin", ((V)(0D))).V), "to", ((V)(160D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("i")));
return Invoke(t_1754, "back", ((V)(260D)));
return default;
}, 1, "spin", false)).Put("freeze", Fn((V _self1755, int _argc1756, V t_1762, V X_1763, V _a1760, V _a1761, V[] _rest1757) => {
if (_self1755.IsNullish) _self1755 = GlobalV;
Invoke(t_1762, "to", ((V)(200D)), Call(o_21, V.Undef, NewObj(10).Put("armL", ((V)(165D))).Put("armR", ((V)(18D))).Put("hLy", ((V)((-4D)))).Put("tilt", ((V)(7D))).Put("x", ((V)(1D))).Put("footR", ((V)(2D))).Put("winkR", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("hap", ((V)(1D))).V, (Get(X_1763, "tk") is var _t1764 && Truthy(_t1764) ? _t1764 : NewObj(0).V)), ((V)("o")));
if (Truthy(Get(X_1763, "cheerFx"))) {
InvokeSpread(t_1762, "fx", new ArrBuilder().Spread(Get(X_1763, "cheerFx")).V);
} else {
Invoke(t_1762, "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
}
Invoke(Invoke(t_1762, "wait", ((V)(900D))), "to", ((V)(160D)), NewObj(1).Put("winkR", ((V)(0D))).V);
return Invoke(t_1762, "back", ((V)(360D)));
return default;
}, 2, "freeze", false)).V;
HK0_85 = Call(S0_39, V.Undef, NewObj(5).Put("pitch", ((V)((-0.16)))).Put("ly", ((V)(0.7))).Put("armR", ((V)(34D))).Put("armL", ((V)(24D))).Put("wide", ((V)(0.2))).V, Call(hand_14, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-2D)))), Call(hand_14, V.Undef, ((V)((-1D))), ((V)(8D)), ((V)(2D))));
HKB_86 = NewObj(3).Put("ready", Fn((V _self1765, int _argc1766, V t_1772, V _a1769, V _a1770, V _a1771, V[] _rest1767) => {
V B_1773 = default;
if (_self1765.IsNullish) _self1765 = GlobalV;
B_1773 = Get(t_1772, "B");
Invoke(Invoke(t_1772, "to", ((V)(260D)), NewObj(3).Put("sq", Add(Get(B_1773, "sq"), ((V)(0.06)))).Put("lift", ((V)((-0.6)))).Put("sqz", ((V)(0.3))).V, ((V)("io"))), "osc", ((V)(1000D)), ((V)(2D)), NewObj(2).Put("lx", ((V)((-0.6)))).Put("x", ((V)((-0.6)))).V, NewObj(2).Put("lx", ((V)(0.6))).Put("x", ((V)(0.6))).V, ((V)("s")));
return Invoke(t_1772, "back", ((V)(260D)));
return default;
}, 1, "ready", false)).Put("hit", Fn((V _self1774, int _argc1775, V t_1781, V X_1782, V rec_1783, V _a1780, V[] _rest1776) => {
V B_1784 = default;
if (_self1774.IsNullish) _self1774 = GlobalV;
B_1784 = Get(t_1781, "B");
Invoke(Invoke(t_1781, "to", ((V)(200D)), NewObj(3).Put("armR", Add(Get(B_1784, "armR"), ((V)(16D)))).Put("hRx", Add(Get(B_1784, "hRx"), ((V)(4D)))).Put("lean", ((V)((-0.5)))).V, ((V)("io"))), "to", ((V)(110D)), NewObj(6).Put("armR", ((V)((ToNum(Get(B_1784, "armR")) - 10D)))).Put("hRx", ((V)((ToNum(Get(B_1784, "hRx")) - 7D)))).Put("lean", ((V)(1D))).Put("sq", ((V)((ToNum(Get(B_1784, "sq")) - 0.03)))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.6))).V, ((V)("o")));
Call(push_46, V.Undef, rec_1783, ((V)("h")), Get(t_1781, "t"));
Invoke(t_1781, "to", ((V)(300D)), NewObj(3).Put("lean", ((V)(0.3))).Put("lx", ((V)(0.8))).Put("ly", ((V)(0.4))).V, ((V)("io")));
return Invoke(t_1781, "back", ((V)(300D)));
return default;
}, 3, "hit", false)).Put("block", Fn((V _self1785, int _argc1786, V t_1792, V X_1793, V rec_1794, V _a1791, V[] _rest1787) => {
V B_1795 = default;
if (_self1785.IsNullish) _self1785 = GlobalV;
B_1795 = Get(t_1792, "B");
Invoke(t_1792, "to", ((V)(120D)), NewObj(5).Put("x", ((V)((-1.6)))).Put("lean", ((V)((-1D)))).Put("hRx", Add(Get(B_1795, "hRx"), ((V)(3D)))).Put("wide", ((V)(0.9))).Put("open", ((V)(0.4))).V, ((V)("o")));
Call(push_46, V.Undef, rec_1794, ((V)("h")), Get(t_1792, "t"));
Invoke(t_1792, "wait", ((V)(250D)));
return Invoke(t_1792, "back", ((V)(300D)));
return default;
}, 3, "block", false)).V;
PADDLE_87 = Fn((V _arrowThis1803, int _argc1796, V c_1802, V _a1799, V _a1800, V _a1801, V[] _rest1797) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"0\" cy=\"1\" rx=\"4.2\" ry=\"2\" fill=\"").V(c_1802).S("\" stroke=\"").V(Call(shade_31, V.Undef, c_1802, ((V)(0.65)))).S("\" stroke-width=\"0.45\"/><ellipse cx=\"0\" cy=\"-0.4\" rx=\"1.5\" ry=\"1.1\" fill=\"").V(Call(shade_31, V.Undef, c_1802, ((V)(1.2)))).S("\" stroke=\"").V(Call(shade_31, V.Undef, c_1802, ((V)(0.65)))).S("\" stroke-width=\"0.35\"/>").End()));
}, 1, "", true);
PPAD_88 = Fn((V _arrowThis1811, int _argc1804, V c_1810, V _a1807, V _a1808, V _a1809, V[] _rest1805) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M-0.6 0H0.6V4H-0.6Z\" fill=\"#c98a52\" stroke=\"#8a5a2c\" stroke-width=\"0.3\"/><circle cx=\"0\" cy=\"-2.6\" r=\"3.2\" fill=\"").V(c_1810).S("\" stroke=\"").V(Call(shade_31, V.Undef, c_1810, ((V)(0.65)))).S("\" stroke-width=\"0.45\"/>").End()));
}, 1, "", true);
BL0_90 = Call(S0_39, V.Undef, NewObj(6).Put("pitch", ((V)((-0.2)))).Put("ly", ((V)(0.7))).Put("armL", ((V)(30D))).Put("armR", ((V)(22D))).Put("lean", ((V)(0.3))).Put("tilt", ((V)(3D))).V, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(10D)), ((V)((-2D)))), Call(hand_14, V.Undef, ((V)(1D)), ((V)((-2D))), ((V)(2D))));
BLB_91 = NewObj(5).Put("chalk", Fn((V _self1812, int _argc1813, V t_1819, V _a1816, V _a1817, V _a1818, V[] _rest1814) => {
if (_self1812.IsNullish) _self1812 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1819, "to", ((V)(340D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(4D)), ((V)((-8D)))), NewObj(4).Put("armL", ((V)(56D))).Put("ly", ((V)(0.2))).Put("lx", ((V)(0.4))).Put("pitch", ((V)((-0.04)))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(2).Put("hLx", ((V)(6D))).Put("tilt", ((V)(2D))).V, NewObj(2).Put("hLx", ((V)(3D))).Put("tilt", ((V)(4D))).V, ((V)("s"))), "fx", ((V)("dust")), ((V)("pawL")), ((V)(2D))), "to", ((V)(200D)), NewObj(1).Put("puff", ((V)(0.6))).V), "to", ((V)(200D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("mouth")), ((V)(1D)));
return Invoke(t_1819, "back", ((V)(360D)));
return default;
}, 1, "chalk", false)).Put("aim", Fn((V _self1820, int _argc1821, V t_1827, V _a1824, V _a1825, V _a1826, V[] _rest1822) => {
V B_1828 = default;
if (_self1820.IsNullish) _self1820 = GlobalV;
B_1828 = Get(t_1827, "B");
Invoke(Invoke(t_1827, "to", ((V)(420D)), NewObj(7).Put("sq", Add(Get(B_1828, "sq"), ((V)(0.1)))).Put("pitch", ((V)((ToNum(Get(B_1828, "pitch")) - 0.12)))).Put("lift", ((V)((-1D)))).Put("winkL", ((V)(1D))).Put("lx", ((V)(0.6))).Put("ly", ((V)(0.8))).Put("tongue", ((V)(0.3))).V, ((V)("io"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("hRx", Add(Get(B_1828, "hRx"), ((V)(2.4)))).V, NewObj(1).Put("hRx", ((V)((ToNum(Get(B_1828, "hRx")) - 1D)))).V, ((V)("io")));
return t_1827;
return default;
}, 1, "aim", false)).Put("shoot", Fn((V _self1829, int _argc1830, V t_1836, V X_1837, V rec_1838, V _a1835, V[] _rest1831) => {
V B_1839 = default;
if (_self1829.IsNullish) _self1829 = GlobalV;
B_1839 = Get(t_1836, "B");
Invoke(Invoke(t_1836, "to", ((V)(300D)), NewObj(2).Put("hRx", Add(Get(B_1839, "hRx"), ((V)(4.4)))).Put("armR", Add(Get(B_1839, "armR"), ((V)(6D)))).V, ((V)("io"))), "to", ((V)(90D)), NewObj(3).Put("hRx", ((V)((ToNum(Get(B_1839, "hRx")) - 6D)))).Put("armR", ((V)((ToNum(Get(B_1839, "armR")) - 4D)))).Put("sq", Add(Get(B_1839, "sq"), ((V)(0.1)))).V, ((V)("o")));
Call(push_46, V.Undef, rec_1838, ((V)("sh")), Get(t_1836, "t"));
Invoke(Invoke(t_1836, "to", ((V)(400D)), NewObj(6).Put("winkL", ((V)(0D))).Put("wide", ((V)(0.6))).Put("lx", ((V)(0.9))).Put("ly", ((V)(0.5))).Put("tongue", ((V)(0D))).Put("pitch", ((V)((ToNum(Get(B_1839, "pitch")) - 0.04)))).V, ((V)("io"))), "wait", ((V)(500D)));
return Invoke(t_1836, "back", ((V)(420D)));
return default;
}, 3, "shoot", false)).Put("miss", Fn((V _self1840, int _argc1841, V t_1847, V _a1844, V _a1845, V _a1846, V[] _rest1842) => {
if (_self1840.IsNullish) _self1840 = GlobalV;
Invoke(Invoke(Invoke(t_1847, "to", ((V)(260D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-18D)))), NewObj(4).Put("armR", ((V)(128D))).Put("frown", ((V)(0.4))).Put("htilt", ((V)(8D))).Put("lx", ((V)(0.7))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(1).Put("hRx", ((V)((-3D)))).V, NewObj(1).Put("hRx", ((V)((-7D)))).V, ((V)("s"))), "to", ((V)(240D)), NewObj(4).Put("frown", ((V)(0D))).Put("sqz", ((V)(0.6))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V, ((V)("o")));
return Invoke(t_1847, "back", ((V)(400D)));
return default;
}, 1, "miss", false)).Put("circle", Fn((V _self1848, int _argc1849, V t_1855, V _a1852, V _a1853, V _a1854, V[] _rest1850) => {
if (_self1848.IsNullish) _self1848 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_1855, "to", ((V)(500D)), NewObj(5).Put("turn", ((V)(0.3))).Put("lx", ((V)(0.9))).Put("ly", ((V)(0.6))).Put("htilt", ((V)(6D))).Put("tilt", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(600D)), NewObj(3).Put("turn", ((V)((-0.3)))).Put("lx", ((V)((-0.9)))).Put("htilt", ((V)((-6D)))).V, ((V)("io"))), "wait", ((V)(600D)));
return Invoke(t_1855, "back", ((V)(500D)));
return default;
}, 1, "circle", false)).V;
ICX_93 = NewObj(7).Put("ball", ((V)("<circle cx=\"0\" cy=\"0\" r=\"3\" fill=\"#ffffff\" stroke=\"#3a3a48\" stroke-width=\"0.45\"/><path d=\"M0-1.2L1.15-0.35L0.7 1H-0.7L-1.15-0.35Z\" fill=\"#2a2a36\"/><path d=\"M0-1.2V-3M1.15-0.35L2.85-0.9M0.7 1L1.7 2.4M-0.7 1L-1.7 2.4M-1.15-0.35L-2.85-0.9\" stroke=\"#3a3a48\" stroke-width=\"0.35\"/>"))).Put("bball", Add(Add(Call(ci_32, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(3D)), ((V)("#f28a2e")), ((V)("#b8561a"))), Call(pa_33, V.Undef, ((V)("M-3 0H3M0-3V3M-2.1-2.1Q0 0-2.1 2.1M2.1-2.1Q0 0 2.1 2.1")), V.Null, ((V)("#7a3a10")), ((V)(0.35)))), Call(ci_32, V.Undef, ((V)((-1.1))), ((V)((-1.2))), ((V)(0.7)), ((V)("rgba(255,255,255,0.45)"))))).Put("bocce", Add(Add(Call(ci_32, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(2.4)), ((V)("#c0392b")), ((V)("#7a1e14"))), Call(pa_33, V.Undef, ((V)("M-2.2-0.6Q0 0.6 2.2-0.6")), V.Null, ((V)("#ffd24a")), ((V)(0.5)))), Call(ci_32, V.Undef, ((V)((-0.8))), ((V)((-0.9))), ((V)(0.6)), ((V)("#ffffff"))))).Put("bag", Fn((V _arrowThis1863, int _argc1856, V c_1862, V _a1859, V _a1860, V _a1861, V[] _rest1857) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"-2.6\" y=\"-2\" width=\"5.2\" height=\"4\" rx=\"1.2\" fill=\"").V(c_1862).S("\" stroke=\"").V(Call(shade_31, V.Undef, c_1862, ((V)(0.65)))).S("\" stroke-width=\"0.4\"/><path d=\"M-1.8-1.2H1.8\" stroke=\"#ffffff\" stroke-width=\"0.4\" opacity=\"0.5\"/>").End()));
}, 1, "bag", true)).Put("shoe", Add(Call(pa_33, V.Undef, ((V)("M-2.6 2.4V-0.4A2.6 2.6 0 0 1 2.6-0.4V2.4")), V.Null, ((V)("#6a7080")), ((V)(1.3))), Call(pa_33, V.Undef, ((V)("M-2.6 2.4V-0.4A2.6 2.6 0 0 1 2.6-0.4V2.4")), V.Null, ((V)("#c9cfdb")), ((V)(0.45))))).Put("disc", Fn((V _arrowThis1871, int _argc1864, V c_1870, V _a1867, V _a1868, V _a1869, V[] _rest1865) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"0\" cy=\"0\" rx=\"4.4\" ry=\"1.5\" fill=\"").V(c_1870).S("\" stroke=\"").V(Call(shade_31, V.Undef, c_1870, ((V)(0.65)))).S("\" stroke-width=\"0.4\"/><ellipse cx=\"0\" cy=\"-0.3\" rx=\"2.4\" ry=\"0.7\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.35\" opacity=\"0.6\"/>").End()));
}, 1, "disc", true)).Put("stone", Call(pa_33, V.Undef, ((V)("M-1.8 0.6Q-1.6-1.2 0-1.3Q1.8-1.2 1.9 0.4Q1.6 1.3 0 1.3Q-1.6 1.3-1.8 0.6Z")), ((V)("#a9a39a")), ((V)("#6a645a")))).V;
GOB_94 = NewObj(3).Put("dribble", Fn((V _self1872, int _argc1873, V t_1879, V X_1880, V rec_1881, V _a1878, V[] _rest1874) => {
V a_1882 = default;
if (_self1872.IsNullish) _self1872 = GlobalV;
a_1882 = Get(t_1879, "t");
{
double i_1883 = 0;
i_1883 = 0D;
while (true) {
if (!((i_1883 < 6D))) break;
V s_1885 = default;
s_1885 = ((V)((NumTruthy((i_1883 % 2D)) ? "footL" : "footR")));
Invoke(Invoke(t_1879, "to", ((V)(160D)), NewObj(6).PutK(s_1885, ((V)(1.8))).Put("x", ((V)((NumTruthy((i_1883 % 2D)) ? (-0.6) : 0.6)))).Put("lx", ((V)(0.3))).Put("ly", ((V)(0.8))).Put("pitch", ((V)((-0.12)))).Put("tilt", ((V)((NumTruthy((i_1883 % 2D)) ? (-2D) : 2D)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).PutK(s_1885, ((V)(0D))).V, ((V)("i")));
i_1883++;
}
}
Call(push_46, V.Undef, rec_1881, ((V)("dr")), Arr(a_1882, Get(t_1879, "t")));
return Invoke(t_1879, "back", ((V)(240D)));
return default;
}, 3, "dribble", false)).Put("kick", Fn((V _self1886, int _argc1887, V t_1893, V X_1894, V rec_1895, V _a1892, V[] _rest1888) => {
V h_1896 = default;
if (_self1886.IsNullish) _self1886 = GlobalV;
h_1896 = Call(kickCore_50, V.Undef, t_1893, X_1894);
Call(push_46, V.Undef, rec_1895, ((V)("k")), h_1896);
return Invoke(t_1893, "back", ((V)(300D)));
return default;
}, 3, "kick", false)).Put("header", Fn((V _self1897, int _argc1898, V t_1904, V X_1905, V rec_1906, V _a1903, V[] _rest1899) => {
if (_self1897.IsNullish) _self1897 = GlobalV;
Invoke(Invoke(t_1904, "to", ((V)(400D)), NewObj(4).Put("ly", ((V)((-0.9)))).Put("pitch", ((V)(0.25))).Put("wide", ((V)(0.5))).Put("lean", ((V)((-0.3)))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(4).Put("pitch", ((V)((-0.14)))).Put("lift", ((V)(3D))).Put("close", ((V)(1D))).Put("sq", ((V)((-0.05)))).V, ((V)("o")));
Call(push_46, V.Undef, rec_1906, ((V)("hd")), Get(t_1904, "t"));
Invoke(Invoke(t_1904, "fx", ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(260D)), NewObj(4).Put("lift", ((V)(0D))).Put("close", ((V)(0D))).Put("sq", ((V)(0.05))).Put("pitch", ((V)(0D))).V, ((V)("i")));
return Invoke(t_1904, "back", ((V)(300D)));
return default;
}, 3, "header", false)).V;
KP0_96 = Call(S0_39, V.Undef, NewObj(8).Put("sq", ((V)(0.1))).Put("lift", ((V)((-1D)))).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).Put("pitch", ((V)((-0.04)))).Put("wide", ((V)(0.3))).Put("footL", ((V)(0.6))).Put("footR", ((V)(0.6))).V, Call(both_15, V.Undef, ((V)((-2D))), ((V)((-4D)))));
dive_97 = Fn((V _arrowThis1915, int _argc1907, V t_1913, V s_1914, V _a1911, V _a1912, V[] _rest1908) => {
V Kk_1916 = default;
Kk_1916 = Call(SIDE_16, V.Undef, s_1914);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1913, "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0.16))).Put("lift", ((V)((-1.4)))).V, ((V)("i"))), "to", ((V)(260D)), NewObj(8).PutK(Get(Kk_1916, "arm"), ((V)(165D))).PutK(Get(Kk_1916, "hy"), ((V)((-6D)))).Put("tilt", ((V)((ToNum(s_1914) * 34D)))).Put("x", ((V)((ToNum(s_1914) * 6D)))).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.06)))).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(3).Put("lift", ((V)(0D))).Put("sq", ((V)(0.18))).Put("tilt", ((V)((ToNum(s_1914) * 40D)))).V, ((V)("i"))), "fx", ((V)("dust")), ((V)("body")), ((V)(4D))), "wait", ((V)(300D))), "to", ((V)(400D)), NewObj(3).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("sq", ((V)(0.1))).V, ((V)("io"))), "fx", ((V)("sweat")), ((V)("head")), ((V)(1D)));
return Invoke(t_1913, "back", ((V)(300D)));
return default;
}, 2, "", true);
KPB_98 = NewObj(5).Put("ready", Fn((V _self1917, int _argc1918, V t_1924, V _a1921, V _a1922, V _a1923, V[] _rest1919) => {
if (_self1917.IsNullish) _self1917 = GlobalV;
Invoke(t_1924, "osc", ((V)(1400D)), ((V)(4D)), NewObj(3).Put("x", ((V)((-2.2)))).Put("tilt", ((V)((-3D)))).Put("footL", ((V)(1.4))).V, NewObj(3).Put("x", ((V)(2.2))).Put("tilt", ((V)(3D))).Put("footR", ((V)(1.4))).V, ((V)("s")));
return Invoke(t_1924, "back", ((V)(260D)));
return default;
}, 1, "ready", false)).Put("diveL", Fn((V _self1925, int _argc1926, V t_1932, V _a1929, V _a1930, V _a1931, V[] _rest1927) => {
if (_self1925.IsNullish) _self1925 = GlobalV;
return Call(dive_97, V.Undef, t_1932, ((V)((-1D))));
return default;
}, 1, "diveL", false)).Put("diveR", Fn((V _self1933, int _argc1934, V t_1940, V _a1937, V _a1938, V _a1939, V[] _rest1935) => {
if (_self1933.IsNullish) _self1933 = GlobalV;
return Call(dive_97, V.Undef, t_1940, ((V)(1D)));
return default;
}, 1, "diveR", false)).Put("catch", Fn((V _self1941, int _argc1942, V t_1948, V X_1949, V rec_1950, V _a1947, V[] _rest1943) => {
if (_self1941.IsNullish) _self1941 = GlobalV;
Invoke(Invoke(t_1948, "to", ((V)(200D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(9D)), ((V)((-9D)))), NewObj(5).Put("armL", ((V)(56D))).Put("armR", ((V)(56D))).Put("wide", ((V)(0.9))).Put("open", ((V)(0.4))).Put("lift", ((V)(2D))).V), ((V)("o"))), "to", ((V)(200D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(10D)), ((V)(2D))), NewObj(9).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.14))).Put("sqz", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("wide", ((V)(0D))).Put("open", ((V)(0.2))).V), ((V)("i")));
Call(push_46, V.Undef, rec_1950, ((V)("c")), Arr(((V)((ToNum(Get(t_1948, "t")) - 200D))), Add(Get(t_1948, "t"), ((V)(900D)))));
Invoke(t_1948, "wait", ((V)(900D)));
return Invoke(t_1948, "back", ((V)(320D)));
return default;
}, 3, "catch", false)).Put("punch", Fn((V _self1951, int _argc1952, V t_1958, V X_1959, V rec_1960, V _a1957, V[] _rest1953) => {
if (_self1951.IsNullish) _self1951 = GlobalV;
Invoke(t_1958, "to", ((V)(160D)), NewObj(5).Put("armR", ((V)(165D))).Put("hRy", ((V)((-8D)))).Put("lift", ((V)(5D))).Put("sq", ((V)((-0.06)))).Put("open", ((V)(0.5))).V, ((V)("o")));
Call(push_46, V.Undef, rec_1960, ((V)("pu")), Get(t_1958, "t"));
Invoke(Invoke(t_1958, "fx", ((V)("spark")), ((V)("pawR")), ((V)(3D))), "to", ((V)(240D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i")));
return Invoke(t_1958, "back", ((V)(300D)));
return default;
}, 3, "punch", false)).V;
HPB_100 = NewObj(3).Put("dribble", Fn((V _self1961, int _argc1962, V t_1968, V X_1969, V rec_1970, V _a1967, V[] _rest1963) => {
V a_1971 = default;
if (_self1961.IsNullish) _self1961 = GlobalV;
a_1971 = Get(t_1968, "t");
Invoke(t_1968, "to", ((V)(200D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)((-2D))), ((V)(4D))), NewObj(4).Put("armR", ((V)(30D))).Put("pitch", ((V)((-0.08)))).Put("ly", ((V)(0.6))).Put("sq", ((V)(0.03))).V), ((V)("io")));
{
double i_1972 = 0;
i_1972 = 0D;
while (true) {
if (!((i_1972 < 5D))) break;
Invoke(Invoke(t_1968, "to", ((V)(150D)), NewObj(3).Put("hRy", ((V)(8D))).Put("armR", ((V)(22D))).Put("sq", ((V)(0.05))).V, ((V)("i"))), "to", ((V)(150D)), NewObj(3).Put("hRy", ((V)(3D))).Put("armR", ((V)(32D))).Put("sq", ((V)(0.02))).V, ((V)("o")));
i_1972++;
}
}
Call(push_46, V.Undef, rec_1970, ((V)("dr")), Arr(a_1971, Get(t_1968, "t")));
return Invoke(t_1968, "back", ((V)(240D)));
return default;
}, 3, "dribble", false)).Put("shoot", Fn((V _self1974, int _argc1975, V t_1981, V X_1982, V rec_1983, V _a1980, V[] _rest1976) => {
if (_self1974.IsNullish) _self1974 = GlobalV;
Invoke(Invoke(t_1981, "to", ((V)(260D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-6D)))), NewObj(7).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("sq", ((V)(0.12))).Put("lift", ((V)((-1D)))).Put("ly", ((V)((-0.6)))).Put("pitch", ((V)(0.12))).Put("sqz", ((V)(0.3))).V), ((V)("io"))), "to", ((V)(240D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-14D)))), NewObj(7).Put("armL", ((V)(160D))).Put("armR", ((V)(160D))).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(9D))).Put("footL", ((V)(1.4))).Put("footR", ((V)(1.4))).Put("sqz", ((V)(0D))).V), ((V)("o")));
Call(push_46, V.Undef, rec_1983, ((V)("sh")), Get(t_1981, "t"));
Invoke(Invoke(Invoke(Invoke(t_1981, "to", ((V)(160D)), NewObj(2).Put("armR", ((V)(170D))).Put("hRy", ((V)((-16D)))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(4).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(4).Put("sq", ((V)(0D))).Put("ly", ((V)((-0.8)))).Put("pitch", ((V)(0.2))).Put("wide", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(300D)));
return Invoke(t_1981, "back", ((V)(300D)));
return default;
}, 3, "shoot", false)).Put("spinball", Fn((V _self1984, int _argc1985, V t_1991, V X_1992, V rec_1993, V _a1990, V[] _rest1986) => {
V a_1994 = default;
if (_self1984.IsNullish) _self1984 = GlobalV;
a_1994 = Get(t_1991, "t");
Invoke(Invoke(t_1991, "to", ((V)(320D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-16D)))), NewObj(5).Put("armR", ((V)(150D))).Put("ly", ((V)((-0.8)))).Put("pitch", ((V)(0.16))).Put("tongue", ((V)(0.5))).Put("sqz", ((V)(0.4))).V), ((V)("io"))), "osc", ((V)(1600D)), ((V)(4D)), NewObj(2).Put("tilt", ((V)(2D))).Put("x", ((V)(0.5))).V, NewObj(2).Put("tilt", ((V)((-2D)))).Put("x", ((V)((-0.5)))).V, ((V)("s")));
Call(push_46, V.Undef, rec_1993, ((V)("sp")), Arr(a_1994, Get(t_1991, "t")));
Invoke(t_1991, "to", ((V)(200D)), NewObj(3).Put("tongue", ((V)(0D))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.8))).V, ((V)("o")));
return Invoke(t_1991, "back", ((V)(360D)));
return default;
}, 3, "spinball", false)).V;
GF0_102 = Call(S0_39, V.Undef, NewObj(5).Put("pitch", ((V)((-0.2)))).Put("ly", ((V)(0.8))).Put("armL", ((V)(26D))).Put("armR", ((V)(26D))).Put("lean", ((V)(0.2))).V, Call(both_15, V.Undef, ((V)(9D)), ((V)(4D))));
GFB_103 = NewObj(3).Put("line", Fn((V _self1995, int _argc1996, V t_2002, V _a1999, V _a2000, V _a2001, V[] _rest1997) => {
if (_self1995.IsNullish) _self1995 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_2002, "to", ((V)(400D)), NewObj(6).Put("sq", ((V)(0.1))).Put("lift", ((V)((-1.2)))).Put("pitch", ((V)((-0.3)))).Put("lx", ((V)(0.9))).Put("ly", ((V)(0.9))).Put("winkL", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(300D)), NewObj(1).Put("lx", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(5).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("winkL", ((V)(0D))).Put("pitch", ((V)((-0.2)))).Put("lx", ((V)(0D))).V, ((V)("io")));
return Invoke(t_2002, "back", ((V)(200D)));
return default;
}, 1, "line", false)).Put("waggle", Fn((V _self2003, int _argc2004, V t_2010, V _a2007, V _a2008, V _a2009, V[] _rest2005) => {
V B_2011 = default;
if (_self2003.IsNullish) _self2003 = GlobalV;
B_2011 = Get(t_2010, "B");
Invoke(t_2010, "osc", ((V)(1000D)), ((V)(3D)), NewObj(3).Put("hLx", ((V)((ToNum(Get(B_2011, "hLx")) - 1.6)))).Put("hRx", ((V)((ToNum(Get(B_2011, "hRx")) - 1.6)))).Put("tilt", ((V)(1D))).V, NewObj(3).Put("hLx", Add(Get(B_2011, "hLx"), ((V)(1.2)))).Put("hRx", Add(Get(B_2011, "hRx"), ((V)(1.2)))).Put("tilt", ((V)((-1D)))).V, ((V)("io")));
return Invoke(t_2010, "back", ((V)(200D)));
return default;
}, 1, "waggle", false)).Put("putt", Fn((V _self2012, int _argc2013, V t_2019, V X_2020, V rec_2021, V _a2018, V[] _rest2014) => {
V B_2022 = default;
if (_self2012.IsNullish) _self2012 = GlobalV;
B_2022 = Get(t_2019, "B");
Invoke(Invoke(t_2019, "to", ((V)(500D)), NewObj(4).Put("hLx", Add(Get(B_2022, "hLx"), ((V)(3D)))).Put("hRx", Add(Get(B_2022, "hRx"), ((V)(3D)))).Put("tilt", ((V)((-2D)))).Put("sqz", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(3).Put("hLx", ((V)((ToNum(Get(B_2022, "hLx")) - 3.4)))).Put("hRx", ((V)((ToNum(Get(B_2022, "hRx")) - 3.4)))).Put("tilt", ((V)(2D))).V, ((V)("o")));
Call(push_46, V.Undef, rec_2021, ((V)("pt")), ((V)((ToNum(Get(t_2019, "t")) - 120D))));
Invoke(Invoke(t_2019, "to", ((V)(500D)), NewObj(6).Put("lx", ((V)(0.9))).Put("ly", ((V)(0.8))).Put("lean", ((V)(0.8))).Put("wide", ((V)(0.6))).Put("sqz", ((V)(0D))).Put("tongue", ((V)(0.4))).V, ((V)("io"))), "wait", ((V)(700D)));
return Invoke(t_2019, "back", ((V)(360D)));
return default;
}, 3, "putt", false)).V;
DMU_105 = Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)((-3D))), ((V)((-6D)))), NewObj(9).Put("lift", ((V)(15D))).Put("armL", ((V)(158D))).Put("armR", ((V)(158D))).Put("sq", ((V)((-0.04)))).Put("footL", ((V)(1.4))).Put("footR", ((V)(1.4))).Put("pitch", ((V)(0.06))).Put("ly", ((V)((-0.2)))).Put("tilt", ((V)(0D))).V);
DMB_106 = NewObj(5).Put("climb", Fn((V _self2023, int _argc2024, V t_2030, V _a2027, V _a2028, V _a2029, V[] _rest2025) => {
if (_self2023.IsNullish) _self2023 = GlobalV;
{
double i_2031 = 0;
i_2031 = 0D;
while (true) {
if (!((i_2031 < 4D))) break;
double s_2033 = 0;
s_2033 = (NumTruthy((i_2031 % 2D)) ? (-1D) : 1D);
Invoke(t_2030, "to", ((V)(300D)), NewObj(9).Put("armL", ((V)(((s_2033 > 0D) ? 165D : 120D)))).Put("armR", ((V)(((s_2033 > 0D) ? 120D : 165D)))).Put("footL", ((V)(((s_2033 > 0D) ? 2.6 : 0.6)))).Put("footR", ((V)(((s_2033 > 0D) ? 0.6 : 2.6)))).Put("lift", ((V)((3.75 * (i_2031 + 1D))))).Put("tilt", ((V)((s_2033 * 3D)))).Put("pitch", ((V)(0.1))).Put("ly", ((V)((-0.4)))).Put("sqz", ((V)(0.3))).V, ((V)("io")));
i_2031++;
}
}
Invoke(t_2030, "to", ((V)(240D)), Call(o_21, V.Undef, DMU_105, NewObj(1).Put("sqz", ((V)(0D))).V), ((V)("io")));
return t_2030;
return default;
}, 1, "climb", false)).Put("hang", Fn((V _self2034, int _argc2035, V t_2041, V _a2038, V _a2039, V _a2040, V[] _rest2036) => {
if (_self2034.IsNullish) _self2034 = GlobalV;
Invoke(Invoke(t_2041, "osc", ((V)(2000D)), ((V)(4D)), NewObj(3).Put("footL", ((V)(3D))).Put("footR", ((V)(0.4))).Put("tilt", ((V)(3D))).V, NewObj(3).Put("footL", ((V)(0.4))).Put("footR", ((V)(3D))).Put("tilt", ((V)((-3D)))).V, ((V)("s"))), "to", ((V)(240D)), DMU_105, ((V)("io")));
return t_2041;
return default;
}, 1, "hang", false)).Put("topwave", Fn((V _self2042, int _argc2043, V t_2049, V X_2050, V _a2047, V _a2048, V[] _rest2044) => {
if (_self2042.IsNullish) _self2042 = GlobalV;
Invoke(Invoke(Invoke(t_2049, "to", ((V)(300D)), Call(o_21, V.Undef, NewObj(5).Put("armR", ((V)(150D))).Put("hRy", ((V)((-2D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, Get(X_2050, "cheer")), ((V)("o"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("armR", ((V)(120D))).V, NewObj(1).Put("armR", ((V)(165D))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_21, V.Undef, DMU_105, NewObj(3).Put("hap", ((V)(0.3))).Put("smile", ((V)(0.7))).Put("open", ((V)(0D))).V), ((V)("io")));
return t_2049;
return default;
}, 2, "topwave", false)).Put("peek", Fn((V _self2051, int _argc2052, V t_2058, V _a2055, V _a2056, V _a2057, V[] _rest2053) => {
if (_self2051.IsNullish) _self2051 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_2058, "to", ((V)(400D)), NewObj(4).Put("lx", ((V)((-0.9)))).Put("ly", ((V)(0.9))).Put("pitch", ((V)((-0.2)))).Put("htilt", ((V)((-6D)))).V, ((V)("io"))), "wait", ((V)(600D))), "to", ((V)(400D)), NewObj(2).Put("lx", ((V)(0.9))).Put("htilt", ((V)(6D))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(300D)), Call(o_21, V.Undef, DMU_105, NewObj(2).Put("lx", ((V)(0D))).Put("htilt", ((V)(0D))).V), ((V)("io")));
return t_2058;
return default;
}, 1, "peek", false)).Put("down", Fn((V _self2059, int _argc2060, V t_2066, V _a2063, V _a2064, V _a2065, V[] _rest2061) => {
if (_self2059.IsNullish) _self2059 = GlobalV;
{
double i_2067 = 0;
i_2067 = 3D;
while (true) {
if (!((i_2067 >= 0D))) break;
double s_2069 = 0;
s_2069 = (NumTruthy((i_2067 % 2D)) ? (-1D) : 1D);
Invoke(t_2066, "to", ((V)(260D)), NewObj(6).Put("armL", ((V)(((s_2069 > 0D) ? 160D : 110D)))).Put("armR", ((V)(((s_2069 > 0D) ? 110D : 160D)))).Put("lift", ((V)((3.75 * i_2067)))).Put("footL", ((V)(((s_2069 > 0D) ? 2D : 0D)))).Put("footR", ((V)(((s_2069 > 0D) ? 0D : 2D)))).Put("tilt", ((V)((s_2069 * 3D)))).V, ((V)("io")));
i_2067--;
}
}
Invoke(t_2066, "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0.1))).V, ((V)("i")));
return Invoke(t_2066, "back", ((V)(320D)));
return default;
}, 1, "down", false)).V;
AGB_107 = NewObj(4).Put("hurdle", Fn((V _self2070, int _argc2071, V t_2077, V _a2074, V _a2075, V _a2076, V[] _rest2072) => {
if (_self2070.IsNullish) _self2070 = GlobalV;
{
double i_2078 = 0;
i_2078 = 0D;
while (true) {
if (!((i_2078 < 3D))) break;
Invoke(Invoke(Invoke(t_2077, "to", ((V)(120D)), NewObj(3).Put("sq", ((V)(0.12))).Put("lift", ((V)((-0.6)))).Put("pitch", ((V)((-0.04)))).V, ((V)("i"))), "to", ((V)(240D)), NewObj(7).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(9D))).Put("footL", ((V)(3D))).Put("footR", ((V)(3D))).Put("armL", ((V)(120D))).Put("armR", ((V)(60D))).Put("lean", ((V)(1D))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(7).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("lean", ((V)(0.4))).V, ((V)("i")));
i_2078++;
}
}
Invoke(t_2077, "fx", ((V)("dust")), ((V)("belly")), ((V)(3D)));
return Invoke(t_2077, "back", ((V)(260D)));
return default;
}, 1, "hurdle", false)).Put("weave", Fn((V _self2080, int _argc2081, V t_2087, V _a2084, V _a2085, V _a2086, V[] _rest2082) => {
if (_self2080.IsNullish) _self2080 = GlobalV;
Invoke(t_2087, "osc", ((V)(1800D)), ((V)(4D)), NewObj(4).Put("x", ((V)(3D))).Put("tilt", ((V)(7D))).Put("lean", ((V)(1D))).Put("footL", ((V)(1.6))).V, NewObj(4).Put("x", ((V)((-3D)))).Put("tilt", ((V)((-7D)))).Put("lean", ((V)((-1D)))).Put("footR", ((V)(1.6))).V, ((V)("s")));
return Invoke(t_2087, "back", ((V)(300D)));
return default;
}, 1, "weave", false)).Put("tire", Fn((V _self2088, int _argc2089, V t_2095, V X_2096, V _a2093, V _a2094, V[] _rest2090) => {
if (_self2088.IsNullish) _self2088 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_2095, "to", ((V)(260D)), NewObj(5).Put("sq", ((V)(0.16))).Put("lift", ((V)((-1.4)))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).Put("pitch", ((V)((-0.1)))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_21, V.Undef, NewObj(11).Put("sq", ((V)((-0.12)))).Put("lift", ((V)(13D))).Put("armL", ((V)(160D))).Put("armR", ((V)(160D))).Put("hLy", ((V)((-6D)))).Put("hRy", ((V)((-6D)))).Put("footL", ((V)(3D))).Put("footR", ((V)(3D))).Put("open", ((V)(0.5))).Put("wide", ((V)(0.5))).Put("hap", ((V)(1D))).V, (Get(X_2096, "tk") is var _t2097 && Truthy(_t2097) ? _t2097 : NewObj(0).V)), ((V)("o"))), "to", ((V)(300D)), NewObj(8).Put("lift", ((V)(0D))).Put("sq", ((V)(0.14))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("i"))), "fx", ((V)("dust")), ((V)("belly")), ((V)(4D))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("o")));
return Invoke(t_2095, "back", ((V)(300D)));
return default;
}, 2, "tire", false)).Put("ramp", Fn((V _self2098, int _argc2099, V t_2105, V _a2102, V _a2103, V _a2104, V[] _rest2100) => {
if (_self2098.IsNullish) _self2098 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2105, "to", ((V)(700D)), NewObj(6).Put("lift", ((V)(10D))).Put("pitch", ((V)(0.1))).Put("lean", ((V)(1D))).Put("footL", ((V)(1.6))).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("pitch", ((V)((-0.1)))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(6).Put("lift", ((V)(0D))).Put("pitch", ((V)((-0.2)))).Put("lean", ((V)(0.6))).Put("sq", ((V)(0.06))).Put("open", ((V)(0.5))).Put("wide", ((V)(0.6))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("o")));
return Invoke(t_2105, "back", ((V)(300D)));
return default;
}, 1, "ramp", false)).V;
tossB_108 = Fn((V _arrowThis2113, int _argc2106, V kind_2112, V _a2109, V _a2110, V _a2111, V[] _rest2107) => {
return Fn((V _self2114, int _argc2115, V t_2121, V X_2122, V rec_2123, V _a2120, V[] _rest2116) => {
V bo_2124 = default;
if (_self2114.IsNullish) _self2114 = GlobalV;
bo_2124 = (SEqS(kind_2112, "bocce") ? V.True : V.False);
Invoke(Invoke(t_2121, "to", ((V)(300D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)((-2D))), ((V)(4D))), NewObj(6).Put("armR", ((V)((Truthy(bo_2124) ? (-8D) : 6D)))).Put("lean", ((V)((-0.5)))).Put("lx", ((V)(0.8))).Put("ly", ((V)((Truthy(bo_2124) ? 0.6 : (-0.1))))).Put("sqz", ((V)(0.3))).Put("sq", ((V)((Truthy(bo_2124) ? 0.1 : 0.04)))).V), ((V)("io"))), "to", ((V)((SEqS(kind_2112, "shoe") ? 200D : 240D))), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(2D)), ((V)((-4D)))), NewObj(6).Put("armR", ((V)((Truthy(bo_2124) ? 60D : (SEqS(kind_2112, "shoe") ? 120D : 100D))))).Put("lean", ((V)(0.8))).Put("footL", ((V)(2D))).Put("sq", ((V)((-0.03)))).Put("sqz", ((V)(0D))).Put("open", ((V)(0.3))).V), ((V)("o")));
Call(push_46, V.Undef, rec_2123, ((V)("ts")), Get(t_2121, "t"));
Invoke(Invoke(Invoke(t_2121, "to", ((V)(300D)), NewObj(2).Put("footL", ((V)(0D))).Put("lean", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(4).Put("lx", ((V)(0.9))).Put("ly", ((V)((Truthy(bo_2124) ? 0.7 : 0.3)))).Put("wide", ((V)(0.6))).Put("open", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(500D)));
return Invoke(t_2121, "back", ((V)(360D)));
return default;
}, 3, "", false);
}, 1, "", true);
aimB_109 = Fn((V _arrowThis2132, int _argc2125, V t_2131, V _a2128, V _a2129, V _a2130, V[] _rest2126) => {
V B_2133 = default;
B_2133 = Get(t_2131, "B");
Invoke(Invoke(Invoke(t_2131, "to", ((V)(300D)), NewObj(5).Put("lx", ((V)(0.9))).Put("ly", ((V)(0.3))).Put("htilt", ((V)(5D))).Put("winkL", ((V)(0.8))).Put("tongue", ((V)(0.3))).V, ((V)("io"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("armR", Add(Get(B_2133, "armR"), ((V)(18D)))).V, NewObj(1).Put("armR", ((V)((ToNum(Get(B_2133, "armR")) - 6D)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("winkL", ((V)(0D))).Put("tongue", ((V)(0D))).V);
return Invoke(t_2131, "back", ((V)(300D)));
return default;
}, 1, "", true);
PG0_111 = Call(S0_39, V.Undef, NewObj(3).Put("armR", ((V)(44D))).Put("pitch", ((V)((-0.06)))).Put("ly", ((V)(0.3))).V, Call(hand_14, V.Undef, ((V)(1D)), ((V)(0D)), ((V)((-4D)))));
PGB_112 = NewObj(3).Put("serve", Fn((V _self2134, int _argc2135, V t_2141, V X_2142, V rec_2143, V _a2140, V[] _rest2136) => {
if (_self2134.IsNullish) _self2134 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2141, "to", ((V)(300D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)((-12D)))), NewObj(2).Put("armL", ((V)(70D))).Put("ly", ((V)((-0.6)))).V), ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("hLy", ((V)((-18D)))).Put("armL", ((V)(110D))).Put("ly", ((V)((-0.9)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("armR", ((V)(120D))).Put("hRy", ((V)((-8D)))).V, ((V)("io"))), "to", ((V)(110D)), NewObj(3).Put("armR", ((V)(40D))).Put("hRy", ((V)((-2D)))).Put("lean", ((V)(0.6))).V, ((V)("o")));
Call(push_46, V.Undef, rec_2143, ((V)("h")), Get(t_2141, "t"));
return Invoke(t_2141, "back", ((V)(300D)));
return default;
}, 3, "serve", false)).Put("rally", Fn((V _self2144, int _argc2145, V t_2151, V X_2152, V rec_2153, V _a2150, V[] _rest2146) => {
if (_self2144.IsNullish) _self2144 = GlobalV;
{
double i_2154 = 0;
i_2154 = 0D;
while (true) {
if (!((i_2154 < 6D))) break;
V fh_2156 = default;
fh_2156 = (((i_2154 % 2D) == 0D) ? V.True : V.False);
Invoke(Invoke(t_2151, "wait", ((V)(160D))), "to", ((V)(140D)), (Truthy(fh_2156) ? NewObj(4).Put("armR", ((V)(70D))).Put("hRx", ((V)((-4D)))).Put("lean", ((V)(0.6))).Put("x", ((V)(0.8))).V : NewObj(4).Put("armR", ((V)(30D))).Put("hRx", ((V)(6D))).Put("lean", ((V)((-0.4)))).Put("x", ((V)((-0.8)))).V), ((V)("o")));
Call(push_46, V.Undef, rec_2153, ((V)("h")), Get(t_2151, "t"));
i_2154++;
}
}
return Invoke(t_2151, "back", ((V)(300D)));
return default;
}, 3, "rally", false)).Put("smash", Fn((V _self2157, int _argc2158, V t_2164, V X_2165, V rec_2166, V _a2163, V[] _rest2159) => {
if (_self2157.IsNullish) _self2157 = GlobalV;
Invoke(Invoke(t_2164, "to", ((V)(220D)), NewObj(6).Put("armR", ((V)(160D))).Put("hRy", ((V)((-10D)))).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.06)))).Put("open", ((V)(0.4))).Put("wide", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(100D)), NewObj(5).Put("armR", ((V)(30D))).Put("hRy", ((V)(2D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).Put("lean", ((V)(1D))).V, ((V)("i")));
Call(push_46, V.Undef, rec_2166, ((V)("h")), Get(t_2164, "t"));
Invoke(Invoke(t_2164, "fx", ((V)("spark")), ((V)("pawR")), ((V)(3D))), "wait", ((V)(300D)));
return Invoke(t_2164, "back", ((V)(300D)));
return default;
}, 3, "smash", false)).V;
TTB_113 = NewObj(4).Put("punch", Fn((V _self2167, int _argc2168, V t_2174, V _a2171, V _a2172, V _a2173, V[] _rest2169) => {
if (_self2167.IsNullish) _self2167 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2174, "to", ((V)(160D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-10D)))), NewObj(3).Put("armR", ((V)(90D))).Put("lean", ((V)((-0.4)))).Put("turn", ((V)((-0.15)))).V), ((V)("io"))), "to", ((V)(140D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)((-6D))), ((V)((-14D)))), NewObj(5).Put("armR", ((V)(160D))).Put("lean", ((V)(0.8))).Put("turn", ((V)(0.15))).Put("sq", ((V)((-0.04)))).Put("open", ((V)(0.4))).V), ((V)("o"))), "fx", ((V)("spark")), ((V)("pawR")), ((V)(2D))), "to", ((V)(300D)), NewObj(4).Put("turn", ((V)(0D))).Put("lean", ((V)(0D))).Put("lx", ((V)(0.9))).Put("ly", ((V)((-0.6)))).V, ((V)("io")));
return Invoke(t_2174, "back", ((V)(300D)));
return default;
}, 1, "punch", false)).Put("duck", Fn((V _self2175, int _argc2176, V t_2182, V _a2179, V _a2180, V _a2181, V[] _rest2177) => {
if (_self2175.IsNullish) _self2175 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2182, "to", ((V)(200D)), NewObj(8).Put("sq", ((V)(0.2))).Put("lift", ((V)((-2.4)))).Put("close", ((V)(1D))).Put("sqz", ((V)(0.8))).Put("armL", ((V)(100D))).Put("armR", ((V)(100D))).Put("hLy", ((V)((-4D)))).Put("hRy", ((V)((-4D)))).V, ((V)("o"))), "wait", ((V)(400D))), "to", ((V)(260D)), NewObj(5).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("close", ((V)(0D))).Put("sqz", ((V)(0D))).Put("wide", ((V)(0.8))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("head")), ((V)(1D)));
return Invoke(t_2182, "back", ((V)(300D)));
return default;
}, 1, "duck", false)).Put("track", Fn((V _self2183, int _argc2184, V t_2190, V _a2187, V _a2188, V _a2189, V[] _rest2185) => {
if (_self2183.IsNullish) _self2183 = GlobalV;
Invoke(t_2190, "osc", ((V)(2400D)), ((V)(2D)), NewObj(3).Put("lx", ((V)(0.9))).Put("turn", ((V)(0.2))).Put("ly", ((V)((-0.5)))).V, NewObj(3).Put("lx", ((V)((-0.9)))).Put("turn", ((V)((-0.2)))).Put("ly", ((V)((-0.3)))).V, ((V)("s")));
return Invoke(t_2190, "back", ((V)(300D)));
return default;
}, 1, "track", false)).Put("double", Fn((V _self2191, int _argc2192, V t_2198, V _a2195, V _a2196, V _a2197, V[] _rest2193) => {
if (_self2191.IsNullish) _self2191 = GlobalV;
Invoke(TTB_113, "punch", t_2198);
Invoke(Invoke(t_2198, "to", ((V)(140D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)((-6D))), ((V)((-14D)))), NewObj(3).Put("armL", ((V)(160D))).Put("lean", ((V)((-0.8)))).Put("sq", ((V)((-0.04)))).V), ((V)("o"))), "fx", ((V)("spark")), ((V)("pawL")), ((V)(2D)));
return Invoke(t_2198, "back", ((V)(300D)));
return default;
}, 1, "double", false)).V;
HSB_114 = NewObj(5).Put("toss", Fn((V _self2199, int _argc2200, V t_2206, V X_2207, V rec_2208, V _a2205, V[] _rest2201) => {
if (_self2199.IsNullish) _self2199 = GlobalV;
Invoke(Invoke(t_2206, "to", ((V)(300D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)((-4D))), ((V)(6D))), NewObj(4).Put("armR", ((V)(10D))).Put("lean", ((V)((-0.4)))).Put("lx", ((V)(0.8))).Put("ly", ((V)(0.8))).V), ((V)("io"))), "to", ((V)(200D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-2D)))), NewObj(2).Put("armR", ((V)(70D))).Put("lean", ((V)(0.4))).V), ((V)("o")));
Call(push_46, V.Undef, rec_2208, ((V)("ts")), Get(t_2206, "t"));
Invoke(t_2206, "to", ((V)(500D)), NewObj(2).Put("lx", ((V)(0.9))).Put("ly", ((V)(0.9))).V, ((V)("io")));
return Invoke(t_2206, "back", ((V)(300D)));
return default;
}, 3, "toss", false)).Put("hops", Fn((V _self2209, int _argc2210, V t_2216, V _a2213, V _a2214, V _a2215, V[] _rest2211) => {
if (_self2209.IsNullish) _self2209 = GlobalV;
{
double i_2217 = 0;
i_2217 = 0D;
while (true) {
if (!((i_2217 < 6D))) break;
V one_2219 = default;
double s_2220 = 0;
one_2219 = (((i_2217 % 3D) != 2D) ? V.True : V.False);
s_2220 = (NumTruthy((i_2217 % 2D)) ? 1D : (-1D));
Invoke(Invoke(Invoke(t_2216, "to", ((V)(110D)), NewObj(2).Put("sq", ((V)(0.1))).Put("lift", ((V)((-0.5)))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(8).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(6D))).Put("footL", ((V)((Truthy(one_2219) ? 3D : 0D)))).Put("footR", ((V)(0D))).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).Put("x", ((V)(((i_2217 + 1D) * 0.8)))).Put("tilt", ((V)((Truthy(one_2219) ? (s_2220 * 2D) : 0D)))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i")));
i_2217++;
}
}
Invoke(t_2216, "to", ((V)(200D)), NewObj(2).Put("footL", ((V)(0D))).Put("tilt", ((V)(0D))).V);
return t_2216;
return default;
}, 1, "hops", false)).Put("twirl", Fn((V _self2221, int _argc2222, V t_2228, V _a2225, V _a2226, V _a2227, V[] _rest2223) => {
if (_self2221.IsNullish) _self2221 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2228, "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.1))).V, ((V)("i"))), "to", ((V)(600D)), NewObj(4).Put("spin", ((V)(360D))).Put("lift", ((V)(5D))).Put("sq", ((V)((-0.05)))).Put("hap", ((V)(1D))).V, ((V)("io"))), "to", ((V)(10D)), NewObj(1).Put("spin", ((V)(0D))).V), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i")));
return t_2228;
return default;
}, 1, "twirl", false)).Put("hopback", Fn((V _self2229, int _argc2230, V t_2236, V _a2233, V _a2234, V _a2235, V[] _rest2231) => {
if (_self2229.IsNullish) _self2229 = GlobalV;
{
double i_2237 = 0;
i_2237 = 5D;
while (true) {
if (!((i_2237 >= 0D))) break;
Invoke(Invoke(Invoke(t_2236, "to", ((V)(110D)), NewObj(1).Put("sq", ((V)(0.1))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(6).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(6D))).Put("footR", ((V)(3D))).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).Put("x", ((V)((i_2237 * 0.8)))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i")));
i_2237--;
}
}
return Invoke(t_2236, "back", ((V)(300D)));
return default;
}, 1, "hopback", false)).Put("pick", Fn((V _self2239, int _argc2240, V t_2246, V X_2247, V rec_2248, V _a2245, V[] _rest2241) => {
if (_self2239.IsNullish) _self2239 = GlobalV;
Invoke(t_2246, "to", ((V)(380D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)((-2D))), ((V)(10D))), NewObj(4).Put("pitch", ((V)((-0.4)))).Put("ly", ((V)(1D))).Put("sq", ((V)(0.1))).Put("armR", ((V)(12D))).V), ((V)("io")));
Call(push_46, V.Undef, rec_2248, ((V)("pk")), Get(t_2246, "t"));
Invoke(t_2246, "wait", ((V)(200D)));
return Invoke(t_2246, "back", ((V)(400D)));
return default;
}, 3, "pick", false)).V;
TU0_116 = Call(S0_39, V.Undef, NewObj(6).Put("sq", ((V)(0.16))).Put("lift", ((V)((-2.4)))).Put("pitch", ((V)((-0.22)))).Put("ly", ((V)(0.8))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, Call(both_15, V.Undef, ((V)((-4D))), ((V)(6D))));
TUB_117 = NewObj(3).Put("crawl", Fn((V _self2249, int _argc2250, V t_2256, V _a2253, V _a2254, V _a2255, V[] _rest2251) => {
if (_self2249.IsNullish) _self2249 = GlobalV;
{
double i_2257 = 0;
i_2257 = 0D;
while (true) {
if (!((i_2257 < 6D))) break;
double s_2259 = 0;
s_2259 = (NumTruthy((i_2257 % 2D)) ? (-1D) : 1D);
Invoke(t_2256, "to", ((V)(220D)), NewObj(6).Put("armL", ((V)(((s_2259 > 0D) ? 82D : 46D)))).Put("armR", ((V)(((s_2259 > 0D) ? 46D : 82D)))).Put("footL", ((V)(((s_2259 > 0D) ? 0D : 1.6)))).Put("footR", ((V)(((s_2259 > 0D) ? 1.6 : 0D)))).Put("tilt", ((V)((s_2259 * 3D)))).Put("x", ((V)((s_2259 * 0.5)))).V, ((V)("io")));
i_2257++;
}
}
return Invoke(t_2256, "back", ((V)(260D)));
return default;
}, 1, "crawl", false)).Put("peek", Fn((V _self2260, int _argc2261, V t_2267, V _a2264, V _a2265, V _a2266, V[] _rest2262) => {
if (_self2260.IsNullish) _self2260 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2267, "to", ((V)(300D)), NewObj(5).Put("pitch", ((V)(0.12))).Put("ly", ((V)((-0.2)))).Put("sq", ((V)(0.06))).Put("wide", ((V)(0.6))).Put("lx", ((V)((-0.8)))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(400D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(300D)));
return Invoke(t_2267, "back", ((V)(300D)));
return default;
}, 1, "peek", false)).Put("pop", Fn((V _self2268, int _argc2269, V t_2275, V X_2276, V _a2273, V _a2274, V[] _rest2270) => {
if (_self2268.IsNullish) _self2268 = GlobalV;
Invoke(t_2275, "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.2))).Put("lift", ((V)((-3D)))).V, ((V)("i")));
Call(cheer_47, V.Undef, t_2275, X_2276, NewObj(2).Put("pitch", ((V)(0.06))).Put("ly", ((V)(0D))).V);
return t_2275;
return default;
}, 2, "pop", false)).V;
FRB_118 = NewObj(2).Put("throw", Fn((V _self2277, int _argc2278, V t_2284, V X_2285, V rec_2286, V _a2283, V[] _rest2279) => {
if (_self2277.IsNullish) _self2277 = GlobalV;
Invoke(Invoke(t_2284, "to", ((V)(320D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(10D)), ((V)(0D))), NewObj(4).Put("armR", ((V)(30D))).Put("turn", ((V)((-0.2)))).Put("lean", ((V)((-0.4)))).Put("lx", ((V)(0.6))).V), ((V)("io"))), "to", ((V)(160D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)((-6D))), ((V)((-4D)))), NewObj(4).Put("armR", ((V)(96D))).Put("turn", ((V)(0.2))).Put("lean", ((V)(0.8))).Put("open", ((V)(0.3))).V), ((V)("o")));
Call(push_46, V.Undef, rec_2286, ((V)("th")), Get(t_2284, "t"));
Invoke(Invoke(t_2284, "to", ((V)(400D)), NewObj(4).Put("turn", ((V)(0D))).Put("lean", ((V)(0.2))).Put("lx", ((V)(0.9))).Put("ly", ((V)((-0.3)))).V, ((V)("io"))), "to", ((V)(600D)), NewObj(2).Put("lx", ((V)((-0.2)))).Put("ly", ((V)((-0.6)))).V, ((V)("io")));
return t_2284;
return default;
}, 3, "throw", false)).Put("catch", Fn((V _self2287, int _argc2288, V t_2294, V X_2295, V rec_2296, V _a2293, V[] _rest2289) => {
if (_self2287.IsNullish) _self2287 = GlobalV;
Invoke(Invoke(t_2294, "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.12))).Put("lift", ((V)((-1D)))).V, ((V)("i"))), "to", ((V)(240D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-14D)))), NewObj(6).Put("armL", ((V)(160D))).Put("armR", ((V)(160D))).Put("lift", ((V)(10D))).Put("sq", ((V)((-0.08)))).Put("wide", ((V)(0.6))).Put("open", ((V)(0.5))).V), ((V)("o")));
Call(push_46, V.Undef, rec_2296, ((V)("ca")), Get(t_2294, "t"));
Invoke(Invoke(t_2294, "to", ((V)(260D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "to", ((V)(200D)), Call(o_21, V.Undef, NewObj(4).Put("sq", ((V)(0D))).Put("sqz", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, Get(X_2295, "cheer")), ((V)("o")));
return Invoke(t_2294, "back", ((V)(360D)));
return default;
}, 3, "catch", false)).V;
CX_120 = NewObj(0).V;
Call(cBuild_121, V.Undef, V.Null, NewObj(0).V);
Object_assign(H_9, NewObj(3).Put("cBuild", cBuild_121).Put("CX", CX_120).Put("ST0", ST0_38).V);
return default;
}, 1, "", false));
        }
    }
}
