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
rnd_84 = Fn((V _self72, int _argc91, V _a93, V _a94, V _a95, V _a96, V[] _rest92) => {
return ((V)(((sd_83 = ((sd_83 * 16807D) % 2147483647D)) / 2147483647D)));
}, 0, "", true);
oct_85 = Fn((V _self72, int _argc97, V n_103, V _a100, V _a101, V _a102, V[] _rest98) => {
V g_104 = default;
double c_105 = 0;
V sm_106 = default;
g_104 = Arr();
{
double i_107 = 0;
i_107 = 0D;
while (true) {
if (!((i_107 < (ToNum(n_103) * ToNum(n_103))))) break;
Invoke(g_104, "push", Call(rnd_84, V.Undef));
i_107++;
}
}
c_105 = (S_79 / ToNum(n_103));
sm_106 = Fn((V _self72, int _argc109, V t_115, V _a112, V _a113, V _a114, V[] _rest110) => {
return ((V)(((ToNum(t_115) * ToNum(t_115)) * (3D - (2D * ToNum(t_115))))));
}, 1, "", true);
return Fn((V _self72, int _argc116, V px_122, V py_123, V _a120, V _a121, V[] _rest117) => {
double gx_124 = 0;
double gy_125 = 0;
double x0_126 = 0;
double y0_127 = 0;
V fx_128 = default;
V fy_129 = default;
V a_130 = default;
V t_131 = default;
V b_132 = default;
gx_124 = (ToNum(px_122) / c_105);
gy_125 = (ToNum(py_123) / c_105);
x0_126 = System.Math.Floor(gx_124);
y0_127 = System.Math.Floor(gy_125);
fx_128 = Call(sm_106, V.Undef, ((V)((gx_124 - x0_126))));
fy_129 = Call(sm_106, V.Undef, ((V)((gy_125 - y0_127))));
a_130 = Fn((V _self72, int _argc133, V i_139, V j_140, V _a137, V _a138, V[] _rest134) => {
return GetIdx(g_104, (((ToNum(Add(((V)((ToNum(j_140) % ToNum(n_103)))), n_103)) % ToNum(n_103)) * ToNum(n_103)) + (ToNum(Add(((V)((ToNum(i_139) % ToNum(n_103)))), n_103)) % ToNum(n_103))));
}, 2, "", true);
t_131 = Add(Call(a_130, V.Undef, ((V)(x0_126)), ((V)(y0_127))), ((V)(((ToNum(Call(a_130, V.Undef, ((V)((x0_126 + 1D))), ((V)(y0_127)))) - ToNum(Call(a_130, V.Undef, ((V)(x0_126)), ((V)(y0_127))))) * ToNum(fx_128)))));
b_132 = Add(Call(a_130, V.Undef, ((V)(x0_126)), ((V)((y0_127 + 1D)))), ((V)(((ToNum(Call(a_130, V.Undef, ((V)((x0_126 + 1D))), ((V)((y0_127 + 1D))))) - ToNum(Call(a_130, V.Undef, ((V)(x0_126)), ((V)((y0_127 + 1D)))))) * ToNum(fx_128)))));
return Add(t_131, ((V)(((ToNum(b_132) - ToNum(t_131)) * ToNum(fy_129)))));
return default;
}, 2, "", true);
return default;
}, 1, "", true);
o1_86 = Call(oct_85, V.Undef, ((V)(32D)));
o2_87 = Call(oct_85, V.Undef, ((V)(64D)));
{
double y_141 = 0;
y_141 = 0D;
while (true) {
if (!((y_141 < S_79))) break;
{
double X_143 = 0;
X_143 = 0D;
while (true) {
if (!((X_143 < S_79))) break;
double v_145 = 0;
double k_146 = 0;
v_145 = (ToNum(Add(Call(o1_86, V.Undef, ((V)(X_143)), ((V)(y_141))), Call(o2_87, V.Undef, ((V)(X_143)), ((V)(y_141))))) / 2D);
k_146 = (((y_141 * S_79) + X_143) * 4D);
SetIdx(Get(im_82, "data"), (k_146 + 3D), ((V)(Round(((0.2 * 255D) * v_145)))));
X_143++;
}
}
y_141++;
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
} catch (System.Exception _ex147) {
V e_148 = default;
e_148 = Caught(_ex147);
FAB_43 = ((V)(""));
}
return FAB_43;
return default;
}, 0, "fabric", false);
bakeGrain_46 = Fn((V _self149, int _argc150, V svg_156, V _a153, V _a154, V _a155, V[] _rest151) => {
V els_157 = default;
V id_158 = default;
V f_159 = default;
V t_160 = default;
V im_161 = default;
V cm_162 = default;
V top_163 = default;
if (_self149.IsNullish) _self149 = GlobalV;
if ((!(Truthy(svg_156)) || !(Truthy(Call(fabric_44, V.Undef))))) {
return default;
}
els_157 = Invoke(new ArrBuilder().Spread(Invoke(svg_156, "querySelectorAll", ((V)("[filter]")))).V, "filter", Fn((V _self149, int _argc164, V e_170, V _a167, V _a168, V _a169, V[] _rest165) => {
V id_171 = default;
id_171 = GetIdx((Invoke(Invoke(e_170, "getAttribute", ((V)("filter"))), "match", NewRegExp(RX0, "url\\(#([^)]+)\\)", "")) is var _t172 && Truthy(_t172) ? _t172 : Arr()), 1D);
return (id_171 is var _t173 && !Truthy(_t173) ? _t173 : Call(isGrain_45, V.Undef, Invoke(svg_156, "getElementById", id_171)));
return default;
}, 1, "", true));
if (!(Truthy(Get(els_157, "length")))) {
return default;
}
id_158 = GetIdx(Invoke(Invoke(GetIdx(els_157, 0D), "getAttribute", ((V)("filter"))), "match", NewRegExp(RX0, "url\\(#([^)]+)\\)", "")), 1D);
f_159 = Invoke(svg_156, "getElementById", id_158);
t_160 = Invoke(f_159, "querySelector", ((V)("feTurbulence")));
im_161 = Invoke(G("document"), "createElementNS", ((V)("http://www.w3.org/2000/svg")), ((V)("feImage")));
Invoke(Arr(Arr(((V)("href")), FAB_43), Arr(((V)("x")), ((V)((-30D)))), Arr(((V)("y")), ((V)((-30D)))), Arr(((V)("width")), ((V)(160D))), Arr(((V)("height")), ((V)(160D))), Arr(((V)("preserveAspectRatio")), ((V)("none")))), "forEach", Fn((V _self149, int _argc174, V _a176, V _a177, V _a178, V _a179, V[] _rest175) => {
V a_182 = default;
V v_184 = default;
{ V _t180 = ListOf(_a176);
{ V _t181 = GetIdx(_t180, 0D);
a_182 = _t181; }
{ V _t183 = GetIdx(_t180, 1D);
v_184 = _t183; }
}
return Invoke(im_161, "setAttribute", a_182, v_184);
}, 1, "", true));
cm_162 = Get(t_160, "nextElementSibling");
Invoke(t_160, "replaceWith", im_161);
if (Truthy((cm_162 is var _t185 && !Truthy(_t185) ? _t185 : (SEqS(Get(cm_162, "tagName"), "feColorMatrix") ? V.True : V.False)))) {
Invoke(cm_162, "remove");
}
top_163 = Get(GetIdx(els_157, 0D), "parentNode");
while ((!SEq(top_163, svg_156) && !(Truthy(Invoke(els_157, "every", Fn((V _self149, int _argc186, V e_192, V _a189, V _a190, V _a191, V[] _rest187) => {
return Invoke(top_163, "contains", e_192);
}, 1, "", true)))))) {
top_163 = Get(top_163, "parentNode");
}
if (SEq(top_163, svg_156)) {
Invoke(els_157, "forEach", Fn((V _self149, int _argc193, V e_199, V _a196, V _a197, V _a198, V[] _rest194) => {
return Invoke(e_199, "setAttribute", ((V)("filter")), ((V)(JsStrBuf.Begin().S("url(#").V(id_158).S(")").End())));
}, 1, "", true));
return default;
}
Invoke(els_157, "forEach", Fn((V _self149, int _argc200, V e_206, V _a203, V _a204, V _a205, V[] _rest201) => {
return Invoke(e_206, "removeAttribute", ((V)("filter")));
}, 1, "", true));
Invoke(top_163, "setAttribute", ((V)("filter")), ((V)(JsStrBuf.Begin().S("url(#").V(id_158).S(")").End())));
return default;
}, 1, "bakeGrain", false);
addStates_47 = Fn((V _self207, int _argc208, V _a210, V _a211, V _a212, V _a213, V[] _rest209) => {
V AR_214 = default;
V ER_215 = default;
if (_self207.IsNullish) _self207 = GlobalV;
AR_214 = Fn((V _self207, int _argc216, V K_222, V _a219, V _a220, V _a221, V[] _rest217) => {
return NewObj(2).Put("armL", K_222).Put("armR", K_222).V;
}, 1, "", true);
ER_215 = Fn((V _self207, int _argc223, V K_229, V _a226, V _a227, V _a228, V[] _rest224) => {
return NewObj(2).Put("earL", K_229).Put("earR", K_229).V;
}, 1, "", true);
Object_assign(Get(Get(window_28, "RiveRig"), "PRE"), NewObj(5).Put("hopSweat", NewObj(8).Put("n", ((V)(1D))).Put("sp", ((V)(0D))).Put("vy", ((V)(6D))).Put("g", ((V)(34D))).Put("life", ((V)(950D))).Put("r", Arr(((V)(2.6)), ((V)(3D)))).Put("col", Arr(((V)("#8fd3ff")))).Put("kind", ((V)("drop"))).V).Put("hopDust", NewObj(8).Put("n", ((V)(7D))).Put("sp", ((V)(26D))).Put("vy", ((V)((-5D)))).Put("g", ((V)(10D))).Put("life", ((V)(620D))).Put("r", Arr(((V)(2D)), ((V)(3.6)))).Put("col", Arr(((V)("#ffffff")), ((V)("#fdf3ff")), ((V)("#efe4ff")))).Put("kind", ((V)("dot"))).V).Put("hopHeart", NewObj(7).Put("n", ((V)(1D))).Put("sp", ((V)(9D))).Put("vy", ((V)((-16D)))).Put("g", ((V)((-3D)))).Put("life", ((V)(1200D))).Put("r", Arr(((V)(1.6)), ((V)(2D)))).Put("kind", ((V)("heart"))).V).Put("hopSpark", NewObj(8).Put("n", ((V)(6D))).Put("sp", ((V)(30D))).Put("vy", ((V)((-10D)))).Put("g", ((V)(0D))).Put("life", ((V)(700D))).Put("r", Arr(((V)(3.2)), ((V)(5D)))).Put("col", Arr(((V)("#fff3a0")), ((V)("#ffffff")), ((V)("#ffd23a")))).Put("kind", ((V)("star"))).V).Put("hopPop", NewObj(7).Put("n", ((V)(6D))).Put("sp", ((V)(30D))).Put("vy", ((V)((-6D)))).Put("g", ((V)((-4D)))).Put("life", ((V)(560D))).Put("r", Arr(((V)(2.2)), ((V)(3.8)))).Put("kind", ((V)("bubble"))).V).V);
Invoke(Get(window_28, "RiveRig"), "add", NewObj(6).Put("hopSad", NewObj(3).Put("loop", ((V)(2400D))).Put("blend", ((V)(220D))).Put("k", NewObj(10).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.14))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)((-0.55)))))).Put("ly", Arr(Arr(((V)(0D)), ((V)(0.55))))).Put("frown", Arr(Arr(((V)(0D)), ((V)(1D))))).Put("teary", Arr(Arr(((V)(0D)), ((V)(0.7))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))))).Spread(Call(ER_215, V.Undef, Arr(Arr(((V)(0D)), ((V)((-18D))))))).Spread(Call(AR_214, V.Undef, Arr(Arr(((V)(0D)), ((V)((-14D))))))).Put("lean", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(600D)), ((V)((-2.4))), ((V)("s"))), Arr(((V)(1200D)), ((V)(0D)), ((V)("s"))), Arr(((V)(1800D)), ((V)(2.4)), ((V)("s"))), Arr(((V)(2400D)), ((V)(0D)), ((V)("s"))))).Put("tilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(600D)), ((V)((-3D))), ((V)("s"))), Arr(((V)(1200D)), ((V)(0D)), ((V)("s"))), Arr(((V)(1800D)), ((V)(3D)), ((V)("s"))), Arr(((V)(2400D)), ((V)(0D)), ((V)("s"))))).V).V).Put("hopSadLook", NewObj(4).Put("dur", ((V)(850D))).Put("blend", ((V)(160D))).Put("next", ((V)("hopSad"))).Put("k", NewObj(8).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)(0.14)), ((V)("o"))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)((-0.45))), ((V)("io"))))).Put("frown", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(1D)), ((V)("io"))))).Put("teary", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(400D)), ((V)(0.5)), ((V)("io"))))).Spread(Call(ER_215, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)((-18D))), ((V)("o")))))).Spread(Call(AR_214, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)((-14D))), ((V)("o")))))).Put("turn", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0D))), Arr(((V)(330D)), ((V)((-0.95))), ((V)("io"))), Arr(((V)(480D)), ((V)((-0.95)))), Arr(((V)(610D)), ((V)(0.95)), ((V)("io"))), Arr(((V)(760D)), ((V)(0.95))), Arr(((V)(850D)), ((V)(0D)), ((V)("io"))))).Put("lx", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0D))), Arr(((V)(300D)), ((V)((-1D))), ((V)("o"))), Arr(((V)(480D)), ((V)((-1D)))), Arr(((V)(580D)), ((V)(1D)), ((V)("io"))), Arr(((V)(760D)), ((V)(1D))), Arr(((V)(850D)), ((V)(0D)), ((V)("io"))))).V).V).Put("hopPerk", NewObj(3).Put("dur", ((V)(320D))).Put("blend", ((V)(90D))).Put("k", NewObj(4).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.08))), Arr(((V)(90D)), ((V)((-0.16))), ((V)("o"))), Arr(((V)(200D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(320D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(90D)), ((V)(3D)), ((V)("o"))), Arr(((V)(200D)), ((V)(0D)), ((V)("i"))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(320D)), ((V)(0D))))).Spread(Call(ER_215, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(90D)), ((V)(10D)), ((V)("o"))), Arr(((V)(320D)), ((V)(0D)), ((V)("io")))))).V).V).Put("hopGiggle", NewObj(3).Put("dur", ((V)(620D))).Put("blend", ((V)(90D))).Put("k", NewObj(6).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(80D)), ((V)(0.18)), ((V)("o"))), Arr(((V)(180D)), ((V)((-0.12))), ((V)("o"))), Arr(((V)(300D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(420D)), ((V)(0D)), ((V)("io"))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(80D)), ((V)(1D)), ((V)("o"))), Arr(((V)(520D)), ((V)(1D))), Arr(((V)(620D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(80D)), ((V)(1D))))).Put("blush", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(1D))), Arr(((V)(520D)), ((V)(1D))), Arr(((V)(620D)), ((V)(0D))))).Put("tilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)((-6D))), ((V)("io"))), Arr(((V)(260D)), ((V)(6D)), ((V)("io"))), Arr(((V)(400D)), ((V)((-3D))), ((V)("io"))), Arr(((V)(520D)), ((V)(0D)), ((V)("io"))))).Spread(Call(AR_214, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)(30D)), ((V)("o"))), Arr(((V)(400D)), ((V)(24D))), Arr(((V)(620D)), ((V)(0D)), ((V)("io")))))).V).V).Put("hopOops", NewObj(3).Put("dur", ((V)(560D))).Put("blend", ((V)(60D))).Put("k", NewObj(3).Put("wide", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(60D)), ((V)(1D)), ((V)("o"))), Arr(((V)(380D)), ((V)(1D))), Arr(((V)(560D)), ((V)(0D)), ((V)("io"))))).Put("frown", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(60D)), ((V)(0.8)), ((V)("o"))), Arr(((V)(400D)), ((V)(0.8))), Arr(((V)(560D)), ((V)(0D)), ((V)("io"))))).Spread(Call(ER_215, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(60D)), ((V)((-16D))), ((V)("o"))), Arr(((V)(420D)), ((V)((-10D)))), Arr(((V)(560D)), ((V)(0D)), ((V)("io")))))).V).V).Put("hopJoy", NewObj(3).Put("dur", ((V)(1300D))).Put("blend", ((V)(80D))).Put("k", NewObj(5).Put("hap", Arr(Arr(((V)(0D)), ((V)(1D))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(1D))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0.6))))).Put("blush", Arr(Arr(((V)(0D)), ((V)(0.6))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(18D)), ((V)("io"))), Arr(((V)(400D)), ((V)((-18D))), ((V)("io"))), Arr(((V)(600D)), ((V)(18D)), ((V)("io"))), Arr(((V)(800D)), ((V)((-18D))), ((V)("io"))), Arr(((V)(1000D)), ((V)(12D)), ((V)("io"))), Arr(((V)(1300D)), ((V)(0D)), ((V)("io"))))).V).V).V);
return default;
}, 0, "addStates", false);
mount_51 = Fn((V _self230, int _argc231, V c_237, V _a234, V _a235, V _a236, V[] _rest232) => {
if (_self230.IsNullish) _self230 = GlobalV;
Set(c_237, "el", Invoke(G("document"), "createElement", ((V)("div"))));
Set(Get(c_237, "el"), "className", ((V)("ch")));
Set(c_237, "inner", Invoke(G("document"), "createElement", ((V)("div"))));
Invoke(Get(c_237, "el"), "appendChild", Get(c_237, "inner"));
Invoke(board_37, "appendChild", Get(c_237, "el"));
Set(Get(Get(c_237, "el"), "style"), "opacity", ((V)("0")));
if (Truthy(Get(window_28, "__rgI"))) {
DeleteK(Get(window_28, "__rgI"), Get(c_237, "key"));
}
Set(c_237, "ctrl", Invoke(Get(window_28, "RiveRig"), "mount", Get(c_237, "inner"), Get(c_237, "key"), NewObj(1).Put("fidgets", (false ? V.True : V.False)).V));
Set(c_237, "I", Get(Get(c_237, "ctrl"), "_I"));
Set(c_237, "t0", Invoke(G("performance"), "now"));
return default;
}, 1, "mount", false);
measure_52 = Fn((V _self238, int _argc239, V c_245, V _a242, V _a243, V _a244, V[] _rest240) => {
V svg_246 = default;
V sh_247 = default;
V b_248 = default;
if (_self238.IsNullish) _self238 = GlobalV;
svg_246 = Invoke(Get(c_245, "inner"), "querySelector", ((V)("svg")));
if (!(Truthy(svg_246))) {
return V.Null;
}
sh_247 = new ArrBuilder().Spread(Invoke(svg_246, "querySelectorAll", ((V)("ellipse[fill=\"#6a1b9a\"]")))).V;
Invoke(sh_247, "forEach", Fn((V _self238, int _argc249, V e_255, V _a252, V _a253, V _a254, V[] _rest250) => {
return Set(Get(e_255, "style"), "display", ((V)("none")));
}, 1, "", true));
b_248 = V.Null;
try {
b_248 = Invoke(svg_246, "getBBox");
} catch (System.Exception _ex256) {
V e_257 = default;
e_257 = Caught(_ex256);

}
Invoke(sh_247, "forEach", Fn((V _self238, int _argc258, V e_264, V _a261, V _a262, V _a263, V[] _rest259) => {
return Set(Get(e_264, "style"), "display", ((V)("")));
}, 1, "", true));
if ((!(Truthy(b_248)) || !(GtN(Get(b_248, "width"), 1D)))) {
return V.Null;
}
return NewObj(4).Put("cx", Add(Get(b_248, "x"), ((V)((ToNum(Get(b_248, "width")) / 2D))))).Put("gy", Add(Get(b_248, "y"), Get(b_248, "height"))).Put("bw", Get(b_248, "width")).Put("top", Get(b_248, "y")).V;
return default;
}, 1, "measure", false);
ready_53 = Fn((V _self265, int _argc266, V c_272, V _a269, V _a270, V _a271, V[] _rest267) => {
V bb_273 = default;
if (_self265.IsNullish) _self265 = GlobalV;
if (Truthy(Get(c_272, "bb"))) {
return (true ? V.True : V.False);
}
if (!(Truthy(Get(c_272, "I")))) {
return (false ? V.True : V.False);
}
if (Truthy((Get(Get(c_272, "I"), "generic") is var _t274 && !Truthy(_t274) ? _t274 : (!(Truthy(Get(Get(c_272, "I"), "ready"))) ? V.True : V.False)))) {
return (false ? V.True : V.False);
}
Invoke(Get(c_272, "ctrl"), "_pose", ((V)("idle")), ((V)(0D)));
bb_273 = Call(measure_52, V.Undef, c_272);
if (!(Truthy(bb_273))) {
return (false ? V.True : V.False);
}
Set(c_272, "bb", bb_273);
Call(bakeGrain_46, V.Undef, Invoke(Get(c_272, "inner"), "querySelector", ((V)("svg"))));
return (true ? V.True : V.False);
return default;
}, 1, "ready", false);
draw_54 = Fn((V _self275, int _argc276, V c_282, V now_283, V _a280, V _a281, V[] _rest277) => {
V m_284 = default;
double s_285 = 0;
double k_286 = 0;
V x_287 = default;
V y_288 = default;
double o_289 = 0;
if (_self275.IsNullish) _self275 = GlobalV;
if ((!(Truthy(Get(c_282, "bb"))) || !(Truthy(Get(c_282, "el"))))) {
return default;
}
m_284 = (Get(c_282, "cur") is var _t290 && Truthy(_t290) ? _t290 : NewObj(0).V);
s_285 = ((ToNum(Get(c_282, "s")) * ToNum((Get(m_284, "k").IsNullish ? ((V)(1D)) : Get(m_284, "k")))) * ToNum((Get(c_282, "k").IsNullish ? ((V)(1D)) : Get(c_282, "k"))));
k_286 = ((ToNum(Get(c_282, "W")) * s_285) / ToNum(Get(Get(c_282, "bb"), "bw")));
x_287 = Add(Get(c_282, "x"), (Get(m_284, "dx") is var _t291 && Truthy(_t291) ? _t291 : ((V)(0D))));
y_288 = Add(Get(c_282, "y"), (Get(m_284, "dy") is var _t292 && Truthy(_t292) ? _t292 : ((V)(0D))));
Set(Get(Get(c_282, "el"), "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").V(Invoke(((V)((ToNum(x_287) - (ToNum(Get(Get(c_282, "bb"), "cx")) * k_286)))), "toFixed", ((V)(2D)))).S("px,").V(Invoke(((V)((ToNum(y_288) - (ToNum(Get(Get(c_282, "bb"), "gy")) * k_286)))), "toFixed", ((V)(2D)))).S("px) scale(").V(Invoke(((V)(k_286)), "toFixed", ((V)(4D)))).S(")").End())));
Set(Get(Get(c_282, "el"), "style"), "zIndex", ((V)(ToStrS((!Get(m_284, "z").IsNullish ? Get(m_284, "z") : Get(c_282, "z"))))));
o_289 = (ToNum(Get(c_282, "o")) * ToNum((Get(m_284, "o").IsNullish ? ((V)(1D)) : Get(m_284, "o"))));
Set(Get(Get(c_282, "el"), "style"), "opacity", ((V)(ToStrS(((V)((Round((o_289 * 100D)) / 100D)))))));
Set(c_282, "kNow", ((V)(k_286)));
return default;
}, 2, "draw", false);
start_55 = Fn((V _self293, int _argc294, V c_300, V mv_301, V _a298, V _a299, V[] _rest295) => {
if (_self293.IsNullish) _self293 = GlobalV;
Set(mv_301, "t0", Add(Invoke(G("performance"), "now"), (Get(mv_301, "delay") is var _t302 && Truthy(_t302) ? _t302 : ((V)(0D)))));
Invoke(Get(c_300, "moves"), "push", mv_301);
Call(kick_69, V.Undef);
return mv_301;
return default;
}, 2, "start", false);
stopMoves_56 = Fn((V _self303, int _argc304, V c_310, V kind_311, V _a308, V _a309, V[] _rest305) => {
if (_self303.IsNullish) _self303 = GlobalV;
Set(c_310, "moves", Invoke(Get(c_310, "moves"), "filter", Fn((V _self303, int _argc312, V m_318, V _a315, V _a316, V _a317, V[] _rest313) => {
return ((Truthy(kind_311) ? !SEq(Get(m_318, "kind"), kind_311) : false) ? V.True : V.False);
}, 1, "", true)));
return default;
}, 2, "stopMoves", false);
leg_60 = Fn((V _self319, int _argc320, V c_326, V L_327, V from_328, V dir_329, V[] _rest321) => {
V D_331 = default;
double hold_332 = 0;
V H_333 = default;
V dx_334 = default;
V dy_335 = default;
V ease_336 = default;
V crouch_337 = default;
V arms_338 = default;
V lean_339 = default;
V onDone_330 = default;
if (_self319.IsNullish) _self319 = GlobalV;
onDone_330 = (_argc320 > 4 ? _rest321[0] : V.Undef);
D_331 = Get(L_327, "ms");
hold_332 = (Truthy(Get(L_327, "boing")) ? SPRING_59 : CROUCH_58);
H_333 = Get(L_327, "h");
dx_334 = (Truthy(GetK(DIRS_63, dir_329)) ? GetIdx(GetK(DIRS_63, dir_329), 0D) : ((V)(0D)));
dy_335 = (Truthy(GetK(DIRS_63, dir_329)) ? GetIdx(GetK(DIRS_63, dir_329), 1D) : ((V)(0D)));
ease_336 = Fn((V _self319, int _argc340, V u_346, V _a343, V _a344, V _a345, V[] _rest341) => {
return (LeN(u_346, (hold_332 * 0.8)) ? ((V)(0D)) : Call(SM_40, V.Undef, ((V)(((ToNum(u_346) - (hold_332 * 0.8)) / (1D - (hold_332 * 0.8)))))));
}, 1, "", true);
crouch_337 = (Truthy(Get(L_327, "boing")) ? Arr(Arr(((V)(0D)), ((V)(0.45))), Arr(((V)((ToNum(D_331) * SPRING_59))), ((V)(0.4)), ((V)("o"))), Arr(((V)((ToNum(D_331) * (SPRING_59 + 0.1)))), ((V)((-0.42))), ((V)("o"))), Arr(((V)((ToNum(D_331) * 0.45))), ((V)((-0.18))), ((V)("io"))), Arr(((V)((ToNum(D_331) * 0.6))), ((V)(0.12)), ((V)("io"))), Arr(((V)((ToNum(D_331) * 0.75))), ((V)((-0.12))), ((V)("io"))), Arr(((V)((ToNum(D_331) * 0.9))), ((V)(0.06)), ((V)("io"))), Arr(D_331, ((V)((-0.14))), ((V)("io")))) : Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_331) * 0.2))), ((V)(0.24)), ((V)("io"))), Arr(((V)((ToNum(D_331) * 0.34))), ((V)((-0.3))), ((V)("o"))), Arr(((V)((ToNum(D_331) * 0.55))), ((V)((-0.1))), ((V)("io"))), Arr(((V)((ToNum(D_331) * 0.86))), ((V)((-0.2))), ((V)("io"))), Arr(D_331, ((V)((-0.12))), ((V)("io")))));
arms_338 = (Truthy(Get(L_327, "boing")) ? Arr(Arr(((V)(0D)), ((V)((-10D)))), Arr(((V)((ToNum(D_331) * 0.3))), ((V)(46D)), ((V)("o"))), Arr(((V)((ToNum(D_331) * 0.8))), ((V)(30D)), ((V)("io"))), Arr(D_331, ((V)(20D)), ((V)("io")))) : Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_331) * 0.2))), ((V)((-14D))), ((V)("io"))), Arr(((V)((ToNum(D_331) * 0.36))), ((V)(40D)), ((V)("o"))), Arr(((V)((ToNum(D_331) * 0.75))), ((V)(28D)), ((V)("io"))), Arr(D_331, ((V)(18D)), ((V)("io")))));
lean_339 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_331) * 0.2))), ((V)((-0.4))), ((V)("io"))), Arr(((V)((ToNum(D_331) * 0.38))), ((V)(1D)), ((V)("o"))), Arr(((V)((ToNum(D_331) * 0.7))), ((V)(0.55)), ((V)("io"))), Arr(D_331, ((V)(0.15)), ((V)("io"))));
return Call(start_55, V.Undef, c_326, NewObj(4).Put("kind", ((V)("hop"))).Put("dur", D_331).Put("run", Fn((V _self347, int _argc348, V c_354, V t_355, V _a352, V _a353, V[] _rest349) => {
V u_356 = default;
V e_357 = default;
double air_358 = 0;
V ln_359 = default;
if (_self347.IsNullish) _self347 = GlobalV;
u_356 = Call(clamp_38, V.Undef, ((V)((ToNum(t_355) / ToNum(D_331)))), ((V)(0D)), ((V)(1D)));
e_357 = Call(ease_336, V.Undef, u_356);
Set(c_354, "x", Call(lerp_39, V.Undef, Get(from_328, "x"), Get(L_327, "x"), e_357));
Set(c_354, "y", Call(lerp_39, V.Undef, Get(from_328, "y"), Get(L_327, "y"), e_357));
Set(c_354, "s", Call(lerp_39, V.Undef, Get(from_328, "s"), Get(L_327, "s"), e_357));
air_358 = (ToNum(Call(parab_42, V.Undef, ((V)(((ToNum(u_356) - hold_332) / (1D - hold_332)))))) * (Truthy(Get(L_327, "boing")) ? 1.2 : 1D));
ln_359 = Call(kv_41, V.Undef, lean_339, t_355);
return NewObj(2).Put("z", ((V)(Max(ToNum(Get(from_328, "z")), ToNum(Get(L_327, "z")))))).Put("ext", NewObj(8).Put("lift", Call(toU_57, V.Undef, c_354, ((V)((ToNum(H_333) * air_358))))).Put("sq", Call(kv_41, V.Undef, crouch_337, t_355)).Put("armL", Call(kv_41, V.Undef, arms_338, t_355)).Put("armR", Call(kv_41, V.Undef, arms_338, t_355)).Put("tilt", ((V)(((ToNum(ln_359) * 11D) * ToNum(dx_334))))).Put("lean", ((V)(((ToNum(ln_359) * 3D) * ToNum(dx_334))))).Put("pitch", ((V)((((-ToNum(ln_359)) * 0.55) * ToNum(dy_335))))).Put("ly", ((V)(((ToNum(ln_359) * 0.7) * ToNum(dy_335))))).V).V;
return default;
}, 2, "run", false)).Put("done", onDone_330).V);
return default;
}, 5, "leg", false);
land_61 = Fn((V _self360, int _argc361, V c_367, V _a364, V _a365, V _a366, V[] _rest362) => {
double D_368 = 0;
V sq_369 = default;
V arms_370 = default;
if (_self360.IsNullish) _self360 = GlobalV;
D_368 = 400D;
sq_369 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(40D)), ((V)(0.3)), ((V)("o"))), Arr(((V)(140D)), ((V)((-0.14))), ((V)("io"))), Arr(((V)(240D)), ((V)(0.07)), ((V)("io"))), Arr(((V)(330D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(D_368)), ((V)(0D)), ((V)("io"))));
arms_370 = Arr(Arr(((V)(0D)), ((V)(18D))), Arr(((V)(60D)), ((V)((-18D))), ((V)("o"))), Arr(((V)(200D)), ((V)(10D)), ((V)("io"))), Arr(((V)(D_368)), ((V)(0D)), ((V)("io"))));
Call(stopMoves_56, V.Undef, c_367, ((V)("land")));
if (Truthy((Get(c_367, "I") is var _t371 && !Truthy(_t371) ? _t371 : Get(c_367, "bb")))) {
Call(burst_66, V.Undef, c_367, ((V)("hopDust")), ((V)("feet")));
}
Call(start_55, V.Undef, c_367, NewObj(3).Put("kind", ((V)("land"))).Put("dur", ((V)(D_368))).Put("run", Fn((V _self372, int _argc373, V c_379, V t_380, V _a377, V _a378, V[] _rest374) => {
if (_self372.IsNullish) _self372 = GlobalV;
return NewObj(1).Put("ext", NewObj(3).Put("sq", Call(kv_41, V.Undef, sq_369, t_380)).Put("armL", Call(kv_41, V.Undef, arms_370, t_380)).Put("armR", Call(kv_41, V.Undef, arms_370, t_380)).V).V;
return default;
}, 2, "run", false)).V);
return default;
}, 1, "land", false);
faceTo_62 = Fn((V _self381, int _argc382, V c_388, V dir_389, V _a386, V _a387, V[] _rest383) => {
V to_390 = default;
V from_391 = default;
if (_self381.IsNullish) _self381 = GlobalV;
to_390 = (SEqN(dir_389, 1D) ? ((V)(0.55)) : (SEqN(dir_389, 3D) ? ((V)((-0.55))) : ((SEqN(dir_389, 0D) || SEqN(dir_389, 2D)) ? ((V)(0D)) : Get(c_388, "face"))));
if (SEq(to_390, Get(c_388, "face"))) {
return default;
}
from_391 = Get(c_388, "face");
Set(c_388, "face", to_390);
Call(stopMoves_56, V.Undef, c_388, ((V)("face")));
Call(start_55, V.Undef, c_388, NewObj(4).Put("kind", ((V)("face"))).Put("dur", ((V)(140D))).Put("keep", (true ? V.True : V.False)).Put("run", Fn((V _self392, int _argc393, V c_399, V t_400, V _a397, V _a398, V[] _rest394) => {
if (_self392.IsNullish) _self392 = GlobalV;
Set(c_399, "faceNow", Call(lerp_39, V.Undef, from_391, to_390, Call(SM_40, V.Undef, ((V)((ToNum(t_400) / 140D))))));
return NewObj(0).V;
return default;
}, 2, "run", false)).V);
return default;
}, 2, "faceTo", false);
hearts_65 = Fn((V _self401, int _argc402, V c_408, V n_409, V every_410, V _a407, V[] _rest403) => {
if (_self401.IsNullish) _self401 = GlobalV;
{
double i_411 = 0;
i_411 = 0D;
while (true) {
if (!(Lt(((V)(i_411)), n_409))) break;
Call(G("setTimeout"), V.Undef, Fn((V _self401, int _argc420, V _a422, V _a423, V _a424, V _a425, V[] _rest421) => {
if (Truthy((Get(c_408, "I") is var _t426 && !Truthy(_t426) ? _t426 : Get(c_408, "bb")))) {
Call(burst_66, V.Undef, c_408, ((V)("hopHeart")), ((V)("head")), ((V)(1D)));
}
return default;
}, 0, "", true), ((V)((i_411 * ToNum(every_410)))));
i_411++;
}
}
return default;
}, 3, "hearts", false);
burst_66 = Fn((V _self427, int _argc428, V c_434, V kind_435, V where_436, V n_437, V[] _rest429) => {
V b_438 = default;
V W_439 = default;
V p_440 = default;
if (_self427.IsNullish) _self427 = GlobalV;
b_438 = Get(c_434, "bb");
W_439 = (Get(Get(c_434, "I"), "W") is var _t441 && Truthy(_t441) ? _t441 : NewObj(0).V);
p_440 = (SEqS(where_436, "feet") ? Arr(Get(b_438, "cx"), ((V)((ToNum(Get(b_438, "gy")) - 2D)))) : (SEqS(where_436, "head") ? Arr(Get(b_438, "cx"), Add(Get(b_438, "top"), ((V)(4D)))) : (SEqS(where_436, "temple") ? Arr(Add(Get(b_438, "cx"), ((V)((ToNum(Get(b_438, "bw")) * 0.34)))), Add(Get(b_438, "top"), ((V)((ToNum(Get(b_438, "bw")) * 0.2))))) : (GetK(W_439, where_436) is var _t442 && Truthy(_t442) ? _t442 : Arr(((V)(50D)), ((V)(50D)))))));
try {
V e_443 = default;
e_443 = Get(Get(window_28, "RiveRig"), "emit");
if (Truthy(e_443)) {
Call(e_443, V.Undef, Get(c_434, "I"), kind_435, p_440, n_437);
}
} catch (System.Exception _ex444) {
V x_445 = default;
x_445 = Caught(_ex444);

}
return default;
}, 4, "burst", false);
frame_68 = Fn((V _self446, int _argc447, V _a449, V _a450, V _a451, V _a452, V[] _rest448) => {
V now_453 = default;
V busy_454 = default;
V allReady_455 = default;
if (_self446.IsNullish) _self446 = GlobalV;
now_453 = Invoke(G("performance"), "now");
busy_454 = (false ? V.True : V.False);
allReady_455 = (true ? V.True : V.False);
{
foreach (V _k456 in new JsIter(Invoke(C_48, "values"))) {
V c_457 = default;
c_457 = _k456;
V ext_458 = default;
V cur_459 = default;
V list_460 = default;
V kept_461 = default;
if (!(Truthy(Call(ready_53, V.Undef, c_457)))) {
if (((((ToNum(now_453) - ToNum(Get(c_457, "t0"))) > 9000D) && !castTag_50.IsNullish) && !SEq(Get(api_64, "_sent"), castTag_50))) {
Set(api_64, "_sent", castTag_50);
Call(post_36, V.Undef, NewObj(4).Put("type", ((V)("cast"))).Put("tag", castTag_50).Put("ok", (false ? V.True : V.False)).Put("key", Get(c_457, "key")).V);
}
allReady_455 = (false ? V.True : V.False);
busy_454 = (((ToNum(now_453) - ToNum(Get(c_457, "t0"))) < 9000D) ? V.True : V.False);
continue;
}
ext_458 = NewObj(0).V;
cur_459 = NewObj(2).Put("dx", ((V)(0D))).Put("dy", ((V)(0D))).V;
list_460 = Get(c_457, "moves");
Set(c_457, "moves", Arr());
kept_461 = Invoke(list_460, "filter", Fn((V _self446, int _argc462, V m_468, V _a465, V _a466, V _a467, V[] _rest463) => {
double t_469 = 0;
V r_470 = default;
t_469 = (ToNum(now_453) - ToNum(Get(m_468, "t0")));
if ((t_469 < 0D)) {
if (Truthy(Get(m_468, "before"))) {
cur_459 = Object_assign(cur_459, Get(m_468, "before"));
}
return (true ? V.True : V.False);
}
if (Ge(((V)(t_469)), Get(m_468, "dur"))) {
if (Truthy(Get(m_468, "run"))) {
Invoke(m_468, "run", c_457, Get(m_468, "dur"));
}
if (Truthy(Get(m_468, "done"))) {
Invoke(m_468, "done");
}
return (false ? V.True : V.False);
}
r_470 = (Invoke(m_468, "run", c_457, ((V)(t_469))) is var _t471 && Truthy(_t471) ? _t471 : NewObj(0).V);
if (Truthy(Get(r_470, "dx"))) {
OpSet(cur_459, "dx", 0, Get(r_470, "dx"));
}
if (Truthy(Get(r_470, "dy"))) {
OpSet(cur_459, "dy", 0, Get(r_470, "dy"));
}
if (!Get(r_470, "k").IsNullish) {
Set(cur_459, "k", ((V)((ToNum((Get(cur_459, "k").IsNullish ? ((V)(1D)) : Get(cur_459, "k"))) * ToNum(Get(r_470, "k"))))));
}
if (!Get(r_470, "o").IsNullish) {
Set(cur_459, "o", ((V)((ToNum((Get(cur_459, "o").IsNullish ? ((V)(1D)) : Get(cur_459, "o"))) * ToNum(Get(r_470, "o"))))));
}
if (!Get(r_470, "z").IsNullish) {
Set(cur_459, "z", Get(r_470, "z"));
}
if (Truthy(Get(r_470, "ext"))) {
{
foreach (V _k472 in ForInKeys(Get(r_470, "ext"))) {
V k_473 = default;
k_473 = _k472;
SetK(ext_458, k_473, Add((GetK(ext_458, k_473) is var _t474 && Truthy(_t474) ? _t474 : ((V)(0D))), GetK(Get(r_470, "ext"), k_473)));
}
}
}
return (true ? V.True : V.False);
return default;
}, 1, "", true));
Set(c_457, "moves", Invoke(kept_461, "concat", Get(c_457, "moves")));
if (Truthy(Get(Get(c_457, "moves"), "length"))) {
busy_454 = (true ? V.True : V.False);
}
Set(ext_458, "turn", Add((Get(ext_458, "turn") is var _t475 && Truthy(_t475) ? _t475 : ((V)(0D))), Get(c_457, "faceNow")));
if (!Get(ext_458, "sq").IsNullish) {
Set(ext_458, "sq", Call(clamp_38, V.Undef, Get(ext_458, "sq"), ((V)((-0.45))), ((V)(0.4))));
}
Set(c_457, "cur", cur_459);
if (Truthy(Get(c_457, "ctrl"))) {
Invoke(Get(c_457, "ctrl"), "ext", ext_458);
}
Call(draw_54, V.Undef, c_457, now_453);
}
}
if (Truthy((((allReady_455 is var _t476 && !Truthy(_t476) ? _t476 : (!castTag_50.IsNullish ? V.True : V.False)) is var _t477 && !Truthy(_t477) ? _t477 : Get(C_48, "size")) is var _t478 && !Truthy(_t478) ? _t478 : (!(Truthy(Get(api_64, "_sent"))) ? V.True : V.False)))) {
Set(api_64, "_sent", castTag_50);
Call(post_36, V.Undef, NewObj(3).Put("type", ((V)("cast"))).Put("tag", castTag_50).Put("ok", (true ? V.True : V.False)).V);
}
if (Truthy(busy_454)) {
Call(G("requestAnimationFrame"), V.Undef, frame_68);
} else {
running_67 = (false ? V.True : V.False);
}
return default;
}, 0, "frame", false);
kick_69 = Fn((V _self479, int _argc480, V _a482, V _a483, V _a484, V _a485, V[] _rest481) => {
if (_self479.IsNullish) _self479 = GlobalV;
if (!(Truthy(running_67))) {
running_67 = (true ? V.True : V.False);
Call(G("requestAnimationFrame"), V.Undef, frame_68);
}
return default;
}, 0, "kick", false);
post_36 = Fn((V _self29, int _argc486, V m_492, V _a489, V _a490, V _a491, V[] _rest487) => {
V s_493 = default;
s_493 = Invoke(G("JSON"), "stringify", m_492);
if (Truthy(Get(window_28, "ReactNativeWebView"))) {
Invoke(Get(window_28, "ReactNativeWebView"), "postMessage", s_493);
} else {
Invoke(Set(window_28, "__hopOut", (Get(window_28, "__hopOut") is var _t494 && Truthy(_t494) ? _t494 : Arr())), "push", m_492);
}
return default;
}, 1, "", true);
board_37 = Invoke(G("document"), "getElementById", ((V)("board")));
clamp_38 = Fn((V _self29, int _argc495, V v_501, V a_502, V b_503, V _a500, V[] _rest496) => {
return ((V)(Max(ToNum(a_502), Min(ToNum(b_503), ToNum(v_501)))));
}, 3, "", true);
lerp_39 = Fn((V _self29, int _argc504, V a_510, V b_511, V t_512, V _a509, V[] _rest505) => {
return Add(a_510, ((V)(((ToNum(b_511) - ToNum(a_510)) * ToNum(t_512)))));
}, 3, "", true);
SM_40 = Fn((V _self29, int _argc513, V x_519, V _a516, V _a517, V _a518, V[] _rest514) => {
x_519 = Call(clamp_38, V.Undef, x_519, ((V)(0D)), ((V)(1D)));
return ((V)(((ToNum(x_519) * ToNum(x_519)) * (3D - (2D * ToNum(x_519))))));
return default;
}, 1, "", true);
kv_41 = V.Null;
parab_42 = Fn((V _self29, int _argc520, V u_526, V _a523, V _a524, V _a525, V[] _rest521) => {
return ((V)(((LeN(u_526, 0D) || GeN(u_526, 1D)) ? 0D : ((4D * ToNum(u_526)) * (1D - ToNum(u_526))))));
}, 1, "", true);
FAB_43 = V.Null;
isGrain_45 = Fn((V _self29, int _argc527, V f_533, V _a530, V _a531, V _a532, V[] _rest528) => {
return (((f_533 is var _t534 && !Truthy(_t534) ? _t534 : Invoke(f_533, "querySelector", ((V)("feTurbulence")))) is var _t535 && !Truthy(_t535) ? _t535 : (!(Truthy(Invoke(f_533, "querySelector", ((V)("feDisplacementMap"))))) ? V.True : V.False)) is var _t536 && !Truthy(_t536) ? _t536 : Invoke(f_533, "querySelector", ((V)("feBlend[mode=\"multiply\"]"))));
}, 1, "", true);
C_48 = New(G("Map"));
origin_49 = Arr(((V)(0D)), ((V)(0D)));
castTag_50 = V.Null;
toU_57 = Fn((V _self29, int _argc537, V c_543, V dp_544, V _a541, V _a542, V[] _rest538) => {
return ((V)((Truthy(Get(c_543, "kNow")) ? (ToNum(dp_544) / ToNum(Get(c_543, "kNow"))) : 0D)));
}, 2, "", true);
CROUCH_58 = 0.24;
SPRING_59 = 0.18;
DIRS_63 = Arr(Arr(((V)(0D)), ((V)((-1D)))), Arr(((V)(1D)), ((V)(0D))), Arr(((V)(0D)), ((V)(1D))), Arr(((V)((-1D))), ((V)(0D))));
api_64 = NewObj(14).Put("origin", Fn((V _self545, int _argc546, V x_552, V y_553, V _a550, V _a551, V[] _rest547) => {
if (_self545.IsNullish) _self545 = GlobalV;
origin_49 = Arr(x_552, y_553);
return default;
}, 2, "origin", false)).Put("cast", Fn((V _self554, int _argc555, V list_561, V tag_562, V _a559, V _a560, V[] _rest556) => {
V ids_563 = default;
if (_self554.IsNullish) _self554 = GlobalV;
castTag_50 = tag_562;
ids_563 = New(G("Set"), Invoke(list_561, "map", Fn((V _self554, int _argc564, V c_570, V _a567, V _a568, V _a569, V[] _rest565) => {
return Get(c_570, "id");
}, 1, "", true)));
{
foreach (V _k571 in new JsIter(C_48)) {
V id_572 = default;
V c_573 = default;
{ V _t574 = ListOf(_k571);
{ V _t575 = GetIdx(_t574, 0D);
id_572 = _t575; }
{ V _t576 = GetIdx(_t574, 1D);
c_573 = _t576; }
}
if (!(Truthy(Invoke(ids_563, "has", id_572)))) {
if (Truthy(Get(c_573, "ctrl"))) {
Invoke(Get(c_573, "ctrl"), "destroy");
}
if (Truthy(Get(c_573, "el"))) {
Invoke(Get(c_573, "el"), "remove");
}
Invoke(C_48, "delete", id_572);
}
}
}
{
foreach (V _k577 in new JsIter(list_561)) {
V it_578 = default;
it_578 = _k577;
V c_579 = default;
c_579 = Invoke(C_48, "get", Get(it_578, "id"));
if (Truthy((c_579 is var _t580 && !Truthy(_t580) ? _t580 : (!SEq(Get(c_579, "key"), Get(it_578, "key")) ? V.True : V.False)))) {
if (Truthy(Get(c_579, "ctrl"))) {
Invoke(Get(c_579, "ctrl"), "destroy");
}
if (Truthy(Get(c_579, "el"))) {
Invoke(Get(c_579, "el"), "remove");
}
Invoke(C_48, "delete", Get(it_578, "id"));
c_579 = V.Null;
}
if (!(Truthy(c_579))) {
c_579 = NewObj(7).Put("id", Get(it_578, "id")).Put("key", Get(it_578, "key")).Put("moves", Arr()).Put("face", ((V)(0D))).Put("faceNow", ((V)(0D))).Put("o", ((V)(1D))).Put("k", ((V)(1D))).V;
Invoke(C_48, "set", Get(it_578, "id"), c_579);
Call(mount_51, V.Undef, c_579);
}
Object_assign(c_579, NewObj(6).Put("W", Get(it_578, "W")).Put("x", Add(Get(it_578, "x"), GetIdx(origin_49, 0D))).Put("y", Add(Get(it_578, "y"), GetIdx(origin_49, 1D))).Put("s", Get(it_578, "s")).Put("z", Get(it_578, "z")).Put("o", (Get(it_578, "o").IsNullish ? ((V)(1D)) : Get(it_578, "o"))).V);
Set(c_579, "moves", Arr());
Set(c_579, "cur", V.Null);
}
}
Call(kick_69, V.Undef);
return default;
}, 2, "cast", false)).Put("place", Fn((V _self581, int _argc582, V id_588, V p_589, V _a586, V _a587, V[] _rest583) => {
V c_590 = default;
if (_self581.IsNullish) _self581 = GlobalV;
c_590 = Invoke(C_48, "get", id_588);
if (!(Truthy(c_590))) {
return default;
}
Set(c_590, "moves", Invoke(Get(c_590, "moves"), "filter", Fn((V _self581, int _argc591, V m_597, V _a594, V _a595, V _a596, V[] _rest592) => {
return Get(m_597, "keep");
}, 1, "", true)));
Object_assign(c_590, NewObj(4).Put("x", Add(Get(p_589, "x"), GetIdx(origin_49, 0D))).Put("y", Add(Get(p_589, "y"), GetIdx(origin_49, 1D))).Put("s", Get(p_589, "s")).Put("z", Get(p_589, "z")).V);
if (!Get(p_589, "o").IsNullish) {
Set(c_590, "o", Get(p_589, "o"));
}
Set(c_590, "k", ((V)(1D)));
Call(kick_69, V.Undef);
return default;
}, 2, "place", false)).Put("show", Fn((V _self598, int _argc599, V id_605, V o_606, V _a603, V _a604, V[] _rest600) => {
V c_607 = default;
if (_self598.IsNullish) _self598 = GlobalV;
c_607 = Invoke(C_48, "get", id_605);
if (Truthy(c_607)) {
Set(c_607, "o", o_606);
Call(kick_69, V.Undef);
}
return default;
}, 2, "show", false)).Put("enter", Fn((V _self608, int _argc609, V id_615, V p_616, V delay_617, V pop_618, V[] _rest610) => {
V c_619 = default;
double D_620 = 0;
if (_self608.IsNullish) _self608 = GlobalV;
c_619 = Invoke(C_48, "get", id_615);
if (!(Truthy(c_619))) {
return default;
}
Call(G("clearInterval"), V.Undef, Get(c_619, "sweat"));
Set(c_619, "moves", Arr());
Object_assign(c_619, NewObj(8).Put("x", Add(Get(p_616, "x"), GetIdx(origin_49, 0D))).Put("y", Add(Get(p_616, "y"), GetIdx(origin_49, 1D))).Put("s", Get(p_616, "s")).Put("z", Get(p_616, "z")).Put("o", ((V)(1D))).Put("k", ((V)(1D))).Put("face", ((V)(0D))).Put("faceNow", ((V)(0D))).V);
if (Truthy(Get(c_619, "ctrl"))) {
Invoke(Get(c_619, "ctrl"), "play", ((V)("idle")));
}
D_620 = (Truthy(pop_618) ? 340D : 460D);
Call(start_55, V.Undef, c_619, NewObj(5).Put("kind", ((V)("enter"))).Put("delay", delay_617).Put("dur", ((V)(D_620))).Put("before", NewObj(1).Put("o", ((V)(0D))).V).Put("run", Fn((V _self621, int _argc622, V c_628, V t_629, V _a626, V _a627, V[] _rest623) => {
V fall_630 = default;
if (_self621.IsNullish) _self621 = GlobalV;
if (Truthy(pop_618)) {
double u_631 = 0;
u_631 = (ToNum(t_629) / D_620);
return NewObj(3).Put("k", ((V)((0.3 + (0.7 * ToNum(Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((D_620 * 0.7))), ((V)(1.12)), ((V)("o"))), Arr(((V)(D_620)), ((V)(1D)), ((V)("io")))), t_629))))))).Put("o", Call(clamp_38, V.Undef, ((V)((u_631 * 3D))), ((V)(0D)), ((V)(1D)))).Put("ext", NewObj(1).Put("sq", Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((D_620 * 0.5))), ((V)((-0.2))), ((V)("o"))), Arr(((V)((D_620 * 0.8))), ((V)(0.1)), ((V)("io"))), Arr(((V)(D_620)), ((V)(0D)), ((V)("io")))), t_629)).V).V;
}
fall_630 = Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)((D_620 * 0.62))), ((V)(0D)), ((V)("i"))), Arr(((V)(D_620)), ((V)(0D)))), t_629);
return NewObj(2).Put("o", Call(clamp_38, V.Undef, ((V)((ToNum(t_629) / 120D))), ((V)(0D)), ((V)(1D)))).Put("ext", NewObj(4).Put("lift", ((V)((ToNum(Call(toU_57, V.Undef, c_628, ((V)((90D * ToNum(Get(c_628, "s"))))))) * ToNum(fall_630))))).Put("sq", Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)((-0.2)))), Arr(((V)((D_620 * 0.62))), ((V)((-0.25))), ((V)("i"))), Arr(((V)((D_620 * 0.7))), ((V)(0.4)), ((V)("o"))), Arr(((V)((D_620 * 0.85))), ((V)((-0.1))), ((V)("io"))), Arr(((V)(D_620)), ((V)(0D)), ((V)("io")))), t_629)).Put("armL", Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(40D))), Arr(((V)((D_620 * 0.62))), ((V)(40D))), Arr(((V)((D_620 * 0.75))), ((V)((-14D))), ((V)("o"))), Arr(((V)(D_620)), ((V)(0D)), ((V)("io")))), t_629)).Put("armR", Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(40D))), Arr(((V)((D_620 * 0.62))), ((V)(40D))), Arr(((V)((D_620 * 0.75))), ((V)((-14D))), ((V)("o"))), Arr(((V)(D_620)), ((V)(0D)), ((V)("io")))), t_629)).V).V;
return default;
}, 2, "run", false)).V);
return default;
}, 4, "enter", false)).Put("hop", Fn((V _self632, int _argc633, V id_639, V legs_640, V dir_641, V _a638, V[] _rest634) => {
V c_642 = default;
double i_643 = 0;
V next_644 = default;
if (_self632.IsNullish) _self632 = GlobalV;
c_642 = Invoke(C_48, "get", id_639);
if (!(Truthy(c_642))) {
return default;
}
Set(c_642, "moves", Invoke(Get(c_642, "moves"), "filter", Fn((V _self632, int _argc645, V m_651, V _a648, V _a649, V _a650, V[] _rest646) => {
return ((SEqS(Get(m_651, "kind"), "land") ? V.True : V.False) is var _t652 && Truthy(_t652) ? _t652 : Get(m_651, "keep"));
}, 1, "", true)));
if (Truthy(((Get(c_642, "ctrl") is var _t653 && !Truthy(_t653) ? _t653 : Get(c_642, "I")) is var _t654 && !Truthy(_t654) ? _t654 : (!SEqS(Get(Get(Get(c_642, "I"), "cur"), "name"), "idle") ? V.True : V.False)))) {
Invoke(Get(c_642, "ctrl"), "play", ((V)("idle")));
}
if (GeN(dir_641, 0D)) {
Call(faceTo_62, V.Undef, c_642, dir_641);
}
i_643 = 0D;
next_644 = Fn((V _self632, int _argc655, V _a657, V _a658, V _a659, V _a660, V[] _rest656) => {
V L_661 = default;
V from_662 = default;
V last_663 = default;
if (Ge(((V)(i_643)), Get(legs_640, "length"))) {
return default;
}
L_661 = Object_assign(NewObj(0).V, GetIdx(legs_640, i_643));
OpSet(L_661, "x", 0, GetIdx(origin_49, 0D));
OpSet(L_661, "y", 0, GetIdx(origin_49, 1D));
from_662 = NewObj(4).Put("x", Get(c_642, "x")).Put("y", Get(c_642, "y")).Put("s", Get(c_642, "s")).Put("z", Get(c_642, "z")).V;
last_663 = ((i_643 == (ToNum(Get(legs_640, "length")) - 1D)) ? V.True : V.False);
i_643++;
if (Truthy(((Get(L_661, "boing") is var _t664 && !Truthy(_t664) ? _t664 : Get(c_642, "I")) is var _t665 && !Truthy(_t665) ? _t665 : Get(c_642, "bb")))) {
Call(burst_66, V.Undef, c_642, ((V)("hopPop")), ((V)("feet")));
}
Call(leg_60, V.Undef, c_642, L_661, from_662, dir_641, Fn((V _self632, int _argc666, V _a668, V _a669, V _a670, V _a671, V[] _rest667) => {
Set(c_642, "x", Get(L_661, "x"));
Set(c_642, "y", Get(L_661, "y"));
Set(c_642, "s", Get(L_661, "s"));
Set(c_642, "z", Get(L_661, "z"));
if (Truthy(last_663)) {
Call(land_61, V.Undef, c_642);
}
Call(next_644, V.Undef);
return default;
}, 0, "", true));
return default;
}, 0, "", true);
Call(next_644, V.Undef);
return default;
}, 3, "hop", false)).Put("bump", Fn((V _self672, int _argc673, V id_679, V dx_680, V dy_681, V shake_682, V[] _rest674) => {
V c_683 = default;
double D_684 = 0;
double side_685 = 0;
if (_self672.IsNullish) _self672 = GlobalV;
c_683 = Invoke(C_48, "get", id_679);
if (!(Truthy(c_683))) {
return default;
}
if (Truthy((shake_682 is var _t686 && !Truthy(_t686) ? _t686 : Get(c_683, "ctrl")))) {
Invoke(Get(c_683, "ctrl"), "play", ((V)("hopOops")));
}
D_684 = (Truthy(shake_682) ? 620D : 380D);
side_685 = Sign(ToNum(dx_680));
Call(start_55, V.Undef, c_683, NewObj(3).Put("kind", ((V)("bump"))).Put("dur", ((V)(D_684))).Put("run", Fn((V _self687, int _argc688, V c_694, V t_695, V _a692, V _a693, V[] _rest689) => {
V @out_696 = default;
V no_697 = default;
V squish_698 = default;
if (_self687.IsNullish) _self687 = GlobalV;
@out_696 = Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(70D)), ((V)(1D)), ((V)("o"))), Arr(((V)(200D)), ((V)(0D)), ((V)("io")))), t_695);
no_697 = (Truthy(shake_682) ? Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(0D))), Arr(((V)(220D)), ((V)(0.9)), ((V)("io"))), Arr(((V)(320D)), ((V)((-0.8))), ((V)("io"))), Arr(((V)(420D)), ((V)(0.5)), ((V)("io"))), Arr(((V)(520D)), ((V)((-0.25))), ((V)("io"))), Arr(((V)(D_684)), ((V)(0D)), ((V)("io")))), t_695) : ((V)(0D)));
squish_698 = (Truthy(shake_682) ? Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(70D)), ((V)(1D)), ((V)("o"))), Arr(((V)(180D)), ((V)(0D)), ((V)("io")))), t_695) : ((V)(0D)));
return NewObj(3).Put("dx", ((V)((ToNum(dx_680) * ToNum(@out_696))))).Put("dy", ((V)((ToNum(dy_681) * ToNum(@out_696))))).Put("ext", NewObj(5).Put("turn", no_697).Put("sq", ((V)((ToNum(squish_698) * (NumTruthy(side_685) ? 0.18 : 0.32))))).Put("tilt", ((V)((((-side_685) * ToNum(squish_698)) * 9D)))).Put("x", ((V)((((-side_685) * ToNum(squish_698)) * 2.5)))).Put("lx", no_697).V).V;
return default;
}, 2, "run", false)).V);
return default;
}, 4, "bump", false)).Put("pickup", Fn((V _self699, int _argc700, V id_706, V tx_707, V ty_708, V ms_709, V[] _rest701) => {
V c_710 = default;
V D_711 = default;
double go_712 = 0;
V from_713 = default;
V to_714 = default;
double kEnd_715 = 0;
if (_self699.IsNullish) _self699 = GlobalV;
c_710 = Invoke(C_48, "get", id_706);
if (!(Truthy(c_710))) {
return default;
}
Set(c_710, "moves", Arr());
if (Truthy(Get(c_710, "ctrl"))) {
Invoke(Get(c_710, "ctrl"), "play", ((V)("hopJoy")));
}
Call(hearts_65, V.Undef, c_710, ((V)(2D)), ((V)(160D)));
D_711 = (ms_709 is var _t716 && Truthy(_t716) ? _t716 : ((V)(760D)));
go_712 = (ToNum(D_711) * 0.34);
from_713 = NewObj(2).Put("x", Get(c_710, "x")).Put("y", Get(c_710, "y")).V;
to_714 = NewObj(2).Put("x", Add(tx_707, GetIdx(origin_49, 0D))).Put("y", Add(ty_708, GetIdx(origin_49, 1D))).V;
kEnd_715 = (Truthy(Get(c_710, "bb")) ? Max(0.15, (26D / (ToNum(Get(c_710, "W")) * ToNum(Get(c_710, "s"))))) : 0.3);
Call(start_55, V.Undef, c_710, NewObj(4).Put("kind", ((V)("pickup"))).Put("dur", D_711).Put("run", Fn((V _self717, int _argc718, V c_724, V t_725, V _a722, V _a723, V[] _rest719) => {
V u_726 = default;
double hopUp_727 = 0;
double fly_728 = 0;
if (_self717.IsNullish) _self717 = GlobalV;
u_726 = (LtN(t_725, go_712) ? ((V)(0D)) : Call(SM_40, V.Undef, ((V)(((ToNum(t_725) - go_712) / (ToNum(D_711) - go_712))))));
Set(c_724, "x", Call(lerp_39, V.Undef, Get(from_713, "x"), Get(to_714, "x"), u_726));
Set(c_724, "y", Call(lerp_39, V.Undef, Get(from_713, "y"), Get(to_714, "y"), u_726));
hopUp_727 = (ToNum(Call(parab_42, V.Undef, ((V)((ToNum(t_725) / (go_712 * 0.9)))))) * 26D);
fly_728 = (ToNum(Call(parab_42, V.Undef, ((V)(((ToNum(t_725) - go_712) / (ToNum(D_711) - go_712)))))) * 60D);
return NewObj(4).Put("z", (LtN(t_725, go_712) ? Get(c_724, "z") : ((V)(90D)))).Put("k", Call(lerp_39, V.Undef, ((V)(1D)), ((V)(kEnd_715)), u_726)).Put("o", ((V)((LtN(t_725, (ToNum(D_711) * 0.8)) ? 1D : (1D - ((ToNum(t_725) - (ToNum(D_711) * 0.8)) / (ToNum(D_711) * 0.2))))))).Put("ext", NewObj(6).Put("lift", Call(toU_57, V.Undef, c_724, ((V)(((hopUp_727 + fly_728) * ToNum(Get(c_724, "s"))))))).Put("sq", Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((go_712 * 0.15))), ((V)(0.3)), ((V)("io"))), Arr(((V)((go_712 * 0.32))), ((V)((-0.3))), ((V)("o"))), Arr(((V)((go_712 * 0.8))), ((V)((-0.05))), ((V)("io"))), Arr(((V)(go_712)), ((V)(0.25)), ((V)("o"))), Arr(((V)((go_712 * 1.15))), ((V)((-0.3))), ((V)("o"))), Arr(D_711, ((V)(0D)), ((V)("io")))), t_725)).Put("armL", Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((go_712 * 0.3))), ((V)(50D)), ((V)("o"))), Arr(D_711, ((V)(40D)))), t_725)).Put("armR", Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((go_712 * 0.3))), ((V)(50D)), ((V)("o"))), Arr(D_711, ((V)(40D)))), t_725)).Put("tilt", Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((go_712 * 0.3))), ((V)(8D)), ((V)("io"))), Arr(((V)((go_712 * 0.6))), ((V)((-8D))), ((V)("io"))), Arr(((V)(go_712)), ((V)(0D)), ((V)("io")))), t_725)).Put("spin", Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(go_712)), ((V)(0D))), Arr(((V)((ToNum(D_711) * 0.9))), ((V)(360D)), ((V)("io"))), Arr(D_711, ((V)(360D)))), t_725)).V).V;
return default;
}, 2, "run", false)).Put("done", Fn((V _self729, int _argc730, V _a732, V _a733, V _a734, V _a735, V[] _rest731) => {
if (_self729.IsNullish) _self729 = GlobalV;
Set(c_710, "o", ((V)(0D)));
Set(c_710, "x", Get(to_714, "x"));
Set(c_710, "y", Get(to_714, "y"));
return default;
}, 0, "done", false)).V);
return default;
}, 4, "pickup", false)).Put("restore", Fn((V _self736, int _argc737, V id_743, V p_744, V _a741, V _a742, V[] _rest738) => {
V c_745 = default;
double D_746 = 0;
if (_self736.IsNullish) _self736 = GlobalV;
c_745 = Invoke(C_48, "get", id_743);
if (!(Truthy(c_745))) {
return default;
}
Set(c_745, "moves", Arr());
Object_assign(c_745, NewObj(6).Put("x", Add(Get(p_744, "x"), GetIdx(origin_49, 0D))).Put("y", Add(Get(p_744, "y"), GetIdx(origin_49, 1D))).Put("s", Get(p_744, "s")).Put("z", Get(p_744, "z")).Put("o", ((V)(1D))).Put("k", ((V)(1D))).V);
if (Truthy(Get(c_745, "ctrl"))) {
Invoke(Get(c_745, "ctrl"), "play", ((V)("idle")));
}
D_746 = 300D;
Call(start_55, V.Undef, c_745, NewObj(3).Put("kind", ((V)("enter"))).Put("dur", ((V)(D_746))).Put("run", Fn((V _self747, int _argc748, V c_754, V t_755, V _a752, V _a753, V[] _rest749) => {
if (_self747.IsNullish) _self747 = GlobalV;
return NewObj(1).Put("k", ((V)((0.3 + (0.7 * ToNum(Call(kv_41, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((D_746 * 0.7))), ((V)(1.12)), ((V)("o"))), Arr(((V)(D_746)), ((V)(1D)), ((V)("io")))), t_755))))))).V;
return default;
}, 2, "run", false)).V);
return default;
}, 2, "restore", false)).Put("win", Fn((V _self756, int _argc757, V id_763, V ms_764, V _a761, V _a762, V[] _rest758) => {
V c_765 = default;
V D_766 = default;
V lift_767 = default;
V sq_768 = default;
V arm_769 = default;
V tilt_770 = default;
V spin_771 = default;
if (_self756.IsNullish) _self756 = GlobalV;
c_765 = Invoke(C_48, "get", id_763);
if (!(Truthy(c_765))) {
return default;
}
if (Truthy(Get(c_765, "ctrl"))) {
Invoke(Get(c_765, "ctrl"), "play", ((V)("hopJoy")));
}
D_766 = (ms_764 is var _t772 && Truthy(_t772) ? _t772 : ((V)(1150D)));
Call(faceTo_62, V.Undef, c_765, ((V)(2D)));
lift_767 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_766) * 0.05))), ((V)(0D))), Arr(((V)((ToNum(D_766) * 0.145))), ((V)(34D)), ((V)("o"))), Arr(((V)((ToNum(D_766) * 0.24))), ((V)(0D)), ((V)("i"))), Arr(((V)((ToNum(D_766) * 0.34))), ((V)(0D))), Arr(((V)((ToNum(D_766) * 0.45))), ((V)(40D)), ((V)("o"))), Arr(((V)((ToNum(D_766) * 0.56))), ((V)(0D)), ((V)("i"))), Arr(((V)((ToNum(D_766) * 0.64))), ((V)(0D))), Arr(((V)((ToNum(D_766) * 0.8))), ((V)(62D)), ((V)("o"))), Arr(((V)((ToNum(D_766) * 0.95))), ((V)(0D)), ((V)("i"))), Arr(D_766, ((V)(0D))));
sq_768 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_766) * 0.04))), ((V)(0.22)), ((V)("io"))), Arr(((V)((ToNum(D_766) * 0.08))), ((V)((-0.3))), ((V)("o"))), Arr(((V)((ToNum(D_766) * 0.2))), ((V)((-0.08))), ((V)("io"))), Arr(((V)((ToNum(D_766) * 0.25))), ((V)(0.26)), ((V)("o"))), Arr(((V)((ToNum(D_766) * 0.31))), ((V)(0.2)), ((V)("io"))), Arr(((V)((ToNum(D_766) * 0.37))), ((V)((-0.3))), ((V)("o"))), Arr(((V)((ToNum(D_766) * 0.5))), ((V)((-0.08))), ((V)("io"))), Arr(((V)((ToNum(D_766) * 0.56))), ((V)(0.26)), ((V)("o"))), Arr(((V)((ToNum(D_766) * 0.62))), ((V)(0.24)), ((V)("io"))), Arr(((V)((ToNum(D_766) * 0.68))), ((V)((-0.36))), ((V)("o"))), Arr(((V)((ToNum(D_766) * 0.86))), ((V)((-0.1))), ((V)("io"))), Arr(((V)((ToNum(D_766) * 0.95))), ((V)(0.28)), ((V)("o"))), Arr(D_766, ((V)(0.06)), ((V)("io"))));
arm_769 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_766) * 0.08))), ((V)(46D)), ((V)("o"))), Arr(((V)((ToNum(D_766) * 0.9))), ((V)(46D))), Arr(D_766, ((V)(10D)), ((V)("io"))));
tilt_770 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_766) * 0.13))), ((V)(7D)), ((V)("io"))), Arr(((V)((ToNum(D_766) * 0.27))), ((V)(0D)), ((V)("io"))), Arr(((V)((ToNum(D_766) * 0.43))), ((V)((-7D))), ((V)("io"))), Arr(((V)((ToNum(D_766) * 0.57))), ((V)(0D)), ((V)("io"))));
spin_771 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((ToNum(D_766) * 0.68))), ((V)(0D))), Arr(((V)((ToNum(D_766) * 0.92))), ((V)(360D)), ((V)("io"))), Arr(D_766, ((V)(360D))));
Call(start_55, V.Undef, c_765, NewObj(4).Put("kind", ((V)("win"))).Put("dur", D_766).Put("run", Fn((V _self773, int _argc774, V c_780, V t_781, V _a778, V _a779, V[] _rest775) => {
if (_self773.IsNullish) _self773 = GlobalV;
return NewObj(1).Put("ext", NewObj(6).Put("lift", Call(toU_57, V.Undef, c_780, ((V)((ToNum(Call(kv_41, V.Undef, lift_767, t_781)) * ToNum(Get(c_780, "s"))))))).Put("sq", Call(kv_41, V.Undef, sq_768, t_781)).Put("armL", Call(kv_41, V.Undef, arm_769, t_781)).Put("armR", Call(kv_41, V.Undef, arm_769, t_781)).Put("tilt", Call(kv_41, V.Undef, tilt_770, t_781)).Put("spin", (Lt(t_781, D_766) ? Call(kv_41, V.Undef, spin_771, t_781) : ((V)(0D)))).V).V;
return default;
}, 2, "run", false)).Put("done", Fn((V _self782, int _argc783, V _a785, V _a786, V _a787, V _a788, V[] _rest784) => {
if (_self782.IsNullish) _self782 = GlobalV;
Call(land_61, V.Undef, c_765);
return default;
}, 0, "done", false)).V);
Invoke(Arr(((V)(0.26)), ((V)(0.56)), ((V)(0.96))), "forEach", Fn((V _self756, int _argc789, V f_795, V _a792, V _a793, V _a794, V[] _rest790) => {
return Call(G("setTimeout"), V.Undef, Fn((V _self756, int _argc803, V _a805, V _a806, V _a807, V _a808, V[] _rest804) => {
if (Truthy((Get(c_765, "I") is var _t809 && !Truthy(_t809) ? _t809 : Get(c_765, "bb")))) {
Call(burst_66, V.Undef, c_765, ((V)("hopSpark")), ((V)("feet")), ((V)(4D)));
}
return default;
}, 0, "", true), ((V)((ToNum(D_766) * ToNum(f_795)))));
}, 1, "", true));
Call(G("setTimeout"), V.Undef, Fn((V _self756, int _argc817, V _a819, V _a820, V _a821, V _a822, V[] _rest818) => {
if (Truthy((Get(c_765, "I") is var _t823 && !Truthy(_t823) ? _t823 : Get(c_765, "bb")))) {
Call(burst_66, V.Undef, c_765, ((V)("hopSpark")), ((V)("head")), ((V)(7D)));
}
return default;
}, 0, "", true), ((V)((ToNum(D_766) * 0.8))));
Call(hearts_65, V.Undef, c_765, ((V)(4D)), ((V)(260D)));
return default;
}, 2, "win", false)).Put("stuck", Fn((V _self824, int _argc825, V id_831, V _a828, V _a829, V _a830, V[] _rest826) => {
V c_832 = default;
V drip_833 = default;
if (_self824.IsNullish) _self824 = GlobalV;
c_832 = Invoke(C_48, "get", id_831);
if (!(Truthy(c_832))) {
return default;
}
Set(c_832, "moves", Invoke(Get(c_832, "moves"), "filter", Fn((V _self824, int _argc834, V m_840, V _a837, V _a838, V _a839, V[] _rest835) => {
return ((SEqS(Get(m_840, "kind"), "land") ? V.True : V.False) is var _t841 && Truthy(_t841) ? _t841 : Get(m_840, "keep"));
}, 1, "", true)));
if (Truthy(Get(c_832, "ctrl"))) {
Invoke(Get(c_832, "ctrl"), "play", ((V)("hopSadLook")));
}
Call(faceTo_62, V.Undef, c_832, ((V)(2D)));
Call(G("clearInterval"), V.Undef, Get(c_832, "sweat"));
drip_833 = Fn((V _self824, int _argc842, V _a844, V _a845, V _a846, V _a847, V[] _rest843) => {
if (Truthy((Get(c_832, "I") is var _t848 && !Truthy(_t848) ? _t848 : Get(c_832, "bb")))) {
Call(burst_66, V.Undef, c_832, ((V)("hopSweat")), ((V)("temple")));
}
return default;
}, 0, "", true);
Call(G("setTimeout"), V.Undef, drip_833, ((V)(360D)));
Set(c_832, "sweat", Call(G("setInterval"), V.Undef, drip_833, ((V)(720D))));
return default;
}, 1, "stuck", false)).Put("unstuck", Fn((V _self849, int _argc850, V id_856, V _a853, V _a854, V _a855, V[] _rest851) => {
V c_857 = default;
if (_self849.IsNullish) _self849 = GlobalV;
c_857 = Invoke(C_48, "get", id_856);
if (!(Truthy(c_857))) {
return default;
}
Call(G("clearInterval"), V.Undef, Get(c_857, "sweat"));
if (Truthy(Get(c_857, "ctrl"))) {
Invoke(Get(c_857, "ctrl"), "play", ((V)("hopPerk")));
}
return default;
}, 1, "unstuck", false)).Put("giggle", Fn((V _self858, int _argc859, V id_865, V _a862, V _a863, V _a864, V[] _rest860) => {
V c_866 = default;
if (_self858.IsNullish) _self858 = GlobalV;
c_866 = Invoke(C_48, "get", id_865);
if (Truthy((c_866 is var _t867 && !Truthy(_t867) ? _t867 : Get(c_866, "ctrl")))) {
Invoke(Get(c_866, "ctrl"), "play", ((V)("hopGiggle")));
}
return default;
}, 1, "giggle", false)).Put("pause", Fn((V _self868, int _argc869, V on_875, V _a872, V _a873, V _a874, V[] _rest870) => {
if (_self868.IsNullish) _self868 = GlobalV;
Invoke(window_28, "__rigPause", on_875);
return default;
}, 1, "pause", false)).V;
running_67 = (false ? V.True : V.False);
castRaw_70 = Get(api_64, "cast");
Set(api_64, "cast", Fn((V _self29, int _argc876, V list_882, V tag_883, V _a880, V _a881, V[] _rest877) => {
Set(api_64, "_sent", V.Null);
Call(castRaw_70, V.Undef, list_882, tag_883);
return default;
}, 2, "", true));
Set(window_28, "hopStage", api_64);
Set(api_64, "_C", C_48);
boot_71 = Fn((V _self29, int _argc884, V _a886, V _a887, V _a888, V _a889, V[] _rest885) => {
V R_890 = default;
R_890 = Get(window_28, "RiveRig");
if (Truthy((((((R_890 is var _t891 && !Truthy(_t891) ? _t891 : Get(R_890, "REST")) is var _t892 && !Truthy(_t892) ? _t892 : Get(R_890, "DEFS")) is var _t893 && !Truthy(_t893) ? _t893 : Get(Get(R_890, "DEFS"), "prickle")) is var _t894 && !Truthy(_t894) ? _t894 : Get(R_890, "movesV")) is var _t895 && !Truthy(_t895) ? _t895 : Get(window_28, "RiveGeneric")))) {
kv_41 = Get(R_890, "kv");
Call(addStates_47, V.Undef);
Call(post_36, V.Undef, NewObj(1).Put("type", ((V)("ready"))).V);
} else {
Call(G("setTimeout"), V.Undef, boot_71, ((V)(25D)));
}
return default;
}, 0, "", true);
Call(boot_71, V.Undef);
Set(window_28, "onerror", Fn((V _self29, int _argc896, V m_902, V _a899, V _a900, V _a901, V[] _rest897) => {
return Call(post_36, V.Undef, NewObj(2).Put("type", ((V)("error"))).Put("message", ((V)(ToStrS(m_902)))).V);
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
