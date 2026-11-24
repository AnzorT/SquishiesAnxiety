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
Invoke(Call(K_37, V.Undef, B_129), "forEach", Fn((V _self122, int _argc141, V p_147, V _a144, V _a145, V _a146, V[] _rest142) => {
return SetK(v_137, p_147, GetK(B_129, p_147));
}, 1, "", true));
Invoke(t_136, "to", ((V)(10D)), v_137);
Set(t_136, "B", Call(o_21, V.Undef, REST_11, B_129));
bt_138 = Arr();
rec_139 = NewObj(0).V;
Invoke(ord_130, "forEach", Fn((V _self122, int _argc148, V n_154, V i_155, V _a152, V _a153, V[] _rest149) => {
V a_156 = default;
Invoke(t_136, "wait", GetIdx(gaps_134, (ToNum(i_155) % ToNum(Get(gaps_134, "length")))));
a_156 = Get(t_136, "t");
if (SEqS(n_154, "sig")) {
if (!(Truthy(sig_133))) {
return default;
}
Call(sig_133, V.Undef, t_136);
} else {
if (Truthy(GetK(BK_131, n_154))) {
InvokeK(BK_131, n_154, t_136, X_132, rec_139);
} else {
if (Truthy(GetK(BEAT_13, n_154))) {
InvokeK(BEAT_13, n_154, t_136);
} else {
return default;
}
}
}
Invoke(bt_138, "push", Arr(n_154, a_156, Get(t_136, "t")));
return default;
}, 2, "", true));
Invoke(t_136, "wait", ((V)(800D)));
st_140 = Invoke(t_136, "out", Call(o_21, V.Undef, NewObj(3).Put("breathe", ((V)(0.5))).Put("look", (false ? V.True : V.False)).Put("blend", ((V)(420D))).V, (ex_135 is var _t157 && Truthy(_t157) ? _t157 : NewObj(0).V)), (true ? V.True : V.False));
Set(st_140, "beats", bt_138);
Set(st_140, "rec", rec_139);
return st_140;
return default;
}, 7, "hold", false);
cheer_47 = Fn((V _self158, int _argc159, V t_165, V X_166, V ex_167, V _a164, V[] _rest160) => {
V B_168 = default;
V L_169 = default;
V Q_170 = default;
if (_self158.IsNullish) _self158 = GlobalV;
B_168 = Get(t_165, "B");
L_169 = (Get(B_168, "lift") is var _t171 && Truthy(_t171) ? _t171 : ((V)(0D)));
Q_170 = (Get(B_168, "sq") is var _t172 && Truthy(_t172) ? _t172 : ((V)(0D)));
Invoke(t_165, "to", ((V)(260D)), Call(o_21, V.Undef, NewObj(13).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("hLx", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hLy", ((V)((-4D)))).Put("hRy", ((V)((-4D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(1D))).Put("wide", ((V)(0.4))).Put("sq", ((V)((ToNum(Q_170) - 0.04)))).Put("frown", ((V)(0D))).V, (ex_167 is var _t173 && Truthy(_t173) ? _t173 : NewObj(0).V), Get(X_166, "cheer")), ((V)("o")));
if (Truthy(Get(X_166, "cheerFx"))) {
InvokeSpread(t_165, "fx", new ArrBuilder().Spread(Get(X_166, "cheerFx")).V);
} else {
Invoke(t_165, "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
}
Invoke(Invoke(Invoke(Invoke(t_165, "to", ((V)(150D)), NewObj(2).Put("lift", Add(L_169, ((V)(5D)))).Put("sq", ((V)((ToNum(Q_170) - 0.08)))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(2).Put("lift", L_169).Put("sq", Add(Q_170, ((V)(0.06)))).V, ((V)("i"))), "to", ((V)(150D)), NewObj(1).Put("sq", Q_170).V, ((V)("o"))), "osc", ((V)(800D)), ((V)(3D)), NewObj(2).Put("armL", ((V)(130D))).Put("armR", ((V)(165D))).V, NewObj(2).Put("armL", ((V)(165D))).Put("armR", ((V)(130D))).V, ((V)("io")));
return Invoke(t_165, "back", ((V)(420D)));
return default;
}, 3, "cheer", false);
frown_48 = Fn((V _self174, int _argc175, V t_181, V _a178, V _a179, V _a180, V[] _rest176) => {
V B_182 = default;
V Q_183 = default;
if (_self174.IsNullish) _self174 = GlobalV;
B_182 = Get(t_181, "B");
Q_183 = (Get(B_182, "sq") is var _t184 && Truthy(_t184) ? _t184 : ((V)(0D)));
Invoke(Invoke(Invoke(Invoke(t_181, "to", ((V)(240D)), NewObj(6).Put("frown", ((V)(0.5))).Put("wide", ((V)(0.6))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).Put("sq", Add(Q_183, ((V)(0.05)))).Put("pitch", ((V)((ToNum((Get(B_182, "pitch") is var _t185 && Truthy(_t185) ? _t185 : ((V)(0D)))) - 0.1)))).V, ((V)("o"))), "wait", ((V)(600D))), "to", ((V)(260D)), NewObj(7).Put("frown", ((V)(0D))).Put("sqz", ((V)(0.6))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).Put("wide", ((V)(0D))).Put("open", ((V)(0.25))).Put("mw", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(3D)), NewObj(1).Put("sq", Add(Q_183, ((V)(0.03)))).V, NewObj(1).Put("sq", Q_183).V, ((V)("o")));
return Invoke(t_181, "back", ((V)(380D)));
return default;
}, 1, "frown", false);
kickCore_50 = Fn((V _self186, int _argc187, V t_193, V X_194, V _a191, V _a192, V[] _rest188) => {
V ks_195 = default;
V hit_196 = default;
if (_self186.IsNullish) _self186 = GlobalV;
ks_195 = (Get(X_194, "ks") is var _t197 && Truthy(_t197) ? _t197 : ((V)("foot")));
hit_196 = V.Undef;
if (SEqS(ks_195, "head")) {
Invoke(Invoke(t_193, "to", ((V)(300D)), NewObj(4).Put("pitch", ((V)(0.12))).Put("lean", ((V)((-1D)))).Put("sq", ((V)(0.08))).Put("lift", ((V)((-0.6)))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(5).Put("pitch", ((V)((-0.34)))).Put("lean", ((V)(1.6))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(2.4))).Put("close", ((V)(1D))).V, ((V)("o")));
hit_196 = Get(t_193, "t");
Invoke(Invoke(t_193, "fx", ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(260D)), NewObj(5).Put("pitch", ((V)(0D))).Put("lean", ((V)(0.4))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).Put("close", ((V)(0D))).V, ((V)("io")));
} else {
if (SEqS(ks_195, "tail")) {
Invoke(Invoke(t_193, "to", ((V)(320D)), NewObj(4).Put("spin", ((V)((-40D)))).Put("sq", ((V)(0.06))).Put("wag", ((V)((-20D)))).Put("tsw", ((V)((-0.6)))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(4).Put("spin", ((V)(150D))).Put("wag", ((V)(34D))).Put("tsw", ((V)(1D))).Put("sq", ((V)((-0.04)))).V, ((V)("o")));
hit_196 = ((V)((ToNum(Get(t_193, "t")) - 80D)));
Invoke(Invoke(t_193, "fx", ((V)("splash")), ((V)("body")), ((V)(2D))), "to", ((V)(420D)), NewObj(4).Put("spin", ((V)(0D))).Put("wag", ((V)(0D))).Put("tsw", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
} else {
if (SEqS(ks_195, "body")) {
Invoke(Invoke(t_193, "to", ((V)(320D)), NewObj(4).Put("x", ((V)((-1.6)))).Put("tilt", ((V)((-6D)))).Put("sq", ((V)(0.1))).Put("lean", ((V)((-0.8)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(5).Put("x", ((V)(2.4))).Put("tilt", ((V)(8D))).Put("sq", ((V)((-0.08)))).Put("lean", ((V)(1.4))).Put("lift", ((V)(2D))).V, ((V)("o")));
hit_196 = Get(t_193, "t");
Invoke(Invoke(t_193, "fx", ((V)("dust")), ((V)("belly")), ((V)(3D))), "to", ((V)(300D)), NewObj(5).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("sq", ((V)(0.04))).Put("lean", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("i")));
} else {
if (SEqS(ks_195, "flip")) {
Invoke(Invoke(t_193, "to", ((V)(320D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)((-6D))), ((V)((-2D)))), NewObj(3).Put("armR", ((V)(70D))).Put("lean", ((V)((-0.8)))).Put("tilt", ((V)((-3D)))).V), ((V)("io"))), "to", ((V)(150D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(10D)), ((V)(4D))), NewObj(4).Put("armR", ((V)(18D))).Put("lean", ((V)(1.2))).Put("tilt", ((V)(4D))).Put("sq", ((V)((-0.04)))).V), ((V)("o")));
hit_196 = Get(t_193, "t");
Invoke(t_193, "to", ((V)(300D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D))), NewObj(4).Put("armR", ((V)(20D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("sq", ((V)(0D))).V), ((V)("io")));
} else {
Invoke(Invoke(t_193, "to", ((V)(300D)), NewObj(6).Put("lean", ((V)((-1D)))).Put("footR", ((V)(0.4))).Put("armL", ((V)(50D))).Put("armR", ((V)(4D))).Put("sq", ((V)(0.06))).Put("tilt", ((V)((-2D)))).V, ((V)("io"))), "to", ((V)(130D)), NewObj(7).Put("lean", ((V)(1.4))).Put("footR", ((V)(3.6))).Put("armL", ((V)(10D))).Put("armR", ((V)(64D))).Put("sq", ((V)((-0.05)))).Put("lift", ((V)(1.4))).Put("tilt", ((V)(3D))).V, ((V)("o")));
hit_196 = ((V)((ToNum(Get(t_193, "t")) - 30D)));
Invoke(Invoke(t_193, "fx", ((V)("dust")), ((V)("footR")), ((V)(3D))), "to", ((V)(280D)), NewObj(7).Put("footR", ((V)(0D))).Put("lean", ((V)(0.3))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.03))).Put("tilt", ((V)(0D))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io")));
}
}
}
}
return hit_196;
return default;
}, 2, "kickCore", false);
kickMove_51 = Fn((V _self198, int _argc199, V X_205, V _a202, V _a203, V _a204, V[] _rest200) => {
V t_206 = default;
V hit_207 = default;
V st_208 = default;
if (_self198.IsNullish) _self198 = GlobalV;
t_206 = Call(TL_12, V.Undef, REST_11);
Set(t_206, "B", Call(o_21, V.Undef, REST_11));
Invoke(t_206, "to", ((V)(320D)), NewObj(6).Put("lx", ((V)(0.7))).Put("ly", ((V)(0.6))).Put("pitch", ((V)((-0.1)))).Put("sqz", ((V)(0.3))).Put("smile", ((V)(0.8))).Put("hap", ((V)(0.5))).V, ((V)("io")));
hit_207 = Call(kickCore_50, V.Undef, t_206, X_205);
Invoke(Invoke(t_206, "to", ((V)(320D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-15D)))), NewObj(8).Put("armR", ((V)(118D))).Put("lx", ((V)(0.9))).Put("ly", ((V)((-0.3)))).Put("htilt", ((V)(6D))).Put("wide", ((V)(0.5))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.6))).Put("sqz", ((V)(0D))).V), ((V)("io"))), "wait", ((V)(700D)));
Invoke(Invoke(Invoke(t_206, "to", ((V)(240D)), Call(o_21, V.Undef, NewObj(13).Put("armR", ((V)(150D))).Put("armL", ((V)(150D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)((-4D)))).Put("hLy", ((V)((-4D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("sqz", ((V)(0.7))).Put("open", ((V)(0.4))).Put("mw", ((V)(1D))).Put("htilt", ((V)(0D))).Put("wide", ((V)(0D))).Put("lx", ((V)(0.4))).V, Get(X_205, "cheer")), ((V)("o"))), "to", ((V)(140D)), NewObj(2).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.06)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i")));
Invoke(t_206, "back", ((V)(420D)));
st_208 = Invoke(t_206, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(180D))).V);
Set(st_208, "hit", hit_207);
return st_208;
return default;
}, 1, "kickMove", false);
dishProp_58 = Fn((V _self209, int _argc210, V st_216, V _a213, V _a214, V _a215, V[] _rest211) => {
V R0_217 = default;
if (_self209.IsNullish) _self209 = GlobalV;
R0_217 = Get(st_216, "rec");
return Fn((V _self209, int _argc218, V I_224, V tt_225, V _a222, V _a223, V[] _rest219) => {
V W_226 = default;
V f0_227 = default;
double tl_228 = 0;
V gx_229 = default;
V gy_230 = default;
V sx_231 = default;
double sy_232 = 0;
V Sk_233 = default;
V done_234 = default;
V cur_235 = default;
V last_236 = default;
V scr_237 = default;
V dirt_238 = default;
V h_239 = default;
W_226 = Get(I_224, "W");
if (((!(Truthy(W_226)) || !(Truthy(Call(okp_35, V.Undef, Get(W_226, "pawL"))))) || !(Truthy(Call(okp_35, V.Undef, Get(W_226, "pawR")))))) {
return ((V)(""));
}
f0_227 = Call(facing_27, V.Undef, I_224);
if (LtN(f0_227, 0.02)) {
return ((V)(""));
}
tl_228 = (ToNum(tt_225) % ToNum(Get(st_216, "loop")));
{ V _t240 = Call(g0_42, V.Undef, I_224);
{ V _t241 = ListOf(_t240);
{ V _t242 = GetIdx(_t241, 0D);
gx_229 = _t242; }
{ V _t243 = GetIdx(_t241, 1D);
gy_230 = _t243; }
} }
sx_231 = Add(Call(rside_25, V.Undef, I_224, gx_229), ((V)(4D)));
sy_232 = (ToNum(gy_230) - 22D);
Sk_233 = (Get(R0_217, "st") is var _t244 && Truthy(_t244) ? _t244 : Arr());
done_234 = Get(Invoke(Sk_233, "filter", Fn((V _self209, int _argc245, V q_251, V _a248, V _a249, V _a250, V[] _rest246) => {
return (Ge(((V)(tl_228)), GetIdx(q_251, 1D)) ? V.True : V.False);
}, 1, "", true)), "length");
cur_235 = Invoke(Sk_233, "find", Fn((V _self209, int _argc252, V q_258, V _a255, V _a256, V _a257, V[] _rest253) => {
return ((Ge(((V)(tl_228)), GetIdx(q_258, 0D)) && Lt(((V)(tl_228)), Add(GetIdx(q_258, 1D), ((V)(500D))))) ? V.True : V.False);
}, 1, "", true));
last_236 = ((V)(0D));
Invoke(Sk_233, "forEach", Fn((V _self209, int _argc259, V q_265, V _a262, V _a263, V _a264, V[] _rest260) => {
if (Ge(((V)(tl_228)), GetIdx(q_265, 1D))) {
last_236 = GetIdx(q_265, 1D);
}
return default;
}, 1, "", true));
scr_237 = ((V)(0D));
Invoke((Get(R0_217, "sc") is var _t277 && Truthy(_t277) ? _t277 : Arr()), "forEach", Fn((V _self209, int _argc266, V _a268, V _a269, V _a270, V _a271, V[] _rest267) => {
V a_274 = default;
V b_276 = default;
{ V _t272 = ListOf(_a268);
{ V _t273 = GetIdx(_t272, 0D);
a_274 = _t273; }
{ V _t275 = GetIdx(_t272, 1D);
b_276 = _t275; }
}
if ((Gt(b_276, last_236) && LtN(a_274, tl_228))) {
scr_237 = Add(scr_237, Call(cl_29, V.Undef, ((V)(((Min(tl_228, ToNum(b_276)) - Max(ToNum(a_274), ToNum(last_236))) / (ToNum(b_276) - ToNum(a_274))))), ((V)(0D)), ((V)(1D))));
}
return default;
}, 1, "", true));
dirt_238 = Call(cl_29, V.Undef, ((V)((1D - (ToNum(scr_237) * 0.75)))), ((V)(0D)), ((V)(1D)));
h_239 = ((V)(""));
{
double i_278 = 0;
i_278 = 0D;
while (true) {
if (!(Lt(((V)(i_278)), done_234))) break;
h_239 = Add(h_239, Call(G_26, V.Undef, sx_231, ((V)((sy_232 - (i_278 * 1.8)))), ((V)(0D)), ((V)(2.3)), Call(PLATE_56, V.Undef, ((V)(0D)))));
i_278++;
}
}
if (Truthy((cur_235 is var _t280 && !Truthy(_t280) ? _t280 : (Lt(((V)(tl_228)), GetIdx(cur_235, 1D)) ? V.True : V.False)))) {
V u_281 = default;
u_281 = Call(ss_28, V.Undef, ((V)(((tl_228 - ToNum(GetIdx(cur_235, 0D))) / (ToNum(GetIdx(cur_235, 1D)) - ToNum(GetIdx(cur_235, 0D)))))));
h_239 = Add(h_239, Call(G_26, V.Undef, Call(lerp_34, V.Undef, GetIdx(Get(W_226, "pawL"), 0D), sx_231, u_281), Call(lerp_34, V.Undef, ((V)((ToNum(GetIdx(Get(W_226, "pawL"), 1D)) - 1D))), ((V)((sy_232 - (ToNum(done_234) * 1.8)))), u_281), ((V)(0D)), ((V)(2.3)), Call(PLATE_56, V.Undef, ((V)(0D))), f0_227));
} else {
V fi_282 = default;
fi_282 = (Truthy(cur_235) ? Call(ss_28, V.Undef, ((V)((((tl_228 - ToNum(GetIdx(cur_235, 1D))) - 200D) / 300D)))) : ((V)(1D)));
if (GtN(fi_282, 0.02)) {
h_239 = Add(h_239, Call(G_26, V.Undef, GetIdx(Get(W_226, "pawL"), 0D), ((V)((ToNum(GetIdx(Get(W_226, "pawL"), 1D)) - 1D))), ((V)((-8D))), ((V)((2.3 * (0.6 + (0.4 * ToNum(fi_282)))))), Call(PLATE_56, V.Undef, dirt_238), ((V)((ToNum(f0_227) * ToNum(fi_282))))));
}
}
return Add(h_239, Call(G_26, V.Undef, GetIdx(Get(W_226, "pawR"), 0D), ((V)((ToNum(GetIdx(Get(W_226, "pawR"), 1D)) - 1D))), ((V)(10D)), ((V)(2.1)), SPONGE_57, f0_227));
return default;
}, 2, "", true);
return default;
}, 1, "dishProp", false);
grillProp_63 = Fn((V _self283, int _argc284, V st_290, V _a287, V _a288, V _a289, V[] _rest285) => {
V R0_291 = default;
double TL0_292 = 0;
double an_293 = 0;
if (_self283.IsNullish) _self283 = GlobalV;
R0_291 = Get(st_290, "rec");
TL0_292 = (13D * 1.75);
an_293 = (((-14D) * System.Math.PI) / 180D);
return Fn((V _self283, int _argc294, V I_300, V tt_301, V _a298, V _a299, V[] _rest295) => {
V W_302 = default;
V f0_303 = default;
double tl_304 = 0;
V p_305 = default;
V tip_306 = default;
V gy_307 = default;
V ck_308 = default;
V sv_309 = default;
V fl_310 = default;
V h_311 = default;
W_302 = Get(I_300, "W");
if ((!(Truthy(W_302)) || !(Truthy(Call(okp_35, V.Undef, Get(W_302, "pawR")))))) {
return ((V)(""));
}
f0_303 = Call(facing_27, V.Undef, I_300);
if (LtN(f0_303, 0.02)) {
return ((V)(""));
}
tl_304 = (ToNum(tt_301) % ToNum(Get(st_290, "loop")));
p_305 = Get(W_302, "pawR");
tip_306 = Arr(Add(GetIdx(p_305, 0D), ((V)((TL0_292 * FdLibm.Cos(an_293))))), Add(GetIdx(p_305, 1D), ((V)((TL0_292 * FdLibm.Sin(an_293))))));
gy_307 = Add(GetIdx(p_305, 1D), ((V)(5D)));
ck_308 = Call(cl_29, V.Undef, ((V)((tl_304 / (ToNum(Get(st_290, "loop")) * 0.8)))), ((V)(0D)), ((V)(1D)));
sv_309 = Invoke((Get(R0_291, "sv") is var _t319 && Truthy(_t319) ? _t319 : Arr()), "find", Fn((V _self283, int _argc312, V q_318, V _a315, V _a316, V _a317, V[] _rest313) => {
return ((Ge(((V)(tl_304)), GetIdx(q_318, 0D)) && Lt(((V)(tl_304)), Add(GetIdx(q_318, 1D), ((V)(300D))))) ? V.True : V.False);
}, 1, "", true));
fl_310 = Invoke((Get(R0_291, "fl") is var _t327 && Truthy(_t327) ? _t327 : Arr()), "find", Fn((V _self283, int _argc320, V a_326, V _a323, V _a324, V _a325, V[] _rest321) => {
return ((Ge(((V)(tl_304)), a_326) && Lt(((V)(tl_304)), Add(a_326, ((V)(800D))))) ? V.True : V.False);
}, 1, "", true));
h_311 = Call(G_26, V.Undef, Add(GetIdx(tip_306, 0D), ((V)(12D))), gy_307, ((V)(0D)), ((V)(2D)), Call(PATTY_62, V.Undef, ((V)((ToNum(ck_308) * 0.8)))), f0_303);
if (Truthy(sv_309)) {
h_311 = Add(h_311, Call(G_26, V.Undef, GetIdx(tip_306, 0D), Add(GetIdx(tip_306, 1D), ((V)(0.6))), ((V)(0D)), ((V)(2D)), Call(PATTY_62, V.Undef, ((V)(1D))), f0_303));
} else {
if (!fl_310.IsNullish) {
double u_328 = 0;
u_328 = ((tl_304 - ToNum(fl_310)) / 800D);
h_311 = Add(h_311, Call(G_26, V.Undef, Add(GetIdx(tip_306, 0D), ((V)(1D))), ((V)((ToNum(Call(lerp_34, V.Undef, Add(GetIdx(tip_306, 1D), ((V)(1D))), gy_307, ((V)(u_328)))) - (FdLibm.Sin((System.Math.PI * u_328)) * 16D)))), ((V)((360D * ToNum(Call(ss_28, V.Undef, ((V)(u_328))))))), ((V)(2D)), Call(PATTY_62, V.Undef, ck_308), f0_303));
} else {
h_311 = Add(h_311, Call(G_26, V.Undef, Add(GetIdx(tip_306, 0D), ((V)(1D))), gy_307, ((V)(0D)), ((V)(2D)), Call(PATTY_62, V.Undef, ck_308), f0_303));
}
}
return Add(Call(G_26, V.Undef, GetIdx(p_305, 0D), GetIdx(p_305, 1D), ((V)((-14D))), ((V)(1.75)), TONGS_61, f0_303), h_311);
return default;
}, 2, "", true);
return default;
}, 1, "grillProp", false);
toastMove_67 = Fn((V _self329, int _argc330, V X_336, V _a333, V _a334, V _a335, V[] _rest331) => {
V t_337 = default;
V c_338 = default;
V st_339 = default;
if (_self329.IsNullish) _self329 = GlobalV;
t_337 = Call(TL_12, V.Undef, TW0_64);
Set(t_337, "B", Call(o_21, V.Undef, REST_11, TW0_64));
Invoke(Invoke(t_337, "to", ((V)(90D)), NewObj(9).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.5))).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.08)))).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).Put("lx", ((V)(0.9))).Put("ly", ((V)((-0.6)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i")));
Invoke(t_337, "to", ((V)(260D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(9D)), ((V)((-11D)))), NewObj(4).Put("armL", ((V)(56D))).Put("armR", ((V)(56D))).Put("ly", ((V)((-0.4)))).Put("lx", ((V)(0.3))).V), ((V)("io")));
c_338 = Get(t_337, "t");
Invoke(t_337, "to", ((V)(120D)), NewObj(1).Put("sq", ((V)(0.06))).V, ((V)("i")));
Invoke(Invoke(t_337, "osc", ((V)(1000D)), ((V)(5D)), NewObj(4).Put("hLx", ((V)(12D))).Put("hRx", ((V)((-6D)))).Put("sqz", ((V)(0.8))).Put("tilt", ((V)(2D))).V, NewObj(3).Put("hLx", ((V)(6D))).Put("hRx", ((V)((-12D)))).Put("tilt", ((V)((-2D)))).V, ((V)("l"))), "fx", ((V)("sweat")), ((V)("head")), ((V)(1D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_337, "to", ((V)(200D)), NewObj(5).Put("puff", ((V)(0.8))).Put("open", ((V)(0D))).Put("sqz", ((V)(0D))).Put("ly", ((V)(0.3))).Put("lx", ((V)(0D))).V), "to", ((V)(160D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).Put("mw", ((V)(0.45))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("mouth")), ((V)(1D))), "to", ((V)(200D)), NewObj(2).Put("puff", ((V)(0.7))).Put("open", ((V)(0D))).V), "to", ((V)(160D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("mouth")), ((V)(1D)));
Invoke(Invoke(Invoke(t_337, "to", ((V)(260D)), Call(o_21, V.Undef, NewObj(7).Put("sqz", ((V)(0.7))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("mw", ((V)(1D))).Put("wide", ((V)(0D))).Put("tilt", ((V)(0D))).V, Get(X_336, "cheer")), ((V)("o"))), "fx", ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(300D)));
st_339 = Invoke(t_337, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(160D))).V);
Set(st_339, "prop", Fn((V _self329, int _argc340, V I_346, V tt_347, V _a344, V _a345, V[] _rest341) => {
V W_348 = default;
double f0_349 = 0;
V m_350 = default;
V gx_351 = default;
V s0_352 = default;
V x_353 = default;
double y_354 = 0;
double r_355 = 0;
W_348 = Get(I_346, "W");
if ((!(Truthy(W_348)) || !(Truthy(Call(okp_35, V.Undef, Get(W_348, "pawR")))))) {
return ((V)(""));
}
f0_349 = Max(0.35, ToNum(Call(facing_27, V.Undef, I_346)));
m_350 = Call(mid_43, V.Undef, W_348);
{ V _t356 = Call(g0_42, V.Undef, I_346);
{ V _t357 = ListOf(_t356);
{ V _t358 = GetIdx(_t357, 0D);
gx_351 = _t358; }
} }
s0_352 = Arr(Add(Call(rside_25, V.Undef, I_346, gx_351), ((V)(2D))), ((V)((ToNum(GetIdx(Get(W_348, "pawR"), 1D)) - 8D))));
x_353 = GetIdx(m_350, 0D);
y_354 = (ToNum(GetIdx(m_350, 1D)) - 3D);
r_355 = 0D;
if (Lt(tt_347, c_338)) {
V u_359 = default;
u_359 = Call(cl_29, V.Undef, ((V)((ToNum(tt_347) / ToNum(c_338)))), ((V)(0D)), ((V)(1D)));
x_353 = Call(lerp_34, V.Undef, GetIdx(s0_352, 0D), GetIdx(m_350, 0D), u_359);
y_354 = (ToNum(Call(lerp_34, V.Undef, GetIdx(s0_352, 1D), ((V)((ToNum(GetIdx(m_350, 1D)) - 3D))), u_359)) - (FdLibm.Sin((System.Math.PI * ToNum(u_359))) * 24D));
r_355 = (400D * ToNum(u_359));
}
return Call(G_26, V.Undef, x_353, ((V)(y_354)), ((V)(r_355)), ((V)(2.6)), TOAST_66, ((V)(f0_349)));
return default;
}, 2, "", true));
return st_339;
return default;
}, 1, "toastMove", false);
splashIn_71 = Fn((V _self360, int _argc361, V B_367, V P_368, V _a365, V _a366, V[] _rest362) => {
V t_369 = default;
V v_370 = default;
if (_self360.IsNullish) _self360 = GlobalV;
t_369 = Call(TL_12, V.Undef, REST_11);
Set(t_369, "B", Call(o_21, V.Undef, REST_11));
if (SEqS(Get(P_368, "dn"), "float")) {
Invoke(Invoke(t_369, "to", ((V)(300D)), NewObj(2).Put("lift", ((V)(6D))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(500D)), Call(o_21, V.Undef, B_367, NewObj(1).Put("lift", ((V)(0D))).V), ((V)("s")));
} else {
Invoke(Invoke(Invoke(Invoke(t_369, "to", ((V)(160D)), NewObj(3).Put("sq", ((V)(0.12))).Put("armL", ((V)((-6D)))).Put("armR", ((V)((-6D)))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(5).Put("lift", ((V)(8D))).Put("sq", ((V)((-0.1)))).Put("footR", ((V)(2.4))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)("o"))), "to", ((V)(220D)), Call(o_21, V.Undef, B_367, NewObj(2).Put("lift", ((V)(0D))).Put("sq", Add((Get(B_367, "sq") is var _t371 && Truthy(_t371) ? _t371 : ((V)(0D))), ((V)(0.1)))).V), ((V)("i"))), "fx", ((V)("splash")), ((V)("body")), ((V)(7D)));
}
v_370 = NewObj(0).V;
Invoke(Call(K_37, V.Undef, B_367), "forEach", Fn((V _self360, int _argc372, V p_378, V _a375, V _a376, V _a377, V[] _rest373) => {
return SetK(v_370, p_378, GetK(B_367, p_378));
}, 1, "", true));
Invoke(t_369, "to", ((V)(220D)), v_370, ((V)("io")));
return Invoke(t_369, "out", NewObj(2).Put("next", ((V)("splash"))).Put("blend", ((V)(180D))).V);
return default;
}, 2, "splashIn", false);
splashOut_72 = Fn((V _self379, int _argc380, V B_386, V _a383, V _a384, V _a385, V[] _rest381) => {
V t_387 = default;
V z_388 = default;
if (_self379.IsNullish) _self379 = GlobalV;
t_387 = Call(TL_12, V.Undef, B_386);
Set(t_387, "B", Call(o_21, V.Undef, REST_11, B_386));
Invoke(Invoke(Invoke(t_387, "to", ((V)(300D)), NewObj(6).Put("wd", ((V)(0.2))).Put("sk", ((V)(1D))).Put("lift", ((V)(1D))).Put("sq", ((V)((-0.04)))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(6).Put("lift", ((V)(8D))).Put("wd", ((V)(0D))).Put("sk", ((V)(0D))).Put("sit", ((V)(0D))).Put("footL", ((V)(2D))).Put("sq", ((V)((-0.08)))).V, ((V)("o"))), "fx", ((V)("drop")), ((V)("body")), ((V)(5D)));
z_388 = NewObj(0).V;
Invoke(Call(K_37, V.Undef, B_386), "forEach", Fn((V _self379, int _argc389, V p_395, V _a392, V _a393, V _a394, V[] _rest390) => {
return SetK(z_388, p_395, (GetK(REST_11, p_395) is var _t396 && Truthy(_t396) ? _t396 : ((V)(0D))));
}, 1, "", true));
Invoke(Invoke(Invoke(Invoke(Invoke(t_387, "to", ((V)(240D)), Call(o_21, V.Undef, z_388, NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).V), ((V)("i"))), "to", ((V)(140D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(5D)), NewObj(3).Put("x", ((V)(1.2))).Put("tilt", ((V)(5D))).Put("sqz", ((V)(0.8))).V, NewObj(3).Put("x", ((V)((-1.2)))).Put("tilt", ((V)((-5D)))).Put("sqz", ((V)(0.8))).V, ((V)("l"))), "fx", ((V)("drop")), ((V)("body")), ((V)(6D))), "to", ((V)(200D)), NewObj(5).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("sqz", ((V)(0D))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.8))).V, ((V)("o")));
Invoke(t_387, "back", ((V)(260D)));
return Invoke(t_387, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(160D))).V);
return default;
}, 1, "splashOut", false);
shellMove_73 = Fn((V _self397, int _argc398, V X_404, V _a401, V _a402, V _a403, V[] _rest399) => {
V t_405 = default;
V g_406 = default;
V k_407 = default;
V st_408 = default;
if (_self397.IsNullish) _self397 = GlobalV;
t_405 = Call(TL_12, V.Undef, REST_11);
Set(t_405, "B", Call(o_21, V.Undef, REST_11));
Invoke(Invoke(Invoke(t_405, "to", ((V)(300D)), NewObj(4).Put("lx", ((V)(0.4))).Put("ly", ((V)(0.9))).Put("pitch", ((V)((-0.16)))).Put("wide", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(380D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)((-2D))), ((V)(10D))), NewObj(6).Put("pitch", ((V)((-0.42)))).Put("ly", ((V)(1D))).Put("sq", ((V)(0.1))).Put("lean", ((V)(0.5))).Put("armR", ((V)(12D))).Put("tilt", ((V)(2D))).V), ((V)("io"))), "wait", ((V)(160D)));
g_406 = Get(t_405, "t");
Invoke(Invoke(Invoke(Invoke(Invoke(t_405, "to", ((V)(160D)), NewObj(1).Put("sqz", ((V)(0.3))).V), "to", ((V)(420D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-10D)))), NewObj(12).Put("armR", ((V)(48D))).Put("pitch", ((V)(0.08))).Put("ly", ((V)((-0.1)))).Put("lx", ((V)(0.3))).Put("sq", ((V)(0D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("wide", ((V)(0.8))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.6))).Put("htilt", ((V)(8D))).Put("sqz", ((V)(0D))).V), ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(2).Put("htilt", ((V)((-6D)))).Put("lx", ((V)((-0.3)))).V, ((V)("io"))), "wait", ((V)(300D)));
Invoke(Invoke(Invoke(Invoke(t_405, "to", ((V)(380D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(3D)), ((V)((-16D)))), NewObj(7).Put("armR", ((V)(112D))).Put("htilt", ((V)((-12D)))).Put("close", ((V)(0.7))).Put("smile", ((V)(1D))).Put("open", ((V)(0D))).Put("wide", ((V)(0D))).Put("mw", ((V)(1D))).V), ((V)("io"))), "fx", ((V)("note")), ((V)("head")), ((V)(1D))), "wait", ((V)(900D))), "fx", ((V)("bubble")), ((V)("head")), ((V)(1D)));
Invoke(t_405, "to", ((V)(360D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(8D)), ((V)(3D))), NewObj(7).Put("armL", ((V)(18D))).Put("armR", ((V)(18D))).Put("htilt", ((V)(0D))).Put("close", ((V)(0.4))).Put("blush", ((V)(0.7))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, Get(X_404, "cheer")), ((V)("io")));
k_407 = Get(t_405, "t");
Invoke(Invoke(t_405, "fx", ((V)("heart")), ((V)("head")), ((V)(2D))), "osc", ((V)(700D)), ((V)(3D)), NewObj(2).Put("sq", ((V)(0.04))).Put("tilt", ((V)(2D))).V, NewObj(2).Put("sq", ((V)(0D))).Put("tilt", ((V)((-2D)))).V, ((V)("s")));
Invoke(Invoke(t_405, "to", ((V)(140D)), NewObj(2).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.06)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i")));
Invoke(t_405, "back", ((V)(420D)));
st_408 = Invoke(t_405, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(180D))).V);
Set(st_408, "prop", Fn((V _self397, int _argc409, V I_415, V tt_416, V _a413, V _a414, V[] _rest410) => {
V W_417 = default;
double f0_418 = 0;
V Bp_419 = default;
V x_420 = default;
V y_421 = default;
double op_422 = 0;
W_417 = Get(I_415, "W");
if (((!(Truthy(W_417)) || !(Truthy(Call(okp_35, V.Undef, Get(W_417, "pawR"))))) || Lt(tt_416, g_406))) {
return ((V)(""));
}
f0_418 = Max(0.3, ToNum(Call(facing_27, V.Undef, I_415)));
Bp_419 = (Truthy(Call(okp_35, V.Undef, Get(W_417, "belly"))) ? Get(W_417, "belly") : Arr(((V)(50D)), ((V)(80D))));
x_420 = GetIdx(Get(W_417, "pawR"), 0D);
y_421 = ((V)((ToNum(GetIdx(Get(W_417, "pawR"), 1D)) - 2.5)));
op_422 = f0_418;
if (Gt(tt_416, k_407)) {
V u_423 = default;
u_423 = Call(ss_28, V.Undef, ((V)(((ToNum(tt_416) - ToNum(k_407)) / 600D))));
x_420 = Call(lerp_34, V.Undef, x_420, GetIdx(Bp_419, 0D), u_423);
y_421 = Call(lerp_34, V.Undef, y_421, GetIdx(Bp_419, 1D), u_423);
op_422 = (op_422 * (1D - ToNum(Call(ss_28, V.Undef, ((V)((((ToNum(tt_416) - ToNum(k_407)) - 400D) / 500D)))))));
}
return ((op_422 < 0.02) ? ((V)("")) : Call(G_26, V.Undef, x_420, y_421, ((V)((-10D))), ((V)(2.4)), (Get(ICON_20, "shell") is var _t424 && Truthy(_t424) ? _t424 : Get(ICON_20, "star")), ((V)(op_422))));
return default;
}, 2, "", true));
return st_408;
return default;
}, 1, "shellMove", false);
puckProp_89 = Fn((V _self425, int _argc426, V st_432, V col_433, V pong_434, V _a431, V[] _rest427) => {
V R0_435 = default;
V PD_436 = default;
if (_self425.IsNullish) _self425 = GlobalV;
R0_435 = Get(st_432, "rec");
PD_436 = (Truthy(pong_434) ? Call(PPAD_88, V.Undef, col_433) : Call(PADDLE_87, V.Undef, col_433));
return Fn((V _self425, int _argc437, V I_443, V tt_444, V _a441, V _a442, V[] _rest438) => {
V W_445 = default;
double f0_446 = 0;
double tl_447 = 0;
V p_448 = default;
V HS_449 = default;
V h0_450 = default;
V h1_451 = default;
double Tm_452 = 0;
double FAR_453 = 0;
double T_454 = 0;
V d_455 = default;
double op_456 = 0;
double u_457 = 0;
V h_458 = default;
W_445 = Get(I_443, "W");
if ((!(Truthy(W_445)) || !(Truthy(Call(okp_35, V.Undef, Get(W_445, "pawR")))))) {
return ((V)(""));
}
f0_446 = Max(0.4, ToNum(Call(facing_27, V.Undef, I_443)));
tl_447 = (ToNum(tt_444) % ToNum(Get(st_432, "loop")));
p_448 = Get(W_445, "pawR");
HS_449 = Invoke(Invoke((Get(R0_435, "h") is var _t467 && Truthy(_t467) ? _t467 : Arr()), "slice"), "sort", Fn((V _self425, int _argc459, V a_465, V b_466, V _a463, V _a464, V[] _rest460) => {
return ((V)((ToNum(a_465) - ToNum(b_466))));
}, 2, "", true));
h0_450 = V.Null;
h1_451 = V.Null;
Invoke(HS_449, "forEach", Fn((V _self425, int _argc468, V v_474, V _a471, V _a472, V _a473, V[] _rest469) => {
if (LeN(v_474, tl_447)) {
h0_450 = v_474;
} else {
if (h1_451.IsNullish) {
h1_451 = v_474;
}
}
return default;
}, 1, "", true));
Tm_452 = (Truthy(pong_434) ? 300D : 450D);
FAR_453 = (Truthy(pong_434) ? 34D : 30D);
T_454 = ((!h0_450.IsNullish && !h1_451.IsNullish) ? Min(Tm_452, ((ToNum(h1_451) - ToNum(h0_450)) / 2D)) : Tm_452);
d_455 = ((V)(5D));
op_456 = 1D;
if (!h0_450.IsNullish) {
d_455 = Call(lerp_34, V.Undef, ((V)(5D)), ((V)(FAR_453)), Call(ss_28, V.Undef, ((V)(((tl_447 - ToNum(h0_450)) / T_454)))));
}
if ((!h1_451.IsNullish && (tl_447 > (ToNum(h1_451) - T_454)))) {
d_455 = Call(lerp_34, V.Undef, ((V)(FAR_453)), ((V)(5D)), Call(ss_28, V.Undef, ((V)(((tl_447 - (ToNum(h1_451) - T_454)) / T_454)))));
}
if (((!h0_450.IsNullish && h1_451.IsNullish) && ((tl_447 - ToNum(h0_450)) > 1200D))) {
op_456 = (1D - ToNum(Call(ss_28, V.Undef, ((V)((((tl_447 - ToNum(h0_450)) - 1200D) / 300D))))));
}
u_457 = ((ToNum(d_455) - 5D) / (FAR_453 - 5D));
h_458 = ((V)(""));
if ((op_456 > 0.02)) {
h_458 = ((V)(string.Concat(new string[] { ToStr(h_458), "<g opacity=\"", ToStr(Call(r2_30, V.Undef, ((V)(op_456)))), "\">", ToStr((Truthy(pong_434) ? Call(ci_32, V.Undef, Call(r2_30, V.Undef, Add(GetIdx(p_448, 0D), d_455)), Call(r2_30, V.Undef, ((V)(((ToNum(GetIdx(p_448, 1D)) - 2D) - (System.Math.Abs(FdLibm.Sin(((System.Math.PI * 2D) * u_457))) * 5D))))), ((V)(1.6)), ((V)("#ffffff")), ((V)("#c9cfdb"))) : ((V)(string.Concat(new string[] { "<ellipse cx=\"", ToStr(Call(r2_30, V.Undef, Add(GetIdx(p_448, 0D), d_455))), "\" cy=\"", ToStr(Call(r2_30, V.Undef, Add(GetIdx(p_448, 1D), ((V)(2.5))))), "\" rx=\"4.2\" ry=\"1.6\" fill=\"#2a2a36\" stroke=\"#111\" stroke-width=\"0.3\"/>" }))))), "</g>" })));
}
return Add(h_458, Call(G_26, V.Undef, GetIdx(p_448, 0D), GetIdx(p_448, 1D), ((V)((Truthy(pong_434) ? (-20D) : 0D))), ((V)(2.4)), PD_436, ((V)(f0_446))));
return default;
}, 2, "", true);
return default;
}, 3, "puckProp", false);
cueProp_92 = Fn((V _self475, int _argc476, V st_482, V _a479, V _a480, V _a481, V[] _rest477) => {
if (_self475.IsNullish) _self475 = GlobalV;
return Fn((V _self475, int _argc483, V I_489, V tt_490, V _a487, V _a488, V[] _rest484) => {
V W_491 = default;
double f0_492 = 0;
double tl_493 = 0;
V a_494 = default;
V b_495 = default;
double dx_496 = 0;
double dy_497 = 0;
double d_498 = 0;
V s0_499 = default;
V tip_500 = default;
V L_501 = default;
V h_502 = default;
V S_503 = default;
V home_504 = default;
V bp_505 = default;
V op_506 = default;
W_491 = Get(I_489, "W");
if (((!(Truthy(W_491)) || !(Truthy(Call(okp_35, V.Undef, Get(W_491, "pawR"))))) || !(Truthy(Call(okp_35, V.Undef, Get(W_491, "pawL")))))) {
return ((V)(""));
}
f0_492 = Max(0.35, ToNum(Call(facing_27, V.Undef, I_489)));
tl_493 = (ToNum(tt_490) % ToNum(Get(st_482, "loop")));
a_494 = Get(W_491, "pawR");
b_495 = Get(W_491, "pawL");
dx_496 = (ToNum(GetIdx(b_495, 0D)) - ToNum(GetIdx(a_494, 0D)));
dy_497 = (ToNum(GetIdx(b_495, 1D)) - ToNum(GetIdx(a_494, 1D)));
d_498 = Hypot(dx_496, dy_497);
if ((d_498 < 4D)) {
dx_496 = (-1D);
dy_497 = 0.2;
d_498 = Hypot(dx_496, dy_497);
}
dx_496 = (dx_496 / d_498);
dy_497 = (dy_497 / d_498);
s0_499 = Arr(((V)((ToNum(GetIdx(a_494, 0D)) - (dx_496 * 16D)))), ((V)((ToNum(GetIdx(a_494, 1D)) - (dy_497 * 16D)))));
tip_500 = Arr(Add(GetIdx(b_495, 0D), ((V)((dx_496 * 14D)))), Add(GetIdx(b_495, 1D), ((V)((dy_497 * 14D)))));
L_501 = Fn((V _self475, int _argc507, V p_513, V q_514, V c_515, V w_516, V[] _rest508) => {
return ((V)(string.Concat(new string[] { "<path d=\"M", ToStr(Call(r2_30, V.Undef, GetIdx(p_513, 0D))), " ", ToStr(Call(r2_30, V.Undef, GetIdx(p_513, 1D))), "L", ToStr(Call(r2_30, V.Undef, GetIdx(q_514, 0D))), " ", ToStr(Call(r2_30, V.Undef, GetIdx(q_514, 1D))), "\" stroke=\"", ToStr(c_515), "\" stroke-width=\"", ToStr(w_516), "\" stroke-linecap=\"round\"/>" })));
}, 4, "", true);
h_502 = ((V)(string.Concat(new string[] { "<g opacity=\"", ToStr(Call(r2_30, V.Undef, ((V)(f0_492)))), "\">", ToStr(Call(L_501, V.Undef, s0_499, tip_500, ((V)("#8a5a2c")), ((V)(2.6)))), ToStr(Call(L_501, V.Undef, s0_499, tip_500, ((V)("#c98a52")), ((V)(1.7)))), ToStr(Call(L_501, V.Undef, s0_499, Arr(Add(GetIdx(s0_499, 0D), ((V)((dx_496 * 12D)))), Add(GetIdx(s0_499, 1D), ((V)((dy_497 * 12D))))), ((V)("#3b2a24")), ((V)(2.8)))), ToStr(Call(ci_32, V.Undef, Call(r2_30, V.Undef, GetIdx(tip_500, 0D)), Call(r2_30, V.Undef, GetIdx(tip_500, 1D)), ((V)(1.1)), ((V)("#5ab4f0")))), "</g>" })));
S_503 = Invoke(Invoke((Get(Get(st_482, "rec"), "sh") is var _t524 && Truthy(_t524) ? _t524 : Arr()), "filter", Fn((V _self475, int _argc517, V v_523, V _a520, V _a521, V _a522, V[] _rest518) => {
return (LeN(v_523, tl_493) ? V.True : V.False);
}, 1, "", true)), "pop");
home_504 = Arr(Add(GetIdx(tip_500, 0D), ((V)((dx_496 * 3.6)))), Add(GetIdx(tip_500, 1D), ((V)((dy_497 * 3.6)))));
bp_505 = home_504;
op_506 = ((V)(1D));
if ((!S_503.IsNullish && ((tl_493 - ToNum(S_503)) < 2200D))) {
double e_525 = 0;
e_525 = (tl_493 - ToNum(S_503));
if ((e_525 < 1300D)) {
V u_526 = default;
double v_527 = 0;
u_526 = Call(cl_29, V.Undef, ((V)((e_525 / 900D))), ((V)(0D)), ((V)(1D)));
v_527 = (1D - ((1D - ToNum(u_526)) * (1D - ToNum(u_526))));
bp_505 = Arr(Add(GetIdx(home_504, 0D), ((V)(((dx_496 * 40D) * v_527)))), Add(GetIdx(home_504, 1D), ((V)(((dy_497 * 40D) * v_527)))));
op_506 = ((V)((1D - ToNum(Call(ss_28, V.Undef, ((V)(((e_525 - 900D) / 400D))))))));
} else {
op_506 = Call(ss_28, V.Undef, ((V)(((e_525 - 1700D) / 500D))));
}
}
if (GtN(op_506, 0.02)) {
h_502 = ((V)(string.Concat(new string[] { ToStr(h_502), "<g opacity=\"", ToStr(Call(r2_30, V.Undef, op_506)), "\">", ToStr(Call(ci_32, V.Undef, Call(r2_30, V.Undef, GetIdx(bp_505, 0D)), Call(r2_30, V.Undef, GetIdx(bp_505, 1D)), ((V)(3D)), ((V)("#ffffff")), ((V)("#9aa3b2")))), ToStr(Call(ci_32, V.Undef, Call(r2_30, V.Undef, ((V)((ToNum(GetIdx(bp_505, 0D)) - 1D)))), Call(r2_30, V.Undef, ((V)((ToNum(GetIdx(bp_505, 1D)) - 1D)))), ((V)(0.8)), ((V)("#ffffff")))), "</g>" })));
}
return h_502;
return default;
}, 2, "", true);
return default;
}, 1, "cueProp", false);
goalProp_95 = Fn((V _self528, int _argc529, V st_535, V _a532, V _a533, V _a534, V[] _rest530) => {
V R0_536 = default;
V HD_537 = default;
if (_self528.IsNullish) _self528 = GlobalV;
R0_536 = Get(st_535, "rec");
HD_537 = (Get(R0_536, "hd") is var _t538 && Truthy(_t538) ? _t538 : Arr());
return Fn((V _self528, int _argc539, V I_545, V tt_546, V _a543, V _a544, V[] _rest540) => {
V W_547 = default;
double tl_548 = 0;
V gx_549 = default;
V gy_550 = default;
V F_551 = default;
V Hd_552 = default;
V x_553 = default;
V y_554 = default;
double r_555 = 0;
double s_556 = 0;
V op_557 = default;
V dr_558 = default;
V pre_559 = default;
V f_560 = default;
W_547 = (Get(I_545, "W") is var _t561 && Truthy(_t561) ? _t561 : NewObj(0).V);
tl_548 = (ToNum(tt_546) % ToNum(Get(st_535, "loop")));
{ V _t562 = Call(g0_42, V.Undef, I_545);
{ V _t563 = ListOf(_t562);
{ V _t564 = GetIdx(_t563, 0D);
gx_549 = _t564; }
{ V _t565 = GetIdx(_t563, 1D);
gy_550 = _t565; }
} }
F_551 = Arr(Add(gx_549, ((V)(8D))), ((V)((ToNum(gy_550) - 3D))));
Hd_552 = (Truthy(Call(okp_35, V.Undef, Get(W_547, "head"))) ? Get(W_547, "head") : Arr(((V)(50D)), ((V)(20D))));
x_553 = GetIdx(F_551, 0D);
y_554 = GetIdx(F_551, 1D);
r_555 = 0D;
s_556 = 2D;
op_557 = ((V)(1D));
dr_558 = Invoke((Get(R0_536, "dr") is var _t573 && Truthy(_t573) ? _t573 : Arr()), "find", Fn((V _self528, int _argc566, V q_572, V _a569, V _a570, V _a571, V[] _rest567) => {
return ((Ge(((V)(tl_548)), GetIdx(q_572, 0D)) && Le(((V)(tl_548)), GetIdx(q_572, 1D))) ? V.True : V.False);
}, 1, "", true));
if (Truthy(dr_558)) {
double ph_574 = 0;
ph_574 = (((tl_548 - ToNum(GetIdx(dr_558, 0D))) / 320D) * System.Math.PI);
x_553 = Add(x_553, Add(((V)((FdLibm.Sin(ph_574) * 2.4))), ((Get(I_545, "lastP") is var _t575 && !Truthy(_t575) ? _t575 : Get(Get(I_545, "lastP"), "x")) is var _t576 && Truthy(_t576) ? _t576 : ((V)(0D)))));
y_554 = ((V)((ToNum(y_554) - (System.Math.Abs(FdLibm.Sin((ph_574 * 2D))) * 1.6))));
r_555 = ((tl_548 - ToNum(GetIdx(dr_558, 0D))) * 0.5);
}
pre_559 = Invoke(HD_537, "find", Fn((V _self528, int _argc577, V v_583, V _a580, V _a581, V _a582, V[] _rest578) => {
return (((tl_548 >= (ToNum(v_583) - 500D)) && Lt(((V)(tl_548)), v_583)) ? V.True : V.False);
}, 1, "", true));
f_560 = Call(flyF_41, V.Undef, Invoke((Get(R0_536, "k") is var _t584 && Truthy(_t584) ? _t584 : Arr()), "concat", HD_537), ((V)(tl_548)), NewObj(3).Put("fly", ((V)(700D))).Put("away", ((V)(1700D))).Put("ret", ((V)(900D))).V);
if (!pre_559.IsNullish) {
V u_585 = default;
u_585 = Call(ss_28, V.Undef, ((V)((((tl_548 - ToNum(pre_559)) + 500D) / 500D))));
x_553 = Call(lerp_34, V.Undef, Add(GetIdx(Hd_552, 0D), ((V)(6D))), GetIdx(Hd_552, 0D), u_585);
y_554 = Call(lerp_34, V.Undef, ((V)((ToNum(GetIdx(Hd_552, 1D)) - 46D))), ((V)((ToNum(GetIdx(Hd_552, 1D)) - 4D))), u_585);
r_555 = (200D * ToNum(u_585));
} else {
if (Truthy(f_560)) {
V ph_586 = default;
V u_587 = default;
V e_588 = default;
V from_589 = default;
{ V _t590 = f_560;
{ V _t591 = ListOf(_t590);
{ V _t592 = GetIdx(_t591, 0D);
ph_586 = _t592; }
{ V _t593 = GetIdx(_t591, 1D);
u_587 = _t593; }
{ V _t594 = GetIdx(_t591, 2D);
e_588 = _t594; }
} }
from_589 = (Truthy(Invoke(HD_537, "includes", e_588)) ? Arr(GetIdx(Hd_552, 0D), ((V)((ToNum(GetIdx(Hd_552, 1D)) - 4D)))) : F_551);
if (SEqS(ph_586, "fly")) {
x_553 = Add(GetIdx(from_589, 0D), ((V)((70D * ToNum(u_587)))));
y_554 = ((V)(((ToNum(GetIdx(from_589, 1D)) - (FdLibm.Sin((System.Math.PI * ToNum(u_587))) * 26D)) + (((ToNum(GetIdx(F_551, 1D)) - 14D) - ToNum(GetIdx(from_589, 1D))) * ToNum(u_587)))));
s_556 = (2D * (1D - (0.45 * ToNum(u_587))));
r_555 = (720D * ToNum(u_587));
if (GtN(u_587, 0.85)) {
op_557 = ((V)((1D - ((ToNum(u_587) - 0.85) / 0.15))));
}
} else {
if (SEqS(ph_586, "away")) {
op_557 = ((V)(0D));
} else {
x_553 = Call(lerp_34, V.Undef, Add(GetIdx(F_551, 0D), ((V)(60D))), GetIdx(F_551, 0D), Call(ss_28, V.Undef, u_587));
r_555 = ((-600D) * (1D - ToNum(u_587)));
op_557 = Call(ss_28, V.Undef, ((V)((ToNum(u_587) / 0.2))));
}
}
}
}
return (LtN(op_557, 0.02) ? ((V)("")) : Call(G_26, V.Undef, x_553, y_554, ((V)(r_555)), ((V)(s_556)), Get(ICX_93, "ball"), op_557));
return default;
}, 2, "", true);
return default;
}, 1, "goalProp", false);
keepProp_99 = Fn((V _self595, int _argc596, V st_602, V _a599, V _a600, V _a601, V[] _rest597) => {
V R0_603 = default;
if (_self595.IsNullish) _self595 = GlobalV;
R0_603 = Get(st_602, "rec");
return Fn((V _self595, int _argc604, V I_610, V tt_611, V _a608, V _a609, V[] _rest605) => {
V W_612 = default;
double tl_613 = 0;
V c_614 = default;
V p_615 = default;
double u_616 = 0;
W_612 = Get(I_610, "W");
if (((!(Truthy(W_612)) || !(Truthy(Call(okp_35, V.Undef, Get(W_612, "pawL"))))) || !(Truthy(Call(okp_35, V.Undef, Get(W_612, "pawR")))))) {
return ((V)(""));
}
tl_613 = (ToNum(tt_611) % ToNum(Get(st_602, "loop")));
c_614 = Invoke((Get(R0_603, "c") is var _t624 && Truthy(_t624) ? _t624 : Arr()), "find", Fn((V _self595, int _argc617, V q_623, V _a620, V _a621, V _a622, V[] _rest618) => {
return (((tl_613 >= (ToNum(GetIdx(q_623, 0D)) - 250D)) && Le(((V)(tl_613)), GetIdx(q_623, 1D))) ? V.True : V.False);
}, 1, "", true));
if (Truthy(c_614)) {
V m_625 = default;
V u_626 = default;
m_625 = Call(mid_43, V.Undef, W_612);
u_626 = Call(ss_28, V.Undef, ((V)((((tl_613 - ToNum(GetIdx(c_614, 0D))) + 250D) / 250D))));
return Call(G_26, V.Undef, Call(lerp_34, V.Undef, Add(GetIdx(m_625, 0D), ((V)(10D))), GetIdx(m_625, 0D), u_626), Call(lerp_34, V.Undef, ((V)((ToNum(GetIdx(m_625, 1D)) - 14D))), GetIdx(m_625, 1D), u_626), ((V)(0D)), ((V)((2.2 * (0.6 + (0.4 * ToNum(u_626)))))), Get(ICX_93, "ball"));
}
p_615 = Invoke((Get(R0_603, "pu") is var _t634 && Truthy(_t634) ? _t634 : Arr()), "find", Fn((V _self595, int _argc627, V v_633, V _a630, V _a631, V _a632, V[] _rest628) => {
return (((tl_613 >= (ToNum(v_633) - 250D)) && Lt(((V)(tl_613)), Add(v_633, ((V)(600D))))) ? V.True : V.False);
}, 1, "", true));
if (p_615.IsNullish) {
return ((V)(""));
}
if (Lt(((V)(tl_613)), p_615)) {
V v_635 = default;
v_635 = Call(ss_28, V.Undef, ((V)((((tl_613 - ToNum(p_615)) + 250D) / 250D))));
return Call(G_26, V.Undef, Add(GetIdx(Get(W_612, "pawR"), 0D), ((V)((12D * (1D - ToNum(v_635)))))), ((V)((ToNum(GetIdx(Get(W_612, "pawR"), 1D)) - (14D * (1D - ToNum(v_635)))))), ((V)(0D)), ((V)(2D)), Get(ICX_93, "ball"), v_635);
}
u_616 = ((tl_613 - ToNum(p_615)) / 600D);
return Call(G_26, V.Undef, Add(GetIdx(Get(W_612, "pawR"), 0D), ((V)((30D * u_616)))), ((V)((ToNum(GetIdx(Get(W_612, "pawR"), 1D)) - (26D * FdLibm.Sin(((System.Math.PI * u_616) * 0.8)))))), ((V)((500D * u_616))), ((V)((2D * (1D - (0.4 * u_616))))), Get(ICX_93, "ball"), ((V)((1D - ToNum(Call(ss_28, V.Undef, ((V)(((u_616 - 0.7) / 0.3)))))))));
return default;
}, 2, "", true);
return default;
}, 1, "keepProp", false);
hoopProp_101 = Fn((V _self636, int _argc637, V st_643, V _a640, V _a641, V _a642, V[] _rest638) => {
V R0_644 = default;
if (_self636.IsNullish) _self636 = GlobalV;
R0_644 = Get(st_643, "rec");
return Fn((V _self636, int _argc645, V I_651, V tt_652, V _a649, V _a650, V[] _rest646) => {
V W_653 = default;
double tl_654 = 0;
V gx_655 = default;
V gy_656 = default;
V p_657 = default;
double f0_658 = 0;
V m_659 = default;
V mm_660 = default;
V dr_661 = default;
V sp_662 = default;
V f_663 = default;
W_653 = Get(I_651, "W");
if ((!(Truthy(W_653)) || !(Truthy(Call(okp_35, V.Undef, Get(W_653, "pawR")))))) {
return ((V)(""));
}
tl_654 = (ToNum(tt_652) % ToNum(Get(st_643, "loop")));
{ V _t664 = Call(g0_42, V.Undef, I_651);
{ V _t665 = ListOf(_t664);
{ V _t666 = GetIdx(_t665, 0D);
gx_655 = _t666; }
{ V _t667 = GetIdx(_t665, 1D);
gy_656 = _t667; }
} }
p_657 = Get(W_653, "pawR");
f0_658 = Max(0.4, ToNum(Call(facing_27, V.Undef, I_651)));
m_659 = Call(mid_43, V.Undef, W_653);
mm_660 = Arr(GetIdx(m_659, 0D), ((V)((ToNum(GetIdx(m_659, 1D)) - 3D))));
dr_661 = Invoke((Get(R0_644, "dr") is var _t675 && Truthy(_t675) ? _t675 : Arr()), "find", Fn((V _self636, int _argc668, V q_674, V _a671, V _a672, V _a673, V[] _rest669) => {
return ((Ge(((V)(tl_654)), GetIdx(q_674, 0D)) && Le(((V)(tl_654)), GetIdx(q_674, 1D))) ? V.True : V.False);
}, 1, "", true));
sp_662 = Invoke((Get(R0_644, "sp") is var _t683 && Truthy(_t683) ? _t683 : Arr()), "find", Fn((V _self636, int _argc676, V q_682, V _a679, V _a680, V _a681, V[] _rest677) => {
return ((Ge(((V)(tl_654)), GetIdx(q_682, 0D)) && Le(((V)(tl_654)), GetIdx(q_682, 1D))) ? V.True : V.False);
}, 1, "", true));
f_663 = Call(flyF_41, V.Undef, Get(R0_644, "sh"), ((V)(tl_654)), NewObj(3).Put("fly", ((V)(900D))).Put("away", ((V)(1500D))).Put("ret", ((V)(600D))).V);
if (Truthy(f_663)) {
V ph_684 = default;
V u_685 = default;
{ V _t686 = f_663;
{ V _t687 = ListOf(_t686);
{ V _t688 = GetIdx(_t687, 0D);
ph_684 = _t688; }
{ V _t689 = GetIdx(_t687, 1D);
u_685 = _t689; }
} }
if (SEqS(ph_684, "fly")) {
return Call(G_26, V.Undef, Add(GetIdx(mm_660, 0D), ((V)((30D * ToNum(u_685))))), ((V)((((ToNum(GetIdx(mm_660, 1D)) - (50D * ToNum(u_685))) - (FdLibm.Sin((System.Math.PI * ToNum(u_685))) * 16D)) + ((40D * ToNum(u_685)) * ToNum(u_685))))), ((V)((600D * ToNum(u_685)))), ((V)((2.4 * (1D - (0.4 * ToNum(u_685)))))), Get(ICX_93, "bball"), ((V)((1D - ToNum(Call(ss_28, V.Undef, ((V)(((ToNum(u_685) - 0.8) / 0.2)))))))));
}
if (SEqS(ph_684, "away")) {
return ((V)(""));
}
return Call(G_26, V.Undef, Call(lerp_34, V.Undef, Add(gx_655, ((V)(50D))), GetIdx(mm_660, 0D), Call(ss_28, V.Undef, u_685)), ((V)((ToNum(Call(lerp_34, V.Undef, ((V)((ToNum(gy_656) - 3D))), GetIdx(mm_660, 1D), Call(ss_28, V.Undef, u_685))) - (FdLibm.Sin((System.Math.PI * ToNum(u_685))) * 10D)))), ((V)(((-400D) * (1D - ToNum(u_685))))), ((V)(2.4)), Get(ICX_93, "bball"), Call(ss_28, V.Undef, ((V)((ToNum(u_685) / 0.25)))));
}
if (Truthy(sp_662)) {
return Call(G_26, V.Undef, GetIdx(p_657, 0D), ((V)((ToNum(GetIdx(p_657, 1D)) - 7D))), ((V)(((tl_654 - ToNum(GetIdx(sp_662, 0D))) * 1.4))), ((V)(2.4)), Get(ICX_93, "bball"), ((V)(f0_658)));
}
if (Truthy(dr_661)) {
double ph_690 = 0;
ph_690 = System.Math.Abs(FdLibm.Sin((((tl_654 - ToNum(GetIdx(dr_661, 0D))) / 300D) * System.Math.PI)));
return Call(G_26, V.Undef, Add(GetIdx(p_657, 0D), ((V)(1D))), Call(lerp_34, V.Undef, Add(GetIdx(p_657, 1D), ((V)(3.5))), ((V)((ToNum(gy_656) - 3D))), ((V)(ph_690))), ((V)(0D)), ((V)(2.4)), Get(ICX_93, "bball"), ((V)(f0_658)));
}
return Call(G_26, V.Undef, GetIdx(mm_660, 0D), GetIdx(mm_660, 1D), ((V)(0D)), ((V)(2.4)), Get(ICX_93, "bball"), ((V)(f0_658)));
return default;
}, 2, "", true);
return default;
}, 1, "hoopProp", false);
golfProp_104 = Fn((V _self691, int _argc692, V st_698, V _a695, V _a696, V _a697, V[] _rest693) => {
if (_self691.IsNullish) _self691 = GlobalV;
return Fn((V _self691, int _argc699, V I_705, V tt_706, V _a703, V _a704, V[] _rest700) => {
V W_707 = default;
double tl_708 = 0;
V gx_709 = default;
V gy_710 = default;
V m_711 = default;
V hd_712 = default;
V h_713 = default;
V b0_714 = default;
V f_715 = default;
V bx_716 = default;
V op_717 = default;
W_707 = Get(I_705, "W");
if (((!(Truthy(W_707)) || !(Truthy(Call(okp_35, V.Undef, Get(W_707, "pawR"))))) || !(Truthy(Call(okp_35, V.Undef, Get(W_707, "pawL")))))) {
return ((V)(""));
}
tl_708 = (ToNum(tt_706) % ToNum(Get(st_698, "loop")));
{ V _t718 = Call(g0_42, V.Undef, I_705);
{ V _t719 = ListOf(_t718);
{ V _t720 = GetIdx(_t719, 0D);
gx_709 = _t720; }
{ V _t721 = GetIdx(_t719, 1D);
gy_710 = _t721; }
} }
m_711 = Call(mid_43, V.Undef, W_707);
hd_712 = Arr(Add(GetIdx(m_711, 0D), ((V)(3D))), ((V)((ToNum(gy_710) - 1D))));
h_713 = ((V)(string.Concat(new string[] { "<path d=\"M", ToStr(Call(r2_30, V.Undef, GetIdx(m_711, 0D))), " ", ToStr(Call(r2_30, V.Undef, GetIdx(m_711, 1D))), "L", ToStr(Call(r2_30, V.Undef, GetIdx(hd_712, 0D))), " ", ToStr(Call(r2_30, V.Undef, GetIdx(hd_712, 1D))), "\" stroke=\"#6a7080\" stroke-width=\"1.5\" stroke-linecap=\"round\"/><rect x=\"", ToStr(Call(r2_30, V.Undef, ((V)((ToNum(GetIdx(hd_712, 0D)) - 1.6))))), "\" y=\"", ToStr(Call(r2_30, V.Undef, ((V)((ToNum(GetIdx(hd_712, 1D)) - 1.4))))), "\" width=\"7\" height=\"2.8\" rx=\"0.5\" fill=\"#6a7080\" stroke=\"#3a3a48\" stroke-width=\"0.3\"/>", ToStr(Call(ci_32, V.Undef, Call(r2_30, V.Undef, GetIdx(m_711, 0D)), Call(r2_30, V.Undef, GetIdx(m_711, 1D)), ((V)(1.6)), ((V)("#2a2a36")))) })));
b0_714 = Add(gx_709, ((V)(9D)));
f_715 = Call(flyF_41, V.Undef, Get(Get(st_698, "rec"), "pt"), ((V)(tl_708)), NewObj(3).Put("fly", ((V)(1300D))).Put("away", ((V)(2600D))).Put("ret", ((V)(400D))).V);
bx_716 = b0_714;
op_717 = ((V)(1D));
if (Truthy(f_715)) {
V ph_722 = default;
V u_723 = default;
V d_724 = default;
{ V _t725 = f_715;
{ V _t726 = ListOf(_t725);
{ V _t727 = GetIdx(_t726, 0D);
ph_722 = _t727; }
{ V _t728 = GetIdx(_t726, 1D);
u_723 = _t728; }
{ V _t729 = GetIdx(_t726, 3D);
d_724 = _t729; }
} }
if (SEqS(ph_722, "fly")) {
bx_716 = Add(b0_714, ((V)((44D * (1D - ((1D - ToNum(u_723)) * (1D - ToNum(u_723))))))));
} else {
if (SEqS(ph_722, "away")) {
bx_716 = Add(b0_714, ((V)(44D)));
op_717 = ((V)((1D - ToNum(Call(ss_28, V.Undef, ((V)(((ToNum(d_724) - 1500D) / 500D))))))));
} else {
op_717 = Call(ss_28, V.Undef, u_723);
}
}
}
if (GtN(op_717, 0.02)) {
h_713 = ((V)(string.Concat(new string[] { ToStr(h_713), "<g opacity=\"", ToStr(Call(r2_30, V.Undef, op_717)), "\">", ToStr(Call(ci_32, V.Undef, Call(r2_30, V.Undef, bx_716), Call(r2_30, V.Undef, ((V)((ToNum(gy_710) - 1.8)))), ((V)(1.9)), ((V)("#ffffff")), ((V)("#9aa3b2")))), "</g>" })));
}
return h_713;
return default;
}, 2, "", true);
return default;
}, 1, "golfProp", false);
tossProp_110 = Fn((V _self730, int _argc731, V st_737, V kind_738, V col_739, V _a736, V[] _rest732) => {
V R0_740 = default;
V IC_741 = default;
V Fp_742 = default;
if (_self730.IsNullish) _self730 = GlobalV;
R0_740 = Get(st_737, "rec");
IC_741 = (SEqS(kind_738, "bag") ? Invoke(ICX_93, "bag", col_739) : (SEqS(kind_738, "shoe") ? Get(ICX_93, "shoe") : Get(ICX_93, "bocce")));
Fp_742 = (SEqS(kind_738, "bocce") ? NewObj(3).Put("fly", ((V)(1500D))).Put("away", ((V)(2600D))).Put("ret", ((V)(400D))).V : NewObj(3).Put("fly", ((V)(800D))).Put("away", ((V)(2400D))).Put("ret", ((V)(400D))).V);
return Fn((V _self730, int _argc743, V I_749, V tt_750, V _a747, V _a748, V[] _rest744) => {
V W_751 = default;
double tl_752 = 0;
V gx_753 = default;
V gy_754 = default;
V p_755 = default;
double f0_756 = 0;
V f_757 = default;
double s_758 = 0;
V T_759 = default;
V ph_760 = default;
V u_761 = default;
V d_762 = default;
W_751 = Get(I_749, "W");
if ((!(Truthy(W_751)) || !(Truthy(Call(okp_35, V.Undef, Get(W_751, "pawR")))))) {
return ((V)(""));
}
tl_752 = (ToNum(tt_750) % ToNum(Get(st_737, "loop")));
{ V _t763 = Call(g0_42, V.Undef, I_749);
{ V _t764 = ListOf(_t763);
{ V _t765 = GetIdx(_t764, 0D);
gx_753 = _t765; }
{ V _t766 = GetIdx(_t764, 1D);
gy_754 = _t766; }
} }
p_755 = Get(W_751, "pawR");
f0_756 = Max(0.4, ToNum(Call(facing_27, V.Undef, I_749)));
f_757 = Call(flyF_41, V.Undef, Get(R0_740, "ts"), ((V)(tl_752)), Fp_742);
s_758 = 2.8;
T_759 = Arr(Add(gx_753, ((V)(48D))), ((V)((ToNum(gy_754) - 9D))));
if (!(Truthy(f_757))) {
return Call(G_26, V.Undef, GetIdx(p_755, 0D), ((V)((ToNum(GetIdx(p_755, 1D)) - 1D))), ((V)(0D)), ((V)(s_758)), IC_741, ((V)(f0_756)));
}
{ V _t767 = f_757;
{ V _t768 = ListOf(_t767);
{ V _t769 = GetIdx(_t768, 0D);
ph_760 = _t769; }
{ V _t770 = GetIdx(_t768, 1D);
u_761 = _t770; }
{ V _t771 = GetIdx(_t768, 3D);
d_762 = _t771; }
} }
if (SEqS(ph_760, "ret")) {
return Call(G_26, V.Undef, GetIdx(p_755, 0D), ((V)((ToNum(GetIdx(p_755, 1D)) - 1D))), ((V)(0D)), ((V)(s_758)), IC_741, ((V)((f0_756 * ToNum(Call(ss_28, V.Undef, u_761))))));
}
if (SEqS(ph_760, "away")) {
return Call(G_26, V.Undef, GetIdx(T_759, 0D), GetIdx(T_759, 1D), ((V)((SEqS(kind_738, "shoe") ? 0D : 10D))), ((V)((s_758 * 0.75))), IC_741, ((V)((1D - ToNum(Call(ss_28, V.Undef, ((V)((((ToNum(d_762) - ToNum(Get(Fp_742, "away"))) + 500D) / 500D)))))))));
}
if (SEqS(kind_738, "bocce")) {
double v_772 = 0;
v_772 = (1D - ((1D - ToNum(u_761)) * (1D - ToNum(u_761))));
return Call(G_26, V.Undef, Call(lerp_34, V.Undef, GetIdx(p_755, 0D), GetIdx(T_759, 0D), ((V)(v_772))), ((V)((ToNum(Call(lerp_34, V.Undef, GetIdx(p_755, 1D), GetIdx(T_759, 1D), ((V)(v_772)))) - (LtN(u_761, 0.12) ? ((1D - (ToNum(u_761) / 0.12)) * 4D) : 0D)))), ((V)((900D * v_772))), ((V)((s_758 * (1D - (0.25 * v_772))))), IC_741);
}
return Call(G_26, V.Undef, Call(lerp_34, V.Undef, GetIdx(p_755, 0D), GetIdx(T_759, 0D), u_761), ((V)((ToNum(Call(lerp_34, V.Undef, GetIdx(p_755, 1D), GetIdx(T_759, 1D), u_761)) - (FdLibm.Sin((System.Math.PI * ToNum(u_761))) * 24D)))), ((V)(((SEqS(kind_738, "shoe") ? 720D : 300D) * ToNum(u_761)))), ((V)((s_758 * (1D - (0.25 * ToNum(u_761)))))), IC_741);
return default;
}, 2, "", true);
return default;
}, 3, "tossProp", false);
hopProp_115 = Fn((V _self773, int _argc774, V st_780, V _a777, V _a778, V _a779, V[] _rest775) => {
V R0_781 = default;
if (_self773.IsNullish) _self773 = GlobalV;
R0_781 = Get(st_780, "rec");
return Fn((V _self773, int _argc782, V I_788, V tt_789, V _a786, V _a787, V[] _rest783) => {
V W_790 = default;
double tl_791 = 0;
V gx_792 = default;
V gy_793 = default;
V p_794 = default;
V T_795 = default;
V ts_796 = default;
V pk_797 = default;
double f0_798 = 0;
V u_799 = default;
W_790 = Get(I_788, "W");
if ((!(Truthy(W_790)) || !(Truthy(Call(okp_35, V.Undef, Get(W_790, "pawR")))))) {
return ((V)(""));
}
tl_791 = (ToNum(tt_789) % ToNum(Get(st_780, "loop")));
{ V _t800 = Call(g0_42, V.Undef, I_788);
{ V _t801 = ListOf(_t800);
{ V _t802 = GetIdx(_t801, 0D);
gx_792 = _t802; }
{ V _t803 = GetIdx(_t801, 1D);
gy_793 = _t803; }
} }
p_794 = Get(W_790, "pawR");
T_795 = Arr(Add(gx_792, ((V)(30D))), Add(gy_793, ((V)(1D))));
ts_796 = GetIdx((Get(R0_781, "ts") is var _t804 && Truthy(_t804) ? _t804 : Arr()), 0D);
pk_797 = GetIdx((Get(R0_781, "pk") is var _t805 && Truthy(_t805) ? _t805 : Arr()), 0D);
f0_798 = Max(0.4, ToNum(Call(facing_27, V.Undef, I_788)));
if (((ts_796.IsNullish || Lt(((V)(tl_791)), ts_796)) || (!pk_797.IsNullish && Ge(((V)(tl_791)), pk_797)))) {
return Call(G_26, V.Undef, GetIdx(p_794, 0D), GetIdx(p_794, 1D), ((V)(0D)), ((V)(2.6)), Get(ICX_93, "stone"), ((V)(f0_798)));
}
u_799 = Call(cl_29, V.Undef, ((V)(((tl_791 - ToNum(ts_796)) / 600D))), ((V)(0D)), ((V)(1D)));
return Call(G_26, V.Undef, Call(lerp_34, V.Undef, GetIdx(p_794, 0D), GetIdx(T_795, 0D), u_799), ((V)((ToNum(Call(lerp_34, V.Undef, GetIdx(p_794, 1D), GetIdx(T_795, 1D), u_799)) - (FdLibm.Sin((System.Math.PI * ToNum(u_799))) * 14D)))), ((V)(0D)), ((V)(2.6)), Get(ICX_93, "stone"));
return default;
}, 2, "", true);
return default;
}, 1, "hopProp", false);
frisbeeProp_119 = Fn((V _self806, int _argc807, V st_813, V col_814, V _a811, V _a812, V[] _rest808) => {
V R0_815 = default;
V IC_816 = default;
if (_self806.IsNullish) _self806 = GlobalV;
R0_815 = Get(st_813, "rec");
IC_816 = Invoke(ICX_93, "disc", col_814);
return Fn((V _self806, int _argc817, V I_823, V tt_824, V _a821, V _a822, V[] _rest818) => {
V W_825 = default;
double tl_826 = 0;
V p_827 = default;
double f0_828 = 0;
V m_829 = default;
V mm_830 = default;
V th_831 = default;
V ca_832 = default;
V e_833 = default;
W_825 = Get(I_823, "W");
if ((!(Truthy(W_825)) || !(Truthy(Call(okp_35, V.Undef, Get(W_825, "pawR")))))) {
return ((V)(""));
}
tl_826 = (ToNum(tt_824) % ToNum(Get(st_813, "loop")));
p_827 = Get(W_825, "pawR");
f0_828 = Max(0.4, ToNum(Call(facing_27, V.Undef, I_823)));
m_829 = Call(mid_43, V.Undef, W_825);
mm_830 = Arr(GetIdx(m_829, 0D), ((V)((ToNum(GetIdx(m_829, 1D)) - 4D))));
th_831 = (Get(R0_815, "th") is var _t834 && Truthy(_t834) ? _t834 : Arr());
ca_832 = (Get(R0_815, "ca") is var _t835 && Truthy(_t835) ? _t835 : Arr());
e_833 = ((V)((-1D)));
Invoke(th_831, "forEach", Fn((V _self806, int _argc836, V v_842, V i_843, V _a840, V _a841, V[] _rest837) => {
if (((Ge(((V)(tl_826)), v_842) && !GetK(ca_832, i_843).IsNullish) && Lt(((V)(tl_826)), GetK(ca_832, i_843)))) {
e_833 = i_843;
}
return default;
}, 2, "", true));
if (GeN(e_833, 0D)) {
V a_844 = default;
V b_845 = default;
double u_846 = 0;
a_844 = GetK(th_831, e_833);
b_845 = GetK(ca_832, e_833);
u_846 = ((tl_826 - ToNum(a_844)) / (ToNum(b_845) - ToNum(a_844)));
return Call(G_26, V.Undef, Add(Call(lerp_34, V.Undef, GetIdx(p_827, 0D), GetIdx(mm_830, 0D), ((V)(u_846))), ((V)((FdLibm.Sin((System.Math.PI * u_846)) * 56D)))), ((V)(((ToNum(Call(lerp_34, V.Undef, GetIdx(p_827, 1D), GetIdx(mm_830, 1D), ((V)(u_846)))) - (FdLibm.Sin((System.Math.PI * u_846)) * 16D)) - (FdLibm.Sin(((System.Math.PI * 2D) * u_846)) * 6D)))), ((V)((FdLibm.Sin(((System.Math.PI * 2D) * u_846)) * 12D))), ((V)((3D * (1D - (0.35 * FdLibm.Sin((System.Math.PI * u_846))))))), IC_816);
}
return (Truthy(Invoke(ca_832, "some", Fn((V _self806, int _argc847, V v_853, V _a850, V _a851, V _a852, V[] _rest848) => {
return ((Ge(((V)(tl_826)), v_853) && Lt(((V)(tl_826)), Add(v_853, ((V)(1200D))))) ? V.True : V.False);
}, 1, "", true))) ? Call(G_26, V.Undef, GetIdx(mm_830, 0D), GetIdx(mm_830, 1D), ((V)(0D)), ((V)(3D)), IC_816, ((V)(f0_828))) : Call(G_26, V.Undef, GetIdx(p_827, 0D), GetIdx(p_827, 1D), ((V)((-10D))), ((V)(3D)), IC_816, ((V)(f0_828))));
return default;
}, 2, "", true);
return default;
}, 2, "frisbeeProp", false);
cBuild_121 = Fn((V _self854, int _argc855, V key_861, V X_862, V _a859, V _a860, V[] _rest856) => {
V P_863 = default;
V nm_864 = default;
V S_865 = default;
V SB_866 = default;
V sig_867 = default;
V pc_868 = default;
V H1_869 = default;
V GM_870 = default;
if (_self854.IsNullish) _self854 = GlobalV;
X_862 = Call(o_21, V.Undef, (GetK(BB_19, key_861) is var _t871 && Truthy(_t871) ? _t871 : NewObj(0).V), (X_862 is var _t872 && Truthy(_t872) ? _t872 : NewObj(0).V));
P_863 = (GetK(PROF_18, key_861) is var _t873 && Truthy(_t873) ? _t873 : NewObj(0).V);
nm_864 = Fn((V _self854, int _argc874, V n_880, V _a877, V _a878, V _a879, V[] _rest875) => {
return (Truthy(key_861) ? ((V)(string.Concat(ToStr(n_880), "@", ToStr(key_861)))) : n_880);
}, 1, "", true);
S_865 = NewObj(0).V;
SB_866 = Call(o_21, V.Undef, SIT0_17, (Get(P_863, "pose") is var _t881 && Truthy(_t881) ? _t881 : NewObj(0).V));
sig_867 = ((Get(X_862, "b") is var _t882 && Truthy(_t882) ? _t882 : Get(X_862, "p")) is var _t891 && Truthy(_t891) ? _t891 : Invoke((Get(P_863, "f") is var _t890 && Truthy(_t890) ? _t890 : Arr()), "find", Fn((V _self854, int _argc883, V f_889, V _a886, V _a887, V _a888, V[] _rest884) => {
return (string.Equals(Typeof(f_889), "function") ? V.True : V.False);
}, 1, "", true)));
pc_868 = (Get(X_862, "pc") is var _t892 && Truthy(_t892) ? _t892 : ((V)("#e8483c")));
H1_869 = Fn((V _self854, int _argc893, V n_899, V B_900, V ord_901, V BK_902, V[] _rest894) => {
V gaps_903 = default;
V e_904 = default;
gaps_903 = (_argc893 > 4 ? _rest894[0] : V.Undef);
e_904 = (_argc893 > 5 ? _rest894[1] : V.Undef);
return SetK(S_865, Call(nm_864, V.Undef, n_899), Call(hold_40, V.Undef, B_900, ord_901, Call(o_21, V.Undef, COM_49, (BK_902 is var _t905 && Truthy(_t905) ? _t905 : NewObj(0).V)), X_862, sig_867, (gaps_903 is var _t906 && Truthy(_t906) ? _t906 : Arr(((V)(500D)), ((V)(700D)), ((V)(600D)), ((V)(800D)))), (e_904 is var _t907 && Truthy(_t907) ? _t907 : NewObj(1).Put("breathe", ((V)(0.4))).V)));
}, 6, "", true);
SetK(S_865, Call(nm_864, V.Undef, ((V)("kick"))), Call(kickMove_51, V.Undef, X_862));
SetK(S_865, Call(nm_864, V.Undef, ((V)("shellpick"))), Call(shellMove_73, V.Undef, X_862));
Call(H1_869, V.Undef, ((V)("bowl")), Call(o_21, V.Undef, BW0_52, (Get(X_862, "bwp") is var _t908 && Truthy(_t908) ? _t908 : NewObj(0).V)), Arr(((V)("munch")), ((V)("up")), ((V)("munch")), ((V)("slurp")), ((V)("lick")), ((V)("sig")), ((V)("munch")), ((V)("tummy")), ((V)("hic"))), BWB_53, Arr(((V)(300D)), ((V)(500D)), ((V)(400D)), ((V)(600D))));
Set(Call(H1_869, V.Undef, ((V)("dishes")), DS0_54, Arr(((V)("scrub")), ((V)("rinse")), ((V)("squeak")), ((V)("stack")), ((V)("scrub")), ((V)("hum")), ((V)("rinse")), ((V)("stack")), ((V)("bubble")), ((V)("sig")), ((V)("scrub")), ((V)("squeak")), ((V)("stack"))), DSB_55, Arr(((V)(300D)), ((V)(500D)), ((V)(400D)))), "prop", V.Null);
Set(GetK(S_865, Call(nm_864, V.Undef, ((V)("dishes")))), "prop", Call(dishProp_58, V.Undef, GetK(S_865, Call(nm_864, V.Undef, ((V)("dishes"))))));
{
V st_909 = default;
st_909 = Call(H1_869, V.Undef, ((V)("grill")), GR0_59, Arr(((V)("poke")), ((V)("flip")), ((V)("smoke")), ((V)("season")), ((V)("poke")), ((V)("flip")), ((V)("sniff")), ((V)("sig")), ((V)("serve"))), GRB_60, Arr(((V)(400D)), ((V)(600D)), ((V)(500D))));
Set(st_909, "prop", Call(grillProp_63, V.Undef, st_909));
}
Call(H1_869, V.Undef, ((V)("toastwait")), TW0_64, Arr(((V)("tap")), ((V)("peek")), ((V)("rub")), ((V)("hum")), ((V)("look")), ((V)("tap"))), TWB_65, Arr(((V)(600D)), ((V)(900D))));
SetK(S_865, Call(nm_864, V.Undef, ((V)("toast"))), Call(toastMove_67, V.Undef, X_862));
{
V PO_910 = default;
V a_911 = default;
PO_910 = Call(o_21, V.Undef, SB_866, NewObj(1).Put("sq", Add((Get(SB_866, "sq") is var _t912 && Truthy(_t912) ? _t912 : ((V)(0D))), ((V)(0.04)))).V);
Call(H1_869, V.Undef, ((V)("pouf")), PO_910, Arr(((V)("bounce")), ((V)("look")), ((V)("big")), ((V)("wiggle")), ((V)("rock")), ((V)("bounce")), ((V)("sig")), ((V)("spinb")), ((V)("giggle"))), POB_68, Arr(((V)(500D)), ((V)(900D)), ((V)(700D))));
a_911 = Call(sitdown_22, V.Undef, PO_910, P_863);
Set(a_911, "next", ((V)("pouf")));
SetK(S_865, Call(nm_864, V.Undef, ((V)("poufin"))), a_911);
SetK(S_865, Call(nm_864, V.Undef, ((V)("poufout"))), Call(standup_23, V.Undef, PO_910, P_863));
}
{
V SP_913 = default;
SP_913 = Call(o_21, V.Undef, SP0_69, (SEqS(Get(P_863, "dn"), "float") ? NewObj(2).Put("sit", ((V)(0D))).Put("sk", ((V)(3D))).V : NewObj(0).V), (Get(X_862, "spp") is var _t914 && Truthy(_t914) ? _t914 : NewObj(0).V));
Call(H1_869, V.Undef, ((V)("splash")), SP_913, Arr(((V)("slap")), ((V)("kick")), ((V)("duck")), ((V)("atyou")), ((V)("soak")), ((V)("sig")), ((V)("slap")), ((V)("wave"))), SPB_70, Arr(((V)(500D)), ((V)(800D)), ((V)(600D))), NewObj(1).Put("breathe", ((V)(0.5))).V);
SetK(S_865, Call(nm_864, V.Undef, ((V)("splashin"))), Call(splashIn_71, V.Undef, SP_913, P_863));
SetK(S_865, Call(nm_864, V.Undef, ((V)("splashout"))), Call(splashOut_72, V.Undef, SP_913));
}
Set(Call(H1_869, V.Undef, ((V)("perform")), PF0_74, Arr(((V)("sing")), ((V)("step")), ((V)("sing")), ((V)("belt")), ((V)("point")), ((V)("spin")), ((V)("sing")), ((V)("sig")), ((V)("belt")), ((V)("bow"))), PFB_75, Arr(((V)(300D)), ((V)(500D)), ((V)(400D)))), "prop", Call(micProp_77, V.Undef, (Get(X_862, "mc") is var _t915 && Truthy(_t915) ? _t915 : ((V)("#3b3b4a")))));
Set(Call(H1_869, V.Undef, ((V)("dj")), DJ0_78, Arr(((V)("nod")), ((V)("scratch")), ((V)("nod")), ((V)("pump")), ((V)("point")), ((V)("nod")), ((V)("scratch")), ((V)("drop")), ((V)("sig")), ((V)("spin")), ((V)("pump"))), DJB_79, Arr(((V)(200D)), ((V)(300D)))), "prop", Call(phoneProp_80, V.Undef, (Get(X_862, "hc") is var _t916 && Truthy(_t916) ? _t916 : ((V)("#45189a")))));
Call(H1_869, V.Undef, ((V)("pinball")), PB0_81, Arr(((V)("flip")), ((V)("track")), ((V)("flip")), ((V)("nudge")), ((V)("multi")), ((V)("yay")), ((V)("flip")), ((V)("oops")), ((V)("sig"))), PBB_82, Arr(((V)(200D)), ((V)(400D)), ((V)(300D))));
Call(H1_869, V.Undef, ((V)("dancecab")), DC0_83, Arr(((V)("steps")), ((V)("arrows")), ((V)("steps")), ((V)("jump")), ((V)("combo")), ((V)("spin")), ((V)("steps")), ((V)("freeze")), ((V)("sig"))), DCB_84, Arr(((V)(150D)), ((V)(250D))));
{
V st_917 = default;
st_917 = Call(H1_869, V.Undef, ((V)("hockey")), HK0_85, Arr(((V)("ready")), ((V)("hit")), ((V)("ready")), ((V)("block")), ((V)("hit")), ((V)("yay")), ((V)("ready")), ((V)("hit")), ((V)("oops")), ((V)("sig"))), HKB_86, Arr(((V)(300D)), ((V)(500D)), ((V)(400D))));
Set(st_917, "prop", Call(puckProp_89, V.Undef, st_917, pc_868, ((V)(0D))));
}
{
V st_918 = default;
st_918 = Call(H1_869, V.Undef, ((V)("billiards")), BL0_90, Arr(((V)("chalk")), ((V)("aim")), ((V)("shoot")), ((V)("yay")), ((V)("aim")), ((V)("shoot")), ((V)("miss")), ((V)("circle")), ((V)("sig"))), BLB_91, Arr(((V)(500D)), ((V)(500D)), ((V)(0D))));
Set(st_918, "prop", Call(cueProp_92, V.Undef, st_918));
}
GM_870 = Fn((V _self854, int _argc919, V n_925, V B_926, V ord_927, V BK_928, V[] _rest920) => {
V st_931 = default;
V gaps_929 = default;
V prop_930 = default;
gaps_929 = (_argc919 > 4 ? _rest920[0] : V.Undef);
prop_930 = (_argc919 > 5 ? _rest920[1] : V.Undef);
st_931 = Call(H1_869, V.Undef, ((V)(string.Concat("g_", ToStr(n_925)))), B_926, ord_927, BK_928, gaps_929);
if (Truthy(prop_930)) {
Set(st_931, "prop", Call(prop_930, V.Undef, st_931));
}
return default;
}, 6, "", true);
Call(GM_870, V.Undef, ((V)("goal")), ST0_38, Arr(((V)("dribble")), ((V)("kick")), ((V)("watch")), ((V)("yay")), ((V)("dribble")), ((V)("header")), ((V)("dribble")), ((V)("kick")), ((V)("sig")), ((V)("yay"))), GOB_94, Arr(((V)(400D)), ((V)(600D)), ((V)(500D))), goalProp_95);
Call(GM_870, V.Undef, ((V)("keep")), KP0_96, Arr(((V)("ready")), ((V)("diveL")), ((V)("ready")), ((V)("catch")), ((V)("ready")), ((V)("diveR")), ((V)("punch")), ((V)("sig")), ((V)("ready")), ((V)("catch"))), KPB_98, Arr(((V)(300D)), ((V)(500D))), keepProp_99);
Call(GM_870, V.Undef, ((V)("hoop")), ST0_38, Arr(((V)("dribble")), ((V)("shoot")), ((V)("yay")), ((V)("dribble")), ((V)("spinball")), ((V)("dribble")), ((V)("shoot")), ((V)("oops")), ((V)("sig")), ((V)("dribble")), ((V)("shoot")), ((V)("yay"))), HPB_100, Arr(((V)(300D)), ((V)(500D)), ((V)(400D))), hoopProp_101);
Call(GM_870, V.Undef, ((V)("golf")), GF0_102, Arr(((V)("line")), ((V)("waggle")), ((V)("putt")), ((V)("yay")), ((V)("line")), ((V)("waggle")), ((V)("putt")), ((V)("oops")), ((V)("sig"))), GFB_103, Arr(((V)(400D)), ((V)(300D)), ((V)(300D))), golfProp_104);
Call(GM_870, V.Undef, ((V)("dome")), ST0_38, Arr(((V)("climb")), ((V)("hang")), ((V)("topwave")), ((V)("peek")), ((V)("hang")), ((V)("down")), ((V)("yay")), ((V)("climb")), ((V)("hang")), ((V)("down")), ((V)("sig"))), DMB_106, Arr(((V)(300D)), ((V)(200D))));
Call(GM_870, V.Undef, ((V)("agility")), ST0_38, Arr(((V)("hurdle")), ((V)("weave")), ((V)("pant")), ((V)("tire")), ((V)("ramp")), ((V)("yay")), ((V)("sig")), ((V)("hurdle")), ((V)("pant"))), AGB_107, Arr(((V)(300D)), ((V)(500D))));
Call(GM_870, V.Undef, ((V)("bocce")), ST0_38, Arr(((V)("aim")), ((V)("roll")), ((V)("watch")), ((V)("yay")), ((V)("aim")), ((V)("roll")), ((V)("watch")), ((V)("oops")), ((V)("sig"))), NewObj(2).Put("aim", aimB_109).Put("roll", Call(tossB_108, V.Undef, ((V)("bocce")))).V, Arr(((V)(500D)), ((V)(300D)), ((V)(200D))), Fn((V _self854, int _argc932, V st_938, V _a935, V _a936, V _a937, V[] _rest933) => {
return Call(tossProp_110, V.Undef, st_938, ((V)("bocce")));
}, 1, "", true));
Call(GM_870, V.Undef, ((V)("cornhole")), ST0_38, Arr(((V)("aim")), ((V)("toss")), ((V)("yay")), ((V)("aim")), ((V)("toss")), ((V)("watch")), ((V)("oops")), ((V)("sig"))), NewObj(2).Put("aim", aimB_109).Put("toss", Call(tossB_108, V.Undef, ((V)("bag")))).V, Arr(((V)(500D)), ((V)(300D)), ((V)(300D))), Fn((V _self854, int _argc939, V st_945, V _a942, V _a943, V _a944, V[] _rest940) => {
return Call(tossProp_110, V.Undef, st_945, ((V)("bag")), pc_868);
}, 1, "", true));
Call(GM_870, V.Undef, ((V)("shoe")), ST0_38, Arr(((V)("aim")), ((V)("toss")), ((V)("yay")), ((V)("aim")), ((V)("toss")), ((V)("oops")), ((V)("sig"))), NewObj(2).Put("aim", aimB_109).Put("toss", Call(tossB_108, V.Undef, ((V)("shoe")))).V, Arr(((V)(500D)), ((V)(300D)), ((V)(300D))), Fn((V _self854, int _argc946, V st_952, V _a949, V _a950, V _a951, V[] _rest947) => {
return Call(tossProp_110, V.Undef, st_952, ((V)("shoe")));
}, 1, "", true));
Call(GM_870, V.Undef, ((V)("pong")), PG0_111, Arr(((V)("serve")), ((V)("rally")), ((V)("smash")), ((V)("yay")), ((V)("serve")), ((V)("rally")), ((V)("oops")), ((V)("sig"))), PGB_112, Arr(((V)(300D)), ((V)(0D)), ((V)(0D)), ((V)(400D))), Fn((V _self854, int _argc953, V st_959, V _a956, V _a957, V _a958, V[] _rest954) => {
return Call(puckProp_89, V.Undef, st_959, pc_868, ((V)(1D)));
}, 1, "", true));
Call(GM_870, V.Undef, ((V)("tether")), ST0_38, Arr(((V)("punch")), ((V)("track")), ((V)("duck")), ((V)("punch")), ((V)("double")), ((V)("yay")), ((V)("track")), ((V)("sig"))), TTB_113, Arr(((V)(400D)), ((V)(300D))));
Call(GM_870, V.Undef, ((V)("villa")), SB_866, Arr(((V)("look")), ((V)("wave")), ((V)("wiggle")), ((V)("yawn")), ((V)("giggle")), ((V)("sig")), ((V)("doze")), ((V)("nod"))), NewObj(0).V, Arr(((V)(900D)), ((V)(1400D)), ((V)(1100D))));
Call(GM_870, V.Undef, ((V)("hop")), ST0_38, Arr(((V)("toss")), ((V)("hops")), ((V)("twirl")), ((V)("hopback")), ((V)("pick")), ((V)("yay")), ((V)("sig"))), HSB_114, Arr(((V)(400D)), ((V)(200D)), ((V)(200D)), ((V)(200D)), ((V)(300D))));
Call(GM_870, V.Undef, ((V)("tunnel")), TU0_116, Arr(((V)("crawl")), ((V)("peek")), ((V)("crawl")), ((V)("pop")), ((V)("crawl")), ((V)("giggle")), ((V)("sig"))), TUB_117, Arr(((V)(300D)), ((V)(500D))));
Call(GM_870, V.Undef, ((V)("frisbee")), ST0_38, Arr(((V)("throw")), ((V)("catch")), ((V)("yay")), ((V)("throw")), ((V)("catch")), ((V)("sig")), ((V)("throw")), ((V)("catch")), ((V)("clap"))), FRB_118, Arr(((V)(300D)), ((V)(0D)), ((V)(400D))), Fn((V _self854, int _argc960, V st_966, V _a963, V _a964, V _a965, V[] _rest961) => {
return Call(frisbeeProp_119, V.Undef, st_966, (Get(X_862, "fc2") is var _t967 && Truthy(_t967) ? _t967 : ((V)("#ffcc3a"))));
}, 1, "", true));
Call(GM_870, V.Undef, ((V)("cheer")), ST0_38, Arr(((V)("clap")), ((V)("watch")), ((V)("yay")), ((V)("look")), ((V)("clap")), ((V)("sig")), ((V)("wave")), ((V)("oops")), ((V)("clap"))), NewObj(0).V, Arr(((V)(500D)), ((V)(800D)), ((V)(600D))));
Invoke(R_10, "add", S_865);
Set(R_10, "HS", Object_assign((Get(R_10, "HS") is var _t968 && Truthy(_t968) ? _t968 : NewObj(0).V), S_865));
if (Truthy(key_861)) {
SetK(CX_120, key_861, X_862);
}
return default;
}, 2, "cBuild", false);
R_10 = Get(G("window"), "RiveRig");
REST_11 = Get(R_10, "REST");
{ V _t969 = H_9;
if (_t969.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t969));
{ V _t970 = Get(_t969, "TL");
TL_12 = _t970; }
{ V _t971 = Get(_t969, "BEAT");
BEAT_13 = _t971; }
{ V _t972 = Get(_t969, "hand");
hand_14 = _t972; }
{ V _t973 = Get(_t969, "both");
both_15 = _t973; }
{ V _t974 = Get(_t969, "SIDE");
SIDE_16 = _t974; }
{ V _t975 = Get(_t969, "SIT0");
SIT0_17 = _t975; }
{ V _t976 = Get(_t969, "PROF");
PROF_18 = _t976; }
{ V _t977 = Get(_t969, "BB");
BB_19 = _t977; }
{ V _t978 = Get(_t969, "ICON");
ICON_20 = _t978; }
{ V _t979 = Get(_t969, "o");
o_21 = _t979; }
{ V _t980 = Get(_t969, "sitdown");
sitdown_22 = _t980; }
{ V _t981 = Get(_t969, "standup");
standup_23 = _t981; }
{ V _t982 = Get(_t969, "gnd");
gnd_24 = _t982; }
{ V _t983 = Get(_t969, "rside");
rside_25 = _t983; }
{ V _t984 = Get(_t969, "G");
G_26 = _t984; }
{ V _t985 = Get(_t969, "facing");
facing_27 = _t985; }
{ V _t986 = Get(_t969, "ss");
ss_28 = _t986; }
{ V _t987 = Get(_t969, "cl");
cl_29 = _t987; }
{ V _t988 = Get(_t969, "r2");
r2_30 = _t988; }
{ V _t989 = Get(_t969, "shade");
shade_31 = _t989; }
{ V _t990 = Get(_t969, "ci");
ci_32 = _t990; }
{ V _t991 = Get(_t969, "pa");
pa_33 = _t991; }
{ V _t992 = Get(_t969, "lerp");
lerp_34 = _t992; }
{ V _t993 = Get(_t969, "okp");
okp_35 = _t993; }
{ V _t994 = Get(_t969, "BATH0");
BATH0_36 = _t994; } }
if ((!(Truthy(sitdown_22)) || !(Truthy(G_26)))) {
Invoke(G("console"), "warn", ((V)("house-cx: house-moves.js too old")));
return default;
}
K_37 = Get(G("Object"), "keys");
ST0_38 = NewObj(31).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("pitch", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("smile", ((V)(0.7))).Put("hap", ((V)(0.3))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).Put("htilt", ((V)(0D))).Put("close", ((V)(0D))).Put("wide", ((V)(0D))).Put("sqz", ((V)(0D))).Put("turn", ((V)(0D))).Put("spin", ((V)(0D))).Put("tongue", ((V)(0D))).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).Put("frown", ((V)(0D))).V;
S0_39 = Fn((V _self2, int _argc995, V x_1001, V _a998, V _a999, V _a1000, V[] _rest996) => {
V a_1002 = default;
a_1002 = RestArgs(1, _argc995, x_1001, _a998, _a999, _a1000, _rest996);
return CallSpread(o_21, V.Undef, new ArrBuilder().Add(ST0_38).Spread(a_1002).Add((x_1001 is var _t1003 && Truthy(_t1003) ? _t1003 : NewObj(0).V)).V);
}, 2, "", true);
flyF_41 = Fn((V _self2, int _argc1004, V L_1010, V tl_1011, V F_1012, V _a1009, V[] _rest1005) => {
V e_1013 = default;
double d_1014 = 0;
e_1013 = V.Null;
Invoke((L_1010 is var _t1022 && Truthy(_t1022) ? _t1022 : Arr()), "forEach", Fn((V _self2, int _argc1015, V v_1021, V _a1018, V _a1019, V _a1020, V[] _rest1016) => {
if (Le(v_1021, tl_1011)) {
e_1013 = v_1021;
}
return default;
}, 1, "", true));
if (e_1013.IsNullish) {
return V.Null;
}
d_1014 = (ToNum(tl_1011) - ToNum(e_1013));
if (Lt(((V)(d_1014)), Get(F_1012, "fly"))) {
return Arr(((V)("fly")), ((V)((d_1014 / ToNum(Get(F_1012, "fly"))))), e_1013, ((V)(d_1014)));
}
if (Lt(((V)(d_1014)), Get(F_1012, "away"))) {
return Arr(((V)("away")), ((V)(1D)), e_1013, ((V)(d_1014)));
}
if (Lt(((V)(d_1014)), Add(Get(F_1012, "away"), Get(F_1012, "ret")))) {
return Arr(((V)("ret")), ((V)(((d_1014 - ToNum(Get(F_1012, "away"))) / ToNum(Get(F_1012, "ret"))))), e_1013, ((V)(d_1014)));
}
return V.Null;
return default;
}, 3, "", true);
g0_42 = Fn((V _self2, int _argc1023, V I_1029, V _a1026, V _a1027, V _a1028, V[] _rest1024) => {
V gx_1030 = default;
V gy_1031 = default;
{ V _t1032 = Call(gnd_24, V.Undef, I_1029);
{ V _t1033 = ListOf(_t1032);
{ V _t1034 = GetIdx(_t1033, 0D);
gx_1030 = _t1034; }
{ V _t1035 = GetIdx(_t1033, 1D);
gy_1031 = _t1035; }
} }
return Arr(((V)((ToNum(gx_1030) - ToNum(((Get(I_1029, "lastP") is var _t1036 && !Truthy(_t1036) ? _t1036 : Get(Get(I_1029, "lastP"), "x")) is var _t1037 && Truthy(_t1037) ? _t1037 : ((V)(0D))))))), gy_1031);
return default;
}, 1, "", true);
mid_43 = Fn((V _self2, int _argc1038, V W_1044, V _a1041, V _a1042, V _a1043, V[] _rest1039) => {
return (Truthy((Call(okp_35, V.Undef, Get(W_1044, "pawL")) is var _t1045 && !Truthy(_t1045) ? _t1045 : Call(okp_35, V.Undef, Get(W_1044, "pawR")))) ? Arr(((V)((ToNum(Add(GetIdx(Get(W_1044, "pawL"), 0D), GetIdx(Get(W_1044, "pawR"), 0D))) / 2D))), ((V)((ToNum(Add(GetIdx(Get(W_1044, "pawL"), 1D), GetIdx(Get(W_1044, "pawR"), 1D))) / 2D)))) : Get(W_1044, "pawR"));
}, 1, "", true);
hx_44 = Fn((V _self2, int _argc1046, V h_1052, V _a1049, V _a1050, V _a1051, V[] _rest1047) => {
return Invoke(Arr(((V)(1D)), ((V)(3D)), ((V)(5D))), "map", Fn((V _self2, int _argc1053, V i_1059, V _a1056, V _a1057, V _a1058, V[] _rest1054) => {
return ((V)(ParseInt(Invoke(h_1052, "slice", i_1059, Add(i_1059, ((V)(2D)))), ((V)(16D)))));
}, 1, "", true));
}, 1, "", true);
mixC_45 = Fn((V _self2, int _argc1060, V a_1066, V b_1067, V u_1068, V _a1065, V[] _rest1061) => {
V A_1069 = default;
V B_1070 = default;
A_1069 = Call(hx_44, V.Undef, a_1066);
B_1070 = Call(hx_44, V.Undef, b_1067);
return ((V)(string.Concat("rgb(", ToStr(Invoke(Invoke(A_1069, "map", Fn((V _self2, int _argc1071, V v_1077, V i_1078, V _a1075, V _a1076, V[] _rest1072) => {
return ((V)(Round(ToNum(Add(v_1077, ((V)(((ToNum(GetK(B_1070, i_1078)) - ToNum(v_1077)) * ToNum(Call(cl_29, V.Undef, u_1068, ((V)(0D)), ((V)(1D))))))))))));
}, 2, "", true)), "join", ((V)(",")))), ")")));
return default;
}, 3, "", true);
push_46 = Fn((V _self2, int _argc1079, V rec_1085, V k_1086, V v_1087, V _a1084, V[] _rest1080) => {
return Invoke(SetK(rec_1085, k_1086, (GetK(rec_1085, k_1086) is var _t1088 && Truthy(_t1088) ? _t1088 : Arr())), "push", v_1087);
}, 3, "", true);
COM_49 = NewObj(5).Put("yay", Fn((V _self1089, int _argc1090, V t_1096, V X_1097, V _a1094, V _a1095, V[] _rest1091) => {
if (_self1089.IsNullish) _self1089 = GlobalV;
Call(cheer_47, V.Undef, t_1096, X_1097);
return t_1096;
return default;
}, 2, "yay", false)).Put("oops", Fn((V _self1098, int _argc1099, V t_1105, V _a1102, V _a1103, V _a1104, V[] _rest1100) => {
if (_self1098.IsNullish) _self1098 = GlobalV;
Call(frown_48, V.Undef, t_1105);
return t_1105;
return default;
}, 1, "oops", false)).Put("watch", Fn((V _self1106, int _argc1107, V t_1113, V _a1110, V _a1111, V _a1112, V[] _rest1108) => {
if (_self1106.IsNullish) _self1106 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_1113, "to", ((V)(320D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-15D)))), NewObj(5).Put("armR", ((V)(118D))).Put("lx", ((V)(0.9))).Put("ly", ((V)((-0.2)))).Put("htilt", ((V)(6D))).Put("lean", ((V)(0.4))).V), ((V)("io"))), "wait", ((V)(900D))), "to", ((V)(240D)), NewObj(2).Put("lx", ((V)(0.6))).Put("ly", ((V)(0.2))).V), "wait", ((V)(400D)));
return Invoke(t_1113, "back", ((V)(380D)));
return default;
}, 1, "watch", false)).Put("pant", Fn((V _self1114, int _argc1115, V t_1121, V _a1118, V _a1119, V _a1120, V[] _rest1116) => {
V Q_1122 = default;
if (_self1114.IsNullish) _self1114 = GlobalV;
Q_1122 = (Get(Get(t_1121, "B"), "sq") is var _t1123 && Truthy(_t1123) ? _t1123 : ((V)(0D)));
Invoke(Invoke(Invoke(t_1121, "to", ((V)(200D)), NewObj(4).Put("open", ((V)(0.45))).Put("mw", ((V)(0.7))).Put("tongue", ((V)(0.4))).Put("close", ((V)(0.3))).V), "osc", ((V)(1200D)), ((V)(8D)), NewObj(1).Put("sq", Add(Q_1122, ((V)(0.03)))).V, NewObj(1).Put("sq", ((V)((ToNum(Q_1122) - 0.01)))).V, ((V)("l"))), "fx", ((V)("sweat")), ((V)("head")), ((V)(1D)));
return Invoke(t_1121, "back", ((V)(300D)));
return default;
}, 1, "pant", false)).Put("clap", Fn((V _self1124, int _argc1125, V t_1131, V _a1128, V _a1129, V _a1130, V[] _rest1126) => {
if (_self1124.IsNullish) _self1124 = GlobalV;
Invoke(t_1131, "to", ((V)(240D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(10D)), ((V)((-6D)))), NewObj(5).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V), ((V)("o")));
{
double i_1132 = 0;
i_1132 = 0D;
while (true) {
if (!((i_1132 < 5D))) break;
Invoke(Invoke(t_1131, "to", ((V)(110D)), NewObj(2).Put("hLx", ((V)(6D))).Put("hRx", ((V)((-6D)))).V, ((V)("l"))), "to", ((V)(110D)), NewObj(2).Put("hLx", ((V)(11D))).Put("hRx", ((V)((-11D)))).V, ((V)("l")));
i_1132++;
}
}
return Invoke(t_1131, "back", ((V)(340D)));
return default;
}, 1, "clap", false)).V;
BW0_52 = Call(S0_39, V.Undef, NewObj(7).Put("pitch", ((V)((-0.3)))).Put("ly", ((V)(0.9))).Put("sq", ((V)(0.07))).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("smile", ((V)(0.8))).Put("hap", ((V)(0.4))).V, Call(both_15, V.Undef, ((V)(4D)), ((V)(4D))));
BWB_53 = NewObj(6).Put("munch", Fn((V _self1134, int _argc1135, V t_1141, V X_1142, V rec_1143, V _a1140, V[] _rest1136) => {
V B_1144 = default;
if (_self1134.IsNullish) _self1134 = GlobalV;
B_1144 = Get(t_1141, "B");
Invoke(t_1141, "to", ((V)(260D)), NewObj(4).Put("pitch", ((V)((ToNum(Get(B_1144, "pitch")) - 0.12)))).Put("sq", Add(Get(B_1144, "sq"), ((V)(0.03)))).Put("lift", ((V)((-0.6)))).Put("open", ((V)(0.4))).V, ((V)("io")));
Call(push_46, V.Undef, rec_1143, ((V)("bite")), Get(t_1141, "t"));
Invoke(Invoke(Invoke(t_1141, "osc", ((V)(1200D)), ((V)(4D)), NewObj(2).Put("open", ((V)(0.42))).Put("puff", ((V)(0.15))).V, NewObj(2).Put("open", ((V)(0D))).Put("puff", ((V)(0.5))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("mouth")), ((V)(3D))), "osc", ((V)(600D)), ((V)(2D)), NewObj(1).Put("open", ((V)(0.38))).V, NewObj(2).Put("open", ((V)(0D))).Put("puff", ((V)(0.4))).V, ((V)("l")));
return Invoke(t_1141, "back", ((V)(300D)));
return default;
}, 3, "munch", false)).Put("up", Fn((V _self1145, int _argc1146, V t_1152, V _a1149, V _a1150, V _a1151, V[] _rest1147) => {
if (_self1145.IsNullish) _self1145 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_1152, "to", ((V)(340D)), NewObj(5).Put("pitch", ((V)(0.04))).Put("ly", ((V)((-0.1)))).Put("lx", ((V)(0.5))).Put("sq", ((V)(0D))).Put("puff", ((V)(0.4))).V, ((V)("io"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(1).Put("puff", ((V)(0.55))).V, NewObj(1).Put("puff", ((V)(0.2))).V, ((V)("l"))), "to", ((V)(420D)), NewObj(2).Put("lx", ((V)((-0.5)))).Put("htilt", ((V)((-4D)))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(3D)), NewObj(1).Put("puff", ((V)(0.5))).V, NewObj(1).Put("puff", ((V)(0.15))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(1).Put("puff", ((V)(0D))).V);
return Invoke(t_1152, "back", ((V)(380D)));
return default;
}, 1, "up", false)).Put("slurp", Fn((V _self1153, int _argc1154, V t_1160, V _a1157, V _a1158, V _a1159, V[] _rest1155) => {
V B_1161 = default;
if (_self1153.IsNullish) _self1153 = GlobalV;
B_1161 = Get(t_1160, "B");
Invoke(Invoke(Invoke(Invoke(t_1160, "to", ((V)(280D)), NewObj(3).Put("pitch", ((V)((ToNum(Get(B_1161, "pitch")) - 0.16)))).Put("sq", Add(Get(B_1161, "sq"), ((V)(0.04)))).Put("close", ((V)(0.6))).V, ((V)("io"))), "osc", ((V)(1100D)), ((V)(6D)), NewObj(2).Put("tongue", ((V)(0.6))).Put("sq", Add(Get(B_1161, "sq"), ((V)(0.05)))).V, NewObj(2).Put("tongue", ((V)(0.1))).Put("sq", Add(Get(B_1161, "sq"), ((V)(0.03)))).V, ((V)("l"))), "fx", ((V)("drop")), ((V)("mouth")), ((V)(3D))), "to", ((V)(160D)), NewObj(1).Put("tongue", ((V)(0D))).V);
return Invoke(t_1160, "back", ((V)(320D)));
return default;
}, 1, "slurp", false)).Put("lick", Fn((V _self1162, int _argc1163, V t_1169, V _a1166, V _a1167, V _a1168, V[] _rest1164) => {
if (_self1162.IsNullish) _self1162 = GlobalV;
Invoke(Invoke(Invoke(t_1169, "to", ((V)(300D)), NewObj(4).Put("pitch", ((V)((-0.04)))).Put("ly", ((V)(0D))).Put("close", ((V)(0.5))).Put("smile", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(1000D)), ((V)(4D)), NewObj(1).Put("tongue", ((V)(0.65))).V, NewObj(1).Put("tongue", ((V)(0.15))).V, ((V)("s"))), "to", ((V)(160D)), NewObj(1).Put("tongue", ((V)(0D))).V);
return Invoke(t_1169, "back", ((V)(360D)));
return default;
}, 1, "lick", false)).Put("tummy", Fn((V _self1170, int _argc1171, V t_1177, V X_1178, V _a1175, V _a1176, V[] _rest1172) => {
if (_self1170.IsNullish) _self1170 = GlobalV;
Invoke(BEAT_13, "belly", t_1177, ((V)((-1D))));
Invoke(Invoke(Invoke(t_1177, "to", ((V)(240D)), Call(o_21, V.Undef, NewObj(3).Put("smile", ((V)(1D))).Put("hap", ((V)(1D))).Put("sqz", ((V)(0.6))).V, Get(X_1178, "cheer")), ((V)("o"))), "fx", ((V)("heart")), ((V)("head")), ((V)(2D))), "wait", ((V)(300D)));
return Invoke(t_1177, "back", ((V)(380D)));
return default;
}, 2, "tummy", false)).Put("hic", Fn((V _self1179, int _argc1180, V t_1186, V _a1183, V _a1184, V _a1185, V[] _rest1181) => {
V B_1187 = default;
if (_self1179.IsNullish) _self1179 = GlobalV;
B_1187 = Get(t_1186, "B");
{
double i_1188 = 0;
i_1188 = 0D;
while (true) {
if (!((i_1188 < 2D))) break;
Invoke(Invoke(Invoke(Invoke(t_1186, "to", ((V)(80D)), NewObj(4).Put("sq", ((V)((ToNum(Get(B_1187, "sq")) - 0.07)))).Put("lift", ((V)(1.8))).Put("wide", ((V)(0.9))).Put("open", ((V)(0.2))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("sq", Get(B_1187, "sq")).Put("lift", ((V)(0D))).V, ((V)("i"))), "fx", ((V)("bubble")), ((V)("mouth")), ((V)(1D))), "wait", ((V)(420D)));
i_1188++;
}
}
Invoke(BEAT_13, "giggle", t_1186, ((V)((-1D))));
return t_1186;
return default;
}, 1, "hic", false)).V;
DS0_54 = Call(S0_39, V.Undef, NewObj(5).Put("pitch", ((V)((-0.16)))).Put("ly", ((V)(0.7))).Put("armL", ((V)(28D))).Put("armR", ((V)(30D))).Put("smile", ((V)(0.6))).V, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(8D)), ((V)((-1D)))), Call(hand_14, V.Undef, ((V)(1D)), ((V)(6D)), ((V)(0D))));
DSB_55 = NewObj(5).Put("scrub", Fn((V _self1190, int _argc1191, V t_1197, V X_1198, V rec_1199, V _a1196, V[] _rest1192) => {
V B_1200 = default;
V a_1201 = default;
if (_self1190.IsNullish) _self1190 = GlobalV;
B_1200 = Get(t_1197, "B");
a_1201 = Get(t_1197, "t");
Invoke(t_1197, "to", ((V)(200D)), NewObj(2).Put("sqz", ((V)(0.3))).Put("smile", ((V)(0.9))).V);
{
double i_1202 = 0;
i_1202 = 0D;
while (true) {
if (!((i_1202 < 8D))) break;
Invoke(Invoke(t_1197, "to", ((V)(115D)), NewObj(2).Put("hRx", ((V)((ToNum(Get(B_1200, "hRx")) - 2.4)))).Put("hRy", ((V)((ToNum(Get(B_1200, "hRy")) - 1.6)))).V, ((V)("l"))), "to", ((V)(115D)), NewObj(2).Put("hRx", Add(Get(B_1200, "hRx"), ((V)(1D)))).Put("hRy", Add(Get(B_1200, "hRy"), ((V)(1.4)))).V, ((V)("l")));
if (((i_1202 % 3D) == 0D)) {
Invoke(t_1197, "fx", ((V)("foam")), ((V)("pawR")), ((V)(2D)));
}
i_1202++;
}
}
Call(push_46, V.Undef, rec_1199, ((V)("sc")), Arr(a_1201, Get(t_1197, "t")));
return Invoke(t_1197, "back", ((V)(260D)));
return default;
}, 3, "scrub", false)).Put("rinse", Fn((V _self1204, int _argc1205, V t_1211, V _a1208, V _a1209, V _a1210, V[] _rest1206) => {
V B_1212 = default;
if (_self1204.IsNullish) _self1204 = GlobalV;
B_1212 = Get(t_1211, "B");
Invoke(Invoke(Invoke(Invoke(t_1211, "to", ((V)(300D)), NewObj(5).Put("hLy", Add(Get(B_1212, "hLy"), ((V)(3D)))).Put("hRy", Add(Get(B_1212, "hRy"), ((V)(3D)))).Put("armL", ((V)(22D))).Put("armR", ((V)(24D))).Put("ly", ((V)(0.9))).V, ((V)("io"))), "osc", ((V)(1100D)), ((V)(4D)), NewObj(2).Put("tilt", ((V)(3D))).Put("hLx", Add(Get(B_1212, "hLx"), ((V)(1.4)))).V, NewObj(2).Put("tilt", ((V)((-3D)))).Put("hLx", ((V)((ToNum(Get(B_1212, "hLx")) - 1D)))).V, ((V)("s"))), "fx", ((V)("drop")), ((V)("pawL")), ((V)(4D))), "fx", ((V)("splash")), ((V)("pawL")), ((V)(2D)));
return Invoke(t_1211, "back", ((V)(320D)));
return default;
}, 1, "rinse", false)).Put("squeak", Fn((V _self1213, int _argc1214, V t_1220, V _a1217, V _a1218, V _a1219, V[] _rest1215) => {
V B_1221 = default;
if (_self1213.IsNullish) _self1213 = GlobalV;
B_1221 = Get(t_1220, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(t_1220, "to", ((V)(380D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)((-11D)))), NewObj(5).Put("armL", ((V)(54D))).Put("pitch", Add(Get(B_1221, "pitch"), ((V)(0.22)))).Put("ly", ((V)((-0.3)))).Put("lx", ((V)((-0.5)))).Put("wide", ((V)(0.5))).V), ((V)("io"))), "fx", ((V)("spark")), ((V)("pawL")), ((V)(4D))), "to", ((V)(200D)), NewObj(4).Put("winkR", ((V)(1D))).Put("sqz", ((V)(0.5))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.7))).V, ((V)("o"))), "wait", ((V)(500D))), "to", ((V)(160D)), NewObj(1).Put("winkR", ((V)(0D))).V);
return Invoke(t_1220, "back", ((V)(400D)));
return default;
}, 1, "squeak", false)).Put("stack", Fn((V _self1222, int _argc1223, V t_1229, V X_1230, V rec_1231, V _a1228, V[] _rest1224) => {
V B_1232 = default;
V a_1233 = default;
if (_self1222.IsNullish) _self1222 = GlobalV;
B_1232 = Get(t_1229, "B");
a_1233 = Get(t_1229, "t");
Invoke(Invoke(t_1229, "to", ((V)(420D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(16D)), ((V)(2D))), NewObj(5).Put("armL", ((V)(34D))).Put("lean", ((V)(0.8))).Put("tilt", ((V)(3D))).Put("lx", ((V)(0.8))).Put("ly", ((V)(0.6))).V), ((V)("io"))), "to", ((V)(140D)), NewObj(2).Put("hLy", ((V)(4D))).Put("sq", Add(Get(B_1232, "sq"), ((V)(0.03)))).V, ((V)("i")));
Call(push_46, V.Undef, rec_1231, ((V)("st")), Arr(a_1233, Get(t_1229, "t")));
Invoke(t_1229, "wait", ((V)(200D)));
return Invoke(t_1229, "back", ((V)(420D)));
return default;
}, 3, "stack", false)).Put("bubble", Fn((V _self1234, int _argc1235, V t_1241, V _a1238, V _a1239, V _a1240, V[] _rest1236) => {
if (_self1234.IsNullish) _self1234 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_1241, "to", ((V)(260D)), NewObj(5).Put("puff", ((V)(0.8))).Put("open", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)((-0.4)))).Put("pitch", ((V)(0.12))).V), "to", ((V)(500D)), NewObj(3).Put("puff", ((V)(0.2))).Put("open", ((V)(0.2))).Put("mw", ((V)(0.4))).V, ((V)("s"))), "fx", ((V)("bubble")), ((V)("mouth")), ((V)(2D))), "to", ((V)(200D)), NewObj(4).Put("wide", ((V)(0.8))).Put("open", ((V)(0.4))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(300D)));
Invoke(BEAT_13, "giggle", t_1241, ((V)(1D)));
return t_1241;
return default;
}, 1, "bubble", false)).V;
PLATE_56 = Fn((V _self2, int _argc1242, V d_1248, V _a1245, V _a1246, V _a1247, V[] _rest1243) => {
return ((V)(string.Concat("<ellipse cx=\"0\" cy=\"0\" rx=\"6\" ry=\"2.4\" fill=\"#ffffff\" stroke=\"#9fb4c9\" stroke-width=\"0.45\"/><ellipse cx=\"0\" cy=\"-0.2\" rx=\"3.8\" ry=\"1.3\" fill=\"none\" stroke=\"#5ab4f0\" stroke-width=\"0.4\" opacity=\"0.8\"/>", (GtN(d_1248, 0.03) ? string.Concat(new string[] { "<g opacity=\"", ToStr(Call(r2_30, V.Undef, d_1248)), "\">", ToStr(Call(ci_32, V.Undef, ((V)((-2D))), ((V)((-0.2))), ((V)(0.9)), ((V)("#c9a46a")))), ToStr(Call(ci_32, V.Undef, ((V)(1.6)), ((V)(0.4)), ((V)(0.7)), ((V)("#b9864a")))), ToStr(Call(ci_32, V.Undef, ((V)(0.4)), ((V)((-0.6))), ((V)(0.5)), ((V)("#d9b07a")))), "</g>" }) : ""))));
}, 1, "", true);
SPONGE_57 = ((V)("<rect x=\"-2.4\" y=\"-1.6\" width=\"4.8\" height=\"3.2\" rx=\"0.7\" fill=\"#ffd24a\" stroke=\"#d9a22a\" stroke-width=\"0.35\"/><rect x=\"-2.4\" y=\"-1.6\" width=\"4.8\" height=\"1.1\" rx=\"0.5\" fill=\"#7cc35a\" stroke=\"#4f8f3a\" stroke-width=\"0.3\"/>"));
GR0_59 = Call(S0_39, V.Undef, NewObj(6).Put("pitch", ((V)((-0.12)))).Put("ly", ((V)(0.6))).Put("armR", ((V)(40D))).Put("armL", ((V)(18D))).Put("smile", ((V)(0.8))).Put("hap", ((V)(0.4))).V, Call(hand_14, V.Undef, ((V)(1D)), ((V)(2D)), ((V)((-4D)))), Call(hand_14, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)(2D))));
GRB_60 = NewObj(6).Put("poke", Fn((V _self1249, int _argc1250, V t_1256, V _a1253, V _a1254, V _a1255, V[] _rest1251) => {
V B_1257 = default;
if (_self1249.IsNullish) _self1249 = GlobalV;
B_1257 = Get(t_1256, "B");
Invoke(Invoke(Invoke(t_1256, "to", ((V)(200D)), NewObj(1).Put("sqz", ((V)(0.2))).V), "osc", ((V)(1000D)), ((V)(4D)), NewObj(2).Put("hRy", Add(Get(B_1257, "hRy"), ((V)(2.4)))).Put("armR", ((V)((ToNum(Get(B_1257, "armR")) - 4D)))).V, NewObj(2).Put("hRy", Get(B_1257, "hRy")).Put("armR", Get(B_1257, "armR")).V, ((V)("io"))), "fx", ((V)("gust")), ((V)("pawR")), ((V)(1D)));
return Invoke(t_1256, "back", ((V)(260D)));
return default;
}, 1, "poke", false)).Put("flip", Fn((V _self1258, int _argc1259, V t_1265, V X_1266, V rec_1267, V _a1264, V[] _rest1260) => {
V B_1268 = default;
if (_self1258.IsNullish) _self1258 = GlobalV;
B_1268 = Get(t_1265, "B");
Invoke(t_1265, "to", ((V)(240D)), NewObj(4).Put("hRy", Add(Get(B_1268, "hRy"), ((V)(3D)))).Put("armR", ((V)((ToNum(Get(B_1268, "armR")) - 8D)))).Put("sq", Add(Get(B_1268, "sq"), ((V)(0.04)))).Put("wide", ((V)(0.3))).V, ((V)("io")));
Call(push_46, V.Undef, rec_1267, ((V)("fl")), Get(t_1265, "t"));
Invoke(t_1265, "to", ((V)(150D)), NewObj(7).Put("hRy", ((V)((ToNum(Get(B_1268, "hRy")) - 7D)))).Put("armR", Add(Get(B_1268, "armR"), ((V)(30D)))).Put("sq", ((V)((ToNum(Get(B_1268, "sq")) - 0.03)))).Put("ly", ((V)((-0.6)))).Put("pitch", Add(Get(B_1268, "pitch"), ((V)(0.2)))).Put("open", ((V)(0.4))).Put("mw", ((V)(0.6))).V, ((V)("o")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_1265, "to", ((V)(320D)), NewObj(3).Put("ly", ((V)((-0.9)))).Put("pitch", Add(Get(B_1268, "pitch"), ((V)(0.28)))).Put("wide", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(330D)), NewObj(4).Put("ly", Get(B_1268, "ly")).Put("pitch", Get(B_1268, "pitch")).Put("hRy", Get(B_1268, "hRy")).Put("armR", Get(B_1268, "armR")).V, ((V)("i"))), "fx", ((V)("gust")), ((V)("pawR")), ((V)(1D))), "to", ((V)(220D)), NewObj(6).Put("sqz", ((V)(0.7))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("mw", ((V)(1D))).Put("wide", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(300D)));
return Invoke(t_1265, "back", ((V)(320D)));
return default;
}, 3, "flip", false)).Put("smoke", Fn((V _self1269, int _argc1270, V t_1276, V _a1273, V _a1274, V _a1275, V[] _rest1271) => {
V B_1277 = default;
if (_self1269.IsNullish) _self1269 = GlobalV;
B_1277 = Get(t_1276, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(t_1276, "to", ((V)(260D)), NewObj(5).Put("lean", ((V)((-1D)))).Put("pitch", Add(Get(B_1277, "pitch"), ((V)(0.14)))).Put("close", ((V)(0.8))).Put("sqz", ((V)(0.9))).Put("puff", ((V)(0.4))).V, ((V)("o"))), "osc", ((V)(1200D)), ((V)(5D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(2D)), ((V)((-6D)))), NewObj(1).Put("armL", ((V)(72D))).V), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(2D)), ((V)((-4D)))), NewObj(1).Put("armL", ((V)(44D))).V), ((V)("io"))), "fx", ((V)("sweat")), ((V)("head")), ((V)(1D))), "to", ((V)(220D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("mouth")), ((V)(1D)));
return Invoke(t_1276, "back", ((V)(400D)));
return default;
}, 1, "smoke", false)).Put("season", Fn((V _self1278, int _argc1279, V t_1285, V _a1282, V _a1283, V _a1284, V[] _rest1280) => {
if (_self1278.IsNullish) _self1278 = GlobalV;
Invoke(Invoke(Invoke(t_1285, "to", ((V)(320D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(4D)), ((V)((-6D)))), NewObj(2).Put("armL", ((V)(64D))).Put("lx", ((V)(0.4))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(5D)), NewObj(2).Put("hLy", ((V)((-8D)))).Put("tilt", ((V)(1D))).V, NewObj(2).Put("hLy", ((V)((-5D)))).Put("tilt", ((V)((-1D)))).V, ((V)("l"))), "fx", ((V)("sand")), ((V)("pawL")), ((V)(4D)));
return Invoke(t_1285, "back", ((V)(320D)));
return default;
}, 1, "season", false)).Put("sniff", Fn((V _self1286, int _argc1287, V t_1293, V _a1290, V _a1291, V _a1292, V[] _rest1288) => {
if (_self1286.IsNullish) _self1286 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_1293, "to", ((V)(380D)), NewObj(5).Put("pitch", ((V)((-0.04)))).Put("close", ((V)(0.7))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.7))).Put("puff", ((V)(0.2))).V, ((V)("s"))), "fx", ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(600D))), "to", ((V)(200D)), NewObj(3).Put("close", ((V)(0D))).Put("wide", ((V)(0.4))).Put("puff", ((V)(0D))).V, ((V)("o")));
return Invoke(t_1293, "back", ((V)(360D)));
return default;
}, 1, "sniff", false)).Put("serve", Fn((V _self1294, int _argc1295, V t_1301, V X_1302, V rec_1303, V _a1300, V[] _rest1296) => {
V a_1304 = default;
if (_self1294.IsNullish) _self1294 = GlobalV;
a_1304 = Get(t_1301, "t");
Invoke(t_1301, "to", ((V)(320D)), Call(o_21, V.Undef, NewObj(9).Put("armR", ((V)(140D))).Put("hRy", ((V)((-10D)))).Put("hRx", ((V)(2D))).Put("ly", ((V)((-0.6)))).Put("pitch", ((V)(0.12))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.5))).Put("wide", ((V)(0.4))).V, Get(X_1302, "cheer")), ((V)("o")));
if (Truthy(Get(X_1302, "cheerFx"))) {
InvokeSpread(t_1301, "fx", new ArrBuilder().Spread(Get(X_1302, "cheerFx")).V);
} else {
Invoke(t_1301, "fx", ((V)("spark")), ((V)("pawR")), ((V)(3D)));
}
Invoke(t_1301, "wait", ((V)(800D)));
Call(push_46, V.Undef, rec_1303, ((V)("sv")), Arr(a_1304, Get(t_1301, "t")));
return Invoke(t_1301, "back", ((V)(420D)));
return default;
}, 3, "serve", false)).V;
TONGS_61 = ((V)("<path d=\"M0-0.6L13-1.6M0 0.6L13 1.6\" stroke=\"#9aa3b2\" stroke-width=\"0.9\" stroke-linecap=\"round\"/><path d=\"M-2.4-0.8H1V0.8H-2.4Z\" fill=\"#3b2a24\"/><path d=\"M12.4-2.4L14.2-1.2M12.4 2.4L14.2 1.2\" stroke=\"#7a8392\" stroke-width=\"0.7\" stroke-linecap=\"round\"/>"));
PATTY_62 = Fn((V _self2, int _argc1305, V k_1311, V _a1308, V _a1309, V _a1310, V[] _rest1306) => {
return ((V)(string.Concat(new string[] { "<ellipse cx=\"0\" cy=\"0\" rx=\"4.4\" ry=\"1.7\" fill=\"", ToStr(Call(mixC_45, V.Undef, ((V)("#e98a8a")), ((V)("#7a4428")), k_1311)), "\" stroke=\"#5a3018\" stroke-width=\"0.4\"/><path d=\"M-2.6-0.3H2.6M-1.6 0.6H1.8\" stroke=\"#3a1e10\" stroke-width=\"0.45\" opacity=\"", ToStr(Call(r2_30, V.Undef, ((V)((ToNum(k_1311) * 0.8))))), "\"/><ellipse cx=\"-1.4\" cy=\"-0.7\" rx=\"1.4\" ry=\"0.4\" fill=\"#ffffff\" opacity=\"0.25\"/>" })));
}, 1, "", true);
TW0_64 = Call(S0_39, V.Undef, NewObj(3).Put("lx", ((V)(0.7))).Put("ly", ((V)(0.4))).Put("pitch", ((V)((-0.04)))).V);
TWB_65 = NewObj(3).Put("tap", Fn((V _self1312, int _argc1313, V t_1319, V _a1316, V _a1317, V _a1318, V[] _rest1314) => {
if (_self1312.IsNullish) _self1312 = GlobalV;
Invoke(Invoke(t_1319, "to", ((V)(300D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(4D)), ((V)(4D))), NewObj(3).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("close", ((V)(0.3))).V)), "osc", ((V)(1500D)), ((V)(6D)), NewObj(1).Put("footR", ((V)(1.4))).V, NewObj(1).Put("footR", ((V)(0D))).V, ((V)("o")));
return Invoke(t_1319, "back", ((V)(300D)));
return default;
}, 1, "tap", false)).Put("peek", Fn((V _self1320, int _argc1321, V t_1327, V _a1324, V _a1325, V _a1326, V[] _rest1322) => {
if (_self1320.IsNullish) _self1320 = GlobalV;
Invoke(Invoke(Invoke(t_1327, "to", ((V)(380D)), NewObj(6).Put("lean", ((V)(0.9))).Put("pitch", ((V)((-0.22)))).Put("lx", ((V)(0.9))).Put("ly", ((V)(0.8))).Put("wide", ((V)(0.6))).Put("sq", ((V)(0.04))).V, ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(200D)), NewObj(1).Put("wide", ((V)(0.2))).V);
return Invoke(t_1327, "back", ((V)(380D)));
return default;
}, 1, "peek", false)).Put("rub", Fn((V _self1328, int _argc1329, V t_1335, V _a1332, V _a1333, V _a1334, V[] _rest1330) => {
if (_self1328.IsNullish) _self1328 = GlobalV;
Invoke(Invoke(t_1335, "to", ((V)(300D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(9D)), ((V)((-5D)))), NewObj(5).Put("armL", ((V)(36D))).Put("armR", ((V)(36D))).Put("sqz", ((V)(0.6))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V), ((V)("io"))), "osc", ((V)(1100D)), ((V)(6D)), NewObj(2).Put("hLx", ((V)(11D))).Put("hRx", ((V)((-7D)))).V, NewObj(2).Put("hLx", ((V)(7D))).Put("hRx", ((V)((-11D)))).V, ((V)("l")));
return Invoke(t_1335, "back", ((V)(340D)));
return default;
}, 1, "rub", false)).V;
TOAST_66 = ((V)("<path d=\"M-3-3Q-3.6-4.6-2-4.8Q0-5.6 2-4.8Q3.6-4.6 3-3V3.2H-3Z\" fill=\"#d9964a\" stroke=\"#9a5a24\" stroke-width=\"0.45\"/><path d=\"M-2.2-2.8Q-2.4-3.8-1.4-3.9Q0-4.5 1.4-3.9Q2.4-3.8 2.2-2.8V2.4H-2.2Z\" fill=\"#f2d08a\"/>"));
POB_68 = NewObj(3).Put("big", Fn((V _self1336, int _argc1337, V t_1343, V X_1344, V _a1341, V _a1342, V[] _rest1338) => {
V B_1345 = default;
V L_1346 = default;
V Q_1347 = default;
if (_self1336.IsNullish) _self1336 = GlobalV;
B_1345 = Get(t_1343, "B");
L_1346 = (Get(B_1345, "lift") is var _t1348 && Truthy(_t1348) ? _t1348 : ((V)(0D)));
Q_1347 = (Get(B_1345, "sq") is var _t1349 && Truthy(_t1349) ? _t1349 : ((V)(0D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_1343, "to", ((V)(160D)), NewObj(2).Put("sq", Add(Q_1347, ((V)(0.14)))).Put("lift", ((V)((ToNum(L_1346) - 1D)))).V, ((V)("i"))), "to", ((V)(300D)), Call(o_21, V.Undef, NewObj(7).Put("sq", ((V)((ToNum(Q_1347) - 0.1)))).Put("lift", Add(L_1346, ((V)(8D)))).Put("armL", ((V)(130D))).Put("armR", ((V)(130D))).Put("open", ((V)(0.5))).Put("hap", ((V)(1D))).Put("wide", ((V)(0.4))).V, (Get(X_1344, "tk") is var _t1350 && Truthy(_t1350) ? _t1350 : NewObj(0).V)), ((V)("o"))), "to", ((V)(280D)), NewObj(4).Put("lift", L_1346).Put("sq", Add(Q_1347, ((V)(0.22)))).Put("armL", Get(B_1345, "armL")).Put("armR", Get(B_1345, "armR")).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)((ToNum(Q_1347) - 0.04)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("sq", Q_1347).V, ((V)("io")));
return Invoke(t_1343, "back", ((V)(300D)));
return default;
}, 2, "big", false)).Put("rock", Fn((V _self1351, int _argc1352, V t_1358, V _a1355, V _a1356, V _a1357, V[] _rest1353) => {
V L_1359 = default;
if (_self1351.IsNullish) _self1351 = GlobalV;
L_1359 = (Get(Get(t_1358, "B"), "lift") is var _t1360 && Truthy(_t1360) ? _t1360 : ((V)(0D)));
Invoke(t_1358, "osc", ((V)(1600D)), ((V)(4D)), NewObj(3).Put("tilt", ((V)(6D))).Put("lift", Add(L_1359, ((V)(1.6)))).Put("x", ((V)(1D))).V, NewObj(3).Put("tilt", ((V)((-6D)))).Put("lift", Add(L_1359, ((V)(1.6)))).Put("x", ((V)((-1D)))).V, ((V)("s")));
return Invoke(t_1358, "back", ((V)(300D)));
return default;
}, 1, "rock", false)).Put("spinb", Fn((V _self1361, int _argc1362, V t_1368, V _a1365, V _a1366, V _a1367, V[] _rest1363) => {
V L_1369 = default;
V Q_1370 = default;
if (_self1361.IsNullish) _self1361 = GlobalV;
L_1369 = (Get(Get(t_1368, "B"), "lift") is var _t1371 && Truthy(_t1371) ? _t1371 : ((V)(0D)));
Q_1370 = (Get(Get(t_1368, "B"), "sq") is var _t1372 && Truthy(_t1372) ? _t1372 : ((V)(0D)));
Invoke(Invoke(Invoke(Invoke(t_1368, "to", ((V)(140D)), NewObj(1).Put("sq", Add(Q_1370, ((V)(0.12)))).V, ((V)("i"))), "to", ((V)(500D)), NewObj(4).Put("spin", ((V)(360D))).Put("lift", Add(L_1369, ((V)(5D)))).Put("sq", ((V)((ToNum(Q_1370) - 0.06)))).Put("hap", ((V)(1D))).V, ((V)("io"))), "to", ((V)(10D)), NewObj(1).Put("spin", ((V)(0D))).V), "to", ((V)(200D)), NewObj(2).Put("lift", L_1369).Put("sq", Add(Q_1370, ((V)(0.12)))).V, ((V)("i")));
return Invoke(t_1368, "back", ((V)(260D)));
return default;
}, 1, "spinb", false)).V;
SP0_69 = Call(o_21, V.Undef, BATH0_36, NewObj(10).Put("wd", ((V)(0.48))).Put("sk", ((V)(5D))).Put("fm", ((V)(0D))).Put("dk", ((V)(0D))).Put("dkx", ((V)(0D))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).Put("close", ((V)(0D))).V, Call(both_15, V.Undef, ((V)(2D)), ((V)((-2D)))));
SPB_70 = NewObj(6).Put("slap", Fn((V _self1373, int _argc1374, V t_1380, V _a1377, V _a1378, V _a1379, V[] _rest1375) => {
V Q_1381 = default;
if (_self1373.IsNullish) _self1373 = GlobalV;
Q_1381 = (Get(Get(t_1380, "B"), "sq") is var _t1382 && Truthy(_t1382) ? _t1382 : ((V)(0D)));
{
double i_1383 = 0;
i_1383 = 0D;
while (true) {
if (!((i_1383 < 3D))) break;
Invoke(Invoke(Invoke(t_1380, "to", ((V)(200D)), NewObj(6).Put("armL", ((V)(96D))).Put("armR", ((V)(96D))).Put("hLy", ((V)((-6D)))).Put("hRy", ((V)((-6D)))).Put("open", ((V)(0.4))).Put("hap", ((V)(1D))).V, ((V)("o"))), "to", ((V)(130D)), NewObj(6).Put("armL", ((V)(26D))).Put("armR", ((V)(26D))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).Put("sq", Add(Q_1381, ((V)(0.05)))).Put("sqz", ((V)(0.6))).V, ((V)("i"))), "fx", ((V)("splash")), ((V)("body")), ((V)(5D)));
i_1383++;
}
}
return Invoke(t_1380, "back", ((V)(320D)));
return default;
}, 1, "slap", false)).Put("kick", Fn((V _self1385, int _argc1386, V t_1392, V _a1389, V _a1390, V _a1391, V[] _rest1387) => {
V B_1393 = default;
V Q_1394 = default;
if (_self1385.IsNullish) _self1385 = GlobalV;
B_1393 = Get(t_1392, "B");
Q_1394 = (Get(B_1393, "sq") is var _t1395 && Truthy(_t1395) ? _t1395 : ((V)(0D)));
Invoke(Invoke(Invoke(Invoke(t_1392, "to", ((V)(200D)), NewObj(2).Put("lean", ((V)((-0.6)))).Put("pitch", Add((Get(B_1393, "pitch") is var _t1396 && Truthy(_t1396) ? _t1396 : ((V)(0D))), ((V)(0.12)))).V), "osc", ((V)(1200D)), ((V)(6D)), NewObj(3).Put("footL", ((V)(3D))).Put("footR", ((V)(0D))).Put("sq", Add(Q_1394, ((V)(0.02)))).V, NewObj(3).Put("footL", ((V)(0D))).Put("footR", ((V)(3D))).Put("sq", Q_1394).V, ((V)("l"))), "fx", ((V)("splash")), ((V)("belly")), ((V)(4D))), "fx", ((V)("drop")), ((V)("belly")), ((V)(3D)));
return Invoke(t_1392, "back", ((V)(320D)));
return default;
}, 1, "kick", false)).Put("soak", Fn((V _self1397, int _argc1398, V t_1404, V _a1401, V _a1402, V _a1403, V[] _rest1399) => {
V B_1405 = default;
if (_self1397.IsNullish) _self1397 = GlobalV;
B_1405 = Get(t_1404, "B");
Invoke(Invoke(t_1404, "to", ((V)(400D)), NewObj(5).Put("pitch", Add((Get(B_1405, "pitch") is var _t1406 && Truthy(_t1406) ? _t1406 : ((V)(0D))), ((V)(0.25)))).Put("close", ((V)(0.7))).Put("wd", Add((Get(B_1405, "wd") is var _t1407 && Truthy(_t1407) ? _t1407 : ((V)(0D))), ((V)(0.18)))).Put("lean", ((V)((-0.6)))).Put("smile", ((V)(1D))).V, ((V)("s"))), "wait", ((V)(900D)));
return Invoke(t_1404, "back", ((V)(400D)), V.Null, ((V)("s")));
return default;
}, 1, "soak", false)).Put("atyou", Fn((V _self1408, int _argc1409, V t_1415, V _a1412, V _a1413, V _a1414, V[] _rest1410) => {
if (_self1408.IsNullish) _self1408 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_1415, "to", ((V)(300D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(10D)), ((V)(2D))), NewObj(7).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("sqz", ((V)(0.5))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).V), ((V)("io"))), "to", ((V)(140D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(8D)), ((V)((-10D)))), NewObj(3).Put("armL", ((V)(80D))).Put("armR", ((V)(80D))).Put("open", ((V)(0.5))).V), ((V)("o"))), "fx", ((V)("splash")), ((V)("head")), ((V)(7D))), "fx", ((V)("drop")), ((V)("head")), ((V)(4D))), "wait", ((V)(200D)));
Invoke(BEAT_13, "giggle", t_1415, ((V)(1D)));
return t_1415;
return default;
}, 1, "atyou", false)).Put("duck", Fn((V _self1416, int _argc1417, V t_1423, V _a1420, V _a1421, V _a1422, V[] _rest1418) => {
if (_self1416.IsNullish) _self1416 = GlobalV;
Invoke(Invoke(Invoke(t_1423, "to", ((V)(300D)), NewObj(5).Put("dk", ((V)(1D))).Put("dkx", ((V)(0.6))).Put("lx", ((V)(0.7))).Put("ly", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(1600D)), ((V)(2D)), NewObj(2).Put("dkx", ((V)((-0.6)))).Put("lx", ((V)((-0.7)))).V, NewObj(2).Put("dkx", ((V)(0.6))).Put("lx", ((V)(0.7))).V, ((V)("s"))), "to", ((V)(300D)), NewObj(2).Put("dk", ((V)(0D))).Put("dkx", ((V)(0D))).V);
return Invoke(t_1423, "back", ((V)(300D)));
return default;
}, 1, "duck", false)).Put("wave", Fn((V _self1424, int _argc1425, V t_1431, V _a1428, V _a1429, V _a1430, V[] _rest1426) => {
if (_self1424.IsNullish) _self1424 = GlobalV;
Invoke(BEAT_13, "wave", t_1431, ((V)(1D)));
return t_1431;
return default;
}, 1, "wave", false)).V;
PF0_74 = Call(S0_39, V.Undef, NewObj(5).Put("armR", ((V)(40D))).Put("armL", ((V)(22D))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.5))).Put("open", ((V)(0.1))).V, Call(hand_14, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-12D)))));
PFB_75 = NewObj(6).Put("sing", Fn((V _self1432, int _argc1433, V t_1439, V _a1436, V _a1437, V _a1438, V[] _rest1434) => {
if (_self1432.IsNullish) _self1432 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_1439, "to", ((V)(220D)), NewObj(3).Put("close", ((V)(0.4))).Put("open", ((V)(0.4))).Put("mw", ((V)(0.7))).V), "fx", ((V)("note")), ((V)("mouth")), ((V)(1D))), "osc", ((V)(2000D)), ((V)(4D)), NewObj(4).Put("htilt", ((V)(6D))).Put("lean", ((V)(0.6))).Put("x", ((V)(0.6))).Put("open", ((V)(0.5))).V, NewObj(4).Put("htilt", ((V)((-6D)))).Put("lean", ((V)((-0.6)))).Put("x", ((V)((-0.6)))).Put("open", ((V)(0.15))).V, ((V)("s"))), "fx", ((V)("note")), ((V)("mouth")), ((V)(1D)));
return Invoke(t_1439, "back", ((V)(360D)));
return default;
}, 1, "sing", false)).Put("belt", Fn((V _self1440, int _argc1441, V t_1447, V _a1444, V _a1445, V _a1446, V[] _rest1442) => {
if (_self1440.IsNullish) _self1440 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_1447, "to", ((V)(360D)), NewObj(9).Put("pitch", ((V)(0.24))).Put("ly", ((V)((-0.6)))).Put("armL", ((V)(128D))).Put("hLy", ((V)((-2D)))).Put("open", ((V)(0.75))).Put("mw", ((V)(0.6))).Put("close", ((V)(0.8))).Put("sq", ((V)((-0.05)))).Put("lean", ((V)((-0.4)))).V, ((V)("io"))), "fx", ((V)("note")), ((V)("mouth")), ((V)(2D))), "osc", ((V)(1200D)), ((V)(8D)), NewObj(1).Put("sq", ((V)((-0.03)))).V, NewObj(1).Put("sq", ((V)((-0.06)))).V, ((V)("l"))), "fx", ((V)("note")), ((V)("mouth")), ((V)(2D))), "to", ((V)(240D)), NewObj(1).Put("open", ((V)(0.2))).V);
return Invoke(t_1447, "back", ((V)(420D)));
return default;
}, 1, "belt", false)).Put("point", Fn((V _self1448, int _argc1449, V t_1455, V _a1452, V _a1453, V _a1454, V[] _rest1450) => {
if (_self1448.IsNullish) _self1448 = GlobalV;
Invoke(Invoke(Invoke(t_1455, "to", ((V)(300D)), NewObj(8).Put("armL", ((V)(150D))).Put("hLx", ((V)((-5D)))).Put("hLy", ((V)((-2D)))).Put("lx", ((V)((-0.7)))).Put("winkL", ((V)(1D))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.8))).Put("htilt", ((V)((-5D)))).V, ((V)("o"))), "wait", ((V)(600D))), "to", ((V)(160D)), NewObj(1).Put("winkL", ((V)(0D))).V);
return Invoke(t_1455, "back", ((V)(360D)));
return default;
}, 1, "point", false)).Put("spin", Fn((V _self1456, int _argc1457, V t_1463, V _a1460, V _a1461, V _a1462, V[] _rest1458) => {
if (_self1456.IsNullish) _self1456 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_1463, "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.06))).V), "to", ((V)(560D)), NewObj(5).Put("spin", ((V)(360D))).Put("armL", ((V)(110D))).Put("sq", ((V)((-0.04)))).Put("hap", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(10D)), NewObj(1).Put("spin", ((V)(0D))).V), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.05))).V, ((V)("o")));
return Invoke(t_1463, "back", ((V)(300D)));
return default;
}, 1, "spin", false)).Put("step", Fn((V _self1464, int _argc1465, V t_1471, V _a1468, V _a1469, V _a1470, V[] _rest1466) => {
V B_1472 = default;
if (_self1464.IsNullish) _self1464 = GlobalV;
B_1472 = Get(t_1471, "B");
{
double i_1473 = 0;
i_1473 = 0D;
while (true) {
if (!((i_1473 < 4D))) break;
double s_1475 = 0;
s_1475 = (NumTruthy((i_1473 % 2D)) ? (-1D) : 1D);
Invoke(t_1471, "to", ((V)(260D)), NewObj(5).Put("x", ((V)((s_1475 * 1.8)))).Put("footL", ((V)(((s_1475 > 0D) ? 2D : 0D)))).Put("footR", ((V)(((s_1475 > 0D) ? 0D : 2D)))).Put("tilt", ((V)((s_1475 * 3D)))).Put("armL", Add(Get(B_1472, "armL"), ((V)(20D)))).V, ((V)("io")));
i_1473++;
}
}
Invoke(t_1471, "fx", ((V)("note")), ((V)("mouth")), ((V)(1D)));
return Invoke(t_1471, "back", ((V)(300D)));
return default;
}, 1, "step", false)).Put("bow", Fn((V _self1476, int _argc1477, V t_1483, V _a1480, V _a1481, V _a1482, V[] _rest1478) => {
V B_1484 = default;
if (_self1476.IsNullish) _self1476 = GlobalV;
B_1484 = Get(t_1483, "B");
Invoke(Invoke(Invoke(t_1483, "to", ((V)(380D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(9D)), ((V)(6D))), NewObj(6).Put("armL", ((V)(14D))).Put("pitch", ((V)((-0.42)))).Put("ly", ((V)(0.8))).Put("sq", ((V)(0.1))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V), ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(320D)), NewObj(4).Put("pitch", Get(B_1484, "pitch")).Put("ly", ((V)(0D))).Put("sq", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
Invoke(BEAT_13, "wave", t_1483, ((V)((-1D))));
Invoke(t_1483, "fx", ((V)("heart")), ((V)("head")), ((V)(3D)));
return t_1483;
return default;
}, 1, "bow", false)).V;
MIC_76 = Fn((V _self2, int _argc1485, V c_1491, V _a1488, V _a1489, V _a1490, V[] _rest1486) => {
return ((V)(string.Concat(new string[] { "<rect x=\"-1\" y=\"-1.1\" width=\"9\" height=\"2.2\" rx=\"1.1\" fill=\"", ToStr(c_1491), "\" stroke=\"", ToStr(Call(shade_31, V.Undef, c_1491, ((V)(0.6)))), "\" stroke-width=\"0.4\"/><circle cx=\"10\" cy=\"0\" r=\"2.6\" fill=\"#c9cfdb\" stroke=\"#6a7080\" stroke-width=\"0.45\"/><path d=\"M8.6-1.6L11.4 1.6M8.6 1.6L11.4-1.6M10-2.4V2.4\" stroke=\"#8a90a0\" stroke-width=\"0.3\"/><path d=\"M8.8-1.4Q9.6-2.2 10.8-1.8\" stroke=\"#fff\" stroke-width=\"0.5\" fill=\"none\" opacity=\"0.8\"/>" })));
}, 1, "", true);
micProp_77 = Fn((V _self2, int _argc1492, V col_1498, V _a1495, V _a1496, V _a1497, V[] _rest1493) => {
return Fn((V _self2, int _argc1499, V I_1505, V _a1502, V _a1503, V _a1504, V[] _rest1500) => {
V W_1506 = default;
V f0_1507 = default;
V p_1508 = default;
V M_1509 = default;
double d_1510 = 0;
W_1506 = Get(I_1505, "W");
if ((!(Truthy(W_1506)) || !(Truthy(Call(okp_35, V.Undef, Get(W_1506, "pawR")))))) {
return ((V)(""));
}
f0_1507 = Call(facing_27, V.Undef, I_1505);
if (LtN(f0_1507, 0.02)) {
return ((V)(""));
}
p_1508 = Get(W_1506, "pawR");
M_1509 = (Truthy(Call(okp_35, V.Undef, Get(W_1506, "mouth"))) ? Get(W_1506, "mouth") : Arr(((V)((ToNum(GetIdx(p_1508, 0D)) - 8D))), ((V)((ToNum(GetIdx(p_1508, 1D)) - 3D)))));
d_1510 = Hypot((ToNum(GetIdx(M_1509, 0D)) - ToNum(GetIdx(p_1508, 0D))), (ToNum(GetIdx(M_1509, 1D)) - ToNum(GetIdx(p_1508, 1D))));
return Call(G_26, V.Undef, GetIdx(p_1508, 0D), GetIdx(p_1508, 1D), ((V)(((FdLibm.Atan2((ToNum(GetIdx(M_1509, 1D)) - ToNum(GetIdx(p_1508, 1D))), (ToNum(GetIdx(M_1509, 0D)) - ToNum(GetIdx(p_1508, 0D)))) * 180D) / System.Math.PI))), ((V)((ToNum(Call(cl_29, V.Undef, ((V)(((d_1510 - 2D) / 12.6))), ((V)(0.8)), ((V)(1.25)))) * 1.3))), Call(MIC_76, V.Undef, col_1498), f0_1507);
return default;
}, 1, "", true);
}, 1, "", true);
DJ0_78 = Call(S0_39, V.Undef, NewObj(6).Put("armL", ((V)(74D))).Put("armR", ((V)(26D))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.5))).Put("pitch", ((V)((-0.05)))).Put("ly", ((V)(0.3))).V, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(3D)), ((V)((-15D)))), Call(hand_14, V.Undef, ((V)(1D)), ((V)(6D)), ((V)(2D))));
DJB_79 = NewObj(6).Put("nod", Fn((V _self1511, int _argc1512, V t_1518, V _a1515, V _a1516, V _a1517, V[] _rest1513) => {
V B_1519 = default;
if (_self1511.IsNullish) _self1511 = GlobalV;
B_1519 = Get(t_1518, "B");
Invoke(Invoke(t_1518, "osc", ((V)(2000D)), ((V)(8D)), NewObj(3).Put("pitch", ((V)((ToNum(Get(B_1519, "pitch")) - 0.14)))).Put("sq", Add(Get(B_1519, "sq"), ((V)(0.04)))).Put("lift", ((V)((-0.4)))).V, NewObj(3).Put("pitch", Add(Get(B_1519, "pitch"), ((V)(0.03)))).Put("sq", ((V)((ToNum(Get(B_1519, "sq")) - 0.01)))).Put("lift", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("note")), ((V)("head")), ((V)(1D)));
return Invoke(t_1518, "back", ((V)(240D)));
return default;
}, 1, "nod", false)).Put("scratch", Fn((V _self1520, int _argc1521, V t_1527, V _a1524, V _a1525, V _a1526, V[] _rest1522) => {
V B_1528 = default;
if (_self1520.IsNullish) _self1520 = GlobalV;
B_1528 = Get(t_1527, "B");
Invoke(t_1527, "to", ((V)(200D)), NewObj(4).Put("sqz", ((V)(0.5))).Put("lean", ((V)(0.4))).Put("pitch", ((V)((ToNum(Get(B_1528, "pitch")) - 0.1)))).Put("ly", ((V)(0.7))).V);
{
double i_1529 = 0;
i_1529 = 0D;
while (true) {
if (!((i_1529 < 6D))) break;
Invoke(Invoke(t_1527, "to", ((V)(110D)), NewObj(1).Put("hRx", ((V)((ToNum(Get(B_1528, "hRx")) - 3.2)))).V, ((V)("l"))), "to", ((V)(110D)), NewObj(1).Put("hRx", Add(Get(B_1528, "hRx"), ((V)(1.6)))).V, ((V)("l")));
i_1529++;
}
}
Invoke(t_1527, "fx", ((V)("note")), ((V)("pawR")), ((V)(1D)));
return Invoke(t_1527, "back", ((V)(260D)));
return default;
}, 1, "scratch", false)).Put("pump", Fn((V _self1531, int _argc1532, V t_1538, V _a1535, V _a1536, V _a1537, V[] _rest1533) => {
V B_1539 = default;
if (_self1531.IsNullish) _self1531 = GlobalV;
B_1539 = Get(t_1538, "B");
Invoke(t_1538, "to", ((V)(200D)), NewObj(4).Put("armR", ((V)(150D))).Put("hRy", ((V)((-4D)))).Put("open", ((V)(0.4))).Put("hap", ((V)(1D))).V, ((V)("o")));
{
double i_1540 = 0;
i_1540 = 0D;
while (true) {
if (!((i_1540 < 4D))) break;
Invoke(Invoke(t_1538, "to", ((V)(250D)), NewObj(3).Put("armR", ((V)(112D))).Put("sq", Add(Get(B_1539, "sq"), ((V)(0.05)))).Put("lift", ((V)((-0.5)))).V, ((V)("i"))), "to", ((V)(250D)), NewObj(3).Put("armR", ((V)(160D))).Put("sq", ((V)((ToNum(Get(B_1539, "sq")) - 0.03)))).Put("lift", ((V)(1D))).V, ((V)("o")));
i_1540++;
}
}
return Invoke(t_1538, "back", ((V)(320D)));
return default;
}, 1, "pump", false)).Put("point", Fn((V _self1542, int _argc1543, V t_1549, V X_1550, V _a1547, V _a1548, V[] _rest1544) => {
if (_self1542.IsNullish) _self1542 = GlobalV;
Invoke(Invoke(Invoke(t_1549, "to", ((V)(300D)), Call(o_21, V.Undef, NewObj(7).Put("armR", ((V)(140D))).Put("hRx", ((V)(5D))).Put("hRy", ((V)((-2D)))).Put("lx", ((V)(0.6))).Put("winkR", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, Get(X_1550, "cheer")), ((V)("o"))), "wait", ((V)(600D))), "to", ((V)(160D)), NewObj(1).Put("winkR", ((V)(0D))).V);
return Invoke(t_1549, "back", ((V)(340D)));
return default;
}, 2, "point", false)).Put("drop", Fn((V _self1551, int _argc1552, V t_1558, V X_1559, V _a1556, V _a1557, V[] _rest1553) => {
V B_1560 = default;
if (_self1551.IsNullish) _self1551 = GlobalV;
B_1560 = Get(t_1558, "B");
Invoke(Invoke(t_1558, "to", ((V)(500D)), NewObj(4).Put("sq", Add(Get(B_1560, "sq"), ((V)(0.1)))).Put("armR", ((V)(10D))).Put("lift", ((V)((-1D)))).Put("wide", ((V)(0.5))).V, ((V)("i"))), "to", ((V)(200D)), Call(o_21, V.Undef, NewObj(10).Put("armR", ((V)(165D))).Put("armL", ((V)(165D))).Put("hLy", ((V)((-4D)))).Put("hRy", ((V)((-4D)))).Put("hLx", ((V)(0D))).Put("lift", ((V)(7D))).Put("sq", ((V)((-0.08)))).Put("open", ((V)(0.7))).Put("wide", ((V)(0.6))).Put("hap", ((V)(1D))).V, (Get(X_1559, "tk") is var _t1561 && Truthy(_t1561) ? _t1561 : NewObj(0).V)), ((V)("o")));
if (Truthy(Get(X_1559, "cheerFx"))) {
InvokeSpread(t_1558, "fx", new ArrBuilder().Spread(Get(X_1559, "cheerFx")).V);
} else {
Invoke(t_1558, "fx", ((V)("spark")), ((V)("body")), ((V)(5D)));
}
Invoke(Invoke(t_1558, "to", ((V)(220D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(2).Put("sq", Add(Get(B_1560, "sq"), ((V)(0.05)))).Put("pitch", ((V)((ToNum(Get(B_1560, "pitch")) - 0.12)))).V, NewObj(2).Put("sq", Get(B_1560, "sq")).Put("pitch", Add(Get(B_1560, "pitch"), ((V)(0.03)))).V, ((V)("io")));
return Invoke(t_1558, "back", ((V)(400D)));
return default;
}, 2, "drop", false)).Put("spin", Fn((V _self1562, int _argc1563, V t_1569, V _a1566, V _a1567, V _a1568, V[] _rest1564) => {
if (_self1562.IsNullish) _self1562 = GlobalV;
Invoke(Invoke(t_1569, "to", ((V)(560D)), NewObj(3).Put("spin", ((V)(360D))).Put("sq", ((V)((-0.03)))).Put("hap", ((V)(1D))).V, ((V)("io"))), "to", ((V)(10D)), NewObj(1).Put("spin", ((V)(0D))).V);
return Invoke(t_1569, "back", ((V)(240D)));
return default;
}, 1, "spin", false)).V;
phoneProp_80 = Fn((V _self2, int _argc1570, V col_1576, V _a1573, V _a1574, V _a1575, V[] _rest1571) => {
return Fn((V _self2, int _argc1577, V I_1583, V _a1580, V _a1581, V _a1582, V[] _rest1578) => {
V W_1584 = default;
V f0_1585 = default;
V a_1586 = default;
V b_1587 = default;
double mx_1588 = 0;
double my_1589 = 0;
double d_1590 = 0;
double hw_1591 = 0;
double top_1592 = 0;
double an_1593 = 0;
V arc_1594 = default;
V cup_1595 = default;
W_1584 = (Get(I_1583, "W") is var _t1596 && Truthy(_t1596) ? _t1596 : NewObj(0).V);
f0_1585 = Call(facing_27, V.Undef, I_1583);
if (LtN(f0_1585, 0.05)) {
return ((V)(""));
}
a_1586 = Get(W_1584, "eyeL");
b_1587 = Get(W_1584, "eyeR");
if ((!(Truthy(Call(okp_35, V.Undef, a_1586))) && !(Truthy(Call(okp_35, V.Undef, b_1587))))) {
return ((V)(""));
}
if (!(Truthy(Call(okp_35, V.Undef, a_1586)))) {
a_1586 = b_1587;
}
if (!(Truthy(Call(okp_35, V.Undef, b_1587)))) {
b_1587 = a_1586;
}
mx_1588 = (ToNum(Add(GetIdx(a_1586, 0D), GetIdx(b_1587, 0D))) / 2D);
my_1589 = (ToNum(Add(GetIdx(a_1586, 1D), GetIdx(b_1587, 1D))) / 2D);
d_1590 = Max(Hypot((ToNum(GetIdx(b_1587, 0D)) - ToNum(GetIdx(a_1586, 0D))), (ToNum(GetIdx(b_1587, 1D)) - ToNum(GetIdx(a_1586, 1D)))), 6D);
hw_1591 = ((d_1590 * 1.15) + 5D);
top_1592 = (Truthy(Call(okp_35, V.Undef, Get(W_1584, "head"))) ? Min(((ToNum(GetIdx(Get(W_1584, "head"), 1D)) - my_1589) + 1D), (-6D)) : (((-d_1590) * 1.4) - 5D));
an_1593 = ((FdLibm.Atan2((ToNum(GetIdx(b_1587, 1D)) - ToNum(GetIdx(a_1586, 1D))), (ToNum(GetIdx(b_1587, 0D)) - ToNum(GetIdx(a_1586, 0D)))) * 180D) / System.Math.PI);
arc_1594 = ((V)(string.Concat(new string[] { "M", ToStr(Call(r2_30, V.Undef, ((V)((-hw_1591))))), " 0C", ToStr(Call(r2_30, V.Undef, ((V)((-hw_1591))))), " ", ToStr(Call(r2_30, V.Undef, ((V)((top_1592 * 1.3))))), " ", ToStr(Call(r2_30, V.Undef, ((V)(hw_1591)))), " ", ToStr(Call(r2_30, V.Undef, ((V)((top_1592 * 1.3))))), " ", ToStr(Call(r2_30, V.Undef, ((V)(hw_1591)))), " 0" })));
cup_1595 = Fn((V _self2, int _argc1597, V x_1603, V _a1600, V _a1601, V _a1602, V[] _rest1598) => {
return ((V)(string.Concat(new string[] { "<rect x=\"", ToStr(Call(r2_30, V.Undef, ((V)((ToNum(x_1603) - 2.2))))), "\" y=\"-2\" width=\"4.4\" height=\"7\" rx=\"2\" fill=\"#2a2440\" stroke=\"#111\" stroke-width=\"0.35\"/><rect x=\"", ToStr(Call(r2_30, V.Undef, ((V)((ToNum(x_1603) - 1.3))))), "\" y=\"-0.8\" width=\"2.6\" height=\"4.6\" rx=\"1.2\" fill=\"", ToStr(col_1576), "\"/>" })));
}, 1, "", true);
return Call(G_26, V.Undef, ((V)(mx_1588)), ((V)((my_1589 + 1D))), ((V)(an_1593)), ((V)(1D)), ((V)(string.Concat(new string[] { "<path d=\"", ToStr(arc_1594), "\" fill=\"none\" stroke=\"#2a2440\" stroke-width=\"2\"/><path d=\"", ToStr(arc_1594), "\" fill=\"none\" stroke=\"", ToStr(col_1576), "\" stroke-width=\"0.9\"/>", ToStr(Call(cup_1595, V.Undef, ((V)((-hw_1591))))), ToStr(Call(cup_1595, V.Undef, ((V)(hw_1591)))) }))), ((V)(Min(1D, (ToNum(f0_1585) * 1.3)))));
return default;
}, 1, "", true);
}, 1, "", true);
PB0_81 = Call(S0_39, V.Undef, NewObj(5).Put("pitch", ((V)((-0.12)))).Put("ly", ((V)(0.6))).Put("armL", ((V)(44D))).Put("armR", ((V)(44D))).Put("wide", ((V)(0.2))).V, Call(both_15, V.Undef, ((V)(4D)), ((V)((-4D)))));
PBB_82 = NewObj(4).Put("flip", Fn((V _self1604, int _argc1605, V t_1611, V _a1608, V _a1609, V _a1610, V[] _rest1606) => {
V B_1612 = default;
if (_self1604.IsNullish) _self1604 = GlobalV;
B_1612 = Get(t_1611, "B");
{
double i_1613 = 0;
i_1613 = 0D;
while (true) {
if (!((i_1613 < 8D))) break;
V s_1615 = default;
s_1615 = ((V)((NumTruthy((i_1613 % 2D)) ? "armL" : "armR")));
Invoke(Invoke(t_1611, "to", ((V)(90D)), NewObj(2).PutK(s_1615, Add(GetK(B_1612, s_1615), ((V)(14D)))).Put("sq", Add(Get(B_1612, "sq"), ((V)(0.015)))).V, ((V)("o"))), "to", ((V)(120D)), NewObj(2).PutK(s_1615, GetK(B_1612, s_1615)).Put("sq", Get(B_1612, "sq")).V, ((V)("i")));
i_1613++;
}
}
return Invoke(t_1611, "back", ((V)(260D)));
return default;
}, 1, "flip", false)).Put("track", Fn((V _self1616, int _argc1617, V t_1623, V _a1620, V _a1621, V _a1622, V[] _rest1618) => {
if (_self1616.IsNullish) _self1616 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_1623, "to", ((V)(300D)), NewObj(3).Put("lx", ((V)((-0.8)))).Put("turn", ((V)((-0.12)))).Put("wide", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("lx", ((V)(0.8))).Put("turn", ((V)(0.12))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(2).Put("lx", ((V)((-0.4)))).Put("ly", ((V)(0.9))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("lx", ((V)(0.6))).Put("ly", ((V)(0.3))).V, ((V)("io")));
return Invoke(t_1623, "back", ((V)(300D)));
return default;
}, 1, "track", false)).Put("nudge", Fn((V _self1624, int _argc1625, V t_1631, V _a1628, V _a1629, V _a1630, V[] _rest1626) => {
V Q_1632 = default;
if (_self1624.IsNullish) _self1624 = GlobalV;
Q_1632 = Get(Get(t_1631, "B"), "sq");
Invoke(Invoke(Invoke(Invoke(t_1631, "to", ((V)(140D)), NewObj(4).Put("tilt", ((V)(7D))).Put("x", ((V)(1.4))).Put("sq", Add(Q_1632, ((V)(0.05)))).Put("sqz", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("tilt", ((V)((-3D)))).Put("x", ((V)((-0.4)))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(2).Put("tilt", ((V)(6D))).Put("x", ((V)(1.2))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(3).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("sqz", ((V)(0D))).V, ((V)("io")));
return Invoke(t_1631, "back", ((V)(260D)));
return default;
}, 1, "nudge", false)).Put("multi", Fn((V _self1633, int _argc1634, V t_1640, V _a1637, V _a1638, V _a1639, V[] _rest1635) => {
V B_1641 = default;
if (_self1633.IsNullish) _self1633 = GlobalV;
B_1641 = Get(t_1640, "B");
Invoke(t_1640, "to", ((V)(200D)), NewObj(4).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.6))).Put("pitch", Add(Get(B_1641, "pitch"), ((V)(0.06)))).V, ((V)("o")));
{
double i_1642 = 0;
i_1642 = 0D;
while (true) {
if (!((i_1642 < 10D))) break;
Invoke(t_1640, "to", ((V)(70D)), NewObj(3).Put("armL", Add(Get(B_1641, "armL"), ((V)((NumTruthy((i_1642 % 2D)) ? 14D : 0D))))).Put("armR", Add(Get(B_1641, "armR"), ((V)((NumTruthy((i_1642 % 2D)) ? 0D : 14D))))).Put("lx", ((V)((NumTruthy((i_1642 % 2D)) ? 0.7 : (-0.7))))).V, ((V)("l")));
i_1642++;
}
}
Invoke(Invoke(t_1640, "fx", ((V)("spark")), ((V)("head")), ((V)(3D))), "fx", ((V)("sweat")), ((V)("head")), ((V)(1D)));
return Invoke(t_1640, "back", ((V)(300D)));
return default;
}, 1, "multi", false)).V;
DC0_83 = Call(S0_39, V.Undef, NewObj(4).Put("armL", ((V)(36D))).Put("armR", ((V)(36D))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V);
DCB_84 = NewObj(6).Put("steps", Fn((V _self1644, int _argc1645, V t_1651, V _a1648, V _a1649, V _a1650, V[] _rest1646) => {
if (_self1644.IsNullish) _self1644 = GlobalV;
{
double i_1652 = 0;
i_1652 = 0D;
while (true) {
if (!((i_1652 < 8D))) break;
double s_1654 = 0;
s_1654 = (NumTruthy((i_1652 % 2D)) ? (-1D) : 1D);
Invoke(Invoke(t_1651, "to", ((V)(115D)), NewObj(7).Put("footL", ((V)(((s_1654 > 0D) ? 2.6 : 0D)))).Put("footR", ((V)(((s_1654 > 0D) ? 0D : 2.6)))).Put("x", ((V)((s_1654 * 1.2)))).Put("armL", ((V)(((s_1654 > 0D) ? 60D : 20D)))).Put("armR", ((V)(((s_1654 > 0D) ? 20D : 60D)))).Put("sq", ((V)(0.03))).Put("tilt", ((V)((s_1654 * 2D)))).V, ((V)("o"))), "to", ((V)(115D)), NewObj(3).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i")));
i_1652++;
}
}
return Invoke(t_1651, "back", ((V)(240D)));
return default;
}, 1, "steps", false)).Put("arrows", Fn((V _self1655, int _argc1656, V t_1662, V _a1659, V _a1660, V _a1661, V[] _rest1657) => {
if (_self1655.IsNullish) _self1655 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1662, "to", ((V)(160D)), NewObj(4).Put("x", ((V)((-2.6)))).Put("footL", ((V)(2.4))).Put("tilt", ((V)((-5D)))).Put("armL", ((V)(90D))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("footL", ((V)(0D))).Put("armL", ((V)(36D))).V, ((V)("i"))), "to", ((V)(160D)), NewObj(4).Put("x", ((V)(2.6))).Put("footR", ((V)(2.4))).Put("tilt", ((V)(5D))).Put("armR", ((V)(90D))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("footR", ((V)(0D))).Put("armR", ((V)(36D))).V, ((V)("i"))), "to", ((V)(160D)), NewObj(6).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.06)))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i"))), "to", ((V)(160D)), NewObj(4).Put("sq", ((V)(0.14))).Put("lift", ((V)((-1D)))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
return Invoke(t_1662, "back", ((V)(240D)));
return default;
}, 1, "arrows", false)).Put("jump", Fn((V _self1663, int _argc1664, V t_1670, V _a1667, V _a1668, V _a1669, V[] _rest1665) => {
if (_self1663.IsNullish) _self1663 = GlobalV;
{
double i_1671 = 0;
i_1671 = 0D;
while (true) {
if (!((i_1671 < 2D))) break;
Invoke(Invoke(Invoke(t_1670, "to", ((V)(110D)), NewObj(1).Put("sq", ((V)(0.12))).V, ((V)("i"))), "to", ((V)(220D)), NewObj(7).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(8D))).Put("footL", ((V)(1.6))).Put("footR", ((V)(1.6))).Put("armL", ((V)(130D))).Put("armR", ((V)(130D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(6).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("i")));
i_1671++;
}
}
return Invoke(t_1670, "back", ((V)(240D)));
return default;
}, 1, "jump", false)).Put("combo", Fn((V _self1673, int _argc1674, V t_1680, V X_1681, V _a1678, V _a1679, V[] _rest1675) => {
if (_self1673.IsNullish) _self1673 = GlobalV;
{
double i_1682 = 0;
i_1682 = 0D;
while (true) {
if (!((i_1682 < 12D))) break;
double s_1684 = 0;
s_1684 = (NumTruthy((i_1682 % 2D)) ? (-1D) : 1D);
Invoke(t_1680, "to", ((V)(80D)), NewObj(6).Put("footL", ((V)(((s_1684 > 0D) ? 2.4 : 0D)))).Put("footR", ((V)(((s_1684 > 0D) ? 0D : 2.4)))).Put("x", ((V)((s_1684 * 1.6)))).Put("armL", ((V)(((s_1684 > 0D) ? 90D : 30D)))).Put("armR", ((V)(((s_1684 > 0D) ? 30D : 90D)))).Put("sqz", ((V)(0.5))).V, ((V)("l")));
i_1682++;
}
}
Invoke(t_1680, "fx", ((V)("sweat")), ((V)("head")), ((V)(1D)));
Call(cheer_47, V.Undef, t_1680, X_1681, NewObj(4).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("x", ((V)(0D))).Put("sqz", ((V)(0D))).V);
return t_1680;
return default;
}, 2, "combo", false)).Put("spin", Fn((V _self1685, int _argc1686, V t_1692, V _a1689, V _a1690, V _a1691, V[] _rest1687) => {
if (_self1685.IsNullish) _self1685 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_1692, "to", ((V)(120D)), NewObj(1).Put("sq", ((V)(0.08))).V), "to", ((V)(600D)), NewObj(5).Put("spin", ((V)(360D))).Put("armL", ((V)(100D))).Put("armR", ((V)(100D))).Put("sq", ((V)((-0.04)))).Put("lift", ((V)(2D))).V, ((V)("io"))), "to", ((V)(10D)), NewObj(1).Put("spin", ((V)(0D))).V), "to", ((V)(160D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("i")));
return Invoke(t_1692, "back", ((V)(260D)));
return default;
}, 1, "spin", false)).Put("freeze", Fn((V _self1693, int _argc1694, V t_1700, V X_1701, V _a1698, V _a1699, V[] _rest1695) => {
if (_self1693.IsNullish) _self1693 = GlobalV;
Invoke(t_1700, "to", ((V)(200D)), Call(o_21, V.Undef, NewObj(10).Put("armL", ((V)(165D))).Put("armR", ((V)(18D))).Put("hLy", ((V)((-4D)))).Put("tilt", ((V)(7D))).Put("x", ((V)(1D))).Put("footR", ((V)(2D))).Put("winkR", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("hap", ((V)(1D))).V, (Get(X_1701, "tk") is var _t1702 && Truthy(_t1702) ? _t1702 : NewObj(0).V)), ((V)("o")));
if (Truthy(Get(X_1701, "cheerFx"))) {
InvokeSpread(t_1700, "fx", new ArrBuilder().Spread(Get(X_1701, "cheerFx")).V);
} else {
Invoke(t_1700, "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
}
Invoke(Invoke(t_1700, "wait", ((V)(900D))), "to", ((V)(160D)), NewObj(1).Put("winkR", ((V)(0D))).V);
return Invoke(t_1700, "back", ((V)(360D)));
return default;
}, 2, "freeze", false)).V;
HK0_85 = Call(S0_39, V.Undef, NewObj(5).Put("pitch", ((V)((-0.16)))).Put("ly", ((V)(0.7))).Put("armR", ((V)(34D))).Put("armL", ((V)(24D))).Put("wide", ((V)(0.2))).V, Call(hand_14, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-2D)))), Call(hand_14, V.Undef, ((V)((-1D))), ((V)(8D)), ((V)(2D))));
HKB_86 = NewObj(3).Put("ready", Fn((V _self1703, int _argc1704, V t_1710, V _a1707, V _a1708, V _a1709, V[] _rest1705) => {
V B_1711 = default;
if (_self1703.IsNullish) _self1703 = GlobalV;
B_1711 = Get(t_1710, "B");
Invoke(Invoke(t_1710, "to", ((V)(260D)), NewObj(3).Put("sq", Add(Get(B_1711, "sq"), ((V)(0.06)))).Put("lift", ((V)((-0.6)))).Put("sqz", ((V)(0.3))).V, ((V)("io"))), "osc", ((V)(1000D)), ((V)(2D)), NewObj(2).Put("lx", ((V)((-0.6)))).Put("x", ((V)((-0.6)))).V, NewObj(2).Put("lx", ((V)(0.6))).Put("x", ((V)(0.6))).V, ((V)("s")));
return Invoke(t_1710, "back", ((V)(260D)));
return default;
}, 1, "ready", false)).Put("hit", Fn((V _self1712, int _argc1713, V t_1719, V X_1720, V rec_1721, V _a1718, V[] _rest1714) => {
V B_1722 = default;
if (_self1712.IsNullish) _self1712 = GlobalV;
B_1722 = Get(t_1719, "B");
Invoke(Invoke(t_1719, "to", ((V)(200D)), NewObj(3).Put("armR", Add(Get(B_1722, "armR"), ((V)(16D)))).Put("hRx", Add(Get(B_1722, "hRx"), ((V)(4D)))).Put("lean", ((V)((-0.5)))).V, ((V)("io"))), "to", ((V)(110D)), NewObj(6).Put("armR", ((V)((ToNum(Get(B_1722, "armR")) - 10D)))).Put("hRx", ((V)((ToNum(Get(B_1722, "hRx")) - 7D)))).Put("lean", ((V)(1D))).Put("sq", ((V)((ToNum(Get(B_1722, "sq")) - 0.03)))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.6))).V, ((V)("o")));
Call(push_46, V.Undef, rec_1721, ((V)("h")), Get(t_1719, "t"));
Invoke(t_1719, "to", ((V)(300D)), NewObj(3).Put("lean", ((V)(0.3))).Put("lx", ((V)(0.8))).Put("ly", ((V)(0.4))).V, ((V)("io")));
return Invoke(t_1719, "back", ((V)(300D)));
return default;
}, 3, "hit", false)).Put("block", Fn((V _self1723, int _argc1724, V t_1730, V X_1731, V rec_1732, V _a1729, V[] _rest1725) => {
V B_1733 = default;
if (_self1723.IsNullish) _self1723 = GlobalV;
B_1733 = Get(t_1730, "B");
Invoke(t_1730, "to", ((V)(120D)), NewObj(5).Put("x", ((V)((-1.6)))).Put("lean", ((V)((-1D)))).Put("hRx", Add(Get(B_1733, "hRx"), ((V)(3D)))).Put("wide", ((V)(0.9))).Put("open", ((V)(0.4))).V, ((V)("o")));
Call(push_46, V.Undef, rec_1732, ((V)("h")), Get(t_1730, "t"));
Invoke(t_1730, "wait", ((V)(250D)));
return Invoke(t_1730, "back", ((V)(300D)));
return default;
}, 3, "block", false)).V;
PADDLE_87 = Fn((V _self2, int _argc1734, V c_1740, V _a1737, V _a1738, V _a1739, V[] _rest1735) => {
return ((V)(string.Concat(new string[] { "<ellipse cx=\"0\" cy=\"1\" rx=\"4.2\" ry=\"2\" fill=\"", ToStr(c_1740), "\" stroke=\"", ToStr(Call(shade_31, V.Undef, c_1740, ((V)(0.65)))), "\" stroke-width=\"0.45\"/><ellipse cx=\"0\" cy=\"-0.4\" rx=\"1.5\" ry=\"1.1\" fill=\"", ToStr(Call(shade_31, V.Undef, c_1740, ((V)(1.2)))), "\" stroke=\"", ToStr(Call(shade_31, V.Undef, c_1740, ((V)(0.65)))), "\" stroke-width=\"0.35\"/>" })));
}, 1, "", true);
PPAD_88 = Fn((V _self2, int _argc1741, V c_1747, V _a1744, V _a1745, V _a1746, V[] _rest1742) => {
return ((V)(string.Concat(new string[] { "<path d=\"M-0.6 0H0.6V4H-0.6Z\" fill=\"#c98a52\" stroke=\"#8a5a2c\" stroke-width=\"0.3\"/><circle cx=\"0\" cy=\"-2.6\" r=\"3.2\" fill=\"", ToStr(c_1747), "\" stroke=\"", ToStr(Call(shade_31, V.Undef, c_1747, ((V)(0.65)))), "\" stroke-width=\"0.45\"/>" })));
}, 1, "", true);
BL0_90 = Call(S0_39, V.Undef, NewObj(6).Put("pitch", ((V)((-0.2)))).Put("ly", ((V)(0.7))).Put("armL", ((V)(30D))).Put("armR", ((V)(22D))).Put("lean", ((V)(0.3))).Put("tilt", ((V)(3D))).V, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(10D)), ((V)((-2D)))), Call(hand_14, V.Undef, ((V)(1D)), ((V)((-2D))), ((V)(2D))));
BLB_91 = NewObj(5).Put("chalk", Fn((V _self1748, int _argc1749, V t_1755, V _a1752, V _a1753, V _a1754, V[] _rest1750) => {
if (_self1748.IsNullish) _self1748 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1755, "to", ((V)(340D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(4D)), ((V)((-8D)))), NewObj(4).Put("armL", ((V)(56D))).Put("ly", ((V)(0.2))).Put("lx", ((V)(0.4))).Put("pitch", ((V)((-0.04)))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(2).Put("hLx", ((V)(6D))).Put("tilt", ((V)(2D))).V, NewObj(2).Put("hLx", ((V)(3D))).Put("tilt", ((V)(4D))).V, ((V)("s"))), "fx", ((V)("dust")), ((V)("pawL")), ((V)(2D))), "to", ((V)(200D)), NewObj(1).Put("puff", ((V)(0.6))).V), "to", ((V)(200D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("mouth")), ((V)(1D)));
return Invoke(t_1755, "back", ((V)(360D)));
return default;
}, 1, "chalk", false)).Put("aim", Fn((V _self1756, int _argc1757, V t_1763, V _a1760, V _a1761, V _a1762, V[] _rest1758) => {
V B_1764 = default;
if (_self1756.IsNullish) _self1756 = GlobalV;
B_1764 = Get(t_1763, "B");
Invoke(Invoke(t_1763, "to", ((V)(420D)), NewObj(7).Put("sq", Add(Get(B_1764, "sq"), ((V)(0.1)))).Put("pitch", ((V)((ToNum(Get(B_1764, "pitch")) - 0.12)))).Put("lift", ((V)((-1D)))).Put("winkL", ((V)(1D))).Put("lx", ((V)(0.6))).Put("ly", ((V)(0.8))).Put("tongue", ((V)(0.3))).V, ((V)("io"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("hRx", Add(Get(B_1764, "hRx"), ((V)(2.4)))).V, NewObj(1).Put("hRx", ((V)((ToNum(Get(B_1764, "hRx")) - 1D)))).V, ((V)("io")));
return t_1763;
return default;
}, 1, "aim", false)).Put("shoot", Fn((V _self1765, int _argc1766, V t_1772, V X_1773, V rec_1774, V _a1771, V[] _rest1767) => {
V B_1775 = default;
if (_self1765.IsNullish) _self1765 = GlobalV;
B_1775 = Get(t_1772, "B");
Invoke(Invoke(t_1772, "to", ((V)(300D)), NewObj(2).Put("hRx", Add(Get(B_1775, "hRx"), ((V)(4.4)))).Put("armR", Add(Get(B_1775, "armR"), ((V)(6D)))).V, ((V)("io"))), "to", ((V)(90D)), NewObj(3).Put("hRx", ((V)((ToNum(Get(B_1775, "hRx")) - 6D)))).Put("armR", ((V)((ToNum(Get(B_1775, "armR")) - 4D)))).Put("sq", Add(Get(B_1775, "sq"), ((V)(0.1)))).V, ((V)("o")));
Call(push_46, V.Undef, rec_1774, ((V)("sh")), Get(t_1772, "t"));
Invoke(Invoke(t_1772, "to", ((V)(400D)), NewObj(6).Put("winkL", ((V)(0D))).Put("wide", ((V)(0.6))).Put("lx", ((V)(0.9))).Put("ly", ((V)(0.5))).Put("tongue", ((V)(0D))).Put("pitch", ((V)((ToNum(Get(B_1775, "pitch")) - 0.04)))).V, ((V)("io"))), "wait", ((V)(500D)));
return Invoke(t_1772, "back", ((V)(420D)));
return default;
}, 3, "shoot", false)).Put("miss", Fn((V _self1776, int _argc1777, V t_1783, V _a1780, V _a1781, V _a1782, V[] _rest1778) => {
if (_self1776.IsNullish) _self1776 = GlobalV;
Invoke(Invoke(Invoke(t_1783, "to", ((V)(260D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-18D)))), NewObj(4).Put("armR", ((V)(128D))).Put("frown", ((V)(0.4))).Put("htilt", ((V)(8D))).Put("lx", ((V)(0.7))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(1).Put("hRx", ((V)((-3D)))).V, NewObj(1).Put("hRx", ((V)((-7D)))).V, ((V)("s"))), "to", ((V)(240D)), NewObj(4).Put("frown", ((V)(0D))).Put("sqz", ((V)(0.6))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V, ((V)("o")));
return Invoke(t_1783, "back", ((V)(400D)));
return default;
}, 1, "miss", false)).Put("circle", Fn((V _self1784, int _argc1785, V t_1791, V _a1788, V _a1789, V _a1790, V[] _rest1786) => {
if (_self1784.IsNullish) _self1784 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_1791, "to", ((V)(500D)), NewObj(5).Put("turn", ((V)(0.3))).Put("lx", ((V)(0.9))).Put("ly", ((V)(0.6))).Put("htilt", ((V)(6D))).Put("tilt", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(600D)), NewObj(3).Put("turn", ((V)((-0.3)))).Put("lx", ((V)((-0.9)))).Put("htilt", ((V)((-6D)))).V, ((V)("io"))), "wait", ((V)(600D)));
return Invoke(t_1791, "back", ((V)(500D)));
return default;
}, 1, "circle", false)).V;
ICX_93 = NewObj(7).Put("ball", ((V)("<circle cx=\"0\" cy=\"0\" r=\"3\" fill=\"#ffffff\" stroke=\"#3a3a48\" stroke-width=\"0.45\"/><path d=\"M0-1.2L1.15-0.35L0.7 1H-0.7L-1.15-0.35Z\" fill=\"#2a2a36\"/><path d=\"M0-1.2V-3M1.15-0.35L2.85-0.9M0.7 1L1.7 2.4M-0.7 1L-1.7 2.4M-1.15-0.35L-2.85-0.9\" stroke=\"#3a3a48\" stroke-width=\"0.35\"/>"))).Put("bball", Add(Add(Call(ci_32, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(3D)), ((V)("#f28a2e")), ((V)("#b8561a"))), Call(pa_33, V.Undef, ((V)("M-3 0H3M0-3V3M-2.1-2.1Q0 0-2.1 2.1M2.1-2.1Q0 0 2.1 2.1")), V.Null, ((V)("#7a3a10")), ((V)(0.35)))), Call(ci_32, V.Undef, ((V)((-1.1))), ((V)((-1.2))), ((V)(0.7)), ((V)("rgba(255,255,255,0.45)"))))).Put("bocce", Add(Add(Call(ci_32, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(2.4)), ((V)("#c0392b")), ((V)("#7a1e14"))), Call(pa_33, V.Undef, ((V)("M-2.2-0.6Q0 0.6 2.2-0.6")), V.Null, ((V)("#ffd24a")), ((V)(0.5)))), Call(ci_32, V.Undef, ((V)((-0.8))), ((V)((-0.9))), ((V)(0.6)), ((V)("#ffffff"))))).Put("bag", Fn((V _self2, int _argc1792, V c_1798, V _a1795, V _a1796, V _a1797, V[] _rest1793) => {
return ((V)(string.Concat(new string[] { "<rect x=\"-2.6\" y=\"-2\" width=\"5.2\" height=\"4\" rx=\"1.2\" fill=\"", ToStr(c_1798), "\" stroke=\"", ToStr(Call(shade_31, V.Undef, c_1798, ((V)(0.65)))), "\" stroke-width=\"0.4\"/><path d=\"M-1.8-1.2H1.8\" stroke=\"#ffffff\" stroke-width=\"0.4\" opacity=\"0.5\"/>" })));
}, 1, "bag", true)).Put("shoe", Add(Call(pa_33, V.Undef, ((V)("M-2.6 2.4V-0.4A2.6 2.6 0 0 1 2.6-0.4V2.4")), V.Null, ((V)("#6a7080")), ((V)(1.3))), Call(pa_33, V.Undef, ((V)("M-2.6 2.4V-0.4A2.6 2.6 0 0 1 2.6-0.4V2.4")), V.Null, ((V)("#c9cfdb")), ((V)(0.45))))).Put("disc", Fn((V _self2, int _argc1799, V c_1805, V _a1802, V _a1803, V _a1804, V[] _rest1800) => {
return ((V)(string.Concat(new string[] { "<ellipse cx=\"0\" cy=\"0\" rx=\"4.4\" ry=\"1.5\" fill=\"", ToStr(c_1805), "\" stroke=\"", ToStr(Call(shade_31, V.Undef, c_1805, ((V)(0.65)))), "\" stroke-width=\"0.4\"/><ellipse cx=\"0\" cy=\"-0.3\" rx=\"2.4\" ry=\"0.7\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.35\" opacity=\"0.6\"/>" })));
}, 1, "disc", true)).Put("stone", Call(pa_33, V.Undef, ((V)("M-1.8 0.6Q-1.6-1.2 0-1.3Q1.8-1.2 1.9 0.4Q1.6 1.3 0 1.3Q-1.6 1.3-1.8 0.6Z")), ((V)("#a9a39a")), ((V)("#6a645a")))).V;
GOB_94 = NewObj(3).Put("dribble", Fn((V _self1806, int _argc1807, V t_1813, V X_1814, V rec_1815, V _a1812, V[] _rest1808) => {
V a_1816 = default;
if (_self1806.IsNullish) _self1806 = GlobalV;
a_1816 = Get(t_1813, "t");
{
double i_1817 = 0;
i_1817 = 0D;
while (true) {
if (!((i_1817 < 6D))) break;
V s_1819 = default;
s_1819 = ((V)((NumTruthy((i_1817 % 2D)) ? "footL" : "footR")));
Invoke(Invoke(t_1813, "to", ((V)(160D)), NewObj(6).PutK(s_1819, ((V)(1.8))).Put("x", ((V)((NumTruthy((i_1817 % 2D)) ? (-0.6) : 0.6)))).Put("lx", ((V)(0.3))).Put("ly", ((V)(0.8))).Put("pitch", ((V)((-0.12)))).Put("tilt", ((V)((NumTruthy((i_1817 % 2D)) ? (-2D) : 2D)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).PutK(s_1819, ((V)(0D))).V, ((V)("i")));
i_1817++;
}
}
Call(push_46, V.Undef, rec_1815, ((V)("dr")), Arr(a_1816, Get(t_1813, "t")));
return Invoke(t_1813, "back", ((V)(240D)));
return default;
}, 3, "dribble", false)).Put("kick", Fn((V _self1820, int _argc1821, V t_1827, V X_1828, V rec_1829, V _a1826, V[] _rest1822) => {
V h_1830 = default;
if (_self1820.IsNullish) _self1820 = GlobalV;
h_1830 = Call(kickCore_50, V.Undef, t_1827, X_1828);
Call(push_46, V.Undef, rec_1829, ((V)("k")), h_1830);
return Invoke(t_1827, "back", ((V)(300D)));
return default;
}, 3, "kick", false)).Put("header", Fn((V _self1831, int _argc1832, V t_1838, V X_1839, V rec_1840, V _a1837, V[] _rest1833) => {
if (_self1831.IsNullish) _self1831 = GlobalV;
Invoke(Invoke(t_1838, "to", ((V)(400D)), NewObj(4).Put("ly", ((V)((-0.9)))).Put("pitch", ((V)(0.25))).Put("wide", ((V)(0.5))).Put("lean", ((V)((-0.3)))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(4).Put("pitch", ((V)((-0.14)))).Put("lift", ((V)(3D))).Put("close", ((V)(1D))).Put("sq", ((V)((-0.05)))).V, ((V)("o")));
Call(push_46, V.Undef, rec_1840, ((V)("hd")), Get(t_1838, "t"));
Invoke(Invoke(t_1838, "fx", ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(260D)), NewObj(4).Put("lift", ((V)(0D))).Put("close", ((V)(0D))).Put("sq", ((V)(0.05))).Put("pitch", ((V)(0D))).V, ((V)("i")));
return Invoke(t_1838, "back", ((V)(300D)));
return default;
}, 3, "header", false)).V;
KP0_96 = Call(S0_39, V.Undef, NewObj(8).Put("sq", ((V)(0.1))).Put("lift", ((V)((-1D)))).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).Put("pitch", ((V)((-0.04)))).Put("wide", ((V)(0.3))).Put("footL", ((V)(0.6))).Put("footR", ((V)(0.6))).V, Call(both_15, V.Undef, ((V)((-2D))), ((V)((-4D)))));
dive_97 = Fn((V _self2, int _argc1841, V t_1847, V s_1848, V _a1845, V _a1846, V[] _rest1842) => {
V Kk_1849 = default;
Kk_1849 = Call(SIDE_16, V.Undef, s_1848);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1847, "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0.16))).Put("lift", ((V)((-1.4)))).V, ((V)("i"))), "to", ((V)(260D)), NewObj(8).PutK(Get(Kk_1849, "arm"), ((V)(165D))).PutK(Get(Kk_1849, "hy"), ((V)((-6D)))).Put("tilt", ((V)((ToNum(s_1848) * 34D)))).Put("x", ((V)((ToNum(s_1848) * 6D)))).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.06)))).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(3).Put("lift", ((V)(0D))).Put("sq", ((V)(0.18))).Put("tilt", ((V)((ToNum(s_1848) * 40D)))).V, ((V)("i"))), "fx", ((V)("dust")), ((V)("body")), ((V)(4D))), "wait", ((V)(300D))), "to", ((V)(400D)), NewObj(3).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("sq", ((V)(0.1))).V, ((V)("io"))), "fx", ((V)("sweat")), ((V)("head")), ((V)(1D)));
return Invoke(t_1847, "back", ((V)(300D)));
return default;
}, 2, "", true);
KPB_98 = NewObj(5).Put("ready", Fn((V _self1850, int _argc1851, V t_1857, V _a1854, V _a1855, V _a1856, V[] _rest1852) => {
if (_self1850.IsNullish) _self1850 = GlobalV;
Invoke(t_1857, "osc", ((V)(1400D)), ((V)(4D)), NewObj(3).Put("x", ((V)((-2.2)))).Put("tilt", ((V)((-3D)))).Put("footL", ((V)(1.4))).V, NewObj(3).Put("x", ((V)(2.2))).Put("tilt", ((V)(3D))).Put("footR", ((V)(1.4))).V, ((V)("s")));
return Invoke(t_1857, "back", ((V)(260D)));
return default;
}, 1, "ready", false)).Put("diveL", Fn((V _self1858, int _argc1859, V t_1865, V _a1862, V _a1863, V _a1864, V[] _rest1860) => {
if (_self1858.IsNullish) _self1858 = GlobalV;
return Call(dive_97, V.Undef, t_1865, ((V)((-1D))));
return default;
}, 1, "diveL", false)).Put("diveR", Fn((V _self1866, int _argc1867, V t_1873, V _a1870, V _a1871, V _a1872, V[] _rest1868) => {
if (_self1866.IsNullish) _self1866 = GlobalV;
return Call(dive_97, V.Undef, t_1873, ((V)(1D)));
return default;
}, 1, "diveR", false)).Put("catch", Fn((V _self1874, int _argc1875, V t_1881, V X_1882, V rec_1883, V _a1880, V[] _rest1876) => {
if (_self1874.IsNullish) _self1874 = GlobalV;
Invoke(Invoke(t_1881, "to", ((V)(200D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(9D)), ((V)((-9D)))), NewObj(5).Put("armL", ((V)(56D))).Put("armR", ((V)(56D))).Put("wide", ((V)(0.9))).Put("open", ((V)(0.4))).Put("lift", ((V)(2D))).V), ((V)("o"))), "to", ((V)(200D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(10D)), ((V)(2D))), NewObj(9).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.14))).Put("sqz", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("wide", ((V)(0D))).Put("open", ((V)(0.2))).V), ((V)("i")));
Call(push_46, V.Undef, rec_1883, ((V)("c")), Arr(((V)((ToNum(Get(t_1881, "t")) - 200D))), Add(Get(t_1881, "t"), ((V)(900D)))));
Invoke(t_1881, "wait", ((V)(900D)));
return Invoke(t_1881, "back", ((V)(320D)));
return default;
}, 3, "catch", false)).Put("punch", Fn((V _self1884, int _argc1885, V t_1891, V X_1892, V rec_1893, V _a1890, V[] _rest1886) => {
if (_self1884.IsNullish) _self1884 = GlobalV;
Invoke(t_1891, "to", ((V)(160D)), NewObj(5).Put("armR", ((V)(165D))).Put("hRy", ((V)((-8D)))).Put("lift", ((V)(5D))).Put("sq", ((V)((-0.06)))).Put("open", ((V)(0.5))).V, ((V)("o")));
Call(push_46, V.Undef, rec_1893, ((V)("pu")), Get(t_1891, "t"));
Invoke(Invoke(t_1891, "fx", ((V)("spark")), ((V)("pawR")), ((V)(3D))), "to", ((V)(240D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i")));
return Invoke(t_1891, "back", ((V)(300D)));
return default;
}, 3, "punch", false)).V;
HPB_100 = NewObj(3).Put("dribble", Fn((V _self1894, int _argc1895, V t_1901, V X_1902, V rec_1903, V _a1900, V[] _rest1896) => {
V a_1904 = default;
if (_self1894.IsNullish) _self1894 = GlobalV;
a_1904 = Get(t_1901, "t");
Invoke(t_1901, "to", ((V)(200D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)((-2D))), ((V)(4D))), NewObj(4).Put("armR", ((V)(30D))).Put("pitch", ((V)((-0.08)))).Put("ly", ((V)(0.6))).Put("sq", ((V)(0.03))).V), ((V)("io")));
{
double i_1905 = 0;
i_1905 = 0D;
while (true) {
if (!((i_1905 < 5D))) break;
Invoke(Invoke(t_1901, "to", ((V)(150D)), NewObj(3).Put("hRy", ((V)(8D))).Put("armR", ((V)(22D))).Put("sq", ((V)(0.05))).V, ((V)("i"))), "to", ((V)(150D)), NewObj(3).Put("hRy", ((V)(3D))).Put("armR", ((V)(32D))).Put("sq", ((V)(0.02))).V, ((V)("o")));
i_1905++;
}
}
Call(push_46, V.Undef, rec_1903, ((V)("dr")), Arr(a_1904, Get(t_1901, "t")));
return Invoke(t_1901, "back", ((V)(240D)));
return default;
}, 3, "dribble", false)).Put("shoot", Fn((V _self1907, int _argc1908, V t_1914, V X_1915, V rec_1916, V _a1913, V[] _rest1909) => {
if (_self1907.IsNullish) _self1907 = GlobalV;
Invoke(Invoke(t_1914, "to", ((V)(260D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-6D)))), NewObj(7).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("sq", ((V)(0.12))).Put("lift", ((V)((-1D)))).Put("ly", ((V)((-0.6)))).Put("pitch", ((V)(0.12))).Put("sqz", ((V)(0.3))).V), ((V)("io"))), "to", ((V)(240D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-14D)))), NewObj(7).Put("armL", ((V)(160D))).Put("armR", ((V)(160D))).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(9D))).Put("footL", ((V)(1.4))).Put("footR", ((V)(1.4))).Put("sqz", ((V)(0D))).V), ((V)("o")));
Call(push_46, V.Undef, rec_1916, ((V)("sh")), Get(t_1914, "t"));
Invoke(Invoke(Invoke(Invoke(t_1914, "to", ((V)(160D)), NewObj(2).Put("armR", ((V)(170D))).Put("hRy", ((V)((-16D)))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(4).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(4).Put("sq", ((V)(0D))).Put("ly", ((V)((-0.8)))).Put("pitch", ((V)(0.2))).Put("wide", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(300D)));
return Invoke(t_1914, "back", ((V)(300D)));
return default;
}, 3, "shoot", false)).Put("spinball", Fn((V _self1917, int _argc1918, V t_1924, V X_1925, V rec_1926, V _a1923, V[] _rest1919) => {
V a_1927 = default;
if (_self1917.IsNullish) _self1917 = GlobalV;
a_1927 = Get(t_1924, "t");
Invoke(Invoke(t_1924, "to", ((V)(320D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-16D)))), NewObj(5).Put("armR", ((V)(150D))).Put("ly", ((V)((-0.8)))).Put("pitch", ((V)(0.16))).Put("tongue", ((V)(0.5))).Put("sqz", ((V)(0.4))).V), ((V)("io"))), "osc", ((V)(1600D)), ((V)(4D)), NewObj(2).Put("tilt", ((V)(2D))).Put("x", ((V)(0.5))).V, NewObj(2).Put("tilt", ((V)((-2D)))).Put("x", ((V)((-0.5)))).V, ((V)("s")));
Call(push_46, V.Undef, rec_1926, ((V)("sp")), Arr(a_1927, Get(t_1924, "t")));
Invoke(t_1924, "to", ((V)(200D)), NewObj(3).Put("tongue", ((V)(0D))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.8))).V, ((V)("o")));
return Invoke(t_1924, "back", ((V)(360D)));
return default;
}, 3, "spinball", false)).V;
GF0_102 = Call(S0_39, V.Undef, NewObj(5).Put("pitch", ((V)((-0.2)))).Put("ly", ((V)(0.8))).Put("armL", ((V)(26D))).Put("armR", ((V)(26D))).Put("lean", ((V)(0.2))).V, Call(both_15, V.Undef, ((V)(9D)), ((V)(4D))));
GFB_103 = NewObj(3).Put("line", Fn((V _self1928, int _argc1929, V t_1935, V _a1932, V _a1933, V _a1934, V[] _rest1930) => {
if (_self1928.IsNullish) _self1928 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_1935, "to", ((V)(400D)), NewObj(6).Put("sq", ((V)(0.1))).Put("lift", ((V)((-1.2)))).Put("pitch", ((V)((-0.3)))).Put("lx", ((V)(0.9))).Put("ly", ((V)(0.9))).Put("winkL", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(300D)), NewObj(1).Put("lx", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(5).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("winkL", ((V)(0D))).Put("pitch", ((V)((-0.2)))).Put("lx", ((V)(0D))).V, ((V)("io")));
return Invoke(t_1935, "back", ((V)(200D)));
return default;
}, 1, "line", false)).Put("waggle", Fn((V _self1936, int _argc1937, V t_1943, V _a1940, V _a1941, V _a1942, V[] _rest1938) => {
V B_1944 = default;
if (_self1936.IsNullish) _self1936 = GlobalV;
B_1944 = Get(t_1943, "B");
Invoke(t_1943, "osc", ((V)(1000D)), ((V)(3D)), NewObj(3).Put("hLx", ((V)((ToNum(Get(B_1944, "hLx")) - 1.6)))).Put("hRx", ((V)((ToNum(Get(B_1944, "hRx")) - 1.6)))).Put("tilt", ((V)(1D))).V, NewObj(3).Put("hLx", Add(Get(B_1944, "hLx"), ((V)(1.2)))).Put("hRx", Add(Get(B_1944, "hRx"), ((V)(1.2)))).Put("tilt", ((V)((-1D)))).V, ((V)("io")));
return Invoke(t_1943, "back", ((V)(200D)));
return default;
}, 1, "waggle", false)).Put("putt", Fn((V _self1945, int _argc1946, V t_1952, V X_1953, V rec_1954, V _a1951, V[] _rest1947) => {
V B_1955 = default;
if (_self1945.IsNullish) _self1945 = GlobalV;
B_1955 = Get(t_1952, "B");
Invoke(Invoke(t_1952, "to", ((V)(500D)), NewObj(4).Put("hLx", Add(Get(B_1955, "hLx"), ((V)(3D)))).Put("hRx", Add(Get(B_1955, "hRx"), ((V)(3D)))).Put("tilt", ((V)((-2D)))).Put("sqz", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(3).Put("hLx", ((V)((ToNum(Get(B_1955, "hLx")) - 3.4)))).Put("hRx", ((V)((ToNum(Get(B_1955, "hRx")) - 3.4)))).Put("tilt", ((V)(2D))).V, ((V)("o")));
Call(push_46, V.Undef, rec_1954, ((V)("pt")), ((V)((ToNum(Get(t_1952, "t")) - 120D))));
Invoke(Invoke(t_1952, "to", ((V)(500D)), NewObj(6).Put("lx", ((V)(0.9))).Put("ly", ((V)(0.8))).Put("lean", ((V)(0.8))).Put("wide", ((V)(0.6))).Put("sqz", ((V)(0D))).Put("tongue", ((V)(0.4))).V, ((V)("io"))), "wait", ((V)(700D)));
return Invoke(t_1952, "back", ((V)(360D)));
return default;
}, 3, "putt", false)).V;
DMU_105 = Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)((-3D))), ((V)((-6D)))), NewObj(9).Put("lift", ((V)(15D))).Put("armL", ((V)(158D))).Put("armR", ((V)(158D))).Put("sq", ((V)((-0.04)))).Put("footL", ((V)(1.4))).Put("footR", ((V)(1.4))).Put("pitch", ((V)(0.06))).Put("ly", ((V)((-0.2)))).Put("tilt", ((V)(0D))).V);
DMB_106 = NewObj(5).Put("climb", Fn((V _self1956, int _argc1957, V t_1963, V _a1960, V _a1961, V _a1962, V[] _rest1958) => {
if (_self1956.IsNullish) _self1956 = GlobalV;
{
double i_1964 = 0;
i_1964 = 0D;
while (true) {
if (!((i_1964 < 4D))) break;
double s_1966 = 0;
s_1966 = (NumTruthy((i_1964 % 2D)) ? (-1D) : 1D);
Invoke(t_1963, "to", ((V)(300D)), NewObj(9).Put("armL", ((V)(((s_1966 > 0D) ? 165D : 120D)))).Put("armR", ((V)(((s_1966 > 0D) ? 120D : 165D)))).Put("footL", ((V)(((s_1966 > 0D) ? 2.6 : 0.6)))).Put("footR", ((V)(((s_1966 > 0D) ? 0.6 : 2.6)))).Put("lift", ((V)((3.75 * (i_1964 + 1D))))).Put("tilt", ((V)((s_1966 * 3D)))).Put("pitch", ((V)(0.1))).Put("ly", ((V)((-0.4)))).Put("sqz", ((V)(0.3))).V, ((V)("io")));
i_1964++;
}
}
Invoke(t_1963, "to", ((V)(240D)), Call(o_21, V.Undef, DMU_105, NewObj(1).Put("sqz", ((V)(0D))).V), ((V)("io")));
return t_1963;
return default;
}, 1, "climb", false)).Put("hang", Fn((V _self1967, int _argc1968, V t_1974, V _a1971, V _a1972, V _a1973, V[] _rest1969) => {
if (_self1967.IsNullish) _self1967 = GlobalV;
Invoke(Invoke(t_1974, "osc", ((V)(2000D)), ((V)(4D)), NewObj(3).Put("footL", ((V)(3D))).Put("footR", ((V)(0.4))).Put("tilt", ((V)(3D))).V, NewObj(3).Put("footL", ((V)(0.4))).Put("footR", ((V)(3D))).Put("tilt", ((V)((-3D)))).V, ((V)("s"))), "to", ((V)(240D)), DMU_105, ((V)("io")));
return t_1974;
return default;
}, 1, "hang", false)).Put("topwave", Fn((V _self1975, int _argc1976, V t_1982, V X_1983, V _a1980, V _a1981, V[] _rest1977) => {
if (_self1975.IsNullish) _self1975 = GlobalV;
Invoke(Invoke(Invoke(t_1982, "to", ((V)(300D)), Call(o_21, V.Undef, NewObj(5).Put("armR", ((V)(150D))).Put("hRy", ((V)((-2D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, Get(X_1983, "cheer")), ((V)("o"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("armR", ((V)(120D))).V, NewObj(1).Put("armR", ((V)(165D))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_21, V.Undef, DMU_105, NewObj(3).Put("hap", ((V)(0.3))).Put("smile", ((V)(0.7))).Put("open", ((V)(0D))).V), ((V)("io")));
return t_1982;
return default;
}, 2, "topwave", false)).Put("peek", Fn((V _self1984, int _argc1985, V t_1991, V _a1988, V _a1989, V _a1990, V[] _rest1986) => {
if (_self1984.IsNullish) _self1984 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_1991, "to", ((V)(400D)), NewObj(4).Put("lx", ((V)((-0.9)))).Put("ly", ((V)(0.9))).Put("pitch", ((V)((-0.2)))).Put("htilt", ((V)((-6D)))).V, ((V)("io"))), "wait", ((V)(600D))), "to", ((V)(400D)), NewObj(2).Put("lx", ((V)(0.9))).Put("htilt", ((V)(6D))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(300D)), Call(o_21, V.Undef, DMU_105, NewObj(2).Put("lx", ((V)(0D))).Put("htilt", ((V)(0D))).V), ((V)("io")));
return t_1991;
return default;
}, 1, "peek", false)).Put("down", Fn((V _self1992, int _argc1993, V t_1999, V _a1996, V _a1997, V _a1998, V[] _rest1994) => {
if (_self1992.IsNullish) _self1992 = GlobalV;
{
double i_2000 = 0;
i_2000 = 3D;
while (true) {
if (!((i_2000 >= 0D))) break;
double s_2002 = 0;
s_2002 = (NumTruthy((i_2000 % 2D)) ? (-1D) : 1D);
Invoke(t_1999, "to", ((V)(260D)), NewObj(6).Put("armL", ((V)(((s_2002 > 0D) ? 160D : 110D)))).Put("armR", ((V)(((s_2002 > 0D) ? 110D : 160D)))).Put("lift", ((V)((3.75 * i_2000)))).Put("footL", ((V)(((s_2002 > 0D) ? 2D : 0D)))).Put("footR", ((V)(((s_2002 > 0D) ? 0D : 2D)))).Put("tilt", ((V)((s_2002 * 3D)))).V, ((V)("io")));
i_2000--;
}
}
Invoke(t_1999, "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0.1))).V, ((V)("i")));
return Invoke(t_1999, "back", ((V)(320D)));
return default;
}, 1, "down", false)).V;
AGB_107 = NewObj(4).Put("hurdle", Fn((V _self2003, int _argc2004, V t_2010, V _a2007, V _a2008, V _a2009, V[] _rest2005) => {
if (_self2003.IsNullish) _self2003 = GlobalV;
{
double i_2011 = 0;
i_2011 = 0D;
while (true) {
if (!((i_2011 < 3D))) break;
Invoke(Invoke(Invoke(t_2010, "to", ((V)(120D)), NewObj(3).Put("sq", ((V)(0.12))).Put("lift", ((V)((-0.6)))).Put("pitch", ((V)((-0.04)))).V, ((V)("i"))), "to", ((V)(240D)), NewObj(7).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(9D))).Put("footL", ((V)(3D))).Put("footR", ((V)(3D))).Put("armL", ((V)(120D))).Put("armR", ((V)(60D))).Put("lean", ((V)(1D))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(7).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("lean", ((V)(0.4))).V, ((V)("i")));
i_2011++;
}
}
Invoke(t_2010, "fx", ((V)("dust")), ((V)("belly")), ((V)(3D)));
return Invoke(t_2010, "back", ((V)(260D)));
return default;
}, 1, "hurdle", false)).Put("weave", Fn((V _self2013, int _argc2014, V t_2020, V _a2017, V _a2018, V _a2019, V[] _rest2015) => {
if (_self2013.IsNullish) _self2013 = GlobalV;
Invoke(t_2020, "osc", ((V)(1800D)), ((V)(4D)), NewObj(4).Put("x", ((V)(3D))).Put("tilt", ((V)(7D))).Put("lean", ((V)(1D))).Put("footL", ((V)(1.6))).V, NewObj(4).Put("x", ((V)((-3D)))).Put("tilt", ((V)((-7D)))).Put("lean", ((V)((-1D)))).Put("footR", ((V)(1.6))).V, ((V)("s")));
return Invoke(t_2020, "back", ((V)(300D)));
return default;
}, 1, "weave", false)).Put("tire", Fn((V _self2021, int _argc2022, V t_2028, V X_2029, V _a2026, V _a2027, V[] _rest2023) => {
if (_self2021.IsNullish) _self2021 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_2028, "to", ((V)(260D)), NewObj(5).Put("sq", ((V)(0.16))).Put("lift", ((V)((-1.4)))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).Put("pitch", ((V)((-0.1)))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_21, V.Undef, NewObj(11).Put("sq", ((V)((-0.12)))).Put("lift", ((V)(13D))).Put("armL", ((V)(160D))).Put("armR", ((V)(160D))).Put("hLy", ((V)((-6D)))).Put("hRy", ((V)((-6D)))).Put("footL", ((V)(3D))).Put("footR", ((V)(3D))).Put("open", ((V)(0.5))).Put("wide", ((V)(0.5))).Put("hap", ((V)(1D))).V, (Get(X_2029, "tk") is var _t2030 && Truthy(_t2030) ? _t2030 : NewObj(0).V)), ((V)("o"))), "to", ((V)(300D)), NewObj(8).Put("lift", ((V)(0D))).Put("sq", ((V)(0.14))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("i"))), "fx", ((V)("dust")), ((V)("belly")), ((V)(4D))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("o")));
return Invoke(t_2028, "back", ((V)(300D)));
return default;
}, 2, "tire", false)).Put("ramp", Fn((V _self2031, int _argc2032, V t_2038, V _a2035, V _a2036, V _a2037, V[] _rest2033) => {
if (_self2031.IsNullish) _self2031 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2038, "to", ((V)(700D)), NewObj(6).Put("lift", ((V)(10D))).Put("pitch", ((V)(0.1))).Put("lean", ((V)(1D))).Put("footL", ((V)(1.6))).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("pitch", ((V)((-0.1)))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(6).Put("lift", ((V)(0D))).Put("pitch", ((V)((-0.2)))).Put("lean", ((V)(0.6))).Put("sq", ((V)(0.06))).Put("open", ((V)(0.5))).Put("wide", ((V)(0.6))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("o")));
return Invoke(t_2038, "back", ((V)(300D)));
return default;
}, 1, "ramp", false)).V;
tossB_108 = Fn((V _self2, int _argc2039, V kind_2045, V _a2042, V _a2043, V _a2044, V[] _rest2040) => {
return Fn((V _self2046, int _argc2047, V t_2053, V X_2054, V rec_2055, V _a2052, V[] _rest2048) => {
V bo_2056 = default;
if (_self2046.IsNullish) _self2046 = GlobalV;
bo_2056 = (SEqS(kind_2045, "bocce") ? V.True : V.False);
Invoke(Invoke(t_2053, "to", ((V)(300D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)((-2D))), ((V)(4D))), NewObj(6).Put("armR", ((V)((Truthy(bo_2056) ? (-8D) : 6D)))).Put("lean", ((V)((-0.5)))).Put("lx", ((V)(0.8))).Put("ly", ((V)((Truthy(bo_2056) ? 0.6 : (-0.1))))).Put("sqz", ((V)(0.3))).Put("sq", ((V)((Truthy(bo_2056) ? 0.1 : 0.04)))).V), ((V)("io"))), "to", ((V)((SEqS(kind_2045, "shoe") ? 200D : 240D))), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(2D)), ((V)((-4D)))), NewObj(6).Put("armR", ((V)((Truthy(bo_2056) ? 60D : (SEqS(kind_2045, "shoe") ? 120D : 100D))))).Put("lean", ((V)(0.8))).Put("footL", ((V)(2D))).Put("sq", ((V)((-0.03)))).Put("sqz", ((V)(0D))).Put("open", ((V)(0.3))).V), ((V)("o")));
Call(push_46, V.Undef, rec_2055, ((V)("ts")), Get(t_2053, "t"));
Invoke(Invoke(Invoke(t_2053, "to", ((V)(300D)), NewObj(2).Put("footL", ((V)(0D))).Put("lean", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(4).Put("lx", ((V)(0.9))).Put("ly", ((V)((Truthy(bo_2056) ? 0.7 : 0.3)))).Put("wide", ((V)(0.6))).Put("open", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(500D)));
return Invoke(t_2053, "back", ((V)(360D)));
return default;
}, 3, "", false);
}, 1, "", true);
aimB_109 = Fn((V _self2, int _argc2057, V t_2063, V _a2060, V _a2061, V _a2062, V[] _rest2058) => {
V B_2064 = default;
B_2064 = Get(t_2063, "B");
Invoke(Invoke(Invoke(t_2063, "to", ((V)(300D)), NewObj(5).Put("lx", ((V)(0.9))).Put("ly", ((V)(0.3))).Put("htilt", ((V)(5D))).Put("winkL", ((V)(0.8))).Put("tongue", ((V)(0.3))).V, ((V)("io"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("armR", Add(Get(B_2064, "armR"), ((V)(18D)))).V, NewObj(1).Put("armR", ((V)((ToNum(Get(B_2064, "armR")) - 6D)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("winkL", ((V)(0D))).Put("tongue", ((V)(0D))).V);
return Invoke(t_2063, "back", ((V)(300D)));
return default;
}, 1, "", true);
PG0_111 = Call(S0_39, V.Undef, NewObj(3).Put("armR", ((V)(44D))).Put("pitch", ((V)((-0.06)))).Put("ly", ((V)(0.3))).V, Call(hand_14, V.Undef, ((V)(1D)), ((V)(0D)), ((V)((-4D)))));
PGB_112 = NewObj(3).Put("serve", Fn((V _self2065, int _argc2066, V t_2072, V X_2073, V rec_2074, V _a2071, V[] _rest2067) => {
if (_self2065.IsNullish) _self2065 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2072, "to", ((V)(300D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)((-12D)))), NewObj(2).Put("armL", ((V)(70D))).Put("ly", ((V)((-0.6)))).V), ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("hLy", ((V)((-18D)))).Put("armL", ((V)(110D))).Put("ly", ((V)((-0.9)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("armR", ((V)(120D))).Put("hRy", ((V)((-8D)))).V, ((V)("io"))), "to", ((V)(110D)), NewObj(3).Put("armR", ((V)(40D))).Put("hRy", ((V)((-2D)))).Put("lean", ((V)(0.6))).V, ((V)("o")));
Call(push_46, V.Undef, rec_2074, ((V)("h")), Get(t_2072, "t"));
return Invoke(t_2072, "back", ((V)(300D)));
return default;
}, 3, "serve", false)).Put("rally", Fn((V _self2075, int _argc2076, V t_2082, V X_2083, V rec_2084, V _a2081, V[] _rest2077) => {
if (_self2075.IsNullish) _self2075 = GlobalV;
{
double i_2085 = 0;
i_2085 = 0D;
while (true) {
if (!((i_2085 < 6D))) break;
V fh_2087 = default;
fh_2087 = (((i_2085 % 2D) == 0D) ? V.True : V.False);
Invoke(Invoke(t_2082, "wait", ((V)(160D))), "to", ((V)(140D)), (Truthy(fh_2087) ? NewObj(4).Put("armR", ((V)(70D))).Put("hRx", ((V)((-4D)))).Put("lean", ((V)(0.6))).Put("x", ((V)(0.8))).V : NewObj(4).Put("armR", ((V)(30D))).Put("hRx", ((V)(6D))).Put("lean", ((V)((-0.4)))).Put("x", ((V)((-0.8)))).V), ((V)("o")));
Call(push_46, V.Undef, rec_2084, ((V)("h")), Get(t_2082, "t"));
i_2085++;
}
}
return Invoke(t_2082, "back", ((V)(300D)));
return default;
}, 3, "rally", false)).Put("smash", Fn((V _self2088, int _argc2089, V t_2095, V X_2096, V rec_2097, V _a2094, V[] _rest2090) => {
if (_self2088.IsNullish) _self2088 = GlobalV;
Invoke(Invoke(t_2095, "to", ((V)(220D)), NewObj(6).Put("armR", ((V)(160D))).Put("hRy", ((V)((-10D)))).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.06)))).Put("open", ((V)(0.4))).Put("wide", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(100D)), NewObj(5).Put("armR", ((V)(30D))).Put("hRy", ((V)(2D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).Put("lean", ((V)(1D))).V, ((V)("i")));
Call(push_46, V.Undef, rec_2097, ((V)("h")), Get(t_2095, "t"));
Invoke(Invoke(t_2095, "fx", ((V)("spark")), ((V)("pawR")), ((V)(3D))), "wait", ((V)(300D)));
return Invoke(t_2095, "back", ((V)(300D)));
return default;
}, 3, "smash", false)).V;
TTB_113 = NewObj(4).Put("punch", Fn((V _self2098, int _argc2099, V t_2105, V _a2102, V _a2103, V _a2104, V[] _rest2100) => {
if (_self2098.IsNullish) _self2098 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2105, "to", ((V)(160D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-10D)))), NewObj(3).Put("armR", ((V)(90D))).Put("lean", ((V)((-0.4)))).Put("turn", ((V)((-0.15)))).V), ((V)("io"))), "to", ((V)(140D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)((-6D))), ((V)((-14D)))), NewObj(5).Put("armR", ((V)(160D))).Put("lean", ((V)(0.8))).Put("turn", ((V)(0.15))).Put("sq", ((V)((-0.04)))).Put("open", ((V)(0.4))).V), ((V)("o"))), "fx", ((V)("spark")), ((V)("pawR")), ((V)(2D))), "to", ((V)(300D)), NewObj(4).Put("turn", ((V)(0D))).Put("lean", ((V)(0D))).Put("lx", ((V)(0.9))).Put("ly", ((V)((-0.6)))).V, ((V)("io")));
return Invoke(t_2105, "back", ((V)(300D)));
return default;
}, 1, "punch", false)).Put("duck", Fn((V _self2106, int _argc2107, V t_2113, V _a2110, V _a2111, V _a2112, V[] _rest2108) => {
if (_self2106.IsNullish) _self2106 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2113, "to", ((V)(200D)), NewObj(8).Put("sq", ((V)(0.2))).Put("lift", ((V)((-2.4)))).Put("close", ((V)(1D))).Put("sqz", ((V)(0.8))).Put("armL", ((V)(100D))).Put("armR", ((V)(100D))).Put("hLy", ((V)((-4D)))).Put("hRy", ((V)((-4D)))).V, ((V)("o"))), "wait", ((V)(400D))), "to", ((V)(260D)), NewObj(5).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("close", ((V)(0D))).Put("sqz", ((V)(0D))).Put("wide", ((V)(0.8))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("head")), ((V)(1D)));
return Invoke(t_2113, "back", ((V)(300D)));
return default;
}, 1, "duck", false)).Put("track", Fn((V _self2114, int _argc2115, V t_2121, V _a2118, V _a2119, V _a2120, V[] _rest2116) => {
if (_self2114.IsNullish) _self2114 = GlobalV;
Invoke(t_2121, "osc", ((V)(2400D)), ((V)(2D)), NewObj(3).Put("lx", ((V)(0.9))).Put("turn", ((V)(0.2))).Put("ly", ((V)((-0.5)))).V, NewObj(3).Put("lx", ((V)((-0.9)))).Put("turn", ((V)((-0.2)))).Put("ly", ((V)((-0.3)))).V, ((V)("s")));
return Invoke(t_2121, "back", ((V)(300D)));
return default;
}, 1, "track", false)).Put("double", Fn((V _self2122, int _argc2123, V t_2129, V _a2126, V _a2127, V _a2128, V[] _rest2124) => {
if (_self2122.IsNullish) _self2122 = GlobalV;
Invoke(TTB_113, "punch", t_2129);
Invoke(Invoke(t_2129, "to", ((V)(140D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)((-6D))), ((V)((-14D)))), NewObj(3).Put("armL", ((V)(160D))).Put("lean", ((V)((-0.8)))).Put("sq", ((V)((-0.04)))).V), ((V)("o"))), "fx", ((V)("spark")), ((V)("pawL")), ((V)(2D)));
return Invoke(t_2129, "back", ((V)(300D)));
return default;
}, 1, "double", false)).V;
HSB_114 = NewObj(5).Put("toss", Fn((V _self2130, int _argc2131, V t_2137, V X_2138, V rec_2139, V _a2136, V[] _rest2132) => {
if (_self2130.IsNullish) _self2130 = GlobalV;
Invoke(Invoke(t_2137, "to", ((V)(300D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)((-4D))), ((V)(6D))), NewObj(4).Put("armR", ((V)(10D))).Put("lean", ((V)((-0.4)))).Put("lx", ((V)(0.8))).Put("ly", ((V)(0.8))).V), ((V)("io"))), "to", ((V)(200D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-2D)))), NewObj(2).Put("armR", ((V)(70D))).Put("lean", ((V)(0.4))).V), ((V)("o")));
Call(push_46, V.Undef, rec_2139, ((V)("ts")), Get(t_2137, "t"));
Invoke(t_2137, "to", ((V)(500D)), NewObj(2).Put("lx", ((V)(0.9))).Put("ly", ((V)(0.9))).V, ((V)("io")));
return Invoke(t_2137, "back", ((V)(300D)));
return default;
}, 3, "toss", false)).Put("hops", Fn((V _self2140, int _argc2141, V t_2147, V _a2144, V _a2145, V _a2146, V[] _rest2142) => {
if (_self2140.IsNullish) _self2140 = GlobalV;
{
double i_2148 = 0;
i_2148 = 0D;
while (true) {
if (!((i_2148 < 6D))) break;
V one_2150 = default;
double s_2151 = 0;
one_2150 = (((i_2148 % 3D) != 2D) ? V.True : V.False);
s_2151 = (NumTruthy((i_2148 % 2D)) ? 1D : (-1D));
Invoke(Invoke(Invoke(t_2147, "to", ((V)(110D)), NewObj(2).Put("sq", ((V)(0.1))).Put("lift", ((V)((-0.5)))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(8).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(6D))).Put("footL", ((V)((Truthy(one_2150) ? 3D : 0D)))).Put("footR", ((V)(0D))).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).Put("x", ((V)(((i_2148 + 1D) * 0.8)))).Put("tilt", ((V)((Truthy(one_2150) ? (s_2151 * 2D) : 0D)))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i")));
i_2148++;
}
}
Invoke(t_2147, "to", ((V)(200D)), NewObj(2).Put("footL", ((V)(0D))).Put("tilt", ((V)(0D))).V);
return t_2147;
return default;
}, 1, "hops", false)).Put("twirl", Fn((V _self2152, int _argc2153, V t_2159, V _a2156, V _a2157, V _a2158, V[] _rest2154) => {
if (_self2152.IsNullish) _self2152 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2159, "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.1))).V, ((V)("i"))), "to", ((V)(600D)), NewObj(4).Put("spin", ((V)(360D))).Put("lift", ((V)(5D))).Put("sq", ((V)((-0.05)))).Put("hap", ((V)(1D))).V, ((V)("io"))), "to", ((V)(10D)), NewObj(1).Put("spin", ((V)(0D))).V), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i")));
return t_2159;
return default;
}, 1, "twirl", false)).Put("hopback", Fn((V _self2160, int _argc2161, V t_2167, V _a2164, V _a2165, V _a2166, V[] _rest2162) => {
if (_self2160.IsNullish) _self2160 = GlobalV;
{
double i_2168 = 0;
i_2168 = 5D;
while (true) {
if (!((i_2168 >= 0D))) break;
Invoke(Invoke(Invoke(t_2167, "to", ((V)(110D)), NewObj(1).Put("sq", ((V)(0.1))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(6).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(6D))).Put("footR", ((V)(3D))).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).Put("x", ((V)((i_2168 * 0.8)))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i")));
i_2168--;
}
}
return Invoke(t_2167, "back", ((V)(300D)));
return default;
}, 1, "hopback", false)).Put("pick", Fn((V _self2170, int _argc2171, V t_2177, V X_2178, V rec_2179, V _a2176, V[] _rest2172) => {
if (_self2170.IsNullish) _self2170 = GlobalV;
Invoke(t_2177, "to", ((V)(380D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)((-2D))), ((V)(10D))), NewObj(4).Put("pitch", ((V)((-0.4)))).Put("ly", ((V)(1D))).Put("sq", ((V)(0.1))).Put("armR", ((V)(12D))).V), ((V)("io")));
Call(push_46, V.Undef, rec_2179, ((V)("pk")), Get(t_2177, "t"));
Invoke(t_2177, "wait", ((V)(200D)));
return Invoke(t_2177, "back", ((V)(400D)));
return default;
}, 3, "pick", false)).V;
TU0_116 = Call(S0_39, V.Undef, NewObj(6).Put("sq", ((V)(0.16))).Put("lift", ((V)((-2.4)))).Put("pitch", ((V)((-0.22)))).Put("ly", ((V)(0.8))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, Call(both_15, V.Undef, ((V)((-4D))), ((V)(6D))));
TUB_117 = NewObj(3).Put("crawl", Fn((V _self2180, int _argc2181, V t_2187, V _a2184, V _a2185, V _a2186, V[] _rest2182) => {
if (_self2180.IsNullish) _self2180 = GlobalV;
{
double i_2188 = 0;
i_2188 = 0D;
while (true) {
if (!((i_2188 < 6D))) break;
double s_2190 = 0;
s_2190 = (NumTruthy((i_2188 % 2D)) ? (-1D) : 1D);
Invoke(t_2187, "to", ((V)(220D)), NewObj(6).Put("armL", ((V)(((s_2190 > 0D) ? 82D : 46D)))).Put("armR", ((V)(((s_2190 > 0D) ? 46D : 82D)))).Put("footL", ((V)(((s_2190 > 0D) ? 0D : 1.6)))).Put("footR", ((V)(((s_2190 > 0D) ? 1.6 : 0D)))).Put("tilt", ((V)((s_2190 * 3D)))).Put("x", ((V)((s_2190 * 0.5)))).V, ((V)("io")));
i_2188++;
}
}
return Invoke(t_2187, "back", ((V)(260D)));
return default;
}, 1, "crawl", false)).Put("peek", Fn((V _self2191, int _argc2192, V t_2198, V _a2195, V _a2196, V _a2197, V[] _rest2193) => {
if (_self2191.IsNullish) _self2191 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2198, "to", ((V)(300D)), NewObj(5).Put("pitch", ((V)(0.12))).Put("ly", ((V)((-0.2)))).Put("sq", ((V)(0.06))).Put("wide", ((V)(0.6))).Put("lx", ((V)((-0.8)))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(400D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(300D)));
return Invoke(t_2198, "back", ((V)(300D)));
return default;
}, 1, "peek", false)).Put("pop", Fn((V _self2199, int _argc2200, V t_2206, V X_2207, V _a2204, V _a2205, V[] _rest2201) => {
if (_self2199.IsNullish) _self2199 = GlobalV;
Invoke(t_2206, "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.2))).Put("lift", ((V)((-3D)))).V, ((V)("i")));
Call(cheer_47, V.Undef, t_2206, X_2207, NewObj(2).Put("pitch", ((V)(0.06))).Put("ly", ((V)(0D))).V);
return t_2206;
return default;
}, 2, "pop", false)).V;
FRB_118 = NewObj(2).Put("throw", Fn((V _self2208, int _argc2209, V t_2215, V X_2216, V rec_2217, V _a2214, V[] _rest2210) => {
if (_self2208.IsNullish) _self2208 = GlobalV;
Invoke(Invoke(t_2215, "to", ((V)(320D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(10D)), ((V)(0D))), NewObj(4).Put("armR", ((V)(30D))).Put("turn", ((V)((-0.2)))).Put("lean", ((V)((-0.4)))).Put("lx", ((V)(0.6))).V), ((V)("io"))), "to", ((V)(160D)), Call(o_21, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)((-6D))), ((V)((-4D)))), NewObj(4).Put("armR", ((V)(96D))).Put("turn", ((V)(0.2))).Put("lean", ((V)(0.8))).Put("open", ((V)(0.3))).V), ((V)("o")));
Call(push_46, V.Undef, rec_2217, ((V)("th")), Get(t_2215, "t"));
Invoke(Invoke(t_2215, "to", ((V)(400D)), NewObj(4).Put("turn", ((V)(0D))).Put("lean", ((V)(0.2))).Put("lx", ((V)(0.9))).Put("ly", ((V)((-0.3)))).V, ((V)("io"))), "to", ((V)(600D)), NewObj(2).Put("lx", ((V)((-0.2)))).Put("ly", ((V)((-0.6)))).V, ((V)("io")));
return t_2215;
return default;
}, 3, "throw", false)).Put("catch", Fn((V _self2218, int _argc2219, V t_2225, V X_2226, V rec_2227, V _a2224, V[] _rest2220) => {
if (_self2218.IsNullish) _self2218 = GlobalV;
Invoke(Invoke(t_2225, "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.12))).Put("lift", ((V)((-1D)))).V, ((V)("i"))), "to", ((V)(240D)), Call(o_21, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-14D)))), NewObj(6).Put("armL", ((V)(160D))).Put("armR", ((V)(160D))).Put("lift", ((V)(10D))).Put("sq", ((V)((-0.08)))).Put("wide", ((V)(0.6))).Put("open", ((V)(0.5))).V), ((V)("o")));
Call(push_46, V.Undef, rec_2227, ((V)("ca")), Get(t_2225, "t"));
Invoke(Invoke(t_2225, "to", ((V)(260D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "to", ((V)(200D)), Call(o_21, V.Undef, NewObj(4).Put("sq", ((V)(0D))).Put("sqz", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, Get(X_2226, "cheer")), ((V)("o")));
return Invoke(t_2225, "back", ((V)(360D)));
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
