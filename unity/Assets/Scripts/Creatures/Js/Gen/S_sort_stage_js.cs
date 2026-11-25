// sort-stage.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_sort_stage_js
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
Set((Get(G_8, "__stages") is var _t31 && Truthy(_t31) ? _t31 : Set(G_8, "__stages", NewObj(0).V)), "sort", NewObj(2).Put("win", W_13).Put("board", b_11).V);
Call(Fn((V _self32, int _argc33, V window_39, V _a36, V _a37, V _a38, V[] _rest34) => {
if (_self32.IsNullish) _self32 = GlobalV;
Call(Fn((V _self40, int _argc41, V _a43, V _a44, V _a45, V _a46, V[] _rest42) => {
V post_47 = default;
V board_48 = default;
V clamp_49 = default;
V lerp_50 = default;
V SM_51 = default;
V outQ_52 = default;
V outBack_53 = default;
V bounce_54 = default;
V parab_55 = default;
V kv_56 = default;
V AR_57 = default;
V ER_58 = default;
double BUDGET_59 = 0;
double LIFT_CAP_60 = 0;
V FAB_61 = default;
V fabric_62 = default;
V isGrain_63 = default;
V bakeGrain_64 = default;
V addStates_65 = default;
V C_66 = default;
V castTag_67 = default;
V mount_68 = default;
V unmount_69 = default;
V measure_70 = default;
V ready_71 = default;
V draw_72 = default;
V toU_73 = default;
V start_74 = default;
V stop_75 = default;
V TRAVEL_76 = default;
V land_77 = default;
V travel_78 = default;
V burst_79 = default;
V glow_80 = default;
V later_81 = default;
V letGo_82 = default;
V play_83 = default;
V shut_84 = default;
V edgeOf_85 = default;
V doorClip_86 = default;
V api_87 = default;
V running_88 = default;
V userPaused_89 = default;
V sleeping_90 = default;
V sync_91 = default;
V frame_92 = default;
V kick_93 = default;
V boot_94 = default;
if (_self40.IsNullish) _self40 = GlobalV;
fabric_62 = Fn((V _self95, int _argc96, V _a98, V _a99, V _a100, V _a101, V[] _rest97) => {
if (_self95.IsNullish) _self95 = GlobalV;
if (!SEq(FAB_61, V.Null)) {
return FAB_61;
}
FAB_61 = ((V)(""));
try {
double S_102 = 0;
V cv_103 = default;
V x_104 = default;
V im_105 = default;
double sd_106 = 0;
V rnd_107 = default;
V oct_108 = default;
V o1_109 = default;
V o2_110 = default;
double B_111 = 0;
V cb_112 = default;
V xb_113 = default;
S_102 = 128D;
cv_103 = Invoke(G("document"), "createElement", ((V)("canvas")));
Set(cv_103, "width", Set(cv_103, "height", ((V)(S_102))));
x_104 = Invoke(cv_103, "getContext", ((V)("2d")));
im_105 = Invoke(x_104, "createImageData", ((V)(S_102)), ((V)(S_102)));
sd_106 = 7D;
rnd_107 = Fn((V _self95, int _argc114, V _a116, V _a117, V _a118, V _a119, V[] _rest115) => {
return ((V)(((sd_106 = ((sd_106 * 16807D) % 2147483647D)) / 2147483647D)));
}, 0, "", true);
oct_108 = Fn((V _self95, int _argc120, V n_126, V _a123, V _a124, V _a125, V[] _rest121) => {
V g_127 = default;
double c_128 = 0;
V sm_129 = default;
g_127 = Arr();
{
double i_130 = 0;
i_130 = 0D;
while (true) {
if (!((i_130 < (ToNum(n_126) * ToNum(n_126))))) break;
Invoke(g_127, "push", Call(rnd_107, V.Undef));
i_130++;
}
}
c_128 = (S_102 / ToNum(n_126));
sm_129 = Fn((V _self95, int _argc132, V t_138, V _a135, V _a136, V _a137, V[] _rest133) => {
return ((V)(((ToNum(t_138) * ToNum(t_138)) * (3D - (2D * ToNum(t_138))))));
}, 1, "", true);
return Fn((V _self95, int _argc139, V px_145, V py_146, V _a143, V _a144, V[] _rest140) => {
double gx_147 = 0;
double gy_148 = 0;
double x0_149 = 0;
double y0_150 = 0;
V fx_151 = default;
V fy_152 = default;
V a_153 = default;
V t_154 = default;
V b_155 = default;
gx_147 = (ToNum(px_145) / c_128);
gy_148 = (ToNum(py_146) / c_128);
x0_149 = System.Math.Floor(gx_147);
y0_150 = System.Math.Floor(gy_148);
fx_151 = Call(sm_129, V.Undef, ((V)((gx_147 - x0_149))));
fy_152 = Call(sm_129, V.Undef, ((V)((gy_148 - y0_150))));
a_153 = Fn((V _self95, int _argc156, V i_162, V j_163, V _a160, V _a161, V[] _rest157) => {
return GetIdx(g_127, (((ToNum(Add(((V)((ToNum(j_163) % ToNum(n_126)))), n_126)) % ToNum(n_126)) * ToNum(n_126)) + (ToNum(Add(((V)((ToNum(i_162) % ToNum(n_126)))), n_126)) % ToNum(n_126))));
}, 2, "", true);
t_154 = Add(Call(a_153, V.Undef, ((V)(x0_149)), ((V)(y0_150))), ((V)(((ToNum(Call(a_153, V.Undef, ((V)((x0_149 + 1D))), ((V)(y0_150)))) - ToNum(Call(a_153, V.Undef, ((V)(x0_149)), ((V)(y0_150))))) * ToNum(fx_151)))));
b_155 = Add(Call(a_153, V.Undef, ((V)(x0_149)), ((V)((y0_150 + 1D)))), ((V)(((ToNum(Call(a_153, V.Undef, ((V)((x0_149 + 1D))), ((V)((y0_150 + 1D))))) - ToNum(Call(a_153, V.Undef, ((V)(x0_149)), ((V)((y0_150 + 1D)))))) * ToNum(fx_151)))));
return Add(t_154, ((V)(((ToNum(b_155) - ToNum(t_154)) * ToNum(fy_152)))));
return default;
}, 2, "", true);
return default;
}, 1, "", true);
o1_109 = Call(oct_108, V.Undef, ((V)(32D)));
o2_110 = Call(oct_108, V.Undef, ((V)(64D)));
{
double y_164 = 0;
y_164 = 0D;
while (true) {
if (!((y_164 < S_102))) break;
{
double X_166 = 0;
X_166 = 0D;
while (true) {
if (!((X_166 < S_102))) break;
double v_168 = 0;
double k_169 = 0;
v_168 = (ToNum(Add(Call(o1_109, V.Undef, ((V)(X_166)), ((V)(y_164))), Call(o2_110, V.Undef, ((V)(X_166)), ((V)(y_164))))) / 2D);
k_169 = (((y_164 * S_102) + X_166) * 4D);
SetIdx(Get(im_105, "data"), (k_169 + 3D), ((V)(Round(((0.2 * 255D) * v_168)))));
X_166++;
}
}
y_164++;
}
}
Invoke(x_104, "putImageData", im_105, ((V)(0D)), ((V)(0D)));
B_111 = 1024D;
cb_112 = Invoke(G("document"), "createElement", ((V)("canvas")));
Set(cb_112, "width", Set(cb_112, "height", ((V)(B_111))));
xb_113 = Invoke(cb_112, "getContext", ((V)("2d")));
Set(xb_113, "fillStyle", Invoke(xb_113, "createPattern", cv_103, ((V)("repeat"))));
Invoke(xb_113, "fillRect", ((V)(0D)), ((V)(0D)), ((V)(B_111)), ((V)(B_111)));
FAB_61 = Invoke(cb_112, "toDataURL", ((V)("image/png")));
} catch (System.Exception _ex170) {
V e_171 = default;
e_171 = Caught(_ex170);
FAB_61 = ((V)(""));
}
return FAB_61;
return default;
}, 0, "fabric", false);
bakeGrain_64 = Fn((V _self172, int _argc173, V svg_179, V _a176, V _a177, V _a178, V[] _rest174) => {
V els_180 = default;
V id_181 = default;
V f_182 = default;
V t_183 = default;
V im_184 = default;
V cm_185 = default;
V top_186 = default;
if (_self172.IsNullish) _self172 = GlobalV;
if ((!(Truthy(svg_179)) || !(Truthy(Call(fabric_62, V.Undef))))) {
return default;
}
els_180 = Invoke(new ArrBuilder().Spread(Invoke(svg_179, "querySelectorAll", ((V)("[filter]")))).V, "filter", Fn((V _self172, int _argc187, V e_193, V _a190, V _a191, V _a192, V[] _rest188) => {
V id_194 = default;
id_194 = GetIdx((Invoke(Invoke(e_193, "getAttribute", ((V)("filter"))), "match", NewRegExp(RX0, "url\\(#([^)]+)\\)", "")) is var _t195 && Truthy(_t195) ? _t195 : Arr()), 1D);
return (id_194 is var _t196 && !Truthy(_t196) ? _t196 : Call(isGrain_63, V.Undef, Invoke(svg_179, "getElementById", id_194)));
return default;
}, 1, "", true));
if (!(Truthy(Get(els_180, "length")))) {
return default;
}
id_181 = GetIdx(Invoke(Invoke(GetIdx(els_180, 0D), "getAttribute", ((V)("filter"))), "match", NewRegExp(RX0, "url\\(#([^)]+)\\)", "")), 1D);
f_182 = Invoke(svg_179, "getElementById", id_181);
t_183 = Invoke(f_182, "querySelector", ((V)("feTurbulence")));
im_184 = Invoke(G("document"), "createElementNS", ((V)("http://www.w3.org/2000/svg")), ((V)("feImage")));
Invoke(Arr(Arr(((V)("href")), FAB_61), Arr(((V)("x")), ((V)((-30D)))), Arr(((V)("y")), ((V)((-30D)))), Arr(((V)("width")), ((V)(160D))), Arr(((V)("height")), ((V)(160D))), Arr(((V)("preserveAspectRatio")), ((V)("none")))), "forEach", Fn((V _self172, int _argc197, V _a199, V _a200, V _a201, V _a202, V[] _rest198) => {
V a_205 = default;
V v_207 = default;
{ V _t203 = ListOf(_a199);
{ V _t204 = GetIdx(_t203, 0D);
a_205 = _t204; }
{ V _t206 = GetIdx(_t203, 1D);
v_207 = _t206; }
}
return Invoke(im_184, "setAttribute", a_205, v_207);
}, 1, "", true));
cm_185 = Get(t_183, "nextElementSibling");
Invoke(t_183, "replaceWith", im_184);
if (Truthy((cm_185 is var _t208 && !Truthy(_t208) ? _t208 : (SEqS(Get(cm_185, "tagName"), "feColorMatrix") ? V.True : V.False)))) {
Invoke(cm_185, "remove");
}
top_186 = Get(GetIdx(els_180, 0D), "parentNode");
while ((!SEq(top_186, svg_179) && !(Truthy(Invoke(els_180, "every", Fn((V _self172, int _argc209, V e_215, V _a212, V _a213, V _a214, V[] _rest210) => {
return Invoke(top_186, "contains", e_215);
}, 1, "", true)))))) {
top_186 = Get(top_186, "parentNode");
}
if (SEq(top_186, svg_179)) {
Invoke(els_180, "forEach", Fn((V _self172, int _argc216, V e_222, V _a219, V _a220, V _a221, V[] _rest217) => {
return Invoke(e_222, "setAttribute", ((V)("filter")), ((V)(JsStrBuf.Begin().S("url(#").V(id_181).S(")").End())));
}, 1, "", true));
return default;
}
Invoke(els_180, "forEach", Fn((V _self172, int _argc223, V e_229, V _a226, V _a227, V _a228, V[] _rest224) => {
return Invoke(e_229, "removeAttribute", ((V)("filter")));
}, 1, "", true));
Invoke(top_186, "setAttribute", ((V)("filter")), ((V)(JsStrBuf.Begin().S("url(#").V(id_181).S(")").End())));
return default;
}, 1, "bakeGrain", false);
addStates_65 = Fn((V _self230, int _argc231, V _a233, V _a234, V _a235, V _a236, V[] _rest232) => {
if (_self230.IsNullish) _self230 = GlobalV;
Object_assign(Get(Get(window_39, "RiveRig"), "PRE"), NewObj(4).Put("sortSweat", NewObj(8).Put("n", ((V)(1D))).Put("sp", ((V)(0D))).Put("vy", ((V)(6D))).Put("g", ((V)(34D))).Put("life", ((V)(950D))).Put("r", Arr(((V)(3D)), ((V)(3.4)))).Put("col", Arr(((V)("#8fd3ff")))).Put("kind", ((V)("drop"))).V).Put("sortSpark", NewObj(8).Put("n", ((V)(7D))).Put("sp", ((V)(34D))).Put("vy", ((V)((-12D)))).Put("g", ((V)(0D))).Put("life", ((V)(720D))).Put("r", Arr(((V)(3.6)), ((V)(5.6)))).Put("col", Arr(((V)("#fff3a0")), ((V)("#ffffff")), ((V)("#ffd23a")), ((V)("#ffd1f5")))).Put("kind", ((V)("star"))).V).Put("sortHeart", NewObj(7).Put("n", ((V)(1D))).Put("sp", ((V)(9D))).Put("vy", ((V)((-16D)))).Put("g", ((V)((-3D)))).Put("life", ((V)(1100D))).Put("r", Arr(((V)(1.8)), ((V)(2.2)))).Put("kind", ((V)("heart"))).V).Put("sortTear", NewObj(8).Put("n", ((V)(1D))).Put("sp", ((V)(0.6))).Put("vy", ((V)(3D))).Put("g", ((V)(18D))).Put("life", ((V)(1100D))).Put("r", Arr(((V)(2.2)), ((V)(2.5)))).Put("col", Arr(((V)("#8fd3ff")))).Put("kind", ((V)("drop"))).V).V);
Invoke(Get(window_39, "RiveRig"), "add", NewObj(7).Put("sortHeld", NewObj(3).Put("loop", ((V)(1000D))).Put("blend", ((V)(90D))).Put("k", NewObj(6).Put("smile", Arr(Arr(((V)(0D)), ((V)(0.8))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0.45))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0.35))))).Put("wide", Arr(Arr(((V)(0D)), ((V)(0.35))))).Put("blush", Arr(Arr(((V)(0D)), ((V)(0.4))))).Spread(Call(ER_58, V.Undef, Arr(Arr(((V)(0D)), ((V)(12D)))))).V).V).Put("sortJoy", NewObj(3).Put("dur", ((V)(1500D))).Put("blend", ((V)(80D))).Put("k", NewObj(5).Put("hap", Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(1200D)), ((V)(1D))), Arr(((V)(1500D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(1200D)), ((V)(1D))), Arr(((V)(1500D)), ((V)(0D)), ((V)("io"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(1100D)), ((V)(0.6))), Arr(((V)(1500D)), ((V)(0D)), ((V)("io"))))).Put("blush", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(1200D)), ((V)(0.6))), Arr(((V)(1500D)), ((V)(0D)), ((V)("io"))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(18D)), ((V)("io"))), Arr(((V)(400D)), ((V)((-18D))), ((V)("io"))), Arr(((V)(600D)), ((V)(18D)), ((V)("io"))), Arr(((V)(800D)), ((V)((-12D))), ((V)("io"))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).V).Put("sortNope", NewObj(3).Put("dur", ((V)(1700D))).Put("blend", ((V)(70D))).Put("k", NewObj(5).Put("frown", Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(1400D)), ((V)(1D))), Arr(((V)(1700D)), ((V)(0D)), ((V)("io"))))).Put("wide", Arr(Arr(((V)(0D)), ((V)(0.35))), Arr(((V)(1400D)), ((V)(0.35))), Arr(((V)(1700D)), ((V)(0D)), ((V)("io"))))).Put("teary", Arr(Arr(((V)(0D)), ((V)(0.35))), Arr(((V)(1400D)), ((V)(0.35))), Arr(((V)(1700D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))))).Spread(Call(ER_58, V.Undef, Arr(Arr(((V)(0D)), ((V)((-16D)))), Arr(((V)(1400D)), ((V)((-12D)))), Arr(((V)(1700D)), ((V)(0D)), ((V)("io")))))).V).V).Put("sortCaught", NewObj(3).Put("dur", ((V)(1400D))).Put("blend", ((V)(50D))).Put("k", NewObj(6).Put("wide", Arr(Arr(((V)(0D)), ((V)(1D))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0.75))))).Put("frown", Arr(Arr(((V)(0D)), ((V)(0.55))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))))).Put("blush", Arr(Arr(((V)(0D)), ((V)(0.8))))).Spread(Call(ER_58, V.Undef, Arr(Arr(((V)(0D)), ((V)((-18D))))))).V).V).Put("sortHuh", NewObj(3).Put("dur", ((V)(1600D))).Put("blend", ((V)(160D))).Put("k", NewObj(4).Put("frown", Arr(Arr(((V)(0D)), ((V)(0.3))), Arr(((V)(1300D)), ((V)(0.3))), Arr(((V)(1600D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))))).Put("htilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(7D)), ((V)("io"))), Arr(((V)(700D)), ((V)(7D))), Arr(((V)(1000D)), ((V)((-7D))), ((V)("io"))), Arr(((V)(1400D)), ((V)((-7D)))), Arr(((V)(1600D)), ((V)(0D)), ((V)("io"))))).Put("lx", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)((-0.9))), ((V)("io"))), Arr(((V)(700D)), ((V)((-0.9)))), Arr(((V)(1000D)), ((V)(0.9)), ((V)("io"))), Arr(((V)(1400D)), ((V)(0.9))), Arr(((V)(1600D)), ((V)(0D)), ((V)("io"))))).V).V).Put("sortDroop", NewObj(4).Put("dur", ((V)(760D))).Put("blend", ((V)(120D))).Put("next", ((V)("sortSad"))).Put("k", NewObj(9).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)((-0.12))), ((V)("o"))), Arr(((V)(520D)), ((V)(0.24)), ((V)("io"))), Arr(((V)(760D)), ((V)(0.16)), ((V)("io"))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(280D)), ((V)(0.15)), ((V)("o"))), Arr(((V)(600D)), ((V)((-0.6))), ((V)("io"))))).Put("ly", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(500D)), ((V)(0.6)), ((V)("io"))))).Put("frown", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(1D)), ((V)("io"))))).Put("teary", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(600D)), ((V)(0.7)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)(0.5)), ((V)("io"))), Arr(((V)(520D)), ((V)(0.25)), ((V)("io"))))).Spread(Call(ER_58, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(600D)), ((V)((-18D))), ((V)("io")))))).Spread(Call(AR_57, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(600D)), ((V)((-16D))), ((V)("io")))))).V).V).Put("sortSad", NewObj(4).Put("loop", ((V)(2600D))).Put("blend", ((V)(220D))).Put("noBlink", (true ? V.True : V.False)).Put("k", NewObj(9).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.16))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)((-0.6)))))).Put("ly", Arr(Arr(((V)(0D)), ((V)(0.6))))).Put("frown", Arr(Arr(((V)(0D)), ((V)(1D))))).Put("teary", Arr(Arr(((V)(0D)), ((V)(0.7))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0.25))))).Spread(Call(ER_58, V.Undef, Arr(Arr(((V)(0D)), ((V)((-18D))))))).Spread(Call(AR_57, V.Undef, Arr(Arr(((V)(0D)), ((V)((-16D))))))).V).V).V);
return default;
}, 0, "addStates", false);
mount_68 = Fn((V _self237, int _argc238, V c_244, V _a241, V _a242, V _a243, V[] _rest239) => {
if (_self237.IsNullish) _self237 = GlobalV;
Set(c_244, "sh", Invoke(G("document"), "createElement", ((V)("div"))));
Set(Get(c_244, "sh"), "className", ((V)("sh")));
Set(Get(Get(c_244, "sh"), "style"), "opacity", ((V)("0")));
Invoke(board_48, "appendChild", Get(c_244, "sh"));
Set(c_244, "el", Invoke(G("document"), "createElement", ((V)("div"))));
Set(Get(c_244, "el"), "className", ((V)("ch")));
Set(c_244, "inner", Invoke(G("document"), "createElement", ((V)("div"))));
Invoke(Get(c_244, "el"), "appendChild", Get(c_244, "inner"));
Invoke(board_48, "appendChild", Get(c_244, "el"));
Set(Get(Get(c_244, "el"), "style"), "opacity", ((V)("0")));
if (Truthy(Get(window_39, "__rgI"))) {
DeleteK(Get(window_39, "__rgI"), Get(c_244, "key"));
}
Set(c_244, "ctrl", Invoke(Get(window_39, "RiveRig"), "mount", Get(c_244, "inner"), Get(c_244, "key"), NewObj(1).Put("fidgets", (false ? V.True : V.False)).V));
Set(c_244, "I", Get(Get(c_244, "ctrl"), "_I"));
Set(c_244, "t0", Invoke(G("performance"), "now"));
return default;
}, 1, "mount", false);
unmount_69 = Fn((V _self245, int _argc246, V c_252, V _a249, V _a250, V _a251, V[] _rest247) => {
if (_self245.IsNullish) _self245 = GlobalV;
if (Truthy(Get(c_252, "ctrl"))) {
Invoke(Get(c_252, "ctrl"), "destroy");
}
if (Truthy(Get(c_252, "el"))) {
Invoke(Get(c_252, "el"), "remove");
}
if (Truthy(Get(c_252, "sh"))) {
Invoke(Get(c_252, "sh"), "remove");
}
return default;
}, 1, "unmount", false);
measure_70 = Fn((V _self253, int _argc254, V c_260, V _a257, V _a258, V _a259, V[] _rest255) => {
V svg_261 = default;
V b_262 = default;
if (_self253.IsNullish) _self253 = GlobalV;
svg_261 = Invoke(Get(c_260, "inner"), "querySelector", ((V)("svg")));
if (!(Truthy(svg_261))) {
return V.Null;
}
b_262 = V.Null;
try {
b_262 = Invoke(svg_261, "getBBox");
} catch (System.Exception _ex263) {
V e_264 = default;
e_264 = Caught(_ex263);

}
if ((!(Truthy(b_262)) || !(GtN(Get(b_262, "width"), 1D)))) {
return V.Null;
}
return NewObj(4).Put("cx", Add(Get(b_262, "x"), ((V)((ToNum(Get(b_262, "width")) / 2D))))).Put("gy", Add(Get(b_262, "y"), Get(b_262, "height"))).Put("bw", Get(b_262, "width")).Put("top", Get(b_262, "y")).V;
return default;
}, 1, "measure", false);
ready_71 = Fn((V _self265, int _argc266, V c_272, V _a269, V _a270, V _a271, V[] _rest267) => {
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
bb_273 = Call(measure_70, V.Undef, c_272);
if (!(Truthy(bb_273))) {
return (false ? V.True : V.False);
}
Set(c_272, "bb", bb_273);
Call(bakeGrain_64, V.Undef, Invoke(Get(c_272, "inner"), "querySelector", ((V)("svg"))));
Set(c_272, "settle", Add(Invoke(G("performance"), "now"), ((V)(80D))));
return (true ? V.True : V.False);
return default;
}, 1, "ready", false);
draw_72 = Fn((V _self275, int _argc276, V c_282, V b_283, V _a280, V _a281, V[] _rest277) => {
V m_284 = default;
double side_285 = 0;
double k_286 = 0;
double x_287 = 0;
double y_288 = 0;
V fx_289 = default;
V fy_290 = default;
V sq_291 = default;
double sx_292 = 0;
double sy_293 = 0;
JsStrBuf tf_294 = null;
V z_295 = default;
double o_296 = 0;
V up_297 = default;
double f_298 = 0;
double w_299 = 0;
double h_300 = 0;
double shx_301 = 0;
double shy_302 = 0;
if (_self275.IsNullish) _self275 = GlobalV;
if ((!(Truthy(Get(c_282, "bb"))) || !(Truthy(Get(c_282, "el"))))) {
return default;
}
m_284 = (Get(c_282, "cur") is var _t303 && Truthy(_t303) ? _t303 : NewObj(0).V);
side_285 = ((ToNum(Get(c_282, "P")) * ToNum(Get(c_282, "s"))) * ToNum((Get(m_284, "k").IsNullish ? ((V)(1D)) : Get(m_284, "k"))));
k_286 = ((0.88 * side_285) / 100D);
x_287 = ((ToNum(Add(Add(Get(c_282, "x"), ((V)((ToNum(Get(c_282, "P")) / 2D)))), (Get(m_284, "dx") is var _t304 && Truthy(_t304) ? _t304 : ((V)(0D))))) - (side_285 / 2D)) + (0.06 * side_285));
y_288 = ((ToNum(Add(Add(Get(c_282, "y"), ((V)((ToNum(Get(c_282, "P")) / 2D)))), (Get(m_284, "dy") is var _t305 && Truthy(_t305) ? _t305 : ((V)(0D))))) - (side_285 / 2D)) + (0.06 * side_285));
fx_289 = Get(Get(c_282, "bb"), "cx");
fy_290 = Get(Get(c_282, "bb"), "gy");
sq_291 = Call(clamp_49, V.Undef, (Get(b_283, "sq") is var _t306 && Truthy(_t306) ? _t306 : ((V)(0D))), ((V)((-0.45))), ((V)(0.45)));
sx_292 = (1D + (ToNum(sq_291) * 0.42));
sy_293 = (1D - (ToNum(sq_291) * 0.5));
tf_294 = new JsStrBuf(JsStrBuf.Begin().S("translate(").V(Invoke(((V)(x_287)), "toFixed", ((V)(2D)))).S("px,").V(Invoke(((V)((y_288 - ToNum((Get(b_283, "lift") is var _t307 && Truthy(_t307) ? _t307 : ((V)(0D))))))), "toFixed", ((V)(2D)))).S("px) scale(").V(Invoke(((V)(k_286)), "toFixed", ((V)(4D)))).S(")").End());
if (Truthy((sq_291 is var _t308 && Truthy(_t308) ? _t308 : Get(b_283, "tilt")))) {
tf_294.S(" translate(").V(Invoke(fx_289, "toFixed", ((V)(2D)))).S("px,").V(Invoke(fy_290, "toFixed", ((V)(2D)))).S("px) rotate(").V(Invoke((Get(b_283, "tilt") is var _t309 && Truthy(_t309) ? _t309 : ((V)(0D))), "toFixed", ((V)(2D)))).S("deg) scale(").V(Invoke(((V)(sx_292)), "toFixed", ((V)(3D)))).S(",").V(Invoke(((V)(sy_293)), "toFixed", ((V)(3D)))).S(") translate(").V(Invoke(((V)((-ToNum(fx_289)))), "toFixed", ((V)(2D)))).S("px,").V(Invoke(((V)((-ToNum(fy_290)))), "toFixed", ((V)(2D)))).S("px)");
}
Set(Get(Get(c_282, "el"), "style"), "transform", ((V)(tf_294.Str)));
z_295 = (!Get(m_284, "z").IsNullish ? Get(m_284, "z") : Get(c_282, "z"));
Set(Get(Get(c_282, "el"), "style"), "zIndex", ((V)(ToStrS(z_295))));
o_296 = (ToNum(Get(c_282, "o")) * ToNum((Get(m_284, "o").IsNullish ? ((V)(1D)) : Get(m_284, "o"))));
Set(Get(Get(c_282, "el"), "style"), "opacity", ((V)(ToStrS(((V)((Round((o_296 * 100D)) / 100D)))))));
Set(c_282, "kNow", ((V)(k_286)));
up_297 = Add((Get(b_283, "lift") is var _t310 && Truthy(_t310) ? _t310 : ((V)(0D))), ((V)((ToNum((Get(b_283, "rigLift") is var _t311 && Truthy(_t311) ? _t311 : ((V)(0D)))) * k_286))));
f_298 = (1D - ToNum(Call(clamp_49, V.Undef, ((V)((ToNum(up_297) / (ToNum(Get(c_282, "P")) * 0.9)))), ((V)(0D)), ((V)(0.55)))));
w_299 = (((ToNum(Get(Get(c_282, "bb"), "bw")) * k_286) * 0.94) * f_298);
h_300 = (w_299 * 0.2);
shx_301 = ((x_287 + (ToNum(fx_289) * k_286)) - (w_299 / 2D));
shy_302 = ((y_288 + (ToNum(fy_290) * k_286)) - (h_300 * 0.55));
Set(Get(Get(c_282, "sh"), "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").V(Invoke(((V)(shx_301)), "toFixed", ((V)(2D)))).S("px,").V(Invoke(((V)(shy_302)), "toFixed", ((V)(2D)))).S("px) scale(").V(Invoke(((V)((w_299 / 100D))), "toFixed", ((V)(4D)))).S(",").V(Invoke(((V)((h_300 / 100D))), "toFixed", ((V)(4D)))).S(")").End())));
Set(Get(Get(c_282, "sh"), "style"), "zIndex", ((V)(ToStrS(((V)((ToNum(z_295) - 1D)))))));
Set(Get(Get(c_282, "sh"), "style"), "opacity", ((V)((Truthy(Invoke(Get(Get(c_282, "el"), "classList"), "contains", ((V)("air")))) ? "0" : ToStrS(((V)((Round(((o_296 * f_298) * 100D)) / 100D))))))));
return default;
}, 2, "draw", false);
start_74 = Fn((V _self312, int _argc313, V c_319, V mv_320, V _a317, V _a318, V[] _rest314) => {
if (_self312.IsNullish) _self312 = GlobalV;
Set(mv_320, "t0", Add(Invoke(G("performance"), "now"), (Get(mv_320, "delay") is var _t321 && Truthy(_t321) ? _t321 : ((V)(0D)))));
if (Get(mv_320, "prio").IsNullish) {
Set(mv_320, "prio", ((V)(2D)));
}
Invoke(Get(c_319, "moves"), "push", mv_320);
Call(kick_93, V.Undef);
return mv_320;
return default;
}, 2, "start", false);
stop_75 = Fn((V _self322, int _argc323, V c_329, V kinds_330, V _a327, V _a328, V[] _rest324) => {
V hit_331 = default;
if (_self322.IsNullish) _self322 = GlobalV;
hit_331 = Fn((V _self322, int _argc332, V m_338, V _a335, V _a336, V _a337, V[] _rest333) => {
return ((!(Truthy(kinds_330)) ? V.True : V.False) is var _t339 && Truthy(_t339) ? _t339 : Invoke(kinds_330, "includes", Get(m_338, "kind")));
}, 1, "", true);
Invoke(Get(c_329, "moves"), "forEach", Fn((V _self322, int _argc340, V m_346, V _a343, V _a344, V _a345, V[] _rest341) => {
if (Truthy(Call(hit_331, V.Undef, m_346))) {
Set(m_346, "dead", (true ? V.True : V.False));
}
return default;
}, 1, "", true));
if (Truthy(Get(c_329, "iter"))) {
Invoke(Get(c_329, "iter"), "forEach", Fn((V _self322, int _argc347, V m_353, V _a350, V _a351, V _a352, V[] _rest348) => {
if (Truthy(Call(hit_331, V.Undef, m_353))) {
Set(m_353, "dead", (true ? V.True : V.False));
}
return default;
}, 1, "", true));
}
Set(c_329, "moves", Invoke(Get(c_329, "moves"), "filter", Fn((V _self322, int _argc354, V m_360, V _a357, V _a358, V _a359, V[] _rest355) => {
return (!(Truthy(Get(m_360, "dead"))) ? V.True : V.False);
}, 1, "", true)));
return default;
}, 2, "stop", false);
land_77 = Fn((V _self361, int _argc362, V c_368, V _a365, V _a366, V _a367, V[] _rest363) => {
double D_373 = 0;
V sq_374 = default;
V arms_375 = default;
V hard_370 = default;
V crowd_372 = default;
if (_self361.IsNullish) _self361 = GlobalV;
{ V _t369 = _a365; if (_t369.IsUndef) _t369 = ((V)(0.3));
hard_370 = _t369; }
{ V _t371 = _a366; if (_t371.IsUndef) _t371 = (false ? V.True : V.False);
crowd_372 = _t371; }
D_373 = 380D;
sq_374 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(40D)), hard_370, ((V)("o"))), Arr(((V)(140D)), ((V)(((-ToNum(hard_370)) * 0.45))), ((V)("io"))), Arr(((V)(240D)), ((V)((ToNum(hard_370) * 0.2))), ((V)("io"))), Arr(((V)(320D)), ((V)(((-ToNum(hard_370)) * 0.08))), ((V)("io"))), Arr(((V)(D_373)), ((V)(0D)), ((V)("io"))));
arms_375 = Arr(Arr(((V)(0D)), ((V)(16D))), Arr(((V)(60D)), ((V)((-16D))), ((V)("o"))), Arr(((V)(200D)), ((V)(8D)), ((V)("io"))), Arr(((V)(D_373)), ((V)(0D)), ((V)("io"))));
return Call(start_74, V.Undef, c_368, NewObj(4).Put("kind", ((V)("land"))).Put("dur", ((V)(D_373))).Put("prio", ((V)((Truthy(crowd_372) ? 1D : 2D)))).Put("run", Fn((V _self376, int _argc377, V c_383, V t_384, V _a381, V _a382, V[] _rest378) => {
V s_385 = default;
V a_386 = default;
if (_self376.IsNullish) _self376 = GlobalV;
s_385 = Call(kv_56, V.Undef, sq_374, t_384);
a_386 = Call(kv_56, V.Undef, arms_375, t_384);
return (Truthy(crowd_372) ? NewObj(2).Put("body", NewObj(1).Put("sq", s_385).V).Put("ext", NewObj(2).Put("armL", a_386).Put("armR", a_386).V).V : NewObj(1).Put("ext", NewObj(3).Put("sq", s_385).Put("armL", a_386).Put("armR", a_386).V).V);
return default;
}, 2, "run", false)).V);
return default;
}, 3, "land", false);
travel_78 = Fn((V _self387, int _argc388, V c_394, V to_395, V o_396, V then_397, V[] _rest389) => {
V from_398 = default;
double dist_399 = 0;
V D_400 = default;
V H_401 = default;
double side_402 = 0;
V ease_403 = default;
V crowd_404 = default;
if (_self387.IsNullish) _self387 = GlobalV;
from_398 = NewObj(3).Put("x", Get(c_394, "x")).Put("y", Get(c_394, "y")).Put("s", Get(c_394, "s")).V;
dist_399 = Hypot((ToNum(Get(to_395, "x")) - ToNum(Get(from_398, "x"))), (ToNum(Get(to_395, "y")) - ToNum(Get(from_398, "y"))));
D_400 = (Get(o_396, "ms") is var _t405 && Truthy(_t405) ? _t405 : Call(clamp_49, V.Undef, ((V)((200D + (dist_399 * 0.6)))), ((V)(220D)), ((V)(520D))));
H_401 = (!Get(o_396, "h").IsNullish ? Get(o_396, "h") : ((V)(Min((ToNum(Get(c_394, "P")) * 0.7), (8D + (dist_399 * 0.25))))));
side_402 = (Sign((ToNum(Get(to_395, "x")) - ToNum(Get(from_398, "x")))) * Min(1D, (System.Math.Abs((ToNum(Get(to_395, "x")) - ToNum(Get(from_398, "x")))) / (ToNum(Get(c_394, "P")) * 1.5))));
ease_403 = (Truthy(Get(o_396, "back")) ? outBack_53 : outQ_52);
crowd_404 = (!(!(Truthy(Get(o_396, "crowd")))) ? V.True : V.False);
return Call(start_74, V.Undef, c_394, NewObj(6).Put("kind", (Get(o_396, "kind") is var _t406 && Truthy(_t406) ? _t406 : ((V)("go")))).Put("delay", Get(o_396, "delay")).Put("dur", D_400).Put("prio", ((V)((Truthy(crowd_404) ? 1D : 2D)))).Put("run", Fn((V _self407, int _argc408, V c_414, V t_415, V _a412, V _a413, V[] _rest409) => {
V u_416 = default;
V e_417 = default;
V air_418 = default;
V arms_419 = default;
if (_self407.IsNullish) _self407 = GlobalV;
u_416 = Call(clamp_49, V.Undef, ((V)((ToNum(t_415) / ToNum(D_400)))), ((V)(0D)), ((V)(1D)));
e_417 = Call(ease_403, V.Undef, u_416);
air_418 = Call(parab_55, V.Undef, u_416);
Set(c_414, "x", Call(lerp_50, V.Undef, Get(from_398, "x"), Get(to_395, "x"), e_417));
Set(c_414, "y", Call(lerp_50, V.Undef, Get(from_398, "y"), Get(to_395, "y"), e_417));
Set(c_414, "s", Call(lerp_50, V.Undef, Get(from_398, "s"), (Get(to_395, "s").IsNullish ? Get(from_398, "s") : Get(to_395, "s")), Call(outQ_52, V.Undef, u_416)));
arms_419 = NewObj(3).Put("armL", ((V)((34D * ToNum(air_418))))).Put("armR", ((V)((34D * ToNum(air_418))))).Put("lean", ((V)(((side_402 * 2.5) * ToNum(air_418))))).V;
return (Truthy(crowd_404) ? NewObj(3).Put("z", ((V)(40D))).Put("body", NewObj(3).Put("lift", ((V)((ToNum(H_401) * ToNum(air_418))))).Put("sq", ((V)(((-0.24) * ToNum(air_418))))).Put("tilt", ((V)(((side_402 * 10D) * ToNum(air_418))))).V).Put("ext", arms_419).V : NewObj(2).Put("z", ((V)(40D))).Put("ext", Object_assign(NewObj(3).Put("lift", Call(toU_73, V.Undef, c_414, ((V)((ToNum(H_401) * ToNum(air_418)))))).Put("sq", ((V)(((-0.24) * ToNum(air_418))))).Put("tilt", ((V)(((side_402 * 10D) * ToNum(air_418))))).V, arms_419)).V);
return default;
}, 2, "run", false)).Put("done", Fn((V _self420, int _argc421, V _a423, V _a424, V _a425, V _a426, V[] _rest422) => {
if (_self420.IsNullish) _self420 = GlobalV;
Set(c_394, "x", Get(to_395, "x"));
Set(c_394, "y", Get(to_395, "y"));
if (!Get(to_395, "s").IsNullish) {
Set(c_394, "s", Get(to_395, "s"));
}
Set(c_394, "z", (!Get(to_395, "z").IsNullish ? Get(to_395, "z") : ((V)(10D))));
if (!SEq(Get(o_396, "land"), (false ? V.True : V.False))) {
Call(land_77, V.Undef, c_394, (Get(o_396, "land") is var _t427 && Truthy(_t427) ? _t427 : ((V)(0.3))), crowd_404);
}
if (Truthy(then_397)) {
Call(then_397, V.Undef);
}
return default;
}, 0, "done", false)).V);
return default;
}, 4, "travel", false);
burst_79 = Fn((V _self428, int _argc429, V c_435, V kind_436, V where_437, V n_438, V[] _rest430) => {
V b_439 = default;
V W_440 = default;
V p_441 = default;
if (_self428.IsNullish) _self428 = GlobalV;
if ((!(Truthy(Get(c_435, "I"))) || !(Truthy(Get(c_435, "bb"))))) {
return default;
}
b_439 = Get(c_435, "bb");
W_440 = (Get(Get(c_435, "I"), "W") is var _t442 && Truthy(_t442) ? _t442 : NewObj(0).V);
p_441 = (SEqS(where_437, "feet") ? Arr(Get(b_439, "cx"), ((V)((ToNum(Get(b_439, "gy")) - 2D)))) : (SEqS(where_437, "head") ? Arr(Get(b_439, "cx"), Add(Get(b_439, "top"), ((V)(4D)))) : (SEqS(where_437, "temple") ? Arr(Add(Get(b_439, "cx"), ((V)((ToNum(Get(b_439, "bw")) * 0.34)))), Add(Get(b_439, "top"), ((V)((ToNum(Get(b_439, "bw")) * 0.2))))) : (GetK(W_440, where_437) is var _t443 && Truthy(_t443) ? _t443 : Arr(((V)(50D)), ((V)(50D)))))));
try {
V e_444 = default;
e_444 = Get(Get(window_39, "RiveRig"), "emit");
if (Truthy(e_444)) {
Call(e_444, V.Undef, Get(c_435, "I"), kind_436, p_441, n_438);
}
} catch (System.Exception _ex445) {
V x_446 = default;
x_446 = Caught(_ex445);

}
return default;
}, 4, "burst", false);
edgeOf_85 = Fn((V _self447, int _argc448, V d_454, V th_455, V p_456, V _a453, V[] _rest449) => {
double f_457 = 0;
double r_458 = 0;
if (_self447.IsNullish) _self447 = GlobalV;
f_457 = (ToNum(p_456) / (ToNum(p_456) - (ToNum(Get(d_454, "w")) * FdLibm.Sin(ToNum(th_455)))));
r_458 = (((ToNum(Get(d_454, "w")) * FdLibm.Cos(ToNum(th_455))) - (ToNum(Get(d_454, "w")) / 2D)) * f_457);
return (SEqS(Get(d_454, "hinge"), "left") ? Add(Add(Get(d_454, "x0"), ((V)((ToNum(Get(d_454, "w")) / 2D)))), ((V)(r_458))) : ((V)((ToNum(Add(Get(d_454, "x0"), ((V)((ToNum(Get(d_454, "w")) / 2D))))) - r_458))));
return default;
}, 3, "edgeOf", false);
doorClip_86 = Fn((V _self459, int _argc460, V now_466, V _a463, V _a464, V _a465, V[] _rest461) => {
double t_467 = 0;
V u_468 = default;
double open_469 = 0;
double th_470 = 0;
double L_471 = 0;
double R_472 = 0;
V W_473 = default;
if (_self459.IsNullish) _self459 = GlobalV;
if (!(Truthy(shut_84))) {
return (false ? V.True : V.False);
}
t_467 = (ToNum(now_466) - ToNum(Get(shut_84, "t0")));
if ((t_467 < 0D)) {
return (true ? V.True : V.False);
}
u_468 = Call(clamp_49, V.Undef, ((V)((t_467 / ToNum(Get(shut_84, "ms"))))), ((V)(0D)), ((V)(1D)));
open_469 = (1D - (ToNum(u_468) * ToNum(u_468)));
th_470 = (((ToNum(Get(shut_84, "deg")) * open_469) * System.Math.PI) / 180D);
L_471 = (-10000D);
R_472 = 10000D;
{
foreach (V _k474 in new JsIter(Get(shut_84, "list"))) {
V d_475 = default;
d_475 = _k474;
V e_476 = default;
e_476 = Call(edgeOf_85, V.Undef, d_475, ((V)(th_470)), Get(shut_84, "persp"));
if (SEqS(Get(d_475, "hinge"), "left")) {
if (Gt(e_476, Get(d_475, "x0"))) {
L_471 = Max(L_471, ToNum(Add(e_476, Get(shut_84, "lead"))));
}
} else {
if (Lt(e_476, Add(Get(d_475, "x0"), Get(d_475, "w")))) {
R_472 = Min(R_472, (ToNum(e_476) - ToNum(Get(shut_84, "lead"))));
}
}
}
}
W_473 = Get(window_39, "innerWidth");
Set(Get(board_48, "style"), "clipPath", ((V)(((L_471 >= R_472) ? "inset(0 0 0 100%)" : JsStrBuf.Begin().S("inset(0px ").V(Invoke(((V)(Max(0D, (ToNum(W_473) - R_472)))), "toFixed", ((V)(1D)))).S("px 0px ").V(Invoke(((V)(Max(0D, L_471))), "toFixed", ((V)(1D)))).S("px)").End()))));
return (LtN(u_468, 1D) ? V.True : V.False);
return default;
}, 1, "doorClip", false);
frame_92 = Fn((V _self477, int _argc478, V _a480, V _a481, V _a482, V _a483, V[] _rest479) => {
V now_484 = default;
V busy_485 = default;
V allReady_486 = default;
V want_487 = default;
V must_488 = default;
V rest_489 = default;
V on_490 = default;
if (_self477.IsNullish) _self477 = GlobalV;
now_484 = Invoke(G("performance"), "now");
busy_485 = Call(doorClip_86, V.Undef, now_484);
allReady_486 = (true ? V.True : V.False);
want_487 = Arr();
{
foreach (V _k491 in new JsIter(Invoke(C_66, "values"))) {
V c_492 = default;
c_492 = _k491;
V ext_493 = default;
V body_494 = default;
V cur_495 = default;
double prio_496 = 0;
V list_497 = default;
V kept_498 = default;
if (!(Truthy(Call(ready_71, V.Undef, c_492)))) {
if (((((ToNum(now_484) - ToNum(Get(c_492, "t0"))) > 9000D) && !castTag_67.IsNullish) && !SEq(Get(api_87, "_sent"), castTag_67))) {
Set(api_87, "_sent", castTag_67);
Call(post_47, V.Undef, NewObj(4).Put("type", ((V)("cast"))).Put("tag", castTag_67).Put("ok", (false ? V.True : V.False)).Put("key", Get(c_492, "key")).V);
}
allReady_486 = (false ? V.True : V.False);
busy_485 = (busy_485 is var _t499 && Truthy(_t499) ? _t499 : (((ToNum(now_484) - ToNum(Get(c_492, "t0"))) < 9000D) ? V.True : V.False));
continue;
}
ext_493 = NewObj(0).V;
body_494 = NewObj(0).V;
cur_495 = NewObj(2).Put("dx", ((V)(0D))).Put("dy", ((V)(0D))).V;
prio_496 = 0D;
list_497 = Get(c_492, "moves");
Set(c_492, "moves", Arr());
Set(c_492, "iter", list_497);
kept_498 = Arr();
{
foreach (V _k500 in new JsIter(list_497)) {
V m_501 = default;
m_501 = _k500;
double t_502 = 0;
V r_503 = default;
if (Truthy(Get(m_501, "dead"))) {
continue;
}
t_502 = (ToNum(now_484) - ToNum(Get(m_501, "t0")));
if ((t_502 < 0D)) {
if (Truthy(Get(m_501, "before"))) {
Object_assign(cur_495, Get(m_501, "before"));
}
Invoke(kept_498, "push", m_501);
continue;
}
if (Ge(((V)(t_502)), Get(m_501, "dur"))) {
Invoke(m_501, "run", c_492, Get(m_501, "dur"));
if (Truthy(((!(Truthy(Get(m_501, "dead"))) ? V.True : V.False) is var _t504 && !Truthy(_t504) ? _t504 : Get(m_501, "done")))) {
Invoke(m_501, "done");
}
continue;
}
r_503 = (Invoke(m_501, "run", c_492, ((V)(t_502))) is var _t505 && Truthy(_t505) ? _t505 : NewObj(0).V);
if (Truthy(Get(m_501, "fin"))) {
continue;
}
prio_496 = Max(prio_496, ToNum(Get(m_501, "prio")));
if (Truthy(Get(r_503, "dx"))) {
OpSet(cur_495, "dx", 0, Get(r_503, "dx"));
}
if (Truthy(Get(r_503, "dy"))) {
OpSet(cur_495, "dy", 0, Get(r_503, "dy"));
}
if (!Get(r_503, "k").IsNullish) {
Set(cur_495, "k", ((V)((ToNum((Get(cur_495, "k").IsNullish ? ((V)(1D)) : Get(cur_495, "k"))) * ToNum(Get(r_503, "k"))))));
}
if (!Get(r_503, "o").IsNullish) {
Set(cur_495, "o", ((V)((ToNum((Get(cur_495, "o").IsNullish ? ((V)(1D)) : Get(cur_495, "o"))) * ToNum(Get(r_503, "o"))))));
}
if (!Get(r_503, "z").IsNullish) {
Set(cur_495, "z", ((V)(Max(ToNum((Get(cur_495, "z") is var _t506 && Truthy(_t506) ? _t506 : ((V)(0D)))), ToNum(Get(r_503, "z"))))));
}
if (Truthy(Get(r_503, "ext"))) {
{
foreach (V _k507 in ForInKeys(Get(r_503, "ext"))) {
V k_508 = default;
k_508 = _k507;
SetK(ext_493, k_508, Add((GetK(ext_493, k_508) is var _t509 && Truthy(_t509) ? _t509 : ((V)(0D))), GetK(Get(r_503, "ext"), k_508)));
}
}
}
if (Truthy(Get(r_503, "body"))) {
{
foreach (V _k510 in ForInKeys(Get(r_503, "body"))) {
V k_511 = default;
k_511 = _k510;
SetK(body_494, k_511, Add((GetK(body_494, k_511) is var _t512 && Truthy(_t512) ? _t512 : ((V)(0D))), GetK(Get(r_503, "body"), k_511)));
}
}
}
Invoke(kept_498, "push", m_501);
}
}
Set(c_492, "iter", V.Null);
Set(c_492, "moves", Invoke(Invoke(kept_498, "filter", Fn((V _self477, int _argc513, V m_519, V _a516, V _a517, V _a518, V[] _rest514) => {
return (!(Truthy(Get(m_519, "dead"))) ? V.True : V.False);
}, 1, "", true)), "concat", Get(c_492, "moves")));
OpSet(c_492, "vx", 2, ((V)(0.86)));
OpSet(c_492, "vy", 2, ((V)(0.86)));
if (Truthy((Get(c_492, "sway") is var _t520 && !Truthy(_t520) ? _t520 : (Gt(now_484, Get(Get(c_492, "sway"), "t0")) ? V.True : V.False)))) {
double w_521 = 0;
w_521 = ((ToNum(now_484) - ToNum(Get(Get(c_492, "sway"), "t0"))) / 1000D);
Set(body_494, "tilt", Add((Get(body_494, "tilt") is var _t522 && Truthy(_t522) ? _t522 : ((V)(0D))), ((V)((3D * FdLibm.Sin(ToNum(Add(((V)((w_521 * 2.4))), Get(Get(c_492, "sway"), "ph")))))))));
Set(body_494, "sq", Add((Get(body_494, "sq") is var _t523 && Truthy(_t523) ? _t523 : ((V)(0D))), ((V)((0.02 * FdLibm.Sin(ToNum(Add(((V)((w_521 * 4.8))), Get(Get(c_492, "sway"), "ph")))))))));
busy_485 = (true ? V.True : V.False);
}
if (!Get(ext_493, "sq").IsNullish) {
Set(ext_493, "sq", Call(clamp_49, V.Undef, Get(ext_493, "sq"), ((V)((-0.45))), ((V)(0.45))));
}
if (GtN(Get(ext_493, "lift"), LIFT_CAP_60)) {
Set(body_494, "lift", Add((Get(body_494, "lift") is var _t524 && Truthy(_t524) ? _t524 : ((V)(0D))), ((V)(((ToNum(Get(ext_493, "lift")) - LIFT_CAP_60) * ToNum((Get(c_492, "kNow") is var _t525 && Truthy(_t525) ? _t525 : ((V)(0D)))))))));
Set(ext_493, "lift", ((V)(LIFT_CAP_60)));
}
Set(body_494, "rigLift", (Get(ext_493, "lift") is var _t526 && Truthy(_t526) ? _t526 : ((V)(0D))));
Set(c_492, "cur", cur_495);
if (Truthy(Get(c_492, "ctrl"))) {
Invoke(Get(c_492, "ctrl"), "ext", ext_493);
}
Call(draw_72, V.Undef, c_492, body_494);
if (Truthy(Get(Get(c_492, "moves"), "length"))) {
Set(c_492, "settle", Add(now_484, ((V)(450D))));
busy_485 = (true ? V.True : V.False);
}
Set(c_492, "prio", ((V)(prio_496)));
if (Truthy((Get(Get(c_492, "moves"), "length") is var _t527 && Truthy(_t527) ? _t527 : (Lt(now_484, Get(c_492, "settle")) ? V.True : V.False)))) {
Invoke(want_487, "push", c_492);
if (Truthy(Get(c_492, "I"))) {
Set(Get(c_492, "I"), "blinkAt", ((V)(Max(ToNum(Get(Get(c_492, "I"), "blinkAt")), ToNum(Add(now_484, ((V)(700D))))))));
if (!(Truthy(Get(Get(c_492, "moves"), "length")))) {
Set(Get(c_492, "I"), "gl", Arr(((V)(0D)), ((V)(0D))));
Set(Get(c_492, "I"), "glAt", Add(now_484, ((V)(4000D))));
}
}
busy_485 = (true ? V.True : V.False);
}
}
}
must_488 = Invoke(want_487, "filter", Fn((V _self477, int _argc528, V c_534, V _a531, V _a532, V _a533, V[] _rest529) => {
return (GeN(Get(c_534, "prio"), 2D) ? V.True : V.False);
}, 1, "", true));
rest_489 = Invoke(Invoke(Invoke(want_487, "filter", Fn((V _self477, int _argc543, V c_549, V _a546, V _a547, V _a548, V[] _rest544) => {
return (LtN(Get(c_549, "prio"), 2D) ? V.True : V.False);
}, 1, "", true)), "sort", Fn((V _self477, int _argc535, V a_541, V b_542, V _a539, V _a540, V[] _rest536) => {
return ((V)((ToNum(Get(a_541, "lastR")) - ToNum(Get(b_542, "lastR")))));
}, 2, "", true)), "slice", ((V)(0D)), ((V)(BUDGET_59)));
on_490 = New(G("Set"), Invoke(must_488, "concat", rest_489));
{
foreach (V _k550 in new JsIter(Invoke(C_66, "values"))) {
V c_551 = default;
c_551 = _k550;
if (((!(Truthy(Get(c_551, "bb"))) || !(Truthy(Get(c_551, "I")))) || !(Truthy(Get(Get(c_551, "I"), "generic"))))) {
continue;
}
Set(Get(c_551, "I"), "ready", Invoke(on_490, "has", c_551));
if (Truthy(Get(Get(c_551, "I"), "ready"))) {
Set(c_551, "lastR", now_484);
}
}
}
if (Truthy((((allReady_486 is var _t552 && !Truthy(_t552) ? _t552 : (!castTag_67.IsNullish ? V.True : V.False)) is var _t553 && !Truthy(_t553) ? _t553 : Get(C_66, "size")) is var _t554 && !Truthy(_t554) ? _t554 : (!(Truthy(Get(api_87, "_sent"))) ? V.True : V.False)))) {
Set(api_87, "_sent", castTag_67);
Call(post_47, V.Undef, NewObj(3).Put("type", ((V)("cast"))).Put("tag", castTag_67).Put("ok", (true ? V.True : V.False)).V);
}
if (Truthy(busy_485)) {
Call(G("requestAnimationFrame"), V.Undef, frame_92);
} else {
running_88 = (false ? V.True : V.False);
sleeping_90 = (true ? V.True : V.False);
Call(sync_91, V.Undef);
}
return default;
}, 0, "frame", false);
kick_93 = Fn((V _self555, int _argc556, V _a558, V _a559, V _a560, V _a561, V[] _rest557) => {
if (_self555.IsNullish) _self555 = GlobalV;
if (Truthy(sleeping_90)) {
sleeping_90 = (false ? V.True : V.False);
Call(sync_91, V.Undef);
}
if (!(Truthy(running_88))) {
running_88 = (true ? V.True : V.False);
Call(G("requestAnimationFrame"), V.Undef, frame_92);
}
return default;
}, 0, "kick", false);
post_47 = Fn((V _self40, int _argc562, V m_568, V _a565, V _a566, V _a567, V[] _rest563) => {
V s_569 = default;
s_569 = Invoke(G("JSON"), "stringify", m_568);
if (Truthy(Get(window_39, "ReactNativeWebView"))) {
Invoke(Get(window_39, "ReactNativeWebView"), "postMessage", s_569);
} else {
Invoke(Set(window_39, "__sortOut", (Get(window_39, "__sortOut") is var _t570 && Truthy(_t570) ? _t570 : Arr())), "push", m_568);
}
return default;
}, 1, "", true);
board_48 = Invoke(G("document"), "getElementById", ((V)("board")));
clamp_49 = Fn((V _self40, int _argc571, V v_577, V a_578, V b_579, V _a576, V[] _rest572) => {
return ((V)(Max(ToNum(a_578), Min(ToNum(b_579), ToNum(v_577)))));
}, 3, "", true);
lerp_50 = Fn((V _self40, int _argc580, V a_586, V b_587, V t_588, V _a585, V[] _rest581) => {
return Add(a_586, ((V)(((ToNum(b_587) - ToNum(a_586)) * ToNum(t_588)))));
}, 3, "", true);
SM_51 = Fn((V _self40, int _argc589, V x_595, V _a592, V _a593, V _a594, V[] _rest590) => {
x_595 = Call(clamp_49, V.Undef, x_595, ((V)(0D)), ((V)(1D)));
return ((V)(((ToNum(x_595) * ToNum(x_595)) * (3D - (2D * ToNum(x_595))))));
return default;
}, 1, "", true);
outQ_52 = Fn((V _self40, int _argc596, V u_602, V _a599, V _a600, V _a601, V[] _rest597) => {
return ((V)((1D - ((1D - ToNum(u_602)) * (1D - ToNum(u_602))))));
}, 1, "", true);
outBack_53 = Fn((V _self40, int _argc603, V u_609, V _a606, V _a607, V _a608, V[] _rest604) => {
double v_610 = 0;
v_610 = (ToNum(u_609) - 1D);
return ((V)(((1D + (((2.70158 * v_610) * v_610) * v_610)) + ((1.70158 * v_610) * v_610))));
return default;
}, 1, "", true);
bounce_54 = Fn((V _self40, int _argc611, V t_617, V _a614, V _a615, V _a616, V[] _rest612) => {
double u_618 = 0;
if (LtN(t_617, (1D / 2.75))) {
return ((V)(((7.5625 * ToNum(t_617)) * ToNum(t_617))));
}
if (LtN(t_617, (2D / 2.75))) {
double u_619 = 0;
u_619 = (ToNum(t_617) - (1.5 / 2.75));
return ((V)((((7.5625 * u_619) * u_619) + 0.75)));
}
if (LtN(t_617, (2.5 / 2.75))) {
double u_620 = 0;
u_620 = (ToNum(t_617) - (2.25 / 2.75));
return ((V)((((7.5625 * u_620) * u_620) + 0.9375)));
}
u_618 = (ToNum(t_617) - (2.625 / 2.75));
return ((V)((((7.5625 * u_618) * u_618) + 0.984375)));
return default;
}, 1, "", true);
parab_55 = Fn((V _self40, int _argc621, V u_627, V _a624, V _a625, V _a626, V[] _rest622) => {
return ((V)(((LeN(u_627, 0D) || GeN(u_627, 1D)) ? 0D : ((4D * ToNum(u_627)) * (1D - ToNum(u_627))))));
}, 1, "", true);
kv_56 = V.Null;
AR_57 = Fn((V _self40, int _argc628, V K_634, V _a631, V _a632, V _a633, V[] _rest629) => {
return NewObj(2).Put("armL", K_634).Put("armR", K_634).V;
}, 1, "", true);
ER_58 = Fn((V _self40, int _argc635, V K_641, V _a638, V _a639, V _a640, V[] _rest636) => {
return NewObj(2).Put("earL", K_641).Put("earR", K_641).V;
}, 1, "", true);
BUDGET_59 = 2D;
LIFT_CAP_60 = 40D;
FAB_61 = V.Null;
isGrain_63 = Fn((V _self40, int _argc642, V f_648, V _a645, V _a646, V _a647, V[] _rest643) => {
return (((f_648 is var _t649 && !Truthy(_t649) ? _t649 : Invoke(f_648, "querySelector", ((V)("feTurbulence")))) is var _t650 && !Truthy(_t650) ? _t650 : (!(Truthy(Invoke(f_648, "querySelector", ((V)("feDisplacementMap"))))) ? V.True : V.False)) is var _t651 && !Truthy(_t651) ? _t651 : Invoke(f_648, "querySelector", ((V)("feBlend[mode=\"multiply\"]"))));
}, 1, "", true);
C_66 = New(G("Map"));
castTag_67 = V.Null;
toU_73 = Fn((V _self40, int _argc652, V c_658, V dp_659, V _a656, V _a657, V[] _rest653) => {
return ((V)((Truthy(Get(c_658, "kNow")) ? (ToNum(dp_659) / ToNum(Get(c_658, "kNow"))) : 0D)));
}, 2, "", true);
TRAVEL_76 = Arr(((V)("go")), ((V)("tumble")), ((V)("correct")), ((V)("wrong")), ((V)("caught")), ((V)("win")), ((V)("land")), ((V)("huh")), ((V)("sad")));
glow_80 = Fn((V _self40, int _argc660, V c_666, V ms_667, V _a664, V _a665, V[] _rest661) => {
return Call(start_74, V.Undef, c_666, NewObj(3).Put("kind", ((V)("glow"))).Put("dur", ms_667).Put("run", Fn((V _self668, int _argc669, V _a671, V _a672, V _a673, V _a674, V[] _rest670) => {
if (_self668.IsNullish) _self668 = GlobalV;
return NewObj(0).V;
return default;
}, 0, "run", false)).V);
}, 2, "", true);
later_81 = Fn((V _self40, int _argc675, V ms_681, V fn_682, V _a679, V _a680, V[] _rest676) => {
return Call(G("setTimeout"), V.Undef, fn_682, ms_681);
}, 2, "", true);
letGo_82 = Fn((V _self40, int _argc683, V c_689, V _a686, V _a687, V _a688, V[] _rest684) => {
if (Truthy((Get(c_689, "held") is var _t690 && !Truthy(_t690) ? _t690 : (!(Truthy(Get(Get(c_689, "held"), "rel"))) ? V.True : V.False)))) {
Set(Get(c_689, "held"), "rel", Invoke(G("performance"), "now"));
}
Set(c_689, "held", V.Null);
Invoke(Get(Get(c_689, "el"), "classList"), "remove", ((V)("air")));
return default;
}, 1, "", true);
play_83 = Fn((V _self40, int _argc691, V c_697, V name_698, V _a695, V _a696, V[] _rest692) => {
if (Truthy(((Get(c_697, "ctrl") is var _t699 && !Truthy(_t699) ? _t699 : Get(c_697, "I")) is var _t700 && !Truthy(_t700) ? _t700 : (!SEq(Get(Get(Get(c_697, "I"), "cur"), "name"), name_698) ? V.True : V.False)))) {
Invoke(Get(c_697, "ctrl"), "play", name_698);
}
return default;
}, 2, "", true);
shut_84 = V.Null;
api_87 = NewObj(15).Put("cast", Fn((V _self701, int _argc702, V list_708, V tag_709, V _a706, V _a707, V[] _rest703) => {
V ids_710 = default;
if (_self701.IsNullish) _self701 = GlobalV;
castTag_67 = tag_709;
Set(api_87, "_sent", V.Null);
shut_84 = V.Null;
Set(Get(board_48, "style"), "clipPath", ((V)("")));
ids_710 = New(G("Set"), Invoke(list_708, "map", Fn((V _self701, int _argc711, V c_717, V _a714, V _a715, V _a716, V[] _rest712) => {
return Get(c_717, "id");
}, 1, "", true)));
{
foreach (V _k718 in new JsIter(C_66)) {
V id_719 = default;
V c_720 = default;
{ V _t721 = ListOf(_k718);
{ V _t722 = GetIdx(_t721, 0D);
id_719 = _t722; }
{ V _t723 = GetIdx(_t721, 1D);
c_720 = _t723; }
}
if (!(Truthy(Invoke(ids_710, "has", id_719)))) {
Call(unmount_69, V.Undef, c_720);
Invoke(C_66, "delete", id_719);
}
}
}
{
foreach (V _k724 in new JsIter(list_708)) {
V it_725 = default;
it_725 = _k724;
V c_726 = default;
c_726 = Invoke(C_66, "get", Get(it_725, "id"));
if (Truthy((c_726 is var _t727 && !Truthy(_t727) ? _t727 : (!SEq(Get(c_726, "key"), Get(it_725, "key")) ? V.True : V.False)))) {
Call(unmount_69, V.Undef, c_726);
Invoke(C_66, "delete", Get(it_725, "id"));
c_726 = V.Null;
}
if (!(Truthy(c_726))) {
c_726 = NewObj(7).Put("id", Get(it_725, "id")).Put("key", Get(it_725, "key")).Put("moves", Arr()).Put("vx", ((V)(0D))).Put("vy", ((V)(0D))).Put("lastR", ((V)(0D))).Put("settle", ((V)(0D))).V;
Invoke(C_66, "set", Get(it_725, "id"), c_726);
Call(mount_68, V.Undef, c_726);
}
Object_assign(c_726, NewObj(9).Put("P", Get(it_725, "P")).Put("x", ((V)((-1000D)))).Put("y", ((V)((-1000D)))).Put("s", ((V)(1D))).Put("o", ((V)(0D))).Put("z", ((V)(10D))).Put("held", V.Null).Put("cur", V.Null).Put("sway", V.Null).V);
Set(c_726, "moves", Arr());
Invoke(Get(Get(c_726, "el"), "classList"), "remove", ((V)("air")));
if (Truthy(Get(c_726, "bb"))) {
Call(play_83, V.Undef, c_726, ((V)("idle")));
Set(c_726, "settle", Add(Invoke(G("performance"), "now"), ((V)(300D))));
}
}
}
Call(kick_93, V.Undef);
return default;
}, 2, "cast", false)).Put("place", Fn((V _self728, int _argc729, V id_735, V p_736, V _a733, V _a734, V[] _rest730) => {
V c_737 = default;
if (_self728.IsNullish) _self728 = GlobalV;
c_737 = Invoke(C_66, "get", id_735);
if (!(Truthy(c_737))) {
return default;
}
Call(stop_75, V.Undef, c_737);
Set(c_737, "held", V.Null);
Set(c_737, "sway", V.Null);
Invoke(Get(Get(c_737, "el"), "classList"), "remove", ((V)("air")));
Object_assign(c_737, NewObj(4).Put("x", Get(p_736, "x")).Put("y", Get(p_736, "y")).Put("s", (Get(p_736, "s").IsNullish ? ((V)(1D)) : Get(p_736, "s"))).Put("z", (Get(p_736, "z").IsNullish ? ((V)(10D)) : Get(p_736, "z"))).V);
if (!Get(p_736, "o").IsNullish) {
Set(c_737, "o", Get(p_736, "o"));
}
Call(play_83, V.Undef, c_737, ((V)("idle")));
Set(c_737, "settle", Add(Invoke(G("performance"), "now"), ((V)(300D))));
Call(kick_93, V.Undef);
return default;
}, 2, "place", false)).Put("hideAll", Fn((V _self738, int _argc739, V _a741, V _a742, V _a743, V _a744, V[] _rest740) => {
if (_self738.IsNullish) _self738 = GlobalV;
{
foreach (V _k745 in new JsIter(Invoke(C_66, "values"))) {
V c_746 = default;
c_746 = _k745;
Call(stop_75, V.Undef, c_746);
Set(c_746, "held", V.Null);
Set(c_746, "sway", V.Null);
Set(c_746, "o", ((V)(0D)));
}
}
shut_84 = V.Null;
Set(Get(board_48, "style"), "clipPath", ((V)("")));
Call(kick_93, V.Undef);
return default;
}, 0, "hideAll", false)).Put("tumble", Fn((V _self747, int _argc748, V id_754, V from_755, V to_756, V delay_757, V[] _rest749) => {
V c_760 = default;
double D_761 = 0;
double up_762 = 0;
V peak_758 = default;
V inside_759 = default;
if (_self747.IsNullish) _self747 = GlobalV;
peak_758 = (_argc748 > 4 ? _rest749[0] : V.Undef);
inside_759 = (_argc748 > 5 ? _rest749[1] : V.Undef);
c_760 = Invoke(C_66, "get", id_754);
if (!(Truthy(c_760))) {
return default;
}
Call(stop_75, V.Undef, c_760);
Set(c_760, "held", V.Null);
Set(c_760, "sway", V.Null);
Call(play_83, V.Undef, c_760, ((V)("idle")));
if (Truthy(inside_759)) {
Object_assign(c_760, NewObj(5).Put("x", Get(to_756, "x")).Put("y", Get(to_756, "y")).Put("s", Get(to_756, "s")).Put("z", ((V)(10D))).Put("o", ((V)(1D))).V);
Call(start_74, V.Undef, c_760, NewObj(4).Put("kind", ((V)("tumble"))).Put("dur", ((V)(140D))).Put("prio", ((V)(1D))).Put("run", Fn((V _self763, int _argc764, V c_770, V t_771, V _a768, V _a769, V[] _rest765) => {
if (_self763.IsNullish) _self763 = GlobalV;
return NewObj(1).Put("o", ((V)((ToNum(t_771) / 140D)))).V;
return default;
}, 2, "run", false)).V);
return default;
}
Object_assign(c_760, NewObj(5).Put("x", Get(from_755, "x")).Put("y", Get(from_755, "y")).Put("s", Get(from_755, "s")).Put("z", ((V)(30D))).Put("o", ((V)(1D))).V);
D_761 = 560D;
up_762 = 230D;
Call(start_74, V.Undef, c_760, NewObj(7).Put("kind", ((V)("tumble"))).Put("delay", delay_757).Put("dur", ((V)(D_761))).Put("prio", ((V)(1D))).Put("before", NewObj(1).Put("o", ((V)(0D))).V).Put("run", Fn((V _self772, int _argc773, V c_779, V t_780, V _a777, V _a778, V[] _rest774) => {
double u_781 = 0;
V fall_782 = default;
if (_self772.IsNullish) _self772 = GlobalV;
u_781 = (ToNum(t_780) / D_761);
Set(c_779, "x", Call(lerp_50, V.Undef, Get(from_755, "x"), Get(to_756, "x"), Call(outQ_52, V.Undef, ((V)(u_781)))));
Set(c_779, "y", (LtN(t_780, up_762) ? Call(lerp_50, V.Undef, Get(from_755, "y"), peak_758, Call(outQ_52, V.Undef, ((V)((ToNum(t_780) / up_762))))) : Call(lerp_50, V.Undef, peak_758, Get(to_756, "y"), Call(bounce_54, V.Undef, ((V)(((ToNum(t_780) - up_762) / (D_761 - up_762))))))));
Set(c_779, "s", Call(lerp_50, V.Undef, Get(from_755, "s"), Get(to_756, "s"), ((V)(u_781))));
fall_782 = (LtN(t_780, up_762) ? ((V)(1D)) : Call(clamp_49, V.Undef, ((V)((1D - ((ToNum(t_780) - up_762) / 160D)))), ((V)(0D)), ((V)(1D))));
return NewObj(3).Put("o", Call(clamp_49, V.Undef, ((V)((ToNum(t_780) / 90D))), ((V)(0D)), ((V)(1D)))).Put("body", NewObj(2).Put("sq", ((V)(((-0.2) * ToNum(fall_782))))).Put("tilt", ((V)(((9D * ToNum(fall_782)) * FdLibm.Sin((ToNum(t_780) / 45D)))))).V).Put("ext", NewObj(4).Put("armL", ((V)((44D * ToNum(fall_782))))).Put("armR", ((V)((44D * ToNum(fall_782))))).Put("wide", fall_782).Put("open", ((V)((0.5 * ToNum(fall_782))))).V).V;
return default;
}, 2, "run", false)).Put("done", Fn((V _self783, int _argc784, V _a786, V _a787, V _a788, V _a789, V[] _rest785) => {
if (_self783.IsNullish) _self783 = GlobalV;
Set(c_760, "x", Get(to_756, "x"));
Set(c_760, "y", Get(to_756, "y"));
Set(c_760, "s", Get(to_756, "s"));
Set(c_760, "z", ((V)(10D)));
Call(land_77, V.Undef, c_760, ((V)(0.26)), (true ? V.True : V.False));
return default;
}, 0, "done", false)).V);
return default;
}, 6, "tumble", false)).Put("hold", Fn((V _self790, int _argc791, V id_797, V mode_798, V _a795, V _a796, V[] _rest792) => {
V c_799 = default;
V h_800 = default;
if (_self790.IsNullish) _self790 = GlobalV;
c_799 = Invoke(C_66, "get", id_797);
if (!(Truthy(c_799))) {
return default;
}
if (!(Truthy(mode_798))) {
if (!(Truthy(Get(c_799, "held")))) {
return default;
}
Set(Get(c_799, "held"), "rel", Invoke(G("performance"), "now"));
Set(c_799, "held", V.Null);
Invoke(Get(Get(c_799, "el"), "classList"), "remove", ((V)("air")));
Call(play_83, V.Undef, c_799, ((V)("idle")));
Call(kick_93, V.Undef);
return default;
}
Call(stop_75, V.Undef, c_799, Invoke(TRAVEL_76, "concat", ((V)("held"))));
Set(c_799, "sway", V.Null);
Set(c_799, "vx", ((V)(0D)));
Set(c_799, "vy", ((V)(0D)));
if (SEqS(mode_798, "drag")) {
Invoke(Get(Get(c_799, "el"), "classList"), "add", ((V)("air")));
} else {
Invoke(Get(Get(c_799, "el"), "classList"), "remove", ((V)("air")));
}
Call(play_83, V.Undef, c_799, ((V)("sortHeld")));
h_800 = NewObj(2).Put("mode", mode_798).Put("rel", ((V)(0D))).V;
Set(c_799, "held", h_800);
Call(start_74, V.Undef, c_799, NewObj(4).Put("kind", ((V)("held"))).Put("dur", ((V)(1000000000D))).Put("prio", ((V)(3D))).Put("run", Fn((V _self801, int _argc802, V c_808, V t_809, V _a806, V _a807, V[] _rest803) => {
V now_810 = default;
V env_811 = default;
V drag_812 = default;
double w_813 = 0;
V pop_814 = default;
double wig_815 = 0;
V sway_816 = default;
double lift_817 = 0;
double kick_818 = 0;
if (_self801.IsNullish) _self801 = GlobalV;
now_810 = Invoke(G("performance"), "now");
env_811 = (Truthy(Get(h_800, "rel")) ? ((V)((1D - ToNum(Call(clamp_49, V.Undef, ((V)(((ToNum(now_810) - ToNum(Get(h_800, "rel"))) / 160D))), ((V)(0D)), ((V)(1D))))))) : Call(clamp_49, V.Undef, ((V)((ToNum(t_809) / 110D))), ((V)(0D)), ((V)(1D))));
if (Truthy((Get(h_800, "rel") is var _t819 && !Truthy(_t819) ? _t819 : (LeN(env_811, 0D) ? V.True : V.False)))) {
Set(_self801, "fin", (true ? V.True : V.False));
return NewObj(0).V;
}
drag_812 = (SEqS(Get(h_800, "mode"), "drag") ? V.True : V.False);
w_813 = (ToNum(t_809) / 1000D);
pop_814 = Call(kv_56, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(90D)), ((V)((-0.36))), ((V)("o"))), Arr(((V)(220D)), ((V)((-0.18))), ((V)("io"))), Arr(((V)(340D)), ((V)((-0.24))), ((V)("io")))), ((V)(Min(ToNum(t_809), 340D))));
wig_815 = FdLibm.Sin((((w_813 * System.Math.PI) * 2D) * (Truthy(drag_812) ? 3.2 : 2.2)));
sway_816 = Call(clamp_49, V.Undef, ((V)(((-ToNum(Get(c_808, "vx"))) * 0.022))), ((V)((-16D))), ((V)(16D)));
lift_817 = (Truthy(drag_812) ? 5D : (6D + (2D * FdLibm.Sin((((w_813 * System.Math.PI) * 2D) * 1.2)))));
kick_818 = (Truthy(drag_812) ? FdLibm.Sin((((w_813 * System.Math.PI) * 2D) * 3.2)) : 0D);
return NewObj(2).Put("z", ((V)(60D))).Put("ext", NewObj(11).Put("lift", Call(toU_73, V.Undef, c_808, ((V)((lift_817 * ToNum(env_811)))))).Put("sq", ((V)((ToNum(Add(pop_814, ((V)(((Truthy(drag_812) ? 0.04 : 0.03) * FdLibm.Sin((((w_813 * System.Math.PI) * 2D) * 4.4))))))) * ToNum(env_811))))).Put("tilt", ((V)((ToNum(Add(((V)(((Truthy(drag_812) ? 7D : 4D) * wig_815))), sway_816)) * ToNum(env_811))))).Put("lean", ((V)(((((Truthy(drag_812) ? 1.6 : 1D) * wig_815) + (ToNum(sway_816) * 0.12)) * ToNum(env_811))))).Put("x", ((V)((ToNum(Call(clamp_49, V.Undef, ((V)(((-ToNum(Get(c_808, "vx"))) * 0.004))), ((V)((-3D))), ((V)(3D)))) * ToNum(env_811))))).Put("armL", ((V)((((38D + (10D * wig_815)) - (ToNum(sway_816) * 0.8)) * ToNum(env_811))))).Put("armR", ((V)((((38D - (10D * wig_815)) - (ToNum(sway_816) * 0.8)) * ToNum(env_811))))).Put("earL", ((V)((((-ToNum(sway_816)) * 0.7) * ToNum(env_811))))).Put("earR", ((V)((((-ToNum(sway_816)) * 0.7) * ToNum(env_811))))).Put("footL", ((V)(((2.4 * Max(0D, kick_818)) * ToNum(env_811))))).Put("footR", ((V)(((2.4 * Max(0D, (-kick_818))) * ToNum(env_811))))).V).V;
return default;
}, 2, "run", false)).V);
return default;
}, 2, "hold", false)).Put("drag", Fn((V _self820, int _argc821, V id_827, V x_828, V y_829, V _a826, V[] _rest822) => {
V c_830 = default;
V now_831 = default;
double dt_832 = 0;
double vx_833 = 0;
double vy_834 = 0;
if (_self820.IsNullish) _self820 = GlobalV;
c_830 = Invoke(C_66, "get", id_827);
if (!(Truthy(c_830))) {
return default;
}
now_831 = Invoke(G("performance"), "now");
dt_832 = Max(8D, (ToNum(now_831) - ToNum((Get(c_830, "dragAt") is var _t835 && Truthy(_t835) ? _t835 : ((V)((ToNum(now_831) - 16D)))))));
vx_833 = (((ToNum(x_828) - ToNum(Get(c_830, "x"))) / dt_832) * 1000D);
vy_834 = (((ToNum(y_829) - ToNum(Get(c_830, "y"))) / dt_832) * 1000D);
Set(c_830, "vx", Call(lerp_50, V.Undef, Get(c_830, "vx"), Call(clamp_49, V.Undef, ((V)(vx_833)), ((V)((-2500D))), ((V)(2500D))), ((V)(0.35))));
Set(c_830, "vy", Call(lerp_50, V.Undef, Get(c_830, "vy"), Call(clamp_49, V.Undef, ((V)(vy_834)), ((V)((-2500D))), ((V)(2500D))), ((V)(0.35))));
Set(c_830, "dragAt", now_831);
Set(c_830, "x", x_828);
Set(c_830, "y", y_829);
Set(c_830, "s", ((V)(1D)));
Call(kick_93, V.Undef);
return default;
}, 3, "drag", false)).Put("go", Fn((V _self836, int _argc837, V id_843, V to_844, V o_845, V _a842, V[] _rest838) => {
V c_846 = default;
if (_self836.IsNullish) _self836 = GlobalV;
c_846 = Invoke(C_66, "get", id_843);
if (!(Truthy(c_846))) {
return default;
}
Call(stop_75, V.Undef, c_846, TRAVEL_76);
Call(letGo_82, V.Undef, c_846);
Set(c_846, "sway", V.Null);
Call(travel_78, V.Undef, c_846, to_844, (o_845 is var _t847 && Truthy(_t847) ? _t847 : NewObj(0).V));
return default;
}, 3, "go", false)).Put("correct", Fn((V _self848, int _argc849, V id_855, V to_856, V _a853, V _a854, V[] _rest850) => {
V c_857 = default;
double dist_858 = 0;
if (_self848.IsNullish) _self848 = GlobalV;
c_857 = Invoke(C_66, "get", id_855);
if (!(Truthy(c_857))) {
return default;
}
Call(stop_75, V.Undef, c_857, TRAVEL_76);
Call(letGo_82, V.Undef, c_857);
Set(c_857, "sway", V.Null);
dist_858 = Hypot((ToNum(Get(to_856, "x")) - ToNum(Get(c_857, "x"))), (ToNum(Get(to_856, "y")) - ToNum(Get(c_857, "y"))));
Call(travel_78, V.Undef, c_857, to_856, NewObj(5).Put("kind", ((V)("correct"))).Put("ms", Call(clamp_49, V.Undef, ((V)((170D + (dist_858 * 0.5)))), ((V)(200D)), ((V)(440D)))).Put("h", ((V)(Min((ToNum(Get(c_857, "P")) * 0.6), (dist_858 * 0.3))))).Put("back", (true ? V.True : V.False)).Put("land", (false ? V.True : V.False)).V, Fn((V _self848, int _argc859, V _a861, V _a862, V _a863, V _a864, V[] _rest860) => {
V sq_865 = default;
V lift_866 = default;
V arms_867 = default;
Call(play_83, V.Undef, c_857, ((V)("sortJoy")));
sq_865 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(50D)), ((V)(0.34)), ((V)("o"))), Arr(((V)(150D)), ((V)(0.3)), ((V)("io"))), Arr(((V)(200D)), ((V)((-0.3))), ((V)("o"))), Arr(((V)(380D)), ((V)((-0.12))), ((V)("io"))), Arr(((V)(520D)), ((V)(0.3)), ((V)("o"))), Arr(((V)(620D)), ((V)((-0.1))), ((V)("io"))), Arr(((V)(720D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))));
lift_866 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(170D)), ((V)(0D))), Arr(((V)(360D)), ((V)((ToNum(Get(c_857, "P")) * 0.34))), ((V)("o"))), Arr(((V)(520D)), ((V)(0D)), ((V)("i"))), Arr(((V)(800D)), ((V)(0D))));
arms_867 = Arr(Arr(((V)(0D)), ((V)((-12D)))), Arr(((V)(150D)), ((V)((-14D)))), Arr(((V)(220D)), ((V)(50D)), ((V)("o"))), Arr(((V)(480D)), ((V)(44D))), Arr(((V)(560D)), ((V)((-10D))), ((V)("o"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))));
Call(start_74, V.Undef, c_857, NewObj(3).Put("kind", ((V)("correct"))).Put("dur", ((V)(800D))).Put("run", Fn((V _self868, int _argc869, V c_875, V t_876, V _a873, V _a874, V[] _rest870) => {
V L_877 = default;
if (_self868.IsNullish) _self868 = GlobalV;
L_877 = Call(kv_56, V.Undef, lift_866, t_876);
return NewObj(1).Put("ext", NewObj(6).Put("sq", Call(kv_56, V.Undef, sq_865, t_876)).Put("lift", Call(toU_73, V.Undef, c_875, L_877)).Put("armL", Call(kv_56, V.Undef, arms_867, t_876)).Put("armR", Call(kv_56, V.Undef, arms_867, t_876)).Put("close", Call(kv_56, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(40D)), ((V)(0.7)), ((V)("o"))), Arr(((V)(160D)), ((V)(0.7))), Arr(((V)(220D)), ((V)(0D)), ((V)("o")))), t_876)).Put("tilt", Call(kv_56, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)(6D)), ((V)("io"))), Arr(((V)(420D)), ((V)((-6D))), ((V)("io"))), Arr(((V)(560D)), ((V)(0D)), ((V)("io")))), t_876)).V).V;
return default;
}, 2, "run", false)).V);
Call(glow_80, V.Undef, c_857, ((V)(1600D)));
Call(later_81, V.Undef, ((V)(240D)), Fn((V _self848, int _argc878, V _a880, V _a881, V _a882, V _a883, V[] _rest879) => {
return Call(burst_79, V.Undef, c_857, ((V)("sortSpark")), ((V)("head")), ((V)(7D)));
}, 0, "", true));
Call(later_81, V.Undef, ((V)(520D)), Fn((V _self848, int _argc884, V _a886, V _a887, V _a888, V _a889, V[] _rest885) => {
return Call(burst_79, V.Undef, c_857, ((V)("sortSpark")), ((V)("feet")), ((V)(5D)));
}, 0, "", true));
Call(later_81, V.Undef, ((V)(300D)), Fn((V _self848, int _argc890, V _a892, V _a893, V _a894, V _a895, V[] _rest891) => {
return Call(burst_79, V.Undef, c_857, ((V)("sortHeart")), ((V)("head")), ((V)(1D)));
}, 0, "", true));
return default;
}, 0, "", true));
return default;
}, 2, "correct", false)).Put("wrong", Fn((V _self896, int _argc897, V id_903, V at_904, V back_905, V _a902, V[] _rest898) => {
V c_906 = default;
V shake_907 = default;
if (_self896.IsNullish) _self896 = GlobalV;
c_906 = Invoke(C_66, "get", id_903);
if (!(Truthy(c_906))) {
return default;
}
Call(stop_75, V.Undef, c_906, TRAVEL_76);
Call(letGo_82, V.Undef, c_906);
Set(c_906, "sway", V.Null);
shake_907 = Fn((V _self896, int _argc908, V _a910, V _a911, V _a912, V _a913, V[] _rest909) => {
V no_914 = default;
Call(play_83, V.Undef, c_906, ((V)("sortNope")));
Call(burst_79, V.Undef, c_906, ((V)("sortSweat")), ((V)("temple")));
Call(later_81, V.Undef, ((V)(380D)), Fn((V _self896, int _argc915, V _a917, V _a918, V _a919, V _a920, V[] _rest916) => {
return Call(burst_79, V.Undef, c_906, ((V)("sortSweat")), ((V)("temple")));
}, 0, "", true));
no_914 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(70D)), ((V)(0.95)), ((V)("io"))), Arr(((V)(170D)), ((V)((-0.95))), ((V)("io"))), Arr(((V)(270D)), ((V)(0.85)), ((V)("io"))), Arr(((V)(370D)), ((V)((-0.65))), ((V)("io"))), Arr(((V)(460D)), ((V)(0.3)), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))));
Call(start_74, V.Undef, c_906, NewObj(4).Put("kind", ((V)("wrong"))).Put("dur", ((V)(560D))).Put("run", Fn((V _self921, int _argc922, V c_928, V t_929, V _a926, V _a927, V[] _rest923) => {
V n_930 = default;
if (_self921.IsNullish) _self921 = GlobalV;
n_930 = Call(kv_56, V.Undef, no_914, t_929);
return NewObj(1).Put("ext", NewObj(5).Put("turn", n_930).Put("lx", n_930).Put("htilt", ((V)((ToNum(n_930) * 5D)))).Put("sq", Call(kv_56, V.Undef, Arr(Arr(((V)(0D)), ((V)(0.2))), Arr(((V)(80D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(560D)), ((V)(0.04)))), t_929)).Spread(Call(AR_57, V.Undef, Call(kv_56, V.Undef, Arr(Arr(((V)(0D)), ((V)((-6D)))), Arr(((V)(120D)), ((V)((-14D))), ((V)("io"))), Arr(((V)(560D)), ((V)((-12D))))), t_929))).V).V;
return default;
}, 2, "run", false)).Put("done", Fn((V _self931, int _argc932, V _a934, V _a935, V _a936, V _a937, V[] _rest933) => {
if (_self931.IsNullish) _self931 = GlobalV;
Call(travel_78, V.Undef, c_906, back_905, NewObj(4).Put("kind", ((V)("wrong"))).Put("ms", ((V)(460D))).Put("h", ((V)((ToNum(Get(c_906, "P")) * 0.75)))).Put("land", ((V)(0.34))).V, Fn((V _self931, int _argc938, V _a940, V _a941, V _a942, V _a943, V[] _rest939) => {
Call(burst_79, V.Undef, c_906, ((V)("sortSweat")), ((V)("temple")));
Call(glow_80, V.Undef, c_906, ((V)(1000D)));
return default;
}, 0, "", true));
return default;
}, 0, "done", false)).V);
return default;
}, 0, "", true);
Call(glow_80, V.Undef, c_906, ((V)(2400D)));
if ((Hypot((ToNum(Get(at_904, "x")) - ToNum(Get(c_906, "x"))), (ToNum(Get(at_904, "y")) - ToNum(Get(c_906, "y")))) > 3D)) {
Call(travel_78, V.Undef, c_906, at_904, NewObj(4).Put("kind", ((V)("wrong"))).Put("ms", ((V)(200D))).Put("h", ((V)(10D))).Put("land", (false ? V.True : V.False)).V, shake_907);
} else {
Call(shake_907, V.Undef);
}
return default;
}, 3, "wrong", false)).Put("caught", Fn((V _self944, int _argc945, V id_951, V dir_952, V delay_953, V _a950, V[] _rest946) => {
V c_954 = default;
double J_955 = 0;
double D_956 = 0;
V from_957 = default;
V W_958 = default;
double off_959 = 0;
V up_960 = default;
if (_self944.IsNullish) _self944 = GlobalV;
c_954 = Invoke(C_66, "get", id_951);
if (!(Truthy(c_954))) {
return default;
}
Call(stop_75, V.Undef, c_954, TRAVEL_76);
Call(letGo_82, V.Undef, c_954);
Set(c_954, "sway", V.Null);
Call(later_81, V.Undef, (delay_953 is var _t961 && Truthy(_t961) ? _t961 : ((V)(0D))), Fn((V _self944, int _argc962, V _a964, V _a965, V _a966, V _a967, V[] _rest963) => {
Call(play_83, V.Undef, c_954, ((V)("sortCaught")));
Call(burst_79, V.Undef, c_954, ((V)("sortSweat")), ((V)("temple")));
Call(later_81, V.Undef, ((V)(160D)), Fn((V _self944, int _argc968, V _a970, V _a971, V _a972, V _a973, V[] _rest969) => {
return Call(burst_79, V.Undef, c_954, ((V)("sortSweat")), ((V)("temple")));
}, 0, "", true));
return default;
}, 0, "", true));
J_955 = 420D;
D_956 = 1150D;
from_957 = NewObj(2).Put("x", Get(c_954, "x")).Put("y", Get(c_954, "y")).V;
W_958 = Get(window_39, "innerWidth");
off_959 = (LtN(dir_952, 0D) ? (((-ToNum(Get(c_954, "P"))) * 1.6) - ToNum(Get(from_957, "x"))) : ((ToNum(W_958) - ToNum(Get(from_957, "x"))) + (ToNum(Get(c_954, "P")) * 0.6)));
up_960 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(70D)), ((V)(0D))), Arr(((V)((J_955 * 0.55))), ((V)((ToNum(Get(c_954, "P")) * 0.5))), ((V)("o"))), Arr(((V)(J_955)), ((V)((ToNum(Get(c_954, "P")) * 0.38))), ((V)("io"))), Arr(((V)(D_956)), ((V)((ToNum(Get(c_954, "P")) * 0.38)))));
Call(start_74, V.Undef, c_954, NewObj(5).Put("kind", ((V)("caught"))).Put("delay", delay_953).Put("dur", ((V)(D_956))).Put("run", Fn((V _self974, int _argc975, V c_981, V t_982, V _a979, V _a980, V[] _rest976) => {
V lift_983 = default;
V away_984 = default;
if (_self974.IsNullish) _self974 = GlobalV;
lift_983 = Call(kv_56, V.Undef, up_960, t_982);
away_984 = (LtN(t_982, (J_955 * 0.75)) ? ((V)(0D)) : Call(SM_51, V.Undef, ((V)(((ToNum(t_982) - (J_955 * 0.75)) / (D_956 - (J_955 * 0.75)))))));
Set(c_981, "x", Add(Get(from_957, "x"), ((V)((off_959 * ToNum(away_984))))));
Set(c_981, "y", ((V)((ToNum(Get(from_957, "y")) - ((ToNum(Get(c_981, "P")) * 0.9) * FdLibm.Sin(((ToNum(away_984) * System.Math.PI) * 0.6)))))));
return NewObj(4).Put("z", ((V)(70D))).Put("k", Call(lerp_50, V.Undef, ((V)(1D)), ((V)(0.45)), away_984)).Put("o", ((V)((LtN(away_984, 0.7) ? 1D : (1D - ((ToNum(away_984) - 0.7) / 0.3)))))).Put("ext", NewObj(6).Put("lift", Call(toU_73, V.Undef, c_981, lift_983)).Put("sq", Call(kv_56, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(60D)), ((V)(0.3)), ((V)("o"))), Arr(((V)(140D)), ((V)((-0.34))), ((V)("o"))), Arr(((V)(J_955)), ((V)((-0.2))), ((V)("io"))), Arr(((V)(D_956)), ((V)((-0.1))))), t_982)).Spread(Call(AR_57, V.Undef, Call(kv_56, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)(52D)), ((V)("o"))), Arr(((V)(J_955)), ((V)(46D))), Arr(((V)(D_956)), ((V)(40D)))), t_982))).Put("wide", ((V)(1D))).Put("spin", Call(kv_56, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((J_955 * 0.8))), ((V)(0D))), Arr(((V)(D_956)), ((V)((ToNum(dir_952) * 900D))), ((V)("i")))), t_982)).Put("tilt", Call(kv_56, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((J_955 * 0.8))), ((V)(0D))), Arr(((V)(D_956)), ((V)((ToNum(dir_952) * 40D))), ((V)("i")))), t_982)).V).V;
return default;
}, 2, "run", false)).Put("done", Fn((V _self985, int _argc986, V _a988, V _a989, V _a990, V _a991, V[] _rest987) => {
if (_self985.IsNullish) _self985 = GlobalV;
Set(c_954, "o", ((V)(0D)));
return default;
}, 0, "done", false)).V);
return default;
}, 3, "caught", false)).Put("huh", Fn((V _self992, int _argc993, V id_999, V _a996, V _a997, V _a998, V[] _rest994) => {
V c_1000 = default;
if (_self992.IsNullish) _self992 = GlobalV;
c_1000 = Invoke(C_66, "get", id_999);
if (Truthy((((!(Truthy(c_1000)) ? V.True : V.False) is var _t1001 && Truthy(_t1001) ? _t1001 : Get(c_1000, "held")) is var _t1002 && Truthy(_t1002) ? _t1002 : Get(Get(c_1000, "moves"), "length")))) {
return default;
}
Call(play_83, V.Undef, c_1000, ((V)("sortHuh")));
Call(start_74, V.Undef, c_1000, NewObj(3).Put("kind", ((V)("huh"))).Put("dur", ((V)(1700D))).Put("run", Fn((V _self1003, int _argc1004, V _a1006, V _a1007, V _a1008, V _a1009, V[] _rest1005) => {
if (_self1003.IsNullish) _self1003 = GlobalV;
return NewObj(0).V;
return default;
}, 0, "run", false)).V);
return default;
}, 1, "huh", false)).Put("win", Fn((V _self1010, int _argc1011, V list_1017, V doors_1018, V _a1015, V _a1016, V[] _rest1012) => {
V now_1019 = default;
if (_self1010.IsNullish) _self1010 = GlobalV;
now_1019 = Invoke(G("performance"), "now");
{
foreach (V _k1020 in new JsIter(list_1017)) {
V it0_1021 = default;
it0_1021 = _k1020;
V c_1022 = default;
V rem_1023 = default;
V it_1024 = default;
double D_1025 = 0;
double h_1026 = 0;
V sq_1027 = default;
V lift_1028 = default;
V wave_1029 = default;
c_1022 = Invoke(C_66, "get", Get(it0_1021, "id"));
if (!(Truthy(c_1022))) {
continue;
}
Call(letGo_82, V.Undef, c_1022);
Set(c_1022, "sway", V.Null);
rem_1023 = Invoke(Invoke(Get(c_1022, "moves"), "filter", Fn((V _self1010, int _argc1038, V m_1044, V _a1041, V _a1042, V _a1043, V[] _rest1039) => {
return (((!(Truthy(Get(m_1044, "dead"))) && LtN(Get(m_1044, "dur"), 100000000D)) && !SEqS(Get(m_1044, "kind"), "glow")) ? V.True : V.False);
}, 1, "", true)), "reduce", Fn((V _self1010, int _argc1030, V a_1036, V m_1037, V _a1034, V _a1035, V[] _rest1031) => {
return ((V)(Max(ToNum(a_1036), (ToNum(Add(Get(m_1037, "t0"), Get(m_1037, "dur"))) - ToNum(now_1019)))));
}, 2, "", true), ((V)(0D)));
it_1024 = NewObj(2).Put("id", Get(it0_1021, "id")).Put("delay", ((V)(Max(ToNum(Get(it0_1021, "delay")), ToNum(rem_1023))))).V;
Call(later_81, V.Undef, Get(it_1024, "delay"), Fn((V _self1010, int _argc1045, V _a1047, V _a1048, V _a1049, V _a1050, V[] _rest1046) => {
return Call(play_83, V.Undef, c_1022, ((V)("sortJoy")));
}, 0, "", true));
D_1025 = 760D;
h_1026 = (ToNum(Get(c_1022, "P")) * 0.42);
sq_1027 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(70D)), ((V)(0.26)), ((V)("o"))), Arr(((V)(150D)), ((V)((-0.32))), ((V)("o"))), Arr(((V)(330D)), ((V)((-0.12))), ((V)("io"))), Arr(((V)(420D)), ((V)(0.3)), ((V)("o"))), Arr(((V)(480D)), ((V)((-0.1))), ((V)("io"))), Arr(((V)(600D)), ((V)(0.18)), ((V)("o"))), Arr(((V)(680D)), ((V)((-0.05))), ((V)("io"))), Arr(((V)(D_1025)), ((V)(0D)), ((V)("io"))));
lift_1028 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(80D)), ((V)(0D))), Arr(((V)(250D)), ((V)(h_1026)), ((V)("o"))), Arr(((V)(420D)), ((V)(0D)), ((V)("i"))), Arr(((V)(480D)), ((V)(0D))), Arr(((V)(540D)), ((V)((h_1026 * 0.3))), ((V)("o"))), Arr(((V)(600D)), ((V)(0D)), ((V)("i"))), Arr(((V)(D_1025)), ((V)(0D))));
wave_1029 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(90D)), ((V)(54D)), ((V)("o"))), Arr(((V)(200D)), ((V)(40D)), ((V)("io"))), Arr(((V)(300D)), ((V)(56D)), ((V)("io"))), Arr(((V)(420D)), ((V)(30D)), ((V)("io"))), Arr(((V)(D_1025)), ((V)(0D)), ((V)("io"))));
Call(start_74, V.Undef, c_1022, NewObj(5).Put("kind", ((V)("win"))).Put("delay", Get(it_1024, "delay")).Put("dur", ((V)(D_1025))).Put("prio", ((V)(1D))).Put("run", Fn((V _self1051, int _argc1052, V c_1058, V t_1059, V _a1056, V _a1057, V[] _rest1053) => {
V wv_1060 = default;
if (_self1051.IsNullish) _self1051 = GlobalV;
wv_1060 = Call(kv_56, V.Undef, wave_1029, t_1059);
return NewObj(2).Put("body", NewObj(3).Put("sq", Call(kv_56, V.Undef, sq_1027, t_1059)).Put("lift", Call(kv_56, V.Undef, lift_1028, t_1059)).Put("tilt", Call(kv_56, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)((-5D))), ((V)("io"))), Arr(((V)(330D)), ((V)(5D)), ((V)("io"))), Arr(((V)(480D)), ((V)(0D)), ((V)("io")))), t_1059)).V).Put("ext", NewObj(2).Put("armL", wv_1060).Put("armR", ((V)((ToNum(wv_1060) * 0.85)))).V).V;
return default;
}, 2, "run", false)).V);
}
}
if (Truthy(doors_1018)) {
shut_84 = NewObj(6).Put("t0", Add(Invoke(G("performance"), "now"), (Get(doors_1018, "delay") is var _t1061 && Truthy(_t1061) ? _t1061 : ((V)(0D))))).Put("ms", Get(doors_1018, "ms")).Put("deg", Get(doors_1018, "deg")).Put("persp", Get(doors_1018, "persp")).Put("list", Get(doors_1018, "list")).Put("lead", (Get(doors_1018, "lead") is var _t1062 && Truthy(_t1062) ? _t1062 : ((V)(3D)))).V;
Call(kick_93, V.Undef);
}
return default;
}, 2, "win", false)).Put("unshut", Fn((V _self1063, int _argc1064, V _a1066, V _a1067, V _a1068, V _a1069, V[] _rest1065) => {
if (_self1063.IsNullish) _self1063 = GlobalV;
shut_84 = V.Null;
Set(Get(board_48, "style"), "clipPath", ((V)("")));
return default;
}, 0, "unshut", false)).Put("lose", Fn((V _self1070, int _argc1071, V list_1077, V _a1074, V _a1075, V _a1076, V[] _rest1072) => {
if (_self1070.IsNullish) _self1070 = GlobalV;
{
foreach (V _k1078 in new JsIter(list_1077)) {
V it_1079 = default;
it_1079 = _k1078;
V c_1080 = default;
c_1080 = Invoke(C_66, "get", Get(it_1079, "id"));
if (!(Truthy(c_1080))) {
continue;
}
Call(letGo_82, V.Undef, c_1080);
Call(later_81, V.Undef, Get(it_1079, "delay"), Fn((V _self1070, int _argc1081, V _a1083, V _a1084, V _a1085, V _a1086, V[] _rest1082) => {
Call(stop_75, V.Undef, c_1080, Arr(((V)("huh"))));
Call(play_83, V.Undef, c_1080, ((V)("sortDroop")));
Call(start_74, V.Undef, c_1080, NewObj(4).Put("kind", ((V)("sad"))).Put("dur", ((V)(1100D))).Put("prio", ((V)(1D))).Put("run", Fn((V _self1087, int _argc1088, V _a1090, V _a1091, V _a1092, V _a1093, V[] _rest1089) => {
if (_self1087.IsNullish) _self1087 = GlobalV;
return NewObj(0).V;
return default;
}, 0, "run", false)).V);
Set(c_1080, "sway", NewObj(2).Put("t0", Add(Invoke(G("performance"), "now"), ((V)(700D)))).Put("ph", ((V)(((ToNum(Invoke(G("Math"), "random")) * System.Math.PI) * 2D)))).V);
Call(later_81, V.Undef, ((V)(800D)), Fn((V _self1070, int _argc1094, V _a1096, V _a1097, V _a1098, V _a1099, V[] _rest1095) => {
Call(burst_79, V.Undef, c_1080, ((V)("sortTear")), ((V)("eyeL")));
Call(glow_80, V.Undef, c_1080, ((V)(1200D)));
return default;
}, 0, "", true));
return default;
}, 0, "", true));
}
}
return default;
}, 1, "lose", false)).Put("pause", Fn((V _self1100, int _argc1101, V on_1107, V _a1104, V _a1105, V _a1106, V[] _rest1102) => {
if (_self1100.IsNullish) _self1100 = GlobalV;
userPaused_89 = (!(!(Truthy(on_1107))) ? V.True : V.False);
Call(sync_91, V.Undef);
return default;
}, 1, "pause", false)).V;
running_88 = (false ? V.True : V.False);
userPaused_89 = (false ? V.True : V.False);
sleeping_90 = (false ? V.True : V.False);
sync_91 = Fn((V _self40, int _argc1108, V _a1110, V _a1111, V _a1112, V _a1113, V[] _rest1109) => {
return Invoke(window_39, "__rigPause", (userPaused_89 is var _t1114 && Truthy(_t1114) ? _t1114 : sleeping_90));
}, 0, "", true);
Set(window_39, "sortStage", api_87);
Set(api_87, "_C", C_66);
Set(api_87, "_state", Fn((V _self40, int _argc1115, V _a1117, V _a1118, V _a1119, V _a1120, V[] _rest1116) => {
return NewObj(3).Put("sleeping", sleeping_90).Put("userPaused", userPaused_89).Put("drawn", Invoke(Invoke(new ArrBuilder().Spread(Invoke(C_66, "values")).V, "filter", Fn((V _self40, int _argc1128, V c_1134, V _a1131, V _a1132, V _a1133, V[] _rest1129) => {
return (Get(c_1134, "I") is var _t1135 && !Truthy(_t1135) ? _t1135 : Get(Get(c_1134, "I"), "ready"));
}, 1, "", true)), "map", Fn((V _self40, int _argc1121, V c_1127, V _a1124, V _a1125, V _a1126, V[] _rest1122) => {
return Get(c_1127, "id");
}, 1, "", true))).V;
}, 0, "", true));
boot_94 = Fn((V _self40, int _argc1136, V _a1138, V _a1139, V _a1140, V _a1141, V[] _rest1137) => {
V R_1142 = default;
R_1142 = Get(window_39, "RiveRig");
if (Truthy((((((R_1142 is var _t1143 && !Truthy(_t1143) ? _t1143 : Get(R_1142, "REST")) is var _t1144 && !Truthy(_t1144) ? _t1144 : Get(R_1142, "DEFS")) is var _t1145 && !Truthy(_t1145) ? _t1145 : Get(Get(R_1142, "DEFS"), "prickle")) is var _t1146 && !Truthy(_t1146) ? _t1146 : Get(R_1142, "movesV")) is var _t1147 && !Truthy(_t1147) ? _t1147 : Get(window_39, "RiveGeneric")))) {
kv_56 = Get(R_1142, "kv");
Call(addStates_65, V.Undef);
Call(post_47, V.Undef, NewObj(1).Put("type", ((V)("ready"))).V);
} else {
Call(G("setTimeout"), V.Undef, boot_94, ((V)(25D)));
}
return default;
}, 0, "", true);
Call(boot_94, V.Undef);
Set(window_39, "onerror", Fn((V _self40, int _argc1148, V m_1154, V _a1151, V _a1152, V _a1153, V[] _rest1149) => {
return Call(post_47, V.Undef, NewObj(2).Put("type", ((V)("error"))).Put("message", ((V)(ToStrS(m_1154)))).V);
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
