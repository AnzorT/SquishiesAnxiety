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
rnd_112 = Fn((V _self100, int _argc119, V _a121, V _a122, V _a123, V _a124, V[] _rest120) => {
return ((V)((sd_111 = ((sd_111 * 16807D) % 2147483647D) / 2147483647D)));
}, 0, "", true);
oct_113 = Fn((V _self100, int _argc125, V n_131, V _a128, V _a129, V _a130, V[] _rest126) => {
V g_132 = default;
double c_133 = 0;
V sm_134 = default;
g_132 = Arr();
{
double i_135 = 0;
i_135 = 0D;
while (true) {
if (!((i_135 < (ToNum(n_131) * ToNum(n_131))))) break;
Invoke(g_132, "push", Call(rnd_112, V.Undef));
i_135++;
}
}
c_133 = (S_107 / ToNum(n_131));
sm_134 = Fn((V _self100, int _argc137, V t_143, V _a140, V _a141, V _a142, V[] _rest138) => {
return ((V)(((ToNum(t_143) * ToNum(t_143)) * (3D - (2D * ToNum(t_143))))));
}, 1, "", true);
return Fn((V _self100, int _argc144, V px_150, V py_151, V _a148, V _a149, V[] _rest145) => {
double gx_152 = 0;
double gy_153 = 0;
double x0_154 = 0;
double y0_155 = 0;
V fx_156 = default;
V fy_157 = default;
V a_158 = default;
V t_159 = default;
V b_160 = default;
gx_152 = (ToNum(px_150) / c_133);
gy_153 = (ToNum(py_151) / c_133);
x0_154 = System.Math.Floor(gx_152);
y0_155 = System.Math.Floor(gy_153);
fx_156 = Call(sm_134, V.Undef, ((V)((gx_152 - x0_154))));
fy_157 = Call(sm_134, V.Undef, ((V)((gy_153 - y0_155))));
a_158 = Fn((V _self100, int _argc161, V i_167, V j_168, V _a165, V _a166, V[] _rest162) => {
return GetIdx(g_132, (((ToNum(Add(((V)((ToNum(j_168) % ToNum(n_131)))), n_131)) % ToNum(n_131)) * ToNum(n_131)) + (ToNum(Add(((V)((ToNum(i_167) % ToNum(n_131)))), n_131)) % ToNum(n_131))));
}, 2, "", true);
t_159 = Add(Call(a_158, V.Undef, ((V)(x0_154)), ((V)(y0_155))), ((V)(((ToNum(Call(a_158, V.Undef, ((V)((x0_154 + 1D))), ((V)(y0_155)))) - ToNum(Call(a_158, V.Undef, ((V)(x0_154)), ((V)(y0_155))))) * ToNum(fx_156)))));
b_160 = Add(Call(a_158, V.Undef, ((V)(x0_154)), ((V)((y0_155 + 1D)))), ((V)(((ToNum(Call(a_158, V.Undef, ((V)((x0_154 + 1D))), ((V)((y0_155 + 1D))))) - ToNum(Call(a_158, V.Undef, ((V)(x0_154)), ((V)((y0_155 + 1D)))))) * ToNum(fx_156)))));
return Add(t_159, ((V)(((ToNum(b_160) - ToNum(t_159)) * ToNum(fy_157)))));
return default;
}, 2, "", true);
return default;
}, 1, "", true);
o1_114 = Call(oct_113, V.Undef, ((V)(32D)));
o2_115 = Call(oct_113, V.Undef, ((V)(64D)));
{
double y_169 = 0;
y_169 = 0D;
while (true) {
if (!((y_169 < S_107))) break;
{
double X_171 = 0;
X_171 = 0D;
while (true) {
if (!((X_171 < S_107))) break;
double v_173 = 0;
double k_174 = 0;
v_173 = (ToNum(Add(Call(o1_114, V.Undef, ((V)(X_171)), ((V)(y_169))), Call(o2_115, V.Undef, ((V)(X_171)), ((V)(y_169))))) / 2D);
k_174 = (((y_169 * S_107) + X_171) * 4D);
SetIdx(Get(im_110, "data"), (k_174 + 3D), ((V)(Round(((0.2 * 255D) * v_173)))));
X_171++;
}
}
y_169++;
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
} catch (System.Exception _ex175) {
V e_176 = default;
e_176 = Caught(_ex175);
FAB_8 = ((V)(""));
}
}
return ((V)((Truthy(FAB_8) ? string.Concat("<feImage href=\"", ToStr(FAB_8), "\" x=\"-30\" y=\"-30\" width=\"160\" height=\"160\" preserveAspectRatio=\"none\"/>") : "<feFlood flood-opacity=\"0\"/>")));
return default;
}, 0, "fabricFx", false);
parsePath_21 = Fn((V _self177, int _argc178, V d_184, V _a181, V _a182, V _a183, V[] _rest179) => {
V tk_185 = default;
double i_186 = 0;
V cmd_187 = default;
V x_188 = default;
V y_189 = default;
V sx_190 = default;
V sy_191 = default;
V @out_192 = default;
V n_193 = default;
if (_self177.IsNullish) _self177 = GlobalV;
tk_185 = (Invoke(d_184, "match", NewRegExp(RX0, "[a-zA-Z]|-?\\d*\\.?\\d+(?:e-?\\d+)?", "g")) is var _t194 && Truthy(_t194) ? _t194 : Arr());
i_186 = 0D;
cmd_187 = ((V)(""));
x_188 = ((V)(0D));
y_189 = ((V)(0D));
sx_190 = ((V)(0D));
sy_191 = ((V)(0D));
@out_192 = Arr();
n_193 = Fn((V _self177, int _argc195, V _a197, V _a198, V _a199, V _a200, V[] _rest196) => {
return ((V)(ToNum(GetIdx(tk_185, i_186++))));
}, 0, "", true);
while (Lt(((V)(i_186)), Get(tk_185, "length"))) {
V C_201 = default;
V rel_202 = default;
V ox_203 = default;
V oy_204 = default;
if (Truthy(Invoke(NewRegExp(RX1, "[a-zA-Z]", ""), "test", GetIdx(tk_185, i_186)))) {
cmd_187 = GetIdx(tk_185, i_186++);
}
C_201 = Invoke(cmd_187, "toUpperCase");
rel_202 = (!SEq(cmd_187, C_201) ? V.True : V.False);
ox_203 = (Truthy(rel_202) ? x_188 : ((V)(0D)));
oy_204 = (Truthy(rel_202) ? y_189 : ((V)(0D)));
if (SEqS(C_201, "Z")) {
Invoke(@out_192, "push", NewObj(1).Put("c", ((V)("Z"))).V);
x_188 = sx_190;
y_189 = sy_191;
continue;
}
if ((SEqS(C_201, "M") || SEqS(C_201, "L"))) {
V p_205 = default;
p_205 = Arr(Add(ox_203, Call(n_193, V.Undef)), Add(oy_204, Call(n_193, V.Undef)));
Invoke(@out_192, "push", NewObj(2).Put("c", C_201).Put("p", Arr(p_205)).V);
{ V _t206 = p_205;
{ V _t207 = ListOf(_t206);
{ V _t208 = GetIdx(_t207, 0D);
x_188 = _t208; }
{ V _t209 = GetIdx(_t207, 1D);
y_189 = _t209; }
} }
if (SEqS(C_201, "M")) {
sx_190 = x_188;
sy_191 = y_189;
cmd_187 = ((V)((Truthy(rel_202) ? "l" : "L")));
}
} else {
if (SEqS(C_201, "Q")) {
V a_210 = default;
V b_211 = default;
a_210 = Arr(Add(ox_203, Call(n_193, V.Undef)), Add(oy_204, Call(n_193, V.Undef)));
b_211 = Arr(Add(ox_203, Call(n_193, V.Undef)), Add(oy_204, Call(n_193, V.Undef)));
Invoke(@out_192, "push", NewObj(2).Put("c", ((V)("Q"))).Put("p", Arr(a_210, b_211)).V);
{ V _t212 = b_211;
{ V _t213 = ListOf(_t212);
{ V _t214 = GetIdx(_t213, 0D);
x_188 = _t214; }
{ V _t215 = GetIdx(_t213, 1D);
y_189 = _t215; }
} }
} else {
if (SEqS(C_201, "C")) {
V a_216 = default;
V b_217 = default;
V c_218 = default;
a_216 = Arr(Add(ox_203, Call(n_193, V.Undef)), Add(oy_204, Call(n_193, V.Undef)));
b_217 = Arr(Add(ox_203, Call(n_193, V.Undef)), Add(oy_204, Call(n_193, V.Undef)));
c_218 = Arr(Add(ox_203, Call(n_193, V.Undef)), Add(oy_204, Call(n_193, V.Undef)));
Invoke(@out_192, "push", NewObj(2).Put("c", ((V)("C"))).Put("p", Arr(a_216, b_217, c_218)).V);
{ V _t219 = c_218;
{ V _t220 = ListOf(_t219);
{ V _t221 = GetIdx(_t220, 0D);
x_188 = _t221; }
{ V _t222 = GetIdx(_t220, 1D);
y_189 = _t222; }
} }
} else {
i_186++;
}
}
}
}
return @out_192;
return default;
}, 1, "parsePath", false);
poseAt_43 = Fn((V _self223, int _argc224, V name_230, V t_231, V key_232, V _a229, V[] _rest225) => {
V st_233 = default;
V P_234 = default;
V id_235 = default;
double tl_236 = 0;
if (_self223.IsNullish) _self223 = GlobalV;
if (Truthy((key_232 is var _t237 && !Truthy(_t237) ? _t237 : Get(G("window"), "SquishLazy")))) {
Invoke(Get(G("window"), "SquishLazy"), "need", key_232);
}
st_233 = ((key_232 is var _t238 && !Truthy(_t238) ? _t238 : GetK(STATES_38, ((V)(string.Concat(ToStr(name_230), "@", ToStr(key_232)))))) is var _t239 && Truthy(_t239) ? _t239 : GetK(STATES_38, name_230));
P_234 = Object_assign(NewObj(0).V, REST_35);
id_235 = Get(STATES_38, "idle");
if (!SEqS(name_230, "idle")) {
double ti_240 = 0;
ti_240 = (ToNum(t_231) % ToNum(Get(id_235, "loop")));
{
foreach (V _k241 in ForInKeys(Get(id_235, "k"))) {
V k_242 = default;
k_242 = _k241;
SetK(P_234, k_242, Call(kv_19, V.Undef, GetK(Get(id_235, "k"), k_242), ((V)(ti_240))));
}
}
}
tl_236 = (Truthy(Get(st_233, "loop")) ? (ToNum(t_231) % ToNum(Get(st_233, "loop"))) : Min(ToNum(t_231), ToNum((Get(st_233, "dur") is var _t243 && Truthy(_t243) ? _t243 : t_231))));
{
foreach (V _k244 in ForInKeys(Get(st_233, "k"))) {
V k_245 = default;
k_245 = _k244;
SetK(P_234, k_245, Call(kv_19, V.Undef, GetK(Get(st_233, "k"), k_245), ((V)(tl_236))));
}
}
if (Truthy(Get(st_233, "breathe"))) {
V bk_246 = default;
bk_246 = Get(st_233, "breathe");
OpSet(P_234, "sq", 0, ((V)(((FdLibm.Sin((ToNum(t_231) / 640D)) * 0.013) * ToNum(bk_246)))));
OpSet(P_234, "lean", 0, ((V)(((FdLibm.Sin((ToNum(t_231) / 1350D)) * 0.4) * ToNum(bk_246)))));
OpSet(P_234, "htilt", 0, ((V)(((FdLibm.Sin(((ToNum(t_231) / 1900D) + 1D)) * 0.8) * ToNum(bk_246)))));
}
return P_234;
return default;
}, 3, "poseAt", false);
setState_45 = Fn((V _self247, int _argc248, V I_254, V name_255, V now_256, V keepQ_257, V[] _rest249) => {
V st_258 = default;
if (_self247.IsNullish) _self247 = GlobalV;
if (!(Truthy(GetK(STATES_38, name_255)))) {
name_255 = ((V)("idle"));
}
if (Truthy(Get(G("window"), "SquishConfig"))) {
name_255 = Invoke(Get(G("window"), "SquishConfig"), "gateState", Get(I_254, "ak"), name_255, STATES_38);
}
if (!(Truthy(keepQ_257))) {
Set(I_254, "queue", Arr());
}
if (Truthy(Get(GetK(STATES_38, name_255), "seq"))) {
Set(I_254, "queue", Invoke(Get(GetK(STATES_38, name_255), "seq"), "slice", ((V)(1D))));
name_255 = GetIdx(Get(GetK(STATES_38, name_255), "seq"), 0D);
if (!(Truthy(GetK(STATES_38, name_255)))) {
name_255 = ((V)("idle"));
}
if (Truthy(Get(G("window"), "SquishConfig"))) {
name_255 = Invoke(Get(G("window"), "SquishConfig"), "gateState", Get(I_254, "ak"), name_255, STATES_38);
}
}
Set(I_254, "prev", (Truthy(Get(I_254, "prev")) ? NewObj(1).Put("frozen", Get(I_254, "lastP")).V : NewObj(2).Put("name", Get(Get(I_254, "cur"), "name")).Put("t0", Get(Get(I_254, "cur"), "t0")).V));
Set(I_254, "cur", NewObj(2).Put("name", name_255).Put("t0", now_256).V);
Set(I_254, "bt0", now_256);
Set(I_254, "bd", (Get(GetK(STATES_38, name_255), "blend") is var _t259 && Truthy(_t259) ? _t259 : ((V)(280D))));
Set(I_254, "evC", ((V)((-1D))));
Set(I_254, "evF", NewObj(0).V);
Set(I_254, "ctr", NewObj(0).V);
Set(I_254, "ctT", NewObj(0).V);
Set(I_254, "emL", NewObj(0).V);
st_258 = GetK(STATES_38, name_255);
if (Truthy(Get(st_258, "tap"))) {
V tp_260 = default;
tp_260 = (Truthy(Get(I_254, "fromM")) ? Invoke(I_254, "fromM", GetIdx(Get(st_258, "tap"), 0D), GetIdx(Get(st_258, "tap"), 1D)) : Get(st_258, "tap"));
Invoke(Get(I_254, "shots"), "push", NewObj(4).Put("S", DENT_44).Put("t0", now_256).Put("x", GetIdx(tp_260, 0D)).Put("y", GetIdx(tp_260, 1D)).V);
}
if (Truthy(Get(I_254, "onState"))) {
Invoke(I_254, "onState", name_255);
}
return default;
}, 4, "setState", false);
fire_46 = Fn((V _self261, int _argc262, V I_268, V e_269, V now_270, V _a267, V[] _rest263) => {
V n_271 = default;
V st_272 = default;
if (_self261.IsNullish) _self261 = GlobalV;
n_271 = GetIdx(e_269, 1D);
SetK(Get(I_268, "ctr"), n_271, Add((GetK(Get(I_268, "ctr"), n_271) is var _t273 && Truthy(_t273) ? _t273 : ((V)(0D))), ((V)(1D))));
SetK(Get(I_268, "ctT"), n_271, now_270);
if ((SEqS(n_271, "blink") || SEqS(n_271, "blink2"))) {
Set(I_268, "blinkT", now_270);
Set(I_268, "dbl", (SEqS(n_271, "blink2") ? V.True : V.False));
Set(I_268, "blinkAt", Add(now_270, ((V)(2600D))));
} else {
if (SEqS(n_271, "poke")) {
Call(poke_47, V.Undef, I_268, GetIdx(e_269, 2D), GetIdx(e_269, 3D), now_270);
} else {
if (SEqS(n_271, "emit")) {
Call(emit_51, V.Undef, I_268, GetIdx(e_269, 2D), GetIdx(e_269, 3D), GetIdx(e_269, 4D));
}
}
}
st_272 = GetK(STATES_38, Get(Get(I_268, "cur"), "name"));
if (Truthy((Get(st_272, "on") is var _t274 && !Truthy(_t274) ? _t274 : GetK(Get(st_272, "on"), n_271)))) {
InvokeK(Get(st_272, "on"), n_271, I_268, e_269, now_270);
}
return default;
}, 3, "fire", false);
poke_47 = Fn((V _self275, int _argc276, V I_282, V x_283, V y_284, V now_285, V[] _rest277) => {
if (_self275.IsNullish) _self275 = GlobalV;
Invoke(Get(I_282, "shots"), "push", NewObj(4).Put("S", Call(POKE_40, V.Undef, ((V)((LtN(x_283, 50D) ? 1D : (-1D)))))).Put("t0", now_285).Put("x", x_283).Put("y", y_284).V);
return default;
}, 4, "poke", false);
region_48 = Fn((V _self286, int _argc287, V I_293, V x_294, V y_295, V _a292, V[] _rest288) => {
V P_296 = default;
double dx_297 = 0;
double dh_298 = 0;
V L_299 = default;
if (_self286.IsNullish) _self286 = GlobalV;
P_296 = (Get(I_293, "lastP") is var _t300 && Truthy(_t300) ? _t300 : REST_35);
x_294 = ((V)((ToNum(x_294) - ToNum(Get(P_296, "x")))));
y_295 = Add(y_295, Get(P_296, "lift"));
if (Truthy(Get(I_293, "toM"))) {
{ V _t301 = Invoke(I_293, "toM", x_294, y_295);
{ V _t302 = ListOf(_t301);
{ V _t303 = GetIdx(_t302, 0D);
x_294 = _t303; }
{ V _t304 = GetIdx(_t302, 1D);
y_295 = _t304; }
} }
}
dx_297 = (ToNum(x_294) - 50D);
dh_298 = Hypot(dx_297, (ToNum(y_295) - 46D));
L_299 = ((dx_297 < 0D) ? V.True : V.False);
if (((GtN(x_294, 74D) && GtN(y_295, 56D)) && LtN(y_295, 92D))) {
return ((V)("tail"));
}
if (GtN(y_295, 87D)) {
return ((V)((Truthy(L_299) ? "footL" : "footR")));
}
if ((LtN(y_295, 30D) && (System.Math.Abs(dx_297) > 9D))) {
return ((V)((Truthy(L_299) ? "earL" : "earR")));
}
if ((GeN(y_295, 70D) && (System.Math.Abs(dx_297) < 13D))) {
return ((V)("belly"));
}
if ((GeN(y_295, 64D) && (System.Math.Abs(dx_297) >= 13D))) {
return ((V)((Truthy(L_299) ? "sideL" : "sideR")));
}
if ((dh_298 < 31D)) {
if (LtN(y_295, 38D)) {
return ((V)("head"));
}
if ((((System.Math.Abs(dx_297) < 6D) && GeN(y_295, 50D)) && LtN(y_295, 62D))) {
return ((V)("nose"));
}
if (((GeN(y_295, 40D) && LtN(y_295, 52D)) && (System.Math.Abs((System.Math.Abs(dx_297) - 12D)) < 6D))) {
return ((V)((Truthy(L_299) ? "eyeL" : "eyeR")));
}
if (LtN(y_295, 50D)) {
return ((V)("head"));
}
return ((V)((Truthy(L_299) ? "cheekL" : "cheekR")));
}
return ((V)((Truthy(L_299) ? "sideL" : "sideR")));
return default;
}, 3, "region", false);
where_50 = Fn((V _self305, int _argc306, V I_312, V w_313, V _a310, V _a311, V[] _rest307) => {
V p_314 = default;
double sd_315 = 0;
if (_self305.IsNullish) _self305 = GlobalV;
if ((w_313.O is JsArray)) {
return Arr(GetIdx(w_313, 0D), GetIdx(w_313, 1D), ((V)((LtN(GetIdx(w_313, 0D), 50D) ? (-1D) : 1D))));
}
p_314 = ((Get(I_312, "W") is var _t316 && !Truthy(_t316) ? _t316 : GetK(Get(I_312, "W"), w_313)) is var _t317 && Truthy(_t317) ? _t317 : Arr(((V)(50D)), ((V)(50D))));
sd_315 = (Truthy(Invoke(NewRegExp(RX3, "L$", ""), "test", w_313)) ? (-1D) : (Truthy((Invoke(NewRegExp(RX2, "R$", ""), "test", w_313) is var _t318 && Truthy(_t318) ? _t318 : (SEqS(w_313, "tail") ? V.True : V.False))) ? 1D : 0D));
return Arr(GetIdx(p_314, 0D), GetIdx(p_314, 1D), ((V)(sd_315)));
return default;
}, 2, "where", false);
emit_51 = Fn((V _self319, int _argc320, V I_326, V name_327, V w_328, V n_329, V[] _rest321) => {
V q_330 = default;
V x_331 = default;
V y_332 = default;
V sd_333 = default;
if (_self319.IsNullish) _self319 = GlobalV;
q_330 = GetK(PRE_49, name_327);
if (!(Truthy(q_330))) {
return default;
}
{ V _t334 = Call(where_50, V.Undef, I_326, w_328);
{ V _t335 = ListOf(_t334);
{ V _t336 = GetIdx(_t335, 0D);
x_331 = _t336; }
{ V _t337 = GetIdx(_t335, 1D);
y_332 = _t337; }
{ V _t338 = GetIdx(_t335, 2D);
sd_333 = _t338; }
} }
n_329 = (n_329 is var _t339 && Truthy(_t339) ? _t339 : Get(q_330, "n"));
{
double i_340 = 0;
i_340 = 0D;
while (true) {
if (!((Lt(((V)(i_340)), n_329) && LtN(Get(Get(I_326, "parts"), "length"), 140D)))) break;
double a_342 = 0;
double m_343 = 0;
V side_344 = default;
a_342 = (ToNum(Invoke(G("Math"), "random")) * TAU_12);
m_343 = (ToNum(Invoke(G("Math"), "random")) * ToNum(Get(q_330, "sp")));
side_344 = (Truthy(Get(q_330, "out")) ? (sd_333 is var _t345 && Truthy(_t345) ? _t345 : ((V)((LtN(Invoke(G("Math"), "random"), 0.5) ? (-1D) : 1D)))) : ((V)(1D)));
Invoke(Get(I_326, "parts"), "push", NewObj(12).Put("x", Add(x_331, ((V)((FdLibm.Cos(a_342) * 0.6))))).Put("y", Add(y_332, ((V)((FdLibm.Sin(a_342) * 0.6))))).Put("vx", ((V)(((ToNum((Get(q_330, "vx") is var _t346 && Truthy(_t346) ? _t346 : ((V)(0D)))) * ToNum(side_344)) + (FdLibm.Cos(a_342) * m_343))))).Put("vy", Add((Get(q_330, "vy") is var _t347 && Truthy(_t347) ? _t347 : ((V)(0D))), ((V)(((FdLibm.Sin(a_342) * m_343) * 0.7))))).Put("g", Get(q_330, "g")).Put("life", ((V)((ToNum(Get(q_330, "life")) * (0.8 + (ToNum(Invoke(G("Math"), "random")) * 0.4)))))).Put("age", ((V)(0D))).Put("r", Add(GetIdx(Get(q_330, "r"), 0D), ((V)((ToNum(Invoke(G("Math"), "random")) * (ToNum(GetIdx(Get(q_330, "r"), 1D)) - ToNum(GetIdx(Get(q_330, "r"), 0D)))))))).Put("col", (Truthy(Get(q_330, "col")) ? GetIdx(Get(q_330, "col"), System.Math.Floor((ToNum(Invoke(G("Math"), "random")) * ToNum(Get(Get(q_330, "col"), "length"))))) : ((V)("#fff")))).Put("kind", Get(q_330, "kind")).Put("ph", ((V)((ToNum(Invoke(G("Math"), "random")) * TAU_12)))).Put("gy", (Truthy(Get(q_330, "hop")) ? y_332 : V.Null)).V);
i_340++;
}
}
return default;
}, 4, "emit", false);
drawParts_52 = Fn((V _self348, int _argc349, V I_355, V dt_356, V _a353, V _a354, V[] _rest350) => {
V h_357 = default;
if (_self348.IsNullish) _self348 = GlobalV;
h_357 = ((V)(""));
Set(I_355, "parts", Invoke(Get(I_355, "parts"), "filter", Fn((V _self348, int _argc358, V p_364, V _a361, V _a362, V _a363, V[] _rest359) => {
double u_365 = 0;
V op_366 = default;
V tr_367 = default;
OpSet(p_364, "age", 0, ((V)((ToNum(dt_356) * 1000D))));
if (Gt(Get(p_364, "age"), Get(p_364, "life"))) {
return (false ? V.True : V.False);
}
OpSet(p_364, "vy", 0, ((V)((ToNum(Get(p_364, "g")) * ToNum(dt_356)))));
OpSet(p_364, "x", 0, ((V)((ToNum(Get(p_364, "vx")) * ToNum(dt_356)))));
OpSet(p_364, "y", 0, ((V)((ToNum(Get(p_364, "vy")) * ToNum(dt_356)))));
if (((!Get(p_364, "gy").IsNullish && Gt(Get(p_364, "y"), Get(p_364, "gy"))) && GtN(Get(p_364, "vy"), 0D))) {
Set(p_364, "y", Get(p_364, "gy"));
Set(p_364, "vy", ((V)(((-24D) * (0.85 + (ToNum(Invoke(G("Math"), "random")) * 0.3))))));
Set(p_364, "land", Get(p_364, "age"));
}
u_365 = (ToNum(Get(p_364, "age")) / ToNum(Get(p_364, "life")));
op_366 = Call(r2_14, V.Undef, ((V)((Min(1D, (u_365 * 8D)) * (1D - ToNum(Call(SM_16, V.Undef, ((V)(((u_365 - 0.7) / 0.3))))))))));
tr_367 = ((V)(string.Concat(new string[] { "translate(", ToStr(Call(r2_14, V.Undef, Get(p_364, "x"))), " ", ToStr(Call(r2_14, V.Undef, Get(p_364, "y"))), ")" })));
if (SEqS(Get(p_364, "kind"), "dot")) {
h_357 = ((V)(string.Concat(new string[] { ToStr(h_357), "<circle cx=\"", ToStr(Call(r2_14, V.Undef, Get(p_364, "x"))), "\" cy=\"", ToStr(Call(r2_14, V.Undef, Get(p_364, "y"))), "\" r=\"", ToStr(Call(r2_14, V.Undef, Get(p_364, "r"))), "\" fill=\"", ToStr(Get(p_364, "col")), "\" opacity=\"", ToStr(op_366), "\"/>" })));
} else {
if (SEqS(Get(p_364, "kind"), "drop")) {
h_357 = ((V)(string.Concat(new string[] { ToStr(h_357), "<path transform=\"", ToStr(tr_367), " rotate(", ToStr(Call(r2_14, V.Undef, ((V)((FdLibm.Atan2((-ToNum(Get(p_364, "vx"))), ToNum(Get(p_364, "vy"))) / D2R_11))))), ") scale(", ToStr(Call(r2_14, V.Undef, Get(p_364, "r"))), ")\" d=\"M0 -2 Q1.4 0.4 0 1.3 Q-1.4 0.4 0 -2Z\" fill=\"", ToStr(Get(p_364, "col")), "\" stroke=\"#ffffff\" stroke-width=\"0.3\" opacity=\"", ToStr(op_366), "\"/>" })));
} else {
if (SEqS(Get(p_364, "kind"), "bubble")) {
V pop_368 = default;
double rr_369 = 0;
pop_368 = Call(SM_16, V.Undef, ((V)(((u_365 - 0.88) / 0.12))));
rr_369 = (ToNum(Get(p_364, "r")) * (1D + (ToNum(pop_368) * 0.4)));
h_357 = ((V)(string.Concat(new string[] { ToStr(h_357), "<g opacity=\"", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(op_366) * (1D - ToNum(pop_368))))))), "\"><circle cx=\"", ToStr(Call(r2_14, V.Undef, Add(Get(p_364, "x"), ((V)((FdLibm.Sin(ToNum(Add(((V)((ToNum(Get(p_364, "age")) / 300D))), Get(p_364, "ph")))) * 1.2)))))), "\" cy=\"", ToStr(Call(r2_14, V.Undef, Get(p_364, "y"))), "\" r=\"", ToStr(Call(r2_14, V.Undef, ((V)(rr_369)))), "\" fill=\"rgba(215,240,255,0.35)\" stroke=\"#ffffff\" stroke-width=\"0.45\"/><circle cx=\"", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(Get(p_364, "x")) - (rr_369 * 0.35)))))), "\" cy=\"", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(Get(p_364, "y")) - (rr_369 * 0.35)))))), "\" r=\"", ToStr(Call(r2_14, V.Undef, ((V)((rr_369 * 0.22))))), "\" fill=\"#ffffff\"/></g>" })));
} else {
if (SEqS(Get(p_364, "kind"), "star")) {
h_357 = ((V)(string.Concat(new string[] { ToStr(h_357), "<path d=\"", ToStr(Call(star4_33, V.Undef, Get(p_364, "x"), Get(p_364, "y"), ((V)((ToNum(Get(p_364, "r")) * (0.6 + (0.6 * FdLibm.Sin((System.Math.PI * u_365))))))))), "\" fill=\"", ToStr(Get(p_364, "col")), "\" opacity=\"", ToStr(op_366), "\"/>" })));
} else {
if (SEqS(Get(p_364, "kind"), "heart")) {
h_357 = ((V)(string.Concat(new string[] { ToStr(h_357), "<path transform=\"", ToStr(tr_367), " scale(", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(Get(p_364, "r")) * (0.8 + (u_365 * 0.5))))))), ")\" d=\"M0 2.6 C-4.6 -0.6 -3.4 -5.6 0 -3 C3.4 -5.6 4.6 -0.6 0 2.6Z\" fill=\"#ff5c9e\" stroke=\"#ffffff\" stroke-width=\"0.5\" opacity=\"", ToStr(op_366), "\"/>" })));
} else {
if (SEqS(Get(p_364, "kind"), "wave")) {
double w_370 = 0;
w_370 = (FdLibm.Sin(ToNum(Add(((V)((ToNum(Get(p_364, "age")) / 260D))), Get(p_364, "ph")))) * 1.2);
h_357 = ((V)(string.Concat(new string[] { ToStr(h_357), "<path transform=\"", ToStr(tr_367), " scale(", ToStr(Call(r2_14, V.Undef, Get(p_364, "r"))), ")\" d=\"M0 0 q", ToStr(Call(r2_14, V.Undef, ((V)(((-1.6) + w_370))))), " -2 0 -4 q", ToStr(Call(r2_14, V.Undef, ((V)((1.6 + w_370))))), " -2 0 -4\" stroke=\"", ToStr(Get(p_364, "col")), "\" stroke-width=\"1.1\" fill=\"none\" stroke-linecap=\"round\" opacity=\"", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(op_366) * 0.9))))), "\"/>" })));
} else {
if (SEqS(Get(p_364, "kind"), "wisp")) {
double s_371 = 0;
double dr_372 = 0;
s_371 = (ToNum(Get(p_364, "r")) * (0.8 + (u_365 * 0.6)));
dr_372 = (LtN(Get(p_364, "vx"), 0D) ? (-1D) : 1D);
h_357 = ((V)(string.Concat(new string[] { ToStr(h_357), "<path transform=\"", ToStr(tr_367), " scale(", ToStr(Call(r2_14, V.Undef, ((V)((dr_372 * s_371))))), " ", ToStr(Call(r2_14, V.Undef, ((V)(s_371)))), ")\" d=\"M-5 0 Q-2 -1.6 1 0 T5 -0.6 Q7 -1.6 6 -3 Q4.6 -3.6 4.6 -2.2\" stroke=\"", ToStr(Get(p_364, "col")), "\" stroke-width=\"", ToStr(Call(r2_14, V.Undef, ((V)((0.9 / s_371))))), "\" fill=\"none\" stroke-linecap=\"round\" opacity=\"", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(op_366) * 0.9))))), "\"/>" })));
} else {
if (SEqS(Get(p_364, "kind"), "leaf")) {
double sw_373 = 0;
sw_373 = FdLibm.Sin(ToNum(Add(((V)((ToNum(Get(p_364, "age")) / 260D))), Get(p_364, "ph"))));
h_357 = ((V)(string.Concat(new string[] { ToStr(h_357), "<path transform=\"translate(", ToStr(Call(r2_14, V.Undef, Add(Get(p_364, "x"), ((V)((sw_373 * 2.2)))))), " ", ToStr(Call(r2_14, V.Undef, Get(p_364, "y"))), ") rotate(", ToStr(Call(r2_14, V.Undef, ((V)(((ToNum(Get(p_364, "ph")) * 57D) + (sw_373 * 55D)))))), ") scale(", ToStr(Call(r2_14, V.Undef, Get(p_364, "r"))), ")\" d=\"M0 -2.6 Q1.8 -0.8 0.3 2.3 L0 2.9 L-0.3 2.3 Q-1.8 -0.8 0 -2.6Z\" fill=\"", ToStr(Get(p_364, "col")), "\" stroke=\"#ffffff\" stroke-width=\"0.25\" opacity=\"", ToStr(op_366), "\"/>" })));
} else {
if (SEqS(Get(p_364, "kind"), "duck")) {
double sq_374 = 0;
double wd_375 = 0;
double dr_376 = 0;
double s_377 = 0;
sq_374 = ((!Get(p_364, "land").IsNullish && ((ToNum(Get(p_364, "age")) - ToNum(Get(p_364, "land"))) < 140D)) ? (1D - ToNum(Call(SM_16, V.Undef, ((V)(((ToNum(Get(p_364, "age")) - ToNum(Get(p_364, "land"))) / 140D)))))) : 0D);
wd_375 = (FdLibm.Sin(ToNum(Add(((V)((ToNum(Get(p_364, "age")) / 110D))), Get(p_364, "ph")))) * 14D);
dr_376 = (LtN(Get(p_364, "vx"), 0D) ? (-1D) : 1D);
s_377 = (ToNum(Get(p_364, "r")) * 1.5);
h_357 = ((V)(string.Concat(new string[] { ToStr(h_357), "<g transform=\"", ToStr(tr_367), " scale(", ToStr(Call(r2_14, V.Undef, ((V)(((dr_376 * s_377) * (1D + (sq_374 * 0.18))))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((s_377 * (1D - (sq_374 * 0.22))))))), ") rotate(", ToStr(Call(r2_14, V.Undef, ((V)(wd_375)))), ")\" opacity=\"", ToStr(op_366), "\"><ellipse cx=\"0.2\" cy=\"-2\" rx=\"3.5\" ry=\"2.3\" fill=\"#e9a512\"/><ellipse cx=\"-0.2\" cy=\"-2.4\" rx=\"3.1\" ry=\"1.9\" fill=\"#ffd43b\"/><path d=\"M-3 -2.6 L-4.5 -4.2 L-2.4 -3.5Z\" fill=\"#ffd43b\"/><path d=\"M-1.6 -2.6 Q0 -1.2 1.4 -2.6\" stroke=\"#e9a512\" stroke-width=\"0.5\" fill=\"none\" stroke-linecap=\"round\"/><circle cx=\"1.95\" cy=\"-4.85\" r=\"1.85\" fill=\"#e9a512\"/><circle cx=\"1.8\" cy=\"-5\" r=\"1.75\" fill=\"#ffd43b\"/><ellipse cx=\"3.7\" cy=\"-4.6\" rx=\"1.05\" ry=\"0.5\" fill=\"#ff8a2a\"/><circle cx=\"2.4\" cy=\"-5.4\" r=\"0.36\" fill=\"#2a1a30\"/><ellipse cx=\"1.1\" cy=\"-5.8\" rx=\"0.6\" ry=\"0.35\" fill=\"#fff8d0\"/><ellipse cx=\"-1.2\" cy=\"-3.3\" rx=\"1\" ry=\"0.4\" fill=\"#fff8d0\" opacity=\"0.8\"/></g>" })));
} else {
if (SEqS(Get(p_364, "kind"), "haze")) {
h_357 = ((V)(string.Concat(new string[] { ToStr(h_357), "<circle cx=\"", ToStr(Call(r2_14, V.Undef, Get(p_364, "x"))), "\" cy=\"", ToStr(Call(r2_14, V.Undef, Get(p_364, "y"))), "\" r=\"", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(Get(p_364, "r")) * (0.8 + (u_365 * 1.1))))))), "\" fill=\"url(#phz", ToStr(Get(I_355, "u")), ")\" opacity=\"", ToStr(op_366), "\"/>" })));
} else {
if (SEqS(Get(p_364, "kind"), "puff")) {
h_357 = ((V)(string.Concat(new string[] { ToStr(h_357), "<circle cx=\"", ToStr(Call(r2_14, V.Undef, Get(p_364, "x"))), "\" cy=\"", ToStr(Call(r2_14, V.Undef, Get(p_364, "y"))), "\" r=\"", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(Get(p_364, "r")) * (0.7 + (u_365 * 0.8))))))), "\" fill=\"", ToStr(Get(p_364, "col")), "\" opacity=\"", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(op_366) * 0.85))))), "\"/>" })));
} else {
if (SEqS(Get(p_364, "kind"), "seed")) {
h_357 = ((V)(string.Concat(new string[] { ToStr(h_357), "<ellipse cx=\"", ToStr(Call(r2_14, V.Undef, Get(p_364, "x"))), "\" cy=\"", ToStr(Call(r2_14, V.Undef, Get(p_364, "y"))), "\" rx=\"", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(Get(p_364, "r")) * 0.7))))), "\" ry=\"", ToStr(Call(r2_14, V.Undef, Get(p_364, "r"))), "\" fill=\"", ToStr(Get(p_364, "col")), "\" opacity=\"", ToStr(op_366), "\"/>" })));
} else {
if (SEqS(Get(p_364, "kind"), "note")) {
h_357 = ((V)(string.Concat(new string[] { ToStr(h_357), "<g transform=\"", ToStr(tr_367), " rotate(", ToStr(Call(r2_14, V.Undef, ((V)((FdLibm.Sin((ToNum(Get(p_364, "age")) / 200D)) * 12D))))), ")\" opacity=\"", ToStr(op_366), "\"><ellipse cx=\"0\" cy=\"0\" rx=\"1.5\" ry=\"1.1\" fill=\"", ToStr(Get(p_364, "col")), "\" transform=\"rotate(-20)\"/><path d=\"M1.3 -0.3 L1.3 -5 Q3 -4.2 3.3 -2.6\" stroke=\"", ToStr(Get(p_364, "col")), "\" stroke-width=\"0.8\" fill=\"none\" stroke-linecap=\"round\"/></g>" })));
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
return h_357;
return default;
}, 2, "drawParts", false);
wPrep_53 = Fn((V _self378, int _argc379, V I_385, V _a382, V _a383, V _a384, V[] _rest380) => {
V fx_386 = default;
V par_387 = default;
V NS_388 = default;
V mkE_389 = default;
V df_390 = default;
V cp_391 = default;
V rc_392 = default;
V b_393 = default;
V g_394 = default;
if (_self378.IsNullish) _self378 = GlobalV;
fx_386 = Get(I_385, "fxG");
par_387 = (fx_386 is var _t395 && !Truthy(_t395) ? _t395 : Get(fx_386, "parentNode"));
if (!(Truthy(par_387))) {
return V.Null;
}
NS_388 = ((V)("http://www.w3.org/2000/svg"));
mkE_389 = Fn((V _self378, int _argc396, V n_402, V _a399, V _a400, V _a401, V[] _rest397) => {
return Invoke(G("document"), "createElementNS", NS_388, n_402);
}, 1, "", true);
df_390 = Call(mkE_389, V.Undef, ((V)("defs")));
cp_391 = Call(mkE_389, V.Undef, ((V)("clipPath")));
rc_392 = Call(mkE_389, V.Undef, ((V)("rect")));
Invoke(cp_391, "setAttribute", ((V)("id")), ((V)(string.Concat("wcl", ToStr(Get(I_385, "u"))))));
Invoke(cp_391, "setAttribute", ((V)("clipPathUnits")), ((V)("userSpaceOnUse")));
Invoke(rc_392, "setAttribute", ((V)("x")), ((V)((-300D))));
Invoke(rc_392, "setAttribute", ((V)("y")), ((V)((-400D))));
Invoke(rc_392, "setAttribute", ((V)("width")), ((V)(700D)));
Invoke(rc_392, "setAttribute", ((V)("height")), ((V)(500D)));
Invoke(cp_391, "appendChild", rc_392);
Invoke(df_390, "appendChild", cp_391);
Invoke(par_387, "insertBefore", df_390, Get(par_387, "firstChild"));
b_393 = Call(mkE_389, V.Undef, ((V)("g")));
g_394 = Call(mkE_389, V.Undef, ((V)("g")));
Invoke(new ArrBuilder().Spread(Get(par_387, "childNodes")).V, "forEach", Fn((V _self378, int _argc403, V n_409, V _a406, V _a407, V _a408, V[] _rest404) => {
if (((SEq(n_409, fx_386) || SEq(n_409, df_390)) || SEqS(Get(n_409, "nodeName"), "defs"))) {
return default;
}
Invoke(g_394, "appendChild", n_409);
return default;
}, 1, "", true));
Invoke(par_387, "insertBefore", g_394, fx_386);
Invoke(par_387, "insertBefore", b_393, g_394);
return NewObj(7).Put("g", g_394).Put("b", b_393).Put("rc", rc_392).Put("on", (false ? V.True : V.False)).Put("m0", V.Null).Put("cx", V.Null).Put("hw", V.Null).V;
return default;
}, 1, "wPrep", false);
dustBath_56 = Fn((V _self410, int _argc411, V I_417, V P_418, V now_419, V _a416, V[] _rest412) => {
V s_420 = default;
double hz_421 = 0;
V u_422 = default;
double cx_423 = 0;
double rx_424 = 0;
double ry_425 = 0;
double rim_426 = 0;
double wh_427 = 0;
double brx_428 = 0;
double bry_429 = 0;
double by_430 = 0;
V al_431 = default;
double T_432 = 0;
V arc_433 = default;
V lvl_434 = default;
V blob_435 = default;
double sy_436 = 0;
double srx_437 = 0;
double sry_438 = 0;
V sp_439 = default;
V gr_440 = default;
V hzB_441 = default;
V hzF_442 = default;
V st_443 = default;
V hy_444 = default;
V ha_445 = default;
V hb_446 = default;
V hy2_447 = default;
V ha2_448 = default;
V hb2_449 = default;
V heap_450 = default;
double dk_451 = 0;
if (_self410.IsNullish) _self410 = GlobalV;
s_420 = Call(clamp_13, V.Undef, (Get(P_418, "dbb") is var _t452 && Truthy(_t452) ? _t452 : ((V)(0D))), ((V)(0D)), ((V)(1.3)));
hz_421 = (ToNum(Call(clamp_13, V.Undef, (Get(P_418, "dbh") is var _t453 && Truthy(_t453) ? _t453 : ((V)(0D))), ((V)(0D)), ((V)(1D)))) * ToNum(Call(clamp_13, V.Undef, s_420, ((V)(0D)), ((V)(1D)))));
if (LtN(s_420, 0.02)) {
if (Truthy((Get(I_417, "dbG") is var _t454 && !Truthy(_t454) ? _t454 : Get(I_417, "dbOn")))) {
Set(Get(I_417, "dbG"), "innerHTML", ((V)("")));
Set(I_417, "dbOn", (false ? V.True : V.False));
Invoke(Get(I_417, "root"), "removeAttribute", ((V)("clip-path")));
}
return ((V)(""));
}
if (!(Truthy(Get(I_417, "dbG")))) {
Set(I_417, "dbG", Invoke(G("document"), "createElementNS", ((V)("http://www.w3.org/2000/svg")), ((V)("g"))));
Invoke(Get(Get(I_417, "root"), "parentNode"), "insertBefore", Get(I_417, "dbG"), Get(I_417, "root"));
}
u_422 = Get(I_417, "u");
cx_423 = 50D;
rx_424 = (46D * ToNum(s_420));
ry_425 = (11.5 * ToNum(s_420));
rim_426 = (79D + (9D * (1D - Min(1D, ToNum(s_420)))));
wh_427 = (11D * ToNum(s_420));
brx_428 = (rx_424 * 0.94);
bry_429 = (ry_425 * 0.94);
by_430 = (rim_426 + wh_427);
al_431 = Call(r2_14, V.Undef, Call(clamp_13, V.Undef, ((V)((ToNum(s_420) * 3D))), ((V)(0D)), ((V)(1D))));
T_432 = (ToNum((now_419 is var _t455 && Truthy(_t455) ? _t455 : ((V)(0D)))) / 1000D);
arc_433 = Fn((V _self410, int _argc456, V y_462, V a_463, V b_464, V up_465, V[] _rest457) => {
return ((V)(string.Concat(new string[] { "M", ToStr(Call(r2_14, V.Undef, ((V)((cx_423 - ToNum(a_463)))))), " ", ToStr(Call(r2_14, V.Undef, y_462)), "A", ToStr(Call(r2_14, V.Undef, a_463)), " ", ToStr(Call(r2_14, V.Undef, b_464)), " 0 0 ", NumStr((Truthy(up_465) ? 1D : 0D)), " ", ToStr(Call(r2_14, V.Undef, Add(((V)(cx_423)), a_463))), " ", ToStr(Call(r2_14, V.Undef, y_462)) })));
}, 4, "", true);
lvl_434 = Fn((V _self410, int _argc466, V f_472, V _a469, V _a470, V _a471, V[] _rest467) => {
return Arr(((V)((rim_426 + (wh_427 * ToNum(f_472))))), ((V)((rx_424 + ((brx_428 - rx_424) * ToNum(f_472))))), ((V)((ry_425 + ((bry_429 - ry_425) * ToNum(f_472))))));
}, 1, "", true);
blob_435 = Fn((V _self410, int _argc473, V x_479, V y_480, V r_481, V o_482, V[] _rest474) => {
return ((V)(string.Concat(new string[] { "<circle cx=\"", ToStr(Call(r2_14, V.Undef, x_479)), "\" cy=\"", ToStr(Call(r2_14, V.Undef, y_480)), "\" r=\"", ToStr(Call(r2_14, V.Undef, r_481)), "\" fill=\"url(#dbh", ToStr(u_422), ")\" opacity=\"", ToStr(Call(r2_14, V.Undef, o_482)), "\"/>" })));
}, 4, "", true);
sy_436 = (rim_426 + (3D * ToNum(s_420)));
srx_437 = (rx_424 - (2.6 * ToNum(s_420)));
sry_438 = (ry_425 - (0.6 * ToNum(s_420)));
sp_439 = ((V)(""));
{
double i_483 = 0;
i_483 = 0D;
while (true) {
if (!((i_483 < 26D))) break;
double a_485 = 0;
double rr_486 = 0;
a_485 = (i_483 * 2.4);
rr_486 = (((0.15 + (((i_483 * 7D) % 10D) / 11.5)) * srx_437) * 0.92);
sp_439 = ((V)(string.Concat(new string[] { ToStr(sp_439), "<circle cx=\"", ToStr(Call(r2_14, V.Undef, ((V)((cx_423 + (FdLibm.Cos(a_485) * rr_486)))))), "\" cy=\"", ToStr(Call(r2_14, V.Undef, ((V)((sy_436 + ((((FdLibm.Sin(a_485) * rr_486) * sry_438) / srx_437) * 0.85)))))), "\" r=\"", ToStr(Call(r2_14, V.Undef, ((V)(((0.3 + ((i_483 % 3D) * 0.12)) * ToNum(s_420)))))), "\" fill=\"", (NumTruthy((i_483 % 2D)) ? "#bdb2a2" : "#fbf8f3"), "\" opacity=\"0.6\"/>" })));
i_483++;
}
}
gr_440 = ((V)(""));
Invoke(Arr(Arr(((V)((-24D))), ((V)((-2.5))), ((V)(9D)), ((V)(0.9))), Arr(((V)((-6D))), ((V)(1.2)), ((V)(12D)), ((V)(1.1))), Arr(((V)(17D)), ((V)((-1.4))), ((V)(10D)), ((V)(0.8))), Arr(((V)(29D)), ((V)(2.6)), ((V)(7D)), ((V)(0.7))), Arr(((V)((-31D))), ((V)(3.2)), ((V)(6D)), ((V)(0.6)))), "forEach", Fn((V _self410, int _argc487, V _a489, V _a490, V _a491, V _a492, V[] _rest488) => {
double x_502 = 0;
double y_503 = 0;
double ww_504 = 0;
V dx_495 = default;
V dy_497 = default;
V w_499 = default;
V b_501 = default;
{ V _t493 = ListOf(_a489);
{ V _t494 = GetIdx(_t493, 0D);
dx_495 = _t494; }
{ V _t496 = GetIdx(_t493, 1D);
dy_497 = _t496; }
{ V _t498 = GetIdx(_t493, 2D);
w_499 = _t498; }
{ V _t500 = GetIdx(_t493, 3D);
b_501 = _t500; }
}
x_502 = (cx_423 + (ToNum(dx_495) * ToNum(s_420)));
y_503 = (sy_436 + (ToNum(dy_497) * ToNum(s_420)));
ww_504 = (ToNum(w_499) * ToNum(s_420));
gr_440 = ((V)(string.Concat(new string[] { ToStr(gr_440), "<path d=\"M", ToStr(Call(r2_14, V.Undef, ((V)((x_502 - ww_504))))), " ", ToStr(Call(r2_14, V.Undef, ((V)(y_503)))), "Q", ToStr(Call(r2_14, V.Undef, ((V)(x_502)))), " ", ToStr(Call(r2_14, V.Undef, ((V)((y_503 + ((ToNum(b_501) * 1.6) * ToNum(s_420))))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((x_502 + ww_504))))), " ", ToStr(Call(r2_14, V.Undef, ((V)(y_503)))), "\" stroke=\"#c3b8a8\" stroke-width=\"", ToStr(Call(r2_14, V.Undef, ((V)((0.7 * ToNum(s_420)))))), "\" fill=\"none\" stroke-linecap=\"round\" opacity=\"0.55\"/><path d=\"M", ToStr(Call(r2_14, V.Undef, ((V)((x_502 - (ww_504 * 0.9)))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((y_503 - (0.6 * ToNum(s_420))))))), "Q", ToStr(Call(r2_14, V.Undef, ((V)(x_502)))), " ", ToStr(Call(r2_14, V.Undef, ((V)(((y_503 + ((ToNum(b_501) * 1.6) * ToNum(s_420))) - (0.6 * ToNum(s_420))))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((x_502 + (ww_504 * 0.9)))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((y_503 - (0.6 * ToNum(s_420))))))), "\" stroke=\"#fdfbf8\" stroke-width=\"", ToStr(Call(r2_14, V.Undef, ((V)((0.5 * ToNum(s_420)))))), "\" fill=\"none\" stroke-linecap=\"round\" opacity=\"0.7\"/>" })));
return default;
}, 1, "", true));
hzB_441 = ((V)(""));
hzF_442 = ((V)(""));
if ((hz_421 > 0.01)) {
{
double i_505 = 0;
i_505 = 0D;
while (true) {
if (!((i_505 < 6D))) break;
double x_507 = 0;
double y_508 = 0;
double r_509 = 0;
x_507 = ((cx_423 + (((-34D) + (i_505 * 13.6)) * ToNum(s_420))) + (FdLibm.Sin(((T_432 * 0.8) + (i_505 * 1.7))) * 3.5));
y_508 = (((rim_426 - 7D) - ((i_505 % 2D) * 6D)) + (FdLibm.Sin(((T_432 * 1.1) + (i_505 * 2.3))) * 2.2));
r_509 = ((12D + (((i_505 * 5D) % 3D) * 3.5)) * (0.9 + (0.1 * FdLibm.Sin(((T_432 * 1.6) + i_505)))));
hzB_441 = Add(hzB_441, Call(blob_435, V.Undef, ((V)(x_507)), ((V)(y_508)), ((V)(r_509)), ((V)((hz_421 * 0.85)))));
if (((i_505 % 2D) == 0D)) {
hzF_442 = Add(hzF_442, Call(blob_435, V.Undef, ((V)((x_507 + 3D))), ((V)((y_508 + 6D))), ((V)((r_509 * 0.85))), ((V)((hz_421 * 0.18)))));
}
i_505++;
}
}
}
if ((hz_421 > 0.01)) {
{
double i_510 = 0;
i_510 = 0D;
while (true) {
if (!((i_510 < 4D))) break;
hzF_442 = Add(hzF_442, Call(blob_435, V.Undef, ((V)(((cx_423 + (((-30D) + (i_510 * 20D)) * ToNum(s_420))) + (FdLibm.Sin(((T_432 * 1.3) + (i_510 * 2.1))) * 3D)))), ((V)(((rim_426 + 2D) + (FdLibm.Sin(((T_432 * 1.7) + i_510)) * 1.5)))), ((V)((8D + ((i_510 % 2D) * 3D)))), ((V)((hz_421 * 0.2)))));
i_510++;
}
}
}
Set(Get(I_417, "dbG"), "innerHTML", ((V)(string.Concat(new string[] { "<defs><linearGradient id=\"dbw", ToStr(u_422), "\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#a5763e\"/><stop offset=\"0.16\" stop-color=\"#d6a967\"/><stop offset=\"0.4\" stop-color=\"#f0cf98\"/><stop offset=\"0.62\" stop-color=\"#e5bc7e\"/><stop offset=\"0.86\" stop-color=\"#c49352\"/><stop offset=\"1\" stop-color=\"#9a6c37\"/></linearGradient>", "<linearGradient id=\"dbi", ToStr(u_422), "\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#e4bd84\"/><stop offset=\"1\" stop-color=\"#b08048\"/></linearGradient>", "<radialGradient id=\"dbs", ToStr(u_422), "\" cx=\"42%\" cy=\"35%\" r=\"72%\"><stop offset=\"0\" stop-color=\"#f6f3ee\"/><stop offset=\"0.7\" stop-color=\"#e3dbcf\"/><stop offset=\"1\" stop-color=\"#cdc2b2\"/></radialGradient>", "<radialGradient id=\"dbh", ToStr(u_422), "\"><stop offset=\"0\" stop-color=\"#c9c8c6\" stop-opacity=\"0.9\"/><stop offset=\"0.55\" stop-color=\"#d2d1cf\" stop-opacity=\"0.5\"/><stop offset=\"1\" stop-color=\"#d8d7d5\" stop-opacity=\"0\"/></radialGradient>", "<clipPath id=\"dbk", ToStr(u_422), "\" clipPathUnits=\"userSpaceOnUse\"><path d=\"M-200 -300L300 -300L300 300L", ToStr(Call(r2_14, V.Undef, ((V)((cx_423 + brx_428))))), " 300L", ToStr(Call(r2_14, V.Undef, ((V)((cx_423 + brx_428))))), " ", ToStr(Call(r2_14, V.Undef, ((V)(by_430)))), "A", ToStr(Call(r2_14, V.Undef, ((V)(brx_428)))), " ", ToStr(Call(r2_14, V.Undef, ((V)(bry_429)))), " 0 0 1 ", ToStr(Call(r2_14, V.Undef, ((V)((cx_423 - brx_428))))), " ", ToStr(Call(r2_14, V.Undef, ((V)(by_430)))), "L", ToStr(Call(r2_14, V.Undef, ((V)((cx_423 - brx_428))))), " 300L-200 300Z\"/></clipPath>", "<clipPath id=\"dbc", ToStr(u_422), "\"><ellipse cx=\"", NumStr(cx_423), "\" cy=\"", ToStr(Call(r2_14, V.Undef, ((V)(rim_426)))), "\" rx=\"", ToStr(Call(r2_14, V.Undef, ((V)((rx_424 - 0.4))))), "\" ry=\"", ToStr(Call(r2_14, V.Undef, ((V)((ry_425 - 0.3))))), "\"/></clipPath></defs>", "<g opacity=\"", ToStr(al_431), "\"><ellipse cx=\"", NumStr(cx_423), "\" cy=\"", ToStr(Call(r2_14, V.Undef, ((V)((by_430 + 0.8))))), "\" rx=\"", ToStr(Call(r2_14, V.Undef, ((V)((brx_428 * 1.04))))), "\" ry=\"", ToStr(Call(r2_14, V.Undef, ((V)((bry_429 * 0.95))))), "\" fill=\"#6d4f9a\" opacity=\"0.17\"/>", "<ellipse cx=\"", NumStr(cx_423), "\" cy=\"", ToStr(Call(r2_14, V.Undef, ((V)(rim_426)))), "\" rx=\"", ToStr(Call(r2_14, V.Undef, ((V)(rx_424)))), "\" ry=\"", ToStr(Call(r2_14, V.Undef, ((V)(ry_425)))), "\" fill=\"url(#dbi", ToStr(u_422), ")\"/>", "<g clip-path=\"url(#dbc", ToStr(u_422), ")\"><ellipse cx=\"", NumStr(cx_423), "\" cy=\"", ToStr(Call(r2_14, V.Undef, ((V)((sy_436 + (0.5 * ToNum(s_420))))))), "\" rx=\"", ToStr(Call(r2_14, V.Undef, ((V)((srx_437 + 0.8))))), "\" ry=\"", ToStr(Call(r2_14, V.Undef, ((V)((sry_438 + 0.6))))), "\" fill=\"#8d6232\" opacity=\"0.35\"/>", "<ellipse cx=\"", NumStr(cx_423), "\" cy=\"", ToStr(Call(r2_14, V.Undef, ((V)(sy_436)))), "\" rx=\"", ToStr(Call(r2_14, V.Undef, ((V)(srx_437)))), "\" ry=\"", ToStr(Call(r2_14, V.Undef, ((V)(sry_438)))), "\" fill=\"url(#dbs", ToStr(u_422), ")\"/>", ToStr(gr_440), ToStr(sp_439), "</g>", "<path d=\"", ToStr(Call(arc_433, V.Undef, ((V)(rim_426)), ((V)(rx_424)), ((V)(ry_425)), ((V)(1D)))), "\" fill=\"none\" stroke=\"#f6dfb4\" stroke-width=\"", ToStr(Call(r2_14, V.Undef, ((V)((1.9 * ToNum(s_420)))))), "\" stroke-linecap=\"round\"/>", "<path d=\"", ToStr(Call(arc_433, V.Undef, ((V)((rim_426 + (0.35 * ToNum(s_420))))), ((V)((rx_424 - (1.1 * ToNum(s_420))))), ((V)((ry_425 - (0.7 * ToNum(s_420))))), ((V)(1D)))), "\" fill=\"none\" stroke=\"#a87a42\" stroke-width=\"", ToStr(Call(r2_14, V.Undef, ((V)((0.45 * ToNum(s_420)))))), "\" opacity=\"0.55\"/>", ToStr(hzB_441), "</g>" }))));
if (!(Truthy(Get(I_417, "dbOn")))) {
Invoke(Get(I_417, "root"), "setAttribute", ((V)("clip-path")), ((V)(string.Concat("url(#dbk", ToStr(u_422), ")"))));
}
Set(I_417, "dbOn", (true ? V.True : V.False));
st_443 = ((V)(""));
{
double a_512 = 0;
a_512 = (-72D);
while (true) {
if (!((a_512 <= 72D))) break;
double q_514 = 0;
double x0_515 = 0;
double y0_516 = 0;
double x1_517 = 0;
double y1_518 = 0;
q_514 = (a_512 * D2R_11);
x0_515 = (cx_423 + (rx_424 * FdLibm.Sin(q_514)));
y0_516 = (rim_426 + (ry_425 * FdLibm.Cos(q_514)));
x1_517 = (cx_423 + (brx_428 * FdLibm.Sin(q_514)));
y1_518 = (by_430 + (bry_429 * FdLibm.Cos(q_514)));
st_443 = ((V)(string.Concat(new string[] { ToStr(st_443), "<path d=\"M", ToStr(Call(r2_14, V.Undef, ((V)(x0_515)))), " ", ToStr(Call(r2_14, V.Undef, ((V)((y0_516 + 1D))))), "L", ToStr(Call(r2_14, V.Undef, ((V)(x1_517)))), " ", ToStr(Call(r2_14, V.Undef, ((V)(y1_518)))), "\" stroke=\"#9c6d38\" stroke-width=\"", ToStr(Call(r2_14, V.Undef, ((V)((0.35 * ToNum(s_420)))))), "\" opacity=\"0.38\"/>" })));
a_512 = (a_512 + 12D);
}
}
{ V _t519 = Call(lvl_434, V.Undef, ((V)(0.66)));
{ V _t520 = ListOf(_t519);
{ V _t521 = GetIdx(_t520, 0D);
hy_444 = _t521; }
{ V _t522 = GetIdx(_t520, 1D);
ha_445 = _t522; }
{ V _t523 = GetIdx(_t520, 2D);
hb_446 = _t523; }
} }
{ V _t524 = Call(lvl_434, V.Undef, ((V)((0.66 + (1.5 / Max(1D, wh_427))))));
{ V _t525 = ListOf(_t524);
{ V _t526 = GetIdx(_t525, 0D);
hy2_447 = _t526; }
{ V _t527 = GetIdx(_t525, 1D);
ha2_448 = _t527; }
{ V _t528 = GetIdx(_t525, 2D);
hb2_449 = _t528; }
} }
heap_450 = ((V)(""));
dk_451 = (ToNum(Call(clamp_13, V.Undef, (Get(P_418, "dbs") is var _t529 && Truthy(_t529) ? _t529 : ((V)(0D))), ((V)(0D)), ((V)(1D)))) * Min(1D, ToNum(s_420)));
if ((dk_451 > 0.01)) {
double N_530 = 0;
double x0_531 = 0;
double x1_532 = 0;
V rf_533 = default;
double mv_534 = 0;
V top_535 = default;
V pts_536 = default;
V gn_537 = default;
N_530 = 22D;
x0_531 = (cx_423 - (41D * ToNum(s_420)));
x1_532 = (cx_423 + (41D * ToNum(s_420)));
rf_533 = Fn((V _self410, int _argc538, V x_544, V _a541, V _a542, V _a543, V[] _rest539) => {
return ((V)((rim_426 + (ry_425 * System.Math.Sqrt(Max(0D, (1D - (((ToNum(x_544) - cx_423) / rx_424) * ((ToNum(x_544) - cx_423) / rx_424)))))))));
}, 1, "", true);
mv_534 = hz_421;
top_535 = ((V)(""));
pts_536 = Arr();
{
double i_545 = 0;
i_545 = 0D;
while (true) {
if (!((i_545 <= N_530))) break;
double q_547 = 0;
double x_548 = 0;
double e_549 = 0;
double lump_550 = 0;
q_547 = (i_545 / N_530);
x_548 = (x0_531 + ((x1_532 - x0_531) * q_547));
e_549 = Pow(FdLibm.Sin((System.Math.PI * q_547)), 0.55);
lump_550 = ((1D + (0.22 * FdLibm.Sin((((q_547 * 19D) + 1.3) + ((T_432 * 5D) * mv_534))))) + (0.12 * FdLibm.Sin(((q_547 * 41D) + ((T_432 * 8D) * mv_534)))));
Invoke(pts_536, "push", Arr(((V)(x_548)), ((V)((ToNum(Call(rf_533, V.Undef, ((V)(x_548)))) - ((((dk_451 * 5.5) * ToNum(s_420)) * e_549) * lump_550))))));
i_545++;
}
}
Invoke(pts_536, "forEach", Fn((V _self410, int _argc551, V p_557, V i_558, V _a555, V _a556, V[] _rest552) => {
top_535 = ((V)(string.Concat(new string[] { ToStr(top_535), (Truthy(i_558) ? "L" : "M"), ToStr(Call(r2_14, V.Undef, GetIdx(p_557, 0D))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(p_557, 1D))) })));
return default;
}, 2, "", true));
gn_537 = ((V)(""));
{
double i_559 = 0;
i_559 = 2D;
while (true) {
if (!((i_559 < (N_530 - 1D)))) break;
V p_561 = default;
p_561 = GetIdx(pts_536, i_559);
gn_537 = ((V)(string.Concat(new string[] { ToStr(gn_537), "<circle cx=\"", ToStr(Call(r2_14, V.Undef, Add(GetIdx(p_561, 0D), ((V)((FdLibm.Sin((i_559 * 3.7)) * 1.2)))))), "\" cy=\"", ToStr(Call(r2_14, V.Undef, Add(Add(GetIdx(p_561, 1D), ((V)(1.4))), ((V)(((i_559 % 3D) * 0.7)))))), "\" r=\"", ToStr(Call(r2_14, V.Undef, ((V)((0.32 * ToNum(s_420)))))), "\" fill=\"", (NumTruthy((i_559 % 4D)) ? "#b9b0a3" : "#fbf9f5"), "\" opacity=\"0.7\"/>" })));
i_559 = (i_559 + 2D);
}
}
heap_450 = ((V)(string.Concat(new string[] { "<g opacity=\"", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(al_431) * Min(1D, (dk_451 * 2.5))))))), "\"><path d=\"", ToStr(top_535), "L", ToStr(Call(r2_14, V.Undef, ((V)(x1_532)))), " ", ToStr(Call(r2_14, V.Undef, ((V)((by_430 + 4D))))), "L", ToStr(Call(r2_14, V.Undef, ((V)(x0_531)))), " ", ToStr(Call(r2_14, V.Undef, ((V)((by_430 + 4D))))), "Z\" fill=\"url(#dbs", ToStr(u_422), ")\"/>", "<path d=\"", ToStr(top_535), "\" fill=\"none\" stroke=\"#a99f91\" stroke-width=\"", ToStr(Call(r2_14, V.Undef, ((V)((1.2 * ToNum(s_420)))))), "\" stroke-linejoin=\"round\" opacity=\"0.35\" transform=\"translate(0 -0.5)\"/>", "<path d=\"", ToStr(top_535), "\" fill=\"none\" stroke=\"#fcfaf6\" stroke-width=\"", ToStr(Call(r2_14, V.Undef, ((V)((0.6 * ToNum(s_420)))))), "\" stroke-linejoin=\"round\" opacity=\"0.9\" transform=\"translate(0 0.45)\"/>", ToStr(gn_537), "</g>" })));
}
return ((V)(string.Concat(new string[] { ToStr(heap_450), "<g opacity=\"", ToStr(al_431), "\"><path d=\"", ToStr(Call(arc_433, V.Undef, ((V)(rim_426)), ((V)(rx_424)), ((V)(ry_425)), ((V)(0D)))), "L", ToStr(Call(r2_14, V.Undef, ((V)((cx_423 + brx_428))))), " ", ToStr(Call(r2_14, V.Undef, ((V)(by_430)))), "A", ToStr(Call(r2_14, V.Undef, ((V)(brx_428)))), " ", ToStr(Call(r2_14, V.Undef, ((V)(bry_429)))), " 0 0 1 ", ToStr(Call(r2_14, V.Undef, ((V)((cx_423 - brx_428))))), " ", ToStr(Call(r2_14, V.Undef, ((V)(by_430)))), "Z\" fill=\"url(#dbw", ToStr(u_422), ")\"/>", ToStr(st_443), "<path d=\"", ToStr(Call(arc_433, V.Undef, hy_444, ha_445, hb_446, ((V)(0D)))), "L", ToStr(Call(r2_14, V.Undef, Add(((V)(cx_423)), ha2_448))), " ", ToStr(Call(r2_14, V.Undef, hy2_447)), "A", ToStr(Call(r2_14, V.Undef, ha2_448)), " ", ToStr(Call(r2_14, V.Undef, hb2_449)), " 0 0 1 ", ToStr(Call(r2_14, V.Undef, ((V)((cx_423 - ToNum(ha2_448)))))), " ", ToStr(Call(r2_14, V.Undef, hy2_447)), "Z\" fill=\"#9b6c3a\" opacity=\"0.8\"/>", "<path d=\"", ToStr(Call(arc_433, V.Undef, hy_444, ha_445, hb_446, ((V)(0D)))), "\" fill=\"none\" stroke=\"#e8c58e\" stroke-width=\"", ToStr(Call(r2_14, V.Undef, ((V)((0.4 * ToNum(s_420)))))), "\" opacity=\"0.8\"/>", "<path d=\"", ToStr(Call(arc_433, V.Undef, ((V)((rim_426 + (0.9 * ToNum(s_420))))), ((V)((rx_424 - 0.1))), ((V)(ry_425)), ((V)(0D)))), "\" fill=\"none\" stroke=\"#a97b43\" stroke-width=\"", ToStr(Call(r2_14, V.Undef, ((V)((0.6 * ToNum(s_420)))))), "\" opacity=\"0.6\"/>", "<path d=\"", ToStr(Call(arc_433, V.Undef, ((V)(rim_426)), ((V)(rx_424)), ((V)(ry_425)), ((V)(0D)))), "\" fill=\"none\" stroke=\"#f8e4bf\" stroke-width=\"", ToStr(Call(r2_14, V.Undef, ((V)((1.9 * ToNum(s_420)))))), "\" stroke-linecap=\"round\"/>", "<path d=\"M", ToStr(Call(r2_14, V.Undef, ((V)((cx_423 - (rx_424 * 0.5)))))), " ", ToStr(Call(r2_14, V.Undef, ((V)(((rim_426 + (ry_425 * 0.86)) - 0.25))))), "Q", ToStr(Call(r2_14, V.Undef, ((V)((cx_423 - (rx_424 * 0.2)))))), " ", ToStr(Call(r2_14, V.Undef, ((V)(((rim_426 + ry_425) + 0.05))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((cx_423 + (rx_424 * 0.05)))))), " ", ToStr(Call(r2_14, V.Undef, ((V)(((rim_426 + (ry_425 * 0.99)) - 0.25))))), "\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(r2_14, V.Undef, ((V)((0.6 * ToNum(s_420)))))), "\" stroke-linecap=\"round\" fill=\"none\" opacity=\"0.65\"/>", "<path d=\"M", ToStr(Call(r2_14, V.Undef, ((V)((cx_423 - (brx_428 * 0.62)))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((by_430 + (bry_429 * 0.6)))))), "Q", ToStr(Call(r2_14, V.Undef, ((V)((cx_423 - (brx_428 * 0.3)))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((by_430 + (bry_429 * 0.86)))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((cx_423 - (brx_428 * 0.05)))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((by_430 + (bry_429 * 0.86)))))), "\" stroke=\"#fff3da\" stroke-width=\"", ToStr(Call(r2_14, V.Undef, ((V)((0.9 * ToNum(s_420)))))), "\" stroke-linecap=\"round\" fill=\"none\" opacity=\"0.35\"/>", ToStr(hzF_442), "</g>" })));
return default;
}, 3, "dustBath", false);
water_57 = Fn((V _self562, int _argc563, V I_569, V P_570, V now_571, V _a568, V[] _rest564) => {
V wd_572 = default;
V on_573 = default;
V sh_574 = default;
V stm_575 = default;
V wet_576 = default;
V fh_577 = default;
V spg_578 = default;
V C_579 = default;
V W_580 = default;
V ok_581 = default;
double T_582 = 0;
V M_583 = default;
V m0_584 = default;
V sl_585 = default;
V sr_586 = default;
double hw0_587 = 0;
V cx0_588 = default;
V back_589 = default;
V h_590 = default;
double Y_591 = 0;
V cx_592 = default;
V hw_593 = default;
V HD_594 = default;
if (_self562.IsNullish) _self562 = GlobalV;
wd_572 = Call(clamp_13, V.Undef, (Get(P_570, "wd") is var _t595 && Truthy(_t595) ? _t595 : ((V)(0D))), ((V)(0D)), ((V)(1.2)));
on_573 = (GtN(wd_572, 0.02) ? V.True : V.False);
sh_574 = (Get(P_570, "shw") is var _t596 && Truthy(_t596) ? _t596 : ((V)(0D)));
stm_575 = (Get(P_570, "stm") is var _t597 && Truthy(_t597) ? _t597 : ((V)(0D)));
wet_576 = (Get(P_570, "wet") is var _t598 && Truthy(_t598) ? _t598 : ((V)(0D)));
fh_577 = (Get(P_570, "fh") is var _t599 && Truthy(_t599) ? _t599 : ((V)(0D)));
spg_578 = (Get(P_570, "spg") is var _t600 && Truthy(_t600) ? _t600 : ((V)(0D)));
if (((((((!(Truthy(on_573)) && LtN(sh_574, 0.02)) && LtN(stm_575, 0.02)) && LtN(wet_576, 0.02)) && LtN(fh_577, 0.02)) && LtN(spg_578, 0.02)) && !(Truthy((Get(I_569, "wc") is var _t601 && !Truthy(_t601) ? _t601 : Get(Get(I_569, "wc"), "on")))))) {
return ((V)(""));
}
if (Truthy((on_573 is var _t602 && !Truthy(_t602) ? _t602 : (!(Truthy(Get(I_569, "wc"))) ? V.True : V.False)))) {
Set(I_569, "wc", Call(wPrep_53, V.Undef, I_569));
}
C_579 = Get(I_569, "wc");
W_580 = (Get(I_569, "W") is var _t603 && Truthy(_t603) ? _t603 : NewObj(0).V);
ok_581 = Fn((V _self562, int _argc604, V p_610, V _a607, V _a608, V _a609, V[] _rest605) => {
return ((p_610 is var _t611 && !Truthy(_t611) ? _t611 : (IsFiniteV(GetIdx(p_610, 0D)) ? V.True : V.False)) is var _t612 && !Truthy(_t612) ? _t612 : (IsFiniteV(GetIdx(p_610, 1D)) ? V.True : V.False));
}, 1, "", true);
T_582 = (ToNum(now_571) / 1000D);
M_583 = (Truthy(Call(ok_581, V.Undef, Get(W_580, "mouth"))) ? Get(W_580, "mouth") : (Truthy(Call(ok_581, V.Undef, Get(W_580, "nose"))) ? Get(W_580, "nose") : V.Null));
m0_584 = Add((Truthy(M_583) ? GetIdx(M_583, 1D) : ((V)(58D))), Get(P_570, "lift"));
sl_585 = Get(W_580, "sideL");
sr_586 = Get(W_580, "sideR");
hw0_587 = (Truthy((Call(ok_581, V.Undef, sl_585) is var _t613 && !Truthy(_t613) ? _t613 : Call(ok_581, V.Undef, sr_586))) ? ((System.Math.Abs((ToNum(GetIdx(sr_586, 0D)) - ToNum(GetIdx(sl_585, 0D)))) * 0.56) + 4D) : 22D);
cx0_588 = (Truthy(Call(ok_581, V.Undef, Get(W_580, "body"))) ? GetIdx(Get(W_580, "body"), 0D) : Add(((V)(50D)), Get(P_570, "x")));
back_589 = ((V)(""));
h_590 = ((V)(""));
Y_591 = 0D;
cx_592 = cx0_588;
hw_593 = Call(clamp_13, V.Undef, ((V)(hw0_587)), ((V)(14D)), ((V)(38D)));
if (Truthy(C_579)) {
Set(C_579, "m0", (Get(C_579, "m0").IsNullish ? m0_584 : Add(Get(C_579, "m0"), ((V)(((ToNum(m0_584) - ToNum(Get(C_579, "m0"))) * 0.05))))));
Set(C_579, "cx", (Get(C_579, "cx").IsNullish ? cx0_588 : Add(Get(C_579, "cx"), ((V)(((ToNum(cx0_588) - ToNum(Get(C_579, "cx"))) * 0.2))))));
Set(C_579, "hw", (Get(C_579, "hw").IsNullish ? hw_593 : Add(Get(C_579, "hw"), ((V)(((ToNum(hw_593) - ToNum(Get(C_579, "hw"))) * 0.1))))));
cx_592 = Get(C_579, "cx");
hw_593 = Get(C_579, "hw");
}
if (Truthy((C_579 is var _t614 && !Truthy(_t614) ? _t614 : (!SEq(on_573, Get(C_579, "on")) ? V.True : V.False)))) {
Set(C_579, "on", on_573);
if (Truthy(on_573)) {
Invoke(Get(C_579, "g"), "setAttribute", ((V)("clip-path")), ((V)(string.Concat("url(#wcl", ToStr(Get(I_569, "u")), ")"))));
} else {
Invoke(Get(C_579, "g"), "removeAttribute", ((V)("clip-path")));
Set(Get(C_579, "b"), "innerHTML", ((V)("")));
}
}
if (Truthy((on_573 is var _t615 && !Truthy(_t615) ? _t615 : C_579))) {
double G0_616 = 0;
V top_617 = default;
V rx_618 = default;
double ry_619 = 0;
V half_620 = default;
V fm_621 = default;
V dk_622 = default;
G0_616 = 96D;
top_617 = Add(Add(Get(C_579, "m0"), (Get(P_570, "sk") is var _t623 && Truthy(_t623) ? _t623 : ((V)(0D)))), ((V)(5D)));
Y_591 = (G0_616 - (Min(ToNum(wd_572), 1D) * (G0_616 - ToNum(top_617))));
Invoke(Get(C_579, "rc"), "setAttribute", ((V)("height")), Call(r2_14, V.Undef, ((V)(((400D + Y_591) + 1.2)))));
rx_618 = Add(hw_593, ((V)(6D)));
ry_619 = Max(2.6, (ToNum(rx_618) * 0.19));
half_620 = Fn((V _self562, int _argc624, V y_630, V rxx_631, V ryy_632, V up_633, V[] _rest625) => {
return ((V)(string.Concat(new string[] { "M", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(cx_592) - ToNum(rxx_631)))))), " ", ToStr(Call(r2_14, V.Undef, y_630)), "A", ToStr(Call(r2_14, V.Undef, rxx_631)), " ", ToStr(Call(r2_14, V.Undef, ryy_632)), " 0 0 ", NumStr((Truthy(up_633) ? 1D : 0D)), " ", ToStr(Call(r2_14, V.Undef, Add(cx_592, rxx_631))), " ", ToStr(Call(r2_14, V.Undef, y_630)) })));
}, 4, "", true);
back_589 = ((V)(string.Concat(new string[] { ToStr(back_589), "<path d=\"", ToStr(Call(half_620, V.Undef, ((V)(Y_591)), rx_618, ((V)(ry_619)), ((V)(1D)))), "Z\" fill=\"#8fd0ee\" opacity=\"0.55\"/><path d=\"", ToStr(Call(half_620, V.Undef, ((V)(Y_591)), rx_618, ((V)(ry_619)), ((V)(1D)))), "\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.6\" opacity=\"0.7\"/>" })));
h_590 = ((V)(string.Concat(new string[] { ToStr(h_590), "<path d=\"", ToStr(Call(half_620, V.Undef, ((V)(Y_591)), rx_618, ((V)(ry_619)), ((V)(0D)))), "Z\" fill=\"#7cc6ea\" opacity=\"0.62\"/><path d=\"", ToStr(Call(half_620, V.Undef, ((V)((Y_591 + 0.2))), ((V)((ToNum(rx_618) - 0.6))), ((V)((ry_619 * 0.86))), ((V)(0D)))), "\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.9\" stroke-linecap=\"round\" opacity=\"0.85\"/>" })));
h_590 = ((V)(string.Concat(new string[] { ToStr(h_590), "<path d=\"M", ToStr(Call(r2_14, V.Undef, ((V)(((ToNum(cx_592) - ToNum(hw_593)) + 1.5))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((Y_591 + 0.3))))), "Q", ToStr(Call(r2_14, V.Undef, cx_592)), " ", ToStr(Call(r2_14, V.Undef, ((V)((Y_591 + 2.2))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(Add(cx_592, hw_593)) - 1.5))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((Y_591 + 0.3))))), "\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"1.1\" stroke-linecap=\"round\" opacity=\"0.9\"/>" })));
{
double i_634 = 0;
i_634 = 0D;
while (true) {
if (!((i_634 < 2D))) break;
double u_636 = 0;
double k_637 = 0;
V op_638 = default;
u_636 = (((T_582 / 1.8) + (i_634 / 2D)) % 1D);
k_637 = (1D + (u_636 * 0.55));
op_638 = Call(r2_14, V.Undef, ((V)(((1D - u_636) * 0.6))));
back_589 = ((V)(string.Concat(new string[] { ToStr(back_589), "<path d=\"", ToStr(Call(half_620, V.Undef, ((V)(Y_591)), ((V)((ToNum(rx_618) * k_637))), ((V)((ry_619 * k_637))), ((V)(1D)))), "\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.55\" opacity=\"", ToStr(op_638), "\"/>" })));
h_590 = ((V)(string.Concat(new string[] { ToStr(h_590), "<path d=\"", ToStr(Call(half_620, V.Undef, ((V)(Y_591)), ((V)((ToNum(rx_618) * k_637))), ((V)((ry_619 * k_637))), ((V)(0D)))), "\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.55\" opacity=\"", ToStr(op_638), "\"/>" })));
i_634++;
}
}
fm_621 = Call(clamp_13, V.Undef, (Get(P_570, "fm") is var _t639 && Truthy(_t639) ? _t639 : ((V)(0D))), ((V)(0D)), ((V)(1.4)));
if (GtN(fm_621, 0.02)) {
double N_640 = 0;
N_640 = 24D;
{
double i_641 = 0;
i_641 = 0D;
while (true) {
if (!((i_641 < N_640))) break;
double a_643 = 0;
V rr_644 = default;
V x_645 = default;
double y_646 = 0;
double r_647 = 0;
V s_648 = default;
a_643 = (((i_641 / N_640) * TAU_12) + (FdLibm.Sin(((T_582 * 0.6) + i_641)) * 0.05));
rr_644 = Add(Add(hw_593, ((V)(0.5))), ((V)((((i_641 * 7D) % 5D) * 1.1))));
x_645 = Add(cx_592, ((V)((FdLibm.Cos(a_643) * ToNum(rr_644)))));
y_646 = (Y_591 + ((FdLibm.Sin(a_643) * ry_619) * 0.95));
r_647 = (((2.1 + (((i_641 * 5D) % 4D) * 0.6)) * ToNum(fm_621)) * (0.9 + (0.1 * FdLibm.Sin(((T_582 * 2.2) + (i_641 * 1.7))))));
s_648 = Call(bub_55, V.Undef, x_645, ((V)((y_646 - (r_647 * 0.4)))), ((V)(r_647)), ((V)(Min(1D, ToNum(fm_621)))));
if ((FdLibm.Sin(a_643) < 0D)) {
back_589 = Add(back_589, s_648);
} else {
h_590 = Add(h_590, s_648);
}
i_641++;
}
}
Invoke(Arr(Arr(((V)((-1.06))), ((V)(0.4)), ((V)(3.6))), Arr(((V)((-0.9))), ((V)(0.8)), ((V)(2.6))), Arr(((V)(1.1)), ((V)(0.3)), ((V)(3.2))), Arr(((V)(0.85)), ((V)(0.85)), ((V)(2.8))), Arr(((V)((-0.45))), ((V)(1.05)), ((V)(2.4))), Arr(((V)(0.2)), ((V)(1.15)), ((V)(2.2))), Arr(((V)(1.28)), ((V)((-0.3))), ((V)(2.4))), Arr(((V)((-1.25))), ((V)((-0.25))), ((V)(2.6)))), "forEach", Fn((V _self562, int _argc649, V _a651, V i_655, V _a653, V _a654, V[] _rest650) => {
V fx_658 = default;
V fy_660 = default;
V r_662 = default;
{ V _t656 = ListOf(_a651);
{ V _t657 = GetIdx(_t656, 0D);
fx_658 = _t657; }
{ V _t659 = GetIdx(_t656, 1D);
fy_660 = _t659; }
{ V _t661 = GetIdx(_t656, 2D);
r_662 = _t661; }
}
h_590 = Add(h_590, Call(bub_55, V.Undef, Add(cx_592, ((V)((ToNum(fx_658) * ToNum(rx_618))))), ((V)(((Y_591 + (ToNum(fy_660) * ry_619)) - 1D))), ((V)(((ToNum(r_662) * ToNum(fm_621)) * (0.92 + (0.08 * FdLibm.Sin(ToNum(Add(((V)((T_582 * 1.9))), i_655)))))))), ((V)(Min(1D, ToNum(fm_621))))));
return default;
}, 2, "", true));
}
dk_622 = Call(clamp_13, V.Undef, (Get(P_570, "dk") is var _t663 && Truthy(_t663) ? _t663 : ((V)(0D))), ((V)(0D)), ((V)(1D)));
if (GtN(dk_622, 0.02)) {
V dx_664 = default;
double dy_665 = 0;
double s_666 = 0;
dx_664 = Add(cx_592, ((V)((ToNum(rx_618) * ToNum(Add(((V)(0.62)), (Get(P_570, "dkx") is var _t667 && Truthy(_t667) ? _t667 : ((V)(0D)))))))));
dy_665 = (((Y_591 + (ry_619 * 0.75)) + (FdLibm.Sin((T_582 * 2.4)) * 0.6)) + ((1D - ToNum(dk_622)) * 5D));
s_666 = (1.8 * ToNum(dk_622));
h_590 = ((V)(string.Concat(new string[] { ToStr(h_590), "<g transform=\"translate(", ToStr(Call(r2_14, V.Undef, dx_664)), " ", ToStr(Call(r2_14, V.Undef, ((V)(dy_665)))), ") rotate(", ToStr(Call(r2_14, V.Undef, ((V)((FdLibm.Sin((T_582 * 1.7)) * 6D))))), ") scale(", ToStr(Call(r2_14, V.Undef, ((V)((-s_666))))), " ", ToStr(Call(r2_14, V.Undef, ((V)(s_666)))), ")\" opacity=\"", ToStr(Call(r2_14, V.Undef, dk_622)), "\">", ToStr(DUCK_54), "</g>" })));
}
if (GtN((Get(P_570, "dv") is var _t668 && Truthy(_t668) ? _t668 : ((V)(0D))), 0.3)) {
{
double i_669 = 0;
i_669 = 0D;
while (true) {
if (!((i_669 < 3D))) break;
double u_671 = 0;
u_671 = (((T_582 * 1.4) + (i_669 / 3D)) % 1D);
h_590 = Add(h_590, Call(bub_55, V.Undef, Add(cx_592, ((V)((FdLibm.Sin(((i_669 * 2.1) + T_582)) * 4D)))), ((V)(((Y_591 - 1D) - (u_671 * 3D)))), ((V)((0.9 + (u_671 * 0.8)))), ((V)(((1D - u_671) * 0.9)))));
i_669++;
}
}
}
}
if (Truthy(C_579)) {
Set(Get(C_579, "b"), "innerHTML", back_589);
}
HD_594 = (Truthy(Call(ok_581, V.Undef, Get(W_580, "head"))) ? Get(W_580, "head") : (Truthy(Call(ok_581, V.Undef, Get(I_569, "topW"))) ? Get(I_569, "topW") : Arr(Add(((V)(50D)), Get(P_570, "x")), ((V)(20D)))));
if (GtN(fh_577, 0.02)) {
double k_672 = 0;
k_672 = Min(ToNum(fh_577), 1.8);
Invoke(Arr(Arr(((V)(0D)), ((V)((-2D))), ((V)(4D))), Arr(((V)((-4.2))), ((V)(0.3)), ((V)(3D))), Arr(((V)(4D)), ((V)((-0.1))), ((V)(3.2))), Arr(((V)((-1.9))), ((V)((-5.4))), ((V)(2.8))), Arr(((V)(2.2)), ((V)((-5D))), ((V)(2.5))), Arr(((V)(0.2)), ((V)((-8.4))), ((V)((2.3 * Max(0D, (k_672 - 0.6)))))), Arr(((V)((-0.6))), ((V)((-11D))), ((V)((1.6 * Max(0D, (k_672 - 1.1))))))), "forEach", Fn((V _self562, int _argc673, V _a675, V i_679, V _a677, V _a678, V[] _rest674) => {
V x_682 = default;
V y_684 = default;
V r_686 = default;
{ V _t680 = ListOf(_a675);
{ V _t681 = GetIdx(_t680, 0D);
x_682 = _t681; }
{ V _t683 = GetIdx(_t680, 1D);
y_684 = _t683; }
{ V _t685 = GetIdx(_t680, 2D);
r_686 = _t685; }
}
if (GtN(r_686, 0.1)) {
h_590 = Add(h_590, Call(bub_55, V.Undef, Add(GetIdx(HD_594, 0D), ((V)((ToNum(x_682) * Min(1D, k_672))))), Add(Add(Add(GetIdx(HD_594, 1D), ((V)(1.4))), ((V)((ToNum(y_684) * k_672)))), ((V)((FdLibm.Sin(ToNum(Add(((V)((T_582 * 2D))), i_679))) * 0.3)))), ((V)(((ToNum(r_686) * Min(1D, k_672)) * (0.94 + (0.06 * FdLibm.Sin(ToNum(Add(((V)((T_582 * 3D))), i_679)))))))), ((V)(Min(1D, (ToNum(fh_577) * 1.4))))));
}
return default;
}, 2, "", true));
}
if (Truthy((((GtN(spg_578, 0.02) ? V.True : V.False) is var _t687 && !Truthy(_t687) ? _t687 : Call(ok_581, V.Undef, Get(W_580, "pawR"))) is var _t688 && !Truthy(_t688) ? _t688 : ((!(Truthy(on_573)) || LtN(GetIdx(Get(W_580, "pawR"), 1D), (Y_591 + 1.5))) ? V.True : V.False)))) {
V x_689 = default;
V y_690 = default;
double s_691 = 0;
{ V _t692 = Get(W_580, "pawR");
{ V _t693 = ListOf(_t692);
{ V _t694 = GetIdx(_t693, 0D);
x_689 = _t694; }
{ V _t695 = GetIdx(_t693, 1D);
y_690 = _t695; }
} }
s_691 = Min(1D, ToNum(spg_578));
h_590 = ((V)(string.Concat(new string[] { ToStr(h_590), "<g transform=\"translate(", ToStr(Call(r2_14, V.Undef, x_689)), " ", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(y_690) - 1.4))))), ") rotate(", ToStr(Call(r2_14, V.Undef, ((V)(((-14D) + (FdLibm.Sin((T_582 * 9D)) * 6D)))))), ") scale(", ToStr(Call(r2_14, V.Undef, ((V)(s_691)))), ")\"><rect x=\"-3.6\" y=\"-2.5\" width=\"7.2\" height=\"5\" rx=\"1.6\" fill=\"#ffd04a\" stroke=\"#e0a21e\" stroke-width=\"0.4\"/><rect x=\"-3.6\" y=\"1\" width=\"7.2\" height=\"1.5\" rx=\"0.7\" fill=\"#7cc35a\"/><circle cx=\"-1.6\" cy=\"-0.6\" r=\"0.5\" fill=\"#e0a21e\"/><circle cx=\"1.2\" cy=\"-1.3\" r=\"0.45\" fill=\"#e0a21e\"/><circle cx=\"0.4\" cy=\"0.2\" r=\"0.35\" fill=\"#e0a21e\"/>", ToStr(Call(bub_55, V.Undef, ((V)(2.6)), ((V)((-2.8))), ((V)((1.2 * s_691))), ((V)(s_691)))), "</g>" })));
}
if (GtN(sh_574, 0.02)) {
double n_696 = 0;
double Yb_697 = 0;
double hr_698 = 0;
n_696 = 13D;
Yb_697 = (Truthy(on_573) ? Y_591 : 95D);
hr_698 = Max(9D, (ToNum(hw_593) * 0.62));
{
double i_699 = 0;
i_699 = 0D;
while (true) {
if (!((i_699 < n_696))) break;
double x_701 = 0;
V inside_702 = default;
V yb_703 = default;
double L_704 = 0;
x_701 = ((((ToNum(cx_592) - ToNum(hw_593)) - 4D) + (((i_699 + 0.5) * ((2D * ToNum(hw_593)) + 8D)) / n_696)) + (FdLibm.Sin((i_699 * 3.1)) * 0.8));
inside_702 = ((System.Math.Abs((x_701 - ToNum(cx_592))) < hr_698) ? V.True : V.False);
yb_703 = (Truthy(inside_702) ? Add(Add(GetIdx(HD_594, 1D), ((V)(2D))), ((V)((Pow(((x_701 - ToNum(cx_592)) / hr_698), 2D) * 8D)))) : ((V)(Yb_697)));
L_704 = (7D + ((i_699 % 3D) * 2D));
{
double j_705 = 0;
j_705 = 0D;
while (true) {
if (!((j_705 < 3D))) break;
double yy_707 = 0;
double y2_708 = 0;
yy_707 = ((-26D) + ((((T_582 * 95D) + (i_699 * 23D)) + (j_705 * 31D)) % ToNum(Add(yb_703, ((V)(26D))))));
y2_708 = Min(ToNum(yb_703), (yy_707 + L_704));
if ((y2_708 > yy_707)) {
h_590 = ((V)(string.Concat(new string[] { ToStr(h_590), "<path d=\"M", ToStr(Call(r2_14, V.Undef, ((V)(x_701)))), " ", ToStr(Call(r2_14, V.Undef, ((V)(yy_707)))), "L", ToStr(Call(r2_14, V.Undef, ((V)((x_701 - 0.5))))), " ", ToStr(Call(r2_14, V.Undef, ((V)(y2_708)))), "\" stroke=\"#5fb8ea\" stroke-width=\"1.25\" stroke-linecap=\"round\" opacity=\"", ToStr(Call(r2_14, V.Undef, ((V)((0.8 * ToNum(sh_574)))))), "\"/><path d=\"M", ToStr(Call(r2_14, V.Undef, ((V)((x_701 - 0.2))))), " ", ToStr(Call(r2_14, V.Undef, ((V)(yy_707)))), "L", ToStr(Call(r2_14, V.Undef, ((V)((x_701 - 0.6))))), " ", ToStr(Call(r2_14, V.Undef, ((V)(y2_708)))), "\" stroke=\"#ffffff\" stroke-width=\"0.45\" stroke-linecap=\"round\" opacity=\"", ToStr(Call(r2_14, V.Undef, ((V)((0.9 * ToNum(sh_574)))))), "\"/>" })));
}
j_705++;
}
}
if (Truthy((inside_702 is var _t709 && !Truthy(_t709) ? _t709 : ((V)((i_699 % 2D)))))) {
double u_710 = 0;
u_710 = (((T_582 * 3D) + (i_699 * 0.37)) % 1D);
h_590 = ((V)(string.Concat(new string[] { ToStr(h_590), "<circle cx=\"", ToStr(Call(r2_14, V.Undef, ((V)((x_701 + (((Lt(((V)(x_701)), cx_592) ? (-1D) : 1D) * u_710) * 4D)))))), "\" cy=\"", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(yb_703) - (FdLibm.Sin((u_710 * System.Math.PI)) * 3D)))))), "\" r=\"0.55\" fill=\"#bfe8ff\" opacity=\"", ToStr(Call(r2_14, V.Undef, ((V)(((1D - u_710) * ToNum(sh_574)))))), "\"/>" })));
}
i_699++;
}
}
}
if (GtN(stm_575, 0.02)) {
{
double i_711 = 0;
i_711 = 0D;
while (true) {
if (!((i_711 < 5D))) break;
double u_713 = 0;
V x_714 = default;
double y_715 = 0;
u_713 = (((T_582 / 3.2) + (i_711 / 5D)) % 1D);
x_714 = Add(Add(cx_592, ((V)((((i_711 - 2D) * ToNum(hw_593)) * 0.42)))), ((V)((FdLibm.Sin((T_582 + i_711)) * 3D))));
y_715 = ((Truthy(on_573) ? Y_591 : 70D) - (u_713 * 46D));
h_590 = ((V)(string.Concat(new string[] { ToStr(h_590), "<circle cx=\"", ToStr(Call(r2_14, V.Undef, x_714)), "\" cy=\"", ToStr(Call(r2_14, V.Undef, ((V)(y_715)))), "\" r=\"", ToStr(Call(r2_14, V.Undef, ((V)((3D + (u_713 * 6D)))))), "\" fill=\"#ffffff\" opacity=\"", ToStr(Call(r2_14, V.Undef, ((V)(((FdLibm.Sin((System.Math.PI * u_713)) * 0.32) * Min(1D, ToNum(stm_575))))))), "\"/>" })));
i_711++;
}
}
}
if (GtN(wet_576, 0.02)) {
V src_716 = default;
src_716 = Invoke(Arr(Get(W_580, "sideL"), Get(W_580, "sideR"), M_583, Get(W_580, "belly"), (Truthy(Call(ok_581, V.Undef, Get(W_580, "earL"))) ? Get(W_580, "earL") : V.Null)), "filter", ok_581);
Invoke(src_716, "forEach", Fn((V _self562, int _argc717, V p_723, V i_724, V _a721, V _a722, V[] _rest718) => {
double u_725 = 0;
V y_726 = default;
u_725 = (((T_582 / 0.95) + (ToNum(i_724) * 0.29)) % 1D);
y_726 = Add(Add(GetIdx(p_723, 1D), ((V)(2D))), ((V)((u_725 * 13D))));
if (Truthy((on_573 is var _t727 && !Truthy(_t727) ? _t727 : (GtN(y_726, Y_591) ? V.True : V.False)))) {
return default;
}
h_590 = ((V)(string.Concat(new string[] { ToStr(h_590), "<path transform=\"translate(", ToStr(Call(r2_14, V.Undef, Add(GetIdx(p_723, 0D), ((V)(((NumTruthy((ToNum(i_724) % 2D)) ? 1D : (-1D)) * 1.2)))))), " ", ToStr(Call(r2_14, V.Undef, y_726)), ") scale(", ToStr(Call(r2_14, V.Undef, ((V)((0.9 * Min(1D, ToNum(wet_576))))))), ")\" d=\"M0 -2 Q1.4 0.4 0 1.3 Q-1.4 0.4 0 -2Z\" fill=\"#8fd3ff\" stroke=\"#ffffff\" stroke-width=\"0.3\" opacity=\"", ToStr(Call(r2_14, V.Undef, ((V)(((1D - u_725) * Min(1D, ToNum(wet_576))))))), "\"/>" })));
return default;
}, 2, "", true));
}
return h_590;
return default;
}, 3, "water", false);
tick_59 = Fn((V _self728, int _argc729, V I_735, V now_736, V dt_737, V _a734, V[] _rest730) => {
V SO_738 = default;
V st_739 = default;
double t_740 = 0;
V FL_741 = default;
V P_742 = default;
V lw_743 = default;
V tx_744 = default;
V ty_745 = default;
V pv_746 = default;
double ht_747 = 0;
V hx_748 = default;
V ed_749 = default;
V ld_750 = default;
V sd_751 = default;
double tt_752 = 0;
V fx_753 = default;
V pr_754 = default;
if (_self728.IsNullish) _self728 = GlobalV;
SO_738 = Fn((V _self728, int _argc755, V n_761, V _a758, V _a759, V _a760, V[] _rest756) => {
return ((Get(I_735, "key") is var _t762 && !Truthy(_t762) ? _t762 : GetK(STATES_38, ((V)(string.Concat(ToStr(n_761), "@", ToStr(Get(I_735, "key"))))))) is var _t763 && Truthy(_t763) ? _t763 : GetK(STATES_38, n_761));
}, 1, "", true);
st_739 = Call(SO_738, V.Undef, Get(Get(I_735, "cur"), "name"));
t_740 = (ToNum(now_736) - ToNum(Get(Get(I_735, "cur"), "t0")));
if (Truthy((Get(st_739, "dur") is var _t764 && !Truthy(_t764) ? _t764 : (Ge(((V)(t_740)), Get(st_739, "dur")) ? V.True : V.False)))) {
Call(setState_45, V.Undef, I_735, (Truthy(Get(Get(I_735, "queue"), "length")) ? Invoke(Get(I_735, "queue"), "shift") : (Get(st_739, "next") is var _t765 && Truthy(_t765) ? _t765 : ((V)("idle")))), now_736, (true ? V.True : V.False));
st_739 = Call(SO_738, V.Undef, Get(Get(I_735, "cur"), "name"));
t_740 = 0D;
}
FL_741 = (Truthy(Get(G("window"), "SquishConfig")) ? Invoke(Get(G("window"), "SquishConfig"), "filter", Get(I_735, "ak"), (((Get(I_735, "hfid") is var _t766 && !Truthy(_t766) ? _t766 : Get(I_735, "key")) is var _t767 && !Truthy(_t767) ? _t767 : GetK(FIDK_97, Get(I_735, "key"))) is var _t768 && Truthy(_t768) ? _t768 : FIDGETS_96)) : (((Get(I_735, "hfid") is var _t769 && !Truthy(_t769) ? _t769 : Get(I_735, "key")) is var _t770 && !Truthy(_t770) ? _t770 : GetK(FIDK_97, Get(I_735, "key"))) is var _t771 && Truthy(_t771) ? _t771 : FIDGETS_96));
if (Truthy((((((SEqS(Get(Get(I_735, "cur"), "name"), "idle") ? V.True : V.False) is var _t772 && !Truthy(_t772) ? _t772 : Get(I_735, "fidgets")) is var _t773 && !Truthy(_t773) ? _t773 : (!(Truthy(Get(I_735, "press"))) ? V.True : V.False)) is var _t774 && !Truthy(_t774) ? _t774 : (!(Truthy(Get(I_735, "down"))) ? V.True : V.False)) is var _t775 && !Truthy(_t775) ? _t775 : Get(FL_741, "length")))) {
if (!(Truthy(Get(I_735, "fidAt")))) {
Set(I_735, "fidAt", Add(now_736, ((V)((Truthy(Get(I_735, "hfid")) ? (3200D + (ToNum(Invoke(G("Math"), "random")) * 3600D)) : (4200D + (ToNum(Invoke(G("Math"), "random")) * 4200D)))))));
} else {
if (Gt(now_736, Get(I_735, "fidAt"))) {
V f_776 = default;
Set(I_735, "fidAt", ((V)(0D)));
f_776 = V.Undef;
do {
f_776 = GetIdx(FL_741, System.Math.Floor((ToNum(Invoke(G("Math"), "random")) * ToNum(Get(FL_741, "length")))));
} while ((GtN(Get(FL_741, "length"), 1D) && SEq(f_776, Get(I_735, "lastFid"))));
Set(I_735, "lastFid", f_776);
Call(setState_45, V.Undef, I_735, f_776, now_736, (true ? V.True : V.False));
st_739 = Call(SO_738, V.Undef, f_776);
t_740 = 0D;
}
}
} else {
if (!SEqS(Get(Get(I_735, "cur"), "name"), "idle")) {
Set(I_735, "fidAt", ((V)(0D)));
}
}
if (Truthy(Get(st_739, "emit"))) {
double tl_777 = 0;
tl_777 = (Truthy(Get(st_739, "loop")) ? (t_740 % ToNum(Get(st_739, "loop"))) : t_740);
Invoke(Get(st_739, "emit"), "forEach", Fn((V _self728, int _argc778, V m_784, V i_785, V _a782, V _a783, V[] _rest779) => {
if (((Ge(((V)(tl_777)), GetIdx(m_784, 0D)) && Le(((V)(tl_777)), GetIdx(m_784, 1D))) && Ge(((V)((ToNum(now_736) - ToNum((GetK(Get(I_735, "emL"), i_785) is var _t786 && Truthy(_t786) ? _t786 : ((V)(0D))))))), GetIdx(m_784, 2D)))) {
SetK(Get(I_735, "emL"), i_785, now_736);
Call(emit_51, V.Undef, I_735, GetIdx(m_784, 3D), GetIdx(m_784, 4D), GetIdx(m_784, 5D));
}
return default;
}, 2, "", true));
}
if (Truthy(Get(st_739, "ev"))) {
double c_787 = 0;
double tl_788 = 0;
c_787 = (Truthy(Get(st_739, "loop")) ? System.Math.Floor((t_740 / ToNum(Get(st_739, "loop")))) : 0D);
tl_788 = (Truthy(Get(st_739, "loop")) ? (t_740 % ToNum(Get(st_739, "loop"))) : t_740);
if (!SEqN(Get(I_735, "evC"), c_787)) {
Set(I_735, "evC", ((V)(c_787)));
Set(I_735, "evF", NewObj(0).V);
}
Invoke(Get(st_739, "ev"), "forEach", Fn((V _self728, int _argc789, V e_795, V i_796, V _a793, V _a794, V[] _rest790) => {
if ((Ge(((V)(tl_788)), GetIdx(e_795, 0D)) && !(Truthy(GetK(Get(I_735, "evF"), i_796))))) {
SetK(Get(I_735, "evF"), i_796, ((V)(1D)));
Call(fire_46, V.Undef, I_735, e_795, now_736);
}
return default;
}, 2, "", true));
}
P_742 = Call(poseAt_43, V.Undef, Get(Get(I_735, "cur"), "name"), ((V)(t_740)), Get(I_735, "key"));
if (Truthy(Get(I_735, "prev"))) {
V w_797 = default;
w_797 = Invoke(EZ_18, "io", Call(clamp_13, V.Undef, ((V)(((ToNum(now_736) - ToNum(Get(I_735, "bt0"))) / ToNum(Get(I_735, "bd"))))), ((V)(0D)), ((V)(1D))));
if (GeN(w_797, 1D)) {
Set(I_735, "prev", V.Null);
} else {
V Q_798 = default;
Q_798 = (Get(Get(I_735, "prev"), "frozen") is var _t799 && Truthy(_t799) ? _t799 : Call(poseAt_43, V.Undef, Get(Get(I_735, "prev"), "name"), ((V)((ToNum(now_736) - ToNum(Get(Get(I_735, "prev"), "t0"))))), Get(I_735, "key")));
{
foreach (V _k800 in ForInKeys(P_742)) {
V k_801 = default;
k_801 = _k800;
if (SEqS(k_801, "spin")) {
double d_802 = 0;
d_802 = (ToNum(Get(P_742, "spin")) - ToNum(Get(Q_798, "spin")));
d_802 = ((((d_802 % 360D) + 540D) % 360D) - 180D);
Set(P_742, "spin", Add(Get(Q_798, "spin"), ((V)((d_802 * ToNum(w_797))))));
} else {
SetK(P_742, k_801, Call(lerp_15, V.Undef, (GetK(Q_798, k_801).IsNullish ? GetK(P_742, k_801) : GetK(Q_798, k_801)), GetK(P_742, k_801), w_797));
}
}
}
}
}
if (Truthy(Get(I_735, "ext"))) {
{
foreach (V _k803 in ForInKeys(Get(I_735, "ext"))) {
V k_804 = default;
k_804 = _k803;
SetK(P_742, k_804, Add((GetK(P_742, k_804) is var _t805 && Truthy(_t805) ? _t805 : ((V)(0D))), GetK(Get(I_735, "ext"), k_804)));
}
}
}
Set(I_735, "lastP", Object_assign(NewObj(0).V, P_742));
Invoke(Get(I_735, "flw"), "step", ((V)((Truthy(Get(st_739, "look")) ? 1D : 0D))), dt_737);
lw_743 = Call(clamp_13, V.Undef, Get(Get(I_735, "flw"), "v"), ((V)(0D)), ((V)(1D)));
tx_744 = ((V)(0D));
ty_745 = ((V)(0D));
if (Truthy(Get(I_735, "ptr"))) {
tx_744 = Get(Get(I_735, "ptr"), "x");
ty_745 = Get(Get(I_735, "ptr"), "y");
} else {
if (Gt(now_736, Get(I_735, "glAt"))) {
V g_806 = default;
g_806 = (LtN(Invoke(G("Math"), "random"), 0.3) ? Arr(((V)(0D)), ((V)(0D))) : Arr(((V)((((ToNum(Invoke(G("Math"), "random")) * 2D) - 1D) * 0.9))), ((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 0.7)))));
if (((System.Math.Abs((ToNum(GetIdx(g_806, 0D)) - ToNum(GetIdx(Get(I_735, "gl"), 0D)))) > 0.9) && ((ToNum(now_736) - ToNum(Get(I_735, "blinkT"))) > 800D))) {
Set(I_735, "blinkT", Add(now_736, ((V)(60D))));
Set(I_735, "dbl", (false ? V.True : V.False));
}
Set(I_735, "gl", g_806);
Set(I_735, "glAt", Add(Add(now_736, ((V)(1400D))), ((V)((ToNum(Invoke(G("Math"), "random")) * 2600D)))));
}
tx_744 = GetIdx(Get(I_735, "gl"), 0D);
ty_745 = GetIdx(Get(I_735, "gl"), 1D);
}
Invoke(Get(I_735, "fex"), "step", tx_744, dt_737);
Invoke(Get(I_735, "fey"), "step", ty_745, dt_737);
Invoke(Get(I_735, "fhx"), "step", tx_744, dt_737);
Invoke(Get(I_735, "fhy"), "step", ty_745, dt_737);
if (Truthy(Invoke(HYAW_41, "has", Get(I_735, "key")))) {
OpSet(P_742, "hyaw", 0, ((V)(((ToNum(Get(Get(I_735, "fhx"), "v")) * 0.62) * ToNum(lw_743)))));
OpSet(P_742, "turn", 0, ((V)(((ToNum(Get(Get(I_735, "fhx"), "v")) * 0.06) * ToNum(lw_743)))));
} else {
OpSet(P_742, "turn", 0, ((V)(((ToNum(Get(Get(I_735, "fhx"), "v")) * 0.6) * ToNum(lw_743)))));
}
OpSet(P_742, "lx", 0, ((V)((ToNum(Get(Get(I_735, "fex"), "v")) * ToNum(lw_743)))));
OpSet(P_742, "ly", 0, ((V)((ToNum(Get(Get(I_735, "fey"), "v")) * ToNum(lw_743)))));
OpSet(P_742, "pitch", 1, ((V)(((ToNum(Get(Get(I_735, "fhy"), "v")) * 0.35) * ToNum(lw_743)))));
OpSet(P_742, "htilt", 0, ((V)(((ToNum(Get(Get(I_735, "fhx"), "v")) * 2.5) * ToNum(lw_743)))));
if (Gt(now_736, Get(I_735, "blinkAt"))) {
Set(I_735, "blinkT", now_736);
Set(I_735, "dbl", (LtN(Invoke(G("Math"), "random"), 0.2) ? V.True : V.False));
Set(I_735, "blinkAt", Add(Add(now_736, ((V)(2200D))), ((V)((ToNum(Invoke(G("Math"), "random")) * 3200D)))));
}
if (!(Truthy(Get(st_739, "noBlink")))) {
V b_807 = default;
b_807 = Call(blinkC_58, V.Undef, ((V)((ToNum(now_736) - ToNum(Get(I_735, "blinkT"))))));
if (Truthy(Get(I_735, "dbl"))) {
b_807 = ((V)(Max(ToNum(b_807), ToNum(Call(blinkC_58, V.Undef, ((V)(((ToNum(now_736) - ToNum(Get(I_735, "blinkT"))) - 260D))))))));
}
Set(P_742, "close", ((V)(Max(ToNum(Get(P_742, "close")), ToNum(b_807)))));
}
Set(Get(I_735, "fp"), "w", ((V)((Truthy(Get(I_735, "press")) ? 14D : 28D))));
Invoke(Get(I_735, "fp"), "step", ((V)((Truthy(Get(I_735, "press")) ? 1D : 0D))), dt_737);
pv_746 = Call(clamp_13, V.Undef, Get(Get(I_735, "fp"), "v"), ((V)(0D)), ((V)(1.05)));
ht_747 = (Truthy(Get(I_735, "press")) ? (ToNum(now_736) - ToNum(Get(I_735, "pressT"))) : 0D);
if (GtN(pv_746, 0.001)) {
V PR_808 = default;
OpSet(P_742, "sq", 0, ((V)((ToNum(pv_746) * (0.34 + (0.06 * ToNum(Call(clamp_13, V.Undef, ((V)((ht_747 / 2000D))), ((V)(0D)), ((V)(1D))))))))));
Set(P_742, "hap", ((V)(Max(ToNum(Get(P_742, "hap")), (ToNum(pv_746) * 0.85)))));
OpSet(P_742, "armL", 0, ((V)((ToNum(pv_746) * 22D))));
OpSet(P_742, "armR", 0, ((V)((ToNum(pv_746) * 22D))));
OpSet(P_742, "earL", 0, ((V)((ToNum(pv_746) * 14D))));
OpSet(P_742, "earR", 0, ((V)((ToNum(pv_746) * 14D))));
Set(P_742, "blush", ((V)(Max(ToNum(Get(P_742, "blush")), (ToNum(pv_746) * ToNum(Call(clamp_13, V.Undef, ((V)(((ht_747 - 400D) / 900D))), ((V)(0D)), ((V)(1D)))))))));
if ((ht_747 > 1300D)) {
OpSet(P_742, "x", 0, ((V)(((FdLibm.Sin((ToNum(now_736) / 24D)) * 0.22) * ToNum(pv_746)))));
}
PR_808 = (Get(I_735, "key") is var _t809 && !Truthy(_t809) ? _t809 : GetK(PRESS_98, Get(I_735, "key")));
if (Truthy(PR_808)) {
{
foreach (V _k810 in ForInKeys(PR_808)) {
V k_811 = default;
k_811 = _k810;
OpSetK(P_742, k_811, 0, ((V)((ToNum(pv_746) * ToNum(GetK(PR_808, k_811))))));
}
}
}
}
Set(I_735, "dent", V.Null);
Set(I_735, "shots", Invoke(Get(I_735, "shots"), "filter", Fn((V _self728, int _argc812, V s_818, V _a815, V _a816, V _a817, V[] _rest813) => {
double u_819 = 0;
u_819 = (ToNum(now_736) - ToNum(Get(s_818, "t0")));
if (Gt(((V)(u_819)), Get(Get(s_818, "S"), "dur"))) {
return (false ? V.True : V.False);
}
{
foreach (V _k820 in ForInKeys(Get(Get(s_818, "S"), "k"))) {
V k_821 = default;
k_821 = _k820;
V v_822 = default;
v_822 = Call(kv_19, V.Undef, GetK(Get(Get(s_818, "S"), "k"), k_821), ((V)(u_819)));
if (SEqS(k_821, "dent")) {
Set(I_735, "dent", NewObj(3).Put("x", Get(s_818, "x")).Put("y", Get(s_818, "y")).Put("a", v_822).V);
} else {
OpSetK(P_742, k_821, 0, v_822);
}
}
}
return (true ? V.True : V.False);
return default;
}, 1, "", true)));
if (Truthy(Get(I_735, "spinTw"))) {
V u_823 = default;
u_823 = Call(clamp_13, V.Undef, ((V)(((ToNum(now_736) - ToNum(Get(Get(I_735, "spinTw"), "t0"))) / ToNum(Get(Get(I_735, "spinTw"), "d"))))), ((V)(0D)), ((V)(1D)));
Set(I_735, "spinOff", Call(lerp_15, V.Undef, Get(Get(I_735, "spinTw"), "from"), Get(Get(I_735, "spinTw"), "to"), Invoke(EZ_18, "bk", u_823)));
if (GeN(u_823, 1D)) {
Set(I_735, "spinOff", ((V)((ToNum(Get(Get(I_735, "spinTw"), "to")) % 360D))));
Set(I_735, "spinTw", V.Null);
}
}
OpSet(P_742, "spin", 0, Get(I_735, "spinOff"));
Invoke(Get(I_735, "fs"), "step", Get(P_742, "sq"), dt_737);
Set(I_735, "hs", Call(clamp_13, V.Undef, ((V)(((ToNum(Get(Get(I_735, "fs"), "v")) - ToNum(Get(P_742, "sq"))) * 0.55))), ((V)((-0.12))), ((V)(0.12))));
hx_748 = Add(Add(Add(Get(P_742, "x"), Get(P_742, "lean")), ((V)((ToNum(Get(P_742, "tilt")) * 0.9)))), ((V)((ToNum(Get(P_742, "htilt")) * 0.4))));
Invoke(Get(I_735, "fx"), "step", hx_748, dt_737);
ed_749 = Call(clamp_13, V.Undef, ((V)((ToNum(Get(Get(I_735, "fx"), "v")) - ToNum(hx_748)))), ((V)((-8D))), ((V)(8D)));
Invoke(Get(I_735, "fl"), "step", Get(P_742, "lift"), dt_737);
ld_750 = Call(clamp_13, V.Undef, ((V)((ToNum(Get(Get(I_735, "fl"), "v")) - ToNum(Get(P_742, "lift"))))), ((V)((-10D))), ((V)(10D)));
Set(I_735, "ld", ld_750);
if (!Get(I_735, "lastSpin").IsNullish) {
double dd_824 = 0;
dd_824 = (ToNum(Get(P_742, "spin")) - ToNum(Get(I_735, "lastSpin")));
if ((System.Math.Abs(dd_824) > 180D)) {
OpSet(Get(I_735, "fsp"), "v", 0, ((V)((Round((dd_824 / 360D)) * 360D))));
}
}
Set(I_735, "lastSpin", Get(P_742, "spin"));
Invoke(Get(I_735, "fsp"), "step", Get(P_742, "spin"), dt_737);
sd_751 = Call(clamp_13, V.Undef, ((V)((ToNum(Get(Get(I_735, "fsp"), "v")) - ToNum(Get(P_742, "spin"))))), ((V)((-40D))), ((V)(40D)));
if (Truthy(Get(st_739, "whip"))) {
V SB_825 = default;
SB_825 = Get(I_735, "spb");
if (Truthy(SB_825)) {
Set(Get(SB_825, "f"), "v", Get(P_742, "spin"));
Set(Get(SB_825, "f"), "d", ((V)(0D)));
Set(SB_825, "last", Get(P_742, "spin"));
Set(Get(SB_825, "w"), "v", ((V)(0D)));
Set(Get(SB_825, "w"), "d", ((V)(0D)));
Set(Get(SB_825, "wl"), "v", ((V)(0D)));
Set(Get(SB_825, "wl"), "d", ((V)(0D)));
}
Set(I_735, "spTw", ((V)(0D)));
Set(I_735, "spF", ((V)(0D)));
} else {
V SB_826 = default;
double dd_827 = 0;
V tw_828 = default;
double om_829 = 0;
V f_830 = default;
SB_826 = (Get(I_735, "spb") is var _t831 && Truthy(_t831) ? _t831 : Set(I_735, "spb", NewObj(4).Put("f", New(Fol_20, Get(P_742, "spin"), ((V)(7.5)), ((V)(0.42)))).Put("w", New(Fol_20, ((V)(0D)), ((V)(10D)), ((V)(0.75)))).Put("wl", New(Fol_20, ((V)(0D)), ((V)(6D)), ((V)(0.55)))).Put("last", Get(P_742, "spin")).V));
dd_827 = (ToNum(Get(P_742, "spin")) - ToNum(Get(SB_826, "last")));
if ((System.Math.Abs(dd_827) > 180D)) {
double k_832 = 0;
k_832 = (Round((dd_827 / 360D)) * 360D);
OpSet(Get(SB_826, "f"), "v", 0, ((V)(k_832)));
dd_827 = (dd_827 - k_832);
}
Set(SB_826, "last", Get(P_742, "spin"));
Invoke(Get(SB_826, "f"), "step", Get(P_742, "spin"), dt_737);
tw_828 = Call(clamp_13, V.Undef, ((V)((ToNum(Get(Get(SB_826, "f"), "v")) - ToNum(Get(P_742, "spin"))))), ((V)((-40D))), ((V)(40D)));
om_829 = (GtN(dt_737, 0.002) ? (System.Math.Abs(dd_827) / ToNum(dt_737)) : 0D);
Invoke(Get(SB_826, "w"), "step", Call(clamp_13, V.Undef, ((V)((om_829 / 540D))), ((V)(0D)), ((V)(1D))), dt_737);
f_830 = Call(clamp_13, V.Undef, Get(Get(SB_826, "w"), "v"), ((V)(0D)), ((V)(1D)));
Invoke(Get(SB_826, "wl"), "step", f_830, dt_737);
Set(I_735, "spTw", ((V)(((ToNum(tw_828) * 0.9) * D2R_11))));
Set(I_735, "spF", f_830);
if (!(Truthy(Get(I_735, "generic")))) {
Set(P_742, "twist", Add((Get(P_742, "twist") is var _t833 && Truthy(_t833) ? _t833 : ((V)(0D))), ((V)(((ToNum(tw_828) * 0.9) / 40D)))));
}
OpSet(P_742, "sq", 0, Add(((V)(((-0.045) * ToNum(f_830)))), Call(clamp_13, V.Undef, ((V)(((ToNum(Get(Get(SB_826, "wl"), "v")) - ToNum(f_830)) * 0.14))), ((V)((-0.03))), ((V)(0.05)))));
OpSet(P_742, "lift", 0, ((V)((1.5 * ToNum(f_830)))));
OpSet(P_742, "armL", 0, ((V)((18D * ToNum(f_830)))));
OpSet(P_742, "armR", 0, ((V)((18D * ToNum(f_830)))));
}
Set(I_735, "ed", ed_749);
OpSet(P_742, "earL", 0, Call(clamp_13, V.Undef, ((V)((((-ToNum(ed_749)) * 2D) - (ToNum(ld_750) * 1.3)))), ((V)((-22D))), ((V)(22D))));
OpSet(P_742, "earR", 0, Call(clamp_13, V.Undef, ((V)(((ToNum(ed_749) * 2D) - (ToNum(ld_750) * 1.3)))), ((V)((-22D))), ((V)(22D))));
OpSet(P_742, "wag", 0, Call(clamp_13, V.Undef, ((V)(((ToNum(sd_751) * 0.5) - (ToNum(ed_749) * 3D)))), ((V)((-30D))), ((V)(30D))));
if (Truthy(Invoke(SOFT_42, "has", Get(I_735, "key")))) {
V J_834 = default;
V g_835 = default;
V tx_836 = default;
V ty_837 = default;
V M_838 = default;
V lx_839 = default;
double yw_840 = 0;
double spd_841 = 0;
V sg_842 = default;
J_834 = (Get(I_735, "jel") is var _t843 && Truthy(_t843) ? _t843 : Set(I_735, "jel", NewObj(2).Put("x", New(Fol_20, ((V)(0D)), ((V)(7D)), ((V)(0.3)))).Put("y", New(Fol_20, ((V)(0D)), ((V)(8D)), ((V)(0.36)))).V));
g_835 = (Get(st_739, "soft") is var _t844 && Truthy(_t844) ? _t844 : ((V)(1D)));
tx_836 = Add(Add(Add(Add(Get(P_742, "x"), ((V)((ToNum(Get(P_742, "tilt")) * 0.9)))), ((V)((ToNum(Get(P_742, "turn")) * 5D)))), ((V)((ToNum(Get(P_742, "bend")) * 0.3)))), Get(P_742, "lean"));
ty_837 = Get(P_742, "lift");
OpSet(P_742, "bend", 0, Call(clamp_13, V.Undef, ((V)((((ToNum(Get(Get(J_834, "x"), "v")) - ToNum(tx_836)) * 2.6) * ToNum(g_835)))), ((V)((-16D))), ((V)(16D))));
OpSet(P_742, "sq", 0, Call(clamp_13, V.Undef, ((V)((((ToNum(Get(Get(J_834, "y"), "v")) - ToNum(ty_837)) * 0.008) * ToNum(g_835)))), ((V)((-0.06))), ((V)(0.06))));
M_838 = (Get(I_735, "mot") is var _t845 && Truthy(_t845) ? _t845 : Set(I_735, "mot", NewObj(5).Put("lx", V.Null).Put("ly", ((V)(0D))).Put("yw", ((V)(0D))).Put("vx", New(Fol_20, ((V)(0D)), ((V)(15D)), ((V)(1D)))).Put("vy", New(Fol_20, ((V)(0D)), ((V)(15D)), ((V)(1D)))).V));
lx_839 = Add(Add(Add(Get(P_742, "x"), ((V)((ToNum(Get(P_742, "tilt")) * 0.9)))), Get(P_742, "lean")), ((V)((ToNum(Get(P_742, "bend")) * 0.35))));
yw_840 = (ToNum(Add(Add(Get(P_742, "turn"), Get(P_742, "hyaw")), Get(P_742, "twist"))) * 40D);
if ((!Get(M_838, "lx").IsNullish && GtN(dt_737, 0.002))) {
Invoke(Get(M_838, "vx"), "step", ((V)((((ToNum(lx_839) - ToNum(Get(M_838, "lx"))) / ToNum(dt_737)) + ((((yw_840 - ToNum(Get(M_838, "yw"))) * D2R_11) / ToNum(dt_737)) * 4D)))), dt_737);
Invoke(Get(M_838, "vy"), "step", ((V)((((-(ToNum(Get(P_742, "lift")) - ToNum(Get(M_838, "ly")))) / ToNum(dt_737)) * 0.45))), dt_737);
}
Set(M_838, "lx", lx_839);
Set(M_838, "ly", Get(P_742, "lift"));
Set(M_838, "yw", ((V)(yw_840)));
spd_841 = Hypot(ToNum(Get(Get(M_838, "vx"), "v")), ToNum(Get(Get(M_838, "vy"), "v")));
sg_842 = (!Get(st_739, "stretch").IsNullish ? Get(st_739, "stretch") : ((V)(1D)));
Set(I_735, "ms", ((spd_841 > 2D) ? NewObj(3).Put("s", Call(clamp_13, V.Undef, ((V)(((spd_841 * 0.0034) * ToNum(sg_842)))), ((V)(0D)), ((V)((0.26 * Max(1D, (ToNum(sg_842) * 0.8))))))).Put("c", ((V)((ToNum(Get(Get(M_838, "vx"), "v")) / spd_841)))).Put("n", ((V)((ToNum(Get(Get(M_838, "vy"), "v")) / spd_841)))).V : V.Null));
} else {
Set(I_735, "ms", V.Null);
}
if (Truthy((Get(P_742, "sk") is var _t846 && Truthy(_t846) ? _t846 : Get(P_742, "dv")))) {
OpSet(P_742, "lift", 1, Add((Get(P_742, "sk") is var _t847 && Truthy(_t847) ? _t847 : ((V)(0D))), ((V)((ToNum((Get(P_742, "dv") is var _t848 && Truthy(_t848) ? _t848 : ((V)(0D)))) * 30D)))));
}
Set(I_735, "propZ", Get(st_739, "propZ"));
if (Truthy(Get(I_735, "generic"))) {
if (!(Truthy(Get(I_735, "ready")))) {
return default;
}
Invoke(I_735, "render", I_735, P_742, now_736);
} else {
Call(render_62, V.Undef, I_735, P_742, now_736);
}
if (Truthy(Get(I_735, "olDirty"))) {
Call(outline_91, V.Undef, I_735);
}
if (Truthy(Get(I_735, "olEls"))) {
Call(outlineTick_92, V.Undef, I_735);
}
tt_752 = (ToNum(now_736) - ToNum(Get(Get(I_735, "cur"), "t0")));
fx_753 = (Get(st_739, "fx") is var _t849 && Truthy(_t849) ? _t849 : GetK(FX_61, Get(Get(I_735, "cur"), "name")));
pr_754 = (Truthy(Get(st_739, "prop")) ? Invoke(st_739, "prop", I_735, ((V)(tt_752))) : (Truthy(Get(I_735, "propFn")) ? Invoke(I_735, "propFn", I_735, now_736) : ((V)(""))));
if (Truthy((pr_754 is var _t850 && Truthy(_t850) ? _t850 : Get(I_735, "propOn")))) {
Set(Get(Get(I_735, "pg"), "prop"), "innerHTML", pr_754);
Set(I_735, "propOn", (!(!(Truthy(pr_754))) ? V.True : V.False));
}
Set(Get(I_735, "fxG"), "innerHTML", Add(Add(Add(Add(Call(drawParts_52, V.Undef, I_735, dt_737), (Truthy(fx_753) ? Call(fx_753, V.Undef, I_735, ((V)(tt_752))) : ((V)("")))), Call(water_57, V.Undef, I_735, P_742, now_736)), Call(dustBath_56, V.Undef, I_735, P_742, now_736)), Call(whipFx_60, V.Undef, I_735, P_742)));
return default;
}, 3, "tick", false);
whipFx_60 = Fn((V _self851, int _argc852, V I_858, V P_859, V _a856, V _a857, V[] _rest853) => {
V s_860 = default;
V R_861 = default;
if (_self851.IsNullish) _self851 = GlobalV;
s_860 = Call(clamp_13, V.Undef, (((V)(ToNum(Get(P_859, "sblur")))) is var _t862 && Truthy(_t862) ? _t862 : ((V)(0D))), ((V)(0D)), ((V)(1.5)));
R_861 = (Get(I_858, "root") is var _t863 && Truthy(_t863) ? _t863 : Get(I_858, "art"));
if (!(Truthy(R_861))) {
return ((V)(""));
}
if ((GtN(s_860, 0.02) && !(Truthy(Get(I_858, "mbW"))))) {
V svg_864 = default;
V NS_865 = default;
V df_866 = default;
V f_867 = default;
V b_868 = default;
V W_869 = default;
svg_864 = Get(R_861, "ownerSVGElement");
NS_865 = ((V)("http://www.w3.org/2000/svg"));
df_866 = (Invoke(svg_864, "querySelector", ((V)("defs"))) is var _t870 && Truthy(_t870) ? _t870 : Invoke(svg_864, "insertBefore", Invoke(G("document"), "createElementNS", NS_865, ((V)("defs"))), Get(svg_864, "firstChild")));
f_867 = Invoke(G("document"), "createElementNS", NS_865, ((V)("filter")));
b_868 = Invoke(G("document"), "createElementNS", NS_865, ((V)("feGaussianBlur")));
W_869 = Invoke(G("document"), "createElementNS", NS_865, ((V)("g")));
Invoke(f_867, "setAttribute", ((V)("id")), ((V)(string.Concat("mbl", ToStr(Get(I_858, "u"))))));
Invoke(f_867, "setAttribute", ((V)("x")), ((V)("-40%")));
Invoke(f_867, "setAttribute", ((V)("y")), ((V)("-10%")));
Invoke(f_867, "setAttribute", ((V)("width")), ((V)("180%")));
Invoke(f_867, "setAttribute", ((V)("height")), ((V)("120%")));
Invoke(b_868, "setAttribute", ((V)("in")), ((V)("SourceGraphic")));
Invoke(b_868, "setAttribute", ((V)("stdDeviation")), ((V)("0 0")));
Invoke(f_867, "appendChild", b_868);
Invoke(df_866, "appendChild", f_867);
Invoke(Get(R_861, "parentNode"), "insertBefore", W_869, R_861);
Invoke(W_869, "appendChild", R_861);
Set(I_858, "mbW", W_869);
Set(I_858, "mbF", b_868);
}
if (!(Truthy(Get(I_858, "mbW")))) {
return ((V)(""));
}
if (LeN(s_860, 0.02)) {
if (Truthy(Get(I_858, "mbOn"))) {
Invoke(Get(I_858, "mbW"), "removeAttribute", ((V)("filter")));
Set(I_858, "mbOn", (false ? V.True : V.False));
}
return ((V)(""));
}
Invoke(Get(I_858, "mbF"), "setAttribute", ((V)("stdDeviation")), ((V)(string.Concat(ToStr(Call(r2_14, V.Undef, ((V)((ToNum(s_860) * 3.4))))), " 0"))));
if (!(Truthy(Get(I_858, "mbOn")))) {
Invoke(Get(I_858, "mbW"), "setAttribute", ((V)("filter")), ((V)(string.Concat("url(#mbl", ToStr(Get(I_858, "u")), ")"))));
Set(I_858, "mbOn", (true ? V.True : V.False));
}
return ((V)(""));
return default;
}, 2, "whipFx", false);
render_62 = Fn((V _self871, int _argc872, V I_878, V P_879, V now_880, V _a877, V[] _rest873) => {
V D_881 = default;
V R_882 = default;
V E_883 = default;
V G_884 = default;
double Hh_885 = 0;
V HX_886 = default;
V HY_887 = default;
V HR_888 = default;
V SR_889 = default;
V HRY_890 = default;
V SRY_891 = default;
double KY_892 = 0;
V NX_893 = default;
V NY_894 = default;
double yb_895 = 0;
double yh_896 = 0;
double ya_897 = 0;
double cya_898 = 0;
double sya_899 = 0;
double ph_900 = 0;
double cyb_901 = 0;
double syb_902 = 0;
double cyh_903 = 0;
double syh_904 = 0;
double cp_905 = 0;
double sp_906 = 0;
double bnd_907 = 0;
double HN_908 = 0;
V MS_909 = default;
V MAx_910 = default;
double MAy_911 = 0;
V sq_912 = default;
double sy_913 = 0;
double tr_914 = 0;
double ct_915 = 0;
double stt_916 = 0;
V dn_917 = default;
V glob_918 = default;
V hs_919 = default;
double hr_920 = 0;
double chr_921 = 0;
double shr_922 = 0;
double hyo_923 = 0;
V headT_924 = default;
V sz_925 = default;
V sph_926 = default;
V sphZ_927 = default;
V face_928 = default;
V face0_929 = default;
V wrapF_930 = default;
V vis_931 = default;
V zc_932 = default;
double yw_933 = 0;
double hY_934 = 0;
double hw_935 = 0;
double HP_936 = 0;
V hugF_937 = default;
V byw_938 = default;
V bywZ_939 = default;
V set_940 = default;
V pf_941 = default;
V hF_942 = default;
V skD_943 = default;
V rd_944 = default;
V gr_945 = default;
V keys_946 = default;
V MZ_947 = default;
V NS0_948 = default;
V sm_949 = default;
V decal_950 = default;
V CK_951 = default;
double ox_952 = 0;
double oy_953 = 0;
double ws_954 = 0;
V h_955 = default;
V qz_956 = default;
double cr_957 = 0;
V ty_958 = default;
V wk_959 = default;
V wFold_960 = default;
double gl_961 = 0;
V order_962 = default;
V os_963 = default;
if (_self871.IsNullish) _self871 = GlobalV;
D_881 = Get(I_878, "D");
R_882 = Get(I_878, "RG");
E_883 = Get(I_878, "E");
G_884 = Get(D_881, "G");
Hh_885 = (ToNum(G_884) - ToNum(Get(D_881, "top")));
{ V _t964 = Get(D_881, "head");
{ V _t965 = ListOf(_t964);
{ V _t966 = GetIdx(_t965, 0D);
HX_886 = _t966; }
{ V _t967 = GetIdx(_t965, 1D);
HY_887 = _t967; }
{ V _t968 = GetIdx(_t965, 2D);
HR_888 = _t968; }
} }
SR_889 = Add(HR_888, ((V)(0.5)));
HRY_890 = (GetIdx(Get(D_881, "head"), 3D) is var _t969 && Truthy(_t969) ? _t969 : HR_888);
SRY_891 = Add(HRY_890, ((V)(0.5)));
KY_892 = (ToNum(SRY_891) / ToNum(SR_889));
{ V _t970 = Get(D_881, "neck");
{ V _t971 = ListOf(_t970);
{ V _t972 = GetIdx(_t971, 0D);
NX_893 = _t972; }
{ V _t973 = GetIdx(_t971, 1D);
NY_894 = _t973; }
} }
yb_895 = (ToNum(Add(Get(P_879, "spin"), ((V)((ToNum(Get(P_879, "turn")) * 40D))))) * D2R_11);
yh_896 = (yb_895 + ((ToNum(Add((Get(P_879, "hyaw") is var _t974 && Truthy(_t974) ? _t974 : ((V)(0D))), (Get(P_879, "twist") is var _t975 && Truthy(_t975) ? _t975 : ((V)(0D))))) * 40D) * D2R_11));
ya_897 = (yb_895 + ((ToNum((Get(P_879, "twist") is var _t976 && Truthy(_t976) ? _t976 : ((V)(0D)))) * 24D) * D2R_11));
cya_898 = FdLibm.Cos(ya_897);
sya_899 = FdLibm.Sin(ya_897);
ph_900 = ((ToNum(Get(P_879, "pitch")) * 22D) * D2R_11);
cyb_901 = FdLibm.Cos(yb_895);
syb_902 = FdLibm.Sin(yb_895);
cyh_903 = FdLibm.Cos(yh_896);
syh_904 = FdLibm.Sin(yh_896);
cp_905 = FdLibm.Cos(ph_900);
sp_906 = FdLibm.Sin(ph_900);
bnd_907 = (ToNum(Call(clamp_13, V.Undef, (Get(P_879, "bend") is var _t977 && Truthy(_t977) ? _t977 : ((V)(0D))), ((V)((-32D))), ((V)(32D)))) * D2R_11);
HN_908 = Max(8D, ((ToNum(G_884) - ToNum(GetIdx(Get(D_881, "neck"), 1D))) + 2D));
MS_909 = (Truthy((Get(I_878, "ms") is var _t978 && !Truthy(_t978) ? _t978 : (GtN(Get(Get(I_878, "ms"), "s"), 0.004) ? V.True : V.False))) ? Get(I_878, "ms") : V.Null);
MAx_910 = Add(((V)(50D)), Get(P_879, "x"));
MAy_911 = ((ToNum(G_884) - ToNum(Get(P_879, "lift"))) - ((ToNum(G_884) - ToNum(GetIdx(Get(D_881, "head"), 1D))) * (1D - ToNum(Call(clamp_13, V.Undef, Get(P_879, "sq"), ((V)((-0.25))), ((V)(0.45)))))));
sq_912 = Call(clamp_13, V.Undef, Get(P_879, "sq"), ((V)((-0.25))), ((V)(0.45)));
sy_913 = (1D - ToNum(sq_912));
tr_914 = (ToNum(Get(P_879, "tilt")) * D2R_11);
ct_915 = FdLibm.Cos(tr_914);
stt_916 = FdLibm.Sin(tr_914);
dn_917 = (Truthy((Get(I_878, "dent") is var _t979 && !Truthy(_t979) ? _t979 : (GtN(Get(Get(I_878, "dent"), "a"), 0.01) ? V.True : V.False))) ? Get(I_878, "dent") : V.Null);
glob_918 = Fn((V _self871, int _argc980, V x_986, V y_987, V _a984, V _a985, V[] _rest981) => {
V u_988 = default;
double kx_989 = 0;
double X0_990 = 0;
double h_991 = 0;
double X_992 = 0;
double Y_993 = 0;
V gx_994 = default;
double gy_995 = 0;
if (Truthy(dn_917)) {
double ddx_996 = 0;
double ddy_997 = 0;
double g_998 = 0;
ddx_996 = (ToNum(x_986) - ToNum(Get(dn_917, "x")));
ddy_997 = (ToNum(y_987) - ToNum(Get(dn_917, "y")));
g_998 = FdLibm.Exp(((-((ddx_996 * ddx_996) + (ddy_997 * ddy_997))) / 90D));
if ((g_998 > 0.01)) {
double vx_999 = 0;
double vy_1000 = 0;
V L_1001 = default;
vx_999 = (50D - ToNum(Get(dn_917, "x")));
vy_1000 = (60D - ToNum(Get(dn_917, "y")));
L_1001 = (((V)(Hypot(vx_999, vy_1000))) is var _t1002 && Truthy(_t1002) ? _t1002 : ((V)(1D)));
x_986 = Add(x_986, ((V)(((((vx_999 / ToNum(L_1001)) * ToNum(Get(dn_917, "a"))) * 4.5) * g_998))));
y_987 = Add(y_987, ((V)(((((vy_1000 / ToNum(L_1001)) * ToNum(Get(dn_917, "a"))) * 4.5) * g_998))));
}
}
u_988 = Call(clamp_13, V.Undef, ((V)(((ToNum(G_884) - ToNum(y_987)) / Hh_885))), ((V)(0D)), ((V)(1D)));
kx_989 = (1D + (ToNum(sq_912) * (0.45 + (((0.6 * 4D) * ToNum(u_988)) * (1D - ToNum(u_988))))));
X0_990 = (((ToNum(x_986) - 50D) * kx_989) + (ToNum(Get(P_879, "lean")) * Pow(ToNum(u_988), 1.5)));
h_991 = ((ToNum(G_884) - ToNum(y_987)) * sy_913);
X_992 = X0_990;
Y_993 = (-h_991);
if (NumTruthy(bnd_907)) {
double hn_1003 = 0;
double c_1004 = 0;
hn_1003 = (HN_908 * sy_913);
c_1004 = (bnd_907 / hn_1003);
if ((h_991 <= hn_1003)) {
double a_1005 = 0;
a_1005 = (c_1004 * h_991);
X_992 = (((1D - FdLibm.Cos(a_1005)) / c_1004) + (X0_990 * FdLibm.Cos(a_1005)));
Y_993 = (-((FdLibm.Sin(a_1005) / c_1004) - (X0_990 * FdLibm.Sin(a_1005))));
} else {
double dh_1006 = 0;
double cb_1007 = 0;
double sb_1008 = 0;
dh_1006 = (h_991 - hn_1003);
cb_1007 = FdLibm.Cos(bnd_907);
sb_1008 = FdLibm.Sin(bnd_907);
X_992 = ((((1D - cb_1007) / c_1004) + (X0_990 * cb_1007)) + (dh_1006 * sb_1008));
Y_993 = (-(((sb_1008 / c_1004) - (X0_990 * sb_1008)) + (dh_1006 * cb_1007)));
}
}
gx_994 = Add(((V)(((50D + (X_992 * ct_915)) - (Y_993 * stt_916)))), Get(P_879, "x"));
gy_995 = (ToNum(Add(Add(G_884, ((V)((X_992 * stt_916)))), ((V)((Y_993 * ct_915))))) - ToNum(Get(P_879, "lift")));
if (Truthy(MS_909)) {
V w_1009 = default;
double k_1010 = 0;
double dx_1011 = 0;
double dy_1012 = 0;
double al_1013 = 0;
double pe_1014 = 0;
w_1009 = Call(SM_16, V.Undef, ((V)((ToNum(u_988) * 1.5))));
k_1010 = (1D + (ToNum(Get(MS_909, "s")) * ToNum(w_1009)));
dx_1011 = (ToNum(gx_994) - ToNum(MAx_910));
dy_1012 = (gy_995 - MAy_911);
al_1013 = (((dx_1011 * ToNum(Get(MS_909, "c"))) + (dy_1012 * ToNum(Get(MS_909, "n")))) * k_1010);
pe_1014 = ((((-dx_1011) * ToNum(Get(MS_909, "n"))) + (dy_1012 * ToNum(Get(MS_909, "c")))) / k_1010);
gx_994 = ((V)((ToNum(Add(MAx_910, ((V)((al_1013 * ToNum(Get(MS_909, "c"))))))) - (pe_1014 * ToNum(Get(MS_909, "n"))))));
gy_995 = ((MAy_911 + (al_1013 * ToNum(Get(MS_909, "n")))) + (pe_1014 * ToNum(Get(MS_909, "c"))));
}
return Arr(gx_994, ((V)(gy_995)));
return default;
}, 2, "", true);
hs_919 = Get(I_878, "hs");
hr_920 = (ToNum(Get(P_879, "htilt")) * D2R_11);
chr_921 = FdLibm.Cos(hr_920);
shr_922 = FdLibm.Sin(hr_920);
hyo_923 = ((-ToNum(Get(P_879, "pitch"))) * 1.1);
headT_924 = Fn((V _self871, int _argc1015, V x_1021, V y_1022, V _a1019, V _a1020, V[] _rest1016) => {
double dx_1023 = 0;
double dy_1024 = 0;
x_1021 = ((V)((50D + ((ToNum(x_1021) - 50D) * (1D + (ToNum(hs_919) * 0.6))))));
y_1022 = ((V)(((ToNum(NY_894) - ((ToNum(NY_894) - ToNum(y_1022)) * (1D - ToNum(hs_919)))) + hyo_923)));
dx_1023 = (ToNum(x_1021) - ToNum(NX_893));
dy_1024 = (ToNum(y_1022) - ToNum(NY_894));
return Call(glob_918, V.Undef, ((V)((ToNum(Add(NX_893, ((V)((dx_1023 * chr_921))))) - (dy_1024 * shr_922)))), Add(Add(NY_894, ((V)((dx_1023 * shr_922)))), ((V)((dy_1024 * chr_921)))));
return default;
}, 2, "", true);
sz_925 = Fn((V _self871, int _argc1025, V dx_1031, V dy_1032, V zm_1033, V _a1030, V[] _rest1026) => {
double q_1034 = 0;
double z_1035 = 0;
if (string.Equals(Typeof(zm_1033), "number")) {
return zm_1033;
}
q_1034 = ((1D - ((ToNum(dx_1031) / ToNum(SR_889)) * (ToNum(dx_1031) / ToNum(SR_889)))) - ((ToNum(dy_1032) / ToNum(SRY_891)) * (ToNum(dy_1032) / ToNum(SRY_891))));
z_1035 = ((q_1034 > 0D) ? (ToNum(SR_889) * System.Math.Sqrt(q_1034)) : 0D);
return ((V)((SEqS(zm_1033, "b") ? (-z_1035) : z_1035)));
return default;
}, 3, "", true);
sph_926 = Fn((V _self871, int _argc1036, V x_1042, V y_1043, V zm_1044, V _a1041, V[] _rest1037) => {
double dx_1045 = 0;
double dy_1046 = 0;
V z_1047 = default;
double x1_1048 = 0;
double z1_1049 = 0;
double X_1050 = 0;
double Y_1051 = 0;
dx_1045 = (ToNum(x_1042) - ToNum(HX_886));
dy_1046 = (ToNum(y_1043) - ToNum(HY_887));
z_1047 = Call(sz_925, V.Undef, ((V)(dx_1045)), ((V)(dy_1046)), zm_1044);
x1_1048 = ((dx_1045 * cyh_903) + (ToNum(z_1047) * syh_904));
z1_1049 = (((-dx_1045) * syh_904) + (ToNum(z_1047) * cyh_903));
X_1050 = x1_1048;
Y_1051 = ((dy_1046 * cp_905) - ((z1_1049 * sp_906) * KY_892));
if ((SEq(zm_1044, V.Undef) && ((((dy_1046 * sp_906) / KY_892) + (z1_1049 * cp_905)) < 0D))) {
V nr_1052 = default;
nr_1052 = (((V)(Hypot((X_1050 / ToNum(SR_889)), (Y_1051 / ToNum(SRY_891))))) is var _t1053 && Truthy(_t1053) ? _t1053 : ((V)(1D)));
X_1050 = (X_1050 / ToNum(nr_1052));
Y_1051 = (Y_1051 / ToNum(nr_1052));
}
return Call(headT_924, V.Undef, Add(HX_886, ((V)(X_1050))), Add(HY_887, ((V)(Y_1051))));
return default;
}, 3, "", true);
sphZ_927 = Fn((V _self871, int _argc1054, V x_1060, V y_1061, V zm_1062, V _a1059, V[] _rest1055) => {
double dx_1063 = 0;
double dy_1064 = 0;
V z_1065 = default;
double z1_1066 = 0;
dx_1063 = (ToNum(x_1060) - ToNum(HX_886));
dy_1064 = (ToNum(y_1061) - ToNum(HY_887));
z_1065 = Call(sz_925, V.Undef, ((V)(dx_1063)), ((V)(dy_1064)), zm_1062);
z1_1066 = (((-dx_1063) * syh_904) + (ToNum(z_1065) * cyh_903));
return ((V)((((dy_1064 * sp_906) / KY_892) + (z1_1066 * cp_905))));
return default;
}, 3, "", true);
face_928 = Fn((V _self871, int _argc1067, V x_1073, V y_1074, V _a1071, V _a1072, V[] _rest1068) => {
return Call(sph_926, V.Undef, x_1073, y_1074);
}, 2, "", true);
face0_929 = face_928;
wrapF_930 = Fn((V _self871, int _argc1075, V x_1081, V y_1082, V _a1079, V _a1080, V[] _rest1076) => {
double dx_1083 = 0;
double dy_1084 = 0;
double q_1085 = 0;
V w_1086 = default;
V a_1087 = default;
V b_1088 = default;
dx_1083 = (ToNum(x_1081) - ToNum(HX_886));
dy_1084 = (ToNum(y_1082) - ToNum(HY_887));
q_1085 = ((1D - ((dx_1083 / ToNum(SR_889)) * (dx_1083 / ToNum(SR_889)))) - ((dy_1084 / ToNum(SRY_891)) * (dy_1084 / ToNum(SRY_891))));
w_1086 = Call(SM_16, V.Undef, ((V)(((q_1085 - 0.04) / 0.32))));
if (GeN(w_1086, 1D)) {
return Call(sph_926, V.Undef, x_1081, y_1082);
}
a_1087 = Call(sph_926, V.Undef, x_1081, y_1082);
b_1088 = Call(headT_924, V.Undef, x_1081, y_1082);
return Arr(Add(GetIdx(b_1088, 0D), ((V)(((ToNum(GetIdx(a_1087, 0D)) - ToNum(GetIdx(b_1088, 0D))) * ToNum(w_1086))))), Add(GetIdx(b_1088, 1D), ((V)(((ToNum(GetIdx(a_1087, 1D)) - ToNum(GetIdx(b_1088, 1D))) * ToNum(w_1086))))));
return default;
}, 2, "", true);
vis_931 = Fn((V _self871, int _argc1089, V z_1095, V _a1092, V _a1093, V _a1094, V[] _rest1090) => {
return Call(SM_16, V.Undef, ((V)(((ToNum(z_1095) - 1.5) / 6D))));
}, 1, "", true);
zc_932 = Fn((V _self871, int _argc1096, V x_1102, V y_1103, V zm_1104, V _a1101, V[] _rest1097) => {
return Call(vis_931, V.Undef, Call(sphZ_927, V.Undef, x_1102, y_1103, zm_1104));
}, 3, "", true);
yw_933 = (((((yh_896 / D2R_11) % 360D) + 540D) % 360D) - 180D);
hY_934 = (ToNum(Call(clamp_13, V.Undef, ((V)(yw_933)), ((V)((-85D))), ((V)(85D)))) * D2R_11);
hw_935 = (1D - ToNum(Call(SM_16, V.Undef, ((V)(((System.Math.Abs(yw_933) - 45D) / 40D))))));
HP_936 = (System.Math.PI / 2D);
hugF_937 = Fn((V _self871, int _argc1105, V x_1111, V y_1112, V _a1109, V _a1110, V[] _rest1106) => {
double dx_1113 = 0;
double dy_1114 = 0;
V z_1115 = default;
double r_1116 = 0;
double th_1117 = 0;
double t2_1118 = 0;
double z1_1119 = 0;
V b_1120 = default;
V a_1121 = default;
dx_1113 = (ToNum(x_1111) - ToNum(HX_886));
dy_1114 = (ToNum(y_1112) - ToNum(HY_887));
z_1115 = Call(sz_925, V.Undef, ((V)(dx_1113)), ((V)(dy_1114)));
r_1116 = Hypot(dx_1113, ToNum(z_1115));
th_1117 = FdLibm.Atan2(dx_1113, ToNum(z_1115));
t2_1118 = ((th_1117 < 0D) ? ((-HP_936) + (((th_1117 + HP_936) * (HP_936 + hY_934)) / HP_936)) : (hY_934 + ((th_1117 * (HP_936 - hY_934)) / HP_936)));
z1_1119 = (r_1116 * FdLibm.Cos(t2_1118));
b_1120 = Call(headT_924, V.Undef, Add(HX_886, ((V)((r_1116 * FdLibm.Sin(t2_1118))))), ((V)((ToNum(Add(HY_887, ((V)((dy_1114 * cp_905))))) - ((z1_1119 * sp_906) * KY_892)))));
if ((hw_935 >= 1D)) {
return b_1120;
}
a_1121 = Call(wrapF_930, V.Undef, x_1111, y_1112);
return Arr(Add(GetIdx(a_1121, 0D), ((V)(((ToNum(GetIdx(b_1120, 0D)) - ToNum(GetIdx(a_1121, 0D))) * hw_935)))), Add(GetIdx(a_1121, 1D), ((V)(((ToNum(GetIdx(b_1120, 1D)) - ToNum(GetIdx(a_1121, 1D))) * hw_935)))));
return default;
}, 2, "", true);
byw_938 = Fn((V _self871, int _argc1122, V x_1128, V y_1129, V z_1130, V _a1127, V[] _rest1123) => {
return Call(glob_918, V.Undef, ((V)(((50D + ((ToNum(x_1128) - 50D) * cyb_901)) + (ToNum(z_1130) * syb_902)))), y_1129);
}, 3, "", true);
bywZ_939 = Fn((V _self871, int _argc1131, V x_1137, V z_1138, V _a1135, V _a1136, V[] _rest1132) => {
return ((V)((((-(ToNum(x_1137) - 50D)) * syb_902) + (ToNum(z_1138) * cyb_901))));
}, 2, "", true);
set_940 = Fn((V _self871, int _argc1139, V e_1145, V a_1146, V v_1147, V _a1144, V[] _rest1140) => {
return Invoke(e_1145, "setAttribute", a_1146, v_1147);
}, 3, "", true);
if (Truthy(Get(D_881, "body3"))) {
V B3_1148 = default;
V bx_1149 = default;
V by_1150 = default;
V bz_1151 = default;
V brx_1152 = default;
V bry_1153 = default;
V brz_1154 = default;
double t3_1155 = 0;
double c3_1156 = 0;
double s3_1157 = 0;
B3_1148 = Get(D_881, "body3");
{ V _t1158 = Get(B3_1148, "c");
{ V _t1159 = ListOf(_t1158);
{ V _t1160 = GetIdx(_t1159, 0D);
bx_1149 = _t1160; }
{ V _t1161 = GetIdx(_t1159, 1D);
by_1150 = _t1161; }
{ V _t1162 = GetIdx(_t1159, 2D);
bz_1151 = _t1162; }
} }
{ V _t1163 = Get(B3_1148, "r");
{ V _t1164 = ListOf(_t1163);
{ V _t1165 = GetIdx(_t1164, 0D);
brx_1152 = _t1165; }
{ V _t1166 = GetIdx(_t1164, 1D);
bry_1153 = _t1166; }
{ V _t1167 = GetIdx(_t1164, 2D);
brz_1154 = _t1167; }
} }
t3_1155 = (ToNum((Get(B3_1148, "tilt") is var _t1168 && Truthy(_t1168) ? _t1168 : ((V)(0D)))) * D2R_11);
c3_1156 = FdLibm.Cos(t3_1155);
s3_1157 = FdLibm.Sin(t3_1155);
Call(set_940, V.Undef, Get(E_883, "body"), ((V)("d")), Call(toD_25, V.Undef, Call(ellAx_30, V.Undef, ((V)(((50D + ((ToNum(bx_1149) - 50D) * cyb_901)) + (ToNum(bz_1151) * syb_902)))), by_1150, Arr(Arr(((V)((ToNum(brx_1152) * cyb_901))), ((V)(0D))), Arr(((V)(((ToNum(bry_1153) * s3_1157) * syb_902))), ((V)((ToNum(bry_1153) * c3_1156)))), Arr(((V)(((ToNum(brz_1154) * c3_1156) * syb_902))), ((V)(((-ToNum(brz_1154)) * s3_1157)))))), glob_918));
} else {
if (Truthy(Get(I_878, "furB"))) {
Call(set_940, V.Undef, Get(E_883, "body"), ((V)("d")), ((V)(string.Concat("M", ToStr(Invoke(Invoke(Call(furPts_24, V.Undef, Get(I_878, "furB"), ((V)(yb_895))), "map", Fn((V _self871, int _argc1169, V p_1175, V _a1172, V _a1173, V _a1174, V[] _rest1170) => {
V q_1176 = default;
q_1176 = Call(glob_918, V.Undef, GetIdx(p_1175, 0D), GetIdx(p_1175, 1D));
return ((V)(string.Concat(ToStr(Call(r2_14, V.Undef, GetIdx(q_1176, 0D))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(q_1176, 1D))))));
return default;
}, 1, "", true)), "join", ((V)("L")))), "Z"))));
} else {
Call(set_940, V.Undef, Get(E_883, "body"), ((V)("d")), Call(toD_25, V.Undef, Get(R_882, "body"), glob_918));
}
}
if (Truthy(Get(E_883, "lumps"))) {
double dB_1177 = 0;
dB_1177 = (ToNum((Truthy(Get(D_881, "body3")) ? GetIdx(Get(Get(D_881, "body3"), "c"), 2D) : ((V)(0D)))) * cyb_901);
Invoke(Get(D_881, "lumps"), "forEach", Fn((V _self871, int _argc1178, V L_1184, V i_1185, V _a1182, V _a1183, V[] _rest1179) => {
V lx_1186 = default;
V ly_1187 = default;
V lz_1188 = default;
V lrx_1189 = default;
V lry_1190 = default;
V lrz_1191 = default;
V el_1192 = default;
V fr_1193 = default;
{ V _t1194 = Get(L_1184, "c");
{ V _t1195 = ListOf(_t1194);
{ V _t1196 = GetIdx(_t1195, 0D);
lx_1186 = _t1196; }
{ V _t1197 = GetIdx(_t1195, 1D);
ly_1187 = _t1197; }
{ V _t1198 = GetIdx(_t1195, 2D);
lz_1188 = _t1198; }
} }
{ V _t1199 = Get(L_1184, "r");
{ V _t1200 = ListOf(_t1199);
{ V _t1201 = GetIdx(_t1200, 0D);
lrx_1189 = _t1201; }
{ V _t1202 = GetIdx(_t1200, 1D);
lry_1190 = _t1202; }
{ V _t1203 = GetIdx(_t1200, 2D);
lrz_1191 = _t1203; }
} }
el_1192 = GetK(Get(E_883, "lumps"), i_1185);
fr_1193 = (((((-(ToNum(lx_1186) - 50D)) * syb_902) + (ToNum(lz_1188) * cyb_901)) > dB_1177) ? V.True : V.False);
Call(set_940, V.Undef, el_1192, ((V)("d")), Call(toD_25, V.Undef, Call(ellAx_30, V.Undef, ((V)(((50D + ((ToNum(lx_1186) - 50D) * cyb_901)) + (ToNum(lz_1188) * syb_902)))), ly_1187, Arr(Arr(((V)((ToNum(lrx_1189) * cyb_901))), ((V)(0D))), Arr(((V)(0D)), lry_1190), Arr(((V)((ToNum(lrz_1191) * syb_902))), ((V)(0D))))), glob_918));
if (!SEq(fr_1193, Get(el_1192, "__fr"))) {
Set(el_1192, "__fr", fr_1193);
Invoke(Get(el_1192, "parentNode"), "insertBefore", el_1192, (Truthy(fr_1193) ? Get(Get(E_883, "body"), "nextSibling") : Get(E_883, "body")));
}
return default;
}, 2, "", true));
}
if (Truthy(Get(E_883, "neck3"))) {
V N3_1204 = default;
V nx_1205 = default;
V ny_1206 = default;
V nz_1207 = default;
V nrx_1208 = default;
V nry_1209 = default;
V nrz_1210 = default;
N3_1204 = Get(D_881, "neck3");
{ V _t1211 = Get(N3_1204, "c");
{ V _t1212 = ListOf(_t1211);
{ V _t1213 = GetIdx(_t1212, 0D);
nx_1205 = _t1213; }
{ V _t1214 = GetIdx(_t1212, 1D);
ny_1206 = _t1214; }
{ V _t1215 = GetIdx(_t1212, 2D);
nz_1207 = _t1215; }
} }
{ V _t1216 = Get(N3_1204, "r");
{ V _t1217 = ListOf(_t1216);
{ V _t1218 = GetIdx(_t1217, 0D);
nrx_1208 = _t1218; }
{ V _t1219 = GetIdx(_t1217, 1D);
nry_1209 = _t1219; }
{ V _t1220 = GetIdx(_t1217, 2D);
nrz_1210 = _t1220; }
} }
Call(set_940, V.Undef, Get(E_883, "neck3"), ((V)("d")), Call(toD_25, V.Undef, Call(ellAx_30, V.Undef, ((V)(((50D + ((ToNum(nx_1205) - 50D) * cyb_901)) + (ToNum(nz_1207) * syb_902)))), ny_1206, Arr(Arr(((V)((ToNum(nrx_1208) * cyb_901))), ((V)(0D))), Arr(((V)(0D)), nry_1209), Arr(((V)((ToNum(nrz_1210) * syb_902))), ((V)(0D))))), glob_918));
}
pf_941 = Call(clamp_13, V.Undef, Get(P_879, "puff"), ((V)((-0.5))), ((V)(1.2)));
hF_942 = (Truthy(pf_941) ? Fn((V _self871, int _argc1221, V x_1227, V y_1228, V _a1225, V _a1226, V[] _rest1222) => {
double dy_1229 = 0;
double g_1230 = 0;
dy_1229 = (ToNum(y_1228) - 58D);
g_1230 = FdLibm.Exp((((-dy_1229) * dy_1229) / 80D));
return Call(headT_924, V.Undef, Add(x_1227, ((V)((((((LtN(x_1227, 50D) ? (-1D) : 1D) * ToNum(pf_941)) * 3.2) * g_1230) * ToNum(Call(clamp_13, V.Undef, ((V)((System.Math.Abs((ToNum(x_1227) - 50D)) / 20D))), ((V)(0D)), ((V)(1D)))))))), y_1228);
return default;
}, 2, "", true) : headT_924);
skD_943 = (Truthy(Get(I_878, "furH")) ? ((V)(string.Concat("M", ToStr(Invoke(Invoke(Call(furPts_24, V.Undef, Get(I_878, "furH"), ((V)(yh_896))), "map", Fn((V _self871, int _argc1231, V p_1237, V _a1234, V _a1235, V _a1236, V[] _rest1232) => {
V q_1238 = default;
q_1238 = Call(hF_942, V.Undef, GetIdx(p_1237, 0D), GetIdx(p_1237, 1D));
return ((V)(string.Concat(ToStr(Call(r2_14, V.Undef, GetIdx(q_1238, 0D))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(q_1238, 1D))))));
return default;
}, 1, "", true)), "join", ((V)("L")))), "Z"))) : Call(toD_25, V.Undef, Get(R_882, "skull"), hF_942));
Call(set_940, V.Undef, Get(E_883, "skull"), ((V)("d")), skD_943);
Call(set_940, V.Undef, Get(E_883, "clip"), ((V)("d")), skD_943);
rd_944 = Call(clamp_13, V.Undef, Get(P_879, "red"), ((V)(0D)), ((V)(1D)));
gr_945 = Call(clamp_13, V.Undef, Get(P_879, "green"), ((V)(0D)), ((V)(1D)));
Call(set_940, V.Undef, Get(E_883, "tintR"), ((V)("d")), skD_943);
Call(set_940, V.Undef, Get(E_883, "tintR"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ToNum(rd_944) * 0.34)))));
Call(set_940, V.Undef, Get(E_883, "tintG"), ((V)("d")), skD_943);
Call(set_940, V.Undef, Get(E_883, "tintG"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ToNum(gr_945) * 0.26)))));
if (GtN(gr_945, 0.01)) {
Call(set_940, V.Undef, Get(E_883, "bodyG"), ((V)("d")), Invoke(Get(E_883, "body"), "getAttribute", ((V)("d"))));
}
Call(set_940, V.Undef, Get(E_883, "bodyG"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ToNum(gr_945) * 0.26)))));
keys_946 = NewObj(4).Put("body", ((V)(0D))).Put("head", ((V)(1D))).Put("collar", ((V)(1.5))).Put("prop", (!Get(I_878, "propZ").IsNullish ? Get(I_878, "propZ") : ((V)(5D)))).V;
Set(I_878, "W", NewObj(0).V);
Invoke(Get(R_882, "feet"), "forEach", Fn((V _self871, int _argc1239, V f_1245, V i_1246, V _a1243, V _a1244, V[] _rest1240) => {
V st_1247 = default;
double cy_1248 = 0;
V z_1249 = default;
double X_1250 = 0;
double fsd_1251 = 0;
V FS0_1252 = default;
V FS_1253 = default;
V fd_1254 = default;
V zp_1255 = default;
st_1247 = Call(clamp_13, V.Undef, (((V)(ToNum(Get(P_879, "sit")))) is var _t1256 && Truthy(_t1256) ? _t1256 : ((V)(0D))), ((V)(0D)), ((V)(1D)));
cy_1248 = ((ToNum(Get(f_1245, "y")) - ToNum((Truthy(i_1246) ? Get(P_879, "footR") : Get(P_879, "footL")))) + (ToNum(st_1247) * 4.6));
z_1249 = Add((!Get(D_881, "footZ").IsNullish ? Get(D_881, "footZ") : ((V)(8D))), ((V)((ToNum(st_1247) * 7D))));
X_1250 = ((50D + (((ToNum(Get(f_1245, "x")) - 50D) * (1D + (ToNum(st_1247) * 0.3))) * cyb_901)) + (ToNum(z_1249) * syb_902));
fsd_1251 = (LtN(Get(f_1245, "x"), 50D) ? 1D : (-1D));
if (Truthy(Get(D_881, "web"))) {
V W_1257 = default;
V kk_1258 = default;
double ao_1259 = 0;
double co_1260 = 0;
double so_1261 = 0;
double bx0_1262 = 0;
double d0_1263 = 0;
V mp_1264 = default;
V fd_1265 = default;
W_1257 = Get(D_881, "web");
kk_1258 = (Get(W_1257, "k") is var _t1266 && Truthy(_t1266) ? _t1266 : ((V)(0.32)));
ao_1259 = ((ToNum((Get(W_1257, "out") is var _t1267 && Truthy(_t1267) ? _t1267 : ((V)(0D)))) * D2R_11) * (LtN(Get(f_1245, "x"), 50D) ? (-1D) : 1D));
co_1260 = FdLibm.Cos(ao_1259);
so_1261 = FdLibm.Sin(ao_1259);
bx0_1262 = (50D + ((ToNum(Get(f_1245, "x")) - 50D) * (1D + (ToNum(st_1247) * 0.3))));
d0_1263 = (((-(bx0_1262 - 50D)) * syb_902) + (ToNum(z_1249) * cyb_901));
mp_1264 = Fn((V _self871, int _argc1268, V u_1274, V v_1275, V _a1272, V _a1273, V[] _rest1269) => {
double wx_1276 = 0;
double wz_1277 = 0;
wx_1276 = ((bx0_1262 + (ToNum(u_1274) * co_1260)) + (ToNum(v_1275) * so_1261));
wz_1277 = ((ToNum(z_1249) - (ToNum(u_1274) * so_1261)) + (ToNum(v_1275) * co_1260));
return Call(glob_918, V.Undef, ((V)(((50D + ((wx_1276 - 50D) * cyb_901)) + (wz_1277 * syb_902)))), ((V)((cy_1248 + (ToNum(kk_1258) * ((((-(wx_1276 - 50D)) * syb_902) + (wz_1277 * cyb_901)) - d0_1263))))));
return default;
}, 2, "", true);
fd_1265 = Call(toD_25, V.Undef, Get(R_882, "web"), mp_1264);
Call(set_940, V.Undef, Get(GetK(Get(E_883, "feet"), i_1246), "f"), ((V)("d")), fd_1265);
Call(set_940, V.Undef, Get(GetK(Get(E_883, "feet"), i_1246), "clip"), ((V)("d")), fd_1265);
Call(set_940, V.Undef, Get(GetK(Get(E_883, "feet"), i_1246), "p"), ((V)("d")), (Truthy(Get(R_882, "webT")) ? Call(toD_25, V.Undef, Get(R_882, "webT"), mp_1264) : ((V)(""))));
if (Truthy(Get(GetK(Get(E_883, "feet"), i_1246), "leg"))) {
V L_1278 = default;
V h0_1279 = default;
V top_1280 = default;
L_1278 = Get(W_1257, "leg");
h0_1279 = Call(mp_1264, V.Undef, ((V)(0D)), ((V)(0.6)));
top_1280 = Call(glob_918, V.Undef, ((V)(X_1250)), ((V)(Min((cy_1248 - 1D), ToNum(Add(Get(L_1278, "top"), ((V)(((cy_1248 - ToNum(Get(f_1245, "y"))) * 0.4)))))))));
Call(set_940, V.Undef, Get(GetK(Get(E_883, "feet"), i_1246), "leg"), ((V)("d")), ((V)(string.Concat(new string[] { "M", ToStr(Call(r2_14, V.Undef, GetIdx(h0_1279, 0D))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(h0_1279, 1D))), " L", ToStr(Call(r2_14, V.Undef, GetIdx(top_1280, 0D))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(top_1280, 1D))) }))));
Call(set_940, V.Undef, Get(GetK(Get(E_883, "feet"), i_1246), "leg"), ((V)("stroke-width")), Call(r2_14, V.Undef, ((V)((ToNum((Get(L_1278, "w") is var _t1281 && Truthy(_t1281) ? _t1281 : ((V)(3D)))) * System.Math.Sqrt(sy_913))))));
}
SetK(keys_946, ((V)((Truthy(i_1246) ? "footR" : "footL"))), Add(((V)(d0_1263)), (!Get(D_881, "footK").IsNullish ? Get(D_881, "footK") : ((V)((-10D))))));
SetK(Get(I_878, "W"), ((V)((Truthy(i_1246) ? "footR" : "footL"))), Call(glob_918, V.Undef, ((V)(X_1250)), ((V)(cy_1248))));
return default;
}
FS0_1252 = (Get(D_881, "footS") is var _t1282 && Truthy(_t1282) ? _t1282 : Arr(((V)(9D)), ((V)(5.5)), ((V)(8D))));
FS_1253 = Arr(((V)((ToNum(GetIdx(FS0_1252, 0D)) * (1D + (ToNum(st_1247) * 0.06))))), ((V)((ToNum(GetIdx(FS0_1252, 1D)) * (1D + (ToNum(st_1247) * 0.75))))), GetIdx(FS0_1252, 2D));
fd_1254 = Call(toD_25, V.Undef, Call(ellAx_30, V.Undef, ((V)(X_1250)), ((V)(cy_1248)), Arr(Arr(((V)((ToNum(GetIdx(FS_1253, 0D)) * cyb_901))), ((V)(0D))), Arr(((V)(((((fsd_1251 * ToNum(st_1247)) * ToNum(GetIdx(FS_1253, 1D))) * 0.28) * cyb_901))), GetIdx(FS_1253, 1D)), Arr(((V)((ToNum(GetIdx(FS_1253, 2D)) * syb_902))), ((V)(0D))))), glob_918);
Call(set_940, V.Undef, Get(GetK(Get(E_883, "feet"), i_1246), "f"), ((V)("d")), fd_1254);
Call(set_940, V.Undef, Get(GetK(Get(E_883, "feet"), i_1246), "clip"), ((V)("d")), fd_1254);
zp_1255 = Add(z_1249, ((V)(7.5)));
Call(set_940, V.Undef, Get(GetK(Get(E_883, "feet"), i_1246), "p"), ((V)("d")), Invoke(Invoke((Get(D_881, "pads") is var _t1298 && Truthy(_t1298) ? _t1298 : Arr(Arr(((V)(0D)), ((V)(1D)), ((V)(5D)), ((V)(2.8))))), "map", Fn((V _self871, int _argc1283, V _a1285, V _a1286, V _a1287, V _a1288, V[] _rest1284) => {
V dx_1291 = default;
V dy_1293 = default;
V rx_1295 = default;
V ry_1297 = default;
{ V _t1289 = ListOf(_a1285);
{ V _t1290 = GetIdx(_t1289, 0D);
dx_1291 = _t1290; }
{ V _t1292 = GetIdx(_t1289, 1D);
dy_1293 = _t1292; }
{ V _t1294 = GetIdx(_t1289, 2D);
rx_1295 = _t1294; }
{ V _t1296 = GetIdx(_t1289, 3D);
ry_1297 = _t1296; }
}
return Call(toD_25, V.Undef, Call(ellAx_30, V.Undef, ((V)(((50D + (((ToNum(Add(((V)(((ToNum(Get(f_1245, "x")) * (1D + (ToNum(st_1247) * 0.3))) - (ToNum(st_1247) * 15D)))), dx_1291)) - (((fsd_1251 * ToNum(st_1247)) * ToNum(dy_1293)) * 0.28)) - 50D) * cyb_901)) + (ToNum(zp_1255) * syb_902)))), ((V)(((cy_1248 + (ToNum(dy_1293) * (1D + (ToNum(st_1247) * 0.75)))) - (ToNum(st_1247) * 0.8)))), Arr(Arr(((V)((ToNum(rx_1295) * cyb_901))), ((V)(0D))), Arr(((V)(0D)), ((V)((ToNum(ry_1297) * (1D + (ToNum(st_1247) * 0.6)))))))), glob_918);
}, 1, "", true)), "join", ((V)(" "))));
Call(set_940, V.Undef, Get(GetK(Get(E_883, "feet"), i_1246), "p"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((0.9 * ToNum(Call(SM_16, V.Undef, ((V)((cyb_901 * 3D))))))))));
SetK(keys_946, ((V)((Truthy(i_1246) ? "footR" : "footL"))), Add(((V)((((-(ToNum(Get(f_1245, "x")) - 50D)) * syb_902) + (ToNum(z_1249) * cyb_901)))), (!Get(D_881, "footK").IsNullish ? Get(D_881, "footK") : ((V)((-10D))))));
SetK(Get(I_878, "W"), ((V)((Truthy(i_1246) ? "footR" : "footL"))), Call(glob_918, V.Undef, ((V)(X_1250)), ((V)(cy_1248))));
return default;
}, 2, "", true));
if (Truthy(Get(E_883, "crest"))) {
Invoke(Get(D_881, "crest"), "forEach", Fn((V _self871, int _argc1299, V C_1305, V i_1306, V _a1303, V _a1304, V[] _rest1300) => {
double a_1307 = 0;
double ca_1308 = 0;
double sa_1309 = 0;
V u0_1310 = default;
V v0_1311 = default;
double tu_1312 = 0;
double st_1313 = 0;
double ct_1314 = 0;
a_1307 = (((ToNum(Add((Get(P_879, "earL") is var _t1315 && Truthy(_t1315) ? _t1315 : ((V)(0D))), (Get(P_879, "earR") is var _t1316 && Truthy(_t1316) ? _t1316 : ((V)(0D))))) / 2D) * ToNum((!Get(C_1305, "k").IsNullish ? Get(C_1305, "k") : ((V)(1D))))) * D2R_11);
ca_1308 = FdLibm.Cos(a_1307);
sa_1309 = FdLibm.Sin(a_1307);
{ V _t1317 = Get(C_1305, "root");
{ V _t1318 = ListOf(_t1317);
{ V _t1319 = GetIdx(_t1318, 0D);
u0_1310 = _t1319; }
{ V _t1320 = GetIdx(_t1318, 1D);
v0_1311 = _t1320; }
} }
tu_1312 = (ToNum((Get(C_1305, "turn") is var _t1321 && Truthy(_t1321) ? _t1321 : ((V)(0D)))) * D2R_11);
st_1313 = FdLibm.Sin(tu_1312);
ct_1314 = FdLibm.Cos(tu_1312);
Call(set_940, V.Undef, GetK(Get(E_883, "crest"), i_1306), ((V)("d")), Call(toD_25, V.Undef, GetK(Get(R_882, "crest"), i_1306), Fn((V _self871, int _argc1322, V u_1328, V v_1329, V _a1326, V _a1327, V[] _rest1323) => {
double du_1330 = 0;
double dv_1331 = 0;
double U_1332 = 0;
V V_1333 = default;
du_1330 = (ToNum(u_1328) - ToNum(u0_1310));
dv_1331 = (ToNum(v_1329) - ToNum(v0_1311));
U_1332 = (ToNum(Add(u0_1310, ((V)((du_1330 * ca_1308))))) - (dv_1331 * sa_1309));
V_1333 = Add(Add(v0_1311, ((V)((du_1330 * sa_1309)))), ((V)((dv_1331 * ca_1308))));
return Call(sph_926, V.Undef, Add(HX_886, ((V)((U_1332 * st_1313)))), V_1333, ((V)(((-U_1332) * ct_1314))));
return default;
}, 2, "", true)));
return default;
}, 2, "", true));
}
Invoke(Get(R_882, "ears"), "forEach", Fn((V _self871, int _argc1334, V e_1340, V i_1341, V _a1338, V _a1339, V[] _rest1335) => {
double a_1342 = 0;
V px_1343 = default;
V py_1344 = default;
V S_1345 = default;
V pts_1346 = default;
double lim_1347 = 0;
V zm_1348 = default;
V bend_1349 = default;
V ed_1350 = default;
V hdAt_1351 = default;
V tq_1352 = default;
V tb_1353 = default;
a_1342 = (ToNum((Truthy(Get(e_1340, "flop")) ? ((V)((ToNum((LtN(Get(e_1340, "side"), 0D) ? Get(P_879, "earL") : ((V)((-ToNum(Get(P_879, "earR"))))))) * 0.9))) : (LtN(Get(e_1340, "side"), 0D) ? ((V)((-ToNum(Get(P_879, "earL"))))) : Get(P_879, "earR")))) * D2R_11);
{ V _t1354 = Get(e_1340, "pivot");
{ V _t1355 = ListOf(_t1354);
{ V _t1356 = GetIdx(_t1355, 0D);
px_1343 = _t1356; }
{ V _t1357 = GetIdx(_t1355, 1D);
py_1344 = _t1357; }
} }
S_1345 = Get(e_1340, "S");
pts_1346 = Arr();
lim_1347 = ((ToNum(SR_889) * ToNum(SR_889)) * 0.81);
if (Truthy(Get(e_1340, "lobe"))) {
V lx_1358 = default;
V ly_1359 = default;
V la_1360 = default;
V lb_1361 = default;
V lc_1362 = default;
V lz_1363 = default;
V lr_1364 = default;
double ca_1365 = 0;
double sa_1366 = 0;
double vx_1367 = 0;
double vy_1368 = 0;
double cx_1369 = 0;
V cy_1370 = default;
double rr_1371 = 0;
double cr_1372 = 0;
double sr_1373 = 0;
V pv_1374 = default;
V C_1375 = default;
V ld_1376 = default;
double bk_1377 = 0;
V msh_1378 = default;
{ V _t1379 = Get(e_1340, "lobe");
{ V _t1380 = ListOf(_t1379);
{ V _t1381 = GetIdx(_t1380, 0D);
lx_1358 = _t1381; }
{ V _t1382 = GetIdx(_t1380, 1D);
ly_1359 = _t1382; }
{ V _t1383 = GetIdx(_t1380, 2D);
la_1360 = _t1383; }
{ V _t1384 = GetIdx(_t1380, 3D);
lb_1361 = _t1384; }
{ V _t1385 = GetIdx(_t1380, 4D);
lc_1362 = _t1385; }
{ V _t1386 = GetIdx(_t1380, 5D);
lz_1363 = _t1386; }
{ V _t1387 = GetIdx(_t1380, 6D);
lr_1364 = _t1387; }
} }
ca_1365 = FdLibm.Cos(a_1342);
sa_1366 = FdLibm.Sin(a_1342);
vx_1367 = (ToNum(lx_1358) - ToNum(px_1343));
vy_1368 = (ToNum(ly_1359) - ToNum(py_1344));
cx_1369 = (ToNum(Add(px_1343, ((V)((vx_1367 * ca_1365))))) - (vy_1368 * sa_1366));
cy_1370 = Add(Add(py_1344, ((V)((vx_1367 * sa_1366)))), ((V)((vy_1368 * ca_1365))));
rr_1371 = ((ToNum((lr_1364 is var _t1388 && Truthy(_t1388) ? _t1388 : ((V)(0D)))) * D2R_11) + a_1342);
cr_1372 = FdLibm.Cos(rr_1371);
sr_1373 = FdLibm.Sin(rr_1371);
pv_1374 = Fn((V _self871, int _argc1389, V x_1395, V y_1396, V z_1397, V _a1394, V[] _rest1390) => {
double z1_1398 = 0;
z1_1398 = (((-ToNum(x_1395)) * syh_904) + (ToNum(z_1397) * cyh_903));
return Arr(((V)(((ToNum(x_1395) * cyh_903) + (ToNum(z_1397) * syh_904)))), ((V)(((ToNum(y_1396) * cp_905) - ((z1_1398 * sp_906) * KY_892)))));
return default;
}, 3, "", true);
C_1375 = Call(pv_1374, V.Undef, ((V)((cx_1369 - ToNum(HX_886)))), ((V)((ToNum(cy_1370) - ToNum(HY_887)))), (lz_1363 is var _t1399 && Truthy(_t1399) ? _t1399 : ((V)(0D))));
ld_1376 = Call(toD_25, V.Undef, Call(ellAx_30, V.Undef, Add(HX_886, GetIdx(C_1375, 0D)), Add(HY_887, GetIdx(C_1375, 1D)), Arr(Call(pv_1374, V.Undef, ((V)((ToNum(la_1360) * cr_1372))), ((V)((ToNum(la_1360) * sr_1373))), ((V)(0D))), Call(pv_1374, V.Undef, ((V)(((-ToNum(lb_1361)) * sr_1373))), ((V)((ToNum(lb_1361) * cr_1372))), ((V)(0D))), Call(pv_1374, V.Undef, ((V)(0D)), ((V)(0D)), lc_1362))), headT_924);
Call(set_940, V.Undef, Get(GetK(Get(E_883, "ears"), i_1341), "o"), ((V)("d")), ld_1376);
Call(set_940, V.Undef, Get(GetK(Get(E_883, "ears"), i_1341), "clip"), ((V)("d")), ld_1376);
Call(set_940, V.Undef, Get(GetK(Get(E_883, "ears"), i_1341), "n"), ((V)("opacity")), ((V)(0D)));
bk_1377 = (1D - ToNum(Call(SM_16, V.Undef, ((V)(((((-ToNum(Get(e_1340, "side"))) * syh_904) - 0.2) / 0.35))))));
msh_1378 = ((V)(string.Concat("translate(", ToStr(Call(r2_14, V.Undef, ((V)(((((-ToNum(Get(e_1340, "side"))) * (1D - bk_1377)) * 2D) * ToNum(Add(la_1360, lb_1361))))))), " 0)")));
Invoke((Get(GetK(Get(E_883, "ears"), i_1341), "mk") is var _t1408 && Truthy(_t1408) ? _t1408 : Arr()), "forEach", Fn((V _self871, int _argc1400, V m_1406, V j_1407, V _a1404, V _a1405, V[] _rest1401) => {
Call(set_940, V.Undef, m_1406, ((V)("d")), (Truthy(j_1407) ? Invoke(Get(E_883, "body"), "getAttribute", ((V)("d"))) : skD_943));
Call(set_940, V.Undef, m_1406, ((V)("transform")), msh_1378);
return default;
}, 2, "", true));
SetK(keys_946, ((V)((Truthy(i_1341) ? "earR" : "earL"))), ((V)(2.5)));
SetK(Get(I_878, "W"), ((V)((Truthy(i_1341) ? "earR" : "earL"))), Call(headT_924, V.Undef, Add(HX_886, GetIdx(C_1375, 0D)), Add(Add(HY_887, GetIdx(C_1375, 1D)), ((V)((ToNum(lb_1361) * 0.8))))));
return default;
}
zm_1348 = Fn((V _self871, int _argc1409, V x_1415, V y_1416, V _a1413, V _a1414, V[] _rest1410) => {
double dx_1417 = 0;
double dy_1418 = 0;
double q_1419 = 0;
dx_1417 = (ToNum(x_1415) - ToNum(HX_886));
dy_1418 = (ToNum(y_1416) - ToNum(HY_887));
q_1419 = ((1D - ((dx_1417 / ToNum(SR_889)) * (dx_1417 / ToNum(SR_889)))) - ((dy_1418 / ToNum(SRY_891)) * (dy_1418 / ToNum(SRY_891))));
return ((V)((Truthy(Get(e_1340, "flop")) ? ((q_1419 > 0D) ? ((0.12 * ToNum(SR_889)) * System.Math.Sqrt(q_1419)) : 1D) : ((q_1419 > 0D) ? (((-0.35) * ToNum(SR_889)) * System.Math.Sqrt(q_1419)) : 0D))));
return default;
}, 2, "", true);
bend_1349 = Fn((V _self871, int _argc1420, V x_1426, V y_1427, V w_1428, V _a1425, V[] _rest1421) => {
double vx_1429 = 0;
double vy_1430 = 0;
double c_1431 = 0;
double s_1432 = 0;
vx_1429 = (ToNum(x_1426) - ToNum(px_1343));
vy_1430 = (ToNum(y_1427) - ToNum(py_1344));
c_1431 = FdLibm.Cos((a_1342 * ToNum(w_1428)));
s_1432 = FdLibm.Sin((a_1342 * ToNum(w_1428)));
return Arr(((V)((ToNum(Add(px_1343, ((V)((vx_1429 * c_1431))))) - (vy_1430 * s_1432)))), Add(Add(py_1344, ((V)((vx_1429 * s_1432)))), ((V)((vy_1430 * c_1431)))));
return default;
}, 3, "", true);
{
foreach (V _k1433 in Iterate(Get(S_1345, "secs"))) {
V q_1434 = default;
q_1434 = _k1433;
double w_1435 = 0;
double c_1436 = 0;
double s_1437 = 0;
double nx_1438 = 0;
double ny_1439 = 0;
V cx_1440 = default;
V cy_1441 = default;
w_1435 = Pow(ToNum(Get(q_1434, "s")), 1.3);
c_1436 = FdLibm.Cos((a_1342 * w_1435));
s_1437 = FdLibm.Sin((a_1342 * w_1435));
nx_1438 = ((ToNum(Get(S_1345, "nx")) * c_1436) - (ToNum(Get(S_1345, "ny")) * s_1437));
ny_1439 = ((ToNum(Get(S_1345, "nx")) * s_1437) + (ToNum(Get(S_1345, "ny")) * c_1436));
{ V _t1442 = Call(bend_1349, V.Undef, Get(q_1434, "cx"), Get(q_1434, "cy"), ((V)(w_1435)));
{ V _t1443 = ListOf(_t1442);
{ V _t1444 = GetIdx(_t1443, 0D);
cx_1440 = _t1444; }
{ V _t1445 = GetIdx(_t1443, 1D);
cy_1441 = _t1445; }
} }
{
double k_1446 = 0;
k_1446 = 0D;
while (true) {
if (!((k_1446 < 14D))) break;
double f_1448 = 0;
double cf_1449 = 0;
V X_1450 = default;
V Y_1451 = default;
double Z_1452 = 0;
double dx_1453 = 0;
double dy_1454 = 0;
f_1448 = ((k_1446 / 14D) * TAU_12);
cf_1449 = FdLibm.Cos(f_1448);
X_1450 = Add(cx_1440, ((V)(((nx_1438 * ToNum(Get(q_1434, "hw"))) * cf_1449))));
Y_1451 = Add(cy_1441, ((V)(((ny_1439 * ToNum(Get(q_1434, "hw"))) * cf_1449))));
if (!(Truthy(Get(e_1340, "flop")))) {
double wr_1455 = 0;
wr_1455 = (1D - ToNum(Call(SM_16, V.Undef, ((V)(((ToNum(Get(q_1434, "s")) - 0.08) / 0.3))))));
if ((wr_1455 > 0D)) {
double dx0_1456 = 0;
double dy0_1457 = 0;
double rr_1458 = 0;
dx0_1456 = (ToNum(X_1450) - ToNum(HX_886));
dy0_1457 = (ToNum(Y_1451) - ToNum(HY_887));
rr_1458 = Hypot((dx0_1456 / ToNum(SR_889)), (dy0_1457 / ToNum(SRY_891)));
if ((rr_1458 > 0.94)) {
double r1_1459 = 0;
r1_1459 = (0.94 + ((rr_1458 - 0.94) * (1D - wr_1455)));
X_1450 = Add(HX_886, ((V)(((dx0_1456 * r1_1459) / rr_1458))));
Y_1451 = Add(HY_887, ((V)(((dy0_1457 * r1_1459) / rr_1458))));
}
}
}
Z_1452 = ((ToNum(Call(zm_1348, V.Undef, X_1450, Y_1451)) - (ToNum(Get(q_1434, "hd")) * 0.15)) + (ToNum(Get(q_1434, "hd")) * FdLibm.Sin(f_1448)));
dx_1453 = (ToNum(X_1450) - ToNum(HX_886));
dy_1454 = (ToNum(Y_1451) - ToNum(HY_887));
if (Truthy((Get(e_1340, "flop") is var _t1460 && Truthy(_t1460) ? _t1460 : ((((((dx_1453 / ToNum(SR_889)) * (dx_1453 / ToNum(SR_889))) + ((dy_1454 / ToNum(SRY_891)) * (dy_1454 / ToNum(SRY_891)))) + ((Z_1452 / ToNum(SR_889)) * (Z_1452 / ToNum(SR_889)))) >= 0.81) ? V.True : V.False)))) {
Invoke(pts_1346, "push", Call(sph_926, V.Undef, X_1450, Y_1451, ((V)(Z_1452))));
}
k_1446++;
}
}
}
}
ed_1350 = Call(closedD_29, V.Undef, Call(hull_28, V.Undef, pts_1346));
Call(set_940, V.Undef, Get(GetK(Get(E_883, "ears"), i_1341), "o"), ((V)("d")), ed_1350);
Call(set_940, V.Undef, Get(GetK(Get(E_883, "ears"), i_1341), "clip"), ((V)("d")), ed_1350);
hdAt_1351 = Fn((V _self871, int _argc1461, V s_1467, V _a1464, V _a1465, V _a1466, V[] _rest1462) => {
V L_1468 = default;
double j_1469 = 0;
V A_1470 = default;
V B_1471 = default;
V u_1472 = default;
L_1468 = Get(S_1345, "secs");
j_1469 = 0D;
while (((j_1469 < (ToNum(Get(L_1468, "length")) - 2D)) && Lt(Get(GetIdx(L_1468, (j_1469 + 1D)), "s"), s_1467))) {
j_1469++;
}
A_1470 = GetIdx(L_1468, j_1469);
B_1471 = (GetIdx(L_1468, (j_1469 + 1D)) is var _t1473 && Truthy(_t1473) ? _t1473 : A_1470);
u_1472 = (Gt(Get(B_1471, "s"), Get(A_1470, "s")) ? Call(clamp_13, V.Undef, ((V)(((ToNum(s_1467) - ToNum(Get(A_1470, "s"))) / (ToNum(Get(B_1471, "s")) - ToNum(Get(A_1470, "s")))))), ((V)(0D)), ((V)(1D))) : ((V)(0D)));
return Call(lerp_15, V.Undef, Get(A_1470, "hd"), Get(B_1471, "hd"), u_1472);
return default;
}, 1, "", true);
if (Truthy(Get(e_1340, "n"))) {
Call(set_940, V.Undef, Get(GetK(Get(E_883, "ears"), i_1341), "n"), ((V)("d")), Call(toD_25, V.Undef, Get(e_1340, "n"), Fn((V _self871, int _argc1474, V x_1480, V y_1481, V _a1478, V _a1479, V[] _rest1475) => {
V s_1482 = default;
V hd_1483 = default;
V bx_1484 = default;
V by_1485 = default;
s_1482 = Call(clamp_13, V.Undef, ((V)(((((ToNum(x_1480) - ToNum(px_1343)) * ToNum(Get(e_1340, "ux"))) + ((ToNum(y_1481) - ToNum(py_1344)) * ToNum(Get(e_1340, "uy")))) / ToNum(Get(S_1345, "amax"))))), ((V)(0D)), ((V)(1D)));
hd_1483 = Call(hdAt_1351, V.Undef, s_1482);
{ V _t1486 = Call(bend_1349, V.Undef, x_1480, y_1481, ((V)(Pow(ToNum(s_1482), 1.3))));
{ V _t1487 = ListOf(_t1486);
{ V _t1488 = GetIdx(_t1487, 0D);
bx_1484 = _t1488; }
{ V _t1489 = GetIdx(_t1487, 1D);
by_1485 = _t1489; }
} }
return Call(sph_926, V.Undef, bx_1484, by_1485, ((V)(((ToNum(Call(zm_1348, V.Undef, bx_1484, by_1485)) - (ToNum(hd_1483) * 0.15)) + (ToNum(hd_1483) * 0.85)))));
return default;
}, 2, "", true)));
}
Call(set_940, V.Undef, Get(GetK(Get(E_883, "ears"), i_1341), "n"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((0.8 * ToNum(Call(SM_16, V.Undef, ((V)(((cyh_903 * cp_905) * 3D))))))))));
SetK(keys_946, ((V)((Truthy(i_1341) ? "earR" : "earL"))), (Truthy(Get(e_1340, "behind")) ? ((V)((-99D))) : Add(Call(sphZ_927, V.Undef, px_1343, py_1344, Call(zm_1348, V.Undef, px_1343, py_1344)), ((V)((Truthy(Get(e_1340, "flop")) ? 2.5 : 1D))))));
if (Truthy((Get(D_881, "earK") is var _t1490 && !Truthy(_t1490) ? _t1490 : (!(Truthy(Get(e_1340, "behind"))) ? V.True : V.False)))) {
V k_1491 = default;
double hf_1492 = 0;
k_1491 = Add(GetK(keys_946, ((V)((Truthy(i_1341) ? "earR" : "earL")))), Get(D_881, "earK"));
hf_1492 = (cyh_903 * cp_905);
if (!Get(D_881, "earF").IsNullish) {
if (Truthy(Get(I_878, "eBk"))) {
if (Gt(((V)(hf_1492)), Add(Get(D_881, "earF"), ((V)(0.05))))) {
Set(I_878, "eBk", ((V)(0D)));
}
} else {
if ((hf_1492 < (ToNum(Get(D_881, "earF")) - 0.05))) {
Set(I_878, "eBk", ((V)(1D)));
}
}
}
SetK(keys_946, ((V)((Truthy(i_1341) ? "earR" : "earL"))), ((GtN(k_1491, 1.35) && !(Truthy(Get(I_878, "eBk")))) ? k_1491 : ((V)((-40D)))));
}
tq_1352 = GetIdx(Get(S_1345, "secs"), (ToNum(Get(Get(S_1345, "secs"), "length")) - 1D));
tb_1353 = Call(bend_1349, V.Undef, Get(tq_1352, "cx"), Get(tq_1352, "cy"), ((V)(1D)));
SetK(Get(I_878, "W"), ((V)((Truthy(i_1341) ? "earR" : "earL"))), Call(sph_926, V.Undef, GetIdx(tb_1353, 0D), GetIdx(tb_1353, 1D), ((V)(0D))));
return default;
}, 2, "", true));
if (Truthy(Get(D_881, "wing"))) {
Invoke(Get(R_882, "arms"), "forEach", Fn((V _self871, int _argc1493, V a_1499, V i_1500, V _a1497, V _a1498, V[] _rest1494) => {
V WG_1501 = default;
V sd_1502 = default;
V Lf_1503 = default;
V av_1504 = default;
double o_1505 = 0;
double co_1506 = 0;
double so_1507 = 0;
double om_1508 = 0;
double lm_1509 = 0;
double cw_1510 = 0;
double sw_1511 = 0;
double cl_1512 = 0;
double sl_1513 = 0;
V ro_1514 = default;
V ry0_1515 = default;
V rz0_1516 = default;
double xr_1517 = 0;
V rot_1518 = default;
V W3_1519 = default;
V P3_1520 = default;
V Nv_1521 = default;
double nd_1522 = 0;
V C_1523 = default;
double dC_1524 = 0;
V bz0_1525 = default;
WG_1501 = Get(D_881, "wing");
sd_1502 = Get(a_1499, "side");
Lf_1503 = (LtN(sd_1502, 0D) ? V.True : V.False);
av_1504 = Call(clamp_13, V.Undef, ((V)((ToNum((Truthy(Lf_1503) ? Get(P_879, "armL") : Get(P_879, "armR"))) - (ToNum((Truthy(Lf_1503) ? Get(P_879, "hLy") : Get(P_879, "hRy"))) * 2D)))), ((V)((-40D))), ((V)(170D)));
o_1505 = (ToNum((Get(WG_1501, "out") is var _t1526 && Truthy(_t1526) ? _t1526 : ((V)(0D)))) * D2R_11);
co_1506 = FdLibm.Cos(o_1505);
so_1507 = FdLibm.Sin(o_1505);
om_1508 = (ToNum(Add((Get(WG_1501, "rest") is var _t1527 && Truthy(_t1527) ? _t1527 : ((V)(0D))), ((V)(((90D - ToNum((Get(WG_1501, "rest") is var _t1528 && Truthy(_t1528) ? _t1528 : ((V)(0D))))) * ToNum(Call(SM_16, V.Undef, ((V)((ToNum(av_1504) / 60D)))))))))) * D2R_11);
lm_1509 = ((GtN(av_1504, 30D) ? ((ToNum(av_1504) - 30D) * 0.9) : (LtN(av_1504, 0D) ? (ToNum(av_1504) * 0.4) : 0D)) * D2R_11);
cw_1510 = FdLibm.Cos(om_1508);
sw_1511 = FdLibm.Sin(om_1508);
cl_1512 = FdLibm.Cos(lm_1509);
sl_1513 = FdLibm.Sin(lm_1509);
{ V _t1529 = Get(WG_1501, "root");
{ V _t1530 = ListOf(_t1529);
{ V _t1531 = GetIdx(_t1530, 0D);
ro_1514 = _t1531; }
{ V _t1532 = GetIdx(_t1530, 1D);
ry0_1515 = _t1532; }
{ V _t1533 = GetIdx(_t1530, 2D);
rz0_1516 = _t1533; }
} }
xr_1517 = ((50D + (ToNum(sd_1502) * ToNum(ro_1514))) + (ToNum((Truthy(Lf_1503) ? Get(P_879, "hLx") : ((V)((-ToNum(Get(P_879, "hRx"))))))) * 0.3));
rot_1518 = Fn((V _self871, int _argc1534, V x0_1540, V y0_1541, V z0_1542, V _a1539, V[] _rest1535) => {
double x1_1543 = 0;
double z1_1544 = 0;
x1_1543 = ((ToNum(x0_1540) * cw_1510) - ((ToNum(sd_1502) * ToNum(z0_1542)) * sw_1511));
z1_1544 = (((ToNum(sd_1502) * ToNum(x0_1540)) * sw_1511) + (ToNum(z0_1542) * cw_1510));
return Arr(((V)(((x1_1543 * cl_1512) + ((ToNum(sd_1502) * ToNum(y0_1541)) * sl_1513)))), ((V)(((((-ToNum(sd_1502)) * x1_1543) * sl_1513) + (ToNum(y0_1541) * cl_1512)))), ((V)(z1_1544)));
return default;
}, 3, "", true);
W3_1519 = Fn((V _self871, int _argc1545, V A_1551, V B_1552, V bu_1553, V _a1550, V[] _rest1546) => {
V x_1554 = default;
V y_1555 = default;
V z_1556 = default;
{ V _t1557 = Call(rot_1518, V.Undef, ((V)((ToNum(sd_1502) * ((ToNum(B_1552) * so_1507) + (ToNum(bu_1553) * co_1506))))), ((V)(((ToNum(B_1552) * co_1506) - (ToNum(bu_1553) * so_1507)))), ((V)((-ToNum(A_1551)))));
{ V _t1558 = ListOf(_t1557);
{ V _t1559 = GetIdx(_t1558, 0D);
x_1554 = _t1559; }
{ V _t1560 = GetIdx(_t1558, 1D);
y_1555 = _t1560; }
{ V _t1561 = GetIdx(_t1558, 2D);
z_1556 = _t1561; }
} }
return Arr(Add(((V)(xr_1517)), x_1554), Add(ry0_1515, y_1555), Add(rz0_1516, z_1556));
return default;
}, 3, "", true);
P3_1520 = Fn((V _self871, int _argc1562, V A_1568, V B_1569, V _a1566, V _a1567, V[] _rest1563) => {
V x_1570 = default;
V y_1571 = default;
V z_1572 = default;
{ V _t1573 = Call(W3_1519, V.Undef, A_1568, B_1569, ((V)((ToNum((Get(WG_1501, "bulge") is var _t1574 && Truthy(_t1574) ? _t1574 : ((V)(0D)))) * Max(0D, ((1D - Pow(((ToNum(A_1568) - 10D) / 12D), 2D)) - Pow(((ToNum(B_1569) - 3D) / 7D), 2D)))))));
{ V _t1575 = ListOf(_t1573);
{ V _t1576 = GetIdx(_t1575, 0D);
x_1570 = _t1576; }
{ V _t1577 = GetIdx(_t1575, 1D);
y_1571 = _t1577; }
{ V _t1578 = GetIdx(_t1575, 2D);
z_1572 = _t1578; }
} }
return Call(glob_918, V.Undef, ((V)(((50D + ((ToNum(x_1570) - 50D) * cya_898)) + (ToNum(z_1572) * sya_899)))), y_1571);
return default;
}, 2, "", true);
Nv_1521 = Call(rot_1518, V.Undef, ((V)((ToNum(sd_1502) * co_1506))), ((V)((-so_1507))), ((V)(0D)));
nd_1522 = (((-ToNum(GetIdx(Nv_1521, 0D))) * sya_899) + (ToNum(GetIdx(Nv_1521, 2D)) * cya_898));
C_1523 = Call(W3_1519, V.Undef, ((V)(10D)), ((V)(3D)), ((V)(0D)));
dC_1524 = (((-(ToNum(GetIdx(C_1523, 0D)) - 50D)) * sya_899) + (ToNum(GetIdx(C_1523, 2D)) * cya_898));
bz0_1525 = (Truthy(Get(D_881, "body3")) ? GetIdx(Get(Get(D_881, "body3"), "c"), 2D) : ((V)(0D)));
Call(set_940, V.Undef, GetK(Get(E_883, "arms"), i_1500), ((V)("d")), Call(toD_25, V.Undef, Get(R_882, "wing"), P3_1520));
if (Truthy(Get(E_883, "wingF"))) {
Call(set_940, V.Undef, GetK(Get(E_883, "wingF"), i_1500), ((V)("d")), Call(toD_25, V.Undef, Get(R_882, "wingF"), P3_1520));
Call(set_940, V.Undef, GetK(Get(E_883, "wingF"), i_1500), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((0.8 * ToNum(Call(SM_16, V.Undef, ((V)(((System.Math.Abs(nd_1522) * 3D) - 0.3))))))))));
}
Call(set_940, V.Undef, GetK(Get(E_883, "armT"), i_1500), ((V)("opacity")), ((V)(0D)));
SetK(keys_946, ((V)((Truthy(i_1500) ? "armR" : "armL"))), ((V)((dC_1524 - (ToNum(bz0_1525) * cya_898)))));
SetK(Get(I_878, "W"), ((V)((Truthy(Lf_1503) ? "pawL" : "pawR"))), Call(P3_1520, V.Undef, ((V)(19D)), ((V)(4D))));
return default;
}, 2, "", true));
} else {
Invoke(Get(R_882, "arms"), "forEach", Fn((V _self871, int _argc1579, V a_1585, V i_1586, V _a1583, V _a1584, V[] _rest1580) => {
V Lf_1587 = default;
V av_1588 = default;
double @base_1589 = 0;
V wr_1590 = default;
double ang_1591 = 0;
double c_1592 = 0;
double s_1593 = 0;
V px_1594 = default;
V py_1595 = default;
double vx_1596 = 0;
double vy_1597 = 0;
V mhx_1598 = default;
V mhy_1599 = default;
V hy_1600 = default;
V hz_1601 = default;
V cx_1602 = default;
V cy_1603 = default;
V z_1604 = default;
double sx_1605 = 0;
V sy0_1606 = default;
double ddx_1607 = 0;
double ddy_1608 = 0;
double len_1609 = 0;
double r0_1610 = 0;
double c0_1611 = 0;
double s0_1612 = 0;
V ax_1613 = default;
double PX_1614 = 0;
V Sw_1615 = default;
V Pw_1616 = default;
double mx_1617 = 0;
double my_1618 = 0;
double tx_1619 = 0;
double ty_1620 = 0;
V tl_1621 = default;
double nx_1622 = 0;
double ny_1623 = 0;
double bu_1624 = 0;
Lf_1587 = (LtN(Get(a_1585, "side"), 0D) ? V.True : V.False);
av_1588 = (Truthy(Lf_1587) ? Get(P_879, "armL") : Get(P_879, "armR"));
@base_1589 = (Truthy(Lf_1587) ? 20D : (-20D));
wr_1590 = Call(SM_16, V.Undef, ((V)((System.Math.Abs(ToNum(av_1588)) / 45D))));
ang_1591 = (ToNum(Add((Truthy(Lf_1587) ? Get(P_879, "armL") : ((V)((-ToNum(Get(P_879, "armR")))))), ((V)(((@base_1589 - ToNum(GetIdx(Get(a_1585, "e"), 4D))) * ToNum(wr_1590)))))) * D2R_11);
c_1592 = FdLibm.Cos(ang_1591);
s_1593 = FdLibm.Sin(ang_1591);
{ V _t1625 = Get(a_1585, "pivot");
{ V _t1626 = ListOf(_t1625);
{ V _t1627 = GetIdx(_t1626, 0D);
px_1594 = _t1627; }
{ V _t1628 = GetIdx(_t1626, 1D);
py_1595 = _t1628; }
} }
vx_1596 = (ToNum(GetIdx(Get(a_1585, "e"), 0D)) - ToNum(px_1594));
vy_1597 = (ToNum(GetIdx(Get(a_1585, "e"), 1D)) - ToNum(py_1595));
{ V _t1629 = (Truthy(Get(I_878, "mapHand")) ? Invoke(I_878, "mapHand", (Truthy(Lf_1587) ? Get(P_879, "hLx") : ((V)((-ToNum(Get(P_879, "hRx")))))), (Truthy(Lf_1587) ? Get(P_879, "hLy") : Get(P_879, "hRy"))) : Arr(((V)((ToNum((Truthy(Lf_1587) ? Get(P_879, "hLx") : ((V)((-ToNum(Get(P_879, "hRx"))))))) * ToNum((Get(I_878, "hkx") is var _t1630 && Truthy(_t1630) ? _t1630 : ((V)(1D))))))), (Truthy(Lf_1587) ? Get(P_879, "hLy") : Get(P_879, "hRy"))));
{ V _t1631 = ListOf(_t1629);
{ V _t1632 = GetIdx(_t1631, 0D);
mhx_1598 = _t1632; }
{ V _t1633 = GetIdx(_t1631, 1D);
mhy_1599 = _t1633; }
} }
hy_1600 = mhy_1599;
hz_1601 = (Truthy(Lf_1587) ? Get(P_879, "hLz") : Get(P_879, "hRz"));
cx_1602 = Add(Add(Add(((V)((ToNum(Add(px_1594, ((V)((vx_1596 * c_1592))))) - (vy_1597 * s_1593)))), (Truthy(Lf_1587) ? mhx_1598 : ((V)((-ToNum(mhx_1598)))))), ((V)((ToNum((Get(I_878, "ed") is var _t1634 && Truthy(_t1634) ? _t1634 : ((V)(0D)))) * 0.35)))), ((V)((Truthy(Get(I_878, "mapHand")) ? ((ToNum(Get(a_1585, "side")) * 7D) * ToNum(wr_1590)) : 0D))));
cy_1603 = Add(Add(Add(py_1595, ((V)((vx_1596 * s_1593)))), ((V)((vy_1597 * c_1592)))), hy_1600);
z_1604 = Add(Add((!Get(D_881, "armZ").IsNullish ? Get(D_881, "armZ") : ((V)(9D))), hz_1601), ((V)((Max(0D, (-ToNum(hy_1600))) * 0.25))));
sx_1605 = (ToNum(px_1594) - (ToNum(Get(a_1585, "side")) * 1.2));
sy0_1606 = Add(py_1595, ((V)(1.5)));
ddx_1607 = (ToNum(cx_1602) - sx_1605);
ddy_1608 = (ToNum(cy_1603) - ToNum(sy0_1606));
len_1609 = Hypot(ddx_1607, ddy_1608);
r0_1610 = ((ToNum(GetIdx(Get(a_1585, "e"), 4D)) * D2R_11) + ang_1591);
if ((len_1609 > 9D)) {
double want_1635 = 0;
double df_1636 = 0;
want_1635 = (FdLibm.Atan2(ddy_1608, ddx_1607) - (System.Math.PI / 2D));
df_1636 = (want_1635 - r0_1610);
df_1636 = ((((df_1636 % TAU_12) + (TAU_12 * 1.5)) % TAU_12) - System.Math.PI);
r0_1610 = (r0_1610 + (df_1636 * ToNum(Call(SM_16, V.Undef, ((V)(((len_1609 - 9D) / 8D)))))));
}
c0_1611 = FdLibm.Cos(r0_1610);
s0_1612 = FdLibm.Sin(r0_1610);
ax_1613 = Invoke(Arr(Arr(((V)((ToNum(GetIdx(Get(a_1585, "e"), 2D)) * c0_1611))), ((V)((ToNum(GetIdx(Get(a_1585, "e"), 2D)) * s0_1612))), ((V)(0D))), Arr(((V)(((-ToNum(GetIdx(Get(a_1585, "e"), 3D))) * s0_1612))), ((V)((ToNum(GetIdx(Get(a_1585, "e"), 3D)) * c0_1611))), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), (Get(D_881, "armD") is var _t1650 && Truthy(_t1650) ? _t1650 : ((V)(6.5))))), "map", Fn((V _self871, int _argc1637, V _a1639, V _a1640, V _a1641, V _a1642, V[] _rest1638) => {
V x_1645 = default;
V y_1647 = default;
V zz_1649 = default;
{ V _t1643 = ListOf(_a1639);
{ V _t1644 = GetIdx(_t1643, 0D);
x_1645 = _t1644; }
{ V _t1646 = GetIdx(_t1643, 1D);
y_1647 = _t1646; }
{ V _t1648 = GetIdx(_t1643, 2D);
zz_1649 = _t1648; }
}
return Arr(((V)(((ToNum(x_1645) * cya_898) + (ToNum(zz_1649) * sya_899)))), y_1647);
}, 1, "", true));
PX_1614 = ((50D + ((ToNum(cx_1602) - 50D) * cya_898)) + (ToNum(z_1604) * sya_899));
Call(set_940, V.Undef, GetK(Get(E_883, "arms"), i_1586), ((V)("d")), Call(toD_25, V.Undef, Call(ellAx_30, V.Undef, ((V)(PX_1614)), cy_1603, ax_1613), glob_918));
SetK(keys_946, ((V)((Truthy(i_1586) ? "armR" : "armL"))), ((V)((((-(ToNum(cx_1602) - 50D)) * sya_899) + (ToNum(z_1604) * cya_898)))));
if (!Get(D_881, "armCut").IsNullish) {
double rf_1651 = 0;
V ab_1652 = default;
rf_1651 = (((-(ToNum(GetIdx(Get(a_1585, "e"), 0D)) - 50D)) * sya_899) + (ToNum((!Get(D_881, "armZ").IsNullish ? Get(D_881, "armZ") : ((V)(9D)))) * cya_898));
ab_1652 = (Get(I_878, "aBk") is var _t1653 && Truthy(_t1653) ? _t1653 : Set(I_878, "aBk", Arr(((V)(0D)), ((V)(0D)))));
if (Truthy(GetK(ab_1652, i_1586))) {
if (Gt(((V)(rf_1651)), Add(Get(D_881, "armCut"), ((V)(0.6))))) {
SetK(ab_1652, i_1586, ((V)(0D)));
}
} else {
if ((rf_1651 < (ToNum(Get(D_881, "armCut")) - 0.6))) {
SetK(ab_1652, i_1586, ((V)(1D)));
}
}
if (Truthy(GetK(ab_1652, i_1586))) {
SetK(keys_946, ((V)((Truthy(i_1586) ? "armR" : "armL"))), ((V)(Min(ToNum(GetK(keys_946, ((V)((Truthy(i_1586) ? "armR" : "armL"))))), 0.3))));
}
}
Sw_1615 = Call(glob_918, V.Undef, ((V)(((50D + ((sx_1605 - 50D) * cya_898)) + (4D * sya_899)))), sy0_1606);
Pw_1616 = Call(glob_918, V.Undef, ((V)(PX_1614)), cy_1603);
mx_1617 = (ToNum(Add(GetIdx(Sw_1615, 0D), GetIdx(Pw_1616, 0D))) / 2D);
my_1618 = (ToNum(Add(GetIdx(Sw_1615, 1D), GetIdx(Pw_1616, 1D))) / 2D);
tx_1619 = (ToNum(GetIdx(Pw_1616, 0D)) - ToNum(GetIdx(Sw_1615, 0D)));
ty_1620 = (ToNum(GetIdx(Pw_1616, 1D)) - ToNum(GetIdx(Sw_1615, 1D)));
tl_1621 = (((V)(Hypot(tx_1619, ty_1620))) is var _t1654 && Truthy(_t1654) ? _t1654 : ((V)(1D)));
nx_1622 = ((-ty_1620) / ToNum(tl_1621));
ny_1623 = (tx_1619 / ToNum(tl_1621));
if (((nx_1622 * ToNum(Get(a_1585, "side"))) < 0D)) {
nx_1622 = (-nx_1622);
ny_1623 = (-ny_1623);
}
bu_1624 = (Max(0D, (ToNum(tl_1621) - 10D)) * 0.18);
Call(set_940, V.Undef, GetK(Get(E_883, "armT"), i_1586), ((V)("d")), ((V)(string.Concat(new string[] { "M", ToStr(Call(r2_14, V.Undef, GetIdx(Sw_1615, 0D))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(Sw_1615, 1D))), " Q", ToStr(Call(r2_14, V.Undef, ((V)((mx_1617 + (nx_1622 * bu_1624)))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((my_1618 + (ny_1623 * bu_1624)))))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(Pw_1616, 0D))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(Pw_1616, 1D))) }))));
Call(set_940, V.Undef, GetK(Get(E_883, "armT"), i_1586), ((V)("stroke-width")), Call(r2_14, V.Undef, ((V)((9.5 * System.Math.Sqrt(((1D + (ToNum(sq_912) * 0.4)) * sy_913)))))));
Call(set_940, V.Undef, GetK(Get(E_883, "armT"), i_1586), ((V)("opacity")), Call(r2_14, V.Undef, Call(SM_16, V.Undef, ((V)(((len_1609 - 7.5) / 5D))))));
SetK(Get(I_878, "W"), ((V)((Truthy(Lf_1587) ? "pawL" : "pawR"))), Pw_1616);
return default;
}, 2, "", true));
}
{
V b_1655 = default;
double wa_1656 = 0;
double cu_1657 = 0;
double dnk_1658 = 0;
V T3_1659 = default;
V sp3_1660 = default;
double tw_1661 = 0;
b_1655 = GetIdx(Get(R_882, "tail"), 0D);
wa_1656 = (ToNum(Get(P_879, "wag")) * D2R_11);
cu_1657 = ((ToNum(Get(P_879, "curl")) * 40D) * D2R_11);
dnk_1658 = ((SEqS(Get(I_878, "key"), "mittens") || SEqS(Get(I_878, "key"), "duchess")) ? (ToNum(Call(clamp_13, V.Undef, ((V)((ToNum((Get(P_879, "wd") is var _t1662 && Truthy(_t1662) ? _t1662 : ((V)(0D)))) * 1.6))), ((V)(0D)), ((V)(1D)))) * 1.4) : 0D);
T3_1659 = (!(!(Truthy(Get(D_881, "tail3")))) ? V.True : V.False);
sp3_1660 = Invoke(Get(R_882, "tail"), "map", Fn((V _self871, int _argc1663, V _a1665, V _a1666, V _a1667, V _a1668, V[] _rest1664) => {
double th_1678 = 0;
double c_1679 = 0;
double sn_1680 = 0;
double vx_1681 = 0;
double vy_1682 = 0;
double X_1683 = 0;
V Y_1684 = default;
V Z_1685 = default;
V x_1671 = default;
V y_1673 = default;
V s_1675 = default;
V z_1677 = default;
{ V _t1669 = ListOf(_a1665);
{ V _t1670 = GetIdx(_t1669, 0D);
x_1671 = _t1670; }
{ V _t1672 = GetIdx(_t1669, 1D);
y_1673 = _t1672; }
{ V _t1674 = GetIdx(_t1669, 2D);
s_1675 = _t1674; }
{ V _t1676 = GetIdx(_t1669, 3D);
z_1677 = _t1676; }
}
th_1678 = ((((Truthy(T3_1659) ? (wa_1656 * 0.3) : wa_1656) * Pow(ToNum(s_1675), 1.2)) - (cu_1657 * Pow(ToNum(s_1675), 1.6))) + (dnk_1658 * Pow(ToNum(s_1675), 1.1)));
c_1679 = FdLibm.Cos(th_1678);
sn_1680 = FdLibm.Sin(th_1678);
vx_1681 = (ToNum(x_1671) - ToNum(GetIdx(b_1655, 0D)));
vy_1682 = (ToNum(y_1673) - ToNum(GetIdx(b_1655, 1D)));
X_1683 = (ToNum(Add(GetIdx(b_1655, 0D), ((V)((vx_1681 * c_1679))))) - (vy_1682 * sn_1680));
Y_1684 = Add(Add(GetIdx(b_1655, 1D), ((V)((vx_1681 * sn_1680)))), ((V)((vy_1682 * c_1679))));
Z_1685 = z_1677;
if (Truthy(T3_1659)) {
double ty_1686 = 0;
double cw_1687 = 0;
double sw_1688 = 0;
double ux_1689 = 0;
double uz_1690 = 0;
ty_1686 = ((wa_1656 * ToNum((Get(D_881, "tailWag") is var _t1691 && Truthy(_t1691) ? _t1691 : ((V)(1.3))))) * Pow(ToNum(s_1675), 1.1));
cw_1687 = FdLibm.Cos(ty_1686);
sw_1688 = FdLibm.Sin(ty_1686);
ux_1689 = (X_1683 - ToNum(GetIdx(b_1655, 0D)));
uz_1690 = (ToNum(Z_1685) - ToNum(GetIdx(b_1655, 3D)));
X_1683 = (ToNum(Add(GetIdx(b_1655, 0D), ((V)((ux_1689 * cw_1687))))) - (uz_1690 * sw_1688));
Z_1685 = Add(Add(GetIdx(b_1655, 3D), ((V)((ux_1689 * sw_1688)))), ((V)((uz_1690 * cw_1687))));
}
return Call(byw_938, V.Undef, ((V)(X_1683)), Y_1684, Z_1685);
return default;
}, 1, "", true));
tw_1661 = (ToNum((Get(D_881, "tailK") is var _t1692 && Truthy(_t1692) ? _t1692 : ((V)(7D)))) * System.Math.Sqrt(((1D + (ToNum(sq_912) * 0.5)) * sy_913)));
Call(set_940, V.Undef, Get(E_883, "tail"), ((V)("d")), Call(smoothD_26, V.Undef, sp3_1660));
Call(set_940, V.Undef, Get(E_883, "tail"), ((V)("stroke-width")), Call(r2_14, V.Undef, ((V)(((tw_1661 * ToNum((Get(D_881, "tailW") is var _t1693 && Truthy(_t1693) ? _t1693 : ((V)(7D))))) / 7D)))));
Call(set_940, V.Undef, Get(E_883, "tailH"), ((V)("d")), Call(smoothD_26, V.Undef, Invoke(Invoke(sp3_1660, "slice", ((V)(0D)), ((V)((-1D)))), "map", Fn((V _self871, int _argc1694, V p_1700, V _a1697, V _a1698, V _a1699, V[] _rest1695) => {
return Arr(((V)((ToNum(GetIdx(p_1700, 0D)) - (tw_1661 * 0.16)))), ((V)((ToNum(GetIdx(p_1700, 1D)) - (tw_1661 * 0.18)))));
}, 1, "", true))));
Call(set_940, V.Undef, Get(E_883, "tailH"), ((V)("stroke-width")), Call(r2_14, V.Undef, ((V)((((tw_1661 * ToNum((Get(D_881, "tailW") is var _t1701 && Truthy(_t1701) ? _t1701 : ((V)(7D))))) / 7D) * ToNum((Get(D_881, "tailHLW") is var _t1702 && Truthy(_t1702) ? _t1702 : ((V)(0.3)))))))));
if (Truthy(Get(E_883, "tailF"))) {
V wb_1703 = default;
V wt_1704 = default;
V n_1705 = default;
V hwAt_1706 = default;
V NR_1707 = default;
double dn_1708 = 0;
V L_1709 = default;
V Rr_1710 = default;
V tp_1711 = default;
V tq_1712 = default;
double ux_1713 = 0;
double uy_1714 = 0;
V ul_1715 = default;
V hT_1716 = default;
V cap_1717 = default;
V s0_1718 = default;
V s1_1719 = default;
double vx0_1720 = 0;
double vy0_1721 = 0;
V vl0_1722 = default;
V h0_1723 = default;
double nx0_1724 = 0;
double ny0_1725 = 0;
V @base_1726 = default;
V fd_1727 = default;
V mid_1728 = default;
V Rx_1729 = default;
{ V _t1730 = Get(D_881, "tailTaper");
{ V _t1731 = ListOf(_t1730);
{ V _t1732 = GetIdx(_t1731, 0D);
wb_1703 = _t1732; }
{ V _t1733 = GetIdx(_t1731, 1D);
wt_1704 = _t1733; }
} }
n_1705 = Get(sp3_1660, "length");
hwAt_1706 = Fn((V _self871, int _argc1734, V i_1740, V _a1737, V _a1738, V _a1739, V[] _rest1735) => {
return ((V)(((tw_1661 * ToNum(Add(wb_1703, ((V)(((ToNum(wt_1704) - ToNum(wb_1703)) * Pow((ToNum(i_1740) / (ToNum(n_1705) - 1D)), 0.85))))))) * (1D + (0.14 * (1D - ToNum(Call(SM_16, V.Undef, ((V)(((ToNum(i_1740) / (ToNum(n_1705) - 1D)) / 0.3)))))))))));
}, 1, "", true);
NR_1707 = Invoke(sp3_1660, "map", Fn((V _self871, int _argc1741, V p_1747, V i_1748, V _a1745, V _a1746, V[] _rest1742) => {
V a_1749 = default;
V b_1750 = default;
double dx_1751 = 0;
double dy_1752 = 0;
V l_1753 = default;
a_1749 = GetIdx(sp3_1660, Max(0D, (ToNum(i_1748) - 1D)));
b_1750 = GetIdx(sp3_1660, Min((ToNum(n_1705) - 1D), ToNum(Add(i_1748, ((V)(1D))))));
dx_1751 = (ToNum(GetIdx(b_1750, 0D)) - ToNum(GetIdx(a_1749, 0D)));
dy_1752 = (ToNum(GetIdx(b_1750, 1D)) - ToNum(GetIdx(a_1749, 1D)));
l_1753 = (((V)(Hypot(dx_1751, dy_1752))) is var _t1754 && Truthy(_t1754) ? _t1754 : ((V)(1D)));
return Arr(((V)(((-dy_1752) / ToNum(l_1753)))), ((V)((dx_1751 / ToNum(l_1753)))));
return default;
}, 2, "", true));
dn_1708 = (GeN(Invoke(NR_1707, "reduce", Fn((V _self871, int _argc1755, V q_1761, V v_1762, V _a1759, V _a1760, V[] _rest1756) => {
return Add(q_1761, GetIdx(v_1762, 1D));
}, 2, "", true), ((V)(0D))), 0D) ? 1D : (-1D));
L_1709 = Invoke(sp3_1660, "map", Fn((V _self871, int _argc1763, V p_1769, V i_1770, V _a1767, V _a1768, V[] _rest1764) => {
return Arr(((V)((ToNum(GetIdx(p_1769, 0D)) - ((ToNum(GetIdx(GetK(NR_1707, i_1770), 0D)) * ToNum(Call(hwAt_1706, V.Undef, i_1770))) * dn_1708)))), ((V)((ToNum(GetIdx(p_1769, 1D)) - ((ToNum(GetIdx(GetK(NR_1707, i_1770), 1D)) * ToNum(Call(hwAt_1706, V.Undef, i_1770))) * dn_1708)))));
}, 2, "", true));
Rr_1710 = Invoke(sp3_1660, "map", Fn((V _self871, int _argc1771, V p_1777, V i_1778, V _a1775, V _a1776, V[] _rest1772) => {
return Arr(Add(GetIdx(p_1777, 0D), ((V)(((ToNum(GetIdx(GetK(NR_1707, i_1778), 0D)) * ToNum(Call(hwAt_1706, V.Undef, i_1778))) * dn_1708)))), Add(GetIdx(p_1777, 1D), ((V)(((ToNum(GetIdx(GetK(NR_1707, i_1778), 1D)) * ToNum(Call(hwAt_1706, V.Undef, i_1778))) * dn_1708)))));
}, 2, "", true));
tp_1711 = GetIdx(sp3_1660, (ToNum(n_1705) - 1D));
tq_1712 = GetIdx(sp3_1660, (ToNum(n_1705) - 2D));
ux_1713 = (ToNum(GetIdx(tp_1711, 0D)) - ToNum(GetIdx(tq_1712, 0D)));
uy_1714 = (ToNum(GetIdx(tp_1711, 1D)) - ToNum(GetIdx(tq_1712, 1D)));
ul_1715 = (((V)(Hypot(ux_1713, uy_1714))) is var _t1779 && Truthy(_t1779) ? _t1779 : ((V)(1D)));
hT_1716 = Call(hwAt_1706, V.Undef, ((V)((ToNum(n_1705) - 1D))));
cap_1717 = Invoke(Arr(((V)(0.25)), ((V)(0.5)), ((V)(0.75))), "map", Fn((V _self871, int _argc1780, V f_1786, V _a1783, V _a1784, V _a1785, V[] _rest1781) => {
double t_1787 = 0;
double nx_1788 = 0;
double ny_1789 = 0;
t_1787 = (ToNum(f_1786) * System.Math.PI);
nx_1788 = (ToNum(GetIdx(GetIdx(NR_1707, (ToNum(n_1705) - 1D)), 0D)) * dn_1708);
ny_1789 = (ToNum(GetIdx(GetIdx(NR_1707, (ToNum(n_1705) - 1D)), 1D)) * dn_1708);
return Arr(Add(GetIdx(tp_1711, 0D), ((V)(((((ux_1713 / ToNum(ul_1715)) * FdLibm.Sin(t_1787)) - (nx_1788 * FdLibm.Cos(t_1787))) * ToNum(hT_1716))))), Add(GetIdx(tp_1711, 1D), ((V)(((((uy_1714 / ToNum(ul_1715)) * FdLibm.Sin(t_1787)) - (ny_1789 * FdLibm.Cos(t_1787))) * ToNum(hT_1716))))));
return default;
}, 1, "", true));
s0_1718 = GetIdx(sp3_1660, 0D);
s1_1719 = GetIdx(sp3_1660, 2D);
vx0_1720 = (ToNum(GetIdx(s1_1719, 0D)) - ToNum(GetIdx(s0_1718, 0D)));
vy0_1721 = (ToNum(GetIdx(s1_1719, 1D)) - ToNum(GetIdx(s0_1718, 1D)));
vl0_1722 = (((V)(Hypot(vx0_1720, vy0_1721))) is var _t1790 && Truthy(_t1790) ? _t1790 : ((V)(1D)));
h0_1723 = Call(hwAt_1706, V.Undef, ((V)(0D)));
nx0_1724 = (ToNum(GetIdx(GetIdx(NR_1707, 0D), 0D)) * dn_1708);
ny0_1725 = (ToNum(GetIdx(GetIdx(NR_1707, 0D), 1D)) * dn_1708);
@base_1726 = Invoke(Arr(((V)(0.2)), ((V)(0.4)), ((V)(0.6)), ((V)(0.8))), "map", Fn((V _self871, int _argc1791, V f_1797, V _a1794, V _a1795, V _a1796, V[] _rest1792) => {
double t_1798 = 0;
t_1798 = (ToNum(f_1797) * System.Math.PI);
return Arr(Add(GetIdx(s0_1718, 0D), ((V)((((nx0_1724 * FdLibm.Cos(t_1798)) - (((vx0_1720 / ToNum(vl0_1722)) * FdLibm.Sin(t_1798)) * 0.55)) * ToNum(h0_1723))))), Add(GetIdx(s0_1718, 1D), ((V)((((ny0_1725 * FdLibm.Cos(t_1798)) - (((vy0_1721 / ToNum(vl0_1722)) * FdLibm.Sin(t_1798)) * 0.55)) * ToNum(h0_1723))))));
return default;
}, 1, "", true));
fd_1727 = Call(closedD_29, V.Undef, Invoke(L_1709, "concat", cap_1717, Invoke(Invoke(Rr_1710, "slice"), "reverse"), @base_1726));
Call(set_940, V.Undef, Get(E_883, "tailF"), ((V)("d")), fd_1727);
Call(set_940, V.Undef, Get(E_883, "tailSC"), ((V)("d")), fd_1727);
mid_1728 = Invoke(sp3_1660, "map", Fn((V _self871, int _argc1799, V p_1805, V i_1806, V _a1803, V _a1804, V[] _rest1800) => {
return Arr(Add(GetIdx(p_1805, 0D), ((V)((((ToNum(GetIdx(GetK(NR_1707, i_1806), 0D)) * ToNum(Call(hwAt_1706, V.Undef, i_1806))) * dn_1708) * 0.25)))), Add(GetIdx(p_1805, 1D), ((V)((((ToNum(GetIdx(GetK(NR_1707, i_1806), 1D)) * ToNum(Call(hwAt_1706, V.Undef, i_1806))) * dn_1708) * 0.25)))));
}, 2, "", true));
Rx_1729 = Invoke(sp3_1660, "map", Fn((V _self871, int _argc1807, V p_1813, V i_1814, V _a1811, V _a1812, V[] _rest1808) => {
return Arr(Add(GetIdx(p_1813, 0D), ((V)((((ToNum(GetIdx(GetK(NR_1707, i_1814), 0D)) * ToNum(Call(hwAt_1706, V.Undef, i_1814))) * dn_1708) * 1.5)))), Add(GetIdx(p_1813, 1D), ((V)((((ToNum(GetIdx(GetK(NR_1707, i_1814), 1D)) * ToNum(Call(hwAt_1706, V.Undef, i_1814))) * dn_1708) * 1.5)))));
}, 2, "", true));
Call(set_940, V.Undef, Get(E_883, "tailS"), ((V)("d")), Call(closedD_29, V.Undef, Invoke(Invoke(mid_1728, "slice", ((V)(1D)), ((V)((ToNum(n_1705) - 1D)))), "concat", Invoke(Invoke(Rx_1729, "slice", ((V)(1D)), ((V)((ToNum(n_1705) - 1D)))), "reverse"))));
Invoke(Invoke(Arr(Get(E_883, "tail"), Get(E_883, "tailH")), "concat", Get(E_883, "tailT")), "forEach", Fn((V _self871, int _argc1815, V e_1821, V _a1818, V _a1819, V _a1820, V[] _rest1816) => {
return Set(Get(e_1821, "style"), "display", ((V)("none")));
}, 1, "", true));
}
if (Truthy(Get(E_883, "tailT"))) {
V r0_1822 = default;
V r1_1823 = default;
double dx_1824 = 0;
double dy_1825 = 0;
V dl_1826 = default;
Invoke(Arr(Arr(((V)(1.55)), ((V)(6D))), Arr(((V)(1.25)), ((V)(10D)))), "forEach", Fn((V _self871, int _argc1827, V _a1829, V i_1833, V _a1831, V _a1832, V[] _rest1828) => {
V k_1836 = default;
V n_1838 = default;
{ V _t1834 = ListOf(_a1829);
{ V _t1835 = GetIdx(_t1834, 0D);
k_1836 = _t1835; }
{ V _t1837 = GetIdx(_t1834, 1D);
n_1838 = _t1837; }
}
Call(set_940, V.Undef, GetK(Get(E_883, "tailT"), i_1833), ((V)("d")), Call(smoothD_26, V.Undef, Invoke(sp3_1660, "slice", ((V)(0D)), n_1838)));
Call(set_940, V.Undef, GetK(Get(E_883, "tailT"), i_1833), ((V)("stroke-width")), Call(r2_14, V.Undef, ((V)((tw_1661 * ToNum(k_1836))))));
return default;
}, 2, "", true));
r0_1822 = GetIdx(sp3_1660, 0D);
r1_1823 = GetIdx(sp3_1660, 2D);
dx_1824 = (ToNum(GetIdx(r1_1823, 0D)) - ToNum(GetIdx(r0_1822, 0D)));
dy_1825 = (ToNum(GetIdx(r1_1823, 1D)) - ToNum(GetIdx(r0_1822, 1D)));
dl_1826 = (((V)(Hypot(dx_1824, dy_1825))) is var _t1839 && Truthy(_t1839) ? _t1839 : ((V)(1D)));
Call(set_940, V.Undef, Get(E_883, "tailB"), ((V)("cx")), Call(r2_14, V.Undef, Add(GetIdx(r0_1822, 0D), ((V)((((dx_1824 / ToNum(dl_1826)) * tw_1661) * 0.3))))));
Call(set_940, V.Undef, Get(E_883, "tailB"), ((V)("cy")), Call(r2_14, V.Undef, Add(GetIdx(r0_1822, 1D), ((V)((((dy_1825 / ToNum(dl_1826)) * tw_1661) * 0.3))))));
Call(set_940, V.Undef, Get(E_883, "tailB"), ((V)("rx")), Call(r2_14, V.Undef, ((V)((tw_1661 * 1.12)))));
Call(set_940, V.Undef, Get(E_883, "tailB"), ((V)("ry")), Call(r2_14, V.Undef, ((V)((tw_1661 * 0.95)))));
Call(set_940, V.Undef, Get(E_883, "tailB"), ((V)("opacity")), Call(r2_14, V.Undef, Call(SM_16, V.Undef, ((V)((((-0.15) - cyb_901) / 0.5))))));
}
if (Truthy(Get(D_881, "tail"))) {
Set(keys_946, "tail", (Truthy(T3_1659) ? Call(bywZ_939, V.Undef, ((V)(64D)), ((V)((-22D)))) : Call(bywZ_939, V.Undef, ((V)(66D)), ((V)((-12D))))));
}
Set(keys_946, "collar", ((V)(1.5)));
if (Truthy(Get(D_881, "mane"))) {
Set(keys_946, "mane", ((V)((-30D))));
Set(keys_946, "maneF", ((V)(1.3)));
if (Truthy(Get(E_883, "coat"))) {
Set(keys_946, "coatB", ((V)(0.6)));
}
}
if (Truthy(Get(D_881, "pup"))) {
Set(keys_946, "pup", ((V)(12D)));
}
Set(Get(I_878, "W"), "tail", GetIdx(sp3_1660, (ToNum(Get(sp3_1660, "length")) - 1D)));
}
MZ_947 = (Get(D_881, "muzzle") is var _t1840 && Truthy(_t1840) ? _t1840 : Arr(((V)(50D)), ((V)(57D)), ((V)(16D)), ((V)(10D))));
Call(set_940, V.Undef, Get(E_883, "muzzle"), ((V)("d")), Call(toD_25, V.Undef, Get(R_882, "muzzle"), face_928));
Call(set_940, V.Undef, Get(E_883, "muzzle"), ((V)("opacity")), Call(r2_14, V.Undef, Call(zc_932, V.Undef, GetIdx(MZ_947, 0D), GetIdx(MZ_947, 1D))));
if (Truthy(Get(E_883, "tufts"))) {
Invoke(Get(D_881, "tufts"), "forEach", Fn((V _self871, int _argc1841, V T_1847, V i_1848, V _a1845, V _a1846, V[] _rest1842) => {
V cx_1849 = default;
V cy_1850 = default;
double dx_1851 = 0;
double dy_1852 = 0;
double q_1853 = 0;
double z0_1854 = 0;
double th0_1855 = 0;
double thN_1856 = 0;
double th_1857 = 0;
double fxs_1858 = 0;
double lf_1859 = 0;
V C0_1860 = default;
double hr2_1861 = 0;
double c2_1862 = 0;
double s2_1863 = 0;
double ct_1864 = 0;
V el_1865 = default;
V eb_1866 = default;
V TM_1867 = default;
V td_1868 = default;
V Hc_1869 = default;
double dC_1870 = 0;
V tr_1871 = default;
V f_1872 = default;
double rho_1873 = 0;
double Rg_1874 = 0;
double ky_1875 = 0;
V o1_1876 = default;
{ V _t1877 = Get(T_1847, "c");
{ V _t1878 = ListOf(_t1877);
{ V _t1879 = GetIdx(_t1878, 0D);
cx_1849 = _t1879; }
{ V _t1880 = GetIdx(_t1878, 1D);
cy_1850 = _t1880; }
} }
dx_1851 = (ToNum(cx_1849) - ToNum(HX_886));
dy_1852 = (ToNum(cy_1850) - ToNum(HY_887));
q_1853 = ((1D - ((dx_1851 / ToNum(SR_889)) * (dx_1851 / ToNum(SR_889)))) - ((dy_1852 / ToNum(SRY_891)) * (dy_1852 / ToNum(SRY_891))));
z0_1854 = (ToNum(SR_889) * System.Math.Sqrt(Max(0.02, q_1853)));
th0_1855 = FdLibm.Atan2(dx_1851, z0_1854);
thN_1856 = (th0_1855 * 0.55);
th_1857 = (th0_1855 + yh_896);
fxs_1858 = ((0.64 + (0.36 * ToNum(Call(clamp_13, V.Undef, ((V)(FdLibm.Cos((thN_1856 + yh_896)))), ((V)(0D)), ((V)(1D)))))) / (0.64 + (0.36 * FdLibm.Cos(thN_1856))));
lf_1859 = (1D + (ToNum((Get(T_1847, "lift") is var _t1881 && Truthy(_t1881) ? _t1881 : ((V)(0D)))) / ToNum(SR_889)));
C0_1860 = ((lf_1859 > 1D) ? Call(sph_926, V.Undef, Add(HX_886, ((V)((dx_1851 * lf_1859)))), Add(HY_887, ((V)((dy_1852 * lf_1859)))), ((V)((z0_1854 * lf_1859)))) : Call(sph_926, V.Undef, cx_1849, cy_1850));
hr2_1861 = ((ToNum(Get(P_879, "htilt")) * D2R_11) * 0.6);
c2_1862 = FdLibm.Cos(hr2_1861);
s2_1863 = FdLibm.Sin(hr2_1861);
ct_1864 = FdLibm.Cos(th_1857);
el_1865 = GetK(Get(E_883, "tufts"), i_1848);
eb_1866 = GetK(Get(E_883, "tuftsB"), i_1848);
TM_1867 = Fn((V _self871, int _argc1882, V x_1888, V y_1889, V _a1886, V _a1887, V[] _rest1883) => {
double lx_1890 = 0;
double ly_1891 = 0;
lx_1890 = ((ToNum(x_1888) - ToNum(cx_1849)) * fxs_1858);
ly_1891 = (ToNum(y_1889) - ToNum(cy_1850));
return Arr(((V)((ToNum(Add(GetIdx(C0_1860, 0D), ((V)((lx_1890 * c2_1862))))) - (ly_1891 * s2_1863)))), Add(Add(GetIdx(C0_1860, 1D), ((V)((lx_1890 * s2_1863)))), ((V)((ly_1891 * c2_1862)))));
return default;
}, 2, "", true);
td_1868 = Call(toD_25, V.Undef, GetK(Get(R_882, "tufts"), i_1848), TM_1867);
Call(set_940, V.Undef, el_1865, ((V)("d")), td_1868);
Call(set_940, V.Undef, eb_1866, ((V)("d")), td_1868);
SetK((Get(I_878, "tuftMap") is var _t1892 && Truthy(_t1892) ? _t1892 : Set(I_878, "tuftMap", Arr())), i_1848, TM_1867);
if (Truthy((Get(E_883, "tuftsW") is var _t1893 && !Truthy(_t1893) ? _t1893 : GetK(Get(E_883, "tuftsW"), i_1848)))) {
V Wt_1894 = default;
Wt_1894 = Get(T_1847, "white");
Call(set_940, V.Undef, GetK(Get(E_883, "tuftsW"), i_1848), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, Add(cx_1849, GetIdx(Wt_1894, 0D)), Add(cy_1850, GetIdx(Wt_1894, 1D)), GetIdx(Wt_1894, 2D), GetIdx(Wt_1894, 2D), ((V)(0D)), ((V)(10D))), TM_1867));
}
Hc_1869 = Call(headT_924, V.Undef, HX_886, HY_887);
dC_1870 = Hypot((ToNum(GetIdx(C0_1860, 0D)) - ToNum(GetIdx(Hc_1869, 0D))), (ToNum(GetIdx(C0_1860, 1D)) - ToNum(GetIdx(Hc_1869, 1D))));
tr_1871 = (Get(T_1847, "r") is var _t1895 && Truthy(_t1895) ? _t1895 : ((V)(9.5)));
f_1872 = Call(SM_16, V.Undef, ((V)(((0.26 - ct_1864) / 0.52))));
rho_1873 = ((dC_1870 - ToNum(tr_1871)) + ((ToNum(f_1872) * 2D) * ToNum(tr_1871)));
Rg_1874 = 60D;
ky_1875 = (ToNum(SRY_891) / ToNum(SR_889));
Call(set_940, V.Undef, Get(el_1865, "_g"), ((V)("cx")), Call(r2_14, V.Undef, GetIdx(Hc_1869, 0D)));
Call(set_940, V.Undef, Get(el_1865, "_g"), ((V)("cy")), Call(r2_14, V.Undef, GetIdx(Hc_1869, 1D)));
Call(set_940, V.Undef, Get(el_1865, "_g"), ((V)("gradientTransform")), ((V)(string.Concat(new string[] { "translate(", ToStr(Call(r2_14, V.Undef, GetIdx(Hc_1869, 0D))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(Hc_1869, 1D))), ") scale(1 ", ToStr(Invoke(((V)(ky_1875)), "toFixed", ((V)(4D)))), ") translate(", ToStr(Call(r2_14, V.Undef, ((V)((-ToNum(GetIdx(Hc_1869, 0D))))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((-ToNum(GetIdx(Hc_1869, 1D))))))), ")" }))));
o1_1876 = (GtN(f_1872, 0.001) ? Call(clamp_13, V.Undef, ((V)((rho_1873 / Rg_1874))), ((V)(0D)), ((V)(1D))) : ((V)(0D)));
Invoke(GetIdx(Get(el_1865, "_s"), 0D), "setAttribute", ((V)("offset")), Invoke(o1_1876, "toFixed", ((V)(4D))));
Invoke(GetIdx(Get(el_1865, "_s"), 1D), "setAttribute", ((V)("offset")), Invoke((GtN(f_1872, 0.001) ? Call(clamp_13, V.Undef, ((V)(((rho_1873 + 1.8) / Rg_1874))), ((V)(0D)), ((V)(1D))) : ((V)(0D))), "toFixed", ((V)(4D))));
Call(set_940, V.Undef, el_1865, ((V)("opacity")), ((V)(1D)));
Call(set_940, V.Undef, eb_1866, ((V)("opacity")), Call(r2_14, V.Undef, Call(SM_16, V.Undef, ((V)(((ct_1864 + 0.95) / 0.25))))));
return default;
}, 2, "", true));
}
Invoke((Get(E_883, "fx") is var _t1910 && Truthy(_t1910) ? _t1910 : Arr()), "forEach", Fn((V _self871, int _argc1896, V el_1902, V i_1903, V _a1900, V _a1901, V[] _rest1897) => {
V fe_1904 = default;
V big_1905 = default;
fe_1904 = GetK(Get(D_881, "faceExtra"), i_1903);
big_1905 = (Get(R_882, "fxBig") is var _t1906 && !Truthy(_t1906) ? _t1906 : GetK(Get(R_882, "fxBig"), i_1903));
Call(set_940, V.Undef, el_1902, ((V)("d")), Call(toD_25, V.Undef, GetK(Get(R_882, "fx"), i_1903), (Truthy(Get(fe_1904, "gloss")) ? headT_924 : (Truthy(Get(fe_1904, "hug")) ? hugF_937 : (Truthy((big_1905 is var _t1907 && !Truthy(_t1907) ? _t1907 : (!(Truthy(Get(fe_1904, "sph"))) ? V.True : V.False))) ? wrapF_930 : face_928)))));
Call(set_940, V.Undef, el_1902, ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ToNum((Get(fe_1904, "op") is var _t1908 && Truthy(_t1908) ? _t1908 : ((V)(1D)))) * ToNum((Truthy(Get(fe_1904, "gloss")) ? ((V)(1D)) : (Truthy(Get(fe_1904, "hug")) ? Call(zc_932, V.Undef, HX_886, GetIdx(GetK(Get(R_882, "fxC"), i_1903), 1D)) : (Truthy((big_1905 is var _t1909 && !Truthy(_t1909) ? _t1909 : (!(Truthy(Get(fe_1904, "sph"))) ? V.True : V.False))) ? ((V)(1D)) : Call(zc_932, V.Undef, GetIdx(GetK(Get(R_882, "fxC"), i_1903), 0D), GetIdx(GetK(Get(R_882, "fxC"), i_1903), 1D)))))))))));
return default;
}, 2, "", true));
Call(set_940, V.Undef, Get(E_883, "stripes"), ((V)("d")), Call(toD_25, V.Undef, Get(R_882, "stripes"), face_928));
Call(set_940, V.Undef, Get(E_883, "stripes"), ((V)("opacity")), Call(r2_14, V.Undef, Call(zc_932, V.Undef, ((V)(50D)), ((V)(21D)))));
Call(set_940, V.Undef, Get(E_883, "back"), ((V)("d")), Call(toD_25, V.Undef, Get(R_882, "back"), Fn((V _self871, int _argc1911, V x_1917, V y_1918, V _a1915, V _a1916, V[] _rest1912) => {
return Call(sph_926, V.Undef, x_1917, y_1918, ((V)("b")));
}, 2, "", true)));
Call(set_940, V.Undef, Get(E_883, "back"), ((V)("opacity")), Call(r2_14, V.Undef, Call(zc_932, V.Undef, (Truthy(Get(D_881, "backAt")) ? GetIdx(Get(D_881, "backAt"), 0D) : ((V)(50D))), (Truthy(Get(D_881, "backAt")) ? GetIdx(Get(D_881, "backAt"), 1D) : ((V)(23D))), ((V)("b")))));
if (Truthy(Get(E_883, "snout"))) {
V S0_1919 = default;
V la_1920 = default;
V lb_1921 = default;
V lc_1922 = default;
double dx_1923 = 0;
double dy_1924 = 0;
double q_1925 = 0;
V z0_1926 = default;
V pv_1927 = default;
V dep_1928 = default;
V C_1929 = default;
V ux_1930 = default;
V A_1931 = default;
V sv_1932 = default;
V svv_1933 = default;
V N0_1934 = default;
V nz_1935 = default;
double ny_1936 = 0;
V NC_1937 = default;
V na_1938 = default;
V nb_1939 = default;
V nc_1940 = default;
V HC_1941 = default;
S0_1919 = Get(D_881, "snout");
{ V _t1942 = Get(S0_1919, "r");
{ V _t1943 = ListOf(_t1942);
{ V _t1944 = GetIdx(_t1943, 0D);
la_1920 = _t1944; }
{ V _t1945 = GetIdx(_t1943, 1D);
lb_1921 = _t1945; }
{ V _t1946 = GetIdx(_t1943, 2D);
lc_1922 = _t1946; }
} }
dx_1923 = (ToNum(GetIdx(Get(S0_1919, "c"), 0D)) - ToNum(HX_886));
dy_1924 = (ToNum(GetIdx(Get(S0_1919, "c"), 1D)) - ToNum(HY_887));
q_1925 = ((1D - Pow((dx_1923 / ToNum(SR_889)), 2D)) - Pow((dy_1924 / ToNum(SRY_891)), 2D));
z0_1926 = Add(((V)(((q_1925 > 0D) ? (ToNum(SR_889) * System.Math.Sqrt(q_1925)) : 0D))), (Get(S0_1919, "out") is var _t1947 && Truthy(_t1947) ? _t1947 : ((V)(0D))));
pv_1927 = Fn((V _self871, int _argc1948, V x_1954, V y_1955, V z_1956, V _a1953, V[] _rest1949) => {
double z1_1957 = 0;
z1_1957 = (((-ToNum(x_1954)) * syh_904) + (ToNum(z_1956) * cyh_903));
return Arr(((V)(((ToNum(x_1954) * cyh_903) + (ToNum(z_1956) * syh_904)))), ((V)(((ToNum(y_1955) * cp_905) - ((z1_1957 * sp_906) * KY_892)))));
return default;
}, 3, "", true);
dep_1928 = Fn((V _self871, int _argc1958, V x_1964, V y_1965, V z_1966, V _a1963, V[] _rest1959) => {
double z1_1967 = 0;
z1_1967 = (((-ToNum(x_1964)) * syh_904) + (ToNum(z_1966) * cyh_903));
return ((V)((((ToNum(y_1965) * sp_906) / KY_892) + (z1_1967 * cp_905))));
return default;
}, 3, "", true);
C_1929 = Call(pv_1927, V.Undef, ((V)(dx_1923)), ((V)(dy_1924)), z0_1926);
ux_1930 = (Get(S0_1919, "tilt") is var _t1968 && Truthy(_t1968) ? _t1968 : ((V)(0D)));
A_1931 = Arr(Call(pv_1927, V.Undef, la_1920, ((V)(0D)), ((V)(0D))), Call(pv_1927, V.Undef, ((V)(0D)), lb_1921, ((V)(0D))), Call(pv_1927, V.Undef, ((V)(0D)), ((V)((ToNum(lb_1921) * ToNum(ux_1930)))), lc_1922));
sv_1932 = Call(SM_16, V.Undef, ((V)((ToNum(Add(Call(dep_1928, V.Undef, ((V)(dx_1923)), ((V)(dy_1924)), z0_1926), ((V)(5D)))) / 4.5))));
svv_1933 = sv_1932;
if (Truthy(Get(S0_1919, "occlude"))) {
V bk_1969 = default;
bk_1969 = (LtN(Call(dep_1928, V.Undef, ((V)(dx_1923)), ((V)(dy_1924)), z0_1926), 0D) ? V.True : V.False);
svv_1933 = ((V)(1D));
if (!SEq(bk_1969, Get(I_878, "snBk"))) {
V els_1970 = default;
V hg_1971 = default;
Set(I_878, "snBk", bk_1969);
els_1970 = Invoke(Arr(Get(E_883, "snoutJ"), Get(E_883, "snout"), Get(E_883, "snoutN"), Get(E_883, "snoutH")), "filter", G("Boolean"));
hg_1971 = Get(Get(E_883, "skull"), "parentNode");
if (Truthy((bk_1969 is var _t1972 && !Truthy(_t1972) ? _t1972 : (SEq(Get(I_878, "snAnchor"), V.Undef) ? V.True : V.False)))) {
Set(I_878, "snAnchor", Get(GetIdx(els_1970, (ToNum(Get(els_1970, "length")) - 1D)), "nextSibling"));
}
Invoke(els_1970, "forEach", Fn((V _self871, int _argc1973, V el_1979, V _a1976, V _a1977, V _a1978, V[] _rest1974) => {
return Invoke(hg_1971, "insertBefore", el_1979, (Truthy(bk_1969) ? Get(E_883, "skull") : (Get(I_878, "snAnchor") is var _t1980 && Truthy(_t1980) ? _t1980 : V.Null)));
}, 1, "", true));
}
}
Call(set_940, V.Undef, Get(E_883, "snout"), ((V)("d")), Call(toD_25, V.Undef, Call(ellAx_30, V.Undef, Add(HX_886, GetIdx(C_1929, 0D)), Add(HY_887, GetIdx(C_1929, 1D)), A_1931), headT_924));
Call(set_940, V.Undef, Get(E_883, "snout"), ((V)("opacity")), Call(r2_14, V.Undef, svv_1933));
if (Truthy(Get(E_883, "snoutJ"))) {
V J_1981 = default;
V ja_1982 = default;
V jb_1983 = default;
V jc_1984 = default;
V op_1985 = default;
V JC_1986 = default;
V jt_1987 = default;
J_1981 = Get(S0_1919, "jaw");
{ V _t1988 = Get(J_1981, "r");
{ V _t1989 = ListOf(_t1988);
{ V _t1990 = GetIdx(_t1989, 0D);
ja_1982 = _t1990; }
{ V _t1991 = GetIdx(_t1989, 1D);
jb_1983 = _t1991; }
{ V _t1992 = GetIdx(_t1989, 2D);
jc_1984 = _t1992; }
} }
op_1985 = Call(clamp_13, V.Undef, Get(P_879, "open"), ((V)(0D)), ((V)(1D)));
JC_1986 = Call(pv_1927, V.Undef, ((V)(dx_1923)), ((V)(((dy_1924 + (ToNum(lb_1921) * 0.62)) + (ToNum(op_1985) * ToNum((Get(J_1981, "drop") is var _t1993 && Truthy(_t1993) ? _t1993 : ((V)(2.2)))))))), ((V)(((ToNum(z0_1926) - (ToNum(lc_1922) * 0.08)) - (ToNum(op_1985) * 0.6)))));
jt_1987 = Add((Get(J_1981, "tilt") is var _t1994 && Truthy(_t1994) ? _t1994 : ((V)(0D))), ((V)((ToNum(op_1985) * ToNum((Get(J_1981, "tiltOpen") is var _t1995 && Truthy(_t1995) ? _t1995 : ((V)(0.5))))))));
Call(set_940, V.Undef, Get(E_883, "snoutJ"), ((V)("d")), Call(toD_25, V.Undef, Call(ellAx_30, V.Undef, Add(HX_886, GetIdx(JC_1986, 0D)), Add(HY_887, GetIdx(JC_1986, 1D)), Arr(Call(pv_1927, V.Undef, ja_1982, ((V)(0D)), ((V)(0D))), Call(pv_1927, V.Undef, ((V)(0D)), jb_1983, ((V)(0D))), Call(pv_1927, V.Undef, ((V)(0D)), ((V)((ToNum(jc_1984) * ToNum(jt_1987)))), jc_1984))), headT_924));
Call(set_940, V.Undef, Get(E_883, "snoutJ"), ((V)("opacity")), Call(r2_14, V.Undef, svv_1933));
}
N0_1934 = (Get(S0_1919, "nose") is var _t1996 && Truthy(_t1996) ? _t1996 : NewObj(1).Put("r", Arr(((V)(2.5)), ((V)(2D)), ((V)(1.6)))).V);
nz_1935 = Add(z0_1926, ((V)((ToNum(lc_1922) * 0.9))));
ny_1936 = ((dy_1924 + ((ToNum(lb_1921) * ToNum(ux_1930)) * 0.9)) - (ToNum(lb_1921) * 0.12));
NC_1937 = Call(pv_1927, V.Undef, ((V)(dx_1923)), ((V)(ny_1936)), nz_1935);
{ V _t1997 = Get(N0_1934, "r");
{ V _t1998 = ListOf(_t1997);
{ V _t1999 = GetIdx(_t1998, 0D);
na_1938 = _t1999; }
{ V _t2000 = GetIdx(_t1998, 1D);
nb_1939 = _t2000; }
{ V _t2001 = GetIdx(_t1998, 2D);
nc_1940 = _t2001; }
} }
Call(set_940, V.Undef, Get(E_883, "snoutN"), ((V)("d")), Call(toD_25, V.Undef, Call(ellAx_30, V.Undef, Add(HX_886, GetIdx(NC_1937, 0D)), Add(HY_887, GetIdx(NC_1937, 1D)), Arr(Call(pv_1927, V.Undef, na_1938, ((V)(0D)), ((V)(0D))), Call(pv_1927, V.Undef, ((V)(0D)), nb_1939, ((V)(0D))), Call(pv_1927, V.Undef, ((V)(0D)), ((V)(0D)), nc_1940))), headT_924));
Call(set_940, V.Undef, Get(E_883, "snoutN"), ((V)("opacity")), Call(r2_14, V.Undef, svv_1933));
HC_1941 = Call(pv_1927, V.Undef, ((V)((dx_1923 - (ToNum(na_1938) * 0.35)))), ((V)((ny_1936 - (ToNum(nb_1939) * 0.4)))), Add(nz_1935, ((V)((ToNum(nc_1940) * 0.6)))));
Call(set_940, V.Undef, Get(E_883, "snoutH"), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, Add(HX_886, GetIdx(HC_1941, 0D)), Add(HY_887, GetIdx(HC_1941, 1D)), ((V)((ToNum(na_1938) * 0.32))), ((V)((ToNum(nb_1939) * 0.26))), ((V)(0D)), ((V)(6D))), headT_924));
Call(set_940, V.Undef, Get(E_883, "snoutH"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((Truthy(Get(S0_1919, "occlude")) ? (Truthy(Get(I_878, "snBk")) ? 0D : (0.75 * ToNum(Call(SM_16, V.Undef, ((V)((ToNum(Add(Call(dep_1928, V.Undef, ((V)(dx_1923)), ((V)(dy_1924)), z0_1926), ((V)(2D)))) / 4D))))))) : (ToNum(sv_1932) * 0.75))))));
Set(Get(I_878, "W"), "nose", Call(headT_924, V.Undef, Add(HX_886, GetIdx(NC_1937, 0D)), Add(HY_887, GetIdx(NC_1937, 1D))));
}
NS0_948 = (Get(D_881, "nose") is var _t2002 && Truthy(_t2002) ? _t2002 : Arr(((V)(50D)), ((V)(54D)), ((V)(2.6)), ((V)(1.8))));
Call(set_940, V.Undef, Get(E_883, "nose"), ((V)("d")), Call(toD_25, V.Undef, Get(R_882, "nose"), face_928));
Call(set_940, V.Undef, Get(E_883, "nose"), ((V)("opacity")), Call(r2_14, V.Undef, Call(zc_932, V.Undef, GetIdx(NS0_948, 0D), GetIdx(NS0_948, 1D))));
if (Truthy(Get(E_883, "noseHL"))) {
Call(set_940, V.Undef, Get(E_883, "noseHL"), ((V)("d")), Call(toD_25, V.Undef, Get(R_882, "noseHL"), face_928));
Call(set_940, V.Undef, Get(E_883, "noseHL"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((0.7 * ToNum(Call(zc_932, V.Undef, GetIdx(NS0_948, 0D), GetIdx(NS0_948, 1D))))))));
}
sm_949 = Call(clamp_13, V.Undef, Get(P_879, "smile"), ((V)(0D)), ((V)(1D)));
decal_950 = Fn((V _self871, int _argc2003, V F_2009, V cx_2010, V cy_2011, V _a2008, V[] _rest2004) => {
double e_2012 = 0;
double k_2013 = 0;
V C_2014 = default;
V a_2015 = default;
V b_2016 = default;
V c_2017 = default;
V d_2018 = default;
V h1_2019 = default;
V h2_2020 = default;
V h3_2021 = default;
V h4_2022 = default;
V mul_2023 = default;
V J_2024 = default;
V Hm_2025 = default;
V dt_2026 = default;
V m_2027 = default;
double e1_2028 = 0;
double f1_2029 = 0;
double g1_2030 = 0;
double k1_2031 = 0;
double q1_2032 = 0;
double q2_2033 = 0;
double a1_2034 = 0;
double a2_2035 = 0;
double th_2036 = 0;
double ph2_2037 = 0;
double s1_2038 = 0;
double s2_2039 = 0;
double cf_2040 = 0;
double sf_2041 = 0;
double ct_2042 = 0;
double st_2043 = 0;
V M_2044 = default;
e_2012 = 0.5;
k_2013 = (1D / (2D * e_2012));
C_2014 = Call(F_2009, V.Undef, cx_2010, cy_2011);
a_2015 = Call(F_2009, V.Undef, Add(cx_2010, ((V)(e_2012))), cy_2011);
b_2016 = Call(F_2009, V.Undef, ((V)((ToNum(cx_2010) - e_2012))), cy_2011);
c_2017 = Call(F_2009, V.Undef, cx_2010, Add(cy_2011, ((V)(e_2012))));
d_2018 = Call(F_2009, V.Undef, cx_2010, ((V)((ToNum(cy_2011) - e_2012))));
h1_2019 = Call(headT_924, V.Undef, Add(cx_2010, ((V)(e_2012))), cy_2011);
h2_2020 = Call(headT_924, V.Undef, ((V)((ToNum(cx_2010) - e_2012))), cy_2011);
h3_2021 = Call(headT_924, V.Undef, cx_2010, Add(cy_2011, ((V)(e_2012))));
h4_2022 = Call(headT_924, V.Undef, cx_2010, ((V)((ToNum(cy_2011) - e_2012))));
mul_2023 = Fn((V _self871, int _argc2045, V A_2051, V B_2052, V _a2049, V _a2050, V[] _rest2046) => {
return Arr(((V)(((ToNum(GetIdx(A_2051, 0D)) * ToNum(GetIdx(B_2052, 0D))) + (ToNum(GetIdx(A_2051, 1D)) * ToNum(GetIdx(B_2052, 2D)))))), ((V)(((ToNum(GetIdx(A_2051, 0D)) * ToNum(GetIdx(B_2052, 1D))) + (ToNum(GetIdx(A_2051, 1D)) * ToNum(GetIdx(B_2052, 3D)))))), ((V)(((ToNum(GetIdx(A_2051, 2D)) * ToNum(GetIdx(B_2052, 0D))) + (ToNum(GetIdx(A_2051, 3D)) * ToNum(GetIdx(B_2052, 2D)))))), ((V)(((ToNum(GetIdx(A_2051, 2D)) * ToNum(GetIdx(B_2052, 1D))) + (ToNum(GetIdx(A_2051, 3D)) * ToNum(GetIdx(B_2052, 3D)))))));
}, 2, "", true);
J_2024 = Arr(((V)(((ToNum(GetIdx(a_2015, 0D)) - ToNum(GetIdx(b_2016, 0D))) * k_2013))), ((V)(((ToNum(GetIdx(c_2017, 0D)) - ToNum(GetIdx(d_2018, 0D))) * k_2013))), ((V)(((ToNum(GetIdx(a_2015, 1D)) - ToNum(GetIdx(b_2016, 1D))) * k_2013))), ((V)(((ToNum(GetIdx(c_2017, 1D)) - ToNum(GetIdx(d_2018, 1D))) * k_2013))));
Hm_2025 = Arr(((V)(((ToNum(GetIdx(h1_2019, 0D)) - ToNum(GetIdx(h2_2020, 0D))) * k_2013))), ((V)(((ToNum(GetIdx(h3_2021, 0D)) - ToNum(GetIdx(h4_2022, 0D))) * k_2013))), ((V)(((ToNum(GetIdx(h1_2019, 1D)) - ToNum(GetIdx(h2_2020, 1D))) * k_2013))), ((V)(((ToNum(GetIdx(h3_2021, 1D)) - ToNum(GetIdx(h4_2022, 1D))) * k_2013))));
dt_2026 = (((V)(((ToNum(GetIdx(Hm_2025, 0D)) * ToNum(GetIdx(Hm_2025, 3D))) - (ToNum(GetIdx(Hm_2025, 1D)) * ToNum(GetIdx(Hm_2025, 2D)))))) is var _t2053 && Truthy(_t2053) ? _t2053 : ((V)(1D)));
m_2027 = Call(mul_2023, V.Undef, Arr(((V)((ToNum(GetIdx(Hm_2025, 3D)) / ToNum(dt_2026)))), ((V)(((-ToNum(GetIdx(Hm_2025, 1D))) / ToNum(dt_2026)))), ((V)(((-ToNum(GetIdx(Hm_2025, 2D))) / ToNum(dt_2026)))), ((V)((ToNum(GetIdx(Hm_2025, 0D)) / ToNum(dt_2026))))), J_2024);
e1_2028 = (ToNum(Add(GetIdx(m_2027, 0D), GetIdx(m_2027, 3D))) / 2D);
f1_2029 = ((ToNum(GetIdx(m_2027, 0D)) - ToNum(GetIdx(m_2027, 3D))) / 2D);
g1_2030 = (ToNum(Add(GetIdx(m_2027, 2D), GetIdx(m_2027, 1D))) / 2D);
k1_2031 = ((ToNum(GetIdx(m_2027, 2D)) - ToNum(GetIdx(m_2027, 1D))) / 2D);
q1_2032 = Hypot(e1_2028, k1_2031);
q2_2033 = Hypot(f1_2029, g1_2030);
a1_2034 = FdLibm.Atan2(g1_2030, f1_2029);
a2_2035 = FdLibm.Atan2(k1_2031, e1_2028);
th_2036 = ((a2_2035 - a1_2034) / 2D);
ph2_2037 = ((a2_2035 + a1_2034) / 2D);
s1_2038 = Min((q1_2032 + q2_2033), 1D);
s2_2039 = (Sign((q1_2032 - q2_2033)) * Min(System.Math.Abs((q1_2032 - q2_2033)), 1D));
cf_2040 = FdLibm.Cos(ph2_2037);
sf_2041 = FdLibm.Sin(ph2_2037);
ct_2042 = FdLibm.Cos(th_2036);
st_2043 = FdLibm.Sin(th_2036);
M_2044 = Call(mul_2023, V.Undef, Hm_2025, Call(mul_2023, V.Undef, Arr(((V)((cf_2040 * s1_2038))), ((V)(((-sf_2041) * s2_2039))), ((V)((sf_2041 * s1_2038))), ((V)((cf_2040 * s2_2039)))), Arr(((V)(ct_2042)), ((V)((-st_2043))), ((V)(st_2043)), ((V)(ct_2042)))));
return Fn((V _self871, int _argc2054, V x_2060, V y_2061, V _a2058, V _a2059, V[] _rest2055) => {
double u_2062 = 0;
double v_2063 = 0;
u_2062 = (ToNum(x_2060) - ToNum(cx_2010));
v_2063 = (ToNum(y_2061) - ToNum(cy_2011));
return Arr(Add(Add(GetIdx(C_2014, 0D), ((V)((ToNum(GetIdx(M_2044, 0D)) * u_2062)))), ((V)((ToNum(GetIdx(M_2044, 1D)) * v_2063)))), Add(Add(GetIdx(C_2014, 1D), ((V)((ToNum(GetIdx(M_2044, 2D)) * u_2062)))), ((V)((ToNum(GetIdx(M_2044, 3D)) * v_2063)))));
return default;
}, 2, "", true);
return default;
}, 3, "", true);
CK_951 = (Get(D_881, "cheekR") is var _t2064 && Truthy(_t2064) ? _t2064 : Arr(((V)(4D)), ((V)(2.6))));
Invoke((Get(D_881, "cheeks") is var _t2079 && Truthy(_t2079) ? _t2079 : Arr(Arr(((V)(33D)), ((V)(56D))), Arr(((V)(67D)), ((V)(56D))))), "forEach", Fn((V _self871, int _argc2065, V _a2067, V i_2071, V _a2069, V _a2070, V[] _rest2066) => {
double cy_2077 = 0;
double pk_2078 = 0;
V cx_2074 = default;
V cy0_2076 = default;
{ V _t2072 = ListOf(_a2067);
{ V _t2073 = GetIdx(_t2072, 0D);
cx_2074 = _t2073; }
{ V _t2075 = GetIdx(_t2072, 1D);
cy0_2076 = _t2075; }
}
cy_2077 = (ToNum(cy0_2076) - (ToNum(sm_949) * 0.6));
pk_2078 = (1D + (Max(0D, ToNum(pf_941)) * 0.35));
Call(set_940, V.Undef, GetK(Get(E_883, "cheeks"), i_2071), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, Add(cx_2074, ((V)((((Truthy(i_2071) ? 1D : (-1D)) * Max(0D, ToNum(pf_941))) * 1.2)))), ((V)(cy_2077)), ((V)(((ToNum(GetIdx(CK_951, 0D)) * (1D + (ToNum(sm_949) * 0.08))) * pk_2078))), ((V)((ToNum(GetIdx(CK_951, 1D)) * pk_2078))), ((V)(0D)), ((V)(8D))), (Truthy(Get(D_881, "hugCheeks")) ? Call(decal_950, V.Undef, hugF_937, cx_2074, ((V)(cy_2077))) : face_928)));
Call(set_940, V.Undef, GetK(Get(E_883, "cheeks"), i_2071), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ToNum(Call(clamp_13, V.Undef, ((V)((((0.5 + (ToNum(Call(clamp_13, V.Undef, Get(P_879, "blush"), ((V)(0D)), ((V)(1D)))) * 0.45)) + (Max(0D, ToNum(pf_941)) * 0.25)) + (ToNum(rd_944) * 0.3)))), ((V)(0D)), ((V)(1D)))) * ToNum(Call(zc_932, V.Undef, (Truthy(Get(D_881, "hugCheeks")) ? HX_886 : cx_2074), ((V)(cy_2077)))))))));
return default;
}, 2, "", true));
ox_952 = (ToNum(Get(P_879, "lx")) * 2.6);
oy_953 = (ToNum(Get(P_879, "ly")) * 2.2);
ws_954 = (1D + (ToNum(Call(clamp_13, V.Undef, Get(P_879, "wide"), ((V)(0D)), ((V)(1D)))) * 0.22));
h_955 = Call(clamp_13, V.Undef, Get(P_879, "hap"), ((V)(0D)), ((V)(1D)));
qz_956 = Call(clamp_13, V.Undef, Get(P_879, "sqz"), ((V)(0D)), ((V)(1D)));
cr_957 = (ToNum(Call(clamp_13, V.Undef, Get(P_879, "cross"), ((V)(0D)), ((V)(1D)))) * 1.8);
ty_958 = Call(clamp_13, V.Undef, Get(P_879, "teary"), ((V)(0D)), ((V)(1D)));
Set(I_878, "eyeW", Arr());
Invoke(Get(D_881, "eyes"), "forEach", Fn((V _self871, int _argc2080, V _a2082, V i_2086, V _a2084, V _a2085, V[] _rest2081) => {
double c_2092 = 0;
double dir_2093 = 0;
V cx_2094 = default;
double cy_2095 = 0;
double r_2096 = 0;
V o_2097 = default;
V face_2098 = default;
double sl_2099 = 0;
double @out_2100 = 0;
V eD_2101 = default;
double ha_2102 = 0;
double hk_2103 = 0;
double hd_2104 = 0;
V ex_2089 = default;
V ey_2091 = default;
{ V _t2087 = ListOf(_a2082);
{ V _t2088 = GetIdx(_t2087, 0D);
ex_2089 = _t2088; }
{ V _t2090 = GetIdx(_t2087, 1D);
ey_2091 = _t2090; }
}
c_2092 = (ToNum(Call(clamp_13, V.Undef, ((V)(Max(ToNum(Get(P_879, "close")), ToNum((Truthy(i_2086) ? Get(P_879, "winkR") : Get(P_879, "winkL")))))), ((V)(0D)), ((V)(1D)))) * (1D - ToNum(Call(SM_16, V.Undef, ((V)((ToNum(h_955) * 1.6)))))));
dir_2093 = (Truthy(i_2086) ? (-1D) : 1D);
cx_2094 = Add(Add(ex_2089, ((V)(ox_952))), ((V)((dir_2093 * cr_957))));
cy_2095 = (ToNum(Add(ey_2091, ((V)(oy_953)))) - (ToNum(h_955) * 0.8));
r_2096 = (ToNum(Get(D_881, "eyeR")) * ws_954);
o_2097 = GetK(Get(E_883, "eyes"), i_2086);
face_2098 = (Truthy(((Get(D_881, "eyeDome") is var _t2105 && !Truthy(_t2105) ? _t2105 : Get(I_878, "tuftMap")) is var _t2106 && !Truthy(_t2106) ? _t2106 : GetK(Get(I_878, "tuftMap"), i_2086))) ? GetK(Get(I_878, "tuftMap"), i_2086) : face0_929);
sl_2099 = (ToNum(Call(clamp_13, V.Undef, Get(P_879, "sl"), ((V)(0D)), ((V)(1D)))) * 0.32);
@out_2100 = (Truthy(i_2086) ? 1D : (-1D));
eD_2101 = Call(toD_25, V.Undef, Call(ellS_22, V.Undef, cx_2094, ((V)(cy_2095)), ((V)(r_2096)), ((V)(r_2096)), ((V)(0D)), ((V)(8D))), Fn((V _self871, int _argc2107, V x_2113, V y_2114, V _a2111, V _a2112, V[] _rest2108) => {
double dy_2115 = 0;
V ce_2116 = default;
V X_2117 = default;
V Y_2118 = default;
dy_2115 = (ToNum(y_2114) - cy_2095);
ce_2116 = Call(clamp_13, V.Undef, ((V)((c_2092 + (sl_2099 * (0.5 + (((0.5 * @out_2100) * (ToNum(x_2113) - ToNum(cx_2094))) / r_2096)))))), ((V)(0D)), ((V)(1D)));
X_2117 = x_2113;
Y_2118 = ((V)((cy_2095 + (dy_2115 * ((dy_2115 < 0D) ? (1D - (2D * ToNum(ce_2116))) : (1D - (2D * ToNum(h_955))))))));
if (GtN(qz_956, 0D)) {
V cu_2119 = default;
double u_2120 = 0;
cu_2119 = Call(clamp_13, V.Undef, ((V)(((ToNum(x_2113) - ToNum(cx_2094)) / r_2096))), ((V)((-1D))), ((V)(1D)));
u_2120 = ((dir_2093 > 0D) ? (ToNum(Add(cu_2119, ((V)(1D)))) / 2D) : ((1D - ToNum(cu_2119)) / 2D));
X_2117 = Call(lerp_15, V.Undef, X_2117, Add(cx_2094, ((V)(((dir_2093 * ((-0.8) + (u_2120 * 1.4))) * r_2096)))), qz_956);
Y_2118 = Call(lerp_15, V.Undef, Y_2118, ((V)((cy_2095 + (((Sign(dy_2115) * (1D - u_2120)) * 0.6) * r_2096)))), qz_956);
}
return Call(face_2098, V.Undef, X_2117, Y_2118);
return default;
}, 2, "", true));
Call(set_940, V.Undef, Get(o_2097, "e"), ((V)("d")), eD_2101);
Call(set_940, V.Undef, Get(o_2097, "clip"), ((V)("d")), eD_2101);
Call(set_940, V.Undef, Get(o_2097, "e"), ((V)("stroke-width")), Call(r2_14, V.Undef, ((V)((1.3 * Max(ToNum(Call(SM_16, V.Undef, ((V)(((c_2092 - 0.5) / 0.45))))), ToNum(Call(SM_16, V.Undef, ((V)(((ToNum(h_955) - 0.5) / 0.45))))), ToNum(Call(SM_16, V.Undef, ((V)((ToNum(qz_956) * 1.6)))))))))));
ha_2102 = (((1D - ToNum(Call(SM_16, V.Undef, ((V)(((c_2092 - 0.4) / 0.25)))))) * (1D - ToNum(Call(SM_16, V.Undef, ((V)(((ToNum(h_955) - 0.12) / 0.3))))))) * (1D - ToNum(Call(SM_16, V.Undef, ((V)((ToNum(qz_956) * 2.5)))))));
hk_2103 = (ws_954 * (1D + (ToNum(ty_958) * 0.4)));
hd_2104 = ((c_2092 * r_2096) * 0.7);
Call(set_940, V.Undef, Get(o_2097, "h1"), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, ((V)((ToNum(cx_2094) - (1.7 * ws_954)))), ((V)(((cy_2095 - (1.9 * ws_954)) + hd_2104))), ((V)((1.8 * hk_2103))), ((V)((1.8 * hk_2103))), ((V)(0D)), ((V)(6D))), face_2098));
Call(set_940, V.Undef, Get(o_2097, "h2"), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, Add(cx_2094, ((V)((1.8 * ws_954)))), ((V)((cy_2095 + (1.6 * ws_954)))), ((V)((0.7 * hk_2103))), ((V)((0.7 * hk_2103))), ((V)(0D)), ((V)(6D))), face_2098));
Call(set_940, V.Undef, Get(o_2097, "tp"), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, cx_2094, ((V)((cy_2095 + (r_2096 * 0.8)))), ((V)(r_2096)), ((V)((r_2096 * 0.42))), ((V)(0D)), ((V)(8D))), face_2098));
Call(set_940, V.Undef, Get(o_2097, "tp"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((((ToNum(ty_958) * 0.85) * (1D - ToNum(qz_956))) * (1D - ToNum(Call(SM_16, V.Undef, ((V)((c_2092 * 1.5)))))))))));
Call(set_940, V.Undef, Get(o_2097, "h1"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)(ha_2102))));
Call(set_940, V.Undef, Get(o_2097, "h2"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ha_2102 * 0.9)))));
Call(set_940, V.Undef, Get(o_2097, "g"), ((V)("opacity")), Call(r2_14, V.Undef, Call(zc_932, V.Undef, cx_2094, ((V)(cy_2095)))));
Invoke(Get(I_878, "eyeW"), "push", Call(face_2098, V.Undef, cx_2094, ((V)(cy_2095))));
SetK(Get(I_878, "W"), ((V)((Truthy(i_2086) ? "eyeR" : "eyeL"))), Call(face_2098, V.Undef, cx_2094, ((V)(cy_2095))));
return default;
}, 2, "", true));
{
V MX0_2121 = default;
V MY0_2122 = default;
V MH0_2123 = default;
V mk0_2124 = default;
V op_2125 = default;
V fr_2126 = default;
double mw_2127 = 0;
double hw_2128 = 0;
V y0_2129 = default;
double d_2130 = 0;
double ym_2131 = 0;
V lip_2132 = default;
V mv_2133 = default;
V tg_2134 = default;
{ V _t2135 = (Get(D_881, "mouth") is var _t2136 && Truthy(_t2136) ? _t2136 : Arr(((V)(50D)), ((V)(58D)), ((V)(3.5))));
{ V _t2137 = ListOf(_t2135);
{ V _t2138 = GetIdx(_t2137, 0D);
MX0_2121 = _t2138; }
{ V _t2139 = GetIdx(_t2137, 1D);
MY0_2122 = _t2139; }
{ V _t2140 = GetIdx(_t2137, 2D);
MH0_2123 = _t2140; }
} }
mk0_2124 = (!Get(D_881, "mouthD").IsNullish ? Get(D_881, "mouthD") : ((V)((ToNum(MH0_2123) / 3.5))));
op_2125 = Call(clamp_13, V.Undef, Get(P_879, "open"), ((V)(0D)), ((V)(1D)));
fr_2126 = Call(clamp_13, V.Undef, Get(P_879, "frown"), ((V)(0D)), ((V)(1D)));
mw_2127 = (ToNum(Get(P_879, "mw")) * (1D + (ToNum(sm_949) * 0.12)));
hw_2128 = ((ToNum(MH0_2123) * mw_2127) * (1D + (ToNum(op_2125) * 0.3)));
y0_2129 = Add(MY0_2122, ((V)(((((-ToNum(sm_949)) * 0.5) + (ToNum(fr_2126) * 1.3)) * ToNum(mk0_2124)))));
d_2130 = ((((2.3 * (1D + (ToNum(sm_949) * 0.45))) - (ToNum(fr_2126) * 4D)) * (1D - (ToNum(op_2125) * 0.55))) * ToNum(mk0_2124));
ym_2131 = (ToNum(MY0_2122) - ((ToNum(fr_2126) * 0.2) * ToNum(mk0_2124)));
lip_2132 = ((V)((Truthy(Get(D_881, "mouthOne")) ? string.Concat(new string[] { "M", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(MX0_2121) - hw_2128))))), " ", ToStr(Call(r2_14, V.Undef, y0_2129)), " Q", ToStr(Call(r2_14, V.Undef, MX0_2121)), " ", ToStr(Call(r2_14, V.Undef, Add(y0_2129, ((V)((d_2130 * 2.2)))))), " ", ToStr(Call(r2_14, V.Undef, Add(MX0_2121, ((V)(hw_2128))))), " ", ToStr(Call(r2_14, V.Undef, y0_2129)) }) : string.Concat(new string[] { "M", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(MX0_2121) - hw_2128))))), " ", ToStr(Call(r2_14, V.Undef, y0_2129)), " Q", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(MX0_2121) - (hw_2128 / 2D)))))), " ", ToStr(Call(r2_14, V.Undef, Add(y0_2129, ((V)(d_2130))))), " ", ToStr(Call(r2_14, V.Undef, MX0_2121)), " ", ToStr(Call(r2_14, V.Undef, ((V)(ym_2131)))), " Q", ToStr(Call(r2_14, V.Undef, Add(MX0_2121, ((V)((hw_2128 / 2D)))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((ym_2131 + d_2130))))), " ", ToStr(Call(r2_14, V.Undef, Add(MX0_2121, ((V)(hw_2128))))), " ", ToStr(Call(r2_14, V.Undef, y0_2129)) }))));
mv_2133 = Call(zc_932, V.Undef, MX0_2121, MY0_2122);
Call(set_940, V.Undef, Get(E_883, "mouth"), ((V)("d")), Call(toD_25, V.Undef, Call(parsePath_21, V.Undef, lip_2132), face_928));
Call(set_940, V.Undef, Get(E_883, "mouth"), ((V)("opacity")), Call(r2_14, V.Undef, mv_2133));
if (GtN(op_2125, 0.03)) {
Call(set_940, V.Undef, Get(E_883, "mopen"), ((V)("d")), Call(toD_25, V.Undef, Call(parsePath_21, V.Undef, ((V)(string.Concat(new string[] { ToStr(lip_2132), " C", ToStr(Call(r2_14, V.Undef, Add(MX0_2121, ((V)(hw_2128))))), " ", ToStr(Call(r2_14, V.Undef, Add(y0_2129, ((V)(((ToNum(op_2125) * 8D) * ToNum(mk0_2124))))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(MX0_2121) - hw_2128))))), " ", ToStr(Call(r2_14, V.Undef, Add(y0_2129, ((V)(((ToNum(op_2125) * 8D) * ToNum(mk0_2124))))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(MX0_2121) - hw_2128))))), " ", ToStr(Call(r2_14, V.Undef, y0_2129)), "Z" })))), face_928));
Call(set_940, V.Undef, Get(E_883, "tongue"), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, MX0_2121, Add(y0_2129, ((V)(((ToNum(op_2125) * 4.2) * ToNum(mk0_2124))))), ((V)((((2.3 * ToNum(op_2125)) * mw_2127) * ToNum(mk0_2124)))), ((V)(((1.4 * ToNum(op_2125)) * ToNum(mk0_2124)))), ((V)(0D)), ((V)(8D))), face_928));
Call(set_940, V.Undef, Get(E_883, "mopen"), ((V)("opacity")), Call(r2_14, V.Undef, mv_2133));
Call(set_940, V.Undef, Get(E_883, "tongue"), ((V)("opacity")), Call(r2_14, V.Undef, mv_2133));
} else {
Call(set_940, V.Undef, Get(E_883, "mopen"), ((V)("opacity")), ((V)(0D)));
Call(set_940, V.Undef, Get(E_883, "tongue"), ((V)("opacity")), ((V)(0D)));
}
tg_2134 = Call(clamp_13, V.Undef, Get(P_879, "tongue"), ((V)(0D)), ((V)(1D)));
Call(set_940, V.Undef, Get(E_883, "tout"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ToNum(mv_2133) * ToNum(Call(SM_16, V.Undef, ((V)((ToNum(tg_2134) * 3D))))))))));
if (GtN(tg_2134, 0.02)) {
Call(set_940, V.Undef, Get(E_883, "tout"), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, MX0_2121, Add(y0_2129, ((V)(((1.3 + (ToNum(tg_2134) * 1.9)) * ToNum(mk0_2124))))), ((V)(((2.2 * (1D + (ToNum(tg_2134) * 0.15))) * ToNum(mk0_2124)))), ((V)(((1D + (ToNum(tg_2134) * 1.7)) * ToNum(mk0_2124)))), ((V)(0D)), ((V)(8D))), face_928));
}
}
{
V M0_2141 = default;
V N0_2142 = default;
M0_2141 = (Get(D_881, "mouth") is var _t2143 && Truthy(_t2143) ? _t2143 : Arr(((V)(50D)), ((V)(58D))));
N0_2142 = (Get(D_881, "nose") is var _t2144 && Truthy(_t2144) ? _t2144 : Arr(((V)(50D)), ((V)(54D))));
Set(Get(I_878, "W"), "mouth", Call(face_928, V.Undef, GetIdx(M0_2141, 0D), GetIdx(M0_2141, 1D)));
if (!(Truthy(Get(D_881, "snout")))) {
Set(Get(I_878, "W"), "nose", Call(face_928, V.Undef, GetIdx(N0_2142, 0D), GetIdx(N0_2142, 1D)));
}
}
Set(Get(I_878, "W"), "body", Call(glob_918, V.Undef, ((V)(50D)), ((V)(78D))));
Set(Get(I_878, "W"), "belly", Call(glob_918, V.Undef, ((V)(50D)), ((V)(83D))));
Set(Get(I_878, "W"), "sideL", Call(glob_918, V.Undef, ((V)(30D)), ((V)(78D))));
Set(Get(I_878, "W"), "sideR", Call(glob_918, V.Undef, ((V)(70D)), ((V)(78D))));
wk_959 = Call(clamp_13, V.Undef, (Get(P_879, "wsk") is var _t2145 && Truthy(_t2145) ? _t2145 : ((V)(0D))), ((V)(0D)), ((V)(1D)));
wFold_960 = Fn((V _self871, int _argc2146, V w_2152, V sg_2153, V _a2150, V _a2151, V[] _rest2147) => {
V r0_2154 = default;
double a_2155 = 0;
double ca_2156 = 0;
double sa_2157 = 0;
double k_2158 = 0;
r0_2154 = GetIdx(Get(GetIdx(w_2152, 0D), "p"), 0D);
a_2155 = ((0.34 * ToNum(wk_959)) * ToNum(sg_2153));
ca_2156 = FdLibm.Cos(a_2155);
sa_2157 = FdLibm.Sin(a_2155);
k_2158 = (1D - (0.5 * ToNum(wk_959)));
return Invoke(w_2152, "map", Fn((V _self871, int _argc2159, V g_2165, V _a2162, V _a2163, V _a2164, V[] _rest2160) => {
return (SEqS(Get(g_2165, "c"), "Z") ? g_2165 : NewObj(2).Put("c", Get(g_2165, "c")).Put("p", Invoke(Get(g_2165, "p"), "map", Fn((V _self871, int _argc2166, V _a2168, V _a2169, V _a2170, V _a2171, V[] _rest2167) => {
double dx_2177 = 0;
double dy_2178 = 0;
V x_2174 = default;
V y_2176 = default;
{ V _t2172 = ListOf(_a2168);
{ V _t2173 = GetIdx(_t2172, 0D);
x_2174 = _t2173; }
{ V _t2175 = GetIdx(_t2172, 1D);
y_2176 = _t2175; }
}
dx_2177 = ((ToNum(x_2174) - ToNum(GetIdx(r0_2154, 0D))) * k_2158);
dy_2178 = ((ToNum(y_2176) - ToNum(GetIdx(r0_2154, 1D))) * k_2158);
return Arr(((V)((ToNum(Add(GetIdx(r0_2154, 0D), ((V)((dx_2177 * ca_2156))))) - (dy_2178 * sa_2157)))), Add(Add(GetIdx(r0_2154, 1D), ((V)((dx_2177 * sa_2157)))), ((V)((dy_2178 * ca_2156)))));
return default;
}, 1, "", true))).V);
}, 1, "", true));
return default;
}, 2, "", true);
Invoke(Get(R_882, "wh"), "forEach", Fn((V _self871, int _argc2179, V w_2185, V i_2186, V _a2183, V _a2184, V[] _rest2180) => {
double sd_2187 = 0;
double far_2188 = 0;
sd_2187 = (LtN(i_2186, 2D) ? (-1D) : 1D);
far_2188 = (1D - ToNum(Call(SM_16, V.Undef, ((V)((((syh_904 * sd_2187) - 0.06) / 0.22))))));
Call(set_940, V.Undef, GetK(Get(E_883, "wh"), i_2186), ((V)("d")), Call(toD_25, V.Undef, (GtN(wk_959, 0.01) ? Call(wFold_960, V.Undef, w_2185, ((V)(((SEqN(i_2186, 0D) || SEqN(i_2186, 3D)) ? 1D : (-1D))))) : w_2185), face_928));
Call(set_940, V.Undef, GetK(Get(E_883, "wh"), i_2186), ((V)("opacity")), Call(r2_14, V.Undef, ((V)(((0.8 * ToNum(Call(zc_932, V.Undef, ((V)((LtN(i_2186, 2D) ? 36D : 64D))), ((V)(56D))))) * far_2188)))));
return default;
}, 2, "", true));
if (Truthy((Get(E_883, "spots3") is var _t2189 && !Truthy(_t2189) ? _t2189 : Get(D_881, "body3")))) {
V bx_2190 = default;
V by_2191 = default;
V bz_2192 = default;
V brx_2193 = default;
V bry_2194 = default;
V brz_2195 = default;
double t3_2196 = 0;
double c3_2197 = 0;
double s3_2198 = 0;
V dd_2199 = default;
{ V _t2200 = Get(Get(D_881, "body3"), "c");
{ V _t2201 = ListOf(_t2200);
{ V _t2202 = GetIdx(_t2201, 0D);
bx_2190 = _t2202; }
{ V _t2203 = GetIdx(_t2201, 1D);
by_2191 = _t2203; }
{ V _t2204 = GetIdx(_t2201, 2D);
bz_2192 = _t2204; }
} }
{ V _t2205 = Get(Get(D_881, "body3"), "r");
{ V _t2206 = ListOf(_t2205);
{ V _t2207 = GetIdx(_t2206, 0D);
brx_2193 = _t2207; }
{ V _t2208 = GetIdx(_t2206, 1D);
bry_2194 = _t2208; }
{ V _t2209 = GetIdx(_t2206, 2D);
brz_2195 = _t2209; }
} }
t3_2196 = (ToNum((Get(Get(D_881, "body3"), "tilt") is var _t2210 && Truthy(_t2210) ? _t2210 : ((V)(0D)))) * D2R_11);
c3_2197 = FdLibm.Cos(t3_2196);
s3_2198 = FdLibm.Sin(t3_2196);
dd_2199 = ((V)(""));
Invoke(Get(Get(D_881, "spots3"), "pts"), "forEach", Fn((V _self871, int _argc2211, V _a2213, V _a2214, V _a2215, V _a2216, V[] _rest2212) => {
double A_2224 = 0;
double B_2225 = 0;
double lx_2226 = 0;
double ly_2227 = 0;
double lz_2228 = 0;
double X_2229 = 0;
double Y_2230 = 0;
double Z_2231 = 0;
double nlx_2232 = 0;
double nly_2233 = 0;
double nlz_2234 = 0;
double NX_2235 = 0;
double NY_2236 = 0;
double NZ_2237 = 0;
V NL_2238 = default;
double fz_2239 = 0;
double sx_2240 = 0;
V sy_2241 = default;
double nxs_2242 = 0;
double nys_2243 = 0;
V nl_2244 = default;
double ux_2245 = 0;
double uy_2246 = 0;
double mn_2247 = 0;
V pts_2248 = default;
V a_2219 = default;
V b_2221 = default;
V r_2223 = default;
{ V _t2217 = ListOf(_a2213);
{ V _t2218 = GetIdx(_t2217, 0D);
a_2219 = _t2218; }
{ V _t2220 = GetIdx(_t2217, 1D);
b_2221 = _t2220; }
{ V _t2222 = GetIdx(_t2217, 2D);
r_2223 = _t2222; }
}
A_2224 = (ToNum(a_2219) * D2R_11);
B_2225 = (ToNum(b_2221) * D2R_11);
lx_2226 = ((ToNum(brx_2193) * FdLibm.Cos(B_2225)) * FdLibm.Sin(A_2224));
ly_2227 = ((-ToNum(bry_2194)) * FdLibm.Sin(B_2225));
lz_2228 = ((ToNum(brz_2195) * FdLibm.Cos(B_2225)) * FdLibm.Cos(A_2224));
X_2229 = lx_2226;
Y_2230 = ((ly_2227 * c3_2197) - (lz_2228 * s3_2198));
Z_2231 = ((ly_2227 * s3_2198) + (lz_2228 * c3_2197));
nlx_2232 = (lx_2226 / (ToNum(brx_2193) * ToNum(brx_2193)));
nly_2233 = (ly_2227 / (ToNum(bry_2194) * ToNum(bry_2194)));
nlz_2234 = (lz_2228 / (ToNum(brz_2195) * ToNum(brz_2195)));
NX_2235 = nlx_2232;
NY_2236 = ((nly_2233 * c3_2197) - (nlz_2234 * s3_2198));
NZ_2237 = ((nly_2233 * s3_2198) + (nlz_2234 * c3_2197));
NL_2238 = (((V)(Hypot(NX_2235, NY_2236, NZ_2237))) is var _t2249 && Truthy(_t2249) ? _t2249 : ((V)(1D)));
fz_2239 = ((((-NX_2235) * syb_902) + (NZ_2237 * cyb_901)) / ToNum(NL_2238));
if ((fz_2239 < 0.06)) {
return default;
}
sx_2240 = ((50D + ((ToNum(Add(bx_2190, ((V)(X_2229)))) - 50D) * cyb_901)) + (ToNum(Add(bz_2192, ((V)(Z_2231)))) * syb_902));
sy_2241 = Add(by_2191, ((V)(Y_2230)));
nxs_2242 = ((NX_2235 * cyb_901) + (NZ_2237 * syb_902));
nys_2243 = NY_2236;
nl_2244 = (((V)(Hypot(nxs_2242, nys_2243))) is var _t2250 && Truthy(_t2250) ? _t2250 : ((V)(1D)));
ux_2245 = (nxs_2242 / ToNum(nl_2244));
uy_2246 = (nys_2243 / ToNum(nl_2244));
mn_2247 = (ToNum(r_2223) * fz_2239);
pts_2248 = Arr();
{
double k_2251 = 0;
k_2251 = 0D;
while (true) {
if (!((k_2251 < 10D))) break;
double t_2253 = 0;
double c_2254 = 0;
double s_2255 = 0;
t_2253 = ((k_2251 / 10D) * TAU_12);
c_2254 = FdLibm.Cos(t_2253);
s_2255 = FdLibm.Sin(t_2253);
Invoke(pts_2248, "push", Call(glob_918, V.Undef, ((V)(((sx_2240 - ((uy_2246 * ToNum(r_2223)) * c_2254)) + ((ux_2245 * mn_2247) * s_2255)))), Add(Add(sy_2241, ((V)(((ux_2245 * ToNum(r_2223)) * c_2254)))), ((V)(((uy_2246 * mn_2247) * s_2255))))));
k_2251++;
}
}
dd_2199 = Add(dd_2199, Call(closedD_29, V.Undef, pts_2248));
return default;
}, 1, "", true));
Call(set_940, V.Undef, Get(E_883, "spots3"), ((V)("d")), (dd_2199 is var _t2256 && Truthy(_t2256) ? _t2256 : ((V)("M0 0"))));
}
if (Truthy(((Get(E_883, "belly") is var _t2257 && !Truthy(_t2257) ? _t2257 : Get(D_881, "body3")) is var _t2258 && !Truthy(_t2258) ? _t2258 : Get(D_881, "belly")))) {
V bx_2259 = default;
V by_2260 = default;
V bz_2261 = default;
V brx_2262 = default;
V bry_2263 = default;
V brz_2264 = default;
V bf_2265 = default;
{ V _t2266 = Get(Get(D_881, "body3"), "c");
{ V _t2267 = ListOf(_t2266);
{ V _t2268 = GetIdx(_t2267, 0D);
bx_2259 = _t2268; }
{ V _t2269 = GetIdx(_t2267, 1D);
by_2260 = _t2269; }
{ V _t2270 = GetIdx(_t2267, 2D);
bz_2261 = _t2270; }
} }
{ V _t2271 = Get(Get(D_881, "body3"), "r");
{ V _t2272 = ListOf(_t2271);
{ V _t2273 = GetIdx(_t2272, 0D);
brx_2262 = _t2273; }
{ V _t2274 = GetIdx(_t2272, 1D);
bry_2263 = _t2274; }
{ V _t2275 = GetIdx(_t2272, 2D);
brz_2264 = _t2275; }
} }
bf_2265 = Fn((V _self871, int _argc2276, V x_2282, V y_2283, V _a2280, V _a2281, V[] _rest2277) => {
double dx_2284 = 0;
V v_2285 = default;
double cw_2286 = 0;
double w_2287 = 0;
double dd_2288 = 0;
double q_2289 = 0;
V z_2290 = default;
double rim_2291 = 0;
double Xc_2292 = 0;
dx_2284 = (ToNum(x_2282) - ToNum(bx_2259));
v_2285 = Call(clamp_13, V.Undef, ((V)(((ToNum(y_2283) - ToNum(by_2260)) / ToNum(bry_2263)))), ((V)((-0.98))), ((V)(0.98)));
cw_2286 = System.Math.Sqrt((1D - (ToNum(v_2285) * ToNum(v_2285))));
w_2287 = (ToNum(brx_2262) * cw_2286);
dd_2288 = (ToNum(brz_2264) * cw_2286);
q_2289 = (1D - ((dx_2284 / w_2287) * (dx_2284 / w_2287)));
z_2290 = Add(bz_2261, ((V)((dd_2288 * System.Math.Sqrt(Max(0D, q_2289))))));
rim_2291 = Hypot((w_2287 * cyb_901), (dd_2288 * syb_902));
Xc_2292 = (ToNum(bz_2261) * syb_902);
return Call(glob_918, V.Undef, Add(((V)(50D)), Call(clamp_13, V.Undef, ((V)(((dx_2284 * cyb_901) + (ToNum(z_2290) * syb_902)))), ((V)((Xc_2292 - rim_2291))), ((V)((Xc_2292 + rim_2291))))), y_2283);
return default;
}, 2, "", true);
Call(set_940, V.Undef, Get(E_883, "belly"), ((V)("d")), Call(closedD_29, V.Undef, Invoke((Get(R_882, "bellyP") is var _t2300 && Truthy(_t2300) ? _t2300 : Set(R_882, "bellyP", Invoke(Call(flat_27, V.Undef, Get(R_882, "belly"), ((V)(4D))), "slice", ((V)(0D)), ((V)((-1D)))))), "map", Fn((V _self871, int _argc2293, V p_2299, V _a2296, V _a2297, V _a2298, V[] _rest2294) => {
return Call(bf_2265, V.Undef, GetIdx(p_2299, 0D), GetIdx(p_2299, 1D));
}, 1, "", true))));
Call(set_940, V.Undef, Get(E_883, "belly"), ((V)("opacity")), Call(r2_14, V.Undef, Call(SM_16, V.Undef, ((V)(((cyb_901 - 0.15) / 0.45))))));
} else {
if (Truthy(Get(E_883, "belly"))) {
if (Truthy((Get(D_881, "bellyTurn") is var _t2301 && !Truthy(_t2301) ? _t2301 : Get(D_881, "belly")))) {
V BX_2302 = default;
V BY_2303 = default;
V BW_2304 = default;
V BH_2305 = default;
V bf_2306 = default;
{ V _t2307 = Get(D_881, "body");
{ V _t2308 = ListOf(_t2307);
{ V _t2309 = GetIdx(_t2308, 0D);
BX_2302 = _t2309; }
{ V _t2310 = GetIdx(_t2308, 1D);
BY_2303 = _t2310; }
{ V _t2311 = GetIdx(_t2308, 2D);
BW_2304 = _t2311; }
{ V _t2312 = GetIdx(_t2308, 3D);
BH_2305 = _t2312; }
} }
bf_2306 = Fn((V _self871, int _argc2313, V x_2319, V y_2320, V _a2317, V _a2318, V[] _rest2314) => {
double dx_2321 = 0;
V v_2322 = default;
double w_2323 = 0;
double wc_2324 = 0;
double q_2325 = 0;
double z_2326 = 0;
double X_2327 = 0;
dx_2321 = (ToNum(x_2319) - ToNum(BX_2302));
v_2322 = Call(clamp_13, V.Undef, ((V)(((ToNum(y_2320) - ToNum(BY_2303)) / ToNum(BH_2305)))), ((V)((-1D))), ((V)(1D)));
w_2323 = (ToNum(BW_2304) * System.Math.Sqrt((1D - (ToNum(v_2322) * ToNum(v_2322)))));
wc_2324 = (ToNum(BW_2304) * System.Math.Sqrt((1D - ((ToNum(v_2322) * ToNum(v_2322)) * 0.36))));
q_2325 = ((wc_2324 * wc_2324) - (dx_2321 * dx_2321));
z_2326 = ((q_2325 > 0D) ? System.Math.Sqrt(q_2325) : 0D);
X_2327 = ((dx_2321 * cyb_901) + (z_2326 * syb_902));
if (((((-dx_2321) * syb_902) + (z_2326 * cyb_901)) < 0D)) {
X_2327 = (((X_2327 < 0D) ? (-1D) : 1D) * wc_2324);
}
return Call(glob_918, V.Undef, Add(BX_2302, Call(clamp_13, V.Undef, ((V)(X_2327)), ((V)((-w_2323))), ((V)(w_2323)))), y_2320);
return default;
}, 2, "", true);
Call(set_940, V.Undef, Get(E_883, "belly"), ((V)("d")), Call(closedD_29, V.Undef, Invoke((Get(R_882, "bellyP") is var _t2335 && Truthy(_t2335) ? _t2335 : Set(R_882, "bellyP", Invoke(Call(flat_27, V.Undef, Get(R_882, "belly"), ((V)(4D))), "slice", ((V)(0D)), ((V)((-1D)))))), "map", Fn((V _self871, int _argc2328, V p_2334, V _a2331, V _a2332, V _a2333, V[] _rest2329) => {
return Call(bf_2306, V.Undef, GetIdx(p_2334, 0D), GetIdx(p_2334, 1D));
}, 1, "", true))));
Call(set_940, V.Undef, Get(E_883, "belly"), ((V)("opacity")), Call(r2_14, V.Undef, Call(SM_16, V.Undef, ((V)(((cyb_901 + 0.3) / 0.4))))));
} else {
Call(set_940, V.Undef, Get(E_883, "belly"), ((V)("d")), Call(toD_25, V.Undef, Get(R_882, "belly"), glob_918));
}
}
}
if (Truthy(Get(E_883, "coat"))) {
V K_2336 = default;
V ed_2337 = default;
V ld_2338 = default;
V p2s_2339 = default;
V br_2340 = default;
V LA_2341 = default;
double gl_2342 = 0;
V PJ_2343 = default;
V SM2_2344 = default;
V mB_2345 = default;
V mBF_2346 = default;
V mHF_2347 = default;
V LS_2348 = default;
V cS_2349 = default;
V f_2350 = default;
V put_2351 = default;
K_2336 = Get(R_882, "coat");
ed_2337 = (Get(I_878, "ed") is var _t2352 && Truthy(_t2352) ? _t2352 : ((V)(0D)));
ld_2338 = (Get(I_878, "ld") is var _t2353 && Truthy(_t2353) ? _t2353 : ((V)(0D)));
p2s_2339 = Fn((V _self871, int _argc2354, V q_2360, V _a2357, V _a2358, V _a2359, V[] _rest2355) => {
return ((V)(string.Concat(ToStr(Call(r2_14, V.Undef, GetIdx(q_2360, 0D))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(q_2360, 1D))))));
}, 1, "", true);
br_2340 = Call(clamp_13, V.Undef, ((V)(Max(ToNum((Get(P_879, "bristle") is var _t2361 && Truthy(_t2361) ? _t2361 : ((V)(0D)))), (ToNum(Call(clamp_13, V.Undef, Get(P_879, "wide"), ((V)(0D)), ((V)(1D)))) * 0.85), (ToNum(Call(SM_16, V.Undef, ((V)((((-ToNum(Get(P_879, "pitch"))) - 0.3) / 0.25))))) * ToNum(Call(SM_16, V.Undef, ((V)(((ToNum(sq_912) - 0.08) / 0.06))))))))), ((V)(0D)), ((V)(1D)));
LA_2341 = Invoke(Get(K_2336, "lay"), "map", Fn((V _self871, int _argc2362, V v_2368, V j_2369, V _a2366, V _a2367, V[] _rest2363) => {
return Add(v_2368, ((V)(((ToNum(GetK(Get(K_2336, "layUp"), j_2369)) - ToNum(v_2368)) * ToNum(br_2340)))));
}, 2, "", true));
gl_2342 = (1D + (ToNum(br_2340) * 0.22));
PJ_2343 = Fn((V _self871, int _argc2370, V p_2376, V w_2377, V _a2374, V _a2375, V[] _rest2371) => {
V B_2378 = default;
V zb_2379 = default;
V A_2380 = default;
V za_2381 = default;
B_2378 = Call(byw_938, V.Undef, GetIdx(p_2376, 0D), GetIdx(p_2376, 1D), GetIdx(p_2376, 2D));
zb_2379 = Call(bywZ_939, V.Undef, GetIdx(p_2376, 0D), GetIdx(p_2376, 2D));
if (LeN(w_2377, 0.002)) {
return Arr(B_2378, zb_2379);
}
A_2380 = Call(sph_926, V.Undef, GetIdx(p_2376, 0D), GetIdx(p_2376, 1D), GetIdx(p_2376, 2D));
za_2381 = Call(sphZ_927, V.Undef, GetIdx(p_2376, 0D), GetIdx(p_2376, 1D), GetIdx(p_2376, 2D));
if (GeN(w_2377, 0.998)) {
return Arr(A_2380, za_2381);
}
return Arr(Arr(Add(GetIdx(B_2378, 0D), ((V)(((ToNum(GetIdx(A_2380, 0D)) - ToNum(GetIdx(B_2378, 0D))) * ToNum(w_2377))))), Add(GetIdx(B_2378, 1D), ((V)(((ToNum(GetIdx(A_2380, 1D)) - ToNum(GetIdx(B_2378, 1D))) * ToNum(w_2377)))))), Add(zb_2379, ((V)(((ToNum(za_2381) - ToNum(zb_2379)) * ToNum(w_2377))))));
return default;
}, 2, "", true);
SM2_2344 = Invoke(Get(K_2336, "mesh"), "map", Fn((V _self871, int _argc2382, V row_2388, V _a2385, V _a2386, V _a2387, V[] _rest2383) => {
return Invoke(row_2388, "map", Fn((V _self871, int _argc2389, V v_2395, V _a2392, V _a2393, V _a2394, V[] _rest2390) => {
V q_2396 = default;
V z_2397 = default;
{ V _t2398 = Call(PJ_2343, V.Undef, Get(v_2395, "p"), Get(v_2395, "w"));
{ V _t2399 = ListOf(_t2398);
{ V _t2400 = GetIdx(_t2399, 0D);
q_2396 = _t2400; }
{ V _t2401 = GetIdx(_t2399, 1D);
z_2397 = _t2401; }
} }
return NewObj(3).Put("q", q_2396).Put("z", z_2397).Put("w", Get(v_2395, "w")).V;
return default;
}, 1, "", true));
}, 1, "", true));
mB_2345 = ((V)(""));
mBF_2346 = ((V)(""));
mHF_2347 = ((V)(""));
{
double r_2402 = 0;
r_2402 = 0D;
while (true) {
if (!((r_2402 < (ToNum(Get(SM2_2344, "length")) - 1D)))) break;
{
double i_2404 = 0;
i_2404 = 0D;
while (true) {
if (!(Lt(((V)(i_2404)), Get(GetIdx(SM2_2344, r_2402), "length")))) break;
double i2_2406 = 0;
V c_2407 = default;
V w_2408 = default;
double ar_2409 = 0;
V d_2410 = default;
i2_2406 = ((i_2404 + 1D) % ToNum(Get(GetIdx(SM2_2344, r_2402), "length")));
c_2407 = Arr(GetIdx(GetIdx(SM2_2344, r_2402), i_2404), GetIdx(GetIdx(SM2_2344, r_2402), i2_2406), GetIdx(GetIdx(SM2_2344, (r_2402 + 1D)), i2_2406), GetIdx(GetIdx(SM2_2344, (r_2402 + 1D)), i_2404));
w_2408 = Invoke(c_2407, "map", Fn((V _self871, int _argc2411, V o_2417, V _a2414, V _a2415, V _a2416, V[] _rest2412) => {
return Get(o_2417, "q");
}, 1, "", true));
ar_2409 = 0D;
{
double k_2418 = 0;
k_2418 = 0D;
while (true) {
if (!((k_2418 < 4D))) break;
V A_2420 = default;
V B_2421 = default;
A_2420 = GetIdx(w_2408, k_2418);
B_2421 = GetIdx(w_2408, ((k_2418 + 1D) % 4D));
ar_2409 = (ar_2409 + ((ToNum(GetIdx(A_2420, 0D)) * ToNum(GetIdx(B_2421, 1D))) - (ToNum(GetIdx(B_2421, 0D)) * ToNum(GetIdx(A_2420, 1D)))));
k_2418++;
}
}
if ((ar_2409 < 0D)) {
Invoke(w_2408, "reverse");
}
d_2410 = ((V)(string.Concat("M", ToStr(Invoke(Invoke(w_2408, "map", p2s_2339), "join", ((V)(" L")))), "Z")));
if (((ToNum(Add(Add(Add(Get(GetIdx(c_2407, 0D), "z"), Get(GetIdx(c_2407, 1D), "z")), Get(GetIdx(c_2407, 2D), "z")), Get(GetIdx(c_2407, 3D), "z"))) / 4D) > 0D)) {
if (((ToNum(Add(Add(Add(Get(GetIdx(c_2407, 0D), "w"), Get(GetIdx(c_2407, 1D), "w")), Get(GetIdx(c_2407, 2D), "w")), Get(GetIdx(c_2407, 3D), "w"))) / 4D) > 0.5)) {
mHF_2347 = Add(mHF_2347, d_2410);
} else {
mBF_2346 = Add(mBF_2346, d_2410);
}
} else {
mB_2345 = Add(mB_2345, d_2410);
}
i_2404++;
}
}
r_2402++;
}
}
LS_2348 = NewObj(3).Put("back", Arr()).Put("bodyF", Arr()).Put("headF", Arr()).V;
cS_2349 = GetIdx(Call(PJ_2343, V.Undef, Arr(((V)(50D)), ((V)(62D)), ((V)(0D))), ((V)(0.5))), 0D);
f_2350 = Get(K_2336, "tipF");
Invoke(Get(K_2336, "sp"), "forEach", Fn((V _self871, int _argc2422, V s_2428, V _a2425, V _a2426, V _a2427, V[] _rest2423) => {
V ou_2429 = default;
V dv_2430 = default;
V dl_2431 = default;
double ln_2432 = 0;
V tip_2433 = default;
V A_2434 = default;
V zr_2435 = default;
V Tt_2436 = default;
V zt_2437 = default;
double k_2438 = 0;
double vx_2439 = 0;
double vy_2440 = 0;
double L_2441 = 0;
double nx_2442 = 0;
double ny_2443 = 0;
V w_2444 = default;
double wob_2445 = 0;
V T_2446 = default;
V B1_2447 = default;
V B2_2448 = default;
V d_2449 = default;
V dt_2450 = default;
ou_2429 = Add(GetIdx(LA_2341, 0D), ((V)((ToNum(Get(s_2428, "rim")) * (1D - ToNum(br_2340))))));
dv_2430 = Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _self871, int _argc2451, V j_2457, V _a2454, V _a2455, V _a2456, V[] _rest2452) => {
return Add(((V)(((ToNum(GetK(Get(s_2428, "n"), j_2457)) * ToNum(ou_2429)) + (ToNum(GetK(Get(s_2428, "e"), j_2457)) * ToNum(GetIdx(LA_2341, 1D)))))), (SEqN(j_2457, 1D) ? GetIdx(LA_2341, 2D) : ((V)(0D))));
}, 1, "", true));
dl_2431 = (((V)(Hypot(ToNum(GetIdx(dv_2430, 0D)), ToNum(GetIdx(dv_2430, 1D)), ToNum(GetIdx(dv_2430, 2D))))) is var _t2458 && Truthy(_t2458) ? _t2458 : ((V)(1D)));
ln_2432 = ((ToNum(Get(s_2428, "len")) * gl_2342) / ToNum(dl_2431));
tip_2433 = Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _self871, int _argc2459, V j_2465, V _a2462, V _a2463, V _a2464, V[] _rest2460) => {
return Add(GetK(Get(s_2428, "r"), j_2465), ((V)((ToNum(GetK(dv_2430, j_2465)) * ln_2432))));
}, 1, "", true));
{ V _t2466 = Call(PJ_2343, V.Undef, Get(s_2428, "r"), Get(s_2428, "o"));
{ V _t2467 = ListOf(_t2466);
{ V _t2468 = GetIdx(_t2467, 0D);
A_2434 = _t2468; }
{ V _t2469 = GetIdx(_t2467, 1D);
zr_2435 = _t2469; }
} }
{ V _t2470 = Call(PJ_2343, V.Undef, tip_2433, Get(s_2428, "o"));
{ V _t2471 = ListOf(_t2470);
{ V _t2472 = GetIdx(_t2471, 0D);
Tt_2436 = _t2472; }
{ V _t2473 = GetIdx(_t2471, 1D);
zt_2437 = _t2473; }
} }
k_2438 = (ToNum(Get(s_2428, "len")) / 10D);
vx_2439 = (ToNum(GetIdx(Tt_2436, 0D)) - ToNum(GetIdx(A_2434, 0D)));
vy_2440 = (ToNum(GetIdx(Tt_2436, 1D)) - ToNum(GetIdx(A_2434, 1D)));
L_2441 = Hypot(vx_2439, vy_2440);
if ((L_2441 < 1.2)) {
double ox_2474 = 0;
double oy_2475 = 0;
V ol_2476 = default;
ox_2474 = (ToNum(GetIdx(A_2434, 0D)) - ToNum(GetIdx(cS_2349, 0D)));
oy_2475 = (ToNum(GetIdx(A_2434, 1D)) - ToNum(GetIdx(cS_2349, 1D)));
ol_2476 = (((V)(Hypot(ox_2474, oy_2475))) is var _t2477 && Truthy(_t2477) ? _t2477 : ((V)(1D)));
vx_2439 = ((ox_2474 / ToNum(ol_2476)) * 1.2);
vy_2440 = ((oy_2475 / ToNum(ol_2476)) * 1.2);
L_2441 = 1.2;
}
nx_2442 = ((-vy_2440) / L_2441);
ny_2443 = (vx_2439 / L_2441);
w_2444 = Get(s_2428, "w");
wob_2445 = ((FdLibm.Sin(((ToNum(now_880) / 520D) + (ToNum(Get(s_2428, "i")) * 1.7))) * 0.2) * k_2438);
T_2446 = Arr(Add(Add(Add(GetIdx(A_2434, 0D), ((V)(vx_2439))), ((V)(((ToNum(ed_2337) * 0.3) * k_2438)))), ((V)((nx_2442 * wob_2445)))), ((V)(((ToNum(Add(GetIdx(A_2434, 1D), ((V)(vy_2440)))) - ((ToNum(ld_2338) * 0.25) * k_2438)) + (ny_2443 * wob_2445)))));
B1_2447 = Arr(Add(GetIdx(A_2434, 0D), ((V)((nx_2442 * ToNum(w_2444))))), Add(GetIdx(A_2434, 1D), ((V)((ny_2443 * ToNum(w_2444))))));
B2_2448 = Arr(((V)((ToNum(GetIdx(A_2434, 0D)) - (nx_2442 * ToNum(w_2444))))), ((V)((ToNum(GetIdx(A_2434, 1D)) - (ny_2443 * ToNum(w_2444))))));
d_2449 = ((V)(string.Concat(new string[] { "M", ToStr(Call(p2s_2339, V.Undef, B1_2447)), " L", ToStr(Call(p2s_2339, V.Undef, T_2446)), " L", ToStr(Call(p2s_2339, V.Undef, B2_2448)) })));
dt_2450 = ((V)((Truthy(f_2350) ? string.Concat(new string[] { "M", ToStr(Call(p2s_2339, V.Undef, Arr(Add(GetIdx(B1_2447, 0D), ((V)(((ToNum(GetIdx(T_2446, 0D)) - ToNum(GetIdx(B1_2447, 0D))) * ToNum(f_2350))))), Add(GetIdx(B1_2447, 1D), ((V)(((ToNum(GetIdx(T_2446, 1D)) - ToNum(GetIdx(B1_2447, 1D))) * ToNum(f_2350)))))))), " L", ToStr(Call(p2s_2339, V.Undef, T_2446)), " L", ToStr(Call(p2s_2339, V.Undef, Arr(Add(GetIdx(B2_2448, 0D), ((V)(((ToNum(GetIdx(T_2446, 0D)) - ToNum(GetIdx(B2_2448, 0D))) * ToNum(f_2350))))), Add(GetIdx(B2_2448, 1D), ((V)(((ToNum(GetIdx(T_2446, 1D)) - ToNum(GetIdx(B2_2448, 1D))) * ToNum(f_2350)))))))), "Z" }) : "")));
Invoke(GetK(LS_2348, ((V)((GtN(zr_2435, (-1.5)) ? (GtN(Get(s_2428, "o"), 0.5) ? "headF" : "bodyF") : "back")))), "push", Arr(((V)((ToNum(Add(zr_2435, zt_2437)) / 2D))), d_2449, dt_2450));
return default;
}, 1, "", true));
put_2351 = Fn((V _self871, int _argc2478, V pool_2484, V list_2485, V _a2482, V _a2483, V[] _rest2479) => {
Invoke(list_2485, "sort", Fn((V _self871, int _argc2486, V a_2492, V b_2493, V _a2490, V _a2491, V[] _rest2487) => {
return ((V)((ToNum(GetIdx(a_2492, 0D)) - ToNum(GetIdx(b_2493, 0D)))));
}, 2, "", true));
Invoke(pool_2484, "forEach", Fn((V _self871, int _argc2494, V el_2500, V i_2501, V _a2498, V _a2499, V[] _rest2495) => {
V v_2502 = default;
V d_2503 = default;
V dt_2504 = default;
v_2502 = GetK(list_2485, i_2501);
d_2503 = (Truthy(v_2502) ? GetIdx(v_2502, 1D) : ((V)("")));
dt_2504 = (Truthy(v_2502) ? GetIdx(v_2502, 2D) : ((V)("")));
if (!SEq(Get(el_2500, "_d"), d_2503)) {
Set(el_2500, "_d", d_2503);
Call(set_940, V.Undef, Get(el_2500, "firstChild"), ((V)("d")), d_2503);
}
if (!SEq(Get(el_2500, "_t"), dt_2504)) {
Set(el_2500, "_t", dt_2504);
Call(set_940, V.Undef, Get(el_2500, "lastChild"), ((V)("d")), dt_2504);
}
return default;
}, 2, "", true));
return default;
}, 2, "", true);
Call(put_2351, V.Undef, Get(Get(E_883, "coat"), "back"), Get(LS_2348, "back"));
Call(put_2351, V.Undef, Get(Get(E_883, "coat"), "bodyF"), Get(LS_2348, "bodyF"));
Call(put_2351, V.Undef, Get(Get(E_883, "coat"), "headF"), Get(LS_2348, "headF"));
Call(set_940, V.Undef, Get(Get(E_883, "coat"), "mB"), ((V)("d")), mB_2345);
Call(set_940, V.Undef, Get(Get(E_883, "coat"), "mBF"), ((V)("d")), mBF_2346);
Call(set_940, V.Undef, Get(Get(E_883, "coat"), "mHF"), ((V)("d")), mHF_2347);
} else {
if (Truthy(Get(E_883, "hog"))) {
V K_2505 = default;
V ed_2506 = default;
V ld_2507 = default;
double grow_2508 = 0;
V BX0_2509 = default;
V BY0_2510 = default;
V BW0_2511 = default;
V BH0_2512 = default;
double BZ_2513 = 0;
V hw_2514 = default;
double dyw_2515 = 0;
V rot_2516 = default;
V fac_2517 = default;
V p2s_2518 = default;
V W2_2519 = default;
V surf_2520 = default;
V S_2521 = default;
V na_2522 = default;
V dB_2523 = default;
V dF_2524 = default;
V LS_2525 = default;
V put_2526 = default;
K_2505 = Get(R_882, "hog");
ed_2506 = (Get(I_878, "ed") is var _t2527 && Truthy(_t2527) ? _t2527 : ((V)(0D)));
ld_2507 = (Get(I_878, "ld") is var _t2528 && Truthy(_t2528) ? _t2528 : ((V)(0D)));
grow_2508 = ((1D + (ToNum(Call(clamp_13, V.Undef, Get(P_879, "wide"), ((V)(0D)), ((V)(1D)))) * 0.2)) + (Max(0D, ToNum(sq_912)) * 0.15));
{ V _t2529 = Get(D_881, "body");
{ V _t2530 = ListOf(_t2529);
{ V _t2531 = GetIdx(_t2530, 0D);
BX0_2509 = _t2531; }
{ V _t2532 = GetIdx(_t2530, 1D);
BY0_2510 = _t2532; }
{ V _t2533 = GetIdx(_t2530, 2D);
BW0_2511 = _t2533; }
{ V _t2534 = GetIdx(_t2530, 3D);
BH0_2512 = _t2534; }
} }
BZ_2513 = (ToNum(BW0_2511) * 0.75);
hw_2514 = Fn((V _self871, int _argc2535, V p_2541, V _a2538, V _a2539, V _a2540, V[] _rest2536) => {
return ((V)((ToNum(Call(SM_16, V.Undef, ((V)(((60D - ToNum(GetIdx(p_2541, 1D))) / 18D))))) * ToNum(Call(SM_16, V.Undef, ((V)((ToNum(Add(GetIdx(p_2541, 2D), ((V)(26D)))) / 14D))))))));
}, 1, "", true);
dyw_2515 = (yh_896 - yb_895);
rot_2516 = Fn((V _self871, int _argc2542, V p_2548, V w_2549, V _a2546, V _a2547, V[] _rest2543) => {
double a_2550 = 0;
double c_2551 = 0;
double s_2552 = 0;
double x_2553 = 0;
V y_2554 = default;
double z_2555 = 0;
if (!(Truthy(w_2549))) {
return Arr(((V)(((50D + ((ToNum(GetIdx(p_2548, 0D)) - 50D) * cyb_901)) + (ToNum(GetIdx(p_2548, 2D)) * syb_902)))), GetIdx(p_2548, 1D), ((V)((((-(ToNum(GetIdx(p_2548, 0D)) - 50D)) * syb_902) + (ToNum(GetIdx(p_2548, 2D)) * cyb_901)))));
}
a_2550 = (yb_895 + (dyw_2515 * ToNum(w_2549)));
c_2551 = FdLibm.Cos(a_2550);
s_2552 = FdLibm.Sin(a_2550);
x_2553 = ((50D + ((ToNum(GetIdx(p_2548, 0D)) - 50D) * c_2551)) + (ToNum(GetIdx(p_2548, 2D)) * s_2552));
y_2554 = GetIdx(p_2548, 1D);
z_2555 = (((-(ToNum(GetIdx(p_2548, 0D)) - 50D)) * s_2552) + (ToNum(GetIdx(p_2548, 2D)) * c_2551));
if (NumTruthy(ph_900)) {
double pa_2556 = 0;
double cc_2557 = 0;
double ss_2558 = 0;
double dy_2559 = 0;
pa_2556 = (ph_900 * ToNum(w_2549));
cc_2557 = FdLibm.Cos(pa_2556);
ss_2558 = FdLibm.Sin(pa_2556);
dy_2559 = (ToNum(y_2554) - ToNum(HY_887));
y_2554 = ((V)((ToNum(Add(HY_887, ((V)((dy_2559 * cc_2557))))) - (z_2555 * ss_2558))));
z_2555 = ((dy_2559 * ss_2558) + (z_2555 * cc_2557));
}
return Arr(((V)(x_2553)), y_2554, ((V)(z_2555)));
return default;
}, 2, "", true);
fac_2517 = Fn((V _self871, int _argc2560, V n_2566, V w_2567, V _a2564, V _a2565, V[] _rest2561) => {
double a_2568 = 0;
if (!(Truthy(w_2567))) {
return ((V)((((-ToNum(GetIdx(n_2566, 0D))) * syb_902) + (ToNum(GetIdx(n_2566, 2D)) * cyb_901))));
}
a_2568 = (yb_895 + (dyw_2515 * ToNum(w_2567)));
return ((V)((((-ToNum(GetIdx(n_2566, 0D))) * FdLibm.Sin(a_2568)) + (ToNum(GetIdx(n_2566, 2D)) * FdLibm.Cos(a_2568)))));
return default;
}, 2, "", true);
p2s_2518 = Fn((V _self871, int _argc2569, V q_2575, V _a2572, V _a2573, V _a2574, V[] _rest2570) => {
return ((V)(string.Concat(ToStr(Call(r2_14, V.Undef, GetIdx(q_2575, 0D))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(q_2575, 1D))))));
}, 1, "", true);
if (!(Truthy(Get(K_2505, "GW")))) {
Set(K_2505, "GW", Invoke(Get(K_2505, "G"), "map", Fn((V _self871, int _argc2576, V row_2582, V _a2579, V _a2580, V _a2581, V[] _rest2577) => {
return Invoke(row_2582, "map", hw_2514);
}, 1, "", true)));
Invoke(Get(K_2505, "sp"), "forEach", Fn((V _self871, int _argc2583, V s_2589, V _a2586, V _a2587, V _a2588, V[] _rest2584) => {
Set(s_2589, "hw", Call(hw_2514, V.Undef, Arr(((V)((ToNum(Add(GetIdx(Get(s_2589, "b1"), 0D), GetIdx(Get(s_2589, "b2"), 0D))) / 2D))), ((V)((ToNum(Add(GetIdx(Get(s_2589, "b1"), 1D), GetIdx(Get(s_2589, "b2"), 1D))) / 2D))), ((V)((ToNum(Add(GetIdx(Get(s_2589, "b1"), 2D), GetIdx(Get(s_2589, "b2"), 2D))) / 2D))))));
return default;
}, 1, "", true));
}
W2_2519 = Fn((V _self871, int _argc2590, V X_2596, V Y_2597, V _a2594, V _a2595, V[] _rest2591) => {
V w_2598 = default;
V a_2599 = default;
V b_2600 = default;
w_2598 = Call(SM_16, V.Undef, ((V)(((ToNum(NY_894) - ToNum(Y_2597)) / 12D))));
if (LeN(w_2598, 0D)) {
return Call(glob_918, V.Undef, X_2596, Y_2597);
}
a_2599 = Call(headT_924, V.Undef, X_2596, Y_2597);
if (GeN(w_2598, 1D)) {
return a_2599;
}
b_2600 = Call(glob_918, V.Undef, X_2596, Y_2597);
return Arr(Add(GetIdx(b_2600, 0D), ((V)(((ToNum(GetIdx(a_2599, 0D)) - ToNum(GetIdx(b_2600, 0D))) * ToNum(w_2598))))), Add(GetIdx(b_2600, 1D), ((V)(((ToNum(GetIdx(a_2599, 1D)) - ToNum(GetIdx(b_2600, 1D))) * ToNum(w_2598))))));
return default;
}, 2, "", true);
surf_2520 = Fn((V _self871, int _argc2601, V X_2607, V Y_2608, V _a2605, V _a2606, V[] _rest2602) => {
double a_2609 = 0;
double b_2610 = 0;
a_2609 = ((1D - Pow(((ToNum(X_2607) - ToNum(HX_886)) / ToNum(SR_889)), 2D)) - Pow(((ToNum(Y_2608) - ToNum(HY_887)) / ToNum(SRY_891)), 2D));
b_2610 = ((1D - Pow(((ToNum(X_2607) - ToNum(BX0_2509)) / ToNum(BW0_2511)), 2D)) - Pow(((ToNum(Y_2608) - ToNum(BY0_2510)) / ToNum(BH0_2512)), 2D));
return ((V)(Max(((a_2609 > 0D) ? (ToNum(SR_889) * System.Math.Sqrt(a_2609)) : (-1000000000D)), ((b_2610 > 0D) ? (BZ_2513 * System.Math.Sqrt(b_2610)) : (-1000000000D)))));
return default;
}, 2, "", true);
S_2521 = Invoke(Get(K_2505, "G"), "map", Fn((V _self871, int _argc2611, V row_2617, V j_2618, V _a2615, V _a2616, V[] _rest2612) => {
return Invoke(row_2617, "map", Fn((V _self871, int _argc2619, V p_2625, V i_2626, V _a2623, V _a2624, V[] _rest2620) => {
V q_2627 = default;
q_2627 = Call(rot_2516, V.Undef, p_2625, GetK(GetK(Get(K_2505, "GW"), j_2618), i_2626));
return NewObj(2).Put("q", q_2627).Put("w", Call(W2_2519, V.Undef, GetIdx(q_2627, 0D), GetIdx(q_2627, 1D))).V;
return default;
}, 2, "", true));
}, 2, "", true));
na_2522 = Get(Get(K_2505, "A"), "length");
dB_2523 = ((V)(""));
dF_2524 = ((V)(""));
{
double j_2628 = 0;
j_2628 = 0D;
while (true) {
if (!((j_2628 < (ToNum(Get(Get(K_2505, "B"), "length")) - 1D)))) break;
{
double i_2630 = 0;
i_2630 = 0D;
while (true) {
if (!(Lt(((V)(i_2630)), na_2522))) break;
double i2_2632 = 0;
V c_2633 = default;
V w_2634 = default;
double ar_2635 = 0;
V d_2636 = default;
i2_2632 = ((i_2630 + 1D) % ToNum(na_2522));
c_2633 = Arr(GetIdx(GetIdx(S_2521, j_2628), i_2630), GetIdx(GetIdx(S_2521, j_2628), i2_2632), GetIdx(GetIdx(S_2521, (j_2628 + 1D)), i2_2632), GetIdx(GetIdx(S_2521, (j_2628 + 1D)), i_2630));
w_2634 = Invoke(c_2633, "map", Fn((V _self871, int _argc2637, V o_2643, V _a2640, V _a2641, V _a2642, V[] _rest2638) => {
return Get(o_2643, "w");
}, 1, "", true));
ar_2635 = 0D;
{
double k_2644 = 0;
k_2644 = 0D;
while (true) {
if (!((k_2644 < 4D))) break;
V a_2646 = default;
V b_2647 = default;
a_2646 = GetIdx(w_2634, k_2644);
b_2647 = GetIdx(w_2634, ((k_2644 + 1D) % 4D));
ar_2635 = (ar_2635 + ((ToNum(GetIdx(a_2646, 0D)) * ToNum(GetIdx(b_2647, 1D))) - (ToNum(GetIdx(b_2647, 0D)) * ToNum(GetIdx(a_2646, 1D)))));
k_2644++;
}
}
if ((ar_2635 < 0D)) {
Invoke(w_2634, "reverse");
}
d_2636 = ((V)(string.Concat("M", ToStr(Invoke(Invoke(w_2634, "map", p2s_2518), "join", ((V)(" L")))), "Z")));
dB_2523 = Add(dB_2523, d_2636);
if (GtN(Call(fac_2517, V.Undef, GetIdx(GetIdx(Get(K_2505, "QN"), j_2628), i_2630), ((V)((ToNum(Add(GetIdx(GetIdx(Get(K_2505, "GW"), j_2628), i_2630), GetIdx(GetIdx(Get(K_2505, "GW"), (j_2628 + 1D)), ((i_2630 + 1D) % ToNum(na_2522))))) / 2D)))), 0.02)) {
double mx_2648 = 0;
double my_2649 = 0;
double mz_2650 = 0;
mx_2648 = (ToNum(Add(GetIdx(Get(GetIdx(c_2633, 0D), "q"), 0D), GetIdx(Get(GetIdx(c_2633, 2D), "q"), 0D))) / 2D);
my_2649 = (ToNum(Add(GetIdx(Get(GetIdx(c_2633, 0D), "q"), 1D), GetIdx(Get(GetIdx(c_2633, 2D), "q"), 1D))) / 2D);
mz_2650 = (ToNum(Add(Add(Add(GetIdx(Get(GetIdx(c_2633, 0D), "q"), 2D), GetIdx(Get(GetIdx(c_2633, 1D), "q"), 2D)), GetIdx(Get(GetIdx(c_2633, 2D), "q"), 2D)), GetIdx(Get(GetIdx(c_2633, 3D), "q"), 2D))) / 4D);
if ((mz_2650 > (ToNum(Call(surf_2520, V.Undef, ((V)(mx_2648)), ((V)(my_2649)))) - 1.5))) {
dF_2524 = Add(dF_2524, d_2636);
}
}
i_2630++;
}
}
j_2628++;
}
}
LS_2525 = Arr(Arr(), Arr(), Arr());
Invoke(Get(K_2505, "sp"), "forEach", Fn((V _self871, int _argc2651, V s_2657, V _a2654, V _a2655, V _a2656, V[] _rest2652) => {
V bc_2658 = default;
V t3_2659 = default;
V q1_2660 = default;
V q2_2661 = default;
V qt_2662 = default;
V f_2663 = default;
double k_2664 = 0;
double wob_2665 = 0;
V A1_2666 = default;
V A2_2667 = default;
V At_2668 = default;
double tx_2669 = 0;
double ty_2670 = 0;
V tl_2671 = default;
V Tp_2672 = default;
double vis_2673 = 0;
V qc_2674 = default;
V front_2675 = default;
bc_2658 = Arr(((V)((ToNum(Add(GetIdx(Get(s_2657, "b1"), 0D), GetIdx(Get(s_2657, "b2"), 0D))) / 2D))), ((V)((ToNum(Add(GetIdx(Get(s_2657, "b1"), 1D), GetIdx(Get(s_2657, "b2"), 1D))) / 2D))), ((V)((ToNum(Add(GetIdx(Get(s_2657, "b1"), 2D), GetIdx(Get(s_2657, "b2"), 2D))) / 2D))));
t3_2659 = Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _self871, int _argc2676, V k_2682, V _a2679, V _a2680, V _a2681, V[] _rest2677) => {
return Add(GetK(bc_2658, k_2682), ((V)(((ToNum(GetK(Get(s_2657, "t"), k_2682)) - ToNum(GetK(bc_2658, k_2682))) * grow_2508))));
}, 1, "", true));
q1_2660 = Call(rot_2516, V.Undef, Get(s_2657, "b1"), Get(s_2657, "hw"));
q2_2661 = Call(rot_2516, V.Undef, Get(s_2657, "b2"), Get(s_2657, "hw"));
qt_2662 = Call(rot_2516, V.Undef, t3_2659, Get(s_2657, "hw"));
f_2663 = Call(fac_2517, V.Undef, Get(s_2657, "n"), Get(s_2657, "hw"));
k_2664 = (ToNum(Get(s_2657, "len")) / 10D);
wob_2665 = ((FdLibm.Sin(((ToNum(now_880) / 520D) + (ToNum(Get(s_2657, "i")) * 1.7))) * 0.25) * k_2664);
A1_2666 = Call(W2_2519, V.Undef, GetIdx(q1_2660, 0D), GetIdx(q1_2660, 1D));
A2_2667 = Call(W2_2519, V.Undef, GetIdx(q2_2661, 0D), GetIdx(q2_2661, 1D));
At_2668 = Call(W2_2519, V.Undef, GetIdx(qt_2662, 0D), GetIdx(qt_2662, 1D));
{
double mx_2683 = 0;
double my_2684 = 0;
double ax_2685 = 0;
double ay_2686 = 0;
V al_2687 = default;
double px_2688 = 0;
double py_2689 = 0;
double hx_2690 = 0;
double hy_2691 = 0;
double dp_2692 = 0;
double need_2693 = 0;
mx_2683 = (ToNum(Add(GetIdx(A1_2666, 0D), GetIdx(A2_2667, 0D))) / 2D);
my_2684 = (ToNum(Add(GetIdx(A1_2666, 1D), GetIdx(A2_2667, 1D))) / 2D);
ax_2685 = (ToNum(GetIdx(At_2668, 0D)) - mx_2683);
ay_2686 = (ToNum(GetIdx(At_2668, 1D)) - my_2684);
al_2687 = (((V)(Hypot(ax_2685, ay_2686))) is var _t2694 && Truthy(_t2694) ? _t2694 : ((V)(1D)));
px_2688 = ((-ay_2686) / ToNum(al_2687));
py_2689 = (ax_2685 / ToNum(al_2687));
hx_2690 = ((ToNum(GetIdx(A2_2667, 0D)) - ToNum(GetIdx(A1_2666, 0D))) / 2D);
hy_2691 = ((ToNum(GetIdx(A2_2667, 1D)) - ToNum(GetIdx(A1_2666, 1D))) / 2D);
dp_2692 = ((hx_2690 * px_2688) + (hy_2691 * py_2689));
need_2693 = ((ToNum(Get(s_2657, "w")) * 0.8) - System.Math.Abs(dp_2692));
if ((need_2693 > 0D)) {
double sg_2695 = 0;
double nx_2696 = 0;
double ny_2697 = 0;
sg_2695 = ((dp_2692 < 0D) ? (-1D) : 1D);
nx_2696 = (hx_2690 + ((px_2688 * need_2693) * sg_2695));
ny_2697 = (hy_2691 + ((py_2689 * need_2693) * sg_2695));
A1_2666 = Arr(((V)((mx_2683 - nx_2696))), ((V)((my_2684 - ny_2697))));
A2_2667 = Arr(((V)((mx_2683 + nx_2696))), ((V)((my_2684 + ny_2697))));
}
}
tx_2669 = (ToNum(GetIdx(A2_2667, 0D)) - ToNum(GetIdx(A1_2666, 0D)));
ty_2670 = (ToNum(GetIdx(A2_2667, 1D)) - ToNum(GetIdx(A1_2666, 1D)));
tl_2671 = (((V)(Hypot(tx_2669, ty_2670))) is var _t2698 && Truthy(_t2698) ? _t2698 : ((V)(1D)));
Tp_2672 = Arr(Add(Add(GetIdx(At_2668, 0D), ((V)(((ToNum(ed_2506) * 0.35) * k_2664)))), ((V)(((tx_2669 / ToNum(tl_2671)) * wob_2665)))), ((V)(((ToNum(GetIdx(At_2668, 1D)) - ((ToNum(ld_2507) * 0.3) * k_2664)) + ((ty_2670 / ToNum(tl_2671)) * wob_2665)))));
vis_2673 = (System.Math.Abs((((ToNum(GetIdx(Tp_2672, 0D)) - ToNum(GetIdx(A1_2666, 0D))) * ty_2670) - ((ToNum(GetIdx(Tp_2672, 1D)) - ToNum(GetIdx(A1_2666, 1D))) * tx_2669))) / (ToNum(tl_2671) * Max(1D, (ToNum(Get(s_2657, "len")) * grow_2508))));
qc_2674 = Arr(((V)((ToNum(Add(GetIdx(q1_2660, 0D), GetIdx(q2_2661, 0D))) / 2D))), ((V)((ToNum(Add(GetIdx(q1_2660, 1D), GetIdx(q2_2661, 1D))) / 2D))), ((V)((ToNum(Add(GetIdx(q1_2660, 2D), GetIdx(q2_2661, 2D))) / 2D))));
front_2675 = ((GtN(f_2663, 0.1) && GtN(GetIdx(qc_2674, 2D), (ToNum(Call(surf_2520, V.Undef, GetIdx(qc_2674, 0D), GetIdx(qc_2674, 1D))) - 1.5))) ? V.True : V.False);
Invoke(GetIdx(LS_2525, (Truthy(front_2675) ? 2D : (LtN(f_2663, (-0.01)) ? 0D : 1D))), "push", Arr(((V)((ToNum(Add(GetIdx(qc_2674, 2D), GetIdx(qt_2662, 2D))) / 2D))), ((V)(string.Concat(new string[] { "M", ToStr(Call(p2s_2518, V.Undef, A1_2666)), " L", ToStr(Call(p2s_2518, V.Undef, Tp_2672)), " L", ToStr(Call(p2s_2518, V.Undef, A2_2667)) }))), Call(r2_14, V.Undef, Call(SM_16, V.Undef, ((V)((vis_2673 * 3D)))))));
return default;
}, 1, "", true));
put_2526 = Fn((V _self871, int _argc2699, V pool_2705, V list_2706, V _a2703, V _a2704, V[] _rest2700) => {
Invoke(list_2706, "sort", Fn((V _self871, int _argc2707, V a_2713, V b_2714, V _a2711, V _a2712, V[] _rest2708) => {
return ((V)((ToNum(GetIdx(a_2713, 0D)) - ToNum(GetIdx(b_2714, 0D)))));
}, 2, "", true));
Invoke(pool_2705, "forEach", Fn((V _self871, int _argc2715, V el_2721, V i_2722, V _a2719, V _a2720, V[] _rest2716) => {
V v_2723 = default;
V d_2724 = default;
V o_2725 = default;
v_2723 = GetK(list_2706, i_2722);
d_2724 = (Truthy(v_2723) ? GetIdx(v_2723, 1D) : ((V)("")));
o_2725 = (Truthy(v_2723) ? GetIdx(v_2723, 2D) : ((V)(1D)));
if (!SEq(Get(el_2721, "_d"), d_2724)) {
Set(el_2721, "_d", d_2724);
Call(set_940, V.Undef, el_2721, ((V)("d")), d_2724);
}
if (!SEq(Get(el_2721, "_o"), o_2725)) {
Set(el_2721, "_o", o_2725);
Call(set_940, V.Undef, el_2721, ((V)("stroke-opacity")), o_2725);
}
return default;
}, 2, "", true));
return default;
}, 2, "", true);
Call(put_2526, V.Undef, Get(Get(E_883, "hog"), "pre"), GetIdx(LS_2525, 0D));
Call(put_2526, V.Undef, Get(Get(E_883, "hog"), "post"), GetIdx(LS_2525, 1D));
Call(put_2526, V.Undef, Get(Get(E_883, "hog"), "fs"), GetIdx(LS_2525, 2D));
Call(set_940, V.Undef, Get(Get(E_883, "hog"), "domeB"), ((V)("d")), dB_2523);
Call(set_940, V.Undef, Get(Get(E_883, "hog"), "domeF"), ((V)("d")), dF_2524);
} else {
if (Truthy((Get(E_883, "mane") is var _t2726 && !Truthy(_t2726) ? _t2726 : Get(R_882, "spk")))) {
V K_2727 = default;
V cx0_2728 = default;
V cy0_2729 = default;
double grow_2730 = 0;
V tris_2731 = default;
double cY_2732 = 0;
double sY_2733 = 0;
V rot_2734 = default;
V pth_2735 = default;
K_2727 = Get(R_882, "spk");
{ V _t2736 = Get(K_2727, "C");
{ V _t2737 = ListOf(_t2736);
{ V _t2738 = GetIdx(_t2737, 0D);
cx0_2728 = _t2738; }
{ V _t2739 = GetIdx(_t2737, 1D);
cy0_2729 = _t2739; }
} }
grow_2730 = (1D + (ToNum(Call(clamp_13, V.Undef, Get(P_879, "wide"), ((V)(0D)), ((V)(1D)))) * 0.12));
tris_2731 = Arr();
cY_2732 = FdLibm.Cos(yh_896);
sY_2733 = FdLibm.Sin(yh_896);
rot_2734 = Fn((V _self871, int _argc2740, V v_2746, V _a2743, V _a2744, V _a2745, V[] _rest2741) => {
double x1_2747 = 0;
double z0_2748 = 0;
x1_2747 = ((ToNum(GetIdx(v_2746, 0D)) * cY_2732) + (ToNum(GetIdx(v_2746, 2D)) * sY_2733));
z0_2748 = (((-ToNum(GetIdx(v_2746, 0D))) * sY_2733) + (ToNum(GetIdx(v_2746, 2D)) * cY_2732));
return Arr(((V)(x1_2747)), ((V)(((ToNum(GetIdx(v_2746, 1D)) * cp_905) - (z0_2748 * sp_906)))), ((V)(((ToNum(GetIdx(v_2746, 1D)) * sp_906) + (z0_2748 * cp_905)))));
return default;
}, 1, "", true);
{
foreach (V _k2749 in Iterate(Get(K_2727, "list"))) {
V q_2750 = default;
q_2750 = _k2749;
double sT_2751 = 0;
double ct2_2752 = 0;
double st2_2753 = 0;
V d_2754 = default;
V tg_2755 = default;
V pr_2756 = default;
sT_2751 = FdLibm.Sin(ToNum(Get(q_2750, "th")));
ct2_2752 = FdLibm.Cos(ToNum(Get(q_2750, "t")));
st2_2753 = FdLibm.Sin(ToNum(Get(q_2750, "t")));
d_2754 = Call(rot_2734, V.Undef, Arr(((V)((sT_2751 * ct2_2752))), ((V)((sT_2751 * st2_2753))), ((V)((-FdLibm.Cos(ToNum(Get(q_2750, "th"))))))));
tg_2755 = Call(rot_2734, V.Undef, (Truthy(Get(q_2750, "th")) ? Arr(((V)((-st2_2753))), ((V)(ct2_2752)), ((V)(0D))) : Arr(((V)(1D)), ((V)(0D)), ((V)(0D)))));
pr_2756 = Fn((V _self871, int _argc2757, V rr_2763, V ww_2764, V _a2761, V _a2762, V[] _rest2758) => {
return Call(headT_924, V.Undef, Add(Add(cx0_2728, ((V)((ToNum(GetIdx(d_2754, 0D)) * ToNum(rr_2763))))), ((V)((ToNum(GetIdx(tg_2755, 0D)) * ToNum(ww_2764))))), Add(Add(cy0_2729, ((V)((ToNum(GetIdx(d_2754, 1D)) * ToNum(rr_2763))))), ((V)((ToNum(GetIdx(tg_2755, 1D)) * ToNum(ww_2764))))));
}, 2, "", true);
Invoke(tris_2731, "push", Arr(GetIdx(d_2754, 2D), Call(pr_2756, V.Undef, ((V)((ToNum(Get(K_2727, "rb")) * 0.9))), Get(K_2727, "w")), Call(pr_2756, V.Undef, ((V)((ToNum(Get(K_2727, "rt")) * grow_2730))), ((V)(0D))), Call(pr_2756, V.Undef, ((V)((ToNum(Get(K_2727, "rb")) * 0.9))), ((V)((-ToNum(Get(K_2727, "w"))))))));
}
}
Invoke(tris_2731, "sort", Fn((V _self871, int _argc2765, V a_2771, V b_2772, V _a2769, V _a2770, V[] _rest2766) => {
return ((V)((ToNum(GetIdx(a_2771, 0D)) - ToNum(GetIdx(b_2772, 0D)))));
}, 2, "", true));
pth_2735 = Fn((V _self871, int _argc2773, V L_2779, V _a2776, V _a2777, V _a2778, V[] _rest2774) => {
return Invoke(Invoke(L_2779, "map", Fn((V _self871, int _argc2780, V _a2782, V _a2783, V _a2784, V _a2785, V[] _rest2781) => {
V z_2788 = default;
V a_2790 = default;
V b_2792 = default;
V c_2794 = default;
{ V _t2786 = ListOf(_a2782);
{ V _t2787 = GetIdx(_t2786, 0D);
z_2788 = _t2787; }
{ V _t2789 = GetIdx(_t2786, 1D);
a_2790 = _t2789; }
{ V _t2791 = GetIdx(_t2786, 2D);
b_2792 = _t2791; }
{ V _t2793 = GetIdx(_t2786, 3D);
c_2794 = _t2793; }
}
return ((V)(string.Concat(new string[] { "M", ToStr(Call(r2_14, V.Undef, GetIdx(a_2790, 0D))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(a_2790, 1D))), " L", ToStr(Call(r2_14, V.Undef, GetIdx(b_2792, 0D))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(b_2792, 1D))), " L", ToStr(Call(r2_14, V.Undef, GetIdx(c_2794, 0D))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(c_2794, 1D))), "Z" })));
}, 1, "", true)), "join", ((V)(" ")));
}, 1, "", true);
Call(set_940, V.Undef, Get(E_883, "mane"), ((V)("d")), Call(pth_2735, V.Undef, Invoke(tris_2731, "filter", Fn((V _self871, int _argc2795, V t_2801, V _a2798, V _a2799, V _a2800, V[] _rest2796) => {
return (LtN(GetIdx(t_2801, 0D), 0.18) ? V.True : V.False);
}, 1, "", true))));
if (Truthy(Get(E_883, "maneF"))) {
Call(set_940, V.Undef, Get(E_883, "maneF"), ((V)("d")), Call(pth_2735, V.Undef, Invoke(tris_2731, "filter", Fn((V _self871, int _argc2802, V t_2808, V _a2805, V _a2806, V _a2807, V[] _rest2803) => {
return (GeN(GetIdx(t_2808, 0D), 0.18) ? V.True : V.False);
}, 1, "", true))));
}
} else {
if (Truthy(Get(E_883, "mane"))) {
double k_2809 = 0;
double rp_2810 = 0;
double tt_2811 = 0;
V HC_2812 = default;
V T_2813 = default;
k_2809 = ((1D + (ToNum(Call(clamp_13, V.Undef, Get(P_879, "wide"), ((V)(0D)), ((V)(1D)))) * 0.1)) + (Max(0D, ToNum(sq_912)) * 0.05));
rp_2810 = (0.025 + (ToNum(Call(clamp_13, V.Undef, Get(P_879, "wide"), ((V)(0D)), ((V)(1D)))) * 0.05));
tt_2811 = (ToNum(now_880) / 260D);
HC_2812 = (Get(Get(D_881, "mane"), "c") is var _t2814 && Truthy(_t2814) ? _t2814 : Arr(HX_886, HY_887));
T_2813 = (SEqS(Get(Get(D_881, "mane"), "mode"), "body") ? glob_918 : headT_924);
Call(set_940, V.Undef, Get(E_883, "mane"), ((V)("d")), Call(toD_25, V.Undef, Get(R_882, "mane"), Fn((V _self871, int _argc2815, V x_2821, V y_2822, V _a2819, V _a2820, V[] _rest2816) => {
double dx_2823 = 0;
double dy_2824 = 0;
double th_2825 = 0;
double m_2826 = 0;
dx_2823 = (ToNum(x_2821) - ToNum(GetIdx(HC_2812, 0D)));
dy_2824 = (ToNum(y_2822) - ToNum(GetIdx(HC_2812, 1D)));
th_2825 = FdLibm.Atan2(dy_2824, dx_2823);
m_2826 = (k_2809 * (1D + ((rp_2810 * ToNum(Call(clamp_13, V.Undef, Get(P_879, "wide"), ((V)(0D)), ((V)(1D))))) * FdLibm.Sin((th_2825 * 7D)))));
return Call(T_2813, V.Undef, Add(GetIdx(HC_2812, 0D), ((V)((dx_2823 * m_2826)))), Add(GetIdx(HC_2812, 1D), ((V)((dy_2824 * m_2826)))));
return default;
}, 2, "", true)));
}
}
}
}
Invoke((Get(E_883, "hx") is var _t2835 && Truthy(_t2835) ? _t2835 : Arr()), "forEach", Fn((V _self871, int _argc2827, V el_2833, V i_2834, V _a2831, V _a2832, V[] _rest2828) => {
return Call(set_940, V.Undef, el_2833, ((V)("d")), Call(toD_25, V.Undef, GetK(Get(R_882, "hx"), i_2834), wrapF_930));
}, 2, "", true));
if (Truthy(Get(Get(E_883, "crown"), "length"))) {
double ang_2836 = 0;
V bx_2837 = default;
V by_2838 = default;
double c_2839 = 0;
double sn_2840 = 0;
ang_2836 = (((((ToNum(Get(P_879, "earR")) - ToNum(Get(P_879, "earL"))) * 0.25) - (ToNum((Get(I_878, "ed") is var _t2841 && Truthy(_t2841) ? _t2841 : ((V)(0D)))) * 2.5)) + (ToNum(Get(P_879, "htilt")) * 0.3)) * D2R_11);
{ V _t2842 = Get(D_881, "crownBase");
{ V _t2843 = ListOf(_t2842);
{ V _t2844 = GetIdx(_t2843, 0D);
bx_2837 = _t2844; }
{ V _t2845 = GetIdx(_t2843, 1D);
by_2838 = _t2845; }
} }
c_2839 = FdLibm.Cos(ang_2836);
sn_2840 = FdLibm.Sin(ang_2836);
Invoke(Get(E_883, "crown"), "forEach", Fn((V _self871, int _argc2846, V el_2852, V i_2853, V _a2850, V _a2851, V[] _rest2847) => {
return Call(set_940, V.Undef, el_2852, ((V)("d")), Call(toD_25, V.Undef, GetK(Get(R_882, "crown"), i_2853), Fn((V _self871, int _argc2854, V x_2860, V y_2861, V _a2858, V _a2859, V[] _rest2855) => {
double vx_2862 = 0;
double vy_2863 = 0;
vx_2862 = (ToNum(x_2860) - ToNum(bx_2837));
vy_2863 = (ToNum(y_2861) - ToNum(by_2838));
return Call(sph_926, V.Undef, ((V)((ToNum(Add(bx_2837, ((V)((vx_2862 * c_2839))))) - (vy_2863 * sn_2840)))), Add(Add(Add(Add(by_2838, ((V)((vx_2862 * sn_2840)))), ((V)((vy_2863 * c_2839)))), ((V)((Min(0D, ToNum(sq_912)) * 2D)))), (Get(D_881, "crownDy") is var _t2864 && Truthy(_t2864) ? _t2864 : ((V)(0D)))), (!Get(D_881, "crownZ").IsNullish ? Get(D_881, "crownZ") : ((V)((-3D)))));
return default;
}, 2, "", true)));
}, 2, "", true));
}
if (Truthy(Get(Get(E_883, "pup"), "length"))) {
V pcx_2865 = default;
V pcy_2866 = default;
V pr_2867 = default;
V BX_2868 = default;
V BY_2869 = default;
V BW_2870 = default;
V BH_2871 = default;
double t_2872 = 0;
double pdt_2873 = 0;
V pj_2874 = default;
double fb_2875 = 0;
double td_2876 = 0;
double tl_2877 = 0;
double ca_2878 = 0;
double sa_2879 = 0;
double sq_2880 = 0;
double bl_2881 = 0;
{ V _t2882 = (Get(D_881, "pupC") is var _t2883 && Truthy(_t2883) ? _t2883 : Arr(((V)(50D)), ((V)(71D)), ((V)(11D))));
{ V _t2884 = ListOf(_t2882);
{ V _t2885 = GetIdx(_t2884, 0D);
pcx_2865 = _t2885; }
{ V _t2886 = GetIdx(_t2884, 1D);
pcy_2866 = _t2886; }
{ V _t2887 = GetIdx(_t2884, 2D);
pr_2867 = _t2887; }
} }
{ V _t2888 = Get(D_881, "body");
{ V _t2889 = ListOf(_t2888);
{ V _t2890 = GetIdx(_t2889, 0D);
BX_2868 = _t2890; }
{ V _t2891 = GetIdx(_t2889, 1D);
BY_2869 = _t2891; }
{ V _t2892 = GetIdx(_t2889, 2D);
BW_2870 = _t2892; }
{ V _t2893 = GetIdx(_t2889, 3D);
BH_2871 = _t2893; }
} }
t_2872 = (ToNum(now_880) / 1000D);
pdt_2873 = (Truthy(Get(I_878, "pjT")) ? Min(0.05, ((ToNum(now_880) - ToNum(Get(I_878, "pjT"))) / 1000D)) : 0.016);
Set(I_878, "pjT", now_880);
Set(I_878, "pj", Add((Get(I_878, "pj") is var _t2894 && Truthy(_t2894) ? _t2894 : ((V)(0D))), ((V)((((Truthy(Invoke(NewRegExp(RX4, "dance", ""), "test", Get(Get(I_878, "cur"), "name"))) ? 1D : 0D) - ToNum((Get(I_878, "pj") is var _t2895 && Truthy(_t2895) ? _t2895 : ((V)(0D))))) * Min(1D, (pdt_2873 * 5D)))))));
pj_2874 = Call(SM_16, V.Undef, Get(I_878, "pj"));
fb_2875 = (ToNum(Add(pcy_2866, pr_2867)) - 1D);
td_2876 = ((((FdLibm.Sin((t_2872 * 1.3)) * 6D) * (1D - ToNum(pj_2874))) + ((FdLibm.Sin(((t_2872 * System.Math.PI) * 2D)) * 9D) * ToNum(pj_2874))) + (ToNum(Call(clamp_13, V.Undef, (Get(I_878, "ed") is var _t2896 && Truthy(_t2896) ? _t2896 : ((V)(0D))), ((V)((-4D))), ((V)(4D)))) * 2D));
tl_2877 = (td_2876 * D2R_11);
ca_2878 = FdLibm.Cos(tl_2877);
sa_2879 = FdLibm.Sin(tl_2877);
sq_2880 = ((((FdLibm.Sin((t_2872 * 2.6)) * 0.03) * (1D - ToNum(pj_2874))) - ((ToNum(Call(clamp_13, V.Undef, (Get(P_879, "sq") is var _t2897 && Truthy(_t2897) ? _t2897 : ((V)(0D))), ((V)((-0.3))), ((V)(0.3)))) * 0.7) * ToNum(pj_2874))) + (ToNum(Call(clamp_13, V.Undef, (Get(I_878, "ld") is var _t2898 && Truthy(_t2898) ? _t2898 : ((V)(0D))), ((V)((-6D))), ((V)(6D)))) * 0.008));
bl_2881 = (((ToNum(now_880) % 3400D) < 150D) ? 0.12 : 1D);
Invoke(Get(E_883, "pup"), "forEach", Fn((V _self871, int _argc2899, V el_2905, V i_2906, V _a2903, V _a2904, V[] _rest2900) => {
V h_2907 = default;
double ea_2908 = 0;
double ec_2909 = 0;
double es_2910 = 0;
double cs_2911 = 0;
h_2907 = GetK(Get(D_881, "pup"), i_2906);
ea_2908 = (Truthy(Get(h_2907, "ear")) ? ((((-ToNum(GetIdx(Get(h_2907, "ear"), 2D))) * (((5D + ((FdLibm.Sin(((t_2872 * 2.6) - 0.9)) * 5D) * (1D - ToNum(pj_2874)))) + ((System.Math.Abs(FdLibm.Sin((((t_2872 * System.Math.PI) * 2D) - 0.6))) * 16D) * ToNum(pj_2874))) + (ToNum(Call(clamp_13, V.Undef, (Get(I_878, "ld") is var _t2912 && Truthy(_t2912) ? _t2912 : ((V)(0D))), ((V)((-6D))), ((V)(6D)))) * 1.2))) * D2R_11) - ((td_2876 * 0.5) * D2R_11)) : 0D);
ec_2909 = FdLibm.Cos(ea_2908);
es_2910 = FdLibm.Sin(ea_2908);
cs_2911 = (Truthy(Get(h_2907, "cheek")) ? (1D + (ToNum(pj_2874) * 0.18)) : 1D);
if (Truthy((((Get(h_2907, "shine") is var _t2913 && Truthy(_t2913) ? _t2913 : Get(h_2907, "mouthLine")) is var _t2914 && Truthy(_t2914) ? _t2914 : Get(h_2907, "joy")) is var _t2915 && Truthy(_t2915) ? _t2915 : Get(h_2907, "cheek")))) {
Call(set_940, V.Undef, el_2905, ((V)("opacity")), Call(r2_14, V.Undef, (Truthy(Get(h_2907, "joy")) ? pj_2874 : ((V)((Truthy(Get(h_2907, "cheek")) ? Min(1D, ToNum(Add((Get(h_2907, "op") is var _t2916 && Truthy(_t2916) ? _t2916 : ((V)(1D))), ((V)((ToNum(pj_2874) * 0.4)))))) : (ToNum((Get(h_2907, "op") is var _t2917 && Truthy(_t2917) ? _t2917 : ((V)(1D)))) * (1D - ToNum(pj_2874)))))))));
}
Call(set_940, V.Undef, el_2905, ((V)("d")), Call(toD_25, V.Undef, GetK(Get(R_882, "pup"), i_2906), Fn((V _self871, int _argc2918, V x_2924, V y_2925, V _a2922, V _a2923, V[] _rest2919) => {
double u0_2926 = 0;
double v0_2927 = 0;
double zp_2928 = 0;
double p_2929 = 0;
double q_2930 = 0;
double dx_2931 = 0;
V v_2932 = default;
double wc_2933 = 0;
double zb_2934 = 0;
if (Truthy(Get(h_2907, "eye"))) {
double dy_2935 = 0;
dy_2935 = (ToNum(y_2925) - ToNum(GetIdx(Get(h_2907, "eye"), 1D)));
y_2925 = ((V)(((ToNum(GetIdx(Get(h_2907, "eye"), 1D)) - (ToNum(pj_2874) * 0.5)) + (dy_2935 * ((dy_2935 > 0D) ? (bl_2881 * (1D - (1.75 * ToNum(pj_2874)))) : bl_2881)))));
}
if (Truthy(Get(h_2907, "joy"))) {
y_2925 = Add(GetIdx(Get(h_2907, "joy"), 1D), ((V)(((ToNum(y_2925) - ToNum(GetIdx(Get(h_2907, "joy"), 1D))) * Max(0.05, ToNum(pj_2874))))));
}
if (Truthy(Get(h_2907, "cheek"))) {
x_2924 = Add(GetIdx(Get(h_2907, "cheek"), 0D), ((V)(((ToNum(x_2924) - ToNum(GetIdx(Get(h_2907, "cheek"), 0D))) * cs_2911))));
y_2925 = Add(GetIdx(Get(h_2907, "cheek"), 1D), ((V)(((ToNum(y_2925) - ToNum(GetIdx(Get(h_2907, "cheek"), 1D))) * cs_2911))));
}
if (Truthy(Get(h_2907, "ear"))) {
double p_2936 = 0;
double q_2937 = 0;
p_2936 = (ToNum(x_2924) - ToNum(GetIdx(Get(h_2907, "ear"), 0D)));
q_2937 = (ToNum(y_2925) - ToNum(GetIdx(Get(h_2907, "ear"), 1D)));
x_2924 = ((V)((ToNum(Add(GetIdx(Get(h_2907, "ear"), 0D), ((V)((p_2936 * ec_2909))))) - (q_2937 * es_2910))));
y_2925 = Add(Add(GetIdx(Get(h_2907, "ear"), 1D), ((V)((p_2936 * es_2910)))), ((V)((q_2937 * ec_2909))));
}
u0_2926 = (ToNum(x_2924) - ToNum(pcx_2865));
v0_2927 = (ToNum(y_2925) - ToNum(pcy_2866));
zp_2928 = ((System.Math.Sqrt(Max(0D, (1D - (((u0_2926 * u0_2926) + (v0_2927 * v0_2927)) / (ToNum(pr_2867) * ToNum(pr_2867)))))) * ToNum(pr_2867)) * 0.5);
x_2924 = Add(pcx_2865, ((V)((u0_2926 * (1D - (sq_2880 * 0.5))))));
y_2925 = ((V)((fb_2875 + ((ToNum(y_2925) - fb_2875) * (1D + sq_2880)))));
p_2929 = (ToNum(x_2924) - ToNum(pcx_2865));
q_2930 = (ToNum(y_2925) - fb_2875);
x_2924 = ((V)((ToNum(Add(pcx_2865, ((V)((p_2929 * ca_2878))))) - (q_2930 * sa_2879))));
y_2925 = ((V)(((fb_2875 + (p_2929 * sa_2879)) + (q_2930 * ca_2878))));
dx_2931 = (ToNum(x_2924) - ToNum(BX_2868));
v_2932 = Call(clamp_13, V.Undef, ((V)(((ToNum(y_2925) - ToNum(BY_2869)) / ToNum(BH_2871)))), ((V)((-1D))), ((V)(1D)));
wc_2933 = (ToNum(BW_2870) * System.Math.Sqrt((1D - ((ToNum(v_2932) * ToNum(v_2932)) * 0.36))));
zb_2934 = System.Math.Sqrt(Max(0D, ((wc_2933 * wc_2933) - (dx_2931 * dx_2931))));
return Call(glob_918, V.Undef, Add(Add(BX_2868, ((V)((dx_2931 * cyb_901)))), ((V)(((zb_2934 + zp_2928) * syb_902)))), y_2925);
return default;
}, 2, "", true)));
return default;
}, 2, "", true));
Call(set_940, V.Undef, Get(Get(I_878, "pg"), "pup"), ((V)("opacity")), Call(r2_14, V.Undef, Call(SM_16, V.Undef, ((V)(((cyb_901 + 0.15) / 0.35))))));
}
if (Truthy(Get(E_883, "cr"))) {
V C_2938 = default;
V Q_2939 = default;
double N_2940 = 0;
V W_2941 = default;
V ty_2942 = default;
V keys2_2943 = default;
V RB_2944 = default;
V rS_2945 = default;
V pt_2946 = default;
V dep_2947 = default;
V P2_2948 = default;
V hx_2949 = default;
V cD_2950 = default;
V cB_2951 = default;
V cL_2952 = default;
V mix_2953 = default;
V vis_2954 = default;
double k0_2955 = 0;
V run_2956 = default;
V line_2957 = default;
Call(set_940, V.Undef, GetIdx(Get(Get(E_883, "cr"), "mk"), 0D), ((V)("d")), Invoke(Get(E_883, "body"), "getAttribute", ((V)("d"))));
Call(set_940, V.Undef, GetIdx(Get(Get(E_883, "cr"), "mk"), 1D), ((V)("d")), skD_943);
C_2938 = Get(Get(D_881, "collar"), "ring");
Q_2939 = Get(E_883, "cr");
N_2940 = 48D;
W_2941 = Get(C_2938, "w");
ty_2942 = Fn((V _self871, int _argc2958, V t_2964, V _a2961, V _a2962, V _a2963, V[] _rest2959) => {
double c_2965 = 0;
c_2965 = FdLibm.Cos(ToNum(t_2964));
return Add(Get(C_2938, "ys"), ((V)(((ToNum(((c_2965 >= 0D) ? Get(C_2938, "af") : Get(C_2938, "ab"))) * c_2965) * c_2965))));
return default;
}, 1, "", true);
keys2_2943 = keys_946;
Set(keys2_2943, "collar", ((V)(1.5)));
RB_2944 = Get(D_881, "body");
rS_2945 = Fn((V _self871, int _argc2966, V y_2972, V _a2969, V _a2970, V _a2971, V[] _rest2967) => {
double a_2973 = 0;
double b_2974 = 0;
a_2973 = ((ToNum(y_2972) - ToNum(HY_887)) / ToNum(SRY_891));
b_2974 = ((ToNum(y_2972) - ToNum(GetIdx(RB_2944, 1D))) / ToNum(GetIdx(RB_2944, 3D)));
return Add(((V)(Max((((a_2973 * a_2973) < 1D) ? (ToNum(SR_889) * System.Math.Sqrt((1D - (a_2973 * a_2973)))) : 0D), (((b_2974 * b_2974) < 1D) ? (ToNum(GetIdx(RB_2944, 2D)) * System.Math.Sqrt((1D - (b_2974 * b_2974)))) : 0D)))), (Get(C_2938, "pad") is var _t2975 && Truthy(_t2975) ? _t2975 : ((V)(0.25))));
return default;
}, 1, "", true);
pt_2946 = Fn((V _self871, int _argc2976, V t_2982, V dy_2983, V _a2980, V _a2981, V[] _rest2977) => {
V y_2984 = default;
V r_2985 = default;
y_2984 = Add(Call(ty_2942, V.Undef, t_2982), dy_2983);
r_2985 = Call(rS_2945, V.Undef, y_2984);
return Call(byw_938, V.Undef, ((V)((50D + (ToNum(r_2985) * FdLibm.Sin(ToNum(t_2982)))))), y_2984, ((V)((ToNum(r_2985) * FdLibm.Cos(ToNum(t_2982))))));
return default;
}, 2, "", true);
dep_2947 = Fn((V _self871, int _argc2986, V t_2992, V _a2989, V _a2990, V _a2991, V[] _rest2987) => {
return ((V)(((((-ToNum(Get(C_2938, "rx"))) * FdLibm.Sin(ToNum(t_2992))) * syb_902) + ((ToNum(Get(C_2938, "rz")) * FdLibm.Cos(ToNum(t_2992))) * cyb_901))));
}, 1, "", true);
P2_2948 = Fn((V _self871, int _argc2993, V q_2999, V _a2996, V _a2997, V _a2998, V[] _rest2994) => {
return ((V)(string.Concat(ToStr(Call(r2_14, V.Undef, GetIdx(q_2999, 0D))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(q_2999, 1D))))));
}, 1, "", true);
hx_2949 = Fn((V _self871, int _argc3000, V c_3006, V _a3003, V _a3004, V _a3005, V[] _rest3001) => {
return Arr(((V)(ParseInt(Invoke(c_3006, "slice", ((V)(1D)), ((V)(3D))), ((V)(16D))))), ((V)(ParseInt(Invoke(c_3006, "slice", ((V)(3D)), ((V)(5D))), ((V)(16D))))), ((V)(ParseInt(Invoke(c_3006, "slice", ((V)(5D)), ((V)(7D))), ((V)(16D))))));
}, 1, "", true);
cD_2950 = Call(hx_2949, V.Undef, Get(C_2938, "dark"));
cB_2951 = Call(hx_2949, V.Undef, Get(Get(D_881, "collar"), "fill"));
cL_2952 = Call(hx_2949, V.Undef, Get(C_2938, "light"));
mix_2953 = Fn((V _self871, int _argc3007, V a_3013, V b_3014, V f_3015, V _a3012, V[] _rest3008) => {
return Invoke(a_3013, "map", Fn((V _self871, int _argc3016, V v_3022, V i_3023, V _a3020, V _a3021, V[] _rest3017) => {
return ((V)(Round(ToNum(Add(v_3022, ((V)(((ToNum(GetK(b_3014, i_3023)) - ToNum(v_3022)) * ToNum(f_3015)))))))));
}, 2, "", true));
}, 3, "", true);
vis_2954 = Arr();
{
double i_3024 = 0;
i_3024 = 0D;
while (true) {
if (!((i_3024 < N_2940))) break;
double t0_3026 = 0;
double t1_3027 = 0;
double tm_3028 = 0;
V seg_3029 = default;
double nx_3030 = 0;
double nz_3031 = 0;
V lam_3032 = default;
V col_3033 = default;
V cs_3034 = default;
t0_3026 = ((i_3024 / N_2940) * TAU_12);
t1_3027 = (((i_3024 + 1D) / N_2940) * TAU_12);
tm_3028 = ((t0_3026 + t1_3027) / 2D);
seg_3029 = GetIdx(Get(Q_2939, "segs"), i_3024);
if (LeN(Call(dep_2947, V.Undef, ((V)(tm_3028))), 0D)) {
Invoke(seg_3029, "setAttribute", ((V)("d")), ((V)("")));
goto _cont3025;
}
Invoke(vis_2954, "push", ((V)(i_3024)));
nx_3030 = ((FdLibm.Sin(tm_3028) * cyb_901) + (FdLibm.Cos(tm_3028) * syb_902));
nz_3031 = (((-FdLibm.Sin(tm_3028)) * syb_902) + (FdLibm.Cos(tm_3028) * cyb_901));
lam_3032 = Call(clamp_13, V.Undef, ((V)(((((-0.42) * nx_3030) + (0.9 * nz_3031)) / 0.993))), ((V)(0D)), ((V)(1D)));
col_3033 = (LtN(lam_3032, 0.6) ? Call(mix_2953, V.Undef, cD_2950, cB_2951, ((V)((ToNum(lam_3032) / 0.6)))) : Call(mix_2953, V.Undef, cB_2951, cL_2952, ((V)((((ToNum(lam_3032) - 0.6) / 0.4) * 0.45)))));
cs_3034 = ((V)(string.Concat("rgb(", ToStr(Invoke(col_3033, "join", ((V)(",")))), ")")));
Call(set_940, V.Undef, seg_3029, ((V)("d")), ((V)(string.Concat("M", ToStr(Invoke(Invoke(Arr(Call(pt_2946, V.Undef, ((V)(t0_3026)), ((V)(0D))), Call(pt_2946, V.Undef, ((V)(t1_3027)), ((V)(0D))), Call(pt_2946, V.Undef, ((V)(t1_3027)), W_2941), Call(pt_2946, V.Undef, ((V)(t0_3026)), W_2941)), "map", P2_2948), "join", ((V)("L")))), "Z"))));
Call(set_940, V.Undef, seg_3029, ((V)("fill")), cs_3034);
Call(set_940, V.Undef, seg_3029, ((V)("stroke")), cs_3034);
_cont3025: ;
i_3024++;
}
}
k0_2955 = 0D;
{
double j_3035 = 0;
j_3035 = 0D;
while (true) {
if (!(Lt(((V)(j_3035)), Get(vis_2954, "length")))) break;
if (!SEqN(GetIdx(vis_2954, ((ToNum(Add(((V)(j_3035)), Get(vis_2954, "length"))) - 1D) % ToNum(Get(vis_2954, "length")))), ((ToNum(Add(GetIdx(vis_2954, j_3035), ((V)(N_2940)))) - 1D) % N_2940))) {
k0_2955 = j_3035;
break;
}
j_3035++;
}
}
run_2956 = Invoke(Invoke(vis_2954, "slice", ((V)(k0_2955))), "concat", Invoke(vis_2954, "slice", ((V)(0D)), ((V)(k0_2955))));
line_2957 = Fn((V _self871, int _argc3037, V dy_3043, V _a3040, V _a3041, V _a3042, V[] _rest3038) => {
return ((V)((Truthy(Get(run_2956, "length")) ? string.Concat("M", ToStr(Invoke(Invoke(Invoke(run_2956, "map", Fn((V _self871, int _argc3044, V i_3050, V _a3047, V _a3048, V _a3049, V[] _rest3045) => {
return Call(P2_2948, V.Undef, Call(pt_2946, V.Undef, ((V)(((ToNum(i_3050) / N_2940) * TAU_12))), dy_3043));
}, 1, "", true)), "concat", Arr(Call(P2_2948, V.Undef, Call(pt_2946, V.Undef, ((V)(((ToNum(Add(GetIdx(run_2956, (ToNum(Get(run_2956, "length")) - 1D)), ((V)(1D)))) / N_2940) * TAU_12))), dy_3043)))), "join", ((V)("L"))))) : "")));
}, 1, "", true);
Call(set_940, V.Undef, Get(Q_2939, "sh"), ((V)("d")), Call(line_2957, V.Undef, Add(W_2941, ((V)(0.7)))));
Call(set_940, V.Undef, Get(Q_2939, "hl"), ((V)("d")), Call(line_2957, V.Undef, ((V)(0.45))));
Call(set_940, V.Undef, Get(Q_2939, "lo"), ((V)("d")), Call(line_2957, V.Undef, ((V)((ToNum(W_2941) - 0.35)))));
Call(set_940, V.Undef, Get(Q_2939, "st"), ((V)("d")), Call(line_2957, V.Undef, ((V)((ToNum(W_2941) * 0.5)))));
{
V db_3051 = default;
V o_3052 = default;
double d1_3053 = 0;
double d2_3054 = 0;
V Bq_3055 = default;
db_3051 = Call(dep_2947, V.Undef, ((V)(System.Math.PI)));
o_3052 = Call(SM_16, V.Undef, ((V)(((ToNum(db_3051) - 5D) / 5D))));
d1_3053 = (2.4 / ToNum(Get(C_2938, "rz")));
d2_3054 = (1.25 / ToNum(Get(C_2938, "rz")));
Bq_3055 = Fn((V _self871, int _argc3056, V a_3062, V y0_3063, V y1_3064, V _a3061, V[] _rest3057) => {
return ((V)(string.Concat("M", ToStr(Invoke(Invoke(Arr(Call(pt_2946, V.Undef, ((V)((System.Math.PI - ToNum(a_3062)))), y0_3063), Call(pt_2946, V.Undef, Add(((V)(System.Math.PI)), a_3062), y0_3063), Call(pt_2946, V.Undef, Add(((V)(System.Math.PI)), a_3062), y1_3064), Call(pt_2946, V.Undef, ((V)((System.Math.PI - ToNum(a_3062)))), y1_3064)), "map", P2_2948), "join", ((V)("L")))), "Z")));
}, 3, "", true);
if (GtN(o_3052, 0.01)) {
Call(set_940, V.Undef, Get(Q_2939, "bk"), ((V)("d")), Call(Bq_3055, V.Undef, ((V)(d1_3053)), ((V)((-0.9))), Add(W_2941, ((V)(0.9)))));
Call(set_940, V.Undef, Get(Q_2939, "bki"), ((V)("d")), Call(Bq_3055, V.Undef, ((V)(d2_3054)), ((V)(0.25)), ((V)((ToNum(W_2941) - 0.25)))));
Call(set_940, V.Undef, Get(Q_2939, "bkp"), ((V)("d")), ((V)(string.Concat("M", ToStr(Call(P2_2948, V.Undef, Call(pt_2946, V.Undef, ((V)((System.Math.PI - d2_3054))), ((V)((ToNum(W_2941) / 2D)))))), "L", ToStr(Call(P2_2948, V.Undef, Call(pt_2946, V.Undef, ((V)((System.Math.PI + (d1_3053 * 0.15)))), ((V)((ToNum(W_2941) / 2D))))))))));
} else {
Invoke(Arr(((V)("bk")), ((V)("bki")), ((V)("bkp"))), "forEach", Fn((V _self871, int _argc3065, V k_3071, V _a3068, V _a3069, V _a3070, V[] _rest3066) => {
return Call(set_940, V.Undef, GetK(Q_2939, k_3071), ((V)("d")), ((V)("")));
}, 1, "", true));
}
Invoke(Arr(((V)("bk")), ((V)("bki")), ((V)("bkp"))), "forEach", Fn((V _self871, int _argc3072, V k_3078, V _a3075, V _a3076, V _a3077, V[] _rest3073) => {
return Call(set_940, V.Undef, GetK(Q_2939, k_3078), ((V)("opacity")), Call(r2_14, V.Undef, o_3052));
}, 1, "", true));
}
{
V T_3079 = default;
V A_3080 = default;
V df_3081 = default;
V o_3082 = default;
V G2_3083 = default;
V dt_3084 = default;
double vx_3085 = 0;
double vy_3086 = 0;
V ax_3087 = default;
V ay_3088 = default;
V Lh_3089 = default;
double g_3090 = 0;
V a_3091 = default;
V rc_3092 = default;
V tc_3093 = default;
double fx_3094 = 0;
V rot_3095 = default;
T_3079 = Get(D_881, "tag");
A_3080 = Call(pt_2946, V.Undef, ((V)(0D)), Add(W_2941, ((V)(0.2))));
df_3081 = Call(dep_2947, V.Undef, ((V)(0D)));
o_3082 = Call(SM_16, V.Undef, ((V)(((cyb_901 + 0.06) / 0.16))));
G2_3083 = (Get(I_878, "tgp") is var _t3096 && Truthy(_t3096) ? _t3096 : Set(I_878, "tgp", NewObj(7).Put("a", ((V)(0D))).Put("v", ((V)(0D))).Put("x", GetIdx(A_3080, 0D)).Put("y", GetIdx(A_3080, 1D)).Put("vx", ((V)(0D))).Put("vy", ((V)(0D))).Put("t", now_880).V));
dt_3084 = Call(clamp_13, V.Undef, ((V)(((ToNum(now_880) - ToNum(Get(G2_3083, "t"))) / 1000D))), ((V)(0.001)), ((V)(0.05)));
vx_3085 = ((ToNum(GetIdx(A_3080, 0D)) - ToNum(Get(G2_3083, "x"))) / ToNum(dt_3084));
vy_3086 = ((ToNum(GetIdx(A_3080, 1D)) - ToNum(Get(G2_3083, "y"))) / ToNum(dt_3084));
ax_3087 = Call(clamp_13, V.Undef, ((V)(((vx_3085 - ToNum(Get(G2_3083, "vx"))) / ToNum(dt_3084)))), ((V)((-4000D))), ((V)(4000D)));
ay_3088 = Call(clamp_13, V.Undef, ((V)(((vy_3086 - ToNum(Get(G2_3083, "vy"))) / ToNum(dt_3084)))), ((V)((-4000D))), ((V)(4000D)));
Lh_3089 = Add(Get(T_3079, "r"), ((V)(1.7)));
g_3090 = 700D;
OpSet(G2_3083, "v", 0, ((V)(((((((-(g_3090 - ToNum(ay_3088))) / ToNum(Lh_3089)) * FdLibm.Sin(ToNum(Get(G2_3083, "a")))) - ((ToNum(ax_3087) / ToNum(Lh_3089)) * FdLibm.Cos(ToNum(Get(G2_3083, "a"))))) - (3.2 * ToNum(Get(G2_3083, "v")))) * ToNum(dt_3084)))));
Set(G2_3083, "a", Call(clamp_13, V.Undef, Add(Get(G2_3083, "a"), ((V)((ToNum(Get(G2_3083, "v")) * ToNum(dt_3084))))), ((V)((-0.95))), ((V)(0.95))));
Set(G2_3083, "x", GetIdx(A_3080, 0D));
Set(G2_3083, "y", GetIdx(A_3080, 1D));
Set(G2_3083, "vx", ((V)(vx_3085)));
Set(G2_3083, "vy", ((V)(vy_3086)));
Set(G2_3083, "t", now_880);
a_3091 = Add(Get(G2_3083, "a"), ((V)((FdLibm.Sin((ToNum(now_880) / 900D)) * 0.035))));
rc_3092 = Arr(Add(GetIdx(A_3080, 0D), ((V)((FdLibm.Sin(ToNum(a_3091)) * 1.1)))), Add(GetIdx(A_3080, 1D), ((V)((FdLibm.Cos(ToNum(a_3091)) * 1.1)))));
tc_3093 = Arr(Add(GetIdx(A_3080, 0D), ((V)((FdLibm.Sin(ToNum(a_3091)) * ToNum(Lh_3089))))), Add(GetIdx(A_3080, 1D), ((V)((FdLibm.Cos(ToNum(a_3091)) * ToNum(Lh_3089))))));
fx_3094 = (0.22 + (0.78 * System.Math.Abs(cyb_901)));
rot_3095 = ((V)(string.Concat(new string[] { "rotate(", ToStr(Call(r2_14, V.Undef, ((V)(((-ToNum(a_3091)) / D2R_11))))), " ", ToStr(Invoke(Call(P2_2948, V.Undef, tc_3093), "replace", ((V)(" ")), ((V)(" ")))), ")" })));
Call(set_940, V.Undef, Get(Q_2939, "rg"), ((V)("cx")), Call(r2_14, V.Undef, GetIdx(rc_3092, 0D)));
Call(set_940, V.Undef, Get(Q_2939, "rg"), ((V)("cy")), Call(r2_14, V.Undef, GetIdx(rc_3092, 1D)));
Call(set_940, V.Undef, Get(Q_2939, "rg"), ((V)("rx")), Call(r2_14, V.Undef, ((V)((1.05 * fx_3094)))));
Call(set_940, V.Undef, Get(Q_2939, "rg"), ((V)("ry")), ((V)(1.05)));
Invoke(Arr(Arr(Get(Q_2939, "tg"), ((V)(1D))), Arr(Get(Q_2939, "ti"), ((V)(0.62)))), "forEach", Fn((V _self871, int _argc3097, V _a3099, V _a3100, V _a3101, V _a3102, V[] _rest3098) => {
V e_3105 = default;
V k_3107 = default;
{ V _t3103 = ListOf(_a3099);
{ V _t3104 = GetIdx(_t3103, 0D);
e_3105 = _t3104; }
{ V _t3106 = GetIdx(_t3103, 1D);
k_3107 = _t3106; }
}
Call(set_940, V.Undef, e_3105, ((V)("cx")), Call(r2_14, V.Undef, GetIdx(tc_3093, 0D)));
Call(set_940, V.Undef, e_3105, ((V)("cy")), Call(r2_14, V.Undef, GetIdx(tc_3093, 1D)));
Call(set_940, V.Undef, e_3105, ((V)("rx")), Call(r2_14, V.Undef, ((V)(((ToNum(Get(T_3079, "r")) * ToNum(k_3107)) * fx_3094)))));
Call(set_940, V.Undef, e_3105, ((V)("ry")), Call(r2_14, V.Undef, ((V)((ToNum(Get(T_3079, "r")) * ToNum(k_3107))))));
Call(set_940, V.Undef, e_3105, ((V)("transform")), rot_3095);
return default;
}, 1, "", true));
Call(set_940, V.Undef, Get(Q_2939, "gl"), ((V)("cx")), Call(r2_14, V.Undef, ((V)((ToNum(GetIdx(tc_3093, 0D)) - ((ToNum(Get(T_3079, "r")) * 0.38) * fx_3094))))));
Call(set_940, V.Undef, Get(Q_2939, "gl"), ((V)("cy")), Call(r2_14, V.Undef, ((V)((ToNum(GetIdx(tc_3093, 1D)) - (ToNum(Get(T_3079, "r")) * 0.42))))));
Call(set_940, V.Undef, Get(Q_2939, "gl"), ((V)("rx")), Call(r2_14, V.Undef, ((V)(((ToNum(Get(T_3079, "r")) * 0.3) * fx_3094)))));
Call(set_940, V.Undef, Get(Q_2939, "gl"), ((V)("ry")), Call(r2_14, V.Undef, ((V)((ToNum(Get(T_3079, "r")) * 0.2)))));
Call(set_940, V.Undef, Get(Q_2939, "gl"), ((V)("transform")), rot_3095);
Invoke(Arr(Get(Q_2939, "rg"), Get(Q_2939, "tg"), Get(Q_2939, "ti")), "forEach", Fn((V _self871, int _argc3108, V e_3114, V _a3111, V _a3112, V _a3113, V[] _rest3109) => {
return Call(set_940, V.Undef, e_3114, ((V)("opacity")), Call(r2_14, V.Undef, o_3082));
}, 1, "", true));
Call(set_940, V.Undef, Get(Q_2939, "gl"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ToNum(o_3082) * 0.75)))));
}
}
if (Truthy(Get(E_883, "collar"))) {
if (Truthy(Get(Get(D_881, "collar"), "head"))) {
V T_3115 = default;
double fa_3116 = 0;
double ca_3117 = 0;
double sa_3118 = 0;
double fl_3119 = 0;
T_3115 = (Get(D_881, "tag") is var _t3120 && Truthy(_t3120) ? _t3120 : NewObj(2).Put("x", ((V)(50D))).Put("y", ((V)(66D))).V);
fa_3116 = (((((((-ToNum((Get(I_878, "ed") is var _t3121 && Truthy(_t3121) ? _t3121 : ((V)(0D))))) * 4D) + (ToNum(Get(P_879, "lean")) * 1.5)) + (ToNum(Get(P_879, "htilt")) * 0.4)) - (ToNum((Get(I_878, "ld") is var _t3122 && Truthy(_t3122) ? _t3122 : ((V)(0D)))) * 1.2)) + (FdLibm.Sin((ToNum(now_880) / 520D)) * 2D)) * D2R_11);
ca_3117 = FdLibm.Cos(fa_3116);
sa_3118 = FdLibm.Sin(fa_3116);
fl_3119 = ((1D + (FdLibm.Sin((ToNum(now_880) / 430D)) * 0.05)) + (ToNum(Call(clamp_13, V.Undef, (Get(I_878, "ld") is var _t3123 && Truthy(_t3123) ? _t3123 : ((V)(0D))), ((V)((-10D))), ((V)(10D)))) * 0.012));
Call(set_940, V.Undef, Get(E_883, "collar"), ((V)("d")), Call(toD_25, V.Undef, Get(R_882, "collar"), Fn((V _self871, int _argc3124, V x_3130, V y_3131, V _a3128, V _a3129, V[] _rest3125) => {
double u_3132 = 0;
double v_3133 = 0;
u_3132 = ((ToNum(x_3130) - ToNum(Get(T_3115, "x"))) * fl_3119);
v_3133 = (ToNum(y_3131) - ToNum(Get(T_3115, "y")));
return Call(face_928, V.Undef, ((V)((ToNum(Add(Get(T_3115, "x"), ((V)((u_3132 * ca_3117))))) - (v_3133 * sa_3118)))), Add(Add(Get(T_3115, "y"), ((V)((u_3132 * sa_3118)))), ((V)((v_3133 * ca_3117)))));
return default;
}, 2, "", true)));
Call(set_940, V.Undef, Get(E_883, "collar"), ((V)("opacity")), Call(r2_14, V.Undef, Call(zc_932, V.Undef, Get(T_3115, "x"), Get(T_3115, "y"))));
} else {
if (Truthy(Get(Get(D_881, "collar"), "body"))) {
V T_3134 = default;
V cz_3135 = default;
double fa_3136 = 0;
double ca_3137 = 0;
double sa_3138 = 0;
double fl_3139 = 0;
T_3134 = Get(D_881, "tag");
cz_3135 = (Get(Get(D_881, "collar"), "z") is var _t3140 && Truthy(_t3140) ? _t3140 : ((V)(14D)));
fa_3136 = ((((FdLibm.Sin((ToNum(now_880) / 520D)) * 3D) + (ToNum(Get(P_879, "lean")) * 1.5)) - (ToNum((Get(I_878, "ld") is var _t3141 && Truthy(_t3141) ? _t3141 : ((V)(0D)))) * 1.2)) * D2R_11);
ca_3137 = FdLibm.Cos(fa_3136);
sa_3138 = FdLibm.Sin(fa_3136);
fl_3139 = (1D + (FdLibm.Sin((ToNum(now_880) / 430D)) * 0.05));
Call(set_940, V.Undef, Get(E_883, "collar"), ((V)("d")), Call(toD_25, V.Undef, Get(R_882, "collar"), Fn((V _self871, int _argc3142, V x_3148, V y_3149, V _a3146, V _a3147, V[] _rest3143) => {
double u_3150 = 0;
double v_3151 = 0;
u_3150 = ((ToNum(x_3148) - ToNum(Get(T_3134, "x"))) * fl_3139);
v_3151 = (ToNum(y_3149) - ToNum(Get(T_3134, "y")));
return Call(byw_938, V.Undef, ((V)((ToNum(Add(Get(T_3134, "x"), ((V)((u_3150 * ca_3137))))) - (v_3151 * sa_3138)))), Add(Add(Get(T_3134, "y"), ((V)((u_3150 * sa_3138)))), ((V)((v_3151 * ca_3137)))), cz_3135);
return default;
}, 2, "", true)));
Call(set_940, V.Undef, Get(E_883, "collar"), ((V)("opacity")), Call(r2_14, V.Undef, Call(SM_16, V.Undef, ((V)((ToNum(Call(bywZ_939, V.Undef, Get(T_3134, "x"), cz_3135)) / 4D))))));
} else {
Call(set_940, V.Undef, Get(E_883, "collar"), ((V)("d")), Call(toD_25, V.Undef, Get(R_882, "collar"), glob_918));
}
}
}
if (Truthy((Get(E_883, "tag") is var _t3152 && !Truthy(_t3152) ? _t3152 : Get(Get(D_881, "collar"), "head")))) {
V T_3153 = default;
T_3153 = Get(D_881, "tag");
Call(set_940, V.Undef, Get(E_883, "tag"), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, Get(T_3153, "x"), Get(T_3153, "y"), Get(T_3153, "r"), Get(T_3153, "r"), ((V)(0D)), ((V)(8D))), face_928));
Call(set_940, V.Undef, Get(E_883, "tag"), ((V)("opacity")), Call(r2_14, V.Undef, Call(zc_932, V.Undef, Get(T_3153, "x"), Get(T_3153, "y"))));
} else {
if (Truthy((Get(E_883, "tag") is var _t3154 && !Truthy(_t3154) ? _t3154 : Get(Get(D_881, "collar"), "body")))) {
V T_3155 = default;
V cz_3156 = default;
T_3155 = Get(D_881, "tag");
cz_3156 = Add((Get(Get(D_881, "collar"), "z") is var _t3157 && Truthy(_t3157) ? _t3157 : ((V)(14D))), ((V)(0.5)));
Call(set_940, V.Undef, Get(E_883, "tag"), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, Get(T_3155, "x"), Get(T_3155, "y"), Get(T_3155, "r"), Get(T_3155, "r"), ((V)(0D)), ((V)(8D))), Fn((V _self871, int _argc3158, V x_3164, V y_3165, V _a3162, V _a3163, V[] _rest3159) => {
return Call(byw_938, V.Undef, x_3164, y_3165, cz_3156);
}, 2, "", true)));
Call(set_940, V.Undef, Get(E_883, "tag"), ((V)("opacity")), Call(r2_14, V.Undef, Call(SM_16, V.Undef, ((V)((ToNum(Call(bywZ_939, V.Undef, Get(T_3155, "x"), cz_3156)) / 4D))))));
} else {
if (Truthy(Get(E_883, "tag"))) {
V T_3166 = default;
double sw_3167 = 0;
double cz_3168 = 0;
V tx_3169 = default;
V ty_3170 = default;
double X_3171 = 0;
T_3166 = Get(D_881, "tag");
sw_3167 = ((((((-ToNum((Get(I_878, "ed") is var _t3172 && Truthy(_t3172) ? _t3172 : ((V)(0D))))) * 6D) + (FdLibm.Sin((ToNum(now_880) / 360D)) * 4D)) + (ToNum(Get(P_879, "lean")) * 2D)) - (ToNum((Get(I_878, "ld") is var _t3173 && Truthy(_t3173) ? _t3173 : ((V)(0D)))) * 1.5)) * D2R_11);
cz_3168 = 13D;
tx_3169 = Add(Get(T_3166, "x"), ((V)(((FdLibm.Sin(sw_3167) * ToNum(Get(T_3166, "r"))) * 1.2))));
ty_3170 = Add(Get(T_3166, "y"), ((V)(((FdLibm.Cos(sw_3167) - 1D) * ToNum(Get(T_3166, "r"))))));
X_3171 = ((50D + ((ToNum(tx_3169) - 50D) * cyb_901)) + (cz_3168 * syb_902));
Call(set_940, V.Undef, Get(E_883, "tag"), ((V)("d")), Call(toD_25, V.Undef, Call(ellS_22, V.Undef, ((V)(X_3171)), ty_3170, ((V)((ToNum(Get(T_3166, "r")) * (0.75 + (0.25 * System.Math.Abs(cyb_901)))))), Get(T_3166, "r"), ((V)(0D)), ((V)(8D))), glob_918));
Call(set_940, V.Undef, Get(E_883, "tag"), ((V)("opacity")), Call(r2_14, V.Undef, Call(SM_16, V.Undef, ((V)(((((-(ToNum(tx_3169) - 50D)) * syb_902) + (cz_3168 * cyb_901)) / 4D))))));
}
}
}
Set(I_878, "topW", Call(headT_924, V.Undef, ((V)(50D)), Get(D_881, "top")));
Set(Get(I_878, "W"), "head", Get(I_878, "topW"));
gl_961 = Max(0D, ToNum(Get(P_879, "lift")));
Call(set_940, V.Undef, Get(I_878, "shadow"), ((V)("cx")), Call(r2_14, V.Undef, Add(Add(((V)(50D)), Get(P_879, "x")), ((V)((ToNum(Get(P_879, "lean")) * 0.15))))));
Call(set_940, V.Undef, Get(I_878, "shadow"), ((V)("cy")), Call(r2_14, V.Undef, Add(G_884, ((V)(0.6)))));
Call(set_940, V.Undef, Get(I_878, "shadow"), ((V)("rx")), Call(r2_14, V.Undef, ((V)(((25D * (1D + (ToNum(sq_912) * 0.45))) * (1D - (gl_961 / 70D)))))));
Call(set_940, V.Undef, Get(I_878, "shadow"), ((V)("ry")), Call(r2_14, V.Undef, ((V)((3.6 * (1D - (gl_961 / 90D)))))));
Call(set_940, V.Undef, Get(I_878, "shadow"), ((V)("opacity")), Call(r2_14, V.Undef, ((V)((((0.2 * ToNum((Truthy((Get(I_878, "lt") is var _t3175 && !Truthy(_t3175) ? _t3175 : Get(Get(I_878, "lt"), "L"))) ? (Get(Get(Get(I_878, "lt"), "L"), "contact") is var _t3174 && Truthy(_t3174) ? _t3174 : ((V)(1D))) : ((V)(1D))))) * (1D - (gl_961 / 50D))) * (1D - ToNum(Call(clamp_13, V.Undef, (Get(P_879, "dbb") is var _t3176 && Truthy(_t3176) ? _t3176 : ((V)(0D))), ((V)(0D)), ((V)(1D))))))))));
if (Truthy(Get(I_878, "lt"))) {
Call(litTick_94, V.Undef, I_878, P_879, G_884, sq_912, ((V)(gl_961)));
}
if (Truthy((Get(I_878, "propArm") is var _t3177 && !Truthy(_t3177) ? _t3177 : (!GetK(keys_946, Get(I_878, "propArm")).IsNullish ? V.True : V.False)))) {
Set(keys_946, "prop", Add(GetK(keys_946, Get(I_878, "propArm")), (!Get(I_878, "propK").IsNullish ? Get(I_878, "propK") : ((V)(0.3)))));
}
order_962 = Invoke(Object_keys(keys_946), "sort", Fn((V _self871, int _argc3178, V a_3184, V b_3185, V _a3182, V _a3183, V[] _rest3179) => {
return ((V)((ToNum(GetK(keys_946, a_3184)) - ToNum(GetK(keys_946, b_3185)))));
}, 2, "", true));
os_963 = Invoke(order_962, "join");
if (!SEq(os_963, Get(I_878, "order"))) {
Set(I_878, "order", os_963);
Invoke(order_962, "forEach", Fn((V _self871, int _argc3186, V k_3192, V _a3189, V _a3190, V _a3191, V[] _rest3187) => {
V O_3193 = default;
V Q_3194 = default;
O_3193 = (((SEqS(k_3192, "tail") ? V.True : V.False) is var _t3195 && !Truthy(_t3195) ? _t3195 : Get(I_878, "lt")) is var _t3196 && !Truthy(_t3196) ? _t3196 : Get(Get(I_878, "lt"), "tailOL"));
if (Truthy(O_3193)) {
Invoke(Get(I_878, "root"), "appendChild", O_3193);
}
Invoke(Get(I_878, "root"), "appendChild", GetK(Get(I_878, "pg"), k_3192));
Q_3194 = (Get(I_878, "lt") is var _t3197 && !Truthy(_t3197) ? _t3197 : GetK(Get(Get(I_878, "lt"), "part"), k_3192));
if (Truthy(Q_3194)) {
Invoke(Get(I_878, "root"), "appendChild", Get(Q_3194, "g"));
}
return default;
}, 1, "", true));
if (Truthy(Get(I_878, "lt"))) {
Invoke(Get(I_878, "root"), "appendChild", Get(Get(I_878, "lt"), "gm"));
}
}
return default;
}, 3, "render", false);
coatBuild_63 = Fn((V _self3198, int _argc3199, V D_3205, V _a3202, V _a3203, V _a3204, V[] _rest3200) => {
V H_3206 = default;
V HX_3207 = default;
V HY_3208 = default;
V HR_3209 = default;
V SR_3210 = default;
V SRY_3211 = default;
V BX_3212 = default;
V BY_3213 = default;
V BW_3214 = default;
V BH_3215 = default;
double BZ_3216 = 0;
V SH_3217 = default;
V CX_3218 = default;
V CY_3219 = default;
V RX_3220 = default;
V RY_3221 = default;
V RZ_3222 = default;
V tab_3223 = default;
V hA_3224 = default;
V bA_3225 = default;
V dir_3226 = default;
V nrm_3227 = default;
V S_3228 = default;
V NY_3229 = default;
V NS_3230 = default;
V own_3231 = default;
V ang_3232 = default;
V cov_3233 = default;
V NA_3234 = default;
V NR_3235 = default;
double PM_3236 = 0;
V edge_3237 = default;
double zig_3238 = 0;
V mesh_3239 = default;
V hs_3240 = default;
V sp_3241 = default;
V n_3242 = default;
V L0_3243 = default;
V W0_3244 = default;
V nH_3245 = default;
if (_self3198.IsNullish) _self3198 = GlobalV;
H_3206 = Get(Get(Get(D_3205, "mane"), "hog"), "coat");
{ V _t3246 = Get(D_3205, "head");
{ V _t3247 = ListOf(_t3246);
{ V _t3248 = GetIdx(_t3247, 0D);
HX_3207 = _t3248; }
{ V _t3249 = GetIdx(_t3247, 1D);
HY_3208 = _t3249; }
{ V _t3250 = GetIdx(_t3247, 2D);
HR_3209 = _t3250; }
} }
SR_3210 = Add(HR_3209, ((V)(0.5)));
SRY_3211 = Add((GetIdx(Get(D_3205, "head"), 3D) is var _t3251 && Truthy(_t3251) ? _t3251 : HR_3209), ((V)(0.5)));
{ V _t3252 = Get(D_3205, "body");
{ V _t3253 = ListOf(_t3252);
{ V _t3254 = GetIdx(_t3253, 0D);
BX_3212 = _t3254; }
{ V _t3255 = GetIdx(_t3253, 1D);
BY_3213 = _t3255; }
{ V _t3256 = GetIdx(_t3253, 2D);
BW_3214 = _t3256; }
{ V _t3257 = GetIdx(_t3253, 3D);
BH_3215 = _t3257; }
} }
BZ_3216 = (ToNum(BW_3214) * 0.75);
SH_3217 = (Get(H_3206, "shell") is var _t3258 && Truthy(_t3258) ? _t3258 : NewObj(2).Put("c", Arr(((V)(50D)), ((V)(62D)))).Put("r", Arr(((V)(27D)), ((V)(29D)), ((V)(26D)))).V);
{ V _t3259 = Get(SH_3217, "c");
{ V _t3260 = ListOf(_t3259);
{ V _t3261 = GetIdx(_t3260, 0D);
CX_3218 = _t3261; }
{ V _t3262 = GetIdx(_t3260, 1D);
CY_3219 = _t3262; }
} }
{ V _t3263 = Get(SH_3217, "r");
{ V _t3264 = ListOf(_t3263);
{ V _t3265 = GetIdx(_t3264, 0D);
RX_3220 = _t3265; }
{ V _t3266 = GetIdx(_t3264, 1D);
RY_3221 = _t3266; }
{ V _t3267 = GetIdx(_t3264, 2D);
RZ_3222 = _t3267; }
} }
tab_3223 = Fn((V _self3198, int _argc3268, V T_3274, V a_3275, V _a3272, V _a3273, V[] _rest3269) => {
if (Le(a_3275, GetIdx(GetIdx(T_3274, 0D), 0D))) {
return GetIdx(GetIdx(T_3274, 0D), 1D);
}
{
double i_3276 = 0;
i_3276 = 1D;
while (true) {
if (!(Lt(((V)(i_3276)), Get(T_3274, "length")))) break;
if (Le(a_3275, GetIdx(GetIdx(T_3274, i_3276), 0D))) {
return Call(lerp_15, V.Undef, GetIdx(GetIdx(T_3274, (i_3276 - 1D)), 1D), GetIdx(GetIdx(T_3274, i_3276), 1D), ((V)(((ToNum(a_3275) - ToNum(GetIdx(GetIdx(T_3274, (i_3276 - 1D)), 0D))) / (ToNum(GetIdx(GetIdx(T_3274, i_3276), 0D)) - ToNum(GetIdx(GetIdx(T_3274, (i_3276 - 1D)), 0D)))))));
}
i_3276++;
}
}
return GetIdx(GetIdx(T_3274, (ToNum(Get(T_3274, "length")) - 1D)), 1D);
return default;
}, 2, "", true);
hA_3224 = (Get(H_3206, "headEdge") is var _t3278 && Truthy(_t3278) ? _t3278 : Arr(Arr(((V)(0D)), ((V)(27D))), Arr(((V)(14D)), ((V)(34D))), Arr(((V)(40D)), ((V)(52D))), Arr(((V)(90D)), ((V)(84D))), Arr(((V)(130D)), ((V)(104D))), Arr(((V)(180D)), ((V)(98D)))));
bA_3225 = (Get(H_3206, "bodyEdge") is var _t3279 && Truthy(_t3279) ? _t3279 : Arr(Arr(((V)(0D)), ((V)(55D))), Arr(((V)(90D)), ((V)(82D))), Arr(((V)(150D)), ((V)(112D))), Arr(((V)(180D)), ((V)(135D)))));
dir_3226 = Fn((V _self3198, int _argc3280, V pa_3286, V ph_3287, V _a3284, V _a3285, V[] _rest3281) => {
return Arr(((V)((FdLibm.Sin(ToNum(pa_3286)) * FdLibm.Sin(ToNum(ph_3287))))), ((V)(((-FdLibm.Sin(ToNum(pa_3286))) * FdLibm.Cos(ToNum(ph_3287))))), ((V)(FdLibm.Cos(ToNum(pa_3286)))));
}, 2, "", true);
nrm_3227 = Fn((V _self3198, int _argc3288, V v_3294, V _a3291, V _a3292, V _a3293, V[] _rest3289) => {
V l_3295 = default;
l_3295 = (((V)(Hypot(ToNum(GetIdx(v_3294, 0D)), ToNum(GetIdx(v_3294, 1D)), ToNum(GetIdx(v_3294, 2D))))) is var _t3296 && Truthy(_t3296) ? _t3296 : ((V)(1D)));
return Arr(((V)((ToNum(GetIdx(v_3294, 0D)) / ToNum(l_3295)))), ((V)((ToNum(GetIdx(v_3294, 1D)) / ToNum(l_3295)))), ((V)((ToNum(GetIdx(v_3294, 2D)) / ToNum(l_3295)))));
return default;
}, 1, "", true);
S_3228 = Fn((V _self3198, int _argc3297, V u_3303, V k_3304, V _a3301, V _a3302, V[] _rest3298) => {
return Arr(Add(CX_3218, ((V)(((ToNum(RX_3220) * ToNum(GetIdx(u_3303, 0D))) * ToNum(k_3304))))), Add(CY_3219, ((V)(((ToNum(RY_3221) * ToNum(GetIdx(u_3303, 1D))) * ToNum(k_3304))))), ((V)(((ToNum(RZ_3222) * ToNum(GetIdx(u_3303, 2D))) * ToNum(k_3304)))));
}, 2, "", true);
NY_3229 = (Get(H_3206, "neckY") is var _t3305 && Truthy(_t3305) ? _t3305 : ((V)(66D)));
NS_3230 = (Get(H_3206, "neckSpan") is var _t3306 && Truthy(_t3306) ? _t3306 : ((V)(12D)));
own_3231 = Fn((V _self3198, int _argc3307, V p_3313, V _a3310, V _a3311, V _a3312, V[] _rest3308) => {
return Call(SM_16, V.Undef, ((V)(((ToNum(Add(NY_3229, NS_3230)) - ToNum(GetIdx(p_3313, 1D))) / ToNum(NS_3230)))));
}, 1, "", true);
ang_3232 = Fn((V _self3198, int _argc3314, V x_3320, V y_3321, V z_3322, V _a3319, V[] _rest3315) => {
V l_3323 = default;
l_3323 = (((V)(Hypot(ToNum(x_3320), ToNum(y_3321), ToNum(z_3322)))) is var _t3324 && Truthy(_t3324) ? _t3324 : ((V)(1D)));
return Arr(((V)((FdLibm.Acos(ToNum(Call(clamp_13, V.Undef, ((V)((ToNum(z_3322) / ToNum(l_3323)))), ((V)((-1D))), ((V)(1D))))) / D2R_11))), ((V)((System.Math.Abs(FdLibm.Atan2(ToNum(x_3320), (-ToNum(y_3321)))) / D2R_11))));
return default;
}, 3, "", true);
cov_3233 = Fn((V _self3198, int _argc3325, V p_3331, V _a3328, V _a3329, V _a3330, V[] _rest3326) => {
V hpa_3332 = default;
V hph_3333 = default;
V bpa_3334 = default;
V bph_3335 = default;
V w_3336 = default;
{ V _t3337 = Call(ang_3232, V.Undef, ((V)(((ToNum(GetIdx(p_3331, 0D)) - ToNum(HX_3207)) / ToNum(SR_3210)))), ((V)(((ToNum(GetIdx(p_3331, 1D)) - ToNum(HY_3208)) / ToNum(SRY_3211)))), ((V)((ToNum(GetIdx(p_3331, 2D)) / ToNum(SR_3210)))));
{ V _t3338 = ListOf(_t3337);
{ V _t3339 = GetIdx(_t3338, 0D);
hpa_3332 = _t3339; }
{ V _t3340 = GetIdx(_t3338, 1D);
hph_3333 = _t3340; }
} }
{ V _t3341 = Call(ang_3232, V.Undef, ((V)(((ToNum(GetIdx(p_3331, 0D)) - ToNum(BX_3212)) / ToNum(BW_3214)))), ((V)(((ToNum(GetIdx(p_3331, 1D)) - ToNum(BY_3213)) / ToNum(BH_3215)))), ((V)((ToNum(GetIdx(p_3331, 2D)) / BZ_3216))));
{ V _t3342 = ListOf(_t3341);
{ V _t3343 = GetIdx(_t3342, 0D);
bpa_3334 = _t3343; }
{ V _t3344 = GetIdx(_t3342, 1D);
bph_3335 = _t3344; }
} }
w_3336 = Call(own_3231, V.Undef, p_3331);
return ((V)(((ToNum(w_3336) * (ToNum(hpa_3332) - ToNum(Call(tab_3223, V.Undef, hA_3224, hph_3333)))) + ((1D - ToNum(w_3336)) * (ToNum(bpa_3334) - ToNum(Call(tab_3223, V.Undef, bA_3225, bph_3335)))))));
return default;
}, 1, "", true);
NA_3234 = (Get(H_3206, "meshA") is var _t3345 && Truthy(_t3345) ? _t3345 : ((V)(44D)));
NR_3235 = (Get(H_3206, "meshR") is var _t3346 && Truthy(_t3346) ? _t3346 : ((V)(8D)));
PM_3236 = (System.Math.PI * 0.985);
edge_3237 = Array_from(NewObj(1).Put("length", NA_3234).V, Fn((V _self3198, int _argc3347, V __3353, V i_3354, V _a3351, V _a3352, V[] _rest3348) => {
double ph_3355 = 0;
double lo_3356 = 0;
double hi_3357 = 0;
ph_3355 = ((ToNum(i_3354) / ToNum(NA_3234)) * TAU_12);
lo_3356 = 0D;
hi_3357 = PM_3236;
if (LeN(Call(cov_3233, V.Undef, Call(S_3228, V.Undef, Call(dir_3226, V.Undef, ((V)(hi_3357)), ((V)(ph_3355))), ((V)(1D)))), 0D)) {
return ((V)(hi_3357));
}
if (GtN(Call(cov_3233, V.Undef, Call(S_3228, V.Undef, Call(dir_3226, V.Undef, ((V)(lo_3356)), ((V)(ph_3355))), ((V)(1D)))), 0D)) {
return ((V)(lo_3356));
}
{
double k_3358 = 0;
k_3358 = 0D;
while (true) {
if (!((k_3358 < 24D))) break;
double m_3360 = 0;
m_3360 = ((lo_3356 + hi_3357) / 2D);
if (GtN(Call(cov_3233, V.Undef, Call(S_3228, V.Undef, Call(dir_3226, V.Undef, ((V)(m_3360)), ((V)(ph_3355))), ((V)(1D)))), 0D)) {
hi_3357 = m_3360;
} else {
lo_3356 = m_3360;
}
k_3358++;
}
}
return ((V)(hi_3357));
return default;
}, 2, "", true));
zig_3238 = (ToNum((!Get(H_3206, "zig").IsNullish ? Get(H_3206, "zig") : ((V)(7D)))) * D2R_11);
mesh_3239 = Arr();
{
double r_3361 = 0;
r_3361 = 0D;
while (true) {
if (!(Le(((V)(r_3361)), NR_3235))) break;
V row_3363 = default;
row_3363 = Arr();
{
double i_3364 = 0;
i_3364 = 0D;
while (true) {
if (!(Lt(((V)(i_3364)), NA_3234))) break;
double ph_3366 = 0;
V a0_3367 = default;
V a_3368 = default;
V p_3369 = default;
ph_3366 = ((i_3364 / ToNum(NA_3234)) * TAU_12);
a0_3367 = GetIdx(edge_3237, i_3364);
a_3368 = ((r_3361 == 0D) ? ((V)(Max(0D, (ToNum(a0_3367) - (NumTruthy((i_3364 % 2D)) ? 0D : zig_3238))))) : Add(a0_3367, ((V)((((PM_3236 - ToNum(a0_3367)) * r_3361) / ToNum(NR_3235))))));
p_3369 = Call(S_3228, V.Undef, Call(dir_3226, V.Undef, a_3368, ((V)(ph_3366))), ((V)(0.985)));
Invoke(row_3363, "push", NewObj(2).Put("p", p_3369).Put("w", Call(own_3231, V.Undef, p_3369)).V);
i_3364++;
}
}
Invoke(mesh_3239, "push", row_3363);
r_3361++;
}
}
hs_3240 = Fn((V _self3198, int _argc3370, V i_3376, V _a3373, V _a3374, V _a3375, V[] _rest3371) => {
return ((V)(((((FdLibm.Sin(((ToNum(i_3376) * 12.9898) + 4.1)) * 43758.5453) % 1D) + 1D) % 1D)));
}, 1, "", true);
sp_3241 = Arr();
n_3242 = (Get(H_3206, "n") is var _t3377 && Truthy(_t3377) ? _t3377 : ((V)(300D)));
L0_3243 = (Get(H_3206, "len") is var _t3378 && Truthy(_t3378) ? _t3378 : ((V)(9D)));
W0_3244 = (Get(H_3206, "w") is var _t3379 && Truthy(_t3379) ? _t3379 : ((V)(3.4)));
{
double i_3380 = 0;
i_3380 = 0D;
while (true) {
if (!(Lt(((V)(i_3380)), n_3242))) break;
double y_3382 = 0;
double rr_3383 = 0;
double t_3384 = 0;
V u_3385 = default;
V root_3386 = default;
double pa_3387 = 0;
double ph_3388 = 0;
V nr_3389 = default;
V e_3390 = default;
y_3382 = (1D - ((2D * (i_3380 + 0.5)) / ToNum(n_3242)));
rr_3383 = System.Math.Sqrt((1D - (y_3382 * y_3382)));
t_3384 = (i_3380 * 2.399963);
u_3385 = Arr(((V)((rr_3383 * FdLibm.Cos(t_3384)))), ((V)(y_3382)), ((V)((rr_3383 * FdLibm.Sin(t_3384)))));
root_3386 = Call(S_3228, V.Undef, u_3385, ((V)(1D)));
if (LtN(Call(cov_3233, V.Undef, root_3386), 3D)) {
goto _cont3381;
}
pa_3387 = FdLibm.Acos(ToNum(Call(clamp_13, V.Undef, GetIdx(u_3385, 2D), ((V)((-1D))), ((V)(1D)))));
ph_3388 = FdLibm.Atan2(ToNum(GetIdx(u_3385, 0D)), (-ToNum(GetIdx(u_3385, 1D))));
nr_3389 = Call(nrm_3227, V.Undef, Arr(((V)((ToNum(GetIdx(u_3385, 0D)) / ToNum(RX_3220)))), ((V)((ToNum(GetIdx(u_3385, 1D)) / ToNum(RY_3221)))), ((V)((ToNum(GetIdx(u_3385, 2D)) / ToNum(RZ_3222))))));
e_3390 = Call(nrm_3227, V.Undef, Arr(((V)(((ToNum(RX_3220) * FdLibm.Cos(pa_3387)) * FdLibm.Sin(ph_3388)))), ((V)((((-ToNum(RY_3221)) * FdLibm.Cos(pa_3387)) * FdLibm.Cos(ph_3388)))), ((V)(((-ToNum(RZ_3222)) * FdLibm.Sin(pa_3387))))));
if (Truthy(Get(H_3206, "comb"))) {
V v_3391 = default;
double vn_3392 = 0;
v_3391 = Arr(((V)(0D)), Add(GetIdx(Get(H_3206, "comb"), 0D), ((V)((ToNum(GetIdx(Get(H_3206, "comb"), 1D)) * Max(0D, (-ToNum(GetIdx(nr_3389, 2D)))))))), ((V)((-1D))));
vn_3392 = ((ToNum(GetIdx(v_3391, 1D)) * ToNum(GetIdx(nr_3389, 1D))) + (ToNum(GetIdx(v_3391, 2D)) * ToNum(GetIdx(nr_3389, 2D))));
e_3390 = Invoke(v_3391, "map", Fn((V _self3198, int _argc3393, V x_3399, V j_3400, V _a3397, V _a3398, V[] _rest3394) => {
return ((V)((ToNum(x_3399) - (vn_3392 * ToNum(GetK(nr_3389, j_3400))))));
}, 2, "", true));
OpSetK(e_3390, ((V)(0D)), 2, ((V)((1D - (ToNum(Call(SM_16, V.Undef, ((V)((ToNum(GetIdx(nr_3389, 1D)) / 0.5))))) * ToNum(Call(SM_16, V.Undef, ((V)(((-ToNum(GetIdx(nr_3389, 2D))) / 0.4))))))))));
e_3390 = Call(nrm_3227, V.Undef, e_3390);
}
Invoke(sp_3241, "push", NewObj(8).Put("r", root_3386).Put("n", nr_3389).Put("e", e_3390).Put("len", ((V)((ToNum(L0_3243) * (0.8 + (0.4 * ToNum(Call(hs_3240, V.Undef, ((V)(i_3380)))))))))).Put("w", W0_3244).Put("o", Call(own_3231, V.Undef, root_3386)).Put("rim", ((V)((ToNum((!Get(H_3206, "rim").IsNullish ? Get(H_3206, "rim") : ((V)(0.45)))) * Pow((1D - System.Math.Abs(ToNum(GetIdx(nr_3389, 2D)))), 2D))))).Put("i", Get(sp_3241, "length")).V);
_cont3381: ;
i_3380++;
}
}
nH_3245 = Get(Invoke(sp_3241, "filter", Fn((V _self3198, int _argc3401, V q_3407, V _a3404, V _a3405, V _a3406, V[] _rest3402) => {
return (GtN(Get(q_3407, "o"), 0.5) ? V.True : V.False);
}, 1, "", true)), "length");
return NewObj(7).Put("mesh", mesh_3239).Put("sp", sp_3241).Put("nH", nH_3245).Put("nB", ((V)((ToNum(Get(sp_3241, "length")) - ToNum(nH_3245))))).Put("tipF", (!Get(H_3206, "tipF").IsNullish ? Get(H_3206, "tipF") : ((V)(0.62)))).Put("lay", (Get(H_3206, "lay") is var _t3408 && Truthy(_t3408) ? _t3408 : Arr(((V)(0.28)), ((V)(1D)), ((V)(0.22))))).Put("layUp", (Get(H_3206, "layUp") is var _t3409 && Truthy(_t3409) ? _t3409 : Arr(((V)(1.25)), ((V)(0.45)), ((V)(0D))))).V;
return default;
}, 1, "coatBuild", false);
hogBuild_64 = Fn((V _self3410, int _argc3411, V D_3417, V _a3414, V _a3415, V _a3416, V[] _rest3412) => {
V M_3418 = default;
V H_3419 = default;
V C_3420 = default;
V zc_3421 = default;
V RZ_3422 = default;
V P_3423 = default;
V ring_3424 = default;
V c0_3425 = default;
V c1_3426 = default;
V ang_3427 = default;
V rad_3428 = default;
V V_3429 = default;
V T_3430 = default;
V prof_3431 = default;
V rim_3432 = default;
V rv0_3433 = default;
V rt_3434 = default;
double aE_3435 = 0;
double yc_3436 = 0;
V rv_3437 = default;
V zr_3438 = default;
V sh_3439 = default;
V nrm_3440 = default;
V A_3441 = default;
V B_3442 = default;
V G_3443 = default;
V QN_3444 = default;
V sp_3445 = default;
if (_self3410.IsNullish) _self3410 = GlobalV;
M_3418 = Get(D_3417, "mane");
H_3419 = Get(M_3418, "hog");
C_3420 = Get(M_3418, "c");
zc_3421 = (!Get(H_3419, "z").IsNullish ? Get(H_3419, "z") : ((V)((-5D))));
RZ_3422 = (Get(H_3419, "rz") is var _t3446 && Truthy(_t3446) ? _t3446 : ((V)(30D)));
P_3423 = Call(flat_27, V.Undef, Call(parsePath_21, V.Undef, Get(M_3418, "d")), ((V)(1D)));
ring_3424 = Invoke(P_3423, "slice", ((V)(1D)), ((V)((ToNum(Get(P_3423, "length")) - 2D))));
c0_3425 = GetIdx(P_3423, 0D);
c1_3426 = GetIdx(P_3423, (ToNum(Get(P_3423, "length")) - 2D));
ang_3427 = Fn((V _self3410, int _argc3447, V p_3453, V _a3450, V _a3451, V _a3452, V[] _rest3448) => {
return ((V)(FdLibm.Atan2((ToNum(GetIdx(p_3453, 0D)) - ToNum(GetIdx(C_3420, 0D))), (ToNum(GetIdx(C_3420, 1D)) - ToNum(GetIdx(p_3453, 1D))))));
}, 1, "", true);
rad_3428 = Fn((V _self3410, int _argc3454, V p_3460, V _a3457, V _a3458, V _a3459, V[] _rest3455) => {
return ((V)(Hypot((ToNum(GetIdx(p_3460, 0D)) - ToNum(GetIdx(C_3420, 0D))), (ToNum(GetIdx(p_3460, 1D)) - ToNum(GetIdx(C_3420, 1D))))));
}, 1, "", true);
V_3429 = Invoke(ring_3424, "filter", Fn((V _self3410, int _argc3461, V p_3467, V i_3468, V _a3465, V _a3466, V[] _rest3462) => {
return (((ToNum(i_3468) % 2D) == 0D) ? V.True : V.False);
}, 2, "", true));
T_3430 = Invoke(ring_3424, "filter", Fn((V _self3410, int _argc3469, V p_3475, V i_3476, V _a3473, V _a3474, V[] _rest3470) => {
return (((ToNum(i_3476) % 2D) == 1D) ? V.True : V.False);
}, 2, "", true));
prof_3431 = Fn((V _self3410, int _argc3477, V L_3483, V _a3480, V _a3481, V _a3482, V[] _rest3478) => {
V A_3484 = default;
A_3484 = Invoke(Invoke(L_3483, "map", Fn((V _self3410, int _argc3493, V p_3499, V _a3496, V _a3497, V _a3498, V[] _rest3494) => {
return Arr(Call(ang_3427, V.Undef, p_3499), Call(rad_3428, V.Undef, p_3499));
}, 1, "", true)), "sort", Fn((V _self3410, int _argc3485, V a_3491, V b_3492, V _a3489, V _a3490, V[] _rest3486) => {
return ((V)((ToNum(GetIdx(a_3491, 0D)) - ToNum(GetIdx(b_3492, 0D)))));
}, 2, "", true));
return Fn((V _self3410, int _argc3500, V a_3506, V _a3503, V _a3504, V _a3505, V[] _rest3501) => {
if (Le(a_3506, GetIdx(GetIdx(A_3484, 0D), 0D))) {
return GetIdx(GetIdx(A_3484, 0D), 1D);
}
{
double i_3507 = 0;
i_3507 = 1D;
while (true) {
if (!(Lt(((V)(i_3507)), Get(A_3484, "length")))) break;
if (Le(a_3506, GetIdx(GetIdx(A_3484, i_3507), 0D))) {
return Call(lerp_15, V.Undef, GetIdx(GetIdx(A_3484, (i_3507 - 1D)), 1D), GetIdx(GetIdx(A_3484, i_3507), 1D), ((V)(((ToNum(a_3506) - ToNum(GetIdx(GetIdx(A_3484, (i_3507 - 1D)), 0D))) / (ToNum(GetIdx(GetIdx(A_3484, i_3507), 0D)) - ToNum(GetIdx(GetIdx(A_3484, (i_3507 - 1D)), 0D)))))));
}
i_3507++;
}
}
return GetIdx(GetIdx(A_3484, (ToNum(Get(A_3484, "length")) - 1D)), 1D);
return default;
}, 1, "", true);
return default;
}, 1, "", true);
rim_3432 = new ArrBuilder().Add(c0_3425).Spread(V_3429).Add(c1_3426).V;
rv0_3433 = Call(prof_3431, V.Undef, rim_3432);
rt_3434 = Call(prof_3431, V.Undef, T_3430);
aE_3435 = System.Math.Abs(ToNum(Call(ang_3427, V.Undef, c0_3425)));
yc_3436 = (ToNum(Add(GetIdx(c0_3425, 1D), GetIdx(c1_3426, 1D))) / 2D);
rv_3437 = Fn((V _self3410, int _argc3509, V a_3515, V _a3512, V _a3513, V _a3514, V[] _rest3510) => {
return ((System.Math.Abs(ToNum(a_3515)) <= aE_3435) ? Call(rv0_3433, V.Undef, a_3515) : ((V)(((yc_3436 - ToNum(GetIdx(C_3420, 1D))) / Max(0.3, (-FdLibm.Cos(ToNum(a_3515))))))));
}, 1, "", true);
zr_3438 = Fn((V _self3410, int _argc3516, V a_3522, V _a3519, V _a3520, V _a3521, V[] _rest3517) => {
return ((V)((ToNum(Add(zc_3421, ((V)((ToNum((!Get(H_3419, "zt").IsNullish ? Get(H_3419, "zt") : ((V)(9D)))) * Max(0D, FdLibm.Cos(ToNum(a_3522)))))))) - (ToNum((!Get(H_3419, "zb").IsNullish ? Get(H_3419, "zb") : ((V)(6D)))) * Max(0D, (-FdLibm.Cos(ToNum(a_3522))))))));
}, 1, "", true);
sh_3439 = Fn((V _self3410, int _argc3523, V a_3529, V b_3530, V r_3531, V rz_3532, V[] _rest3524) => {
return Arr(Add(GetIdx(C_3420, 0D), ((V)(((ToNum(r_3531) * FdLibm.Cos(ToNum(b_3530))) * FdLibm.Sin(ToNum(a_3529)))))), ((V)((ToNum(GetIdx(C_3420, 1D)) - ((ToNum(r_3531) * FdLibm.Cos(ToNum(b_3530))) * FdLibm.Cos(ToNum(a_3529)))))), ((V)(((ToNum(zc_3421) - (ToNum(rz_3532) * FdLibm.Sin(ToNum(b_3530)))) + ((ToNum(Call(zr_3438, V.Undef, a_3529)) - ToNum(zc_3421)) * FdLibm.Cos(ToNum(b_3530)))))));
}, 4, "", true);
nrm_3440 = Fn((V _self3410, int _argc3533, V a_3539, V b_3540, V _a3537, V _a3538, V[] _rest3534) => {
return Arr(((V)((FdLibm.Cos(ToNum(b_3540)) * FdLibm.Sin(ToNum(a_3539))))), ((V)(((-FdLibm.Cos(ToNum(b_3540))) * FdLibm.Cos(ToNum(a_3539))))), ((V)((-FdLibm.Sin(ToNum(b_3540))))));
}, 2, "", true);
A_3441 = Invoke(Invoke(rim_3432, "map", ang_3427), "concat", Invoke(Arr(((V)(1D)), ((V)(2D)), ((V)(3D))), "map", Fn((V _self3410, int _argc3541, V k_3547, V _a3544, V _a3545, V _a3546, V[] _rest3542) => {
return ((V)((aE_3435 + ((ToNum(k_3547) * (TAU_12 - (2D * aE_3435))) / 4D))));
}, 1, "", true)));
B_3442 = Invoke(Arr(((V)(0D)), ((V)(18D)), ((V)(36D)), ((V)(54D)), ((V)(72D)), ((V)(90D))), "map", Fn((V _self3410, int _argc3548, V d_3554, V _a3551, V _a3552, V _a3553, V[] _rest3549) => {
return ((V)((ToNum(d_3554) * D2R_11)));
}, 1, "", true));
G_3443 = Invoke(B_3442, "map", Fn((V _self3410, int _argc3555, V b_3561, V _a3558, V _a3559, V _a3560, V[] _rest3556) => {
return Invoke(A_3441, "map", Fn((V _self3410, int _argc3562, V a_3568, V _a3565, V _a3566, V _a3567, V[] _rest3563) => {
return Call(sh_3439, V.Undef, a_3568, b_3561, Call(rv_3437, V.Undef, a_3568), RZ_3422);
}, 1, "", true));
}, 1, "", true));
QN_3444 = Invoke(Invoke(B_3442, "slice", ((V)(0D)), ((V)((-1D)))), "map", Fn((V _self3410, int _argc3569, V b_3575, V j_3576, V _a3573, V _a3574, V[] _rest3570) => {
return Invoke(A_3441, "map", Fn((V _self3410, int _argc3577, V a_3583, V i_3584, V _a3581, V _a3582, V[] _rest3578) => {
V a2_3585 = default;
a2_3585 = GetIdx(A_3441, (ToNum(Add(i_3584, ((V)(1D)))) % ToNum(Get(A_3441, "length"))));
if (Lt(a2_3585, a_3583)) {
a2_3585 = Add(a2_3585, ((V)(TAU_12)));
}
return Call(nrm_3440, V.Undef, ((V)((ToNum(Add(a_3583, a2_3585)) / 2D))), ((V)((ToNum(Add(b_3575, GetK(B_3442, Add(j_3576, ((V)(1D)))))) / 2D))));
return default;
}, 2, "", true));
}, 2, "", true));
sp_3445 = Arr();
{
double k_3586 = 0;
k_3586 = 0D;
while (true) {
if (!(Lt(((V)(k_3586)), Get(T_3430, "length")))) break;
V b1_3588 = default;
V b2_3589 = default;
V t_3590 = default;
double len_3591 = 0;
b1_3588 = GetIdx(V_3429, k_3586);
b2_3589 = GetIdx(V_3429, (k_3586 + 1D));
t_3590 = GetIdx(T_3430, k_3586);
len_3591 = (ToNum(Call(rad_3428, V.Undef, t_3590)) - (ToNum(Add(Call(rad_3428, V.Undef, b1_3588), Call(rad_3428, V.Undef, b2_3589))) / 2D));
Invoke(sp_3445, "push", NewObj(6).Put("b1", Arr(GetIdx(b1_3588, 0D), GetIdx(b1_3588, 1D), Call(zr_3438, V.Undef, Call(ang_3427, V.Undef, b1_3588)))).Put("b2", Arr(GetIdx(b2_3589, 0D), GetIdx(b2_3589, 1D), Call(zr_3438, V.Undef, Call(ang_3427, V.Undef, b2_3589)))).Put("t", Arr(GetIdx(t_3590, 0D), GetIdx(t_3590, 1D), ((V)((ToNum(Call(zr_3438, V.Undef, Call(ang_3427, V.Undef, t_3590))) - (len_3591 * ToNum(Add((!Get(H_3419, "tilt").IsNullish ? Get(H_3419, "tilt") : ((V)(1D))), ((V)((0.8 * Max(0D, FdLibm.Cos(ToNum(Call(ang_3427, V.Undef, t_3590))))))))))))))).Put("n", Call(nrm_3440, V.Undef, Call(ang_3427, V.Undef, t_3590), ((V)(0D)))).Put("len", ((V)(len_3591))).Put("i", Get(sp_3445, "length")).V);
k_3586++;
}
}
Invoke((Get(H_3419, "rows") is var _t3615 && Truthy(_t3615) ? _t3615 : Arr()), "forEach", Fn((V _self3410, int _argc3592, V _a3594, V _a3595, V _a3596, V _a3597, V[] _rest3593) => {
double b_3605 = 0;
V full_3606 = default;
double stp_3607 = 0;
double a0_3608 = 0;
V bd_3600 = default;
V m_3602 = default;
V am_3604 = default;
{ V _t3598 = ListOf(_a3594);
{ V _t3599 = GetIdx(_t3598, 0D);
bd_3600 = _t3599; }
{ V _t3601 = GetIdx(_t3598, 1D);
m_3602 = _t3601; }
{ V _t3603 = GetIdx(_t3598, 2D);
am_3604 = _t3603; }
}
b_3605 = (ToNum(bd_3600) * D2R_11);
full_3606 = (GeN(am_3604, 180D) ? V.True : V.False);
stp_3607 = (((Truthy(full_3606) ? 360D : (2D * ToNum(am_3604))) / ToNum(m_3602)) * D2R_11);
a0_3608 = (Truthy(full_3606) ? (-System.Math.PI) : ((-ToNum(am_3604)) * D2R_11));
{
double j_3609 = 0;
j_3609 = 0D;
while (true) {
if (!(Lt(((V)(j_3609)), m_3602))) break;
double a_3611 = 0;
double da_3612 = 0;
double len_3613 = 0;
a_3611 = (a0_3608 + ((j_3609 + 0.5) * stp_3607));
da_3612 = (stp_3607 / 2D);
len_3613 = Max(2D, ((ToNum(Call(rt_3434, V.Undef, ((V)(a_3611)))) - ToNum(Call(rv_3437, V.Undef, ((V)(a_3611))))) * ToNum((Get(H_3419, "lk") is var _t3614 && Truthy(_t3614) ? _t3614 : ((V)(0.9))))));
Invoke(sp_3445, "push", NewObj(6).Put("b1", Call(sh_3439, V.Undef, ((V)((a_3611 - da_3612))), ((V)(b_3605)), Call(rv_3437, V.Undef, ((V)((a_3611 - da_3612)))), RZ_3422)).Put("b2", Call(sh_3439, V.Undef, ((V)((a_3611 + da_3612))), ((V)(b_3605)), Call(rv_3437, V.Undef, ((V)((a_3611 + da_3612)))), RZ_3422)).Put("t", Call(sh_3439, V.Undef, ((V)(a_3611)), ((V)(b_3605)), Add(Call(rv_3437, V.Undef, ((V)(a_3611))), ((V)(len_3613))), Add(RZ_3422, ((V)(len_3613))))).Put("n", Call(nrm_3440, V.Undef, ((V)(a_3611)), ((V)(b_3605)))).Put("len", ((V)(len_3613))).Put("i", Get(sp_3445, "length")).V);
j_3609++;
}
}
return default;
}, 1, "", true));
return NewObj(5).Put("A", A_3441).Put("B", B_3442).Put("G", G_3443).Put("QN", QN_3444).Put("sp", Invoke(sp_3445, "map", Fn((V _self3410, int _argc3616, V s_3622, V _a3619, V _a3620, V _a3621, V[] _rest3617) => {
return Object_assign(s_3622, NewObj(1).Put("w", ((V)((Hypot((ToNum(GetIdx(Get(s_3622, "b2"), 0D)) - ToNum(GetIdx(Get(s_3622, "b1"), 0D))), (ToNum(GetIdx(Get(s_3622, "b2"), 1D)) - ToNum(GetIdx(Get(s_3622, "b1"), 1D))), (ToNum(GetIdx(Get(s_3622, "b2"), 2D)) - ToNum(GetIdx(Get(s_3622, "b1"), 2D)))) / 2D)))).V);
}, 1, "", true))).V;
return default;
}, 1, "hogBuild", false);
loop_69 = Fn((V _self3623, int _argc3624, V now_3630, V _a3627, V _a3628, V _a3629, V[] _rest3625) => {
V SP_3631 = default;
V N_3632 = default;
double F_3633 = 0;
double j_3634 = 0;
V c0_3635 = default;
if (_self3623.IsNullish) _self3623 = GlobalV;
SP_3631 = Get(G("window"), "SquishPerf");
if (Truthy((SP_3631 is var _t3636 && !Truthy(_t3636) ? _t3636 : Get(SP_3631, "freeze")))) {
V back_3637 = default;
if (Truthy(raf_66)) {
Call(G("cancelAnimationFrame"), V.Undef, raf_66);
}
raf_66 = ((V)(0D));
last_67 = now_3630;
Call(G("clearTimeout"), V.Undef, Get(loop_69, "fz"));
back_3637 = Fn((V _self3623, int _argc3638, V _a3640, V _a3641, V _a3642, V _a3643, V[] _rest3639) => {
if (Truthy(Get(SP_3631, "freeze"))) {
Set(loop_69, "fz", Call(G("setTimeout"), V.Undef, back_3637, ((V)(120D))));
return default;
}
if (Truthy(((!(Truthy(raf_66)) ? V.True : V.False) is var _t3644 && !Truthy(_t3644) ? _t3644 : Get(ALL_65, "size")))) {
raf_66 = Call(G("requestAnimationFrame"), V.Undef, loop_69);
}
return default;
}, 0, "", true);
Set(loop_69, "fz", Call(G("setTimeout"), V.Undef, back_3637, ((V)(120D))));
return default;
}
raf_66 = (Truthy(Get(ALL_65, "size")) ? Call(G("requestAnimationFrame"), V.Undef, loop_69) : ((V)(0D)));
N_3632 = (Truthy((SP_3631 is var _t3645 && !Truthy(_t3645) ? _t3645 : Get(SP_3631, "rigStride"))) ? Invoke(SP_3631, "rigStride") : ((V)(1D)));
F_3633 = ToNum(Set(loop_69, "f", ((V)((ToNum(Add((Get(loop_69, "f") is var _t3646 && Truthy(_t3646) ? _t3646 : ((V)(0D))), ((V)(1D)))) % 997920D)))));
j_3634 = 0D;
last_67 = now_3630;
c0_3635 = Invoke(G("performance"), "now");
Invoke(ALL_65, "forEach", Fn((V _self3623, int _argc3647, V I_3653, V _a3650, V _a3651, V _a3652, V[] _rest3648) => {
V dt_3654 = default;
if (Truthy(Get(I_3653, "sqHold"))) {
return default;
}
if (NumTruthy(((j_3634++ + F_3633) % ToNum(N_3632)))) {
return default;
}
if (Truthy((Get(I_3653, "key") is var _t3655 && !Truthy(_t3655) ? _t3655 : Get(G("window"), "SquishLazy")))) {
Invoke(Get(G("window"), "SquishLazy"), "need", Get(I_3653, "key"));
}
dt_3654 = Call(clamp_13, V.Undef, ((V)(((ToNum(now_3630) - ToNum((Get(I_3653, "sqT") is var _t3656 && Truthy(_t3656) ? _t3656 : ((V)((ToNum(now_3630) - (16D * ToNum(N_3632)))))))) / 1000D))), ((V)(0.001)), ((V)((1D / 20D))));
Set(I_3653, "sqT", now_3630);
try {
Call(tick_59, V.Undef, I_3653, now_3630, dt_3654);
} catch (System.Exception _ex3657) {
V e_3658 = default;
e_3658 = Caught(_ex3657);
if (!(Truthy(Get(I_3653, "err")))) {
Set(I_3653, "err", ((V)(1D)));
Invoke(G("console"), "error", ((V)("RiveRig")), e_3658);
}
}
return default;
}, 1, "", true));
if (Truthy(((SP_3631 is var _t3659 && !Truthy(_t3659) ? _t3659 : Get(SP_3631, "rigCost")) is var _t3660 && !Truthy(_t3660) ? _t3660 : ((V)(j_3634))))) {
Invoke(SP_3631, "rigCost", ((V)((ToNum(Invoke(G("performance"), "now")) - ToNum(c0_3635)))), N_3632);
}
return default;
}, 1, "loop", false);
rgbOf_78 = Fn((V _self3661, int _argc3662, V e_3668, V _a3665, V _a3666, V _a3667, V[] _rest3663) => {
if (_self3661.IsNullish) _self3661 = GlobalV;
try {
V f_3669 = default;
V m_3670 = default;
f_3669 = (Get(Call(G("getComputedStyle"), V.Undef, e_3668), "fill") is var _t3671 && Truthy(_t3671) ? _t3671 : ((V)("")));
m_3670 = Invoke(f_3669, "match", NewRegExp(RX5, "url\\([\"']?#([^\"')]+)[\"']?\\)", ""));
if (Truthy(m_3670)) {
V svg_3672 = default;
V g_3673 = default;
V cs_3674 = default;
svg_3672 = Get(e_3668, "ownerSVGElement");
g_3673 = (svg_3672 is var _t3675 && !Truthy(_t3675) ? _t3675 : Invoke(svg_3672, "querySelector", ((V)(string.Concat("[id=\"", ToStr(GetIdx(m_3670, 1D)), "\"]")))));
{
double i_3676 = 0;
i_3676 = 0D;
while (true) {
if (!(Truthy(((((i_3676 < 3D) ? V.True : V.False) is var _t3678 && !Truthy(_t3678) ? _t3678 : g_3673) is var _t3679 && !Truthy(_t3679) ? _t3679 : (!(Truthy(Invoke(g_3673, "querySelector", ((V)("stop"))))) ? V.True : V.False))))) break;
V hr_3680 = default;
hr_3680 = Invoke(((Invoke(g_3673, "getAttribute", ((V)("href"))) is var _t3681 && Truthy(_t3681) ? _t3681 : Invoke(g_3673, "getAttribute", ((V)("xlink:href")))) is var _t3682 && Truthy(_t3682) ? _t3682 : ((V)(""))), "slice", ((V)(1D)));
g_3673 = (Truthy(hr_3680) ? Invoke(svg_3672, "querySelector", ((V)(string.Concat("[id=\"", ToStr(hr_3680), "\"]")))) : V.Null);
i_3676++;
}
}
cs_3674 = (Truthy(g_3673) ? Invoke(Invoke(new ArrBuilder().Spread(Invoke(g_3673, "querySelectorAll", ((V)("stop")))).V, "map", Fn((V _self3661, int _argc3683, V s_3689, V _a3686, V _a3687, V _a3688, V[] _rest3684) => {
return Call(rgbP_77, V.Undef, Get(Call(G("getComputedStyle"), V.Undef, s_3689), "stopColor"));
}, 1, "", true)), "filter", G("Boolean")) : Arr());
if (!(Truthy(Get(cs_3674, "length")))) {
return Arr(((V)(200D)), ((V)(140D)), ((V)(100D)));
}
return Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _self3661, int _argc3690, V i_3696, V _a3693, V _a3694, V _a3695, V[] _rest3691) => {
return ((V)((ToNum(Invoke(cs_3674, "reduce", Fn((V _self3661, int _argc3697, V a_3703, V c_3704, V _a3701, V _a3702, V[] _rest3698) => {
return Add(a_3703, GetK(c_3704, i_3696));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(cs_3674, "length")))));
}, 1, "", true));
}
return (Call(rgbP_77, V.Undef, f_3669) is var _t3705 && Truthy(_t3705) ? _t3705 : Arr(((V)(200D)), ((V)(140D)), ((V)(100D))));
} catch (System.Exception _ex3706) {
V x_3707 = default;
x_3707 = Caught(_ex3706);
return Arr(((V)(200D)), ((V)(140D)), ((V)(100D)));
}
return default;
}, 1, "rgbOf", false);
hsl_79 = Fn((V _self3708, int _argc3709, V _a3711, V _a3712, V _a3713, V _a3714, V[] _rest3710) => {
double mx_3722 = 0;
double mn_3723 = 0;
double l_3724 = 0;
double h_3725 = 0;
double s_3726 = 0;
V r_3717 = default;
V g_3719 = default;
V b_3721 = default;
if (_self3708.IsNullish) _self3708 = GlobalV;
{ V _t3715 = ListOf(_a3711);
{ V _t3716 = GetIdx(_t3715, 0D);
r_3717 = _t3716; }
{ V _t3718 = GetIdx(_t3715, 1D);
g_3719 = _t3718; }
{ V _t3720 = GetIdx(_t3715, 2D);
b_3721 = _t3720; }
}
r_3717 = ((V)((ToNum(r_3717) / 255D)));
g_3719 = ((V)((ToNum(g_3719) / 255D)));
b_3721 = ((V)((ToNum(b_3721) / 255D)));
mx_3722 = Max(ToNum(r_3717), ToNum(g_3719), ToNum(b_3721));
mn_3723 = Min(ToNum(r_3717), ToNum(g_3719), ToNum(b_3721));
l_3724 = ((mx_3722 + mn_3723) / 2D);
h_3725 = 0D;
s_3726 = 0D;
if ((mx_3722 != mn_3723)) {
double d_3727 = 0;
d_3727 = (mx_3722 - mn_3723);
s_3726 = ((l_3724 > 0.5) ? (d_3727 / ((2D - mx_3722) - mn_3723)) : (d_3727 / (mx_3722 + mn_3723)));
h_3725 = (SEqN(r_3717, mx_3722) ? (((ToNum(g_3719) - ToNum(b_3721)) / d_3727) + (Lt(g_3719, b_3721) ? 6D : 0D)) : (SEqN(g_3719, mx_3722) ? (((ToNum(b_3721) - ToNum(r_3717)) / d_3727) + 2D) : (((ToNum(r_3717) - ToNum(g_3719)) / d_3727) + 4D)));
h_3725 = (h_3725 / 6D);
}
return Arr(((V)(h_3725)), ((V)(s_3726)), ((V)(l_3724)));
return default;
}, 1, "hsl", false);
hex_80 = Fn((V _self3728, int _argc3729, V _a3731, V _a3732, V _a3733, V _a3734, V[] _rest3730) => {
V f_3742 = default;
V h_3737 = default;
V s_3739 = default;
V l_3741 = default;
if (_self3728.IsNullish) _self3728 = GlobalV;
{ V _t3735 = ListOf(_a3731);
{ V _t3736 = GetIdx(_t3735, 0D);
h_3737 = _t3736; }
{ V _t3738 = GetIdx(_t3735, 1D);
s_3739 = _t3738; }
{ V _t3740 = GetIdx(_t3735, 2D);
l_3741 = _t3740; }
}
f_3742 = Fn((V _self3728, int _argc3743, V n_3749, V _a3746, V _a3747, V _a3748, V[] _rest3744) => {
double k_3750 = 0;
double a_3751 = 0;
k_3750 = (ToNum(Add(n_3749, ((V)((ToNum(h_3737) * 12D))))) % 12D);
a_3751 = (ToNum(s_3739) * Min(ToNum(l_3741), (1D - ToNum(l_3741))));
return ((V)(Round((255D * (ToNum(l_3741) - (a_3751 * Max((-1D), Min((k_3750 - 3D), (9D - k_3750), 1D))))))));
return default;
}, 1, "", true);
return ((V)(string.Concat("#", ToStr(Invoke(Invoke(Arr(Call(f_3742, V.Undef, ((V)(0D))), Call(f_3742, V.Undef, ((V)(8D))), Call(f_3742, V.Undef, ((V)(4D)))), "map", Fn((V _self3728, int _argc3752, V v_3758, V _a3755, V _a3756, V _a3757, V[] _rest3753) => {
return Invoke(Invoke(v_3758, "toString", ((V)(16D))), "padStart", ((V)(2D)), ((V)("0")));
}, 1, "", true)), "join", ((V)("")))))));
return default;
}, 1, "hex", false);
lightSrc_84 = Fn((V _self3759, int _argc3760, V I_3766, V k_3767, V _a3764, V _a3765, V[] _rest3761) => {
V E_3768 = default;
if (_self3759.IsNullish) _self3759 = GlobalV;
E_3768 = (Get(I_3766, "E") is var _t3769 && Truthy(_t3769) ? _t3769 : NewObj(0).V);
if (SEqS(k_3767, "head")) {
return Get(E_3768, "skull");
}
if (SEqS(k_3767, "body")) {
return Get(E_3768, "body");
}
if (SEqS(k_3767, "mane")) {
return Get(E_3768, "mane");
}
if (SEqS(k_3767, "tail")) {
return Get(E_3768, "tailF");
}
if ((SEqS(k_3767, "armL") || SEqS(k_3767, "armR"))) {
return (Get(E_3768, "arms") is var _t3770 && !Truthy(_t3770) ? _t3770 : GetIdx(Get(E_3768, "arms"), (SEqS(k_3767, "armL") ? 0D : 1D)));
}
if ((SEqS(k_3767, "footL") || SEqS(k_3767, "footR"))) {
return ((Get(E_3768, "feet") is var _t3771 && !Truthy(_t3771) ? _t3771 : GetIdx(Get(E_3768, "feet"), (SEqS(k_3767, "footL") ? 0D : 1D))) is var _t3772 && !Truthy(_t3772) ? _t3772 : Get(GetIdx(Get(E_3768, "feet"), (SEqS(k_3767, "footL") ? 0D : 1D)), "f"));
}
if ((SEqS(k_3767, "earL") || SEqS(k_3767, "earR"))) {
V e_3773 = default;
e_3773 = Invoke((Get(E_3768, "ears") is var _t3782 && Truthy(_t3782) ? _t3782 : Arr()), "find", Fn((V _self3759, int _argc3774, V x_3780, V _a3777, V _a3778, V _a3779, V[] _rest3775) => {
return (Get(x_3780, "o") is var _t3781 && !Truthy(_t3781) ? _t3781 : (SEq(Get(Get(x_3780, "o"), "parentNode"), GetK(Get(I_3766, "pg"), k_3767)) ? V.True : V.False));
}, 1, "", true));
return (e_3773 is var _t3783 && !Truthy(_t3783) ? _t3783 : Get(e_3773, "o"));
}
return V.Null;
return default;
}, 2, "lightSrc", false);
applyLook_86 = Fn((V _self3784, int _argc3785, V I_3791, V _a3788, V _a3789, V _a3790, V[] _rest3786) => {
V LK_3792 = default;
V L_3793 = default;
if (_self3784.IsNullish) _self3784 = GlobalV;
LK_3792 = (!Get(I_3791, "lookM").IsNullish ? Get(I_3791, "lookM") : ((V)(LOOK_76)));
L_3793 = (Truthy(LK_3792) ? Object_assign(NewObj(0).V, (Get(I_3791, "sceneL") is var _t3794 && Truthy(_t3794) ? _t3794 : LOOK0_74), (GetK(MODES_75, LK_3792) is var _t3795 && Truthy(_t3795) ? _t3795 : NewObj(0).V)) : V.Null);
if (Truthy((L_3793 is var _t3796 && !Truthy(_t3796) ? _t3796 : (SEq(Get(L_3793, "lineC"), V.Null) ? V.True : V.False)))) {
Delete(L_3793, "lineC");
}
if (Truthy(((L_3793 is var _t3797 && !Truthy(_t3797) ? _t3797 : (Get(L_3793, "face").IsNullish ? V.True : V.False)) is var _t3798 && !Truthy(_t3798) ? _t3798 : Invoke(FACE_85, "has", Get(I_3791, "key"))))) {
Set(L_3793, "face", Invoke(FACE_85, "get", Get(I_3791, "key")));
}
Set(I_3791, "curL", L_3793);
if (Truthy(Get(I_3791, "root"))) {
Call(setLight_93, V.Undef, I_3791, L_3793);
}
Set(I_3791, "olDirty", ((V)(1D)));
return default;
}, 1, "applyLook", false);
faceLines_87 = Fn((V _self3799, int _argc3800, V I_3806, V L_3807, V _a3804, V _a3805, V[] _rest3801) => {
V E_3808 = default;
V fw_3809 = default;
V NS_3810 = default;
V one_3811 = default;
if (_self3799.IsNullish) _self3799 = GlobalV;
E_3808 = (Get(I_3806, "E") is var _t3812 && Truthy(_t3812) ? _t3812 : NewObj(0).V);
fw_3809 = ((L_3807 is var _t3813 && !Truthy(_t3813) ? _t3813 : Get(L_3807, "face")) is var _t3814 && Truthy(_t3814) ? _t3814 : ((V)(0D)));
NS_3810 = ((V)("http://www.w3.org/2000/svg"));
Set(I_3806, "faceW", fw_3809);
one_3811 = Fn((V _self3799, int _argc3815, V e_3821, V w_3822, V _a3819, V _a3820, V[] _rest3816) => {
if (!(Truthy(e_3821))) {
return default;
}
if (Truthy(fw_3809)) {
Invoke(e_3821, "setAttribute", ((V)("stroke")), Call(lineOf_81, V.Undef, Call(rgbOf_78, V.Undef, e_3821)));
Invoke(e_3821, "setAttribute", ((V)("stroke-width")), Call(r2_14, V.Undef, w_3822));
Invoke(e_3821, "setAttribute", ((V)("stroke-linejoin")), ((V)("round")));
Invoke(e_3821, "setAttribute", ((V)("paint-order")), ((V)("stroke")));
} else {
Invoke(Arr(((V)("stroke")), ((V)("stroke-width")), ((V)("stroke-linejoin")), ((V)("paint-order"))), "forEach", Fn((V _self3799, int _argc3823, V a_3829, V _a3826, V _a3827, V _a3828, V[] _rest3824) => {
return Invoke(e_3821, "removeAttribute", a_3829);
}, 1, "", true));
}
return default;
}, 2, "", true);
Call(one_3811, V.Undef, Get(E_3808, "nose"), ((V)((ToNum(fw_3809) * 1.7))));
Call(one_3811, V.Undef, Get(E_3808, "mopen"), ((V)((ToNum(fw_3809) * 1.7))));
if (Truthy(Get(E_3808, "muzzle"))) {
Call(one_3811, V.Undef, Get(E_3808, "muzzle"), ((V)((ToNum(fw_3809) * 1.6))));
if (Truthy(fw_3809)) {
Invoke(Get(E_3808, "muzzle"), "setAttribute", ((V)("stroke")), Call(lineOf_81, V.Undef, Call(rgbOf_78, V.Undef, (Get(E_3808, "skull") is var _t3830 && Truthy(_t3830) ? _t3830 : Get(E_3808, "muzzle")))));
Invoke(Get(E_3808, "muzzle"), "setAttribute", ((V)("stroke-opacity")), ((V)("0.5")));
} else {
Invoke(Get(E_3808, "muzzle"), "removeAttribute", ((V)("stroke-opacity")));
}
}
if (Truthy(Get(E_3808, "mouth"))) {
if (Get(I_3806, "mouthW0").IsNullish) {
Set(I_3806, "mouthW0", (Invoke(Get(E_3808, "mouth"), "getAttribute", ((V)("stroke-width"))) is var _t3831 && Truthy(_t3831) ? _t3831 : ((V)("1.2"))));
}
Invoke(Get(E_3808, "mouth"), "setAttribute", ((V)("stroke-width")), (Truthy(fw_3809) ? Call(r2_14, V.Undef, ((V)(Max(ToNum(Get(I_3806, "mouthW0")), (ToNum(Get(I_3806, "mouthW0")) + (ToNum(fw_3809) * 0.55)))))) : Get(I_3806, "mouthW0")));
}
Invoke((Get(E_3808, "eyes") is var _t3850 && Truthy(_t3850) ? _t3850 : Arr()), "forEach", Fn((V _self3799, int _argc3832, V o_3838, V _a3835, V _a3836, V _a3837, V[] _rest3833) => {
if (!(Truthy(Get(o_3838, "e")))) {
return default;
}
if (Truthy(((!(Truthy(Get(o_3838, "ring"))) ? V.True : V.False) is var _t3839 && !Truthy(_t3839) ? _t3839 : fw_3809))) {
Set(o_3838, "ring", Invoke(G("document"), "createElementNS", NS_3810, ((V)("path"))));
Invoke(Arr(((V)("fill")), ((V)("none")), ((V)("stroke-linecap")), ((V)("round")), ((V)("stroke-linejoin")), ((V)("round")), ((V)("pointer-events")), ((V)("none")), ((V)("data-lt")), ((V)("1"))), "reduce", Fn((V _self3799, int _argc3840, V k_3846, V v_3847, V i_3848, V a_3849, V[] _rest3841) => {
if (NumTruthy((ToNum(i_3848) % 2D))) {
Invoke(Get(o_3838, "ring"), "setAttribute", GetIdx(a_3849, (ToNum(i_3848) - 1D)), v_3847);
}
return k_3846;
return default;
}, 4, "", true), ((V)(0D)));
Invoke(Get(o_3838, "e"), "before", Get(o_3838, "ring"));
Set(o_3838, "ringD", V.Null);
}
if (Truthy(Get(o_3838, "ring"))) {
Set(Get(Get(o_3838, "ring"), "style"), "display", ((V)((Truthy(fw_3809) ? "" : "none"))));
Invoke(Get(o_3838, "ring"), "setAttribute", ((V)("stroke")), ((V)("#1c1024")));
}
return default;
}, 1, "", true));
return default;
}, 2, "faceLines", false);
sqSvgPt_88 = Fn((V _self3851, int _argc3852, V e_3858, V x_3859, V y_3860, V _a3857, V[] _rest3853) => {
V s_3861 = default;
V q_3862 = default;
if (_self3851.IsNullish) _self3851 = GlobalV;
s_3861 = Get(e_3858, "ownerSVGElement");
if ((!(Truthy(s_3861)) || !(Truthy(Get(s_3861, "createSVGPoint"))))) {
return New(G("DOMPoint"), x_3859, y_3860);
}
q_3862 = Invoke(s_3861, "createSVGPoint");
Set(q_3862, "x", x_3859);
Set(q_3862, "y", y_3860);
return q_3862;
return default;
}, 3, "sqSvgPt", false);
outlineEls_89 = Fn((V _self3863, int _argc3864, V I_3870, V _a3867, V _a3868, V _a3869, V[] _rest3865) => {
V root_3871 = default;
V els_3872 = default;
V info_3873 = default;
V all_3874 = default;
V late_3875 = default;
V tubes_3876 = default;
V filledT_3877 = default;
V rb_3878 = default;
double RA_3879 = 0;
V each_3880 = default;
V RSE_3881 = default;
V PART_3882 = default;
V roleOf_3883 = default;
V footOf_3884 = default;
V BE_3885 = default;
V fillA_3886 = default;
V @out_3887 = default;
V R0_3888 = default;
V rs_3889 = default;
V grp_3890 = default;
double ci_3891 = 0;
V tb_3892 = default;
if (_self3863.IsNullish) _self3863 = GlobalV;
root_3871 = (Get(I_3870, "root") is var _t3893 && Truthy(_t3893) ? _t3893 : Get(I_3870, "art"));
if (((!(Truthy(root_3871)) || !(Truthy(Get(root_3871, "getCTM")))) || !(Truthy(Invoke(root_3871, "getCTM"))))) {
return V.Null;
}
els_3872 = Invoke(new ArrBuilder().Spread(Invoke(root_3871, "querySelectorAll", ((V)("path,ellipse,circle,rect,polygon")))).V, "filter", Fn((V _self3863, int _argc3894, V e_3900, V _a3897, V _a3898, V _a3899, V[] _rest3895) => {
return (!(Truthy(Invoke(e_3900, "closest", ((V)("defs,clipPath,mask,pattern,[data-lt]"))))) ? V.True : V.False);
}, 1, "", true));
info_3873 = Arr();
all_3874 = Arr();
late_3875 = Arr();
tubes_3876 = Arr();
filledT_3877 = New(G("Set"));
rb_3878 = Invoke(root_3871, "getBoundingClientRect");
RA_3879 = Max(1D, (ToNum(Get(rb_3878, "width")) * ToNum(Get(rb_3878, "height"))));
each_3880 = Arr();
RSE_3881 = Call(Fn((V _self3863, int _argc3901, V q_3907, V _a3904, V _a3905, V _a3906, V[] _rest3902) => {
return (((V)(System.Math.Sqrt(System.Math.Abs(((ToNum(Get(q_3907, "a")) * ToNum(Get(q_3907, "d"))) - (ToNum(Get(q_3907, "b")) * ToNum(Get(q_3907, "c")))))))) is var _t3908 && Truthy(_t3908) ? _t3908 : ((V)(1D)));
}, 1, "", true), V.Undef, Invoke(root_3871, "getCTM"));
PART_3882 = New(G("Set"), Arr(((V)("head")), ((V)("arm")), ((V)("hand")), ((V)("foot")), ((V)("leg")), ((V)("wing")), ((V)("tail")), ((V)("earF")), ((V)("earP")), ((V)("pup"))));
roleOf_3883 = New(G("Map"));
Invoke((Get(I_3870, "items") is var _t3918 && Truthy(_t3918) ? _t3918 : Arr()), "forEach", Fn((V _self3863, int _argc3909, V q_3915, V _a3912, V _a3913, V _a3914, V[] _rest3910) => {
if (Truthy((q_3915 is var _t3916 && !Truthy(_t3916) ? _t3916 : Get(q_3915, "e")))) {
Invoke(roleOf_3883, "set", Get(q_3915, "e"), (Invoke(PART_3882, "has", Get(q_3915, "role")) is var _t3917 && Truthy(_t3917) ? _t3917 : Invoke(PART_3882, "has", Get(q_3915, "pet"))));
}
return default;
}, 1, "", true));
footOf_3884 = New(G("Map"));
BE_3885 = ((!(Truthy(Get(I_3870, "generic"))) ? V.True : V.False) is var _t3919 && !Truthy(_t3919) ? _t3919 : Get(I_3870, "E"));
if (Truthy(BE_3885)) {
Invoke(Invoke(Arr(Get(BE_3885, "skull"), Get(BE_3885, "tailF")), "concat", (Get(BE_3885, "arms") is var _t3927 && Truthy(_t3927) ? _t3927 : Arr()), Invoke((Get(BE_3885, "ears") is var _t3936 && Truthy(_t3936) ? _t3936 : Arr()), "map", Fn((V _self3863, int _argc3928, V x_3934, V _a3931, V _a3932, V _a3933, V[] _rest3929) => {
return (x_3934 is var _t3935 && !Truthy(_t3935) ? _t3935 : Get(x_3934, "o"));
}, 1, "", true))), "forEach", Fn((V _self3863, int _argc3920, V e_3926, V _a3923, V _a3924, V _a3925, V[] _rest3921) => {
if (Truthy(e_3926)) {
Invoke(roleOf_3883, "set", e_3926, (true ? V.True : V.False));
}
return default;
}, 1, "", true));
Invoke((Get(BE_3885, "feet") is var _t3946 && Truthy(_t3946) ? _t3946 : Arr()), "forEach", Fn((V _self3863, int _argc3937, V f_3943, V i_3944, V _a3941, V _a3942, V[] _rest3938) => {
if (Truthy((f_3943 is var _t3945 && !Truthy(_t3945) ? _t3945 : Get(f_3943, "f")))) {
Invoke(roleOf_3883, "set", Get(f_3943, "f"), (true ? V.True : V.False));
Invoke(footOf_3884, "set", Get(f_3943, "f"), ((V)((Truthy(i_3944) ? "footR" : "footL"))));
}
return default;
}, 2, "", true));
if (Truthy(Get(BE_3885, "collar"))) {
Invoke(roleOf_3883, "set", Get(BE_3885, "collar"), (true ? V.True : V.False));
}
}
fillA_3886 = Fn((V _self3863, int _argc3947, V e_3953, V cs_3954, V _a3951, V _a3952, V[] _rest3948) => {
double a_3955 = 0;
V m_3956 = default;
a_3955 = ToNum(Get(cs_3954, "fillOpacity"));
m_3956 = Invoke((Get(cs_3954, "fill") is var _t3957 && Truthy(_t3957) ? _t3957 : ((V)(""))), "match", NewRegExp(RX5, "url\\([\"']?#([^\"')]+)[\"']?\\)", ""));
if (Truthy(m_3956)) {
V svg_3958 = default;
V g_3959 = default;
V st_3960 = default;
svg_3958 = Get(e_3953, "ownerSVGElement");
g_3959 = (svg_3958 is var _t3961 && !Truthy(_t3961) ? _t3961 : Invoke(svg_3958, "querySelector", ((V)(string.Concat("[id=\"", ToStr(GetIdx(m_3956, 1D)), "\"]")))));
st_3960 = (Truthy(g_3959) ? new ArrBuilder().Spread(Invoke(g_3959, "querySelectorAll", ((V)("stop")))).V : Arr());
if (Truthy(Get(st_3960, "length"))) {
a_3955 = (a_3955 * (ToNum(Invoke(st_3960, "reduce", Fn((V _self3863, int _argc3962, V t_3968, V x_3969, V _a3966, V _a3967, V[] _rest3963) => {
return Add(t_3968, ((V)(ToNum(Get(Call(G("getComputedStyle"), V.Undef, x_3969), "stopOpacity")))));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(st_3960, "length"))));
}
}
return ((V)(a_3955));
return default;
}, 2, "", true);
Invoke(els_3872, "forEach", Fn((V _self3863, int _argc3970, V e_3976, V _a3973, V _a3974, V _a3975, V[] _rest3971) => {
V cs_3977 = default;
double op_3978 = 0;
V cl_3979 = default;
V a_3980 = default;
V hid_3981 = default;
V ctm_3982 = default;
double fa_3983 = 0;
V it_3984 = default;
V olg_3985 = default;
V ss_3986 = default;
V r_3987 = default;
cs_3977 = Call(G("getComputedStyle"), V.Undef, e_3976);
if ((!(Truthy(Get(cs_3977, "fill"))) || SEqS(Get(cs_3977, "fill"), "none"))) {
if (Truthy(((((((SEqS(Get(e_3976, "tagName"), "path") ? V.True : V.False) is var _t3988 && !Truthy(_t3988) ? _t3988 : Get(cs_3977, "stroke")) is var _t3989 && !Truthy(_t3989) ? _t3989 : (!SEqS(Get(cs_3977, "stroke"), "none") ? V.True : V.False)) is var _t3990 && !Truthy(_t3990) ? _t3990 : ((!(Truthy(Get(cs_3977, "strokeDasharray"))) || SEqS(Get(cs_3977, "strokeDasharray"), "none")) ? V.True : V.False)) is var _t3991 && !Truthy(_t3991) ? _t3991 : (!(Truthy(Invoke(e_3976, "getAttribute", ((V)("clip-path"))))) ? V.True : V.False)) is var _t3992 && !Truthy(_t3992) ? _t3992 : (!(Truthy(Invoke(e_3976, "getAttribute", ((V)("mask"))))) ? V.True : V.False)))) {
Invoke(tubes_3876, "push", e_3976);
}
return default;
}
if (SEqS(Get(cs_3977, "visibility"), "hidden")) {
return default;
}
op_3978 = (SEqS(Get(cs_3977, "display"), "none") ? 0D : ToNum(Get(cs_3977, "opacity")));
cl_3979 = (!(!(Truthy((Invoke(e_3976, "getAttribute", ((V)("clip-path"))) is var _t3993 && Truthy(_t3993) ? _t3993 : Invoke(e_3976, "getAttribute", ((V)("mask"))))))) ? V.True : V.False);
a_3980 = Get(e_3976, "parentNode");
hid_3981 = (SEqS(Get(cs_3977, "display"), "none") ? V.True : V.False);
while (Truthy(((a_3980 is var _t3994 && !Truthy(_t3994) ? _t3994 : (!SEq(a_3980, root_3871) ? V.True : V.False)) is var _t3995 && !Truthy(_t3995) ? _t3995 : (SEqN(Get(a_3980, "nodeType"), 1D) ? V.True : V.False)))) {
V s2_3996 = default;
if (Truthy(((Invoke(a_3980, "getAttribute", ((V)("clip-path"))) is var _t3997 && Truthy(_t3997) ? _t3997 : Invoke(a_3980, "getAttribute", ((V)("mask")))) is var _t4000 && !Truthy(_t4000) ? _t4000 : (!(Truthy(((BE_3885 is var _t3998 && !Truthy(_t3998) ? _t3998 : Invoke(roleOf_3883, "get", e_3976)) is var _t3999 && !Truthy(_t3999) ? _t3999 : (SEq(Get(a_3980, "parentNode"), root_3871) ? V.True : V.False)))) ? V.True : V.False)))) {
cl_3979 = (true ? V.True : V.False);
}
s2_3996 = Call(G("getComputedStyle"), V.Undef, a_3980);
if (SEqS(Get(s2_3996, "display"), "none")) {
hid_3981 = (true ? V.True : V.False);
break;
}
op_3978 = (op_3978 * ToNum(Get(s2_3996, "opacity")));
a_3980 = Get(a_3980, "parentNode");
}
if (Truthy((hid_3981 is var _t4001 && Truthy(_t4001) ? _t4001 : ((op_3978 < 0.5) ? V.True : V.False)))) {
if (!(Truthy(cl_3979))) {
Invoke(late_3875, "push", e_3976);
}
return default;
}
ctm_3982 = Invoke(e_3976, "getCTM");
if (!(Truthy(ctm_3982))) {
return default;
}
fa_3983 = (ToNum(Call(fillA_3886, V.Undef, e_3976, cs_3977)) * op_3978);
it_3984 = NewObj(4).Put("e", e_3976).Put("ctm", ctm_3982).Put("inv", Invoke(ctm_3982, "inverse")).Put("idx", Get(all_3874, "length")).V;
if ((fa_3983 >= 0.35)) {
Invoke(all_3874, "push", it_3984);
}
olg_3985 = ((!(Truthy(cl_3979)) ? V.True : V.False) is var _t4002 && !Truthy(_t4002) ? _t4002 : Invoke(e_3976, "closest", ((V)("[data-ol]"))));
if (Truthy((olg_3985 is var _t4003 && !Truthy(_t4003) ? _t4003 : ((fa_3983 >= 0.6) ? V.True : V.False)))) {
Invoke(each_3880, "push", NewObj(5).Put("e", e_3976).Put("col", Call(rgbOf_78, V.Undef, e_3976)).Put("sc", (((V)((System.Math.Sqrt(System.Math.Abs(((ToNum(Get(ctm_3982, "a")) * ToNum(Get(ctm_3982, "d"))) - (ToNum(Get(ctm_3982, "b")) * ToNum(Get(ctm_3982, "c")))))) / ToNum(RSE_3881)))) is var _t4004 && Truthy(_t4004) ? _t4004 : ((V)(1D)))).Put("forced", (true ? V.True : V.False)).Put("k", (((V)(ToNum(Invoke(olg_3985, "getAttribute", ((V)("data-ol")))))) is var _t4005 && Truthy(_t4005) ? _t4005 : ((V)(1D)))).V);
return default;
}
ss_3986 = (((((!(Truthy(cl_3979)) && (fa_3983 >= 0.6)) ? V.True : V.False) is var _t4006 && !Truthy(_t4006) ? _t4006 : Get(cs_3977, "stroke")) is var _t4007 && !Truthy(_t4007) ? _t4007 : (!SEqS(Get(cs_3977, "stroke"), "none") ? V.True : V.False)) is var _t4008 && !Truthy(_t4008) ? _t4008 : (SEq(Get(cs_3977, "stroke"), Get(cs_3977, "fill")) ? V.True : V.False));
if (Truthy(ss_3986)) {
Set(it_3984, "ss", ((V)(1D)));
}
if (Truthy(((cl_3979 is var _t4009 && Truthy(_t4009) ? _t4009 : ((fa_3983 < 0.6) ? V.True : V.False)) is var _t4012 && Truthy(_t4012) ? _t4012 : ((Get(cs_3977, "stroke") is var _t4010 && !Truthy(_t4010) ? _t4010 : (!SEqS(Get(cs_3977, "stroke"), "none") ? V.True : V.False)) is var _t4011 && !Truthy(_t4011) ? _t4011 : (!(Truthy(ss_3986)) ? V.True : V.False))))) {
return default;
}
r_3987 = Invoke(e_3976, "getBoundingClientRect");
if (((ToNum(Get(r_3987, "width")) * ToNum(Get(r_3987, "height"))) < (RA_3879 * 0.004))) {
return default;
}
Invoke(info_3873, "push", it_3984);
return default;
}, 1, "", true));
@out_3887 = Arr();
R0_3888 = Invoke(root_3871, "getCTM");
rs_3889 = (((V)(System.Math.Sqrt(System.Math.Abs(((ToNum(Get(R0_3888, "a")) * ToNum(Get(R0_3888, "d"))) - (ToNum(Get(R0_3888, "b")) * ToNum(Get(R0_3888, "c")))))))) is var _t4013 && Truthy(_t4013) ? _t4013 : ((V)(1D)));
Invoke(info_3873, "forEach", Fn((V _self3863, int _argc4014, V it_4020, V i_4021, V _a4018, V _a4019, V[] _rest4015) => {
V len_4022 = default;
V bb_4023 = default;
double N_4024 = 0;
double cov_4025 = 0;
V under_4026 = default;
V bx_4027 = default;
V by_4028 = default;
len_4022 = ((V)(0D));
bb_4023 = V.Null;
try {
len_4022 = Invoke(Get(it_4020, "e"), "getTotalLength");
bb_4023 = Invoke(Get(it_4020, "e"), "getBBox");
} catch (System.Exception _ex4029) {
V x_4030 = default;
x_4030 = Caught(_ex4029);

}
if ((!(Truthy(len_4022)) || !(Truthy(bb_4023)))) {
return default;
}
N_4024 = 28D;
cov_4025 = 0D;
under_4026 = Invoke(all_3874, "slice", ((V)(0D)), Get(it_4020, "idx"));
bx_4027 = Add(Get(bb_4023, "x"), ((V)((ToNum(Get(bb_4023, "width")) / 2D))));
by_4028 = Add(Get(bb_4023, "y"), ((V)((ToNum(Get(bb_4023, "height")) / 2D))));
{
double j_4031 = 0;
j_4031 = 0D;
while (true) {
if (!((j_4031 < N_4024))) break;
V p0_4033 = default;
double vx_4034 = 0;
double vy_4035 = 0;
V vl_4036 = default;
double nd_4037 = 0;
V sp_4038 = default;
p0_4033 = Invoke(Get(it_4020, "e"), "getPointAtLength", ((V)(((ToNum(len_4022) * (j_4031 + 0.5)) / N_4024))));
vx_4034 = (ToNum(bx_4027) - ToNum(Get(p0_4033, "x")));
vy_4035 = (ToNum(by_4028) - ToNum(Get(p0_4033, "y")));
vl_4036 = (((V)(Hypot(vx_4034, vy_4035))) is var _t4039 && Truthy(_t4039) ? _t4039 : ((V)(1D)));
nd_4037 = Min(1.2, (ToNum(vl_4036) * 0.5));
sp_4038 = Invoke(New(G("DOMPoint"), Add(Get(p0_4033, "x"), ((V)(((vx_4034 / ToNum(vl_4036)) * nd_4037)))), Add(Get(p0_4033, "y"), ((V)(((vy_4035 / ToNum(vl_4036)) * nd_4037))))), "matrixTransform", Get(it_4020, "ctm"));
{
double k_4040 = 0;
k_4040 = 0D;
while (true) {
if (!(Lt(((V)(k_4040)), Get(under_4026, "length")))) break;
V lp_4042 = default;
if (Truthy(((Get(it_4020, "ss") is var _t4043 && !Truthy(_t4043) ? _t4043 : Get(GetIdx(under_4026, k_4040), "ss")) is var _t4044 && !Truthy(_t4044) ? _t4044 : (SEq(Get(Get(GetIdx(under_4026, k_4040), "e"), "parentNode"), Get(Get(it_4020, "e"), "parentNode")) ? V.True : V.False)))) {
goto _cont4041;
}
lp_4042 = Invoke(sp_4038, "matrixTransform", Get(GetIdx(under_4026, k_4040), "inv"));
if (Truthy(Invoke(Get(GetIdx(under_4026, k_4040), "e"), "isPointInFill", Call(sqSvgPt_88, V.Undef, Get(GetIdx(under_4026, k_4040), "e"), Get(lp_4042, "x"), Get(lp_4042, "y"))))) {
cov_4025++;
break;
}
_cont4041: ;
k_4040++;
}
}
j_4031++;
}
}
if (Truthy(Get(it_4020, "ss"))) {
if (Truthy(((((cov_4025 / N_4024) < 0.88) ? V.True : V.False) is var _t4045 && Truthy(_t4045) ? _t4045 : Invoke(roleOf_3883, "get", Get(it_4020, "e"))))) {
Invoke(tubes_3876, "push", Get(it_4020, "e"));
Invoke(filledT_3877, "add", Get(it_4020, "e"));
}
return default;
}
if (Truthy(((((cov_4025 / N_4024) < 0.88) ? V.True : V.False) is var _t4046 && Truthy(_t4046) ? _t4046 : Invoke(roleOf_3883, "get", Get(it_4020, "e"))))) {
Invoke(@out_3887, "push", NewObj(5).Put("e", Get(it_4020, "e")).Put("col", Call(rgbOf_78, V.Undef, Get(it_4020, "e"))).Put("sc", (((V)((System.Math.Sqrt(System.Math.Abs(((ToNum(Get(Get(it_4020, "ctm"), "a")) * ToNum(Get(Get(it_4020, "ctm"), "d"))) - (ToNum(Get(Get(it_4020, "ctm"), "b")) * ToNum(Get(Get(it_4020, "ctm"), "c")))))) / ToNum(rs_3889)))) is var _t4047 && Truthy(_t4047) ? _t4047 : ((V)(1D)))).Put("forced", (((cov_4025 / N_4024) >= 0.88) ? V.True : V.False)).Put("ft", Invoke(footOf_3884, "get", Get(it_4020, "e"))).V);
}
return default;
}, 2, "", true));
grp_3890 = New(G("Map"));
Invoke(@out_3887, "forEach", Fn((V _self3863, int _argc4048, V o_4054, V _a4051, V _a4052, V _a4053, V[] _rest4049) => {
V k_4055 = default;
k_4055 = ((V)(string.Concat(ToStr(((Get(Get(o_4054, "e"), "parentNode") is var _t4056 && !Truthy(_t4056) ? _t4056 : Get(Get(Get(o_4054, "e"), "parentNode"), "__olk")) is var _t4057 && Truthy(_t4057) ? _t4057 : Set(Get(Get(o_4054, "e"), "parentNode"), "__olk", Invoke(G("Math"), "random")))), ":", ToStr(Invoke(Invoke(Get(o_4054, "col"), "map", Fn((V _self3863, int _argc4058, V v_4064, V _a4061, V _a4062, V _a4063, V[] _rest4059) => {
return ((V)(Round((ToNum(v_4064) / 22D))));
}, 1, "", true)), "join", ((V)(",")))))));
Invoke((Invoke(grp_3890, "get", k_4055) is var _t4065 && Truthy(_t4065) ? _t4065 : Invoke(Invoke(grp_3890, "set", k_4055, Arr()), "get", k_4055)), "push", o_4054);
return default;
}, 1, "", true));
ci_3891 = 0D;
Invoke(grp_3890, "forEach", Fn((V _self3863, int _argc4066, V list_4072, V _a4069, V _a4070, V _a4071, V[] _rest4067) => {
if (GeN(Get(list_4072, "length"), 5D)) {
ci_3891++;
Invoke(list_4072, "forEach", Fn((V _self3863, int _argc4073, V o_4079, V _a4076, V _a4077, V _a4078, V[] _rest4074) => {
Set(o_4079, "cl", ((V)(ci_3891)));
return default;
}, 1, "", true));
}
return default;
}, 1, "", true));
Invoke(each_3880, "forEach", Fn((V _self3863, int _argc4080, V o_4086, V _a4083, V _a4084, V _a4085, V[] _rest4081) => {
return Invoke(@out_3887, "push", o_4086);
}, 1, "", true));
tb_3892 = Invoke(tubes_3876, "map", Fn((V _self3863, int _argc4087, V e_4093, V _a4090, V _a4091, V _a4092, V[] _rest4088) => {
V cs_4094 = default;
V c_4095 = default;
V fl_4096 = default;
cs_4094 = Call(G("getComputedStyle"), V.Undef, e_4093);
c_4095 = Invoke(e_4093, "getCTM");
fl_4096 = Invoke(filledT_3877, "has", e_4093);
return NewObj(7).Put("e", e_4093).Put("fl", fl_4096).Put("sw0", (((V)(ParseFloat(Get(cs_4094, "strokeWidth")))) is var _t4097 && Truthy(_t4097) ? _t4097 : ((V)((Truthy(fl_4096) ? 0D : 1D))))).Put("cap", (Get(cs_4094, "strokeLinecap") is var _t4098 && Truthy(_t4098) ? _t4098 : ((V)("round")))).Put("join", (Get(cs_4094, "strokeLinejoin") is var _t4099 && Truthy(_t4099) ? _t4099 : ((V)("round")))).Put("col", (Truthy(fl_4096) ? Call(rgbOf_78, V.Undef, e_4093) : (Call(rgbP_77, V.Undef, Get(cs_4094, "stroke")) is var _t4100 && Truthy(_t4100) ? _t4100 : Arr(((V)(180D)), ((V)(120D)), ((V)(80D)))))).Put("sc", (Truthy(c_4095) ? (((V)((System.Math.Sqrt(System.Math.Abs(((ToNum(Get(c_4095, "a")) * ToNum(Get(c_4095, "d"))) - (ToNum(Get(c_4095, "b")) * ToNum(Get(c_4095, "c")))))) / ToNum(rs_3889)))) is var _t4101 && Truthy(_t4101) ? _t4101 : ((V)(1D))) : ((V)(1D)))).V;
return default;
}, 1, "", true));
return NewObj(3).Put("out", @out_3887).Put("late", late_3875).Put("tubes", tb_3892).V;
return default;
}, 1, "outlineEls", false);
outline_91 = Fn((V _self4102, int _argc4103, V I_4109, V _a4106, V _a4107, V _a4108, V[] _rest4104) => {
V L_4110 = default;
V lw_4111 = default;
V stk_4112 = default;
if (_self4102.IsNullish) _self4102 = GlobalV;
if (Truthy((Get(I_4109, "generic") is var _t4113 && !Truthy(_t4113) ? _t4113 : (!(Truthy(Get(I_4109, "ready"))) ? V.True : V.False)))) {
return default;
}
if ((!(Truthy(Get(I_4109, "olEls"))) && !(Truthy((Get(I_4109, "curL") is var _t4114 && !Truthy(_t4114) ? _t4114 : Get(Get(I_4109, "curL"), "line")))))) {
Set(I_4109, "olDirty", ((V)(0D)));
return default;
}
if (!(Truthy(Get(I_4109, "olEls")))) {
V r_4115 = default;
r_4115 = Call(outlineEls_89, V.Undef, I_4109);
if (!(Truthy(r_4115))) {
return default;
}
Set(I_4109, "olEls", Get(r_4115, "out"));
Set(I_4109, "olLate", Get(r_4115, "late"));
Set(I_4109, "olTubes", Get(r_4115, "tubes"));
Set(I_4109, "olN", ((V)(0D)));
}
L_4110 = Get(I_4109, "curL");
lw_4111 = ((L_4110 is var _t4116 && !Truthy(_t4116) ? _t4116 : Get(L_4110, "line")) is var _t4117 && Truthy(_t4117) ? _t4117 : ((V)(0D)));
Set(I_4109, "olDirty", ((V)(0D)));
if (!(Truthy(Get(I_4109, "generic")))) {
Call(faceLines_87, V.Undef, I_4109, L_4110);
}
Invoke(Get(I_4109, "olEls"), "forEach", Fn((V _self4102, int _argc4118, V o_4124, V _a4121, V _a4122, V _a4123, V[] _rest4119) => {
V e_4125 = default;
e_4125 = Get(o_4124, "e");
if (Truthy(Get(o_4124, "cl"))) {
V g_4126 = default;
g_4126 = GetK((Get(I_4109, "olCl") is var _t4127 && Truthy(_t4127) ? _t4127 : Set(I_4109, "olCl", NewObj(0).V)), Get(o_4124, "cl"));
if (!(Truthy(g_4126))) {
g_4126 = SetK(Get(I_4109, "olCl"), Get(o_4124, "cl"), Invoke(G("document"), "createElementNS", SVGNS_90, ((V)("g"))));
Invoke(g_4126, "setAttribute", ((V)("data-lt")), ((V)(1D)));
Invoke(g_4126, "setAttribute", ((V)("pointer-events")), ((V)("none")));
Invoke(e_4125, "before", g_4126);
}
if (!(Truthy(Get(o_4124, "use")))) {
if (!(Truthy(Get(e_4125, "id")))) {
Set(e_4125, "id", ((V)(string.Concat("olc", ToStr((Get(I_4109, "u") is var _t4128 && Truthy(_t4128) ? _t4128 : ((V)("")))), "_", ToStr(Invoke(Invoke(Invoke(G("Math"), "random"), "toString", ((V)(36D))), "slice", ((V)(2D)), ((V)(8D))))))));
}
Set(o_4124, "use", Invoke(G("document"), "createElementNS", SVGNS_90, ((V)("use"))));
Invoke(Get(o_4124, "use"), "setAttribute", ((V)("href")), ((V)(string.Concat("#", ToStr(Get(e_4125, "id"))))));
Invoke(g_4126, "appendChild", Get(o_4124, "use"));
}
Set(Get(g_4126, "style"), "display", ((V)((Truthy(lw_4111) ? "" : "none"))));
if (Truthy(lw_4111)) {
Invoke(g_4126, "setAttribute", ((V)("stroke")), (Get(L_4110, "lineC") is var _t4129 && Truthy(_t4129) ? _t4129 : Call(lineOf_81, V.Undef, Get(o_4124, "col"))));
Invoke(g_4126, "setAttribute", ((V)("stroke-width")), Call(r2_14, V.Undef, ((V)(((ToNum(lw_4111) * 2D) / ToNum(Get(o_4124, "sc")))))));
Invoke(g_4126, "setAttribute", ((V)("stroke-linejoin")), ((V)("round")));
}
return default;
}
if (Truthy(Get(o_4124, "ft"))) {
Invoke(Arr(((V)("stroke")), ((V)("stroke-width")), ((V)("stroke-linejoin")), ((V)("paint-order"))), "forEach", Fn((V _self4102, int _argc4130, V a_4136, V _a4133, V _a4134, V _a4135, V[] _rest4131) => {
return Invoke(e_4125, "removeAttribute", a_4136);
}, 1, "", true));
if (!(Truthy(Get(o_4124, "fo")))) {
Set(o_4124, "fo", Invoke(G("document"), "createElementNS", SVGNS_90, ((V)("path"))));
Invoke(Get(o_4124, "fo"), "setAttribute", ((V)("fill")), ((V)("none")));
Invoke(Get(o_4124, "fo"), "setAttribute", ((V)("stroke-linejoin")), ((V)("round")));
Invoke(Get(o_4124, "fo"), "setAttribute", ((V)("data-lt")), ((V)(1D)));
Invoke(Get(o_4124, "fo"), "setAttribute", ((V)("pointer-events")), ((V)("none")));
Invoke(e_4125, "before", Get(o_4124, "fo"));
}
Set(Get(Get(o_4124, "fo"), "style"), "display", ((V)((Truthy(lw_4111) ? "" : "none"))));
Set(o_4124, "fd", V.Null);
if (Truthy(lw_4111)) {
Invoke(Get(o_4124, "fo"), "setAttribute", ((V)("stroke")), (Get(L_4110, "lineC") is var _t4137 && Truthy(_t4137) ? _t4137 : Call(lineOf_81, V.Undef, Get(o_4124, "col"))));
Invoke(Get(o_4124, "fo"), "setAttribute", ((V)("stroke-width")), Call(r2_14, V.Undef, ((V)(((ToNum(lw_4111) * 2D) / ToNum(Get(o_4124, "sc")))))));
}
return default;
}
if (Truthy(lw_4111)) {
Invoke(e_4125, "setAttribute", ((V)("stroke")), (Get(L_4110, "lineC") is var _t4138 && Truthy(_t4138) ? _t4138 : Call(lineOf_81, V.Undef, Get(o_4124, "col"))));
Invoke(e_4125, "setAttribute", ((V)("stroke-width")), Call(r2_14, V.Undef, ((V)((((ToNum(lw_4111) * 2D) * ToNum((Get(o_4124, "k") is var _t4139 && Truthy(_t4139) ? _t4139 : ((V)(1D))))) / ToNum(Get(o_4124, "sc")))))));
Invoke(e_4125, "setAttribute", ((V)("stroke-linejoin")), ((V)("round")));
Invoke(e_4125, "setAttribute", ((V)("paint-order")), ((V)("stroke")));
} else {
Invoke(Arr(((V)("stroke")), ((V)("stroke-width")), ((V)("stroke-linejoin")), ((V)("paint-order"))), "forEach", Fn((V _self4102, int _argc4140, V a_4146, V _a4143, V _a4144, V _a4145, V[] _rest4141) => {
return Invoke(e_4125, "removeAttribute", a_4146);
}, 1, "", true));
}
return default;
}, 1, "", true));
if (Truthy(((!(Truthy(Get(I_4109, "generic"))) ? V.True : V.False) is var _t4147 && !Truthy(_t4147) ? _t4147 : Get(I_4109, "E")))) {
Invoke((Get(Get(I_4109, "E"), "ears") is var _t4163 && Truthy(_t4163) ? _t4163 : Arr()), "forEach", Fn((V _self4102, int _argc4148, V x_4154, V _a4151, V _a4152, V _a4153, V[] _rest4149) => {
return Invoke((Get(x_4154, "mk") is var _t4162 && Truthy(_t4162) ? _t4162 : Arr()), "forEach", Fn((V _self4102, int _argc4155, V m_4161, V _a4158, V _a4159, V _a4160, V[] _rest4156) => {
if (Truthy(lw_4111)) {
Invoke(m_4161, "setAttribute", ((V)("stroke")), ((V)("#000")));
Invoke(m_4161, "setAttribute", ((V)("stroke-width")), Call(r2_14, V.Undef, ((V)((ToNum(lw_4111) * 2D)))));
Invoke(m_4161, "setAttribute", ((V)("stroke-linejoin")), ((V)("round")));
} else {
Invoke(m_4161, "removeAttribute", ((V)("stroke")));
}
return default;
}, 1, "", true));
}, 1, "", true));
}
stk_4112 = (Get(I_4109, "olStk") is var _t4164 && Truthy(_t4164) ? _t4164 : Set(I_4109, "olStk", New(G("Map"))));
Invoke((Get(I_4109, "olTubes") is var _t4175 && Truthy(_t4175) ? _t4175 : Arr()), "forEach", Fn((V _self4102, int _argc4165, V t_4171, V _a4168, V _a4169, V _a4170, V[] _rest4166) => {
V par_4172 = default;
V S_4173 = default;
if (!(Truthy(Get(t_4171, "fl")))) {
return default;
}
par_4172 = Get(Get(t_4171, "e"), "parentNode");
if (!(Truthy(par_4172))) {
return default;
}
S_4173 = Invoke(stk_4112, "get", par_4172);
if (!(Truthy(S_4173))) {
V g_4174 = default;
g_4174 = Get(par_4172, "__olTube");
if ((!(Truthy(g_4174)) || !SEq(Get(g_4174, "parentNode"), par_4172))) {
g_4174 = Set(par_4172, "__olTube", Invoke(G("document"), "createElementNS", SVGNS_90, ((V)("g"))));
Invoke(g_4174, "setAttribute", ((V)("data-lt")), ((V)(1D)));
Invoke(g_4174, "setAttribute", ((V)("pointer-events")), ((V)("none")));
Invoke(g_4174, "setAttribute", ((V)("fill")), ((V)("none")));
Invoke(par_4172, "insertBefore", g_4174, Get(par_4172, "firstChild"));
}
S_4173 = NewObj(3).Put("par", par_4172).Put("ts", Arr()).Put("p", Invoke(G("document"), "createElementNS", SVGNS_90, ((V)("path")))).V;
Invoke(Get(S_4173, "p"), "setAttribute", ((V)("stroke-linecap")), ((V)("round")));
Invoke(Get(S_4173, "p"), "setAttribute", ((V)("stroke-linejoin")), ((V)("round")));
Set(Get(Get(S_4173, "p"), "style"), "display", ((V)("none")));
Invoke(g_4174, "appendChild", Get(S_4173, "p"));
Invoke(stk_4112, "set", par_4172, S_4173);
}
if (LtN(Invoke(Get(S_4173, "ts"), "indexOf", t_4171), 0D)) {
Invoke(Get(S_4173, "ts"), "push", t_4171);
}
return default;
}, 1, "", true));
Invoke(stk_4112, "forEach", Fn((V _self4102, int _argc4176, V S_4182, V _a4179, V _a4180, V _a4181, V[] _rest4177) => {
Invoke(Get(S_4182, "p"), "setAttribute", ((V)("stroke")), ((L_4110 is var _t4183 && !Truthy(_t4183) ? _t4183 : Get(L_4110, "lineC")) is var _t4184 && Truthy(_t4184) ? _t4184 : Call(lineOf_81, V.Undef, Get(GetIdx(Get(S_4182, "ts"), 0D), "col"))));
Set(S_4182, "d", Set(S_4182, "w", Set(S_4182, "o", Set(S_4182, "tr", V.Undef))));
if (!(Truthy(lw_4111))) {
Set(Get(Get(S_4182, "p"), "style"), "display", ((V)("none")));
}
return default;
}, 1, "", true));
Invoke((Get(I_4109, "olTubes") is var _t4197 && Truthy(_t4197) ? _t4197 : Arr()), "forEach", Fn((V _self4102, int _argc4185, V t_4191, V _a4188, V _a4189, V _a4190, V[] _rest4186) => {
V par_4192 = default;
par_4192 = Get(Get(t_4191, "e"), "parentNode");
if (Truthy(((!(Truthy(par_4192)) ? V.True : V.False) is var _t4193 && Truthy(_t4193) ? _t4193 : Get(t_4191, "fl")))) {
return default;
}
if (!(Truthy(Get(t_4191, "p")))) {
V g_4194 = default;
g_4194 = Get(par_4192, "__olTube");
if ((!(Truthy(g_4194)) || !SEq(Get(g_4194, "parentNode"), par_4192))) {
g_4194 = Set(par_4192, "__olTube", Invoke(G("document"), "createElementNS", SVGNS_90, ((V)("g"))));
Invoke(g_4194, "setAttribute", ((V)("data-lt")), ((V)(1D)));
Invoke(g_4194, "setAttribute", ((V)("pointer-events")), ((V)("none")));
Invoke(g_4194, "setAttribute", ((V)("fill")), ((V)("none")));
Invoke(par_4192, "insertBefore", g_4194, Get(par_4192, "firstChild"));
}
Set(t_4191, "p", Invoke(G("document"), "createElementNS", SVGNS_90, ((V)("path"))));
Invoke(Get(t_4191, "p"), "setAttribute", ((V)("stroke-linecap")), Get(t_4191, "cap"));
Invoke(Get(t_4191, "p"), "setAttribute", ((V)("stroke-linejoin")), Get(t_4191, "join"));
Set(Get(Get(t_4191, "p"), "style"), "display", ((V)("none")));
Invoke(g_4194, "appendChild", Get(t_4191, "p"));
Set(t_4191, "d", Set(t_4191, "w", Set(t_4191, "o", Set(t_4191, "tr", V.Null))));
}
Invoke(Get(t_4191, "p"), "setAttribute", ((V)("stroke")), ((L_4110 is var _t4195 && !Truthy(_t4195) ? _t4195 : Get(L_4110, "lineC")) is var _t4196 && Truthy(_t4196) ? _t4196 : Call(lineOf_81, V.Undef, Get(t_4191, "col"))));
Set(t_4191, "w", V.Null);
if (!(Truthy(lw_4111))) {
Set(Get(Get(t_4191, "p"), "style"), "display", ((V)("none")));
}
return default;
}, 1, "", true));
return default;
}, 1, "outline", false);
outlineTick_92 = Fn((V _self4198, int _argc4199, V I_4205, V _a4202, V _a4203, V _a4204, V[] _rest4200) => {
V L_4206 = default;
V lw_4207 = default;
if (_self4198.IsNullish) _self4198 = GlobalV;
L_4206 = Get(I_4205, "curL");
lw_4207 = ((L_4206 is var _t4208 && !Truthy(_t4208) ? _t4208 : Get(L_4206, "line")) is var _t4209 && Truthy(_t4209) ? _t4209 : ((V)(0D)));
if ((!(Truthy(lw_4207)) || !(Truthy(Get(I_4205, "olEls"))))) {
return default;
}
if (!(Truthy(Get(I_4205, "generic")))) {
V pb_4210 = default;
pb_4210 = Get(Get(I_4205, "pg"), "body");
Invoke(Get(I_4205, "olEls"), "forEach", Fn((V _self4198, int _argc4211, V o_4217, V _a4214, V _a4215, V _a4216, V[] _rest4212) => {
V e_4218 = default;
V pf_4219 = default;
V vis_4220 = default;
V d_4221 = default;
if (!(Truthy(Get(o_4217, "fo")))) {
return default;
}
e_4218 = Get(o_4217, "e");
pf_4219 = GetK(Get(I_4205, "pg"), Get(o_4217, "ft"));
vis_4220 = ((Get(e_4218, "isConnected") is var _t4222 && !Truthy(_t4222) ? _t4222 : (!SEqS(Get(Get(e_4218, "style"), "display"), "none") ? V.True : V.False)) is var _t4223 && !Truthy(_t4223) ? _t4223 : (!SEqS(Invoke(e_4218, "getAttribute", ((V)("opacity"))), "0") ? V.True : V.False));
if (!(Truthy(vis_4220))) {
if (!SEqS(Get(Get(Get(o_4217, "fo"), "style"), "display"), "none")) {
Set(Get(Get(o_4217, "fo"), "style"), "display", ((V)("none")));
}
return default;
}
if (SEqS(Get(Get(Get(o_4217, "fo"), "style"), "display"), "none")) {
Set(Get(Get(o_4217, "fo"), "style"), "display", ((V)("")));
}
if (Truthy(((pb_4210 is var _t4224 && !Truthy(_t4224) ? _t4224 : pf_4219) is var _t4225 && !Truthy(_t4225) ? _t4225 : ((V)(((double)(ToInt32(ToNum(Invoke(pb_4210, "compareDocumentPosition", pf_4219))) & ToInt32(4D)))))))) {
V g_4226 = default;
V po_4227 = default;
g_4226 = Get(I_4205, "olFootG");
if ((!(Truthy(g_4226)) || !SEq(Get(g_4226, "parentNode"), pb_4210))) {
g_4226 = Set(I_4205, "olFootG", Invoke(G("document"), "createElementNS", SVGNS_90, ((V)("g"))));
Invoke(g_4226, "setAttribute", ((V)("data-lt")), ((V)(1D)));
Invoke(g_4226, "setAttribute", ((V)("pointer-events")), ((V)("none")));
}
if (!SEq(Get(pb_4210, "firstChild"), g_4226)) {
Invoke(pb_4210, "insertBefore", g_4226, Get(pb_4210, "firstChild"));
}
if (!SEq(Get(Get(o_4217, "fo"), "parentNode"), g_4226)) {
Invoke(g_4226, "appendChild", Get(o_4217, "fo"));
}
po_4227 = Invoke(pf_4219, "getAttribute", ((V)("opacity")));
if (!SEq(Get(o_4217, "po"), po_4227)) {
Set(o_4217, "po", po_4227);
if (po_4227.IsNullish) {
Invoke(Get(o_4217, "fo"), "removeAttribute", ((V)("opacity")));
} else {
Invoke(Get(o_4217, "fo"), "setAttribute", ((V)("opacity")), po_4227);
}
}
} else {
if (!SEq(Get(Get(o_4217, "fo"), "nextSibling"), e_4218)) {
Invoke(e_4218, "before", Get(o_4217, "fo"));
}
if (!Get(o_4217, "po").IsNullish) {
Set(o_4217, "po", V.Null);
Invoke(Get(o_4217, "fo"), "removeAttribute", ((V)("opacity")));
}
}
d_4221 = (Invoke(e_4218, "getAttribute", ((V)("d"))) is var _t4228 && Truthy(_t4228) ? _t4228 : ((V)("")));
if (!SEq(Get(o_4217, "fd"), d_4221)) {
Set(o_4217, "fd", d_4221);
Invoke(Get(o_4217, "fo"), "setAttribute", ((V)("d")), d_4221);
}
return default;
}, 1, "", true));
}
if (Truthy(Get(I_4205, "olStk"))) {
Invoke(Get(I_4205, "olStk"), "forEach", Fn((V _self4198, int _argc4229, V S_4235, V _a4232, V _a4233, V _a4234, V[] _rest4230) => {
V d_4236 = default;
V w_4237 = default;
V o_4238 = default;
V tr_4239 = default;
double f_4240 = 0;
V g_4241 = default;
d_4236 = ((V)(""));
w_4237 = ((V)(0D));
o_4238 = V.Null;
tr_4239 = V.Null;
f_4240 = 1D;
{
foreach (V _k4242 in Iterate(Get(S_4235, "ts"))) {
V t_4243 = default;
t_4243 = _k4242;
V e_4244 = default;
V op_4245 = default;
V dd_4246 = default;
V swA_4247 = default;
V sw_4248 = default;
e_4244 = Get(t_4243, "e");
if (((!(Truthy(Get(e_4244, "isConnected"))) || !SEq(Get(e_4244, "parentNode"), Get(S_4235, "par"))) || SEqS(Get(Get(e_4244, "style"), "display"), "none"))) {
continue;
}
op_4245 = Invoke(e_4244, "getAttribute", ((V)("opacity")));
dd_4246 = Invoke(e_4244, "getAttribute", ((V)("d")));
if ((SEqS(op_4245, "0") || !(Truthy(dd_4246)))) {
continue;
}
d_4236 = ((V)(string.Concat(ToStr(d_4236), ToStr(dd_4246), " ")));
swA_4247 = Invoke(e_4244, "getAttribute", ((V)("stroke-width")));
sw_4248 = Add((!swA_4247.IsNullish ? ((V)(ParseFloat(swA_4247))) : Get(t_4243, "sw0")), ((V)(((2D * ToNum(lw_4207)) / ToNum(Get(t_4243, "sc"))))));
if (Gt(sw_4248, w_4237)) {
w_4237 = sw_4248;
}
if (NumTruthy(f_4240)) {
f_4240 = 0D;
o_4238 = op_4245;
tr_4239 = Invoke(e_4244, "getAttribute", ((V)("transform")));
}
}
}
if (!(Truthy(d_4236))) {
if (!SEqS(Get(Get(Get(S_4235, "p"), "style"), "display"), "none")) {
Set(Get(Get(S_4235, "p"), "style"), "display", ((V)("none")));
}
return default;
}
if (SEqS(Get(Get(Get(S_4235, "p"), "style"), "display"), "none")) {
Set(Get(Get(S_4235, "p"), "style"), "display", ((V)("")));
}
g_4241 = Get(Get(S_4235, "p"), "parentNode");
if (Truthy((g_4241 is var _t4249 && !Truthy(_t4249) ? _t4249 : (!SEq(Get(Get(S_4235, "par"), "firstChild"), g_4241) ? V.True : V.False)))) {
Invoke(Get(S_4235, "par"), "insertBefore", g_4241, Get(Get(S_4235, "par"), "firstChild"));
}
if (!SEq(Get(S_4235, "d"), d_4236)) {
Set(S_4235, "d", d_4236);
Invoke(Get(S_4235, "p"), "setAttribute", ((V)("d")), d_4236);
}
w_4237 = Call(r2_14, V.Undef, w_4237);
if (!SEq(Get(S_4235, "w"), w_4237)) {
Set(S_4235, "w", w_4237);
Invoke(Get(S_4235, "p"), "setAttribute", ((V)("stroke-width")), w_4237);
}
if (!SEq(Get(S_4235, "o"), o_4238)) {
Set(S_4235, "o", o_4238);
if (o_4238.IsNullish) {
Invoke(Get(S_4235, "p"), "removeAttribute", ((V)("opacity")));
} else {
Invoke(Get(S_4235, "p"), "setAttribute", ((V)("opacity")), o_4238);
}
}
if (!SEq(Get(S_4235, "tr"), tr_4239)) {
Set(S_4235, "tr", tr_4239);
if (tr_4239.IsNullish) {
Invoke(Get(S_4235, "p"), "removeAttribute", ((V)("transform")));
} else {
Invoke(Get(S_4235, "p"), "setAttribute", ((V)("transform")), tr_4239);
}
}
return default;
}, 1, "", true));
}
Invoke((Get(I_4205, "olTubes") is var _t4270 && Truthy(_t4270) ? _t4270 : Arr()), "forEach", Fn((V _self4198, int _argc4250, V t_4256, V _a4253, V _a4254, V _a4255, V[] _rest4251) => {
V e_4257 = default;
V swA_4258 = default;
V sw_4259 = default;
V op_4260 = default;
V par_4261 = default;
V d_4262 = default;
V w_4263 = default;
V tr_4264 = default;
if (!(Truthy(Get(t_4256, "p")))) {
return default;
}
e_4257 = Get(t_4256, "e");
swA_4258 = Invoke(e_4257, "getAttribute", ((V)("stroke-width")));
sw_4259 = (!swA_4258.IsNullish ? ((V)(ParseFloat(swA_4258))) : Get(t_4256, "sw0"));
op_4260 = Invoke(e_4257, "getAttribute", ((V)("opacity")));
if ((((SEqS(Get(Get(e_4257, "style"), "display"), "none") || SEqS(op_4260, "0")) || !(Truthy((Get(t_4256, "fl") is var _t4265 && Truthy(_t4265) ? _t4265 : (GeN(sw_4259, 3D) ? V.True : V.False))))) || !(Truthy(Get(e_4257, "isConnected"))))) {
if (!SEqS(Get(Get(Get(t_4256, "p"), "style"), "display"), "none")) {
Set(Get(Get(t_4256, "p"), "style"), "display", ((V)("none")));
}
return default;
}
par_4261 = Get(e_4257, "parentNode");
if (Truthy((Get(Get(t_4256, "p"), "parentNode") is var _t4266 && !Truthy(_t4266) ? _t4266 : (!SEq(Get(Get(Get(t_4256, "p"), "parentNode"), "parentNode"), par_4261) ? V.True : V.False)))) {
V g_4267 = default;
g_4267 = Get(par_4261, "__olTube");
if ((!(Truthy(g_4267)) || !SEq(Get(g_4267, "parentNode"), par_4261))) {
g_4267 = Set(par_4261, "__olTube", Invoke(G("document"), "createElementNS", SVGNS_90, ((V)("g"))));
Invoke(g_4267, "setAttribute", ((V)("data-lt")), ((V)(1D)));
Invoke(g_4267, "setAttribute", ((V)("pointer-events")), ((V)("none")));
Invoke(g_4267, "setAttribute", ((V)("fill")), ((V)("none")));
Invoke(par_4261, "insertBefore", g_4267, Get(par_4261, "firstChild"));
}
Invoke(g_4267, "appendChild", Get(t_4256, "p"));
} else {
if (Truthy(((!SEq(Get(par_4261, "firstChild"), Get(Get(t_4256, "p"), "parentNode")) ? V.True : V.False) is var _t4268 && !Truthy(_t4268) ? _t4268 : Get(Get(t_4256, "p"), "parentNode")))) {
Invoke(par_4261, "insertBefore", Get(Get(t_4256, "p"), "parentNode"), Get(par_4261, "firstChild"));
}
}
if (SEqS(Get(Get(Get(t_4256, "p"), "style"), "display"), "none")) {
Set(Get(Get(t_4256, "p"), "style"), "display", ((V)("")));
}
d_4262 = (Invoke(e_4257, "getAttribute", ((V)("d"))) is var _t4269 && Truthy(_t4269) ? _t4269 : ((V)("")));
if (!SEq(Get(t_4256, "d"), d_4262)) {
Set(t_4256, "d", d_4262);
Invoke(Get(t_4256, "p"), "setAttribute", ((V)("d")), d_4262);
}
w_4263 = Call(r2_14, V.Undef, Add(sw_4259, ((V)(((2D * ToNum(lw_4207)) / ToNum(Get(t_4256, "sc")))))));
if (!SEq(Get(t_4256, "w"), w_4263)) {
Set(t_4256, "w", w_4263);
Invoke(Get(t_4256, "p"), "setAttribute", ((V)("stroke-width")), w_4263);
}
if (!SEq(Get(t_4256, "o"), op_4260)) {
Set(t_4256, "o", op_4260);
if (op_4260.IsNullish) {
Invoke(Get(t_4256, "p"), "removeAttribute", ((V)("opacity")));
} else {
Invoke(Get(t_4256, "p"), "setAttribute", ((V)("opacity")), op_4260);
}
}
tr_4264 = Invoke(e_4257, "getAttribute", ((V)("transform")));
if (!SEq(Get(t_4256, "tr"), tr_4264)) {
Set(t_4256, "tr", tr_4264);
if (tr_4264.IsNullish) {
Invoke(Get(t_4256, "p"), "removeAttribute", ((V)("transform")));
} else {
Invoke(Get(t_4256, "p"), "setAttribute", ((V)("transform")), tr_4264);
}
}
return default;
}, 1, "", true));
if (Truthy(((Get(I_4205, "olLate") is var _t4271 && !Truthy(_t4271) ? _t4271 : Get(Get(I_4205, "olLate"), "length")) is var _t4272 && !Truthy(_t4272) ? _t4272 : (((IncM(I_4205, "olN", 1D, true) % 20D) == 0D) ? V.True : V.False)))) {
V root_4273 = default;
V seen_4274 = default;
root_4273 = (Get(I_4205, "root") is var _t4275 && Truthy(_t4275) ? _t4275 : Get(I_4205, "art"));
seen_4274 = Invoke(Get(I_4205, "olLate"), "some", Fn((V _self4198, int _argc4276, V e_4282, V _a4279, V _a4280, V _a4281, V[] _rest4277) => {
V a_4283 = default;
double op_4284 = 0;
if (!(Truthy(Get(e_4282, "isConnected")))) {
return (false ? V.True : V.False);
}
a_4283 = e_4282;
op_4284 = 1D;
while (Truthy(((a_4283 is var _t4285 && !Truthy(_t4285) ? _t4285 : (!SEq(a_4283, root_4273) ? V.True : V.False)) is var _t4286 && !Truthy(_t4286) ? _t4286 : (SEqN(Get(a_4283, "nodeType"), 1D) ? V.True : V.False)))) {
V s2_4287 = default;
s2_4287 = Call(G("getComputedStyle"), V.Undef, a_4283);
if (SEqS(Get(s2_4287, "display"), "none")) {
return (false ? V.True : V.False);
}
op_4284 = (op_4284 * ToNum(Get(s2_4287, "opacity")));
a_4283 = Get(a_4283, "parentNode");
}
return ((op_4284 >= 0.6) ? V.True : V.False);
return default;
}, 1, "", true));
if (Truthy(seen_4274)) {
V r_4288 = default;
r_4288 = Call(outlineEls_89, V.Undef, I_4205);
if (Truthy(r_4288)) {
V have_4289 = default;
V tb_4290 = default;
have_4289 = New(G("Set"), Invoke(Get(I_4205, "olEls"), "map", Fn((V _self4198, int _argc4291, V o_4297, V _a4294, V _a4295, V _a4296, V[] _rest4292) => {
return Get(o_4297, "e");
}, 1, "", true)));
tb_4290 = New(G("Set"), Invoke((Get(I_4205, "olTubes") is var _t4305 && Truthy(_t4305) ? _t4305 : Arr()), "map", Fn((V _self4198, int _argc4298, V t_4304, V _a4301, V _a4302, V _a4303, V[] _rest4299) => {
return Get(t_4304, "e");
}, 1, "", true)));
Invoke(Get(r_4288, "out"), "forEach", Fn((V _self4198, int _argc4306, V o_4312, V _a4309, V _a4310, V _a4311, V[] _rest4307) => {
if (!(Truthy(Invoke(have_4289, "has", Get(o_4312, "e"))))) {
Invoke(Get(I_4205, "olEls"), "push", o_4312);
}
return default;
}, 1, "", true));
Invoke(Get(r_4288, "tubes"), "forEach", Fn((V _self4198, int _argc4313, V t_4319, V _a4316, V _a4317, V _a4318, V[] _rest4314) => {
if (!(Truthy(Invoke(tb_4290, "has", Get(t_4319, "e"))))) {
Invoke(Get(I_4205, "olTubes"), "push", t_4319);
}
return default;
}, 1, "", true));
Set(I_4205, "olLate", Invoke(Get(I_4205, "olLate"), "filter", Fn((V _self4198, int _argc4320, V e_4326, V _a4323, V _a4324, V _a4325, V[] _rest4321) => {
return (GeN(Invoke(Get(r_4288, "late"), "indexOf", e_4326), 0D) ? V.True : V.False);
}, 1, "", true)));
Call(outline_91, V.Undef, I_4205);
}
}
}
return default;
}, 1, "outlineTick", false);
setLight_93 = Fn((V _self4327, int _argc4328, V I_4334, V L_4335, V _a4332, V _a4333, V[] _rest4329) => {
V svg_4336 = default;
V u_4337 = default;
V NS_4338 = default;
V df_4339 = default;
V mkL_4340 = default;
V T_4341 = default;
V tintOn_4342 = default;
V st_4343 = default;
V ac_4344 = default;
V rc_4345 = default;
V sh_4346 = default;
V mix_4347 = default;
V d_4348 = default;
V n_4349 = default;
V oc_4350 = default;
if (_self4327.IsNullish) _self4327 = GlobalV;
svg_4336 = (Get(I_4334, "root") is var _t4351 && !Truthy(_t4351) ? _t4351 : Get(Get(I_4334, "root"), "ownerSVGElement"));
if (!(Truthy(svg_4336))) {
return default;
}
u_4337 = Get(I_4334, "u");
NS_4338 = ((V)("http://www.w3.org/2000/svg"));
df_4339 = Invoke(svg_4336, "querySelector", ((V)("defs")));
mkL_4340 = Fn((V _self4327, int _argc4352, V tag_4358, V at_4359, V par_4360, V _a4357, V[] _rest4353) => {
V e_4361 = default;
e_4361 = Invoke(G("document"), "createElementNS", NS_4338, tag_4358);
Invoke(Object_keys(at_4359), "forEach", Fn((V _self4327, int _argc4362, V k_4368, V _a4365, V _a4366, V _a4367, V[] _rest4363) => {
return Invoke(e_4361, "setAttribute", k_4368, GetK(at_4359, k_4368));
}, 1, "", true));
if (Truthy(par_4360)) {
Invoke(par_4360, "appendChild", e_4361);
}
return e_4361;
return default;
}, 3, "", true);
if (!(Truthy(Get(I_4334, "lt")))) {
V R_4369 = default;
V gm_4370 = default;
V tint_4371 = default;
V cast_4372 = default;
V part_4373 = default;
V E0_4374 = default;
V tailOL_4375 = default;
V wg0_4376 = default;
V whOL_4377 = default;
V WHISK_4378 = default;
if (!(Truthy(L_4335))) {
return default;
}
Invoke(Object_keys(Get(I_4334, "pg")), "forEach", Fn((V _self4327, int _argc4379, V k_4385, V _a4382, V _a4383, V _a4384, V[] _rest4380) => {
Set(GetK(Get(I_4334, "pg"), k_4385), "id", ((V)(string.Concat("pg", ToStr(k_4385), ToStr(u_4337)))));
return default;
}, 1, "", true));
Invoke(df_4339, "insertAdjacentHTML", ((V)("beforeend")), ((V)(string.Concat(new string[] { "<mask id=\"lm", ToStr(u_4337), "\" maskUnits=\"userSpaceOnUse\" x=\"-12\" y=\"-25\" width=\"124\" height=\"128\" style=\"mask-type:alpha\">", ToStr(Invoke(Invoke(Object_keys(Get(I_4334, "pg")), "map", Fn((V _self4327, int _argc4386, V k_4392, V _a4389, V _a4390, V _a4391, V[] _rest4387) => {
return ((V)(string.Concat("<use href=\"#pg", ToStr(k_4392), ToStr(u_4337), "\"/>")));
}, 1, "", true)), "join", ((V)("")))), "</mask>", "<linearGradient id=\"la", ToStr(u_4337), "\" gradientUnits=\"userSpaceOnUse\" x1=\"0\" x2=\"0\"><stop offset=\"0\"/><stop offset=\"1\"/></linearGradient>", "<radialGradient id=\"lhg", ToStr(u_4337), "\" r=\"0.42\"><stop offset=\"0\"/><stop offset=\"1\"/></radialGradient>", "<radialGradient id=\"lc", ToStr(u_4337), "\"><stop offset=\"0\" stop-opacity=\"1\"/><stop offset=\"0.45\" stop-opacity=\"0.75\"/><stop offset=\"1\" stop-opacity=\"0\"/></radialGradient>" }))));
R_4369 = NewObj(4).Put("x", ((V)((-12D)))).Put("y", ((V)((-25D)))).Put("width", ((V)(124D))).Put("height", ((V)(128D))).V;
gm_4370 = Call(mkL_4340, V.Undef, ((V)("g")), NewObj(2).Put("mask", ((V)(string.Concat("url(#lm", ToStr(u_4337), ")")))).Put("data-lt", ((V)(1D))).V);
Set(Get(gm_4370, "style"), "mixBlendMode", ((V)("multiply")));
tint_4371 = Call(mkL_4340, V.Undef, ((V)("rect")), Object_assign(NewObj(1).Put("fill", ((V)("#ffffff"))).V, R_4369), gm_4370);
Call(mkL_4340, V.Undef, ((V)("rect")), Object_assign(NewObj(1).Put("fill", ((V)(string.Concat("url(#la", ToStr(u_4337), ")")))).V, R_4369), gm_4370);
cast_4372 = Call(mkL_4340, V.Undef, ((V)("ellipse")), NewObj(2).Put("fill", ((V)(string.Concat("url(#lc", ToStr(u_4337), ")")))).Put("data-lt", ((V)(1D))).V);
Invoke(Get(Get(I_4334, "shadow"), "parentNode"), "insertBefore", cast_4372, Get(I_4334, "shadow"));
part_4373 = NewObj(0).V;
Invoke(LPARTS_71, "forEach", Fn((V _self4327, int _argc4393, V _a4395, V _a4396, V _a4397, V _a4398, V[] _rest4394) => {
V src_4406 = default;
V g_4407 = default;
V tube_4408 = default;
V P_4409 = default;
V mA_4410 = default;
V k_4401 = default;
V size_4403 = default;
V mode_4405 = default;
{ V _t4399 = ListOf(_a4395);
{ V _t4400 = GetIdx(_t4399, 0D);
k_4401 = _t4400; }
{ V _t4402 = GetIdx(_t4399, 1D);
size_4403 = _t4402; }
{ V _t4404 = GetIdx(_t4399, 2D);
mode_4405 = _t4404; }
}
src_4406 = Call(lightSrc_84, V.Undef, I_4334, k_4401);
if ((!(Truthy(src_4406)) || !(Truthy(GetK(Get(I_4334, "pg"), k_4401))))) {
return default;
}
g_4407 = Call(mkL_4340, V.Undef, ((V)("g")), NewObj(2).Put("pointer-events", ((V)("none"))).Put("data-lt", ((V)(1D))).V);
tube_4408 = (SEqS(mode_4405, "tube") ? V.True : V.False);
if (Truthy(tube_4408)) {
Invoke(df_4339, "insertAdjacentHTML", ((V)("beforeend")), ((V)(string.Concat("<clipPath id=\"ltc", ToStr(k_4401), ToStr(u_4337), "\" clipPathUnits=\"userSpaceOnUse\"><path clip-rule=\"evenodd\"/></clipPath>"))));
} else {
Invoke(df_4339, "insertAdjacentHTML", ((V)("beforeend")), ((V)(string.Concat("<radialGradient id=\"lsg", ToStr(k_4401), ToStr(u_4337), "\" r=\"0.78\"><stop offset=\"0.42\"/><stop offset=\"0.72\"/><stop offset=\"0.9\"/><stop offset=\"1\"/></radialGradient>"))));
}
P_4409 = NewObj(11).Put("k", k_4401).Put("size", size_4403).Put("src", src_4406).Put("g", g_4407).Put("tube", tube_4408).Put("occ", Arr()).Put("col", Call(rgbOf_78, V.Undef, src_4406)).Put("gs", (Truthy(tube_4408) ? V.Null : Invoke(df_4339, "querySelector", ((V)(string.Concat("#lsg", ToStr(k_4401), ToStr(u_4337))))))).Put("sh", Call(mkL_4340, V.Undef, ((V)("path")), (Truthy(tube_4408) ? NewObj(1).Put("clip-path", ((V)(string.Concat("url(#ltc", ToStr(k_4401), ToStr(u_4337), ")")))).V : NewObj(1).Put("fill", ((V)(string.Concat("url(#lsg", ToStr(k_4401), ToStr(u_4337), ")")))).V), g_4407)).Put("hi", (Truthy(tube_4408) ? V.Null : Call(mkL_4340, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)(string.Concat("url(#lhg", ToStr(u_4337), ")")))).V, g_4407))).Put("tc", (Truthy(tube_4408) ? Invoke(df_4339, "querySelector", ((V)(string.Concat("#ltc", ToStr(k_4401), ToStr(u_4337), " path")))) : V.Null)).V;
Invoke((GetK(LOCC_72, k_4401) is var _t4424 && Truthy(_t4424) ? _t4424 : Arr()), "forEach", Fn((V _self4327, int _argc4411, V _a4413, V _a4414, V _a4415, V _a4416, V[] _rest4412) => {
V os_4422 = default;
V id_4423 = default;
V o_4419 = default;
V w_4421 = default;
{ V _t4417 = ListOf(_a4413);
{ V _t4418 = GetIdx(_t4417, 0D);
o_4419 = _t4418; }
{ V _t4420 = GetIdx(_t4417, 1D);
w_4421 = _t4420; }
}
os_4422 = Call(lightSrc_84, V.Undef, I_4334, o_4419);
if (!(Truthy(os_4422))) {
return default;
}
id_4423 = ((V)(string.Concat("lo", ToStr(k_4401), ToStr(o_4419), ToStr(u_4337))));
Invoke(df_4339, "insertAdjacentHTML", ((V)("beforeend")), ((V)(string.Concat("<clipPath id=\"", ToStr(id_4423), "\" clipPathUnits=\"userSpaceOnUse\"><path/></clipPath>"))));
Invoke(Get(P_4409, "occ"), "push", NewObj(5).Put("o", o_4419).Put("w", w_4421).Put("src", os_4422).Put("c", Invoke(df_4339, "querySelector", ((V)(string.Concat("#", ToStr(id_4423), " path"))))).Put("e", Call(mkL_4340, V.Undef, ((V)("path")), NewObj(1).Put("clip-path", ((V)(string.Concat("url(#", ToStr(id_4423), ")")))).V, g_4407)).V);
return default;
}, 1, "", true));
mA_4410 = Invoke(GetK(Get(I_4334, "pg"), k_4401), "getAttribute", ((V)("mask")));
if (Truthy(mA_4410)) {
Invoke(g_4407, "setAttribute", ((V)("mask")), mA_4410);
}
SetK(part_4373, k_4401, P_4409);
Invoke(GetK(Get(I_4334, "pg"), k_4401), "after", g_4407);
return default;
}, 1, "", true));
E0_4374 = (Get(I_4334, "E") is var _t4425 && Truthy(_t4425) ? _t4425 : NewObj(0).V);
tailOL_4375 = V.Null;
if (Truthy(((Get(E0_4374, "tail") is var _t4426 && !Truthy(_t4426) ? _t4426 : (!(Truthy(Get(E0_4374, "tailF"))) ? V.True : V.False)) is var _t4427 && !Truthy(_t4427) ? _t4427 : (!(Truthy(Get(part_4373, "tail"))) ? V.True : V.False)))) {
V g_4428 = default;
V mp_4429 = default;
V tc_4430 = default;
Invoke(df_4339, "insertAdjacentHTML", ((V)("beforeend")), ((V)(string.Concat("<mask id=\"ltm", ToStr(u_4337), "\" maskUnits=\"userSpaceOnUse\" x=\"-60\" y=\"-60\" width=\"220\" height=\"220\"><path fill=\"none\" stroke=\"#fff\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><path fill=\"none\" stroke=\"#000\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/></mask>"))));
g_4428 = Call(mkL_4340, V.Undef, ((V)("g")), NewObj(2).Put("pointer-events", ((V)("none"))).Put("data-lt", ((V)(1D))).V);
mp_4429 = Invoke(df_4339, "querySelectorAll", ((V)(string.Concat("#ltm", ToStr(u_4337), " path"))));
tc_4430 = Arr(((V)(200D)), ((V)(140D)), ((V)(100D)));
try {
tc_4430 = (Call(rgbP_77, V.Undef, Get(Call(G("getComputedStyle"), V.Undef, Get(E0_4374, "tail")), "stroke")) is var _t4431 && Truthy(_t4431) ? _t4431 : tc_4430);
} catch (System.Exception _ex4432) {
V x_4433 = default;
x_4433 = Caught(_ex4432);

}
Set(part_4373, "tail", NewObj(10).Put("k", ((V)("tail"))).Put("size", ((V)(16D))).Put("src", Get(E0_4374, "tail")).Put("g", g_4428).Put("occ", Arr()).Put("st", (true ? V.True : V.False)).Put("col", tc_4430).Put("sh", Call(mkL_4340, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).Put("mask", ((V)(string.Concat("url(#ltm", ToStr(u_4337), ")")))).V, g_4428)).Put("mw", GetIdx(mp_4429, 0D)).Put("mb", GetIdx(mp_4429, 1D)).V);
Invoke(Get(Get(I_4334, "pg"), "tail"), "after", g_4428);
}
wg0_4376 = ((Get(E0_4374, "wh") is var _t4434 && !Truthy(_t4434) ? _t4434 : GetIdx(Get(E0_4374, "wh"), 0D)) is var _t4435 && !Truthy(_t4435) ? _t4435 : Get(GetIdx(Get(E0_4374, "wh"), 0D), "parentNode"));
whOL_4377 = V.Null;
WHISK_4378 = (false ? V.True : V.False);
if (Truthy(((WHISK_4378 is var _t4436 && !Truthy(_t4436) ? _t4436 : wg0_4376) is var _t4438 && !Truthy(_t4438) ? _t4438 : (!SEqS((Invoke(wg0_4376, "getAttribute", ((V)("stroke"))) is var _t4437 && Truthy(_t4437) ? _t4437 : ((V)("none"))), "none") ? V.True : V.False)))) {
V g_4439 = default;
g_4439 = Call(mkL_4340, V.Undef, ((V)("g")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).Put("pointer-events", ((V)("none"))).Put("data-lt", ((V)(1D))).V);
Invoke(wg0_4376, "before", g_4439);
whOL_4377 = NewObj(5).Put("g", g_4439).Put("wg", wg0_4376).Put("c0", Invoke(wg0_4376, "getAttribute", ((V)("stroke")))).Put("w0", (((V)(ToNum(Invoke(wg0_4376, "getAttribute", ((V)("stroke-width")))))) is var _t4440 && Truthy(_t4440) ? _t4440 : ((V)(0.9)))).Put("ps", Invoke(Get(E0_4374, "wh"), "map", Fn((V _self4327, int _argc4441, V _a4443, V _a4444, V _a4445, V _a4446, V[] _rest4442) => {
return Call(mkL_4340, V.Undef, ((V)("path")), NewObj(0).V, g_4439);
}, 0, "", true))).V;
}
Invoke(Get(I_4334, "root"), "appendChild", gm_4370);
Set(I_4334, "lt", NewObj(8).Put("gm", gm_4370).Put("tint", tint_4371).Put("cast", cast_4372).Put("part", part_4373).Put("tailOL", tailOL_4375).Put("whOL", whOL_4377).Put("ga", Invoke(df_4339, "querySelector", ((V)(string.Concat("#la", ToStr(u_4337)))))).Put("ghi", Invoke(df_4339, "querySelector", ((V)(string.Concat("#lhg", ToStr(u_4337)))))).V);
}
T_4341 = Get(I_4334, "lt");
Set(T_4341, "L", (L_4335 is var _t4447 && Truthy(_t4447) ? _t4447 : V.Null));
Invoke(Invoke(Arr(Get(T_4341, "cast")), "concat", Invoke(Object_values(Get(T_4341, "part")), "map", Fn((V _self4327, int _argc4455, V P_4461, V _a4458, V _a4459, V _a4460, V[] _rest4456) => {
return Get(P_4461, "g");
}, 1, "", true))), "forEach", Fn((V _self4327, int _argc4448, V e_4454, V _a4451, V _a4452, V _a4453, V[] _rest4449) => {
Set(Get(e_4454, "style"), "display", ((V)((Truthy(L_4335) ? "" : "none"))));
return default;
}, 1, "", true));
Invoke(Get(I_4334, "shadow"), "setAttribute", ((V)("fill")), (Truthy((L_4335 is var _t4462 && !Truthy(_t4462) ? _t4462 : Get(L_4335, "castC"))) ? Get(L_4335, "castC") : ((V)("#6a1b9a"))));
if (!(Truthy(L_4335))) {
Set(Get(Get(T_4341, "gm"), "style"), "display", ((V)("none")));
if (Truthy(Get(T_4341, "tailOL"))) {
Set(Get(Get(T_4341, "tailOL"), "style"), "display", ((V)("none")));
}
if (Truthy(Get(T_4341, "whOL"))) {
Set(Get(Get(Get(T_4341, "whOL"), "g"), "style"), "display", ((V)("none")));
Invoke(Get(Get(T_4341, "whOL"), "wg"), "setAttribute", ((V)("stroke")), Get(Get(T_4341, "whOL"), "c0"));
}
return default;
}
tintOn_4342 = ((!(!(Truthy((Get(L_4335, "tint") is var _t4463 && !Truthy(_t4463) ? _t4463 : (!(Truthy(Invoke(NewRegExp(RX6, "^#f{6}$", "i"), "test", Get(L_4335, "tint")))) ? V.True : V.False))))) || GtN((Get(L_4335, "ao") is var _t4464 && Truthy(_t4464) ? _t4464 : ((V)(0D))), 0D)) ? V.True : V.False);
Set(Get(Get(T_4341, "gm"), "style"), "display", ((V)((Truthy(tintOn_4342) ? "" : "none"))));
st_4343 = Fn((V _self4327, int _argc4465, V g_4471, V cols_4472, V _a4469, V _a4470, V[] _rest4466) => {
return Invoke(new ArrBuilder().Spread(Get(g_4471, "children")).V, "forEach", Fn((V _self4327, int _argc4473, V s_4479, V i_4480, V _a4477, V _a4478, V[] _rest4474) => {
Invoke(s_4479, "setAttribute", ((V)("stop-color")), GetIdx(GetK(cols_4472, i_4480), 0D));
Invoke(s_4479, "setAttribute", ((V)("stop-opacity")), GetIdx(GetK(cols_4472, i_4480), 1D));
return default;
}, 2, "", true));
}, 2, "", true);
ac_4344 = ((Get(L_4335, "aoC") is var _t4481 && Truthy(_t4481) ? _t4481 : Get(L_4335, "shC")) is var _t4482 && Truthy(_t4482) ? _t4482 : ((V)("#5a2a48")));
rc_4345 = (Get(L_4335, "rimC") is var _t4483 && Truthy(_t4483) ? _t4483 : ((V)("#fff3d2")));
sh_4346 = (Get(L_4335, "sh").IsNullish ? ((V)(0.4)) : Get(L_4335, "sh"));
mix_4347 = (Get(L_4335, "shMix").IsNullish ? ((V)(1D)) : Get(L_4335, "shMix"));
Call(st_4343, V.Undef, Get(T_4341, "ga"), Arr(Arr(ac_4344, ((V)(0D))), Arr(ac_4344, (Get(L_4335, "ao") is var _t4484 && Truthy(_t4484) ? _t4484 : ((V)(0D))))));
Invoke(Get(T_4341, "tint"), "setAttribute", ((V)("fill")), (Get(L_4335, "tint") is var _t4485 && Truthy(_t4485) ? _t4485 : ((V)("#ffffff"))));
Call(st_4343, V.Undef, Get(T_4341, "ghi"), Arr(Arr(rc_4345, (Get(L_4335, "rim") is var _t4486 && Truthy(_t4486) ? _t4486 : ((V)(0D)))), Arr(rc_4345, ((V)(0D)))));
Invoke(new ArrBuilder().Spread(Get(Invoke(Get(Get(T_4341, "cast"), "ownerSVGElement"), "querySelector", ((V)(string.Concat("#lc", ToStr(u_4337))))), "children")).V, "forEach", Fn((V _self4327, int _argc4487, V s_4493, V _a4490, V _a4491, V _a4492, V[] _rest4488) => {
return Invoke(s_4493, "setAttribute", ((V)("stop-color")), (Get(L_4335, "castC") is var _t4494 && Truthy(_t4494) ? _t4494 : ((V)("#2a1a30"))));
}, 1, "", true));
d_4348 = (Get(L_4335, "dir") is var _t4495 && Truthy(_t4495) ? _t4495 : Arr(((V)(0.7)), ((V)(0.6))));
n_4349 = (((V)(Hypot(ToNum(GetIdx(d_4348, 0D)), ToNum(GetIdx(d_4348, 1D))))) is var _t4496 && Truthy(_t4496) ? _t4496 : ((V)(1D)));
Set(T_4341, "dx", ((V)((ToNum(GetIdx(d_4348, 0D)) / ToNum(n_4349)))));
Set(T_4341, "dy", ((V)((ToNum(GetIdx(d_4348, 1D)) / ToNum(n_4349)))));
Invoke(Get(T_4341, "ghi"), "setAttribute", ((V)("cx")), Call(r2_14, V.Undef, ((V)((0.5 - (0.24 * ToNum(Get(T_4341, "dx"))))))));
Invoke(Get(T_4341, "ghi"), "setAttribute", ((V)("cy")), Call(r2_14, V.Undef, ((V)((0.42 - (0.24 * ToNum(Get(T_4341, "dy"))))))));
Invoke(Object_values(Get(T_4341, "part")), "forEach", Fn((V _self4327, int _argc4497, V P_4503, V _a4500, V _a4501, V _a4502, V[] _rest4498) => {
V sc_4504 = default;
Set(P_4503, "sc", (Truthy(Get(L_4335, "shC")) ? Call(mixHex_83, V.Undef, Call(shadeOf_82, V.Undef, Get(P_4503, "col")), Get(L_4335, "shC"), mix_4347) : Call(shadeOf_82, V.Undef, Get(P_4503, "col"))));
sc_4504 = Get(P_4503, "sc");
if (Truthy(Get(P_4503, "gs"))) {
Call(st_4343, V.Undef, Get(P_4503, "gs"), Arr(Arr(sc_4504, ((V)(0D))), Arr(sc_4504, ((V)((ToNum(sh_4346) * 0.42)))), Arr(sc_4504, ((V)((ToNum(sh_4346) * 0.85)))), Arr(sc_4504, sh_4346)));
Invoke(Get(P_4503, "gs"), "setAttribute", ((V)("cx")), Call(r2_14, V.Undef, ((V)((0.5 - (0.2 * ToNum(Get(T_4341, "dx"))))))));
Invoke(Get(P_4503, "gs"), "setAttribute", ((V)("cy")), Call(r2_14, V.Undef, ((V)((0.5 - (0.2 * ToNum(Get(T_4341, "dy"))))))));
}
if (Truthy(Get(P_4503, "tube"))) {
Invoke(Get(P_4503, "sh"), "setAttribute", ((V)("fill")), sc_4504);
Invoke(Get(P_4503, "sh"), "setAttribute", ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ToNum(sh_4346) * 0.8)))));
}
if (Truthy(Get(P_4503, "st"))) {
Invoke(Get(P_4503, "sh"), "setAttribute", ((V)("stroke")), sc_4504);
Invoke(Get(P_4503, "sh"), "setAttribute", ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ToNum(sh_4346) * 0.8)))));
}
return default;
}, 1, "", true));
oc_4350 = (Get(L_4335, "occ").IsNullish ? sh_4346 : Get(L_4335, "occ"));
Invoke(Object_values(Get(T_4341, "part")), "forEach", Fn((V _self4327, int _argc4505, V P_4511, V _a4508, V _a4509, V _a4510, V[] _rest4506) => {
return Invoke(Get(P_4511, "occ"), "forEach", Fn((V _self4327, int _argc4512, V O_4518, V _a4515, V _a4516, V _a4517, V[] _rest4513) => {
Invoke(Get(O_4518, "e"), "setAttribute", ((V)("fill")), Get(P_4511, "sc"));
Invoke(Get(O_4518, "e"), "setAttribute", ((V)("opacity")), Call(r2_14, V.Undef, ((V)(Min(0.9, ((ToNum(oc_4350) * ToNum(Get(O_4518, "w"))) * 1.3))))));
return default;
}, 1, "", true));
}, 1, "", true));
Set(T_4341, "lw", (Get(L_4335, "line") is var _t4519 && Truthy(_t4519) ? _t4519 : ((V)(0D))));
Set(T_4341, "dirty", ((V)(1D)));
if (Truthy(Get(T_4341, "whOL"))) {
V W_4520 = default;
W_4520 = Get(T_4341, "whOL");
Set(Get(Get(W_4520, "g"), "style"), "display", ((V)((Truthy(Get(T_4341, "lw")) ? "" : "none"))));
Invoke(Get(W_4520, "wg"), "setAttribute", ((V)("stroke")), (Truthy(Get(T_4341, "lw")) ? Call(mixHex_83, V.Undef, Get(W_4520, "c0"), ((V)("#ffffff")), ((V)(0.5))) : Get(W_4520, "c0")));
Invoke(Get(W_4520, "g"), "setAttribute", ((V)("stroke")), (Get(L_4335, "lineC") is var _t4523 && Truthy(_t4523) ? _t4523 : Call(lineOf_81, V.Undef, Call(rgbOf_78, V.Undef, ((Get(I_4334, "E") is var _t4521 && !Truthy(_t4521) ? _t4521 : Get(Get(I_4334, "E"), "skull")) is var _t4522 && Truthy(_t4522) ? _t4522 : Get(I_4334, "root"))))));
Invoke(Get(W_4520, "g"), "setAttribute", ((V)("stroke-width")), Call(r2_14, V.Undef, Add(Get(W_4520, "w0"), ((V)((2D * Min(0.32, (ToNum(Get(T_4341, "lw")) * 0.3))))))));
Invoke(Get(W_4520, "ps"), "forEach", Fn((V _self4327, int _argc4524, V q_4530, V _a4527, V _a4528, V _a4529, V[] _rest4525) => {
Set(q_4530, "_d", V.Null);
Set(q_4530, "_o", V.Null);
return default;
}, 1, "", true));
}
return default;
}, 2, "setLight", false);
litTick_94 = Fn((V _self4531, int _argc4532, V I_4538, V P_4539, V G_4540, V sq_4541, V[] _rest4533) => {
V T_4543 = default;
V L_4544 = default;
V S_4545 = default;
V cx_4546 = default;
V dx_4547 = default;
V dy_4548 = default;
double len_4549 = 0;
double off_4550 = 0;
V gl_4542 = default;
if (_self4531.IsNullish) _self4531 = GlobalV;
gl_4542 = (_argc4532 > 4 ? _rest4533[0] : V.Undef);
T_4543 = Get(I_4538, "lt");
L_4544 = (T_4543 is var _t4551 && !Truthy(_t4551) ? _t4551 : Get(T_4543, "L"));
if (!(Truthy(L_4544))) {
return default;
}
S_4545 = Fn((V _self4531, int _argc4552, V e_4558, V a_4559, V v_4560, V _a4557, V[] _rest4553) => {
return Invoke(e_4558, "setAttribute", a_4559, Call(r2_14, V.Undef, v_4560));
}, 3, "", true);
cx_4546 = Add(Add(((V)(50D)), Get(P_4539, "x")), ((V)((ToNum(Get(P_4539, "lean")) * 0.1))));
dx_4547 = Get(T_4543, "dx");
dy_4548 = Get(T_4543, "dy");
if (!SEqS(Get(Get(Get(T_4543, "gm"), "style"), "display"), "none")) {
Call(S_4545, V.Undef, Get(T_4543, "ga"), ((V)("y1")), ((V)(((ToNum(G_4540) - 19D) - (ToNum(gl_4542) * 0.6)))));
Call(S_4545, V.Undef, Get(T_4543, "ga"), ((V)("y2")), ((V)((ToNum(Add(G_4540, ((V)(1D)))) - (ToNum(gl_4542) * 0.6)))));
}
Invoke(Object_values(Get(T_4543, "part")), "forEach", Fn((V _self4531, int _argc4561, V Q_4567, V _a4564, V _a4565, V _a4566, V[] _rest4562) => {
V dd_4568 = default;
V vis_4569 = default;
V O_4570 = default;
V po_4571 = default;
V so_4572 = default;
double op_4573 = 0;
V fr_4574 = default;
dd_4568 = (Invoke(Get(Q_4567, "src"), "getAttribute", ((V)("d"))) is var _t4575 && Truthy(_t4575) ? _t4575 : ((V)("")));
vis_4569 = ((dd_4568 is var _t4576 && !Truthy(_t4576) ? _t4576 : (!SEqS(Get(Get(Get(Q_4567, "src"), "style"), "display"), "none") ? V.True : V.False)) is var _t4577 && !Truthy(_t4577) ? _t4577 : (!SEqS(Invoke(Get(Q_4567, "src"), "getAttribute", ((V)("opacity"))), "0") ? V.True : V.False));
O_4570 = (Truthy((Get(Q_4567, "st") is var _t4578 && !Truthy(_t4578) ? _t4578 : Get(T_4543, "lw"))) ? Get(T_4543, "tailOL") : V.Null);
if (!(Truthy(vis_4569))) {
if (!SEqS(Get(Get(Get(Q_4567, "g"), "style"), "display"), "none")) {
Set(Get(Get(Q_4567, "g"), "style"), "display", ((V)("none")));
}
if (Truthy(O_4570)) {
Set(Get(O_4570, "style"), "display", ((V)("none")));
}
return default;
}
if (SEqS(Get(Get(Get(Q_4567, "g"), "style"), "display"), "none")) {
Set(Get(Get(Q_4567, "g"), "style"), "display", ((V)("")));
}
if (!SEq(Get(Get(Q_4567, "g"), "previousSibling"), GetK(Get(I_4538, "pg"), Get(Q_4567, "k")))) {
Invoke(GetK(Get(I_4538, "pg"), Get(Q_4567, "k")), "after", Get(Q_4567, "g"));
}
po_4571 = Invoke(GetK(Get(I_4538, "pg"), Get(Q_4567, "k")), "getAttribute", ((V)("opacity")));
so_4572 = Invoke(Get(Q_4567, "src"), "getAttribute", ((V)("opacity")));
op_4573 = ((po_4571.IsNullish ? 1D : ToNum(po_4571)) * (so_4572.IsNullish ? 1D : ToNum(so_4572)));
Invoke(Get(Q_4567, "g"), "setAttribute", ((V)("opacity")), Call(r2_14, V.Undef, ((V)(op_4573))));
if (Truthy(Get(Q_4567, "st"))) {
V tw_4579 = default;
V key_4580 = default;
V sw_4581 = default;
double w_4582 = 0;
if (Truthy(O_4570)) {
if (SEqS(Get(Get(O_4570, "style"), "display"), "none")) {
Set(Get(O_4570, "style"), "display", ((V)("")));
}
if (!SEq(Get(O_4570, "nextSibling"), Get(Get(I_4538, "pg"), "tail"))) {
Invoke(Get(Get(I_4538, "pg"), "tail"), "before", O_4570);
}
Invoke(O_4570, "setAttribute", ((V)("opacity")), Call(r2_14, V.Undef, ((V)(op_4573))));
}
tw_4579 = (((V)(ToNum(Invoke(Get(Q_4567, "src"), "getAttribute", ((V)("stroke-width")))))) is var _t4583 && Truthy(_t4583) ? _t4583 : ((V)(7D)));
key_4580 = Add(Add(dd_4568, tw_4579), Get(T_4543, "lw"));
if ((SEq(Get(Q_4567, "d"), key_4580) && !(Truthy(Get(T_4543, "dirty"))))) {
return default;
}
Set(Q_4567, "d", key_4580);
sw_4581 = Call(r2_14, V.Undef, tw_4579);
w_4582 = (ToNum(tw_4579) * 0.36);
Invoke(Arr(Get(Q_4567, "sh"), Get(Q_4567, "mw"), Get(Q_4567, "mb")), "forEach", Fn((V _self4531, int _argc4584, V e_4590, V _a4587, V _a4588, V _a4589, V[] _rest4585) => {
Invoke(e_4590, "setAttribute", ((V)("d")), dd_4568);
Invoke(e_4590, "setAttribute", ((V)("stroke-width")), sw_4581);
return default;
}, 1, "", true));
Invoke(Get(Q_4567, "mb"), "setAttribute", ((V)("transform")), ((V)(string.Concat(new string[] { "translate(", ToStr(Call(r2_14, V.Undef, ((V)(((-ToNum(dx_4547)) * w_4582))))), " ", ToStr(Call(r2_14, V.Undef, ((V)(((-ToNum(dy_4548)) * w_4582))))), ")" }))));
if (Truthy(O_4570)) {
Invoke(O_4570, "setAttribute", ((V)("d")), dd_4568);
Invoke(O_4570, "setAttribute", ((V)("stroke-width")), Call(r2_14, V.Undef, Add(tw_4579, ((V)((2D * ToNum(Get(T_4543, "lw"))))))));
}
return default;
}
if (Truthy(((!SEq(Get(Q_4567, "d"), dd_4568) ? V.True : V.False) is var _t4591 && Truthy(_t4591) ? _t4591 : Get(T_4543, "dirty")))) {
Set(Q_4567, "d", dd_4568);
Invoke(Get(Q_4567, "sh"), "setAttribute", ((V)("d")), dd_4568);
if (Truthy(Get(Q_4567, "hi"))) {
Invoke(Get(Q_4567, "hi"), "setAttribute", ((V)("d")), dd_4568);
}
if (Truthy(Get(Q_4567, "tc"))) {
double w_4592 = 0;
w_4592 = (ToNum(Get(Q_4567, "size")) * 0.22);
Invoke(Get(Q_4567, "tc"), "setAttribute", ((V)("d")), Add(LRECT_73, dd_4568));
Invoke(Get(Q_4567, "tc"), "setAttribute", ((V)("transform")), ((V)(string.Concat(new string[] { "translate(", ToStr(Call(r2_14, V.Undef, ((V)(((-ToNum(dx_4547)) * w_4592))))), " ", ToStr(Call(r2_14, V.Undef, ((V)(((-ToNum(dy_4548)) * w_4592))))), ")" }))));
}
}
fr_4574 = ((SEqS(GetIdx(Get(Q_4567, "k"), 0D), "f") && !(!(NumTruthy(((double)(ToInt32(ToNum(Invoke(Get(Get(I_4538, "pg"), "body"), "compareDocumentPosition", GetK(Get(I_4538, "pg"), Get(Q_4567, "k"))))) & ToInt32(4D))))))) ? V.True : V.False);
Invoke(Get(Q_4567, "occ"), "forEach", Fn((V _self4531, int _argc4593, V O_4599, V _a4596, V _a4597, V _a4598, V[] _rest4594) => {
V od_4600 = default;
double k_4601 = 0;
if (SEqS(Get(O_4599, "o"), "body")) {
V dp_4602 = default;
dp_4602 = ((V)((Truthy(fr_4574) ? "none" : "")));
if (!SEq(Get(Get(Get(O_4599, "e"), "style"), "display"), dp_4602)) {
Set(Get(Get(O_4599, "e"), "style"), "display", dp_4602);
}
}
od_4600 = (Invoke(Get(O_4599, "src"), "getAttribute", ((V)("d"))) is var _t4603 && Truthy(_t4603) ? _t4603 : ((V)("")));
if (((SEq(Get(O_4599, "d"), od_4600) && SEq(Get(O_4599, "dd"), dd_4568)) && !(Truthy(Get(T_4543, "dirty"))))) {
return default;
}
Set(O_4599, "d", od_4600);
Set(O_4599, "dd", dd_4568);
Invoke(Get(O_4599, "e"), "setAttribute", ((V)("d")), dd_4568);
Invoke(Get(O_4599, "c"), "setAttribute", ((V)("d")), od_4600);
k_4601 = (SEqS(Get(O_4599, "o"), "body") ? 1.6 : 1D);
Invoke(Get(O_4599, "c"), "setAttribute", ((V)("transform")), ((V)(string.Concat(new string[] { "translate(", ToStr(Call(r2_14, V.Undef, ((V)(((ToNum(dx_4547) * 2.2) * k_4601))))), " ", ToStr(Call(r2_14, V.Undef, ((V)(((2.6 + (Max(0D, ToNum(dy_4548)) * 1.8)) * k_4601))))), ")" }))));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
Set(T_4543, "dirty", ((V)(0D)));
if (Truthy((Get(T_4543, "whOL") is var _t4604 && !Truthy(_t4604) ? _t4604 : Get(T_4543, "lw")))) {
Invoke(Get(Get(I_4538, "E"), "wh"), "forEach", Fn((V _self4531, int _argc4605, V w_4611, V i_4612, V _a4609, V _a4610, V[] _rest4606) => {
V q_4613 = default;
V d_4614 = default;
V o_4615 = default;
q_4613 = GetK(Get(Get(T_4543, "whOL"), "ps"), i_4612);
if (!(Truthy(q_4613))) {
return default;
}
d_4614 = (Invoke(w_4611, "getAttribute", ((V)("d"))) is var _t4616 && Truthy(_t4616) ? _t4616 : ((V)("")));
o_4615 = Invoke(w_4611, "getAttribute", ((V)("opacity")));
if (!SEq(Get(q_4613, "_d"), d_4614)) {
Set(q_4613, "_d", d_4614);
Invoke(q_4613, "setAttribute", ((V)("d")), d_4614);
}
if (!SEq(Get(q_4613, "_o"), o_4615)) {
Set(q_4613, "_o", o_4615);
if (!o_4615.IsNullish) {
Invoke(q_4613, "setAttribute", ((V)("opacity")), Call(r2_14, V.Undef, ((V)(Min(1D, (ToNum(o_4615) / 0.8))))));
}
}
return default;
}, 2, "", true));
}
if (Truthy(Get(I_4538, "faceW"))) {
Invoke((Get(Get(I_4538, "E"), "eyes") is var _t4630 && Truthy(_t4630) ? _t4630 : Arr()), "forEach", Fn((V _self4531, int _argc4617, V o_4623, V _a4620, V _a4621, V _a4622, V[] _rest4618) => {
V ed_4624 = default;
V sw_4625 = default;
V w_4626 = default;
V op_4627 = default;
if (!(Truthy(Get(o_4623, "ring")))) {
return default;
}
ed_4624 = (Invoke(Get(o_4623, "e"), "getAttribute", ((V)("d"))) is var _t4628 && Truthy(_t4628) ? _t4628 : ((V)("")));
sw_4625 = (((V)(ToNum(Invoke(Get(o_4623, "e"), "getAttribute", ((V)("stroke-width")))))) is var _t4629 && Truthy(_t4629) ? _t4629 : ((V)(0D)));
w_4626 = Call(r2_14, V.Undef, Add(sw_4625, ((V)((ToNum(Get(I_4538, "faceW")) * 1.7)))));
op_4627 = Invoke(Get(o_4623, "e"), "getAttribute", ((V)("opacity")));
if (!SEq(Get(o_4623, "ringD"), ed_4624)) {
Set(o_4623, "ringD", ed_4624);
Invoke(Get(o_4623, "ring"), "setAttribute", ((V)("d")), ed_4624);
}
if (!SEq(Get(o_4623, "ringW"), w_4626)) {
Set(o_4623, "ringW", w_4626);
Invoke(Get(o_4623, "ring"), "setAttribute", ((V)("stroke-width")), w_4626);
}
if (!op_4627.IsNullish) {
Invoke(Get(o_4623, "ring"), "setAttribute", ((V)("opacity")), op_4627);
}
return default;
}, 1, "", true));
}
len_4549 = (ToNum((Get(L_4544, "castLen") is var _t4631 && Truthy(_t4631) ? _t4631 : ((V)(16D)))) * (1D - Min(1D, (ToNum(gl_4542) / 60D))));
off_4550 = ((ToNum(dx_4547) * len_4549) * 0.55);
Call(S_4545, V.Undef, Get(T_4543, "cast"), ((V)("cx")), Add(cx_4546, ((V)(off_4550))));
Call(S_4545, V.Undef, Get(T_4543, "cast"), ((V)("cy")), Add(Add(G_4540, ((V)(0.8))), ((V)((System.Math.Abs(ToNum(dy_4548)) * 0.6)))));
Call(S_4545, V.Undef, Get(T_4543, "cast"), ((V)("rx")), ((V)(((27D * (1D + (ToNum(sq_4541) * 0.45))) + (System.Math.Abs(off_4550) * 0.8)))));
Call(S_4545, V.Undef, Get(T_4543, "cast"), ((V)("ry")), ((V)((6.2 * (1D - (ToNum(gl_4542) / 90D))))));
Invoke(Get(T_4543, "cast"), "setAttribute", ((V)("opacity")), Call(r2_14, V.Undef, ((V)((ToNum((Get(L_4544, "cast") is var _t4632 && Truthy(_t4632) ? _t4632 : ((V)(0D)))) * Max(0D, (1D - (ToNum(gl_4542) / 45D))))))));
return default;
}, 5, "litTick", false);
mount_95 = Fn((V _self4633, int _argc4634, V host_4640, V key_4641, V opts_4642, V _a4639, V[] _rest4635) => {
V ak0_4643 = default;
V D_4644 = default;
V u_4645 = default;
V now_4646 = default;
V I_4647 = default;
V wrap_4648 = default;
V svg_4649 = default;
V loc_4650 = default;
V up_4651 = default;
if (_self4633.IsNullish) _self4633 = GlobalV;
ak0_4643 = key_4641;
key_4641 = ((Get(G("window"), "SQ_ALIAS") is var _t4652 && !Truthy(_t4652) ? _t4652 : GetK(Get(G("window"), "SQ_ALIAS"), key_4641)) is var _t4653 && Truthy(_t4653) ? _t4653 : key_4641);
opts_4642 = (opts_4642 is var _t4654 && Truthy(_t4654) ? _t4654 : NewObj(0).V);
D_4644 = (GetK(DEFS_34, key_4641) is var _t4655 && Truthy(_t4655) ? _t4655 : Get(DEFS_34, "mittens"));
u_4645 = ((V)(string.Concat("rv", NumStr(++UID_68))));
now_4646 = Invoke(G("performance"), "now");
I_4647 = NewObj(33).Put("D", D_4644).Put("lookM", (!Get(opts_4642, "look").IsNullish ? ((V)(Max(0D, Min(4D, ((double)(ToInt32(ToNum(Get(opts_4642, "look"))) | ToInt32(0D))))))) : V.Null)).Put("onState", Get(opts_4642, "onState")).Put("cur", NewObj(2).Put("name", ((V)("idle"))).Put("t0", now_4646).V).Put("prev", V.Null).Put("shots", Arr()).Put("press", (false ? V.True : V.False)).Put("spinOff", ((V)(0D))).Put("ptr", V.Null).Put("gl", Arr(((V)(0D)), ((V)(0D)))).Put("glAt", Add(now_4646, ((V)(1200D)))).Put("blinkT", ((V)((-1000000000D)))).Put("blinkAt", Add(now_4646, ((V)(1500D)))).Put("dbl", (false ? V.True : V.False)).Put("hs", ((V)(0D))).Put("lastSpin", V.Null).Put("queue", Arr()).Put("ctr", NewObj(0).V).Put("ctT", NewObj(0).V).Put("emL", NewObj(0).V).Put("parts", Arr()).Put("fidgets", (!SEq(Get(opts_4642, "fidgets"), (false ? V.True : V.False)) ? V.True : V.False)).Put("ak", ak0_4643).Put("flw", New(Fol_20, ((V)(1D)), ((V)(8D)))).Put("fex", New(Fol_20, ((V)(0D)), ((V)(22D)))).Put("fey", New(Fol_20, ((V)(0D)), ((V)(22D)))).Put("fhx", New(Fol_20, ((V)(0D)), ((V)(6.5)))).Put("fhy", New(Fol_20, ((V)(0D)), ((V)(6.5)))).Put("fp", New(Fol_20, ((V)(0D)), ((V)(14D)))).Put("fs", New(Fol_20, ((V)(0D)), ((V)(18D)), ((V)(0.55)))).Put("fx", New(Fol_20, ((V)(0D)), ((V)(9D)), ((V)(0.6)))).Put("fl", New(Fol_20, ((V)(0D)), ((V)(9D)), ((V)(0.6)))).Put("fsp", New(Fol_20, ((V)(0D)), ((V)(7D)), ((V)(0.7)))).V;
wrap_4648 = Invoke(G("document"), "createElement", ((V)("div")));
Set(Get(wrap_4648, "style"), "cssText", ((V)("position:relative;width:100%;height:100%;touch-action:none;cursor:pointer;user-select:none;-webkit-user-select:none;will-change:opacity;")));
Set(host_4640, "innerHTML", ((V)("")));
Invoke(host_4640, "appendChild", wrap_4648);
svg_4649 = Call(mk_32, V.Undef, ((V)("svg")), NewObj(3).Put("viewBox", ((V)("0 0 100 100"))).Put("width", ((V)("100%"))).Put("height", ((V)("100%"))).V);
Set(Get(svg_4649, "style"), "cssText", ((V)("position:absolute;inset:0;overflow:visible;pointer-events:none;")));
Invoke(wrap_4648, "appendChild", svg_4649);
if (Truthy(((!(Truthy(GetK(DEFS_34, key_4641))) ? V.True : V.False) is var _t4656 && !Truthy(_t4656) ? _t4656 : Get(G("window"), "RiveGeneric")))) {
Set(I_4647, "generic", (true ? V.True : V.False));
Set(I_4647, "key", key_4641);
Set(I_4647, "u", u_4645);
Invoke(Get(G("window"), "RiveGeneric"), "build", I_4647, svg_4649, key_4641, NewObj(17).Put("mk", mk_32).Put("ellS", ellS_22).Put("toD", toD_25).Put("parsePath", parsePath_21).Put("ellAx", ellAx_30).Put("smoothD", smoothD_26).Put("SM", SM_16).Put("clamp", clamp_13).Put("lerp", lerp_15).Put("r2", r2_14).Put("D2R", ((V)(D2R_11))).Put("TAU", ((V)(TAU_12))).Put("Fol", Fol_20).Put("earSec", earSec_31).Put("flat", flat_27).Put("hull", hull_28).Put("closedD", closedD_29).V);
} else {
V g_4657 = default;
V FUR_4658 = default;
V CF_4659 = default;
V pg_4660 = default;
V E_4661 = default;
V face_4662 = default;
V wg_4663 = default;
V t0_4664 = default;
V t1_4665 = default;
V t2_4666 = default;
V t3_4667 = default;
V cub_4668 = default;
Set(I_4647, "key", key_4641);
g_4657 = Get(Get(D_4644, "c"), "g");
Set(Call(mk_32, V.Undef, ((V)("defs")), NewObj(0).V, svg_4649), "innerHTML", ((V)(string.Concat(new string[] { "<radialGradient id=\"g", ToStr(u_4645), "\" cx=\"38%\" cy=\"30%\" r=\"75%\"><stop offset=\"0\" stop-color=\"", ToStr(GetIdx(g_4657, 0D)), "\"/><stop offset=\"0.6\" stop-color=\"", ToStr(GetIdx(g_4657, 1D)), "\"/><stop offset=\"1\" stop-color=\"", ToStr(GetIdx(g_4657, 2D)), "\"/></radialGradient>", (Truthy(Get(Get(D_4644, "c"), "ge")) ? string.Concat(new string[] { "<radialGradient id=\"ge", ToStr(u_4645), "\" cx=\"38%\" cy=\"30%\" r=\"75%\"><stop offset=\"0\" stop-color=\"", ToStr(GetIdx(Get(Get(D_4644, "c"), "ge"), 0D)), "\"/><stop offset=\"0.6\" stop-color=\"", ToStr(GetIdx(Get(Get(D_4644, "c"), "ge"), 1D)), "\"/><stop offset=\"1\" stop-color=\"", ToStr(GetIdx(Get(Get(D_4644, "c"), "ge"), 2D)), "\"/></radialGradient>" }) : ""), "<radialGradient id=\"ey", ToStr(u_4645), "\" cx=\"35%\" cy=\"30%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#6b5470\"/><stop offset=\"1\" stop-color=\"#2a1a30\"/></radialGradient>", "<filter id=\"ft", ToStr(u_4645), "\" x=\"-15%\" y=\"-15%\" width=\"130%\" height=\"130%\">", ToStr(Call(fabricFx_9, V.Undef)), "<feComposite in2=\"SourceGraphic\" operator=\"in\"/><feBlend in=\"SourceGraphic\" mode=\"multiply\"/></filter>", "<clipPath id=\"fc", ToStr(u_4645), "\" clipPathUnits=\"userSpaceOnUse\"><path/></clipPath>", ToStr(Invoke(Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _self4633, int _argc4669, V i_4675, V _a4672, V _a4673, V _a4674, V[] _rest4670) => {
return ((V)(string.Concat(new string[] { "<clipPath id=\"fk", ToStr(i_4675), ToStr(u_4645), "\" clipPathUnits=\"userSpaceOnUse\"><path/></clipPath><clipPath id=\"ek", ToStr(i_4675), ToStr(u_4645), "\" clipPathUnits=\"userSpaceOnUse\"><path/></clipPath>" })));
}, 1, "", true)), "join", ((V)("")))), "<clipPath id=\"ec0", ToStr(u_4645), "\" clipPathUnits=\"userSpaceOnUse\"><path/></clipPath><clipPath id=\"ec1", ToStr(u_4645), "\" clipPathUnits=\"userSpaceOnUse\"><path/></clipPath>" }))));
if (Truthy(((SEqS(key_4641, "mittens") ? V.True : V.False) is var _t4676 && !Truthy(_t4676) ? _t4676 : Get(D_4644, "arms")))) {
Set(I_4647, "hkx", ((V)((System.Math.Abs((50D - ToNum(GetIdx(Get(GetIdx(Get(D_4644, "arms"), 0D), "e"), 0D)))) / 18D))));
}
if (Truthy((((((!SEqS(key_4641, "mittens") && !(Truthy(Get(D_4644, "mittensFrame")))) ? V.True : V.False) is var _t4677 && !Truthy(_t4677) ? _t4677 : Get(D_4644, "mouth")) is var _t4678 && !Truthy(_t4678) ? _t4678 : Get(D_4644, "eyes")) is var _t4679 && !Truthy(_t4679) ? _t4679 : Get(D_4644, "arms")))) {
double pawY_4680 = 0;
V pawX_4681 = default;
V MY_4682 = default;
V CY_4683 = default;
V pl_4684 = default;
double kx_4685 = 0;
double mxk_4686 = 0;
pawY_4680 = (ToNum(Add(GetIdx(Get(GetIdx(Get(D_4644, "arms"), 0D), "e"), 1D), GetIdx(Get(GetIdx(Get(D_4644, "arms"), 1D), "e"), 1D))) / 2D);
pawX_4681 = GetIdx(Get(GetIdx(Get(D_4644, "arms"), 0D), "e"), 0D);
MY_4682 = Arr(((V)(17D)), ((V)(47D)), ((V)(58D)), ((V)(76D)), ((V)(95.5)));
CY_4683 = Invoke(Arr(Get(D_4644, "top"), GetIdx(GetIdx(Get(D_4644, "eyes"), 0D), 1D), GetIdx(Get(D_4644, "mouth"), 1D), ((V)(pawY_4680)), Get(D_4644, "G")), "map", Fn((V _self4633, int _argc4687, V v_4693, V i_4694, V a2_4695, V _a4692, V[] _rest4688) => {
return (Truthy((i_4694 is var _t4696 && !Truthy(_t4696) ? _t4696 : (Le(v_4693, GetIdx(a2_4695, (ToNum(i_4694) - 1D))) ? V.True : V.False))) ? Add(GetIdx(a2_4695, (ToNum(i_4694) - 1D)), ((V)(1D))) : v_4693);
}, 3, "", true));
pl_4684 = Fn((V _self4633, int _argc4697, V A_4703, V B_4704, V v_4705, V _a4702, V[] _rest4698) => {
{
double i_4706 = 0;
i_4706 = 1D;
while (true) {
if (!(Lt(((V)(i_4706)), Get(A_4703, "length")))) break;
if ((Le(v_4705, GetIdx(A_4703, i_4706)) || (i_4706 == (ToNum(Get(A_4703, "length")) - 1D)))) {
return Add(GetIdx(B_4704, (i_4706 - 1D)), ((V)((((ToNum(v_4705) - ToNum(GetIdx(A_4703, (i_4706 - 1D)))) * (ToNum(GetIdx(B_4704, i_4706)) - ToNum(GetIdx(B_4704, (i_4706 - 1D))))) / (ToNum(GetIdx(A_4703, i_4706)) - ToNum(GetIdx(A_4703, (i_4706 - 1D))))))));
}
i_4706++;
}
}
return default;
}, 3, "", true);
kx_4685 = Max(0.5, (System.Math.Abs((50D - ToNum(pawX_4681))) / 18D));
mxk_4686 = ((System.Math.Abs((50D - ToNum(GetIdx(Get(D_4644, "mouth"), 0D)))) < 1D) ? 1D : 1D);
Set(I_4647, "mapHand", Fn((V _self4633, int _argc4708, V inX_4714, V hy_4715, V _a4712, V _a4713, V[] _rest4709) => {
return Arr(((V)((ToNum(inX_4714) * kx_4685))), ((V)((ToNum(Call(pl_4684, V.Undef, MY_4682, CY_4683, Add(((V)(76D)), hy_4715))) - pawY_4680))));
}, 2, "", true));
Set(I_4647, "foodK", ((V)(Max(0.05, Min(1.5, ((pawY_4680 - ToNum(GetIdx(Get(D_4644, "mouth"), 1D))) / 18D))))));
Set(I_4647, "toM", Fn((V _self4633, int _argc4716, V x_4722, V y_4723, V _a4720, V _a4721, V[] _rest4717) => {
return Arr(((V)((50D + (((ToNum(x_4722) - ToNum(GetIdx(Get(D_4644, "head"), 0D))) / ToNum(GetIdx(Get(D_4644, "head"), 2D))) * 29D)))), Call(pl_4684, V.Undef, CY_4683, MY_4682, y_4723));
}, 2, "", true));
Set(I_4647, "fromM", Fn((V _self4633, int _argc4724, V x_4730, V y_4731, V _a4728, V _a4729, V[] _rest4725) => {
return Arr(Add(GetIdx(Get(D_4644, "head"), 0D), ((V)((((ToNum(x_4730) - 50D) / 29D) * ToNum(GetIdx(Get(D_4644, "head"), 2D)))))), Call(pl_4684, V.Undef, MY_4682, CY_4683, y_4731));
}, 2, "", true));
}
FUR_4658 = ((V)(string.Concat("url(#g", ToStr(u_4645), ")")));
CF_4659 = Fn((V _self4633, int _argc4732, V f_4738, V _a4735, V _a4736, V _a4737, V[] _rest4733) => {
return (Truthy(f_4738) ? Invoke(((V)(ToStrS(f_4738))), "replace", NewRegExp(RX7, "url\\(#([^)]+)\\)", ""), ((V)(string.Concat("url(#$1", ToStr(u_4645), ")")))) : FUR_4658);
}, 1, "", true);
Invoke(Invoke(svg_4649, "querySelector", ((V)("defs"))), "insertAdjacentHTML", ((V)("beforeend")), ((V)(string.Concat("<radialGradient id=\"phz", ToStr(u_4645), "\"><stop offset=\"0\" stop-color=\"#cbcac7\" stop-opacity=\"0.85\"/><stop offset=\"0.5\" stop-color=\"#d3d2cf\" stop-opacity=\"0.45\"/><stop offset=\"1\" stop-color=\"#d9d8d5\" stop-opacity=\"0\"/></radialGradient>"))));
if (Truthy(Get(D_4644, "grads"))) {
Invoke(Invoke(svg_4649, "querySelector", ((V)("defs"))), "insertAdjacentHTML", ((V)("beforeend")), Invoke(Invoke(Object_keys(Get(D_4644, "grads")), "map", Fn((V _self4633, int _argc4739, V id_4745, V _a4742, V _a4743, V _a4744, V[] _rest4740) => {
return ((V)(string.Concat(new string[] { "<radialGradient id=\"", ToStr(id_4745), ToStr(u_4645), "\" cx=\"38%\" cy=\"30%\" r=\"75%\">", ToStr(Invoke(Invoke(GetK(Get(D_4644, "grads"), id_4745), "map", Fn((V _self4633, int _argc4746, V _a4748, V _a4749, V _a4750, V _a4751, V[] _rest4747) => {
V o_4754 = default;
V c_4756 = default;
{ V _t4752 = ListOf(_a4748);
{ V _t4753 = GetIdx(_t4752, 0D);
o_4754 = _t4753; }
{ V _t4755 = GetIdx(_t4752, 1D);
c_4756 = _t4755; }
}
return ((V)(string.Concat(new string[] { "<stop offset=\"", ToStr(o_4754), "\" stop-color=\"", ToStr(c_4756), "\"/>" })));
}, 1, "", true)), "join", ((V)("")))), "</radialGradient>" })));
}, 1, "", true)), "join", ((V)(""))));
}
if (Truthy((Get(D_4644, "mane") is var _t4757 && !Truthy(_t4757) ? _t4757 : Get(Get(D_4644, "mane"), "hog")))) {
V gs_4758 = default;
gs_4758 = ((Get(D_4644, "grads") is var _t4760 && !Truthy(_t4760) ? _t4760 : GetK(Get(D_4644, "grads"), GetIdx((Invoke(((V)(ToStrS(Get(Get(D_4644, "mane"), "fill")))), "match", NewRegExp(RX7, "url\\(#([^)]+)\\)", "")) is var _t4759 && Truthy(_t4759) ? _t4759 : Arr()), 1D))) is var _t4761 && Truthy(_t4761) ? _t4761 : Arr(Arr(((V)("0")), ((V)("#a8794e"))), Arr(((V)("1")), ((V)("#5a3a22")))));
Invoke(Invoke(svg_4649, "querySelector", ((V)("defs"))), "insertAdjacentHTML", ((V)("beforeend")), ((V)(string.Concat(new string[] { "<radialGradient id=\"hg", ToStr(u_4645), "\" gradientUnits=\"userSpaceOnUse\" cx=\"40\" cy=\"38\" r=\"58\">", ToStr(Invoke(Invoke(gs_4758, "map", Fn((V _self4633, int _argc4762, V _a4764, V _a4765, V _a4766, V _a4767, V[] _rest4763) => {
V o_4770 = default;
V c_4772 = default;
{ V _t4768 = ListOf(_a4764);
{ V _t4769 = GetIdx(_t4768, 0D);
o_4770 = _t4769; }
{ V _t4771 = GetIdx(_t4768, 1D);
c_4772 = _t4771; }
}
return ((V)(string.Concat(new string[] { "<stop offset=\"", ToStr(o_4770), "\" stop-color=\"", ToStr(c_4772), "\"/>" })));
}, 1, "", true)), "join", ((V)("")))), "</radialGradient>" }))));
}
Set(I_4647, "shadow", Call(mk_32, V.Undef, ((V)("ellipse")), NewObj(2).Put("fill", ((V)("#6a1b9a"))).Put("opacity", ((V)(0.2))).V, svg_4649));
Set(I_4647, "root", Call(mk_32, V.Undef, ((V)("g")), NewObj(1).Put("filter", ((V)(string.Concat("url(#ft", ToStr(u_4645), ")")))).V, svg_4649));
Set(I_4647, "pg", NewObj(0).V);
Set(I_4647, "u", u_4645);
Invoke(Arr(((V)("mane")), ((V)("tail")), ((V)("footL")), ((V)("footR")), ((V)("body")), ((V)("coatB")), ((V)("earL")), ((V)("earR")), ((V)("head")), ((V)("maneF")), ((V)("collar")), ((V)("pup")), ((V)("prop")), ((V)("armL")), ((V)("armR"))), "forEach", Fn((V _self4633, int _argc4773, V k_4779, V _a4776, V _a4777, V _a4778, V[] _rest4774) => {
return SetK(Get(I_4647, "pg"), k_4779, Call(mk_32, V.Undef, ((V)("g")), NewObj(0).V, Get(I_4647, "root")));
}, 1, "", true));
pg_4660 = Get(I_4647, "pg");
E_4661 = Set(I_4647, "E", NewObj(0).V);
if (Truthy((Get(D_4644, "collar") is var _t4780 && !Truthy(_t4780) ? _t4780 : Get(Get(D_4644, "collar"), "ring")))) {
V g_4781 = default;
V Q0_4782 = default;
V gb_4783 = default;
g_4781 = Get(pg_4660, "collar");
Invoke(Invoke(svg_4649, "querySelector", ((V)("defs"))), "insertAdjacentHTML", ((V)("beforeend")), ((V)(string.Concat(new string[] { ToStr(Call(Fn((V _self4633, int _argc4786, V M_4792, V _a4789, V _a4790, V _a4791, V[] _rest4787) => {
return ((V)(string.Concat(new string[] { "<radialGradient id=\"tg", ToStr(u_4645), "\" cx=\"35%\" cy=\"30%\" r=\"75%\"><stop offset=\"0\" stop-color=\"", ToStr(GetIdx(M_4792, 0D)), "\"/><stop offset=\"0.45\" stop-color=\"", ToStr(GetIdx(M_4792, 1D)), "\"/><stop offset=\"1\" stop-color=\"", ToStr(GetIdx(M_4792, 2D)), "\"/></radialGradient>" })));
}, 1, "", true), V.Undef, ((Get(D_4644, "tag") is var _t4784 && !Truthy(_t4784) ? _t4784 : Get(Get(D_4644, "tag"), "metal")) is var _t4785 && Truthy(_t4785) ? _t4785 : Arr(((V)("#fff7c4")), ((V)("#ffd84a")), ((V)("#c9921c")))))), "<linearGradient id=\"bg", ToStr(u_4645), "\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff0a8\"/><stop offset=\"1\" stop-color=\"#c9921c\"/></linearGradient>", "<filter id=\"csb", ToStr(u_4645), "\" x=\"-20%\" y=\"-50%\" width=\"140%\" height=\"200%\"><feGaussianBlur stdDeviation=\"0.7\"/></filter>" }))));
Set(E_4661, "cr", NewObj(12).Put("sh", Call(mk_32, V.Undef, ((V)("path")), NewObj(6).Put("fill", ((V)("none"))).Put("stroke", ((V)("#6a3d14"))).Put("stroke-width", ((V)(1.7))).Put("opacity", ((V)(0.22))).Put("stroke-linecap", ((V)("round"))).Put("filter", ((V)(string.Concat("url(#csb", ToStr(u_4645), ")")))).V, g_4781)).Put("segs", Array_from(NewObj(1).Put("length", ((V)(48D))).V, Fn((V _self4633, int _argc4793, V _a4795, V _a4796, V _a4797, V _a4798, V[] _rest4794) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(2).Put("stroke-width", ((V)(0.3))).Put("stroke-linejoin", ((V)("round"))).V, g_4781);
}, 0, "", true))).Put("hl", Call(mk_32, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", Get(Get(Get(D_4644, "collar"), "ring"), "light")).Put("stroke-width", ((V)(0.6))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.85))).V, g_4781)).Put("lo", Call(mk_32, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", Get(Get(Get(D_4644, "collar"), "ring"), "dark")).Put("stroke-width", ((V)(0.55))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.7))).V, g_4781)).Put("st", Call(mk_32, V.Undef, ((V)("path")), NewObj(6).Put("fill", ((V)("none"))).Put("stroke", (Get(Get(Get(D_4644, "collar"), "ring"), "stitch") is var _t4799 && Truthy(_t4799) ? _t4799 : ((V)("#ffd6df")))).Put("stroke-width", ((V)(0.32))).Put("stroke-dasharray", ((V)("0.9 0.75"))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.8))).V, g_4781)).Put("bk", Call(mk_32, V.Undef, ((V)("path")), NewObj(3).Put("fill", ((V)(string.Concat("url(#bg", ToStr(u_4645), ")")))).Put("stroke", ((V)("#a8761a"))).Put("stroke-width", ((V)(0.35))).V, g_4781)).Put("bki", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Get(Get(Get(D_4644, "collar"), "ring"), "dark")).V, g_4781)).Put("bkp", Call(mk_32, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#c9921c"))).Put("stroke-width", ((V)(0.6))).Put("stroke-linecap", ((V)("round"))).V, g_4781)).Put("rg", Call(mk_32, V.Undef, ((V)("ellipse")), NewObj(3).Put("fill", ((V)("none"))).Put("stroke", (((Get(D_4644, "tag") is var _t4800 && !Truthy(_t4800) ? _t4800 : Get(Get(D_4644, "tag"), "metal")) is var _t4801 && !Truthy(_t4801) ? _t4801 : GetIdx(Get(Get(D_4644, "tag"), "metal"), 3D)) is var _t4802 && Truthy(_t4802) ? _t4802 : ((V)("#c9921c")))).Put("stroke-width", ((V)(0.55))).V, g_4781)).Put("tg", Call(mk_32, V.Undef, ((V)("ellipse")), NewObj(3).Put("fill", ((V)(string.Concat("url(#tg", ToStr(u_4645), ")")))).Put("stroke", (((Get(D_4644, "tag") is var _t4803 && !Truthy(_t4803) ? _t4803 : Get(Get(D_4644, "tag"), "metal")) is var _t4804 && !Truthy(_t4804) ? _t4804 : GetIdx(Get(Get(D_4644, "tag"), "metal"), 3D)) is var _t4805 && Truthy(_t4805) ? _t4805 : ((V)("#b07d14")))).Put("stroke-width", ((V)(0.45))).V, g_4781)).Put("ti", Call(mk_32, V.Undef, ((V)("ellipse")), NewObj(3).Put("fill", ((V)("none"))).Put("stroke", (((Get(D_4644, "tag") is var _t4806 && !Truthy(_t4806) ? _t4806 : Get(Get(D_4644, "tag"), "metal")) is var _t4807 && !Truthy(_t4807) ? _t4807 : GetIdx(Get(Get(D_4644, "tag"), "metal"), 2D)) is var _t4808 && Truthy(_t4808) ? _t4808 : ((V)("#e8b52c")))).Put("stroke-width", ((V)(0.35))).V, g_4781)).Put("gl", Call(mk_32, V.Undef, ((V)("ellipse")), NewObj(2).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.75))).V, g_4781)).V);
Invoke(Invoke(svg_4649, "querySelector", ((V)("defs"))), "insertAdjacentHTML", ((V)("beforeend")), ((V)(string.Concat("<mask id=\"cm", ToStr(u_4645), "\" maskUnits=\"userSpaceOnUse\" x=\"-60\" y=\"-60\" width=\"220\" height=\"220\"><path fill=\"#fff\"/><path fill=\"#fff\"/></mask>"))));
Q0_4782 = Get(E_4661, "cr");
gb_4783 = Call(mk_32, V.Undef, ((V)("g")), NewObj(1).Put("mask", ((V)(string.Concat("url(#cm", ToStr(u_4645), ")")))).V, g_4781);
Invoke(g_4781, "insertBefore", gb_4783, Get(g_4781, "firstChild"));
Invoke(Invoke(Arr(Get(Q0_4782, "sh")), "concat", Get(Q0_4782, "segs"), Arr(Get(Q0_4782, "hl"), Get(Q0_4782, "lo"), Get(Q0_4782, "st"), Get(Q0_4782, "bk"), Get(Q0_4782, "bki"), Get(Q0_4782, "bkp"))), "forEach", Fn((V _self4633, int _argc4809, V e_4815, V _a4812, V _a4813, V _a4814, V[] _rest4810) => {
return Invoke(gb_4783, "appendChild", e_4815);
}, 1, "", true));
Set(Q0_4782, "mk", new ArrBuilder().Spread(Invoke(svg_4649, "querySelectorAll", ((V)(string.Concat("#cm", ToStr(u_4645), " path"))))).V);
} else {
if (Truthy(Get(D_4644, "collar"))) {
Set(E_4661, "collar", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Get(Get(D_4644, "collar"), "fill")).V, Get(pg_4660, "collar")));
Set(E_4661, "tag", Call(mk_32, V.Undef, ((V)("path")), NewObj(3).Put("fill", Get(Get(D_4644, "tag"), "fill")).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(0.8))).V, Get(pg_4660, "collar")));
}
}
if (Truthy(Get(D_4644, "tail3"))) {
Invoke(Invoke(svg_4649, "querySelector", ((V)("defs"))), "insertAdjacentHTML", ((V)("beforeend")), ((V)(string.Concat(new string[] { "<radialGradient id=\"tb", ToStr(u_4645), "\"><stop offset=\"0\" stop-color=\"", ToStr((Get(Get(D_4644, "c"), "tailB") is var _t4816 && Truthy(_t4816) ? _t4816 : ((V)("#eba264")))), "\"/><stop offset=\"0.55\" stop-color=\"", ToStr((Get(Get(D_4644, "c"), "tailB") is var _t4817 && Truthy(_t4817) ? _t4817 : ((V)("#eba264")))), "\" stop-opacity=\"0.85\"/><stop offset=\"1\" stop-color=\"", ToStr((Get(Get(D_4644, "c"), "tailB") is var _t4818 && Truthy(_t4818) ? _t4818 : ((V)("#eba264")))), "\" stop-opacity=\"0\"/></radialGradient>" }))));
Set(E_4661, "tailT", Invoke(Arr(((V)(1.55)), ((V)(1.25))), "map", Fn((V _self4633, int _argc4819, V _a4821, V _a4822, V _a4823, V _a4824, V[] _rest4820) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", Get(Get(D_4644, "c"), "tail")).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V, Get(pg_4660, "tail"));
}, 0, "", true)));
if (Truthy(Get(D_4644, "tailTaper"))) {
Set(E_4661, "tailF", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Get(Get(D_4644, "c"), "tail")).V, Get(pg_4660, "tail")));
Invoke(Invoke(svg_4649, "querySelector", ((V)("defs"))), "insertAdjacentHTML", ((V)("beforeend")), ((V)(string.Concat("<filter id=\"tsb", ToStr(u_4645), "\" x=\"-30%\" y=\"-30%\" width=\"160%\" height=\"160%\"><feGaussianBlur stdDeviation=\"0.9\"/></filter>"))));
Set(E_4661, "tailS", Call(mk_32, V.Undef, ((V)("path")), NewObj(4).Put("fill", (Get(D_4644, "tailShade") is var _t4825 && Truthy(_t4825) ? _t4825 : ((V)("#c9873f")))).Put("opacity", ((V)(0.38))).Put("filter", ((V)(string.Concat("url(#tsb", ToStr(u_4645), ")")))).Put("clip-path", ((V)(string.Concat("url(#tsc", ToStr(u_4645), ")")))).V, Get(pg_4660, "tail")));
Invoke(Invoke(svg_4649, "querySelector", ((V)("defs"))), "insertAdjacentHTML", ((V)("beforeend")), ((V)(string.Concat("<clipPath id=\"tsc", ToStr(u_4645), "\" clipPathUnits=\"userSpaceOnUse\"><path/></clipPath>"))));
Set(E_4661, "tailSC", Invoke(svg_4649, "querySelector", ((V)(string.Concat("#tsc", ToStr(u_4645), " path")))));
}
}
Set(E_4661, "tail", Call(mk_32, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", Get(Get(D_4644, "c"), "tail")).Put("stroke-width", ((V)(7D))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V, Get(pg_4660, "tail")));
Set(E_4661, "tailH", Call(mk_32, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", (Get(Get(D_4644, "c"), "tailHL") is var _t4826 && Truthy(_t4826) ? _t4826 : ((V)("#ffd2a3")))).Put("stroke-width", ((V)(2D))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.55))).V, Get(pg_4660, "tail")));
if (Truthy(Get(D_4644, "tail3"))) {
Set(E_4661, "tailB", Call(mk_32, V.Undef, ((V)("ellipse")), NewObj(1).Put("fill", ((V)(string.Concat("url(#tb", ToStr(u_4645), ")")))).V, Get(pg_4660, "tail")));
}
Set(E_4661, "feet", Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _self4633, int _argc4827, V i_4833, V _a4830, V _a4831, V _a4832, V[] _rest4828) => {
V p_4834 = default;
V lg_4835 = default;
p_4834 = GetK(pg_4660, ((V)((Truthy(i_4833) ? "footR" : "footL"))));
lg_4835 = (Truthy((Get(D_4644, "web") is var _t4837 && !Truthy(_t4837) ? _t4837 : Get(Get(D_4644, "web"), "leg"))) ? Call(mk_32, V.Undef, ((V)("path")), NewObj(3).Put("fill", ((V)("none"))).Put("stroke", Call(CF_4659, V.Undef, (Get(Get(Get(D_4644, "web"), "leg"), "fill") is var _t4836 && Truthy(_t4836) ? _t4836 : Get(Get(D_4644, "c"), "foot")))).Put("stroke-linecap", ((V)("round"))).V, p_4834) : V.Null);
return NewObj(4).Put("leg", lg_4835).Put("f", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4659, V.Undef, Get(Get(D_4644, "c"), "foot"))).V, p_4834)).Put("p", Call(mk_32, V.Undef, ((V)("path")), NewObj(3).Put("fill", Get(Get(D_4644, "c"), "pad")).Put("opacity", ((V)(0.9))).Put("clip-path", ((V)(string.Concat("url(#fk", ToStr(i_4833), ToStr(u_4645), ")")))).V, p_4834)).Put("clip", Invoke(svg_4649, "querySelector", ((V)(string.Concat("#fk", ToStr(i_4833), ToStr(u_4645), " path"))))).V;
return default;
}, 1, "", true)));
if (Truthy(Get(D_4644, "mane"))) {
V ma_4838 = default;
ma_4838 = NewObj(4).Put("fill", Call(CF_4659, V.Undef, Get(Get(D_4644, "mane"), "fill"))).Put("stroke", (Truthy(Get(Get(D_4644, "mane"), "stroke")) ? Call(CF_4659, V.Undef, Get(Get(D_4644, "mane"), "stroke")) : ((V)("none")))).Put("stroke-width", (Get(Get(D_4644, "mane"), "sw") is var _t4839 && Truthy(_t4839) ? _t4839 : ((V)(0D)))).Put("stroke-linejoin", ((V)("round"))).V;
Set(E_4661, "mane", Call(mk_32, V.Undef, ((V)("path")), ma_4838, Get(pg_4660, "mane")));
if (Truthy(Get(Get(D_4644, "mane"), "spiky"))) {
Set(E_4661, "maneF", Call(mk_32, V.Undef, ((V)("path")), ma_4838, Get(pg_4660, "maneF")));
}
}
Set(E_4661, "body", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4659, V.Undef, Get(Get(D_4644, "c"), "body"))).V, Get(pg_4660, "body")));
if (Truthy(Get(D_4644, "hideBody"))) {
Set(Get(Get(E_4661, "body"), "style"), "display", ((V)("none")));
}
if (Truthy((Get(D_4644, "belly") is var _t4840 && Truthy(_t4840) ? _t4840 : Get(D_4644, "bellyD")))) {
Set(E_4661, "belly", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4659, V.Undef, (Truthy(Get(D_4644, "bellyD")) ? Get(Get(D_4644, "bellyD"), "fill") : GetIdx(Get(D_4644, "belly"), 4D)))).V, Get(pg_4660, "body")));
}
Set(E_4661, "bodyG", Call(mk_32, V.Undef, ((V)("path")), NewObj(2).Put("fill", ((V)("#93b84a"))).Put("opacity", ((V)(0D))).V, Get(pg_4660, "body")));
if (Truthy(Get(D_4644, "neck3"))) {
Set(E_4661, "neck3", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4659, V.Undef, (Get(Get(D_4644, "neck3"), "fill") is var _t4841 && Truthy(_t4841) ? _t4841 : Get(Get(D_4644, "c"), "body")))).V, Get(pg_4660, "body")));
Invoke(Get(pg_4660, "body"), "insertBefore", Get(E_4661, "neck3"), Get(E_4661, "body"));
}
if (Truthy(Get(D_4644, "lumps"))) {
Set(E_4661, "lumps", Invoke(Get(D_4644, "lumps"), "map", Fn((V _self4633, int _argc4842, V L_4848, V _a4845, V _a4846, V _a4847, V[] _rest4843) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4659, V.Undef, (Get(L_4848, "fill") is var _t4849 && Truthy(_t4849) ? _t4849 : Get(Get(D_4644, "c"), "body")))).V, Get(pg_4660, "body"));
}, 1, "", true)));
}
if (Truthy((Get(D_4644, "spots3") is var _t4850 && !Truthy(_t4850) ? _t4850 : Get(D_4644, "body3")))) {
Set(E_4661, "spots3", Call(mk_32, V.Undef, ((V)("path")), NewObj(2).Put("fill", Call(CF_4659, V.Undef, (Get(Get(D_4644, "spots3"), "fill") is var _t4851 && Truthy(_t4851) ? _t4851 : ((V)("#5a3a1e"))))).Put("opacity", (!Get(Get(D_4644, "spots3"), "op").IsNullish ? Get(Get(D_4644, "spots3"), "op") : ((V)(1D)))).V, Get(pg_4660, "body")));
}
Set(E_4661, "ears", Invoke(Get(D_4644, "ears"), "map", Fn((V _self4633, int _argc4852, V ed_4858, V i_4859, V _a4856, V _a4857, V[] _rest4853) => {
V p_4860 = default;
p_4860 = GetK(pg_4660, ((V)((GtN(Get(ed_4858, "side"), 0D) ? "earR" : "earL"))));
return NewObj(3).Put("o", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", (Truthy(Get(ed_4858, "fill")) ? Call(CF_4659, V.Undef, Get(ed_4858, "fill")) : (Truthy(Get(Get(D_4644, "c"), "ge")) ? ((V)(string.Concat("url(#ge", ToStr(u_4645), ")"))) : FUR_4658))).V, p_4860)).Put("n", Call(mk_32, V.Undef, ((V)("path")), NewObj(3).Put("fill", Call(CF_4659, V.Undef, (Get(ed_4858, "innerFill") is var _t4861 && Truthy(_t4861) ? _t4861 : Get(Get(D_4644, "c"), "inner")))).Put("opacity", (Get(ed_4858, "innerOp") is var _t4862 && Truthy(_t4862) ? _t4862 : ((V)(0.8)))).Put("clip-path", ((V)(string.Concat("url(#ek", ToStr(i_4859), ToStr(u_4645), ")")))).V, p_4860)).Put("clip", Invoke(svg_4649, "querySelector", ((V)(string.Concat("#ek", ToStr(i_4859), ToStr(u_4645), " path"))))).V;
return default;
}, 2, "", true)));
Invoke(Get(D_4644, "ears"), "forEach", Fn((V _self4633, int _argc4863, V ed_4869, V i_4870, V _a4867, V _a4868, V[] _rest4864) => {
V m_4871 = default;
if (!(Truthy(Get(ed_4869, "lobe")))) {
return default;
}
m_4871 = Call(mk_32, V.Undef, ((V)("mask")), NewObj(6).Put("id", ((V)(string.Concat("em", ToStr(i_4870), ToStr(u_4645))))).Put("maskUnits", ((V)("userSpaceOnUse"))).Put("x", ((V)((-50D)))).Put("y", ((V)((-50D)))).Put("width", ((V)(200D))).Put("height", ((V)(200D))).V, Invoke(svg_4649, "querySelector", ((V)("defs"))));
Call(mk_32, V.Undef, ((V)("rect")), NewObj(5).Put("x", ((V)((-50D)))).Put("y", ((V)((-50D)))).Put("width", ((V)(200D))).Put("height", ((V)(200D))).Put("fill", ((V)("#fff"))).V, m_4871);
Set(GetK(Get(E_4661, "ears"), i_4870), "mk", Arr(Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#000"))).V, m_4871), Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#000"))).V, m_4871)));
Invoke(GetK(pg_4660, ((V)((GtN(Get(ed_4869, "side"), 0D) ? "earR" : "earL")))), "setAttribute", ((V)("mask")), ((V)(string.Concat("url(#em", ToStr(i_4870), ToStr(u_4645), ")"))));
return default;
}, 2, "", true));
if (Truthy(Get(D_4644, "tufts"))) {
Set(E_4661, "tuftB", Call(mk_32, V.Undef, ((V)("g")), NewObj(0).V, Get(pg_4660, "head")));
}
Set(E_4661, "skull", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4659, V.Undef, Get(Get(D_4644, "c"), "head"))).V, Get(pg_4660, "head")));
Set(E_4661, "hx", Invoke((Get(D_4644, "headExtra") is var _t4880 && Truthy(_t4880) ? _t4880 : Arr()), "map", Fn((V _self4633, int _argc4872, V h_4878, V _a4875, V _a4876, V _a4877, V[] _rest4873) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(2).Put("fill", Call(CF_4659, V.Undef, Get(h_4878, "fill"))).Put("opacity", (Get(h_4878, "op") is var _t4879 && Truthy(_t4879) ? _t4879 : ((V)(1D)))).V, Get(pg_4660, "head"));
}, 1, "", true)));
if (Truthy(Get(D_4644, "crest"))) {
Set(E_4661, "crest", Invoke(Get(D_4644, "crest"), "map", Fn((V _self4633, int _argc4881, V c_4887, V _a4884, V _a4885, V _a4886, V[] _rest4882) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4659, V.Undef, (Get(c_4887, "fill") is var _t4888 && Truthy(_t4888) ? _t4888 : Get(Get(D_4644, "c"), "inner")))).V, Get(pg_4660, "earL"));
}, 1, "", true)));
}
if (Truthy(Get(D_4644, "tufts"))) {
Set(E_4661, "tuftF", Call(mk_32, V.Undef, ((V)("g")), NewObj(0).V, Get(pg_4660, "head")));
Set(E_4661, "tuftG", Invoke(Get(D_4644, "tufts"), "map", Fn((V _self4633, int _argc4889, V _a4891, V _a4892, V _a4893, V _a4894, V[] _rest4890) => {
return Call(mk_32, V.Undef, ((V)("g")), NewObj(0).V, Get(E_4661, "tuftF"));
}, 0, "", true)));
Set(E_4661, "tufts", Invoke(Get(D_4644, "tufts"), "map", Fn((V _self4633, int _argc4895, V t_4901, V i_4902, V _a4899, V _a4900, V[] _rest4896) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4659, V.Undef, (Get(t_4901, "fill") is var _t4903 && Truthy(_t4903) ? _t4903 : ((V)("url(#wcr)"))))).V, GetK(Get(E_4661, "tuftG"), i_4902));
}, 2, "", true)));
Set(E_4661, "tuftsB", Invoke(Get(D_4644, "tufts"), "map", Fn((V _self4633, int _argc4904, V t_4910, V _a4907, V _a4908, V _a4909, V[] _rest4905) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4659, V.Undef, (Get(t_4910, "fill") is var _t4911 && Truthy(_t4911) ? _t4911 : ((V)("url(#wcr)"))))).V, Get(E_4661, "tuftB"));
}, 1, "", true)));
Set(E_4661, "tuftsW", Invoke(Get(D_4644, "tufts"), "map", Fn((V _self4633, int _argc4912, V t_4918, V i_4919, V _a4916, V _a4917, V[] _rest4913) => {
return (Truthy(Get(t_4918, "white")) ? Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", (GetIdx(Get(t_4918, "white"), 3D) is var _t4920 && Truthy(_t4920) ? _t4920 : ((V)("#fffef4")))).V, GetK(Get(E_4661, "tuftG"), i_4919)) : V.Null);
}, 2, "", true)));
Invoke(Invoke(svg_4649, "querySelector", ((V)("defs"))), "insertAdjacentHTML", ((V)("beforeend")), Invoke(Invoke(Get(D_4644, "tufts"), "map", Fn((V _self4633, int _argc4921, V t_4927, V i_4928, V _a4925, V _a4926, V[] _rest4922) => {
return ((V)(string.Concat(new string[] { "<radialGradient id=\"tfg", ToStr(i_4928), ToStr(u_4645), "\" gradientUnits=\"userSpaceOnUse\" cx=\"50\" cy=\"46\" r=\"60\"><stop offset=\"0\" stop-color=\"#000\"/><stop offset=\"0\" stop-color=\"#fff\"/></radialGradient>", "<mask id=\"tfm", ToStr(i_4928), ToStr(u_4645), "\" maskUnits=\"userSpaceOnUse\" x=\"-60\" y=\"-60\" width=\"220\" height=\"220\"><rect x=\"-60\" y=\"-60\" width=\"220\" height=\"220\" fill=\"url(#tfg", ToStr(i_4928), ToStr(u_4645), ")\"/></mask>" })));
}, 2, "", true)), "join", ((V)(""))));
Invoke(Get(E_4661, "tufts"), "forEach", Fn((V _self4633, int _argc4929, V el_4935, V i_4936, V _a4933, V _a4934, V[] _rest4930) => {
V gq_4937 = default;
Invoke(GetK(Get(E_4661, "tuftG"), i_4936), "setAttribute", ((V)("mask")), ((V)(string.Concat("url(#tfm", ToStr(i_4936), ToStr(u_4645), ")"))));
gq_4937 = Invoke(svg_4649, "querySelector", ((V)(string.Concat("#tfg", ToStr(i_4936), ToStr(u_4645)))));
Set(el_4935, "_g", gq_4937);
Set(el_4935, "_s", Invoke(gq_4937, "querySelectorAll", ((V)("stop"))));
return default;
}, 2, "", true));
}
face_4662 = Call(mk_32, V.Undef, ((V)("g")), NewObj(1).Put("clip-path", ((V)(string.Concat("url(#fc", ToStr(u_4645), ")")))).V, Get(pg_4660, "head"));
Set(E_4661, "muzzle", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Get(Get(D_4644, "c"), "muzzle")).V, face_4662));
Invoke((Get(E_4661, "hx") is var _t4945 && Truthy(_t4945) ? _t4945 : Arr()), "forEach", Fn((V _self4633, int _argc4938, V el_4944, V _a4941, V _a4942, V _a4943, V[] _rest4939) => {
return Invoke(face_4662, "insertBefore", el_4944, Get(E_4661, "muzzle"));
}, 1, "", true));
Set(E_4661, "tintR", Call(mk_32, V.Undef, ((V)("path")), NewObj(2).Put("fill", ((V)("#ff4040"))).Put("opacity", ((V)(0D))).V, face_4662));
Set(E_4661, "tintG", Call(mk_32, V.Undef, ((V)("path")), NewObj(2).Put("fill", ((V)("#93b84a"))).Put("opacity", ((V)(0D))).V, face_4662));
Set(E_4661, "stripes", Call(mk_32, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", Get(Get(D_4644, "c"), "stripe")).Put("stroke-width", ((V)(2D))).Put("stroke-linecap", ((V)("round"))).V, face_4662));
Set(E_4661, "back", Call(mk_32, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", Get(Get(D_4644, "c"), "stripe")).Put("stroke-width", (Get(D_4644, "backW") is var _t4946 && Truthy(_t4946) ? _t4946 : ((V)(2.2)))).Put("stroke-linecap", ((V)("round"))).V, face_4662));
Set(E_4661, "fx", Invoke((Get(D_4644, "faceExtra") is var _t4958 && Truthy(_t4958) ? _t4958 : Arr()), "map", Fn((V _self4633, int _argc4947, V fe_4953, V _a4950, V _a4951, V _a4952, V[] _rest4948) => {
return Call(mk_32, V.Undef, ((V)("path")), (Truthy((Get(fe_4953, "stroke") is var _t4957 && !Truthy(_t4957) ? _t4957 : (!(Truthy(Get(fe_4953, "fill"))) ? V.True : V.False))) ? NewObj(4).Put("fill", ((V)("none"))).Put("stroke", Get(fe_4953, "stroke")).Put("stroke-width", (Get(fe_4953, "sw") is var _t4954 && Truthy(_t4954) ? _t4954 : ((V)(1D)))).Put("stroke-linecap", ((V)("round"))).V : NewObj(3).Put("fill", Call(CF_4659, V.Undef, Get(fe_4953, "fill"))).Put("stroke", (Get(fe_4953, "stroke") is var _t4955 && Truthy(_t4955) ? _t4955 : ((V)("none")))).Put("stroke-width", (Get(fe_4953, "sw") is var _t4956 && Truthy(_t4956) ? _t4956 : ((V)(0D)))).V), face_4662);
}, 1, "", true)));
Set(E_4661, "nose", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Get(Get(D_4644, "c"), "nose")).V, face_4662));
if (Truthy(Get(D_4644, "noseHL"))) {
Set(E_4661, "noseHL", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#ffffff"))).V, face_4662));
}
Set(E_4661, "cheeks", Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _self4633, int _argc4959, V _a4961, V _a4962, V _a4963, V _a4964, V[] _rest4960) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Get(Get(D_4644, "c"), "cheek")).V, face_4662);
}, 0, "", true)));
Set(E_4661, "eyes", Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _self4633, int _argc4965, V i_4971, V _a4968, V _a4969, V _a4970, V[] _rest4966) => {
V gg_4972 = default;
V e_4973 = default;
V hg_4974 = default;
gg_4972 = Call(mk_32, V.Undef, ((V)("g")), NewObj(0).V, face_4662);
e_4973 = Call(mk_32, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)(string.Concat("url(#ey", ToStr(u_4645), ")")))).Put("stroke", ((V)("#2a1a30"))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V, gg_4972);
hg_4974 = Call(mk_32, V.Undef, ((V)("g")), NewObj(1).Put("clip-path", ((V)(string.Concat("url(#ec", ToStr(i_4971), ToStr(u_4645), ")")))).V, gg_4972);
return NewObj(6).Put("g", gg_4972).Put("e", e_4973).Put("tp", Call(mk_32, V.Undef, ((V)("path")), NewObj(2).Put("fill", ((V)("#a8dcff"))).Put("opacity", ((V)(0D))).V, hg_4974)).Put("h1", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#fff"))).V, hg_4974)).Put("h2", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#fff"))).V, hg_4974)).Put("clip", Invoke(svg_4649, "querySelector", ((V)(string.Concat("#ec", ToStr(i_4971), ToStr(u_4645), " path"))))).V;
return default;
}, 1, "", true)));
if (Truthy((Get(D_4644, "eyeDome") is var _t4975 && !Truthy(_t4975) ? _t4975 : Get(E_4661, "tuftG")))) {
Invoke(Get(E_4661, "eyes"), "forEach", Fn((V _self4633, int _argc4976, V o_4982, V i_4983, V _a4980, V _a4981, V[] _rest4977) => {
if (Truthy(GetK(Get(E_4661, "tuftG"), i_4983))) {
Invoke(GetK(Get(E_4661, "tuftG"), i_4983), "appendChild", Get(o_4982, "g"));
}
return default;
}, 2, "", true));
}
Set(E_4661, "mopen", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#7a2a40"))).V, face_4662));
Set(E_4661, "tongue", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#ff8fa3"))).V, face_4662));
Set(E_4661, "mouth", Call(mk_32, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", Get(Get(D_4644, "c"), "mouth")).Put("stroke-width", ((V)(1.2))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V, face_4662));
Set(E_4661, "tout", Call(mk_32, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("#ff7f9a"))).Put("stroke", ((V)("#e0607e"))).Put("stroke-width", ((V)(0.3))).Put("opacity", ((V)(0D))).V, face_4662));
wg_4663 = Call(mk_32, V.Undef, ((V)("g")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", Get(Get(D_4644, "c"), "whisker")).Put("stroke-width", ((V)(0.9))).Put("stroke-linecap", ((V)("round"))).V, Get(pg_4660, "head"));
Set(E_4661, "wh", Invoke(Get(D_4644, "whiskers"), "map", Fn((V _self4633, int _argc4984, V _a4986, V _a4987, V _a4988, V _a4989, V[] _rest4985) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(0).V, wg_4663);
}, 0, "", true)));
if (Truthy(Get(D_4644, "snout"))) {
if (Truthy(Get(Get(D_4644, "snout"), "jaw"))) {
Set(E_4661, "snoutJ", Call(mk_32, V.Undef, ((V)("path")), NewObj(3).Put("fill", Call(CF_4659, V.Undef, ((Get(Get(Get(D_4644, "snout"), "jaw"), "fill") is var _t4990 && Truthy(_t4990) ? _t4990 : Get(Get(D_4644, "snout"), "fill")) is var _t4991 && Truthy(_t4991) ? _t4991 : Get(Get(D_4644, "c"), "muzzle")))).Put("stroke", (Get(Get(D_4644, "snout"), "stroke") is var _t4992 && Truthy(_t4992) ? _t4992 : ((V)("none")))).Put("stroke-width", (Get(Get(D_4644, "snout"), "sw") is var _t4993 && Truthy(_t4993) ? _t4993 : ((V)(0D)))).V, Get(pg_4660, "head")));
}
Set(E_4661, "snout", Call(mk_32, V.Undef, ((V)("path")), NewObj(3).Put("fill", Call(CF_4659, V.Undef, (Get(Get(D_4644, "snout"), "fill") is var _t4994 && Truthy(_t4994) ? _t4994 : Get(Get(D_4644, "c"), "muzzle")))).Put("stroke", (Get(Get(D_4644, "snout"), "stroke") is var _t4995 && Truthy(_t4995) ? _t4995 : ((V)("none")))).Put("stroke-width", (Get(Get(D_4644, "snout"), "sw") is var _t4996 && Truthy(_t4996) ? _t4996 : ((V)(0D)))).V, Get(pg_4660, "head")));
Set(E_4661, "snoutN", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4659, V.Undef, ((Get(Get(D_4644, "snout"), "nose") is var _t4997 && !Truthy(_t4997) ? _t4997 : Get(Get(Get(D_4644, "snout"), "nose"), "fill")) is var _t4998 && Truthy(_t4998) ? _t4998 : ((V)("#3a2340"))))).V, Get(pg_4660, "head")));
Set(E_4661, "snoutH", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)("#ffffff"))).V, Get(pg_4660, "head")));
}
Set(E_4661, "armT", Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _self4633, int _argc4999, V i_5005, V _a5002, V _a5003, V _a5004, V[] _rest5000) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", Get(Get(D_4644, "c"), "arm")).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0D))).V, GetK(pg_4660, ((V)((Truthy(i_5005) ? "armR" : "armL")))));
}, 1, "", true)));
Set(E_4661, "arms", Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _self4633, int _argc5006, V i_5012, V _a5009, V _a5010, V _a5011, V[] _rest5007) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", Call(CF_4659, V.Undef, Get(Get(D_4644, "c"), "armFill"))).V, GetK(pg_4660, ((V)((Truthy(i_5012) ? "armR" : "armL")))));
}, 1, "", true)));
if (Truthy((Get(D_4644, "wing") is var _t5013 && !Truthy(_t5013) ? _t5013 : Get(Get(D_4644, "wing"), "f")))) {
Set(E_4661, "wingF", Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _self4633, int _argc5014, V i_5020, V _a5017, V _a5018, V _a5019, V[] _rest5015) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", (Get(Get(D_4644, "wing"), "fc") is var _t5021 && Truthy(_t5021) ? _t5021 : ((V)("#e8b43a")))).Put("stroke-width", (Get(Get(D_4644, "wing"), "sw") is var _t5022 && Truthy(_t5022) ? _t5022 : ((V)(0.5)))).Put("stroke-linecap", ((V)("round"))).V, GetK(pg_4660, ((V)((Truthy(i_5020) ? "armR" : "armL")))));
}, 1, "", true)));
}
Set(E_4661, "crown", Invoke((Get(D_4644, "crown") is var _t5032 && Truthy(_t5032) ? _t5032 : Arr()), "map", Fn((V _self4633, int _argc5023, V h_5029, V _a5026, V _a5027, V _a5028, V[] _rest5024) => {
return Call(mk_32, V.Undef, ((V)("path")), NewObj(3).Put("fill", Call(CF_4659, V.Undef, Get(h_5029, "fill"))).Put("stroke", (Get(h_5029, "stroke") is var _t5030 && Truthy(_t5030) ? _t5030 : ((V)("none")))).Put("stroke-width", (Get(h_5029, "sw") is var _t5031 && Truthy(_t5031) ? _t5031 : ((V)(0D)))).V, Get(pg_4660, "head"));
}, 1, "", true)));
Set(E_4661, "pup", Invoke((Get(D_4644, "pup") is var _t5043 && Truthy(_t5043) ? _t5043 : Arr()), "map", Fn((V _self4633, int _argc5033, V h_5039, V _a5036, V _a5037, V _a5038, V[] _rest5034) => {
return Call(mk_32, V.Undef, ((V)("path")), (Truthy((Get(h_5039, "stroke") is var _t5042 && !Truthy(_t5042) ? _t5042 : (!(Truthy(Get(h_5039, "fill"))) ? V.True : V.False))) ? NewObj(4).Put("fill", ((V)("none"))).Put("stroke", Get(h_5039, "stroke")).Put("stroke-width", (Get(h_5039, "sw") is var _t5040 && Truthy(_t5040) ? _t5040 : ((V)(1D)))).Put("stroke-linecap", ((V)("round"))).V : NewObj(2).Put("fill", Call(CF_4659, V.Undef, Get(h_5039, "fill"))).Put("opacity", (Get(h_5039, "op") is var _t5041 && Truthy(_t5041) ? _t5041 : ((V)(1D)))).V), Get(pg_4660, "pup"));
}, 1, "", true)));
if (!(Truthy(Get(D_4644, "tail")))) {
Set(Get(Get(pg_4660, "tail"), "style"), "display", ((V)("none")));
}
if (SEq(Get(D_4644, "muzzle"), V.Null)) {
Set(Get(Get(E_4661, "muzzle"), "style"), "display", ((V)("none")));
}
if (SEq(Get(D_4644, "nose"), V.Null)) {
Set(Get(Get(E_4661, "nose"), "style"), "display", ((V)("none")));
}
Set(E_4661, "clip", Invoke(svg_4649, "querySelector", ((V)(string.Concat("#fc", ToStr(u_4645), " path")))));
Set(I_4647, "fxG", Call(mk_32, V.Undef, ((V)("g")), NewObj(0).V, svg_4649));
{ V _t5044 = (Get(D_4644, "tail") is var _t5045 && Truthy(_t5045) ? _t5045 : Arr(Arr(((V)(50D)), ((V)(85D))), Arr(((V)(50D)), ((V)(85D))), Arr(((V)(50D)), ((V)(85D))), Arr(((V)(50D)), ((V)(85D)))));
{ V _t5046 = ListOf(_t5044);
{ V _t5047 = GetIdx(_t5046, 0D);
t0_4664 = _t5047; }
{ V _t5048 = GetIdx(_t5046, 1D);
t1_4665 = _t5048; }
{ V _t5049 = GetIdx(_t5046, 2D);
t2_4666 = _t5049; }
{ V _t5050 = GetIdx(_t5046, 3D);
t3_4667 = _t5050; }
} }
cub_4668 = Fn((V _self4633, int _argc5051, V a_5057, V b_5058, V c_5059, V d_5060, V[] _rest5052) => {
double m_5062 = 0;
V t_5061 = default;
t_5061 = (_argc5051 > 4 ? _rest5052[0] : V.Undef);
m_5062 = (1D - ToNum(t_5061));
return ((V)(((((((m_5062 * m_5062) * m_5062) * ToNum(a_5057)) + ((((3D * m_5062) * m_5062) * ToNum(t_5061)) * ToNum(b_5058))) + ((((3D * m_5062) * ToNum(t_5061)) * ToNum(t_5061)) * ToNum(c_5059))) + (((ToNum(t_5061) * ToNum(t_5061)) * ToNum(t_5061)) * ToNum(d_5060)))));
return default;
}, 5, "", true);
Set(I_4647, "furH", (Truthy(Get(D_4644, "headD")) ? Call(furRing_23, V.Undef, Get(D_4644, "headD"), Get(D_4644, "head")) : V.Null));
Set(I_4647, "furB", (Truthy((Get(D_4644, "bodyD") is var _t5063 && !Truthy(_t5063) ? _t5063 : (!(Truthy(Get(D_4644, "body3"))) ? V.True : V.False))) ? Call(furRing_23, V.Undef, Get(D_4644, "bodyD"), Get(D_4644, "body")) : V.Null));
Set(I_4647, "RG", NewObj(28).Put("body", (Truthy(Get(D_4644, "bodyD")) ? Call(parsePath_21, V.Undef, Get(D_4644, "bodyD")) : Call(ellS_22, V.Undef, GetIdx(Get(D_4644, "body"), 0D), GetIdx(Get(D_4644, "body"), 1D), GetIdx(Get(D_4644, "body"), 2D), GetIdx(Get(D_4644, "body"), 3D), ((V)(0D)), ((V)(16D))))).Put("skull", (Truthy(Get(D_4644, "headD")) ? Call(parsePath_21, V.Undef, Get(D_4644, "headD")) : Call(ellS_22, V.Undef, GetIdx(Get(D_4644, "head"), 0D), GetIdx(Get(D_4644, "head"), 1D), GetIdx(Get(D_4644, "head"), 2D), (GetIdx(Get(D_4644, "head"), 3D) is var _t5064 && Truthy(_t5064) ? _t5064 : GetIdx(Get(D_4644, "head"), 2D)), ((V)(0D)), ((V)(16D))))).Put("muzzle", (SEq(Get(D_4644, "muzzle"), V.Null) ? Arr() : CallSpread(ellS_22, V.Undef, new ArrBuilder().Spread(Invoke((Get(D_4644, "muzzle") is var _t5065 && Truthy(_t5065) ? _t5065 : Arr(((V)(50D)), ((V)(57D)), ((V)(16D)), ((V)(10D)))), "slice", ((V)(0D)), ((V)(4D)))).Add(((V)(0D))).Add(((V)(12D))).V))).Put("mane", (Truthy(Get(D_4644, "mane")) ? Call(parsePath_21, V.Undef, Get(Get(D_4644, "mane"), "d")) : V.Null)).Put("spk", (Truthy((Get(D_4644, "mane") is var _t5151 && !Truthy(_t5151) ? _t5151 : Get(Get(D_4644, "mane"), "spiky"))) ? Call(Fn((V _self4633, int _argc5066, V _a5068, V _a5069, V _a5070, V _a5071, V[] _rest5067) => {
V C_5072 = default;
V P_5073 = default;
double avg_5074 = 0;
V tips_5075 = default;
V vals_5076 = default;
double rt_5077 = 0;
double rb_5078 = 0;
V n_5079 = default;
V th_5080 = default;
V list_5081 = default;
C_5072 = (Get(Get(D_4644, "mane"), "c") is var _t5082 && Truthy(_t5082) ? _t5082 : Arr(GetIdx(Get(D_4644, "head"), 0D), GetIdx(Get(D_4644, "head"), 1D)));
P_5073 = Invoke(Call(flat_27, V.Undef, Call(parsePath_21, V.Undef, Get(Get(D_4644, "mane"), "d")), ((V)(1D))), "map", Fn((V _self4633, int _argc5083, V p_5089, V _a5086, V _a5087, V _a5088, V[] _rest5084) => {
return Arr(((V)(FdLibm.Atan2((ToNum(GetIdx(p_5089, 1D)) - ToNum(GetIdx(C_5072, 1D))), (ToNum(GetIdx(p_5089, 0D)) - ToNum(GetIdx(C_5072, 0D)))))), ((V)(Hypot((ToNum(GetIdx(p_5089, 0D)) - ToNum(GetIdx(C_5072, 0D))), (ToNum(GetIdx(p_5089, 1D)) - ToNum(GetIdx(C_5072, 1D)))))));
}, 1, "", true));
avg_5074 = (ToNum(Invoke(P_5073, "reduce", Fn((V _self4633, int _argc5090, V a_5096, V q_5097, V _a5094, V _a5095, V[] _rest5091) => {
return Add(a_5096, GetIdx(q_5097, 1D));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(P_5073, "length")));
tips_5075 = Invoke(P_5073, "filter", Fn((V _self4633, int _argc5098, V q_5104, V _a5101, V _a5102, V _a5103, V[] _rest5099) => {
return (GtN(GetIdx(q_5104, 1D), avg_5074) ? V.True : V.False);
}, 1, "", true));
vals_5076 = Invoke(P_5073, "filter", Fn((V _self4633, int _argc5105, V q_5111, V _a5108, V _a5109, V _a5110, V[] _rest5106) => {
return (LeN(GetIdx(q_5111, 1D), avg_5074) ? V.True : V.False);
}, 1, "", true));
rt_5077 = (ToNum(Invoke(tips_5075, "reduce", Fn((V _self4633, int _argc5112, V a_5118, V q_5119, V _a5116, V _a5117, V[] _rest5113) => {
return Add(a_5118, GetIdx(q_5119, 1D));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(tips_5075, "length")));
rb_5078 = (ToNum(Invoke(vals_5076, "reduce", Fn((V _self4633, int _argc5120, V a_5126, V q_5127, V _a5124, V _a5125, V[] _rest5121) => {
return Add(a_5126, GetIdx(q_5127, 1D));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(vals_5076, "length")));
n_5079 = Get(tips_5075, "length");
th_5080 = Invoke(tips_5075, "map", Fn((V _self4633, int _argc5128, V q_5134, V _a5131, V _a5132, V _a5133, V[] _rest5129) => {
return GetIdx(q_5134, 0D);
}, 1, "", true));
list_5081 = Arr();
Invoke(Arr(Arr(((V)(90D)), ((V)(1D)), ((V)(0D))), Arr(((V)(58D)), ((V)(0.8)), ((V)(0.5))), Arr(((V)(28D)), ((V)(0.45)), ((V)(0D)))), "forEach", Fn((V _self4633, int _argc5135, V _a5137, V _a5138, V _a5139, V _a5140, V[] _rest5136) => {
double m_5148 = 0;
V tq_5143 = default;
V f_5145 = default;
V off_5147 = default;
{ V _t5141 = ListOf(_a5137);
{ V _t5142 = GetIdx(_t5141, 0D);
tq_5143 = _t5142; }
{ V _t5144 = GetIdx(_t5141, 1D);
f_5145 = _t5144; }
{ V _t5146 = GetIdx(_t5141, 2D);
off_5147 = _t5146; }
}
m_5148 = Max(3D, Round((ToNum(n_5079) * ToNum(f_5145))));
{
double k_5149 = 0;
k_5149 = 0D;
while (true) {
if (!((k_5149 < m_5148))) break;
Invoke(list_5081, "push", NewObj(2).Put("th", ((V)((ToNum(tq_5143) * D2R_11)))).Put("t", Add(((V)(((ToNum(Add(((V)(k_5149)), off_5147)) / m_5148) * TAU_12))), (SEqN(f_5145, 1D) ? GetIdx(th_5080, 0D) : ((V)(0D))))).V);
k_5149++;
}
}
return default;
}, 1, "", true));
Invoke(list_5081, "push", NewObj(2).Put("th", ((V)(0D))).Put("t", ((V)(0D))).V);
return NewObj(5).Put("C", C_5072).Put("rt", ((V)(rt_5077))).Put("rb", ((V)(rb_5078))).Put("w", ((V)(((rb_5078 * FdLibm.Sin((System.Math.PI / ToNum(n_5079)))) * 1.05)))).Put("list", list_5081).V;
return default;
}, 0, "", true), V.Undef) : V.Null)).Put("hx", Invoke((Get(D_4644, "headExtra") is var _t5159 && Truthy(_t5159) ? _t5159 : Arr()), "map", Fn((V _self4633, int _argc5152, V h_5158, V _a5155, V _a5156, V _a5157, V[] _rest5153) => {
return Call(parsePath_21, V.Undef, Get(h_5158, "d"));
}, 1, "", true))).Put("crown", Invoke((Get(D_4644, "crown") is var _t5167 && Truthy(_t5167) ? _t5167 : Arr()), "map", Fn((V _self4633, int _argc5160, V h_5166, V _a5163, V _a5164, V _a5165, V[] _rest5161) => {
return Call(parsePath_21, V.Undef, Get(h_5166, "d"));
}, 1, "", true))).Put("pup", Invoke((Get(D_4644, "pup") is var _t5175 && Truthy(_t5175) ? _t5175 : Arr()), "map", Fn((V _self4633, int _argc5168, V h_5174, V _a5171, V _a5172, V _a5173, V[] _rest5169) => {
return Call(parsePath_21, V.Undef, Get(h_5174, "d"));
}, 1, "", true))).Put("nose", (SEq(Get(D_4644, "nose"), V.Null) ? Arr() : CallSpread(ellS_22, V.Undef, new ArrBuilder().Spread((Get(D_4644, "nose") is var _t5176 && Truthy(_t5176) ? _t5176 : Arr(((V)(50D)), ((V)(54D)), ((V)(2.6)), ((V)(1.8))))).Add(((V)(0D))).Add(((V)(8D))).V))).Put("noseHL", (Truthy(Get(D_4644, "noseHL")) ? CallSpread(ellS_22, V.Undef, new ArrBuilder().Spread(Get(D_4644, "noseHL")).Add(((V)(0D))).Add(((V)(6D))).V) : V.Null)).Put("belly", (Truthy(Get(D_4644, "bellyD")) ? Call(parsePath_21, V.Undef, Get(Get(D_4644, "bellyD"), "d")) : (Truthy(Get(D_4644, "belly")) ? Call(ellS_22, V.Undef, GetIdx(Get(D_4644, "belly"), 0D), GetIdx(Get(D_4644, "belly"), 1D), GetIdx(Get(D_4644, "belly"), 2D), GetIdx(Get(D_4644, "belly"), 3D), ((V)(0D)), ((V)(12D))) : V.Null))).Put("collar", (Truthy(Get(D_4644, "collar")) ? Call(parsePath_21, V.Undef, Get(Get(D_4644, "collar"), "d")) : V.Null)).Put("fx", Invoke((Get(D_4644, "faceExtra") is var _t5184 && Truthy(_t5184) ? _t5184 : Arr()), "map", Fn((V _self4633, int _argc5177, V fe_5183, V _a5180, V _a5181, V _a5182, V[] _rest5178) => {
return Call(parsePath_21, V.Undef, Get(fe_5183, "d"));
}, 1, "", true))).Put("fxBig", Invoke((Get(D_4644, "faceExtra") is var _t5213 && Truthy(_t5213) ? _t5213 : Arr()), "map", Fn((V _self4633, int _argc5185, V fe_5191, V _a5188, V _a5189, V _a5190, V[] _rest5186) => {
V P_5192 = default;
V hx_5193 = default;
V hy_5194 = default;
V rx_5195 = default;
V ry_5196 = default;
P_5192 = Invoke(Call(parsePath_21, V.Undef, Get(fe_5191, "d")), "flatMap", Fn((V _self4633, int _argc5197, V g_5203, V _a5200, V _a5201, V _a5202, V[] _rest5198) => {
return (Get(g_5203, "p") is var _t5204 && Truthy(_t5204) ? _t5204 : Arr());
}, 1, "", true));
hx_5193 = GetIdx(Get(D_4644, "head"), 0D);
hy_5194 = GetIdx(Get(D_4644, "head"), 1D);
rx_5195 = GetIdx(Get(D_4644, "head"), 2D);
ry_5196 = (GetIdx(Get(D_4644, "head"), 3D) is var _t5205 && Truthy(_t5205) ? _t5205 : GetIdx(Get(D_4644, "head"), 2D));
return Invoke(P_5192, "some", Fn((V _self4633, int _argc5206, V p_5212, V _a5209, V _a5210, V _a5211, V[] _rest5207) => {
return (((Pow(((ToNum(GetIdx(p_5212, 0D)) - ToNum(hx_5193)) / ToNum(rx_5195)), 2D) + Pow(((ToNum(GetIdx(p_5212, 1D)) - ToNum(hy_5194)) / ToNum(ry_5196)), 2D)) > 0.8) ? V.True : V.False);
}, 1, "", true));
return default;
}, 1, "", true))).Put("fxC", Invoke((Get(D_4644, "faceExtra") is var _t5246 && Truthy(_t5246) ? _t5246 : Arr()), "map", Fn((V _self4633, int _argc5214, V fe_5220, V _a5217, V _a5218, V _a5219, V[] _rest5215) => {
V P_5221 = default;
P_5221 = Invoke(Call(parsePath_21, V.Undef, Get(fe_5220, "d")), "flatMap", Fn((V _self4633, int _argc5222, V g_5228, V _a5225, V _a5226, V _a5227, V[] _rest5223) => {
return (Get(g_5228, "p") is var _t5229 && Truthy(_t5229) ? _t5229 : Arr());
}, 1, "", true));
return Arr(((V)((ToNum(Invoke(P_5221, "reduce", Fn((V _self4633, int _argc5230, V a_5236, V p_5237, V _a5234, V _a5235, V[] _rest5231) => {
return Add(a_5236, GetIdx(p_5237, 0D));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(P_5221, "length"))))), ((V)((ToNum(Invoke(P_5221, "reduce", Fn((V _self4633, int _argc5238, V a_5244, V p_5245, V _a5242, V _a5243, V[] _rest5239) => {
return Add(a_5244, GetIdx(p_5245, 1D));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(P_5221, "length"))))));
return default;
}, 1, "", true))).Put("feet", Invoke(Get(D_4644, "feet"), "map", Fn((V _self4633, int _argc5247, V _a5249, V _a5250, V _a5251, V _a5252, V[] _rest5248) => {
V x_5255 = default;
V y_5257 = default;
{ V _t5253 = ListOf(_a5249);
{ V _t5254 = GetIdx(_t5253, 0D);
x_5255 = _t5254; }
{ V _t5256 = GetIdx(_t5253, 1D);
y_5257 = _t5256; }
}
return NewObj(2).Put("x", x_5255).Put("y", y_5257).V;
}, 1, "", true))).Put("web", (Truthy(Get(D_4644, "web")) ? Call(parsePath_21, V.Undef, Get(Get(D_4644, "web"), "d")) : V.Null)).Put("wing", (Truthy(Get(D_4644, "wing")) ? Call(parsePath_21, V.Undef, Get(Get(D_4644, "wing"), "d")) : V.Null)).Put("wingF", (Truthy((Get(D_4644, "wing") is var _t5258 && !Truthy(_t5258) ? _t5258 : Get(Get(D_4644, "wing"), "f"))) ? Call(parsePath_21, V.Undef, Get(Get(D_4644, "wing"), "f")) : V.Null)).Put("webT", (Truthy((Get(D_4644, "web") is var _t5259 && !Truthy(_t5259) ? _t5259 : Get(Get(D_4644, "web"), "toes"))) ? Call(parsePath_21, V.Undef, Get(Get(D_4644, "web"), "toes")) : V.Null)).Put("ears", Invoke(Get(D_4644, "ears"), "map", Fn((V _self4633, int _argc5260, V e_5266, V _a5263, V _a5264, V _a5265, V[] _rest5261) => {
double vx_5267 = 0;
double vy_5268 = 0;
double len_5269 = 0;
V q_5270 = default;
vx_5267 = (ToNum(GetIdx(Get(e_5266, "tip"), 0D)) - ToNum(GetIdx(Get(e_5266, "pivot"), 0D)));
vy_5268 = (ToNum(GetIdx(Get(e_5266, "tip"), 1D)) - ToNum(GetIdx(Get(e_5266, "pivot"), 1D)));
len_5269 = Hypot(vx_5267, vy_5268);
q_5270 = Object_assign(NewObj(0).V, e_5266, NewObj(5).Put("o", Call(parsePath_21, V.Undef, Get(e_5266, "d"))).Put("n", (Truthy(Get(e_5266, "inner")) ? Call(parsePath_21, V.Undef, Get(e_5266, "inner")) : V.Null)).Put("ux", ((V)((vx_5267 / len_5269)))).Put("uy", ((V)((vy_5268 / len_5269)))).Put("len", ((V)(len_5269))).V);
Set(q_5270, "S", Call(earSec_31, V.Undef, q_5270, Call(flat_27, V.Undef, Get(q_5270, "o"), ((V)(14D)))));
return q_5270;
return default;
}, 1, "", true))).Put("arms", Invoke(Get(D_4644, "arms"), "map", Fn((V _self4633, int _argc5271, V a_5277, V _a5274, V _a5275, V _a5276, V[] _rest5272) => {
return Object_assign(NewObj(0).V, a_5277, NewObj(1).Put("s", Call(ellS_22, V.Undef, GetIdx(Get(a_5277, "e"), 0D), GetIdx(Get(a_5277, "e"), 1D), GetIdx(Get(a_5277, "e"), 2D), GetIdx(Get(a_5277, "e"), 3D), GetIdx(Get(a_5277, "e"), 4D), ((V)(8D)))).V);
}, 1, "", true))).Put("tail", (Truthy((Get(D_4644, "tail3") is var _t5343 && !Truthy(_t5343) ? _t5343 : (GtN(Get(Get(D_4644, "tail3"), "length"), 4D) ? V.True : V.False))) ? Call(Fn((V _self4633, int _argc5278, V _a5280, V _a5281, V _a5282, V _a5283, V[] _rest5279) => {
V Q_5284 = default;
double m_5285 = 0;
double n_5286 = 0;
V cr_5287 = default;
Q_5284 = Get(D_4644, "tail3");
m_5285 = (ToNum(Get(Q_5284, "length")) - 1D);
n_5286 = (m_5285 * 4D);
cr_5287 = Fn((V _self4633, int _argc5288, V p0_5294, V p1_5295, V p2_5296, V p3_5297, V[] _rest5289) => {
V t_5298 = default;
t_5298 = (_argc5288 > 4 ? _rest5289[0] : V.Undef);
return ((V)((0.5 * ((((2D * ToNum(p1_5295)) + ((ToNum(p2_5296) - ToNum(p0_5294)) * ToNum(t_5298))) + ((((((2D * ToNum(p0_5294)) - (5D * ToNum(p1_5295))) + (4D * ToNum(p2_5296))) - ToNum(p3_5297)) * ToNum(t_5298)) * ToNum(t_5298))) + (((ToNum(Add(((V)((((3D * ToNum(p1_5295)) - ToNum(p0_5294)) - (3D * ToNum(p2_5296))))), p3_5297)) * ToNum(t_5298)) * ToNum(t_5298)) * ToNum(t_5298))))));
}, 5, "", true);
return Array_from(NewObj(1).Put("length", ((V)((n_5286 + 1D)))).V, Fn((V _self4633, int _argc5299, V __5305, V i_5306, V _a5303, V _a5304, V[] _rest5300) => {
double u_5307 = 0;
double j_5308 = 0;
double t_5309 = 0;
V A_5310 = default;
V B_5311 = default;
V C_5312 = default;
V E2_5313 = default;
u_5307 = Min((ToNum(i_5306) / 4D), (m_5285 - 0.000001));
j_5308 = System.Math.Floor(u_5307);
t_5309 = (u_5307 - j_5308);
A_5310 = GetIdx(Q_5284, Max(0D, (j_5308 - 1D)));
B_5311 = GetIdx(Q_5284, j_5308);
C_5312 = GetIdx(Q_5284, (j_5308 + 1D));
E2_5313 = GetIdx(Q_5284, Min(m_5285, (j_5308 + 2D)));
return Arr(Call(cr_5287, V.Undef, GetIdx(A_5310, 0D), GetIdx(B_5311, 0D), GetIdx(C_5312, 0D), GetIdx(E2_5313, 0D), ((V)(t_5309))), Call(cr_5287, V.Undef, GetIdx(A_5310, 1D), GetIdx(B_5311, 1D), GetIdx(C_5312, 1D), GetIdx(E2_5313, 1D), ((V)(t_5309))), ((V)((ToNum(i_5306) / n_5286))), Call(cr_5287, V.Undef, GetIdx(A_5310, 2D), GetIdx(B_5311, 2D), GetIdx(C_5312, 2D), GetIdx(E2_5313, 2D), ((V)(t_5309))));
return default;
}, 2, "", true));
return default;
}, 0, "", true), V.Undef) : (Truthy(Get(D_4644, "tail3")) ? Array_from(NewObj(1).Put("length", ((V)(16D))).V, Fn((V _self4633, int _argc5314, V __5320, V i_5321, V _a5318, V _a5319, V[] _rest5315) => {
double s_5322 = 0;
V a_5323 = default;
V b_5324 = default;
V c_5325 = default;
V d_5326 = default;
s_5322 = (ToNum(i_5321) / 15D);
{ V _t5327 = Get(D_4644, "tail3");
{ V _t5328 = ListOf(_t5327);
{ V _t5329 = GetIdx(_t5328, 0D);
a_5323 = _t5329; }
{ V _t5330 = GetIdx(_t5328, 1D);
b_5324 = _t5330; }
{ V _t5331 = GetIdx(_t5328, 2D);
c_5325 = _t5331; }
{ V _t5332 = GetIdx(_t5328, 3D);
d_5326 = _t5332; }
} }
return Arr(Call(cub_4668, V.Undef, GetIdx(a_5323, 0D), GetIdx(b_5324, 0D), GetIdx(c_5325, 0D), GetIdx(d_5326, 0D), ((V)(s_5322))), Call(cub_4668, V.Undef, GetIdx(a_5323, 1D), GetIdx(b_5324, 1D), GetIdx(c_5325, 1D), GetIdx(d_5326, 1D), ((V)(s_5322))), ((V)(s_5322)), Call(cub_4668, V.Undef, GetIdx(a_5323, 2D), GetIdx(b_5324, 2D), GetIdx(c_5325, 2D), GetIdx(d_5326, 2D), ((V)(s_5322))));
return default;
}, 2, "", true)) : Array_from(NewObj(1).Put("length", ((V)(14D))).V, Fn((V _self4633, int _argc5333, V __5339, V i_5340, V _a5337, V _a5338, V[] _rest5334) => {
double s_5341 = 0;
double ins_5342 = 0;
s_5341 = (ToNum(i_5340) / 13D);
ins_5342 = ((1D - ToNum(Call(SM_16, V.Undef, ((V)((s_5341 / 0.18)))))) * 3.2);
return Arr(((V)((ToNum(Call(cub_4668, V.Undef, GetIdx(t0_4664, 0D), GetIdx(t1_4665, 0D), GetIdx(t2_4666, 0D), GetIdx(t3_4667, 0D), ((V)(s_5341)))) - ins_5342))), Add(Call(cub_4668, V.Undef, GetIdx(t0_4664, 1D), GetIdx(t1_4665, 1D), GetIdx(t2_4666, 1D), GetIdx(t3_4667, 1D), ((V)(s_5341))), ((V)((ins_5342 * 0.25)))), ((V)(s_5341)), ((V)(((-9D) - (9D * Pow(s_5341, 0.9))))));
return default;
}, 2, "", true))))).Put("stripes", Call(parsePath_21, V.Undef, Get(D_4644, "stripes"))).Put("back", Call(parsePath_21, V.Undef, Get(D_4644, "back"))).Put("wh", Invoke(Get(D_4644, "whiskers"), "map", parsePath_21)).Put("tufts", Invoke((Get(D_4644, "tufts") is var _t5351 && Truthy(_t5351) ? _t5351 : Arr()), "map", Fn((V _self4633, int _argc5344, V t_5350, V _a5347, V _a5348, V _a5349, V[] _rest5345) => {
return Call(parsePath_21, V.Undef, Get(t_5350, "d"));
}, 1, "", true))).Put("crest", Invoke((Get(D_4644, "crest") is var _t5359 && Truthy(_t5359) ? _t5359 : Arr()), "map", Fn((V _self4633, int _argc5352, V c_5358, V _a5355, V _a5356, V _a5357, V[] _rest5353) => {
return Call(parsePath_21, V.Undef, Get(c_5358, "d"));
}, 1, "", true))).V);
if (Truthy(((Get(D_4644, "mane") is var _t5360 && !Truthy(_t5360) ? _t5360 : Get(Get(D_4644, "mane"), "hog")) is var _t5361 && !Truthy(_t5361) ? _t5361 : Get(Get(Get(D_4644, "mane"), "hog"), "coat")))) {
V K_5362 = default;
V CT_5363 = default;
V HF_5364 = default;
V sa_5365 = default;
V pool_5366 = default;
V mB_5367 = default;
V back_5368 = default;
V mBF_5369 = default;
V bodyF_5370 = default;
V mHF_5371 = default;
V headF_5372 = default;
K_5362 = Set(Get(I_4647, "RG"), "coat", Call(coatBuild_63, V.Undef, D_4644));
CT_5363 = Get(Get(Get(D_4644, "mane"), "hog"), "coat");
HF_5364 = ((V)(string.Concat("url(#hg", ToStr(u_4645), ")")));
sa_5365 = NewObj(5).Put("fill", HF_5364).Put("stroke", ((Get(CT_5363, "stroke") is var _t5373 && Truthy(_t5373) ? _t5373 : Get(Get(D_4644, "mane"), "stroke")) is var _t5374 && Truthy(_t5374) ? _t5374 : ((V)("none")))).Put("stroke-width", (!Get(CT_5363, "sw").IsNullish ? Get(CT_5363, "sw") : (Get(Get(D_4644, "mane"), "sw") is var _t5375 && Truthy(_t5375) ? _t5375 : ((V)(0D))))).Put("stroke-linejoin", ((V)("round"))).Put("stroke-linecap", ((V)("round"))).V;
pool_5366 = Fn((V _self4633, int _argc5376, V par_5382, V n_5383, V _a5380, V _a5381, V[] _rest5377) => {
return Array_from(NewObj(1).Put("length", n_5383).V, Fn((V _self4633, int _argc5384, V _a5386, V _a5387, V _a5388, V _a5389, V[] _rest5385) => {
V g_5390 = default;
g_5390 = Call(mk_32, V.Undef, ((V)("g")), NewObj(0).V, par_5382);
Call(mk_32, V.Undef, ((V)("path")), sa_5365, g_5390);
Call(mk_32, V.Undef, ((V)("path")), NewObj(2).Put("fill", (Get(CT_5363, "tip") is var _t5391 && Truthy(_t5391) ? _t5391 : ((V)("#f3e2c4")))).Put("stroke", ((V)("none"))).V, g_5390);
return g_5390;
return default;
}, 0, "", true));
}, 2, "", true);
Set(Get(Get(E_4661, "mane"), "style"), "display", ((V)("none")));
mB_5367 = Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", HF_5364).V, Get(pg_4660, "mane"));
back_5368 = Call(pool_5366, V.Undef, Get(pg_4660, "mane"), Get(Get(K_5362, "sp"), "length"));
mBF_5369 = Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", HF_5364).V, Get(pg_4660, "coatB"));
bodyF_5370 = Call(pool_5366, V.Undef, Get(pg_4660, "coatB"), Get(K_5362, "nB"));
mHF_5371 = Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", HF_5364).V, Get(pg_4660, "maneF"));
headF_5372 = Call(pool_5366, V.Undef, Get(pg_4660, "maneF"), Get(K_5362, "nH"));
Set(E_4661, "coat", NewObj(6).Put("mB", mB_5367).Put("back", back_5368).Put("mBF", mBF_5369).Put("bodyF", bodyF_5370).Put("mHF", mHF_5371).Put("headF", headF_5372).V);
} else {
if (Truthy((Get(D_4644, "mane") is var _t5392 && !Truthy(_t5392) ? _t5392 : Get(Get(D_4644, "mane"), "hog")))) {
V n_5393 = default;
V HF_5394 = default;
V sa_5395 = default;
V pool_5396 = default;
Set(Get(I_4647, "RG"), "hog", Call(hogBuild_64, V.Undef, D_4644));
n_5393 = Get(Get(Get(Get(I_4647, "RG"), "hog"), "sp"), "length");
HF_5394 = ((V)(string.Concat("url(#hg", ToStr(u_4645), ")")));
sa_5395 = NewObj(5).Put("fill", HF_5394).Put("stroke", (Get(Get(D_4644, "mane"), "stroke") is var _t5397 && Truthy(_t5397) ? _t5397 : ((V)("none")))).Put("stroke-width", (Get(Get(D_4644, "mane"), "sw") is var _t5398 && Truthy(_t5398) ? _t5398 : ((V)(0D)))).Put("stroke-linejoin", ((V)("round"))).Put("stroke-linecap", ((V)("round"))).V;
pool_5396 = Fn((V _self4633, int _argc5399, V par_5405, V _a5402, V _a5403, V _a5404, V[] _rest5400) => {
return Array_from(NewObj(1).Put("length", n_5393).V, Fn((V _self4633, int _argc5406, V _a5408, V _a5409, V _a5410, V _a5411, V[] _rest5407) => {
return Call(mk_32, V.Undef, ((V)("path")), sa_5395, par_5405);
}, 0, "", true));
}, 1, "", true);
Set(Get(Get(E_4661, "mane"), "style"), "display", ((V)("none")));
Set(E_4661, "hog", NewObj(5).Put("pre", Call(pool_5396, V.Undef, Get(pg_4660, "mane"))).Put("domeB", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", HF_5394).V, Get(pg_4660, "mane"))).Put("post", Call(pool_5396, V.Undef, Get(pg_4660, "mane"))).Put("domeF", Call(mk_32, V.Undef, ((V)("path")), NewObj(1).Put("fill", HF_5394).V, Get(pg_4660, "maneF"))).Put("fs", Call(pool_5396, V.Undef, Get(pg_4660, "maneF"))).V);
}
}
}
loc_4650 = Fn((V _self4633, int _argc5412, V e_5418, V _a5415, V _a5416, V _a5417, V[] _rest5413) => {
V r_5419 = default;
r_5419 = Invoke(wrap_4648, "getBoundingClientRect");
return NewObj(3).Put("r", r_5419).Put("x", ((V)((((ToNum(Get(e_5418, "clientX")) - ToNum(Get(r_5419, "left"))) / ToNum(Get(r_5419, "width"))) * 100D)))).Put("y", ((V)((((ToNum(Get(e_5418, "clientY")) - ToNum(Get(r_5419, "top"))) / ToNum(Get(r_5419, "height"))) * 100D)))).V;
return default;
}, 1, "", true);
Invoke(wrap_4648, "addEventListener", ((V)("pointermove")), Fn((V _self4633, int _argc5420, V e_5426, V _a5423, V _a5424, V _a5425, V[] _rest5421) => {
V p_5427 = default;
p_5427 = Call(loc_4650, V.Undef, e_5426);
Set(I_4647, "ptr", NewObj(2).Put("x", Call(clamp_13, V.Undef, ((V)(((ToNum(Get(p_5427, "x")) - 50D) / 42D))), ((V)((-1D))), ((V)(1D)))).Put("y", Call(clamp_13, V.Undef, ((V)(((ToNum(Get(p_5427, "y")) - 46D) / 42D))), ((V)((-1D))), ((V)(1D)))).V);
if (Truthy(Get(I_4647, "down"))) {
double dx_5428 = 0;
dx_5428 = (ToNum(Get(e_5426, "clientX")) - ToNum(Get(Get(I_4647, "down"), "cx")));
if (((!(Truthy(Get(I_4647, "drag"))) && !(Truthy(Get(I_4647, "press")))) && (System.Math.Abs(dx_5428) > 10D))) {
Set(I_4647, "drag", (true ? V.True : V.False));
Call(G("clearTimeout"), V.Undef, Get(I_4647, "ht"));
Set(I_4647, "spinTw", V.Null);
Set(I_4647, "spin0", Get(I_4647, "spinOff"));
}
if (Truthy(Get(I_4647, "drag"))) {
Set(I_4647, "spinOff", Add(Get(I_4647, "spin0"), ((V)(((dx_5428 / ToNum(Get(Get(p_5427, "r"), "width"))) * 360D)))));
}
}
return default;
}, 1, "", true));
Invoke(wrap_4648, "addEventListener", ((V)("pointerleave")), Fn((V _self4633, int _argc5429, V _a5431, V _a5432, V _a5433, V _a5434, V[] _rest5430) => {
Set(I_4647, "ptr", V.Null);
return default;
}, 0, "", true));
Invoke(wrap_4648, "addEventListener", ((V)("pointerdown")), Fn((V _self4633, int _argc5435, V e_5441, V _a5438, V _a5439, V _a5440, V[] _rest5436) => {
V p_5442 = default;
V n_5443 = default;
try {
Invoke(wrap_4648, "setPointerCapture", Get(e_5441, "pointerId"));
} catch (System.Exception _ex5444) {
V x_5445 = default;
x_5445 = Caught(_ex5444);

}
p_5442 = Call(loc_4650, V.Undef, e_5441);
n_5443 = Invoke(G("performance"), "now");
if (!SEqS(Get(Get(I_4647, "cur"), "name"), "idle")) {
Call(setState_45, V.Undef, I_4647, ((V)("idle")), n_5443);
}
Set(I_4647, "down", NewObj(3).Put("cx", Get(e_5441, "clientX")).Put("x", Get(p_5442, "x")).Put("y", Get(p_5442, "y")).V);
Set(I_4647, "drag", (false ? V.True : V.False));
Call(G("clearTimeout"), V.Undef, Get(I_4647, "ht"));
Set(I_4647, "ht", Call(G("setTimeout"), V.Undef, Fn((V _self4633, int _argc5453, V _a5455, V _a5456, V _a5457, V _a5458, V[] _rest5454) => {
if (Truthy((Get(I_4647, "down") is var _t5459 && !Truthy(_t5459) ? _t5459 : (!(Truthy(Get(I_4647, "drag"))) ? V.True : V.False)))) {
Set(I_4647, "press", (true ? V.True : V.False));
Set(I_4647, "pressT", Invoke(G("performance"), "now"));
}
return default;
}, 0, "", true), ((V)(170D))));
return default;
}, 1, "", true));
up_4651 = Fn((V _self4633, int _argc5460, V _a5462, V _a5463, V _a5464, V _a5465, V[] _rest5461) => {
V n_5466 = default;
if (!(Truthy(Get(I_4647, "down")))) {
return default;
}
Call(G("clearTimeout"), V.Undef, Get(I_4647, "ht"));
n_5466 = Invoke(G("performance"), "now");
if (Truthy(Get(I_4647, "drag"))) {
Set(I_4647, "spinTw", NewObj(4).Put("from", Get(I_4647, "spinOff")).Put("to", ((V)((Round((ToNum(Get(I_4647, "spinOff")) / 360D)) * 360D)))).Put("t0", n_5466).Put("d", ((V)(650D))).V);
} else {
if (Truthy(Get(I_4647, "press"))) {
V RS_5467 = default;
Set(I_4647, "press", (false ? V.True : V.False));
RS_5467 = ((Get(I_4647, "key") is var _t5468 && !Truthy(_t5468) ? _t5468 : GetK(REL_99, Get(I_4647, "key"))) is var _t5469 && Truthy(_t5469) ? _t5469 : RELEASE_39);
Invoke(Get(I_4647, "shots"), "push", NewObj(2).Put("S", RS_5467).Put("t0", n_5466).V);
Invoke((Get(RS_5467, "em") is var _t5477 && Truthy(_t5477) ? _t5477 : Arr()), "forEach", Fn((V _self4633, int _argc5470, V m_5476, V _a5473, V _a5474, V _a5475, V[] _rest5471) => {
return Call(emit_51, V.Undef, I_4647, GetIdx(m_5476, 0D), GetIdx(m_5476, 1D), GetIdx(m_5476, 2D));
}, 1, "", true));
}
}
Set(I_4647, "down", V.Null);
Set(I_4647, "drag", (false ? V.True : V.False));
return default;
}, 0, "", true);
Invoke(wrap_4648, "addEventListener", ((V)("pointerup")), up_4651);
Invoke(wrap_4648, "addEventListener", ((V)("pointercancel")), up_4651);
Invoke(ALL_65, "add", I_4647);
Call(applyLook_86, V.Undef, I_4647);
Call(kick_70, V.Undef);
Call(tick_59, V.Undef, I_4647, now_4646, ((V)(0.016)));
return Set(Get(G("window"), "RiveRig"), "_last", NewObj(7).Put("play", Fn((V _self4633, int _argc5478, V n_5484, V _a5481, V _a5482, V _a5483, V[] _rest5479) => {
return Call(setState_45, V.Undef, I_4647, n_5484, Invoke(G("performance"), "now"));
}, 1, "play", true)).Put("ext", Fn((V _self4633, int _argc5485, V o_5491, V _a5488, V _a5489, V _a5490, V[] _rest5486) => {
Set(I_4647, "ext", o_5491);
return default;
}, 1, "ext", true)).Put("light", Fn((V _self4633, int _argc5492, V L_5498, V _a5495, V _a5496, V _a5497, V[] _rest5493) => {
Set(I_4647, "sceneL", (L_5498 is var _t5499 && Truthy(_t5499) ? _t5499 : V.Null));
Call(applyLook_86, V.Undef, I_4647);
Call(tick_59, V.Undef, I_4647, Invoke(G("performance"), "now"), ((V)(0.016)));
return default;
}, 1, "light", true)).Put("destroy", Fn((V _self4633, int _argc5500, V _a5502, V _a5503, V _a5504, V _a5505, V[] _rest5501) => {
Invoke(ALL_65, "delete", I_4647);
Call(G("clearTimeout"), V.Undef, Get(I_4647, "ht"));
Set(host_4640, "innerHTML", ((V)("")));
return default;
}, 0, "destroy", true)).Put("_pose", Fn((V _self4633, int _argc5506, V name_5512, V t_5513, V _a5510, V _a5511, V[] _rest5507) => {
V n_5514 = default;
n_5514 = Invoke(G("performance"), "now");
Set(I_4647, "cur", NewObj(2).Put("name", name_5512).Put("t0", ((V)((ToNum(n_5514) - ToNum(t_5513))))).V);
Set(I_4647, "prev", V.Null);
Set(I_4647, "shots", Arr());
Set(Get(I_4647, "flw"), "v", ((V)(0D)));
Call(tick_59, V.Undef, I_4647, n_5514, ((V)(0.016)));
return default;
}, 2, "_pose", true)).Getter("state", Fn((V _self5515, int _argc5516, V _a5518, V _a5519, V _a5520, V _a5521, V[] _rest5517) => {
if (_self5515.IsNullish) _self5515 = GlobalV;
return Get(Get(I_4647, "cur"), "name");
return default;
}, 0, "state", false)).Put("_I", I_4647).V);
return default;
}, 3, "mount", false);
if (Truthy(Get(G("window"), "RiveRig"))) {
return default;
}
FAB_8 = V.Null;
NS_10 = ((V)("http://www.w3.org/2000/svg"));
D2R_11 = (System.Math.PI / 180D);
TAU_12 = (System.Math.PI * 2D);
clamp_13 = Fn((V _self1, int _argc5522, V v_5528, V a_5529, V b_5530, V _a5527, V[] _rest5523) => {
return ((V)(Max(ToNum(a_5529), Min(ToNum(b_5530), ToNum(v_5528)))));
}, 3, "", true);
r2_14 = Fn((V _self1, int _argc5531, V n_5537, V _a5534, V _a5535, V _a5536, V[] _rest5532) => {
return ((V)((Round((ToNum(n_5537) * 100D)) / 100D)));
}, 1, "", true);
lerp_15 = Fn((V _self1, int _argc5538, V a_5544, V b_5545, V t_5546, V _a5543, V[] _rest5539) => {
return Add(a_5544, ((V)(((ToNum(b_5545) - ToNum(a_5544)) * ToNum(t_5546)))));
}, 3, "", true);
SM_16 = Fn((V _self1, int _argc5547, V x_5553, V _a5550, V _a5551, V _a5552, V[] _rest5548) => {
x_5553 = Call(clamp_13, V.Undef, x_5553, ((V)(0D)), ((V)(1D)));
return ((V)(((ToNum(x_5553) * ToNum(x_5553)) * (3D - (2D * ToNum(x_5553))))));
return default;
}, 1, "", true);
bez_17 = Fn((V _self1, int _argc5554, V x1_5560, V y1_5561, V x2_5562, V y2_5563, V[] _rest5555) => {
double cx_5564 = 0;
double bx_5565 = 0;
double ax_5566 = 0;
double cy_5567 = 0;
double by_5568 = 0;
double ay_5569 = 0;
V X_5570 = default;
V dX_5571 = default;
V Y_5572 = default;
cx_5564 = (3D * ToNum(x1_5560));
bx_5565 = ((3D * (ToNum(x2_5562) - ToNum(x1_5560))) - cx_5564);
ax_5566 = ((1D - cx_5564) - bx_5565);
cy_5567 = (3D * ToNum(y1_5561));
by_5568 = ((3D * (ToNum(y2_5563) - ToNum(y1_5561))) - cy_5567);
ay_5569 = ((1D - cy_5567) - by_5568);
X_5570 = Fn((V _self1, int _argc5573, V t_5579, V _a5576, V _a5577, V _a5578, V[] _rest5574) => {
return ((V)((((((ax_5566 * ToNum(t_5579)) + bx_5565) * ToNum(t_5579)) + cx_5564) * ToNum(t_5579))));
}, 1, "", true);
dX_5571 = Fn((V _self1, int _argc5580, V t_5586, V _a5583, V _a5584, V _a5585, V[] _rest5581) => {
return ((V)((((((3D * ax_5566) * ToNum(t_5586)) + (2D * bx_5565)) * ToNum(t_5586)) + cx_5564)));
}, 1, "", true);
Y_5572 = Fn((V _self1, int _argc5587, V t_5593, V _a5590, V _a5591, V _a5592, V[] _rest5588) => {
return ((V)((((((ay_5569 * ToNum(t_5593)) + by_5568) * ToNum(t_5593)) + cy_5567) * ToNum(t_5593))));
}, 1, "", true);
return Fn((V _self1, int _argc5594, V x_5600, V _a5597, V _a5598, V _a5599, V[] _rest5595) => {
V t_5601 = default;
if (LeN(x_5600, 0D)) {
return ((V)(0D));
}
if (GeN(x_5600, 1D)) {
return ((V)(1D));
}
t_5601 = x_5600;
{
double i_5602 = 0;
i_5602 = 0D;
while (true) {
if (!((i_5602 < 8D))) break;
V d_5604 = default;
d_5604 = Call(dX_5571, V.Undef, t_5601);
if ((System.Math.Abs(ToNum(d_5604)) < 0.00001)) {
break;
}
t_5601 = Call(clamp_13, V.Undef, ((V)((ToNum(t_5601) - ((ToNum(Call(X_5570, V.Undef, t_5601)) - ToNum(x_5600)) / ToNum(d_5604))))), ((V)(0D)), ((V)(1D)));
i_5602++;
}
}
return Call(Y_5572, V.Undef, t_5601);
return default;
}, 1, "", true);
return default;
}, 4, "", true);
EZ_18 = NewObj(6).Put("l", Fn((V _self1, int _argc5605, V x_5611, V _a5608, V _a5609, V _a5610, V[] _rest5606) => {
return x_5611;
}, 1, "l", true)).Put("io", Call(bez_17, V.Undef, ((V)(0.45)), ((V)(0D)), ((V)(0.55)), ((V)(1D)))).Put("s", Call(bez_17, V.Undef, ((V)(0.37)), ((V)(0D)), ((V)(0.63)), ((V)(1D)))).Put("o", Fn((V _self1, int _argc5612, V x_5618, V _a5615, V _a5616, V _a5617, V[] _rest5613) => {
return ((V)((1D - Pow((1D - ToNum(x_5618)), 2.4))));
}, 1, "o", true)).Put("i", Fn((V _self1, int _argc5619, V x_5625, V _a5622, V _a5623, V _a5624, V[] _rest5620) => {
return ((V)(Pow(ToNum(x_5625), 2.2)));
}, 1, "i", true)).Put("bk", Call(bez_17, V.Undef, ((V)(0.34)), ((V)(1.45)), ((V)(0.64)), ((V)(1D)))).V;
kv_19 = Fn((V _self1, int _argc5626, V K_5632, V t_5633, V _a5630, V _a5631, V[] _rest5627) => {
if (Le(t_5633, GetIdx(GetIdx(K_5632, 0D), 0D))) {
return GetIdx(GetIdx(K_5632, 0D), 1D);
}
{
double i_5634 = 0;
i_5634 = 1D;
while (true) {
if (!(Lt(((V)(i_5634)), Get(K_5632, "length")))) break;
V b_5636 = default;
b_5636 = GetIdx(K_5632, i_5634);
if (Le(t_5633, GetIdx(b_5636, 0D))) {
V a_5637 = default;
a_5637 = GetIdx(K_5632, (i_5634 - 1D));
return Add(GetIdx(a_5637, 1D), ((V)(((ToNum(GetIdx(b_5636, 1D)) - ToNum(GetIdx(a_5637, 1D))) * ToNum(InvokeK(EZ_18, (GetIdx(b_5636, 2D) is var _t5638 && Truthy(_t5638) ? _t5638 : ((V)("io"))), ((V)(((ToNum(t_5633) - ToNum(GetIdx(a_5637, 0D))) / Max(1D, (ToNum(GetIdx(b_5636, 0D)) - ToNum(GetIdx(a_5637, 0D)))))))))))));
}
i_5634++;
}
}
return GetIdx(GetIdx(K_5632, (ToNum(Get(K_5632, "length")) - 1D)), 1D);
return default;
}, 2, "", true);
Fol_20 = ClassOf(Fn((V _self5639, int _argc5640, V v_5646, V w_5647, V z_5648, V _a5645, V[] _rest5641) => {
if (_self5639.IsNullish) _self5639 = GlobalV;
Set(_self5639, "v", (v_5646 is var _t5649 && Truthy(_t5649) ? _t5649 : ((V)(0D))));
Set(_self5639, "d", ((V)(0D)));
Set(_self5639, "w", w_5647);
Set(_self5639, "z", (z_5648.IsNullish ? ((V)(1D)) : z_5648));
return default;
}, 3, "Fol", false)).Method("step", Fn((V _self5650, int _argc5651, V t_5657, V dt_5658, V _a5655, V _a5656, V[] _rest5652) => {
double n_5659 = 0;
double h_5660 = 0;
if (_self5650.IsNullish) _self5650 = GlobalV;
n_5659 = Max(1D, System.Math.Ceiling((ToNum(dt_5658) / 0.006)));
h_5660 = (ToNum(dt_5658) / n_5659);
{
double i_5661 = 0;
i_5661 = 0D;
while (true) {
if (!((i_5661 < n_5659))) break;
OpSet(_self5650, "d", 0, ((V)(((((ToNum(Get(_self5650, "w")) * ToNum(Get(_self5650, "w"))) * (ToNum(t_5657) - ToNum(Get(_self5650, "v")))) - (((2D * ToNum(Get(_self5650, "z"))) * ToNum(Get(_self5650, "w"))) * ToNum(Get(_self5650, "d")))) * h_5660))));
OpSet(_self5650, "v", 0, ((V)((ToNum(Get(_self5650, "d")) * h_5660))));
i_5661++;
}
}
return Get(_self5650, "v");
return default;
}, 2, "step", false)).V;
ellS_22 = Fn((V _self1, int _argc5663, V cx_5669, V cy_5670, V rx_5671, V ry_5672, V[] _rest5664) => {
double k_5675 = 0;
double c_5676 = 0;
double s_5677 = 0;
V P_5678 = default;
V @out_5679 = default;
V rot_5673 = default;
V n_5674 = default;
rot_5673 = (_argc5663 > 4 ? _rest5664[0] : V.Undef);
n_5674 = (_argc5663 > 5 ? _rest5664[1] : V.Undef);
n_5674 = (n_5674 is var _t5680 && Truthy(_t5680) ? _t5680 : ((V)(8D)));
k_5675 = ((4D / 3D) * FdLibm.Tan((System.Math.PI / (2D * ToNum(n_5674)))));
c_5676 = FdLibm.Cos((ToNum((rot_5673 is var _t5681 && Truthy(_t5681) ? _t5681 : ((V)(0D)))) * D2R_11));
s_5677 = FdLibm.Sin((ToNum((rot_5673 is var _t5682 && Truthy(_t5682) ? _t5682 : ((V)(0D)))) * D2R_11));
P_5678 = Fn((V _self1, int _argc5683, V x_5689, V y_5690, V _a5687, V _a5688, V[] _rest5684) => {
return Arr(((V)((ToNum(Add(cx_5669, ((V)((ToNum(x_5689) * c_5676))))) - (ToNum(y_5690) * s_5677)))), Add(Add(cy_5670, ((V)((ToNum(x_5689) * s_5677)))), ((V)((ToNum(y_5690) * c_5676)))));
}, 2, "", true);
@out_5679 = Arr(NewObj(2).Put("c", ((V)("M"))).Put("p", Arr(Call(P_5678, V.Undef, rx_5671, ((V)(0D))))).V);
{
double i_5691 = 0;
i_5691 = 0D;
while (true) {
if (!(Lt(((V)(i_5691)), n_5674))) break;
double a0_5693 = 0;
double a1_5694 = 0;
double c0_5695 = 0;
double s0_5696 = 0;
double c1_5697 = 0;
double s1_5698 = 0;
a0_5693 = ((i_5691 / ToNum(n_5674)) * TAU_12);
a1_5694 = (((i_5691 + 1D) / ToNum(n_5674)) * TAU_12);
c0_5695 = FdLibm.Cos(a0_5693);
s0_5696 = FdLibm.Sin(a0_5693);
c1_5697 = FdLibm.Cos(a1_5694);
s1_5698 = FdLibm.Sin(a1_5694);
Invoke(@out_5679, "push", NewObj(2).Put("c", ((V)("C"))).Put("p", Arr(Call(P_5678, V.Undef, ((V)((ToNum(rx_5671) * (c0_5695 - (k_5675 * s0_5696))))), ((V)((ToNum(ry_5672) * (s0_5696 + (k_5675 * c0_5695)))))), Call(P_5678, V.Undef, ((V)((ToNum(rx_5671) * (c1_5697 + (k_5675 * s1_5698))))), ((V)((ToNum(ry_5672) * (s1_5698 - (k_5675 * c1_5697)))))), Call(P_5678, V.Undef, ((V)((ToNum(rx_5671) * c1_5697))), ((V)((ToNum(ry_5672) * s1_5698)))))).V);
i_5691++;
}
}
Invoke(@out_5679, "push", NewObj(1).Put("c", ((V)("Z"))).V);
return @out_5679;
return default;
}, 6, "", true);
furRing_23 = Fn((V _self1, int _argc5699, V d_5705, V E_5706, V _a5703, V _a5704, V[] _rest5700) => {
V n_5707 = default;
V cx_5708 = default;
V cy_5709 = default;
V rx_5710 = default;
V ry0_5711 = default;
V ry_5712 = default;
V v_5713 = default;
V pol_5714 = default;
V V_5715 = default;
V Pk_5716 = default;
V p0_5717 = default;
V wrap_5718 = default;
V Vs_5719 = default;
V vfn_5720 = default;
V T_5721 = default;
V T2_5722 = default;
n_5707 = Get((Invoke(d_5705, "match", NewRegExp(RX8, "Q", "g")) is var _t5723 && Truthy(_t5723) ? _t5723 : Arr()), "length");
if (Truthy(((LtN(n_5707, 8D) ? V.True : V.False) is var _t5724 && Truthy(_t5724) ? _t5724 : Invoke(NewRegExp(RX10, "[CLAHVS]", "i"), "test", Invoke(d_5705, "replace", NewRegExp(RX9, "[MQZ]", "g"), ((V)(""))))))) {
return V.Null;
}
{ V _t5725 = E_5706;
{ V _t5726 = ListOf(_t5725);
{ V _t5727 = GetIdx(_t5726, 0D);
cx_5708 = _t5727; }
{ V _t5728 = GetIdx(_t5726, 1D);
cy_5709 = _t5728; }
{ V _t5729 = GetIdx(_t5726, 2D);
rx_5710 = _t5729; }
{ V _t5730 = GetIdx(_t5726, 3D);
ry0_5711 = _t5730; }
} }
ry_5712 = (ry0_5711 is var _t5731 && Truthy(_t5731) ? _t5731 : rx_5710);
v_5713 = Invoke((Invoke(d_5705, "match", NewRegExp(RX11, "-?\\d+\\.?\\d*", "g")) is var _t5732 && Truthy(_t5732) ? _t5732 : Arr()), "map", G("Number"));
pol_5714 = Fn((V _self1, int _argc5733, V x_5739, V y_5740, V _a5737, V _a5738, V[] _rest5734) => {
return Arr(((V)(FdLibm.Atan2(((ToNum(x_5739) - ToNum(cx_5708)) / ToNum(rx_5710)), ((-(ToNum(y_5740) - ToNum(cy_5709))) / ToNum(ry_5712))))), ((V)(Hypot(((ToNum(x_5739) - ToNum(cx_5708)) / ToNum(rx_5710)), ((ToNum(y_5740) - ToNum(cy_5709)) / ToNum(ry_5712))))));
}, 2, "", true);
V_5715 = Arr();
Pk_5716 = Arr();
p0_5717 = Arr(GetIdx(v_5713, 0D), GetIdx(v_5713, 1D));
{
double k_5741 = 0;
k_5741 = 2D;
while (true) {
if (!(Lt(((V)((k_5741 + 3D))), Get(v_5713, "length")))) break;
V c_5743 = default;
V p1_5744 = default;
V best_5745 = default;
c_5743 = Arr(GetIdx(v_5713, k_5741), GetIdx(v_5713, (k_5741 + 1D)));
p1_5744 = Arr(GetIdx(v_5713, (k_5741 + 2D)), GetIdx(v_5713, (k_5741 + 3D)));
Invoke(V_5715, "push", Call(pol_5714, V.Undef, GetIdx(p0_5717, 0D), GetIdx(p0_5717, 1D)));
best_5745 = V.Null;
{
double i_5746 = 0;
i_5746 = 1D;
while (true) {
if (!((i_5746 < 20D))) break;
double t_5748 = 0;
double u_5749 = 0;
V q_5750 = default;
t_5748 = (i_5746 / 20D);
u_5749 = (1D - t_5748);
q_5750 = Call(pol_5714, V.Undef, ((V)(((((u_5749 * u_5749) * ToNum(GetIdx(p0_5717, 0D))) + (((2D * u_5749) * t_5748) * ToNum(GetIdx(c_5743, 0D)))) + ((t_5748 * t_5748) * ToNum(GetIdx(p1_5744, 0D)))))), ((V)(((((u_5749 * u_5749) * ToNum(GetIdx(p0_5717, 1D))) + (((2D * u_5749) * t_5748) * ToNum(GetIdx(c_5743, 1D)))) + ((t_5748 * t_5748) * ToNum(GetIdx(p1_5744, 1D)))))));
if ((!(Truthy(best_5745)) || Gt(GetIdx(q_5750, 1D), GetIdx(best_5745, 1D)))) {
best_5745 = q_5750;
}
i_5746++;
}
}
Invoke(Pk_5716, "push", best_5745);
p0_5717 = p1_5744;
k_5741 = (k_5741 + 4D);
}
}
wrap_5718 = Fn((V _self1, int _argc5751, V a_5757, V _a5754, V _a5755, V _a5756, V[] _rest5752) => {
return ((V)(FdLibm.Atan2(FdLibm.Sin(ToNum(a_5757)), FdLibm.Cos(ToNum(a_5757)))));
}, 1, "", true);
Vs_5719 = Invoke(Invoke(V_5715, "slice"), "sort", Fn((V _self1, int _argc5758, V a_5764, V b_5765, V _a5762, V _a5763, V[] _rest5759) => {
return ((V)((ToNum(GetIdx(a_5764, 0D)) - ToNum(GetIdx(b_5765, 0D)))));
}, 2, "", true));
vfn_5720 = Fn((V _self1, int _argc5766, V th_5772, V _a5769, V _a5770, V _a5771, V[] _rest5767) => {
th_5772 = Call(wrap_5718, V.Undef, th_5772);
{
double i_5773 = 0;
i_5773 = 0D;
while (true) {
if (!(Lt(((V)(i_5773)), Get(Vs_5719, "length")))) break;
V a_5775 = default;
V b_5776 = default;
V span_5777 = default;
V o_5778 = default;
a_5775 = GetIdx(Vs_5719, i_5773);
b_5776 = GetIdx(Vs_5719, ((i_5773 + 1D) % ToNum(Get(Vs_5719, "length"))));
span_5777 = Call(wrap_5718, V.Undef, ((V)((ToNum(GetIdx(b_5776, 0D)) - ToNum(GetIdx(a_5775, 0D))))));
if (LeN(span_5777, 0D)) {
span_5777 = Add(span_5777, ((V)(TAU_12)));
}
o_5778 = Call(wrap_5718, V.Undef, ((V)((ToNum(th_5772) - ToNum(GetIdx(a_5775, 0D))))));
if (LtN(o_5778, 0D)) {
o_5778 = Add(o_5778, ((V)(TAU_12)));
}
if (Le(o_5778, span_5777)) {
return Add(GetIdx(a_5775, 1D), ((V)((((ToNum(GetIdx(b_5776, 1D)) - ToNum(GetIdx(a_5775, 1D))) * ToNum(o_5778)) / ToNum(span_5777)))));
}
i_5773++;
}
}
return GetIdx(GetIdx(Vs_5719, 0D), 1D);
return default;
}, 1, "", true);
T_5721 = Invoke(Pk_5716, "map", Fn((V _self1, int _argc5779, V q_5785, V i_5786, V _a5783, V _a5784, V[] _rest5780) => {
V pv_5787 = default;
V nx_5788 = default;
double dl_5789 = 0;
double vv_5790 = 0;
double lo_5791 = 0;
V hi_5792 = default;
double r_5793 = 0;
pv_5787 = GetIdx(Pk_5716, (ToNum(Add(((V)((ToNum(i_5786) - 1D))), n_5707)) % ToNum(n_5707)));
nx_5788 = GetIdx(Pk_5716, (ToNum(Add(i_5786, ((V)(1D)))) % ToNum(n_5707)));
dl_5789 = ((System.Math.Abs(ToNum(Call(wrap_5718, V.Undef, ((V)((ToNum(GetIdx(q_5785, 0D)) - ToNum(GetIdx(pv_5787, 0D)))))))) + System.Math.Abs(ToNum(Call(wrap_5718, V.Undef, ((V)((ToNum(GetIdx(nx_5788, 0D)) - ToNum(GetIdx(q_5785, 0D))))))))) / 4D);
vv_5790 = (ToNum(Add(Call(vfn_5720, V.Undef, ((V)((ToNum(GetIdx(q_5785, 0D)) - dl_5789)))), Call(vfn_5720, V.Undef, Add(GetIdx(q_5785, 0D), ((V)(dl_5789)))))) / 2D);
lo_5791 = 0.001;
hi_5792 = GetIdx(q_5785, 1D);
{
double it_5794 = 0;
it_5794 = 0D;
while (true) {
if (!((it_5794 < 40D))) break;
double r_5796 = 0;
double D0_5797 = 0;
double f_5798 = 0;
r_5796 = (ToNum(Add(((V)(lo_5791)), hi_5792)) / 2D);
D0_5797 = (ToNum(GetIdx(q_5785, 1D)) - r_5796);
f_5798 = (((D0_5797 * FdLibm.Cos(dl_5789)) + System.Math.Sqrt(Max(0D, ((r_5796 * r_5796) - (((D0_5797 * D0_5797) * FdLibm.Sin(dl_5789)) * FdLibm.Sin(dl_5789)))))) - vv_5790);
if ((f_5798 > 0D)) {
hi_5792 = ((V)(r_5796));
} else {
lo_5791 = r_5796;
}
it_5794++;
}
}
r_5793 = (ToNum(Add(((V)(lo_5791)), hi_5792)) / 2D);
return NewObj(3).Put("th", GetIdx(q_5785, 0D)).Put("D", ((V)((ToNum(GetIdx(q_5785, 1D)) - r_5793)))).Put("r", ((V)(r_5793))).V;
return default;
}, 2, "", true));
T2_5722 = Invoke(T_5721, "map", Fn((V _self1, int _argc5799, V t_5805, V i_5806, V _a5803, V _a5804, V[] _rest5800) => {
V u_5807 = default;
u_5807 = GetIdx(T_5721, (ToNum(Add(i_5806, ((V)(1D)))) % ToNum(n_5707)));
return NewObj(3).Put("th", Add(Get(t_5805, "th"), ((V)((ToNum(Call(wrap_5718, V.Undef, ((V)((ToNum(Get(u_5807, "th")) - ToNum(Get(t_5805, "th"))))))) / 2D))))).Put("D", ((V)((ToNum(Add(Get(t_5805, "D"), Get(u_5807, "D"))) / 2D)))).Put("r", ((V)((ToNum(Add(Get(t_5805, "r"), Get(u_5807, "r"))) / 2D)))).V;
return default;
}, 2, "", true));
return NewObj(7).Put("R", Arr(Arr(((V)((System.Math.PI / 2D))), T_5721), Arr(((V)(0D)), T_5721), Arr(((V)((System.Math.PI / 4D))), T2_5722), Arr(((V)(((3D * System.Math.PI) / 4D))), T2_5722))).Put("cx", cx_5708).Put("cy", cy_5709).Put("rx", rx_5710).Put("ry", ry_5712).Put("vfn", vfn_5720).Put("n", n_5707).V;
return default;
}, 2, "", true);
furPts_24 = Fn((V _self1, int _argc5808, V F_5814, V yaw_5815, V _a5812, V _a5813, V[] _rest5809) => {
double M_5816 = 0;
V @out_5817 = default;
V C_5818 = default;
M_5816 = 168D;
@out_5817 = Arr();
C_5818 = Arr();
Invoke(Get(F_5814, "R"), "forEach", Fn((V _self1, int _argc5819, V _a5821, V _a5822, V _a5823, V _a5824, V[] _rest5820) => {
double xs_5830 = 0;
V l0_5827 = default;
V T_5829 = default;
{ V _t5825 = ListOf(_a5821);
{ V _t5826 = GetIdx(_t5825, 0D);
l0_5827 = _t5826; }
{ V _t5828 = GetIdx(_t5825, 1D);
T_5829 = _t5828; }
}
xs_5830 = FdLibm.Sin(ToNum(Add(l0_5827, yaw_5815)));
Invoke(T_5829, "forEach", Fn((V _self1, int _argc5831, V t_5837, V _a5834, V _a5835, V _a5836, V[] _rest5832) => {
double x_5838 = 0;
double y_5839 = 0;
x_5838 = ((FdLibm.Sin(ToNum(Get(t_5837, "th"))) * ToNum(Get(t_5837, "D"))) * xs_5830);
y_5839 = (FdLibm.Cos(ToNum(Get(t_5837, "th"))) * ToNum(Get(t_5837, "D")));
Invoke(C_5818, "push", NewObj(3).Put("s", ((V)(Hypot(x_5838, y_5839)))).Put("ph", ((V)(FdLibm.Atan2(x_5838, y_5839)))).Put("r", Get(t_5837, "r")).V);
return default;
}, 1, "", true));
return default;
}, 1, "", true));
{
double i_5840 = 0;
i_5840 = 0D;
while (true) {
if (!((i_5840 < M_5816))) break;
double th_5842 = 0;
double rho_5843 = 0;
th_5842 = ((i_5840 / M_5816) * TAU_12);
rho_5843 = (ToNum(Invoke(F_5814, "vfn", ((V)(th_5842)))) * 0.995);
{
foreach (V _k5844 in Iterate(C_5818)) {
V q_5845 = default;
q_5845 = _k5844;
double dl_5846 = 0;
double sn_5847 = 0;
dl_5846 = (th_5842 - ToNum(Get(q_5845, "ph")));
sn_5847 = (ToNum(Get(q_5845, "s")) * FdLibm.Sin(dl_5846));
if ((Lt(((V)(System.Math.Abs(sn_5847))), Get(q_5845, "r")) && (FdLibm.Cos(dl_5846) > 0D))) {
double e_5848 = 0;
e_5848 = ((ToNum(Get(q_5845, "s")) * FdLibm.Cos(dl_5846)) + System.Math.Sqrt(((ToNum(Get(q_5845, "r")) * ToNum(Get(q_5845, "r"))) - (sn_5847 * sn_5847))));
if ((e_5848 > rho_5843)) {
rho_5843 = e_5848;
}
}
}
}
Invoke(@out_5817, "push", Arr(Add(Get(F_5814, "cx"), ((V)(((ToNum(Get(F_5814, "rx")) * rho_5843) * FdLibm.Sin(th_5842))))), ((V)((ToNum(Get(F_5814, "cy")) - ((ToNum(Get(F_5814, "ry")) * rho_5843) * FdLibm.Cos(th_5842)))))));
i_5840++;
}
}
return @out_5817;
return default;
}, 2, "", true);
toD_25 = Fn((V _self1, int _argc5849, V segs_5855, V F_5856, V _a5853, V _a5854, V[] _rest5850) => {
V s_5857 = default;
s_5857 = ((V)(""));
{
foreach (V _k5858 in Iterate(segs_5855)) {
V g_5859 = default;
g_5859 = _k5858;
if (SEqS(Get(g_5859, "c"), "Z")) {
s_5857 = ((V)(string.Concat(ToStr(s_5857), "Z")));
continue;
}
s_5857 = Add(s_5857, Get(g_5859, "c"));
{
foreach (V _k5860 in Iterate(Get(g_5859, "p"))) {
V p_5861 = default;
p_5861 = _k5860;
V q_5862 = default;
q_5862 = Call(F_5856, V.Undef, GetIdx(p_5861, 0D), GetIdx(p_5861, 1D));
s_5857 = ((V)(string.Concat(new string[] { ToStr(s_5857), ToStr(Call(r2_14, V.Undef, GetIdx(q_5862, 0D))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(q_5862, 1D))), " " })));
}
}
}
}
return s_5857;
return default;
}, 2, "", true);
smoothD_26 = Fn((V _self1, int _argc5863, V P_5869, V _a5866, V _a5867, V _a5868, V[] _rest5864) => {
V s_5870 = default;
s_5870 = ((V)(string.Concat("M", ToStr(Call(r2_14, V.Undef, GetIdx(GetIdx(P_5869, 0D), 0D))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(GetIdx(P_5869, 0D), 1D))))));
{
double i_5871 = 0;
i_5871 = 0D;
while (true) {
if (!((i_5871 < (ToNum(Get(P_5869, "length")) - 1D)))) break;
V p0_5873 = default;
V p1_5874 = default;
V p2_5875 = default;
V p3_5876 = default;
p0_5873 = (GetIdx(P_5869, (i_5871 - 1D)) is var _t5877 && Truthy(_t5877) ? _t5877 : GetIdx(P_5869, i_5871));
p1_5874 = GetIdx(P_5869, i_5871);
p2_5875 = GetIdx(P_5869, (i_5871 + 1D));
p3_5876 = (GetIdx(P_5869, (i_5871 + 2D)) is var _t5878 && Truthy(_t5878) ? _t5878 : p2_5875);
s_5870 = ((V)(string.Concat(new string[] { ToStr(s_5870), " C", ToStr(Call(r2_14, V.Undef, Add(GetIdx(p1_5874, 0D), ((V)(((ToNum(GetIdx(p2_5875, 0D)) - ToNum(GetIdx(p0_5873, 0D))) / 6D)))))), " ", ToStr(Call(r2_14, V.Undef, Add(GetIdx(p1_5874, 1D), ((V)(((ToNum(GetIdx(p2_5875, 1D)) - ToNum(GetIdx(p0_5873, 1D))) / 6D)))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(GetIdx(p2_5875, 0D)) - ((ToNum(GetIdx(p3_5876, 0D)) - ToNum(GetIdx(p1_5874, 0D))) / 6D)))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(GetIdx(p2_5875, 1D)) - ((ToNum(GetIdx(p3_5876, 1D)) - ToNum(GetIdx(p1_5874, 1D))) / 6D)))))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(p2_5875, 0D))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(p2_5875, 1D))) })));
i_5871++;
}
}
return s_5870;
return default;
}, 1, "", true);
flat_27 = Fn((V _self1, int _argc5879, V segs_5885, V n_5886, V _a5883, V _a5884, V[] _rest5880) => {
V @out_5887 = default;
V p_5888 = default;
@out_5887 = Arr();
p_5888 = V.Null;
{
foreach (V _k5889 in Iterate(segs_5885)) {
V g_5890 = default;
g_5890 = _k5889;
if ((SEqS(Get(g_5890, "c"), "M") || SEqS(Get(g_5890, "c"), "L"))) {
p_5888 = GetIdx(Get(g_5890, "p"), 0D);
Invoke(@out_5887, "push", p_5888);
} else {
if (SEqS(Get(g_5890, "c"), "Q")) {
V a_5891 = default;
V b_5892 = default;
{ V _t5893 = Get(g_5890, "p");
{ V _t5894 = ListOf(_t5893);
{ V _t5895 = GetIdx(_t5894, 0D);
a_5891 = _t5895; }
{ V _t5896 = GetIdx(_t5894, 1D);
b_5892 = _t5896; }
} }
{
double i_5897 = 0;
i_5897 = 1D;
while (true) {
if (!(Le(((V)(i_5897)), n_5886))) break;
double t_5899 = 0;
double m_5900 = 0;
t_5899 = (i_5897 / ToNum(n_5886));
m_5900 = (1D - t_5899);
Invoke(@out_5887, "push", Arr(((V)(((((m_5900 * m_5900) * ToNum(GetIdx(p_5888, 0D))) + (((2D * m_5900) * t_5899) * ToNum(GetIdx(a_5891, 0D)))) + ((t_5899 * t_5899) * ToNum(GetIdx(b_5892, 0D)))))), ((V)(((((m_5900 * m_5900) * ToNum(GetIdx(p_5888, 1D))) + (((2D * m_5900) * t_5899) * ToNum(GetIdx(a_5891, 1D)))) + ((t_5899 * t_5899) * ToNum(GetIdx(b_5892, 1D))))))));
i_5897++;
}
}
p_5888 = b_5892;
} else {
if (SEqS(Get(g_5890, "c"), "C")) {
V a_5901 = default;
V b_5902 = default;
V c_5903 = default;
{ V _t5904 = Get(g_5890, "p");
{ V _t5905 = ListOf(_t5904);
{ V _t5906 = GetIdx(_t5905, 0D);
a_5901 = _t5906; }
{ V _t5907 = GetIdx(_t5905, 1D);
b_5902 = _t5907; }
{ V _t5908 = GetIdx(_t5905, 2D);
c_5903 = _t5908; }
} }
{
double i_5909 = 0;
i_5909 = 1D;
while (true) {
if (!(Le(((V)(i_5909)), n_5886))) break;
double t_5911 = 0;
double m_5912 = 0;
t_5911 = (i_5909 / ToNum(n_5886));
m_5912 = (1D - t_5911);
Invoke(@out_5887, "push", Arr(((V)(((((((m_5912 * m_5912) * m_5912) * ToNum(GetIdx(p_5888, 0D))) + ((((3D * m_5912) * m_5912) * t_5911) * ToNum(GetIdx(a_5901, 0D)))) + ((((3D * m_5912) * t_5911) * t_5911) * ToNum(GetIdx(b_5902, 0D)))) + (((t_5911 * t_5911) * t_5911) * ToNum(GetIdx(c_5903, 0D)))))), ((V)(((((((m_5912 * m_5912) * m_5912) * ToNum(GetIdx(p_5888, 1D))) + ((((3D * m_5912) * m_5912) * t_5911) * ToNum(GetIdx(a_5901, 1D)))) + ((((3D * m_5912) * t_5911) * t_5911) * ToNum(GetIdx(b_5902, 1D)))) + (((t_5911 * t_5911) * t_5911) * ToNum(GetIdx(c_5903, 1D))))))));
i_5909++;
}
}
p_5888 = c_5903;
}
}
}
}
}
return @out_5887;
return default;
}, 2, "", true);
hull_28 = Fn((V _self1, int _argc5913, V P_5919, V _a5916, V _a5917, V _a5918, V[] _rest5914) => {
V cr_5920 = default;
V lo_5921 = default;
V up_5922 = default;
P_5919 = Invoke(Invoke(P_5919, "slice"), "sort", Fn((V _self1, int _argc5923, V a_5929, V b_5930, V _a5927, V _a5928, V[] _rest5924) => {
return (((V)((ToNum(GetIdx(a_5929, 0D)) - ToNum(GetIdx(b_5930, 0D))))) is var _t5931 && Truthy(_t5931) ? _t5931 : ((V)((ToNum(GetIdx(a_5929, 1D)) - ToNum(GetIdx(b_5930, 1D))))));
}, 2, "", true));
cr_5920 = Fn((V _self1, int _argc5932, V o_5938, V a_5939, V b_5940, V _a5937, V[] _rest5933) => {
return ((V)((((ToNum(GetIdx(a_5939, 0D)) - ToNum(GetIdx(o_5938, 0D))) * (ToNum(GetIdx(b_5940, 1D)) - ToNum(GetIdx(o_5938, 1D)))) - ((ToNum(GetIdx(a_5939, 1D)) - ToNum(GetIdx(o_5938, 1D))) * (ToNum(GetIdx(b_5940, 0D)) - ToNum(GetIdx(o_5938, 0D)))))));
}, 3, "", true);
lo_5921 = Arr();
up_5922 = Arr();
{
foreach (V _k5941 in Iterate(P_5919)) {
V p_5942 = default;
p_5942 = _k5941;
while ((GeN(Get(lo_5921, "length"), 2D) && LeN(Call(cr_5920, V.Undef, GetIdx(lo_5921, (ToNum(Get(lo_5921, "length")) - 2D)), GetIdx(lo_5921, (ToNum(Get(lo_5921, "length")) - 1D)), p_5942), 0D))) {
Invoke(lo_5921, "pop");
}
Invoke(lo_5921, "push", p_5942);
}
}
{
double i_5943 = 0;
i_5943 = (ToNum(Get(P_5919, "length")) - 1D);
while (true) {
if (!((i_5943 >= 0D))) break;
V p_5945 = default;
p_5945 = GetIdx(P_5919, i_5943);
while ((GeN(Get(up_5922, "length"), 2D) && LeN(Call(cr_5920, V.Undef, GetIdx(up_5922, (ToNum(Get(up_5922, "length")) - 2D)), GetIdx(up_5922, (ToNum(Get(up_5922, "length")) - 1D)), p_5945), 0D))) {
Invoke(up_5922, "pop");
}
Invoke(up_5922, "push", p_5945);
i_5943--;
}
}
Invoke(up_5922, "pop");
Invoke(lo_5921, "pop");
return Invoke(lo_5921, "concat", up_5922);
return default;
}, 1, "", true);
closedD_29 = Fn((V _self1, int _argc5946, V P_5952, V _a5949, V _a5950, V _a5951, V[] _rest5947) => {
V n_5953 = default;
V s_5954 = default;
n_5953 = Get(P_5952, "length");
if (LtN(n_5953, 3D)) {
return ((V)(""));
}
s_5954 = ((V)(string.Concat("M", ToStr(Call(r2_14, V.Undef, GetIdx(GetIdx(P_5952, 0D), 0D))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(GetIdx(P_5952, 0D), 1D))))));
{
double i_5955 = 0;
i_5955 = 0D;
while (true) {
if (!(Lt(((V)(i_5955)), n_5953))) break;
V p0_5957 = default;
V p1_5958 = default;
V p2_5959 = default;
V p3_5960 = default;
p0_5957 = GetIdx(P_5952, (ToNum(Add(((V)((i_5955 - 1D))), n_5953)) % ToNum(n_5953)));
p1_5958 = GetIdx(P_5952, i_5955);
p2_5959 = GetIdx(P_5952, ((i_5955 + 1D) % ToNum(n_5953)));
p3_5960 = GetIdx(P_5952, ((i_5955 + 2D) % ToNum(n_5953)));
s_5954 = ((V)(string.Concat(new string[] { ToStr(s_5954), " C", ToStr(Call(r2_14, V.Undef, Add(GetIdx(p1_5958, 0D), ((V)(((ToNum(GetIdx(p2_5959, 0D)) - ToNum(GetIdx(p0_5957, 0D))) / 6D)))))), " ", ToStr(Call(r2_14, V.Undef, Add(GetIdx(p1_5958, 1D), ((V)(((ToNum(GetIdx(p2_5959, 1D)) - ToNum(GetIdx(p0_5957, 1D))) / 6D)))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(GetIdx(p2_5959, 0D)) - ((ToNum(GetIdx(p3_5960, 0D)) - ToNum(GetIdx(p1_5958, 0D))) / 6D)))))), " ", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(GetIdx(p2_5959, 1D)) - ((ToNum(GetIdx(p3_5960, 1D)) - ToNum(GetIdx(p1_5958, 1D))) / 6D)))))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(p2_5959, 0D))), " ", ToStr(Call(r2_14, V.Undef, GetIdx(p2_5959, 1D))) })));
i_5955++;
}
}
return ((V)(string.Concat(ToStr(s_5954), "Z")));
return default;
}, 1, "", true);
ellAx_30 = Fn((V _self1, int _argc5961, V cx_5967, V cy_5968, V A_5969, V _a5966, V[] _rest5962) => {
double a_5970 = 0;
double b_5971 = 0;
double c_5972 = 0;
double tr_5973 = 0;
double df_5974 = 0;
a_5970 = 0D;
b_5971 = 0D;
c_5972 = 0D;
{
foreach (V _k5975 in Iterate(A_5969)) {
V v_5976 = default;
v_5976 = _k5975;
a_5970 = (a_5970 + (ToNum(GetIdx(v_5976, 0D)) * ToNum(GetIdx(v_5976, 0D))));
b_5971 = (b_5971 + (ToNum(GetIdx(v_5976, 0D)) * ToNum(GetIdx(v_5976, 1D))));
c_5972 = (c_5972 + (ToNum(GetIdx(v_5976, 1D)) * ToNum(GetIdx(v_5976, 1D))));
}
}
tr_5973 = ((a_5970 + c_5972) / 2D);
df_5974 = System.Math.Sqrt(Max(0D, ((((a_5970 - c_5972) * (a_5970 - c_5972)) / 4D) + (b_5971 * b_5971))));
return Call(ellS_22, V.Undef, cx_5967, cy_5968, ((V)(System.Math.Sqrt((tr_5973 + df_5974)))), ((V)(System.Math.Sqrt(Max(0.01, (tr_5973 - df_5974))))), ((V)(((0.5 * FdLibm.Atan2((2D * b_5971), (a_5970 - c_5972))) / D2R_11))), ((V)(8D)));
return default;
}, 3, "", true);
earSec_31 = Fn((V _self1, int _argc5977, V e_5983, V poly_5984, V _a5981, V _a5982, V[] _rest5978) => {
V px_5985 = default;
V py_5986 = default;
V ux_5987 = default;
V uy_5988 = default;
double nx_5989 = 0;
V ny_5990 = default;
V A_5991 = default;
V amax_5992 = default;
double amin_5993 = 0;
V secs_5994 = default;
{ V _t5995 = Get(e_5983, "pivot");
{ V _t5996 = ListOf(_t5995);
{ V _t5997 = GetIdx(_t5996, 0D);
px_5985 = _t5997; }
{ V _t5998 = GetIdx(_t5996, 1D);
py_5986 = _t5998; }
} }
ux_5987 = Get(e_5983, "ux");
uy_5988 = Get(e_5983, "uy");
nx_5989 = (-ToNum(uy_5988));
ny_5990 = ux_5987;
A_5991 = Invoke(poly_5984, "map", Fn((V _self1, int _argc5999, V _a6001, V _a6002, V _a6003, V _a6004, V[] _rest6000) => {
V x_6007 = default;
V y_6009 = default;
{ V _t6005 = ListOf(_a6001);
{ V _t6006 = GetIdx(_t6005, 0D);
x_6007 = _t6006; }
{ V _t6008 = GetIdx(_t6005, 1D);
y_6009 = _t6008; }
}
return Arr(((V)((((ToNum(x_6007) - ToNum(px_5985)) * ToNum(ux_5987)) + ((ToNum(y_6009) - ToNum(py_5986)) * ToNum(uy_5988))))), ((V)((((ToNum(x_6007) - ToNum(px_5985)) * nx_5989) + ((ToNum(y_6009) - ToNum(py_5986)) * ToNum(ny_5990))))));
}, 1, "", true));
amax_5992 = InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(Invoke(A_5991, "map", Fn((V _self1, int _argc6010, V a_6016, V _a6013, V _a6014, V _a6015, V[] _rest6011) => {
return GetIdx(a_6016, 0D);
}, 1, "", true))).V);
amin_5993 = Max(ToNum(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(Invoke(A_5991, "map", Fn((V _self1, int _argc6017, V a_6023, V _a6020, V _a6021, V _a6022, V[] _rest6018) => {
return GetIdx(a_6023, 0D);
}, 1, "", true))).V)), (-4D));
secs_5994 = Arr();
{
double i_6024 = 0;
i_6024 = 0D;
while (true) {
if (!((i_6024 <= 13D))) break;
double a_6026 = 0;
double lo_6027 = 0;
double hi_6028 = 0;
double hw_6029 = 0;
double tc_6030 = 0;
V s_6031 = default;
a_6026 = (amin_5993 + ((((ToNum(amax_5992) - amin_5993) - 0.5) * i_6024) / 13D));
lo_6027 = 1000000000D;
hi_6028 = (-1000000000D);
{
double j_6032 = 0;
j_6032 = 0D;
while (true) {
if (!(Lt(((V)(j_6032)), Get(A_5991, "length")))) break;
V p_6034 = default;
V q_6035 = default;
p_6034 = GetIdx(A_5991, j_6032);
q_6035 = GetIdx(A_5991, ((j_6032 + 1D) % ToNum(Get(A_5991, "length"))));
if (((((ToNum(GetIdx(p_6034, 0D)) - a_6026) * (ToNum(GetIdx(q_6035, 0D)) - a_6026)) <= 0D) && !SEq(GetIdx(p_6034, 0D), GetIdx(q_6035, 0D)))) {
V t_6036 = default;
t_6036 = Add(GetIdx(p_6034, 1D), ((V)((((ToNum(GetIdx(q_6035, 1D)) - ToNum(GetIdx(p_6034, 1D))) * (a_6026 - ToNum(GetIdx(p_6034, 0D)))) / (ToNum(GetIdx(q_6035, 0D)) - ToNum(GetIdx(p_6034, 0D)))))));
lo_6027 = Min(lo_6027, ToNum(t_6036));
hi_6028 = Max(hi_6028, ToNum(t_6036));
}
j_6032++;
}
}
if ((lo_6027 > hi_6028)) {
goto _cont6025;
}
hw_6029 = Max(0.8, ((hi_6028 - lo_6027) / 2D));
tc_6030 = ((hi_6028 + lo_6027) / 2D);
s_6031 = Call(clamp_13, V.Undef, ((V)((a_6026 / ToNum(amax_5992)))), ((V)(0D)), ((V)(1D)));
Invoke(secs_5994, "push", NewObj(5).Put("s", s_6031).Put("cx", Add(Add(px_5985, ((V)((a_6026 * ToNum(ux_5987))))), ((V)((tc_6030 * nx_5989))))).Put("cy", Add(Add(py_5986, ((V)((a_6026 * ToNum(uy_5988))))), ((V)((tc_6030 * ToNum(ny_5990)))))).Put("hw", ((V)(hw_6029))).Put("hd", ((V)(Max(0.8, ((hw_6029 * 0.55) * (0.3 + (0.7 * ToNum(Call(SM_16, V.Undef, ((V)(((ToNum(s_6031) - 0.1) / 0.4)))))))))))).V);
_cont6025: ;
i_6024++;
}
}
return NewObj(4).Put("secs", secs_5994).Put("amax", amax_5992).Put("nx", ((V)(nx_5989))).Put("ny", ny_5990).V;
return default;
}, 2, "", true);
mk_32 = Fn((V _self1, int _argc6037, V tag_6043, V at_6044, V par_6045, V _a6042, V[] _rest6038) => {
V e_6046 = default;
e_6046 = Invoke(G("document"), "createElementNS", NS_10, tag_6043);
{
foreach (V _k6047 in ForInKeys(at_6044)) {
V k_6048 = default;
k_6048 = _k6047;
Invoke(e_6046, "setAttribute", k_6048, GetK(at_6044, k_6048));
}
}
if (Truthy(par_6045)) {
Invoke(par_6045, "appendChild", e_6046);
}
return e_6046;
return default;
}, 3, "", true);
star4_33 = Fn((V _self1, int _argc6049, V x_6055, V y_6056, V r_6057, V _a6054, V[] _rest6050) => {
return ((V)(string.Concat(new string[] { "M", ToStr(Call(r2_14, V.Undef, x_6055)), " ", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(y_6056) - ToNum(r_6057)))))), " Q", ToStr(Call(r2_14, V.Undef, x_6055)), " ", ToStr(Call(r2_14, V.Undef, y_6056)), " ", ToStr(Call(r2_14, V.Undef, Add(x_6055, r_6057))), " ", ToStr(Call(r2_14, V.Undef, y_6056)), " Q", ToStr(Call(r2_14, V.Undef, x_6055)), " ", ToStr(Call(r2_14, V.Undef, y_6056)), " ", ToStr(Call(r2_14, V.Undef, x_6055)), " ", ToStr(Call(r2_14, V.Undef, Add(y_6056, r_6057))), " Q", ToStr(Call(r2_14, V.Undef, x_6055)), " ", ToStr(Call(r2_14, V.Undef, y_6056)), " ", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(x_6055) - ToNum(r_6057)))))), " ", ToStr(Call(r2_14, V.Undef, y_6056)), " Q", ToStr(Call(r2_14, V.Undef, x_6055)), " ", ToStr(Call(r2_14, V.Undef, y_6056)), " ", ToStr(Call(r2_14, V.Undef, x_6055)), " ", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(y_6056) - ToNum(r_6057)))))), "Z" })));
}, 3, "", true);
DEFS_34 = NewObj(1).Put("mittens", NewObj(16).Put("G", ((V)(95.5))).Put("top", ((V)(17D))).Put("head", Arr(((V)(50D)), ((V)(46D)), ((V)(29D)))).Put("neck", Arr(((V)(50D)), ((V)(73D)))).Put("c", NewObj(11).Put("tail", ((V)("#e59a58"))).Put("pad", ((V)("#ffb8c6"))).Put("inner", ((V)("#ffb3c1"))).Put("muzzle", ((V)("#fff1e2"))).Put("nose", ((V)("#e8798f"))).Put("cheek", ((V)("#ff8fa3"))).Put("mouth", ((V)("#6a3a3a"))).Put("whisker", ((V)("#a86a3a"))).Put("stripe", ((V)("#e08e48"))).Put("arm", ((V)("#f0aa6a"))).Put("g", Arr(((V)("#ffe4c0")), ((V)("#f8b77a")), ((V)("#d98a4a")))).V).Put("body", Arr(((V)(50D)), ((V)(78D)), ((V)(22D)), ((V)(13D)))).Put("feet", Arr(Arr(((V)(38D)), ((V)(90D))), Arr(((V)(62D)), ((V)(90D))))).Put("ears", Arr(NewObj(5).Put("side", ((V)((-1D)))).Put("pivot", Arr(((V)(34D)), ((V)(30D)))).Put("tip", Arr(((V)(26D)), ((V)(9D)))).Put("d", ((V)("M22 36 Q20 8 30 10 Q38 14 46 24 Z"))).Put("inner", ((V)("M28 28 Q28 16 32 16 Q36 18 40 24 Z"))).V, NewObj(5).Put("side", ((V)(1D))).Put("pivot", Arr(((V)(66D)), ((V)(30D)))).Put("tip", Arr(((V)(74D)), ((V)(9D)))).Put("d", ((V)("M78 36 Q80 8 70 10 Q62 14 54 24 Z"))).Put("inner", ((V)("M72 28 Q72 16 68 16 Q64 18 60 24 Z"))).V)).Put("arms", Arr(NewObj(3).Put("side", ((V)((-1D)))).Put("e", Arr(((V)(30.6)), ((V)(76D)), ((V)(6D)), ((V)(8D)), ((V)(20D)))).Put("pivot", Arr(((V)(33.2)), ((V)(68.6)))).V, NewObj(3).Put("side", ((V)(1D))).Put("e", Arr(((V)(69.4)), ((V)(76D)), ((V)(6D)), ((V)(8D)), ((V)((-20D))))).Put("pivot", Arr(((V)(66.8)), ((V)(68.6)))).V)).Put("tail", Arr(Arr(((V)(52D)), ((V)(86D))), Arr(((V)(74D)), ((V)(92D))), Arr(((V)(92D)), ((V)(82D))), Arr(((V)(88D)), ((V)(66D))))).Put("eyes", Arr(Arr(((V)(38D)), ((V)(47D))), Arr(((V)(62D)), ((V)(47D))))).Put("eyeR", ((V)(5.2))).Put("tail3", Arr(Arr(((V)(50D)), ((V)(81D)), ((V)((-18D)))), Arr(((V)(51D)), ((V)(90D)), ((V)((-35D)))), Arr(((V)(80D)), ((V)(94D)), ((V)((-36D)))), Arr(((V)(90D)), ((V)(71D)), ((V)((-26D)))))).Put("whiskers", Arr(((V)("M36 55 Q27 52.5 18 52")), ((V)("M36 58 Q27 58.5 18 60")), ((V)("M64 55 Q73 52.5 82 52")), ((V)("M64 58 Q73 58.5 82 60")))).Put("stripes", ((V)("M44 18 L45 24 M56 18 L55 24"))).Put("back", ((V)("M43 21 L44 28 M50 19 L50 27 M57 21 L56 28"))).V).V;
Set(DEFS_34, "biscuit", NewObj(33).Put("G", ((V)(95.5))).Put("top", ((V)(16D))).Put("head", Arr(((V)(50D)), ((V)(44D)), ((V)(28D)))).Put("neck", Arr(((V)(50D)), ((V)(71D)))).Put("c", NewObj(14).Put("tail", ((V)("#e8a45a"))).Put("tailB", ((V)("#e2a056"))).Put("pad", ((V)("#7a4a2a"))).Put("inner", ((V)("#c98a50"))).Put("muzzle", ((V)("#fff1de"))).Put("nose", ((V)("#2a1a30"))).Put("cheek", ((V)("#ff8fa3"))).Put("mouth", ((V)("#6a3a3a"))).Put("whisker", ((V)("none"))).Put("stripe", ((V)("#fff1de"))).Put("arm", ((V)("#efae62"))).Put("g", Arr(((V)("#ffe2b8")), ((V)("#f2b56c")), ((V)("#d48a3e")))).Put("ge", Arr(((V)("#c98a50")), ((V)("#a8693a")), ((V)("#7c4724")))).Put("tailHL", ((V)("#ffe2b8"))).V).Put("body", Arr(((V)(50D)), ((V)(77D)), ((V)(21D)), ((V)(14D)))).Put("belly", Arr(((V)(50D)), ((V)(80D)), ((V)(12D)), ((V)(9D)), ((V)("#fff3e0")))).Put("bellyTurn", (true ? V.True : V.False)).Put("feet", Arr(Arr(((V)(38D)), ((V)(90D))), Arr(((V)(62D)), ((V)(90D))))).Put("pads", Arr(Arr(((V)((-4D))), ((V)(1D)), ((V)(1.6)), ((V)(1.2))), Arr(((V)(0D)), ((V)(2D)), ((V)(1.6)), ((V)(1.2))), Arr(((V)(4D)), ((V)(1D)), ((V)(1.6)), ((V)(1.2))))).Put("ears", Arr(NewObj(6).Put("side", ((V)((-1D)))).Put("flop", (true ? V.True : V.False)).Put("lobe", Arr(((V)(19D)), ((V)(42D)), ((V)(10.5)), ((V)(18D)), ((V)(9D)), ((V)((-2D))), ((V)(14D)))).Put("pivot", Arr(((V)(27D)), ((V)(30D)))).Put("tip", Arr(((V)(15D)), ((V)(58D)))).Put("d", ((V)("M28 26 Q14 22 10 36 Q8 52 18 60 Q24 62 26 54 Q26 40 32 32Z"))).V, NewObj(6).Put("side", ((V)(1D))).Put("flop", (true ? V.True : V.False)).Put("lobe", Arr(((V)(81D)), ((V)(42D)), ((V)(10.5)), ((V)(18D)), ((V)(9D)), ((V)((-2D))), ((V)((-14D))))).Put("pivot", Arr(((V)(73D)), ((V)(30D)))).Put("tip", Arr(((V)(85D)), ((V)(58D)))).Put("d", ((V)("M72 26 Q86 22 90 36 Q92 52 82 60 Q76 62 74 54 Q74 40 68 32Z"))).V)).Put("arms", Arr(NewObj(3).Put("side", ((V)((-1D)))).Put("e", Arr(((V)(30.6)), ((V)(77D)), ((V)(6D)), ((V)(8D)), ((V)(15D)))).Put("pivot", Arr(((V)(32.7)), ((V)(69.3)))).V, NewObj(3).Put("side", ((V)(1D))).Put("e", Arr(((V)(69.4)), ((V)(77D)), ((V)(6D)), ((V)(8D)), ((V)((-15D))))).Put("pivot", Arr(((V)(67.3)), ((V)(69.3)))).V)).Put("tail", Arr(Arr(((V)(72D)), ((V)(78D))), Arr(((V)(86D)), ((V)(77D))), Arr(((V)(89D)), ((V)(65D))), Arr(((V)(84D)), ((V)(57D))))).Put("tailW", ((V)(6D))).Put("tailRoot", Arr(Arr(((V)(62D)), ((V)(86D))), Arr(((V)(67D)), ((V)(83D))))).Put("eyes", Arr(Arr(((V)(38D)), ((V)(45D))), Arr(((V)(62D)), ((V)(45D))))).Put("eyeR", ((V)(5.2))).Put("tail3", Arr(Arr(((V)(50D)), ((V)(80D)), ((V)((-16D)))), Arr(((V)(51D)), ((V)(79D)), ((V)((-31D)))), Arr(((V)(60D)), ((V)(74D)), ((V)((-34D)))), Arr(((V)(71D)), ((V)(62D)), ((V)((-27D)))))).Put("tailWag", ((V)(1.7))).Put("tailK", ((V)(8D))).Put("tailTaper", Arr(((V)(0.86)), ((V)(0.36)))).Put("tailShade", ((V)("#c9873f"))).Put("muzzle", Arr(((V)(50D)), ((V)(56D)), ((V)(15D)), ((V)(11D)))).Put("nose", Arr(((V)(50D)), ((V)(53D)), ((V)(4.4)), ((V)(3.2)))).Put("noseHL", Arr(((V)(48.6)), ((V)(52D)), ((V)(1.4)), ((V)(0.9)))).Put("mouth", Arr(((V)(50D)), ((V)(60D)), ((V)(4.5)))).Put("cheeks", Arr(Arr(((V)(33D)), ((V)(55D))), Arr(((V)(67D)), ((V)(55D))))).Put("faceExtra", Arr(NewObj(3).Put("d", ((V)("M44 20 Q50 16 56 20 Q54 30 50 34 Q46 30 44 20Z"))).Put("fill", ((V)("#fff1de"))).Put("op", ((V)(0.9))).V, NewObj(3).Put("d", ((V)("M50 56 L50 59"))).Put("stroke", ((V)("#6a3a3a"))).Put("sw", ((V)(1.2))).V)).Put("whiskers", Arr()).Put("stripes", ((V)(""))).Put("back", ((V)("M44 22 Q50 18 56 22"))).Put("collar", NewObj(3).Put("d", ((V)("M30 66 Q50 74 70 66 L70 70 Q50 78 30 70Z"))).Put("fill", ((V)("#ff6f86"))).Put("ring", NewObj(8).Put("ys", ((V)(64D))).Put("af", ((V)(4D))).Put("ab", ((V)(1.5))).Put("w", ((V)(4D))).Put("rx", ((V)(20D))).Put("rz", ((V)(20D))).Put("dark", ((V)("#c8445d"))).Put("light", ((V)("#ff9cb0"))).V).V).Put("tag", NewObj(4).Put("x", ((V)(50D))).Put("y", ((V)(74D))).Put("r", ((V)(3.4))).Put("fill", ((V)("#ffd84a"))).V).V);
Set(DEFS_34, "waffles", NewObj(34).Put("G", ((V)(95.5))).Put("top", ((V)(15D))).Put("head", Arr(((V)(50D)), ((V)(46D)), ((V)(30D)), ((V)(26.5)))).Put("neck", Arr(((V)(50D)), ((V)(72D)))).Put("c", NewObj(13).Put("tail", ((V)("#e8953e"))).Put("tailB", ((V)("#e0903c"))).Put("pad", ((V)("#fff1de"))).Put("inner", ((V)("#ffd29a"))).Put("muzzle", ((V)("#fff1de"))).Put("nose", ((V)("#2a1a30"))).Put("cheek", ((V)("#ff8fa3"))).Put("mouth", ((V)("#6a3a3a"))).Put("whisker", ((V)("none"))).Put("stripe", ((V)("#fff1de"))).Put("arm", ((V)("#eda052"))).Put("g", Arr(((V)("#ffd29a")), ((V)("#e8953e")), ((V)("#b86424")))).Put("tailHL", ((V)("#ffd29a"))).V).Put("grads", NewObj(1).Put("wcr", Arr(Arr(((V)("0")), ((V)("#fffaf2"))), Arr(((V)("0.6")), ((V)("#fff1de"))), Arr(((V)("1")), ((V)("#f0d9b8"))))).V).Put("headD", ((V)("M50 20 Q57.38 14.9 61.86 21.98 Q71 19.63 71.92 27.62 Q81.44 28.38 78.64 36.05 Q87.08 39.81 81 46 Q87.08 52.19 78.64 55.95 Q81.44 63.62 71.92 64.38 Q71 72.37 61.86 70.02 Q57.38 77.1 50 72 Q42.62 77.1 38.14 70.02 Q29 72.37 28.08 64.38 Q18.56 63.62 21.36 55.95 Q12.92 52.19 19 46 Q12.92 39.81 21.36 36.05 Q18.56 28.38 28.08 27.62 Q29 19.63 38.14 21.98 Q42.62 14.9 50 20Z"))).Put("body", Arr(((V)(50D)), ((V)(77D)), ((V)(21D)), ((V)(14D)))).Put("belly", Arr(((V)(50D)), ((V)(80D)), ((V)(12D)), ((V)(9D)), ((V)("url(#wcr)")))).Put("bellyTurn", (true ? V.True : V.False)).Put("feet", Arr(Arr(((V)(38D)), ((V)(90D))), Arr(((V)(62D)), ((V)(90D))))).Put("pads", Arr(Arr(((V)((-4D))), ((V)(1D)), ((V)(1.6)), ((V)(1.2))), Arr(((V)(0D)), ((V)(2D)), ((V)(1.6)), ((V)(1.2))), Arr(((V)(4D)), ((V)(1D)), ((V)(1.6)), ((V)(1.2))))).Put("ears", Arr(NewObj(4).Put("side", ((V)((-1D)))).Put("pivot", Arr(((V)(33D)), ((V)(34D)))).Put("tip", Arr(((V)(28D)), ((V)(7D)))).Put("d", ((V)("M24 40 Q18 14 28 6 Q40 14 42 34Z"))).V, NewObj(4).Put("side", ((V)(1D))).Put("pivot", Arr(((V)(67D)), ((V)(34D)))).Put("tip", Arr(((V)(72D)), ((V)(7D)))).Put("d", ((V)("M76 40 Q82 14 72 6 Q60 14 58 34Z"))).V)).Put("arms", Arr(NewObj(3).Put("side", ((V)((-1D)))).Put("e", Arr(((V)(30.6)), ((V)(77D)), ((V)(6D)), ((V)(8D)), ((V)(15D)))).Put("pivot", Arr(((V)(32.7)), ((V)(69.3)))).V, NewObj(3).Put("side", ((V)(1D))).Put("e", Arr(((V)(69.4)), ((V)(77D)), ((V)(6D)), ((V)(8D)), ((V)((-15D))))).Put("pivot", Arr(((V)(67.3)), ((V)(69.3)))).V)).Put("tail", Arr(Arr(((V)(72D)), ((V)(78D))), Arr(((V)(86D)), ((V)(77D))), Arr(((V)(89D)), ((V)(65D))), Arr(((V)(84D)), ((V)(57D))))).Put("eyes", Arr(Arr(((V)(38D)), ((V)(45D))), Arr(((V)(62D)), ((V)(45D))))).Put("eyeR", ((V)(5.2))).Put("tail3", Arr(Arr(((V)(50D)), ((V)(80D)), ((V)((-16D)))), Arr(((V)(50D)), ((V)(79D)), ((V)((-22.5)))), Arr(((V)(51D)), ((V)(77D)), ((V)((-25.5)))), Arr(((V)(52.5)), ((V)(74D)), ((V)((-26.5)))))).Put("tailWag", ((V)(1.9))).Put("tailK", ((V)(8.5))).Put("tailTaper", Arr(((V)(0.92)), ((V)(0.78)))).Put("tailShade", ((V)("#b86424"))).Put("muzzle", Arr(((V)(50D)), ((V)(56D)), ((V)(15D)), ((V)(11D)))).Put("nose", Arr(((V)(50D)), ((V)(53D)), ((V)(4.4)), ((V)(3.2)))).Put("noseHL", Arr(((V)(48.6)), ((V)(52D)), ((V)(1.4)), ((V)(0.9)))).Put("mouth", Arr(((V)(50D)), ((V)(60D)), ((V)(4.5)))).Put("cheeks", Arr(Arr(((V)(33D)), ((V)(55D))), Arr(((V)(67D)), ((V)(55D))))).Put("tufts", Arr(NewObj(2).Put("c", Arr(((V)(26D)), ((V)(58D)))).Put("d", ((V)("M26 49 Q29.06 46.57 30.5 50.21 Q34.37 49.63 33.79 53.5 Q37.43 54.94 35 58 Q37.43 61.06 33.79 62.5 Q34.37 66.37 30.5 65.79 Q29.06 69.43 26 67 Q22.94 69.43 21.5 65.79 Q17.63 66.37 18.21 62.5 Q14.57 61.06 17 58 Q14.57 54.94 18.21 53.5 Q17.63 49.63 21.5 50.21 Q22.94 46.57 26 49Z"))).V, NewObj(2).Put("c", Arr(((V)(74D)), ((V)(58D)))).Put("d", ((V)("M74 49 Q77.06 46.57 78.5 50.21 Q82.37 49.63 81.79 53.5 Q85.43 54.94 83 58 Q85.43 61.06 81.79 62.5 Q82.37 66.37 78.5 65.79 Q77.06 69.43 74 67 Q70.94 69.43 69.5 65.79 Q65.63 66.37 66.21 62.5 Q62.57 61.06 65 58 Q62.57 54.94 66.21 53.5 Q65.63 49.63 69.5 50.21 Q70.94 46.57 74 49Z"))).V)).Put("faceExtra", Arr(NewObj(3).Put("d", ((V)("M50 30 Q54.77 28.38 57 30.8 Q63.02 30.42 62.12 33 Q67.79 33.96 64 36 Q67.79 38.04 62.12 39 Q63.02 41.58 57 41.2 Q54.77 43.62 50 42 Q45.23 43.62 43 41.2 Q36.98 41.58 37.88 39 Q32.21 38.04 36 36 Q32.21 33.96 37.88 33 Q36.98 30.42 43 30.8 Q45.23 28.38 50 30Z"))).Put("fill", ((V)("url(#wcr)"))).Put("op", ((V)(0.85))).V, NewObj(3).Put("d", ((V)("M44 20 Q50 16 56 20 Q54 30 50 34 Q46 30 44 20Z"))).Put("fill", ((V)("#fff1de"))).Put("op", ((V)(0.9))).V, NewObj(3).Put("d", ((V)("M50 56 L50 59"))).Put("stroke", ((V)("#6a3a3a"))).Put("sw", ((V)(1.2))).V, NewObj(2).Put("d", ((V)("M47.5 61 Q50 67 52.5 61Z"))).Put("fill", ((V)("#ff7f96"))).V)).Put("whiskers", Arr()).Put("stripes", ((V)(""))).Put("back", ((V)(""))).Put("collar", NewObj(3).Put("d", ((V)("M30 66 Q50 74 70 66 L70 70 Q50 78 30 70Z"))).Put("fill", ((V)("#b86424"))).Put("ring", NewObj(9).Put("ys", ((V)(66D))).Put("af", ((V)(4D))).Put("ab", ((V)(1.5))).Put("w", ((V)(4D))).Put("rx", ((V)(20D))).Put("rz", ((V)(20D))).Put("dark", ((V)("#7e3f12"))).Put("light", ((V)("#d9894a"))).Put("stitch", ((V)("#f2c48c"))).V).V).Put("tag", NewObj(5).Put("x", ((V)(50D))).Put("y", ((V)(74D))).Put("r", ((V)(3.4))).Put("fill", ((V)("#fff8ee"))).Put("metal", Arr(((V)("#ffffff")), ((V)("#efece6")), ((V)("#b3ada2")), ((V)("#8a8478")))).V).V);
Set(DEFS_34, "truffle", NewObj(29).Put("G", ((V)(95.5))).Put("top", ((V)(21D))).Put("head", Arr(((V)(50D)), ((V)(47D)), ((V)(30D)), ((V)(26D)))).Put("neck", Arr(((V)(50D)), ((V)(72D)))).Put("c", NewObj(12).Put("tail", ((V)("#f095ad"))).Put("tailB", ((V)("#f4a3b8"))).Put("pad", ((V)("#d9718f"))).Put("inner", ((V)("#f59ab2"))).Put("muzzle", ((V)("#ff9fb6"))).Put("nose", ((V)("#b8506e"))).Put("cheek", ((V)("#ff7f9a"))).Put("mouth", ((V)("#6a3a3a"))).Put("whisker", ((V)("none"))).Put("stripe", ((V)("none"))).Put("arm", ((V)("#ffb3c6"))).Put("g", Arr(((V)("#ffe6ec")), ((V)("#ffb8c8")), ((V)("#ee8aa6")))).V).Put("grads", NewObj(1).Put("pcr", Arr(Arr(((V)("0")), ((V)("#fff6f8"))), Arr(((V)("0.6")), ((V)("#ffe2ea"))), Arr(((V)("1")), ((V)("#f7c3d1"))))).V).Put("body", Arr(((V)(50D)), ((V)(77D)), ((V)(23D)), ((V)(15.5)))).Put("belly", Arr(((V)(50D)), ((V)(80D)), ((V)(14D)), ((V)(10D)), ((V)("url(#pcr)")))).Put("bellyTurn", (true ? V.True : V.False)).Put("feet", Arr(Arr(((V)(38D)), ((V)(90D))), Arr(((V)(62D)), ((V)(90D))))).Put("pads", Arr(Arr(((V)(0D)), ((V)(3.2)), ((V)(5.6)), ((V)(1.6))))).Put("ears", Arr(NewObj(5).Put("side", ((V)((-1D)))).Put("pivot", Arr(((V)(32D)), ((V)(30D)))).Put("tip", Arr(((V)(27D)), ((V)(13.5)))).Put("d", ((V)("M25 33 Q16 16 28 13 Q38 16 39 27 Z"))).Put("inner", ((V)("M27 28 Q22 18 29 17 Q35 19 35 26 Z"))).V, NewObj(5).Put("side", ((V)(1D))).Put("pivot", Arr(((V)(68D)), ((V)(30D)))).Put("tip", Arr(((V)(73D)), ((V)(13.5)))).Put("d", ((V)("M75 33 Q84 16 72 13 Q62 16 61 27 Z"))).Put("inner", ((V)("M73 28 Q78 18 71 17 Q65 19 65 26 Z"))).V)).Put("arms", Arr(NewObj(3).Put("side", ((V)((-1D)))).Put("e", Arr(((V)(30.6)), ((V)(77D)), ((V)(6D)), ((V)(8D)), ((V)(15D)))).Put("pivot", Arr(((V)(32.7)), ((V)(69.3)))).V, NewObj(3).Put("side", ((V)(1D))).Put("e", Arr(((V)(69.4)), ((V)(77D)), ((V)(6D)), ((V)(8D)), ((V)((-15D))))).Put("pivot", Arr(((V)(67.3)), ((V)(69.3)))).V)).Put("tail", Arr(Arr(((V)(72D)), ((V)(78D))), Arr(((V)(86D)), ((V)(77D))), Arr(((V)(89D)), ((V)(65D))), Arr(((V)(84D)), ((V)(57D))))).Put("eyes", Arr(Arr(((V)(37D)), ((V)(43.5))), Arr(((V)(63D)), ((V)(43.5))))).Put("eyeR", ((V)(5.2))).Put("tail3", Arr(Arr(((V)(50D)), ((V)(80D)), ((V)((-16D)))), Arr(((V)(51.5)), ((V)(79D)), ((V)((-24D)))), Arr(((V)(58D)), ((V)(77D)), ((V)((-28D)))), Arr(((V)(66D)), ((V)(76D)), ((V)((-27D)))), Arr(((V)(73D)), ((V)(75D)), ((V)((-24D)))), Arr(((V)(78D)), ((V)(72D)), ((V)((-21D)))), Arr(((V)(79.5)), ((V)(68.5)), ((V)((-19.5)))), Arr(((V)(77D)), ((V)(66.5)), ((V)((-19.5)))), Arr(((V)(74.5)), ((V)(68D)), ((V)((-20.5)))), Arr(((V)(75.5)), ((V)(71D)), ((V)((-21.5)))), Arr(((V)(78D)), ((V)(71.5)), ((V)((-21D)))))).Put("tailWag", ((V)(1.3))).Put("tailK", ((V)(2.1))).Put("tailTaper", Arr(((V)(1D)), ((V)(0.78)))).Put("tailShade", ((V)("#d9718f"))).Put("muzzle", Arr(((V)(50D)), ((V)(56D)), ((V)(10D)), ((V)(7D)))).Put("nose", V.Null).Put("mouth", Arr(((V)(50D)), ((V)(64.6)), ((V)(4.6)))).Put("cheeks", Arr(Arr(((V)(27D)), ((V)(54D))), Arr(((V)(73D)), ((V)(54D))))).Put("faceExtra", Arr(NewObj(2).Put("d", ((V)("M44.60 56.00 C44.60 54.62 45.36 53.50 46.30 53.50 C47.24 53.50 48.00 54.62 48.00 56.00 C48.00 57.38 47.24 58.50 46.30 58.50 C45.36 58.50 44.60 57.38 44.60 56.00Z"))).Put("fill", ((V)("#b8506e"))).V, NewObj(2).Put("d", ((V)("M52.00 56.00 C52.00 54.62 52.76 53.50 53.70 53.50 C54.64 53.50 55.40 54.62 55.40 56.00 C55.40 57.38 54.64 58.50 53.70 58.50 C52.76 58.50 52.00 57.38 52.00 56.00Z"))).Put("fill", ((V)("#b8506e"))).V, NewObj(3).Put("d", ((V)("M44.50 52.60 C44.50 51.99 45.84 51.50 47.50 51.50 C49.16 51.50 50.50 51.99 50.50 52.60 C50.50 53.21 49.16 53.70 47.50 53.70 C45.84 53.70 44.50 53.21 44.50 52.60Z"))).Put("fill", ((V)("#ffffff"))).Put("op", ((V)(0.45))).V)).Put("whiskers", Arr()).Put("stripes", ((V)(""))).Put("back", ((V)(""))).V);
Set(DEFS_34, "ribbit", NewObj(26).Put("G", ((V)(95.5))).Put("top", ((V)(19D))).Put("head", Arr(((V)(50D)), ((V)(46D)), ((V)(34D)), ((V)(27D)))).Put("neck", Arr(((V)(50D)), ((V)(70D)))).Put("c", NewObj(10).Put("pad", ((V)("#b9e88e"))).Put("inner", ((V)("#9fdb66"))).Put("muzzle", ((V)("#fff2b8"))).Put("nose", ((V)("#3f7a26"))).Put("cheek", ((V)("#ff4f86"))).Put("mouth", ((V)("#6a3a3a"))).Put("whisker", ((V)("none"))).Put("stripe", ((V)("none"))).Put("arm", ((V)("#9fdb66"))).Put("g", Arr(((V)("#ecffc6")), ((V)("#9fdb66")), ((V)("#5fa63a")))).V).Put("grads", NewObj(1).Put("fcr", Arr(Arr(((V)("0")), ((V)("#fffbe2"))), Arr(((V)("0.6")), ((V)("#fff2b8"))), Arr(((V)("1")), ((V)("#f2dc8c"))))).V).Put("body", Arr(((V)(50D)), ((V)(78D)), ((V)(23D)), ((V)(15D)))).Put("belly", Arr(((V)(50D)), ((V)(81D)), ((V)(15D)), ((V)(10D)), ((V)("url(#fcr)")))).Put("bellyTurn", (true ? V.True : V.False)).Put("feet", Arr(Arr(((V)(34D)), ((V)(90D))), Arr(((V)(66D)), ((V)(90D))))).Put("footS", Arr(((V)(10.5)), ((V)(5D)), ((V)(8D)))).Put("pads", Arr(Arr(((V)((-5D))), ((V)(3.2)), ((V)(2.3)), ((V)(2.1))), Arr(((V)(0D)), ((V)(4D)), ((V)(2.3)), ((V)(2.1))), Arr(((V)(5D)), ((V)(3.2)), ((V)(2.3)), ((V)(2.1))))).Put("tufts", Arr(NewObj(6).Put("c", Arr(((V)(33D)), ((V)(31D)))).Put("r", ((V)(12D))).Put("lift", ((V)(3D))).Put("white", Arr(((V)(0D)), ((V)(0D)), ((V)(8D)))).Put("d", ((V)("M21.00 31.00 C21.00 24.37 26.37 19.00 33.00 19.00 C39.63 19.00 45.00 24.37 45.00 31.00 C45.00 37.63 39.63 43.00 33.00 43.00 C26.37 43.00 21.00 37.63 21.00 31.00Z"))).Put("fill", ((V)("url(#g)"))).V, NewObj(6).Put("c", Arr(((V)(67D)), ((V)(31D)))).Put("r", ((V)(12D))).Put("lift", ((V)(3D))).Put("white", Arr(((V)(0D)), ((V)(0D)), ((V)(8D)))).Put("d", ((V)("M55.00 31.00 C55.00 24.37 60.37 19.00 67.00 19.00 C73.63 19.00 79.00 24.37 79.00 31.00 C79.00 37.63 73.63 43.00 67.00 43.00 C60.37 43.00 55.00 37.63 55.00 31.00Z"))).Put("fill", ((V)("url(#g)"))).V)).Put("eyeDome", (true ? V.True : V.False)).Put("ears", Arr()).Put("arms", Arr(NewObj(3).Put("side", ((V)((-1D)))).Put("e", Arr(((V)(30.6)), ((V)(77D)), ((V)(5.5)), ((V)(8D)), ((V)(15D)))).Put("pivot", Arr(((V)(33.1)), ((V)(69.5)))).V, NewObj(3).Put("side", ((V)(1D))).Put("e", Arr(((V)(69.4)), ((V)(77D)), ((V)(5.5)), ((V)(8D)), ((V)((-15D))))).Put("pivot", Arr(((V)(66.9)), ((V)(69.5)))).V)).Put("eyes", Arr(Arr(((V)(33.5)), ((V)(32D))), Arr(((V)(66.5)), ((V)(32D))))).Put("eyeR", ((V)(5.6))).Put("muzzle", V.Null).Put("nose", V.Null).Put("mouth", Arr(((V)(50D)), ((V)(52.4)), ((V)(3.8)))).Put("cheeks", Arr(Arr(((V)(26D)), ((V)(56D))), Arr(((V)(74D)), ((V)(56D))))).Put("faceExtra", Arr(NewObj(3).Put("d", ((V)("M41.80 37.00 C41.80 35.78 42.78 34.80 44.00 34.80 C45.22 34.80 46.20 35.78 46.20 37.00 C46.20 38.22 45.22 39.20 44.00 39.20 C42.78 39.20 41.80 38.22 41.80 37.00Z"))).Put("fill", ((V)("#5f9e38"))).Put("op", ((V)(0.45))).V, NewObj(3).Put("d", ((V)("M55.40 38.50 C55.40 37.62 56.12 36.90 57.00 36.90 C57.88 36.90 58.60 37.62 58.60 38.50 C58.60 39.38 57.88 40.10 57.00 40.10 C56.12 40.10 55.40 39.38 55.40 38.50Z"))).Put("fill", ((V)("#5f9e38"))).Put("op", ((V)(0.45))).V, NewObj(3).Put("d", ((V)("M21.20 48.00 C21.20 47.01 22.01 46.20 23.00 46.20 C23.99 46.20 24.80 47.01 24.80 48.00 C24.80 48.99 23.99 49.80 23.00 49.80 C22.01 49.80 21.20 48.99 21.20 48.00Z"))).Put("fill", ((V)("#5f9e38"))).Put("op", ((V)(0.45))).V, NewObj(3).Put("d", ((V)("M75.00 47.00 C75.00 45.90 75.90 45.00 77.00 45.00 C78.10 45.00 79.00 45.90 79.00 47.00 C79.00 48.10 78.10 49.00 77.00 49.00 C75.90 49.00 75.00 48.10 75.00 47.00Z"))).Put("fill", ((V)("#5f9e38"))).Put("op", ((V)(0.45))).V, NewObj(2).Put("d", ((V)("M45.60 47.00 C45.60 46.50 46.00 46.10 46.50 46.10 C47.00 46.10 47.40 46.50 47.40 47.00 C47.40 47.50 47.00 47.90 46.50 47.90 C46.00 47.90 45.60 47.50 45.60 47.00Z"))).Put("fill", ((V)("#3f7a26"))).V, NewObj(2).Put("d", ((V)("M52.60 47.00 C52.60 46.50 53.00 46.10 53.50 46.10 C54.00 46.10 54.40 46.50 54.40 47.00 C54.40 47.50 54.00 47.90 53.50 47.90 C53.00 47.90 52.60 47.50 52.60 47.00Z"))).Put("fill", ((V)("#3f7a26"))).V)).Put("whiskers", Arr()).Put("stripes", ((V)(""))).Put("back", ((V)(""))).V);
REST_35 = NewObj(53).Put("sblur", ((V)(0D))).Put("x", ((V)(0D))).Put("lift", ((V)(0D))).Put("tilt", ((V)(0D))).Put("sq", ((V)(0D))).Put("lean", ((V)(0D))).Put("bend", ((V)(0D))).Put("spin", ((V)(0D))).Put("turn", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("twist", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("wag", ((V)(0D))).Put("curl", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("close", ((V)(0D))).Put("sl", ((V)(0D))).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).Put("hap", ((V)(0D))).Put("wide", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("frown", ((V)(0D))).Put("blush", ((V)(0D))).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hLz", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("hRz", ((V)(0D))).Put("puff", ((V)(0D))).Put("tongue", ((V)(0D))).Put("sqz", ((V)(0D))).Put("cross", ((V)(0D))).Put("teary", ((V)(0D))).Put("red", ((V)(0D))).Put("green", ((V)(0D))).Put("sit", ((V)(0D))).Put("bristle", ((V)(0D))).Put("dbb", ((V)(0D))).Put("dbh", ((V)(0D))).Put("dbs", ((V)(0D))).Put("wsk", ((V)(0D))).V;
AR_36 = Fn((V _self1, int _argc6058, V K_6064, V _a6061, V _a6062, V _a6063, V[] _rest6059) => {
return NewObj(2).Put("armL", K_6064).Put("armR", K_6064).V;
}, 1, "", true);
ER_37 = Fn((V _self1, int _argc6065, V K_6071, V _a6068, V _a6069, V _a6070, V[] _rest6066) => {
return NewObj(2).Put("earL", K_6071).Put("earR", K_6071).V;
}, 1, "", true);
STATES_38 = NewObj(8).Put("idle", NewObj(3).Put("loop", ((V)(8400D))).Put("look", (true ? V.True : V.False)).Put("k", NewObj(5).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2100D)), ((V)((-0.025))), ((V)("s"))), Arr(((V)(4200D)), ((V)(0.012)), ((V)("s"))), Arr(((V)(6300D)), ((V)((-0.025))), ((V)("s"))), Arr(((V)(8400D)), ((V)(0D)), ((V)("s"))))).Put("lean", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2100D)), ((V)(0.9)), ((V)("s"))), Arr(((V)(4200D)), ((V)(0D)), ((V)("s"))), Arr(((V)(6300D)), ((V)((-0.9))), ((V)("s"))), Arr(((V)(8400D)), ((V)(0D)), ((V)("s"))))).Put("htilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2100D)), ((V)(1.4)), ((V)("s"))), Arr(((V)(4200D)), ((V)(0D)), ((V)("s"))), Arr(((V)(6300D)), ((V)((-1.4))), ((V)("s"))), Arr(((V)(8400D)), ((V)(0D)), ((V)("s"))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2100D)), ((V)(9D)), ((V)("s"))), Arr(((V)(4200D)), ((V)(0D)), ((V)("s"))), Arr(((V)(6300D)), ((V)((-9D))), ((V)("s"))), Arr(((V)(8400D)), ((V)(0D)), ((V)("s"))))).Put("earR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(5200D)), ((V)(0D))), Arr(((V)(5280D)), ((V)((-9D))), ((V)("o"))), Arr(((V)(5420D)), ((V)(4D)), ((V)("io"))), Arr(((V)(5600D)), ((V)(0D)), ((V)("io"))))).V).V).Put("look", NewObj(3).Put("dur", ((V)(6000D))).Put("ev", Arr(Arr(((V)(1950D)), ((V)("blink"))), Arr(((V)(4500D)), ((V)("blink"))))).Put("k", NewObj(11).Put("lx", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0D))), Arr(((V)(380D)), ((V)((-1D))), ((V)("o"))), Arr(((V)(1700D)), ((V)((-1D)))), Arr(((V)(1880D)), ((V)(1D)), ((V)("io"))), Arr(((V)(3200D)), ((V)(1D))), Arr(((V)(3380D)), ((V)(0D)), ((V)("io"))))).Put("ly", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(3400D)), ((V)(0D))), Arr(((V)(3580D)), ((V)((-1D))), ((V)("o"))), Arr(((V)(4400D)), ((V)((-1D)))), Arr(((V)(4580D)), ((V)(0.8)), ((V)("io"))), Arr(((V)(5200D)), ((V)(0.8))), Arr(((V)(5400D)), ((V)(0D)), ((V)("io"))))).Put("turn", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(330D)), ((V)(0D))), Arr(((V)(850D)), ((V)((-0.97))), ((V)("io"))), Arr(((V)(1050D)), ((V)((-0.9))), ((V)("io"))), Arr(((V)(1950D)), ((V)((-0.9)))), Arr(((V)(2550D)), ((V)(0.97)), ((V)("io"))), Arr(((V)(2750D)), ((V)(0.9)), ((V)("io"))), Arr(((V)(3300D)), ((V)(0.9))), Arr(((V)(3750D)), ((V)((-0.05))), ((V)("io"))), Arr(((V)(3950D)), ((V)(0D)), ((V)("io"))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(3450D)), ((V)(0D))), Arr(((V)(3950D)), ((V)(0.7)), ((V)("io"))), Arr(((V)(4450D)), ((V)(0.7))), Arr(((V)(4950D)), ((V)((-0.5))), ((V)("io"))), Arr(((V)(5250D)), ((V)((-0.5)))), Arr(((V)(5800D)), ((V)(0D)), ((V)("io"))))).Put("htilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(330D)), ((V)(0D))), Arr(((V)(900D)), ((V)((-4D))), ((V)("io"))), Arr(((V)(1950D)), ((V)((-4D)))), Arr(((V)(2600D)), ((V)(4D)), ((V)("io"))), Arr(((V)(3300D)), ((V)(4D))), Arr(((V)(3800D)), ((V)(0D)), ((V)("io"))))).Put("lean", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(350D)), ((V)(0D))), Arr(((V)(950D)), ((V)((-1.5))), ((V)("io"))), Arr(((V)(1950D)), ((V)((-1.5)))), Arr(((V)(2650D)), ((V)(1.5)), ((V)("io"))), Arr(((V)(3300D)), ((V)(1.5))), Arr(((V)(3800D)), ((V)(0D)), ((V)("io"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(3450D)), ((V)(0D))), Arr(((V)(3950D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(4450D)), ((V)((-0.04)))), Arr(((V)(4950D)), ((V)(0.03)), ((V)("io"))), Arr(((V)(5250D)), ((V)(0.03))), Arr(((V)(5800D)), ((V)(0D)), ((V)("io"))))).Put("armL", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(330D)), ((V)(0D))), Arr(((V)(850D)), ((V)(10D)), ((V)("io"))), Arr(((V)(1950D)), ((V)(10D))), Arr(((V)(2550D)), ((V)(0D)), ((V)("io"))))).Put("armR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(1950D)), ((V)(0D))), Arr(((V)(2550D)), ((V)(10D)), ((V)("io"))), Arr(((V)(3300D)), ((V)(10D))), Arr(((V)(3750D)), ((V)(0D)), ((V)("io"))))).Put("footL", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(350D)), ((V)(0D))), Arr(((V)(550D)), ((V)(2.2)), ((V)("o"))), Arr(((V)(750D)), ((V)(0D)), ((V)("io"))), Arr(((V)(2000D)), ((V)(0D))), Arr(((V)(2200D)), ((V)(2.2)), ((V)("o"))), Arr(((V)(2400D)), ((V)(0D)), ((V)("io"))), Arr(((V)(3350D)), ((V)(0D))), Arr(((V)(3550D)), ((V)(1.6)), ((V)("o"))), Arr(((V)(3750D)), ((V)(0D)), ((V)("io"))))).Put("footR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(500D)), ((V)(0D))), Arr(((V)(700D)), ((V)(2.2)), ((V)("o"))), Arr(((V)(900D)), ((V)(0D)), ((V)("io"))), Arr(((V)(2150D)), ((V)(0D))), Arr(((V)(2350D)), ((V)(2.2)), ((V)("o"))), Arr(((V)(2550D)), ((V)(0D)), ((V)("io"))), Arr(((V)(3500D)), ((V)(0D))), Arr(((V)(3700D)), ((V)(1.6)), ((V)("o"))), Arr(((V)(3900D)), ((V)(0D)), ((V)("io"))))).V).V).Put("squish", NewObj(3).Put("dur", ((V)(5400D))).Put("loop", ((V)(1800D))).Put("k", NewObj(8).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)((-0.05))), ((V)("o"))), Arr(((V)(480D)), ((V)(0.38)), ((V)("io"))), Arr(((V)(900D)), ((V)(0.4)), ((V)("l"))), Arr(((V)(1030D)), ((V)((-0.18))), ((V)("o"))), Arr(((V)(1180D)), ((V)(0.08)), ((V)("io"))), Arr(((V)(1340D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(1520D)), ((V)(0D)), ((V)("io"))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(330D)), ((V)(0D))), Arr(((V)(450D)), ((V)(0.85)), ((V)("o"))), Arr(((V)(920D)), ((V)(0.85))), Arr(((V)(1040D)), ((V)(0D)), ((V)("o"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(1000D)), ((V)(0D))), Arr(((V)(1100D)), ((V)(1D)), ((V)("o"))), Arr(((V)(1500D)), ((V)(1D))), Arr(((V)(1800D)), ((V)(0D)), ((V)("io"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(1000D)), ((V)(0D))), Arr(((V)(1080D)), ((V)(0.45)), ((V)("o"))), Arr(((V)(1400D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(980D)), ((V)(0D))), Arr(((V)(1110D)), ((V)(3.5)), ((V)("o"))), Arr(((V)(1240D)), ((V)(0D)), ((V)("i"))))).Spread(Call(AR_36, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(480D)), ((V)(18D)), ((V)("io"))), Arr(((V)(900D)), ((V)(20D))), Arr(((V)(1050D)), ((V)((-4D))), ((V)("o"))), Arr(((V)(1300D)), ((V)(0D)), ((V)("io")))))).Spread(Call(ER_37, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(480D)), ((V)(12D)), ((V)("io"))), Arr(((V)(900D)), ((V)(14D))), Arr(((V)(1050D)), ((V)((-6D))), ((V)("o"))), Arr(((V)(1300D)), ((V)(0D)), ((V)("io")))))).Put("blush", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(600D)), ((V)(0.6)), ((V)("io"))), Arr(((V)(1000D)), ((V)(0.6))), Arr(((V)(1500D)), ((V)(0D)), ((V)("io"))))).V).V).Put("spin", NewObj(3).Put("dur", ((V)(5400D))).Put("ev", Arr(Arr(((V)(1750D)), ((V)("blink"))), Arr(((V)(4450D)), ((V)("blink"))))).Put("k", NewObj(7).Put("spin", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0D))), Arr(((V)(500D)), ((V)((-25D))), ((V)("io"))), Arr(((V)(1450D)), ((V)(375D)), ((V)("io"))), Arr(((V)(1700D)), ((V)(360D)), ((V)("io"))), Arr(((V)(2900D)), ((V)(360D))), Arr(((V)(3200D)), ((V)(335D)), ((V)("io"))), Arr(((V)(4150D)), ((V)(735D)), ((V)("io"))), Arr(((V)(4400D)), ((V)(720D)), ((V)("io"))))).Put("turn", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0D))), Arr(((V)(500D)), ((V)(0.3)), ((V)("io"))), Arr(((V)(900D)), ((V)((-0.5))), ((V)("io"))), Arr(((V)(1450D)), ((V)(0.4)), ((V)("io"))), Arr(((V)(1800D)), ((V)(0D)), ((V)("io"))), Arr(((V)(2900D)), ((V)(0D))), Arr(((V)(3200D)), ((V)(0.3)), ((V)("io"))), Arr(((V)(3600D)), ((V)((-0.5))), ((V)("io"))), Arr(((V)(4150D)), ((V)(0.4)), ((V)("io"))), Arr(((V)(4500D)), ((V)(0D)), ((V)("io"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0D))), Arr(((V)(500D)), ((V)(0.14)), ((V)("io"))), Arr(((V)(700D)), ((V)((-0.1))), ((V)("o"))), Arr(((V)(1250D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(1450D)), ((V)(0.14)), ((V)("o"))), Arr(((V)(1600D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(1800D)), ((V)(0D)), ((V)("io"))), Arr(((V)(2900D)), ((V)(0D))), Arr(((V)(3200D)), ((V)(0.14)), ((V)("io"))), Arr(((V)(3400D)), ((V)((-0.1))), ((V)("o"))), Arr(((V)(3950D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(4150D)), ((V)(0.14)), ((V)("o"))), Arr(((V)(4300D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(4500D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(550D)), ((V)(0D))), Arr(((V)(850D)), ((V)(4D)), ((V)("o"))), Arr(((V)(1200D)), ((V)(4D))), Arr(((V)(1450D)), ((V)(0D)), ((V)("i"))), Arr(((V)(3250D)), ((V)(0D))), Arr(((V)(3550D)), ((V)(4D)), ((V)("o"))), Arr(((V)(3900D)), ((V)(4D))), Arr(((V)(4150D)), ((V)(0D)), ((V)("i"))))).Spread(Call(AR_36, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(500D)), ((V)((-8D))), ((V)("io"))), Arr(((V)(750D)), ((V)(35D)), ((V)("o"))), Arr(((V)(1300D)), ((V)(35D))), Arr(((V)(1500D)), ((V)(0D)), ((V)("io"))), Arr(((V)(2900D)), ((V)(0D))), Arr(((V)(3200D)), ((V)((-8D))), ((V)("io"))), Arr(((V)(3450D)), ((V)(35D)), ((V)("o"))), Arr(((V)(4000D)), ((V)(35D))), Arr(((V)(4200D)), ((V)(0D)), ((V)("io")))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(700D)), ((V)(0.7)), ((V)("io"))), Arr(((V)(1700D)), ((V)(0.7))), Arr(((V)(2100D)), ((V)(0D)), ((V)("io"))), Arr(((V)(2900D)), ((V)(0D))), Arr(((V)(3400D)), ((V)(0.7)), ((V)("io"))), Arr(((V)(4400D)), ((V)(0.7))), Arr(((V)(4800D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(700D)), ((V)(1D)), ((V)("io"))), Arr(((V)(1700D)), ((V)(1D))), Arr(((V)(2100D)), ((V)(0D)), ((V)("io"))), Arr(((V)(2900D)), ((V)(0D))), Arr(((V)(3400D)), ((V)(1D)), ((V)("io"))), Arr(((V)(4400D)), ((V)(1D))), Arr(((V)(4800D)), ((V)(0D)), ((V)("io"))))).V).V).Put("hop", NewObj(3).Put("dur", ((V)(5700D))).Put("loop", ((V)(1900D))).Put("k", NewObj(7).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(0D))), Arr(((V)(330D)), ((V)(0.24)), ((V)("io"))), Arr(((V)(410D)), ((V)((-0.2))), ((V)("o"))), Arr(((V)(640D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(780D)), ((V)((-0.12))), ((V)("i"))), Arr(((V)(820D)), ((V)(0.3)), ((V)("o"))), Arr(((V)(960D)), ((V)((-0.07))), ((V)("io"))), Arr(((V)(1100D)), ((V)(0.035)), ((V)("io"))), Arr(((V)(1260D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(380D)), ((V)(0D))), Arr(((V)(620D)), ((V)(18D)), ((V)("o"))), Arr(((V)(820D)), ((V)(0D)), ((V)("i"))))).Spread(Call(AR_36, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(330D)), ((V)((-12D))), ((V)("io"))), Arr(((V)(460D)), ((V)(38D)), ((V)("o"))), Arr(((V)(700D)), ((V)(26D)), ((V)("io"))), Arr(((V)(830D)), ((V)((-8D))), ((V)("o"))), Arr(((V)(1050D)), ((V)(0D)), ((V)("io")))))).Spread(Call(ER_37, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(330D)), ((V)((-6D))), ((V)("io"))), Arr(((V)(450D)), ((V)(10D)), ((V)("o"))), Arr(((V)(650D)), ((V)(2D)), ((V)("io"))), Arr(((V)(830D)), ((V)(12D)), ((V)("o"))), Arr(((V)(1000D)), ((V)((-3D))), ((V)("io"))), Arr(((V)(1200D)), ((V)(0D)), ((V)("io")))))).Put("ly", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(250D)), ((V)(0.4)), ((V)("io"))), Arr(((V)(450D)), ((V)((-0.6))), ((V)("o"))), Arr(((V)(850D)), ((V)(0.2)), ((V)("io"))), Arr(((V)(1200D)), ((V)(0D)), ((V)("io"))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(330D)), ((V)((-0.2))), ((V)("io"))), Arr(((V)(500D)), ((V)(0.3)), ((V)("o"))), Arr(((V)(820D)), ((V)((-0.2))), ((V)("io"))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(0.6)), ((V)("io"))), Arr(((V)(430D)), ((V)(0D)), ((V)("io"))), Arr(((V)(800D)), ((V)(0D))), Arr(((V)(840D)), ((V)(0.6)), ((V)("o"))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).V).Put("happy", NewObj(3).Put("dur", ((V)(7200D))).Put("loop", ((V)(2400D))).Put("k", NewObj(10).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0.2)), ((V)("io"))), Arr(((V)(270D)), ((V)((-0.16))), ((V)("o"))), Arr(((V)(480D)), ((V)((-0.02))), ((V)("io"))), Arr(((V)(600D)), ((V)((-0.1))), ((V)("i"))), Arr(((V)(640D)), ((V)(0.26)), ((V)("o"))), Arr(((V)(760D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(860D)), ((V)(0.18)), ((V)("io"))), Arr(((V)(930D)), ((V)((-0.16))), ((V)("o"))), Arr(((V)(1140D)), ((V)((-0.02))), ((V)("io"))), Arr(((V)(1260D)), ((V)((-0.1))), ((V)("i"))), Arr(((V)(1300D)), ((V)(0.26)), ((V)("o"))), Arr(((V)(1440D)), ((V)((-0.06))), ((V)("io"))), Arr(((V)(1600D)), ((V)(0.03)), ((V)("io"))), Arr(((V)(1800D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(240D)), ((V)(0D))), Arr(((V)(440D)), ((V)(13D)), ((V)("o"))), Arr(((V)(640D)), ((V)(0D)), ((V)("i"))), Arr(((V)(900D)), ((V)(0D))), Arr(((V)(1100D)), ((V)(13D)), ((V)("o"))), Arr(((V)(1300D)), ((V)(0D)), ((V)("i"))))).Put("tilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(240D)), ((V)(0D))), Arr(((V)(440D)), ((V)((-7D))), ((V)("io"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))), Arr(((V)(900D)), ((V)(0D))), Arr(((V)(1100D)), ((V)(7D)), ((V)("io"))), Arr(((V)(1360D)), ((V)(0D)), ((V)("io"))))).Put("htilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(440D)), ((V)((-3D))), ((V)("io"))), Arr(((V)(720D)), ((V)(4D)), ((V)("io"))), Arr(((V)(900D)), ((V)(0D)), ((V)("io"))), Arr(((V)(1100D)), ((V)(3D)), ((V)("io"))), Arr(((V)(1380D)), ((V)((-4D))), ((V)("io"))), Arr(((V)(1600D)), ((V)(0D)), ((V)("io"))))).Spread(Call(AR_36, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)((-8D))), ((V)("io"))), Arr(((V)(330D)), ((V)(48D)), ((V)("o"))), Arr(((V)(640D)), ((V)(40D))), Arr(((V)(700D)), ((V)(24D)), ((V)("io"))), Arr(((V)(860D)), ((V)((-6D))), ((V)("io"))), Arr(((V)(990D)), ((V)(48D)), ((V)("o"))), Arr(((V)(1300D)), ((V)(40D))), Arr(((V)(1400D)), ((V)(24D)), ((V)("io"))), Arr(((V)(1800D)), ((V)(0D)), ((V)("io")))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(16D)), ((V)("io"))), Arr(((V)(600D)), ((V)((-16D))), ((V)("io"))), Arr(((V)(900D)), ((V)(16D)), ((V)("io"))), Arr(((V)(1200D)), ((V)((-16D))), ((V)("io"))), Arr(((V)(1500D)), ((V)(16D)), ((V)("io"))), Arr(((V)(1800D)), ((V)((-16D))), ((V)("io"))), Arr(((V)(2100D)), ((V)(10D)), ((V)("io"))), Arr(((V)(2400D)), ((V)(0D)), ((V)("io"))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(1D))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(1D))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0.5))))).Put("ly", Arr(Arr(((V)(0D)), ((V)((-0.3)))))).V).V).Put("surprised", NewObj(3).Put("dur", ((V)(5200D))).Put("ev", Arr(Arr(((V)(2400D)), ((V)("blink2"))))).Put("k", NewObj(14).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0D))), Arr(((V)(280D)), ((V)(0.16)), ((V)("o"))), Arr(((V)(380D)), ((V)((-0.2))), ((V)("o"))), Arr(((V)(700D)), ((V)((-0.12))), ((V)("io"))), Arr(((V)(900D)), ((V)(0.12)), ((V)("o"))), Arr(((V)(1050D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(1200D)), ((V)(0D)), ((V)("io"))), Arr(((V)(3700D)), ((V)(0D))), Arr(((V)(3800D)), ((V)(0.1)), ((V)("o"))), Arr(((V)(3900D)), ((V)((-0.15))), ((V)("o"))), Arr(((V)(4200D)), ((V)((-0.05))), ((V)("io"))), Arr(((V)(4350D)), ((V)(0.08)), ((V)("o"))), Arr(((V)(4550D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(0D))), Arr(((V)(560D)), ((V)(9D)), ((V)("o"))), Arr(((V)(880D)), ((V)(0D)), ((V)("i"))), Arr(((V)(3820D)), ((V)(0D))), Arr(((V)(4020D)), ((V)(6D)), ((V)("o"))), Arr(((V)(4300D)), ((V)(0D)), ((V)("i"))))).Put("x", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(0D))), Arr(((V)(880D)), ((V)((-7D))), ((V)("o"))), Arr(((V)(2500D)), ((V)((-7D)))), Arr(((V)(3300D)), ((V)(0D)), ((V)("io"))))).Put("lean", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(0D))), Arr(((V)(500D)), ((V)((-5D))), ((V)("o"))), Arr(((V)(880D)), ((V)((-2D))), ((V)("io"))), Arr(((V)(1100D)), ((V)(1.5)), ((V)("io"))), Arr(((V)(1400D)), ((V)(0D)), ((V)("io"))))).Put("tilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(0D))), Arr(((V)(500D)), ((V)((-7D))), ((V)("o"))), Arr(((V)(900D)), ((V)((-2D))), ((V)("io"))), Arr(((V)(1300D)), ((V)(0D)), ((V)("io"))))).Put("wide", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(280D)), ((V)(0D))), Arr(((V)(340D)), ((V)(1D)), ((V)("o"))), Arr(((V)(2300D)), ((V)(1D))), Arr(((V)(2700D)), ((V)(0.3)), ((V)("io"))), Arr(((V)(3700D)), ((V)(0.3))), Arr(((V)(3800D)), ((V)(1D)), ((V)("o"))), Arr(((V)(4500D)), ((V)(1D))), Arr(((V)(4900D)), ((V)(0D)), ((V)("io"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(280D)), ((V)(0D))), Arr(((V)(360D)), ((V)(0.7)), ((V)("o"))), Arr(((V)(1900D)), ((V)(0.65))), Arr(((V)(2300D)), ((V)(0.15)), ((V)("io"))), Arr(((V)(3700D)), ((V)(0.1))), Arr(((V)(3800D)), ((V)(0.65)), ((V)("o"))), Arr(((V)(4500D)), ((V)(0.55))), Arr(((V)(4900D)), ((V)(0D)), ((V)("io"))))).Put("mw", Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(280D)), ((V)(1D))), Arr(((V)(360D)), ((V)(0.6)), ((V)("o"))), Arr(((V)(2300D)), ((V)(0.6))), Arr(((V)(2700D)), ((V)(1D)), ((V)("io"))), Arr(((V)(3700D)), ((V)(1D))), Arr(((V)(3800D)), ((V)(0.6)), ((V)("o"))), Arr(((V)(4500D)), ((V)(0.6))), Arr(((V)(4900D)), ((V)(1D)), ((V)("io"))))).Spread(Call(AR_36, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(280D)), ((V)(0D))), Arr(((V)(380D)), ((V)(34D)), ((V)("o"))), Arr(((V)(1900D)), ((V)(30D))), Arr(((V)(2400D)), ((V)(8D)), ((V)("io"))), Arr(((V)(3700D)), ((V)(8D))), Arr(((V)(3800D)), ((V)(34D)), ((V)("o"))), Arr(((V)(4500D)), ((V)(30D))), Arr(((V)(4900D)), ((V)(0D)), ((V)("io")))))).Spread(Call(ER_37, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(280D)), ((V)(0D))), Arr(((V)(380D)), ((V)((-12D))), ((V)("o"))), Arr(((V)(1700D)), ((V)((-10D)))), Arr(((V)(2100D)), ((V)(0D)), ((V)("io"))), Arr(((V)(3700D)), ((V)(0D))), Arr(((V)(3800D)), ((V)((-10D))), ((V)("o"))), Arr(((V)(4500D)), ((V)((-8D)))), Arr(((V)(4900D)), ((V)(0D)), ((V)("io")))))).Put("lx", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2500D)), ((V)(0D))), Arr(((V)(2650D)), ((V)((-0.9))), ((V)("o"))), Arr(((V)(3000D)), ((V)((-0.9)))), Arr(((V)(3150D)), ((V)(0.9)), ((V)("io"))), Arr(((V)(3550D)), ((V)(0.9))), Arr(((V)(3700D)), ((V)(0D)), ((V)("io"))))).Put("turn", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2550D)), ((V)(0D))), Arr(((V)(2900D)), ((V)((-0.35))), ((V)("io"))), Arr(((V)(3100D)), ((V)((-0.35)))), Arr(((V)(3450D)), ((V)(0.35)), ((V)("io"))), Arr(((V)(3600D)), ((V)(0.35))), Arr(((V)(3800D)), ((V)(0D)), ((V)("io"))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(0D))), Arr(((V)(450D)), ((V)(0.25)), ((V)("o"))), Arr(((V)(1500D)), ((V)(0.2))), Arr(((V)(2000D)), ((V)(0D)), ((V)("io"))))).Put("curl", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(350D)), ((V)(0.8)), ((V)("o"))), Arr(((V)(2000D)), ((V)(0.6))), Arr(((V)(2600D)), ((V)(0D)), ((V)("io"))))).V).V).Put("sleep", NewObj(4).Put("dur", ((V)(9000D))).Put("noBlink", (true ? V.True : V.False)).Put("ev", Arr(Arr(((V)(8550D)), ((V)("blink2"))))).Put("k", NewObj(10).Put("open", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(0.9)), ((V)("io"))), Arr(((V)(1100D)), ((V)(0.9))), Arr(((V)(1500D)), ((V)(0D)), ((V)("io"))))).Put("mw", Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(300D)), ((V)(0.75)), ((V)("io"))), Arr(((V)(1100D)), ((V)(0.75))), Arr(((V)(1500D)), ((V)(1D)), ((V)("io"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)((-0.08))), ((V)("io"))), Arr(((V)(1100D)), ((V)((-0.08)))), Arr(((V)(1500D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(2800D)), ((V)(0.05))), Arr(((V)(4100D)), ((V)(0.09)), ((V)("s"))), Arr(((V)(5400D)), ((V)(0.03)), ((V)("s"))), Arr(((V)(6700D)), ((V)(0.09)), ((V)("s"))), Arr(((V)(8000D)), ((V)(0.05)), ((V)("s"))), Arr(((V)(8250D)), ((V)((-0.1))), ((V)("o"))), Arr(((V)(8500D)), ((V)(0.04)), ((V)("io"))), Arr(((V)(8800D)), ((V)(0D)), ((V)("io"))))).Spread(Call(AR_36, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(36D)), ((V)("io"))), Arr(((V)(1100D)), ((V)(36D))), Arr(((V)(1500D)), ((V)(0D)), ((V)("io")))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(0.75)), ((V)("io"))), Arr(((V)(1100D)), ((V)(0.75))), Arr(((V)(1500D)), ((V)(0.45)), ((V)("io"))), Arr(((V)(2000D)), ((V)(0.7)), ((V)("io"))), Arr(((V)(2300D)), ((V)(0.4)), ((V)("io"))), Arr(((V)(2800D)), ((V)(1D)), ((V)("io"))), Arr(((V)(8200D)), ((V)(1D))), Arr(((V)(8450D)), ((V)(0D)), ((V)("o"))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(0.4)), ((V)("io"))), Arr(((V)(1100D)), ((V)(0.4))), Arr(((V)(1600D)), ((V)(0D)), ((V)("io"))), Arr(((V)(2800D)), ((V)((-0.4))), ((V)("io"))), Arr(((V)(8200D)), ((V)((-0.4)))), Arr(((V)(8450D)), ((V)(0D)), ((V)("io"))))).Put("htilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2800D)), ((V)(0D))), Arr(((V)(3300D)), ((V)(7D)), ((V)("io"))), Arr(((V)(8200D)), ((V)(7D))), Arr(((V)(8450D)), ((V)(0D)), ((V)("io"))))).Spread(Call(ER_37, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2800D)), ((V)(8D)), ((V)("io"))), Arr(((V)(8200D)), ((V)(8D))), Arr(((V)(8300D)), ((V)((-6D))), ((V)("o"))), Arr(((V)(8600D)), ((V)(0D)), ((V)("io")))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2800D)), ((V)(0D))), Arr(((V)(3300D)), ((V)(0.3)), ((V)("io"))), Arr(((V)(8200D)), ((V)(0.3))), Arr(((V)(8400D)), ((V)(0D)), ((V)("io"))))).Put("curl", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2800D)), ((V)(0D))), Arr(((V)(3400D)), ((V)((-0.3))), ((V)("io"))), Arr(((V)(8200D)), ((V)((-0.3)))), Arr(((V)(8600D)), ((V)(0D)), ((V)("io"))))).V).V).V;
RELEASE_39 = NewObj(2).Put("dur", ((V)(1000D))).Put("k", NewObj(5).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.2))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.1)), ((V)("io"))), Arr(((V)(390D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(3D)), ((V)("o"))), Arr(((V)(270D)), ((V)(0D)), ((V)("i"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(0.8)), ((V)("o"))), Arr(((V)(700D)), ((V)(0.8))), Arr(((V)(1000D)), ((V)(0D)), ((V)("io"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(0.35)), ((V)("o"))), Arr(((V)(500D)), ((V)(0D)), ((V)("io"))))).Spread(Call(ER_37, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)((-8D))), ((V)("o"))), Arr(((V)(300D)), ((V)(6D)), ((V)("io"))), Arr(((V)(500D)), ((V)(0D)), ((V)("io")))))).V).V;
POKE_40 = Fn((V _self1, int _argc6072, V s_6078, V _a6075, V _a6076, V _a6077, V[] _rest6073) => {
return NewObj(2).Put("dur", ((V)(1100D))).Put("k", NewObj(7).Put("dent", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(45D)), ((V)(1D)), ((V)("o"))), Arr(((V)(200D)), ((V)(0.3)), ((V)("io"))), Arr(((V)(460D)), ((V)(0D)), ((V)("io"))))).Put("lean", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(70D)), ((V)((4D * ToNum(s_6078)))), ((V)("o"))), Arr(((V)(300D)), ((V)(((-1.6) * ToNum(s_6078)))), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(40D)), ((V)(1D)), ((V)("o"))), Arr(((V)(170D)), ((V)(1D))), Arr(((V)(300D)), ((V)(0D)), ((V)("io"))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(280D)), ((V)(0D))), Arr(((V)(360D)), ((V)(1D)), ((V)("o"))), Arr(((V)(850D)), ((V)(1D))), Arr(((V)(1050D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(280D)), ((V)(0D))), Arr(((V)(360D)), ((V)(1D)), ((V)("o"))), Arr(((V)(850D)), ((V)(1D))), Arr(((V)(1050D)), ((V)(0D)), ((V)("io"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(280D)), ((V)(0D))), Arr(((V)(360D)), ((V)(0.35)), ((V)("o"))), Arr(((V)(850D)), ((V)(0.3))), Arr(((V)(1050D)), ((V)(0D)), ((V)("io"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(60D)), ((V)(0.06)), ((V)("o"))), Arr(((V)(200D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(380D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(480D)), ((V)((-0.02))), ((V)("io"))), Arr(((V)(580D)), ((V)(0.04)), ((V)("io"))), Arr(((V)(680D)), ((V)((-0.01))), ((V)("io"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))).V).V;
}, 1, "", true);
HYAW_41 = New(G("Set"), Arr());
SOFT_42 = New(G("Set"), Arr(((V)("mittens")), ((V)("biscuit")), ((V)("prickle")), ((V)("nibbles")), ((V)("quill")), ((V)("poppy")), ((V)("duchess")), ((V)("mamapaws")), ((V)("waffles")), ((V)("truffle")), ((V)("ribbit"))));
DENT_44 = NewObj(2).Put("dur", ((V)(600D))).Put("k", NewObj(2).Put("dent", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(45D)), ((V)(1D)), ((V)("o"))), Arr(((V)(200D)), ((V)(0.3)), ((V)("io"))), Arr(((V)(460D)), ((V)(0D)), ((V)("io"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(50D)), ((V)(0.05)), ((V)("o"))), Arr(((V)(200D)), ((V)((-0.02))), ((V)("io"))), Arr(((V)(360D)), ((V)(0D)), ((V)("io"))))).V).V;
PRE_49 = NewObj(23).Put("crumb", NewObj(8).Put("n", ((V)(3D))).Put("sp", ((V)(9D))).Put("vy", ((V)((-6D)))).Put("g", ((V)(90D))).Put("life", ((V)(650D))).Put("r", Arr(((V)(0.5)), ((V)(0.9)))).Put("col", Arr(((V)("#d9a35a")), ((V)("#b77a3a")), ((V)("#f0c890")))).Put("kind", ((V)("dot"))).V).Put("drop", NewObj(8).Put("n", ((V)(5D))).Put("sp", ((V)(20D))).Put("vy", ((V)((-16D)))).Put("g", ((V)(80D))).Put("life", ((V)(750D))).Put("r", Arr(((V)(0.7)), ((V)(1.2)))).Put("col", Arr(((V)("#8fd3ff")), ((V)("#bfe8ff")))).Put("kind", ((V)("drop"))).V).Put("splash", NewObj(8).Put("n", ((V)(8D))).Put("sp", ((V)(28D))).Put("vy", ((V)((-28D)))).Put("g", ((V)(95D))).Put("life", ((V)(820D))).Put("r", Arr(((V)(0.8)), ((V)(1.4)))).Put("col", Arr(((V)("#8fd3ff")), ((V)("#bfe8ff")))).Put("kind", ((V)("drop"))).V).Put("tear", NewObj(8).Put("n", ((V)(1D))).Put("sp", ((V)(0.6))).Put("vy", ((V)(3D))).Put("g", ((V)(16D))).Put("life", ((V)(1150D))).Put("r", Arr(((V)(1D)), ((V)(1.2)))).Put("col", Arr(((V)("#8fd3ff")))).Put("kind", ((V)("drop"))).V).Put("gush", NewObj(10).Put("n", ((V)(2D))).Put("sp", ((V)(5D))).Put("vx", ((V)(24D))).Put("vy", ((V)((-15D)))).Put("g", ((V)(75D))).Put("life", ((V)(760D))).Put("r", Arr(((V)(0.9)), ((V)(1.4)))).Put("col", Arr(((V)("#8fd3ff")), ((V)("#bfe8ff")))).Put("kind", ((V)("drop"))).Put("out", ((V)(1D))).V).Put("bubble", NewObj(7).Put("n", ((V)(2D))).Put("sp", ((V)(7D))).Put("vy", ((V)((-9D)))).Put("g", ((V)((-3D)))).Put("life", ((V)(1700D))).Put("r", Arr(((V)(1.2)), ((V)(2.6)))).Put("kind", ((V)("bubble"))).V).Put("bigbubble", NewObj(9).Put("n", ((V)(1D))).Put("sp", ((V)(3D))).Put("vx", ((V)(7D))).Put("vy", ((V)((-6D)))).Put("g", ((V)((-1.5)))).Put("life", ((V)(2600D))).Put("r", Arr(((V)(3.6)), ((V)(4.6)))).Put("kind", ((V)("bubble"))).Put("out", ((V)(1D))).V).Put("spark", NewObj(8).Put("n", ((V)(4D))).Put("sp", ((V)(16D))).Put("vy", ((V)((-6D)))).Put("g", ((V)(0D))).Put("life", ((V)(700D))).Put("r", Arr(((V)(1.4)), ((V)(2.4)))).Put("col", Arr(((V)("#fff3a0")), ((V)("#ffffff")))).Put("kind", ((V)("star"))).V).Put("heart", NewObj(7).Put("n", ((V)(1D))).Put("sp", ((V)(7D))).Put("vy", ((V)((-12D)))).Put("g", ((V)((-2D)))).Put("life", ((V)(1300D))).Put("r", Arr(((V)(0.8)), ((V)(1.1)))).Put("kind", ((V)("heart"))).V).Put("stink", NewObj(8).Put("n", ((V)(1D))).Put("sp", ((V)(7D))).Put("vy", ((V)((-7D)))).Put("g", ((V)((-1D)))).Put("life", ((V)(1900D))).Put("r", Arr(((V)(1D)), ((V)(1.3)))).Put("col", Arr(((V)("#8fae55")), ((V)("#a3c266")))).Put("kind", ((V)("wave"))).V).Put("steam", NewObj(8).Put("n", ((V)(2D))).Put("sp", ((V)(3D))).Put("vy", ((V)((-13D)))).Put("g", ((V)((-4D)))).Put("life", ((V)(900D))).Put("r", Arr(((V)(1.6)), ((V)(2.6)))).Put("col", Arr(((V)("#ffffff")))).Put("kind", ((V)("puff"))).V).Put("foam", NewObj(8).Put("n", ((V)(2D))).Put("sp", ((V)(9D))).Put("vy", ((V)((-3D)))).Put("g", ((V)(0D))).Put("life", ((V)(1300D))).Put("r", Arr(((V)(1.6)), ((V)(2.8)))).Put("col", Arr(((V)("#ffffff")))).Put("kind", ((V)("puff"))).V).Put("seed", NewObj(10).Put("n", ((V)(1D))).Put("sp", ((V)(2D))).Put("vx", ((V)(20D))).Put("vy", ((V)((-10D)))).Put("g", ((V)(70D))).Put("life", ((V)(800D))).Put("r", Arr(((V)(0.7)), ((V)(0.8)))).Put("col", Arr(((V)("#2a1a30")))).Put("kind", ((V)("seed"))).Put("out", ((V)(1D))).V).Put("sneeze", NewObj(8).Put("n", ((V)(9D))).Put("sp", ((V)(20D))).Put("vy", ((V)(2D))).Put("g", ((V)(18D))).Put("life", ((V)(620D))).Put("r", Arr(((V)(0.5)), ((V)(1D)))).Put("col", Arr(((V)("#d6f2fc")), ((V)("#ffffff")))).Put("kind", ((V)("dot"))).V).Put("note", NewObj(8).Put("n", ((V)(1D))).Put("sp", ((V)(9D))).Put("vy", ((V)((-11D)))).Put("g", ((V)((-2D)))).Put("life", ((V)(1400D))).Put("r", Arr(((V)(1D)), ((V)(1D)))).Put("col", Arr(((V)("#8f3cf2")), ((V)("#ff5cc6")), ((V)("#2f7fd6")))).Put("kind", ((V)("note"))).V).Put("sweat", NewObj(8).Put("n", ((V)(1D))).Put("sp", ((V)(0D))).Put("vy", ((V)(2D))).Put("g", ((V)(20D))).Put("life", ((V)(900D))).Put("r", Arr(((V)(1.1)), ((V)(1.1)))).Put("col", Arr(((V)("#8fd3ff")))).Put("kind", ((V)("drop"))).V).Put("duck", NewObj(10).Put("n", ((V)(1D))).Put("sp", ((V)(0D))).Put("vx", ((V)(2.2))).Put("vy", ((V)((-24D)))).Put("g", ((V)(120D))).Put("life", ((V)(3600D))).Put("r", Arr(((V)(1D)), ((V)(1.15)))).Put("kind", ((V)("duck"))).Put("out", ((V)(1D))).Put("hop", ((V)(1D))).V).Put("dust", NewObj(8).Put("n", ((V)(3D))).Put("sp", ((V)(8D))).Put("vy", ((V)((-2D)))).Put("g", ((V)(5D))).Put("life", ((V)(1500D))).Put("r", Arr(((V)(0.35)), ((V)(0.75)))).Put("col", Arr(((V)("#fff1d6")), ((V)("#d2b6f4")), ((V)("#ffffff")))).Put("kind", ((V)("dot"))).V).Put("sprinkle", NewObj(8).Put("n", ((V)(4D))).Put("sp", ((V)(22D))).Put("vy", ((V)((-22D)))).Put("g", ((V)(90D))).Put("life", ((V)(950D))).Put("r", Arr(((V)(0.7)), ((V)(0.9)))).Put("col", Arr(((V)("#ffd84a")), ((V)("#7cc8ff")), ((V)("#9be38a")), ((V)("#ffffff")), ((V)("#ff5cc6")))).Put("kind", ((V)("seed"))).V).Put("salt", NewObj(8).Put("n", ((V)(3D))).Put("sp", ((V)(10D))).Put("vy", ((V)(2D))).Put("g", ((V)(70D))).Put("life", ((V)(900D))).Put("r", Arr(((V)(0.45)), ((V)(0.75)))).Put("col", Arr(((V)("#ffffff")), ((V)("#f2f0ff")), ((V)("#fffbe6")))).Put("kind", ((V)("dot"))).V).Put("ketchup", NewObj(8).Put("n", ((V)(3D))).Put("sp", ((V)(14D))).Put("vy", ((V)((-15D)))).Put("g", ((V)(90D))).Put("life", ((V)(800D))).Put("r", Arr(((V)(0.9)), ((V)(1.4)))).Put("col", Arr(((V)("#e8352a")), ((V)("#ff5a4a")), ((V)("#c8241c")))).Put("kind", ((V)("drop"))).V).Put("coffee", NewObj(8).Put("n", ((V)(4D))).Put("sp", ((V)(18D))).Put("vy", ((V)((-20D)))).Put("g", ((V)(90D))).Put("life", ((V)(800D))).Put("r", Arr(((V)(0.8)), ((V)(1.3)))).Put("col", Arr(((V)("#8a5a3a")), ((V)("#b07a52")))).Put("kind", ((V)("drop"))).V).Put("gust", NewObj(10).Put("n", ((V)(1D))).Put("sp", ((V)(3D))).Put("vx", ((V)(26D))).Put("vy", ((V)((-3D)))).Put("g", ((V)(0D))).Put("life", ((V)(1000D))).Put("r", Arr(((V)(0.9)), ((V)(1.4)))).Put("col", Arr(((V)("#9ad8cc")), ((V)("#7cc8ff")))).Put("kind", ((V)("wisp"))).Put("out", ((V)(1D))).V).V;
DUCK_54 = ((V)("<ellipse cx=\"0.2\" cy=\"-2\" rx=\"3.5\" ry=\"2.3\" fill=\"#e9a512\"/><ellipse cx=\"-0.2\" cy=\"-2.4\" rx=\"3.1\" ry=\"1.9\" fill=\"#ffd43b\"/><path d=\"M-3 -2.6 L-4.5 -4.2 L-2.4 -3.5Z\" fill=\"#ffd43b\"/><path d=\"M-1.6 -2.6 Q0 -1.2 1.4 -2.6\" stroke=\"#e9a512\" stroke-width=\"0.5\" fill=\"none\" stroke-linecap=\"round\"/><circle cx=\"1.95\" cy=\"-4.85\" r=\"1.85\" fill=\"#e9a512\"/><circle cx=\"1.8\" cy=\"-5\" r=\"1.75\" fill=\"#ffd43b\"/><ellipse cx=\"3.7\" cy=\"-4.6\" rx=\"1.05\" ry=\"0.5\" fill=\"#ff8a2a\"/><circle cx=\"2.4\" cy=\"-5.4\" r=\"0.36\" fill=\"#2a1a30\"/><ellipse cx=\"1.1\" cy=\"-5.8\" rx=\"0.6\" ry=\"0.35\" fill=\"#fff8d0\"/><ellipse cx=\"-1.2\" cy=\"-3.3\" rx=\"1\" ry=\"0.4\" fill=\"#fff8d0\" opacity=\"0.8\"/>"));
bub_55 = Fn((V _self1, int _argc6079, V x_6085, V y_6086, V r_6087, V op_6088, V[] _rest6080) => {
return ((V)(string.Concat(new string[] { "<circle cx=\"", ToStr(Call(r2_14, V.Undef, x_6085)), "\" cy=\"", ToStr(Call(r2_14, V.Undef, y_6086)), "\" r=\"", ToStr(Call(r2_14, V.Undef, r_6087)), "\" fill=\"#ffffff\" stroke=\"#cfe8f4\" stroke-width=\"0.35\" opacity=\"", ToStr(Call(r2_14, V.Undef, op_6088)), "\"/><circle cx=\"", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(x_6085) - (ToNum(r_6087) * 0.35)))))), "\" cy=\"", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(y_6086) - (ToNum(r_6087) * 0.38)))))), "\" r=\"", ToStr(Call(r2_14, V.Undef, ((V)((ToNum(r_6087) * 0.26))))), "\" fill=\"#eaf7ff\" opacity=\"", ToStr(Call(r2_14, V.Undef, op_6088)), "\"/>" })));
}, 4, "", true);
blinkC_58 = Fn((V _self1, int _argc6089, V t_6095, V _a6092, V _a6093, V _a6094, V[] _rest6090) => {
return (LtN(t_6095, 0D) ? ((V)(0D)) : (LtN(t_6095, 75D) ? Invoke(EZ_18, "i", ((V)((ToNum(t_6095) / 75D)))) : ((V)((LtN(t_6095, 105D) ? 1D : (LtN(t_6095, 240D) ? (1D - ToNum(Invoke(EZ_18, "o", ((V)(((ToNum(t_6095) - 105D) / 135D)))))) : 0D))))));
}, 1, "", true);
FX_61 = NewObj(3).Put("sleep", Fn((V _self6096, int _argc6097, V I_6103, V t_6104, V _a6101, V _a6102, V[] _rest6098) => {
V h_6105 = default;
V x0_6106 = default;
V y0_6107 = default;
if (_self6096.IsNullish) _self6096 = GlobalV;
if ((LtN(t_6104, 2900D) || GtN(t_6104, 8150D))) {
return ((V)(""));
}
h_6105 = ((V)(""));
{ V _t6108 = Get(I_6103, "topW");
{ V _t6109 = ListOf(_t6108);
{ V _t6110 = GetIdx(_t6109, 0D);
x0_6106 = _t6110; }
{ V _t6111 = GetIdx(_t6109, 1D);
y0_6107 = _t6111; }
} }
{
double i_6112 = 0;
i_6112 = 0D;
while (true) {
if (!((i_6112 < 3D))) break;
double u_6114 = 0;
V x_6115 = default;
double y_6116 = 0;
u_6114 = ((((ToNum(t_6104) - 2900D) / 2600D) + (i_6112 / 3D)) % 1D);
x_6115 = Add(Add(Add(x0_6106, ((V)(16D))), ((V)((u_6114 * 14D)))), ((V)((FdLibm.Sin((u_6114 * TAU_12)) * 2D))));
y_6116 = (ToNum(Add(y0_6107, ((V)(4D)))) - (u_6114 * 22D));
h_6105 = ((V)(string.Concat(new string[] { ToStr(h_6105), "<text x=\"", ToStr(Call(r2_14, V.Undef, x_6115)), "\" y=\"", ToStr(Call(r2_14, V.Undef, ((V)(y_6116)))), "\" font-family=\"Fredoka,sans-serif\" font-weight=\"700\" font-size=\"", ToStr(Call(r2_14, V.Undef, ((V)((5D + (u_6114 * 5D)))))), "\" fill=\"#8f3cf2\" stroke=\"#ffffff\" stroke-width=\"0.6\" paint-order=\"stroke\" opacity=\"", ToStr(Call(r2_14, V.Undef, ((V)(FdLibm.Sin((System.Math.PI * u_6114)))))), "\">z</text>" })));
i_6112++;
}
}
return h_6105;
return default;
}, 2, "sleep", false)).Put("happy", Fn((V _self6117, int _argc6118, V I_6124, V t_6125, V _a6122, V _a6123, V[] _rest6119) => {
V h_6126 = default;
if (_self6117.IsNullish) _self6117 = GlobalV;
h_6126 = ((V)(""));
{
double i_6127 = 0;
i_6127 = 0D;
while (true) {
if (!((i_6127 < 8D))) break;
double a_6129 = 0;
double u_6130 = 0;
double r_6131 = 0;
a_6129 = (((i_6127 / 8D) * TAU_12) + (i_6127 * 0.7));
u_6130 = (((ToNum(t_6125) / 900D) + (i_6127 / 8D)) % 1D);
r_6131 = (36D * (0.55 + (0.45 * u_6130)));
h_6126 = ((V)(string.Concat(new string[] { ToStr(h_6126), "<path d=\"", ToStr(Call(star4_33, V.Undef, ((V)((50D + (FdLibm.Cos(a_6129) * r_6131)))), ((V)((52D + ((FdLibm.Sin(a_6129) * r_6131) * 0.8)))), ((V)((1.2 + (2.2 * FdLibm.Sin((System.Math.PI * u_6130)))))))), "\" fill=\"", (NumTruthy((i_6127 % 2D)) ? "#fff3a0" : "#ffffff"), "\" opacity=\"", ToStr(Call(r2_14, V.Undef, ((V)(FdLibm.Sin((System.Math.PI * u_6130)))))), "\"/>" })));
i_6127++;
}
}
return h_6126;
return default;
}, 2, "happy", false)).Put("surprised", Fn((V _self6132, int _argc6133, V I_6139, V t_6140, V _a6137, V _a6138, V[] _rest6134) => {
V u_6141 = default;
V x0_6142 = default;
V y0_6143 = default;
double a_6144 = 0;
V h_6145 = default;
if (_self6132.IsNullish) _self6132 = GlobalV;
u_6141 = Call(clamp_13, V.Undef, ((V)(((ToNum(t_6140) - 300D) / 700D))), ((V)(0D)), ((V)(1D)));
if ((LeN(u_6141, 0D) || GeN(u_6141, 1D))) {
return ((V)(""));
}
{ V _t6146 = Get(I_6139, "topW");
{ V _t6147 = ListOf(_t6146);
{ V _t6148 = GetIdx(_t6147, 0D);
x0_6142 = _t6148; }
{ V _t6149 = GetIdx(_t6147, 1D);
y0_6143 = _t6149; }
} }
a_6144 = FdLibm.Sin((System.Math.PI * ToNum(u_6141)));
h_6145 = ((V)(""));
Invoke(Arr(((V)((-34D))), ((V)(0D)), ((V)(34D))), "forEach", Fn((V _self6132, int _argc6150, V d_6156, V _a6153, V _a6154, V _a6155, V[] _rest6151) => {
double r_6157 = 0;
double s_6158 = 0;
V x1_6159 = default;
double y1_6160 = 0;
V x2_6161 = default;
double y2_6162 = 0;
r_6157 = (ToNum(d_6156) * D2R_11);
s_6158 = (6D + (ToNum(u_6141) * 4D));
x1_6159 = Add(x0_6142, ((V)((FdLibm.Sin(r_6157) * s_6158))));
y1_6160 = ((ToNum(y0_6143) - 3D) - (FdLibm.Cos(r_6157) * s_6158));
x2_6161 = Add(x0_6142, ((V)((FdLibm.Sin(r_6157) * (s_6158 + 5D)))));
y2_6162 = ((ToNum(y0_6143) - 3D) - (FdLibm.Cos(r_6157) * (s_6158 + 5D)));
h_6145 = ((V)(string.Concat(new string[] { ToStr(h_6145), "<path d=\"M", ToStr(Call(r2_14, V.Undef, x1_6159)), " ", ToStr(Call(r2_14, V.Undef, ((V)(y1_6160)))), " L", ToStr(Call(r2_14, V.Undef, x2_6161)), " ", ToStr(Call(r2_14, V.Undef, ((V)(y2_6162)))), "\" stroke=\"#8f3cf2\" stroke-width=\"1.6\" stroke-linecap=\"round\" opacity=\"", ToStr(Call(r2_14, V.Undef, ((V)(a_6144)))), "\"/>" })));
return default;
}, 1, "", true));
return h_6145;
return default;
}, 2, "surprised", false)).V;
ALL_65 = New(G("Set"));
raf_66 = ((V)(0D));
last_67 = ((V)(0D));
UID_68 = 0D;
kick_70 = Fn((V _self1, int _argc6163, V _a6165, V _a6166, V _a6167, V _a6168, V[] _rest6164) => {
if (!(Truthy(raf_66))) {
last_67 = ((V)(0D));
raf_66 = Call(G("requestAnimationFrame"), V.Undef, loop_69);
}
return default;
}, 0, "", true);
Call(G("setInterval"), V.Undef, Fn((V _self1, int _argc6178, V _a6180, V _a6181, V _a6182, V _a6183, V[] _rest6179) => {
V n_6175 = default;
n_6175 = Invoke(G("performance"), "now");
if (Truthy((Get(ALL_65, "size") is var _t6184 && !Truthy(_t6184) ? _t6184 : (((ToNum(n_6175) - ToNum(last_67)) > 80D) ? V.True : V.False)))) {
V r_6177 = default;
r_6177 = raf_66;
raf_66 = ((V)(0D));
if (Truthy(r_6177)) {
Call(G("cancelAnimationFrame"), V.Undef, r_6177);
}
Call(loop_69, V.Undef, n_6175);
}
return default;
}, 0, "", true), ((V)(50D)));
LPARTS_71 = Arr(Arr(((V)("mane")), ((V)(40D))), Arr(((V)("tail")), ((V)(16D)), ((V)("tube"))), Arr(((V)("body")), ((V)(36D))), Arr(((V)("earL")), ((V)(18D)), ((V)("tube"))), Arr(((V)("earR")), ((V)(18D)), ((V)("tube"))), Arr(((V)("head")), ((V)(40D))), Arr(((V)("armL")), ((V)(16D))), Arr(((V)("armR")), ((V)(16D))), Arr(((V)("footL")), ((V)(13D))), Arr(((V)("footR")), ((V)(13D))));
LOCC_72 = NewObj(4).Put("body", Arr(Arr(((V)("head")), ((V)(0.75))), Arr(((V)("armL")), ((V)(0.6))), Arr(((V)("armR")), ((V)(0.6))))).Put("footL", Arr(Arr(((V)("body")), ((V)(0.45))))).Put("footR", Arr(Arr(((V)("body")), ((V)(0.45))))).Put("tail", Arr(Arr(((V)("body")), ((V)(0.6))))).V;
LRECT_73 = ((V)("M-90 -110H190V210H-90Z "));
LOOK0_74 = NewObj(7).Put("dir", Arr(((V)(0.75)), ((V)(0.55)))).Put("sh", ((V)(0.5))).Put("rim", ((V)(0.42))).Put("rimC", ((V)("#fff4dc"))).Put("line", ((V)(1.05))).Put("cast", ((V)(0D))).Put("contact", ((V)(1D))).V;
MODES_75 = NewObj(4).Put("1", NewObj(1).Put("line", ((V)(0D))).V).Put("2", NewObj(2).Put("line", ((V)(0.7))).Put("lineC", ((V)("#4a3a2e"))).V).Put("3", NewObj(2).Put("line", ((V)(1.05))).Put("lineC", ((V)("#4a3a2e"))).V).Put("4", NewObj(2).Put("line", ((V)(1.05))).Put("lineC", V.Null).V).V;
LOOK_76 = 4D;
rgbP_77 = Fn((V _self1, int _argc6185, V c_6191, V _a6188, V _a6189, V _a6190, V[] _rest6186) => {
V m_6192 = default;
V h_6193 = default;
V x_6194 = default;
m_6192 = Invoke(((V)(ToStrS((c_6191 is var _t6195 && Truthy(_t6195) ? _t6195 : ((V)("")))))), "match", NewRegExp(RX12, "rgba?\\(([\\d.]+),\\s*([\\d.]+),\\s*([\\d.]+)", ""));
if (Truthy(m_6192)) {
return Arr(((V)(ToNum(GetIdx(m_6192, 1D)))), ((V)(ToNum(GetIdx(m_6192, 2D)))), ((V)(ToNum(GetIdx(m_6192, 3D)))));
}
h_6193 = Invoke(((V)(ToStrS((c_6191 is var _t6196 && Truthy(_t6196) ? _t6196 : ((V)("")))))), "match", NewRegExp(RX13, "^#([\\da-f]{3}|[\\da-f]{6})$", "i"));
if (!(Truthy(h_6193))) {
return V.Null;
}
x_6194 = GetIdx(h_6193, 1D);
if (SEqN(Get(x_6194, "length"), 3D)) {
x_6194 = Invoke(x_6194, "replace", NewRegExp(RX14, ".", "g"), ((V)("$&$&")));
}
return Invoke(Arr(((V)(0D)), ((V)(2D)), ((V)(4D))), "map", Fn((V _self1, int _argc6197, V i_6203, V _a6200, V _a6201, V _a6202, V[] _rest6198) => {
return ((V)(ParseInt(Invoke(x_6194, "slice", i_6203, Add(i_6203, ((V)(2D)))), ((V)(16D)))));
}, 1, "", true));
return default;
}, 1, "", true);
lineOf_81 = Fn((V _self1, int _argc6204, V c_6210, V _a6207, V _a6208, V _a6209, V[] _rest6205) => {
V h_6211 = default;
V s_6212 = default;
V l_6213 = default;
{ V _t6214 = Call(hsl_79, V.Undef, c_6210);
{ V _t6215 = ListOf(_t6214);
{ V _t6216 = GetIdx(_t6215, 0D);
h_6211 = _t6216; }
{ V _t6217 = GetIdx(_t6215, 1D);
s_6212 = _t6217; }
{ V _t6218 = GetIdx(_t6215, 2D);
l_6213 = _t6218; }
} }
if (LtN(s_6212, 0.1)) {
h_6211 = (LtN(s_6212, 0.03) ? ((V)(0.08)) : h_6211);
s_6212 = ((V)(0.22));
}
return Call(hex_80, V.Undef, Arr(h_6211, ((V)(Min(1D, ((ToNum(s_6212) * 1.12) + 0.06)))), ((V)(Max(0.1, Min(0.42, (ToNum(l_6213) * 0.42)))))));
return default;
}, 1, "", true);
shadeOf_82 = Fn((V _self1, int _argc6219, V c_6225, V _a6222, V _a6223, V _a6224, V[] _rest6220) => {
V h_6226 = default;
V s_6227 = default;
V l_6228 = default;
{ V _t6229 = Call(hsl_79, V.Undef, c_6225);
{ V _t6230 = ListOf(_t6229);
{ V _t6231 = GetIdx(_t6230, 0D);
h_6226 = _t6231; }
{ V _t6232 = GetIdx(_t6230, 1D);
s_6227 = _t6232; }
{ V _t6233 = GetIdx(_t6230, 2D);
l_6228 = _t6233; }
} }
return Call(hex_80, V.Undef, Arr(h_6226, ((V)(Min(1D, ((ToNum(s_6227) * 1.05) + 0.05)))), ((V)((ToNum(l_6228) * 0.55)))));
return default;
}, 1, "", true);
mixHex_83 = Fn((V _self1, int _argc6234, V a_6240, V b_6241, V t_6242, V _a6239, V[] _rest6235) => {
V A_6243 = default;
V B_6244 = default;
A_6243 = Call(rgbP_77, V.Undef, a_6240);
B_6244 = Call(rgbP_77, V.Undef, b_6241);
return Call(hex_80, V.Undef, Call(hsl_79, V.Undef, Invoke(A_6243, "map", Fn((V _self1, int _argc6245, V v_6251, V i_6252, V _a6249, V _a6250, V[] _rest6246) => {
return Add(v_6251, ((V)(((ToNum(GetK(B_6244, i_6252)) - ToNum(v_6251)) * ToNum(t_6242)))));
}, 2, "", true))));
return default;
}, 3, "", true);
FACE_85 = New(G("Map"));
SVGNS_90 = ((V)("http://www.w3.org/2000/svg"));
FIDGETS_96 = Arr();
FIDK_97 = NewObj(0).V;
PRESS_98 = NewObj(0).V;
REL_99 = NewObj(0).V;
Set(G("window"), "RiveRig", NewObj(24).Put("v", ((V)(2D))).Put("setLook", Fn((V _self1, int _argc6253, V m_6259, V _a6256, V _a6257, V _a6258, V[] _rest6254) => {
LOOK_76 = (SEq(m_6259, (true ? V.True : V.False)) ? 4D : (SEq(m_6259, (false ? V.True : V.False)) ? 0D : Max(0D, Min(4D, ((double)(ToInt32(ToNum(m_6259)) | ToInt32(0D)))))));
Invoke(ALL_65, "forEach", Fn((V _self1, int _argc6260, V I_6266, V _a6263, V _a6264, V _a6265, V[] _rest6261) => {
Call(applyLook_86, V.Undef, I_6266);
try {
Call(tick_59, V.Undef, I_6266, Invoke(G("performance"), "now"), ((V)(0.016)));
} catch (System.Exception _ex6267) {
V e_6268 = default;
e_6268 = Caught(_ex6267);

}
return default;
}, 1, "", true));
return default;
}, 1, "setLook", true)).Put("look", Fn((V _self1, int _argc6269, V _a6271, V _a6272, V _a6273, V _a6274, V[] _rest6270) => {
return ((V)(LOOK_76));
}, 0, "look", true)).Put("lineOf", lineOf_81).Put("HYAW", HYAW_41).Put("SOFT", SOFT_42).Put("DEFS", DEFS_34).Put("mount", mount_95).Put("STATES", STATES_38).Put("REST", REST_35).Put("FIDGETS", FIDGETS_96).Put("FIDK", FIDK_97).Put("PRESS", PRESS_98).Put("REL", REL_99).Put("PRE", PRE_49).Put("EZ", EZ_18).Put("kv", kv_19).Put("r2", r2_14).Put("star4", star4_33).Put("clamp", clamp_13).Put("SM", SM_16).Put("add", Fn((V _self1, int _argc6275, V o_6281, V _a6278, V _a6279, V _a6280, V[] _rest6276) => {
return Object_assign(STATES_38, o_6281);
}, 1, "add", true)).Put("emit", emit_51).Put("tick1", Fn((V _self1, int _argc6282, V I_6288, V _a6285, V _a6286, V _a6287, V[] _rest6283) => {
try {
Call(tick_59, V.Undef, I_6288, Invoke(G("performance"), "now"), ((V)(0.016)));
} catch (System.Exception _ex6289) {
V e_6290 = default;
e_6290 = Caught(_ex6289);
if (!(Truthy(Get(I_6288, "err")))) {
Set(I_6288, "err", ((V)(1D)));
Invoke(G("console"), "error", ((V)("RiveRig")), e_6290);
}
}
return default;
}, 1, "tick1", true)).V);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
