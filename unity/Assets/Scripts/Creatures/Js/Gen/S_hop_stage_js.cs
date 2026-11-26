// hop-stage.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_hop_stage_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("url\\(#([^)]+)\\)", "");
        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V G_8, V _a5, V _a6, V _a7, V[] _rest3) => {
V d_9 = default;
V old_10 = default;
V b_11 = default;
V hid_12 = default;
V W_13 = default;
if (_self1.IsNullish) _self1 = GlobalV;
d_9 = Get(G_8, "document");
old_10 = Invoke(d_9, "getElementById", ((V)("board")));
if (Truthy(old_10)) {
Invoke(old_10, "removeAttribute", ((V)("id")));
}
b_11 = Invoke(d_9, "createElement", ((V)("div")));
Invoke(b_11, "setAttribute", ((V)("id")), ((V)("board")));
Invoke(Get(d_9, "body"), "appendChild", b_11);
hid_12 = Get(G_8, "__cssHidden");
Set(G_8, "__cssHidden", Fn((V _self14, int _argc15, V el_21, V _a18, V _a19, V _a20, V[] _rest16) => {
V p_22 = default;
if (_self14.IsNullish) _self14 = GlobalV;
if ((SEqS(Get(el_21, "localName"), "ellipse") && SEqS(Invoke(el_21, "getAttribute", ((V)("fill"))), "#6a1b9a"))) {
{
p_22 = Get(el_21, "parentNode");
while (true) {
if (!(Truthy(p_22))) break;
if (SEq(p_22, b_11)) {
return (true ? V.True : V.False);
}
p_22 = Get(p_22, "parentNode");
}
}
}
return (Truthy(hid_12) ? Call(hid_12, V.Undef, el_21) : (false ? V.True : V.False));
return default;
}, 1, "", false));
W_13 = Object_create(G_8);
Set(W_13, "innerWidth", ((V)(400D)));
Set(W_13, "innerHeight", ((V)(300D)));
Set(W_13, "__rigPause", Fn((V _self24, int _argc25, V _a27, V _a28, V _a29, V _a30, V[] _rest26) => {
if (_self24.IsNullish) _self24 = GlobalV;

return default;
}, 0, "", false));
Set((Get(G_8, "__stages") is var _t31 && Truthy(_t31) ? _t31 : Set(G_8, "__stages", NewObj(0).V)), "hop", NewObj(2).Put("win", W_13).Put("board", b_11).V);
Call(Fn((V _self32, int _argc33, V window_39, V _a36, V _a37, V _a38, V[] _rest34) => {
if (_self32.IsNullish) _self32 = GlobalV;
Call(Fn((V _self40, int _argc41, V _a43, V _a44, V _a45, V _a46, V[] _rest42) => {
V post_47 = default;
V board_48 = default;
V clamp_49 = default;
V lerp_50 = default;
V SM_51 = default;
V kv_52 = default;
V parab_53 = default;
V FAB_54 = default;
V fabric_55 = default;
V isGrain_56 = default;
V bakeGrain_57 = default;
V addStates_58 = default;
V C_59 = default;
V origin_60 = default;
V castTag_61 = default;
V mount_62 = default;
V unmount_63 = default;
V measure_64 = default;
V ready_65 = default;
double SH_O_66 = 0;
V draw_67 = default;
V start_68 = default;
V stopMoves_69 = default;
V toU_70 = default;
double CROUCH_71 = 0;
double SPRING_72 = 0;
double END_SQ_73 = 0;
double END_ARMS_74 = 0;
V leg_75 = default;
V land_76 = default;
V faceTo_77 = default;
V DIRS_78 = default;
V api_79 = default;
V hearts_80 = default;
V burst_81 = default;
V running_82 = default;
V frame_83 = default;
V kick_84 = default;
V castRaw_85 = default;
V boot_86 = default;
if (_self40.IsNullish) _self40 = GlobalV;
fabric_55 = Fn((V _self87, int _argc88, V _a90, V _a91, V _a92, V _a93, V[] _rest89) => {
if (_self87.IsNullish) _self87 = GlobalV;
if (!SEq(FAB_54, V.Null)) {
return FAB_54;
}
FAB_54 = ((V)(""));
try {
double S_94 = 0;
V cv_95 = default;
V x_96 = default;
V im_97 = default;
double sd_98 = 0;
V rnd_99 = default;
V oct_100 = default;
V o1_101 = default;
V o2_102 = default;
double B_103 = 0;
V cb_104 = default;
V xb_105 = default;
S_94 = 128D;
cv_95 = Invoke(G("document"), "createElement", ((V)("canvas")));
Set(cv_95, "width", Set(cv_95, "height", ((V)(S_94))));
x_96 = Invoke(cv_95, "getContext", ((V)("2d")));
im_97 = Invoke(x_96, "createImageData", ((V)(S_94)), ((V)(S_94)));
sd_98 = 7D;
rnd_99 = Fn((V _arrowThis112, int _argc106, V _a108, V _a109, V _a110, V _a111, V[] _rest107) => {
return ((V)(((sd_98 = ((sd_98 * 16807D) % 2147483647D)) / 2147483647D)));
}, 0, "", true);
oct_100 = Fn((V _arrowThis120, int _argc113, V n_119, V _a116, V _a117, V _a118, V[] _rest114) => {
V g_121 = default;
double c_122 = 0;
V sm_123 = default;
g_121 = Arr();
{
double i_124 = 0;
i_124 = 0D;
while (true) {
if (!((i_124 < (ToNum(n_119) * ToNum(n_119))))) break;
Invoke(g_121, "push", Call(rnd_99, V.Undef));
i_124++;
}
}
c_122 = (S_94 / ToNum(n_119));
sm_123 = Fn((V _arrowThis133, int _argc126, V t_132, V _a129, V _a130, V _a131, V[] _rest127) => {
return ((V)(((ToNum(t_132) * ToNum(t_132)) * (3D - (2D * ToNum(t_132))))));
}, 1, "", true);
return Fn((V _arrowThis142, int _argc134, V px_140, V py_141, V _a138, V _a139, V[] _rest135) => {
double gx_143 = 0;
double gy_144 = 0;
double x0_145 = 0;
double y0_146 = 0;
V fx_147 = default;
V fy_148 = default;
V a_149 = default;
V t_150 = default;
V b_151 = default;
gx_143 = (ToNum(px_140) / c_122);
gy_144 = (ToNum(py_141) / c_122);
x0_145 = System.Math.Floor(gx_143);
y0_146 = System.Math.Floor(gy_144);
fx_147 = Call(sm_123, V.Undef, ((V)((gx_143 - x0_145))));
fy_148 = Call(sm_123, V.Undef, ((V)((gy_144 - y0_146))));
a_149 = Fn((V _arrowThis160, int _argc152, V i_158, V j_159, V _a156, V _a157, V[] _rest153) => {
return GetIdx(g_121, (((ToNum(Add(((V)((ToNum(j_159) % ToNum(n_119)))), n_119)) % ToNum(n_119)) * ToNum(n_119)) + (ToNum(Add(((V)((ToNum(i_158) % ToNum(n_119)))), n_119)) % ToNum(n_119))));
}, 2, "", true);
t_150 = Add(Call(a_149, V.Undef, ((V)(x0_145)), ((V)(y0_146))), ((V)(((ToNum(Call(a_149, V.Undef, ((V)((x0_145 + 1D))), ((V)(y0_146)))) - ToNum(Call(a_149, V.Undef, ((V)(x0_145)), ((V)(y0_146))))) * ToNum(fx_147)))));
b_151 = Add(Call(a_149, V.Undef, ((V)(x0_145)), ((V)((y0_146 + 1D)))), ((V)(((ToNum(Call(a_149, V.Undef, ((V)((x0_145 + 1D))), ((V)((y0_146 + 1D))))) - ToNum(Call(a_149, V.Undef, ((V)(x0_145)), ((V)((y0_146 + 1D)))))) * ToNum(fx_147)))));
return Add(t_150, ((V)(((ToNum(b_151) - ToNum(t_150)) * ToNum(fy_148)))));
return default;
}, 2, "", true);
return default;
}, 1, "", true);
o1_101 = Call(oct_100, V.Undef, ((V)(32D)));
o2_102 = Call(oct_100, V.Undef, ((V)(64D)));
{
double y_161 = 0;
y_161 = 0D;
while (true) {
if (!((y_161 < S_94))) break;
{
double X_163 = 0;
X_163 = 0D;
while (true) {
if (!((X_163 < S_94))) break;
double v_165 = 0;
double k_166 = 0;
v_165 = (ToNum(Add(Call(o1_101, V.Undef, ((V)(X_163)), ((V)(y_161))), Call(o2_102, V.Undef, ((V)(X_163)), ((V)(y_161))))) / 2D);
k_166 = (((y_161 * S_94) + X_163) * 4D);
SetIdx(Get(im_97, "data"), (k_166 + 3D), ((V)(Round(((0.2 * 255D) * v_165)))));
X_163++;
}
}
y_161++;
}
}
Invoke(x_96, "putImageData", im_97, ((V)(0D)), ((V)(0D)));
B_103 = 1024D;
cb_104 = Invoke(G("document"), "createElement", ((V)("canvas")));
Set(cb_104, "width", Set(cb_104, "height", ((V)(B_103))));
xb_105 = Invoke(cb_104, "getContext", ((V)("2d")));
Set(xb_105, "fillStyle", Invoke(xb_105, "createPattern", cv_95, ((V)("repeat"))));
Invoke(xb_105, "fillRect", ((V)(0D)), ((V)(0D)), ((V)(B_103)), ((V)(B_103)));
FAB_54 = Invoke(cb_104, "toDataURL", ((V)("image/png")));
} catch (System.Exception _ex167) {
V e_168 = default;
e_168 = Caught(_ex167);
FAB_54 = ((V)(""));
}
return FAB_54;
return default;
}, 0, "fabric", false);
bakeGrain_57 = Fn((V _self169, int _argc170, V svg_176, V _a173, V _a174, V _a175, V[] _rest171) => {
V els_177 = default;
V id_178 = default;
V f_179 = default;
V t_180 = default;
V im_181 = default;
V cm_182 = default;
V top_183 = default;
if (_self169.IsNullish) _self169 = GlobalV;
if ((!(Truthy(svg_176)) || !(Truthy(Call(fabric_55, V.Undef))))) {
return default;
}
els_177 = Invoke(new ArrBuilder().Spread(Invoke(svg_176, "querySelectorAll", ((V)("[filter]")))).V, "filter", Fn((V _arrowThis191, int _argc184, V e_190, V _a187, V _a188, V _a189, V[] _rest185) => {
V id_192 = default;
id_192 = GetIdx((Invoke(Invoke(e_190, "getAttribute", ((V)("filter"))), "match", NewRegExp(RX0, "url\\(#([^)]+)\\)", "")) is var _t193 && Truthy(_t193) ? _t193 : Arr()), 1D);
return (id_192 is var _t194 && !Truthy(_t194) ? _t194 : Call(isGrain_56, V.Undef, Invoke(svg_176, "getElementById", id_192)));
return default;
}, 1, "", true));
if (!(Truthy(Get(els_177, "length")))) {
return default;
}
id_178 = GetIdx(Invoke(Invoke(GetIdx(els_177, 0D), "getAttribute", ((V)("filter"))), "match", NewRegExp(RX0, "url\\(#([^)]+)\\)", "")), 1D);
f_179 = Invoke(svg_176, "getElementById", id_178);
t_180 = Invoke(f_179, "querySelector", ((V)("feTurbulence")));
im_181 = Invoke(G("document"), "createElementNS", ((V)("http://www.w3.org/2000/svg")), ((V)("feImage")));
Invoke(Arr(Arr(((V)("href")), FAB_54), Arr(((V)("x")), ((V)((-30D)))), Arr(((V)("y")), ((V)((-30D)))), Arr(((V)("width")), ((V)(160D))), Arr(((V)("height")), ((V)(160D))), Arr(((V)("preserveAspectRatio")), ((V)("none")))), "forEach", Fn((V _arrowThis206, int _argc195, V _a197, V _a198, V _a199, V _a200, V[] _rest196) => {
V a_203 = default;
V v_205 = default;
{ V _t201 = ListOf(_a197);
{ V _t202 = GetIdx(_t201, 0D);
a_203 = _t202; }
{ V _t204 = GetIdx(_t201, 1D);
v_205 = _t204; }
}
return Invoke(im_181, "setAttribute", a_203, v_205);
}, 1, "", true));
cm_182 = Get(t_180, "nextElementSibling");
Invoke(t_180, "replaceWith", im_181);
if (Truthy((cm_182 is var _t207 && !Truthy(_t207) ? _t207 : (SEqS(Get(cm_182, "tagName"), "feColorMatrix") ? V.True : V.False)))) {
Invoke(cm_182, "remove");
}
top_183 = Get(GetIdx(els_177, 0D), "parentNode");
while ((!SEq(top_183, svg_176) && !(Truthy(Invoke(els_177, "every", Fn((V _arrowThis215, int _argc208, V e_214, V _a211, V _a212, V _a213, V[] _rest209) => {
return Invoke(top_183, "contains", e_214);
}, 1, "", true)))))) {
top_183 = Get(top_183, "parentNode");
}
if (SEq(top_183, svg_176)) {
Invoke(els_177, "forEach", Fn((V _arrowThis223, int _argc216, V e_222, V _a219, V _a220, V _a221, V[] _rest217) => {
return Invoke(e_222, "setAttribute", ((V)("filter")), ((V)(JsStrBuf.Begin().S("url(#").V(id_178).S(")").End())));
}, 1, "", true));
return default;
}
Invoke(els_177, "forEach", Fn((V _arrowThis231, int _argc224, V e_230, V _a227, V _a228, V _a229, V[] _rest225) => {
return Invoke(e_230, "removeAttribute", ((V)("filter")));
}, 1, "", true));
Invoke(top_183, "setAttribute", ((V)("filter")), ((V)(JsStrBuf.Begin().S("url(#").V(id_178).S(")").End())));
return default;
}, 1, "bakeGrain", false);
addStates_58 = Fn((V _self232, int _argc233, V _a235, V _a236, V _a237, V _a238, V[] _rest234) => {
V AR_239 = default;
V ER_240 = default;
if (_self232.IsNullish) _self232 = GlobalV;
AR_239 = Fn((V _arrowThis248, int _argc241, V K_247, V _a244, V _a245, V _a246, V[] _rest242) => {
return NewObj(2).Put("armL", K_247).Put("armR", K_247).V;
}, 1, "", true);
ER_240 = Fn((V _arrowThis256, int _argc249, V K_255, V _a252, V _a253, V _a254, V[] _rest250) => {
return NewObj(2).Put("earL", K_255).Put("earR", K_255).V;
}, 1, "", true);
Object_assign(Get(Get(window_39, "RiveRig"), "PRE"), NewObj(5).Put("hopSweat", NewObj(8).Put("n", ((V)(1D))).Put("sp", ((V)(0D))).Put("vy", ((V)(6D))).Put("g", ((V)(34D))).Put("life", ((V)(950D))).Put("r", Arr(((V)(2.6)), ((V)(3D)))).Put("col", Arr(((V)("#8fd3ff")))).Put("kind", ((V)("drop"))).V).Put("hopDust", NewObj(8).Put("n", ((V)(7D))).Put("sp", ((V)(26D))).Put("vy", ((V)((-5D)))).Put("g", ((V)(10D))).Put("life", ((V)(620D))).Put("r", Arr(((V)(2D)), ((V)(3.6)))).Put("col", Arr(((V)("#ffffff")), ((V)("#fdf3ff")), ((V)("#efe4ff")))).Put("kind", ((V)("dot"))).V).Put("hopHeart", NewObj(7).Put("n", ((V)(1D))).Put("sp", ((V)(9D))).Put("vy", ((V)((-16D)))).Put("g", ((V)((-3D)))).Put("life", ((V)(1200D))).Put("r", Arr(((V)(1.6)), ((V)(2D)))).Put("kind", ((V)("heart"))).V).Put("hopSpark", NewObj(8).Put("n", ((V)(6D))).Put("sp", ((V)(30D))).Put("vy", ((V)((-10D)))).Put("g", ((V)(0D))).Put("life", ((V)(700D))).Put("r", Arr(((V)(3.2)), ((V)(5D)))).Put("col", Arr(((V)("#fff3a0")), ((V)("#ffffff")), ((V)("#ffd23a")))).Put("kind", ((V)("star"))).V).Put("hopPop", NewObj(7).Put("n", ((V)(6D))).Put("sp", ((V)(30D))).Put("vy", ((V)((-6D)))).Put("g", ((V)((-4D)))).Put("life", ((V)(560D))).Put("r", Arr(((V)(2.2)), ((V)(3.8)))).Put("kind", ((V)("bubble"))).V).V);
Invoke(Get(window_39, "RiveRig"), "add", NewObj(6).Put("hopSad", NewObj(3).Put("loop", ((V)(2400D))).Put("blend", ((V)(220D))).Put("k", NewObj(10).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.14))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)((-0.55)))))).Put("ly", Arr(Arr(((V)(0D)), ((V)(0.55))))).Put("frown", Arr(Arr(((V)(0D)), ((V)(1D))))).Put("teary", Arr(Arr(((V)(0D)), ((V)(0.7))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))))).Spread(Call(ER_240, V.Undef, Arr(Arr(((V)(0D)), ((V)((-18D))))))).Spread(Call(AR_239, V.Undef, Arr(Arr(((V)(0D)), ((V)((-14D))))))).Put("lean", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(600D)), ((V)((-2.4))), ((V)("s"))), Arr(((V)(1200D)), ((V)(0D)), ((V)("s"))), Arr(((V)(1800D)), ((V)(2.4)), ((V)("s"))), Arr(((V)(2400D)), ((V)(0D)), ((V)("s"))))).Put("tilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(600D)), ((V)((-3D))), ((V)("s"))), Arr(((V)(1200D)), ((V)(0D)), ((V)("s"))), Arr(((V)(1800D)), ((V)(3D)), ((V)("s"))), Arr(((V)(2400D)), ((V)(0D)), ((V)("s"))))).V).V).Put("hopSadLook", NewObj(4).Put("dur", ((V)(850D))).Put("blend", ((V)(160D))).Put("next", ((V)("hopSad"))).Put("k", NewObj(8).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)(0.14)), ((V)("o"))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)((-0.45))), ((V)("io"))))).Put("frown", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(1D)), ((V)("io"))))).Put("teary", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(400D)), ((V)(0.5)), ((V)("io"))))).Spread(Call(ER_240, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)((-18D))), ((V)("o")))))).Spread(Call(AR_239, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)((-14D))), ((V)("o")))))).Put("turn", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0D))), Arr(((V)(330D)), ((V)((-0.95))), ((V)("io"))), Arr(((V)(480D)), ((V)((-0.95)))), Arr(((V)(610D)), ((V)(0.95)), ((V)("io"))), Arr(((V)(760D)), ((V)(0.95))), Arr(((V)(850D)), ((V)(0D)), ((V)("io"))))).Put("lx", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0D))), Arr(((V)(300D)), ((V)((-1D))), ((V)("o"))), Arr(((V)(480D)), ((V)((-1D)))), Arr(((V)(580D)), ((V)(1D)), ((V)("io"))), Arr(((V)(760D)), ((V)(1D))), Arr(((V)(850D)), ((V)(0D)), ((V)("io"))))).V).V).Put("hopPerk", NewObj(3).Put("dur", ((V)(320D))).Put("blend", ((V)(90D))).Put("k", NewObj(4).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.08))), Arr(((V)(90D)), ((V)((-0.16))), ((V)("o"))), Arr(((V)(200D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(320D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(90D)), ((V)(3D)), ((V)("o"))), Arr(((V)(200D)), ((V)(0D)), ((V)("i"))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(320D)), ((V)(0D))))).Spread(Call(ER_240, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(90D)), ((V)(10D)), ((V)("o"))), Arr(((V)(320D)), ((V)(0D)), ((V)("io")))))).V).V).Put("hopGiggle", NewObj(3).Put("dur", ((V)(620D))).Put("blend", ((V)(90D))).Put("k", NewObj(6).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(80D)), ((V)(0.18)), ((V)("o"))), Arr(((V)(180D)), ((V)((-0.12))), ((V)("o"))), Arr(((V)(300D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(420D)), ((V)(0D)), ((V)("io"))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(80D)), ((V)(1D)), ((V)("o"))), Arr(((V)(520D)), ((V)(1D))), Arr(((V)(620D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(80D)), ((V)(1D))))).Put("blush", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(1D))), Arr(((V)(520D)), ((V)(1D))), Arr(((V)(620D)), ((V)(0D))))).Put("tilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)((-6D))), ((V)("io"))), Arr(((V)(260D)), ((V)(6D)), ((V)("io"))), Arr(((V)(400D)), ((V)((-3D))), ((V)("io"))), Arr(((V)(520D)), ((V)(0D)), ((V)("io"))))).Spread(Call(AR_239, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)(30D)), ((V)("o"))), Arr(((V)(400D)), ((V)(24D))), Arr(((V)(620D)), ((V)(0D)), ((V)("io")))))).V).V).Put("hopOops", NewObj(3).Put("dur", ((V)(560D))).Put("blend", ((V)(60D))).Put("k", NewObj(3).Put("wide", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(60D)), ((V)(1D)), ((V)("o"))), Arr(((V)(380D)), ((V)(1D))), Arr(((V)(560D)), ((V)(0D)), ((V)("io"))))).Put("frown", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(60D)), ((V)(0.8)), ((V)("o"))), Arr(((V)(400D)), ((V)(0.8))), Arr(((V)(560D)), ((V)(0D)), ((V)("io"))))).Spread(Call(ER_240, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(60D)), ((V)((-16D))), ((V)("o"))), Arr(((V)(420D)), ((V)((-10D)))), Arr(((V)(560D)), ((V)(0D)), ((V)("io")))))).V).V).Put("hopJoy", NewObj(3).Put("dur", ((V)(1300D))).Put("blend", ((V)(80D))).Put("k", NewObj(5).Put("hap", Arr(Arr(((V)(0D)), ((V)(1D))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(1D))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0.6))))).Put("blush", Arr(Arr(((V)(0D)), ((V)(0.6))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(18D)), ((V)("io"))), Arr(((V)(400D)), ((V)((-18D))), ((V)("io"))), Arr(((V)(600D)), ((V)(18D)), ((V)("io"))), Arr(((V)(800D)), ((V)((-18D))), ((V)("io"))), Arr(((V)(1000D)), ((V)(12D)), ((V)("io"))), Arr(((V)(1300D)), ((V)(0D)), ((V)("io"))))).V).V).V);
return default;
}, 0, "addStates", false);
mount_62 = Fn((V _self257, int _argc258, V c_264, V _a261, V _a262, V _a263, V[] _rest259) => {
if (_self257.IsNullish) _self257 = GlobalV;
Set(c_264, "sh", Invoke(G("document"), "createElement", ((V)("div"))));
Set(Get(c_264, "sh"), "className", ((V)("sh")));
Set(Get(Get(c_264, "sh"), "style"), "opacity", ((V)("0")));
Invoke(board_48, "appendChild", Get(c_264, "sh"));
Set(c_264, "el", Invoke(G("document"), "createElement", ((V)("div"))));
Set(Get(c_264, "el"), "className", ((V)("ch")));
Set(c_264, "inner", Invoke(G("document"), "createElement", ((V)("div"))));
Invoke(Get(c_264, "el"), "appendChild", Get(c_264, "inner"));
Invoke(board_48, "appendChild", Get(c_264, "el"));
Set(Get(Get(c_264, "el"), "style"), "opacity", ((V)("0")));
if (Truthy(Get(window_39, "__rgI"))) {
DeleteK(Get(window_39, "__rgI"), Get(c_264, "key"));
}
Set(c_264, "ctrl", Invoke(Get(window_39, "RiveRig"), "mount", Get(c_264, "inner"), Get(c_264, "key"), NewObj(1).Put("fidgets", (false ? V.True : V.False)).V));
Set(c_264, "I", Get(Get(c_264, "ctrl"), "_I"));
Set(c_264, "t0", Invoke(G("performance"), "now"));
return default;
}, 1, "mount", false);
unmount_63 = Fn((V _self265, int _argc266, V c_272, V _a269, V _a270, V _a271, V[] _rest267) => {
if (_self265.IsNullish) _self265 = GlobalV;
if (Truthy(Get(c_272, "ctrl"))) {
Invoke(Get(c_272, "ctrl"), "destroy");
}
if (Truthy(Get(c_272, "el"))) {
Invoke(Get(c_272, "el"), "remove");
}
if (Truthy(Get(c_272, "sh"))) {
Invoke(Get(c_272, "sh"), "remove");
}
Call(G("clearInterval"), V.Undef, Get(c_272, "sweat"));
return default;
}, 1, "unmount", false);
measure_64 = Fn((V _self273, int _argc274, V c_280, V _a277, V _a278, V _a279, V[] _rest275) => {
V svg_281 = default;
V sh_282 = default;
V b_283 = default;
if (_self273.IsNullish) _self273 = GlobalV;
svg_281 = Invoke(Get(c_280, "inner"), "querySelector", ((V)("svg")));
if (!(Truthy(svg_281))) {
return V.Null;
}
sh_282 = new ArrBuilder().Spread(Invoke(svg_281, "querySelectorAll", ((V)("ellipse[fill=\"#6a1b9a\"]")))).V;
Invoke(sh_282, "forEach", Fn((V _arrowThis291, int _argc284, V e_290, V _a287, V _a288, V _a289, V[] _rest285) => {
return Set(Get(e_290, "style"), "display", ((V)("none")));
}, 1, "", true));
b_283 = V.Null;
try {
b_283 = Invoke(svg_281, "getBBox");
} catch (System.Exception _ex292) {
V e_293 = default;
e_293 = Caught(_ex292);

}
Invoke(sh_282, "forEach", Fn((V _arrowThis301, int _argc294, V e_300, V _a297, V _a298, V _a299, V[] _rest295) => {
return Set(Get(e_300, "style"), "display", ((V)("")));
}, 1, "", true));
if ((!(Truthy(b_283)) || !(GtN(Get(b_283, "width"), 1D)))) {
return V.Null;
}
return NewObj(4).Put("cx", Add(Get(b_283, "x"), ((V)((ToNum(Get(b_283, "width")) / 2D))))).Put("gy", Add(Get(b_283, "y"), Get(b_283, "height"))).Put("bw", Get(b_283, "width")).Put("top", Get(b_283, "y")).V;
return default;
}, 1, "measure", false);
ready_65 = Fn((V _self302, int _argc303, V c_309, V _a306, V _a307, V _a308, V[] _rest304) => {
V bb_310 = default;
if (_self302.IsNullish) _self302 = GlobalV;
if (Truthy(Get(c_309, "bb"))) {
return (true ? V.True : V.False);
}
if (!(Truthy(Get(c_309, "I")))) {
return (false ? V.True : V.False);
}
if (Truthy((Get(Get(c_309, "I"), "generic") is var _t311 && !Truthy(_t311) ? _t311 : (!(Truthy(Get(Get(c_309, "I"), "ready"))) ? V.True : V.False)))) {
return (false ? V.True : V.False);
}
Invoke(Get(c_309, "ctrl"), "_pose", ((V)("idle")), ((V)(0D)));
bb_310 = Call(measure_64, V.Undef, c_309);
if (!(Truthy(bb_310))) {
return (false ? V.True : V.False);
}
Set(c_309, "bb", bb_310);
Call(bakeGrain_57, V.Undef, Invoke(Get(c_309, "inner"), "querySelector", ((V)("svg"))));
return (true ? V.True : V.False);
return default;
}, 1, "ready", false);
draw_67 = Fn((V _self312, int _argc313, V c_319, V now_320, V _a317, V _a318, V[] _rest314) => {
V m_321 = default;
double s_322 = 0;
double k_323 = 0;
V x_324 = default;
V y_325 = default;
double up_326 = 0;
V z_327 = default;
double o_328 = 0;
double bw_329 = 0;
double hi_330 = 0;
double w_331 = 0;
double h_332 = 0;
double f_333 = 0;
if (_self312.IsNullish) _self312 = GlobalV;
if ((!(Truthy(Get(c_319, "bb"))) || !(Truthy(Get(c_319, "el"))))) {
return default;
}
m_321 = (Get(c_319, "cur") is var _t334 && Truthy(_t334) ? _t334 : NewObj(0).V);
s_322 = ((ToNum(Get(c_319, "s")) * ToNum((Get(m_321, "k").IsNullish ? ((V)(1D)) : Get(m_321, "k")))) * ToNum((Get(c_319, "k").IsNullish ? ((V)(1D)) : Get(c_319, "k"))));
k_323 = ((ToNum(Get(c_319, "W")) * s_322) / ToNum(Get(Get(c_319, "bb"), "bw")));
x_324 = Add(Get(c_319, "x"), (Get(m_321, "dx") is var _t335 && Truthy(_t335) ? _t335 : ((V)(0D))));
y_325 = Add(Get(c_319, "y"), (Get(m_321, "dy") is var _t336 && Truthy(_t336) ? _t336 : ((V)(0D))));
up_326 = Max(0D, ToNum((Get(m_321, "up") is var _t337 && Truthy(_t337) ? _t337 : ((V)(0D)))));
Set(Get(Get(c_319, "el"), "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").V(Invoke(((V)((ToNum(x_324) - (ToNum(Get(Get(c_319, "bb"), "cx")) * k_323)))), "toFixed", ((V)(2D)))).S("px,").V(Invoke(((V)(((ToNum(y_325) - up_326) - (ToNum(Get(Get(c_319, "bb"), "gy")) * k_323)))), "toFixed", ((V)(2D)))).S("px) scale(").V(Invoke(((V)(k_323)), "toFixed", ((V)(4D)))).S(")").End())));
z_327 = (!Get(m_321, "z").IsNullish ? Get(m_321, "z") : Get(c_319, "z"));
Set(Get(Get(c_319, "el"), "style"), "zIndex", ((V)(ToStrS(z_327))));
o_328 = (ToNum(Get(c_319, "o")) * ToNum((Get(m_321, "o").IsNullish ? ((V)(1D)) : Get(m_321, "o"))));
Set(Get(Get(c_319, "el"), "style"), "opacity", ((V)(ToStrS(((V)((Round((o_328 * 100D)) / 100D)))))));
Set(c_319, "kNow", ((V)(k_323)));
bw_329 = (ToNum(Get(c_319, "W")) * s_322);
hi_330 = (up_326 / bw_329);
w_331 = (((bw_329 * 0.94) * (1D + (ToNum(Call(clamp_49, V.Undef, (Get(c_319, "sqNow") is var _t338 && Truthy(_t338) ? _t338 : ((V)(0D))), ((V)((-0.45))), ((V)(0.4)))) * 0.45))) * (1D - ToNum(Call(clamp_49, V.Undef, ((V)((hi_330 / 1.2))), ((V)(0D)), ((V)(0.6))))));
h_332 = (w_331 * 0.2);
f_333 = ((1D - ToNum(Call(clamp_49, V.Undef, ((V)((hi_330 / 0.9))), ((V)(0D)), ((V)(1D))))) * ToNum((Get(m_321, "sh").IsNullish ? ((V)(1D)) : Get(m_321, "sh"))));
Set(Get(Get(c_319, "sh"), "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").V(Invoke(((V)((ToNum(x_324) - (w_331 / 2D)))), "toFixed", ((V)(2D)))).S("px,").V(Invoke(((V)((ToNum(y_325) - (h_332 * 0.55)))), "toFixed", ((V)(2D)))).S("px) scale(").V(Invoke(((V)((w_331 / 100D))), "toFixed", ((V)(4D)))).S(",").V(Invoke(((V)((h_332 / 100D))), "toFixed", ((V)(4D)))).S(")").End())));
Set(Get(Get(c_319, "sh"), "style"), "zIndex", ((V)(ToStrS(((V)((ToNum(z_327) - 1D)))))));
Set(Get(Get(c_319, "sh"), "style"), "opacity", ((V)(ToStrS(((V)((Round((((o_328 * f_333) * SH_O_66) * 100D)) / 100D)))))));
return default;
}, 2, "draw", false);
start_68 = Fn((V _self339, int _argc340, V c_346, V mv_347, V _a344, V _a345, V[] _rest341) => {
if (_self339.IsNullish) _self339 = GlobalV;
Set(mv_347, "t0", Add(Invoke(G("performance"), "now"), (Get(mv_347, "delay") is var _t348 && Truthy(_t348) ? _t348 : ((V)(0D)))));
Invoke(Get(c_346, "moves"), "push", mv_347);
Call(kick_84, V.Undef);
return mv_347;
return default;
}, 2, "start", false);
stopMoves_69 = Fn((V _self349, int _argc350, V c_356, V kind_357, V _a354, V _a355, V[] _rest351) => {
if (_self349.IsNullish) _self349 = GlobalV;
Set(c_356, "moves", Invoke(Get(c_356, "moves"), "filter", Fn((V _arrowThis365, int _argc358, V m_364, V _a361, V _a362, V _a363, V[] _rest359) => {
return ((Truthy(kind_357) ? !SEq(Get(m_364, "kind"), kind_357) : false) ? V.True : V.False);
}, 1, "", true)));
return default;
}, 2, "stopMoves", false);
leg_75 = Fn((V _self366, int _argc367, V c_373, V L_374, V from_375, V dir_376, V[] _rest368) => {
V D_378 = default;
double hold_379 = 0;
V H_380 = default;
V dx_381 = default;
V dy_382 = default;
V ease_383 = default;
V crouch_384 = default;
V arms_385 = default;
V lean_386 = default;
V onDone_377 = default;
if (_self366.IsNullish) _self366 = GlobalV;
onDone_377 = (_argc367 > 4 ? _rest368[0] : V.Undef);
D_378 = Get(L_374, "ms");
hold_379 = (Truthy(Get(L_374, "boing")) ? SPRING_72 : CROUCH_71);
H_380 = Get(L_374, "h");
dx_381 = (Truthy(GetK(DIRS_78, dir_376)) ? GetIdx(GetK(DIRS_78, dir_376), 0D) : ((V)(0D)));
dy_382 = (Truthy(GetK(DIRS_78, dir_376)) ? GetIdx(GetK(DIRS_78, dir_376), 1D) : ((V)(0D)));
ease_383 = Fn((V _arrowThis394, int _argc387, V u_393, V _a390, V _a391, V _a392, V[] _rest388) => {
return (LeN(u_393, (hold_379 * 0.8)) ? ((V)(0D)) : Call(SM_51, V.Undef, ((V)(((ToNum(u_393) - (hold_379 * 0.8)) / (1D - (hold_379 * 0.8)))))));
}, 1, "", true);
crouch_384 = (Truthy(Get(L_374, "boing")) ? Arr(Arr(((V)(0D)), ((V)(END_SQ_73))), Arr(((V)((ToNum(D_378) * 0.1))), ((V)(0.42)), ((V)("o"))), Arr(((V)((ToNum(D_378) * SPRING_72))), ((V)(0.36)), ((V)("io"))), Arr(((V)((ToNum(D_378) * (SPRING_72 + 0.14)))), ((V)((-0.38))), ((V)("o"))), Arr(((V)((ToNum(D_378) * 0.48))), ((V)((-0.16))), ((V)("io"))), Arr(((V)((ToNum(D_378) * 0.62))), ((V)(0.1)), ((V)("io"))), Arr(((V)((ToNum(D_378) * 0.76))), ((V)((-0.1))), ((V)("io"))), Arr(((V)((ToNum(D_378) * 0.9))), ((V)(0.04)), ((V)("io"))), Arr(D_378, ((V)(END_SQ_73)), ((V)("io")))) : Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_378) * 0.22))), ((V)(0.24)), ((V)("io"))), Arr(((V)((ToNum(D_378) * 0.4))), ((V)((-0.28))), ((V)("o"))), Arr(((V)((ToNum(D_378) * 0.58))), ((V)((-0.08))), ((V)("io"))), Arr(((V)((ToNum(D_378) * 0.86))), ((V)((-0.18))), ((V)("io"))), Arr(D_378, ((V)(END_SQ_73)), ((V)("io")))));
arms_385 = (Truthy(Get(L_374, "boing")) ? Arr(Arr(((V)(0D)), ((V)(END_ARMS_74))), Arr(((V)((ToNum(D_378) * 0.1))), ((V)((-6D))), ((V)("io"))), Arr(((V)((ToNum(D_378) * 0.3))), ((V)(46D)), ((V)("o"))), Arr(((V)((ToNum(D_378) * 0.8))), ((V)(30D)), ((V)("io"))), Arr(D_378, ((V)(END_ARMS_74)), ((V)("io")))) : Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_378) * 0.22))), ((V)((-14D))), ((V)("io"))), Arr(((V)((ToNum(D_378) * 0.4))), ((V)(40D)), ((V)("o"))), Arr(((V)((ToNum(D_378) * 0.75))), ((V)(28D)), ((V)("io"))), Arr(D_378, ((V)(END_ARMS_74)), ((V)("io")))));
lean_386 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_378) * 0.22))), ((V)((-0.4))), ((V)("io"))), Arr(((V)((ToNum(D_378) * 0.4))), ((V)(1D)), ((V)("o"))), Arr(((V)((ToNum(D_378) * 0.7))), ((V)(0.55)), ((V)("io"))), Arr(D_378, ((V)(0D)), ((V)("io"))));
return Call(start_68, V.Undef, c_373, NewObj(4).Put("kind", ((V)("hop"))).Put("dur", D_378).Put("run", Fn((V _self395, int _argc396, V c_402, V t_403, V _a400, V _a401, V[] _rest397) => {
V u_404 = default;
V e_405 = default;
double air_406 = 0;
V ln_407 = default;
if (_self395.IsNullish) _self395 = GlobalV;
u_404 = Call(clamp_49, V.Undef, ((V)((ToNum(t_403) / ToNum(D_378)))), ((V)(0D)), ((V)(1D)));
e_405 = Call(ease_383, V.Undef, u_404);
Set(c_402, "x", Call(lerp_50, V.Undef, Get(from_375, "x"), Get(L_374, "x"), e_405));
Set(c_402, "y", Call(lerp_50, V.Undef, Get(from_375, "y"), Get(L_374, "y"), e_405));
Set(c_402, "s", Call(lerp_50, V.Undef, Get(from_375, "s"), Get(L_374, "s"), e_405));
air_406 = (ToNum(Call(parab_53, V.Undef, ((V)(((ToNum(u_404) - hold_379) / (1D - hold_379)))))) * (Truthy(Get(L_374, "boing")) ? 1.2 : 1D));
ln_407 = Call(kv_52, V.Undef, lean_386, t_403);
return NewObj(3).Put("z", ((V)(Max(ToNum(Get(from_375, "z")), ToNum(Get(L_374, "z")))))).Put("up", ((V)((ToNum(H_380) * air_406)))).Put("ext", NewObj(7).Put("sq", Call(kv_52, V.Undef, crouch_384, t_403)).Put("armL", Call(kv_52, V.Undef, arms_385, t_403)).Put("armR", Call(kv_52, V.Undef, arms_385, t_403)).Put("tilt", ((V)(((ToNum(ln_407) * 11D) * ToNum(dx_381))))).Put("lean", ((V)(((ToNum(ln_407) * 3D) * ToNum(dx_381))))).Put("pitch", ((V)((((-ToNum(ln_407)) * 0.55) * ToNum(dy_382))))).Put("ly", ((V)(((ToNum(ln_407) * 0.7) * ToNum(dy_382))))).V).V;
return default;
}, 2, "run", false)).Put("done", onDone_377).V);
return default;
}, 5, "leg", false);
land_76 = Fn((V _self408, int _argc409, V c_415, V _a412, V _a413, V _a414, V[] _rest410) => {
double D_420 = 0;
V sq_421 = default;
V arms_422 = default;
V sq0_417 = default;
V arms0_419 = default;
if (_self408.IsNullish) _self408 = GlobalV;
{ V _t416 = _a412; if (_t416.IsUndef) _t416 = ((V)(END_SQ_73));
sq0_417 = _t416; }
{ V _t418 = _a413; if (_t418.IsUndef) _t418 = ((V)(END_ARMS_74));
arms0_419 = _t418; }
D_420 = 420D;
sq_421 = Arr(Arr(((V)(0D)), sq0_417), Arr(((V)(55D)), ((V)(0.3)), ((V)("o"))), Arr(((V)(160D)), ((V)((-0.13))), ((V)("io"))), Arr(((V)(260D)), ((V)(0.06)), ((V)("io"))), Arr(((V)(350D)), ((V)((-0.02))), ((V)("io"))), Arr(((V)(D_420)), ((V)(0D)), ((V)("io"))));
arms_422 = Arr(Arr(((V)(0D)), arms0_419), Arr(((V)(70D)), ((V)((-18D))), ((V)("o"))), Arr(((V)(210D)), ((V)(10D)), ((V)("io"))), Arr(((V)(D_420)), ((V)(0D)), ((V)("io"))));
Call(stopMoves_69, V.Undef, c_415, ((V)("land")));
if (Truthy((Get(c_415, "I") is var _t423 && !Truthy(_t423) ? _t423 : Get(c_415, "bb")))) {
Call(burst_81, V.Undef, c_415, ((V)("hopDust")), ((V)("feet")));
}
Call(start_68, V.Undef, c_415, NewObj(3).Put("kind", ((V)("land"))).Put("dur", ((V)(D_420))).Put("run", Fn((V _self424, int _argc425, V c_431, V t_432, V _a429, V _a430, V[] _rest426) => {
if (_self424.IsNullish) _self424 = GlobalV;
return NewObj(1).Put("ext", NewObj(3).Put("sq", Call(kv_52, V.Undef, sq_421, t_432)).Put("armL", Call(kv_52, V.Undef, arms_422, t_432)).Put("armR", Call(kv_52, V.Undef, arms_422, t_432)).V).V;
return default;
}, 2, "run", false)).V);
return default;
}, 3, "land", false);
faceTo_77 = Fn((V _self433, int _argc434, V c_440, V dir_441, V _a438, V _a439, V[] _rest435) => {
V to_442 = default;
V from_443 = default;
if (_self433.IsNullish) _self433 = GlobalV;
to_442 = (SEqN(dir_441, 1D) ? ((V)(0.55)) : (SEqN(dir_441, 3D) ? ((V)((-0.55))) : ((SEqN(dir_441, 0D) || SEqN(dir_441, 2D)) ? ((V)(0D)) : Get(c_440, "face"))));
if (SEq(to_442, Get(c_440, "face"))) {
return default;
}
from_443 = Get(c_440, "face");
Set(c_440, "face", to_442);
Call(stopMoves_69, V.Undef, c_440, ((V)("face")));
Call(start_68, V.Undef, c_440, NewObj(4).Put("kind", ((V)("face"))).Put("dur", ((V)(140D))).Put("keep", (true ? V.True : V.False)).Put("run", Fn((V _self444, int _argc445, V c_451, V t_452, V _a449, V _a450, V[] _rest446) => {
if (_self444.IsNullish) _self444 = GlobalV;
Set(c_451, "faceNow", Call(lerp_50, V.Undef, from_443, to_442, Call(SM_51, V.Undef, ((V)((ToNum(t_452) / 140D))))));
return NewObj(0).V;
return default;
}, 2, "run", false)).V);
return default;
}, 2, "faceTo", false);
hearts_80 = Fn((V _self453, int _argc454, V c_460, V n_461, V every_462, V _a459, V[] _rest455) => {
if (_self453.IsNullish) _self453 = GlobalV;
{
double i_463 = 0;
i_463 = 0D;
while (true) {
if (!(Lt(((V)(i_463)), n_461))) break;
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis479, int _argc473, V _a475, V _a476, V _a477, V _a478, V[] _rest474) => {
if (Truthy((Get(c_460, "I") is var _t480 && !Truthy(_t480) ? _t480 : Get(c_460, "bb")))) {
Call(burst_81, V.Undef, c_460, ((V)("hopHeart")), ((V)("head")), ((V)(1D)));
}
return default;
}, 0, "", true), ((V)((i_463 * ToNum(every_462)))));
i_463++;
}
}
return default;
}, 3, "hearts", false);
burst_81 = Fn((V _self481, int _argc482, V c_488, V kind_489, V where_490, V n_491, V[] _rest483) => {
V b_492 = default;
V W_493 = default;
V p_494 = default;
if (_self481.IsNullish) _self481 = GlobalV;
b_492 = Get(c_488, "bb");
W_493 = (Get(Get(c_488, "I"), "W") is var _t495 && Truthy(_t495) ? _t495 : NewObj(0).V);
p_494 = (SEqS(where_490, "feet") ? Arr(Get(b_492, "cx"), ((V)((ToNum(Get(b_492, "gy")) - 2D)))) : (SEqS(where_490, "head") ? Arr(Get(b_492, "cx"), Add(Get(b_492, "top"), ((V)(4D)))) : (SEqS(where_490, "temple") ? Arr(Add(Get(b_492, "cx"), ((V)((ToNum(Get(b_492, "bw")) * 0.34)))), Add(Get(b_492, "top"), ((V)((ToNum(Get(b_492, "bw")) * 0.2))))) : (GetK(W_493, where_490) is var _t496 && Truthy(_t496) ? _t496 : Arr(((V)(50D)), ((V)(50D)))))));
try {
V e_497 = default;
e_497 = Get(Get(window_39, "RiveRig"), "emit");
if (Truthy(e_497)) {
Call(e_497, V.Undef, Get(c_488, "I"), kind_489, p_494, n_491);
}
} catch (System.Exception _ex498) {
V x_499 = default;
x_499 = Caught(_ex498);

}
return default;
}, 4, "burst", false);
frame_83 = Fn((V _self500, int _argc501, V _a503, V _a504, V _a505, V _a506, V[] _rest502) => {
V now_507 = default;
V busy_508 = default;
V allReady_509 = default;
if (_self500.IsNullish) _self500 = GlobalV;
now_507 = Invoke(G("performance"), "now");
busy_508 = (false ? V.True : V.False);
allReady_509 = (true ? V.True : V.False);
{
foreach (V _k510 in new JsIter(Invoke(C_59, "values"))) {
V c_511 = default;
c_511 = _k510;
V ext_512 = default;
V cur_513 = default;
V list_514 = default;
V kept_515 = default;
if (!(Truthy(Call(ready_65, V.Undef, c_511)))) {
if (((((ToNum(now_507) - ToNum(Get(c_511, "t0"))) > 9000D) && !castTag_61.IsNullish) && !SEq(Get(api_79, "_sent"), castTag_61))) {
Set(api_79, "_sent", castTag_61);
Call(post_47, V.Undef, NewObj(4).Put("type", ((V)("cast"))).Put("tag", castTag_61).Put("ok", (false ? V.True : V.False)).Put("key", Get(c_511, "key")).V);
}
allReady_509 = (false ? V.True : V.False);
busy_508 = (((ToNum(now_507) - ToNum(Get(c_511, "t0"))) < 9000D) ? V.True : V.False);
continue;
}
ext_512 = NewObj(0).V;
cur_513 = NewObj(2).Put("dx", ((V)(0D))).Put("dy", ((V)(0D))).V;
list_514 = Get(c_511, "moves");
Set(c_511, "moves", Arr());
kept_515 = Invoke(list_514, "filter", Fn((V _arrowThis523, int _argc516, V m_522, V _a519, V _a520, V _a521, V[] _rest517) => {
double t_524 = 0;
V r_525 = default;
t_524 = (ToNum(now_507) - ToNum(Get(m_522, "t0")));
if ((t_524 < 0D)) {
if (Truthy(Get(m_522, "before"))) {
cur_513 = Object_assign(cur_513, Get(m_522, "before"));
}
return (true ? V.True : V.False);
}
if (Ge(((V)(t_524)), Get(m_522, "dur"))) {
if (Truthy(Get(m_522, "run"))) {
Invoke(m_522, "run", c_511, Get(m_522, "dur"));
}
if (Truthy(Get(m_522, "done"))) {
Invoke(m_522, "done");
}
return (false ? V.True : V.False);
}
r_525 = (Invoke(m_522, "run", c_511, ((V)(t_524))) is var _t526 && Truthy(_t526) ? _t526 : NewObj(0).V);
if (Truthy(Get(r_525, "dx"))) {
OpSet(cur_513, "dx", 0, Get(r_525, "dx"));
}
if (Truthy(Get(r_525, "dy"))) {
OpSet(cur_513, "dy", 0, Get(r_525, "dy"));
}
if (Truthy(Get(r_525, "up"))) {
Set(cur_513, "up", Add((Get(cur_513, "up") is var _t527 && Truthy(_t527) ? _t527 : ((V)(0D))), Get(r_525, "up")));
}
if (!Get(r_525, "sh").IsNullish) {
Set(cur_513, "sh", ((V)((ToNum((Get(cur_513, "sh").IsNullish ? ((V)(1D)) : Get(cur_513, "sh"))) * ToNum(Get(r_525, "sh"))))));
}
if (!Get(r_525, "k").IsNullish) {
Set(cur_513, "k", ((V)((ToNum((Get(cur_513, "k").IsNullish ? ((V)(1D)) : Get(cur_513, "k"))) * ToNum(Get(r_525, "k"))))));
}
if (!Get(r_525, "o").IsNullish) {
Set(cur_513, "o", ((V)((ToNum((Get(cur_513, "o").IsNullish ? ((V)(1D)) : Get(cur_513, "o"))) * ToNum(Get(r_525, "o"))))));
}
if (!Get(r_525, "z").IsNullish) {
Set(cur_513, "z", Get(r_525, "z"));
}
if (Truthy(Get(r_525, "ext"))) {
{
foreach (V _k528 in ForInKeys(Get(r_525, "ext"))) {
V k_529 = default;
k_529 = _k528;
SetK(ext_512, k_529, Add((GetK(ext_512, k_529) is var _t530 && Truthy(_t530) ? _t530 : ((V)(0D))), GetK(Get(r_525, "ext"), k_529)));
}
}
}
return (true ? V.True : V.False);
return default;
}, 1, "", true));
Set(c_511, "moves", Invoke(kept_515, "concat", Get(c_511, "moves")));
if (Truthy(Get(Get(c_511, "moves"), "length"))) {
busy_508 = (true ? V.True : V.False);
}
Set(ext_512, "turn", Add((Get(ext_512, "turn") is var _t531 && Truthy(_t531) ? _t531 : ((V)(0D))), Get(c_511, "faceNow")));
if (!Get(ext_512, "sq").IsNullish) {
Set(ext_512, "sq", Call(clamp_49, V.Undef, Get(ext_512, "sq"), ((V)((-0.45))), ((V)(0.4))));
}
Set(c_511, "sqNow", (Get(ext_512, "sq") is var _t532 && Truthy(_t532) ? _t532 : ((V)(0D))));
if (Truthy(Get(cur_513, "up"))) {
V u_533 = default;
u_533 = Call(toU_70, V.Undef, c_511, Get(cur_513, "up"));
Set(ext_512, "lift", Add((Get(ext_512, "lift") is var _t534 && Truthy(_t534) ? _t534 : ((V)(0D))), u_533));
Set(ext_512, "sk", Add((Get(ext_512, "sk") is var _t535 && Truthy(_t535) ? _t535 : ((V)(0D))), u_533));
}
Set(c_511, "cur", cur_513);
if (Truthy(Get(c_511, "ctrl"))) {
Invoke(Get(c_511, "ctrl"), "ext", ext_512);
}
Call(draw_67, V.Undef, c_511, now_507);
}
}
if (Truthy((((allReady_509 is var _t536 && !Truthy(_t536) ? _t536 : (!castTag_61.IsNullish ? V.True : V.False)) is var _t537 && !Truthy(_t537) ? _t537 : Get(C_59, "size")) is var _t538 && !Truthy(_t538) ? _t538 : (!(Truthy(Get(api_79, "_sent"))) ? V.True : V.False)))) {
Set(api_79, "_sent", castTag_61);
Call(post_47, V.Undef, NewObj(3).Put("type", ((V)("cast"))).Put("tag", castTag_61).Put("ok", (true ? V.True : V.False)).V);
}
if (Truthy(busy_508)) {
Call(G("requestAnimationFrame"), V.Undef, frame_83);
} else {
running_82 = (false ? V.True : V.False);
}
return default;
}, 0, "frame", false);
kick_84 = Fn((V _self539, int _argc540, V _a542, V _a543, V _a544, V _a545, V[] _rest541) => {
if (_self539.IsNullish) _self539 = GlobalV;
if (!(Truthy(running_82))) {
running_82 = (true ? V.True : V.False);
Call(G("requestAnimationFrame"), V.Undef, frame_83);
}
return default;
}, 0, "kick", false);
post_47 = Fn((V _arrowThis553, int _argc546, V m_552, V _a549, V _a550, V _a551, V[] _rest547) => {
V s_554 = default;
s_554 = Invoke(G("JSON"), "stringify", m_552);
if (Truthy(Get(window_39, "ReactNativeWebView"))) {
Invoke(Get(window_39, "ReactNativeWebView"), "postMessage", s_554);
} else {
Invoke(Set(window_39, "__hopOut", (Get(window_39, "__hopOut") is var _t555 && Truthy(_t555) ? _t555 : Arr())), "push", m_552);
}
return default;
}, 1, "", true);
board_48 = Invoke(G("document"), "getElementById", ((V)("board")));
clamp_49 = Fn((V _arrowThis565, int _argc556, V v_562, V a_563, V b_564, V _a561, V[] _rest557) => {
return ((V)(Max(ToNum(a_563), Min(ToNum(b_564), ToNum(v_562)))));
}, 3, "", true);
lerp_50 = Fn((V _arrowThis575, int _argc566, V a_572, V b_573, V t_574, V _a571, V[] _rest567) => {
return Add(a_572, ((V)(((ToNum(b_573) - ToNum(a_572)) * ToNum(t_574)))));
}, 3, "", true);
SM_51 = Fn((V _arrowThis583, int _argc576, V x_582, V _a579, V _a580, V _a581, V[] _rest577) => {
x_582 = Call(clamp_49, V.Undef, x_582, ((V)(0D)), ((V)(1D)));
return ((V)(((ToNum(x_582) * ToNum(x_582)) * (3D - (2D * ToNum(x_582))))));
return default;
}, 1, "", true);
kv_52 = V.Null;
parab_53 = Fn((V _arrowThis591, int _argc584, V u_590, V _a587, V _a588, V _a589, V[] _rest585) => {
return ((V)(((LeN(u_590, 0D) || GeN(u_590, 1D)) ? 0D : ((4D * ToNum(u_590)) * (1D - ToNum(u_590))))));
}, 1, "", true);
FAB_54 = V.Null;
isGrain_56 = Fn((V _arrowThis599, int _argc592, V f_598, V _a595, V _a596, V _a597, V[] _rest593) => {
return (((f_598 is var _t600 && !Truthy(_t600) ? _t600 : Invoke(f_598, "querySelector", ((V)("feTurbulence")))) is var _t601 && !Truthy(_t601) ? _t601 : (!(Truthy(Invoke(f_598, "querySelector", ((V)("feDisplacementMap"))))) ? V.True : V.False)) is var _t602 && !Truthy(_t602) ? _t602 : Invoke(f_598, "querySelector", ((V)("feBlend[mode=\"multiply\"]"))));
}, 1, "", true);
C_59 = New(G("Map"));
origin_60 = Arr(((V)(0D)), ((V)(0D)));
castTag_61 = V.Null;
SH_O_66 = 0.6;
toU_70 = Fn((V _arrowThis611, int _argc603, V c_609, V dp_610, V _a607, V _a608, V[] _rest604) => {
return ((V)((Truthy(Get(c_609, "kNow")) ? (ToNum(dp_610) / ToNum(Get(c_609, "kNow"))) : 0D)));
}, 2, "", true);
CROUCH_71 = 0.24;
SPRING_72 = 0.18;
END_SQ_73 = (-0.1);
END_ARMS_74 = 18D;
DIRS_78 = Arr(Arr(((V)(0D)), ((V)((-1D)))), Arr(((V)(1D)), ((V)(0D))), Arr(((V)(0D)), ((V)(1D))), Arr(((V)((-1D))), ((V)(0D))));
api_79 = NewObj(14).Put("origin", Fn((V _self612, int _argc613, V x_619, V y_620, V _a617, V _a618, V[] _rest614) => {
if (_self612.IsNullish) _self612 = GlobalV;
origin_60 = Arr(x_619, y_620);
return default;
}, 2, "origin", false)).Put("cast", Fn((V _self621, int _argc622, V list_628, V tag_629, V _a626, V _a627, V[] _rest623) => {
V ids_630 = default;
if (_self621.IsNullish) _self621 = GlobalV;
castTag_61 = tag_629;
ids_630 = New(G("Set"), Invoke(list_628, "map", Fn((V _arrowThis638, int _argc631, V c_637, V _a634, V _a635, V _a636, V[] _rest632) => {
return Get(c_637, "id");
}, 1, "", true)));
{
foreach (V _k639 in new JsIter(C_59)) {
V id_640 = default;
V c_641 = default;
{ V _t642 = ListOf(_k639);
{ V _t643 = GetIdx(_t642, 0D);
id_640 = _t643; }
{ V _t644 = GetIdx(_t642, 1D);
c_641 = _t644; }
}
if (!(Truthy(Invoke(ids_630, "has", id_640)))) {
Call(unmount_63, V.Undef, c_641);
Invoke(C_59, "delete", id_640);
}
}
}
{
foreach (V _k645 in new JsIter(list_628)) {
V it_646 = default;
it_646 = _k645;
V c_647 = default;
c_647 = Invoke(C_59, "get", Get(it_646, "id"));
if (Truthy((c_647 is var _t648 && !Truthy(_t648) ? _t648 : (!SEq(Get(c_647, "key"), Get(it_646, "key")) ? V.True : V.False)))) {
Call(unmount_63, V.Undef, c_647);
Invoke(C_59, "delete", Get(it_646, "id"));
c_647 = V.Null;
}
if (!(Truthy(c_647))) {
c_647 = NewObj(7).Put("id", Get(it_646, "id")).Put("key", Get(it_646, "key")).Put("moves", Arr()).Put("face", ((V)(0D))).Put("faceNow", ((V)(0D))).Put("o", ((V)(1D))).Put("k", ((V)(1D))).V;
Invoke(C_59, "set", Get(it_646, "id"), c_647);
Call(mount_62, V.Undef, c_647);
}
Object_assign(c_647, NewObj(6).Put("W", Get(it_646, "W")).Put("x", Add(Get(it_646, "x"), GetIdx(origin_60, 0D))).Put("y", Add(Get(it_646, "y"), GetIdx(origin_60, 1D))).Put("s", Get(it_646, "s")).Put("z", Get(it_646, "z")).Put("o", (Get(it_646, "o").IsNullish ? ((V)(1D)) : Get(it_646, "o"))).V);
Set(c_647, "moves", Arr());
Set(c_647, "cur", V.Null);
}
}
Call(kick_84, V.Undef);
return default;
}, 2, "cast", false)).Put("place", Fn((V _self649, int _argc650, V id_656, V p_657, V _a654, V _a655, V[] _rest651) => {
V c_658 = default;
if (_self649.IsNullish) _self649 = GlobalV;
c_658 = Invoke(C_59, "get", id_656);
if (!(Truthy(c_658))) {
return default;
}
Set(c_658, "moves", Invoke(Get(c_658, "moves"), "filter", Fn((V _arrowThis666, int _argc659, V m_665, V _a662, V _a663, V _a664, V[] _rest660) => {
return Get(m_665, "keep");
}, 1, "", true)));
Object_assign(c_658, NewObj(4).Put("x", Add(Get(p_657, "x"), GetIdx(origin_60, 0D))).Put("y", Add(Get(p_657, "y"), GetIdx(origin_60, 1D))).Put("s", Get(p_657, "s")).Put("z", Get(p_657, "z")).V);
if (!Get(p_657, "o").IsNullish) {
Set(c_658, "o", Get(p_657, "o"));
}
Set(c_658, "k", ((V)(1D)));
Call(kick_84, V.Undef);
return default;
}, 2, "place", false)).Put("show", Fn((V _self667, int _argc668, V id_674, V o_675, V _a672, V _a673, V[] _rest669) => {
V c_676 = default;
if (_self667.IsNullish) _self667 = GlobalV;
c_676 = Invoke(C_59, "get", id_674);
if (Truthy(c_676)) {
Set(c_676, "o", o_675);
Call(kick_84, V.Undef);
}
return default;
}, 2, "show", false)).Put("enter", Fn((V _self677, int _argc678, V id_684, V p_685, V delay_686, V pop_687, V[] _rest679) => {
V c_688 = default;
double D_689 = 0;
if (_self677.IsNullish) _self677 = GlobalV;
c_688 = Invoke(C_59, "get", id_684);
if (!(Truthy(c_688))) {
return default;
}
Call(G("clearInterval"), V.Undef, Get(c_688, "sweat"));
Set(c_688, "moves", Arr());
Object_assign(c_688, NewObj(8).Put("x", Add(Get(p_685, "x"), GetIdx(origin_60, 0D))).Put("y", Add(Get(p_685, "y"), GetIdx(origin_60, 1D))).Put("s", Get(p_685, "s")).Put("z", Get(p_685, "z")).Put("o", ((V)(1D))).Put("k", ((V)(1D))).Put("face", ((V)(0D))).Put("faceNow", ((V)(0D))).V);
if (Truthy(Get(c_688, "ctrl"))) {
Invoke(Get(c_688, "ctrl"), "play", ((V)("idle")));
}
D_689 = (Truthy(pop_687) ? 340D : 460D);
Call(start_68, V.Undef, c_688, NewObj(5).Put("kind", ((V)("enter"))).Put("delay", delay_686).Put("dur", ((V)(D_689))).Put("before", NewObj(1).Put("o", ((V)(0D))).V).Put("run", Fn((V _self690, int _argc691, V c_697, V t_698, V _a695, V _a696, V[] _rest692) => {
V fall_699 = default;
if (_self690.IsNullish) _self690 = GlobalV;
if (Truthy(pop_687)) {
double u_700 = 0;
u_700 = (ToNum(t_698) / D_689);
return NewObj(3).Put("k", ((V)((0.3 + (0.7 * ToNum(Call(kv_52, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((D_689 * 0.7))), ((V)(1.12)), ((V)("o"))), Arr(((V)(D_689)), ((V)(1D)), ((V)("io")))), t_698))))))).Put("o", Call(clamp_49, V.Undef, ((V)((u_700 * 3D))), ((V)(0D)), ((V)(1D)))).Put("ext", NewObj(1).Put("sq", Call(kv_52, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((D_689 * 0.5))), ((V)((-0.2))), ((V)("o"))), Arr(((V)((D_689 * 0.8))), ((V)(0.1)), ((V)("io"))), Arr(((V)(D_689)), ((V)(0D)), ((V)("io")))), t_698)).V).V;
}
fall_699 = Call(kv_52, V.Undef, Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)((D_689 * 0.62))), ((V)(0D)), ((V)("i"))), Arr(((V)(D_689)), ((V)(0D)))), t_698);
return NewObj(3).Put("o", Call(clamp_49, V.Undef, ((V)((ToNum(t_698) / 120D))), ((V)(0D)), ((V)(1D)))).Put("up", ((V)(((90D * ToNum(Get(c_697, "s"))) * ToNum(fall_699))))).Put("ext", NewObj(3).Put("sq", Call(kv_52, V.Undef, Arr(Arr(((V)(0D)), ((V)((-0.2)))), Arr(((V)((D_689 * 0.62))), ((V)((-0.25))), ((V)("i"))), Arr(((V)((D_689 * 0.7))), ((V)(0.4)), ((V)("o"))), Arr(((V)((D_689 * 0.85))), ((V)((-0.1))), ((V)("io"))), Arr(((V)(D_689)), ((V)(0D)), ((V)("io")))), t_698)).Put("armL", Call(kv_52, V.Undef, Arr(Arr(((V)(0D)), ((V)(40D))), Arr(((V)((D_689 * 0.62))), ((V)(40D))), Arr(((V)((D_689 * 0.75))), ((V)((-14D))), ((V)("o"))), Arr(((V)(D_689)), ((V)(0D)), ((V)("io")))), t_698)).Put("armR", Call(kv_52, V.Undef, Arr(Arr(((V)(0D)), ((V)(40D))), Arr(((V)((D_689 * 0.62))), ((V)(40D))), Arr(((V)((D_689 * 0.75))), ((V)((-14D))), ((V)("o"))), Arr(((V)(D_689)), ((V)(0D)), ((V)("io")))), t_698)).V).V;
return default;
}, 2, "run", false)).V);
return default;
}, 4, "enter", false)).Put("hop", Fn((V _self701, int _argc702, V id_708, V legs_709, V dir_710, V _a707, V[] _rest703) => {
V c_711 = default;
V E_712 = default;
double i_713 = 0;
V next_714 = default;
if (_self701.IsNullish) _self701 = GlobalV;
c_711 = Invoke(C_59, "get", id_708);
if (!(Truthy(c_711))) {
return default;
}
if (Truthy((Get(c_711, "hopEnd") is var _t723 && !Truthy(_t723) ? _t723 : Invoke(Get(c_711, "moves"), "some", Fn((V _arrowThis722, int _argc715, V m_721, V _a718, V _a719, V _a720, V[] _rest716) => {
return (SEqS(Get(m_721, "kind"), "hop") ? V.True : V.False);
}, 1, "", true))))) {
Object_assign(c_711, Get(c_711, "hopEnd"));
Call(land_76, V.Undef, c_711);
}
Set(c_711, "hopEnd", V.Null);
Set(c_711, "moves", Invoke(Get(c_711, "moves"), "filter", Fn((V _arrowThis731, int _argc724, V m_730, V _a727, V _a728, V _a729, V[] _rest725) => {
return ((SEqS(Get(m_730, "kind"), "land") ? V.True : V.False) is var _t732 && Truthy(_t732) ? _t732 : Get(m_730, "keep"));
}, 1, "", true)));
if (Truthy(((Get(c_711, "ctrl") is var _t733 && !Truthy(_t733) ? _t733 : Get(c_711, "I")) is var _t734 && !Truthy(_t734) ? _t734 : (!SEqS(Get(Get(Get(c_711, "I"), "cur"), "name"), "idle") ? V.True : V.False)))) {
Invoke(Get(c_711, "ctrl"), "play", ((V)("idle")));
}
if (GeN(dir_710, 0D)) {
Call(faceTo_77, V.Undef, c_711, dir_710);
}
if (!(Truthy(Get(legs_709, "length")))) {
return default;
}
E_712 = GetIdx(legs_709, (ToNum(Get(legs_709, "length")) - 1D));
Set(c_711, "hopEnd", NewObj(4).Put("x", Add(Get(E_712, "x"), GetIdx(origin_60, 0D))).Put("y", Add(Get(E_712, "y"), GetIdx(origin_60, 1D))).Put("s", Get(E_712, "s")).Put("z", Get(E_712, "z")).V);
i_713 = 0D;
next_714 = Fn((V _arrowThis741, int _argc735, V _a737, V _a738, V _a739, V _a740, V[] _rest736) => {
V L_742 = default;
V from_743 = default;
V last_744 = default;
if (Ge(((V)(i_713)), Get(legs_709, "length"))) {
return default;
}
L_742 = Object_assign(NewObj(0).V, GetIdx(legs_709, i_713));
OpSet(L_742, "x", 0, GetIdx(origin_60, 0D));
OpSet(L_742, "y", 0, GetIdx(origin_60, 1D));
from_743 = NewObj(4).Put("x", Get(c_711, "x")).Put("y", Get(c_711, "y")).Put("s", Get(c_711, "s")).Put("z", Get(c_711, "z")).V;
last_744 = ((i_713 == (ToNum(Get(legs_709, "length")) - 1D)) ? V.True : V.False);
i_713++;
if (Truthy(((Get(L_742, "boing") is var _t745 && !Truthy(_t745) ? _t745 : Get(c_711, "I")) is var _t746 && !Truthy(_t746) ? _t746 : Get(c_711, "bb")))) {
Call(burst_81, V.Undef, c_711, ((V)("hopPop")), ((V)("feet")));
}
Call(leg_75, V.Undef, c_711, L_742, from_743, dir_710, Fn((V _arrowThis753, int _argc747, V _a749, V _a750, V _a751, V _a752, V[] _rest748) => {
Set(c_711, "x", Get(L_742, "x"));
Set(c_711, "y", Get(L_742, "y"));
Set(c_711, "s", Get(L_742, "s"));
Set(c_711, "z", Get(L_742, "z"));
if (Truthy(last_744)) {
Set(c_711, "hopEnd", V.Null);
Call(land_76, V.Undef, c_711);
}
Call(next_714, V.Undef);
return default;
}, 0, "", true));
return default;
}, 0, "", true);
Call(next_714, V.Undef);
return default;
}, 3, "hop", false)).Put("bump", Fn((V _self754, int _argc755, V id_761, V dx_762, V dy_763, V shake_764, V[] _rest756) => {
V c_765 = default;
double D_766 = 0;
double side_767 = 0;
if (_self754.IsNullish) _self754 = GlobalV;
c_765 = Invoke(C_59, "get", id_761);
if (!(Truthy(c_765))) {
return default;
}
if (Truthy((shake_764 is var _t768 && !Truthy(_t768) ? _t768 : Get(c_765, "ctrl")))) {
Invoke(Get(c_765, "ctrl"), "play", ((V)("hopOops")));
}
D_766 = (Truthy(shake_764) ? 620D : 380D);
side_767 = Sign(ToNum(dx_762));
Call(start_68, V.Undef, c_765, NewObj(3).Put("kind", ((V)("bump"))).Put("dur", ((V)(D_766))).Put("run", Fn((V _self769, int _argc770, V c_776, V t_777, V _a774, V _a775, V[] _rest771) => {
V @out_778 = default;
V no_779 = default;
V squish_780 = default;
if (_self769.IsNullish) _self769 = GlobalV;
@out_778 = Call(kv_52, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(70D)), ((V)(1D)), ((V)("o"))), Arr(((V)(200D)), ((V)(0D)), ((V)("io")))), t_777);
no_779 = (Truthy(shake_764) ? Call(kv_52, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(0D))), Arr(((V)(220D)), ((V)(0.9)), ((V)("io"))), Arr(((V)(320D)), ((V)((-0.8))), ((V)("io"))), Arr(((V)(420D)), ((V)(0.5)), ((V)("io"))), Arr(((V)(520D)), ((V)((-0.25))), ((V)("io"))), Arr(((V)(D_766)), ((V)(0D)), ((V)("io")))), t_777) : ((V)(0D)));
squish_780 = (Truthy(shake_764) ? Call(kv_52, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(70D)), ((V)(1D)), ((V)("o"))), Arr(((V)(180D)), ((V)(0D)), ((V)("io")))), t_777) : ((V)(0D)));
return NewObj(3).Put("dx", ((V)((ToNum(dx_762) * ToNum(@out_778))))).Put("dy", ((V)((ToNum(dy_763) * ToNum(@out_778))))).Put("ext", NewObj(5).Put("turn", no_779).Put("sq", ((V)((ToNum(squish_780) * (NumTruthy(side_767) ? 0.18 : 0.32))))).Put("tilt", ((V)((((-side_767) * ToNum(squish_780)) * 9D)))).Put("x", ((V)((((-side_767) * ToNum(squish_780)) * 2.5)))).Put("lx", no_779).V).V;
return default;
}, 2, "run", false)).V);
return default;
}, 4, "bump", false)).Put("pickup", Fn((V _self781, int _argc782, V id_788, V tx_789, V ty_790, V ms_791, V[] _rest783) => {
V c_792 = default;
V D_793 = default;
double go_794 = 0;
V from_795 = default;
V to_796 = default;
double kEnd_797 = 0;
if (_self781.IsNullish) _self781 = GlobalV;
c_792 = Invoke(C_59, "get", id_788);
if (!(Truthy(c_792))) {
return default;
}
Set(c_792, "moves", Arr());
if (Truthy(Get(c_792, "ctrl"))) {
Invoke(Get(c_792, "ctrl"), "play", ((V)("hopJoy")));
}
Call(hearts_80, V.Undef, c_792, ((V)(2D)), ((V)(160D)));
D_793 = (ms_791 is var _t798 && Truthy(_t798) ? _t798 : ((V)(760D)));
go_794 = (ToNum(D_793) * 0.34);
from_795 = NewObj(2).Put("x", Get(c_792, "x")).Put("y", Get(c_792, "y")).V;
to_796 = NewObj(2).Put("x", Add(tx_789, GetIdx(origin_60, 0D))).Put("y", Add(ty_790, GetIdx(origin_60, 1D))).V;
kEnd_797 = (Truthy(Get(c_792, "bb")) ? Max(0.15, (26D / (ToNum(Get(c_792, "W")) * ToNum(Get(c_792, "s"))))) : 0.3);
Call(start_68, V.Undef, c_792, NewObj(4).Put("kind", ((V)("pickup"))).Put("dur", D_793).Put("run", Fn((V _self799, int _argc800, V c_806, V t_807, V _a804, V _a805, V[] _rest801) => {
V u_808 = default;
double hopUp_809 = 0;
double fly_810 = 0;
if (_self799.IsNullish) _self799 = GlobalV;
u_808 = (LtN(t_807, go_794) ? ((V)(0D)) : Call(SM_51, V.Undef, ((V)(((ToNum(t_807) - go_794) / (ToNum(D_793) - go_794))))));
Set(c_806, "x", Call(lerp_50, V.Undef, Get(from_795, "x"), Get(to_796, "x"), u_808));
Set(c_806, "y", Call(lerp_50, V.Undef, Get(from_795, "y"), Get(to_796, "y"), u_808));
hopUp_809 = (ToNum(Call(parab_53, V.Undef, ((V)((ToNum(t_807) / (go_794 * 0.9)))))) * 26D);
fly_810 = (ToNum(Call(parab_53, V.Undef, ((V)(((ToNum(t_807) - go_794) / (ToNum(D_793) - go_794)))))) * 60D);
return NewObj(6).Put("z", (LtN(t_807, go_794) ? Get(c_806, "z") : ((V)(90D)))).Put("k", Call(lerp_50, V.Undef, ((V)(1D)), ((V)(kEnd_797)), u_808)).Put("o", ((V)((LtN(t_807, (ToNum(D_793) * 0.8)) ? 1D : (1D - ((ToNum(t_807) - (ToNum(D_793) * 0.8)) / (ToNum(D_793) * 0.2))))))).Put("up", ((V)(((hopUp_809 + fly_810) * ToNum(Get(c_806, "s")))))).Put("sh", ((V)((1D - ToNum(Call(SM_51, V.Undef, ((V)(((ToNum(t_807) - go_794) / (ToNum(D_793) * 0.2)))))))))).Put("ext", NewObj(5).Put("sq", Call(kv_52, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((go_794 * 0.15))), ((V)(0.3)), ((V)("io"))), Arr(((V)((go_794 * 0.32))), ((V)((-0.3))), ((V)("o"))), Arr(((V)((go_794 * 0.8))), ((V)((-0.05))), ((V)("io"))), Arr(((V)(go_794)), ((V)(0.25)), ((V)("o"))), Arr(((V)((go_794 * 1.15))), ((V)((-0.3))), ((V)("o"))), Arr(D_793, ((V)(0D)), ((V)("io")))), t_807)).Put("armL", Call(kv_52, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((go_794 * 0.3))), ((V)(50D)), ((V)("o"))), Arr(D_793, ((V)(40D)))), t_807)).Put("armR", Call(kv_52, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((go_794 * 0.3))), ((V)(50D)), ((V)("o"))), Arr(D_793, ((V)(40D)))), t_807)).Put("tilt", Call(kv_52, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((go_794 * 0.3))), ((V)(8D)), ((V)("io"))), Arr(((V)((go_794 * 0.6))), ((V)((-8D))), ((V)("io"))), Arr(((V)(go_794)), ((V)(0D)), ((V)("io")))), t_807)).Put("spin", Call(kv_52, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(go_794)), ((V)(0D))), Arr(((V)((ToNum(D_793) * 0.9))), ((V)(360D)), ((V)("io"))), Arr(D_793, ((V)(360D)))), t_807)).V).V;
return default;
}, 2, "run", false)).Put("done", Fn((V _self811, int _argc812, V _a814, V _a815, V _a816, V _a817, V[] _rest813) => {
if (_self811.IsNullish) _self811 = GlobalV;
Set(c_792, "o", ((V)(0D)));
Set(c_792, "x", Get(to_796, "x"));
Set(c_792, "y", Get(to_796, "y"));
return default;
}, 0, "done", false)).V);
return default;
}, 4, "pickup", false)).Put("restore", Fn((V _self818, int _argc819, V id_825, V p_826, V _a823, V _a824, V[] _rest820) => {
V c_827 = default;
double D_828 = 0;
if (_self818.IsNullish) _self818 = GlobalV;
c_827 = Invoke(C_59, "get", id_825);
if (!(Truthy(c_827))) {
return default;
}
Set(c_827, "moves", Arr());
Object_assign(c_827, NewObj(6).Put("x", Add(Get(p_826, "x"), GetIdx(origin_60, 0D))).Put("y", Add(Get(p_826, "y"), GetIdx(origin_60, 1D))).Put("s", Get(p_826, "s")).Put("z", Get(p_826, "z")).Put("o", ((V)(1D))).Put("k", ((V)(1D))).V);
if (Truthy(Get(c_827, "ctrl"))) {
Invoke(Get(c_827, "ctrl"), "play", ((V)("idle")));
}
D_828 = 300D;
Call(start_68, V.Undef, c_827, NewObj(3).Put("kind", ((V)("enter"))).Put("dur", ((V)(D_828))).Put("run", Fn((V _self829, int _argc830, V c_836, V t_837, V _a834, V _a835, V[] _rest831) => {
if (_self829.IsNullish) _self829 = GlobalV;
return NewObj(1).Put("k", ((V)((0.3 + (0.7 * ToNum(Call(kv_52, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((D_828 * 0.7))), ((V)(1.12)), ((V)("o"))), Arr(((V)(D_828)), ((V)(1D)), ((V)("io")))), t_837))))))).V;
return default;
}, 2, "run", false)).V);
return default;
}, 2, "restore", false)).Put("win", Fn((V _self838, int _argc839, V id_845, V ms_846, V _a843, V _a844, V[] _rest840) => {
V c_847 = default;
V D_848 = default;
V lift_849 = default;
V sq_850 = default;
V arm_851 = default;
V tilt_852 = default;
V spin_853 = default;
if (_self838.IsNullish) _self838 = GlobalV;
c_847 = Invoke(C_59, "get", id_845);
if (!(Truthy(c_847))) {
return default;
}
if (Truthy(Get(c_847, "ctrl"))) {
Invoke(Get(c_847, "ctrl"), "play", ((V)("hopJoy")));
}
D_848 = (ms_846 is var _t854 && Truthy(_t854) ? _t854 : ((V)(1150D)));
Call(faceTo_77, V.Undef, c_847, ((V)(2D)));
lift_849 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_848) * 0.05))), ((V)(0D))), Arr(((V)((ToNum(D_848) * 0.145))), ((V)(34D)), ((V)("o"))), Arr(((V)((ToNum(D_848) * 0.24))), ((V)(0D)), ((V)("i"))), Arr(((V)((ToNum(D_848) * 0.34))), ((V)(0D))), Arr(((V)((ToNum(D_848) * 0.45))), ((V)(40D)), ((V)("o"))), Arr(((V)((ToNum(D_848) * 0.56))), ((V)(0D)), ((V)("i"))), Arr(((V)((ToNum(D_848) * 0.64))), ((V)(0D))), Arr(((V)((ToNum(D_848) * 0.8))), ((V)(62D)), ((V)("o"))), Arr(((V)((ToNum(D_848) * 0.95))), ((V)(0D)), ((V)("i"))), Arr(D_848, ((V)(0D))));
sq_850 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_848) * 0.04))), ((V)(0.22)), ((V)("io"))), Arr(((V)((ToNum(D_848) * 0.08))), ((V)((-0.3))), ((V)("o"))), Arr(((V)((ToNum(D_848) * 0.2))), ((V)((-0.08))), ((V)("io"))), Arr(((V)((ToNum(D_848) * 0.25))), ((V)(0.26)), ((V)("o"))), Arr(((V)((ToNum(D_848) * 0.31))), ((V)(0.2)), ((V)("io"))), Arr(((V)((ToNum(D_848) * 0.37))), ((V)((-0.3))), ((V)("o"))), Arr(((V)((ToNum(D_848) * 0.5))), ((V)((-0.08))), ((V)("io"))), Arr(((V)((ToNum(D_848) * 0.56))), ((V)(0.26)), ((V)("o"))), Arr(((V)((ToNum(D_848) * 0.62))), ((V)(0.24)), ((V)("io"))), Arr(((V)((ToNum(D_848) * 0.68))), ((V)((-0.36))), ((V)("o"))), Arr(((V)((ToNum(D_848) * 0.86))), ((V)((-0.1))), ((V)("io"))), Arr(((V)((ToNum(D_848) * 0.95))), ((V)(0.28)), ((V)("o"))), Arr(D_848, ((V)(0.06)), ((V)("io"))));
arm_851 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_848) * 0.08))), ((V)(46D)), ((V)("o"))), Arr(((V)((ToNum(D_848) * 0.9))), ((V)(46D))), Arr(D_848, ((V)(10D)), ((V)("io"))));
tilt_852 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_848) * 0.13))), ((V)(7D)), ((V)("io"))), Arr(((V)((ToNum(D_848) * 0.27))), ((V)(0D)), ((V)("io"))), Arr(((V)((ToNum(D_848) * 0.43))), ((V)((-7D))), ((V)("io"))), Arr(((V)((ToNum(D_848) * 0.57))), ((V)(0D)), ((V)("io"))));
spin_853 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_848) * 0.68))), ((V)(0D))), Arr(((V)((ToNum(D_848) * 0.92))), ((V)(360D)), ((V)("io"))), Arr(D_848, ((V)(360D))));
Call(start_68, V.Undef, c_847, NewObj(4).Put("kind", ((V)("win"))).Put("dur", D_848).Put("run", Fn((V _self855, int _argc856, V c_862, V t_863, V _a860, V _a861, V[] _rest857) => {
if (_self855.IsNullish) _self855 = GlobalV;
return NewObj(2).Put("up", ((V)((ToNum(Call(kv_52, V.Undef, lift_849, t_863)) * ToNum(Get(c_862, "s")))))).Put("ext", NewObj(5).Put("sq", Call(kv_52, V.Undef, sq_850, t_863)).Put("armL", Call(kv_52, V.Undef, arm_851, t_863)).Put("armR", Call(kv_52, V.Undef, arm_851, t_863)).Put("tilt", Call(kv_52, V.Undef, tilt_852, t_863)).Put("spin", (Lt(t_863, D_848) ? Call(kv_52, V.Undef, spin_853, t_863) : ((V)(0D)))).V).V;
return default;
}, 2, "run", false)).Put("done", Fn((V _self864, int _argc865, V _a867, V _a868, V _a869, V _a870, V[] _rest866) => {
if (_self864.IsNullish) _self864 = GlobalV;
Call(land_76, V.Undef, c_847, ((V)(0.06)), ((V)(10D)));
return default;
}, 0, "done", false)).V);
Invoke(Arr(((V)(0.26)), ((V)(0.56)), ((V)(0.96))), "forEach", Fn((V _arrowThis878, int _argc871, V f_877, V _a874, V _a875, V _a876, V[] _rest872) => {
return Call(G("setTimeout"), V.Undef, Fn((V _arrowThis893, int _argc887, V _a889, V _a890, V _a891, V _a892, V[] _rest888) => {
if (Truthy((Get(c_847, "I") is var _t894 && !Truthy(_t894) ? _t894 : Get(c_847, "bb")))) {
Call(burst_81, V.Undef, c_847, ((V)("hopSpark")), ((V)("feet")), ((V)(4D)));
}
return default;
}, 0, "", true), ((V)((ToNum(D_848) * ToNum(f_877)))));
}, 1, "", true));
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis909, int _argc903, V _a905, V _a906, V _a907, V _a908, V[] _rest904) => {
if (Truthy((Get(c_847, "I") is var _t910 && !Truthy(_t910) ? _t910 : Get(c_847, "bb")))) {
Call(burst_81, V.Undef, c_847, ((V)("hopSpark")), ((V)("head")), ((V)(7D)));
}
return default;
}, 0, "", true), ((V)((ToNum(D_848) * 0.8))));
Call(hearts_80, V.Undef, c_847, ((V)(4D)), ((V)(260D)));
return default;
}, 2, "win", false)).Put("stuck", Fn((V _self911, int _argc912, V id_918, V _a915, V _a916, V _a917, V[] _rest913) => {
V c_919 = default;
V drip_920 = default;
if (_self911.IsNullish) _self911 = GlobalV;
c_919 = Invoke(C_59, "get", id_918);
if (!(Truthy(c_919))) {
return default;
}
Set(c_919, "moves", Invoke(Get(c_919, "moves"), "filter", Fn((V _arrowThis928, int _argc921, V m_927, V _a924, V _a925, V _a926, V[] _rest922) => {
return ((SEqS(Get(m_927, "kind"), "land") ? V.True : V.False) is var _t929 && Truthy(_t929) ? _t929 : Get(m_927, "keep"));
}, 1, "", true)));
if (Truthy(Get(c_919, "ctrl"))) {
Invoke(Get(c_919, "ctrl"), "play", ((V)("hopSadLook")));
}
Call(faceTo_77, V.Undef, c_919, ((V)(2D)));
Call(G("clearInterval"), V.Undef, Get(c_919, "sweat"));
drip_920 = Fn((V _arrowThis936, int _argc930, V _a932, V _a933, V _a934, V _a935, V[] _rest931) => {
if (Truthy((Get(c_919, "I") is var _t937 && !Truthy(_t937) ? _t937 : Get(c_919, "bb")))) {
Call(burst_81, V.Undef, c_919, ((V)("hopSweat")), ((V)("temple")));
}
return default;
}, 0, "", true);
Call(G("setTimeout"), V.Undef, drip_920, ((V)(360D)));
Set(c_919, "sweat", Call(G("setInterval"), V.Undef, drip_920, ((V)(720D))));
return default;
}, 1, "stuck", false)).Put("unstuck", Fn((V _self938, int _argc939, V id_945, V _a942, V _a943, V _a944, V[] _rest940) => {
V c_946 = default;
if (_self938.IsNullish) _self938 = GlobalV;
c_946 = Invoke(C_59, "get", id_945);
if (!(Truthy(c_946))) {
return default;
}
Call(G("clearInterval"), V.Undef, Get(c_946, "sweat"));
if (Truthy(Get(c_946, "ctrl"))) {
Invoke(Get(c_946, "ctrl"), "play", ((V)("hopPerk")));
}
return default;
}, 1, "unstuck", false)).Put("giggle", Fn((V _self947, int _argc948, V id_954, V _a951, V _a952, V _a953, V[] _rest949) => {
V c_955 = default;
if (_self947.IsNullish) _self947 = GlobalV;
c_955 = Invoke(C_59, "get", id_954);
if (Truthy((c_955 is var _t956 && !Truthy(_t956) ? _t956 : Get(c_955, "ctrl")))) {
Invoke(Get(c_955, "ctrl"), "play", ((V)("hopGiggle")));
}
return default;
}, 1, "giggle", false)).Put("pause", Fn((V _self957, int _argc958, V on_964, V _a961, V _a962, V _a963, V[] _rest959) => {
if (_self957.IsNullish) _self957 = GlobalV;
Invoke(window_39, "__rigPause", on_964);
return default;
}, 1, "pause", false)).V;
running_82 = (false ? V.True : V.False);
castRaw_85 = Get(api_79, "cast");
Set(api_79, "cast", Fn((V _arrowThis973, int _argc965, V list_971, V tag_972, V _a969, V _a970, V[] _rest966) => {
Set(api_79, "_sent", V.Null);
Call(castRaw_85, V.Undef, list_971, tag_972);
return default;
}, 2, "", true));
Set(window_39, "hopStage", api_79);
Set(api_79, "_C", C_59);
boot_86 = Fn((V _arrowThis980, int _argc974, V _a976, V _a977, V _a978, V _a979, V[] _rest975) => {
V R_981 = default;
R_981 = Get(window_39, "RiveRig");
if (Truthy((((((R_981 is var _t982 && !Truthy(_t982) ? _t982 : Get(R_981, "REST")) is var _t983 && !Truthy(_t983) ? _t983 : Get(R_981, "DEFS")) is var _t984 && !Truthy(_t984) ? _t984 : Get(Get(R_981, "DEFS"), "prickle")) is var _t985 && !Truthy(_t985) ? _t985 : Get(R_981, "movesV")) is var _t986 && !Truthy(_t986) ? _t986 : Get(window_39, "RiveGeneric")))) {
kv_52 = Get(R_981, "kv");
Call(addStates_58, V.Undef);
Call(post_47, V.Undef, NewObj(1).Put("type", ((V)("ready"))).V);
} else {
Call(G("setTimeout"), V.Undef, boot_86, ((V)(25D)));
}
return default;
}, 0, "", true);
Call(boot_86, V.Undef);
Set(window_39, "onerror", Fn((V _arrowThis994, int _argc987, V m_993, V _a990, V _a991, V _a992, V[] _rest988) => {
return Call(post_47, V.Undef, NewObj(2).Put("type", ((V)("error"))).Put("message", ((V)(ToStrS(m_993)))).V);
}, 1, "", true));
return default;
}, 0, "", false), V.Undef);
return default;
}, 1, "", false), V.Undef, W_13);
Invoke(b_11, "removeAttribute", ((V)("id")));
return default;
}, 1, "", false), V.Undef, (!string.Equals(GTypeof("globalThis"), "undefined") ? G("globalThis") : GlobalV));
        }
    }
}
