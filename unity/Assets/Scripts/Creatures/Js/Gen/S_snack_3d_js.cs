// snack-3d.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_snack_3d_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("^M15\\.00 41", "");
        static readonly System.Text.RegularExpressions.Regex RX1 = JsRegExp.Compile("translate", "");
        static readonly System.Text.RegularExpressions.Regex RX2 = JsRegExp.Compile("^url", "");
        static readonly System.Text.RegularExpressions.Regex RX3 = JsRegExp.Compile("^(M15\\.00 41|M33\\.90 41|M57\\.00 41|M75\\.90 41|M13\\.5 39\\.5|M15 40\\.6)", "");
        static readonly System.Text.RegularExpressions.Regex RX4 = JsRegExp.Compile("^M12\\.00 88", "");
        static readonly System.Text.RegularExpressions.Regex RX5 = JsRegExp.Compile("^M11\\.50 88", "");
        static readonly System.Text.RegularExpressions.Regex RX6 = JsRegExp.Compile("^M29 \\d+ L29 22", "");
        static readonly System.Text.RegularExpressions.Regex RX7 = JsRegExp.Compile("^M14 41", "");
        static readonly System.Text.RegularExpressions.Regex RX8 = JsRegExp.Compile("^M13 43", "");
        static readonly System.Text.RegularExpressions.Regex RX9 = JsRegExp.Compile("^M9 50 Q9 31|^M14 43\\.6|^M16 46 L20|^M16 56", "");
        static readonly System.Text.RegularExpressions.Regex RX10 = JsRegExp.Compile("^M6\\.5 75\\.5", "");
        static readonly System.Text.RegularExpressions.Regex RX11 = JsRegExp.Compile("^M18 80\\.5", "");
        static readonly System.Text.RegularExpressions.Regex RX12 = JsRegExp.Compile("^url\\(#k", "");
        static readonly System.Text.RegularExpressions.Regex RX13 = JsRegExp.Compile("#p_", "");
        static readonly System.Text.RegularExpressions.Regex RX14 = JsRegExp.Compile("url\\(#p", "");
        static readonly System.Text.RegularExpressions.Regex RX15 = JsRegExp.Compile("url\\(#b", "");
        static readonly System.Text.RegularExpressions.Regex RX16 = JsRegExp.Compile("^M46 74", "");
        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V NS_8 = default;
double TAU_9 = 0;
double D2R_10 = 0;
V r2_11 = default;
V clamp_12 = default;
V SM_13 = default;
V el_14 = default;
V pt_15 = default;
V polyD_16 = default;
V area_17 = default;
V polyW_18 = default;
V circD_19 = default;
V ellD_20 = default;
V runs_21 = default;
V rnd_22 = default;
V subs_23 = default;
V DA_24 = default;
V inh_25 = default;
V decD_26 = default;
V LV_27 = default;
V pal_28 = default;
V pleatSet_29 = default;
V pleatDraw_30 = default;
V SA_31 = default;
V longSet_32 = default;
V longDraw_33 = default;
V resample_34 = default;
V inside_35 = default;
V segDist_36 = default;
V sdist_37 = default;
V halfW_38 = default;
V offset_39 = default;
V pillowRings_40 = default;
V pillowZ_41 = default;
V MODELS_42 = default;
V SN_43 = default;
V sphereHull_44 = default;
V tubeD_45 = default;
V pillowHull_46 = default;
V slabD_47 = default;
V PEf_48 = default;
V tiltW_49 = default;
if (_self1.IsNullish) _self1 = GlobalV;
if (Truthy(Get(G("window"), "SN3D"))) {
return default;
}
NS_8 = ((V)("http://www.w3.org/2000/svg"));
TAU_9 = (System.Math.PI * 2D);
D2R_10 = (System.Math.PI / 180D);
r2_11 = Fn((V _arrowThis57, int _argc50, V v_56, V _a53, V _a54, V _a55, V[] _rest51) => {
return ((V)((Round((ToNum(v_56) * 100D)) / 100D)));
}, 1, "", true);
clamp_12 = Fn((V _arrowThis67, int _argc58, V v_64, V a_65, V b_66, V _a63, V[] _rest59) => {
return (Lt(v_64, a_65) ? a_65 : (Gt(v_64, b_66) ? b_66 : v_64));
}, 3, "", true);
SM_13 = Fn((V _arrowThis75, int _argc68, V t_74, V _a71, V _a72, V _a73, V[] _rest69) => {
t_74 = Call(clamp_12, V.Undef, t_74, ((V)(0D)), ((V)(1D)));
return ((V)(((ToNum(t_74) * ToNum(t_74)) * (3D - (2D * ToNum(t_74))))));
return default;
}, 1, "", true);
el_14 = Fn((V _arrowThis86, int _argc76, V tag_82, V a_83, V par_84, V before_85, V[] _rest77) => {
V e_87 = default;
e_87 = Invoke(G("document"), "createElementNS", NS_8, tag_82);
{
foreach (V _k88 in ForInKeys(a_83)) {
V k_89 = default;
k_89 = _k88;
Invoke(e_87, "setAttribute", k_89, GetK(a_83, k_89));
}
}
if (Truthy(par_84)) {
if (Truthy(before_85)) {
Invoke(par_84, "insertBefore", e_87, before_85);
} else {
Invoke(par_84, "appendChild", e_87);
}
}
return e_87;
return default;
}, 4, "", true);
pt_15 = Fn((V _arrowThis97, int _argc90, V p_96, V _a93, V _a94, V _a95, V[] _rest91) => {
return ((V)(JsStrBuf.Begin().V(Call(r2_11, V.Undef, GetIdx(p_96, 0D))).S(" ").V(Call(r2_11, V.Undef, GetIdx(p_96, 1D))).End()));
}, 1, "", true);
polyD_16 = Fn((V _arrowThis105, int _argc98, V Q_104, V _a101, V _a102, V _a103, V[] _rest99) => {
return ((V)((GtN(Get(Q_104, "length"), 2D) ? JsStrBuf.Begin().S("M").V(Invoke(Invoke(Q_104, "map", pt_15), "join", ((V)("L")))).S("Z").End() : "")));
}, 1, "", true);
area_17 = Fn((V _arrowThis113, int _argc106, V Q_112, V _a109, V _a110, V _a111, V[] _rest107) => {
double a_114 = 0;
a_114 = 0D;
{
double i_115 = 0;
i_115 = 0D;
while (true) {
if (!(Lt(((V)(i_115)), Get(Q_112, "length")))) break;
V p_117 = default;
V q_118 = default;
p_117 = GetIdx(Q_112, i_115);
q_118 = GetIdx(Q_112, ((i_115 + 1D) % ToNum(Get(Q_112, "length"))));
a_114 = (a_114 + ((ToNum(GetIdx(p_117, 0D)) * ToNum(GetIdx(q_118, 1D))) - (ToNum(GetIdx(q_118, 0D)) * ToNum(GetIdx(p_117, 1D)))));
i_115++;
}
}
return ((V)((a_114 / 2D)));
return default;
}, 1, "", true);
polyW_18 = Fn((V _arrowThis126, int _argc119, V Q_125, V _a122, V _a123, V _a124, V[] _rest120) => {
V a_127 = default;
if (LtN(Get(Q_125, "length"), 3D)) {
return ((V)(""));
}
a_127 = Call(area_17, V.Undef, Q_125);
if ((System.Math.Abs(ToNum(a_127)) < 0.02)) {
return ((V)(""));
}
return Call(polyD_16, V.Undef, (GtN(a_127, 0D) ? Invoke(Invoke(Q_125, "slice"), "reverse") : Q_125));
return default;
}, 1, "", true);
circD_19 = Fn((V _arrowThis136, int _argc128, V c_134, V r_135, V _a132, V _a133, V[] _rest129) => {
return ((V)(JsStrBuf.Begin().S("M").V(Call(r2_11, V.Undef, ((V)((ToNum(GetIdx(c_134, 0D)) - ToNum(r_135)))))).S(" ").V(Call(r2_11, V.Undef, GetIdx(c_134, 1D))).S("a").V(Call(r2_11, V.Undef, r_135)).S(" ").V(Call(r2_11, V.Undef, r_135)).S(" 0 1 0 ").V(Call(r2_11, V.Undef, ((V)((2D * ToNum(r_135)))))).S(" 0a").V(Call(r2_11, V.Undef, r_135)).S(" ").V(Call(r2_11, V.Undef, r_135)).S(" 0 1 0 ").V(Call(r2_11, V.Undef, ((V)(((-2D) * ToNum(r_135)))))).S(" 0Z").End()));
}, 2, "", true);
ellD_20 = Fn((V _arrowThis147, int _argc137, V c_143, V rx_144, V ry_145, V a_146, V[] _rest138) => {
V o_148 = default;
double ca_149 = 0;
double sa_150 = 0;
o_148 = Arr();
ca_149 = FdLibm.Cos(ToNum((a_146 is var _t151 && Truthy(_t151) ? _t151 : ((V)(0D)))));
sa_150 = FdLibm.Sin(ToNum((a_146 is var _t152 && Truthy(_t152) ? _t152 : ((V)(0D)))));
{
double k_153 = 0;
k_153 = 0D;
while (true) {
if (!((k_153 < 16D))) break;
double f_155 = 0;
double x_156 = 0;
double y_157 = 0;
f_155 = ((k_153 / 16D) * TAU_9);
x_156 = (ToNum(rx_144) * FdLibm.Cos(f_155));
y_157 = (ToNum(ry_145) * FdLibm.Sin(f_155));
Invoke(o_148, "push", Arr(((V)((ToNum(Add(GetIdx(c_143, 0D), ((V)((x_156 * ca_149))))) - (y_157 * sa_150)))), Add(Add(GetIdx(c_143, 1D), ((V)((x_156 * sa_150)))), ((V)((y_157 * ca_149))))));
k_153++;
}
}
return Call(polyW_18, V.Undef, o_148);
return default;
}, 4, "", true);
runs_21 = Fn((V _arrowThis166, int _argc158, V pts_164, V ok_165, V _a162, V _a163, V[] _rest159) => {
JsStrBuf d_167 = null;
V pen_168 = default;
d_167 = new JsStrBuf("");
pen_168 = (false ? V.True : V.False);
{
double i_169 = 0;
i_169 = 0D;
while (true) {
if (!(Lt(((V)(i_169)), Get(pts_164, "length")))) break;
if (Truthy(GetIdx(ok_165, i_169))) {
d_167.S((Truthy(pen_168) ? "L" : "M")).V(Call(pt_15, V.Undef, GetIdx(pts_164, i_169)));
pen_168 = (true ? V.True : V.False);
} else {
pen_168 = (false ? V.True : V.False);
}
i_169++;
}
}
return ((V)(d_167.Str));
return default;
}, 2, "", true);
rnd_22 = Fn((V _arrowThis178, int _argc171, V s_177, V _a174, V _a175, V _a176, V[] _rest172) => {
double v_179 = 0;
v_179 = (FdLibm.Sin(((ToNum(s_177) * 127.1) + 311.7)) * 43758.5453);
return ((V)((v_179 - System.Math.Floor(v_179))));
return default;
}, 1, "", true);
subs_23 = Fn((V _arrowThis188, int _argc180, V segs_186, V n_187, V _a184, V _a185, V[] _rest181) => {
V @out_189 = default;
V cur_190 = default;
V p_191 = default;
@out_189 = Arr();
cur_190 = V.Null;
p_191 = Arr(((V)(0D)), ((V)(0D)));
{
foreach (V _k192 in new JsIter(segs_186)) {
V g_193 = default;
g_193 = _k192;
V c_194 = default;
c_194 = Get(g_193, "c");
if (SEqS(c_194, "M")) {
cur_190 = Arr(GetIdx(Get(g_193, "p"), 0D));
Invoke(@out_189, "push", cur_190);
p_191 = GetIdx(Get(g_193, "p"), 0D);
} else {
if (SEqS(c_194, "Z")) {
if (Truthy(cur_190)) {
Set(cur_190, "closed", ((V)(1D)));
}
} else {
if (!(Truthy(cur_190))) {
continue;
} else {
if ((SEqS(c_194, "L") || SEqS(c_194, "T"))) {
Invoke(cur_190, "push", GetIdx(Get(g_193, "p"), 0D));
p_191 = GetIdx(Get(g_193, "p"), 0D);
} else {
if ((SEqS(c_194, "Q") || SEqS(c_194, "S"))) {
V a_195 = default;
V b_196 = default;
a_195 = GetIdx(Get(g_193, "p"), 0D);
b_196 = GetIdx(Get(g_193, "p"), 1D);
{
double k_197 = 0;
k_197 = 1D;
while (true) {
if (!(Le(((V)(k_197)), n_187))) break;
double t_199 = 0;
double u_200 = 0;
t_199 = (k_197 / ToNum(n_187));
u_200 = (1D - t_199);
Invoke(cur_190, "push", Arr(((V)(((((u_200 * u_200) * ToNum(GetIdx(p_191, 0D))) + (((2D * u_200) * t_199) * ToNum(GetIdx(a_195, 0D)))) + ((t_199 * t_199) * ToNum(GetIdx(b_196, 0D)))))), ((V)(((((u_200 * u_200) * ToNum(GetIdx(p_191, 1D))) + (((2D * u_200) * t_199) * ToNum(GetIdx(a_195, 1D)))) + ((t_199 * t_199) * ToNum(GetIdx(b_196, 1D))))))));
k_197++;
}
}
p_191 = b_196;
} else {
if (SEqS(c_194, "C")) {
V a_201 = default;
V b_202 = default;
V e_203 = default;
a_201 = GetIdx(Get(g_193, "p"), 0D);
b_202 = GetIdx(Get(g_193, "p"), 1D);
e_203 = GetIdx(Get(g_193, "p"), 2D);
{
double k_204 = 0;
k_204 = 1D;
while (true) {
if (!(Le(((V)(k_204)), n_187))) break;
double t_206 = 0;
double u_207 = 0;
t_206 = (k_204 / ToNum(n_187));
u_207 = (1D - t_206);
Invoke(cur_190, "push", Arr(((V)(((((((u_207 * u_207) * u_207) * ToNum(GetIdx(p_191, 0D))) + ((((3D * u_207) * u_207) * t_206) * ToNum(GetIdx(a_201, 0D)))) + ((((3D * u_207) * t_206) * t_206) * ToNum(GetIdx(b_202, 0D)))) + (((t_206 * t_206) * t_206) * ToNum(GetIdx(e_203, 0D)))))), ((V)(((((((u_207 * u_207) * u_207) * ToNum(GetIdx(p_191, 1D))) + ((((3D * u_207) * u_207) * t_206) * ToNum(GetIdx(a_201, 1D)))) + ((((3D * u_207) * t_206) * t_206) * ToNum(GetIdx(b_202, 1D)))) + (((t_206 * t_206) * t_206) * ToNum(GetIdx(e_203, 1D))))))));
k_204++;
}
}
p_191 = e_203;
}
}
}
}
}
}
}
}
return @out_189;
return default;
}, 2, "", true);
DA_24 = Arr(((V)("fill")), ((V)("stroke")), ((V)("stroke-width")), ((V)("opacity")), ((V)("stroke-linecap")), ((V)("stroke-linejoin")), ((V)("fill-opacity")), ((V)("stroke-opacity")));
inh_25 = Fn((V _arrowThis216, int _argc208, V e_214, V k_215, V _a212, V _a213, V[] _rest209) => {
{
V n_217 = default;
n_217 = e_214;
while (true) {
if (!(Truthy((n_217 is var _t219 && !Truthy(_t219) ? _t219 : Get(n_217, "getAttribute"))))) break;
V v_220 = default;
if (Truthy(((SEqS(Get(n_217, "tagName"), "g") ? V.True : V.False) is var _t221 && !Truthy(_t221) ? _t221 : Invoke(n_217, "hasAttribute", ((V)("filter")))))) {
break;
}
v_220 = Invoke(n_217, "getAttribute", k_215);
if ((!v_220.IsNullish && !(Truthy((((SEqS(k_215, "opacity") && !SEq(n_217, e_214)) ? V.True : V.False) is var _t222 && !Truthy(_t222) ? _t222 : Invoke(n_217, "hasAttribute", ((V)("data-k")))))))) {
return v_220;
}
n_217 = Get(n_217, "parentNode");
}
}
return V.Null;
return default;
}, 2, "", true);
decD_26 = Fn((V _arrowThis231, int _argc223, V o_229, V f_230, V _a227, V _a228, V[] _rest224) => {
return (Invoke(Invoke(Get(o_229, "L"), "map", Fn((V _arrowThis239, int _argc232, V L_238, V _a235, V _a236, V _a237, V[] _rest233) => {
return ((V)((GtN(Get(L_238, "length"), 1D) ? JsStrBuf.Begin().S("M").V(Invoke(Invoke(L_238, "map", Fn((V _arrowThis247, int _argc240, V p_246, V _a243, V _a244, V _a245, V[] _rest241) => {
return Call(pt_15, V.Undef, Call(f_230, V.Undef, GetIdx(p_246, 0D), GetIdx(p_246, 1D)));
}, 1, "", true)), "join", ((V)("L")))).S((Truthy(Get(L_238, "closed")) ? "Z" : "")).End() : "")));
}, 1, "", true)), "join", ((V)(""))) is var _t248 && Truthy(_t248) ? _t248 : ((V)("M0 0")));
}, 2, "", true);
LV_27 = Call(Fn((V _arrowThis256, int _argc249, V v_255, V _a252, V _a253, V _a254, V[] _rest250) => {
double L_257 = 0;
L_257 = Hypot(ToNum(GetIdx(v_255, 0D)), ToNum(GetIdx(v_255, 1D)), ToNum(GetIdx(v_255, 2D)));
return Invoke(v_255, "map", Fn((V _arrowThis265, int _argc258, V c_264, V _a261, V _a262, V _a263, V[] _rest259) => {
return ((V)((ToNum(c_264) / L_257)));
}, 1, "", true));
return default;
}, 1, "", true), V.Undef, Arr(((V)((-0.5))), ((V)((-0.55))), ((V)(0.67))));
pal_28 = Fn((V _arrowThis276, int _argc266, V dark_272, V mid_273, V light_274, V n_275, V[] _rest267) => {
V hx_277 = default;
V A_278 = default;
V M_279 = default;
V L_280 = default;
hx_277 = Fn((V _arrowThis288, int _argc281, V c_287, V _a284, V _a285, V _a286, V[] _rest282) => {
return Invoke(Arr(((V)(1D)), ((V)(3D)), ((V)(5D))), "map", Fn((V _arrowThis296, int _argc289, V i_295, V _a292, V _a293, V _a294, V[] _rest290) => {
return ((V)(ParseInt(Invoke(c_287, "slice", i_295, Add(i_295, ((V)(2D)))), ((V)(16D)))));
}, 1, "", true));
}, 1, "", true);
A_278 = Call(hx_277, V.Undef, dark_272);
M_279 = Call(hx_277, V.Undef, mid_273);
L_280 = Call(hx_277, V.Undef, light_274);
return Array_from(NewObj(1).Put("length", Add(n_275, ((V)(1D)))).V, Fn((V _arrowThis305, int _argc297, V __303, V i_304, V _a301, V _a302, V[] _rest298) => {
double t_306 = 0;
V a_307 = default;
V b_308 = default;
double u_309 = 0;
t_306 = (ToNum(i_304) / ToNum(n_275));
a_307 = ((t_306 < 0.5) ? A_278 : M_279);
b_308 = ((t_306 < 0.5) ? M_279 : L_280);
u_309 = ((t_306 < 0.5) ? (t_306 / 0.5) : ((t_306 - 0.5) / 0.5));
return ((V)(JsStrBuf.Begin().S("#").V(Invoke(Invoke(a_307, "map", Fn((V _arrowThis318, int _argc310, V v_316, V k_317, V _a314, V _a315, V[] _rest311) => {
return Invoke(Invoke(((V)(Round(ToNum(Add(v_316, ((V)(((ToNum(GetK(b_308, k_317)) - ToNum(v_316)) * u_309)))))))), "toString", ((V)(16D))), "padStart", ((V)(2D)), ((V)("0")));
}, 2, "", true)), "join", ((V)("")))).End()));
return default;
}, 2, "", true));
return default;
}, 4, "", true);
pleatSet_29 = Fn((V _arrowThis328, int _argc319, V sp_325, V par_326, V linePar_327, V _a324, V[] _rest320) => {
V F_329 = default;
double H_330 = 0;
F_329 = Arr();
H_330 = (TAU_9 / (2D * ToNum(Get(sp_325, "N"))));
{
double k_331 = 0;
k_331 = 0D;
while (true) {
if (!(Lt(((V)(k_331)), Get(sp_325, "N")))) break;
V fg_333 = default;
double j_334 = 0;
fg_333 = Add((Get(sp_325, "ph") is var _t335 && Truthy(_t335) ? _t335 : ((V)(0D))), ((V)(((k_331 * TAU_9) / ToNum(Get(sp_325, "N"))))));
j_334 = ((ToNum(Call(rnd_22, V.Undef, ((V)((k_331 * 1.7))))) - 0.5) * ToNum((Get(sp_325, "jit") is var _t336 && Truthy(_t336) ? _t336 : ((V)(0D)))));
{
double side_337 = 0;
side_337 = 0D;
while (true) {
if (!((side_337 < 2D))) break;
Invoke(F_329, "push", NewObj(7).Put("side", ((V)(side_337))).Put("fa", (NumTruthy(side_337) ? Add(fg_333, ((V)(H_330))) : fg_333)).Put("fb", (NumTruthy(side_337) ? Add(fg_333, ((V)((2D * H_330)))) : Add(fg_333, ((V)(H_330))))).Put("yge", Add(Get(sp_325, "yG"), ((V)((j_334 * 0.5))))).Put("yre", Add(Get(sp_325, "yR"), ((V)(j_334)))).Put("id", ((V)(JsStrBuf.Begin().S("p").N(k_331).S("_").N(side_337).End()))).Put("e", Call(el_14, V.Undef, ((V)("path")), NewObj(0).V, par_326)).V);
side_337++;
}
}
k_331++;
}
}
return NewObj(6).Put("sp", sp_325).Put("F", F_329).Put("H", ((V)(H_330))).Put("par", par_326).Put("ln", Call(el_14, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", Get(sp_325, "lc")).Put("stroke-width", Get(sp_325, "lw")).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.75))).V, (linePar_327 is var _t339 && Truthy(_t339) ? _t339 : Get(par_326, "parentNode")))).Put("PAL", Call(pal_28, V.Undef, GetIdx(Get(sp_325, "cols"), 0D), GetIdx(Get(sp_325, "cols"), 1D), GetIdx(Get(sp_325, "cols"), 2D), ((V)(24D)))).V;
return default;
}, 3, "", true);
pleatDraw_30 = Fn((V _arrowThis351, int _argc340, V D_346, V PS_347, V proj_348, V Z_349, V[] _rest341) => {
V sp_352 = default;
V F_353 = default;
V H_354 = default;
V rT_355 = default;
V y0_356 = default;
V yR_357 = default;
V tw_358 = default;
V dep_359 = default;
V U_360 = default;
V TW_361 = default;
V P3d_362 = default;
JsStrBuf gl_363 = null;
JsStrBuf lob_364 = null;
V L_365 = default;
V xt_350 = default;
xt_350 = (_argc340 > 4 ? _rest341[0] : V.Undef);
{ V _t366 = PS_347;
if (_t366.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t366));
{ V _t367 = Get(_t366, "sp");
sp_352 = _t367; }
{ V _t368 = Get(_t366, "F");
F_353 = _t368; }
{ V _t369 = Get(_t366, "H");
H_354 = _t369; } }
{ V _t370 = sp_352;
if (_t370.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t370));
{ V _t371 = Get(_t370, "rT");
rT_355 = _t371; }
{ V _t372 = Get(_t370, "y0");
y0_356 = _t372; }
{ V _t373 = Get(_t370, "yR");
yR_357 = _t373; }
{ V _t374 = Get(_t370, "tw");
tw_358 = _t374; }
{ V _t375 = Get(_t370, "dep");
dep_359 = _t375; } }
U_360 = Fn((V _arrowThis383, int _argc376, V y_382, V _a379, V _a380, V _a381, V[] _rest377) => {
return Call(clamp_12, V.Undef, ((V)(((ToNum(y_382) - ToNum(y0_356)) / (ToNum(yR_357) - ToNum(y0_356))))), ((V)(0D)), ((V)(1D)));
}, 1, "", true);
TW_361 = Fn((V _arrowThis391, int _argc384, V u_390, V _a387, V _a388, V _a389, V[] _rest385) => {
return Add(Call(tw_358, V.Undef, u_390), ((V)((ToNum(xt_350) * (1D - ToNum(u_390))))));
}, 1, "", true);
P3d_362 = Fn((V _arrowThis401, int _argc392, V f_398, V y_399, V ridge_400, V _a397, V[] _rest393) => {
V u_402 = default;
V ff_403 = default;
V r_404 = default;
u_402 = Call(U_360, V.Undef, y_399);
ff_403 = Add(f_398, Call(TW_361, V.Undef, u_402));
r_404 = Add(Call(rT_355, V.Undef, y_399), (Truthy(ridge_400) ? Call(dep_359, V.Undef, u_402) : ((V)((-0.25)))));
return Call(proj_348, V.Undef, ((V)((50D + (ToNum(r_404) * FdLibm.Sin(ToNum(ff_403)))))), y_399, ((V)((ToNum(r_404) * FdLibm.Cos(ToNum(ff_403))))));
return default;
}, 3, "", true);
gl_363 = new JsStrBuf("");
lob_364 = new JsStrBuf("");
L_365 = Arr();
Invoke(F_353, "forEach", Fn((V _arrowThis412, int _argc405, V o_411, V _a408, V _a409, V _a410, V[] _rest406) => {
double um_413 = 0;
V ym_414 = default;
V fm_415 = default;
V rm_416 = default;
double be_417 = 0;
V az_418 = default;
double g_419 = 0;
V n_420 = default;
V m_421 = default;
V fz_422 = default;
V p0_423 = default;
V p1_424 = default;
double sx_425 = 0;
double sy_426 = 0;
V ln_427 = default;
double b_428 = 0;
V ra_429 = default;
V rb_430 = default;
V ea_431 = default;
V eb_432 = default;
V A_433 = default;
V B_434 = default;
V lo_435 = default;
V c_436 = default;
um_413 = 0.45;
ym_414 = Add(y0_356, ((V)(((ToNum(yR_357) - ToNum(y0_356)) * um_413))));
fm_415 = Add(((V)((ToNum(Add(Get(o_411, "fa"), Get(o_411, "fb"))) / 2D))), Call(TW_361, V.Undef, ((V)(um_413))));
rm_416 = Call(rT_355, V.Undef, ym_414);
be_417 = (FdLibm.Atan2(ToNum(Add(Call(dep_359, V.Undef, ((V)(um_413))), ((V)(0.25)))), (ToNum(rm_416) * ToNum(H_354))) * (Truthy(Get(o_411, "side")) ? 1D : (-1D)));
az_418 = Add(fm_415, ((V)(be_417)));
g_419 = FdLibm.Atan(((ToNum(Call(rT_355, V.Undef, Add(ym_414, ((V)(1D))))) - ToNum(Call(rT_355, V.Undef, ((V)((ToNum(ym_414) - 1D)))))) / 2D));
n_420 = Arr(((V)((FdLibm.Sin(ToNum(az_418)) * FdLibm.Cos(g_419)))), ((V)((-FdLibm.Sin(g_419)))), ((V)((FdLibm.Cos(ToNum(az_418)) * FdLibm.Cos(g_419)))));
m_421 = Arr(((V)((50D + (ToNum(rm_416) * FdLibm.Sin(ToNum(fm_415)))))), ym_414, ((V)((ToNum(rm_416) * FdLibm.Cos(ToNum(fm_415))))));
fz_422 = Invoke(D_346, "facing", GetIdx(m_421, 0D), GetIdx(m_421, 1D), GetIdx(m_421, 2D), GetIdx(n_420, 0D), GetIdx(n_420, 1D), GetIdx(n_420, 2D));
if (LeN(fz_422, 0.02)) {
if (!SEqN(Get(o_411, "on"), 0D)) {
Set(o_411, "on", ((V)(0D)));
Invoke(Get(o_411, "e"), "setAttribute", ((V)("d")), ((V)("M0 0")));
}
return default;
}
Set(o_411, "on", ((V)(1D)));
p0_423 = Call(proj_348, V.Undef, GetIdx(m_421, 0D), GetIdx(m_421, 1D), GetIdx(m_421, 2D));
p1_424 = Call(proj_348, V.Undef, Add(GetIdx(m_421, 0D), GetIdx(n_420, 0D)), Add(GetIdx(m_421, 1D), GetIdx(n_420, 1D)), Add(GetIdx(m_421, 2D), GetIdx(n_420, 2D)));
sx_425 = ((ToNum(GetIdx(p1_424, 0D)) - ToNum(GetIdx(p0_423, 0D))) / ToNum(Get(D_346, "kS")));
sy_426 = ((ToNum(GetIdx(p1_424, 1D)) - ToNum(GetIdx(p0_423, 1D))) / ToNum(Get(D_346, "kS")));
ln_427 = (((V)(Hypot(sx_425, sy_426, ToNum(fz_422)))) is var _t437 && Truthy(_t437) ? _t437 : ((V)(1D)));
b_428 = ((((sx_425 * ToNum(GetIdx(LV_27, 0D))) + (sy_426 * ToNum(GetIdx(LV_27, 1D)))) + (ToNum(fz_422) * ToNum(GetIdx(LV_27, 2D)))) / ToNum(ln_427));
ra_429 = (SEqN(Get(o_411, "side"), 1D) ? V.True : V.False);
rb_430 = (SEqN(Get(o_411, "side"), 0D) ? V.True : V.False);
ea_431 = (Truthy(ra_429) ? Get(o_411, "yre") : Get(o_411, "yge"));
eb_432 = (Truthy(rb_430) ? Get(o_411, "yre") : Get(o_411, "yge"));
A_433 = Arr();
B_434 = Arr();
lo_435 = Arr();
{
double i_438 = 0;
i_438 = 0D;
while (true) {
if (!((i_438 <= 10D))) break;
Invoke(A_433, "push", Call(P3d_362, V.Undef, Get(o_411, "fa"), Add(y0_356, ((V)((((ToNum(ea_431) - ToNum(y0_356)) * i_438) / 10D)))), ra_429));
Invoke(B_434, "push", Call(P3d_362, V.Undef, Get(o_411, "fb"), Add(y0_356, ((V)((((ToNum(eb_432) - ToNum(y0_356)) * i_438) / 10D)))), rb_430));
i_438++;
}
}
{
double i_440 = 0;
i_440 = 1D;
while (true) {
if (!((i_440 <= 5D))) break;
double t_442 = 0;
V f_443 = default;
double s_444 = 0;
V y_445 = default;
V u_446 = default;
double r_447 = 0;
V ff_448 = default;
t_442 = (i_440 / 6D);
f_443 = Add(Get(o_411, "fa"), ((V)(((ToNum(Get(o_411, "fb")) - ToNum(Get(o_411, "fa"))) * t_442))));
s_444 = FdLibm.Sin((((Truthy(Get(o_411, "side")) ? (1D - t_442) : t_442) * System.Math.PI) / 2D));
y_445 = Add(Get(o_411, "yge"), ((V)(((ToNum(Get(o_411, "yre")) - ToNum(Get(o_411, "yge"))) * s_444))));
u_446 = Call(U_360, V.Undef, y_445);
r_447 = ((ToNum(Call(rT_355, V.Undef, y_445)) - 0.25) + (ToNum(Add(Call(dep_359, V.Undef, u_446), ((V)(0.25)))) * s_444));
ff_448 = Add(f_443, Call(TW_361, V.Undef, u_446));
Invoke(lo_435, "push", Call(proj_348, V.Undef, ((V)((50D + (r_447 * FdLibm.Sin(ToNum(ff_448)))))), y_445, ((V)((r_447 * FdLibm.Cos(ToNum(ff_448)))))));
i_440++;
}
}
Invoke(Get(o_411, "e"), "setAttribute", ((V)("d")), Call(polyD_16, V.Undef, Invoke(A_433, "concat", lo_435, Invoke(Invoke(B_434, "slice"), "reverse"))));
c_436 = GetIdx(Get(PS_347, "PAL"), Round((ToNum(Call(clamp_12, V.Undef, ((V)((0.3 + (0.95 * b_428)))), ((V)(0D)), ((V)(1D)))) * 24D)));
if (!SEq(Get(o_411, "c"), c_436)) {
Set(o_411, "c", c_436);
Invoke(Get(o_411, "e"), "setAttribute", ((V)("fill")), c_436);
}
if (!(Truthy(Get(o_411, "side")))) {
gl_363.S("M").V(Invoke(Invoke(A_433, "map", pt_15), "join", ((V)("L"))));
}
if (Truthy(Get(sp_352, "lobe"))) {
lob_364.S("M").V(Invoke(Invoke(lo_435, "map", Fn((V _arrowThis456, int _argc449, V p_455, V _a452, V _a453, V _a454, V[] _rest450) => {
return Call(pt_15, V.Undef, Arr(GetIdx(p_455, 0D), Add(GetIdx(p_455, 1D), ((V)((0.7 * ToNum(Get(D_346, "kS"))))))));
}, 1, "", true)), "join", ((V)("L"))));
}
Invoke(L_365, "push", NewObj(3).Put("id", Get(o_411, "id")).Put("e", Get(o_411, "e")).Put("z", Call(Z_349, V.Undef, GetIdx(m_421, 0D), GetIdx(m_421, 1D), GetIdx(m_421, 2D))).V);
return default;
}, 1, "", true));
Invoke(L_365, "sort", Fn((V _arrowThis465, int _argc457, V a_463, V b_464, V _a461, V _a462, V[] _rest458) => {
return ((V)((ToNum(Get(a_463, "z")) - ToNum(Get(b_464, "z")))));
}, 2, "", true));
Invoke(SN_43, "order", Get(PS_347, "par"), L_365);
Invoke(Get(PS_347, "ln"), "setAttribute", ((V)("d")), (((V)(gl_363.Str)) is var _t466 && Truthy(_t466) ? _t466 : ((V)("M0 0"))));
return ((V)(lob_364.Str));
return default;
}, 5, "", true);
SA_31 = Fn((V _arrowThis476, int _argc467, V e_473, V k_474, V v_475, V _a472, V[] _rest468) => {
if (!SEq(GetK(e_473, ((V)(JsStrBuf.Begin().S("_").V(k_474).End()))), v_475)) {
SetK(e_473, ((V)(JsStrBuf.Begin().S("_").V(k_474).End())), v_475);
Invoke(e_473, "setAttribute", k_474, v_475);
}
return default;
}, 3, "", true);
longSet_32 = Fn((V _arrowThis487, int _argc477, V S_483, V sp_484, V par_485, V linePar_486, V[] _rest478) => {
V F_488 = default;
double H_489 = 0;
V u_490 = default;
V LG_491 = default;
V lg_492 = default;
F_488 = Arr();
H_489 = (TAU_9 / (2D * ToNum(Get(sp_484, "N"))));
u_490 = Get(S_483, "u");
LG_491 = Fn((V _arrowThis501, int _argc493, V id_499, V a_500, V _a497, V _a498, V[] _rest494) => {
return Call(el_14, V.Undef, ((V)("linearGradient")), Object_assign(NewObj(6).Put("id", Add(id_499, u_490)).Put("gradientUnits", ((V)("userSpaceOnUse"))).Put("x1", ((V)(50D))).Put("y1", Get(sp_484, "y0")).Put("x2", ((V)(50D))).Put("y2", Get(sp_484, "y1")).V, (a_500 is var _t502 && Truthy(_t502) ? _t502 : NewObj(0).V)), Get(S_483, "df"));
}, 2, "", true);
{
double k_503 = 0;
k_503 = 0D;
while (true) {
if (!(Lt(((V)(k_503)), Get(sp_484, "N")))) break;
V fg_505 = default;
fg_505 = Add((Get(sp_484, "ph") is var _t506 && Truthy(_t506) ? _t506 : ((V)(0D))), ((V)(((k_503 * TAU_9) / ToNum(Get(sp_484, "N"))))));
{
double side_507 = 0;
side_507 = 0D;
while (true) {
if (!((side_507 < 2D))) break;
V g_509 = default;
g_509 = Call(LG_491, V.Undef, ((V)(JsStrBuf.Begin().S("lp").N(k_503).S("_").N(side_507).End())));
Invoke(F_488, "push", NewObj(7).Put("side", ((V)(side_507))).Put("fa", (NumTruthy(side_507) ? Add(fg_505, ((V)(H_489))) : fg_505)).Put("fb", (NumTruthy(side_507) ? Add(fg_505, ((V)((2D * H_489)))) : Add(fg_505, ((V)(H_489))))).Put("id", ((V)(JsStrBuf.Begin().S("p").N(k_503).S("_").N(side_507).End()))).Put("g", g_509).Put("st", Invoke(Get(sp_484, "SY"), "map", Fn((V _arrowThis516, int _argc510, V _a512, V _a513, V _a514, V _a515, V[] _rest511) => {
return Call(el_14, V.Undef, ((V)("stop")), NewObj(2).Put("offset", ((V)(0D))).Put("stop-color", GetIdx(Get(sp_484, "cols"), 1D)).V, g_509);
}, 0, "", true))).Put("e", Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)(JsStrBuf.Begin().S("url(#lp").N(k_503).S("_").N(side_507).V(u_490).S(")").End()))).V, par_485)).V);
side_507++;
}
}
k_503++;
}
}
lg_492 = Call(LG_491, V.Undef, ((V)("lpl")));
Invoke(Get(sp_484, "LS"), "forEach", Fn((V _arrowThis528, int _argc517, V _a519, V _a520, V _a521, V _a522, V[] _rest518) => {
V o_525 = default;
V op_527 = default;
{ V _t523 = ListOf(_a519);
{ V _t524 = GetIdx(_t523, 0D);
o_525 = _t524; }
{ V _t526 = GetIdx(_t523, 1D);
op_527 = _t526; }
}
return Call(el_14, V.Undef, ((V)("stop")), NewObj(3).Put("offset", o_525).Put("stop-color", Get(sp_484, "lc")).Put("stop-opacity", op_527).V, lg_492);
}, 1, "", true));
return NewObj(8).Put("sp", sp_484).Put("F", F_488).Put("H", ((V)(H_489))).Put("par", par_485).Put("lg", lg_492).Put("YS", Array_from(NewObj(1).Put("length", Add(Get(sp_484, "NY"), ((V)(1D)))).V, Fn((V _arrowThis537, int _argc529, V __535, V i_536, V _a533, V _a534, V[] _rest530) => {
return Add(Get(sp_484, "y0"), ((V)((((ToNum(Get(sp_484, "y1")) - ToNum(Get(sp_484, "y0"))) * ToNum(i_536)) / ToNum(Get(sp_484, "NY"))))));
}, 2, "", true))).Put("ln", Call(el_14, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)(JsStrBuf.Begin().S("url(#lpl").V(u_490).S(")").End()))).Put("stroke-width", Get(sp_484, "lw")).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V, (linePar_486 is var _t538 && Truthy(_t538) ? _t538 : Get(par_485, "parentNode")))).Put("PAL", Call(pal_28, V.Undef, GetIdx(Get(sp_484, "cols"), 0D), GetIdx(Get(sp_484, "cols"), 1D), GetIdx(Get(sp_484, "cols"), 2D), ((V)(24D)))).V;
return default;
}, 4, "", true);
longDraw_33 = Fn((V _arrowThis550, int _argc539, V D_545, V PS_546, V proj_547, V Z_548, V[] _rest540) => {
V sp_551 = default;
V F_552 = default;
V H_553 = default;
V YS_554 = default;
V rT_555 = default;
V dep_556 = default;
V SY_557 = default;
V r3_558 = default;
V gT_559 = default;
V X3_560 = default;
JsStrBuf gl_561 = null;
V L_562 = default;
V t0_563 = default;
V t1_564 = default;
V TW_549 = default;
TW_549 = (_argc539 > 4 ? _rest540[0] : V.Undef);
{ V _t565 = PS_546;
if (_t565.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t565));
{ V _t566 = Get(_t565, "sp");
sp_551 = _t566; }
{ V _t567 = Get(_t565, "F");
F_552 = _t567; }
{ V _t568 = Get(_t565, "H");
H_553 = _t568; }
{ V _t569 = Get(_t565, "YS");
YS_554 = _t569; } }
{ V _t570 = sp_551;
if (_t570.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t570));
{ V _t571 = Get(_t570, "rT");
rT_555 = _t571; }
{ V _t572 = Get(_t570, "dep");
dep_556 = _t572; }
{ V _t573 = Get(_t570, "SY");
SY_557 = _t573; } }
r3_558 = Fn((V _arrowThis581, int _argc574, V v_580, V _a577, V _a578, V _a579, V[] _rest575) => {
return ((V)((Round((ToNum(v_580) * 1000D)) / 1000D)));
}, 1, "", true);
gT_559 = Fn((V _arrowThis589, int _argc582, V y_588, V _a585, V _a586, V _a587, V[] _rest583) => {
return ((V)(FdLibm.Atan(((ToNum(Call(rT_555, V.Undef, Add(y_588, ((V)(1D))))) - ToNum(Call(rT_555, V.Undef, ((V)((ToNum(y_588) - 1D)))))) / 2D))));
}, 1, "", true);
X3_560 = Fn((V _arrowThis599, int _argc590, V f_596, V y_597, V ridge_598, V _a595, V[] _rest591) => {
V ff_600 = default;
V r_601 = default;
ff_600 = Add(f_596, Call(TW_549, V.Undef, y_597));
r_601 = Add(Call(rT_555, V.Undef, y_597), (Truthy(ridge_598) ? Call(dep_556, V.Undef, y_597) : ((V)((-0.25)))));
return Arr(((V)((50D + (ToNum(r_601) * FdLibm.Sin(ToNum(ff_600)))))), y_597, ((V)((ToNum(r_601) * FdLibm.Cos(ToNum(ff_600))))));
return default;
}, 3, "", true);
gl_561 = new JsStrBuf("");
L_562 = Arr();
Invoke(F_552, "forEach", Fn((V _arrowThis609, int _argc602, V o_608, V _a605, V _a606, V _a607, V[] _rest603) => {
V vis_610 = default;
V zs_611 = default;
V C_612 = default;
V ra_613 = default;
V A3_614 = default;
V A_615 = default;
V B_616 = default;
V a_617 = default;
V bq_618 = default;
double vx_619 = 0;
double vy_620 = 0;
V vv_621 = default;
double of_622 = 0;
vis_610 = (false ? V.True : V.False);
zs_611 = ((V)(0D));
C_612 = Invoke(SY_557, "map", Fn((V _arrowThis630, int _argc623, V y_629, V _a626, V _a627, V _a628, V[] _rest624) => {
V fm_631 = default;
V rm_632 = default;
double be_633 = 0;
V az_634 = default;
V g_635 = default;
V n_636 = default;
V m_637 = default;
V fz_638 = default;
V p0_639 = default;
V p1_640 = default;
double sx_641 = 0;
double sy_642 = 0;
V ln_643 = default;
double b_644 = 0;
fm_631 = Add(((V)((ToNum(Add(Get(o_608, "fa"), Get(o_608, "fb"))) / 2D))), Call(TW_549, V.Undef, y_629));
rm_632 = Call(rT_555, V.Undef, y_629);
be_633 = (FdLibm.Atan2(ToNum(Add(Call(dep_556, V.Undef, y_629), ((V)(0.25)))), (ToNum(rm_632) * ToNum(H_553))) * (Truthy(Get(o_608, "side")) ? 1D : (-1D)));
az_634 = Add(fm_631, ((V)(be_633)));
g_635 = Call(gT_559, V.Undef, y_629);
n_636 = Arr(((V)((FdLibm.Sin(ToNum(az_634)) * FdLibm.Cos(ToNum(g_635))))), ((V)((-FdLibm.Sin(ToNum(g_635))))), ((V)((FdLibm.Cos(ToNum(az_634)) * FdLibm.Cos(ToNum(g_635))))));
m_637 = Arr(((V)((50D + (ToNum(rm_632) * FdLibm.Sin(ToNum(fm_631)))))), y_629, ((V)((ToNum(rm_632) * FdLibm.Cos(ToNum(fm_631))))));
fz_638 = Invoke(D_545, "facing", GetIdx(m_637, 0D), GetIdx(m_637, 1D), GetIdx(m_637, 2D), GetIdx(n_636, 0D), GetIdx(n_636, 1D), GetIdx(n_636, 2D));
if (GtN(fz_638, 0.02)) {
vis_610 = (true ? V.True : V.False);
}
zs_611 = Add(zs_611, Call(Z_548, V.Undef, GetIdx(m_637, 0D), GetIdx(m_637, 1D), GetIdx(m_637, 2D)));
p0_639 = Call(proj_547, V.Undef, GetIdx(m_637, 0D), GetIdx(m_637, 1D), GetIdx(m_637, 2D));
p1_640 = Call(proj_547, V.Undef, Add(GetIdx(m_637, 0D), GetIdx(n_636, 0D)), Add(GetIdx(m_637, 1D), GetIdx(n_636, 1D)), Add(GetIdx(m_637, 2D), GetIdx(n_636, 2D)));
sx_641 = ((ToNum(GetIdx(p1_640, 0D)) - ToNum(GetIdx(p0_639, 0D))) / ToNum(Get(D_545, "kS")));
sy_642 = ((ToNum(GetIdx(p1_640, 1D)) - ToNum(GetIdx(p0_639, 1D))) / ToNum(Get(D_545, "kS")));
ln_643 = (((V)(Hypot(sx_641, sy_642, ToNum(fz_638)))) is var _t645 && Truthy(_t645) ? _t645 : ((V)(1D)));
b_644 = ((((sx_641 * ToNum(GetIdx(LV_27, 0D))) + (sy_642 * ToNum(GetIdx(LV_27, 1D)))) + (ToNum(fz_638) * ToNum(GetIdx(LV_27, 2D)))) / ToNum(ln_643));
return NewObj(2).Put("p", p0_639).Put("c", GetIdx(Get(PS_546, "PAL"), Round((ToNum(Call(clamp_12, V.Undef, ((V)((0.3 + (0.95 * b_644)))), ((V)(0D)), ((V)(1D)))) * 24D)))).V;
return default;
}, 1, "", true));
if (!(Truthy(vis_610))) {
if (!SEqN(Get(o_608, "on"), 0D)) {
Set(o_608, "on", ((V)(0D)));
Invoke(Get(o_608, "e"), "setAttribute", ((V)("d")), ((V)("M0 0")));
}
return default;
}
Set(o_608, "on", ((V)(1D)));
ra_613 = (SEqN(Get(o_608, "side"), 1D) ? V.True : V.False);
A3_614 = Invoke(YS_554, "map", Fn((V _arrowThis653, int _argc646, V y_652, V _a649, V _a650, V _a651, V[] _rest647) => {
return Call(X3_560, V.Undef, Get(o_608, "fa"), y_652, ra_613);
}, 1, "", true));
A_615 = Invoke(A3_614, "map", Fn((V _arrowThis661, int _argc654, V p_660, V _a657, V _a658, V _a659, V[] _rest655) => {
return Call(proj_547, V.Undef, GetIdx(p_660, 0D), GetIdx(p_660, 1D), GetIdx(p_660, 2D));
}, 1, "", true));
B_616 = Invoke(YS_554, "map", Fn((V _arrowThis669, int _argc662, V y_668, V _a665, V _a666, V _a667, V[] _rest663) => {
V p_670 = default;
p_670 = Call(X3_560, V.Undef, Get(o_608, "fb"), y_668, (!(Truthy(ra_613)) ? V.True : V.False));
return Call(proj_547, V.Undef, GetIdx(p_670, 0D), GetIdx(p_670, 1D), GetIdx(p_670, 2D));
return default;
}, 1, "", true));
Invoke(Get(o_608, "e"), "setAttribute", ((V)("d")), Call(polyD_16, V.Undef, Invoke(A_615, "concat", Invoke(B_616, "reverse"))));
a_617 = Get(GetIdx(C_612, 0D), "p");
bq_618 = Get(GetIdx(C_612, (ToNum(Get(C_612, "length")) - 1D)), "p");
vx_619 = (ToNum(GetIdx(bq_618, 0D)) - ToNum(GetIdx(a_617, 0D)));
vy_620 = (ToNum(GetIdx(bq_618, 1D)) - ToNum(GetIdx(a_617, 1D)));
vv_621 = (((V)(((vx_619 * vx_619) + (vy_620 * vy_620)))) is var _t671 && Truthy(_t671) ? _t671 : ((V)(1D)));
Call(SA_31, V.Undef, Get(o_608, "g"), ((V)("x1")), Call(r3_558, V.Undef, GetIdx(a_617, 0D)));
Call(SA_31, V.Undef, Get(o_608, "g"), ((V)("y1")), Call(r3_558, V.Undef, GetIdx(a_617, 1D)));
Call(SA_31, V.Undef, Get(o_608, "g"), ((V)("x2")), Call(r3_558, V.Undef, GetIdx(bq_618, 0D)));
Call(SA_31, V.Undef, Get(o_608, "g"), ((V)("y2")), Call(r3_558, V.Undef, GetIdx(bq_618, 1D)));
of_622 = 0D;
Invoke(C_612, "forEach", Fn((V _arrowThis680, int _argc672, V s_678, V i_679, V _a676, V _a677, V[] _rest673) => {
of_622 = Max(of_622, ToNum(Call(clamp_12, V.Undef, ((V)(((((ToNum(GetIdx(Get(s_678, "p"), 0D)) - ToNum(GetIdx(a_617, 0D))) * vx_619) + ((ToNum(GetIdx(Get(s_678, "p"), 1D)) - ToNum(GetIdx(a_617, 1D))) * vy_620)) / ToNum(vv_621)))), ((V)(0D)), ((V)(1D)))));
Call(SA_31, V.Undef, GetK(Get(o_608, "st"), i_679), ((V)("offset")), Call(r3_558, V.Undef, ((V)(of_622))));
Call(SA_31, V.Undef, GetK(Get(o_608, "st"), i_679), ((V)("stop-color")), Get(s_678, "c"));
return default;
}, 2, "", true));
if (!(Truthy(Get(o_608, "side")))) {
gl_561.V(Call(runs_21, V.Undef, A_615, Invoke(A3_614, "map", Fn((V _arrowThis689, int _argc681, V p_687, V i_688, V _a685, V _a686, V[] _rest682) => {
V ff_690 = default;
V g_691 = default;
ff_690 = Add(Get(o_608, "fa"), Call(TW_549, V.Undef, GetK(YS_554, i_688)));
g_691 = Call(gT_559, V.Undef, GetK(YS_554, i_688));
return (GtN(Invoke(D_545, "facing", GetIdx(p_687, 0D), GetIdx(p_687, 1D), GetIdx(p_687, 2D), ((V)((FdLibm.Sin(ToNum(ff_690)) * FdLibm.Cos(ToNum(g_691))))), ((V)((-FdLibm.Sin(ToNum(g_691))))), ((V)((FdLibm.Cos(ToNum(ff_690)) * FdLibm.Cos(ToNum(g_691)))))), 0.05) ? V.True : V.False);
return default;
}, 2, "", true))));
}
Invoke(L_562, "push", NewObj(3).Put("id", Get(o_608, "id")).Put("e", Get(o_608, "e")).Put("z", ((V)((ToNum(zs_611) / ToNum(Get(SY_557, "length")))))).V);
return default;
}, 1, "", true));
Invoke(L_562, "sort", Fn((V _arrowThis700, int _argc692, V a_698, V b_699, V _a696, V _a697, V[] _rest693) => {
return ((V)((ToNum(Get(a_698, "z")) - ToNum(Get(b_699, "z")))));
}, 2, "", true));
Invoke(SN_43, "order", Get(PS_546, "par"), L_562);
Invoke(Get(PS_546, "ln"), "setAttribute", ((V)("d")), (((V)(gl_561.Str)) is var _t701 && Truthy(_t701) ? _t701 : ((V)("M0 0"))));
t0_563 = Call(proj_547, V.Undef, ((V)(50D)), Get(sp_551, "y0"), ((V)(0D)));
t1_564 = Call(proj_547, V.Undef, ((V)(50D)), Get(sp_551, "y1"), ((V)(0D)));
Call(SA_31, V.Undef, Get(PS_546, "lg"), ((V)("x1")), Call(r3_558, V.Undef, GetIdx(t0_563, 0D)));
Call(SA_31, V.Undef, Get(PS_546, "lg"), ((V)("y1")), Call(r3_558, V.Undef, GetIdx(t0_563, 1D)));
Call(SA_31, V.Undef, Get(PS_546, "lg"), ((V)("x2")), Call(r3_558, V.Undef, GetIdx(t1_564, 0D)));
Call(SA_31, V.Undef, Get(PS_546, "lg"), ((V)("y2")), Call(r3_558, V.Undef, GetIdx(t1_564, 1D)));
return default;
}, 5, "", true);
resample_34 = Fn((V _arrowThis710, int _argc702, V Q_708, V n_709, V _a706, V _a707, V[] _rest703) => {
V L_711 = default;
V tot_712 = default;
V @out_713 = default;
double j_714 = 0;
L_711 = Arr(((V)(0D)));
{
double i_715 = 0;
i_715 = 1D;
while (true) {
if (!(Le(((V)(i_715)), Get(Q_708, "length")))) break;
V a_717 = default;
V b_718 = default;
a_717 = GetIdx(Q_708, (i_715 - 1D));
b_718 = GetIdx(Q_708, (i_715 % ToNum(Get(Q_708, "length"))));
Invoke(L_711, "push", Add(GetIdx(L_711, (i_715 - 1D)), ((V)(Hypot((ToNum(GetIdx(b_718, 0D)) - ToNum(GetIdx(a_717, 0D))), (ToNum(GetIdx(b_718, 1D)) - ToNum(GetIdx(a_717, 1D))))))));
i_715++;
}
}
tot_712 = GetIdx(L_711, (ToNum(Get(L_711, "length")) - 1D));
@out_713 = Arr();
j_714 = 0D;
{
double k_719 = 0;
k_719 = 0D;
while (true) {
if (!(Lt(((V)(k_719)), n_709))) break;
double s_721 = 0;
V a_722 = default;
V b_723 = default;
double u_724 = 0;
s_721 = ((ToNum(tot_712) * k_719) / ToNum(n_709));
while (LtN(GetIdx(L_711, (j_714 + 1D)), s_721)) {
j_714++;
}
a_722 = GetIdx(Q_708, j_714);
b_723 = GetIdx(Q_708, ((j_714 + 1D) % ToNum(Get(Q_708, "length"))));
u_724 = ((s_721 - ToNum(GetIdx(L_711, j_714))) / ToNum((((V)((ToNum(GetIdx(L_711, (j_714 + 1D))) - ToNum(GetIdx(L_711, j_714))))) is var _t725 && Truthy(_t725) ? _t725 : ((V)(1D)))));
Invoke(@out_713, "push", Arr(Add(GetIdx(a_722, 0D), ((V)(((ToNum(GetIdx(b_723, 0D)) - ToNum(GetIdx(a_722, 0D))) * u_724)))), Add(GetIdx(a_722, 1D), ((V)(((ToNum(GetIdx(b_723, 1D)) - ToNum(GetIdx(a_722, 1D))) * u_724))))));
k_719++;
}
}
return @out_713;
return default;
}, 2, "", true);
inside_35 = Fn((V _arrowThis735, int _argc726, V O_732, V x_733, V y_734, V _a731, V[] _rest727) => {
V c_736 = default;
c_736 = (false ? V.True : V.False);
{
double i_737 = 0;
double j_738 = 0;
i_737 = 0D;
j_738 = (ToNum(Get(O_732, "length")) - 1D);
while (true) {
if (!(Lt(((V)(i_737)), Get(O_732, "length")))) break;
V a_740 = default;
V b_741 = default;
a_740 = GetIdx(O_732, i_737);
b_741 = GetIdx(O_732, j_738);
if ((!SEq((Gt(GetIdx(a_740, 1D), y_734) ? V.True : V.False), (Gt(GetIdx(b_741, 1D), y_734) ? V.True : V.False)) && Lt(x_733, Add(((V)((((ToNum(GetIdx(b_741, 0D)) - ToNum(GetIdx(a_740, 0D))) * (ToNum(y_734) - ToNum(GetIdx(a_740, 1D)))) / (ToNum(GetIdx(b_741, 1D)) - ToNum(GetIdx(a_740, 1D)))))), GetIdx(a_740, 0D))))) {
c_736 = (!(Truthy(c_736)) ? V.True : V.False);
}
j_738 = i_737++;
}
}
return c_736;
return default;
}, 3, "", true);
segDist_36 = Fn((V _arrowThis751, int _argc742, V O_748, V x_749, V y_750, V _a747, V[] _rest743) => {
double m_752 = 0;
m_752 = 1000000000D;
{
double i_753 = 0;
i_753 = 0D;
while (true) {
if (!(Lt(((V)(i_753)), Get(O_748, "length")))) break;
V a_755 = default;
V b_756 = default;
double vx_757 = 0;
double vy_758 = 0;
V L_759 = default;
V t_760 = default;
double dx_761 = 0;
double dy_762 = 0;
double d_763 = 0;
a_755 = GetIdx(O_748, i_753);
b_756 = GetIdx(O_748, ((i_753 + 1D) % ToNum(Get(O_748, "length"))));
vx_757 = (ToNum(GetIdx(b_756, 0D)) - ToNum(GetIdx(a_755, 0D)));
vy_758 = (ToNum(GetIdx(b_756, 1D)) - ToNum(GetIdx(a_755, 1D)));
L_759 = (((V)(((vx_757 * vx_757) + (vy_758 * vy_758)))) is var _t764 && Truthy(_t764) ? _t764 : ((V)(1D)));
t_760 = Call(clamp_12, V.Undef, ((V)(((((ToNum(x_749) - ToNum(GetIdx(a_755, 0D))) * vx_757) + ((ToNum(y_750) - ToNum(GetIdx(a_755, 1D))) * vy_758)) / ToNum(L_759)))), ((V)(0D)), ((V)(1D)));
dx_761 = (ToNum(Add(GetIdx(a_755, 0D), ((V)((vx_757 * ToNum(t_760)))))) - ToNum(x_749));
dy_762 = (ToNum(Add(GetIdx(a_755, 1D), ((V)((vy_758 * ToNum(t_760)))))) - ToNum(y_750));
d_763 = ((dx_761 * dx_761) + (dy_762 * dy_762));
if ((d_763 < m_752)) {
m_752 = d_763;
}
i_753++;
}
}
return ((V)(System.Math.Sqrt(m_752)));
return default;
}, 3, "", true);
sdist_37 = Fn((V _arrowThis774, int _argc765, V O_771, V x_772, V y_773, V _a770, V[] _rest766) => {
return ((V)(((Truthy(Call(inside_35, V.Undef, O_771, x_772, y_773)) ? 1D : (-1D)) * ToNum(Call(segDist_36, V.Undef, O_771, x_772, y_773)))));
}, 3, "", true);
halfW_38 = Fn((V _arrowThis783, int _argc775, V O_781, V y_782, V _a779, V _a780, V[] _rest776) => {
V lo_784 = default;
V hi_785 = default;
lo_784 = ((V)(1000000000D));
hi_785 = ((V)((-1000000000D)));
{
double i_786 = 0;
i_786 = 0D;
while (true) {
if (!(Lt(((V)(i_786)), Get(O_781, "length")))) break;
V a_788 = default;
V b_789 = default;
a_788 = GetIdx(O_781, i_786);
b_789 = GetIdx(O_781, ((i_786 + 1D) % ToNum(Get(O_781, "length"))));
if (((((ToNum(GetIdx(a_788, 1D)) - ToNum(y_782)) * (ToNum(GetIdx(b_789, 1D)) - ToNum(y_782))) <= 0D) && !SEq(GetIdx(a_788, 1D), GetIdx(b_789, 1D)))) {
V x_790 = default;
x_790 = Add(GetIdx(a_788, 0D), ((V)((((ToNum(GetIdx(b_789, 0D)) - ToNum(GetIdx(a_788, 0D))) * (ToNum(y_782) - ToNum(GetIdx(a_788, 1D)))) / (ToNum(GetIdx(b_789, 1D)) - ToNum(GetIdx(a_788, 1D)))))));
if (Lt(x_790, lo_784)) {
lo_784 = x_790;
}
if (Gt(x_790, hi_785)) {
hi_785 = x_790;
}
}
i_786++;
}
}
return ((V)((Lt(hi_785, lo_784) ? 0D : ((ToNum(hi_785) - ToNum(lo_784)) / 2D))));
return default;
}, 2, "", true);
offset_39 = Fn((V _arrowThis799, int _argc791, V O_797, V b_798, V _a795, V _a796, V[] _rest792) => {
V n_800 = default;
if (!(Truthy(b_798))) {
return O_797;
}
n_800 = Get(O_797, "length");
return Invoke(O_797, "map", Fn((V _arrowThis809, int _argc801, V p_807, V i_808, V _a805, V _a806, V[] _rest802) => {
V a_810 = default;
V c_811 = default;
double tx_812 = 0;
double ty_813 = 0;
V L_814 = default;
double nx_815 = 0;
double ny_816 = 0;
a_810 = GetIdx(O_797, (ToNum(Add(((V)((ToNum(i_808) - 1D))), n_800)) % ToNum(n_800)));
c_811 = GetIdx(O_797, (ToNum(Add(i_808, ((V)(1D)))) % ToNum(n_800)));
tx_812 = (ToNum(GetIdx(c_811, 0D)) - ToNum(GetIdx(a_810, 0D)));
ty_813 = (ToNum(GetIdx(c_811, 1D)) - ToNum(GetIdx(a_810, 1D)));
L_814 = (((V)(Hypot(tx_812, ty_813))) is var _t817 && Truthy(_t817) ? _t817 : ((V)(1D)));
nx_815 = ((-ty_813) / ToNum(L_814));
ny_816 = (tx_812 / ToNum(L_814));
if (!(Truthy(Call(inside_35, V.Undef, O_797, Add(GetIdx(p_807, 0D), ((V)((nx_815 * 0.4)))), Add(GetIdx(p_807, 1D), ((V)((ny_816 * 0.4)))))))) {
nx_815 = (-nx_815);
ny_816 = (-ny_816);
}
return Arr(Add(GetIdx(p_807, 0D), ((V)((nx_815 * ToNum(b_798))))), Add(GetIdx(p_807, 1D), ((V)((ny_816 * ToNum(b_798))))));
return default;
}, 2, "", true));
return default;
}, 2, "", true);
pillowRings_40 = Fn((V _arrowThis828, int _argc818, V O_824, V T_825, V b_826, V K_827, V[] _rest819) => {
V R_829 = default;
R_829 = Arr();
{
double k_830 = 0;
k_830 = 0D;
while (true) {
if (!(Le(((V)(k_830)), K_827))) break;
double th_832 = 0;
th_832 = (((k_830 / ToNum(K_827)) * System.Math.PI) / 2D);
Invoke(R_829, "push", NewObj(2).Put("z", ((V)((ToNum(T_825) * FdLibm.Sin(th_832))))).Put("Q", Call(offset_39, V.Undef, O_824, ((V)((ToNum(b_826) * (1D - FdLibm.Cos(th_832))))))).V);
k_830++;
}
}
return R_829;
return default;
}, 4, "", true);
pillowZ_41 = Fn((V _arrowThis842, int _argc833, V O_839, V T_840, V b_841, V _a838, V[] _rest834) => {
return Fn((V _arrowThis851, int _argc843, V x_849, V y_850, V _a847, V _a848, V[] _rest844) => {
V d_852 = default;
double u_853 = 0;
d_852 = Call(sdist_37, V.Undef, O_839, x_849, y_850);
if (LeN(d_852, 0D)) {
return ((V)(0D));
}
u_853 = Min(1D, (ToNum(d_852) / ToNum(b_841)));
return ((V)((ToNum(T_840) * System.Math.Sqrt((1D - ((1D - u_853) * (1D - u_853)))))));
return default;
}, 2, "", true);
}, 3, "", true);
MODELS_42 = NewObj(0).V;
SN_43 = Set(G("window"), "SN3D", NewObj(2).Put("MODELS", MODELS_42).Put("h", NewObj(25).Put("el", el_14).Put("pt", pt_15).Put("polyD", polyD_16).Put("polyW", polyW_18).Put("circD", circD_19).Put("ellD", ellD_20).Put("runs", runs_21).Put("resample", resample_34).Put("inside", inside_35).Put("sdist", sdist_37).Put("halfW", halfW_38).Put("offset", offset_39).Put("pillowRings", pillowRings_40).Put("pillowZ", pillowZ_41).Put("clamp", clamp_12).Put("SM", SM_13).Put("r2", r2_11).Put("rnd", rnd_22).Put("subs", subs_23).Put("decD", decD_26).Put("pal", pal_28).Put("pleatSet", pleatSet_29).Put("pleatDraw", pleatDraw_30).Put("longSet", longSet_32).Put("longDraw", longDraw_33).V).V);
Set(SN_43, "setup", Fn((V _arrowThis861, int _argc854, V c_860, V _a857, V _a858, V _a859, V[] _rest855) => {
try {
Invoke(SN_43, "setup0", c_860);
} catch (System.Exception _ex862) {
V e_863 = default;
e_863 = Caught(_ex862);
Invoke(Set(G("window"), "__SNERR", (Get(G("window"), "__SNERR") is var _t865 && Truthy(_t865) ? _t865 : Arr())), "push", ((V)(JsStrBuf.Begin().S("setup ").V(Get(c_860, "key")).S(" ").V((e_863 is var _t864 && !Truthy(_t864) ? _t864 : Get(e_863, "message"))).End())));
Invoke(G("console"), "error", ((V)("SN3D setup")), Get(c_860, "key"), (e_863 is var _t866 && !Truthy(_t866) ? _t866 : Get(e_863, "stack")));
}
return default;
}, 1, "", true));
Set(SN_43, "setup0", Fn((V _arrowThis874, int _argc867, V c_873, V _a870, V _a871, V _a872, V[] _rest868) => {
V I_875 = default;
V key_876 = default;
V art_877 = default;
V items_878 = default;
V headA_879 = default;
V H_880 = default;
V M_881 = default;
V sk_882 = default;
V par_883 = default;
V df_884 = default;
V dOf_885 = default;
V fOf_886 = default;
V sOf_887 = default;
V S_888 = default;
V B_889 = default;
{ V _t890 = c_873;
if (_t890.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t890));
{ V _t891 = Get(_t890, "I");
I_875 = _t891; }
{ V _t892 = Get(_t890, "key");
key_876 = _t892; }
{ V _t893 = Get(_t890, "art");
art_877 = _t893; }
{ V _t894 = Get(_t890, "items");
items_878 = _t894; }
{ V _t895 = Get(_t890, "headA");
headA_879 = _t895; }
{ V _t896 = Get(_t890, "H");
H_880 = _t896; } }
M_881 = GetK(MODELS_42, key_876);
if ((!(Truthy(M_881)) || !(Truthy(headA_879)))) {
return default;
}
sk_882 = Get(headA_879, "q");
par_883 = Get(Get(sk_882, "e"), "parentNode");
df_884 = (Invoke(art_877, "querySelector", ((V)("defs"))) is var _t897 && Truthy(_t897) ? _t897 : Invoke(art_877, "insertBefore", Call(el_14, V.Undef, ((V)("defs")), NewObj(0).V), Get(art_877, "firstChild")));
dOf_885 = Fn((V _arrowThis905, int _argc898, V q_904, V _a901, V _a902, V _a903, V[] _rest899) => {
return (Invoke(Get(q_904, "e"), "getAttribute", ((V)("d"))) is var _t906 && Truthy(_t906) ? _t906 : ((V)("")));
}, 1, "", true);
fOf_886 = Fn((V _arrowThis914, int _argc907, V q_913, V _a910, V _a911, V _a912, V[] _rest908) => {
return ((Invoke(Get(q_913, "e"), "getAttribute", ((V)("fill"))) is var _t917 && Truthy(_t917) ? _t917 : ((Get(Get(q_913, "e"), "parentNode") is var _t915 && !Truthy(_t915) ? _t915 : Get(Get(Get(q_913, "e"), "parentNode"), "getAttribute")) is var _t916 && !Truthy(_t916) ? _t916 : Invoke(Get(Get(q_913, "e"), "parentNode"), "getAttribute", ((V)("fill"))))) is var _t918 && Truthy(_t918) ? _t918 : ((V)("")));
}, 1, "", true);
sOf_887 = Fn((V _arrowThis926, int _argc919, V q_925, V _a922, V _a923, V _a924, V[] _rest920) => {
return ((Invoke(Get(q_925, "e"), "getAttribute", ((V)("stroke"))) is var _t929 && Truthy(_t929) ? _t929 : ((Get(Get(q_925, "e"), "parentNode") is var _t927 && !Truthy(_t927) ? _t927 : Get(Get(Get(q_925, "e"), "parentNode"), "getAttribute")) is var _t928 && !Truthy(_t928) ? _t928 : Invoke(Get(Get(q_925, "e"), "parentNode"), "getAttribute", ((V)("stroke"))))) is var _t930 && Truthy(_t930) ? _t930 : ((V)("")));
}, 1, "", true);
S_888 = NewObj(25).Put("I", I_875).Put("key", key_876).Put("art", art_877).Put("items", items_878).Put("headA", headA_879).Put("H", H_880).Put("sk", sk_882).Put("par", par_883).Put("df", df_884).Put("u", Get(I_875, "u")).Put("HX", Get(headA_879, "cx")).Put("HY", Get(headA_879, "cy")).Put("d", dOf_885).Put("f", fOf_886).Put("s", sOf_887).Put("el", el_14).Put("hide", Fn((V _arrowThis938, int _argc931, V pred_937, V _a934, V _a935, V _a936, V[] _rest932) => {
return Invoke(items_878, "filter", Fn((V _arrowThis946, int _argc939, V q_945, V _a942, V _a943, V _a944, V[] _rest940) => {
if (((SEq(q_945, sk_882) || SEqS(Get(q_945, "role"), "xHide")) || !(Truthy(Call(pred_937, V.Undef, q_945))))) {
return (false ? V.True : V.False);
}
Set(q_945, "role", ((V)("xHide")));
Set(Get(Get(q_945, "e"), "style"), "display", ((V)("none")));
return (true ? V.True : V.False);
return default;
}, 1, "", true));
}, 1, "hide", true)).Put("path", Fn((V _arrowThis956, int _argc947, V a_953, V p_954, V before_955, V _a952, V[] _rest948) => {
return Call(el_14, V.Undef, ((V)("path")), a_953, (p_954 is var _t957 && Truthy(_t957) ? _t957 : Get(S_888, "LG")), before_955);
}, 3, "path", true)).Put("g", Fn((V _arrowThis966, int _argc958, V p_964, V before_965, V _a962, V _a963, V[] _rest959) => {
return Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, (p_964 is var _t967 && Truthy(_t967) ? _t967 : Get(S_888, "LG")), before_965);
}, 2, "g", true)).Put("outline", Fn((V _arrowThis976, int _argc968, V q_974, V n_975, V _a972, V _a973, V[] _rest969) => {
return Call(resample_34, V.Undef, Invoke(Invoke(H_880, "flat", Get(q_974, "segs"), ((V)(8D))), "filter", Fn((V _arrowThis986, int _argc977, V p_983, V i_984, V A_985, V _a982, V[] _rest978) => {
return ((!(Truthy(i_984)) || (Hypot((ToNum(GetIdx(p_983, 0D)) - ToNum(GetIdx(GetIdx(A_985, (ToNum(i_984) - 1D)), 0D))), (ToNum(GetIdx(p_983, 1D)) - ToNum(GetIdx(GetIdx(A_985, (ToNum(i_984) - 1D)), 1D)))) > 0.01)) ? V.True : V.False);
}, 3, "", true)), (n_975 is var _t987 && Truthy(_t987) ? _t987 : ((V)(64D))));
}, 2, "outline", true)).Put("rgrad", Fn((V _arrowThis997, int _argc988, V id_994, V st_995, V o_996, V _a993, V[] _rest989) => {
V g_998 = default;
g_998 = Call(el_14, V.Undef, ((V)("radialGradient")), Object_assign(NewObj(4).Put("id", Add(id_994, Get(I_875, "u"))).Put("cx", ((V)("38%"))).Put("cy", ((V)("30%"))).Put("r", ((V)("75%"))).V, (o_996 is var _t999 && Truthy(_t999) ? _t999 : NewObj(0).V)), df_884);
Invoke(st_995, "forEach", Fn((V _arrowThis1013, int _argc1000, V _a1002, V _a1003, V _a1004, V _a1005, V[] _rest1001) => {
V of_1008 = default;
V cl_1010 = default;
V op_1012 = default;
{ V _t1006 = ListOf(_a1002);
{ V _t1007 = GetIdx(_t1006, 0D);
of_1008 = _t1007; }
{ V _t1009 = GetIdx(_t1006, 1D);
cl_1010 = _t1009; }
{ V _t1011 = GetIdx(_t1006, 2D);
op_1012 = _t1011; }
}
return Call(el_14, V.Undef, ((V)("stop")), (!op_1012.IsNullish ? NewObj(3).Put("offset", of_1008).Put("stop-color", cl_1010).Put("stop-opacity", op_1012).V : NewObj(2).Put("offset", of_1008).Put("stop-color", cl_1010).V), g_998);
}, 1, "", true));
return ((V)(JsStrBuf.Begin().S("url(#").V(id_994).V(Get(I_875, "u")).S(")").End()));
return default;
}, 3, "rgrad", true)).Put("lgrad", Fn((V _arrowThis1023, int _argc1014, V id_1020, V st_1021, V o_1022, V _a1019, V[] _rest1015) => {
V g_1024 = default;
g_1024 = Call(el_14, V.Undef, ((V)("linearGradient")), Object_assign(NewObj(5).Put("id", Add(id_1020, Get(I_875, "u"))).Put("x1", ((V)(0D))).Put("y1", ((V)(0D))).Put("x2", ((V)(1D))).Put("y2", ((V)(0D))).V, (o_1022 is var _t1025 && Truthy(_t1025) ? _t1025 : NewObj(0).V)), df_884);
Invoke(st_1021, "forEach", Fn((V _arrowThis1039, int _argc1026, V _a1028, V _a1029, V _a1030, V _a1031, V[] _rest1027) => {
V of_1034 = default;
V cl_1036 = default;
V op_1038 = default;
{ V _t1032 = ListOf(_a1028);
{ V _t1033 = GetIdx(_t1032, 0D);
of_1034 = _t1033; }
{ V _t1035 = GetIdx(_t1032, 1D);
cl_1036 = _t1035; }
{ V _t1037 = GetIdx(_t1032, 2D);
op_1038 = _t1037; }
}
return Call(el_14, V.Undef, ((V)("stop")), (!op_1038.IsNullish ? NewObj(3).Put("offset", of_1034).Put("stop-color", cl_1036).Put("stop-opacity", op_1038).V : NewObj(2).Put("offset", of_1034).Put("stop-color", cl_1036).V), g_1024);
}, 1, "", true));
return ((V)(JsStrBuf.Begin().S("url(#").V(id_1020).V(Get(I_875, "u")).S(")").End()));
return default;
}, 3, "lgrad", true)).Put("clip", Fn((V _arrowThis1047, int _argc1040, V id_1046, V _a1043, V _a1044, V _a1045, V[] _rest1041) => {
V cp_1048 = default;
cp_1048 = Call(el_14, V.Undef, ((V)("clipPath")), NewObj(1).Put("id", Add(id_1046, Get(I_875, "u"))).V, df_884);
return NewObj(2).Put("p", Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("d", ((V)("M0 0"))).V, cp_1048)).Put("url", ((V)(JsStrBuf.Begin().S("url(#").V(id_1046).V(Get(I_875, "u")).S(")").End()))).V;
return default;
}, 1, "clip", true)).Put("dk", Fn((V _arrowThis1057, int _argc1049, V q_1055, V k_1056, V _a1053, V _a1054, V[] _rest1050) => {
return (!(!(Truthy((Get(Get(q_1055, "e"), "closest") is var _t1058 && !Truthy(_t1058) ? _t1058 : Invoke(Get(q_1055, "e"), "closest", ((V)((Truthy(k_1056) ? JsStrBuf.Begin().S("[data-k=\"").V(k_1056).S("\"]").End() : "[data-k]")))))))) ? V.True : V.False);
}, 2, "dk", true)).Put("decals", Fn((V _arrowThis1067, int _argc1059, V pred_1065, V par_1066, V _a1063, V _a1064, V[] _rest1060) => {
return Invoke(Invoke(S_888, "hide", pred_1065), "map", Fn((V _arrowThis1075, int _argc1068, V q_1074, V _a1071, V _a1072, V _a1073, V[] _rest1069) => {
V a_1076 = default;
a_1076 = NewObj(0).V;
Invoke(DA_24, "forEach", Fn((V _arrowThis1084, int _argc1077, V k_1083, V _a1080, V _a1081, V _a1082, V[] _rest1078) => {
V v_1085 = default;
v_1085 = Call(inh_25, V.Undef, Get(q_1074, "e"), k_1083);
if (!v_1085.IsNullish) {
SetK(a_1076, k_1083, v_1085);
}
return default;
}, 1, "", true));
if (Get(a_1076, "fill").IsNullish) {
Set(a_1076, "fill", ((V)("#000")));
}
return NewObj(3).Put("e", Call(el_14, V.Undef, ((V)("path")), a_1076, (par_1066 is var _t1086 && Truthy(_t1086) ? _t1086 : Get(S_888, "LG")))).Put("L", Call(subs_23, V.Undef, Get(q_1074, "segs"), ((V)(6D)))).Put("q", q_1074).V;
return default;
}, 1, "", true));
}, 2, "decals", true)).V;
Set(S_888, "gB", Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, par_883, Get(sk_882, "e")));
Set(S_888, "LG", Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, par_883, Get(Get(sk_882, "e"), "nextSibling")));
B_889 = Set(I_875, "bk", Object_assign(NewObj(10).Put("kind", key_876).Put("sn", ((V)(1D))).Put("bodyG", Get(c_873, "bodyG")).Put("d", ((V)(""))).Put("ya", ((V)(30D))).Put("yb", ((V)(90D))).Put("rx", ((V)(30D))).Put("rT", Fn((V _arrowThis1093, int _argc1087, V _a1089, V _a1090, V _a1091, V _a1092, V[] _rest1088) => {
return ((V)(20D));
}, 0, "rT", true)).Put("S", S_888).Put("M", M_881).V, (Invoke(M_881, "setup", S_888) is var _t1094 && Truthy(_t1094) ? _t1094 : NewObj(0).V)));
if (Truthy(Get(B_889, "zE"))) {
Set(I_875, "zE", Get(B_889, "zE"));
}
return default;
}, 1, "", true));
Set(SN_43, "draw", Fn((V _arrowThis1102, int _argc1095, V c_1101, V _a1098, V _a1099, V _a1100, V[] _rest1096) => {
try {
Invoke(SN_43, "draw0", c_1101);
} catch (System.Exception _ex1103) {
V e_1104 = default;
e_1104 = Caught(_ex1103);
if (!(Truthy(Get(SN_43, "err")))) {
Set(SN_43, "err", ((V)(1D)));
Invoke(Set(G("window"), "__SNERR", (Get(G("window"), "__SNERR") is var _t1107 && Truthy(_t1107) ? _t1107 : Arr())), "push", ((V)(JsStrBuf.Begin().S("draw ").V((Get(Get(c_1101, "I"), "bk") is var _t1105 && !Truthy(_t1105) ? _t1105 : Get(Get(Get(c_1101, "I"), "bk"), "kind"))).S(" ").V((e_1104 is var _t1106 && !Truthy(_t1106) ? _t1106 : Get(e_1104, "message"))).End())));
Invoke(G("console"), "error", ((V)("SN3D draw")), (Get(Get(c_1101, "I"), "bk") is var _t1108 && !Truthy(_t1108) ? _t1108 : Get(Get(Get(c_1101, "I"), "bk"), "kind")), (e_1104 is var _t1109 && !Truthy(_t1109) ? _t1109 : Get(e_1104, "stack")));
}
}
return default;
}, 1, "", true));
Set(SN_43, "draw0", Fn((V _arrowThis1117, int _argc1110, V c_1116, V _a1113, V _a1114, V _a1115, V[] _rest1111) => {
V I_1118 = default;
V P_1119 = default;
V now_1120 = default;
V sph_1121 = default;
V sphZ_1122 = default;
V glob_1123 = default;
V H_1124 = default;
V HY_1125 = default;
V B_1126 = default;
V M_1127 = default;
V dt_1128 = default;
double ts_1129 = 0;
double tg_1130 = 0;
double ly_1131 = 0;
V Q_1132 = default;
V g0_1133 = default;
V g1_1134 = default;
V D_1135 = default;
{ V _t1136 = c_1116;
if (_t1136.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1136));
{ V _t1137 = Get(_t1136, "I");
I_1118 = _t1137; }
{ V _t1138 = Get(_t1136, "P");
P_1119 = _t1138; }
{ V _t1139 = Get(_t1136, "now");
now_1120 = _t1139; }
{ V _t1140 = Get(_t1136, "sph");
sph_1121 = _t1140; }
{ V _t1141 = Get(_t1136, "sphZ");
sphZ_1122 = _t1141; }
{ V _t1142 = Get(_t1136, "glob");
glob_1123 = _t1142; }
{ V _t1143 = Get(_t1136, "H");
H_1124 = _t1143; }
{ V _t1144 = Get(_t1136, "HY");
HY_1125 = _t1144; } }
B_1126 = Get(I_1118, "bk");
M_1127 = (B_1126 is var _t1145 && !Truthy(_t1145) ? _t1145 : Get(B_1126, "M"));
if (!(Truthy(M_1127))) {
return default;
}
dt_1128 = (Get(c_1116, "dtS") is var _t1146 && Truthy(_t1146) ? _t1146 : ((V)(0.016)));
ts_1129 = (ToNum(now_1120) / 1000D);
tg_1130 = ((((ToNum(Get(P_1119, "x")) * 1.4) + (ToNum(Get(P_1119, "tilt")) * 0.5)) + (ToNum(Get(P_1119, "lean")) * 1.5)) + (ToNum(Get(P_1119, "turn")) * 12D));
ly_1131 = (ToNum(Get(P_1119, "lift")) - (ToNum(Get(c_1116, "sq")) * 8D));
Q_1132 = (Get(B_1126, "__q") is var _t1147 && Truthy(_t1147) ? _t1147 : Set(B_1126, "__q", NewObj(4).Put("p", ((V)(tg_1130))).Put("v", ((V)(0D))).Put("l", ((V)(ly_1131))).Put("lv", ((V)(0D))).V));
OpSet(Q_1132, "v", 0, ((V)(((((tg_1130 - ToNum(Get(Q_1132, "p"))) * 120D) - (ToNum(Get(Q_1132, "v")) * 7D)) * ToNum(dt_1128)))));
OpSet(Q_1132, "p", 0, ((V)((ToNum(Get(Q_1132, "v")) * ToNum(dt_1128)))));
OpSet(Q_1132, "lv", 0, ((V)(((((ly_1131 - ToNum(Get(Q_1132, "l"))) * 140D) - (ToNum(Get(Q_1132, "lv")) * 7.5)) * ToNum(dt_1128)))));
OpSet(Q_1132, "l", 0, ((V)((ToNum(Get(Q_1132, "lv")) * ToNum(dt_1128)))));
g0_1133 = Call(glob_1123, V.Undef, ((V)(40D)), HY_1125);
g1_1134 = Call(glob_1123, V.Undef, ((V)(60D)), HY_1125);
D_1135 = Object_assign(NewObj(0).V, c_1116, NewObj(12).Put("B", B_1126).Put("ts", ((V)(ts_1129))).Put("P3", sph_1121).Put("Z3", sphZ_1122).Put("kS", ((V)((Hypot((ToNum(GetIdx(g1_1134, 0D)) - ToNum(GetIdx(g0_1133, 0D))), (ToNum(GetIdx(g1_1134, 1D)) - ToNum(GetIdx(g0_1133, 1D)))) / 20D)))).Put("ox", Call(clamp_12, V.Undef, ((V)((ToNum(Get(Q_1132, "p")) - tg_1130))), ((V)((-12D))), ((V)(12D)))).Put("oy", Call(clamp_12, V.Undef, ((V)((ToNum(Get(Q_1132, "l")) - ly_1131))), ((V)((-6D))), ((V)(6D)))).Put("front", ((V)((ToNum(Get(c_1116, "cyh")) * ToNum(Get(c_1116, "cp")))))).Put("bv", Fn((V _arrowThis1155, int _argc1148, V k_1154, V _a1151, V _a1152, V _a1153, V[] _rest1149) => {
double v_1156 = 0;
v_1156 = ToNum(GetK(P_1119, k_1154));
return ((V)(((v_1156 == v_1156) ? v_1156 : 0D)));
return default;
}, 1, "bv", true)).Put("hull", Fn((V _arrowThis1164, int _argc1157, V pts_1163, V _a1160, V _a1161, V _a1162, V[] _rest1158) => {
return Call(polyD_16, V.Undef, Invoke(H_1124, "hull", pts_1163));
}, 1, "hull", true)).Put("set", Fn((V _arrowThis1174, int _argc1165, V e_1171, V a_1172, V v_1173, V _a1170, V[] _rest1166) => {
return Invoke(e_1171, "setAttribute", a_1172, v_1173);
}, 3, "set", true)).Put("facing", Fn((V _arrowThis1187, int _argc1175, V x_1181, V y_1182, V z_1183, V nx_1184, V[] _rest1176) => {
V ny_1185 = default;
V nz_1186 = default;
ny_1185 = (_argc1175 > 4 ? _rest1176[0] : V.Undef);
nz_1186 = (_argc1175 > 5 ? _rest1176[1] : V.Undef);
return ((V)((ToNum(Call(sphZ_1122, V.Undef, Add(x_1181, nx_1184), Add(y_1182, ny_1185), Add(z_1183, nz_1186))) - ToNum(Call(sphZ_1122, V.Undef, x_1181, y_1182, z_1183)))));
}, 6, "facing", true)).V);
Invoke(M_1127, "draw", B_1126, D_1135);
return default;
}, 1, "", true));
Set(SN_43, "order", Fn((V _arrowThis1197, int _argc1188, V g_1194, V list_1195, V key_1196, V _a1193, V[] _rest1189) => {
V k_1198 = default;
k_1198 = Invoke(Invoke(list_1195, "map", Fn((V _arrowThis1206, int _argc1199, V o_1205, V _a1202, V _a1203, V _a1204, V[] _rest1200) => {
return Get(o_1205, "id");
}, 1, "", true)), "join", ((V)(",")));
if (SEq(Get(g_1194, "__ok"), k_1198)) {
return default;
}
Set(g_1194, "__ok", k_1198);
Invoke(list_1195, "forEach", Fn((V _arrowThis1214, int _argc1207, V o_1213, V _a1210, V _a1211, V _a1212, V[] _rest1208) => {
return Invoke(g_1194, "appendChild", Get(o_1213, "e"));
}, 1, "", true));
return default;
}, 3, "", true));
sphereHull_44 = Fn((V _arrowThis1225, int _argc1215, V D_1221, V c_1222, V r_1223, V n_1224, V[] _rest1216) => {
V o_1226 = default;
o_1226 = Arr();
n_1224 = (n_1224 is var _t1227 && Truthy(_t1227) ? _t1227 : ((V)(8D)));
{
double i_1228 = 0;
i_1228 = 0D;
while (true) {
if (!(Le(((V)(i_1228)), n_1224))) break;
double th_1230 = 0;
double cr_1231 = 0;
V y_1232 = default;
th_1230 = (((-System.Math.PI) / 2D) + ((System.Math.PI * i_1228) / ToNum(n_1224)));
cr_1231 = FdLibm.Cos(th_1230);
y_1232 = Add(GetIdx(c_1222, 1D), ((V)((ToNum(r_1223) * FdLibm.Sin(th_1230)))));
if ((cr_1231 < 0.01)) {
Invoke(o_1226, "push", Invoke(D_1221, "P3", GetIdx(c_1222, 0D), y_1232, GetIdx(c_1222, 2D)));
goto _cont1229;
}
{
double k_1233 = 0;
k_1233 = 0D;
while (true) {
if (!((k_1233 < (2D * ToNum(n_1224))))) break;
double f_1235 = 0;
f_1235 = ((k_1233 / (2D * ToNum(n_1224))) * TAU_9);
Invoke(o_1226, "push", Invoke(D_1221, "P3", Add(GetIdx(c_1222, 0D), ((V)(((ToNum(r_1223) * cr_1231) * FdLibm.Sin(f_1235))))), y_1232, Add(GetIdx(c_1222, 2D), ((V)(((ToNum(r_1223) * cr_1231) * FdLibm.Cos(f_1235)))))));
k_1233++;
}
}
_cont1229: ;
i_1228++;
}
}
return o_1226;
return default;
}, 4, "", true);
Set(Get(SN_43, "h"), "sphereHull", sphereHull_44);
tubeD_45 = Fn((V _arrowThis1245, int _argc1236, V D_1242, V C_1243, V R_1244, V _a1241, V[] _rest1237) => {
JsStrBuf d_1246 = null;
V SP_1247 = default;
d_1246 = new JsStrBuf("");
SP_1247 = Invoke(C_1243, "map", Fn((V _arrowThis1256, int _argc1248, V c_1254, V i_1255, V _a1252, V _a1253, V[] _rest1249) => {
return Call(sphereHull_44, V.Undef, D_1242, c_1254, GetK(R_1244, i_1255), ((V)(5D)));
}, 2, "", true));
{
double i_1257 = 0;
i_1257 = 0D;
while (true) {
if (!((i_1257 < (ToNum(Get(C_1243, "length")) - 1D)))) break;
d_1246.V(Call(polyW_18, V.Undef, Invoke(Get(D_1242, "H"), "hull", Invoke(GetIdx(SP_1247, i_1257), "concat", GetIdx(SP_1247, (i_1257 + 1D))))));
i_1257++;
}
}
return ((V)(d_1246.Str));
return default;
}, 3, "", true);
Set(Get(SN_43, "h"), "tubeD", tubeD_45);
pillowHull_46 = Fn((V _arrowThis1270, int _argc1259, V D_1265, V rings_1266, V z0_1267, V sg_1268, V[] _rest1260) => {
V o_1271 = default;
V extra_1269 = default;
extra_1269 = (_argc1259 > 4 ? _rest1260[0] : V.Undef);
o_1271 = (Truthy(extra_1269) ? Invoke(extra_1269, "slice") : Arr());
Invoke(rings_1266, "forEach", Fn((V _arrowThis1279, int _argc1272, V R_1278, V _a1275, V _a1276, V _a1277, V[] _rest1273) => {
return Invoke(Get(R_1278, "Q"), "forEach", Fn((V _arrowThis1287, int _argc1280, V p_1286, V _a1283, V _a1284, V _a1285, V[] _rest1281) => {
return Invoke(o_1271, "push", Invoke(D_1265, "P3", GetIdx(p_1286, 0D), GetIdx(p_1286, 1D), Add(z0_1267, ((V)((ToNum(sg_1268) * ToNum(Get(R_1278, "z"))))))));
}, 1, "", true));
}, 1, "", true));
return o_1271;
return default;
}, 5, "", true);
Set(Get(SN_43, "h"), "pillowHull", pillowHull_46);
Set(Get(SN_43, "h"), "frontArc", Fn((V _arrowThis1298, int _argc1288, V D_1294, V r_1295, V y_1296, V n_1297, V[] _rest1289) => {
V v_1299 = default;
V i0_1300 = default;
V o_1301 = default;
v_1299 = Arr();
{
double k_1302 = 0;
k_1302 = 0D;
while (true) {
if (!(Lt(((V)(k_1302)), n_1297))) break;
double f_1304 = 0;
f_1304 = ((k_1302 / ToNum(n_1297)) * TAU_9);
Invoke(v_1299, "push", (GtN(Invoke(D_1294, "facing", ((V)((50D + (ToNum(r_1295) * FdLibm.Sin(f_1304))))), y_1296, ((V)((ToNum(r_1295) * FdLibm.Cos(f_1304)))), ((V)(FdLibm.Sin(f_1304))), ((V)(0D)), ((V)(FdLibm.Cos(f_1304)))), (-0.002)) ? V.True : V.False));
k_1302++;
}
}
i0_1300 = Invoke(v_1299, "findIndex", Fn((V _arrowThis1313, int _argc1305, V o_1311, V k_1312, V _a1309, V _a1310, V[] _rest1306) => {
return (o_1311 is var _t1314 && !Truthy(_t1314) ? _t1314 : (!(Truthy(GetIdx(v_1299, (ToNum(Add(((V)((ToNum(k_1312) - 1D))), n_1297)) % ToNum(n_1297))))) ? V.True : V.False));
}, 2, "", true));
if (LtN(i0_1300, 0D)) {
i0_1300 = ((V)(0D));
}
o_1301 = Arr();
{
double j_1315 = 0;
j_1315 = 0D;
while (true) {
if (!(Le(((V)(j_1315)), n_1297))) break;
double k_1317 = 0;
k_1317 = (ToNum(Add(i0_1300, ((V)(j_1315)))) % ToNum(n_1297));
if (!(Truthy(GetIdx(v_1299, k_1317)))) {
break;
}
Invoke(o_1301, "push", ((V)(((ToNum(Add(i0_1300, ((V)(j_1315)))) / ToNum(n_1297)) * TAU_9))));
j_1315++;
}
}
return o_1301;
return default;
}, 4, "", true));
Set(MODELS_42, "corny", NewObj(2).Put("setup", Fn((V _self1318, int _argc1319, V S_1325, V _a1322, V _a1323, V _a1324, V[] _rest1320) => {
V sk_1326 = default;
V O_1327 = default;
V rT_1328 = default;
double EL_1329 = 0;
V red_1330 = default;
V RF_1331 = default;
V pk_1332 = default;
V PF_1333 = default;
V popF_1334 = default;
V sh_1335 = default;
V st_1336 = default;
V bed_1337 = default;
V cl_1338 = default;
V KG_1339 = default;
V rim_1340 = default;
V rimL_1341 = default;
V K_1342 = default;
V add_1343 = default;
if (_self1318.IsNullish) _self1318 = GlobalV;
{ V _t1344 = S_1325;
if (_t1344.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1344));
{ V _t1345 = Get(_t1344, "sk");
sk_1326 = _t1345; } }
O_1327 = Invoke(S_1325, "outline", sk_1326, ((V)(64D)));
rT_1328 = Fn((V _arrowThis1353, int _argc1346, V y_1352, V _a1349, V _a1350, V _a1351, V[] _rest1347) => {
return Call(halfW_38, V.Undef, O_1327, Call(clamp_12, V.Undef, y_1352, ((V)(41.2)), ((V)(86.8))));
}, 1, "", true);
EL_1329 = 0.11;
red_1330 = Get((Invoke(Get(S_1325, "items"), "find", Fn((V _arrowThis1361, int _argc1354, V q_1360, V _a1357, V _a1358, V _a1359, V[] _rest1355) => {
return (Get(q_1360, "inBody") is var _t1362 && !Truthy(_t1362) ? _t1362 : Invoke(NewRegExp(RX0, "^M15\\.00 41", ""), "test", Invoke(S_1325, "d", q_1360)));
}, 1, "", true)) is var _t1363 && Truthy(_t1363) ? _t1363 : NewObj(0).V), "e");
RF_1331 = (Truthy(red_1330) ? Invoke(red_1330, "getAttribute", ((V)("fill"))) : ((V)("#f0464e")));
pk_1332 = Invoke(S_1325, "hide", Fn((V _arrowThis1371, int _argc1364, V q_1370, V _a1367, V _a1368, V _a1369, V[] _rest1365) => {
return (((Get(q_1370, "inBody") is var _t1372 && !Truthy(_t1372) ? _t1372 : Get(Get(q_1370, "e"), "parentNode")) is var _t1373 && !Truthy(_t1373) ? _t1373 : Get(Get(Get(q_1370, "e"), "parentNode"), "getAttribute")) is var _t1375 && !Truthy(_t1375) ? _t1375 : Invoke(NewRegExp(RX1, "translate", ""), "test", (Invoke(Get(Get(q_1370, "e"), "parentNode"), "getAttribute", ((V)("transform"))) is var _t1374 && Truthy(_t1374) ? _t1374 : ((V)("")))));
}, 1, "", true));
PF_1333 = Get((Invoke(pk_1332, "find", Fn((V _arrowThis1383, int _argc1376, V q_1382, V _a1379, V _a1380, V _a1381, V[] _rest1377) => {
return Invoke(NewRegExp(RX2, "^url", ""), "test", Invoke(S_1325, "f", q_1382));
}, 1, "", true)) is var _t1384 && Truthy(_t1384) ? _t1384 : NewObj(0).V), "e");
popF_1334 = (Truthy(PF_1333) ? Invoke(PF_1333, "getAttribute", ((V)("fill"))) : ((V)("#fff2c8")));
Invoke(S_1325, "hide", Fn((V _arrowThis1392, int _argc1385, V q_1391, V _a1388, V _a1389, V _a1390, V[] _rest1386) => {
return (Get(q_1391, "inBody") is var _t1393 && !Truthy(_t1393) ? _t1393 : Invoke(NewRegExp(RX3, "^(M15\\.00 41|M33\\.90 41|M57\\.00 41|M75\\.90 41|M13\\.5 39\\.5|M15 40\\.6)", ""), "test", Invoke(S_1325, "d", q_1391)));
}, 1, "", true));
sh_1335 = Invoke(S_1325, "path", NewObj(1).Put("fill", Invoke(S_1325, "lgrad", ((V)("cnsh")), Arr(Arr(((V)(0D)), ((V)("#7a2a22")), ((V)(0.34))), Arr(((V)(0.14)), ((V)("#7a2a22")), ((V)(0.08))), Arr(((V)(0.3)), ((V)("#ffffff")), ((V)(0.32))), Arr(((V)(0.46)), ((V)("#ffffff")), ((V)(0D))), Arr(((V)(0.76)), ((V)("#5a1a14")), ((V)(0.05))), Arr(((V)(1D)), ((V)("#5a1a14")), ((V)(0.4)))))).V);
st_1336 = Invoke(S_1325, "path", NewObj(1).Put("fill", RF_1331).V);
bed_1337 = Invoke(S_1325, "path", NewObj(1).Put("fill", Invoke(S_1325, "rgrad", ((V)("cnbd")), Arr(Arr(((V)(0D)), ((V)("#fff3c4"))), Arr(((V)(0.7)), ((V)("#f4d27a"))), Arr(((V)(1D)), ((V)("#d9a848")))), NewObj(3).Put("cx", ((V)("50%"))).Put("cy", ((V)("40%"))).Put("r", ((V)("60%"))).V)).V);
cl_1338 = Invoke(S_1325, "clip", ((V)("cnc")));
KG_1339 = Invoke(S_1325, "g");
Invoke(KG_1339, "setAttribute", ((V)("clip-path")), Get(cl_1338, "url"));
rim_1340 = Invoke(S_1325, "path", NewObj(1).Put("fill", RF_1331).V);
rimL_1341 = Invoke(S_1325, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffd0d0"))).Put("stroke-width", ((V)(0.9))).Put("opacity", ((V)(0.8))).Put("stroke-linecap", ((V)("round"))).V);
K_1342 = Arr();
add_1343 = Fn((V _arrowThis1405, int _argc1394, V rho_1400, V n_1401, V y_1402, V s_1403, V[] _rest1395) => {
V ph_1404 = default;
ph_1404 = (_argc1394 > 4 ? _rest1395[0] : V.Undef);
{
double i_1406 = 0;
i_1406 = 0D;
while (true) {
if (!(Lt(((V)(i_1406)), n_1401))) break;
V a_1408 = default;
V id_1409 = default;
a_1408 = Add(ph_1404, ((V)(((i_1406 / ToNum(n_1401)) * TAU_9))));
id_1409 = Get(K_1342, "length");
Invoke(K_1342, "push", NewObj(7).Put("id", id_1409).Put("x", ((V)((50D + (ToNum(rho_1400) * FdLibm.Sin(ToNum(a_1408))))))).Put("z", ((V)((ToNum(rho_1400) * FdLibm.Cos(ToNum(a_1408)))))).Put("y", Add(y_1402, ((V)(((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(id_1409) * 2.3) + 1D))))) - 0.5) * 2.8))))).Put("s", ((V)((ToNum(s_1403) * (0.9 + (ToNum(Call(rnd_22, V.Undef, id_1409)) * 0.25)))))).Put("hk", ((V)((6D + (ToNum(Call(rnd_22, V.Undef, Add(id_1409, ((V)(9D))))) * 10D))))).Put("B", Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(4D))), "map", Fn((V _arrowThis1417, int _argc1410, V j_1416, V _a1413, V _a1414, V _a1415, V[] _rest1411) => {
double aa_1418 = 0;
double dd_1419 = 0;
aa_1418 = ((ToNum(j_1416) * 1.257) + (ToNum(Call(rnd_22, V.Undef, Add(((V)((ToNum(id_1409) * 7D))), j_1416))) * 0.6));
dd_1419 = (1.7 + (ToNum(Call(rnd_22, V.Undef, Add(((V)((ToNum(id_1409) * 5D))), j_1416))) * 0.9));
return Arr(((V)((FdLibm.Cos(aa_1418) * dd_1419))), ((V)((FdLibm.Sin(aa_1418) * dd_1419))), ((V)((2.5 + (ToNum(Call(rnd_22, V.Undef, Add(((V)((ToNum(id_1409) * 3D))), j_1416))) * 1D)))));
return default;
}, 1, "", true))).V);
i_1406++;
}
}
return default;
}, 5, "", true);
Invoke(Arr(Arr(((V)(0D)), ((V)(1D)), ((V)(12.5)), ((V)(1.8)), ((V)(0D))), Arr(((V)(6.5)), ((V)(5D)), ((V)(16.5)), ((V)(1.75)), ((V)(0.4))), Arr(((V)(13D)), ((V)(9D)), ((V)(21D)), ((V)(1.75)), ((V)(0.1))), Arr(((V)(19.5)), ((V)(12D)), ((V)(25.5)), ((V)(1.7)), ((V)(0.35))), Arr(((V)(25.5)), ((V)(15D)), ((V)(30D)), ((V)(1.7)), ((V)(0.05))), Arr(((V)(30.5)), ((V)(18D)), ((V)(34.2)), ((V)(1.65)), ((V)(0.25))), Arr(((V)(34.5)), ((V)(21D)), ((V)(38D)), ((V)(1.6)), ((V)(0.15))), Arr(((V)(36.8)), ((V)(12D)), ((V)(38.8)), ((V)(1.5)), ((V)(0.3)))), "forEach", Fn((V _arrowThis1427, int _argc1420, V a_1426, V _a1423, V _a1424, V _a1425, V[] _rest1421) => {
return CallSpread(add_1343, V.Undef, new ArrBuilder().Spread(a_1426).V);
}, 1, "", true));
Invoke(K_1342, "forEach", Fn((V _arrowThis1435, int _argc1428, V k_1434, V _a1431, V _a1432, V _a1433, V[] _rest1429) => {
Set(k_1434, "g", Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, KG_1339));
Set(k_1434, "e", Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", popF_1334).V, Get(k_1434, "g")));
Set(k_1434, "dot", Call(el_14, V.Undef, ((V)("path")), NewObj(2).Put("fill", ((V)("#d89a3a"))).Put("opacity", ((V)(0.8))).V, Get(k_1434, "g")));
Set(k_1434, "id", ((V)(JsStrBuf.Begin().S("k").V(Get(k_1434, "id")).End())));
return default;
}, 1, "", true));
return NewObj(15).Put("O", O_1327).Put("rT", rT_1328).Put("EL", ((V)(EL_1329))).Put("K", K_1342).Put("KG", KG_1339).Put("cl", cl_1338).Put("sh", sh_1335).Put("st", st_1336).Put("bed", bed_1337).Put("rim", rim_1340).Put("rimL", rimL_1341).Put("rx", ((V)(35D))).Put("ya", ((V)(44D))).Put("yb", ((V)(86D))).Put("zE", Fn((V _arrowThis1444, int _argc1436, V dx_1442, V dy_1443, V _a1440, V _a1441, V[] _rest1437) => {
V r_1445 = default;
r_1445 = Call(rT_1328, V.Undef, Add(Get(S_1325, "HY"), dy_1443));
return ((V)((System.Math.Sqrt(Max(0D, ((ToNum(r_1445) * ToNum(r_1445)) - (ToNum(dx_1442) * ToNum(dx_1442))))) + 0.3)));
return default;
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self1446, int _argc1447, V B_1453, V D_1454, V _a1451, V _a1452, V[] _rest1448) => {
V P3_1455 = default;
V Z3_1456 = default;
V set_1457 = default;
V EL_1458 = default;
V rT_1459 = default;
V pop_1460 = default;
V fz_1461 = default;
V PE_1462 = default;
V hp_1463 = default;
V vis_1464 = default;
JsStrBuf sd_1465 = null;
V ring_1466 = default;
V FR_1467 = default;
V FRb_1468 = default;
V FRl_1469 = default;
V L_1470 = default;
if (_self1446.IsNullish) _self1446 = GlobalV;
{ V _t1471 = D_1454;
if (_t1471.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1471));
{ V _t1472 = Get(_t1471, "P3");
P3_1455 = _t1472; }
{ V _t1473 = Get(_t1471, "Z3");
Z3_1456 = _t1473; }
{ V _t1474 = Get(_t1471, "set");
set_1457 = _t1474; } }
EL_1458 = Get(B_1453, "EL");
rT_1459 = Get(B_1453, "rT");
pop_1460 = Call(clamp_12, V.Undef, Invoke(D_1454, "bv", ((V)("pop"))), ((V)(0D)), ((V)(1.6)));
fz_1461 = Call(clamp_12, V.Undef, Invoke(D_1454, "bv", ((V)("cfz"))), ((V)(0D)), ((V)(1D)));
PE_1462 = Fn((V _arrowThis1484, int _argc1475, V x_1481, V y_1482, V z_1483, V _a1480, V[] _rest1476) => {
V p_1485 = default;
p_1485 = Call(P3_1455, V.Undef, x_1481, y_1482, z_1483);
return Arr(GetIdx(p_1485, 0D), Add(GetIdx(p_1485, 1D), ((V)((ToNum(EL_1458) * ToNum(Call(Z3_1456, V.Undef, x_1481, y_1482, z_1483)))))));
return default;
}, 3, "", true);
hp_1463 = Arr();
{
double i_1486 = 0;
i_1486 = 0D;
while (true) {
if (!((i_1486 <= 14D))) break;
double y_1488 = 0;
V r_1489 = default;
y_1488 = (41.5 + ((45.5 * i_1486) / 14D));
r_1489 = Call(rT_1459, V.Undef, ((V)(y_1488)));
{
double k_1490 = 0;
k_1490 = 0D;
while (true) {
if (!((k_1490 < 24D))) break;
double f_1492 = 0;
f_1492 = ((k_1490 / 24D) * TAU_9);
Invoke(hp_1463, "push", Call(PE_1462, V.Undef, ((V)((50D + (ToNum(r_1489) * FdLibm.Sin(f_1492))))), ((V)(y_1488)), ((V)((ToNum(r_1489) * FdLibm.Cos(f_1492))))));
k_1490++;
}
}
i_1486++;
}
}
{
double k_1493 = 0;
k_1493 = 0D;
while (true) {
if (!((k_1493 < 32D))) break;
double f_1495 = 0;
f_1495 = ((k_1493 / 32D) * TAU_9);
Invoke(hp_1463, "push", Call(PE_1462, V.Undef, ((V)((50D + (35.6 * FdLibm.Sin(f_1495))))), ((V)(39.8)), ((V)((35.6 * FdLibm.Cos(f_1495))))));
k_1493++;
}
}
Set(B_1453, "d", Invoke(D_1454, "hull", hp_1463));
Call(set_1457, V.Undef, Get(B_1453, "sh"), ((V)("d")), Get(B_1453, "d"));
vis_1464 = Fn((V _arrowThis1504, int _argc1496, V f_1502, V y_1503, V _a1500, V _a1501, V[] _rest1497) => {
V r_1505 = default;
r_1505 = Call(rT_1459, V.Undef, y_1503);
return (GtN(Invoke(D_1454, "facing", ((V)((50D + (ToNum(r_1505) * FdLibm.Sin(ToNum(f_1502)))))), y_1503, ((V)((ToNum(r_1505) * FdLibm.Cos(ToNum(f_1502))))), ((V)(FdLibm.Sin(ToNum(f_1502)))), ((V)(0D)), ((V)(FdLibm.Cos(ToNum(f_1502))))), 0.004) ? V.True : V.False);
return default;
}, 2, "", true);
sd_1465 = new JsStrBuf("");
{
double s_1506 = 0;
s_1506 = 0D;
while (true) {
if (!((s_1506 < 8D))) break;
double fc_1508 = 0;
double fa_1509 = 0;
double fb_1510 = 0;
V F_1511 = default;
V Q_1512 = default;
V ys_1513 = default;
fc_1508 = (((s_1506 + 0.5) * TAU_9) / 8D);
fa_1509 = (fc_1508 - (TAU_9 / 32D));
fb_1510 = (fc_1508 + (TAU_9 / 32D));
F_1511 = Arr();
{
double j_1514 = 0;
j_1514 = 0D;
while (true) {
if (!((j_1514 <= 12D))) break;
double f_1516 = 0;
f_1516 = (fa_1509 + (((fb_1510 - fa_1509) * j_1514) / 12D));
if (Truthy(Call(vis_1464, V.Undef, ((V)(f_1516)), ((V)(62D))))) {
Invoke(F_1511, "push", ((V)(f_1516)));
}
j_1514++;
}
}
if (LtN(Get(F_1511, "length"), 2D)) {
goto _cont1507;
}
Q_1512 = Arr();
ys_1513 = Arr(((V)(44.5)), ((V)(52D)), ((V)(60D)), ((V)(68D)), ((V)(76D)), ((V)(82D)), ((V)(85D)), ((V)(86.8)));
Invoke(F_1511, "forEach", Fn((V _arrowThis1524, int _argc1517, V f_1523, V _a1520, V _a1521, V _a1522, V[] _rest1518) => {
return Invoke(Q_1512, "push", Call(PE_1462, V.Undef, ((V)((50D + (ToNum(Call(rT_1459, V.Undef, ((V)(44.5)))) * FdLibm.Sin(ToNum(f_1523)))))), ((V)(44.5)), ((V)((ToNum(Call(rT_1459, V.Undef, ((V)(44.5)))) * FdLibm.Cos(ToNum(f_1523)))))));
}, 1, "", true));
Invoke(ys_1513, "forEach", Fn((V _arrowThis1532, int _argc1525, V y_1531, V _a1528, V _a1529, V _a1530, V[] _rest1526) => {
V f_1533 = default;
V r_1534 = default;
f_1533 = GetIdx(F_1511, (ToNum(Get(F_1511, "length")) - 1D));
r_1534 = Call(rT_1459, V.Undef, y_1531);
Invoke(Q_1512, "push", Call(PE_1462, V.Undef, ((V)((50D + (ToNum(r_1534) * FdLibm.Sin(ToNum(f_1533)))))), y_1531, ((V)((ToNum(r_1534) * FdLibm.Cos(ToNum(f_1533)))))));
return default;
}, 1, "", true));
Invoke(Invoke(Invoke(F_1511, "slice"), "reverse"), "forEach", Fn((V _arrowThis1542, int _argc1535, V f_1541, V _a1538, V _a1539, V _a1540, V[] _rest1536) => {
V r_1543 = default;
r_1543 = Call(rT_1459, V.Undef, ((V)(86.8)));
Invoke(Q_1512, "push", Call(PE_1462, V.Undef, ((V)((50D + (ToNum(r_1543) * FdLibm.Sin(ToNum(f_1541)))))), ((V)(86.8)), ((V)((ToNum(r_1543) * FdLibm.Cos(ToNum(f_1541)))))));
return default;
}, 1, "", true));
Invoke(Invoke(Invoke(ys_1513, "slice"), "reverse"), "forEach", Fn((V _arrowThis1551, int _argc1544, V y_1550, V _a1547, V _a1548, V _a1549, V[] _rest1545) => {
V f_1552 = default;
V r_1553 = default;
f_1552 = GetIdx(F_1511, 0D);
r_1553 = Call(rT_1459, V.Undef, y_1550);
Invoke(Q_1512, "push", Call(PE_1462, V.Undef, ((V)((50D + (ToNum(r_1553) * FdLibm.Sin(ToNum(f_1552)))))), y_1550, ((V)((ToNum(r_1553) * FdLibm.Cos(ToNum(f_1552)))))));
return default;
}, 1, "", true));
sd_1465.V(Call(polyW_18, V.Undef, Q_1512));
_cont1507: ;
s_1506++;
}
}
Call(set_1457, V.Undef, Get(B_1453, "st"), ((V)("d")), (((V)(sd_1465.Str)) is var _t1554 && Truthy(_t1554) ? _t1554 : ((V)("M0 0"))));
ring_1466 = Fn((V _arrowThis1563, int _argc1555, V r_1561, V y_1562, V _a1559, V _a1560, V[] _rest1556) => {
V o_1564 = default;
o_1564 = Arr();
{
double k_1565 = 0;
k_1565 = 0D;
while (true) {
if (!((k_1565 < 40D))) break;
double f_1567 = 0;
f_1567 = ((k_1565 / 40D) * TAU_9);
Invoke(o_1564, "push", Call(PE_1462, V.Undef, ((V)((50D + (ToNum(r_1561) * FdLibm.Sin(f_1567))))), y_1562, ((V)((ToNum(r_1561) * FdLibm.Cos(f_1567))))));
k_1565++;
}
}
return o_1564;
return default;
}, 2, "", true);
Call(set_1457, V.Undef, Get(B_1453, "bed"), ((V)("d")), Call(polyW_18, V.Undef, Call(ring_1466, V.Undef, ((V)(34.2)), ((V)(40.6)))));
FR_1467 = Arr();
FRb_1468 = Arr();
FRl_1469 = Arr();
Invoke(Invoke(Get(SN_43, "h"), "frontArc", D_1454, ((V)(36D)), ((V)(41D)), ((V)(60D))), "forEach", Fn((V _arrowThis1575, int _argc1568, V f_1574, V _a1571, V _a1572, V _a1573, V[] _rest1569) => {
Invoke(FR_1467, "push", Call(PE_1462, V.Undef, ((V)((50D + (36.8 * FdLibm.Sin(ToNum(f_1574)))))), ((V)(39.2)), ((V)((36.8 * FdLibm.Cos(ToNum(f_1574)))))));
Invoke(FRb_1468, "push", Call(PE_1462, V.Undef, ((V)((50D + (36.1 * FdLibm.Sin(ToNum(f_1574)))))), ((V)(44.2)), ((V)((36.1 * FdLibm.Cos(ToNum(f_1574)))))));
Invoke(FRl_1469, "push", Call(PE_1462, V.Undef, ((V)((50D + (36.3 * FdLibm.Sin(ToNum(f_1574)))))), ((V)(40.5)), ((V)((36.3 * FdLibm.Cos(ToNum(f_1574)))))));
return default;
}, 1, "", true));
Call(set_1457, V.Undef, Get(B_1453, "rim"), ((V)("d")), (Call(polyW_18, V.Undef, Invoke(FR_1467, "concat", Invoke(Invoke(FRb_1468, "slice"), "reverse"))) is var _t1576 && Truthy(_t1576) ? _t1576 : ((V)("M0 0"))));
Call(set_1457, V.Undef, Get(B_1453, "rimL"), ((V)("d")), (Call(runs_21, V.Undef, FRl_1469, Invoke(FRl_1469, "map", Fn((V _arrowThis1583, int _argc1577, V _a1579, V _a1580, V _a1581, V _a1582, V[] _rest1578) => {
return (true ? V.True : V.False);
}, 0, "", true))) is var _t1584 && Truthy(_t1584) ? _t1584 : ((V)("M0 0"))));
if (GtN(Get(FR_1467, "length"), 2D)) {
V a_1585 = default;
V z_1586 = default;
V L_1587 = default;
a_1585 = GetIdx(FR_1467, 0D);
z_1586 = GetIdx(FR_1467, (ToNum(Get(FR_1467, "length")) - 1D));
L_1587 = (Lt(GetIdx(a_1585, 0D), GetIdx(z_1586, 0D)) ? FR_1467 : Invoke(Invoke(FR_1467, "slice"), "reverse"));
Call(set_1457, V.Undef, Get(Get(B_1453, "cl"), "p"), ((V)("d")), ((V)(JsStrBuf.Begin().S("M").V(Call(r2_11, V.Undef, ((V)((ToNum(GetIdx(GetIdx(L_1587, 0D), 0D)) - 40D))))).S(" ").V(Call(r2_11, V.Undef, Add(GetIdx(GetIdx(L_1587, 0D), 1D), ((V)(0.6))))).S("L").V(Call(r2_11, V.Undef, ((V)((ToNum(GetIdx(GetIdx(L_1587, 0D), 0D)) - 40D))))).S(" -200L").V(Call(r2_11, V.Undef, Add(GetIdx(GetIdx(L_1587, (ToNum(Get(L_1587, "length")) - 1D)), 0D), ((V)(40D))))).S(" -200L").V(Call(r2_11, V.Undef, Add(GetIdx(GetIdx(L_1587, (ToNum(Get(L_1587, "length")) - 1D)), 0D), ((V)(40D))))).S(" ").V(Call(r2_11, V.Undef, Add(GetIdx(GetIdx(L_1587, (ToNum(Get(L_1587, "length")) - 1D)), 1D), ((V)(0.6))))).V(Invoke(Invoke(Invoke(Invoke(L_1587, "slice"), "reverse"), "map", Fn((V _arrowThis1595, int _argc1588, V p_1594, V _a1591, V _a1592, V _a1593, V[] _rest1589) => {
return ((V)(JsStrBuf.Begin().S("L").V(Call(r2_11, V.Undef, GetIdx(p_1594, 0D))).S(" ").V(Call(r2_11, V.Undef, Add(GetIdx(p_1594, 1D), ((V)(0.6))))).End()));
}, 1, "", true)), "join", ((V)("")))).S("Z").End())));
}
L_1470 = Invoke(Invoke(Get(B_1453, "K"), "map", Fn((V _arrowThis1612, int _argc1605, V k_1611, V _a1608, V _a1609, V _a1610, V[] _rest1606) => {
V hgt_1613 = default;
double jp_1614 = 0;
V x_1615 = default;
double y_1616 = 0;
V C_1617 = default;
double s_1618 = 0;
JsStrBuf d_1619 = null;
hgt_1613 = Call(clamp_12, V.Undef, ((V)(((41D - ToNum(Get(k_1611, "y"))) / 28D))), ((V)(0D)), ((V)(1D)));
jp_1614 = (((ToNum(pop_1460) * ToNum(Get(k_1611, "hk"))) * (0.6 + (0.4 * FdLibm.Sin(ToNum(Add(((V)((ToNum(Get(D_1454, "ts")) * 9D))), Get(k_1611, "hk"))))))) + ((ToNum(fz_1461) * FdLibm.Sin(((ToNum(Get(D_1454, "ts")) * 37D) + (ToNum(Get(k_1611, "hk")) * 3D)))) * 0.6));
x_1615 = Add(Add(Get(k_1611, "x"), ((V)(((ToNum(Get(D_1454, "ox")) * 0.25) * ToNum(hgt_1613))))), ((V)(((ToNum(fz_1461) * FdLibm.Sin(ToNum(Add(((V)((ToNum(Get(D_1454, "ts")) * 41D))), Get(k_1611, "hk"))))) * 0.5))));
y_1616 = ((ToNum(Get(k_1611, "y")) - ((ToNum(Get(D_1454, "oy")) * 0.3) * ToNum(hgt_1613))) - Max(0D, jp_1614));
C_1617 = Call(PE_1462, V.Undef, x_1615, ((V)(y_1616)), Get(k_1611, "z"));
s_1618 = (ToNum(Get(k_1611, "s")) * ToNum(Get(D_1454, "kS")));
d_1619 = new JsStrBuf("");
Invoke(Get(k_1611, "B"), "forEach", Fn((V _arrowThis1627, int _argc1620, V b_1626, V _a1623, V _a1624, V _a1625, V[] _rest1621) => {
d_1619.V(Call(circD_19, V.Undef, Arr(Add(GetIdx(C_1617, 0D), ((V)(((ToNum(GetIdx(b_1626, 0D)) * s_1618) * 0.55)))), Add(GetIdx(C_1617, 1D), ((V)(((ToNum(GetIdx(b_1626, 1D)) * s_1618) * 0.55))))), ((V)(((ToNum(GetIdx(b_1626, 2D)) * s_1618) * 0.55)))));
return default;
}, 1, "", true));
Call(set_1457, V.Undef, Get(k_1611, "e"), ((V)("d")), ((V)(d_1619.Str)));
Call(set_1457, V.Undef, Get(k_1611, "dot"), ((V)("d")), Call(circD_19, V.Undef, Arr(Add(GetIdx(C_1617, 0D), ((V)(((ToNum(GetIdx(GetIdx(Get(k_1611, "B"), 1D), 0D)) * s_1618) * 0.3)))), Add(GetIdx(C_1617, 1D), ((V)((0.7 * s_1618))))), ((V)(((0.85 * s_1618) * 0.55)))));
return NewObj(3).Put("id", Get(k_1611, "id")).Put("e", Get(k_1611, "g")).Put("z", Call(Z3_1456, V.Undef, x_1615, ((V)(y_1616)), Get(k_1611, "z"))).V;
return default;
}, 1, "", true)), "sort", Fn((V _arrowThis1604, int _argc1596, V a_1602, V b_1603, V _a1600, V _a1601, V[] _rest1597) => {
return ((V)((ToNum(Get(a_1602, "z")) - ToNum(Get(b_1603, "z")))));
}, 2, "", true));
Invoke(SN_43, "order", Get(B_1453, "KG"), L_1470);
return default;
}, 2, "draw", false)).V);
Set(MODELS_42, "nori", NewObj(2).Put("setup", Fn((V _self1628, int _argc1629, V S_1635, V _a1632, V _a1633, V _a1634, V[] _rest1630) => {
V sk_1636 = default;
V O_1637 = default;
double T_1638 = 0;
double b_1639 = 0;
V rings_1640 = default;
V zF_1641 = default;
V GG_1642 = default;
V DC_1643 = default;
V BG_1644 = default;
V SG_1645 = default;
V swq_1646 = default;
V sh_1647 = default;
V SW_1648 = default;
V TOP_1649 = default;
V BK_1650 = default;
double n_1651 = 0;
V bkg_1652 = default;
V FL_1653 = default;
V SAL_1654 = default;
V shd_1655 = default;
V FK_1656 = default;
if (_self1628.IsNullish) _self1628 = GlobalV;
{ V _t1657 = S_1635;
if (_t1657.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1657));
{ V _t1658 = Get(_t1657, "sk");
sk_1636 = _t1658; } }
O_1637 = Invoke(S_1635, "outline", sk_1636, ((V)(64D)));
T_1638 = 10.5;
b_1639 = 8D;
rings_1640 = Call(pillowRings_40, V.Undef, O_1637, ((V)(T_1638)), ((V)(b_1639)), ((V)(4D)));
zF_1641 = Call(pillowZ_41, V.Undef, O_1637, ((V)(T_1638)), ((V)(b_1639)));
Invoke(S_1635, "hide", Fn((V _arrowThis1666, int _argc1659, V q_1665, V _a1662, V _a1663, V _a1664, V[] _rest1660) => {
return (Get(q_1665, "inBody") is var _t1671 && !Truthy(_t1671) ? _t1671 : (((Invoke(S_1635, "dk", q_1665, ((V)("sal"))) is var _t1668 && Truthy(_t1668) ? _t1668 : ((SEqS(Get(q_1665, "tag"), "circle") ? V.True : V.False) is var _t1667 && !Truthy(_t1667) ? _t1667 : Invoke(NewRegExp(RX2, "^url", ""), "test", Invoke(S_1635, "f", q_1665)))) is var _t1669 && Truthy(_t1669) ? _t1669 : (SEqS(Invoke(S_1635, "f", q_1665), "#5aa04a") ? V.True : V.False)) is var _t1670 && Truthy(_t1670) ? _t1670 : (SEqS(Invoke(S_1635, "s", q_1665), "#ffd0da") ? V.True : V.False)));
}, 1, "", true));
GG_1642 = Invoke(S_1635, "g");
DC_1643 = Invoke(S_1635, "decals", Fn((V _arrowThis1679, int _argc1672, V q_1678, V _a1675, V _a1676, V _a1677, V[] _rest1673) => {
return (Get(q_1678, "inBody") is var _t1680 && !Truthy(_t1680) ? _t1680 : Invoke(S_1635, "dk", q_1678, ((V)("dc"))));
}, 1, "", true), GG_1642);
BG_1644 = Invoke(S_1635, "g");
SG_1645 = Invoke(S_1635, "g");
swq_1646 = Invoke(S_1635, "hide", Fn((V _arrowThis1688, int _argc1681, V q_1687, V _a1684, V _a1685, V _a1686, V[] _rest1682) => {
return (Get(q_1687, "inBody") is var _t1689 && !Truthy(_t1689) ? _t1689 : Invoke(S_1635, "dk", q_1687, ((V)("sw"))));
}, 1, "", true));
sh_1647 = Invoke(swq_1646, "find", Fn((V _arrowThis1697, int _argc1690, V q_1696, V _a1693, V _a1694, V _a1695, V[] _rest1691) => {
return Invoke(NewRegExp(RX2, "^url", ""), "test", Invoke(S_1635, "f", q_1696));
}, 1, "", true));
SW_1648 = NewObj(5).Put("st", Invoke(S_1635, "path", NewObj(1).Put("fill", (Truthy(sh_1647) ? Invoke(S_1635, "f", sh_1647) : ((V)("#2b4232")))).V, SG_1645)).Put("rim", Invoke(S_1635, "path", NewObj(2).Put("fill", ((V)("#0f1c13"))).Put("opacity", ((V)(0.45))).V, SG_1645)).Put("fib", Invoke(S_1635, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#46644e"))).Put("stroke-width", ((V)(0.45))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.7))).V, SG_1645)).Put("shn", Invoke(S_1635, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#86a88c"))).Put("stroke-width", ((V)(1.3))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.45))).V, SG_1645)).Put("edge", Invoke(S_1635, "path", NewObj(6).Put("fill", ((V)("none"))).Put("stroke", ((V)("#122017"))).Put("stroke-width", ((V)(0.7))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).Put("opacity", ((V)(0.7))).V, SG_1645)).V;
TOP_1649 = Arr();
Invoke(Arr(Arr(Arr(((V)(31.5)), ((V)(65.5))), Arr(((V)(41D)), ((V)(64D))), Arr(((V)(50D)), ((V)(64.6)))), Arr(Arr(((V)(50D)), ((V)(64.6))), Arr(((V)(59D)), ((V)(64D))), Arr(((V)(68.5)), ((V)(65.5))))), "forEach", Fn((V _arrowThis1712, int _argc1698, V _a1700, V h_1704, V _a1702, V _a1703, V[] _rest1699) => {
V p0_1707 = default;
V c_1709 = default;
V p1_1711 = default;
{ V _t1705 = ListOf(_a1700);
{ V _t1706 = GetIdx(_t1705, 0D);
p0_1707 = _t1706; }
{ V _t1708 = GetIdx(_t1705, 1D);
c_1709 = _t1708; }
{ V _t1710 = GetIdx(_t1705, 2D);
p1_1711 = _t1710; }
}
{
double k_1713 = 0;
k_1713 = (Truthy(h_1704) ? 1D : 0D);
while (true) {
if (!((k_1713 <= 12D))) break;
double t_1715 = 0;
double u_1716 = 0;
t_1715 = (k_1713 / 12D);
u_1716 = (1D - t_1715);
Invoke(TOP_1649, "push", Arr(((V)(((((u_1716 * u_1716) * ToNum(GetIdx(p0_1707, 0D))) + (((2D * u_1716) * t_1715) * ToNum(GetIdx(c_1709, 0D)))) + ((t_1715 * t_1715) * ToNum(GetIdx(p1_1711, 0D)))))), ((V)(((((u_1716 * u_1716) * ToNum(GetIdx(p0_1707, 1D))) + (((2D * u_1716) * t_1715) * ToNum(GetIdx(c_1709, 1D)))) + ((t_1715 * t_1715) * ToNum(GetIdx(p1_1711, 1D))))))));
k_1713++;
}
}
return default;
}, 2, "", true));
Set(SW_1648, "yt", Fn((V _arrowThis1724, int _argc1717, V x_1723, V _a1720, V _a1721, V _a1722, V[] _rest1718) => {
if (Le(x_1723, GetIdx(GetIdx(TOP_1649, 0D), 0D))) {
return GetIdx(GetIdx(TOP_1649, 0D), 1D);
}
{
double k_1725 = 0;
k_1725 = 1D;
while (true) {
if (!(Lt(((V)(k_1725)), Get(TOP_1649, "length")))) break;
if (Le(x_1723, GetIdx(GetIdx(TOP_1649, k_1725), 0D))) {
V a_1727 = default;
V c_1728 = default;
double t_1729 = 0;
a_1727 = GetIdx(TOP_1649, (k_1725 - 1D));
c_1728 = GetIdx(TOP_1649, k_1725);
t_1729 = ((ToNum(x_1723) - ToNum(GetIdx(a_1727, 0D))) / ToNum((((V)((ToNum(GetIdx(c_1728, 0D)) - ToNum(GetIdx(a_1727, 0D))))) is var _t1730 && Truthy(_t1730) ? _t1730 : ((V)(1D)))));
return Add(GetIdx(a_1727, 1D), ((V)(((ToNum(GetIdx(c_1728, 1D)) - ToNum(GetIdx(a_1727, 1D))) * t_1729))));
}
k_1725++;
}
}
return GetIdx(GetIdx(TOP_1649, (ToNum(Get(TOP_1649, "length")) - 1D)), 1D);
return default;
}, 1, "", true));
BK_1650 = Arr();
n_1651 = 0D;
while ((LtN(Get(BK_1650, "length"), 12D) && (n_1651 < 400D))) {
double x_1731 = 0;
double y_1732 = 0;
n_1651++;
x_1731 = (31D + (ToNum(Call(rnd_22, V.Undef, ((V)((n_1651 * 3.3))))) * 38D));
y_1732 = (46D + (ToNum(Call(rnd_22, V.Undef, ((V)((n_1651 * 7.1))))) * 18D));
if (Truthy(Invoke(BK_1650, "some", Fn((V _arrowThis1740, int _argc1733, V p_1739, V _a1736, V _a1737, V _a1738, V[] _rest1734) => {
return ((Hypot((ToNum(GetIdx(p_1739, 0D)) - x_1731), (ToNum(GetIdx(p_1739, 1D)) - y_1732)) < 4.6) ? V.True : V.False);
}, 1, "", true)))) {
continue;
}
Invoke(BK_1650, "push", Arr(((V)(x_1731)), ((V)(y_1732)), ((V)((ToNum(Call(rnd_22, V.Undef, ((V)((n_1651 * 1.9))))) * System.Math.PI)))));
}
bkg_1652 = Call(el_14, V.Undef, ((V)("path")), NewObj(3).Put("fill", ((V)("#ffffff"))).Put("stroke", ((V)("#ddd5c3"))).Put("stroke-width", ((V)(0.35))).V, BG_1644);
FL_1653 = Arr(Arr(((V)(43.92)), ((V)(18.79)), ((V)(2.48)), ((V)("#f8b897")), ((V)(1D)), ((V)(2.64))), Arr(((V)(46.89)), ((V)(18.71)), ((V)(2.48)), ((V)("#e97c55")), ((V)(1D)), ((V)(2.64))), Arr(((V)(50.17)), ((V)(18.41)), ((V)(2.37)), ((V)("#e97c55")), ((V)(1D)), ((V)(1.22))), Arr(((V)(53.59)), ((V)(18.65)), ((V)(2.2)), ((V)("#ee8a62")), ((V)(1D)), ((V)(2.49))), Arr(((V)(57.12)), ((V)(18.06)), ((V)(2.28)), ((V)("#f39a72")), ((V)(1D)), ((V)(1.32))), Arr(((V)(45.78)), ((V)(15.18)), ((V)(2.06)), ((V)("#f39a72")), ((V)(1D)), ((V)((-1.95)))), Arr(((V)(48.98)), ((V)(15.41)), ((V)(1.85)), ((V)("#f8b897")), ((V)(0D)), ((V)((-0.96)))), Arr(((V)(52.94)), ((V)(15.17)), ((V)(2.03)), ((V)("#f6ad8a")), ((V)(1D)), ((V)((-1.24)))), Arr(((V)(56.3)), ((V)(15.08)), ((V)(2.16)), ((V)("#e97c55")), ((V)(1D)), ((V)((-0.89)))), Arr(((V)(47.11)), ((V)(12.8)), ((V)(1.62)), ((V)("#e97c55")), ((V)(0D)), ((V)(1.24))), Arr(((V)(51.35)), ((V)(12.56)), ((V)(1.67)), ((V)("#f8b897")), ((V)(0D)), ((V)(0.66))), Arr(((V)(54.4)), ((V)(12.22)), ((V)(1.92)), ((V)("#f39a72")), ((V)(1D)), ((V)(1.1))), Arr(((V)(50.85)), ((V)(10.35)), ((V)(1.53)), ((V)("#f8b897")), ((V)(0D)), ((V)(0D))));
SAL_1654 = Invoke(S_1635, "g");
shd_1655 = Invoke(S_1635, "path", NewObj(2).Put("fill", ((V)("#cfc6b2"))).Put("opacity", ((V)(0.4))).V, SAL_1654);
FK_1656 = Invoke(FL_1653, "map", Fn((V _arrowThis1761, int _argc1741, V _a1743, V k_1747, V _a1745, V _a1746, V[] _rest1742) => {
V g_1762 = default;
V x_1750 = default;
V y_1752 = default;
V r_1754 = default;
V c_1756 = default;
V ft_1758 = default;
V z_1760 = default;
{ V _t1748 = ListOf(_a1743);
{ V _t1749 = GetIdx(_t1748, 0D);
x_1750 = _t1749; }
{ V _t1751 = GetIdx(_t1748, 1D);
y_1752 = _t1751; }
{ V _t1753 = GetIdx(_t1748, 2D);
r_1754 = _t1753; }
{ V _t1755 = GetIdx(_t1748, 3D);
c_1756 = _t1755; }
{ V _t1757 = GetIdx(_t1748, 4D);
ft_1758 = _t1757; }
{ V _t1759 = GetIdx(_t1748, 5D);
z_1760 = _t1759; }
}
g_1762 = Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, SAL_1654);
return NewObj(9).Put("k", k_1747).Put("x", x_1750).Put("y", y_1752).Put("r", r_1754).Put("z", z_1760).Put("rot", ((V)(((ToNum(Call(rnd_22, V.Undef, ((V)((ToNum(k_1747) * 3.1))))) - 0.5) * 1.3)))).Put("g", g_1762).Put("b", Call(el_14, V.Undef, ((V)("path")), NewObj(4).Put("fill", c_1756).Put("stroke", ((V)("#cf6a44"))).Put("stroke-width", ((V)(0.3))).Put("stroke-opacity", ((V)(0.5))).V, g_1762)).Put("f", (Truthy(ft_1758) ? Call(el_14, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffe6d8"))).Put("stroke-width", ((V)(0.42))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.8))).V, g_1762) : V.Null)).V;
return default;
}, 2, "", true));
return NewObj(20).Put("O", O_1637).Put("T", ((V)(T_1638))).Put("b", ((V)(b_1639))).Put("rings", rings_1640).Put("zF", zF_1641).Put("DC", DC_1643).Put("SW", SW_1648).Put("BG", BG_1644).Put("bkg", bkg_1652).Put("BK", BK_1650).Put("SAL", SAL_1654).Put("shd", shd_1655).Put("FK", FK_1656).Put("slab", ((V)(1D))).Put("rx", ((V)(38D))).Put("ya", ((V)(20D))).Put("yb", ((V)(86D))).Put("rT", Fn((V _arrowThis1770, int _argc1763, V y_1769, V _a1766, V _a1767, V _a1768, V[] _rest1764) => {
return Call(halfW_38, V.Undef, O_1637, y_1769);
}, 1, "rT", true)).Put("zAt", Fn((V _arrowThis1779, int _argc1771, V x_1777, V y_1778, V _a1775, V _a1776, V[] _rest1772) => {
return Call(zF_1641, V.Undef, x_1777, y_1778);
}, 2, "zAt", true)).Put("zE", Fn((V _arrowThis1788, int _argc1780, V dx_1786, V dy_1787, V _a1784, V _a1785, V[] _rest1781) => {
return Add(Call(zF_1641, V.Undef, Add(Get(S_1635, "HX"), dx_1786), Add(Get(S_1635, "HY"), dy_1787)), ((V)(0.3)));
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self1789, int _argc1790, V B_1796, V D_1797, V _a1794, V _a1795, V[] _rest1791) => {
V P3_1798 = default;
V set_1799 = default;
V zF_1800 = default;
V umeV_1801 = default;
double nw_1802 = 0;
V fr_1803 = default;
double s_1804 = 0;
V S2_1805 = default;
V W_1806 = default;
double YB_1807 = 0;
V xl_1808 = default;
V xr_1809 = default;
double NU_1810 = 0;
double e_1811 = 0;
V nrm_1812 = default;
V line_1813 = default;
V L_1814 = default;
V lerp_1815 = default;
JsStrBuf dS_1816 = null;
JsStrBuf dR_1817 = null;
V fr2_1818 = default;
double ti_1819 = 0;
JsStrBuf fd_1820 = null;
V PS_1821 = default;
V sj_1822 = default;
V kS_1823 = default;
V M2_1824 = default;
V flk_1825 = default;
V fatL_1826 = default;
if (_self1789.IsNullish) _self1789 = GlobalV;
{ V _t1827 = D_1797;
if (_t1827.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1827));
{ V _t1828 = Get(_t1827, "P3");
P3_1798 = _t1828; }
{ V _t1829 = Get(_t1827, "set");
set_1799 = _t1829; } }
zF_1800 = Get(B_1796, "zF");
umeV_1801 = Call(clamp_12, V.Undef, Invoke(D_1797, "bv", ((V)("ume"))), ((V)(0D)), ((V)(1.2)));
nw_1802 = (ToNum(Call(clamp_12, V.Undef, Invoke(D_1797, "bv", ((V)("nwr"))), ((V)((-1D))), ((V)(1D)))) * 3D);
Set(B_1796, "d", Invoke(D_1797, "hull", Call(pillowHull_46, V.Undef, D_1797, Get(B_1796, "rings"), ((V)(0D)), ((V)(1D)), Call(pillowHull_46, V.Undef, D_1797, Get(B_1796, "rings"), ((V)(0D)), ((V)((-1D)))))));
fr_1803 = (GeN(Get(D_1797, "front"), 0D) ? V.True : V.False);
s_1804 = (Truthy(fr_1803) ? 1D : (-1D));
S2_1805 = Fn((V _arrowThis1839, int _argc1830, V x_1836, V y_1837, V dz_1838, V _a1835, V[] _rest1831) => {
return Call(P3_1798, V.Undef, x_1836, y_1837, ((V)((s_1804 * ToNum(Add(Call(zF_1800, V.Undef, x_1836, y_1837), dz_1838))))));
}, 3, "", true);
Invoke(Get(B_1796, "DC"), "forEach", Fn((V _arrowThis1847, int _argc1840, V o_1846, V _a1843, V _a1844, V _a1845, V[] _rest1841) => {
return Call(set_1799, V.Undef, Get(o_1846, "e"), ((V)("d")), Call(decD_26, V.Undef, o_1846, Fn((V _arrowThis1856, int _argc1848, V x_1854, V y_1855, V _a1852, V _a1853, V[] _rest1849) => {
return Call(S2_1805, V.Undef, x_1854, y_1855, ((V)(0.2)));
}, 2, "", true)));
}, 1, "", true));
Invoke(Get(B_1796, "BG"), "setAttribute", ((V)("opacity")), ((V)((Truthy(fr_1803) ? 0D : 1D))));
if (!(Truthy(fr_1803))) {
Call(set_1799, V.Undef, Get(B_1796, "bkg"), ((V)("d")), Invoke(Invoke(Get(B_1796, "BK"), "map", Fn((V _arrowThis1870, int _argc1857, V _a1859, V _a1860, V _a1861, V _a1862, V[] _rest1858) => {
V x_1865 = default;
V y_1867 = default;
V a_1869 = default;
{ V _t1863 = ListOf(_a1859);
{ V _t1864 = GetIdx(_t1863, 0D);
x_1865 = _t1864; }
{ V _t1866 = GetIdx(_t1863, 1D);
y_1867 = _t1866; }
{ V _t1868 = GetIdx(_t1863, 2D);
a_1869 = _t1868; }
}
return Call(polyW_18, V.Undef, Array_from(NewObj(1).Put("length", ((V)(10D))).V, Fn((V _arrowThis1879, int _argc1871, V __1877, V k_1878, V _a1875, V _a1876, V[] _rest1872) => {
double f_1880 = 0;
f_1880 = ((ToNum(k_1878) / 10D) * TAU_9);
return Call(S2_1805, V.Undef, ((V)((ToNum(Add(x_1865, ((V)(((1.65 * FdLibm.Cos(f_1880)) * FdLibm.Cos(ToNum(a_1869))))))) - ((0.8 * FdLibm.Sin(f_1880)) * FdLibm.Sin(ToNum(a_1869)))))), Add(Add(y_1867, ((V)(((1.65 * FdLibm.Cos(f_1880)) * FdLibm.Sin(ToNum(a_1869)))))), ((V)(((0.8 * FdLibm.Sin(f_1880)) * FdLibm.Cos(ToNum(a_1869)))))), ((V)(0.2)));
return default;
}, 2, "", true)));
}, 1, "", true)), "join", ((V)(""))));
}
W_1806 = Get(B_1796, "SW");
YB_1807 = 87.5;
xl_1808 = Fn((V _arrowThis1888, int _argc1881, V y_1887, V _a1884, V _a1885, V _a1886, V[] _rest1882) => {
return ((V)((31.5 - ((2D * (ToNum(y_1887) - 65.5)) / 22D))));
}, 1, "", true);
xr_1809 = Fn((V _arrowThis1896, int _argc1889, V y_1895, V _a1892, V _a1893, V _a1894, V[] _rest1890) => {
return ((V)((68.5 + ((2D * (ToNum(y_1895) - 65.5)) / 22D))));
}, 1, "", true);
NU_1810 = 16D;
e_1811 = 0.25;
nrm_1812 = Fn((V _arrowThis1906, int _argc1897, V x_1903, V y_1904, V z_1905, V _a1902, V[] _rest1898) => {
double gx_1907 = 0;
double gy_1908 = 0;
double sg_1909 = 0;
double L__1910 = 0;
if ((System.Math.Abs(ToNum(z_1905)) < 0.05)) {
return Arr(((V)(0D)), ((V)(1D)), ((V)(0D)));
}
gx_1907 = ((ToNum(Call(zF_1800, V.Undef, Add(x_1903, ((V)(e_1811))), y_1904)) - ToNum(Call(zF_1800, V.Undef, ((V)((ToNum(x_1903) - e_1811))), y_1904))) / (2D * e_1811));
gy_1908 = ((ToNum(Call(zF_1800, V.Undef, x_1903, Add(y_1904, ((V)(e_1811))))) - ToNum(Call(zF_1800, V.Undef, x_1903, ((V)((ToNum(y_1904) - e_1811)))))) / (2D * e_1811));
sg_1909 = (GtN(z_1905, 0D) ? 1D : (-1D));
L__1910 = Hypot(gx_1907, gy_1908, 1D);
return Arr(((V)((((-gx_1907) * sg_1909) / L__1910))), ((V)((((-gy_1908) * sg_1909) / L__1910))), ((V)((sg_1909 / L__1910))));
return default;
}, 3, "", true);
line_1813 = Fn((V _arrowThis1918, int _argc1911, V u_1917, V _a1914, V _a1915, V _a1916, V[] _rest1912) => {
V x0_1919 = default;
V y0_1920 = default;
V P_1921 = default;
V Y_1922 = default;
x0_1919 = Add(Call(xl_1808, V.Undef, ((V)(65D))), ((V)((ToNum(u_1917) * (ToNum(Call(xr_1809, V.Undef, ((V)(65D)))) - ToNum(Call(xl_1808, V.Undef, ((V)(65D)))))))));
y0_1920 = Add(Invoke(W_1806, "yt", x0_1919), ((V)(nw_1802)));
P_1921 = Arr();
Y_1922 = Arr();
{
double j_1923 = 0;
j_1923 = 0D;
while (true) {
if (!((j_1923 <= 6D))) break;
Invoke(Y_1922, "push", Arr(Add(y0_1920, ((V)(((((YB_1807 - ToNum(Get(B_1796, "b"))) - ToNum(y0_1920)) * j_1923) / 6D)))), ((V)(1D))));
j_1923++;
}
}
{
double j_1925 = 0;
j_1925 = 1D;
while (true) {
if (!((j_1925 <= 6D))) break;
Invoke(Y_1922, "push", Arr(((V)((YB_1807 - (ToNum(Get(B_1796, "b")) * (1D - FdLibm.Cos((((1D - (j_1925 / 6D)) * System.Math.PI) / 2D))))))), ((V)(1D))));
j_1925++;
}
}
{
double j_1927 = 0;
j_1927 = 1D;
while (true) {
if (!((j_1927 <= 6D))) break;
Invoke(Y_1922, "push", Arr(((V)((YB_1807 - (ToNum(Get(B_1796, "b")) * (1D - FdLibm.Cos((((j_1927 / 6D) * System.Math.PI) / 2D))))))), ((V)((-1D)))));
j_1927++;
}
}
{
double j_1929 = 0;
j_1929 = 1D;
while (true) {
if (!((j_1929 <= 6D))) break;
Invoke(Y_1922, "push", Arr(((V)(((YB_1807 - ToNum(Get(B_1796, "b"))) + (((ToNum(y0_1920) - (YB_1807 - ToNum(Get(B_1796, "b")))) * j_1929) / 6D)))), ((V)((-1D)))));
j_1929++;
}
}
Invoke(Y_1922, "forEach", Fn((V _arrowThis1943, int _argc1931, V _a1933, V j_1937, V _a1935, V _a1936, V[] _rest1932) => {
double yy_1944 = 0;
V x_1945 = default;
double z_1946 = 0;
V n_1947 = default;
V y_1940 = default;
V sg_1942 = default;
{ V _t1938 = ListOf(_a1933);
{ V _t1939 = GetIdx(_t1938, 0D);
y_1940 = _t1939; }
{ V _t1941 = GetIdx(_t1938, 1D);
sg_1942 = _t1941; }
}
yy_1944 = Min(ToNum(y_1940), (YB_1807 - 0.02));
x_1945 = Add(Call(xl_1808, V.Undef, ((V)(yy_1944))), ((V)((ToNum(u_1917) * (ToNum(Call(xr_1809, V.Undef, ((V)(yy_1944)))) - ToNum(Call(xl_1808, V.Undef, ((V)(yy_1944)))))))));
z_1946 = (ToNum(sg_1942) * ToNum(Call(zF_1800, V.Undef, x_1945, ((V)(yy_1944)))));
n_1947 = Call(nrm_1812, V.Undef, x_1945, ((V)(yy_1944)), ((V)(z_1946)));
Invoke(P_1921, "push", NewObj(3).Put("p", Call(P3_1798, V.Undef, x_1945, ((V)(yy_1944)), ((V)(z_1946)))).Put("f", Invoke(D_1797, "facing", x_1945, ((V)(yy_1944)), ((V)(z_1946)), GetIdx(n_1947, 0D), GetIdx(n_1947, 1D), GetIdx(n_1947, 2D))).Put("rim", ((GtN(j_1937, 6D) && LtN(j_1937, 19D)) ? V.True : V.False)).V);
return default;
}, 2, "", true));
return P_1921;
return default;
}, 1, "", true);
L_1814 = Arr();
{
double i_1948 = 0;
i_1948 = 0D;
while (true) {
if (!((i_1948 <= NU_1810))) break;
Invoke(L_1814, "push", Call(line_1813, V.Undef, ((V)((i_1948 / NU_1810)))));
i_1948++;
}
}
lerp_1815 = Fn((V _arrowThis1959, int _argc1950, V a_1956, V c_1957, V t_1958, V _a1955, V[] _rest1951) => {
return Arr(Add(GetIdx(a_1956, 0D), ((V)(((ToNum(GetIdx(c_1957, 0D)) - ToNum(GetIdx(a_1956, 0D))) * ToNum(t_1958))))), Add(GetIdx(a_1956, 1D), ((V)(((ToNum(GetIdx(c_1957, 1D)) - ToNum(GetIdx(a_1956, 1D))) * ToNum(t_1958))))));
}, 3, "", true);
dS_1816 = new JsStrBuf("");
dR_1817 = new JsStrBuf("");
{
double i_1960 = 0;
i_1960 = 0D;
while (true) {
if (!((i_1960 < NU_1810))) break;
V A_1962 = default;
V C_1963 = default;
V G_1964 = default;
V n_1965 = default;
double G0_1966 = 0;
V j0_1967 = default;
V j1_1968 = default;
V side_1969 = default;
V sa_1970 = default;
V sc_1971 = default;
V ra_1972 = default;
V rc_1973 = default;
A_1962 = GetIdx(L_1814, i_1960);
C_1963 = GetIdx(L_1814, (i_1960 + 1D));
G_1964 = Invoke(A_1962, "map", Fn((V _arrowThis1982, int _argc1974, V q_1980, V j_1981, V _a1978, V _a1979, V[] _rest1975) => {
return ((V)((ToNum(Add(Get(q_1980, "f"), Get(GetK(C_1963, j_1981), "f"))) / 2D)));
}, 2, "", true));
n_1965 = Get(G_1964, "length");
G0_1966 = 0.05;
j0_1967 = Invoke(G_1964, "findIndex", Fn((V _arrowThis1990, int _argc1983, V g_1989, V _a1986, V _a1987, V _a1988, V[] _rest1984) => {
return (GtN(g_1989, G0_1966) ? V.True : V.False);
}, 1, "", true));
if (LtN(j0_1967, 0D)) {
goto _cont1961;
}
j1_1968 = j0_1967;
while ((Lt(Add(j1_1968, ((V)(1D))), n_1965) && GtN(GetK(G_1964, Add(j1_1968, ((V)(1D)))), G0_1966))) {
PostInc(ref j1_1968, 1D);
}
side_1969 = Fn((V _arrowThis1999, int _argc1991, V pick_1997, V rimOnly_1998, V _a1995, V _a1996, V[] _rest1992) => {
V o_2000 = default;
V a0_2001 = default;
V a1_2002 = default;
V cut_2003 = default;
o_2000 = Arr();
a0_2001 = j0_1967;
a1_2002 = j1_1968;
if (Truthy(rimOnly_1998)) {
while ((Le(a0_2001, a1_2002) && !(Truthy(Get(GetK(A_1962, a0_2001), "rim"))))) {
PostInc(ref a0_2001, 1D);
}
while ((Ge(a1_2002, a0_2001) && !(Truthy(Get(GetK(A_1962, a1_2002), "rim"))))) {
PostInc(ref a1_2002, -1D);
}
if (Gt(a0_2001, a1_2002)) {
return V.Null;
}
}
cut_2003 = Fn((V _arrowThis2012, int _argc2004, V j_2010, V k_2011, V _a2008, V _a2009, V[] _rest2005) => {
double t_2013 = 0;
t_2013 = ((ToNum(GetK(G_1964, j_2010)) - G0_1966) / ToNum((((V)((ToNum(GetK(G_1964, j_2010)) - ToNum(GetK(G_1964, k_2011))))) is var _t2014 && Truthy(_t2014) ? _t2014 : ((V)(1D)))));
return Call(lerp_1815, V.Undef, Get(GetK(pick_1997, j_2010), "p"), Get(GetK(pick_1997, k_2011), "p"), Call(clamp_12, V.Undef, ((V)(t_2013)), ((V)(0D)), ((V)(1D))));
return default;
}, 2, "", true);
if ((!(Truthy(rimOnly_1998)) && GtN(j0_1967, 0D))) {
Invoke(o_2000, "push", Call(cut_2003, V.Undef, j0_1967, ((V)((ToNum(j0_1967) - 1D)))));
}
{
V j_2015 = default;
j_2015 = a0_2001;
while (true) {
if (!(Le(j_2015, a1_2002))) break;
Invoke(o_2000, "push", Get(GetK(pick_1997, j_2015), "p"));
PostInc(ref j_2015, 1D);
}
}
if ((!(Truthy(rimOnly_1998)) && LtN(j1_1968, (ToNum(n_1965) - 1D)))) {
Invoke(o_2000, "push", Call(cut_2003, V.Undef, j1_1968, Add(j1_1968, ((V)(1D)))));
}
return o_2000;
return default;
}, 2, "", true);
sa_1970 = Call(side_1969, V.Undef, A_1962);
sc_1971 = Call(side_1969, V.Undef, C_1963);
dS_1816.V(Call(polyW_18, V.Undef, Invoke(sa_1970, "concat", Invoke(Invoke(sc_1971, "slice"), "reverse"))));
ra_1972 = Call(side_1969, V.Undef, A_1962, ((V)(1D)));
rc_1973 = Call(side_1969, V.Undef, C_1963, ((V)(1D)));
if (Truthy(((ra_1972 is var _t2017 && !Truthy(_t2017) ? _t2017 : rc_1973) is var _t2018 && !Truthy(_t2018) ? _t2018 : (GtN(Get(ra_1972, "length"), 1D) ? V.True : V.False)))) {
dR_1817.V(Call(polyW_18, V.Undef, Invoke(ra_1972, "concat", Invoke(Invoke(rc_1973, "slice"), "reverse"))));
}
_cont1961: ;
i_1960++;
}
}
Call(set_1799, V.Undef, Get(W_1806, "st"), ((V)("d")), (((V)(dS_1816.Str)) is var _t2019 && Truthy(_t2019) ? _t2019 : ((V)("M0 0"))));
Call(set_1799, V.Undef, Get(W_1806, "rim"), ((V)("d")), (((V)(dR_1817.Str)) is var _t2020 && Truthy(_t2020) ? _t2020 : ((V)("M0 0"))));
fr2_1818 = (Ge(Get(GetIdx(GetIdx(L_1814, ((double)(ToInt32(NU_1810) >> (int)(ToUint32(1D) & 31)))), 0D), "f"), Get(GetIdx(GetIdx(L_1814, ((double)(ToInt32(NU_1810) >> (int)(ToUint32(1D) & 31)))), 24D), "f")) ? V.True : V.False);
ti_1819 = (Truthy(fr2_1818) ? 0D : 24D);
Call(set_1799, V.Undef, Get(W_1806, "edge"), ((V)("d")), (Call(runs_21, V.Undef, Invoke(L_1814, "map", Fn((V _arrowThis2028, int _argc2021, V P_2027, V _a2024, V _a2025, V _a2026, V[] _rest2022) => {
return Get(GetIdx(P_2027, ti_1819), "p");
}, 1, "", true)), Invoke(L_1814, "map", Fn((V _arrowThis2036, int _argc2029, V P_2035, V _a2032, V _a2033, V _a2034, V[] _rest2030) => {
return (GtN(Get(GetIdx(P_2035, ti_1819), "f"), 0.05) ? V.True : V.False);
}, 1, "", true))) is var _t2037 && Truthy(_t2037) ? _t2037 : ((V)("M0 0"))));
fd_1820 = new JsStrBuf("");
Invoke(Arr(((V)(0.084)), ((V)(0.216)), ((V)(0.354)), ((V)(0.495)), ((V)(0.641)), ((V)(0.781)), ((V)(0.916))), "forEach", Fn((V _arrowThis2045, int _argc2038, V u_2044, V _a2041, V _a2042, V _a2043, V[] _rest2039) => {
V P_2046 = default;
P_2046 = Call(line_1813, V.Undef, u_2044);
fd_1820.V(Call(runs_21, V.Undef, Invoke(P_2046, "map", Fn((V _arrowThis2054, int _argc2047, V q_2053, V _a2050, V _a2051, V _a2052, V[] _rest2048) => {
return Get(q_2053, "p");
}, 1, "", true)), Invoke(P_2046, "map", Fn((V _arrowThis2063, int _argc2055, V q_2061, V j_2062, V _a2059, V _a2060, V[] _rest2056) => {
return (((GtN(Get(q_2061, "f"), 0.08) && GtN(j_2062, 0D)) && LtN(j_2062, 24D)) ? V.True : V.False);
}, 2, "", true))));
return default;
}, 1, "", true));
Call(set_1799, V.Undef, Get(W_1806, "fib"), ((V)("d")), (((V)(fd_1820.Str)) is var _t2064 && Truthy(_t2064) ? _t2064 : ((V)("M0 0"))));
PS_1821 = Call(line_1813, V.Undef, ((V)((Truthy(fr2_1818) ? 0.06 : 0.94))));
sj_1822 = (Truthy(fr2_1818) ? Arr(((V)(1D)), ((V)(5D))) : Arr(((V)(19D)), ((V)(23D))));
Call(set_1799, V.Undef, Get(W_1806, "shn"), ((V)("d")), (Call(runs_21, V.Undef, Invoke(PS_1821, "map", Fn((V _arrowThis2072, int _argc2065, V q_2071, V _a2068, V _a2069, V _a2070, V[] _rest2066) => {
return Get(q_2071, "p");
}, 1, "", true)), Invoke(PS_1821, "map", Fn((V _arrowThis2081, int _argc2073, V q_2079, V j_2080, V _a2077, V _a2078, V[] _rest2074) => {
return (((GtN(Get(q_2079, "f"), 0.05) && Ge(j_2080, GetIdx(sj_1822, 0D))) && Le(j_2080, GetIdx(sj_1822, 1D))) ? V.True : V.False);
}, 2, "", true))) is var _t2082 && Truthy(_t2082) ? _t2082 : ((V)("M0 0"))));
kS_1823 = Get(D_1797, "kS");
M2_1824 = Fn((V _arrowThis2091, int _argc2083, V a_2089, V c_2090, V _a2087, V _a2088, V[] _rest2084) => {
return Arr(((V)((ToNum(Add(GetIdx(a_2089, 0D), GetIdx(c_2090, 0D))) / 2D))), ((V)((ToNum(Add(GetIdx(a_2089, 1D), GetIdx(c_2090, 1D))) / 2D))));
}, 2, "", true);
flk_1825 = Fn((V _arrowThis2101, int _argc2092, V o_2098, V C_2099, V r_2100, V _a2097, V[] _rest2093) => {
V P_2102 = default;
JsStrBuf d_2103 = null;
P_2102 = Arr();
{
double i_2104 = 0;
i_2104 = 0D;
while (true) {
if (!((i_2104 < 7D))) break;
double a_2106 = 0;
double rr_2107 = 0;
double x_2108 = 0;
double y_2109 = 0;
a_2106 = ((i_2104 * TAU_9) / 7D);
rr_2107 = (ToNum(r_2100) * (0.72 + (0.5 * ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(Get(o_2098, "k")) * 7D) + i_2104))))))));
x_2108 = ((rr_2107 * FdLibm.Cos(a_2106)) * 1.32);
y_2109 = ((rr_2107 * FdLibm.Sin(a_2106)) * 0.74);
Invoke(P_2102, "push", Arr(((V)((ToNum(Add(GetIdx(C_2099, 0D), ((V)((x_2108 * FdLibm.Cos(ToNum(Get(o_2098, "rot")))))))) - (y_2109 * FdLibm.Sin(ToNum(Get(o_2098, "rot"))))))), Add(Add(GetIdx(C_2099, 1D), ((V)((x_2108 * FdLibm.Sin(ToNum(Get(o_2098, "rot"))))))), ((V)((y_2109 * FdLibm.Cos(ToNum(Get(o_2098, "rot")))))))));
i_2104++;
}
}
d_2103 = new JsStrBuf(JsStrBuf.Begin().S("M").V(Call(pt_15, V.Undef, Call(M2_1824, V.Undef, GetIdx(P_2102, 6D), GetIdx(P_2102, 0D)))).End());
{
double i_2110 = 0;
i_2110 = 0D;
while (true) {
if (!((i_2110 < 7D))) break;
d_2103.S("Q").V(Call(pt_15, V.Undef, GetIdx(P_2102, i_2110))).S(" ").V(Call(pt_15, V.Undef, Call(M2_1824, V.Undef, GetIdx(P_2102, i_2110), GetIdx(P_2102, ((i_2110 + 1D) % 7D)))));
i_2110++;
}
}
return ((V)(string.Concat(d_2103.Str, "Z")));
return default;
}, 3, "", true);
fatL_1826 = Fn((V _arrowThis2121, int _argc2112, V o_2118, V C_2119, V r_2120, V _a2117, V[] _rest2113) => {
V q_2122 = default;
q_2122 = Fn((V _arrowThis2131, int _argc2123, V x_2129, V y_2130, V _a2127, V _a2128, V[] _rest2124) => {
return Arr(((V)((ToNum(Add(GetIdx(C_2119, 0D), ((V)((ToNum(x_2129) * FdLibm.Cos(ToNum(Get(o_2118, "rot")))))))) - (ToNum(y_2130) * FdLibm.Sin(ToNum(Get(o_2118, "rot"))))))), Add(Add(GetIdx(C_2119, 1D), ((V)((ToNum(x_2129) * FdLibm.Sin(ToNum(Get(o_2118, "rot"))))))), ((V)((ToNum(y_2130) * FdLibm.Cos(ToNum(Get(o_2118, "rot"))))))));
}, 2, "", true);
return ((V)(JsStrBuf.Begin().S("M").V(Call(pt_15, V.Undef, Call(q_2122, V.Undef, ((V)(((-0.75) * ToNum(r_2120)))), ((V)(((-0.2) * ToNum(r_2120))))))).S("Q").V(Call(pt_15, V.Undef, Call(q_2122, V.Undef, ((V)(0D)), ((V)((0.12 * ToNum(r_2120))))))).S(" ").V(Call(pt_15, V.Undef, Call(q_2122, V.Undef, ((V)((0.72 * ToNum(r_2120)))), ((V)(((-0.14) * ToNum(r_2120))))))).S("M").V(Call(pt_15, V.Undef, Call(q_2122, V.Undef, ((V)(((-0.55) * ToNum(r_2120)))), ((V)((0.22 * ToNum(r_2120))))))).S("Q").V(Call(pt_15, V.Undef, Call(q_2122, V.Undef, ((V)(0D)), ((V)((0.5 * ToNum(r_2120))))))).S(" ").V(Call(pt_15, V.Undef, Call(q_2122, V.Undef, ((V)((0.5 * ToNum(r_2120)))), ((V)((0.26 * ToNum(r_2120))))))).End()));
return default;
}, 3, "", true);
Call(set_1799, V.Undef, Get(B_1796, "shd"), ((V)("d")), Call(ellD_20, V.Undef, Call(P3_1798, V.Undef, ((V)(50D)), ((V)(20D)), ((V)(0D))), ((V)((((8.6 * ToNum(kS_1823)) * Max(0.35, System.Math.Abs(ToNum(Get(D_1797, "front"))))) + (2.2 * ToNum(kS_1823))))), ((V)((1.7 * ToNum(kS_1823)))), ((V)(0D))));
Invoke(SN_43, "order", Get(B_1796, "SAL"), Invoke(Invoke(Get(B_1796, "FK"), "map", Fn((V _arrowThis2148, int _argc2141, V o_2147, V _a2144, V _a2145, V _a2146, V[] _rest2142) => {
double up_2149 = 0;
V x_2150 = default;
double y_2151 = 0;
V C_2152 = default;
double r_2153 = 0;
up_2149 = (ToNum(umeV_1801) * (5D + (3D * ToNum(Call(rnd_22, V.Undef, ((V)((ToNum(Get(o_2147, "k")) * 5.3))))))));
x_2150 = Add(Get(o_2147, "x"), ((V)((((ToNum(Get(o_2147, "x")) - 50D) * 0.18) * ToNum(umeV_1801)))));
y_2151 = (ToNum(Get(o_2147, "y")) - up_2149);
C_2152 = Call(P3_1798, V.Undef, x_2150, ((V)(y_2151)), Get(o_2147, "z"));
r_2153 = (ToNum(Get(o_2147, "r")) * ToNum(kS_1823));
Call(set_1799, V.Undef, Get(o_2147, "b"), ((V)("d")), Call(flk_1825, V.Undef, o_2147, C_2152, ((V)(r_2153))));
if (Truthy(Get(o_2147, "f"))) {
Call(set_1799, V.Undef, Get(o_2147, "f"), ((V)("d")), Call(fatL_1826, V.Undef, o_2147, C_2152, ((V)(r_2153))));
}
return NewObj(3).Put("id", ((V)(JsStrBuf.Begin().S("f").V(Get(o_2147, "k")).End()))).Put("e", Get(o_2147, "g")).Put("z", Invoke(D_1797, "Z3", x_2150, ((V)(y_2151)), Get(o_2147, "z"))).V;
return default;
}, 1, "", true)), "sort", Fn((V _arrowThis2140, int _argc2132, V a_2138, V b_2139, V _a2136, V _a2137, V[] _rest2133) => {
return ((V)((ToNum(Get(a_2138, "z")) - ToNum(Get(b_2139, "z")))));
}, 2, "", true)));
return default;
}, 2, "draw", false)).V);
slabD_47 = Fn((V _arrowThis2165, int _argc2154, V D_2160, V Q_2161, V zf_2162, V zb_2163, V[] _rest2155) => {
V F_2166 = default;
V K_2167 = default;
V d_2168 = default;
V W_2164 = default;
W_2164 = (_argc2154 > 4 ? _rest2155[0] : V.Undef);
W_2164 = (W_2164 is var _t2169 && Truthy(_t2169) ? _t2169 : Get(D_2160, "P3"));
F_2166 = Invoke(Q_2161, "map", Fn((V _arrowThis2177, int _argc2170, V p_2176, V _a2173, V _a2174, V _a2175, V[] _rest2171) => {
return Call(W_2164, V.Undef, GetIdx(p_2176, 0D), GetIdx(p_2176, 1D), zf_2162);
}, 1, "", true));
K_2167 = Invoke(Q_2161, "map", Fn((V _arrowThis2185, int _argc2178, V p_2184, V _a2181, V _a2182, V _a2183, V[] _rest2179) => {
return Call(W_2164, V.Undef, GetIdx(p_2184, 0D), GetIdx(p_2184, 1D), zb_2163);
}, 1, "", true));
d_2168 = Add(Call(polyW_18, V.Undef, F_2166), Call(polyW_18, V.Undef, K_2167));
{
double i_2186 = 0;
i_2186 = 0D;
while (true) {
if (!(Lt(((V)(i_2186)), Get(Q_2161, "length")))) break;
double j_2188 = 0;
j_2188 = ((i_2186 + 1D) % ToNum(Get(Q_2161, "length")));
d_2168 = Add(d_2168, Call(polyW_18, V.Undef, Arr(GetIdx(F_2166, i_2186), GetIdx(F_2166, j_2188), GetIdx(K_2167, j_2188), GetIdx(K_2167, i_2186))));
i_2186++;
}
}
return d_2168;
return default;
}, 5, "", true);
Set(Get(SN_43, "h"), "slabD", slabD_47);
PEf_48 = Fn((V _arrowThis2198, int _argc2189, V D_2195, V EL_2196, V rT_2197, V _a2194, V[] _rest2190) => {
return Fn((V _arrowThis2208, int _argc2199, V x_2205, V y_2206, V z_2207, V _a2204, V[] _rest2200) => {
V p_2209 = default;
p_2209 = Invoke(D_2195, "P3", x_2205, y_2206, z_2207);
return Arr(GetIdx(p_2209, 0D), Add(GetIdx(p_2209, 1D), ((V)((ToNum(EL_2196) * (ToNum(Invoke(D_2195, "Z3", x_2205, y_2206, z_2207)) - ToNum(Call(rT_2197, V.Undef, y_2206))))))));
return default;
}, 3, "", true);
}, 3, "", true);
Set(MODELS_42, "toco", NewObj(2).Put("setup", Fn((V _self2210, int _argc2211, V S_2217, V _a2214, V _a2215, V _a2216, V[] _rest2212) => {
V sk_2218 = default;
V O_2219 = default;
double th_2220 = 0;
double W0_2221 = 0;
V Wy_2222 = default;
V lt_2223 = default;
V mt_2224 = default;
V LF_2225 = default;
V MF_2226 = default;
V SG_2227 = default;
V back_2228 = default;
V FG_2229 = default;
V F_2230 = default;
V add_2231 = default;
V sp_2232 = default;
V hl_2233 = default;
if (_self2210.IsNullish) _self2210 = GlobalV;
{ V _t2234 = S_2217;
if (_t2234.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t2234));
{ V _t2235 = Get(_t2234, "sk");
sk_2218 = _t2235; } }
O_2219 = Invoke(S_2217, "outline", sk_2218, ((V)(64D)));
th_2220 = 1.5;
W0_2221 = 9.5;
Wy_2222 = Fn((V _arrowThis2243, int _argc2236, V y_2242, V _a2239, V _a2240, V _a2241, V[] _rest2237) => {
return ((V)((W0_2221 * Pow(ToNum(Call(clamp_12, V.Undef, ((V)(((87.5 - ToNum(y_2242)) / 45.5))), ((V)(0D)), ((V)(1D)))), 0.85))));
}, 1, "", true);
lt_2223 = GetIdx(Invoke(S_2217, "hide", Fn((V _arrowThis2251, int _argc2244, V q_2250, V _a2247, V _a2248, V _a2249, V[] _rest2245) => {
return (((Get(q_2250, "inBody") is var _t2252 && !Truthy(_t2252) ? _t2252 : Invoke(NewRegExp(RX2, "^url", ""), "test", Invoke(S_2217, "f", q_2250))) is var _t2253 && !Truthy(_t2253) ? _t2253 : (SEqS(Get(q_2250, "tag"), "path") ? V.True : V.False)) is var _t2254 && !Truthy(_t2254) ? _t2254 : Invoke(NewRegExp(RX4, "^M12\\.00 88", ""), "test", Invoke(S_2217, "d", q_2250)));
}, 1, "", true)), 0D);
mt_2224 = GetIdx(Invoke(S_2217, "hide", Fn((V _arrowThis2262, int _argc2255, V q_2261, V _a2258, V _a2259, V _a2260, V[] _rest2256) => {
return (Get(q_2261, "inBody") is var _t2263 && !Truthy(_t2263) ? _t2263 : Invoke(NewRegExp(RX5, "^M11\\.50 88", ""), "test", Invoke(S_2217, "d", q_2261)));
}, 1, "", true)), 0D);
Invoke(S_2217, "hide", Fn((V _arrowThis2271, int _argc2264, V q_2270, V _a2267, V _a2268, V _a2269, V[] _rest2265) => {
return (Get(q_2270, "inBody") is var _t2272 && !Truthy(_t2272) ? _t2272 : ((((SEqS(Get(q_2270, "tag"), "rect") || SEqS(Invoke(S_2217, "s", q_2270), "#ffb02e")) || SEqS(Invoke(S_2217, "f", q_2270), "#d9952a")) || SEqS(Invoke(S_2217, "s", q_2270), "#fff6cf")) ? V.True : V.False));
}, 1, "", true));
LF_2225 = (Truthy(lt_2223) ? Invoke(S_2217, "f", lt_2223) : ((V)("#86d24e")));
MF_2226 = (Truthy(mt_2224) ? Invoke(S_2217, "f", mt_2224) : ((V)("#8a4526")));
SG_2227 = Invoke(S_2217, "g", Get(S_2217, "par"), Get(sk_2218, "e"));
Invoke(SG_2227, "appendChild", Get(sk_2218, "e"));
back_2228 = Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", Invoke(S_2217, "f", sk_2218)).V, SG_2227, Get(sk_2218, "e"));
FG_2229 = Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, SG_2227, Get(sk_2218, "e"));
F_2230 = Arr();
add_2231 = Fn((V _arrowThis2284, int _argc2273, V a_2279, V kind_2280, V dz_2281, V r_2282, V[] _rest2274) => {
V id_2283 = default;
id_2283 = (_argc2273 > 4 ? _rest2274[0] : V.Undef);
return Invoke(F_2230, "push", NewObj(6).Put("a", a_2279).Put("kind", kind_2280).Put("dz", dz_2281).Put("r", r_2282).Put("id", Add(kind_2280, Get(F_2230, "length"))).Put("e", Call(el_14, V.Undef, ((V)("path")), (SEqS(kind_2280, "l") ? NewObj(4).Put("fill", LF_2225).Put("stroke", ((V)("#4d9a2a"))).Put("stroke-width", ((V)(0.45))).Put("stroke-opacity", ((V)(0.55))).V : (SEqS(kind_2280, "m") ? NewObj(1).Put("fill", MF_2226).V : (SEqS(kind_2280, "t") ? NewObj(1).Put("fill", ((V)("#ff5a4a"))).V : NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffb02e"))).Put("stroke-width", ((V)(1.5))).Put("stroke-linecap", ((V)("round"))).V))), FG_2229)).V);
}, 5, "", true);
{
double i_2285 = 0;
i_2285 = 0D;
while (true) {
if (!((i_2285 < 13D))) break;
Call(add_2231, V.Undef, ((V)((0.08 + (i_2285 * 0.07)))), ((V)("m")), ((V)(((NumTruthy((i_2285 % 2D)) ? 1D : (-1D)) * 0.3))), ((V)(3.6)));
i_2285++;
}
}
{
double i_2287 = 0;
i_2287 = 0D;
while (true) {
if (!((i_2287 < 30D))) break;
Call(add_2231, V.Undef, ((V)((0.025 + (i_2287 * 0.0328)))), ((V)("l")), GetIdx(Arr(((V)((-0.45))), ((V)(0.1)), ((V)(0.5)), ((V)((-0.1))), ((V)(0.35)), ((V)((-0.35)))), (i_2287 % 6D)), ((V)((3.3 + ((i_2287 % 3D) * 0.45)))));
i_2287++;
}
}
Invoke(Arr(Arr(((V)(0.16)), ((V)(0.2))), Arr(((V)(0.36)), ((V)((-0.3)))), Arr(((V)(0.62)), ((V)(0.3))), Arr(((V)(0.84)), ((V)((-0.2))))), "forEach", Fn((V _arrowThis2300, int _argc2289, V _a2291, V _a2292, V _a2293, V _a2294, V[] _rest2290) => {
V a_2297 = default;
V dz_2299 = default;
{ V _t2295 = ListOf(_a2291);
{ V _t2296 = GetIdx(_t2295, 0D);
a_2297 = _t2296; }
{ V _t2298 = GetIdx(_t2295, 1D);
dz_2299 = _t2298; }
}
return Call(add_2231, V.Undef, a_2297, ((V)("t")), dz_2299, ((V)(2.7)));
}, 1, "", true));
Invoke(Arr(Arr(((V)(0.24)), ((V)(0.1))), Arr(((V)(0.5)), ((V)((-0.2)))), Arr(((V)(0.7)), ((V)(0.25))), Arr(((V)(0.92)), ((V)(0D)))), "forEach", Fn((V _arrowThis2312, int _argc2301, V _a2303, V _a2304, V _a2305, V _a2306, V[] _rest2302) => {
V a_2309 = default;
V dz_2311 = default;
{ V _t2307 = ListOf(_a2303);
{ V _t2308 = GetIdx(_t2307, 0D);
a_2309 = _t2308; }
{ V _t2310 = GetIdx(_t2307, 1D);
dz_2311 = _t2310; }
}
return Call(add_2231, V.Undef, a_2309, ((V)("c")), dz_2311, ((V)(2.4)));
}, 1, "", true));
sp_2232 = Invoke(S_2217, "path", NewObj(2).Put("fill", ((V)("#d9952a"))).Put("opacity", ((V)(0.5))).V);
hl_2233 = Invoke(S_2217, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#fff6cf"))).Put("stroke-width", ((V)(1.2))).Put("opacity", ((V)(0.7))).Put("stroke-linecap", ((V)("round"))).V);
return NewObj(16).Put("O", O_2219).Put("th", ((V)(th_2220))).Put("Wy", Wy_2222).Put("SG", SG_2227).Put("back", back_2228).Put("FG", FG_2229).Put("F", F_2230).Put("sp", sp_2232).Put("hl", hl_2233).Put("slab", ((V)(1D))).Put("rx", ((V)(38D))).Put("ya", ((V)(44D))).Put("yb", ((V)(86D))).Put("rT", Fn((V _arrowThis2320, int _argc2313, V y_2319, V _a2316, V _a2317, V _a2318, V[] _rest2314) => {
return Call(halfW_38, V.Undef, O_2219, y_2319);
}, 1, "rT", true)).Put("zAt", Fn((V _arrowThis2329, int _argc2321, V x_2327, V y_2328, V _a2325, V _a2326, V[] _rest2322) => {
return Add(Call(Wy_2222, V.Undef, y_2328), ((V)(th_2220)));
}, 2, "zAt", true)).Put("zE", Fn((V _arrowThis2338, int _argc2330, V dx_2336, V dy_2337, V _a2334, V _a2335, V[] _rest2331) => {
return Add(Add(Call(Wy_2222, V.Undef, Add(Get(S_2217, "HY"), dy_2337)), ((V)(th_2220))), ((V)(0.3)));
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self2339, int _argc2340, V B_2346, V D_2347, V _a2344, V _a2345, V[] _rest2341) => {
V P3_2348 = default;
V Z3_2349 = default;
V set_2350 = default;
V snap_2351 = default;
double k_2352 = 0;
V W_2353 = default;
V th_2354 = default;
V fr_2355 = default;
V sh_2356 = default;
V L_2357 = default;
double s_2358 = 0;
V SP_2359 = default;
V hp_2360 = default;
if (_self2339.IsNullish) _self2339 = GlobalV;
{ V _t2361 = D_2347;
if (_t2361.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t2361));
{ V _t2362 = Get(_t2361, "P3");
P3_2348 = _t2362; }
{ V _t2363 = Get(_t2361, "Z3");
Z3_2349 = _t2363; }
{ V _t2364 = Get(_t2361, "set");
set_2350 = _t2364; } }
snap_2351 = Call(clamp_12, V.Undef, Invoke(D_2347, "bv", ((V)("snap"))), ((V)((-0.8))), ((V)(1.6)));
k_2352 = (1D + (ToNum(snap_2351) * 0.6));
W_2353 = Fn((V _arrowThis2372, int _argc2365, V y_2371, V _a2368, V _a2369, V _a2370, V[] _rest2366) => {
return ((V)((ToNum(Invoke(B_2346, "Wy", y_2371)) * k_2352)));
}, 1, "", true);
th_2354 = Get(B_2346, "th");
fr_2355 = (GeN(Get(D_2347, "front"), 0D) ? V.True : V.False);
sh_2356 = Fn((V _arrowThis2380, int _argc2373, V sg_2379, V _a2376, V _a2377, V _a2378, V[] _rest2374) => {
V o_2381 = default;
o_2381 = Arr();
Invoke(Get(B_2346, "O"), "forEach", Fn((V _arrowThis2389, int _argc2382, V p_2388, V _a2385, V _a2386, V _a2387, V[] _rest2383) => {
V z_2390 = default;
z_2390 = Call(W_2353, V.Undef, GetIdx(p_2388, 1D));
Invoke(o_2381, "push", Call(P3_2348, V.Undef, GetIdx(p_2388, 0D), GetIdx(p_2388, 1D), ((V)((ToNum(sg_2379) * ToNum(z_2390))))));
Invoke(o_2381, "push", Call(P3_2348, V.Undef, GetIdx(p_2388, 0D), GetIdx(p_2388, 1D), ((V)((ToNum(sg_2379) * ToNum(Add(z_2390, th_2354)))))));
return default;
}, 1, "", true));
return Invoke(D_2347, "hull", o_2381);
return default;
}, 1, "", true);
Set(B_2346, "d", Call(sh_2356, V.Undef, ((V)(1D))));
Call(set_2350, V.Undef, Get(B_2346, "back"), ((V)("d")), Call(sh_2356, V.Undef, ((V)((-1D)))));
L_2357 = Invoke(Invoke(Get(B_2346, "F"), "map", Fn((V _arrowThis2408, int _argc2400, V o_2406, V i_2407, V _a2404, V _a2405, V[] _rest2401) => {
double a_2409 = 0;
double @out_2410 = 0;
double wob_2411 = 0;
double x_2412 = 0;
double y_2413 = 0;
double z_2414 = 0;
V C_2415 = default;
double r_2416 = 0;
a_2409 = (System.Math.PI * (1D - ToNum(Get(o_2406, "a"))));
@out_2410 = (SEqS(Get(o_2406, "kind"), "l") ? (1.8 + ((ToNum(Get(o_2406, "r")) - 3.3) * 1.4)) : (SEqS(Get(o_2406, "kind"), "m") ? 1.2 : (SEqS(Get(o_2406, "kind"), "t") ? 3.4 : 4.2)));
wob_2411 = ((FdLibm.Sin(((ToNum(Get(D_2347, "ts")) * 3D) + (ToNum(i_2407) * 1.7))) * 0.4) + ((ToNum(snap_2351) * FdLibm.Sin(ToNum(Add(((V)((ToNum(Get(D_2347, "ts")) * 18D))), i_2407)))) * 0.8));
x_2412 = ((50D + ((38D + @out_2410) * FdLibm.Cos(a_2409))) + (ToNum(Get(D_2347, "ox")) * 0.15));
y_2413 = ((86D - (((44D + @out_2410) + wob_2411) * FdLibm.Sin(a_2409))) - (ToNum(Get(D_2347, "oy")) * 0.25));
z_2414 = ((ToNum(Get(o_2406, "dz")) * ToNum(Call(W_2353, V.Undef, ((V)(y_2413))))) * 1.6);
C_2415 = Call(P3_2348, V.Undef, ((V)(x_2412)), ((V)(y_2413)), ((V)(z_2414)));
r_2416 = ((ToNum(Get(o_2406, "r")) * ToNum(Get(D_2347, "kS"))) * ToNum((SEqS(Get(o_2406, "kind"), "l") ? Add(((V)(1D)), Call(clamp_12, V.Undef, ((V)((ToNum(Call(W_2353, V.Undef, ((V)(y_2413)))) / 14D))), ((V)(0D)), ((V)(0.4)))) : ((V)(1D)))));
if (SEqS(Get(o_2406, "kind"), "c")) {
V t_2417 = default;
t_2417 = Arr(((V)(FdLibm.Cos((a_2409 + 1.2)))), ((V)((-FdLibm.Sin((a_2409 + 1.2))))));
Call(set_2350, V.Undef, Get(o_2406, "e"), ((V)("d")), ((V)(JsStrBuf.Begin().S("M").V(Call(pt_15, V.Undef, Arr(((V)((ToNum(GetIdx(C_2415, 0D)) - (ToNum(GetIdx(t_2417, 0D)) * r_2416)))), ((V)((ToNum(GetIdx(C_2415, 1D)) - (ToNum(GetIdx(t_2417, 1D)) * r_2416))))))).S("L").V(Call(pt_15, V.Undef, Arr(Add(GetIdx(C_2415, 0D), ((V)((ToNum(GetIdx(t_2417, 0D)) * r_2416)))), Add(GetIdx(C_2415, 1D), ((V)((ToNum(GetIdx(t_2417, 1D)) * r_2416))))))).End())));
} else {
if (SEqS(Get(o_2406, "kind"), "t")) {
Call(set_2350, V.Undef, Get(o_2406, "e"), ((V)("d")), Call(ellD_20, V.Undef, C_2415, ((V)(r_2416)), ((V)((r_2416 * 0.9))), ((V)((-a_2409)))));
} else {
Call(set_2350, V.Undef, Get(o_2406, "e"), ((V)("d")), Call(circD_19, V.Undef, C_2415, ((V)(r_2416))));
}
}
return NewObj(3).Put("id", Get(o_2406, "id")).Put("e", Get(o_2406, "e")).Put("z", Call(Z3_2349, V.Undef, ((V)(x_2412)), ((V)(y_2413)), ((V)(z_2414)))).V;
return default;
}, 2, "", true)), "sort", Fn((V _arrowThis2399, int _argc2391, V a_2397, V b_2398, V _a2395, V _a2396, V[] _rest2392) => {
return ((V)((ToNum(Get(a_2397, "z")) - ToNum(Get(b_2398, "z")))));
}, 2, "", true));
Invoke(SN_43, "order", Get(B_2346, "FG"), L_2357);
s_2358 = (Truthy(fr_2355) ? 1D : (-1D));
SP_2359 = Arr(Arr(((V)(24D)), ((V)(78D))), Arr(((V)(76D)), ((V)(79D))), Arr(((V)(31D)), ((V)(84D))), Arr(((V)(69D)), ((V)(84D))), Arr(((V)(22D)), ((V)(64D))), Arr(((V)(78D)), ((V)(63D))), Arr(((V)(36D)), ((V)(49D))), Arr(((V)(64D)), ((V)(48D))), Arr(((V)(45D)), ((V)(70D))), Arr(((V)(57D)), ((V)(77D))));
Call(set_2350, V.Undef, Get(B_2346, "sp"), ((V)("d")), Invoke(Invoke(SP_2359, "map", Fn((V _arrowThis2429, int _argc2418, V _a2420, V _a2421, V _a2422, V _a2423, V[] _rest2419) => {
V x_2426 = default;
V y_2428 = default;
{ V _t2424 = ListOf(_a2420);
{ V _t2425 = GetIdx(_t2424, 0D);
x_2426 = _t2425; }
{ V _t2427 = GetIdx(_t2424, 1D);
y_2428 = _t2427; }
}
return Call(circD_19, V.Undef, Call(P3_2348, V.Undef, x_2426, y_2428, ((V)((s_2358 * ToNum(Add(Add(Call(W_2353, V.Undef, y_2428), th_2354), ((V)(0.1)))))))), ((V)((0.8 * ToNum(Get(D_2347, "kS"))))));
}, 1, "", true)), "join", ((V)(""))));
hp_2360 = Arr();
{
double i_2430 = 0;
i_2430 = 0D;
while (true) {
if (!((i_2430 <= 24D))) break;
double a_2432 = 0;
double x_2433 = 0;
double y_2434 = 0;
a_2432 = ((System.Math.PI * i_2430) / 24D);
x_2433 = (50D + (33.5 * FdLibm.Cos(a_2432)));
y_2434 = (86D - (39.5 * FdLibm.Sin(a_2432)));
Invoke(hp_2360, "push", Call(P3_2348, V.Undef, ((V)(x_2433)), ((V)(y_2434)), ((V)((s_2358 * ToNum(Add(Add(Call(W_2353, V.Undef, ((V)(y_2434))), th_2354), ((V)(0.15)))))))));
i_2430++;
}
}
Call(set_2350, V.Undef, Get(B_2346, "hl"), ((V)("d")), Call(runs_21, V.Undef, hp_2360, Invoke(hp_2360, "map", Fn((V _arrowThis2441, int _argc2435, V _a2437, V _a2438, V _a2439, V _a2440, V[] _rest2436) => {
return (true ? V.True : V.False);
}, 0, "", true))));
Invoke(SN_43, "order", Get(B_2346, "SG"), (Truthy(fr_2355) ? Arr(NewObj(2).Put("id", ((V)("b"))).Put("e", Get(B_2346, "back")).V, NewObj(2).Put("id", ((V)("f"))).Put("e", Get(B_2346, "FG")).V, NewObj(2).Put("id", ((V)("s"))).Put("e", Get(Get(Get(B_2346, "S"), "sk"), "e")).V) : Arr(NewObj(2).Put("id", ((V)("s"))).Put("e", Get(Get(Get(B_2346, "S"), "sk"), "e")).V, NewObj(2).Put("id", ((V)("f"))).Put("e", Get(B_2346, "FG")).V, NewObj(2).Put("id", ((V)("b"))).Put("e", Get(B_2346, "back")).V)));
return default;
}, 2, "draw", false)).V);
Set(MODELS_42, "churro", NewObj(2).Put("setup", Fn((V _self2442, int _argc2443, V S_2449, V _a2446, V _a2447, V _a2448, V[] _rest2444) => {
V sk_2450 = default;
V O_2451 = default;
V rT_2452 = default;
V ch_2453 = default;
V CF_2454 = default;
V sh_2455 = default;
V gv_2456 = default;
V cr_2457 = default;
V sug_2458 = default;
V dz_2459 = default;
V dzh_2460 = default;
V cap_2461 = default;
V cg_2462 = default;
V cg2_2463 = default;
V SU_2464 = default;
V DR_2465 = default;
V yd_2466 = default;
V DZ_2467 = default;
V pre_2468 = default;
if (_self2442.IsNullish) _self2442 = GlobalV;
{ V _t2469 = S_2449;
if (_t2469.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t2469));
{ V _t2470 = Get(_t2469, "sk");
sk_2450 = _t2470; } }
O_2451 = Invoke(S_2449, "outline", sk_2450, ((V)(64D)));
rT_2452 = Fn((V _arrowThis2478, int _argc2471, V y_2477, V _a2474, V _a2475, V _a2476, V[] _rest2472) => {
return Call(halfW_38, V.Undef, O_2451, Call(clamp_12, V.Undef, y_2477, ((V)(12.2)), ((V)(86.8))));
}, 1, "", true);
ch_2453 = GetIdx(Invoke(S_2449, "hide", Fn((V _arrowThis2486, int _argc2479, V q_2485, V _a2482, V _a2483, V _a2484, V[] _rest2480) => {
return (Get(q_2485, "inBody") is var _t2487 && !Truthy(_t2487) ? _t2487 : Invoke(NewRegExp(RX6, "^M29 \\d+ L29 22", ""), "test", Invoke(S_2449, "d", q_2485)));
}, 1, "", true)), 0D);
CF_2454 = (Truthy(ch_2453) ? Invoke(S_2449, "f", ch_2453) : ((V)("#5e3620")));
Invoke(S_2449, "hide", Fn((V _arrowThis2495, int _argc2488, V q_2494, V _a2491, V _a2492, V _a2493, V[] _rest2489) => {
return (Get(q_2494, "inBody") is var _t2501 && !Truthy(_t2501) ? _t2501 : (((((Invoke(S_2449, "dk", q_2494, ((V)("dz"))) is var _t2496 && Truthy(_t2496) ? _t2496 : (SEqS(Invoke(S_2449, "s", q_2494), "#9a5420") ? V.True : V.False)) is var _t2497 && Truthy(_t2497) ? _t2497 : (SEqS(Invoke(S_2449, "s", q_2494), "#ffe8c0") ? V.True : V.False)) is var _t2498 && Truthy(_t2498) ? _t2498 : (SEqS(Invoke(S_2449, "s", q_2494), "#b8865e") ? V.True : V.False)) is var _t2499 && Truthy(_t2499) ? _t2499 : (SEqS(Invoke(S_2449, "s", q_2494), "#a87652") ? V.True : V.False)) is var _t2500 && Truthy(_t2500) ? _t2500 : ((SEqS(Get(q_2494, "tag"), "circle") && SEqS(Invoke(S_2449, "f", q_2494), "#ffffff")) ? V.True : V.False)));
}, 1, "", true));
sh_2455 = Invoke(S_2449, "path", NewObj(1).Put("fill", Invoke(S_2449, "lgrad", ((V)("crsh")), Arr(Arr(((V)(0D)), ((V)("#6a3410")), ((V)(0.38))), Arr(((V)(0.16)), ((V)("#6a3410")), ((V)(0.08))), Arr(((V)(0.32)), ((V)("#fff2d0")), ((V)(0.34))), Arr(((V)(0.48)), ((V)("#fff2d0")), ((V)(0D))), Arr(((V)(0.78)), ((V)("#4a2008")), ((V)(0.06))), Arr(((V)(1D)), ((V)("#4a2008")), ((V)(0.42)))))).V);
gv_2456 = Invoke(S_2449, "path", NewObj(6).Put("fill", ((V)("none"))).Put("stroke", ((V)("#9a5420"))).Put("stroke-width", ((V)(1.1))).Put("opacity", ((V)(0.55))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V);
cr_2457 = Invoke(S_2449, "path", NewObj(6).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffe8c0"))).Put("stroke-width", ((V)(0.85))).Put("opacity", ((V)(0.6))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V);
sug_2458 = Invoke(S_2449, "path", NewObj(2).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.9))).V);
dz_2459 = Invoke(S_2449, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#4e2c18"))).Put("stroke-width", ((V)(2.1))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V);
dzh_2460 = Invoke(S_2449, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#9a6a48"))).Put("stroke-width", ((V)(0.6))).Put("opacity", ((V)(0.8))).Put("stroke-linecap", ((V)("round"))).V);
cap_2461 = Invoke(S_2449, "path", NewObj(1).Put("fill", CF_2454).V);
cg_2462 = Invoke(S_2449, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#b8865e"))).Put("stroke-width", ((V)(1.1))).Put("opacity", ((V)(0.7))).Put("stroke-linecap", ((V)("round"))).V);
cg2_2463 = Invoke(S_2449, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#a87652"))).Put("stroke-width", ((V)(1.2))).Put("opacity", ((V)(0.55))).Put("stroke-linecap", ((V)("round"))).V);
SU_2464 = Invoke(Array_from(NewObj(1).Put("length", ((V)(30D))).V, Fn((V _arrowThis2522, int _argc2514, V __2520, V i_2521, V _a2518, V _a2519, V[] _rest2515) => {
return Arr(((V)((ToNum(Call(rnd_22, V.Undef, ((V)((ToNum(i_2521) * 3.1))))) * TAU_9))), ((V)((46D + (ToNum(Call(rnd_22, V.Undef, ((V)((ToNum(i_2521) * 7.7))))) * 38D)))));
}, 2, "", true)), "filter", Fn((V _arrowThis2513, int _argc2502, V _a2504, V _a2505, V _a2506, V _a2507, V[] _rest2503) => {
V f_2510 = default;
V y_2512 = default;
{ V _t2508 = ListOf(_a2504);
{ V _t2509 = GetIdx(_t2508, 0D);
f_2510 = _t2509; }
{ V _t2511 = GetIdx(_t2508, 1D);
y_2512 = _t2511; }
}
return (!((((System.Math.Abs(FdLibm.Atan2(FdLibm.Sin(ToNum(f_2510)), FdLibm.Cos(ToNum(f_2510)))) < 0.62) && GtN(y_2512, 41D)) && LtN(y_2512, 64D))) ? V.True : V.False);
}, 1, "", true));
DR_2465 = Arr(Arr(((V)(0D)), ((V)(6.5)), ((V)(0.17))), Arr(((V)(0.5)), ((V)(2.2)), ((V)(0.13))), Arr(((V)((-0.5))), ((V)(2.4)), ((V)(0.13))), Arr(((V)(0.98)), ((V)(9.5)), ((V)(0.15))), Arr(((V)((-0.98))), ((V)(10.5)), ((V)(0.15))), Arr(((V)(1.75)), ((V)(7D)), ((V)(0.16))), Arr(((V)((-1.8))), ((V)(8.5)), ((V)(0.14))), Arr(((V)(2.5)), ((V)(10D)), ((V)(0.15))), Arr(((V)((-2.55))), ((V)(6.5)), ((V)(0.16))), Arr(((V)(3.14)), ((V)(9D)), ((V)(0.17))));
yd_2466 = Fn((V _arrowThis2530, int _argc2523, V f_2529, V _a2526, V _a2527, V _a2528, V[] _rest2524) => {
double y_2531 = 0;
y_2531 = (37D + (1.2 * FdLibm.Sin(((5D * ToNum(f_2529)) + 0.7))));
Invoke(DR_2465, "forEach", Fn((V _arrowThis2545, int _argc2532, V _a2534, V _a2535, V _a2536, V _a2537, V[] _rest2533) => {
double d_2546 = 0;
V c_2540 = default;
V L_2542 = default;
V w_2544 = default;
{ V _t2538 = ListOf(_a2534);
{ V _t2539 = GetIdx(_t2538, 0D);
c_2540 = _t2539; }
{ V _t2541 = GetIdx(_t2538, 1D);
L_2542 = _t2541; }
{ V _t2543 = GetIdx(_t2538, 2D);
w_2544 = _t2543; }
}
d_2546 = (FdLibm.Atan2(FdLibm.Sin((ToNum(f_2529) - ToNum(c_2540))), FdLibm.Cos((ToNum(f_2529) - ToNum(c_2540)))) / ToNum(w_2544));
if ((System.Math.Abs(d_2546) < 1D)) {
y_2531 = Max(y_2531, (37D + (ToNum(L_2542) * System.Math.Sqrt((1D - (d_2546 * d_2546))))));
}
return default;
}, 1, "", true));
return ((V)(y_2531));
return default;
}, 1, "", true);
DZ_2467 = Arr(Arr(((V)(67D)), ((V)(0.4)), ((V)(1.1))), Arr(((V)(75.2)), ((V)(2.3)), ((V)(4D))), Arr(((V)(83D)), ((V)(4.3)), ((V)(2.6))));
pre_2468 = Fn((V _arrowThis2554, int _argc2547, V P_2553, V _a2550, V _a2551, V _a2552, V[] _rest2548) => {
V c_2555 = default;
c_2555 = Call(clamp_12, V.Undef, (((V)(ToNum(Get(P_2553, "cork")))) is var _t2556 && Truthy(_t2556) ? _t2556 : ((V)(0D))), ((V)((-1.2))), ((V)(1.2)));
return (Truthy(c_2555) ? Object_assign(NewObj(0).V, P_2553, NewObj(2).Put("spin", Add((((V)(ToNum(Get(P_2553, "spin")))) is var _t2557 && Truthy(_t2557) ? _t2557 : ((V)(0D))), ((V)((ToNum(c_2555) * 17D))))).Put("hyaw", Add((((V)(ToNum(Get(P_2553, "hyaw")))) is var _t2558 && Truthy(_t2558) ? _t2558 : ((V)(0D))), ((V)((ToNum(c_2555) * 0.2))))).V) : P_2553);
return default;
}, 1, "", true);
return NewObj(19).Put("O", O_2451).Put("rT", rT_2452).Put("sh", sh_2455).Put("gv", gv_2456).Put("cr", cr_2457).Put("sug", sug_2458).Put("dz", dz_2459).Put("dzh", dzh_2460).Put("cap", cap_2461).Put("cg", cg_2462).Put("cg2", cg2_2463).Put("SU", SU_2464).Put("yd", yd_2466).Put("DZ", DZ_2467).Put("pre", pre_2468).Put("rx", ((V)(21D))).Put("ya", ((V)(22D))).Put("yb", ((V)(82D))).Put("zE", Fn((V _arrowThis2567, int _argc2559, V dx_2565, V dy_2566, V _a2563, V _a2564, V[] _rest2560) => {
V r_2568 = default;
r_2568 = Call(rT_2452, V.Undef, Add(Get(S_2449, "HY"), dy_2566));
return ((V)((System.Math.Sqrt(Max(0D, ((ToNum(r_2568) * ToNum(r_2568)) - (ToNum(dx_2565) * ToNum(dx_2565))))) + 0.3)));
return default;
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self2569, int _argc2570, V B_2576, V D_2577, V _a2574, V _a2575, V[] _rest2571) => {
V P3_2578 = default;
V set_2579 = default;
V rT_2580 = default;
V cork_2581 = default;
V P_2582 = default;
V vis_2583 = default;
V hp_2584 = default;
V fz_2585 = default;
V tw_2586 = default;
JsStrBuf gd_2587 = null;
JsStrBuf cd_2588 = null;
JsStrBuf zd_2589 = null;
JsStrBuf zh_2590 = null;
V A_2591 = default;
if (_self2569.IsNullish) _self2569 = GlobalV;
{ V _t2592 = D_2577;
if (_t2592.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t2592));
{ V _t2593 = Get(_t2592, "P3");
P3_2578 = _t2593; }
{ V _t2594 = Get(_t2592, "set");
set_2579 = _t2594; } }
rT_2580 = Get(B_2576, "rT");
cork_2581 = Call(clamp_12, V.Undef, Invoke(D_2577, "bv", ((V)("cork"))), ((V)((-1.2))), ((V)(1.2)));
P_2582 = Fn((V _arrowThis2604, int _argc2595, V f_2601, V y_2602, V k_2603, V _a2600, V[] _rest2596) => {
double r_2605 = 0;
r_2605 = (ToNum(Call(rT_2580, V.Undef, y_2602)) * ToNum((k_2603 is var _t2606 && Truthy(_t2606) ? _t2606 : ((V)(1D)))));
return Call(P3_2578, V.Undef, ((V)((50D + (r_2605 * FdLibm.Sin(ToNum(f_2601)))))), y_2602, ((V)((r_2605 * FdLibm.Cos(ToNum(f_2601))))));
return default;
}, 3, "", true);
vis_2583 = Fn((V _arrowThis2615, int _argc2607, V f_2613, V y_2614, V _a2611, V _a2612, V[] _rest2608) => {
V r_2616 = default;
r_2616 = Call(rT_2580, V.Undef, y_2614);
return (GtN(Invoke(D_2577, "facing", ((V)((50D + (ToNum(r_2616) * FdLibm.Sin(ToNum(f_2613)))))), y_2614, ((V)((ToNum(r_2616) * FdLibm.Cos(ToNum(f_2613))))), ((V)(FdLibm.Sin(ToNum(f_2613)))), ((V)(0D)), ((V)(FdLibm.Cos(ToNum(f_2613))))), 0.01) ? V.True : V.False);
return default;
}, 2, "", true);
hp_2584 = Arr();
{
double i_2617 = 0;
i_2617 = 0D;
while (true) {
if (!((i_2617 <= 18D))) break;
double y_2619 = 0;
y_2619 = (12.2 + ((74.6 * i_2617) / 18D));
{
double k_2620 = 0;
k_2620 = 0D;
while (true) {
if (!((k_2620 < 24D))) break;
Invoke(hp_2584, "push", Call(P_2582, V.Undef, ((V)(((k_2620 / 24D) * TAU_9))), ((V)(y_2619)), ((V)(1.02))));
k_2620++;
}
}
i_2617++;
}
}
Set(B_2576, "d", Invoke(D_2577, "hull", hp_2584));
Call(set_2579, V.Undef, Get(B_2576, "sh"), ((V)("d")), Get(B_2576, "d"));
fz_2585 = Fn((V _arrowThis2630, int _argc2622, V f_2628, V y_2629, V _a2626, V _a2627, V[] _rest2623) => {
return ((((System.Math.Abs(FdLibm.Atan2(FdLibm.Sin(ToNum(f_2628)), FdLibm.Cos(ToNum(f_2628)))) < 0.6) && GtN(y_2629, 40D)) && LtN(y_2629, 66D)) ? V.True : V.False);
}, 2, "", true);
tw_2586 = Fn((V _arrowThis2638, int _argc2631, V y_2637, V _a2634, V _a2635, V _a2636, V[] _rest2632) => {
return ((V)((((ToNum(cork_2581) * 0.9) * (51D - ToNum(y_2637))) / 75D)));
}, 1, "", true);
gd_2587 = new JsStrBuf("");
cd_2588 = new JsStrBuf("");
{
double k_2639 = 0;
k_2639 = 0D;
while (true) {
if (!((k_2639 < 8D))) break;
V G_2641 = default;
V Go_2642 = default;
V C_2643 = default;
V Co_2644 = default;
G_2641 = Arr();
Go_2642 = Arr();
C_2643 = Arr();
Co_2644 = Arr();
{
double y_2645 = 0;
y_2645 = 39D;
while (true) {
if (!((y_2645 <= 85D))) break;
V fg_2647 = default;
V fc_2648 = default;
fg_2647 = Add(((V)((((k_2639 + 0.5) * TAU_9) / 8D))), Call(tw_2586, V.Undef, ((V)(y_2645))));
fc_2648 = Add(((V)(((k_2639 * TAU_9) / 8D))), Call(tw_2586, V.Undef, ((V)(y_2645))));
Invoke(G_2641, "push", Call(P_2582, V.Undef, fg_2647, ((V)(y_2645)), ((V)(0.985))));
Invoke(Go_2642, "push", (Call(vis_2583, V.Undef, fg_2647, ((V)(y_2645))) is var _t2649 && !Truthy(_t2649) ? _t2649 : (!(Truthy(Call(fz_2585, V.Undef, fg_2647, ((V)(y_2645))))) ? V.True : V.False)));
Invoke(C_2643, "push", Call(P_2582, V.Undef, fc_2648, ((V)(y_2645)), ((V)(1.01))));
Invoke(Co_2644, "push", (Call(vis_2583, V.Undef, fc_2648, ((V)(y_2645))) is var _t2650 && !Truthy(_t2650) ? _t2650 : (!(Truthy(Call(fz_2585, V.Undef, fc_2648, ((V)(y_2645))))) ? V.True : V.False)));
y_2645 = (y_2645 + 2D);
}
}
gd_2587.V(Call(runs_21, V.Undef, G_2641, Go_2642));
cd_2588.V(Call(runs_21, V.Undef, C_2643, Co_2644));
k_2639++;
}
}
Call(set_2579, V.Undef, Get(B_2576, "gv"), ((V)("d")), (((V)(gd_2587.Str)) is var _t2651 && Truthy(_t2651) ? _t2651 : ((V)("M0 0"))));
Call(set_2579, V.Undef, Get(B_2576, "cr"), ((V)("d")), (((V)(cd_2588.Str)) is var _t2652 && Truthy(_t2652) ? _t2652 : ((V)("M0 0"))));
Call(set_2579, V.Undef, Get(B_2576, "sug"), ((V)("d")), (Invoke(Invoke(Invoke(Get(B_2576, "SU"), "filter", Fn((V _arrowThis2676, int _argc2665, V _a2667, V _a2668, V _a2669, V _a2670, V[] _rest2666) => {
V f_2673 = default;
V y_2675 = default;
{ V _t2671 = ListOf(_a2667);
{ V _t2672 = GetIdx(_t2671, 0D);
f_2673 = _t2672; }
{ V _t2674 = GetIdx(_t2671, 1D);
y_2675 = _t2674; }
}
return Call(vis_2583, V.Undef, Add(f_2673, Call(tw_2586, V.Undef, y_2675)), y_2675);
}, 1, "", true)), "map", Fn((V _arrowThis2664, int _argc2653, V _a2655, V _a2656, V _a2657, V _a2658, V[] _rest2654) => {
V f_2661 = default;
V y_2663 = default;
{ V _t2659 = ListOf(_a2655);
{ V _t2660 = GetIdx(_t2659, 0D);
f_2661 = _t2660; }
{ V _t2662 = GetIdx(_t2659, 1D);
y_2663 = _t2662; }
}
return Call(circD_19, V.Undef, Call(P_2582, V.Undef, Add(f_2661, Call(tw_2586, V.Undef, y_2663)), y_2663, ((V)(1.02))), ((V)((0.5 * ToNum(Get(D_2577, "kS"))))));
}, 1, "", true)), "join", ((V)(""))) is var _t2677 && Truthy(_t2677) ? _t2677 : ((V)("M0 0"))));
zd_2589 = new JsStrBuf("");
zh_2590 = new JsStrBuf("");
Invoke(Get(B_2576, "DZ"), "forEach", Fn((V _arrowThis2691, int _argc2678, V _a2680, V _a2681, V _a2682, V _a2683, V[] _rest2679) => {
V Q_2692 = default;
V ok_2693 = default;
V Qh_2694 = default;
V okh_2695 = default;
V yc_2686 = default;
V p1_2688 = default;
V p2_2690 = default;
{ V _t2684 = ListOf(_a2680);
{ V _t2685 = GetIdx(_t2684, 0D);
yc_2686 = _t2685; }
{ V _t2687 = GetIdx(_t2684, 1D);
p1_2688 = _t2687; }
{ V _t2689 = GetIdx(_t2684, 2D);
p2_2690 = _t2689; }
}
Q_2692 = Arr();
ok_2693 = Arr();
Qh_2694 = Arr();
okh_2695 = Arr();
{
double k_2696 = 0;
k_2696 = 0D;
while (true) {
if (!((k_2696 <= 96D))) break;
double f_2698 = 0;
V y_2699 = default;
V ff_2700 = default;
V v_2701 = default;
f_2698 = ((k_2696 / 96D) * TAU_9);
y_2699 = Add(Add(yc_2686, ((V)((2.3 * FdLibm.Sin(ToNum(Add(((V)((3D * f_2698))), p1_2688))))))), ((V)((0.5 * FdLibm.Sin(ToNum(Add(((V)((7D * f_2698))), p2_2690)))))));
ff_2700 = Add(((V)(f_2698)), Call(tw_2586, V.Undef, y_2699));
v_2701 = Call(vis_2583, V.Undef, ff_2700, y_2699);
Invoke(Q_2692, "push", Call(P_2582, V.Undef, ff_2700, y_2699, ((V)(1.03))));
Invoke(ok_2693, "push", v_2701);
Invoke(Qh_2694, "push", Call(P_2582, V.Undef, ff_2700, ((V)((ToNum(y_2699) - 0.55))), ((V)(1.04))));
Invoke(okh_2695, "push", (v_2701 is var _t2702 && !Truthy(_t2702) ? _t2702 : ((FdLibm.Cos(ToNum(Add(Add(((V)((f_2698 * 3D))), p1_2688), ((V)(0.6))))) > 0.1) ? V.True : V.False)));
k_2696++;
}
}
zd_2589.V(Call(runs_21, V.Undef, Q_2692, ok_2693));
zh_2590.V(Call(runs_21, V.Undef, Qh_2694, okh_2695));
return default;
}, 1, "", true));
Call(set_2579, V.Undef, Get(B_2576, "dz"), ((V)("d")), (((V)(zd_2589.Str)) is var _t2703 && Truthy(_t2703) ? _t2703 : ((V)("M0 0"))));
Call(set_2579, V.Undef, Get(B_2576, "dzh"), ((V)("d")), (((V)(zh_2590.Str)) is var _t2704 && Truthy(_t2704) ? _t2704 : ((V)("M0 0"))));
A_2591 = Invoke(Get(SN_43, "h"), "frontArc", D_2577, ((V)(21D)), ((V)(40D)), ((V)(160D)));
if (GtN(Get(A_2591, "length"), 1D)) {
V t2_2705 = default;
V yd_2706 = default;
V Q_2707 = default;
V fb_2708 = default;
V fa_2709 = default;
t2_2705 = Call(tw_2586, V.Undef, ((V)(42D)));
yd_2706 = Fn((V _arrowThis2717, int _argc2710, V f_2716, V _a2713, V _a2714, V _a2715, V[] _rest2711) => {
return Invoke(B_2576, "yd", ((V)((ToNum(f_2716) - ToNum(t2_2705)))));
}, 1, "", true);
Q_2707 = Arr();
Invoke(A_2591, "forEach", Fn((V _arrowThis2725, int _argc2718, V f_2724, V _a2721, V _a2722, V _a2723, V[] _rest2719) => {
return Invoke(Q_2707, "push", Call(P_2582, V.Undef, f_2724, Call(yd_2706, V.Undef, f_2724), ((V)(1.035))));
}, 1, "", true));
fb_2708 = GetIdx(A_2591, (ToNum(Get(A_2591, "length")) - 1D));
fa_2709 = GetIdx(A_2591, 0D);
{
V y_2726 = default;
y_2726 = Call(yd_2706, V.Undef, fb_2708);
while (true) {
if (!(GeN(y_2726, 13D))) break;
Invoke(Q_2707, "push", Call(P_2582, V.Undef, fb_2708, y_2726, ((V)(1.035))));
y_2726 = ((V)((ToNum(y_2726) - 2.5)));
}
}
{
double i_2728 = 0;
i_2728 = (ToNum(Get(A_2591, "length")) - 1D);
while (true) {
if (!((i_2728 >= 0D))) break;
Invoke(Q_2707, "push", Call(P_2582, V.Undef, GetIdx(A_2591, i_2728), ((V)(12.4)), ((V)(1.035))));
i_2728 = (i_2728 - 4D);
}
}
Invoke(Q_2707, "push", Call(P_2582, V.Undef, GetIdx(A_2591, 0D), ((V)(12.4)), ((V)(1.035))));
{
double y_2730 = 0;
y_2730 = 13D;
while (true) {
if (!(Le(((V)(y_2730)), Call(yd_2706, V.Undef, fa_2709)))) break;
Invoke(Q_2707, "push", Call(P_2582, V.Undef, fa_2709, ((V)(y_2730)), ((V)(1.035))));
y_2730 = (y_2730 + 2.5);
}
}
Call(set_2579, V.Undef, Get(B_2576, "cap"), ((V)("d")), Call(polyW_18, V.Undef, Q_2707));
Call(set_2579, V.Undef, Get(B_2576, "cg"), ((V)("d")), Call(runs_21, V.Undef, Invoke(A_2591, "map", Fn((V _arrowThis2739, int _argc2732, V f_2738, V _a2735, V _a2736, V _a2737, V[] _rest2733) => {
return Call(P_2582, V.Undef, f_2738, ((V)(17D)), ((V)(1.04)));
}, 1, "", true)), Invoke(A_2591, "map", Fn((V _arrowThis2747, int _argc2740, V f_2746, V _a2743, V _a2744, V _a2745, V[] _rest2741) => {
return ((FdLibm.Cos(ToNum(Add(f_2746, Get(D_2577, "yh")))) > 0.35) ? V.True : V.False);
}, 1, "", true))));
Call(set_2579, V.Undef, Get(B_2576, "cg2"), ((V)("d")), Call(runs_21, V.Undef, Invoke(A_2591, "map", Fn((V _arrowThis2755, int _argc2748, V f_2754, V _a2751, V _a2752, V _a2753, V[] _rest2749) => {
return Call(P_2582, V.Undef, f_2754, ((V)((22D + (ToNum(Add(Add(f_2754, Get(D_2577, "yh")), ((V)(0.9)))) * 8D)))), ((V)(1.045)));
}, 1, "", true)), Invoke(A_2591, "map", Fn((V _arrowThis2763, int _argc2756, V f_2762, V _a2759, V _a2760, V _a2761, V[] _rest2757) => {
return ((System.Math.Abs(ToNum(Add(Add(f_2762, Get(D_2577, "yh")), ((V)(0.85))))) < 0.16) ? V.True : V.False);
}, 1, "", true))));
}
return default;
}, 2, "draw", false)).V);
tiltW_49 = Fn((V _arrowThis2774, int _argc2764, V D_2770, V al_2771, V yc_2772, V zc_2773, V[] _rest2765) => {
double ca_2775 = 0;
double sa_2776 = 0;
V HX_2777 = default;
V cyh_2778 = default;
V syh_2779 = default;
V R_2780 = default;
ca_2775 = FdLibm.Cos(ToNum(al_2771));
sa_2776 = FdLibm.Sin(ToNum(al_2771));
HX_2777 = Get(D_2770, "HX");
cyh_2778 = Get(D_2770, "cyh");
syh_2779 = Get(D_2770, "syh");
R_2780 = Fn((V _arrowThis2790, int _argc2781, V x_2787, V y_2788, V z_2789, V _a2786, V[] _rest2782) => {
V cs_2791 = default;
double dx_2792 = 0;
double x1_2793 = 0;
double z1_2794 = 0;
double u_2795 = 0;
double w_2796 = 0;
cs_2791 = (Truthy(Get(D_2770, "yawH")) ? Invoke(D_2770, "yawH", y_2788) : Arr(cyh_2778, syh_2779));
dx_2792 = (ToNum(x_2787) - ToNum(HX_2777));
x1_2793 = ((dx_2792 * ToNum(GetIdx(cs_2791, 0D))) + (ToNum(z_2789) * ToNum(GetIdx(cs_2791, 1D))));
z1_2794 = (((-dx_2792) * ToNum(GetIdx(cs_2791, 1D))) + (ToNum(z_2789) * ToNum(GetIdx(cs_2791, 0D))));
u_2795 = (ToNum(y_2788) - ToNum(yc_2772));
w_2796 = (z1_2794 - ToNum(zc_2773));
return Arr(Add(HX_2777, ((V)(x1_2793))), Add(Add(yc_2772, ((V)((u_2795 * ca_2775)))), ((V)((w_2796 * sa_2776)))), ((V)(((ToNum(zc_2773) - (u_2795 * sa_2776)) + (w_2796 * ca_2775)))));
return default;
}, 3, "", true);
return NewObj(3).Put("P", Fn((V _arrowThis2806, int _argc2797, V x_2803, V y_2804, V z_2805, V _a2802, V[] _rest2798) => {
V r_2807 = default;
r_2807 = Call(R_2780, V.Undef, x_2803, y_2804, z_2805);
return Invoke(D_2770, "headT", GetIdx(r_2807, 0D), GetIdx(r_2807, 1D));
return default;
}, 3, "P", true)).Put("Z", Fn((V _arrowThis2817, int _argc2808, V x_2814, V y_2815, V z_2816, V _a2813, V[] _rest2809) => {
return GetIdx(Call(R_2780, V.Undef, x_2814, y_2815, z_2816), 2D);
}, 3, "Z", true)).Put("F", Fn((V _arrowThis2830, int _argc2818, V x_2824, V y_2825, V z_2826, V nx_2827, V[] _rest2819) => {
V ny_2828 = default;
V nz_2829 = default;
ny_2828 = (_argc2818 > 4 ? _rest2819[0] : V.Undef);
nz_2829 = (_argc2818 > 5 ? _rest2819[1] : V.Undef);
return ((V)((ToNum(GetIdx(Call(R_2780, V.Undef, Add(x_2824, nx_2827), Add(y_2825, ny_2828), Add(z_2826, nz_2829)), 2D)) - ToNum(GetIdx(Call(R_2780, V.Undef, x_2824, y_2825, z_2826), 2D)))));
}, 6, "F", true)).V;
return default;
}, 4, "", true);
Set(Get(SN_43, "h"), "tiltW", tiltW_49);
Set(MODELS_42, "frankie", NewObj(2).Put("setup", Fn((V _self2831, int _argc2832, V S_2838, V _a2835, V _a2836, V _a2837, V[] _rest2833) => {
V sk_2839 = default;
double T_2840 = 0;
double b_2841 = 0;
V rr_2842 = default;
V O_2843 = default;
V OF_2844 = default;
V rings_2845 = default;
V ringsF_2846 = default;
V zF_2847 = default;
V sau_2848 = default;
V bi_2849 = default;
V zz_2850 = default;
V SG_2851 = default;
V topY_2852 = default;
V OFi_2853 = default;
V back_2854 = default;
V inB_2855 = default;
V sg_2856 = default;
V sp_2857 = default;
V sh_2858 = default;
V kc_2859 = default;
V ms_2860 = default;
V lip_2861 = default;
V shn_2862 = default;
if (_self2831.IsNullish) _self2831 = GlobalV;
{ V _t2863 = S_2838;
if (_t2863.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t2863));
{ V _t2864 = Get(_t2863, "sk");
sk_2839 = _t2864; } }
T_2840 = 11D;
b_2841 = 9.5;
rr_2842 = Fn((V _arrowThis2873, int _argc2865, V y0_2871, V n_2872, V _a2869, V _a2870, V[] _rest2866) => {
V Q_2874 = default;
Q_2874 = Arr();
{
double k_2875 = 0;
k_2875 = 0D;
while (true) {
if (!((k_2875 < 72D))) break;
double f_2877 = 0;
double c_2878 = 0;
double s_2879 = 0;
double ax_2880 = 0;
double ay_2881 = 0;
f_2877 = ((k_2875 / 72D) * TAU_9);
c_2878 = FdLibm.Cos(f_2877);
s_2879 = FdLibm.Sin(f_2877);
ax_2880 = 42D;
ay_2881 = ((88D - ToNum(y0_2871)) / 2D);
Invoke(Q_2874, "push", Arr(((V)((50D + ((ax_2880 * Sign(c_2878)) * Pow(System.Math.Abs(c_2878), (2D / ToNum(n_2872))))))), ((V)(((ToNum(Add(((V)(88D)), y0_2871)) / 2D) + ((ay_2881 * Sign(s_2879)) * Pow(System.Math.Abs(s_2879), (2D / ToNum(n_2872)))))))));
k_2875++;
}
}
return Q_2874;
return default;
}, 2, "", true);
O_2843 = Call(rr_2842, V.Undef, ((V)(53D)), ((V)(2.8)));
OF_2844 = Call(rr_2842, V.Undef, ((V)(43D)), ((V)(2.8)));
rings_2845 = Call(pillowRings_40, V.Undef, O_2843, ((V)(T_2840)), ((V)(b_2841)), ((V)(5D)));
ringsF_2846 = Call(pillowRings_40, V.Undef, OF_2844, ((V)(T_2840)), ((V)(b_2841)), ((V)(5D)));
zF_2847 = Call(pillowZ_41, V.Undef, O_2843, ((V)(T_2840)), ((V)(b_2841)));
sau_2848 = GetIdx(Invoke(S_2838, "hide", Fn((V _arrowThis2889, int _argc2882, V q_2888, V _a2885, V _a2886, V _a2887, V[] _rest2883) => {
return (Get(q_2888, "inBody") is var _t2890 && !Truthy(_t2890) ? _t2890 : Invoke(NewRegExp(RX7, "^M14 41", ""), "test", Invoke(S_2838, "d", q_2888)));
}, 1, "", true)), 0D);
bi_2849 = GetIdx(Invoke(S_2838, "hide", Fn((V _arrowThis2898, int _argc2891, V q_2897, V _a2894, V _a2895, V _a2896, V[] _rest2892) => {
return (Get(q_2897, "inBody") is var _t2899 && !Truthy(_t2899) ? _t2899 : Invoke(NewRegExp(RX8, "^M13 43", ""), "test", Invoke(S_2838, "d", q_2897)));
}, 1, "", true)), 0D);
Invoke(S_2838, "hide", Fn((V _arrowThis2907, int _argc2900, V q_2906, V _a2903, V _a2904, V _a2905, V[] _rest2901) => {
return (Get(q_2906, "inBody") is var _t2909 && !Truthy(_t2909) ? _t2909 : (Invoke(NewRegExp(RX9, "^M9 50 Q9 31|^M14 43\\.6|^M16 46 L20|^M16 56", ""), "test", Invoke(S_2838, "d", q_2906)) is var _t2908 && Truthy(_t2908) ? _t2908 : (SEqS(Invoke(S_2838, "s", q_2906), "#e8402e") ? V.True : V.False)));
}, 1, "", true));
Invoke(Get(sk_2839, "e"), "setAttribute", ((V)("fill")), Invoke(S_2838, "lgrad", ((V)("fkb")), Arr(Arr(((V)(0D)), ((V)("#c9782f"))), Arr(((V)(0.16)), ((V)("#d98f42"))), Arr(((V)(0.42)), ((V)("#eeb265"))), Arr(((V)(0.78)), ((V)("#f6cf92"))), Arr(((V)(1D)), ((V)("#eebd7c")))), NewObj(2).Put("x2", ((V)(0D))).Put("y2", ((V)(1D))).V));
zz_2850 = Fn((V _arrowThis2917, int _argc2910, V y_2916, V _a2913, V _a2914, V _a2915, V[] _rest2911) => {
return Call(SM_13, V.Undef, ((V)(((88D - ToNum(y_2916)) / 26D))));
}, 1, "", true);
SG_2851 = Invoke(S_2838, "g", Get(S_2838, "par"), Get(sk_2839, "e"));
Invoke(SG_2851, "appendChild", Get(sk_2839, "e"));
topY_2852 = Fn((V _arrowThis2925, int _argc2918, V x_2924, V _a2921, V _a2922, V _a2923, V[] _rest2919) => {
V m_2926 = default;
m_2926 = ((V)(1000000000D));
{
double i_2927 = 0;
i_2927 = 0D;
while (true) {
if (!(Lt(((V)(i_2927)), Get(O_2843, "length")))) break;
V a_2929 = default;
V c_2930 = default;
a_2929 = GetIdx(O_2843, i_2927);
c_2930 = GetIdx(O_2843, ((i_2927 + 1D) % ToNum(Get(O_2843, "length"))));
if (((((ToNum(GetIdx(a_2929, 0D)) - ToNum(x_2924)) * (ToNum(GetIdx(c_2930, 0D)) - ToNum(x_2924))) <= 0D) && !SEq(GetIdx(a_2929, 0D), GetIdx(c_2930, 0D)))) {
V y_2931 = default;
y_2931 = Add(GetIdx(a_2929, 1D), ((V)((((ToNum(GetIdx(c_2930, 1D)) - ToNum(GetIdx(a_2929, 1D))) * (ToNum(x_2924) - ToNum(GetIdx(a_2929, 0D)))) / (ToNum(GetIdx(c_2930, 0D)) - ToNum(GetIdx(a_2929, 0D)))))));
if (Lt(y_2931, m_2926)) {
m_2926 = y_2931;
}
}
i_2927++;
}
}
return m_2926;
return default;
}, 1, "", true);
OFi_2853 = Invoke(Call(offset_39, V.Undef, OF_2844, ((V)(1.5))), "map", Fn((V _arrowThis2939, int _argc2932, V p_2938, V _a2935, V _a2936, V _a2937, V[] _rest2933) => {
return Arr(GetIdx(p_2938, 0D), ((V)(Min(ToNum(GetIdx(p_2938, 1D)), 62D))));
}, 1, "", true));
back_2854 = Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", Invoke(S_2838, "lgrad", ((V)("fkf")), Arr(Arr(((V)(0D)), ((V)("#bf6c28"))), Arr(((V)(0.3)), ((V)("#d48a3e"))), Arr(((V)(1D)), ((V)("#e9ae63")))), NewObj(2).Put("x2", ((V)(0D))).Put("y2", ((V)(1D))).V)).V, SG_2851, Get(sk_2839, "e"));
inB_2855 = Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", Invoke(S_2838, "rgrad", ((V)("fki")), Arr(Arr(((V)(0D)), ((V)("#fff8ea"))), Arr(((V)(0.6)), ((V)("#ffeccb"))), Arr(((V)(1D)), ((V)("#f2d29c")))), NewObj(1).Put("cy", ((V)("70%"))).V)).V, SG_2851, Get(sk_2839, "e"));
sg_2856 = Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, SG_2851, Get(sk_2839, "e"));
sp_2857 = Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", Invoke(S_2838, "lgrad", ((V)("fks")), Arr(Arr(((V)(0D)), ((V)("#f08660"))), Arr(((V)(0.38)), ((V)("#d85434"))), Arr(((V)(0.78)), ((V)("#b23d26"))), Arr(((V)(1D)), ((V)("#8c2c1c")))), NewObj(2).Put("x2", ((V)(0D))).Put("y2", ((V)(1D))).V)).V, sg_2856);
sh_2858 = Call(el_14, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffd8c6"))).Put("stroke-width", ((V)(1.3))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.75))).V, sg_2856);
kc_2859 = Call(el_14, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#e8402e"))).Put("stroke-width", ((V)(2.1))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V, sg_2856);
ms_2860 = Call(el_14, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffd43b"))).Put("stroke-width", ((V)(1.8))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V, sg_2856);
lip_2861 = Call(el_14, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#fff3dc"))).Put("stroke-width", ((V)(1.7))).Put("opacity", ((V)(0.85))).Put("stroke-linecap", ((V)("round"))).V, SG_2851);
shn_2862 = Call(el_14, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#fff4dc"))).Put("stroke-width", ((V)(4D))).Put("opacity", ((V)(0.2))).Put("stroke-linecap", ((V)("round"))).V, SG_2851);
return NewObj(30).Put("O", O_2843).Put("OF", OF_2844).Put("OFi", OFi_2853).Put("topY", topY_2852).Put("T", ((V)(T_2840))).Put("b", ((V)(b_2841))).Put("rings", rings_2845).Put("ringsF", ringsF_2846).Put("zF", zF_2847).Put("zz", zz_2850).Put("SG", SG_2851).Put("back", back_2854).Put("inB", inB_2855).Put("sg", sg_2856).Put("sp", sp_2857).Put("sh", sh_2858).Put("kc", kc_2859).Put("ms", ms_2860).Put("lip", lip_2861).Put("shn", shn_2862).Put("z0", ((V)(4D))).Put("AL", ((V)(0.45))).Put("YC", ((V)(70D))).Put("slab", ((V)(1D))).Put("rx", ((V)(41D))).Put("ya", ((V)(50D))).Put("yb", ((V)(87D))).Put("rT", Fn((V _arrowThis2947, int _argc2940, V y_2946, V _a2943, V _a2944, V _a2945, V[] _rest2941) => {
return Call(halfW_38, V.Undef, O_2843, y_2946);
}, 1, "rT", true)).Put("zAt", Fn((V _arrowThis2956, int _argc2948, V x_2954, V y_2955, V _a2952, V _a2953, V[] _rest2949) => {
return Add(((V)((4D * ToNum(Call(zz_2850, V.Undef, y_2955))))), Call(zF_2847, V.Undef, x_2954, y_2955));
}, 2, "zAt", true)).Put("zE", Fn((V _arrowThis2965, int _argc2957, V dx_2963, V dy_2964, V _a2961, V _a2962, V[] _rest2958) => {
return Add(Add(((V)((4D * ToNum(Call(zz_2850, V.Undef, Add(Get(S_2838, "HY"), dy_2964)))))), Call(zF_2847, V.Undef, Add(Get(S_2838, "HX"), dx_2963), Add(Get(S_2838, "HY"), dy_2964))), ((V)(0.3)));
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self2966, int _argc2967, V B_2973, V D_2974, V _a2971, V _a2972, V[] _rest2968) => {
V set_2975 = default;
double slip_2976 = 0;
V hug_2977 = default;
V z0_2978 = default;
V zc_2979 = default;
V W_2980 = default;
V P_2981 = default;
V zz_2982 = default;
V fr_2983 = default;
double s_2984 = 0;
V half_2985 = default;
double r_2986 = 0;
double yS_2987 = 0;
V sph_2988 = default;
V line_2989 = default;
V lp_2990 = default;
V sn_2991 = default;
V L_2992 = default;
if (_self2966.IsNullish) _self2966 = GlobalV;
{ V _t2993 = D_2974;
if (_t2993.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t2993));
{ V _t2994 = Get(_t2993, "set");
set_2975 = _t2994; } }
slip_2976 = (ToNum(Call(clamp_12, V.Undef, Invoke(D_2974, "bv", ((V)("slip"))), ((V)((-1.3))), ((V)(1.3)))) * 15D);
hug_2977 = Call(clamp_12, V.Undef, Invoke(D_2974, "bv", ((V)("hug"))), ((V)((-1D))), ((V)(1.5)));
z0_2978 = Add(Get(B_2973, "z0"), ((V)((ToNum(hug_2977) * 3D))));
zc_2979 = Add(z0_2978, Get(B_2973, "T"));
W_2980 = Call(tiltW_49, V.Undef, D_2974, Get(B_2973, "AL"), Get(B_2973, "YC"), zc_2979);
P_2981 = Get(W_2980, "P");
zz_2982 = Fn((V _arrowThis3002, int _argc2995, V y_3001, V _a2998, V _a2999, V _a3000, V[] _rest2996) => {
return ((V)((ToNum(z0_2978) * ToNum(Invoke(B_2973, "zz", y_3001)))));
}, 1, "", true);
fr_2983 = (GeN(Get(D_2974, "front"), 0D) ? V.True : V.False);
s_2984 = (Truthy(fr_2983) ? 1D : (-1D));
half_2985 = Fn((V _arrowThis3011, int _argc3003, V sg_3009, V RG_3010, V _a3007, V _a3008, V[] _rest3004) => {
V o_3012 = default;
o_3012 = Arr();
Invoke(RG_3010, "forEach", Fn((V _arrowThis3020, int _argc3013, V R_3019, V _a3016, V _a3017, V _a3018, V[] _rest3014) => {
return Invoke(Get(R_3019, "Q"), "forEach", Fn((V _arrowThis3028, int _argc3021, V p_3027, V _a3024, V _a3025, V _a3026, V[] _rest3022) => {
return Invoke(o_3012, "push", Call(P_2981, V.Undef, GetIdx(p_3027, 0D), GetIdx(p_3027, 1D), ((V)((ToNum(sg_3009) * ToNum(Add(Call(zz_2982, V.Undef, GetIdx(p_3027, 1D)), Get(R_3019, "z"))))))));
}, 1, "", true));
}, 1, "", true));
return Invoke(D_2974, "hull", o_3012);
return default;
}, 2, "", true);
Set(B_2973, "d", Call(half_2985, V.Undef, ((V)(1D)), (Truthy(fr_2983) ? Get(B_2973, "rings") : Get(B_2973, "ringsF"))));
Call(set_2975, V.Undef, Get(B_2973, "back"), ((V)("d")), Call(half_2985, V.Undef, ((V)((-1D))), (Truthy(fr_2983) ? Get(B_2973, "ringsF") : Get(B_2973, "rings"))));
Call(set_2975, V.Undef, Get(B_2973, "inB"), ((V)("d")), Call(polyW_18, V.Undef, Invoke(Get(B_2973, "OFi"), "map", Fn((V _arrowThis3036, int _argc3029, V p_3035, V _a3032, V _a3033, V _a3034, V[] _rest3030) => {
return Call(P_2981, V.Undef, GetIdx(p_3035, 0D), GetIdx(p_3035, 1D), ((V)(((-s_2984) * (ToNum(Call(zz_2982, V.Undef, GetIdx(p_3035, 1D))) - 0.2)))));
}, 1, "", true))));
r_2986 = (8.4 - (Max(0D, (-ToNum(hug_2977))) * 0.8));
yS_2987 = (52.5 - (Max(0D, (-ToNum(hug_2977))) * 1.5));
sph_2988 = Fn((V _arrowThis3044, int _argc3037, V c_3043, V _a3040, V _a3041, V _a3042, V[] _rest3038) => {
V o_3045 = default;
o_3045 = Arr();
{
double i_3046 = 0;
i_3046 = 0D;
while (true) {
if (!((i_3046 <= 6D))) break;
double th_3048 = 0;
double cr_3049 = 0;
th_3048 = (((-System.Math.PI) / 2D) + ((System.Math.PI * i_3046) / 6D));
cr_3049 = FdLibm.Cos(th_3048);
{
double k_3050 = 0;
k_3050 = 0D;
while (true) {
if (!((k_3050 < 12D))) break;
double f_3052 = 0;
f_3052 = ((k_3050 / 12D) * TAU_9);
Invoke(o_3045, "push", Call(P_2981, V.Undef, Add(GetIdx(c_3043, 0D), ((V)(((r_2986 * cr_3049) * FdLibm.Sin(f_3052))))), Add(GetIdx(c_3043, 1D), ((V)((r_2986 * FdLibm.Sin(th_3048))))), Add(GetIdx(c_3043, 2D), ((V)(((r_2986 * cr_3049) * FdLibm.Cos(f_3052)))))));
k_3050++;
}
}
i_3046++;
}
}
return o_3045;
return default;
}, 1, "", true);
Call(set_2975, V.Undef, Get(B_2973, "sp"), ((V)("d")), Invoke(D_2974, "hull", Invoke(Call(sph_2988, V.Undef, Arr(((V)((12D + slip_2976))), ((V)(yS_2987)), ((V)(0D)))), "concat", Call(sph_2988, V.Undef, Arr(((V)((88D + slip_2976))), ((V)(yS_2987)), ((V)(0D)))))));
line_2989 = Fn((V _arrowThis3063, int _argc3053, V fn_3059, V x0_3060, V x1_3061, V st_3062, V[] _rest3054) => {
V Q_3064 = default;
V ok_3065 = default;
Q_3064 = Arr();
ok_3065 = Arr();
{
V x_3066 = default;
x_3066 = x0_3060;
while (true) {
if (!(Le(x_3066, x1_3061))) break;
V ph_3068 = default;
double ny_3069 = 0;
double nz_3070 = 0;
ph_3068 = Call(fn_3059, V.Undef, x_3066);
ny_3069 = (-FdLibm.Cos(ToNum(ph_3068)));
nz_3070 = FdLibm.Sin(ToNum(ph_3068));
Invoke(Q_3064, "push", Call(P_2981, V.Undef, Add(x_3066, ((V)(slip_2976))), ((V)((yS_2987 + ((r_2986 * ny_3069) * 1.03)))), ((V)(((r_2986 * nz_3070) * 1.03)))));
Invoke(ok_3065, "push", (GtN(Invoke(W_2980, "F", Add(x_3066, ((V)(slip_2976))), ((V)((yS_2987 + (r_2986 * ny_3069)))), ((V)((r_2986 * nz_3070))), ((V)(((ny_3069 * 0D) + 0D))), ((V)(ny_3069)), ((V)(nz_3070))), 0.02) ? V.True : V.False));
x_3066 = Add(x_3066, st_3062);
}
}
return Call(runs_21, V.Undef, Q_3064, ok_3065);
return default;
}, 4, "", true);
Call(set_2975, V.Undef, Get(B_2973, "kc"), ((V)("d")), (Call(line_2989, V.Undef, Fn((V _arrowThis3078, int _argc3071, V x_3077, V _a3074, V _a3075, V _a3076, V[] _rest3072) => {
return ((V)((0.32 + (0.24 * FdLibm.Sin(((ToNum(x_3077) - 15D) * 0.9))))));
}, 1, "", true), ((V)(15D)), ((V)(85D)), ((V)(0.9))) is var _t3079 && Truthy(_t3079) ? _t3079 : ((V)("M0 0"))));
Call(set_2975, V.Undef, Get(B_2973, "ms"), ((V)("d")), (Call(line_2989, V.Undef, Fn((V _arrowThis3087, int _argc3080, V x_3086, V _a3083, V _a3084, V _a3085, V[] _rest3081) => {
double u_3088 = 0;
double tri_3089 = 0;
u_3088 = ((ToNum(x_3086) - 16D) / 4D);
tri_3089 = ((System.Math.Abs(((((u_3088 % 2D) + 2D) % 2D) - 1D)) * 2D) - 1D);
return ((V)(((-0.2) + (0.3 * tri_3089))));
return default;
}, 1, "", true), ((V)(16D)), ((V)(84D)), ((V)(1D))) is var _t3090 && Truthy(_t3090) ? _t3090 : ((V)("M0 0"))));
Call(set_2975, V.Undef, Get(B_2973, "sh"), ((V)("d")), (Call(line_2989, V.Undef, Fn((V _arrowThis3097, int _argc3091, V _a3093, V _a3094, V _a3095, V _a3096, V[] _rest3092) => {
return ((V)(0.95));
}, 0, "", true), ((V)(18D)), ((V)(82D)), ((V)(4D))) is var _t3098 && Truthy(_t3098) ? _t3098 : ((V)("M0 0"))));
lp_2990 = Arr();
sn_2991 = Arr();
{
double x_3099 = 0;
x_3099 = 12D;
while (true) {
if (!((x_3099 <= 88D))) break;
V ty_3101 = default;
ty_3101 = Invoke(B_2973, "topY", ((V)(x_3099)));
if (GtN(ty_3101, 72D)) {
goto _cont3100;
}
Invoke(lp_2990, "push", Call(P_2981, V.Undef, ((V)(x_3099)), Add(ty_3101, ((V)(0.5))), ((V)((s_2984 * ToNum(Add(Call(zz_2982, V.Undef, Add(ty_3101, ((V)(0.5)))), ((V)(0.7)))))))));
if (((x_3099 >= 24D) && (x_3099 <= 76D))) {
Invoke(sn_2991, "push", Call(P_2981, V.Undef, ((V)(x_3099)), Add(ty_3101, ((V)(5.2))), ((V)((s_2984 * ToNum(Add(Call(zz_2982, V.Undef, Add(ty_3101, ((V)(5.2)))), ((V)((ToNum(Get(B_2973, "T")) * 0.9))))))))));
}
_cont3100: ;
x_3099 = (x_3099 + 2D);
}
}
Call(set_2975, V.Undef, Get(B_2973, "lip"), ((V)("d")), Call(runs_21, V.Undef, lp_2990, Invoke(lp_2990, "map", Fn((V _arrowThis3108, int _argc3102, V _a3104, V _a3105, V _a3106, V _a3107, V[] _rest3103) => {
return (true ? V.True : V.False);
}, 0, "", true))));
Call(set_2975, V.Undef, Get(B_2973, "shn"), ((V)("d")), Call(runs_21, V.Undef, sn_2991, Invoke(sn_2991, "map", Fn((V _arrowThis3115, int _argc3109, V _a3111, V _a3112, V _a3113, V _a3114, V[] _rest3110) => {
return (true ? V.True : V.False);
}, 0, "", true))));
L_2992 = Invoke(Arr(NewObj(3).Put("id", ((V)("b"))).Put("e", Get(B_2973, "back")).Put("z", Invoke(W_2980, "Z", ((V)(50D)), ((V)(68D)), ((V)(((-ToNum(z0_2978)) - 6D))))).V, NewObj(3).Put("id", ((V)("i"))).Put("e", Get(B_2973, "inB")).Put("z", Add(Invoke(W_2980, "Z", ((V)(50D)), ((V)(68D)), ((V)(((-s_2984) * ToNum(z0_2978))))), ((V)((s_2984 * 0.01))))).V, NewObj(3).Put("id", ((V)("s"))).Put("e", Get(B_2973, "sg")).Put("z", Invoke(W_2980, "Z", ((V)((50D + slip_2976))), ((V)(yS_2987)), ((V)(0D)))).V, NewObj(3).Put("id", ((V)("f"))).Put("e", Get(Get(Get(B_2973, "S"), "sk"), "e")).Put("z", Invoke(W_2980, "Z", ((V)(50D)), ((V)(68D)), Add(z0_2978, ((V)(6D))))).V, NewObj(3).Put("id", ((V)("l"))).Put("e", Get(B_2973, "lip")).Put("z", Add(Invoke(W_2980, "Z", ((V)(50D)), ((V)(68D)), ((V)((s_2984 * ToNum(Add(z0_2978, ((V)(6D)))))))), ((V)(0.01)))).V, NewObj(3).Put("id", ((V)("h"))).Put("e", Get(B_2973, "shn")).Put("z", Add(Invoke(W_2980, "Z", ((V)(50D)), ((V)(68D)), ((V)((s_2984 * ToNum(Add(z0_2978, ((V)(6D)))))))), ((V)(0.02)))).V), "sort", Fn((V _arrowThis3124, int _argc3116, V a_3122, V b_3123, V _a3120, V _a3121, V[] _rest3117) => {
return ((V)((ToNum(Get(a_3122, "z")) - ToNum(Get(b_3123, "z")))));
}, 2, "", true));
Invoke(SN_43, "order", Get(B_2973, "SG"), L_2992);
return default;
}, 2, "draw", false)).V);
Set(MODELS_42, "peppi", NewObj(2).Put("setup", Fn((V _self3125, int _argc3126, V S_3132, V _a3129, V _a3130, V _a3131, V[] _rest3127) => {
V sk_3133 = default;
V O_3134 = default;
double T_3135 = 0;
double b_3136 = 0;
V rings_3137 = default;
V cheese_3138 = default;
V cr_3139 = default;
V CR_3140 = default;
V face_3141 = default;
V dec_3142 = default;
V DC_3143 = default;
V spots_3144 = default;
V strings_3145 = default;
V crust_3146 = default;
V @char_3147 = default;
V cl_3148 = default;
if (_self3125.IsNullish) _self3125 = GlobalV;
{ V _t3149 = S_3132;
if (_t3149.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t3149));
{ V _t3150 = Get(_t3149, "sk");
sk_3133 = _t3150; } }
O_3134 = Invoke(S_3132, "outline", sk_3133, ((V)(56D)));
T_3135 = 2.3;
b_3136 = 1.4;
rings_3137 = Call(pillowRings_40, V.Undef, O_3134, ((V)(T_3135)), ((V)(b_3136)), ((V)(2D)));
cheese_3138 = Invoke(S_3132, "f", sk_3133);
cr_3139 = GetIdx(Invoke(S_3132, "hide", Fn((V _arrowThis3158, int _argc3151, V q_3157, V _a3154, V _a3155, V _a3156, V[] _rest3152) => {
return (Get(q_3157, "inBody") is var _t3159 && !Truthy(_t3159) ? _t3159 : Invoke(NewRegExp(RX10, "^M6\\.5 75\\.5", ""), "test", Invoke(S_3132, "d", q_3157)));
}, 1, "", true)), 0D);
CR_3140 = (Truthy(cr_3139) ? Invoke(S_3132, "f", cr_3139) : ((V)("#eaa95c")));
Invoke(S_3132, "hide", Fn((V _arrowThis3167, int _argc3160, V q_3166, V _a3163, V _a3164, V _a3165, V[] _rest3161) => {
return (Get(q_3166, "inBody") is var _t3168 && !Truthy(_t3168) ? _t3168 : Invoke(NewRegExp(RX11, "^M18 80\\.5", ""), "test", Invoke(S_3132, "d", q_3166)));
}, 1, "", true));
Invoke(Get(sk_3133, "e"), "setAttribute", ((V)("fill")), Invoke(S_3132, "rgrad", ((V)("pzd")), Arr(Arr(((V)(0D)), ((V)("#ffe9bf"))), Arr(((V)(0.6)), ((V)("#f0c886"))), Arr(((V)(1D)), ((V)("#c99450"))))));
face_3141 = Invoke(S_3132, "path", NewObj(1).Put("fill", cheese_3138).V);
dec_3142 = Invoke(S_3132, "g");
DC_3143 = Invoke(S_3132, "decals", Fn((V _arrowThis3176, int _argc3169, V q_3175, V _a3172, V _a3173, V _a3174, V[] _rest3170) => {
return (Get(q_3175, "inBody") is var _t3177 && !Truthy(_t3177) ? _t3177 : Invoke(S_3132, "dk", q_3175, ((V)("tp"))));
}, 1, "", true), dec_3142);
spots_3144 = Invoke(S_3132, "path", NewObj(2).Put("fill", ((V)("#c98a44"))).Put("opacity", ((V)(0.4))).V);
strings_3145 = Invoke(S_3132, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffd45c"))).Put("stroke-width", ((V)(1.6))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.95))).V);
crust_3146 = Invoke(S_3132, "path", NewObj(1).Put("fill", CR_3140).V);
@char_3147 = Invoke(S_3132, "path", NewObj(2).Put("fill", ((V)("#a8642a"))).Put("opacity", ((V)(0.4))).V);
cl_3148 = Invoke(S_3132, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffeccc"))).Put("stroke-width", ((V)(1.3))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.8))).V);
return NewObj(21).Put("O", O_3134).Put("T", ((V)(T_3135))).Put("b", ((V)(b_3136))).Put("rings", rings_3137).Put("face", face_3141).Put("dec", dec_3142).Put("DC", DC_3143).Put("spots", spots_3144).Put("strings", strings_3145).Put("crust", crust_3146).Put("char", @char_3147).Put("cl", cl_3148).Put("slab", ((V)(1D))).Put("rx", ((V)(41D))).Put("ya", ((V)(20D))).Put("yb", ((V)(78D))).Put("rT", Fn((V _arrowThis3185, int _argc3178, V y_3184, V _a3181, V _a3182, V _a3183, V[] _rest3179) => {
return Call(halfW_38, V.Undef, O_3134, y_3184);
}, 1, "rT", true)).Put("zAt", Fn((V _arrowThis3194, int _argc3186, V x_3192, V y_3193, V _a3190, V _a3191, V[] _rest3187) => {
return ((V)((Truthy(Call(inside_35, V.Undef, O_3134, x_3192, y_3193)) ? T_3135 : 0D)));
}, 2, "zAt", true)).Put("zE", Fn((V _arrowThis3201, int _argc3195, V _a3197, V _a3198, V _a3199, V _a3200, V[] _rest3196) => {
return ((V)((T_3135 + 0.25)));
}, 0, "zE", true)).Put("cheese", cheese_3138).Put("back", Invoke(S_3132, "rgrad", ((V)("pzb")), Arr(Arr(((V)(0D)), ((V)("#fff2d2"))), Arr(((V)(0.6)), ((V)("#f2d39a"))), Arr(((V)(1D)), ((V)("#d6a660")))))).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self3202, int _argc3203, V B_3209, V D_3210, V _a3207, V _a3208, V[] _rest3204) => {
V P3_3211 = default;
V set_3212 = default;
V T_3213 = default;
V pull_3214 = default;
double flop_3215 = 0;
V W_3216 = default;
V all_3217 = default;
V fr_3218 = default;
double s_3219 = 0;
V cir_3220 = default;
V C_3221 = default;
V R_3222 = default;
V lp_3223 = default;
JsStrBuf sd_3224 = null;
if (_self3202.IsNullish) _self3202 = GlobalV;
{ V _t3225 = D_3210;
if (_t3225.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t3225));
{ V _t3226 = Get(_t3225, "P3");
P3_3211 = _t3226; }
{ V _t3227 = Get(_t3225, "set");
set_3212 = _t3227; } }
T_3213 = Get(B_3209, "T");
pull_3214 = Call(clamp_12, V.Undef, Invoke(D_3210, "bv", ((V)("pull"))), ((V)(0D)), ((V)(1.2)));
flop_3215 = (ToNum(Call(clamp_12, V.Undef, Invoke(D_3210, "bv", ((V)("flop"))), ((V)((-1D))), ((V)(1D)))) * 10D);
W_3216 = Fn((V _arrowThis3237, int _argc3228, V x_3234, V y_3235, V z_3236, V _a3233, V[] _rest3229) => {
V u_3238 = default;
u_3238 = Call(clamp_12, V.Undef, ((V)(((46D - ToNum(y_3235)) / 36D))), ((V)(0D)), ((V)(1D)));
return Call(P3_3211, V.Undef, x_3234, Add(y_3235, ((V)((((System.Math.Abs(flop_3215) * ToNum(u_3238)) * ToNum(u_3238)) * 0.35)))), Add(z_3236, ((V)(((flop_3215 * ToNum(u_3238)) * ToNum(u_3238))))));
return default;
}, 3, "", true);
all_3217 = Arr();
Invoke(Get(B_3209, "rings"), "forEach", Fn((V _arrowThis3246, int _argc3239, V R_3245, V _a3242, V _a3243, V _a3244, V[] _rest3240) => {
return Invoke(Get(R_3245, "Q"), "forEach", Fn((V _arrowThis3254, int _argc3247, V p_3253, V _a3250, V _a3251, V _a3252, V[] _rest3248) => {
Invoke(all_3217, "push", Call(W_3216, V.Undef, GetIdx(p_3253, 0D), GetIdx(p_3253, 1D), Get(R_3245, "z")));
Invoke(all_3217, "push", Call(W_3216, V.Undef, GetIdx(p_3253, 0D), GetIdx(p_3253, 1D), ((V)((-ToNum(Get(R_3245, "z")))))));
return default;
}, 1, "", true));
}, 1, "", true));
Set(B_3209, "d", Invoke(D_3210, "hull", all_3217));
fr_3218 = (GeN(Get(D_3210, "front"), 0D) ? V.True : V.False);
s_3219 = (Truthy(fr_3218) ? 1D : (-1D));
Call(set_3212, V.Undef, Get(B_3209, "face"), ((V)("d")), Call(polyW_18, V.Undef, Invoke(Get(GetIdx(Get(B_3209, "rings"), (ToNum(Get(Get(B_3209, "rings"), "length")) - 1D)), "Q"), "map", Fn((V _arrowThis3262, int _argc3255, V p_3261, V _a3258, V _a3259, V _a3260, V[] _rest3256) => {
return Call(W_3216, V.Undef, GetIdx(p_3261, 0D), GetIdx(p_3261, 1D), ((V)((s_3219 * ToNum(T_3213)))));
}, 1, "", true))));
Call(set_3212, V.Undef, Get(B_3209, "face"), ((V)("fill")), (Truthy(fr_3218) ? Get(B_3209, "cheese") : Get(B_3209, "back")));
Invoke(Get(B_3209, "dec"), "setAttribute", ((V)("opacity")), ((V)((Truthy(fr_3218) ? 1D : 0D))));
Call(set_3212, V.Undef, Get(B_3209, "spots"), ((V)("opacity")), ((V)((Truthy(fr_3218) ? 0D : 0.4))));
cir_3220 = Fn((V _arrowThis3274, int _argc3263, V x_3269, V y_3270, V r_3271, V z_3272, V[] _rest3264) => {
V n_3273 = default;
n_3273 = (_argc3263 > 4 ? _rest3264[0] : V.Undef);
return Call(polyW_18, V.Undef, Array_from(NewObj(1).Put("length", (n_3273 is var _t3275 && Truthy(_t3275) ? _t3275 : ((V)(14D)))).V, Fn((V _arrowThis3284, int _argc3276, V __3282, V k_3283, V _a3280, V _a3281, V[] _rest3277) => {
return Call(W_3216, V.Undef, Add(x_3269, ((V)((ToNum(r_3271) * FdLibm.Cos(((ToNum(k_3283) / ToNum((n_3273 is var _t3285 && Truthy(_t3285) ? _t3285 : ((V)(14D))))) * TAU_9)))))), Add(y_3270, ((V)((ToNum(r_3271) * FdLibm.Sin(((ToNum(k_3283) / ToNum((n_3273 is var _t3286 && Truthy(_t3286) ? _t3286 : ((V)(14D))))) * TAU_9)))))), z_3272);
}, 2, "", true)));
}, 5, "", true);
if (Truthy(fr_3218)) {
Invoke(Get(B_3209, "DC"), "forEach", Fn((V _arrowThis3295, int _argc3287, V o_3293, V i_3294, V _a3291, V _a3292, V[] _rest3288) => {
return Call(set_3212, V.Undef, Get(o_3293, "e"), ((V)("d")), Call(decD_26, V.Undef, o_3293, Fn((V _arrowThis3304, int _argc3296, V x_3302, V y_3303, V _a3300, V _a3301, V[] _rest3297) => {
return Call(W_3216, V.Undef, x_3302, y_3303, Add(Add(T_3213, ((V)(0.15))), ((V)((ToNum(i_3294) * 0.004)))));
}, 2, "", true)));
}, 2, "", true));
} else {
Call(set_3212, V.Undef, Get(B_3209, "spots"), ((V)("d")), Invoke(Invoke(Arr(Arr(((V)(44D)), ((V)(40D)), ((V)(1.4))), Arr(((V)(58D)), ((V)(46D)), ((V)(1.3))), Arr(((V)(50D)), ((V)(58D)), ((V)(1.5))), Arr(((V)(40D)), ((V)(62D)), ((V)(1.1))), Arr(((V)(62D)), ((V)(64D)), ((V)(1.2))), Arr(((V)(30D)), ((V)(66D)), ((V)(1D))), Arr(((V)(70D)), ((V)(60D)), ((V)(1.3)))), "map", Fn((V _arrowThis3318, int _argc3305, V _a3307, V _a3308, V _a3309, V _a3310, V[] _rest3306) => {
V x_3313 = default;
V y_3315 = default;
V r_3317 = default;
{ V _t3311 = ListOf(_a3307);
{ V _t3312 = GetIdx(_t3311, 0D);
x_3313 = _t3312; }
{ V _t3314 = GetIdx(_t3311, 1D);
y_3315 = _t3314; }
{ V _t3316 = GetIdx(_t3311, 2D);
r_3317 = _t3316; }
}
return Call(cir_3220, V.Undef, x_3313, y_3315, r_3317, ((V)(((-ToNum(T_3213)) - 0.15))), ((V)(8D)));
}, 1, "", true)), "join", ((V)(""))));
}
C_3221 = Arr();
R_3222 = Arr();
{
double i_3319 = 0;
i_3319 = 0D;
while (true) {
if (!((i_3319 <= 10D))) break;
double t_3321 = 0;
double u_3322 = 0;
double x_3323 = 0;
double y_3324 = 0;
t_3321 = (i_3319 / 10D);
u_3322 = (1D - t_3321);
x_3323 = ((((u_3322 * u_3322) * 7.5) + (((2D * u_3322) * t_3321) * 50D)) + ((t_3321 * t_3321) * 92.5));
y_3324 = (((((u_3322 * u_3322) * 80D) + (((2D * u_3322) * t_3321) * 91.5)) + ((t_3321 * t_3321) * 80D)) + (ToNum(pull_3214) * 6D));
Invoke(C_3221, "push", Arr(((V)(x_3323)), ((V)(y_3324)), ((V)(0D))));
Invoke(R_3222, "push", ((V)((4.6 - (0.9 * Pow((System.Math.Abs((t_3321 - 0.5)) * 2D), 3D))))));
i_3319++;
}
}
Call(set_3212, V.Undef, Get(B_3209, "crust"), ((V)("d")), Call(tubeD_45, V.Undef, D_3210, C_3221, R_3222));
lp_3223 = Invoke(Invoke(C_3221, "slice", ((V)(1D)), ((V)((-1D)))), "map", Fn((V _arrowThis3333, int _argc3325, V c_3331, V i_3332, V _a3329, V _a3330, V[] _rest3326) => {
return Call(P3_3211, V.Undef, GetIdx(c_3331, 0D), ((V)((ToNum(GetIdx(c_3331, 1D)) - (ToNum(GetK(R_3222, Add(i_3332, ((V)(1D))))) * 0.72)))), ((V)(((s_3219 * ToNum(GetK(R_3222, Add(i_3332, ((V)(1D)))))) * 0.55))));
}, 2, "", true));
Call(set_3212, V.Undef, Get(B_3209, "cl"), ((V)("d")), Call(runs_21, V.Undef, lp_3223, Invoke(lp_3223, "map", Fn((V _arrowThis3340, int _argc3334, V _a3336, V _a3337, V _a3338, V _a3339, V[] _rest3335) => {
return (true ? V.True : V.False);
}, 0, "", true))));
Call(set_3212, V.Undef, Get(B_3209, "char"), ((V)("d")), Invoke(Invoke(Arr(Arr(((V)(1.6)), ((V)((-0.1))), ((V)(1.1))), Arr(((V)(3.2)), ((V)(0.25)), ((V)(0.8))), Arr(((V)(4.6)), ((V)((-0.2))), ((V)(1.2))), Arr(((V)(6.3)), ((V)(0.15)), ((V)(0.9))), Arr(((V)(7.7)), ((V)((-0.15))), ((V)(1D))), Arr(((V)(8.9)), ((V)(0.3)), ((V)(0.7)))), "map", Fn((V _arrowThis3354, int _argc3341, V _a3343, V _a3344, V _a3345, V _a3346, V[] _rest3342) => {
double a_3355 = 0;
double f_3356 = 0;
V c_3357 = default;
V rr_3358 = default;
V i_3349 = default;
V dy_3351 = default;
V r_3353 = default;
{ V _t3347 = ListOf(_a3343);
{ V _t3348 = GetIdx(_t3347, 0D);
i_3349 = _t3348; }
{ V _t3350 = GetIdx(_t3347, 1D);
dy_3351 = _t3350; }
{ V _t3352 = GetIdx(_t3347, 2D);
r_3353 = _t3352; }
}
a_3355 = System.Math.Floor(ToNum(i_3349));
f_3356 = (ToNum(i_3349) - a_3355);
c_3357 = Arr(Add(GetIdx(GetIdx(C_3221, a_3355), 0D), ((V)(((ToNum(GetIdx(GetIdx(C_3221, (a_3355 + 1D)), 0D)) - ToNum(GetIdx(GetIdx(C_3221, a_3355), 0D))) * f_3356)))), Add(GetIdx(GetIdx(C_3221, a_3355), 1D), ((V)(((ToNum(GetIdx(GetIdx(C_3221, (a_3355 + 1D)), 1D)) - ToNum(GetIdx(GetIdx(C_3221, a_3355), 1D))) * f_3356)))));
rr_3358 = GetIdx(R_3222, a_3355);
return Call(ellD_20, V.Undef, Call(P3_3211, V.Undef, GetIdx(c_3357, 0D), Add(GetIdx(c_3357, 1D), ((V)((ToNum(dy_3351) * ToNum(rr_3358))))), ((V)(((s_3219 * ToNum(rr_3358)) * 0.82)))), ((V)((ToNum(r_3353) * ToNum(Get(D_3210, "kS"))))), ((V)(((ToNum(r_3353) * 0.65) * ToNum(Get(D_3210, "kS"))))), ((V)(0D)));
return default;
}, 1, "", true)), "join", ((V)(""))));
sd_3224 = new JsStrBuf("");
if (GtN(pull_3214, 0.02)) {
Invoke(Arr(((V)(20D)), ((V)(33D)), ((V)(47D)), ((V)(61D)), ((V)(75D))), "forEach", Fn((V _arrowThis3367, int _argc3359, V x_3365, V i_3366, V _a3363, V _a3364, V[] _rest3360) => {
double yb_3368 = 0;
V a_3369 = default;
V b_3370 = default;
V m_3371 = default;
yb_3368 = (74D + ((1D - Pow(((ToNum(x_3365) - 50D) / 42D), 2D)) * 5D));
a_3369 = Call(W_3216, V.Undef, x_3365, ((V)((yb_3368 - 1D))), ((V)((s_3219 * ToNum(Add(T_3213, ((V)(0.3))))))));
b_3370 = Call(P3_3211, V.Undef, Add(x_3365, ((V)((FdLibm.Sin((ToNum(i_3366) * 2.1)) * 1.2)))), ((V)(((yb_3368 + 2D) + (ToNum(pull_3214) * 6D)))), ((V)((s_3219 * 1D))));
m_3371 = Call(P3_3211, V.Undef, Add(x_3365, ((V)(((FdLibm.Sin(ToNum(Add(((V)((ToNum(Get(D_3210, "ts")) * 6D))), i_3366))) * 0.8) * ToNum(pull_3214))))), ((V)(((yb_3368 + 1D) + (ToNum(pull_3214) * 3D)))), ((V)((s_3219 * ToNum(Add(T_3213, ((V)(0.5))))))));
sd_3224.S("M").V(Call(pt_15, V.Undef, a_3369)).S("Q").V(Call(pt_15, V.Undef, m_3371)).S(" ").V(Call(pt_15, V.Undef, b_3370));
return default;
}, 2, "", true));
}
Call(set_3212, V.Undef, Get(B_3209, "strings"), ((V)("d")), (((V)(sd_3224.Str)) is var _t3372 && Truthy(_t3372) ? _t3372 : ((V)("M0 0"))));
Call(set_3212, V.Undef, Get(B_3209, "strings"), ((V)("stroke-width")), Call(r2_11, V.Undef, ((V)((0.6 + (ToNum(pull_3214) * 1.2))))));
return default;
}, 2, "draw", false)).V);
Set(MODELS_42, "sunny", NewObj(2).Put("setup", Fn((V _self3373, int _argc3374, V S_3380, V _a3377, V _a3378, V _a3379, V[] _rest3375) => {
V sk_3381 = default;
V O_3382 = default;
V rT_3383 = default;
double YK_3384 = 0;
V crack_3385 = default;
V spk_3386 = default;
V open_3387 = default;
V yolk_3388 = default;
V capE_3389 = default;
V capL_3390 = default;
V SP_3391 = default;
V OS_3392 = default;
V roll_3393 = default;
if (_self3373.IsNullish) _self3373 = GlobalV;
{ V _t3394 = S_3380;
if (_t3394.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t3394));
{ V _t3395 = Get(_t3394, "sk");
sk_3381 = _t3395; } }
O_3382 = Invoke(S_3380, "outline", sk_3381, ((V)(72D)));
rT_3383 = Fn((V _arrowThis3403, int _argc3396, V y_3402, V _a3399, V _a3400, V _a3401, V[] _rest3397) => {
return Call(halfW_38, V.Undef, O_3382, Call(clamp_12, V.Undef, y_3402, ((V)(12.2)), ((V)(91.8))));
}, 1, "", true);
YK_3384 = 31.8;
Invoke(S_3380, "hide", Fn((V _arrowThis3411, int _argc3404, V q_3410, V _a3407, V _a3408, V _a3409, V[] _rest3405) => {
return (Get(q_3410, "inBody") is var _t3412 && !Truthy(_t3412) ? _t3412 : ((SEqS(Invoke(S_3380, "s", q_3410), "#c9a87c") || SEqS(Invoke(S_3380, "f", q_3410), "#d8c09c")) ? V.True : V.False));
}, 1, "", true));
crack_3385 = Invoke(S_3380, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#c9a87c"))).Put("stroke-width", ((V)(0.9))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V);
spk_3386 = Invoke(S_3380, "path", NewObj(2).Put("fill", ((V)("#d8c09c"))).Put("opacity", ((V)(0.55))).V);
open_3387 = Invoke(S_3380, "path", NewObj(1).Put("fill", ((V)("#fffdf6"))).V);
yolk_3388 = Invoke(S_3380, "path", NewObj(1).Put("fill", Invoke(S_3380, "rgrad", ((V)("sny")), Arr(Arr(((V)(0D)), ((V)("#fff3a8"))), Arr(((V)(0.6)), ((V)("#ffc42c"))), Arr(((V)(1D)), ((V)("#ef9410")))), NewObj(3).Put("cx", ((V)("42%"))).Put("cy", ((V)("35%"))).Put("r", ((V)("70%"))).V)).V);
capE_3389 = Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", Invoke(S_3380, "f", sk_3381)).V, Get(S_3380, "gB"));
capL_3390 = Call(el_14, V.Undef, ((V)("path")), NewObj(3).Put("fill", ((V)("none"))).Put("stroke", ((V)("#c9a87c"))).Put("stroke-width", ((V)(0.8))).V, Get(S_3380, "gB"));
SP_3391 = Invoke(Array_from(NewObj(1).Put("length", ((V)(18D))).V, Fn((V _arrowThis3433, int _argc3425, V __3431, V i_3432, V _a3429, V _a3430, V[] _rest3426) => {
return Arr(((V)((ToNum(Call(rnd_22, V.Undef, ((V)((ToNum(i_3432) * 3.7))))) * TAU_9))), ((V)((16D + (ToNum(Call(rnd_22, V.Undef, ((V)((ToNum(i_3432) * 5.9))))) * 72D)))));
}, 2, "", true)), "filter", Fn((V _arrowThis3424, int _argc3413, V _a3415, V _a3416, V _a3417, V _a3418, V[] _rest3414) => {
V f_3421 = default;
V y_3423 = default;
{ V _t3419 = ListOf(_a3415);
{ V _t3420 = GetIdx(_t3419, 0D);
f_3421 = _t3420; }
{ V _t3422 = GetIdx(_t3419, 1D);
y_3423 = _t3422; }
}
return (!((((System.Math.Abs(FdLibm.Atan2(FdLibm.Sin(ToNum(f_3421)), FdLibm.Cos(ToNum(f_3421)))) < 0.55) && GtN(y_3423, 50D)) && LtN(y_3423, 72D))) ? V.True : V.False);
}, 1, "", true));
OS_3392 = Invoke(O_3382, "filter", Fn((V _arrowThis3442, int _argc3434, V p_3440, V i_3441, V _a3438, V _a3439, V[] _rest3435) => {
return (((ToNum(i_3441) % 2D) == 0D) ? V.True : V.False);
}, 2, "", true));
roll_3393 = Fn((V _arrowThis3453, int _argc3443, V a_3449, V P_3450, V G_3451, V sy_3452, V[] _rest3444) => {
double c_3454 = 0;
double s_3455 = 0;
V lf_3456 = default;
V px_3457 = default;
V cx_3458 = default;
double cy_3459 = 0;
double my_3460 = 0;
c_3454 = FdLibm.Cos(ToNum(a_3449));
s_3455 = FdLibm.Sin(ToNum(a_3449));
lf_3456 = (((V)(ToNum(Get(P_3450, "lift")))) is var _t3461 && Truthy(_t3461) ? _t3461 : ((V)(0D)));
px_3457 = (((V)(ToNum(Get(P_3450, "x")))) is var _t3462 && Truthy(_t3462) ? _t3462 : ((V)(0D)));
cx_3458 = Add(((V)(50D)), px_3457);
cy_3459 = ((ToNum(G_3451) - ToNum(lf_3456)) - ((ToNum(G_3451) - 56D) * ToNum(sy_3452)));
my_3460 = (-1000000000D);
Invoke(OS_3392, "forEach", Fn((V _arrowThis3470, int _argc3463, V p_3469, V _a3466, V _a3467, V _a3468, V[] _rest3464) => {
V gx_3471 = default;
double gy_3472 = 0;
double y_3473 = 0;
gx_3471 = Add(GetIdx(p_3469, 0D), px_3457);
gy_3472 = ((ToNum(G_3451) - ToNum(lf_3456)) - ((ToNum(G_3451) - ToNum(GetIdx(p_3469, 1D))) * ToNum(sy_3452)));
y_3473 = ((cy_3459 + ((ToNum(gx_3471) - ToNum(cx_3458)) * s_3455)) + ((gy_3472 - cy_3459) * c_3454));
if ((y_3473 > my_3460)) {
my_3460 = y_3473;
}
return default;
}, 1, "", true));
return NewObj(5).Put("c", ((V)(c_3454))).Put("s", ((V)(s_3455))).Put("cx", cx_3458).Put("cy", ((V)(cy_3459))).Put("up", ((V)((my_3460 - (ToNum(G_3451) - ToNum(lf_3456)))))).V;
return default;
}, 4, "", true);
return NewObj(15).Put("O", O_3382).Put("rT", rT_3383).Put("YK", ((V)(YK_3384))).Put("crack", crack_3385).Put("spk", spk_3386).Put("open", open_3387).Put("yolk", yolk_3388).Put("capE", capE_3389).Put("capL", capL_3390).Put("SP", SP_3391).Put("roll", roll_3393).Put("rx", ((V)(30D))).Put("ya", ((V)(30D))).Put("yb", ((V)(88D))).Put("zE", Fn((V _arrowThis3482, int _argc3474, V dx_3480, V dy_3481, V _a3478, V _a3479, V[] _rest3475) => {
V r_3483 = default;
r_3483 = Call(rT_3383, V.Undef, Add(Get(S_3380, "HY"), dy_3481));
return ((V)((System.Math.Sqrt(Max(0D, ((ToNum(r_3483) * ToNum(r_3483)) - (ToNum(dx_3480) * ToNum(dx_3480))))) + 0.3)));
return default;
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self3484, int _argc3485, V B_3491, V D_3492, V _a3489, V _a3490, V[] _rest3486) => {
V P3_3493 = default;
V set_3494 = default;
V rT_3495 = default;
V YK_3496 = default;
V cap_3497 = default;
V wob_3498 = default;
V ring_3499 = default;
V y0_3500 = default;
V hp_3501 = default;
V rk_3502 = default;
V CA_3503 = default;
V cq_3504 = default;
double EL_3505 = 0;
V PE_3506 = default;
double yr_3507 = 0;
double yk_3508 = 0;
double lift_3509 = 0;
double tip_3510 = 0;
double ct_3511 = 0;
double st_3512 = 0;
V pv_3513 = default;
V cp_3514 = default;
V cl_3515 = default;
if (_self3484.IsNullish) _self3484 = GlobalV;
{ V _t3516 = D_3492;
if (_t3516.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t3516));
{ V _t3517 = Get(_t3516, "P3");
P3_3493 = _t3517; }
{ V _t3518 = Get(_t3516, "set");
set_3494 = _t3518; } }
rT_3495 = Get(B_3491, "rT");
YK_3496 = Get(B_3491, "YK");
cap_3497 = Call(clamp_12, V.Undef, Invoke(D_3492, "bv", ((V)("cap"))), ((V)(0D)), ((V)(1.2)));
wob_3498 = Call(clamp_12, V.Undef, Invoke(D_3492, "bv", ((V)("wob"))), ((V)(0D)), ((V)(1.6)));
ring_3499 = Fn((V _arrowThis3528, int _argc3519, V r_3525, V y_3526, V n_3527, V _a3524, V[] _rest3520) => {
return Array_from(NewObj(1).Put("length", n_3527).V, Fn((V _arrowThis3537, int _argc3529, V __3535, V k_3536, V _a3533, V _a3534, V[] _rest3530) => {
double f_3538 = 0;
f_3538 = ((ToNum(k_3536) / ToNum(n_3527)) * TAU_9);
return Call(P3_3493, V.Undef, ((V)((50D + (ToNum(r_3525) * FdLibm.Sin(f_3538))))), y_3526, ((V)((ToNum(r_3525) * FdLibm.Cos(f_3538)))));
return default;
}, 2, "", true));
}, 3, "", true);
y0_3500 = (GtN(cap_3497, 0.02) ? YK_3496 : ((V)(12.2)));
hp_3501 = Arr();
{
double i_3539 = 0;
i_3539 = 0D;
while (true) {
if (!((i_3539 <= 18D))) break;
V y_3541 = default;
y_3541 = Add(y0_3500, ((V)((((91.8 - ToNum(y0_3500)) * i_3539) / 18D))));
InvokeSpread(hp_3501, "push", new ArrBuilder().Spread(Call(ring_3499, V.Undef, Call(rT_3495, V.Undef, y_3541), y_3541, ((V)(24D)))).V);
i_3539++;
}
}
Set(B_3491, "d", Invoke(D_3492, "hull", hp_3501));
Call(set_3494, V.Undef, Get(B_3491, "spk"), ((V)("d")), (Invoke(Invoke(Invoke(Get(B_3491, "SP"), "filter", Fn((V _arrowThis3565, int _argc3554, V _a3556, V _a3557, V _a3558, V _a3559, V[] _rest3555) => {
V f_3562 = default;
V y_3564 = default;
{ V _t3560 = ListOf(_a3556);
{ V _t3561 = GetIdx(_t3560, 0D);
f_3562 = _t3561; }
{ V _t3563 = GetIdx(_t3560, 1D);
y_3564 = _t3563; }
}
return ((Gt(y_3564, Add(y0_3500, ((V)(1D)))) && GtN(Invoke(D_3492, "facing", ((V)((50D + (ToNum(Call(rT_3495, V.Undef, y_3564)) * FdLibm.Sin(ToNum(f_3562)))))), y_3564, ((V)((ToNum(Call(rT_3495, V.Undef, y_3564)) * FdLibm.Cos(ToNum(f_3562))))), ((V)(FdLibm.Sin(ToNum(f_3562)))), ((V)(0D)), ((V)(FdLibm.Cos(ToNum(f_3562))))), 0.05)) ? V.True : V.False);
}, 1, "", true)), "map", Fn((V _arrowThis3553, int _argc3542, V _a3544, V _a3545, V _a3546, V _a3547, V[] _rest3543) => {
V f_3550 = default;
V y_3552 = default;
{ V _t3548 = ListOf(_a3544);
{ V _t3549 = GetIdx(_t3548, 0D);
f_3550 = _t3549; }
{ V _t3551 = GetIdx(_t3548, 1D);
y_3552 = _t3551; }
}
return Call(circD_19, V.Undef, Call(P3_3493, V.Undef, ((V)((50D + (ToNum(Add(Call(rT_3495, V.Undef, y_3552), ((V)(0.1)))) * FdLibm.Sin(ToNum(f_3550)))))), y_3552, ((V)((ToNum(Add(Call(rT_3495, V.Undef, y_3552), ((V)(0.1)))) * FdLibm.Cos(ToNum(f_3550)))))), ((V)((0.75 * ToNum(Get(D_3492, "kS"))))));
}, 1, "", true)), "join", ((V)(""))) is var _t3566 && Truthy(_t3566) ? _t3566 : ((V)("M0 0"))));
rk_3502 = Call(rT_3495, V.Undef, YK_3496);
CA_3503 = Invoke(Get(SN_43, "h"), "frontArc", D_3492, rk_3502, YK_3496, ((V)(72D)));
cq_3504 = Invoke(CA_3503, "map", Fn((V _arrowThis3575, int _argc3567, V f_3573, V i_3574, V _a3571, V _a3572, V[] _rest3568) => {
return Call(P3_3493, V.Undef, ((V)((50D + (ToNum(Add(rk_3502, ((V)(0.1)))) * FdLibm.Sin(ToNum(f_3573)))))), Add(YK_3496, ((V)((NumTruthy((ToNum(i_3574) % 2D)) ? (-1.6) : 1.4)))), ((V)((ToNum(Add(rk_3502, ((V)(0.1)))) * FdLibm.Cos(ToNum(f_3573))))));
}, 2, "", true));
if (LeN(cap_3497, 0.02)) {
Call(set_3494, V.Undef, Get(B_3491, "crack"), ((V)("d")), (Call(runs_21, V.Undef, cq_3504, Invoke(cq_3504, "map", Fn((V _arrowThis3582, int _argc3576, V _a3578, V _a3579, V _a3580, V _a3581, V[] _rest3577) => {
return (true ? V.True : V.False);
}, 0, "", true))) is var _t3583 && Truthy(_t3583) ? _t3583 : ((V)("M0 0"))));
Invoke(Arr(((V)("open")), ((V)("yolk")), ((V)("capE")), ((V)("capL"))), "forEach", Fn((V _arrowThis3591, int _argc3584, V k_3590, V _a3587, V _a3588, V _a3589, V[] _rest3585) => {
return Call(set_3494, V.Undef, GetK(B_3491, k_3590), ((V)("d")), ((V)("M0 0")));
}, 1, "", true));
return default;
}
Call(set_3494, V.Undef, Get(B_3491, "crack"), ((V)("d")), ((V)("M0 0")));
EL_3505 = 0.22;
PE_3506 = Fn((V _arrowThis3601, int _argc3592, V x_3598, V y_3599, V z_3600, V _a3597, V[] _rest3593) => {
V p_3602 = default;
p_3602 = Call(P3_3493, V.Undef, x_3598, y_3599, z_3600);
return Arr(GetIdx(p_3602, 0D), Add(GetIdx(p_3602, 1D), ((V)((EL_3505 * (ToNum(Invoke(D_3492, "Z3", x_3598, y_3599, z_3600)) - ToNum(rk_3502)))))));
return default;
}, 3, "", true);
Call(set_3494, V.Undef, Get(B_3491, "open"), ((V)("d")), Call(polyW_18, V.Undef, Array_from(NewObj(1).Put("length", ((V)(36D))).V, Fn((V _arrowThis3611, int _argc3603, V __3609, V k_3610, V _a3607, V _a3608, V[] _rest3604) => {
double f_3612 = 0;
f_3612 = ((ToNum(k_3610) / 36D) * TAU_9);
return Call(PE_3506, V.Undef, ((V)((50D + (ToNum(rk_3502) * FdLibm.Sin(f_3612))))), YK_3496, ((V)((ToNum(rk_3502) * FdLibm.Cos(f_3612)))));
return default;
}, 2, "", true))));
yr_3507 = ((ToNum(rk_3502) * 0.62) * (1D + ((ToNum(wob_3498) * 0.06) * FdLibm.Sin((ToNum(Get(D_3492, "ts")) * 15D)))));
yk_3508 = ((ToNum(YK_3496) - 1.2) - ((ToNum(wob_3498) * 0.6) * FdLibm.Sin((ToNum(Get(D_3492, "ts")) * 17D))));
Call(set_3494, V.Undef, Get(B_3491, "yolk"), ((V)("d")), Call(polyW_18, V.Undef, Array_from(NewObj(1).Put("length", ((V)(30D))).V, Fn((V _arrowThis3621, int _argc3613, V __3619, V k_3620, V _a3617, V _a3618, V[] _rest3614) => {
double f_3622 = 0;
f_3622 = ((ToNum(k_3620) / 30D) * TAU_9);
return Call(PE_3506, V.Undef, ((V)((50D + (yr_3507 * FdLibm.Sin(f_3622))))), ((V)(yk_3508)), ((V)((yr_3507 * FdLibm.Cos(f_3622)))));
return default;
}, 2, "", true))));
lift_3509 = (ToNum(cap_3497) * 11D);
tip_3510 = (((ToNum(cap_3497) * 58D) * System.Math.PI) / 180D);
ct_3511 = FdLibm.Cos(tip_3510);
st_3512 = FdLibm.Sin(tip_3510);
pv_3513 = Arr(((V)(50D)), YK_3496, ((V)((-ToNum(rk_3502)))));
cp_3514 = Arr();
{
double i_3623 = 0;
i_3623 = 0D;
while (true) {
if (!((i_3623 <= 8D))) break;
double y_3625 = 0;
V r_3626 = default;
y_3625 = (12.2 + (((ToNum(YK_3496) - 12.2) * i_3623) / 8D));
r_3626 = Call(rT_3495, V.Undef, ((V)(y_3625)));
{
double k_3627 = 0;
k_3627 = 0D;
while (true) {
if (!((k_3627 < 20D))) break;
double f_3629 = 0;
double x_3630 = 0;
double z_3631 = 0;
double vy_3632 = 0;
double vz_3633 = 0;
f_3629 = ((k_3627 / 20D) * TAU_9);
x_3630 = (50D + (ToNum(r_3626) * FdLibm.Sin(f_3629)));
z_3631 = (ToNum(r_3626) * FdLibm.Cos(f_3629));
vy_3632 = (y_3625 - ToNum(GetIdx(pv_3513, 1D)));
vz_3633 = (z_3631 - ToNum(GetIdx(pv_3513, 2D)));
Invoke(cp_3514, "push", Call(P3_3493, V.Undef, ((V)(x_3630)), ((V)(((ToNum(Add(GetIdx(pv_3513, 1D), ((V)((vy_3632 * ct_3511))))) - (vz_3633 * st_3512)) - lift_3509))), Add(Add(GetIdx(pv_3513, 2D), ((V)((vy_3632 * st_3512)))), ((V)((vz_3633 * ct_3511))))));
k_3627++;
}
}
i_3623++;
}
}
Call(set_3494, V.Undef, Get(B_3491, "capE"), ((V)("d")), Invoke(D_3492, "hull", cp_3514));
cl_3515 = Arr();
{
double k_3634 = 0;
k_3634 = 0D;
while (true) {
if (!((k_3634 <= 24D))) break;
double f_3636 = 0;
double x_3637 = 0;
double z_3638 = 0;
double vz_3639 = 0;
f_3636 = (((-System.Math.PI) / 2D) + ((System.Math.PI * k_3634) / 24D));
x_3637 = (50D + (ToNum(rk_3502) * FdLibm.Sin(f_3636)));
z_3638 = (ToNum(rk_3502) * FdLibm.Cos(f_3636));
vz_3639 = (z_3638 - ToNum(GetIdx(pv_3513, 2D)));
Invoke(cl_3515, "push", Call(P3_3493, V.Undef, ((V)(x_3637)), ((V)(((ToNum(GetIdx(pv_3513, 1D)) - (vz_3639 * st_3512)) - lift_3509))), Add(GetIdx(pv_3513, 2D), ((V)((vz_3639 * ct_3511))))));
k_3634++;
}
}
Call(set_3494, V.Undef, Get(B_3491, "capL"), ((V)("d")), Call(runs_21, V.Undef, cl_3515, Invoke(cl_3515, "map", Fn((V _arrowThis3646, int _argc3640, V _a3642, V _a3643, V _a3644, V _a3645, V[] _rest3641) => {
return (true ? V.True : V.False);
}, 0, "", true))));
return default;
}, 2, "draw", false)).V);
Set(MODELS_42, "khinki", NewObj(2).Put("setup", Fn((V _self3647, int _argc3648, V S_3654, V _a3651, V _a3652, V _a3653, V[] _rest3649) => {
V sk_3655 = default;
V O_3656 = default;
V rT_3657 = default;
V KN_3658 = default;
V kn_3659 = default;
V KF_3660 = default;
double Y0_3661 = 0;
double Y1_3662 = 0;
V tw_3663 = default;
V xw_3664 = default;
V dep_3665 = default;
V PG_3666 = default;
V LN_3667 = default;
V knob_3668 = default;
V KG_3669 = default;
V KL_3670 = default;
V pep_3671 = default;
V cone_3672 = default;
V kp_3673 = default;
V PE_3674 = default;
double LC_3675 = 0;
V limb_3676 = default;
if (_self3647.IsNullish) _self3647 = GlobalV;
{ V _t3677 = S_3654;
if (_t3677.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t3677));
{ V _t3678 = Get(_t3677, "sk");
sk_3655 = _t3678; } }
O_3656 = Invoke(S_3654, "outline", sk_3655, ((V)(80D)));
rT_3657 = Fn((V _arrowThis3686, int _argc3679, V y_3685, V _a3682, V _a3683, V _a3684, V[] _rest3680) => {
return Call(halfW_38, V.Undef, O_3656, Call(clamp_12, V.Undef, y_3685, ((V)(27.6)), ((V)(90.2))));
}, 1, "", true);
KN_3658 = Fn((V _arrowThis3694, int _argc3687, V y_3693, V _a3690, V _a3691, V _a3692, V[] _rest3688) => {
return ((V)((GeN(y_3693, 20.5) ? (6.9 - ((28.5 - ToNum(y_3693)) * 0.16)) : (5.62 * System.Math.Sqrt(Max(0D, (1D - Pow(((20.5 - ToNum(y_3693)) / 3.6), 2D))))))));
}, 1, "", true);
kn_3659 = GetIdx(Invoke(S_3654, "hide", Fn((V _arrowThis3702, int _argc3695, V q_3701, V _a3698, V _a3699, V _a3700, V[] _rest3696) => {
return (Get(q_3701, "inBody") is var _t3703 && !Truthy(_t3703) ? _t3703 : Invoke(NewRegExp(RX12, "^url\\(#k", ""), "test", Invoke(S_3654, "f", q_3701)));
}, 1, "", true)), 0D);
KF_3660 = (Truthy(kn_3659) ? Invoke(S_3654, "f", kn_3659) : ((V)("#e3c895")));
Invoke(S_3654, "hide", Fn((V _arrowThis3711, int _argc3704, V q_3710, V _a3707, V _a3708, V _a3709, V[] _rest3705) => {
return (Get(q_3710, "inBody") is var _t3712 && !Truthy(_t3712) ? _t3712 : Invoke(S_3654, "dk", q_3710));
}, 1, "", true));
Y0_3661 = 28.2;
Y1_3662 = 90D;
tw_3663 = Fn((V _arrowThis3720, int _argc3713, V y_3719, V _a3716, V _a3717, V _a3718, V[] _rest3714) => {
return ((V)((0.55 * Pow((1D - ToNum(Call(clamp_12, V.Undef, ((V)(((ToNum(y_3719) - Y0_3661) / 30.8))), ((V)(0D)), ((V)(1D))))), 2D))));
}, 1, "", true);
xw_3664 = Fn((V _arrowThis3728, int _argc3721, V y_3727, V _a3724, V _a3725, V _a3726, V[] _rest3722) => {
return ((V)(Pow((1D - ToNum(Call(clamp_12, V.Undef, ((V)(((ToNum(y_3727) - Y0_3661) / 44D))), ((V)(0D)), ((V)(1D))))), 2D)));
}, 1, "", true);
dep_3665 = Fn((V _arrowThis3736, int _argc3729, V y_3735, V _a3732, V _a3733, V _a3734, V[] _rest3730) => {
return ((V)((LeN(y_3735, 59D) ? (0.8 + (3D * Pow((1D - ToNum(Call(clamp_12, V.Undef, ((V)(((ToNum(y_3735) - Y0_3661) / 30.8))), ((V)(0D)), ((V)(1D))))), 0.8))) : (LeN(y_3735, 81D) ? (0.8 + (0.55 * FdLibm.Sin(((((ToNum(y_3735) - 59D) / 22D) * System.Math.PI) / 2D)))) : (0.4 + (0.95 * FdLibm.Cos(((ToNum(Call(clamp_12, V.Undef, ((V)(((ToNum(y_3735) - 81D) / 9D))), ((V)(0D)), ((V)(1D)))) * System.Math.PI) / 2D))))))));
}, 1, "", true);
PG_3666 = Invoke(S_3654, "g");
LN_3667 = Invoke(S_3654, "g");
knob_3668 = Invoke(S_3654, "path", NewObj(1).Put("fill", KF_3660).V);
KG_3669 = Invoke(S_3654, "g");
KL_3670 = Invoke(S_3654, "g");
pep_3671 = Invoke(S_3654, "path", NewObj(1).Put("fill", ((V)("#3e3028"))).V);
cone_3672 = Call(longSet_32, V.Undef, S_3654, NewObj(13).Put("N", ((V)(18D))).Put("ph", ((V)(((-TAU_9) / 36D)))).Put("rT", rT_3657).Put("y0", ((V)(Y0_3661))).Put("y1", ((V)(Y1_3662))).Put("NY", ((V)(24D))).Put("SY", Arr(((V)(28.2)), ((V)(36D)), ((V)(45D)), ((V)(56D)), ((V)(68D)), ((V)(79D)), ((V)(89.6)))).Put("tw", tw_3663).Put("dep", dep_3665).Put("cols", Arr(((V)("#b08c56")), ((V)("#ead6ac")), ((V)("#fdf3dc")))).Put("lc", ((V)("#a68552"))).Put("lw", ((V)(0.6))).Put("LS", Arr(Arr(((V)(0D)), ((V)(0.8))), Arr(((V)(0.45)), ((V)(0.55))), Arr(((V)(0.8)), ((V)(0.34))), Arr(((V)(1D)), ((V)(0.2))))).V, PG_3666, LN_3667);
kp_3673 = Call(pleatSet_29, V.Undef, NewObj(11).Put("N", ((V)(7D))).Put("rT", KN_3658).Put("y0", ((V)(18.2))).Put("yG", ((V)(28.8))).Put("yR", ((V)(28.8))).Put("ph", ((V)(0.3))).Put("tw", Fn((V _arrowThis3744, int _argc3737, V u_3743, V _a3740, V _a3741, V _a3742, V[] _rest3738) => {
return ((V)((1.25 * (1D - ToNum(u_3743)))));
}, 1, "tw", true)).Put("dep", Fn((V _arrowThis3751, int _argc3745, V _a3747, V _a3748, V _a3749, V _a3750, V[] _rest3746) => {
return ((V)(1D));
}, 0, "dep", true)).Put("cols", Arr(((V)("#a8844e")), ((V)("#e2c896")), ((V)("#fff6e2")))).Put("lc", ((V)("#9c7a48"))).Put("lw", ((V)(0.55))).V, KG_3669, KL_3670);
PE_3674 = Invoke(Array_from(NewObj(1).Put("length", ((V)(26D))).V, Fn((V _arrowThis3781, int _argc3773, V __3779, V i_3780, V _a3777, V _a3778, V[] _rest3774) => {
return Arr(((V)((ToNum(Call(rnd_22, V.Undef, ((V)((ToNum(i_3780) * 4.1))))) * TAU_9))), ((V)((31D + (ToNum(Call(rnd_22, V.Undef, ((V)((ToNum(i_3780) * 2.3))))) * 22D)))));
}, 2, "", true)), "concat", Invoke(Invoke(Array_from(NewObj(1).Put("length", ((V)(30D))).V, Fn((V _arrowThis3772, int _argc3764, V __3770, V i_3771, V _a3768, V _a3769, V[] _rest3765) => {
return Arr(((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_3771) * 3.7) + 9D))))) * TAU_9))), ((V)((58D + (ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_3771) * 1.9) + 4D))))) * 29D)))));
}, 2, "", true)), "filter", Fn((V _arrowThis3763, int _argc3752, V _a3754, V _a3755, V _a3756, V _a3757, V[] _rest3753) => {
V f_3760 = default;
V y_3762 = default;
{ V _t3758 = ListOf(_a3754);
{ V _t3759 = GetIdx(_t3758, 0D);
f_3760 = _t3759; }
{ V _t3761 = GetIdx(_t3758, 1D);
y_3762 = _t3761; }
}
return (!((LtN(y_3762, 84D) && (System.Math.Abs(FdLibm.Atan2(FdLibm.Sin(ToNum(f_3760)), FdLibm.Cos(ToNum(f_3760)))) < 0.75))) ? V.True : V.False);
}, 1, "", true)), "slice", ((V)(0D)), ((V)(14D))));
LC_3675 = 0D;
limb_3676 = Fn((V _arrowThis3795, int _argc3782, V q_3788, V kind_3789, V c_3790, V ax_3791, V[] _rest3783) => {
V ar_3796 = default;
double N_3797 = 0;
double H_3798 = 0;
double ph_3799 = 0;
double th0_3800 = 0;
double th1_3801 = 0;
double NS_3802 = 0;
double BE_3803 = 0;
V S3_3804 = default;
V P2_3805 = default;
V NV_3806 = default;
V BR_3807 = default;
V TH_3808 = default;
JsStrBuf dL_3809 = null;
JsStrBuf dD_3810 = null;
JsStrBuf dG_3811 = null;
V E_3792 = default;
V R_3793 = default;
V glob_3794 = default;
E_3792 = (_argc3782 > 4 ? _rest3783[0] : V.Undef);
R_3793 = (_argc3782 > 5 ? _rest3783[1] : V.Undef);
glob_3794 = (_argc3782 > 6 ? _rest3783[2] : V.Undef);
ar_3796 = (SEqS(kind_3789, "arm") ? V.True : V.False);
if (!(Truthy(Get(q_3788, "dec")))) {
V u_3812 = default;
V gr_3813 = default;
V fd_3814 = default;
u_3812 = ((V)(JsStrBuf.Begin().S("kl").N(LC_3675++).V(Get(S_3654, "u")).End()));
gr_3813 = Fn((V _arrowThis3824, int _argc3815, V n_3821, V col_3822, V st_3823, V _a3820, V[] _rest3816) => {
V g_3825 = default;
g_3825 = Call(el_14, V.Undef, ((V)("linearGradient")), NewObj(6).Put("id", Add(n_3821, u_3812)).Put("gradientUnits", ((V)("userSpaceOnUse"))).Put("x1", ((V)(0D))).Put("y1", ((V)(0D))).Put("x2", ((V)(0D))).Put("y2", ((V)(1D))).V, Get(S_3654, "df"));
Invoke(st_3823, "forEach", Fn((V _arrowThis3837, int _argc3826, V _a3828, V _a3829, V _a3830, V _a3831, V[] _rest3827) => {
V o_3834 = default;
V op_3836 = default;
{ V _t3832 = ListOf(_a3828);
{ V _t3833 = GetIdx(_t3832, 0D);
o_3834 = _t3833; }
{ V _t3835 = GetIdx(_t3832, 1D);
op_3836 = _t3835; }
}
return Call(el_14, V.Undef, ((V)("stop")), NewObj(3).Put("offset", o_3834).Put("stop-color", col_3822).Put("stop-opacity", op_3836).V, g_3825);
}, 1, "", true));
return g_3825;
return default;
}, 3, "", true);
fd_3814 = (Truthy(ar_3796) ? Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(0.45)), ((V)(0.85))), Arr(((V)(0.92)), ((V)(0D)))) : Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))));
Set(q_3788, "dGr", Arr(Call(gr_3813, V.Undef, ((V)("d")), ((V)("#8a6436")), fd_3814), Call(gr_3813, V.Undef, ((V)("l")), ((V)("#fffaf0")), fd_3814), Call(gr_3813, V.Undef, ((V)("g")), ((V)("#a68552")), fd_3814)));
Set(q_3788, "dec", Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, Get(Get(q_3788, "e"), "parentNode"), Get(Get(q_3788, "e"), "nextSibling")));
Set(q_3788, "dD", Call(el_14, V.Undef, ((V)("path")), NewObj(2).Put("fill", ((V)(JsStrBuf.Begin().S("url(#d").V(u_3812).S(")").End()))).Put("opacity", ((V)(0.2))).V, Get(q_3788, "dec")));
Set(q_3788, "dL", Call(el_14, V.Undef, ((V)("path")), NewObj(2).Put("fill", ((V)(JsStrBuf.Begin().S("url(#l").V(u_3812).S(")").End()))).Put("opacity", ((V)(0.45))).V, Get(q_3788, "dec")));
Set(q_3788, "dG", Call(el_14, V.Undef, ((V)("path")), NewObj(6).Put("fill", ((V)("none"))).Put("stroke", ((V)(JsStrBuf.Begin().S("url(#g").V(u_3812).S(")").End()))).Put("stroke-width", ((V)(0.42))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).Put("opacity", ((V)(0.7))).V, Get(q_3788, "dec")));
}
N_3797 = (Truthy(ar_3796) ? 8D : 10D);
H_3798 = (System.Math.PI / N_3797);
ph_3799 = (Truthy(ar_3796) ? 0D : H_3798);
th0_3800 = (Truthy(ar_3796) ? 0.04 : 0.14);
th1_3801 = (Truthy(ar_3796) ? 0.84 : 0.9);
NS_3802 = 8D;
BE_3803 = 0.38;
{
V r0_3838 = default;
V t0_3839 = default;
r0_3838 = Call(glob_3794, V.Undef, ((V)((ToNum(GetIdx(c_3790, 0D)) - ToNum(GetIdx(GetIdx(ax_3791, 1D), 0D))))), ((V)((ToNum(GetIdx(c_3790, 1D)) - ToNum(GetIdx(GetIdx(ax_3791, 1D), 1D))))));
t0_3839 = Call(glob_3794, V.Undef, Add(GetIdx(c_3790, 0D), GetIdx(GetIdx(ax_3791, 1D), 0D)), Add(GetIdx(c_3790, 1D), GetIdx(GetIdx(ax_3791, 1D), 1D)));
Invoke(Get(q_3788, "dGr"), "forEach", Fn((V _arrowThis3847, int _argc3840, V g_3846, V _a3843, V _a3844, V _a3845, V[] _rest3841) => {
Call(SA_31, V.Undef, g_3846, ((V)("x1")), Call(r2_11, V.Undef, GetIdx(r0_3838, 0D)));
Call(SA_31, V.Undef, g_3846, ((V)("y1")), Call(r2_11, V.Undef, GetIdx(r0_3838, 1D)));
Call(SA_31, V.Undef, g_3846, ((V)("x2")), Call(r2_11, V.Undef, GetIdx(t0_3839, 0D)));
Call(SA_31, V.Undef, g_3846, ((V)("y2")), Call(r2_11, V.Undef, GetIdx(t0_3839, 1D)));
return default;
}, 1, "", true));
}
S3_3804 = Fn((V _arrowThis3856, int _argc3848, V th_3854, V f_3855, V _a3852, V _a3853, V[] _rest3849) => {
return Arr(((V)((FdLibm.Sin(ToNum(th_3854)) * FdLibm.Sin(ToNum(f_3855))))), ((V)((-FdLibm.Cos(ToNum(th_3854))))), ((V)((FdLibm.Sin(ToNum(th_3854)) * FdLibm.Cos(ToNum(f_3855))))));
}, 2, "", true);
P2_3805 = Fn((V _arrowThis3864, int _argc3857, V s_3863, V _a3860, V _a3861, V _a3862, V[] _rest3858) => {
return Call(glob_3794, V.Undef, Add(Add(Add(GetIdx(c_3790, 0D), ((V)((ToNum(GetIdx(s_3863, 0D)) * ToNum(GetIdx(GetIdx(ax_3791, 0D), 0D)))))), ((V)((ToNum(GetIdx(s_3863, 1D)) * ToNum(GetIdx(GetIdx(ax_3791, 1D), 0D)))))), ((V)((ToNum(GetIdx(s_3863, 2D)) * ToNum(GetIdx(GetIdx(ax_3791, 2D), 0D)))))), Add(Add(Add(GetIdx(c_3790, 1D), ((V)((ToNum(GetIdx(s_3863, 0D)) * ToNum(GetIdx(GetIdx(ax_3791, 0D), 1D)))))), ((V)((ToNum(GetIdx(s_3863, 1D)) * ToNum(GetIdx(GetIdx(ax_3791, 1D), 1D)))))), ((V)((ToNum(GetIdx(s_3863, 2D)) * ToNum(GetIdx(GetIdx(ax_3791, 2D), 1D)))))));
}, 1, "", true);
NV_3806 = Fn((V _arrowThis3872, int _argc3865, V s_3871, V _a3868, V _a3869, V _a3870, V[] _rest3866) => {
V n_3873 = default;
V l_3874 = default;
n_3873 = Arr(((V)(0D)), ((V)(0D)), ((V)(0D)));
{
double i_3875 = 0;
i_3875 = 0D;
while (true) {
if (!((i_3875 < 3D))) break;
double k_3877 = 0;
k_3877 = (ToNum(GetIdx(s_3871, i_3875)) / ToNum(GetIdx(R_3793, i_3875)));
{
double j_3878 = 0;
j_3878 = 0D;
while (true) {
if (!((j_3878 < 3D))) break;
OpSetK(n_3873, ((V)(j_3878)), 0, ((V)((k_3877 * ToNum(GetIdx(GetIdx(E_3792, i_3875), j_3878))))));
j_3878++;
}
}
i_3875++;
}
}
l_3874 = (((V)(Hypot(ToNum(GetIdx(n_3873, 0D)), ToNum(GetIdx(n_3873, 1D)), ToNum(GetIdx(n_3873, 2D))))) is var _t3880 && Truthy(_t3880) ? _t3880 : ((V)(1D)));
return Arr(((V)((ToNum(GetIdx(n_3873, 0D)) / ToNum(l_3874)))), ((V)((ToNum(GetIdx(n_3873, 1D)) / ToNum(l_3874)))), ((V)((ToNum(GetIdx(n_3873, 2D)) / ToNum(l_3874)))));
return default;
}, 1, "", true);
BR_3807 = Fn((V _arrowThis3888, int _argc3881, V n_3887, V _a3884, V _a3885, V _a3886, V[] _rest3882) => {
return ((V)((((ToNum(GetIdx(n_3887, 0D)) * ToNum(GetIdx(LV_27, 0D))) + (ToNum(GetIdx(n_3887, 1D)) * ToNum(GetIdx(LV_27, 1D)))) + (ToNum(GetIdx(n_3887, 2D)) * ToNum(GetIdx(LV_27, 2D))))));
}, 1, "", true);
TH_3808 = Array_from(NewObj(1).Put("length", ((V)((NS_3802 + 1D)))).V, Fn((V _arrowThis3897, int _argc3889, V __3895, V i_3896, V _a3893, V _a3894, V[] _rest3890) => {
return ((V)((System.Math.PI * (th0_3800 + (((th1_3801 - th0_3800) * ToNum(i_3896)) / NS_3802)))));
}, 2, "", true));
dL_3809 = new JsStrBuf("");
dD_3810 = new JsStrBuf("");
dG_3811 = new JsStrBuf("");
{
double k_3898 = 0;
k_3898 = 0D;
while (true) {
if (!((k_3898 < N_3797))) break;
double fg_3900 = 0;
V G3_3901 = default;
fg_3900 = (ph_3799 + ((k_3898 * 2D) * H_3798));
G3_3901 = Invoke(TH_3808, "map", Fn((V _arrowThis3909, int _argc3902, V th_3908, V _a3905, V _a3906, V _a3907, V[] _rest3903) => {
return Call(S3_3804, V.Undef, th_3908, ((V)(fg_3900)));
}, 1, "", true));
dG_3811.V(Call(runs_21, V.Undef, Invoke(G3_3901, "map", P2_3805), Invoke(G3_3901, "map", Fn((V _arrowThis3917, int _argc3910, V s_3916, V _a3913, V _a3914, V _a3915, V[] _rest3911) => {
return (GtN(GetIdx(Call(NV_3806, V.Undef, s_3916), 2D), 0.03) ? V.True : V.False);
}, 1, "", true))));
{
double side_3918 = 0;
side_3918 = 0D;
while (true) {
if (!((side_3918 < 2D))) break;
double fa_3920 = 0;
double fb_3921 = 0;
double fm_3922 = 0;
V nm_3923 = default;
double d_3924 = 0;
V pd_3925 = default;
fa_3920 = (fg_3900 + (side_3918 * H_3798));
fb_3921 = (fa_3920 + H_3798);
fm_3922 = (fa_3920 + (H_3798 / 2D));
nm_3923 = Call(NV_3806, V.Undef, Call(S3_3804, V.Undef, ((V)((System.Math.PI / 2D))), ((V)(fm_3922))));
if (LtN(GetIdx(nm_3923, 2D), 0.05)) {
goto _cont3919;
}
d_3924 = (ToNum(Call(BR_3807, V.Undef, Call(NV_3806, V.Undef, Call(S3_3804, V.Undef, ((V)((System.Math.PI / 2D))), ((V)((fm_3922 + (NumTruthy(side_3918) ? BE_3803 : (-BE_3803))))))))) - ToNum(Call(BR_3807, V.Undef, nm_3923)));
if ((System.Math.Abs(d_3924) < 0.03)) {
goto _cont3919;
}
pd_3925 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Invoke(Invoke(TH_3808, "map", Fn((V _arrowThis3941, int _argc3934, V th_3940, V _a3937, V _a3938, V _a3939, V[] _rest3935) => {
return Call(P2_3805, V.Undef, Call(S3_3804, V.Undef, th_3940, ((V)(fa_3920))));
}, 1, "", true)), "concat", Invoke(Invoke(Invoke(TH_3808, "slice"), "reverse"), "map", Fn((V _arrowThis3933, int _argc3926, V th_3932, V _a3929, V _a3930, V _a3931, V[] _rest3927) => {
return Call(P2_3805, V.Undef, Call(S3_3804, V.Undef, th_3932, ((V)(fb_3921))));
}, 1, "", true))), "map", pt_15), "join", ((V)("L")))).S("Z").End()));
if ((d_3924 > 0D)) {
dL_3809.V(pd_3925);
} else {
dD_3810.V(pd_3925);
}
_cont3919: ;
side_3918++;
}
}
k_3898++;
}
}
Call(SA_31, V.Undef, Get(q_3788, "dL"), ((V)("d")), (((V)(dL_3809.Str)) is var _t3942 && Truthy(_t3942) ? _t3942 : ((V)("M0 0"))));
Call(SA_31, V.Undef, Get(q_3788, "dD"), ((V)("d")), (((V)(dD_3810.Str)) is var _t3943 && Truthy(_t3943) ? _t3943 : ((V)("M0 0"))));
Call(SA_31, V.Undef, Get(q_3788, "dG"), ((V)("d")), (((V)(dG_3811.Str)) is var _t3944 && Truthy(_t3944) ? _t3944 : ((V)("M0 0"))));
return default;
}, 7, "", true);
return NewObj(16).Put("O", O_3656).Put("rT", rT_3657).Put("KN", KN_3658).Put("tw", tw_3663).Put("xw", xw_3664).Put("dep", dep_3665).Put("knob", knob_3668).Put("cone", cone_3672).Put("kp", kp_3673).Put("pep", pep_3671).Put("PE", PE_3674).Put("limb", limb_3676).Put("rx", ((V)(37D))).Put("ya", ((V)(44D))).Put("yb", ((V)(88D))).Put("zE", Fn((V _arrowThis3953, int _argc3945, V dx_3951, V dy_3952, V _a3949, V _a3950, V[] _rest3946) => {
V r_3954 = default;
r_3954 = Call(rT_3657, V.Undef, Add(Get(S_3654, "HY"), dy_3952));
return ((V)((System.Math.Sqrt(Max(0D, ((ToNum(r_3954) * ToNum(r_3954)) - (ToNum(dx_3951) * ToNum(dx_3951))))) + 0.3)));
return default;
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self3955, int _argc3956, V B_3962, V D_3963, V _a3960, V _a3961, V[] _rest3957) => {
V P3_3964 = default;
V Z3_3965 = default;
V set_3966 = default;
V rT_3967 = default;
V kt_3968 = default;
V kq_3969 = default;
V hp_3970 = default;
V TW_3971 = default;
double sw_3972 = 0;
V KP_3973 = default;
V KZ_3974 = default;
V kh_3975 = default;
if (_self3955.IsNullish) _self3955 = GlobalV;
{ V _t3976 = D_3963;
if (_t3976.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t3976));
{ V _t3977 = Get(_t3976, "P3");
P3_3964 = _t3977; }
{ V _t3978 = Get(_t3976, "Z3");
Z3_3965 = _t3978; }
{ V _t3979 = Get(_t3976, "set");
set_3966 = _t3979; } }
rT_3967 = Get(B_3962, "rT");
kt_3968 = Call(clamp_12, V.Undef, Invoke(D_3963, "bv", ((V)("kt"))), ((V)((-1.2))), ((V)(1.2)));
kq_3969 = Call(clamp_12, V.Undef, Invoke(D_3963, "bv", ((V)("knot"))), ((V)((-1.2))), ((V)(1.2)));
hp_3970 = Arr();
{
double i_3980 = 0;
i_3980 = 0D;
while (true) {
if (!((i_3980 <= 20D))) break;
double y_3982 = 0;
V r_3983 = default;
y_3982 = (27.6 + ((62.6 * i_3980) / 20D));
r_3983 = Call(rT_3967, V.Undef, ((V)(y_3982)));
{
double k_3984 = 0;
k_3984 = 0D;
while (true) {
if (!((k_3984 < 24D))) break;
double f_3986 = 0;
f_3986 = ((k_3984 / 24D) * TAU_9);
Invoke(hp_3970, "push", Call(P3_3964, V.Undef, ((V)((50D + (ToNum(r_3983) * FdLibm.Sin(f_3986))))), ((V)(y_3982)), ((V)((ToNum(r_3983) * FdLibm.Cos(f_3986))))));
k_3984++;
}
}
i_3980++;
}
}
Set(B_3962, "d", Invoke(D_3963, "hull", hp_3970));
TW_3971 = Fn((V _arrowThis3994, int _argc3987, V y_3993, V _a3990, V _a3991, V _a3992, V[] _rest3988) => {
return Add(Invoke(B_3962, "tw", y_3993), ((V)(((ToNum(kt_3968) * 0.6) * ToNum(Invoke(B_3962, "xw", y_3993))))));
}, 1, "", true);
Call(longDraw_33, V.Undef, D_3963, Get(B_3962, "cone"), P3_3964, Z3_3965, TW_3971);
Call(set_3966, V.Undef, Get(B_3962, "pep"), ((V)("d")), (Invoke(Invoke(Invoke(Get(B_3962, "PE"), "filter", Fn((V _arrowThis4020, int _argc4009, V _a4011, V _a4012, V _a4013, V _a4014, V[] _rest4010) => {
V ff_4021 = default;
V f_4017 = default;
V y_4019 = default;
{ V _t4015 = ListOf(_a4011);
{ V _t4016 = GetIdx(_t4015, 0D);
f_4017 = _t4016; }
{ V _t4018 = GetIdx(_t4015, 1D);
y_4019 = _t4018; }
}
ff_4021 = Add(f_4017, Call(TW_3971, V.Undef, y_4019));
return (GtN(Invoke(D_3963, "facing", ((V)((50D + (ToNum(Call(rT_3967, V.Undef, y_4019)) * FdLibm.Sin(ToNum(ff_4021)))))), y_4019, ((V)((ToNum(Call(rT_3967, V.Undef, y_4019)) * FdLibm.Cos(ToNum(ff_4021))))), ((V)(FdLibm.Sin(ToNum(ff_4021)))), ((V)(0D)), ((V)(FdLibm.Cos(ToNum(ff_4021))))), 0.08) ? V.True : V.False);
return default;
}, 1, "", true)), "map", Fn((V _arrowThis4006, int _argc3995, V _a3997, V _a3998, V _a3999, V _a4000, V[] _rest3996) => {
V ff_4007 = default;
V r_4008 = default;
V f_4003 = default;
V y_4005 = default;
{ V _t4001 = ListOf(_a3997);
{ V _t4002 = GetIdx(_t4001, 0D);
f_4003 = _t4002; }
{ V _t4004 = GetIdx(_t4001, 1D);
y_4005 = _t4004; }
}
ff_4007 = Add(f_4003, Call(TW_3971, V.Undef, y_4005));
r_4008 = Add(Call(rT_3967, V.Undef, y_4005), ((V)((ToNum(Invoke(B_3962, "dep", y_4005)) * 0.55))));
return Call(circD_19, V.Undef, Call(P3_3964, V.Undef, ((V)((50D + (ToNum(r_4008) * FdLibm.Sin(ToNum(ff_4007)))))), y_4005, ((V)((ToNum(r_4008) * FdLibm.Cos(ToNum(ff_4007)))))), ((V)((0.5 * ToNum(Get(D_3963, "kS"))))));
return default;
}, 1, "", true)), "join", ((V)(""))) is var _t4022 && Truthy(_t4022) ? _t4022 : ((V)("M0 0"))));
sw_3972 = (((FdLibm.Sin((ToNum(Get(D_3963, "ts")) * 1.6)) * 0.5) + (ToNum(Get(D_3963, "ox")) * 0.25)) + (ToNum(kq_3969) * 3.5));
KP_3973 = Fn((V _arrowThis4032, int _argc4023, V x_4029, V y_4030, V z_4031, V _a4028, V[] _rest4024) => {
V u_4033 = default;
u_4033 = Call(clamp_12, V.Undef, ((V)(((28.8 - ToNum(y_4030)) / 12D))), ((V)(0D)), ((V)(1D)));
return Call(P3_3964, V.Undef, Add(x_4029, ((V)(((sw_3972 * ToNum(u_4033)) * ToNum(u_4033))))), ((V)((ToNum(y_4030) - ((ToNum(Get(D_3963, "oy")) * 0.25) * ToNum(u_4033))))), z_4031);
return default;
}, 3, "", true);
KZ_3974 = Fn((V _arrowThis4043, int _argc4034, V x_4040, V y_4041, V z_4042, V _a4039, V[] _rest4035) => {
return Call(Z3_3965, V.Undef, x_4040, y_4041, z_4042);
}, 3, "", true);
kh_3975 = Arr();
{
double i_4044 = 0;
i_4044 = 0D;
while (true) {
if (!((i_4044 <= 12D))) break;
double y_4046 = 0;
V r_4047 = default;
y_4046 = (28.8 - (((28.8 - 16.95) * i_4044) / 12D));
r_4047 = Invoke(B_3962, "KN", ((V)(y_4046)));
{
double k_4048 = 0;
k_4048 = 0D;
while (true) {
if (!((k_4048 < 16D))) break;
double f_4050 = 0;
f_4050 = ((k_4048 / 16D) * TAU_9);
Invoke(kh_3975, "push", Call(KP_3973, V.Undef, ((V)((50D + (ToNum(r_4047) * FdLibm.Sin(f_4050))))), ((V)(y_4046)), ((V)((ToNum(r_4047) * FdLibm.Cos(f_4050))))));
k_4048++;
}
}
i_4044++;
}
}
Call(set_3966, V.Undef, Get(B_3962, "knob"), ((V)("d")), Invoke(D_3963, "hull", kh_3975));
Call(pleatDraw_30, V.Undef, D_3963, Get(B_3962, "kp"), KP_3973, KZ_3974, ((V)(((ToNum(kt_3968) * 0.4) + (ToNum(kq_3969) * 0.5)))));
return default;
}, 2, "draw", false)).V);
Set(MODELS_42, "maki", NewObj(2).Put("setup", Fn((V _self4051, int _argc4052, V S_4058, V _a4055, V _a4056, V _a4057, V[] _rest4053) => {
double R0_4059 = 0;
double YT_4060 = 0;
double AL_4061 = 0;
double KF_4062 = 0;
V rT_4063 = default;
V ang_4064 = default;
V face_4065 = default;
V SG_4066 = default;
V TG_4067 = default;
V SS_4068 = default;
V TS_4069 = default;
V NR_4070 = default;
V C_4071 = default;
V SCc_4072 = default;
V SM_4073 = default;
V ringXZ_4074 = default;
V clip_4075 = default;
V bed_4076 = default;
V fr_4077 = default;
V shr_4078 = default;
V PC_4079 = default;
V GSH_4080 = default;
V GT_4081 = default;
V ses_4082 = default;
V top_4083 = default;
V tgr_4084 = default;
V tse_4085 = default;
V nori_4086 = default;
V bedE_4087 = default;
V VG_4088 = default;
V scl_4089 = default;
V LGR_4090 = default;
V limb_4091 = default;
if (_self4051.IsNullish) _self4051 = GlobalV;
R0_4059 = 29D;
YT_4060 = 38.6;
AL_4061 = FdLibm.Asin(0.44);
KF_4062 = (21.5 / 17.8);
rT_4063 = Fn((V _arrowThis4099, int _argc4092, V y_4098, V _a4095, V _a4096, V _a4097, V[] _rest4093) => {
return ((V)((GtN(y_4098, 82D) ? ((System.Math.Sqrt(Max(0D, (36D - ((ToNum(y_4098) - 82D) * (ToNum(y_4098) - 82D))))) + R0_4059) - 6D) : R0_4059)));
}, 1, "", true);
Invoke(S_4058, "hide", Fn((V _arrowThis4107, int _argc4100, V q_4106, V _a4103, V _a4104, V _a4105, V[] _rest4101) => {
return (Get(q_4106, "inBody") is var _t4108 && !Truthy(_t4108) ? _t4108 : Invoke(S_4058, "dk", q_4106));
}, 1, "", true));
ang_4064 = Fn((V _arrowThis4116, int _argc4109, V f_4115, V _a4112, V _a4113, V _a4114, V[] _rest4110) => {
return ((V)(FdLibm.Atan2(FdLibm.Sin(ToNum(f_4115)), FdLibm.Cos(ToNum(f_4115)))));
}, 1, "", true);
face_4065 = Fn((V _arrowThis4125, int _argc4117, V f_4123, V y_4124, V _a4121, V _a4122, V[] _rest4118) => {
return ((((System.Math.Abs(ToNum(Call(ang_4064, V.Undef, f_4123))) < 0.6) && GtN(y_4124, 52D)) && LtN(y_4124, 75D)) ? V.True : V.False);
}, 2, "", true);
SG_4066 = Invoke(Array_from(NewObj(1).Put("length", ((V)(300D))).V, Fn((V _arrowThis4142, int _argc4134, V __4140, V i_4141, V _a4138, V _a4139, V[] _rest4135) => {
return Arr(((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_4141) * 2.31) + 1D))))) * TAU_9))), ((V)(((YT_4060 + 2D) + (ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_4141) * 1.73) + 2D))))) * (84D - YT_4060))))), ((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_4141) * 3.1) + 5D))))) * System.Math.PI))));
}, 2, "", true)), "filter", Fn((V _arrowThis4133, int _argc4126, V g_4132, V _a4129, V _a4130, V _a4131, V[] _rest4127) => {
return (!(Truthy(Call(face_4065, V.Undef, GetIdx(g_4132, 0D), GetIdx(g_4132, 1D)))) ? V.True : V.False);
}, 1, "", true));
TG_4067 = Array_from(NewObj(1).Put("length", ((V)(52D))).V, Fn((V _arrowThis4151, int _argc4143, V __4149, V i_4150, V _a4147, V _a4148, V[] _rest4144) => {
return Arr(((V)((24.3 + (ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_4150) * 1.37) + 7D))))) * 4.2)))), ((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_4150) * 2.9) + 3D))))) * TAU_9))), ((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_4150) * 4.3) + 1D))))) * System.Math.PI))));
}, 2, "", true));
SS_4068 = Invoke(Array_from(NewObj(1).Put("length", ((V)(34D))).V, Fn((V _arrowThis4168, int _argc4160, V __4166, V i_4167, V _a4164, V _a4165, V[] _rest4161) => {
return Arr(((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_4167) * 5.1) + 11D))))) * TAU_9))), ((V)(((YT_4060 + 4D) + (ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_4167) * 2.2) + 9D))))) * (80D - YT_4060))))), ((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_4167) * 1.9) + 4D))))) * System.Math.PI))));
}, 2, "", true)), "filter", Fn((V _arrowThis4159, int _argc4152, V g_4158, V _a4155, V _a4156, V _a4157, V[] _rest4153) => {
return (!(Truthy(Call(face_4065, V.Undef, GetIdx(g_4158, 0D), GetIdx(g_4158, 1D)))) ? V.True : V.False);
}, 1, "", true));
TS_4069 = Array_from(NewObj(1).Put("length", ((V)(10D))).V, Fn((V _arrowThis4177, int _argc4169, V __4175, V i_4176, V _a4173, V _a4174, V[] _rest4170) => {
return Arr(((V)((24.5 + (ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_4176) * 3.3) + 2D))))) * 3.8)))), ((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_4176) * 1.1) + 8D))))) * TAU_9))), ((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_4176) * 2.7) + 6D))))) * System.Math.PI))));
}, 2, "", true));
NR_4070 = Fn((V _arrowThis4185, int _argc4178, V f_4184, V _a4181, V _a4182, V _a4183, V[] _rest4179) => {
return ((V)((KF_4062 * ((17.8 + (0.8 * FdLibm.Sin(((3D * ToNum(f_4184)) + 1.1)))) + (0.45 * FdLibm.Sin(((5D * ToNum(f_4184)) + 0.3)))))));
}, 1, "", true);
C_4071 = Arr(((V)(50.5)), ((V)((-1.2))));
SCc_4072 = Fn((V _arrowThis4195, int _argc4186, V a_4192, V b_4193, V c_4194, V _a4191, V[] _rest4187) => {
return ((V)((((KF_4062 * ((ToNum(c_4194) - (ToNum(a_4192) * ToNum(GetIdx(C_4071, 0D)))) - (ToNum(b_4193) * ToNum(GetIdx(C_4071, 1D))))) + (ToNum(a_4192) * ToNum(GetIdx(C_4071, 0D)))) + (ToNum(b_4193) * ToNum(GetIdx(C_4071, 1D))))));
}, 3, "", true);
SM_4073 = Fn((V _arrowThis4204, int _argc4196, V x_4202, V z_4203, V _a4200, V _a4201, V[] _rest4197) => {
return Arr(Add(GetIdx(C_4071, 0D), ((V)(((ToNum(x_4202) - ToNum(GetIdx(C_4071, 0D))) * KF_4062)))), Add(GetIdx(C_4071, 1D), ((V)(((ToNum(z_4203) - ToNum(GetIdx(C_4071, 1D))) * KF_4062)))));
}, 2, "", true);
ringXZ_4074 = Fn((V _arrowThis4213, int _argc4205, V rf_4211, V n_4212, V _a4209, V _a4210, V[] _rest4206) => {
return Array_from(NewObj(1).Put("length", n_4212).V, Fn((V _arrowThis4222, int _argc4214, V __4220, V k_4221, V _a4218, V _a4219, V[] _rest4215) => {
double f_4223 = 0;
f_4223 = ((ToNum(k_4221) / ToNum(n_4212)) * TAU_9);
return Arr(Add(GetIdx(C_4071, 0D), ((V)((ToNum(Call(rf_4211, V.Undef, ((V)(f_4223)))) * FdLibm.Sin(f_4223))))), Add(GetIdx(C_4071, 1D), ((V)((ToNum(Call(rf_4211, V.Undef, ((V)(f_4223)))) * FdLibm.Cos(f_4223))))));
return default;
}, 2, "", true));
}, 2, "", true);
clip_4075 = Fn((V _arrowThis4234, int _argc4224, V Q_4230, V a_4231, V b_4232, V c_4233, V[] _rest4225) => {
V o_4235 = default;
o_4235 = Arr();
{
double i_4236 = 0;
i_4236 = 0D;
while (true) {
if (!(Lt(((V)(i_4236)), Get(Q_4230, "length")))) break;
V p_4238 = default;
V q_4239 = default;
double s1_4240 = 0;
double s2_4241 = 0;
p_4238 = GetIdx(Q_4230, i_4236);
q_4239 = GetIdx(Q_4230, ((i_4236 + 1D) % ToNum(Get(Q_4230, "length"))));
s1_4240 = (((ToNum(a_4231) * ToNum(GetIdx(p_4238, 0D))) + (ToNum(b_4232) * ToNum(GetIdx(p_4238, 1D)))) - ToNum(c_4233));
s2_4241 = (((ToNum(a_4231) * ToNum(GetIdx(q_4239, 0D))) + (ToNum(b_4232) * ToNum(GetIdx(q_4239, 1D)))) - ToNum(c_4233));
if ((s1_4240 <= 0D)) {
Invoke(o_4235, "push", p_4238);
}
if (((s1_4240 * s2_4241) < 0D)) {
double t_4242 = 0;
t_4242 = (s1_4240 / (s1_4240 - s2_4241));
Invoke(o_4235, "push", Arr(Add(GetIdx(p_4238, 0D), ((V)(((ToNum(GetIdx(q_4239, 0D)) - ToNum(GetIdx(p_4238, 0D))) * t_4242)))), Add(GetIdx(p_4238, 1D), ((V)(((ToNum(GetIdx(q_4239, 1D)) - ToNum(GetIdx(p_4238, 1D))) * t_4242))))));
}
i_4236++;
}
}
return o_4235;
return default;
}, 4, "", true);
bed_4076 = Call(ringXZ_4074, V.Undef, Fn((V _arrowThis4250, int _argc4243, V f_4249, V _a4246, V _a4247, V _a4248, V[] _rest4244) => {
return ((V)((ToNum(Call(NR_4070, V.Undef, f_4249)) - 0.7)));
}, 1, "", true), ((V)(64D)));
fr_4077 = Call(clip_4075, V.Undef, bed_4076, ((V)((-0.08))), ((V)((-1D))), Call(SCc_4072, V.Undef, ((V)((-0.08))), ((V)((-1D))), ((V)((-(3.8 + 4D))))));
shr_4078 = Fn((V _arrowThis4259, int _argc4251, V Q_4257, V k_4258, V _a4255, V _a4256, V[] _rest4252) => {
double cx_4260 = 0;
double cz_4261 = 0;
cx_4260 = (ToNum(Invoke(Q_4257, "reduce", Fn((V _arrowThis4270, int _argc4262, V s_4268, V p_4269, V _a4266, V _a4267, V[] _rest4263) => {
return Add(s_4268, GetIdx(p_4269, 0D));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(Q_4257, "length")));
cz_4261 = (ToNum(Invoke(Q_4257, "reduce", Fn((V _arrowThis4279, int _argc4271, V s_4277, V p_4278, V _a4275, V _a4276, V[] _rest4272) => {
return Add(s_4277, GetIdx(p_4278, 1D));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(Q_4257, "length")));
return Invoke(Q_4257, "map", Fn((V _arrowThis4287, int _argc4280, V p_4286, V _a4283, V _a4284, V _a4285, V[] _rest4281) => {
return Arr(((V)((cx_4260 + ((ToNum(GetIdx(p_4286, 0D)) - cx_4260) * ToNum(k_4258))))), ((V)((cz_4261 + ((ToNum(GetIdx(p_4286, 1D)) - cz_4261) * ToNum(k_4258))))));
}, 1, "", true));
return default;
}, 2, "", true);
PC_4079 = Arr(NewObj(5).Put("n", ((V)("s"))).Put("Q", Call(clip_4075, V.Undef, bed_4076, ((V)(0.08)), ((V)(1D)), Call(SCc_4072, V.Undef, ((V)(0.08)), ((V)(1D)), ((V)((2.6 + 4D)))))).Put("h", ((V)(2.2))).Put("sd", ((V)("#d9542a"))).Put("top", Invoke(S_4058, "rgrad", ((V)("mks")), Arr(Arr(((V)(0D)), ((V)("#ffb894"))), Arr(((V)(0.6)), ((V)("#ff7c4a"))), Arr(((V)(1D)), ((V)("#e65a2c")))))).V, NewObj(8).Put("n", ((V)("a"))).Put("Q", Call(clip_4075, V.Undef, fr_4077, ((V)(1D)), ((V)((-0.3))), Call(SCc_4072, V.Undef, ((V)(1D)), ((V)((-0.3))), ((V)((54.8 - 2.7)))))).Put("h", ((V)(1.7))).Put("sd", ((V)("#5e8e30"))).Put("top", Invoke(S_4058, "rgrad", ((V)("mka")), Arr(Arr(((V)(0D)), ((V)("#f8f4ba"))), Arr(((V)(0.6)), ((V)("#e6e690"))), Arr(((V)(1D)), ((V)("#b4c862")))))).Put("in", ((V)("#eef0b0"))).Put("ik", ((V)(0.55))).Put("io", ((V)(0.8))).V, NewObj(8).Put("n", ((V)("k"))).Put("Q", Call(clip_4075, V.Undef, fr_4077, ((V)((-1D))), ((V)(0.3)), Call(SCc_4072, V.Undef, ((V)((-1D))), ((V)(0.3)), ((V)((-(56.2 - 2.7))))))).Put("h", ((V)(1.4))).Put("sd", ((V)("#2e6a22"))).Put("top", Invoke(S_4058, "rgrad", ((V)("mkk")), Arr(Arr(((V)(0D)), ((V)("#b6ea80"))), Arr(((V)(0.6)), ((V)("#86cc52"))), Arr(((V)(1D)), ((V)("#4f9a2e")))))).Put("in", ((V)("#e2f6c0"))).Put("ik", ((V)(0.5))).Put("io", ((V)(0.85))).V);
GSH_4080 = Invoke(S_4058, "path", NewObj(2).Put("fill", ((V)("#d6ccb7"))).Put("opacity", ((V)(0.75))).V);
GT_4081 = Arr(Invoke(S_4058, "path", NewObj(3).Put("fill", ((V)("#ffffff"))).Put("stroke", ((V)("#cfc5b0"))).Put("stroke-width", ((V)(0.26))).V), Invoke(S_4058, "path", NewObj(3).Put("fill", ((V)("#fbf9f4"))).Put("stroke", ((V)("#cfc5b0"))).Put("stroke-width", ((V)(0.26))).V), Invoke(S_4058, "path", NewObj(3).Put("fill", ((V)("#efeae0"))).Put("stroke", ((V)("#c4b9a2"))).Put("stroke-width", ((V)(0.26))).V));
ses_4082 = Invoke(S_4058, "path", NewObj(3).Put("fill", ((V)("#e6c682"))).Put("stroke", ((V)("#b48a42"))).Put("stroke-width", ((V)(0.24))).V);
top_4083 = Invoke(S_4058, "path", NewObj(1).Put("fill", Invoke(S_4058, "rgrad", ((V)("mkt")), Arr(Arr(((V)(0D)), ((V)("#fdfbf7"))), Arr(((V)(0.6)), ((V)("#f3efe6"))), Arr(((V)(1D)), ((V)("#ddd5c4")))), NewObj(3).Put("cx", ((V)("45%"))).Put("cy", ((V)("40%"))).Put("r", ((V)("65%"))).V)).V);
tgr_4084 = Invoke(S_4058, "path", NewObj(3).Put("fill", ((V)("#ffffff"))).Put("stroke", ((V)("#cfc5b0"))).Put("stroke-width", ((V)(0.26))).V);
tse_4085 = Invoke(S_4058, "path", NewObj(3).Put("fill", ((V)("#e6c682"))).Put("stroke", ((V)("#b48a42"))).Put("stroke-width", ((V)(0.22))).V);
nori_4086 = Invoke(S_4058, "path", NewObj(1).Put("fill", ((V)("#1f3326"))).V);
bedE_4087 = Invoke(S_4058, "path", NewObj(1).Put("fill", ((V)("#f1ece0"))).V);
VG_4088 = Invoke(S_4058, "g");
scl_4089 = Invoke(S_4058, "clip", ((V)("mksc")));
Invoke(PC_4079, "forEach", Fn((V _arrowThis4296, int _argc4288, V p_4294, V i_4295, V _a4292, V _a4293, V[] _rest4289) => {
Set(p_4294, "id", ((V)(JsStrBuf.Begin().S("v").V(i_4295).End())));
Set(p_4294, "sdE", Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", Get(p_4294, "sd")).V, VG_4088));
Set(p_4294, "e", Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", Get(p_4294, "top")).V, VG_4088));
Set(p_4294, "ex", (SEqS(Get(p_4294, "n"), "s") ? Call(Fn((V _arrowThis4303, int _argc4297, V _a4299, V _a4300, V _a4301, V _a4302, V[] _rest4298) => {
V g_4304 = default;
g_4304 = Call(el_14, V.Undef, ((V)("g")), NewObj(1).Put("clip-path", Get(scl_4089, "url")).V, VG_4088);
Call(el_14, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffe6d6"))).Put("stroke-width", ((V)(2.1))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.6))).V, g_4304);
return g_4304;
return default;
}, 0, "", true), V.Undef) : Call(el_14, V.Undef, ((V)("path")), NewObj(2).Put("fill", Get(p_4294, "in")).Put("opacity", Get(p_4294, "io")).V, VG_4088)));
Set(p_4294, "QI", (Truthy(Get(p_4294, "ik")) ? Call(shr_4078, V.Undef, Get(p_4294, "Q"), Get(p_4294, "ik")) : V.Null));
return default;
}, 2, "", true));
LGR_4090 = Array_from(NewObj(1).Put("length", ((V)(9D))).V, Fn((V _arrowThis4313, int _argc4305, V __4311, V i_4312, V _a4309, V _a4310, V[] _rest4306) => {
return Arr(((V)((0.22 + (ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_4312) * 2.7) + 1D))))) * 0.62)))), ((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_4312) * 1.9) + 3D))))) * TAU_9))), ((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_4312) * 3.3) + 2D))))) * System.Math.PI))));
}, 2, "", true));
limb_4091 = Fn((V _arrowThis4327, int _argc4314, V q_4320, V kind_4321, V c_4322, V ax_4323, V[] _rest4315) => {
V S3_4328 = default;
V P2_4329 = default;
V NZ_4330 = default;
double RA_4331 = 0;
JsStrBuf dg_4332 = null;
JsStrBuf ds_4333 = null;
V E_4324 = default;
V R_4325 = default;
V glob_4326 = default;
E_4324 = (_argc4314 > 4 ? _rest4315[0] : V.Undef);
R_4325 = (_argc4314 > 5 ? _rest4315[1] : V.Undef);
glob_4326 = (_argc4314 > 6 ? _rest4315[2] : V.Undef);
if (!(Truthy(Get(q_4320, "dec")))) {
Set(q_4320, "dec", Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, Get(Get(q_4320, "e"), "parentNode"), Get(Get(q_4320, "e"), "nextSibling")));
Set(q_4320, "dG", Call(el_14, V.Undef, ((V)("path")), NewObj(3).Put("fill", ((V)("#ffffff"))).Put("stroke", ((V)("#cfc5b0"))).Put("stroke-width", ((V)(0.24))).V, Get(q_4320, "dec")));
Set(q_4320, "dS", Call(el_14, V.Undef, ((V)("path")), NewObj(3).Put("fill", ((V)("#e6c682"))).Put("stroke", ((V)("#b48a42"))).Put("stroke-width", ((V)(0.22))).V, Get(q_4320, "dec")));
}
S3_4328 = Fn((V _arrowThis4342, int _argc4334, V th_4340, V f_4341, V _a4338, V _a4339, V[] _rest4335) => {
return Arr(((V)((FdLibm.Sin(ToNum(th_4340)) * FdLibm.Sin(ToNum(f_4341))))), ((V)((-FdLibm.Cos(ToNum(th_4340))))), ((V)((FdLibm.Sin(ToNum(th_4340)) * FdLibm.Cos(ToNum(f_4341))))));
}, 2, "", true);
P2_4329 = Fn((V _arrowThis4350, int _argc4343, V s_4349, V _a4346, V _a4347, V _a4348, V[] _rest4344) => {
return Call(glob_4326, V.Undef, Add(Add(Add(GetIdx(c_4322, 0D), ((V)((ToNum(GetIdx(s_4349, 0D)) * ToNum(GetIdx(GetIdx(ax_4323, 0D), 0D)))))), ((V)((ToNum(GetIdx(s_4349, 1D)) * ToNum(GetIdx(GetIdx(ax_4323, 1D), 0D)))))), ((V)((ToNum(GetIdx(s_4349, 2D)) * ToNum(GetIdx(GetIdx(ax_4323, 2D), 0D)))))), Add(Add(Add(GetIdx(c_4322, 1D), ((V)((ToNum(GetIdx(s_4349, 0D)) * ToNum(GetIdx(GetIdx(ax_4323, 0D), 1D)))))), ((V)((ToNum(GetIdx(s_4349, 1D)) * ToNum(GetIdx(GetIdx(ax_4323, 1D), 1D)))))), ((V)((ToNum(GetIdx(s_4349, 2D)) * ToNum(GetIdx(GetIdx(ax_4323, 2D), 1D)))))));
}, 1, "", true);
NZ_4330 = Fn((V _arrowThis4358, int _argc4351, V s_4357, V _a4354, V _a4355, V _a4356, V[] _rest4352) => {
double n0_4359 = 0;
double n1_4360 = 0;
double n2_4361 = 0;
n0_4359 = 0D;
n1_4360 = 0D;
n2_4361 = 0D;
{
double i_4362 = 0;
i_4362 = 0D;
while (true) {
if (!((i_4362 < 3D))) break;
double k_4364 = 0;
k_4364 = (ToNum(GetIdx(s_4357, i_4362)) / ToNum(GetIdx(R_4325, i_4362)));
n0_4359 = (n0_4359 + (k_4364 * ToNum(GetIdx(GetIdx(E_4324, i_4362), 0D))));
n1_4360 = (n1_4360 + (k_4364 * ToNum(GetIdx(GetIdx(E_4324, i_4362), 1D))));
n2_4361 = (n2_4361 + (k_4364 * ToNum(GetIdx(GetIdx(E_4324, i_4362), 2D))));
i_4362++;
}
}
return ((V)((n2_4361 / ToNum((((V)(Hypot(n0_4359, n1_4360, n2_4361))) is var _t4365 && Truthy(_t4365) ? _t4365 : ((V)(1D)))))));
return default;
}, 1, "", true);
RA_4331 = (ToNum(Add(Add(GetIdx(R_4325, 0D), GetIdx(R_4325, 1D)), GetIdx(R_4325, 2D))) / 3D);
dg_4332 = new JsStrBuf("");
ds_4333 = new JsStrBuf("");
Invoke(LGR_4090, "forEach", Fn((V _arrowThis4380, int _argc4366, V _a4368, V i_4372, V _a4370, V _a4371, V[] _rest4367) => {
double T_4381 = 0;
V s_4382 = default;
V e1_4383 = default;
V e2_4384 = default;
V sz_4385 = default;
V Q_4386 = default;
V th_4375 = default;
V f_4377 = default;
V o_4379 = default;
{ V _t4373 = ListOf(_a4368);
{ V _t4374 = GetIdx(_t4373, 0D);
th_4375 = _t4374; }
{ V _t4376 = GetIdx(_t4373, 1D);
f_4377 = _t4376; }
{ V _t4378 = GetIdx(_t4373, 2D);
o_4379 = _t4378; }
}
T_4381 = (ToNum(th_4375) * System.Math.PI);
s_4382 = Call(S3_4328, V.Undef, ((V)(T_4381)), f_4377);
if (LtN(Call(NZ_4330, V.Undef, s_4382), 0.15)) {
return default;
}
e1_4383 = Arr(((V)(FdLibm.Cos(ToNum(f_4377)))), ((V)(0D)), ((V)((-FdLibm.Sin(ToNum(f_4377))))));
e2_4384 = Arr(((V)((FdLibm.Cos(T_4381) * FdLibm.Sin(ToNum(f_4377))))), ((V)(FdLibm.Sin(T_4381))), ((V)((FdLibm.Cos(T_4381) * FdLibm.Cos(ToNum(f_4377))))));
sz_4385 = (SEqN(i_4372, 4D) ? Arr(((V)(1.1)), ((V)(0.55))) : Arr(((V)(1.5)), ((V)(0.72))));
Q_4386 = Arr();
{
double k_4387 = 0;
k_4387 = 0D;
while (true) {
if (!((k_4387 < 8D))) break;
double t_4389 = 0;
double a_4390 = 0;
double b_4391 = 0;
double ca_4392 = 0;
double sa_4393 = 0;
t_4389 = ((k_4387 / 8D) * TAU_9);
a_4390 = ((ToNum(GetIdx(sz_4385, 0D)) / RA_4331) * FdLibm.Cos(t_4389));
b_4391 = ((ToNum(GetIdx(sz_4385, 1D)) / RA_4331) * FdLibm.Sin(t_4389));
ca_4392 = FdLibm.Cos(ToNum(o_4379));
sa_4393 = FdLibm.Sin(ToNum(o_4379));
Invoke(Q_4386, "push", Call(P2_4329, V.Undef, Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis4401, int _argc4394, V j_4400, V _a4397, V _a4398, V _a4399, V[] _rest4395) => {
return ((V)((((ToNum(GetK(s_4382, j_4400)) * 1.04) + (((ToNum(GetK(e1_4383, j_4400)) * ca_4392) + (ToNum(GetK(e2_4384, j_4400)) * sa_4393)) * a_4390)) + ((((-ToNum(GetK(e1_4383, j_4400))) * sa_4393) + (ToNum(GetK(e2_4384, j_4400)) * ca_4392)) * b_4391))));
}, 1, "", true))));
k_4387++;
}
}
if (SEqN(i_4372, 4D)) {
ds_4333.V(Call(polyW_18, V.Undef, Q_4386));
} else {
dg_4332.V(Call(polyW_18, V.Undef, Q_4386));
}
return default;
}, 2, "", true));
Call(SA_31, V.Undef, Get(q_4320, "dG"), ((V)("d")), (((V)(dg_4332.Str)) is var _t4402 && Truthy(_t4402) ? _t4402 : ((V)("M0 0"))));
Call(SA_31, V.Undef, Get(q_4320, "dS"), ((V)("d")), (((V)(ds_4333.Str)) is var _t4403 && Truthy(_t4403) ? _t4403 : ((V)("M0 0"))));
return default;
}, 7, "", true);
return NewObj(27).Put("R0", ((V)(R0_4059))).Put("YT", ((V)(YT_4060))).Put("AL", ((V)(AL_4061))).Put("rT", rT_4063).Put("SM", SM_4073).Put("SG", SG_4066).Put("TG", TG_4067).Put("SS", SS_4068).Put("TS", TS_4069).Put("GT", GT_4081).Put("GSH", GSH_4080).Put("ses", ses_4082).Put("top", top_4083).Put("tgr", tgr_4084).Put("tse", tse_4085).Put("nori", nori_4086).Put("bedE", bedE_4087).Put("VG", VG_4088).Put("PC", PC_4079).Put("scl", scl_4089).Put("NO", Call(ringXZ_4074, V.Undef, Fn((V _arrowThis4411, int _argc4404, V f_4410, V _a4407, V _a4408, V _a4409, V[] _rest4405) => {
return Add(Call(NR_4070, V.Undef, f_4410), ((V)(0.85)));
}, 1, "", true), ((V)(64D)))).Put("BD", Call(ringXZ_4074, V.Undef, NR_4070, ((V)(64D)))).Put("limb", limb_4091).Put("rx", ((V)(29D))).Put("ya", ((V)(36D))).Put("yb", ((V)(86D))).Put("zE", Fn((V _arrowThis4420, int _argc4412, V dx_4418, V dy_4419, V _a4416, V _a4417, V[] _rest4413) => {
V r_4421 = default;
r_4421 = Call(rT_4063, V.Undef, Add(Get(S_4058, "HY"), dy_4419));
return ((V)((System.Math.Sqrt(Max(0D, ((ToNum(r_4421) * ToNum(r_4421)) - (ToNum(dx_4418) * ToNum(dx_4418))))) + 0.3)));
return default;
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self4422, int _argc4423, V B_4429, V D_4430, V _a4427, V _a4428, V[] _rest4424) => {
V set_4431 = default;
V W_4432 = default;
V P_4433 = default;
V rT_4434 = default;
V veg_4435 = default;
V YT_4436 = default;
V hp_4437 = default;
V ovalQ_4438 = default;
V oval_4439 = default;
V g3_4440 = default;
JsStrBuf gs_4441 = null;
double dx_4442 = 0;
double dy_4443 = 0;
JsStrBuf sd_4444 = null;
V ring_4445 = default;
V TP_4446 = default;
JsStrBuf tg_4447 = null;
JsStrBuf ts_4448 = null;
V L_4449 = default;
V ord_4450 = default;
if (_self4422.IsNullish) _self4422 = GlobalV;
{ V _t4451 = D_4430;
if (_t4451.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t4451));
{ V _t4452 = Get(_t4451, "set");
set_4431 = _t4452; } }
W_4432 = Call(tiltW_49, V.Undef, D_4430, Get(B_4429, "AL"), ((V)(60D)), Get(B_4429, "R0"));
P_4433 = Get(W_4432, "P");
rT_4434 = Get(B_4429, "rT");
veg_4435 = Call(clamp_12, V.Undef, Invoke(D_4430, "bv", ((V)("veg"))), ((V)(0D)), ((V)(1.3)));
YT_4436 = Get(B_4429, "YT");
hp_4437 = Arr();
{
double i_4453 = 0;
i_4453 = 0D;
while (true) {
if (!((i_4453 <= 14D))) break;
V y_4455 = default;
V r_4456 = default;
y_4455 = Add(YT_4436, ((V)((((88D - ToNum(YT_4436)) * i_4453) / 14D))));
r_4456 = Call(rT_4434, V.Undef, y_4455);
{
double k_4457 = 0;
k_4457 = 0D;
while (true) {
if (!((k_4457 < 24D))) break;
double f_4459 = 0;
f_4459 = ((k_4457 / 24D) * TAU_9);
Invoke(hp_4437, "push", Call(P_4433, V.Undef, ((V)((50D + (ToNum(r_4456) * FdLibm.Sin(f_4459))))), y_4455, ((V)((ToNum(r_4456) * FdLibm.Cos(f_4459))))));
k_4457++;
}
}
i_4453++;
}
}
Set(B_4429, "d", Invoke(D_4430, "hull", hp_4437));
ovalQ_4438 = Fn((V _arrowThis4472, int _argc4460, V c_4466, V u_4467, V v_4468, V a_4469, V[] _rest4461) => {
double ca_4473 = 0;
double sa_4474 = 0;
V Q_4475 = default;
V b_4470 = default;
V o_4471 = default;
b_4470 = (_argc4460 > 4 ? _rest4461[0] : V.Undef);
o_4471 = (_argc4460 > 5 ? _rest4461[1] : V.Undef);
ca_4473 = FdLibm.Cos(ToNum(o_4471));
sa_4474 = FdLibm.Sin(ToNum(o_4471));
Q_4475 = Arr();
{
double k_4476 = 0;
k_4476 = 0D;
while (true) {
if (!((k_4476 < 8D))) break;
double t_4478 = 0;
double A_4479 = 0;
double Bb_4480 = 0;
t_4478 = ((k_4476 / 8D) * TAU_9);
A_4479 = (ToNum(a_4469) * FdLibm.Cos(t_4478));
Bb_4480 = (ToNum(b_4470) * FdLibm.Sin(t_4478));
Invoke(Q_4475, "push", Call(P_4433, V.Undef, Add(Add(GetIdx(c_4466, 0D), ((V)((((ToNum(GetIdx(u_4467, 0D)) * ca_4473) + (ToNum(GetIdx(v_4468, 0D)) * sa_4474)) * A_4479)))), ((V)(((((-ToNum(GetIdx(u_4467, 0D))) * sa_4474) + (ToNum(GetIdx(v_4468, 0D)) * ca_4473)) * Bb_4480)))), Add(Add(GetIdx(c_4466, 1D), ((V)((((ToNum(GetIdx(u_4467, 1D)) * ca_4473) + (ToNum(GetIdx(v_4468, 1D)) * sa_4474)) * A_4479)))), ((V)(((((-ToNum(GetIdx(u_4467, 1D))) * sa_4474) + (ToNum(GetIdx(v_4468, 1D)) * ca_4473)) * Bb_4480)))), Add(Add(GetIdx(c_4466, 2D), ((V)((((ToNum(GetIdx(u_4467, 2D)) * ca_4473) + (ToNum(GetIdx(v_4468, 2D)) * sa_4474)) * A_4479)))), ((V)(((((-ToNum(GetIdx(u_4467, 2D))) * sa_4474) + (ToNum(GetIdx(v_4468, 2D)) * ca_4473)) * Bb_4480))))));
k_4476++;
}
}
return Q_4475;
return default;
}, 6, "", true);
oval_4439 = Fn((V _arrowThis4493, int _argc4481, V c_4487, V u_4488, V v_4489, V a_4490, V[] _rest4482) => {
V b_4491 = default;
V o_4492 = default;
b_4491 = (_argc4481 > 4 ? _rest4482[0] : V.Undef);
o_4492 = (_argc4481 > 5 ? _rest4482[1] : V.Undef);
return Call(polyW_18, V.Undef, Call(ovalQ_4438, V.Undef, c_4487, u_4488, v_4489, a_4490, b_4491, o_4492));
}, 6, "", true);
g3_4440 = Arr(((V)("")), ((V)("")), ((V)("")));
gs_4441 = new JsStrBuf("");
dx_4442 = (0.32 * ToNum(Get(D_4430, "kS")));
dy_4443 = (0.42 * ToNum(Get(D_4430, "kS")));
Invoke(Get(B_4429, "SG"), "forEach", Fn((V _arrowThis4507, int _argc4494, V _a4496, V _a4497, V _a4498, V _a4499, V[] _rest4495) => {
double sf_4508 = 0;
double cf_4509 = 0;
V r_4510 = default;
V c_4511 = default;
V fz_4512 = default;
V p0_4513 = default;
V p1_4514 = default;
double b_4515 = 0;
V Q_4516 = default;
V f_4502 = default;
V y_4504 = default;
V o_4506 = default;
{ V _t4500 = ListOf(_a4496);
{ V _t4501 = GetIdx(_t4500, 0D);
f_4502 = _t4501; }
{ V _t4503 = GetIdx(_t4500, 1D);
y_4504 = _t4503; }
{ V _t4505 = GetIdx(_t4500, 2D);
o_4506 = _t4505; }
}
sf_4508 = FdLibm.Sin(ToNum(f_4502));
cf_4509 = FdLibm.Cos(ToNum(f_4502));
r_4510 = Add(Call(rT_4434, V.Undef, y_4504), ((V)(0.55)));
c_4511 = Arr(((V)((50D + (ToNum(r_4510) * sf_4508)))), y_4504, ((V)((ToNum(r_4510) * cf_4509))));
fz_4512 = Invoke(W_4432, "F", GetIdx(c_4511, 0D), GetIdx(c_4511, 1D), GetIdx(c_4511, 2D), ((V)(sf_4508)), ((V)(0D)), ((V)(cf_4509)));
if (LtN(fz_4512, 0.02)) {
return default;
}
p0_4513 = Call(P_4433, V.Undef, GetIdx(c_4511, 0D), GetIdx(c_4511, 1D), GetIdx(c_4511, 2D));
p1_4514 = Call(P_4433, V.Undef, Add(GetIdx(c_4511, 0D), ((V)(sf_4508))), GetIdx(c_4511, 1D), Add(GetIdx(c_4511, 2D), ((V)(cf_4509))));
b_4515 = (((((ToNum(GetIdx(p1_4514, 0D)) - ToNum(GetIdx(p0_4513, 0D))) / ToNum(Get(D_4430, "kS"))) * ToNum(GetIdx(LV_27, 0D))) + (((ToNum(GetIdx(p1_4514, 1D)) - ToNum(GetIdx(p0_4513, 1D))) / ToNum(Get(D_4430, "kS"))) * ToNum(GetIdx(LV_27, 1D)))) + (ToNum(fz_4512) * ToNum(GetIdx(LV_27, 2D))));
Q_4516 = Call(ovalQ_4438, V.Undef, c_4511, Arr(((V)(cf_4509)), ((V)(0D)), ((V)((-sf_4508)))), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))), ((V)(1.85)), ((V)(0.88)), o_4506);
OpSetK(g3_4440, ((V)(((b_4515 > 0.45) ? 0D : ((b_4515 > 0.12) ? 1D : 2D)))), 0, Call(polyW_18, V.Undef, Q_4516));
gs_4441.V(Call(polyW_18, V.Undef, Invoke(Q_4516, "map", Fn((V _arrowThis4524, int _argc4517, V q_4523, V _a4520, V _a4521, V _a4522, V[] _rest4518) => {
return Arr(Add(GetIdx(q_4523, 0D), ((V)(dx_4442))), Add(GetIdx(q_4523, 1D), ((V)(dy_4443))));
}, 1, "", true))));
return default;
}, 1, "", true));
Invoke(Get(B_4429, "GT"), "forEach", Fn((V _arrowThis4533, int _argc4525, V e_4531, V i_4532, V _a4529, V _a4530, V[] _rest4526) => {
return Call(set_4431, V.Undef, e_4531, ((V)("d")), (GetK(g3_4440, i_4532) is var _t4534 && Truthy(_t4534) ? _t4534 : ((V)("M0 0"))));
}, 2, "", true));
Call(set_4431, V.Undef, Get(B_4429, "GSH"), ((V)("d")), (((V)(gs_4441.Str)) is var _t4535 && Truthy(_t4535) ? _t4535 : ((V)("M0 0"))));
sd_4444 = new JsStrBuf("");
Invoke(Get(B_4429, "SS"), "forEach", Fn((V _arrowThis4549, int _argc4536, V _a4538, V _a4539, V _a4540, V _a4541, V[] _rest4537) => {
double sf_4550 = 0;
double cf_4551 = 0;
V r_4552 = default;
V c_4553 = default;
V f_4544 = default;
V y_4546 = default;
V o_4548 = default;
{ V _t4542 = ListOf(_a4538);
{ V _t4543 = GetIdx(_t4542, 0D);
f_4544 = _t4543; }
{ V _t4545 = GetIdx(_t4542, 1D);
y_4546 = _t4545; }
{ V _t4547 = GetIdx(_t4542, 2D);
o_4548 = _t4547; }
}
sf_4550 = FdLibm.Sin(ToNum(f_4544));
cf_4551 = FdLibm.Cos(ToNum(f_4544));
r_4552 = Add(Call(rT_4434, V.Undef, y_4546), ((V)(0.5)));
c_4553 = Arr(((V)((50D + (ToNum(r_4552) * sf_4550)))), y_4546, ((V)((ToNum(r_4552) * cf_4551))));
if (LtN(Invoke(W_4432, "F", GetIdx(c_4553, 0D), GetIdx(c_4553, 1D), GetIdx(c_4553, 2D), ((V)(sf_4550)), ((V)(0D)), ((V)(cf_4551))), 0.06)) {
return default;
}
sd_4444.V(Call(oval_4439, V.Undef, c_4553, Arr(((V)(cf_4551)), ((V)(0D)), ((V)((-sf_4550)))), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))), ((V)(1.15)), ((V)(0.55)), o_4548));
return default;
}, 1, "", true));
Call(set_4431, V.Undef, Get(B_4429, "ses"), ((V)("d")), (((V)(sd_4444.Str)) is var _t4554 && Truthy(_t4554) ? _t4554 : ((V)("M0 0"))));
ring_4445 = Fn((V _arrowThis4564, int _argc4555, V r_4561, V y_4562, V n_4563, V _a4560, V[] _rest4556) => {
return Array_from(NewObj(1).Put("length", n_4563).V, Fn((V _arrowThis4573, int _argc4565, V __4571, V k_4572, V _a4569, V _a4570, V[] _rest4566) => {
double f_4574 = 0;
f_4574 = ((ToNum(k_4572) / ToNum(n_4563)) * TAU_9);
return Call(P_4433, V.Undef, ((V)((50D + (ToNum(r_4561) * FdLibm.Sin(f_4574))))), y_4562, ((V)((ToNum(r_4561) * FdLibm.Cos(f_4574)))));
return default;
}, 2, "", true));
}, 3, "", true);
Call(set_4431, V.Undef, Get(B_4429, "top"), ((V)("d")), Call(polyW_18, V.Undef, Call(ring_4445, V.Undef, Get(B_4429, "R0"), YT_4436, ((V)(48D)))));
TP_4446 = Fn((V _arrowThis4584, int _argc4575, V x_4581, V z_4582, V h_4583, V _a4580, V[] _rest4576) => {
return Call(P_4433, V.Undef, x_4581, ((V)((ToNum(YT_4436) - ToNum((h_4583 is var _t4585 && Truthy(_t4585) ? _t4585 : ((V)(0D))))))), z_4582);
}, 3, "", true);
tg_4447 = new JsStrBuf("");
ts_4448 = new JsStrBuf("");
Invoke(Get(B_4429, "TG"), "forEach", Fn((V _arrowThis4599, int _argc4586, V _a4588, V _a4589, V _a4590, V _a4591, V[] _rest4587) => {
V r_4594 = default;
V f_4596 = default;
V o_4598 = default;
{ V _t4592 = ListOf(_a4588);
{ V _t4593 = GetIdx(_t4592, 0D);
r_4594 = _t4593; }
{ V _t4595 = GetIdx(_t4592, 1D);
f_4596 = _t4595; }
{ V _t4597 = GetIdx(_t4592, 2D);
o_4598 = _t4597; }
}
tg_4447.V(Call(oval_4439, V.Undef, Arr(((V)((50D + (ToNum(r_4594) * FdLibm.Sin(ToNum(f_4596)))))), ((V)((ToNum(YT_4436) - 0.12))), ((V)((ToNum(r_4594) * FdLibm.Cos(ToNum(f_4596)))))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), ((V)(1.65)), ((V)(0.8)), o_4598));
return default;
}, 1, "", true));
Invoke(Get(B_4429, "TS"), "forEach", Fn((V _arrowThis4613, int _argc4600, V _a4602, V _a4603, V _a4604, V _a4605, V[] _rest4601) => {
V r_4608 = default;
V f_4610 = default;
V o_4612 = default;
{ V _t4606 = ListOf(_a4602);
{ V _t4607 = GetIdx(_t4606, 0D);
r_4608 = _t4607; }
{ V _t4609 = GetIdx(_t4606, 1D);
f_4610 = _t4609; }
{ V _t4611 = GetIdx(_t4606, 2D);
o_4612 = _t4611; }
}
ts_4448.V(Call(oval_4439, V.Undef, Arr(((V)((50D + (ToNum(r_4608) * FdLibm.Sin(ToNum(f_4610)))))), ((V)((ToNum(YT_4436) - 0.14))), ((V)((ToNum(r_4608) * FdLibm.Cos(ToNum(f_4610)))))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), ((V)(1.15)), ((V)(0.55)), o_4612));
return default;
}, 1, "", true));
Call(set_4431, V.Undef, Get(B_4429, "tgr"), ((V)("d")), ((V)(tg_4447.Str)));
Call(set_4431, V.Undef, Get(B_4429, "tse"), ((V)("d")), ((V)(ts_4448.Str)));
Call(set_4431, V.Undef, Get(B_4429, "nori"), ((V)("d")), Call(polyW_18, V.Undef, Invoke(Get(B_4429, "NO"), "map", Fn((V _arrowThis4625, int _argc4614, V _a4616, V _a4617, V _a4618, V _a4619, V[] _rest4615) => {
V x_4622 = default;
V z_4624 = default;
{ V _t4620 = ListOf(_a4616);
{ V _t4621 = GetIdx(_t4620, 0D);
x_4622 = _t4621; }
{ V _t4623 = GetIdx(_t4620, 1D);
z_4624 = _t4623; }
}
return Call(TP_4446, V.Undef, x_4622, z_4624, ((V)(0.05)));
}, 1, "", true))));
Call(set_4431, V.Undef, Get(B_4429, "bedE"), ((V)("d")), Call(polyW_18, V.Undef, Invoke(Get(B_4429, "BD"), "map", Fn((V _arrowThis4637, int _argc4626, V _a4628, V _a4629, V _a4630, V _a4631, V[] _rest4627) => {
V x_4634 = default;
V z_4636 = default;
{ V _t4632 = ListOf(_a4628);
{ V _t4633 = GetIdx(_t4632, 0D);
x_4634 = _t4633; }
{ V _t4635 = GetIdx(_t4632, 1D);
z_4636 = _t4635; }
}
return Call(TP_4446, V.Undef, x_4634, z_4636, ((V)(0.08)));
}, 1, "", true))));
L_4449 = Invoke(Invoke(Get(B_4429, "PC"), "map", Fn((V _arrowThis4655, int _argc4647, V p_4653, V i_4654, V _a4651, V _a4652, V[] _rest4648) => {
double h_4656 = 0;
double sw_4657 = 0;
V bot_4658 = default;
V tp_4659 = default;
V td_4660 = default;
double cx_4661 = 0;
double cz_4662 = 0;
h_4656 = ((ToNum(Get(p_4653, "h")) * (1D + (ToNum(veg_4435) * 0.6))) + ((ToNum(veg_4435) * 1.2) * Max(0D, FdLibm.Sin(((ToNum(Get(D_4430, "ts")) * 9D) + (ToNum(i_4654) * 1.7))))));
sw_4657 = ((ToNum(Get(D_4430, "ox")) * 0.06) + ((ToNum(veg_4435) * FdLibm.Sin(ToNum(Add(((V)((ToNum(Get(D_4430, "ts")) * 11D))), i_4654)))) * 0.5));
bot_4658 = Invoke(Get(p_4653, "Q"), "map", Fn((V _arrowThis4674, int _argc4663, V _a4665, V _a4666, V _a4667, V _a4668, V[] _rest4664) => {
V x_4671 = default;
V z_4673 = default;
{ V _t4669 = ListOf(_a4665);
{ V _t4670 = GetIdx(_t4669, 0D);
x_4671 = _t4670; }
{ V _t4672 = GetIdx(_t4669, 1D);
z_4673 = _t4672; }
}
return Call(TP_4446, V.Undef, x_4671, z_4673, ((V)(0.1)));
}, 1, "", true));
tp_4659 = Invoke(Get(p_4653, "Q"), "map", Fn((V _arrowThis4686, int _argc4675, V _a4677, V _a4678, V _a4679, V _a4680, V[] _rest4676) => {
V x_4683 = default;
V z_4685 = default;
{ V _t4681 = ListOf(_a4677);
{ V _t4682 = GetIdx(_t4681, 0D);
x_4683 = _t4682; }
{ V _t4684 = GetIdx(_t4681, 1D);
z_4685 = _t4684; }
}
return Call(TP_4446, V.Undef, Add(x_4683, ((V)(sw_4657))), z_4685, ((V)(h_4656)));
}, 1, "", true));
Call(set_4431, V.Undef, Get(p_4653, "sdE"), ((V)("d")), Invoke(D_4430, "hull", Invoke(bot_4658, "concat", tp_4659)));
td_4660 = Call(polyW_18, V.Undef, tp_4659);
Call(set_4431, V.Undef, Get(p_4653, "e"), ((V)("d")), td_4660);
if (SEqS(Get(p_4653, "n"), "s")) {
Call(set_4431, V.Undef, Get(Get(B_4429, "scl"), "p"), ((V)("d")), td_4660);
Call(set_4431, V.Undef, Get(Get(p_4653, "ex"), "firstChild"), ((V)("d")), Invoke(Invoke(Arr(((V)(37.5)), ((V)(46.5))), "map", Fn((V _arrowThis4694, int _argc4687, V x0_4693, V _a4690, V _a4691, V _a4692, V[] _rest4688) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Array_from(NewObj(1).Put("length", ((V)(12D))).V, Fn((V _arrowThis4703, int _argc4695, V __4701, V k_4702, V _a4699, V _a4700, V[] _rest4696) => {
V q_4704 = default;
q_4704 = Invoke(B_4429, "SM", Add(x0_4693, ((V)((ToNum(k_4702) * 1.05)))), ((V)(((-14.5) + (ToNum(k_4702) * 1.45)))));
return Call(pt_15, V.Undef, Call(TP_4446, V.Undef, Add(GetIdx(q_4704, 0D), ((V)(sw_4657))), GetIdx(q_4704, 1D), ((V)((h_4656 + 0.02)))));
return default;
}, 2, "", true)), "join", ((V)("L")))).End()));
}, 1, "", true)), "join", ((V)(""))));
} else {
Call(set_4431, V.Undef, Get(p_4653, "ex"), ((V)("d")), Call(polyW_18, V.Undef, Invoke(Get(p_4653, "QI"), "map", Fn((V _arrowThis4716, int _argc4705, V _a4707, V _a4708, V _a4709, V _a4710, V[] _rest4706) => {
V x_4713 = default;
V z_4715 = default;
{ V _t4711 = ListOf(_a4707);
{ V _t4712 = GetIdx(_t4711, 0D);
x_4713 = _t4712; }
{ V _t4714 = GetIdx(_t4711, 1D);
z_4715 = _t4714; }
}
return Call(TP_4446, V.Undef, Add(x_4713, ((V)(sw_4657))), z_4715, ((V)((h_4656 + 0.02))));
}, 1, "", true))));
}
cx_4661 = (ToNum(Invoke(Get(p_4653, "Q"), "reduce", Fn((V _arrowThis4725, int _argc4717, V s_4723, V q_4724, V _a4721, V _a4722, V[] _rest4718) => {
return Add(s_4723, GetIdx(q_4724, 0D));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(Get(p_4653, "Q"), "length")));
cz_4662 = (ToNum(Invoke(Get(p_4653, "Q"), "reduce", Fn((V _arrowThis4734, int _argc4726, V s_4732, V q_4733, V _a4730, V _a4731, V[] _rest4727) => {
return Add(s_4732, GetIdx(q_4733, 1D));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(Get(p_4653, "Q"), "length")));
return NewObj(4).Put("id", Get(p_4653, "id")).Put("e", Get(p_4653, "sdE")).Put("ex", Arr(Get(p_4653, "e"), Get(p_4653, "ex"))).Put("z", Invoke(W_4432, "Z", ((V)(cx_4661)), ((V)((ToNum(YT_4436) - (h_4656 / 2D)))), ((V)(cz_4662)))).V;
return default;
}, 2, "", true)), "sort", Fn((V _arrowThis4646, int _argc4638, V a_4644, V b_4645, V _a4642, V _a4643, V[] _rest4639) => {
return ((V)((ToNum(Get(a_4644, "z")) - ToNum(Get(b_4645, "z")))));
}, 2, "", true));
ord_4450 = Arr();
Invoke(L_4449, "forEach", Fn((V _arrowThis4742, int _argc4735, V l_4741, V _a4738, V _a4739, V _a4740, V[] _rest4736) => {
Invoke(ord_4450, "push", l_4741);
Invoke(Get(l_4741, "ex"), "forEach", Fn((V _arrowThis4751, int _argc4743, V e_4749, V j_4750, V _a4747, V _a4748, V[] _rest4744) => {
return Invoke(ord_4450, "push", NewObj(2).Put("id", ((V)(JsStrBuf.Begin().V(Get(l_4741, "id")).S("x").V(j_4750).End()))).Put("e", e_4749).V);
}, 2, "", true));
return default;
}, 1, "", true));
Invoke(SN_43, "order", Get(B_4429, "VG"), ord_4450);
return default;
}, 2, "draw", false)).V);
Set(MODELS_42, "noodle", NewObj(2).Put("setup", Fn((V _self4752, int _argc4753, V S_4759, V _a4756, V _a4757, V _a4758, V[] _rest4754) => {
double EL_4760 = 0;
V O_4761 = default;
V sid_4762 = default;
V PR_4763 = default;
V Y0_4764 = default;
V Y1_4765 = default;
V rT_4766 = default;
V hid_4767 = default;
V bro_4768 = default;
V BF_4769 = default;
V sk0_4770 = default;
V CK_4771 = default;
V sh_4772 = default;
V bd_4773 = default;
V rm_4774 = default;
V rimB_4775 = default;
V rimI_4776 = default;
V broth_4777 = default;
V FG_4778 = default;
V TG_4779 = default;
V rimF_4780 = default;
V rimL_4781 = default;
V FL_4782 = default;
V box_4783 = default;
V SP_4784 = default;
V hp_4785 = default;
V NS_4786 = default;
V SG_4787 = default;
V hang_4788 = default;
V hang2_4789 = default;
V ck_4790 = default;
V sticks_4791 = default;
if (_self4752.IsNullish) _self4752 = GlobalV;
EL_4760 = 0.178;
O_4761 = Invoke(S_4759, "outline", Get(S_4759, "sk"), ((V)(96D)));
sid_4762 = Fn((V _arrowThis4799, int _argc4792, V q_4798, V _a4795, V _a4796, V _a4797, V[] _rest4793) => {
V g_4800 = default;
g_4800 = (Get(Get(q_4798, "e"), "closest") is var _t4801 && !Truthy(_t4801) ? _t4801 : Invoke(Get(q_4798, "e"), "closest", ((V)("[data-s]"))));
return (Truthy(g_4800) ? Invoke(g_4800, "getAttribute", ((V)("data-s"))) : ((V)("")));
return default;
}, 1, "", true);
PR_4763 = Arr();
{
double ys_4802 = 0;
ys_4802 = 46D;
while (true) {
if (!((ys_4802 <= 86.6))) break;
V r_4804 = default;
r_4804 = Call(halfW_38, V.Undef, O_4761, ((V)(ys_4802)));
if (GtN(r_4804, 0.5)) {
Invoke(PR_4763, "push", Arr(((V)((ys_4802 + (EL_4760 * ToNum(r_4804))))), r_4804));
}
ys_4802 = (ys_4802 + 0.4);
}
}
Invoke(PR_4763, "sort", Fn((V _arrowThis4813, int _argc4805, V p_4811, V q_4812, V _a4809, V _a4810, V[] _rest4806) => {
return ((V)((ToNum(GetIdx(p_4811, 0D)) - ToNum(GetIdx(q_4812, 0D)))));
}, 2, "", true));
Y0_4764 = GetIdx(GetIdx(PR_4763, 0D), 0D);
Y1_4765 = GetIdx(GetIdx(PR_4763, (ToNum(Get(PR_4763, "length")) - 1D)), 0D);
rT_4766 = Fn((V _arrowThis4821, int _argc4814, V y_4820, V _a4817, V _a4818, V _a4819, V[] _rest4815) => {
double i_4822 = 0;
V p_4823 = default;
V q_4824 = default;
double t_4825 = 0;
y_4820 = Call(clamp_12, V.Undef, y_4820, Y0_4764, Y1_4765);
i_4822 = 1D;
while (((i_4822 < (ToNum(Get(PR_4763, "length")) - 1D)) && Lt(GetIdx(GetIdx(PR_4763, i_4822), 0D), y_4820))) {
i_4822++;
}
p_4823 = GetIdx(PR_4763, (i_4822 - 1D));
q_4824 = GetIdx(PR_4763, i_4822);
t_4825 = (Gt(GetIdx(q_4824, 0D), GetIdx(p_4823, 0D)) ? ((ToNum(y_4820) - ToNum(GetIdx(p_4823, 0D))) / (ToNum(GetIdx(q_4824, 0D)) - ToNum(GetIdx(p_4823, 0D)))) : 0D);
return Add(GetIdx(p_4823, 1D), ((V)(((ToNum(GetIdx(q_4824, 1D)) - ToNum(GetIdx(p_4823, 1D))) * t_4825))));
return default;
}, 1, "", true);
hid_4767 = Invoke(S_4759, "hide", Fn((V _arrowThis4833, int _argc4826, V q_4832, V _a4829, V _a4830, V _a4831, V[] _rest4827) => {
return ((Get(q_4832, "inBody") is var _t4834 && !Truthy(_t4834) ? _t4834 : Invoke(S_4759, "dk", q_4832, ((V)("top")))) is var _t4835 && !Truthy(_t4835) ? _t4835 : Invoke(Arr(((V)("rim")), ((V)("broth")), ((V)("lip")), ((V)("sticks"))), "includes", Call(sid_4762, V.Undef, q_4832)));
}, 1, "", true));
bro_4768 = Invoke(hid_4767, "find", Fn((V _arrowThis4843, int _argc4836, V q_4842, V _a4839, V _a4840, V _a4841, V[] _rest4837) => {
return (SEqS(Call(sid_4762, V.Undef, q_4842), "broth") ? V.True : V.False);
}, 1, "", true));
BF_4769 = (Truthy(bro_4768) ? Invoke(S_4759, "f", bro_4768) : ((V)("#efb35c")));
sk0_4770 = Invoke(hid_4767, "find", Fn((V _arrowThis4851, int _argc4844, V q_4850, V _a4847, V _a4848, V _a4849, V[] _rest4845) => {
return (SEqS(Call(sid_4762, V.Undef, q_4850), "sticks") ? V.True : V.False);
}, 1, "", true));
CK_4771 = (Truthy(sk0_4770) ? Invoke(S_4759, "f", sk0_4770) : ((V)("#d9a868")));
Invoke(S_4759, "hide", Fn((V _arrowThis4859, int _argc4852, V q_4858, V _a4855, V _a4856, V _a4857, V[] _rest4853) => {
return ((Get(q_4858, "inBody") is var _t4860 && !Truthy(_t4860) ? _t4860 : (!(Truthy(Invoke(S_4759, "dk", q_4858))) ? V.True : V.False)) is var _t4861 && !Truthy(_t4861) ? _t4861 : ((SEqS(Invoke(S_4759, "f", q_4858), "#e2402e") || SEqS(Invoke(S_4759, "s", q_4858), "#e2402e")) ? V.True : V.False));
}, 1, "", true));
sh_4772 = Invoke(S_4759, "path", NewObj(1).Put("fill", Invoke(S_4759, "lgrad", ((V)("ndsh")), Arr(Arr(((V)(0D)), ((V)("#8a7a66")), ((V)(0.3))), Arr(((V)(0.15)), ((V)("#8a7a66")), ((V)(0.06))), Arr(((V)(0.3)), ((V)("#ffffff")), ((V)(0.4))), Arr(((V)(0.46)), ((V)("#ffffff")), ((V)(0D))), Arr(((V)(0.76)), ((V)("#6a5a46")), ((V)(0.05))), Arr(((V)(1D)), ((V)("#6a5a46")), ((V)(0.34)))))).V);
bd_4773 = Invoke(S_4759, "path", NewObj(1).Put("fill", ((V)("#e2402e"))).V);
rm_4774 = Invoke(S_4759, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#e2402e"))).Put("stroke-width", ((V)(1D))).Put("stroke-linejoin", ((V)("round"))).Put("stroke-linecap", ((V)("round"))).V);
rimB_4775 = Invoke(S_4759, "path", NewObj(1).Put("fill", ((V)("#fbf3e6"))).V);
rimI_4776 = Invoke(S_4759, "path", NewObj(1).Put("fill", ((V)("#efe4d2"))).V);
broth_4777 = Invoke(S_4759, "path", NewObj(1).Put("fill", BF_4769).V);
FG_4778 = Invoke(S_4759, "g");
TG_4779 = Invoke(S_4759, "g");
rimF_4780 = Invoke(S_4759, "path", NewObj(1).Put("fill", ((V)("#fbf3e6"))).V);
rimL_4781 = Invoke(S_4759, "path", NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(0.8))).Put("opacity", ((V)(0.8))).V);
FL_4782 = Invoke(S_4759, "decals", Fn((V _arrowThis4869, int _argc4862, V q_4868, V _a4865, V _a4866, V _a4867, V[] _rest4863) => {
return (Get(q_4868, "inBody") is var _t4870 && !Truthy(_t4870) ? _t4870 : (SEqS(Call(sid_4762, V.Undef, q_4868), "flat") ? V.True : V.False));
}, 1, "", true), FG_4778);
box_4783 = Fn((V _arrowThis4878, int _argc4871, V D__4877, V _a4874, V _a4875, V _a4876, V[] _rest4872) => {
V x0_4879 = default;
V x1_4880 = default;
V y0_4881 = default;
V y1_4882 = default;
x0_4879 = ((V)(1000000000D));
x1_4880 = ((V)((-1000000000D)));
y0_4881 = ((V)(1000000000D));
y1_4882 = ((V)((-1000000000D)));
Invoke(D__4877, "forEach", Fn((V _arrowThis4890, int _argc4883, V o_4889, V _a4886, V _a4887, V _a4888, V[] _rest4884) => {
return Invoke(Get(o_4889, "L"), "forEach", Fn((V _arrowThis4898, int _argc4891, V L_4897, V _a4894, V _a4895, V _a4896, V[] _rest4892) => {
return Invoke(L_4897, "forEach", Fn((V _arrowThis4906, int _argc4899, V p_4905, V _a4902, V _a4903, V _a4904, V[] _rest4900) => {
if (Lt(GetIdx(p_4905, 0D), x0_4879)) {
x0_4879 = GetIdx(p_4905, 0D);
}
if (Gt(GetIdx(p_4905, 0D), x1_4880)) {
x1_4880 = GetIdx(p_4905, 0D);
}
if (Lt(GetIdx(p_4905, 1D), y0_4881)) {
y0_4881 = GetIdx(p_4905, 1D);
}
if (Gt(GetIdx(p_4905, 1D), y1_4882)) {
y1_4882 = GetIdx(p_4905, 1D);
}
return default;
}, 1, "", true));
}, 1, "", true));
}, 1, "", true));
return NewObj(4).Put("x0", x0_4879).Put("x1", x1_4880).Put("y0", y0_4881).Put("y1", y1_4882).V;
return default;
}, 1, "", true);
SP_4784 = Invoke(Arr(((V)("chashu")), ((V)("heap")), ((V)("egg")), ((V)("nar1")), ((V)("nar2"))), "map", Fn((V _arrowThis4914, int _argc4907, V n_4913, V _a4910, V _a4911, V _a4912, V[] _rest4908) => {
V g_4915 = default;
V D__4916 = default;
V b_4917 = default;
double h_4918 = 0;
g_4915 = Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, TG_4779);
D__4916 = Invoke(S_4759, "decals", Fn((V _arrowThis4926, int _argc4919, V q_4925, V _a4922, V _a4923, V _a4924, V[] _rest4920) => {
return (Get(q_4925, "inBody") is var _t4927 && !Truthy(_t4927) ? _t4927 : (SEq(Call(sid_4762, V.Undef, q_4925), n_4913) ? V.True : V.False));
}, 1, "", true), g_4915);
b_4917 = Call(box_4783, V.Undef, D__4916);
h_4918 = (ToNum(Get(b_4917, "y1")) - ToNum(Get(b_4917, "y0")));
return NewObj(6).Put("n", n_4913).Put("g", g_4915).Put("D", D__4916).Put("ax", ((V)((ToNum(Add(Get(b_4917, "x0"), Get(b_4917, "x1"))) / 2D)))).Put("ay", ((V)((ToNum(Get(b_4917, "y1")) - Min(2.2, (h_4918 * 0.3)))))).Put("lag", ((V)((SEqS(n_4913, "heap") ? 1D : 0.5)))).V;
return default;
}, 1, "", true));
hp_4785 = Invoke(SP_4784, "find", Fn((V _arrowThis4935, int _argc4928, V o_4934, V _a4931, V _a4932, V _a4933, V[] _rest4929) => {
return (SEqS(Get(o_4934, "n"), "heap") ? V.True : V.False);
}, 1, "", true));
Set(hp_4785, "sl", Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis4942, int _argc4936, V _a4938, V _a4939, V _a4940, V _a4941, V[] _rest4937) => {
return Call(el_14, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#b07c22"))).Put("stroke-width", ((V)(2.2))).Put("stroke-linecap", ((V)("round"))).V, Get(hp_4785, "g"));
}, 0, "", true)));
Set(hp_4785, "sl2", Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis4949, int _argc4943, V _a4945, V _a4946, V _a4947, V _a4948, V[] _rest4944) => {
return Call(el_14, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffd65e"))).Put("stroke-width", ((V)(1.5))).Put("stroke-linecap", ((V)("round"))).V, Get(hp_4785, "g"));
}, 0, "", true)));
NS_4786 = Invoke(Arr(((V)("nori1")), ((V)("nori2"))), "map", Fn((V _arrowThis4957, int _argc4950, V n_4956, V _a4953, V _a4954, V _a4955, V[] _rest4951) => {
V g_4958 = default;
V D__4959 = default;
V b_4960 = default;
g_4958 = Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, TG_4779);
D__4959 = Invoke(S_4759, "decals", Fn((V _arrowThis4968, int _argc4961, V q_4967, V _a4964, V _a4965, V _a4966, V[] _rest4962) => {
return (Get(q_4967, "inBody") is var _t4969 && !Truthy(_t4969) ? _t4969 : (SEq(Call(sid_4762, V.Undef, q_4967), n_4956) ? V.True : V.False));
}, 1, "", true), g_4958);
b_4960 = Call(box_4783, V.Undef, D__4959);
return NewObj(5).Put("n", n_4956).Put("g", g_4958).Put("D", D__4959).Put("yb", ((V)((ToNum(Get(b_4960, "y1")) - 0.6)))).Put("cx", ((V)((ToNum(Add(Get(b_4960, "x0"), Get(b_4960, "x1"))) / 2D)))).V;
return default;
}, 1, "", true));
SG_4787 = Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, TG_4779);
hang_4788 = Call(el_14, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#b07c22"))).Put("stroke-width", ((V)(2.2))).Put("stroke-linecap", ((V)("round"))).V, SG_4787);
hang2_4789 = Call(el_14, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffd65e"))).Put("stroke-width", ((V)(1.5))).Put("stroke-linecap", ((V)("round"))).V, SG_4787);
ck_4790 = Invoke(S_4759, "lgrad", ((V)("ndck")), Arr(Arr(((V)(0D)), ((V)("#f4d6a4"))), Arr(((V)(0.5)), ((V)("#d9a868"))), Arr(((V)(1D)), ((V)("#a87a44")))), NewObj(4).Put("x1", ((V)(0D))).Put("y1", ((V)(0D))).Put("x2", ((V)(0D))).Put("y2", ((V)(1D))).V);
sticks_4791 = Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _arrowThis4976, int _argc4970, V _a4972, V _a4973, V _a4974, V _a4975, V[] _rest4971) => {
return Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", (Truthy(Invoke(CK_4771, "startsWith", ((V)("url")))) ? ck_4790 : CK_4771)).V, SG_4787);
}, 0, "", true));
return NewObj(29).Put("EL", ((V)(EL_4760))).Put("O", O_4761).Put("rT", rT_4766).Put("Y0", Y0_4764).Put("Y1", Y1_4765).Put("YR", Y0_4764).Put("YB", Add(Y0_4764, ((V)(0.3)))).Put("R0", Call(rT_4766, V.Undef, Y0_4764)).Put("sh", sh_4772).Put("bd", bd_4773).Put("rm", rm_4774).Put("rimB", rimB_4775).Put("rimI", rimI_4776).Put("broth", broth_4777).Put("FG", FG_4778).Put("TG", TG_4779).Put("rimF", rimF_4780).Put("rimL", rimL_4781).Put("FL", FL_4782).Put("SP", SP_4784).Put("NS", NS_4786).Put("SG", SG_4787).Put("hang", hang_4788).Put("hang2", hang2_4789).Put("sticks", sticks_4791).Put("rx", ((V)(34D))).Put("ya", ((V)(55D))).Put("yb", ((V)(86D))).Put("zE", Fn((V _arrowThis4985, int _argc4977, V dx_4983, V dy_4984, V _a4981, V _a4982, V[] _rest4978) => {
V r_4986 = default;
r_4986 = Call(rT_4766, V.Undef, Add(Get(S_4759, "HY"), dy_4984));
return ((V)((System.Math.Sqrt(Max(0D, ((ToNum(r_4986) * ToNum(r_4986)) - (ToNum(dx_4983) * ToNum(dx_4983))))) + 0.3)));
return default;
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self4987, int _argc4988, V B_4994, V D_4995, V _a4992, V _a4993, V[] _rest4989) => {
V Z3_4996 = default;
V set_4997 = default;
V EL_4998 = default;
V rT_4999 = default;
V YR_5000 = default;
V YB_5001 = default;
V R0_5002 = default;
V PE_5003 = default;
V slurp_5004 = default;
V lid_5005 = default;
V ts_5006 = default;
V RP_5007 = default;
V ring_5008 = default;
V hp_5009 = default;
V A_5010 = default;
double yS_5011 = 0;
double hS_5012 = 0;
V rS_5013 = default;
double nS_5014 = 0;
double wS_5015 = 0;
double q_5016 = 0;
V SPI_5017 = default;
JsStrBuf rd_5018 = null;
V zOf_5019 = default;
V L_5020 = default;
V zt_5021 = default;
double ze_5022 = 0;
double lf_5023 = 0;
double dp_5024 = 0;
V T_5025 = default;
V E_5026 = default;
V tips_5027 = default;
JsStrBuf hd_5028 = null;
V FA_5029 = default;
if (_self4987.IsNullish) _self4987 = GlobalV;
{ V _t5030 = D_4995;
if (_t5030.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t5030));
{ V _t5031 = Get(_t5030, "Z3");
Z3_4996 = _t5031; }
{ V _t5032 = Get(_t5030, "set");
set_4997 = _t5032; } }
{ V _t5033 = B_4994;
if (_t5033.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t5033));
{ V _t5034 = Get(_t5033, "EL");
EL_4998 = _t5034; }
{ V _t5035 = Get(_t5033, "rT");
rT_4999 = _t5035; }
{ V _t5036 = Get(_t5033, "YR");
YR_5000 = _t5036; }
{ V _t5037 = Get(_t5033, "YB");
YB_5001 = _t5037; }
{ V _t5038 = Get(_t5033, "R0");
R0_5002 = _t5038; } }
PE_5003 = Call(PEf_48, V.Undef, D_4995, EL_4998, rT_4999);
slurp_5004 = Call(clamp_12, V.Undef, Invoke(D_4995, "bv", ((V)("slurp"))), ((V)(0D)), ((V)(1.2)));
lid_5005 = Call(clamp_12, V.Undef, Invoke(D_4995, "bv", ((V)("lid"))), ((V)((-1D))), ((V)(1.2)));
ts_5006 = Get(D_4995, "ts");
RP_5007 = Fn((V _arrowThis5048, int _argc5039, V r_5045, V y_5046, V f_5047, V _a5044, V[] _rest5040) => {
return Call(PE_5003, V.Undef, ((V)((50D + (ToNum(r_5045) * FdLibm.Sin(ToNum(f_5047)))))), y_5046, ((V)((ToNum(r_5045) * FdLibm.Cos(ToNum(f_5047))))));
}, 3, "", true);
ring_5008 = Fn((V _arrowThis5058, int _argc5049, V r_5055, V y_5056, V n_5057, V _a5054, V[] _rest5050) => {
return Array_from(NewObj(1).Put("length", n_5057).V, Fn((V _arrowThis5067, int _argc5059, V __5065, V i_5066, V _a5063, V _a5064, V[] _rest5060) => {
return Call(RP_5007, V.Undef, r_5055, y_5056, ((V)(((ToNum(i_5066) / ToNum(n_5057)) * TAU_9))));
}, 2, "", true));
}, 3, "", true);
hp_5009 = Arr();
{
double i_5068 = 0;
i_5068 = 0D;
while (true) {
if (!((i_5068 <= 16D))) break;
V y_5070 = default;
y_5070 = Add(Get(B_4994, "Y0"), ((V)((((ToNum(Get(B_4994, "Y1")) - ToNum(Get(B_4994, "Y0"))) * i_5068) / 16D))));
Invoke(Call(ring_5008, V.Undef, Call(rT_4999, V.Undef, y_5070), y_5070, ((V)(28D))), "forEach", Fn((V _arrowThis5078, int _argc5071, V p_5077, V _a5074, V _a5075, V _a5076, V[] _rest5072) => {
return Invoke(hp_5009, "push", p_5077);
}, 1, "", true));
i_5068++;
}
}
Set(B_4994, "d", Invoke(D_4995, "hull", hp_5009));
Call(set_4997, V.Undef, Get(B_4994, "sh"), ((V)("d")), Get(B_4994, "d"));
A_5010 = Invoke(Get(SN_43, "h"), "frontArc", D_4995, ((V)(34D)), ((V)(58D)), ((V)(72D)));
if (GtN(Get(A_5010, "length"), 1D)) {
Call(set_4997, V.Undef, Get(B_4994, "bd"), ((V)("d")), Call(polyW_18, V.Undef, Invoke(Invoke(A_5010, "map", Fn((V _arrowThis5094, int _argc5087, V f_5093, V _a5090, V _a5091, V _a5092, V[] _rest5088) => {
return Call(RP_5007, V.Undef, Add(Call(rT_4999, V.Undef, ((V)(55.4))), ((V)(0.05))), ((V)(55.4)), f_5093);
}, 1, "", true)), "concat", Invoke(Invoke(Invoke(A_5010, "slice"), "reverse"), "map", Fn((V _arrowThis5086, int _argc5079, V f_5085, V _a5082, V _a5083, V _a5084, V[] _rest5080) => {
return Call(RP_5007, V.Undef, Add(Call(rT_4999, V.Undef, ((V)(57.1))), ((V)(0.05))), ((V)(57.1)), f_5085);
}, 1, "", true)))));
} else {
Call(set_4997, V.Undef, Get(B_4994, "bd"), ((V)("d")), ((V)("M0 0")));
}
yS_5011 = 58.8;
hS_5012 = 4D;
rS_5013 = Add(Call(rT_4999, V.Undef, ((V)((yS_5011 + (hS_5012 / 2D))))), ((V)(0.08)));
nS_5014 = Round(((TAU_9 * ToNum(rS_5013)) / 7.4));
wS_5015 = (TAU_9 / nS_5014);
q_5016 = 0.82;
SPI_5017 = Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(0D)), ((V)(0D))), Arr(((V)(q_5016)), ((V)(0D))), Arr(((V)(q_5016)), ((V)(0.8))), Arr(((V)((q_5016 * 0.25))), ((V)(0.8))), Arr(((V)((q_5016 * 0.25))), ((V)(0.3))), Arr(((V)((q_5016 * 0.62))), ((V)(0.3))), Arr(((V)((q_5016 * 0.62))), ((V)(0.55))));
rd_5018 = new JsStrBuf("");
{
double i_5095 = 0;
i_5095 = 0D;
while (true) {
if (!((i_5095 < nS_5014))) break;
double f0_5097 = 0;
double fm_5098 = 0;
f0_5097 = ((i_5095 - 0.41) * wS_5015);
fm_5098 = (f0_5097 + (0.41 * wS_5015));
if (LtN(Invoke(D_4995, "facing", ((V)((50D + (ToNum(rS_5013) * FdLibm.Sin(fm_5098))))), ((V)(yS_5011)), ((V)((ToNum(rS_5013) * FdLibm.Cos(fm_5098)))), ((V)(FdLibm.Sin(fm_5098))), ((V)(0D)), ((V)(FdLibm.Cos(fm_5098)))), 0.08)) {
goto _cont5096;
}
rd_5018.S("M").V(Invoke(Invoke(SPI_5017, "map", Fn((V _arrowThis5110, int _argc5099, V _a5101, V _a5102, V _a5103, V _a5104, V[] _rest5100) => {
double f_5111 = 0;
double y_5112 = 0;
V r_5113 = default;
V u_5107 = default;
V v_5109 = default;
{ V _t5105 = ListOf(_a5101);
{ V _t5106 = GetIdx(_t5105, 0D);
u_5107 = _t5106; }
{ V _t5108 = GetIdx(_t5105, 1D);
v_5109 = _t5108; }
}
f_5111 = (f0_5097 + (ToNum(u_5107) * wS_5015));
y_5112 = (yS_5011 + (ToNum(v_5109) * hS_5012));
r_5113 = Add(Call(rT_4999, V.Undef, ((V)(y_5112))), ((V)(0.08)));
return Call(pt_15, V.Undef, Call(RP_5007, V.Undef, r_5113, ((V)(y_5112)), ((V)(f_5111))));
return default;
}, 1, "", true)), "join", ((V)("L"))));
_cont5096: ;
i_5095++;
}
}
Call(set_4997, V.Undef, Get(B_4994, "rm"), ((V)("d")), (((V)(rd_5018.Str)) is var _t5114 && Truthy(_t5114) ? _t5114 : ((V)("M0 0"))));
Call(set_4997, V.Undef, Get(B_4994, "rimB"), ((V)("d")), Call(polyW_18, V.Undef, Call(ring_5008, V.Undef, ((V)(37D)), YR_5000, ((V)(56D)))));
Call(set_4997, V.Undef, Get(B_4994, "rimI"), ((V)("d")), Call(polyW_18, V.Undef, Call(ring_5008, V.Undef, ((V)(35.2)), Add(YR_5000, ((V)(0.1))), ((V)(56D)))));
Call(set_4997, V.Undef, Get(B_4994, "broth"), ((V)("d")), Call(polyW_18, V.Undef, Call(ring_5008, V.Undef, ((V)(33.6)), YB_5001, ((V)(56D)))));
zOf_5019 = Fn((V _arrowThis5122, int _argc5115, V y_5121, V _a5118, V _a5119, V _a5120, V[] _rest5116) => {
return Add(((V)(((ToNum(y_5121) - ToNum(YB_5001)) / ToNum(EL_4998)))), R0_5002);
}, 1, "", true);
Invoke(Get(B_4994, "FL"), "forEach", Fn((V _arrowThis5130, int _argc5123, V o_5129, V _a5126, V _a5127, V _a5128, V[] _rest5124) => {
return Call(set_4997, V.Undef, Get(o_5129, "e"), ((V)("d")), Call(decD_26, V.Undef, o_5129, Fn((V _arrowThis5139, int _argc5131, V x_5137, V y_5138, V _a5135, V _a5136, V[] _rest5132) => {
return Call(PE_5003, V.Undef, x_5137, YB_5001, Call(zOf_5019, V.Undef, y_5138));
}, 2, "", true)));
}, 1, "", true));
L_5020 = Arr();
Invoke(Get(B_4994, "SP"), "forEach", Fn((V _arrowThis5147, int _argc5140, V sp_5146, V _a5143, V _a5144, V _a5145, V[] _rest5141) => {
V A3_5148 = default;
V C_5149 = default;
V cy_5150 = default;
V kx_5151 = default;
double ky_5152 = 0;
double sy_5153 = 0;
double oy_5154 = 0;
A3_5148 = Arr(Add(Get(sp_5146, "ax"), ((V)(((ToNum(Get(D_4995, "ox")) * 0.05) * ToNum(Get(sp_5146, "lag")))))), YB_5001, Call(zOf_5019, V.Undef, Get(sp_5146, "ay")));
C_5149 = Call(PE_5003, V.Undef, GetIdx(A3_5148, 0D), GetIdx(A3_5148, 1D), GetIdx(A3_5148, 2D));
cy_5150 = Call(PE_5003, V.Undef, GetIdx(A3_5148, 0D), Add(GetIdx(A3_5148, 1D), ((V)(1D))), GetIdx(A3_5148, 2D));
kx_5151 = Get(D_4995, "kS");
ky_5152 = Hypot((ToNum(GetIdx(cy_5150, 0D)) - ToNum(GetIdx(C_5149, 0D))), (ToNum(GetIdx(cy_5150, 1D)) - ToNum(GetIdx(C_5149, 1D))));
sy_5153 = (SEqS(Get(sp_5146, "n"), "heap") ? (1D - (0.1 * ToNum(slurp_5004))) : 1D);
oy_5154 = (((-ToNum(Get(D_4995, "oy"))) * 0.08) * ToNum(Get(sp_5146, "lag")));
Invoke(Get(sp_5146, "D"), "forEach", Fn((V _arrowThis5162, int _argc5155, V o_5161, V _a5158, V _a5159, V _a5160, V[] _rest5156) => {
return Call(set_4997, V.Undef, Get(o_5161, "e"), ((V)("d")), Call(decD_26, V.Undef, o_5161, Fn((V _arrowThis5171, int _argc5163, V x_5169, V y_5170, V _a5167, V _a5168, V[] _rest5164) => {
return Arr(Add(GetIdx(C_5149, 0D), ((V)(((ToNum(x_5169) - ToNum(Get(sp_5146, "ax"))) * ToNum(kx_5151))))), Add(Add(GetIdx(C_5149, 1D), ((V)((((ToNum(y_5170) - ToNum(Get(sp_5146, "ay"))) * ky_5152) * sy_5153)))), ((V)(oy_5154))));
}, 2, "", true)));
}, 1, "", true));
if (Truthy(Get(sp_5146, "sl"))) {
V top_5172 = default;
top_5172 = Arr(GetIdx(C_5149, 0D), ((V)((ToNum(GetIdx(C_5149, 1D)) - ((9D * ky_5152) * sy_5153)))));
Invoke(Get(sp_5146, "sl"), "forEach", Fn((V _arrowThis5181, int _argc5173, V e_5179, V j_5180, V _a5177, V _a5178, V[] _rest5174) => {
JsStrBuf d_5182 = null;
d_5182 = new JsStrBuf("");
if (GtN(slurp_5004, 0.03)) {
double h_5183 = 0;
V x0_5184 = default;
h_5183 = (13D * ToNum(slurp_5004));
x0_5184 = Add(GetIdx(top_5172, 0D), ((V)((((ToNum(j_5180) - 1D) * 3.2) * ToNum(kx_5151)))));
{
double i_5185 = 0;
i_5185 = 0D;
while (true) {
if (!((i_5185 <= 14D))) break;
double u_5187 = 0;
u_5187 = (i_5185 / 14D);
d_5182.S((NumTruthy(i_5185) ? "L" : "M")).V(Call(r2_11, V.Undef, Add(x0_5184, ((V)(((1.1 * ToNum(kx_5151)) * FdLibm.Sin((((u_5187 * 9D) + (ToNum(j_5180) * 2.1)) + (ToNum(ts_5006) * 9D))))))))).S(" ").V(Call(r2_11, V.Undef, ((V)((ToNum(GetIdx(top_5172, 1D)) - ((h_5183 * u_5187) * ky_5152))))));
i_5185++;
}
}
}
Call(set_4997, V.Undef, e_5179, ((V)("d")), (((V)(d_5182.Str)) is var _t5188 && Truthy(_t5188) ? _t5188 : ((V)("M0 0"))));
Call(set_4997, V.Undef, GetK(Get(sp_5146, "sl2"), j_5180), ((V)("d")), (((V)(d_5182.Str)) is var _t5189 && Truthy(_t5189) ? _t5189 : ((V)("M0 0"))));
return default;
}, 2, "", true));
}
Invoke(L_5020, "push", NewObj(3).Put("id", Get(sp_5146, "n")).Put("e", Get(sp_5146, "g")).Put("z", Call(Z3_4996, V.Undef, GetIdx(A3_5148, 0D), GetIdx(A3_5148, 1D), GetIdx(A3_5148, 2D))).V);
return default;
}, 1, "", true));
Invoke(Get(B_4994, "NS"), "forEach", Fn((V _arrowThis5197, int _argc5190, V sh_5196, V _a5193, V _a5194, V _a5195, V[] _rest5191) => {
V z_5198 = default;
V sw_5199 = default;
z_5198 = Call(zOf_5019, V.Undef, Get(sh_5196, "yb"));
sw_5199 = Call(clamp_12, V.Undef, ((V)(((-ToNum(Get(D_4995, "ox"))) * 0.05))), ((V)((-0.6))), ((V)(0.6)));
Invoke(Get(sh_5196, "D"), "forEach", Fn((V _arrowThis5207, int _argc5200, V o_5206, V _a5203, V _a5204, V _a5205, V[] _rest5201) => {
return Call(set_4997, V.Undef, Get(o_5206, "e"), ((V)("d")), Call(decD_26, V.Undef, o_5206, Fn((V _arrowThis5216, int _argc5208, V x_5214, V y_5215, V _a5212, V _a5213, V[] _rest5209) => {
double up_5217 = 0;
up_5217 = (Max(0D, (ToNum(Get(sh_5196, "yb")) - ToNum(y_5215))) / 20D);
return Call(PE_5003, V.Undef, Add(x_5214, ((V)(((ToNum(sw_5199) * up_5217) * 5D)))), ((V)(((ToNum(y_5215) - (ToNum(EL_4998) * (ToNum(z_5198) - ToNum(R0_5002)))) + ((up_5217 * up_5217) * 0.3)))), ((V)((ToNum(z_5198) - (up_5217 * 1.5)))));
return default;
}, 2, "", true)));
}, 1, "", true));
Invoke(L_5020, "push", NewObj(3).Put("id", Get(sh_5196, "n")).Put("e", Get(sh_5196, "g")).Put("z", ((V)((ToNum(Call(Z3_4996, V.Undef, Get(sh_5196, "cx"), ((V)((ToNum(YB_5001) - 8D))), z_5198)) - 4D)))).V);
return default;
}, 1, "", true));
zt_5021 = Call(zOf_5019, V.Undef, ((V)(46.4)));
ze_5022 = (ToNum(zt_5021) - 9D);
lf_5023 = Max(0D, ToNum(lid_5005));
dp_5024 = Min(0D, ToNum(lid_5005));
T_5025 = Arr(Arr(((V)(53.8)), ((V)(39.6))), Arr(((V)(56.8)), ((V)(41.2))));
E_5026 = Arr(Arr(((V)(88.6)), ((V)(13.4))), Arr(((V)(92.4)), ((V)(17.4))));
tips_5027 = Arr();
Invoke(Get(B_4994, "sticks"), "forEach", Fn((V _arrowThis5226, int _argc5218, V e_5224, V i_5225, V _a5222, V _a5223, V[] _rest5219) => {
V t3_5227 = default;
V e3_5228 = default;
V a_5229 = default;
V b_5230 = default;
double dx_5231 = 0;
double dy_5232 = 0;
V l_5233 = default;
double nx_5234 = 0;
double ny_5235 = 0;
double w0_5236 = 0;
double w1_5237 = 0;
t3_5227 = Arr(((V)((ToNum(GetIdx(GetK(T_5025, i_5225), 0D)) - (2D * lf_5023)))), ((V)((((ToNum(GetIdx(GetK(T_5025, i_5225), 1D)) - (ToNum(EL_4998) * (ToNum(zt_5021) - ToNum(R0_5002)))) - (11D * lf_5023)) - (2.5 * dp_5024)))), zt_5021);
e3_5228 = Arr(((V)(((ToNum(GetIdx(GetK(E_5026, i_5225), 0D)) - (5D * lf_5023)) + (2D * dp_5024)))), ((V)((((ToNum(GetIdx(GetK(E_5026, i_5225), 1D)) - (ToNum(EL_4998) * (ze_5022 - ToNum(R0_5002)))) - (8D * lf_5023)) - (3D * dp_5024)))), ((V)(ze_5022)));
a_5229 = Call(PE_5003, V.Undef, GetIdx(t3_5227, 0D), GetIdx(t3_5227, 1D), GetIdx(t3_5227, 2D));
b_5230 = Call(PE_5003, V.Undef, GetIdx(e3_5228, 0D), GetIdx(e3_5228, 1D), GetIdx(e3_5228, 2D));
dx_5231 = (ToNum(GetIdx(b_5230, 0D)) - ToNum(GetIdx(a_5229, 0D)));
dy_5232 = (ToNum(GetIdx(b_5230, 1D)) - ToNum(GetIdx(a_5229, 1D)));
l_5233 = (((V)(Hypot(dx_5231, dy_5232))) is var _t5238 && Truthy(_t5238) ? _t5238 : ((V)(1D)));
nx_5234 = ((-dy_5232) / ToNum(l_5233));
ny_5235 = (dx_5231 / ToNum(l_5233));
w0_5236 = (0.72 * ToNum(Get(D_4995, "kS")));
w1_5237 = (1.15 * ToNum(Get(D_4995, "kS")));
Invoke(tips_5027, "push", t3_5227);
Call(set_4997, V.Undef, e_5224, ((V)("d")), Call(polyD_16, V.Undef, Arr(Arr(Add(GetIdx(a_5229, 0D), ((V)((nx_5234 * w0_5236)))), Add(GetIdx(a_5229, 1D), ((V)((ny_5235 * w0_5236))))), Arr(Add(GetIdx(b_5230, 0D), ((V)((nx_5234 * w1_5237)))), Add(GetIdx(b_5230, 1D), ((V)((ny_5235 * w1_5237))))), Arr(((V)((ToNum(GetIdx(b_5230, 0D)) - (nx_5234 * w1_5237)))), ((V)((ToNum(GetIdx(b_5230, 1D)) - (ny_5235 * w1_5237))))), Arr(((V)((ToNum(GetIdx(a_5229, 0D)) - (nx_5234 * w0_5236)))), ((V)((ToNum(GetIdx(a_5229, 1D)) - (ny_5235 * w0_5236))))))));
return default;
}, 2, "", true));
hd_5028 = new JsStrBuf("");
if ((lf_5023 > 0.04)) {
V m3_5239 = default;
V b3_5240 = default;
m3_5239 = Arr(((V)((ToNum(Add(GetIdx(GetIdx(tips_5027, 0D), 0D), GetIdx(GetIdx(tips_5027, 1D), 0D))) / 2D))), ((V)(((ToNum(Add(GetIdx(GetIdx(tips_5027, 0D), 1D), GetIdx(GetIdx(tips_5027, 1D), 1D))) / 2D) + 0.6))), zt_5021);
b3_5240 = Arr(((V)(48D)), ((V)((ToNum(YB_5001) - 8D))), Add(zt_5021, ((V)(3D))));
{
double j_5241 = 0;
j_5241 = 0D;
while (true) {
if (!((j_5241 < 4D))) break;
V Q_5243 = default;
Q_5243 = Arr();
{
double i_5244 = 0;
i_5244 = 0D;
while (true) {
if (!((i_5244 <= 16D))) break;
double u_5246 = 0;
V x_5247 = default;
V y_5248 = default;
V z_5249 = default;
u_5246 = (i_5244 / 16D);
x_5247 = Add(Add(Add(GetIdx(m3_5239, 0D), ((V)(((ToNum(GetIdx(b3_5240, 0D)) - ToNum(GetIdx(m3_5239, 0D))) * u_5246)))), ((V)((((j_5241 - 1.5) * 1.1) * u_5246)))), ((V)(((1.2 * FdLibm.Sin((((u_5246 * 10D) + (j_5241 * 1.9)) + (ToNum(ts_5006) * 4D)))) * FdLibm.Sin((u_5246 * System.Math.PI))))));
y_5248 = Add(GetIdx(m3_5239, 1D), ((V)(((ToNum(GetIdx(b3_5240, 1D)) - ToNum(GetIdx(m3_5239, 1D))) * u_5246))));
z_5249 = Add(GetIdx(m3_5239, 2D), ((V)(((ToNum(GetIdx(b3_5240, 2D)) - ToNum(GetIdx(m3_5239, 2D))) * u_5246))));
Invoke(Q_5243, "push", Call(PE_5003, V.Undef, x_5247, y_5248, z_5249));
i_5244++;
}
}
hd_5028.V(Call(runs_21, V.Undef, Q_5243, Invoke(Q_5243, "map", Fn((V _arrowThis5256, int _argc5250, V _a5252, V _a5253, V _a5254, V _a5255, V[] _rest5251) => {
return (true ? V.True : V.False);
}, 0, "", true))));
j_5241++;
}
}
}
Call(set_4997, V.Undef, Get(B_4994, "hang"), ((V)("d")), (((V)(hd_5028.Str)) is var _t5257 && Truthy(_t5257) ? _t5257 : ((V)("M0 0"))));
Call(set_4997, V.Undef, Get(B_4994, "hang2"), ((V)("d")), (((V)(hd_5028.Str)) is var _t5258 && Truthy(_t5258) ? _t5258 : ((V)("M0 0"))));
Invoke(L_5020, "push", NewObj(3).Put("id", ((V)("st"))).Put("e", Get(B_4994, "SG")).Put("z", Add(Call(Z3_4996, V.Undef, ((V)(70D)), ((V)((ToNum(YB_5001) - 12D))), zt_5021), ((V)(1D)))).V);
Invoke(L_5020, "sort", Fn((V _arrowThis5267, int _argc5259, V a_5265, V b_5266, V _a5263, V _a5264, V[] _rest5260) => {
return ((V)((ToNum(Get(a_5265, "z")) - ToNum(Get(b_5266, "z")))));
}, 2, "", true));
Invoke(SN_43, "order", Get(B_4994, "TG"), L_5020);
FA_5029 = Invoke(Get(SN_43, "h"), "frontArc", D_4995, ((V)(37D)), YR_5000, ((V)(72D)));
Call(set_4997, V.Undef, Get(B_4994, "rimF"), ((V)("d")), (GtN(Get(FA_5029, "length"), 1D) ? Call(polyW_18, V.Undef, Invoke(Invoke(FA_5029, "map", Fn((V _arrowThis5283, int _argc5276, V f_5282, V _a5279, V _a5280, V _a5281, V[] _rest5277) => {
return Call(RP_5007, V.Undef, ((V)(37.2)), YR_5000, f_5282);
}, 1, "", true)), "concat", Invoke(Invoke(Invoke(FA_5029, "slice"), "reverse"), "map", Fn((V _arrowThis5275, int _argc5268, V f_5274, V _a5271, V _a5272, V _a5273, V[] _rest5269) => {
return Call(RP_5007, V.Undef, ((V)(33.4)), YB_5001, f_5274);
}, 1, "", true)))) : ((V)("M0 0"))));
Call(set_4997, V.Undef, Get(B_4994, "rimL"), ((V)("d")), (GtN(Get(FA_5029, "length"), 1D) ? Call(runs_21, V.Undef, Invoke(FA_5029, "map", Fn((V _arrowThis5291, int _argc5284, V f_5290, V _a5287, V _a5288, V _a5289, V[] _rest5285) => {
return Call(RP_5007, V.Undef, ((V)(36.3)), ((V)((ToNum(YR_5000) - 0.05))), f_5290);
}, 1, "", true)), Invoke(FA_5029, "map", Fn((V _arrowThis5298, int _argc5292, V _a5294, V _a5295, V _a5296, V _a5297, V[] _rest5293) => {
return (true ? V.True : V.False);
}, 0, "", true))) : ((V)("M0 0"))));
return default;
}, 2, "draw", false)).V);
Set(MODELS_42, "flossie", NewObj(2).Put("setup", Fn((V _self5299, int _argc5300, V S_5306, V _a5303, V _a5304, V _a5305, V[] _rest5301) => {
V sk_5307 = default;
V C_5308 = default;
double R_5309 = 0;
V pf_5310 = default;
V PF_5311 = default;
V BF_5312 = default;
V fP_5313 = default;
V fB_5314 = default;
V st_5315 = default;
V stick_5316 = default;
V sts_5317 = default;
V BG_5318 = default;
V FG_5319 = default;
V sP_5320 = default;
V sB_5321 = default;
V PU_5322 = default;
double n_5323 = 0;
V wisp_5324 = default;
V wisp2_5325 = default;
V spk_5326 = default;
if (_self5299.IsNullish) _self5299 = GlobalV;
{ V _t5327 = S_5306;
if (_t5327.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t5327));
{ V _t5328 = Get(_t5327, "sk");
sk_5307 = _t5328; } }
C_5308 = Arr(((V)(50D)), ((V)(51D)));
R_5309 = 28D;
pf_5310 = Invoke(S_5306, "hide", Fn((V _arrowThis5336, int _argc5329, V q_5335, V _a5332, V _a5333, V _a5334, V[] _rest5330) => {
return (((Get(q_5335, "inBody") is var _t5337 && !Truthy(_t5337) ? _t5337 : (SEqS(Get(q_5335, "tag"), "circle") ? V.True : V.False)) is var _t5338 && !Truthy(_t5338) ? _t5338 : (!SEq(q_5335, Get(S_5306, "sk")) ? V.True : V.False)) is var _t5339 && !Truthy(_t5339) ? _t5339 : Invoke(NewRegExp(RX2, "^url", ""), "test", Invoke(S_5306, "f", q_5335)));
}, 1, "", true));
PF_5311 = (Invoke(pf_5310, "find", Fn((V _arrowThis5347, int _argc5340, V q_5346, V _a5343, V _a5344, V _a5345, V[] _rest5341) => {
return (Invoke(NewRegExp(RX13, "#p_", ""), "test", Invoke(S_5306, "f", q_5346)) is var _t5348 && Truthy(_t5348) ? _t5348 : Invoke(NewRegExp(RX14, "url\\(#p", ""), "test", Invoke(S_5306, "f", q_5346)));
}, 1, "", true)) is var _t5349 && Truthy(_t5349) ? _t5349 : NewObj(0).V);
BF_5312 = (Invoke(pf_5310, "find", Fn((V _arrowThis5357, int _argc5350, V q_5356, V _a5353, V _a5354, V _a5355, V[] _rest5351) => {
return Invoke(NewRegExp(RX15, "url\\(#b", ""), "test", Invoke(S_5306, "f", q_5356));
}, 1, "", true)) is var _t5358 && Truthy(_t5358) ? _t5358 : NewObj(0).V);
fP_5313 = (Truthy(Get(PF_5311, "e")) ? Invoke(S_5306, "f", PF_5311) : ((V)("#ffbede")));
fB_5314 = (Truthy(Get(BF_5312, "e")) ? Invoke(S_5306, "f", BF_5312) : ((V)("#b8e0ff")));
st_5315 = GetIdx(Invoke(S_5306, "hide", Fn((V _arrowThis5366, int _argc5359, V q_5365, V _a5362, V _a5363, V _a5364, V[] _rest5360) => {
return (Get(q_5365, "inBody") is var _t5367 && !Truthy(_t5367) ? _t5367 : Invoke(NewRegExp(RX16, "^M46 74", ""), "test", Invoke(S_5306, "d", q_5365)));
}, 1, "", true)), 0D);
Invoke(S_5306, "hide", Fn((V _arrowThis5375, int _argc5368, V q_5374, V _a5371, V _a5372, V _a5373, V[] _rest5369) => {
return (Get(q_5374, "inBody") is var _t5376 && !Truthy(_t5376) ? _t5376 : (((SEqS(Invoke(S_5306, "s", q_5374), "#ff8ac4") || SEqS(Invoke(S_5306, "s", q_5374), "#ffffff")) || SEqS(Invoke(S_5306, "s", q_5374), "#b8e0ff")) ? V.True : V.False));
}, 1, "", true));
Invoke(S_5306, "hide", Fn((V _arrowThis5384, int _argc5377, V q_5383, V _a5380, V _a5381, V _a5382, V[] _rest5378) => {
return ((((!(Truthy(Get(q_5383, "inBody"))) && SEqS(Get(q_5383, "tag"), "path")) && SEqS(Get(q_5383, "role"), "face")) && LtN(Get(q_5383, "cy"), 40D)) ? V.True : V.False);
}, 1, "", true));
stick_5316 = Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", (Truthy(st_5315) ? Invoke(S_5306, "f", st_5315) : ((V)("#ffffff")))).V, Get(S_5306, "gB"));
sts_5317 = Call(el_14, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ff8ac4"))).Put("stroke-width", ((V)(1.3))).Put("stroke-linecap", ((V)("round"))).V, Get(S_5306, "gB"));
BG_5318 = Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, Get(S_5306, "gB"));
FG_5319 = Invoke(S_5306, "g");
sP_5320 = Invoke(S_5306, "rgrad", ((V)("flp")), Arr(Arr(((V)(0D)), ((V)("#fff3f9"))), Arr(((V)(0.55)), ((V)("#ffcbe5"))), Arr(((V)(1D)), ((V)("#f7afd3")))), NewObj(3).Put("cx", ((V)("42%"))).Put("cy", ((V)("36%"))).Put("r", ((V)("68%"))).V);
sB_5321 = Invoke(S_5306, "rgrad", ((V)("flb")), Arr(Arr(((V)(0D)), ((V)("#f4fbff"))), Arr(((V)(0.55)), ((V)("#cbe8ff"))), Arr(((V)(1D)), ((V)("#a6d2f6")))), NewObj(3).Put("cx", ((V)("42%"))).Put("cy", ((V)("36%"))).Put("r", ((V)("68%"))).V);
PU_5322 = Arr();
n_5323 = 34D;
{
double i_5385 = 0;
i_5385 = 0D;
while (true) {
if (!((i_5385 < n_5323))) break;
double yy_5387 = 0;
double rr_5388 = 0;
double a_5389 = 0;
double dx_5390 = 0;
double dz_5391 = 0;
double dy_5392 = 0;
yy_5387 = (1D - ((2D * (i_5385 + 0.5)) / n_5323));
rr_5388 = System.Math.Sqrt((1D - (yy_5387 * yy_5387)));
a_5389 = (i_5385 * 2.39996);
dx_5390 = (rr_5388 * FdLibm.Cos(a_5389));
dz_5391 = (rr_5388 * FdLibm.Sin(a_5389));
dy_5392 = (-yy_5387);
if (((dz_5391 > 0.3) && (dy_5392 > (-0.55)))) {
goto _cont5386;
}
if ((dy_5392 > 0.8)) {
goto _cont5386;
}
Invoke(PU_5322, "push", NewObj(5).Put("d", Arr(((V)(dx_5390)), ((V)(dy_5392)), ((V)(dz_5391)))).Put("rho", ((V)(((R_5309 - 3D) + (ToNum(Call(rnd_22, V.Undef, ((V)(i_5385)))) * 3D))))).Put("r", ((V)((10D + (ToNum(Call(rnd_22, V.Undef, ((V)((i_5385 * 3D))))) * 4D))))).Put("c", (((i_5385 % 3D) == 1D) ? sB_5321 : sP_5320)).Put("id", ((V)(JsStrBuf.Begin().S("u").N(i_5385).End()))).V);
_cont5386: ;
i_5385++;
}
}
Invoke(PU_5322, "forEach", Fn((V _arrowThis5400, int _argc5393, V o_5399, V _a5396, V _a5397, V _a5398, V[] _rest5394) => {
Set(o_5399, "e", Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", Get(o_5399, "c")).V, BG_5318));
return default;
}, 1, "", true));
wisp_5324 = Invoke(S_5306, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(1.4))).Put("opacity", ((V)(0.55))).Put("stroke-linecap", ((V)("round"))).V);
wisp2_5325 = Invoke(S_5306, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#b8e0ff"))).Put("stroke-width", ((V)(1.8))).Put("opacity", ((V)(0.85))).Put("stroke-linecap", ((V)("round"))).V);
spk_5326 = Invoke(S_5306, "path", NewObj(2).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.95))).V);
return NewObj(15).Put("C", C_5308).Put("R", ((V)(R_5309))).Put("PU", PU_5322).Put("BG", BG_5318).Put("FG", FG_5319).Put("stick", stick_5316).Put("sts", sts_5317).Put("wisp", wisp_5324).Put("wisp2", wisp2_5325).Put("spk", spk_5326).Put("rx", ((V)(28D))).Put("ya", ((V)(30D))).Put("yb", ((V)(76D))).Put("rT", Fn((V _arrowThis5408, int _argc5401, V y_5407, V _a5404, V _a5405, V _a5406, V[] _rest5402) => {
return ((V)(System.Math.Sqrt(Max(0D, ((R_5309 * R_5309) - ((ToNum(y_5407) - ToNum(GetIdx(C_5308, 1D))) * (ToNum(y_5407) - ToNum(GetIdx(C_5308, 1D)))))))));
}, 1, "rT", true)).Put("zE", Fn((V _arrowThis5417, int _argc5409, V dx_5415, V dy_5416, V _a5413, V _a5414, V[] _rest5410) => {
return ((V)((System.Math.Sqrt(Max(0D, (((R_5309 * R_5309) - (ToNum(dx_5415) * ToNum(dx_5415))) - (ToNum(dy_5416) * ToNum(dy_5416))))) + 0.3)));
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self5418, int _argc5419, V B_5425, V D_5426, V _a5423, V _a5424, V[] _rest5420) => {
V P3_5427 = default;
V Z3_5428 = default;
V set_5429 = default;
V C_5430 = default;
V R_5431 = default;
V fl_5432 = default;
double sw_5433 = 0;
V ts_5434 = default;
V sp_5435 = default;
JsStrBuf sd_5436 = null;
V L_5437 = default;
V S3_5438 = default;
V wl_5439 = default;
JsStrBuf kd_5440 = null;
if (_self5418.IsNullish) _self5418 = GlobalV;
{ V _t5441 = D_5426;
if (_t5441.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t5441));
{ V _t5442 = Get(_t5441, "P3");
P3_5427 = _t5442; }
{ V _t5443 = Get(_t5441, "Z3");
Z3_5428 = _t5443; }
{ V _t5444 = Get(_t5441, "set");
set_5429 = _t5444; } }
{ V _t5445 = B_5425;
if (_t5445.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t5445));
{ V _t5446 = Get(_t5445, "C");
C_5430 = _t5446; }
{ V _t5447 = Get(_t5445, "R");
R_5431 = _t5447; } }
fl_5432 = Call(clamp_12, V.Undef, Invoke(D_5426, "bv", ((V)("fluff"))), ((V)(0D)), ((V)(1.6)));
sw_5433 = (ToNum(Invoke(D_5426, "bv", ((V)("swirl")))) * TAU_9);
ts_5434 = Get(D_5426, "ts");
sp_5435 = Arr();
{
double i_5448 = 0;
i_5448 = 0D;
while (true) {
if (!((i_5448 <= 8D))) break;
double th_5450 = 0;
double cr_5451 = 0;
th_5450 = (((-System.Math.PI) / 2D) + ((System.Math.PI * i_5448) / 8D));
cr_5451 = FdLibm.Cos(th_5450);
{
double k_5452 = 0;
k_5452 = 0D;
while (true) {
if (!((k_5452 < 20D))) break;
double f_5454 = 0;
f_5454 = ((k_5452 / 20D) * TAU_9);
Invoke(sp_5435, "push", Call(P3_5427, V.Undef, Add(GetIdx(C_5430, 0D), ((V)(((ToNum(R_5431) * cr_5451) * FdLibm.Sin(f_5454))))), Add(GetIdx(C_5430, 1D), ((V)((ToNum(R_5431) * FdLibm.Sin(th_5450))))), ((V)(((ToNum(R_5431) * cr_5451) * FdLibm.Cos(f_5454))))));
k_5452++;
}
}
i_5448++;
}
}
Set(B_5425, "d", Invoke(D_5426, "hull", sp_5435));
Call(set_5429, V.Undef, Get(B_5425, "stick"), ((V)("d")), Invoke(Get(SN_43, "h"), "tubeD", D_5426, Arr(Arr(((V)(50D)), ((V)(76D)), ((V)(0D))), Arr(((V)(50D)), ((V)(97.4)), ((V)(0D)))), Arr(((V)(3.7)), ((V)(3.3)))));
sd_5436 = new JsStrBuf("");
Invoke(Arr(((V)(80D)), ((V)(85.5)), ((V)(91D)), ((V)(96D))), "forEach", Fn((V _arrowThis5462, int _argc5455, V y0_5461, V _a5458, V _a5459, V _a5460, V[] _rest5456) => {
V Q_5463 = default;
V ok_5464 = default;
Q_5463 = Arr();
ok_5464 = Arr();
{
double j_5465 = 0;
j_5465 = 0D;
while (true) {
if (!((j_5465 <= 8D))) break;
double a_5467 = 0;
V y_5468 = default;
double r_5469 = 0;
a_5467 = ((-1.4) + ((j_5465 / 8D) * 2.8));
y_5468 = Add(y0_5461, ((V)((j_5465 * 0.42))));
r_5469 = 3.75;
Invoke(Q_5463, "push", Call(P3_5427, V.Undef, ((V)((50D + (r_5469 * FdLibm.Sin(a_5467))))), y_5468, ((V)((r_5469 * FdLibm.Cos(a_5467))))));
Invoke(ok_5464, "push", (GtN(Invoke(D_5426, "facing", ((V)((50D + (r_5469 * FdLibm.Sin(a_5467))))), y_5468, ((V)((r_5469 * FdLibm.Cos(a_5467)))), ((V)(FdLibm.Sin(a_5467))), ((V)(0D)), ((V)(FdLibm.Cos(a_5467)))), 0D) ? V.True : V.False));
j_5465++;
}
}
sd_5436.V(Call(runs_21, V.Undef, Q_5463, ok_5464));
return default;
}, 1, "", true));
Call(set_5429, V.Undef, Get(B_5425, "sts"), ((V)("d")), (((V)(sd_5436.Str)) is var _t5470 && Truthy(_t5470) ? _t5470 : ((V)("M0 0"))));
L_5437 = Invoke(Invoke(Get(B_5425, "PU"), "map", Fn((V _arrowThis5488, int _argc5480, V o_5486, V i_5487, V _a5484, V _a5485, V[] _rest5481) => {
double ca_5489 = 0;
double sa_5490 = 0;
double dx_5491 = 0;
double dz_5492 = 0;
double rho_5493 = 0;
V up_5494 = default;
V x_5495 = default;
double y_5496 = 0;
double z_5497 = 0;
V c_5498 = default;
V zz_5499 = default;
ca_5489 = FdLibm.Cos(sw_5433);
sa_5490 = FdLibm.Sin(sw_5433);
dx_5491 = ((ToNum(GetIdx(Get(o_5486, "d"), 0D)) * ca_5489) + (ToNum(GetIdx(Get(o_5486, "d"), 2D)) * sa_5490));
dz_5492 = (((-ToNum(GetIdx(Get(o_5486, "d"), 0D))) * sa_5490) + (ToNum(GetIdx(Get(o_5486, "d"), 2D)) * ca_5489));
rho_5493 = ((ToNum(Get(o_5486, "rho")) * (1D + (ToNum(fl_5432) * 0.1))) + (FdLibm.Sin(ToNum(Add(((V)((ToNum(ts_5434) * 1.3))), i_5487))) * 0.4));
up_5494 = Call(clamp_12, V.Undef, ((V)((-ToNum(GetIdx(Get(o_5486, "d"), 1D))))), ((V)(0D)), ((V)(1D)));
x_5495 = Add(Add(GetIdx(C_5430, 0D), ((V)((rho_5493 * dx_5491)))), ((V)(((ToNum(Get(D_5426, "ox")) * 0.2) * ToNum(up_5494)))));
y_5496 = (ToNum(Add(GetIdx(C_5430, 1D), ((V)((rho_5493 * ToNum(GetIdx(Get(o_5486, "d"), 1D))))))) - ((ToNum(Get(D_5426, "oy")) * 0.25) * ToNum(up_5494)));
z_5497 = (rho_5493 * dz_5492);
c_5498 = Call(P3_5427, V.Undef, x_5495, ((V)(y_5496)), ((V)(z_5497)));
zz_5499 = Call(Z3_5428, V.Undef, x_5495, ((V)(y_5496)), ((V)(z_5497)));
Call(set_5429, V.Undef, Get(o_5486, "e"), ((V)("d")), Call(circD_19, V.Undef, c_5498, ((V)(((ToNum(Get(o_5486, "r")) * (1D + (ToNum(fl_5432) * 0.22))) * ToNum(Get(D_5426, "kS")))))));
return NewObj(3).Put("id", Get(o_5486, "id")).Put("e", Get(o_5486, "e")).Put("z", zz_5499).V;
return default;
}, 2, "", true)), "sort", Fn((V _arrowThis5479, int _argc5471, V a_5477, V b_5478, V _a5475, V _a5476, V[] _rest5472) => {
return ((V)((ToNum(Get(a_5477, "z")) - ToNum(Get(b_5478, "z")))));
}, 2, "", true));
Invoke(L_5437, "forEach", Fn((V _arrowThis5507, int _argc5500, V l_5506, V _a5503, V _a5504, V _a5505, V[] _rest5501) => {
V tg_5508 = default;
tg_5508 = (GtN(Get(l_5506, "z"), 6D) ? Get(B_5425, "FG") : Get(B_5425, "BG"));
if (!SEq(Get(Get(l_5506, "e"), "parentNode"), tg_5508)) {
Invoke(tg_5508, "appendChild", Get(l_5506, "e"));
}
return default;
}, 1, "", true));
Invoke(SN_43, "order", Get(B_5425, "BG"), Invoke(L_5437, "filter", Fn((V _arrowThis5516, int _argc5509, V l_5515, V _a5512, V _a5513, V _a5514, V[] _rest5510) => {
return (LeN(Get(l_5515, "z"), 6D) ? V.True : V.False);
}, 1, "", true)));
Invoke(SN_43, "order", Get(B_5425, "FG"), Invoke(L_5437, "filter", Fn((V _arrowThis5524, int _argc5517, V l_5523, V _a5520, V _a5521, V _a5522, V[] _rest5518) => {
return (GtN(Get(l_5523, "z"), 6D) ? V.True : V.False);
}, 1, "", true)));
S3_5438 = Fn((V _arrowThis5533, int _argc5525, V x_5531, V y_5532, V _a5529, V _a5530, V[] _rest5526) => {
double dz_5534 = 0;
dz_5534 = System.Math.Sqrt(Max(0D, (((ToNum(R_5431) * ToNum(R_5431)) - ((ToNum(x_5531) - ToNum(GetIdx(C_5430, 0D))) * (ToNum(x_5531) - ToNum(GetIdx(C_5430, 0D))))) - ((ToNum(y_5532) - ToNum(GetIdx(C_5430, 1D))) * (ToNum(y_5532) - ToNum(GetIdx(C_5430, 1D)))))));
return Arr(Call(P3_5427, V.Undef, x_5531, y_5532, ((V)((dz_5534 + 0.2)))), (GtN(Invoke(D_5426, "facing", x_5531, y_5532, ((V)(dz_5534)), ((V)((ToNum(x_5531) - ToNum(GetIdx(C_5430, 0D))))), ((V)((ToNum(y_5532) - ToNum(GetIdx(C_5430, 1D))))), ((V)(dz_5534))), 0.5) ? V.True : V.False));
return default;
}, 2, "", true);
wl_5439 = Fn((V _arrowThis5542, int _argc5535, V pts_5541, V _a5538, V _a5539, V _a5540, V[] _rest5536) => {
V Q_5543 = default;
Q_5543 = Invoke(pts_5541, "map", Fn((V _arrowThis5551, int _argc5544, V p_5550, V _a5547, V _a5548, V _a5549, V[] _rest5545) => {
return Call(S3_5438, V.Undef, GetIdx(p_5550, 0D), GetIdx(p_5550, 1D));
}, 1, "", true));
return Call(runs_21, V.Undef, Invoke(Q_5543, "map", Fn((V _arrowThis5559, int _argc5552, V q_5558, V _a5555, V _a5556, V _a5557, V[] _rest5553) => {
return GetIdx(q_5558, 0D);
}, 1, "", true)), Invoke(Q_5543, "map", Fn((V _arrowThis5567, int _argc5560, V q_5566, V _a5563, V _a5564, V _a5565, V[] _rest5561) => {
return GetIdx(q_5566, 1D);
}, 1, "", true)));
return default;
}, 1, "", true);
Call(set_5429, V.Undef, Get(B_5425, "wisp"), ((V)("d")), (Call(wl_5439, V.Undef, Arr(Arr(((V)(33D)), ((V)(40D))), Arr(((V)(38D)), ((V)(36D))), Arr(((V)(44D)), ((V)(34.5))), Arr(((V)(50D)), ((V)(35.5))), Arr(((V)(56D)), ((V)(37.5))), Arr(((V)(61D)), ((V)(37D))), Arr(((V)(66D)), ((V)(34D))))) is var _t5568 && Truthy(_t5568) ? _t5568 : ((V)("M0 0"))));
Call(set_5429, V.Undef, Get(B_5425, "wisp2"), ((V)("d")), (Call(wl_5439, V.Undef, Arr(Arr(((V)(28D)), ((V)(70D))), Arr(((V)(33D)), ((V)(73D))), Arr(((V)(38D)), ((V)(74.5))), Arr(((V)(43D)), ((V)(73D))), Arr(((V)(47D)), ((V)(71D))))) is var _t5569 && Truthy(_t5569) ? _t5569 : ((V)("M0 0"))));
kd_5440 = new JsStrBuf("");
Invoke(Arr(Arr(((V)(24D)), ((V)(20D)), ((V)(0D))), Arr(((V)(78D)), ((V)(16D)), ((V)(1.7))), Arr(((V)(88D)), ((V)(36D)), ((V)(3.1)))), "forEach", Fn((V _arrowThis5583, int _argc5570, V _a5572, V _a5573, V _a5574, V _a5575, V[] _rest5571) => {
double a_5584 = 0;
double s_5585 = 0;
V p_5586 = default;
V x_5578 = default;
V y_5580 = default;
V ph_5582 = default;
{ V _t5576 = ListOf(_a5572);
{ V _t5577 = GetIdx(_t5576, 0D);
x_5578 = _t5577; }
{ V _t5579 = GetIdx(_t5576, 1D);
y_5580 = _t5579; }
{ V _t5581 = GetIdx(_t5576, 2D);
ph_5582 = _t5581; }
}
a_5584 = Max(0D, FdLibm.Sin(ToNum(Add(((V)((ToNum(ts_5434) * 2.1))), ph_5582))));
s_5585 = ((1.2 + (1.4 * a_5584)) * ToNum(Get(D_5426, "kS")));
p_5586 = Call(P3_5427, V.Undef, x_5578, y_5580, ((V)(0D)));
if ((a_5584 > 0.05)) {
kd_5440.S("M").V(Call(r2_11, V.Undef, GetIdx(p_5586, 0D))).S(" ").V(Call(r2_11, V.Undef, ((V)((ToNum(GetIdx(p_5586, 1D)) - s_5585))))).S("L").V(Call(r2_11, V.Undef, Add(GetIdx(p_5586, 0D), ((V)((s_5585 * 0.3)))))).S(" ").V(Call(r2_11, V.Undef, ((V)((ToNum(GetIdx(p_5586, 1D)) - (s_5585 * 0.3)))))).S("L").V(Call(r2_11, V.Undef, Add(GetIdx(p_5586, 0D), ((V)(s_5585))))).S(" ").V(Call(r2_11, V.Undef, GetIdx(p_5586, 1D))).S("L").V(Call(r2_11, V.Undef, Add(GetIdx(p_5586, 0D), ((V)((s_5585 * 0.3)))))).S(" ").V(Call(r2_11, V.Undef, Add(GetIdx(p_5586, 1D), ((V)((s_5585 * 0.3)))))).S("L").V(Call(r2_11, V.Undef, GetIdx(p_5586, 0D))).S(" ").V(Call(r2_11, V.Undef, Add(GetIdx(p_5586, 1D), ((V)(s_5585))))).S("L").V(Call(r2_11, V.Undef, ((V)((ToNum(GetIdx(p_5586, 0D)) - (s_5585 * 0.3)))))).S(" ").V(Call(r2_11, V.Undef, Add(GetIdx(p_5586, 1D), ((V)((s_5585 * 0.3)))))).S("L").V(Call(r2_11, V.Undef, ((V)((ToNum(GetIdx(p_5586, 0D)) - s_5585))))).S(" ").V(Call(r2_11, V.Undef, GetIdx(p_5586, 1D))).S("L").V(Call(r2_11, V.Undef, ((V)((ToNum(GetIdx(p_5586, 0D)) - (s_5585 * 0.3)))))).S(" ").V(Call(r2_11, V.Undef, ((V)((ToNum(GetIdx(p_5586, 1D)) - (s_5585 * 0.3)))))).S("Z");
}
return default;
}, 1, "", true));
Call(set_5429, V.Undef, Get(B_5425, "spk"), ((V)("d")), (((V)(kd_5440.Str)) is var _t5587 && Truthy(_t5587) ? _t5587 : ((V)("M0 0"))));
return default;
}, 2, "draw", false)).V);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
