// rive-rig.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_rive_rig_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("[a-zA-Z]|-?\\d*\\.?\\d+(?:e-?\\d+)?", "g");
        static readonly System.Text.RegularExpressions.Regex RX1 = JsRegExp.Compile("[a-zA-Z]", "");
        static readonly System.Text.RegularExpressions.Regex RX2 = JsRegExp.Compile("R$", "");
        static readonly System.Text.RegularExpressions.Regex RX3 = JsRegExp.Compile("L$", "");
        static readonly System.Text.RegularExpressions.Regex RX4 = JsRegExp.Compile("dance", "");
        static readonly System.Text.RegularExpressions.Regex RX5 = JsRegExp.Compile("url\\([\"']?#([^\"')]+)[\"']?\\)", "");
        static readonly System.Text.RegularExpressions.Regex RX6 = JsRegExp.Compile("^#f{6}$", "i");
        static readonly System.Text.RegularExpressions.Regex RX7 = JsRegExp.Compile("url\\(#([^)]+)\\)", "");
        static readonly System.Text.RegularExpressions.Regex RX8 = JsRegExp.Compile("Q", "g");
        static readonly System.Text.RegularExpressions.Regex RX9 = JsRegExp.Compile("[MQZ]", "g");
        static readonly System.Text.RegularExpressions.Regex RX10 = JsRegExp.Compile("[CLAHVS]", "i");
        static readonly System.Text.RegularExpressions.Regex RX11 = JsRegExp.Compile("-?\\d+\\.?\\d*", "g");
        static readonly System.Text.RegularExpressions.Regex RX12 = JsRegExp.Compile("rgba?\\(([\\d.]+),\\s*([\\d.]+),\\s*([\\d.]+)", "");
        static readonly System.Text.RegularExpressions.Regex RX13 = JsRegExp.Compile("^#([\\da-f]{3}|[\\da-f]{6})$", "i");
        static readonly System.Text.RegularExpressions.Regex RX14 = JsRegExp.Compile(".", "g");
        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V FAB_8 = default;
V fabricFx_9 = default;
V NS_10 = default;
double D2R_11 = 0;
double TAU_12 = 0;
V clamp_13 = default;
V r2_14 = default;
V lerp_15 = default;
V SM_16 = default;
V bez_17 = default;
V EZ_18 = default;
V kv_19 = default;
V Fol_20 = default;
V parsePath_21 = default;
V ellS_22 = default;
V furRing_23 = default;
V furPts_24 = default;
V toD_25 = default;
V smoothD_26 = default;
V flat_27 = default;
V hull_28 = default;
V closedD_29 = default;
V ellAx_30 = default;
V earSec_31 = default;
V mk_32 = default;
V star4_33 = default;
V DEFS_34 = default;
V REST_35 = default;
V AR_36 = default;
V ER_37 = default;
V STATES_38 = default;
V RELEASE_39 = default;
V POKE_40 = default;
V HYAW_41 = default;
V SOFT_42 = default;
V poseAt_43 = default;
V DENT_44 = default;
V setState_45 = default;
V fire_46 = default;
V poke_47 = default;
V region_48 = default;
V PRE_49 = default;
V where_50 = default;
V emit_51 = default;
V drawParts_52 = default;
V wPrep_53 = default;
V DUCK_54 = default;
V bub_55 = default;
V dustBath_56 = default;
V water_57 = default;
V blinkC_58 = default;
V tick_59 = default;
V whipFx_60 = default;
V FX_61 = default;
V render_62 = default;
V coatBuild_63 = default;
V hogBuild_64 = default;
V ALL_65 = default;
V raf_66 = default;
V last_67 = default;
double UID_68 = 0;
V loop_69 = default;
V kick_70 = default;
V LPARTS_71 = default;
V LOCC_72 = default;
V LRECT_73 = default;
V LOOK0_74 = default;
V MODES_75 = default;
double LOOK_76 = 0;
V rgbP_77 = default;
V rgbOf_78 = default;
V hsl_79 = default;
V hex_80 = default;
V lineOf_81 = default;
V shadeOf_82 = default;
V mixHex_83 = default;
V lightSrc_84 = default;
V FACE_85 = default;
V applyLook_86 = default;
V faceLines_87 = default;
V sqSvgPt_88 = default;
V outlineEls_89 = default;
V SVGNS_90 = default;
V outline_91 = default;
V outlineTick_92 = default;
V setLight_93 = default;
V litTick_94 = default;
V mount_95 = default;
V FIDGETS_96 = default;
V FIDK_97 = default;
V PRESS_98 = default;
V REL_99 = default;
if (_self1.IsNullish) _self1 = GlobalV;
fabricFx_9 = Fn((V _self100, int _argc101, V _a103, V _a104, V _a105, V _a106, V[] _rest102) => {
if (_self100.IsNullish) _self100 = GlobalV;
if (SEq(FAB_8, V.Null)) {
FAB_8 = ((V)(""));
try {
double S_107 = 0;
V cv_108 = default;
V x_109 = default;
V im_110 = default;
double sd_111 = 0;
V rnd_112 = default;
V oct_113 = default;
V o1_114 = default;
V o2_115 = default;
double B_116 = 0;
V cb_117 = default;
V xb_118 = default;
S_107 = 128D;
cv_108 = Invoke(G("document"), "createElement", ((V)("canvas")));
Set(cv_108, "width", Set(cv_108, "height", ((V)(S_107))));
x_109 = Invoke(cv_108, "getContext", ((V)("2d")));
im_110 = Invoke(x_109, "createImageData", ((V)(S_107)), ((V)(S_107)));
sd_111 = 7D;
rnd_112 = Fn((V _arrowThis125, int _argc119, V _a121, V _a122, V _a123, V _a124, V[] _rest120) => {
return ((V)(((sd_111 = ((sd_111 * 16807D) % 2147483647D)) / 2147483647D)));
}, 0, "", true);
oct_113 = Fn((V _arrowThis133, int _argc126, V n_132, V _a129, V _a130, V _a131, V[] _rest127) => {
V g_134 = default;
double c_135 = 0;
V sm_136 = default;
g_134 = Arr();
{
double i_137 = 0;
i_137 = 0D;
while (true) {
if (!((i_137 < (ToNum(n_132) * ToNum(n_132))))) break;
Invoke(g_134, "push", Call(rnd_112, V.Undef));
i_137++;
}
}
c_135 = (S_107 / ToNum(n_132));
sm_136 = Fn((V _arrowThis146, int _argc139, V t_145, V _a142, V _a143, V _a144, V[] _rest140) => {
return ((V)(((ToNum(t_145) * ToNum(t_145)) * (3D - (2D * ToNum(t_145))))));
}, 1, "", true);
return Fn((V _arrowThis155, int _argc147, V px_153, V py_154, V _a151, V _a152, V[] _rest148) => {
double gx_156 = 0;
double gy_157 = 0;
double x0_158 = 0;
double y0_159 = 0;
V fx_160 = default;
V fy_161 = default;
V a_162 = default;
V t_163 = default;
V b_164 = default;
gx_156 = (ToNum(px_153) / c_135);
gy_157 = (ToNum(py_154) / c_135);
x0_158 = System.Math.Floor(gx_156);
y0_159 = System.Math.Floor(gy_157);
fx_160 = Call(sm_136, V.Undef, ((V)((gx_156 - x0_158))));
fy_161 = Call(sm_136, V.Undef, ((V)((gy_157 - y0_159))));
a_162 = Fn((V _arrowThis173, int _argc165, V i_171, V j_172, V _a169, V _a170, V[] _rest166) => {
return GetIdx(g_134, (((ToNum(Add(((V)((ToNum(j_172) % ToNum(n_132)))), n_132)) % ToNum(n_132)) * ToNum(n_132)) + (ToNum(Add(((V)((ToNum(i_171) % ToNum(n_132)))), n_132)) % ToNum(n_132))));
}, 2, "", true);
t_163 = Add(Call(a_162, V.Undef, ((V)(x0_158)), ((V)(y0_159))), ((V)(((ToNum(Call(a_162, V.Undef, ((V)((x0_158 + 1D))), ((V)(y0_159)))) - ToNum(Call(a_162, V.Undef, ((V)(x0_158)), ((V)(y0_159))))) * ToNum(fx_160)))));
b_164 = Add(Call(a_162, V.Undef, ((V)(x0_158)), ((V)((y0_159 + 1D)))), ((V)(((ToNum(Call(a_162, V.Undef, ((V)((x0_158 + 1D))), ((V)((y0_159 + 1D))))) - ToNum(Call(a_162, V.Undef, ((V)(x0_158)), ((V)((y0_159 + 1D)))))) * ToNum(fx_160)))));
return Add(t_163, ((V)(((ToNum(b_164) - ToNum(t_163)) * ToNum(fy_161)))));
return default;
}, 2, "", true);
return default;
}, 1, "", true);
o1_114 = Call(oct_113, V.Undef, ((V)(32D)));
o2_115 = Call(oct_113, V.Undef, ((V)(64D)));
{
double y_174 = 0;
y_174 = 0D;
while (true) {
if (!((y_174 < S_107))) break;
{
double X_176 = 0;
X_176 = 0D;
while (true) {
if (!((X_176 < S_107))) break;
double v_178 = 0;
double k_179 = 0;
v_178 = (ToNum(Add(Call(o1_114, V.Undef, ((V)(X_176)), ((V)(y_174))), Call(o2_115, V.Undef, ((V)(X_176)), ((V)(y_174))))) / 2D);
k_179 = (((y_174 * S_107) + X_176) * 4D);
SetIdx(Get(im_110, "data"), (k_179 + 3D), ((V)(Round(((0.2 * 255D) * v_178)))));
X_176++;
}
}
y_174++;
}
}
Invoke(x_109, "putImageData", im_110, ((V)(0D)), ((V)(0D)));
B_116 = 1024D;
cb_117 = Invoke(G("document"), "createElement", ((V)("canvas")));
Set(cb_117, "width", Set(cb_117, "height", ((V)(B_116))));
xb_118 = Invoke(cb_117, "getContext", ((V)("2d")));
Set(xb_118, "fillStyle", Invoke(xb_118, "createPattern", cv_108, ((V)("repeat"))));
Invoke(xb_118, "fillRect", ((V)(0D)), ((V)(0D)), ((V)(B_116)), ((V)(B_116)));
FAB_8 = Invoke(cb_117, "toDataURL", ((V)("image/png")));
} catch (System.Exception _ex180) {
V e_181 = default;
e_181 = Caught(_ex180);
FAB_8 = ((V)(""));
}
}
return ((V)((Truthy(FAB_8) ? JsStrBuf.Begin().S("<feImage href=\"").V(FAB_8).S("\" x=\"-30\" y=\"-30\" width=\"160\" height=\"160\" preserveAspectRatio=\"none\"/>").End() : "<feFlood flood-opacity=\"0\"/>")));
return default;
}, 0, "fabricFx", false);
parsePath_21 = Fn((V _self182, int _argc183, V d_189, V _a186, V _a187, V _a188, V[] _rest184) => {
V tk_190 = default;
double i_191 = 0;
V cmd_192 = default;
V x_193 = default;
V y_194 = default;
V sx_195 = default;
V sy_196 = default;
V @out_197 = default;
V n_198 = default;
if (_self182.IsNullish) _self182 = GlobalV;
tk_190 = (Invoke(d_189, "match", NewRegExp(RX0, "[a-zA-Z]|-?\\d*\\.?\\d+(?:e-?\\d+)?", "g")) is var _t199 && Truthy(_t199) ? _t199 : Arr());
i_191 = 0D;
cmd_192 = ((V)(""));
x_193 = ((V)(0D));
y_194 = ((V)(0D));
sx_195 = ((V)(0D));
sy_196 = ((V)(0D));
@out_197 = Arr();
n_198 = Fn((V _arrowThis206, int _argc200, V _a202, V _a203, V _a204, V _a205, V[] _rest201) => {
return ((V)(ToNum(GetIdx(tk_190, i_191++))));
}, 0, "", true);
while (Lt(((V)(i_191)), Get(tk_190, "length"))) {
V C_207 = default;
V rel_208 = default;
V ox_209 = default;
V oy_210 = default;
if (Truthy(Invoke(NewRegExp(RX1, "[a-zA-Z]", ""), "test", GetIdx(tk_190, i_191)))) {
cmd_192 = GetIdx(tk_190, i_191++);
}
C_207 = Invoke(cmd_192, "toUpperCase");
rel_208 = (!SEq(cmd_192, C_207) ? V.True : V.False);
ox_209 = (Truthy(rel_208) ? x_193 : ((V)(0D)));
oy_210 = (Truthy(rel_208) ? y_194 : ((V)(0D)));
if (SEqS(C_207, "Z")) {
Invoke(@out_197, "push", NewObj(1).Put("c", ((V)("Z"))).V);
x_193 = sx_195;
y_194 = sy_196;
continue;
}
if ((SEqS(C_207, "M") || SEqS(C_207, "L"))) {
V p_211 = default;
p_211 = Arr(Add(ox_209, Call(n_198, V.Undef)), Add(oy_210, Call(n_198, V.Undef)));
Invoke(@out_197, "push", NewObj(2).Put("c", C_207).Put("p", Arr(p_211)).V);
{ V _t212 = p_211;
{ V _t213 = ListOf(_t212);
{ V _t214 = GetIdx(_t213, 0D);
x_193 = _t214; }
{ V _t215 = GetIdx(_t213, 1D);
y_194 = _t215; }
} }
if (SEqS(C_207, "M")) {
sx_195 = x_193;
sy_196 = y_194;
cmd_192 = ((V)((Truthy(rel_208) ? "l" : "L")));
}
} else {
if (SEqS(C_207, "Q")) {
V a_216 = default;
V b_217 = default;
a_216 = Arr(Add(ox_209, Call(n_198, V.Undef)), Add(oy_210, Call(n_198, V.Undef)));
b_217 = Arr(Add(ox_209, Call(n_198, V.Undef)), Add(oy_210, Call(n_198, V.Undef)));
Invoke(@out_197, "push", NewObj(2).Put("c", ((V)("Q"))).Put("p", Arr(a_216, b_217)).V);
{ V _t218 = b_217;
{ V _t219 = ListOf(_t218);
{ V _t220 = GetIdx(_t219, 0D);
x_193 = _t220; }
{ V _t221 = GetIdx(_t219, 1D);
y_194 = _t221; }
} }
} else {
if (SEqS(C_207, "C")) {
V a_222 = default;
V b_223 = default;
V c_224 = default;
a_222 = Arr(Add(ox_209, Call(n_198, V.Undef)), Add(oy_210, Call(n_198, V.Undef)));
b_223 = Arr(Add(ox_209, Call(n_198, V.Undef)), Add(oy_210, Call(n_198, V.Undef)));
c_224 = Arr(Add(ox_209, Call(n_198, V.Undef)), Add(oy_210, Call(n_198, V.Undef)));
Invoke(@out_197, "push", NewObj(2).Put("c", ((V)("C"))).Put("p", Arr(a_222, b_223, c_224)).V);
{ V _t225 = c_224;
{ V _t226 = ListOf(_t225);
{ V _t227 = GetIdx(_t226, 0D);
x_193 = _t227; }
{ V _t228 = GetIdx(_t226, 1D);
y_194 = _t228; }
} }
} else {
i_191++;
}
}
}
}
return @out_197;
return default;
}, 1, "parsePath", false);
poseAt_43 = Fn((V _self229, int _argc230, V name_236, V t_237, V key_238, V _a235, V[] _rest231) => {
V st_239 = default;
V P_240 = default;
V id_241 = default;
double tl_242 = 0;
if (_self229.IsNullish) _self229 = GlobalV;
if (Truthy((key_238 is var _t243 && !Truthy(_t243) ? _t243 : Get(G("window"), "SquishLazy")))) {
Invoke(Get(G("window"), "SquishLazy"), "need", key_238);
}
st_239 = ((key_238 is var _t244 && !Truthy(_t244) ? _t244 : GetK(STATES_38, ((V)(JsStrBuf.Begin().V(name_236).S("@").V(key_238).End())))) is var _t245 && Truthy(_t245) ? _t245 : GetK(STATES_38, name_236));
P_240 = Object_assign(NewObj(0).V, REST_35);
id_241 = Get(STATES_38, "idle");
if (!SEqS(name_236, "idle")) {
double ti_246 = 0;
ti_246 = (ToNum(t_237) % ToNum(Get(id_241, "loop")));
{
foreach (V _k247 in ForInKeys(Get(id_241, "k"))) {
V k_248 = default;
k_248 = _k247;
SetK(P_240, k_248, Call(kv_19, V.Undef, GetK(Get(id_241, "k"), k_248), ((V)(ti_246))));
}
}
}
tl_242 = (Truthy(Get(st_239, "loop")) ? (ToNum(t_237) % ToNum(Get(st_239, "loop"))) : Min(ToNum(t_237), ToNum((Get(st_239, "dur") is var _t249 && Truthy(_t249) ? _t249 : t_237))));
{
foreach (V _k250 in ForInKeys(Get(st_239, "k"))) {
V k_251 = default;
k_251 = _k250;
SetK(P_240, k_251, Call(kv_19, V.Undef, GetK(Get(st_239, "k"), k_251), ((V)(tl_242))));
}
}
if (Truthy(Get(st_239, "breathe"))) {
V bk_252 = default;
bk_252 = Get(st_239, "breathe");
OpSet(P_240, "sq", 0, ((V)(((FdLibm.Sin((ToNum(t_237) / 640D)) * 0.013) * ToNum(bk_252)))));
OpSet(P_240, "lean", 0, ((V)(((FdLibm.Sin((ToNum(t_237) / 1350D)) * 0.4) * ToNum(bk_252)))));
OpSet(P_240, "htilt", 0, ((V)(((FdLibm.Sin(((ToNum(t_237) / 1900D) + 1D)) * 0.8) * ToNum(bk_252)))));
}
return P_240;
return default;
}, 3, "poseAt", false);
setState_45 = Fn((V _self253, int _argc254, V I_260, V name_261, V now_262, V keepQ_263, V[] _rest255) => {
V st_264 = default;
if (_self253.IsNullish) _self253 = GlobalV;
if (!(Truthy(GetK(STATES_38, name_261)))) {
name_261 = ((V)("idle"));
}
if (Truthy(Get(G("window"), "SquishConfig"))) {
name_261 = Invoke(Get(G("window"), "SquishConfig"), "gateState", Get(I_260, "ak"), name_261, STATES_38);
}
if (!(Truthy(keepQ_263))) {
Set(I_260, "queue", Arr());
}
if (Truthy(Get(GetK(STATES_38, name_261), "seq"))) {
Set(I_260, "queue", Invoke(Get(GetK(STATES_38, name_261), "seq"), "slice", ((V)(1D))));
name_261 = GetIdx(Get(GetK(STATES_38, name_261), "seq"), 0D);
if (!(Truthy(GetK(STATES_38, name_261)))) {
name_261 = ((V)("idle"));
}
if (Truthy(Get(G("window"), "SquishConfig"))) {
name_261 = Invoke(Get(G("window"), "SquishConfig"), "gateState", Get(I_260, "ak"), name_261, STATES_38);
}
}
Set(I_260, "prev", (Truthy(Get(I_260, "prev")) ? NewObj(1).Put("frozen", Get(I_260, "lastP")).V : NewObj(2).Put("name", Get(Get(I_260, "cur"), "name")).Put("t0", Get(Get(I_260, "cur"), "t0")).V));
Set(I_260, "cur", NewObj(2).Put("name", name_261).Put("t0", now_262).V);
Set(I_260, "bt0", now_262);
Set(I_260, "bd", (Get(GetK(STATES_38, name_261), "blend") is var _t265 && Truthy(_t265) ? _t265 : ((V)(280D))));
Set(I_260, "evC", ((V)((-1D))));
Set(I_260, "evF", NewObj(0).V);
Set(I_260, "ctr", NewObj(0).V);
Set(I_260, "ctT", NewObj(0).V);
Set(I_260, "emL", NewObj(0).V);
st_264 = GetK(STATES_38, name_261);
if (Truthy(Get(st_264, "tap"))) {
V tp_266 = default;
tp_266 = (Truthy(Get(I_260, "fromM")) ? Invoke(I_260, "fromM", GetIdx(Get(st_264, "tap"), 0D), GetIdx(Get(st_264, "tap"), 1D)) : Get(st_264, "tap"));
Invoke(Get(I_260, "shots"), "push", NewObj(4).Put("S", DENT_44).Put("t0", now_262).Put("x", GetIdx(tp_266, 0D)).Put("y", GetIdx(tp_266, 1D)).V);
}
if (Truthy(Get(I_260, "onState"))) {
Invoke(I_260, "onState", name_261);
}
return default;
}, 4, "setState", false);
fire_46 = Fn((V _self267, int _argc268, V I_274, V e_275, V now_276, V _a273, V[] _rest269) => {
V n_277 = default;
V st_278 = default;
if (_self267.IsNullish) _self267 = GlobalV;
n_277 = GetIdx(e_275, 1D);
SetK(Get(I_274, "ctr"), n_277, Add((GetK(Get(I_274, "ctr"), n_277) is var _t279 && Truthy(_t279) ? _t279 : ((V)(0D))), ((V)(1D))));
SetK(Get(I_274, "ctT"), n_277, now_276);
if ((SEqS(n_277, "blink") || SEqS(n_277, "blink2"))) {
Set(I_274, "blinkT", now_276);
Set(I_274, "dbl", (SEqS(n_277, "blink2") ? V.True : V.False));
Set(I_274, "blinkAt", Add(now_276, ((V)(2600D))));
} else {
if (SEqS(n_277, "poke")) {
Call(poke_47, V.Undef, I_274, GetIdx(e_275, 2D), GetIdx(e_275, 3D), now_276);
} else {
if (SEqS(n_277, "emit")) {
Call(emit_51, V.Undef, I_274, GetIdx(e_275, 2D), GetIdx(e_275, 3D), GetIdx(e_275, 4D));
}
}
}
st_278 = GetK(STATES_38, Get(Get(I_274, "cur"), "name"));
if (Truthy((Get(st_278, "on") is var _t280 && !Truthy(_t280) ? _t280 : GetK(Get(st_278, "on"), n_277)))) {
InvokeK(Get(st_278, "on"), n_277, I_274, e_275, now_276);
}
return default;
}, 3, "fire", false);
poke_47 = Fn((V _self281, int _argc282, V I_288, V x_289, V y_290, V now_291, V[] _rest283) => {
if (_self281.IsNullish) _self281 = GlobalV;
Invoke(Get(I_288, "shots"), "push", NewObj(4).Put("S", Call(POKE_40, V.Undef, ((V)((LtN(x_289, 50D) ? 1D : (-1D)))))).Put("t0", now_291).Put("x", x_289).Put("y", y_290).V);
return default;
}, 4, "poke", false);
region_48 = Fn((V _self292, int _argc293, V I_299, V x_300, V y_301, V _a298, V[] _rest294) => {
V P_302 = default;
double dx_303 = 0;
double dh_304 = 0;
V L_305 = default;
if (_self292.IsNullish) _self292 = GlobalV;
P_302 = (Get(I_299, "lastP") is var _t306 && Truthy(_t306) ? _t306 : REST_35);
x_300 = ((V)((ToNum(x_300) - ToNum(Get(P_302, "x")))));
y_301 = Add(y_301, Get(P_302, "lift"));
if (Truthy(Get(I_299, "toM"))) {
{ V _t307 = Invoke(I_299, "toM", x_300, y_301);
{ V _t308 = ListOf(_t307);
{ V _t309 = GetIdx(_t308, 0D);
x_300 = _t309; }
{ V _t310 = GetIdx(_t308, 1D);
y_301 = _t310; }
} }
}
dx_303 = (ToNum(x_300) - 50D);
dh_304 = Hypot(dx_303, (ToNum(y_301) - 46D));
L_305 = ((dx_303 < 0D) ? V.True : V.False);
if (((GtN(x_300, 74D) && GtN(y_301, 56D)) && LtN(y_301, 92D))) {
return ((V)("tail"));
}
if (GtN(y_301, 87D)) {
return ((V)((Truthy(L_305) ? "footL" : "footR")));
}
if ((LtN(y_301, 30D) && (System.Math.Abs(dx_303) > 9D))) {
return ((V)((Truthy(L_305) ? "earL" : "earR")));
}
if ((GeN(y_301, 70D) && (System.Math.Abs(dx_303) < 13D))) {
return ((V)("belly"));
}
if ((GeN(y_301, 64D) && (System.Math.Abs(dx_303) >= 13D))) {
return ((V)((Truthy(L_305) ? "sideL" : "sideR")));
}
if ((dh_304 < 31D)) {
if (LtN(y_301, 38D)) {
return ((V)("head"));
}
if ((((System.Math.Abs(dx_303) < 6D) && GeN(y_301, 50D)) && LtN(y_301, 62D))) {
return ((V)("nose"));
}
if (((GeN(y_301, 40D) && LtN(y_301, 52D)) && (System.Math.Abs((System.Math.Abs(dx_303) - 12D)) < 6D))) {
return ((V)((Truthy(L_305) ? "eyeL" : "eyeR")));
}
if (LtN(y_301, 50D)) {
return ((V)("head"));
}
return ((V)((Truthy(L_305) ? "cheekL" : "cheekR")));
}
return ((V)((Truthy(L_305) ? "sideL" : "sideR")));
return default;
}, 3, "region", false);
where_50 = Fn((V _self311, int _argc312, V I_318, V w_319, V _a316, V _a317, V[] _rest313) => {
V p_320 = default;
double sd_321 = 0;
if (_self311.IsNullish) _self311 = GlobalV;
if ((w_319.O is JsArray)) {
return Arr(GetIdx(w_319, 0D), GetIdx(w_319, 1D), ((V)((LtN(GetIdx(w_319, 0D), 50D) ? (-1D) : 1D))));
}
p_320 = ((Get(I_318, "W") is var _t322 && !Truthy(_t322) ? _t322 : GetK(Get(I_318, "W"), w_319)) is var _t323 && Truthy(_t323) ? _t323 : Arr(((V)(50D)), ((V)(50D))));
sd_321 = (Truthy(Invoke(NewRegExp(RX3, "L$", ""), "test", w_319)) ? (-1D) : (Truthy((Invoke(NewRegExp(RX2, "R$", ""), "test", w_319) is var _t324 && Truthy(_t324) ? _t324 : (SEqS(w_319, "tail") ? V.True : V.False))) ? 1D : 0D));
return Arr(GetIdx(p_320, 0D), GetIdx(p_320, 1D), ((V)(sd_321)));
return default;
}, 2, "where", false);
emit_51 = Fn((V _self325, int _argc326, V I_332, V name_333, V w_334, V n_335, V[] _rest327) => {
V q_336 = default;
V x_337 = default;
V y_338 = default;
V sd_339 = default;
if (_self325.IsNullish) _self325 = GlobalV;
q_336 = GetK(PRE_49, name_333);
if (!(Truthy(q_336))) {
return default;
}
{ V _t340 = Call(where_50, V.Undef, I_332, w_334);
{ V _t341 = ListOf(_t340);
{ V _t342 = GetIdx(_t341, 0D);
x_337 = _t342; }
{ V _t343 = GetIdx(_t341, 1D);
y_338 = _t343; }
{ V _t344 = GetIdx(_t341, 2D);
sd_339 = _t344; }
} }
n_335 = (n_335 is var _t345 && Truthy(_t345) ? _t345 : Get(q_336, "n"));
{
double i_346 = 0;
i_346 = 0D;
while (true) {
if (!((Lt(((V)(i_346)), n_335) && LtN(Get(Get(I_332, "parts"), "length"), 140D)))) break;
double a_348 = 0;
double m_349 = 0;
V side_350 = default;
a_348 = (ToNum(Invoke(G("Math"), "random")) * TAU_12);
m_349 = (ToNum(Invoke(G("Math"), "random")) * ToNum(Get(q_336, "sp")));
side_350 = (Truthy(Get(q_336, "out")) ? (sd_339 is var _t351 && Truthy(_t351) ? _t351 : ((V)((LtN(Invoke(G("Math"), "random"), 0.5) ? (-1D) : 1D)))) : ((V)(1D)));
Invoke(Get(I_332, "parts"), "push", NewObj(12).Put("x", Add(x_337, ((V)((FdLibm.Cos(a_348) * 0.6))))).Put("y", Add(y_338, ((V)((FdLibm.Sin(a_348) * 0.6))))).Put("vx", ((V)(((ToNum((Get(q_336, "vx") is var _t352 && Truthy(_t352) ? _t352 : ((V)(0D)))) * ToNum(side_350)) + (FdLibm.Cos(a_348) * m_349))))).Put("vy", Add((Get(q_336, "vy") is var _t353 && Truthy(_t353) ? _t353 : ((V)(0D))), ((V)(((FdLibm.Sin(a_348) * m_349) * 0.7))))).Put("g", Get(q_336, "g")).Put("life", ((V)((ToNum(Get(q_336, "life")) * (0.8 + (ToNum(Invoke(G("Math"), "random")) * 0.4)))))).Put("age", ((V)(0D))).Put("r", Add(GetIdx(Get(q_336, "r"), 0D), ((V)((ToNum(Invoke(G("Math"), "random")) * (ToNum(GetIdx(Get(q_336, "r"), 1D)) - ToNum(GetIdx(Get(q_336, "r"), 0D)))))))).Put("col", (Truthy(Get(q_336, "col")) ? GetIdx(Get(q_336, "col"), System.Math.Floor((ToNum(Invoke(G("Math"), "random")) * ToNum(Get(Get(q_336, "col"), "length"))))) : ((V)("#fff")))).Put("kind", Get(q_336, "kind")).Put("ph", ((V)((ToNum(Invoke(G("Math"), "random")) * TAU_12)))).Put("gy", (Truthy(Get(q_336, "hop")) ? y_338 : V.Null)).V);
i_346++;
}
}
return default;
}, 4, "emit", false);
drawParts_52 = Fn((V _self354, int _argc355, V I_361, V dt_362, V _a359, V _a360, V[] _rest356) => {
JsStrBuf h_363 = null;
if (_self354.IsNullish) _self354 = GlobalV;
h_363 = new JsStrBuf("");
Set(I_361, "parts", Invoke(Get(I_361, "parts"), "filter", Fn((V _arrowThis371, int _argc364, V p_370, V _a367, V _a368, V _a369, V[] _rest365) => {
double u_372 = 0;
V op_373 = default;
V tr_374 = default;
OpSet(p_370, "age", 0, ((V)((ToNum(dt_362) * 1000D))));
if (Gt(Get(p_370, "age"), Get(p_370, "life"))) {
return (false ? V.True : V.False);
}
OpSet(p_370, "vy", 0, ((V)((ToNum(Get(p_370, "g")) * ToNum(dt_362)))));
OpSet(p_370, "x", 0, ((V)((ToNum(Get(p_370, "vx")) * ToNum(dt_362)))));
OpSet(p_370, "y", 0, ((V)((ToNum(Get(p_370, "vy")) * ToNum(dt_362)))));
if (((!Get(p_370, "gy").IsNullish && Gt(Get(p_370, "y"), Get(p_370, "gy"))) && GtN(Get(p_370, "vy"), 0D))) {
Set(p_370, "y", Get(p_370, "gy"));
Set(p_370, "vy", ((V)(((-24D) * (0.85 + (ToNum(Invoke(G("Math"), "random")) * 0.3))))));
Set(p_370, "land", Get(p_370, "age"));
}
u_372 = (ToNum(Get(p_370, "age")) / ToNum(Get(p_370, "life")));
op_373 = Call(r2_14, V.Undef, ((V)((Min(1D, (u_372 * 8D)) * (1D - ToNum(Call(SM_16, V.Undef, ((V)(((u_372 - 0.7) / 0.3))))))))));
tr_374 = ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_14, V.Undef, Get(p_370, "x"))).S(" ").V(Call(r2_14, V.Undef, Get(p_370, "y"))).S(")").End()));
if (SEqS(Get(p_370, "kind"), "dot")) {
h_363.S("<circle cx=\"").V(Call(r2_14, V.Undef, Get(p_370, "x"))).S("\" cy=\"").V(Call(r2_14, V.Undef, Get(p_370, "y"))).S("\" r=\"").V(Call(r2_14, V.Undef, Get(p_370, "r"))).S("\" fill=\"").V(Get(p_370, "col")).S("\" opacity=\"").V(op_373).S("\"/>");
} else {
if (SEqS(Get(p_370, "kind"), "drop")) {
h_363.S("<path transform=\"").V(tr_374).S(" rotate(").V(Call(r2_14, V.Undef, ((V)((FdLibm.Atan2((-ToNum(Get(p_370, "vx"))), ToNum(Get(p_370, "vy"))) / D2R_11))))).S(") scale(").V(Call(r2_14, V.Undef, Get(p_370, "r"))).S(")\" d=\"M0 -2 Q1.4 0.4 0 1.3 Q-1.4 0.4 0 -2Z\" fill=\"").V(Get(p_370, "col")).S("\" stroke=\"#ffffff\" stroke-width=\"0.3\" opacity=\"").V(op_373).S("\"/>");
} else {
if (SEqS(Get(p_370, "kind"), "bubble")) {
V pop_375 = default;
double rr_376 = 0;
pop_375 = Call(SM_16, V.Undef, ((V)(((u_372 - 0.88) / 0.12))));
rr_376 = (ToNum(Get(p_370, "r")) * (1D + (ToNum(pop_375) * 0.4)));
h_363.S("<g opacity=\"").V(Call(r2_14, V.Undef, ((V)((ToNum(op_373) * (1D - ToNum(pop_375))))))).S("\"><circle cx=\"").V(Call(r2_14, V.Undef, Add(Get(p_370, "x"), ((V)((FdLibm.Sin(ToNum(Add(((V)((ToNum(Get(p_370, "age")) / 300D))), Get(p_370, "ph")))) * 1.2)))))).S("\" cy=\"").V(Call(r2_14, V.Undef, Get(p_370, "y"))).S("\" r=\"").V(Call(r2_14, V.Undef, ((V)(rr_376)))).S("\" fill=\"rgba(215,240,255,0.35)\" stroke=\"#ffffff\" stroke-width=\"0.45\"/><circle cx=\"").V(Call(r2_14, V.Undef, ((V)((ToNum(Get(p_370, "x")) - (rr_376 * 0.35)))))).S("\" cy=\"").V(Call(r2_14, V.Undef, ((V)((ToNum(Get(p_370, "y")) - (rr_376 * 0.35)))))).S("\" r=\"").V(Call(r2_14, V.Undef, ((V)((rr_376 * 0.22))))).S("\" fill=\"#ffffff\"/></g>");
} else {
if (SEqS(Get(p_370, "kind"), "star")) {
h_363.S("<path d=\"").V(Call(star4_33, V.Undef, Get(p_370, "x"), Get(p_370, "y"), ((V)((ToNum(Get(p_370, "r")) * (0.6 + (0.6 * FdLibm.Sin((System.Math.PI * u_372))))))))).S("\" fill=\"").V(Get(p_370, "col")).S("\" opacity=\"").V(op_373).S("\"/>");
} else {
if (SEqS(Get(p_370, "kind"), "heart")) {
h_363.S("<path transform=\"").V(tr_374).S(" scale(").V(Call(r2_14, V.Undef, ((V)((ToNum(Get(p_370, "r")) * (0.8 + (u_372 * 0.5))))))).S(")\" d=\"M0 2.6 C-4.6 -0.6 -3.4 -5.6 0 -3 C3.4 -5.6 4.6 -0.6 0 2.6Z\" fill=\"#ff5c9e\" stroke=\"#ffffff\" stroke-width=\"0.5\" opacity=\"").V(op_373).S("\"/>");
} else {
if (SEqS(Get(p_370, "kind"), "wave")) {
double w_377 = 0;
w_377 = (FdLibm.Sin(ToNum(Add(((V)((ToNum(Get(p_370, "age")) / 260D))), Get(p_370, "ph")))) * 1.2);
h_363.S("<path transform=\"").V(tr_374).S(" scale(").V(Call(r2_14, V.Undef, Get(p_370, "r"))).S(")\" d=\"M0 0 q").V(Call(r2_14, V.Undef, ((V)(((-1.6) + w_377))))).S(" -2 0 -4 q").V(Call(r2_14, V.Undef, ((V)((1.6 + w_377))))).S(" -2 0 -4\" stroke=\"").V(Get(p_370, "col")).S("\" stroke-width=\"1.1\" fill=\"none\" stroke-linecap=\"round\" opacity=\"").V(Call(r2_14, V.Undef, ((V)((ToNum(op_373) * 0.9))))).S("\"/>");
} else {
if (SEqS(Get(p_370, "kind"), "wisp")) {
double s_378 = 0;
double dr_379 = 0;
s_378 = (ToNum(Get(p_370, "r")) * (0.8 + (u_372 * 0.6)));
dr_379 = (LtN(Get(p_370, "vx"), 0D) ? (-1D) : 1D);
h_363.S("<path transform=\"").V(tr_374).S(" scale(").V(Call(r2_14, V.Undef, ((V)((dr_379 * s_378))))).S(" ").V(Call(r2_14, V.Undef, ((V)(s_378)))).S(")\" d=\"M-5 0 Q-2 -1.6 1 0 T5 -0.6 Q7 -1.6 6 -3 Q4.6 -3.6 4.6 -2.2\" stroke=\"").V(Get(p_370, "col")).S("\" stroke-width=\"").V(Call(r2_14, V.Undef, ((V)((0.9 / s_378))))).S("\" fill=\"none\" stroke-linecap=\"round\" opacity=\"").V(Call(r2_14, V.Undef, ((V)((ToNum(op_373) * 0.9))))).S("\"/>");
} else {
if (SEqS(Get(p_370, "kind"), "leaf")) {
double sw_380 = 0;
sw_380 = FdLibm.Sin(ToNum(Add(((V)((ToNum(Get(p_370, "age")) / 260D))), Get(p_370, "ph"))));
h_363.S("<path transform=\"translate(").V(Call(r2_14, V.Undef, Add(Get(p_370, "x"), ((V)((sw_380 * 2.2)))))).S(" ").V(Call(r2_14, V.Undef, Get(p_370, "y"))).S(") rotate(").V(Call(r2_14, V.Undef, ((V)(((ToNum(Get(p_370, "ph")) * 57D) + (sw_380 * 55D)))))).S(") scale(").V(Call(r2_14, V.Undef, Get(p_370, "r"))).S(")\" d=\"M0 -2.6 Q1.8 -0.8 0.3 2.3 L0 2.9 L-0.3 2.3 Q-1.8 -0.8 0 -2.6Z\" fill=\"").V(Get(p_370, "col")).S("\" stroke=\"#ffffff\" stroke-width=\"0.25\" opacity=\"").V(op_373).S("\"/>");
} else {
if (SEqS(Get(p_370, "kind"), "duck")) {
double sq_381 = 0;
double wd_382 = 0;
double dr_383 = 0;
double s_384 = 0;
sq_381 = ((!Get(p_370, "land").IsNullish && ((ToNum(Get(p_370, "age")) - ToNum(Get(p_370, "land"))) < 140D)) ? (1D - ToNum(Call(SM_16, V.Undef, ((V)(((ToNum(Get(p_370, "age")) - ToNum(Get(p_370, "land"))) / 140D)))))) : 0D);
wd_382 = (FdLibm.Sin(ToNum(Add(((V)((ToNum(Get(p_370, "age")) / 110D))), Get(p_370, "ph")))) * 14D);
dr_383 = (LtN(Get(p_370, "vx"), 0D) ? (-1D) : 1D);
s_384 = (ToNum(Get(p_370, "r")) * 1.5);
h_363.S("<g transform=\"").V(tr_374).S(" scale(").V(Call(r2_14, V.Undef, ((V)(((dr_383 * s_384) * (1D + (sq_381 * 0.18))))))).S(" ").V(Call(r2_14, V.Undef, ((V)((s_384 * (1D - (sq_381 * 0.22))))))).S(") rotate(").V(Call(r2_14, V.Undef, ((V)(wd_382)))).S(")\" opacity=\"").V(op_373).S("\"><ellipse cx=\"0.2\" cy=\"-2\" rx=\"3.5\" ry=\"2.3\" fill=\"#e9a512\"/><ellipse cx=\"-0.2\" cy=\"-2.4\" rx=\"3.1\" ry=\"1.9\" fill=\"#ffd43b\"/><path d=\"M-3 -2.6 L-4.5 -4.2 L-2.4 -3.5Z\" fill=\"#ffd43b\"/><path d=\"M-1.6 -2.6 Q0 -1.2 1.4 -2.6\" stroke=\"#e9a512\" stroke-width=\"0.5\" fill=\"none\" stroke-linecap=\"round\"/><circle cx=\"1.95\" cy=\"-4.85\" r=\"1.85\" fill=\"#e9a512\"/><circle cx=\"1.8\" cy=\"-5\" r=\"1.75\" fill=\"#ffd43b\"/><ellipse cx=\"3.7\" cy=\"-4.6\" rx=\"1.05\" ry=\"0.5\" fill=\"#ff8a2a\"/><circle cx=\"2.4\" cy=\"-5.4\" r=\"0.36\" fill=\"#2a1a30\"/><ellipse cx=\"1.1\" cy=\"-5.8\" rx=\"0.6\" ry=\"0.35\" fill=\"#fff8d0\"/><ellipse cx=\"-1.2\" cy=\"-3.3\" rx=\"1\" ry=\"0.4\" fill=\"#fff8d0\" opacity=\"0.8\"/></g>");
} else {
if (SEqS(Get(p_370, "kind"), "haze")) {
h_363.S("<circle cx=\"").V(Call(r2_14, V.Undef, Get(p_370, "x"))).S("\" cy=\"").V(Call(r2_14, V.Undef, Get(p_370, "y"))).S("\" r=\"").V(Call(r2_14, V.Undef, ((V)((ToNum(Get(p_370, "r")) * (0.8 + (u_372 * 1.1))))))).S("\" fill=\"url(#phz").V(Get(I_361, "u")).S(")\" opacity=\"").V(op_373).S("\"/>");
} else {
if (SEqS(Get(p_370, "kind"), "puff")) {
h_363.S("<circle cx=\"").V(Call(r2_14, V.Undef, Get(p_370, "x"))).S("\" cy=\"").V(Call(r2_14, V.Undef, Get(p_370, "y"))).S("\" r=\"").V(Call(r2_14, V.Undef, ((V)((ToNum(Get(p_370, "r")) * (0.7 + (u_372 * 0.8))))))).S("\" fill=\"").V(Get(p_370, "col")).S("\" opacity=\"").V(Call(r2_14, V.Undef, ((V)((ToNum(op_373) * 0.85))))).S("\"/>");
} else {
if (SEqS(Get(p_370, "kind"), "seed")) {
h_363.S("<ellipse cx=\"").V(Call(r2_14, V.Undef, Get(p_370, "x"))).S("\" cy=\"").V(Call(r2_14, V.Undef, Get(p_370, "y"))).S("\" rx=\"").V(Call(r2_14, V.Undef, ((V)((ToNum(Get(p_370, "r")) * 0.7))))).S("\" ry=\"").V(Call(r2_14, V.Undef, Get(p_370, "r"))).S("\" fill=\"").V(Get(p_370, "col")).S("\" opacity=\"").V(op_373).S("\"/>");
} else {
if (SEqS(Get(p_370, "kind"), "note")) {
h_363.S("<g transform=\"").V(tr_374).S(" rotate(").V(Call(r2_14, V.Undef, ((V)((FdLibm.Sin((ToNum(Get(p_370, "age")) / 200D)) * 12D))))).S(")\" opacity=\"").V(op_373).S("\"><ellipse cx=\"0\" cy=\"0\" rx=\"1.5\" ry=\"1.1\" fill=\"").V(Get(p_370, "col")).S("\" transform=\"rotate(-20)\"/><path d=\"M1.3 -0.3 L1.3 -5 Q3 -4.2 3.3 -2.6\" stroke=\"").V(Get(p_370, "col")).S("\" stroke-width=\"0.8\" fill=\"none\" stroke-linecap=\"round\"/></g>");
}
}
}
}
}
}
}
}
}
}
}
}
}
return (true ? V.True : V.False);
return default;
}, 1, "", true)));
return ((V)(h_363.Str));
return default;
}, 2, "drawParts", false);
wPrep_53 = Fn((V _self385, int _argc386, V I_392, V _a389, V _a390, V _a391, V[] _rest387) => {
V fx_393 = default;
V par_394 = default;
V NS_395 = default;
V mkE_396 = default;
V df_397 = default;
V cp_398 = default;
V rc_399 = default;
V b_400 = default;
V g_401 = default;
if (_self385.IsNullish) _self385 = GlobalV;
fx_393 = Get(I_392, "fxG");
par_394 = (fx_393 is var _t402 && !Truthy(_t402) ? _t402 : Get(fx_393, "parentNode"));
if (!(Truthy(par_394))) {
return V.Null;
}
NS_395 = ((V)("http://www.w3.org/2000/svg"));
mkE_396 = Fn((V _arrowThis410, int _argc403, V n_409, V _a406, V _a407, V _a408, V[] _rest404) => {
return Invoke(G("document"), "createElementNS", NS_395, n_409);
}, 1, "", true);
df_397 = Call(mkE_396, V.Undef, ((V)("defs")));
cp_398 = Call(mkE_396, V.Undef, ((V)("clipPath")));
rc_399 = Call(mkE_396, V.Undef, ((V)("rect")));
Invoke(cp_398, "setAttribute", ((V)("id")), ((V)(JsStrBuf.Begin().S("wcl").V(Get(I_392, "u")).End())));
Invoke(cp_398, "setAttribute", ((V)("clipPathUnits")), ((V)("userSpaceOnUse")));
Invoke(rc_399, "setAttribute", ((V)("x")), ((V)((-300D))));
Invoke(rc_399, "setAttribute", ((V)("y")), ((V)((-400D))));
Invoke(rc_399, "setAttribute", ((V)("width")), ((V)(700D)));
Invoke(rc_399, "setAttribute", ((V)("height")), ((V)(500D)));
Invoke(cp_398, "appendChild", rc_399);
Invoke(df_397, "appendChild", cp_398);
Invoke(par_394, "insertBefore", df_397, Get(par_394, "firstChild"));
b_400 = Call(mkE_396, V.Undef, ((V)("g")));
g_401 = Call(mkE_396, V.Undef, ((V)("g")));
Invoke(new ArrBuilder().Spread(Get(par_394, "childNodes")).V, "forEach", Fn((V _arrowThis418, int _argc411, V n_417, V _a414, V _a415, V _a416, V[] _rest412) => {
if (((SEq(n_417, fx_393) || SEq(n_417, df_397)) || SEqS(Get(n_417, "nodeName"), "defs"))) {
return default;
}
Invoke(g_401, "appendChild", n_417);
return default;
}, 1, "", true));
Invoke(par_394, "insertBefore", g_401, fx_393);
Invoke(par_394, "insertBefore", b_400, g_401);
return NewObj(7).Put("g", g_401).Put("b", b_400).Put("rc", rc_399).Put("on", (false ? V.True : V.False)).Put("m0", V.Null).Put("cx", V.Null).Put("hw", V.Null).V;
return default;
}, 1, "wPrep", false);
dustBath_56 = Fn((V _self419, int _argc420, V I_426, V P_427, V now_428, V _a425, V[] _rest421) => {
V s_429 = default;
double hz_430 = 0;
V u_431 = default;
double cx_432 = 0;
double rx_433 = 0;
double ry_434 = 0;
double rim_435 = 0;
double wh_436 = 0;
double brx_437 = 0;
double bry_438 = 0;
double by_439 = 0;
V al_440 = default;
double T_441 = 0;
V arc_442 = default;
V lvl_443 = default;
V blob_444 = default;
double sy_445 = 0;
double srx_446 = 0;
double sry_447 = 0;
JsStrBuf sp_448 = null;
JsStrBuf gr_449 = null;
JsStrBuf hzB_450 = null;
JsStrBuf hzF_451 = null;
JsStrBuf st_452 = null;
V hy_453 = default;
V ha_454 = default;
V hb_455 = default;
V hy2_456 = default;
V ha2_457 = default;
V hb2_458 = default;
JsStrBuf heap_459 = null;
double dk_460 = 0;
if (_self419.IsNullish) _self419 = GlobalV;
s_429 = Call(clamp_13, V.Undef, (Get(P_427, "dbb") is var _t461 && Truthy(_t461) ? _t461 : ((V)(0D))), ((V)(0D)), ((V)(1.3)));
hz_430 = (ToNum(Call(clamp_13, V.Undef, (Get(P_427, "dbh") is var _t462 && Truthy(_t462) ? _t462 : ((V)(0D))), ((V)(0D)), ((V)(1D)))) * ToNum(Call(clamp_13, V.Undef, s_429, ((V)(0D)), ((V)(1D)))));
if (LtN(s_429, 0.02)) {
if (Truthy((Get(I_426, "dbG") is var _t463 && !Truthy(_t463) ? _t463 : Get(I_426, "dbOn")))) {
Set(Get(I_426, "dbG"), "innerHTML", ((V)("")));
Set(I_426, "dbOn", (false ? V.True : V.False));
Invoke(Get(I_426, "root"), "removeAttribute", ((V)("clip-path")));
}
return ((V)(""));
}
if (!(Truthy(Get(I_426, "dbG")))) {
Set(I_426, "dbG", Invoke(G("document"), "createElementNS", ((V)("http://www.w3.org/2000/svg")), ((V)("g"))));
Invoke(Get(Get(I_426, "root"), "parentNode"), "insertBefore", Get(I_426, "dbG"), Get(I_426, "root"));
}
u_431 = Get(I_426, "u");
cx_432 = 50D;
rx_433 = (46D * ToNum(s_429));
ry_434 = (11.5 * ToNum(s_429));
rim_435 = (79D + (9D * (1D - Min(1D, ToNum(s_429)))));
wh_436 = (11D * ToNum(s_429));
brx_437 = (rx_433 * 0.94);
bry_438 = (ry_434 * 0.94);
by_439 = (rim_435 + wh_436);
al_440 = Call(r2_14, V.Undef, Call(clamp_13, V.Undef, ((V)((ToNum(s_429) * 3D))), ((V)(0D)), ((V)(1D))));
T_441 = (ToNum((now_428 is var _t464 && Truthy(_t464) ? _t464 : ((V)(0D)))) / 1000D);
arc_442 = Fn((V _arrowThis475, int _argc465, V y_471, V a_472, V b_473, V up_474, V[] _rest466) => {
return ((V)(JsStrBuf.Begin().S("M").V(Call(r2_14, V.Undef, ((V)((cx_432 - ToNum(a_472)))))).S(" ").V(Call(r2_14, V.Undef, y_471)).S("A").V(Call(r2_14, V.Undef, a_472)).S(" ").V(Call(r2_14, V.Undef, b_473)).S(" 0 0 ").N((Truthy(up_474) ? 1D : 0D)).S(" ").V(Call(r2_14, V.Undef, Add(((V)(cx_432)), a_472))).S(" ").V(Call(r2_14, V.Undef, y_471)).End()));
}, 4, "", true);
lvl_443 = Fn((V _arrowThis483, int _argc476, V f_482, V _a479, V _a480, V _a481, V[] _rest477) => {
return Arr(((V)((rim_435 + (wh_436 * ToNum(f_482))))), ((V)((rx_433 + ((brx_437 - rx_433) * ToNum(f_482))))), ((V)((ry_434 + ((bry_438 - ry_434) * ToNum(f_482))))));
}, 1, "", true);
blob_444 = Fn((V _arrowThis494, int _argc484, V x_490, V y_491, V r_492, V o_493, V[] _rest485) => {
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(r2_14, V.Undef, x_490)).S("\" cy=\"").V(Call(r2_14, V.Undef, y_491)).S("\" r=\"").V(Call(r2_14, V.Undef, r_492)).S("\" fill=\"url(#dbh").V(u_431).S(")\" opacity=\"").V(Call(r2_14, V.Undef, o_493)).S("\"/>").End()));
}, 4, "", true);
sy_445 = (rim_435 + (3D * ToNum(s_429)));
srx_446 = (rx_433 - (2.6 * ToNum(s_429)));
sry_447 = (ry_434 - (0.6 * ToNum(s_429)));
sp_448 = new JsStrBuf("");
{
double i_495 = 0;
i_495 = 0D;
while (true) {
if (!((i_495 < 26D))) break;
double a_497 = 0;
double rr_498 = 0;
a_497 = (i_495 * 2.4);
rr_498 = (((0.15 + (((i_495 * 7D) % 10D) / 11.5)) * srx_446) * 0.92);
sp_448.S("<circle cx=\"").V(Call(r2_14, V.Undef, ((V)((cx_432 + (FdLibm.Cos(a_497) * rr_498)))))).S("\" cy=\"").V(Call(r2_14, V.Undef, ((V)((sy_445 + ((((FdLibm.Sin(a_497) * rr_498) * sry_447) / srx_446) * 0.85)))))).S("\" r=\"").V(Call(r2_14, V.Undef, ((V)(((0.3 + ((i_495 % 3D) * 0.12)) * ToNum(s_429)))))).S("\" fill=\"").S((NumTruthy((i_495 % 2D)) ? "#bdb2a2" : "#fbf8f3")).S("\" opacity=\"0.6\"/>");
i_495++;
}
}
gr_449 = new JsStrBuf("");
Invoke(Arr(Arr(((V)((-24D))), ((V)((-2.5))), ((V)(9D)), ((V)(0.9))), Arr(((V)((-6D))), ((V)(1.2)), ((V)(12D)), ((V)(1.1))), Arr(((V)(17D)), ((V)((-1.4))), ((V)(10D)), ((V)(0.8))), Arr(((V)(29D)), ((V)(2.6)), ((V)(7D)), ((V)(0.7))), Arr(((V)((-31D))), ((V)(3.2)), ((V)(6D)), ((V)(0.6)))), "forEach", Fn((V _arrowThis514, int _argc499, V _a501, V _a502, V _a503, V _a504, V[] _rest500) => {
double x_515 = 0;
double y_516 = 0;
double ww_517 = 0;
V dx_507 = default;
V dy_509 = default;
V w_511 = default;
V b_513 = default;
{ V _t505 = ListOf(_a501);
{ V _t506 = GetIdx(_t505, 0D);
dx_507 = _t506; }
{ V _t508 = GetIdx(_t505, 1D);
dy_509 = _t508; }
{ V _t510 = GetIdx(_t505, 2D);
w_511 = _t510; }
{ V _t512 = GetIdx(_t505, 3D);
b_513 = _t512; }
}
x_515 = (cx_432 + (ToNum(dx_507) * ToNum(s_429)));
y_516 = (sy_445 + (ToNum(dy_509) * ToNum(s_429)));
ww_517 = (ToNum(w_511) * ToNum(s_429));
gr_449.S("<path d=\"M").V(Call(r2_14, V.Undef, ((V)((x_515 - ww_517))))).S(" ").V(Call(r2_14, V.Undef, ((V)(y_516)))).S("Q").V(Call(r2_14, V.Undef, ((V)(x_515)))).S(" ").V(Call(r2_14, V.Undef, ((V)((y_516 + ((ToNum(b_513) * 1.6) * ToNum(s_429))))))).S(" ").V(Call(r2_14, V.Undef, ((V)((x_515 + ww_517))))).S(" ").V(Call(r2_14, V.Undef, ((V)(y_516)))).S("\" stroke=\"#c3b8a8\" stroke-width=\"").V(Call(r2_14, V.Undef, ((V)((0.7 * ToNum(s_429)))))).S("\" fill=\"none\" stroke-linecap=\"round\" opacity=\"0.55\"/><path d=\"M").V(Call(r2_14, V.Undef, ((V)((x_515 - (ww_517 * 0.9)))))).S(" ").V(Call(r2_14, V.Undef, ((V)((y_516 - (0.6 * ToNum(s_429))))))).S("Q").V(Call(r2_14, V.Undef, ((V)(x_515)))).S(" ").V(Call(r2_14, V.Undef, ((V)(((y_516 + ((ToNum(b_513) * 1.6) * ToNum(s_429))) - (0.6 * ToNum(s_429))))))).S(" ").V(Call(r2_14, V.Undef, ((V)((x_515 + (ww_517 * 0.9)))))).S(" ").V(Call(r2_14, V.Undef, ((V)((y_516 - (0.6 * ToNum(s_429))))))).S("\" stroke=\"#fdfbf8\" stroke-width=\"").V(Call(r2_14, V.Undef, ((V)((0.5 * ToNum(s_429)))))).S("\" fill=\"none\" stroke-linecap=\"round\" opacity=\"0.7\"/>");
return default;
}, 1, "", true));
hzB_450 = new JsStrBuf("");
hzF_451 = new JsStrBuf("");
if ((hz_430 > 0.01)) {
{
double i_518 = 0;
i_518 = 0D;
while (true) {
if (!((i_518 < 6D))) break;
double x_520 = 0;
double y_521 = 0;
double r_522 = 0;
x_520 = ((cx_432 + (((-34D) + (i_518 * 13.6)) * ToNum(s_429))) + (FdLibm.Sin(((T_441 * 0.8) + (i_518 * 1.7))) * 3.5));
y_521 = (((rim_435 - 7D) - ((i_518 % 2D) * 6D)) + (FdLibm.Sin(((T_441 * 1.1) + (i_518 * 2.3))) * 2.2));
r_522 = ((12D + (((i_518 * 5D) % 3D) * 3.5)) * (0.9 + (0.1 * FdLibm.Sin(((T_441 * 1.6) + i_518)))));
hzB_450.V(Call(blob_444, V.Undef, ((V)(x_520)), ((V)(y_521)), ((V)(r_522)), ((V)((hz_430 * 0.85)))));
if (((i_518 % 2D) == 0D)) {
hzF_451.V(Call(blob_444, V.Undef, ((V)((x_520 + 3D))), ((V)((y_521 + 6D))), ((V)((r_522 * 0.85))), ((V)((hz_430 * 0.18)))));
}
i_518++;
}
}
}
if ((hz_430 > 0.01)) {
{
double i_523 = 0;
i_523 = 0D;
while (true) {
if (!((i_523 < 4D))) break;
hzF_451.V(Call(blob_444, V.Undef, ((V)(((cx_432 + (((-30D) + (i_523 * 20D)) * ToNum(s_429))) + (FdLibm.Sin(((T_441 * 1.3) + (i_523 * 2.1))) * 3D)))), ((V)(((rim_435 + 2D) + (FdLibm.Sin(((T_441 * 1.7) + i_523)) * 1.5)))), ((V)((8D + ((i_523 % 2D) * 3D)))), ((V)((hz_430 * 0.2)))));
i_523++;
}
}
}
Set(Get(I_426, "dbG"), "innerHTML", ((V)(JsStrBuf.Begin().S("<defs><linearGradient id=\"dbw").V(u_431).S("\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#a5763e\"/><stop offset=\"0.16\" stop-color=\"#d6a967\"/><stop offset=\"0.4\" stop-color=\"#f0cf98\"/><stop offset=\"0.62\" stop-color=\"#e5bc7e\"/><stop offset=\"0.86\" stop-color=\"#c49352\"/><stop offset=\"1\" stop-color=\"#9a6c37\"/></linearGradient>").S("<linearGradient id=\"dbi").V(u_431).S("\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#e4bd84\"/><stop offset=\"1\" stop-color=\"#b08048\"/></linearGradient>").S("<radialGradient id=\"dbs").V(u_431).S("\" cx=\"42%\" cy=\"35%\" r=\"72%\"><stop offset=\"0\" stop-color=\"#f6f3ee\"/><stop offset=\"0.7\" stop-color=\"#e3dbcf\"/><stop offset=\"1\" stop-color=\"#cdc2b2\"/></radialGradient>").S("<radialGradient id=\"dbh").V(u_431).S("\"><stop offset=\"0\" stop-color=\"#c9c8c6\" stop-opacity=\"0.9\"/><stop offset=\"0.55\" stop-color=\"#d2d1cf\" stop-opacity=\"0.5\"/><stop offset=\"1\" stop-color=\"#d8d7d5\" stop-opacity=\"0\"/></radialGradient>").S("<clipPath id=\"dbk").V(u_431).S("\" clipPathUnits=\"userSpaceOnUse\"><path d=\"M-200 -300L300 -300L300 300L").V(Call(r2_14, V.Undef, ((V)((cx_432 + brx_437))))).S(" 300L").V(Call(r2_14, V.Undef, ((V)((cx_432 + brx_437))))).S(" ").V(Call(r2_14, V.Undef, ((V)(by_439)))).S("A").V(Call(r2_14, V.Undef, ((V)(brx_437)))).S(" ").V(Call(r2_14, V.Undef, ((V)(bry_438)))).S(" 0 0 1 ").V(Call(r2_14, V.Undef, ((V)((cx_432 - brx_437))))).S(" ").V(Call(r2_14, V.Undef, ((V)(by_439)))).S("L").V(Call(r2_14, V.Undef, ((V)((cx_432 - brx_437))))).S(" 300L-200 300Z\"/></clipPath>").S("<clipPath id=\"dbc").V(u_431).S("\"><ellipse cx=\"").N(cx_432).S("\" cy=\"").V(Call(r2_14, V.Undef, ((V)(rim_435)))).S("\" rx=\"").V(Call(r2_14, V.Undef, ((V)((rx_433 - 0.4))))).S("\" ry=\"").V(Call(r2_14, V.Undef, ((V)((ry_434 - 0.3))))).S("\"/></clipPath></defs>").S("<g opacity=\"").V(al_440).S("\"><ellipse cx=\"").N(cx_432).S("\" cy=\"").V(Call(r2_14, V.Undef, ((V)((by_439 + 0.8))))).S("\" rx=\"").V(Call(r2_14, V.Undef, ((V)((brx_437 * 1.04))))).S("\" ry=\"").V(Call(r2_14, V.Undef, ((V)((bry_438 * 0.95))))).S("\" fill=\"#6d4f9a\" opacity=\"0.17\"/>").S("<ellipse cx=\"").N(cx_432).S("\" cy=\"").V(Call(r2_14, V.Undef, ((V)(rim_435)))).S("\" rx=\"").V(Call(r2_14, V.Undef, ((V)(rx_433)))).S("\" ry=\"").V(Call(r2_14, V.Undef, ((V)(ry_434)))).S("\" fill=\"url(#dbi").V(u_431).S(")\"/>").S("<g clip-path=\"url(#dbc").V(u_431).S(")\"><ellipse cx=\"").N(cx_432).S("\" cy=\"").V(Call(r2_14, V.Undef, ((V)((sy_445 + (0.5 * ToNum(s_429))))))).S("\" rx=\"").V(Call(r2_14, V.Undef, ((V)((srx_446 + 0.8))))).S("\" ry=\"").V(Call(r2_14, V.Undef, ((V)((sry_447 + 0.6))))).S("\" fill=\"#8d6232\" opacity=\"0.35\"/>").S("<ellipse cx=\"").N(cx_432).S("\" cy=\"").V(Call(r2_14, V.Undef, ((V)(sy_445)))).S("\" rx=\"").V(Call(r2_14, V.Undef, ((V)(srx_446)))).S("\" ry=\"").V(Call(r2_14, V.Undef, ((V)(sry_447)))).S("\" fill=\"url(#dbs").V(u_431).S(")\"/>").S(gr_449.Str).S(sp_448.Str).S("</g>").S("<path d=\"").V(Call(arc_442, V.Undef, ((V)(rim_435)), ((V)(rx_433)), ((V)(ry_434)), ((V)(1D)))).S("\" fill=\"none\" stroke=\"#f6dfb4\" stroke-width=\"").V(Call(r2_14, V.Undef, ((V)((1.9 * ToNum(s_429)))))).S("\" stroke-linecap=\"round\"/>").S("<path d=\"").V(Call(arc_442, V.Undef, ((V)((rim_435 + (0.35 * ToNum(s_429))))), ((V)((rx_433 - (1.1 * ToNum(s_429))))), ((V)((ry_434 - (0.7 * ToNum(s_429))))), ((V)(1D)))).S("\" fill=\"none\" stroke=\"#a87a42\" stroke-width=\"").V(Call(r2_14, V.Undef, ((V)((0.45 * ToNum(s_429)))))).S("\" opacity=\"0.55\"/>").S(hzB_450.Str).S("</g>").End())));
if (!(Truthy(Get(I_426, "dbOn")))) {
Invoke(Get(I_426, "root"), "setAttribute", ((V)("clip-path")), ((V)(JsStrBuf.Begin().S("url(#dbk").V(u_431).S(")").End())));
}
Set(I_426, "dbOn", (true ? V.True : V.False));
st_452 = new JsStrBuf("");
{
double a_525 = 0;
a_525 = (-72D);
while (true) {
if (!((a_525 <= 72D))) break;
double q_527 = 0;
double x0_528 = 0;
double y0_529 = 0;
double x1_530 = 0;
double y1_531 = 0;
q_527 = (a_525 * D2R_11);
x0_528 = (cx_432 + (rx_433 * FdLibm.Sin(q_527)));
y0_529 = (rim_435 + (ry_434 * FdLibm.Cos(q_527)));
x1_530 = (cx_432 + (brx_437 * FdLibm.Sin(q_527)));
y1_531 = (by_439 + (bry_438 * FdLibm.Cos(q_527)));
st_452.S("<path d=\"M").V(Call(r2_14, V.Undef, ((V)(x0_528)))).S(" ").V(Call(r2_14, V.Undef, ((V)((y0_529 + 1D))))).S("L").V(Call(r2_14, V.Undef, ((V)(x1_530)))).S(" ").V(Call(r2_14, V.Undef, ((V)(y1_531)))).S("\" stroke=\"#9c6d38\" stroke-width=\"").V(Call(r2_14, V.Undef, ((V)((0.35 * ToNum(s_429)))))).S("\" opacity=\"0.38\"/>");
a_525 = (a_525 + 12D);
}
}
{ V _t532 = Call(lvl_443, V.Undef, ((V)(0.66)));
{ V _t533 = ListOf(_t532);
{ V _t534 = GetIdx(_t533, 0D);
hy_453 = _t534; }
{ V _t535 = GetIdx(_t533, 1D);
ha_454 = _t535; }
{ V _t536 = GetIdx(_t533, 2D);
hb_455 = _t536; }
} }
{ V _t537 = Call(lvl_443, V.Undef, ((V)((0.66 + (1.5 / Max(1D, wh_436))))));
{ V _t538 = ListOf(_t537);
{ V _t539 = GetIdx(_t538, 0D);
hy2_456 = _t539; }
{ V _t540 = GetIdx(_t538, 1D);
ha2_457 = _t540; }
{ V _t541 = GetIdx(_t538, 2D);
hb2_458 = _t541; }
} }
heap_459 = new JsStrBuf("");
dk_460 = (ToNum(Call(clamp_13, V.Undef, (Get(P_427, "dbs") is var _t542 && Truthy(_t542) ? _t542 : ((V)(0D))), ((V)(0D)), ((V)(1D)))) * Min(1D, ToNum(s_429)));
if ((dk_460 > 0.01)) {
double N_543 = 0;
double x0_544 = 0;
double x1_545 = 0;
V rf_546 = default;
double mv_547 = 0;
JsStrBuf top_548 = null;
V pts_549 = default;
JsStrBuf gn_550 = null;
N_543 = 22D;
x0_544 = (cx_432 - (41D * ToNum(s_429)));
x1_545 = (cx_432 + (41D * ToNum(s_429)));
rf_546 = Fn((V _arrowThis558, int _argc551, V x_557, V _a554, V _a555, V _a556, V[] _rest552) => {
return ((V)((rim_435 + (ry_434 * System.Math.Sqrt(Max(0D, (1D - (((ToNum(x_557) - cx_432) / rx_433) * ((ToNum(x_557) - cx_432) / rx_433)))))))));
}, 1, "", true);
mv_547 = hz_430;
top_548 = new JsStrBuf("");
pts_549 = Arr();
{
double i_559 = 0;
i_559 = 0D;
while (true) {
if (!((i_559 <= N_543))) break;
double q_561 = 0;
double x_562 = 0;
double e_563 = 0;
double lump_564 = 0;
q_561 = (i_559 / N_543);
x_562 = (x0_544 + ((x1_545 - x0_544) * q_561));
e_563 = Pow(FdLibm.Sin((System.Math.PI * q_561)), 0.55);
lump_564 = ((1D + (0.22 * FdLibm.Sin((((q_561 * 19D) + 1.3) + ((T_441 * 5D) * mv_547))))) + (0.12 * FdLibm.Sin(((q_561 * 41D) + ((T_441 * 8D) * mv_547)))));
Invoke(pts_549, "push", Arr(((V)(x_562)), ((V)((ToNum(Call(rf_546, V.Undef, ((V)(x_562)))) - ((((dk_460 * 5.5) * ToNum(s_429)) * e_563) * lump_564))))));
i_559++;
}
}
Invoke(pts_549, "forEach", Fn((V _arrowThis573, int _argc565, V p_571, V i_572, V _a569, V _a570, V[] _rest566) => {
top_548.S((Truthy(i_572) ? "L" : "M")).V(Call(r2_14, V.Undef, GetIdx(p_571, 0D))).S(" ").V(Call(r2_14, V.Undef, GetIdx(p_571, 1D)));
return default;
}, 2, "", true));
gn_550 = new JsStrBuf("");
{
double i_574 = 0;
i_574 = 2D;
while (true) {
if (!((i_574 < (N_543 - 1D)))) break;
V p_576 = default;
p_576 = GetIdx(pts_549, i_574);
gn_550.S("<circle cx=\"").V(Call(r2_14, V.Undef, Add(GetIdx(p_576, 0D), ((V)((FdLibm.Sin((i_574 * 3.7)) * 1.2)))))).S("\" cy=\"").V(Call(r2_14, V.Undef, Add(Add(GetIdx(p_576, 1D), ((V)(1.4))), ((V)(((i_574 % 3D) * 0.7)))))).S("\" r=\"").V(Call(r2_14, V.Undef, ((V)((0.32 * ToNum(s_429)))))).S("\" fill=\"").S((NumTruthy((i_574 % 4D)) ? "#b9b0a3" : "#fbf9f5")).S("\" opacity=\"0.7\"/>");
i_574 = (i_574 + 2D);
}
}
heap_459.Set(JsStrBuf.Begin().S("<g opacity=\"").V(Call(r2_14, V.Undef, ((V)((ToNum(al_440) * Min(1D, (dk_460 * 2.5))))))).S("\"><path d=\"").S(top_548.Str).S("L").V(Call(r2_14, V.Undef, ((V)(x1_545)))).S(" ").V(Call(r2_14, V.Undef, ((V)((by_439 + 4D))))).S("L").V(Call(r2_14, V.Undef, ((V)(x0_544)))).S(" ").V(Call(r2_14, V.Undef, ((V)((by_439 + 4D))))).S("Z\" fill=\"url(#dbs").V(u_431).S(")\"/>").S("<path d=\"").S(top_548.Str).S("\" fill=\"none\" stroke=\"#a99f91\" stroke-width=\"").V(Call(r2_14, V.Undef, ((V)((1.2 * ToNum(s_429)))))).S("\" stroke-linejoin=\"round\" opacity=\"0.35\" transform=\"translate(0 -0.5)\"/>").S("<path d=\"").S(top_548.Str).S("\" fill=\"none\" stroke=\"#fcfaf6\" stroke-width=\"").V(Call(r2_14, V.Undef, ((V)((0.6 * ToNum(s_429)))))).S("\" stroke-linejoin=\"round\" opacity=\"0.9\" transform=\"translate(0 0.45)\"/>").S(gn_550.Str).S("</g>").End());
}
return ((V)(JsStrBuf.Begin().S(heap_459.Str).S("<g opacity=\"").V(al_440).S("\"><path d=\"").V(Call(arc_442, V.Undef, ((V)(rim_435)), ((V)(rx_433)), ((V)(ry_434)), ((V)(0D)))).S("L").V(Call(r2_14, V.Undef, ((V)((cx_432 + brx_437))))).S(" ").V(Call(r2_14, V.Undef, ((V)(by_439)))).S("A").V(Call(r2_14, V.Undef, ((V)(brx_437)))).S(" ").V(Call(r2_14, V.Undef, ((V)(bry_438)))).S(" 0 0 1 ").V(Call(r2_14, V.Undef, ((V)((cx_432 - brx_437))))).S(" ").V(Call(r2_14, V.Undef, ((V)(by_439)))).S("Z\" fill=\"url(#dbw").V(u_431).S(")\"/>").S(st_452.Str).S("<path d=\"").V(Call(arc_442, V.Undef, hy_453, ha_454, hb_455, ((V)(0D)))).S("L").V(Call(r2_14, V.Undef, Add(((V)(cx_432)), ha2_457))).S(" ").V(Call(r2_14, V.Undef, hy2_456)).S("A").V(Call(r2_14, V.Undef, ha2_457)).S(" ").V(Call(r2_14, V.Undef, hb2_458)).S(" 0 0 1 ").V(Call(r2_14, V.Undef, ((V)((cx_432 - ToNum(ha2_457)))))).S(" ").V(Call(r2_14, V.Undef, hy2_456)).S("Z\" fill=\"#9b6c3a\" opacity=\"0.8\"/>").S("<path d=\"").V(Call(arc_442, V.Undef, hy_453, ha_454, hb_455, ((V)(0D)))).S("\" fill=\"none\" stroke=\"#e8c58e\" stroke-width=\"").V(Call(r2_14, V.Undef, ((V)((0.4 * ToNum(s_429)))))).S("\" opacity=\"0.8\"/>").S("<path d=\"").V(Call(arc_442, V.Undef, ((V)((rim_435 + (0.9 * ToNum(s_429))))), ((V)((rx_433 - 0.1))), ((V)(ry_434)), ((V)(0D)))).S("\" fill=\"none\" stroke=\"#a97b43\" stroke-width=\"").V(Call(r2_14, V.Undef, ((V)((0.6 * ToNum(s_429)))))).S("\" opacity=\"0.6\"/>").S("<path d=\"").V(Call(arc_442, V.Undef, ((V)(rim_435)), ((V)(rx_433)), ((V)(ry_434)), ((V)(0D)))).S("\" fill=\"none\" stroke=\"#f8e4bf\" stroke-width=\"").V(Call(r2_14, V.Undef, ((V)((1.9 * ToNum(s_429)))))).S("\" stroke-linecap=\"round\"/>").S("<path d=\"M").V(Call(r2_14, V.Undef, ((V)((cx_432 - (rx_433 * 0.5)))))).S(" ").V(Call(r2_14, V.Undef, ((V)(((rim_435 + (ry_434 * 0.86)) - 0.25))))).S("Q").V(Call(r2_14, V.Undef, ((V)((cx_432 - (rx_433 * 0.2)))))).S(" ").V(Call(r2_14, V.Undef, ((V)(((rim_435 + ry_434) + 0.05))))).S(" ").V(Call(r2_14, V.Undef, ((V)((cx_432 + (rx_433 * 0.05)))))).S(" ").V(Call(r2_14, V.Undef, ((V)(((rim_435 + (ry_434 * 0.99)) - 0.25))))).S("\" stroke=\"#ffffff\" stroke-width=\"").V(Call(r2_14, V.Undef, ((V)((0.6 * ToNum(s_429)))))).S("\" stroke-linecap=\"round\" fill=\"none\" opacity=\"0.65\"/>").S("<path d=\"M").V(Call(r2_14, V.Undef, ((V)((cx_432 - (brx_437 * 0.62)))))).S(" ").V(Call(r2_14, V.Undef, ((V)((by_439 + (bry_438 * 0.6)))))).S("Q").V(Call(r2_14, V.Undef, ((V)((cx_432 - (brx_437 * 0.3)))))).S(" ").V(Call(r2_14, V.Undef, ((V)((by_439 + (bry_438 * 0.86)))))).S(" ").V(Call(r2_14, V.Undef, ((V)((cx_432 - (brx_437 * 0.05)))))).S(" ").V(Call(r2_14, V.Undef, ((V)((by_439 + (bry_438 * 0.86)))))).S("\" stroke=\"#fff3da\" stroke-width=\"").V(Call(r2_14, V.Undef, ((V)((0.9 * ToNum(s_429)))))).S("\" stroke-linecap=\"round\" fill=\"none\" opacity=\"0.35\"/>").S(hzF_451.Str).S("</g>").End()));
return default;
}, 3, "dustBath", false);
water_57 = Fn((V _self577, int _argc578, V I_584, V P_585, V now_586, V _a583, V[] _rest579) => {
V wd_587 = default;
V on_588 = default;
V sh_589 = default;
V stm_590 = default;
V wet_591 = default;
V fh_592 = default;
V spg_593 = default;
V C_594 = default;
V W_595 = default;
V ok_596 = default;
double T_597 = 0;
V M_598 = default;
V m0_599 = default;
V sl_600 = default;
V sr_601 = default;
double hw0_602 = 0;
V cx0_603 = default;
JsStrBuf back_604 = null;
JsStrBuf h_605 = null;
double Y_606 = 0;
V cx_607 = default;
V hw_608 = default;
V HD_609 = default;
if (_self577.IsNullish) _self577 = GlobalV;
wd_587 = Call(clamp_13, V.Undef, (Get(P_585, "wd") is var _t610 && Truthy(_t610) ? _t610 : ((V)(0D))), ((V)(0D)), ((V)(1.2)));
on_588 = (GtN(wd_587, 0.02) ? V.True : V.False);
sh_589 = (Get(P_585, "shw") is var _t611 && Truthy(_t611) ? _t611 : ((V)(0D)));
stm_590 = (Get(P_585, "stm") is var _t612 && Truthy(_t612) ? _t612 : ((V)(0D)));
wet_591 = (Get(P_585, "wet") is var _t613 && Truthy(_t613) ? _t613 : ((V)(0D)));
fh_592 = (Get(P_585, "fh") is var _t614 && Truthy(_t614) ? _t614 : ((V)(0D)));
spg_593 = (Get(P_585, "spg") is var _t615 && Truthy(_t615) ? _t615 : ((V)(0D)));
if (((((((!(Truthy(on_588)) && LtN(sh_589, 0.02)) && LtN(stm_590, 0.02)) && LtN(wet_591, 0.02)) && LtN(fh_592, 0.02)) && LtN(spg_593, 0.02)) && !(Truthy((Get(I_584, "wc") is var _t616 && !Truthy(_t616) ? _t616 : Get(Get(I_584, "wc"), "on")))))) {
return ((V)(""));
}
if (Truthy((on_588 is var _t617 && !Truthy(_t617) ? _t617 : (!(Truthy(Get(I_584, "wc"))) ? V.True : V.False)))) {
Set(I_584, "wc", Call(wPrep_53, V.Undef, I_584));
}
C_594 = Get(I_584, "wc");
W_595 = (Get(I_584, "W") is var _t618 && Truthy(_t618) ? _t618 : NewObj(0).V);
ok_596 = Fn((V _arrowThis626, int _argc619, V p_625, V _a622, V _a623, V _a624, V[] _rest620) => {
return ((p_625 is var _t627 && !Truthy(_t627) ? _t627 : (IsFiniteV(GetIdx(p_625, 0D)) ? V.True : V.False)) is var _t628 && !Truthy(_t628) ? _t628 : (IsFiniteV(GetIdx(p_625, 1D)) ? V.True : V.False));
}, 1, "", true);
T_597 = (ToNum(now_586) / 1000D);
M_598 = (Truthy(Call(ok_596, V.Undef, Get(W_595, "mouth"))) ? Get(W_595, "mouth") : (Truthy(Call(ok_596, V.Undef, Get(W_595, "nose"))) ? Get(W_595, "nose") : V.Null));
m0_599 = Add((Truthy(M_598) ? GetIdx(M_598, 1D) : ((V)(58D))), Get(P_585, "lift"));
sl_600 = Get(W_595, "sideL");
sr_601 = Get(W_595, "sideR");
hw0_602 = (Truthy((Call(ok_596, V.Undef, sl_600) is var _t629 && !Truthy(_t629) ? _t629 : Call(ok_596, V.Undef, sr_601))) ? ((System.Math.Abs((ToNum(GetIdx(sr_601, 0D)) - ToNum(GetIdx(sl_600, 0D)))) * 0.56) + 4D) : 22D);
cx0_603 = (Truthy(Call(ok_596, V.Undef, Get(W_595, "body"))) ? GetIdx(Get(W_595, "body"), 0D) : Add(((V)(50D)), Get(P_585, "x")));
back_604 = new JsStrBuf("");
h_605 = new JsStrBuf("");
Y_606 = 0D;
cx_607 = cx0_603;
hw_608 = Call(clamp_13, V.Undef, ((V)(hw0_602)), ((V)(14D)), ((V)(38D)));
if (Truthy(C_594)) {
Set(C_594, "m0", (Get(C_594, "m0").IsNullish ? m0_599 : Add(Get(C_594, "m0"), ((V)(((ToNum(m0_599) - ToNum(Get(C_594, "m0"))) * 0.05))))));
Set(C_594, "cx", (Get(C_594, "cx").IsNullish ? cx0_603 : Add(Get(C_594, "cx"), ((V)(((ToNum(cx0_603) - ToNum(Get(C_594, "cx"))) * 0.2))))));
Set(C_594, "hw", (Get(C_594, "hw").IsNullish ? hw_608 : Add(Get(C_594, "hw"), ((V)(((ToNum(hw_608) - ToNum(Get(C_594, "hw"))) * 0.1))))));
cx_607 = Get(C_594, "cx");
hw_608 = Get(C_594, "hw");
}
if (Truthy((C_594 is var _t630 && !Truthy(_t630) ? _t630 : (!SEq(on_588, Get(C_594, "on")) ? V.True : V.False)))) {
Set(C_594, "on", on_588);
if (Truthy(on_588)) {
Invoke(Get(C_594, "g"), "setAttribute", ((V)("clip-path")), ((V)(JsStrBuf.Begin().S("url(#wcl").V(Get(I_584, "u")).S(")").End())));
} else {
Invoke(Get(C_594, "g"), "removeAttribute", ((V)("clip-path")));
Set(Get(C_594, "b"), "innerHTML", ((V)("")));
}
}
if (Truthy((on_588 is var _t631 && !Truthy(_t631) ? _t631 : C_594))) {
double G0_632 = 0;
V top_633 = default;
V rx_634 = default;
double ry_635 = 0;
V half_636 = default;
V fm_637 = default;
V dk_638 = default;
G0_632 = 96D;
top_633 = Add(Add(Get(C_594, "m0"), (Get(P_585, "sk") is var _t639 && Truthy(_t639) ? _t639 : ((V)(0D)))), ((V)(5D)));
Y_606 = (G0_632 - (Min(ToNum(wd_587), 1D) * (G0_632 - ToNum(top_633))));
Invoke(Get(C_594, "rc"), "setAttribute", ((V)("height")), Call(r2_14, V.Undef, ((V)(((400D + Y_606) + 1.2)))));
rx_634 = Add(hw_608, ((V)(6D)));
ry_635 = Max(2.6, (ToNum(rx_634) * 0.19));
half_636 = Fn((V _arrowThis650, int _argc640, V y_646, V rxx_647, V ryy_648, V up_649, V[] _rest641) => {
return ((V)(JsStrBuf.Begin().S("M").V(Call(r2_14, V.Undef, ((V)((ToNum(cx_607) - ToNum(rxx_647)))))).S(" ").V(Call(r2_14, V.Undef, y_646)).S("A").V(Call(r2_14, V.Undef, rxx_647)).S(" ").V(Call(r2_14, V.Undef, ryy_648)).S(" 0 0 ").N((Truthy(up_649) ? 1D : 0D)).S(" ").V(Call(r2_14, V.Undef, Add(cx_607, rxx_647))).S(" ").V(Call(r2_14, V.Undef, y_646)).End()));
}, 4, "", true);
back_604.S("<path d=\"").V(Call(half_636, V.Undef, ((V)(Y_606)), rx_634, ((V)(ry_635)), ((V)(1D)))).S("Z\" fill=\"#8fd0ee\" opacity=\"0.55\"/><path d=\"").V(Call(half_636, V.Undef, ((V)(Y_606)), rx_634, ((V)(ry_635)), ((V)(1D)))).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.6\" opacity=\"0.7\"/>");
h_605.S("<path d=\"").V(Call(half_636, V.Undef, ((V)(Y_606)), rx_634, ((V)(ry_635)), ((V)(0D)))).S("Z\" fill=\"#7cc6ea\" opacity=\"0.62\"/><path d=\"").V(Call(half_636, V.Undef, ((V)((Y_606 + 0.2))), ((V)((ToNum(rx_634) - 0.6))), ((V)((ry_635 * 0.86))), ((V)(0D)))).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.9\" stroke-linecap=\"round\" opacity=\"0.85\"/>");
h_605.S("<path d=\"M").V(Call(r2_14, V.Undef, ((V)(((ToNum(cx_607) - ToNum(hw_608)) + 1.5))))).S(" ").V(Call(r2_14, V.Undef, ((V)((Y_606 + 0.3))))).S("Q").V(Call(r2_14, V.Undef, cx_607)).S(" ").V(Call(r2_14, V.Undef, ((V)((Y_606 + 2.2))))).S(" ").V(Call(r2_14, V.Undef, ((V)((ToNum(Add(cx_607, hw_608)) - 1.5))))).S(" ").V(Call(r2_14, V.Undef, ((V)((Y_606 + 0.3))))).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"1.1\" stroke-linecap=\"round\" opacity=\"0.9\"/>");
{
double i_651 = 0;
i_651 = 0D;
while (true) {
if (!((i_651 < 2D))) break;
double u_653 = 0;
double k_654 = 0;
V op_655 = default;
u_653 = (((T_597 / 1.8) + (i_651 / 2D)) % 1D);
k_654 = (1D + (u_653 * 0.55));
op_655 = Call(r2_14, V.Undef, ((V)(((1D - u_653) * 0.6))));
back_604.S("<path d=\"").V(Call(half_636, V.Undef, ((V)(Y_606)), ((V)((ToNum(rx_634) * k_654))), ((V)((ry_635 * k_654))), ((V)(1D)))).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.55\" opacity=\"").V(op_655).S("\"/>");
h_605.S("<path d=\"").V(Call(half_636, V.Undef, ((V)(Y_606)), ((V)((ToNum(rx_634) * k_654))), ((V)((ry_635 * k_654))), ((V)(0D)))).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.55\" opacity=\"").V(op_655).S("\"/>");
i_651++;
}
}
fm_637 = Call(clamp_13, V.Undef, (Get(P_585, "fm") is var _t656 && Truthy(_t656) ? _t656 : ((V)(0D))), ((V)(0D)), ((V)(1.4)));
if (GtN(fm_637, 0.02)) {
double N_657 = 0;
N_657 = 24D;
{
double i_658 = 0;
i_658 = 0D;
while (true) {
if (!((i_658 < N_657))) break;
double a_660 = 0;
V rr_661 = default;
V x_662 = default;
double y_663 = 0;
double r_664 = 0;
V s_665 = default;
a_660 = (((i_658 / N_657) * TAU_12) + (FdLibm.Sin(((T_597 * 0.6) + i_658)) * 0.05));
rr_661 = Add(Add(hw_608, ((V)(0.5))), ((V)((((i_658 * 7D) % 5D) * 1.1))));
x_662 = Add(cx_607, ((V)((FdLibm.Cos(a_660) * ToNum(rr_661)))));
y_663 = (Y_606 + ((FdLibm.Sin(a_660) * ry_635) * 0.95));
r_664 = (((2.1 + (((i_658 * 5D) % 4D) * 0.6)) * ToNum(fm_637)) * (0.9 + (0.1 * FdLibm.Sin(((T_597 * 2.2) + (i_658 * 1.7))))));
s_665 = Call(bub_55, V.Undef, x_662, ((V)((y_663 - (r_664 * 0.4)))), ((V)(r_664)), ((V)(Min(1D, ToNum(fm_637)))));
if ((FdLibm.Sin(a_660) < 0D)) {
back_604.V(s_665);
} else {
h_605.V(s_665);
}
i_658++;
}
}
Invoke(Arr(Arr(((V)((-1.06))), ((V)(0.4)), ((V)(3.6))), Arr(((V)((-0.9))), ((V)(0.8)), ((V)(2.6))), Arr(((V)(1.1)), ((V)(0.3)), ((V)(3.2))), Arr(((V)(0.85)), ((V)(0.85)), ((V)(2.8))), Arr(((V)((-0.45))), ((V)(1.05)), ((V)(2.4))), Arr(((V)(0.2)), ((V)(1.15)), ((V)(2.2))), Arr(((V)(1.28)), ((V)((-0.3))), ((V)(2.4))), Arr(((V)((-1.25))), ((V)((-0.25))), ((V)(2.6)))), "forEach", Fn((V _arrowThis680, int _argc666, V _a668, V i_672, V _a670, V _a671, V[] _rest667) => {
V fx_675 = default;
V fy_677 = default;
V r_679 = default;
{ V _t673 = ListOf(_a668);
{ V _t674 = GetIdx(_t673, 0D);
fx_675 = _t674; }
{ V _t676 = GetIdx(_t673, 1D);
fy_677 = _t676; }
{ V _t678 = GetIdx(_t673, 2D);
r_679 = _t678; }
}
h_605.V(Call(bub_55, V.Undef, Add(cx_607, ((V)((ToNum(fx_675) * ToNum(rx_634))))), ((V)(((Y_606 + (ToNum(fy_677) * ry_635)) - 1D))), ((V)(((ToNum(r_679) * ToNum(fm_637)) * (0.92 + (0.08 * FdLibm.Sin(ToNum(Add(((V)((T_597 * 1.9))), i_672)))))))), ((V)(Min(1D, ToNum(fm_637))))));
return default;
}, 2, "", true));
}
dk_638 = Call(clamp_13, V.Undef, (Get(P_585, "dk") is var _t681 && Truthy(_t681) ? _t681 : ((V)(0D))), ((V)(0D)), ((V)(1D)));
if (GtN(dk_638, 0.02)) {
V dx_682 = default;
double dy_683 = 0;
double s_684 = 0;
dx_682 = Add(cx_607, ((V)((ToNum(rx_634) * ToNum(Add(((V)(0.62)), (Get(P_585, "dkx") is var _t685 && Truthy(_t685) ? _t685 : ((V)(0D)))))))));
dy_683 = (((Y_606 + (ry_635 * 0.75)) + (FdLibm.Sin((T_597 * 2.4)) * 0.6)) + ((1D - ToNum(dk_638)) * 5D));
s_684 = (1.8 * ToNum(dk_638));
h_605.S("<g transform=\"translate(").V(Call(r2_14, V.Undef, dx_682)).S(" ").V(Call(r2_14, V.Undef, ((V)(dy_683)))).S(") rotate(").V(Call(r2_14, V.Undef, ((V)((FdLibm.Sin((T_597 * 1.7)) * 6D))))).S(") scale(").V(Call(r2_14, V.Undef, ((V)((-s_684))))).S(" ").V(Call(r2_14, V.Undef, ((V)(s_684)))).S(")\" opacity=\"").V(Call(r2_14, V.Undef, dk_638)).S("\">").V(DUCK_54).S("</g>");
}
if (GtN((Get(P_585, "dv") is var _t686 && Truthy(_t686) ? _t686 : ((V)(0D))), 0.3)) {
{
double i_687 = 0;
i_687 = 0D;
while (true) {
if (!((i_687 < 3D))) break;
double u_689 = 0;
u_689 = (((T_597 * 1.4) + (i_687 / 3D)) % 1D);
h_605.V(Call(bub_55, V.Undef, Add(cx_607, ((V)((FdLibm.Sin(((i_687 * 2.1) + T_597)) * 4D)))), ((V)(((Y_606 - 1D) - (u_689 * 3D)))), ((V)((0.9 + (u_689 * 0.8)))), ((V)(((1D - u_689) * 0.9)))));
i_687++;
}
}
}
}
if (Truthy(C_594)) {
Set(Get(C_594, "b"), "innerHTML", ((V)(back_604.Str)));
}
HD_609 = (Truthy(Call(ok_596, V.Undef, Get(W_595, "head"))) ? Get(W_595, "head") : (Truthy(Call(ok_596, V.Undef, Get(I_584, "topW"))) ? Get(I_584, "topW") : Arr(Add(((V)(50D)), Get(P_585, "x")), ((V)(20D)))));
if (GtN(fh_592, 0.02)) {
double k_690 = 0;
k_690 = Min(ToNum(fh_592), 1.8);
Invoke(Arr(Arr(((V)(0D)), ((V)((-2D))), ((V)(4D))), Arr(((V)((-4.2))), ((V)(0.3)), ((V)(3D))), Arr(((V)(4D)), ((V)((-0.1))), ((V)(3.2))), Arr(((V)((-1.9))), ((V)((-5.4))), ((V)(2.8))), Arr(((V)(2.2)), ((V)((-5D))), ((V)(2.5))), Arr(((V)(0.2)), ((V)((-8.4))), ((V)((2.3 * Max(0D, (k_690 - 0.6)))))), Arr(((V)((-0.6))), ((V)((-11D))), ((V)((1.6 * Max(0D, (k_690 - 1.1))))))), "forEach", Fn((V _arrowThis705, int _argc691, V _a693, V i_697, V _a695, V _a696, V[] _rest692) => {
V x_700 = default;
V y_702 = default;
V r_704 = default;
{ V _t698 = ListOf(_a693);
{ V _t699 = GetIdx(_t698, 0D);
x_700 = _t699; }
{ V _t701 = GetIdx(_t698, 1D);
y_702 = _t701; }
{ V _t703 = GetIdx(_t698, 2D);
r_704 = _t703; }
}
if (GtN(r_704, 0.1)) {
h_605.V(Call(bub_55, V.Undef, Add(GetIdx(HD_609, 0D), ((V)((ToNum(x_700) * Min(1D, k_690))))), Add(Add(Add(GetIdx(HD_609, 1D), ((V)(1.4))), ((V)((ToNum(y_702) * k_690)))), ((V)((FdLibm.Sin(ToNum(Add(((V)((T_597 * 2D))), i_697))) * 0.3)))), ((V)(((ToNum(r_704) * Min(1D, k_690)) * (0.94 + (0.06 * FdLibm.Sin(ToNum(Add(((V)((T_597 * 3D))), i_697)))))))), ((V)(Min(1D, (ToNum(fh_592) * 1.4))))));
}
return default;
}, 2, "", true));
}
if (Truthy((((GtN(spg_593, 0.02) ? V.True : V.False) is var _t706 && !Truthy(_t706) ? _t706 : Call(ok_596, V.Undef, Get(W_595, "pawR"))) is var _t707 && !Truthy(_t707) ? _t707 : ((!(Truthy(on_588)) || LtN(GetIdx(Get(W_595, "pawR"), 1D), (Y_606 + 1.5))) ? V.True : V.False)))) {
V x_708 = default;
V y_709 = default;
double s_710 = 0;
{ V _t711 = Get(W_595, "pawR");
{ V _t712 = ListOf(_t711);
{ V _t713 = GetIdx(_t712, 0D);
x_708 = _t713; }
{ V _t714 = GetIdx(_t712, 1D);
y_709 = _t714; }
} }
s_710 = Min(1D, ToNum(spg_593));
h_605.S("<g transform=\"translate(").V(Call(r2_14, V.Undef, x_708)).S(" ").V(Call(r2_14, V.Undef, ((V)((ToNum(y_709) - 1.4))))).S(") rotate(").V(Call(r2_14, V.Undef, ((V)(((-14D) + (FdLibm.Sin((T_597 * 9D)) * 6D)))))).S(") scale(").V(Call(r2_14, V.Undef, ((V)(s_710)))).S(")\"><rect x=\"-3.6\" y=\"-2.5\" width=\"7.2\" height=\"5\" rx=\"1.6\" fill=\"#ffd04a\" stroke=\"#e0a21e\" stroke-width=\"0.4\"/><rect x=\"-3.6\" y=\"1\" width=\"7.2\" height=\"1.5\" rx=\"0.7\" fill=\"#7cc35a\"/><circle cx=\"-1.6\" cy=\"-0.6\" r=\"0.5\" fill=\"#e0a21e\"/><circle cx=\"1.2\" cy=\"-1.3\" r=\"0.45\" fill=\"#e0a21e\"/><circle cx=\"0.4\" cy=\"0.2\" r=\"0.35\" fill=\"#e0a21e\"/>").V(Call(bub_55, V.Undef, ((V)(2.6)), ((V)((-2.8))), ((V)((1.2 * s_710))), ((V)(s_710)))).S("</g>");
}
if (GtN(sh_589, 0.02)) {
double n_715 = 0;
double Yb_716 = 0;
double hr_717 = 0;
n_715 = 13D;
Yb_716 = (Truthy(on_588) ? Y_606 : 95D);
hr_717 = Max(9D, (ToNum(hw_608) * 0.62));
{
double i_718 = 0;
i_718 = 0D;
while (true) {
if (!((i_718 < n_715))) break;
double x_720 = 0;
V inside_721 = default;
V yb_722 = default;
double L_723 = 0;
x_720 = ((((ToNum(cx_607) - ToNum(hw_608)) - 4D) + (((i_718 + 0.5) * ((2D * ToNum(hw_608)) + 8D)) / n_715)) + (FdLibm.Sin((i_718 * 3.1)) * 0.8));
inside_721 = ((System.Math.Abs((x_720 - ToNum(cx_607))) < hr_717) ? V.True : V.False);
yb_722 = (Truthy(inside_721) ? Add(Add(GetIdx(HD_609, 1D), ((V)(2D))), ((V)((Pow(((x_720 - ToNum(cx_607)) / hr_717), 2D) * 8D)))) : ((V)(Yb_716)));
L_723 = (7D + ((i_718 % 3D) * 2D));
{
double j_724 = 0;
j_724 = 0D;
while (true) {
if (!((j_724 < 3D))) break;
double yy_726 = 0;
double y2_727 = 0;
yy_726 = ((-26D) + ((((T_597 * 95D) + (i_718 * 23D)) + (j_724 * 31D)) % ToNum(Add(yb_722, ((V)(26D))))));
y2_727 = Min(ToNum(yb_722), (yy_726 + L_723));
if ((y2_727 > yy_726)) {
h_605.S("<path d=\"M").V(Call(r2_14, V.Undef, ((V)(x_720)))).S(" ").V(Call(r2_14, V.Undef, ((V)(yy_726)))).S("L").V(Call(r2_14, V.Undef, ((V)((x_720 - 0.5))))).S(" ").V(Call(r2_14, V.Undef, ((V)(y2_727)))).S("\" stroke=\"#5fb8ea\" stroke-width=\"1.25\" stroke-linecap=\"round\" opacity=\"").V(Call(r2_14, V.Undef, ((V)((0.8 * ToNum(sh_589)))))).S("\"/><path d=\"M").V(Call(r2_14, V.Undef, ((V)((x_720 - 0.2))))).S(" ").V(Call(r2_14, V.Undef, ((V)(yy_726)))).S("L").V(Call(r2_14, V.Undef, ((V)((x_720 - 0.6))))).S(" ").V(Call(r2_14, V.Undef, ((V)(y2_727)))).S("\" stroke=\"#ffffff\" stroke-width=\"0.45\" stroke-linecap=\"round\" opacity=\"").V(Call(r2_14, V.Undef, ((V)((0.9 * ToNum(sh_589)))))).S("\"/>");
}
j_724++;
}
}
if (Truthy((inside_721 is var _t728 && !Truthy(_t728) ? _t728 : ((V)((i_718 % 2D)))))) {
double u_729 = 0;
u_729 = (((T_597 * 3D) + (i_718 * 0.37)) % 1D);
h_605.S("<circle cx=\"").V(Call(r2_14, V.Undef, ((V)((x_720 + (((Lt(((V)(x_720)), cx_607) ? (-1D) : 1D) * u_729) * 4D)))))).S("\" cy=\"").V(Call(r2_14, V.Undef, ((V)((ToNum(yb_722) - (FdLibm.Sin((u_729 * System.Math.PI)) * 3D)))))).S("\" r=\"0.55\" fill=\"#bfe8ff\" opacity=\"").V(Call(r2_14, V.Undef, ((V)(((1D - u_729) * ToNum(sh_589)))))).S("\"/>");
}
i_718++;
}
}
}
if (GtN(stm_590, 0.02)) {
{
double i_730 = 0;
i_730 = 0D;
while (true) {
if (!((i_730 < 5D))) break;
double u_732 = 0;
V x_733 = default;
double y_734 = 0;
u_732 = (((T_597 / 3.2) + (i_730 / 5D)) % 1D);
x_733 = Add(Add(cx_607, ((V)((((i_730 - 2D) * ToNum(hw_608)) * 0.42)))), ((V)((FdLibm.Sin((T_597 + i_730)) * 3D))));
y_734 = ((Truthy(on_588) ? Y_606 : 70D) - (u_732 * 46D));
h_605.S("<circle cx=\"").V(Call(r2_14, V.Undef, x_733)).S("\" cy=\"").V(Call(r2_14, V.Undef, ((V)(y_734)))).S("\" r=\"").V(Call(r2_14, V.Undef, ((V)((3D + (u_732 * 6D)))))).S("\" fill=\"#ffffff\" opacity=\"").V(Call(r2_14, V.Undef, ((V)(((FdLibm.Sin((System.Math.PI * u_732)) * 0.32) * Min(1D, ToNum(stm_590))))))).S("\"/>");
i_730++;
}
}
}
if (GtN(wet_591, 0.02)) {
V src_735 = default;
src_735 = Invoke(Arr(Get(W_595, "sideL"), Get(W_595, "sideR"), M_598, Get(W_595, "belly"), (Truthy(Call(ok_596, V.Undef, Get(W_595, "earL"))) ? Get(W_595, "earL") : V.Null)), "filter", ok_596);
Invoke(src_735, "forEach", Fn((V _arrowThis744, int _argc736, V p_742, V i_743, V _a740, V _a741, V[] _rest737) => {
double u_745 = 0;
V y_746 = default;
u_745 = (((T_597 / 0.95) + (ToNum(i_743) * 0.29)) % 1D);
y_746 = Add(Add(GetIdx(p_742, 1D), ((V)(2D))), ((V)((u_745 * 13D))));
if (Truthy((on_588 is var _t747 && !Truthy(_t747) ? _t747 : (GtN(y_746, Y_606) ? V.True : V.False)))) {
return default;
}
h_605.S("<path transform=\"translate(").V(Call(r2_14, V.Undef, Add(GetIdx(p_742, 0D), ((V)(((NumTruthy((ToNum(i_743) % 2D)) ? 1D : (-1D)) * 1.2)))))).S(" ").V(Call(r2_14, V.Undef, y_746)).S(") scale(").V(Call(r2_14, V.Undef, ((V)((0.9 * Min(1D, ToNum(wet_591))))))).S(")\" d=\"M0 -2 Q1.4 0.4 0 1.3 Q-1.4 0.4 0 -2Z\" fill=\"#8fd3ff\" stroke=\"#ffffff\" stroke-width=\"0.3\" opacity=\"").V(Call(r2_14, V.Undef, ((V)(((1D - u_745) * Min(1D, ToNum(wet_591))))))).S("\"/>");
return default;
}, 2, "", true));
}
return ((V)(h_605.Str));
return default;
}, 3, "water", false);
tick_59 = Fn((V _self748, int _argc749, V I_755, V now_756, V dt_757, V _a754, V[] _rest750) => {
V SO_758 = default;
V st_759 = default;
double t_760 = 0;
V FL_761 = default;
V P_762 = default;
V lw_763 = default;
V tx_764 = default;
V ty_765 = default;
V pv_766 = default;
double ht_767 = 0;
V hx_768 = default;
V ed_769 = default;
V ld_770 = default;
V sd_771 = default;
double tt_772 = 0;
V fx_773 = default;
V pr_774 = default;
if (_self748.IsNullish) _self748 = GlobalV;
SO_758 = Fn((V _arrowThis782, int _argc775, V n_781, V _a778, V _a779, V _a780, V[] _rest776) => {
return ((Get(I_755, "key") is var _t783 && !Truthy(_t783) ? _t783 : GetK(STATES_38, ((V)(JsStrBuf.Begin().V(n_781).S("@").V(Get(I_755, "key")).End())))) is var _t784 && Truthy(_t784) ? _t784 : GetK(STATES_38, n_781));
}, 1, "", true);
st_759 = Call(SO_758, V.Undef, Get(Get(I_755, "cur"), "name"));
t_760 = (ToNum(now_756) - ToNum(Get(Get(I_755, "cur"), "t0")));
if (Truthy((Get(st_759, "dur") is var _t785 && !Truthy(_t785) ? _t785 : (Ge(((V)(t_760)), Get(st_759, "dur")) ? V.True : V.False)))) {
Call(setState_45, V.Undef, I_755, (Truthy(Get(Get(I_755, "queue"), "length")) ? Invoke(Get(I_755, "queue"), "shift") : (Get(st_759, "next") is var _t786 && Truthy(_t786) ? _t786 : ((V)("idle")))), now_756, (true ? V.True : V.False));
st_759 = Call(SO_758, V.Undef, Get(Get(I_755, "cur"), "name"));
t_760 = 0D;
}
FL_761 = (Truthy(Get(G("window"), "SquishConfig")) ? Invoke(Get(G("window"), "SquishConfig"), "filter", Get(I_755, "ak"), (((Get(I_755, "hfid") is var _t787 && !Truthy(_t787) ? _t787 : Get(I_755, "key")) is var _t788 && !Truthy(_t788) ? _t788 : GetK(FIDK_97, Get(I_755, "key"))) is var _t789 && Truthy(_t789) ? _t789 : FIDGETS_96)) : (((Get(I_755, "hfid") is var _t790 && !Truthy(_t790) ? _t790 : Get(I_755, "key")) is var _t791 && !Truthy(_t791) ? _t791 : GetK(FIDK_97, Get(I_755, "key"))) is var _t792 && Truthy(_t792) ? _t792 : FIDGETS_96));
if (Truthy((((((SEqS(Get(Get(I_755, "cur"), "name"), "idle") ? V.True : V.False) is var _t793 && !Truthy(_t793) ? _t793 : Get(I_755, "fidgets")) is var _t794 && !Truthy(_t794) ? _t794 : (!(Truthy(Get(I_755, "press"))) ? V.True : V.False)) is var _t795 && !Truthy(_t795) ? _t795 : (!(Truthy(Get(I_755, "down"))) ? V.True : V.False)) is var _t796 && !Truthy(_t796) ? _t796 : Get(FL_761, "length")))) {
if (!(Truthy(Get(I_755, "fidAt")))) {
Set(I_755, "fidAt", Add(now_756, ((V)((Truthy(Get(I_755, "hfid")) ? (3200D + (ToNum(Invoke(G("Math"), "random")) * 3600D)) : (4200D + (ToNum(Invoke(G("Math"), "random")) * 4200D)))))));
} else {
if (Gt(now_756, Get(I_755, "fidAt"))) {
V f_797 = default;
Set(I_755, "fidAt", ((V)(0D)));
f_797 = V.Undef;
do {
f_797 = GetIdx(FL_761, System.Math.Floor((ToNum(Invoke(G("Math"), "random")) * ToNum(Get(FL_761, "length")))));
} while ((GtN(Get(FL_761, "length"), 1D) && SEq(f_797, Get(I_755, "lastFid"))));
Set(I_755, "lastFid", f_797);
Call(setState_45, V.Undef, I_755, f_797, now_756, (true ? V.True : V.False));
st_759 = Call(SO_758, V.Undef, f_797);
t_760 = 0D;
}
}
} else {
if (!SEqS(Get(Get(I_755, "cur"), "name"), "idle")) {
Set(I_755, "fidAt", ((V)(0D)));
}
}
if (Truthy(Get(st_759, "emit"))) {
double tl_798 = 0;
tl_798 = (Truthy(Get(st_759, "loop")) ? (t_760 % ToNum(Get(st_759, "loop"))) : t_760);
Invoke(Get(st_759, "emit"), "forEach", Fn((V _arrowThis807, int _argc799, V m_805, V i_806, V _a803, V _a804, V[] _rest800) => {
if (((Ge(((V)(tl_798)), GetIdx(m_805, 0D)) && Le(((V)(tl_798)), GetIdx(m_805, 1D))) && Ge(((V)((ToNum(now_756) - ToNum((GetK(Get(I_755, "emL"), i_806) is var _t808 && Truthy(_t808) ? _t808 : ((V)(0D))))))), GetIdx(m_805, 2D)))) {
SetK(Get(I_755, "emL"), i_806, now_756);
Call(emit_51, V.Undef, I_755, GetIdx(m_805, 3D), GetIdx(m_805, 4D), GetIdx(m_805, 5D));
}
return default;
}, 2, "", true));
}
if (Truthy(Get(st_759, "ev"))) {
double c_809 = 0;
double tl_810 = 0;
c_809 = (Truthy(Get(st_759, "loop")) ? System.Math.Floor((t_760 / ToNum(Get(st_759, "loop")))) : 0D);
tl_810 = (Truthy(Get(st_759, "loop")) ? (t_760 % ToNum(Get(st_759, "loop"))) : t_760);
if (!SEqN(Get(I_755, "evC"), c_809)) {
Set(I_755, "evC", ((V)(c_809)));
Set(I_755, "evF", NewObj(0).V);
}
Invoke(Get(st_759, "ev"), "forEach", Fn((V _arrowThis819, int _argc811, V e_817, V i_818, V _a815, V _a816, V[] _rest812) => {
if ((Ge(((V)(tl_810)), GetIdx(e_817, 0D)) && !(Truthy(GetK(Get(I_755, "evF"), i_818))))) {
SetK(Get(I_755, "evF"), i_818, ((V)(1D)));
Call(fire_46, V.Undef, I_755, e_817, now_756);
}
return default;
}, 2, "", true));
}
P_762 = Call(poseAt_43, V.Undef, Get(Get(I_755, "cur"), "name"), ((V)(t_760)), Get(I_755, "key"));
if (Truthy(Get(I_755, "prev"))) {
V w_820 = default;
w_820 = Invoke(EZ_18, "io", Call(clamp_13, V.Undef, ((V)(((ToNum(now_756) - ToNum(Get(I_755, "bt0"))) / ToNum(Get(I_755, "bd"))))), ((V)(0D)), ((V)(1D))));
if (GeN(w_820, 1D)) {
Set(I_755, "prev", V.Null);
} else {
V Q_821 = default;
Q_821 = (Get(Get(I_755, "prev"), "frozen") is var _t822 && Truthy(_t822) ? _t822 : Call(poseAt_43, V.Undef, Get(Get(I_755, "prev"), "name"), ((V)((ToNum(now_756) - ToNum(Get(Get(I_755, "prev"), "t0"))))), Get(I_755, "key")));
{
foreach (V _k823 in ForInKeys(P_762)) {
V k_824 = default;
k_824 = _k823;
if (SEqS(k_824, "spin")) {
double d_825 = 0;
d_825 = (ToNum(Get(P_762, "spin")) - ToNum(Get(Q_821, "spin")));
d_825 = ((((d_825 % 360D) + 540D) % 360D) - 180D);
Set(P_762, "spin", Add(Get(Q_821, "spin"), ((V)((d_825 * ToNum(w_820))))));
} else {
SetK(P_762, k_824, Call(lerp_15, V.Undef, (GetK(Q_821, k_824).IsNullish ? GetK(P_762, k_824) : GetK(Q_821, k_824)), GetK(P_762, k_824), w_820));
}
}
}
}
}
if (Truthy(Get(I_755, "ext"))) {
{
foreach (V _k826 in ForInKeys(Get(I_755, "ext"))) {
V k_827 = default;
k_827 = _k826;
SetK(P_762, k_827, Add((GetK(P_762, k_827) is var _t828 && Truthy(_t828) ? _t828 : ((V)(0D))), GetK(Get(I_755, "ext"), k_827)));
}
}
}
Set(I_755, "lastP", Object_assign(NewObj(0).V, P_762));
Invoke(Get(I_755, "flw"), "step", ((V)((Truthy(Get(st_759, "look")) ? 1D : 0D))), dt_757);
lw_763 = Call(clamp_13, V.Undef, Get(Get(I_755, "flw"), "v"), ((V)(0D)), ((V)(1D)));
tx_764 = ((V)(0D));
ty_765 = ((V)(0D));
if (Truthy(Get(I_755, "ptr"))) {
tx_764 = Get(Get(I_755, "ptr"), "x");
ty_765 = Get(Get(I_755, "ptr"), "y");
} else {
if (Gt(now_756, Get(I_755, "glAt"))) {
V g_829 = default;
g_829 = (LtN(Invoke(G("Math"), "random"), 0.3) ? Arr(((V)(0D)), ((V)(0D))) : Arr(((V)((((ToNum(Invoke(G("Math"), "random")) * 2D) - 1D) * 0.9))), ((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 0.7)))));
if (((System.Math.Abs((ToNum(GetIdx(g_829, 0D)) - ToNum(GetIdx(Get(I_755, "gl"), 0D)))) > 0.9) && ((ToNum(now_756) - ToNum(Get(I_755, "blinkT"))) > 800D))) {
Set(I_755, "blinkT", Add(now_756, ((V)(60D))));
Set(I_755, "dbl", (false ? V.True : V.False));
}
Set(I_755, "gl", g_829);
Set(I_755, "glAt", Add(Add(now_756, ((V)(1400D))), ((V)((ToNum(Invoke(G("Math"), "random")) * 2600D)))));
}
tx_764 = GetIdx(Get(I_755, "gl"), 0D);
ty_765 = GetIdx(Get(I_755, "gl"), 1D);
}
Invoke(Get(I_755, "fex"), "step", tx_764, dt_757);
Invoke(Get(I_755, "fey"), "step", ty_765, dt_757);
Invoke(Get(I_755, "fhx"), "step", tx_764, dt_757);
Invoke(Get(I_755, "fhy"), "step", ty_765, dt_757);
if (Truthy(Invoke(HYAW_41, "has", Get(I_755, "key")))) {
OpSet(P_762, "hyaw", 0, ((V)(((ToNum(Get(Get(I_755, "fhx"), "v")) * 0.62) * ToNum(lw_763)))));
OpSet(P_762, "turn", 0, ((V)(((ToNum(Get(Get(I_755, "fhx"), "v")) * 0.06) * ToNum(lw_763)))));
} else {
OpSet(P_762, "turn", 0, ((V)(((ToNum(Get(Get(I_755, "fhx"), "v")) * 0.6) * ToNum(lw_763)))));
}
OpSet(P_762, "lx", 0, ((V)((ToNum(Get(Get(I_755, "fex"), "v")) * ToNum(lw_763)))));
OpSet(P_762, "ly", 0, ((V)((ToNum(Get(Get(I_755, "fey"), "v")) * ToNum(lw_763)))));
OpSet(P_762, "pitch", 1, ((V)(((ToNum(Get(Get(I_755, "fhy"), "v")) * 0.35) * ToNum(lw_763)))));
OpSet(P_762, "htilt", 0, ((V)(((ToNum(Get(Get(I_755, "fhx"), "v")) * 2.5) * ToNum(lw_763)))));
if (Gt(now_756, Get(I_755, "blinkAt"))) {
Set(I_755, "blinkT", now_756);
Set(I_755, "dbl", (LtN(Invoke(G("Math"), "random"), 0.2) ? V.True : V.False));
Set(I_755, "blinkAt", Add(Add(now_756, ((V)(2200D))), ((V)((ToNum(Invoke(G("Math"), "random")) * 3200D)))));
}
if (!(Truthy(Get(st_759, "noBlink")))) {
V b_830 = default;
b_830 = Call(blinkC_58, V.Undef, ((V)((ToNum(now_756) - ToNum(Get(I_755, "blinkT"))))));
if (Truthy(Get(I_755, "dbl"))) {
b_830 = ((V)(Max(ToNum(b_830), ToNum(Call(blinkC_58, V.Undef, ((V)(((ToNum(now_756) - ToNum(Get(I_755, "blinkT"))) - 260D))))))));
}
Set(P_762, "close", ((V)(Max(ToNum(Get(P_762, "close")), ToNum(b_830)))));
}
Set(Get(I_755, "fp"), "w", ((V)((Truthy(Get(I_755, "press")) ? 14D : 28D))));
Invoke(Get(I_755, "fp"), "step", ((V)((Truthy(Get(I_755, "press")) ? 1D : 0D))), dt_757);
pv_766 = Call(clamp_13, V.Undef, Get(Get(I_755, "fp"), "v"), ((V)(0D)), ((V)(1.05)));
ht_767 = (Truthy(Get(I_755, "press")) ? (ToNum(now_756) - ToNum(Get(I_755, "pressT"))) : 0D);
if (GtN(pv_766, 0.001)) {
V PR_831 = default;
OpSet(P_762, "sq", 0, ((V)((ToNum(pv_766) * (0.34 + (0.06 * ToNum(Call(clamp_13, V.Undef, ((V)((ht_767 / 2000D))), ((V)(0D)), ((V)(1D))))))))));
Set(P_762, "hap", ((V)(Max(ToNum(Get(P_762, "hap")), (ToNum(pv_766) * 0.85)))));
OpSet(P_762, "armL", 0, ((V)((ToNum(pv_766) * 22D))));
OpSet(P_762, "armR", 0, ((V)((ToNum(pv_766) * 22D))));
OpSet(P_762, "earL", 0, ((V)((ToNum(pv_766) * 14D))));
OpSet(P_762, "earR", 0, ((V)((ToNum(pv_766) * 14D))));
Set(P_762, "blush", ((V)(Max(ToNum(Get(P_762, "blush")), (ToNum(pv_766) * ToNum(Call(clamp_13, V.Undef, ((V)(((ht_767 - 400D) / 900D))), ((V)(0D)), ((V)(1D)))))))));
if ((ht_767 > 1300D)) {
OpSet(P_762, "x", 0, ((V)(((FdLibm.Sin((ToNum(now_756) / 24D)) * 0.22) * ToNum(pv_766)))));
}
PR_831 = (Get(I_755, "key") is var _t832 && !Truthy(_t832) ? _t832 : GetK(PRESS_98, Get(I_755, "key")));
if (Truthy(PR_831)) {
{
foreach (V _k833 in ForInKeys(PR_831)) {
V k_834 = default;
k_834 = _k833;
OpSetK(P_762, k_834, 0, ((V)((ToNum(pv_766) * ToNum(GetK(PR_831, k_834))))));
}
}
}
}
Set(I_755, "dent", V.Null);
Set(I_755, "shots", Invoke(Get(I_755, "shots"), "filter", Fn((V _arrowThis842, int _argc835, V s_841, V _a838, V _a839, V _a840, V[] _rest836) => {
double u_843 = 0;
u_843 = (ToNum(now_756) - ToNum(Get(s_841, "t0")));
if (Gt(((V)(u_843)), Get(Get(s_841, "S"), "dur"))) {
return (false ? V.True : V.False);
}
{
foreach (V _k844 in ForInKeys(Get(Get(s_841, "S"), "k"))) {
V k_845 = default;
k_845 = _k844;
V v_846 = default;
v_846 = Call(kv_19, V.Undef, GetK(Get(Get(s_841, "S"), "k"), k_845), ((V)(u_843)));
if (SEqS(k_845, "dent")) {
Set(I_755, "dent", NewObj(3).Put("x", Get(s_841, "x")).Put("y", Get(s_841, "y")).Put("a", v_846).V);
} else {
OpSetK(P_762, k_845, 0, v_846);
}
}
}
return (true ? V.True : V.False);
return default;
}, 1, "", true)));
if (Truthy(Get(I_755, "spinTw"))) {
V u_847 = default;
u_847 = Call(clamp_13, V.Undef, ((V)(((ToNum(now_756) - ToNum(Get(Get(I_755, "spinTw"), "t0"))) / ToNum(Get(Get(I_755, "spinTw"), "d"))))), ((V)(0D)), ((V)(1D)));
Set(I_755, "spinOff", Call(lerp_15, V.Undef, Get(Get(I_755, "spinTw"), "from"), Get(Get(I_755, "spinTw"), "to"), Invoke(EZ_18, "bk", u_847)));
if (GeN(u_847, 1D)) {
Set(I_755, "spinOff", ((V)((ToNum(Get(Get(I_755, "spinTw"), "to")) % 360D))));
Set(I_755, "spinTw", V.Null);
}
}
OpSet(P_762, "spin", 0, Get(I_755, "spinOff"));
Invoke(Get(I_755, "fs"), "step", Get(P_762, "sq"), dt_757);
Set(I_755, "hs", Call(clamp_13, V.Undef, ((V)(((ToNum(Get(Get(I_755, "fs"), "v")) - ToNum(Get(P_762, "sq"))) * 0.55))), ((V)((-0.12))), ((V)(0.12))));
hx_768 = Add(Add(Add(Get(P_762, "x"), Get(P_762, "lean")), ((V)((ToNum(Get(P_762, "tilt")) * 0.9)))), ((V)((ToNum(Get(P_762, "htilt")) * 0.4))));
Invoke(Get(I_755, "fx"), "step", hx_768, dt_757);
ed_769 = Call(clamp_13, V.Undef, ((V)((ToNum(Get(Get(I_755, "fx"), "v")) - ToNum(hx_768)))), ((V)((-8D))), ((V)(8D)));
Invoke(Get(I_755, "fl"), "step", Get(P_762, "lift"), dt_757);
ld_770 = Call(clamp_13, V.Undef, ((V)((ToNum(Get(Get(I_755, "fl"), "v")) - ToNum(Get(P_762, "lift"))))), ((V)((-10D))), ((V)(10D)));
Set(I_755, "ld", ld_770);
if (!Get(I_755, "lastSpin").IsNullish) {
double dd_848 = 0;
dd_848 = (ToNum(Get(P_762, "spin")) - ToNum(Get(I_755, "lastSpin")));
if ((System.Math.Abs(dd_848) > 180D)) {
OpSet(Get(I_755, "fsp"), "v", 0, ((V)((Round((dd_848 / 360D)) * 360D))));
}
}
Set(I_755, "lastSpin", Get(P_762, "spin"));
Invoke(Get(I_755, "fsp"), "step", Get(P_762, "spin"), dt_757);
sd_771 = Call(clamp_13, V.Undef, ((V)((ToNum(Get(Get(I_755, "fsp"), "v")) - ToNum(Get(P_762, "spin"))))), ((V)((-40D))), ((V)(40D)));
if (Truthy(Get(st_759, "whip"))) {
V SB_849 = default;
SB_849 = Get(I_755, "spb");
if (Truthy(SB_849)) {
Set(Get(SB_849, "f"), "v", Get(P_762, "spin"));
Set(Get(SB_849, "f"), "d", ((V)(0D)));
Set(SB_849, "last", Get(P_762, "spin"));
Set(Get(SB_849, "w"), "v", ((V)(0D)));
Set(Get(SB_849, "w"), "d", ((V)(0D)));
Set(Get(SB_849, "wl"), "v", ((V)(0D)));
Set(Get(SB_849, "wl"), "d", ((V)(0D)));
}
Set(I_755, "spTw", ((V)(0D)));
Set(I_755, "spF", ((V)(0D)));
} else {
V SB_850 = default;
double dd_851 = 0;
V tw_852 = default;
double om_853 = 0;
V f_854 = default;
SB_850 = (Get(I_755, "spb") is var _t855 && Truthy(_t855) ? _t855 : Set(I_755, "spb", NewObj(4).Put("f", New(Fol_20, Get(P_762, "spin"), ((V)(7.5)), ((V)(0.42)))).Put("w", New(Fol_20, ((V)(0D)), ((V)(10D)), ((V)(0.75)))).Put("wl", New(Fol_20, ((V)(0D)), ((V)(6D)), ((V)(0.55)))).Put("last", Get(P_762, "spin")).V));
dd_851 = (ToNum(Get(P_762, "spin")) - ToNum(Get(SB_850, "last")));
if ((System.Math.Abs(dd_851) > 180D)) {
double k_856 = 0;
k_856 = (Round((dd_851 / 360D)) * 360D);
OpSet(Get(SB_850, "f"), "v", 0, ((V)(k_856)));
dd_851 = (dd_851 - k_856);
}
Set(SB_850, "last", Get(P_762, "spin"));
Invoke(Get(SB_850, "f"), "step", Get(P_762, "spin"), dt_757);
tw_852 = Call(clamp_13, V.Undef, ((V)((ToNum(Get(Get(SB_850, "f"), "v")) - ToNum(Get(P_762, "spin"))))), ((V)((-40D))), ((V)(40D)));
om_853 = (GtN(dt_757, 0.002) ? (System.Math.Abs(dd_851) / ToNum(dt_757)) : 0D);
Invoke(Get(SB_850, "w"), "step", Call(clamp_13, V.Undef, ((V)((om_853 / 540D))), ((V)(0D)), ((V)(1D))), dt_757);
f_854 = Call(clamp_13, V.Undef, Get(Get(SB_850, "w"), "v"), ((V)(0D)), ((V)(1D)));
Invoke(Get(SB_850, "wl"), "step", f_854, dt_757);
Set(I_755, "spTw", ((V)(((ToNum(tw_852) * 0.9) * D2R_11))));
Set(I_755, "spF", f_854);
if (!(Truthy(Get(I_755, "generic")))) {
Set(P_762, "twist", Add((Get(P_762, "twist") is var _t857 && Truthy(_t857) ? _t857 : ((V)(0D))), ((V)(((ToNum(tw_852) * 0.9) / 40D)))));
}
OpSet(P_762, "sq", 0, Add(((V)(((-0.045) * ToNum(f_854)))), Call(clamp_13, V.Undef, ((V)(((ToNum(Get(Get(SB_850, "wl"), "v")) - ToNum(f_854)) * 0.14))), ((V)((-0.03))), ((V)(0.05)))));
OpSet(P_762, "lift", 0, ((V)((1.5 * ToNum(f_854)))));
OpSet(P_762, "armL", 0, ((V)((18D * ToNum(f_854)))));
OpSet(P_762, "armR", 0, ((V)((18D * ToNum(f_854)))));
}
Set(I_755, "ed", ed_769);
OpSet(P_762, "earL", 0, Call(clamp_13, V.Undef, ((V)((((-ToNum(ed_769)) * 2D) - (ToNum(ld_770) * 1.3)))), ((V)((-22D))), ((V)(22D))));
OpSet(P_762, "earR", 0, Call(clamp_13, V.Undef, ((V)(((ToNum(ed_769) * 2D) - (ToNum(ld_770) * 1.3)))), ((V)((-22D))), ((V)(22D))));
OpSet(P_762, "wag", 0, Call(clamp_13, V.Undef, ((V)(((ToNum(sd_771) * 0.5) - (ToNum(ed_769) * 3D)))), ((V)((-30D))), ((V)(30D))));
if (Truthy(Invoke(SOFT_42, "has", Get(I_755, "key")))) {
V J_858 = default;
V g_859 = default;
V tx_860 = default;
V ty_861 = default;
V M_862 = default;
V lx_863 = default;
double yw_864 = 0;
double spd_865 = 0;
V sg_866 = default;
J_858 = (Get(I_755, "jel") is var _t867 && Truthy(_t867) ? _t867 : Set(I_755, "jel", NewObj(2).Put("x", New(Fol_20, ((V)(0D)), ((V)(7D)), ((V)(0.3)))).Put("y", New(Fol_20, ((V)(0D)), ((V)(8D)), ((V)(0.36)))).V));
g_859 = (Get(st_759, "soft") is var _t868 && Truthy(_t868) ? _t868 : ((V)(1D)));
tx_860 = Add(Add(Add(Add(Get(P_762, "x"), ((V)((ToNum(Get(P_762, "tilt")) * 0.9)))), ((V)((ToNum(Get(P_762, "turn")) * 5D)))), ((V)((ToNum(Get(P_762, "bend")) * 0.3)))), Get(P_762, "lean"));
ty_861 = Get(P_762, "lift");
OpSet(P_762, "bend", 0, Call(clamp_13, V.Undef, ((V)((((ToNum(Get(Get(J_858, "x"), "v")) - ToNum(tx_860)) * 2.6) * ToNum(g_859)))), ((V)((-16D))), ((V)(16D))));
OpSet(P_762, "sq", 0, Call(clamp_13, V.Undef, ((V)((((ToNum(Get(Get(J_858, "y"), "v")) - ToNum(ty_861)) * 0.008) * ToNum(g_859)))), ((V)((-0.06))), ((V)(0.06))));
M_862 = (Get(I_755, "mot") is var _t869 && Truthy(_t869) ? _t869 : Set(I_755, "mot", NewObj(5).Put("lx", V.Null).Put("ly", ((V)(0D))).Put("yw", ((V)(0D))).Put("vx", New(Fol_20, ((V)(0D)), ((V)(15D)), ((V)(1D)))).Put("vy", New(Fol_20, ((V)(0D)), ((V)(15D)), ((V)(1D)))).V));
lx_863 = Add(Add(Add(Get(P_762, "x"), ((V)((ToNum(Get(P_762, "tilt")) * 0.9)))), Get(P_762, "lean")), ((V)((ToNum(Get(P_762, "bend")) * 0.35))));
yw_864 = (ToNum(Add(Add(Get(P_762, "turn"), Get(P_762, "hyaw")), Get(P_762, "twist"))) * 40D);
if ((!Get(M_862, "lx").IsNullish && GtN(dt_757, 0.002))) {
Invoke(Get(M_862, "vx"), "step", ((V)((((ToNum(lx_863) - ToNum(Get(M_862, "lx"))) / ToNum(dt_757)) + ((((yw_864 - ToNum(Get(M_862, "yw"))) * D2R_11) / ToNum(dt_757)) * 4D)))), dt_757);
Invoke(Get(M_862, "vy"), "step", ((V)((((-(ToNum(Get(P_762, "lift")) - ToNum(Get(M_862, "ly")))) / ToNum(dt_757)) * 0.45))), dt_757);
}
Set(M_862, "lx", lx_863);
Set(M_862, "ly", Get(P_762, "lift"));
Set(M_862, "yw", ((V)(yw_864)));
spd_865 = Hypot(ToNum(Get(Get(M_862, "vx"), "v")), ToNum(Get(Get(M_862, "vy"), "v")));
sg_866 = (!Get(st_759, "stretch").IsNullish ? Get(st_759, "stretch") : ((V)(1D)));
Set(I_755, "ms", ((spd_865 > 2D) ? NewObj(3).Put("s", Call(clamp_13, V.Undef, ((V)(((spd_865 * 0.0034) * ToNum(sg_866)))), ((V)(0D)), ((V)((0.26 * Max(1D, (ToNum(sg_866) * 0.8))))))).Put("c", ((V)((ToNum(Get(Get(M_862, "vx"), "v")) / spd_865)))).Put("n", ((V)((ToNum(Get(Get(M_862, "vy"), "v")) / spd_865)))).V : V.Null));
} else {
Set(I_755, "ms", V.Null);
}
if (Truthy((Get(P_762, "sk") is var _t870 && Truthy(_t870) ? _t870 : Get(P_762, "dv")))) {
OpSet(P_762, "lift", 1, Add((Get(P_762, "sk") is var _t871 && Truthy(_t871) ? _t871 : ((V)(0D))), ((V)((ToNum((Get(P_762, "dv") is var _t872 && Truthy(_t872) ? _t872 : ((V)(0D)))) * 30D)))));
}
Set(I_755, "propZ", Get(st_759, "propZ"));
if (Truthy(Get(I_755, "generic"))) {
if (!(Truthy(Get(I_755, "ready")))) {
return default;
}
Invoke(I_755, "render", I_755, P_762, now_756);
} else {
Call(render_62, V.Undef, I_755, P_762, now_756);
}
if (Truthy(Get(I_755, "olDirty"))) {
Call(outline_91, V.Undef, I_755);
}
if (Truthy(Get(I_755, "olEls"))) {
Call(outlineTick_92, V.Undef, I_755);
}
tt_772 = (ToNum(now_756) - ToNum(Get(Get(I_755, "cur"), "t0")));
fx_773 = (Get(st_759, "fx") is var _t873 && Truthy(_t873) ? _t873 : GetK(FX_61, Get(Get(I_755, "cur"), "name")));
pr_774 = (Truthy(Get(st_759, "prop")) ? Invoke(st_759, "prop", I_755, ((V)(tt_772))) : (Truthy(Get(I_755, "propFn")) ? Invoke(I_755, "propFn", I_755, now_756) : ((V)(""))));
if (Truthy((pr_774 is var _t874 && Truthy(_t874) ? _t874 : Get(I_755, "propOn")))) {
Set(Get(Get(I_755, "pg"), "prop"), "innerHTML", pr_774);
Set(I_755, "propOn", (!(!(Truthy(pr_774))) ? V.True : V.False));
}
Set(Get(I_755, "fxG"), "innerHTML", Add(Add(Add(Add(Call(drawParts_52, V.Undef, I_755, dt_757), (Truthy(fx_773) ? Call(fx_773, V.Undef, I_755, ((V)(tt_772))) : ((V)("")))), Call(water_57, V.Undef, I_755, P_762, now_756)), Call(dustBath_56, V.Undef, I_755, P_762, now_756)), Call(whipFx_60, V.Undef, I_755, P_762)));
return default;
}, 3, "tick", false);
whipFx_60 = Fn((V _self875, int _argc876, V I_882, V P_883, V _a880, V _a881, V[] _rest877) => {
V s_884 = default;
V R_885 = default;
if (_self875.IsNullish) _self875 = GlobalV;
s_884 = Call(clamp_13, V.Undef, (((V)(ToNum(Get(P_883, "sblur")))) is var _t886 && Truthy(_t886) ? _t886 : ((V)(0D))), ((V)(0D)), ((V)(1.5)));
R_885 = (Get(I_882, "root") is var _t887 && Truthy(_t887) ? _t887 : Get(I_882, "art"));
if (!(Truthy(R_885))) {
return ((V)(""));
}
if ((GtN(s_884, 0.02) && !(Truthy(Get(I_882, "mbW"))))) {
V svg_888 = default;
V NS_889 = default;
V df_890 = default;
V f_891 = default;
V b_892 = default;
V W_893 = default;
svg_888 = Get(R_885, "ownerSVGElement");
NS_889 = ((V)("http://www.w3.org/2000/svg"));
df_890 = (Invoke(svg_888, "querySelector", ((V)("defs"))) is var _t894 && Truthy(_t894) ? _t894 : Invoke(svg_888, "insertBefore", Invoke(G("document"), "createElementNS", NS_889, ((V)("defs"))), Get(svg_888, "firstChild")));
f_891 = Invoke(G("document"), "createElementNS", NS_889, ((V)("filter")));
b_892 = Invoke(G("document"), "createElementNS", NS_889, ((V)("feGaussianBlur")));
W_893 = Invoke(G("document"), "createElementNS", NS_889, ((V)("g")));
Invoke(f_891, "setAttribute", ((V)("id")), ((V)(JsStrBuf.Begin().S("mbl").V(Get(I_882, "u")).End())));
Invoke(f_891, "setAttribute", ((V)("x")), ((V)("-40%")));
Invoke(f_891, "setAttribute", ((V)("y")), ((V)("-10%")));
Invoke(f_891, "setAttribute", ((V)("width")), ((V)("180%")));
Invoke(f_891, "setAttribute", ((V)("height")), ((V)("120%")));
Invoke(b_892, "setAttribute", ((V)("in")), ((V)("SourceGraphic")));
Invoke(b_892, "setAttribute", ((V)("stdDeviation")), ((V)("0 0")));
Invoke(f_891, "appendChild", b_892);
Invoke(df_890, "appendChild", f_891);
Invoke(Get(R_885, "parentNode"), "insertBefore", W_893, R_885);
Invoke(W_893, "appendChild", R_885);
Set(I_882, "mbW", W_893);
Set(I_882, "mbF", b_892);
}
if (!(Truthy(Get(I_882, "mbW")))) {
return ((V)(""));
}
if (LeN(s_884, 0.02)) {
if (Truthy(Get(I_882, "mbOn"))) {
Invoke(Get(I_882, "mbW"), "removeAttribute", ((V)("filter")));
Set(I_882, "mbOn", (false ? V.True : V.False));
}
return ((V)(""));
}
Invoke(Get(I_882, "mbF"), "setAttribute", ((V)("stdDeviation")), ((V)(JsStrBuf.Begin().V(Call(r2_14, V.Undef, ((V)((ToNum(s_884) * 3.4))))).S(" 0").End())));
if (!(Truthy(Get(I_882, "mbOn")))) {
Invoke(Get(I_882, "mbW"), "setAttribute", ((V)("filter")), ((V)(JsStrBuf.Begin().S("url(#mbl").V(Get(I_882, "u")).S(")").End())));
Set(I_882, "mbOn", (true ? V.True : V.False));
}
return ((V)(""));
return default;
}, 2, "whipFx", false);
render_62 = Fn((V _self895, int _argc896, V I_902, V P_903, V now_904, V _a901, V[] _rest897) => {
V D_905 = default;
V R_906 = default;
V E_907 = default;
V G_908 = default;
double Hh_909 = 0;
V HX_910 = default;
V HY_911 = default;
V HR_912 = default;
V SR_913 = default;
V HRY_914 = default;
V SRY_915 = default;
double KY_916 = 0;
V NX_917 = default;
V NY_918 = default;
double yb_919 = 0;
double yh_920 = 0;
double ya_921 = 0;
double cya_922 = 0;
double sya_923 = 0;
double ph_924 = 0;
double cyb_925 = 0;
double syb_926 = 0;
double cyh_927 = 0;
double syh_928 = 0;
double cp_929 = 0;
double sp_930 = 0;
double bnd_931 = 0;
double HN_932 = 0;
V MS_933 = default;
V MAx_934 = default;
double MAy_935 = 0;
V sq_936 = default;
double sy_937 = 0;
double tr_938 = 0;
double ct_939 = 0;
double stt_940 = 0;
V dn_941 = default;
V glob_942 = default;
V hs_943 = default;
double hr_944 = 0;
double chr_945 = 0;
double shr_946 = 0;
double hyo_947 = 0;
V headT_948 = default;
V sz_949 = default;
V sph_950 = default;
V sphZ_951 = default;
V face_952 = default;
V face0_953 = default;
V wrapF_954 = default;
V vis_955 = default;
V zc_956 = default;
double yw_957 = 0;
double hY_958 = 0;
double hw_959 = 0;
double HP_960 = 0;
V hugF_961 = default;
V byw_962 = default;
V bywZ_963 = default;
V set_964 = default;
V pf_965 = default;
V hF_966 = default;
V skD_967 = default;
V rd_968 = default;
V gr_969 = default;
V keys_970 = default;
V MZ_971 = default;
V NS0_972 = default;
V sm_973 = default;
V decal_974 = default;
V CK_975 = default;
double ox_976 = 0;
double oy_977 = 0;
double ws_978 = 0;
V h_979 = default;
V qz_980 = default;
double cr_981 = 0;
V ty_982 = default;
V wk_983 = default;
V wFold_984 = default;
double gl_985 = 0;
V order_986 = default;
V os_987 = default;
if (_self895.IsNullish) _self895 = GlobalV;
D_905 = Get(I_902, "D");
R_906 = Get(I_902, "RG");
E_907 = Get(I_902, "E");
G_908 = Get(D_905, "G");
Hh_909 = (ToNum(G_908) - ToNum(Get(D_905, "top")));
{ V _t988 = Get(D_905, "head");
{ V _t989 = ListOf(_t988);
{ V _t990 = GetIdx(_t989, 0D);
HX_910 = _t990; }
{ V _t991 = GetIdx(_t989, 1D);
HY_911 = _t991; }
{ V _t992 = GetIdx(_t989, 2D);
HR_912 = _t992; }
} }
SR_913 = Add(HR_912, ((V)(0.5)));
HRY_914 = (GetIdx(Get(D_905, "head"), 3D) is var _t993 && Truthy(_t993) ? _t993 : HR_912);
SRY_915 = Add(HRY_914, ((V)(0.5)));
KY_916 = (ToNum(SRY_915) / ToNum(SR_913));
{ V _t994 = Get(D_905, "neck");
{ V _t995 = ListOf(_t994);
{ V _t996 = GetIdx(_t995, 0D);
NX_917 = _t996; }
{ V _t997 = GetIdx(_t995, 1D);
NY_918 = _t997; }
} }
yb_919 = (ToNum(Add(Get(P_903, "spin"), ((V)((ToNum(Get(P_903, "turn")) * 40D))))) * D2R_11);
yh_920 = (yb_919 + ((ToNum(Add((Get(P_903, "hyaw") is var _t998 && Truthy(_t998) ? _t998 : ((V)(0D))), (Get(P_903, "twist") is var _t999 && Truthy(_t999) ? _t999 : ((V)(0D))))) * 40D) * D2R_11));
ya_921 = (yb_919 + ((ToNum((Get(P_903, "twist") is var _t1000 && Truthy(_t1000) ? _t1000 : ((V)(0D)))) * 24D) * D2R_11));
cya_922 = FdLibm.Cos(ya_921);
sya_923 = FdLibm.Sin(ya_921);
ph_924 = ((ToNum(Get(P_903, "pitch")) * 22D) * D2R_11);
cyb_925 = FdLibm.Cos(yb_919);
syb_926 = FdLibm.Sin(yb_919);
cyh_927 = FdLibm.Cos(yh_920);
syh_928 = FdLibm.Sin(yh_920);
cp_929 = FdLibm.Cos(ph_924);
sp_930 = FdLibm.Sin(ph_924);
bnd_931 = (ToNum(Call(clamp_13, V.Undef, (Get(P_903, "bend") is var _t1001 && Truthy(_t1001) ? _t1001 : ((V)(0D))), ((V)((-32D))), ((V)(32D)))) * D2R_11);
HN_932 = Max(8D, ((ToNum(G_908) - ToNum(GetIdx(Get(D_905, "neck"), 1D))) + 2D));
MS_933 = (Truthy((Get(I_902, "ms") is var _t1002 && !Truthy(_t1002) ? _t1002 : (GtN(Get(Get(I_902, "ms"), "s"), 0.004) ? V.True : V.False))) ? Get(I_902, "ms") : V.Null);
MAx_934 = Add(((V)(50D)), Get(P_903, "x"));
MAy_935 = ((ToNum(G_908) - ToNum(Get(P_903, "lift"))) - ((ToNum(G_908) - ToNum(GetIdx(Get(D_905, "head"), 1D))) * (1D - ToNum(Call(clamp_13, V.Undef, Get(P_903, "sq"), ((V)((-0.25))), ((V)(0.45)))))));
sq_936 = Call(clamp_13, V.Undef, Get(P_903, "sq"), ((V)((-0.25))), ((V)(0.45)));
sy_937 = (1D - ToNum(sq_936));
tr_938 = (ToNum(Get(P_903, "tilt")) * D2R_11);
ct_939 = FdLibm.Cos(tr_938);
stt_940 = FdLibm.Sin(tr_938);
dn_941 = (Truthy((Get(I_902, "dent") is var _t1003 && !Truthy(_t1003) ? _t1003 : (GtN(Get(Get(I_902, "dent"), "a"), 0.01) ? V.True : V.False))) ? Get(I_902, "dent") : V.Null);
glob_942 = Fn((V _arrowThis1012, int _argc1004, V x_1010, V y_1011, V _a1008, V _a1009, V[] _rest1005) => {
V u_1013 = default;
double kx_1014 = 0;
double X0_1015 = 0;
double h_1016 = 0;
double X_1017 = 0;
double Y_1018 = 0;
V gx_1019 = default;
double gy_1020 = 0;
if (Truthy(dn_941)) {
double ddx_1021 = 0;
double ddy_1022 = 0;
double g_1023 = 0;
ddx_1021 = (ToNum(x_1010) - ToNum(Get(dn_941, "x")));
ddy_1022 = (ToNum(y_1011) - ToNum(Get(dn_941, "y")));
g_1023 = FdLibm.Exp(((-((ddx_1021 * ddx_1021) + (ddy_1022 * ddy_1022))) / 90D));
if ((g_1023 > 0.01)) {
double vx_1024 = 0;
double vy_1025 = 0;
V L_1026 = default;
vx_1024 = (50D - ToNum(Get(dn_941, "x")));
vy_1025 = (60D - ToNum(Get(dn_941, "y")));
L_1026 = (((V)(Hypot(vx_1024, vy_1025))) is var _t1027 && Truthy(_t1027) ? _t1027 : ((V)(1D)));
x_1010 = Add(x_1010, ((V)(((((vx_1024 / ToNum(L_1026)) * ToNum(Get(dn_941, "a"))) * 4.5) * g_1023))));
y_1011 = Add(y_1011, ((V)(((((vy_1025 / ToNum(L_1026)) * ToNum(Get(dn_941, "a"))) * 4.5) * g_1023))));
}
}
u_1013 = Call(clamp_13, V.Undef, ((V)(((ToNum(G_908) - ToNum(y_1011)) / Hh_909))), ((V)(0D)), ((V)(1D)));
kx_1014 = (1D + (ToNum(sq_936) * (0.45 + (((0.6 * 4D) * ToNum(u_1013)) * (1D - ToNum(u_1013))))));
X0_1015 = (((ToNum(x_1010) - 50D) * kx_1014) + (ToNum(Get(P_903, "lean")) * Pow(ToNum(u_1013), 1.5)));
h_1016 = ((ToNum(G_908) - ToNum(y_1011)) * sy_937);
X_1017 = X0_1015;
Y_1018 = (-h_1016);
if (NumTruthy(bnd_931)) {
double hn_1028 = 0;
double c_1029 = 0;
hn_1028 = (HN_932 * sy_937);
c_1029 = (bnd_931 / hn_1028);
if ((h_1016 <= hn_1028)) {
double a_1030 = 0;
a_1030 = (c_1029 * h_1016);
X_1017 = (((1D - FdLibm.Cos(a_1030)) / c_1029) + (X0_1015 * FdLibm.Cos(a_1030)));
Y_1018 = (-((FdLibm.Sin(a_1030) / c_1029) - (X0_1015 * FdLibm.Sin(a_1030))));
} else {
double dh_1031 = 0;
double cb_1032 = 0;
double sb_1033 = 0;
dh_1031 = (h_1016 - hn_1028);
cb_1032 = FdLibm.Cos(bnd_931);
sb_1033 = FdLibm.Sin(bnd_931);
X_1017 = ((((1D - cb_1032) / c_1029) + (X0_1015 * cb_1032)) + (dh_1031 * sb_1033));
Y_1018 = (-(((sb_1033 / c_1029) - (X0_1015 * sb_1033)) + (dh_1031 * cb_1032)));
}
}
gx_1019 = Add(((V)(((50D + (X_1017 * ct_939)) - (Y_1018 * stt_940)))), Get(P_903, "x"));
gy_1020 = (ToNum(Add(Add(G_908, ((V)((X_1017 * stt_940)))), ((V)((Y_1018 * ct_939))))) - ToNum(Get(P_903, "lift")));
if (Truthy(MS_933)) {
V w_1034 = default;
double k_1035 = 0;
double dx_1036 = 0;
double dy_1037 = 0;
double al_1038 = 0;
double pe_1039 = 0;
w_1034 = Call(SM_16, V.Undef, ((V)((ToNum(u_1013) * 1.5))));
k_1035 = (1D + (ToNum(Get(MS_933, "s")) * ToNum(w_1034)));
dx_1036 = (ToNum(gx_1019) - ToNum(MAx_934));
dy_1037 = (gy_1020 - MAy_935);
al_1038 = (((dx_1036 * ToNum(Get(MS_933, "c"))) + (dy_1037 * ToNum(Get(MS_933, "n")))) * k_1035);
pe_1039 = ((((-dx_1036) * ToNum(Get(MS_933, "n"))) + (dy_1037 * ToNum(Get(MS_933, "c")))) / k_1035);
gx_1019 = ((V)((ToNum(Add(MAx_934, ((V)((al_1038 * ToNum(Get(MS_933, "c"))))))) - (pe_1039 * ToNum(Get(MS_933, "n"))))));
gy_1020 = ((MAy_935 + (al_1038 * ToNum(Get(MS_933, "n")))) + (pe_1039 * ToNum(Get(MS_933, "c"))));
}
return Arr(gx_1019, ((V)(gy_1020)));
return default;
}, 2, "", true);
hs_943 = Get(I_902, "hs");
hr_944 = (ToNum(Get(P_903, "htilt")) * D2R_11);
chr_945 = FdLibm.Cos(hr_944);
shr_946 = FdLibm.Sin(hr_944);
hyo_947 = ((-ToNum(Get(P_903, "pitch"))) * 1.1);
headT_948 = Fn((V _arrowThis1048, int _argc1040, V x_1046, V y_1047, V _a1044, V _a1045, V[] _rest1041) => {
double dx_1049 = 0;
double dy_1050 = 0;
x_1046 = ((V)((50D + ((ToNum(x_1046) - 50D) * (1D + (ToNum(hs_943) * 0.6))))));
y_1047 = ((V)(((ToNum(NY_918) - ((ToNum(NY_918) - ToNum(y_1047)) * (1D - ToNum(hs_943)))) + hyo_947)));
dx_1049 = (ToNum(x_1046) - ToNum(NX_917));
dy_1050 = (ToNum(y_1047) - ToNum(NY_918));
return Call(glob_942, V.Undef, ((V)((ToNum(Add(NX_917, ((V)((dx_1049 * chr_945))))) - (dy_1050 * shr_946)))), Add(Add(NY_918, ((V)((dx_1049 * shr_946)))), ((V)((dy_1050 * chr_945)))));
return default;
}, 2, "", true);
sz_949 = Fn((V _arrowThis1060, int _argc1051, V dx_1057, V dy_1058, V zm_1059, V _a1056, V[] _rest1052) => {
double q_1061 = 0;
double z_1062 = 0;
if (string.Equals(Typeof(zm_1059), "number")) {
return zm_1059;
}
q_1061 = ((1D - ((ToNum(dx_1057) / ToNum(SR_913)) * (ToNum(dx_1057) / ToNum(SR_913)))) - ((ToNum(dy_1058) / ToNum(SRY_915)) * (ToNum(dy_1058) / ToNum(SRY_915))));
z_1062 = ((q_1061 > 0D) ? (ToNum(SR_913) * System.Math.Sqrt(q_1061)) : 0D);
return ((V)((SEqS(zm_1059, "b") ? (-z_1062) : z_1062)));
return default;
}, 3, "", true);
sph_950 = Fn((V _arrowThis1072, int _argc1063, V x_1069, V y_1070, V zm_1071, V _a1068, V[] _rest1064) => {
double dx_1073 = 0;
double dy_1074 = 0;
V z_1075 = default;
double x1_1076 = 0;
double z1_1077 = 0;
double X_1078 = 0;
double Y_1079 = 0;
dx_1073 = (ToNum(x_1069) - ToNum(HX_910));
dy_1074 = (ToNum(y_1070) - ToNum(HY_911));
z_1075 = Call(sz_949, V.Undef, ((V)(dx_1073)), ((V)(dy_1074)), zm_1071);
x1_1076 = ((dx_1073 * cyh_927) + (ToNum(z_1075) * syh_928));
z1_1077 = (((-dx_1073) * syh_928) + (ToNum(z_1075) * cyh_927));
X_1078 = x1_1076;
Y_1079 = ((dy_1074 * cp_929) - ((z1_1077 * sp_930) * KY_916));
if ((SEq(zm_1071, V.Undef) && ((((dy_1074 * sp_930) / KY_916) + (z1_1077 * cp_929)) < 0D))) {
V nr_1080 = default;
nr_1080 = (((V)(Hypot((X_1078 / ToNum(SR_913)), (Y_1079 / ToNum(SRY_915))))) is var _t1081 && Truthy(_t1081) ? _t1081 : ((V)(1D)));
X_1078 = (X_1078 / ToNum(nr_1080));
Y_1079 = (Y_1079 / ToNum(nr_1080));
}
return Call(headT_948, V.Undef, Add(HX_910, ((V)(X_1078))), Add(HY_911, ((V)(Y_1079))));
return default;
}, 3, "", true);
sphZ_951 = Fn((V _arrowThis1091, int _argc1082, V x_1088, V y_1089, V zm_1090, V _a1087, V[] _rest1083) => {
double dx_1092 = 0;
double dy_1093 = 0;
V z_1094 = default;
double z1_1095 = 0;
dx_1092 = (ToNum(x_1088) - ToNum(HX_910));
dy_1093 = (ToNum(y_1089) - ToNum(HY_911));
z_1094 = Call(sz_949, V.Undef, ((V)(dx_1092)), ((V)(dy_1093)), zm_1090);
z1_1095 = (((-dx_1092) * syh_928) + (ToNum(z_1094) * cyh_927));
return ((V)((((dy_1093 * sp_930) / KY_916) + (z1_1095 * cp_929))));
return default;
}, 3, "", true);
face_952 = Fn((V _arrowThis1104, int _argc1096, V x_1102, V y_1103, V _a1100, V _a1101, V[] _rest1097) => {
return Call(sph_950, V.Undef, x_1102, y_1103);
}, 2, "", true);
face0_953 = face_952;
wrapF_954 = Fn((V _arrowThis1113, int _argc1105, V x_1111, V y_1112, V _a1109, V _a1110, V[] _rest1106) => {
double dx_1114 = 0;
double dy_1115 = 0;
double q_1116 = 0;
V w_1117 = default;
V a_1118 = default;
V b_1119 = default;
dx_1114 = (ToNum(x_1111) - ToNum(HX_910));
dy_1115 = (ToNum(y_1112) - ToNum(HY_911));
q_1116 = ((1D - ((dx_1114 / ToNum(SR_913)) * (dx_1114 / ToNum(SR_913)))) - ((dy_1115 / ToNum(SRY_915)) * (dy_1115 / ToNum(SRY_915))));
w_1117 = Call(SM_16, V.Undef, ((V)(((q_1116 - 0.04) / 0.32))));
if (GeN(w_1117, 1D)) {
return Call(sph_950, V.Undef, x_1111, y_1112);
}
a_1118 = Call(sph_950, V.Undef, x_1111, y_1112);
b_1119 = Call(headT_948, V.Undef, x_1111, y_1112);
return Arr(Add(GetIdx(b_1119, 0D), ((V)(((ToNum(GetIdx(a_1118, 0D)) - ToNum(GetIdx(b_1119, 0D))) * ToNum(w_1117))))), Add(GetIdx(b_1119, 1D), ((V)(((ToNum(GetIdx(a_1118, 1D)) - ToNum(GetIdx(b_1119, 1D))) * ToNum(w_1117))))));
return default;
}, 2, "", true);
vis_955 = Fn((V _arrowThis1127, int _argc1120, V z_1126, V _a1123, V _a1124, V _a1125, V[] _rest1121) => {
return Call(SM_16, V.Undef, ((V)(((ToNum(z_1126) - 1.5) / 6D))));
}, 1, "", true);
zc_956 = Fn((V _arrowThis1137, int _argc1128, V x_1134, V y_1135, V zm_1136, V _a1133, V[] _rest1129) => {
return Call(vis_955, V.Undef, Call(sphZ_951, V.Undef, x_1134, y_1135, zm_1136));
}, 3, "", true);
yw_957 = (((((yh_920 / D2R_11) % 360D) + 540D) % 360D) - 180D);
hY_958 = (ToNum(Call(clamp_13, V.Undef, ((V)(yw_957)), ((V)((-85D))), ((V)(85D)))) * D2R_11);
hw_959 = (1D - ToNum(Call(SM_16, V.Undef, ((V)(((System.Math.Abs(yw_957) - 45D) / 40D))))));
HP_960 = (System.Math.PI / 2D);
hugF_961 = Fn((V _arrowThis1146, int _argc1138, V x_1144, V y_1145, V _a1142, V _a1143, V[] _rest1139) => {
double dx_1147 = 0;
double dy_1148 = 0;
V z_1149 = default;
double r_1150 = 0;
double th_1151 = 0;
double t2_1152 = 0;
double z1_1153 = 0;
V b_1154 = default;
V a_1155 = default;
dx_1147 = (ToNum(x_1144) - ToNum(HX_910));
dy_1148 = (ToNum(y_1145) - ToNum(HY_911));
z_1149 = Call(sz_949, V.Undef, ((V)(dx_1147)), ((V)(dy_1148)));
r_1150 = Hypot(dx_1147, ToNum(z_1149));
th_1151 = FdLibm.Atan2(dx_1147, ToNum(z_1149));
t2_1152 = ((th_1151 < 0D) ? ((-HP_960) + (((th_1151 + HP_960) * (HP_960 + hY_958)) / HP_960)) : (hY_958 + ((th_1151 * (HP_960 - hY_958)) / HP_960)));
z1_1153 = (r_1150 * FdLibm.Cos(t2_1152));
b_1154 = Call(headT_948, V.Undef, Add(HX_910, ((V)((r_1150 * FdLibm.Sin(t2_1152))))), ((V)((ToNum(Add(HY_911, ((V)((dy_1148 * cp_929))))) - ((z1_1153 * sp_930) * KY_916)))));
if ((hw_959 >= 1D)) {
return b_1154;
}
a_1155 = Call(wrapF_954, V.Undef, x_1144, y_1145);
return Arr(Add(GetIdx(a_1155, 0D), ((V)(((ToNum(GetIdx(b_1154, 0D)) - ToNum(GetIdx(a_1155, 0D))) * hw_959)))), Add(GetIdx(a_1155, 1D), ((V)(((ToNum(GetIdx(b_1154, 1D)) - ToNum(GetIdx(a_1155, 1D))) * hw_959)))));
return default;
}, 2, "", true);
byw_962 = Fn((V _arrowThis1165, int _argc1156, V x_1162, V y_1163, V z_1164, V _a1161, V[] _rest1157) => {
return Call(glob_942, V.Undef, ((V)(((50D + ((ToNum(x_1162) - 50D) * cyb_925)) + (ToNum(z_1164) * syb_926)))), y_1163);
}, 3, "", true);
bywZ_963 = Fn((V _arrowThis1174, int _argc1166, V x_1172, V z_1173, V _a1170, V _a1171, V[] _rest1167) => {
return ((V)((((-(ToNum(x_1172) - 50D)) * syb_926) + (ToNum(z_1173) * cyb_925))));
}, 2, "", true);
set_964 = Fn((V _arrowThis1184, int _argc1175, V e_1181, V a_1182, V v_1183, V _a1180, V[] _rest1176) => {
return Invoke(e_1181, "setAttribute", a_1182, v_1183);
}, 3, "", true);
if (Truthy(Get(D_905, "body3"))) {
V B3_1185 = default;
V bx_1186 = default;
V by_1187 = default;
V bz_1188 = default;
V brx_1189 = default;
V bry_1190 = default;
V brz_1191 = default;
double t3_1192 = 0;
double c3_1193 = 0;
double s3_1194 = 0;
B3_1185 = Get(D_905, "body3");
{ V _t1195 = Get(B3_1185, "c");
{ V _t1196 = ListOf(_t1195);
{ V _t1197 = GetIdx(_t1196, 0D);
bx_1186 = _t1197; }
{ V _t1198 = GetIdx(_t1196, 1D);
by_1187 = _t1198; }
{ V _t1199 = GetIdx(_t1196, 2D);
bz_1188 = _t1199; }
} }
{ V _t1200 = Get(B3_1185, "r");
{ V _t1201 = ListOf(_t1200);
{ V _t1202 = GetIdx(_t1201, 0D);
brx_1189 = _t1202; }
{ V _t1203 = GetIdx(_t1201, 1D);
bry_1190 = _t1203; }
{ V _t1204 = GetIdx(_t1201, 2D);
brz_1191 = _t1204; }
} }
t3_1192 = (ToNum((Get(B3_1185, "tilt") is var _t1205 && Truthy(_t1205) ? _t1205 : ((V)(0D)))) * D2R_11);
c3_1193 = FdLibm.Cos(t3_1192);
s3_1194 = FdLibm.Sin(t3_1192);
Call(set_964, V.Undef, Get(E_907, "body"), ((V)("d")), Call(toD_25, V.Undef, Call(ellAx_30, V.Undef, ((V)(((50D + ((ToNum(bx_1186) - 50D) * cyb_925)) + (ToNum(bz_1188) * syb_926)))), by_1187, Arr(Arr(((V)((ToNum(brx_1189) * cyb_925))), ((V)(0D))), Arr(((V)(((ToNum(bry_1190) * s3_1194) * syb_926))), ((V)((ToNum(bry_1190) * c3_1193)))), Arr(((V)(((ToNum(brz_1191) * c3_1193) * syb_926))), ((V)(((-ToNum(brz_1191)) * s3_1194)))))), glob_942));
} else {
if (Truthy(Get(I_902, "furB"))) {
Call(set_964, V.Undef, Get(E_907, "body"), ((V)("d")), ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Call(furPts_24, V.Undef, Get(I_902, "furB"), ((V)(yb_919))), "map", Fn((V _arrowThis1213, int _argc1206, V p_1212, V _a1209, V _a1210, V _a1211, V[] _rest1207) => {
V q_1214 = default;
q_1214 = Call(glob_942, V.Undef, GetIdx(p_1212, 0D), GetIdx(p_1212, 1D));
return ((V)(JsStrBuf.Begin().V(Call(r2_14, V.Undef, GetIdx(q_1214, 0D))).S(" ").V(Call(r2_14, V.Undef, GetIdx(q_1214, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).S("Z").End())));
} else {
Call(set_964, V.Undef, Get(E_907, "body"), ((V)("d")), Call(toD_25, V.Undef, Get(R_906, "body"), glob_942));
}
}
if (Truthy(Get(E_907, "lumps"))) {
double dB_1215 = 0;
dB_1215 = (ToNum((Truthy(Get(D_905, "body3")) ? GetIdx(Get(Get(D_905, "body3"), "c"), 2D) : ((V)(0D)))) * cyb_925);
Invoke(Get(D_905, "lumps"), "forEach", Fn((V _arrowThis1224, int _argc1216, V L_1222, V i_1223, V _a1220, V _a1221, V[] _rest1217) => {
V lx_1225 = default;
V ly_1226 = default;
V lz_1227 = default;
V lrx_1228 = default;
V lry_1229 = default;
V lrz_1230 = default;
V el_1231 = default;
V fr_1232 = default;
{ V _t1233 = Get(L_1222, "c");
{ V _t1234 = ListOf(_t1233);
{ V _t1235 = GetIdx(_t1234, 0D);
lx_1225 = _t1235; }
{ V _t1236 = GetIdx(_t1234, 1D);
ly_1226 = _t1236; }
{ V _t1237 = GetIdx(_t1234, 2D);
lz_1227 = _t1237; }
} }
{ V _t1238 = Get(L_1222, "r");
{ V _t1239 = ListOf(_t1238);
{ V _t1240 = GetIdx(_t1239, 0D);
lrx_1228 = _t1240; }
{ V _t1241 = GetIdx(_t1239, 1D);
lry_1229 = _t1241; }
{ V _t1242 = GetIdx(_t1239, 2D);
lrz_1230 = _t1242; }
} }
el_1231 = GetK(Get(E_907, "lumps"), i_1223);
fr_1232 = (((((-(ToNum(lx_1225) - 50D)) * syb_926) + (ToNum(lz_1227) * cyb_925)) > dB_1215) ? V.True : V.False);
Call(set_964, V.Undef, el_1231, ((V)("d")), Call(toD_25, V.Undef, Call(ellAx_30, V.Undef, ((V)(((50D + ((ToNum(lx_1225) - 50D) * cyb_925)) + (ToNum(lz_1227) * syb_926)))), ly_1226, Arr(Arr(((V)((ToNum(lrx_1228) * cyb_925))), ((V)(0D))), Arr(((V)(0D)), lry_1229), Arr(((V)((ToNum(lrz_1230) * syb_926))), ((V)(0D))))), glob_942));
if (!SEq(fr_1232, Get(el_1231, "__fr"))) {
Set(el_1231, "__fr", fr_1232);
Invoke(Get(el_1231, "parentNode"), "insertBefore", el_1231, (Truthy(fr_1232) ? Get(Get(E_907, "body"), "nextSibling") : Get(E_907, "body")));
}
return default;
}, 2, "", true));
}
if (Truthy(Get(E_907, "neck3"))) {
V N3_1243 = default;
V nx_1244 = default;
V ny_1245 = default;
V nz_1246 = default;
V nrx_1247 = default;
V nry_1248 = default;
V nrz_1249 = default;
N3_1243 = Get(D_905, "neck3");
{ V _t1250 = Get(N3_1243, "c");
{ V _t1251 = ListOf(_t1250);
{ V _t1252 = GetIdx(_t1251, 0D);
nx_1244 = _t1252; }
{ V _t1253 = GetIdx(_t1251, 1D);
ny_1245 = _t1253; }
{ V _t1254 = GetIdx(_t1251, 2D);
nz_1246 = _t1254; }
} }
{ V _t1255 = Get(N3_1243, "r");
{ V _t1256 = ListOf(_t1255);
{ V _t1257 = GetIdx(_t1256, 0D);
nrx_1247 = _t1257; }
{ V _t1258 = GetIdx(_t1256, 1D);
nry_1248 = _t1258; }
{ V _t1259 = GetIdx(_t1256, 2D);
nrz_1249 = _t1259; }
} }
Call(set_964, V.Undef, Get(E_907, "neck3"), ((V)("d")), Call(toD_25, V.Undef, Call(ellAx_30, V.Undef, ((V)(((50D + ((ToNum(nx_1244) - 50D) * cyb_925)) + (ToNum(nz_1246) * syb_926)))), ny_1245, Arr(Arr(((V)((ToNum(nrx_1247) * cyb_925))), ((V)(0D))), Arr(((V)(0D)), nry_1248), Arr(((V)((ToNum(nrz_1249) * syb_926))), ((V)(0D))))), glob_942));
}
pf_965 = Call(clamp_13, V.Undef, Get(P_903, "puff"), ((V)((-0.5))), ((V)(1.2)));
hF_966 = (Truthy(pf_965) ? Fn((V _arrowThis1268, int _argc1260, V x_1266, V y_1267, V _a1264, V _a1265, V[] _rest1261) => {
double dy_1269 = 0;
double g_1270 = 0;
dy_1269 = (ToNum(y_1267) - 58D);
g_1270 = FdLibm.Exp((((-dy_1269) * dy_1269) / 80D));
return Call(headT_948, V.Undef, Add(x_1266, ((V)((((((LtN(x_1266, 50D) ? (-1D) : 1D) * ToNum(pf_965)) * 3.2) * g_1270) * ToNum(Call(clamp_13, V.Undef, ((V)((System.Math.Abs((ToNum(x_1266) - 50D)) / 20D))), ((V)(0D)), ((V)(1D)))))))), y_1267);
return default;
}, 2, "", true) : headT_948);
skD_967 = (Truthy(Get(I_902, "furH")) ? ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Call(furPts_24, V.Undef, Get(I_902, "furH"), ((V)(yh_920))), "map", Fn((V _arrowThis1278, int _argc1271, V p_1277, V _a1274, V _a1275, V _a1276, V[] _rest1272) => {
V q_1279 = default;
q_1279 = Call(hF_966, V.Undef, GetIdx(p_1277, 0D), GetIdx(p_1277, 1D));
return ((V)(JsStrBuf.Begin().V(Call(r2_14, V.Undef, GetIdx(q_1279, 0D))).S(" ").V(Call(r2_14, V.Undef, GetIdx(q_1279, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).S("Z").End())) : Call(toD_25, V.Undef, Get(R_906, "skull"), hF_966));
Call(set_964, V.Undef, Get(E_907, "skull"), ((V)("d")), skD_967);
Call(set_964, V.Undef, Get(E_907, "clip"), ((V)("d")), skD_967);
rd_968 = Call(clamp_13, V.Undef, Get(P_903, "red"), ((V)(0D)), ((V)(1D)));
gr_969 = Call(clamp_13, V.Undef, Get(P_903, "green"), ((V)(0D)), ((V)(1D)));
Call(set_964, V.Undef, Get(E_907, "tintR"), ((V)("d")), skD_967);
Call(set_964, V.Undef, Get(E_907, "tintR"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ToNum(rd_968) * 0.34)))));
Call(set_964, V.Undef, Get(E_907, "tintG"), ((V)("d")), skD_967);
Call(set_964, V.Undef, Get(E_907, "tintG"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ToNum(gr_969) * 0.26)))));
if (GtN(gr_969, 0.01)) {
Call(set_964, V.Undef, Get(E_907, "bodyG"), ((V)("d")), Invoke(Get(E_907, "body"), "getAttribute", ((V)("d"))));
}
Call(set_964, V.Undef, Get(E_907, "bodyG"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ToNum(gr_969) * 0.26)))));
keys_970 = NewObj(4).Put("body", ((V)(0D))).Put("head", ((V)(1D))).Put("collar", ((V)(1.5))).Put("prop", (!Get(I_902, "propZ").IsNullish ? Get(I_902, "propZ") : ((V)(5D)))).V;
Set(I_902, "W", NewObj(0).V);
Invoke(Get(R_906, "feet"), "forEach", Fn((V _arrowThis1288, int _argc1280, V f_1286, V i_1287, V _a1284, V _a1285, V[] _rest1281) => {
V st_1289 = default;
double cy_1290 = 0;
V z_1291 = default;
double X_1292 = 0;
double fsd_1293 = 0;
V FS0_1294 = default;
V FS_1295 = default;
V fd_1296 = default;
V zp_1297 = default;
st_1289 = Call(clamp_13, V.Undef, (((V)(ToNum(Get(P_903, "sit")))) is var _t1298 && Truthy(_t1298) ? _t1298 : ((V)(0D))), ((V)(0D)), ((V)(1D)));
cy_1290 = ((ToNum(Get(f_1286, "y")) - ToNum((Truthy(i_1287) ? Get(P_903, "footR") : Get(P_903, "footL")))) + (ToNum(st_1289) * 4.6));
z_1291 = Add((!Get(D_905, "footZ").IsNullish ? Get(D_905, "footZ") : ((V)(8D))), ((V)((ToNum(st_1289) * 7D))));
X_1292 = ((50D + (((ToNum(Get(f_1286, "x")) - 50D) * (1D + (ToNum(st_1289) * 0.3))) * cyb_925)) + (ToNum(z_1291) * syb_926));
fsd_1293 = (LtN(Get(f_1286, "x"), 50D) ? 1D : (-1D));
if (Truthy(Get(D_905, "web"))) {
V W_1299 = default;
V kk_1300 = default;
double ao_1301 = 0;
double co_1302 = 0;
double so_1303 = 0;
double bx0_1304 = 0;
double d0_1305 = 0;
V mp_1306 = default;
V fd_1307 = default;
W_1299 = Get(D_905, "web");
kk_1300 = (Get(W_1299, "k") is var _t1308 && Truthy(_t1308) ? _t1308 : ((V)(0.32)));
ao_1301 = ((ToNum((Get(W_1299, "out") is var _t1309 && Truthy(_t1309) ? _t1309 : ((V)(0D)))) * D2R_11) * (LtN(Get(f_1286, "x"), 50D) ? (-1D) : 1D));
co_1302 = FdLibm.Cos(ao_1301);
so_1303 = FdLibm.Sin(ao_1301);
bx0_1304 = (50D + ((ToNum(Get(f_1286, "x")) - 50D) * (1D + (ToNum(st_1289) * 0.3))));
d0_1305 = (((-(bx0_1304 - 50D)) * syb_926) + (ToNum(z_1291) * cyb_925));
mp_1306 = Fn((V _arrowThis1318, int _argc1310, V u_1316, V v_1317, V _a1314, V _a1315, V[] _rest1311) => {
double wx_1319 = 0;
double wz_1320 = 0;
wx_1319 = ((bx0_1304 + (ToNum(u_1316) * co_1302)) + (ToNum(v_1317) * so_1303));
wz_1320 = ((ToNum(z_1291) - (ToNum(u_1316) * so_1303)) + (ToNum(v_1317) * co_1302));
return Call(glob_942, V.Undef, ((V)(((50D + ((wx_1319 - 50D) * cyb_925)) + (wz_1320 * syb_926)))), ((V)((cy_1290 + (ToNum(kk_1300) * ((((-(wx_1319 - 50D)) * syb_926) + (wz_1320 * cyb_925)) - d0_1305))))));
return default;
}, 2, "", true);
fd_1307 = Call(toD_25, V.Undef, Get(R_906, "web"), mp_1306);
Call(set_964, V.Undef, Get(GetK(Get(E_907, "feet"), i_1287), "f"), ((V)("d")), fd_1307);
Call(set_964, V.Undef, Get(GetK(Get(E_907, "feet"), i_1287), "clip"), ((V)("d")), fd_1307);
Call(set_964, V.Undef, Get(GetK(Get(E_907, "feet"), i_1287), "p"), ((V)("d")), (Truthy(Get(R_906, "webT")) ? Call(toD_25, V.Undef, Get(R_906, "webT"), mp_1306) : ((V)(""))));
if (Truthy(Get(GetK(Get(E_907, "feet"), i_1287), "leg"))) {
V L_1321 = default;
V h0_1322 = default;
V top_1323 = default;
L_1321 = Get(W_1299, "leg");
h0_1322 = Call(mp_1306, V.Undef, ((V)(0D)), ((V)(0.6)));
top_1323 = Call(glob_942, V.Undef, ((V)(X_1292)), ((V)(Min((cy_1290 - 1D), ToNum(Add(Get(L_1321, "top"), ((V)(((cy_1290 - ToNum(Get(f_1286, "y"))) * 0.4)))))))));
Call(set_964, V.Undef, Get(GetK(Get(E_907, "feet"), i_1287), "leg"), ((V)("d")), ((V)(JsStrBuf.Begin().S("M").V(Call(r2_14, V.Undef, GetIdx(h0_1322, 0D))).S(" ").V(Call(r2_14, V.Undef, GetIdx(h0_1322, 1D))).S(" L").V(Call(r2_14, V.Undef, GetIdx(top_1323, 0D))).S(" ").V(Call(r2_14, V.Undef, GetIdx(top_1323, 1D))).End())));
Call(set_964, V.Undef, Get(GetK(Get(E_907, "feet"), i_1287), "leg"), ((V)("stroke-width")), Call(r2_14, V.Undef, ((V)((ToNum((Get(L_1321, "w") is var _t1324 && Truthy(_t1324) ? _t1324 : ((V)(3D)))) * System.Math.Sqrt(sy_937))))));
}
SetK(keys_970, ((V)((Truthy(i_1287) ? "footR" : "footL"))), Add(((V)(d0_1305)), (!Get(D_905, "footK").IsNullish ? Get(D_905, "footK") : ((V)((-10D))))));
SetK(Get(I_902, "W"), ((V)((Truthy(i_1287) ? "footR" : "footL"))), Call(glob_942, V.Undef, ((V)(X_1292)), ((V)(cy_1290))));
return default;
}
FS0_1294 = (Get(D_905, "footS") is var _t1325 && Truthy(_t1325) ? _t1325 : Arr(((V)(9D)), ((V)(5.5)), ((V)(8D))));
FS_1295 = Arr(((V)((ToNum(GetIdx(FS0_1294, 0D)) * (1D + (ToNum(st_1289) * 0.06))))), ((V)((ToNum(GetIdx(FS0_1294, 1D)) * (1D + (ToNum(st_1289) * 0.75))))), GetIdx(FS0_1294, 2D));
fd_1296 = Call(toD_25, V.Undef, Call(ellAx_30, V.Undef, ((V)(X_1292)), ((V)(cy_1290)), Arr(Arr(((V)((ToNum(GetIdx(FS_1295, 0D)) * cyb_925))), ((V)(0D))), Arr(((V)(((((fsd_1293 * ToNum(st_1289)) * ToNum(GetIdx(FS_1295, 1D))) * 0.28) * cyb_925))), GetIdx(FS_1295, 1D)), Arr(((V)((ToNum(GetIdx(FS_1295, 2D)) * syb_926))), ((V)(0D))))), glob_942);
Call(set_964, V.Undef, Get(GetK(Get(E_907, "feet"), i_1287), "f"), ((V)("d")), fd_1296);
Call(set_964, V.Undef, Get(GetK(Get(E_907, "feet"), i_1287), "clip"), ((V)("d")), fd_1296);
zp_1297 = Add(z_1291, ((V)(7.5)));
Call(set_964, V.Undef, Get(GetK(Get(E_907, "feet"), i_1287), "p"), ((V)("d")), Invoke(Invoke((Get(D_905, "pads") is var _t1342 && Truthy(_t1342) ? _t1342 : Arr(Arr(((V)(0D)), ((V)(1D)), ((V)(5D)), ((V)(2.8))))), "map", Fn((V _arrowThis1341, int _argc1326, V _a1328, V _a1329, V _a1330, V _a1331, V[] _rest1327) => {
V dx_1334 = default;
V dy_1336 = default;
V rx_1338 = default;
V ry_1340 = default;
{ V _t1332 = ListOf(_a1328);
{ V _t1333 = GetIdx(_t1332, 0D);
dx_1334 = _t1333; }
{ V _t1335 = GetIdx(_t1332, 1D);
dy_1336 = _t1335; }
{ V _t1337 = GetIdx(_t1332, 2D);
rx_1338 = _t1337; }
{ V _t1339 = GetIdx(_t1332, 3D);
ry_1340 = _t1339; }
}
return Call(toD_25, V.Undef, Call(ellAx_30, V.Undef, ((V)(((50D + (((ToNum(Add(((V)(((ToNum(Get(f_1286, "x")) * (1D + (ToNum(st_1289) * 0.3))) - (ToNum(st_1289) * 15D)))), dx_1334)) - (((fsd_1293 * ToNum(st_1289)) * ToNum(dy_1336)) * 0.28)) - 50D) * cyb_925)) + (ToNum(zp_1297) * syb_926)))), ((V)(((cy_1290 + (ToNum(dy_1336) * (1D + (ToNum(st_1289) * 0.75)))) - (ToNum(st_1289) * 0.8)))), Arr(Arr(((V)((ToNum(rx_1338) * cyb_925))), ((V)(0D))), Arr(((V)(0D)), ((V)((ToNum(ry_1340) * (1D + (ToNum(st_1289) * 0.6)))))))), glob_942);
}, 1, "", true)), "join", ((V)(" "))));
Call(set_964, V.Undef, Get(GetK(Get(E_907, "feet"), i_1287), "p"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((0.9 * ToNum(Call(SM_16, V.Undef, ((V)((cyb_925 * 3D))))))))));
SetK(keys_970, ((V)((Truthy(i_1287) ? "footR" : "footL"))), Add(((V)((((-(ToNum(Get(f_1286, "x")) - 50D)) * syb_926) + (ToNum(z_1291) * cyb_925)))), (!Get(D_905, "footK").IsNullish ? Get(D_905, "footK") : ((V)((-10D))))));
SetK(Get(I_902, "W"), ((V)((Truthy(i_1287) ? "footR" : "footL"))), Call(glob_942, V.Undef, ((V)(X_1292)), ((V)(cy_1290))));
return default;
}, 2, "", true));
if (Truthy(Get(E_907, "crest"))) {
Invoke(Get(D_905, "crest"), "forEach", Fn((V _arrowThis1351, int _argc1343, V C_1349, V i_1350, V _a1347, V _a1348, V[] _rest1344) => {
double a_1352 = 0;
double ca_1353 = 0;
double sa_1354 = 0;
V u0_1355 = default;
V v0_1356 = default;
double tu_1357 = 0;
double st_1358 = 0;
double ct_1359 = 0;
a_1352 = (((ToNum(Add((Get(P_903, "earL") is var _t1360 && Truthy(_t1360) ? _t1360 : ((V)(0D))), (Get(P_903, "earR") is var _t1361 && Truthy(_t1361) ? _t1361 : ((V)(0D))))) / 2D) * ToNum((!Get(C_1349, "k").IsNullish ? Get(C_1349, "k") : ((V)(1D))))) * D2R_11);
ca_1353 = FdLibm.Cos(a_1352);
sa_1354 = FdLibm.Sin(a_1352);
{ V _t1362 = Get(C_1349, "root");
{ V _t1363 = ListOf(_t1362);
{ V _t1364 = GetIdx(_t1363, 0D);
u0_1355 = _t1364; }
{ V _t1365 = GetIdx(_t1363, 1D);
v0_1356 = _t1365; }
} }
tu_1357 = (ToNum((Get(C_1349, "turn") is var _t1366 && Truthy(_t1366) ? _t1366 : ((V)(0D)))) * D2R_11);
st_1358 = FdLibm.Sin(tu_1357);
ct_1359 = FdLibm.Cos(tu_1357);
Call(set_964, V.Undef, GetK(Get(E_907, "crest"), i_1350), ((V)("d")), Call(toD_25, V.Undef, GetK(Get(R_906, "crest"), i_1350), Fn((V _arrowThis1375, int _argc1367, V u_1373, V v_1374, V _a1371, V _a1372, V[] _rest1368) => {
double du_1376 = 0;
double dv_1377 = 0;
double U_1378 = 0;
V V_1379 = default;
du_1376 = (ToNum(u_1373) - ToNum(u0_1355));
dv_1377 = (ToNum(v_1374) - ToNum(v0_1356));
U_1378 = (ToNum(Add(u0_1355, ((V)((du_1376 * ca_1353))))) - (dv_1377 * sa_1354));
V_1379 = Add(Add(v0_1356, ((V)((du_1376 * sa_1354)))), ((V)((dv_1377 * ca_1353))));
return Call(sph_950, V.Undef, Add(HX_910, ((V)((U_1378 * st_1358)))), V_1379, ((V)(((-U_1378) * ct_1359))));
return default;
}, 2, "", true)));
return default;
}, 2, "", true));
}
Invoke(Get(R_906, "ears"), "forEach", Fn((V _arrowThis1388, int _argc1380, V e_1386, V i_1387, V _a1384, V _a1385, V[] _rest1381) => {
double a_1389 = 0;
V px_1390 = default;
V py_1391 = default;
V S_1392 = default;
V pts_1393 = default;
double lim_1394 = 0;
V zm_1395 = default;
V bend_1396 = default;
V ed_1397 = default;
V hdAt_1398 = default;
V tq_1399 = default;
V tb_1400 = default;
a_1389 = (ToNum((Truthy(Get(e_1386, "flop")) ? ((V)((ToNum((LtN(Get(e_1386, "side"), 0D) ? Get(P_903, "earL") : ((V)((-ToNum(Get(P_903, "earR"))))))) * 0.9))) : (LtN(Get(e_1386, "side"), 0D) ? ((V)((-ToNum(Get(P_903, "earL"))))) : Get(P_903, "earR")))) * D2R_11);
{ V _t1401 = Get(e_1386, "pivot");
{ V _t1402 = ListOf(_t1401);
{ V _t1403 = GetIdx(_t1402, 0D);
px_1390 = _t1403; }
{ V _t1404 = GetIdx(_t1402, 1D);
py_1391 = _t1404; }
} }
S_1392 = Get(e_1386, "S");
pts_1393 = Arr();
lim_1394 = ((ToNum(SR_913) * ToNum(SR_913)) * 0.81);
if (Truthy(Get(e_1386, "lobe"))) {
V lx_1405 = default;
V ly_1406 = default;
V la_1407 = default;
V lb_1408 = default;
V lc_1409 = default;
V lz_1410 = default;
V lr_1411 = default;
double ca_1412 = 0;
double sa_1413 = 0;
double vx_1414 = 0;
double vy_1415 = 0;
double cx_1416 = 0;
V cy_1417 = default;
double rr_1418 = 0;
double cr_1419 = 0;
double sr_1420 = 0;
V pv_1421 = default;
V C_1422 = default;
V ld_1423 = default;
double bk_1424 = 0;
V msh_1425 = default;
{ V _t1426 = Get(e_1386, "lobe");
{ V _t1427 = ListOf(_t1426);
{ V _t1428 = GetIdx(_t1427, 0D);
lx_1405 = _t1428; }
{ V _t1429 = GetIdx(_t1427, 1D);
ly_1406 = _t1429; }
{ V _t1430 = GetIdx(_t1427, 2D);
la_1407 = _t1430; }
{ V _t1431 = GetIdx(_t1427, 3D);
lb_1408 = _t1431; }
{ V _t1432 = GetIdx(_t1427, 4D);
lc_1409 = _t1432; }
{ V _t1433 = GetIdx(_t1427, 5D);
lz_1410 = _t1433; }
{ V _t1434 = GetIdx(_t1427, 6D);
lr_1411 = _t1434; }
} }
ca_1412 = FdLibm.Cos(a_1389);
sa_1413 = FdLibm.Sin(a_1389);
vx_1414 = (ToNum(lx_1405) - ToNum(px_1390));
vy_1415 = (ToNum(ly_1406) - ToNum(py_1391));
cx_1416 = (ToNum(Add(px_1390, ((V)((vx_1414 * ca_1412))))) - (vy_1415 * sa_1413));
cy_1417 = Add(Add(py_1391, ((V)((vx_1414 * sa_1413)))), ((V)((vy_1415 * ca_1412))));
rr_1418 = ((ToNum((lr_1411 is var _t1435 && Truthy(_t1435) ? _t1435 : ((V)(0D)))) * D2R_11) + a_1389);
cr_1419 = FdLibm.Cos(rr_1418);
sr_1420 = FdLibm.Sin(rr_1418);
pv_1421 = Fn((V _arrowThis1445, int _argc1436, V x_1442, V y_1443, V z_1444, V _a1441, V[] _rest1437) => {
double z1_1446 = 0;
z1_1446 = (((-ToNum(x_1442)) * syh_928) + (ToNum(z_1444) * cyh_927));
return Arr(((V)(((ToNum(x_1442) * cyh_927) + (ToNum(z_1444) * syh_928)))), ((V)(((ToNum(y_1443) * cp_929) - ((z1_1446 * sp_930) * KY_916)))));
return default;
}, 3, "", true);
C_1422 = Call(pv_1421, V.Undef, ((V)((cx_1416 - ToNum(HX_910)))), ((V)((ToNum(cy_1417) - ToNum(HY_911)))), (lz_1410 is var _t1447 && Truthy(_t1447) ? _t1447 : ((V)(0D))));
ld_1423 = Call(toD_25, V.Undef, Call(ellAx_30, V.Undef, Add(HX_910, GetIdx(C_1422, 0D)), Add(HY_911, GetIdx(C_1422, 1D)), Arr(Call(pv_1421, V.Undef, ((V)((ToNum(la_1407) * cr_1419))), ((V)((ToNum(la_1407) * sr_1420))), ((V)(0D))), Call(pv_1421, V.Undef, ((V)(((-ToNum(lb_1408)) * sr_1420))), ((V)((ToNum(lb_1408) * cr_1419))), ((V)(0D))), Call(pv_1421, V.Undef, ((V)(0D)), ((V)(0D)), lc_1409))), headT_948);
Call(set_964, V.Undef, Get(GetK(Get(E_907, "ears"), i_1387), "o"), ((V)("d")), ld_1423);
Call(set_964, V.Undef, Get(GetK(Get(E_907, "ears"), i_1387), "clip"), ((V)("d")), ld_1423);
Call(set_964, V.Undef, Get(GetK(Get(E_907, "ears"), i_1387), "n"), ((V)("opacity")), ((V)(0D)));
bk_1424 = (1D - ToNum(Call(SM_16, V.Undef, ((V)(((((-ToNum(Get(e_1386, "side"))) * syh_928) - 0.2) / 0.35))))));
msh_1425 = ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_14, V.Undef, ((V)(((((-ToNum(Get(e_1386, "side"))) * (1D - bk_1424)) * 2D) * ToNum(Add(la_1407, lb_1408))))))).S(" 0)").End()));
Invoke((Get(GetK(Get(E_907, "ears"), i_1387), "mk") is var _t1457 && Truthy(_t1457) ? _t1457 : Arr()), "forEach", Fn((V _arrowThis1456, int _argc1448, V m_1454, V j_1455, V _a1452, V _a1453, V[] _rest1449) => {
Call(set_964, V.Undef, m_1454, ((V)("d")), (Truthy(j_1455) ? Invoke(Get(E_907, "body"), "getAttribute", ((V)("d"))) : skD_967));
Call(set_964, V.Undef, m_1454, ((V)("transform")), msh_1425);
return default;
}, 2, "", true));
SetK(keys_970, ((V)((Truthy(i_1387) ? "earR" : "earL"))), ((V)(2.5)));
SetK(Get(I_902, "W"), ((V)((Truthy(i_1387) ? "earR" : "earL"))), Call(headT_948, V.Undef, Add(HX_910, GetIdx(C_1422, 0D)), Add(Add(HY_911, GetIdx(C_1422, 1D)), ((V)((ToNum(lb_1408) * 0.8))))));
return default;
}
zm_1395 = Fn((V _arrowThis1466, int _argc1458, V x_1464, V y_1465, V _a1462, V _a1463, V[] _rest1459) => {
double dx_1467 = 0;
double dy_1468 = 0;
double q_1469 = 0;
dx_1467 = (ToNum(x_1464) - ToNum(HX_910));
dy_1468 = (ToNum(y_1465) - ToNum(HY_911));
q_1469 = ((1D - ((dx_1467 / ToNum(SR_913)) * (dx_1467 / ToNum(SR_913)))) - ((dy_1468 / ToNum(SRY_915)) * (dy_1468 / ToNum(SRY_915))));
return ((V)((Truthy(Get(e_1386, "flop")) ? ((q_1469 > 0D) ? ((0.12 * ToNum(SR_913)) * System.Math.Sqrt(q_1469)) : 1D) : ((q_1469 > 0D) ? (((-0.35) * ToNum(SR_913)) * System.Math.Sqrt(q_1469)) : 0D))));
return default;
}, 2, "", true);
bend_1396 = Fn((V _arrowThis1479, int _argc1470, V x_1476, V y_1477, V w_1478, V _a1475, V[] _rest1471) => {
double vx_1480 = 0;
double vy_1481 = 0;
double c_1482 = 0;
double s_1483 = 0;
vx_1480 = (ToNum(x_1476) - ToNum(px_1390));
vy_1481 = (ToNum(y_1477) - ToNum(py_1391));
c_1482 = FdLibm.Cos((a_1389 * ToNum(w_1478)));
s_1483 = FdLibm.Sin((a_1389 * ToNum(w_1478)));
return Arr(((V)((ToNum(Add(px_1390, ((V)((vx_1480 * c_1482))))) - (vy_1481 * s_1483)))), Add(Add(py_1391, ((V)((vx_1480 * s_1483)))), ((V)((vy_1481 * c_1482)))));
return default;
}, 3, "", true);
{
foreach (V _k1484 in new JsIter(Get(S_1392, "secs"))) {
V q_1485 = default;
q_1485 = _k1484;
double w_1486 = 0;
double c_1487 = 0;
double s_1488 = 0;
double nx_1489 = 0;
double ny_1490 = 0;
V cx_1491 = default;
V cy_1492 = default;
w_1486 = Pow(ToNum(Get(q_1485, "s")), 1.3);
c_1487 = FdLibm.Cos((a_1389 * w_1486));
s_1488 = FdLibm.Sin((a_1389 * w_1486));
nx_1489 = ((ToNum(Get(S_1392, "nx")) * c_1487) - (ToNum(Get(S_1392, "ny")) * s_1488));
ny_1490 = ((ToNum(Get(S_1392, "nx")) * s_1488) + (ToNum(Get(S_1392, "ny")) * c_1487));
{ V _t1493 = Call(bend_1396, V.Undef, Get(q_1485, "cx"), Get(q_1485, "cy"), ((V)(w_1486)));
{ V _t1494 = ListOf(_t1493);
{ V _t1495 = GetIdx(_t1494, 0D);
cx_1491 = _t1495; }
{ V _t1496 = GetIdx(_t1494, 1D);
cy_1492 = _t1496; }
} }
{
double k_1497 = 0;
k_1497 = 0D;
while (true) {
if (!((k_1497 < 14D))) break;
double f_1499 = 0;
double cf_1500 = 0;
V X_1501 = default;
V Y_1502 = default;
double Z_1503 = 0;
double dx_1504 = 0;
double dy_1505 = 0;
f_1499 = ((k_1497 / 14D) * TAU_12);
cf_1500 = FdLibm.Cos(f_1499);
X_1501 = Add(cx_1491, ((V)(((nx_1489 * ToNum(Get(q_1485, "hw"))) * cf_1500))));
Y_1502 = Add(cy_1492, ((V)(((ny_1490 * ToNum(Get(q_1485, "hw"))) * cf_1500))));
if (!(Truthy(Get(e_1386, "flop")))) {
double wr_1506 = 0;
wr_1506 = (1D - ToNum(Call(SM_16, V.Undef, ((V)(((ToNum(Get(q_1485, "s")) - 0.08) / 0.3))))));
if ((wr_1506 > 0D)) {
double dx0_1507 = 0;
double dy0_1508 = 0;
double rr_1509 = 0;
dx0_1507 = (ToNum(X_1501) - ToNum(HX_910));
dy0_1508 = (ToNum(Y_1502) - ToNum(HY_911));
rr_1509 = Hypot((dx0_1507 / ToNum(SR_913)), (dy0_1508 / ToNum(SRY_915)));
if ((rr_1509 > 0.94)) {
double r1_1510 = 0;
r1_1510 = (0.94 + ((rr_1509 - 0.94) * (1D - wr_1506)));
X_1501 = Add(HX_910, ((V)(((dx0_1507 * r1_1510) / rr_1509))));
Y_1502 = Add(HY_911, ((V)(((dy0_1508 * r1_1510) / rr_1509))));
}
}
}
Z_1503 = ((ToNum(Call(zm_1395, V.Undef, X_1501, Y_1502)) - (ToNum(Get(q_1485, "hd")) * 0.15)) + (ToNum(Get(q_1485, "hd")) * FdLibm.Sin(f_1499)));
dx_1504 = (ToNum(X_1501) - ToNum(HX_910));
dy_1505 = (ToNum(Y_1502) - ToNum(HY_911));
if (Truthy((Get(e_1386, "flop") is var _t1511 && Truthy(_t1511) ? _t1511 : ((((((dx_1504 / ToNum(SR_913)) * (dx_1504 / ToNum(SR_913))) + ((dy_1505 / ToNum(SRY_915)) * (dy_1505 / ToNum(SRY_915)))) + ((Z_1503 / ToNum(SR_913)) * (Z_1503 / ToNum(SR_913)))) >= 0.81) ? V.True : V.False)))) {
Invoke(pts_1393, "push", Call(sph_950, V.Undef, X_1501, Y_1502, ((V)(Z_1503))));
}
k_1497++;
}
}
}
}
ed_1397 = Call(closedD_29, V.Undef, Call(hull_28, V.Undef, pts_1393));
Call(set_964, V.Undef, Get(GetK(Get(E_907, "ears"), i_1387), "o"), ((V)("d")), ed_1397);
Call(set_964, V.Undef, Get(GetK(Get(E_907, "ears"), i_1387), "clip"), ((V)("d")), ed_1397);
hdAt_1398 = Fn((V _arrowThis1519, int _argc1512, V s_1518, V _a1515, V _a1516, V _a1517, V[] _rest1513) => {
V L_1520 = default;
double j_1521 = 0;
V A_1522 = default;
V B_1523 = default;
V u_1524 = default;
L_1520 = Get(S_1392, "secs");
j_1521 = 0D;
while (((j_1521 < (ToNum(Get(L_1520, "length")) - 2D)) && Lt(Get(GetIdx(L_1520, (j_1521 + 1D)), "s"), s_1518))) {
j_1521++;
}
A_1522 = GetIdx(L_1520, j_1521);
B_1523 = (GetIdx(L_1520, (j_1521 + 1D)) is var _t1525 && Truthy(_t1525) ? _t1525 : A_1522);
u_1524 = (Gt(Get(B_1523, "s"), Get(A_1522, "s")) ? Call(clamp_13, V.Undef, ((V)(((ToNum(s_1518) - ToNum(Get(A_1522, "s"))) / (ToNum(Get(B_1523, "s")) - ToNum(Get(A_1522, "s")))))), ((V)(0D)), ((V)(1D))) : ((V)(0D)));
return Call(lerp_15, V.Undef, Get(A_1522, "hd"), Get(B_1523, "hd"), u_1524);
return default;
}, 1, "", true);
if (Truthy(Get(e_1386, "n"))) {
Call(set_964, V.Undef, Get(GetK(Get(E_907, "ears"), i_1387), "n"), ((V)("d")), Call(toD_25, V.Undef, Get(e_1386, "n"), Fn((V _arrowThis1534, int _argc1526, V x_1532, V y_1533, V _a1530, V _a1531, V[] _rest1527) => {
V s_1535 = default;
V hd_1536 = default;
V bx_1537 = default;
V by_1538 = default;
s_1535 = Call(clamp_13, V.Undef, ((V)(((((ToNum(x_1532) - ToNum(px_1390)) * ToNum(Get(e_1386, "ux"))) + ((ToNum(y_1533) - ToNum(py_1391)) * ToNum(Get(e_1386, "uy")))) / ToNum(Get(S_1392, "amax"))))), ((V)(0D)), ((V)(1D)));
hd_1536 = Call(hdAt_1398, V.Undef, s_1535);
{ V _t1539 = Call(bend_1396, V.Undef, x_1532, y_1533, ((V)(Pow(ToNum(s_1535), 1.3))));
{ V _t1540 = ListOf(_t1539);
{ V _t1541 = GetIdx(_t1540, 0D);
bx_1537 = _t1541; }
{ V _t1542 = GetIdx(_t1540, 1D);
by_1538 = _t1542; }
} }
return Call(sph_950, V.Undef, bx_1537, by_1538, ((V)(((ToNum(Call(zm_1395, V.Undef, bx_1537, by_1538)) - (ToNum(hd_1536) * 0.15)) + (ToNum(hd_1536) * 0.85)))));
return default;
}, 2, "", true)));
}
Call(set_964, V.Undef, Get(GetK(Get(E_907, "ears"), i_1387), "n"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((0.8 * ToNum(Call(SM_16, V.Undef, ((V)(((cyh_927 * cp_929) * 3D))))))))));
SetK(keys_970, ((V)((Truthy(i_1387) ? "earR" : "earL"))), (Truthy(Get(e_1386, "behind")) ? ((V)((-99D))) : Add(Call(sphZ_951, V.Undef, px_1390, py_1391, Call(zm_1395, V.Undef, px_1390, py_1391)), ((V)((Truthy(Get(e_1386, "flop")) ? 2.5 : 1D))))));
if (Truthy((Get(D_905, "earK") is var _t1543 && !Truthy(_t1543) ? _t1543 : (!(Truthy(Get(e_1386, "behind"))) ? V.True : V.False)))) {
V k_1544 = default;
double hf_1545 = 0;
k_1544 = Add(GetK(keys_970, ((V)((Truthy(i_1387) ? "earR" : "earL")))), Get(D_905, "earK"));
hf_1545 = (cyh_927 * cp_929);
if (!Get(D_905, "earF").IsNullish) {
if (Truthy(Get(I_902, "eBk"))) {
if (Gt(((V)(hf_1545)), Add(Get(D_905, "earF"), ((V)(0.05))))) {
Set(I_902, "eBk", ((V)(0D)));
}
} else {
if ((hf_1545 < (ToNum(Get(D_905, "earF")) - 0.05))) {
Set(I_902, "eBk", ((V)(1D)));
}
}
}
SetK(keys_970, ((V)((Truthy(i_1387) ? "earR" : "earL"))), ((GtN(k_1544, 1.35) && !(Truthy(Get(I_902, "eBk")))) ? k_1544 : ((V)((-40D)))));
}
tq_1399 = GetIdx(Get(S_1392, "secs"), (ToNum(Get(Get(S_1392, "secs"), "length")) - 1D));
tb_1400 = Call(bend_1396, V.Undef, Get(tq_1399, "cx"), Get(tq_1399, "cy"), ((V)(1D)));
SetK(Get(I_902, "W"), ((V)((Truthy(i_1387) ? "earR" : "earL"))), Call(sph_950, V.Undef, GetIdx(tb_1400, 0D), GetIdx(tb_1400, 1D), ((V)(0D))));
return default;
}, 2, "", true));
if (Truthy(Get(D_905, "wing"))) {
Invoke(Get(R_906, "arms"), "forEach", Fn((V _arrowThis1554, int _argc1546, V a_1552, V i_1553, V _a1550, V _a1551, V[] _rest1547) => {
V WG_1555 = default;
V sd_1556 = default;
V Lf_1557 = default;
V av_1558 = default;
double o_1559 = 0;
double co_1560 = 0;
double so_1561 = 0;
double om_1562 = 0;
double lm_1563 = 0;
double cw_1564 = 0;
double sw_1565 = 0;
double cl_1566 = 0;
double sl_1567 = 0;
V ro_1568 = default;
V ry0_1569 = default;
V rz0_1570 = default;
double xr_1571 = 0;
V rot_1572 = default;
V W3_1573 = default;
V P3_1574 = default;
V Nv_1575 = default;
double nd_1576 = 0;
V C_1577 = default;
double dC_1578 = 0;
V bz0_1579 = default;
WG_1555 = Get(D_905, "wing");
sd_1556 = Get(a_1552, "side");
Lf_1557 = (LtN(sd_1556, 0D) ? V.True : V.False);
av_1558 = Call(clamp_13, V.Undef, ((V)((ToNum((Truthy(Lf_1557) ? Get(P_903, "armL") : Get(P_903, "armR"))) - (ToNum((Truthy(Lf_1557) ? Get(P_903, "hLy") : Get(P_903, "hRy"))) * 2D)))), ((V)((-40D))), ((V)(170D)));
o_1559 = (ToNum((Get(WG_1555, "out") is var _t1580 && Truthy(_t1580) ? _t1580 : ((V)(0D)))) * D2R_11);
co_1560 = FdLibm.Cos(o_1559);
so_1561 = FdLibm.Sin(o_1559);
om_1562 = (ToNum(Add((Get(WG_1555, "rest") is var _t1581 && Truthy(_t1581) ? _t1581 : ((V)(0D))), ((V)(((90D - ToNum((Get(WG_1555, "rest") is var _t1582 && Truthy(_t1582) ? _t1582 : ((V)(0D))))) * ToNum(Call(SM_16, V.Undef, ((V)((ToNum(av_1558) / 60D)))))))))) * D2R_11);
lm_1563 = ((GtN(av_1558, 30D) ? ((ToNum(av_1558) - 30D) * 0.9) : (LtN(av_1558, 0D) ? (ToNum(av_1558) * 0.4) : 0D)) * D2R_11);
cw_1564 = FdLibm.Cos(om_1562);
sw_1565 = FdLibm.Sin(om_1562);
cl_1566 = FdLibm.Cos(lm_1563);
sl_1567 = FdLibm.Sin(lm_1563);
{ V _t1583 = Get(WG_1555, "root");
{ V _t1584 = ListOf(_t1583);
{ V _t1585 = GetIdx(_t1584, 0D);
ro_1568 = _t1585; }
{ V _t1586 = GetIdx(_t1584, 1D);
ry0_1569 = _t1586; }
{ V _t1587 = GetIdx(_t1584, 2D);
rz0_1570 = _t1587; }
} }
xr_1571 = ((50D + (ToNum(sd_1556) * ToNum(ro_1568))) + (ToNum((Truthy(Lf_1557) ? Get(P_903, "hLx") : ((V)((-ToNum(Get(P_903, "hRx"))))))) * 0.3));
rot_1572 = Fn((V _arrowThis1597, int _argc1588, V x0_1594, V y0_1595, V z0_1596, V _a1593, V[] _rest1589) => {
double x1_1598 = 0;
double z1_1599 = 0;
x1_1598 = ((ToNum(x0_1594) * cw_1564) - ((ToNum(sd_1556) * ToNum(z0_1596)) * sw_1565));
z1_1599 = (((ToNum(sd_1556) * ToNum(x0_1594)) * sw_1565) + (ToNum(z0_1596) * cw_1564));
return Arr(((V)(((x1_1598 * cl_1566) + ((ToNum(sd_1556) * ToNum(y0_1595)) * sl_1567)))), ((V)(((((-ToNum(sd_1556)) * x1_1598) * sl_1567) + (ToNum(y0_1595) * cl_1566)))), ((V)(z1_1599)));
return default;
}, 3, "", true);
W3_1573 = Fn((V _arrowThis1609, int _argc1600, V A_1606, V B_1607, V bu_1608, V _a1605, V[] _rest1601) => {
V x_1610 = default;
V y_1611 = default;
V z_1612 = default;
{ V _t1613 = Call(rot_1572, V.Undef, ((V)((ToNum(sd_1556) * ((ToNum(B_1607) * so_1561) + (ToNum(bu_1608) * co_1560))))), ((V)(((ToNum(B_1607) * co_1560) - (ToNum(bu_1608) * so_1561)))), ((V)((-ToNum(A_1606)))));
{ V _t1614 = ListOf(_t1613);
{ V _t1615 = GetIdx(_t1614, 0D);
x_1610 = _t1615; }
{ V _t1616 = GetIdx(_t1614, 1D);
y_1611 = _t1616; }
{ V _t1617 = GetIdx(_t1614, 2D);
z_1612 = _t1617; }
} }
return Arr(Add(((V)(xr_1571)), x_1610), Add(ry0_1569, y_1611), Add(rz0_1570, z_1612));
return default;
}, 3, "", true);
P3_1574 = Fn((V _arrowThis1626, int _argc1618, V A_1624, V B_1625, V _a1622, V _a1623, V[] _rest1619) => {
V x_1627 = default;
V y_1628 = default;
V z_1629 = default;
{ V _t1630 = Call(W3_1573, V.Undef, A_1624, B_1625, ((V)((ToNum((Get(WG_1555, "bulge") is var _t1631 && Truthy(_t1631) ? _t1631 : ((V)(0D)))) * Max(0D, ((1D - Pow(((ToNum(A_1624) - 10D) / 12D), 2D)) - Pow(((ToNum(B_1625) - 3D) / 7D), 2D)))))));
{ V _t1632 = ListOf(_t1630);
{ V _t1633 = GetIdx(_t1632, 0D);
x_1627 = _t1633; }
{ V _t1634 = GetIdx(_t1632, 1D);
y_1628 = _t1634; }
{ V _t1635 = GetIdx(_t1632, 2D);
z_1629 = _t1635; }
} }
return Call(glob_942, V.Undef, ((V)(((50D + ((ToNum(x_1627) - 50D) * cya_922)) + (ToNum(z_1629) * sya_923)))), y_1628);
return default;
}, 2, "", true);
Nv_1575 = Call(rot_1572, V.Undef, ((V)((ToNum(sd_1556) * co_1560))), ((V)((-so_1561))), ((V)(0D)));
nd_1576 = (((-ToNum(GetIdx(Nv_1575, 0D))) * sya_923) + (ToNum(GetIdx(Nv_1575, 2D)) * cya_922));
C_1577 = Call(W3_1573, V.Undef, ((V)(10D)), ((V)(3D)), ((V)(0D)));
dC_1578 = (((-(ToNum(GetIdx(C_1577, 0D)) - 50D)) * sya_923) + (ToNum(GetIdx(C_1577, 2D)) * cya_922));
bz0_1579 = (Truthy(Get(D_905, "body3")) ? GetIdx(Get(Get(D_905, "body3"), "c"), 2D) : ((V)(0D)));
Call(set_964, V.Undef, GetK(Get(E_907, "arms"), i_1553), ((V)("d")), Call(toD_25, V.Undef, Get(R_906, "wing"), P3_1574));
if (Truthy(Get(E_907, "wingF"))) {
Call(set_964, V.Undef, GetK(Get(E_907, "wingF"), i_1553), ((V)("d")), Call(toD_25, V.Undef, Get(R_906, "wingF"), P3_1574));
Call(set_964, V.Undef, GetK(Get(E_907, "wingF"), i_1553), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((0.8 * ToNum(Call(SM_16, V.Undef, ((V)(((System.Math.Abs(nd_1576) * 3D) - 0.3))))))))));
}
Call(set_964, V.Undef, GetK(Get(E_907, "armT"), i_1553), ((V)("opacity")), ((V)(0D)));
SetK(keys_970, ((V)((Truthy(i_1553) ? "armR" : "armL"))), ((V)((dC_1578 - (ToNum(bz0_1579) * cya_922)))));
SetK(Get(I_902, "W"), ((V)((Truthy(Lf_1557) ? "pawL" : "pawR"))), Call(P3_1574, V.Undef, ((V)(19D)), ((V)(4D))));
return default;
}, 2, "", true));
} else {
Invoke(Get(R_906, "arms"), "forEach", Fn((V _arrowThis1644, int _argc1636, V a_1642, V i_1643, V _a1640, V _a1641, V[] _rest1637) => {
V Lf_1645 = default;
V av_1646 = default;
double @base_1647 = 0;
V wr_1648 = default;
double ang_1649 = 0;
double c_1650 = 0;
double s_1651 = 0;
V px_1652 = default;
V py_1653 = default;
double vx_1654 = 0;
double vy_1655 = 0;
V mhx_1656 = default;
V mhy_1657 = default;
V hy_1658 = default;
V hz_1659 = default;
V cx_1660 = default;
V cy_1661 = default;
V z_1662 = default;
double sx_1663 = 0;
V sy0_1664 = default;
double ddx_1665 = 0;
double ddy_1666 = 0;
double len_1667 = 0;
double r0_1668 = 0;
double c0_1669 = 0;
double s0_1670 = 0;
V ax_1671 = default;
double PX_1672 = 0;
V Sw_1673 = default;
V Pw_1674 = default;
double mx_1675 = 0;
double my_1676 = 0;
double tx_1677 = 0;
double ty_1678 = 0;
V tl_1679 = default;
double nx_1680 = 0;
double ny_1681 = 0;
double bu_1682 = 0;
Lf_1645 = (LtN(Get(a_1642, "side"), 0D) ? V.True : V.False);
av_1646 = (Truthy(Lf_1645) ? Get(P_903, "armL") : Get(P_903, "armR"));
@base_1647 = (Truthy(Lf_1645) ? 20D : (-20D));
wr_1648 = Call(SM_16, V.Undef, ((V)((System.Math.Abs(ToNum(av_1646)) / 45D))));
ang_1649 = (ToNum(Add((Truthy(Lf_1645) ? Get(P_903, "armL") : ((V)((-ToNum(Get(P_903, "armR")))))), ((V)(((@base_1647 - ToNum(GetIdx(Get(a_1642, "e"), 4D))) * ToNum(wr_1648)))))) * D2R_11);
c_1650 = FdLibm.Cos(ang_1649);
s_1651 = FdLibm.Sin(ang_1649);
{ V _t1683 = Get(a_1642, "pivot");
{ V _t1684 = ListOf(_t1683);
{ V _t1685 = GetIdx(_t1684, 0D);
px_1652 = _t1685; }
{ V _t1686 = GetIdx(_t1684, 1D);
py_1653 = _t1686; }
} }
vx_1654 = (ToNum(GetIdx(Get(a_1642, "e"), 0D)) - ToNum(px_1652));
vy_1655 = (ToNum(GetIdx(Get(a_1642, "e"), 1D)) - ToNum(py_1653));
{ V _t1687 = (Truthy(Get(I_902, "mapHand")) ? Invoke(I_902, "mapHand", (Truthy(Lf_1645) ? Get(P_903, "hLx") : ((V)((-ToNum(Get(P_903, "hRx")))))), (Truthy(Lf_1645) ? Get(P_903, "hLy") : Get(P_903, "hRy"))) : Arr(((V)((ToNum((Truthy(Lf_1645) ? Get(P_903, "hLx") : ((V)((-ToNum(Get(P_903, "hRx"))))))) * ToNum((Get(I_902, "hkx") is var _t1688 && Truthy(_t1688) ? _t1688 : ((V)(1D))))))), (Truthy(Lf_1645) ? Get(P_903, "hLy") : Get(P_903, "hRy"))));
{ V _t1689 = ListOf(_t1687);
{ V _t1690 = GetIdx(_t1689, 0D);
mhx_1656 = _t1690; }
{ V _t1691 = GetIdx(_t1689, 1D);
mhy_1657 = _t1691; }
} }
hy_1658 = mhy_1657;
hz_1659 = (Truthy(Lf_1645) ? Get(P_903, "hLz") : Get(P_903, "hRz"));
cx_1660 = Add(Add(Add(((V)((ToNum(Add(px_1652, ((V)((vx_1654 * c_1650))))) - (vy_1655 * s_1651)))), (Truthy(Lf_1645) ? mhx_1656 : ((V)((-ToNum(mhx_1656)))))), ((V)((ToNum((Get(I_902, "ed") is var _t1692 && Truthy(_t1692) ? _t1692 : ((V)(0D)))) * 0.35)))), ((V)((Truthy(Get(I_902, "mapHand")) ? ((ToNum(Get(a_1642, "side")) * 7D) * ToNum(wr_1648)) : 0D))));
cy_1661 = Add(Add(Add(py_1653, ((V)((vx_1654 * s_1651)))), ((V)((vy_1655 * c_1650)))), hy_1658);
z_1662 = Add(Add((!Get(D_905, "armZ").IsNullish ? Get(D_905, "armZ") : ((V)(9D))), hz_1659), ((V)((Max(0D, (-ToNum(hy_1658))) * 0.25))));
sx_1663 = (ToNum(px_1652) - (ToNum(Get(a_1642, "side")) * 1.2));
sy0_1664 = Add(py_1653, ((V)(1.5)));
ddx_1665 = (ToNum(cx_1660) - sx_1663);
ddy_1666 = (ToNum(cy_1661) - ToNum(sy0_1664));
len_1667 = Hypot(ddx_1665, ddy_1666);
r0_1668 = ((ToNum(GetIdx(Get(a_1642, "e"), 4D)) * D2R_11) + ang_1649);
if ((len_1667 > 9D)) {
double want_1693 = 0;
double df_1694 = 0;
want_1693 = (FdLibm.Atan2(ddy_1666, ddx_1665) - (System.Math.PI / 2D));
df_1694 = (want_1693 - r0_1668);
df_1694 = ((((df_1694 % TAU_12) + (TAU_12 * 1.5)) % TAU_12) - System.Math.PI);
r0_1668 = (r0_1668 + (df_1694 * ToNum(Call(SM_16, V.Undef, ((V)(((len_1667 - 9D) / 8D)))))));
}
c0_1669 = FdLibm.Cos(r0_1668);
s0_1670 = FdLibm.Sin(r0_1668);
ax_1671 = Invoke(Arr(Arr(((V)((ToNum(GetIdx(Get(a_1642, "e"), 2D)) * c0_1669))), ((V)((ToNum(GetIdx(Get(a_1642, "e"), 2D)) * s0_1670))), ((V)(0D))), Arr(((V)(((-ToNum(GetIdx(Get(a_1642, "e"), 3D))) * s0_1670))), ((V)((ToNum(GetIdx(Get(a_1642, "e"), 3D)) * c0_1669))), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), (Get(D_905, "armD") is var _t1709 && Truthy(_t1709) ? _t1709 : ((V)(6.5))))), "map", Fn((V _arrowThis1708, int _argc1695, V _a1697, V _a1698, V _a1699, V _a1700, V[] _rest1696) => {
V x_1703 = default;
V y_1705 = default;
V zz_1707 = default;
{ V _t1701 = ListOf(_a1697);
{ V _t1702 = GetIdx(_t1701, 0D);
x_1703 = _t1702; }
{ V _t1704 = GetIdx(_t1701, 1D);
y_1705 = _t1704; }
{ V _t1706 = GetIdx(_t1701, 2D);
zz_1707 = _t1706; }
}
return Arr(((V)(((ToNum(x_1703) * cya_922) + (ToNum(zz_1707) * sya_923)))), y_1705);
}, 1, "", true));
PX_1672 = ((50D + ((ToNum(cx_1660) - 50D) * cya_922)) + (ToNum(z_1662) * sya_923));
Call(set_964, V.Undef, GetK(Get(E_907, "arms"), i_1643), ((V)("d")), Call(toD_25, V.Undef, Call(ellAx_30, V.Undef, ((V)(PX_1672)), cy_1661, ax_1671), glob_942));
SetK(keys_970, ((V)((Truthy(i_1643) ? "armR" : "armL"))), ((V)((((-(ToNum(cx_1660) - 50D)) * sya_923) + (ToNum(z_1662) * cya_922)))));
if (!Get(D_905, "armCut").IsNullish) {
double rf_1710 = 0;
V ab_1711 = default;
rf_1710 = (((-(ToNum(GetIdx(Get(a_1642, "e"), 0D)) - 50D)) * sya_923) + (ToNum((!Get(D_905, "armZ").IsNullish ? Get(D_905, "armZ") : ((V)(9D)))) * cya_922));
ab_1711 = (Get(I_902, "aBk") is var _t1712 && Truthy(_t1712) ? _t1712 : Set(I_902, "aBk", Arr(((V)(0D)), ((V)(0D)))));
if (Truthy(GetK(ab_1711, i_1643))) {
if (Gt(((V)(rf_1710)), Add(Get(D_905, "armCut"), ((V)(0.6))))) {
SetK(ab_1711, i_1643, ((V)(0D)));
}
} else {
if ((rf_1710 < (ToNum(Get(D_905, "armCut")) - 0.6))) {
SetK(ab_1711, i_1643, ((V)(1D)));
}
}
if (Truthy(GetK(ab_1711, i_1643))) {
SetK(keys_970, ((V)((Truthy(i_1643) ? "armR" : "armL"))), ((V)(Min(ToNum(GetK(keys_970, ((V)((Truthy(i_1643) ? "armR" : "armL"))))), 0.3))));
}
}
Sw_1673 = Call(glob_942, V.Undef, ((V)(((50D + ((sx_1663 - 50D) * cya_922)) + (4D * sya_923)))), sy0_1664);
Pw_1674 = Call(glob_942, V.Undef, ((V)(PX_1672)), cy_1661);
mx_1675 = (ToNum(Add(GetIdx(Sw_1673, 0D), GetIdx(Pw_1674, 0D))) / 2D);
my_1676 = (ToNum(Add(GetIdx(Sw_1673, 1D), GetIdx(Pw_1674, 1D))) / 2D);
tx_1677 = (ToNum(GetIdx(Pw_1674, 0D)) - ToNum(GetIdx(Sw_1673, 0D)));
ty_1678 = (ToNum(GetIdx(Pw_1674, 1D)) - ToNum(GetIdx(Sw_1673, 1D)));
tl_1679 = (((V)(Hypot(tx_1677, ty_1678))) is var _t1713 && Truthy(_t1713) ? _t1713 : ((V)(1D)));
nx_1680 = ((-ty_1678) / ToNum(tl_1679));
ny_1681 = (tx_1677 / ToNum(tl_1679));
if (((nx_1680 * ToNum(Get(a_1642, "side"))) < 0D)) {
nx_1680 = (-nx_1680);
ny_1681 = (-ny_1681);
}
bu_1682 = (Max(0D, (ToNum(tl_1679) - 10D)) * 0.18);
Call(set_964, V.Undef, GetK(Get(E_907, "armT"), i_1643), ((V)("d")), ((V)(JsStrBuf.Begin().S("M").V(Call(r2_14, V.Undef, GetIdx(Sw_1673, 0D))).S(" ").V(Call(r2_14, V.Undef, GetIdx(Sw_1673, 1D))).S(" Q").V(Call(r2_14, V.Undef, ((V)((mx_1675 + (nx_1680 * bu_1682)))))).S(" ").V(Call(r2_14, V.Undef, ((V)((my_1676 + (ny_1681 * bu_1682)))))).S(" ").V(Call(r2_14, V.Undef, GetIdx(Pw_1674, 0D))).S(" ").V(Call(r2_14, V.Undef, GetIdx(Pw_1674, 1D))).End())));
Call(set_964, V.Undef, GetK(Get(E_907, "armT"), i_1643), ((V)("stroke-width")), Call(r2_14, V.Undef, ((V)((9.5 * System.Math.Sqrt(((1D + (ToNum(sq_936) * 0.4)) * sy_937)))))));
Call(set_964, V.Undef, GetK(Get(E_907, "armT"), i_1643), ((V)("opacity")), Call(r2_14, V.Undef, Call(SM_16, V.Undef, ((V)(((len_1667 - 7.5) / 5D))))));
SetK(Get(I_902, "W"), ((V)((Truthy(Lf_1645) ? "pawL" : "pawR"))), Pw_1674);
return default;
}, 2, "", true));
}
{
V b_1714 = default;
double wa_1715 = 0;
double cu_1716 = 0;
double dnk_1717 = 0;
V T3_1718 = default;
V sp3_1719 = default;
double tw_1720 = 0;
b_1714 = GetIdx(Get(R_906, "tail"), 0D);
wa_1715 = (ToNum(Get(P_903, "wag")) * D2R_11);
cu_1716 = ((ToNum(Get(P_903, "curl")) * 40D) * D2R_11);
dnk_1717 = ((SEqS(Get(I_902, "key"), "mittens") || SEqS(Get(I_902, "key"), "duchess")) ? (ToNum(Call(clamp_13, V.Undef, ((V)((ToNum((Get(P_903, "wd") is var _t1721 && Truthy(_t1721) ? _t1721 : ((V)(0D)))) * 1.6))), ((V)(0D)), ((V)(1D)))) * 1.4) : 0D);
T3_1718 = (!(!(Truthy(Get(D_905, "tail3")))) ? V.True : V.False);
sp3_1719 = Invoke(Get(R_906, "tail"), "map", Fn((V _arrowThis1737, int _argc1722, V _a1724, V _a1725, V _a1726, V _a1727, V[] _rest1723) => {
double th_1738 = 0;
double c_1739 = 0;
double sn_1740 = 0;
double vx_1741 = 0;
double vy_1742 = 0;
double X_1743 = 0;
V Y_1744 = default;
V Z_1745 = default;
V x_1730 = default;
V y_1732 = default;
V s_1734 = default;
V z_1736 = default;
{ V _t1728 = ListOf(_a1724);
{ V _t1729 = GetIdx(_t1728, 0D);
x_1730 = _t1729; }
{ V _t1731 = GetIdx(_t1728, 1D);
y_1732 = _t1731; }
{ V _t1733 = GetIdx(_t1728, 2D);
s_1734 = _t1733; }
{ V _t1735 = GetIdx(_t1728, 3D);
z_1736 = _t1735; }
}
th_1738 = ((((Truthy(T3_1718) ? (wa_1715 * 0.3) : wa_1715) * Pow(ToNum(s_1734), 1.2)) - (cu_1716 * Pow(ToNum(s_1734), 1.6))) + (dnk_1717 * Pow(ToNum(s_1734), 1.1)));
c_1739 = FdLibm.Cos(th_1738);
sn_1740 = FdLibm.Sin(th_1738);
vx_1741 = (ToNum(x_1730) - ToNum(GetIdx(b_1714, 0D)));
vy_1742 = (ToNum(y_1732) - ToNum(GetIdx(b_1714, 1D)));
X_1743 = (ToNum(Add(GetIdx(b_1714, 0D), ((V)((vx_1741 * c_1739))))) - (vy_1742 * sn_1740));
Y_1744 = Add(Add(GetIdx(b_1714, 1D), ((V)((vx_1741 * sn_1740)))), ((V)((vy_1742 * c_1739))));
Z_1745 = z_1736;
if (Truthy(T3_1718)) {
double ty_1746 = 0;
double cw_1747 = 0;
double sw_1748 = 0;
double ux_1749 = 0;
double uz_1750 = 0;
ty_1746 = ((wa_1715 * ToNum((Get(D_905, "tailWag") is var _t1751 && Truthy(_t1751) ? _t1751 : ((V)(1.3))))) * Pow(ToNum(s_1734), 1.1));
cw_1747 = FdLibm.Cos(ty_1746);
sw_1748 = FdLibm.Sin(ty_1746);
ux_1749 = (X_1743 - ToNum(GetIdx(b_1714, 0D)));
uz_1750 = (ToNum(Z_1745) - ToNum(GetIdx(b_1714, 3D)));
X_1743 = (ToNum(Add(GetIdx(b_1714, 0D), ((V)((ux_1749 * cw_1747))))) - (uz_1750 * sw_1748));
Z_1745 = Add(Add(GetIdx(b_1714, 3D), ((V)((ux_1749 * sw_1748)))), ((V)((uz_1750 * cw_1747))));
}
return Call(byw_962, V.Undef, ((V)(X_1743)), Y_1744, Z_1745);
return default;
}, 1, "", true));
tw_1720 = (ToNum((Get(D_905, "tailK") is var _t1752 && Truthy(_t1752) ? _t1752 : ((V)(7D)))) * System.Math.Sqrt(((1D + (ToNum(sq_936) * 0.5)) * sy_937)));
Call(set_964, V.Undef, Get(E_907, "tail"), ((V)("d")), Call(smoothD_26, V.Undef, sp3_1719));
Call(set_964, V.Undef, Get(E_907, "tail"), ((V)("stroke-width")), Call(r2_14, V.Undef, ((V)(((tw_1720 * ToNum((Get(D_905, "tailW") is var _t1753 && Truthy(_t1753) ? _t1753 : ((V)(7D))))) / 7D)))));
Call(set_964, V.Undef, Get(E_907, "tailH"), ((V)("d")), Call(smoothD_26, V.Undef, Invoke(Invoke(sp3_1719, "slice", ((V)(0D)), ((V)((-1D)))), "map", Fn((V _arrowThis1761, int _argc1754, V p_1760, V _a1757, V _a1758, V _a1759, V[] _rest1755) => {
return Arr(((V)((ToNum(GetIdx(p_1760, 0D)) - (tw_1720 * 0.16)))), ((V)((ToNum(GetIdx(p_1760, 1D)) - (tw_1720 * 0.18)))));
}, 1, "", true))));
Call(set_964, V.Undef, Get(E_907, "tailH"), ((V)("stroke-width")), Call(r2_14, V.Undef, ((V)((((tw_1720 * ToNum((Get(D_905, "tailW") is var _t1762 && Truthy(_t1762) ? _t1762 : ((V)(7D))))) / 7D) * ToNum((Get(D_905, "tailHLW") is var _t1763 && Truthy(_t1763) ? _t1763 : ((V)(0.3)))))))));
if (Truthy(Get(E_907, "tailF"))) {
V wb_1764 = default;
V wt_1765 = default;
V n_1766 = default;
V hwAt_1767 = default;
V NR_1768 = default;
double dn_1769 = 0;
V L_1770 = default;
V Rr_1771 = default;
V tp_1772 = default;
V tq_1773 = default;
double ux_1774 = 0;
double uy_1775 = 0;
V ul_1776 = default;
V hT_1777 = default;
V cap_1778 = default;
V s0_1779 = default;
V s1_1780 = default;
double vx0_1781 = 0;
double vy0_1782 = 0;
V vl0_1783 = default;
V h0_1784 = default;
double nx0_1785 = 0;
double ny0_1786 = 0;
V @base_1787 = default;
V fd_1788 = default;
V mid_1789 = default;
V Rx_1790 = default;
{ V _t1791 = Get(D_905, "tailTaper");
{ V _t1792 = ListOf(_t1791);
{ V _t1793 = GetIdx(_t1792, 0D);
wb_1764 = _t1793; }
{ V _t1794 = GetIdx(_t1792, 1D);
wt_1765 = _t1794; }
} }
n_1766 = Get(sp3_1719, "length");
hwAt_1767 = Fn((V _arrowThis1802, int _argc1795, V i_1801, V _a1798, V _a1799, V _a1800, V[] _rest1796) => {
return ((V)(((tw_1720 * ToNum(Add(wb_1764, ((V)(((ToNum(wt_1765) - ToNum(wb_1764)) * Pow((ToNum(i_1801) / (ToNum(n_1766) - 1D)), 0.85))))))) * (1D + (0.14 * (1D - ToNum(Call(SM_16, V.Undef, ((V)(((ToNum(i_1801) / (ToNum(n_1766) - 1D)) / 0.3)))))))))));
}, 1, "", true);
NR_1768 = Invoke(sp3_1719, "map", Fn((V _arrowThis1811, int _argc1803, V p_1809, V i_1810, V _a1807, V _a1808, V[] _rest1804) => {
V a_1812 = default;
V b_1813 = default;
double dx_1814 = 0;
double dy_1815 = 0;
V l_1816 = default;
a_1812 = GetIdx(sp3_1719, Max(0D, (ToNum(i_1810) - 1D)));
b_1813 = GetIdx(sp3_1719, Min((ToNum(n_1766) - 1D), ToNum(Add(i_1810, ((V)(1D))))));
dx_1814 = (ToNum(GetIdx(b_1813, 0D)) - ToNum(GetIdx(a_1812, 0D)));
dy_1815 = (ToNum(GetIdx(b_1813, 1D)) - ToNum(GetIdx(a_1812, 1D)));
l_1816 = (((V)(Hypot(dx_1814, dy_1815))) is var _t1817 && Truthy(_t1817) ? _t1817 : ((V)(1D)));
return Arr(((V)(((-dy_1815) / ToNum(l_1816)))), ((V)((dx_1814 / ToNum(l_1816)))));
return default;
}, 2, "", true));
dn_1769 = (GeN(Invoke(NR_1768, "reduce", Fn((V _arrowThis1826, int _argc1818, V q_1824, V v_1825, V _a1822, V _a1823, V[] _rest1819) => {
return Add(q_1824, GetIdx(v_1825, 1D));
}, 2, "", true), ((V)(0D))), 0D) ? 1D : (-1D));
L_1770 = Invoke(sp3_1719, "map", Fn((V _arrowThis1835, int _argc1827, V p_1833, V i_1834, V _a1831, V _a1832, V[] _rest1828) => {
return Arr(((V)((ToNum(GetIdx(p_1833, 0D)) - ((ToNum(GetIdx(GetK(NR_1768, i_1834), 0D)) * ToNum(Call(hwAt_1767, V.Undef, i_1834))) * dn_1769)))), ((V)((ToNum(GetIdx(p_1833, 1D)) - ((ToNum(GetIdx(GetK(NR_1768, i_1834), 1D)) * ToNum(Call(hwAt_1767, V.Undef, i_1834))) * dn_1769)))));
}, 2, "", true));
Rr_1771 = Invoke(sp3_1719, "map", Fn((V _arrowThis1844, int _argc1836, V p_1842, V i_1843, V _a1840, V _a1841, V[] _rest1837) => {
return Arr(Add(GetIdx(p_1842, 0D), ((V)(((ToNum(GetIdx(GetK(NR_1768, i_1843), 0D)) * ToNum(Call(hwAt_1767, V.Undef, i_1843))) * dn_1769)))), Add(GetIdx(p_1842, 1D), ((V)(((ToNum(GetIdx(GetK(NR_1768, i_1843), 1D)) * ToNum(Call(hwAt_1767, V.Undef, i_1843))) * dn_1769)))));
}, 2, "", true));
tp_1772 = GetIdx(sp3_1719, (ToNum(n_1766) - 1D));
tq_1773 = GetIdx(sp3_1719, (ToNum(n_1766) - 2D));
ux_1774 = (ToNum(GetIdx(tp_1772, 0D)) - ToNum(GetIdx(tq_1773, 0D)));
uy_1775 = (ToNum(GetIdx(tp_1772, 1D)) - ToNum(GetIdx(tq_1773, 1D)));
ul_1776 = (((V)(Hypot(ux_1774, uy_1775))) is var _t1845 && Truthy(_t1845) ? _t1845 : ((V)(1D)));
hT_1777 = Call(hwAt_1767, V.Undef, ((V)((ToNum(n_1766) - 1D))));
cap_1778 = Invoke(Arr(((V)(0.25)), ((V)(0.5)), ((V)(0.75))), "map", Fn((V _arrowThis1853, int _argc1846, V f_1852, V _a1849, V _a1850, V _a1851, V[] _rest1847) => {
double t_1854 = 0;
double nx_1855 = 0;
double ny_1856 = 0;
t_1854 = (ToNum(f_1852) * System.Math.PI);
nx_1855 = (ToNum(GetIdx(GetIdx(NR_1768, (ToNum(n_1766) - 1D)), 0D)) * dn_1769);
ny_1856 = (ToNum(GetIdx(GetIdx(NR_1768, (ToNum(n_1766) - 1D)), 1D)) * dn_1769);
return Arr(Add(GetIdx(tp_1772, 0D), ((V)(((((ux_1774 / ToNum(ul_1776)) * FdLibm.Sin(t_1854)) - (nx_1855 * FdLibm.Cos(t_1854))) * ToNum(hT_1777))))), Add(GetIdx(tp_1772, 1D), ((V)(((((uy_1775 / ToNum(ul_1776)) * FdLibm.Sin(t_1854)) - (ny_1856 * FdLibm.Cos(t_1854))) * ToNum(hT_1777))))));
return default;
}, 1, "", true));
s0_1779 = GetIdx(sp3_1719, 0D);
s1_1780 = GetIdx(sp3_1719, 2D);
vx0_1781 = (ToNum(GetIdx(s1_1780, 0D)) - ToNum(GetIdx(s0_1779, 0D)));
vy0_1782 = (ToNum(GetIdx(s1_1780, 1D)) - ToNum(GetIdx(s0_1779, 1D)));
vl0_1783 = (((V)(Hypot(vx0_1781, vy0_1782))) is var _t1857 && Truthy(_t1857) ? _t1857 : ((V)(1D)));
h0_1784 = Call(hwAt_1767, V.Undef, ((V)(0D)));
nx0_1785 = (ToNum(GetIdx(GetIdx(NR_1768, 0D), 0D)) * dn_1769);
ny0_1786 = (ToNum(GetIdx(GetIdx(NR_1768, 0D), 1D)) * dn_1769);
@base_1787 = Invoke(Arr(((V)(0.2)), ((V)(0.4)), ((V)(0.6)), ((V)(0.8))), "map", Fn((V _arrowThis1865, int _argc1858, V f_1864, V _a1861, V _a1862, V _a1863, V[] _rest1859) => {
double t_1866 = 0;
t_1866 = (ToNum(f_1864) * System.Math.PI);
return Arr(Add(GetIdx(s0_1779, 0D), ((V)((((nx0_1785 * FdLibm.Cos(t_1866)) - (((vx0_1781 / ToNum(vl0_1783)) * FdLibm.Sin(t_1866)) * 0.55)) * ToNum(h0_1784))))), Add(GetIdx(s0_1779, 1D), ((V)((((ny0_1786 * FdLibm.Cos(t_1866)) - (((vy0_1782 / ToNum(vl0_1783)) * FdLibm.Sin(t_1866)) * 0.55)) * ToNum(h0_1784))))));
return default;
}, 1, "", true));
fd_1788 = Call(closedD_29, V.Undef, Invoke(L_1770, "concat", cap_1778, Invoke(Invoke(Rr_1771, "slice"), "reverse"), @base_1787));
Call(set_964, V.Undef, Get(E_907, "tailF"), ((V)("d")), fd_1788);
Call(set_964, V.Undef, Get(E_907, "tailSC"), ((V)("d")), fd_1788);
mid_1789 = Invoke(sp3_1719, "map", Fn((V _arrowThis1875, int _argc1867, V p_1873, V i_1874, V _a1871, V _a1872, V[] _rest1868) => {
return Arr(Add(GetIdx(p_1873, 0D), ((V)((((ToNum(GetIdx(GetK(NR_1768, i_1874), 0D)) * ToNum(Call(hwAt_1767, V.Undef, i_1874))) * dn_1769) * 0.25)))), Add(GetIdx(p_1873, 1D), ((V)((((ToNum(GetIdx(GetK(NR_1768, i_1874), 1D)) * ToNum(Call(hwAt_1767, V.Undef, i_1874))) * dn_1769) * 0.25)))));
}, 2, "", true));
Rx_1790 = Invoke(sp3_1719, "map", Fn((V _arrowThis1884, int _argc1876, V p_1882, V i_1883, V _a1880, V _a1881, V[] _rest1877) => {
return Arr(Add(GetIdx(p_1882, 0D), ((V)((((ToNum(GetIdx(GetK(NR_1768, i_1883), 0D)) * ToNum(Call(hwAt_1767, V.Undef, i_1883))) * dn_1769) * 1.5)))), Add(GetIdx(p_1882, 1D), ((V)((((ToNum(GetIdx(GetK(NR_1768, i_1883), 1D)) * ToNum(Call(hwAt_1767, V.Undef, i_1883))) * dn_1769) * 1.5)))));
}, 2, "", true));
Call(set_964, V.Undef, Get(E_907, "tailS"), ((V)("d")), Call(closedD_29, V.Undef, Invoke(Invoke(mid_1789, "slice", ((V)(1D)), ((V)((ToNum(n_1766) - 1D)))), "concat", Invoke(Invoke(Rx_1790, "slice", ((V)(1D)), ((V)((ToNum(n_1766) - 1D)))), "reverse"))));
Invoke(Invoke(Arr(Get(E_907, "tail"), Get(E_907, "tailH")), "concat", Get(E_907, "tailT")), "forEach", Fn((V _arrowThis1892, int _argc1885, V e_1891, V _a1888, V _a1889, V _a1890, V[] _rest1886) => {
return Set(Get(e_1891, "style"), "display", ((V)("none")));
}, 1, "", true));
}
if (Truthy(Get(E_907, "tailT"))) {
V r0_1893 = default;
V r1_1894 = default;
double dx_1895 = 0;
double dy_1896 = 0;
V dl_1897 = default;
Invoke(Arr(Arr(((V)(1.55)), ((V)(6D))), Arr(((V)(1.25)), ((V)(10D)))), "forEach", Fn((V _arrowThis1910, int _argc1898, V _a1900, V i_1904, V _a1902, V _a1903, V[] _rest1899) => {
V k_1907 = default;
V n_1909 = default;
{ V _t1905 = ListOf(_a1900);
{ V _t1906 = GetIdx(_t1905, 0D);
k_1907 = _t1906; }
{ V _t1908 = GetIdx(_t1905, 1D);
n_1909 = _t1908; }
}
Call(set_964, V.Undef, GetK(Get(E_907, "tailT"), i_1904), ((V)("d")), Call(smoothD_26, V.Undef, Invoke(sp3_1719, "slice", ((V)(0D)), n_1909)));
Call(set_964, V.Undef, GetK(Get(E_907, "tailT"), i_1904), ((V)("stroke-width")), Call(r2_14, V.Undef, ((V)((tw_1720 * ToNum(k_1907))))));
return default;
}, 2, "", true));
r0_1893 = GetIdx(sp3_1719, 0D);
r1_1894 = GetIdx(sp3_1719, 2D);
dx_1895 = (ToNum(GetIdx(r1_1894, 0D)) - ToNum(GetIdx(r0_1893, 0D)));
dy_1896 = (ToNum(GetIdx(r1_1894, 1D)) - ToNum(GetIdx(r0_1893, 1D)));
dl_1897 = (((V)(Hypot(dx_1895, dy_1896))) is var _t1911 && Truthy(_t1911) ? _t1911 : ((V)(1D)));
Call(set_964, V.Undef, Get(E_907, "tailB"), ((V)("cx")), Call(r2_14, V.Undef, Add(GetIdx(r0_1893, 0D), ((V)((((dx_1895 / ToNum(dl_1897)) * tw_1720) * 0.3))))));
Call(set_964, V.Undef, Get(E_907, "tailB"), ((V)("cy")), Call(r2_14, V.Undef, Add(GetIdx(r0_1893, 1D), ((V)((((dy_1896 / ToNum(dl_1897)) * tw_1720) * 0.3))))));
Call(set_964, V.Undef, Get(E_907, "tailB"), ((V)("rx")), Call(r2_14, V.Undef, ((V)((tw_1720 * 1.12)))));
Call(set_964, V.Undef, Get(E_907, "tailB"), ((V)("ry")), Call(r2_14, V.Undef, ((V)((tw_1720 * 0.95)))));
Call(set_964, V.Undef, Get(E_907, "tailB"), ((V)("opacity")), Call(r2_14, V.Undef, Call(SM_16, V.Undef, ((V)((((-0.15) - cyb_925) / 0.5))))));
}
if (Truthy(Get(D_905, "tail"))) {
Set(keys_970, "tail", (Truthy(T3_1718) ? Call(bywZ_963, V.Undef, ((V)(64D)), ((V)((-22D)))) : Call(bywZ_963, V.Undef, ((V)(66D)), ((V)((-12D))))));
}
Set(keys_970, "collar", ((V)(1.5)));
if (Truthy(Get(D_905, "mane"))) {
Set(keys_970, "mane", ((V)((-30D))));
Set(keys_970, "maneF", ((V)(1.3)));
if (Truthy(Get(E_907, "coat"))) {
Set(keys_970, "coatB", ((V)(0.6)));
}
}
if (Truthy(Get(D_905, "pup"))) {
Set(keys_970, "pup", ((V)(12D)));
}
Set(Get(I_902, "W"), "tail", GetIdx(sp3_1719, (ToNum(Get(sp3_1719, "length")) - 1D)));
}
MZ_971 = (Get(D_905, "muzzle") is var _t1912 && Truthy(_t1912) ? _t1912 : Arr(((V)(50D)), ((V)(57D)), ((V)(16D)), ((V)(10D))));
Call(set_964, V.Undef, Get(E_907, "muzzle"), ((V)("d")), Call(toD_25, V.Undef, Get(R_906, "muzzle"), face_952));
Call(set_964, V.Undef, Get(E_907, "muzzle"), ((V)("opacity")), Call(r2_14, V.Undef, Call(zc_956, V.Undef, GetIdx(MZ_971, 0D), GetIdx(MZ_971, 1D))));
if (Truthy(Get(E_907, "tufts"))) {
Invoke(Get(D_905, "tufts"), "forEach", Fn((V _arrowThis1921, int _argc1913, V T_1919, V i_1920, V _a1917, V _a1918, V[] _rest1914) => {
V cx_1922 = default;
V cy_1923 = default;
double dx_1924 = 0;
double dy_1925 = 0;
double q_1926 = 0;
double z0_1927 = 0;
double th0_1928 = 0;
double thN_1929 = 0;
double th_1930 = 0;
double fxs_1931 = 0;
double lf_1932 = 0;
V C0_1933 = default;
double hr2_1934 = 0;
double c2_1935 = 0;
double s2_1936 = 0;
double ct_1937 = 0;
V el_1938 = default;
V eb_1939 = default;
V TM_1940 = default;
V td_1941 = default;
V Hc_1942 = default;
double dC_1943 = 0;
V tr_1944 = default;
V f_1945 = default;
double rho_1946 = 0;
double Rg_1947 = 0;
double ky_1948 = 0;
V o1_1949 = default;
{ V _t1950 = Get(T_1919, "c");
{ V _t1951 = ListOf(_t1950);
{ V _t1952 = GetIdx(_t1951, 0D);
cx_1922 = _t1952; }
{ V _t1953 = GetIdx(_t1951, 1D);
cy_1923 = _t1953; }
} }
dx_1924 = (ToNum(cx_1922) - ToNum(HX_910));
dy_1925 = (ToNum(cy_1923) - ToNum(HY_911));
q_1926 = ((1D - ((dx_1924 / ToNum(SR_913)) * (dx_1924 / ToNum(SR_913)))) - ((dy_1925 / ToNum(SRY_915)) * (dy_1925 / ToNum(SRY_915))));
z0_1927 = (ToNum(SR_913) * System.Math.Sqrt(Max(0.02, q_1926)));
th0_1928 = FdLibm.Atan2(dx_1924, z0_1927);
thN_1929 = (th0_1928 * 0.55);
th_1930 = (th0_1928 + yh_920);
fxs_1931 = ((0.64 + (0.36 * ToNum(Call(clamp_13, V.Undef, ((V)(FdLibm.Cos((thN_1929 + yh_920)))), ((V)(0D)), ((V)(1D)))))) / (0.64 + (0.36 * FdLibm.Cos(thN_1929))));
lf_1932 = (1D + (ToNum((Get(T_1919, "lift") is var _t1954 && Truthy(_t1954) ? _t1954 : ((V)(0D)))) / ToNum(SR_913)));
C0_1933 = ((lf_1932 > 1D) ? Call(sph_950, V.Undef, Add(HX_910, ((V)((dx_1924 * lf_1932)))), Add(HY_911, ((V)((dy_1925 * lf_1932)))), ((V)((z0_1927 * lf_1932)))) : Call(sph_950, V.Undef, cx_1922, cy_1923));
hr2_1934 = ((ToNum(Get(P_903, "htilt")) * D2R_11) * 0.6);
c2_1935 = FdLibm.Cos(hr2_1934);
s2_1936 = FdLibm.Sin(hr2_1934);
ct_1937 = FdLibm.Cos(th_1930);
el_1938 = GetK(Get(E_907, "tufts"), i_1920);
eb_1939 = GetK(Get(E_907, "tuftsB"), i_1920);
TM_1940 = Fn((V _arrowThis1963, int _argc1955, V x_1961, V y_1962, V _a1959, V _a1960, V[] _rest1956) => {
double lx_1964 = 0;
double ly_1965 = 0;
lx_1964 = ((ToNum(x_1961) - ToNum(cx_1922)) * fxs_1931);
ly_1965 = (ToNum(y_1962) - ToNum(cy_1923));
return Arr(((V)((ToNum(Add(GetIdx(C0_1933, 0D), ((V)((lx_1964 * c2_1935))))) - (ly_1965 * s2_1936)))), Add(Add(GetIdx(C0_1933, 1D), ((V)((lx_1964 * s2_1936)))), ((V)((ly_1965 * c2_1935)))));
return default;
}, 2, "", true);
td_1941 = Call(toD_25, V.Undef, GetK(Get(R_906, "tufts"), i_1920), TM_1940);
Call(set_964, V.Undef, el_1938, ((V)("d")), td_1941);
Call(set_964, V.Undef, eb_1939, ((V)("d")), td_1941);
SetK((Get(I_902, "tuftMap") is var _t1966 && Truthy(_t1966) ? _t1966 : Set(I_902, "tuftMap", Arr())), i_1920, TM_1940);
if (Truthy((Get(E_907, "tuftsW") is var _t1967 && !Truthy(_t1967) ? _t1967 : GetK(Get(E_907, "tuftsW"), i_1920)))) {
V Wt_1968 = default;
Wt_1968 = Get(T_1919, "white");
Call(set_964, V.Undef, GetK(Get(E_907, "tuftsW"), i_1920), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, Add(cx_1922, GetIdx(Wt_1968, 0D)), Add(cy_1923, GetIdx(Wt_1968, 1D)), GetIdx(Wt_1968, 2D), GetIdx(Wt_1968, 2D), ((V)(0D)), ((V)(10D))), TM_1940));
}
Hc_1942 = Call(headT_948, V.Undef, HX_910, HY_911);
dC_1943 = Hypot((ToNum(GetIdx(C0_1933, 0D)) - ToNum(GetIdx(Hc_1942, 0D))), (ToNum(GetIdx(C0_1933, 1D)) - ToNum(GetIdx(Hc_1942, 1D))));
tr_1944 = (Get(T_1919, "r") is var _t1969 && Truthy(_t1969) ? _t1969 : ((V)(9.5)));
f_1945 = Call(SM_16, V.Undef, ((V)(((0.26 - ct_1937) / 0.52))));
rho_1946 = ((dC_1943 - ToNum(tr_1944)) + ((ToNum(f_1945) * 2D) * ToNum(tr_1944)));
Rg_1947 = 60D;
ky_1948 = (ToNum(SRY_915) / ToNum(SR_913));
Call(set_964, V.Undef, Get(el_1938, "_g"), ((V)("cx")), Call(r2_14, V.Undef, GetIdx(Hc_1942, 0D)));
Call(set_964, V.Undef, Get(el_1938, "_g"), ((V)("cy")), Call(r2_14, V.Undef, GetIdx(Hc_1942, 1D)));
Call(set_964, V.Undef, Get(el_1938, "_g"), ((V)("gradientTransform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_14, V.Undef, GetIdx(Hc_1942, 0D))).S(" ").V(Call(r2_14, V.Undef, GetIdx(Hc_1942, 1D))).S(") scale(1 ").V(Invoke(((V)(ky_1948)), "toFixed", ((V)(4D)))).S(") translate(").V(Call(r2_14, V.Undef, ((V)((-ToNum(GetIdx(Hc_1942, 0D))))))).S(" ").V(Call(r2_14, V.Undef, ((V)((-ToNum(GetIdx(Hc_1942, 1D))))))).S(")").End())));
o1_1949 = (GtN(f_1945, 0.001) ? Call(clamp_13, V.Undef, ((V)((rho_1946 / Rg_1947))), ((V)(0D)), ((V)(1D))) : ((V)(0D)));
Invoke(GetIdx(Get(el_1938, "_s"), 0D), "setAttribute", ((V)("offset")), Invoke(o1_1949, "toFixed", ((V)(4D))));
Invoke(GetIdx(Get(el_1938, "_s"), 1D), "setAttribute", ((V)("offset")), Invoke((GtN(f_1945, 0.001) ? Call(clamp_13, V.Undef, ((V)(((rho_1946 + 1.8) / Rg_1947))), ((V)(0D)), ((V)(1D))) : ((V)(0D))), "toFixed", ((V)(4D))));
Call(set_964, V.Undef, el_1938, ((V)("opacity")), ((V)(1D)));
Call(set_964, V.Undef, eb_1939, ((V)("opacity")), Call(r2_14, V.Undef, Call(SM_16, V.Undef, ((V)(((ct_1937 + 0.95) / 0.25))))));
return default;
}, 2, "", true));
}
Invoke((Get(E_907, "fx") is var _t1985 && Truthy(_t1985) ? _t1985 : Arr()), "forEach", Fn((V _arrowThis1978, int _argc1970, V el_1976, V i_1977, V _a1974, V _a1975, V[] _rest1971) => {
V fe_1979 = default;
V big_1980 = default;
fe_1979 = GetK(Get(D_905, "faceExtra"), i_1977);
big_1980 = (Get(R_906, "fxBig") is var _t1981 && !Truthy(_t1981) ? _t1981 : GetK(Get(R_906, "fxBig"), i_1977));
Call(set_964, V.Undef, el_1976, ((V)("d")), Call(toD_25, V.Undef, GetK(Get(R_906, "fx"), i_1977), (Truthy(Get(fe_1979, "gloss")) ? headT_948 : (Truthy(Get(fe_1979, "hug")) ? hugF_961 : (Truthy((big_1980 is var _t1982 && !Truthy(_t1982) ? _t1982 : (!(Truthy(Get(fe_1979, "sph"))) ? V.True : V.False))) ? wrapF_954 : face_952)))));
Call(set_964, V.Undef, el_1976, ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ToNum((Get(fe_1979, "op") is var _t1983 && Truthy(_t1983) ? _t1983 : ((V)(1D)))) * ToNum((Truthy(Get(fe_1979, "gloss")) ? ((V)(1D)) : (Truthy(Get(fe_1979, "hug")) ? Call(zc_956, V.Undef, HX_910, GetIdx(GetK(Get(R_906, "fxC"), i_1977), 1D)) : (Truthy((big_1980 is var _t1984 && !Truthy(_t1984) ? _t1984 : (!(Truthy(Get(fe_1979, "sph"))) ? V.True : V.False))) ? ((V)(1D)) : Call(zc_956, V.Undef, GetIdx(GetK(Get(R_906, "fxC"), i_1977), 0D), GetIdx(GetK(Get(R_906, "fxC"), i_1977), 1D)))))))))));
return default;
}, 2, "", true));
Call(set_964, V.Undef, Get(E_907, "stripes"), ((V)("d")), Call(toD_25, V.Undef, Get(R_906, "stripes"), face_952));
Call(set_964, V.Undef, Get(E_907, "stripes"), ((V)("opacity")), Call(r2_14, V.Undef, Call(zc_956, V.Undef, ((V)(50D)), ((V)(21D)))));
Call(set_964, V.Undef, Get(E_907, "back"), ((V)("d")), Call(toD_25, V.Undef, Get(R_906, "back"), Fn((V _arrowThis1994, int _argc1986, V x_1992, V y_1993, V _a1990, V _a1991, V[] _rest1987) => {
return Call(sph_950, V.Undef, x_1992, y_1993, ((V)("b")));
}, 2, "", true)));
Call(set_964, V.Undef, Get(E_907, "back"), ((V)("opacity")), Call(r2_14, V.Undef, Call(zc_956, V.Undef, (Truthy(Get(D_905, "backAt")) ? GetIdx(Get(D_905, "backAt"), 0D) : ((V)(50D))), (Truthy(Get(D_905, "backAt")) ? GetIdx(Get(D_905, "backAt"), 1D) : ((V)(23D))), ((V)("b")))));
if (Truthy(Get(E_907, "snout"))) {
V S0_1995 = default;
V la_1996 = default;
V lb_1997 = default;
V lc_1998 = default;
double dx_1999 = 0;
double dy_2000 = 0;
double q_2001 = 0;
V z0_2002 = default;
V pv_2003 = default;
V dep_2004 = default;
V C_2005 = default;
V ux_2006 = default;
V A_2007 = default;
V sv_2008 = default;
V svv_2009 = default;
V N0_2010 = default;
V nz_2011 = default;
double ny_2012 = 0;
V NC_2013 = default;
V na_2014 = default;
V nb_2015 = default;
V nc_2016 = default;
V HC_2017 = default;
S0_1995 = Get(D_905, "snout");
{ V _t2018 = Get(S0_1995, "r");
{ V _t2019 = ListOf(_t2018);
{ V _t2020 = GetIdx(_t2019, 0D);
la_1996 = _t2020; }
{ V _t2021 = GetIdx(_t2019, 1D);
lb_1997 = _t2021; }
{ V _t2022 = GetIdx(_t2019, 2D);
lc_1998 = _t2022; }
} }
dx_1999 = (ToNum(GetIdx(Get(S0_1995, "c"), 0D)) - ToNum(HX_910));
dy_2000 = (ToNum(GetIdx(Get(S0_1995, "c"), 1D)) - ToNum(HY_911));
q_2001 = ((1D - Pow((dx_1999 / ToNum(SR_913)), 2D)) - Pow((dy_2000 / ToNum(SRY_915)), 2D));
z0_2002 = Add(((V)(((q_2001 > 0D) ? (ToNum(SR_913) * System.Math.Sqrt(q_2001)) : 0D))), (Get(S0_1995, "out") is var _t2023 && Truthy(_t2023) ? _t2023 : ((V)(0D))));
pv_2003 = Fn((V _arrowThis2033, int _argc2024, V x_2030, V y_2031, V z_2032, V _a2029, V[] _rest2025) => {
double z1_2034 = 0;
z1_2034 = (((-ToNum(x_2030)) * syh_928) + (ToNum(z_2032) * cyh_927));
return Arr(((V)(((ToNum(x_2030) * cyh_927) + (ToNum(z_2032) * syh_928)))), ((V)(((ToNum(y_2031) * cp_929) - ((z1_2034 * sp_930) * KY_916)))));
return default;
}, 3, "", true);
dep_2004 = Fn((V _arrowThis2044, int _argc2035, V x_2041, V y_2042, V z_2043, V _a2040, V[] _rest2036) => {
double z1_2045 = 0;
z1_2045 = (((-ToNum(x_2041)) * syh_928) + (ToNum(z_2043) * cyh_927));
return ((V)((((ToNum(y_2042) * sp_930) / KY_916) + (z1_2045 * cp_929))));
return default;
}, 3, "", true);
C_2005 = Call(pv_2003, V.Undef, ((V)(dx_1999)), ((V)(dy_2000)), z0_2002);
ux_2006 = (Get(S0_1995, "tilt") is var _t2046 && Truthy(_t2046) ? _t2046 : ((V)(0D)));
A_2007 = Arr(Call(pv_2003, V.Undef, la_1996, ((V)(0D)), ((V)(0D))), Call(pv_2003, V.Undef, ((V)(0D)), lb_1997, ((V)(0D))), Call(pv_2003, V.Undef, ((V)(0D)), ((V)((ToNum(lb_1997) * ToNum(ux_2006)))), lc_1998));
sv_2008 = Call(SM_16, V.Undef, ((V)((ToNum(Add(Call(dep_2004, V.Undef, ((V)(dx_1999)), ((V)(dy_2000)), z0_2002), ((V)(5D)))) / 4.5))));
svv_2009 = sv_2008;
if (Truthy(Get(S0_1995, "occlude"))) {
V bk_2047 = default;
bk_2047 = (LtN(Call(dep_2004, V.Undef, ((V)(dx_1999)), ((V)(dy_2000)), z0_2002), 0D) ? V.True : V.False);
svv_2009 = ((V)(1D));
if (!SEq(bk_2047, Get(I_902, "snBk"))) {
V els_2048 = default;
V hg_2049 = default;
Set(I_902, "snBk", bk_2047);
els_2048 = Invoke(Arr(Get(E_907, "snoutJ"), Get(E_907, "snout"), Get(E_907, "snoutN"), Get(E_907, "snoutH")), "filter", G("Boolean"));
hg_2049 = Get(Get(E_907, "skull"), "parentNode");
if (Truthy((bk_2047 is var _t2050 && !Truthy(_t2050) ? _t2050 : (SEq(Get(I_902, "snAnchor"), V.Undef) ? V.True : V.False)))) {
Set(I_902, "snAnchor", Get(GetIdx(els_2048, (ToNum(Get(els_2048, "length")) - 1D)), "nextSibling"));
}
Invoke(els_2048, "forEach", Fn((V _arrowThis2058, int _argc2051, V el_2057, V _a2054, V _a2055, V _a2056, V[] _rest2052) => {
return Invoke(hg_2049, "insertBefore", el_2057, (Truthy(bk_2047) ? Get(E_907, "skull") : (Get(I_902, "snAnchor") is var _t2059 && Truthy(_t2059) ? _t2059 : V.Null)));
}, 1, "", true));
}
}
Call(set_964, V.Undef, Get(E_907, "snout"), ((V)("d")), Call(toD_25, V.Undef, Call(ellAx_30, V.Undef, Add(HX_910, GetIdx(C_2005, 0D)), Add(HY_911, GetIdx(C_2005, 1D)), A_2007), headT_948));
Call(set_964, V.Undef, Get(E_907, "snout"), ((V)("opacity")), Call(r2_14, V.Undef, svv_2009));
if (Truthy(Get(E_907, "snoutJ"))) {
V J_2060 = default;
V ja_2061 = default;
V jb_2062 = default;
V jc_2063 = default;
V op_2064 = default;
V JC_2065 = default;
V jt_2066 = default;
J_2060 = Get(S0_1995, "jaw");
{ V _t2067 = Get(J_2060, "r");
{ V _t2068 = ListOf(_t2067);
{ V _t2069 = GetIdx(_t2068, 0D);
ja_2061 = _t2069; }
{ V _t2070 = GetIdx(_t2068, 1D);
jb_2062 = _t2070; }
{ V _t2071 = GetIdx(_t2068, 2D);
jc_2063 = _t2071; }
} }
op_2064 = Call(clamp_13, V.Undef, Get(P_903, "open"), ((V)(0D)), ((V)(1D)));
JC_2065 = Call(pv_2003, V.Undef, ((V)(dx_1999)), ((V)(((dy_2000 + (ToNum(lb_1997) * 0.62)) + (ToNum(op_2064) * ToNum((Get(J_2060, "drop") is var _t2072 && Truthy(_t2072) ? _t2072 : ((V)(2.2)))))))), ((V)(((ToNum(z0_2002) - (ToNum(lc_1998) * 0.08)) - (ToNum(op_2064) * 0.6)))));
jt_2066 = Add((Get(J_2060, "tilt") is var _t2073 && Truthy(_t2073) ? _t2073 : ((V)(0D))), ((V)((ToNum(op_2064) * ToNum((Get(J_2060, "tiltOpen") is var _t2074 && Truthy(_t2074) ? _t2074 : ((V)(0.5))))))));
Call(set_964, V.Undef, Get(E_907, "snoutJ"), ((V)("d")), Call(toD_25, V.Undef, Call(ellAx_30, V.Undef, Add(HX_910, GetIdx(JC_2065, 0D)), Add(HY_911, GetIdx(JC_2065, 1D)), Arr(Call(pv_2003, V.Undef, ja_2061, ((V)(0D)), ((V)(0D))), Call(pv_2003, V.Undef, ((V)(0D)), jb_2062, ((V)(0D))), Call(pv_2003, V.Undef, ((V)(0D)), ((V)((ToNum(jc_2063) * ToNum(jt_2066)))), jc_2063))), headT_948));
Call(set_964, V.Undef, Get(E_907, "snoutJ"), ((V)("opacity")), Call(r2_14, V.Undef, svv_2009));
}
N0_2010 = (Get(S0_1995, "nose") is var _t2075 && Truthy(_t2075) ? _t2075 : NewObj(1).Put("r", Arr(((V)(2.5)), ((V)(2D)), ((V)(1.6)))).V);
nz_2011 = Add(z0_2002, ((V)((ToNum(lc_1998) * 0.9))));
ny_2012 = ((dy_2000 + ((ToNum(lb_1997) * ToNum(ux_2006)) * 0.9)) - (ToNum(lb_1997) * 0.12));
NC_2013 = Call(pv_2003, V.Undef, ((V)(dx_1999)), ((V)(ny_2012)), nz_2011);
{ V _t2076 = Get(N0_2010, "r");
{ V _t2077 = ListOf(_t2076);
{ V _t2078 = GetIdx(_t2077, 0D);
na_2014 = _t2078; }
{ V _t2079 = GetIdx(_t2077, 1D);
nb_2015 = _t2079; }
{ V _t2080 = GetIdx(_t2077, 2D);
nc_2016 = _t2080; }
} }
Call(set_964, V.Undef, Get(E_907, "snoutN"), ((V)("d")), Call(toD_25, V.Undef, Call(ellAx_30, V.Undef, Add(HX_910, GetIdx(NC_2013, 0D)), Add(HY_911, GetIdx(NC_2013, 1D)), Arr(Call(pv_2003, V.Undef, na_2014, ((V)(0D)), ((V)(0D))), Call(pv_2003, V.Undef, ((V)(0D)), nb_2015, ((V)(0D))), Call(pv_2003, V.Undef, ((V)(0D)), ((V)(0D)), nc_2016))), headT_948));
Call(set_964, V.Undef, Get(E_907, "snoutN"), ((V)("opacity")), Call(r2_14, V.Undef, svv_2009));
HC_2017 = Call(pv_2003, V.Undef, ((V)((dx_1999 - (ToNum(na_2014) * 0.35)))), ((V)((ny_2012 - (ToNum(nb_2015) * 0.4)))), Add(nz_2011, ((V)((ToNum(nc_2016) * 0.6)))));
Call(set_964, V.Undef, Get(E_907, "snoutH"), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, Add(HX_910, GetIdx(HC_2017, 0D)), Add(HY_911, GetIdx(HC_2017, 1D)), ((V)((ToNum(na_2014) * 0.32))), ((V)((ToNum(nb_2015) * 0.26))), ((V)(0D)), ((V)(6D))), headT_948));
Call(set_964, V.Undef, Get(E_907, "snoutH"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((Truthy(Get(S0_1995, "occlude")) ? (Truthy(Get(I_902, "snBk")) ? 0D : (0.75 * ToNum(Call(SM_16, V.Undef, ((V)((ToNum(Add(Call(dep_2004, V.Undef, ((V)(dx_1999)), ((V)(dy_2000)), z0_2002), ((V)(2D)))) / 4D))))))) : (ToNum(sv_2008) * 0.75))))));
Set(Get(I_902, "W"), "nose", Call(headT_948, V.Undef, Add(HX_910, GetIdx(NC_2013, 0D)), Add(HY_911, GetIdx(NC_2013, 1D))));
}
NS0_972 = (Get(D_905, "nose") is var _t2081 && Truthy(_t2081) ? _t2081 : Arr(((V)(50D)), ((V)(54D)), ((V)(2.6)), ((V)(1.8))));
Call(set_964, V.Undef, Get(E_907, "nose"), ((V)("d")), Call(toD_25, V.Undef, Get(R_906, "nose"), face_952));
Call(set_964, V.Undef, Get(E_907, "nose"), ((V)("opacity")), Call(r2_14, V.Undef, Call(zc_956, V.Undef, GetIdx(NS0_972, 0D), GetIdx(NS0_972, 1D))));
if (Truthy(Get(E_907, "noseHL"))) {
Call(set_964, V.Undef, Get(E_907, "noseHL"), ((V)("d")), Call(toD_25, V.Undef, Get(R_906, "noseHL"), face_952));
Call(set_964, V.Undef, Get(E_907, "noseHL"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((0.7 * ToNum(Call(zc_956, V.Undef, GetIdx(NS0_972, 0D), GetIdx(NS0_972, 1D))))))));
}
sm_973 = Call(clamp_13, V.Undef, Get(P_903, "smile"), ((V)(0D)), ((V)(1D)));
decal_974 = Fn((V _arrowThis2091, int _argc2082, V F_2088, V cx_2089, V cy_2090, V _a2087, V[] _rest2083) => {
double e_2092 = 0;
double k_2093 = 0;
V C_2094 = default;
V a_2095 = default;
V b_2096 = default;
V c_2097 = default;
V d_2098 = default;
V h1_2099 = default;
V h2_2100 = default;
V h3_2101 = default;
V h4_2102 = default;
V mul_2103 = default;
V J_2104 = default;
V Hm_2105 = default;
V dt_2106 = default;
V m_2107 = default;
double e1_2108 = 0;
double f1_2109 = 0;
double g1_2110 = 0;
double k1_2111 = 0;
double q1_2112 = 0;
double q2_2113 = 0;
double a1_2114 = 0;
double a2_2115 = 0;
double th_2116 = 0;
double ph2_2117 = 0;
double s1_2118 = 0;
double s2_2119 = 0;
double cf_2120 = 0;
double sf_2121 = 0;
double ct_2122 = 0;
double st_2123 = 0;
V M_2124 = default;
e_2092 = 0.5;
k_2093 = (1D / (2D * e_2092));
C_2094 = Call(F_2088, V.Undef, cx_2089, cy_2090);
a_2095 = Call(F_2088, V.Undef, Add(cx_2089, ((V)(e_2092))), cy_2090);
b_2096 = Call(F_2088, V.Undef, ((V)((ToNum(cx_2089) - e_2092))), cy_2090);
c_2097 = Call(F_2088, V.Undef, cx_2089, Add(cy_2090, ((V)(e_2092))));
d_2098 = Call(F_2088, V.Undef, cx_2089, ((V)((ToNum(cy_2090) - e_2092))));
h1_2099 = Call(headT_948, V.Undef, Add(cx_2089, ((V)(e_2092))), cy_2090);
h2_2100 = Call(headT_948, V.Undef, ((V)((ToNum(cx_2089) - e_2092))), cy_2090);
h3_2101 = Call(headT_948, V.Undef, cx_2089, Add(cy_2090, ((V)(e_2092))));
h4_2102 = Call(headT_948, V.Undef, cx_2089, ((V)((ToNum(cy_2090) - e_2092))));
mul_2103 = Fn((V _arrowThis2133, int _argc2125, V A_2131, V B_2132, V _a2129, V _a2130, V[] _rest2126) => {
return Arr(((V)(((ToNum(GetIdx(A_2131, 0D)) * ToNum(GetIdx(B_2132, 0D))) + (ToNum(GetIdx(A_2131, 1D)) * ToNum(GetIdx(B_2132, 2D)))))), ((V)(((ToNum(GetIdx(A_2131, 0D)) * ToNum(GetIdx(B_2132, 1D))) + (ToNum(GetIdx(A_2131, 1D)) * ToNum(GetIdx(B_2132, 3D)))))), ((V)(((ToNum(GetIdx(A_2131, 2D)) * ToNum(GetIdx(B_2132, 0D))) + (ToNum(GetIdx(A_2131, 3D)) * ToNum(GetIdx(B_2132, 2D)))))), ((V)(((ToNum(GetIdx(A_2131, 2D)) * ToNum(GetIdx(B_2132, 1D))) + (ToNum(GetIdx(A_2131, 3D)) * ToNum(GetIdx(B_2132, 3D)))))));
}, 2, "", true);
J_2104 = Arr(((V)(((ToNum(GetIdx(a_2095, 0D)) - ToNum(GetIdx(b_2096, 0D))) * k_2093))), ((V)(((ToNum(GetIdx(c_2097, 0D)) - ToNum(GetIdx(d_2098, 0D))) * k_2093))), ((V)(((ToNum(GetIdx(a_2095, 1D)) - ToNum(GetIdx(b_2096, 1D))) * k_2093))), ((V)(((ToNum(GetIdx(c_2097, 1D)) - ToNum(GetIdx(d_2098, 1D))) * k_2093))));
Hm_2105 = Arr(((V)(((ToNum(GetIdx(h1_2099, 0D)) - ToNum(GetIdx(h2_2100, 0D))) * k_2093))), ((V)(((ToNum(GetIdx(h3_2101, 0D)) - ToNum(GetIdx(h4_2102, 0D))) * k_2093))), ((V)(((ToNum(GetIdx(h1_2099, 1D)) - ToNum(GetIdx(h2_2100, 1D))) * k_2093))), ((V)(((ToNum(GetIdx(h3_2101, 1D)) - ToNum(GetIdx(h4_2102, 1D))) * k_2093))));
dt_2106 = (((V)(((ToNum(GetIdx(Hm_2105, 0D)) * ToNum(GetIdx(Hm_2105, 3D))) - (ToNum(GetIdx(Hm_2105, 1D)) * ToNum(GetIdx(Hm_2105, 2D)))))) is var _t2134 && Truthy(_t2134) ? _t2134 : ((V)(1D)));
m_2107 = Call(mul_2103, V.Undef, Arr(((V)((ToNum(GetIdx(Hm_2105, 3D)) / ToNum(dt_2106)))), ((V)(((-ToNum(GetIdx(Hm_2105, 1D))) / ToNum(dt_2106)))), ((V)(((-ToNum(GetIdx(Hm_2105, 2D))) / ToNum(dt_2106)))), ((V)((ToNum(GetIdx(Hm_2105, 0D)) / ToNum(dt_2106))))), J_2104);
e1_2108 = (ToNum(Add(GetIdx(m_2107, 0D), GetIdx(m_2107, 3D))) / 2D);
f1_2109 = ((ToNum(GetIdx(m_2107, 0D)) - ToNum(GetIdx(m_2107, 3D))) / 2D);
g1_2110 = (ToNum(Add(GetIdx(m_2107, 2D), GetIdx(m_2107, 1D))) / 2D);
k1_2111 = ((ToNum(GetIdx(m_2107, 2D)) - ToNum(GetIdx(m_2107, 1D))) / 2D);
q1_2112 = Hypot(e1_2108, k1_2111);
q2_2113 = Hypot(f1_2109, g1_2110);
a1_2114 = FdLibm.Atan2(g1_2110, f1_2109);
a2_2115 = FdLibm.Atan2(k1_2111, e1_2108);
th_2116 = ((a2_2115 - a1_2114) / 2D);
ph2_2117 = ((a2_2115 + a1_2114) / 2D);
s1_2118 = Min((q1_2112 + q2_2113), 1D);
s2_2119 = (Sign((q1_2112 - q2_2113)) * Min(System.Math.Abs((q1_2112 - q2_2113)), 1D));
cf_2120 = FdLibm.Cos(ph2_2117);
sf_2121 = FdLibm.Sin(ph2_2117);
ct_2122 = FdLibm.Cos(th_2116);
st_2123 = FdLibm.Sin(th_2116);
M_2124 = Call(mul_2103, V.Undef, Hm_2105, Call(mul_2103, V.Undef, Arr(((V)((cf_2120 * s1_2118))), ((V)(((-sf_2121) * s2_2119))), ((V)((sf_2121 * s1_2118))), ((V)((cf_2120 * s2_2119)))), Arr(((V)(ct_2122)), ((V)((-st_2123))), ((V)(st_2123)), ((V)(ct_2122)))));
return Fn((V _arrowThis2143, int _argc2135, V x_2141, V y_2142, V _a2139, V _a2140, V[] _rest2136) => {
double u_2144 = 0;
double v_2145 = 0;
u_2144 = (ToNum(x_2141) - ToNum(cx_2089));
v_2145 = (ToNum(y_2142) - ToNum(cy_2090));
return Arr(Add(Add(GetIdx(C_2094, 0D), ((V)((ToNum(GetIdx(M_2124, 0D)) * u_2144)))), ((V)((ToNum(GetIdx(M_2124, 1D)) * v_2145)))), Add(Add(GetIdx(C_2094, 1D), ((V)((ToNum(GetIdx(M_2124, 2D)) * u_2144)))), ((V)((ToNum(GetIdx(M_2124, 3D)) * v_2145)))));
return default;
}, 2, "", true);
return default;
}, 3, "", true);
CK_975 = (Get(D_905, "cheekR") is var _t2146 && Truthy(_t2146) ? _t2146 : Arr(((V)(4D)), ((V)(2.6))));
Invoke((Get(D_905, "cheeks") is var _t2162 && Truthy(_t2162) ? _t2162 : Arr(Arr(((V)(33D)), ((V)(56D))), Arr(((V)(67D)), ((V)(56D))))), "forEach", Fn((V _arrowThis2159, int _argc2147, V _a2149, V i_2153, V _a2151, V _a2152, V[] _rest2148) => {
double cy_2160 = 0;
double pk_2161 = 0;
V cx_2156 = default;
V cy0_2158 = default;
{ V _t2154 = ListOf(_a2149);
{ V _t2155 = GetIdx(_t2154, 0D);
cx_2156 = _t2155; }
{ V _t2157 = GetIdx(_t2154, 1D);
cy0_2158 = _t2157; }
}
cy_2160 = (ToNum(cy0_2158) - (ToNum(sm_973) * 0.6));
pk_2161 = (1D + (Max(0D, ToNum(pf_965)) * 0.35));
Call(set_964, V.Undef, GetK(Get(E_907, "cheeks"), i_2153), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, Add(cx_2156, ((V)((((Truthy(i_2153) ? 1D : (-1D)) * Max(0D, ToNum(pf_965))) * 1.2)))), ((V)(cy_2160)), ((V)(((ToNum(GetIdx(CK_975, 0D)) * (1D + (ToNum(sm_973) * 0.08))) * pk_2161))), ((V)((ToNum(GetIdx(CK_975, 1D)) * pk_2161))), ((V)(0D)), ((V)(8D))), (Truthy(Get(D_905, "hugCheeks")) ? Call(decal_974, V.Undef, hugF_961, cx_2156, ((V)(cy_2160))) : face_952)));
Call(set_964, V.Undef, GetK(Get(E_907, "cheeks"), i_2153), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ToNum(Call(clamp_13, V.Undef, ((V)((((0.5 + (ToNum(Call(clamp_13, V.Undef, Get(P_903, "blush"), ((V)(0D)), ((V)(1D)))) * 0.45)) + (Max(0D, ToNum(pf_965)) * 0.25)) + (ToNum(rd_968) * 0.3)))), ((V)(0D)), ((V)(1D)))) * ToNum(Call(zc_956, V.Undef, (Truthy(Get(D_905, "hugCheeks")) ? HX_910 : cx_2156), ((V)(cy_2160)))))))));
return default;
}, 2, "", true));
ox_976 = (ToNum(Get(P_903, "lx")) * 2.6);
oy_977 = (ToNum(Get(P_903, "ly")) * 2.2);
ws_978 = (1D + (ToNum(Call(clamp_13, V.Undef, Get(P_903, "wide"), ((V)(0D)), ((V)(1D)))) * 0.22));
h_979 = Call(clamp_13, V.Undef, Get(P_903, "hap"), ((V)(0D)), ((V)(1D)));
qz_980 = Call(clamp_13, V.Undef, Get(P_903, "sqz"), ((V)(0D)), ((V)(1D)));
cr_981 = (ToNum(Call(clamp_13, V.Undef, Get(P_903, "cross"), ((V)(0D)), ((V)(1D)))) * 1.8);
ty_982 = Call(clamp_13, V.Undef, Get(P_903, "teary"), ((V)(0D)), ((V)(1D)));
Set(I_902, "eyeW", Arr());
Invoke(Get(D_905, "eyes"), "forEach", Fn((V _arrowThis2175, int _argc2163, V _a2165, V i_2169, V _a2167, V _a2168, V[] _rest2164) => {
double c_2176 = 0;
double dir_2177 = 0;
V cx_2178 = default;
double cy_2179 = 0;
double r_2180 = 0;
V o_2181 = default;
V face_2182 = default;
double sl_2183 = 0;
double @out_2184 = 0;
V eD_2185 = default;
double ha_2186 = 0;
double hk_2187 = 0;
double hd_2188 = 0;
V ex_2172 = default;
V ey_2174 = default;
{ V _t2170 = ListOf(_a2165);
{ V _t2171 = GetIdx(_t2170, 0D);
ex_2172 = _t2171; }
{ V _t2173 = GetIdx(_t2170, 1D);
ey_2174 = _t2173; }
}
c_2176 = (ToNum(Call(clamp_13, V.Undef, ((V)(Max(ToNum(Get(P_903, "close")), ToNum((Truthy(i_2169) ? Get(P_903, "winkR") : Get(P_903, "winkL")))))), ((V)(0D)), ((V)(1D)))) * (1D - ToNum(Call(SM_16, V.Undef, ((V)((ToNum(h_979) * 1.6)))))));
dir_2177 = (Truthy(i_2169) ? (-1D) : 1D);
cx_2178 = Add(Add(ex_2172, ((V)(ox_976))), ((V)((dir_2177 * cr_981))));
cy_2179 = (ToNum(Add(ey_2174, ((V)(oy_977)))) - (ToNum(h_979) * 0.8));
r_2180 = (ToNum(Get(D_905, "eyeR")) * ws_978);
o_2181 = GetK(Get(E_907, "eyes"), i_2169);
face_2182 = (Truthy(((Get(D_905, "eyeDome") is var _t2189 && !Truthy(_t2189) ? _t2189 : Get(I_902, "tuftMap")) is var _t2190 && !Truthy(_t2190) ? _t2190 : GetK(Get(I_902, "tuftMap"), i_2169))) ? GetK(Get(I_902, "tuftMap"), i_2169) : face0_953);
sl_2183 = (ToNum(Call(clamp_13, V.Undef, Get(P_903, "sl"), ((V)(0D)), ((V)(1D)))) * 0.32);
@out_2184 = (Truthy(i_2169) ? 1D : (-1D));
eD_2185 = Call(toD_25, V.Undef, Call(ellS_22, V.Undef, cx_2178, ((V)(cy_2179)), ((V)(r_2180)), ((V)(r_2180)), ((V)(0D)), ((V)(8D))), Fn((V _arrowThis2199, int _argc2191, V x_2197, V y_2198, V _a2195, V _a2196, V[] _rest2192) => {
double dy_2200 = 0;
V ce_2201 = default;
V X_2202 = default;
V Y_2203 = default;
dy_2200 = (ToNum(y_2198) - cy_2179);
ce_2201 = Call(clamp_13, V.Undef, ((V)((c_2176 + (sl_2183 * (0.5 + (((0.5 * @out_2184) * (ToNum(x_2197) - ToNum(cx_2178))) / r_2180)))))), ((V)(0D)), ((V)(1D)));
X_2202 = x_2197;
Y_2203 = ((V)((cy_2179 + (dy_2200 * ((dy_2200 < 0D) ? (1D - (2D * ToNum(ce_2201))) : (1D - (2D * ToNum(h_979))))))));
if (GtN(qz_980, 0D)) {
V cu_2204 = default;
double u_2205 = 0;
cu_2204 = Call(clamp_13, V.Undef, ((V)(((ToNum(x_2197) - ToNum(cx_2178)) / r_2180))), ((V)((-1D))), ((V)(1D)));
u_2205 = ((dir_2177 > 0D) ? (ToNum(Add(cu_2204, ((V)(1D)))) / 2D) : ((1D - ToNum(cu_2204)) / 2D));
X_2202 = Call(lerp_15, V.Undef, X_2202, Add(cx_2178, ((V)(((dir_2177 * ((-0.8) + (u_2205 * 1.4))) * r_2180)))), qz_980);
Y_2203 = Call(lerp_15, V.Undef, Y_2203, ((V)((cy_2179 + (((Sign(dy_2200) * (1D - u_2205)) * 0.6) * r_2180)))), qz_980);
}
return Call(face_2182, V.Undef, X_2202, Y_2203);
return default;
}, 2, "", true));
Call(set_964, V.Undef, Get(o_2181, "e"), ((V)("d")), eD_2185);
Call(set_964, V.Undef, Get(o_2181, "clip"), ((V)("d")), eD_2185);
Call(set_964, V.Undef, Get(o_2181, "e"), ((V)("stroke-width")), Call(r2_14, V.Undef, ((V)((1.3 * Max(ToNum(Call(SM_16, V.Undef, ((V)(((c_2176 - 0.5) / 0.45))))), ToNum(Call(SM_16, V.Undef, ((V)(((ToNum(h_979) - 0.5) / 0.45))))), ToNum(Call(SM_16, V.Undef, ((V)((ToNum(qz_980) * 1.6)))))))))));
ha_2186 = (((1D - ToNum(Call(SM_16, V.Undef, ((V)(((c_2176 - 0.4) / 0.25)))))) * (1D - ToNum(Call(SM_16, V.Undef, ((V)(((ToNum(h_979) - 0.12) / 0.3))))))) * (1D - ToNum(Call(SM_16, V.Undef, ((V)((ToNum(qz_980) * 2.5)))))));
hk_2187 = (ws_978 * (1D + (ToNum(ty_982) * 0.4)));
hd_2188 = ((c_2176 * r_2180) * 0.7);
Call(set_964, V.Undef, Get(o_2181, "h1"), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, ((V)((ToNum(cx_2178) - (1.7 * ws_978)))), ((V)(((cy_2179 - (1.9 * ws_978)) + hd_2188))), ((V)((1.8 * hk_2187))), ((V)((1.8 * hk_2187))), ((V)(0D)), ((V)(6D))), face_2182));
Call(set_964, V.Undef, Get(o_2181, "h2"), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, Add(cx_2178, ((V)((1.8 * ws_978)))), ((V)((cy_2179 + (1.6 * ws_978)))), ((V)((0.7 * hk_2187))), ((V)((0.7 * hk_2187))), ((V)(0D)), ((V)(6D))), face_2182));
Call(set_964, V.Undef, Get(o_2181, "tp"), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, cx_2178, ((V)((cy_2179 + (r_2180 * 0.8)))), ((V)(r_2180)), ((V)((r_2180 * 0.42))), ((V)(0D)), ((V)(8D))), face_2182));
Call(set_964, V.Undef, Get(o_2181, "tp"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((((ToNum(ty_982) * 0.85) * (1D - ToNum(qz_980))) * (1D - ToNum(Call(SM_16, V.Undef, ((V)((c_2176 * 1.5)))))))))));
Call(set_964, V.Undef, Get(o_2181, "h1"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)(ha_2186))));
Call(set_964, V.Undef, Get(o_2181, "h2"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ha_2186 * 0.9)))));
Call(set_964, V.Undef, Get(o_2181, "g"), ((V)("opacity")), Call(r2_14, V.Undef, Call(zc_956, V.Undef, cx_2178, ((V)(cy_2179)))));
Invoke(Get(I_902, "eyeW"), "push", Call(face_2182, V.Undef, cx_2178, ((V)(cy_2179))));
SetK(Get(I_902, "W"), ((V)((Truthy(i_2169) ? "eyeR" : "eyeL"))), Call(face_2182, V.Undef, cx_2178, ((V)(cy_2179))));
return default;
}, 2, "", true));
{
V MX0_2206 = default;
V MY0_2207 = default;
V MH0_2208 = default;
V mk0_2209 = default;
V op_2210 = default;
V fr_2211 = default;
double mw_2212 = 0;
double hw_2213 = 0;
V y0_2214 = default;
double d_2215 = 0;
double ym_2216 = 0;
V lip_2217 = default;
V mv_2218 = default;
V tg_2219 = default;
{ V _t2220 = (Get(D_905, "mouth") is var _t2221 && Truthy(_t2221) ? _t2221 : Arr(((V)(50D)), ((V)(58D)), ((V)(3.5))));
{ V _t2222 = ListOf(_t2220);
{ V _t2223 = GetIdx(_t2222, 0D);
MX0_2206 = _t2223; }
{ V _t2224 = GetIdx(_t2222, 1D);
MY0_2207 = _t2224; }
{ V _t2225 = GetIdx(_t2222, 2D);
MH0_2208 = _t2225; }
} }
mk0_2209 = (!Get(D_905, "mouthD").IsNullish ? Get(D_905, "mouthD") : ((V)((ToNum(MH0_2208) / 3.5))));
op_2210 = Call(clamp_13, V.Undef, Get(P_903, "open"), ((V)(0D)), ((V)(1D)));
fr_2211 = Call(clamp_13, V.Undef, Get(P_903, "frown"), ((V)(0D)), ((V)(1D)));
mw_2212 = (ToNum(Get(P_903, "mw")) * (1D + (ToNum(sm_973) * 0.12)));
hw_2213 = ((ToNum(MH0_2208) * mw_2212) * (1D + (ToNum(op_2210) * 0.3)));
y0_2214 = Add(MY0_2207, ((V)(((((-ToNum(sm_973)) * 0.5) + (ToNum(fr_2211) * 1.3)) * ToNum(mk0_2209)))));
d_2215 = ((((2.3 * (1D + (ToNum(sm_973) * 0.45))) - (ToNum(fr_2211) * 4D)) * (1D - (ToNum(op_2210) * 0.55))) * ToNum(mk0_2209));
ym_2216 = (ToNum(MY0_2207) - ((ToNum(fr_2211) * 0.2) * ToNum(mk0_2209)));
lip_2217 = ((V)((Truthy(Get(D_905, "mouthOne")) ? JsStrBuf.Begin().S("M").V(Call(r2_14, V.Undef, ((V)((ToNum(MX0_2206) - hw_2213))))).S(" ").V(Call(r2_14, V.Undef, y0_2214)).S(" Q").V(Call(r2_14, V.Undef, MX0_2206)).S(" ").V(Call(r2_14, V.Undef, Add(y0_2214, ((V)((d_2215 * 2.2)))))).S(" ").V(Call(r2_14, V.Undef, Add(MX0_2206, ((V)(hw_2213))))).S(" ").V(Call(r2_14, V.Undef, y0_2214)).End() : JsStrBuf.Begin().S("M").V(Call(r2_14, V.Undef, ((V)((ToNum(MX0_2206) - hw_2213))))).S(" ").V(Call(r2_14, V.Undef, y0_2214)).S(" Q").V(Call(r2_14, V.Undef, ((V)((ToNum(MX0_2206) - (hw_2213 / 2D)))))).S(" ").V(Call(r2_14, V.Undef, Add(y0_2214, ((V)(d_2215))))).S(" ").V(Call(r2_14, V.Undef, MX0_2206)).S(" ").V(Call(r2_14, V.Undef, ((V)(ym_2216)))).S(" Q").V(Call(r2_14, V.Undef, Add(MX0_2206, ((V)((hw_2213 / 2D)))))).S(" ").V(Call(r2_14, V.Undef, ((V)((ym_2216 + d_2215))))).S(" ").V(Call(r2_14, V.Undef, Add(MX0_2206, ((V)(hw_2213))))).S(" ").V(Call(r2_14, V.Undef, y0_2214)).End())));
mv_2218 = Call(zc_956, V.Undef, MX0_2206, MY0_2207);
Call(set_964, V.Undef, Get(E_907, "mouth"), ((V)("d")), Call(toD_25, V.Undef, Call(parsePath_21, V.Undef, lip_2217), face_952));
Call(set_964, V.Undef, Get(E_907, "mouth"), ((V)("opacity")), Call(r2_14, V.Undef, mv_2218));
if (GtN(op_2210, 0.03)) {
Call(set_964, V.Undef, Get(E_907, "mopen"), ((V)("d")), Call(toD_25, V.Undef, Call(parsePath_21, V.Undef, ((V)(JsStrBuf.Begin().V(lip_2217).S(" C").V(Call(r2_14, V.Undef, Add(MX0_2206, ((V)(hw_2213))))).S(" ").V(Call(r2_14, V.Undef, Add(y0_2214, ((V)(((ToNum(op_2210) * 8D) * ToNum(mk0_2209))))))).S(" ").V(Call(r2_14, V.Undef, ((V)((ToNum(MX0_2206) - hw_2213))))).S(" ").V(Call(r2_14, V.Undef, Add(y0_2214, ((V)(((ToNum(op_2210) * 8D) * ToNum(mk0_2209))))))).S(" ").V(Call(r2_14, V.Undef, ((V)((ToNum(MX0_2206) - hw_2213))))).S(" ").V(Call(r2_14, V.Undef, y0_2214)).S("Z").End()))), face_952));
Call(set_964, V.Undef, Get(E_907, "tongue"), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, MX0_2206, Add(y0_2214, ((V)(((ToNum(op_2210) * 4.2) * ToNum(mk0_2209))))), ((V)((((2.3 * ToNum(op_2210)) * mw_2212) * ToNum(mk0_2209)))), ((V)(((1.4 * ToNum(op_2210)) * ToNum(mk0_2209)))), ((V)(0D)), ((V)(8D))), face_952));
Call(set_964, V.Undef, Get(E_907, "mopen"), ((V)("opacity")), Call(r2_14, V.Undef, mv_2218));
Call(set_964, V.Undef, Get(E_907, "tongue"), ((V)("opacity")), Call(r2_14, V.Undef, mv_2218));
} else {
Call(set_964, V.Undef, Get(E_907, "mopen"), ((V)("opacity")), ((V)(0D)));
Call(set_964, V.Undef, Get(E_907, "tongue"), ((V)("opacity")), ((V)(0D)));
}
tg_2219 = Call(clamp_13, V.Undef, Get(P_903, "tongue"), ((V)(0D)), ((V)(1D)));
Call(set_964, V.Undef, Get(E_907, "tout"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ToNum(mv_2218) * ToNum(Call(SM_16, V.Undef, ((V)((ToNum(tg_2219) * 3D))))))))));
if (GtN(tg_2219, 0.02)) {
Call(set_964, V.Undef, Get(E_907, "tout"), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, MX0_2206, Add(y0_2214, ((V)(((1.3 + (ToNum(tg_2219) * 1.9)) * ToNum(mk0_2209))))), ((V)(((2.2 * (1D + (ToNum(tg_2219) * 0.15))) * ToNum(mk0_2209)))), ((V)(((1D + (ToNum(tg_2219) * 1.7)) * ToNum(mk0_2209)))), ((V)(0D)), ((V)(8D))), face_952));
}
}
{
V M0_2226 = default;
V N0_2227 = default;
M0_2226 = (Get(D_905, "mouth") is var _t2228 && Truthy(_t2228) ? _t2228 : Arr(((V)(50D)), ((V)(58D))));
N0_2227 = (Get(D_905, "nose") is var _t2229 && Truthy(_t2229) ? _t2229 : Arr(((V)(50D)), ((V)(54D))));
Set(Get(I_902, "W"), "mouth", Call(face_952, V.Undef, GetIdx(M0_2226, 0D), GetIdx(M0_2226, 1D)));
if (!(Truthy(Get(D_905, "snout")))) {
Set(Get(I_902, "W"), "nose", Call(face_952, V.Undef, GetIdx(N0_2227, 0D), GetIdx(N0_2227, 1D)));
}
}
Set(Get(I_902, "W"), "body", Call(glob_942, V.Undef, ((V)(50D)), ((V)(78D))));
Set(Get(I_902, "W"), "belly", Call(glob_942, V.Undef, ((V)(50D)), ((V)(83D))));
Set(Get(I_902, "W"), "sideL", Call(glob_942, V.Undef, ((V)(30D)), ((V)(78D))));
Set(Get(I_902, "W"), "sideR", Call(glob_942, V.Undef, ((V)(70D)), ((V)(78D))));
wk_983 = Call(clamp_13, V.Undef, (Get(P_903, "wsk") is var _t2230 && Truthy(_t2230) ? _t2230 : ((V)(0D))), ((V)(0D)), ((V)(1D)));
wFold_984 = Fn((V _arrowThis2239, int _argc2231, V w_2237, V sg_2238, V _a2235, V _a2236, V[] _rest2232) => {
V r0_2240 = default;
double a_2241 = 0;
double ca_2242 = 0;
double sa_2243 = 0;
double k_2244 = 0;
r0_2240 = GetIdx(Get(GetIdx(w_2237, 0D), "p"), 0D);
a_2241 = ((0.34 * ToNum(wk_983)) * ToNum(sg_2238));
ca_2242 = FdLibm.Cos(a_2241);
sa_2243 = FdLibm.Sin(a_2241);
k_2244 = (1D - (0.5 * ToNum(wk_983)));
return Invoke(w_2237, "map", Fn((V _arrowThis2252, int _argc2245, V g_2251, V _a2248, V _a2249, V _a2250, V[] _rest2246) => {
return (SEqS(Get(g_2251, "c"), "Z") ? g_2251 : NewObj(2).Put("c", Get(g_2251, "c")).Put("p", Invoke(Get(g_2251, "p"), "map", Fn((V _arrowThis2264, int _argc2253, V _a2255, V _a2256, V _a2257, V _a2258, V[] _rest2254) => {
double dx_2265 = 0;
double dy_2266 = 0;
V x_2261 = default;
V y_2263 = default;
{ V _t2259 = ListOf(_a2255);
{ V _t2260 = GetIdx(_t2259, 0D);
x_2261 = _t2260; }
{ V _t2262 = GetIdx(_t2259, 1D);
y_2263 = _t2262; }
}
dx_2265 = ((ToNum(x_2261) - ToNum(GetIdx(r0_2240, 0D))) * k_2244);
dy_2266 = ((ToNum(y_2263) - ToNum(GetIdx(r0_2240, 1D))) * k_2244);
return Arr(((V)((ToNum(Add(GetIdx(r0_2240, 0D), ((V)((dx_2265 * ca_2242))))) - (dy_2266 * sa_2243)))), Add(Add(GetIdx(r0_2240, 1D), ((V)((dx_2265 * sa_2243)))), ((V)((dy_2266 * ca_2242)))));
return default;
}, 1, "", true))).V);
}, 1, "", true));
return default;
}, 2, "", true);
Invoke(Get(R_906, "wh"), "forEach", Fn((V _arrowThis2275, int _argc2267, V w_2273, V i_2274, V _a2271, V _a2272, V[] _rest2268) => {
double sd_2276 = 0;
double far_2277 = 0;
sd_2276 = (LtN(i_2274, 2D) ? (-1D) : 1D);
far_2277 = (1D - ToNum(Call(SM_16, V.Undef, ((V)((((syh_928 * sd_2276) - 0.06) / 0.22))))));
Call(set_964, V.Undef, GetK(Get(E_907, "wh"), i_2274), ((V)("d")), Call(toD_25, V.Undef, (GtN(wk_983, 0.01) ? Call(wFold_984, V.Undef, w_2273, ((V)(((SEqN(i_2274, 0D) || SEqN(i_2274, 3D)) ? 1D : (-1D))))) : w_2273), face_952));
Call(set_964, V.Undef, GetK(Get(E_907, "wh"), i_2274), ((V)("opacity")), Call(r2_14, V.Undef, ((V)(((0.8 * ToNum(Call(zc_956, V.Undef, ((V)((LtN(i_2274, 2D) ? 36D : 64D))), ((V)(56D))))) * far_2277)))));
return default;
}, 2, "", true));
if (Truthy((Get(E_907, "spots3") is var _t2278 && !Truthy(_t2278) ? _t2278 : Get(D_905, "body3")))) {
V bx_2279 = default;
V by_2280 = default;
V bz_2281 = default;
V brx_2282 = default;
V bry_2283 = default;
V brz_2284 = default;
double t3_2285 = 0;
double c3_2286 = 0;
double s3_2287 = 0;
JsStrBuf dd_2288 = null;
{ V _t2289 = Get(Get(D_905, "body3"), "c");
{ V _t2290 = ListOf(_t2289);
{ V _t2291 = GetIdx(_t2290, 0D);
bx_2279 = _t2291; }
{ V _t2292 = GetIdx(_t2290, 1D);
by_2280 = _t2292; }
{ V _t2293 = GetIdx(_t2290, 2D);
bz_2281 = _t2293; }
} }
{ V _t2294 = Get(Get(D_905, "body3"), "r");
{ V _t2295 = ListOf(_t2294);
{ V _t2296 = GetIdx(_t2295, 0D);
brx_2282 = _t2296; }
{ V _t2297 = GetIdx(_t2295, 1D);
bry_2283 = _t2297; }
{ V _t2298 = GetIdx(_t2295, 2D);
brz_2284 = _t2298; }
} }
t3_2285 = (ToNum((Get(Get(D_905, "body3"), "tilt") is var _t2299 && Truthy(_t2299) ? _t2299 : ((V)(0D)))) * D2R_11);
c3_2286 = FdLibm.Cos(t3_2285);
s3_2287 = FdLibm.Sin(t3_2285);
dd_2288 = new JsStrBuf("");
Invoke(Get(Get(D_905, "spots3"), "pts"), "forEach", Fn((V _arrowThis2313, int _argc2300, V _a2302, V _a2303, V _a2304, V _a2305, V[] _rest2301) => {
double A_2314 = 0;
double B_2315 = 0;
double lx_2316 = 0;
double ly_2317 = 0;
double lz_2318 = 0;
double X_2319 = 0;
double Y_2320 = 0;
double Z_2321 = 0;
double nlx_2322 = 0;
double nly_2323 = 0;
double nlz_2324 = 0;
double NX_2325 = 0;
double NY_2326 = 0;
double NZ_2327 = 0;
V NL_2328 = default;
double fz_2329 = 0;
double sx_2330 = 0;
V sy_2331 = default;
double nxs_2332 = 0;
double nys_2333 = 0;
V nl_2334 = default;
double ux_2335 = 0;
double uy_2336 = 0;
double mn_2337 = 0;
V pts_2338 = default;
V a_2308 = default;
V b_2310 = default;
V r_2312 = default;
{ V _t2306 = ListOf(_a2302);
{ V _t2307 = GetIdx(_t2306, 0D);
a_2308 = _t2307; }
{ V _t2309 = GetIdx(_t2306, 1D);
b_2310 = _t2309; }
{ V _t2311 = GetIdx(_t2306, 2D);
r_2312 = _t2311; }
}
A_2314 = (ToNum(a_2308) * D2R_11);
B_2315 = (ToNum(b_2310) * D2R_11);
lx_2316 = ((ToNum(brx_2282) * FdLibm.Cos(B_2315)) * FdLibm.Sin(A_2314));
ly_2317 = ((-ToNum(bry_2283)) * FdLibm.Sin(B_2315));
lz_2318 = ((ToNum(brz_2284) * FdLibm.Cos(B_2315)) * FdLibm.Cos(A_2314));
X_2319 = lx_2316;
Y_2320 = ((ly_2317 * c3_2286) - (lz_2318 * s3_2287));
Z_2321 = ((ly_2317 * s3_2287) + (lz_2318 * c3_2286));
nlx_2322 = (lx_2316 / (ToNum(brx_2282) * ToNum(brx_2282)));
nly_2323 = (ly_2317 / (ToNum(bry_2283) * ToNum(bry_2283)));
nlz_2324 = (lz_2318 / (ToNum(brz_2284) * ToNum(brz_2284)));
NX_2325 = nlx_2322;
NY_2326 = ((nly_2323 * c3_2286) - (nlz_2324 * s3_2287));
NZ_2327 = ((nly_2323 * s3_2287) + (nlz_2324 * c3_2286));
NL_2328 = (((V)(Hypot(NX_2325, NY_2326, NZ_2327))) is var _t2339 && Truthy(_t2339) ? _t2339 : ((V)(1D)));
fz_2329 = ((((-NX_2325) * syb_926) + (NZ_2327 * cyb_925)) / ToNum(NL_2328));
if ((fz_2329 < 0.06)) {
return default;
}
sx_2330 = ((50D + ((ToNum(Add(bx_2279, ((V)(X_2319)))) - 50D) * cyb_925)) + (ToNum(Add(bz_2281, ((V)(Z_2321)))) * syb_926));
sy_2331 = Add(by_2280, ((V)(Y_2320)));
nxs_2332 = ((NX_2325 * cyb_925) + (NZ_2327 * syb_926));
nys_2333 = NY_2326;
nl_2334 = (((V)(Hypot(nxs_2332, nys_2333))) is var _t2340 && Truthy(_t2340) ? _t2340 : ((V)(1D)));
ux_2335 = (nxs_2332 / ToNum(nl_2334));
uy_2336 = (nys_2333 / ToNum(nl_2334));
mn_2337 = (ToNum(r_2312) * fz_2329);
pts_2338 = Arr();
{
double k_2341 = 0;
k_2341 = 0D;
while (true) {
if (!((k_2341 < 10D))) break;
double t_2343 = 0;
double c_2344 = 0;
double s_2345 = 0;
t_2343 = ((k_2341 / 10D) * TAU_12);
c_2344 = FdLibm.Cos(t_2343);
s_2345 = FdLibm.Sin(t_2343);
Invoke(pts_2338, "push", Call(glob_942, V.Undef, ((V)(((sx_2330 - ((uy_2336 * ToNum(r_2312)) * c_2344)) + ((ux_2335 * mn_2337) * s_2345)))), Add(Add(sy_2331, ((V)(((ux_2335 * ToNum(r_2312)) * c_2344)))), ((V)(((uy_2336 * mn_2337) * s_2345))))));
k_2341++;
}
}
dd_2288.V(Call(closedD_29, V.Undef, pts_2338));
return default;
}, 1, "", true));
Call(set_964, V.Undef, Get(E_907, "spots3"), ((V)("d")), (((V)(dd_2288.Str)) is var _t2346 && Truthy(_t2346) ? _t2346 : ((V)("M0 0"))));
}
if (Truthy(((Get(E_907, "belly") is var _t2347 && !Truthy(_t2347) ? _t2347 : Get(D_905, "body3")) is var _t2348 && !Truthy(_t2348) ? _t2348 : Get(D_905, "belly")))) {
V bx_2349 = default;
V by_2350 = default;
V bz_2351 = default;
V brx_2352 = default;
V bry_2353 = default;
V brz_2354 = default;
V bf_2355 = default;
{ V _t2356 = Get(Get(D_905, "body3"), "c");
{ V _t2357 = ListOf(_t2356);
{ V _t2358 = GetIdx(_t2357, 0D);
bx_2349 = _t2358; }
{ V _t2359 = GetIdx(_t2357, 1D);
by_2350 = _t2359; }
{ V _t2360 = GetIdx(_t2357, 2D);
bz_2351 = _t2360; }
} }
{ V _t2361 = Get(Get(D_905, "body3"), "r");
{ V _t2362 = ListOf(_t2361);
{ V _t2363 = GetIdx(_t2362, 0D);
brx_2352 = _t2363; }
{ V _t2364 = GetIdx(_t2362, 1D);
bry_2353 = _t2364; }
{ V _t2365 = GetIdx(_t2362, 2D);
brz_2354 = _t2365; }
} }
bf_2355 = Fn((V _arrowThis2374, int _argc2366, V x_2372, V y_2373, V _a2370, V _a2371, V[] _rest2367) => {
double dx_2375 = 0;
V v_2376 = default;
double cw_2377 = 0;
double w_2378 = 0;
double dd_2379 = 0;
double q_2380 = 0;
V z_2381 = default;
double rim_2382 = 0;
double Xc_2383 = 0;
dx_2375 = (ToNum(x_2372) - ToNum(bx_2349));
v_2376 = Call(clamp_13, V.Undef, ((V)(((ToNum(y_2373) - ToNum(by_2350)) / ToNum(bry_2353)))), ((V)((-0.98))), ((V)(0.98)));
cw_2377 = System.Math.Sqrt((1D - (ToNum(v_2376) * ToNum(v_2376))));
w_2378 = (ToNum(brx_2352) * cw_2377);
dd_2379 = (ToNum(brz_2354) * cw_2377);
q_2380 = (1D - ((dx_2375 / w_2378) * (dx_2375 / w_2378)));
z_2381 = Add(bz_2351, ((V)((dd_2379 * System.Math.Sqrt(Max(0D, q_2380))))));
rim_2382 = Hypot((w_2378 * cyb_925), (dd_2379 * syb_926));
Xc_2383 = (ToNum(bz_2351) * syb_926);
return Call(glob_942, V.Undef, Add(((V)(50D)), Call(clamp_13, V.Undef, ((V)(((dx_2375 * cyb_925) + (ToNum(z_2381) * syb_926)))), ((V)((Xc_2383 - rim_2382))), ((V)((Xc_2383 + rim_2382))))), y_2373);
return default;
}, 2, "", true);
Call(set_964, V.Undef, Get(E_907, "belly"), ((V)("d")), Call(closedD_29, V.Undef, Invoke((Get(R_906, "bellyP") is var _t2392 && Truthy(_t2392) ? _t2392 : Set(R_906, "bellyP", Invoke(Call(flat_27, V.Undef, Get(R_906, "belly"), ((V)(4D))), "slice", ((V)(0D)), ((V)((-1D)))))), "map", Fn((V _arrowThis2391, int _argc2384, V p_2390, V _a2387, V _a2388, V _a2389, V[] _rest2385) => {
return Call(bf_2355, V.Undef, GetIdx(p_2390, 0D), GetIdx(p_2390, 1D));
}, 1, "", true))));
Call(set_964, V.Undef, Get(E_907, "belly"), ((V)("opacity")), Call(r2_14, V.Undef, Call(SM_16, V.Undef, ((V)(((cyb_925 - 0.15) / 0.45))))));
} else {
if (Truthy(Get(E_907, "belly"))) {
if (Truthy((Get(D_905, "bellyTurn") is var _t2393 && !Truthy(_t2393) ? _t2393 : Get(D_905, "belly")))) {
V BX_2394 = default;
V BY_2395 = default;
V BW_2396 = default;
V BH_2397 = default;
V bf_2398 = default;
{ V _t2399 = Get(D_905, "body");
{ V _t2400 = ListOf(_t2399);
{ V _t2401 = GetIdx(_t2400, 0D);
BX_2394 = _t2401; }
{ V _t2402 = GetIdx(_t2400, 1D);
BY_2395 = _t2402; }
{ V _t2403 = GetIdx(_t2400, 2D);
BW_2396 = _t2403; }
{ V _t2404 = GetIdx(_t2400, 3D);
BH_2397 = _t2404; }
} }
bf_2398 = Fn((V _arrowThis2413, int _argc2405, V x_2411, V y_2412, V _a2409, V _a2410, V[] _rest2406) => {
double dx_2414 = 0;
V v_2415 = default;
double w_2416 = 0;
double wc_2417 = 0;
double q_2418 = 0;
double z_2419 = 0;
double X_2420 = 0;
dx_2414 = (ToNum(x_2411) - ToNum(BX_2394));
v_2415 = Call(clamp_13, V.Undef, ((V)(((ToNum(y_2412) - ToNum(BY_2395)) / ToNum(BH_2397)))), ((V)((-1D))), ((V)(1D)));
w_2416 = (ToNum(BW_2396) * System.Math.Sqrt((1D - (ToNum(v_2415) * ToNum(v_2415)))));
wc_2417 = (ToNum(BW_2396) * System.Math.Sqrt((1D - ((ToNum(v_2415) * ToNum(v_2415)) * 0.36))));
q_2418 = ((wc_2417 * wc_2417) - (dx_2414 * dx_2414));
z_2419 = ((q_2418 > 0D) ? System.Math.Sqrt(q_2418) : 0D);
X_2420 = ((dx_2414 * cyb_925) + (z_2419 * syb_926));
if (((((-dx_2414) * syb_926) + (z_2419 * cyb_925)) < 0D)) {
X_2420 = (((X_2420 < 0D) ? (-1D) : 1D) * wc_2417);
}
return Call(glob_942, V.Undef, Add(BX_2394, Call(clamp_13, V.Undef, ((V)(X_2420)), ((V)((-w_2416))), ((V)(w_2416)))), y_2412);
return default;
}, 2, "", true);
Call(set_964, V.Undef, Get(E_907, "belly"), ((V)("d")), Call(closedD_29, V.Undef, Invoke((Get(R_906, "bellyP") is var _t2429 && Truthy(_t2429) ? _t2429 : Set(R_906, "bellyP", Invoke(Call(flat_27, V.Undef, Get(R_906, "belly"), ((V)(4D))), "slice", ((V)(0D)), ((V)((-1D)))))), "map", Fn((V _arrowThis2428, int _argc2421, V p_2427, V _a2424, V _a2425, V _a2426, V[] _rest2422) => {
return Call(bf_2398, V.Undef, GetIdx(p_2427, 0D), GetIdx(p_2427, 1D));
}, 1, "", true))));
Call(set_964, V.Undef, Get(E_907, "belly"), ((V)("opacity")), Call(r2_14, V.Undef, Call(SM_16, V.Undef, ((V)(((cyb_925 + 0.3) / 0.4))))));
} else {
Call(set_964, V.Undef, Get(E_907, "belly"), ((V)("d")), Call(toD_25, V.Undef, Get(R_906, "belly"), glob_942));
}
}
}
if (Truthy(Get(E_907, "coat"))) {
V K_2430 = default;
V ed_2431 = default;
V ld_2432 = default;
V p2s_2433 = default;
V br_2434 = default;
V LA_2435 = default;
double gl_2436 = 0;
V PJ_2437 = default;
V SM2_2438 = default;
JsStrBuf mB_2439 = null;
JsStrBuf mBF_2440 = null;
JsStrBuf mHF_2441 = null;
V LS_2442 = default;
V cS_2443 = default;
V f_2444 = default;
V put_2445 = default;
K_2430 = Get(R_906, "coat");
ed_2431 = (Get(I_902, "ed") is var _t2446 && Truthy(_t2446) ? _t2446 : ((V)(0D)));
ld_2432 = (Get(I_902, "ld") is var _t2447 && Truthy(_t2447) ? _t2447 : ((V)(0D)));
p2s_2433 = Fn((V _arrowThis2455, int _argc2448, V q_2454, V _a2451, V _a2452, V _a2453, V[] _rest2449) => {
return ((V)(JsStrBuf.Begin().V(Call(r2_14, V.Undef, GetIdx(q_2454, 0D))).S(" ").V(Call(r2_14, V.Undef, GetIdx(q_2454, 1D))).End()));
}, 1, "", true);
br_2434 = Call(clamp_13, V.Undef, ((V)(Max(ToNum((Get(P_903, "bristle") is var _t2456 && Truthy(_t2456) ? _t2456 : ((V)(0D)))), (ToNum(Call(clamp_13, V.Undef, Get(P_903, "wide"), ((V)(0D)), ((V)(1D)))) * 0.85), (ToNum(Call(SM_16, V.Undef, ((V)((((-ToNum(Get(P_903, "pitch"))) - 0.3) / 0.25))))) * ToNum(Call(SM_16, V.Undef, ((V)(((ToNum(sq_936) - 0.08) / 0.06))))))))), ((V)(0D)), ((V)(1D)));
LA_2435 = Invoke(Get(K_2430, "lay"), "map", Fn((V _arrowThis2465, int _argc2457, V v_2463, V j_2464, V _a2461, V _a2462, V[] _rest2458) => {
return Add(v_2463, ((V)(((ToNum(GetK(Get(K_2430, "layUp"), j_2464)) - ToNum(v_2463)) * ToNum(br_2434)))));
}, 2, "", true));
gl_2436 = (1D + (ToNum(br_2434) * 0.22));
PJ_2437 = Fn((V _arrowThis2474, int _argc2466, V p_2472, V w_2473, V _a2470, V _a2471, V[] _rest2467) => {
V B_2475 = default;
V zb_2476 = default;
V A_2477 = default;
V za_2478 = default;
B_2475 = Call(byw_962, V.Undef, GetIdx(p_2472, 0D), GetIdx(p_2472, 1D), GetIdx(p_2472, 2D));
zb_2476 = Call(bywZ_963, V.Undef, GetIdx(p_2472, 0D), GetIdx(p_2472, 2D));
if (LeN(w_2473, 0.002)) {
return Arr(B_2475, zb_2476);
}
A_2477 = Call(sph_950, V.Undef, GetIdx(p_2472, 0D), GetIdx(p_2472, 1D), GetIdx(p_2472, 2D));
za_2478 = Call(sphZ_951, V.Undef, GetIdx(p_2472, 0D), GetIdx(p_2472, 1D), GetIdx(p_2472, 2D));
if (GeN(w_2473, 0.998)) {
return Arr(A_2477, za_2478);
}
return Arr(Arr(Add(GetIdx(B_2475, 0D), ((V)(((ToNum(GetIdx(A_2477, 0D)) - ToNum(GetIdx(B_2475, 0D))) * ToNum(w_2473))))), Add(GetIdx(B_2475, 1D), ((V)(((ToNum(GetIdx(A_2477, 1D)) - ToNum(GetIdx(B_2475, 1D))) * ToNum(w_2473)))))), Add(zb_2476, ((V)(((ToNum(za_2478) - ToNum(zb_2476)) * ToNum(w_2473))))));
return default;
}, 2, "", true);
SM2_2438 = Invoke(Get(K_2430, "mesh"), "map", Fn((V _arrowThis2486, int _argc2479, V row_2485, V _a2482, V _a2483, V _a2484, V[] _rest2480) => {
return Invoke(row_2485, "map", Fn((V _arrowThis2494, int _argc2487, V v_2493, V _a2490, V _a2491, V _a2492, V[] _rest2488) => {
V q_2495 = default;
V z_2496 = default;
{ V _t2497 = Call(PJ_2437, V.Undef, Get(v_2493, "p"), Get(v_2493, "w"));
{ V _t2498 = ListOf(_t2497);
{ V _t2499 = GetIdx(_t2498, 0D);
q_2495 = _t2499; }
{ V _t2500 = GetIdx(_t2498, 1D);
z_2496 = _t2500; }
} }
return NewObj(3).Put("q", q_2495).Put("z", z_2496).Put("w", Get(v_2493, "w")).V;
return default;
}, 1, "", true));
}, 1, "", true));
mB_2439 = new JsStrBuf("");
mBF_2440 = new JsStrBuf("");
mHF_2441 = new JsStrBuf("");
{
double r_2501 = 0;
r_2501 = 0D;
while (true) {
if (!((r_2501 < (ToNum(Get(SM2_2438, "length")) - 1D)))) break;
{
double i_2503 = 0;
i_2503 = 0D;
while (true) {
if (!(Lt(((V)(i_2503)), Get(GetIdx(SM2_2438, r_2501), "length")))) break;
double i2_2505 = 0;
V c_2506 = default;
V w_2507 = default;
double ar_2508 = 0;
V d_2509 = default;
i2_2505 = ((i_2503 + 1D) % ToNum(Get(GetIdx(SM2_2438, r_2501), "length")));
c_2506 = Arr(GetIdx(GetIdx(SM2_2438, r_2501), i_2503), GetIdx(GetIdx(SM2_2438, r_2501), i2_2505), GetIdx(GetIdx(SM2_2438, (r_2501 + 1D)), i2_2505), GetIdx(GetIdx(SM2_2438, (r_2501 + 1D)), i_2503));
w_2507 = Invoke(c_2506, "map", Fn((V _arrowThis2517, int _argc2510, V o_2516, V _a2513, V _a2514, V _a2515, V[] _rest2511) => {
return Get(o_2516, "q");
}, 1, "", true));
ar_2508 = 0D;
{
double k_2518 = 0;
k_2518 = 0D;
while (true) {
if (!((k_2518 < 4D))) break;
V A_2520 = default;
V B_2521 = default;
A_2520 = GetIdx(w_2507, k_2518);
B_2521 = GetIdx(w_2507, ((k_2518 + 1D) % 4D));
ar_2508 = (ar_2508 + ((ToNum(GetIdx(A_2520, 0D)) * ToNum(GetIdx(B_2521, 1D))) - (ToNum(GetIdx(B_2521, 0D)) * ToNum(GetIdx(A_2520, 1D)))));
k_2518++;
}
}
if ((ar_2508 < 0D)) {
Invoke(w_2507, "reverse");
}
d_2509 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(w_2507, "map", p2s_2433), "join", ((V)(" L")))).S("Z").End()));
if (((ToNum(Add(Add(Add(Get(GetIdx(c_2506, 0D), "z"), Get(GetIdx(c_2506, 1D), "z")), Get(GetIdx(c_2506, 2D), "z")), Get(GetIdx(c_2506, 3D), "z"))) / 4D) > 0D)) {
if (((ToNum(Add(Add(Add(Get(GetIdx(c_2506, 0D), "w"), Get(GetIdx(c_2506, 1D), "w")), Get(GetIdx(c_2506, 2D), "w")), Get(GetIdx(c_2506, 3D), "w"))) / 4D) > 0.5)) {
mHF_2441.V(d_2509);
} else {
mBF_2440.V(d_2509);
}
} else {
mB_2439.V(d_2509);
}
i_2503++;
}
}
r_2501++;
}
}
LS_2442 = NewObj(3).Put("back", Arr()).Put("bodyF", Arr()).Put("headF", Arr()).V;
cS_2443 = GetIdx(Call(PJ_2437, V.Undef, Arr(((V)(50D)), ((V)(62D)), ((V)(0D))), ((V)(0.5))), 0D);
f_2444 = Get(K_2430, "tipF");
Invoke(Get(K_2430, "sp"), "forEach", Fn((V _arrowThis2529, int _argc2522, V s_2528, V _a2525, V _a2526, V _a2527, V[] _rest2523) => {
V ou_2530 = default;
V dv_2531 = default;
V dl_2532 = default;
double ln_2533 = 0;
V tip_2534 = default;
V A_2535 = default;
V zr_2536 = default;
V Tt_2537 = default;
V zt_2538 = default;
double k_2539 = 0;
double vx_2540 = 0;
double vy_2541 = 0;
double L_2542 = 0;
double nx_2543 = 0;
double ny_2544 = 0;
V w_2545 = default;
double wob_2546 = 0;
V T_2547 = default;
V B1_2548 = default;
V B2_2549 = default;
V d_2550 = default;
V dt_2551 = default;
ou_2530 = Add(GetIdx(LA_2435, 0D), ((V)((ToNum(Get(s_2528, "rim")) * (1D - ToNum(br_2434))))));
dv_2531 = Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis2559, int _argc2552, V j_2558, V _a2555, V _a2556, V _a2557, V[] _rest2553) => {
return Add(((V)(((ToNum(GetK(Get(s_2528, "n"), j_2558)) * ToNum(ou_2530)) + (ToNum(GetK(Get(s_2528, "e"), j_2558)) * ToNum(GetIdx(LA_2435, 1D)))))), (SEqN(j_2558, 1D) ? GetIdx(LA_2435, 2D) : ((V)(0D))));
}, 1, "", true));
dl_2532 = (((V)(Hypot(ToNum(GetIdx(dv_2531, 0D)), ToNum(GetIdx(dv_2531, 1D)), ToNum(GetIdx(dv_2531, 2D))))) is var _t2560 && Truthy(_t2560) ? _t2560 : ((V)(1D)));
ln_2533 = ((ToNum(Get(s_2528, "len")) * gl_2436) / ToNum(dl_2532));
tip_2534 = Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis2568, int _argc2561, V j_2567, V _a2564, V _a2565, V _a2566, V[] _rest2562) => {
return Add(GetK(Get(s_2528, "r"), j_2567), ((V)((ToNum(GetK(dv_2531, j_2567)) * ln_2533))));
}, 1, "", true));
{ V _t2569 = Call(PJ_2437, V.Undef, Get(s_2528, "r"), Get(s_2528, "o"));
{ V _t2570 = ListOf(_t2569);
{ V _t2571 = GetIdx(_t2570, 0D);
A_2535 = _t2571; }
{ V _t2572 = GetIdx(_t2570, 1D);
zr_2536 = _t2572; }
} }
{ V _t2573 = Call(PJ_2437, V.Undef, tip_2534, Get(s_2528, "o"));
{ V _t2574 = ListOf(_t2573);
{ V _t2575 = GetIdx(_t2574, 0D);
Tt_2537 = _t2575; }
{ V _t2576 = GetIdx(_t2574, 1D);
zt_2538 = _t2576; }
} }
k_2539 = (ToNum(Get(s_2528, "len")) / 10D);
vx_2540 = (ToNum(GetIdx(Tt_2537, 0D)) - ToNum(GetIdx(A_2535, 0D)));
vy_2541 = (ToNum(GetIdx(Tt_2537, 1D)) - ToNum(GetIdx(A_2535, 1D)));
L_2542 = Hypot(vx_2540, vy_2541);
if ((L_2542 < 1.2)) {
double ox_2577 = 0;
double oy_2578 = 0;
V ol_2579 = default;
ox_2577 = (ToNum(GetIdx(A_2535, 0D)) - ToNum(GetIdx(cS_2443, 0D)));
oy_2578 = (ToNum(GetIdx(A_2535, 1D)) - ToNum(GetIdx(cS_2443, 1D)));
ol_2579 = (((V)(Hypot(ox_2577, oy_2578))) is var _t2580 && Truthy(_t2580) ? _t2580 : ((V)(1D)));
vx_2540 = ((ox_2577 / ToNum(ol_2579)) * 1.2);
vy_2541 = ((oy_2578 / ToNum(ol_2579)) * 1.2);
L_2542 = 1.2;
}
nx_2543 = ((-vy_2541) / L_2542);
ny_2544 = (vx_2540 / L_2542);
w_2545 = Get(s_2528, "w");
wob_2546 = ((FdLibm.Sin(((ToNum(now_904) / 520D) + (ToNum(Get(s_2528, "i")) * 1.7))) * 0.2) * k_2539);
T_2547 = Arr(Add(Add(Add(GetIdx(A_2535, 0D), ((V)(vx_2540))), ((V)(((ToNum(ed_2431) * 0.3) * k_2539)))), ((V)((nx_2543 * wob_2546)))), ((V)(((ToNum(Add(GetIdx(A_2535, 1D), ((V)(vy_2541)))) - ((ToNum(ld_2432) * 0.25) * k_2539)) + (ny_2544 * wob_2546)))));
B1_2548 = Arr(Add(GetIdx(A_2535, 0D), ((V)((nx_2543 * ToNum(w_2545))))), Add(GetIdx(A_2535, 1D), ((V)((ny_2544 * ToNum(w_2545))))));
B2_2549 = Arr(((V)((ToNum(GetIdx(A_2535, 0D)) - (nx_2543 * ToNum(w_2545))))), ((V)((ToNum(GetIdx(A_2535, 1D)) - (ny_2544 * ToNum(w_2545))))));
d_2550 = ((V)(JsStrBuf.Begin().S("M").V(Call(p2s_2433, V.Undef, B1_2548)).S(" L").V(Call(p2s_2433, V.Undef, T_2547)).S(" L").V(Call(p2s_2433, V.Undef, B2_2549)).End()));
dt_2551 = ((V)((Truthy(f_2444) ? JsStrBuf.Begin().S("M").V(Call(p2s_2433, V.Undef, Arr(Add(GetIdx(B1_2548, 0D), ((V)(((ToNum(GetIdx(T_2547, 0D)) - ToNum(GetIdx(B1_2548, 0D))) * ToNum(f_2444))))), Add(GetIdx(B1_2548, 1D), ((V)(((ToNum(GetIdx(T_2547, 1D)) - ToNum(GetIdx(B1_2548, 1D))) * ToNum(f_2444)))))))).S(" L").V(Call(p2s_2433, V.Undef, T_2547)).S(" L").V(Call(p2s_2433, V.Undef, Arr(Add(GetIdx(B2_2549, 0D), ((V)(((ToNum(GetIdx(T_2547, 0D)) - ToNum(GetIdx(B2_2549, 0D))) * ToNum(f_2444))))), Add(GetIdx(B2_2549, 1D), ((V)(((ToNum(GetIdx(T_2547, 1D)) - ToNum(GetIdx(B2_2549, 1D))) * ToNum(f_2444)))))))).S("Z").End() : "")));
Invoke(GetK(LS_2442, ((V)((GtN(zr_2536, (-1.5)) ? (GtN(Get(s_2528, "o"), 0.5) ? "headF" : "bodyF") : "back")))), "push", Arr(((V)((ToNum(Add(zr_2536, zt_2538)) / 2D))), d_2550, dt_2551));
return default;
}, 1, "", true));
put_2445 = Fn((V _arrowThis2589, int _argc2581, V pool_2587, V list_2588, V _a2585, V _a2586, V[] _rest2582) => {
Invoke(list_2588, "sort", Fn((V _arrowThis2598, int _argc2590, V a_2596, V b_2597, V _a2594, V _a2595, V[] _rest2591) => {
return ((V)((ToNum(GetIdx(a_2596, 0D)) - ToNum(GetIdx(b_2597, 0D)))));
}, 2, "", true));
Invoke(pool_2587, "forEach", Fn((V _arrowThis2607, int _argc2599, V el_2605, V i_2606, V _a2603, V _a2604, V[] _rest2600) => {
V v_2608 = default;
V d_2609 = default;
V dt_2610 = default;
v_2608 = GetK(list_2588, i_2606);
d_2609 = (Truthy(v_2608) ? GetIdx(v_2608, 1D) : ((V)("")));
dt_2610 = (Truthy(v_2608) ? GetIdx(v_2608, 2D) : ((V)("")));
if (!SEq(Get(el_2605, "_d"), d_2609)) {
Set(el_2605, "_d", d_2609);
Call(set_964, V.Undef, Get(el_2605, "firstChild"), ((V)("d")), d_2609);
}
if (!SEq(Get(el_2605, "_t"), dt_2610)) {
Set(el_2605, "_t", dt_2610);
Call(set_964, V.Undef, Get(el_2605, "lastChild"), ((V)("d")), dt_2610);
}
return default;
}, 2, "", true));
return default;
}, 2, "", true);
Call(put_2445, V.Undef, Get(Get(E_907, "coat"), "back"), Get(LS_2442, "back"));
Call(put_2445, V.Undef, Get(Get(E_907, "coat"), "bodyF"), Get(LS_2442, "bodyF"));
Call(put_2445, V.Undef, Get(Get(E_907, "coat"), "headF"), Get(LS_2442, "headF"));
Call(set_964, V.Undef, Get(Get(E_907, "coat"), "mB"), ((V)("d")), ((V)(mB_2439.Str)));
Call(set_964, V.Undef, Get(Get(E_907, "coat"), "mBF"), ((V)("d")), ((V)(mBF_2440.Str)));
Call(set_964, V.Undef, Get(Get(E_907, "coat"), "mHF"), ((V)("d")), ((V)(mHF_2441.Str)));
} else {
if (Truthy(Get(E_907, "hog"))) {
V K_2611 = default;
V ed_2612 = default;
V ld_2613 = default;
double grow_2614 = 0;
V BX0_2615 = default;
V BY0_2616 = default;
V BW0_2617 = default;
V BH0_2618 = default;
double BZ_2619 = 0;
V hw_2620 = default;
double dyw_2621 = 0;
V rot_2622 = default;
V fac_2623 = default;
V p2s_2624 = default;
V W2_2625 = default;
V surf_2626 = default;
V S_2627 = default;
V na_2628 = default;
JsStrBuf dB_2629 = null;
JsStrBuf dF_2630 = null;
V LS_2631 = default;
V put_2632 = default;
K_2611 = Get(R_906, "hog");
ed_2612 = (Get(I_902, "ed") is var _t2633 && Truthy(_t2633) ? _t2633 : ((V)(0D)));
ld_2613 = (Get(I_902, "ld") is var _t2634 && Truthy(_t2634) ? _t2634 : ((V)(0D)));
grow_2614 = ((1D + (ToNum(Call(clamp_13, V.Undef, Get(P_903, "wide"), ((V)(0D)), ((V)(1D)))) * 0.2)) + (Max(0D, ToNum(sq_936)) * 0.15));
{ V _t2635 = Get(D_905, "body");
{ V _t2636 = ListOf(_t2635);
{ V _t2637 = GetIdx(_t2636, 0D);
BX0_2615 = _t2637; }
{ V _t2638 = GetIdx(_t2636, 1D);
BY0_2616 = _t2638; }
{ V _t2639 = GetIdx(_t2636, 2D);
BW0_2617 = _t2639; }
{ V _t2640 = GetIdx(_t2636, 3D);
BH0_2618 = _t2640; }
} }
BZ_2619 = (ToNum(BW0_2617) * 0.75);
hw_2620 = Fn((V _arrowThis2648, int _argc2641, V p_2647, V _a2644, V _a2645, V _a2646, V[] _rest2642) => {
return ((V)((ToNum(Call(SM_16, V.Undef, ((V)(((60D - ToNum(GetIdx(p_2647, 1D))) / 18D))))) * ToNum(Call(SM_16, V.Undef, ((V)((ToNum(Add(GetIdx(p_2647, 2D), ((V)(26D)))) / 14D))))))));
}, 1, "", true);
dyw_2621 = (yh_920 - yb_919);
rot_2622 = Fn((V _arrowThis2657, int _argc2649, V p_2655, V w_2656, V _a2653, V _a2654, V[] _rest2650) => {
double a_2658 = 0;
double c_2659 = 0;
double s_2660 = 0;
double x_2661 = 0;
V y_2662 = default;
double z_2663 = 0;
if (!(Truthy(w_2656))) {
return Arr(((V)(((50D + ((ToNum(GetIdx(p_2655, 0D)) - 50D) * cyb_925)) + (ToNum(GetIdx(p_2655, 2D)) * syb_926)))), GetIdx(p_2655, 1D), ((V)((((-(ToNum(GetIdx(p_2655, 0D)) - 50D)) * syb_926) + (ToNum(GetIdx(p_2655, 2D)) * cyb_925)))));
}
a_2658 = (yb_919 + (dyw_2621 * ToNum(w_2656)));
c_2659 = FdLibm.Cos(a_2658);
s_2660 = FdLibm.Sin(a_2658);
x_2661 = ((50D + ((ToNum(GetIdx(p_2655, 0D)) - 50D) * c_2659)) + (ToNum(GetIdx(p_2655, 2D)) * s_2660));
y_2662 = GetIdx(p_2655, 1D);
z_2663 = (((-(ToNum(GetIdx(p_2655, 0D)) - 50D)) * s_2660) + (ToNum(GetIdx(p_2655, 2D)) * c_2659));
if (NumTruthy(ph_924)) {
double pa_2664 = 0;
double cc_2665 = 0;
double ss_2666 = 0;
double dy_2667 = 0;
pa_2664 = (ph_924 * ToNum(w_2656));
cc_2665 = FdLibm.Cos(pa_2664);
ss_2666 = FdLibm.Sin(pa_2664);
dy_2667 = (ToNum(y_2662) - ToNum(HY_911));
y_2662 = ((V)((ToNum(Add(HY_911, ((V)((dy_2667 * cc_2665))))) - (z_2663 * ss_2666))));
z_2663 = ((dy_2667 * ss_2666) + (z_2663 * cc_2665));
}
return Arr(((V)(x_2661)), y_2662, ((V)(z_2663)));
return default;
}, 2, "", true);
fac_2623 = Fn((V _arrowThis2676, int _argc2668, V n_2674, V w_2675, V _a2672, V _a2673, V[] _rest2669) => {
double a_2677 = 0;
if (!(Truthy(w_2675))) {
return ((V)((((-ToNum(GetIdx(n_2674, 0D))) * syb_926) + (ToNum(GetIdx(n_2674, 2D)) * cyb_925))));
}
a_2677 = (yb_919 + (dyw_2621 * ToNum(w_2675)));
return ((V)((((-ToNum(GetIdx(n_2674, 0D))) * FdLibm.Sin(a_2677)) + (ToNum(GetIdx(n_2674, 2D)) * FdLibm.Cos(a_2677)))));
return default;
}, 2, "", true);
p2s_2624 = Fn((V _arrowThis2685, int _argc2678, V q_2684, V _a2681, V _a2682, V _a2683, V[] _rest2679) => {
return ((V)(JsStrBuf.Begin().V(Call(r2_14, V.Undef, GetIdx(q_2684, 0D))).S(" ").V(Call(r2_14, V.Undef, GetIdx(q_2684, 1D))).End()));
}, 1, "", true);
if (!(Truthy(Get(K_2611, "GW")))) {
Set(K_2611, "GW", Invoke(Get(K_2611, "G"), "map", Fn((V _arrowThis2693, int _argc2686, V row_2692, V _a2689, V _a2690, V _a2691, V[] _rest2687) => {
return Invoke(row_2692, "map", hw_2620);
}, 1, "", true)));
Invoke(Get(K_2611, "sp"), "forEach", Fn((V _arrowThis2701, int _argc2694, V s_2700, V _a2697, V _a2698, V _a2699, V[] _rest2695) => {
Set(s_2700, "hw", Call(hw_2620, V.Undef, Arr(((V)((ToNum(Add(GetIdx(Get(s_2700, "b1"), 0D), GetIdx(Get(s_2700, "b2"), 0D))) / 2D))), ((V)((ToNum(Add(GetIdx(Get(s_2700, "b1"), 1D), GetIdx(Get(s_2700, "b2"), 1D))) / 2D))), ((V)((ToNum(Add(GetIdx(Get(s_2700, "b1"), 2D), GetIdx(Get(s_2700, "b2"), 2D))) / 2D))))));
return default;
}, 1, "", true));
}
W2_2625 = Fn((V _arrowThis2710, int _argc2702, V X_2708, V Y_2709, V _a2706, V _a2707, V[] _rest2703) => {
V w_2711 = default;
V a_2712 = default;
V b_2713 = default;
w_2711 = Call(SM_16, V.Undef, ((V)(((ToNum(NY_918) - ToNum(Y_2709)) / 12D))));
if (LeN(w_2711, 0D)) {
return Call(glob_942, V.Undef, X_2708, Y_2709);
}
a_2712 = Call(headT_948, V.Undef, X_2708, Y_2709);
if (GeN(w_2711, 1D)) {
return a_2712;
}
b_2713 = Call(glob_942, V.Undef, X_2708, Y_2709);
return Arr(Add(GetIdx(b_2713, 0D), ((V)(((ToNum(GetIdx(a_2712, 0D)) - ToNum(GetIdx(b_2713, 0D))) * ToNum(w_2711))))), Add(GetIdx(b_2713, 1D), ((V)(((ToNum(GetIdx(a_2712, 1D)) - ToNum(GetIdx(b_2713, 1D))) * ToNum(w_2711))))));
return default;
}, 2, "", true);
surf_2626 = Fn((V _arrowThis2722, int _argc2714, V X_2720, V Y_2721, V _a2718, V _a2719, V[] _rest2715) => {
double a_2723 = 0;
double b_2724 = 0;
a_2723 = ((1D - Pow(((ToNum(X_2720) - ToNum(HX_910)) / ToNum(SR_913)), 2D)) - Pow(((ToNum(Y_2721) - ToNum(HY_911)) / ToNum(SRY_915)), 2D));
b_2724 = ((1D - Pow(((ToNum(X_2720) - ToNum(BX0_2615)) / ToNum(BW0_2617)), 2D)) - Pow(((ToNum(Y_2721) - ToNum(BY0_2616)) / ToNum(BH0_2618)), 2D));
return ((V)(Max(((a_2723 > 0D) ? (ToNum(SR_913) * System.Math.Sqrt(a_2723)) : (-1000000000D)), ((b_2724 > 0D) ? (BZ_2619 * System.Math.Sqrt(b_2724)) : (-1000000000D)))));
return default;
}, 2, "", true);
S_2627 = Invoke(Get(K_2611, "G"), "map", Fn((V _arrowThis2733, int _argc2725, V row_2731, V j_2732, V _a2729, V _a2730, V[] _rest2726) => {
return Invoke(row_2731, "map", Fn((V _arrowThis2742, int _argc2734, V p_2740, V i_2741, V _a2738, V _a2739, V[] _rest2735) => {
V q_2743 = default;
q_2743 = Call(rot_2622, V.Undef, p_2740, GetK(GetK(Get(K_2611, "GW"), j_2732), i_2741));
return NewObj(2).Put("q", q_2743).Put("w", Call(W2_2625, V.Undef, GetIdx(q_2743, 0D), GetIdx(q_2743, 1D))).V;
return default;
}, 2, "", true));
}, 2, "", true));
na_2628 = Get(Get(K_2611, "A"), "length");
dB_2629 = new JsStrBuf("");
dF_2630 = new JsStrBuf("");
{
double j_2744 = 0;
j_2744 = 0D;
while (true) {
if (!((j_2744 < (ToNum(Get(Get(K_2611, "B"), "length")) - 1D)))) break;
{
double i_2746 = 0;
i_2746 = 0D;
while (true) {
if (!(Lt(((V)(i_2746)), na_2628))) break;
double i2_2748 = 0;
V c_2749 = default;
V w_2750 = default;
double ar_2751 = 0;
V d_2752 = default;
i2_2748 = ((i_2746 + 1D) % ToNum(na_2628));
c_2749 = Arr(GetIdx(GetIdx(S_2627, j_2744), i_2746), GetIdx(GetIdx(S_2627, j_2744), i2_2748), GetIdx(GetIdx(S_2627, (j_2744 + 1D)), i2_2748), GetIdx(GetIdx(S_2627, (j_2744 + 1D)), i_2746));
w_2750 = Invoke(c_2749, "map", Fn((V _arrowThis2760, int _argc2753, V o_2759, V _a2756, V _a2757, V _a2758, V[] _rest2754) => {
return Get(o_2759, "w");
}, 1, "", true));
ar_2751 = 0D;
{
double k_2761 = 0;
k_2761 = 0D;
while (true) {
if (!((k_2761 < 4D))) break;
V a_2763 = default;
V b_2764 = default;
a_2763 = GetIdx(w_2750, k_2761);
b_2764 = GetIdx(w_2750, ((k_2761 + 1D) % 4D));
ar_2751 = (ar_2751 + ((ToNum(GetIdx(a_2763, 0D)) * ToNum(GetIdx(b_2764, 1D))) - (ToNum(GetIdx(b_2764, 0D)) * ToNum(GetIdx(a_2763, 1D)))));
k_2761++;
}
}
if ((ar_2751 < 0D)) {
Invoke(w_2750, "reverse");
}
d_2752 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(w_2750, "map", p2s_2624), "join", ((V)(" L")))).S("Z").End()));
dB_2629.V(d_2752);
if (GtN(Call(fac_2623, V.Undef, GetIdx(GetIdx(Get(K_2611, "QN"), j_2744), i_2746), ((V)((ToNum(Add(GetIdx(GetIdx(Get(K_2611, "GW"), j_2744), i_2746), GetIdx(GetIdx(Get(K_2611, "GW"), (j_2744 + 1D)), ((i_2746 + 1D) % ToNum(na_2628))))) / 2D)))), 0.02)) {
double mx_2765 = 0;
double my_2766 = 0;
double mz_2767 = 0;
mx_2765 = (ToNum(Add(GetIdx(Get(GetIdx(c_2749, 0D), "q"), 0D), GetIdx(Get(GetIdx(c_2749, 2D), "q"), 0D))) / 2D);
my_2766 = (ToNum(Add(GetIdx(Get(GetIdx(c_2749, 0D), "q"), 1D), GetIdx(Get(GetIdx(c_2749, 2D), "q"), 1D))) / 2D);
mz_2767 = (ToNum(Add(Add(Add(GetIdx(Get(GetIdx(c_2749, 0D), "q"), 2D), GetIdx(Get(GetIdx(c_2749, 1D), "q"), 2D)), GetIdx(Get(GetIdx(c_2749, 2D), "q"), 2D)), GetIdx(Get(GetIdx(c_2749, 3D), "q"), 2D))) / 4D);
if ((mz_2767 > (ToNum(Call(surf_2626, V.Undef, ((V)(mx_2765)), ((V)(my_2766)))) - 1.5))) {
dF_2630.V(d_2752);
}
}
i_2746++;
}
}
j_2744++;
}
}
LS_2631 = Arr(Arr(), Arr(), Arr());
Invoke(Get(K_2611, "sp"), "forEach", Fn((V _arrowThis2775, int _argc2768, V s_2774, V _a2771, V _a2772, V _a2773, V[] _rest2769) => {
V bc_2776 = default;
V t3_2777 = default;
V q1_2778 = default;
V q2_2779 = default;
V qt_2780 = default;
V f_2781 = default;
double k_2782 = 0;
double wob_2783 = 0;
V A1_2784 = default;
V A2_2785 = default;
V At_2786 = default;
double tx_2787 = 0;
double ty_2788 = 0;
V tl_2789 = default;
V Tp_2790 = default;
double vis_2791 = 0;
V qc_2792 = default;
V front_2793 = default;
bc_2776 = Arr(((V)((ToNum(Add(GetIdx(Get(s_2774, "b1"), 0D), GetIdx(Get(s_2774, "b2"), 0D))) / 2D))), ((V)((ToNum(Add(GetIdx(Get(s_2774, "b1"), 1D), GetIdx(Get(s_2774, "b2"), 1D))) / 2D))), ((V)((ToNum(Add(GetIdx(Get(s_2774, "b1"), 2D), GetIdx(Get(s_2774, "b2"), 2D))) / 2D))));
t3_2777 = Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis2801, int _argc2794, V k_2800, V _a2797, V _a2798, V _a2799, V[] _rest2795) => {
return Add(GetK(bc_2776, k_2800), ((V)(((ToNum(GetK(Get(s_2774, "t"), k_2800)) - ToNum(GetK(bc_2776, k_2800))) * grow_2614))));
}, 1, "", true));
q1_2778 = Call(rot_2622, V.Undef, Get(s_2774, "b1"), Get(s_2774, "hw"));
q2_2779 = Call(rot_2622, V.Undef, Get(s_2774, "b2"), Get(s_2774, "hw"));
qt_2780 = Call(rot_2622, V.Undef, t3_2777, Get(s_2774, "hw"));
f_2781 = Call(fac_2623, V.Undef, Get(s_2774, "n"), Get(s_2774, "hw"));
k_2782 = (ToNum(Get(s_2774, "len")) / 10D);
wob_2783 = ((FdLibm.Sin(((ToNum(now_904) / 520D) + (ToNum(Get(s_2774, "i")) * 1.7))) * 0.25) * k_2782);
A1_2784 = Call(W2_2625, V.Undef, GetIdx(q1_2778, 0D), GetIdx(q1_2778, 1D));
A2_2785 = Call(W2_2625, V.Undef, GetIdx(q2_2779, 0D), GetIdx(q2_2779, 1D));
At_2786 = Call(W2_2625, V.Undef, GetIdx(qt_2780, 0D), GetIdx(qt_2780, 1D));
{
double mx_2802 = 0;
double my_2803 = 0;
double ax_2804 = 0;
double ay_2805 = 0;
V al_2806 = default;
double px_2807 = 0;
double py_2808 = 0;
double hx_2809 = 0;
double hy_2810 = 0;
double dp_2811 = 0;
double need_2812 = 0;
mx_2802 = (ToNum(Add(GetIdx(A1_2784, 0D), GetIdx(A2_2785, 0D))) / 2D);
my_2803 = (ToNum(Add(GetIdx(A1_2784, 1D), GetIdx(A2_2785, 1D))) / 2D);
ax_2804 = (ToNum(GetIdx(At_2786, 0D)) - mx_2802);
ay_2805 = (ToNum(GetIdx(At_2786, 1D)) - my_2803);
al_2806 = (((V)(Hypot(ax_2804, ay_2805))) is var _t2813 && Truthy(_t2813) ? _t2813 : ((V)(1D)));
px_2807 = ((-ay_2805) / ToNum(al_2806));
py_2808 = (ax_2804 / ToNum(al_2806));
hx_2809 = ((ToNum(GetIdx(A2_2785, 0D)) - ToNum(GetIdx(A1_2784, 0D))) / 2D);
hy_2810 = ((ToNum(GetIdx(A2_2785, 1D)) - ToNum(GetIdx(A1_2784, 1D))) / 2D);
dp_2811 = ((hx_2809 * px_2807) + (hy_2810 * py_2808));
need_2812 = ((ToNum(Get(s_2774, "w")) * 0.8) - System.Math.Abs(dp_2811));
if ((need_2812 > 0D)) {
double sg_2814 = 0;
double nx_2815 = 0;
double ny_2816 = 0;
sg_2814 = ((dp_2811 < 0D) ? (-1D) : 1D);
nx_2815 = (hx_2809 + ((px_2807 * need_2812) * sg_2814));
ny_2816 = (hy_2810 + ((py_2808 * need_2812) * sg_2814));
A1_2784 = Arr(((V)((mx_2802 - nx_2815))), ((V)((my_2803 - ny_2816))));
A2_2785 = Arr(((V)((mx_2802 + nx_2815))), ((V)((my_2803 + ny_2816))));
}
}
tx_2787 = (ToNum(GetIdx(A2_2785, 0D)) - ToNum(GetIdx(A1_2784, 0D)));
ty_2788 = (ToNum(GetIdx(A2_2785, 1D)) - ToNum(GetIdx(A1_2784, 1D)));
tl_2789 = (((V)(Hypot(tx_2787, ty_2788))) is var _t2817 && Truthy(_t2817) ? _t2817 : ((V)(1D)));
Tp_2790 = Arr(Add(Add(GetIdx(At_2786, 0D), ((V)(((ToNum(ed_2612) * 0.35) * k_2782)))), ((V)(((tx_2787 / ToNum(tl_2789)) * wob_2783)))), ((V)(((ToNum(GetIdx(At_2786, 1D)) - ((ToNum(ld_2613) * 0.3) * k_2782)) + ((ty_2788 / ToNum(tl_2789)) * wob_2783)))));
vis_2791 = (System.Math.Abs((((ToNum(GetIdx(Tp_2790, 0D)) - ToNum(GetIdx(A1_2784, 0D))) * ty_2788) - ((ToNum(GetIdx(Tp_2790, 1D)) - ToNum(GetIdx(A1_2784, 1D))) * tx_2787))) / (ToNum(tl_2789) * Max(1D, (ToNum(Get(s_2774, "len")) * grow_2614))));
qc_2792 = Arr(((V)((ToNum(Add(GetIdx(q1_2778, 0D), GetIdx(q2_2779, 0D))) / 2D))), ((V)((ToNum(Add(GetIdx(q1_2778, 1D), GetIdx(q2_2779, 1D))) / 2D))), ((V)((ToNum(Add(GetIdx(q1_2778, 2D), GetIdx(q2_2779, 2D))) / 2D))));
front_2793 = ((GtN(f_2781, 0.1) && GtN(GetIdx(qc_2792, 2D), (ToNum(Call(surf_2626, V.Undef, GetIdx(qc_2792, 0D), GetIdx(qc_2792, 1D))) - 1.5))) ? V.True : V.False);
Invoke(GetIdx(LS_2631, (Truthy(front_2793) ? 2D : (LtN(f_2781, (-0.01)) ? 0D : 1D))), "push", Arr(((V)((ToNum(Add(GetIdx(qc_2792, 2D), GetIdx(qt_2780, 2D))) / 2D))), ((V)(JsStrBuf.Begin().S("M").V(Call(p2s_2624, V.Undef, A1_2784)).S(" L").V(Call(p2s_2624, V.Undef, Tp_2790)).S(" L").V(Call(p2s_2624, V.Undef, A2_2785)).End())), Call(r2_14, V.Undef, Call(SM_16, V.Undef, ((V)((vis_2791 * 3D)))))));
return default;
}, 1, "", true));
put_2632 = Fn((V _arrowThis2826, int _argc2818, V pool_2824, V list_2825, V _a2822, V _a2823, V[] _rest2819) => {
Invoke(list_2825, "sort", Fn((V _arrowThis2835, int _argc2827, V a_2833, V b_2834, V _a2831, V _a2832, V[] _rest2828) => {
return ((V)((ToNum(GetIdx(a_2833, 0D)) - ToNum(GetIdx(b_2834, 0D)))));
}, 2, "", true));
Invoke(pool_2824, "forEach", Fn((V _arrowThis2844, int _argc2836, V el_2842, V i_2843, V _a2840, V _a2841, V[] _rest2837) => {
V v_2845 = default;
V d_2846 = default;
V o_2847 = default;
v_2845 = GetK(list_2825, i_2843);
d_2846 = (Truthy(v_2845) ? GetIdx(v_2845, 1D) : ((V)("")));
o_2847 = (Truthy(v_2845) ? GetIdx(v_2845, 2D) : ((V)(1D)));
if (!SEq(Get(el_2842, "_d"), d_2846)) {
Set(el_2842, "_d", d_2846);
Call(set_964, V.Undef, el_2842, ((V)("d")), d_2846);
}
if (!SEq(Get(el_2842, "_o"), o_2847)) {
Set(el_2842, "_o", o_2847);
Call(set_964, V.Undef, el_2842, ((V)("stroke-opacity")), o_2847);
}
return default;
}, 2, "", true));
return default;
}, 2, "", true);
Call(put_2632, V.Undef, Get(Get(E_907, "hog"), "pre"), GetIdx(LS_2631, 0D));
Call(put_2632, V.Undef, Get(Get(E_907, "hog"), "post"), GetIdx(LS_2631, 1D));
Call(put_2632, V.Undef, Get(Get(E_907, "hog"), "fs"), GetIdx(LS_2631, 2D));
Call(set_964, V.Undef, Get(Get(E_907, "hog"), "domeB"), ((V)("d")), ((V)(dB_2629.Str)));
Call(set_964, V.Undef, Get(Get(E_907, "hog"), "domeF"), ((V)("d")), ((V)(dF_2630.Str)));
} else {
if (Truthy((Get(E_907, "mane") is var _t2848 && !Truthy(_t2848) ? _t2848 : Get(R_906, "spk")))) {
V K_2849 = default;
V cx0_2850 = default;
V cy0_2851 = default;
double grow_2852 = 0;
V tris_2853 = default;
double cY_2854 = 0;
double sY_2855 = 0;
V rot_2856 = default;
V pth_2857 = default;
K_2849 = Get(R_906, "spk");
{ V _t2858 = Get(K_2849, "C");
{ V _t2859 = ListOf(_t2858);
{ V _t2860 = GetIdx(_t2859, 0D);
cx0_2850 = _t2860; }
{ V _t2861 = GetIdx(_t2859, 1D);
cy0_2851 = _t2861; }
} }
grow_2852 = (1D + (ToNum(Call(clamp_13, V.Undef, Get(P_903, "wide"), ((V)(0D)), ((V)(1D)))) * 0.12));
tris_2853 = Arr();
cY_2854 = FdLibm.Cos(yh_920);
sY_2855 = FdLibm.Sin(yh_920);
rot_2856 = Fn((V _arrowThis2869, int _argc2862, V v_2868, V _a2865, V _a2866, V _a2867, V[] _rest2863) => {
double x1_2870 = 0;
double z0_2871 = 0;
x1_2870 = ((ToNum(GetIdx(v_2868, 0D)) * cY_2854) + (ToNum(GetIdx(v_2868, 2D)) * sY_2855));
z0_2871 = (((-ToNum(GetIdx(v_2868, 0D))) * sY_2855) + (ToNum(GetIdx(v_2868, 2D)) * cY_2854));
return Arr(((V)(x1_2870)), ((V)(((ToNum(GetIdx(v_2868, 1D)) * cp_929) - (z0_2871 * sp_930)))), ((V)(((ToNum(GetIdx(v_2868, 1D)) * sp_930) + (z0_2871 * cp_929)))));
return default;
}, 1, "", true);
{
foreach (V _k2872 in new JsIter(Get(K_2849, "list"))) {
V q_2873 = default;
q_2873 = _k2872;
double sT_2874 = 0;
double ct2_2875 = 0;
double st2_2876 = 0;
V d_2877 = default;
V tg_2878 = default;
V pr_2879 = default;
sT_2874 = FdLibm.Sin(ToNum(Get(q_2873, "th")));
ct2_2875 = FdLibm.Cos(ToNum(Get(q_2873, "t")));
st2_2876 = FdLibm.Sin(ToNum(Get(q_2873, "t")));
d_2877 = Call(rot_2856, V.Undef, Arr(((V)((sT_2874 * ct2_2875))), ((V)((sT_2874 * st2_2876))), ((V)((-FdLibm.Cos(ToNum(Get(q_2873, "th"))))))));
tg_2878 = Call(rot_2856, V.Undef, (Truthy(Get(q_2873, "th")) ? Arr(((V)((-st2_2876))), ((V)(ct2_2875)), ((V)(0D))) : Arr(((V)(1D)), ((V)(0D)), ((V)(0D)))));
pr_2879 = Fn((V _arrowThis2888, int _argc2880, V rr_2886, V ww_2887, V _a2884, V _a2885, V[] _rest2881) => {
return Call(headT_948, V.Undef, Add(Add(cx0_2850, ((V)((ToNum(GetIdx(d_2877, 0D)) * ToNum(rr_2886))))), ((V)((ToNum(GetIdx(tg_2878, 0D)) * ToNum(ww_2887))))), Add(Add(cy0_2851, ((V)((ToNum(GetIdx(d_2877, 1D)) * ToNum(rr_2886))))), ((V)((ToNum(GetIdx(tg_2878, 1D)) * ToNum(ww_2887))))));
}, 2, "", true);
Invoke(tris_2853, "push", Arr(GetIdx(d_2877, 2D), Call(pr_2879, V.Undef, ((V)((ToNum(Get(K_2849, "rb")) * 0.9))), Get(K_2849, "w")), Call(pr_2879, V.Undef, ((V)((ToNum(Get(K_2849, "rt")) * grow_2852))), ((V)(0D))), Call(pr_2879, V.Undef, ((V)((ToNum(Get(K_2849, "rb")) * 0.9))), ((V)((-ToNum(Get(K_2849, "w"))))))));
}
}
Invoke(tris_2853, "sort", Fn((V _arrowThis2897, int _argc2889, V a_2895, V b_2896, V _a2893, V _a2894, V[] _rest2890) => {
return ((V)((ToNum(GetIdx(a_2895, 0D)) - ToNum(GetIdx(b_2896, 0D)))));
}, 2, "", true));
pth_2857 = Fn((V _arrowThis2905, int _argc2898, V L_2904, V _a2901, V _a2902, V _a2903, V[] _rest2899) => {
return Invoke(Invoke(L_2904, "map", Fn((V _arrowThis2921, int _argc2906, V _a2908, V _a2909, V _a2910, V _a2911, V[] _rest2907) => {
V z_2914 = default;
V a_2916 = default;
V b_2918 = default;
V c_2920 = default;
{ V _t2912 = ListOf(_a2908);
{ V _t2913 = GetIdx(_t2912, 0D);
z_2914 = _t2913; }
{ V _t2915 = GetIdx(_t2912, 1D);
a_2916 = _t2915; }
{ V _t2917 = GetIdx(_t2912, 2D);
b_2918 = _t2917; }
{ V _t2919 = GetIdx(_t2912, 3D);
c_2920 = _t2919; }
}
return ((V)(JsStrBuf.Begin().S("M").V(Call(r2_14, V.Undef, GetIdx(a_2916, 0D))).S(" ").V(Call(r2_14, V.Undef, GetIdx(a_2916, 1D))).S(" L").V(Call(r2_14, V.Undef, GetIdx(b_2918, 0D))).S(" ").V(Call(r2_14, V.Undef, GetIdx(b_2918, 1D))).S(" L").V(Call(r2_14, V.Undef, GetIdx(c_2920, 0D))).S(" ").V(Call(r2_14, V.Undef, GetIdx(c_2920, 1D))).S("Z").End()));
}, 1, "", true)), "join", ((V)(" ")));
}, 1, "", true);
Call(set_964, V.Undef, Get(E_907, "mane"), ((V)("d")), Call(pth_2857, V.Undef, Invoke(tris_2853, "filter", Fn((V _arrowThis2929, int _argc2922, V t_2928, V _a2925, V _a2926, V _a2927, V[] _rest2923) => {
return (LtN(GetIdx(t_2928, 0D), 0.18) ? V.True : V.False);
}, 1, "", true))));
if (Truthy(Get(E_907, "maneF"))) {
Call(set_964, V.Undef, Get(E_907, "maneF"), ((V)("d")), Call(pth_2857, V.Undef, Invoke(tris_2853, "filter", Fn((V _arrowThis2937, int _argc2930, V t_2936, V _a2933, V _a2934, V _a2935, V[] _rest2931) => {
return (GeN(GetIdx(t_2936, 0D), 0.18) ? V.True : V.False);
}, 1, "", true))));
}
} else {
if (Truthy(Get(E_907, "mane"))) {
double k_2938 = 0;
double rp_2939 = 0;
double tt_2940 = 0;
V HC_2941 = default;
V T_2942 = default;
k_2938 = ((1D + (ToNum(Call(clamp_13, V.Undef, Get(P_903, "wide"), ((V)(0D)), ((V)(1D)))) * 0.1)) + (Max(0D, ToNum(sq_936)) * 0.05));
rp_2939 = (0.025 + (ToNum(Call(clamp_13, V.Undef, Get(P_903, "wide"), ((V)(0D)), ((V)(1D)))) * 0.05));
tt_2940 = (ToNum(now_904) / 260D);
HC_2941 = (Get(Get(D_905, "mane"), "c") is var _t2943 && Truthy(_t2943) ? _t2943 : Arr(HX_910, HY_911));
T_2942 = (SEqS(Get(Get(D_905, "mane"), "mode"), "body") ? glob_942 : headT_948);
Call(set_964, V.Undef, Get(E_907, "mane"), ((V)("d")), Call(toD_25, V.Undef, Get(R_906, "mane"), Fn((V _arrowThis2952, int _argc2944, V x_2950, V y_2951, V _a2948, V _a2949, V[] _rest2945) => {
double dx_2953 = 0;
double dy_2954 = 0;
double th_2955 = 0;
double m_2956 = 0;
dx_2953 = (ToNum(x_2950) - ToNum(GetIdx(HC_2941, 0D)));
dy_2954 = (ToNum(y_2951) - ToNum(GetIdx(HC_2941, 1D)));
th_2955 = FdLibm.Atan2(dy_2954, dx_2953);
m_2956 = (k_2938 * (1D + ((rp_2939 * ToNum(Call(clamp_13, V.Undef, Get(P_903, "wide"), ((V)(0D)), ((V)(1D))))) * FdLibm.Sin((th_2955 * 7D)))));
return Call(T_2942, V.Undef, Add(GetIdx(HC_2941, 0D), ((V)((dx_2953 * m_2956)))), Add(GetIdx(HC_2941, 1D), ((V)((dy_2954 * m_2956)))));
return default;
}, 2, "", true)));
}
}
}
}
Invoke((Get(E_907, "hx") is var _t2966 && Truthy(_t2966) ? _t2966 : Arr()), "forEach", Fn((V _arrowThis2965, int _argc2957, V el_2963, V i_2964, V _a2961, V _a2962, V[] _rest2958) => {
return Call(set_964, V.Undef, el_2963, ((V)("d")), Call(toD_25, V.Undef, GetK(Get(R_906, "hx"), i_2964), wrapF_954));
}, 2, "", true));
if (Truthy(Get(Get(E_907, "crown"), "length"))) {
double ang_2967 = 0;
V bx_2968 = default;
V by_2969 = default;
double c_2970 = 0;
double sn_2971 = 0;
ang_2967 = (((((ToNum(Get(P_903, "earR")) - ToNum(Get(P_903, "earL"))) * 0.25) - (ToNum((Get(I_902, "ed") is var _t2972 && Truthy(_t2972) ? _t2972 : ((V)(0D)))) * 2.5)) + (ToNum(Get(P_903, "htilt")) * 0.3)) * D2R_11);
{ V _t2973 = Get(D_905, "crownBase");
{ V _t2974 = ListOf(_t2973);
{ V _t2975 = GetIdx(_t2974, 0D);
bx_2968 = _t2975; }
{ V _t2976 = GetIdx(_t2974, 1D);
by_2969 = _t2976; }
} }
c_2970 = FdLibm.Cos(ang_2967);
sn_2971 = FdLibm.Sin(ang_2967);
Invoke(Get(E_907, "crown"), "forEach", Fn((V _arrowThis2985, int _argc2977, V el_2983, V i_2984, V _a2981, V _a2982, V[] _rest2978) => {
return Call(set_964, V.Undef, el_2983, ((V)("d")), Call(toD_25, V.Undef, GetK(Get(R_906, "crown"), i_2984), Fn((V _arrowThis2994, int _argc2986, V x_2992, V y_2993, V _a2990, V _a2991, V[] _rest2987) => {
double vx_2995 = 0;
double vy_2996 = 0;
vx_2995 = (ToNum(x_2992) - ToNum(bx_2968));
vy_2996 = (ToNum(y_2993) - ToNum(by_2969));
return Call(sph_950, V.Undef, ((V)((ToNum(Add(bx_2968, ((V)((vx_2995 * c_2970))))) - (vy_2996 * sn_2971)))), Add(Add(Add(Add(by_2969, ((V)((vx_2995 * sn_2971)))), ((V)((vy_2996 * c_2970)))), ((V)((Min(0D, ToNum(sq_936)) * 2D)))), (Get(D_905, "crownDy") is var _t2997 && Truthy(_t2997) ? _t2997 : ((V)(0D)))), (!Get(D_905, "crownZ").IsNullish ? Get(D_905, "crownZ") : ((V)((-3D)))));
return default;
}, 2, "", true)));
}, 2, "", true));
}
if (Truthy(Get(Get(E_907, "pup"), "length"))) {
V pcx_2998 = default;
V pcy_2999 = default;
V pr_3000 = default;
V BX_3001 = default;
V BY_3002 = default;
V BW_3003 = default;
V BH_3004 = default;
double t_3005 = 0;
double pdt_3006 = 0;
V pj_3007 = default;
double fb_3008 = 0;
double td_3009 = 0;
double tl_3010 = 0;
double ca_3011 = 0;
double sa_3012 = 0;
double sq_3013 = 0;
double bl_3014 = 0;
{ V _t3015 = (Get(D_905, "pupC") is var _t3016 && Truthy(_t3016) ? _t3016 : Arr(((V)(50D)), ((V)(71D)), ((V)(11D))));
{ V _t3017 = ListOf(_t3015);
{ V _t3018 = GetIdx(_t3017, 0D);
pcx_2998 = _t3018; }
{ V _t3019 = GetIdx(_t3017, 1D);
pcy_2999 = _t3019; }
{ V _t3020 = GetIdx(_t3017, 2D);
pr_3000 = _t3020; }
} }
{ V _t3021 = Get(D_905, "body");
{ V _t3022 = ListOf(_t3021);
{ V _t3023 = GetIdx(_t3022, 0D);
BX_3001 = _t3023; }
{ V _t3024 = GetIdx(_t3022, 1D);
BY_3002 = _t3024; }
{ V _t3025 = GetIdx(_t3022, 2D);
BW_3003 = _t3025; }
{ V _t3026 = GetIdx(_t3022, 3D);
BH_3004 = _t3026; }
} }
t_3005 = (ToNum(now_904) / 1000D);
pdt_3006 = (Truthy(Get(I_902, "pjT")) ? Min(0.05, ((ToNum(now_904) - ToNum(Get(I_902, "pjT"))) / 1000D)) : 0.016);
Set(I_902, "pjT", now_904);
Set(I_902, "pj", Add((Get(I_902, "pj") is var _t3027 && Truthy(_t3027) ? _t3027 : ((V)(0D))), ((V)((((Truthy(Invoke(NewRegExp(RX4, "dance", ""), "test", Get(Get(I_902, "cur"), "name"))) ? 1D : 0D) - ToNum((Get(I_902, "pj") is var _t3028 && Truthy(_t3028) ? _t3028 : ((V)(0D))))) * Min(1D, (pdt_3006 * 5D)))))));
pj_3007 = Call(SM_16, V.Undef, Get(I_902, "pj"));
fb_3008 = (ToNum(Add(pcy_2999, pr_3000)) - 1D);
td_3009 = ((((FdLibm.Sin((t_3005 * 1.3)) * 6D) * (1D - ToNum(pj_3007))) + ((FdLibm.Sin(((t_3005 * System.Math.PI) * 2D)) * 9D) * ToNum(pj_3007))) + (ToNum(Call(clamp_13, V.Undef, (Get(I_902, "ed") is var _t3029 && Truthy(_t3029) ? _t3029 : ((V)(0D))), ((V)((-4D))), ((V)(4D)))) * 2D));
tl_3010 = (td_3009 * D2R_11);
ca_3011 = FdLibm.Cos(tl_3010);
sa_3012 = FdLibm.Sin(tl_3010);
sq_3013 = ((((FdLibm.Sin((t_3005 * 2.6)) * 0.03) * (1D - ToNum(pj_3007))) - ((ToNum(Call(clamp_13, V.Undef, (Get(P_903, "sq") is var _t3030 && Truthy(_t3030) ? _t3030 : ((V)(0D))), ((V)((-0.3))), ((V)(0.3)))) * 0.7) * ToNum(pj_3007))) + (ToNum(Call(clamp_13, V.Undef, (Get(I_902, "ld") is var _t3031 && Truthy(_t3031) ? _t3031 : ((V)(0D))), ((V)((-6D))), ((V)(6D)))) * 0.008));
bl_3014 = (((ToNum(now_904) % 3400D) < 150D) ? 0.12 : 1D);
Invoke(Get(E_907, "pup"), "forEach", Fn((V _arrowThis3040, int _argc3032, V el_3038, V i_3039, V _a3036, V _a3037, V[] _rest3033) => {
V h_3041 = default;
double ea_3042 = 0;
double ec_3043 = 0;
double es_3044 = 0;
double cs_3045 = 0;
h_3041 = GetK(Get(D_905, "pup"), i_3039);
ea_3042 = (Truthy(Get(h_3041, "ear")) ? ((((-ToNum(GetIdx(Get(h_3041, "ear"), 2D))) * (((5D + ((FdLibm.Sin(((t_3005 * 2.6) - 0.9)) * 5D) * (1D - ToNum(pj_3007)))) + ((System.Math.Abs(FdLibm.Sin((((t_3005 * System.Math.PI) * 2D) - 0.6))) * 16D) * ToNum(pj_3007))) + (ToNum(Call(clamp_13, V.Undef, (Get(I_902, "ld") is var _t3046 && Truthy(_t3046) ? _t3046 : ((V)(0D))), ((V)((-6D))), ((V)(6D)))) * 1.2))) * D2R_11) - ((td_3009 * 0.5) * D2R_11)) : 0D);
ec_3043 = FdLibm.Cos(ea_3042);
es_3044 = FdLibm.Sin(ea_3042);
cs_3045 = (Truthy(Get(h_3041, "cheek")) ? (1D + (ToNum(pj_3007) * 0.18)) : 1D);
if (Truthy((((Get(h_3041, "shine") is var _t3047 && Truthy(_t3047) ? _t3047 : Get(h_3041, "mouthLine")) is var _t3048 && Truthy(_t3048) ? _t3048 : Get(h_3041, "joy")) is var _t3049 && Truthy(_t3049) ? _t3049 : Get(h_3041, "cheek")))) {
Call(set_964, V.Undef, el_3038, ((V)("opacity")), Call(r2_14, V.Undef, (Truthy(Get(h_3041, "joy")) ? pj_3007 : ((V)((Truthy(Get(h_3041, "cheek")) ? Min(1D, ToNum(Add((Get(h_3041, "op") is var _t3050 && Truthy(_t3050) ? _t3050 : ((V)(1D))), ((V)((ToNum(pj_3007) * 0.4)))))) : (ToNum((Get(h_3041, "op") is var _t3051 && Truthy(_t3051) ? _t3051 : ((V)(1D)))) * (1D - ToNum(pj_3007)))))))));
}
Call(set_964, V.Undef, el_3038, ((V)("d")), Call(toD_25, V.Undef, GetK(Get(R_906, "pup"), i_3039), Fn((V _arrowThis3060, int _argc3052, V x_3058, V y_3059, V _a3056, V _a3057, V[] _rest3053) => {
double u0_3061 = 0;
double v0_3062 = 0;
double zp_3063 = 0;
double p_3064 = 0;
double q_3065 = 0;
double dx_3066 = 0;
V v_3067 = default;
double wc_3068 = 0;
double zb_3069 = 0;
if (Truthy(Get(h_3041, "eye"))) {
double dy_3070 = 0;
dy_3070 = (ToNum(y_3059) - ToNum(GetIdx(Get(h_3041, "eye"), 1D)));
y_3059 = ((V)(((ToNum(GetIdx(Get(h_3041, "eye"), 1D)) - (ToNum(pj_3007) * 0.5)) + (dy_3070 * ((dy_3070 > 0D) ? (bl_3014 * (1D - (1.75 * ToNum(pj_3007)))) : bl_3014)))));
}
if (Truthy(Get(h_3041, "joy"))) {
y_3059 = Add(GetIdx(Get(h_3041, "joy"), 1D), ((V)(((ToNum(y_3059) - ToNum(GetIdx(Get(h_3041, "joy"), 1D))) * Max(0.05, ToNum(pj_3007))))));
}
if (Truthy(Get(h_3041, "cheek"))) {
x_3058 = Add(GetIdx(Get(h_3041, "cheek"), 0D), ((V)(((ToNum(x_3058) - ToNum(GetIdx(Get(h_3041, "cheek"), 0D))) * cs_3045))));
y_3059 = Add(GetIdx(Get(h_3041, "cheek"), 1D), ((V)(((ToNum(y_3059) - ToNum(GetIdx(Get(h_3041, "cheek"), 1D))) * cs_3045))));
}
if (Truthy(Get(h_3041, "ear"))) {
double p_3071 = 0;
double q_3072 = 0;
p_3071 = (ToNum(x_3058) - ToNum(GetIdx(Get(h_3041, "ear"), 0D)));
q_3072 = (ToNum(y_3059) - ToNum(GetIdx(Get(h_3041, "ear"), 1D)));
x_3058 = ((V)((ToNum(Add(GetIdx(Get(h_3041, "ear"), 0D), ((V)((p_3071 * ec_3043))))) - (q_3072 * es_3044))));
y_3059 = Add(Add(GetIdx(Get(h_3041, "ear"), 1D), ((V)((p_3071 * es_3044)))), ((V)((q_3072 * ec_3043))));
}
u0_3061 = (ToNum(x_3058) - ToNum(pcx_2998));
v0_3062 = (ToNum(y_3059) - ToNum(pcy_2999));
zp_3063 = ((System.Math.Sqrt(Max(0D, (1D - (((u0_3061 * u0_3061) + (v0_3062 * v0_3062)) / (ToNum(pr_3000) * ToNum(pr_3000)))))) * ToNum(pr_3000)) * 0.5);
x_3058 = Add(pcx_2998, ((V)((u0_3061 * (1D - (sq_3013 * 0.5))))));
y_3059 = ((V)((fb_3008 + ((ToNum(y_3059) - fb_3008) * (1D + sq_3013)))));
p_3064 = (ToNum(x_3058) - ToNum(pcx_2998));
q_3065 = (ToNum(y_3059) - fb_3008);
x_3058 = ((V)((ToNum(Add(pcx_2998, ((V)((p_3064 * ca_3011))))) - (q_3065 * sa_3012))));
y_3059 = ((V)(((fb_3008 + (p_3064 * sa_3012)) + (q_3065 * ca_3011))));
dx_3066 = (ToNum(x_3058) - ToNum(BX_3001));
v_3067 = Call(clamp_13, V.Undef, ((V)(((ToNum(y_3059) - ToNum(BY_3002)) / ToNum(BH_3004)))), ((V)((-1D))), ((V)(1D)));
wc_3068 = (ToNum(BW_3003) * System.Math.Sqrt((1D - ((ToNum(v_3067) * ToNum(v_3067)) * 0.36))));
zb_3069 = System.Math.Sqrt(Max(0D, ((wc_3068 * wc_3068) - (dx_3066 * dx_3066))));
return Call(glob_942, V.Undef, Add(Add(BX_3001, ((V)((dx_3066 * cyb_925)))), ((V)(((zb_3069 + zp_3063) * syb_926)))), y_3059);
return default;
}, 2, "", true)));
return default;
}, 2, "", true));
Call(set_964, V.Undef, Get(Get(I_902, "pg"), "pup"), ((V)("opacity")), Call(r2_14, V.Undef, Call(SM_16, V.Undef, ((V)(((cyb_925 + 0.15) / 0.35))))));
}
if (Truthy(Get(E_907, "cr"))) {
V C_3073 = default;
V Q_3074 = default;
double N_3075 = 0;
V W_3076 = default;
V ty_3077 = default;
V keys2_3078 = default;
V RB_3079 = default;
V rS_3080 = default;
V pt_3081 = default;
V dep_3082 = default;
V P2_3083 = default;
V hx_3084 = default;
V cD_3085 = default;
V cB_3086 = default;
V cL_3087 = default;
V mix_3088 = default;
V vis_3089 = default;
double k0_3090 = 0;
V run_3091 = default;
V line_3092 = default;
Call(set_964, V.Undef, GetIdx(Get(Get(E_907, "cr"), "mk"), 0D), ((V)("d")), Invoke(Get(E_907, "body"), "getAttribute", ((V)("d"))));
Call(set_964, V.Undef, GetIdx(Get(Get(E_907, "cr"), "mk"), 1D), ((V)("d")), skD_967);
C_3073 = Get(Get(D_905, "collar"), "ring");
Q_3074 = Get(E_907, "cr");
N_3075 = 48D;
W_3076 = Get(C_3073, "w");
ty_3077 = Fn((V _arrowThis3100, int _argc3093, V t_3099, V _a3096, V _a3097, V _a3098, V[] _rest3094) => {
double c_3101 = 0;
c_3101 = FdLibm.Cos(ToNum(t_3099));
return Add(Get(C_3073, "ys"), ((V)(((ToNum(((c_3101 >= 0D) ? Get(C_3073, "af") : Get(C_3073, "ab"))) * c_3101) * c_3101))));
return default;
}, 1, "", true);
keys2_3078 = keys_970;
Set(keys2_3078, "collar", ((V)(1.5)));
RB_3079 = Get(D_905, "body");
rS_3080 = Fn((V _arrowThis3109, int _argc3102, V y_3108, V _a3105, V _a3106, V _a3107, V[] _rest3103) => {
double a_3110 = 0;
double b_3111 = 0;
a_3110 = ((ToNum(y_3108) - ToNum(HY_911)) / ToNum(SRY_915));
b_3111 = ((ToNum(y_3108) - ToNum(GetIdx(RB_3079, 1D))) / ToNum(GetIdx(RB_3079, 3D)));
return Add(((V)(Max((((a_3110 * a_3110) < 1D) ? (ToNum(SR_913) * System.Math.Sqrt((1D - (a_3110 * a_3110)))) : 0D), (((b_3111 * b_3111) < 1D) ? (ToNum(GetIdx(RB_3079, 2D)) * System.Math.Sqrt((1D - (b_3111 * b_3111)))) : 0D)))), (Get(C_3073, "pad") is var _t3112 && Truthy(_t3112) ? _t3112 : ((V)(0.25))));
return default;
}, 1, "", true);
pt_3081 = Fn((V _arrowThis3121, int _argc3113, V t_3119, V dy_3120, V _a3117, V _a3118, V[] _rest3114) => {
V y_3122 = default;
V r_3123 = default;
y_3122 = Add(Call(ty_3077, V.Undef, t_3119), dy_3120);
r_3123 = Call(rS_3080, V.Undef, y_3122);
return Call(byw_962, V.Undef, ((V)((50D + (ToNum(r_3123) * FdLibm.Sin(ToNum(t_3119)))))), y_3122, ((V)((ToNum(r_3123) * FdLibm.Cos(ToNum(t_3119))))));
return default;
}, 2, "", true);
dep_3082 = Fn((V _arrowThis3131, int _argc3124, V t_3130, V _a3127, V _a3128, V _a3129, V[] _rest3125) => {
return ((V)(((((-ToNum(Get(C_3073, "rx"))) * FdLibm.Sin(ToNum(t_3130))) * syb_926) + ((ToNum(Get(C_3073, "rz")) * FdLibm.Cos(ToNum(t_3130))) * cyb_925))));
}, 1, "", true);
P2_3083 = Fn((V _arrowThis3139, int _argc3132, V q_3138, V _a3135, V _a3136, V _a3137, V[] _rest3133) => {
return ((V)(JsStrBuf.Begin().V(Call(r2_14, V.Undef, GetIdx(q_3138, 0D))).S(" ").V(Call(r2_14, V.Undef, GetIdx(q_3138, 1D))).End()));
}, 1, "", true);
hx_3084 = Fn((V _arrowThis3147, int _argc3140, V c_3146, V _a3143, V _a3144, V _a3145, V[] _rest3141) => {
return Arr(((V)(ParseInt(Invoke(c_3146, "slice", ((V)(1D)), ((V)(3D))), ((V)(16D))))), ((V)(ParseInt(Invoke(c_3146, "slice", ((V)(3D)), ((V)(5D))), ((V)(16D))))), ((V)(ParseInt(Invoke(c_3146, "slice", ((V)(5D)), ((V)(7D))), ((V)(16D))))));
}, 1, "", true);
cD_3085 = Call(hx_3084, V.Undef, Get(C_3073, "dark"));
cB_3086 = Call(hx_3084, V.Undef, Get(Get(D_905, "collar"), "fill"));
cL_3087 = Call(hx_3084, V.Undef, Get(C_3073, "light"));
mix_3088 = Fn((V _arrowThis3157, int _argc3148, V a_3154, V b_3155, V f_3156, V _a3153, V[] _rest3149) => {
return Invoke(a_3154, "map", Fn((V _arrowThis3166, int _argc3158, V v_3164, V i_3165, V _a3162, V _a3163, V[] _rest3159) => {
return ((V)(Round(ToNum(Add(v_3164, ((V)(((ToNum(GetK(b_3155, i_3165)) - ToNum(v_3164)) * ToNum(f_3156)))))))));
}, 2, "", true));
}, 3, "", true);
vis_3089 = Arr();
{
double i_3167 = 0;
i_3167 = 0D;
while (true) {
if (!((i_3167 < N_3075))) break;
double t0_3169 = 0;
double t1_3170 = 0;
double tm_3171 = 0;
V seg_3172 = default;
double nx_3173 = 0;
double nz_3174 = 0;
V lam_3175 = default;
V col_3176 = default;
V cs_3177 = default;
t0_3169 = ((i_3167 / N_3075) * TAU_12);
t1_3170 = (((i_3167 + 1D) / N_3075) * TAU_12);
tm_3171 = ((t0_3169 + t1_3170) / 2D);
seg_3172 = GetIdx(Get(Q_3074, "segs"), i_3167);
if (LeN(Call(dep_3082, V.Undef, ((V)(tm_3171))), 0D)) {
Invoke(seg_3172, "setAttribute", ((V)("d")), ((V)("")));
goto _cont3168;
}
Invoke(vis_3089, "push", ((V)(i_3167)));
nx_3173 = ((FdLibm.Sin(tm_3171) * cyb_925) + (FdLibm.Cos(tm_3171) * syb_926));
nz_3174 = (((-FdLibm.Sin(tm_3171)) * syb_926) + (FdLibm.Cos(tm_3171) * cyb_925));
lam_3175 = Call(clamp_13, V.Undef, ((V)(((((-0.42) * nx_3173) + (0.9 * nz_3174)) / 0.993))), ((V)(0D)), ((V)(1D)));
col_3176 = (LtN(lam_3175, 0.6) ? Call(mix_3088, V.Undef, cD_3085, cB_3086, ((V)((ToNum(lam_3175) / 0.6)))) : Call(mix_3088, V.Undef, cB_3086, cL_3087, ((V)((((ToNum(lam_3175) - 0.6) / 0.4) * 0.45)))));
cs_3177 = ((V)(JsStrBuf.Begin().S("rgb(").V(Invoke(col_3176, "join", ((V)(",")))).S(")").End()));
Call(set_964, V.Undef, seg_3172, ((V)("d")), ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Arr(Call(pt_3081, V.Undef, ((V)(t0_3169)), ((V)(0D))), Call(pt_3081, V.Undef, ((V)(t1_3170)), ((V)(0D))), Call(pt_3081, V.Undef, ((V)(t1_3170)), W_3076), Call(pt_3081, V.Undef, ((V)(t0_3169)), W_3076)), "map", P2_3083), "join", ((V)("L")))).S("Z").End())));
Call(set_964, V.Undef, seg_3172, ((V)("fill")), cs_3177);
Call(set_964, V.Undef, seg_3172, ((V)("stroke")), cs_3177);
_cont3168: ;
i_3167++;
}
}
k0_3090 = 0D;
{
double j_3178 = 0;
j_3178 = 0D;
while (true) {
if (!(Lt(((V)(j_3178)), Get(vis_3089, "length")))) break;
if (!SEqN(GetIdx(vis_3089, ((ToNum(Add(((V)(j_3178)), Get(vis_3089, "length"))) - 1D) % ToNum(Get(vis_3089, "length")))), ((ToNum(Add(GetIdx(vis_3089, j_3178), ((V)(N_3075)))) - 1D) % N_3075))) {
k0_3090 = j_3178;
break;
}
j_3178++;
}
}
run_3091 = Invoke(Invoke(vis_3089, "slice", ((V)(k0_3090))), "concat", Invoke(vis_3089, "slice", ((V)(0D)), ((V)(k0_3090))));
line_3092 = Fn((V _arrowThis3187, int _argc3180, V dy_3186, V _a3183, V _a3184, V _a3185, V[] _rest3181) => {
return ((V)((Truthy(Get(run_3091, "length")) ? JsStrBuf.Begin().S("M").V(Invoke(Invoke(Invoke(run_3091, "map", Fn((V _arrowThis3195, int _argc3188, V i_3194, V _a3191, V _a3192, V _a3193, V[] _rest3189) => {
return Call(P2_3083, V.Undef, Call(pt_3081, V.Undef, ((V)(((ToNum(i_3194) / N_3075) * TAU_12))), dy_3186));
}, 1, "", true)), "concat", Arr(Call(P2_3083, V.Undef, Call(pt_3081, V.Undef, ((V)(((ToNum(Add(GetIdx(run_3091, (ToNum(Get(run_3091, "length")) - 1D)), ((V)(1D)))) / N_3075) * TAU_12))), dy_3186)))), "join", ((V)("L")))).End() : "")));
}, 1, "", true);
Call(set_964, V.Undef, Get(Q_3074, "sh"), ((V)("d")), Call(line_3092, V.Undef, Add(W_3076, ((V)(0.7)))));
Call(set_964, V.Undef, Get(Q_3074, "hl"), ((V)("d")), Call(line_3092, V.Undef, ((V)(0.45))));
Call(set_964, V.Undef, Get(Q_3074, "lo"), ((V)("d")), Call(line_3092, V.Undef, ((V)((ToNum(W_3076) - 0.35)))));
Call(set_964, V.Undef, Get(Q_3074, "st"), ((V)("d")), Call(line_3092, V.Undef, ((V)((ToNum(W_3076) * 0.5)))));
{
V db_3196 = default;
V o_3197 = default;
double d1_3198 = 0;
double d2_3199 = 0;
V Bq_3200 = default;
db_3196 = Call(dep_3082, V.Undef, ((V)(System.Math.PI)));
o_3197 = Call(SM_16, V.Undef, ((V)(((ToNum(db_3196) - 5D) / 5D))));
d1_3198 = (2.4 / ToNum(Get(C_3073, "rz")));
d2_3199 = (1.25 / ToNum(Get(C_3073, "rz")));
Bq_3200 = Fn((V _arrowThis3210, int _argc3201, V a_3207, V y0_3208, V y1_3209, V _a3206, V[] _rest3202) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Arr(Call(pt_3081, V.Undef, ((V)((System.Math.PI - ToNum(a_3207)))), y0_3208), Call(pt_3081, V.Undef, Add(((V)(System.Math.PI)), a_3207), y0_3208), Call(pt_3081, V.Undef, Add(((V)(System.Math.PI)), a_3207), y1_3209), Call(pt_3081, V.Undef, ((V)((System.Math.PI - ToNum(a_3207)))), y1_3209)), "map", P2_3083), "join", ((V)("L")))).S("Z").End()));
}, 3, "", true);
if (GtN(o_3197, 0.01)) {
Call(set_964, V.Undef, Get(Q_3074, "bk"), ((V)("d")), Call(Bq_3200, V.Undef, ((V)(d1_3198)), ((V)((-0.9))), Add(W_3076, ((V)(0.9)))));
Call(set_964, V.Undef, Get(Q_3074, "bki"), ((V)("d")), Call(Bq_3200, V.Undef, ((V)(d2_3199)), ((V)(0.25)), ((V)((ToNum(W_3076) - 0.25)))));
Call(set_964, V.Undef, Get(Q_3074, "bkp"), ((V)("d")), ((V)(JsStrBuf.Begin().S("M").V(Call(P2_3083, V.Undef, Call(pt_3081, V.Undef, ((V)((System.Math.PI - d2_3199))), ((V)((ToNum(W_3076) / 2D)))))).S("L").V(Call(P2_3083, V.Undef, Call(pt_3081, V.Undef, ((V)((System.Math.PI + (d1_3198 * 0.15)))), ((V)((ToNum(W_3076) / 2D)))))).End())));
} else {
Invoke(Arr(((V)("bk")), ((V)("bki")), ((V)("bkp"))), "forEach", Fn((V _arrowThis3218, int _argc3211, V k_3217, V _a3214, V _a3215, V _a3216, V[] _rest3212) => {
return Call(set_964, V.Undef, GetK(Q_3074, k_3217), ((V)("d")), ((V)("")));
}, 1, "", true));
}
Invoke(Arr(((V)("bk")), ((V)("bki")), ((V)("bkp"))), "forEach", Fn((V _arrowThis3226, int _argc3219, V k_3225, V _a3222, V _a3223, V _a3224, V[] _rest3220) => {
return Call(set_964, V.Undef, GetK(Q_3074, k_3225), ((V)("opacity")), Call(r2_14, V.Undef, o_3197));
}, 1, "", true));
}
{
V T_3227 = default;
V A_3228 = default;
V df_3229 = default;
V o_3230 = default;
V G2_3231 = default;
V dt_3232 = default;
double vx_3233 = 0;
double vy_3234 = 0;
V ax_3235 = default;
V ay_3236 = default;
V Lh_3237 = default;
double g_3238 = 0;
V a_3239 = default;
V rc_3240 = default;
V tc_3241 = default;
double fx_3242 = 0;
V rot_3243 = default;
T_3227 = Get(D_905, "tag");
A_3228 = Call(pt_3081, V.Undef, ((V)(0D)), Add(W_3076, ((V)(0.2))));
df_3229 = Call(dep_3082, V.Undef, ((V)(0D)));
o_3230 = Call(SM_16, V.Undef, ((V)(((cyb_925 + 0.06) / 0.16))));
G2_3231 = (Get(I_902, "tgp") is var _t3244 && Truthy(_t3244) ? _t3244 : Set(I_902, "tgp", NewObj(7).Put("a", ((V)(0D))).Put("v", ((V)(0D))).Put("x", GetIdx(A_3228, 0D)).Put("y", GetIdx(A_3228, 1D)).Put("vx", ((V)(0D))).Put("vy", ((V)(0D))).Put("t", now_904).V));
dt_3232 = Call(clamp_13, V.Undef, ((V)(((ToNum(now_904) - ToNum(Get(G2_3231, "t"))) / 1000D))), ((V)(0.001)), ((V)(0.05)));
vx_3233 = ((ToNum(GetIdx(A_3228, 0D)) - ToNum(Get(G2_3231, "x"))) / ToNum(dt_3232));
vy_3234 = ((ToNum(GetIdx(A_3228, 1D)) - ToNum(Get(G2_3231, "y"))) / ToNum(dt_3232));
ax_3235 = Call(clamp_13, V.Undef, ((V)(((vx_3233 - ToNum(Get(G2_3231, "vx"))) / ToNum(dt_3232)))), ((V)((-4000D))), ((V)(4000D)));
ay_3236 = Call(clamp_13, V.Undef, ((V)(((vy_3234 - ToNum(Get(G2_3231, "vy"))) / ToNum(dt_3232)))), ((V)((-4000D))), ((V)(4000D)));
Lh_3237 = Add(Get(T_3227, "r"), ((V)(1.7)));
g_3238 = 700D;
OpSet(G2_3231, "v", 0, ((V)(((((((-(g_3238 - ToNum(ay_3236))) / ToNum(Lh_3237)) * FdLibm.Sin(ToNum(Get(G2_3231, "a")))) - ((ToNum(ax_3235) / ToNum(Lh_3237)) * FdLibm.Cos(ToNum(Get(G2_3231, "a"))))) - (3.2 * ToNum(Get(G2_3231, "v")))) * ToNum(dt_3232)))));
Set(G2_3231, "a", Call(clamp_13, V.Undef, Add(Get(G2_3231, "a"), ((V)((ToNum(Get(G2_3231, "v")) * ToNum(dt_3232))))), ((V)((-0.95))), ((V)(0.95))));
Set(G2_3231, "x", GetIdx(A_3228, 0D));
Set(G2_3231, "y", GetIdx(A_3228, 1D));
Set(G2_3231, "vx", ((V)(vx_3233)));
Set(G2_3231, "vy", ((V)(vy_3234)));
Set(G2_3231, "t", now_904);
a_3239 = Add(Get(G2_3231, "a"), ((V)((FdLibm.Sin((ToNum(now_904) / 900D)) * 0.035))));
rc_3240 = Arr(Add(GetIdx(A_3228, 0D), ((V)((FdLibm.Sin(ToNum(a_3239)) * 1.1)))), Add(GetIdx(A_3228, 1D), ((V)((FdLibm.Cos(ToNum(a_3239)) * 1.1)))));
tc_3241 = Arr(Add(GetIdx(A_3228, 0D), ((V)((FdLibm.Sin(ToNum(a_3239)) * ToNum(Lh_3237))))), Add(GetIdx(A_3228, 1D), ((V)((FdLibm.Cos(ToNum(a_3239)) * ToNum(Lh_3237))))));
fx_3242 = (0.22 + (0.78 * System.Math.Abs(cyb_925)));
rot_3243 = ((V)(JsStrBuf.Begin().S("rotate(").V(Call(r2_14, V.Undef, ((V)(((-ToNum(a_3239)) / D2R_11))))).S(" ").V(Invoke(Call(P2_3083, V.Undef, tc_3241), "replace", ((V)(" ")), ((V)(" ")))).S(")").End()));
Call(set_964, V.Undef, Get(Q_3074, "rg"), ((V)("cx")), Call(r2_14, V.Undef, GetIdx(rc_3240, 0D)));
Call(set_964, V.Undef, Get(Q_3074, "rg"), ((V)("cy")), Call(r2_14, V.Undef, GetIdx(rc_3240, 1D)));
Call(set_964, V.Undef, Get(Q_3074, "rg"), ((V)("rx")), Call(r2_14, V.Undef, ((V)((1.05 * fx_3242)))));
Call(set_964, V.Undef, Get(Q_3074, "rg"), ((V)("ry")), ((V)(1.05)));
Invoke(Arr(Arr(Get(Q_3074, "tg"), ((V)(1D))), Arr(Get(Q_3074, "ti"), ((V)(0.62)))), "forEach", Fn((V _arrowThis3256, int _argc3245, V _a3247, V _a3248, V _a3249, V _a3250, V[] _rest3246) => {
V e_3253 = default;
V k_3255 = default;
{ V _t3251 = ListOf(_a3247);
{ V _t3252 = GetIdx(_t3251, 0D);
e_3253 = _t3252; }
{ V _t3254 = GetIdx(_t3251, 1D);
k_3255 = _t3254; }
}
Call(set_964, V.Undef, e_3253, ((V)("cx")), Call(r2_14, V.Undef, GetIdx(tc_3241, 0D)));
Call(set_964, V.Undef, e_3253, ((V)("cy")), Call(r2_14, V.Undef, GetIdx(tc_3241, 1D)));
Call(set_964, V.Undef, e_3253, ((V)("rx")), Call(r2_14, V.Undef, ((V)(((ToNum(Get(T_3227, "r")) * ToNum(k_3255)) * fx_3242)))));
Call(set_964, V.Undef, e_3253, ((V)("ry")), Call(r2_14, V.Undef, ((V)((ToNum(Get(T_3227, "r")) * ToNum(k_3255))))));
Call(set_964, V.Undef, e_3253, ((V)("transform")), rot_3243);
return default;
}, 1, "", true));
Call(set_964, V.Undef, Get(Q_3074, "gl"), ((V)("cx")), Call(r2_14, V.Undef, ((V)((ToNum(GetIdx(tc_3241, 0D)) - ((ToNum(Get(T_3227, "r")) * 0.38) * fx_3242))))));
Call(set_964, V.Undef, Get(Q_3074, "gl"), ((V)("cy")), Call(r2_14, V.Undef, ((V)((ToNum(GetIdx(tc_3241, 1D)) - (ToNum(Get(T_3227, "r")) * 0.42))))));
Call(set_964, V.Undef, Get(Q_3074, "gl"), ((V)("rx")), Call(r2_14, V.Undef, ((V)(((ToNum(Get(T_3227, "r")) * 0.3) * fx_3242)))));
Call(set_964, V.Undef, Get(Q_3074, "gl"), ((V)("ry")), Call(r2_14, V.Undef, ((V)((ToNum(Get(T_3227, "r")) * 0.2)))));
Call(set_964, V.Undef, Get(Q_3074, "gl"), ((V)("transform")), rot_3243);
Invoke(Arr(Get(Q_3074, "rg"), Get(Q_3074, "tg"), Get(Q_3074, "ti")), "forEach", Fn((V _arrowThis3264, int _argc3257, V e_3263, V _a3260, V _a3261, V _a3262, V[] _rest3258) => {
return Call(set_964, V.Undef, e_3263, ((V)("opacity")), Call(r2_14, V.Undef, o_3230));
}, 1, "", true));
Call(set_964, V.Undef, Get(Q_3074, "gl"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ToNum(o_3230) * 0.75)))));
}
}
if (Truthy(Get(E_907, "collar"))) {
if (Truthy(Get(Get(D_905, "collar"), "head"))) {
V T_3265 = default;
double fa_3266 = 0;
double ca_3267 = 0;
double sa_3268 = 0;
double fl_3269 = 0;
T_3265 = (Get(D_905, "tag") is var _t3270 && Truthy(_t3270) ? _t3270 : NewObj(2).Put("x", ((V)(50D))).Put("y", ((V)(66D))).V);
fa_3266 = (((((((-ToNum((Get(I_902, "ed") is var _t3271 && Truthy(_t3271) ? _t3271 : ((V)(0D))))) * 4D) + (ToNum(Get(P_903, "lean")) * 1.5)) + (ToNum(Get(P_903, "htilt")) * 0.4)) - (ToNum((Get(I_902, "ld") is var _t3272 && Truthy(_t3272) ? _t3272 : ((V)(0D)))) * 1.2)) + (FdLibm.Sin((ToNum(now_904) / 520D)) * 2D)) * D2R_11);
ca_3267 = FdLibm.Cos(fa_3266);
sa_3268 = FdLibm.Sin(fa_3266);
fl_3269 = ((1D + (FdLibm.Sin((ToNum(now_904) / 430D)) * 0.05)) + (ToNum(Call(clamp_13, V.Undef, (Get(I_902, "ld") is var _t3273 && Truthy(_t3273) ? _t3273 : ((V)(0D))), ((V)((-10D))), ((V)(10D)))) * 0.012));
Call(set_964, V.Undef, Get(E_907, "collar"), ((V)("d")), Call(toD_25, V.Undef, Get(R_906, "collar"), Fn((V _arrowThis3282, int _argc3274, V x_3280, V y_3281, V _a3278, V _a3279, V[] _rest3275) => {
double u_3283 = 0;
double v_3284 = 0;
u_3283 = ((ToNum(x_3280) - ToNum(Get(T_3265, "x"))) * fl_3269);
v_3284 = (ToNum(y_3281) - ToNum(Get(T_3265, "y")));
return Call(face_952, V.Undef, ((V)((ToNum(Add(Get(T_3265, "x"), ((V)((u_3283 * ca_3267))))) - (v_3284 * sa_3268)))), Add(Add(Get(T_3265, "y"), ((V)((u_3283 * sa_3268)))), ((V)((v_3284 * ca_3267)))));
return default;
}, 2, "", true)));
Call(set_964, V.Undef, Get(E_907, "collar"), ((V)("opacity")), Call(r2_14, V.Undef, Call(zc_956, V.Undef, Get(T_3265, "x"), Get(T_3265, "y"))));
} else {
if (Truthy(Get(Get(D_905, "collar"), "body"))) {
V T_3285 = default;
V cz_3286 = default;
double fa_3287 = 0;
double ca_3288 = 0;
double sa_3289 = 0;
double fl_3290 = 0;
T_3285 = Get(D_905, "tag");
cz_3286 = (Get(Get(D_905, "collar"), "z") is var _t3291 && Truthy(_t3291) ? _t3291 : ((V)(14D)));
fa_3287 = ((((FdLibm.Sin((ToNum(now_904) / 520D)) * 3D) + (ToNum(Get(P_903, "lean")) * 1.5)) - (ToNum((Get(I_902, "ld") is var _t3292 && Truthy(_t3292) ? _t3292 : ((V)(0D)))) * 1.2)) * D2R_11);
ca_3288 = FdLibm.Cos(fa_3287);
sa_3289 = FdLibm.Sin(fa_3287);
fl_3290 = (1D + (FdLibm.Sin((ToNum(now_904) / 430D)) * 0.05));
Call(set_964, V.Undef, Get(E_907, "collar"), ((V)("d")), Call(toD_25, V.Undef, Get(R_906, "collar"), Fn((V _arrowThis3301, int _argc3293, V x_3299, V y_3300, V _a3297, V _a3298, V[] _rest3294) => {
double u_3302 = 0;
double v_3303 = 0;
u_3302 = ((ToNum(x_3299) - ToNum(Get(T_3285, "x"))) * fl_3290);
v_3303 = (ToNum(y_3300) - ToNum(Get(T_3285, "y")));
return Call(byw_962, V.Undef, ((V)((ToNum(Add(Get(T_3285, "x"), ((V)((u_3302 * ca_3288))))) - (v_3303 * sa_3289)))), Add(Add(Get(T_3285, "y"), ((V)((u_3302 * sa_3289)))), ((V)((v_3303 * ca_3288)))), cz_3286);
return default;
}, 2, "", true)));
Call(set_964, V.Undef, Get(E_907, "collar"), ((V)("opacity")), Call(r2_14, V.Undef, Call(SM_16, V.Undef, ((V)((ToNum(Call(bywZ_963, V.Undef, Get(T_3285, "x"), cz_3286)) / 4D))))));
} else {
Call(set_964, V.Undef, Get(E_907, "collar"), ((V)("d")), Call(toD_25, V.Undef, Get(R_906, "collar"), glob_942));
}
}
}
if (Truthy((Get(E_907, "tag") is var _t3304 && !Truthy(_t3304) ? _t3304 : Get(Get(D_905, "collar"), "head")))) {
V T_3305 = default;
T_3305 = Get(D_905, "tag");
Call(set_964, V.Undef, Get(E_907, "tag"), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, Get(T_3305, "x"), Get(T_3305, "y"), Get(T_3305, "r"), Get(T_3305, "r"), ((V)(0D)), ((V)(8D))), face_952));
Call(set_964, V.Undef, Get(E_907, "tag"), ((V)("opacity")), Call(r2_14, V.Undef, Call(zc_956, V.Undef, Get(T_3305, "x"), Get(T_3305, "y"))));
} else {
if (Truthy((Get(E_907, "tag") is var _t3306 && !Truthy(_t3306) ? _t3306 : Get(Get(D_905, "collar"), "body")))) {
V T_3307 = default;
V cz_3308 = default;
T_3307 = Get(D_905, "tag");
cz_3308 = Add((Get(Get(D_905, "collar"), "z") is var _t3309 && Truthy(_t3309) ? _t3309 : ((V)(14D))), ((V)(0.5)));
Call(set_964, V.Undef, Get(E_907, "tag"), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, Get(T_3307, "x"), Get(T_3307, "y"), Get(T_3307, "r"), Get(T_3307, "r"), ((V)(0D)), ((V)(8D))), Fn((V _arrowThis3318, int _argc3310, V x_3316, V y_3317, V _a3314, V _a3315, V[] _rest3311) => {
return Call(byw_962, V.Undef, x_3316, y_3317, cz_3308);
}, 2, "", true)));
Call(set_964, V.Undef, Get(E_907, "tag"), ((V)("opacity")), Call(r2_14, V.Undef, Call(SM_16, V.Undef, ((V)((ToNum(Call(bywZ_963, V.Undef, Get(T_3307, "x"), cz_3308)) / 4D))))));
} else {
if (Truthy(Get(E_907, "tag"))) {
V T_3319 = default;
double sw_3320 = 0;
double cz_3321 = 0;
V tx_3322 = default;
V ty_3323 = default;
double X_3324 = 0;
T_3319 = Get(D_905, "tag");
sw_3320 = ((((((-ToNum((Get(I_902, "ed") is var _t3325 && Truthy(_t3325) ? _t3325 : ((V)(0D))))) * 6D) + (FdLibm.Sin((ToNum(now_904) / 360D)) * 4D)) + (ToNum(Get(P_903, "lean")) * 2D)) - (ToNum((Get(I_902, "ld") is var _t3326 && Truthy(_t3326) ? _t3326 : ((V)(0D)))) * 1.5)) * D2R_11);
cz_3321 = 13D;
tx_3322 = Add(Get(T_3319, "x"), ((V)(((FdLibm.Sin(sw_3320) * ToNum(Get(T_3319, "r"))) * 1.2))));
ty_3323 = Add(Get(T_3319, "y"), ((V)(((FdLibm.Cos(sw_3320) - 1D) * ToNum(Get(T_3319, "r"))))));
X_3324 = ((50D + ((ToNum(tx_3322) - 50D) * cyb_925)) + (cz_3321 * syb_926));
Call(set_964, V.Undef, Get(E_907, "tag"), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, ((V)(X_3324)), ty_3323, ((V)((ToNum(Get(T_3319, "r")) * (0.75 + (0.25 * System.Math.Abs(cyb_925)))))), Get(T_3319, "r"), ((V)(0D)), ((V)(8D))), glob_942));
Call(set_964, V.Undef, Get(E_907, "tag"), ((V)("opacity")), Call(r2_14, V.Undef, Call(SM_16, V.Undef, ((V)(((((-(ToNum(tx_3322) - 50D)) * syb_926) + (cz_3321 * cyb_925)) / 4D))))));
}
}
}
Set(I_902, "topW", Call(headT_948, V.Undef, ((V)(50D)), Get(D_905, "top")));
Set(Get(I_902, "W"), "head", Get(I_902, "topW"));
gl_985 = Max(0D, ToNum(Get(P_903, "lift")));
Call(set_964, V.Undef, Get(I_902, "shadow"), ((V)("cx")), Call(r2_14, V.Undef, Add(Add(((V)(50D)), Get(P_903, "x")), ((V)((ToNum(Get(P_903, "lean")) * 0.15))))));
Call(set_964, V.Undef, Get(I_902, "shadow"), ((V)("cy")), Call(r2_14, V.Undef, Add(G_908, ((V)(0.6)))));
Call(set_964, V.Undef, Get(I_902, "shadow"), ((V)("rx")), Call(r2_14, V.Undef, ((V)(((25D * (1D + (ToNum(sq_936) * 0.45))) * (1D - (gl_985 / 70D)))))));
Call(set_964, V.Undef, Get(I_902, "shadow"), ((V)("ry")), Call(r2_14, V.Undef, ((V)((3.6 * (1D - (gl_985 / 90D)))))));
Call(set_964, V.Undef, Get(I_902, "shadow"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((((0.2 * ToNum((Truthy((Get(I_902, "lt") is var _t3328 && !Truthy(_t3328) ? _t3328 : Get(Get(I_902, "lt"), "L"))) ? (Get(Get(Get(I_902, "lt"), "L"), "contact") is var _t3327 && Truthy(_t3327) ? _t3327 : ((V)(1D))) : ((V)(1D))))) * (1D - (gl_985 / 50D))) * (1D - ToNum(Call(clamp_13, V.Undef, (Get(P_903, "dbb") is var _t3329 && Truthy(_t3329) ? _t3329 : ((V)(0D))), ((V)(0D)), ((V)(1D))))))))));
if (Truthy(Get(I_902, "lt"))) {
Call(litTick_94, V.Undef, I_902, P_903, G_908, sq_936, ((V)(gl_985)));
}
if (Truthy((Get(I_902, "propArm") is var _t3330 && !Truthy(_t3330) ? _t3330 : (!GetK(keys_970, Get(I_902, "propArm")).IsNullish ? V.True : V.False)))) {
Set(keys_970, "prop", Add(GetK(keys_970, Get(I_902, "propArm")), (!Get(I_902, "propK").IsNullish ? Get(I_902, "propK") : ((V)(0.3)))));
}
order_986 = Invoke(Object_keys(keys_970), "sort", Fn((V _arrowThis3339, int _argc3331, V a_3337, V b_3338, V _a3335, V _a3336, V[] _rest3332) => {
return ((V)((ToNum(GetK(keys_970, a_3337)) - ToNum(GetK(keys_970, b_3338)))));
}, 2, "", true));
os_987 = Invoke(order_986, "join");
if (!SEq(os_987, Get(I_902, "order"))) {
Set(I_902, "order", os_987);
Invoke(order_986, "forEach", Fn((V _arrowThis3347, int _argc3340, V k_3346, V _a3343, V _a3344, V _a3345, V[] _rest3341) => {
V O_3348 = default;
V Q_3349 = default;
O_3348 = (((SEqS(k_3346, "tail") ? V.True : V.False) is var _t3350 && !Truthy(_t3350) ? _t3350 : Get(I_902, "lt")) is var _t3351 && !Truthy(_t3351) ? _t3351 : Get(Get(I_902, "lt"), "tailOL"));
if (Truthy(O_3348)) {
Invoke(Get(I_902, "root"), "appendChild", O_3348);
}
Invoke(Get(I_902, "root"), "appendChild", GetK(Get(I_902, "pg"), k_3346));
Q_3349 = (Get(I_902, "lt") is var _t3352 && !Truthy(_t3352) ? _t3352 : GetK(Get(Get(I_902, "lt"), "part"), k_3346));
if (Truthy(Q_3349)) {
Invoke(Get(I_902, "root"), "appendChild", Get(Q_3349, "g"));
}
return default;
}, 1, "", true));
if (Truthy(Get(I_902, "lt"))) {
Invoke(Get(I_902, "root"), "appendChild", Get(Get(I_902, "lt"), "gm"));
}
}
return default;
}, 3, "render", false);
coatBuild_63 = Fn((V _self3353, int _argc3354, V D_3360, V _a3357, V _a3358, V _a3359, V[] _rest3355) => {
V H_3361 = default;
V HX_3362 = default;
V HY_3363 = default;
V HR_3364 = default;
V SR_3365 = default;
V SRY_3366 = default;
V BX_3367 = default;
V BY_3368 = default;
V BW_3369 = default;
V BH_3370 = default;
double BZ_3371 = 0;
V SH_3372 = default;
V CX_3373 = default;
V CY_3374 = default;
V RX_3375 = default;
V RY_3376 = default;
V RZ_3377 = default;
V tab_3378 = default;
V hA_3379 = default;
V bA_3380 = default;
V dir_3381 = default;
V nrm_3382 = default;
V S_3383 = default;
V NY_3384 = default;
V NS_3385 = default;
V own_3386 = default;
V ang_3387 = default;
V cov_3388 = default;
V NA_3389 = default;
V NR_3390 = default;
double PM_3391 = 0;
V edge_3392 = default;
double zig_3393 = 0;
V mesh_3394 = default;
V hs_3395 = default;
V sp_3396 = default;
V n_3397 = default;
V L0_3398 = default;
V W0_3399 = default;
V nH_3400 = default;
if (_self3353.IsNullish) _self3353 = GlobalV;
H_3361 = Get(Get(Get(D_3360, "mane"), "hog"), "coat");
{ V _t3401 = Get(D_3360, "head");
{ V _t3402 = ListOf(_t3401);
{ V _t3403 = GetIdx(_t3402, 0D);
HX_3362 = _t3403; }
{ V _t3404 = GetIdx(_t3402, 1D);
HY_3363 = _t3404; }
{ V _t3405 = GetIdx(_t3402, 2D);
HR_3364 = _t3405; }
} }
SR_3365 = Add(HR_3364, ((V)(0.5)));
SRY_3366 = Add((GetIdx(Get(D_3360, "head"), 3D) is var _t3406 && Truthy(_t3406) ? _t3406 : HR_3364), ((V)(0.5)));
{ V _t3407 = Get(D_3360, "body");
{ V _t3408 = ListOf(_t3407);
{ V _t3409 = GetIdx(_t3408, 0D);
BX_3367 = _t3409; }
{ V _t3410 = GetIdx(_t3408, 1D);
BY_3368 = _t3410; }
{ V _t3411 = GetIdx(_t3408, 2D);
BW_3369 = _t3411; }
{ V _t3412 = GetIdx(_t3408, 3D);
BH_3370 = _t3412; }
} }
BZ_3371 = (ToNum(BW_3369) * 0.75);
SH_3372 = (Get(H_3361, "shell") is var _t3413 && Truthy(_t3413) ? _t3413 : NewObj(2).Put("c", Arr(((V)(50D)), ((V)(62D)))).Put("r", Arr(((V)(27D)), ((V)(29D)), ((V)(26D)))).V);
{ V _t3414 = Get(SH_3372, "c");
{ V _t3415 = ListOf(_t3414);
{ V _t3416 = GetIdx(_t3415, 0D);
CX_3373 = _t3416; }
{ V _t3417 = GetIdx(_t3415, 1D);
CY_3374 = _t3417; }
} }
{ V _t3418 = Get(SH_3372, "r");
{ V _t3419 = ListOf(_t3418);
{ V _t3420 = GetIdx(_t3419, 0D);
RX_3375 = _t3420; }
{ V _t3421 = GetIdx(_t3419, 1D);
RY_3376 = _t3421; }
{ V _t3422 = GetIdx(_t3419, 2D);
RZ_3377 = _t3422; }
} }
tab_3378 = Fn((V _arrowThis3431, int _argc3423, V T_3429, V a_3430, V _a3427, V _a3428, V[] _rest3424) => {
if (Le(a_3430, GetIdx(GetIdx(T_3429, 0D), 0D))) {
return GetIdx(GetIdx(T_3429, 0D), 1D);
}
{
double i_3432 = 0;
i_3432 = 1D;
while (true) {
if (!(Lt(((V)(i_3432)), Get(T_3429, "length")))) break;
if (Le(a_3430, GetIdx(GetIdx(T_3429, i_3432), 0D))) {
return Call(lerp_15, V.Undef, GetIdx(GetIdx(T_3429, (i_3432 - 1D)), 1D), GetIdx(GetIdx(T_3429, i_3432), 1D), ((V)(((ToNum(a_3430) - ToNum(GetIdx(GetIdx(T_3429, (i_3432 - 1D)), 0D))) / (ToNum(GetIdx(GetIdx(T_3429, i_3432), 0D)) - ToNum(GetIdx(GetIdx(T_3429, (i_3432 - 1D)), 0D)))))));
}
i_3432++;
}
}
return GetIdx(GetIdx(T_3429, (ToNum(Get(T_3429, "length")) - 1D)), 1D);
return default;
}, 2, "", true);
hA_3379 = (Get(H_3361, "headEdge") is var _t3434 && Truthy(_t3434) ? _t3434 : Arr(Arr(((V)(0D)), ((V)(27D))), Arr(((V)(14D)), ((V)(34D))), Arr(((V)(40D)), ((V)(52D))), Arr(((V)(90D)), ((V)(84D))), Arr(((V)(130D)), ((V)(104D))), Arr(((V)(180D)), ((V)(98D)))));
bA_3380 = (Get(H_3361, "bodyEdge") is var _t3435 && Truthy(_t3435) ? _t3435 : Arr(Arr(((V)(0D)), ((V)(55D))), Arr(((V)(90D)), ((V)(82D))), Arr(((V)(150D)), ((V)(112D))), Arr(((V)(180D)), ((V)(135D)))));
dir_3381 = Fn((V _arrowThis3444, int _argc3436, V pa_3442, V ph_3443, V _a3440, V _a3441, V[] _rest3437) => {
return Arr(((V)((FdLibm.Sin(ToNum(pa_3442)) * FdLibm.Sin(ToNum(ph_3443))))), ((V)(((-FdLibm.Sin(ToNum(pa_3442))) * FdLibm.Cos(ToNum(ph_3443))))), ((V)(FdLibm.Cos(ToNum(pa_3442)))));
}, 2, "", true);
nrm_3382 = Fn((V _arrowThis3452, int _argc3445, V v_3451, V _a3448, V _a3449, V _a3450, V[] _rest3446) => {
V l_3453 = default;
l_3453 = (((V)(Hypot(ToNum(GetIdx(v_3451, 0D)), ToNum(GetIdx(v_3451, 1D)), ToNum(GetIdx(v_3451, 2D))))) is var _t3454 && Truthy(_t3454) ? _t3454 : ((V)(1D)));
return Arr(((V)((ToNum(GetIdx(v_3451, 0D)) / ToNum(l_3453)))), ((V)((ToNum(GetIdx(v_3451, 1D)) / ToNum(l_3453)))), ((V)((ToNum(GetIdx(v_3451, 2D)) / ToNum(l_3453)))));
return default;
}, 1, "", true);
S_3383 = Fn((V _arrowThis3463, int _argc3455, V u_3461, V k_3462, V _a3459, V _a3460, V[] _rest3456) => {
return Arr(Add(CX_3373, ((V)(((ToNum(RX_3375) * ToNum(GetIdx(u_3461, 0D))) * ToNum(k_3462))))), Add(CY_3374, ((V)(((ToNum(RY_3376) * ToNum(GetIdx(u_3461, 1D))) * ToNum(k_3462))))), ((V)(((ToNum(RZ_3377) * ToNum(GetIdx(u_3461, 2D))) * ToNum(k_3462)))));
}, 2, "", true);
NY_3384 = (Get(H_3361, "neckY") is var _t3464 && Truthy(_t3464) ? _t3464 : ((V)(66D)));
NS_3385 = (Get(H_3361, "neckSpan") is var _t3465 && Truthy(_t3465) ? _t3465 : ((V)(12D)));
own_3386 = Fn((V _arrowThis3473, int _argc3466, V p_3472, V _a3469, V _a3470, V _a3471, V[] _rest3467) => {
return Call(SM_16, V.Undef, ((V)(((ToNum(Add(NY_3384, NS_3385)) - ToNum(GetIdx(p_3472, 1D))) / ToNum(NS_3385)))));
}, 1, "", true);
ang_3387 = Fn((V _arrowThis3483, int _argc3474, V x_3480, V y_3481, V z_3482, V _a3479, V[] _rest3475) => {
V l_3484 = default;
l_3484 = (((V)(Hypot(ToNum(x_3480), ToNum(y_3481), ToNum(z_3482)))) is var _t3485 && Truthy(_t3485) ? _t3485 : ((V)(1D)));
return Arr(((V)((FdLibm.Acos(ToNum(Call(clamp_13, V.Undef, ((V)((ToNum(z_3482) / ToNum(l_3484)))), ((V)((-1D))), ((V)(1D))))) / D2R_11))), ((V)((System.Math.Abs(FdLibm.Atan2(ToNum(x_3480), (-ToNum(y_3481)))) / D2R_11))));
return default;
}, 3, "", true);
cov_3388 = Fn((V _arrowThis3493, int _argc3486, V p_3492, V _a3489, V _a3490, V _a3491, V[] _rest3487) => {
V hpa_3494 = default;
V hph_3495 = default;
V bpa_3496 = default;
V bph_3497 = default;
V w_3498 = default;
{ V _t3499 = Call(ang_3387, V.Undef, ((V)(((ToNum(GetIdx(p_3492, 0D)) - ToNum(HX_3362)) / ToNum(SR_3365)))), ((V)(((ToNum(GetIdx(p_3492, 1D)) - ToNum(HY_3363)) / ToNum(SRY_3366)))), ((V)((ToNum(GetIdx(p_3492, 2D)) / ToNum(SR_3365)))));
{ V _t3500 = ListOf(_t3499);
{ V _t3501 = GetIdx(_t3500, 0D);
hpa_3494 = _t3501; }
{ V _t3502 = GetIdx(_t3500, 1D);
hph_3495 = _t3502; }
} }
{ V _t3503 = Call(ang_3387, V.Undef, ((V)(((ToNum(GetIdx(p_3492, 0D)) - ToNum(BX_3367)) / ToNum(BW_3369)))), ((V)(((ToNum(GetIdx(p_3492, 1D)) - ToNum(BY_3368)) / ToNum(BH_3370)))), ((V)((ToNum(GetIdx(p_3492, 2D)) / BZ_3371))));
{ V _t3504 = ListOf(_t3503);
{ V _t3505 = GetIdx(_t3504, 0D);
bpa_3496 = _t3505; }
{ V _t3506 = GetIdx(_t3504, 1D);
bph_3497 = _t3506; }
} }
w_3498 = Call(own_3386, V.Undef, p_3492);
return ((V)(((ToNum(w_3498) * (ToNum(hpa_3494) - ToNum(Call(tab_3378, V.Undef, hA_3379, hph_3495)))) + ((1D - ToNum(w_3498)) * (ToNum(bpa_3496) - ToNum(Call(tab_3378, V.Undef, bA_3380, bph_3497)))))));
return default;
}, 1, "", true);
NA_3389 = (Get(H_3361, "meshA") is var _t3507 && Truthy(_t3507) ? _t3507 : ((V)(44D)));
NR_3390 = (Get(H_3361, "meshR") is var _t3508 && Truthy(_t3508) ? _t3508 : ((V)(8D)));
PM_3391 = (System.Math.PI * 0.985);
edge_3392 = Array_from(NewObj(1).Put("length", NA_3389).V, Fn((V _arrowThis3517, int _argc3509, V __3515, V i_3516, V _a3513, V _a3514, V[] _rest3510) => {
double ph_3518 = 0;
double lo_3519 = 0;
double hi_3520 = 0;
ph_3518 = ((ToNum(i_3516) / ToNum(NA_3389)) * TAU_12);
lo_3519 = 0D;
hi_3520 = PM_3391;
if (LeN(Call(cov_3388, V.Undef, Call(S_3383, V.Undef, Call(dir_3381, V.Undef, ((V)(hi_3520)), ((V)(ph_3518))), ((V)(1D)))), 0D)) {
return ((V)(hi_3520));
}
if (GtN(Call(cov_3388, V.Undef, Call(S_3383, V.Undef, Call(dir_3381, V.Undef, ((V)(lo_3519)), ((V)(ph_3518))), ((V)(1D)))), 0D)) {
return ((V)(lo_3519));
}
{
double k_3521 = 0;
k_3521 = 0D;
while (true) {
if (!((k_3521 < 24D))) break;
double m_3523 = 0;
m_3523 = ((lo_3519 + hi_3520) / 2D);
if (GtN(Call(cov_3388, V.Undef, Call(S_3383, V.Undef, Call(dir_3381, V.Undef, ((V)(m_3523)), ((V)(ph_3518))), ((V)(1D)))), 0D)) {
hi_3520 = m_3523;
} else {
lo_3519 = m_3523;
}
k_3521++;
}
}
return ((V)(hi_3520));
return default;
}, 2, "", true));
zig_3393 = (ToNum((!Get(H_3361, "zig").IsNullish ? Get(H_3361, "zig") : ((V)(7D)))) * D2R_11);
mesh_3394 = Arr();
{
double r_3524 = 0;
r_3524 = 0D;
while (true) {
if (!(Le(((V)(r_3524)), NR_3390))) break;
V row_3526 = default;
row_3526 = Arr();
{
double i_3527 = 0;
i_3527 = 0D;
while (true) {
if (!(Lt(((V)(i_3527)), NA_3389))) break;
double ph_3529 = 0;
V a0_3530 = default;
V a_3531 = default;
V p_3532 = default;
ph_3529 = ((i_3527 / ToNum(NA_3389)) * TAU_12);
a0_3530 = GetIdx(edge_3392, i_3527);
a_3531 = ((r_3524 == 0D) ? ((V)(Max(0D, (ToNum(a0_3530) - (NumTruthy((i_3527 % 2D)) ? 0D : zig_3393))))) : Add(a0_3530, ((V)((((PM_3391 - ToNum(a0_3530)) * r_3524) / ToNum(NR_3390))))));
p_3532 = Call(S_3383, V.Undef, Call(dir_3381, V.Undef, a_3531, ((V)(ph_3529))), ((V)(0.985)));
Invoke(row_3526, "push", NewObj(2).Put("p", p_3532).Put("w", Call(own_3386, V.Undef, p_3532)).V);
i_3527++;
}
}
Invoke(mesh_3394, "push", row_3526);
r_3524++;
}
}
hs_3395 = Fn((V _arrowThis3540, int _argc3533, V i_3539, V _a3536, V _a3537, V _a3538, V[] _rest3534) => {
return ((V)(((((FdLibm.Sin(((ToNum(i_3539) * 12.9898) + 4.1)) * 43758.5453) % 1D) + 1D) % 1D)));
}, 1, "", true);
sp_3396 = Arr();
n_3397 = (Get(H_3361, "n") is var _t3541 && Truthy(_t3541) ? _t3541 : ((V)(300D)));
L0_3398 = (Get(H_3361, "len") is var _t3542 && Truthy(_t3542) ? _t3542 : ((V)(9D)));
W0_3399 = (Get(H_3361, "w") is var _t3543 && Truthy(_t3543) ? _t3543 : ((V)(3.4)));
{
double i_3544 = 0;
i_3544 = 0D;
while (true) {
if (!(Lt(((V)(i_3544)), n_3397))) break;
double y_3546 = 0;
double rr_3547 = 0;
double t_3548 = 0;
V u_3549 = default;
V root_3550 = default;
double pa_3551 = 0;
double ph_3552 = 0;
V nr_3553 = default;
V e_3554 = default;
y_3546 = (1D - ((2D * (i_3544 + 0.5)) / ToNum(n_3397)));
rr_3547 = System.Math.Sqrt((1D - (y_3546 * y_3546)));
t_3548 = (i_3544 * 2.399963);
u_3549 = Arr(((V)((rr_3547 * FdLibm.Cos(t_3548)))), ((V)(y_3546)), ((V)((rr_3547 * FdLibm.Sin(t_3548)))));
root_3550 = Call(S_3383, V.Undef, u_3549, ((V)(1D)));
if (LtN(Call(cov_3388, V.Undef, root_3550), 3D)) {
goto _cont3545;
}
pa_3551 = FdLibm.Acos(ToNum(Call(clamp_13, V.Undef, GetIdx(u_3549, 2D), ((V)((-1D))), ((V)(1D)))));
ph_3552 = FdLibm.Atan2(ToNum(GetIdx(u_3549, 0D)), (-ToNum(GetIdx(u_3549, 1D))));
nr_3553 = Call(nrm_3382, V.Undef, Arr(((V)((ToNum(GetIdx(u_3549, 0D)) / ToNum(RX_3375)))), ((V)((ToNum(GetIdx(u_3549, 1D)) / ToNum(RY_3376)))), ((V)((ToNum(GetIdx(u_3549, 2D)) / ToNum(RZ_3377))))));
e_3554 = Call(nrm_3382, V.Undef, Arr(((V)(((ToNum(RX_3375) * FdLibm.Cos(pa_3551)) * FdLibm.Sin(ph_3552)))), ((V)((((-ToNum(RY_3376)) * FdLibm.Cos(pa_3551)) * FdLibm.Cos(ph_3552)))), ((V)(((-ToNum(RZ_3377)) * FdLibm.Sin(pa_3551))))));
if (Truthy(Get(H_3361, "comb"))) {
V v_3555 = default;
double vn_3556 = 0;
v_3555 = Arr(((V)(0D)), Add(GetIdx(Get(H_3361, "comb"), 0D), ((V)((ToNum(GetIdx(Get(H_3361, "comb"), 1D)) * Max(0D, (-ToNum(GetIdx(nr_3553, 2D)))))))), ((V)((-1D))));
vn_3556 = ((ToNum(GetIdx(v_3555, 1D)) * ToNum(GetIdx(nr_3553, 1D))) + (ToNum(GetIdx(v_3555, 2D)) * ToNum(GetIdx(nr_3553, 2D))));
e_3554 = Invoke(v_3555, "map", Fn((V _arrowThis3565, int _argc3557, V x_3563, V j_3564, V _a3561, V _a3562, V[] _rest3558) => {
return ((V)((ToNum(x_3563) - (vn_3556 * ToNum(GetK(nr_3553, j_3564))))));
}, 2, "", true));
OpSetK(e_3554, ((V)(0D)), 2, ((V)((1D - (ToNum(Call(SM_16, V.Undef, ((V)((ToNum(GetIdx(nr_3553, 1D)) / 0.5))))) * ToNum(Call(SM_16, V.Undef, ((V)(((-ToNum(GetIdx(nr_3553, 2D))) / 0.4))))))))));
e_3554 = Call(nrm_3382, V.Undef, e_3554);
}
Invoke(sp_3396, "push", NewObj(8).Put("r", root_3550).Put("n", nr_3553).Put("e", e_3554).Put("len", ((V)((ToNum(L0_3398) * (0.8 + (0.4 * ToNum(Call(hs_3395, V.Undef, ((V)(i_3544)))))))))).Put("w", W0_3399).Put("o", Call(own_3386, V.Undef, root_3550)).Put("rim", ((V)((ToNum((!Get(H_3361, "rim").IsNullish ? Get(H_3361, "rim") : ((V)(0.45)))) * Pow((1D - System.Math.Abs(ToNum(GetIdx(nr_3553, 2D)))), 2D))))).Put("i", Get(sp_3396, "length")).V);
_cont3545: ;
i_3544++;
}
}
nH_3400 = Get(Invoke(sp_3396, "filter", Fn((V _arrowThis3573, int _argc3566, V q_3572, V _a3569, V _a3570, V _a3571, V[] _rest3567) => {
return (GtN(Get(q_3572, "o"), 0.5) ? V.True : V.False);
}, 1, "", true)), "length");
return NewObj(7).Put("mesh", mesh_3394).Put("sp", sp_3396).Put("nH", nH_3400).Put("nB", ((V)((ToNum(Get(sp_3396, "length")) - ToNum(nH_3400))))).Put("tipF", (!Get(H_3361, "tipF").IsNullish ? Get(H_3361, "tipF") : ((V)(0.62)))).Put("lay", (Get(H_3361, "lay") is var _t3574 && Truthy(_t3574) ? _t3574 : Arr(((V)(0.28)), ((V)(1D)), ((V)(0.22))))).Put("layUp", (Get(H_3361, "layUp") is var _t3575 && Truthy(_t3575) ? _t3575 : Arr(((V)(1.25)), ((V)(0.45)), ((V)(0D))))).V;
return default;
}, 1, "coatBuild", false);
hogBuild_64 = Fn((V _self3576, int _argc3577, V D_3583, V _a3580, V _a3581, V _a3582, V[] _rest3578) => {
V M_3584 = default;
V H_3585 = default;
V C_3586 = default;
V zc_3587 = default;
V RZ_3588 = default;
V P_3589 = default;
V ring_3590 = default;
V c0_3591 = default;
V c1_3592 = default;
V ang_3593 = default;
V rad_3594 = default;
V V_3595 = default;
V T_3596 = default;
V prof_3597 = default;
V rim_3598 = default;
V rv0_3599 = default;
V rt_3600 = default;
double aE_3601 = 0;
double yc_3602 = 0;
V rv_3603 = default;
V zr_3604 = default;
V sh_3605 = default;
V nrm_3606 = default;
V A_3607 = default;
V B_3608 = default;
V G_3609 = default;
V QN_3610 = default;
V sp_3611 = default;
if (_self3576.IsNullish) _self3576 = GlobalV;
M_3584 = Get(D_3583, "mane");
H_3585 = Get(M_3584, "hog");
C_3586 = Get(M_3584, "c");
zc_3587 = (!Get(H_3585, "z").IsNullish ? Get(H_3585, "z") : ((V)((-5D))));
RZ_3588 = (Get(H_3585, "rz") is var _t3612 && Truthy(_t3612) ? _t3612 : ((V)(30D)));
P_3589 = Call(flat_27, V.Undef, Call(parsePath_21, V.Undef, Get(M_3584, "d")), ((V)(1D)));
ring_3590 = Invoke(P_3589, "slice", ((V)(1D)), ((V)((ToNum(Get(P_3589, "length")) - 2D))));
c0_3591 = GetIdx(P_3589, 0D);
c1_3592 = GetIdx(P_3589, (ToNum(Get(P_3589, "length")) - 2D));
ang_3593 = Fn((V _arrowThis3620, int _argc3613, V p_3619, V _a3616, V _a3617, V _a3618, V[] _rest3614) => {
return ((V)(FdLibm.Atan2((ToNum(GetIdx(p_3619, 0D)) - ToNum(GetIdx(C_3586, 0D))), (ToNum(GetIdx(C_3586, 1D)) - ToNum(GetIdx(p_3619, 1D))))));
}, 1, "", true);
rad_3594 = Fn((V _arrowThis3628, int _argc3621, V p_3627, V _a3624, V _a3625, V _a3626, V[] _rest3622) => {
return ((V)(Hypot((ToNum(GetIdx(p_3627, 0D)) - ToNum(GetIdx(C_3586, 0D))), (ToNum(GetIdx(p_3627, 1D)) - ToNum(GetIdx(C_3586, 1D))))));
}, 1, "", true);
V_3595 = Invoke(ring_3590, "filter", Fn((V _arrowThis3637, int _argc3629, V p_3635, V i_3636, V _a3633, V _a3634, V[] _rest3630) => {
return (((ToNum(i_3636) % 2D) == 0D) ? V.True : V.False);
}, 2, "", true));
T_3596 = Invoke(ring_3590, "filter", Fn((V _arrowThis3646, int _argc3638, V p_3644, V i_3645, V _a3642, V _a3643, V[] _rest3639) => {
return (((ToNum(i_3645) % 2D) == 1D) ? V.True : V.False);
}, 2, "", true));
prof_3597 = Fn((V _arrowThis3654, int _argc3647, V L_3653, V _a3650, V _a3651, V _a3652, V[] _rest3648) => {
V A_3655 = default;
A_3655 = Invoke(Invoke(L_3653, "map", Fn((V _arrowThis3672, int _argc3665, V p_3671, V _a3668, V _a3669, V _a3670, V[] _rest3666) => {
return Arr(Call(ang_3593, V.Undef, p_3671), Call(rad_3594, V.Undef, p_3671));
}, 1, "", true)), "sort", Fn((V _arrowThis3664, int _argc3656, V a_3662, V b_3663, V _a3660, V _a3661, V[] _rest3657) => {
return ((V)((ToNum(GetIdx(a_3662, 0D)) - ToNum(GetIdx(b_3663, 0D)))));
}, 2, "", true));
return Fn((V _arrowThis3680, int _argc3673, V a_3679, V _a3676, V _a3677, V _a3678, V[] _rest3674) => {
if (Le(a_3679, GetIdx(GetIdx(A_3655, 0D), 0D))) {
return GetIdx(GetIdx(A_3655, 0D), 1D);
}
{
double i_3681 = 0;
i_3681 = 1D;
while (true) {
if (!(Lt(((V)(i_3681)), Get(A_3655, "length")))) break;
if (Le(a_3679, GetIdx(GetIdx(A_3655, i_3681), 0D))) {
return Call(lerp_15, V.Undef, GetIdx(GetIdx(A_3655, (i_3681 - 1D)), 1D), GetIdx(GetIdx(A_3655, i_3681), 1D), ((V)(((ToNum(a_3679) - ToNum(GetIdx(GetIdx(A_3655, (i_3681 - 1D)), 0D))) / (ToNum(GetIdx(GetIdx(A_3655, i_3681), 0D)) - ToNum(GetIdx(GetIdx(A_3655, (i_3681 - 1D)), 0D)))))));
}
i_3681++;
}
}
return GetIdx(GetIdx(A_3655, (ToNum(Get(A_3655, "length")) - 1D)), 1D);
return default;
}, 1, "", true);
return default;
}, 1, "", true);
rim_3598 = new ArrBuilder().Add(c0_3591).Spread(V_3595).Add(c1_3592).V;
rv0_3599 = Call(prof_3597, V.Undef, rim_3598);
rt_3600 = Call(prof_3597, V.Undef, T_3596);
aE_3601 = System.Math.Abs(ToNum(Call(ang_3593, V.Undef, c0_3591)));
yc_3602 = (ToNum(Add(GetIdx(c0_3591, 1D), GetIdx(c1_3592, 1D))) / 2D);
rv_3603 = Fn((V _arrowThis3690, int _argc3683, V a_3689, V _a3686, V _a3687, V _a3688, V[] _rest3684) => {
return ((System.Math.Abs(ToNum(a_3689)) <= aE_3601) ? Call(rv0_3599, V.Undef, a_3689) : ((V)(((yc_3602 - ToNum(GetIdx(C_3586, 1D))) / Max(0.3, (-FdLibm.Cos(ToNum(a_3689))))))));
}, 1, "", true);
zr_3604 = Fn((V _arrowThis3698, int _argc3691, V a_3697, V _a3694, V _a3695, V _a3696, V[] _rest3692) => {
return ((V)((ToNum(Add(zc_3587, ((V)((ToNum((!Get(H_3585, "zt").IsNullish ? Get(H_3585, "zt") : ((V)(9D)))) * Max(0D, FdLibm.Cos(ToNum(a_3697)))))))) - (ToNum((!Get(H_3585, "zb").IsNullish ? Get(H_3585, "zb") : ((V)(6D)))) * Max(0D, (-FdLibm.Cos(ToNum(a_3697))))))));
}, 1, "", true);
sh_3605 = Fn((V _arrowThis3709, int _argc3699, V a_3705, V b_3706, V r_3707, V rz_3708, V[] _rest3700) => {
return Arr(Add(GetIdx(C_3586, 0D), ((V)(((ToNum(r_3707) * FdLibm.Cos(ToNum(b_3706))) * FdLibm.Sin(ToNum(a_3705)))))), ((V)((ToNum(GetIdx(C_3586, 1D)) - ((ToNum(r_3707) * FdLibm.Cos(ToNum(b_3706))) * FdLibm.Cos(ToNum(a_3705)))))), ((V)(((ToNum(zc_3587) - (ToNum(rz_3708) * FdLibm.Sin(ToNum(b_3706)))) + ((ToNum(Call(zr_3604, V.Undef, a_3705)) - ToNum(zc_3587)) * FdLibm.Cos(ToNum(b_3706)))))));
}, 4, "", true);
nrm_3606 = Fn((V _arrowThis3718, int _argc3710, V a_3716, V b_3717, V _a3714, V _a3715, V[] _rest3711) => {
return Arr(((V)((FdLibm.Cos(ToNum(b_3717)) * FdLibm.Sin(ToNum(a_3716))))), ((V)(((-FdLibm.Cos(ToNum(b_3717))) * FdLibm.Cos(ToNum(a_3716))))), ((V)((-FdLibm.Sin(ToNum(b_3717))))));
}, 2, "", true);
A_3607 = Invoke(Invoke(rim_3598, "map", ang_3593), "concat", Invoke(Arr(((V)(1D)), ((V)(2D)), ((V)(3D))), "map", Fn((V _arrowThis3726, int _argc3719, V k_3725, V _a3722, V _a3723, V _a3724, V[] _rest3720) => {
return ((V)((aE_3601 + ((ToNum(k_3725) * (TAU_12 - (2D * aE_3601))) / 4D))));
}, 1, "", true)));
B_3608 = Invoke(Arr(((V)(0D)), ((V)(18D)), ((V)(36D)), ((V)(54D)), ((V)(72D)), ((V)(90D))), "map", Fn((V _arrowThis3734, int _argc3727, V d_3733, V _a3730, V _a3731, V _a3732, V[] _rest3728) => {
return ((V)((ToNum(d_3733) * D2R_11)));
}, 1, "", true));
G_3609 = Invoke(B_3608, "map", Fn((V _arrowThis3742, int _argc3735, V b_3741, V _a3738, V _a3739, V _a3740, V[] _rest3736) => {
return Invoke(A_3607, "map", Fn((V _arrowThis3750, int _argc3743, V a_3749, V _a3746, V _a3747, V _a3748, V[] _rest3744) => {
return Call(sh_3605, V.Undef, a_3749, b_3741, Call(rv_3603, V.Undef, a_3749), RZ_3588);
}, 1, "", true));
}, 1, "", true));
QN_3610 = Invoke(Invoke(B_3608, "slice", ((V)(0D)), ((V)((-1D)))), "map", Fn((V _arrowThis3759, int _argc3751, V b_3757, V j_3758, V _a3755, V _a3756, V[] _rest3752) => {
return Invoke(A_3607, "map", Fn((V _arrowThis3768, int _argc3760, V a_3766, V i_3767, V _a3764, V _a3765, V[] _rest3761) => {
V a2_3769 = default;
a2_3769 = GetIdx(A_3607, (ToNum(Add(i_3767, ((V)(1D)))) % ToNum(Get(A_3607, "length"))));
if (Lt(a2_3769, a_3766)) {
a2_3769 = Add(a2_3769, ((V)(TAU_12)));
}
return Call(nrm_3606, V.Undef, ((V)((ToNum(Add(a_3766, a2_3769)) / 2D))), ((V)((ToNum(Add(b_3757, GetK(B_3608, Add(j_3758, ((V)(1D)))))) / 2D))));
return default;
}, 2, "", true));
}, 2, "", true));
sp_3611 = Arr();
{
double k_3770 = 0;
k_3770 = 0D;
while (true) {
if (!(Lt(((V)(k_3770)), Get(T_3596, "length")))) break;
V b1_3772 = default;
V b2_3773 = default;
V t_3774 = default;
double len_3775 = 0;
b1_3772 = GetIdx(V_3595, k_3770);
b2_3773 = GetIdx(V_3595, (k_3770 + 1D));
t_3774 = GetIdx(T_3596, k_3770);
len_3775 = (ToNum(Call(rad_3594, V.Undef, t_3774)) - (ToNum(Add(Call(rad_3594, V.Undef, b1_3772), Call(rad_3594, V.Undef, b2_3773))) / 2D));
Invoke(sp_3611, "push", NewObj(6).Put("b1", Arr(GetIdx(b1_3772, 0D), GetIdx(b1_3772, 1D), Call(zr_3604, V.Undef, Call(ang_3593, V.Undef, b1_3772)))).Put("b2", Arr(GetIdx(b2_3773, 0D), GetIdx(b2_3773, 1D), Call(zr_3604, V.Undef, Call(ang_3593, V.Undef, b2_3773)))).Put("t", Arr(GetIdx(t_3774, 0D), GetIdx(t_3774, 1D), ((V)((ToNum(Call(zr_3604, V.Undef, Call(ang_3593, V.Undef, t_3774))) - (len_3775 * ToNum(Add((!Get(H_3585, "tilt").IsNullish ? Get(H_3585, "tilt") : ((V)(1D))), ((V)((0.8 * Max(0D, FdLibm.Cos(ToNum(Call(ang_3593, V.Undef, t_3774))))))))))))))).Put("n", Call(nrm_3606, V.Undef, Call(ang_3593, V.Undef, t_3774), ((V)(0D)))).Put("len", ((V)(len_3775))).Put("i", Get(sp_3611, "length")).V);
k_3770++;
}
}
Invoke((Get(H_3585, "rows") is var _t3800 && Truthy(_t3800) ? _t3800 : Arr()), "forEach", Fn((V _arrowThis3789, int _argc3776, V _a3778, V _a3779, V _a3780, V _a3781, V[] _rest3777) => {
double b_3790 = 0;
V full_3791 = default;
double stp_3792 = 0;
double a0_3793 = 0;
V bd_3784 = default;
V m_3786 = default;
V am_3788 = default;
{ V _t3782 = ListOf(_a3778);
{ V _t3783 = GetIdx(_t3782, 0D);
bd_3784 = _t3783; }
{ V _t3785 = GetIdx(_t3782, 1D);
m_3786 = _t3785; }
{ V _t3787 = GetIdx(_t3782, 2D);
am_3788 = _t3787; }
}
b_3790 = (ToNum(bd_3784) * D2R_11);
full_3791 = (GeN(am_3788, 180D) ? V.True : V.False);
stp_3792 = (((Truthy(full_3791) ? 360D : (2D * ToNum(am_3788))) / ToNum(m_3786)) * D2R_11);
a0_3793 = (Truthy(full_3791) ? (-System.Math.PI) : ((-ToNum(am_3788)) * D2R_11));
{
double j_3794 = 0;
j_3794 = 0D;
while (true) {
if (!(Lt(((V)(j_3794)), m_3786))) break;
double a_3796 = 0;
double da_3797 = 0;
double len_3798 = 0;
a_3796 = (a0_3793 + ((j_3794 + 0.5) * stp_3792));
da_3797 = (stp_3792 / 2D);
len_3798 = Max(2D, ((ToNum(Call(rt_3600, V.Undef, ((V)(a_3796)))) - ToNum(Call(rv_3603, V.Undef, ((V)(a_3796))))) * ToNum((Get(H_3585, "lk") is var _t3799 && Truthy(_t3799) ? _t3799 : ((V)(0.9))))));
Invoke(sp_3611, "push", NewObj(6).Put("b1", Call(sh_3605, V.Undef, ((V)((a_3796 - da_3797))), ((V)(b_3790)), Call(rv_3603, V.Undef, ((V)((a_3796 - da_3797)))), RZ_3588)).Put("b2", Call(sh_3605, V.Undef, ((V)((a_3796 + da_3797))), ((V)(b_3790)), Call(rv_3603, V.Undef, ((V)((a_3796 + da_3797)))), RZ_3588)).Put("t", Call(sh_3605, V.Undef, ((V)(a_3796)), ((V)(b_3790)), Add(Call(rv_3603, V.Undef, ((V)(a_3796))), ((V)(len_3798))), Add(RZ_3588, ((V)(len_3798))))).Put("n", Call(nrm_3606, V.Undef, ((V)(a_3796)), ((V)(b_3790)))).Put("len", ((V)(len_3798))).Put("i", Get(sp_3611, "length")).V);
j_3794++;
}
}
return default;
}, 1, "", true));
return NewObj(5).Put("A", A_3607).Put("B", B_3608).Put("G", G_3609).Put("QN", QN_3610).Put("sp", Invoke(sp_3611, "map", Fn((V _arrowThis3808, int _argc3801, V s_3807, V _a3804, V _a3805, V _a3806, V[] _rest3802) => {
return Object_assign(s_3807, NewObj(1).Put("w", ((V)((Hypot((ToNum(GetIdx(Get(s_3807, "b2"), 0D)) - ToNum(GetIdx(Get(s_3807, "b1"), 0D))), (ToNum(GetIdx(Get(s_3807, "b2"), 1D)) - ToNum(GetIdx(Get(s_3807, "b1"), 1D))), (ToNum(GetIdx(Get(s_3807, "b2"), 2D)) - ToNum(GetIdx(Get(s_3807, "b1"), 2D)))) / 2D)))).V);
}, 1, "", true))).V;
return default;
}, 1, "hogBuild", false);
loop_69 = Fn((V _self3809, int _argc3810, V now_3816, V _a3813, V _a3814, V _a3815, V[] _rest3811) => {
V SP_3817 = default;
V N_3818 = default;
double F_3819 = 0;
double j_3820 = 0;
V c0_3821 = default;
if (_self3809.IsNullish) _self3809 = GlobalV;
SP_3817 = Get(G("window"), "SquishPerf");
if (Truthy((SP_3817 is var _t3822 && !Truthy(_t3822) ? _t3822 : Get(SP_3817, "freeze")))) {
V back_3823 = default;
if (Truthy(raf_66)) {
Call(G("cancelAnimationFrame"), V.Undef, raf_66);
}
raf_66 = ((V)(0D));
last_67 = now_3816;
Call(G("clearTimeout"), V.Undef, Get(loop_69, "fz"));
back_3823 = Fn((V _arrowThis3830, int _argc3824, V _a3826, V _a3827, V _a3828, V _a3829, V[] _rest3825) => {
if (Truthy(Get(SP_3817, "freeze"))) {
Set(loop_69, "fz", Call(G("setTimeout"), V.Undef, back_3823, ((V)(120D))));
return default;
}
if (Truthy(((!(Truthy(raf_66)) ? V.True : V.False) is var _t3831 && !Truthy(_t3831) ? _t3831 : Get(ALL_65, "size")))) {
raf_66 = Call(G("requestAnimationFrame"), V.Undef, loop_69);
}
return default;
}, 0, "", true);
Set(loop_69, "fz", Call(G("setTimeout"), V.Undef, back_3823, ((V)(120D))));
return default;
}
raf_66 = (Truthy(Get(ALL_65, "size")) ? Call(G("requestAnimationFrame"), V.Undef, loop_69) : ((V)(0D)));
N_3818 = (Truthy((SP_3817 is var _t3832 && !Truthy(_t3832) ? _t3832 : Get(SP_3817, "rigStride"))) ? Invoke(SP_3817, "rigStride") : ((V)(1D)));
F_3819 = ToNum(Set(loop_69, "f", ((V)((ToNum(Add((Get(loop_69, "f") is var _t3833 && Truthy(_t3833) ? _t3833 : ((V)(0D))), ((V)(1D)))) % 997920D)))));
j_3820 = 0D;
last_67 = now_3816;
c0_3821 = Invoke(G("performance"), "now");
Invoke(ALL_65, "forEach", Fn((V _arrowThis3841, int _argc3834, V I_3840, V _a3837, V _a3838, V _a3839, V[] _rest3835) => {
V dt_3842 = default;
if (Truthy(Get(I_3840, "sqHold"))) {
return default;
}
if (NumTruthy(((j_3820++ + F_3819) % ToNum(N_3818)))) {
return default;
}
if (Truthy((Get(I_3840, "key") is var _t3843 && !Truthy(_t3843) ? _t3843 : Get(G("window"), "SquishLazy")))) {
Invoke(Get(G("window"), "SquishLazy"), "need", Get(I_3840, "key"));
}
dt_3842 = Call(clamp_13, V.Undef, ((V)(((ToNum(now_3816) - ToNum((Get(I_3840, "sqT") is var _t3844 && Truthy(_t3844) ? _t3844 : ((V)((ToNum(now_3816) - (16D * ToNum(N_3818)))))))) / 1000D))), ((V)(0.001)), ((V)((1D / 20D))));
Set(I_3840, "sqT", now_3816);
try {
Call(tick_59, V.Undef, I_3840, now_3816, dt_3842);
} catch (System.Exception _ex3845) {
V e_3846 = default;
e_3846 = Caught(_ex3845);
if (!(Truthy(Get(I_3840, "err")))) {
Set(I_3840, "err", ((V)(1D)));
Invoke(G("console"), "error", ((V)("RiveRig")), e_3846);
}
}
return default;
}, 1, "", true));
if (Truthy(((SP_3817 is var _t3847 && !Truthy(_t3847) ? _t3847 : Get(SP_3817, "rigCost")) is var _t3848 && !Truthy(_t3848) ? _t3848 : ((V)(j_3820))))) {
Invoke(SP_3817, "rigCost", ((V)((ToNum(Invoke(G("performance"), "now")) - ToNum(c0_3821)))), N_3818);
}
return default;
}, 1, "loop", false);
rgbOf_78 = Fn((V _self3849, int _argc3850, V e_3856, V _a3853, V _a3854, V _a3855, V[] _rest3851) => {
if (_self3849.IsNullish) _self3849 = GlobalV;
try {
V f_3857 = default;
V m_3858 = default;
f_3857 = (Get(Call(G("getComputedStyle"), V.Undef, e_3856), "fill") is var _t3859 && Truthy(_t3859) ? _t3859 : ((V)("")));
m_3858 = Invoke(f_3857, "match", NewRegExp(RX5, "url\\([\"']?#([^\"')]+)[\"']?\\)", ""));
if (Truthy(m_3858)) {
V svg_3860 = default;
V g_3861 = default;
V cs_3862 = default;
svg_3860 = Get(e_3856, "ownerSVGElement");
g_3861 = (svg_3860 is var _t3863 && !Truthy(_t3863) ? _t3863 : Invoke(svg_3860, "querySelector", ((V)(JsStrBuf.Begin().S("[id=\"").V(GetIdx(m_3858, 1D)).S("\"]").End()))));
{
double i_3864 = 0;
i_3864 = 0D;
while (true) {
if (!(Truthy(((((i_3864 < 3D) ? V.True : V.False) is var _t3866 && !Truthy(_t3866) ? _t3866 : g_3861) is var _t3867 && !Truthy(_t3867) ? _t3867 : (!(Truthy(Invoke(g_3861, "querySelector", ((V)("stop"))))) ? V.True : V.False))))) break;
V hr_3868 = default;
hr_3868 = Invoke(((Invoke(g_3861, "getAttribute", ((V)("href"))) is var _t3869 && Truthy(_t3869) ? _t3869 : Invoke(g_3861, "getAttribute", ((V)("xlink:href")))) is var _t3870 && Truthy(_t3870) ? _t3870 : ((V)(""))), "slice", ((V)(1D)));
g_3861 = (Truthy(hr_3868) ? Invoke(svg_3860, "querySelector", ((V)(JsStrBuf.Begin().S("[id=\"").V(hr_3868).S("\"]").End()))) : V.Null);
i_3864++;
}
}
cs_3862 = (Truthy(g_3861) ? Invoke(Invoke(new ArrBuilder().Spread(Invoke(g_3861, "querySelectorAll", ((V)("stop")))).V, "map", Fn((V _arrowThis3878, int _argc3871, V s_3877, V _a3874, V _a3875, V _a3876, V[] _rest3872) => {
return Call(rgbP_77, V.Undef, Get(Call(G("getComputedStyle"), V.Undef, s_3877), "stopColor"));
}, 1, "", true)), "filter", G("Boolean")) : Arr());
if (!(Truthy(Get(cs_3862, "length")))) {
return Arr(((V)(200D)), ((V)(140D)), ((V)(100D)));
}
return Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis3886, int _argc3879, V i_3885, V _a3882, V _a3883, V _a3884, V[] _rest3880) => {
return ((V)((ToNum(Invoke(cs_3862, "reduce", Fn((V _arrowThis3895, int _argc3887, V a_3893, V c_3894, V _a3891, V _a3892, V[] _rest3888) => {
return Add(a_3893, GetK(c_3894, i_3885));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(cs_3862, "length")))));
}, 1, "", true));
}
return (Call(rgbP_77, V.Undef, f_3857) is var _t3896 && Truthy(_t3896) ? _t3896 : Arr(((V)(200D)), ((V)(140D)), ((V)(100D))));
} catch (System.Exception _ex3897) {
V x_3898 = default;
x_3898 = Caught(_ex3897);
return Arr(((V)(200D)), ((V)(140D)), ((V)(100D)));
}
return default;
}, 1, "rgbOf", false);
hsl_79 = Fn((V _self3899, int _argc3900, V _a3902, V _a3903, V _a3904, V _a3905, V[] _rest3901) => {
double mx_3913 = 0;
double mn_3914 = 0;
double l_3915 = 0;
double h_3916 = 0;
double s_3917 = 0;
V r_3908 = default;
V g_3910 = default;
V b_3912 = default;
if (_self3899.IsNullish) _self3899 = GlobalV;
{ V _t3906 = ListOf(_a3902);
{ V _t3907 = GetIdx(_t3906, 0D);
r_3908 = _t3907; }
{ V _t3909 = GetIdx(_t3906, 1D);
g_3910 = _t3909; }
{ V _t3911 = GetIdx(_t3906, 2D);
b_3912 = _t3911; }
}
r_3908 = ((V)((ToNum(r_3908) / 255D)));
g_3910 = ((V)((ToNum(g_3910) / 255D)));
b_3912 = ((V)((ToNum(b_3912) / 255D)));
mx_3913 = Max(ToNum(r_3908), ToNum(g_3910), ToNum(b_3912));
mn_3914 = Min(ToNum(r_3908), ToNum(g_3910), ToNum(b_3912));
l_3915 = ((mx_3913 + mn_3914) / 2D);
h_3916 = 0D;
s_3917 = 0D;
if ((mx_3913 != mn_3914)) {
double d_3918 = 0;
d_3918 = (mx_3913 - mn_3914);
s_3917 = ((l_3915 > 0.5) ? (d_3918 / ((2D - mx_3913) - mn_3914)) : (d_3918 / (mx_3913 + mn_3914)));
h_3916 = (SEqN(r_3908, mx_3913) ? (((ToNum(g_3910) - ToNum(b_3912)) / d_3918) + (Lt(g_3910, b_3912) ? 6D : 0D)) : (SEqN(g_3910, mx_3913) ? (((ToNum(b_3912) - ToNum(r_3908)) / d_3918) + 2D) : (((ToNum(r_3908) - ToNum(g_3910)) / d_3918) + 4D)));
h_3916 = (h_3916 / 6D);
}
return Arr(((V)(h_3916)), ((V)(s_3917)), ((V)(l_3915)));
return default;
}, 1, "hsl", false);
hex_80 = Fn((V _self3919, int _argc3920, V _a3922, V _a3923, V _a3924, V _a3925, V[] _rest3921) => {
V f_3933 = default;
V h_3928 = default;
V s_3930 = default;
V l_3932 = default;
if (_self3919.IsNullish) _self3919 = GlobalV;
{ V _t3926 = ListOf(_a3922);
{ V _t3927 = GetIdx(_t3926, 0D);
h_3928 = _t3927; }
{ V _t3929 = GetIdx(_t3926, 1D);
s_3930 = _t3929; }
{ V _t3931 = GetIdx(_t3926, 2D);
l_3932 = _t3931; }
}
f_3933 = Fn((V _arrowThis3941, int _argc3934, V n_3940, V _a3937, V _a3938, V _a3939, V[] _rest3935) => {
double k_3942 = 0;
double a_3943 = 0;
k_3942 = (ToNum(Add(n_3940, ((V)((ToNum(h_3928) * 12D))))) % 12D);
a_3943 = (ToNum(s_3930) * Min(ToNum(l_3932), (1D - ToNum(l_3932))));
return ((V)(Round((255D * (ToNum(l_3932) - (a_3943 * Max((-1D), Min((k_3942 - 3D), (9D - k_3942), 1D))))))));
return default;
}, 1, "", true);
return ((V)(JsStrBuf.Begin().S("#").V(Invoke(Invoke(Arr(Call(f_3933, V.Undef, ((V)(0D))), Call(f_3933, V.Undef, ((V)(8D))), Call(f_3933, V.Undef, ((V)(4D)))), "map", Fn((V _arrowThis3951, int _argc3944, V v_3950, V _a3947, V _a3948, V _a3949, V[] _rest3945) => {
return Invoke(Invoke(v_3950, "toString", ((V)(16D))), "padStart", ((V)(2D)), ((V)("0")));
}, 1, "", true)), "join", ((V)("")))).End()));
return default;
}, 1, "hex", false);
lightSrc_84 = Fn((V _self3952, int _argc3953, V I_3959, V k_3960, V _a3957, V _a3958, V[] _rest3954) => {
V E_3961 = default;
if (_self3952.IsNullish) _self3952 = GlobalV;
E_3961 = (Get(I_3959, "E") is var _t3962 && Truthy(_t3962) ? _t3962 : NewObj(0).V);
if (SEqS(k_3960, "head")) {
return Get(E_3961, "skull");
}
if (SEqS(k_3960, "body")) {
return Get(E_3961, "body");
}
if (SEqS(k_3960, "mane")) {
return Get(E_3961, "mane");
}
if (SEqS(k_3960, "tail")) {
return Get(E_3961, "tailF");
}
if ((SEqS(k_3960, "armL") || SEqS(k_3960, "armR"))) {
return (Get(E_3961, "arms") is var _t3963 && !Truthy(_t3963) ? _t3963 : GetIdx(Get(E_3961, "arms"), (SEqS(k_3960, "armL") ? 0D : 1D)));
}
if ((SEqS(k_3960, "footL") || SEqS(k_3960, "footR"))) {
return ((Get(E_3961, "feet") is var _t3964 && !Truthy(_t3964) ? _t3964 : GetIdx(Get(E_3961, "feet"), (SEqS(k_3960, "footL") ? 0D : 1D))) is var _t3965 && !Truthy(_t3965) ? _t3965 : Get(GetIdx(Get(E_3961, "feet"), (SEqS(k_3960, "footL") ? 0D : 1D)), "f"));
}
if ((SEqS(k_3960, "earL") || SEqS(k_3960, "earR"))) {
V e_3966 = default;
e_3966 = Invoke((Get(E_3961, "ears") is var _t3976 && Truthy(_t3976) ? _t3976 : Arr()), "find", Fn((V _arrowThis3974, int _argc3967, V x_3973, V _a3970, V _a3971, V _a3972, V[] _rest3968) => {
return (Get(x_3973, "o") is var _t3975 && !Truthy(_t3975) ? _t3975 : (SEq(Get(Get(x_3973, "o"), "parentNode"), GetK(Get(I_3959, "pg"), k_3960)) ? V.True : V.False));
}, 1, "", true));
return (e_3966 is var _t3977 && !Truthy(_t3977) ? _t3977 : Get(e_3966, "o"));
}
return V.Null;
return default;
}, 2, "lightSrc", false);
applyLook_86 = Fn((V _self3978, int _argc3979, V I_3985, V _a3982, V _a3983, V _a3984, V[] _rest3980) => {
V LK_3986 = default;
V L_3987 = default;
if (_self3978.IsNullish) _self3978 = GlobalV;
LK_3986 = (!Get(I_3985, "lookM").IsNullish ? Get(I_3985, "lookM") : ((V)(LOOK_76)));
L_3987 = (Truthy(LK_3986) ? Object_assign(NewObj(0).V, (Get(I_3985, "sceneL") is var _t3988 && Truthy(_t3988) ? _t3988 : LOOK0_74), (GetK(MODES_75, LK_3986) is var _t3989 && Truthy(_t3989) ? _t3989 : NewObj(0).V)) : V.Null);
if (Truthy((L_3987 is var _t3990 && !Truthy(_t3990) ? _t3990 : (SEq(Get(L_3987, "lineC"), V.Null) ? V.True : V.False)))) {
Delete(L_3987, "lineC");
}
if (Truthy(((L_3987 is var _t3991 && !Truthy(_t3991) ? _t3991 : (Get(L_3987, "face").IsNullish ? V.True : V.False)) is var _t3992 && !Truthy(_t3992) ? _t3992 : Invoke(FACE_85, "has", Get(I_3985, "key"))))) {
Set(L_3987, "face", Invoke(FACE_85, "get", Get(I_3985, "key")));
}
Set(I_3985, "curL", L_3987);
if (Truthy(Get(I_3985, "root"))) {
Call(setLight_93, V.Undef, I_3985, L_3987);
}
Set(I_3985, "olDirty", ((V)(1D)));
return default;
}, 1, "applyLook", false);
faceLines_87 = Fn((V _self3993, int _argc3994, V I_4000, V L_4001, V _a3998, V _a3999, V[] _rest3995) => {
V E_4002 = default;
V fw_4003 = default;
V NS_4004 = default;
V one_4005 = default;
if (_self3993.IsNullish) _self3993 = GlobalV;
E_4002 = (Get(I_4000, "E") is var _t4006 && Truthy(_t4006) ? _t4006 : NewObj(0).V);
fw_4003 = ((L_4001 is var _t4007 && !Truthy(_t4007) ? _t4007 : Get(L_4001, "face")) is var _t4008 && Truthy(_t4008) ? _t4008 : ((V)(0D)));
NS_4004 = ((V)("http://www.w3.org/2000/svg"));
Set(I_4000, "faceW", fw_4003);
one_4005 = Fn((V _arrowThis4017, int _argc4009, V e_4015, V w_4016, V _a4013, V _a4014, V[] _rest4010) => {
if (!(Truthy(e_4015))) {
return default;
}
if (Truthy(fw_4003)) {
Invoke(e_4015, "setAttribute", ((V)("stroke")), Call(lineOf_81, V.Undef, Call(rgbOf_78, V.Undef, e_4015)));
Invoke(e_4015, "setAttribute", ((V)("stroke-width")), Call(r2_14, V.Undef, w_4016));
Invoke(e_4015, "setAttribute", ((V)("stroke-linejoin")), ((V)("round")));
Invoke(e_4015, "setAttribute", ((V)("paint-order")), ((V)("stroke")));
} else {
Invoke(Arr(((V)("stroke")), ((V)("stroke-width")), ((V)("stroke-linejoin")), ((V)("paint-order"))), "forEach", Fn((V _arrowThis4025, int _argc4018, V a_4024, V _a4021, V _a4022, V _a4023, V[] _rest4019) => {
return Invoke(e_4015, "removeAttribute", a_4024);
}, 1, "", true));
}
return default;
}, 2, "", true);
Call(one_4005, V.Undef, Get(E_4002, "nose"), ((V)((ToNum(fw_4003) * 1.7))));
Call(one_4005, V.Undef, Get(E_4002, "mopen"), ((V)((ToNum(fw_4003) * 1.7))));
if (Truthy(Get(E_4002, "muzzle"))) {
Call(one_4005, V.Undef, Get(E_4002, "muzzle"), ((V)((ToNum(fw_4003) * 1.6))));
if (Truthy(fw_4003)) {
Invoke(Get(E_4002, "muzzle"), "setAttribute", ((V)("stroke")), Call(lineOf_81, V.Undef, Call(rgbOf_78, V.Undef, (Get(E_4002, "skull") is var _t4026 && Truthy(_t4026) ? _t4026 : Get(E_4002, "muzzle")))));
Invoke(Get(E_4002, "muzzle"), "setAttribute", ((V)("stroke-opacity")), ((V)("0.5")));
} else {
Invoke(Get(E_4002, "muzzle"), "removeAttribute", ((V)("stroke-opacity")));
}
}
if (Truthy(Get(E_4002, "mouth"))) {
if (Get(I_4000, "mouthW0").IsNullish) {
Set(I_4000, "mouthW0", (Invoke(Get(E_4002, "mouth"), "getAttribute", ((V)("stroke-width"))) is var _t4027 && Truthy(_t4027) ? _t4027 : ((V)("1.2"))));
}
Invoke(Get(E_4002, "mouth"), "setAttribute", ((V)("stroke-width")), (Truthy(fw_4003) ? Call(r2_14, V.Undef, ((V)(Max(ToNum(Get(I_4000, "mouthW0")), (ToNum(Get(I_4000, "mouthW0")) + (ToNum(fw_4003) * 0.55)))))) : Get(I_4000, "mouthW0")));
}
Invoke((Get(E_4002, "eyes") is var _t4048 && Truthy(_t4048) ? _t4048 : Arr()), "forEach", Fn((V _arrowThis4035, int _argc4028, V o_4034, V _a4031, V _a4032, V _a4033, V[] _rest4029) => {
if (!(Truthy(Get(o_4034, "e")))) {
return default;
}
if (Truthy(((!(Truthy(Get(o_4034, "ring"))) ? V.True : V.False) is var _t4036 && !Truthy(_t4036) ? _t4036 : fw_4003))) {
Set(o_4034, "ring", Invoke(G("document"), "createElementNS", NS_4004, ((V)("path"))));
Invoke(Arr(((V)("fill")), ((V)("none")), ((V)("stroke-linecap")), ((V)("round")), ((V)("stroke-linejoin")), ((V)("round")), ((V)("pointer-events")), ((V)("none")), ((V)("data-lt")), ((V)("1"))), "reduce", Fn((V _arrowThis4047, int _argc4037, V k_4043, V v_4044, V i_4045, V a_4046, V[] _rest4038) => {
if (NumTruthy((ToNum(i_4045) % 2D))) {
Invoke(Get(o_4034, "ring"), "setAttribute", GetIdx(a_4046, (ToNum(i_4045) - 1D)), v_4044);
}
return k_4043;
return default;
}, 4, "", true), ((V)(0D)));
Invoke(Get(o_4034, "e"), "before", Get(o_4034, "ring"));
Set(o_4034, "ringD", V.Null);
}
if (Truthy(Get(o_4034, "ring"))) {
Set(Get(Get(o_4034, "ring"), "style"), "display", ((V)((Truthy(fw_4003) ? "" : "none"))));
Invoke(Get(o_4034, "ring"), "setAttribute", ((V)("stroke")), ((V)("#1c1024")));
}
return default;
}, 1, "", true));
return default;
}, 2, "faceLines", false);
sqSvgPt_88 = Fn((V _self4049, int _argc4050, V e_4056, V x_4057, V y_4058, V _a4055, V[] _rest4051) => {
V s_4059 = default;
V q_4060 = default;
if (_self4049.IsNullish) _self4049 = GlobalV;
s_4059 = Get(e_4056, "ownerSVGElement");
if ((!(Truthy(s_4059)) || !(Truthy(Get(s_4059, "createSVGPoint"))))) {
return New(G("DOMPoint"), x_4057, y_4058);
}
q_4060 = Invoke(s_4059, "createSVGPoint");
Set(q_4060, "x", x_4057);
Set(q_4060, "y", y_4058);
return q_4060;
return default;
}, 3, "sqSvgPt", false);
outlineEls_89 = Fn((V _self4061, int _argc4062, V I_4068, V _a4065, V _a4066, V _a4067, V[] _rest4063) => {
V root_4069 = default;
V els_4070 = default;
V info_4071 = default;
V all_4072 = default;
V late_4073 = default;
V tubes_4074 = default;
V filledT_4075 = default;
V rb_4076 = default;
double RA_4077 = 0;
V each_4078 = default;
V RSE_4079 = default;
V PART_4080 = default;
V roleOf_4081 = default;
V footOf_4082 = default;
V BE_4083 = default;
V fillA_4084 = default;
V @out_4085 = default;
V R0_4086 = default;
V rs_4087 = default;
V grp_4088 = default;
double ci_4089 = 0;
V tb_4090 = default;
if (_self4061.IsNullish) _self4061 = GlobalV;
root_4069 = (Get(I_4068, "root") is var _t4091 && Truthy(_t4091) ? _t4091 : Get(I_4068, "art"));
if (((!(Truthy(root_4069)) || !(Truthy(Get(root_4069, "getCTM")))) || !(Truthy(Invoke(root_4069, "getCTM"))))) {
return V.Null;
}
els_4070 = Invoke(new ArrBuilder().Spread(Invoke(root_4069, "querySelectorAll", ((V)("path,ellipse,circle,rect,polygon")))).V, "filter", Fn((V _arrowThis4099, int _argc4092, V e_4098, V _a4095, V _a4096, V _a4097, V[] _rest4093) => {
return (!(Truthy(Invoke(e_4098, "closest", ((V)("defs,clipPath,mask,pattern,[data-lt]"))))) ? V.True : V.False);
}, 1, "", true));
info_4071 = Arr();
all_4072 = Arr();
late_4073 = Arr();
tubes_4074 = Arr();
filledT_4075 = New(G("Set"));
rb_4076 = Invoke(root_4069, "getBoundingClientRect");
RA_4077 = Max(1D, (ToNum(Get(rb_4076, "width")) * ToNum(Get(rb_4076, "height"))));
each_4078 = Arr();
RSE_4079 = Call(Fn((V _arrowThis4107, int _argc4100, V q_4106, V _a4103, V _a4104, V _a4105, V[] _rest4101) => {
return (((V)(System.Math.Sqrt(System.Math.Abs(((ToNum(Get(q_4106, "a")) * ToNum(Get(q_4106, "d"))) - (ToNum(Get(q_4106, "b")) * ToNum(Get(q_4106, "c")))))))) is var _t4108 && Truthy(_t4108) ? _t4108 : ((V)(1D)));
}, 1, "", true), V.Undef, Invoke(root_4069, "getCTM"));
PART_4080 = New(G("Set"), Arr(((V)("head")), ((V)("arm")), ((V)("hand")), ((V)("foot")), ((V)("leg")), ((V)("wing")), ((V)("tail")), ((V)("earF")), ((V)("earP")), ((V)("pup"))));
roleOf_4081 = New(G("Map"));
Invoke((Get(I_4068, "items") is var _t4119 && Truthy(_t4119) ? _t4119 : Arr()), "forEach", Fn((V _arrowThis4116, int _argc4109, V q_4115, V _a4112, V _a4113, V _a4114, V[] _rest4110) => {
if (Truthy((q_4115 is var _t4117 && !Truthy(_t4117) ? _t4117 : Get(q_4115, "e")))) {
Invoke(roleOf_4081, "set", Get(q_4115, "e"), (Invoke(PART_4080, "has", Get(q_4115, "role")) is var _t4118 && Truthy(_t4118) ? _t4118 : Invoke(PART_4080, "has", Get(q_4115, "pet"))));
}
return default;
}, 1, "", true));
footOf_4082 = New(G("Map"));
BE_4083 = ((!(Truthy(Get(I_4068, "generic"))) ? V.True : V.False) is var _t4120 && !Truthy(_t4120) ? _t4120 : Get(I_4068, "E"));
if (Truthy(BE_4083)) {
Invoke(Invoke(Arr(Get(BE_4083, "skull"), Get(BE_4083, "tailF")), "concat", (Get(BE_4083, "arms") is var _t4129 && Truthy(_t4129) ? _t4129 : Arr()), Invoke((Get(BE_4083, "ears") is var _t4139 && Truthy(_t4139) ? _t4139 : Arr()), "map", Fn((V _arrowThis4137, int _argc4130, V x_4136, V _a4133, V _a4134, V _a4135, V[] _rest4131) => {
return (x_4136 is var _t4138 && !Truthy(_t4138) ? _t4138 : Get(x_4136, "o"));
}, 1, "", true))), "forEach", Fn((V _arrowThis4128, int _argc4121, V e_4127, V _a4124, V _a4125, V _a4126, V[] _rest4122) => {
if (Truthy(e_4127)) {
Invoke(roleOf_4081, "set", e_4127, (true ? V.True : V.False));
}
return default;
}, 1, "", true));
Invoke((Get(BE_4083, "feet") is var _t4150 && Truthy(_t4150) ? _t4150 : Arr()), "forEach", Fn((V _arrowThis4148, int _argc4140, V f_4146, V i_4147, V _a4144, V _a4145, V[] _rest4141) => {
if (Truthy((f_4146 is var _t4149 && !Truthy(_t4149) ? _t4149 : Get(f_4146, "f")))) {
Invoke(roleOf_4081, "set", Get(f_4146, "f"), (true ? V.True : V.False));
Invoke(footOf_4082, "set", Get(f_4146, "f"), ((V)((Truthy(i_4147) ? "footR" : "footL"))));
}
return default;
}, 2, "", true));
if (Truthy(Get(BE_4083, "collar"))) {
Invoke(roleOf_4081, "set", Get(BE_4083, "collar"), (true ? V.True : V.False));
}
}
fillA_4084 = Fn((V _arrowThis4159, int _argc4151, V e_4157, V cs_4158, V _a4155, V _a4156, V[] _rest4152) => {
double a_4160 = 0;
V m_4161 = default;
a_4160 = ToNum(Get(cs_4158, "fillOpacity"));
m_4161 = Invoke((Get(cs_4158, "fill") is var _t4162 && Truthy(_t4162) ? _t4162 : ((V)(""))), "match", NewRegExp(RX5, "url\\([\"']?#([^\"')]+)[\"']?\\)", ""));
if (Truthy(m_4161)) {
V svg_4163 = default;
V g_4164 = default;
V st_4165 = default;
svg_4163 = Get(e_4157, "ownerSVGElement");
g_4164 = (svg_4163 is var _t4166 && !Truthy(_t4166) ? _t4166 : Invoke(svg_4163, "querySelector", ((V)(JsStrBuf.Begin().S("[id=\"").V(GetIdx(m_4161, 1D)).S("\"]").End()))));
st_4165 = (Truthy(g_4164) ? new ArrBuilder().Spread(Invoke(g_4164, "querySelectorAll", ((V)("stop")))).V : Arr());
if (Truthy(Get(st_4165, "length"))) {
a_4160 = (a_4160 * (ToNum(Invoke(st_4165, "reduce", Fn((V _arrowThis4175, int _argc4167, V t_4173, V x_4174, V _a4171, V _a4172, V[] _rest4168) => {
return Add(t_4173, ((V)(ToNum(Get(Call(G("getComputedStyle"), V.Undef, x_4174), "stopOpacity")))));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(st_4165, "length"))));
}
}
return ((V)(a_4160));
return default;
}, 2, "", true);
Invoke(els_4070, "forEach", Fn((V _arrowThis4183, int _argc4176, V e_4182, V _a4179, V _a4180, V _a4181, V[] _rest4177) => {
V cs_4184 = default;
double op_4185 = 0;
V cl_4186 = default;
V a_4187 = default;
V hid_4188 = default;
V ctm_4189 = default;
double fa_4190 = 0;
V it_4191 = default;
V olg_4192 = default;
V ss_4193 = default;
V r_4194 = default;
cs_4184 = Call(G("getComputedStyle"), V.Undef, e_4182);
if ((!(Truthy(Get(cs_4184, "fill"))) || SEqS(Get(cs_4184, "fill"), "none"))) {
if (Truthy(((((((SEqS(Get(e_4182, "tagName"), "path") ? V.True : V.False) is var _t4195 && !Truthy(_t4195) ? _t4195 : Get(cs_4184, "stroke")) is var _t4196 && !Truthy(_t4196) ? _t4196 : (!SEqS(Get(cs_4184, "stroke"), "none") ? V.True : V.False)) is var _t4197 && !Truthy(_t4197) ? _t4197 : ((!(Truthy(Get(cs_4184, "strokeDasharray"))) || SEqS(Get(cs_4184, "strokeDasharray"), "none")) ? V.True : V.False)) is var _t4198 && !Truthy(_t4198) ? _t4198 : (!(Truthy(Invoke(e_4182, "getAttribute", ((V)("clip-path"))))) ? V.True : V.False)) is var _t4199 && !Truthy(_t4199) ? _t4199 : (!(Truthy(Invoke(e_4182, "getAttribute", ((V)("mask"))))) ? V.True : V.False)))) {
Invoke(tubes_4074, "push", e_4182);
}
return default;
}
if (SEqS(Get(cs_4184, "visibility"), "hidden")) {
return default;
}
op_4185 = (SEqS(Get(cs_4184, "display"), "none") ? 0D : ToNum(Get(cs_4184, "opacity")));
cl_4186 = (!(!(Truthy((Invoke(e_4182, "getAttribute", ((V)("clip-path"))) is var _t4200 && Truthy(_t4200) ? _t4200 : Invoke(e_4182, "getAttribute", ((V)("mask"))))))) ? V.True : V.False);
a_4187 = Get(e_4182, "parentNode");
hid_4188 = (SEqS(Get(cs_4184, "display"), "none") ? V.True : V.False);
while (Truthy(((a_4187 is var _t4201 && !Truthy(_t4201) ? _t4201 : (!SEq(a_4187, root_4069) ? V.True : V.False)) is var _t4202 && !Truthy(_t4202) ? _t4202 : (SEqN(Get(a_4187, "nodeType"), 1D) ? V.True : V.False)))) {
V s2_4203 = default;
if (Truthy(((Invoke(a_4187, "getAttribute", ((V)("clip-path"))) is var _t4204 && Truthy(_t4204) ? _t4204 : Invoke(a_4187, "getAttribute", ((V)("mask")))) is var _t4207 && !Truthy(_t4207) ? _t4207 : (!(Truthy(((BE_4083 is var _t4205 && !Truthy(_t4205) ? _t4205 : Invoke(roleOf_4081, "get", e_4182)) is var _t4206 && !Truthy(_t4206) ? _t4206 : (SEq(Get(a_4187, "parentNode"), root_4069) ? V.True : V.False)))) ? V.True : V.False)))) {
cl_4186 = (true ? V.True : V.False);
}
s2_4203 = Call(G("getComputedStyle"), V.Undef, a_4187);
if (SEqS(Get(s2_4203, "display"), "none")) {
hid_4188 = (true ? V.True : V.False);
break;
}
op_4185 = (op_4185 * ToNum(Get(s2_4203, "opacity")));
a_4187 = Get(a_4187, "parentNode");
}
if (Truthy((hid_4188 is var _t4208 && Truthy(_t4208) ? _t4208 : ((op_4185 < 0.5) ? V.True : V.False)))) {
if (!(Truthy(cl_4186))) {
Invoke(late_4073, "push", e_4182);
}
return default;
}
ctm_4189 = Invoke(e_4182, "getCTM");
if (!(Truthy(ctm_4189))) {
return default;
}
fa_4190 = (ToNum(Call(fillA_4084, V.Undef, e_4182, cs_4184)) * op_4185);
it_4191 = NewObj(4).Put("e", e_4182).Put("ctm", ctm_4189).Put("inv", Invoke(ctm_4189, "inverse")).Put("idx", Get(all_4072, "length")).V;
if ((fa_4190 >= 0.35)) {
Invoke(all_4072, "push", it_4191);
}
olg_4192 = ((!(Truthy(cl_4186)) ? V.True : V.False) is var _t4209 && !Truthy(_t4209) ? _t4209 : Invoke(e_4182, "closest", ((V)("[data-ol]"))));
if (Truthy((olg_4192 is var _t4210 && !Truthy(_t4210) ? _t4210 : ((fa_4190 >= 0.6) ? V.True : V.False)))) {
Invoke(each_4078, "push", NewObj(5).Put("e", e_4182).Put("col", Call(rgbOf_78, V.Undef, e_4182)).Put("sc", (((V)((System.Math.Sqrt(System.Math.Abs(((ToNum(Get(ctm_4189, "a")) * ToNum(Get(ctm_4189, "d"))) - (ToNum(Get(ctm_4189, "b")) * ToNum(Get(ctm_4189, "c")))))) / ToNum(RSE_4079)))) is var _t4211 && Truthy(_t4211) ? _t4211 : ((V)(1D)))).Put("forced", (true ? V.True : V.False)).Put("k", (((V)(ToNum(Invoke(olg_4192, "getAttribute", ((V)("data-ol")))))) is var _t4212 && Truthy(_t4212) ? _t4212 : ((V)(1D)))).V);
return default;
}
ss_4193 = (((((!(Truthy(cl_4186)) && (fa_4190 >= 0.6)) ? V.True : V.False) is var _t4213 && !Truthy(_t4213) ? _t4213 : Get(cs_4184, "stroke")) is var _t4214 && !Truthy(_t4214) ? _t4214 : (!SEqS(Get(cs_4184, "stroke"), "none") ? V.True : V.False)) is var _t4215 && !Truthy(_t4215) ? _t4215 : (SEq(Get(cs_4184, "stroke"), Get(cs_4184, "fill")) ? V.True : V.False));
if (Truthy(ss_4193)) {
Set(it_4191, "ss", ((V)(1D)));
}
if (Truthy(((cl_4186 is var _t4216 && Truthy(_t4216) ? _t4216 : ((fa_4190 < 0.6) ? V.True : V.False)) is var _t4219 && Truthy(_t4219) ? _t4219 : ((Get(cs_4184, "stroke") is var _t4217 && !Truthy(_t4217) ? _t4217 : (!SEqS(Get(cs_4184, "stroke"), "none") ? V.True : V.False)) is var _t4218 && !Truthy(_t4218) ? _t4218 : (!(Truthy(ss_4193)) ? V.True : V.False))))) {
return default;
}
r_4194 = Invoke(e_4182, "getBoundingClientRect");
if (((ToNum(Get(r_4194, "width")) * ToNum(Get(r_4194, "height"))) < (RA_4077 * 0.004))) {
return default;
}
Invoke(info_4071, "push", it_4191);
return default;
}, 1, "", true));
@out_4085 = Arr();
R0_4086 = Invoke(root_4069, "getCTM");
rs_4087 = (((V)(System.Math.Sqrt(System.Math.Abs(((ToNum(Get(R0_4086, "a")) * ToNum(Get(R0_4086, "d"))) - (ToNum(Get(R0_4086, "b")) * ToNum(Get(R0_4086, "c")))))))) is var _t4220 && Truthy(_t4220) ? _t4220 : ((V)(1D)));
Invoke(info_4071, "forEach", Fn((V _arrowThis4229, int _argc4221, V it_4227, V i_4228, V _a4225, V _a4226, V[] _rest4222) => {
V len_4230 = default;
V bb_4231 = default;
double N_4232 = 0;
double cov_4233 = 0;
V under_4234 = default;
V bx_4235 = default;
V by_4236 = default;
len_4230 = ((V)(0D));
bb_4231 = V.Null;
try {
len_4230 = Invoke(Get(it_4227, "e"), "getTotalLength");
bb_4231 = Invoke(Get(it_4227, "e"), "getBBox");
} catch (System.Exception _ex4237) {
V x_4238 = default;
x_4238 = Caught(_ex4237);

}
if ((!(Truthy(len_4230)) || !(Truthy(bb_4231)))) {
return default;
}
N_4232 = 28D;
cov_4233 = 0D;
under_4234 = Invoke(all_4072, "slice", ((V)(0D)), Get(it_4227, "idx"));
bx_4235 = Add(Get(bb_4231, "x"), ((V)((ToNum(Get(bb_4231, "width")) / 2D))));
by_4236 = Add(Get(bb_4231, "y"), ((V)((ToNum(Get(bb_4231, "height")) / 2D))));
{
double j_4239 = 0;
j_4239 = 0D;
while (true) {
if (!((j_4239 < N_4232))) break;
V p0_4241 = default;
double vx_4242 = 0;
double vy_4243 = 0;
V vl_4244 = default;
double nd_4245 = 0;
V sp_4246 = default;
p0_4241 = Invoke(Get(it_4227, "e"), "getPointAtLength", ((V)(((ToNum(len_4230) * (j_4239 + 0.5)) / N_4232))));
vx_4242 = (ToNum(bx_4235) - ToNum(Get(p0_4241, "x")));
vy_4243 = (ToNum(by_4236) - ToNum(Get(p0_4241, "y")));
vl_4244 = (((V)(Hypot(vx_4242, vy_4243))) is var _t4247 && Truthy(_t4247) ? _t4247 : ((V)(1D)));
nd_4245 = Min(1.2, (ToNum(vl_4244) * 0.5));
sp_4246 = Invoke(New(G("DOMPoint"), Add(Get(p0_4241, "x"), ((V)(((vx_4242 / ToNum(vl_4244)) * nd_4245)))), Add(Get(p0_4241, "y"), ((V)(((vy_4243 / ToNum(vl_4244)) * nd_4245))))), "matrixTransform", Get(it_4227, "ctm"));
{
double k_4248 = 0;
k_4248 = 0D;
while (true) {
if (!(Lt(((V)(k_4248)), Get(under_4234, "length")))) break;
V lp_4250 = default;
if (Truthy(((Get(it_4227, "ss") is var _t4251 && !Truthy(_t4251) ? _t4251 : Get(GetIdx(under_4234, k_4248), "ss")) is var _t4252 && !Truthy(_t4252) ? _t4252 : (SEq(Get(Get(GetIdx(under_4234, k_4248), "e"), "parentNode"), Get(Get(it_4227, "e"), "parentNode")) ? V.True : V.False)))) {
goto _cont4249;
}
lp_4250 = Invoke(sp_4246, "matrixTransform", Get(GetIdx(under_4234, k_4248), "inv"));
if (Truthy(Invoke(Get(GetIdx(under_4234, k_4248), "e"), "isPointInFill", Call(sqSvgPt_88, V.Undef, Get(GetIdx(under_4234, k_4248), "e"), Get(lp_4250, "x"), Get(lp_4250, "y"))))) {
cov_4233++;
break;
}
_cont4249: ;
k_4248++;
}
}
j_4239++;
}
}
if (Truthy(Get(it_4227, "ss"))) {
if (Truthy(((((cov_4233 / N_4232) < 0.88) ? V.True : V.False) is var _t4253 && Truthy(_t4253) ? _t4253 : Invoke(roleOf_4081, "get", Get(it_4227, "e"))))) {
Invoke(tubes_4074, "push", Get(it_4227, "e"));
Invoke(filledT_4075, "add", Get(it_4227, "e"));
}
return default;
}
if (Truthy(((((cov_4233 / N_4232) < 0.88) ? V.True : V.False) is var _t4254 && Truthy(_t4254) ? _t4254 : Invoke(roleOf_4081, "get", Get(it_4227, "e"))))) {
Invoke(@out_4085, "push", NewObj(5).Put("e", Get(it_4227, "e")).Put("col", Call(rgbOf_78, V.Undef, Get(it_4227, "e"))).Put("sc", (((V)((System.Math.Sqrt(System.Math.Abs(((ToNum(Get(Get(it_4227, "ctm"), "a")) * ToNum(Get(Get(it_4227, "ctm"), "d"))) - (ToNum(Get(Get(it_4227, "ctm"), "b")) * ToNum(Get(Get(it_4227, "ctm"), "c")))))) / ToNum(rs_4087)))) is var _t4255 && Truthy(_t4255) ? _t4255 : ((V)(1D)))).Put("forced", (((cov_4233 / N_4232) >= 0.88) ? V.True : V.False)).Put("ft", Invoke(footOf_4082, "get", Get(it_4227, "e"))).V);
}
return default;
}, 2, "", true));
grp_4088 = New(G("Map"));
Invoke(@out_4085, "forEach", Fn((V _arrowThis4263, int _argc4256, V o_4262, V _a4259, V _a4260, V _a4261, V[] _rest4257) => {
V k_4264 = default;
k_4264 = ((V)(JsStrBuf.Begin().V(((Get(Get(o_4262, "e"), "parentNode") is var _t4265 && !Truthy(_t4265) ? _t4265 : Get(Get(Get(o_4262, "e"), "parentNode"), "__olk")) is var _t4266 && Truthy(_t4266) ? _t4266 : Set(Get(Get(o_4262, "e"), "parentNode"), "__olk", Invoke(G("Math"), "random")))).S(":").V(Invoke(Invoke(Get(o_4262, "col"), "map", Fn((V _arrowThis4274, int _argc4267, V v_4273, V _a4270, V _a4271, V _a4272, V[] _rest4268) => {
return ((V)(Round((ToNum(v_4273) / 22D))));
}, 1, "", true)), "join", ((V)(",")))).End()));
Invoke((Invoke(grp_4088, "get", k_4264) is var _t4275 && Truthy(_t4275) ? _t4275 : Invoke(Invoke(grp_4088, "set", k_4264, Arr()), "get", k_4264)), "push", o_4262);
return default;
}, 1, "", true));
ci_4089 = 0D;
Invoke(grp_4088, "forEach", Fn((V _arrowThis4283, int _argc4276, V list_4282, V _a4279, V _a4280, V _a4281, V[] _rest4277) => {
if (GeN(Get(list_4282, "length"), 5D)) {
ci_4089++;
Invoke(list_4282, "forEach", Fn((V _arrowThis4291, int _argc4284, V o_4290, V _a4287, V _a4288, V _a4289, V[] _rest4285) => {
Set(o_4290, "cl", ((V)(ci_4089)));
return default;
}, 1, "", true));
}
return default;
}, 1, "", true));
Invoke(each_4078, "forEach", Fn((V _arrowThis4299, int _argc4292, V o_4298, V _a4295, V _a4296, V _a4297, V[] _rest4293) => {
return Invoke(@out_4085, "push", o_4298);
}, 1, "", true));
tb_4090 = Invoke(tubes_4074, "map", Fn((V _arrowThis4307, int _argc4300, V e_4306, V _a4303, V _a4304, V _a4305, V[] _rest4301) => {
V cs_4308 = default;
V c_4309 = default;
V fl_4310 = default;
cs_4308 = Call(G("getComputedStyle"), V.Undef, e_4306);
c_4309 = Invoke(e_4306, "getCTM");
fl_4310 = Invoke(filledT_4075, "has", e_4306);
return NewObj(7).Put("e", e_4306).Put("fl", fl_4310).Put("sw0", (((V)(ParseFloat(Get(cs_4308, "strokeWidth")))) is var _t4311 && Truthy(_t4311) ? _t4311 : ((V)((Truthy(fl_4310) ? 0D : 1D))))).Put("cap", (Get(cs_4308, "strokeLinecap") is var _t4312 && Truthy(_t4312) ? _t4312 : ((V)("round")))).Put("join", (Get(cs_4308, "strokeLinejoin") is var _t4313 && Truthy(_t4313) ? _t4313 : ((V)("round")))).Put("col", (Truthy(fl_4310) ? Call(rgbOf_78, V.Undef, e_4306) : (Call(rgbP_77, V.Undef, Get(cs_4308, "stroke")) is var _t4314 && Truthy(_t4314) ? _t4314 : Arr(((V)(180D)), ((V)(120D)), ((V)(80D)))))).Put("sc", (Truthy(c_4309) ? (((V)((System.Math.Sqrt(System.Math.Abs(((ToNum(Get(c_4309, "a")) * ToNum(Get(c_4309, "d"))) - (ToNum(Get(c_4309, "b")) * ToNum(Get(c_4309, "c")))))) / ToNum(rs_4087)))) is var _t4315 && Truthy(_t4315) ? _t4315 : ((V)(1D))) : ((V)(1D)))).V;
return default;
}, 1, "", true));
return NewObj(3).Put("out", @out_4085).Put("late", late_4073).Put("tubes", tb_4090).V;
return default;
}, 1, "outlineEls", false);
outline_91 = Fn((V _self4316, int _argc4317, V I_4323, V _a4320, V _a4321, V _a4322, V[] _rest4318) => {
V L_4324 = default;
V lw_4325 = default;
V stk_4326 = default;
if (_self4316.IsNullish) _self4316 = GlobalV;
if (Truthy((Get(I_4323, "generic") is var _t4327 && !Truthy(_t4327) ? _t4327 : (!(Truthy(Get(I_4323, "ready"))) ? V.True : V.False)))) {
return default;
}
if ((!(Truthy(Get(I_4323, "olEls"))) && !(Truthy((Get(I_4323, "curL") is var _t4328 && !Truthy(_t4328) ? _t4328 : Get(Get(I_4323, "curL"), "line")))))) {
Set(I_4323, "olDirty", ((V)(0D)));
return default;
}
if (!(Truthy(Get(I_4323, "olEls")))) {
V r_4329 = default;
r_4329 = Call(outlineEls_89, V.Undef, I_4323);
if (!(Truthy(r_4329))) {
return default;
}
Set(I_4323, "olEls", Get(r_4329, "out"));
Set(I_4323, "olLate", Get(r_4329, "late"));
Set(I_4323, "olTubes", Get(r_4329, "tubes"));
Set(I_4323, "olN", ((V)(0D)));
}
L_4324 = Get(I_4323, "curL");
lw_4325 = ((L_4324 is var _t4330 && !Truthy(_t4330) ? _t4330 : Get(L_4324, "line")) is var _t4331 && Truthy(_t4331) ? _t4331 : ((V)(0D)));
Set(I_4323, "olDirty", ((V)(0D)));
if (!(Truthy(Get(I_4323, "generic")))) {
Call(faceLines_87, V.Undef, I_4323, L_4324);
}
Invoke(Get(I_4323, "olEls"), "forEach", Fn((V _arrowThis4339, int _argc4332, V o_4338, V _a4335, V _a4336, V _a4337, V[] _rest4333) => {
V e_4340 = default;
e_4340 = Get(o_4338, "e");
if (Truthy(Get(o_4338, "cl"))) {
V g_4341 = default;
g_4341 = GetK((Get(I_4323, "olCl") is var _t4342 && Truthy(_t4342) ? _t4342 : Set(I_4323, "olCl", NewObj(0).V)), Get(o_4338, "cl"));
if (!(Truthy(g_4341))) {
g_4341 = SetK(Get(I_4323, "olCl"), Get(o_4338, "cl"), Invoke(G("document"), "createElementNS", SVGNS_90, ((V)("g"))));
Invoke(g_4341, "setAttribute", ((V)("data-lt")), ((V)(1D)));
Invoke(g_4341, "setAttribute", ((V)("pointer-events")), ((V)("none")));
Invoke(e_4340, "before", g_4341);
}
if (!(Truthy(Get(o_4338, "use")))) {
if (!(Truthy(Get(e_4340, "id")))) {
Set(e_4340, "id", ((V)(JsStrBuf.Begin().S("olc").V((Get(I_4323, "u") is var _t4343 && Truthy(_t4343) ? _t4343 : ((V)("")))).S("_").V(Invoke(Invoke(Invoke(G("Math"), "random"), "toString", ((V)(36D))), "slice", ((V)(2D)), ((V)(8D)))).End())));
}
Set(o_4338, "use", Invoke(G("document"), "createElementNS", SVGNS_90, ((V)("use"))));
Invoke(Get(o_4338, "use"), "setAttribute", ((V)("href")), ((V)(JsStrBuf.Begin().S("#").V(Get(e_4340, "id")).End())));
Invoke(g_4341, "appendChild", Get(o_4338, "use"));
}
Set(Get(g_4341, "style"), "display", ((V)((Truthy(lw_4325) ? "" : "none"))));
if (Truthy(lw_4325)) {
Invoke(g_4341, "setAttribute", ((V)("stroke")), (Get(L_4324, "lineC") is var _t4344 && Truthy(_t4344) ? _t4344 : Call(lineOf_81, V.Undef, Get(o_4338, "col"))));
Invoke(g_4341, "setAttribute", ((V)("stroke-width")), Call(r2_14, V.Undef, ((V)(((ToNum(lw_4325) * 2D) / ToNum(Get(o_4338, "sc")))))));
Invoke(g_4341, "setAttribute", ((V)("stroke-linejoin")), ((V)("round")));
}
return default;
}
if (Truthy(Get(o_4338, "ft"))) {
Invoke(Arr(((V)("stroke")), ((V)("stroke-width")), ((V)("stroke-linejoin")), ((V)("paint-order"))), "forEach", Fn((V _arrowThis4352, int _argc4345, V a_4351, V _a4348, V _a4349, V _a4350, V[] _rest4346) => {
return Invoke(e_4340, "removeAttribute", a_4351);
}, 1, "", true));
if (!(Truthy(Get(o_4338, "fo")))) {
Set(o_4338, "fo", Invoke(G("document"), "createElementNS", SVGNS_90, ((V)("path"))));
Invoke(Get(o_4338, "fo"), "setAttribute", ((V)("fill")), ((V)("none")));
Invoke(Get(o_4338, "fo"), "setAttribute", ((V)("stroke-linejoin")), ((V)("round")));
Invoke(Get(o_4338, "fo"), "setAttribute", ((V)("data-lt")), ((V)(1D)));
Invoke(Get(o_4338, "fo"), "setAttribute", ((V)("pointer-events")), ((V)("none")));
Invoke(e_4340, "before", Get(o_4338, "fo"));
}
Set(Get(Get(o_4338, "fo"), "style"), "display", ((V)((Truthy(lw_4325) ? "" : "none"))));
Set(o_4338, "fd", V.Null);
if (Truthy(lw_4325)) {
Invoke(Get(o_4338, "fo"), "setAttribute", ((V)("stroke")), (Get(L_4324, "lineC") is var _t4353 && Truthy(_t4353) ? _t4353 : Call(lineOf_81, V.Undef, Get(o_4338, "col"))));
Invoke(Get(o_4338, "fo"), "setAttribute", ((V)("stroke-width")), Call(r2_14, V.Undef, ((V)(((ToNum(lw_4325) * 2D) / ToNum(Get(o_4338, "sc")))))));
}
return default;
}
if (Truthy(lw_4325)) {
Invoke(e_4340, "setAttribute", ((V)("stroke")), (Get(L_4324, "lineC") is var _t4354 && Truthy(_t4354) ? _t4354 : Call(lineOf_81, V.Undef, Get(o_4338, "col"))));
Invoke(e_4340, "setAttribute", ((V)("stroke-width")), Call(r2_14, V.Undef, ((V)((((ToNum(lw_4325) * 2D) * ToNum((Get(o_4338, "k") is var _t4355 && Truthy(_t4355) ? _t4355 : ((V)(1D))))) / ToNum(Get(o_4338, "sc")))))));
Invoke(e_4340, "setAttribute", ((V)("stroke-linejoin")), ((V)("round")));
Invoke(e_4340, "setAttribute", ((V)("paint-order")), ((V)("stroke")));
} else {
Invoke(Arr(((V)("stroke")), ((V)("stroke-width")), ((V)("stroke-linejoin")), ((V)("paint-order"))), "forEach", Fn((V _arrowThis4363, int _argc4356, V a_4362, V _a4359, V _a4360, V _a4361, V[] _rest4357) => {
return Invoke(e_4340, "removeAttribute", a_4362);
}, 1, "", true));
}
return default;
}, 1, "", true));
if (Truthy(((!(Truthy(Get(I_4323, "generic"))) ? V.True : V.False) is var _t4364 && !Truthy(_t4364) ? _t4364 : Get(I_4323, "E")))) {
Invoke((Get(Get(I_4323, "E"), "ears") is var _t4382 && Truthy(_t4382) ? _t4382 : Arr()), "forEach", Fn((V _arrowThis4372, int _argc4365, V x_4371, V _a4368, V _a4369, V _a4370, V[] _rest4366) => {
return Invoke((Get(x_4371, "mk") is var _t4381 && Truthy(_t4381) ? _t4381 : Arr()), "forEach", Fn((V _arrowThis4380, int _argc4373, V m_4379, V _a4376, V _a4377, V _a4378, V[] _rest4374) => {
if (Truthy(lw_4325)) {
Invoke(m_4379, "setAttribute", ((V)("stroke")), ((V)("#000")));
Invoke(m_4379, "setAttribute", ((V)("stroke-width")), Call(r2_14, V.Undef, ((V)((ToNum(lw_4325) * 2D)))));
Invoke(m_4379, "setAttribute", ((V)("stroke-linejoin")), ((V)("round")));
} else {
Invoke(m_4379, "removeAttribute", ((V)("stroke")));
}
return default;
}, 1, "", true));
}, 1, "", true));
}
stk_4326 = (Get(I_4323, "olStk") is var _t4383 && Truthy(_t4383) ? _t4383 : Set(I_4323, "olStk", New(G("Map"))));
Invoke((Get(I_4323, "olTubes") is var _t4395 && Truthy(_t4395) ? _t4395 : Arr()), "forEach", Fn((V _arrowThis4391, int _argc4384, V t_4390, V _a4387, V _a4388, V _a4389, V[] _rest4385) => {
V par_4392 = default;
V S_4393 = default;
if (!(Truthy(Get(t_4390, "fl")))) {
return default;
}
par_4392 = Get(Get(t_4390, "e"), "parentNode");
if (!(Truthy(par_4392))) {
return default;
}
S_4393 = Invoke(stk_4326, "get", par_4392);
if (!(Truthy(S_4393))) {
V g_4394 = default;
g_4394 = Get(par_4392, "__olTube");
if ((!(Truthy(g_4394)) || !SEq(Get(g_4394, "parentNode"), par_4392))) {
g_4394 = Set(par_4392, "__olTube", Invoke(G("document"), "createElementNS", SVGNS_90, ((V)("g"))));
Invoke(g_4394, "setAttribute", ((V)("data-lt")), ((V)(1D)));
Invoke(g_4394, "setAttribute", ((V)("pointer-events")), ((V)("none")));
Invoke(g_4394, "setAttribute", ((V)("fill")), ((V)("none")));
Invoke(par_4392, "insertBefore", g_4394, Get(par_4392, "firstChild"));
}
S_4393 = NewObj(3).Put("par", par_4392).Put("ts", Arr()).Put("p", Invoke(G("document"), "createElementNS", SVGNS_90, ((V)("path")))).V;
Invoke(Get(S_4393, "p"), "setAttribute", ((V)("stroke-linecap")), ((V)("round")));
Invoke(Get(S_4393, "p"), "setAttribute", ((V)("stroke-linejoin")), ((V)("round")));
Set(Get(Get(S_4393, "p"), "style"), "display", ((V)("none")));
Invoke(g_4394, "appendChild", Get(S_4393, "p"));
Invoke(stk_4326, "set", par_4392, S_4393);
}
if (LtN(Invoke(Get(S_4393, "ts"), "indexOf", t_4390), 0D)) {
Invoke(Get(S_4393, "ts"), "push", t_4390);
}
return default;
}, 1, "", true));
Invoke(stk_4326, "forEach", Fn((V _arrowThis4403, int _argc4396, V S_4402, V _a4399, V _a4400, V _a4401, V[] _rest4397) => {
Invoke(Get(S_4402, "p"), "setAttribute", ((V)("stroke")), ((L_4324 is var _t4404 && !Truthy(_t4404) ? _t4404 : Get(L_4324, "lineC")) is var _t4405 && Truthy(_t4405) ? _t4405 : Call(lineOf_81, V.Undef, Get(GetIdx(Get(S_4402, "ts"), 0D), "col"))));
Set(S_4402, "d", Set(S_4402, "w", Set(S_4402, "o", Set(S_4402, "tr", V.Undef))));
if (!(Truthy(lw_4325))) {
Set(Get(Get(S_4402, "p"), "style"), "display", ((V)("none")));
}
return default;
}, 1, "", true));
Invoke((Get(I_4323, "olTubes") is var _t4419 && Truthy(_t4419) ? _t4419 : Arr()), "forEach", Fn((V _arrowThis4413, int _argc4406, V t_4412, V _a4409, V _a4410, V _a4411, V[] _rest4407) => {
V par_4414 = default;
par_4414 = Get(Get(t_4412, "e"), "parentNode");
if (Truthy(((!(Truthy(par_4414)) ? V.True : V.False) is var _t4415 && Truthy(_t4415) ? _t4415 : Get(t_4412, "fl")))) {
return default;
}
if (!(Truthy(Get(t_4412, "p")))) {
V g_4416 = default;
g_4416 = Get(par_4414, "__olTube");
if ((!(Truthy(g_4416)) || !SEq(Get(g_4416, "parentNode"), par_4414))) {
g_4416 = Set(par_4414, "__olTube", Invoke(G("document"), "createElementNS", SVGNS_90, ((V)("g"))));
Invoke(g_4416, "setAttribute", ((V)("data-lt")), ((V)(1D)));
Invoke(g_4416, "setAttribute", ((V)("pointer-events")), ((V)("none")));
Invoke(g_4416, "setAttribute", ((V)("fill")), ((V)("none")));
Invoke(par_4414, "insertBefore", g_4416, Get(par_4414, "firstChild"));
}
Set(t_4412, "p", Invoke(G("document"), "createElementNS", SVGNS_90, ((V)("path"))));
Invoke(Get(t_4412, "p"), "setAttribute", ((V)("stroke-linecap")), Get(t_4412, "cap"));
Invoke(Get(t_4412, "p"), "setAttribute", ((V)("stroke-linejoin")), Get(t_4412, "join"));
Set(Get(Get(t_4412, "p"), "style"), "display", ((V)("none")));
Invoke(g_4416, "appendChild", Get(t_4412, "p"));
Set(t_4412, "d", Set(t_4412, "w", Set(t_4412, "o", Set(t_4412, "tr", V.Null))));
}
Invoke(Get(t_4412, "p"), "setAttribute", ((V)("stroke")), ((L_4324 is var _t4417 && !Truthy(_t4417) ? _t4417 : Get(L_4324, "lineC")) is var _t4418 && Truthy(_t4418) ? _t4418 : Call(lineOf_81, V.Undef, Get(t_4412, "col"))));
Set(t_4412, "w", V.Null);
if (!(Truthy(lw_4325))) {
Set(Get(Get(t_4412, "p"), "style"), "display", ((V)("none")));
}
return default;
}, 1, "", true));
return default;
}, 1, "outline", false);
outlineTick_92 = Fn((V _self4420, int _argc4421, V I_4427, V _a4424, V _a4425, V _a4426, V[] _rest4422) => {
V L_4428 = default;
V lw_4429 = default;
if (_self4420.IsNullish) _self4420 = GlobalV;
L_4428 = Get(I_4427, "curL");
lw_4429 = ((L_4428 is var _t4430 && !Truthy(_t4430) ? _t4430 : Get(L_4428, "line")) is var _t4431 && Truthy(_t4431) ? _t4431 : ((V)(0D)));
if ((!(Truthy(lw_4429)) || !(Truthy(Get(I_4427, "olEls"))))) {
return default;
}
if (!(Truthy(Get(I_4427, "generic")))) {
V pb_4432 = default;
pb_4432 = Get(Get(I_4427, "pg"), "body");
Invoke(Get(I_4427, "olEls"), "forEach", Fn((V _arrowThis4440, int _argc4433, V o_4439, V _a4436, V _a4437, V _a4438, V[] _rest4434) => {
V e_4441 = default;
V pf_4442 = default;
V vis_4443 = default;
V d_4444 = default;
if (!(Truthy(Get(o_4439, "fo")))) {
return default;
}
e_4441 = Get(o_4439, "e");
pf_4442 = GetK(Get(I_4427, "pg"), Get(o_4439, "ft"));
vis_4443 = ((Get(e_4441, "isConnected") is var _t4445 && !Truthy(_t4445) ? _t4445 : (!SEqS(Get(Get(e_4441, "style"), "display"), "none") ? V.True : V.False)) is var _t4446 && !Truthy(_t4446) ? _t4446 : (!SEqS(Invoke(e_4441, "getAttribute", ((V)("opacity"))), "0") ? V.True : V.False));
if (!(Truthy(vis_4443))) {
if (!SEqS(Get(Get(Get(o_4439, "fo"), "style"), "display"), "none")) {
Set(Get(Get(o_4439, "fo"), "style"), "display", ((V)("none")));
}
return default;
}
if (SEqS(Get(Get(Get(o_4439, "fo"), "style"), "display"), "none")) {
Set(Get(Get(o_4439, "fo"), "style"), "display", ((V)("")));
}
if (Truthy(((pb_4432 is var _t4447 && !Truthy(_t4447) ? _t4447 : pf_4442) is var _t4448 && !Truthy(_t4448) ? _t4448 : ((V)(((double)(ToInt32(ToNum(Invoke(pb_4432, "compareDocumentPosition", pf_4442))) & ToInt32(4D)))))))) {
V g_4449 = default;
V po_4450 = default;
g_4449 = Get(I_4427, "olFootG");
if ((!(Truthy(g_4449)) || !SEq(Get(g_4449, "parentNode"), pb_4432))) {
g_4449 = Set(I_4427, "olFootG", Invoke(G("document"), "createElementNS", SVGNS_90, ((V)("g"))));
Invoke(g_4449, "setAttribute", ((V)("data-lt")), ((V)(1D)));
Invoke(g_4449, "setAttribute", ((V)("pointer-events")), ((V)("none")));
}
if (!SEq(Get(pb_4432, "firstChild"), g_4449)) {
Invoke(pb_4432, "insertBefore", g_4449, Get(pb_4432, "firstChild"));
}
if (!SEq(Get(Get(o_4439, "fo"), "parentNode"), g_4449)) {
Invoke(g_4449, "appendChild", Get(o_4439, "fo"));
}
po_4450 = Invoke(pf_4442, "getAttribute", ((V)("opacity")));
if (!SEq(Get(o_4439, "po"), po_4450)) {
Set(o_4439, "po", po_4450);
if (po_4450.IsNullish) {
Invoke(Get(o_4439, "fo"), "removeAttribute", ((V)("opacity")));
} else {
Invoke(Get(o_4439, "fo"), "setAttribute", ((V)("opacity")), po_4450);
}
}
} else {
if (!SEq(Get(Get(o_4439, "fo"), "nextSibling"), e_4441)) {
Invoke(e_4441, "before", Get(o_4439, "fo"));
}
if (!Get(o_4439, "po").IsNullish) {
Set(o_4439, "po", V.Null);
Invoke(Get(o_4439, "fo"), "removeAttribute", ((V)("opacity")));
}
}
d_4444 = (Invoke(e_4441, "getAttribute", ((V)("d"))) is var _t4451 && Truthy(_t4451) ? _t4451 : ((V)("")));
if (!SEq(Get(o_4439, "fd"), d_4444)) {
Set(o_4439, "fd", d_4444);
Invoke(Get(o_4439, "fo"), "setAttribute", ((V)("d")), d_4444);
}
return default;
}, 1, "", true));
}
if (Truthy(Get(I_4427, "olStk"))) {
Invoke(Get(I_4427, "olStk"), "forEach", Fn((V _arrowThis4459, int _argc4452, V S_4458, V _a4455, V _a4456, V _a4457, V[] _rest4453) => {
JsStrBuf d_4460 = null;
V w_4461 = default;
V o_4462 = default;
V tr_4463 = default;
double f_4464 = 0;
V g_4465 = default;
d_4460 = new JsStrBuf("");
w_4461 = ((V)(0D));
o_4462 = V.Null;
tr_4463 = V.Null;
f_4464 = 1D;
{
foreach (V _k4466 in new JsIter(Get(S_4458, "ts"))) {
V t_4467 = default;
t_4467 = _k4466;
V e_4468 = default;
V op_4469 = default;
V dd_4470 = default;
V swA_4471 = default;
V sw_4472 = default;
e_4468 = Get(t_4467, "e");
if (((!(Truthy(Get(e_4468, "isConnected"))) || !SEq(Get(e_4468, "parentNode"), Get(S_4458, "par"))) || SEqS(Get(Get(e_4468, "style"), "display"), "none"))) {
continue;
}
op_4469 = Invoke(e_4468, "getAttribute", ((V)("opacity")));
dd_4470 = Invoke(e_4468, "getAttribute", ((V)("d")));
if ((SEqS(op_4469, "0") || !(Truthy(dd_4470)))) {
continue;
}
d_4460.V(dd_4470).S(" ");
swA_4471 = Invoke(e_4468, "getAttribute", ((V)("stroke-width")));
sw_4472 = Add((!swA_4471.IsNullish ? ((V)(ParseFloat(swA_4471))) : Get(t_4467, "sw0")), ((V)(((2D * ToNum(lw_4429)) / ToNum(Get(t_4467, "sc"))))));
if (Gt(sw_4472, w_4461)) {
w_4461 = sw_4472;
}
if (NumTruthy(f_4464)) {
f_4464 = 0D;
o_4462 = op_4469;
tr_4463 = Invoke(e_4468, "getAttribute", ((V)("transform")));
}
}
}
if (!(((d_4460.Str).Length != 0))) {
if (!SEqS(Get(Get(Get(S_4458, "p"), "style"), "display"), "none")) {
Set(Get(Get(S_4458, "p"), "style"), "display", ((V)("none")));
}
return default;
}
if (SEqS(Get(Get(Get(S_4458, "p"), "style"), "display"), "none")) {
Set(Get(Get(S_4458, "p"), "style"), "display", ((V)("")));
}
g_4465 = Get(Get(S_4458, "p"), "parentNode");
if (Truthy((g_4465 is var _t4473 && !Truthy(_t4473) ? _t4473 : (!SEq(Get(Get(S_4458, "par"), "firstChild"), g_4465) ? V.True : V.False)))) {
Invoke(Get(S_4458, "par"), "insertBefore", g_4465, Get(Get(S_4458, "par"), "firstChild"));
}
if (!SEqS(Get(S_4458, "d"), d_4460.Str)) {
Set(S_4458, "d", ((V)(d_4460.Str)));
Invoke(Get(S_4458, "p"), "setAttribute", ((V)("d")), ((V)(d_4460.Str)));
}
w_4461 = Call(r2_14, V.Undef, w_4461);
if (!SEq(Get(S_4458, "w"), w_4461)) {
Set(S_4458, "w", w_4461);
Invoke(Get(S_4458, "p"), "setAttribute", ((V)("stroke-width")), w_4461);
}
if (!SEq(Get(S_4458, "o"), o_4462)) {
Set(S_4458, "o", o_4462);
if (o_4462.IsNullish) {
Invoke(Get(S_4458, "p"), "removeAttribute", ((V)("opacity")));
} else {
Invoke(Get(S_4458, "p"), "setAttribute", ((V)("opacity")), o_4462);
}
}
if (!SEq(Get(S_4458, "tr"), tr_4463)) {
Set(S_4458, "tr", tr_4463);
if (tr_4463.IsNullish) {
Invoke(Get(S_4458, "p"), "removeAttribute", ((V)("transform")));
} else {
Invoke(Get(S_4458, "p"), "setAttribute", ((V)("transform")), tr_4463);
}
}
return default;
}, 1, "", true));
}
Invoke((Get(I_4427, "olTubes") is var _t4495 && Truthy(_t4495) ? _t4495 : Arr()), "forEach", Fn((V _arrowThis4481, int _argc4474, V t_4480, V _a4477, V _a4478, V _a4479, V[] _rest4475) => {
V e_4482 = default;
V swA_4483 = default;
V sw_4484 = default;
V op_4485 = default;
V par_4486 = default;
V d_4487 = default;
V w_4488 = default;
V tr_4489 = default;
if (!(Truthy(Get(t_4480, "p")))) {
return default;
}
e_4482 = Get(t_4480, "e");
swA_4483 = Invoke(e_4482, "getAttribute", ((V)("stroke-width")));
sw_4484 = (!swA_4483.IsNullish ? ((V)(ParseFloat(swA_4483))) : Get(t_4480, "sw0"));
op_4485 = Invoke(e_4482, "getAttribute", ((V)("opacity")));
if ((((SEqS(Get(Get(e_4482, "style"), "display"), "none") || SEqS(op_4485, "0")) || !(Truthy((Get(t_4480, "fl") is var _t4490 && Truthy(_t4490) ? _t4490 : (GeN(sw_4484, 3D) ? V.True : V.False))))) || !(Truthy(Get(e_4482, "isConnected"))))) {
if (!SEqS(Get(Get(Get(t_4480, "p"), "style"), "display"), "none")) {
Set(Get(Get(t_4480, "p"), "style"), "display", ((V)("none")));
}
return default;
}
par_4486 = Get(e_4482, "parentNode");
if (Truthy((Get(Get(t_4480, "p"), "parentNode") is var _t4491 && !Truthy(_t4491) ? _t4491 : (!SEq(Get(Get(Get(t_4480, "p"), "parentNode"), "parentNode"), par_4486) ? V.True : V.False)))) {
V g_4492 = default;
g_4492 = Get(par_4486, "__olTube");
if ((!(Truthy(g_4492)) || !SEq(Get(g_4492, "parentNode"), par_4486))) {
g_4492 = Set(par_4486, "__olTube", Invoke(G("document"), "createElementNS", SVGNS_90, ((V)("g"))));
Invoke(g_4492, "setAttribute", ((V)("data-lt")), ((V)(1D)));
Invoke(g_4492, "setAttribute", ((V)("pointer-events")), ((V)("none")));
Invoke(g_4492, "setAttribute", ((V)("fill")), ((V)("none")));
Invoke(par_4486, "insertBefore", g_4492, Get(par_4486, "firstChild"));
}
Invoke(g_4492, "appendChild", Get(t_4480, "p"));
} else {
if (Truthy(((!SEq(Get(par_4486, "firstChild"), Get(Get(t_4480, "p"), "parentNode")) ? V.True : V.False) is var _t4493 && !Truthy(_t4493) ? _t4493 : Get(Get(t_4480, "p"), "parentNode")))) {
Invoke(par_4486, "insertBefore", Get(Get(t_4480, "p"), "parentNode"), Get(par_4486, "firstChild"));
}
}
if (SEqS(Get(Get(Get(t_4480, "p"), "style"), "display"), "none")) {
Set(Get(Get(t_4480, "p"), "style"), "display", ((V)("")));
}
d_4487 = (Invoke(e_4482, "getAttribute", ((V)("d"))) is var _t4494 && Truthy(_t4494) ? _t4494 : ((V)("")));
if (!SEq(Get(t_4480, "d"), d_4487)) {
Set(t_4480, "d", d_4487);
Invoke(Get(t_4480, "p"), "setAttribute", ((V)("d")), d_4487);
}
w_4488 = Call(r2_14, V.Undef, Add(sw_4484, ((V)(((2D * ToNum(lw_4429)) / ToNum(Get(t_4480, "sc")))))));
if (!SEq(Get(t_4480, "w"), w_4488)) {
Set(t_4480, "w", w_4488);
Invoke(Get(t_4480, "p"), "setAttribute", ((V)("stroke-width")), w_4488);
}
if (!SEq(Get(t_4480, "o"), op_4485)) {
Set(t_4480, "o", op_4485);
if (op_4485.IsNullish) {
Invoke(Get(t_4480, "p"), "removeAttribute", ((V)("opacity")));
} else {
Invoke(Get(t_4480, "p"), "setAttribute", ((V)("opacity")), op_4485);
}
}
tr_4489 = Invoke(e_4482, "getAttribute", ((V)("transform")));
if (!SEq(Get(t_4480, "tr"), tr_4489)) {
Set(t_4480, "tr", tr_4489);
if (tr_4489.IsNullish) {
Invoke(Get(t_4480, "p"), "removeAttribute", ((V)("transform")));
} else {
Invoke(Get(t_4480, "p"), "setAttribute", ((V)("transform")), tr_4489);
}
}
return default;
}, 1, "", true));
if (Truthy(((Get(I_4427, "olLate") is var _t4496 && !Truthy(_t4496) ? _t4496 : Get(Get(I_4427, "olLate"), "length")) is var _t4497 && !Truthy(_t4497) ? _t4497 : (((IncM(I_4427, "olN", 1D, true) % 20D) == 0D) ? V.True : V.False)))) {
V root_4498 = default;
V seen_4499 = default;
root_4498 = (Get(I_4427, "root") is var _t4500 && Truthy(_t4500) ? _t4500 : Get(I_4427, "art"));
seen_4499 = Invoke(Get(I_4427, "olLate"), "some", Fn((V _arrowThis4508, int _argc4501, V e_4507, V _a4504, V _a4505, V _a4506, V[] _rest4502) => {
V a_4509 = default;
double op_4510 = 0;
if (!(Truthy(Get(e_4507, "isConnected")))) {
return (false ? V.True : V.False);
}
a_4509 = e_4507;
op_4510 = 1D;
while (Truthy(((a_4509 is var _t4511 && !Truthy(_t4511) ? _t4511 : (!SEq(a_4509, root_4498) ? V.True : V.False)) is var _t4512 && !Truthy(_t4512) ? _t4512 : (SEqN(Get(a_4509, "nodeType"), 1D) ? V.True : V.False)))) {
V s2_4513 = default;
s2_4513 = Call(G("getComputedStyle"), V.Undef, a_4509);
if (SEqS(Get(s2_4513, "display"), "none")) {
return (false ? V.True : V.False);
}
op_4510 = (op_4510 * ToNum(Get(s2_4513, "opacity")));
a_4509 = Get(a_4509, "parentNode");
}
return ((op_4510 >= 0.6) ? V.True : V.False);
return default;
}, 1, "", true));
if (Truthy(seen_4499)) {
V r_4514 = default;
r_4514 = Call(outlineEls_89, V.Undef, I_4427);
if (Truthy(r_4514)) {
V have_4515 = default;
V tb_4516 = default;
have_4515 = New(G("Set"), Invoke(Get(I_4427, "olEls"), "map", Fn((V _arrowThis4524, int _argc4517, V o_4523, V _a4520, V _a4521, V _a4522, V[] _rest4518) => {
return Get(o_4523, "e");
}, 1, "", true)));
tb_4516 = New(G("Set"), Invoke((Get(I_4427, "olTubes") is var _t4533 && Truthy(_t4533) ? _t4533 : Arr()), "map", Fn((V _arrowThis4532, int _argc4525, V t_4531, V _a4528, V _a4529, V _a4530, V[] _rest4526) => {
return Get(t_4531, "e");
}, 1, "", true)));
Invoke(Get(r_4514, "out"), "forEach", Fn((V _arrowThis4541, int _argc4534, V o_4540, V _a4537, V _a4538, V _a4539, V[] _rest4535) => {
if (!(Truthy(Invoke(have_4515, "has", Get(o_4540, "e"))))) {
Invoke(Get(I_4427, "olEls"), "push", o_4540);
}
return default;
}, 1, "", true));
Invoke(Get(r_4514, "tubes"), "forEach", Fn((V _arrowThis4549, int _argc4542, V t_4548, V _a4545, V _a4546, V _a4547, V[] _rest4543) => {
if (!(Truthy(Invoke(tb_4516, "has", Get(t_4548, "e"))))) {
Invoke(Get(I_4427, "olTubes"), "push", t_4548);
}
return default;
}, 1, "", true));
Set(I_4427, "olLate", Invoke(Get(I_4427, "olLate"), "filter", Fn((V _arrowThis4557, int _argc4550, V e_4556, V _a4553, V _a4554, V _a4555, V[] _rest4551) => {
return (GeN(Invoke(Get(r_4514, "late"), "indexOf", e_4556), 0D) ? V.True : V.False);
}, 1, "", true)));
Call(outline_91, V.Undef, I_4427);
}
}
}
return default;
}, 1, "outlineTick", false);
setLight_93 = Fn((V _self4558, int _argc4559, V I_4565, V L_4566, V _a4563, V _a4564, V[] _rest4560) => {
V svg_4567 = default;
V u_4568 = default;
V NS_4569 = default;
V df_4570 = default;
V mkL_4571 = default;
V T_4572 = default;
V tintOn_4573 = default;
V st_4574 = default;
V ac_4575 = default;
V rc_4576 = default;
V sh_4577 = default;
V mix_4578 = default;
V d_4579 = default;
V n_4580 = default;
V oc_4581 = default;
if (_self4558.IsNullish) _self4558 = GlobalV;
svg_4567 = (Get(I_4565, "root") is var _t4582 && !Truthy(_t4582) ? _t4582 : Get(Get(I_4565, "root"), "ownerSVGElement"));
if (!(Truthy(svg_4567))) {
return default;
}
u_4568 = Get(I_4565, "u");
NS_4569 = ((V)("http://www.w3.org/2000/svg"));
df_4570 = Invoke(svg_4567, "querySelector", ((V)("defs")));
mkL_4571 = Fn((V _arrowThis4592, int _argc4583, V tag_4589, V at_4590, V par_4591, V _a4588, V[] _rest4584) => {
V e_4593 = default;
e_4593 = Invoke(G("document"), "createElementNS", NS_4569, tag_4589);
Invoke(Object_keys(at_4590), "forEach", Fn((V _arrowThis4601, int _argc4594, V k_4600, V _a4597, V _a4598, V _a4599, V[] _rest4595) => {
return Invoke(e_4593, "setAttribute", k_4600, GetK(at_4590, k_4600));
}, 1, "", true));
if (Truthy(par_4591)) {
Invoke(par_4591, "appendChild", e_4593);
}
return e_4593;
return default;
}, 3, "", true);
if (!(Truthy(Get(I_4565, "lt")))) {
V R_4602 = default;
V gm_4603 = default;
V tint_4604 = default;
V cast_4605 = default;
V part_4606 = default;
V E0_4607 = default;
V tailOL_4608 = default;
V wg0_4609 = default;
V whOL_4610 = default;
V WHISK_4611 = default;
if (!(Truthy(L_4566))) {
return default;
}
Invoke(Object_keys(Get(I_4565, "pg")), "forEach", Fn((V _arrowThis4619, int _argc4612, V k_4618, V _a4615, V _a4616, V _a4617, V[] _rest4613) => {
Set(GetK(Get(I_4565, "pg"), k_4618), "id", ((V)(JsStrBuf.Begin().S("pg").V(k_4618).V(u_4568).End())));
return default;
}, 1, "", true));
Invoke(df_4570, "insertAdjacentHTML", ((V)("beforeend")), ((V)(JsStrBuf.Begin().S("<mask id=\"lm").V(u_4568).S("\" maskUnits=\"userSpaceOnUse\" x=\"-12\" y=\"-25\" width=\"124\" height=\"128\" style=\"mask-type:alpha\">").V(Invoke(Invoke(Object_keys(Get(I_4565, "pg")), "map", Fn((V _arrowThis4627, int _argc4620, V k_4626, V _a4623, V _a4624, V _a4625, V[] _rest4621) => {
return ((V)(JsStrBuf.Begin().S("<use href=\"#pg").V(k_4626).V(u_4568).S("\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</mask>").S("<linearGradient id=\"la").V(u_4568).S("\" gradientUnits=\"userSpaceOnUse\" x1=\"0\" x2=\"0\"><stop offset=\"0\"/><stop offset=\"1\"/></linearGradient>").S("<radialGradient id=\"lhg").V(u_4568).S("\" r=\"0.42\"><stop offset=\"0\"/><stop offset=\"1\"/></radialGradient>").S("<radialGradient id=\"lc").V(u_4568).S("\"><stop offset=\"0\" stop-opacity=\"1\"/><stop offset=\"0.45\" stop-opacity=\"0.75\"/><stop offset=\"1\" stop-opacity=\"0\"/></radialGradient>").End())));
R_4602 = NewObj(4).Put("x", ((V)((-12D)))).Put("y", ((V)((-25D)))).Put("width", ((V)(124D))).Put("height", ((V)(128D))).V;
gm_4603 = Call(mkL_4571, V.Undef, ((V)("g")), NewObj(2).Put("mask", ((V)(JsStrBuf.Begin().S("url(#lm").V(u_4568).S(")").End()))).Put("data-lt", ((V)(1D))).V);
Set(Get(gm_4603, "style"), "mixBlendMode", ((V)("multiply")));
tint_4604 = Call(mkL_4571, V.Undef, ((V)("rect")), Object_assign(NewObj(1).Put("fill", ((V)("#ffffff"))).V, R_4602), gm_4603);
Call(mkL_4571, V.Undef, ((V)("rect")), Object_assign(NewObj(1).Put("fill", ((V)(JsStrBuf.Begin().S("url(#la").V(u_4568).S(")").End()))).V, R_4602), gm_4603);
cast_4605 = Call(mkL_4571, V.Undef, ((V)("ellipse")), NewObj(2).Put("fill", ((V)(JsStrBuf.Begin().S("url(#lc").V(u_4568).S(")").End()))).Put("data-lt", ((V)(1D))).V);
Invoke(Get(Get(I_4565, "shadow"), "parentNode"), "insertBefore", cast_4605, Get(I_4565, "shadow"));
part_4606 = NewObj(0).V;
Invoke(LPARTS_71, "forEach", Fn((V _arrowThis4641, int _argc4628, V _a4630, V _a4631, V _a4632, V _a4633, V[] _rest4629) => {
V src_4642 = default;
V g_4643 = default;
V tube_4644 = default;
V P_4645 = default;
V mA_4646 = default;
V k_4636 = default;
V size_4638 = default;
V mode_4640 = default;
{ V _t4634 = ListOf(_a4630);
{ V _t4635 = GetIdx(_t4634, 0D);
k_4636 = _t4635; }
{ V _t4637 = GetIdx(_t4634, 1D);
size_4638 = _t4637; }
{ V _t4639 = GetIdx(_t4634, 2D);
mode_4640 = _t4639; }
}
src_4642 = Call(lightSrc_84, V.Undef, I_4565, k_4636);
if ((!(Truthy(src_4642)) || !(Truthy(GetK(Get(I_4565, "pg"), k_4636))))) {
return default;
}
g_4643 = Call(mkL_4571, V.Undef, ((V)("g")), NewObj(2).Put("pointer-events", ((V)("none"))).Put("data-lt", ((V)(1D))).V);
tube_4644 = (SEqS(mode_4640, "tube") ? V.True : V.False);
if (Truthy(tube_4644)) {
Invoke(df_4570, "insertAdjacentHTML", ((V)("beforeend")), ((V)(JsStrBuf.Begin().S("<clipPath id=\"ltc").V(k_4636).V(u_4568).S("\" clipPathUnits=\"userSpaceOnUse\"><path clip-rule=\"evenodd\"/></clipPath>").End())));
} else {
Invoke(df_4570, "insertAdjacentHTML", ((V)("beforeend")), ((V)(JsStrBuf.Begin().S("<radialGradient id=\"lsg").V(k_4636).V(u_4568).S("\" r=\"0.78\"><stop offset=\"0.42\"/><stop offset=\"0.72\"/><stop offset=\"0.9\"/><stop offset=\"1\"/></radialGradient>").End())));
}
P_4645 = NewObj(11).Put("k", k_4636).Put("size", size_4638).Put("src", src_4642).Put("g", g_4643).Put("tube", tube_4644).Put("occ", Arr()).Put("col", Call(rgbOf_78, V.Undef, src_4642)).Put("gs", (Truthy(tube_4644) ? V.Null : Invoke(df_4570, "querySelector", ((V)(JsStrBuf.Begin().S("#lsg").V(k_4636).V(u_4568).End()))))).Put("sh", Call(mkL_4571, V.Undef, ((V)("path")), (Truthy(tube_4644) ? NewObj(1).Put("clip-path", ((V)(JsStrBuf.Begin().S("url(#ltc").V(k_4636).V(u_4568).S(")").End()))).V : NewObj(1).Put("fill", ((V)(JsStrBuf.Begin().S("url(#lsg").V(k_4636).V(u_4568).S(")").End()))).V), g_4643)).Put("hi", (Truthy(tube_4644) ? V.Null : Call(mkL_4571, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)(JsStrBuf.Begin().S("url(#lhg").V(u_4568).S(")").End()))).V, g_4643))).Put("tc", (Truthy(tube_4644) ? Invoke(df_4570, "querySelector", ((V)(JsStrBuf.Begin().S("#ltc").V(k_4636).V(u_4568).S(" path").End()))) : V.Null)).V;
Invoke((GetK(LOCC_72, k_4636) is var _t4661 && Truthy(_t4661) ? _t4661 : Arr()), "forEach", Fn((V _arrowThis4658, int _argc4647, V _a4649, V _a4650, V _a4651, V _a4652, V[] _rest4648) => {
V os_4659 = default;
V id_4660 = default;
V o_4655 = default;
V w_4657 = default;
{ V _t4653 = ListOf(_a4649);
{ V _t4654 = GetIdx(_t4653, 0D);
o_4655 = _t4654; }
{ V _t4656 = GetIdx(_t4653, 1D);
w_4657 = _t4656; }
}
os_4659 = Call(lightSrc_84, V.Undef, I_4565, o_4655);
if (!(Truthy(os_4659))) {
return default;
}
id_4660 = ((V)(JsStrBuf.Begin().S("lo").V(k_4636).V(o_4655).V(u_4568).End()));
Invoke(df_4570, "insertAdjacentHTML", ((V)("beforeend")), ((V)(JsStrBuf.Begin().S("<clipPath id=\"").V(id_4660).S("\" clipPathUnits=\"userSpaceOnUse\"><path/></clipPath>").End())));
Invoke(Get(P_4645, "occ"), "push", NewObj(5).Put("o", o_4655).Put("w", w_4657).Put("src", os_4659).Put("c", Invoke(df_4570, "querySelector", ((V)(JsStrBuf.Begin().S("#").V(id_4660).S(" path").End())))).Put("e", Call(mkL_4571, V.Undef, ((V)("path")), NewObj(1).Put("clip-path", ((V)(JsStrBuf.Begin().S("url(#").V(id_4660).S(")").End()))).V, g_4643)).V);
return default;
}, 1, "", true));
mA_4646 = Invoke(GetK(Get(I_4565, "pg"), k_4636), "getAttribute", ((V)("mask")));
if (Truthy(mA_4646)) {
Invoke(g_4643, "setAttribute", ((V)("mask")), mA_4646);
}
SetK(part_4606, k_4636, P_4645);
Invoke(GetK(Get(I_4565, "pg"), k_4636), "after", g_4643);
return default;
}, 1, "", true));
E0_4607 = (Get(I_4565, "E") is var _t4662 && Truthy(_t4662) ? _t4662 : NewObj(0).V);
tailOL_4608 = V.Null;
if (Truthy(((Get(E0_4607, "tail") is var _t4663 && !Truthy(_t4663) ? _t4663 : (!(Truthy(Get(E0_4607, "tailF"))) ? V.True : V.False)) is var _t4664 && !Truthy(_t4664) ? _t4664 : (!(Truthy(Get(part_4606, "tail"))) ? V.True : V.False)))) {
V g_4665 = default;
V mp_4666 = default;
V tc_4667 = default;
Invoke(df_4570, "insertAdjacentHTML", ((V)("beforeend")), ((V)(JsStrBuf.Begin().S("<mask id=\"ltm").V(u_4568).S("\" maskUnits=\"userSpaceOnUse\" x=\"-60\" y=\"-60\" width=\"220\" height=\"220\"><path fill=\"none\" stroke=\"#fff\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><path fill=\"none\" stroke=\"#000\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/></mask>").End())));
g_4665 = Call(mkL_4571, V.Undef, ((V)("g")), NewObj(2).Put("pointer-events", ((V)("none"))).Put("data-lt", ((V)(1D))).V);
mp_4666 = Invoke(df_4570, "querySelectorAll", ((V)(JsStrBuf.Begin().S("#ltm").V(u_4568).S(" path").End())));
tc_4667 = Arr(((V)(200D)), ((V)(140D)), ((V)(100D)));
try {
tc_4667 = (Call(rgbP_77, V.Undef, Get(Call(G("getComputedStyle"), V.Undef, Get(E0_4607, "tail")), "stroke")) is var _t4668 && Truthy(_t4668) ? _t4668 : tc_4667);
} catch (System.Exception _ex4669) {
V x_4670 = default;
x_4670 = Caught(_ex4669);

}
Set(part_4606, "tail", NewObj(10).Put("k", ((V)("tail"))).Put("size", ((V)(16D))).Put("src", Get(E0_4607, "tail")).Put("g", g_4665).Put("occ", Arr()).Put("st", (true ? V.True : V.False)).Put("col", tc_4667).Put("sh", Call(mkL_4571, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).Put("mask", ((V)(JsStrBuf.Begin().S("url(#ltm").V(u_4568).S(")").End()))).V, g_4665)).Put("mw", GetIdx(mp_4666, 0D)).Put("mb", GetIdx(mp_4666, 1D)).V);
Invoke(Get(Get(I_4565, "pg"), "tail"), "after", g_4665);
}
wg0_4609 = ((Get(E0_4607, "wh") is var _t4671 && !Truthy(_t4671) ? _t4671 : GetIdx(Get(E0_4607, "wh"), 0D)) is var _t4672 && !Truthy(_t4672) ? _t4672 : Get(GetIdx(Get(E0_4607, "wh"), 0D), "parentNode"));
whOL_4610 = V.Null;
WHISK_4611 = (false ? V.True : V.False);
if (Truthy(((WHISK_4611 is var _t4673 && !Truthy(_t4673) ? _t4673 : wg0_4609) is var _t4675 && !Truthy(_t4675) ? _t4675 : (!SEqS((Invoke(wg0_4609, "getAttribute", ((V)("stroke"))) is var _t4674 && Truthy(_t4674) ? _t4674 : ((V)("none"))), "none") ? V.True : V.False)))) {
V g_4676 = default;
g_4676 = Call(mkL_4571, V.Undef, ((V)("g")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).Put("pointer-events", ((V)("none"))).Put("data-lt", ((V)(1D))).V);
Invoke(wg0_4609, "before", g_4676);
whOL_4610 = NewObj(5).Put("g", g_4676).Put("wg", wg0_4609).Put("c0", Invoke(wg0_4609, "getAttribute", ((V)("stroke")))).Put("w0", (((V)(ToNum(Invoke(wg0_4609, "getAttribute", ((V)("stroke-width")))))) is var _t4677 && Truthy(_t4677) ? _t4677 : ((V)(0.9)))).Put("ps", Invoke(Get(E0_4607, "wh"), "map", Fn((V _arrowThis4684, int _argc4678, V _a4680, V _a4681, V _a4682, V _a4683, V[] _rest4679) => {
return Call(mkL_4571, V.Undef, ((V)("path")), NewObj(0).V, g_4676);
}, 0, "", true))).V;
}
Invoke(Get(I_4565, "root"), "appendChild", gm_4603);
Set(I_4565, "lt", NewObj(8).Put("gm", gm_4603).Put("tint", tint_4604).Put("cast", cast_4605).Put("part", part_4606).Put("tailOL", tailOL_4608).Put("whOL", whOL_4610).Put("ga", Invoke(df_4570, "querySelector", ((V)(JsStrBuf.Begin().S("#la").V(u_4568).End())))).Put("ghi", Invoke(df_4570, "querySelector", ((V)(JsStrBuf.Begin().S("#lhg").V(u_4568).End())))).V);
}
T_4572 = Get(I_4565, "lt");
Set(T_4572, "L", (L_4566 is var _t4685 && Truthy(_t4685) ? _t4685 : V.Null));
Invoke(Invoke(Arr(Get(T_4572, "cast")), "concat", Invoke(Object_values(Get(T_4572, "part")), "map", Fn((V _arrowThis4701, int _argc4694, V P_4700, V _a4697, V _a4698, V _a4699, V[] _rest4695) => {
return Get(P_4700, "g");
}, 1, "", true))), "forEach", Fn((V _arrowThis4693, int _argc4686, V e_4692, V _a4689, V _a4690, V _a4691, V[] _rest4687) => {
Set(Get(e_4692, "style"), "display", ((V)((Truthy(L_4566) ? "" : "none"))));
return default;
}, 1, "", true));
Invoke(Get(I_4565, "shadow"), "setAttribute", ((V)("fill")), (Truthy((L_4566 is var _t4702 && !Truthy(_t4702) ? _t4702 : Get(L_4566, "castC"))) ? Get(L_4566, "castC") : ((V)("#6a1b9a"))));
if (!(Truthy(L_4566))) {
Set(Get(Get(T_4572, "gm"), "style"), "display", ((V)("none")));
if (Truthy(Get(T_4572, "tailOL"))) {
Set(Get(Get(T_4572, "tailOL"), "style"), "display", ((V)("none")));
}
if (Truthy(Get(T_4572, "whOL"))) {
Set(Get(Get(Get(T_4572, "whOL"), "g"), "style"), "display", ((V)("none")));
Invoke(Get(Get(T_4572, "whOL"), "wg"), "setAttribute", ((V)("stroke")), Get(Get(T_4572, "whOL"), "c0"));
}
return default;
}
tintOn_4573 = ((!(!(Truthy((Get(L_4566, "tint") is var _t4703 && !Truthy(_t4703) ? _t4703 : (!(Truthy(Invoke(NewRegExp(RX6, "^#f{6}$", "i"), "test", Get(L_4566, "tint")))) ? V.True : V.False))))) || GtN((Get(L_4566, "ao") is var _t4704 && Truthy(_t4704) ? _t4704 : ((V)(0D))), 0D)) ? V.True : V.False);
Set(Get(Get(T_4572, "gm"), "style"), "display", ((V)((Truthy(tintOn_4573) ? "" : "none"))));
st_4574 = Fn((V _arrowThis4713, int _argc4705, V g_4711, V cols_4712, V _a4709, V _a4710, V[] _rest4706) => {
return Invoke(new ArrBuilder().Spread(Get(g_4711, "children")).V, "forEach", Fn((V _arrowThis4722, int _argc4714, V s_4720, V i_4721, V _a4718, V _a4719, V[] _rest4715) => {
Invoke(s_4720, "setAttribute", ((V)("stop-color")), GetIdx(GetK(cols_4712, i_4721), 0D));
Invoke(s_4720, "setAttribute", ((V)("stop-opacity")), GetIdx(GetK(cols_4712, i_4721), 1D));
return default;
}, 2, "", true));
}, 2, "", true);
ac_4575 = ((Get(L_4566, "aoC") is var _t4723 && Truthy(_t4723) ? _t4723 : Get(L_4566, "shC")) is var _t4724 && Truthy(_t4724) ? _t4724 : ((V)("#5a2a48")));
rc_4576 = (Get(L_4566, "rimC") is var _t4725 && Truthy(_t4725) ? _t4725 : ((V)("#fff3d2")));
sh_4577 = (Get(L_4566, "sh").IsNullish ? ((V)(0.4)) : Get(L_4566, "sh"));
mix_4578 = (Get(L_4566, "shMix").IsNullish ? ((V)(1D)) : Get(L_4566, "shMix"));
Call(st_4574, V.Undef, Get(T_4572, "ga"), Arr(Arr(ac_4575, ((V)(0D))), Arr(ac_4575, (Get(L_4566, "ao") is var _t4726 && Truthy(_t4726) ? _t4726 : ((V)(0D))))));
Invoke(Get(T_4572, "tint"), "setAttribute", ((V)("fill")), (Get(L_4566, "tint") is var _t4727 && Truthy(_t4727) ? _t4727 : ((V)("#ffffff"))));
Call(st_4574, V.Undef, Get(T_4572, "ghi"), Arr(Arr(rc_4576, (Get(L_4566, "rim") is var _t4728 && Truthy(_t4728) ? _t4728 : ((V)(0D)))), Arr(rc_4576, ((V)(0D)))));
Invoke(new ArrBuilder().Spread(Get(Invoke(Get(Get(T_4572, "cast"), "ownerSVGElement"), "querySelector", ((V)(JsStrBuf.Begin().S("#lc").V(u_4568).End()))), "children")).V, "forEach", Fn((V _arrowThis4736, int _argc4729, V s_4735, V _a4732, V _a4733, V _a4734, V[] _rest4730) => {
return Invoke(s_4735, "setAttribute", ((V)("stop-color")), (Get(L_4566, "castC") is var _t4737 && Truthy(_t4737) ? _t4737 : ((V)("#2a1a30"))));
}, 1, "", true));
d_4579 = (Get(L_4566, "dir") is var _t4738 && Truthy(_t4738) ? _t4738 : Arr(((V)(0.7)), ((V)(0.6))));
n_4580 = (((V)(Hypot(ToNum(GetIdx(d_4579, 0D)), ToNum(GetIdx(d_4579, 1D))))) is var _t4739 && Truthy(_t4739) ? _t4739 : ((V)(1D)));
Set(T_4572, "dx", ((V)((ToNum(GetIdx(d_4579, 0D)) / ToNum(n_4580)))));
Set(T_4572, "dy", ((V)((ToNum(GetIdx(d_4579, 1D)) / ToNum(n_4580)))));
Invoke(Get(T_4572, "ghi"), "setAttribute", ((V)("cx")), Call(r2_14, V.Undef, ((V)((0.5 - (0.24 * ToNum(Get(T_4572, "dx"))))))));
Invoke(Get(T_4572, "ghi"), "setAttribute", ((V)("cy")), Call(r2_14, V.Undef, ((V)((0.42 - (0.24 * ToNum(Get(T_4572, "dy"))))))));
Invoke(Object_values(Get(T_4572, "part")), "forEach", Fn((V _arrowThis4747, int _argc4740, V P_4746, V _a4743, V _a4744, V _a4745, V[] _rest4741) => {
V sc_4748 = default;
Set(P_4746, "sc", (Truthy(Get(L_4566, "shC")) ? Call(mixHex_83, V.Undef, Call(shadeOf_82, V.Undef, Get(P_4746, "col")), Get(L_4566, "shC"), mix_4578) : Call(shadeOf_82, V.Undef, Get(P_4746, "col"))));
sc_4748 = Get(P_4746, "sc");
if (Truthy(Get(P_4746, "gs"))) {
Call(st_4574, V.Undef, Get(P_4746, "gs"), Arr(Arr(sc_4748, ((V)(0D))), Arr(sc_4748, ((V)((ToNum(sh_4577) * 0.42)))), Arr(sc_4748, ((V)((ToNum(sh_4577) * 0.85)))), Arr(sc_4748, sh_4577)));
Invoke(Get(P_4746, "gs"), "setAttribute", ((V)("cx")), Call(r2_14, V.Undef, ((V)((0.5 - (0.2 * ToNum(Get(T_4572, "dx"))))))));
Invoke(Get(P_4746, "gs"), "setAttribute", ((V)("cy")), Call(r2_14, V.Undef, ((V)((0.5 - (0.2 * ToNum(Get(T_4572, "dy"))))))));
}
if (Truthy(Get(P_4746, "tube"))) {
Invoke(Get(P_4746, "sh"), "setAttribute", ((V)("fill")), sc_4748);
Invoke(Get(P_4746, "sh"), "setAttribute", ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ToNum(sh_4577) * 0.8)))));
}
if (Truthy(Get(P_4746, "st"))) {
Invoke(Get(P_4746, "sh"), "setAttribute", ((V)("stroke")), sc_4748);
Invoke(Get(P_4746, "sh"), "setAttribute", ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ToNum(sh_4577) * 0.8)))));
}
return default;
}, 1, "", true));
oc_4581 = (Get(L_4566, "occ").IsNullish ? sh_4577 : Get(L_4566, "occ"));
Invoke(Object_values(Get(T_4572, "part")), "forEach", Fn((V _arrowThis4756, int _argc4749, V P_4755, V _a4752, V _a4753, V _a4754, V[] _rest4750) => {
return Invoke(Get(P_4755, "occ"), "forEach", Fn((V _arrowThis4764, int _argc4757, V O_4763, V _a4760, V _a4761, V _a4762, V[] _rest4758) => {
Invoke(Get(O_4763, "e"), "setAttribute", ((V)("fill")), Get(P_4755, "sc"));
Invoke(Get(O_4763, "e"), "setAttribute", ((V)("opacity")), Call(r2_14, V.Undef, ((V)(Min(0.9, ((ToNum(oc_4581) * ToNum(Get(O_4763, "w"))) * 1.3))))));
return default;
}, 1, "", true));
}, 1, "", true));
Set(T_4572, "lw", (Get(L_4566, "line") is var _t4765 && Truthy(_t4765) ? _t4765 : ((V)(0D))));
Set(T_4572, "dirty", ((V)(1D)));
if (Truthy(Get(T_4572, "whOL"))) {
V W_4766 = default;
W_4766 = Get(T_4572, "whOL");
Set(Get(Get(W_4766, "g"), "style"), "display", ((V)((Truthy(Get(T_4572, "lw")) ? "" : "none"))));
Invoke(Get(W_4766, "wg"), "setAttribute", ((V)("stroke")), (Truthy(Get(T_4572, "lw")) ? Call(mixHex_83, V.Undef, Get(W_4766, "c0"), ((V)("#ffffff")), ((V)(0.5))) : Get(W_4766, "c0")));
Invoke(Get(W_4766, "g"), "setAttribute", ((V)("stroke")), (Get(L_4566, "lineC") is var _t4769 && Truthy(_t4769) ? _t4769 : Call(lineOf_81, V.Undef, Call(rgbOf_78, V.Undef, ((Get(I_4565, "E") is var _t4767 && !Truthy(_t4767) ? _t4767 : Get(Get(I_4565, "E"), "skull")) is var _t4768 && Truthy(_t4768) ? _t4768 : Get(I_4565, "root"))))));
Invoke(Get(W_4766, "g"), "setAttribute", ((V)("stroke-width")), Call(r2_14, V.Undef, Add(Get(W_4766, "w0"), ((V)((2D * Min(0.32, (ToNum(Get(T_4572, "lw")) * 0.3))))))));
Invoke(Get(W_4766, "ps"), "forEach", Fn((V _arrowThis4777, int _argc4770, V q_4776, V _a4773, V _a4774, V _a4775, V[] _rest4771) => {
Set(q_4776, "_d", V.Null);
Set(q_4776, "_o", V.Null);
return default;
}, 1, "", true));
}
return default;
}, 2, "setLight", false);
litTick_94 = Fn((V _self4778, int _argc4779, V I_4785, V P_4786, V G_4787, V sq_4788, V[] _rest4780) => {
V T_4790 = default;
V L_4791 = default;
V S_4792 = default;
V cx_4793 = default;
V dx_4794 = default;
V dy_4795 = default;
double len_4796 = 0;
double off_4797 = 0;
V gl_4789 = default;
if (_self4778.IsNullish) _self4778 = GlobalV;
gl_4789 = (_argc4779 > 4 ? _rest4780[0] : V.Undef);
T_4790 = Get(I_4785, "lt");
L_4791 = (T_4790 is var _t4798 && !Truthy(_t4798) ? _t4798 : Get(T_4790, "L"));
if (!(Truthy(L_4791))) {
return default;
}
S_4792 = Fn((V _arrowThis4808, int _argc4799, V e_4805, V a_4806, V v_4807, V _a4804, V[] _rest4800) => {
return Invoke(e_4805, "setAttribute", a_4806, Call(r2_14, V.Undef, v_4807));
}, 3, "", true);
cx_4793 = Add(Add(((V)(50D)), Get(P_4786, "x")), ((V)((ToNum(Get(P_4786, "lean")) * 0.1))));
dx_4794 = Get(T_4790, "dx");
dy_4795 = Get(T_4790, "dy");
if (!SEqS(Get(Get(Get(T_4790, "gm"), "style"), "display"), "none")) {
Call(S_4792, V.Undef, Get(T_4790, "ga"), ((V)("y1")), ((V)(((ToNum(G_4787) - 19D) - (ToNum(gl_4789) * 0.6)))));
Call(S_4792, V.Undef, Get(T_4790, "ga"), ((V)("y2")), ((V)((ToNum(Add(G_4787, ((V)(1D)))) - (ToNum(gl_4789) * 0.6)))));
}
Invoke(Object_values(Get(T_4790, "part")), "forEach", Fn((V _arrowThis4816, int _argc4809, V Q_4815, V _a4812, V _a4813, V _a4814, V[] _rest4810) => {
V dd_4817 = default;
V vis_4818 = default;
V O_4819 = default;
V po_4820 = default;
V so_4821 = default;
double op_4822 = 0;
V fr_4823 = default;
dd_4817 = (Invoke(Get(Q_4815, "src"), "getAttribute", ((V)("d"))) is var _t4824 && Truthy(_t4824) ? _t4824 : ((V)("")));
vis_4818 = ((dd_4817 is var _t4825 && !Truthy(_t4825) ? _t4825 : (!SEqS(Get(Get(Get(Q_4815, "src"), "style"), "display"), "none") ? V.True : V.False)) is var _t4826 && !Truthy(_t4826) ? _t4826 : (!SEqS(Invoke(Get(Q_4815, "src"), "getAttribute", ((V)("opacity"))), "0") ? V.True : V.False));
O_4819 = (Truthy((Get(Q_4815, "st") is var _t4827 && !Truthy(_t4827) ? _t4827 : Get(T_4790, "lw"))) ? Get(T_4790, "tailOL") : V.Null);
if (!(Truthy(vis_4818))) {
if (!SEqS(Get(Get(Get(Q_4815, "g"), "style"), "display"), "none")) {
Set(Get(Get(Q_4815, "g"), "style"), "display", ((V)("none")));
}
if (Truthy(O_4819)) {
Set(Get(O_4819, "style"), "display", ((V)("none")));
}
return default;
}
if (SEqS(Get(Get(Get(Q_4815, "g"), "style"), "display"), "none")) {
Set(Get(Get(Q_4815, "g"), "style"), "display", ((V)("")));
}
if (!SEq(Get(Get(Q_4815, "g"), "previousSibling"), GetK(Get(I_4785, "pg"), Get(Q_4815, "k")))) {
Invoke(GetK(Get(I_4785, "pg"), Get(Q_4815, "k")), "after", Get(Q_4815, "g"));
}
po_4820 = Invoke(GetK(Get(I_4785, "pg"), Get(Q_4815, "k")), "getAttribute", ((V)("opacity")));
so_4821 = Invoke(Get(Q_4815, "src"), "getAttribute", ((V)("opacity")));
op_4822 = ((po_4820.IsNullish ? 1D : ToNum(po_4820)) * (so_4821.IsNullish ? 1D : ToNum(so_4821)));
Invoke(Get(Q_4815, "g"), "setAttribute", ((V)("opacity")), Call(r2_14, V.Undef, ((V)(op_4822))));
if (Truthy(Get(Q_4815, "st"))) {
V tw_4828 = default;
V key_4829 = default;
V sw_4830 = default;
double w_4831 = 0;
if (Truthy(O_4819)) {
if (SEqS(Get(Get(O_4819, "style"), "display"), "none")) {
Set(Get(O_4819, "style"), "display", ((V)("")));
}
if (!SEq(Get(O_4819, "nextSibling"), Get(Get(I_4785, "pg"), "tail"))) {
Invoke(Get(Get(I_4785, "pg"), "tail"), "before", O_4819);
}
Invoke(O_4819, "setAttribute", ((V)("opacity")), Call(r2_14, V.Undef, ((V)(op_4822))));
}
tw_4828 = (((V)(ToNum(Invoke(Get(Q_4815, "src"), "getAttribute", ((V)("stroke-width")))))) is var _t4832 && Truthy(_t4832) ? _t4832 : ((V)(7D)));
key_4829 = Add(Add(dd_4817, tw_4828), Get(T_4790, "lw"));
if ((SEq(Get(Q_4815, "d"), key_4829) && !(Truthy(Get(T_4790, "dirty"))))) {
return default;
}
Set(Q_4815, "d", key_4829);
sw_4830 = Call(r2_14, V.Undef, tw_4828);
w_4831 = (ToNum(tw_4828) * 0.36);
Invoke(Arr(Get(Q_4815, "sh"), Get(Q_4815, "mw"), Get(Q_4815, "mb")), "forEach", Fn((V _arrowThis4840, int _argc4833, V e_4839, V _a4836, V _a4837, V _a4838, V[] _rest4834) => {
Invoke(e_4839, "setAttribute", ((V)("d")), dd_4817);
Invoke(e_4839, "setAttribute", ((V)("stroke-width")), sw_4830);
return default;
}, 1, "", true));
Invoke(Get(Q_4815, "mb"), "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_14, V.Undef, ((V)(((-ToNum(dx_4794)) * w_4831))))).S(" ").V(Call(r2_14, V.Undef, ((V)(((-ToNum(dy_4795)) * w_4831))))).S(")").End())));
if (Truthy(O_4819)) {
Invoke(O_4819, "setAttribute", ((V)("d")), dd_4817);
Invoke(O_4819, "setAttribute", ((V)("stroke-width")), Call(r2_14, V.Undef, Add(tw_4828, ((V)((2D * ToNum(Get(T_4790, "lw"))))))));
}
return default;
}
if (Truthy(((!SEq(Get(Q_4815, "d"), dd_4817) ? V.True : V.False) is var _t4841 && Truthy(_t4841) ? _t4841 : Get(T_4790, "dirty")))) {
Set(Q_4815, "d", dd_4817);
Invoke(Get(Q_4815, "sh"), "setAttribute", ((V)("d")), dd_4817);
if (Truthy(Get(Q_4815, "hi"))) {
Invoke(Get(Q_4815, "hi"), "setAttribute", ((V)("d")), dd_4817);
}
if (Truthy(Get(Q_4815, "tc"))) {
double w_4842 = 0;
w_4842 = (ToNum(Get(Q_4815, "size")) * 0.22);
Invoke(Get(Q_4815, "tc"), "setAttribute", ((V)("d")), Add(LRECT_73, dd_4817));
Invoke(Get(Q_4815, "tc"), "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_14, V.Undef, ((V)(((-ToNum(dx_4794)) * w_4842))))).S(" ").V(Call(r2_14, V.Undef, ((V)(((-ToNum(dy_4795)) * w_4842))))).S(")").End())));
}
}
fr_4823 = ((SEqS(GetIdx(Get(Q_4815, "k"), 0D), "f") && !(!(NumTruthy(((double)(ToInt32(ToNum(Invoke(Get(Get(I_4785, "pg"), "body"), "compareDocumentPosition", GetK(Get(I_4785, "pg"), Get(Q_4815, "k"))))) & ToInt32(4D))))))) ? V.True : V.False);
Invoke(Get(Q_4815, "occ"), "forEach", Fn((V _arrowThis4850, int _argc4843, V O_4849, V _a4846, V _a4847, V _a4848, V[] _rest4844) => {
V od_4851 = default;
double k_4852 = 0;
if (SEqS(Get(O_4849, "o"), "body")) {
V dp_4853 = default;
dp_4853 = ((V)((Truthy(fr_4823) ? "none" : "")));
if (!SEq(Get(Get(Get(O_4849, "e"), "style"), "display"), dp_4853)) {
Set(Get(Get(O_4849, "e"), "style"), "display", dp_4853);
}
}
od_4851 = (Invoke(Get(O_4849, "src"), "getAttribute", ((V)("d"))) is var _t4854 && Truthy(_t4854) ? _t4854 : ((V)("")));
if (((SEq(Get(O_4849, "d"), od_4851) && SEq(Get(O_4849, "dd"), dd_4817)) && !(Truthy(Get(T_4790, "dirty"))))) {
return default;
}
Set(O_4849, "d", od_4851);
Set(O_4849, "dd", dd_4817);
Invoke(Get(O_4849, "e"), "setAttribute", ((V)("d")), dd_4817);
Invoke(Get(O_4849, "c"), "setAttribute", ((V)("d")), od_4851);
k_4852 = (SEqS(Get(O_4849, "o"), "body") ? 1.6 : 1D);
Invoke(Get(O_4849, "c"), "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_14, V.Undef, ((V)(((ToNum(dx_4794) * 2.2) * k_4852))))).S(" ").V(Call(r2_14, V.Undef, ((V)(((2.6 + (Max(0D, ToNum(dy_4795)) * 1.8)) * k_4852))))).S(")").End())));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
Set(T_4790, "dirty", ((V)(0D)));
if (Truthy((Get(T_4790, "whOL") is var _t4855 && !Truthy(_t4855) ? _t4855 : Get(T_4790, "lw")))) {
Invoke(Get(Get(I_4785, "E"), "wh"), "forEach", Fn((V _arrowThis4864, int _argc4856, V w_4862, V i_4863, V _a4860, V _a4861, V[] _rest4857) => {
V q_4865 = default;
V d_4866 = default;
V o_4867 = default;
q_4865 = GetK(Get(Get(T_4790, "whOL"), "ps"), i_4863);
if (!(Truthy(q_4865))) {
return default;
}
d_4866 = (Invoke(w_4862, "getAttribute", ((V)("d"))) is var _t4868 && Truthy(_t4868) ? _t4868 : ((V)("")));
o_4867 = Invoke(w_4862, "getAttribute", ((V)("opacity")));
if (!SEq(Get(q_4865, "_d"), d_4866)) {
Set(q_4865, "_d", d_4866);
Invoke(q_4865, "setAttribute", ((V)("d")), d_4866);
}
if (!SEq(Get(q_4865, "_o"), o_4867)) {
Set(q_4865, "_o", o_4867);
if (!o_4867.IsNullish) {
Invoke(q_4865, "setAttribute", ((V)("opacity")), Call(r2_14, V.Undef, ((V)(Min(1D, (ToNum(o_4867) / 0.8))))));
}
}
return default;
}, 2, "", true));
}
if (Truthy(Get(I_4785, "faceW"))) {
Invoke((Get(Get(I_4785, "E"), "eyes") is var _t4883 && Truthy(_t4883) ? _t4883 : Arr()), "forEach", Fn((V _arrowThis4876, int _argc4869, V o_4875, V _a4872, V _a4873, V _a4874, V[] _rest4870) => {
V ed_4877 = default;
V sw_4878 = default;
V w_4879 = default;
V op_4880 = default;
if (!(Truthy(Get(o_4875, "ring")))) {
return default;
}
ed_4877 = (Invoke(Get(o_4875, "e"), "getAttribute", ((V)("d"))) is var _t4881 && Truthy(_t4881) ? _t4881 : ((V)("")));
sw_4878 = (((V)(ToNum(Invoke(Get(o_4875, "e"), "getAttribute", ((V)("stroke-width")))))) is var _t4882 && Truthy(_t4882) ? _t4882 : ((V)(0D)));
w_4879 = Call(r2_14, V.Undef, Add(sw_4878, ((V)((ToNum(Get(I_4785, "faceW")) * 1.7)))));
op_4880 = Invoke(Get(o_4875, "e"), "getAttribute", ((V)("opacity")));
if (!SEq(Get(o_4875, "ringD"), ed_4877)) {
Set(o_4875, "ringD", ed_4877);
Invoke(Get(o_4875, "ring"), "setAttribute", ((V)("d")), ed_4877);
}
if (!SEq(Get(o_4875, "ringW"), w_4879)) {
Set(o_4875, "ringW", w_4879);
Invoke(Get(o_4875, "ring"), "setAttribute", ((V)("stroke-width")), w_4879);
}
if (!op_4880.IsNullish) {
Invoke(Get(o_4875, "ring"), "setAttribute", ((V)("opacity")), op_4880);
}
return default;
}, 1, "", true));
}
len_4796 = (ToNum((Get(L_4791, "castLen") is var _t4884 && Truthy(_t4884) ? _t4884 : ((V)(16D)))) * (1D - Min(1D, (ToNum(gl_4789) / 60D))));
off_4797 = ((ToNum(dx_4794) * len_4796) * 0.55);
Call(S_4792, V.Undef, Get(T_4790, "cast"), ((V)("cx")), Add(cx_4793, ((V)(off_4797))));
Call(S_4792, V.Undef, Get(T_4790, "cast"), ((V)("cy")), Add(Add(G_4787, ((V)(0.8))), ((V)((System.Math.Abs(ToNum(dy_4795)) * 0.6)))));
Call(S_4792, V.Undef, Get(T_4790, "cast"), ((V)("rx")), ((V)(((27D * (1D + (ToNum(sq_4788) * 0.45))) + (System.Math.Abs(off_4797) * 0.8)))));
Call(S_4792, V.Undef, Get(T_4790, "cast"), ((V)("ry")), ((V)((6.2 * (1D - (ToNum(gl_4789) / 90D))))));
Invoke(Get(T_4790, "cast"), "setAttribute", ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ToNum((Get(L_4791, "cast") is var _t4885 && Truthy(_t4885) ? _t4885 : ((V)(0D)))) * Max(0D, (1D - (ToNum(gl_4789) / 45D))))))));
return default;
}, 5, "litTick", false);
mount_95 = Fn((V _self4886, int _argc4887, V host_4893, V key_4894, V opts_4895, V _a4892, V[] _rest4888) => {
V ak0_4896 = default;
V D_4897 = default;
V u_4898 = default;
V now_4899 = default;
V I_4900 = default;
V wrap_4901 = default;
V svg_4902 = default;
V loc_4903 = default;
V up_4904 = default;
if (_self4886.IsNullish) _self4886 = GlobalV;
ak0_4896 = key_4894;
key_4894 = ((Get(G("window"), "SQ_ALIAS") is var _t4905 && !Truthy(_t4905) ? _t4905 : GetK(Get(G("window"), "SQ_ALIAS"), key_4894)) is var _t4906 && Truthy(_t4906) ? _t4906 : key_4894);
opts_4895 = (opts_4895 is var _t4907 && Truthy(_t4907) ? _t4907 : NewObj(0).V);
D_4897 = (GetK(DEFS_34, key_4894) is var _t4908 && Truthy(_t4908) ? _t4908 : Get(DEFS_34, "mittens"));
u_4898 = ((V)(JsStrBuf.Begin().S("rv").N(++UID_68).End()));
now_4899 = Invoke(G("performance"), "now");
I_4900 = NewObj(33).Put("D", D_4897).Put("lookM", (!Get(opts_4895, "look").IsNullish ? ((V)(Max(0D, Min(4D, ((double)(ToInt32(ToNum(Get(opts_4895, "look"))) | ToInt32(0D))))))) : V.Null)).Put("onState", Get(opts_4895, "onState")).Put("cur", NewObj(2).Put("name", ((V)("idle"))).Put("t0", now_4899).V).Put("prev", V.Null).Put("shots", Arr()).Put("press", (false ? V.True : V.False)).Put("spinOff", ((V)(0D))).Put("ptr", V.Null).Put("gl", Arr(((V)(0D)), ((V)(0D)))).Put("glAt", Add(now_4899, ((V)(1200D)))).Put("blinkT", ((V)((-1000000000D)))).Put("blinkAt", Add(now_4899, ((V)(1500D)))).Put("dbl", (false ? V.True : V.False)).Put("hs", ((V)(0D))).Put("lastSpin", V.Null).Put("queue", Arr()).Put("ctr", NewObj(0).V).Put("ctT", NewObj(0).V).Put("emL", NewObj(0).V).Put("parts", Arr()).Put("fidgets", (!SEq(Get(opts_4895, "fidgets"), (false ? V.True : V.False)) ? V.True : V.False)).Put("ak", ak0_4896).Put("flw", New(Fol_20, ((V)(1D)), ((V)(8D)))).Put("fex", New(Fol_20, ((V)(0D)), ((V)(22D)))).Put("fey", New(Fol_20, ((V)(0D)), ((V)(22D)))).Put("fhx", New(Fol_20, ((V)(0D)), ((V)(6.5)))).Put("fhy", New(Fol_20, ((V)(0D)), ((V)(6.5)))).Put("fp", New(Fol_20, ((V)(0D)), ((V)(14D)))).Put("fs", New(Fol_20, ((V)(0D)), ((V)(18D)), ((V)(0.55)))).Put("fx", New(Fol_20, ((V)(0D)), ((V)(9D)), ((V)(0.6)))).Put("fl", New(Fol_20, ((V)(0D)), ((V)(9D)), ((V)(0.6)))).Put("fsp", New(Fol_20, ((V)(0D)), ((V)(7D)), ((V)(0.7)))).V;
wrap_4901 = Invoke(G("document"), "createElement", ((V)("div")));
Set(Get(wrap_4901, "style"), "cssText", ((V)("position:relative;width:100%;height:100%;touch-action:none;cursor:pointer;user-select:none;-webkit-user-select:none;will-change:opacity;")));
Set(host_4893, "innerHTML", ((V)("")));
Invoke(host_4893, "appendChild", wrap_4901);
svg_4902 = Call(mk_32, V.Undef, ((V)("svg")), NewObj(3).Put("viewBox", ((V)("0 0 100 100"))).Put("width", ((V)("100%"))).Put("height", ((V)("100%"))).V);
Set(Get(svg_4902, "style"), "cssText", ((V)("position:absolute;inset:0;overflow:visible;pointer-events:none;")));
Invoke(wrap_4901, "appendChild", svg_4902);
if (Truthy(((!(Truthy(GetK(DEFS_34, key_4894))) ? V.True : V.False) is var _t4909 && !Truthy(_t4909) ? _t4909 : Get(G("window"), "RiveGeneric")))) {
Set(I_4900, "generic", (true ? V.True : V.False));
Set(I_4900, "key", key_4894);
Set(I_4900, "u", u_4898);
Invoke(Get(G("window"), "RiveGeneric"), "build", I_4900, svg_4902, key_4894, NewObj(17).Put("mk", mk_32).Put("ellS", ellS_22).Put("toD", toD_25).Put("parsePath", parsePath_21).Put("ellAx", ellAx_30).Put("smoothD", smoothD_26).Put("SM", SM_16).Put("clamp", clamp_13).Put("lerp", lerp_15).Put("r2", r2_14).Put("D2R", ((V)(D2R_11))).Put("TAU", ((V)(TAU_12))).Put("Fol", Fol_20).Put("earSec", earSec_31).Put("flat", flat_27).Put("hull", hull_28).Put("closedD", closedD_29).V);
} else {
V g_4910 = default;
V FUR_4911 = default;
V CF_4912 = default;
V pg_4913 = default;
V E_4914 = default;
V face_4915 = default;
V wg_4916 = default;
V t0_4917 = default;
V t1_4918 = default;
V t2_4919 = default;
V t3_4920 = default;
V cub_4921 = default;
Set(I_4900, "key", key_4894);
g_4910 = Get(Get(D_4897, "c"), "g");
Set(Call(mk_32, V.Undef, ((V)("defs")), NewObj(0).V, svg_4902), "innerHTML", ((V)(JsStrBuf.Begin().S("<radialGradient id=\"g").V(u_4898).S("\" cx=\"38%\" cy=\"30%\" r=\"75%\"><stop offset=\"0\" stop-color=\"").V(GetIdx(g_4910, 0D)).S("\"/><stop offset=\"0.6\" stop-color=\"").V(GetIdx(g_4910, 1D)).S("\"/><stop offset=\"1\" stop-color=\"").V(GetIdx(g_4910, 2D)).S("\"/></radialGradient>").S((Truthy(Get(Get(D_4897, "c"), "ge")) ? JsStrBuf.Begin().S("<radialGradient id=\"ge").V(u_4898).S("\" cx=\"38%\" cy=\"30%\" r=\"75%\"><stop offset=\"0\" stop-color=\"").V(GetIdx(Get(Get(D_4897, "c"), "ge"), 0D)).S("\"/><stop offset=\"0.6\" stop-color=\"").V(GetIdx(Get(Get(D_4897, "c"), "ge"), 1D)).S("\"/><stop offset=\"1\" stop-color=\"").V(GetIdx(Get(Get(D_4897, "c"), "ge"), 2D)).S("\"/></radialGradient>").End() : "")).S("<radialGradient id=\"ey").V(u_4898).S("\" cx=\"35%\" cy=\"30%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#6b5470\"/><stop offset=\"1\" stop-color=\"#2a1a30\"/></radialGradient>").S("<filter id=\"ft").V(u_4898).S("\" x=\"-15%\" y=\"-15%\" width=\"130%\" height=\"130%\">").V(Call(fabricFx_9, V.Undef)).S("<feComposite in2=\"SourceGraphic\" operator=\"in\"/><feBlend in=\"SourceGraphic\" mode=\"multiply\"/></filter>").S("<clipPath id=\"fc").V(u_4898).S("\" clipPathUnits=\"userSpaceOnUse\"><path/></clipPath>").V(Invoke(Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _arrowThis4929, int _argc4922, V i_4928, V _a4925, V _a4926, V _a4927, V[] _rest4923) => {
return ((V)(JsStrBuf.Begin().S("<clipPath id=\"fk").V(i_4928).V(u_4898).S("\" clipPathUnits=\"userSpaceOnUse\"><path/></clipPath><clipPath id=\"ek").V(i_4928).V(u_4898).S("\" clipPathUnits=\"userSpaceOnUse\"><path/></clipPath>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<clipPath id=\"ec0").V(u_4898).S("\" clipPathUnits=\"userSpaceOnUse\"><path/></clipPath><clipPath id=\"ec1").V(u_4898).S("\" clipPathUnits=\"userSpaceOnUse\"><path/></clipPath>").End())));
if (Truthy(((SEqS(key_4894, "mittens") ? V.True : V.False) is var _t4930 && !Truthy(_t4930) ? _t4930 : Get(D_4897, "arms")))) {
Set(I_4900, "hkx", ((V)((System.Math.Abs((50D - ToNum(GetIdx(Get(GetIdx(Get(D_4897, "arms"), 0D), "e"), 0D)))) / 18D))));
}
if (Truthy((((((!SEqS(key_4894, "mittens") && !(Truthy(Get(D_4897, "mittensFrame")))) ? V.True : V.False) is var _t4931 && !Truthy(_t4931) ? _t4931 : Get(D_4897, "mouth")) is var _t4932 && !Truthy(_t4932) ? _t4932 : Get(D_4897, "eyes")) is var _t4933 && !Truthy(_t4933) ? _t4933 : Get(D_4897, "arms")))) {
double pawY_4934 = 0;
V pawX_4935 = default;
V MY_4936 = default;
V CY_4937 = default;
V pl_4938 = default;
double kx_4939 = 0;
double mxk_4940 = 0;
pawY_4934 = (ToNum(Add(GetIdx(Get(GetIdx(Get(D_4897, "arms"), 0D), "e"), 1D), GetIdx(Get(GetIdx(Get(D_4897, "arms"), 1D), "e"), 1D))) / 2D);
pawX_4935 = GetIdx(Get(GetIdx(Get(D_4897, "arms"), 0D), "e"), 0D);
MY_4936 = Arr(((V)(17D)), ((V)(47D)), ((V)(58D)), ((V)(76D)), ((V)(95.5)));
CY_4937 = Invoke(Arr(Get(D_4897, "top"), GetIdx(GetIdx(Get(D_4897, "eyes"), 0D), 1D), GetIdx(Get(D_4897, "mouth"), 1D), ((V)(pawY_4934)), Get(D_4897, "G")), "map", Fn((V _arrowThis4950, int _argc4941, V v_4947, V i_4948, V a2_4949, V _a4946, V[] _rest4942) => {
return (Truthy((i_4948 is var _t4951 && !Truthy(_t4951) ? _t4951 : (Le(v_4947, GetIdx(a2_4949, (ToNum(i_4948) - 1D))) ? V.True : V.False))) ? Add(GetIdx(a2_4949, (ToNum(i_4948) - 1D)), ((V)(1D))) : v_4947);
}, 3, "", true));
pl_4938 = Fn((V _arrowThis4961, int _argc4952, V A_4958, V B_4959, V v_4960, V _a4957, V[] _rest4953) => {
{
double i_4962 = 0;
i_4962 = 1D;
while (true) {
if (!(Lt(((V)(i_4962)), Get(A_4958, "length")))) break;
if ((Le(v_4960, GetIdx(A_4958, i_4962)) || (i_4962 == (ToNum(Get(A_4958, "length")) - 1D)))) {
return Add(GetIdx(B_4959, (i_4962 - 1D)), ((V)((((ToNum(v_4960) - ToNum(GetIdx(A_4958, (i_4962 - 1D)))) * (ToNum(GetIdx(B_4959, i_4962)) - ToNum(GetIdx(B_4959, (i_4962 - 1D))))) / (ToNum(GetIdx(A_4958, i_4962)) - ToNum(GetIdx(A_4958, (i_4962 - 1D))))))));
}
i_4962++;
}
}
return default;
}, 3, "", true);
kx_4939 = Max(0.5, (System.Math.Abs((50D - ToNum(pawX_4935))) / 18D));
mxk_4940 = ((System.Math.Abs((50D - ToNum(GetIdx(Get(D_4897, "mouth"), 0D)))) < 1D) ? 1D : 1D);
Set(I_4900, "mapHand", Fn((V _arrowThis4972, int _argc4964, V inX_4970, V hy_4971, V _a4968, V _a4969, V[] _rest4965) => {
return Arr(((V)((ToNum(inX_4970) * kx_4939))), ((V)((ToNum(Call(pl_4938, V.Undef, MY_4936, CY_4937, Add(((V)(76D)), hy_4971))) - pawY_4934))));
}, 2, "", true));
Set(I_4900, "foodK", ((V)(Max(0.05, Min(1.5, ((pawY_4934 - ToNum(GetIdx(Get(D_4897, "mouth"), 1D))) / 18D))))));
Set(I_4900, "toM", Fn((V _arrowThis4981, int _argc4973, V x_4979, V y_4980, V _a4977, V _a4978, V[] _rest4974) => {
return Arr(((V)((50D + (((ToNum(x_4979) - ToNum(GetIdx(Get(D_4897, "head"), 0D))) / ToNum(GetIdx(Get(D_4897, "head"), 2D))) * 29D)))), Call(pl_4938, V.Undef, CY_4937, MY_4936, y_4980));
}, 2, "", true));
Set(I_4900, "fromM", Fn((V _arrowThis4990, int _argc4982, V x_4988, V y_4989, V _a4986, V _a4987, V[] _rest4983) => {
return Arr(Add(GetIdx(Get(D_4897, "head"), 0D), ((V)((((ToNum(x_4988) - 50D) / 29D) * ToNum(GetIdx(Get(D_4897, "head"), 2D)))))), Call(pl_4938, V.Undef, MY_4936, CY_4937, y_4989));
}, 2, "", true));
}
FUR_4911 = ((V)(JsStrBuf.Begin().S("url(#g").V(u_4898).S(")").End()));
CF_4912 = Fn((V _arrowThis4998, int _argc4991, V f_4997, V _a4994, V _a4995, V _a4996, V[] _rest4992) => {
return (Truthy(f_4997) ? Invoke(((V)(ToStrS(f_4997))), "replace", NewRegExp(RX7, "url\\(#([^)]+)\\)", ""), ((V)(JsStrBuf.Begin().S("url(#$1").V(u_4898).S(")").End()))) : FUR_4911);
}, 1, "", true);
Invoke(Invoke(svg_4902, "querySelector", ((V)("defs"))), "insertAdjacentHTML", ((V)("beforeend")), ((V)(JsStrBuf.Begin().S("<radialGradient id=\"phz").V(u_4898).S("\"><stop offset=\"0\" stop-color=\"#cbcac7\" stop-opacity=\"0.85\"/><stop offset=\"0.5\" stop-color=\"#d3d2cf\" stop-opacity=\"0.45\"/><stop offset=\"1\" stop-color=\"#d9d8d5\" stop-opacity=\"0\"/></radialGradient>").End())));
if (Truthy(Get(D_4897, "grads"))) {
Invoke(Invoke(svg_4902, "querySelector", ((V)("defs"))), "insertAdjacentHTML", ((V)("beforeend")), Invoke(Invoke(Object_keys(Get(D_4897, "grads")), "map", Fn((V _arrowThis5006, int _argc4999, V id_5005, V _a5002, V _a5003, V _a5004, V[] _rest5000) => {
return ((V)(JsStrBuf.Begin().S("<radialGradient id=\"").V(id_5005).V(u_4898).S("\" cx=\"38%\" cy=\"30%\" r=\"75%\">").V(Invoke(Invoke(GetK(Get(D_4897, "grads"), id_5005), "map", Fn((V _arrowThis5018, int _argc5007, V _a5009, V _a5010, V _a5011, V _a5012, V[] _rest5008) => {
V o_5015 = default;
V c_5017 = default;
{ V _t5013 = ListOf(_a5009);
{ V _t5014 = GetIdx(_t5013, 0D);
o_5015 = _t5014; }
{ V _t5016 = GetIdx(_t5013, 1D);
c_5017 = _t5016; }
}
return ((V)(JsStrBuf.Begin().S("<stop offset=\"").V(o_5015).S("\" stop-color=\"").V(c_5017).S("\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</radialGradient>").End()));
}, 1, "", true)), "join", ((V)(""))));
}
if (Truthy((Get(D_4897, "mane") is var _t5019 && !Truthy(_t5019) ? _t5019 : Get(Get(D_4897, "mane"), "hog")))) {
V gs_5020 = default;
gs_5020 = ((Get(D_4897, "grads") is var _t5022 && !Truthy(_t5022) ? _t5022 : GetK(Get(D_4897, "grads"), GetIdx((Invoke(((V)(ToStrS(Get(Get(D_4897, "mane"), "fill")))), "match", NewRegExp(RX7, "url\\(#([^)]+)\\)", "")) is var _t5021 && Truthy(_t5021) ? _t5021 : Arr()), 1D))) is var _t5023 && Truthy(_t5023) ? _t5023 : Arr(Arr(((V)("0")), ((V)("#a8794e"))), Arr(((V)("1")), ((V)("#5a3a22")))));
Invoke(Invoke(svg_4902, "querySelector", ((V)("defs"))), "insertAdjacentHTML", ((V)("beforeend")), ((V)(JsStrBuf.Begin().S("<radialGradient id=\"hg").V(u_4898).S("\" gradientUnits=\"userSpaceOnUse\" cx=\"40\" cy=\"38\" r=\"58\">").V(Invoke(Invoke(gs_5020, "map", Fn((V _arrowThis5035, int _argc5024, V _a5026, V _a5027, V _a5028, V _a5029, V[] _rest5025) => {
V o_5032 = default;
V c_5034 = default;
{ V _t5030 = ListOf(_a5026);
{ V _t5031 = GetIdx(_t5030, 0D);
o_5032 = _t5031; }
{ V _t5033 = GetIdx(_t5030, 1D);
c_5034 = _t5033; }
}
return ((V)(JsStrBuf.Begin().S("<stop offset=\"").V(o_5032).S("\" stop-color=\"").V(c_5034).S("\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</radialGradient>").End())));
}
Set(I_4900, "shadow", Call(mk_32, V.Undef, ((V)("ellipse")), NewObj(2).Put("fill", ((V)("#6a1b9a"))).Put("opacity", ((V)(0.2))).V, svg_4902));
Set(I_4900, "root", Call(mk_32, V.Undef, ((V)("g")), NewObj(1).Put("filter", ((V)(JsStrBuf.Begin().S("url(#ft").V(u_4898).S(")").End()))).V, svg_4902));
Set(I_4900, "pg", NewObj(0).V);
Set(I_4900, "u", u_4898);
Invoke(Arr(((V)("mane")), ((V)("tail")), ((V)("footL")), ((V)("footR")), ((V)("body")), ((V)("coatB")), ((V)("earL")), ((V)("earR")), ((V)("head")), ((V)("maneF")), ((V)("collar")), ((V)("pup")), ((V)("prop")), ((V)("armL")), ((V)("armR"))), "forEach", Fn((V _arrowThis5043, int _argc5036, V k_5042, V _a5039, V _a5040, V _a5041, V[] _rest5037) => {
return SetK(Get(I_4900, "pg"), k_5042, Call(mk_32, V.Undef, ((V)("g")), NewObj(0).V, Get(I_4900, "root")));
}, 1, "", true));
pg_4913 = Get(I_4900, "pg");
E_4914 = Set(I_4900, "E", NewObj(0).V);
if (Truthy((Get(D_4897, "collar") is var _t5044 && !Truthy(_t5044) ? _t5044 : Get(Get(D_4897, "collar"), "ring")))) {
V g_5045 = default;
V Q0_5046 = default;
V gb_5047 = default;
g_5045 = Get(pg_4913, "collar");
Invoke(Invoke(svg_4902, "querySelector", ((V)("defs"))), "insertAdjacentHTML", ((V)("beforeend")), ((V)(JsStrBuf.Begin().V(Call(Fn((V _arrowThis5057, int _argc5050, V M_5056, V _a5053, V _a5054, V _a5055, V[] _rest5051) => {
return ((V)(JsStrBuf.Begin().S("<radialGradient id=\"tg").V(u_4898).S("\" cx=\"35%\" cy=\"30%\" r=\"75%\"><stop offset=\"0\" stop-color=\"").V(GetIdx(M_5056, 0D)).S("\"/><stop offset=\"0.45\" stop-color=\"").V(GetIdx(M_5056, 1D)).S("\"/><stop offset=\"1\" stop-color=\"").V(GetIdx(M_5056, 2D)).S("\"/></radialGradient>").End()));
}, 1, "", true), V.Undef, ((Get(D_4897, "tag") is var _t5048 && !Truthy(_t5048) ? _t5048 : Get(Get(D_4897, "tag"), "metal")) is var _t5049 && Truthy(_t5049) ? _t5049 : Arr(((V)("#fff7c4")), ((V)("#ffd84a")), ((V)("#c9921c")))))).S("<linearGradient id=\"bg").V(u_4898).S("\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff0a8\"/><stop offset=\"1\" stop-color=\"#c9921c\"/></linearGradient>").S("<filter id=\"csb").V(u_4898).S("\" x=\"-20%\" y=\"-50%\" width=\"140%\" height=\"200%\"><feGaussianBlur stdDeviation=\"0.7\"/></filter>").End())));
Set(E_4914, "cr", NewObj(12).Put("sh", Call(mk_32, V.Undef, ((V)("path")), NewObj(6).Put("fill", ((V)("none"))).Put("stroke", ((V)("#6a3d14"))).Put("stroke-width", ((V)(1.7))).Put("opacity", ((V)(0.22))).Put("stroke-linecap", ((V)("round"))).Put("filter", ((V)(JsStrBuf.Begin().S("url(#csb").V(u_4898).S(")").End()))).V, g_5045)).Put("segs", Array_from(NewObj(1).Put("length", ((V)(48D))).V, Fn((V _arrowThis5064, int _argc5058, V _a5060, V _a5061, V _a5062, V _a5063, V[] _rest5059) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(2).Put("stroke-width", ((V)(0.3))).Put("stroke-linejoin", ((V)("round"))).V, g_5045);
}, 0, "", true))).Put("hl", Call(mk_32, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", Get(Get(Get(D_4897, "collar"), "ring"), "light")).Put("stroke-width", ((V)(0.6))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.85))).V, g_5045)).Put("lo", Call(mk_32, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", Get(Get(Get(D_4897, "collar"), "ring"), "dark")).Put("stroke-width", ((V)(0.55))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.7))).V, g_5045)).Put("st", Call(mk_32, V.Undef, ((V)("path")), NewObj(6).Put("fill", ((V)("none"))).Put("stroke", (Get(Get(Get(D_4897, "collar"), "ring"), "stitch") is var _t5065 && Truthy(_t5065) ? _t5065 : ((V)("#ffd6df")))).Put("stroke-width", ((V)(0.32))).Put("stroke-dasharray", ((V)("0.9 0.75"))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.8))).V, g_5045)).Put("bk", Call(mk_32, V.Undef, ((V)("path")), NewObj(3).Put("fill", ((V)(JsStrBuf.Begin().S("url(#bg").V(u_4898).S(")").End()))).Put("stroke", ((V)("#a8761a"))).Put("stroke-width", ((V)(0.35))).V, g_5045)).Put("bki", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Get(Get(Get(D_4897, "collar"), "ring"), "dark")).V, g_5045)).Put("bkp", Call(mk_32, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#c9921c"))).Put("stroke-width", ((V)(0.6))).Put("stroke-linecap", ((V)("round"))).V, g_5045)).Put("rg", Call(mk_32, V.Undef, ((V)("ellipse")), NewObj(3).Put("fill", ((V)("none"))).Put("stroke", (((Get(D_4897, "tag") is var _t5066 && !Truthy(_t5066) ? _t5066 : Get(Get(D_4897, "tag"), "metal")) is var _t5067 && !Truthy(_t5067) ? _t5067 : GetIdx(Get(Get(D_4897, "tag"), "metal"), 3D)) is var _t5068 && Truthy(_t5068) ? _t5068 : ((V)("#c9921c")))).Put("stroke-width", ((V)(0.55))).V, g_5045)).Put("tg", Call(mk_32, V.Undef, ((V)("ellipse")), NewObj(3).Put("fill", ((V)(JsStrBuf.Begin().S("url(#tg").V(u_4898).S(")").End()))).Put("stroke", (((Get(D_4897, "tag") is var _t5069 && !Truthy(_t5069) ? _t5069 : Get(Get(D_4897, "tag"), "metal")) is var _t5070 && !Truthy(_t5070) ? _t5070 : GetIdx(Get(Get(D_4897, "tag"), "metal"), 3D)) is var _t5071 && Truthy(_t5071) ? _t5071 : ((V)("#b07d14")))).Put("stroke-width", ((V)(0.45))).V, g_5045)).Put("ti", Call(mk_32, V.Undef, ((V)("ellipse")), NewObj(3).Put("fill", ((V)("none"))).Put("stroke", (((Get(D_4897, "tag") is var _t5072 && !Truthy(_t5072) ? _t5072 : Get(Get(D_4897, "tag"), "metal")) is var _t5073 && !Truthy(_t5073) ? _t5073 : GetIdx(Get(Get(D_4897, "tag"), "metal"), 2D)) is var _t5074 && Truthy(_t5074) ? _t5074 : ((V)("#e8b52c")))).Put("stroke-width", ((V)(0.35))).V, g_5045)).Put("gl", Call(mk_32, V.Undef, ((V)("ellipse")), NewObj(2).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.75))).V, g_5045)).V);
Invoke(Invoke(svg_4902, "querySelector", ((V)("defs"))), "insertAdjacentHTML", ((V)("beforeend")), ((V)(JsStrBuf.Begin().S("<mask id=\"cm").V(u_4898).S("\" maskUnits=\"userSpaceOnUse\" x=\"-60\" y=\"-60\" width=\"220\" height=\"220\"><path fill=\"#fff\"/><path fill=\"#fff\"/></mask>").End())));
Q0_5046 = Get(E_4914, "cr");
gb_5047 = Call(mk_32, V.Undef, ((V)("g")), NewObj(1).Put("mask", ((V)(JsStrBuf.Begin().S("url(#cm").V(u_4898).S(")").End()))).V, g_5045);
Invoke(g_5045, "insertBefore", gb_5047, Get(g_5045, "firstChild"));
Invoke(Invoke(Arr(Get(Q0_5046, "sh")), "concat", Get(Q0_5046, "segs"), Arr(Get(Q0_5046, "hl"), Get(Q0_5046, "lo"), Get(Q0_5046, "st"), Get(Q0_5046, "bk"), Get(Q0_5046, "bki"), Get(Q0_5046, "bkp"))), "forEach", Fn((V _arrowThis5082, int _argc5075, V e_5081, V _a5078, V _a5079, V _a5080, V[] _rest5076) => {
return Invoke(gb_5047, "appendChild", e_5081);
}, 1, "", true));
Set(Q0_5046, "mk", new ArrBuilder().Spread(Invoke(svg_4902, "querySelectorAll", ((V)(JsStrBuf.Begin().S("#cm").V(u_4898).S(" path").End())))).V);
} else {
if (Truthy(Get(D_4897, "collar"))) {
Set(E_4914, "collar", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Get(Get(D_4897, "collar"), "fill")).V, Get(pg_4913, "collar")));
Set(E_4914, "tag", Call(mk_32, V.Undef, ((V)("path")), NewObj(3).Put("fill", Get(Get(D_4897, "tag"), "fill")).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(0.8))).V, Get(pg_4913, "collar")));
}
}
if (Truthy(Get(D_4897, "tail3"))) {
Invoke(Invoke(svg_4902, "querySelector", ((V)("defs"))), "insertAdjacentHTML", ((V)("beforeend")), ((V)(JsStrBuf.Begin().S("<radialGradient id=\"tb").V(u_4898).S("\"><stop offset=\"0\" stop-color=\"").V((Get(Get(D_4897, "c"), "tailB") is var _t5083 && Truthy(_t5083) ? _t5083 : ((V)("#eba264")))).S("\"/><stop offset=\"0.55\" stop-color=\"").V((Get(Get(D_4897, "c"), "tailB") is var _t5084 && Truthy(_t5084) ? _t5084 : ((V)("#eba264")))).S("\" stop-opacity=\"0.85\"/><stop offset=\"1\" stop-color=\"").V((Get(Get(D_4897, "c"), "tailB") is var _t5085 && Truthy(_t5085) ? _t5085 : ((V)("#eba264")))).S("\" stop-opacity=\"0\"/></radialGradient>").End())));
Set(E_4914, "tailT", Invoke(Arr(((V)(1.55)), ((V)(1.25))), "map", Fn((V _arrowThis5092, int _argc5086, V _a5088, V _a5089, V _a5090, V _a5091, V[] _rest5087) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", Get(Get(D_4897, "c"), "tail")).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V, Get(pg_4913, "tail"));
}, 0, "", true)));
if (Truthy(Get(D_4897, "tailTaper"))) {
Set(E_4914, "tailF", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Get(Get(D_4897, "c"), "tail")).V, Get(pg_4913, "tail")));
Invoke(Invoke(svg_4902, "querySelector", ((V)("defs"))), "insertAdjacentHTML", ((V)("beforeend")), ((V)(JsStrBuf.Begin().S("<filter id=\"tsb").V(u_4898).S("\" x=\"-30%\" y=\"-30%\" width=\"160%\" height=\"160%\"><feGaussianBlur stdDeviation=\"0.9\"/></filter>").End())));
Set(E_4914, "tailS", Call(mk_32, V.Undef, ((V)("path")), NewObj(4).Put("fill", (Get(D_4897, "tailShade") is var _t5093 && Truthy(_t5093) ? _t5093 : ((V)("#c9873f")))).Put("opacity", ((V)(0.38))).Put("filter", ((V)(JsStrBuf.Begin().S("url(#tsb").V(u_4898).S(")").End()))).Put("clip-path", ((V)(JsStrBuf.Begin().S("url(#tsc").V(u_4898).S(")").End()))).V, Get(pg_4913, "tail")));
Invoke(Invoke(svg_4902, "querySelector", ((V)("defs"))), "insertAdjacentHTML", ((V)("beforeend")), ((V)(JsStrBuf.Begin().S("<clipPath id=\"tsc").V(u_4898).S("\" clipPathUnits=\"userSpaceOnUse\"><path/></clipPath>").End())));
Set(E_4914, "tailSC", Invoke(svg_4902, "querySelector", ((V)(JsStrBuf.Begin().S("#tsc").V(u_4898).S(" path").End()))));
}
}
Set(E_4914, "tail", Call(mk_32, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", Get(Get(D_4897, "c"), "tail")).Put("stroke-width", ((V)(7D))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V, Get(pg_4913, "tail")));
Set(E_4914, "tailH", Call(mk_32, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", (Get(Get(D_4897, "c"), "tailHL") is var _t5094 && Truthy(_t5094) ? _t5094 : ((V)("#ffd2a3")))).Put("stroke-width", ((V)(2D))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.55))).V, Get(pg_4913, "tail")));
if (Truthy(Get(D_4897, "tail3"))) {
Set(E_4914, "tailB", Call(mk_32, V.Undef, ((V)("ellipse")), NewObj(1).Put("fill", ((V)(JsStrBuf.Begin().S("url(#tb").V(u_4898).S(")").End()))).V, Get(pg_4913, "tail")));
}
Set(E_4914, "feet", Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _arrowThis5102, int _argc5095, V i_5101, V _a5098, V _a5099, V _a5100, V[] _rest5096) => {
V p_5103 = default;
V lg_5104 = default;
p_5103 = GetK(pg_4913, ((V)((Truthy(i_5101) ? "footR" : "footL"))));
lg_5104 = (Truthy((Get(D_4897, "web") is var _t5106 && !Truthy(_t5106) ? _t5106 : Get(Get(D_4897, "web"), "leg"))) ? Call(mk_32, V.Undef, ((V)("path")), NewObj(3).Put("fill", ((V)("none"))).Put("stroke", Call(CF_4912, V.Undef, (Get(Get(Get(D_4897, "web"), "leg"), "fill") is var _t5105 && Truthy(_t5105) ? _t5105 : Get(Get(D_4897, "c"), "foot")))).Put("stroke-linecap", ((V)("round"))).V, p_5103) : V.Null);
return NewObj(4).Put("leg", lg_5104).Put("f", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4912, V.Undef, Get(Get(D_4897, "c"), "foot"))).V, p_5103)).Put("p", Call(mk_32, V.Undef, ((V)("path")), NewObj(3).Put("fill", Get(Get(D_4897, "c"), "pad")).Put("opacity", ((V)(0.9))).Put("clip-path", ((V)(JsStrBuf.Begin().S("url(#fk").V(i_5101).V(u_4898).S(")").End()))).V, p_5103)).Put("clip", Invoke(svg_4902, "querySelector", ((V)(JsStrBuf.Begin().S("#fk").V(i_5101).V(u_4898).S(" path").End())))).V;
return default;
}, 1, "", true)));
if (Truthy(Get(D_4897, "mane"))) {
V ma_5107 = default;
ma_5107 = NewObj(4).Put("fill", Call(CF_4912, V.Undef, Get(Get(D_4897, "mane"), "fill"))).Put("stroke", (Truthy(Get(Get(D_4897, "mane"), "stroke")) ? Call(CF_4912, V.Undef, Get(Get(D_4897, "mane"), "stroke")) : ((V)("none")))).Put("stroke-width", (Get(Get(D_4897, "mane"), "sw") is var _t5108 && Truthy(_t5108) ? _t5108 : ((V)(0D)))).Put("stroke-linejoin", ((V)("round"))).V;
Set(E_4914, "mane", Call(mk_32, V.Undef, ((V)("path")), ma_5107, Get(pg_4913, "mane")));
if (Truthy(Get(Get(D_4897, "mane"), "spiky"))) {
Set(E_4914, "maneF", Call(mk_32, V.Undef, ((V)("path")), ma_5107, Get(pg_4913, "maneF")));
}
}
Set(E_4914, "body", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4912, V.Undef, Get(Get(D_4897, "c"), "body"))).V, Get(pg_4913, "body")));
if (Truthy(Get(D_4897, "hideBody"))) {
Set(Get(Get(E_4914, "body"), "style"), "display", ((V)("none")));
}
if (Truthy((Get(D_4897, "belly") is var _t5109 && Truthy(_t5109) ? _t5109 : Get(D_4897, "bellyD")))) {
Set(E_4914, "belly", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4912, V.Undef, (Truthy(Get(D_4897, "bellyD")) ? Get(Get(D_4897, "bellyD"), "fill") : GetIdx(Get(D_4897, "belly"), 4D)))).V, Get(pg_4913, "body")));
}
Set(E_4914, "bodyG", Call(mk_32, V.Undef, ((V)("path")), NewObj(2).Put("fill", ((V)("#93b84a"))).Put("opacity", ((V)(0D))).V, Get(pg_4913, "body")));
if (Truthy(Get(D_4897, "neck3"))) {
Set(E_4914, "neck3", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4912, V.Undef, (Get(Get(D_4897, "neck3"), "fill") is var _t5110 && Truthy(_t5110) ? _t5110 : Get(Get(D_4897, "c"), "body")))).V, Get(pg_4913, "body")));
Invoke(Get(pg_4913, "body"), "insertBefore", Get(E_4914, "neck3"), Get(E_4914, "body"));
}
if (Truthy(Get(D_4897, "lumps"))) {
Set(E_4914, "lumps", Invoke(Get(D_4897, "lumps"), "map", Fn((V _arrowThis5118, int _argc5111, V L_5117, V _a5114, V _a5115, V _a5116, V[] _rest5112) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4912, V.Undef, (Get(L_5117, "fill") is var _t5119 && Truthy(_t5119) ? _t5119 : Get(Get(D_4897, "c"), "body")))).V, Get(pg_4913, "body"));
}, 1, "", true)));
}
if (Truthy((Get(D_4897, "spots3") is var _t5120 && !Truthy(_t5120) ? _t5120 : Get(D_4897, "body3")))) {
Set(E_4914, "spots3", Call(mk_32, V.Undef, ((V)("path")), NewObj(2).Put("fill", Call(CF_4912, V.Undef, (Get(Get(D_4897, "spots3"), "fill") is var _t5121 && Truthy(_t5121) ? _t5121 : ((V)("#5a3a1e"))))).Put("opacity", (!Get(Get(D_4897, "spots3"), "op").IsNullish ? Get(Get(D_4897, "spots3"), "op") : ((V)(1D)))).V, Get(pg_4913, "body")));
}
Set(E_4914, "ears", Invoke(Get(D_4897, "ears"), "map", Fn((V _arrowThis5130, int _argc5122, V ed_5128, V i_5129, V _a5126, V _a5127, V[] _rest5123) => {
V p_5131 = default;
p_5131 = GetK(pg_4913, ((V)((GtN(Get(ed_5128, "side"), 0D) ? "earR" : "earL"))));
return NewObj(3).Put("o", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", (Truthy(Get(ed_5128, "fill")) ? Call(CF_4912, V.Undef, Get(ed_5128, "fill")) : (Truthy(Get(Get(D_4897, "c"), "ge")) ? ((V)(JsStrBuf.Begin().S("url(#ge").V(u_4898).S(")").End())) : FUR_4911))).V, p_5131)).Put("n", Call(mk_32, V.Undef, ((V)("path")), NewObj(3).Put("fill", Call(CF_4912, V.Undef, (Get(ed_5128, "innerFill") is var _t5132 && Truthy(_t5132) ? _t5132 : Get(Get(D_4897, "c"), "inner")))).Put("opacity", (Get(ed_5128, "innerOp") is var _t5133 && Truthy(_t5133) ? _t5133 : ((V)(0.8)))).Put("clip-path", ((V)(JsStrBuf.Begin().S("url(#ek").V(i_5129).V(u_4898).S(")").End()))).V, p_5131)).Put("clip", Invoke(svg_4902, "querySelector", ((V)(JsStrBuf.Begin().S("#ek").V(i_5129).V(u_4898).S(" path").End())))).V;
return default;
}, 2, "", true)));
Invoke(Get(D_4897, "ears"), "forEach", Fn((V _arrowThis5142, int _argc5134, V ed_5140, V i_5141, V _a5138, V _a5139, V[] _rest5135) => {
V m_5143 = default;
if (!(Truthy(Get(ed_5140, "lobe")))) {
return default;
}
m_5143 = Call(mk_32, V.Undef, ((V)("mask")), NewObj(6).Put("id", ((V)(JsStrBuf.Begin().S("em").V(i_5141).V(u_4898).End()))).Put("maskUnits", ((V)("userSpaceOnUse"))).Put("x", ((V)((-50D)))).Put("y", ((V)((-50D)))).Put("width", ((V)(200D))).Put("height", ((V)(200D))).V, Invoke(svg_4902, "querySelector", ((V)("defs"))));
Call(mk_32, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-50D)))).Put("y", ((V)((-50D)))).Put("width", ((V)(200D))).Put("height", ((V)(200D))).Put("fill", ((V)("#fff"))).V, m_5143);
Set(GetK(Get(E_4914, "ears"), i_5141), "mk", Arr(Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#000"))).V, m_5143), Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#000"))).V, m_5143)));
Invoke(GetK(pg_4913, ((V)((GtN(Get(ed_5140, "side"), 0D) ? "earR" : "earL")))), "setAttribute", ((V)("mask")), ((V)(JsStrBuf.Begin().S("url(#em").V(i_5141).V(u_4898).S(")").End())));
return default;
}, 2, "", true));
if (Truthy(Get(D_4897, "tufts"))) {
Set(E_4914, "tuftB", Call(mk_32, V.Undef, ((V)("g")), NewObj(0).V, Get(pg_4913, "head")));
}
Set(E_4914, "skull", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4912, V.Undef, Get(Get(D_4897, "c"), "head"))).V, Get(pg_4913, "head")));
Set(E_4914, "hx", Invoke((Get(D_4897, "headExtra") is var _t5153 && Truthy(_t5153) ? _t5153 : Arr()), "map", Fn((V _arrowThis5151, int _argc5144, V h_5150, V _a5147, V _a5148, V _a5149, V[] _rest5145) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(2).Put("fill", Call(CF_4912, V.Undef, Get(h_5150, "fill"))).Put("opacity", (Get(h_5150, "op") is var _t5152 && Truthy(_t5152) ? _t5152 : ((V)(1D)))).V, Get(pg_4913, "head"));
}, 1, "", true)));
if (Truthy(Get(D_4897, "crest"))) {
Set(E_4914, "crest", Invoke(Get(D_4897, "crest"), "map", Fn((V _arrowThis5161, int _argc5154, V c_5160, V _a5157, V _a5158, V _a5159, V[] _rest5155) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4912, V.Undef, (Get(c_5160, "fill") is var _t5162 && Truthy(_t5162) ? _t5162 : Get(Get(D_4897, "c"), "inner")))).V, Get(pg_4913, "earL"));
}, 1, "", true)));
}
if (Truthy(Get(D_4897, "tufts"))) {
Set(E_4914, "tuftF", Call(mk_32, V.Undef, ((V)("g")), NewObj(0).V, Get(pg_4913, "head")));
Set(E_4914, "tuftG", Invoke(Get(D_4897, "tufts"), "map", Fn((V _arrowThis5169, int _argc5163, V _a5165, V _a5166, V _a5167, V _a5168, V[] _rest5164) => {
return Call(mk_32, V.Undef, ((V)("g")), NewObj(0).V, Get(E_4914, "tuftF"));
}, 0, "", true)));
Set(E_4914, "tufts", Invoke(Get(D_4897, "tufts"), "map", Fn((V _arrowThis5178, int _argc5170, V t_5176, V i_5177, V _a5174, V _a5175, V[] _rest5171) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4912, V.Undef, (Get(t_5176, "fill") is var _t5179 && Truthy(_t5179) ? _t5179 : ((V)("url(#wcr)"))))).V, GetK(Get(E_4914, "tuftG"), i_5177));
}, 2, "", true)));
Set(E_4914, "tuftsB", Invoke(Get(D_4897, "tufts"), "map", Fn((V _arrowThis5187, int _argc5180, V t_5186, V _a5183, V _a5184, V _a5185, V[] _rest5181) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4912, V.Undef, (Get(t_5186, "fill") is var _t5188 && Truthy(_t5188) ? _t5188 : ((V)("url(#wcr)"))))).V, Get(E_4914, "tuftB"));
}, 1, "", true)));
Set(E_4914, "tuftsW", Invoke(Get(D_4897, "tufts"), "map", Fn((V _arrowThis5197, int _argc5189, V t_5195, V i_5196, V _a5193, V _a5194, V[] _rest5190) => {
return (Truthy(Get(t_5195, "white")) ? Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", (GetIdx(Get(t_5195, "white"), 3D) is var _t5198 && Truthy(_t5198) ? _t5198 : ((V)("#fffef4")))).V, GetK(Get(E_4914, "tuftG"), i_5196)) : V.Null);
}, 2, "", true)));
Invoke(Invoke(svg_4902, "querySelector", ((V)("defs"))), "insertAdjacentHTML", ((V)("beforeend")), Invoke(Invoke(Get(D_4897, "tufts"), "map", Fn((V _arrowThis5207, int _argc5199, V t_5205, V i_5206, V _a5203, V _a5204, V[] _rest5200) => {
return ((V)(JsStrBuf.Begin().S("<radialGradient id=\"tfg").V(i_5206).V(u_4898).S("\" gradientUnits=\"userSpaceOnUse\" cx=\"50\" cy=\"46\" r=\"60\"><stop offset=\"0\" stop-color=\"#000\"/><stop offset=\"0\" stop-color=\"#fff\"/></radialGradient>").S("<mask id=\"tfm").V(i_5206).V(u_4898).S("\" maskUnits=\"userSpaceOnUse\" x=\"-60\" y=\"-60\" width=\"220\" height=\"220\"><rect x=\"-60\" y=\"-60\" width=\"220\" height=\"220\" fill=\"url(#tfg").V(i_5206).V(u_4898).S(")\"/></mask>").End()));
}, 2, "", true)), "join", ((V)(""))));
Invoke(Get(E_4914, "tufts"), "forEach", Fn((V _arrowThis5216, int _argc5208, V el_5214, V i_5215, V _a5212, V _a5213, V[] _rest5209) => {
V gq_5217 = default;
Invoke(GetK(Get(E_4914, "tuftG"), i_5215), "setAttribute", ((V)("mask")), ((V)(JsStrBuf.Begin().S("url(#tfm").V(i_5215).V(u_4898).S(")").End())));
gq_5217 = Invoke(svg_4902, "querySelector", ((V)(JsStrBuf.Begin().S("#tfg").V(i_5215).V(u_4898).End())));
Set(el_5214, "_g", gq_5217);
Set(el_5214, "_s", Invoke(gq_5217, "querySelectorAll", ((V)("stop"))));
return default;
}, 2, "", true));
}
face_4915 = Call(mk_32, V.Undef, ((V)("g")), NewObj(1).Put("clip-path", ((V)(JsStrBuf.Begin().S("url(#fc").V(u_4898).S(")").End()))).V, Get(pg_4913, "head"));
Set(E_4914, "muzzle", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Get(Get(D_4897, "c"), "muzzle")).V, face_4915));
Invoke((Get(E_4914, "hx") is var _t5226 && Truthy(_t5226) ? _t5226 : Arr()), "forEach", Fn((V _arrowThis5225, int _argc5218, V el_5224, V _a5221, V _a5222, V _a5223, V[] _rest5219) => {
return Invoke(face_4915, "insertBefore", el_5224, Get(E_4914, "muzzle"));
}, 1, "", true));
Set(E_4914, "tintR", Call(mk_32, V.Undef, ((V)("path")), NewObj(2).Put("fill", ((V)("#ff4040"))).Put("opacity", ((V)(0D))).V, face_4915));
Set(E_4914, "tintG", Call(mk_32, V.Undef, ((V)("path")), NewObj(2).Put("fill", ((V)("#93b84a"))).Put("opacity", ((V)(0D))).V, face_4915));
Set(E_4914, "stripes", Call(mk_32, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", Get(Get(D_4897, "c"), "stripe")).Put("stroke-width", ((V)(2D))).Put("stroke-linecap", ((V)("round"))).V, face_4915));
Set(E_4914, "back", Call(mk_32, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", Get(Get(D_4897, "c"), "stripe")).Put("stroke-width", (Get(D_4897, "backW") is var _t5227 && Truthy(_t5227) ? _t5227 : ((V)(2.2)))).Put("stroke-linecap", ((V)("round"))).V, face_4915));
Set(E_4914, "fx", Invoke((Get(D_4897, "faceExtra") is var _t5240 && Truthy(_t5240) ? _t5240 : Arr()), "map", Fn((V _arrowThis5235, int _argc5228, V fe_5234, V _a5231, V _a5232, V _a5233, V[] _rest5229) => {
return Call(mk_32, V.Undef, ((V)("path")), (Truthy((Get(fe_5234, "stroke") is var _t5239 && !Truthy(_t5239) ? _t5239 : (!(Truthy(Get(fe_5234, "fill"))) ? V.True : V.False))) ? NewObj(4).Put("fill", ((V)("none"))).Put("stroke", Get(fe_5234, "stroke")).Put("stroke-width", (Get(fe_5234, "sw") is var _t5236 && Truthy(_t5236) ? _t5236 : ((V)(1D)))).Put("stroke-linecap", ((V)("round"))).V : NewObj(3).Put("fill", Call(CF_4912, V.Undef, Get(fe_5234, "fill"))).Put("stroke", (Get(fe_5234, "stroke") is var _t5237 && Truthy(_t5237) ? _t5237 : ((V)("none")))).Put("stroke-width", (Get(fe_5234, "sw") is var _t5238 && Truthy(_t5238) ? _t5238 : ((V)(0D)))).V), face_4915);
}, 1, "", true)));
Set(E_4914, "nose", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Get(Get(D_4897, "c"), "nose")).V, face_4915));
if (Truthy(Get(D_4897, "noseHL"))) {
Set(E_4914, "noseHL", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#ffffff"))).V, face_4915));
}
Set(E_4914, "cheeks", Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _arrowThis5247, int _argc5241, V _a5243, V _a5244, V _a5245, V _a5246, V[] _rest5242) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Get(Get(D_4897, "c"), "cheek")).V, face_4915);
}, 0, "", true)));
Set(E_4914, "eyes", Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _arrowThis5255, int _argc5248, V i_5254, V _a5251, V _a5252, V _a5253, V[] _rest5249) => {
V gg_5256 = default;
V e_5257 = default;
V hg_5258 = default;
gg_5256 = Call(mk_32, V.Undef, ((V)("g")), NewObj(0).V, face_4915);
e_5257 = Call(mk_32, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)(JsStrBuf.Begin().S("url(#ey").V(u_4898).S(")").End()))).Put("stroke", ((V)("#2a1a30"))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V, gg_5256);
hg_5258 = Call(mk_32, V.Undef, ((V)("g")), NewObj(1).Put("clip-path", ((V)(JsStrBuf.Begin().S("url(#ec").V(i_5254).V(u_4898).S(")").End()))).V, gg_5256);
return NewObj(6).Put("g", gg_5256).Put("e", e_5257).Put("tp", Call(mk_32, V.Undef, ((V)("path")), NewObj(2).Put("fill", ((V)("#a8dcff"))).Put("opacity", ((V)(0D))).V, hg_5258)).Put("h1", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#fff"))).V, hg_5258)).Put("h2", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#fff"))).V, hg_5258)).Put("clip", Invoke(svg_4902, "querySelector", ((V)(JsStrBuf.Begin().S("#ec").V(i_5254).V(u_4898).S(" path").End())))).V;
return default;
}, 1, "", true)));
if (Truthy((Get(D_4897, "eyeDome") is var _t5259 && !Truthy(_t5259) ? _t5259 : Get(E_4914, "tuftG")))) {
Invoke(Get(E_4914, "eyes"), "forEach", Fn((V _arrowThis5268, int _argc5260, V o_5266, V i_5267, V _a5264, V _a5265, V[] _rest5261) => {
if (Truthy(GetK(Get(E_4914, "tuftG"), i_5267))) {
Invoke(GetK(Get(E_4914, "tuftG"), i_5267), "appendChild", Get(o_5266, "g"));
}
return default;
}, 2, "", true));
}
Set(E_4914, "mopen", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#7a2a40"))).V, face_4915));
Set(E_4914, "tongue", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#ff8fa3"))).V, face_4915));
Set(E_4914, "mouth", Call(mk_32, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", Get(Get(D_4897, "c"), "mouth")).Put("stroke-width", ((V)(1.2))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V, face_4915));
Set(E_4914, "tout", Call(mk_32, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("#ff7f9a"))).Put("stroke", ((V)("#e0607e"))).Put("stroke-width", ((V)(0.3))).Put("opacity", ((V)(0D))).V, face_4915));
wg_4916 = Call(mk_32, V.Undef, ((V)("g")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", Get(Get(D_4897, "c"), "whisker")).Put("stroke-width", ((V)(0.9))).Put("stroke-linecap", ((V)("round"))).V, Get(pg_4913, "head"));
Set(E_4914, "wh", Invoke(Get(D_4897, "whiskers"), "map", Fn((V _arrowThis5275, int _argc5269, V _a5271, V _a5272, V _a5273, V _a5274, V[] _rest5270) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(0).V, wg_4916);
}, 0, "", true)));
if (Truthy(Get(D_4897, "snout"))) {
if (Truthy(Get(Get(D_4897, "snout"), "jaw"))) {
Set(E_4914, "snoutJ", Call(mk_32, V.Undef, ((V)("path")), NewObj(3).Put("fill", Call(CF_4912, V.Undef, ((Get(Get(Get(D_4897, "snout"), "jaw"), "fill") is var _t5276 && Truthy(_t5276) ? _t5276 : Get(Get(D_4897, "snout"), "fill")) is var _t5277 && Truthy(_t5277) ? _t5277 : Get(Get(D_4897, "c"), "muzzle")))).Put("stroke", (Get(Get(D_4897, "snout"), "stroke") is var _t5278 && Truthy(_t5278) ? _t5278 : ((V)("none")))).Put("stroke-width", (Get(Get(D_4897, "snout"), "sw") is var _t5279 && Truthy(_t5279) ? _t5279 : ((V)(0D)))).V, Get(pg_4913, "head")));
}
Set(E_4914, "snout", Call(mk_32, V.Undef, ((V)("path")), NewObj(3).Put("fill", Call(CF_4912, V.Undef, (Get(Get(D_4897, "snout"), "fill") is var _t5280 && Truthy(_t5280) ? _t5280 : Get(Get(D_4897, "c"), "muzzle")))).Put("stroke", (Get(Get(D_4897, "snout"), "stroke") is var _t5281 && Truthy(_t5281) ? _t5281 : ((V)("none")))).Put("stroke-width", (Get(Get(D_4897, "snout"), "sw") is var _t5282 && Truthy(_t5282) ? _t5282 : ((V)(0D)))).V, Get(pg_4913, "head")));
Set(E_4914, "snoutN", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4912, V.Undef, ((Get(Get(D_4897, "snout"), "nose") is var _t5283 && !Truthy(_t5283) ? _t5283 : Get(Get(Get(D_4897, "snout"), "nose"), "fill")) is var _t5284 && Truthy(_t5284) ? _t5284 : ((V)("#3a2340"))))).V, Get(pg_4913, "head")));
Set(E_4914, "snoutH", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#ffffff"))).V, Get(pg_4913, "head")));
}
Set(E_4914, "armT", Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _arrowThis5292, int _argc5285, V i_5291, V _a5288, V _a5289, V _a5290, V[] _rest5286) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", Get(Get(D_4897, "c"), "arm")).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0D))).V, GetK(pg_4913, ((V)((Truthy(i_5291) ? "armR" : "armL")))));
}, 1, "", true)));
Set(E_4914, "arms", Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _arrowThis5300, int _argc5293, V i_5299, V _a5296, V _a5297, V _a5298, V[] _rest5294) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4912, V.Undef, Get(Get(D_4897, "c"), "armFill"))).V, GetK(pg_4913, ((V)((Truthy(i_5299) ? "armR" : "armL")))));
}, 1, "", true)));
if (Truthy((Get(D_4897, "wing") is var _t5301 && !Truthy(_t5301) ? _t5301 : Get(Get(D_4897, "wing"), "f")))) {
Set(E_4914, "wingF", Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _arrowThis5309, int _argc5302, V i_5308, V _a5305, V _a5306, V _a5307, V[] _rest5303) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", (Get(Get(D_4897, "wing"), "fc") is var _t5310 && Truthy(_t5310) ? _t5310 : ((V)("#e8b43a")))).Put("stroke-width", (Get(Get(D_4897, "wing"), "sw") is var _t5311 && Truthy(_t5311) ? _t5311 : ((V)(0.5)))).Put("stroke-linecap", ((V)("round"))).V, GetK(pg_4913, ((V)((Truthy(i_5308) ? "armR" : "armL")))));
}, 1, "", true)));
}
Set(E_4914, "crown", Invoke((Get(D_4897, "crown") is var _t5322 && Truthy(_t5322) ? _t5322 : Arr()), "map", Fn((V _arrowThis5319, int _argc5312, V h_5318, V _a5315, V _a5316, V _a5317, V[] _rest5313) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(3).Put("fill", Call(CF_4912, V.Undef, Get(h_5318, "fill"))).Put("stroke", (Get(h_5318, "stroke") is var _t5320 && Truthy(_t5320) ? _t5320 : ((V)("none")))).Put("stroke-width", (Get(h_5318, "sw") is var _t5321 && Truthy(_t5321) ? _t5321 : ((V)(0D)))).V, Get(pg_4913, "head"));
}, 1, "", true)));
Set(E_4914, "pup", Invoke((Get(D_4897, "pup") is var _t5334 && Truthy(_t5334) ? _t5334 : Arr()), "map", Fn((V _arrowThis5330, int _argc5323, V h_5329, V _a5326, V _a5327, V _a5328, V[] _rest5324) => {
return Call(mk_32, V.Undef, ((V)("path")), (Truthy((Get(h_5329, "stroke") is var _t5333 && !Truthy(_t5333) ? _t5333 : (!(Truthy(Get(h_5329, "fill"))) ? V.True : V.False))) ? NewObj(4).Put("fill", ((V)("none"))).Put("stroke", Get(h_5329, "stroke")).Put("stroke-width", (Get(h_5329, "sw") is var _t5331 && Truthy(_t5331) ? _t5331 : ((V)(1D)))).Put("stroke-linecap", ((V)("round"))).V : NewObj(2).Put("fill", Call(CF_4912, V.Undef, Get(h_5329, "fill"))).Put("opacity", (Get(h_5329, "op") is var _t5332 && Truthy(_t5332) ? _t5332 : ((V)(1D)))).V), Get(pg_4913, "pup"));
}, 1, "", true)));
if (!(Truthy(Get(D_4897, "tail")))) {
Set(Get(Get(pg_4913, "tail"), "style"), "display", ((V)("none")));
}
if (SEq(Get(D_4897, "muzzle"), V.Null)) {
Set(Get(Get(E_4914, "muzzle"), "style"), "display", ((V)("none")));
}
if (SEq(Get(D_4897, "nose"), V.Null)) {
Set(Get(Get(E_4914, "nose"), "style"), "display", ((V)("none")));
}
Set(E_4914, "clip", Invoke(svg_4902, "querySelector", ((V)(JsStrBuf.Begin().S("#fc").V(u_4898).S(" path").End()))));
Set(I_4900, "fxG", Call(mk_32, V.Undef, ((V)("g")), NewObj(0).V, svg_4902));
{ V _t5335 = (Get(D_4897, "tail") is var _t5336 && Truthy(_t5336) ? _t5336 : Arr(Arr(((V)(50D)), ((V)(85D))), Arr(((V)(50D)), ((V)(85D))), Arr(((V)(50D)), ((V)(85D))), Arr(((V)(50D)), ((V)(85D)))));
{ V _t5337 = ListOf(_t5335);
{ V _t5338 = GetIdx(_t5337, 0D);
t0_4917 = _t5338; }
{ V _t5339 = GetIdx(_t5337, 1D);
t1_4918 = _t5339; }
{ V _t5340 = GetIdx(_t5337, 2D);
t2_4919 = _t5340; }
{ V _t5341 = GetIdx(_t5337, 3D);
t3_4920 = _t5341; }
} }
cub_4921 = Fn((V _arrowThis5353, int _argc5342, V a_5348, V b_5349, V c_5350, V d_5351, V[] _rest5343) => {
double m_5354 = 0;
V t_5352 = default;
t_5352 = (_argc5342 > 4 ? _rest5343[0] : V.Undef);
m_5354 = (1D - ToNum(t_5352));
return ((V)(((((((m_5354 * m_5354) * m_5354) * ToNum(a_5348)) + ((((3D * m_5354) * m_5354) * ToNum(t_5352)) * ToNum(b_5349))) + ((((3D * m_5354) * ToNum(t_5352)) * ToNum(t_5352)) * ToNum(c_5350))) + (((ToNum(t_5352) * ToNum(t_5352)) * ToNum(t_5352)) * ToNum(d_5351)))));
return default;
}, 5, "", true);
Set(I_4900, "furH", (Truthy(Get(D_4897, "headD")) ? Call(furRing_23, V.Undef, Get(D_4897, "headD"), Get(D_4897, "head")) : V.Null));
Set(I_4900, "furB", (Truthy((Get(D_4897, "bodyD") is var _t5355 && !Truthy(_t5355) ? _t5355 : (!(Truthy(Get(D_4897, "body3"))) ? V.True : V.False))) ? Call(furRing_23, V.Undef, Get(D_4897, "bodyD"), Get(D_4897, "body")) : V.Null));
Set(I_4900, "RG", NewObj(28).Put("body", (Truthy(Get(D_4897, "bodyD")) ? Call(parsePath_21, V.Undef, Get(D_4897, "bodyD")) : Call(ellS_22, V.Undef, GetIdx(Get(D_4897, "body"), 0D), GetIdx(Get(D_4897, "body"), 1D), GetIdx(Get(D_4897, "body"), 2D), GetIdx(Get(D_4897, "body"), 3D), ((V)(0D)), ((V)(16D))))).Put("skull", (Truthy(Get(D_4897, "headD")) ? Call(parsePath_21, V.Undef, Get(D_4897, "headD")) : Call(ellS_22, V.Undef, GetIdx(Get(D_4897, "head"), 0D), GetIdx(Get(D_4897, "head"), 1D), GetIdx(Get(D_4897, "head"), 2D), (GetIdx(Get(D_4897, "head"), 3D) is var _t5356 && Truthy(_t5356) ? _t5356 : GetIdx(Get(D_4897, "head"), 2D)), ((V)(0D)), ((V)(16D))))).Put("muzzle", (SEq(Get(D_4897, "muzzle"), V.Null) ? Arr() : CallSpread(ellS_22, V.Undef, new ArrBuilder().Spread(Invoke((Get(D_4897, "muzzle") is var _t5357 && Truthy(_t5357) ? _t5357 : Arr(((V)(50D)), ((V)(57D)), ((V)(16D)), ((V)(10D)))), "slice", ((V)(0D)), ((V)(4D)))).Add(((V)(0D))).Add(((V)(12D))).V))).Put("mane", (Truthy(Get(D_4897, "mane")) ? Call(parsePath_21, V.Undef, Get(Get(D_4897, "mane"), "d")) : V.Null)).Put("spk", (Truthy((Get(D_4897, "mane") is var _t5452 && !Truthy(_t5452) ? _t5452 : Get(Get(D_4897, "mane"), "spiky"))) ? Call(Fn((V _arrowThis5364, int _argc5358, V _a5360, V _a5361, V _a5362, V _a5363, V[] _rest5359) => {
V C_5365 = default;
V P_5366 = default;
double avg_5367 = 0;
V tips_5368 = default;
V vals_5369 = default;
double rt_5370 = 0;
double rb_5371 = 0;
V n_5372 = default;
V th_5373 = default;
V list_5374 = default;
C_5365 = (Get(Get(D_4897, "mane"), "c") is var _t5375 && Truthy(_t5375) ? _t5375 : Arr(GetIdx(Get(D_4897, "head"), 0D), GetIdx(Get(D_4897, "head"), 1D)));
P_5366 = Invoke(Call(flat_27, V.Undef, Call(parsePath_21, V.Undef, Get(Get(D_4897, "mane"), "d")), ((V)(1D))), "map", Fn((V _arrowThis5383, int _argc5376, V p_5382, V _a5379, V _a5380, V _a5381, V[] _rest5377) => {
return Arr(((V)(FdLibm.Atan2((ToNum(GetIdx(p_5382, 1D)) - ToNum(GetIdx(C_5365, 1D))), (ToNum(GetIdx(p_5382, 0D)) - ToNum(GetIdx(C_5365, 0D)))))), ((V)(Hypot((ToNum(GetIdx(p_5382, 0D)) - ToNum(GetIdx(C_5365, 0D))), (ToNum(GetIdx(p_5382, 1D)) - ToNum(GetIdx(C_5365, 1D)))))));
}, 1, "", true));
avg_5367 = (ToNum(Invoke(P_5366, "reduce", Fn((V _arrowThis5392, int _argc5384, V a_5390, V q_5391, V _a5388, V _a5389, V[] _rest5385) => {
return Add(a_5390, GetIdx(q_5391, 1D));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(P_5366, "length")));
tips_5368 = Invoke(P_5366, "filter", Fn((V _arrowThis5400, int _argc5393, V q_5399, V _a5396, V _a5397, V _a5398, V[] _rest5394) => {
return (GtN(GetIdx(q_5399, 1D), avg_5367) ? V.True : V.False);
}, 1, "", true));
vals_5369 = Invoke(P_5366, "filter", Fn((V _arrowThis5408, int _argc5401, V q_5407, V _a5404, V _a5405, V _a5406, V[] _rest5402) => {
return (LeN(GetIdx(q_5407, 1D), avg_5367) ? V.True : V.False);
}, 1, "", true));
rt_5370 = (ToNum(Invoke(tips_5368, "reduce", Fn((V _arrowThis5417, int _argc5409, V a_5415, V q_5416, V _a5413, V _a5414, V[] _rest5410) => {
return Add(a_5415, GetIdx(q_5416, 1D));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(tips_5368, "length")));
rb_5371 = (ToNum(Invoke(vals_5369, "reduce", Fn((V _arrowThis5426, int _argc5418, V a_5424, V q_5425, V _a5422, V _a5423, V[] _rest5419) => {
return Add(a_5424, GetIdx(q_5425, 1D));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(vals_5369, "length")));
n_5372 = Get(tips_5368, "length");
th_5373 = Invoke(tips_5368, "map", Fn((V _arrowThis5434, int _argc5427, V q_5433, V _a5430, V _a5431, V _a5432, V[] _rest5428) => {
return GetIdx(q_5433, 0D);
}, 1, "", true));
list_5374 = Arr();
Invoke(Arr(Arr(((V)(90D)), ((V)(1D)), ((V)(0D))), Arr(((V)(58D)), ((V)(0.8)), ((V)(0.5))), Arr(((V)(28D)), ((V)(0.45)), ((V)(0D)))), "forEach", Fn((V _arrowThis5448, int _argc5435, V _a5437, V _a5438, V _a5439, V _a5440, V[] _rest5436) => {
double m_5449 = 0;
V tq_5443 = default;
V f_5445 = default;
V off_5447 = default;
{ V _t5441 = ListOf(_a5437);
{ V _t5442 = GetIdx(_t5441, 0D);
tq_5443 = _t5442; }
{ V _t5444 = GetIdx(_t5441, 1D);
f_5445 = _t5444; }
{ V _t5446 = GetIdx(_t5441, 2D);
off_5447 = _t5446; }
}
m_5449 = Max(3D, Round((ToNum(n_5372) * ToNum(f_5445))));
{
double k_5450 = 0;
k_5450 = 0D;
while (true) {
if (!((k_5450 < m_5449))) break;
Invoke(list_5374, "push", NewObj(2).Put("th", ((V)((ToNum(tq_5443) * D2R_11)))).Put("t", Add(((V)(((ToNum(Add(((V)(k_5450)), off_5447)) / m_5449) * TAU_12))), (SEqN(f_5445, 1D) ? GetIdx(th_5373, 0D) : ((V)(0D))))).V);
k_5450++;
}
}
return default;
}, 1, "", true));
Invoke(list_5374, "push", NewObj(2).Put("th", ((V)(0D))).Put("t", ((V)(0D))).V);
return NewObj(5).Put("C", C_5365).Put("rt", ((V)(rt_5370))).Put("rb", ((V)(rb_5371))).Put("w", ((V)(((rb_5371 * FdLibm.Sin((System.Math.PI / ToNum(n_5372)))) * 1.05)))).Put("list", list_5374).V;
return default;
}, 0, "", true), V.Undef) : V.Null)).Put("hx", Invoke((Get(D_4897, "headExtra") is var _t5461 && Truthy(_t5461) ? _t5461 : Arr()), "map", Fn((V _arrowThis5460, int _argc5453, V h_5459, V _a5456, V _a5457, V _a5458, V[] _rest5454) => {
return Call(parsePath_21, V.Undef, Get(h_5459, "d"));
}, 1, "", true))).Put("crown", Invoke((Get(D_4897, "crown") is var _t5470 && Truthy(_t5470) ? _t5470 : Arr()), "map", Fn((V _arrowThis5469, int _argc5462, V h_5468, V _a5465, V _a5466, V _a5467, V[] _rest5463) => {
return Call(parsePath_21, V.Undef, Get(h_5468, "d"));
}, 1, "", true))).Put("pup", Invoke((Get(D_4897, "pup") is var _t5479 && Truthy(_t5479) ? _t5479 : Arr()), "map", Fn((V _arrowThis5478, int _argc5471, V h_5477, V _a5474, V _a5475, V _a5476, V[] _rest5472) => {
return Call(parsePath_21, V.Undef, Get(h_5477, "d"));
}, 1, "", true))).Put("nose", (SEq(Get(D_4897, "nose"), V.Null) ? Arr() : CallSpread(ellS_22, V.Undef, new ArrBuilder().Spread((Get(D_4897, "nose") is var _t5480 && Truthy(_t5480) ? _t5480 : Arr(((V)(50D)), ((V)(54D)), ((V)(2.6)), ((V)(1.8))))).Add(((V)(0D))).Add(((V)(8D))).V))).Put("noseHL", (Truthy(Get(D_4897, "noseHL")) ? CallSpread(ellS_22, V.Undef, new ArrBuilder().Spread(Get(D_4897, "noseHL")).Add(((V)(0D))).Add(((V)(6D))).V) : V.Null)).Put("belly", (Truthy(Get(D_4897, "bellyD")) ? Call(parsePath_21, V.Undef, Get(Get(D_4897, "bellyD"), "d")) : (Truthy(Get(D_4897, "belly")) ? Call(ellS_22, V.Undef, GetIdx(Get(D_4897, "belly"), 0D), GetIdx(Get(D_4897, "belly"), 1D), GetIdx(Get(D_4897, "belly"), 2D), GetIdx(Get(D_4897, "belly"), 3D), ((V)(0D)), ((V)(12D))) : V.Null))).Put("collar", (Truthy(Get(D_4897, "collar")) ? Call(parsePath_21, V.Undef, Get(Get(D_4897, "collar"), "d")) : V.Null)).Put("fx", Invoke((Get(D_4897, "faceExtra") is var _t5489 && Truthy(_t5489) ? _t5489 : Arr()), "map", Fn((V _arrowThis5488, int _argc5481, V fe_5487, V _a5484, V _a5485, V _a5486, V[] _rest5482) => {
return Call(parsePath_21, V.Undef, Get(fe_5487, "d"));
}, 1, "", true))).Put("fxBig", Invoke((Get(D_4897, "faceExtra") is var _t5521 && Truthy(_t5521) ? _t5521 : Arr()), "map", Fn((V _arrowThis5497, int _argc5490, V fe_5496, V _a5493, V _a5494, V _a5495, V[] _rest5491) => {
V P_5498 = default;
V hx_5499 = default;
V hy_5500 = default;
V rx_5501 = default;
V ry_5502 = default;
P_5498 = Invoke(Call(parsePath_21, V.Undef, Get(fe_5496, "d")), "flatMap", Fn((V _arrowThis5510, int _argc5503, V g_5509, V _a5506, V _a5507, V _a5508, V[] _rest5504) => {
return (Get(g_5509, "p") is var _t5511 && Truthy(_t5511) ? _t5511 : Arr());
}, 1, "", true));
hx_5499 = GetIdx(Get(D_4897, "head"), 0D);
hy_5500 = GetIdx(Get(D_4897, "head"), 1D);
rx_5501 = GetIdx(Get(D_4897, "head"), 2D);
ry_5502 = (GetIdx(Get(D_4897, "head"), 3D) is var _t5512 && Truthy(_t5512) ? _t5512 : GetIdx(Get(D_4897, "head"), 2D));
return Invoke(P_5498, "some", Fn((V _arrowThis5520, int _argc5513, V p_5519, V _a5516, V _a5517, V _a5518, V[] _rest5514) => {
return (((Pow(((ToNum(GetIdx(p_5519, 0D)) - ToNum(hx_5499)) / ToNum(rx_5501)), 2D) + Pow(((ToNum(GetIdx(p_5519, 1D)) - ToNum(hy_5500)) / ToNum(ry_5502)), 2D)) > 0.8) ? V.True : V.False);
}, 1, "", true));
return default;
}, 1, "", true))).Put("fxC", Invoke((Get(D_4897, "faceExtra") is var _t5558 && Truthy(_t5558) ? _t5558 : Arr()), "map", Fn((V _arrowThis5529, int _argc5522, V fe_5528, V _a5525, V _a5526, V _a5527, V[] _rest5523) => {
V P_5530 = default;
P_5530 = Invoke(Call(parsePath_21, V.Undef, Get(fe_5528, "d")), "flatMap", Fn((V _arrowThis5538, int _argc5531, V g_5537, V _a5534, V _a5535, V _a5536, V[] _rest5532) => {
return (Get(g_5537, "p") is var _t5539 && Truthy(_t5539) ? _t5539 : Arr());
}, 1, "", true));
return Arr(((V)((ToNum(Invoke(P_5530, "reduce", Fn((V _arrowThis5548, int _argc5540, V a_5546, V p_5547, V _a5544, V _a5545, V[] _rest5541) => {
return Add(a_5546, GetIdx(p_5547, 0D));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(P_5530, "length"))))), ((V)((ToNum(Invoke(P_5530, "reduce", Fn((V _arrowThis5557, int _argc5549, V a_5555, V p_5556, V _a5553, V _a5554, V[] _rest5550) => {
return Add(a_5555, GetIdx(p_5556, 1D));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(P_5530, "length"))))));
return default;
}, 1, "", true))).Put("feet", Invoke(Get(D_4897, "feet"), "map", Fn((V _arrowThis5570, int _argc5559, V _a5561, V _a5562, V _a5563, V _a5564, V[] _rest5560) => {
V x_5567 = default;
V y_5569 = default;
{ V _t5565 = ListOf(_a5561);
{ V _t5566 = GetIdx(_t5565, 0D);
x_5567 = _t5566; }
{ V _t5568 = GetIdx(_t5565, 1D);
y_5569 = _t5568; }
}
return NewObj(2).Put("x", x_5567).Put("y", y_5569).V;
}, 1, "", true))).Put("web", (Truthy(Get(D_4897, "web")) ? Call(parsePath_21, V.Undef, Get(Get(D_4897, "web"), "d")) : V.Null)).Put("wing", (Truthy(Get(D_4897, "wing")) ? Call(parsePath_21, V.Undef, Get(Get(D_4897, "wing"), "d")) : V.Null)).Put("wingF", (Truthy((Get(D_4897, "wing") is var _t5571 && !Truthy(_t5571) ? _t5571 : Get(Get(D_4897, "wing"), "f"))) ? Call(parsePath_21, V.Undef, Get(Get(D_4897, "wing"), "f")) : V.Null)).Put("webT", (Truthy((Get(D_4897, "web") is var _t5572 && !Truthy(_t5572) ? _t5572 : Get(Get(D_4897, "web"), "toes"))) ? Call(parsePath_21, V.Undef, Get(Get(D_4897, "web"), "toes")) : V.Null)).Put("ears", Invoke(Get(D_4897, "ears"), "map", Fn((V _arrowThis5580, int _argc5573, V e_5579, V _a5576, V _a5577, V _a5578, V[] _rest5574) => {
double vx_5581 = 0;
double vy_5582 = 0;
double len_5583 = 0;
V q_5584 = default;
vx_5581 = (ToNum(GetIdx(Get(e_5579, "tip"), 0D)) - ToNum(GetIdx(Get(e_5579, "pivot"), 0D)));
vy_5582 = (ToNum(GetIdx(Get(e_5579, "tip"), 1D)) - ToNum(GetIdx(Get(e_5579, "pivot"), 1D)));
len_5583 = Hypot(vx_5581, vy_5582);
q_5584 = Object_assign(NewObj(0).V, e_5579, NewObj(5).Put("o", Call(parsePath_21, V.Undef, Get(e_5579, "d"))).Put("n", (Truthy(Get(e_5579, "inner")) ? Call(parsePath_21, V.Undef, Get(e_5579, "inner")) : V.Null)).Put("ux", ((V)((vx_5581 / len_5583)))).Put("uy", ((V)((vy_5582 / len_5583)))).Put("len", ((V)(len_5583))).V);
Set(q_5584, "S", Call(earSec_31, V.Undef, q_5584, Call(flat_27, V.Undef, Get(q_5584, "o"), ((V)(14D)))));
return q_5584;
return default;
}, 1, "", true))).Put("arms", Invoke(Get(D_4897, "arms"), "map", Fn((V _arrowThis5592, int _argc5585, V a_5591, V _a5588, V _a5589, V _a5590, V[] _rest5586) => {
return Object_assign(NewObj(0).V, a_5591, NewObj(1).Put("s", Call(ellS_22, V.Undef, GetIdx(Get(a_5591, "e"), 0D), GetIdx(Get(a_5591, "e"), 1D), GetIdx(Get(a_5591, "e"), 2D), GetIdx(Get(a_5591, "e"), 3D), GetIdx(Get(a_5591, "e"), 4D), ((V)(8D)))).V);
}, 1, "", true))).Put("tail", (Truthy((Get(D_4897, "tail3") is var _t5663 && !Truthy(_t5663) ? _t5663 : (GtN(Get(Get(D_4897, "tail3"), "length"), 4D) ? V.True : V.False))) ? Call(Fn((V _arrowThis5599, int _argc5593, V _a5595, V _a5596, V _a5597, V _a5598, V[] _rest5594) => {
V Q_5600 = default;
double m_5601 = 0;
double n_5602 = 0;
V cr_5603 = default;
Q_5600 = Get(D_4897, "tail3");
m_5601 = (ToNum(Get(Q_5600, "length")) - 1D);
n_5602 = (m_5601 * 4D);
cr_5603 = Fn((V _arrowThis5615, int _argc5604, V p0_5610, V p1_5611, V p2_5612, V p3_5613, V[] _rest5605) => {
V t_5614 = default;
t_5614 = (_argc5604 > 4 ? _rest5605[0] : V.Undef);
return ((V)((0.5 * ((((2D * ToNum(p1_5611)) + ((ToNum(p2_5612) - ToNum(p0_5610)) * ToNum(t_5614))) + ((((((2D * ToNum(p0_5610)) - (5D * ToNum(p1_5611))) + (4D * ToNum(p2_5612))) - ToNum(p3_5613)) * ToNum(t_5614)) * ToNum(t_5614))) + (((ToNum(Add(((V)((((3D * ToNum(p1_5611)) - ToNum(p0_5610)) - (3D * ToNum(p2_5612))))), p3_5613)) * ToNum(t_5614)) * ToNum(t_5614)) * ToNum(t_5614))))));
}, 5, "", true);
return Array_from(NewObj(1).Put("length", ((V)((n_5602 + 1D)))).V, Fn((V _arrowThis5624, int _argc5616, V __5622, V i_5623, V _a5620, V _a5621, V[] _rest5617) => {
double u_5625 = 0;
double j_5626 = 0;
double t_5627 = 0;
V A_5628 = default;
V B_5629 = default;
V C_5630 = default;
V E2_5631 = default;
u_5625 = Min((ToNum(i_5623) / 4D), (m_5601 - 0.000001));
j_5626 = System.Math.Floor(u_5625);
t_5627 = (u_5625 - j_5626);
A_5628 = GetIdx(Q_5600, Max(0D, (j_5626 - 1D)));
B_5629 = GetIdx(Q_5600, j_5626);
C_5630 = GetIdx(Q_5600, (j_5626 + 1D));
E2_5631 = GetIdx(Q_5600, Min(m_5601, (j_5626 + 2D)));
return Arr(Call(cr_5603, V.Undef, GetIdx(A_5628, 0D), GetIdx(B_5629, 0D), GetIdx(C_5630, 0D), GetIdx(E2_5631, 0D), ((V)(t_5627))), Call(cr_5603, V.Undef, GetIdx(A_5628, 1D), GetIdx(B_5629, 1D), GetIdx(C_5630, 1D), GetIdx(E2_5631, 1D), ((V)(t_5627))), ((V)((ToNum(i_5623) / n_5602))), Call(cr_5603, V.Undef, GetIdx(A_5628, 2D), GetIdx(B_5629, 2D), GetIdx(C_5630, 2D), GetIdx(E2_5631, 2D), ((V)(t_5627))));
return default;
}, 2, "", true));
return default;
}, 0, "", true), V.Undef) : (Truthy(Get(D_4897, "tail3")) ? Array_from(NewObj(1).Put("length", ((V)(16D))).V, Fn((V _arrowThis5640, int _argc5632, V __5638, V i_5639, V _a5636, V _a5637, V[] _rest5633) => {
double s_5641 = 0;
V a_5642 = default;
V b_5643 = default;
V c_5644 = default;
V d_5645 = default;
s_5641 = (ToNum(i_5639) / 15D);
{ V _t5646 = Get(D_4897, "tail3");
{ V _t5647 = ListOf(_t5646);
{ V _t5648 = GetIdx(_t5647, 0D);
a_5642 = _t5648; }
{ V _t5649 = GetIdx(_t5647, 1D);
b_5643 = _t5649; }
{ V _t5650 = GetIdx(_t5647, 2D);
c_5644 = _t5650; }
{ V _t5651 = GetIdx(_t5647, 3D);
d_5645 = _t5651; }
} }
return Arr(Call(cub_4921, V.Undef, GetIdx(a_5642, 0D), GetIdx(b_5643, 0D), GetIdx(c_5644, 0D), GetIdx(d_5645, 0D), ((V)(s_5641))), Call(cub_4921, V.Undef, GetIdx(a_5642, 1D), GetIdx(b_5643, 1D), GetIdx(c_5644, 1D), GetIdx(d_5645, 1D), ((V)(s_5641))), ((V)(s_5641)), Call(cub_4921, V.Undef, GetIdx(a_5642, 2D), GetIdx(b_5643, 2D), GetIdx(c_5644, 2D), GetIdx(d_5645, 2D), ((V)(s_5641))));
return default;
}, 2, "", true)) : Array_from(NewObj(1).Put("length", ((V)(14D))).V, Fn((V _arrowThis5660, int _argc5652, V __5658, V i_5659, V _a5656, V _a5657, V[] _rest5653) => {
double s_5661 = 0;
double ins_5662 = 0;
s_5661 = (ToNum(i_5659) / 13D);
ins_5662 = ((1D - ToNum(Call(SM_16, V.Undef, ((V)((s_5661 / 0.18)))))) * 3.2);
return Arr(((V)((ToNum(Call(cub_4921, V.Undef, GetIdx(t0_4917, 0D), GetIdx(t1_4918, 0D), GetIdx(t2_4919, 0D), GetIdx(t3_4920, 0D), ((V)(s_5661)))) - ins_5662))), Add(Call(cub_4921, V.Undef, GetIdx(t0_4917, 1D), GetIdx(t1_4918, 1D), GetIdx(t2_4919, 1D), GetIdx(t3_4920, 1D), ((V)(s_5661))), ((V)((ins_5662 * 0.25)))), ((V)(s_5661)), ((V)(((-9D) - (9D * Pow(s_5661, 0.9))))));
return default;
}, 2, "", true))))).Put("stripes", Call(parsePath_21, V.Undef, Get(D_4897, "stripes"))).Put("back", Call(parsePath_21, V.Undef, Get(D_4897, "back"))).Put("wh", Invoke(Get(D_4897, "whiskers"), "map", parsePath_21)).Put("tufts", Invoke((Get(D_4897, "tufts") is var _t5672 && Truthy(_t5672) ? _t5672 : Arr()), "map", Fn((V _arrowThis5671, int _argc5664, V t_5670, V _a5667, V _a5668, V _a5669, V[] _rest5665) => {
return Call(parsePath_21, V.Undef, Get(t_5670, "d"));
}, 1, "", true))).Put("crest", Invoke((Get(D_4897, "crest") is var _t5681 && Truthy(_t5681) ? _t5681 : Arr()), "map", Fn((V _arrowThis5680, int _argc5673, V c_5679, V _a5676, V _a5677, V _a5678, V[] _rest5674) => {
return Call(parsePath_21, V.Undef, Get(c_5679, "d"));
}, 1, "", true))).V);
if (Truthy(((Get(D_4897, "mane") is var _t5682 && !Truthy(_t5682) ? _t5682 : Get(Get(D_4897, "mane"), "hog")) is var _t5683 && !Truthy(_t5683) ? _t5683 : Get(Get(Get(D_4897, "mane"), "hog"), "coat")))) {
V K_5684 = default;
V CT_5685 = default;
V HF_5686 = default;
V sa_5687 = default;
V pool_5688 = default;
V mB_5689 = default;
V back_5690 = default;
V mBF_5691 = default;
V bodyF_5692 = default;
V mHF_5693 = default;
V headF_5694 = default;
K_5684 = Set(Get(I_4900, "RG"), "coat", Call(coatBuild_63, V.Undef, D_4897));
CT_5685 = Get(Get(Get(D_4897, "mane"), "hog"), "coat");
HF_5686 = ((V)(JsStrBuf.Begin().S("url(#hg").V(u_4898).S(")").End()));
sa_5687 = NewObj(5).Put("fill", HF_5686).Put("stroke", ((Get(CT_5685, "stroke") is var _t5695 && Truthy(_t5695) ? _t5695 : Get(Get(D_4897, "mane"), "stroke")) is var _t5696 && Truthy(_t5696) ? _t5696 : ((V)("none")))).Put("stroke-width", (!Get(CT_5685, "sw").IsNullish ? Get(CT_5685, "sw") : (Get(Get(D_4897, "mane"), "sw") is var _t5697 && Truthy(_t5697) ? _t5697 : ((V)(0D))))).Put("stroke-linejoin", ((V)("round"))).Put("stroke-linecap", ((V)("round"))).V;
pool_5688 = Fn((V _arrowThis5706, int _argc5698, V par_5704, V n_5705, V _a5702, V _a5703, V[] _rest5699) => {
return Array_from(NewObj(1).Put("length", n_5705).V, Fn((V _arrowThis5713, int _argc5707, V _a5709, V _a5710, V _a5711, V _a5712, V[] _rest5708) => {
V g_5714 = default;
g_5714 = Call(mk_32, V.Undef, ((V)("g")), NewObj(0).V, par_5704);
Call(mk_32, V.Undef, ((V)("path")), sa_5687, g_5714);
Call(mk_32, V.Undef, ((V)("path")), NewObj(2).Put("fill", (Get(CT_5685, "tip") is var _t5715 && Truthy(_t5715) ? _t5715 : ((V)("#f3e2c4")))).Put("stroke", ((V)("none"))).V, g_5714);
return g_5714;
return default;
}, 0, "", true));
}, 2, "", true);
Set(Get(Get(E_4914, "mane"), "style"), "display", ((V)("none")));
mB_5689 = Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", HF_5686).V, Get(pg_4913, "mane"));
back_5690 = Call(pool_5688, V.Undef, Get(pg_4913, "mane"), Get(Get(K_5684, "sp"), "length"));
mBF_5691 = Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", HF_5686).V, Get(pg_4913, "coatB"));
bodyF_5692 = Call(pool_5688, V.Undef, Get(pg_4913, "coatB"), Get(K_5684, "nB"));
mHF_5693 = Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", HF_5686).V, Get(pg_4913, "maneF"));
headF_5694 = Call(pool_5688, V.Undef, Get(pg_4913, "maneF"), Get(K_5684, "nH"));
Set(E_4914, "coat", NewObj(6).Put("mB", mB_5689).Put("back", back_5690).Put("mBF", mBF_5691).Put("bodyF", bodyF_5692).Put("mHF", mHF_5693).Put("headF", headF_5694).V);
} else {
if (Truthy((Get(D_4897, "mane") is var _t5716 && !Truthy(_t5716) ? _t5716 : Get(Get(D_4897, "mane"), "hog")))) {
V n_5717 = default;
V HF_5718 = default;
V sa_5719 = default;
V pool_5720 = default;
Set(Get(I_4900, "RG"), "hog", Call(hogBuild_64, V.Undef, D_4897));
n_5717 = Get(Get(Get(Get(I_4900, "RG"), "hog"), "sp"), "length");
HF_5718 = ((V)(JsStrBuf.Begin().S("url(#hg").V(u_4898).S(")").End()));
sa_5719 = NewObj(5).Put("fill", HF_5718).Put("stroke", (Get(Get(D_4897, "mane"), "stroke") is var _t5721 && Truthy(_t5721) ? _t5721 : ((V)("none")))).Put("stroke-width", (Get(Get(D_4897, "mane"), "sw") is var _t5722 && Truthy(_t5722) ? _t5722 : ((V)(0D)))).Put("stroke-linejoin", ((V)("round"))).Put("stroke-linecap", ((V)("round"))).V;
pool_5720 = Fn((V _arrowThis5730, int _argc5723, V par_5729, V _a5726, V _a5727, V _a5728, V[] _rest5724) => {
return Array_from(NewObj(1).Put("length", n_5717).V, Fn((V _arrowThis5737, int _argc5731, V _a5733, V _a5734, V _a5735, V _a5736, V[] _rest5732) => {
return Call(mk_32, V.Undef, ((V)("path")), sa_5719, par_5729);
}, 0, "", true));
}, 1, "", true);
Set(Get(Get(E_4914, "mane"), "style"), "display", ((V)("none")));
Set(E_4914, "hog", NewObj(5).Put("pre", Call(pool_5720, V.Undef, Get(pg_4913, "mane"))).Put("domeB", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", HF_5718).V, Get(pg_4913, "mane"))).Put("post", Call(pool_5720, V.Undef, Get(pg_4913, "mane"))).Put("domeF", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", HF_5718).V, Get(pg_4913, "maneF"))).Put("fs", Call(pool_5720, V.Undef, Get(pg_4913, "maneF"))).V);
}
}
}
loc_4903 = Fn((V _arrowThis5745, int _argc5738, V e_5744, V _a5741, V _a5742, V _a5743, V[] _rest5739) => {
V r_5746 = default;
r_5746 = Invoke(wrap_4901, "getBoundingClientRect");
return NewObj(3).Put("r", r_5746).Put("x", ((V)((((ToNum(Get(e_5744, "clientX")) - ToNum(Get(r_5746, "left"))) / ToNum(Get(r_5746, "width"))) * 100D)))).Put("y", ((V)((((ToNum(Get(e_5744, "clientY")) - ToNum(Get(r_5746, "top"))) / ToNum(Get(r_5746, "height"))) * 100D)))).V;
return default;
}, 1, "", true);
Invoke(wrap_4901, "addEventListener", ((V)("pointermove")), Fn((V _arrowThis5754, int _argc5747, V e_5753, V _a5750, V _a5751, V _a5752, V[] _rest5748) => {
V p_5755 = default;
p_5755 = Call(loc_4903, V.Undef, e_5753);
Set(I_4900, "ptr", NewObj(2).Put("x", Call(clamp_13, V.Undef, ((V)(((ToNum(Get(p_5755, "x")) - 50D) / 42D))), ((V)((-1D))), ((V)(1D)))).Put("y", Call(clamp_13, V.Undef, ((V)(((ToNum(Get(p_5755, "y")) - 46D) / 42D))), ((V)((-1D))), ((V)(1D)))).V);
if (Truthy(Get(I_4900, "down"))) {
double dx_5756 = 0;
dx_5756 = (ToNum(Get(e_5753, "clientX")) - ToNum(Get(Get(I_4900, "down"), "cx")));
if (((!(Truthy(Get(I_4900, "drag"))) && !(Truthy(Get(I_4900, "press")))) && (System.Math.Abs(dx_5756) > 10D))) {
Set(I_4900, "drag", (true ? V.True : V.False));
Call(G("clearTimeout"), V.Undef, Get(I_4900, "ht"));
Set(I_4900, "spinTw", V.Null);
Set(I_4900, "spin0", Get(I_4900, "spinOff"));
}
if (Truthy(Get(I_4900, "drag"))) {
Set(I_4900, "spinOff", Add(Get(I_4900, "spin0"), ((V)(((dx_5756 / ToNum(Get(Get(p_5755, "r"), "width"))) * 360D)))));
}
}
return default;
}, 1, "", true));
Invoke(wrap_4901, "addEventListener", ((V)("pointerleave")), Fn((V _arrowThis5763, int _argc5757, V _a5759, V _a5760, V _a5761, V _a5762, V[] _rest5758) => {
Set(I_4900, "ptr", V.Null);
return default;
}, 0, "", true));
Invoke(wrap_4901, "addEventListener", ((V)("pointerdown")), Fn((V _arrowThis5771, int _argc5764, V e_5770, V _a5767, V _a5768, V _a5769, V[] _rest5765) => {
V p_5772 = default;
V n_5773 = default;
try {
Invoke(wrap_4901, "setPointerCapture", Get(e_5770, "pointerId"));
} catch (System.Exception _ex5774) {
V x_5775 = default;
x_5775 = Caught(_ex5774);

}
p_5772 = Call(loc_4903, V.Undef, e_5770);
n_5773 = Invoke(G("performance"), "now");
if (!SEqS(Get(Get(I_4900, "cur"), "name"), "idle")) {
Call(setState_45, V.Undef, I_4900, ((V)("idle")), n_5773);
}
Set(I_4900, "down", NewObj(3).Put("cx", Get(e_5770, "clientX")).Put("x", Get(p_5772, "x")).Put("y", Get(p_5772, "y")).V);
Set(I_4900, "drag", (false ? V.True : V.False));
Call(G("clearTimeout"), V.Undef, Get(I_4900, "ht"));
Set(I_4900, "ht", Call(G("setTimeout"), V.Undef, Fn((V _arrowThis5790, int _argc5784, V _a5786, V _a5787, V _a5788, V _a5789, V[] _rest5785) => {
if (Truthy((Get(I_4900, "down") is var _t5791 && !Truthy(_t5791) ? _t5791 : (!(Truthy(Get(I_4900, "drag"))) ? V.True : V.False)))) {
Set(I_4900, "press", (true ? V.True : V.False));
Set(I_4900, "pressT", Invoke(G("performance"), "now"));
}
return default;
}, 0, "", true), ((V)(170D))));
return default;
}, 1, "", true));
up_4904 = Fn((V _arrowThis5798, int _argc5792, V _a5794, V _a5795, V _a5796, V _a5797, V[] _rest5793) => {
V n_5799 = default;
if (!(Truthy(Get(I_4900, "down")))) {
return default;
}
Call(G("clearTimeout"), V.Undef, Get(I_4900, "ht"));
n_5799 = Invoke(G("performance"), "now");
if (Truthy(Get(I_4900, "drag"))) {
Set(I_4900, "spinTw", NewObj(4).Put("from", Get(I_4900, "spinOff")).Put("to", ((V)((Round((ToNum(Get(I_4900, "spinOff")) / 360D)) * 360D)))).Put("t0", n_5799).Put("d", ((V)(650D))).V);
} else {
if (Truthy(Get(I_4900, "press"))) {
V RS_5800 = default;
Set(I_4900, "press", (false ? V.True : V.False));
RS_5800 = ((Get(I_4900, "key") is var _t5801 && !Truthy(_t5801) ? _t5801 : GetK(REL_99, Get(I_4900, "key"))) is var _t5802 && Truthy(_t5802) ? _t5802 : RELEASE_39);
Invoke(Get(I_4900, "shots"), "push", NewObj(2).Put("S", RS_5800).Put("t0", n_5799).V);
Invoke((Get(RS_5800, "em") is var _t5811 && Truthy(_t5811) ? _t5811 : Arr()), "forEach", Fn((V _arrowThis5810, int _argc5803, V m_5809, V _a5806, V _a5807, V _a5808, V[] _rest5804) => {
return Call(emit_51, V.Undef, I_4900, GetIdx(m_5809, 0D), GetIdx(m_5809, 1D), GetIdx(m_5809, 2D));
}, 1, "", true));
}
}
Set(I_4900, "down", V.Null);
Set(I_4900, "drag", (false ? V.True : V.False));
return default;
}, 0, "", true);
Invoke(wrap_4901, "addEventListener", ((V)("pointerup")), up_4904);
Invoke(wrap_4901, "addEventListener", ((V)("pointercancel")), up_4904);
Invoke(ALL_65, "add", I_4900);
Call(applyLook_86, V.Undef, I_4900);
Call(kick_70, V.Undef);
Call(tick_59, V.Undef, I_4900, now_4899, ((V)(0.016)));
return Set(Get(G("window"), "RiveRig"), "_last", NewObj(7).Put("play", Fn((V _arrowThis5819, int _argc5812, V n_5818, V _a5815, V _a5816, V _a5817, V[] _rest5813) => {
return Call(setState_45, V.Undef, I_4900, n_5818, Invoke(G("performance"), "now"));
}, 1, "play", true)).Put("ext", Fn((V _arrowThis5827, int _argc5820, V o_5826, V _a5823, V _a5824, V _a5825, V[] _rest5821) => {
Set(I_4900, "ext", o_5826);
return default;
}, 1, "ext", true)).Put("light", Fn((V _arrowThis5835, int _argc5828, V L_5834, V _a5831, V _a5832, V _a5833, V[] _rest5829) => {
Set(I_4900, "sceneL", (L_5834 is var _t5836 && Truthy(_t5836) ? _t5836 : V.Null));
Call(applyLook_86, V.Undef, I_4900);
Call(tick_59, V.Undef, I_4900, Invoke(G("performance"), "now"), ((V)(0.016)));
return default;
}, 1, "light", true)).Put("destroy", Fn((V _arrowThis5843, int _argc5837, V _a5839, V _a5840, V _a5841, V _a5842, V[] _rest5838) => {
Invoke(ALL_65, "delete", I_4900);
Call(G("clearTimeout"), V.Undef, Get(I_4900, "ht"));
Set(host_4893, "innerHTML", ((V)("")));
return default;
}, 0, "destroy", true)).Put("_pose", Fn((V _arrowThis5852, int _argc5844, V name_5850, V t_5851, V _a5848, V _a5849, V[] _rest5845) => {
V n_5853 = default;
n_5853 = Invoke(G("performance"), "now");
Set(I_4900, "cur", NewObj(2).Put("name", name_5850).Put("t0", ((V)((ToNum(n_5853) - ToNum(t_5851))))).V);
Set(I_4900, "prev", V.Null);
Set(I_4900, "shots", Arr());
Set(Get(I_4900, "flw"), "v", ((V)(0D)));
Call(tick_59, V.Undef, I_4900, n_5853, ((V)(0.016)));
return default;
}, 2, "_pose", true)).Getter("state", Fn((V _self5854, int _argc5855, V _a5857, V _a5858, V _a5859, V _a5860, V[] _rest5856) => {
if (_self5854.IsNullish) _self5854 = GlobalV;
return Get(Get(I_4900, "cur"), "name");
return default;
}, 0, "state", false)).Put("_I", I_4900).V);
return default;
}, 3, "mount", false);
if (Truthy(Get(G("window"), "RiveRig"))) {
return default;
}
FAB_8 = V.Null;
NS_10 = ((V)("http://www.w3.org/2000/svg"));
D2R_11 = (System.Math.PI / 180D);
TAU_12 = (System.Math.PI * 2D);
clamp_13 = Fn((V _arrowThis5870, int _argc5861, V v_5867, V a_5868, V b_5869, V _a5866, V[] _rest5862) => {
return ((V)(Max(ToNum(a_5868), Min(ToNum(b_5869), ToNum(v_5867)))));
}, 3, "", true);
r2_14 = Fn((V _arrowThis5878, int _argc5871, V n_5877, V _a5874, V _a5875, V _a5876, V[] _rest5872) => {
return ((V)((Round((ToNum(n_5877) * 100D)) / 100D)));
}, 1, "", true);
lerp_15 = Fn((V _arrowThis5888, int _argc5879, V a_5885, V b_5886, V t_5887, V _a5884, V[] _rest5880) => {
return Add(a_5885, ((V)(((ToNum(b_5886) - ToNum(a_5885)) * ToNum(t_5887)))));
}, 3, "", true);
SM_16 = Fn((V _arrowThis5896, int _argc5889, V x_5895, V _a5892, V _a5893, V _a5894, V[] _rest5890) => {
x_5895 = Call(clamp_13, V.Undef, x_5895, ((V)(0D)), ((V)(1D)));
return ((V)(((ToNum(x_5895) * ToNum(x_5895)) * (3D - (2D * ToNum(x_5895))))));
return default;
}, 1, "", true);
bez_17 = Fn((V _arrowThis5907, int _argc5897, V x1_5903, V y1_5904, V x2_5905, V y2_5906, V[] _rest5898) => {
double cx_5908 = 0;
double bx_5909 = 0;
double ax_5910 = 0;
double cy_5911 = 0;
double by_5912 = 0;
double ay_5913 = 0;
V X_5914 = default;
V dX_5915 = default;
V Y_5916 = default;
cx_5908 = (3D * ToNum(x1_5903));
bx_5909 = ((3D * (ToNum(x2_5905) - ToNum(x1_5903))) - cx_5908);
ax_5910 = ((1D - cx_5908) - bx_5909);
cy_5911 = (3D * ToNum(y1_5904));
by_5912 = ((3D * (ToNum(y2_5906) - ToNum(y1_5904))) - cy_5911);
ay_5913 = ((1D - cy_5911) - by_5912);
X_5914 = Fn((V _arrowThis5924, int _argc5917, V t_5923, V _a5920, V _a5921, V _a5922, V[] _rest5918) => {
return ((V)((((((ax_5910 * ToNum(t_5923)) + bx_5909) * ToNum(t_5923)) + cx_5908) * ToNum(t_5923))));
}, 1, "", true);
dX_5915 = Fn((V _arrowThis5932, int _argc5925, V t_5931, V _a5928, V _a5929, V _a5930, V[] _rest5926) => {
return ((V)((((((3D * ax_5910) * ToNum(t_5931)) + (2D * bx_5909)) * ToNum(t_5931)) + cx_5908)));
}, 1, "", true);
Y_5916 = Fn((V _arrowThis5940, int _argc5933, V t_5939, V _a5936, V _a5937, V _a5938, V[] _rest5934) => {
return ((V)((((((ay_5913 * ToNum(t_5939)) + by_5912) * ToNum(t_5939)) + cy_5911) * ToNum(t_5939))));
}, 1, "", true);
return Fn((V _arrowThis5948, int _argc5941, V x_5947, V _a5944, V _a5945, V _a5946, V[] _rest5942) => {
V t_5949 = default;
if (LeN(x_5947, 0D)) {
return ((V)(0D));
}
if (GeN(x_5947, 1D)) {
return ((V)(1D));
}
t_5949 = x_5947;
{
double i_5950 = 0;
i_5950 = 0D;
while (true) {
if (!((i_5950 < 8D))) break;
V d_5952 = default;
d_5952 = Call(dX_5915, V.Undef, t_5949);
if ((System.Math.Abs(ToNum(d_5952)) < 0.00001)) {
break;
}
t_5949 = Call(clamp_13, V.Undef, ((V)((ToNum(t_5949) - ((ToNum(Call(X_5914, V.Undef, t_5949)) - ToNum(x_5947)) / ToNum(d_5952))))), ((V)(0D)), ((V)(1D)));
i_5950++;
}
}
return Call(Y_5916, V.Undef, t_5949);
return default;
}, 1, "", true);
return default;
}, 4, "", true);
EZ_18 = NewObj(6).Put("l", Fn((V _arrowThis5960, int _argc5953, V x_5959, V _a5956, V _a5957, V _a5958, V[] _rest5954) => {
return x_5959;
}, 1, "l", true)).Put("io", Call(bez_17, V.Undef, ((V)(0.45)), ((V)(0D)), ((V)(0.55)), ((V)(1D)))).Put("s", Call(bez_17, V.Undef, ((V)(0.37)), ((V)(0D)), ((V)(0.63)), ((V)(1D)))).Put("o", Fn((V _arrowThis5968, int _argc5961, V x_5967, V _a5964, V _a5965, V _a5966, V[] _rest5962) => {
return ((V)((1D - Pow((1D - ToNum(x_5967)), 2.4))));
}, 1, "o", true)).Put("i", Fn((V _arrowThis5976, int _argc5969, V x_5975, V _a5972, V _a5973, V _a5974, V[] _rest5970) => {
return ((V)(Pow(ToNum(x_5975), 2.2)));
}, 1, "i", true)).Put("bk", Call(bez_17, V.Undef, ((V)(0.34)), ((V)(1.45)), ((V)(0.64)), ((V)(1D)))).V;
kv_19 = Fn((V _arrowThis5985, int _argc5977, V K_5983, V t_5984, V _a5981, V _a5982, V[] _rest5978) => {
if (Le(t_5984, GetIdx(GetIdx(K_5983, 0D), 0D))) {
return GetIdx(GetIdx(K_5983, 0D), 1D);
}
{
double i_5986 = 0;
i_5986 = 1D;
while (true) {
if (!(Lt(((V)(i_5986)), Get(K_5983, "length")))) break;
V b_5988 = default;
b_5988 = GetIdx(K_5983, i_5986);
if (Le(t_5984, GetIdx(b_5988, 0D))) {
V a_5989 = default;
a_5989 = GetIdx(K_5983, (i_5986 - 1D));
return Add(GetIdx(a_5989, 1D), ((V)(((ToNum(GetIdx(b_5988, 1D)) - ToNum(GetIdx(a_5989, 1D))) * ToNum(InvokeK(EZ_18, (GetIdx(b_5988, 2D) is var _t5990 && Truthy(_t5990) ? _t5990 : ((V)("io"))), ((V)(((ToNum(t_5984) - ToNum(GetIdx(a_5989, 0D))) / Max(1D, (ToNum(GetIdx(b_5988, 0D)) - ToNum(GetIdx(a_5989, 0D)))))))))))));
}
i_5986++;
}
}
return GetIdx(GetIdx(K_5983, (ToNum(Get(K_5983, "length")) - 1D)), 1D);
return default;
}, 2, "", true);
Fol_20 = ClassOf(Fn((V _self5991, int _argc5992, V v_5998, V w_5999, V z_6000, V _a5997, V[] _rest5993) => {
if (_self5991.IsNullish) _self5991 = GlobalV;
Set(_self5991, "v", (v_5998 is var _t6001 && Truthy(_t6001) ? _t6001 : ((V)(0D))));
Set(_self5991, "d", ((V)(0D)));
Set(_self5991, "w", w_5999);
Set(_self5991, "z", (z_6000.IsNullish ? ((V)(1D)) : z_6000));
return default;
}, 3, "Fol", false)).Method("step", Fn((V _self6002, int _argc6003, V t_6009, V dt_6010, V _a6007, V _a6008, V[] _rest6004) => {
double n_6011 = 0;
double h_6012 = 0;
if (_self6002.IsNullish) _self6002 = GlobalV;
n_6011 = Max(1D, System.Math.Ceiling((ToNum(dt_6010) / 0.006)));
h_6012 = (ToNum(dt_6010) / n_6011);
{
double i_6013 = 0;
i_6013 = 0D;
while (true) {
if (!((i_6013 < n_6011))) break;
OpSet(_self6002, "d", 0, ((V)(((((ToNum(Get(_self6002, "w")) * ToNum(Get(_self6002, "w"))) * (ToNum(t_6009) - ToNum(Get(_self6002, "v")))) - (((2D * ToNum(Get(_self6002, "z"))) * ToNum(Get(_self6002, "w"))) * ToNum(Get(_self6002, "d")))) * h_6012))));
OpSet(_self6002, "v", 0, ((V)((ToNum(Get(_self6002, "d")) * h_6012))));
i_6013++;
}
}
return Get(_self6002, "v");
return default;
}, 2, "step", false)).V;
ellS_22 = Fn((V _arrowThis6027, int _argc6015, V cx_6021, V cy_6022, V rx_6023, V ry_6024, V[] _rest6016) => {
double k_6028 = 0;
double c_6029 = 0;
double s_6030 = 0;
V P_6031 = default;
V @out_6032 = default;
V rot_6025 = default;
V n_6026 = default;
rot_6025 = (_argc6015 > 4 ? _rest6016[0] : V.Undef);
n_6026 = (_argc6015 > 5 ? _rest6016[1] : V.Undef);
n_6026 = (n_6026 is var _t6033 && Truthy(_t6033) ? _t6033 : ((V)(8D)));
k_6028 = ((4D / 3D) * FdLibm.Tan((System.Math.PI / (2D * ToNum(n_6026)))));
c_6029 = FdLibm.Cos((ToNum((rot_6025 is var _t6034 && Truthy(_t6034) ? _t6034 : ((V)(0D)))) * D2R_11));
s_6030 = FdLibm.Sin((ToNum((rot_6025 is var _t6035 && Truthy(_t6035) ? _t6035 : ((V)(0D)))) * D2R_11));
P_6031 = Fn((V _arrowThis6044, int _argc6036, V x_6042, V y_6043, V _a6040, V _a6041, V[] _rest6037) => {
return Arr(((V)((ToNum(Add(cx_6021, ((V)((ToNum(x_6042) * c_6029))))) - (ToNum(y_6043) * s_6030)))), Add(Add(cy_6022, ((V)((ToNum(x_6042) * s_6030)))), ((V)((ToNum(y_6043) * c_6029)))));
}, 2, "", true);
@out_6032 = Arr(NewObj(2).Put("c", ((V)("M"))).Put("p", Arr(Call(P_6031, V.Undef, rx_6023, ((V)(0D))))).V);
{
double i_6045 = 0;
i_6045 = 0D;
while (true) {
if (!(Lt(((V)(i_6045)), n_6026))) break;
double a0_6047 = 0;
double a1_6048 = 0;
double c0_6049 = 0;
double s0_6050 = 0;
double c1_6051 = 0;
double s1_6052 = 0;
a0_6047 = ((i_6045 / ToNum(n_6026)) * TAU_12);
a1_6048 = (((i_6045 + 1D) / ToNum(n_6026)) * TAU_12);
c0_6049 = FdLibm.Cos(a0_6047);
s0_6050 = FdLibm.Sin(a0_6047);
c1_6051 = FdLibm.Cos(a1_6048);
s1_6052 = FdLibm.Sin(a1_6048);
Invoke(@out_6032, "push", NewObj(2).Put("c", ((V)("C"))).Put("p", Arr(Call(P_6031, V.Undef, ((V)((ToNum(rx_6023) * (c0_6049 - (k_6028 * s0_6050))))), ((V)((ToNum(ry_6024) * (s0_6050 + (k_6028 * c0_6049)))))), Call(P_6031, V.Undef, ((V)((ToNum(rx_6023) * (c1_6051 + (k_6028 * s1_6052))))), ((V)((ToNum(ry_6024) * (s1_6052 - (k_6028 * c1_6051)))))), Call(P_6031, V.Undef, ((V)((ToNum(rx_6023) * c1_6051))), ((V)((ToNum(ry_6024) * s1_6052)))))).V);
i_6045++;
}
}
Invoke(@out_6032, "push", NewObj(1).Put("c", ((V)("Z"))).V);
return @out_6032;
return default;
}, 6, "", true);
furRing_23 = Fn((V _arrowThis6061, int _argc6053, V d_6059, V E_6060, V _a6057, V _a6058, V[] _rest6054) => {
V n_6062 = default;
V cx_6063 = default;
V cy_6064 = default;
V rx_6065 = default;
V ry0_6066 = default;
V ry_6067 = default;
V v_6068 = default;
V pol_6069 = default;
V V_6070 = default;
V Pk_6071 = default;
V p0_6072 = default;
V wrap_6073 = default;
V Vs_6074 = default;
V vfn_6075 = default;
V T_6076 = default;
V T2_6077 = default;
n_6062 = Get((Invoke(d_6059, "match", NewRegExp(RX8, "Q", "g")) is var _t6078 && Truthy(_t6078) ? _t6078 : Arr()), "length");
if (Truthy(((LtN(n_6062, 8D) ? V.True : V.False) is var _t6079 && Truthy(_t6079) ? _t6079 : Invoke(NewRegExp(RX10, "[CLAHVS]", "i"), "test", Invoke(d_6059, "replace", NewRegExp(RX9, "[MQZ]", "g"), ((V)(""))))))) {
return V.Null;
}
{ V _t6080 = E_6060;
{ V _t6081 = ListOf(_t6080);
{ V _t6082 = GetIdx(_t6081, 0D);
cx_6063 = _t6082; }
{ V _t6083 = GetIdx(_t6081, 1D);
cy_6064 = _t6083; }
{ V _t6084 = GetIdx(_t6081, 2D);
rx_6065 = _t6084; }
{ V _t6085 = GetIdx(_t6081, 3D);
ry0_6066 = _t6085; }
} }
ry_6067 = (ry0_6066 is var _t6086 && Truthy(_t6086) ? _t6086 : rx_6065);
v_6068 = Invoke((Invoke(d_6059, "match", NewRegExp(RX11, "-?\\d+\\.?\\d*", "g")) is var _t6087 && Truthy(_t6087) ? _t6087 : Arr()), "map", G("Number"));
pol_6069 = Fn((V _arrowThis6096, int _argc6088, V x_6094, V y_6095, V _a6092, V _a6093, V[] _rest6089) => {
return Arr(((V)(FdLibm.Atan2(((ToNum(x_6094) - ToNum(cx_6063)) / ToNum(rx_6065)), ((-(ToNum(y_6095) - ToNum(cy_6064))) / ToNum(ry_6067))))), ((V)(Hypot(((ToNum(x_6094) - ToNum(cx_6063)) / ToNum(rx_6065)), ((ToNum(y_6095) - ToNum(cy_6064)) / ToNum(ry_6067))))));
}, 2, "", true);
V_6070 = Arr();
Pk_6071 = Arr();
p0_6072 = Arr(GetIdx(v_6068, 0D), GetIdx(v_6068, 1D));
{
double k_6097 = 0;
k_6097 = 2D;
while (true) {
if (!(Lt(((V)((k_6097 + 3D))), Get(v_6068, "length")))) break;
V c_6099 = default;
V p1_6100 = default;
V best_6101 = default;
c_6099 = Arr(GetIdx(v_6068, k_6097), GetIdx(v_6068, (k_6097 + 1D)));
p1_6100 = Arr(GetIdx(v_6068, (k_6097 + 2D)), GetIdx(v_6068, (k_6097 + 3D)));
Invoke(V_6070, "push", Call(pol_6069, V.Undef, GetIdx(p0_6072, 0D), GetIdx(p0_6072, 1D)));
best_6101 = V.Null;
{
double i_6102 = 0;
i_6102 = 1D;
while (true) {
if (!((i_6102 < 20D))) break;
double t_6104 = 0;
double u_6105 = 0;
V q_6106 = default;
t_6104 = (i_6102 / 20D);
u_6105 = (1D - t_6104);
q_6106 = Call(pol_6069, V.Undef, ((V)(((((u_6105 * u_6105) * ToNum(GetIdx(p0_6072, 0D))) + (((2D * u_6105) * t_6104) * ToNum(GetIdx(c_6099, 0D)))) + ((t_6104 * t_6104) * ToNum(GetIdx(p1_6100, 0D)))))), ((V)(((((u_6105 * u_6105) * ToNum(GetIdx(p0_6072, 1D))) + (((2D * u_6105) * t_6104) * ToNum(GetIdx(c_6099, 1D)))) + ((t_6104 * t_6104) * ToNum(GetIdx(p1_6100, 1D)))))));
if ((!(Truthy(best_6101)) || Gt(GetIdx(q_6106, 1D), GetIdx(best_6101, 1D)))) {
best_6101 = q_6106;
}
i_6102++;
}
}
Invoke(Pk_6071, "push", best_6101);
p0_6072 = p1_6100;
k_6097 = (k_6097 + 4D);
}
}
wrap_6073 = Fn((V _arrowThis6114, int _argc6107, V a_6113, V _a6110, V _a6111, V _a6112, V[] _rest6108) => {
return ((V)(FdLibm.Atan2(FdLibm.Sin(ToNum(a_6113)), FdLibm.Cos(ToNum(a_6113)))));
}, 1, "", true);
Vs_6074 = Invoke(Invoke(V_6070, "slice"), "sort", Fn((V _arrowThis6123, int _argc6115, V a_6121, V b_6122, V _a6119, V _a6120, V[] _rest6116) => {
return ((V)((ToNum(GetIdx(a_6121, 0D)) - ToNum(GetIdx(b_6122, 0D)))));
}, 2, "", true));
vfn_6075 = Fn((V _arrowThis6131, int _argc6124, V th_6130, V _a6127, V _a6128, V _a6129, V[] _rest6125) => {
th_6130 = Call(wrap_6073, V.Undef, th_6130);
{
double i_6132 = 0;
i_6132 = 0D;
while (true) {
if (!(Lt(((V)(i_6132)), Get(Vs_6074, "length")))) break;
V a_6134 = default;
V b_6135 = default;
V span_6136 = default;
V o_6137 = default;
a_6134 = GetIdx(Vs_6074, i_6132);
b_6135 = GetIdx(Vs_6074, ((i_6132 + 1D) % ToNum(Get(Vs_6074, "length"))));
span_6136 = Call(wrap_6073, V.Undef, ((V)((ToNum(GetIdx(b_6135, 0D)) - ToNum(GetIdx(a_6134, 0D))))));
if (LeN(span_6136, 0D)) {
span_6136 = Add(span_6136, ((V)(TAU_12)));
}
o_6137 = Call(wrap_6073, V.Undef, ((V)((ToNum(th_6130) - ToNum(GetIdx(a_6134, 0D))))));
if (LtN(o_6137, 0D)) {
o_6137 = Add(o_6137, ((V)(TAU_12)));
}
if (Le(o_6137, span_6136)) {
return Add(GetIdx(a_6134, 1D), ((V)((((ToNum(GetIdx(b_6135, 1D)) - ToNum(GetIdx(a_6134, 1D))) * ToNum(o_6137)) / ToNum(span_6136)))));
}
i_6132++;
}
}
return GetIdx(GetIdx(Vs_6074, 0D), 1D);
return default;
}, 1, "", true);
T_6076 = Invoke(Pk_6071, "map", Fn((V _arrowThis6146, int _argc6138, V q_6144, V i_6145, V _a6142, V _a6143, V[] _rest6139) => {
V pv_6147 = default;
V nx_6148 = default;
double dl_6149 = 0;
double vv_6150 = 0;
double lo_6151 = 0;
V hi_6152 = default;
double r_6153 = 0;
pv_6147 = GetIdx(Pk_6071, (ToNum(Add(((V)((ToNum(i_6145) - 1D))), n_6062)) % ToNum(n_6062)));
nx_6148 = GetIdx(Pk_6071, (ToNum(Add(i_6145, ((V)(1D)))) % ToNum(n_6062)));
dl_6149 = ((System.Math.Abs(ToNum(Call(wrap_6073, V.Undef, ((V)((ToNum(GetIdx(q_6144, 0D)) - ToNum(GetIdx(pv_6147, 0D)))))))) + System.Math.Abs(ToNum(Call(wrap_6073, V.Undef, ((V)((ToNum(GetIdx(nx_6148, 0D)) - ToNum(GetIdx(q_6144, 0D))))))))) / 4D);
vv_6150 = (ToNum(Add(Call(vfn_6075, V.Undef, ((V)((ToNum(GetIdx(q_6144, 0D)) - dl_6149)))), Call(vfn_6075, V.Undef, Add(GetIdx(q_6144, 0D), ((V)(dl_6149)))))) / 2D);
lo_6151 = 0.001;
hi_6152 = GetIdx(q_6144, 1D);
{
double it_6154 = 0;
it_6154 = 0D;
while (true) {
if (!((it_6154 < 40D))) break;
double r_6156 = 0;
double D0_6157 = 0;
double f_6158 = 0;
r_6156 = (ToNum(Add(((V)(lo_6151)), hi_6152)) / 2D);
D0_6157 = (ToNum(GetIdx(q_6144, 1D)) - r_6156);
f_6158 = (((D0_6157 * FdLibm.Cos(dl_6149)) + System.Math.Sqrt(Max(0D, ((r_6156 * r_6156) - (((D0_6157 * D0_6157) * FdLibm.Sin(dl_6149)) * FdLibm.Sin(dl_6149)))))) - vv_6150);
if ((f_6158 > 0D)) {
hi_6152 = ((V)(r_6156));
} else {
lo_6151 = r_6156;
}
it_6154++;
}
}
r_6153 = (ToNum(Add(((V)(lo_6151)), hi_6152)) / 2D);
return NewObj(3).Put("th", GetIdx(q_6144, 0D)).Put("D", ((V)((ToNum(GetIdx(q_6144, 1D)) - r_6153)))).Put("r", ((V)(r_6153))).V;
return default;
}, 2, "", true));
T2_6077 = Invoke(T_6076, "map", Fn((V _arrowThis6167, int _argc6159, V t_6165, V i_6166, V _a6163, V _a6164, V[] _rest6160) => {
V u_6168 = default;
u_6168 = GetIdx(T_6076, (ToNum(Add(i_6166, ((V)(1D)))) % ToNum(n_6062)));
return NewObj(3).Put("th", Add(Get(t_6165, "th"), ((V)((ToNum(Call(wrap_6073, V.Undef, ((V)((ToNum(Get(u_6168, "th")) - ToNum(Get(t_6165, "th"))))))) / 2D))))).Put("D", ((V)((ToNum(Add(Get(t_6165, "D"), Get(u_6168, "D"))) / 2D)))).Put("r", ((V)((ToNum(Add(Get(t_6165, "r"), Get(u_6168, "r"))) / 2D)))).V;
return default;
}, 2, "", true));
return NewObj(7).Put("R", Arr(Arr(((V)((System.Math.PI / 2D))), T_6076), Arr(((V)(0D)), T_6076), Arr(((V)((System.Math.PI / 4D))), T2_6077), Arr(((V)(((3D * System.Math.PI) / 4D))), T2_6077))).Put("cx", cx_6063).Put("cy", cy_6064).Put("rx", rx_6065).Put("ry", ry_6067).Put("vfn", vfn_6075).Put("n", n_6062).V;
return default;
}, 2, "", true);
furPts_24 = Fn((V _arrowThis6177, int _argc6169, V F_6175, V yaw_6176, V _a6173, V _a6174, V[] _rest6170) => {
double M_6178 = 0;
V @out_6179 = default;
V C_6180 = default;
M_6178 = 168D;
@out_6179 = Arr();
C_6180 = Arr();
Invoke(Get(F_6175, "R"), "forEach", Fn((V _arrowThis6192, int _argc6181, V _a6183, V _a6184, V _a6185, V _a6186, V[] _rest6182) => {
double xs_6193 = 0;
V l0_6189 = default;
V T_6191 = default;
{ V _t6187 = ListOf(_a6183);
{ V _t6188 = GetIdx(_t6187, 0D);
l0_6189 = _t6188; }
{ V _t6190 = GetIdx(_t6187, 1D);
T_6191 = _t6190; }
}
xs_6193 = FdLibm.Sin(ToNum(Add(l0_6189, yaw_6176)));
Invoke(T_6191, "forEach", Fn((V _arrowThis6201, int _argc6194, V t_6200, V _a6197, V _a6198, V _a6199, V[] _rest6195) => {
double x_6202 = 0;
double y_6203 = 0;
x_6202 = ((FdLibm.Sin(ToNum(Get(t_6200, "th"))) * ToNum(Get(t_6200, "D"))) * xs_6193);
y_6203 = (FdLibm.Cos(ToNum(Get(t_6200, "th"))) * ToNum(Get(t_6200, "D")));
Invoke(C_6180, "push", NewObj(3).Put("s", ((V)(Hypot(x_6202, y_6203)))).Put("ph", ((V)(FdLibm.Atan2(x_6202, y_6203)))).Put("r", Get(t_6200, "r")).V);
return default;
}, 1, "", true));
return default;
}, 1, "", true));
{
double i_6204 = 0;
i_6204 = 0D;
while (true) {
if (!((i_6204 < M_6178))) break;
double th_6206 = 0;
double rho_6207 = 0;
th_6206 = ((i_6204 / M_6178) * TAU_12);
rho_6207 = (ToNum(Invoke(F_6175, "vfn", ((V)(th_6206)))) * 0.995);
{
foreach (V _k6208 in new JsIter(C_6180)) {
V q_6209 = default;
q_6209 = _k6208;
double dl_6210 = 0;
double sn_6211 = 0;
dl_6210 = (th_6206 - ToNum(Get(q_6209, "ph")));
sn_6211 = (ToNum(Get(q_6209, "s")) * FdLibm.Sin(dl_6210));
if ((Lt(((V)(System.Math.Abs(sn_6211))), Get(q_6209, "r")) && (FdLibm.Cos(dl_6210) > 0D))) {
double e_6212 = 0;
e_6212 = ((ToNum(Get(q_6209, "s")) * FdLibm.Cos(dl_6210)) + System.Math.Sqrt(((ToNum(Get(q_6209, "r")) * ToNum(Get(q_6209, "r"))) - (sn_6211 * sn_6211))));
if ((e_6212 > rho_6207)) {
rho_6207 = e_6212;
}
}
}
}
Invoke(@out_6179, "push", Arr(Add(Get(F_6175, "cx"), ((V)(((ToNum(Get(F_6175, "rx")) * rho_6207) * FdLibm.Sin(th_6206))))), ((V)((ToNum(Get(F_6175, "cy")) - ((ToNum(Get(F_6175, "ry")) * rho_6207) * FdLibm.Cos(th_6206)))))));
i_6204++;
}
}
return @out_6179;
return default;
}, 2, "", true);
toD_25 = Fn((V _arrowThis6221, int _argc6213, V segs_6219, V F_6220, V _a6217, V _a6218, V[] _rest6214) => {
JsStrBuf s_6222 = null;
s_6222 = new JsStrBuf("");
{
foreach (V _k6223 in new JsIter(segs_6219)) {
V g_6224 = default;
g_6224 = _k6223;
if (SEqS(Get(g_6224, "c"), "Z")) {
s_6222.S("Z");
continue;
}
s_6222.V(Get(g_6224, "c"));
{
foreach (V _k6225 in new JsIter(Get(g_6224, "p"))) {
V p_6226 = default;
p_6226 = _k6225;
V q_6227 = default;
q_6227 = Call(F_6220, V.Undef, GetIdx(p_6226, 0D), GetIdx(p_6226, 1D));
s_6222.V(Call(r2_14, V.Undef, GetIdx(q_6227, 0D))).S(" ").V(Call(r2_14, V.Undef, GetIdx(q_6227, 1D))).S(" ");
}
}
}
}
return ((V)(s_6222.Str));
return default;
}, 2, "", true);
smoothD_26 = Fn((V _arrowThis6235, int _argc6228, V P_6234, V _a6231, V _a6232, V _a6233, V[] _rest6229) => {
JsStrBuf s_6236 = null;
s_6236 = new JsStrBuf(JsStrBuf.Begin().S("M").V(Call(r2_14, V.Undef, GetIdx(GetIdx(P_6234, 0D), 0D))).S(" ").V(Call(r2_14, V.Undef, GetIdx(GetIdx(P_6234, 0D), 1D))).End());
{
double i_6237 = 0;
i_6237 = 0D;
while (true) {
if (!((i_6237 < (ToNum(Get(P_6234, "length")) - 1D)))) break;
V p0_6239 = default;
V p1_6240 = default;
V p2_6241 = default;
V p3_6242 = default;
p0_6239 = (GetIdx(P_6234, (i_6237 - 1D)) is var _t6243 && Truthy(_t6243) ? _t6243 : GetIdx(P_6234, i_6237));
p1_6240 = GetIdx(P_6234, i_6237);
p2_6241 = GetIdx(P_6234, (i_6237 + 1D));
p3_6242 = (GetIdx(P_6234, (i_6237 + 2D)) is var _t6244 && Truthy(_t6244) ? _t6244 : p2_6241);
s_6236.S(" C").V(Call(r2_14, V.Undef, Add(GetIdx(p1_6240, 0D), ((V)(((ToNum(GetIdx(p2_6241, 0D)) - ToNum(GetIdx(p0_6239, 0D))) / 6D)))))).S(" ").V(Call(r2_14, V.Undef, Add(GetIdx(p1_6240, 1D), ((V)(((ToNum(GetIdx(p2_6241, 1D)) - ToNum(GetIdx(p0_6239, 1D))) / 6D)))))).S(" ").V(Call(r2_14, V.Undef, ((V)((ToNum(GetIdx(p2_6241, 0D)) - ((ToNum(GetIdx(p3_6242, 0D)) - ToNum(GetIdx(p1_6240, 0D))) / 6D)))))).S(" ").V(Call(r2_14, V.Undef, ((V)((ToNum(GetIdx(p2_6241, 1D)) - ((ToNum(GetIdx(p3_6242, 1D)) - ToNum(GetIdx(p1_6240, 1D))) / 6D)))))).S(" ").V(Call(r2_14, V.Undef, GetIdx(p2_6241, 0D))).S(" ").V(Call(r2_14, V.Undef, GetIdx(p2_6241, 1D)));
i_6237++;
}
}
return ((V)(s_6236.Str));
return default;
}, 1, "", true);
flat_27 = Fn((V _arrowThis6253, int _argc6245, V segs_6251, V n_6252, V _a6249, V _a6250, V[] _rest6246) => {
V @out_6254 = default;
V p_6255 = default;
@out_6254 = Arr();
p_6255 = V.Null;
{
foreach (V _k6256 in new JsIter(segs_6251)) {
V g_6257 = default;
g_6257 = _k6256;
if ((SEqS(Get(g_6257, "c"), "M") || SEqS(Get(g_6257, "c"), "L"))) {
p_6255 = GetIdx(Get(g_6257, "p"), 0D);
Invoke(@out_6254, "push", p_6255);
} else {
if (SEqS(Get(g_6257, "c"), "Q")) {
V a_6258 = default;
V b_6259 = default;
{ V _t6260 = Get(g_6257, "p");
{ V _t6261 = ListOf(_t6260);
{ V _t6262 = GetIdx(_t6261, 0D);
a_6258 = _t6262; }
{ V _t6263 = GetIdx(_t6261, 1D);
b_6259 = _t6263; }
} }
{
double i_6264 = 0;
i_6264 = 1D;
while (true) {
if (!(Le(((V)(i_6264)), n_6252))) break;
double t_6266 = 0;
double m_6267 = 0;
t_6266 = (i_6264 / ToNum(n_6252));
m_6267 = (1D - t_6266);
Invoke(@out_6254, "push", Arr(((V)(((((m_6267 * m_6267) * ToNum(GetIdx(p_6255, 0D))) + (((2D * m_6267) * t_6266) * ToNum(GetIdx(a_6258, 0D)))) + ((t_6266 * t_6266) * ToNum(GetIdx(b_6259, 0D)))))), ((V)(((((m_6267 * m_6267) * ToNum(GetIdx(p_6255, 1D))) + (((2D * m_6267) * t_6266) * ToNum(GetIdx(a_6258, 1D)))) + ((t_6266 * t_6266) * ToNum(GetIdx(b_6259, 1D))))))));
i_6264++;
}
}
p_6255 = b_6259;
} else {
if (SEqS(Get(g_6257, "c"), "C")) {
V a_6268 = default;
V b_6269 = default;
V c_6270 = default;
{ V _t6271 = Get(g_6257, "p");
{ V _t6272 = ListOf(_t6271);
{ V _t6273 = GetIdx(_t6272, 0D);
a_6268 = _t6273; }
{ V _t6274 = GetIdx(_t6272, 1D);
b_6269 = _t6274; }
{ V _t6275 = GetIdx(_t6272, 2D);
c_6270 = _t6275; }
} }
{
double i_6276 = 0;
i_6276 = 1D;
while (true) {
if (!(Le(((V)(i_6276)), n_6252))) break;
double t_6278 = 0;
double m_6279 = 0;
t_6278 = (i_6276 / ToNum(n_6252));
m_6279 = (1D - t_6278);
Invoke(@out_6254, "push", Arr(((V)(((((((m_6279 * m_6279) * m_6279) * ToNum(GetIdx(p_6255, 0D))) + ((((3D * m_6279) * m_6279) * t_6278) * ToNum(GetIdx(a_6268, 0D)))) + ((((3D * m_6279) * t_6278) * t_6278) * ToNum(GetIdx(b_6269, 0D)))) + (((t_6278 * t_6278) * t_6278) * ToNum(GetIdx(c_6270, 0D)))))), ((V)(((((((m_6279 * m_6279) * m_6279) * ToNum(GetIdx(p_6255, 1D))) + ((((3D * m_6279) * m_6279) * t_6278) * ToNum(GetIdx(a_6268, 1D)))) + ((((3D * m_6279) * t_6278) * t_6278) * ToNum(GetIdx(b_6269, 1D)))) + (((t_6278 * t_6278) * t_6278) * ToNum(GetIdx(c_6270, 1D))))))));
i_6276++;
}
}
p_6255 = c_6270;
}
}
}
}
}
return @out_6254;
return default;
}, 2, "", true);
hull_28 = Fn((V _arrowThis6287, int _argc6280, V P_6286, V _a6283, V _a6284, V _a6285, V[] _rest6281) => {
V cr_6288 = default;
V lo_6289 = default;
V up_6290 = default;
P_6286 = Invoke(Invoke(P_6286, "slice"), "sort", Fn((V _arrowThis6299, int _argc6291, V a_6297, V b_6298, V _a6295, V _a6296, V[] _rest6292) => {
return (((V)((ToNum(GetIdx(a_6297, 0D)) - ToNum(GetIdx(b_6298, 0D))))) is var _t6300 && Truthy(_t6300) ? _t6300 : ((V)((ToNum(GetIdx(a_6297, 1D)) - ToNum(GetIdx(b_6298, 1D))))));
}, 2, "", true));
cr_6288 = Fn((V _arrowThis6310, int _argc6301, V o_6307, V a_6308, V b_6309, V _a6306, V[] _rest6302) => {
return ((V)((((ToNum(GetIdx(a_6308, 0D)) - ToNum(GetIdx(o_6307, 0D))) * (ToNum(GetIdx(b_6309, 1D)) - ToNum(GetIdx(o_6307, 1D)))) - ((ToNum(GetIdx(a_6308, 1D)) - ToNum(GetIdx(o_6307, 1D))) * (ToNum(GetIdx(b_6309, 0D)) - ToNum(GetIdx(o_6307, 0D)))))));
}, 3, "", true);
lo_6289 = Arr();
up_6290 = Arr();
{
foreach (V _k6311 in new JsIter(P_6286)) {
V p_6312 = default;
p_6312 = _k6311;
while ((GeN(Get(lo_6289, "length"), 2D) && LeN(Call(cr_6288, V.Undef, GetIdx(lo_6289, (ToNum(Get(lo_6289, "length")) - 2D)), GetIdx(lo_6289, (ToNum(Get(lo_6289, "length")) - 1D)), p_6312), 0D))) {
Invoke(lo_6289, "pop");
}
Invoke(lo_6289, "push", p_6312);
}
}
{
double i_6313 = 0;
i_6313 = (ToNum(Get(P_6286, "length")) - 1D);
while (true) {
if (!((i_6313 >= 0D))) break;
V p_6315 = default;
p_6315 = GetIdx(P_6286, i_6313);
while ((GeN(Get(up_6290, "length"), 2D) && LeN(Call(cr_6288, V.Undef, GetIdx(up_6290, (ToNum(Get(up_6290, "length")) - 2D)), GetIdx(up_6290, (ToNum(Get(up_6290, "length")) - 1D)), p_6315), 0D))) {
Invoke(up_6290, "pop");
}
Invoke(up_6290, "push", p_6315);
i_6313--;
}
}
Invoke(up_6290, "pop");
Invoke(lo_6289, "pop");
return Invoke(lo_6289, "concat", up_6290);
return default;
}, 1, "", true);
closedD_29 = Fn((V _arrowThis6323, int _argc6316, V P_6322, V _a6319, V _a6320, V _a6321, V[] _rest6317) => {
V n_6324 = default;
JsStrBuf s_6325 = null;
n_6324 = Get(P_6322, "length");
if (LtN(n_6324, 3D)) {
return ((V)(""));
}
s_6325 = new JsStrBuf(JsStrBuf.Begin().S("M").V(Call(r2_14, V.Undef, GetIdx(GetIdx(P_6322, 0D), 0D))).S(" ").V(Call(r2_14, V.Undef, GetIdx(GetIdx(P_6322, 0D), 1D))).End());
{
double i_6326 = 0;
i_6326 = 0D;
while (true) {
if (!(Lt(((V)(i_6326)), n_6324))) break;
V p0_6328 = default;
V p1_6329 = default;
V p2_6330 = default;
V p3_6331 = default;
p0_6328 = GetIdx(P_6322, (ToNum(Add(((V)((i_6326 - 1D))), n_6324)) % ToNum(n_6324)));
p1_6329 = GetIdx(P_6322, i_6326);
p2_6330 = GetIdx(P_6322, ((i_6326 + 1D) % ToNum(n_6324)));
p3_6331 = GetIdx(P_6322, ((i_6326 + 2D) % ToNum(n_6324)));
s_6325.S(" C").V(Call(r2_14, V.Undef, Add(GetIdx(p1_6329, 0D), ((V)(((ToNum(GetIdx(p2_6330, 0D)) - ToNum(GetIdx(p0_6328, 0D))) / 6D)))))).S(" ").V(Call(r2_14, V.Undef, Add(GetIdx(p1_6329, 1D), ((V)(((ToNum(GetIdx(p2_6330, 1D)) - ToNum(GetIdx(p0_6328, 1D))) / 6D)))))).S(" ").V(Call(r2_14, V.Undef, ((V)((ToNum(GetIdx(p2_6330, 0D)) - ((ToNum(GetIdx(p3_6331, 0D)) - ToNum(GetIdx(p1_6329, 0D))) / 6D)))))).S(" ").V(Call(r2_14, V.Undef, ((V)((ToNum(GetIdx(p2_6330, 1D)) - ((ToNum(GetIdx(p3_6331, 1D)) - ToNum(GetIdx(p1_6329, 1D))) / 6D)))))).S(" ").V(Call(r2_14, V.Undef, GetIdx(p2_6330, 0D))).S(" ").V(Call(r2_14, V.Undef, GetIdx(p2_6330, 1D)));
i_6326++;
}
}
return ((V)(string.Concat(s_6325.Str, "Z")));
return default;
}, 1, "", true);
ellAx_30 = Fn((V _arrowThis6341, int _argc6332, V cx_6338, V cy_6339, V A_6340, V _a6337, V[] _rest6333) => {
double a_6342 = 0;
double b_6343 = 0;
double c_6344 = 0;
double tr_6345 = 0;
double df_6346 = 0;
a_6342 = 0D;
b_6343 = 0D;
c_6344 = 0D;
{
foreach (V _k6347 in new JsIter(A_6340)) {
V v_6348 = default;
v_6348 = _k6347;
a_6342 = (a_6342 + (ToNum(GetIdx(v_6348, 0D)) * ToNum(GetIdx(v_6348, 0D))));
b_6343 = (b_6343 + (ToNum(GetIdx(v_6348, 0D)) * ToNum(GetIdx(v_6348, 1D))));
c_6344 = (c_6344 + (ToNum(GetIdx(v_6348, 1D)) * ToNum(GetIdx(v_6348, 1D))));
}
}
tr_6345 = ((a_6342 + c_6344) / 2D);
df_6346 = System.Math.Sqrt(Max(0D, ((((a_6342 - c_6344) * (a_6342 - c_6344)) / 4D) + (b_6343 * b_6343))));
return Call(ellS_22, V.Undef, cx_6338, cy_6339, ((V)(System.Math.Sqrt((tr_6345 + df_6346)))), ((V)(System.Math.Sqrt(Max(0.01, (tr_6345 - df_6346))))), ((V)(((0.5 * FdLibm.Atan2((2D * b_6343), (a_6342 - c_6344))) / D2R_11))), ((V)(8D)));
return default;
}, 3, "", true);
earSec_31 = Fn((V _arrowThis6357, int _argc6349, V e_6355, V poly_6356, V _a6353, V _a6354, V[] _rest6350) => {
V px_6358 = default;
V py_6359 = default;
V ux_6360 = default;
V uy_6361 = default;
double nx_6362 = 0;
V ny_6363 = default;
V A_6364 = default;
V amax_6365 = default;
double amin_6366 = 0;
V secs_6367 = default;
{ V _t6368 = Get(e_6355, "pivot");
{ V _t6369 = ListOf(_t6368);
{ V _t6370 = GetIdx(_t6369, 0D);
px_6358 = _t6370; }
{ V _t6371 = GetIdx(_t6369, 1D);
py_6359 = _t6371; }
} }
ux_6360 = Get(e_6355, "ux");
uy_6361 = Get(e_6355, "uy");
nx_6362 = (-ToNum(uy_6361));
ny_6363 = ux_6360;
A_6364 = Invoke(poly_6356, "map", Fn((V _arrowThis6383, int _argc6372, V _a6374, V _a6375, V _a6376, V _a6377, V[] _rest6373) => {
V x_6380 = default;
V y_6382 = default;
{ V _t6378 = ListOf(_a6374);
{ V _t6379 = GetIdx(_t6378, 0D);
x_6380 = _t6379; }
{ V _t6381 = GetIdx(_t6378, 1D);
y_6382 = _t6381; }
}
return Arr(((V)((((ToNum(x_6380) - ToNum(px_6358)) * ToNum(ux_6360)) + ((ToNum(y_6382) - ToNum(py_6359)) * ToNum(uy_6361))))), ((V)((((ToNum(x_6380) - ToNum(px_6358)) * nx_6362) + ((ToNum(y_6382) - ToNum(py_6359)) * ToNum(ny_6363))))));
}, 1, "", true));
amax_6365 = InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(Invoke(A_6364, "map", Fn((V _arrowThis6391, int _argc6384, V a_6390, V _a6387, V _a6388, V _a6389, V[] _rest6385) => {
return GetIdx(a_6390, 0D);
}, 1, "", true))).V);
amin_6366 = Max(ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(Invoke(A_6364, "map", Fn((V _arrowThis6399, int _argc6392, V a_6398, V _a6395, V _a6396, V _a6397, V[] _rest6393) => {
return GetIdx(a_6398, 0D);
}, 1, "", true))).V)), (-4D));
secs_6367 = Arr();
{
double i_6400 = 0;
i_6400 = 0D;
while (true) {
if (!((i_6400 <= 13D))) break;
double a_6402 = 0;
double lo_6403 = 0;
double hi_6404 = 0;
double hw_6405 = 0;
double tc_6406 = 0;
V s_6407 = default;
a_6402 = (amin_6366 + ((((ToNum(amax_6365) - amin_6366) - 0.5) * i_6400) / 13D));
lo_6403 = 1000000000D;
hi_6404 = (-1000000000D);
{
double j_6408 = 0;
j_6408 = 0D;
while (true) {
if (!(Lt(((V)(j_6408)), Get(A_6364, "length")))) break;
V p_6410 = default;
V q_6411 = default;
p_6410 = GetIdx(A_6364, j_6408);
q_6411 = GetIdx(A_6364, ((j_6408 + 1D) % ToNum(Get(A_6364, "length"))));
if (((((ToNum(GetIdx(p_6410, 0D)) - a_6402) * (ToNum(GetIdx(q_6411, 0D)) - a_6402)) <= 0D) && !SEq(GetIdx(p_6410, 0D), GetIdx(q_6411, 0D)))) {
V t_6412 = default;
t_6412 = Add(GetIdx(p_6410, 1D), ((V)((((ToNum(GetIdx(q_6411, 1D)) - ToNum(GetIdx(p_6410, 1D))) * (a_6402 - ToNum(GetIdx(p_6410, 0D)))) / (ToNum(GetIdx(q_6411, 0D)) - ToNum(GetIdx(p_6410, 0D)))))));
lo_6403 = Min(lo_6403, ToNum(t_6412));
hi_6404 = Max(hi_6404, ToNum(t_6412));
}
j_6408++;
}
}
if ((lo_6403 > hi_6404)) {
goto _cont6401;
}
hw_6405 = Max(0.8, ((hi_6404 - lo_6403) / 2D));
tc_6406 = ((hi_6404 + lo_6403) / 2D);
s_6407 = Call(clamp_13, V.Undef, ((V)((a_6402 / ToNum(amax_6365)))), ((V)(0D)), ((V)(1D)));
Invoke(secs_6367, "push", NewObj(5).Put("s", s_6407).Put("cx", Add(Add(px_6358, ((V)((a_6402 * ToNum(ux_6360))))), ((V)((tc_6406 * nx_6362))))).Put("cy", Add(Add(py_6359, ((V)((a_6402 * ToNum(uy_6361))))), ((V)((tc_6406 * ToNum(ny_6363)))))).Put("hw", ((V)(hw_6405))).Put("hd", ((V)(Max(0.8, ((hw_6405 * 0.55) * (0.3 + (0.7 * ToNum(Call(SM_16, V.Undef, ((V)(((ToNum(s_6407) - 0.1) / 0.4)))))))))))).V);
_cont6401: ;
i_6400++;
}
}
return NewObj(4).Put("secs", secs_6367).Put("amax", amax_6365).Put("nx", ((V)(nx_6362))).Put("ny", ny_6363).V;
return default;
}, 2, "", true);
mk_32 = Fn((V _arrowThis6422, int _argc6413, V tag_6419, V at_6420, V par_6421, V _a6418, V[] _rest6414) => {
V e_6423 = default;
e_6423 = Invoke(G("document"), "createElementNS", NS_10, tag_6419);
{
foreach (V _k6424 in ForInKeys(at_6420)) {
V k_6425 = default;
k_6425 = _k6424;
Invoke(e_6423, "setAttribute", k_6425, GetK(at_6420, k_6425));
}
}
if (Truthy(par_6421)) {
Invoke(par_6421, "appendChild", e_6423);
}
return e_6423;
return default;
}, 3, "", true);
star4_33 = Fn((V _arrowThis6435, int _argc6426, V x_6432, V y_6433, V r_6434, V _a6431, V[] _rest6427) => {
return ((V)(JsStrBuf.Begin().S("M").V(Call(r2_14, V.Undef, x_6432)).S(" ").V(Call(r2_14, V.Undef, ((V)((ToNum(y_6433) - ToNum(r_6434)))))).S(" Q").V(Call(r2_14, V.Undef, x_6432)).S(" ").V(Call(r2_14, V.Undef, y_6433)).S(" ").V(Call(r2_14, V.Undef, Add(x_6432, r_6434))).S(" ").V(Call(r2_14, V.Undef, y_6433)).S(" Q").V(Call(r2_14, V.Undef, x_6432)).S(" ").V(Call(r2_14, V.Undef, y_6433)).S(" ").V(Call(r2_14, V.Undef, x_6432)).S(" ").V(Call(r2_14, V.Undef, Add(y_6433, r_6434))).S(" Q").V(Call(r2_14, V.Undef, x_6432)).S(" ").V(Call(r2_14, V.Undef, y_6433)).S(" ").V(Call(r2_14, V.Undef, ((V)((ToNum(x_6432) - ToNum(r_6434)))))).S(" ").V(Call(r2_14, V.Undef, y_6433)).S(" Q").V(Call(r2_14, V.Undef, x_6432)).S(" ").V(Call(r2_14, V.Undef, y_6433)).S(" ").V(Call(r2_14, V.Undef, x_6432)).S(" ").V(Call(r2_14, V.Undef, ((V)((ToNum(y_6433) - ToNum(r_6434)))))).S("Z").End()));
}, 3, "", true);
DEFS_34 = NewObj(1).Put("mittens", NewObj(16).Put("G", ((V)(95.5))).Put("top", ((V)(17D))).Put("head", Arr(((V)(50D)), ((V)(46D)), ((V)(29D)))).Put("neck", Arr(((V)(50D)), ((V)(73D)))).Put("c", NewObj(11).Put("tail", ((V)("#e59a58"))).Put("pad", ((V)("#ffb8c6"))).Put("inner", ((V)("#ffb3c1"))).Put("muzzle", ((V)("#fff1e2"))).Put("nose", ((V)("#e8798f"))).Put("cheek", ((V)("#ff8fa3"))).Put("mouth", ((V)("#6a3a3a"))).Put("whisker", ((V)("#a86a3a"))).Put("stripe", ((V)("#e08e48"))).Put("arm", ((V)("#f0aa6a"))).Put("g", Arr(((V)("#ffe4c0")), ((V)("#f8b77a")), ((V)("#d98a4a")))).V).Put("body", Arr(((V)(50D)), ((V)(78D)), ((V)(22D)), ((V)(13D)))).Put("feet", Arr(Arr(((V)(38D)), ((V)(90D))), Arr(((V)(62D)), ((V)(90D))))).Put("ears", Arr(NewObj(5).Put("side", ((V)((-1D)))).Put("pivot", Arr(((V)(34D)), ((V)(30D)))).Put("tip", Arr(((V)(26D)), ((V)(9D)))).Put("d", ((V)("M22 36 Q20 8 30 10 Q38 14 46 24 Z"))).Put("inner", ((V)("M28 28 Q28 16 32 16 Q36 18 40 24 Z"))).V, NewObj(5).Put("side", ((V)(1D))).Put("pivot", Arr(((V)(66D)), ((V)(30D)))).Put("tip", Arr(((V)(74D)), ((V)(9D)))).Put("d", ((V)("M78 36 Q80 8 70 10 Q62 14 54 24 Z"))).Put("inner", ((V)("M72 28 Q72 16 68 16 Q64 18 60 24 Z"))).V)).Put("arms", Arr(NewObj(3).Put("side", ((V)((-1D)))).Put("e", Arr(((V)(30.6)), ((V)(76D)), ((V)(6D)), ((V)(8D)), ((V)(20D)))).Put("pivot", Arr(((V)(33.2)), ((V)(68.6)))).V, NewObj(3).Put("side", ((V)(1D))).Put("e", Arr(((V)(69.4)), ((V)(76D)), ((V)(6D)), ((V)(8D)), ((V)((-20D))))).Put("pivot", Arr(((V)(66.8)), ((V)(68.6)))).V)).Put("tail", Arr(Arr(((V)(52D)), ((V)(86D))), Arr(((V)(74D)), ((V)(92D))), Arr(((V)(92D)), ((V)(82D))), Arr(((V)(88D)), ((V)(66D))))).Put("eyes", Arr(Arr(((V)(38D)), ((V)(47D))), Arr(((V)(62D)), ((V)(47D))))).Put("eyeR", ((V)(5.2))).Put("tail3", Arr(Arr(((V)(50D)), ((V)(81D)), ((V)((-18D)))), Arr(((V)(51D)), ((V)(90D)), ((V)((-35D)))), Arr(((V)(80D)), ((V)(94D)), ((V)((-36D)))), Arr(((V)(90D)), ((V)(71D)), ((V)((-26D)))))).Put("whiskers", Arr(((V)("M36 55 Q27 52.5 18 52")), ((V)("M36 58 Q27 58.5 18 60")), ((V)("M64 55 Q73 52.5 82 52")), ((V)("M64 58 Q73 58.5 82 60")))).Put("stripes", ((V)("M44 18 L45 24 M56 18 L55 24"))).Put("back", ((V)("M43 21 L44 28 M50 19 L50 27 M57 21 L56 28"))).V).V;
Set(DEFS_34, "biscuit", NewObj(33).Put("G", ((V)(95.5))).Put("top", ((V)(16D))).Put("head", Arr(((V)(50D)), ((V)(44D)), ((V)(28D)))).Put("neck", Arr(((V)(50D)), ((V)(71D)))).Put("c", NewObj(14).Put("tail", ((V)("#e8a45a"))).Put("tailB", ((V)("#e2a056"))).Put("pad", ((V)("#7a4a2a"))).Put("inner", ((V)("#c98a50"))).Put("muzzle", ((V)("#fff1de"))).Put("nose", ((V)("#2a1a30"))).Put("cheek", ((V)("#ff8fa3"))).Put("mouth", ((V)("#6a3a3a"))).Put("whisker", ((V)("none"))).Put("stripe", ((V)("#fff1de"))).Put("arm", ((V)("#efae62"))).Put("g", Arr(((V)("#ffe2b8")), ((V)("#f2b56c")), ((V)("#d48a3e")))).Put("ge", Arr(((V)("#c98a50")), ((V)("#a8693a")), ((V)("#7c4724")))).Put("tailHL", ((V)("#ffe2b8"))).V).Put("body", Arr(((V)(50D)), ((V)(77D)), ((V)(21D)), ((V)(14D)))).Put("belly", Arr(((V)(50D)), ((V)(80D)), ((V)(12D)), ((V)(9D)), ((V)("#fff3e0")))).Put("bellyTurn", (true ? V.True : V.False)).Put("feet", Arr(Arr(((V)(38D)), ((V)(90D))), Arr(((V)(62D)), ((V)(90D))))).Put("pads", Arr(Arr(((V)((-4D))), ((V)(1D)), ((V)(1.6)), ((V)(1.2))), Arr(((V)(0D)), ((V)(2D)), ((V)(1.6)), ((V)(1.2))), Arr(((V)(4D)), ((V)(1D)), ((V)(1.6)), ((V)(1.2))))).Put("ears", Arr(NewObj(6).Put("side", ((V)((-1D)))).Put("flop", (true ? V.True : V.False)).Put("lobe", Arr(((V)(19D)), ((V)(42D)), ((V)(10.5)), ((V)(18D)), ((V)(9D)), ((V)((-2D))), ((V)(14D)))).Put("pivot", Arr(((V)(27D)), ((V)(30D)))).Put("tip", Arr(((V)(15D)), ((V)(58D)))).Put("d", ((V)("M28 26 Q14 22 10 36 Q8 52 18 60 Q24 62 26 54 Q26 40 32 32Z"))).V, NewObj(6).Put("side", ((V)(1D))).Put("flop", (true ? V.True : V.False)).Put("lobe", Arr(((V)(81D)), ((V)(42D)), ((V)(10.5)), ((V)(18D)), ((V)(9D)), ((V)((-2D))), ((V)((-14D))))).Put("pivot", Arr(((V)(73D)), ((V)(30D)))).Put("tip", Arr(((V)(85D)), ((V)(58D)))).Put("d", ((V)("M72 26 Q86 22 90 36 Q92 52 82 60 Q76 62 74 54 Q74 40 68 32Z"))).V)).Put("arms", Arr(NewObj(3).Put("side", ((V)((-1D)))).Put("e", Arr(((V)(30.6)), ((V)(77D)), ((V)(6D)), ((V)(8D)), ((V)(15D)))).Put("pivot", Arr(((V)(32.7)), ((V)(69.3)))).V, NewObj(3).Put("side", ((V)(1D))).Put("e", Arr(((V)(69.4)), ((V)(77D)), ((V)(6D)), ((V)(8D)), ((V)((-15D))))).Put("pivot", Arr(((V)(67.3)), ((V)(69.3)))).V)).Put("tail", Arr(Arr(((V)(72D)), ((V)(78D))), Arr(((V)(86D)), ((V)(77D))), Arr(((V)(89D)), ((V)(65D))), Arr(((V)(84D)), ((V)(57D))))).Put("tailW", ((V)(6D))).Put("tailRoot", Arr(Arr(((V)(62D)), ((V)(86D))), Arr(((V)(67D)), ((V)(83D))))).Put("eyes", Arr(Arr(((V)(38D)), ((V)(45D))), Arr(((V)(62D)), ((V)(45D))))).Put("eyeR", ((V)(5.2))).Put("tail3", Arr(Arr(((V)(50D)), ((V)(80D)), ((V)((-16D)))), Arr(((V)(51D)), ((V)(79D)), ((V)((-31D)))), Arr(((V)(60D)), ((V)(74D)), ((V)((-34D)))), Arr(((V)(71D)), ((V)(62D)), ((V)((-27D)))))).Put("tailWag", ((V)(1.7))).Put("tailK", ((V)(8D))).Put("tailTaper", Arr(((V)(0.86)), ((V)(0.36)))).Put("tailShade", ((V)("#c9873f"))).Put("muzzle", Arr(((V)(50D)), ((V)(56D)), ((V)(15D)), ((V)(11D)))).Put("nose", Arr(((V)(50D)), ((V)(53D)), ((V)(4.4)), ((V)(3.2)))).Put("noseHL", Arr(((V)(48.6)), ((V)(52D)), ((V)(1.4)), ((V)(0.9)))).Put("mouth", Arr(((V)(50D)), ((V)(60D)), ((V)(4.5)))).Put("cheeks", Arr(Arr(((V)(33D)), ((V)(55D))), Arr(((V)(67D)), ((V)(55D))))).Put("faceExtra", Arr(NewObj(3).Put("d", ((V)("M44 20 Q50 16 56 20 Q54 30 50 34 Q46 30 44 20Z"))).Put("fill", ((V)("#fff1de"))).Put("op", ((V)(0.9))).V, NewObj(3).Put("d", ((V)("M50 56 L50 59"))).Put("stroke", ((V)("#6a3a3a"))).Put("sw", ((V)(1.2))).V)).Put("whiskers", Arr()).Put("stripes", ((V)(""))).Put("back", ((V)("M44 22 Q50 18 56 22"))).Put("collar", NewObj(3).Put("d", ((V)("M30 66 Q50 74 70 66 L70 70 Q50 78 30 70Z"))).Put("fill", ((V)("#ff6f86"))).Put("ring", NewObj(8).Put("ys", ((V)(64D))).Put("af", ((V)(4D))).Put("ab", ((V)(1.5))).Put("w", ((V)(4D))).Put("rx", ((V)(20D))).Put("rz", ((V)(20D))).Put("dark", ((V)("#c8445d"))).Put("light", ((V)("#ff9cb0"))).V).V).Put("tag", NewObj(4).Put("x", ((V)(50D))).Put("y", ((V)(74D))).Put("r", ((V)(3.4))).Put("fill", ((V)("#ffd84a"))).V).V);
Set(DEFS_34, "waffles", NewObj(34).Put("G", ((V)(95.5))).Put("top", ((V)(15D))).Put("head", Arr(((V)(50D)), ((V)(46D)), ((V)(30D)), ((V)(26.5)))).Put("neck", Arr(((V)(50D)), ((V)(72D)))).Put("c", NewObj(13).Put("tail", ((V)("#e8953e"))).Put("tailB", ((V)("#e0903c"))).Put("pad", ((V)("#fff1de"))).Put("inner", ((V)("#ffd29a"))).Put("muzzle", ((V)("#fff1de"))).Put("nose", ((V)("#2a1a30"))).Put("cheek", ((V)("#ff8fa3"))).Put("mouth", ((V)("#6a3a3a"))).Put("whisker", ((V)("none"))).Put("stripe", ((V)("#fff1de"))).Put("arm", ((V)("#eda052"))).Put("g", Arr(((V)("#ffd29a")), ((V)("#e8953e")), ((V)("#b86424")))).Put("tailHL", ((V)("#ffd29a"))).V).Put("grads", NewObj(1).Put("wcr", Arr(Arr(((V)("0")), ((V)("#fffaf2"))), Arr(((V)("0.6")), ((V)("#fff1de"))), Arr(((V)("1")), ((V)("#f0d9b8"))))).V).Put("headD", ((V)("M50 20 Q57.38 14.9 61.86 21.98 Q71 19.63 71.92 27.62 Q81.44 28.38 78.64 36.05 Q87.08 39.81 81 46 Q87.08 52.19 78.64 55.95 Q81.44 63.62 71.92 64.38 Q71 72.37 61.86 70.02 Q57.38 77.1 50 72 Q42.62 77.1 38.14 70.02 Q29 72.37 28.08 64.38 Q18.56 63.62 21.36 55.95 Q12.92 52.19 19 46 Q12.92 39.81 21.36 36.05 Q18.56 28.38 28.08 27.62 Q29 19.63 38.14 21.98 Q42.62 14.9 50 20Z"))).Put("body", Arr(((V)(50D)), ((V)(77D)), ((V)(21D)), ((V)(14D)))).Put("belly", Arr(((V)(50D)), ((V)(80D)), ((V)(12D)), ((V)(9D)), ((V)("url(#wcr)")))).Put("bellyTurn", (true ? V.True : V.False)).Put("feet", Arr(Arr(((V)(38D)), ((V)(90D))), Arr(((V)(62D)), ((V)(90D))))).Put("pads", Arr(Arr(((V)((-4D))), ((V)(1D)), ((V)(1.6)), ((V)(1.2))), Arr(((V)(0D)), ((V)(2D)), ((V)(1.6)), ((V)(1.2))), Arr(((V)(4D)), ((V)(1D)), ((V)(1.6)), ((V)(1.2))))).Put("ears", Arr(NewObj(4).Put("side", ((V)((-1D)))).Put("pivot", Arr(((V)(33D)), ((V)(34D)))).Put("tip", Arr(((V)(28D)), ((V)(7D)))).Put("d", ((V)("M24 40 Q18 14 28 6 Q40 14 42 34Z"))).V, NewObj(4).Put("side", ((V)(1D))).Put("pivot", Arr(((V)(67D)), ((V)(34D)))).Put("tip", Arr(((V)(72D)), ((V)(7D)))).Put("d", ((V)("M76 40 Q82 14 72 6 Q60 14 58 34Z"))).V)).Put("arms", Arr(NewObj(3).Put("side", ((V)((-1D)))).Put("e", Arr(((V)(30.6)), ((V)(77D)), ((V)(6D)), ((V)(8D)), ((V)(15D)))).Put("pivot", Arr(((V)(32.7)), ((V)(69.3)))).V, NewObj(3).Put("side", ((V)(1D))).Put("e", Arr(((V)(69.4)), ((V)(77D)), ((V)(6D)), ((V)(8D)), ((V)((-15D))))).Put("pivot", Arr(((V)(67.3)), ((V)(69.3)))).V)).Put("tail", Arr(Arr(((V)(72D)), ((V)(78D))), Arr(((V)(86D)), ((V)(77D))), Arr(((V)(89D)), ((V)(65D))), Arr(((V)(84D)), ((V)(57D))))).Put("eyes", Arr(Arr(((V)(38D)), ((V)(45D))), Arr(((V)(62D)), ((V)(45D))))).Put("eyeR", ((V)(5.2))).Put("tail3", Arr(Arr(((V)(50D)), ((V)(80D)), ((V)((-16D)))), Arr(((V)(50D)), ((V)(79D)), ((V)((-22.5)))), Arr(((V)(51D)), ((V)(77D)), ((V)((-25.5)))), Arr(((V)(52.5)), ((V)(74D)), ((V)((-26.5)))))).Put("tailWag", ((V)(1.9))).Put("tailK", ((V)(8.5))).Put("tailTaper", Arr(((V)(0.92)), ((V)(0.78)))).Put("tailShade", ((V)("#b86424"))).Put("muzzle", Arr(((V)(50D)), ((V)(56D)), ((V)(15D)), ((V)(11D)))).Put("nose", Arr(((V)(50D)), ((V)(53D)), ((V)(4.4)), ((V)(3.2)))).Put("noseHL", Arr(((V)(48.6)), ((V)(52D)), ((V)(1.4)), ((V)(0.9)))).Put("mouth", Arr(((V)(50D)), ((V)(60D)), ((V)(4.5)))).Put("cheeks", Arr(Arr(((V)(33D)), ((V)(55D))), Arr(((V)(67D)), ((V)(55D))))).Put("tufts", Arr(NewObj(2).Put("c", Arr(((V)(26D)), ((V)(58D)))).Put("d", ((V)("M26 49 Q29.06 46.57 30.5 50.21 Q34.37 49.63 33.79 53.5 Q37.43 54.94 35 58 Q37.43 61.06 33.79 62.5 Q34.37 66.37 30.5 65.79 Q29.06 69.43 26 67 Q22.94 69.43 21.5 65.79 Q17.63 66.37 18.21 62.5 Q14.57 61.06 17 58 Q14.57 54.94 18.21 53.5 Q17.63 49.63 21.5 50.21 Q22.94 46.57 26 49Z"))).V, NewObj(2).Put("c", Arr(((V)(74D)), ((V)(58D)))).Put("d", ((V)("M74 49 Q77.06 46.57 78.5 50.21 Q82.37 49.63 81.79 53.5 Q85.43 54.94 83 58 Q85.43 61.06 81.79 62.5 Q82.37 66.37 78.5 65.79 Q77.06 69.43 74 67 Q70.94 69.43 69.5 65.79 Q65.63 66.37 66.21 62.5 Q62.57 61.06 65 58 Q62.57 54.94 66.21 53.5 Q65.63 49.63 69.5 50.21 Q70.94 46.57 74 49Z"))).V)).Put("faceExtra", Arr(NewObj(3).Put("d", ((V)("M50 30 Q54.77 28.38 57 30.8 Q63.02 30.42 62.12 33 Q67.79 33.96 64 36 Q67.79 38.04 62.12 39 Q63.02 41.58 57 41.2 Q54.77 43.62 50 42 Q45.23 43.62 43 41.2 Q36.98 41.58 37.88 39 Q32.21 38.04 36 36 Q32.21 33.96 37.88 33 Q36.98 30.42 43 30.8 Q45.23 28.38 50 30Z"))).Put("fill", ((V)("url(#wcr)"))).Put("op", ((V)(0.85))).V, NewObj(3).Put("d", ((V)("M44 20 Q50 16 56 20 Q54 30 50 34 Q46 30 44 20Z"))).Put("fill", ((V)("#fff1de"))).Put("op", ((V)(0.9))).V, NewObj(3).Put("d", ((V)("M50 56 L50 59"))).Put("stroke", ((V)("#6a3a3a"))).Put("sw", ((V)(1.2))).V, NewObj(2).Put("d", ((V)("M47.5 61 Q50 67 52.5 61Z"))).Put("fill", ((V)("#ff7f96"))).V)).Put("whiskers", Arr()).Put("stripes", ((V)(""))).Put("back", ((V)(""))).Put("collar", NewObj(3).Put("d", ((V)("M30 66 Q50 74 70 66 L70 70 Q50 78 30 70Z"))).Put("fill", ((V)("#b86424"))).Put("ring", NewObj(9).Put("ys", ((V)(66D))).Put("af", ((V)(4D))).Put("ab", ((V)(1.5))).Put("w", ((V)(4D))).Put("rx", ((V)(20D))).Put("rz", ((V)(20D))).Put("dark", ((V)("#7e3f12"))).Put("light", ((V)("#d9894a"))).Put("stitch", ((V)("#f2c48c"))).V).V).Put("tag", NewObj(5).Put("x", ((V)(50D))).Put("y", ((V)(74D))).Put("r", ((V)(3.4))).Put("fill", ((V)("#fff8ee"))).Put("metal", Arr(((V)("#ffffff")), ((V)("#efece6")), ((V)("#b3ada2")), ((V)("#8a8478")))).V).V);
Set(DEFS_34, "truffle", NewObj(29).Put("G", ((V)(95.5))).Put("top", ((V)(21D))).Put("head", Arr(((V)(50D)), ((V)(47D)), ((V)(30D)), ((V)(26D)))).Put("neck", Arr(((V)(50D)), ((V)(72D)))).Put("c", NewObj(12).Put("tail", ((V)("#f095ad"))).Put("tailB", ((V)("#f4a3b8"))).Put("pad", ((V)("#d9718f"))).Put("inner", ((V)("#f59ab2"))).Put("muzzle", ((V)("#ff9fb6"))).Put("nose", ((V)("#b8506e"))).Put("cheek", ((V)("#ff7f9a"))).Put("mouth", ((V)("#6a3a3a"))).Put("whisker", ((V)("none"))).Put("stripe", ((V)("none"))).Put("arm", ((V)("#ffb3c6"))).Put("g", Arr(((V)("#ffe6ec")), ((V)("#ffb8c8")), ((V)("#ee8aa6")))).V).Put("grads", NewObj(1).Put("pcr", Arr(Arr(((V)("0")), ((V)("#fff6f8"))), Arr(((V)("0.6")), ((V)("#ffe2ea"))), Arr(((V)("1")), ((V)("#f7c3d1"))))).V).Put("body", Arr(((V)(50D)), ((V)(77D)), ((V)(23D)), ((V)(15.5)))).Put("belly", Arr(((V)(50D)), ((V)(80D)), ((V)(14D)), ((V)(10D)), ((V)("url(#pcr)")))).Put("bellyTurn", (true ? V.True : V.False)).Put("feet", Arr(Arr(((V)(38D)), ((V)(90D))), Arr(((V)(62D)), ((V)(90D))))).Put("pads", Arr(Arr(((V)(0D)), ((V)(3.2)), ((V)(5.6)), ((V)(1.6))))).Put("ears", Arr(NewObj(5).Put("side", ((V)((-1D)))).Put("pivot", Arr(((V)(32D)), ((V)(30D)))).Put("tip", Arr(((V)(27D)), ((V)(13.5)))).Put("d", ((V)("M25 33 Q16 16 28 13 Q38 16 39 27 Z"))).Put("inner", ((V)("M27 28 Q22 18 29 17 Q35 19 35 26 Z"))).V, NewObj(5).Put("side", ((V)(1D))).Put("pivot", Arr(((V)(68D)), ((V)(30D)))).Put("tip", Arr(((V)(73D)), ((V)(13.5)))).Put("d", ((V)("M75 33 Q84 16 72 13 Q62 16 61 27 Z"))).Put("inner", ((V)("M73 28 Q78 18 71 17 Q65 19 65 26 Z"))).V)).Put("arms", Arr(NewObj(3).Put("side", ((V)((-1D)))).Put("e", Arr(((V)(30.6)), ((V)(77D)), ((V)(6D)), ((V)(8D)), ((V)(15D)))).Put("pivot", Arr(((V)(32.7)), ((V)(69.3)))).V, NewObj(3).Put("side", ((V)(1D))).Put("e", Arr(((V)(69.4)), ((V)(77D)), ((V)(6D)), ((V)(8D)), ((V)((-15D))))).Put("pivot", Arr(((V)(67.3)), ((V)(69.3)))).V)).Put("tail", Arr(Arr(((V)(72D)), ((V)(78D))), Arr(((V)(86D)), ((V)(77D))), Arr(((V)(89D)), ((V)(65D))), Arr(((V)(84D)), ((V)(57D))))).Put("eyes", Arr(Arr(((V)(37D)), ((V)(43.5))), Arr(((V)(63D)), ((V)(43.5))))).Put("eyeR", ((V)(5.2))).Put("tail3", Arr(Arr(((V)(50D)), ((V)(80D)), ((V)((-16D)))), Arr(((V)(51.5)), ((V)(79D)), ((V)((-24D)))), Arr(((V)(58D)), ((V)(77D)), ((V)((-28D)))), Arr(((V)(66D)), ((V)(76D)), ((V)((-27D)))), Arr(((V)(73D)), ((V)(75D)), ((V)((-24D)))), Arr(((V)(78D)), ((V)(72D)), ((V)((-21D)))), Arr(((V)(79.5)), ((V)(68.5)), ((V)((-19.5)))), Arr(((V)(77D)), ((V)(66.5)), ((V)((-19.5)))), Arr(((V)(74.5)), ((V)(68D)), ((V)((-20.5)))), Arr(((V)(75.5)), ((V)(71D)), ((V)((-21.5)))), Arr(((V)(78D)), ((V)(71.5)), ((V)((-21D)))))).Put("tailWag", ((V)(1.3))).Put("tailK", ((V)(2.1))).Put("tailTaper", Arr(((V)(1D)), ((V)(0.78)))).Put("tailShade", ((V)("#d9718f"))).Put("muzzle", Arr(((V)(50D)), ((V)(56D)), ((V)(10D)), ((V)(7D)))).Put("nose", V.Null).Put("mouth", Arr(((V)(50D)), ((V)(64.6)), ((V)(4.6)))).Put("cheeks", Arr(Arr(((V)(27D)), ((V)(54D))), Arr(((V)(73D)), ((V)(54D))))).Put("faceExtra", Arr(NewObj(2).Put("d", ((V)("M44.60 56.00 C44.60 54.62 45.36 53.50 46.30 53.50 C47.24 53.50 48.00 54.62 48.00 56.00 C48.00 57.38 47.24 58.50 46.30 58.50 C45.36 58.50 44.60 57.38 44.60 56.00Z"))).Put("fill", ((V)("#b8506e"))).V, NewObj(2).Put("d", ((V)("M52.00 56.00 C52.00 54.62 52.76 53.50 53.70 53.50 C54.64 53.50 55.40 54.62 55.40 56.00 C55.40 57.38 54.64 58.50 53.70 58.50 C52.76 58.50 52.00 57.38 52.00 56.00Z"))).Put("fill", ((V)("#b8506e"))).V, NewObj(3).Put("d", ((V)("M44.50 52.60 C44.50 51.99 45.84 51.50 47.50 51.50 C49.16 51.50 50.50 51.99 50.50 52.60 C50.50 53.21 49.16 53.70 47.50 53.70 C45.84 53.70 44.50 53.21 44.50 52.60Z"))).Put("fill", ((V)("#ffffff"))).Put("op", ((V)(0.45))).V)).Put("whiskers", Arr()).Put("stripes", ((V)(""))).Put("back", ((V)(""))).V);
Set(DEFS_34, "ribbit", NewObj(26).Put("G", ((V)(95.5))).Put("top", ((V)(19D))).Put("head", Arr(((V)(50D)), ((V)(46D)), ((V)(34D)), ((V)(27D)))).Put("neck", Arr(((V)(50D)), ((V)(70D)))).Put("c", NewObj(10).Put("pad", ((V)("#b9e88e"))).Put("inner", ((V)("#9fdb66"))).Put("muzzle", ((V)("#fff2b8"))).Put("nose", ((V)("#3f7a26"))).Put("cheek", ((V)("#ff4f86"))).Put("mouth", ((V)("#6a3a3a"))).Put("whisker", ((V)("none"))).Put("stripe", ((V)("none"))).Put("arm", ((V)("#9fdb66"))).Put("g", Arr(((V)("#ecffc6")), ((V)("#9fdb66")), ((V)("#5fa63a")))).V).Put("grads", NewObj(1).Put("fcr", Arr(Arr(((V)("0")), ((V)("#fffbe2"))), Arr(((V)("0.6")), ((V)("#fff2b8"))), Arr(((V)("1")), ((V)("#f2dc8c"))))).V).Put("body", Arr(((V)(50D)), ((V)(78D)), ((V)(23D)), ((V)(15D)))).Put("belly", Arr(((V)(50D)), ((V)(81D)), ((V)(15D)), ((V)(10D)), ((V)("url(#fcr)")))).Put("bellyTurn", (true ? V.True : V.False)).Put("feet", Arr(Arr(((V)(34D)), ((V)(90D))), Arr(((V)(66D)), ((V)(90D))))).Put("footS", Arr(((V)(10.5)), ((V)(5D)), ((V)(8D)))).Put("pads", Arr(Arr(((V)((-5D))), ((V)(3.2)), ((V)(2.3)), ((V)(2.1))), Arr(((V)(0D)), ((V)(4D)), ((V)(2.3)), ((V)(2.1))), Arr(((V)(5D)), ((V)(3.2)), ((V)(2.3)), ((V)(2.1))))).Put("tufts", Arr(NewObj(6).Put("c", Arr(((V)(33D)), ((V)(31D)))).Put("r", ((V)(12D))).Put("lift", ((V)(3D))).Put("white", Arr(((V)(0D)), ((V)(0D)), ((V)(8D)))).Put("d", ((V)("M21.00 31.00 C21.00 24.37 26.37 19.00 33.00 19.00 C39.63 19.00 45.00 24.37 45.00 31.00 C45.00 37.63 39.63 43.00 33.00 43.00 C26.37 43.00 21.00 37.63 21.00 31.00Z"))).Put("fill", ((V)("url(#g)"))).V, NewObj(6).Put("c", Arr(((V)(67D)), ((V)(31D)))).Put("r", ((V)(12D))).Put("lift", ((V)(3D))).Put("white", Arr(((V)(0D)), ((V)(0D)), ((V)(8D)))).Put("d", ((V)("M55.00 31.00 C55.00 24.37 60.37 19.00 67.00 19.00 C73.63 19.00 79.00 24.37 79.00 31.00 C79.00 37.63 73.63 43.00 67.00 43.00 C60.37 43.00 55.00 37.63 55.00 31.00Z"))).Put("fill", ((V)("url(#g)"))).V)).Put("eyeDome", (true ? V.True : V.False)).Put("ears", Arr()).Put("arms", Arr(NewObj(3).Put("side", ((V)((-1D)))).Put("e", Arr(((V)(30.6)), ((V)(77D)), ((V)(5.5)), ((V)(8D)), ((V)(15D)))).Put("pivot", Arr(((V)(33.1)), ((V)(69.5)))).V, NewObj(3).Put("side", ((V)(1D))).Put("e", Arr(((V)(69.4)), ((V)(77D)), ((V)(5.5)), ((V)(8D)), ((V)((-15D))))).Put("pivot", Arr(((V)(66.9)), ((V)(69.5)))).V)).Put("eyes", Arr(Arr(((V)(33.5)), ((V)(32D))), Arr(((V)(66.5)), ((V)(32D))))).Put("eyeR", ((V)(5.6))).Put("muzzle", V.Null).Put("nose", V.Null).Put("mouth", Arr(((V)(50D)), ((V)(52.4)), ((V)(3.8)))).Put("cheeks", Arr(Arr(((V)(26D)), ((V)(56D))), Arr(((V)(74D)), ((V)(56D))))).Put("faceExtra", Arr(NewObj(3).Put("d", ((V)("M41.80 37.00 C41.80 35.78 42.78 34.80 44.00 34.80 C45.22 34.80 46.20 35.78 46.20 37.00 C46.20 38.22 45.22 39.20 44.00 39.20 C42.78 39.20 41.80 38.22 41.80 37.00Z"))).Put("fill", ((V)("#5f9e38"))).Put("op", ((V)(0.45))).V, NewObj(3).Put("d", ((V)("M55.40 38.50 C55.40 37.62 56.12 36.90 57.00 36.90 C57.88 36.90 58.60 37.62 58.60 38.50 C58.60 39.38 57.88 40.10 57.00 40.10 C56.12 40.10 55.40 39.38 55.40 38.50Z"))).Put("fill", ((V)("#5f9e38"))).Put("op", ((V)(0.45))).V, NewObj(3).Put("d", ((V)("M21.20 48.00 C21.20 47.01 22.01 46.20 23.00 46.20 C23.99 46.20 24.80 47.01 24.80 48.00 C24.80 48.99 23.99 49.80 23.00 49.80 C22.01 49.80 21.20 48.99 21.20 48.00Z"))).Put("fill", ((V)("#5f9e38"))).Put("op", ((V)(0.45))).V, NewObj(3).Put("d", ((V)("M75.00 47.00 C75.00 45.90 75.90 45.00 77.00 45.00 C78.10 45.00 79.00 45.90 79.00 47.00 C79.00 48.10 78.10 49.00 77.00 49.00 C75.90 49.00 75.00 48.10 75.00 47.00Z"))).Put("fill", ((V)("#5f9e38"))).Put("op", ((V)(0.45))).V, NewObj(2).Put("d", ((V)("M45.60 47.00 C45.60 46.50 46.00 46.10 46.50 46.10 C47.00 46.10 47.40 46.50 47.40 47.00 C47.40 47.50 47.00 47.90 46.50 47.90 C46.00 47.90 45.60 47.50 45.60 47.00Z"))).Put("fill", ((V)("#3f7a26"))).V, NewObj(2).Put("d", ((V)("M52.60 47.00 C52.60 46.50 53.00 46.10 53.50 46.10 C54.00 46.10 54.40 46.50 54.40 47.00 C54.40 47.50 54.00 47.90 53.50 47.90 C53.00 47.90 52.60 47.50 52.60 47.00Z"))).Put("fill", ((V)("#3f7a26"))).V)).Put("whiskers", Arr()).Put("stripes", ((V)(""))).Put("back", ((V)(""))).V);
REST_35 = NewObj(53).Put("sblur", ((V)(0D))).Put("x", ((V)(0D))).Put("lift", ((V)(0D))).Put("tilt", ((V)(0D))).Put("sq", ((V)(0D))).Put("lean", ((V)(0D))).Put("bend", ((V)(0D))).Put("spin", ((V)(0D))).Put("turn", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("twist", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("wag", ((V)(0D))).Put("curl", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("close", ((V)(0D))).Put("sl", ((V)(0D))).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).Put("hap", ((V)(0D))).Put("wide", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("frown", ((V)(0D))).Put("blush", ((V)(0D))).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hLz", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("hRz", ((V)(0D))).Put("puff", ((V)(0D))).Put("tongue", ((V)(0D))).Put("sqz", ((V)(0D))).Put("cross", ((V)(0D))).Put("teary", ((V)(0D))).Put("red", ((V)(0D))).Put("green", ((V)(0D))).Put("sit", ((V)(0D))).Put("bristle", ((V)(0D))).Put("dbb", ((V)(0D))).Put("dbh", ((V)(0D))).Put("dbs", ((V)(0D))).Put("wsk", ((V)(0D))).V;
AR_36 = Fn((V _arrowThis6443, int _argc6436, V K_6442, V _a6439, V _a6440, V _a6441, V[] _rest6437) => {
return NewObj(2).Put("armL", K_6442).Put("armR", K_6442).V;
}, 1, "", true);
ER_37 = Fn((V _arrowThis6451, int _argc6444, V K_6450, V _a6447, V _a6448, V _a6449, V[] _rest6445) => {
return NewObj(2).Put("earL", K_6450).Put("earR", K_6450).V;
}, 1, "", true);
STATES_38 = NewObj(8).Put("idle", NewObj(3).Put("loop", ((V)(8400D))).Put("look", (true ? V.True : V.False)).Put("k", NewObj(5).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2100D)), ((V)((-0.025))), ((V)("s"))), Arr(((V)(4200D)), ((V)(0.012)), ((V)("s"))), Arr(((V)(6300D)), ((V)((-0.025))), ((V)("s"))), Arr(((V)(8400D)), ((V)(0D)), ((V)("s"))))).Put("lean", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2100D)), ((V)(0.9)), ((V)("s"))), Arr(((V)(4200D)), ((V)(0D)), ((V)("s"))), Arr(((V)(6300D)), ((V)((-0.9))), ((V)("s"))), Arr(((V)(8400D)), ((V)(0D)), ((V)("s"))))).Put("htilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2100D)), ((V)(1.4)), ((V)("s"))), Arr(((V)(4200D)), ((V)(0D)), ((V)("s"))), Arr(((V)(6300D)), ((V)((-1.4))), ((V)("s"))), Arr(((V)(8400D)), ((V)(0D)), ((V)("s"))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2100D)), ((V)(9D)), ((V)("s"))), Arr(((V)(4200D)), ((V)(0D)), ((V)("s"))), Arr(((V)(6300D)), ((V)((-9D))), ((V)("s"))), Arr(((V)(8400D)), ((V)(0D)), ((V)("s"))))).Put("earR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(5200D)), ((V)(0D))), Arr(((V)(5280D)), ((V)((-9D))), ((V)("o"))), Arr(((V)(5420D)), ((V)(4D)), ((V)("io"))), Arr(((V)(5600D)), ((V)(0D)), ((V)("io"))))).V).V).Put("look", NewObj(3).Put("dur", ((V)(6000D))).Put("ev", Arr(Arr(((V)(1950D)), ((V)("blink"))), Arr(((V)(4500D)), ((V)("blink"))))).Put("k", NewObj(11).Put("lx", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0D))), Arr(((V)(380D)), ((V)((-1D))), ((V)("o"))), Arr(((V)(1700D)), ((V)((-1D)))), Arr(((V)(1880D)), ((V)(1D)), ((V)("io"))), Arr(((V)(3200D)), ((V)(1D))), Arr(((V)(3380D)), ((V)(0D)), ((V)("io"))))).Put("ly", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(3400D)), ((V)(0D))), Arr(((V)(3580D)), ((V)((-1D))), ((V)("o"))), Arr(((V)(4400D)), ((V)((-1D)))), Arr(((V)(4580D)), ((V)(0.8)), ((V)("io"))), Arr(((V)(5200D)), ((V)(0.8))), Arr(((V)(5400D)), ((V)(0D)), ((V)("io"))))).Put("turn", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(330D)), ((V)(0D))), Arr(((V)(850D)), ((V)((-0.97))), ((V)("io"))), Arr(((V)(1050D)), ((V)((-0.9))), ((V)("io"))), Arr(((V)(1950D)), ((V)((-0.9)))), Arr(((V)(2550D)), ((V)(0.97)), ((V)("io"))), Arr(((V)(2750D)), ((V)(0.9)), ((V)("io"))), Arr(((V)(3300D)), ((V)(0.9))), Arr(((V)(3750D)), ((V)((-0.05))), ((V)("io"))), Arr(((V)(3950D)), ((V)(0D)), ((V)("io"))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(3450D)), ((V)(0D))), Arr(((V)(3950D)), ((V)(0.7)), ((V)("io"))), Arr(((V)(4450D)), ((V)(0.7))), Arr(((V)(4950D)), ((V)((-0.5))), ((V)("io"))), Arr(((V)(5250D)), ((V)((-0.5)))), Arr(((V)(5800D)), ((V)(0D)), ((V)("io"))))).Put("htilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(330D)), ((V)(0D))), Arr(((V)(900D)), ((V)((-4D))), ((V)("io"))), Arr(((V)(1950D)), ((V)((-4D)))), Arr(((V)(2600D)), ((V)(4D)), ((V)("io"))), Arr(((V)(3300D)), ((V)(4D))), Arr(((V)(3800D)), ((V)(0D)), ((V)("io"))))).Put("lean", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(350D)), ((V)(0D))), Arr(((V)(950D)), ((V)((-1.5))), ((V)("io"))), Arr(((V)(1950D)), ((V)((-1.5)))), Arr(((V)(2650D)), ((V)(1.5)), ((V)("io"))), Arr(((V)(3300D)), ((V)(1.5))), Arr(((V)(3800D)), ((V)(0D)), ((V)("io"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(3450D)), ((V)(0D))), Arr(((V)(3950D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(4450D)), ((V)((-0.04)))), Arr(((V)(4950D)), ((V)(0.03)), ((V)("io"))), Arr(((V)(5250D)), ((V)(0.03))), Arr(((V)(5800D)), ((V)(0D)), ((V)("io"))))).Put("armL", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(330D)), ((V)(0D))), Arr(((V)(850D)), ((V)(10D)), ((V)("io"))), Arr(((V)(1950D)), ((V)(10D))), Arr(((V)(2550D)), ((V)(0D)), ((V)("io"))))).Put("armR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(1950D)), ((V)(0D))), Arr(((V)(2550D)), ((V)(10D)), ((V)("io"))), Arr(((V)(3300D)), ((V)(10D))), Arr(((V)(3750D)), ((V)(0D)), ((V)("io"))))).Put("footL", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(350D)), ((V)(0D))), Arr(((V)(550D)), ((V)(2.2)), ((V)("o"))), Arr(((V)(750D)), ((V)(0D)), ((V)("io"))), Arr(((V)(2000D)), ((V)(0D))), Arr(((V)(2200D)), ((V)(2.2)), ((V)("o"))), Arr(((V)(2400D)), ((V)(0D)), ((V)("io"))), Arr(((V)(3350D)), ((V)(0D))), Arr(((V)(3550D)), ((V)(1.6)), ((V)("o"))), Arr(((V)(3750D)), ((V)(0D)), ((V)("io"))))).Put("footR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(500D)), ((V)(0D))), Arr(((V)(700D)), ((V)(2.2)), ((V)("o"))), Arr(((V)(900D)), ((V)(0D)), ((V)("io"))), Arr(((V)(2150D)), ((V)(0D))), Arr(((V)(2350D)), ((V)(2.2)), ((V)("o"))), Arr(((V)(2550D)), ((V)(0D)), ((V)("io"))), Arr(((V)(3500D)), ((V)(0D))), Arr(((V)(3700D)), ((V)(1.6)), ((V)("o"))), Arr(((V)(3900D)), ((V)(0D)), ((V)("io"))))).V).V).Put("squish", NewObj(3).Put("dur", ((V)(5400D))).Put("loop", ((V)(1800D))).Put("k", NewObj(8).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)((-0.05))), ((V)("o"))), Arr(((V)(480D)), ((V)(0.38)), ((V)("io"))), Arr(((V)(900D)), ((V)(0.4)), ((V)("l"))), Arr(((V)(1030D)), ((V)((-0.18))), ((V)("o"))), Arr(((V)(1180D)), ((V)(0.08)), ((V)("io"))), Arr(((V)(1340D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(1520D)), ((V)(0D)), ((V)("io"))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(330D)), ((V)(0D))), Arr(((V)(450D)), ((V)(0.85)), ((V)("o"))), Arr(((V)(920D)), ((V)(0.85))), Arr(((V)(1040D)), ((V)(0D)), ((V)("o"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(1000D)), ((V)(0D))), Arr(((V)(1100D)), ((V)(1D)), ((V)("o"))), Arr(((V)(1500D)), ((V)(1D))), Arr(((V)(1800D)), ((V)(0D)), ((V)("io"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(1000D)), ((V)(0D))), Arr(((V)(1080D)), ((V)(0.45)), ((V)("o"))), Arr(((V)(1400D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(980D)), ((V)(0D))), Arr(((V)(1110D)), ((V)(3.5)), ((V)("o"))), Arr(((V)(1240D)), ((V)(0D)), ((V)("i"))))).Spread(Call(AR_36, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(480D)), ((V)(18D)), ((V)("io"))), Arr(((V)(900D)), ((V)(20D))), Arr(((V)(1050D)), ((V)((-4D))), ((V)("o"))), Arr(((V)(1300D)), ((V)(0D)), ((V)("io")))))).Spread(Call(ER_37, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(480D)), ((V)(12D)), ((V)("io"))), Arr(((V)(900D)), ((V)(14D))), Arr(((V)(1050D)), ((V)((-6D))), ((V)("o"))), Arr(((V)(1300D)), ((V)(0D)), ((V)("io")))))).Put("blush", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(600D)), ((V)(0.6)), ((V)("io"))), Arr(((V)(1000D)), ((V)(0.6))), Arr(((V)(1500D)), ((V)(0D)), ((V)("io"))))).V).V).Put("spin", NewObj(3).Put("dur", ((V)(5400D))).Put("ev", Arr(Arr(((V)(1750D)), ((V)("blink"))), Arr(((V)(4450D)), ((V)("blink"))))).Put("k", NewObj(7).Put("spin", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0D))), Arr(((V)(500D)), ((V)((-25D))), ((V)("io"))), Arr(((V)(1450D)), ((V)(375D)), ((V)("io"))), Arr(((V)(1700D)), ((V)(360D)), ((V)("io"))), Arr(((V)(2900D)), ((V)(360D))), Arr(((V)(3200D)), ((V)(335D)), ((V)("io"))), Arr(((V)(4150D)), ((V)(735D)), ((V)("io"))), Arr(((V)(4400D)), ((V)(720D)), ((V)("io"))))).Put("turn", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0D))), Arr(((V)(500D)), ((V)(0.3)), ((V)("io"))), Arr(((V)(900D)), ((V)((-0.5))), ((V)("io"))), Arr(((V)(1450D)), ((V)(0.4)), ((V)("io"))), Arr(((V)(1800D)), ((V)(0D)), ((V)("io"))), Arr(((V)(2900D)), ((V)(0D))), Arr(((V)(3200D)), ((V)(0.3)), ((V)("io"))), Arr(((V)(3600D)), ((V)((-0.5))), ((V)("io"))), Arr(((V)(4150D)), ((V)(0.4)), ((V)("io"))), Arr(((V)(4500D)), ((V)(0D)), ((V)("io"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0D))), Arr(((V)(500D)), ((V)(0.14)), ((V)("io"))), Arr(((V)(700D)), ((V)((-0.1))), ((V)("o"))), Arr(((V)(1250D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(1450D)), ((V)(0.14)), ((V)("o"))), Arr(((V)(1600D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(1800D)), ((V)(0D)), ((V)("io"))), Arr(((V)(2900D)), ((V)(0D))), Arr(((V)(3200D)), ((V)(0.14)), ((V)("io"))), Arr(((V)(3400D)), ((V)((-0.1))), ((V)("o"))), Arr(((V)(3950D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(4150D)), ((V)(0.14)), ((V)("o"))), Arr(((V)(4300D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(4500D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(550D)), ((V)(0D))), Arr(((V)(850D)), ((V)(4D)), ((V)("o"))), Arr(((V)(1200D)), ((V)(4D))), Arr(((V)(1450D)), ((V)(0D)), ((V)("i"))), Arr(((V)(3250D)), ((V)(0D))), Arr(((V)(3550D)), ((V)(4D)), ((V)("o"))), Arr(((V)(3900D)), ((V)(4D))), Arr(((V)(4150D)), ((V)(0D)), ((V)("i"))))).Spread(Call(AR_36, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(500D)), ((V)((-8D))), ((V)("io"))), Arr(((V)(750D)), ((V)(35D)), ((V)("o"))), Arr(((V)(1300D)), ((V)(35D))), Arr(((V)(1500D)), ((V)(0D)), ((V)("io"))), Arr(((V)(2900D)), ((V)(0D))), Arr(((V)(3200D)), ((V)((-8D))), ((V)("io"))), Arr(((V)(3450D)), ((V)(35D)), ((V)("o"))), Arr(((V)(4000D)), ((V)(35D))), Arr(((V)(4200D)), ((V)(0D)), ((V)("io")))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(700D)), ((V)(0.7)), ((V)("io"))), Arr(((V)(1700D)), ((V)(0.7))), Arr(((V)(2100D)), ((V)(0D)), ((V)("io"))), Arr(((V)(2900D)), ((V)(0D))), Arr(((V)(3400D)), ((V)(0.7)), ((V)("io"))), Arr(((V)(4400D)), ((V)(0.7))), Arr(((V)(4800D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(700D)), ((V)(1D)), ((V)("io"))), Arr(((V)(1700D)), ((V)(1D))), Arr(((V)(2100D)), ((V)(0D)), ((V)("io"))), Arr(((V)(2900D)), ((V)(0D))), Arr(((V)(3400D)), ((V)(1D)), ((V)("io"))), Arr(((V)(4400D)), ((V)(1D))), Arr(((V)(4800D)), ((V)(0D)), ((V)("io"))))).V).V).Put("hop", NewObj(3).Put("dur", ((V)(5700D))).Put("loop", ((V)(1900D))).Put("k", NewObj(7).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(0D))), Arr(((V)(330D)), ((V)(0.24)), ((V)("io"))), Arr(((V)(410D)), ((V)((-0.2))), ((V)("o"))), Arr(((V)(640D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(780D)), ((V)((-0.12))), ((V)("i"))), Arr(((V)(820D)), ((V)(0.3)), ((V)("o"))), Arr(((V)(960D)), ((V)((-0.07))), ((V)("io"))), Arr(((V)(1100D)), ((V)(0.035)), ((V)("io"))), Arr(((V)(1260D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(380D)), ((V)(0D))), Arr(((V)(620D)), ((V)(18D)), ((V)("o"))), Arr(((V)(820D)), ((V)(0D)), ((V)("i"))))).Spread(Call(AR_36, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(330D)), ((V)((-12D))), ((V)("io"))), Arr(((V)(460D)), ((V)(38D)), ((V)("o"))), Arr(((V)(700D)), ((V)(26D)), ((V)("io"))), Arr(((V)(830D)), ((V)((-8D))), ((V)("o"))), Arr(((V)(1050D)), ((V)(0D)), ((V)("io")))))).Spread(Call(ER_37, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(330D)), ((V)((-6D))), ((V)("io"))), Arr(((V)(450D)), ((V)(10D)), ((V)("o"))), Arr(((V)(650D)), ((V)(2D)), ((V)("io"))), Arr(((V)(830D)), ((V)(12D)), ((V)("o"))), Arr(((V)(1000D)), ((V)((-3D))), ((V)("io"))), Arr(((V)(1200D)), ((V)(0D)), ((V)("io")))))).Put("ly", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(250D)), ((V)(0.4)), ((V)("io"))), Arr(((V)(450D)), ((V)((-0.6))), ((V)("o"))), Arr(((V)(850D)), ((V)(0.2)), ((V)("io"))), Arr(((V)(1200D)), ((V)(0D)), ((V)("io"))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(330D)), ((V)((-0.2))), ((V)("io"))), Arr(((V)(500D)), ((V)(0.3)), ((V)("o"))), Arr(((V)(820D)), ((V)((-0.2))), ((V)("io"))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(0.6)), ((V)("io"))), Arr(((V)(430D)), ((V)(0D)), ((V)("io"))), Arr(((V)(800D)), ((V)(0D))), Arr(((V)(840D)), ((V)(0.6)), ((V)("o"))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).V).Put("happy", NewObj(3).Put("dur", ((V)(7200D))).Put("loop", ((V)(2400D))).Put("k", NewObj(10).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0.2)), ((V)("io"))), Arr(((V)(270D)), ((V)((-0.16))), ((V)("o"))), Arr(((V)(480D)), ((V)((-0.02))), ((V)("io"))), Arr(((V)(600D)), ((V)((-0.1))), ((V)("i"))), Arr(((V)(640D)), ((V)(0.26)), ((V)("o"))), Arr(((V)(760D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(860D)), ((V)(0.18)), ((V)("io"))), Arr(((V)(930D)), ((V)((-0.16))), ((V)("o"))), Arr(((V)(1140D)), ((V)((-0.02))), ((V)("io"))), Arr(((V)(1260D)), ((V)((-0.1))), ((V)("i"))), Arr(((V)(1300D)), ((V)(0.26)), ((V)("o"))), Arr(((V)(1440D)), ((V)((-0.06))), ((V)("io"))), Arr(((V)(1600D)), ((V)(0.03)), ((V)("io"))), Arr(((V)(1800D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(240D)), ((V)(0D))), Arr(((V)(440D)), ((V)(13D)), ((V)("o"))), Arr(((V)(640D)), ((V)(0D)), ((V)("i"))), Arr(((V)(900D)), ((V)(0D))), Arr(((V)(1100D)), ((V)(13D)), ((V)("o"))), Arr(((V)(1300D)), ((V)(0D)), ((V)("i"))))).Put("tilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(240D)), ((V)(0D))), Arr(((V)(440D)), ((V)((-7D))), ((V)("io"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))), Arr(((V)(900D)), ((V)(0D))), Arr(((V)(1100D)), ((V)(7D)), ((V)("io"))), Arr(((V)(1360D)), ((V)(0D)), ((V)("io"))))).Put("htilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(440D)), ((V)((-3D))), ((V)("io"))), Arr(((V)(720D)), ((V)(4D)), ((V)("io"))), Arr(((V)(900D)), ((V)(0D)), ((V)("io"))), Arr(((V)(1100D)), ((V)(3D)), ((V)("io"))), Arr(((V)(1380D)), ((V)((-4D))), ((V)("io"))), Arr(((V)(1600D)), ((V)(0D)), ((V)("io"))))).Spread(Call(AR_36, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)((-8D))), ((V)("io"))), Arr(((V)(330D)), ((V)(48D)), ((V)("o"))), Arr(((V)(640D)), ((V)(40D))), Arr(((V)(700D)), ((V)(24D)), ((V)("io"))), Arr(((V)(860D)), ((V)((-6D))), ((V)("io"))), Arr(((V)(990D)), ((V)(48D)), ((V)("o"))), Arr(((V)(1300D)), ((V)(40D))), Arr(((V)(1400D)), ((V)(24D)), ((V)("io"))), Arr(((V)(1800D)), ((V)(0D)), ((V)("io")))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(16D)), ((V)("io"))), Arr(((V)(600D)), ((V)((-16D))), ((V)("io"))), Arr(((V)(900D)), ((V)(16D)), ((V)("io"))), Arr(((V)(1200D)), ((V)((-16D))), ((V)("io"))), Arr(((V)(1500D)), ((V)(16D)), ((V)("io"))), Arr(((V)(1800D)), ((V)((-16D))), ((V)("io"))), Arr(((V)(2100D)), ((V)(10D)), ((V)("io"))), Arr(((V)(2400D)), ((V)(0D)), ((V)("io"))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(1D))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(1D))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0.5))))).Put("ly", Arr(Arr(((V)(0D)), ((V)((-0.3)))))).V).V).Put("surprised", NewObj(3).Put("dur", ((V)(5200D))).Put("ev", Arr(Arr(((V)(2400D)), ((V)("blink2"))))).Put("k", NewObj(14).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0D))), Arr(((V)(280D)), ((V)(0.16)), ((V)("o"))), Arr(((V)(380D)), ((V)((-0.2))), ((V)("o"))), Arr(((V)(700D)), ((V)((-0.12))), ((V)("io"))), Arr(((V)(900D)), ((V)(0.12)), ((V)("o"))), Arr(((V)(1050D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(1200D)), ((V)(0D)), ((V)("io"))), Arr(((V)(3700D)), ((V)(0D))), Arr(((V)(3800D)), ((V)(0.1)), ((V)("o"))), Arr(((V)(3900D)), ((V)((-0.15))), ((V)("o"))), Arr(((V)(4200D)), ((V)((-0.05))), ((V)("io"))), Arr(((V)(4350D)), ((V)(0.08)), ((V)("o"))), Arr(((V)(4550D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(0D))), Arr(((V)(560D)), ((V)(9D)), ((V)("o"))), Arr(((V)(880D)), ((V)(0D)), ((V)("i"))), Arr(((V)(3820D)), ((V)(0D))), Arr(((V)(4020D)), ((V)(6D)), ((V)("o"))), Arr(((V)(4300D)), ((V)(0D)), ((V)("i"))))).Put("x", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(0D))), Arr(((V)(880D)), ((V)((-7D))), ((V)("o"))), Arr(((V)(2500D)), ((V)((-7D)))), Arr(((V)(3300D)), ((V)(0D)), ((V)("io"))))).Put("lean", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(0D))), Arr(((V)(500D)), ((V)((-5D))), ((V)("o"))), Arr(((V)(880D)), ((V)((-2D))), ((V)("io"))), Arr(((V)(1100D)), ((V)(1.5)), ((V)("io"))), Arr(((V)(1400D)), ((V)(0D)), ((V)("io"))))).Put("tilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(0D))), Arr(((V)(500D)), ((V)((-7D))), ((V)("o"))), Arr(((V)(900D)), ((V)((-2D))), ((V)("io"))), Arr(((V)(1300D)), ((V)(0D)), ((V)("io"))))).Put("wide", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(280D)), ((V)(0D))), Arr(((V)(340D)), ((V)(1D)), ((V)("o"))), Arr(((V)(2300D)), ((V)(1D))), Arr(((V)(2700D)), ((V)(0.3)), ((V)("io"))), Arr(((V)(3700D)), ((V)(0.3))), Arr(((V)(3800D)), ((V)(1D)), ((V)("o"))), Arr(((V)(4500D)), ((V)(1D))), Arr(((V)(4900D)), ((V)(0D)), ((V)("io"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(280D)), ((V)(0D))), Arr(((V)(360D)), ((V)(0.7)), ((V)("o"))), Arr(((V)(1900D)), ((V)(0.65))), Arr(((V)(2300D)), ((V)(0.15)), ((V)("io"))), Arr(((V)(3700D)), ((V)(0.1))), Arr(((V)(3800D)), ((V)(0.65)), ((V)("o"))), Arr(((V)(4500D)), ((V)(0.55))), Arr(((V)(4900D)), ((V)(0D)), ((V)("io"))))).Put("mw", Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(280D)), ((V)(1D))), Arr(((V)(360D)), ((V)(0.6)), ((V)("o"))), Arr(((V)(2300D)), ((V)(0.6))), Arr(((V)(2700D)), ((V)(1D)), ((V)("io"))), Arr(((V)(3700D)), ((V)(1D))), Arr(((V)(3800D)), ((V)(0.6)), ((V)("o"))), Arr(((V)(4500D)), ((V)(0.6))), Arr(((V)(4900D)), ((V)(1D)), ((V)("io"))))).Spread(Call(AR_36, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(280D)), ((V)(0D))), Arr(((V)(380D)), ((V)(34D)), ((V)("o"))), Arr(((V)(1900D)), ((V)(30D))), Arr(((V)(2400D)), ((V)(8D)), ((V)("io"))), Arr(((V)(3700D)), ((V)(8D))), Arr(((V)(3800D)), ((V)(34D)), ((V)("o"))), Arr(((V)(4500D)), ((V)(30D))), Arr(((V)(4900D)), ((V)(0D)), ((V)("io")))))).Spread(Call(ER_37, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(280D)), ((V)(0D))), Arr(((V)(380D)), ((V)((-12D))), ((V)("o"))), Arr(((V)(1700D)), ((V)((-10D)))), Arr(((V)(2100D)), ((V)(0D)), ((V)("io"))), Arr(((V)(3700D)), ((V)(0D))), Arr(((V)(3800D)), ((V)((-10D))), ((V)("o"))), Arr(((V)(4500D)), ((V)((-8D)))), Arr(((V)(4900D)), ((V)(0D)), ((V)("io")))))).Put("lx", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2500D)), ((V)(0D))), Arr(((V)(2650D)), ((V)((-0.9))), ((V)("o"))), Arr(((V)(3000D)), ((V)((-0.9)))), Arr(((V)(3150D)), ((V)(0.9)), ((V)("io"))), Arr(((V)(3550D)), ((V)(0.9))), Arr(((V)(3700D)), ((V)(0D)), ((V)("io"))))).Put("turn", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2550D)), ((V)(0D))), Arr(((V)(2900D)), ((V)((-0.35))), ((V)("io"))), Arr(((V)(3100D)), ((V)((-0.35)))), Arr(((V)(3450D)), ((V)(0.35)), ((V)("io"))), Arr(((V)(3600D)), ((V)(0.35))), Arr(((V)(3800D)), ((V)(0D)), ((V)("io"))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(0D))), Arr(((V)(450D)), ((V)(0.25)), ((V)("o"))), Arr(((V)(1500D)), ((V)(0.2))), Arr(((V)(2000D)), ((V)(0D)), ((V)("io"))))).Put("curl", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(350D)), ((V)(0.8)), ((V)("o"))), Arr(((V)(2000D)), ((V)(0.6))), Arr(((V)(2600D)), ((V)(0D)), ((V)("io"))))).V).V).Put("sleep", NewObj(4).Put("dur", ((V)(9000D))).Put("noBlink", (true ? V.True : V.False)).Put("ev", Arr(Arr(((V)(8550D)), ((V)("blink2"))))).Put("k", NewObj(10).Put("open", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(0.9)), ((V)("io"))), Arr(((V)(1100D)), ((V)(0.9))), Arr(((V)(1500D)), ((V)(0D)), ((V)("io"))))).Put("mw", Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(300D)), ((V)(0.75)), ((V)("io"))), Arr(((V)(1100D)), ((V)(0.75))), Arr(((V)(1500D)), ((V)(1D)), ((V)("io"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)((-0.08))), ((V)("io"))), Arr(((V)(1100D)), ((V)((-0.08)))), Arr(((V)(1500D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(2800D)), ((V)(0.05))), Arr(((V)(4100D)), ((V)(0.09)), ((V)("s"))), Arr(((V)(5400D)), ((V)(0.03)), ((V)("s"))), Arr(((V)(6700D)), ((V)(0.09)), ((V)("s"))), Arr(((V)(8000D)), ((V)(0.05)), ((V)("s"))), Arr(((V)(8250D)), ((V)((-0.1))), ((V)("o"))), Arr(((V)(8500D)), ((V)(0.04)), ((V)("io"))), Arr(((V)(8800D)), ((V)(0D)), ((V)("io"))))).Spread(Call(AR_36, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(36D)), ((V)("io"))), Arr(((V)(1100D)), ((V)(36D))), Arr(((V)(1500D)), ((V)(0D)), ((V)("io")))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(0.75)), ((V)("io"))), Arr(((V)(1100D)), ((V)(0.75))), Arr(((V)(1500D)), ((V)(0.45)), ((V)("io"))), Arr(((V)(2000D)), ((V)(0.7)), ((V)("io"))), Arr(((V)(2300D)), ((V)(0.4)), ((V)("io"))), Arr(((V)(2800D)), ((V)(1D)), ((V)("io"))), Arr(((V)(8200D)), ((V)(1D))), Arr(((V)(8450D)), ((V)(0D)), ((V)("o"))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(0.4)), ((V)("io"))), Arr(((V)(1100D)), ((V)(0.4))), Arr(((V)(1600D)), ((V)(0D)), ((V)("io"))), Arr(((V)(2800D)), ((V)((-0.4))), ((V)("io"))), Arr(((V)(8200D)), ((V)((-0.4)))), Arr(((V)(8450D)), ((V)(0D)), ((V)("io"))))).Put("htilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2800D)), ((V)(0D))), Arr(((V)(3300D)), ((V)(7D)), ((V)("io"))), Arr(((V)(8200D)), ((V)(7D))), Arr(((V)(8450D)), ((V)(0D)), ((V)("io"))))).Spread(Call(ER_37, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2800D)), ((V)(8D)), ((V)("io"))), Arr(((V)(8200D)), ((V)(8D))), Arr(((V)(8300D)), ((V)((-6D))), ((V)("o"))), Arr(((V)(8600D)), ((V)(0D)), ((V)("io")))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2800D)), ((V)(0D))), Arr(((V)(3300D)), ((V)(0.3)), ((V)("io"))), Arr(((V)(8200D)), ((V)(0.3))), Arr(((V)(8400D)), ((V)(0D)), ((V)("io"))))).Put("curl", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2800D)), ((V)(0D))), Arr(((V)(3400D)), ((V)((-0.3))), ((V)("io"))), Arr(((V)(8200D)), ((V)((-0.3)))), Arr(((V)(8600D)), ((V)(0D)), ((V)("io"))))).V).V).V;
RELEASE_39 = NewObj(2).Put("dur", ((V)(1000D))).Put("k", NewObj(5).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.2))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.1)), ((V)("io"))), Arr(((V)(390D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(3D)), ((V)("o"))), Arr(((V)(270D)), ((V)(0D)), ((V)("i"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(0.8)), ((V)("o"))), Arr(((V)(700D)), ((V)(0.8))), Arr(((V)(1000D)), ((V)(0D)), ((V)("io"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(0.35)), ((V)("o"))), Arr(((V)(500D)), ((V)(0D)), ((V)("io"))))).Spread(Call(ER_37, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)((-8D))), ((V)("o"))), Arr(((V)(300D)), ((V)(6D)), ((V)("io"))), Arr(((V)(500D)), ((V)(0D)), ((V)("io")))))).V).V;
POKE_40 = Fn((V _arrowThis6459, int _argc6452, V s_6458, V _a6455, V _a6456, V _a6457, V[] _rest6453) => {
return NewObj(2).Put("dur", ((V)(1100D))).Put("k", NewObj(7).Put("dent", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(45D)), ((V)(1D)), ((V)("o"))), Arr(((V)(200D)), ((V)(0.3)), ((V)("io"))), Arr(((V)(460D)), ((V)(0D)), ((V)("io"))))).Put("lean", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(70D)), ((V)((4D * ToNum(s_6458)))), ((V)("o"))), Arr(((V)(300D)), ((V)(((-1.6) * ToNum(s_6458)))), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(40D)), ((V)(1D)), ((V)("o"))), Arr(((V)(170D)), ((V)(1D))), Arr(((V)(300D)), ((V)(0D)), ((V)("io"))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(280D)), ((V)(0D))), Arr(((V)(360D)), ((V)(1D)), ((V)("o"))), Arr(((V)(850D)), ((V)(1D))), Arr(((V)(1050D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(280D)), ((V)(0D))), Arr(((V)(360D)), ((V)(1D)), ((V)("o"))), Arr(((V)(850D)), ((V)(1D))), Arr(((V)(1050D)), ((V)(0D)), ((V)("io"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(280D)), ((V)(0D))), Arr(((V)(360D)), ((V)(0.35)), ((V)("o"))), Arr(((V)(850D)), ((V)(0.3))), Arr(((V)(1050D)), ((V)(0D)), ((V)("io"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(60D)), ((V)(0.06)), ((V)("o"))), Arr(((V)(200D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(380D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(480D)), ((V)((-0.02))), ((V)("io"))), Arr(((V)(580D)), ((V)(0.04)), ((V)("io"))), Arr(((V)(680D)), ((V)((-0.01))), ((V)("io"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))).V).V;
}, 1, "", true);
HYAW_41 = New(G("Set"), Arr());
SOFT_42 = New(G("Set"), Arr(((V)("mittens")), ((V)("biscuit")), ((V)("prickle")), ((V)("nibbles")), ((V)("quill")), ((V)("poppy")), ((V)("duchess")), ((V)("mamapaws")), ((V)("waffles")), ((V)("truffle")), ((V)("ribbit"))));
DENT_44 = NewObj(2).Put("dur", ((V)(600D))).Put("k", NewObj(2).Put("dent", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(45D)), ((V)(1D)), ((V)("o"))), Arr(((V)(200D)), ((V)(0.3)), ((V)("io"))), Arr(((V)(460D)), ((V)(0D)), ((V)("io"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(50D)), ((V)(0.05)), ((V)("o"))), Arr(((V)(200D)), ((V)((-0.02))), ((V)("io"))), Arr(((V)(360D)), ((V)(0D)), ((V)("io"))))).V).V;
PRE_49 = NewObj(23).Put("crumb", NewObj(8).Put("n", ((V)(3D))).Put("sp", ((V)(9D))).Put("vy", ((V)((-6D)))).Put("g", ((V)(90D))).Put("life", ((V)(650D))).Put("r", Arr(((V)(0.5)), ((V)(0.9)))).Put("col", Arr(((V)("#d9a35a")), ((V)("#b77a3a")), ((V)("#f0c890")))).Put("kind", ((V)("dot"))).V).Put("drop", NewObj(8).Put("n", ((V)(5D))).Put("sp", ((V)(20D))).Put("vy", ((V)((-16D)))).Put("g", ((V)(80D))).Put("life", ((V)(750D))).Put("r", Arr(((V)(0.7)), ((V)(1.2)))).Put("col", Arr(((V)("#8fd3ff")), ((V)("#bfe8ff")))).Put("kind", ((V)("drop"))).V).Put("splash", NewObj(8).Put("n", ((V)(8D))).Put("sp", ((V)(28D))).Put("vy", ((V)((-28D)))).Put("g", ((V)(95D))).Put("life", ((V)(820D))).Put("r", Arr(((V)(0.8)), ((V)(1.4)))).Put("col", Arr(((V)("#8fd3ff")), ((V)("#bfe8ff")))).Put("kind", ((V)("drop"))).V).Put("tear", NewObj(8).Put("n", ((V)(1D))).Put("sp", ((V)(0.6))).Put("vy", ((V)(3D))).Put("g", ((V)(16D))).Put("life", ((V)(1150D))).Put("r", Arr(((V)(1D)), ((V)(1.2)))).Put("col", Arr(((V)("#8fd3ff")))).Put("kind", ((V)("drop"))).V).Put("gush", NewObj(10).Put("n", ((V)(2D))).Put("sp", ((V)(5D))).Put("vx", ((V)(24D))).Put("vy", ((V)((-15D)))).Put("g", ((V)(75D))).Put("life", ((V)(760D))).Put("r", Arr(((V)(0.9)), ((V)(1.4)))).Put("col", Arr(((V)("#8fd3ff")), ((V)("#bfe8ff")))).Put("kind", ((V)("drop"))).Put("out", ((V)(1D))).V).Put("bubble", NewObj(7).Put("n", ((V)(2D))).Put("sp", ((V)(7D))).Put("vy", ((V)((-9D)))).Put("g", ((V)((-3D)))).Put("life", ((V)(1700D))).Put("r", Arr(((V)(1.2)), ((V)(2.6)))).Put("kind", ((V)("bubble"))).V).Put("bigbubble", NewObj(9).Put("n", ((V)(1D))).Put("sp", ((V)(3D))).Put("vx", ((V)(7D))).Put("vy", ((V)((-6D)))).Put("g", ((V)((-1.5)))).Put("life", ((V)(2600D))).Put("r", Arr(((V)(3.6)), ((V)(4.6)))).Put("kind", ((V)("bubble"))).Put("out", ((V)(1D))).V).Put("spark", NewObj(8).Put("n", ((V)(4D))).Put("sp", ((V)(16D))).Put("vy", ((V)((-6D)))).Put("g", ((V)(0D))).Put("life", ((V)(700D))).Put("r", Arr(((V)(1.4)), ((V)(2.4)))).Put("col", Arr(((V)("#fff3a0")), ((V)("#ffffff")))).Put("kind", ((V)("star"))).V).Put("heart", NewObj(7).Put("n", ((V)(1D))).Put("sp", ((V)(7D))).Put("vy", ((V)((-12D)))).Put("g", ((V)((-2D)))).Put("life", ((V)(1300D))).Put("r", Arr(((V)(0.8)), ((V)(1.1)))).Put("kind", ((V)("heart"))).V).Put("stink", NewObj(8).Put("n", ((V)(1D))).Put("sp", ((V)(7D))).Put("vy", ((V)((-7D)))).Put("g", ((V)((-1D)))).Put("life", ((V)(1900D))).Put("r", Arr(((V)(1D)), ((V)(1.3)))).Put("col", Arr(((V)("#8fae55")), ((V)("#a3c266")))).Put("kind", ((V)("wave"))).V).Put("steam", NewObj(8).Put("n", ((V)(2D))).Put("sp", ((V)(3D))).Put("vy", ((V)((-13D)))).Put("g", ((V)((-4D)))).Put("life", ((V)(900D))).Put("r", Arr(((V)(1.6)), ((V)(2.6)))).Put("col", Arr(((V)("#ffffff")))).Put("kind", ((V)("puff"))).V).Put("foam", NewObj(8).Put("n", ((V)(2D))).Put("sp", ((V)(9D))).Put("vy", ((V)((-3D)))).Put("g", ((V)(0D))).Put("life", ((V)(1300D))).Put("r", Arr(((V)(1.6)), ((V)(2.8)))).Put("col", Arr(((V)("#ffffff")))).Put("kind", ((V)("puff"))).V).Put("seed", NewObj(10).Put("n", ((V)(1D))).Put("sp", ((V)(2D))).Put("vx", ((V)(20D))).Put("vy", ((V)((-10D)))).Put("g", ((V)(70D))).Put("life", ((V)(800D))).Put("r", Arr(((V)(0.7)), ((V)(0.8)))).Put("col", Arr(((V)("#2a1a30")))).Put("kind", ((V)("seed"))).Put("out", ((V)(1D))).V).Put("sneeze", NewObj(8).Put("n", ((V)(9D))).Put("sp", ((V)(20D))).Put("vy", ((V)(2D))).Put("g", ((V)(18D))).Put("life", ((V)(620D))).Put("r", Arr(((V)(0.5)), ((V)(1D)))).Put("col", Arr(((V)("#d6f2fc")), ((V)("#ffffff")))).Put("kind", ((V)("dot"))).V).Put("note", NewObj(8).Put("n", ((V)(1D))).Put("sp", ((V)(9D))).Put("vy", ((V)((-11D)))).Put("g", ((V)((-2D)))).Put("life", ((V)(1400D))).Put("r", Arr(((V)(1D)), ((V)(1D)))).Put("col", Arr(((V)("#8f3cf2")), ((V)("#ff5cc6")), ((V)("#2f7fd6")))).Put("kind", ((V)("note"))).V).Put("sweat", NewObj(8).Put("n", ((V)(1D))).Put("sp", ((V)(0D))).Put("vy", ((V)(2D))).Put("g", ((V)(20D))).Put("life", ((V)(900D))).Put("r", Arr(((V)(1.1)), ((V)(1.1)))).Put("col", Arr(((V)("#8fd3ff")))).Put("kind", ((V)("drop"))).V).Put("duck", NewObj(10).Put("n", ((V)(1D))).Put("sp", ((V)(0D))).Put("vx", ((V)(2.2))).Put("vy", ((V)((-24D)))).Put("g", ((V)(120D))).Put("life", ((V)(3600D))).Put("r", Arr(((V)(1D)), ((V)(1.15)))).Put("kind", ((V)("duck"))).Put("out", ((V)(1D))).Put("hop", ((V)(1D))).V).Put("dust", NewObj(8).Put("n", ((V)(3D))).Put("sp", ((V)(8D))).Put("vy", ((V)((-2D)))).Put("g", ((V)(5D))).Put("life", ((V)(1500D))).Put("r", Arr(((V)(0.35)), ((V)(0.75)))).Put("col", Arr(((V)("#fff1d6")), ((V)("#d2b6f4")), ((V)("#ffffff")))).Put("kind", ((V)("dot"))).V).Put("sprinkle", NewObj(8).Put("n", ((V)(4D))).Put("sp", ((V)(22D))).Put("vy", ((V)((-22D)))).Put("g", ((V)(90D))).Put("life", ((V)(950D))).Put("r", Arr(((V)(0.7)), ((V)(0.9)))).Put("col", Arr(((V)("#ffd84a")), ((V)("#7cc8ff")), ((V)("#9be38a")), ((V)("#ffffff")), ((V)("#ff5cc6")))).Put("kind", ((V)("seed"))).V).Put("salt", NewObj(8).Put("n", ((V)(3D))).Put("sp", ((V)(10D))).Put("vy", ((V)(2D))).Put("g", ((V)(70D))).Put("life", ((V)(900D))).Put("r", Arr(((V)(0.45)), ((V)(0.75)))).Put("col", Arr(((V)("#ffffff")), ((V)("#f2f0ff")), ((V)("#fffbe6")))).Put("kind", ((V)("dot"))).V).Put("ketchup", NewObj(8).Put("n", ((V)(3D))).Put("sp", ((V)(14D))).Put("vy", ((V)((-15D)))).Put("g", ((V)(90D))).Put("life", ((V)(800D))).Put("r", Arr(((V)(0.9)), ((V)(1.4)))).Put("col", Arr(((V)("#e8352a")), ((V)("#ff5a4a")), ((V)("#c8241c")))).Put("kind", ((V)("drop"))).V).Put("coffee", NewObj(8).Put("n", ((V)(4D))).Put("sp", ((V)(18D))).Put("vy", ((V)((-20D)))).Put("g", ((V)(90D))).Put("life", ((V)(800D))).Put("r", Arr(((V)(0.8)), ((V)(1.3)))).Put("col", Arr(((V)("#8a5a3a")), ((V)("#b07a52")))).Put("kind", ((V)("drop"))).V).Put("gust", NewObj(10).Put("n", ((V)(1D))).Put("sp", ((V)(3D))).Put("vx", ((V)(26D))).Put("vy", ((V)((-3D)))).Put("g", ((V)(0D))).Put("life", ((V)(1000D))).Put("r", Arr(((V)(0.9)), ((V)(1.4)))).Put("col", Arr(((V)("#9ad8cc")), ((V)("#7cc8ff")))).Put("kind", ((V)("wisp"))).Put("out", ((V)(1D))).V).V;
DUCK_54 = ((V)("<ellipse cx=\"0.2\" cy=\"-2\" rx=\"3.5\" ry=\"2.3\" fill=\"#e9a512\"/><ellipse cx=\"-0.2\" cy=\"-2.4\" rx=\"3.1\" ry=\"1.9\" fill=\"#ffd43b\"/><path d=\"M-3 -2.6 L-4.5 -4.2 L-2.4 -3.5Z\" fill=\"#ffd43b\"/><path d=\"M-1.6 -2.6 Q0 -1.2 1.4 -2.6\" stroke=\"#e9a512\" stroke-width=\"0.5\" fill=\"none\" stroke-linecap=\"round\"/><circle cx=\"1.95\" cy=\"-4.85\" r=\"1.85\" fill=\"#e9a512\"/><circle cx=\"1.8\" cy=\"-5\" r=\"1.75\" fill=\"#ffd43b\"/><ellipse cx=\"3.7\" cy=\"-4.6\" rx=\"1.05\" ry=\"0.5\" fill=\"#ff8a2a\"/><circle cx=\"2.4\" cy=\"-5.4\" r=\"0.36\" fill=\"#2a1a30\"/><ellipse cx=\"1.1\" cy=\"-5.8\" rx=\"0.6\" ry=\"0.35\" fill=\"#fff8d0\"/><ellipse cx=\"-1.2\" cy=\"-3.3\" rx=\"1\" ry=\"0.4\" fill=\"#fff8d0\" opacity=\"0.8\"/>"));
bub_55 = Fn((V _arrowThis6470, int _argc6460, V x_6466, V y_6467, V r_6468, V op_6469, V[] _rest6461) => {
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(r2_14, V.Undef, x_6466)).S("\" cy=\"").V(Call(r2_14, V.Undef, y_6467)).S("\" r=\"").V(Call(r2_14, V.Undef, r_6468)).S("\" fill=\"#ffffff\" stroke=\"#cfe8f4\" stroke-width=\"0.35\" opacity=\"").V(Call(r2_14, V.Undef, op_6469)).S("\"/><circle cx=\"").V(Call(r2_14, V.Undef, ((V)((ToNum(x_6466) - (ToNum(r_6468) * 0.35)))))).S("\" cy=\"").V(Call(r2_14, V.Undef, ((V)((ToNum(y_6467) - (ToNum(r_6468) * 0.38)))))).S("\" r=\"").V(Call(r2_14, V.Undef, ((V)((ToNum(r_6468) * 0.26))))).S("\" fill=\"#eaf7ff\" opacity=\"").V(Call(r2_14, V.Undef, op_6469)).S("\"/>").End()));
}, 4, "", true);
blinkC_58 = Fn((V _arrowThis6478, int _argc6471, V t_6477, V _a6474, V _a6475, V _a6476, V[] _rest6472) => {
return (LtN(t_6477, 0D) ? ((V)(0D)) : (LtN(t_6477, 75D) ? Invoke(EZ_18, "i", ((V)((ToNum(t_6477) / 75D)))) : ((V)((LtN(t_6477, 105D) ? 1D : (LtN(t_6477, 240D) ? (1D - ToNum(Invoke(EZ_18, "o", ((V)(((ToNum(t_6477) - 105D) / 135D)))))) : 0D))))));
}, 1, "", true);
FX_61 = NewObj(3).Put("sleep", Fn((V _self6479, int _argc6480, V I_6486, V t_6487, V _a6484, V _a6485, V[] _rest6481) => {
JsStrBuf h_6488 = null;
V x0_6489 = default;
V y0_6490 = default;
if (_self6479.IsNullish) _self6479 = GlobalV;
if ((LtN(t_6487, 2900D) || GtN(t_6487, 8150D))) {
return ((V)(""));
}
h_6488 = new JsStrBuf("");
{ V _t6491 = Get(I_6486, "topW");
{ V _t6492 = ListOf(_t6491);
{ V _t6493 = GetIdx(_t6492, 0D);
x0_6489 = _t6493; }
{ V _t6494 = GetIdx(_t6492, 1D);
y0_6490 = _t6494; }
} }
{
double i_6495 = 0;
i_6495 = 0D;
while (true) {
if (!((i_6495 < 3D))) break;
double u_6497 = 0;
V x_6498 = default;
double y_6499 = 0;
u_6497 = ((((ToNum(t_6487) - 2900D) / 2600D) + (i_6495 / 3D)) % 1D);
x_6498 = Add(Add(Add(x0_6489, ((V)(16D))), ((V)((u_6497 * 14D)))), ((V)((FdLibm.Sin((u_6497 * TAU_12)) * 2D))));
y_6499 = (ToNum(Add(y0_6490, ((V)(4D)))) - (u_6497 * 22D));
h_6488.S("<text x=\"").V(Call(r2_14, V.Undef, x_6498)).S("\" y=\"").V(Call(r2_14, V.Undef, ((V)(y_6499)))).S("\" font-family=\"Fredoka,sans-serif\" font-weight=\"700\" font-size=\"").V(Call(r2_14, V.Undef, ((V)((5D + (u_6497 * 5D)))))).S("\" fill=\"#8f3cf2\" stroke=\"#ffffff\" stroke-width=\"0.6\" paint-order=\"stroke\" opacity=\"").V(Call(r2_14, V.Undef, ((V)(FdLibm.Sin((System.Math.PI * u_6497)))))).S("\">z</text>");
i_6495++;
}
}
return ((V)(h_6488.Str));
return default;
}, 2, "sleep", false)).Put("happy", Fn((V _self6500, int _argc6501, V I_6507, V t_6508, V _a6505, V _a6506, V[] _rest6502) => {
JsStrBuf h_6509 = null;
if (_self6500.IsNullish) _self6500 = GlobalV;
h_6509 = new JsStrBuf("");
{
double i_6510 = 0;
i_6510 = 0D;
while (true) {
if (!((i_6510 < 8D))) break;
double a_6512 = 0;
double u_6513 = 0;
double r_6514 = 0;
a_6512 = (((i_6510 / 8D) * TAU_12) + (i_6510 * 0.7));
u_6513 = (((ToNum(t_6508) / 900D) + (i_6510 / 8D)) % 1D);
r_6514 = (36D * (0.55 + (0.45 * u_6513)));
h_6509.S("<path d=\"").V(Call(star4_33, V.Undef, ((V)((50D + (FdLibm.Cos(a_6512) * r_6514)))), ((V)((52D + ((FdLibm.Sin(a_6512) * r_6514) * 0.8)))), ((V)((1.2 + (2.2 * FdLibm.Sin((System.Math.PI * u_6513)))))))).S("\" fill=\"").S((NumTruthy((i_6510 % 2D)) ? "#fff3a0" : "#ffffff")).S("\" opacity=\"").V(Call(r2_14, V.Undef, ((V)(FdLibm.Sin((System.Math.PI * u_6513)))))).S("\"/>");
i_6510++;
}
}
return ((V)(h_6509.Str));
return default;
}, 2, "happy", false)).Put("surprised", Fn((V _self6515, int _argc6516, V I_6522, V t_6523, V _a6520, V _a6521, V[] _rest6517) => {
V u_6524 = default;
V x0_6525 = default;
V y0_6526 = default;
double a_6527 = 0;
JsStrBuf h_6528 = null;
if (_self6515.IsNullish) _self6515 = GlobalV;
u_6524 = Call(clamp_13, V.Undef, ((V)(((ToNum(t_6523) - 300D) / 700D))), ((V)(0D)), ((V)(1D)));
if ((LeN(u_6524, 0D) || GeN(u_6524, 1D))) {
return ((V)(""));
}
{ V _t6529 = Get(I_6522, "topW");
{ V _t6530 = ListOf(_t6529);
{ V _t6531 = GetIdx(_t6530, 0D);
x0_6525 = _t6531; }
{ V _t6532 = GetIdx(_t6530, 1D);
y0_6526 = _t6532; }
} }
a_6527 = FdLibm.Sin((System.Math.PI * ToNum(u_6524)));
h_6528 = new JsStrBuf("");
Invoke(Arr(((V)((-34D))), ((V)(0D)), ((V)(34D))), "forEach", Fn((V _arrowThis6540, int _argc6533, V d_6539, V _a6536, V _a6537, V _a6538, V[] _rest6534) => {
double r_6541 = 0;
double s_6542 = 0;
V x1_6543 = default;
double y1_6544 = 0;
V x2_6545 = default;
double y2_6546 = 0;
r_6541 = (ToNum(d_6539) * D2R_11);
s_6542 = (6D + (ToNum(u_6524) * 4D));
x1_6543 = Add(x0_6525, ((V)((FdLibm.Sin(r_6541) * s_6542))));
y1_6544 = ((ToNum(y0_6526) - 3D) - (FdLibm.Cos(r_6541) * s_6542));
x2_6545 = Add(x0_6525, ((V)((FdLibm.Sin(r_6541) * (s_6542 + 5D)))));
y2_6546 = ((ToNum(y0_6526) - 3D) - (FdLibm.Cos(r_6541) * (s_6542 + 5D)));
h_6528.S("<path d=\"M").V(Call(r2_14, V.Undef, x1_6543)).S(" ").V(Call(r2_14, V.Undef, ((V)(y1_6544)))).S(" L").V(Call(r2_14, V.Undef, x2_6545)).S(" ").V(Call(r2_14, V.Undef, ((V)(y2_6546)))).S("\" stroke=\"#8f3cf2\" stroke-width=\"1.6\" stroke-linecap=\"round\" opacity=\"").V(Call(r2_14, V.Undef, ((V)(a_6527)))).S("\"/>");
return default;
}, 1, "", true));
return ((V)(h_6528.Str));
return default;
}, 2, "surprised", false)).V;
ALL_65 = New(G("Set"));
raf_66 = ((V)(0D));
last_67 = ((V)(0D));
UID_68 = 0D;
kick_70 = Fn((V _arrowThis6553, int _argc6547, V _a6549, V _a6550, V _a6551, V _a6552, V[] _rest6548) => {
if (!(Truthy(raf_66))) {
last_67 = ((V)(0D));
raf_66 = Call(G("requestAnimationFrame"), V.Undef, loop_69);
}
return default;
}, 0, "", true);
Call(G("setInterval"), V.Undef, Fn((V _arrowThis6570, int _argc6564, V _a6566, V _a6567, V _a6568, V _a6569, V[] _rest6565) => {
V n_6561 = default;
n_6561 = Invoke(G("performance"), "now");
if (Truthy((Get(ALL_65, "size") is var _t6571 && !Truthy(_t6571) ? _t6571 : (((ToNum(n_6561) - ToNum(last_67)) > 80D) ? V.True : V.False)))) {
V r_6563 = default;
r_6563 = raf_66;
raf_66 = ((V)(0D));
if (Truthy(r_6563)) {
Call(G("cancelAnimationFrame"), V.Undef, r_6563);
}
Call(loop_69, V.Undef, n_6561);
}
return default;
}, 0, "", true), ((V)(50D)));
LPARTS_71 = Arr(Arr(((V)("mane")), ((V)(40D))), Arr(((V)("tail")), ((V)(16D)), ((V)("tube"))), Arr(((V)("body")), ((V)(36D))), Arr(((V)("earL")), ((V)(18D)), ((V)("tube"))), Arr(((V)("earR")), ((V)(18D)), ((V)("tube"))), Arr(((V)("head")), ((V)(40D))), Arr(((V)("armL")), ((V)(16D))), Arr(((V)("armR")), ((V)(16D))), Arr(((V)("footL")), ((V)(13D))), Arr(((V)("footR")), ((V)(13D))));
LOCC_72 = NewObj(4).Put("body", Arr(Arr(((V)("head")), ((V)(0.75))), Arr(((V)("armL")), ((V)(0.6))), Arr(((V)("armR")), ((V)(0.6))))).Put("footL", Arr(Arr(((V)("body")), ((V)(0.45))))).Put("footR", Arr(Arr(((V)("body")), ((V)(0.45))))).Put("tail", Arr(Arr(((V)("body")), ((V)(0.6))))).V;
LRECT_73 = ((V)("M-90 -110H190V210H-90Z "));
LOOK0_74 = NewObj(7).Put("dir", Arr(((V)(0.75)), ((V)(0.55)))).Put("sh", ((V)(0.5))).Put("rim", ((V)(0.42))).Put("rimC", ((V)("#fff4dc"))).Put("line", ((V)(1.05))).Put("cast", ((V)(0D))).Put("contact", ((V)(1D))).V;
MODES_75 = NewObj(4).Put("1", NewObj(1).Put("line", ((V)(0D))).V).Put("2", NewObj(2).Put("line", ((V)(0.7))).Put("lineC", ((V)("#4a3a2e"))).V).Put("3", NewObj(2).Put("line", ((V)(1.05))).Put("lineC", ((V)("#4a3a2e"))).V).Put("4", NewObj(2).Put("line", ((V)(1.05))).Put("lineC", V.Null).V).V;
LOOK_76 = 4D;
rgbP_77 = Fn((V _arrowThis6579, int _argc6572, V c_6578, V _a6575, V _a6576, V _a6577, V[] _rest6573) => {
V m_6580 = default;
V h_6581 = default;
V x_6582 = default;
m_6580 = Invoke(((V)(ToStrS((c_6578 is var _t6583 && Truthy(_t6583) ? _t6583 : ((V)("")))))), "match", NewRegExp(RX12, "rgba?\\(([\\d.]+),\\s*([\\d.]+),\\s*([\\d.]+)", ""));
if (Truthy(m_6580)) {
return Arr(((V)(ToNum(GetIdx(m_6580, 1D)))), ((V)(ToNum(GetIdx(m_6580, 2D)))), ((V)(ToNum(GetIdx(m_6580, 3D)))));
}
h_6581 = Invoke(((V)(ToStrS((c_6578 is var _t6584 && Truthy(_t6584) ? _t6584 : ((V)("")))))), "match", NewRegExp(RX13, "^#([\\da-f]{3}|[\\da-f]{6})$", "i"));
if (!(Truthy(h_6581))) {
return V.Null;
}
x_6582 = GetIdx(h_6581, 1D);
if (SEqN(Get(x_6582, "length"), 3D)) {
x_6582 = Invoke(x_6582, "replace", NewRegExp(RX14, ".", "g"), ((V)("$&$&")));
}
return Invoke(Arr(((V)(0D)), ((V)(2D)), ((V)(4D))), "map", Fn((V _arrowThis6592, int _argc6585, V i_6591, V _a6588, V _a6589, V _a6590, V[] _rest6586) => {
return ((V)(ParseInt(Invoke(x_6582, "slice", i_6591, Add(i_6591, ((V)(2D)))), ((V)(16D)))));
}, 1, "", true));
return default;
}, 1, "", true);
lineOf_81 = Fn((V _arrowThis6600, int _argc6593, V c_6599, V _a6596, V _a6597, V _a6598, V[] _rest6594) => {
V h_6601 = default;
V s_6602 = default;
V l_6603 = default;
{ V _t6604 = Call(hsl_79, V.Undef, c_6599);
{ V _t6605 = ListOf(_t6604);
{ V _t6606 = GetIdx(_t6605, 0D);
h_6601 = _t6606; }
{ V _t6607 = GetIdx(_t6605, 1D);
s_6602 = _t6607; }
{ V _t6608 = GetIdx(_t6605, 2D);
l_6603 = _t6608; }
} }
if (LtN(s_6602, 0.1)) {
h_6601 = (LtN(s_6602, 0.03) ? ((V)(0.08)) : h_6601);
s_6602 = ((V)(0.22));
}
return Call(hex_80, V.Undef, Arr(h_6601, ((V)(Min(1D, ((ToNum(s_6602) * 1.12) + 0.06)))), ((V)(Max(0.1, Min(0.42, (ToNum(l_6603) * 0.42)))))));
return default;
}, 1, "", true);
shadeOf_82 = Fn((V _arrowThis6616, int _argc6609, V c_6615, V _a6612, V _a6613, V _a6614, V[] _rest6610) => {
V h_6617 = default;
V s_6618 = default;
V l_6619 = default;
{ V _t6620 = Call(hsl_79, V.Undef, c_6615);
{ V _t6621 = ListOf(_t6620);
{ V _t6622 = GetIdx(_t6621, 0D);
h_6617 = _t6622; }
{ V _t6623 = GetIdx(_t6621, 1D);
s_6618 = _t6623; }
{ V _t6624 = GetIdx(_t6621, 2D);
l_6619 = _t6624; }
} }
return Call(hex_80, V.Undef, Arr(h_6617, ((V)(Min(1D, ((ToNum(s_6618) * 1.05) + 0.05)))), ((V)((ToNum(l_6619) * 0.55)))));
return default;
}, 1, "", true);
mixHex_83 = Fn((V _arrowThis6634, int _argc6625, V a_6631, V b_6632, V t_6633, V _a6630, V[] _rest6626) => {
V A_6635 = default;
V B_6636 = default;
A_6635 = Call(rgbP_77, V.Undef, a_6631);
B_6636 = Call(rgbP_77, V.Undef, b_6632);
return Call(hex_80, V.Undef, Call(hsl_79, V.Undef, Invoke(A_6635, "map", Fn((V _arrowThis6645, int _argc6637, V v_6643, V i_6644, V _a6641, V _a6642, V[] _rest6638) => {
return Add(v_6643, ((V)(((ToNum(GetK(B_6636, i_6644)) - ToNum(v_6643)) * ToNum(t_6633)))));
}, 2, "", true))));
return default;
}, 3, "", true);
FACE_85 = New(G("Map"));
SVGNS_90 = ((V)("http://www.w3.org/2000/svg"));
FIDGETS_96 = Arr();
FIDK_97 = NewObj(0).V;
PRESS_98 = NewObj(0).V;
REL_99 = NewObj(0).V;
Set(G("window"), "RiveRig", NewObj(24).Put("v", ((V)(2D))).Put("setLook", Fn((V _arrowThis6653, int _argc6646, V m_6652, V _a6649, V _a6650, V _a6651, V[] _rest6647) => {
LOOK_76 = (SEq(m_6652, (true ? V.True : V.False)) ? 4D : (SEq(m_6652, (false ? V.True : V.False)) ? 0D : Max(0D, Min(4D, ((double)(ToInt32(ToNum(m_6652)) | ToInt32(0D)))))));
Invoke(ALL_65, "forEach", Fn((V _arrowThis6661, int _argc6654, V I_6660, V _a6657, V _a6658, V _a6659, V[] _rest6655) => {
Call(applyLook_86, V.Undef, I_6660);
try {
Call(tick_59, V.Undef, I_6660, Invoke(G("performance"), "now"), ((V)(0.016)));
} catch (System.Exception _ex6662) {
V e_6663 = default;
e_6663 = Caught(_ex6662);

}
return default;
}, 1, "", true));
return default;
}, 1, "setLook", true)).Put("look", Fn((V _arrowThis6670, int _argc6664, V _a6666, V _a6667, V _a6668, V _a6669, V[] _rest6665) => {
return ((V)(LOOK_76));
}, 0, "look", true)).Put("lineOf", lineOf_81).Put("HYAW", HYAW_41).Put("SOFT", SOFT_42).Put("DEFS", DEFS_34).Put("mount", mount_95).Put("STATES", STATES_38).Put("REST", REST_35).Put("FIDGETS", FIDGETS_96).Put("FIDK", FIDK_97).Put("PRESS", PRESS_98).Put("REL", REL_99).Put("PRE", PRE_49).Put("EZ", EZ_18).Put("kv", kv_19).Put("r2", r2_14).Put("star4", star4_33).Put("clamp", clamp_13).Put("SM", SM_16).Put("add", Fn((V _arrowThis6678, int _argc6671, V o_6677, V _a6674, V _a6675, V _a6676, V[] _rest6672) => {
return Object_assign(STATES_38, o_6677);
}, 1, "add", true)).Put("emit", emit_51).Put("tick1", Fn((V _arrowThis6686, int _argc6679, V I_6685, V _a6682, V _a6683, V _a6684, V[] _rest6680) => {
try {
Call(tick_59, V.Undef, I_6685, Invoke(G("performance"), "now"), ((V)(0.016)));
} catch (System.Exception _ex6687) {
V e_6688 = default;
e_6688 = Caught(_ex6687);
if (!(Truthy(Get(I_6685, "err")))) {
Set(I_6685, "err", ((V)(1D)));
Invoke(G("console"), "error", ((V)("RiveRig")), e_6688);
}
}
return default;
}, 1, "tick1", true)).V);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
