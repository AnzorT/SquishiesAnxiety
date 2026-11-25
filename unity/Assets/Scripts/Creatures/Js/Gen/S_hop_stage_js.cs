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
V W_12 = default;
if (_self1.IsNullish) _self1 = GlobalV;
d_9 = Get(G_8, "document");
old_10 = Invoke(d_9, "getElementById", ((V)("board")));
if (Truthy(old_10)) {
Invoke(old_10, "removeAttribute", ((V)("id")));
}
b_11 = Invoke(d_9, "createElement", ((V)("div")));
Invoke(b_11, "setAttribute", ((V)("id")), ((V)("board")));
Invoke(Get(d_9, "body"), "appendChild", b_11);
W_12 = Object_create(G_8);
Set(W_12, "innerWidth", ((V)(400D)));
Set(W_12, "innerHeight", ((V)(300D)));
Set(W_12, "__rigPause", Fn((V _self13, int _argc14, V _a16, V _a17, V _a18, V _a19, V[] _rest15) => {
if (_self13.IsNullish) _self13 = GlobalV;

return default;
}, 0, "", false));
Set((Get(G_8, "__stages") is var _t20 && Truthy(_t20) ? _t20 : Set(G_8, "__stages", NewObj(0).V)), "hop", NewObj(2).Put("win", W_12).Put("board", b_11).V);
Call(Fn((V _self21, int _argc22, V window_28, V _a25, V _a26, V _a27, V[] _rest23) => {
if (_self21.IsNullish) _self21 = GlobalV;
Call(Fn((V _self29, int _argc30, V _a32, V _a33, V _a34, V _a35, V[] _rest31) => {
V post_36 = default;
V board_37 = default;
V clamp_38 = default;
V lerp_39 = default;
V SM_40 = default;
V kv_41 = default;
V parab_42 = default;
V FAB_43 = default;
V fabric_44 = default;
V isGrain_45 = default;
V bakeGrain_46 = default;
V addStates_47 = default;
V C_48 = default;
V origin_49 = default;
V castTag_50 = default;
V mount_51 = default;
V measure_52 = default;
V ready_53 = default;
V draw_54 = default;
V start_55 = default;
V stopMoves_56 = default;
V toU_57 = default;
double CROUCH_58 = 0;
double SPRING_59 = 0;
V leg_60 = default;
V land_61 = default;
V faceTo_62 = default;
V DIRS_63 = default;
V api_64 = default;
V hearts_65 = default;
V burst_66 = default;
V running_67 = default;
V frame_68 = default;
V kick_69 = default;
V castRaw_70 = default;
V boot_71 = default;
if (_self29.IsNullish) _self29 = GlobalV;
fabric_44 = Fn((V _self72, int _argc73, V _a75, V _a76, V _a77, V _a78, V[] _rest74) => {
if (_self72.IsNullish) _self72 = GlobalV;
if (!SEq(FAB_43, V.Null)) {
return FAB_43;
}
FAB_43 = ((V)(""));
try {
double S_79 = 0;
V cv_80 = default;
V x_81 = default;
V im_82 = default;
double sd_83 = 0;
V rnd_84 = default;
V oct_85 = default;
V o1_86 = default;
V o2_87 = default;
double B_88 = 0;
V cb_89 = default;
V xb_90 = default;
S_79 = 128D;
cv_80 = Invoke(G("document"), "createElement", ((V)("canvas")));
Set(cv_80, "width", Set(cv_80, "height", ((V)(S_79))));
x_81 = Invoke(cv_80, "getContext", ((V)("2d")));
im_82 = Invoke(x_81, "createImageData", ((V)(S_79)), ((V)(S_79)));
sd_83 = 7D;
rnd_84 = Fn((V _arrowThis97, int _argc91, V _a93, V _a94, V _a95, V _a96, V[] _rest92) => {
return ((V)(((sd_83 = ((sd_83 * 16807D) % 2147483647D)) / 2147483647D)));
}, 0, "", true);
oct_85 = Fn((V _arrowThis105, int _argc98, V n_104, V _a101, V _a102, V _a103, V[] _rest99) => {
V g_106 = default;
double c_107 = 0;
V sm_108 = default;
g_106 = Arr();
{
double i_109 = 0;
i_109 = 0D;
while (true) {
if (!((i_109 < (ToNum(n_104) * ToNum(n_104))))) break;
Invoke(g_106, "push", Call(rnd_84, V.Undef));
i_109++;
}
}
c_107 = (S_79 / ToNum(n_104));
sm_108 = Fn((V _arrowThis118, int _argc111, V t_117, V _a114, V _a115, V _a116, V[] _rest112) => {
return ((V)(((ToNum(t_117) * ToNum(t_117)) * (3D - (2D * ToNum(t_117))))));
}, 1, "", true);
return Fn((V _arrowThis127, int _argc119, V px_125, V py_126, V _a123, V _a124, V[] _rest120) => {
double gx_128 = 0;
double gy_129 = 0;
double x0_130 = 0;
double y0_131 = 0;
V fx_132 = default;
V fy_133 = default;
V a_134 = default;
V t_135 = default;
V b_136 = default;
gx_128 = (ToNum(px_125) / c_107);
gy_129 = (ToNum(py_126) / c_107);
x0_130 = System.Math.Floor(gx_128);
y0_131 = System.Math.Floor(gy_129);
fx_132 = Call(sm_108, V.Undef, ((V)((gx_128 - x0_130))));
fy_133 = Call(sm_108, V.Undef, ((V)((gy_129 - y0_131))));
a_134 = Fn((V _arrowThis145, int _argc137, V i_143, V j_144, V _a141, V _a142, V[] _rest138) => {
return GetIdx(g_106, (((ToNum(Add(((V)((ToNum(j_144) % ToNum(n_104)))), n_104)) % ToNum(n_104)) * ToNum(n_104)) + (ToNum(Add(((V)((ToNum(i_143) % ToNum(n_104)))), n_104)) % ToNum(n_104))));
}, 2, "", true);
t_135 = Add(Call(a_134, V.Undef, ((V)(x0_130)), ((V)(y0_131))), ((V)(((ToNum(Call(a_134, V.Undef, ((V)((x0_130 + 1D))), ((V)(y0_131)))) - ToNum(Call(a_134, V.Undef, ((V)(x0_130)), ((V)(y0_131))))) * ToNum(fx_132)))));
b_136 = Add(Call(a_134, V.Undef, ((V)(x0_130)), ((V)((y0_131 + 1D)))), ((V)(((ToNum(Call(a_134, V.Undef, ((V)((x0_130 + 1D))), ((V)((y0_131 + 1D))))) - ToNum(Call(a_134, V.Undef, ((V)(x0_130)), ((V)((y0_131 + 1D)))))) * ToNum(fx_132)))));
return Add(t_135, ((V)(((ToNum(b_136) - ToNum(t_135)) * ToNum(fy_133)))));
return default;
}, 2, "", true);
return default;
}, 1, "", true);
o1_86 = Call(oct_85, V.Undef, ((V)(32D)));
o2_87 = Call(oct_85, V.Undef, ((V)(64D)));
{
double y_146 = 0;
y_146 = 0D;
while (true) {
if (!((y_146 < S_79))) break;
{
double X_148 = 0;
X_148 = 0D;
while (true) {
if (!((X_148 < S_79))) break;
double v_150 = 0;
double k_151 = 0;
v_150 = (ToNum(Add(Call(o1_86, V.Undef, ((V)(X_148)), ((V)(y_146))), Call(o2_87, V.Undef, ((V)(X_148)), ((V)(y_146))))) / 2D);
k_151 = (((y_146 * S_79) + X_148) * 4D);
SetIdx(Get(im_82, "data"), (k_151 + 3D), ((V)(Round(((0.2 * 255D) * v_150)))));
X_148++;
}
}
y_146++;
}
}
Invoke(x_81, "putImageData", im_82, ((V)(0D)), ((V)(0D)));
B_88 = 1024D;
cb_89 = Invoke(G("document"), "createElement", ((V)("canvas")));
Set(cb_89, "width", Set(cb_89, "height", ((V)(B_88))));
xb_90 = Invoke(cb_89, "getContext", ((V)("2d")));
Set(xb_90, "fillStyle", Invoke(xb_90, "createPattern", cv_80, ((V)("repeat"))));
Invoke(xb_90, "fillRect", ((V)(0D)), ((V)(0D)), ((V)(B_88)), ((V)(B_88)));
FAB_43 = Invoke(cb_89, "toDataURL", ((V)("image/png")));
} catch (System.Exception _ex152) {
V e_153 = default;
e_153 = Caught(_ex152);
FAB_43 = ((V)(""));
}
return FAB_43;
return default;
}, 0, "fabric", false);
bakeGrain_46 = Fn((V _self154, int _argc155, V svg_161, V _a158, V _a159, V _a160, V[] _rest156) => {
V els_162 = default;
V id_163 = default;
V f_164 = default;
V t_165 = default;
V im_166 = default;
V cm_167 = default;
V top_168 = default;
if (_self154.IsNullish) _self154 = GlobalV;
if ((!(Truthy(svg_161)) || !(Truthy(Call(fabric_44, V.Undef))))) {
return default;
}
els_162 = Invoke(new ArrBuilder().Spread(Invoke(svg_161, "querySelectorAll", ((V)("[filter]")))).V, "filter", Fn((V _arrowThis176, int _argc169, V e_175, V _a172, V _a173, V _a174, V[] _rest170) => {
V id_177 = default;
id_177 = GetIdx((Invoke(Invoke(e_175, "getAttribute", ((V)("filter"))), "match", NewRegExp(RX0, "url\\(#([^)]+)\\)", "")) is var _t178 && Truthy(_t178) ? _t178 : Arr()), 1D);
return (id_177 is var _t179 && !Truthy(_t179) ? _t179 : Call(isGrain_45, V.Undef, Invoke(svg_161, "getElementById", id_177)));
return default;
}, 1, "", true));
if (!(Truthy(Get(els_162, "length")))) {
return default;
}
id_163 = GetIdx(Invoke(Invoke(GetIdx(els_162, 0D), "getAttribute", ((V)("filter"))), "match", NewRegExp(RX0, "url\\(#([^)]+)\\)", "")), 1D);
f_164 = Invoke(svg_161, "getElementById", id_163);
t_165 = Invoke(f_164, "querySelector", ((V)("feTurbulence")));
im_166 = Invoke(G("document"), "createElementNS", ((V)("http://www.w3.org/2000/svg")), ((V)("feImage")));
Invoke(Arr(Arr(((V)("href")), FAB_43), Arr(((V)("x")), ((V)((-30D)))), Arr(((V)("y")), ((V)((-30D)))), Arr(((V)("width")), ((V)(160D))), Arr(((V)("height")), ((V)(160D))), Arr(((V)("preserveAspectRatio")), ((V)("none")))), "forEach", Fn((V _arrowThis191, int _argc180, V _a182, V _a183, V _a184, V _a185, V[] _rest181) => {
V a_188 = default;
V v_190 = default;
{ V _t186 = ListOf(_a182);
{ V _t187 = GetIdx(_t186, 0D);
a_188 = _t187; }
{ V _t189 = GetIdx(_t186, 1D);
v_190 = _t189; }
}
return Invoke(im_166, "setAttribute", a_188, v_190);
}, 1, "", true));
cm_167 = Get(t_165, "nextElementSibling");
Invoke(t_165, "replaceWith", im_166);
if (Truthy((cm_167 is var _t192 && !Truthy(_t192) ? _t192 : (SEqS(Get(cm_167, "tagName"), "feColorMatrix") ? V.True : V.False)))) {
Invoke(cm_167, "remove");
}
top_168 = Get(GetIdx(els_162, 0D), "parentNode");
while ((!SEq(top_168, svg_161) && !(Truthy(Invoke(els_162, "every", Fn((V _arrowThis200, int _argc193, V e_199, V _a196, V _a197, V _a198, V[] _rest194) => {
return Invoke(top_168, "contains", e_199);
}, 1, "", true)))))) {
top_168 = Get(top_168, "parentNode");
}
if (SEq(top_168, svg_161)) {
Invoke(els_162, "forEach", Fn((V _arrowThis208, int _argc201, V e_207, V _a204, V _a205, V _a206, V[] _rest202) => {
return Invoke(e_207, "setAttribute", ((V)("filter")), ((V)(JsStrBuf.Begin().S("url(#").V(id_163).S(")").End())));
}, 1, "", true));
return default;
}
Invoke(els_162, "forEach", Fn((V _arrowThis216, int _argc209, V e_215, V _a212, V _a213, V _a214, V[] _rest210) => {
return Invoke(e_215, "removeAttribute", ((V)("filter")));
}, 1, "", true));
Invoke(top_168, "setAttribute", ((V)("filter")), ((V)(JsStrBuf.Begin().S("url(#").V(id_163).S(")").End())));
return default;
}, 1, "bakeGrain", false);
addStates_47 = Fn((V _self217, int _argc218, V _a220, V _a221, V _a222, V _a223, V[] _rest219) => {
V AR_224 = default;
V ER_225 = default;
if (_self217.IsNullish) _self217 = GlobalV;
AR_224 = Fn((V _arrowThis233, int _argc226, V K_232, V _a229, V _a230, V _a231, V[] _rest227) => {
return NewObj(2).Put("armL", K_232).Put("armR", K_232).V;
}, 1, "", true);
ER_225 = Fn((V _arrowThis241, int _argc234, V K_240, V _a237, V _a238, V _a239, V[] _rest235) => {
return NewObj(2).Put("earL", K_240).Put("earR", K_240).V;
}, 1, "", true);
Object_assign(Get(Get(window_28, "RiveRig"), "PRE"), NewObj(5).Put("hopSweat", NewObj(8).Put("n", ((V)(1D))).Put("sp", ((V)(0D))).Put("vy", ((V)(6D))).Put("g", ((V)(34D))).Put("life", ((V)(950D))).Put("r", Arr(((V)(2.6)), ((V)(3D)))).Put("col", Arr(((V)("#8fd3ff")))).Put("kind", ((V)("drop"))).V).Put("hopDust", NewObj(8).Put("n", ((V)(7D))).Put("sp", ((V)(26D))).Put("vy", ((V)((-5D)))).Put("g", ((V)(10D))).Put("life", ((V)(620D))).Put("r", Arr(((V)(2D)), ((V)(3.6)))).Put("col", Arr(((V)("#ffffff")), ((V)("#fdf3ff")), ((V)("#efe4ff")))).Put("kind", ((V)("dot"))).V).Put("hopHeart", NewObj(7).Put("n", ((V)(1D))).Put("sp", ((V)(9D))).Put("vy", ((V)((-16D)))).Put("g", ((V)((-3D)))).Put("life", ((V)(1200D))).Put("r", Arr(((V)(1.6)), ((V)(2D)))).Put("kind", ((V)("heart"))).V).Put("hopSpark", NewObj(8).Put("n", ((V)(6D))).Put("sp", ((V)(30D))).Put("vy", ((V)((-10D)))).Put("g", ((V)(0D))).Put("life", ((V)(700D))).Put("r", Arr(((V)(3.2)), ((V)(5D)))).Put("col", Arr(((V)("#fff3a0")), ((V)("#ffffff")), ((V)("#ffd23a")))).Put("kind", ((V)("star"))).V).Put("hopPop", NewObj(7).Put("n", ((V)(6D))).Put("sp", ((V)(30D))).Put("vy", ((V)((-6D)))).Put("g", ((V)((-4D)))).Put("life", ((V)(560D))).Put("r", Arr(((V)(2.2)), ((V)(3.8)))).Put("kind", ((V)("bubble"))).V).V);
Invoke(Get(window_28, "RiveRig"), "add", NewObj(6).Put("hopSad", NewObj(3).Put("loop", ((V)(2400D))).Put("blend", ((V)(220D))).Put("k", NewObj(10).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.14))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)((-0.55)))))).Put("ly", Arr(Arr(((V)(0D)), ((V)(0.55))))).Put("frown", Arr(Arr(((V)(0D)), ((V)(1D))))).Put("teary", Arr(Arr(((V)(0D)), ((V)(0.7))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))))).Spread(Call(ER_225, V.Undef, Arr(Arr(((V)(0D)), ((V)((-18D))))))).Spread(Call(AR_224, V.Undef, Arr(Arr(((V)(0D)), ((V)((-14D))))))).Put("lean", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(600D)), ((V)((-2.4))), ((V)("s"))), Arr(((V)(1200D)), ((V)(0D)), ((V)("s"))), Arr(((V)(1800D)), ((V)(2.4)), ((V)("s"))), Arr(((V)(2400D)), ((V)(0D)), ((V)("s"))))).Put("tilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(600D)), ((V)((-3D))), ((V)("s"))), Arr(((V)(1200D)), ((V)(0D)), ((V)("s"))), Arr(((V)(1800D)), ((V)(3D)), ((V)("s"))), Arr(((V)(2400D)), ((V)(0D)), ((V)("s"))))).V).V).Put("hopSadLook", NewObj(4).Put("dur", ((V)(850D))).Put("blend", ((V)(160D))).Put("next", ((V)("hopSad"))).Put("k", NewObj(8).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)(0.14)), ((V)("o"))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)((-0.45))), ((V)("io"))))).Put("frown", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(1D)), ((V)("io"))))).Put("teary", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(400D)), ((V)(0.5)), ((V)("io"))))).Spread(Call(ER_225, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)((-18D))), ((V)("o")))))).Spread(Call(AR_224, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)((-14D))), ((V)("o")))))).Put("turn", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0D))), Arr(((V)(330D)), ((V)((-0.95))), ((V)("io"))), Arr(((V)(480D)), ((V)((-0.95)))), Arr(((V)(610D)), ((V)(0.95)), ((V)("io"))), Arr(((V)(760D)), ((V)(0.95))), Arr(((V)(850D)), ((V)(0D)), ((V)("io"))))).Put("lx", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0D))), Arr(((V)(300D)), ((V)((-1D))), ((V)("o"))), Arr(((V)(480D)), ((V)((-1D)))), Arr(((V)(580D)), ((V)(1D)), ((V)("io"))), Arr(((V)(760D)), ((V)(1D))), Arr(((V)(850D)), ((V)(0D)), ((V)("io"))))).V).V).Put("hopPerk", NewObj(3).Put("dur", ((V)(320D))).Put("blend", ((V)(90D))).Put("k", NewObj(4).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.08))), Arr(((V)(90D)), ((V)((-0.16))), ((V)("o"))), Arr(((V)(200D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(320D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(90D)), ((V)(3D)), ((V)("o"))), Arr(((V)(200D)), ((V)(0D)), ((V)("i"))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(320D)), ((V)(0D))))).Spread(Call(ER_225, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(90D)), ((V)(10D)), ((V)("o"))), Arr(((V)(320D)), ((V)(0D)), ((V)("io")))))).V).V).Put("hopGiggle", NewObj(3).Put("dur", ((V)(620D))).Put("blend", ((V)(90D))).Put("k", NewObj(6).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(80D)), ((V)(0.18)), ((V)("o"))), Arr(((V)(180D)), ((V)((-0.12))), ((V)("o"))), Arr(((V)(300D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(420D)), ((V)(0D)), ((V)("io"))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(80D)), ((V)(1D)), ((V)("o"))), Arr(((V)(520D)), ((V)(1D))), Arr(((V)(620D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(80D)), ((V)(1D))))).Put("blush", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(1D))), Arr(((V)(520D)), ((V)(1D))), Arr(((V)(620D)), ((V)(0D))))).Put("tilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)((-6D))), ((V)("io"))), Arr(((V)(260D)), ((V)(6D)), ((V)("io"))), Arr(((V)(400D)), ((V)((-3D))), ((V)("io"))), Arr(((V)(520D)), ((V)(0D)), ((V)("io"))))).Spread(Call(AR_224, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)(30D)), ((V)("o"))), Arr(((V)(400D)), ((V)(24D))), Arr(((V)(620D)), ((V)(0D)), ((V)("io")))))).V).V).Put("hopOops", NewObj(3).Put("dur", ((V)(560D))).Put("blend", ((V)(60D))).Put("k", NewObj(3).Put("wide", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(60D)), ((V)(1D)), ((V)("o"))), Arr(((V)(380D)), ((V)(1D))), Arr(((V)(560D)), ((V)(0D)), ((V)("io"))))).Put("frown", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(60D)), ((V)(0.8)), ((V)("o"))), Arr(((V)(400D)), ((V)(0.8))), Arr(((V)(560D)), ((V)(0D)), ((V)("io"))))).Spread(Call(ER_225, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(60D)), ((V)((-16D))), ((V)("o"))), Arr(((V)(420D)), ((V)((-10D)))), Arr(((V)(560D)), ((V)(0D)), ((V)("io")))))).V).V).Put("hopJoy", NewObj(3).Put("dur", ((V)(1300D))).Put("blend", ((V)(80D))).Put("k", NewObj(5).Put("hap", Arr(Arr(((V)(0D)), ((V)(1D))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(1D))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0.6))))).Put("blush", Arr(Arr(((V)(0D)), ((V)(0.6))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(18D)), ((V)("io"))), Arr(((V)(400D)), ((V)((-18D))), ((V)("io"))), Arr(((V)(600D)), ((V)(18D)), ((V)("io"))), Arr(((V)(800D)), ((V)((-18D))), ((V)("io"))), Arr(((V)(1000D)), ((V)(12D)), ((V)("io"))), Arr(((V)(1300D)), ((V)(0D)), ((V)("io"))))).V).V).V);
return default;
}, 0, "addStates", false);
mount_51 = Fn((V _self242, int _argc243, V c_249, V _a246, V _a247, V _a248, V[] _rest244) => {
if (_self242.IsNullish) _self242 = GlobalV;
Set(c_249, "el", Invoke(G("document"), "createElement", ((V)("div"))));
Set(Get(c_249, "el"), "className", ((V)("ch")));
Set(c_249, "inner", Invoke(G("document"), "createElement", ((V)("div"))));
Invoke(Get(c_249, "el"), "appendChild", Get(c_249, "inner"));
Invoke(board_37, "appendChild", Get(c_249, "el"));
Set(Get(Get(c_249, "el"), "style"), "opacity", ((V)("0")));
if (Truthy(Get(window_28, "__rgI"))) {
DeleteK(Get(window_28, "__rgI"), Get(c_249, "key"));
}
Set(c_249, "ctrl", Invoke(Get(window_28, "RiveRig"), "mount", Get(c_249, "inner"), Get(c_249, "key"), NewObj(1).Put("fidgets", (false ? V.True : V.False)).V));
Set(c_249, "I", Get(Get(c_249, "ctrl"), "_I"));
Set(c_249, "t0", Invoke(G("performance"), "now"));
return default;
}, 1, "mount", false);
measure_52 = Fn((V _self250, int _argc251, V c_257, V _a254, V _a255, V _a256, V[] _rest252) => {
V svg_258 = default;
V sh_259 = default;
V b_260 = default;
if (_self250.IsNullish) _self250 = GlobalV;
svg_258 = Invoke(Get(c_257, "inner"), "querySelector", ((V)("svg")));
if (!(Truthy(svg_258))) {
return V.Null;
}
sh_259 = new ArrBuilder().Spread(Invoke(svg_258, "querySelectorAll", ((V)("ellipse[fill=\"#6a1b9a\"]")))).V;
Invoke(sh_259, "forEach", Fn((V _arrowThis268, int _argc261, V e_267, V _a264, V _a265, V _a266, V[] _rest262) => {
return Set(Get(e_267, "style"), "display", ((V)("none")));
}, 1, "", true));
b_260 = V.Null;
try {
b_260 = Invoke(svg_258, "getBBox");
} catch (System.Exception _ex269) {
V e_270 = default;
e_270 = Caught(_ex269);

}
Invoke(sh_259, "forEach", Fn((V _arrowThis278, int _argc271, V e_277, V _a274, V _a275, V _a276, V[] _rest272) => {
return Set(Get(e_277, "style"), "display", ((V)("")));
}, 1, "", true));
if ((!(Truthy(b_260)) || !(GtN(Get(b_260, "width"), 1D)))) {
return V.Null;
}
return NewObj(4).Put("cx", Add(Get(b_260, "x"), ((V)((ToNum(Get(b_260, "width")) / 2D))))).Put("gy", Add(Get(b_260, "y"), Get(b_260, "height"))).Put("bw", Get(b_260, "width")).Put("top", Get(b_260, "y")).V;
return default;
}, 1, "measure", false);
ready_53 = Fn((V _self279, int _argc280, V c_286, V _a283, V _a284, V _a285, V[] _rest281) => {
V bb_287 = default;
if (_self279.IsNullish) _self279 = GlobalV;
if (Truthy(Get(c_286, "bb"))) {
return (true ? V.True : V.False);
}
if (!(Truthy(Get(c_286, "I")))) {
return (false ? V.True : V.False);
}
if (Truthy((Get(Get(c_286, "I"), "generic") is var _t288 && !Truthy(_t288) ? _t288 : (!(Truthy(Get(Get(c_286, "I"), "ready"))) ? V.True : V.False)))) {
return (false ? V.True : V.False);
}
Invoke(Get(c_286, "ctrl"), "_pose", ((V)("idle")), ((V)(0D)));
bb_287 = Call(measure_52, V.Undef, c_286);
if (!(Truthy(bb_287))) {
return (false ? V.True : V.False);
}
Set(c_286, "bb", bb_287);
Call(bakeGrain_46, V.Undef, Invoke(Get(c_286, "inner"), "querySelector", ((V)("svg"))));
return (true ? V.True : V.False);
return default;
}, 1, "ready", false);
draw_54 = Fn((V _self289, int _argc290, V c_296, V now_297, V _a294, V _a295, V[] _rest291) => {
V m_298 = default;
double s_299 = 0;
double k_300 = 0;
V x_301 = default;
V y_302 = default;
double o_303 = 0;
if (_self289.IsNullish) _self289 = GlobalV;
if ((!(Truthy(Get(c_296, "bb"))) || !(Truthy(Get(c_296, "el"))))) {
return default;
}
m_298 = (Get(c_296, "cur") is var _t304 && Truthy(_t304) ? _t304 : NewObj(0).V);
s_299 = ((ToNum(Get(c_296, "s")) * ToNum((Get(m_298, "k").IsNullish ? ((V)(1D)) : Get(m_298, "k")))) * ToNum((Get(c_296, "k").IsNullish ? ((V)(1D)) : Get(c_296, "k"))));
k_300 = ((ToNum(Get(c_296, "W")) * s_299) / ToNum(Get(Get(c_296, "bb"), "bw")));
x_301 = Add(Get(c_296, "x"), (Get(m_298, "dx") is var _t305 && Truthy(_t305) ? _t305 : ((V)(0D))));
y_302 = Add(Get(c_296, "y"), (Get(m_298, "dy") is var _t306 && Truthy(_t306) ? _t306 : ((V)(0D))));
Set(Get(Get(c_296, "el"), "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").V(Invoke(((V)((ToNum(x_301) - (ToNum(Get(Get(c_296, "bb"), "cx")) * k_300)))), "toFixed", ((V)(2D)))).S("px,").V(Invoke(((V)((ToNum(y_302) - (ToNum(Get(Get(c_296, "bb"), "gy")) * k_300)))), "toFixed", ((V)(2D)))).S("px) scale(").V(Invoke(((V)(k_300)), "toFixed", ((V)(4D)))).S(")").End())));
Set(Get(Get(c_296, "el"), "style"), "zIndex", ((V)(ToStrS((!Get(m_298, "z").IsNullish ? Get(m_298, "z") : Get(c_296, "z"))))));
o_303 = (ToNum(Get(c_296, "o")) * ToNum((Get(m_298, "o").IsNullish ? ((V)(1D)) : Get(m_298, "o"))));
Set(Get(Get(c_296, "el"), "style"), "opacity", ((V)(ToStrS(((V)((Round((o_303 * 100D)) / 100D)))))));
Set(c_296, "kNow", ((V)(k_300)));
return default;
}, 2, "draw", false);
start_55 = Fn((V _self307, int _argc308, V c_314, V mv_315, V _a312, V _a313, V[] _rest309) => {
if (_self307.IsNullish) _self307 = GlobalV;
Set(mv_315, "t0", Add(Invoke(G("performance"), "now"), (Get(mv_315, "delay") is var _t316 && Truthy(_t316) ? _t316 : ((V)(0D)))));
Invoke(Get(c_314, "moves"), "push", mv_315);
Call(kick_69, V.Undef);
return mv_315;
return default;
}, 2, "start", false);
stopMoves_56 = Fn((V _self317, int _argc318, V c_324, V kind_325, V _a322, V _a323, V[] _rest319) => {
if (_self317.IsNullish) _self317 = GlobalV;
Set(c_324, "moves", Invoke(Get(c_324, "moves"), "filter", Fn((V _arrowThis333, int _argc326, V m_332, V _a329, V _a330, V _a331, V[] _rest327) => {
return ((Truthy(kind_325) ? !SEq(Get(m_332, "kind"), kind_325) : false) ? V.True : V.False);
}, 1, "", true)));
return default;
}, 2, "stopMoves", false);
leg_60 = Fn((V _self334, int _argc335, V c_341, V L_342, V from_343, V dir_344, V[] _rest336) => {
V D_346 = default;
double hold_347 = 0;
V H_348 = default;
V dx_349 = default;
V dy_350 = default;
V ease_351 = default;
V crouch_352 = default;
V arms_353 = default;
V lean_354 = default;
V onDone_345 = default;
if (_self334.IsNullish) _self334 = GlobalV;
onDone_345 = (_argc335 > 4 ? _rest336[0] : V.Undef);
D_346 = Get(L_342, "ms");
hold_347 = (Truthy(Get(L_342, "boing")) ? SPRING_59 : CROUCH_58);
H_348 = Get(L_342, "h");
dx_349 = (Truthy(GetK(DIRS_63, dir_344)) ? GetIdx(GetK(DIRS_63, dir_344), 0D) : ((V)(0D)));
dy_350 = (Truthy(GetK(DIRS_63, dir_344)) ? GetIdx(GetK(DIRS_63, dir_344), 1D) : ((V)(0D)));
ease_351 = Fn((V _arrowThis362, int _argc355, V u_361, V _a358, V _a359, V _a360, V[] _rest356) => {
return (LeN(u_361, (hold_347 * 0.8)) ? ((V)(0D)) : Call(SM_40, V.Undef, ((V)(((ToNum(u_361) - (hold_347 * 0.8)) / (1D - (hold_347 * 0.8)))))));
}, 1, "", true);
crouch_352 = (Truthy(Get(L_342, "boing")) ? Arr(Arr(((V)(0D)), ((V)(0.45))), Arr(((V)((ToNum(D_346) * SPRING_59))), ((V)(0.4)), ((V)("o"))), Arr(((V)((ToNum(D_346) * (SPRING_59 + 0.1)))), ((V)((-0.42))), ((V)("o"))), Arr(((V)((ToNum(D_346) * 0.45))), ((V)((-0.18))), ((V)("io"))), Arr(((V)((ToNum(D_346) * 0.6))), ((V)(0.12)), ((V)("io"))), Arr(((V)((ToNum(D_346) * 0.75))), ((V)((-0.12))), ((V)("io"))), Arr(((V)((ToNum(D_346) * 0.9))), ((V)(0.06)), ((V)("io"))), Arr(D_346, ((V)((-0.14))), ((V)("io")))) : Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_346) * 0.2))), ((V)(0.24)), ((V)("io"))), Arr(((V)((ToNum(D_346) * 0.34))), ((V)((-0.3))), ((V)("o"))), Arr(((V)((ToNum(D_346) * 0.55))), ((V)((-0.1))), ((V)("io"))), Arr(((V)((ToNum(D_346) * 0.86))), ((V)((-0.2))), ((V)("io"))), Arr(D_346, ((V)((-0.12))), ((V)("io")))));
arms_353 = (Truthy(Get(L_342, "boing")) ? Arr(Arr(((V)(0D)), ((V)((-10D)))), Arr(((V)((ToNum(D_346) * 0.3))), ((V)(46D)), ((V)("o"))), Arr(((V)((ToNum(D_346) * 0.8))), ((V)(30D)), ((V)("io"))), Arr(D_346, ((V)(20D)), ((V)("io")))) : Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_346) * 0.2))), ((V)((-14D))), ((V)("io"))), Arr(((V)((ToNum(D_346) * 0.36))), ((V)(40D)), ((V)("o"))), Arr(((V)((ToNum(D_346) * 0.75))), ((V)(28D)), ((V)("io"))), Arr(D_346, ((V)(18D)), ((V)("io")))));
lean_354 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_346) * 0.2))), ((V)((-0.4))), ((V)("io"))), Arr(((V)((ToNum(D_346) * 0.38))), ((V)(1D)), ((V)("o"))), Arr(((V)((ToNum(D_346) * 0.7))), ((V)(0.55)), ((V)("io"))), Arr(D_346, ((V)(0.15)), ((V)("io"))));
return Call(start_55, V.Undef, c_341, NewObj(4).Put("kind", ((V)("hop"))).Put("dur", D_346).Put("run", Fn((V _self363, int _argc364, V c_370, V t_371, V _a368, V _a369, V[] _rest365) => {
V u_372 = default;
V e_373 = default;
double air_374 = 0;
V ln_375 = default;
if (_self363.IsNullish) _self363 = GlobalV;
u_372 = Call(clamp_38, V.Undef, ((V)((ToNum(t_371) / ToNum(D_346)))), ((V)(0D)), ((V)(1D)));
e_373 = Call(ease_351, V.Undef, u_372);
Set(c_370, "x", Call(lerp_39, V.Undef, Get(from_343, "x"), Get(L_342, "x"), e_373));
Set(c_370, "y", Call(lerp_39, V.Undef, Get(from_343, "y"), Get(L_342, "y"), e_373));
Set(c_370, "s", Call(lerp_39, V.Undef, Get(from_343, "s"), Get(L_342, "s"), e_373));
air_374 = (ToNum(Call(parab_42, V.Undef, ((V)(((ToNum(u_372) - hold_347) / (1D - hold_347)))))) * (Truthy(Get(L_342, "boing")) ? 1.2 : 1D));
ln_375 = Call(kv_41, V.Undef, lean_354, t_371);
return NewObj(2).Put("z", ((V)(Max(ToNum(Get(from_343, "z")), ToNum(Get(L_342, "z")))))).Put("ext", NewObj(8).Put("lift", Call(toU_57, V.Undef, c_370, ((V)((ToNum(H_348) * air_374))))).Put("sq", Call(kv_41, V.Undef, crouch_352, t_371)).Put("armL", Call(kv_41, V.Undef, arms_353, t_371)).Put("armR", Call(kv_41, V.Undef, arms_353, t_371)).Put("tilt", ((V)(((ToNum(ln_375) * 11D) * ToNum(dx_349))))).Put("lean", ((V)(((ToNum(ln_375) * 3D) * ToNum(dx_349))))).Put("pitch", ((V)((((-ToNum(ln_375)) * 0.55) * ToNum(dy_350))))).Put("ly", ((V)(((ToNum(ln_375) * 0.7) * ToNum(dy_350))))).V).V;
return default;
}, 2, "run", false)).Put("done", onDone_345).V);
return default;
}, 5, "leg", false);
land_61 = Fn((V _self376, int _argc377, V c_383, V _a380, V _a381, V _a382, V[] _rest378) => {
double D_384 = 0;
V sq_385 = default;
V arms_386 = default;
if (_self376.IsNullish) _self376 = GlobalV;
D_384 = 400D;
sq_385 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(40D)), ((V)(0.3)), ((V)("o"))), Arr(((V)(140D)), ((V)((-0.14))), ((V)("io"))), Arr(((V)(240D)), ((V)(0.07)), ((V)("io"))), Arr(((V)(330D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(D_384)), ((V)(0D)), ((V)("io"))));
arms_386 = Arr(Arr(((V)(0D)), ((V)(18D))), Arr(((V)(60D)), ((V)((-18D))), ((V)("o"))), Arr(((V)(200D)), ((V)(10D)), ((V)("io"))), Arr(((V)(D_384)), ((V)(0D)), ((V)("io"))));
Call(stopMoves_56, V.Undef, c_383, ((V)("land")));
if (Truthy((Get(c_383, "I") is var _t387 && !Truthy(_t387) ? _t387 : Get(c_383, "bb")))) {
Call(burst_66, V.Undef, c_383, ((V)("hopDust")), ((V)("feet")));
}
Call(start_55, V.Undef, c_383, NewObj(3).Put("kind", ((V)("land"))).Put("dur", ((V)(D_384))).Put("run", Fn((V _self388, int _argc389, V c_395, V t_396, V _a393, V _a394, V[] _rest390) => {
if (_self388.IsNullish) _self388 = GlobalV;
return NewObj(1).Put("ext", NewObj(3).Put("sq", Call(kv_41, V.Undef, sq_385, t_396)).Put("armL", Call(kv_41, V.Undef, arms_386, t_396)).Put("armR", Call(kv_41, V.Undef, arms_386, t_396)).V).V;
return default;
}, 2, "run", false)).V);
return default;
}, 1, "land", false);
faceTo_62 = Fn((V _self397, int _argc398, V c_404, V dir_405, V _a402, V _a403, V[] _rest399) => {
V to_406 = default;
V from_407 = default;
if (_self397.IsNullish) _self397 = GlobalV;
to_406 = (SEqN(dir_405, 1D) ? ((V)(0.55)) : (SEqN(dir_405, 3D) ? ((V)((-0.55))) : ((SEqN(dir_405, 0D) || SEqN(dir_405, 2D)) ? ((V)(0D)) : Get(c_404, "face"))));
if (SEq(to_406, Get(c_404, "face"))) {
return default;
}
from_407 = Get(c_404, "face");
Set(c_404, "face", to_406);
Call(stopMoves_56, V.Undef, c_404, ((V)("face")));
Call(start_55, V.Undef, c_404, NewObj(4).Put("kind", ((V)("face"))).Put("dur", ((V)(140D))).Put("keep", (true ? V.True : V.False)).Put("run", Fn((V _self408, int _argc409, V c_415, V t_416, V _a413, V _a414, V[] _rest410) => {
if (_self408.IsNullish) _self408 = GlobalV;
Set(c_415, "faceNow", Call(lerp_39, V.Undef, from_407, to_406, Call(SM_40, V.Undef, ((V)((ToNum(t_416) / 140D))))));
return NewObj(0).V;
return default;
}, 2, "run", false)).V);
return default;
}, 2, "faceTo", false);
hearts_65 = Fn((V _self417, int _argc418, V c_424, V n_425, V every_426, V _a423, V[] _rest419) => {
if (_self417.IsNullish) _self417 = GlobalV;
{
double i_427 = 0;
i_427 = 0D;
while (true) {
if (!(Lt(((V)(i_427)), n_425))) break;
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis443, int _argc437, V _a439, V _a440, V _a441, V _a442, V[] _rest438) => {
if (Truthy((Get(c_424, "I") is var _t444 && !Truthy(_t444) ? _t444 : Get(c_424, "bb")))) {
Call(burst_66, V.Undef, c_424, ((V)("hopHeart")), ((V)("head")), ((V)(1D)));
}
return default;
}, 0, "", true), ((V)((i_427 * ToNum(every_426)))));
i_427++;
}
}
return default;
}, 3, "hearts", false);
burst_66 = Fn((V _self445, int _argc446, V c_452, V kind_453, V where_454, V n_455, V[] _rest447) => {
V b_456 = default;
V W_457 = default;
V p_458 = default;
if (_self445.IsNullish) _self445 = GlobalV;
b_456 = Get(c_452, "bb");
W_457 = (Get(Get(c_452, "I"), "W") is var _t459 && Truthy(_t459) ? _t459 : NewObj(0).V);
p_458 = (SEqS(where_454, "feet") ? Arr(Get(b_456, "cx"), ((V)((ToNum(Get(b_456, "gy")) - 2D)))) : (SEqS(where_454, "head") ? Arr(Get(b_456, "cx"), Add(Get(b_456, "top"), ((V)(4D)))) : (SEqS(where_454, "temple") ? Arr(Add(Get(b_456, "cx"), ((V)((ToNum(Get(b_456, "bw")) * 0.34)))), Add(Get(b_456, "top"), ((V)((ToNum(Get(b_456, "bw")) * 0.2))))) : (GetK(W_457, where_454) is var _t460 && Truthy(_t460) ? _t460 : Arr(((V)(50D)), ((V)(50D)))))));
try {
V e_461 = default;
e_461 = Get(Get(window_28, "RiveRig"), "emit");
if (Truthy(e_461)) {
Call(e_461, V.Undef, Get(c_452, "I"), kind_453, p_458, n_455);
}
} catch (System.Exception _ex462) {
V x_463 = default;
x_463 = Caught(_ex462);

}
return default;
}, 4, "burst", false);
frame_68 = Fn((V _self464, int _argc465, V _a467, V _a468, V _a469, V _a470, V[] _rest466) => {
V now_471 = default;
V busy_472 = default;
V allReady_473 = default;
if (_self464.IsNullish) _self464 = GlobalV;
now_471 = Invoke(G("performance"), "now");
busy_472 = (false ? V.True : V.False);
allReady_473 = (true ? V.True : V.False);
{
foreach (V _k474 in new JsIter(Invoke(C_48, "values"))) {
V c_475 = default;
c_475 = _k474;
V ext_476 = default;
V cur_477 = default;
V list_478 = default;
V kept_479 = default;
if (!(Truthy(Call(ready_53, V.Undef, c_475)))) {
if (((((ToNum(now_471) - ToNum(Get(c_475, "t0"))) > 9000D) && !castTag_50.IsNullish) && !SEq(Get(api_64, "_sent"), castTag_50))) {
Set(api_64, "_sent", castTag_50);
Call(post_36, V.Undef, NewObj(4).Put("type", ((V)("cast"))).Put("tag", castTag_50).Put("ok", (false ? V.True : V.False)).Put("key", Get(c_475, "key")).V);
}
allReady_473 = (false ? V.True : V.False);
busy_472 = (((ToNum(now_471) - ToNum(Get(c_475, "t0"))) < 9000D) ? V.True : V.False);
continue;
}
ext_476 = NewObj(0).V;
cur_477 = NewObj(2).Put("dx", ((V)(0D))).Put("dy", ((V)(0D))).V;
list_478 = Get(c_475, "moves");
Set(c_475, "moves", Arr());
kept_479 = Invoke(list_478, "filter", Fn((V _arrowThis487, int _argc480, V m_486, V _a483, V _a484, V _a485, V[] _rest481) => {
double t_488 = 0;
V r_489 = default;
t_488 = (ToNum(now_471) - ToNum(Get(m_486, "t0")));
if ((t_488 < 0D)) {
if (Truthy(Get(m_486, "before"))) {
cur_477 = Object_assign(cur_477, Get(m_486, "before"));
}
return (true ? V.True : V.False);
}
if (Ge(((V)(t_488)), Get(m_486, "dur"))) {
if (Truthy(Get(m_486, "run"))) {
Invoke(m_486, "run", c_475, Get(m_486, "dur"));
}
if (Truthy(Get(m_486, "done"))) {
Invoke(m_486, "done");
}
return (false ? V.True : V.False);
}
r_489 = (Invoke(m_486, "run", c_475, ((V)(t_488))) is var _t490 && Truthy(_t490) ? _t490 : NewObj(0).V);
if (Truthy(Get(r_489, "dx"))) {
OpSet(cur_477, "dx", 0, Get(r_489, "dx"));
}
if (Truthy(Get(r_489, "dy"))) {
OpSet(cur_477, "dy", 0, Get(r_489, "dy"));
}
if (!Get(r_489, "k").IsNullish) {
Set(cur_477, "k", ((V)((ToNum((Get(cur_477, "k").IsNullish ? ((V)(1D)) : Get(cur_477, "k"))) * ToNum(Get(r_489, "k"))))));
}
if (!Get(r_489, "o").IsNullish) {
Set(cur_477, "o", ((V)((ToNum((Get(cur_477, "o").IsNullish ? ((V)(1D)) : Get(cur_477, "o"))) * ToNum(Get(r_489, "o"))))));
}
if (!Get(r_489, "z").IsNullish) {
Set(cur_477, "z", Get(r_489, "z"));
}
if (Truthy(Get(r_489, "ext"))) {
{
foreach (V _k491 in ForInKeys(Get(r_489, "ext"))) {
V k_492 = default;
k_492 = _k491;
SetK(ext_476, k_492, Add((GetK(ext_476, k_492) is var _t493 && Truthy(_t493) ? _t493 : ((V)(0D))), GetK(Get(r_489, "ext"), k_492)));
}
}
}
return (true ? V.True : V.False);
return default;
}, 1, "", true));
Set(c_475, "moves", Invoke(kept_479, "concat", Get(c_475, "moves")));
if (Truthy(Get(Get(c_475, "moves"), "length"))) {
busy_472 = (true ? V.True : V.False);
}
Set(ext_476, "turn", Add((Get(ext_476, "turn") is var _t494 && Truthy(_t494) ? _t494 : ((V)(0D))), Get(c_475, "faceNow")));
if (!Get(ext_476, "sq").IsNullish) {
Set(ext_476, "sq", Call(clamp_38, V.Undef, Get(ext_476, "sq"), ((V)((-0.45))), ((V)(0.4))));
}
Set(c_475, "cur", cur_477);
if (Truthy(Get(c_475, "ctrl"))) {
Invoke(Get(c_475, "ctrl"), "ext", ext_476);
}
Call(draw_54, V.Undef, c_475, now_471);
}
}
if (Truthy((((allReady_473 is var _t495 && !Truthy(_t495) ? _t495 : (!castTag_50.IsNullish ? V.True : V.False)) is var _t496 && !Truthy(_t496) ? _t496 : Get(C_48, "size")) is var _t497 && !Truthy(_t497) ? _t497 : (!(Truthy(Get(api_64, "_sent"))) ? V.True : V.False)))) {
Set(api_64, "_sent", castTag_50);
Call(post_36, V.Undef, NewObj(3).Put("type", ((V)("cast"))).Put("tag", castTag_50).Put("ok", (true ? V.True : V.False)).V);
}
if (Truthy(busy_472)) {
Call(G("requestAnimationFrame"), V.Undef, frame_68);
} else {
running_67 = (false ? V.True : V.False);
}
return default;
}, 0, "frame", false);
kick_69 = Fn((V _self498, int _argc499, V _a501, V _a502, V _a503, V _a504, V[] _rest500) => {
if (_self498.IsNullish) _self498 = GlobalV;
if (!(Truthy(running_67))) {
running_67 = (true ? V.True : V.False);
Call(G("requestAnimationFrame"), V.Undef, frame_68);
}
return default;
}, 0, "kick", false);
post_36 = Fn((V _arrowThis512, int _argc505, V m_511, V _a508, V _a509, V _a510, V[] _rest506) => {
V s_513 = default;
s_513 = Invoke(G("JSON"), "stringify", m_511);
if (Truthy(Get(window_28, "ReactNativeWebView"))) {
Invoke(Get(window_28, "ReactNativeWebView"), "postMessage", s_513);
} else {
Invoke(Set(window_28, "__hopOut", (Get(window_28, "__hopOut") is var _t514 && Truthy(_t514) ? _t514 : Arr())), "push", m_511);
}
return default;
}, 1, "", true);
board_37 = Invoke(G("document"), "getElementById", ((V)("board")));
clamp_38 = Fn((V _arrowThis524, int _argc515, V v_521, V a_522, V b_523, V _a520, V[] _rest516) => {
return ((V)(Max(ToNum(a_522), Min(ToNum(b_523), ToNum(v_521)))));
}, 3, "", true);
lerp_39 = Fn((V _arrowThis534, int _argc525, V a_531, V b_532, V t_533, V _a530, V[] _rest526) => {
return Add(a_531, ((V)(((ToNum(b_532) - ToNum(a_531)) * ToNum(t_533)))));
}, 3, "", true);
SM_40 = Fn((V _arrowThis542, int _argc535, V x_541, V _a538, V _a539, V _a540, V[] _rest536) => {
x_541 = Call(clamp_38, V.Undef, x_541, ((V)(0D)), ((V)(1D)));
return ((V)(((ToNum(x_541) * ToNum(x_541)) * (3D - (2D * ToNum(x_541))))));
return default;
}, 1, "", true);
kv_41 = V.Null;
parab_42 = Fn((V _arrowThis550, int _argc543, V u_549, V _a546, V _a547, V _a548, V[] _rest544) => {
return ((V)(((LeN(u_549, 0D) || GeN(u_549, 1D)) ? 0D : ((4D * ToNum(u_549)) * (1D - ToNum(u_549))))));
}, 1, "", true);
FAB_43 = V.Null;
isGrain_45 = Fn((V _arrowThis558, int _argc551, V f_557, V _a554, V _a555, V _a556, V[] _rest552) => {
return (((f_557 is var _t559 && !Truthy(_t559) ? _t559 : Invoke(f_557, "querySelector", ((V)("feTurbulence")))) is var _t560 && !Truthy(_t560) ? _t560 : (!(Truthy(Invoke(f_557, "querySelector", ((V)("feDisplacementMap"))))) ? V.True : V.False)) is var _t561 && !Truthy(_t561) ? _t561 : Invoke(f_557, "querySelector", ((V)("feBlend[mode=\"multiply\"]"))));
}, 1, "", true);
C_48 = New(G("Map"));
origin_49 = Arr(((V)(0D)), ((V)(0D)));
castTag_50 = V.Null;
toU_57 = Fn((V _arrowThis570, int _argc562, V c_568, V dp_569, V _a566, V _a567, V[] _rest563) => {
return ((V)((Truthy(Get(c_568, "kNow")) ? (ToNum(dp_569) / ToNum(Get(c_568, "kNow"))) : 0D)));
}, 2, "", true);
CROUCH_58 = 0.24;
SPRING_59 = 0.18;
DIRS_63 = Arr(Arr(((V)(0D)), ((V)((-1D)))), Arr(((V)(1D)), ((V)(0D))), Arr(((V)(0D)), ((V)(1D))), Arr(((V)((-1D))), ((V)(0D))));
api_64 = NewObj(14).Put("origin", Fn((V _self571, int _argc572, V x_578, V y_579, V _a576, V _a577, V[] _rest573) => {
if (_self571.IsNullish) _self571 = GlobalV;
origin_49 = Arr(x_578, y_579);
return default;
}, 2, "origin", false)).Put("cast", Fn((V _self580, int _argc581, V list_587, V tag_588, V _a585, V _a586, V[] _rest582) => {
V ids_589 = default;
if (_self580.IsNullish) _self580 = GlobalV;
castTag_50 = tag_588;
ids_589 = New(G("Set"), Invoke(list_587, "map", Fn((V _arrowThis597, int _argc590, V c_596, V _a593, V _a594, V _a595, V[] _rest591) => {
return Get(c_596, "id");
}, 1, "", true)));
{
foreach (V _k598 in new JsIter(C_48)) {
V id_599 = default;
V c_600 = default;
{ V _t601 = ListOf(_k598);
{ V _t602 = GetIdx(_t601, 0D);
id_599 = _t602; }
{ V _t603 = GetIdx(_t601, 1D);
c_600 = _t603; }
}
if (!(Truthy(Invoke(ids_589, "has", id_599)))) {
if (Truthy(Get(c_600, "ctrl"))) {
Invoke(Get(c_600, "ctrl"), "destroy");
}
if (Truthy(Get(c_600, "el"))) {
Invoke(Get(c_600, "el"), "remove");
}
Invoke(C_48, "delete", id_599);
}
}
}
{
foreach (V _k604 in new JsIter(list_587)) {
V it_605 = default;
it_605 = _k604;
V c_606 = default;
c_606 = Invoke(C_48, "get", Get(it_605, "id"));
if (Truthy((c_606 is var _t607 && !Truthy(_t607) ? _t607 : (!SEq(Get(c_606, "key"), Get(it_605, "key")) ? V.True : V.False)))) {
if (Truthy(Get(c_606, "ctrl"))) {
Invoke(Get(c_606, "ctrl"), "destroy");
}
if (Truthy(Get(c_606, "el"))) {
Invoke(Get(c_606, "el"), "remove");
}
Invoke(C_48, "delete", Get(it_605, "id"));
c_606 = V.Null;
}
if (!(Truthy(c_606))) {
c_606 = NewObj(7).Put("id", Get(it_605, "id")).Put("key", Get(it_605, "key")).Put("moves", Arr()).Put("face", ((V)(0D))).Put("faceNow", ((V)(0D))).Put("o", ((V)(1D))).Put("k", ((V)(1D))).V;
Invoke(C_48, "set", Get(it_605, "id"), c_606);
Call(mount_51, V.Undef, c_606);
}
Object_assign(c_606, NewObj(6).Put("W", Get(it_605, "W")).Put("x", Add(Get(it_605, "x"), GetIdx(origin_49, 0D))).Put("y", Add(Get(it_605, "y"), GetIdx(origin_49, 1D))).Put("s", Get(it_605, "s")).Put("z", Get(it_605, "z")).Put("o", (Get(it_605, "o").IsNullish ? ((V)(1D)) : Get(it_605, "o"))).V);
Set(c_606, "moves", Arr());
Set(c_606, "cur", V.Null);
}
}
Call(kick_69, V.Undef);
return default;
}, 2, "cast", false)).Put("place", Fn((V _self608, int _argc609, V id_615, V p_616, V _a613, V _a614, V[] _rest610) => {
V c_617 = default;
if (_self608.IsNullish) _self608 = GlobalV;
c_617 = Invoke(C_48, "get", id_615);
if (!(Truthy(c_617))) {
return default;
}
Set(c_617, "moves", Invoke(Get(c_617, "moves"), "filter", Fn((V _arrowThis625, int _argc618, V m_624, V _a621, V _a622, V _a623, V[] _rest619) => {
return Get(m_624, "keep");
}, 1, "", true)));
Object_assign(c_617, NewObj(4).Put("x", Add(Get(p_616, "x"), GetIdx(origin_49, 0D))).Put("y", Add(Get(p_616, "y"), GetIdx(origin_49, 1D))).Put("s", Get(p_616, "s")).Put("z", Get(p_616, "z")).V);
if (!Get(p_616, "o").IsNullish) {
Set(c_617, "o", Get(p_616, "o"));
}
Set(c_617, "k", ((V)(1D)));
Call(kick_69, V.Undef);
return default;
}, 2, "place", false)).Put("show", Fn((V _self626, int _argc627, V id_633, V o_634, V _a631, V _a632, V[] _rest628) => {
V c_635 = default;
if (_self626.IsNullish) _self626 = GlobalV;
c_635 = Invoke(C_48, "get", id_633);
if (Truthy(c_635)) {
Set(c_635, "o", o_634);
Call(kick_69, V.Undef);
}
return default;
}, 2, "show", false)).Put("enter", Fn((V _self636, int _argc637, V id_643, V p_644, V delay_645, V pop_646, V[] _rest638) => {
V c_647 = default;
double D_648 = 0;
if (_self636.IsNullish) _self636 = GlobalV;
c_647 = Invoke(C_48, "get", id_643);
if (!(Truthy(c_647))) {
return default;
}
Call(G("clearInterval"), V.Undef, Get(c_647, "sweat"));
Set(c_647, "moves", Arr());
Object_assign(c_647, NewObj(8).Put("x", Add(Get(p_644, "x"), GetIdx(origin_49, 0D))).Put("y", Add(Get(p_644, "y"), GetIdx(origin_49, 1D))).Put("s", Get(p_644, "s")).Put("z", Get(p_644, "z")).Put("o", ((V)(1D))).Put("k", ((V)(1D))).Put("face", ((V)(0D))).Put("faceNow", ((V)(0D))).V);
if (Truthy(Get(c_647, "ctrl"))) {
Invoke(Get(c_647, "ctrl"), "play", ((V)("idle")));
}
D_648 = (Truthy(pop_646) ? 340D : 460D);
Call(start_55, V.Undef, c_647, NewObj(5).Put("kind", ((V)("enter"))).Put("delay", delay_645).Put("dur", ((V)(D_648))).Put("before", NewObj(1).Put("o", ((V)(0D))).V).Put("run", Fn((V _self649, int _argc650, V c_656, V t_657, V _a654, V _a655, V[] _rest651) => {
V fall_658 = default;
if (_self649.IsNullish) _self649 = GlobalV;
if (Truthy(pop_646)) {
double u_659 = 0;
u_659 = (ToNum(t_657) / D_648);
return NewObj(3).Put("k", ((V)((0.3 + (0.7 * ToNum(Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((D_648 * 0.7))), ((V)(1.12)), ((V)("o"))), Arr(((V)(D_648)), ((V)(1D)), ((V)("io")))), t_657))))))).Put("o", Call(clamp_38, V.Undef, ((V)((u_659 * 3D))), ((V)(0D)), ((V)(1D)))).Put("ext", NewObj(1).Put("sq", Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((D_648 * 0.5))), ((V)((-0.2))), ((V)("o"))), Arr(((V)((D_648 * 0.8))), ((V)(0.1)), ((V)("io"))), Arr(((V)(D_648)), ((V)(0D)), ((V)("io")))), t_657)).V).V;
}
fall_658 = Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)((D_648 * 0.62))), ((V)(0D)), ((V)("i"))), Arr(((V)(D_648)), ((V)(0D)))), t_657);
return NewObj(2).Put("o", Call(clamp_38, V.Undef, ((V)((ToNum(t_657) / 120D))), ((V)(0D)), ((V)(1D)))).Put("ext", NewObj(4).Put("lift", ((V)((ToNum(Call(toU_57, V.Undef, c_656, ((V)((90D * ToNum(Get(c_656, "s"))))))) * ToNum(fall_658))))).Put("sq", Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)((-0.2)))), Arr(((V)((D_648 * 0.62))), ((V)((-0.25))), ((V)("i"))), Arr(((V)((D_648 * 0.7))), ((V)(0.4)), ((V)("o"))), Arr(((V)((D_648 * 0.85))), ((V)((-0.1))), ((V)("io"))), Arr(((V)(D_648)), ((V)(0D)), ((V)("io")))), t_657)).Put("armL", Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(40D))), Arr(((V)((D_648 * 0.62))), ((V)(40D))), Arr(((V)((D_648 * 0.75))), ((V)((-14D))), ((V)("o"))), Arr(((V)(D_648)), ((V)(0D)), ((V)("io")))), t_657)).Put("armR", Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(40D))), Arr(((V)((D_648 * 0.62))), ((V)(40D))), Arr(((V)((D_648 * 0.75))), ((V)((-14D))), ((V)("o"))), Arr(((V)(D_648)), ((V)(0D)), ((V)("io")))), t_657)).V).V;
return default;
}, 2, "run", false)).V);
return default;
}, 4, "enter", false)).Put("hop", Fn((V _self660, int _argc661, V id_667, V legs_668, V dir_669, V _a666, V[] _rest662) => {
V c_670 = default;
double i_671 = 0;
V next_672 = default;
if (_self660.IsNullish) _self660 = GlobalV;
c_670 = Invoke(C_48, "get", id_667);
if (!(Truthy(c_670))) {
return default;
}
Set(c_670, "moves", Invoke(Get(c_670, "moves"), "filter", Fn((V _arrowThis680, int _argc673, V m_679, V _a676, V _a677, V _a678, V[] _rest674) => {
return ((SEqS(Get(m_679, "kind"), "land") ? V.True : V.False) is var _t681 && Truthy(_t681) ? _t681 : Get(m_679, "keep"));
}, 1, "", true)));
if (Truthy(((Get(c_670, "ctrl") is var _t682 && !Truthy(_t682) ? _t682 : Get(c_670, "I")) is var _t683 && !Truthy(_t683) ? _t683 : (!SEqS(Get(Get(Get(c_670, "I"), "cur"), "name"), "idle") ? V.True : V.False)))) {
Invoke(Get(c_670, "ctrl"), "play", ((V)("idle")));
}
if (GeN(dir_669, 0D)) {
Call(faceTo_62, V.Undef, c_670, dir_669);
}
i_671 = 0D;
next_672 = Fn((V _arrowThis690, int _argc684, V _a686, V _a687, V _a688, V _a689, V[] _rest685) => {
V L_691 = default;
V from_692 = default;
V last_693 = default;
if (Ge(((V)(i_671)), Get(legs_668, "length"))) {
return default;
}
L_691 = Object_assign(NewObj(0).V, GetIdx(legs_668, i_671));
OpSet(L_691, "x", 0, GetIdx(origin_49, 0D));
OpSet(L_691, "y", 0, GetIdx(origin_49, 1D));
from_692 = NewObj(4).Put("x", Get(c_670, "x")).Put("y", Get(c_670, "y")).Put("s", Get(c_670, "s")).Put("z", Get(c_670, "z")).V;
last_693 = ((i_671 == (ToNum(Get(legs_668, "length")) - 1D)) ? V.True : V.False);
i_671++;
if (Truthy(((Get(L_691, "boing") is var _t694 && !Truthy(_t694) ? _t694 : Get(c_670, "I")) is var _t695 && !Truthy(_t695) ? _t695 : Get(c_670, "bb")))) {
Call(burst_66, V.Undef, c_670, ((V)("hopPop")), ((V)("feet")));
}
Call(leg_60, V.Undef, c_670, L_691, from_692, dir_669, Fn((V _arrowThis702, int _argc696, V _a698, V _a699, V _a700, V _a701, V[] _rest697) => {
Set(c_670, "x", Get(L_691, "x"));
Set(c_670, "y", Get(L_691, "y"));
Set(c_670, "s", Get(L_691, "s"));
Set(c_670, "z", Get(L_691, "z"));
if (Truthy(last_693)) {
Call(land_61, V.Undef, c_670);
}
Call(next_672, V.Undef);
return default;
}, 0, "", true));
return default;
}, 0, "", true);
Call(next_672, V.Undef);
return default;
}, 3, "hop", false)).Put("bump", Fn((V _self703, int _argc704, V id_710, V dx_711, V dy_712, V shake_713, V[] _rest705) => {
V c_714 = default;
double D_715 = 0;
double side_716 = 0;
if (_self703.IsNullish) _self703 = GlobalV;
c_714 = Invoke(C_48, "get", id_710);
if (!(Truthy(c_714))) {
return default;
}
if (Truthy((shake_713 is var _t717 && !Truthy(_t717) ? _t717 : Get(c_714, "ctrl")))) {
Invoke(Get(c_714, "ctrl"), "play", ((V)("hopOops")));
}
D_715 = (Truthy(shake_713) ? 620D : 380D);
side_716 = Sign(ToNum(dx_711));
Call(start_55, V.Undef, c_714, NewObj(3).Put("kind", ((V)("bump"))).Put("dur", ((V)(D_715))).Put("run", Fn((V _self718, int _argc719, V c_725, V t_726, V _a723, V _a724, V[] _rest720) => {
V @out_727 = default;
V no_728 = default;
V squish_729 = default;
if (_self718.IsNullish) _self718 = GlobalV;
@out_727 = Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(70D)), ((V)(1D)), ((V)("o"))), Arr(((V)(200D)), ((V)(0D)), ((V)("io")))), t_726);
no_728 = (Truthy(shake_713) ? Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(0D))), Arr(((V)(220D)), ((V)(0.9)), ((V)("io"))), Arr(((V)(320D)), ((V)((-0.8))), ((V)("io"))), Arr(((V)(420D)), ((V)(0.5)), ((V)("io"))), Arr(((V)(520D)), ((V)((-0.25))), ((V)("io"))), Arr(((V)(D_715)), ((V)(0D)), ((V)("io")))), t_726) : ((V)(0D)));
squish_729 = (Truthy(shake_713) ? Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(70D)), ((V)(1D)), ((V)("o"))), Arr(((V)(180D)), ((V)(0D)), ((V)("io")))), t_726) : ((V)(0D)));
return NewObj(3).Put("dx", ((V)((ToNum(dx_711) * ToNum(@out_727))))).Put("dy", ((V)((ToNum(dy_712) * ToNum(@out_727))))).Put("ext", NewObj(5).Put("turn", no_728).Put("sq", ((V)((ToNum(squish_729) * (NumTruthy(side_716) ? 0.18 : 0.32))))).Put("tilt", ((V)((((-side_716) * ToNum(squish_729)) * 9D)))).Put("x", ((V)((((-side_716) * ToNum(squish_729)) * 2.5)))).Put("lx", no_728).V).V;
return default;
}, 2, "run", false)).V);
return default;
}, 4, "bump", false)).Put("pickup", Fn((V _self730, int _argc731, V id_737, V tx_738, V ty_739, V ms_740, V[] _rest732) => {
V c_741 = default;
V D_742 = default;
double go_743 = 0;
V from_744 = default;
V to_745 = default;
double kEnd_746 = 0;
if (_self730.IsNullish) _self730 = GlobalV;
c_741 = Invoke(C_48, "get", id_737);
if (!(Truthy(c_741))) {
return default;
}
Set(c_741, "moves", Arr());
if (Truthy(Get(c_741, "ctrl"))) {
Invoke(Get(c_741, "ctrl"), "play", ((V)("hopJoy")));
}
Call(hearts_65, V.Undef, c_741, ((V)(2D)), ((V)(160D)));
D_742 = (ms_740 is var _t747 && Truthy(_t747) ? _t747 : ((V)(760D)));
go_743 = (ToNum(D_742) * 0.34);
from_744 = NewObj(2).Put("x", Get(c_741, "x")).Put("y", Get(c_741, "y")).V;
to_745 = NewObj(2).Put("x", Add(tx_738, GetIdx(origin_49, 0D))).Put("y", Add(ty_739, GetIdx(origin_49, 1D))).V;
kEnd_746 = (Truthy(Get(c_741, "bb")) ? Max(0.15, (26D / (ToNum(Get(c_741, "W")) * ToNum(Get(c_741, "s"))))) : 0.3);
Call(start_55, V.Undef, c_741, NewObj(4).Put("kind", ((V)("pickup"))).Put("dur", D_742).Put("run", Fn((V _self748, int _argc749, V c_755, V t_756, V _a753, V _a754, V[] _rest750) => {
V u_757 = default;
double hopUp_758 = 0;
double fly_759 = 0;
if (_self748.IsNullish) _self748 = GlobalV;
u_757 = (LtN(t_756, go_743) ? ((V)(0D)) : Call(SM_40, V.Undef, ((V)(((ToNum(t_756) - go_743) / (ToNum(D_742) - go_743))))));
Set(c_755, "x", Call(lerp_39, V.Undef, Get(from_744, "x"), Get(to_745, "x"), u_757));
Set(c_755, "y", Call(lerp_39, V.Undef, Get(from_744, "y"), Get(to_745, "y"), u_757));
hopUp_758 = (ToNum(Call(parab_42, V.Undef, ((V)((ToNum(t_756) / (go_743 * 0.9)))))) * 26D);
fly_759 = (ToNum(Call(parab_42, V.Undef, ((V)(((ToNum(t_756) - go_743) / (ToNum(D_742) - go_743)))))) * 60D);
return NewObj(4).Put("z", (LtN(t_756, go_743) ? Get(c_755, "z") : ((V)(90D)))).Put("k", Call(lerp_39, V.Undef, ((V)(1D)), ((V)(kEnd_746)), u_757)).Put("o", ((V)((LtN(t_756, (ToNum(D_742) * 0.8)) ? 1D : (1D - ((ToNum(t_756) - (ToNum(D_742) * 0.8)) / (ToNum(D_742) * 0.2))))))).Put("ext", NewObj(6).Put("lift", Call(toU_57, V.Undef, c_755, ((V)(((hopUp_758 + fly_759) * ToNum(Get(c_755, "s"))))))).Put("sq", Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((go_743 * 0.15))), ((V)(0.3)), ((V)("io"))), Arr(((V)((go_743 * 0.32))), ((V)((-0.3))), ((V)("o"))), Arr(((V)((go_743 * 0.8))), ((V)((-0.05))), ((V)("io"))), Arr(((V)(go_743)), ((V)(0.25)), ((V)("o"))), Arr(((V)((go_743 * 1.15))), ((V)((-0.3))), ((V)("o"))), Arr(D_742, ((V)(0D)), ((V)("io")))), t_756)).Put("armL", Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((go_743 * 0.3))), ((V)(50D)), ((V)("o"))), Arr(D_742, ((V)(40D)))), t_756)).Put("armR", Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((go_743 * 0.3))), ((V)(50D)), ((V)("o"))), Arr(D_742, ((V)(40D)))), t_756)).Put("tilt", Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((go_743 * 0.3))), ((V)(8D)), ((V)("io"))), Arr(((V)((go_743 * 0.6))), ((V)((-8D))), ((V)("io"))), Arr(((V)(go_743)), ((V)(0D)), ((V)("io")))), t_756)).Put("spin", Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(go_743)), ((V)(0D))), Arr(((V)((ToNum(D_742) * 0.9))), ((V)(360D)), ((V)("io"))), Arr(D_742, ((V)(360D)))), t_756)).V).V;
return default;
}, 2, "run", false)).Put("done", Fn((V _self760, int _argc761, V _a763, V _a764, V _a765, V _a766, V[] _rest762) => {
if (_self760.IsNullish) _self760 = GlobalV;
Set(c_741, "o", ((V)(0D)));
Set(c_741, "x", Get(to_745, "x"));
Set(c_741, "y", Get(to_745, "y"));
return default;
}, 0, "done", false)).V);
return default;
}, 4, "pickup", false)).Put("restore", Fn((V _self767, int _argc768, V id_774, V p_775, V _a772, V _a773, V[] _rest769) => {
V c_776 = default;
double D_777 = 0;
if (_self767.IsNullish) _self767 = GlobalV;
c_776 = Invoke(C_48, "get", id_774);
if (!(Truthy(c_776))) {
return default;
}
Set(c_776, "moves", Arr());
Object_assign(c_776, NewObj(6).Put("x", Add(Get(p_775, "x"), GetIdx(origin_49, 0D))).Put("y", Add(Get(p_775, "y"), GetIdx(origin_49, 1D))).Put("s", Get(p_775, "s")).Put("z", Get(p_775, "z")).Put("o", ((V)(1D))).Put("k", ((V)(1D))).V);
if (Truthy(Get(c_776, "ctrl"))) {
Invoke(Get(c_776, "ctrl"), "play", ((V)("idle")));
}
D_777 = 300D;
Call(start_55, V.Undef, c_776, NewObj(3).Put("kind", ((V)("enter"))).Put("dur", ((V)(D_777))).Put("run", Fn((V _self778, int _argc779, V c_785, V t_786, V _a783, V _a784, V[] _rest780) => {
if (_self778.IsNullish) _self778 = GlobalV;
return NewObj(1).Put("k", ((V)((0.3 + (0.7 * ToNum(Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((D_777 * 0.7))), ((V)(1.12)), ((V)("o"))), Arr(((V)(D_777)), ((V)(1D)), ((V)("io")))), t_786))))))).V;
return default;
}, 2, "run", false)).V);
return default;
}, 2, "restore", false)).Put("win", Fn((V _self787, int _argc788, V id_794, V ms_795, V _a792, V _a793, V[] _rest789) => {
V c_796 = default;
V D_797 = default;
V lift_798 = default;
V sq_799 = default;
V arm_800 = default;
V tilt_801 = default;
V spin_802 = default;
if (_self787.IsNullish) _self787 = GlobalV;
c_796 = Invoke(C_48, "get", id_794);
if (!(Truthy(c_796))) {
return default;
}
if (Truthy(Get(c_796, "ctrl"))) {
Invoke(Get(c_796, "ctrl"), "play", ((V)("hopJoy")));
}
D_797 = (ms_795 is var _t803 && Truthy(_t803) ? _t803 : ((V)(1150D)));
Call(faceTo_62, V.Undef, c_796, ((V)(2D)));
lift_798 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_797) * 0.05))), ((V)(0D))), Arr(((V)((ToNum(D_797) * 0.145))), ((V)(34D)), ((V)("o"))), Arr(((V)((ToNum(D_797) * 0.24))), ((V)(0D)), ((V)("i"))), Arr(((V)((ToNum(D_797) * 0.34))), ((V)(0D))), Arr(((V)((ToNum(D_797) * 0.45))), ((V)(40D)), ((V)("o"))), Arr(((V)((ToNum(D_797) * 0.56))), ((V)(0D)), ((V)("i"))), Arr(((V)((ToNum(D_797) * 0.64))), ((V)(0D))), Arr(((V)((ToNum(D_797) * 0.8))), ((V)(62D)), ((V)("o"))), Arr(((V)((ToNum(D_797) * 0.95))), ((V)(0D)), ((V)("i"))), Arr(D_797, ((V)(0D))));
sq_799 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_797) * 0.04))), ((V)(0.22)), ((V)("io"))), Arr(((V)((ToNum(D_797) * 0.08))), ((V)((-0.3))), ((V)("o"))), Arr(((V)((ToNum(D_797) * 0.2))), ((V)((-0.08))), ((V)("io"))), Arr(((V)((ToNum(D_797) * 0.25))), ((V)(0.26)), ((V)("o"))), Arr(((V)((ToNum(D_797) * 0.31))), ((V)(0.2)), ((V)("io"))), Arr(((V)((ToNum(D_797) * 0.37))), ((V)((-0.3))), ((V)("o"))), Arr(((V)((ToNum(D_797) * 0.5))), ((V)((-0.08))), ((V)("io"))), Arr(((V)((ToNum(D_797) * 0.56))), ((V)(0.26)), ((V)("o"))), Arr(((V)((ToNum(D_797) * 0.62))), ((V)(0.24)), ((V)("io"))), Arr(((V)((ToNum(D_797) * 0.68))), ((V)((-0.36))), ((V)("o"))), Arr(((V)((ToNum(D_797) * 0.86))), ((V)((-0.1))), ((V)("io"))), Arr(((V)((ToNum(D_797) * 0.95))), ((V)(0.28)), ((V)("o"))), Arr(D_797, ((V)(0.06)), ((V)("io"))));
arm_800 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_797) * 0.08))), ((V)(46D)), ((V)("o"))), Arr(((V)((ToNum(D_797) * 0.9))), ((V)(46D))), Arr(D_797, ((V)(10D)), ((V)("io"))));
tilt_801 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_797) * 0.13))), ((V)(7D)), ((V)("io"))), Arr(((V)((ToNum(D_797) * 0.27))), ((V)(0D)), ((V)("io"))), Arr(((V)((ToNum(D_797) * 0.43))), ((V)((-7D))), ((V)("io"))), Arr(((V)((ToNum(D_797) * 0.57))), ((V)(0D)), ((V)("io"))));
spin_802 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_797) * 0.68))), ((V)(0D))), Arr(((V)((ToNum(D_797) * 0.92))), ((V)(360D)), ((V)("io"))), Arr(D_797, ((V)(360D))));
Call(start_55, V.Undef, c_796, NewObj(4).Put("kind", ((V)("win"))).Put("dur", D_797).Put("run", Fn((V _self804, int _argc805, V c_811, V t_812, V _a809, V _a810, V[] _rest806) => {
if (_self804.IsNullish) _self804 = GlobalV;
return NewObj(1).Put("ext", NewObj(6).Put("lift", Call(toU_57, V.Undef, c_811, ((V)((ToNum(Call(kv_41, V.Undef, lift_798, t_812)) * ToNum(Get(c_811, "s"))))))).Put("sq", Call(kv_41, V.Undef, sq_799, t_812)).Put("armL", Call(kv_41, V.Undef, arm_800, t_812)).Put("armR", Call(kv_41, V.Undef, arm_800, t_812)).Put("tilt", Call(kv_41, V.Undef, tilt_801, t_812)).Put("spin", (Lt(t_812, D_797) ? Call(kv_41, V.Undef, spin_802, t_812) : ((V)(0D)))).V).V;
return default;
}, 2, "run", false)).Put("done", Fn((V _self813, int _argc814, V _a816, V _a817, V _a818, V _a819, V[] _rest815) => {
if (_self813.IsNullish) _self813 = GlobalV;
Call(land_61, V.Undef, c_796);
return default;
}, 0, "done", false)).V);
Invoke(Arr(((V)(0.26)), ((V)(0.56)), ((V)(0.96))), "forEach", Fn((V _arrowThis827, int _argc820, V f_826, V _a823, V _a824, V _a825, V[] _rest821) => {
return Call(G("setTimeout"), V.Undef, Fn((V _arrowThis842, int _argc836, V _a838, V _a839, V _a840, V _a841, V[] _rest837) => {
if (Truthy((Get(c_796, "I") is var _t843 && !Truthy(_t843) ? _t843 : Get(c_796, "bb")))) {
Call(burst_66, V.Undef, c_796, ((V)("hopSpark")), ((V)("feet")), ((V)(4D)));
}
return default;
}, 0, "", true), ((V)((ToNum(D_797) * ToNum(f_826)))));
}, 1, "", true));
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis858, int _argc852, V _a854, V _a855, V _a856, V _a857, V[] _rest853) => {
if (Truthy((Get(c_796, "I") is var _t859 && !Truthy(_t859) ? _t859 : Get(c_796, "bb")))) {
Call(burst_66, V.Undef, c_796, ((V)("hopSpark")), ((V)("head")), ((V)(7D)));
}
return default;
}, 0, "", true), ((V)((ToNum(D_797) * 0.8))));
Call(hearts_65, V.Undef, c_796, ((V)(4D)), ((V)(260D)));
return default;
}, 2, "win", false)).Put("stuck", Fn((V _self860, int _argc861, V id_867, V _a864, V _a865, V _a866, V[] _rest862) => {
V c_868 = default;
V drip_869 = default;
if (_self860.IsNullish) _self860 = GlobalV;
c_868 = Invoke(C_48, "get", id_867);
if (!(Truthy(c_868))) {
return default;
}
Set(c_868, "moves", Invoke(Get(c_868, "moves"), "filter", Fn((V _arrowThis877, int _argc870, V m_876, V _a873, V _a874, V _a875, V[] _rest871) => {
return ((SEqS(Get(m_876, "kind"), "land") ? V.True : V.False) is var _t878 && Truthy(_t878) ? _t878 : Get(m_876, "keep"));
}, 1, "", true)));
if (Truthy(Get(c_868, "ctrl"))) {
Invoke(Get(c_868, "ctrl"), "play", ((V)("hopSadLook")));
}
Call(faceTo_62, V.Undef, c_868, ((V)(2D)));
Call(G("clearInterval"), V.Undef, Get(c_868, "sweat"));
drip_869 = Fn((V _arrowThis885, int _argc879, V _a881, V _a882, V _a883, V _a884, V[] _rest880) => {
if (Truthy((Get(c_868, "I") is var _t886 && !Truthy(_t886) ? _t886 : Get(c_868, "bb")))) {
Call(burst_66, V.Undef, c_868, ((V)("hopSweat")), ((V)("temple")));
}
return default;
}, 0, "", true);
Call(G("setTimeout"), V.Undef, drip_869, ((V)(360D)));
Set(c_868, "sweat", Call(G("setInterval"), V.Undef, drip_869, ((V)(720D))));
return default;
}, 1, "stuck", false)).Put("unstuck", Fn((V _self887, int _argc888, V id_894, V _a891, V _a892, V _a893, V[] _rest889) => {
V c_895 = default;
if (_self887.IsNullish) _self887 = GlobalV;
c_895 = Invoke(C_48, "get", id_894);
if (!(Truthy(c_895))) {
return default;
}
Call(G("clearInterval"), V.Undef, Get(c_895, "sweat"));
if (Truthy(Get(c_895, "ctrl"))) {
Invoke(Get(c_895, "ctrl"), "play", ((V)("hopPerk")));
}
return default;
}, 1, "unstuck", false)).Put("giggle", Fn((V _self896, int _argc897, V id_903, V _a900, V _a901, V _a902, V[] _rest898) => {
V c_904 = default;
if (_self896.IsNullish) _self896 = GlobalV;
c_904 = Invoke(C_48, "get", id_903);
if (Truthy((c_904 is var _t905 && !Truthy(_t905) ? _t905 : Get(c_904, "ctrl")))) {
Invoke(Get(c_904, "ctrl"), "play", ((V)("hopGiggle")));
}
return default;
}, 1, "giggle", false)).Put("pause", Fn((V _self906, int _argc907, V on_913, V _a910, V _a911, V _a912, V[] _rest908) => {
if (_self906.IsNullish) _self906 = GlobalV;
Invoke(window_28, "__rigPause", on_913);
return default;
}, 1, "pause", false)).V;
running_67 = (false ? V.True : V.False);
castRaw_70 = Get(api_64, "cast");
Set(api_64, "cast", Fn((V _arrowThis922, int _argc914, V list_920, V tag_921, V _a918, V _a919, V[] _rest915) => {
Set(api_64, "_sent", V.Null);
Call(castRaw_70, V.Undef, list_920, tag_921);
return default;
}, 2, "", true));
Set(window_28, "hopStage", api_64);
Set(api_64, "_C", C_48);
boot_71 = Fn((V _arrowThis929, int _argc923, V _a925, V _a926, V _a927, V _a928, V[] _rest924) => {
V R_930 = default;
R_930 = Get(window_28, "RiveRig");
if (Truthy((((((R_930 is var _t931 && !Truthy(_t931) ? _t931 : Get(R_930, "REST")) is var _t932 && !Truthy(_t932) ? _t932 : Get(R_930, "DEFS")) is var _t933 && !Truthy(_t933) ? _t933 : Get(Get(R_930, "DEFS"), "prickle")) is var _t934 && !Truthy(_t934) ? _t934 : Get(R_930, "movesV")) is var _t935 && !Truthy(_t935) ? _t935 : Get(window_28, "RiveGeneric")))) {
kv_41 = Get(R_930, "kv");
Call(addStates_47, V.Undef);
Call(post_36, V.Undef, NewObj(1).Put("type", ((V)("ready"))).V);
} else {
Call(G("setTimeout"), V.Undef, boot_71, ((V)(25D)));
}
return default;
}, 0, "", true);
Call(boot_71, V.Undef);
Set(window_28, "onerror", Fn((V _arrowThis943, int _argc936, V m_942, V _a939, V _a940, V _a941, V[] _rest937) => {
return Call(post_36, V.Undef, NewObj(2).Put("type", ((V)("error"))).Put("message", ((V)(ToStrS(m_942)))).V);
}, 1, "", true));
return default;
}, 0, "", false), V.Undef);
return default;
}, 1, "", false), V.Undef, W_12);
Invoke(b_11, "removeAttribute", ((V)("id")));
return default;
}, 1, "", false), V.Undef, (!string.Equals(GTypeof("globalThis"), "undefined") ? G("globalThis") : GlobalV));
        }
    }
}
