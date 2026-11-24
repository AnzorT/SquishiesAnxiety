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
V TAU_9 = default;
V D2R_10 = default;
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
TAU_9 = ((V)((System.Math.PI * 2D)));
D2R_10 = ((V)((System.Math.PI / 180D)));
r2_11 = Fn((V _self1, int _argc50, V v_56, V _a53, V _a54, V _a55, V[] _rest51) => {
return ((V)((Round((ToNum(v_56) * 100D)) / 100D)));
}, 1, "", true);
clamp_12 = Fn((V _self1, int _argc57, V v_63, V a_64, V b_65, V _a62, V[] _rest58) => {
return (Lt(v_63, a_64) ? a_64 : (Gt(v_63, b_65) ? b_65 : v_63));
}, 3, "", true);
SM_13 = Fn((V _self1, int _argc66, V t_72, V _a69, V _a70, V _a71, V[] _rest67) => {
t_72 = Call(clamp_12, V.Undef, t_72, ((V)(0D)), ((V)(1D)));
return ((V)(((ToNum(t_72) * ToNum(t_72)) * (3D - (2D * ToNum(t_72))))));
return default;
}, 1, "", true);
el_14 = Fn((V _self1, int _argc73, V tag_79, V a_80, V par_81, V before_82, V[] _rest74) => {
V e_83 = default;
e_83 = Invoke(G("document"), "createElementNS", NS_8, tag_79);
{
foreach (V _k84 in ForInKeys(a_80)) {
V k_85 = default;
k_85 = _k84;
Invoke(e_83, "setAttribute", k_85, GetK(a_80, k_85));
}
}
if (Truthy(par_81)) {
if (Truthy(before_82)) {
Invoke(par_81, "insertBefore", e_83, before_82);
} else {
Invoke(par_81, "appendChild", e_83);
}
}
return e_83;
return default;
}, 4, "", true);
pt_15 = Fn((V _self1, int _argc86, V p_92, V _a89, V _a90, V _a91, V[] _rest87) => {
return ((V)(string.Concat(ToStr(Call(r2_11, V.Undef, GetIdx(p_92, 0D))), " ", ToStr(Call(r2_11, V.Undef, GetIdx(p_92, 1D))))));
}, 1, "", true);
polyD_16 = Fn((V _self1, int _argc93, V Q_99, V _a96, V _a97, V _a98, V[] _rest94) => {
return ((V)((GtN(Get(Q_99, "length"), 2D) ? string.Concat("M", ToStr(Invoke(Invoke(Q_99, "map", pt_15), "join", ((V)("L")))), "Z") : "")));
}, 1, "", true);
area_17 = Fn((V _self1, int _argc100, V Q_106, V _a103, V _a104, V _a105, V[] _rest101) => {
V a_107 = default;
a_107 = ((V)(0D));
{
V i_108 = default;
i_108 = ((V)(0D));
while (true) {
if (!(Lt(i_108, Get(Q_106, "length")))) break;
V p_110 = default;
V q_111 = default;
p_110 = GetK(Q_106, i_108);
q_111 = GetIdx(Q_106, (ToNum(Add(i_108, ((V)(1D)))) % ToNum(Get(Q_106, "length"))));
a_107 = Add(a_107, ((V)(((ToNum(GetIdx(p_110, 0D)) * ToNum(GetIdx(q_111, 1D))) - (ToNum(GetIdx(q_111, 0D)) * ToNum(GetIdx(p_110, 1D)))))));
PostInc(ref i_108, 1D);
}
}
return ((V)((ToNum(a_107) / 2D)));
return default;
}, 1, "", true);
polyW_18 = Fn((V _self1, int _argc112, V Q_118, V _a115, V _a116, V _a117, V[] _rest113) => {
V a_119 = default;
if (LtN(Get(Q_118, "length"), 3D)) {
return ((V)(""));
}
a_119 = Call(area_17, V.Undef, Q_118);
if ((System.Math.Abs(ToNum(a_119)) < 0.02)) {
return ((V)(""));
}
return Call(polyD_16, V.Undef, (GtN(a_119, 0D) ? Invoke(Invoke(Q_118, "slice"), "reverse") : Q_118));
return default;
}, 1, "", true);
circD_19 = Fn((V _self1, int _argc120, V c_126, V r_127, V _a124, V _a125, V[] _rest121) => {
return ((V)(string.Concat(new string[] { "M", ToStr(Call(r2_11, V.Undef, ((V)((ToNum(GetIdx(c_126, 0D)) - ToNum(r_127)))))), " ", ToStr(Call(r2_11, V.Undef, GetIdx(c_126, 1D))), "a", ToStr(Call(r2_11, V.Undef, r_127)), " ", ToStr(Call(r2_11, V.Undef, r_127)), " 0 1 0 ", ToStr(Call(r2_11, V.Undef, ((V)((2D * ToNum(r_127)))))), " 0a", ToStr(Call(r2_11, V.Undef, r_127)), " ", ToStr(Call(r2_11, V.Undef, r_127)), " 0 1 0 ", ToStr(Call(r2_11, V.Undef, ((V)(((-2D) * ToNum(r_127)))))), " 0Z" })));
}, 2, "", true);
ellD_20 = Fn((V _self1, int _argc128, V c_134, V rx_135, V ry_136, V a_137, V[] _rest129) => {
V o_138 = default;
V ca_139 = default;
V sa_140 = default;
o_138 = Arr();
ca_139 = ((V)(FdLibm.Cos(ToNum((a_137 is var _t141 && Truthy(_t141) ? _t141 : ((V)(0D)))))));
sa_140 = ((V)(FdLibm.Sin(ToNum((a_137 is var _t142 && Truthy(_t142) ? _t142 : ((V)(0D)))))));
{
V k_143 = default;
k_143 = ((V)(0D));
while (true) {
if (!(LtN(k_143, 16D))) break;
V f_145 = default;
V x_146 = default;
V y_147 = default;
f_145 = ((V)(((ToNum(k_143) / 16D) * ToNum(TAU_9))));
x_146 = ((V)((ToNum(rx_135) * FdLibm.Cos(ToNum(f_145)))));
y_147 = ((V)((ToNum(ry_136) * FdLibm.Sin(ToNum(f_145)))));
Invoke(o_138, "push", Arr(((V)((ToNum(Add(GetIdx(c_134, 0D), ((V)((ToNum(x_146) * ToNum(ca_139)))))) - (ToNum(y_147) * ToNum(sa_140))))), Add(Add(GetIdx(c_134, 1D), ((V)((ToNum(x_146) * ToNum(sa_140))))), ((V)((ToNum(y_147) * ToNum(ca_139)))))));
PostInc(ref k_143, 1D);
}
}
return Call(polyW_18, V.Undef, o_138);
return default;
}, 4, "", true);
runs_21 = Fn((V _self1, int _argc148, V pts_154, V ok_155, V _a152, V _a153, V[] _rest149) => {
V d_156 = default;
V pen_157 = default;
d_156 = ((V)(""));
pen_157 = (false ? V.True : V.False);
{
V i_158 = default;
i_158 = ((V)(0D));
while (true) {
if (!(Lt(i_158, Get(pts_154, "length")))) break;
if (Truthy(GetK(ok_155, i_158))) {
d_156 = ((V)(string.Concat(ToStr(d_156), (Truthy(pen_157) ? "L" : "M"), ToStr(Call(pt_15, V.Undef, GetK(pts_154, i_158))))));
pen_157 = (true ? V.True : V.False);
} else {
pen_157 = (false ? V.True : V.False);
}
PostInc(ref i_158, 1D);
}
}
return d_156;
return default;
}, 2, "", true);
rnd_22 = Fn((V _self1, int _argc160, V s_166, V _a163, V _a164, V _a165, V[] _rest161) => {
V v_167 = default;
v_167 = ((V)((FdLibm.Sin(((ToNum(s_166) * 127.1) + 311.7)) * 43758.5453)));
return ((V)((ToNum(v_167) - System.Math.Floor(ToNum(v_167)))));
return default;
}, 1, "", true);
subs_23 = Fn((V _self1, int _argc168, V segs_174, V n_175, V _a172, V _a173, V[] _rest169) => {
V @out_176 = default;
V cur_177 = default;
V p_178 = default;
@out_176 = Arr();
cur_177 = V.Null;
p_178 = Arr(((V)(0D)), ((V)(0D)));
{
foreach (V _k179 in Iterate(segs_174)) {
V g_180 = default;
g_180 = _k179;
V c_181 = default;
c_181 = Get(g_180, "c");
if (SEqS(c_181, "M")) {
cur_177 = Arr(GetIdx(Get(g_180, "p"), 0D));
Invoke(@out_176, "push", cur_177);
p_178 = GetIdx(Get(g_180, "p"), 0D);
} else {
if (SEqS(c_181, "Z")) {
if (Truthy(cur_177)) {
Set(cur_177, "closed", ((V)(1D)));
}
} else {
if (!(Truthy(cur_177))) {
continue;
} else {
if ((SEqS(c_181, "L") || SEqS(c_181, "T"))) {
Invoke(cur_177, "push", GetIdx(Get(g_180, "p"), 0D));
p_178 = GetIdx(Get(g_180, "p"), 0D);
} else {
if ((SEqS(c_181, "Q") || SEqS(c_181, "S"))) {
V a_182 = default;
V b_183 = default;
a_182 = GetIdx(Get(g_180, "p"), 0D);
b_183 = GetIdx(Get(g_180, "p"), 1D);
{
V k_184 = default;
k_184 = ((V)(1D));
while (true) {
if (!(Le(k_184, n_175))) break;
V t_186 = default;
V u_187 = default;
t_186 = ((V)((ToNum(k_184) / ToNum(n_175))));
u_187 = ((V)((1D - ToNum(t_186))));
Invoke(cur_177, "push", Arr(((V)(((((ToNum(u_187) * ToNum(u_187)) * ToNum(GetIdx(p_178, 0D))) + (((2D * ToNum(u_187)) * ToNum(t_186)) * ToNum(GetIdx(a_182, 0D)))) + ((ToNum(t_186) * ToNum(t_186)) * ToNum(GetIdx(b_183, 0D)))))), ((V)(((((ToNum(u_187) * ToNum(u_187)) * ToNum(GetIdx(p_178, 1D))) + (((2D * ToNum(u_187)) * ToNum(t_186)) * ToNum(GetIdx(a_182, 1D)))) + ((ToNum(t_186) * ToNum(t_186)) * ToNum(GetIdx(b_183, 1D))))))));
PostInc(ref k_184, 1D);
}
}
p_178 = b_183;
} else {
if (SEqS(c_181, "C")) {
V a_188 = default;
V b_189 = default;
V e_190 = default;
a_188 = GetIdx(Get(g_180, "p"), 0D);
b_189 = GetIdx(Get(g_180, "p"), 1D);
e_190 = GetIdx(Get(g_180, "p"), 2D);
{
V k_191 = default;
k_191 = ((V)(1D));
while (true) {
if (!(Le(k_191, n_175))) break;
V t_193 = default;
V u_194 = default;
t_193 = ((V)((ToNum(k_191) / ToNum(n_175))));
u_194 = ((V)((1D - ToNum(t_193))));
Invoke(cur_177, "push", Arr(((V)(((((((ToNum(u_194) * ToNum(u_194)) * ToNum(u_194)) * ToNum(GetIdx(p_178, 0D))) + ((((3D * ToNum(u_194)) * ToNum(u_194)) * ToNum(t_193)) * ToNum(GetIdx(a_188, 0D)))) + ((((3D * ToNum(u_194)) * ToNum(t_193)) * ToNum(t_193)) * ToNum(GetIdx(b_189, 0D)))) + (((ToNum(t_193) * ToNum(t_193)) * ToNum(t_193)) * ToNum(GetIdx(e_190, 0D)))))), ((V)(((((((ToNum(u_194) * ToNum(u_194)) * ToNum(u_194)) * ToNum(GetIdx(p_178, 1D))) + ((((3D * ToNum(u_194)) * ToNum(u_194)) * ToNum(t_193)) * ToNum(GetIdx(a_188, 1D)))) + ((((3D * ToNum(u_194)) * ToNum(t_193)) * ToNum(t_193)) * ToNum(GetIdx(b_189, 1D)))) + (((ToNum(t_193) * ToNum(t_193)) * ToNum(t_193)) * ToNum(GetIdx(e_190, 1D))))))));
PostInc(ref k_191, 1D);
}
}
p_178 = e_190;
}
}
}
}
}
}
}
}
return @out_176;
return default;
}, 2, "", true);
DA_24 = Arr(((V)("fill")), ((V)("stroke")), ((V)("stroke-width")), ((V)("opacity")), ((V)("stroke-linecap")), ((V)("stroke-linejoin")), ((V)("fill-opacity")), ((V)("stroke-opacity")));
inh_25 = Fn((V _self1, int _argc195, V e_201, V k_202, V _a199, V _a200, V[] _rest196) => {
{
V n_203 = default;
n_203 = e_201;
while (true) {
if (!(Truthy((n_203 is var _t205 && !Truthy(_t205) ? _t205 : Get(n_203, "getAttribute"))))) break;
V v_206 = default;
if (Truthy(((SEqS(Get(n_203, "tagName"), "g") ? V.True : V.False) is var _t207 && !Truthy(_t207) ? _t207 : Invoke(n_203, "hasAttribute", ((V)("filter")))))) {
break;
}
v_206 = Invoke(n_203, "getAttribute", k_202);
if ((!v_206.IsNullish && !(Truthy((((SEqS(k_202, "opacity") && !SEq(n_203, e_201)) ? V.True : V.False) is var _t208 && !Truthy(_t208) ? _t208 : Invoke(n_203, "hasAttribute", ((V)("data-k")))))))) {
return v_206;
}
n_203 = Get(n_203, "parentNode");
}
}
return V.Null;
return default;
}, 2, "", true);
decD_26 = Fn((V _self1, int _argc209, V o_215, V f_216, V _a213, V _a214, V[] _rest210) => {
return (Invoke(Invoke(Get(o_215, "L"), "map", Fn((V _self1, int _argc217, V L_223, V _a220, V _a221, V _a222, V[] _rest218) => {
return ((V)((GtN(Get(L_223, "length"), 1D) ? string.Concat("M", ToStr(Invoke(Invoke(L_223, "map", Fn((V _self1, int _argc224, V p_230, V _a227, V _a228, V _a229, V[] _rest225) => {
return Call(pt_15, V.Undef, Call(f_216, V.Undef, GetIdx(p_230, 0D), GetIdx(p_230, 1D)));
}, 1, "", true)), "join", ((V)("L")))), (Truthy(Get(L_223, "closed")) ? "Z" : "")) : "")));
}, 1, "", true)), "join", ((V)(""))) is var _t231 && Truthy(_t231) ? _t231 : ((V)("M0 0")));
}, 2, "", true);
LV_27 = Call(Fn((V _self1, int _argc232, V v_238, V _a235, V _a236, V _a237, V[] _rest233) => {
V L_239 = default;
L_239 = ((V)(Hypot(ToNum(GetIdx(v_238, 0D)), ToNum(GetIdx(v_238, 1D)), ToNum(GetIdx(v_238, 2D)))));
return Invoke(v_238, "map", Fn((V _self1, int _argc240, V c_246, V _a243, V _a244, V _a245, V[] _rest241) => {
return ((V)((ToNum(c_246) / ToNum(L_239))));
}, 1, "", true));
return default;
}, 1, "", true), V.Undef, Arr(((V)((-0.5))), ((V)((-0.55))), ((V)(0.67))));
pal_28 = Fn((V _self1, int _argc247, V dark_253, V mid_254, V light_255, V n_256, V[] _rest248) => {
V hx_257 = default;
V A_258 = default;
V M_259 = default;
V L_260 = default;
hx_257 = Fn((V _self1, int _argc261, V c_267, V _a264, V _a265, V _a266, V[] _rest262) => {
return Invoke(Arr(((V)(1D)), ((V)(3D)), ((V)(5D))), "map", Fn((V _self1, int _argc268, V i_274, V _a271, V _a272, V _a273, V[] _rest269) => {
return ((V)(ParseInt(Invoke(c_267, "slice", i_274, Add(i_274, ((V)(2D)))), ((V)(16D)))));
}, 1, "", true));
}, 1, "", true);
A_258 = Call(hx_257, V.Undef, dark_253);
M_259 = Call(hx_257, V.Undef, mid_254);
L_260 = Call(hx_257, V.Undef, light_255);
return Array_from(NewObj(1).Put("length", Add(n_256, ((V)(1D)))).V, Fn((V _self1, int _argc275, V __281, V i_282, V _a279, V _a280, V[] _rest276) => {
V t_283 = default;
V a_284 = default;
V b_285 = default;
V u_286 = default;
t_283 = ((V)((ToNum(i_282) / ToNum(n_256))));
a_284 = (LtN(t_283, 0.5) ? A_258 : M_259);
b_285 = (LtN(t_283, 0.5) ? M_259 : L_260);
u_286 = ((V)((LtN(t_283, 0.5) ? (ToNum(t_283) / 0.5) : ((ToNum(t_283) - 0.5) / 0.5))));
return ((V)(string.Concat("#", ToStr(Invoke(Invoke(a_284, "map", Fn((V _self1, int _argc287, V v_293, V k_294, V _a291, V _a292, V[] _rest288) => {
return Invoke(Invoke(((V)(Round(ToNum(Add(v_293, ((V)(((ToNum(GetK(b_285, k_294)) - ToNum(v_293)) * ToNum(u_286))))))))), "toString", ((V)(16D))), "padStart", ((V)(2D)), ((V)("0")));
}, 2, "", true)), "join", ((V)("")))))));
return default;
}, 2, "", true));
return default;
}, 4, "", true);
pleatSet_29 = Fn((V _self1, int _argc295, V sp_301, V par_302, V linePar_303, V _a300, V[] _rest296) => {
V F_304 = default;
V H_305 = default;
F_304 = Arr();
H_305 = ((V)((ToNum(TAU_9) / (2D * ToNum(Get(sp_301, "N"))))));
{
V k_306 = default;
k_306 = ((V)(0D));
while (true) {
if (!(Lt(k_306, Get(sp_301, "N")))) break;
V fg_308 = default;
V j_309 = default;
fg_308 = Add((Get(sp_301, "ph") is var _t310 && Truthy(_t310) ? _t310 : ((V)(0D))), ((V)(((ToNum(k_306) * ToNum(TAU_9)) / ToNum(Get(sp_301, "N"))))));
j_309 = ((V)(((ToNum(Call(rnd_22, V.Undef, ((V)((ToNum(k_306) * 1.7))))) - 0.5) * ToNum((Get(sp_301, "jit") is var _t311 && Truthy(_t311) ? _t311 : ((V)(0D)))))));
{
V side_312 = default;
side_312 = ((V)(0D));
while (true) {
if (!(LtN(side_312, 2D))) break;
Invoke(F_304, "push", NewObj(7).Put("side", side_312).Put("fa", (Truthy(side_312) ? Add(fg_308, H_305) : fg_308)).Put("fb", (Truthy(side_312) ? Add(fg_308, ((V)((2D * ToNum(H_305))))) : Add(fg_308, H_305))).Put("yge", Add(Get(sp_301, "yG"), ((V)((ToNum(j_309) * 0.5))))).Put("yre", Add(Get(sp_301, "yR"), j_309)).Put("id", ((V)(string.Concat("p", ToStr(k_306), "_", ToStr(side_312))))).Put("e", Call(el_14, V.Undef, ((V)("path")), NewObj(0).V, par_302)).V);
PostInc(ref side_312, 1D);
}
}
PostInc(ref k_306, 1D);
}
}
return NewObj(6).Put("sp", sp_301).Put("F", F_304).Put("H", H_305).Put("par", par_302).Put("ln", Call(el_14, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", Get(sp_301, "lc")).Put("stroke-width", Get(sp_301, "lw")).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.75))).V, (linePar_303 is var _t314 && Truthy(_t314) ? _t314 : Get(par_302, "parentNode")))).Put("PAL", Call(pal_28, V.Undef, GetIdx(Get(sp_301, "cols"), 0D), GetIdx(Get(sp_301, "cols"), 1D), GetIdx(Get(sp_301, "cols"), 2D), ((V)(24D)))).V;
return default;
}, 3, "", true);
pleatDraw_30 = Fn((V _self1, int _argc315, V D_321, V PS_322, V proj_323, V Z_324, V[] _rest316) => {
V sp_326 = default;
V F_327 = default;
V H_328 = default;
V rT_329 = default;
V y0_330 = default;
V yR_331 = default;
V tw_332 = default;
V dep_333 = default;
V U_334 = default;
V TW_335 = default;
V P3d_336 = default;
V gl_337 = default;
V lob_338 = default;
V L_339 = default;
V xt_325 = default;
xt_325 = (_argc315 > 4 ? _rest316[0] : V.Undef);
{ V _t340 = PS_322;
if (_t340.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t340));
{ V _t341 = Get(_t340, "sp");
sp_326 = _t341; }
{ V _t342 = Get(_t340, "F");
F_327 = _t342; }
{ V _t343 = Get(_t340, "H");
H_328 = _t343; } }
{ V _t344 = sp_326;
if (_t344.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t344));
{ V _t345 = Get(_t344, "rT");
rT_329 = _t345; }
{ V _t346 = Get(_t344, "y0");
y0_330 = _t346; }
{ V _t347 = Get(_t344, "yR");
yR_331 = _t347; }
{ V _t348 = Get(_t344, "tw");
tw_332 = _t348; }
{ V _t349 = Get(_t344, "dep");
dep_333 = _t349; } }
U_334 = Fn((V _self1, int _argc350, V y_356, V _a353, V _a354, V _a355, V[] _rest351) => {
return Call(clamp_12, V.Undef, ((V)(((ToNum(y_356) - ToNum(y0_330)) / (ToNum(yR_331) - ToNum(y0_330))))), ((V)(0D)), ((V)(1D)));
}, 1, "", true);
TW_335 = Fn((V _self1, int _argc357, V u_363, V _a360, V _a361, V _a362, V[] _rest358) => {
return Add(Call(tw_332, V.Undef, u_363), ((V)((ToNum(xt_325) * (1D - ToNum(u_363))))));
}, 1, "", true);
P3d_336 = Fn((V _self1, int _argc364, V f_370, V y_371, V ridge_372, V _a369, V[] _rest365) => {
V u_373 = default;
V ff_374 = default;
V r_375 = default;
u_373 = Call(U_334, V.Undef, y_371);
ff_374 = Add(f_370, Call(TW_335, V.Undef, u_373));
r_375 = Add(Call(rT_329, V.Undef, y_371), (Truthy(ridge_372) ? Call(dep_333, V.Undef, u_373) : ((V)((-0.25)))));
return Call(proj_323, V.Undef, ((V)((50D + (ToNum(r_375) * FdLibm.Sin(ToNum(ff_374)))))), y_371, ((V)((ToNum(r_375) * FdLibm.Cos(ToNum(ff_374))))));
return default;
}, 3, "", true);
gl_337 = ((V)(""));
lob_338 = ((V)(""));
L_339 = Arr();
Invoke(F_327, "forEach", Fn((V _self1, int _argc376, V o_382, V _a379, V _a380, V _a381, V[] _rest377) => {
V um_383 = default;
V ym_384 = default;
V fm_385 = default;
V rm_386 = default;
V be_387 = default;
V az_388 = default;
V g_389 = default;
V n_390 = default;
V m_391 = default;
V fz_392 = default;
V p0_393 = default;
V p1_394 = default;
V sx_395 = default;
V sy_396 = default;
V ln_397 = default;
V b_398 = default;
V ra_399 = default;
V rb_400 = default;
V ea_401 = default;
V eb_402 = default;
V A_403 = default;
V B_404 = default;
V lo_405 = default;
V c_406 = default;
um_383 = ((V)(0.45));
ym_384 = Add(y0_330, ((V)(((ToNum(yR_331) - ToNum(y0_330)) * ToNum(um_383)))));
fm_385 = Add(((V)((ToNum(Add(Get(o_382, "fa"), Get(o_382, "fb"))) / 2D))), Call(TW_335, V.Undef, um_383));
rm_386 = Call(rT_329, V.Undef, ym_384);
be_387 = ((V)((FdLibm.Atan2(ToNum(Add(Call(dep_333, V.Undef, um_383), ((V)(0.25)))), (ToNum(rm_386) * ToNum(H_328))) * (Truthy(Get(o_382, "side")) ? 1D : (-1D)))));
az_388 = Add(fm_385, be_387);
g_389 = ((V)(FdLibm.Atan(((ToNum(Call(rT_329, V.Undef, Add(ym_384, ((V)(1D))))) - ToNum(Call(rT_329, V.Undef, ((V)((ToNum(ym_384) - 1D)))))) / 2D))));
n_390 = Arr(((V)((FdLibm.Sin(ToNum(az_388)) * FdLibm.Cos(ToNum(g_389))))), ((V)((-FdLibm.Sin(ToNum(g_389))))), ((V)((FdLibm.Cos(ToNum(az_388)) * FdLibm.Cos(ToNum(g_389))))));
m_391 = Arr(((V)((50D + (ToNum(rm_386) * FdLibm.Sin(ToNum(fm_385)))))), ym_384, ((V)((ToNum(rm_386) * FdLibm.Cos(ToNum(fm_385))))));
fz_392 = Invoke(D_321, "facing", GetIdx(m_391, 0D), GetIdx(m_391, 1D), GetIdx(m_391, 2D), GetIdx(n_390, 0D), GetIdx(n_390, 1D), GetIdx(n_390, 2D));
if (LeN(fz_392, 0.02)) {
if (!SEqN(Get(o_382, "on"), 0D)) {
Set(o_382, "on", ((V)(0D)));
Invoke(Get(o_382, "e"), "setAttribute", ((V)("d")), ((V)("M0 0")));
}
return default;
}
Set(o_382, "on", ((V)(1D)));
p0_393 = Call(proj_323, V.Undef, GetIdx(m_391, 0D), GetIdx(m_391, 1D), GetIdx(m_391, 2D));
p1_394 = Call(proj_323, V.Undef, Add(GetIdx(m_391, 0D), GetIdx(n_390, 0D)), Add(GetIdx(m_391, 1D), GetIdx(n_390, 1D)), Add(GetIdx(m_391, 2D), GetIdx(n_390, 2D)));
sx_395 = ((V)(((ToNum(GetIdx(p1_394, 0D)) - ToNum(GetIdx(p0_393, 0D))) / ToNum(Get(D_321, "kS")))));
sy_396 = ((V)(((ToNum(GetIdx(p1_394, 1D)) - ToNum(GetIdx(p0_393, 1D))) / ToNum(Get(D_321, "kS")))));
ln_397 = (((V)(Hypot(ToNum(sx_395), ToNum(sy_396), ToNum(fz_392)))) is var _t407 && Truthy(_t407) ? _t407 : ((V)(1D)));
b_398 = ((V)(((((ToNum(sx_395) * ToNum(GetIdx(LV_27, 0D))) + (ToNum(sy_396) * ToNum(GetIdx(LV_27, 1D)))) + (ToNum(fz_392) * ToNum(GetIdx(LV_27, 2D)))) / ToNum(ln_397))));
ra_399 = (SEqN(Get(o_382, "side"), 1D) ? V.True : V.False);
rb_400 = (SEqN(Get(o_382, "side"), 0D) ? V.True : V.False);
ea_401 = (Truthy(ra_399) ? Get(o_382, "yre") : Get(o_382, "yge"));
eb_402 = (Truthy(rb_400) ? Get(o_382, "yre") : Get(o_382, "yge"));
A_403 = Arr();
B_404 = Arr();
lo_405 = Arr();
{
V i_408 = default;
i_408 = ((V)(0D));
while (true) {
if (!(LeN(i_408, 10D))) break;
Invoke(A_403, "push", Call(P3d_336, V.Undef, Get(o_382, "fa"), Add(y0_330, ((V)((((ToNum(ea_401) - ToNum(y0_330)) * ToNum(i_408)) / 10D)))), ra_399));
Invoke(B_404, "push", Call(P3d_336, V.Undef, Get(o_382, "fb"), Add(y0_330, ((V)((((ToNum(eb_402) - ToNum(y0_330)) * ToNum(i_408)) / 10D)))), rb_400));
PostInc(ref i_408, 1D);
}
}
{
V i_410 = default;
i_410 = ((V)(1D));
while (true) {
if (!(LeN(i_410, 5D))) break;
V t_412 = default;
V f_413 = default;
V s_414 = default;
V y_415 = default;
V u_416 = default;
V r_417 = default;
V ff_418 = default;
t_412 = ((V)((ToNum(i_410) / 6D)));
f_413 = Add(Get(o_382, "fa"), ((V)(((ToNum(Get(o_382, "fb")) - ToNum(Get(o_382, "fa"))) * ToNum(t_412)))));
s_414 = ((V)(FdLibm.Sin(((ToNum((Truthy(Get(o_382, "side")) ? ((V)((1D - ToNum(t_412)))) : t_412)) * System.Math.PI) / 2D))));
y_415 = Add(Get(o_382, "yge"), ((V)(((ToNum(Get(o_382, "yre")) - ToNum(Get(o_382, "yge"))) * ToNum(s_414)))));
u_416 = Call(U_334, V.Undef, y_415);
r_417 = ((V)(((ToNum(Call(rT_329, V.Undef, y_415)) - 0.25) + (ToNum(Add(Call(dep_333, V.Undef, u_416), ((V)(0.25)))) * ToNum(s_414)))));
ff_418 = Add(f_413, Call(TW_335, V.Undef, u_416));
Invoke(lo_405, "push", Call(proj_323, V.Undef, ((V)((50D + (ToNum(r_417) * FdLibm.Sin(ToNum(ff_418)))))), y_415, ((V)((ToNum(r_417) * FdLibm.Cos(ToNum(ff_418)))))));
PostInc(ref i_410, 1D);
}
}
Invoke(Get(o_382, "e"), "setAttribute", ((V)("d")), Call(polyD_16, V.Undef, Invoke(A_403, "concat", lo_405, Invoke(Invoke(B_404, "slice"), "reverse"))));
c_406 = GetIdx(Get(PS_322, "PAL"), Round((ToNum(Call(clamp_12, V.Undef, ((V)((0.3 + (0.95 * ToNum(b_398))))), ((V)(0D)), ((V)(1D)))) * 24D)));
if (!SEq(Get(o_382, "c"), c_406)) {
Set(o_382, "c", c_406);
Invoke(Get(o_382, "e"), "setAttribute", ((V)("fill")), c_406);
}
if (!(Truthy(Get(o_382, "side")))) {
gl_337 = ((V)(string.Concat(ToStr(gl_337), "M", ToStr(Invoke(Invoke(A_403, "map", pt_15), "join", ((V)("L")))))));
}
if (Truthy(Get(sp_326, "lobe"))) {
lob_338 = ((V)(string.Concat(ToStr(lob_338), "M", ToStr(Invoke(Invoke(lo_405, "map", Fn((V _self1, int _argc419, V p_425, V _a422, V _a423, V _a424, V[] _rest420) => {
return Call(pt_15, V.Undef, Arr(GetIdx(p_425, 0D), Add(GetIdx(p_425, 1D), ((V)((0.7 * ToNum(Get(D_321, "kS"))))))));
}, 1, "", true)), "join", ((V)("L")))))));
}
Invoke(L_339, "push", NewObj(3).Put("id", Get(o_382, "id")).Put("e", Get(o_382, "e")).Put("z", Call(Z_324, V.Undef, GetIdx(m_391, 0D), GetIdx(m_391, 1D), GetIdx(m_391, 2D))).V);
return default;
}, 1, "", true));
Invoke(L_339, "sort", Fn((V _self1, int _argc426, V a_432, V b_433, V _a430, V _a431, V[] _rest427) => {
return ((V)((ToNum(Get(a_432, "z")) - ToNum(Get(b_433, "z")))));
}, 2, "", true));
Invoke(SN_43, "order", Get(PS_322, "par"), L_339);
Invoke(Get(PS_322, "ln"), "setAttribute", ((V)("d")), (gl_337 is var _t434 && Truthy(_t434) ? _t434 : ((V)("M0 0"))));
return lob_338;
return default;
}, 5, "", true);
SA_31 = Fn((V _self1, int _argc435, V e_441, V k_442, V v_443, V _a440, V[] _rest436) => {
if (!SEq(GetK(e_441, ((V)(string.Concat("_", ToStr(k_442))))), v_443)) {
SetK(e_441, ((V)(string.Concat("_", ToStr(k_442)))), v_443);
Invoke(e_441, "setAttribute", k_442, v_443);
}
return default;
}, 3, "", true);
longSet_32 = Fn((V _self1, int _argc444, V S_450, V sp_451, V par_452, V linePar_453, V[] _rest445) => {
V F_454 = default;
V H_455 = default;
V u_456 = default;
V LG_457 = default;
V lg_458 = default;
F_454 = Arr();
H_455 = ((V)((ToNum(TAU_9) / (2D * ToNum(Get(sp_451, "N"))))));
u_456 = Get(S_450, "u");
LG_457 = Fn((V _self1, int _argc459, V id_465, V a_466, V _a463, V _a464, V[] _rest460) => {
return Call(el_14, V.Undef, ((V)("linearGradient")), Object_assign(NewObj(6).Put("id", Add(id_465, u_456)).Put("gradientUnits", ((V)("userSpaceOnUse"))).Put("x1", ((V)(50D))).Put("y1", Get(sp_451, "y0")).Put("x2", ((V)(50D))).Put("y2", Get(sp_451, "y1")).V, (a_466 is var _t467 && Truthy(_t467) ? _t467 : NewObj(0).V)), Get(S_450, "df"));
}, 2, "", true);
{
V k_468 = default;
k_468 = ((V)(0D));
while (true) {
if (!(Lt(k_468, Get(sp_451, "N")))) break;
V fg_470 = default;
fg_470 = Add((Get(sp_451, "ph") is var _t471 && Truthy(_t471) ? _t471 : ((V)(0D))), ((V)(((ToNum(k_468) * ToNum(TAU_9)) / ToNum(Get(sp_451, "N"))))));
{
V side_472 = default;
side_472 = ((V)(0D));
while (true) {
if (!(LtN(side_472, 2D))) break;
V g_474 = default;
g_474 = Call(LG_457, V.Undef, ((V)(string.Concat("lp", ToStr(k_468), "_", ToStr(side_472)))));
Invoke(F_454, "push", NewObj(7).Put("side", side_472).Put("fa", (Truthy(side_472) ? Add(fg_470, H_455) : fg_470)).Put("fb", (Truthy(side_472) ? Add(fg_470, ((V)((2D * ToNum(H_455))))) : Add(fg_470, H_455))).Put("id", ((V)(string.Concat("p", ToStr(k_468), "_", ToStr(side_472))))).Put("g", g_474).Put("st", Invoke(Get(sp_451, "SY"), "map", Fn((V _self1, int _argc475, V _a477, V _a478, V _a479, V _a480, V[] _rest476) => {
return Call(el_14, V.Undef, ((V)("stop")), NewObj(2).Put("offset", ((V)(0D))).Put("stop-color", GetIdx(Get(sp_451, "cols"), 1D)).V, g_474);
}, 0, "", true))).Put("e", Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", ((V)(string.Concat(new string[] { "url(#lp", ToStr(k_468), "_", ToStr(side_472), ToStr(u_456), ")" })))).V, par_452)).V);
PostInc(ref side_472, 1D);
}
}
PostInc(ref k_468, 1D);
}
}
lg_458 = Call(LG_457, V.Undef, ((V)("lpl")));
Invoke(Get(sp_451, "LS"), "forEach", Fn((V _self1, int _argc481, V _a483, V _a484, V _a485, V _a486, V[] _rest482) => {
V o_489 = default;
V op_491 = default;
{ V _t487 = ListOf(_a483);
{ V _t488 = GetIdx(_t487, 0D);
o_489 = _t488; }
{ V _t490 = GetIdx(_t487, 1D);
op_491 = _t490; }
}
return Call(el_14, V.Undef, ((V)("stop")), NewObj(3).Put("offset", o_489).Put("stop-color", Get(sp_451, "lc")).Put("stop-opacity", op_491).V, lg_458);
}, 1, "", true));
return NewObj(8).Put("sp", sp_451).Put("F", F_454).Put("H", H_455).Put("par", par_452).Put("lg", lg_458).Put("YS", Array_from(NewObj(1).Put("length", Add(Get(sp_451, "NY"), ((V)(1D)))).V, Fn((V _self1, int _argc492, V __498, V i_499, V _a496, V _a497, V[] _rest493) => {
return Add(Get(sp_451, "y0"), ((V)((((ToNum(Get(sp_451, "y1")) - ToNum(Get(sp_451, "y0"))) * ToNum(i_499)) / ToNum(Get(sp_451, "NY"))))));
}, 2, "", true))).Put("ln", Call(el_14, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)(string.Concat("url(#lpl", ToStr(u_456), ")")))).Put("stroke-width", Get(sp_451, "lw")).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V, (linePar_453 is var _t500 && Truthy(_t500) ? _t500 : Get(par_452, "parentNode")))).Put("PAL", Call(pal_28, V.Undef, GetIdx(Get(sp_451, "cols"), 0D), GetIdx(Get(sp_451, "cols"), 1D), GetIdx(Get(sp_451, "cols"), 2D), ((V)(24D)))).V;
return default;
}, 4, "", true);
longDraw_33 = Fn((V _self1, int _argc501, V D_507, V PS_508, V proj_509, V Z_510, V[] _rest502) => {
V sp_512 = default;
V F_513 = default;
V H_514 = default;
V YS_515 = default;
V rT_516 = default;
V dep_517 = default;
V SY_518 = default;
V r3_519 = default;
V gT_520 = default;
V X3_521 = default;
V gl_522 = default;
V L_523 = default;
V t0_524 = default;
V t1_525 = default;
V TW_511 = default;
TW_511 = (_argc501 > 4 ? _rest502[0] : V.Undef);
{ V _t526 = PS_508;
if (_t526.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t526));
{ V _t527 = Get(_t526, "sp");
sp_512 = _t527; }
{ V _t528 = Get(_t526, "F");
F_513 = _t528; }
{ V _t529 = Get(_t526, "H");
H_514 = _t529; }
{ V _t530 = Get(_t526, "YS");
YS_515 = _t530; } }
{ V _t531 = sp_512;
if (_t531.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t531));
{ V _t532 = Get(_t531, "rT");
rT_516 = _t532; }
{ V _t533 = Get(_t531, "dep");
dep_517 = _t533; }
{ V _t534 = Get(_t531, "SY");
SY_518 = _t534; } }
r3_519 = Fn((V _self1, int _argc535, V v_541, V _a538, V _a539, V _a540, V[] _rest536) => {
return ((V)((Round((ToNum(v_541) * 1000D)) / 1000D)));
}, 1, "", true);
gT_520 = Fn((V _self1, int _argc542, V y_548, V _a545, V _a546, V _a547, V[] _rest543) => {
return ((V)(FdLibm.Atan(((ToNum(Call(rT_516, V.Undef, Add(y_548, ((V)(1D))))) - ToNum(Call(rT_516, V.Undef, ((V)((ToNum(y_548) - 1D)))))) / 2D))));
}, 1, "", true);
X3_521 = Fn((V _self1, int _argc549, V f_555, V y_556, V ridge_557, V _a554, V[] _rest550) => {
V ff_558 = default;
V r_559 = default;
ff_558 = Add(f_555, Call(TW_511, V.Undef, y_556));
r_559 = Add(Call(rT_516, V.Undef, y_556), (Truthy(ridge_557) ? Call(dep_517, V.Undef, y_556) : ((V)((-0.25)))));
return Arr(((V)((50D + (ToNum(r_559) * FdLibm.Sin(ToNum(ff_558)))))), y_556, ((V)((ToNum(r_559) * FdLibm.Cos(ToNum(ff_558))))));
return default;
}, 3, "", true);
gl_522 = ((V)(""));
L_523 = Arr();
Invoke(F_513, "forEach", Fn((V _self1, int _argc560, V o_566, V _a563, V _a564, V _a565, V[] _rest561) => {
V vis_567 = default;
V zs_568 = default;
V C_569 = default;
V ra_570 = default;
V A3_571 = default;
V A_572 = default;
V B_573 = default;
V a_574 = default;
V bq_575 = default;
V vx_576 = default;
V vy_577 = default;
V vv_578 = default;
V of_579 = default;
vis_567 = (false ? V.True : V.False);
zs_568 = ((V)(0D));
C_569 = Invoke(SY_518, "map", Fn((V _self1, int _argc580, V y_586, V _a583, V _a584, V _a585, V[] _rest581) => {
V fm_587 = default;
V rm_588 = default;
V be_589 = default;
V az_590 = default;
V g_591 = default;
V n_592 = default;
V m_593 = default;
V fz_594 = default;
V p0_595 = default;
V p1_596 = default;
V sx_597 = default;
V sy_598 = default;
V ln_599 = default;
V b_600 = default;
fm_587 = Add(((V)((ToNum(Add(Get(o_566, "fa"), Get(o_566, "fb"))) / 2D))), Call(TW_511, V.Undef, y_586));
rm_588 = Call(rT_516, V.Undef, y_586);
be_589 = ((V)((FdLibm.Atan2(ToNum(Add(Call(dep_517, V.Undef, y_586), ((V)(0.25)))), (ToNum(rm_588) * ToNum(H_514))) * (Truthy(Get(o_566, "side")) ? 1D : (-1D)))));
az_590 = Add(fm_587, be_589);
g_591 = Call(gT_520, V.Undef, y_586);
n_592 = Arr(((V)((FdLibm.Sin(ToNum(az_590)) * FdLibm.Cos(ToNum(g_591))))), ((V)((-FdLibm.Sin(ToNum(g_591))))), ((V)((FdLibm.Cos(ToNum(az_590)) * FdLibm.Cos(ToNum(g_591))))));
m_593 = Arr(((V)((50D + (ToNum(rm_588) * FdLibm.Sin(ToNum(fm_587)))))), y_586, ((V)((ToNum(rm_588) * FdLibm.Cos(ToNum(fm_587))))));
fz_594 = Invoke(D_507, "facing", GetIdx(m_593, 0D), GetIdx(m_593, 1D), GetIdx(m_593, 2D), GetIdx(n_592, 0D), GetIdx(n_592, 1D), GetIdx(n_592, 2D));
if (GtN(fz_594, 0.02)) {
vis_567 = (true ? V.True : V.False);
}
zs_568 = Add(zs_568, Call(Z_510, V.Undef, GetIdx(m_593, 0D), GetIdx(m_593, 1D), GetIdx(m_593, 2D)));
p0_595 = Call(proj_509, V.Undef, GetIdx(m_593, 0D), GetIdx(m_593, 1D), GetIdx(m_593, 2D));
p1_596 = Call(proj_509, V.Undef, Add(GetIdx(m_593, 0D), GetIdx(n_592, 0D)), Add(GetIdx(m_593, 1D), GetIdx(n_592, 1D)), Add(GetIdx(m_593, 2D), GetIdx(n_592, 2D)));
sx_597 = ((V)(((ToNum(GetIdx(p1_596, 0D)) - ToNum(GetIdx(p0_595, 0D))) / ToNum(Get(D_507, "kS")))));
sy_598 = ((V)(((ToNum(GetIdx(p1_596, 1D)) - ToNum(GetIdx(p0_595, 1D))) / ToNum(Get(D_507, "kS")))));
ln_599 = (((V)(Hypot(ToNum(sx_597), ToNum(sy_598), ToNum(fz_594)))) is var _t601 && Truthy(_t601) ? _t601 : ((V)(1D)));
b_600 = ((V)(((((ToNum(sx_597) * ToNum(GetIdx(LV_27, 0D))) + (ToNum(sy_598) * ToNum(GetIdx(LV_27, 1D)))) + (ToNum(fz_594) * ToNum(GetIdx(LV_27, 2D)))) / ToNum(ln_599))));
return NewObj(2).Put("p", p0_595).Put("c", GetIdx(Get(PS_508, "PAL"), Round((ToNum(Call(clamp_12, V.Undef, ((V)((0.3 + (0.95 * ToNum(b_600))))), ((V)(0D)), ((V)(1D)))) * 24D)))).V;
return default;
}, 1, "", true));
if (!(Truthy(vis_567))) {
if (!SEqN(Get(o_566, "on"), 0D)) {
Set(o_566, "on", ((V)(0D)));
Invoke(Get(o_566, "e"), "setAttribute", ((V)("d")), ((V)("M0 0")));
}
return default;
}
Set(o_566, "on", ((V)(1D)));
ra_570 = (SEqN(Get(o_566, "side"), 1D) ? V.True : V.False);
A3_571 = Invoke(YS_515, "map", Fn((V _self1, int _argc602, V y_608, V _a605, V _a606, V _a607, V[] _rest603) => {
return Call(X3_521, V.Undef, Get(o_566, "fa"), y_608, ra_570);
}, 1, "", true));
A_572 = Invoke(A3_571, "map", Fn((V _self1, int _argc609, V p_615, V _a612, V _a613, V _a614, V[] _rest610) => {
return Call(proj_509, V.Undef, GetIdx(p_615, 0D), GetIdx(p_615, 1D), GetIdx(p_615, 2D));
}, 1, "", true));
B_573 = Invoke(YS_515, "map", Fn((V _self1, int _argc616, V y_622, V _a619, V _a620, V _a621, V[] _rest617) => {
V p_623 = default;
p_623 = Call(X3_521, V.Undef, Get(o_566, "fb"), y_622, (!(Truthy(ra_570)) ? V.True : V.False));
return Call(proj_509, V.Undef, GetIdx(p_623, 0D), GetIdx(p_623, 1D), GetIdx(p_623, 2D));
return default;
}, 1, "", true));
Invoke(Get(o_566, "e"), "setAttribute", ((V)("d")), Call(polyD_16, V.Undef, Invoke(A_572, "concat", Invoke(B_573, "reverse"))));
a_574 = Get(GetIdx(C_569, 0D), "p");
bq_575 = Get(GetIdx(C_569, (ToNum(Get(C_569, "length")) - 1D)), "p");
vx_576 = ((V)((ToNum(GetIdx(bq_575, 0D)) - ToNum(GetIdx(a_574, 0D)))));
vy_577 = ((V)((ToNum(GetIdx(bq_575, 1D)) - ToNum(GetIdx(a_574, 1D)))));
vv_578 = (((V)(((ToNum(vx_576) * ToNum(vx_576)) + (ToNum(vy_577) * ToNum(vy_577))))) is var _t624 && Truthy(_t624) ? _t624 : ((V)(1D)));
Call(SA_31, V.Undef, Get(o_566, "g"), ((V)("x1")), Call(r3_519, V.Undef, GetIdx(a_574, 0D)));
Call(SA_31, V.Undef, Get(o_566, "g"), ((V)("y1")), Call(r3_519, V.Undef, GetIdx(a_574, 1D)));
Call(SA_31, V.Undef, Get(o_566, "g"), ((V)("x2")), Call(r3_519, V.Undef, GetIdx(bq_575, 0D)));
Call(SA_31, V.Undef, Get(o_566, "g"), ((V)("y2")), Call(r3_519, V.Undef, GetIdx(bq_575, 1D)));
of_579 = ((V)(0D));
Invoke(C_569, "forEach", Fn((V _self1, int _argc625, V s_631, V i_632, V _a629, V _a630, V[] _rest626) => {
of_579 = ((V)(Max(ToNum(of_579), ToNum(Call(clamp_12, V.Undef, ((V)(((((ToNum(GetIdx(Get(s_631, "p"), 0D)) - ToNum(GetIdx(a_574, 0D))) * ToNum(vx_576)) + ((ToNum(GetIdx(Get(s_631, "p"), 1D)) - ToNum(GetIdx(a_574, 1D))) * ToNum(vy_577))) / ToNum(vv_578)))), ((V)(0D)), ((V)(1D)))))));
Call(SA_31, V.Undef, GetK(Get(o_566, "st"), i_632), ((V)("offset")), Call(r3_519, V.Undef, of_579));
Call(SA_31, V.Undef, GetK(Get(o_566, "st"), i_632), ((V)("stop-color")), Get(s_631, "c"));
return default;
}, 2, "", true));
if (!(Truthy(Get(o_566, "side")))) {
gl_522 = Add(gl_522, Call(runs_21, V.Undef, A_572, Invoke(A3_571, "map", Fn((V _self1, int _argc633, V p_639, V i_640, V _a637, V _a638, V[] _rest634) => {
V ff_641 = default;
V g_642 = default;
ff_641 = Add(Get(o_566, "fa"), Call(TW_511, V.Undef, GetK(YS_515, i_640)));
g_642 = Call(gT_520, V.Undef, GetK(YS_515, i_640));
return (GtN(Invoke(D_507, "facing", GetIdx(p_639, 0D), GetIdx(p_639, 1D), GetIdx(p_639, 2D), ((V)((FdLibm.Sin(ToNum(ff_641)) * FdLibm.Cos(ToNum(g_642))))), ((V)((-FdLibm.Sin(ToNum(g_642))))), ((V)((FdLibm.Cos(ToNum(ff_641)) * FdLibm.Cos(ToNum(g_642)))))), 0.05) ? V.True : V.False);
return default;
}, 2, "", true))));
}
Invoke(L_523, "push", NewObj(3).Put("id", Get(o_566, "id")).Put("e", Get(o_566, "e")).Put("z", ((V)((ToNum(zs_568) / ToNum(Get(SY_518, "length")))))).V);
return default;
}, 1, "", true));
Invoke(L_523, "sort", Fn((V _self1, int _argc643, V a_649, V b_650, V _a647, V _a648, V[] _rest644) => {
return ((V)((ToNum(Get(a_649, "z")) - ToNum(Get(b_650, "z")))));
}, 2, "", true));
Invoke(SN_43, "order", Get(PS_508, "par"), L_523);
Invoke(Get(PS_508, "ln"), "setAttribute", ((V)("d")), (gl_522 is var _t651 && Truthy(_t651) ? _t651 : ((V)("M0 0"))));
t0_524 = Call(proj_509, V.Undef, ((V)(50D)), Get(sp_512, "y0"), ((V)(0D)));
t1_525 = Call(proj_509, V.Undef, ((V)(50D)), Get(sp_512, "y1"), ((V)(0D)));
Call(SA_31, V.Undef, Get(PS_508, "lg"), ((V)("x1")), Call(r3_519, V.Undef, GetIdx(t0_524, 0D)));
Call(SA_31, V.Undef, Get(PS_508, "lg"), ((V)("y1")), Call(r3_519, V.Undef, GetIdx(t0_524, 1D)));
Call(SA_31, V.Undef, Get(PS_508, "lg"), ((V)("x2")), Call(r3_519, V.Undef, GetIdx(t1_525, 0D)));
Call(SA_31, V.Undef, Get(PS_508, "lg"), ((V)("y2")), Call(r3_519, V.Undef, GetIdx(t1_525, 1D)));
return default;
}, 5, "", true);
resample_34 = Fn((V _self1, int _argc652, V Q_658, V n_659, V _a656, V _a657, V[] _rest653) => {
V L_660 = default;
V tot_661 = default;
V @out_662 = default;
V j_663 = default;
L_660 = Arr(((V)(0D)));
{
V i_664 = default;
i_664 = ((V)(1D));
while (true) {
if (!(Le(i_664, Get(Q_658, "length")))) break;
V a_666 = default;
V b_667 = default;
a_666 = GetIdx(Q_658, (ToNum(i_664) - 1D));
b_667 = GetIdx(Q_658, (ToNum(i_664) % ToNum(Get(Q_658, "length"))));
Invoke(L_660, "push", Add(GetIdx(L_660, (ToNum(i_664) - 1D)), ((V)(Hypot((ToNum(GetIdx(b_667, 0D)) - ToNum(GetIdx(a_666, 0D))), (ToNum(GetIdx(b_667, 1D)) - ToNum(GetIdx(a_666, 1D))))))));
PostInc(ref i_664, 1D);
}
}
tot_661 = GetIdx(L_660, (ToNum(Get(L_660, "length")) - 1D));
@out_662 = Arr();
j_663 = ((V)(0D));
{
V k_668 = default;
k_668 = ((V)(0D));
while (true) {
if (!(Lt(k_668, n_659))) break;
V s_670 = default;
V a_671 = default;
V b_672 = default;
V u_673 = default;
s_670 = ((V)(((ToNum(tot_661) * ToNum(k_668)) / ToNum(n_659))));
while (Lt(GetK(L_660, Add(j_663, ((V)(1D)))), s_670)) {
PostInc(ref j_663, 1D);
}
a_671 = GetK(Q_658, j_663);
b_672 = GetIdx(Q_658, (ToNum(Add(j_663, ((V)(1D)))) % ToNum(Get(Q_658, "length"))));
u_673 = ((V)(((ToNum(s_670) - ToNum(GetK(L_660, j_663))) / ToNum((((V)((ToNum(GetK(L_660, Add(j_663, ((V)(1D))))) - ToNum(GetK(L_660, j_663))))) is var _t674 && Truthy(_t674) ? _t674 : ((V)(1D)))))));
Invoke(@out_662, "push", Arr(Add(GetIdx(a_671, 0D), ((V)(((ToNum(GetIdx(b_672, 0D)) - ToNum(GetIdx(a_671, 0D))) * ToNum(u_673))))), Add(GetIdx(a_671, 1D), ((V)(((ToNum(GetIdx(b_672, 1D)) - ToNum(GetIdx(a_671, 1D))) * ToNum(u_673)))))));
PostInc(ref k_668, 1D);
}
}
return @out_662;
return default;
}, 2, "", true);
inside_35 = Fn((V _self1, int _argc675, V O_681, V x_682, V y_683, V _a680, V[] _rest676) => {
V c_684 = default;
c_684 = (false ? V.True : V.False);
{
V i_685 = default;
V j_686 = default;
i_685 = ((V)(0D));
j_686 = ((V)((ToNum(Get(O_681, "length")) - 1D)));
while (true) {
if (!(Lt(i_685, Get(O_681, "length")))) break;
V a_688 = default;
V b_689 = default;
a_688 = GetK(O_681, i_685);
b_689 = GetK(O_681, j_686);
if ((!SEq((Gt(GetIdx(a_688, 1D), y_683) ? V.True : V.False), (Gt(GetIdx(b_689, 1D), y_683) ? V.True : V.False)) && Lt(x_682, Add(((V)((((ToNum(GetIdx(b_689, 0D)) - ToNum(GetIdx(a_688, 0D))) * (ToNum(y_683) - ToNum(GetIdx(a_688, 1D)))) / (ToNum(GetIdx(b_689, 1D)) - ToNum(GetIdx(a_688, 1D)))))), GetIdx(a_688, 0D))))) {
c_684 = (!(Truthy(c_684)) ? V.True : V.False);
}
j_686 = ((V)(PostInc(ref i_685, 1D)));
}
}
return c_684;
return default;
}, 3, "", true);
segDist_36 = Fn((V _self1, int _argc690, V O_696, V x_697, V y_698, V _a695, V[] _rest691) => {
V m_699 = default;
m_699 = ((V)(1000000000D));
{
V i_700 = default;
i_700 = ((V)(0D));
while (true) {
if (!(Lt(i_700, Get(O_696, "length")))) break;
V a_702 = default;
V b_703 = default;
V vx_704 = default;
V vy_705 = default;
V L_706 = default;
V t_707 = default;
V dx_708 = default;
V dy_709 = default;
V d_710 = default;
a_702 = GetK(O_696, i_700);
b_703 = GetIdx(O_696, (ToNum(Add(i_700, ((V)(1D)))) % ToNum(Get(O_696, "length"))));
vx_704 = ((V)((ToNum(GetIdx(b_703, 0D)) - ToNum(GetIdx(a_702, 0D)))));
vy_705 = ((V)((ToNum(GetIdx(b_703, 1D)) - ToNum(GetIdx(a_702, 1D)))));
L_706 = (((V)(((ToNum(vx_704) * ToNum(vx_704)) + (ToNum(vy_705) * ToNum(vy_705))))) is var _t711 && Truthy(_t711) ? _t711 : ((V)(1D)));
t_707 = Call(clamp_12, V.Undef, ((V)(((((ToNum(x_697) - ToNum(GetIdx(a_702, 0D))) * ToNum(vx_704)) + ((ToNum(y_698) - ToNum(GetIdx(a_702, 1D))) * ToNum(vy_705))) / ToNum(L_706)))), ((V)(0D)), ((V)(1D)));
dx_708 = ((V)((ToNum(Add(GetIdx(a_702, 0D), ((V)((ToNum(vx_704) * ToNum(t_707)))))) - ToNum(x_697))));
dy_709 = ((V)((ToNum(Add(GetIdx(a_702, 1D), ((V)((ToNum(vy_705) * ToNum(t_707)))))) - ToNum(y_698))));
d_710 = ((V)(((ToNum(dx_708) * ToNum(dx_708)) + (ToNum(dy_709) * ToNum(dy_709)))));
if (Lt(d_710, m_699)) {
m_699 = d_710;
}
PostInc(ref i_700, 1D);
}
}
return ((V)(System.Math.Sqrt(ToNum(m_699))));
return default;
}, 3, "", true);
sdist_37 = Fn((V _self1, int _argc712, V O_718, V x_719, V y_720, V _a717, V[] _rest713) => {
return ((V)(((Truthy(Call(inside_35, V.Undef, O_718, x_719, y_720)) ? 1D : (-1D)) * ToNum(Call(segDist_36, V.Undef, O_718, x_719, y_720)))));
}, 3, "", true);
halfW_38 = Fn((V _self1, int _argc721, V O_727, V y_728, V _a725, V _a726, V[] _rest722) => {
V lo_729 = default;
V hi_730 = default;
lo_729 = ((V)(1000000000D));
hi_730 = ((V)((-1000000000D)));
{
V i_731 = default;
i_731 = ((V)(0D));
while (true) {
if (!(Lt(i_731, Get(O_727, "length")))) break;
V a_733 = default;
V b_734 = default;
a_733 = GetK(O_727, i_731);
b_734 = GetIdx(O_727, (ToNum(Add(i_731, ((V)(1D)))) % ToNum(Get(O_727, "length"))));
if (((((ToNum(GetIdx(a_733, 1D)) - ToNum(y_728)) * (ToNum(GetIdx(b_734, 1D)) - ToNum(y_728))) <= 0D) && !SEq(GetIdx(a_733, 1D), GetIdx(b_734, 1D)))) {
V x_735 = default;
x_735 = Add(GetIdx(a_733, 0D), ((V)((((ToNum(GetIdx(b_734, 0D)) - ToNum(GetIdx(a_733, 0D))) * (ToNum(y_728) - ToNum(GetIdx(a_733, 1D)))) / (ToNum(GetIdx(b_734, 1D)) - ToNum(GetIdx(a_733, 1D)))))));
if (Lt(x_735, lo_729)) {
lo_729 = x_735;
}
if (Gt(x_735, hi_730)) {
hi_730 = x_735;
}
}
PostInc(ref i_731, 1D);
}
}
return ((V)((Lt(hi_730, lo_729) ? 0D : ((ToNum(hi_730) - ToNum(lo_729)) / 2D))));
return default;
}, 2, "", true);
offset_39 = Fn((V _self1, int _argc736, V O_742, V b_743, V _a740, V _a741, V[] _rest737) => {
V n_744 = default;
if (!(Truthy(b_743))) {
return O_742;
}
n_744 = Get(O_742, "length");
return Invoke(O_742, "map", Fn((V _self1, int _argc745, V p_751, V i_752, V _a749, V _a750, V[] _rest746) => {
V a_753 = default;
V c_754 = default;
V tx_755 = default;
V ty_756 = default;
V L_757 = default;
V nx_758 = default;
V ny_759 = default;
a_753 = GetIdx(O_742, (ToNum(Add(((V)((ToNum(i_752) - 1D))), n_744)) % ToNum(n_744)));
c_754 = GetIdx(O_742, (ToNum(Add(i_752, ((V)(1D)))) % ToNum(n_744)));
tx_755 = ((V)((ToNum(GetIdx(c_754, 0D)) - ToNum(GetIdx(a_753, 0D)))));
ty_756 = ((V)((ToNum(GetIdx(c_754, 1D)) - ToNum(GetIdx(a_753, 1D)))));
L_757 = (((V)(Hypot(ToNum(tx_755), ToNum(ty_756)))) is var _t760 && Truthy(_t760) ? _t760 : ((V)(1D)));
nx_758 = ((V)(((-ToNum(ty_756)) / ToNum(L_757))));
ny_759 = ((V)((ToNum(tx_755) / ToNum(L_757))));
if (!(Truthy(Call(inside_35, V.Undef, O_742, Add(GetIdx(p_751, 0D), ((V)((ToNum(nx_758) * 0.4)))), Add(GetIdx(p_751, 1D), ((V)((ToNum(ny_759) * 0.4)))))))) {
nx_758 = ((V)((-ToNum(nx_758))));
ny_759 = ((V)((-ToNum(ny_759))));
}
return Arr(Add(GetIdx(p_751, 0D), ((V)((ToNum(nx_758) * ToNum(b_743))))), Add(GetIdx(p_751, 1D), ((V)((ToNum(ny_759) * ToNum(b_743))))));
return default;
}, 2, "", true));
return default;
}, 2, "", true);
pillowRings_40 = Fn((V _self1, int _argc761, V O_767, V T_768, V b_769, V K_770, V[] _rest762) => {
V R_771 = default;
R_771 = Arr();
{
V k_772 = default;
k_772 = ((V)(0D));
while (true) {
if (!(Le(k_772, K_770))) break;
V th_774 = default;
th_774 = ((V)((((ToNum(k_772) / ToNum(K_770)) * System.Math.PI) / 2D)));
Invoke(R_771, "push", NewObj(2).Put("z", ((V)((ToNum(T_768) * FdLibm.Sin(ToNum(th_774)))))).Put("Q", Call(offset_39, V.Undef, O_767, ((V)((ToNum(b_769) * (1D - FdLibm.Cos(ToNum(th_774)))))))).V);
PostInc(ref k_772, 1D);
}
}
return R_771;
return default;
}, 4, "", true);
pillowZ_41 = Fn((V _self1, int _argc775, V O_781, V T_782, V b_783, V _a780, V[] _rest776) => {
return Fn((V _self1, int _argc784, V x_790, V y_791, V _a788, V _a789, V[] _rest785) => {
V d_792 = default;
V u_793 = default;
d_792 = Call(sdist_37, V.Undef, O_781, x_790, y_791);
if (LeN(d_792, 0D)) {
return ((V)(0D));
}
u_793 = ((V)(Min(1D, (ToNum(d_792) / ToNum(b_783)))));
return ((V)((ToNum(T_782) * System.Math.Sqrt((1D - ((1D - ToNum(u_793)) * (1D - ToNum(u_793))))))));
return default;
}, 2, "", true);
}, 3, "", true);
MODELS_42 = NewObj(0).V;
SN_43 = Set(G("window"), "SN3D", NewObj(2).Put("MODELS", MODELS_42).Put("h", NewObj(25).Put("el", el_14).Put("pt", pt_15).Put("polyD", polyD_16).Put("polyW", polyW_18).Put("circD", circD_19).Put("ellD", ellD_20).Put("runs", runs_21).Put("resample", resample_34).Put("inside", inside_35).Put("sdist", sdist_37).Put("halfW", halfW_38).Put("offset", offset_39).Put("pillowRings", pillowRings_40).Put("pillowZ", pillowZ_41).Put("clamp", clamp_12).Put("SM", SM_13).Put("r2", r2_11).Put("rnd", rnd_22).Put("subs", subs_23).Put("decD", decD_26).Put("pal", pal_28).Put("pleatSet", pleatSet_29).Put("pleatDraw", pleatDraw_30).Put("longSet", longSet_32).Put("longDraw", longDraw_33).V).V);
Set(SN_43, "setup", Fn((V _self1, int _argc794, V c_800, V _a797, V _a798, V _a799, V[] _rest795) => {
try {
Invoke(SN_43, "setup0", c_800);
} catch (System.Exception _ex801) {
V e_802 = default;
e_802 = Caught(_ex801);
Invoke(Set(G("window"), "__SNERR", (Get(G("window"), "__SNERR") is var _t804 && Truthy(_t804) ? _t804 : Arr())), "push", ((V)(string.Concat("setup ", ToStr(Get(c_800, "key")), " ", ToStr((e_802 is var _t803 && !Truthy(_t803) ? _t803 : Get(e_802, "message")))))));
Invoke(G("console"), "error", ((V)("SN3D setup")), Get(c_800, "key"), (e_802 is var _t805 && !Truthy(_t805) ? _t805 : Get(e_802, "stack")));
}
return default;
}, 1, "", true));
Set(SN_43, "setup0", Fn((V _self1, int _argc806, V c_812, V _a809, V _a810, V _a811, V[] _rest807) => {
V I_813 = default;
V key_814 = default;
V art_815 = default;
V items_816 = default;
V headA_817 = default;
V H_818 = default;
V M_819 = default;
V sk_820 = default;
V par_821 = default;
V df_822 = default;
V dOf_823 = default;
V fOf_824 = default;
V sOf_825 = default;
V S_826 = default;
V B_827 = default;
{ V _t828 = c_812;
if (_t828.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t828));
{ V _t829 = Get(_t828, "I");
I_813 = _t829; }
{ V _t830 = Get(_t828, "key");
key_814 = _t830; }
{ V _t831 = Get(_t828, "art");
art_815 = _t831; }
{ V _t832 = Get(_t828, "items");
items_816 = _t832; }
{ V _t833 = Get(_t828, "headA");
headA_817 = _t833; }
{ V _t834 = Get(_t828, "H");
H_818 = _t834; } }
M_819 = GetK(MODELS_42, key_814);
if ((!(Truthy(M_819)) || !(Truthy(headA_817)))) {
return default;
}
sk_820 = Get(headA_817, "q");
par_821 = Get(Get(sk_820, "e"), "parentNode");
df_822 = (Invoke(art_815, "querySelector", ((V)("defs"))) is var _t835 && Truthy(_t835) ? _t835 : Invoke(art_815, "insertBefore", Call(el_14, V.Undef, ((V)("defs")), NewObj(0).V), Get(art_815, "firstChild")));
dOf_823 = Fn((V _self1, int _argc836, V q_842, V _a839, V _a840, V _a841, V[] _rest837) => {
return (Invoke(Get(q_842, "e"), "getAttribute", ((V)("d"))) is var _t843 && Truthy(_t843) ? _t843 : ((V)("")));
}, 1, "", true);
fOf_824 = Fn((V _self1, int _argc844, V q_850, V _a847, V _a848, V _a849, V[] _rest845) => {
return ((Invoke(Get(q_850, "e"), "getAttribute", ((V)("fill"))) is var _t853 && Truthy(_t853) ? _t853 : ((Get(Get(q_850, "e"), "parentNode") is var _t851 && !Truthy(_t851) ? _t851 : Get(Get(Get(q_850, "e"), "parentNode"), "getAttribute")) is var _t852 && !Truthy(_t852) ? _t852 : Invoke(Get(Get(q_850, "e"), "parentNode"), "getAttribute", ((V)("fill"))))) is var _t854 && Truthy(_t854) ? _t854 : ((V)("")));
}, 1, "", true);
sOf_825 = Fn((V _self1, int _argc855, V q_861, V _a858, V _a859, V _a860, V[] _rest856) => {
return ((Invoke(Get(q_861, "e"), "getAttribute", ((V)("stroke"))) is var _t864 && Truthy(_t864) ? _t864 : ((Get(Get(q_861, "e"), "parentNode") is var _t862 && !Truthy(_t862) ? _t862 : Get(Get(Get(q_861, "e"), "parentNode"), "getAttribute")) is var _t863 && !Truthy(_t863) ? _t863 : Invoke(Get(Get(q_861, "e"), "parentNode"), "getAttribute", ((V)("stroke"))))) is var _t865 && Truthy(_t865) ? _t865 : ((V)("")));
}, 1, "", true);
S_826 = NewObj(25).Put("I", I_813).Put("key", key_814).Put("art", art_815).Put("items", items_816).Put("headA", headA_817).Put("H", H_818).Put("sk", sk_820).Put("par", par_821).Put("df", df_822).Put("u", Get(I_813, "u")).Put("HX", Get(headA_817, "cx")).Put("HY", Get(headA_817, "cy")).Put("d", dOf_823).Put("f", fOf_824).Put("s", sOf_825).Put("el", el_14).Put("hide", Fn((V _self1, int _argc866, V pred_872, V _a869, V _a870, V _a871, V[] _rest867) => {
return Invoke(items_816, "filter", Fn((V _self1, int _argc873, V q_879, V _a876, V _a877, V _a878, V[] _rest874) => {
if (((SEq(q_879, sk_820) || SEqS(Get(q_879, "role"), "xHide")) || !(Truthy(Call(pred_872, V.Undef, q_879))))) {
return (false ? V.True : V.False);
}
Set(q_879, "role", ((V)("xHide")));
Set(Get(Get(q_879, "e"), "style"), "display", ((V)("none")));
return (true ? V.True : V.False);
return default;
}, 1, "", true));
}, 1, "hide", true)).Put("path", Fn((V _self1, int _argc880, V a_886, V p_887, V before_888, V _a885, V[] _rest881) => {
return Call(el_14, V.Undef, ((V)("path")), a_886, (p_887 is var _t889 && Truthy(_t889) ? _t889 : Get(S_826, "LG")), before_888);
}, 3, "path", true)).Put("g", Fn((V _self1, int _argc890, V p_896, V before_897, V _a894, V _a895, V[] _rest891) => {
return Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, (p_896 is var _t898 && Truthy(_t898) ? _t898 : Get(S_826, "LG")), before_897);
}, 2, "g", true)).Put("outline", Fn((V _self1, int _argc899, V q_905, V n_906, V _a903, V _a904, V[] _rest900) => {
return Call(resample_34, V.Undef, Invoke(Invoke(H_818, "flat", Get(q_905, "segs"), ((V)(8D))), "filter", Fn((V _self1, int _argc907, V p_913, V i_914, V A_915, V _a912, V[] _rest908) => {
return ((!(Truthy(i_914)) || (Hypot((ToNum(GetIdx(p_913, 0D)) - ToNum(GetIdx(GetIdx(A_915, (ToNum(i_914) - 1D)), 0D))), (ToNum(GetIdx(p_913, 1D)) - ToNum(GetIdx(GetIdx(A_915, (ToNum(i_914) - 1D)), 1D)))) > 0.01)) ? V.True : V.False);
}, 3, "", true)), (n_906 is var _t916 && Truthy(_t916) ? _t916 : ((V)(64D))));
}, 2, "outline", true)).Put("rgrad", Fn((V _self1, int _argc917, V id_923, V st_924, V o_925, V _a922, V[] _rest918) => {
V g_926 = default;
g_926 = Call(el_14, V.Undef, ((V)("radialGradient")), Object_assign(NewObj(4).Put("id", Add(id_923, Get(I_813, "u"))).Put("cx", ((V)("38%"))).Put("cy", ((V)("30%"))).Put("r", ((V)("75%"))).V, (o_925 is var _t927 && Truthy(_t927) ? _t927 : NewObj(0).V)), df_822);
Invoke(st_924, "forEach", Fn((V _self1, int _argc928, V _a930, V _a931, V _a932, V _a933, V[] _rest929) => {
V of_936 = default;
V cl_938 = default;
V op_940 = default;
{ V _t934 = ListOf(_a930);
{ V _t935 = GetIdx(_t934, 0D);
of_936 = _t935; }
{ V _t937 = GetIdx(_t934, 1D);
cl_938 = _t937; }
{ V _t939 = GetIdx(_t934, 2D);
op_940 = _t939; }
}
return Call(el_14, V.Undef, ((V)("stop")), (!op_940.IsNullish ? NewObj(3).Put("offset", of_936).Put("stop-color", cl_938).Put("stop-opacity", op_940).V : NewObj(2).Put("offset", of_936).Put("stop-color", cl_938).V), g_926);
}, 1, "", true));
return ((V)(string.Concat("url(#", ToStr(id_923), ToStr(Get(I_813, "u")), ")")));
return default;
}, 3, "rgrad", true)).Put("lgrad", Fn((V _self1, int _argc941, V id_947, V st_948, V o_949, V _a946, V[] _rest942) => {
V g_950 = default;
g_950 = Call(el_14, V.Undef, ((V)("linearGradient")), Object_assign(NewObj(5).Put("id", Add(id_947, Get(I_813, "u"))).Put("x1", ((V)(0D))).Put("y1", ((V)(0D))).Put("x2", ((V)(1D))).Put("y2", ((V)(0D))).V, (o_949 is var _t951 && Truthy(_t951) ? _t951 : NewObj(0).V)), df_822);
Invoke(st_948, "forEach", Fn((V _self1, int _argc952, V _a954, V _a955, V _a956, V _a957, V[] _rest953) => {
V of_960 = default;
V cl_962 = default;
V op_964 = default;
{ V _t958 = ListOf(_a954);
{ V _t959 = GetIdx(_t958, 0D);
of_960 = _t959; }
{ V _t961 = GetIdx(_t958, 1D);
cl_962 = _t961; }
{ V _t963 = GetIdx(_t958, 2D);
op_964 = _t963; }
}
return Call(el_14, V.Undef, ((V)("stop")), (!op_964.IsNullish ? NewObj(3).Put("offset", of_960).Put("stop-color", cl_962).Put("stop-opacity", op_964).V : NewObj(2).Put("offset", of_960).Put("stop-color", cl_962).V), g_950);
}, 1, "", true));
return ((V)(string.Concat("url(#", ToStr(id_947), ToStr(Get(I_813, "u")), ")")));
return default;
}, 3, "lgrad", true)).Put("clip", Fn((V _self1, int _argc965, V id_971, V _a968, V _a969, V _a970, V[] _rest966) => {
V cp_972 = default;
cp_972 = Call(el_14, V.Undef, ((V)("clipPath")), NewObj(1).Put("id", Add(id_971, Get(I_813, "u"))).V, df_822);
return NewObj(2).Put("p", Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("d", ((V)("M0 0"))).V, cp_972)).Put("url", ((V)(string.Concat("url(#", ToStr(id_971), ToStr(Get(I_813, "u")), ")")))).V;
return default;
}, 1, "clip", true)).Put("dk", Fn((V _self1, int _argc973, V q_979, V k_980, V _a977, V _a978, V[] _rest974) => {
return (!(!(Truthy((Get(Get(q_979, "e"), "closest") is var _t981 && !Truthy(_t981) ? _t981 : Invoke(Get(q_979, "e"), "closest", ((V)((Truthy(k_980) ? string.Concat("[data-k=\"", ToStr(k_980), "\"]") : "[data-k]")))))))) ? V.True : V.False);
}, 2, "dk", true)).Put("decals", Fn((V _self1, int _argc982, V pred_988, V par_989, V _a986, V _a987, V[] _rest983) => {
return Invoke(Invoke(S_826, "hide", pred_988), "map", Fn((V _self1, int _argc990, V q_996, V _a993, V _a994, V _a995, V[] _rest991) => {
V a_997 = default;
a_997 = NewObj(0).V;
Invoke(DA_24, "forEach", Fn((V _self1, int _argc998, V k_1004, V _a1001, V _a1002, V _a1003, V[] _rest999) => {
V v_1005 = default;
v_1005 = Call(inh_25, V.Undef, Get(q_996, "e"), k_1004);
if (!v_1005.IsNullish) {
SetK(a_997, k_1004, v_1005);
}
return default;
}, 1, "", true));
if (Get(a_997, "fill").IsNullish) {
Set(a_997, "fill", ((V)("#000")));
}
return NewObj(3).Put("e", Call(el_14, V.Undef, ((V)("path")), a_997, (par_989 is var _t1006 && Truthy(_t1006) ? _t1006 : Get(S_826, "LG")))).Put("L", Call(subs_23, V.Undef, Get(q_996, "segs"), ((V)(6D)))).Put("q", q_996).V;
return default;
}, 1, "", true));
}, 2, "decals", true)).V;
Set(S_826, "gB", Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, par_821, Get(sk_820, "e")));
Set(S_826, "LG", Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, par_821, Get(Get(sk_820, "e"), "nextSibling")));
B_827 = Set(I_813, "bk", Object_assign(NewObj(10).Put("kind", key_814).Put("sn", ((V)(1D))).Put("bodyG", Get(c_812, "bodyG")).Put("d", ((V)(""))).Put("ya", ((V)(30D))).Put("yb", ((V)(90D))).Put("rx", ((V)(30D))).Put("rT", Fn((V _self1, int _argc1007, V _a1009, V _a1010, V _a1011, V _a1012, V[] _rest1008) => {
return ((V)(20D));
}, 0, "rT", true)).Put("S", S_826).Put("M", M_819).V, (Invoke(M_819, "setup", S_826) is var _t1013 && Truthy(_t1013) ? _t1013 : NewObj(0).V)));
if (Truthy(Get(B_827, "zE"))) {
Set(I_813, "zE", Get(B_827, "zE"));
}
return default;
}, 1, "", true));
Set(SN_43, "draw", Fn((V _self1, int _argc1014, V c_1020, V _a1017, V _a1018, V _a1019, V[] _rest1015) => {
try {
Invoke(SN_43, "draw0", c_1020);
} catch (System.Exception _ex1021) {
V e_1022 = default;
e_1022 = Caught(_ex1021);
if (!(Truthy(Get(SN_43, "err")))) {
Set(SN_43, "err", ((V)(1D)));
Invoke(Set(G("window"), "__SNERR", (Get(G("window"), "__SNERR") is var _t1025 && Truthy(_t1025) ? _t1025 : Arr())), "push", ((V)(string.Concat("draw ", ToStr((Get(Get(c_1020, "I"), "bk") is var _t1023 && !Truthy(_t1023) ? _t1023 : Get(Get(Get(c_1020, "I"), "bk"), "kind"))), " ", ToStr((e_1022 is var _t1024 && !Truthy(_t1024) ? _t1024 : Get(e_1022, "message")))))));
Invoke(G("console"), "error", ((V)("SN3D draw")), (Get(Get(c_1020, "I"), "bk") is var _t1026 && !Truthy(_t1026) ? _t1026 : Get(Get(Get(c_1020, "I"), "bk"), "kind")), (e_1022 is var _t1027 && !Truthy(_t1027) ? _t1027 : Get(e_1022, "stack")));
}
}
return default;
}, 1, "", true));
Set(SN_43, "draw0", Fn((V _self1, int _argc1028, V c_1034, V _a1031, V _a1032, V _a1033, V[] _rest1029) => {
V I_1035 = default;
V P_1036 = default;
V now_1037 = default;
V sph_1038 = default;
V sphZ_1039 = default;
V glob_1040 = default;
V H_1041 = default;
V HY_1042 = default;
V B_1043 = default;
V M_1044 = default;
V dt_1045 = default;
V ts_1046 = default;
V tg_1047 = default;
V ly_1048 = default;
V Q_1049 = default;
V g0_1050 = default;
V g1_1051 = default;
V D_1052 = default;
{ V _t1053 = c_1034;
if (_t1053.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1053));
{ V _t1054 = Get(_t1053, "I");
I_1035 = _t1054; }
{ V _t1055 = Get(_t1053, "P");
P_1036 = _t1055; }
{ V _t1056 = Get(_t1053, "now");
now_1037 = _t1056; }
{ V _t1057 = Get(_t1053, "sph");
sph_1038 = _t1057; }
{ V _t1058 = Get(_t1053, "sphZ");
sphZ_1039 = _t1058; }
{ V _t1059 = Get(_t1053, "glob");
glob_1040 = _t1059; }
{ V _t1060 = Get(_t1053, "H");
H_1041 = _t1060; }
{ V _t1061 = Get(_t1053, "HY");
HY_1042 = _t1061; } }
B_1043 = Get(I_1035, "bk");
M_1044 = (B_1043 is var _t1062 && !Truthy(_t1062) ? _t1062 : Get(B_1043, "M"));
if (!(Truthy(M_1044))) {
return default;
}
dt_1045 = (Get(c_1034, "dtS") is var _t1063 && Truthy(_t1063) ? _t1063 : ((V)(0.016)));
ts_1046 = ((V)((ToNum(now_1037) / 1000D)));
tg_1047 = ((V)(((((ToNum(Get(P_1036, "x")) * 1.4) + (ToNum(Get(P_1036, "tilt")) * 0.5)) + (ToNum(Get(P_1036, "lean")) * 1.5)) + (ToNum(Get(P_1036, "turn")) * 12D))));
ly_1048 = ((V)((ToNum(Get(P_1036, "lift")) - (ToNum(Get(c_1034, "sq")) * 8D))));
Q_1049 = (Get(B_1043, "__q") is var _t1064 && Truthy(_t1064) ? _t1064 : Set(B_1043, "__q", NewObj(4).Put("p", tg_1047).Put("v", ((V)(0D))).Put("l", ly_1048).Put("lv", ((V)(0D))).V));
OpSet(Q_1049, "v", 0, ((V)(((((ToNum(tg_1047) - ToNum(Get(Q_1049, "p"))) * 120D) - (ToNum(Get(Q_1049, "v")) * 7D)) * ToNum(dt_1045)))));
OpSet(Q_1049, "p", 0, ((V)((ToNum(Get(Q_1049, "v")) * ToNum(dt_1045)))));
OpSet(Q_1049, "lv", 0, ((V)(((((ToNum(ly_1048) - ToNum(Get(Q_1049, "l"))) * 140D) - (ToNum(Get(Q_1049, "lv")) * 7.5)) * ToNum(dt_1045)))));
OpSet(Q_1049, "l", 0, ((V)((ToNum(Get(Q_1049, "lv")) * ToNum(dt_1045)))));
g0_1050 = Call(glob_1040, V.Undef, ((V)(40D)), HY_1042);
g1_1051 = Call(glob_1040, V.Undef, ((V)(60D)), HY_1042);
D_1052 = Object_assign(NewObj(0).V, c_1034, NewObj(12).Put("B", B_1043).Put("ts", ts_1046).Put("P3", sph_1038).Put("Z3", sphZ_1039).Put("kS", ((V)((Hypot((ToNum(GetIdx(g1_1051, 0D)) - ToNum(GetIdx(g0_1050, 0D))), (ToNum(GetIdx(g1_1051, 1D)) - ToNum(GetIdx(g0_1050, 1D)))) / 20D)))).Put("ox", Call(clamp_12, V.Undef, ((V)((ToNum(Get(Q_1049, "p")) - ToNum(tg_1047)))), ((V)((-12D))), ((V)(12D)))).Put("oy", Call(clamp_12, V.Undef, ((V)((ToNum(Get(Q_1049, "l")) - ToNum(ly_1048)))), ((V)((-6D))), ((V)(6D)))).Put("front", ((V)((ToNum(Get(c_1034, "cyh")) * ToNum(Get(c_1034, "cp")))))).Put("bv", Fn((V _self1, int _argc1065, V k_1071, V _a1068, V _a1069, V _a1070, V[] _rest1066) => {
V v_1072 = default;
v_1072 = ((V)(ToNum(GetK(P_1036, k_1071))));
return (SEq(v_1072, v_1072) ? v_1072 : ((V)(0D)));
return default;
}, 1, "bv", true)).Put("hull", Fn((V _self1, int _argc1073, V pts_1079, V _a1076, V _a1077, V _a1078, V[] _rest1074) => {
return Call(polyD_16, V.Undef, Invoke(H_1041, "hull", pts_1079));
}, 1, "hull", true)).Put("set", Fn((V _self1, int _argc1080, V e_1086, V a_1087, V v_1088, V _a1085, V[] _rest1081) => {
return Invoke(e_1086, "setAttribute", a_1087, v_1088);
}, 3, "set", true)).Put("facing", Fn((V _self1, int _argc1089, V x_1095, V y_1096, V z_1097, V nx_1098, V[] _rest1090) => {
V ny_1099 = default;
V nz_1100 = default;
ny_1099 = (_argc1089 > 4 ? _rest1090[0] : V.Undef);
nz_1100 = (_argc1089 > 5 ? _rest1090[1] : V.Undef);
return ((V)((ToNum(Call(sphZ_1039, V.Undef, Add(x_1095, nx_1098), Add(y_1096, ny_1099), Add(z_1097, nz_1100))) - ToNum(Call(sphZ_1039, V.Undef, x_1095, y_1096, z_1097)))));
}, 6, "facing", true)).V);
Invoke(M_1044, "draw", B_1043, D_1052);
return default;
}, 1, "", true));
Set(SN_43, "order", Fn((V _self1, int _argc1101, V g_1107, V list_1108, V key_1109, V _a1106, V[] _rest1102) => {
V k_1110 = default;
k_1110 = Invoke(Invoke(list_1108, "map", Fn((V _self1, int _argc1111, V o_1117, V _a1114, V _a1115, V _a1116, V[] _rest1112) => {
return Get(o_1117, "id");
}, 1, "", true)), "join", ((V)(",")));
if (SEq(Get(g_1107, "__ok"), k_1110)) {
return default;
}
Set(g_1107, "__ok", k_1110);
Invoke(list_1108, "forEach", Fn((V _self1, int _argc1118, V o_1124, V _a1121, V _a1122, V _a1123, V[] _rest1119) => {
return Invoke(g_1107, "appendChild", Get(o_1124, "e"));
}, 1, "", true));
return default;
}, 3, "", true));
sphereHull_44 = Fn((V _self1, int _argc1125, V D_1131, V c_1132, V r_1133, V n_1134, V[] _rest1126) => {
V o_1135 = default;
o_1135 = Arr();
n_1134 = (n_1134 is var _t1136 && Truthy(_t1136) ? _t1136 : ((V)(8D)));
{
V i_1137 = default;
i_1137 = ((V)(0D));
while (true) {
if (!(Le(i_1137, n_1134))) break;
V th_1139 = default;
V cr_1140 = default;
V y_1141 = default;
th_1139 = ((V)((((-System.Math.PI) / 2D) + ((System.Math.PI * ToNum(i_1137)) / ToNum(n_1134)))));
cr_1140 = ((V)(FdLibm.Cos(ToNum(th_1139))));
y_1141 = Add(GetIdx(c_1132, 1D), ((V)((ToNum(r_1133) * FdLibm.Sin(ToNum(th_1139))))));
if (LtN(cr_1140, 0.01)) {
Invoke(o_1135, "push", Invoke(D_1131, "P3", GetIdx(c_1132, 0D), y_1141, GetIdx(c_1132, 2D)));
goto _cont1138;
}
{
V k_1142 = default;
k_1142 = ((V)(0D));
while (true) {
if (!(LtN(k_1142, (2D * ToNum(n_1134))))) break;
V f_1144 = default;
f_1144 = ((V)(((ToNum(k_1142) / (2D * ToNum(n_1134))) * ToNum(TAU_9))));
Invoke(o_1135, "push", Invoke(D_1131, "P3", Add(GetIdx(c_1132, 0D), ((V)(((ToNum(r_1133) * ToNum(cr_1140)) * FdLibm.Sin(ToNum(f_1144)))))), y_1141, Add(GetIdx(c_1132, 2D), ((V)(((ToNum(r_1133) * ToNum(cr_1140)) * FdLibm.Cos(ToNum(f_1144))))))));
PostInc(ref k_1142, 1D);
}
}
_cont1138: ;
PostInc(ref i_1137, 1D);
}
}
return o_1135;
return default;
}, 4, "", true);
Set(Get(SN_43, "h"), "sphereHull", sphereHull_44);
tubeD_45 = Fn((V _self1, int _argc1145, V D_1151, V C_1152, V R_1153, V _a1150, V[] _rest1146) => {
V d_1154 = default;
V SP_1155 = default;
d_1154 = ((V)(""));
SP_1155 = Invoke(C_1152, "map", Fn((V _self1, int _argc1156, V c_1162, V i_1163, V _a1160, V _a1161, V[] _rest1157) => {
return Call(sphereHull_44, V.Undef, D_1151, c_1162, GetK(R_1153, i_1163), ((V)(5D)));
}, 2, "", true));
{
V i_1164 = default;
i_1164 = ((V)(0D));
while (true) {
if (!(LtN(i_1164, (ToNum(Get(C_1152, "length")) - 1D)))) break;
d_1154 = Add(d_1154, Call(polyW_18, V.Undef, Invoke(Get(D_1151, "H"), "hull", Invoke(GetK(SP_1155, i_1164), "concat", GetK(SP_1155, Add(i_1164, ((V)(1D))))))));
PostInc(ref i_1164, 1D);
}
}
return d_1154;
return default;
}, 3, "", true);
Set(Get(SN_43, "h"), "tubeD", tubeD_45);
pillowHull_46 = Fn((V _self1, int _argc1166, V D_1172, V rings_1173, V z0_1174, V sg_1175, V[] _rest1167) => {
V o_1177 = default;
V extra_1176 = default;
extra_1176 = (_argc1166 > 4 ? _rest1167[0] : V.Undef);
o_1177 = (Truthy(extra_1176) ? Invoke(extra_1176, "slice") : Arr());
Invoke(rings_1173, "forEach", Fn((V _self1, int _argc1178, V R_1184, V _a1181, V _a1182, V _a1183, V[] _rest1179) => {
return Invoke(Get(R_1184, "Q"), "forEach", Fn((V _self1, int _argc1185, V p_1191, V _a1188, V _a1189, V _a1190, V[] _rest1186) => {
return Invoke(o_1177, "push", Invoke(D_1172, "P3", GetIdx(p_1191, 0D), GetIdx(p_1191, 1D), Add(z0_1174, ((V)((ToNum(sg_1175) * ToNum(Get(R_1184, "z"))))))));
}, 1, "", true));
}, 1, "", true));
return o_1177;
return default;
}, 5, "", true);
Set(Get(SN_43, "h"), "pillowHull", pillowHull_46);
Set(Get(SN_43, "h"), "frontArc", Fn((V _self1, int _argc1192, V D_1198, V r_1199, V y_1200, V n_1201, V[] _rest1193) => {
V v_1202 = default;
V i0_1203 = default;
V o_1204 = default;
v_1202 = Arr();
{
V k_1205 = default;
k_1205 = ((V)(0D));
while (true) {
if (!(Lt(k_1205, n_1201))) break;
V f_1207 = default;
f_1207 = ((V)(((ToNum(k_1205) / ToNum(n_1201)) * ToNum(TAU_9))));
Invoke(v_1202, "push", (GtN(Invoke(D_1198, "facing", ((V)((50D + (ToNum(r_1199) * FdLibm.Sin(ToNum(f_1207)))))), y_1200, ((V)((ToNum(r_1199) * FdLibm.Cos(ToNum(f_1207))))), ((V)(FdLibm.Sin(ToNum(f_1207)))), ((V)(0D)), ((V)(FdLibm.Cos(ToNum(f_1207))))), (-0.002)) ? V.True : V.False));
PostInc(ref k_1205, 1D);
}
}
i0_1203 = Invoke(v_1202, "findIndex", Fn((V _self1, int _argc1208, V o_1214, V k_1215, V _a1212, V _a1213, V[] _rest1209) => {
return (o_1214 is var _t1216 && !Truthy(_t1216) ? _t1216 : (!(Truthy(GetIdx(v_1202, (ToNum(Add(((V)((ToNum(k_1215) - 1D))), n_1201)) % ToNum(n_1201))))) ? V.True : V.False));
}, 2, "", true));
if (LtN(i0_1203, 0D)) {
i0_1203 = ((V)(0D));
}
o_1204 = Arr();
{
V j_1217 = default;
j_1217 = ((V)(0D));
while (true) {
if (!(Le(j_1217, n_1201))) break;
V k_1219 = default;
k_1219 = ((V)((ToNum(Add(i0_1203, j_1217)) % ToNum(n_1201))));
if (!(Truthy(GetK(v_1202, k_1219)))) {
break;
}
Invoke(o_1204, "push", ((V)(((ToNum(Add(i0_1203, j_1217)) / ToNum(n_1201)) * ToNum(TAU_9)))));
PostInc(ref j_1217, 1D);
}
}
return o_1204;
return default;
}, 4, "", true));
Set(MODELS_42, "corny", NewObj(2).Put("setup", Fn((V _self1220, int _argc1221, V S_1227, V _a1224, V _a1225, V _a1226, V[] _rest1222) => {
V sk_1228 = default;
V O_1229 = default;
V rT_1230 = default;
V EL_1231 = default;
V red_1232 = default;
V RF_1233 = default;
V pk_1234 = default;
V PF_1235 = default;
V popF_1236 = default;
V sh_1237 = default;
V st_1238 = default;
V bed_1239 = default;
V cl_1240 = default;
V KG_1241 = default;
V rim_1242 = default;
V rimL_1243 = default;
V K_1244 = default;
V add_1245 = default;
if (_self1220.IsNullish) _self1220 = GlobalV;
{ V _t1246 = S_1227;
if (_t1246.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1246));
{ V _t1247 = Get(_t1246, "sk");
sk_1228 = _t1247; } }
O_1229 = Invoke(S_1227, "outline", sk_1228, ((V)(64D)));
rT_1230 = Fn((V _self1220, int _argc1248, V y_1254, V _a1251, V _a1252, V _a1253, V[] _rest1249) => {
return Call(halfW_38, V.Undef, O_1229, Call(clamp_12, V.Undef, y_1254, ((V)(41.2)), ((V)(86.8))));
}, 1, "", true);
EL_1231 = ((V)(0.11));
red_1232 = Get((Invoke(Get(S_1227, "items"), "find", Fn((V _self1220, int _argc1255, V q_1261, V _a1258, V _a1259, V _a1260, V[] _rest1256) => {
return (Get(q_1261, "inBody") is var _t1262 && !Truthy(_t1262) ? _t1262 : Invoke(NewRegExp(RX0, "^M15\\.00 41", ""), "test", Invoke(S_1227, "d", q_1261)));
}, 1, "", true)) is var _t1263 && Truthy(_t1263) ? _t1263 : NewObj(0).V), "e");
RF_1233 = (Truthy(red_1232) ? Invoke(red_1232, "getAttribute", ((V)("fill"))) : ((V)("#f0464e")));
pk_1234 = Invoke(S_1227, "hide", Fn((V _self1220, int _argc1264, V q_1270, V _a1267, V _a1268, V _a1269, V[] _rest1265) => {
return (((Get(q_1270, "inBody") is var _t1271 && !Truthy(_t1271) ? _t1271 : Get(Get(q_1270, "e"), "parentNode")) is var _t1272 && !Truthy(_t1272) ? _t1272 : Get(Get(Get(q_1270, "e"), "parentNode"), "getAttribute")) is var _t1274 && !Truthy(_t1274) ? _t1274 : Invoke(NewRegExp(RX1, "translate", ""), "test", (Invoke(Get(Get(q_1270, "e"), "parentNode"), "getAttribute", ((V)("transform"))) is var _t1273 && Truthy(_t1273) ? _t1273 : ((V)("")))));
}, 1, "", true));
PF_1235 = Get((Invoke(pk_1234, "find", Fn((V _self1220, int _argc1275, V q_1281, V _a1278, V _a1279, V _a1280, V[] _rest1276) => {
return Invoke(NewRegExp(RX2, "^url", ""), "test", Invoke(S_1227, "f", q_1281));
}, 1, "", true)) is var _t1282 && Truthy(_t1282) ? _t1282 : NewObj(0).V), "e");
popF_1236 = (Truthy(PF_1235) ? Invoke(PF_1235, "getAttribute", ((V)("fill"))) : ((V)("#fff2c8")));
Invoke(S_1227, "hide", Fn((V _self1220, int _argc1283, V q_1289, V _a1286, V _a1287, V _a1288, V[] _rest1284) => {
return (Get(q_1289, "inBody") is var _t1290 && !Truthy(_t1290) ? _t1290 : Invoke(NewRegExp(RX3, "^(M15\\.00 41|M33\\.90 41|M57\\.00 41|M75\\.90 41|M13\\.5 39\\.5|M15 40\\.6)", ""), "test", Invoke(S_1227, "d", q_1289)));
}, 1, "", true));
sh_1237 = Invoke(S_1227, "path", NewObj(1).Put("fill", Invoke(S_1227, "lgrad", ((V)("cnsh")), Arr(Arr(((V)(0D)), ((V)("#7a2a22")), ((V)(0.34))), Arr(((V)(0.14)), ((V)("#7a2a22")), ((V)(0.08))), Arr(((V)(0.3)), ((V)("#ffffff")), ((V)(0.32))), Arr(((V)(0.46)), ((V)("#ffffff")), ((V)(0D))), Arr(((V)(0.76)), ((V)("#5a1a14")), ((V)(0.05))), Arr(((V)(1D)), ((V)("#5a1a14")), ((V)(0.4)))))).V);
st_1238 = Invoke(S_1227, "path", NewObj(1).Put("fill", RF_1233).V);
bed_1239 = Invoke(S_1227, "path", NewObj(1).Put("fill", Invoke(S_1227, "rgrad", ((V)("cnbd")), Arr(Arr(((V)(0D)), ((V)("#fff3c4"))), Arr(((V)(0.7)), ((V)("#f4d27a"))), Arr(((V)(1D)), ((V)("#d9a848")))), NewObj(3).Put("cx", ((V)("50%"))).Put("cy", ((V)("40%"))).Put("r", ((V)("60%"))).V)).V);
cl_1240 = Invoke(S_1227, "clip", ((V)("cnc")));
KG_1241 = Invoke(S_1227, "g");
Invoke(KG_1241, "setAttribute", ((V)("clip-path")), Get(cl_1240, "url"));
rim_1242 = Invoke(S_1227, "path", NewObj(1).Put("fill", RF_1233).V);
rimL_1243 = Invoke(S_1227, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffd0d0"))).Put("stroke-width", ((V)(0.9))).Put("opacity", ((V)(0.8))).Put("stroke-linecap", ((V)("round"))).V);
K_1244 = Arr();
add_1245 = Fn((V _self1220, int _argc1291, V rho_1297, V n_1298, V y_1299, V s_1300, V[] _rest1292) => {
V ph_1301 = default;
ph_1301 = (_argc1291 > 4 ? _rest1292[0] : V.Undef);
{
V i_1302 = default;
i_1302 = ((V)(0D));
while (true) {
if (!(Lt(i_1302, n_1298))) break;
V a_1304 = default;
V id_1305 = default;
a_1304 = Add(ph_1301, ((V)(((ToNum(i_1302) / ToNum(n_1298)) * ToNum(TAU_9)))));
id_1305 = Get(K_1244, "length");
Invoke(K_1244, "push", NewObj(7).Put("id", id_1305).Put("x", ((V)((50D + (ToNum(rho_1297) * FdLibm.Sin(ToNum(a_1304))))))).Put("z", ((V)((ToNum(rho_1297) * FdLibm.Cos(ToNum(a_1304)))))).Put("y", Add(y_1299, ((V)(((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(id_1305) * 2.3) + 1D))))) - 0.5) * 2.8))))).Put("s", ((V)((ToNum(s_1300) * (0.9 + (ToNum(Call(rnd_22, V.Undef, id_1305)) * 0.25)))))).Put("hk", ((V)((6D + (ToNum(Call(rnd_22, V.Undef, Add(id_1305, ((V)(9D))))) * 10D))))).Put("B", Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(4D))), "map", Fn((V _self1220, int _argc1306, V j_1312, V _a1309, V _a1310, V _a1311, V[] _rest1307) => {
V aa_1313 = default;
V dd_1314 = default;
aa_1313 = ((V)(((ToNum(j_1312) * 1.257) + (ToNum(Call(rnd_22, V.Undef, Add(((V)((ToNum(id_1305) * 7D))), j_1312))) * 0.6))));
dd_1314 = ((V)((1.7 + (ToNum(Call(rnd_22, V.Undef, Add(((V)((ToNum(id_1305) * 5D))), j_1312))) * 0.9))));
return Arr(((V)((FdLibm.Cos(ToNum(aa_1313)) * ToNum(dd_1314)))), ((V)((FdLibm.Sin(ToNum(aa_1313)) * ToNum(dd_1314)))), ((V)((2.5 + (ToNum(Call(rnd_22, V.Undef, Add(((V)((ToNum(id_1305) * 3D))), j_1312))) * 1D)))));
return default;
}, 1, "", true))).V);
PostInc(ref i_1302, 1D);
}
}
return default;
}, 5, "", true);
Invoke(Arr(Arr(((V)(0D)), ((V)(1D)), ((V)(12.5)), ((V)(1.8)), ((V)(0D))), Arr(((V)(6.5)), ((V)(5D)), ((V)(16.5)), ((V)(1.75)), ((V)(0.4))), Arr(((V)(13D)), ((V)(9D)), ((V)(21D)), ((V)(1.75)), ((V)(0.1))), Arr(((V)(19.5)), ((V)(12D)), ((V)(25.5)), ((V)(1.7)), ((V)(0.35))), Arr(((V)(25.5)), ((V)(15D)), ((V)(30D)), ((V)(1.7)), ((V)(0.05))), Arr(((V)(30.5)), ((V)(18D)), ((V)(34.2)), ((V)(1.65)), ((V)(0.25))), Arr(((V)(34.5)), ((V)(21D)), ((V)(38D)), ((V)(1.6)), ((V)(0.15))), Arr(((V)(36.8)), ((V)(12D)), ((V)(38.8)), ((V)(1.5)), ((V)(0.3)))), "forEach", Fn((V _self1220, int _argc1315, V a_1321, V _a1318, V _a1319, V _a1320, V[] _rest1316) => {
return CallSpread(add_1245, V.Undef, new ArrBuilder().Spread(a_1321).V);
}, 1, "", true));
Invoke(K_1244, "forEach", Fn((V _self1220, int _argc1322, V k_1328, V _a1325, V _a1326, V _a1327, V[] _rest1323) => {
Set(k_1328, "g", Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, KG_1241));
Set(k_1328, "e", Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", popF_1236).V, Get(k_1328, "g")));
Set(k_1328, "dot", Call(el_14, V.Undef, ((V)("path")), NewObj(2).Put("fill", ((V)("#d89a3a"))).Put("opacity", ((V)(0.8))).V, Get(k_1328, "g")));
Set(k_1328, "id", ((V)(string.Concat("k", ToStr(Get(k_1328, "id"))))));
return default;
}, 1, "", true));
return NewObj(15).Put("O", O_1229).Put("rT", rT_1230).Put("EL", EL_1231).Put("K", K_1244).Put("KG", KG_1241).Put("cl", cl_1240).Put("sh", sh_1237).Put("st", st_1238).Put("bed", bed_1239).Put("rim", rim_1242).Put("rimL", rimL_1243).Put("rx", ((V)(35D))).Put("ya", ((V)(44D))).Put("yb", ((V)(86D))).Put("zE", Fn((V _self1220, int _argc1329, V dx_1335, V dy_1336, V _a1333, V _a1334, V[] _rest1330) => {
V r_1337 = default;
r_1337 = Call(rT_1230, V.Undef, Add(Get(S_1227, "HY"), dy_1336));
return ((V)((System.Math.Sqrt(Max(0D, ((ToNum(r_1337) * ToNum(r_1337)) - (ToNum(dx_1335) * ToNum(dx_1335))))) + 0.3)));
return default;
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self1338, int _argc1339, V B_1345, V D_1346, V _a1343, V _a1344, V[] _rest1340) => {
V P3_1347 = default;
V Z3_1348 = default;
V set_1349 = default;
V EL_1350 = default;
V rT_1351 = default;
V pop_1352 = default;
V fz_1353 = default;
V PE_1354 = default;
V hp_1355 = default;
V vis_1356 = default;
V sd_1357 = default;
V ring_1358 = default;
V FR_1359 = default;
V FRb_1360 = default;
V FRl_1361 = default;
V L_1362 = default;
if (_self1338.IsNullish) _self1338 = GlobalV;
{ V _t1363 = D_1346;
if (_t1363.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1363));
{ V _t1364 = Get(_t1363, "P3");
P3_1347 = _t1364; }
{ V _t1365 = Get(_t1363, "Z3");
Z3_1348 = _t1365; }
{ V _t1366 = Get(_t1363, "set");
set_1349 = _t1366; } }
EL_1350 = Get(B_1345, "EL");
rT_1351 = Get(B_1345, "rT");
pop_1352 = Call(clamp_12, V.Undef, Invoke(D_1346, "bv", ((V)("pop"))), ((V)(0D)), ((V)(1.6)));
fz_1353 = Call(clamp_12, V.Undef, Invoke(D_1346, "bv", ((V)("cfz"))), ((V)(0D)), ((V)(1D)));
PE_1354 = Fn((V _self1338, int _argc1367, V x_1373, V y_1374, V z_1375, V _a1372, V[] _rest1368) => {
V p_1376 = default;
p_1376 = Call(P3_1347, V.Undef, x_1373, y_1374, z_1375);
return Arr(GetIdx(p_1376, 0D), Add(GetIdx(p_1376, 1D), ((V)((ToNum(EL_1350) * ToNum(Call(Z3_1348, V.Undef, x_1373, y_1374, z_1375)))))));
return default;
}, 3, "", true);
hp_1355 = Arr();
{
V i_1377 = default;
i_1377 = ((V)(0D));
while (true) {
if (!(LeN(i_1377, 14D))) break;
V y_1379 = default;
V r_1380 = default;
y_1379 = ((V)((41.5 + ((45.5 * ToNum(i_1377)) / 14D))));
r_1380 = Call(rT_1351, V.Undef, y_1379);
{
V k_1381 = default;
k_1381 = ((V)(0D));
while (true) {
if (!(LtN(k_1381, 24D))) break;
V f_1383 = default;
f_1383 = ((V)(((ToNum(k_1381) / 24D) * ToNum(TAU_9))));
Invoke(hp_1355, "push", Call(PE_1354, V.Undef, ((V)((50D + (ToNum(r_1380) * FdLibm.Sin(ToNum(f_1383)))))), y_1379, ((V)((ToNum(r_1380) * FdLibm.Cos(ToNum(f_1383)))))));
PostInc(ref k_1381, 1D);
}
}
PostInc(ref i_1377, 1D);
}
}
{
V k_1384 = default;
k_1384 = ((V)(0D));
while (true) {
if (!(LtN(k_1384, 32D))) break;
V f_1386 = default;
f_1386 = ((V)(((ToNum(k_1384) / 32D) * ToNum(TAU_9))));
Invoke(hp_1355, "push", Call(PE_1354, V.Undef, ((V)((50D + (35.6 * FdLibm.Sin(ToNum(f_1386)))))), ((V)(39.8)), ((V)((35.6 * FdLibm.Cos(ToNum(f_1386)))))));
PostInc(ref k_1384, 1D);
}
}
Set(B_1345, "d", Invoke(D_1346, "hull", hp_1355));
Call(set_1349, V.Undef, Get(B_1345, "sh"), ((V)("d")), Get(B_1345, "d"));
vis_1356 = Fn((V _self1338, int _argc1387, V f_1393, V y_1394, V _a1391, V _a1392, V[] _rest1388) => {
V r_1395 = default;
r_1395 = Call(rT_1351, V.Undef, y_1394);
return (GtN(Invoke(D_1346, "facing", ((V)((50D + (ToNum(r_1395) * FdLibm.Sin(ToNum(f_1393)))))), y_1394, ((V)((ToNum(r_1395) * FdLibm.Cos(ToNum(f_1393))))), ((V)(FdLibm.Sin(ToNum(f_1393)))), ((V)(0D)), ((V)(FdLibm.Cos(ToNum(f_1393))))), 0.004) ? V.True : V.False);
return default;
}, 2, "", true);
sd_1357 = ((V)(""));
{
V s_1396 = default;
s_1396 = ((V)(0D));
while (true) {
if (!(LtN(s_1396, 8D))) break;
V fc_1398 = default;
V fa_1399 = default;
V fb_1400 = default;
V F_1401 = default;
V Q_1402 = default;
V ys_1403 = default;
fc_1398 = ((V)(((ToNum(Add(s_1396, ((V)(0.5)))) * ToNum(TAU_9)) / 8D)));
fa_1399 = ((V)((ToNum(fc_1398) - (ToNum(TAU_9) / 32D))));
fb_1400 = Add(fc_1398, ((V)((ToNum(TAU_9) / 32D))));
F_1401 = Arr();
{
V j_1404 = default;
j_1404 = ((V)(0D));
while (true) {
if (!(LeN(j_1404, 12D))) break;
V f_1406 = default;
f_1406 = Add(fa_1399, ((V)((((ToNum(fb_1400) - ToNum(fa_1399)) * ToNum(j_1404)) / 12D))));
if (Truthy(Call(vis_1356, V.Undef, f_1406, ((V)(62D))))) {
Invoke(F_1401, "push", f_1406);
}
PostInc(ref j_1404, 1D);
}
}
if (LtN(Get(F_1401, "length"), 2D)) {
goto _cont1397;
}
Q_1402 = Arr();
ys_1403 = Arr(((V)(44.5)), ((V)(52D)), ((V)(60D)), ((V)(68D)), ((V)(76D)), ((V)(82D)), ((V)(85D)), ((V)(86.8)));
Invoke(F_1401, "forEach", Fn((V _self1338, int _argc1407, V f_1413, V _a1410, V _a1411, V _a1412, V[] _rest1408) => {
return Invoke(Q_1402, "push", Call(PE_1354, V.Undef, ((V)((50D + (ToNum(Call(rT_1351, V.Undef, ((V)(44.5)))) * FdLibm.Sin(ToNum(f_1413)))))), ((V)(44.5)), ((V)((ToNum(Call(rT_1351, V.Undef, ((V)(44.5)))) * FdLibm.Cos(ToNum(f_1413)))))));
}, 1, "", true));
Invoke(ys_1403, "forEach", Fn((V _self1338, int _argc1414, V y_1420, V _a1417, V _a1418, V _a1419, V[] _rest1415) => {
V f_1421 = default;
V r_1422 = default;
f_1421 = GetIdx(F_1401, (ToNum(Get(F_1401, "length")) - 1D));
r_1422 = Call(rT_1351, V.Undef, y_1420);
Invoke(Q_1402, "push", Call(PE_1354, V.Undef, ((V)((50D + (ToNum(r_1422) * FdLibm.Sin(ToNum(f_1421)))))), y_1420, ((V)((ToNum(r_1422) * FdLibm.Cos(ToNum(f_1421)))))));
return default;
}, 1, "", true));
Invoke(Invoke(Invoke(F_1401, "slice"), "reverse"), "forEach", Fn((V _self1338, int _argc1423, V f_1429, V _a1426, V _a1427, V _a1428, V[] _rest1424) => {
V r_1430 = default;
r_1430 = Call(rT_1351, V.Undef, ((V)(86.8)));
Invoke(Q_1402, "push", Call(PE_1354, V.Undef, ((V)((50D + (ToNum(r_1430) * FdLibm.Sin(ToNum(f_1429)))))), ((V)(86.8)), ((V)((ToNum(r_1430) * FdLibm.Cos(ToNum(f_1429)))))));
return default;
}, 1, "", true));
Invoke(Invoke(Invoke(ys_1403, "slice"), "reverse"), "forEach", Fn((V _self1338, int _argc1431, V y_1437, V _a1434, V _a1435, V _a1436, V[] _rest1432) => {
V f_1438 = default;
V r_1439 = default;
f_1438 = GetIdx(F_1401, 0D);
r_1439 = Call(rT_1351, V.Undef, y_1437);
Invoke(Q_1402, "push", Call(PE_1354, V.Undef, ((V)((50D + (ToNum(r_1439) * FdLibm.Sin(ToNum(f_1438)))))), y_1437, ((V)((ToNum(r_1439) * FdLibm.Cos(ToNum(f_1438)))))));
return default;
}, 1, "", true));
sd_1357 = Add(sd_1357, Call(polyW_18, V.Undef, Q_1402));
_cont1397: ;
PostInc(ref s_1396, 1D);
}
}
Call(set_1349, V.Undef, Get(B_1345, "st"), ((V)("d")), (sd_1357 is var _t1440 && Truthy(_t1440) ? _t1440 : ((V)("M0 0"))));
ring_1358 = Fn((V _self1338, int _argc1441, V r_1447, V y_1448, V _a1445, V _a1446, V[] _rest1442) => {
V o_1449 = default;
o_1449 = Arr();
{
V k_1450 = default;
k_1450 = ((V)(0D));
while (true) {
if (!(LtN(k_1450, 40D))) break;
V f_1452 = default;
f_1452 = ((V)(((ToNum(k_1450) / 40D) * ToNum(TAU_9))));
Invoke(o_1449, "push", Call(PE_1354, V.Undef, ((V)((50D + (ToNum(r_1447) * FdLibm.Sin(ToNum(f_1452)))))), y_1448, ((V)((ToNum(r_1447) * FdLibm.Cos(ToNum(f_1452)))))));
PostInc(ref k_1450, 1D);
}
}
return o_1449;
return default;
}, 2, "", true);
Call(set_1349, V.Undef, Get(B_1345, "bed"), ((V)("d")), Call(polyW_18, V.Undef, Call(ring_1358, V.Undef, ((V)(34.2)), ((V)(40.6)))));
FR_1359 = Arr();
FRb_1360 = Arr();
FRl_1361 = Arr();
Invoke(Invoke(Get(SN_43, "h"), "frontArc", D_1346, ((V)(36D)), ((V)(41D)), ((V)(60D))), "forEach", Fn((V _self1338, int _argc1453, V f_1459, V _a1456, V _a1457, V _a1458, V[] _rest1454) => {
Invoke(FR_1359, "push", Call(PE_1354, V.Undef, ((V)((50D + (36.8 * FdLibm.Sin(ToNum(f_1459)))))), ((V)(39.2)), ((V)((36.8 * FdLibm.Cos(ToNum(f_1459)))))));
Invoke(FRb_1360, "push", Call(PE_1354, V.Undef, ((V)((50D + (36.1 * FdLibm.Sin(ToNum(f_1459)))))), ((V)(44.2)), ((V)((36.1 * FdLibm.Cos(ToNum(f_1459)))))));
Invoke(FRl_1361, "push", Call(PE_1354, V.Undef, ((V)((50D + (36.3 * FdLibm.Sin(ToNum(f_1459)))))), ((V)(40.5)), ((V)((36.3 * FdLibm.Cos(ToNum(f_1459)))))));
return default;
}, 1, "", true));
Call(set_1349, V.Undef, Get(B_1345, "rim"), ((V)("d")), (Call(polyW_18, V.Undef, Invoke(FR_1359, "concat", Invoke(Invoke(FRb_1360, "slice"), "reverse"))) is var _t1460 && Truthy(_t1460) ? _t1460 : ((V)("M0 0"))));
Call(set_1349, V.Undef, Get(B_1345, "rimL"), ((V)("d")), (Call(runs_21, V.Undef, FRl_1361, Invoke(FRl_1361, "map", Fn((V _self1338, int _argc1461, V _a1463, V _a1464, V _a1465, V _a1466, V[] _rest1462) => {
return (true ? V.True : V.False);
}, 0, "", true))) is var _t1467 && Truthy(_t1467) ? _t1467 : ((V)("M0 0"))));
if (GtN(Get(FR_1359, "length"), 2D)) {
V a_1468 = default;
V z_1469 = default;
V L_1470 = default;
a_1468 = GetIdx(FR_1359, 0D);
z_1469 = GetIdx(FR_1359, (ToNum(Get(FR_1359, "length")) - 1D));
L_1470 = (Lt(GetIdx(a_1468, 0D), GetIdx(z_1469, 0D)) ? FR_1359 : Invoke(Invoke(FR_1359, "slice"), "reverse"));
Call(set_1349, V.Undef, Get(Get(B_1345, "cl"), "p"), ((V)("d")), ((V)(string.Concat(new string[] { "M", ToStr(Call(r2_11, V.Undef, ((V)((ToNum(GetIdx(GetIdx(L_1470, 0D), 0D)) - 40D))))), " ", ToStr(Call(r2_11, V.Undef, Add(GetIdx(GetIdx(L_1470, 0D), 1D), ((V)(0.6))))), "L", ToStr(Call(r2_11, V.Undef, ((V)((ToNum(GetIdx(GetIdx(L_1470, 0D), 0D)) - 40D))))), " -200L", ToStr(Call(r2_11, V.Undef, Add(GetIdx(GetIdx(L_1470, (ToNum(Get(L_1470, "length")) - 1D)), 0D), ((V)(40D))))), " -200L", ToStr(Call(r2_11, V.Undef, Add(GetIdx(GetIdx(L_1470, (ToNum(Get(L_1470, "length")) - 1D)), 0D), ((V)(40D))))), " ", ToStr(Call(r2_11, V.Undef, Add(GetIdx(GetIdx(L_1470, (ToNum(Get(L_1470, "length")) - 1D)), 1D), ((V)(0.6))))), ToStr(Invoke(Invoke(Invoke(Invoke(L_1470, "slice"), "reverse"), "map", Fn((V _self1338, int _argc1471, V p_1477, V _a1474, V _a1475, V _a1476, V[] _rest1472) => {
return ((V)(string.Concat("L", ToStr(Call(r2_11, V.Undef, GetIdx(p_1477, 0D))), " ", ToStr(Call(r2_11, V.Undef, Add(GetIdx(p_1477, 1D), ((V)(0.6))))))));
}, 1, "", true)), "join", ((V)("")))), "Z" }))));
}
L_1362 = Invoke(Invoke(Get(B_1345, "K"), "map", Fn((V _self1338, int _argc1486, V k_1492, V _a1489, V _a1490, V _a1491, V[] _rest1487) => {
V hgt_1493 = default;
V jp_1494 = default;
V x_1495 = default;
V y_1496 = default;
V C_1497 = default;
V s_1498 = default;
V d_1499 = default;
hgt_1493 = Call(clamp_12, V.Undef, ((V)(((41D - ToNum(Get(k_1492, "y"))) / 28D))), ((V)(0D)), ((V)(1D)));
jp_1494 = ((V)((((ToNum(pop_1352) * ToNum(Get(k_1492, "hk"))) * (0.6 + (0.4 * FdLibm.Sin(ToNum(Add(((V)((ToNum(Get(D_1346, "ts")) * 9D))), Get(k_1492, "hk"))))))) + ((ToNum(fz_1353) * FdLibm.Sin(((ToNum(Get(D_1346, "ts")) * 37D) + (ToNum(Get(k_1492, "hk")) * 3D)))) * 0.6))));
x_1495 = Add(Add(Get(k_1492, "x"), ((V)(((ToNum(Get(D_1346, "ox")) * 0.25) * ToNum(hgt_1493))))), ((V)(((ToNum(fz_1353) * FdLibm.Sin(ToNum(Add(((V)((ToNum(Get(D_1346, "ts")) * 41D))), Get(k_1492, "hk"))))) * 0.5))));
y_1496 = ((V)(((ToNum(Get(k_1492, "y")) - ((ToNum(Get(D_1346, "oy")) * 0.3) * ToNum(hgt_1493))) - Max(0D, ToNum(jp_1494)))));
C_1497 = Call(PE_1354, V.Undef, x_1495, y_1496, Get(k_1492, "z"));
s_1498 = ((V)((ToNum(Get(k_1492, "s")) * ToNum(Get(D_1346, "kS")))));
d_1499 = ((V)(""));
Invoke(Get(k_1492, "B"), "forEach", Fn((V _self1338, int _argc1500, V b_1506, V _a1503, V _a1504, V _a1505, V[] _rest1501) => {
d_1499 = Add(d_1499, Call(circD_19, V.Undef, Arr(Add(GetIdx(C_1497, 0D), ((V)(((ToNum(GetIdx(b_1506, 0D)) * ToNum(s_1498)) * 0.55)))), Add(GetIdx(C_1497, 1D), ((V)(((ToNum(GetIdx(b_1506, 1D)) * ToNum(s_1498)) * 0.55))))), ((V)(((ToNum(GetIdx(b_1506, 2D)) * ToNum(s_1498)) * 0.55)))));
return default;
}, 1, "", true));
Call(set_1349, V.Undef, Get(k_1492, "e"), ((V)("d")), d_1499);
Call(set_1349, V.Undef, Get(k_1492, "dot"), ((V)("d")), Call(circD_19, V.Undef, Arr(Add(GetIdx(C_1497, 0D), ((V)(((ToNum(GetIdx(GetIdx(Get(k_1492, "B"), 1D), 0D)) * ToNum(s_1498)) * 0.3)))), Add(GetIdx(C_1497, 1D), ((V)((0.7 * ToNum(s_1498)))))), ((V)(((0.85 * ToNum(s_1498)) * 0.55)))));
return NewObj(3).Put("id", Get(k_1492, "id")).Put("e", Get(k_1492, "g")).Put("z", Call(Z3_1348, V.Undef, x_1495, y_1496, Get(k_1492, "z"))).V;
return default;
}, 1, "", true)), "sort", Fn((V _self1338, int _argc1478, V a_1484, V b_1485, V _a1482, V _a1483, V[] _rest1479) => {
return ((V)((ToNum(Get(a_1484, "z")) - ToNum(Get(b_1485, "z")))));
}, 2, "", true));
Invoke(SN_43, "order", Get(B_1345, "KG"), L_1362);
return default;
}, 2, "draw", false)).V);
Set(MODELS_42, "nori", NewObj(2).Put("setup", Fn((V _self1507, int _argc1508, V S_1514, V _a1511, V _a1512, V _a1513, V[] _rest1509) => {
V sk_1515 = default;
V O_1516 = default;
V T_1517 = default;
V b_1518 = default;
V rings_1519 = default;
V zF_1520 = default;
V GG_1521 = default;
V DC_1522 = default;
V BG_1523 = default;
V SG_1524 = default;
V swq_1525 = default;
V sh_1526 = default;
V SW_1527 = default;
V TOP_1528 = default;
V BK_1529 = default;
V n_1530 = default;
V bkg_1531 = default;
V FL_1532 = default;
V SAL_1533 = default;
V shd_1534 = default;
V FK_1535 = default;
if (_self1507.IsNullish) _self1507 = GlobalV;
{ V _t1536 = S_1514;
if (_t1536.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1536));
{ V _t1537 = Get(_t1536, "sk");
sk_1515 = _t1537; } }
O_1516 = Invoke(S_1514, "outline", sk_1515, ((V)(64D)));
T_1517 = ((V)(10.5));
b_1518 = ((V)(8D));
rings_1519 = Call(pillowRings_40, V.Undef, O_1516, T_1517, b_1518, ((V)(4D)));
zF_1520 = Call(pillowZ_41, V.Undef, O_1516, T_1517, b_1518);
Invoke(S_1514, "hide", Fn((V _self1507, int _argc1538, V q_1544, V _a1541, V _a1542, V _a1543, V[] _rest1539) => {
return (Get(q_1544, "inBody") is var _t1549 && !Truthy(_t1549) ? _t1549 : (((Invoke(S_1514, "dk", q_1544, ((V)("sal"))) is var _t1546 && Truthy(_t1546) ? _t1546 : ((SEqS(Get(q_1544, "tag"), "circle") ? V.True : V.False) is var _t1545 && !Truthy(_t1545) ? _t1545 : Invoke(NewRegExp(RX2, "^url", ""), "test", Invoke(S_1514, "f", q_1544)))) is var _t1547 && Truthy(_t1547) ? _t1547 : (SEqS(Invoke(S_1514, "f", q_1544), "#5aa04a") ? V.True : V.False)) is var _t1548 && Truthy(_t1548) ? _t1548 : (SEqS(Invoke(S_1514, "s", q_1544), "#ffd0da") ? V.True : V.False)));
}, 1, "", true));
GG_1521 = Invoke(S_1514, "g");
DC_1522 = Invoke(S_1514, "decals", Fn((V _self1507, int _argc1550, V q_1556, V _a1553, V _a1554, V _a1555, V[] _rest1551) => {
return (Get(q_1556, "inBody") is var _t1557 && !Truthy(_t1557) ? _t1557 : Invoke(S_1514, "dk", q_1556, ((V)("dc"))));
}, 1, "", true), GG_1521);
BG_1523 = Invoke(S_1514, "g");
SG_1524 = Invoke(S_1514, "g");
swq_1525 = Invoke(S_1514, "hide", Fn((V _self1507, int _argc1558, V q_1564, V _a1561, V _a1562, V _a1563, V[] _rest1559) => {
return (Get(q_1564, "inBody") is var _t1565 && !Truthy(_t1565) ? _t1565 : Invoke(S_1514, "dk", q_1564, ((V)("sw"))));
}, 1, "", true));
sh_1526 = Invoke(swq_1525, "find", Fn((V _self1507, int _argc1566, V q_1572, V _a1569, V _a1570, V _a1571, V[] _rest1567) => {
return Invoke(NewRegExp(RX2, "^url", ""), "test", Invoke(S_1514, "f", q_1572));
}, 1, "", true));
SW_1527 = NewObj(5).Put("st", Invoke(S_1514, "path", NewObj(1).Put("fill", (Truthy(sh_1526) ? Invoke(S_1514, "f", sh_1526) : ((V)("#2b4232")))).V, SG_1524)).Put("rim", Invoke(S_1514, "path", NewObj(2).Put("fill", ((V)("#0f1c13"))).Put("opacity", ((V)(0.45))).V, SG_1524)).Put("fib", Invoke(S_1514, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#46644e"))).Put("stroke-width", ((V)(0.45))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.7))).V, SG_1524)).Put("shn", Invoke(S_1514, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#86a88c"))).Put("stroke-width", ((V)(1.3))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.45))).V, SG_1524)).Put("edge", Invoke(S_1514, "path", NewObj(6).Put("fill", ((V)("none"))).Put("stroke", ((V)("#122017"))).Put("stroke-width", ((V)(0.7))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).Put("opacity", ((V)(0.7))).V, SG_1524)).V;
TOP_1528 = Arr();
Invoke(Arr(Arr(Arr(((V)(31.5)), ((V)(65.5))), Arr(((V)(41D)), ((V)(64D))), Arr(((V)(50D)), ((V)(64.6)))), Arr(Arr(((V)(50D)), ((V)(64.6))), Arr(((V)(59D)), ((V)(64D))), Arr(((V)(68.5)), ((V)(65.5))))), "forEach", Fn((V _self1507, int _argc1573, V _a1575, V h_1579, V _a1577, V _a1578, V[] _rest1574) => {
V p0_1582 = default;
V c_1584 = default;
V p1_1586 = default;
{ V _t1580 = ListOf(_a1575);
{ V _t1581 = GetIdx(_t1580, 0D);
p0_1582 = _t1581; }
{ V _t1583 = GetIdx(_t1580, 1D);
c_1584 = _t1583; }
{ V _t1585 = GetIdx(_t1580, 2D);
p1_1586 = _t1585; }
}
{
V k_1587 = default;
k_1587 = ((V)((Truthy(h_1579) ? 1D : 0D)));
while (true) {
if (!(LeN(k_1587, 12D))) break;
V t_1589 = default;
V u_1590 = default;
t_1589 = ((V)((ToNum(k_1587) / 12D)));
u_1590 = ((V)((1D - ToNum(t_1589))));
Invoke(TOP_1528, "push", Arr(((V)(((((ToNum(u_1590) * ToNum(u_1590)) * ToNum(GetIdx(p0_1582, 0D))) + (((2D * ToNum(u_1590)) * ToNum(t_1589)) * ToNum(GetIdx(c_1584, 0D)))) + ((ToNum(t_1589) * ToNum(t_1589)) * ToNum(GetIdx(p1_1586, 0D)))))), ((V)(((((ToNum(u_1590) * ToNum(u_1590)) * ToNum(GetIdx(p0_1582, 1D))) + (((2D * ToNum(u_1590)) * ToNum(t_1589)) * ToNum(GetIdx(c_1584, 1D)))) + ((ToNum(t_1589) * ToNum(t_1589)) * ToNum(GetIdx(p1_1586, 1D))))))));
PostInc(ref k_1587, 1D);
}
}
return default;
}, 2, "", true));
Set(SW_1527, "yt", Fn((V _self1507, int _argc1591, V x_1597, V _a1594, V _a1595, V _a1596, V[] _rest1592) => {
if (Le(x_1597, GetIdx(GetIdx(TOP_1528, 0D), 0D))) {
return GetIdx(GetIdx(TOP_1528, 0D), 1D);
}
{
V k_1598 = default;
k_1598 = ((V)(1D));
while (true) {
if (!(Lt(k_1598, Get(TOP_1528, "length")))) break;
if (Le(x_1597, GetIdx(GetK(TOP_1528, k_1598), 0D))) {
V a_1600 = default;
V c_1601 = default;
V t_1602 = default;
a_1600 = GetIdx(TOP_1528, (ToNum(k_1598) - 1D));
c_1601 = GetK(TOP_1528, k_1598);
t_1602 = ((V)(((ToNum(x_1597) - ToNum(GetIdx(a_1600, 0D))) / ToNum((((V)((ToNum(GetIdx(c_1601, 0D)) - ToNum(GetIdx(a_1600, 0D))))) is var _t1603 && Truthy(_t1603) ? _t1603 : ((V)(1D)))))));
return Add(GetIdx(a_1600, 1D), ((V)(((ToNum(GetIdx(c_1601, 1D)) - ToNum(GetIdx(a_1600, 1D))) * ToNum(t_1602)))));
}
PostInc(ref k_1598, 1D);
}
}
return GetIdx(GetIdx(TOP_1528, (ToNum(Get(TOP_1528, "length")) - 1D)), 1D);
return default;
}, 1, "", true));
BK_1529 = Arr();
n_1530 = ((V)(0D));
while ((LtN(Get(BK_1529, "length"), 12D) && LtN(n_1530, 400D))) {
V x_1604 = default;
V y_1605 = default;
PostInc(ref n_1530, 1D);
x_1604 = ((V)((31D + (ToNum(Call(rnd_22, V.Undef, ((V)((ToNum(n_1530) * 3.3))))) * 38D))));
y_1605 = ((V)((46D + (ToNum(Call(rnd_22, V.Undef, ((V)((ToNum(n_1530) * 7.1))))) * 18D))));
if (Truthy(Invoke(BK_1529, "some", Fn((V _self1507, int _argc1606, V p_1612, V _a1609, V _a1610, V _a1611, V[] _rest1607) => {
return ((Hypot((ToNum(GetIdx(p_1612, 0D)) - ToNum(x_1604)), (ToNum(GetIdx(p_1612, 1D)) - ToNum(y_1605))) < 4.6) ? V.True : V.False);
}, 1, "", true)))) {
continue;
}
Invoke(BK_1529, "push", Arr(x_1604, y_1605, ((V)((ToNum(Call(rnd_22, V.Undef, ((V)((ToNum(n_1530) * 1.9))))) * System.Math.PI)))));
}
bkg_1531 = Call(el_14, V.Undef, ((V)("path")), NewObj(3).Put("fill", ((V)("#ffffff"))).Put("stroke", ((V)("#ddd5c3"))).Put("stroke-width", ((V)(0.35))).V, BG_1523);
FL_1532 = Arr(Arr(((V)(43.92)), ((V)(18.79)), ((V)(2.48)), ((V)("#f8b897")), ((V)(1D)), ((V)(2.64))), Arr(((V)(46.89)), ((V)(18.71)), ((V)(2.48)), ((V)("#e97c55")), ((V)(1D)), ((V)(2.64))), Arr(((V)(50.17)), ((V)(18.41)), ((V)(2.37)), ((V)("#e97c55")), ((V)(1D)), ((V)(1.22))), Arr(((V)(53.59)), ((V)(18.65)), ((V)(2.2)), ((V)("#ee8a62")), ((V)(1D)), ((V)(2.49))), Arr(((V)(57.12)), ((V)(18.06)), ((V)(2.28)), ((V)("#f39a72")), ((V)(1D)), ((V)(1.32))), Arr(((V)(45.78)), ((V)(15.18)), ((V)(2.06)), ((V)("#f39a72")), ((V)(1D)), ((V)((-1.95)))), Arr(((V)(48.98)), ((V)(15.41)), ((V)(1.85)), ((V)("#f8b897")), ((V)(0D)), ((V)((-0.96)))), Arr(((V)(52.94)), ((V)(15.17)), ((V)(2.03)), ((V)("#f6ad8a")), ((V)(1D)), ((V)((-1.24)))), Arr(((V)(56.3)), ((V)(15.08)), ((V)(2.16)), ((V)("#e97c55")), ((V)(1D)), ((V)((-0.89)))), Arr(((V)(47.11)), ((V)(12.8)), ((V)(1.62)), ((V)("#e97c55")), ((V)(0D)), ((V)(1.24))), Arr(((V)(51.35)), ((V)(12.56)), ((V)(1.67)), ((V)("#f8b897")), ((V)(0D)), ((V)(0.66))), Arr(((V)(54.4)), ((V)(12.22)), ((V)(1.92)), ((V)("#f39a72")), ((V)(1D)), ((V)(1.1))), Arr(((V)(50.85)), ((V)(10.35)), ((V)(1.53)), ((V)("#f8b897")), ((V)(0D)), ((V)(0D))));
SAL_1533 = Invoke(S_1514, "g");
shd_1534 = Invoke(S_1514, "path", NewObj(2).Put("fill", ((V)("#cfc6b2"))).Put("opacity", ((V)(0.4))).V, SAL_1533);
FK_1535 = Invoke(FL_1532, "map", Fn((V _self1507, int _argc1613, V _a1615, V k_1619, V _a1617, V _a1618, V[] _rest1614) => {
V g_1633 = default;
V x_1622 = default;
V y_1624 = default;
V r_1626 = default;
V c_1628 = default;
V ft_1630 = default;
V z_1632 = default;
{ V _t1620 = ListOf(_a1615);
{ V _t1621 = GetIdx(_t1620, 0D);
x_1622 = _t1621; }
{ V _t1623 = GetIdx(_t1620, 1D);
y_1624 = _t1623; }
{ V _t1625 = GetIdx(_t1620, 2D);
r_1626 = _t1625; }
{ V _t1627 = GetIdx(_t1620, 3D);
c_1628 = _t1627; }
{ V _t1629 = GetIdx(_t1620, 4D);
ft_1630 = _t1629; }
{ V _t1631 = GetIdx(_t1620, 5D);
z_1632 = _t1631; }
}
g_1633 = Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, SAL_1533);
return NewObj(9).Put("k", k_1619).Put("x", x_1622).Put("y", y_1624).Put("r", r_1626).Put("z", z_1632).Put("rot", ((V)(((ToNum(Call(rnd_22, V.Undef, ((V)((ToNum(k_1619) * 3.1))))) - 0.5) * 1.3)))).Put("g", g_1633).Put("b", Call(el_14, V.Undef, ((V)("path")), NewObj(4).Put("fill", c_1628).Put("stroke", ((V)("#cf6a44"))).Put("stroke-width", ((V)(0.3))).Put("stroke-opacity", ((V)(0.5))).V, g_1633)).Put("f", (Truthy(ft_1630) ? Call(el_14, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffe6d8"))).Put("stroke-width", ((V)(0.42))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.8))).V, g_1633) : V.Null)).V;
return default;
}, 2, "", true));
return NewObj(20).Put("O", O_1516).Put("T", T_1517).Put("b", b_1518).Put("rings", rings_1519).Put("zF", zF_1520).Put("DC", DC_1522).Put("SW", SW_1527).Put("BG", BG_1523).Put("bkg", bkg_1531).Put("BK", BK_1529).Put("SAL", SAL_1533).Put("shd", shd_1534).Put("FK", FK_1535).Put("slab", ((V)(1D))).Put("rx", ((V)(38D))).Put("ya", ((V)(20D))).Put("yb", ((V)(86D))).Put("rT", Fn((V _self1507, int _argc1634, V y_1640, V _a1637, V _a1638, V _a1639, V[] _rest1635) => {
return Call(halfW_38, V.Undef, O_1516, y_1640);
}, 1, "rT", true)).Put("zAt", Fn((V _self1507, int _argc1641, V x_1647, V y_1648, V _a1645, V _a1646, V[] _rest1642) => {
return Call(zF_1520, V.Undef, x_1647, y_1648);
}, 2, "zAt", true)).Put("zE", Fn((V _self1507, int _argc1649, V dx_1655, V dy_1656, V _a1653, V _a1654, V[] _rest1650) => {
return Add(Call(zF_1520, V.Undef, Add(Get(S_1514, "HX"), dx_1655), Add(Get(S_1514, "HY"), dy_1656)), ((V)(0.3)));
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self1657, int _argc1658, V B_1664, V D_1665, V _a1662, V _a1663, V[] _rest1659) => {
V P3_1666 = default;
V set_1667 = default;
V zF_1668 = default;
V umeV_1669 = default;
V nw_1670 = default;
V fr_1671 = default;
V s_1672 = default;
V S2_1673 = default;
V W_1674 = default;
V YB_1675 = default;
V xl_1676 = default;
V xr_1677 = default;
V NU_1678 = default;
V e_1679 = default;
V nrm_1680 = default;
V line_1681 = default;
V L_1682 = default;
V lerp_1683 = default;
V dS_1684 = default;
V dR_1685 = default;
V fr2_1686 = default;
V ti_1687 = default;
V fd_1688 = default;
V PS_1689 = default;
V sj_1690 = default;
V kS_1691 = default;
V M2_1692 = default;
V flk_1693 = default;
V fatL_1694 = default;
if (_self1657.IsNullish) _self1657 = GlobalV;
{ V _t1695 = D_1665;
if (_t1695.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1695));
{ V _t1696 = Get(_t1695, "P3");
P3_1666 = _t1696; }
{ V _t1697 = Get(_t1695, "set");
set_1667 = _t1697; } }
zF_1668 = Get(B_1664, "zF");
umeV_1669 = Call(clamp_12, V.Undef, Invoke(D_1665, "bv", ((V)("ume"))), ((V)(0D)), ((V)(1.2)));
nw_1670 = ((V)((ToNum(Call(clamp_12, V.Undef, Invoke(D_1665, "bv", ((V)("nwr"))), ((V)((-1D))), ((V)(1D)))) * 3D)));
Set(B_1664, "d", Invoke(D_1665, "hull", Call(pillowHull_46, V.Undef, D_1665, Get(B_1664, "rings"), ((V)(0D)), ((V)(1D)), Call(pillowHull_46, V.Undef, D_1665, Get(B_1664, "rings"), ((V)(0D)), ((V)((-1D)))))));
fr_1671 = (GeN(Get(D_1665, "front"), 0D) ? V.True : V.False);
s_1672 = ((V)((Truthy(fr_1671) ? 1D : (-1D))));
S2_1673 = Fn((V _self1657, int _argc1698, V x_1704, V y_1705, V dz_1706, V _a1703, V[] _rest1699) => {
return Call(P3_1666, V.Undef, x_1704, y_1705, ((V)((ToNum(s_1672) * ToNum(Add(Call(zF_1668, V.Undef, x_1704, y_1705), dz_1706))))));
}, 3, "", true);
Invoke(Get(B_1664, "DC"), "forEach", Fn((V _self1657, int _argc1707, V o_1713, V _a1710, V _a1711, V _a1712, V[] _rest1708) => {
return Call(set_1667, V.Undef, Get(o_1713, "e"), ((V)("d")), Call(decD_26, V.Undef, o_1713, Fn((V _self1657, int _argc1714, V x_1720, V y_1721, V _a1718, V _a1719, V[] _rest1715) => {
return Call(S2_1673, V.Undef, x_1720, y_1721, ((V)(0.2)));
}, 2, "", true)));
}, 1, "", true));
Invoke(Get(B_1664, "BG"), "setAttribute", ((V)("opacity")), ((V)((Truthy(fr_1671) ? 0D : 1D))));
if (!(Truthy(fr_1671))) {
Call(set_1667, V.Undef, Get(B_1664, "bkg"), ((V)("d")), Invoke(Invoke(Get(B_1664, "BK"), "map", Fn((V _self1657, int _argc1722, V _a1724, V _a1725, V _a1726, V _a1727, V[] _rest1723) => {
V x_1730 = default;
V y_1732 = default;
V a_1734 = default;
{ V _t1728 = ListOf(_a1724);
{ V _t1729 = GetIdx(_t1728, 0D);
x_1730 = _t1729; }
{ V _t1731 = GetIdx(_t1728, 1D);
y_1732 = _t1731; }
{ V _t1733 = GetIdx(_t1728, 2D);
a_1734 = _t1733; }
}
return Call(polyW_18, V.Undef, Array_from(NewObj(1).Put("length", ((V)(10D))).V, Fn((V _self1657, int _argc1735, V __1741, V k_1742, V _a1739, V _a1740, V[] _rest1736) => {
V f_1743 = default;
f_1743 = ((V)(((ToNum(k_1742) / 10D) * ToNum(TAU_9))));
return Call(S2_1673, V.Undef, ((V)((ToNum(Add(x_1730, ((V)(((1.65 * FdLibm.Cos(ToNum(f_1743))) * FdLibm.Cos(ToNum(a_1734))))))) - ((0.8 * FdLibm.Sin(ToNum(f_1743))) * FdLibm.Sin(ToNum(a_1734)))))), Add(Add(y_1732, ((V)(((1.65 * FdLibm.Cos(ToNum(f_1743))) * FdLibm.Sin(ToNum(a_1734)))))), ((V)(((0.8 * FdLibm.Sin(ToNum(f_1743))) * FdLibm.Cos(ToNum(a_1734)))))), ((V)(0.2)));
return default;
}, 2, "", true)));
}, 1, "", true)), "join", ((V)(""))));
}
W_1674 = Get(B_1664, "SW");
YB_1675 = ((V)(87.5));
xl_1676 = Fn((V _self1657, int _argc1744, V y_1750, V _a1747, V _a1748, V _a1749, V[] _rest1745) => {
return ((V)((31.5 - ((2D * (ToNum(y_1750) - 65.5)) / 22D))));
}, 1, "", true);
xr_1677 = Fn((V _self1657, int _argc1751, V y_1757, V _a1754, V _a1755, V _a1756, V[] _rest1752) => {
return ((V)((68.5 + ((2D * (ToNum(y_1757) - 65.5)) / 22D))));
}, 1, "", true);
NU_1678 = ((V)(16D));
e_1679 = ((V)(0.25));
nrm_1680 = Fn((V _self1657, int _argc1758, V x_1764, V y_1765, V z_1766, V _a1763, V[] _rest1759) => {
V gx_1767 = default;
V gy_1768 = default;
V sg_1769 = default;
V L__1770 = default;
if ((System.Math.Abs(ToNum(z_1766)) < 0.05)) {
return Arr(((V)(0D)), ((V)(1D)), ((V)(0D)));
}
gx_1767 = ((V)(((ToNum(Call(zF_1668, V.Undef, Add(x_1764, e_1679), y_1765)) - ToNum(Call(zF_1668, V.Undef, ((V)((ToNum(x_1764) - ToNum(e_1679)))), y_1765))) / (2D * ToNum(e_1679)))));
gy_1768 = ((V)(((ToNum(Call(zF_1668, V.Undef, x_1764, Add(y_1765, e_1679))) - ToNum(Call(zF_1668, V.Undef, x_1764, ((V)((ToNum(y_1765) - ToNum(e_1679))))))) / (2D * ToNum(e_1679)))));
sg_1769 = ((V)((GtN(z_1766, 0D) ? 1D : (-1D))));
L__1770 = ((V)(Hypot(ToNum(gx_1767), ToNum(gy_1768), 1D)));
return Arr(((V)((((-ToNum(gx_1767)) * ToNum(sg_1769)) / ToNum(L__1770)))), ((V)((((-ToNum(gy_1768)) * ToNum(sg_1769)) / ToNum(L__1770)))), ((V)((ToNum(sg_1769) / ToNum(L__1770)))));
return default;
}, 3, "", true);
line_1681 = Fn((V _self1657, int _argc1771, V u_1777, V _a1774, V _a1775, V _a1776, V[] _rest1772) => {
V x0_1778 = default;
V y0_1779 = default;
V P_1780 = default;
V Y_1781 = default;
x0_1778 = Add(Call(xl_1676, V.Undef, ((V)(65D))), ((V)((ToNum(u_1777) * (ToNum(Call(xr_1677, V.Undef, ((V)(65D)))) - ToNum(Call(xl_1676, V.Undef, ((V)(65D)))))))));
y0_1779 = Add(Invoke(W_1674, "yt", x0_1778), nw_1670);
P_1780 = Arr();
Y_1781 = Arr();
{
V j_1782 = default;
j_1782 = ((V)(0D));
while (true) {
if (!(LeN(j_1782, 6D))) break;
Invoke(Y_1781, "push", Arr(Add(y0_1779, ((V)(((((ToNum(YB_1675) - ToNum(Get(B_1664, "b"))) - ToNum(y0_1779)) * ToNum(j_1782)) / 6D)))), ((V)(1D))));
PostInc(ref j_1782, 1D);
}
}
{
V j_1784 = default;
j_1784 = ((V)(1D));
while (true) {
if (!(LeN(j_1784, 6D))) break;
Invoke(Y_1781, "push", Arr(((V)((ToNum(YB_1675) - (ToNum(Get(B_1664, "b")) * (1D - FdLibm.Cos((((1D - (ToNum(j_1784) / 6D)) * System.Math.PI) / 2D))))))), ((V)(1D))));
PostInc(ref j_1784, 1D);
}
}
{
V j_1786 = default;
j_1786 = ((V)(1D));
while (true) {
if (!(LeN(j_1786, 6D))) break;
Invoke(Y_1781, "push", Arr(((V)((ToNum(YB_1675) - (ToNum(Get(B_1664, "b")) * (1D - FdLibm.Cos((((ToNum(j_1786) / 6D) * System.Math.PI) / 2D))))))), ((V)((-1D)))));
PostInc(ref j_1786, 1D);
}
}
{
V j_1788 = default;
j_1788 = ((V)(1D));
while (true) {
if (!(LeN(j_1788, 6D))) break;
Invoke(Y_1781, "push", Arr(((V)(((ToNum(YB_1675) - ToNum(Get(B_1664, "b"))) + (((ToNum(y0_1779) - (ToNum(YB_1675) - ToNum(Get(B_1664, "b")))) * ToNum(j_1788)) / 6D)))), ((V)((-1D)))));
PostInc(ref j_1788, 1D);
}
}
Invoke(Y_1781, "forEach", Fn((V _self1657, int _argc1790, V _a1792, V j_1796, V _a1794, V _a1795, V[] _rest1791) => {
V yy_1802 = default;
V x_1803 = default;
V z_1804 = default;
V n_1805 = default;
V y_1799 = default;
V sg_1801 = default;
{ V _t1797 = ListOf(_a1792);
{ V _t1798 = GetIdx(_t1797, 0D);
y_1799 = _t1798; }
{ V _t1800 = GetIdx(_t1797, 1D);
sg_1801 = _t1800; }
}
yy_1802 = ((V)(Min(ToNum(y_1799), (ToNum(YB_1675) - 0.02))));
x_1803 = Add(Call(xl_1676, V.Undef, yy_1802), ((V)((ToNum(u_1777) * (ToNum(Call(xr_1677, V.Undef, yy_1802)) - ToNum(Call(xl_1676, V.Undef, yy_1802)))))));
z_1804 = ((V)((ToNum(sg_1801) * ToNum(Call(zF_1668, V.Undef, x_1803, yy_1802)))));
n_1805 = Call(nrm_1680, V.Undef, x_1803, yy_1802, z_1804);
Invoke(P_1780, "push", NewObj(3).Put("p", Call(P3_1666, V.Undef, x_1803, yy_1802, z_1804)).Put("f", Invoke(D_1665, "facing", x_1803, yy_1802, z_1804, GetIdx(n_1805, 0D), GetIdx(n_1805, 1D), GetIdx(n_1805, 2D))).Put("rim", ((GtN(j_1796, 6D) && LtN(j_1796, 19D)) ? V.True : V.False)).V);
return default;
}, 2, "", true));
return P_1780;
return default;
}, 1, "", true);
L_1682 = Arr();
{
V i_1806 = default;
i_1806 = ((V)(0D));
while (true) {
if (!(Le(i_1806, NU_1678))) break;
Invoke(L_1682, "push", Call(line_1681, V.Undef, ((V)((ToNum(i_1806) / ToNum(NU_1678))))));
PostInc(ref i_1806, 1D);
}
}
lerp_1683 = Fn((V _self1657, int _argc1808, V a_1814, V c_1815, V t_1816, V _a1813, V[] _rest1809) => {
return Arr(Add(GetIdx(a_1814, 0D), ((V)(((ToNum(GetIdx(c_1815, 0D)) - ToNum(GetIdx(a_1814, 0D))) * ToNum(t_1816))))), Add(GetIdx(a_1814, 1D), ((V)(((ToNum(GetIdx(c_1815, 1D)) - ToNum(GetIdx(a_1814, 1D))) * ToNum(t_1816))))));
}, 3, "", true);
dS_1684 = ((V)(""));
dR_1685 = ((V)(""));
{
V i_1817 = default;
i_1817 = ((V)(0D));
while (true) {
if (!(Lt(i_1817, NU_1678))) break;
V A_1819 = default;
V C_1820 = default;
V G_1821 = default;
V n_1822 = default;
V G0_1823 = default;
V j0_1824 = default;
V j1_1825 = default;
V side_1826 = default;
V sa_1827 = default;
V sc_1828 = default;
V ra_1829 = default;
V rc_1830 = default;
A_1819 = GetK(L_1682, i_1817);
C_1820 = GetK(L_1682, Add(i_1817, ((V)(1D))));
G_1821 = Invoke(A_1819, "map", Fn((V _self1657, int _argc1831, V q_1837, V j_1838, V _a1835, V _a1836, V[] _rest1832) => {
return ((V)((ToNum(Add(Get(q_1837, "f"), Get(GetK(C_1820, j_1838), "f"))) / 2D)));
}, 2, "", true));
n_1822 = Get(G_1821, "length");
G0_1823 = ((V)(0.05));
j0_1824 = Invoke(G_1821, "findIndex", Fn((V _self1657, int _argc1839, V g_1845, V _a1842, V _a1843, V _a1844, V[] _rest1840) => {
return (Gt(g_1845, G0_1823) ? V.True : V.False);
}, 1, "", true));
if (LtN(j0_1824, 0D)) {
goto _cont1818;
}
j1_1825 = j0_1824;
while ((Lt(Add(j1_1825, ((V)(1D))), n_1822) && Gt(GetK(G_1821, Add(j1_1825, ((V)(1D)))), G0_1823))) {
PostInc(ref j1_1825, 1D);
}
side_1826 = Fn((V _self1657, int _argc1846, V pick_1852, V rimOnly_1853, V _a1850, V _a1851, V[] _rest1847) => {
V o_1854 = default;
V a0_1855 = default;
V a1_1856 = default;
V cut_1857 = default;
o_1854 = Arr();
a0_1855 = j0_1824;
a1_1856 = j1_1825;
if (Truthy(rimOnly_1853)) {
while ((Le(a0_1855, a1_1856) && !(Truthy(Get(GetK(A_1819, a0_1855), "rim"))))) {
PostInc(ref a0_1855, 1D);
}
while ((Ge(a1_1856, a0_1855) && !(Truthy(Get(GetK(A_1819, a1_1856), "rim"))))) {
PostInc(ref a1_1856, -1D);
}
if (Gt(a0_1855, a1_1856)) {
return V.Null;
}
}
cut_1857 = Fn((V _self1657, int _argc1858, V j_1864, V k_1865, V _a1862, V _a1863, V[] _rest1859) => {
V t_1866 = default;
t_1866 = ((V)(((ToNum(GetK(G_1821, j_1864)) - ToNum(G0_1823)) / ToNum((((V)((ToNum(GetK(G_1821, j_1864)) - ToNum(GetK(G_1821, k_1865))))) is var _t1867 && Truthy(_t1867) ? _t1867 : ((V)(1D)))))));
return Call(lerp_1683, V.Undef, Get(GetK(pick_1852, j_1864), "p"), Get(GetK(pick_1852, k_1865), "p"), Call(clamp_12, V.Undef, t_1866, ((V)(0D)), ((V)(1D))));
return default;
}, 2, "", true);
if ((!(Truthy(rimOnly_1853)) && GtN(j0_1824, 0D))) {
Invoke(o_1854, "push", Call(cut_1857, V.Undef, j0_1824, ((V)((ToNum(j0_1824) - 1D)))));
}
{
V j_1868 = default;
j_1868 = a0_1855;
while (true) {
if (!(Le(j_1868, a1_1856))) break;
Invoke(o_1854, "push", Get(GetK(pick_1852, j_1868), "p"));
PostInc(ref j_1868, 1D);
}
}
if ((!(Truthy(rimOnly_1853)) && LtN(j1_1825, (ToNum(n_1822) - 1D)))) {
Invoke(o_1854, "push", Call(cut_1857, V.Undef, j1_1825, Add(j1_1825, ((V)(1D)))));
}
return o_1854;
return default;
}, 2, "", true);
sa_1827 = Call(side_1826, V.Undef, A_1819);
sc_1828 = Call(side_1826, V.Undef, C_1820);
dS_1684 = Add(dS_1684, Call(polyW_18, V.Undef, Invoke(sa_1827, "concat", Invoke(Invoke(sc_1828, "slice"), "reverse"))));
ra_1829 = Call(side_1826, V.Undef, A_1819, ((V)(1D)));
rc_1830 = Call(side_1826, V.Undef, C_1820, ((V)(1D)));
if (Truthy(((ra_1829 is var _t1870 && !Truthy(_t1870) ? _t1870 : rc_1830) is var _t1871 && !Truthy(_t1871) ? _t1871 : (GtN(Get(ra_1829, "length"), 1D) ? V.True : V.False)))) {
dR_1685 = Add(dR_1685, Call(polyW_18, V.Undef, Invoke(ra_1829, "concat", Invoke(Invoke(rc_1830, "slice"), "reverse"))));
}
_cont1818: ;
PostInc(ref i_1817, 1D);
}
}
Call(set_1667, V.Undef, Get(W_1674, "st"), ((V)("d")), (dS_1684 is var _t1872 && Truthy(_t1872) ? _t1872 : ((V)("M0 0"))));
Call(set_1667, V.Undef, Get(W_1674, "rim"), ((V)("d")), (dR_1685 is var _t1873 && Truthy(_t1873) ? _t1873 : ((V)("M0 0"))));
fr2_1686 = (Ge(Get(GetIdx(GetIdx(L_1682, ((double)(ToInt32(ToNum(NU_1678)) >> (int)(ToUint32(1D) & 31)))), 0D), "f"), Get(GetIdx(GetIdx(L_1682, ((double)(ToInt32(ToNum(NU_1678)) >> (int)(ToUint32(1D) & 31)))), 24D), "f")) ? V.True : V.False);
ti_1687 = ((V)((Truthy(fr2_1686) ? 0D : 24D)));
Call(set_1667, V.Undef, Get(W_1674, "edge"), ((V)("d")), (Call(runs_21, V.Undef, Invoke(L_1682, "map", Fn((V _self1657, int _argc1874, V P_1880, V _a1877, V _a1878, V _a1879, V[] _rest1875) => {
return Get(GetK(P_1880, ti_1687), "p");
}, 1, "", true)), Invoke(L_1682, "map", Fn((V _self1657, int _argc1881, V P_1887, V _a1884, V _a1885, V _a1886, V[] _rest1882) => {
return (GtN(Get(GetK(P_1887, ti_1687), "f"), 0.05) ? V.True : V.False);
}, 1, "", true))) is var _t1888 && Truthy(_t1888) ? _t1888 : ((V)("M0 0"))));
fd_1688 = ((V)(""));
Invoke(Arr(((V)(0.084)), ((V)(0.216)), ((V)(0.354)), ((V)(0.495)), ((V)(0.641)), ((V)(0.781)), ((V)(0.916))), "forEach", Fn((V _self1657, int _argc1889, V u_1895, V _a1892, V _a1893, V _a1894, V[] _rest1890) => {
V P_1896 = default;
P_1896 = Call(line_1681, V.Undef, u_1895);
fd_1688 = Add(fd_1688, Call(runs_21, V.Undef, Invoke(P_1896, "map", Fn((V _self1657, int _argc1897, V q_1903, V _a1900, V _a1901, V _a1902, V[] _rest1898) => {
return Get(q_1903, "p");
}, 1, "", true)), Invoke(P_1896, "map", Fn((V _self1657, int _argc1904, V q_1910, V j_1911, V _a1908, V _a1909, V[] _rest1905) => {
return (((GtN(Get(q_1910, "f"), 0.08) && GtN(j_1911, 0D)) && LtN(j_1911, 24D)) ? V.True : V.False);
}, 2, "", true))));
return default;
}, 1, "", true));
Call(set_1667, V.Undef, Get(W_1674, "fib"), ((V)("d")), (fd_1688 is var _t1912 && Truthy(_t1912) ? _t1912 : ((V)("M0 0"))));
PS_1689 = Call(line_1681, V.Undef, ((V)((Truthy(fr2_1686) ? 0.06 : 0.94))));
sj_1690 = (Truthy(fr2_1686) ? Arr(((V)(1D)), ((V)(5D))) : Arr(((V)(19D)), ((V)(23D))));
Call(set_1667, V.Undef, Get(W_1674, "shn"), ((V)("d")), (Call(runs_21, V.Undef, Invoke(PS_1689, "map", Fn((V _self1657, int _argc1913, V q_1919, V _a1916, V _a1917, V _a1918, V[] _rest1914) => {
return Get(q_1919, "p");
}, 1, "", true)), Invoke(PS_1689, "map", Fn((V _self1657, int _argc1920, V q_1926, V j_1927, V _a1924, V _a1925, V[] _rest1921) => {
return (((GtN(Get(q_1926, "f"), 0.05) && Ge(j_1927, GetIdx(sj_1690, 0D))) && Le(j_1927, GetIdx(sj_1690, 1D))) ? V.True : V.False);
}, 2, "", true))) is var _t1928 && Truthy(_t1928) ? _t1928 : ((V)("M0 0"))));
kS_1691 = Get(D_1665, "kS");
M2_1692 = Fn((V _self1657, int _argc1929, V a_1935, V c_1936, V _a1933, V _a1934, V[] _rest1930) => {
return Arr(((V)((ToNum(Add(GetIdx(a_1935, 0D), GetIdx(c_1936, 0D))) / 2D))), ((V)((ToNum(Add(GetIdx(a_1935, 1D), GetIdx(c_1936, 1D))) / 2D))));
}, 2, "", true);
flk_1693 = Fn((V _self1657, int _argc1937, V o_1943, V C_1944, V r_1945, V _a1942, V[] _rest1938) => {
V P_1946 = default;
V d_1947 = default;
P_1946 = Arr();
{
V i_1948 = default;
i_1948 = ((V)(0D));
while (true) {
if (!(LtN(i_1948, 7D))) break;
V a_1950 = default;
V rr_1951 = default;
V x_1952 = default;
V y_1953 = default;
a_1950 = ((V)(((ToNum(i_1948) * ToNum(TAU_9)) / 7D)));
rr_1951 = ((V)((ToNum(r_1945) * (0.72 + (0.5 * ToNum(Call(rnd_22, V.Undef, Add(((V)((ToNum(Get(o_1943, "k")) * 7D))), i_1948))))))));
x_1952 = ((V)(((ToNum(rr_1951) * FdLibm.Cos(ToNum(a_1950))) * 1.32)));
y_1953 = ((V)(((ToNum(rr_1951) * FdLibm.Sin(ToNum(a_1950))) * 0.74)));
Invoke(P_1946, "push", Arr(((V)((ToNum(Add(GetIdx(C_1944, 0D), ((V)((ToNum(x_1952) * FdLibm.Cos(ToNum(Get(o_1943, "rot")))))))) - (ToNum(y_1953) * FdLibm.Sin(ToNum(Get(o_1943, "rot"))))))), Add(Add(GetIdx(C_1944, 1D), ((V)((ToNum(x_1952) * FdLibm.Sin(ToNum(Get(o_1943, "rot"))))))), ((V)((ToNum(y_1953) * FdLibm.Cos(ToNum(Get(o_1943, "rot")))))))));
PostInc(ref i_1948, 1D);
}
}
d_1947 = ((V)(string.Concat("M", ToStr(Call(pt_15, V.Undef, Call(M2_1692, V.Undef, GetIdx(P_1946, 6D), GetIdx(P_1946, 0D)))))));
{
V i_1954 = default;
i_1954 = ((V)(0D));
while (true) {
if (!(LtN(i_1954, 7D))) break;
d_1947 = ((V)(string.Concat(new string[] { ToStr(d_1947), "Q", ToStr(Call(pt_15, V.Undef, GetK(P_1946, i_1954))), " ", ToStr(Call(pt_15, V.Undef, Call(M2_1692, V.Undef, GetK(P_1946, i_1954), GetIdx(P_1946, (ToNum(Add(i_1954, ((V)(1D)))) % 7D))))) })));
PostInc(ref i_1954, 1D);
}
}
return ((V)(string.Concat(ToStr(d_1947), "Z")));
return default;
}, 3, "", true);
fatL_1694 = Fn((V _self1657, int _argc1956, V o_1962, V C_1963, V r_1964, V _a1961, V[] _rest1957) => {
V q_1965 = default;
q_1965 = Fn((V _self1657, int _argc1966, V x_1972, V y_1973, V _a1970, V _a1971, V[] _rest1967) => {
return Arr(((V)((ToNum(Add(GetIdx(C_1963, 0D), ((V)((ToNum(x_1972) * FdLibm.Cos(ToNum(Get(o_1962, "rot")))))))) - (ToNum(y_1973) * FdLibm.Sin(ToNum(Get(o_1962, "rot"))))))), Add(Add(GetIdx(C_1963, 1D), ((V)((ToNum(x_1972) * FdLibm.Sin(ToNum(Get(o_1962, "rot"))))))), ((V)((ToNum(y_1973) * FdLibm.Cos(ToNum(Get(o_1962, "rot"))))))));
}, 2, "", true);
return ((V)(string.Concat(new string[] { "M", ToStr(Call(pt_15, V.Undef, Call(q_1965, V.Undef, ((V)(((-0.75) * ToNum(r_1964)))), ((V)(((-0.2) * ToNum(r_1964))))))), "Q", ToStr(Call(pt_15, V.Undef, Call(q_1965, V.Undef, ((V)(0D)), ((V)((0.12 * ToNum(r_1964))))))), " ", ToStr(Call(pt_15, V.Undef, Call(q_1965, V.Undef, ((V)((0.72 * ToNum(r_1964)))), ((V)(((-0.14) * ToNum(r_1964))))))), "M", ToStr(Call(pt_15, V.Undef, Call(q_1965, V.Undef, ((V)(((-0.55) * ToNum(r_1964)))), ((V)((0.22 * ToNum(r_1964))))))), "Q", ToStr(Call(pt_15, V.Undef, Call(q_1965, V.Undef, ((V)(0D)), ((V)((0.5 * ToNum(r_1964))))))), " ", ToStr(Call(pt_15, V.Undef, Call(q_1965, V.Undef, ((V)((0.5 * ToNum(r_1964)))), ((V)((0.26 * ToNum(r_1964))))))) })));
return default;
}, 3, "", true);
Call(set_1667, V.Undef, Get(B_1664, "shd"), ((V)("d")), Call(ellD_20, V.Undef, Call(P3_1666, V.Undef, ((V)(50D)), ((V)(20D)), ((V)(0D))), ((V)((((8.6 * ToNum(kS_1691)) * Max(0.35, System.Math.Abs(ToNum(Get(D_1665, "front"))))) + (2.2 * ToNum(kS_1691))))), ((V)((1.7 * ToNum(kS_1691)))), ((V)(0D))));
Invoke(SN_43, "order", Get(B_1664, "SAL"), Invoke(Invoke(Get(B_1664, "FK"), "map", Fn((V _self1657, int _argc1982, V o_1988, V _a1985, V _a1986, V _a1987, V[] _rest1983) => {
V up_1989 = default;
V x_1990 = default;
V y_1991 = default;
V C_1992 = default;
V r_1993 = default;
up_1989 = ((V)((ToNum(umeV_1669) * (5D + (3D * ToNum(Call(rnd_22, V.Undef, ((V)((ToNum(Get(o_1988, "k")) * 5.3))))))))));
x_1990 = Add(Get(o_1988, "x"), ((V)((((ToNum(Get(o_1988, "x")) - 50D) * 0.18) * ToNum(umeV_1669)))));
y_1991 = ((V)((ToNum(Get(o_1988, "y")) - ToNum(up_1989))));
C_1992 = Call(P3_1666, V.Undef, x_1990, y_1991, Get(o_1988, "z"));
r_1993 = ((V)((ToNum(Get(o_1988, "r")) * ToNum(kS_1691))));
Call(set_1667, V.Undef, Get(o_1988, "b"), ((V)("d")), Call(flk_1693, V.Undef, o_1988, C_1992, r_1993));
if (Truthy(Get(o_1988, "f"))) {
Call(set_1667, V.Undef, Get(o_1988, "f"), ((V)("d")), Call(fatL_1694, V.Undef, o_1988, C_1992, r_1993));
}
return NewObj(3).Put("id", ((V)(string.Concat("f", ToStr(Get(o_1988, "k")))))).Put("e", Get(o_1988, "g")).Put("z", Invoke(D_1665, "Z3", x_1990, y_1991, Get(o_1988, "z"))).V;
return default;
}, 1, "", true)), "sort", Fn((V _self1657, int _argc1974, V a_1980, V b_1981, V _a1978, V _a1979, V[] _rest1975) => {
return ((V)((ToNum(Get(a_1980, "z")) - ToNum(Get(b_1981, "z")))));
}, 2, "", true)));
return default;
}, 2, "draw", false)).V);
slabD_47 = Fn((V _self1, int _argc1994, V D_2000, V Q_2001, V zf_2002, V zb_2003, V[] _rest1995) => {
V F_2005 = default;
V K_2006 = default;
V d_2007 = default;
V W_2004 = default;
W_2004 = (_argc1994 > 4 ? _rest1995[0] : V.Undef);
W_2004 = (W_2004 is var _t2008 && Truthy(_t2008) ? _t2008 : Get(D_2000, "P3"));
F_2005 = Invoke(Q_2001, "map", Fn((V _self1, int _argc2009, V p_2015, V _a2012, V _a2013, V _a2014, V[] _rest2010) => {
return Call(W_2004, V.Undef, GetIdx(p_2015, 0D), GetIdx(p_2015, 1D), zf_2002);
}, 1, "", true));
K_2006 = Invoke(Q_2001, "map", Fn((V _self1, int _argc2016, V p_2022, V _a2019, V _a2020, V _a2021, V[] _rest2017) => {
return Call(W_2004, V.Undef, GetIdx(p_2022, 0D), GetIdx(p_2022, 1D), zb_2003);
}, 1, "", true));
d_2007 = Add(Call(polyW_18, V.Undef, F_2005), Call(polyW_18, V.Undef, K_2006));
{
V i_2023 = default;
i_2023 = ((V)(0D));
while (true) {
if (!(Lt(i_2023, Get(Q_2001, "length")))) break;
V j_2025 = default;
j_2025 = ((V)((ToNum(Add(i_2023, ((V)(1D)))) % ToNum(Get(Q_2001, "length")))));
d_2007 = Add(d_2007, Call(polyW_18, V.Undef, Arr(GetK(F_2005, i_2023), GetK(F_2005, j_2025), GetK(K_2006, j_2025), GetK(K_2006, i_2023))));
PostInc(ref i_2023, 1D);
}
}
return d_2007;
return default;
}, 5, "", true);
Set(Get(SN_43, "h"), "slabD", slabD_47);
PEf_48 = Fn((V _self1, int _argc2026, V D_2032, V EL_2033, V rT_2034, V _a2031, V[] _rest2027) => {
return Fn((V _self1, int _argc2035, V x_2041, V y_2042, V z_2043, V _a2040, V[] _rest2036) => {
V p_2044 = default;
p_2044 = Invoke(D_2032, "P3", x_2041, y_2042, z_2043);
return Arr(GetIdx(p_2044, 0D), Add(GetIdx(p_2044, 1D), ((V)((ToNum(EL_2033) * (ToNum(Invoke(D_2032, "Z3", x_2041, y_2042, z_2043)) - ToNum(Call(rT_2034, V.Undef, y_2042))))))));
return default;
}, 3, "", true);
}, 3, "", true);
Set(MODELS_42, "toco", NewObj(2).Put("setup", Fn((V _self2045, int _argc2046, V S_2052, V _a2049, V _a2050, V _a2051, V[] _rest2047) => {
V sk_2053 = default;
V O_2054 = default;
V th_2055 = default;
V W0_2056 = default;
V Wy_2057 = default;
V lt_2058 = default;
V mt_2059 = default;
V LF_2060 = default;
V MF_2061 = default;
V SG_2062 = default;
V back_2063 = default;
V FG_2064 = default;
V F_2065 = default;
V add_2066 = default;
V sp_2067 = default;
V hl_2068 = default;
if (_self2045.IsNullish) _self2045 = GlobalV;
{ V _t2069 = S_2052;
if (_t2069.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t2069));
{ V _t2070 = Get(_t2069, "sk");
sk_2053 = _t2070; } }
O_2054 = Invoke(S_2052, "outline", sk_2053, ((V)(64D)));
th_2055 = ((V)(1.5));
W0_2056 = ((V)(9.5));
Wy_2057 = Fn((V _self2045, int _argc2071, V y_2077, V _a2074, V _a2075, V _a2076, V[] _rest2072) => {
return ((V)((ToNum(W0_2056) * Pow(ToNum(Call(clamp_12, V.Undef, ((V)(((87.5 - ToNum(y_2077)) / 45.5))), ((V)(0D)), ((V)(1D)))), 0.85))));
}, 1, "", true);
lt_2058 = GetIdx(Invoke(S_2052, "hide", Fn((V _self2045, int _argc2078, V q_2084, V _a2081, V _a2082, V _a2083, V[] _rest2079) => {
return (((Get(q_2084, "inBody") is var _t2085 && !Truthy(_t2085) ? _t2085 : Invoke(NewRegExp(RX2, "^url", ""), "test", Invoke(S_2052, "f", q_2084))) is var _t2086 && !Truthy(_t2086) ? _t2086 : (SEqS(Get(q_2084, "tag"), "path") ? V.True : V.False)) is var _t2087 && !Truthy(_t2087) ? _t2087 : Invoke(NewRegExp(RX4, "^M12\\.00 88", ""), "test", Invoke(S_2052, "d", q_2084)));
}, 1, "", true)), 0D);
mt_2059 = GetIdx(Invoke(S_2052, "hide", Fn((V _self2045, int _argc2088, V q_2094, V _a2091, V _a2092, V _a2093, V[] _rest2089) => {
return (Get(q_2094, "inBody") is var _t2095 && !Truthy(_t2095) ? _t2095 : Invoke(NewRegExp(RX5, "^M11\\.50 88", ""), "test", Invoke(S_2052, "d", q_2094)));
}, 1, "", true)), 0D);
Invoke(S_2052, "hide", Fn((V _self2045, int _argc2096, V q_2102, V _a2099, V _a2100, V _a2101, V[] _rest2097) => {
return (Get(q_2102, "inBody") is var _t2103 && !Truthy(_t2103) ? _t2103 : ((((SEqS(Get(q_2102, "tag"), "rect") || SEqS(Invoke(S_2052, "s", q_2102), "#ffb02e")) || SEqS(Invoke(S_2052, "f", q_2102), "#d9952a")) || SEqS(Invoke(S_2052, "s", q_2102), "#fff6cf")) ? V.True : V.False));
}, 1, "", true));
LF_2060 = (Truthy(lt_2058) ? Invoke(S_2052, "f", lt_2058) : ((V)("#86d24e")));
MF_2061 = (Truthy(mt_2059) ? Invoke(S_2052, "f", mt_2059) : ((V)("#8a4526")));
SG_2062 = Invoke(S_2052, "g", Get(S_2052, "par"), Get(sk_2053, "e"));
Invoke(SG_2062, "appendChild", Get(sk_2053, "e"));
back_2063 = Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", Invoke(S_2052, "f", sk_2053)).V, SG_2062, Get(sk_2053, "e"));
FG_2064 = Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, SG_2062, Get(sk_2053, "e"));
F_2065 = Arr();
add_2066 = Fn((V _self2045, int _argc2104, V a_2110, V kind_2111, V dz_2112, V r_2113, V[] _rest2105) => {
V id_2114 = default;
id_2114 = (_argc2104 > 4 ? _rest2105[0] : V.Undef);
return Invoke(F_2065, "push", NewObj(6).Put("a", a_2110).Put("kind", kind_2111).Put("dz", dz_2112).Put("r", r_2113).Put("id", Add(kind_2111, Get(F_2065, "length"))).Put("e", Call(el_14, V.Undef, ((V)("path")), (SEqS(kind_2111, "l") ? NewObj(4).Put("fill", LF_2060).Put("stroke", ((V)("#4d9a2a"))).Put("stroke-width", ((V)(0.45))).Put("stroke-opacity", ((V)(0.55))).V : (SEqS(kind_2111, "m") ? NewObj(1).Put("fill", MF_2061).V : (SEqS(kind_2111, "t") ? NewObj(1).Put("fill", ((V)("#ff5a4a"))).V : NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffb02e"))).Put("stroke-width", ((V)(1.5))).Put("stroke-linecap", ((V)("round"))).V))), FG_2064)).V);
}, 5, "", true);
{
V i_2115 = default;
i_2115 = ((V)(0D));
while (true) {
if (!(LtN(i_2115, 13D))) break;
Call(add_2066, V.Undef, ((V)((0.08 + (ToNum(i_2115) * 0.07)))), ((V)("m")), ((V)(((NumTruthy((ToNum(i_2115) % 2D)) ? 1D : (-1D)) * 0.3))), ((V)(3.6)));
PostInc(ref i_2115, 1D);
}
}
{
V i_2117 = default;
i_2117 = ((V)(0D));
while (true) {
if (!(LtN(i_2117, 30D))) break;
Call(add_2066, V.Undef, ((V)((0.025 + (ToNum(i_2117) * 0.0328)))), ((V)("l")), GetIdx(Arr(((V)((-0.45))), ((V)(0.1)), ((V)(0.5)), ((V)((-0.1))), ((V)(0.35)), ((V)((-0.35)))), (ToNum(i_2117) % 6D)), ((V)((3.3 + ((ToNum(i_2117) % 3D) * 0.45)))));
PostInc(ref i_2117, 1D);
}
}
Invoke(Arr(Arr(((V)(0.16)), ((V)(0.2))), Arr(((V)(0.36)), ((V)((-0.3)))), Arr(((V)(0.62)), ((V)(0.3))), Arr(((V)(0.84)), ((V)((-0.2))))), "forEach", Fn((V _self2045, int _argc2119, V _a2121, V _a2122, V _a2123, V _a2124, V[] _rest2120) => {
V a_2127 = default;
V dz_2129 = default;
{ V _t2125 = ListOf(_a2121);
{ V _t2126 = GetIdx(_t2125, 0D);
a_2127 = _t2126; }
{ V _t2128 = GetIdx(_t2125, 1D);
dz_2129 = _t2128; }
}
return Call(add_2066, V.Undef, a_2127, ((V)("t")), dz_2129, ((V)(2.7)));
}, 1, "", true));
Invoke(Arr(Arr(((V)(0.24)), ((V)(0.1))), Arr(((V)(0.5)), ((V)((-0.2)))), Arr(((V)(0.7)), ((V)(0.25))), Arr(((V)(0.92)), ((V)(0D)))), "forEach", Fn((V _self2045, int _argc2130, V _a2132, V _a2133, V _a2134, V _a2135, V[] _rest2131) => {
V a_2138 = default;
V dz_2140 = default;
{ V _t2136 = ListOf(_a2132);
{ V _t2137 = GetIdx(_t2136, 0D);
a_2138 = _t2137; }
{ V _t2139 = GetIdx(_t2136, 1D);
dz_2140 = _t2139; }
}
return Call(add_2066, V.Undef, a_2138, ((V)("c")), dz_2140, ((V)(2.4)));
}, 1, "", true));
sp_2067 = Invoke(S_2052, "path", NewObj(2).Put("fill", ((V)("#d9952a"))).Put("opacity", ((V)(0.5))).V);
hl_2068 = Invoke(S_2052, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#fff6cf"))).Put("stroke-width", ((V)(1.2))).Put("opacity", ((V)(0.7))).Put("stroke-linecap", ((V)("round"))).V);
return NewObj(16).Put("O", O_2054).Put("th", th_2055).Put("Wy", Wy_2057).Put("SG", SG_2062).Put("back", back_2063).Put("FG", FG_2064).Put("F", F_2065).Put("sp", sp_2067).Put("hl", hl_2068).Put("slab", ((V)(1D))).Put("rx", ((V)(38D))).Put("ya", ((V)(44D))).Put("yb", ((V)(86D))).Put("rT", Fn((V _self2045, int _argc2141, V y_2147, V _a2144, V _a2145, V _a2146, V[] _rest2142) => {
return Call(halfW_38, V.Undef, O_2054, y_2147);
}, 1, "rT", true)).Put("zAt", Fn((V _self2045, int _argc2148, V x_2154, V y_2155, V _a2152, V _a2153, V[] _rest2149) => {
return Add(Call(Wy_2057, V.Undef, y_2155), th_2055);
}, 2, "zAt", true)).Put("zE", Fn((V _self2045, int _argc2156, V dx_2162, V dy_2163, V _a2160, V _a2161, V[] _rest2157) => {
return Add(Add(Call(Wy_2057, V.Undef, Add(Get(S_2052, "HY"), dy_2163)), th_2055), ((V)(0.3)));
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self2164, int _argc2165, V B_2171, V D_2172, V _a2169, V _a2170, V[] _rest2166) => {
V P3_2173 = default;
V Z3_2174 = default;
V set_2175 = default;
V snap_2176 = default;
V k_2177 = default;
V W_2178 = default;
V th_2179 = default;
V fr_2180 = default;
V sh_2181 = default;
V L_2182 = default;
V s_2183 = default;
V SP_2184 = default;
V hp_2185 = default;
if (_self2164.IsNullish) _self2164 = GlobalV;
{ V _t2186 = D_2172;
if (_t2186.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t2186));
{ V _t2187 = Get(_t2186, "P3");
P3_2173 = _t2187; }
{ V _t2188 = Get(_t2186, "Z3");
Z3_2174 = _t2188; }
{ V _t2189 = Get(_t2186, "set");
set_2175 = _t2189; } }
snap_2176 = Call(clamp_12, V.Undef, Invoke(D_2172, "bv", ((V)("snap"))), ((V)((-0.8))), ((V)(1.6)));
k_2177 = ((V)((1D + (ToNum(snap_2176) * 0.6))));
W_2178 = Fn((V _self2164, int _argc2190, V y_2196, V _a2193, V _a2194, V _a2195, V[] _rest2191) => {
return ((V)((ToNum(Invoke(B_2171, "Wy", y_2196)) * ToNum(k_2177))));
}, 1, "", true);
th_2179 = Get(B_2171, "th");
fr_2180 = (GeN(Get(D_2172, "front"), 0D) ? V.True : V.False);
sh_2181 = Fn((V _self2164, int _argc2197, V sg_2203, V _a2200, V _a2201, V _a2202, V[] _rest2198) => {
V o_2204 = default;
o_2204 = Arr();
Invoke(Get(B_2171, "O"), "forEach", Fn((V _self2164, int _argc2205, V p_2211, V _a2208, V _a2209, V _a2210, V[] _rest2206) => {
V z_2212 = default;
z_2212 = Call(W_2178, V.Undef, GetIdx(p_2211, 1D));
Invoke(o_2204, "push", Call(P3_2173, V.Undef, GetIdx(p_2211, 0D), GetIdx(p_2211, 1D), ((V)((ToNum(sg_2203) * ToNum(z_2212))))));
Invoke(o_2204, "push", Call(P3_2173, V.Undef, GetIdx(p_2211, 0D), GetIdx(p_2211, 1D), ((V)((ToNum(sg_2203) * ToNum(Add(z_2212, th_2179)))))));
return default;
}, 1, "", true));
return Invoke(D_2172, "hull", o_2204);
return default;
}, 1, "", true);
Set(B_2171, "d", Call(sh_2181, V.Undef, ((V)(1D))));
Call(set_2175, V.Undef, Get(B_2171, "back"), ((V)("d")), Call(sh_2181, V.Undef, ((V)((-1D)))));
L_2182 = Invoke(Invoke(Get(B_2171, "F"), "map", Fn((V _self2164, int _argc2221, V o_2227, V i_2228, V _a2225, V _a2226, V[] _rest2222) => {
V a_2229 = default;
V @out_2230 = default;
V wob_2231 = default;
V x_2232 = default;
V y_2233 = default;
V z_2234 = default;
V C_2235 = default;
V r_2236 = default;
a_2229 = ((V)((System.Math.PI * (1D - ToNum(Get(o_2227, "a"))))));
@out_2230 = ((V)((SEqS(Get(o_2227, "kind"), "l") ? (1.8 + ((ToNum(Get(o_2227, "r")) - 3.3) * 1.4)) : (SEqS(Get(o_2227, "kind"), "m") ? 1.2 : (SEqS(Get(o_2227, "kind"), "t") ? 3.4 : 4.2)))));
wob_2231 = ((V)(((FdLibm.Sin(((ToNum(Get(D_2172, "ts")) * 3D) + (ToNum(i_2228) * 1.7))) * 0.4) + ((ToNum(snap_2176) * FdLibm.Sin(ToNum(Add(((V)((ToNum(Get(D_2172, "ts")) * 18D))), i_2228)))) * 0.8))));
x_2232 = ((V)(((50D + (ToNum(Add(((V)(38D)), @out_2230)) * FdLibm.Cos(ToNum(a_2229)))) + (ToNum(Get(D_2172, "ox")) * 0.15))));
y_2233 = ((V)(((86D - (ToNum(Add(Add(((V)(44D)), @out_2230), wob_2231)) * FdLibm.Sin(ToNum(a_2229)))) - (ToNum(Get(D_2172, "oy")) * 0.25))));
z_2234 = ((V)(((ToNum(Get(o_2227, "dz")) * ToNum(Call(W_2178, V.Undef, y_2233))) * 1.6)));
C_2235 = Call(P3_2173, V.Undef, x_2232, y_2233, z_2234);
r_2236 = ((V)(((ToNum(Get(o_2227, "r")) * ToNum(Get(D_2172, "kS"))) * ToNum((SEqS(Get(o_2227, "kind"), "l") ? Add(((V)(1D)), Call(clamp_12, V.Undef, ((V)((ToNum(Call(W_2178, V.Undef, y_2233)) / 14D))), ((V)(0D)), ((V)(0.4)))) : ((V)(1D)))))));
if (SEqS(Get(o_2227, "kind"), "c")) {
V t_2237 = default;
t_2237 = Arr(((V)(FdLibm.Cos(ToNum(Add(a_2229, ((V)(1.2))))))), ((V)((-FdLibm.Sin(ToNum(Add(a_2229, ((V)(1.2)))))))));
Call(set_2175, V.Undef, Get(o_2227, "e"), ((V)("d")), ((V)(string.Concat("M", ToStr(Call(pt_15, V.Undef, Arr(((V)((ToNum(GetIdx(C_2235, 0D)) - (ToNum(GetIdx(t_2237, 0D)) * ToNum(r_2236))))), ((V)((ToNum(GetIdx(C_2235, 1D)) - (ToNum(GetIdx(t_2237, 1D)) * ToNum(r_2236)))))))), "L", ToStr(Call(pt_15, V.Undef, Arr(Add(GetIdx(C_2235, 0D), ((V)((ToNum(GetIdx(t_2237, 0D)) * ToNum(r_2236))))), Add(GetIdx(C_2235, 1D), ((V)((ToNum(GetIdx(t_2237, 1D)) * ToNum(r_2236))))))))))));
} else {
if (SEqS(Get(o_2227, "kind"), "t")) {
Call(set_2175, V.Undef, Get(o_2227, "e"), ((V)("d")), Call(ellD_20, V.Undef, C_2235, r_2236, ((V)((ToNum(r_2236) * 0.9))), ((V)((-ToNum(a_2229))))));
} else {
Call(set_2175, V.Undef, Get(o_2227, "e"), ((V)("d")), Call(circD_19, V.Undef, C_2235, r_2236));
}
}
return NewObj(3).Put("id", Get(o_2227, "id")).Put("e", Get(o_2227, "e")).Put("z", Call(Z3_2174, V.Undef, x_2232, y_2233, z_2234)).V;
return default;
}, 2, "", true)), "sort", Fn((V _self2164, int _argc2213, V a_2219, V b_2220, V _a2217, V _a2218, V[] _rest2214) => {
return ((V)((ToNum(Get(a_2219, "z")) - ToNum(Get(b_2220, "z")))));
}, 2, "", true));
Invoke(SN_43, "order", Get(B_2171, "FG"), L_2182);
s_2183 = ((V)((Truthy(fr_2180) ? 1D : (-1D))));
SP_2184 = Arr(Arr(((V)(24D)), ((V)(78D))), Arr(((V)(76D)), ((V)(79D))), Arr(((V)(31D)), ((V)(84D))), Arr(((V)(69D)), ((V)(84D))), Arr(((V)(22D)), ((V)(64D))), Arr(((V)(78D)), ((V)(63D))), Arr(((V)(36D)), ((V)(49D))), Arr(((V)(64D)), ((V)(48D))), Arr(((V)(45D)), ((V)(70D))), Arr(((V)(57D)), ((V)(77D))));
Call(set_2175, V.Undef, Get(B_2171, "sp"), ((V)("d")), Invoke(Invoke(SP_2184, "map", Fn((V _self2164, int _argc2238, V _a2240, V _a2241, V _a2242, V _a2243, V[] _rest2239) => {
V x_2246 = default;
V y_2248 = default;
{ V _t2244 = ListOf(_a2240);
{ V _t2245 = GetIdx(_t2244, 0D);
x_2246 = _t2245; }
{ V _t2247 = GetIdx(_t2244, 1D);
y_2248 = _t2247; }
}
return Call(circD_19, V.Undef, Call(P3_2173, V.Undef, x_2246, y_2248, ((V)((ToNum(s_2183) * ToNum(Add(Add(Call(W_2178, V.Undef, y_2248), th_2179), ((V)(0.1)))))))), ((V)((0.8 * ToNum(Get(D_2172, "kS"))))));
}, 1, "", true)), "join", ((V)(""))));
hp_2185 = Arr();
{
V i_2249 = default;
i_2249 = ((V)(0D));
while (true) {
if (!(LeN(i_2249, 24D))) break;
V a_2251 = default;
V x_2252 = default;
V y_2253 = default;
a_2251 = ((V)(((System.Math.PI * ToNum(i_2249)) / 24D)));
x_2252 = ((V)((50D + (33.5 * FdLibm.Cos(ToNum(a_2251))))));
y_2253 = ((V)((86D - (39.5 * FdLibm.Sin(ToNum(a_2251))))));
Invoke(hp_2185, "push", Call(P3_2173, V.Undef, x_2252, y_2253, ((V)((ToNum(s_2183) * ToNum(Add(Add(Call(W_2178, V.Undef, y_2253), th_2179), ((V)(0.15)))))))));
PostInc(ref i_2249, 1D);
}
}
Call(set_2175, V.Undef, Get(B_2171, "hl"), ((V)("d")), Call(runs_21, V.Undef, hp_2185, Invoke(hp_2185, "map", Fn((V _self2164, int _argc2254, V _a2256, V _a2257, V _a2258, V _a2259, V[] _rest2255) => {
return (true ? V.True : V.False);
}, 0, "", true))));
Invoke(SN_43, "order", Get(B_2171, "SG"), (Truthy(fr_2180) ? Arr(NewObj(2).Put("id", ((V)("b"))).Put("e", Get(B_2171, "back")).V, NewObj(2).Put("id", ((V)("f"))).Put("e", Get(B_2171, "FG")).V, NewObj(2).Put("id", ((V)("s"))).Put("e", Get(Get(Get(B_2171, "S"), "sk"), "e")).V) : Arr(NewObj(2).Put("id", ((V)("s"))).Put("e", Get(Get(Get(B_2171, "S"), "sk"), "e")).V, NewObj(2).Put("id", ((V)("f"))).Put("e", Get(B_2171, "FG")).V, NewObj(2).Put("id", ((V)("b"))).Put("e", Get(B_2171, "back")).V)));
return default;
}, 2, "draw", false)).V);
Set(MODELS_42, "churro", NewObj(2).Put("setup", Fn((V _self2260, int _argc2261, V S_2267, V _a2264, V _a2265, V _a2266, V[] _rest2262) => {
V sk_2268 = default;
V O_2269 = default;
V rT_2270 = default;
V ch_2271 = default;
V CF_2272 = default;
V sh_2273 = default;
V gv_2274 = default;
V cr_2275 = default;
V sug_2276 = default;
V dz_2277 = default;
V dzh_2278 = default;
V cap_2279 = default;
V cg_2280 = default;
V cg2_2281 = default;
V SU_2282 = default;
V DR_2283 = default;
V yd_2284 = default;
V DZ_2285 = default;
V pre_2286 = default;
if (_self2260.IsNullish) _self2260 = GlobalV;
{ V _t2287 = S_2267;
if (_t2287.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t2287));
{ V _t2288 = Get(_t2287, "sk");
sk_2268 = _t2288; } }
O_2269 = Invoke(S_2267, "outline", sk_2268, ((V)(64D)));
rT_2270 = Fn((V _self2260, int _argc2289, V y_2295, V _a2292, V _a2293, V _a2294, V[] _rest2290) => {
return Call(halfW_38, V.Undef, O_2269, Call(clamp_12, V.Undef, y_2295, ((V)(12.2)), ((V)(86.8))));
}, 1, "", true);
ch_2271 = GetIdx(Invoke(S_2267, "hide", Fn((V _self2260, int _argc2296, V q_2302, V _a2299, V _a2300, V _a2301, V[] _rest2297) => {
return (Get(q_2302, "inBody") is var _t2303 && !Truthy(_t2303) ? _t2303 : Invoke(NewRegExp(RX6, "^M29 \\d+ L29 22", ""), "test", Invoke(S_2267, "d", q_2302)));
}, 1, "", true)), 0D);
CF_2272 = (Truthy(ch_2271) ? Invoke(S_2267, "f", ch_2271) : ((V)("#5e3620")));
Invoke(S_2267, "hide", Fn((V _self2260, int _argc2304, V q_2310, V _a2307, V _a2308, V _a2309, V[] _rest2305) => {
return (Get(q_2310, "inBody") is var _t2316 && !Truthy(_t2316) ? _t2316 : (((((Invoke(S_2267, "dk", q_2310, ((V)("dz"))) is var _t2311 && Truthy(_t2311) ? _t2311 : (SEqS(Invoke(S_2267, "s", q_2310), "#9a5420") ? V.True : V.False)) is var _t2312 && Truthy(_t2312) ? _t2312 : (SEqS(Invoke(S_2267, "s", q_2310), "#ffe8c0") ? V.True : V.False)) is var _t2313 && Truthy(_t2313) ? _t2313 : (SEqS(Invoke(S_2267, "s", q_2310), "#b8865e") ? V.True : V.False)) is var _t2314 && Truthy(_t2314) ? _t2314 : (SEqS(Invoke(S_2267, "s", q_2310), "#a87652") ? V.True : V.False)) is var _t2315 && Truthy(_t2315) ? _t2315 : ((SEqS(Get(q_2310, "tag"), "circle") && SEqS(Invoke(S_2267, "f", q_2310), "#ffffff")) ? V.True : V.False)));
}, 1, "", true));
sh_2273 = Invoke(S_2267, "path", NewObj(1).Put("fill", Invoke(S_2267, "lgrad", ((V)("crsh")), Arr(Arr(((V)(0D)), ((V)("#6a3410")), ((V)(0.38))), Arr(((V)(0.16)), ((V)("#6a3410")), ((V)(0.08))), Arr(((V)(0.32)), ((V)("#fff2d0")), ((V)(0.34))), Arr(((V)(0.48)), ((V)("#fff2d0")), ((V)(0D))), Arr(((V)(0.78)), ((V)("#4a2008")), ((V)(0.06))), Arr(((V)(1D)), ((V)("#4a2008")), ((V)(0.42)))))).V);
gv_2274 = Invoke(S_2267, "path", NewObj(6).Put("fill", ((V)("none"))).Put("stroke", ((V)("#9a5420"))).Put("stroke-width", ((V)(1.1))).Put("opacity", ((V)(0.55))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V);
cr_2275 = Invoke(S_2267, "path", NewObj(6).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffe8c0"))).Put("stroke-width", ((V)(0.85))).Put("opacity", ((V)(0.6))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V);
sug_2276 = Invoke(S_2267, "path", NewObj(2).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.9))).V);
dz_2277 = Invoke(S_2267, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#4e2c18"))).Put("stroke-width", ((V)(2.1))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V);
dzh_2278 = Invoke(S_2267, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#9a6a48"))).Put("stroke-width", ((V)(0.6))).Put("opacity", ((V)(0.8))).Put("stroke-linecap", ((V)("round"))).V);
cap_2279 = Invoke(S_2267, "path", NewObj(1).Put("fill", CF_2272).V);
cg_2280 = Invoke(S_2267, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#b8865e"))).Put("stroke-width", ((V)(1.1))).Put("opacity", ((V)(0.7))).Put("stroke-linecap", ((V)("round"))).V);
cg2_2281 = Invoke(S_2267, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#a87652"))).Put("stroke-width", ((V)(1.2))).Put("opacity", ((V)(0.55))).Put("stroke-linecap", ((V)("round"))).V);
SU_2282 = Invoke(Array_from(NewObj(1).Put("length", ((V)(30D))).V, Fn((V _self2260, int _argc2328, V __2334, V i_2335, V _a2332, V _a2333, V[] _rest2329) => {
return Arr(((V)((ToNum(Call(rnd_22, V.Undef, ((V)((ToNum(i_2335) * 3.1))))) * ToNum(TAU_9)))), ((V)((46D + (ToNum(Call(rnd_22, V.Undef, ((V)((ToNum(i_2335) * 7.7))))) * 38D)))));
}, 2, "", true)), "filter", Fn((V _self2260, int _argc2317, V _a2319, V _a2320, V _a2321, V _a2322, V[] _rest2318) => {
V f_2325 = default;
V y_2327 = default;
{ V _t2323 = ListOf(_a2319);
{ V _t2324 = GetIdx(_t2323, 0D);
f_2325 = _t2324; }
{ V _t2326 = GetIdx(_t2323, 1D);
y_2327 = _t2326; }
}
return (!((((System.Math.Abs(FdLibm.Atan2(FdLibm.Sin(ToNum(f_2325)), FdLibm.Cos(ToNum(f_2325)))) < 0.62) && GtN(y_2327, 41D)) && LtN(y_2327, 64D))) ? V.True : V.False);
}, 1, "", true));
DR_2283 = Arr(Arr(((V)(0D)), ((V)(6.5)), ((V)(0.17))), Arr(((V)(0.5)), ((V)(2.2)), ((V)(0.13))), Arr(((V)((-0.5))), ((V)(2.4)), ((V)(0.13))), Arr(((V)(0.98)), ((V)(9.5)), ((V)(0.15))), Arr(((V)((-0.98))), ((V)(10.5)), ((V)(0.15))), Arr(((V)(1.75)), ((V)(7D)), ((V)(0.16))), Arr(((V)((-1.8))), ((V)(8.5)), ((V)(0.14))), Arr(((V)(2.5)), ((V)(10D)), ((V)(0.15))), Arr(((V)((-2.55))), ((V)(6.5)), ((V)(0.16))), Arr(((V)(3.14)), ((V)(9D)), ((V)(0.17))));
yd_2284 = Fn((V _self2260, int _argc2336, V f_2342, V _a2339, V _a2340, V _a2341, V[] _rest2337) => {
V y_2343 = default;
y_2343 = ((V)((37D + (1.2 * FdLibm.Sin(((5D * ToNum(f_2342)) + 0.7))))));
Invoke(DR_2283, "forEach", Fn((V _self2260, int _argc2344, V _a2346, V _a2347, V _a2348, V _a2349, V[] _rest2345) => {
V d_2357 = default;
V c_2352 = default;
V L_2354 = default;
V w_2356 = default;
{ V _t2350 = ListOf(_a2346);
{ V _t2351 = GetIdx(_t2350, 0D);
c_2352 = _t2351; }
{ V _t2353 = GetIdx(_t2350, 1D);
L_2354 = _t2353; }
{ V _t2355 = GetIdx(_t2350, 2D);
w_2356 = _t2355; }
}
d_2357 = ((V)((FdLibm.Atan2(FdLibm.Sin((ToNum(f_2342) - ToNum(c_2352))), FdLibm.Cos((ToNum(f_2342) - ToNum(c_2352)))) / ToNum(w_2356))));
if ((System.Math.Abs(ToNum(d_2357)) < 1D)) {
y_2343 = ((V)(Max(ToNum(y_2343), (37D + (ToNum(L_2354) * System.Math.Sqrt((1D - (ToNum(d_2357) * ToNum(d_2357)))))))));
}
return default;
}, 1, "", true));
return y_2343;
return default;
}, 1, "", true);
DZ_2285 = Arr(Arr(((V)(67D)), ((V)(0.4)), ((V)(1.1))), Arr(((V)(75.2)), ((V)(2.3)), ((V)(4D))), Arr(((V)(83D)), ((V)(4.3)), ((V)(2.6))));
pre_2286 = Fn((V _self2260, int _argc2358, V P_2364, V _a2361, V _a2362, V _a2363, V[] _rest2359) => {
V c_2365 = default;
c_2365 = Call(clamp_12, V.Undef, (((V)(ToNum(Get(P_2364, "cork")))) is var _t2366 && Truthy(_t2366) ? _t2366 : ((V)(0D))), ((V)((-1.2))), ((V)(1.2)));
return (Truthy(c_2365) ? Object_assign(NewObj(0).V, P_2364, NewObj(2).Put("spin", Add((((V)(ToNum(Get(P_2364, "spin")))) is var _t2367 && Truthy(_t2367) ? _t2367 : ((V)(0D))), ((V)((ToNum(c_2365) * 17D))))).Put("hyaw", Add((((V)(ToNum(Get(P_2364, "hyaw")))) is var _t2368 && Truthy(_t2368) ? _t2368 : ((V)(0D))), ((V)((ToNum(c_2365) * 0.2))))).V) : P_2364);
return default;
}, 1, "", true);
return NewObj(19).Put("O", O_2269).Put("rT", rT_2270).Put("sh", sh_2273).Put("gv", gv_2274).Put("cr", cr_2275).Put("sug", sug_2276).Put("dz", dz_2277).Put("dzh", dzh_2278).Put("cap", cap_2279).Put("cg", cg_2280).Put("cg2", cg2_2281).Put("SU", SU_2282).Put("yd", yd_2284).Put("DZ", DZ_2285).Put("pre", pre_2286).Put("rx", ((V)(21D))).Put("ya", ((V)(22D))).Put("yb", ((V)(82D))).Put("zE", Fn((V _self2260, int _argc2369, V dx_2375, V dy_2376, V _a2373, V _a2374, V[] _rest2370) => {
V r_2377 = default;
r_2377 = Call(rT_2270, V.Undef, Add(Get(S_2267, "HY"), dy_2376));
return ((V)((System.Math.Sqrt(Max(0D, ((ToNum(r_2377) * ToNum(r_2377)) - (ToNum(dx_2375) * ToNum(dx_2375))))) + 0.3)));
return default;
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self2378, int _argc2379, V B_2385, V D_2386, V _a2383, V _a2384, V[] _rest2380) => {
V P3_2387 = default;
V set_2388 = default;
V rT_2389 = default;
V cork_2390 = default;
V P_2391 = default;
V vis_2392 = default;
V hp_2393 = default;
V fz_2394 = default;
V tw_2395 = default;
V gd_2396 = default;
V cd_2397 = default;
V zd_2398 = default;
V zh_2399 = default;
V A_2400 = default;
if (_self2378.IsNullish) _self2378 = GlobalV;
{ V _t2401 = D_2386;
if (_t2401.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t2401));
{ V _t2402 = Get(_t2401, "P3");
P3_2387 = _t2402; }
{ V _t2403 = Get(_t2401, "set");
set_2388 = _t2403; } }
rT_2389 = Get(B_2385, "rT");
cork_2390 = Call(clamp_12, V.Undef, Invoke(D_2386, "bv", ((V)("cork"))), ((V)((-1.2))), ((V)(1.2)));
P_2391 = Fn((V _self2378, int _argc2404, V f_2410, V y_2411, V k_2412, V _a2409, V[] _rest2405) => {
V r_2413 = default;
r_2413 = ((V)((ToNum(Call(rT_2389, V.Undef, y_2411)) * ToNum((k_2412 is var _t2414 && Truthy(_t2414) ? _t2414 : ((V)(1D)))))));
return Call(P3_2387, V.Undef, ((V)((50D + (ToNum(r_2413) * FdLibm.Sin(ToNum(f_2410)))))), y_2411, ((V)((ToNum(r_2413) * FdLibm.Cos(ToNum(f_2410))))));
return default;
}, 3, "", true);
vis_2392 = Fn((V _self2378, int _argc2415, V f_2421, V y_2422, V _a2419, V _a2420, V[] _rest2416) => {
V r_2423 = default;
r_2423 = Call(rT_2389, V.Undef, y_2422);
return (GtN(Invoke(D_2386, "facing", ((V)((50D + (ToNum(r_2423) * FdLibm.Sin(ToNum(f_2421)))))), y_2422, ((V)((ToNum(r_2423) * FdLibm.Cos(ToNum(f_2421))))), ((V)(FdLibm.Sin(ToNum(f_2421)))), ((V)(0D)), ((V)(FdLibm.Cos(ToNum(f_2421))))), 0.01) ? V.True : V.False);
return default;
}, 2, "", true);
hp_2393 = Arr();
{
V i_2424 = default;
i_2424 = ((V)(0D));
while (true) {
if (!(LeN(i_2424, 18D))) break;
V y_2426 = default;
y_2426 = ((V)((12.2 + ((74.6 * ToNum(i_2424)) / 18D))));
{
V k_2427 = default;
k_2427 = ((V)(0D));
while (true) {
if (!(LtN(k_2427, 24D))) break;
Invoke(hp_2393, "push", Call(P_2391, V.Undef, ((V)(((ToNum(k_2427) / 24D) * ToNum(TAU_9)))), y_2426, ((V)(1.02))));
PostInc(ref k_2427, 1D);
}
}
PostInc(ref i_2424, 1D);
}
}
Set(B_2385, "d", Invoke(D_2386, "hull", hp_2393));
Call(set_2388, V.Undef, Get(B_2385, "sh"), ((V)("d")), Get(B_2385, "d"));
fz_2394 = Fn((V _self2378, int _argc2429, V f_2435, V y_2436, V _a2433, V _a2434, V[] _rest2430) => {
return ((((System.Math.Abs(FdLibm.Atan2(FdLibm.Sin(ToNum(f_2435)), FdLibm.Cos(ToNum(f_2435)))) < 0.6) && GtN(y_2436, 40D)) && LtN(y_2436, 66D)) ? V.True : V.False);
}, 2, "", true);
tw_2395 = Fn((V _self2378, int _argc2437, V y_2443, V _a2440, V _a2441, V _a2442, V[] _rest2438) => {
return ((V)((((ToNum(cork_2390) * 0.9) * (51D - ToNum(y_2443))) / 75D)));
}, 1, "", true);
gd_2396 = ((V)(""));
cd_2397 = ((V)(""));
{
V k_2444 = default;
k_2444 = ((V)(0D));
while (true) {
if (!(LtN(k_2444, 8D))) break;
V G_2446 = default;
V Go_2447 = default;
V C_2448 = default;
V Co_2449 = default;
G_2446 = Arr();
Go_2447 = Arr();
C_2448 = Arr();
Co_2449 = Arr();
{
V y_2450 = default;
y_2450 = ((V)(39D));
while (true) {
if (!(LeN(y_2450, 85D))) break;
V fg_2452 = default;
V fc_2453 = default;
fg_2452 = Add(((V)(((ToNum(Add(k_2444, ((V)(0.5)))) * ToNum(TAU_9)) / 8D))), Call(tw_2395, V.Undef, y_2450));
fc_2453 = Add(((V)(((ToNum(k_2444) * ToNum(TAU_9)) / 8D))), Call(tw_2395, V.Undef, y_2450));
Invoke(G_2446, "push", Call(P_2391, V.Undef, fg_2452, y_2450, ((V)(0.985))));
Invoke(Go_2447, "push", (Call(vis_2392, V.Undef, fg_2452, y_2450) is var _t2454 && !Truthy(_t2454) ? _t2454 : (!(Truthy(Call(fz_2394, V.Undef, fg_2452, y_2450))) ? V.True : V.False)));
Invoke(C_2448, "push", Call(P_2391, V.Undef, fc_2453, y_2450, ((V)(1.01))));
Invoke(Co_2449, "push", (Call(vis_2392, V.Undef, fc_2453, y_2450) is var _t2455 && !Truthy(_t2455) ? _t2455 : (!(Truthy(Call(fz_2394, V.Undef, fc_2453, y_2450))) ? V.True : V.False)));
y_2450 = Add(y_2450, ((V)(2D)));
}
}
gd_2396 = Add(gd_2396, Call(runs_21, V.Undef, G_2446, Go_2447));
cd_2397 = Add(cd_2397, Call(runs_21, V.Undef, C_2448, Co_2449));
PostInc(ref k_2444, 1D);
}
}
Call(set_2388, V.Undef, Get(B_2385, "gv"), ((V)("d")), (gd_2396 is var _t2456 && Truthy(_t2456) ? _t2456 : ((V)("M0 0"))));
Call(set_2388, V.Undef, Get(B_2385, "cr"), ((V)("d")), (cd_2397 is var _t2457 && Truthy(_t2457) ? _t2457 : ((V)("M0 0"))));
Call(set_2388, V.Undef, Get(B_2385, "sug"), ((V)("d")), (Invoke(Invoke(Invoke(Get(B_2385, "SU"), "filter", Fn((V _self2378, int _argc2469, V _a2471, V _a2472, V _a2473, V _a2474, V[] _rest2470) => {
V f_2477 = default;
V y_2479 = default;
{ V _t2475 = ListOf(_a2471);
{ V _t2476 = GetIdx(_t2475, 0D);
f_2477 = _t2476; }
{ V _t2478 = GetIdx(_t2475, 1D);
y_2479 = _t2478; }
}
return Call(vis_2392, V.Undef, Add(f_2477, Call(tw_2395, V.Undef, y_2479)), y_2479);
}, 1, "", true)), "map", Fn((V _self2378, int _argc2458, V _a2460, V _a2461, V _a2462, V _a2463, V[] _rest2459) => {
V f_2466 = default;
V y_2468 = default;
{ V _t2464 = ListOf(_a2460);
{ V _t2465 = GetIdx(_t2464, 0D);
f_2466 = _t2465; }
{ V _t2467 = GetIdx(_t2464, 1D);
y_2468 = _t2467; }
}
return Call(circD_19, V.Undef, Call(P_2391, V.Undef, Add(f_2466, Call(tw_2395, V.Undef, y_2468)), y_2468, ((V)(1.02))), ((V)((0.5 * ToNum(Get(D_2386, "kS"))))));
}, 1, "", true)), "join", ((V)(""))) is var _t2480 && Truthy(_t2480) ? _t2480 : ((V)("M0 0"))));
zd_2398 = ((V)(""));
zh_2399 = ((V)(""));
Invoke(Get(B_2385, "DZ"), "forEach", Fn((V _self2378, int _argc2481, V _a2483, V _a2484, V _a2485, V _a2486, V[] _rest2482) => {
V Q_2494 = default;
V ok_2495 = default;
V Qh_2496 = default;
V okh_2497 = default;
V yc_2489 = default;
V p1_2491 = default;
V p2_2493 = default;
{ V _t2487 = ListOf(_a2483);
{ V _t2488 = GetIdx(_t2487, 0D);
yc_2489 = _t2488; }
{ V _t2490 = GetIdx(_t2487, 1D);
p1_2491 = _t2490; }
{ V _t2492 = GetIdx(_t2487, 2D);
p2_2493 = _t2492; }
}
Q_2494 = Arr();
ok_2495 = Arr();
Qh_2496 = Arr();
okh_2497 = Arr();
{
V k_2498 = default;
k_2498 = ((V)(0D));
while (true) {
if (!(LeN(k_2498, 96D))) break;
V f_2500 = default;
V y_2501 = default;
V ff_2502 = default;
V v_2503 = default;
f_2500 = ((V)(((ToNum(k_2498) / 96D) * ToNum(TAU_9))));
y_2501 = Add(Add(yc_2489, ((V)((2.3 * FdLibm.Sin(ToNum(Add(((V)((3D * ToNum(f_2500)))), p1_2491))))))), ((V)((0.5 * FdLibm.Sin(ToNum(Add(((V)((7D * ToNum(f_2500)))), p2_2493)))))));
ff_2502 = Add(f_2500, Call(tw_2395, V.Undef, y_2501));
v_2503 = Call(vis_2392, V.Undef, ff_2502, y_2501);
Invoke(Q_2494, "push", Call(P_2391, V.Undef, ff_2502, y_2501, ((V)(1.03))));
Invoke(ok_2495, "push", v_2503);
Invoke(Qh_2496, "push", Call(P_2391, V.Undef, ff_2502, ((V)((ToNum(y_2501) - 0.55))), ((V)(1.04))));
Invoke(okh_2497, "push", (v_2503 is var _t2504 && !Truthy(_t2504) ? _t2504 : ((FdLibm.Cos(ToNum(Add(Add(((V)((ToNum(f_2500) * 3D))), p1_2491), ((V)(0.6))))) > 0.1) ? V.True : V.False)));
PostInc(ref k_2498, 1D);
}
}
zd_2398 = Add(zd_2398, Call(runs_21, V.Undef, Q_2494, ok_2495));
zh_2399 = Add(zh_2399, Call(runs_21, V.Undef, Qh_2496, okh_2497));
return default;
}, 1, "", true));
Call(set_2388, V.Undef, Get(B_2385, "dz"), ((V)("d")), (zd_2398 is var _t2505 && Truthy(_t2505) ? _t2505 : ((V)("M0 0"))));
Call(set_2388, V.Undef, Get(B_2385, "dzh"), ((V)("d")), (zh_2399 is var _t2506 && Truthy(_t2506) ? _t2506 : ((V)("M0 0"))));
A_2400 = Invoke(Get(SN_43, "h"), "frontArc", D_2386, ((V)(21D)), ((V)(40D)), ((V)(160D)));
if (GtN(Get(A_2400, "length"), 1D)) {
V t2_2507 = default;
V yd_2508 = default;
V Q_2509 = default;
V fb_2510 = default;
V fa_2511 = default;
t2_2507 = Call(tw_2395, V.Undef, ((V)(42D)));
yd_2508 = Fn((V _self2378, int _argc2512, V f_2518, V _a2515, V _a2516, V _a2517, V[] _rest2513) => {
return Invoke(B_2385, "yd", ((V)((ToNum(f_2518) - ToNum(t2_2507)))));
}, 1, "", true);
Q_2509 = Arr();
Invoke(A_2400, "forEach", Fn((V _self2378, int _argc2519, V f_2525, V _a2522, V _a2523, V _a2524, V[] _rest2520) => {
return Invoke(Q_2509, "push", Call(P_2391, V.Undef, f_2525, Call(yd_2508, V.Undef, f_2525), ((V)(1.035))));
}, 1, "", true));
fb_2510 = GetIdx(A_2400, (ToNum(Get(A_2400, "length")) - 1D));
fa_2511 = GetIdx(A_2400, 0D);
{
V y_2526 = default;
y_2526 = Call(yd_2508, V.Undef, fb_2510);
while (true) {
if (!(GeN(y_2526, 13D))) break;
Invoke(Q_2509, "push", Call(P_2391, V.Undef, fb_2510, y_2526, ((V)(1.035))));
y_2526 = ((V)((ToNum(y_2526) - 2.5)));
}
}
{
V i_2528 = default;
i_2528 = ((V)((ToNum(Get(A_2400, "length")) - 1D)));
while (true) {
if (!(GeN(i_2528, 0D))) break;
Invoke(Q_2509, "push", Call(P_2391, V.Undef, GetK(A_2400, i_2528), ((V)(12.4)), ((V)(1.035))));
i_2528 = ((V)((ToNum(i_2528) - 4D)));
}
}
Invoke(Q_2509, "push", Call(P_2391, V.Undef, GetIdx(A_2400, 0D), ((V)(12.4)), ((V)(1.035))));
{
V y_2530 = default;
y_2530 = ((V)(13D));
while (true) {
if (!(Le(y_2530, Call(yd_2508, V.Undef, fa_2511)))) break;
Invoke(Q_2509, "push", Call(P_2391, V.Undef, fa_2511, y_2530, ((V)(1.035))));
y_2530 = Add(y_2530, ((V)(2.5)));
}
}
Call(set_2388, V.Undef, Get(B_2385, "cap"), ((V)("d")), Call(polyW_18, V.Undef, Q_2509));
Call(set_2388, V.Undef, Get(B_2385, "cg"), ((V)("d")), Call(runs_21, V.Undef, Invoke(A_2400, "map", Fn((V _self2378, int _argc2532, V f_2538, V _a2535, V _a2536, V _a2537, V[] _rest2533) => {
return Call(P_2391, V.Undef, f_2538, ((V)(17D)), ((V)(1.04)));
}, 1, "", true)), Invoke(A_2400, "map", Fn((V _self2378, int _argc2539, V f_2545, V _a2542, V _a2543, V _a2544, V[] _rest2540) => {
return ((FdLibm.Cos(ToNum(Add(f_2545, Get(D_2386, "yh")))) > 0.35) ? V.True : V.False);
}, 1, "", true))));
Call(set_2388, V.Undef, Get(B_2385, "cg2"), ((V)("d")), Call(runs_21, V.Undef, Invoke(A_2400, "map", Fn((V _self2378, int _argc2546, V f_2552, V _a2549, V _a2550, V _a2551, V[] _rest2547) => {
return Call(P_2391, V.Undef, f_2552, ((V)((22D + (ToNum(Add(Add(f_2552, Get(D_2386, "yh")), ((V)(0.9)))) * 8D)))), ((V)(1.045)));
}, 1, "", true)), Invoke(A_2400, "map", Fn((V _self2378, int _argc2553, V f_2559, V _a2556, V _a2557, V _a2558, V[] _rest2554) => {
return ((System.Math.Abs(ToNum(Add(Add(f_2559, Get(D_2386, "yh")), ((V)(0.85))))) < 0.16) ? V.True : V.False);
}, 1, "", true))));
}
return default;
}, 2, "draw", false)).V);
tiltW_49 = Fn((V _self1, int _argc2560, V D_2566, V al_2567, V yc_2568, V zc_2569, V[] _rest2561) => {
V ca_2570 = default;
V sa_2571 = default;
V HX_2572 = default;
V cyh_2573 = default;
V syh_2574 = default;
V R_2575 = default;
ca_2570 = ((V)(FdLibm.Cos(ToNum(al_2567))));
sa_2571 = ((V)(FdLibm.Sin(ToNum(al_2567))));
HX_2572 = Get(D_2566, "HX");
cyh_2573 = Get(D_2566, "cyh");
syh_2574 = Get(D_2566, "syh");
R_2575 = Fn((V _self1, int _argc2576, V x_2582, V y_2583, V z_2584, V _a2581, V[] _rest2577) => {
V cs_2585 = default;
V dx_2586 = default;
V x1_2587 = default;
V z1_2588 = default;
V u_2589 = default;
V w_2590 = default;
cs_2585 = (Truthy(Get(D_2566, "yawH")) ? Invoke(D_2566, "yawH", y_2583) : Arr(cyh_2573, syh_2574));
dx_2586 = ((V)((ToNum(x_2582) - ToNum(HX_2572))));
x1_2587 = ((V)(((ToNum(dx_2586) * ToNum(GetIdx(cs_2585, 0D))) + (ToNum(z_2584) * ToNum(GetIdx(cs_2585, 1D))))));
z1_2588 = ((V)((((-ToNum(dx_2586)) * ToNum(GetIdx(cs_2585, 1D))) + (ToNum(z_2584) * ToNum(GetIdx(cs_2585, 0D))))));
u_2589 = ((V)((ToNum(y_2583) - ToNum(yc_2568))));
w_2590 = ((V)((ToNum(z1_2588) - ToNum(zc_2569))));
return Arr(Add(HX_2572, x1_2587), Add(Add(yc_2568, ((V)((ToNum(u_2589) * ToNum(ca_2570))))), ((V)((ToNum(w_2590) * ToNum(sa_2571))))), ((V)(((ToNum(zc_2569) - (ToNum(u_2589) * ToNum(sa_2571))) + (ToNum(w_2590) * ToNum(ca_2570))))));
return default;
}, 3, "", true);
return NewObj(3).Put("P", Fn((V _self1, int _argc2591, V x_2597, V y_2598, V z_2599, V _a2596, V[] _rest2592) => {
V r_2600 = default;
r_2600 = Call(R_2575, V.Undef, x_2597, y_2598, z_2599);
return Invoke(D_2566, "headT", GetIdx(r_2600, 0D), GetIdx(r_2600, 1D));
return default;
}, 3, "P", true)).Put("Z", Fn((V _self1, int _argc2601, V x_2607, V y_2608, V z_2609, V _a2606, V[] _rest2602) => {
return GetIdx(Call(R_2575, V.Undef, x_2607, y_2608, z_2609), 2D);
}, 3, "Z", true)).Put("F", Fn((V _self1, int _argc2610, V x_2616, V y_2617, V z_2618, V nx_2619, V[] _rest2611) => {
V ny_2620 = default;
V nz_2621 = default;
ny_2620 = (_argc2610 > 4 ? _rest2611[0] : V.Undef);
nz_2621 = (_argc2610 > 5 ? _rest2611[1] : V.Undef);
return ((V)((ToNum(GetIdx(Call(R_2575, V.Undef, Add(x_2616, nx_2619), Add(y_2617, ny_2620), Add(z_2618, nz_2621)), 2D)) - ToNum(GetIdx(Call(R_2575, V.Undef, x_2616, y_2617, z_2618), 2D)))));
}, 6, "F", true)).V;
return default;
}, 4, "", true);
Set(Get(SN_43, "h"), "tiltW", tiltW_49);
Set(MODELS_42, "frankie", NewObj(2).Put("setup", Fn((V _self2622, int _argc2623, V S_2629, V _a2626, V _a2627, V _a2628, V[] _rest2624) => {
V sk_2630 = default;
V T_2631 = default;
V b_2632 = default;
V rr_2633 = default;
V O_2634 = default;
V OF_2635 = default;
V rings_2636 = default;
V ringsF_2637 = default;
V zF_2638 = default;
V sau_2639 = default;
V bi_2640 = default;
V zz_2641 = default;
V SG_2642 = default;
V topY_2643 = default;
V OFi_2644 = default;
V back_2645 = default;
V inB_2646 = default;
V sg_2647 = default;
V sp_2648 = default;
V sh_2649 = default;
V kc_2650 = default;
V ms_2651 = default;
V lip_2652 = default;
V shn_2653 = default;
if (_self2622.IsNullish) _self2622 = GlobalV;
{ V _t2654 = S_2629;
if (_t2654.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t2654));
{ V _t2655 = Get(_t2654, "sk");
sk_2630 = _t2655; } }
T_2631 = ((V)(11D));
b_2632 = ((V)(9.5));
rr_2633 = Fn((V _self2622, int _argc2656, V y0_2662, V n_2663, V _a2660, V _a2661, V[] _rest2657) => {
V Q_2664 = default;
Q_2664 = Arr();
{
V k_2665 = default;
k_2665 = ((V)(0D));
while (true) {
if (!(LtN(k_2665, 72D))) break;
V f_2667 = default;
V c_2668 = default;
V s_2669 = default;
V ax_2670 = default;
V ay_2671 = default;
f_2667 = ((V)(((ToNum(k_2665) / 72D) * ToNum(TAU_9))));
c_2668 = ((V)(FdLibm.Cos(ToNum(f_2667))));
s_2669 = ((V)(FdLibm.Sin(ToNum(f_2667))));
ax_2670 = ((V)(42D));
ay_2671 = ((V)(((88D - ToNum(y0_2662)) / 2D)));
Invoke(Q_2664, "push", Arr(((V)((50D + ((ToNum(ax_2670) * Sign(ToNum(c_2668))) * Pow(System.Math.Abs(ToNum(c_2668)), (2D / ToNum(n_2663))))))), ((V)(((ToNum(Add(((V)(88D)), y0_2662)) / 2D) + ((ToNum(ay_2671) * Sign(ToNum(s_2669))) * Pow(System.Math.Abs(ToNum(s_2669)), (2D / ToNum(n_2663)))))))));
PostInc(ref k_2665, 1D);
}
}
return Q_2664;
return default;
}, 2, "", true);
O_2634 = Call(rr_2633, V.Undef, ((V)(53D)), ((V)(2.8)));
OF_2635 = Call(rr_2633, V.Undef, ((V)(43D)), ((V)(2.8)));
rings_2636 = Call(pillowRings_40, V.Undef, O_2634, T_2631, b_2632, ((V)(5D)));
ringsF_2637 = Call(pillowRings_40, V.Undef, OF_2635, T_2631, b_2632, ((V)(5D)));
zF_2638 = Call(pillowZ_41, V.Undef, O_2634, T_2631, b_2632);
sau_2639 = GetIdx(Invoke(S_2629, "hide", Fn((V _self2622, int _argc2672, V q_2678, V _a2675, V _a2676, V _a2677, V[] _rest2673) => {
return (Get(q_2678, "inBody") is var _t2679 && !Truthy(_t2679) ? _t2679 : Invoke(NewRegExp(RX7, "^M14 41", ""), "test", Invoke(S_2629, "d", q_2678)));
}, 1, "", true)), 0D);
bi_2640 = GetIdx(Invoke(S_2629, "hide", Fn((V _self2622, int _argc2680, V q_2686, V _a2683, V _a2684, V _a2685, V[] _rest2681) => {
return (Get(q_2686, "inBody") is var _t2687 && !Truthy(_t2687) ? _t2687 : Invoke(NewRegExp(RX8, "^M13 43", ""), "test", Invoke(S_2629, "d", q_2686)));
}, 1, "", true)), 0D);
Invoke(S_2629, "hide", Fn((V _self2622, int _argc2688, V q_2694, V _a2691, V _a2692, V _a2693, V[] _rest2689) => {
return (Get(q_2694, "inBody") is var _t2696 && !Truthy(_t2696) ? _t2696 : (Invoke(NewRegExp(RX9, "^M9 50 Q9 31|^M14 43\\.6|^M16 46 L20|^M16 56", ""), "test", Invoke(S_2629, "d", q_2694)) is var _t2695 && Truthy(_t2695) ? _t2695 : (SEqS(Invoke(S_2629, "s", q_2694), "#e8402e") ? V.True : V.False)));
}, 1, "", true));
Invoke(Get(sk_2630, "e"), "setAttribute", ((V)("fill")), Invoke(S_2629, "lgrad", ((V)("fkb")), Arr(Arr(((V)(0D)), ((V)("#c9782f"))), Arr(((V)(0.16)), ((V)("#d98f42"))), Arr(((V)(0.42)), ((V)("#eeb265"))), Arr(((V)(0.78)), ((V)("#f6cf92"))), Arr(((V)(1D)), ((V)("#eebd7c")))), NewObj(2).Put("x2", ((V)(0D))).Put("y2", ((V)(1D))).V));
zz_2641 = Fn((V _self2622, int _argc2697, V y_2703, V _a2700, V _a2701, V _a2702, V[] _rest2698) => {
return Call(SM_13, V.Undef, ((V)(((88D - ToNum(y_2703)) / 26D))));
}, 1, "", true);
SG_2642 = Invoke(S_2629, "g", Get(S_2629, "par"), Get(sk_2630, "e"));
Invoke(SG_2642, "appendChild", Get(sk_2630, "e"));
topY_2643 = Fn((V _self2622, int _argc2704, V x_2710, V _a2707, V _a2708, V _a2709, V[] _rest2705) => {
V m_2711 = default;
m_2711 = ((V)(1000000000D));
{
V i_2712 = default;
i_2712 = ((V)(0D));
while (true) {
if (!(Lt(i_2712, Get(O_2634, "length")))) break;
V a_2714 = default;
V c_2715 = default;
a_2714 = GetK(O_2634, i_2712);
c_2715 = GetIdx(O_2634, (ToNum(Add(i_2712, ((V)(1D)))) % ToNum(Get(O_2634, "length"))));
if (((((ToNum(GetIdx(a_2714, 0D)) - ToNum(x_2710)) * (ToNum(GetIdx(c_2715, 0D)) - ToNum(x_2710))) <= 0D) && !SEq(GetIdx(a_2714, 0D), GetIdx(c_2715, 0D)))) {
V y_2716 = default;
y_2716 = Add(GetIdx(a_2714, 1D), ((V)((((ToNum(GetIdx(c_2715, 1D)) - ToNum(GetIdx(a_2714, 1D))) * (ToNum(x_2710) - ToNum(GetIdx(a_2714, 0D)))) / (ToNum(GetIdx(c_2715, 0D)) - ToNum(GetIdx(a_2714, 0D)))))));
if (Lt(y_2716, m_2711)) {
m_2711 = y_2716;
}
}
PostInc(ref i_2712, 1D);
}
}
return m_2711;
return default;
}, 1, "", true);
OFi_2644 = Invoke(Call(offset_39, V.Undef, OF_2635, ((V)(1.5))), "map", Fn((V _self2622, int _argc2717, V p_2723, V _a2720, V _a2721, V _a2722, V[] _rest2718) => {
return Arr(GetIdx(p_2723, 0D), ((V)(Min(ToNum(GetIdx(p_2723, 1D)), 62D))));
}, 1, "", true));
back_2645 = Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", Invoke(S_2629, "lgrad", ((V)("fkf")), Arr(Arr(((V)(0D)), ((V)("#bf6c28"))), Arr(((V)(0.3)), ((V)("#d48a3e"))), Arr(((V)(1D)), ((V)("#e9ae63")))), NewObj(2).Put("x2", ((V)(0D))).Put("y2", ((V)(1D))).V)).V, SG_2642, Get(sk_2630, "e"));
inB_2646 = Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", Invoke(S_2629, "rgrad", ((V)("fki")), Arr(Arr(((V)(0D)), ((V)("#fff8ea"))), Arr(((V)(0.6)), ((V)("#ffeccb"))), Arr(((V)(1D)), ((V)("#f2d29c")))), NewObj(1).Put("cy", ((V)("70%"))).V)).V, SG_2642, Get(sk_2630, "e"));
sg_2647 = Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, SG_2642, Get(sk_2630, "e"));
sp_2648 = Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", Invoke(S_2629, "lgrad", ((V)("fks")), Arr(Arr(((V)(0D)), ((V)("#f08660"))), Arr(((V)(0.38)), ((V)("#d85434"))), Arr(((V)(0.78)), ((V)("#b23d26"))), Arr(((V)(1D)), ((V)("#8c2c1c")))), NewObj(2).Put("x2", ((V)(0D))).Put("y2", ((V)(1D))).V)).V, sg_2647);
sh_2649 = Call(el_14, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffd8c6"))).Put("stroke-width", ((V)(1.3))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.75))).V, sg_2647);
kc_2650 = Call(el_14, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#e8402e"))).Put("stroke-width", ((V)(2.1))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V, sg_2647);
ms_2651 = Call(el_14, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffd43b"))).Put("stroke-width", ((V)(1.8))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V, sg_2647);
lip_2652 = Call(el_14, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#fff3dc"))).Put("stroke-width", ((V)(1.7))).Put("opacity", ((V)(0.85))).Put("stroke-linecap", ((V)("round"))).V, SG_2642);
shn_2653 = Call(el_14, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#fff4dc"))).Put("stroke-width", ((V)(4D))).Put("opacity", ((V)(0.2))).Put("stroke-linecap", ((V)("round"))).V, SG_2642);
return NewObj(30).Put("O", O_2634).Put("OF", OF_2635).Put("OFi", OFi_2644).Put("topY", topY_2643).Put("T", T_2631).Put("b", b_2632).Put("rings", rings_2636).Put("ringsF", ringsF_2637).Put("zF", zF_2638).Put("zz", zz_2641).Put("SG", SG_2642).Put("back", back_2645).Put("inB", inB_2646).Put("sg", sg_2647).Put("sp", sp_2648).Put("sh", sh_2649).Put("kc", kc_2650).Put("ms", ms_2651).Put("lip", lip_2652).Put("shn", shn_2653).Put("z0", ((V)(4D))).Put("AL", ((V)(0.45))).Put("YC", ((V)(70D))).Put("slab", ((V)(1D))).Put("rx", ((V)(41D))).Put("ya", ((V)(50D))).Put("yb", ((V)(87D))).Put("rT", Fn((V _self2622, int _argc2724, V y_2730, V _a2727, V _a2728, V _a2729, V[] _rest2725) => {
return Call(halfW_38, V.Undef, O_2634, y_2730);
}, 1, "rT", true)).Put("zAt", Fn((V _self2622, int _argc2731, V x_2737, V y_2738, V _a2735, V _a2736, V[] _rest2732) => {
return Add(((V)((4D * ToNum(Call(zz_2641, V.Undef, y_2738))))), Call(zF_2638, V.Undef, x_2737, y_2738));
}, 2, "zAt", true)).Put("zE", Fn((V _self2622, int _argc2739, V dx_2745, V dy_2746, V _a2743, V _a2744, V[] _rest2740) => {
return Add(Add(((V)((4D * ToNum(Call(zz_2641, V.Undef, Add(Get(S_2629, "HY"), dy_2746)))))), Call(zF_2638, V.Undef, Add(Get(S_2629, "HX"), dx_2745), Add(Get(S_2629, "HY"), dy_2746))), ((V)(0.3)));
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self2747, int _argc2748, V B_2754, V D_2755, V _a2752, V _a2753, V[] _rest2749) => {
V set_2756 = default;
V slip_2757 = default;
V hug_2758 = default;
V z0_2759 = default;
V zc_2760 = default;
V W_2761 = default;
V P_2762 = default;
V zz_2763 = default;
V fr_2764 = default;
V s_2765 = default;
V half_2766 = default;
V r_2767 = default;
V yS_2768 = default;
V sph_2769 = default;
V line_2770 = default;
V lp_2771 = default;
V sn_2772 = default;
V L_2773 = default;
if (_self2747.IsNullish) _self2747 = GlobalV;
{ V _t2774 = D_2755;
if (_t2774.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t2774));
{ V _t2775 = Get(_t2774, "set");
set_2756 = _t2775; } }
slip_2757 = ((V)((ToNum(Call(clamp_12, V.Undef, Invoke(D_2755, "bv", ((V)("slip"))), ((V)((-1.3))), ((V)(1.3)))) * 15D)));
hug_2758 = Call(clamp_12, V.Undef, Invoke(D_2755, "bv", ((V)("hug"))), ((V)((-1D))), ((V)(1.5)));
z0_2759 = Add(Get(B_2754, "z0"), ((V)((ToNum(hug_2758) * 3D))));
zc_2760 = Add(z0_2759, Get(B_2754, "T"));
W_2761 = Call(tiltW_49, V.Undef, D_2755, Get(B_2754, "AL"), Get(B_2754, "YC"), zc_2760);
P_2762 = Get(W_2761, "P");
zz_2763 = Fn((V _self2747, int _argc2776, V y_2782, V _a2779, V _a2780, V _a2781, V[] _rest2777) => {
return ((V)((ToNum(z0_2759) * ToNum(Invoke(B_2754, "zz", y_2782)))));
}, 1, "", true);
fr_2764 = (GeN(Get(D_2755, "front"), 0D) ? V.True : V.False);
s_2765 = ((V)((Truthy(fr_2764) ? 1D : (-1D))));
half_2766 = Fn((V _self2747, int _argc2783, V sg_2789, V RG_2790, V _a2787, V _a2788, V[] _rest2784) => {
V o_2791 = default;
o_2791 = Arr();
Invoke(RG_2790, "forEach", Fn((V _self2747, int _argc2792, V R_2798, V _a2795, V _a2796, V _a2797, V[] _rest2793) => {
return Invoke(Get(R_2798, "Q"), "forEach", Fn((V _self2747, int _argc2799, V p_2805, V _a2802, V _a2803, V _a2804, V[] _rest2800) => {
return Invoke(o_2791, "push", Call(P_2762, V.Undef, GetIdx(p_2805, 0D), GetIdx(p_2805, 1D), ((V)((ToNum(sg_2789) * ToNum(Add(Call(zz_2763, V.Undef, GetIdx(p_2805, 1D)), Get(R_2798, "z"))))))));
}, 1, "", true));
}, 1, "", true));
return Invoke(D_2755, "hull", o_2791);
return default;
}, 2, "", true);
Set(B_2754, "d", Call(half_2766, V.Undef, ((V)(1D)), (Truthy(fr_2764) ? Get(B_2754, "rings") : Get(B_2754, "ringsF"))));
Call(set_2756, V.Undef, Get(B_2754, "back"), ((V)("d")), Call(half_2766, V.Undef, ((V)((-1D))), (Truthy(fr_2764) ? Get(B_2754, "ringsF") : Get(B_2754, "rings"))));
Call(set_2756, V.Undef, Get(B_2754, "inB"), ((V)("d")), Call(polyW_18, V.Undef, Invoke(Get(B_2754, "OFi"), "map", Fn((V _self2747, int _argc2806, V p_2812, V _a2809, V _a2810, V _a2811, V[] _rest2807) => {
return Call(P_2762, V.Undef, GetIdx(p_2812, 0D), GetIdx(p_2812, 1D), ((V)(((-ToNum(s_2765)) * (ToNum(Call(zz_2763, V.Undef, GetIdx(p_2812, 1D))) - 0.2)))));
}, 1, "", true))));
r_2767 = ((V)((8.4 - (Max(0D, (-ToNum(hug_2758))) * 0.8))));
yS_2768 = ((V)((52.5 - (Max(0D, (-ToNum(hug_2758))) * 1.5))));
sph_2769 = Fn((V _self2747, int _argc2813, V c_2819, V _a2816, V _a2817, V _a2818, V[] _rest2814) => {
V o_2820 = default;
o_2820 = Arr();
{
V i_2821 = default;
i_2821 = ((V)(0D));
while (true) {
if (!(LeN(i_2821, 6D))) break;
V th_2823 = default;
V cr_2824 = default;
th_2823 = ((V)((((-System.Math.PI) / 2D) + ((System.Math.PI * ToNum(i_2821)) / 6D))));
cr_2824 = ((V)(FdLibm.Cos(ToNum(th_2823))));
{
V k_2825 = default;
k_2825 = ((V)(0D));
while (true) {
if (!(LtN(k_2825, 12D))) break;
V f_2827 = default;
f_2827 = ((V)(((ToNum(k_2825) / 12D) * ToNum(TAU_9))));
Invoke(o_2820, "push", Call(P_2762, V.Undef, Add(GetIdx(c_2819, 0D), ((V)(((ToNum(r_2767) * ToNum(cr_2824)) * FdLibm.Sin(ToNum(f_2827)))))), Add(GetIdx(c_2819, 1D), ((V)((ToNum(r_2767) * FdLibm.Sin(ToNum(th_2823)))))), Add(GetIdx(c_2819, 2D), ((V)(((ToNum(r_2767) * ToNum(cr_2824)) * FdLibm.Cos(ToNum(f_2827))))))));
PostInc(ref k_2825, 1D);
}
}
PostInc(ref i_2821, 1D);
}
}
return o_2820;
return default;
}, 1, "", true);
Call(set_2756, V.Undef, Get(B_2754, "sp"), ((V)("d")), Invoke(D_2755, "hull", Invoke(Call(sph_2769, V.Undef, Arr(Add(((V)(12D)), slip_2757), yS_2768, ((V)(0D)))), "concat", Call(sph_2769, V.Undef, Arr(Add(((V)(88D)), slip_2757), yS_2768, ((V)(0D)))))));
line_2770 = Fn((V _self2747, int _argc2828, V fn_2834, V x0_2835, V x1_2836, V st_2837, V[] _rest2829) => {
V Q_2838 = default;
V ok_2839 = default;
Q_2838 = Arr();
ok_2839 = Arr();
{
V x_2840 = default;
x_2840 = x0_2835;
while (true) {
if (!(Le(x_2840, x1_2836))) break;
V ph_2842 = default;
V ny_2843 = default;
V nz_2844 = default;
ph_2842 = Call(fn_2834, V.Undef, x_2840);
ny_2843 = ((V)((-FdLibm.Cos(ToNum(ph_2842)))));
nz_2844 = ((V)(FdLibm.Sin(ToNum(ph_2842))));
Invoke(Q_2838, "push", Call(P_2762, V.Undef, Add(x_2840, slip_2757), Add(yS_2768, ((V)(((ToNum(r_2767) * ToNum(ny_2843)) * 1.03)))), ((V)(((ToNum(r_2767) * ToNum(nz_2844)) * 1.03)))));
Invoke(ok_2839, "push", (GtN(Invoke(W_2761, "F", Add(x_2840, slip_2757), Add(yS_2768, ((V)((ToNum(r_2767) * ToNum(ny_2843))))), ((V)((ToNum(r_2767) * ToNum(nz_2844)))), ((V)(((ToNum(ny_2843) * 0D) + 0D))), ny_2843, nz_2844), 0.02) ? V.True : V.False));
x_2840 = Add(x_2840, st_2837);
}
}
return Call(runs_21, V.Undef, Q_2838, ok_2839);
return default;
}, 4, "", true);
Call(set_2756, V.Undef, Get(B_2754, "kc"), ((V)("d")), (Call(line_2770, V.Undef, Fn((V _self2747, int _argc2845, V x_2851, V _a2848, V _a2849, V _a2850, V[] _rest2846) => {
return ((V)((0.32 + (0.24 * FdLibm.Sin(((ToNum(x_2851) - 15D) * 0.9))))));
}, 1, "", true), ((V)(15D)), ((V)(85D)), ((V)(0.9))) is var _t2852 && Truthy(_t2852) ? _t2852 : ((V)("M0 0"))));
Call(set_2756, V.Undef, Get(B_2754, "ms"), ((V)("d")), (Call(line_2770, V.Undef, Fn((V _self2747, int _argc2853, V x_2859, V _a2856, V _a2857, V _a2858, V[] _rest2854) => {
V u_2860 = default;
V tri_2861 = default;
u_2860 = ((V)(((ToNum(x_2859) - 16D) / 4D)));
tri_2861 = ((V)(((System.Math.Abs(((((ToNum(u_2860) % 2D) + 2D) % 2D) - 1D)) * 2D) - 1D)));
return ((V)(((-0.2) + (0.3 * ToNum(tri_2861)))));
return default;
}, 1, "", true), ((V)(16D)), ((V)(84D)), ((V)(1D))) is var _t2862 && Truthy(_t2862) ? _t2862 : ((V)("M0 0"))));
Call(set_2756, V.Undef, Get(B_2754, "sh"), ((V)("d")), (Call(line_2770, V.Undef, Fn((V _self2747, int _argc2863, V _a2865, V _a2866, V _a2867, V _a2868, V[] _rest2864) => {
return ((V)(0.95));
}, 0, "", true), ((V)(18D)), ((V)(82D)), ((V)(4D))) is var _t2869 && Truthy(_t2869) ? _t2869 : ((V)("M0 0"))));
lp_2771 = Arr();
sn_2772 = Arr();
{
V x_2870 = default;
x_2870 = ((V)(12D));
while (true) {
if (!(LeN(x_2870, 88D))) break;
V ty_2872 = default;
ty_2872 = Invoke(B_2754, "topY", x_2870);
if (GtN(ty_2872, 72D)) {
goto _cont2871;
}
Invoke(lp_2771, "push", Call(P_2762, V.Undef, x_2870, Add(ty_2872, ((V)(0.5))), ((V)((ToNum(s_2765) * ToNum(Add(Call(zz_2763, V.Undef, Add(ty_2872, ((V)(0.5)))), ((V)(0.7)))))))));
if ((GeN(x_2870, 24D) && LeN(x_2870, 76D))) {
Invoke(sn_2772, "push", Call(P_2762, V.Undef, x_2870, Add(ty_2872, ((V)(5.2))), ((V)((ToNum(s_2765) * ToNum(Add(Call(zz_2763, V.Undef, Add(ty_2872, ((V)(5.2)))), ((V)((ToNum(Get(B_2754, "T")) * 0.9))))))))));
}
_cont2871: ;
x_2870 = Add(x_2870, ((V)(2D)));
}
}
Call(set_2756, V.Undef, Get(B_2754, "lip"), ((V)("d")), Call(runs_21, V.Undef, lp_2771, Invoke(lp_2771, "map", Fn((V _self2747, int _argc2873, V _a2875, V _a2876, V _a2877, V _a2878, V[] _rest2874) => {
return (true ? V.True : V.False);
}, 0, "", true))));
Call(set_2756, V.Undef, Get(B_2754, "shn"), ((V)("d")), Call(runs_21, V.Undef, sn_2772, Invoke(sn_2772, "map", Fn((V _self2747, int _argc2879, V _a2881, V _a2882, V _a2883, V _a2884, V[] _rest2880) => {
return (true ? V.True : V.False);
}, 0, "", true))));
L_2773 = Invoke(Arr(NewObj(3).Put("id", ((V)("b"))).Put("e", Get(B_2754, "back")).Put("z", Invoke(W_2761, "Z", ((V)(50D)), ((V)(68D)), ((V)(((-ToNum(z0_2759)) - 6D))))).V, NewObj(3).Put("id", ((V)("i"))).Put("e", Get(B_2754, "inB")).Put("z", Add(Invoke(W_2761, "Z", ((V)(50D)), ((V)(68D)), ((V)(((-ToNum(s_2765)) * ToNum(z0_2759))))), ((V)((ToNum(s_2765) * 0.01))))).V, NewObj(3).Put("id", ((V)("s"))).Put("e", Get(B_2754, "sg")).Put("z", Invoke(W_2761, "Z", Add(((V)(50D)), slip_2757), yS_2768, ((V)(0D)))).V, NewObj(3).Put("id", ((V)("f"))).Put("e", Get(Get(Get(B_2754, "S"), "sk"), "e")).Put("z", Invoke(W_2761, "Z", ((V)(50D)), ((V)(68D)), Add(z0_2759, ((V)(6D))))).V, NewObj(3).Put("id", ((V)("l"))).Put("e", Get(B_2754, "lip")).Put("z", Add(Invoke(W_2761, "Z", ((V)(50D)), ((V)(68D)), ((V)((ToNum(s_2765) * ToNum(Add(z0_2759, ((V)(6D)))))))), ((V)(0.01)))).V, NewObj(3).Put("id", ((V)("h"))).Put("e", Get(B_2754, "shn")).Put("z", Add(Invoke(W_2761, "Z", ((V)(50D)), ((V)(68D)), ((V)((ToNum(s_2765) * ToNum(Add(z0_2759, ((V)(6D)))))))), ((V)(0.02)))).V), "sort", Fn((V _self2747, int _argc2885, V a_2891, V b_2892, V _a2889, V _a2890, V[] _rest2886) => {
return ((V)((ToNum(Get(a_2891, "z")) - ToNum(Get(b_2892, "z")))));
}, 2, "", true));
Invoke(SN_43, "order", Get(B_2754, "SG"), L_2773);
return default;
}, 2, "draw", false)).V);
Set(MODELS_42, "peppi", NewObj(2).Put("setup", Fn((V _self2893, int _argc2894, V S_2900, V _a2897, V _a2898, V _a2899, V[] _rest2895) => {
V sk_2901 = default;
V O_2902 = default;
V T_2903 = default;
V b_2904 = default;
V rings_2905 = default;
V cheese_2906 = default;
V cr_2907 = default;
V CR_2908 = default;
V face_2909 = default;
V dec_2910 = default;
V DC_2911 = default;
V spots_2912 = default;
V strings_2913 = default;
V crust_2914 = default;
V @char_2915 = default;
V cl_2916 = default;
if (_self2893.IsNullish) _self2893 = GlobalV;
{ V _t2917 = S_2900;
if (_t2917.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t2917));
{ V _t2918 = Get(_t2917, "sk");
sk_2901 = _t2918; } }
O_2902 = Invoke(S_2900, "outline", sk_2901, ((V)(56D)));
T_2903 = ((V)(2.3));
b_2904 = ((V)(1.4));
rings_2905 = Call(pillowRings_40, V.Undef, O_2902, T_2903, b_2904, ((V)(2D)));
cheese_2906 = Invoke(S_2900, "f", sk_2901);
cr_2907 = GetIdx(Invoke(S_2900, "hide", Fn((V _self2893, int _argc2919, V q_2925, V _a2922, V _a2923, V _a2924, V[] _rest2920) => {
return (Get(q_2925, "inBody") is var _t2926 && !Truthy(_t2926) ? _t2926 : Invoke(NewRegExp(RX10, "^M6\\.5 75\\.5", ""), "test", Invoke(S_2900, "d", q_2925)));
}, 1, "", true)), 0D);
CR_2908 = (Truthy(cr_2907) ? Invoke(S_2900, "f", cr_2907) : ((V)("#eaa95c")));
Invoke(S_2900, "hide", Fn((V _self2893, int _argc2927, V q_2933, V _a2930, V _a2931, V _a2932, V[] _rest2928) => {
return (Get(q_2933, "inBody") is var _t2934 && !Truthy(_t2934) ? _t2934 : Invoke(NewRegExp(RX11, "^M18 80\\.5", ""), "test", Invoke(S_2900, "d", q_2933)));
}, 1, "", true));
Invoke(Get(sk_2901, "e"), "setAttribute", ((V)("fill")), Invoke(S_2900, "rgrad", ((V)("pzd")), Arr(Arr(((V)(0D)), ((V)("#ffe9bf"))), Arr(((V)(0.6)), ((V)("#f0c886"))), Arr(((V)(1D)), ((V)("#c99450"))))));
face_2909 = Invoke(S_2900, "path", NewObj(1).Put("fill", cheese_2906).V);
dec_2910 = Invoke(S_2900, "g");
DC_2911 = Invoke(S_2900, "decals", Fn((V _self2893, int _argc2935, V q_2941, V _a2938, V _a2939, V _a2940, V[] _rest2936) => {
return (Get(q_2941, "inBody") is var _t2942 && !Truthy(_t2942) ? _t2942 : Invoke(S_2900, "dk", q_2941, ((V)("tp"))));
}, 1, "", true), dec_2910);
spots_2912 = Invoke(S_2900, "path", NewObj(2).Put("fill", ((V)("#c98a44"))).Put("opacity", ((V)(0.4))).V);
strings_2913 = Invoke(S_2900, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffd45c"))).Put("stroke-width", ((V)(1.6))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.95))).V);
crust_2914 = Invoke(S_2900, "path", NewObj(1).Put("fill", CR_2908).V);
@char_2915 = Invoke(S_2900, "path", NewObj(2).Put("fill", ((V)("#a8642a"))).Put("opacity", ((V)(0.4))).V);
cl_2916 = Invoke(S_2900, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffeccc"))).Put("stroke-width", ((V)(1.3))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.8))).V);
return NewObj(21).Put("O", O_2902).Put("T", T_2903).Put("b", b_2904).Put("rings", rings_2905).Put("face", face_2909).Put("dec", dec_2910).Put("DC", DC_2911).Put("spots", spots_2912).Put("strings", strings_2913).Put("crust", crust_2914).Put("char", @char_2915).Put("cl", cl_2916).Put("slab", ((V)(1D))).Put("rx", ((V)(41D))).Put("ya", ((V)(20D))).Put("yb", ((V)(78D))).Put("rT", Fn((V _self2893, int _argc2943, V y_2949, V _a2946, V _a2947, V _a2948, V[] _rest2944) => {
return Call(halfW_38, V.Undef, O_2902, y_2949);
}, 1, "rT", true)).Put("zAt", Fn((V _self2893, int _argc2950, V x_2956, V y_2957, V _a2954, V _a2955, V[] _rest2951) => {
return (Truthy(Call(inside_35, V.Undef, O_2902, x_2956, y_2957)) ? T_2903 : ((V)(0D)));
}, 2, "zAt", true)).Put("zE", Fn((V _self2893, int _argc2958, V _a2960, V _a2961, V _a2962, V _a2963, V[] _rest2959) => {
return Add(T_2903, ((V)(0.25)));
}, 0, "zE", true)).Put("cheese", cheese_2906).Put("back", Invoke(S_2900, "rgrad", ((V)("pzb")), Arr(Arr(((V)(0D)), ((V)("#fff2d2"))), Arr(((V)(0.6)), ((V)("#f2d39a"))), Arr(((V)(1D)), ((V)("#d6a660")))))).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self2964, int _argc2965, V B_2971, V D_2972, V _a2969, V _a2970, V[] _rest2966) => {
V P3_2973 = default;
V set_2974 = default;
V T_2975 = default;
V pull_2976 = default;
V flop_2977 = default;
V W_2978 = default;
V all_2979 = default;
V fr_2980 = default;
V s_2981 = default;
V cir_2982 = default;
V C_2983 = default;
V R_2984 = default;
V lp_2985 = default;
V sd_2986 = default;
if (_self2964.IsNullish) _self2964 = GlobalV;
{ V _t2987 = D_2972;
if (_t2987.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t2987));
{ V _t2988 = Get(_t2987, "P3");
P3_2973 = _t2988; }
{ V _t2989 = Get(_t2987, "set");
set_2974 = _t2989; } }
T_2975 = Get(B_2971, "T");
pull_2976 = Call(clamp_12, V.Undef, Invoke(D_2972, "bv", ((V)("pull"))), ((V)(0D)), ((V)(1.2)));
flop_2977 = ((V)((ToNum(Call(clamp_12, V.Undef, Invoke(D_2972, "bv", ((V)("flop"))), ((V)((-1D))), ((V)(1D)))) * 10D)));
W_2978 = Fn((V _self2964, int _argc2990, V x_2996, V y_2997, V z_2998, V _a2995, V[] _rest2991) => {
V u_2999 = default;
u_2999 = Call(clamp_12, V.Undef, ((V)(((46D - ToNum(y_2997)) / 36D))), ((V)(0D)), ((V)(1D)));
return Call(P3_2973, V.Undef, x_2996, Add(y_2997, ((V)((((System.Math.Abs(ToNum(flop_2977)) * ToNum(u_2999)) * ToNum(u_2999)) * 0.35)))), Add(z_2998, ((V)(((ToNum(flop_2977) * ToNum(u_2999)) * ToNum(u_2999))))));
return default;
}, 3, "", true);
all_2979 = Arr();
Invoke(Get(B_2971, "rings"), "forEach", Fn((V _self2964, int _argc3000, V R_3006, V _a3003, V _a3004, V _a3005, V[] _rest3001) => {
return Invoke(Get(R_3006, "Q"), "forEach", Fn((V _self2964, int _argc3007, V p_3013, V _a3010, V _a3011, V _a3012, V[] _rest3008) => {
Invoke(all_2979, "push", Call(W_2978, V.Undef, GetIdx(p_3013, 0D), GetIdx(p_3013, 1D), Get(R_3006, "z")));
Invoke(all_2979, "push", Call(W_2978, V.Undef, GetIdx(p_3013, 0D), GetIdx(p_3013, 1D), ((V)((-ToNum(Get(R_3006, "z")))))));
return default;
}, 1, "", true));
}, 1, "", true));
Set(B_2971, "d", Invoke(D_2972, "hull", all_2979));
fr_2980 = (GeN(Get(D_2972, "front"), 0D) ? V.True : V.False);
s_2981 = ((V)((Truthy(fr_2980) ? 1D : (-1D))));
Call(set_2974, V.Undef, Get(B_2971, "face"), ((V)("d")), Call(polyW_18, V.Undef, Invoke(Get(GetIdx(Get(B_2971, "rings"), (ToNum(Get(Get(B_2971, "rings"), "length")) - 1D)), "Q"), "map", Fn((V _self2964, int _argc3014, V p_3020, V _a3017, V _a3018, V _a3019, V[] _rest3015) => {
return Call(W_2978, V.Undef, GetIdx(p_3020, 0D), GetIdx(p_3020, 1D), ((V)((ToNum(s_2981) * ToNum(T_2975)))));
}, 1, "", true))));
Call(set_2974, V.Undef, Get(B_2971, "face"), ((V)("fill")), (Truthy(fr_2980) ? Get(B_2971, "cheese") : Get(B_2971, "back")));
Invoke(Get(B_2971, "dec"), "setAttribute", ((V)("opacity")), ((V)((Truthy(fr_2980) ? 1D : 0D))));
Call(set_2974, V.Undef, Get(B_2971, "spots"), ((V)("opacity")), ((V)((Truthy(fr_2980) ? 0D : 0.4))));
cir_2982 = Fn((V _self2964, int _argc3021, V x_3027, V y_3028, V r_3029, V z_3030, V[] _rest3022) => {
V n_3031 = default;
n_3031 = (_argc3021 > 4 ? _rest3022[0] : V.Undef);
return Call(polyW_18, V.Undef, Array_from(NewObj(1).Put("length", (n_3031 is var _t3032 && Truthy(_t3032) ? _t3032 : ((V)(14D)))).V, Fn((V _self2964, int _argc3033, V __3039, V k_3040, V _a3037, V _a3038, V[] _rest3034) => {
return Call(W_2978, V.Undef, Add(x_3027, ((V)((ToNum(r_3029) * FdLibm.Cos(((ToNum(k_3040) / ToNum((n_3031 is var _t3041 && Truthy(_t3041) ? _t3041 : ((V)(14D))))) * ToNum(TAU_9))))))), Add(y_3028, ((V)((ToNum(r_3029) * FdLibm.Sin(((ToNum(k_3040) / ToNum((n_3031 is var _t3042 && Truthy(_t3042) ? _t3042 : ((V)(14D))))) * ToNum(TAU_9))))))), z_3030);
}, 2, "", true)));
}, 5, "", true);
if (Truthy(fr_2980)) {
Invoke(Get(B_2971, "DC"), "forEach", Fn((V _self2964, int _argc3043, V o_3049, V i_3050, V _a3047, V _a3048, V[] _rest3044) => {
return Call(set_2974, V.Undef, Get(o_3049, "e"), ((V)("d")), Call(decD_26, V.Undef, o_3049, Fn((V _self2964, int _argc3051, V x_3057, V y_3058, V _a3055, V _a3056, V[] _rest3052) => {
return Call(W_2978, V.Undef, x_3057, y_3058, Add(Add(T_2975, ((V)(0.15))), ((V)((ToNum(i_3050) * 0.004)))));
}, 2, "", true)));
}, 2, "", true));
} else {
Call(set_2974, V.Undef, Get(B_2971, "spots"), ((V)("d")), Invoke(Invoke(Arr(Arr(((V)(44D)), ((V)(40D)), ((V)(1.4))), Arr(((V)(58D)), ((V)(46D)), ((V)(1.3))), Arr(((V)(50D)), ((V)(58D)), ((V)(1.5))), Arr(((V)(40D)), ((V)(62D)), ((V)(1.1))), Arr(((V)(62D)), ((V)(64D)), ((V)(1.2))), Arr(((V)(30D)), ((V)(66D)), ((V)(1D))), Arr(((V)(70D)), ((V)(60D)), ((V)(1.3)))), "map", Fn((V _self2964, int _argc3059, V _a3061, V _a3062, V _a3063, V _a3064, V[] _rest3060) => {
V x_3067 = default;
V y_3069 = default;
V r_3071 = default;
{ V _t3065 = ListOf(_a3061);
{ V _t3066 = GetIdx(_t3065, 0D);
x_3067 = _t3066; }
{ V _t3068 = GetIdx(_t3065, 1D);
y_3069 = _t3068; }
{ V _t3070 = GetIdx(_t3065, 2D);
r_3071 = _t3070; }
}
return Call(cir_2982, V.Undef, x_3067, y_3069, r_3071, ((V)(((-ToNum(T_2975)) - 0.15))), ((V)(8D)));
}, 1, "", true)), "join", ((V)(""))));
}
C_2983 = Arr();
R_2984 = Arr();
{
V i_3072 = default;
i_3072 = ((V)(0D));
while (true) {
if (!(LeN(i_3072, 10D))) break;
V t_3074 = default;
V u_3075 = default;
V x_3076 = default;
V y_3077 = default;
t_3074 = ((V)((ToNum(i_3072) / 10D)));
u_3075 = ((V)((1D - ToNum(t_3074))));
x_3076 = ((V)(((((ToNum(u_3075) * ToNum(u_3075)) * 7.5) + (((2D * ToNum(u_3075)) * ToNum(t_3074)) * 50D)) + ((ToNum(t_3074) * ToNum(t_3074)) * 92.5))));
y_3077 = ((V)((((((ToNum(u_3075) * ToNum(u_3075)) * 80D) + (((2D * ToNum(u_3075)) * ToNum(t_3074)) * 91.5)) + ((ToNum(t_3074) * ToNum(t_3074)) * 80D)) + (ToNum(pull_2976) * 6D))));
Invoke(C_2983, "push", Arr(x_3076, y_3077, ((V)(0D))));
Invoke(R_2984, "push", ((V)((4.6 - (0.9 * Pow((System.Math.Abs((ToNum(t_3074) - 0.5)) * 2D), 3D))))));
PostInc(ref i_3072, 1D);
}
}
Call(set_2974, V.Undef, Get(B_2971, "crust"), ((V)("d")), Call(tubeD_45, V.Undef, D_2972, C_2983, R_2984));
lp_2985 = Invoke(Invoke(C_2983, "slice", ((V)(1D)), ((V)((-1D)))), "map", Fn((V _self2964, int _argc3078, V c_3084, V i_3085, V _a3082, V _a3083, V[] _rest3079) => {
return Call(P3_2973, V.Undef, GetIdx(c_3084, 0D), ((V)((ToNum(GetIdx(c_3084, 1D)) - (ToNum(GetK(R_2984, Add(i_3085, ((V)(1D))))) * 0.72)))), ((V)(((ToNum(s_2981) * ToNum(GetK(R_2984, Add(i_3085, ((V)(1D)))))) * 0.55))));
}, 2, "", true));
Call(set_2974, V.Undef, Get(B_2971, "cl"), ((V)("d")), Call(runs_21, V.Undef, lp_2985, Invoke(lp_2985, "map", Fn((V _self2964, int _argc3086, V _a3088, V _a3089, V _a3090, V _a3091, V[] _rest3087) => {
return (true ? V.True : V.False);
}, 0, "", true))));
Call(set_2974, V.Undef, Get(B_2971, "char"), ((V)("d")), Invoke(Invoke(Arr(Arr(((V)(1.6)), ((V)((-0.1))), ((V)(1.1))), Arr(((V)(3.2)), ((V)(0.25)), ((V)(0.8))), Arr(((V)(4.6)), ((V)((-0.2))), ((V)(1.2))), Arr(((V)(6.3)), ((V)(0.15)), ((V)(0.9))), Arr(((V)(7.7)), ((V)((-0.15))), ((V)(1D))), Arr(((V)(8.9)), ((V)(0.3)), ((V)(0.7)))), "map", Fn((V _self2964, int _argc3092, V _a3094, V _a3095, V _a3096, V _a3097, V[] _rest3093) => {
V a_3105 = default;
V f_3106 = default;
V c_3107 = default;
V rr_3108 = default;
V i_3100 = default;
V dy_3102 = default;
V r_3104 = default;
{ V _t3098 = ListOf(_a3094);
{ V _t3099 = GetIdx(_t3098, 0D);
i_3100 = _t3099; }
{ V _t3101 = GetIdx(_t3098, 1D);
dy_3102 = _t3101; }
{ V _t3103 = GetIdx(_t3098, 2D);
r_3104 = _t3103; }
}
a_3105 = ((V)(System.Math.Floor(ToNum(i_3100))));
f_3106 = ((V)((ToNum(i_3100) - ToNum(a_3105))));
c_3107 = Arr(Add(GetIdx(GetK(C_2983, a_3105), 0D), ((V)(((ToNum(GetIdx(GetK(C_2983, Add(a_3105, ((V)(1D)))), 0D)) - ToNum(GetIdx(GetK(C_2983, a_3105), 0D))) * ToNum(f_3106))))), Add(GetIdx(GetK(C_2983, a_3105), 1D), ((V)(((ToNum(GetIdx(GetK(C_2983, Add(a_3105, ((V)(1D)))), 1D)) - ToNum(GetIdx(GetK(C_2983, a_3105), 1D))) * ToNum(f_3106))))));
rr_3108 = GetK(R_2984, a_3105);
return Call(ellD_20, V.Undef, Call(P3_2973, V.Undef, GetIdx(c_3107, 0D), Add(GetIdx(c_3107, 1D), ((V)((ToNum(dy_3102) * ToNum(rr_3108))))), ((V)(((ToNum(s_2981) * ToNum(rr_3108)) * 0.82)))), ((V)((ToNum(r_3104) * ToNum(Get(D_2972, "kS"))))), ((V)(((ToNum(r_3104) * 0.65) * ToNum(Get(D_2972, "kS"))))), ((V)(0D)));
return default;
}, 1, "", true)), "join", ((V)(""))));
sd_2986 = ((V)(""));
if (GtN(pull_2976, 0.02)) {
Invoke(Arr(((V)(20D)), ((V)(33D)), ((V)(47D)), ((V)(61D)), ((V)(75D))), "forEach", Fn((V _self2964, int _argc3109, V x_3115, V i_3116, V _a3113, V _a3114, V[] _rest3110) => {
V yb_3117 = default;
V a_3118 = default;
V b_3119 = default;
V m_3120 = default;
yb_3117 = ((V)((74D + ((1D - Pow(((ToNum(x_3115) - 50D) / 42D), 2D)) * 5D))));
a_3118 = Call(W_2978, V.Undef, x_3115, ((V)((ToNum(yb_3117) - 1D))), ((V)((ToNum(s_2981) * ToNum(Add(T_2975, ((V)(0.3))))))));
b_3119 = Call(P3_2973, V.Undef, Add(x_3115, ((V)((FdLibm.Sin((ToNum(i_3116) * 2.1)) * 1.2)))), Add(Add(yb_3117, ((V)(2D))), ((V)((ToNum(pull_2976) * 6D)))), ((V)((ToNum(s_2981) * 1D))));
m_3120 = Call(P3_2973, V.Undef, Add(x_3115, ((V)(((FdLibm.Sin(ToNum(Add(((V)((ToNum(Get(D_2972, "ts")) * 6D))), i_3116))) * 0.8) * ToNum(pull_2976))))), Add(Add(yb_3117, ((V)(1D))), ((V)((ToNum(pull_2976) * 3D)))), ((V)((ToNum(s_2981) * ToNum(Add(T_2975, ((V)(0.5))))))));
sd_2986 = ((V)(string.Concat(new string[] { ToStr(sd_2986), "M", ToStr(Call(pt_15, V.Undef, a_3118)), "Q", ToStr(Call(pt_15, V.Undef, m_3120)), " ", ToStr(Call(pt_15, V.Undef, b_3119)) })));
return default;
}, 2, "", true));
}
Call(set_2974, V.Undef, Get(B_2971, "strings"), ((V)("d")), (sd_2986 is var _t3121 && Truthy(_t3121) ? _t3121 : ((V)("M0 0"))));
Call(set_2974, V.Undef, Get(B_2971, "strings"), ((V)("stroke-width")), Call(r2_11, V.Undef, ((V)((0.6 + (ToNum(pull_2976) * 1.2))))));
return default;
}, 2, "draw", false)).V);
Set(MODELS_42, "sunny", NewObj(2).Put("setup", Fn((V _self3122, int _argc3123, V S_3129, V _a3126, V _a3127, V _a3128, V[] _rest3124) => {
V sk_3130 = default;
V O_3131 = default;
V rT_3132 = default;
V YK_3133 = default;
V crack_3134 = default;
V spk_3135 = default;
V open_3136 = default;
V yolk_3137 = default;
V capE_3138 = default;
V capL_3139 = default;
V SP_3140 = default;
V OS_3141 = default;
V roll_3142 = default;
if (_self3122.IsNullish) _self3122 = GlobalV;
{ V _t3143 = S_3129;
if (_t3143.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t3143));
{ V _t3144 = Get(_t3143, "sk");
sk_3130 = _t3144; } }
O_3131 = Invoke(S_3129, "outline", sk_3130, ((V)(72D)));
rT_3132 = Fn((V _self3122, int _argc3145, V y_3151, V _a3148, V _a3149, V _a3150, V[] _rest3146) => {
return Call(halfW_38, V.Undef, O_3131, Call(clamp_12, V.Undef, y_3151, ((V)(12.2)), ((V)(91.8))));
}, 1, "", true);
YK_3133 = ((V)(31.8));
Invoke(S_3129, "hide", Fn((V _self3122, int _argc3152, V q_3158, V _a3155, V _a3156, V _a3157, V[] _rest3153) => {
return (Get(q_3158, "inBody") is var _t3159 && !Truthy(_t3159) ? _t3159 : ((SEqS(Invoke(S_3129, "s", q_3158), "#c9a87c") || SEqS(Invoke(S_3129, "f", q_3158), "#d8c09c")) ? V.True : V.False));
}, 1, "", true));
crack_3134 = Invoke(S_3129, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#c9a87c"))).Put("stroke-width", ((V)(0.9))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).V);
spk_3135 = Invoke(S_3129, "path", NewObj(2).Put("fill", ((V)("#d8c09c"))).Put("opacity", ((V)(0.55))).V);
open_3136 = Invoke(S_3129, "path", NewObj(1).Put("fill", ((V)("#fffdf6"))).V);
yolk_3137 = Invoke(S_3129, "path", NewObj(1).Put("fill", Invoke(S_3129, "rgrad", ((V)("sny")), Arr(Arr(((V)(0D)), ((V)("#fff3a8"))), Arr(((V)(0.6)), ((V)("#ffc42c"))), Arr(((V)(1D)), ((V)("#ef9410")))), NewObj(3).Put("cx", ((V)("42%"))).Put("cy", ((V)("35%"))).Put("r", ((V)("70%"))).V)).V);
capE_3138 = Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", Invoke(S_3129, "f", sk_3130)).V, Get(S_3129, "gB"));
capL_3139 = Call(el_14, V.Undef, ((V)("path")), NewObj(3).Put("fill", ((V)("none"))).Put("stroke", ((V)("#c9a87c"))).Put("stroke-width", ((V)(0.8))).V, Get(S_3129, "gB"));
SP_3140 = Invoke(Array_from(NewObj(1).Put("length", ((V)(18D))).V, Fn((V _self3122, int _argc3171, V __3177, V i_3178, V _a3175, V _a3176, V[] _rest3172) => {
return Arr(((V)((ToNum(Call(rnd_22, V.Undef, ((V)((ToNum(i_3178) * 3.7))))) * ToNum(TAU_9)))), ((V)((16D + (ToNum(Call(rnd_22, V.Undef, ((V)((ToNum(i_3178) * 5.9))))) * 72D)))));
}, 2, "", true)), "filter", Fn((V _self3122, int _argc3160, V _a3162, V _a3163, V _a3164, V _a3165, V[] _rest3161) => {
V f_3168 = default;
V y_3170 = default;
{ V _t3166 = ListOf(_a3162);
{ V _t3167 = GetIdx(_t3166, 0D);
f_3168 = _t3167; }
{ V _t3169 = GetIdx(_t3166, 1D);
y_3170 = _t3169; }
}
return (!((((System.Math.Abs(FdLibm.Atan2(FdLibm.Sin(ToNum(f_3168)), FdLibm.Cos(ToNum(f_3168)))) < 0.55) && GtN(y_3170, 50D)) && LtN(y_3170, 72D))) ? V.True : V.False);
}, 1, "", true));
OS_3141 = Invoke(O_3131, "filter", Fn((V _self3122, int _argc3179, V p_3185, V i_3186, V _a3183, V _a3184, V[] _rest3180) => {
return (((ToNum(i_3186) % 2D) == 0D) ? V.True : V.False);
}, 2, "", true));
roll_3142 = Fn((V _self3122, int _argc3187, V a_3193, V P_3194, V G_3195, V sy_3196, V[] _rest3188) => {
V c_3197 = default;
V s_3198 = default;
V lf_3199 = default;
V px_3200 = default;
V cx_3201 = default;
V cy_3202 = default;
V my_3203 = default;
c_3197 = ((V)(FdLibm.Cos(ToNum(a_3193))));
s_3198 = ((V)(FdLibm.Sin(ToNum(a_3193))));
lf_3199 = (((V)(ToNum(Get(P_3194, "lift")))) is var _t3204 && Truthy(_t3204) ? _t3204 : ((V)(0D)));
px_3200 = (((V)(ToNum(Get(P_3194, "x")))) is var _t3205 && Truthy(_t3205) ? _t3205 : ((V)(0D)));
cx_3201 = Add(((V)(50D)), px_3200);
cy_3202 = ((V)(((ToNum(G_3195) - ToNum(lf_3199)) - ((ToNum(G_3195) - 56D) * ToNum(sy_3196)))));
my_3203 = ((V)((-1000000000D)));
Invoke(OS_3141, "forEach", Fn((V _self3122, int _argc3206, V p_3212, V _a3209, V _a3210, V _a3211, V[] _rest3207) => {
V gx_3213 = default;
V gy_3214 = default;
V y_3215 = default;
gx_3213 = Add(GetIdx(p_3212, 0D), px_3200);
gy_3214 = ((V)(((ToNum(G_3195) - ToNum(lf_3199)) - ((ToNum(G_3195) - ToNum(GetIdx(p_3212, 1D))) * ToNum(sy_3196)))));
y_3215 = Add(Add(cy_3202, ((V)(((ToNum(gx_3213) - ToNum(cx_3201)) * ToNum(s_3198))))), ((V)(((ToNum(gy_3214) - ToNum(cy_3202)) * ToNum(c_3197)))));
if (Gt(y_3215, my_3203)) {
my_3203 = y_3215;
}
return default;
}, 1, "", true));
return NewObj(5).Put("c", c_3197).Put("s", s_3198).Put("cx", cx_3201).Put("cy", cy_3202).Put("up", ((V)((ToNum(my_3203) - (ToNum(G_3195) - ToNum(lf_3199)))))).V;
return default;
}, 4, "", true);
return NewObj(15).Put("O", O_3131).Put("rT", rT_3132).Put("YK", YK_3133).Put("crack", crack_3134).Put("spk", spk_3135).Put("open", open_3136).Put("yolk", yolk_3137).Put("capE", capE_3138).Put("capL", capL_3139).Put("SP", SP_3140).Put("roll", roll_3142).Put("rx", ((V)(30D))).Put("ya", ((V)(30D))).Put("yb", ((V)(88D))).Put("zE", Fn((V _self3122, int _argc3216, V dx_3222, V dy_3223, V _a3220, V _a3221, V[] _rest3217) => {
V r_3224 = default;
r_3224 = Call(rT_3132, V.Undef, Add(Get(S_3129, "HY"), dy_3223));
return ((V)((System.Math.Sqrt(Max(0D, ((ToNum(r_3224) * ToNum(r_3224)) - (ToNum(dx_3222) * ToNum(dx_3222))))) + 0.3)));
return default;
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self3225, int _argc3226, V B_3232, V D_3233, V _a3230, V _a3231, V[] _rest3227) => {
V P3_3234 = default;
V set_3235 = default;
V rT_3236 = default;
V YK_3237 = default;
V cap_3238 = default;
V wob_3239 = default;
V ring_3240 = default;
V y0_3241 = default;
V hp_3242 = default;
V rk_3243 = default;
V CA_3244 = default;
V cq_3245 = default;
V EL_3246 = default;
V PE_3247 = default;
V yr_3248 = default;
V yk_3249 = default;
V lift_3250 = default;
V tip_3251 = default;
V ct_3252 = default;
V st_3253 = default;
V pv_3254 = default;
V cp_3255 = default;
V cl_3256 = default;
if (_self3225.IsNullish) _self3225 = GlobalV;
{ V _t3257 = D_3233;
if (_t3257.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t3257));
{ V _t3258 = Get(_t3257, "P3");
P3_3234 = _t3258; }
{ V _t3259 = Get(_t3257, "set");
set_3235 = _t3259; } }
rT_3236 = Get(B_3232, "rT");
YK_3237 = Get(B_3232, "YK");
cap_3238 = Call(clamp_12, V.Undef, Invoke(D_3233, "bv", ((V)("cap"))), ((V)(0D)), ((V)(1.2)));
wob_3239 = Call(clamp_12, V.Undef, Invoke(D_3233, "bv", ((V)("wob"))), ((V)(0D)), ((V)(1.6)));
ring_3240 = Fn((V _self3225, int _argc3260, V r_3266, V y_3267, V n_3268, V _a3265, V[] _rest3261) => {
return Array_from(NewObj(1).Put("length", n_3268).V, Fn((V _self3225, int _argc3269, V __3275, V k_3276, V _a3273, V _a3274, V[] _rest3270) => {
V f_3277 = default;
f_3277 = ((V)(((ToNum(k_3276) / ToNum(n_3268)) * ToNum(TAU_9))));
return Call(P3_3234, V.Undef, ((V)((50D + (ToNum(r_3266) * FdLibm.Sin(ToNum(f_3277)))))), y_3267, ((V)((ToNum(r_3266) * FdLibm.Cos(ToNum(f_3277))))));
return default;
}, 2, "", true));
}, 3, "", true);
y0_3241 = (GtN(cap_3238, 0.02) ? YK_3237 : ((V)(12.2)));
hp_3242 = Arr();
{
V i_3278 = default;
i_3278 = ((V)(0D));
while (true) {
if (!(LeN(i_3278, 18D))) break;
V y_3280 = default;
y_3280 = Add(y0_3241, ((V)((((91.8 - ToNum(y0_3241)) * ToNum(i_3278)) / 18D))));
InvokeSpread(hp_3242, "push", new ArrBuilder().Spread(Call(ring_3240, V.Undef, Call(rT_3236, V.Undef, y_3280), y_3280, ((V)(24D)))).V);
PostInc(ref i_3278, 1D);
}
}
Set(B_3232, "d", Invoke(D_3233, "hull", hp_3242));
Call(set_3235, V.Undef, Get(B_3232, "spk"), ((V)("d")), (Invoke(Invoke(Invoke(Get(B_3232, "SP"), "filter", Fn((V _self3225, int _argc3292, V _a3294, V _a3295, V _a3296, V _a3297, V[] _rest3293) => {
V f_3300 = default;
V y_3302 = default;
{ V _t3298 = ListOf(_a3294);
{ V _t3299 = GetIdx(_t3298, 0D);
f_3300 = _t3299; }
{ V _t3301 = GetIdx(_t3298, 1D);
y_3302 = _t3301; }
}
return ((Gt(y_3302, Add(y0_3241, ((V)(1D)))) && GtN(Invoke(D_3233, "facing", ((V)((50D + (ToNum(Call(rT_3236, V.Undef, y_3302)) * FdLibm.Sin(ToNum(f_3300)))))), y_3302, ((V)((ToNum(Call(rT_3236, V.Undef, y_3302)) * FdLibm.Cos(ToNum(f_3300))))), ((V)(FdLibm.Sin(ToNum(f_3300)))), ((V)(0D)), ((V)(FdLibm.Cos(ToNum(f_3300))))), 0.05)) ? V.True : V.False);
}, 1, "", true)), "map", Fn((V _self3225, int _argc3281, V _a3283, V _a3284, V _a3285, V _a3286, V[] _rest3282) => {
V f_3289 = default;
V y_3291 = default;
{ V _t3287 = ListOf(_a3283);
{ V _t3288 = GetIdx(_t3287, 0D);
f_3289 = _t3288; }
{ V _t3290 = GetIdx(_t3287, 1D);
y_3291 = _t3290; }
}
return Call(circD_19, V.Undef, Call(P3_3234, V.Undef, ((V)((50D + (ToNum(Add(Call(rT_3236, V.Undef, y_3291), ((V)(0.1)))) * FdLibm.Sin(ToNum(f_3289)))))), y_3291, ((V)((ToNum(Add(Call(rT_3236, V.Undef, y_3291), ((V)(0.1)))) * FdLibm.Cos(ToNum(f_3289)))))), ((V)((0.75 * ToNum(Get(D_3233, "kS"))))));
}, 1, "", true)), "join", ((V)(""))) is var _t3303 && Truthy(_t3303) ? _t3303 : ((V)("M0 0"))));
rk_3243 = Call(rT_3236, V.Undef, YK_3237);
CA_3244 = Invoke(Get(SN_43, "h"), "frontArc", D_3233, rk_3243, YK_3237, ((V)(72D)));
cq_3245 = Invoke(CA_3244, "map", Fn((V _self3225, int _argc3304, V f_3310, V i_3311, V _a3308, V _a3309, V[] _rest3305) => {
return Call(P3_3234, V.Undef, ((V)((50D + (ToNum(Add(rk_3243, ((V)(0.1)))) * FdLibm.Sin(ToNum(f_3310)))))), Add(YK_3237, ((V)((NumTruthy((ToNum(i_3311) % 2D)) ? (-1.6) : 1.4)))), ((V)((ToNum(Add(rk_3243, ((V)(0.1)))) * FdLibm.Cos(ToNum(f_3310))))));
}, 2, "", true));
if (LeN(cap_3238, 0.02)) {
Call(set_3235, V.Undef, Get(B_3232, "crack"), ((V)("d")), (Call(runs_21, V.Undef, cq_3245, Invoke(cq_3245, "map", Fn((V _self3225, int _argc3312, V _a3314, V _a3315, V _a3316, V _a3317, V[] _rest3313) => {
return (true ? V.True : V.False);
}, 0, "", true))) is var _t3318 && Truthy(_t3318) ? _t3318 : ((V)("M0 0"))));
Invoke(Arr(((V)("open")), ((V)("yolk")), ((V)("capE")), ((V)("capL"))), "forEach", Fn((V _self3225, int _argc3319, V k_3325, V _a3322, V _a3323, V _a3324, V[] _rest3320) => {
return Call(set_3235, V.Undef, GetK(B_3232, k_3325), ((V)("d")), ((V)("M0 0")));
}, 1, "", true));
return default;
}
Call(set_3235, V.Undef, Get(B_3232, "crack"), ((V)("d")), ((V)("M0 0")));
EL_3246 = ((V)(0.22));
PE_3247 = Fn((V _self3225, int _argc3326, V x_3332, V y_3333, V z_3334, V _a3331, V[] _rest3327) => {
V p_3335 = default;
p_3335 = Call(P3_3234, V.Undef, x_3332, y_3333, z_3334);
return Arr(GetIdx(p_3335, 0D), Add(GetIdx(p_3335, 1D), ((V)((ToNum(EL_3246) * (ToNum(Invoke(D_3233, "Z3", x_3332, y_3333, z_3334)) - ToNum(rk_3243)))))));
return default;
}, 3, "", true);
Call(set_3235, V.Undef, Get(B_3232, "open"), ((V)("d")), Call(polyW_18, V.Undef, Array_from(NewObj(1).Put("length", ((V)(36D))).V, Fn((V _self3225, int _argc3336, V __3342, V k_3343, V _a3340, V _a3341, V[] _rest3337) => {
V f_3344 = default;
f_3344 = ((V)(((ToNum(k_3343) / 36D) * ToNum(TAU_9))));
return Call(PE_3247, V.Undef, ((V)((50D + (ToNum(rk_3243) * FdLibm.Sin(ToNum(f_3344)))))), YK_3237, ((V)((ToNum(rk_3243) * FdLibm.Cos(ToNum(f_3344))))));
return default;
}, 2, "", true))));
yr_3248 = ((V)(((ToNum(rk_3243) * 0.62) * (1D + ((ToNum(wob_3239) * 0.06) * FdLibm.Sin((ToNum(Get(D_3233, "ts")) * 15D)))))));
yk_3249 = ((V)(((ToNum(YK_3237) - 1.2) - ((ToNum(wob_3239) * 0.6) * FdLibm.Sin((ToNum(Get(D_3233, "ts")) * 17D))))));
Call(set_3235, V.Undef, Get(B_3232, "yolk"), ((V)("d")), Call(polyW_18, V.Undef, Array_from(NewObj(1).Put("length", ((V)(30D))).V, Fn((V _self3225, int _argc3345, V __3351, V k_3352, V _a3349, V _a3350, V[] _rest3346) => {
V f_3353 = default;
f_3353 = ((V)(((ToNum(k_3352) / 30D) * ToNum(TAU_9))));
return Call(PE_3247, V.Undef, ((V)((50D + (ToNum(yr_3248) * FdLibm.Sin(ToNum(f_3353)))))), yk_3249, ((V)((ToNum(yr_3248) * FdLibm.Cos(ToNum(f_3353))))));
return default;
}, 2, "", true))));
lift_3250 = ((V)((ToNum(cap_3238) * 11D)));
tip_3251 = ((V)((((ToNum(cap_3238) * 58D) * System.Math.PI) / 180D)));
ct_3252 = ((V)(FdLibm.Cos(ToNum(tip_3251))));
st_3253 = ((V)(FdLibm.Sin(ToNum(tip_3251))));
pv_3254 = Arr(((V)(50D)), YK_3237, ((V)((-ToNum(rk_3243)))));
cp_3255 = Arr();
{
V i_3354 = default;
i_3354 = ((V)(0D));
while (true) {
if (!(LeN(i_3354, 8D))) break;
V y_3356 = default;
V r_3357 = default;
y_3356 = ((V)((12.2 + (((ToNum(YK_3237) - 12.2) * ToNum(i_3354)) / 8D))));
r_3357 = Call(rT_3236, V.Undef, y_3356);
{
V k_3358 = default;
k_3358 = ((V)(0D));
while (true) {
if (!(LtN(k_3358, 20D))) break;
V f_3360 = default;
V x_3361 = default;
V z_3362 = default;
V vy_3363 = default;
V vz_3364 = default;
f_3360 = ((V)(((ToNum(k_3358) / 20D) * ToNum(TAU_9))));
x_3361 = ((V)((50D + (ToNum(r_3357) * FdLibm.Sin(ToNum(f_3360))))));
z_3362 = ((V)((ToNum(r_3357) * FdLibm.Cos(ToNum(f_3360)))));
vy_3363 = ((V)((ToNum(y_3356) - ToNum(GetIdx(pv_3254, 1D)))));
vz_3364 = ((V)((ToNum(z_3362) - ToNum(GetIdx(pv_3254, 2D)))));
Invoke(cp_3255, "push", Call(P3_3234, V.Undef, x_3361, ((V)(((ToNum(Add(GetIdx(pv_3254, 1D), ((V)((ToNum(vy_3363) * ToNum(ct_3252)))))) - (ToNum(vz_3364) * ToNum(st_3253))) - ToNum(lift_3250)))), Add(Add(GetIdx(pv_3254, 2D), ((V)((ToNum(vy_3363) * ToNum(st_3253))))), ((V)((ToNum(vz_3364) * ToNum(ct_3252)))))));
PostInc(ref k_3358, 1D);
}
}
PostInc(ref i_3354, 1D);
}
}
Call(set_3235, V.Undef, Get(B_3232, "capE"), ((V)("d")), Invoke(D_3233, "hull", cp_3255));
cl_3256 = Arr();
{
V k_3365 = default;
k_3365 = ((V)(0D));
while (true) {
if (!(LeN(k_3365, 24D))) break;
V f_3367 = default;
V x_3368 = default;
V z_3369 = default;
V vz_3370 = default;
f_3367 = ((V)((((-System.Math.PI) / 2D) + ((System.Math.PI * ToNum(k_3365)) / 24D))));
x_3368 = ((V)((50D + (ToNum(rk_3243) * FdLibm.Sin(ToNum(f_3367))))));
z_3369 = ((V)((ToNum(rk_3243) * FdLibm.Cos(ToNum(f_3367)))));
vz_3370 = ((V)((ToNum(z_3369) - ToNum(GetIdx(pv_3254, 2D)))));
Invoke(cl_3256, "push", Call(P3_3234, V.Undef, x_3368, ((V)(((ToNum(GetIdx(pv_3254, 1D)) - (ToNum(vz_3370) * ToNum(st_3253))) - ToNum(lift_3250)))), Add(GetIdx(pv_3254, 2D), ((V)((ToNum(vz_3370) * ToNum(ct_3252)))))));
PostInc(ref k_3365, 1D);
}
}
Call(set_3235, V.Undef, Get(B_3232, "capL"), ((V)("d")), Call(runs_21, V.Undef, cl_3256, Invoke(cl_3256, "map", Fn((V _self3225, int _argc3371, V _a3373, V _a3374, V _a3375, V _a3376, V[] _rest3372) => {
return (true ? V.True : V.False);
}, 0, "", true))));
return default;
}, 2, "draw", false)).V);
Set(MODELS_42, "khinki", NewObj(2).Put("setup", Fn((V _self3377, int _argc3378, V S_3384, V _a3381, V _a3382, V _a3383, V[] _rest3379) => {
V sk_3385 = default;
V O_3386 = default;
V rT_3387 = default;
V KN_3388 = default;
V kn_3389 = default;
V KF_3390 = default;
V Y0_3391 = default;
V Y1_3392 = default;
V tw_3393 = default;
V xw_3394 = default;
V dep_3395 = default;
V PG_3396 = default;
V LN_3397 = default;
V knob_3398 = default;
V KG_3399 = default;
V KL_3400 = default;
V pep_3401 = default;
V cone_3402 = default;
V kp_3403 = default;
V PE_3404 = default;
V LC_3405 = default;
V limb_3406 = default;
if (_self3377.IsNullish) _self3377 = GlobalV;
{ V _t3407 = S_3384;
if (_t3407.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t3407));
{ V _t3408 = Get(_t3407, "sk");
sk_3385 = _t3408; } }
O_3386 = Invoke(S_3384, "outline", sk_3385, ((V)(80D)));
rT_3387 = Fn((V _self3377, int _argc3409, V y_3415, V _a3412, V _a3413, V _a3414, V[] _rest3410) => {
return Call(halfW_38, V.Undef, O_3386, Call(clamp_12, V.Undef, y_3415, ((V)(27.6)), ((V)(90.2))));
}, 1, "", true);
KN_3388 = Fn((V _self3377, int _argc3416, V y_3422, V _a3419, V _a3420, V _a3421, V[] _rest3417) => {
return ((V)((GeN(y_3422, 20.5) ? (6.9 - ((28.5 - ToNum(y_3422)) * 0.16)) : (5.62 * System.Math.Sqrt(Max(0D, (1D - Pow(((20.5 - ToNum(y_3422)) / 3.6), 2D))))))));
}, 1, "", true);
kn_3389 = GetIdx(Invoke(S_3384, "hide", Fn((V _self3377, int _argc3423, V q_3429, V _a3426, V _a3427, V _a3428, V[] _rest3424) => {
return (Get(q_3429, "inBody") is var _t3430 && !Truthy(_t3430) ? _t3430 : Invoke(NewRegExp(RX12, "^url\\(#k", ""), "test", Invoke(S_3384, "f", q_3429)));
}, 1, "", true)), 0D);
KF_3390 = (Truthy(kn_3389) ? Invoke(S_3384, "f", kn_3389) : ((V)("#e3c895")));
Invoke(S_3384, "hide", Fn((V _self3377, int _argc3431, V q_3437, V _a3434, V _a3435, V _a3436, V[] _rest3432) => {
return (Get(q_3437, "inBody") is var _t3438 && !Truthy(_t3438) ? _t3438 : Invoke(S_3384, "dk", q_3437));
}, 1, "", true));
Y0_3391 = ((V)(28.2));
Y1_3392 = ((V)(90D));
tw_3393 = Fn((V _self3377, int _argc3439, V y_3445, V _a3442, V _a3443, V _a3444, V[] _rest3440) => {
return ((V)((0.55 * Pow((1D - ToNum(Call(clamp_12, V.Undef, ((V)(((ToNum(y_3445) - ToNum(Y0_3391)) / 30.8))), ((V)(0D)), ((V)(1D))))), 2D))));
}, 1, "", true);
xw_3394 = Fn((V _self3377, int _argc3446, V y_3452, V _a3449, V _a3450, V _a3451, V[] _rest3447) => {
return ((V)(Pow((1D - ToNum(Call(clamp_12, V.Undef, ((V)(((ToNum(y_3452) - ToNum(Y0_3391)) / 44D))), ((V)(0D)), ((V)(1D))))), 2D)));
}, 1, "", true);
dep_3395 = Fn((V _self3377, int _argc3453, V y_3459, V _a3456, V _a3457, V _a3458, V[] _rest3454) => {
return ((V)((LeN(y_3459, 59D) ? (0.8 + (3D * Pow((1D - ToNum(Call(clamp_12, V.Undef, ((V)(((ToNum(y_3459) - ToNum(Y0_3391)) / 30.8))), ((V)(0D)), ((V)(1D))))), 0.8))) : (LeN(y_3459, 81D) ? (0.8 + (0.55 * FdLibm.Sin(((((ToNum(y_3459) - 59D) / 22D) * System.Math.PI) / 2D)))) : (0.4 + (0.95 * FdLibm.Cos(((ToNum(Call(clamp_12, V.Undef, ((V)(((ToNum(y_3459) - 81D) / 9D))), ((V)(0D)), ((V)(1D)))) * System.Math.PI) / 2D))))))));
}, 1, "", true);
PG_3396 = Invoke(S_3384, "g");
LN_3397 = Invoke(S_3384, "g");
knob_3398 = Invoke(S_3384, "path", NewObj(1).Put("fill", KF_3390).V);
KG_3399 = Invoke(S_3384, "g");
KL_3400 = Invoke(S_3384, "g");
pep_3401 = Invoke(S_3384, "path", NewObj(1).Put("fill", ((V)("#3e3028"))).V);
cone_3402 = Call(longSet_32, V.Undef, S_3384, NewObj(13).Put("N", ((V)(18D))).Put("ph", ((V)(((-ToNum(TAU_9)) / 36D)))).Put("rT", rT_3387).Put("y0", Y0_3391).Put("y1", Y1_3392).Put("NY", ((V)(24D))).Put("SY", Arr(((V)(28.2)), ((V)(36D)), ((V)(45D)), ((V)(56D)), ((V)(68D)), ((V)(79D)), ((V)(89.6)))).Put("tw", tw_3393).Put("dep", dep_3395).Put("cols", Arr(((V)("#b08c56")), ((V)("#ead6ac")), ((V)("#fdf3dc")))).Put("lc", ((V)("#a68552"))).Put("lw", ((V)(0.6))).Put("LS", Arr(Arr(((V)(0D)), ((V)(0.8))), Arr(((V)(0.45)), ((V)(0.55))), Arr(((V)(0.8)), ((V)(0.34))), Arr(((V)(1D)), ((V)(0.2))))).V, PG_3396, LN_3397);
kp_3403 = Call(pleatSet_29, V.Undef, NewObj(11).Put("N", ((V)(7D))).Put("rT", KN_3388).Put("y0", ((V)(18.2))).Put("yG", ((V)(28.8))).Put("yR", ((V)(28.8))).Put("ph", ((V)(0.3))).Put("tw", Fn((V _self3377, int _argc3460, V u_3466, V _a3463, V _a3464, V _a3465, V[] _rest3461) => {
return ((V)((1.25 * (1D - ToNum(u_3466)))));
}, 1, "tw", true)).Put("dep", Fn((V _self3377, int _argc3467, V _a3469, V _a3470, V _a3471, V _a3472, V[] _rest3468) => {
return ((V)(1D));
}, 0, "dep", true)).Put("cols", Arr(((V)("#a8844e")), ((V)("#e2c896")), ((V)("#fff6e2")))).Put("lc", ((V)("#9c7a48"))).Put("lw", ((V)(0.55))).V, KG_3399, KL_3400);
PE_3404 = Invoke(Array_from(NewObj(1).Put("length", ((V)(26D))).V, Fn((V _self3377, int _argc3492, V __3498, V i_3499, V _a3496, V _a3497, V[] _rest3493) => {
return Arr(((V)((ToNum(Call(rnd_22, V.Undef, ((V)((ToNum(i_3499) * 4.1))))) * ToNum(TAU_9)))), ((V)((31D + (ToNum(Call(rnd_22, V.Undef, ((V)((ToNum(i_3499) * 2.3))))) * 22D)))));
}, 2, "", true)), "concat", Invoke(Invoke(Array_from(NewObj(1).Put("length", ((V)(30D))).V, Fn((V _self3377, int _argc3484, V __3490, V i_3491, V _a3488, V _a3489, V[] _rest3485) => {
return Arr(((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_3491) * 3.7) + 9D))))) * ToNum(TAU_9)))), ((V)((58D + (ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_3491) * 1.9) + 4D))))) * 29D)))));
}, 2, "", true)), "filter", Fn((V _self3377, int _argc3473, V _a3475, V _a3476, V _a3477, V _a3478, V[] _rest3474) => {
V f_3481 = default;
V y_3483 = default;
{ V _t3479 = ListOf(_a3475);
{ V _t3480 = GetIdx(_t3479, 0D);
f_3481 = _t3480; }
{ V _t3482 = GetIdx(_t3479, 1D);
y_3483 = _t3482; }
}
return (!((LtN(y_3483, 84D) && (System.Math.Abs(FdLibm.Atan2(FdLibm.Sin(ToNum(f_3481)), FdLibm.Cos(ToNum(f_3481)))) < 0.75))) ? V.True : V.False);
}, 1, "", true)), "slice", ((V)(0D)), ((V)(14D))));
LC_3405 = ((V)(0D));
limb_3406 = Fn((V _self3377, int _argc3500, V q_3506, V kind_3507, V c_3508, V ax_3509, V[] _rest3501) => {
V ar_3513 = default;
V N_3514 = default;
V H_3515 = default;
V ph_3516 = default;
V th0_3517 = default;
V th1_3518 = default;
V NS_3519 = default;
V BE_3520 = default;
V S3_3521 = default;
V P2_3522 = default;
V NV_3523 = default;
V BR_3524 = default;
V TH_3525 = default;
V dL_3526 = default;
V dD_3527 = default;
V dG_3528 = default;
V E_3510 = default;
V R_3511 = default;
V glob_3512 = default;
E_3510 = (_argc3500 > 4 ? _rest3501[0] : V.Undef);
R_3511 = (_argc3500 > 5 ? _rest3501[1] : V.Undef);
glob_3512 = (_argc3500 > 6 ? _rest3501[2] : V.Undef);
ar_3513 = (SEqS(kind_3507, "arm") ? V.True : V.False);
if (!(Truthy(Get(q_3506, "dec")))) {
V u_3529 = default;
V gr_3530 = default;
V fd_3531 = default;
u_3529 = ((V)(string.Concat("kl", NumStr(PostInc(ref LC_3405, 1D)), ToStr(Get(S_3384, "u")))));
gr_3530 = Fn((V _self3377, int _argc3532, V n_3538, V col_3539, V st_3540, V _a3537, V[] _rest3533) => {
V g_3541 = default;
g_3541 = Call(el_14, V.Undef, ((V)("linearGradient")), NewObj(6).Put("id", Add(n_3538, u_3529)).Put("gradientUnits", ((V)("userSpaceOnUse"))).Put("x1", ((V)(0D))).Put("y1", ((V)(0D))).Put("x2", ((V)(0D))).Put("y2", ((V)(1D))).V, Get(S_3384, "df"));
Invoke(st_3540, "forEach", Fn((V _self3377, int _argc3542, V _a3544, V _a3545, V _a3546, V _a3547, V[] _rest3543) => {
V o_3550 = default;
V op_3552 = default;
{ V _t3548 = ListOf(_a3544);
{ V _t3549 = GetIdx(_t3548, 0D);
o_3550 = _t3549; }
{ V _t3551 = GetIdx(_t3548, 1D);
op_3552 = _t3551; }
}
return Call(el_14, V.Undef, ((V)("stop")), NewObj(3).Put("offset", o_3550).Put("stop-color", col_3539).Put("stop-opacity", op_3552).V, g_3541);
}, 1, "", true));
return g_3541;
return default;
}, 3, "", true);
fd_3531 = (Truthy(ar_3513) ? Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(0.45)), ((V)(0.85))), Arr(((V)(0.92)), ((V)(0D)))) : Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))));
Set(q_3506, "dGr", Arr(Call(gr_3530, V.Undef, ((V)("d")), ((V)("#8a6436")), fd_3531), Call(gr_3530, V.Undef, ((V)("l")), ((V)("#fffaf0")), fd_3531), Call(gr_3530, V.Undef, ((V)("g")), ((V)("#a68552")), fd_3531)));
Set(q_3506, "dec", Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, Get(Get(q_3506, "e"), "parentNode"), Get(Get(q_3506, "e"), "nextSibling")));
Set(q_3506, "dD", Call(el_14, V.Undef, ((V)("path")), NewObj(2).Put("fill", ((V)(string.Concat("url(#d", ToStr(u_3529), ")")))).Put("opacity", ((V)(0.2))).V, Get(q_3506, "dec")));
Set(q_3506, "dL", Call(el_14, V.Undef, ((V)("path")), NewObj(2).Put("fill", ((V)(string.Concat("url(#l", ToStr(u_3529), ")")))).Put("opacity", ((V)(0.45))).V, Get(q_3506, "dec")));
Set(q_3506, "dG", Call(el_14, V.Undef, ((V)("path")), NewObj(6).Put("fill", ((V)("none"))).Put("stroke", ((V)(string.Concat("url(#g", ToStr(u_3529), ")")))).Put("stroke-width", ((V)(0.42))).Put("stroke-linecap", ((V)("round"))).Put("stroke-linejoin", ((V)("round"))).Put("opacity", ((V)(0.7))).V, Get(q_3506, "dec")));
}
N_3514 = ((V)((Truthy(ar_3513) ? 8D : 10D)));
H_3515 = ((V)((System.Math.PI / ToNum(N_3514))));
ph_3516 = (Truthy(ar_3513) ? ((V)(0D)) : H_3515);
th0_3517 = ((V)((Truthy(ar_3513) ? 0.04 : 0.14)));
th1_3518 = ((V)((Truthy(ar_3513) ? 0.84 : 0.9)));
NS_3519 = ((V)(8D));
BE_3520 = ((V)(0.38));
{
V r0_3553 = default;
V t0_3554 = default;
r0_3553 = Call(glob_3512, V.Undef, ((V)((ToNum(GetIdx(c_3508, 0D)) - ToNum(GetIdx(GetIdx(ax_3509, 1D), 0D))))), ((V)((ToNum(GetIdx(c_3508, 1D)) - ToNum(GetIdx(GetIdx(ax_3509, 1D), 1D))))));
t0_3554 = Call(glob_3512, V.Undef, Add(GetIdx(c_3508, 0D), GetIdx(GetIdx(ax_3509, 1D), 0D)), Add(GetIdx(c_3508, 1D), GetIdx(GetIdx(ax_3509, 1D), 1D)));
Invoke(Get(q_3506, "dGr"), "forEach", Fn((V _self3377, int _argc3555, V g_3561, V _a3558, V _a3559, V _a3560, V[] _rest3556) => {
Call(SA_31, V.Undef, g_3561, ((V)("x1")), Call(r2_11, V.Undef, GetIdx(r0_3553, 0D)));
Call(SA_31, V.Undef, g_3561, ((V)("y1")), Call(r2_11, V.Undef, GetIdx(r0_3553, 1D)));
Call(SA_31, V.Undef, g_3561, ((V)("x2")), Call(r2_11, V.Undef, GetIdx(t0_3554, 0D)));
Call(SA_31, V.Undef, g_3561, ((V)("y2")), Call(r2_11, V.Undef, GetIdx(t0_3554, 1D)));
return default;
}, 1, "", true));
}
S3_3521 = Fn((V _self3377, int _argc3562, V th_3568, V f_3569, V _a3566, V _a3567, V[] _rest3563) => {
return Arr(((V)((FdLibm.Sin(ToNum(th_3568)) * FdLibm.Sin(ToNum(f_3569))))), ((V)((-FdLibm.Cos(ToNum(th_3568))))), ((V)((FdLibm.Sin(ToNum(th_3568)) * FdLibm.Cos(ToNum(f_3569))))));
}, 2, "", true);
P2_3522 = Fn((V _self3377, int _argc3570, V s_3576, V _a3573, V _a3574, V _a3575, V[] _rest3571) => {
return Call(glob_3512, V.Undef, Add(Add(Add(GetIdx(c_3508, 0D), ((V)((ToNum(GetIdx(s_3576, 0D)) * ToNum(GetIdx(GetIdx(ax_3509, 0D), 0D)))))), ((V)((ToNum(GetIdx(s_3576, 1D)) * ToNum(GetIdx(GetIdx(ax_3509, 1D), 0D)))))), ((V)((ToNum(GetIdx(s_3576, 2D)) * ToNum(GetIdx(GetIdx(ax_3509, 2D), 0D)))))), Add(Add(Add(GetIdx(c_3508, 1D), ((V)((ToNum(GetIdx(s_3576, 0D)) * ToNum(GetIdx(GetIdx(ax_3509, 0D), 1D)))))), ((V)((ToNum(GetIdx(s_3576, 1D)) * ToNum(GetIdx(GetIdx(ax_3509, 1D), 1D)))))), ((V)((ToNum(GetIdx(s_3576, 2D)) * ToNum(GetIdx(GetIdx(ax_3509, 2D), 1D)))))));
}, 1, "", true);
NV_3523 = Fn((V _self3377, int _argc3577, V s_3583, V _a3580, V _a3581, V _a3582, V[] _rest3578) => {
V n_3584 = default;
V l_3585 = default;
n_3584 = Arr(((V)(0D)), ((V)(0D)), ((V)(0D)));
{
V i_3586 = default;
i_3586 = ((V)(0D));
while (true) {
if (!(LtN(i_3586, 3D))) break;
V k_3588 = default;
k_3588 = ((V)((ToNum(GetK(s_3583, i_3586)) / ToNum(GetK(R_3511, i_3586)))));
{
V j_3589 = default;
j_3589 = ((V)(0D));
while (true) {
if (!(LtN(j_3589, 3D))) break;
OpSetK(n_3584, j_3589, 0, ((V)((ToNum(k_3588) * ToNum(GetK(GetK(E_3510, i_3586), j_3589))))));
PostInc(ref j_3589, 1D);
}
}
PostInc(ref i_3586, 1D);
}
}
l_3585 = (((V)(Hypot(ToNum(GetIdx(n_3584, 0D)), ToNum(GetIdx(n_3584, 1D)), ToNum(GetIdx(n_3584, 2D))))) is var _t3591 && Truthy(_t3591) ? _t3591 : ((V)(1D)));
return Arr(((V)((ToNum(GetIdx(n_3584, 0D)) / ToNum(l_3585)))), ((V)((ToNum(GetIdx(n_3584, 1D)) / ToNum(l_3585)))), ((V)((ToNum(GetIdx(n_3584, 2D)) / ToNum(l_3585)))));
return default;
}, 1, "", true);
BR_3524 = Fn((V _self3377, int _argc3592, V n_3598, V _a3595, V _a3596, V _a3597, V[] _rest3593) => {
return ((V)((((ToNum(GetIdx(n_3598, 0D)) * ToNum(GetIdx(LV_27, 0D))) + (ToNum(GetIdx(n_3598, 1D)) * ToNum(GetIdx(LV_27, 1D)))) + (ToNum(GetIdx(n_3598, 2D)) * ToNum(GetIdx(LV_27, 2D))))));
}, 1, "", true);
TH_3525 = Array_from(NewObj(1).Put("length", Add(NS_3519, ((V)(1D)))).V, Fn((V _self3377, int _argc3599, V __3605, V i_3606, V _a3603, V _a3604, V[] _rest3600) => {
return ((V)((System.Math.PI * ToNum(Add(th0_3517, ((V)((((ToNum(th1_3518) - ToNum(th0_3517)) * ToNum(i_3606)) / ToNum(NS_3519)))))))));
}, 2, "", true));
dL_3526 = ((V)(""));
dD_3527 = ((V)(""));
dG_3528 = ((V)(""));
{
V k_3607 = default;
k_3607 = ((V)(0D));
while (true) {
if (!(Lt(k_3607, N_3514))) break;
V fg_3609 = default;
V G3_3610 = default;
fg_3609 = Add(ph_3516, ((V)(((ToNum(k_3607) * 2D) * ToNum(H_3515)))));
G3_3610 = Invoke(TH_3525, "map", Fn((V _self3377, int _argc3611, V th_3617, V _a3614, V _a3615, V _a3616, V[] _rest3612) => {
return Call(S3_3521, V.Undef, th_3617, fg_3609);
}, 1, "", true));
dG_3528 = Add(dG_3528, Call(runs_21, V.Undef, Invoke(G3_3610, "map", P2_3522), Invoke(G3_3610, "map", Fn((V _self3377, int _argc3618, V s_3624, V _a3621, V _a3622, V _a3623, V[] _rest3619) => {
return (GtN(GetIdx(Call(NV_3523, V.Undef, s_3624), 2D), 0.03) ? V.True : V.False);
}, 1, "", true))));
{
V side_3625 = default;
side_3625 = ((V)(0D));
while (true) {
if (!(LtN(side_3625, 2D))) break;
V fa_3627 = default;
V fb_3628 = default;
V fm_3629 = default;
V nm_3630 = default;
V d_3631 = default;
V pd_3632 = default;
fa_3627 = Add(fg_3609, ((V)((ToNum(side_3625) * ToNum(H_3515)))));
fb_3628 = Add(fa_3627, H_3515);
fm_3629 = Add(fa_3627, ((V)((ToNum(H_3515) / 2D))));
nm_3630 = Call(NV_3523, V.Undef, Call(S3_3521, V.Undef, ((V)((System.Math.PI / 2D))), fm_3629));
if (LtN(GetIdx(nm_3630, 2D), 0.05)) {
goto _cont3626;
}
d_3631 = ((V)((ToNum(Call(BR_3524, V.Undef, Call(NV_3523, V.Undef, Call(S3_3521, V.Undef, ((V)((System.Math.PI / 2D))), Add(fm_3629, (Truthy(side_3625) ? BE_3520 : ((V)((-ToNum(BE_3520)))))))))) - ToNum(Call(BR_3524, V.Undef, nm_3630)))));
if ((System.Math.Abs(ToNum(d_3631)) < 0.03)) {
goto _cont3626;
}
pd_3632 = ((V)(string.Concat("M", ToStr(Invoke(Invoke(Invoke(Invoke(TH_3525, "map", Fn((V _self3377, int _argc3640, V th_3646, V _a3643, V _a3644, V _a3645, V[] _rest3641) => {
return Call(P2_3522, V.Undef, Call(S3_3521, V.Undef, th_3646, fa_3627));
}, 1, "", true)), "concat", Invoke(Invoke(Invoke(TH_3525, "slice"), "reverse"), "map", Fn((V _self3377, int _argc3633, V th_3639, V _a3636, V _a3637, V _a3638, V[] _rest3634) => {
return Call(P2_3522, V.Undef, Call(S3_3521, V.Undef, th_3639, fb_3628));
}, 1, "", true))), "map", pt_15), "join", ((V)("L")))), "Z")));
if (GtN(d_3631, 0D)) {
dL_3526 = Add(dL_3526, pd_3632);
} else {
dD_3527 = Add(dD_3527, pd_3632);
}
_cont3626: ;
PostInc(ref side_3625, 1D);
}
}
PostInc(ref k_3607, 1D);
}
}
Call(SA_31, V.Undef, Get(q_3506, "dL"), ((V)("d")), (dL_3526 is var _t3647 && Truthy(_t3647) ? _t3647 : ((V)("M0 0"))));
Call(SA_31, V.Undef, Get(q_3506, "dD"), ((V)("d")), (dD_3527 is var _t3648 && Truthy(_t3648) ? _t3648 : ((V)("M0 0"))));
Call(SA_31, V.Undef, Get(q_3506, "dG"), ((V)("d")), (dG_3528 is var _t3649 && Truthy(_t3649) ? _t3649 : ((V)("M0 0"))));
return default;
}, 7, "", true);
return NewObj(16).Put("O", O_3386).Put("rT", rT_3387).Put("KN", KN_3388).Put("tw", tw_3393).Put("xw", xw_3394).Put("dep", dep_3395).Put("knob", knob_3398).Put("cone", cone_3402).Put("kp", kp_3403).Put("pep", pep_3401).Put("PE", PE_3404).Put("limb", limb_3406).Put("rx", ((V)(37D))).Put("ya", ((V)(44D))).Put("yb", ((V)(88D))).Put("zE", Fn((V _self3377, int _argc3650, V dx_3656, V dy_3657, V _a3654, V _a3655, V[] _rest3651) => {
V r_3658 = default;
r_3658 = Call(rT_3387, V.Undef, Add(Get(S_3384, "HY"), dy_3657));
return ((V)((System.Math.Sqrt(Max(0D, ((ToNum(r_3658) * ToNum(r_3658)) - (ToNum(dx_3656) * ToNum(dx_3656))))) + 0.3)));
return default;
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self3659, int _argc3660, V B_3666, V D_3667, V _a3664, V _a3665, V[] _rest3661) => {
V P3_3668 = default;
V Z3_3669 = default;
V set_3670 = default;
V rT_3671 = default;
V kt_3672 = default;
V kq_3673 = default;
V hp_3674 = default;
V TW_3675 = default;
V sw_3676 = default;
V KP_3677 = default;
V KZ_3678 = default;
V kh_3679 = default;
if (_self3659.IsNullish) _self3659 = GlobalV;
{ V _t3680 = D_3667;
if (_t3680.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t3680));
{ V _t3681 = Get(_t3680, "P3");
P3_3668 = _t3681; }
{ V _t3682 = Get(_t3680, "Z3");
Z3_3669 = _t3682; }
{ V _t3683 = Get(_t3680, "set");
set_3670 = _t3683; } }
rT_3671 = Get(B_3666, "rT");
kt_3672 = Call(clamp_12, V.Undef, Invoke(D_3667, "bv", ((V)("kt"))), ((V)((-1.2))), ((V)(1.2)));
kq_3673 = Call(clamp_12, V.Undef, Invoke(D_3667, "bv", ((V)("knot"))), ((V)((-1.2))), ((V)(1.2)));
hp_3674 = Arr();
{
V i_3684 = default;
i_3684 = ((V)(0D));
while (true) {
if (!(LeN(i_3684, 20D))) break;
V y_3686 = default;
V r_3687 = default;
y_3686 = ((V)((27.6 + ((62.6 * ToNum(i_3684)) / 20D))));
r_3687 = Call(rT_3671, V.Undef, y_3686);
{
V k_3688 = default;
k_3688 = ((V)(0D));
while (true) {
if (!(LtN(k_3688, 24D))) break;
V f_3690 = default;
f_3690 = ((V)(((ToNum(k_3688) / 24D) * ToNum(TAU_9))));
Invoke(hp_3674, "push", Call(P3_3668, V.Undef, ((V)((50D + (ToNum(r_3687) * FdLibm.Sin(ToNum(f_3690)))))), y_3686, ((V)((ToNum(r_3687) * FdLibm.Cos(ToNum(f_3690)))))));
PostInc(ref k_3688, 1D);
}
}
PostInc(ref i_3684, 1D);
}
}
Set(B_3666, "d", Invoke(D_3667, "hull", hp_3674));
TW_3675 = Fn((V _self3659, int _argc3691, V y_3697, V _a3694, V _a3695, V _a3696, V[] _rest3692) => {
return Add(Invoke(B_3666, "tw", y_3697), ((V)(((ToNum(kt_3672) * 0.6) * ToNum(Invoke(B_3666, "xw", y_3697))))));
}, 1, "", true);
Call(longDraw_33, V.Undef, D_3667, Get(B_3666, "cone"), P3_3668, Z3_3669, TW_3675);
Call(set_3670, V.Undef, Get(B_3666, "pep"), ((V)("d")), (Invoke(Invoke(Invoke(Get(B_3666, "PE"), "filter", Fn((V _self3659, int _argc3711, V _a3713, V _a3714, V _a3715, V _a3716, V[] _rest3712) => {
V ff_3722 = default;
V f_3719 = default;
V y_3721 = default;
{ V _t3717 = ListOf(_a3713);
{ V _t3718 = GetIdx(_t3717, 0D);
f_3719 = _t3718; }
{ V _t3720 = GetIdx(_t3717, 1D);
y_3721 = _t3720; }
}
ff_3722 = Add(f_3719, Call(TW_3675, V.Undef, y_3721));
return (GtN(Invoke(D_3667, "facing", ((V)((50D + (ToNum(Call(rT_3671, V.Undef, y_3721)) * FdLibm.Sin(ToNum(ff_3722)))))), y_3721, ((V)((ToNum(Call(rT_3671, V.Undef, y_3721)) * FdLibm.Cos(ToNum(ff_3722))))), ((V)(FdLibm.Sin(ToNum(ff_3722)))), ((V)(0D)), ((V)(FdLibm.Cos(ToNum(ff_3722))))), 0.08) ? V.True : V.False);
return default;
}, 1, "", true)), "map", Fn((V _self3659, int _argc3698, V _a3700, V _a3701, V _a3702, V _a3703, V[] _rest3699) => {
V ff_3709 = default;
V r_3710 = default;
V f_3706 = default;
V y_3708 = default;
{ V _t3704 = ListOf(_a3700);
{ V _t3705 = GetIdx(_t3704, 0D);
f_3706 = _t3705; }
{ V _t3707 = GetIdx(_t3704, 1D);
y_3708 = _t3707; }
}
ff_3709 = Add(f_3706, Call(TW_3675, V.Undef, y_3708));
r_3710 = Add(Call(rT_3671, V.Undef, y_3708), ((V)((ToNum(Invoke(B_3666, "dep", y_3708)) * 0.55))));
return Call(circD_19, V.Undef, Call(P3_3668, V.Undef, ((V)((50D + (ToNum(r_3710) * FdLibm.Sin(ToNum(ff_3709)))))), y_3708, ((V)((ToNum(r_3710) * FdLibm.Cos(ToNum(ff_3709)))))), ((V)((0.5 * ToNum(Get(D_3667, "kS"))))));
return default;
}, 1, "", true)), "join", ((V)(""))) is var _t3723 && Truthy(_t3723) ? _t3723 : ((V)("M0 0"))));
sw_3676 = ((V)((((FdLibm.Sin((ToNum(Get(D_3667, "ts")) * 1.6)) * 0.5) + (ToNum(Get(D_3667, "ox")) * 0.25)) + (ToNum(kq_3673) * 3.5))));
KP_3677 = Fn((V _self3659, int _argc3724, V x_3730, V y_3731, V z_3732, V _a3729, V[] _rest3725) => {
V u_3733 = default;
u_3733 = Call(clamp_12, V.Undef, ((V)(((28.8 - ToNum(y_3731)) / 12D))), ((V)(0D)), ((V)(1D)));
return Call(P3_3668, V.Undef, Add(x_3730, ((V)(((ToNum(sw_3676) * ToNum(u_3733)) * ToNum(u_3733))))), ((V)((ToNum(y_3731) - ((ToNum(Get(D_3667, "oy")) * 0.25) * ToNum(u_3733))))), z_3732);
return default;
}, 3, "", true);
KZ_3678 = Fn((V _self3659, int _argc3734, V x_3740, V y_3741, V z_3742, V _a3739, V[] _rest3735) => {
return Call(Z3_3669, V.Undef, x_3740, y_3741, z_3742);
}, 3, "", true);
kh_3679 = Arr();
{
V i_3743 = default;
i_3743 = ((V)(0D));
while (true) {
if (!(LeN(i_3743, 12D))) break;
V y_3745 = default;
V r_3746 = default;
y_3745 = ((V)((28.8 - (((28.8 - 16.95) * ToNum(i_3743)) / 12D))));
r_3746 = Invoke(B_3666, "KN", y_3745);
{
V k_3747 = default;
k_3747 = ((V)(0D));
while (true) {
if (!(LtN(k_3747, 16D))) break;
V f_3749 = default;
f_3749 = ((V)(((ToNum(k_3747) / 16D) * ToNum(TAU_9))));
Invoke(kh_3679, "push", Call(KP_3677, V.Undef, ((V)((50D + (ToNum(r_3746) * FdLibm.Sin(ToNum(f_3749)))))), y_3745, ((V)((ToNum(r_3746) * FdLibm.Cos(ToNum(f_3749)))))));
PostInc(ref k_3747, 1D);
}
}
PostInc(ref i_3743, 1D);
}
}
Call(set_3670, V.Undef, Get(B_3666, "knob"), ((V)("d")), Invoke(D_3667, "hull", kh_3679));
Call(pleatDraw_30, V.Undef, D_3667, Get(B_3666, "kp"), KP_3677, KZ_3678, ((V)(((ToNum(kt_3672) * 0.4) + (ToNum(kq_3673) * 0.5)))));
return default;
}, 2, "draw", false)).V);
Set(MODELS_42, "maki", NewObj(2).Put("setup", Fn((V _self3750, int _argc3751, V S_3757, V _a3754, V _a3755, V _a3756, V[] _rest3752) => {
V R0_3758 = default;
V YT_3759 = default;
V AL_3760 = default;
V KF_3761 = default;
V rT_3762 = default;
V ang_3763 = default;
V face_3764 = default;
V SG_3765 = default;
V TG_3766 = default;
V SS_3767 = default;
V TS_3768 = default;
V NR_3769 = default;
V C_3770 = default;
V SCc_3771 = default;
V SM_3772 = default;
V ringXZ_3773 = default;
V clip_3774 = default;
V bed_3775 = default;
V fr_3776 = default;
V shr_3777 = default;
V PC_3778 = default;
V GSH_3779 = default;
V GT_3780 = default;
V ses_3781 = default;
V top_3782 = default;
V tgr_3783 = default;
V tse_3784 = default;
V nori_3785 = default;
V bedE_3786 = default;
V VG_3787 = default;
V scl_3788 = default;
V LGR_3789 = default;
V limb_3790 = default;
if (_self3750.IsNullish) _self3750 = GlobalV;
R0_3758 = ((V)(29D));
YT_3759 = ((V)(38.6));
AL_3760 = ((V)(FdLibm.Asin(0.44)));
KF_3761 = ((V)((21.5 / 17.8)));
rT_3762 = Fn((V _self3750, int _argc3791, V y_3797, V _a3794, V _a3795, V _a3796, V[] _rest3792) => {
return (GtN(y_3797, 82D) ? ((V)((ToNum(Add(((V)(System.Math.Sqrt(Max(0D, (36D - ((ToNum(y_3797) - 82D) * (ToNum(y_3797) - 82D))))))), R0_3758)) - 6D))) : R0_3758);
}, 1, "", true);
Invoke(S_3757, "hide", Fn((V _self3750, int _argc3798, V q_3804, V _a3801, V _a3802, V _a3803, V[] _rest3799) => {
return (Get(q_3804, "inBody") is var _t3805 && !Truthy(_t3805) ? _t3805 : Invoke(S_3757, "dk", q_3804));
}, 1, "", true));
ang_3763 = Fn((V _self3750, int _argc3806, V f_3812, V _a3809, V _a3810, V _a3811, V[] _rest3807) => {
return ((V)(FdLibm.Atan2(FdLibm.Sin(ToNum(f_3812)), FdLibm.Cos(ToNum(f_3812)))));
}, 1, "", true);
face_3764 = Fn((V _self3750, int _argc3813, V f_3819, V y_3820, V _a3817, V _a3818, V[] _rest3814) => {
return ((((System.Math.Abs(ToNum(Call(ang_3763, V.Undef, f_3819))) < 0.6) && GtN(y_3820, 52D)) && LtN(y_3820, 75D)) ? V.True : V.False);
}, 2, "", true);
SG_3765 = Invoke(Array_from(NewObj(1).Put("length", ((V)(300D))).V, Fn((V _self3750, int _argc3828, V __3834, V i_3835, V _a3832, V _a3833, V[] _rest3829) => {
return Arr(((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_3835) * 2.31) + 1D))))) * ToNum(TAU_9)))), Add(Add(YT_3759, ((V)(2D))), ((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_3835) * 1.73) + 2D))))) * (84D - ToNum(YT_3759)))))), ((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_3835) * 3.1) + 5D))))) * System.Math.PI))));
}, 2, "", true)), "filter", Fn((V _self3750, int _argc3821, V g_3827, V _a3824, V _a3825, V _a3826, V[] _rest3822) => {
return (!(Truthy(Call(face_3764, V.Undef, GetIdx(g_3827, 0D), GetIdx(g_3827, 1D)))) ? V.True : V.False);
}, 1, "", true));
TG_3766 = Array_from(NewObj(1).Put("length", ((V)(52D))).V, Fn((V _self3750, int _argc3836, V __3842, V i_3843, V _a3840, V _a3841, V[] _rest3837) => {
return Arr(((V)((24.3 + (ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_3843) * 1.37) + 7D))))) * 4.2)))), ((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_3843) * 2.9) + 3D))))) * ToNum(TAU_9)))), ((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_3843) * 4.3) + 1D))))) * System.Math.PI))));
}, 2, "", true));
SS_3767 = Invoke(Array_from(NewObj(1).Put("length", ((V)(34D))).V, Fn((V _self3750, int _argc3851, V __3857, V i_3858, V _a3855, V _a3856, V[] _rest3852) => {
return Arr(((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_3858) * 5.1) + 11D))))) * ToNum(TAU_9)))), Add(Add(YT_3759, ((V)(4D))), ((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_3858) * 2.2) + 9D))))) * (80D - ToNum(YT_3759)))))), ((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_3858) * 1.9) + 4D))))) * System.Math.PI))));
}, 2, "", true)), "filter", Fn((V _self3750, int _argc3844, V g_3850, V _a3847, V _a3848, V _a3849, V[] _rest3845) => {
return (!(Truthy(Call(face_3764, V.Undef, GetIdx(g_3850, 0D), GetIdx(g_3850, 1D)))) ? V.True : V.False);
}, 1, "", true));
TS_3768 = Array_from(NewObj(1).Put("length", ((V)(10D))).V, Fn((V _self3750, int _argc3859, V __3865, V i_3866, V _a3863, V _a3864, V[] _rest3860) => {
return Arr(((V)((24.5 + (ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_3866) * 3.3) + 2D))))) * 3.8)))), ((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_3866) * 1.1) + 8D))))) * ToNum(TAU_9)))), ((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_3866) * 2.7) + 6D))))) * System.Math.PI))));
}, 2, "", true));
NR_3769 = Fn((V _self3750, int _argc3867, V f_3873, V _a3870, V _a3871, V _a3872, V[] _rest3868) => {
return ((V)((ToNum(KF_3761) * ((17.8 + (0.8 * FdLibm.Sin(((3D * ToNum(f_3873)) + 1.1)))) + (0.45 * FdLibm.Sin(((5D * ToNum(f_3873)) + 0.3)))))));
}, 1, "", true);
C_3770 = Arr(((V)(50.5)), ((V)((-1.2))));
SCc_3771 = Fn((V _self3750, int _argc3874, V a_3880, V b_3881, V c_3882, V _a3879, V[] _rest3875) => {
return ((V)((((ToNum(KF_3761) * ((ToNum(c_3882) - (ToNum(a_3880) * ToNum(GetIdx(C_3770, 0D)))) - (ToNum(b_3881) * ToNum(GetIdx(C_3770, 1D))))) + (ToNum(a_3880) * ToNum(GetIdx(C_3770, 0D)))) + (ToNum(b_3881) * ToNum(GetIdx(C_3770, 1D))))));
}, 3, "", true);
SM_3772 = Fn((V _self3750, int _argc3883, V x_3889, V z_3890, V _a3887, V _a3888, V[] _rest3884) => {
return Arr(Add(GetIdx(C_3770, 0D), ((V)(((ToNum(x_3889) - ToNum(GetIdx(C_3770, 0D))) * ToNum(KF_3761))))), Add(GetIdx(C_3770, 1D), ((V)(((ToNum(z_3890) - ToNum(GetIdx(C_3770, 1D))) * ToNum(KF_3761))))));
}, 2, "", true);
ringXZ_3773 = Fn((V _self3750, int _argc3891, V rf_3897, V n_3898, V _a3895, V _a3896, V[] _rest3892) => {
return Array_from(NewObj(1).Put("length", n_3898).V, Fn((V _self3750, int _argc3899, V __3905, V k_3906, V _a3903, V _a3904, V[] _rest3900) => {
V f_3907 = default;
f_3907 = ((V)(((ToNum(k_3906) / ToNum(n_3898)) * ToNum(TAU_9))));
return Arr(Add(GetIdx(C_3770, 0D), ((V)((ToNum(Call(rf_3897, V.Undef, f_3907)) * FdLibm.Sin(ToNum(f_3907)))))), Add(GetIdx(C_3770, 1D), ((V)((ToNum(Call(rf_3897, V.Undef, f_3907)) * FdLibm.Cos(ToNum(f_3907)))))));
return default;
}, 2, "", true));
}, 2, "", true);
clip_3774 = Fn((V _self3750, int _argc3908, V Q_3914, V a_3915, V b_3916, V c_3917, V[] _rest3909) => {
V o_3918 = default;
o_3918 = Arr();
{
V i_3919 = default;
i_3919 = ((V)(0D));
while (true) {
if (!(Lt(i_3919, Get(Q_3914, "length")))) break;
V p_3921 = default;
V q_3922 = default;
V s1_3923 = default;
V s2_3924 = default;
p_3921 = GetK(Q_3914, i_3919);
q_3922 = GetIdx(Q_3914, (ToNum(Add(i_3919, ((V)(1D)))) % ToNum(Get(Q_3914, "length"))));
s1_3923 = ((V)((((ToNum(a_3915) * ToNum(GetIdx(p_3921, 0D))) + (ToNum(b_3916) * ToNum(GetIdx(p_3921, 1D)))) - ToNum(c_3917))));
s2_3924 = ((V)((((ToNum(a_3915) * ToNum(GetIdx(q_3922, 0D))) + (ToNum(b_3916) * ToNum(GetIdx(q_3922, 1D)))) - ToNum(c_3917))));
if (LeN(s1_3923, 0D)) {
Invoke(o_3918, "push", p_3921);
}
if (((ToNum(s1_3923) * ToNum(s2_3924)) < 0D)) {
V t_3925 = default;
t_3925 = ((V)((ToNum(s1_3923) / (ToNum(s1_3923) - ToNum(s2_3924)))));
Invoke(o_3918, "push", Arr(Add(GetIdx(p_3921, 0D), ((V)(((ToNum(GetIdx(q_3922, 0D)) - ToNum(GetIdx(p_3921, 0D))) * ToNum(t_3925))))), Add(GetIdx(p_3921, 1D), ((V)(((ToNum(GetIdx(q_3922, 1D)) - ToNum(GetIdx(p_3921, 1D))) * ToNum(t_3925)))))));
}
PostInc(ref i_3919, 1D);
}
}
return o_3918;
return default;
}, 4, "", true);
bed_3775 = Call(ringXZ_3773, V.Undef, Fn((V _self3750, int _argc3926, V f_3932, V _a3929, V _a3930, V _a3931, V[] _rest3927) => {
return ((V)((ToNum(Call(NR_3769, V.Undef, f_3932)) - 0.7)));
}, 1, "", true), ((V)(64D)));
fr_3776 = Call(clip_3774, V.Undef, bed_3775, ((V)((-0.08))), ((V)((-1D))), Call(SCc_3771, V.Undef, ((V)((-0.08))), ((V)((-1D))), ((V)((-(3.8 + 4D))))));
shr_3777 = Fn((V _self3750, int _argc3933, V Q_3939, V k_3940, V _a3937, V _a3938, V[] _rest3934) => {
V cx_3941 = default;
V cz_3942 = default;
cx_3941 = ((V)((ToNum(Invoke(Q_3939, "reduce", Fn((V _self3750, int _argc3943, V s_3949, V p_3950, V _a3947, V _a3948, V[] _rest3944) => {
return Add(s_3949, GetIdx(p_3950, 0D));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(Q_3939, "length")))));
cz_3942 = ((V)((ToNum(Invoke(Q_3939, "reduce", Fn((V _self3750, int _argc3951, V s_3957, V p_3958, V _a3955, V _a3956, V[] _rest3952) => {
return Add(s_3957, GetIdx(p_3958, 1D));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(Q_3939, "length")))));
return Invoke(Q_3939, "map", Fn((V _self3750, int _argc3959, V p_3965, V _a3962, V _a3963, V _a3964, V[] _rest3960) => {
return Arr(Add(cx_3941, ((V)(((ToNum(GetIdx(p_3965, 0D)) - ToNum(cx_3941)) * ToNum(k_3940))))), Add(cz_3942, ((V)(((ToNum(GetIdx(p_3965, 1D)) - ToNum(cz_3942)) * ToNum(k_3940))))));
}, 1, "", true));
return default;
}, 2, "", true);
PC_3778 = Arr(NewObj(5).Put("n", ((V)("s"))).Put("Q", Call(clip_3774, V.Undef, bed_3775, ((V)(0.08)), ((V)(1D)), Call(SCc_3771, V.Undef, ((V)(0.08)), ((V)(1D)), ((V)((2.6 + 4D)))))).Put("h", ((V)(2.2))).Put("sd", ((V)("#d9542a"))).Put("top", Invoke(S_3757, "rgrad", ((V)("mks")), Arr(Arr(((V)(0D)), ((V)("#ffb894"))), Arr(((V)(0.6)), ((V)("#ff7c4a"))), Arr(((V)(1D)), ((V)("#e65a2c")))))).V, NewObj(8).Put("n", ((V)("a"))).Put("Q", Call(clip_3774, V.Undef, fr_3776, ((V)(1D)), ((V)((-0.3))), Call(SCc_3771, V.Undef, ((V)(1D)), ((V)((-0.3))), ((V)((54.8 - 2.7)))))).Put("h", ((V)(1.7))).Put("sd", ((V)("#5e8e30"))).Put("top", Invoke(S_3757, "rgrad", ((V)("mka")), Arr(Arr(((V)(0D)), ((V)("#f8f4ba"))), Arr(((V)(0.6)), ((V)("#e6e690"))), Arr(((V)(1D)), ((V)("#b4c862")))))).Put("in", ((V)("#eef0b0"))).Put("ik", ((V)(0.55))).Put("io", ((V)(0.8))).V, NewObj(8).Put("n", ((V)("k"))).Put("Q", Call(clip_3774, V.Undef, fr_3776, ((V)((-1D))), ((V)(0.3)), Call(SCc_3771, V.Undef, ((V)((-1D))), ((V)(0.3)), ((V)((-(56.2 - 2.7))))))).Put("h", ((V)(1.4))).Put("sd", ((V)("#2e6a22"))).Put("top", Invoke(S_3757, "rgrad", ((V)("mkk")), Arr(Arr(((V)(0D)), ((V)("#b6ea80"))), Arr(((V)(0.6)), ((V)("#86cc52"))), Arr(((V)(1D)), ((V)("#4f9a2e")))))).Put("in", ((V)("#e2f6c0"))).Put("ik", ((V)(0.5))).Put("io", ((V)(0.85))).V);
GSH_3779 = Invoke(S_3757, "path", NewObj(2).Put("fill", ((V)("#d6ccb7"))).Put("opacity", ((V)(0.75))).V);
GT_3780 = Arr(Invoke(S_3757, "path", NewObj(3).Put("fill", ((V)("#ffffff"))).Put("stroke", ((V)("#cfc5b0"))).Put("stroke-width", ((V)(0.26))).V), Invoke(S_3757, "path", NewObj(3).Put("fill", ((V)("#fbf9f4"))).Put("stroke", ((V)("#cfc5b0"))).Put("stroke-width", ((V)(0.26))).V), Invoke(S_3757, "path", NewObj(3).Put("fill", ((V)("#efeae0"))).Put("stroke", ((V)("#c4b9a2"))).Put("stroke-width", ((V)(0.26))).V));
ses_3781 = Invoke(S_3757, "path", NewObj(3).Put("fill", ((V)("#e6c682"))).Put("stroke", ((V)("#b48a42"))).Put("stroke-width", ((V)(0.24))).V);
top_3782 = Invoke(S_3757, "path", NewObj(1).Put("fill", Invoke(S_3757, "rgrad", ((V)("mkt")), Arr(Arr(((V)(0D)), ((V)("#fdfbf7"))), Arr(((V)(0.6)), ((V)("#f3efe6"))), Arr(((V)(1D)), ((V)("#ddd5c4")))), NewObj(3).Put("cx", ((V)("45%"))).Put("cy", ((V)("40%"))).Put("r", ((V)("65%"))).V)).V);
tgr_3783 = Invoke(S_3757, "path", NewObj(3).Put("fill", ((V)("#ffffff"))).Put("stroke", ((V)("#cfc5b0"))).Put("stroke-width", ((V)(0.26))).V);
tse_3784 = Invoke(S_3757, "path", NewObj(3).Put("fill", ((V)("#e6c682"))).Put("stroke", ((V)("#b48a42"))).Put("stroke-width", ((V)(0.22))).V);
nori_3785 = Invoke(S_3757, "path", NewObj(1).Put("fill", ((V)("#1f3326"))).V);
bedE_3786 = Invoke(S_3757, "path", NewObj(1).Put("fill", ((V)("#f1ece0"))).V);
VG_3787 = Invoke(S_3757, "g");
scl_3788 = Invoke(S_3757, "clip", ((V)("mksc")));
Invoke(PC_3778, "forEach", Fn((V _self3750, int _argc3966, V p_3972, V i_3973, V _a3970, V _a3971, V[] _rest3967) => {
Set(p_3972, "id", ((V)(string.Concat("v", ToStr(i_3973)))));
Set(p_3972, "sdE", Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", Get(p_3972, "sd")).V, VG_3787));
Set(p_3972, "e", Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", Get(p_3972, "top")).V, VG_3787));
Set(p_3972, "ex", (SEqS(Get(p_3972, "n"), "s") ? Call(Fn((V _self3750, int _argc3974, V _a3976, V _a3977, V _a3978, V _a3979, V[] _rest3975) => {
V g_3980 = default;
g_3980 = Call(el_14, V.Undef, ((V)("g")), NewObj(1).Put("clip-path", Get(scl_3788, "url")).V, VG_3787);
Call(el_14, V.Undef, ((V)("path")), NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffe6d6"))).Put("stroke-width", ((V)(2.1))).Put("stroke-linecap", ((V)("round"))).Put("opacity", ((V)(0.6))).V, g_3980);
return g_3980;
return default;
}, 0, "", true), V.Undef) : Call(el_14, V.Undef, ((V)("path")), NewObj(2).Put("fill", Get(p_3972, "in")).Put("opacity", Get(p_3972, "io")).V, VG_3787)));
Set(p_3972, "QI", (Truthy(Get(p_3972, "ik")) ? Call(shr_3777, V.Undef, Get(p_3972, "Q"), Get(p_3972, "ik")) : V.Null));
return default;
}, 2, "", true));
LGR_3789 = Array_from(NewObj(1).Put("length", ((V)(9D))).V, Fn((V _self3750, int _argc3981, V __3987, V i_3988, V _a3985, V _a3986, V[] _rest3982) => {
return Arr(((V)((0.22 + (ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_3988) * 2.7) + 1D))))) * 0.62)))), ((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_3988) * 1.9) + 3D))))) * ToNum(TAU_9)))), ((V)((ToNum(Call(rnd_22, V.Undef, ((V)(((ToNum(i_3988) * 3.3) + 2D))))) * System.Math.PI))));
}, 2, "", true));
limb_3790 = Fn((V _self3750, int _argc3989, V q_3995, V kind_3996, V c_3997, V ax_3998, V[] _rest3990) => {
V S3_4002 = default;
V P2_4003 = default;
V NZ_4004 = default;
V RA_4005 = default;
V dg_4006 = default;
V ds_4007 = default;
V E_3999 = default;
V R_4000 = default;
V glob_4001 = default;
E_3999 = (_argc3989 > 4 ? _rest3990[0] : V.Undef);
R_4000 = (_argc3989 > 5 ? _rest3990[1] : V.Undef);
glob_4001 = (_argc3989 > 6 ? _rest3990[2] : V.Undef);
if (!(Truthy(Get(q_3995, "dec")))) {
Set(q_3995, "dec", Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, Get(Get(q_3995, "e"), "parentNode"), Get(Get(q_3995, "e"), "nextSibling")));
Set(q_3995, "dG", Call(el_14, V.Undef, ((V)("path")), NewObj(3).Put("fill", ((V)("#ffffff"))).Put("stroke", ((V)("#cfc5b0"))).Put("stroke-width", ((V)(0.24))).V, Get(q_3995, "dec")));
Set(q_3995, "dS", Call(el_14, V.Undef, ((V)("path")), NewObj(3).Put("fill", ((V)("#e6c682"))).Put("stroke", ((V)("#b48a42"))).Put("stroke-width", ((V)(0.22))).V, Get(q_3995, "dec")));
}
S3_4002 = Fn((V _self3750, int _argc4008, V th_4014, V f_4015, V _a4012, V _a4013, V[] _rest4009) => {
return Arr(((V)((FdLibm.Sin(ToNum(th_4014)) * FdLibm.Sin(ToNum(f_4015))))), ((V)((-FdLibm.Cos(ToNum(th_4014))))), ((V)((FdLibm.Sin(ToNum(th_4014)) * FdLibm.Cos(ToNum(f_4015))))));
}, 2, "", true);
P2_4003 = Fn((V _self3750, int _argc4016, V s_4022, V _a4019, V _a4020, V _a4021, V[] _rest4017) => {
return Call(glob_4001, V.Undef, Add(Add(Add(GetIdx(c_3997, 0D), ((V)((ToNum(GetIdx(s_4022, 0D)) * ToNum(GetIdx(GetIdx(ax_3998, 0D), 0D)))))), ((V)((ToNum(GetIdx(s_4022, 1D)) * ToNum(GetIdx(GetIdx(ax_3998, 1D), 0D)))))), ((V)((ToNum(GetIdx(s_4022, 2D)) * ToNum(GetIdx(GetIdx(ax_3998, 2D), 0D)))))), Add(Add(Add(GetIdx(c_3997, 1D), ((V)((ToNum(GetIdx(s_4022, 0D)) * ToNum(GetIdx(GetIdx(ax_3998, 0D), 1D)))))), ((V)((ToNum(GetIdx(s_4022, 1D)) * ToNum(GetIdx(GetIdx(ax_3998, 1D), 1D)))))), ((V)((ToNum(GetIdx(s_4022, 2D)) * ToNum(GetIdx(GetIdx(ax_3998, 2D), 1D)))))));
}, 1, "", true);
NZ_4004 = Fn((V _self3750, int _argc4023, V s_4029, V _a4026, V _a4027, V _a4028, V[] _rest4024) => {
V n0_4030 = default;
V n1_4031 = default;
V n2_4032 = default;
n0_4030 = ((V)(0D));
n1_4031 = ((V)(0D));
n2_4032 = ((V)(0D));
{
V i_4033 = default;
i_4033 = ((V)(0D));
while (true) {
if (!(LtN(i_4033, 3D))) break;
V k_4035 = default;
k_4035 = ((V)((ToNum(GetK(s_4029, i_4033)) / ToNum(GetK(R_4000, i_4033)))));
n0_4030 = Add(n0_4030, ((V)((ToNum(k_4035) * ToNum(GetIdx(GetK(E_3999, i_4033), 0D))))));
n1_4031 = Add(n1_4031, ((V)((ToNum(k_4035) * ToNum(GetIdx(GetK(E_3999, i_4033), 1D))))));
n2_4032 = Add(n2_4032, ((V)((ToNum(k_4035) * ToNum(GetIdx(GetK(E_3999, i_4033), 2D))))));
PostInc(ref i_4033, 1D);
}
}
return ((V)((ToNum(n2_4032) / ToNum((((V)(Hypot(ToNum(n0_4030), ToNum(n1_4031), ToNum(n2_4032)))) is var _t4036 && Truthy(_t4036) ? _t4036 : ((V)(1D)))))));
return default;
}, 1, "", true);
RA_4005 = ((V)((ToNum(Add(Add(GetIdx(R_4000, 0D), GetIdx(R_4000, 1D)), GetIdx(R_4000, 2D))) / 3D)));
dg_4006 = ((V)(""));
ds_4007 = ((V)(""));
Invoke(LGR_3789, "forEach", Fn((V _self3750, int _argc4037, V _a4039, V i_4043, V _a4041, V _a4042, V[] _rest4038) => {
V T_4051 = default;
V s_4052 = default;
V e1_4053 = default;
V e2_4054 = default;
V sz_4055 = default;
V Q_4056 = default;
V th_4046 = default;
V f_4048 = default;
V o_4050 = default;
{ V _t4044 = ListOf(_a4039);
{ V _t4045 = GetIdx(_t4044, 0D);
th_4046 = _t4045; }
{ V _t4047 = GetIdx(_t4044, 1D);
f_4048 = _t4047; }
{ V _t4049 = GetIdx(_t4044, 2D);
o_4050 = _t4049; }
}
T_4051 = ((V)((ToNum(th_4046) * System.Math.PI)));
s_4052 = Call(S3_4002, V.Undef, T_4051, f_4048);
if (LtN(Call(NZ_4004, V.Undef, s_4052), 0.15)) {
return default;
}
e1_4053 = Arr(((V)(FdLibm.Cos(ToNum(f_4048)))), ((V)(0D)), ((V)((-FdLibm.Sin(ToNum(f_4048))))));
e2_4054 = Arr(((V)((FdLibm.Cos(ToNum(T_4051)) * FdLibm.Sin(ToNum(f_4048))))), ((V)(FdLibm.Sin(ToNum(T_4051)))), ((V)((FdLibm.Cos(ToNum(T_4051)) * FdLibm.Cos(ToNum(f_4048))))));
sz_4055 = (SEqN(i_4043, 4D) ? Arr(((V)(1.1)), ((V)(0.55))) : Arr(((V)(1.5)), ((V)(0.72))));
Q_4056 = Arr();
{
V k_4057 = default;
k_4057 = ((V)(0D));
while (true) {
if (!(LtN(k_4057, 8D))) break;
V t_4059 = default;
V a_4060 = default;
V b_4061 = default;
V ca_4062 = default;
V sa_4063 = default;
t_4059 = ((V)(((ToNum(k_4057) / 8D) * ToNum(TAU_9))));
a_4060 = ((V)(((ToNum(GetIdx(sz_4055, 0D)) / ToNum(RA_4005)) * FdLibm.Cos(ToNum(t_4059)))));
b_4061 = ((V)(((ToNum(GetIdx(sz_4055, 1D)) / ToNum(RA_4005)) * FdLibm.Sin(ToNum(t_4059)))));
ca_4062 = ((V)(FdLibm.Cos(ToNum(o_4050))));
sa_4063 = ((V)(FdLibm.Sin(ToNum(o_4050))));
Invoke(Q_4056, "push", Call(P2_4003, V.Undef, Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _self3750, int _argc4064, V j_4070, V _a4067, V _a4068, V _a4069, V[] _rest4065) => {
return ((V)((((ToNum(GetK(s_4052, j_4070)) * 1.04) + (((ToNum(GetK(e1_4053, j_4070)) * ToNum(ca_4062)) + (ToNum(GetK(e2_4054, j_4070)) * ToNum(sa_4063))) * ToNum(a_4060))) + ((((-ToNum(GetK(e1_4053, j_4070))) * ToNum(sa_4063)) + (ToNum(GetK(e2_4054, j_4070)) * ToNum(ca_4062))) * ToNum(b_4061)))));
}, 1, "", true))));
PostInc(ref k_4057, 1D);
}
}
if (SEqN(i_4043, 4D)) {
ds_4007 = Add(ds_4007, Call(polyW_18, V.Undef, Q_4056));
} else {
dg_4006 = Add(dg_4006, Call(polyW_18, V.Undef, Q_4056));
}
return default;
}, 2, "", true));
Call(SA_31, V.Undef, Get(q_3995, "dG"), ((V)("d")), (dg_4006 is var _t4071 && Truthy(_t4071) ? _t4071 : ((V)("M0 0"))));
Call(SA_31, V.Undef, Get(q_3995, "dS"), ((V)("d")), (ds_4007 is var _t4072 && Truthy(_t4072) ? _t4072 : ((V)("M0 0"))));
return default;
}, 7, "", true);
return NewObj(27).Put("R0", R0_3758).Put("YT", YT_3759).Put("AL", AL_3760).Put("rT", rT_3762).Put("SM", SM_3772).Put("SG", SG_3765).Put("TG", TG_3766).Put("SS", SS_3767).Put("TS", TS_3768).Put("GT", GT_3780).Put("GSH", GSH_3779).Put("ses", ses_3781).Put("top", top_3782).Put("tgr", tgr_3783).Put("tse", tse_3784).Put("nori", nori_3785).Put("bedE", bedE_3786).Put("VG", VG_3787).Put("PC", PC_3778).Put("scl", scl_3788).Put("NO", Call(ringXZ_3773, V.Undef, Fn((V _self3750, int _argc4073, V f_4079, V _a4076, V _a4077, V _a4078, V[] _rest4074) => {
return Add(Call(NR_3769, V.Undef, f_4079), ((V)(0.85)));
}, 1, "", true), ((V)(64D)))).Put("BD", Call(ringXZ_3773, V.Undef, NR_3769, ((V)(64D)))).Put("limb", limb_3790).Put("rx", ((V)(29D))).Put("ya", ((V)(36D))).Put("yb", ((V)(86D))).Put("zE", Fn((V _self3750, int _argc4080, V dx_4086, V dy_4087, V _a4084, V _a4085, V[] _rest4081) => {
V r_4088 = default;
r_4088 = Call(rT_3762, V.Undef, Add(Get(S_3757, "HY"), dy_4087));
return ((V)((System.Math.Sqrt(Max(0D, ((ToNum(r_4088) * ToNum(r_4088)) - (ToNum(dx_4086) * ToNum(dx_4086))))) + 0.3)));
return default;
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self4089, int _argc4090, V B_4096, V D_4097, V _a4094, V _a4095, V[] _rest4091) => {
V set_4098 = default;
V W_4099 = default;
V P_4100 = default;
V rT_4101 = default;
V veg_4102 = default;
V YT_4103 = default;
V hp_4104 = default;
V ovalQ_4105 = default;
V oval_4106 = default;
V g3_4107 = default;
V gs_4108 = default;
V dx_4109 = default;
V dy_4110 = default;
V sd_4111 = default;
V ring_4112 = default;
V TP_4113 = default;
V tg_4114 = default;
V ts_4115 = default;
V L_4116 = default;
V ord_4117 = default;
if (_self4089.IsNullish) _self4089 = GlobalV;
{ V _t4118 = D_4097;
if (_t4118.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t4118));
{ V _t4119 = Get(_t4118, "set");
set_4098 = _t4119; } }
W_4099 = Call(tiltW_49, V.Undef, D_4097, Get(B_4096, "AL"), ((V)(60D)), Get(B_4096, "R0"));
P_4100 = Get(W_4099, "P");
rT_4101 = Get(B_4096, "rT");
veg_4102 = Call(clamp_12, V.Undef, Invoke(D_4097, "bv", ((V)("veg"))), ((V)(0D)), ((V)(1.3)));
YT_4103 = Get(B_4096, "YT");
hp_4104 = Arr();
{
V i_4120 = default;
i_4120 = ((V)(0D));
while (true) {
if (!(LeN(i_4120, 14D))) break;
V y_4122 = default;
V r_4123 = default;
y_4122 = Add(YT_4103, ((V)((((88D - ToNum(YT_4103)) * ToNum(i_4120)) / 14D))));
r_4123 = Call(rT_4101, V.Undef, y_4122);
{
V k_4124 = default;
k_4124 = ((V)(0D));
while (true) {
if (!(LtN(k_4124, 24D))) break;
V f_4126 = default;
f_4126 = ((V)(((ToNum(k_4124) / 24D) * ToNum(TAU_9))));
Invoke(hp_4104, "push", Call(P_4100, V.Undef, ((V)((50D + (ToNum(r_4123) * FdLibm.Sin(ToNum(f_4126)))))), y_4122, ((V)((ToNum(r_4123) * FdLibm.Cos(ToNum(f_4126)))))));
PostInc(ref k_4124, 1D);
}
}
PostInc(ref i_4120, 1D);
}
}
Set(B_4096, "d", Invoke(D_4097, "hull", hp_4104));
ovalQ_4105 = Fn((V _self4089, int _argc4127, V c_4133, V u_4134, V v_4135, V a_4136, V[] _rest4128) => {
V ca_4139 = default;
V sa_4140 = default;
V Q_4141 = default;
V b_4137 = default;
V o_4138 = default;
b_4137 = (_argc4127 > 4 ? _rest4128[0] : V.Undef);
o_4138 = (_argc4127 > 5 ? _rest4128[1] : V.Undef);
ca_4139 = ((V)(FdLibm.Cos(ToNum(o_4138))));
sa_4140 = ((V)(FdLibm.Sin(ToNum(o_4138))));
Q_4141 = Arr();
{
V k_4142 = default;
k_4142 = ((V)(0D));
while (true) {
if (!(LtN(k_4142, 8D))) break;
V t_4144 = default;
V A_4145 = default;
V Bb_4146 = default;
t_4144 = ((V)(((ToNum(k_4142) / 8D) * ToNum(TAU_9))));
A_4145 = ((V)((ToNum(a_4136) * FdLibm.Cos(ToNum(t_4144)))));
Bb_4146 = ((V)((ToNum(b_4137) * FdLibm.Sin(ToNum(t_4144)))));
Invoke(Q_4141, "push", Call(P_4100, V.Undef, Add(Add(GetIdx(c_4133, 0D), ((V)((((ToNum(GetIdx(u_4134, 0D)) * ToNum(ca_4139)) + (ToNum(GetIdx(v_4135, 0D)) * ToNum(sa_4140))) * ToNum(A_4145))))), ((V)(((((-ToNum(GetIdx(u_4134, 0D))) * ToNum(sa_4140)) + (ToNum(GetIdx(v_4135, 0D)) * ToNum(ca_4139))) * ToNum(Bb_4146))))), Add(Add(GetIdx(c_4133, 1D), ((V)((((ToNum(GetIdx(u_4134, 1D)) * ToNum(ca_4139)) + (ToNum(GetIdx(v_4135, 1D)) * ToNum(sa_4140))) * ToNum(A_4145))))), ((V)(((((-ToNum(GetIdx(u_4134, 1D))) * ToNum(sa_4140)) + (ToNum(GetIdx(v_4135, 1D)) * ToNum(ca_4139))) * ToNum(Bb_4146))))), Add(Add(GetIdx(c_4133, 2D), ((V)((((ToNum(GetIdx(u_4134, 2D)) * ToNum(ca_4139)) + (ToNum(GetIdx(v_4135, 2D)) * ToNum(sa_4140))) * ToNum(A_4145))))), ((V)(((((-ToNum(GetIdx(u_4134, 2D))) * ToNum(sa_4140)) + (ToNum(GetIdx(v_4135, 2D)) * ToNum(ca_4139))) * ToNum(Bb_4146)))))));
PostInc(ref k_4142, 1D);
}
}
return Q_4141;
return default;
}, 6, "", true);
oval_4106 = Fn((V _self4089, int _argc4147, V c_4153, V u_4154, V v_4155, V a_4156, V[] _rest4148) => {
V b_4157 = default;
V o_4158 = default;
b_4157 = (_argc4147 > 4 ? _rest4148[0] : V.Undef);
o_4158 = (_argc4147 > 5 ? _rest4148[1] : V.Undef);
return Call(polyW_18, V.Undef, Call(ovalQ_4105, V.Undef, c_4153, u_4154, v_4155, a_4156, b_4157, o_4158));
}, 6, "", true);
g3_4107 = Arr(((V)("")), ((V)("")), ((V)("")));
gs_4108 = ((V)(""));
dx_4109 = ((V)((0.32 * ToNum(Get(D_4097, "kS")))));
dy_4110 = ((V)((0.42 * ToNum(Get(D_4097, "kS")))));
Invoke(Get(B_4096, "SG"), "forEach", Fn((V _self4089, int _argc4159, V _a4161, V _a4162, V _a4163, V _a4164, V[] _rest4160) => {
V sf_4172 = default;
V cf_4173 = default;
V r_4174 = default;
V c_4175 = default;
V fz_4176 = default;
V p0_4177 = default;
V p1_4178 = default;
V b_4179 = default;
V Q_4180 = default;
V f_4167 = default;
V y_4169 = default;
V o_4171 = default;
{ V _t4165 = ListOf(_a4161);
{ V _t4166 = GetIdx(_t4165, 0D);
f_4167 = _t4166; }
{ V _t4168 = GetIdx(_t4165, 1D);
y_4169 = _t4168; }
{ V _t4170 = GetIdx(_t4165, 2D);
o_4171 = _t4170; }
}
sf_4172 = ((V)(FdLibm.Sin(ToNum(f_4167))));
cf_4173 = ((V)(FdLibm.Cos(ToNum(f_4167))));
r_4174 = Add(Call(rT_4101, V.Undef, y_4169), ((V)(0.55)));
c_4175 = Arr(((V)((50D + (ToNum(r_4174) * ToNum(sf_4172))))), y_4169, ((V)((ToNum(r_4174) * ToNum(cf_4173)))));
fz_4176 = Invoke(W_4099, "F", GetIdx(c_4175, 0D), GetIdx(c_4175, 1D), GetIdx(c_4175, 2D), sf_4172, ((V)(0D)), cf_4173);
if (LtN(fz_4176, 0.02)) {
return default;
}
p0_4177 = Call(P_4100, V.Undef, GetIdx(c_4175, 0D), GetIdx(c_4175, 1D), GetIdx(c_4175, 2D));
p1_4178 = Call(P_4100, V.Undef, Add(GetIdx(c_4175, 0D), sf_4172), GetIdx(c_4175, 1D), Add(GetIdx(c_4175, 2D), cf_4173));
b_4179 = ((V)((((((ToNum(GetIdx(p1_4178, 0D)) - ToNum(GetIdx(p0_4177, 0D))) / ToNum(Get(D_4097, "kS"))) * ToNum(GetIdx(LV_27, 0D))) + (((ToNum(GetIdx(p1_4178, 1D)) - ToNum(GetIdx(p0_4177, 1D))) / ToNum(Get(D_4097, "kS"))) * ToNum(GetIdx(LV_27, 1D)))) + (ToNum(fz_4176) * ToNum(GetIdx(LV_27, 2D))))));
Q_4180 = Call(ovalQ_4105, V.Undef, c_4175, Arr(cf_4173, ((V)(0D)), ((V)((-ToNum(sf_4172))))), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))), ((V)(1.85)), ((V)(0.88)), o_4171);
OpSetK(g3_4107, ((V)((GtN(b_4179, 0.45) ? 0D : (GtN(b_4179, 0.12) ? 1D : 2D)))), 0, Call(polyW_18, V.Undef, Q_4180));
gs_4108 = Add(gs_4108, Call(polyW_18, V.Undef, Invoke(Q_4180, "map", Fn((V _self4089, int _argc4181, V q_4187, V _a4184, V _a4185, V _a4186, V[] _rest4182) => {
return Arr(Add(GetIdx(q_4187, 0D), dx_4109), Add(GetIdx(q_4187, 1D), dy_4110));
}, 1, "", true))));
return default;
}, 1, "", true));
Invoke(Get(B_4096, "GT"), "forEach", Fn((V _self4089, int _argc4188, V e_4194, V i_4195, V _a4192, V _a4193, V[] _rest4189) => {
return Call(set_4098, V.Undef, e_4194, ((V)("d")), (GetK(g3_4107, i_4195) is var _t4196 && Truthy(_t4196) ? _t4196 : ((V)("M0 0"))));
}, 2, "", true));
Call(set_4098, V.Undef, Get(B_4096, "GSH"), ((V)("d")), (gs_4108 is var _t4197 && Truthy(_t4197) ? _t4197 : ((V)("M0 0"))));
sd_4111 = ((V)(""));
Invoke(Get(B_4096, "SS"), "forEach", Fn((V _self4089, int _argc4198, V _a4200, V _a4201, V _a4202, V _a4203, V[] _rest4199) => {
V sf_4211 = default;
V cf_4212 = default;
V r_4213 = default;
V c_4214 = default;
V f_4206 = default;
V y_4208 = default;
V o_4210 = default;
{ V _t4204 = ListOf(_a4200);
{ V _t4205 = GetIdx(_t4204, 0D);
f_4206 = _t4205; }
{ V _t4207 = GetIdx(_t4204, 1D);
y_4208 = _t4207; }
{ V _t4209 = GetIdx(_t4204, 2D);
o_4210 = _t4209; }
}
sf_4211 = ((V)(FdLibm.Sin(ToNum(f_4206))));
cf_4212 = ((V)(FdLibm.Cos(ToNum(f_4206))));
r_4213 = Add(Call(rT_4101, V.Undef, y_4208), ((V)(0.5)));
c_4214 = Arr(((V)((50D + (ToNum(r_4213) * ToNum(sf_4211))))), y_4208, ((V)((ToNum(r_4213) * ToNum(cf_4212)))));
if (LtN(Invoke(W_4099, "F", GetIdx(c_4214, 0D), GetIdx(c_4214, 1D), GetIdx(c_4214, 2D), sf_4211, ((V)(0D)), cf_4212), 0.06)) {
return default;
}
sd_4111 = Add(sd_4111, Call(oval_4106, V.Undef, c_4214, Arr(cf_4212, ((V)(0D)), ((V)((-ToNum(sf_4211))))), Arr(((V)(0D)), ((V)(1D)), ((V)(0D))), ((V)(1.15)), ((V)(0.55)), o_4210));
return default;
}, 1, "", true));
Call(set_4098, V.Undef, Get(B_4096, "ses"), ((V)("d")), (sd_4111 is var _t4215 && Truthy(_t4215) ? _t4215 : ((V)("M0 0"))));
ring_4112 = Fn((V _self4089, int _argc4216, V r_4222, V y_4223, V n_4224, V _a4221, V[] _rest4217) => {
return Array_from(NewObj(1).Put("length", n_4224).V, Fn((V _self4089, int _argc4225, V __4231, V k_4232, V _a4229, V _a4230, V[] _rest4226) => {
V f_4233 = default;
f_4233 = ((V)(((ToNum(k_4232) / ToNum(n_4224)) * ToNum(TAU_9))));
return Call(P_4100, V.Undef, ((V)((50D + (ToNum(r_4222) * FdLibm.Sin(ToNum(f_4233)))))), y_4223, ((V)((ToNum(r_4222) * FdLibm.Cos(ToNum(f_4233))))));
return default;
}, 2, "", true));
}, 3, "", true);
Call(set_4098, V.Undef, Get(B_4096, "top"), ((V)("d")), Call(polyW_18, V.Undef, Call(ring_4112, V.Undef, Get(B_4096, "R0"), YT_4103, ((V)(48D)))));
TP_4113 = Fn((V _self4089, int _argc4234, V x_4240, V z_4241, V h_4242, V _a4239, V[] _rest4235) => {
return Call(P_4100, V.Undef, x_4240, ((V)((ToNum(YT_4103) - ToNum((h_4242 is var _t4243 && Truthy(_t4243) ? _t4243 : ((V)(0D))))))), z_4241);
}, 3, "", true);
tg_4114 = ((V)(""));
ts_4115 = ((V)(""));
Invoke(Get(B_4096, "TG"), "forEach", Fn((V _self4089, int _argc4244, V _a4246, V _a4247, V _a4248, V _a4249, V[] _rest4245) => {
V r_4252 = default;
V f_4254 = default;
V o_4256 = default;
{ V _t4250 = ListOf(_a4246);
{ V _t4251 = GetIdx(_t4250, 0D);
r_4252 = _t4251; }
{ V _t4253 = GetIdx(_t4250, 1D);
f_4254 = _t4253; }
{ V _t4255 = GetIdx(_t4250, 2D);
o_4256 = _t4255; }
}
tg_4114 = Add(tg_4114, Call(oval_4106, V.Undef, Arr(((V)((50D + (ToNum(r_4252) * FdLibm.Sin(ToNum(f_4254)))))), ((V)((ToNum(YT_4103) - 0.12))), ((V)((ToNum(r_4252) * FdLibm.Cos(ToNum(f_4254)))))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), ((V)(1.65)), ((V)(0.8)), o_4256));
return default;
}, 1, "", true));
Invoke(Get(B_4096, "TS"), "forEach", Fn((V _self4089, int _argc4257, V _a4259, V _a4260, V _a4261, V _a4262, V[] _rest4258) => {
V r_4265 = default;
V f_4267 = default;
V o_4269 = default;
{ V _t4263 = ListOf(_a4259);
{ V _t4264 = GetIdx(_t4263, 0D);
r_4265 = _t4264; }
{ V _t4266 = GetIdx(_t4263, 1D);
f_4267 = _t4266; }
{ V _t4268 = GetIdx(_t4263, 2D);
o_4269 = _t4268; }
}
ts_4115 = Add(ts_4115, Call(oval_4106, V.Undef, Arr(((V)((50D + (ToNum(r_4265) * FdLibm.Sin(ToNum(f_4267)))))), ((V)((ToNum(YT_4103) - 0.14))), ((V)((ToNum(r_4265) * FdLibm.Cos(ToNum(f_4267)))))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), ((V)(1.15)), ((V)(0.55)), o_4269));
return default;
}, 1, "", true));
Call(set_4098, V.Undef, Get(B_4096, "tgr"), ((V)("d")), tg_4114);
Call(set_4098, V.Undef, Get(B_4096, "tse"), ((V)("d")), ts_4115);
Call(set_4098, V.Undef, Get(B_4096, "nori"), ((V)("d")), Call(polyW_18, V.Undef, Invoke(Get(B_4096, "NO"), "map", Fn((V _self4089, int _argc4270, V _a4272, V _a4273, V _a4274, V _a4275, V[] _rest4271) => {
V x_4278 = default;
V z_4280 = default;
{ V _t4276 = ListOf(_a4272);
{ V _t4277 = GetIdx(_t4276, 0D);
x_4278 = _t4277; }
{ V _t4279 = GetIdx(_t4276, 1D);
z_4280 = _t4279; }
}
return Call(TP_4113, V.Undef, x_4278, z_4280, ((V)(0.05)));
}, 1, "", true))));
Call(set_4098, V.Undef, Get(B_4096, "bedE"), ((V)("d")), Call(polyW_18, V.Undef, Invoke(Get(B_4096, "BD"), "map", Fn((V _self4089, int _argc4281, V _a4283, V _a4284, V _a4285, V _a4286, V[] _rest4282) => {
V x_4289 = default;
V z_4291 = default;
{ V _t4287 = ListOf(_a4283);
{ V _t4288 = GetIdx(_t4287, 0D);
x_4289 = _t4288; }
{ V _t4290 = GetIdx(_t4287, 1D);
z_4291 = _t4290; }
}
return Call(TP_4113, V.Undef, x_4289, z_4291, ((V)(0.08)));
}, 1, "", true))));
L_4116 = Invoke(Invoke(Get(B_4096, "PC"), "map", Fn((V _self4089, int _argc4300, V p_4306, V i_4307, V _a4304, V _a4305, V[] _rest4301) => {
V h_4308 = default;
V sw_4309 = default;
V bot_4310 = default;
V tp_4311 = default;
V td_4312 = default;
V cx_4313 = default;
V cz_4314 = default;
h_4308 = ((V)(((ToNum(Get(p_4306, "h")) * (1D + (ToNum(veg_4102) * 0.6))) + ((ToNum(veg_4102) * 1.2) * Max(0D, FdLibm.Sin(((ToNum(Get(D_4097, "ts")) * 9D) + (ToNum(i_4307) * 1.7))))))));
sw_4309 = ((V)(((ToNum(Get(D_4097, "ox")) * 0.06) + ((ToNum(veg_4102) * FdLibm.Sin(ToNum(Add(((V)((ToNum(Get(D_4097, "ts")) * 11D))), i_4307)))) * 0.5))));
bot_4310 = Invoke(Get(p_4306, "Q"), "map", Fn((V _self4089, int _argc4315, V _a4317, V _a4318, V _a4319, V _a4320, V[] _rest4316) => {
V x_4323 = default;
V z_4325 = default;
{ V _t4321 = ListOf(_a4317);
{ V _t4322 = GetIdx(_t4321, 0D);
x_4323 = _t4322; }
{ V _t4324 = GetIdx(_t4321, 1D);
z_4325 = _t4324; }
}
return Call(TP_4113, V.Undef, x_4323, z_4325, ((V)(0.1)));
}, 1, "", true));
tp_4311 = Invoke(Get(p_4306, "Q"), "map", Fn((V _self4089, int _argc4326, V _a4328, V _a4329, V _a4330, V _a4331, V[] _rest4327) => {
V x_4334 = default;
V z_4336 = default;
{ V _t4332 = ListOf(_a4328);
{ V _t4333 = GetIdx(_t4332, 0D);
x_4334 = _t4333; }
{ V _t4335 = GetIdx(_t4332, 1D);
z_4336 = _t4335; }
}
return Call(TP_4113, V.Undef, Add(x_4334, sw_4309), z_4336, h_4308);
}, 1, "", true));
Call(set_4098, V.Undef, Get(p_4306, "sdE"), ((V)("d")), Invoke(D_4097, "hull", Invoke(bot_4310, "concat", tp_4311)));
td_4312 = Call(polyW_18, V.Undef, tp_4311);
Call(set_4098, V.Undef, Get(p_4306, "e"), ((V)("d")), td_4312);
if (SEqS(Get(p_4306, "n"), "s")) {
Call(set_4098, V.Undef, Get(Get(B_4096, "scl"), "p"), ((V)("d")), td_4312);
Call(set_4098, V.Undef, Get(Get(p_4306, "ex"), "firstChild"), ((V)("d")), Invoke(Invoke(Arr(((V)(37.5)), ((V)(46.5))), "map", Fn((V _self4089, int _argc4337, V x0_4343, V _a4340, V _a4341, V _a4342, V[] _rest4338) => {
return ((V)(string.Concat("M", ToStr(Invoke(Array_from(NewObj(1).Put("length", ((V)(12D))).V, Fn((V _self4089, int _argc4344, V __4350, V k_4351, V _a4348, V _a4349, V[] _rest4345) => {
V q_4352 = default;
q_4352 = Invoke(B_4096, "SM", Add(x0_4343, ((V)((ToNum(k_4351) * 1.05)))), ((V)(((-14.5) + (ToNum(k_4351) * 1.45)))));
return Call(pt_15, V.Undef, Call(TP_4113, V.Undef, Add(GetIdx(q_4352, 0D), sw_4309), GetIdx(q_4352, 1D), Add(h_4308, ((V)(0.02)))));
return default;
}, 2, "", true)), "join", ((V)("L")))))));
}, 1, "", true)), "join", ((V)(""))));
} else {
Call(set_4098, V.Undef, Get(p_4306, "ex"), ((V)("d")), Call(polyW_18, V.Undef, Invoke(Get(p_4306, "QI"), "map", Fn((V _self4089, int _argc4353, V _a4355, V _a4356, V _a4357, V _a4358, V[] _rest4354) => {
V x_4361 = default;
V z_4363 = default;
{ V _t4359 = ListOf(_a4355);
{ V _t4360 = GetIdx(_t4359, 0D);
x_4361 = _t4360; }
{ V _t4362 = GetIdx(_t4359, 1D);
z_4363 = _t4362; }
}
return Call(TP_4113, V.Undef, Add(x_4361, sw_4309), z_4363, Add(h_4308, ((V)(0.02))));
}, 1, "", true))));
}
cx_4313 = ((V)((ToNum(Invoke(Get(p_4306, "Q"), "reduce", Fn((V _self4089, int _argc4364, V s_4370, V q_4371, V _a4368, V _a4369, V[] _rest4365) => {
return Add(s_4370, GetIdx(q_4371, 0D));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(Get(p_4306, "Q"), "length")))));
cz_4314 = ((V)((ToNum(Invoke(Get(p_4306, "Q"), "reduce", Fn((V _self4089, int _argc4372, V s_4378, V q_4379, V _a4376, V _a4377, V[] _rest4373) => {
return Add(s_4378, GetIdx(q_4379, 1D));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(Get(p_4306, "Q"), "length")))));
return NewObj(4).Put("id", Get(p_4306, "id")).Put("e", Get(p_4306, "sdE")).Put("ex", Arr(Get(p_4306, "e"), Get(p_4306, "ex"))).Put("z", Invoke(W_4099, "Z", cx_4313, ((V)((ToNum(YT_4103) - (ToNum(h_4308) / 2D)))), cz_4314)).V;
return default;
}, 2, "", true)), "sort", Fn((V _self4089, int _argc4292, V a_4298, V b_4299, V _a4296, V _a4297, V[] _rest4293) => {
return ((V)((ToNum(Get(a_4298, "z")) - ToNum(Get(b_4299, "z")))));
}, 2, "", true));
ord_4117 = Arr();
Invoke(L_4116, "forEach", Fn((V _self4089, int _argc4380, V l_4386, V _a4383, V _a4384, V _a4385, V[] _rest4381) => {
Invoke(ord_4117, "push", l_4386);
Invoke(Get(l_4386, "ex"), "forEach", Fn((V _self4089, int _argc4387, V e_4393, V j_4394, V _a4391, V _a4392, V[] _rest4388) => {
return Invoke(ord_4117, "push", NewObj(2).Put("id", ((V)(string.Concat(ToStr(Get(l_4386, "id")), "x", ToStr(j_4394))))).Put("e", e_4393).V);
}, 2, "", true));
return default;
}, 1, "", true));
Invoke(SN_43, "order", Get(B_4096, "VG"), ord_4117);
return default;
}, 2, "draw", false)).V);
Set(MODELS_42, "noodle", NewObj(2).Put("setup", Fn((V _self4395, int _argc4396, V S_4402, V _a4399, V _a4400, V _a4401, V[] _rest4397) => {
V EL_4403 = default;
V O_4404 = default;
V sid_4405 = default;
V PR_4406 = default;
V Y0_4407 = default;
V Y1_4408 = default;
V rT_4409 = default;
V hid_4410 = default;
V bro_4411 = default;
V BF_4412 = default;
V sk0_4413 = default;
V CK_4414 = default;
V sh_4415 = default;
V bd_4416 = default;
V rm_4417 = default;
V rimB_4418 = default;
V rimI_4419 = default;
V broth_4420 = default;
V FG_4421 = default;
V TG_4422 = default;
V rimF_4423 = default;
V rimL_4424 = default;
V FL_4425 = default;
V box_4426 = default;
V SP_4427 = default;
V hp_4428 = default;
V NS_4429 = default;
V SG_4430 = default;
V hang_4431 = default;
V hang2_4432 = default;
V ck_4433 = default;
V sticks_4434 = default;
if (_self4395.IsNullish) _self4395 = GlobalV;
EL_4403 = ((V)(0.178));
O_4404 = Invoke(S_4402, "outline", Get(S_4402, "sk"), ((V)(96D)));
sid_4405 = Fn((V _self4395, int _argc4435, V q_4441, V _a4438, V _a4439, V _a4440, V[] _rest4436) => {
V g_4442 = default;
g_4442 = (Get(Get(q_4441, "e"), "closest") is var _t4443 && !Truthy(_t4443) ? _t4443 : Invoke(Get(q_4441, "e"), "closest", ((V)("[data-s]"))));
return (Truthy(g_4442) ? Invoke(g_4442, "getAttribute", ((V)("data-s"))) : ((V)("")));
return default;
}, 1, "", true);
PR_4406 = Arr();
{
V ys_4444 = default;
ys_4444 = ((V)(46D));
while (true) {
if (!(LeN(ys_4444, 86.6))) break;
V r_4446 = default;
r_4446 = Call(halfW_38, V.Undef, O_4404, ys_4444);
if (GtN(r_4446, 0.5)) {
Invoke(PR_4406, "push", Arr(Add(ys_4444, ((V)((ToNum(EL_4403) * ToNum(r_4446))))), r_4446));
}
ys_4444 = Add(ys_4444, ((V)(0.4)));
}
}
Invoke(PR_4406, "sort", Fn((V _self4395, int _argc4447, V p_4453, V q_4454, V _a4451, V _a4452, V[] _rest4448) => {
return ((V)((ToNum(GetIdx(p_4453, 0D)) - ToNum(GetIdx(q_4454, 0D)))));
}, 2, "", true));
Y0_4407 = GetIdx(GetIdx(PR_4406, 0D), 0D);
Y1_4408 = GetIdx(GetIdx(PR_4406, (ToNum(Get(PR_4406, "length")) - 1D)), 0D);
rT_4409 = Fn((V _self4395, int _argc4455, V y_4461, V _a4458, V _a4459, V _a4460, V[] _rest4456) => {
V i_4462 = default;
V p_4463 = default;
V q_4464 = default;
V t_4465 = default;
y_4461 = Call(clamp_12, V.Undef, y_4461, Y0_4407, Y1_4408);
i_4462 = ((V)(1D));
while ((LtN(i_4462, (ToNum(Get(PR_4406, "length")) - 1D)) && Lt(GetIdx(GetK(PR_4406, i_4462), 0D), y_4461))) {
PostInc(ref i_4462, 1D);
}
p_4463 = GetIdx(PR_4406, (ToNum(i_4462) - 1D));
q_4464 = GetK(PR_4406, i_4462);
t_4465 = ((V)((Gt(GetIdx(q_4464, 0D), GetIdx(p_4463, 0D)) ? ((ToNum(y_4461) - ToNum(GetIdx(p_4463, 0D))) / (ToNum(GetIdx(q_4464, 0D)) - ToNum(GetIdx(p_4463, 0D)))) : 0D)));
return Add(GetIdx(p_4463, 1D), ((V)(((ToNum(GetIdx(q_4464, 1D)) - ToNum(GetIdx(p_4463, 1D))) * ToNum(t_4465)))));
return default;
}, 1, "", true);
hid_4410 = Invoke(S_4402, "hide", Fn((V _self4395, int _argc4466, V q_4472, V _a4469, V _a4470, V _a4471, V[] _rest4467) => {
return ((Get(q_4472, "inBody") is var _t4473 && !Truthy(_t4473) ? _t4473 : Invoke(S_4402, "dk", q_4472, ((V)("top")))) is var _t4474 && !Truthy(_t4474) ? _t4474 : Invoke(Arr(((V)("rim")), ((V)("broth")), ((V)("lip")), ((V)("sticks"))), "includes", Call(sid_4405, V.Undef, q_4472)));
}, 1, "", true));
bro_4411 = Invoke(hid_4410, "find", Fn((V _self4395, int _argc4475, V q_4481, V _a4478, V _a4479, V _a4480, V[] _rest4476) => {
return (SEqS(Call(sid_4405, V.Undef, q_4481), "broth") ? V.True : V.False);
}, 1, "", true));
BF_4412 = (Truthy(bro_4411) ? Invoke(S_4402, "f", bro_4411) : ((V)("#efb35c")));
sk0_4413 = Invoke(hid_4410, "find", Fn((V _self4395, int _argc4482, V q_4488, V _a4485, V _a4486, V _a4487, V[] _rest4483) => {
return (SEqS(Call(sid_4405, V.Undef, q_4488), "sticks") ? V.True : V.False);
}, 1, "", true));
CK_4414 = (Truthy(sk0_4413) ? Invoke(S_4402, "f", sk0_4413) : ((V)("#d9a868")));
Invoke(S_4402, "hide", Fn((V _self4395, int _argc4489, V q_4495, V _a4492, V _a4493, V _a4494, V[] _rest4490) => {
return ((Get(q_4495, "inBody") is var _t4496 && !Truthy(_t4496) ? _t4496 : (!(Truthy(Invoke(S_4402, "dk", q_4495))) ? V.True : V.False)) is var _t4497 && !Truthy(_t4497) ? _t4497 : ((SEqS(Invoke(S_4402, "f", q_4495), "#e2402e") || SEqS(Invoke(S_4402, "s", q_4495), "#e2402e")) ? V.True : V.False));
}, 1, "", true));
sh_4415 = Invoke(S_4402, "path", NewObj(1).Put("fill", Invoke(S_4402, "lgrad", ((V)("ndsh")), Arr(Arr(((V)(0D)), ((V)("#8a7a66")), ((V)(0.3))), Arr(((V)(0.15)), ((V)("#8a7a66")), ((V)(0.06))), Arr(((V)(0.3)), ((V)("#ffffff")), ((V)(0.4))), Arr(((V)(0.46)), ((V)("#ffffff")), ((V)(0D))), Arr(((V)(0.76)), ((V)("#6a5a46")), ((V)(0.05))), Arr(((V)(1D)), ((V)("#6a5a46")), ((V)(0.34)))))).V);
bd_4416 = Invoke(S_4402, "path", NewObj(1).Put("fill", ((V)("#e2402e"))).V);
rm_4417 = Invoke(S_4402, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#e2402e"))).Put("stroke-width", ((V)(1D))).Put("stroke-linejoin", ((V)("round"))).Put("stroke-linecap", ((V)("round"))).V);
rimB_4418 = Invoke(S_4402, "path", NewObj(1).Put("fill", ((V)("#fbf3e6"))).V);
rimI_4419 = Invoke(S_4402, "path", NewObj(1).Put("fill", ((V)("#efe4d2"))).V);
broth_4420 = Invoke(S_4402, "path", NewObj(1).Put("fill", BF_4412).V);
FG_4421 = Invoke(S_4402, "g");
TG_4422 = Invoke(S_4402, "g");
rimF_4423 = Invoke(S_4402, "path", NewObj(1).Put("fill", ((V)("#fbf3e6"))).V);
rimL_4424 = Invoke(S_4402, "path", NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(0.8))).Put("opacity", ((V)(0.8))).V);
FL_4425 = Invoke(S_4402, "decals", Fn((V _self4395, int _argc4498, V q_4504, V _a4501, V _a4502, V _a4503, V[] _rest4499) => {
return (Get(q_4504, "inBody") is var _t4505 && !Truthy(_t4505) ? _t4505 : (SEqS(Call(sid_4405, V.Undef, q_4504), "flat") ? V.True : V.False));
}, 1, "", true), FG_4421);
box_4426 = Fn((V _self4395, int _argc4506, V D__4512, V _a4509, V _a4510, V _a4511, V[] _rest4507) => {
V x0_4513 = default;
V x1_4514 = default;
V y0_4515 = default;
V y1_4516 = default;
x0_4513 = ((V)(1000000000D));
x1_4514 = ((V)((-1000000000D)));
y0_4515 = ((V)(1000000000D));
y1_4516 = ((V)((-1000000000D)));
Invoke(D__4512, "forEach", Fn((V _self4395, int _argc4517, V o_4523, V _a4520, V _a4521, V _a4522, V[] _rest4518) => {
return Invoke(Get(o_4523, "L"), "forEach", Fn((V _self4395, int _argc4524, V L_4530, V _a4527, V _a4528, V _a4529, V[] _rest4525) => {
return Invoke(L_4530, "forEach", Fn((V _self4395, int _argc4531, V p_4537, V _a4534, V _a4535, V _a4536, V[] _rest4532) => {
if (Lt(GetIdx(p_4537, 0D), x0_4513)) {
x0_4513 = GetIdx(p_4537, 0D);
}
if (Gt(GetIdx(p_4537, 0D), x1_4514)) {
x1_4514 = GetIdx(p_4537, 0D);
}
if (Lt(GetIdx(p_4537, 1D), y0_4515)) {
y0_4515 = GetIdx(p_4537, 1D);
}
if (Gt(GetIdx(p_4537, 1D), y1_4516)) {
y1_4516 = GetIdx(p_4537, 1D);
}
return default;
}, 1, "", true));
}, 1, "", true));
}, 1, "", true));
return NewObj(4).Put("x0", x0_4513).Put("x1", x1_4514).Put("y0", y0_4515).Put("y1", y1_4516).V;
return default;
}, 1, "", true);
SP_4427 = Invoke(Arr(((V)("chashu")), ((V)("heap")), ((V)("egg")), ((V)("nar1")), ((V)("nar2"))), "map", Fn((V _self4395, int _argc4538, V n_4544, V _a4541, V _a4542, V _a4543, V[] _rest4539) => {
V g_4545 = default;
V D__4546 = default;
V b_4547 = default;
V h_4548 = default;
g_4545 = Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, TG_4422);
D__4546 = Invoke(S_4402, "decals", Fn((V _self4395, int _argc4549, V q_4555, V _a4552, V _a4553, V _a4554, V[] _rest4550) => {
return (Get(q_4555, "inBody") is var _t4556 && !Truthy(_t4556) ? _t4556 : (SEq(Call(sid_4405, V.Undef, q_4555), n_4544) ? V.True : V.False));
}, 1, "", true), g_4545);
b_4547 = Call(box_4426, V.Undef, D__4546);
h_4548 = ((V)((ToNum(Get(b_4547, "y1")) - ToNum(Get(b_4547, "y0")))));
return NewObj(6).Put("n", n_4544).Put("g", g_4545).Put("D", D__4546).Put("ax", ((V)((ToNum(Add(Get(b_4547, "x0"), Get(b_4547, "x1"))) / 2D)))).Put("ay", ((V)((ToNum(Get(b_4547, "y1")) - Min(2.2, (ToNum(h_4548) * 0.3)))))).Put("lag", ((V)((SEqS(n_4544, "heap") ? 1D : 0.5)))).V;
return default;
}, 1, "", true));
hp_4428 = Invoke(SP_4427, "find", Fn((V _self4395, int _argc4557, V o_4563, V _a4560, V _a4561, V _a4562, V[] _rest4558) => {
return (SEqS(Get(o_4563, "n"), "heap") ? V.True : V.False);
}, 1, "", true));
Set(hp_4428, "sl", Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _self4395, int _argc4564, V _a4566, V _a4567, V _a4568, V _a4569, V[] _rest4565) => {
return Call(el_14, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#b07c22"))).Put("stroke-width", ((V)(2.2))).Put("stroke-linecap", ((V)("round"))).V, Get(hp_4428, "g"));
}, 0, "", true)));
Set(hp_4428, "sl2", Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _self4395, int _argc4570, V _a4572, V _a4573, V _a4574, V _a4575, V[] _rest4571) => {
return Call(el_14, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffd65e"))).Put("stroke-width", ((V)(1.5))).Put("stroke-linecap", ((V)("round"))).V, Get(hp_4428, "g"));
}, 0, "", true)));
NS_4429 = Invoke(Arr(((V)("nori1")), ((V)("nori2"))), "map", Fn((V _self4395, int _argc4576, V n_4582, V _a4579, V _a4580, V _a4581, V[] _rest4577) => {
V g_4583 = default;
V D__4584 = default;
V b_4585 = default;
g_4583 = Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, TG_4422);
D__4584 = Invoke(S_4402, "decals", Fn((V _self4395, int _argc4586, V q_4592, V _a4589, V _a4590, V _a4591, V[] _rest4587) => {
return (Get(q_4592, "inBody") is var _t4593 && !Truthy(_t4593) ? _t4593 : (SEq(Call(sid_4405, V.Undef, q_4592), n_4582) ? V.True : V.False));
}, 1, "", true), g_4583);
b_4585 = Call(box_4426, V.Undef, D__4584);
return NewObj(5).Put("n", n_4582).Put("g", g_4583).Put("D", D__4584).Put("yb", ((V)((ToNum(Get(b_4585, "y1")) - 0.6)))).Put("cx", ((V)((ToNum(Add(Get(b_4585, "x0"), Get(b_4585, "x1"))) / 2D)))).V;
return default;
}, 1, "", true));
SG_4430 = Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, TG_4422);
hang_4431 = Call(el_14, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#b07c22"))).Put("stroke-width", ((V)(2.2))).Put("stroke-linecap", ((V)("round"))).V, SG_4430);
hang2_4432 = Call(el_14, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffd65e"))).Put("stroke-width", ((V)(1.5))).Put("stroke-linecap", ((V)("round"))).V, SG_4430);
ck_4433 = Invoke(S_4402, "lgrad", ((V)("ndck")), Arr(Arr(((V)(0D)), ((V)("#f4d6a4"))), Arr(((V)(0.5)), ((V)("#d9a868"))), Arr(((V)(1D)), ((V)("#a87a44")))), NewObj(4).Put("x1", ((V)(0D))).Put("y1", ((V)(0D))).Put("x2", ((V)(0D))).Put("y2", ((V)(1D))).V);
sticks_4434 = Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _self4395, int _argc4594, V _a4596, V _a4597, V _a4598, V _a4599, V[] _rest4595) => {
return Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", (Truthy(Invoke(CK_4414, "startsWith", ((V)("url")))) ? ck_4433 : CK_4414)).V, SG_4430);
}, 0, "", true));
return NewObj(29).Put("EL", EL_4403).Put("O", O_4404).Put("rT", rT_4409).Put("Y0", Y0_4407).Put("Y1", Y1_4408).Put("YR", Y0_4407).Put("YB", Add(Y0_4407, ((V)(0.3)))).Put("R0", Call(rT_4409, V.Undef, Y0_4407)).Put("sh", sh_4415).Put("bd", bd_4416).Put("rm", rm_4417).Put("rimB", rimB_4418).Put("rimI", rimI_4419).Put("broth", broth_4420).Put("FG", FG_4421).Put("TG", TG_4422).Put("rimF", rimF_4423).Put("rimL", rimL_4424).Put("FL", FL_4425).Put("SP", SP_4427).Put("NS", NS_4429).Put("SG", SG_4430).Put("hang", hang_4431).Put("hang2", hang2_4432).Put("sticks", sticks_4434).Put("rx", ((V)(34D))).Put("ya", ((V)(55D))).Put("yb", ((V)(86D))).Put("zE", Fn((V _self4395, int _argc4600, V dx_4606, V dy_4607, V _a4604, V _a4605, V[] _rest4601) => {
V r_4608 = default;
r_4608 = Call(rT_4409, V.Undef, Add(Get(S_4402, "HY"), dy_4607));
return ((V)((System.Math.Sqrt(Max(0D, ((ToNum(r_4608) * ToNum(r_4608)) - (ToNum(dx_4606) * ToNum(dx_4606))))) + 0.3)));
return default;
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self4609, int _argc4610, V B_4616, V D_4617, V _a4614, V _a4615, V[] _rest4611) => {
V Z3_4618 = default;
V set_4619 = default;
V EL_4620 = default;
V rT_4621 = default;
V YR_4622 = default;
V YB_4623 = default;
V R0_4624 = default;
V PE_4625 = default;
V slurp_4626 = default;
V lid_4627 = default;
V ts_4628 = default;
V RP_4629 = default;
V ring_4630 = default;
V hp_4631 = default;
V A_4632 = default;
V yS_4633 = default;
V hS_4634 = default;
V rS_4635 = default;
V nS_4636 = default;
V wS_4637 = default;
V q_4638 = default;
V SPI_4639 = default;
V rd_4640 = default;
V zOf_4641 = default;
V L_4642 = default;
V zt_4643 = default;
V ze_4644 = default;
V lf_4645 = default;
V dp_4646 = default;
V T_4647 = default;
V E_4648 = default;
V tips_4649 = default;
V hd_4650 = default;
V FA_4651 = default;
if (_self4609.IsNullish) _self4609 = GlobalV;
{ V _t4652 = D_4617;
if (_t4652.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t4652));
{ V _t4653 = Get(_t4652, "Z3");
Z3_4618 = _t4653; }
{ V _t4654 = Get(_t4652, "set");
set_4619 = _t4654; } }
{ V _t4655 = B_4616;
if (_t4655.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t4655));
{ V _t4656 = Get(_t4655, "EL");
EL_4620 = _t4656; }
{ V _t4657 = Get(_t4655, "rT");
rT_4621 = _t4657; }
{ V _t4658 = Get(_t4655, "YR");
YR_4622 = _t4658; }
{ V _t4659 = Get(_t4655, "YB");
YB_4623 = _t4659; }
{ V _t4660 = Get(_t4655, "R0");
R0_4624 = _t4660; } }
PE_4625 = Call(PEf_48, V.Undef, D_4617, EL_4620, rT_4621);
slurp_4626 = Call(clamp_12, V.Undef, Invoke(D_4617, "bv", ((V)("slurp"))), ((V)(0D)), ((V)(1.2)));
lid_4627 = Call(clamp_12, V.Undef, Invoke(D_4617, "bv", ((V)("lid"))), ((V)((-1D))), ((V)(1.2)));
ts_4628 = Get(D_4617, "ts");
RP_4629 = Fn((V _self4609, int _argc4661, V r_4667, V y_4668, V f_4669, V _a4666, V[] _rest4662) => {
return Call(PE_4625, V.Undef, ((V)((50D + (ToNum(r_4667) * FdLibm.Sin(ToNum(f_4669)))))), y_4668, ((V)((ToNum(r_4667) * FdLibm.Cos(ToNum(f_4669))))));
}, 3, "", true);
ring_4630 = Fn((V _self4609, int _argc4670, V r_4676, V y_4677, V n_4678, V _a4675, V[] _rest4671) => {
return Array_from(NewObj(1).Put("length", n_4678).V, Fn((V _self4609, int _argc4679, V __4685, V i_4686, V _a4683, V _a4684, V[] _rest4680) => {
return Call(RP_4629, V.Undef, r_4676, y_4677, ((V)(((ToNum(i_4686) / ToNum(n_4678)) * ToNum(TAU_9)))));
}, 2, "", true));
}, 3, "", true);
hp_4631 = Arr();
{
V i_4687 = default;
i_4687 = ((V)(0D));
while (true) {
if (!(LeN(i_4687, 16D))) break;
V y_4689 = default;
y_4689 = Add(Get(B_4616, "Y0"), ((V)((((ToNum(Get(B_4616, "Y1")) - ToNum(Get(B_4616, "Y0"))) * ToNum(i_4687)) / 16D))));
Invoke(Call(ring_4630, V.Undef, Call(rT_4621, V.Undef, y_4689), y_4689, ((V)(28D))), "forEach", Fn((V _self4609, int _argc4690, V p_4696, V _a4693, V _a4694, V _a4695, V[] _rest4691) => {
return Invoke(hp_4631, "push", p_4696);
}, 1, "", true));
PostInc(ref i_4687, 1D);
}
}
Set(B_4616, "d", Invoke(D_4617, "hull", hp_4631));
Call(set_4619, V.Undef, Get(B_4616, "sh"), ((V)("d")), Get(B_4616, "d"));
A_4632 = Invoke(Get(SN_43, "h"), "frontArc", D_4617, ((V)(34D)), ((V)(58D)), ((V)(72D)));
if (GtN(Get(A_4632, "length"), 1D)) {
Call(set_4619, V.Undef, Get(B_4616, "bd"), ((V)("d")), Call(polyW_18, V.Undef, Invoke(Invoke(A_4632, "map", Fn((V _self4609, int _argc4704, V f_4710, V _a4707, V _a4708, V _a4709, V[] _rest4705) => {
return Call(RP_4629, V.Undef, Add(Call(rT_4621, V.Undef, ((V)(55.4))), ((V)(0.05))), ((V)(55.4)), f_4710);
}, 1, "", true)), "concat", Invoke(Invoke(Invoke(A_4632, "slice"), "reverse"), "map", Fn((V _self4609, int _argc4697, V f_4703, V _a4700, V _a4701, V _a4702, V[] _rest4698) => {
return Call(RP_4629, V.Undef, Add(Call(rT_4621, V.Undef, ((V)(57.1))), ((V)(0.05))), ((V)(57.1)), f_4703);
}, 1, "", true)))));
} else {
Call(set_4619, V.Undef, Get(B_4616, "bd"), ((V)("d")), ((V)("M0 0")));
}
yS_4633 = ((V)(58.8));
hS_4634 = ((V)(4D));
rS_4635 = Add(Call(rT_4621, V.Undef, Add(yS_4633, ((V)((ToNum(hS_4634) / 2D))))), ((V)(0.08)));
nS_4636 = ((V)(Round(((ToNum(TAU_9) * ToNum(rS_4635)) / 7.4))));
wS_4637 = ((V)((ToNum(TAU_9) / ToNum(nS_4636))));
q_4638 = ((V)(0.82));
SPI_4639 = Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(0D)), ((V)(0D))), Arr(q_4638, ((V)(0D))), Arr(q_4638, ((V)(0.8))), Arr(((V)((ToNum(q_4638) * 0.25))), ((V)(0.8))), Arr(((V)((ToNum(q_4638) * 0.25))), ((V)(0.3))), Arr(((V)((ToNum(q_4638) * 0.62))), ((V)(0.3))), Arr(((V)((ToNum(q_4638) * 0.62))), ((V)(0.55))));
rd_4640 = ((V)(""));
{
V i_4711 = default;
i_4711 = ((V)(0D));
while (true) {
if (!(Lt(i_4711, nS_4636))) break;
V f0_4713 = default;
V fm_4714 = default;
f0_4713 = ((V)(((ToNum(i_4711) - 0.41) * ToNum(wS_4637))));
fm_4714 = Add(f0_4713, ((V)((0.41 * ToNum(wS_4637)))));
if (LtN(Invoke(D_4617, "facing", ((V)((50D + (ToNum(rS_4635) * FdLibm.Sin(ToNum(fm_4714)))))), yS_4633, ((V)((ToNum(rS_4635) * FdLibm.Cos(ToNum(fm_4714))))), ((V)(FdLibm.Sin(ToNum(fm_4714)))), ((V)(0D)), ((V)(FdLibm.Cos(ToNum(fm_4714))))), 0.08)) {
goto _cont4712;
}
rd_4640 = ((V)(string.Concat(ToStr(rd_4640), "M", ToStr(Invoke(Invoke(SPI_4639, "map", Fn((V _self4609, int _argc4715, V _a4717, V _a4718, V _a4719, V _a4720, V[] _rest4716) => {
V f_4726 = default;
V y_4727 = default;
V r_4728 = default;
V u_4723 = default;
V v_4725 = default;
{ V _t4721 = ListOf(_a4717);
{ V _t4722 = GetIdx(_t4721, 0D);
u_4723 = _t4722; }
{ V _t4724 = GetIdx(_t4721, 1D);
v_4725 = _t4724; }
}
f_4726 = Add(f0_4713, ((V)((ToNum(u_4723) * ToNum(wS_4637)))));
y_4727 = Add(yS_4633, ((V)((ToNum(v_4725) * ToNum(hS_4634)))));
r_4728 = Add(Call(rT_4621, V.Undef, y_4727), ((V)(0.08)));
return Call(pt_15, V.Undef, Call(RP_4629, V.Undef, r_4728, y_4727, f_4726));
return default;
}, 1, "", true)), "join", ((V)("L")))))));
_cont4712: ;
PostInc(ref i_4711, 1D);
}
}
Call(set_4619, V.Undef, Get(B_4616, "rm"), ((V)("d")), (rd_4640 is var _t4729 && Truthy(_t4729) ? _t4729 : ((V)("M0 0"))));
Call(set_4619, V.Undef, Get(B_4616, "rimB"), ((V)("d")), Call(polyW_18, V.Undef, Call(ring_4630, V.Undef, ((V)(37D)), YR_4622, ((V)(56D)))));
Call(set_4619, V.Undef, Get(B_4616, "rimI"), ((V)("d")), Call(polyW_18, V.Undef, Call(ring_4630, V.Undef, ((V)(35.2)), Add(YR_4622, ((V)(0.1))), ((V)(56D)))));
Call(set_4619, V.Undef, Get(B_4616, "broth"), ((V)("d")), Call(polyW_18, V.Undef, Call(ring_4630, V.Undef, ((V)(33.6)), YB_4623, ((V)(56D)))));
zOf_4641 = Fn((V _self4609, int _argc4730, V y_4736, V _a4733, V _a4734, V _a4735, V[] _rest4731) => {
return Add(((V)(((ToNum(y_4736) - ToNum(YB_4623)) / ToNum(EL_4620)))), R0_4624);
}, 1, "", true);
Invoke(Get(B_4616, "FL"), "forEach", Fn((V _self4609, int _argc4737, V o_4743, V _a4740, V _a4741, V _a4742, V[] _rest4738) => {
return Call(set_4619, V.Undef, Get(o_4743, "e"), ((V)("d")), Call(decD_26, V.Undef, o_4743, Fn((V _self4609, int _argc4744, V x_4750, V y_4751, V _a4748, V _a4749, V[] _rest4745) => {
return Call(PE_4625, V.Undef, x_4750, YB_4623, Call(zOf_4641, V.Undef, y_4751));
}, 2, "", true)));
}, 1, "", true));
L_4642 = Arr();
Invoke(Get(B_4616, "SP"), "forEach", Fn((V _self4609, int _argc4752, V sp_4758, V _a4755, V _a4756, V _a4757, V[] _rest4753) => {
V A3_4759 = default;
V C_4760 = default;
V cy_4761 = default;
V kx_4762 = default;
V ky_4763 = default;
V sy_4764 = default;
V oy_4765 = default;
A3_4759 = Arr(Add(Get(sp_4758, "ax"), ((V)(((ToNum(Get(D_4617, "ox")) * 0.05) * ToNum(Get(sp_4758, "lag")))))), YB_4623, Call(zOf_4641, V.Undef, Get(sp_4758, "ay")));
C_4760 = Call(PE_4625, V.Undef, GetIdx(A3_4759, 0D), GetIdx(A3_4759, 1D), GetIdx(A3_4759, 2D));
cy_4761 = Call(PE_4625, V.Undef, GetIdx(A3_4759, 0D), Add(GetIdx(A3_4759, 1D), ((V)(1D))), GetIdx(A3_4759, 2D));
kx_4762 = Get(D_4617, "kS");
ky_4763 = ((V)(Hypot((ToNum(GetIdx(cy_4761, 0D)) - ToNum(GetIdx(C_4760, 0D))), (ToNum(GetIdx(cy_4761, 1D)) - ToNum(GetIdx(C_4760, 1D))))));
sy_4764 = ((V)((SEqS(Get(sp_4758, "n"), "heap") ? (1D - (0.1 * ToNum(slurp_4626))) : 1D)));
oy_4765 = ((V)((((-ToNum(Get(D_4617, "oy"))) * 0.08) * ToNum(Get(sp_4758, "lag")))));
Invoke(Get(sp_4758, "D"), "forEach", Fn((V _self4609, int _argc4766, V o_4772, V _a4769, V _a4770, V _a4771, V[] _rest4767) => {
return Call(set_4619, V.Undef, Get(o_4772, "e"), ((V)("d")), Call(decD_26, V.Undef, o_4772, Fn((V _self4609, int _argc4773, V x_4779, V y_4780, V _a4777, V _a4778, V[] _rest4774) => {
return Arr(Add(GetIdx(C_4760, 0D), ((V)(((ToNum(x_4779) - ToNum(Get(sp_4758, "ax"))) * ToNum(kx_4762))))), Add(Add(GetIdx(C_4760, 1D), ((V)((((ToNum(y_4780) - ToNum(Get(sp_4758, "ay"))) * ToNum(ky_4763)) * ToNum(sy_4764))))), oy_4765));
}, 2, "", true)));
}, 1, "", true));
if (Truthy(Get(sp_4758, "sl"))) {
V top_4781 = default;
top_4781 = Arr(GetIdx(C_4760, 0D), ((V)((ToNum(GetIdx(C_4760, 1D)) - ((9D * ToNum(ky_4763)) * ToNum(sy_4764))))));
Invoke(Get(sp_4758, "sl"), "forEach", Fn((V _self4609, int _argc4782, V e_4788, V j_4789, V _a4786, V _a4787, V[] _rest4783) => {
V d_4790 = default;
d_4790 = ((V)(""));
if (GtN(slurp_4626, 0.03)) {
V h_4791 = default;
V x0_4792 = default;
h_4791 = ((V)((13D * ToNum(slurp_4626))));
x0_4792 = Add(GetIdx(top_4781, 0D), ((V)((((ToNum(j_4789) - 1D) * 3.2) * ToNum(kx_4762)))));
{
V i_4793 = default;
i_4793 = ((V)(0D));
while (true) {
if (!(LeN(i_4793, 14D))) break;
V u_4795 = default;
u_4795 = ((V)((ToNum(i_4793) / 14D)));
d_4790 = ((V)(string.Concat(new string[] { ToStr(d_4790), (Truthy(i_4793) ? "L" : "M"), ToStr(Call(r2_11, V.Undef, Add(x0_4792, ((V)(((1.1 * ToNum(kx_4762)) * FdLibm.Sin((((ToNum(u_4795) * 9D) + (ToNum(j_4789) * 2.1)) + (ToNum(ts_4628) * 9D))))))))), " ", ToStr(Call(r2_11, V.Undef, ((V)((ToNum(GetIdx(top_4781, 1D)) - ((ToNum(h_4791) * ToNum(u_4795)) * ToNum(ky_4763))))))) })));
PostInc(ref i_4793, 1D);
}
}
}
Call(set_4619, V.Undef, e_4788, ((V)("d")), (d_4790 is var _t4796 && Truthy(_t4796) ? _t4796 : ((V)("M0 0"))));
Call(set_4619, V.Undef, GetK(Get(sp_4758, "sl2"), j_4789), ((V)("d")), (d_4790 is var _t4797 && Truthy(_t4797) ? _t4797 : ((V)("M0 0"))));
return default;
}, 2, "", true));
}
Invoke(L_4642, "push", NewObj(3).Put("id", Get(sp_4758, "n")).Put("e", Get(sp_4758, "g")).Put("z", Call(Z3_4618, V.Undef, GetIdx(A3_4759, 0D), GetIdx(A3_4759, 1D), GetIdx(A3_4759, 2D))).V);
return default;
}, 1, "", true));
Invoke(Get(B_4616, "NS"), "forEach", Fn((V _self4609, int _argc4798, V sh_4804, V _a4801, V _a4802, V _a4803, V[] _rest4799) => {
V z_4805 = default;
V sw_4806 = default;
z_4805 = Call(zOf_4641, V.Undef, Get(sh_4804, "yb"));
sw_4806 = Call(clamp_12, V.Undef, ((V)(((-ToNum(Get(D_4617, "ox"))) * 0.05))), ((V)((-0.6))), ((V)(0.6)));
Invoke(Get(sh_4804, "D"), "forEach", Fn((V _self4609, int _argc4807, V o_4813, V _a4810, V _a4811, V _a4812, V[] _rest4808) => {
return Call(set_4619, V.Undef, Get(o_4813, "e"), ((V)("d")), Call(decD_26, V.Undef, o_4813, Fn((V _self4609, int _argc4814, V x_4820, V y_4821, V _a4818, V _a4819, V[] _rest4815) => {
V up_4822 = default;
up_4822 = ((V)((Max(0D, (ToNum(Get(sh_4804, "yb")) - ToNum(y_4821))) / 20D)));
return Call(PE_4625, V.Undef, Add(x_4820, ((V)(((ToNum(sw_4806) * ToNum(up_4822)) * 5D)))), ((V)(((ToNum(y_4821) - (ToNum(EL_4620) * (ToNum(z_4805) - ToNum(R0_4624)))) + ((ToNum(up_4822) * ToNum(up_4822)) * 0.3)))), ((V)((ToNum(z_4805) - (ToNum(up_4822) * 1.5)))));
return default;
}, 2, "", true)));
}, 1, "", true));
Invoke(L_4642, "push", NewObj(3).Put("id", Get(sh_4804, "n")).Put("e", Get(sh_4804, "g")).Put("z", ((V)((ToNum(Call(Z3_4618, V.Undef, Get(sh_4804, "cx"), ((V)((ToNum(YB_4623) - 8D))), z_4805)) - 4D)))).V);
return default;
}, 1, "", true));
zt_4643 = Call(zOf_4641, V.Undef, ((V)(46.4)));
ze_4644 = ((V)((ToNum(zt_4643) - 9D)));
lf_4645 = ((V)(Max(0D, ToNum(lid_4627))));
dp_4646 = ((V)(Min(0D, ToNum(lid_4627))));
T_4647 = Arr(Arr(((V)(53.8)), ((V)(39.6))), Arr(((V)(56.8)), ((V)(41.2))));
E_4648 = Arr(Arr(((V)(88.6)), ((V)(13.4))), Arr(((V)(92.4)), ((V)(17.4))));
tips_4649 = Arr();
Invoke(Get(B_4616, "sticks"), "forEach", Fn((V _self4609, int _argc4823, V e_4829, V i_4830, V _a4827, V _a4828, V[] _rest4824) => {
V t3_4831 = default;
V e3_4832 = default;
V a_4833 = default;
V b_4834 = default;
V dx_4835 = default;
V dy_4836 = default;
V l_4837 = default;
V nx_4838 = default;
V ny_4839 = default;
V w0_4840 = default;
V w1_4841 = default;
t3_4831 = Arr(((V)((ToNum(GetIdx(GetK(T_4647, i_4830), 0D)) - (2D * ToNum(lf_4645))))), ((V)((((ToNum(GetIdx(GetK(T_4647, i_4830), 1D)) - (ToNum(EL_4620) * (ToNum(zt_4643) - ToNum(R0_4624)))) - (11D * ToNum(lf_4645))) - (2.5 * ToNum(dp_4646))))), zt_4643);
e3_4832 = Arr(((V)(((ToNum(GetIdx(GetK(E_4648, i_4830), 0D)) - (5D * ToNum(lf_4645))) + (2D * ToNum(dp_4646))))), ((V)((((ToNum(GetIdx(GetK(E_4648, i_4830), 1D)) - (ToNum(EL_4620) * (ToNum(ze_4644) - ToNum(R0_4624)))) - (8D * ToNum(lf_4645))) - (3D * ToNum(dp_4646))))), ze_4644);
a_4833 = Call(PE_4625, V.Undef, GetIdx(t3_4831, 0D), GetIdx(t3_4831, 1D), GetIdx(t3_4831, 2D));
b_4834 = Call(PE_4625, V.Undef, GetIdx(e3_4832, 0D), GetIdx(e3_4832, 1D), GetIdx(e3_4832, 2D));
dx_4835 = ((V)((ToNum(GetIdx(b_4834, 0D)) - ToNum(GetIdx(a_4833, 0D)))));
dy_4836 = ((V)((ToNum(GetIdx(b_4834, 1D)) - ToNum(GetIdx(a_4833, 1D)))));
l_4837 = (((V)(Hypot(ToNum(dx_4835), ToNum(dy_4836)))) is var _t4842 && Truthy(_t4842) ? _t4842 : ((V)(1D)));
nx_4838 = ((V)(((-ToNum(dy_4836)) / ToNum(l_4837))));
ny_4839 = ((V)((ToNum(dx_4835) / ToNum(l_4837))));
w0_4840 = ((V)((0.72 * ToNum(Get(D_4617, "kS")))));
w1_4841 = ((V)((1.15 * ToNum(Get(D_4617, "kS")))));
Invoke(tips_4649, "push", t3_4831);
Call(set_4619, V.Undef, e_4829, ((V)("d")), Call(polyD_16, V.Undef, Arr(Arr(Add(GetIdx(a_4833, 0D), ((V)((ToNum(nx_4838) * ToNum(w0_4840))))), Add(GetIdx(a_4833, 1D), ((V)((ToNum(ny_4839) * ToNum(w0_4840)))))), Arr(Add(GetIdx(b_4834, 0D), ((V)((ToNum(nx_4838) * ToNum(w1_4841))))), Add(GetIdx(b_4834, 1D), ((V)((ToNum(ny_4839) * ToNum(w1_4841)))))), Arr(((V)((ToNum(GetIdx(b_4834, 0D)) - (ToNum(nx_4838) * ToNum(w1_4841))))), ((V)((ToNum(GetIdx(b_4834, 1D)) - (ToNum(ny_4839) * ToNum(w1_4841)))))), Arr(((V)((ToNum(GetIdx(a_4833, 0D)) - (ToNum(nx_4838) * ToNum(w0_4840))))), ((V)((ToNum(GetIdx(a_4833, 1D)) - (ToNum(ny_4839) * ToNum(w0_4840)))))))));
return default;
}, 2, "", true));
hd_4650 = ((V)(""));
if (GtN(lf_4645, 0.04)) {
V m3_4843 = default;
V b3_4844 = default;
m3_4843 = Arr(((V)((ToNum(Add(GetIdx(GetIdx(tips_4649, 0D), 0D), GetIdx(GetIdx(tips_4649, 1D), 0D))) / 2D))), ((V)(((ToNum(Add(GetIdx(GetIdx(tips_4649, 0D), 1D), GetIdx(GetIdx(tips_4649, 1D), 1D))) / 2D) + 0.6))), zt_4643);
b3_4844 = Arr(((V)(48D)), ((V)((ToNum(YB_4623) - 8D))), Add(zt_4643, ((V)(3D))));
{
V j_4845 = default;
j_4845 = ((V)(0D));
while (true) {
if (!(LtN(j_4845, 4D))) break;
V Q_4847 = default;
Q_4847 = Arr();
{
V i_4848 = default;
i_4848 = ((V)(0D));
while (true) {
if (!(LeN(i_4848, 16D))) break;
V u_4850 = default;
V x_4851 = default;
V y_4852 = default;
V z_4853 = default;
u_4850 = ((V)((ToNum(i_4848) / 16D)));
x_4851 = Add(Add(Add(GetIdx(m3_4843, 0D), ((V)(((ToNum(GetIdx(b3_4844, 0D)) - ToNum(GetIdx(m3_4843, 0D))) * ToNum(u_4850))))), ((V)((((ToNum(j_4845) - 1.5) * 1.1) * ToNum(u_4850))))), ((V)(((1.2 * FdLibm.Sin((((ToNum(u_4850) * 10D) + (ToNum(j_4845) * 1.9)) + (ToNum(ts_4628) * 4D)))) * FdLibm.Sin((ToNum(u_4850) * System.Math.PI))))));
y_4852 = Add(GetIdx(m3_4843, 1D), ((V)(((ToNum(GetIdx(b3_4844, 1D)) - ToNum(GetIdx(m3_4843, 1D))) * ToNum(u_4850)))));
z_4853 = Add(GetIdx(m3_4843, 2D), ((V)(((ToNum(GetIdx(b3_4844, 2D)) - ToNum(GetIdx(m3_4843, 2D))) * ToNum(u_4850)))));
Invoke(Q_4847, "push", Call(PE_4625, V.Undef, x_4851, y_4852, z_4853));
PostInc(ref i_4848, 1D);
}
}
hd_4650 = Add(hd_4650, Call(runs_21, V.Undef, Q_4847, Invoke(Q_4847, "map", Fn((V _self4609, int _argc4854, V _a4856, V _a4857, V _a4858, V _a4859, V[] _rest4855) => {
return (true ? V.True : V.False);
}, 0, "", true))));
PostInc(ref j_4845, 1D);
}
}
}
Call(set_4619, V.Undef, Get(B_4616, "hang"), ((V)("d")), (hd_4650 is var _t4860 && Truthy(_t4860) ? _t4860 : ((V)("M0 0"))));
Call(set_4619, V.Undef, Get(B_4616, "hang2"), ((V)("d")), (hd_4650 is var _t4861 && Truthy(_t4861) ? _t4861 : ((V)("M0 0"))));
Invoke(L_4642, "push", NewObj(3).Put("id", ((V)("st"))).Put("e", Get(B_4616, "SG")).Put("z", Add(Call(Z3_4618, V.Undef, ((V)(70D)), ((V)((ToNum(YB_4623) - 12D))), zt_4643), ((V)(1D)))).V);
Invoke(L_4642, "sort", Fn((V _self4609, int _argc4862, V a_4868, V b_4869, V _a4866, V _a4867, V[] _rest4863) => {
return ((V)((ToNum(Get(a_4868, "z")) - ToNum(Get(b_4869, "z")))));
}, 2, "", true));
Invoke(SN_43, "order", Get(B_4616, "TG"), L_4642);
FA_4651 = Invoke(Get(SN_43, "h"), "frontArc", D_4617, ((V)(37D)), YR_4622, ((V)(72D)));
Call(set_4619, V.Undef, Get(B_4616, "rimF"), ((V)("d")), (GtN(Get(FA_4651, "length"), 1D) ? Call(polyW_18, V.Undef, Invoke(Invoke(FA_4651, "map", Fn((V _self4609, int _argc4877, V f_4883, V _a4880, V _a4881, V _a4882, V[] _rest4878) => {
return Call(RP_4629, V.Undef, ((V)(37.2)), YR_4622, f_4883);
}, 1, "", true)), "concat", Invoke(Invoke(Invoke(FA_4651, "slice"), "reverse"), "map", Fn((V _self4609, int _argc4870, V f_4876, V _a4873, V _a4874, V _a4875, V[] _rest4871) => {
return Call(RP_4629, V.Undef, ((V)(33.4)), YB_4623, f_4876);
}, 1, "", true)))) : ((V)("M0 0"))));
Call(set_4619, V.Undef, Get(B_4616, "rimL"), ((V)("d")), (GtN(Get(FA_4651, "length"), 1D) ? Call(runs_21, V.Undef, Invoke(FA_4651, "map", Fn((V _self4609, int _argc4884, V f_4890, V _a4887, V _a4888, V _a4889, V[] _rest4885) => {
return Call(RP_4629, V.Undef, ((V)(36.3)), ((V)((ToNum(YR_4622) - 0.05))), f_4890);
}, 1, "", true)), Invoke(FA_4651, "map", Fn((V _self4609, int _argc4891, V _a4893, V _a4894, V _a4895, V _a4896, V[] _rest4892) => {
return (true ? V.True : V.False);
}, 0, "", true))) : ((V)("M0 0"))));
return default;
}, 2, "draw", false)).V);
Set(MODELS_42, "flossie", NewObj(2).Put("setup", Fn((V _self4897, int _argc4898, V S_4904, V _a4901, V _a4902, V _a4903, V[] _rest4899) => {
V sk_4905 = default;
V C_4906 = default;
V R_4907 = default;
V pf_4908 = default;
V PF_4909 = default;
V BF_4910 = default;
V fP_4911 = default;
V fB_4912 = default;
V st_4913 = default;
V stick_4914 = default;
V sts_4915 = default;
V BG_4916 = default;
V FG_4917 = default;
V sP_4918 = default;
V sB_4919 = default;
V PU_4920 = default;
V n_4921 = default;
V wisp_4922 = default;
V wisp2_4923 = default;
V spk_4924 = default;
if (_self4897.IsNullish) _self4897 = GlobalV;
{ V _t4925 = S_4904;
if (_t4925.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t4925));
{ V _t4926 = Get(_t4925, "sk");
sk_4905 = _t4926; } }
C_4906 = Arr(((V)(50D)), ((V)(51D)));
R_4907 = ((V)(28D));
pf_4908 = Invoke(S_4904, "hide", Fn((V _self4897, int _argc4927, V q_4933, V _a4930, V _a4931, V _a4932, V[] _rest4928) => {
return (((Get(q_4933, "inBody") is var _t4934 && !Truthy(_t4934) ? _t4934 : (SEqS(Get(q_4933, "tag"), "circle") ? V.True : V.False)) is var _t4935 && !Truthy(_t4935) ? _t4935 : (!SEq(q_4933, Get(S_4904, "sk")) ? V.True : V.False)) is var _t4936 && !Truthy(_t4936) ? _t4936 : Invoke(NewRegExp(RX2, "^url", ""), "test", Invoke(S_4904, "f", q_4933)));
}, 1, "", true));
PF_4909 = (Invoke(pf_4908, "find", Fn((V _self4897, int _argc4937, V q_4943, V _a4940, V _a4941, V _a4942, V[] _rest4938) => {
return (Invoke(NewRegExp(RX13, "#p_", ""), "test", Invoke(S_4904, "f", q_4943)) is var _t4944 && Truthy(_t4944) ? _t4944 : Invoke(NewRegExp(RX14, "url\\(#p", ""), "test", Invoke(S_4904, "f", q_4943)));
}, 1, "", true)) is var _t4945 && Truthy(_t4945) ? _t4945 : NewObj(0).V);
BF_4910 = (Invoke(pf_4908, "find", Fn((V _self4897, int _argc4946, V q_4952, V _a4949, V _a4950, V _a4951, V[] _rest4947) => {
return Invoke(NewRegExp(RX15, "url\\(#b", ""), "test", Invoke(S_4904, "f", q_4952));
}, 1, "", true)) is var _t4953 && Truthy(_t4953) ? _t4953 : NewObj(0).V);
fP_4911 = (Truthy(Get(PF_4909, "e")) ? Invoke(S_4904, "f", PF_4909) : ((V)("#ffbede")));
fB_4912 = (Truthy(Get(BF_4910, "e")) ? Invoke(S_4904, "f", BF_4910) : ((V)("#b8e0ff")));
st_4913 = GetIdx(Invoke(S_4904, "hide", Fn((V _self4897, int _argc4954, V q_4960, V _a4957, V _a4958, V _a4959, V[] _rest4955) => {
return (Get(q_4960, "inBody") is var _t4961 && !Truthy(_t4961) ? _t4961 : Invoke(NewRegExp(RX16, "^M46 74", ""), "test", Invoke(S_4904, "d", q_4960)));
}, 1, "", true)), 0D);
Invoke(S_4904, "hide", Fn((V _self4897, int _argc4962, V q_4968, V _a4965, V _a4966, V _a4967, V[] _rest4963) => {
return (Get(q_4968, "inBody") is var _t4969 && !Truthy(_t4969) ? _t4969 : (((SEqS(Invoke(S_4904, "s", q_4968), "#ff8ac4") || SEqS(Invoke(S_4904, "s", q_4968), "#ffffff")) || SEqS(Invoke(S_4904, "s", q_4968), "#b8e0ff")) ? V.True : V.False));
}, 1, "", true));
Invoke(S_4904, "hide", Fn((V _self4897, int _argc4970, V q_4976, V _a4973, V _a4974, V _a4975, V[] _rest4971) => {
return ((((!(Truthy(Get(q_4976, "inBody"))) && SEqS(Get(q_4976, "tag"), "path")) && SEqS(Get(q_4976, "role"), "face")) && LtN(Get(q_4976, "cy"), 40D)) ? V.True : V.False);
}, 1, "", true));
stick_4914 = Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", (Truthy(st_4913) ? Invoke(S_4904, "f", st_4913) : ((V)("#ffffff")))).V, Get(S_4904, "gB"));
sts_4915 = Call(el_14, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ff8ac4"))).Put("stroke-width", ((V)(1.3))).Put("stroke-linecap", ((V)("round"))).V, Get(S_4904, "gB"));
BG_4916 = Call(el_14, V.Undef, ((V)("g")), NewObj(0).V, Get(S_4904, "gB"));
FG_4917 = Invoke(S_4904, "g");
sP_4918 = Invoke(S_4904, "rgrad", ((V)("flp")), Arr(Arr(((V)(0D)), ((V)("#fff3f9"))), Arr(((V)(0.55)), ((V)("#ffcbe5"))), Arr(((V)(1D)), ((V)("#f7afd3")))), NewObj(3).Put("cx", ((V)("42%"))).Put("cy", ((V)("36%"))).Put("r", ((V)("68%"))).V);
sB_4919 = Invoke(S_4904, "rgrad", ((V)("flb")), Arr(Arr(((V)(0D)), ((V)("#f4fbff"))), Arr(((V)(0.55)), ((V)("#cbe8ff"))), Arr(((V)(1D)), ((V)("#a6d2f6")))), NewObj(3).Put("cx", ((V)("42%"))).Put("cy", ((V)("36%"))).Put("r", ((V)("68%"))).V);
PU_4920 = Arr();
n_4921 = ((V)(34D));
{
V i_4977 = default;
i_4977 = ((V)(0D));
while (true) {
if (!(Lt(i_4977, n_4921))) break;
V yy_4979 = default;
V rr_4980 = default;
V a_4981 = default;
V dx_4982 = default;
V dz_4983 = default;
V dy_4984 = default;
yy_4979 = ((V)((1D - ((2D * ToNum(Add(i_4977, ((V)(0.5))))) / ToNum(n_4921)))));
rr_4980 = ((V)(System.Math.Sqrt((1D - (ToNum(yy_4979) * ToNum(yy_4979))))));
a_4981 = ((V)((ToNum(i_4977) * 2.39996)));
dx_4982 = ((V)((ToNum(rr_4980) * FdLibm.Cos(ToNum(a_4981)))));
dz_4983 = ((V)((ToNum(rr_4980) * FdLibm.Sin(ToNum(a_4981)))));
dy_4984 = ((V)((-ToNum(yy_4979))));
if ((GtN(dz_4983, 0.3) && GtN(dy_4984, (-0.55)))) {
goto _cont4978;
}
if (GtN(dy_4984, 0.8)) {
goto _cont4978;
}
Invoke(PU_4920, "push", NewObj(5).Put("d", Arr(dx_4982, dy_4984, dz_4983)).Put("rho", ((V)(((ToNum(R_4907) - 3D) + (ToNum(Call(rnd_22, V.Undef, i_4977)) * 3D))))).Put("r", ((V)((10D + (ToNum(Call(rnd_22, V.Undef, ((V)((ToNum(i_4977) * 3D))))) * 4D))))).Put("c", (((ToNum(i_4977) % 3D) == 1D) ? sB_4919 : sP_4918)).Put("id", ((V)(string.Concat("u", ToStr(i_4977))))).V);
_cont4978: ;
PostInc(ref i_4977, 1D);
}
}
Invoke(PU_4920, "forEach", Fn((V _self4897, int _argc4985, V o_4991, V _a4988, V _a4989, V _a4990, V[] _rest4986) => {
Set(o_4991, "e", Call(el_14, V.Undef, ((V)("path")), NewObj(1).Put("fill", Get(o_4991, "c")).V, BG_4916));
return default;
}, 1, "", true));
wisp_4922 = Invoke(S_4904, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(1.4))).Put("opacity", ((V)(0.55))).Put("stroke-linecap", ((V)("round"))).V);
wisp2_4923 = Invoke(S_4904, "path", NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#b8e0ff"))).Put("stroke-width", ((V)(1.8))).Put("opacity", ((V)(0.85))).Put("stroke-linecap", ((V)("round"))).V);
spk_4924 = Invoke(S_4904, "path", NewObj(2).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.95))).V);
return NewObj(15).Put("C", C_4906).Put("R", R_4907).Put("PU", PU_4920).Put("BG", BG_4916).Put("FG", FG_4917).Put("stick", stick_4914).Put("sts", sts_4915).Put("wisp", wisp_4922).Put("wisp2", wisp2_4923).Put("spk", spk_4924).Put("rx", ((V)(28D))).Put("ya", ((V)(30D))).Put("yb", ((V)(76D))).Put("rT", Fn((V _self4897, int _argc4992, V y_4998, V _a4995, V _a4996, V _a4997, V[] _rest4993) => {
return ((V)(System.Math.Sqrt(Max(0D, ((ToNum(R_4907) * ToNum(R_4907)) - ((ToNum(y_4998) - ToNum(GetIdx(C_4906, 1D))) * (ToNum(y_4998) - ToNum(GetIdx(C_4906, 1D)))))))));
}, 1, "rT", true)).Put("zE", Fn((V _self4897, int _argc4999, V dx_5005, V dy_5006, V _a5003, V _a5004, V[] _rest5000) => {
return ((V)((System.Math.Sqrt(Max(0D, (((ToNum(R_4907) * ToNum(R_4907)) - (ToNum(dx_5005) * ToNum(dx_5005))) - (ToNum(dy_5006) * ToNum(dy_5006))))) + 0.3)));
}, 2, "zE", true)).V;
return default;
}, 1, "setup", false)).Put("draw", Fn((V _self5007, int _argc5008, V B_5014, V D_5015, V _a5012, V _a5013, V[] _rest5009) => {
V P3_5016 = default;
V Z3_5017 = default;
V set_5018 = default;
V C_5019 = default;
V R_5020 = default;
V fl_5021 = default;
V sw_5022 = default;
V ts_5023 = default;
V sp_5024 = default;
V sd_5025 = default;
V L_5026 = default;
V S3_5027 = default;
V wl_5028 = default;
V kd_5029 = default;
if (_self5007.IsNullish) _self5007 = GlobalV;
{ V _t5030 = D_5015;
if (_t5030.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t5030));
{ V _t5031 = Get(_t5030, "P3");
P3_5016 = _t5031; }
{ V _t5032 = Get(_t5030, "Z3");
Z3_5017 = _t5032; }
{ V _t5033 = Get(_t5030, "set");
set_5018 = _t5033; } }
{ V _t5034 = B_5014;
if (_t5034.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t5034));
{ V _t5035 = Get(_t5034, "C");
C_5019 = _t5035; }
{ V _t5036 = Get(_t5034, "R");
R_5020 = _t5036; } }
fl_5021 = Call(clamp_12, V.Undef, Invoke(D_5015, "bv", ((V)("fluff"))), ((V)(0D)), ((V)(1.6)));
sw_5022 = ((V)((ToNum(Invoke(D_5015, "bv", ((V)("swirl")))) * ToNum(TAU_9))));
ts_5023 = Get(D_5015, "ts");
sp_5024 = Arr();
{
V i_5037 = default;
i_5037 = ((V)(0D));
while (true) {
if (!(LeN(i_5037, 8D))) break;
V th_5039 = default;
V cr_5040 = default;
th_5039 = ((V)((((-System.Math.PI) / 2D) + ((System.Math.PI * ToNum(i_5037)) / 8D))));
cr_5040 = ((V)(FdLibm.Cos(ToNum(th_5039))));
{
V k_5041 = default;
k_5041 = ((V)(0D));
while (true) {
if (!(LtN(k_5041, 20D))) break;
V f_5043 = default;
f_5043 = ((V)(((ToNum(k_5041) / 20D) * ToNum(TAU_9))));
Invoke(sp_5024, "push", Call(P3_5016, V.Undef, Add(GetIdx(C_5019, 0D), ((V)(((ToNum(R_5020) * ToNum(cr_5040)) * FdLibm.Sin(ToNum(f_5043)))))), Add(GetIdx(C_5019, 1D), ((V)((ToNum(R_5020) * FdLibm.Sin(ToNum(th_5039)))))), ((V)(((ToNum(R_5020) * ToNum(cr_5040)) * FdLibm.Cos(ToNum(f_5043)))))));
PostInc(ref k_5041, 1D);
}
}
PostInc(ref i_5037, 1D);
}
}
Set(B_5014, "d", Invoke(D_5015, "hull", sp_5024));
Call(set_5018, V.Undef, Get(B_5014, "stick"), ((V)("d")), Invoke(Get(SN_43, "h"), "tubeD", D_5015, Arr(Arr(((V)(50D)), ((V)(76D)), ((V)(0D))), Arr(((V)(50D)), ((V)(97.4)), ((V)(0D)))), Arr(((V)(3.7)), ((V)(3.3)))));
sd_5025 = ((V)(""));
Invoke(Arr(((V)(80D)), ((V)(85.5)), ((V)(91D)), ((V)(96D))), "forEach", Fn((V _self5007, int _argc5044, V y0_5050, V _a5047, V _a5048, V _a5049, V[] _rest5045) => {
V Q_5051 = default;
V ok_5052 = default;
Q_5051 = Arr();
ok_5052 = Arr();
{
V j_5053 = default;
j_5053 = ((V)(0D));
while (true) {
if (!(LeN(j_5053, 8D))) break;
V a_5055 = default;
V y_5056 = default;
V r_5057 = default;
a_5055 = ((V)(((-1.4) + ((ToNum(j_5053) / 8D) * 2.8))));
y_5056 = Add(y0_5050, ((V)((ToNum(j_5053) * 0.42))));
r_5057 = ((V)(3.75));
Invoke(Q_5051, "push", Call(P3_5016, V.Undef, ((V)((50D + (ToNum(r_5057) * FdLibm.Sin(ToNum(a_5055)))))), y_5056, ((V)((ToNum(r_5057) * FdLibm.Cos(ToNum(a_5055)))))));
Invoke(ok_5052, "push", (GtN(Invoke(D_5015, "facing", ((V)((50D + (ToNum(r_5057) * FdLibm.Sin(ToNum(a_5055)))))), y_5056, ((V)((ToNum(r_5057) * FdLibm.Cos(ToNum(a_5055))))), ((V)(FdLibm.Sin(ToNum(a_5055)))), ((V)(0D)), ((V)(FdLibm.Cos(ToNum(a_5055))))), 0D) ? V.True : V.False));
PostInc(ref j_5053, 1D);
}
}
sd_5025 = Add(sd_5025, Call(runs_21, V.Undef, Q_5051, ok_5052));
return default;
}, 1, "", true));
Call(set_5018, V.Undef, Get(B_5014, "sts"), ((V)("d")), (sd_5025 is var _t5058 && Truthy(_t5058) ? _t5058 : ((V)("M0 0"))));
L_5026 = Invoke(Invoke(Get(B_5014, "PU"), "map", Fn((V _self5007, int _argc5067, V o_5073, V i_5074, V _a5071, V _a5072, V[] _rest5068) => {
V ca_5075 = default;
V sa_5076 = default;
V dx_5077 = default;
V dz_5078 = default;
V rho_5079 = default;
V up_5080 = default;
V x_5081 = default;
V y_5082 = default;
V z_5083 = default;
V c_5084 = default;
V zz_5085 = default;
ca_5075 = ((V)(FdLibm.Cos(ToNum(sw_5022))));
sa_5076 = ((V)(FdLibm.Sin(ToNum(sw_5022))));
dx_5077 = ((V)(((ToNum(GetIdx(Get(o_5073, "d"), 0D)) * ToNum(ca_5075)) + (ToNum(GetIdx(Get(o_5073, "d"), 2D)) * ToNum(sa_5076)))));
dz_5078 = ((V)((((-ToNum(GetIdx(Get(o_5073, "d"), 0D))) * ToNum(sa_5076)) + (ToNum(GetIdx(Get(o_5073, "d"), 2D)) * ToNum(ca_5075)))));
rho_5079 = ((V)(((ToNum(Get(o_5073, "rho")) * (1D + (ToNum(fl_5021) * 0.1))) + (FdLibm.Sin(ToNum(Add(((V)((ToNum(ts_5023) * 1.3))), i_5074))) * 0.4))));
up_5080 = Call(clamp_12, V.Undef, ((V)((-ToNum(GetIdx(Get(o_5073, "d"), 1D))))), ((V)(0D)), ((V)(1D)));
x_5081 = Add(Add(GetIdx(C_5019, 0D), ((V)((ToNum(rho_5079) * ToNum(dx_5077))))), ((V)(((ToNum(Get(D_5015, "ox")) * 0.2) * ToNum(up_5080)))));
y_5082 = ((V)((ToNum(Add(GetIdx(C_5019, 1D), ((V)((ToNum(rho_5079) * ToNum(GetIdx(Get(o_5073, "d"), 1D))))))) - ((ToNum(Get(D_5015, "oy")) * 0.25) * ToNum(up_5080)))));
z_5083 = ((V)((ToNum(rho_5079) * ToNum(dz_5078))));
c_5084 = Call(P3_5016, V.Undef, x_5081, y_5082, z_5083);
zz_5085 = Call(Z3_5017, V.Undef, x_5081, y_5082, z_5083);
Call(set_5018, V.Undef, Get(o_5073, "e"), ((V)("d")), Call(circD_19, V.Undef, c_5084, ((V)(((ToNum(Get(o_5073, "r")) * (1D + (ToNum(fl_5021) * 0.22))) * ToNum(Get(D_5015, "kS")))))));
return NewObj(3).Put("id", Get(o_5073, "id")).Put("e", Get(o_5073, "e")).Put("z", zz_5085).V;
return default;
}, 2, "", true)), "sort", Fn((V _self5007, int _argc5059, V a_5065, V b_5066, V _a5063, V _a5064, V[] _rest5060) => {
return ((V)((ToNum(Get(a_5065, "z")) - ToNum(Get(b_5066, "z")))));
}, 2, "", true));
Invoke(L_5026, "forEach", Fn((V _self5007, int _argc5086, V l_5092, V _a5089, V _a5090, V _a5091, V[] _rest5087) => {
V tg_5093 = default;
tg_5093 = (GtN(Get(l_5092, "z"), 6D) ? Get(B_5014, "FG") : Get(B_5014, "BG"));
if (!SEq(Get(Get(l_5092, "e"), "parentNode"), tg_5093)) {
Invoke(tg_5093, "appendChild", Get(l_5092, "e"));
}
return default;
}, 1, "", true));
Invoke(SN_43, "order", Get(B_5014, "BG"), Invoke(L_5026, "filter", Fn((V _self5007, int _argc5094, V l_5100, V _a5097, V _a5098, V _a5099, V[] _rest5095) => {
return (LeN(Get(l_5100, "z"), 6D) ? V.True : V.False);
}, 1, "", true)));
Invoke(SN_43, "order", Get(B_5014, "FG"), Invoke(L_5026, "filter", Fn((V _self5007, int _argc5101, V l_5107, V _a5104, V _a5105, V _a5106, V[] _rest5102) => {
return (GtN(Get(l_5107, "z"), 6D) ? V.True : V.False);
}, 1, "", true)));
S3_5027 = Fn((V _self5007, int _argc5108, V x_5114, V y_5115, V _a5112, V _a5113, V[] _rest5109) => {
V dz_5116 = default;
dz_5116 = ((V)(System.Math.Sqrt(Max(0D, (((ToNum(R_5020) * ToNum(R_5020)) - ((ToNum(x_5114) - ToNum(GetIdx(C_5019, 0D))) * (ToNum(x_5114) - ToNum(GetIdx(C_5019, 0D))))) - ((ToNum(y_5115) - ToNum(GetIdx(C_5019, 1D))) * (ToNum(y_5115) - ToNum(GetIdx(C_5019, 1D)))))))));
return Arr(Call(P3_5016, V.Undef, x_5114, y_5115, Add(dz_5116, ((V)(0.2)))), (GtN(Invoke(D_5015, "facing", x_5114, y_5115, dz_5116, ((V)((ToNum(x_5114) - ToNum(GetIdx(C_5019, 0D))))), ((V)((ToNum(y_5115) - ToNum(GetIdx(C_5019, 1D))))), dz_5116), 0.5) ? V.True : V.False));
return default;
}, 2, "", true);
wl_5028 = Fn((V _self5007, int _argc5117, V pts_5123, V _a5120, V _a5121, V _a5122, V[] _rest5118) => {
V Q_5124 = default;
Q_5124 = Invoke(pts_5123, "map", Fn((V _self5007, int _argc5125, V p_5131, V _a5128, V _a5129, V _a5130, V[] _rest5126) => {
return Call(S3_5027, V.Undef, GetIdx(p_5131, 0D), GetIdx(p_5131, 1D));
}, 1, "", true));
return Call(runs_21, V.Undef, Invoke(Q_5124, "map", Fn((V _self5007, int _argc5132, V q_5138, V _a5135, V _a5136, V _a5137, V[] _rest5133) => {
return GetIdx(q_5138, 0D);
}, 1, "", true)), Invoke(Q_5124, "map", Fn((V _self5007, int _argc5139, V q_5145, V _a5142, V _a5143, V _a5144, V[] _rest5140) => {
return GetIdx(q_5145, 1D);
}, 1, "", true)));
return default;
}, 1, "", true);
Call(set_5018, V.Undef, Get(B_5014, "wisp"), ((V)("d")), (Call(wl_5028, V.Undef, Arr(Arr(((V)(33D)), ((V)(40D))), Arr(((V)(38D)), ((V)(36D))), Arr(((V)(44D)), ((V)(34.5))), Arr(((V)(50D)), ((V)(35.5))), Arr(((V)(56D)), ((V)(37.5))), Arr(((V)(61D)), ((V)(37D))), Arr(((V)(66D)), ((V)(34D))))) is var _t5146 && Truthy(_t5146) ? _t5146 : ((V)("M0 0"))));
Call(set_5018, V.Undef, Get(B_5014, "wisp2"), ((V)("d")), (Call(wl_5028, V.Undef, Arr(Arr(((V)(28D)), ((V)(70D))), Arr(((V)(33D)), ((V)(73D))), Arr(((V)(38D)), ((V)(74.5))), Arr(((V)(43D)), ((V)(73D))), Arr(((V)(47D)), ((V)(71D))))) is var _t5147 && Truthy(_t5147) ? _t5147 : ((V)("M0 0"))));
kd_5029 = ((V)(""));
Invoke(Arr(Arr(((V)(24D)), ((V)(20D)), ((V)(0D))), Arr(((V)(78D)), ((V)(16D)), ((V)(1.7))), Arr(((V)(88D)), ((V)(36D)), ((V)(3.1)))), "forEach", Fn((V _self5007, int _argc5148, V _a5150, V _a5151, V _a5152, V _a5153, V[] _rest5149) => {
V a_5161 = default;
V s_5162 = default;
V p_5163 = default;
V x_5156 = default;
V y_5158 = default;
V ph_5160 = default;
{ V _t5154 = ListOf(_a5150);
{ V _t5155 = GetIdx(_t5154, 0D);
x_5156 = _t5155; }
{ V _t5157 = GetIdx(_t5154, 1D);
y_5158 = _t5157; }
{ V _t5159 = GetIdx(_t5154, 2D);
ph_5160 = _t5159; }
}
a_5161 = ((V)(Max(0D, FdLibm.Sin(ToNum(Add(((V)((ToNum(ts_5023) * 2.1))), ph_5160))))));
s_5162 = ((V)(((1.2 + (1.4 * ToNum(a_5161))) * ToNum(Get(D_5015, "kS")))));
p_5163 = Call(P3_5016, V.Undef, x_5156, y_5158, ((V)(0D)));
if (GtN(a_5161, 0.05)) {
kd_5029 = ((V)(string.Concat(new string[] { ToStr(kd_5029), "M", ToStr(Call(r2_11, V.Undef, GetIdx(p_5163, 0D))), " ", ToStr(Call(r2_11, V.Undef, ((V)((ToNum(GetIdx(p_5163, 1D)) - ToNum(s_5162)))))), "L", ToStr(Call(r2_11, V.Undef, Add(GetIdx(p_5163, 0D), ((V)((ToNum(s_5162) * 0.3)))))), " ", ToStr(Call(r2_11, V.Undef, ((V)((ToNum(GetIdx(p_5163, 1D)) - (ToNum(s_5162) * 0.3)))))), "L", ToStr(Call(r2_11, V.Undef, Add(GetIdx(p_5163, 0D), s_5162))), " ", ToStr(Call(r2_11, V.Undef, GetIdx(p_5163, 1D))), "L", ToStr(Call(r2_11, V.Undef, Add(GetIdx(p_5163, 0D), ((V)((ToNum(s_5162) * 0.3)))))), " ", ToStr(Call(r2_11, V.Undef, Add(GetIdx(p_5163, 1D), ((V)((ToNum(s_5162) * 0.3)))))), "L", ToStr(Call(r2_11, V.Undef, GetIdx(p_5163, 0D))), " ", ToStr(Call(r2_11, V.Undef, Add(GetIdx(p_5163, 1D), s_5162))), "L", ToStr(Call(r2_11, V.Undef, ((V)((ToNum(GetIdx(p_5163, 0D)) - (ToNum(s_5162) * 0.3)))))), " ", ToStr(Call(r2_11, V.Undef, Add(GetIdx(p_5163, 1D), ((V)((ToNum(s_5162) * 0.3)))))), "L", ToStr(Call(r2_11, V.Undef, ((V)((ToNum(GetIdx(p_5163, 0D)) - ToNum(s_5162)))))), " ", ToStr(Call(r2_11, V.Undef, GetIdx(p_5163, 1D))), "L", ToStr(Call(r2_11, V.Undef, ((V)((ToNum(GetIdx(p_5163, 0D)) - (ToNum(s_5162) * 0.3)))))), " ", ToStr(Call(r2_11, V.Undef, ((V)((ToNum(GetIdx(p_5163, 1D)) - (ToNum(s_5162) * 0.3)))))), "Z" })));
}
return default;
}, 1, "", true));
Call(set_5018, V.Undef, Get(B_5014, "spk"), ((V)("d")), (kd_5029 is var _t5164 && Truthy(_t5164) ? _t5164 : ((V)("M0 0"))));
return default;
}, 2, "draw", false)).V);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
