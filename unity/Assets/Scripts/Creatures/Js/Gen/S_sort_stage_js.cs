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
rnd_107 = Fn((V _arrowThis120, int _argc114, V _a116, V _a117, V _a118, V _a119, V[] _rest115) => {
return ((V)(((sd_106 = ((sd_106 * 16807D) % 2147483647D)) / 2147483647D)));
}, 0, "", true);
oct_108 = Fn((V _arrowThis128, int _argc121, V n_127, V _a124, V _a125, V _a126, V[] _rest122) => {
V g_129 = default;
double c_130 = 0;
V sm_131 = default;
g_129 = Arr();
{
double i_132 = 0;
i_132 = 0D;
while (true) {
if (!((i_132 < (ToNum(n_127) * ToNum(n_127))))) break;
Invoke(g_129, "push", Call(rnd_107, V.Undef));
i_132++;
}
}
c_130 = (S_102 / ToNum(n_127));
sm_131 = Fn((V _arrowThis141, int _argc134, V t_140, V _a137, V _a138, V _a139, V[] _rest135) => {
return ((V)(((ToNum(t_140) * ToNum(t_140)) * (3D - (2D * ToNum(t_140))))));
}, 1, "", true);
return Fn((V _arrowThis150, int _argc142, V px_148, V py_149, V _a146, V _a147, V[] _rest143) => {
double gx_151 = 0;
double gy_152 = 0;
double x0_153 = 0;
double y0_154 = 0;
V fx_155 = default;
V fy_156 = default;
V a_157 = default;
V t_158 = default;
V b_159 = default;
gx_151 = (ToNum(px_148) / c_130);
gy_152 = (ToNum(py_149) / c_130);
x0_153 = System.Math.Floor(gx_151);
y0_154 = System.Math.Floor(gy_152);
fx_155 = Call(sm_131, V.Undef, ((V)((gx_151 - x0_153))));
fy_156 = Call(sm_131, V.Undef, ((V)((gy_152 - y0_154))));
a_157 = Fn((V _arrowThis168, int _argc160, V i_166, V j_167, V _a164, V _a165, V[] _rest161) => {
return GetIdx(g_129, (((ToNum(Add(((V)((ToNum(j_167) % ToNum(n_127)))), n_127)) % ToNum(n_127)) * ToNum(n_127)) + (ToNum(Add(((V)((ToNum(i_166) % ToNum(n_127)))), n_127)) % ToNum(n_127))));
}, 2, "", true);
t_158 = Add(Call(a_157, V.Undef, ((V)(x0_153)), ((V)(y0_154))), ((V)(((ToNum(Call(a_157, V.Undef, ((V)((x0_153 + 1D))), ((V)(y0_154)))) - ToNum(Call(a_157, V.Undef, ((V)(x0_153)), ((V)(y0_154))))) * ToNum(fx_155)))));
b_159 = Add(Call(a_157, V.Undef, ((V)(x0_153)), ((V)((y0_154 + 1D)))), ((V)(((ToNum(Call(a_157, V.Undef, ((V)((x0_153 + 1D))), ((V)((y0_154 + 1D))))) - ToNum(Call(a_157, V.Undef, ((V)(x0_153)), ((V)((y0_154 + 1D)))))) * ToNum(fx_155)))));
return Add(t_158, ((V)(((ToNum(b_159) - ToNum(t_158)) * ToNum(fy_156)))));
return default;
}, 2, "", true);
return default;
}, 1, "", true);
o1_109 = Call(oct_108, V.Undef, ((V)(32D)));
o2_110 = Call(oct_108, V.Undef, ((V)(64D)));
{
double y_169 = 0;
y_169 = 0D;
while (true) {
if (!((y_169 < S_102))) break;
{
double X_171 = 0;
X_171 = 0D;
while (true) {
if (!((X_171 < S_102))) break;
double v_173 = 0;
double k_174 = 0;
v_173 = (ToNum(Add(Call(o1_109, V.Undef, ((V)(X_171)), ((V)(y_169))), Call(o2_110, V.Undef, ((V)(X_171)), ((V)(y_169))))) / 2D);
k_174 = (((y_169 * S_102) + X_171) * 4D);
SetIdx(Get(im_105, "data"), (k_174 + 3D), ((V)(Round(((0.2 * 255D) * v_173)))));
X_171++;
}
}
y_169++;
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
} catch (System.Exception _ex175) {
V e_176 = default;
e_176 = Caught(_ex175);
FAB_61 = ((V)(""));
}
return FAB_61;
return default;
}, 0, "fabric", false);
bakeGrain_64 = Fn((V _self177, int _argc178, V svg_184, V _a181, V _a182, V _a183, V[] _rest179) => {
V els_185 = default;
V id_186 = default;
V f_187 = default;
V t_188 = default;
V im_189 = default;
V cm_190 = default;
V top_191 = default;
if (_self177.IsNullish) _self177 = GlobalV;
if ((!(Truthy(svg_184)) || !(Truthy(Call(fabric_62, V.Undef))))) {
return default;
}
els_185 = Invoke(new ArrBuilder().Spread(Invoke(svg_184, "querySelectorAll", ((V)("[filter]")))).V, "filter", Fn((V _arrowThis199, int _argc192, V e_198, V _a195, V _a196, V _a197, V[] _rest193) => {
V id_200 = default;
id_200 = GetIdx((Invoke(Invoke(e_198, "getAttribute", ((V)("filter"))), "match", NewRegExp(RX0, "url\\(#([^)]+)\\)", "")) is var _t201 && Truthy(_t201) ? _t201 : Arr()), 1D);
return (id_200 is var _t202 && !Truthy(_t202) ? _t202 : Call(isGrain_63, V.Undef, Invoke(svg_184, "getElementById", id_200)));
return default;
}, 1, "", true));
if (!(Truthy(Get(els_185, "length")))) {
return default;
}
id_186 = GetIdx(Invoke(Invoke(GetIdx(els_185, 0D), "getAttribute", ((V)("filter"))), "match", NewRegExp(RX0, "url\\(#([^)]+)\\)", "")), 1D);
f_187 = Invoke(svg_184, "getElementById", id_186);
t_188 = Invoke(f_187, "querySelector", ((V)("feTurbulence")));
im_189 = Invoke(G("document"), "createElementNS", ((V)("http://www.w3.org/2000/svg")), ((V)("feImage")));
Invoke(Arr(Arr(((V)("href")), FAB_61), Arr(((V)("x")), ((V)((-30D)))), Arr(((V)("y")), ((V)((-30D)))), Arr(((V)("width")), ((V)(160D))), Arr(((V)("height")), ((V)(160D))), Arr(((V)("preserveAspectRatio")), ((V)("none")))), "forEach", Fn((V _arrowThis214, int _argc203, V _a205, V _a206, V _a207, V _a208, V[] _rest204) => {
V a_211 = default;
V v_213 = default;
{ V _t209 = ListOf(_a205);
{ V _t210 = GetIdx(_t209, 0D);
a_211 = _t210; }
{ V _t212 = GetIdx(_t209, 1D);
v_213 = _t212; }
}
return Invoke(im_189, "setAttribute", a_211, v_213);
}, 1, "", true));
cm_190 = Get(t_188, "nextElementSibling");
Invoke(t_188, "replaceWith", im_189);
if (Truthy((cm_190 is var _t215 && !Truthy(_t215) ? _t215 : (SEqS(Get(cm_190, "tagName"), "feColorMatrix") ? V.True : V.False)))) {
Invoke(cm_190, "remove");
}
top_191 = Get(GetIdx(els_185, 0D), "parentNode");
while ((!SEq(top_191, svg_184) && !(Truthy(Invoke(els_185, "every", Fn((V _arrowThis223, int _argc216, V e_222, V _a219, V _a220, V _a221, V[] _rest217) => {
return Invoke(top_191, "contains", e_222);
}, 1, "", true)))))) {
top_191 = Get(top_191, "parentNode");
}
if (SEq(top_191, svg_184)) {
Invoke(els_185, "forEach", Fn((V _arrowThis231, int _argc224, V e_230, V _a227, V _a228, V _a229, V[] _rest225) => {
return Invoke(e_230, "setAttribute", ((V)("filter")), ((V)(JsStrBuf.Begin().S("url(#").V(id_186).S(")").End())));
}, 1, "", true));
return default;
}
Invoke(els_185, "forEach", Fn((V _arrowThis239, int _argc232, V e_238, V _a235, V _a236, V _a237, V[] _rest233) => {
return Invoke(e_238, "removeAttribute", ((V)("filter")));
}, 1, "", true));
Invoke(top_191, "setAttribute", ((V)("filter")), ((V)(JsStrBuf.Begin().S("url(#").V(id_186).S(")").End())));
return default;
}, 1, "bakeGrain", false);
addStates_65 = Fn((V _self240, int _argc241, V _a243, V _a244, V _a245, V _a246, V[] _rest242) => {
if (_self240.IsNullish) _self240 = GlobalV;
Object_assign(Get(Get(window_39, "RiveRig"), "PRE"), NewObj(4).Put("sortSweat", NewObj(8).Put("n", ((V)(1D))).Put("sp", ((V)(0D))).Put("vy", ((V)(6D))).Put("g", ((V)(34D))).Put("life", ((V)(950D))).Put("r", Arr(((V)(3D)), ((V)(3.4)))).Put("col", Arr(((V)("#8fd3ff")))).Put("kind", ((V)("drop"))).V).Put("sortSpark", NewObj(8).Put("n", ((V)(7D))).Put("sp", ((V)(34D))).Put("vy", ((V)((-12D)))).Put("g", ((V)(0D))).Put("life", ((V)(720D))).Put("r", Arr(((V)(3.6)), ((V)(5.6)))).Put("col", Arr(((V)("#fff3a0")), ((V)("#ffffff")), ((V)("#ffd23a")), ((V)("#ffd1f5")))).Put("kind", ((V)("star"))).V).Put("sortHeart", NewObj(7).Put("n", ((V)(1D))).Put("sp", ((V)(9D))).Put("vy", ((V)((-16D)))).Put("g", ((V)((-3D)))).Put("life", ((V)(1100D))).Put("r", Arr(((V)(1.8)), ((V)(2.2)))).Put("kind", ((V)("heart"))).V).Put("sortTear", NewObj(8).Put("n", ((V)(1D))).Put("sp", ((V)(0.6))).Put("vy", ((V)(3D))).Put("g", ((V)(18D))).Put("life", ((V)(1100D))).Put("r", Arr(((V)(2.2)), ((V)(2.5)))).Put("col", Arr(((V)("#8fd3ff")))).Put("kind", ((V)("drop"))).V).V);
Invoke(Get(window_39, "RiveRig"), "add", NewObj(7).Put("sortHeld", NewObj(3).Put("loop", ((V)(1000D))).Put("blend", ((V)(90D))).Put("k", NewObj(6).Put("smile", Arr(Arr(((V)(0D)), ((V)(0.8))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0.45))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0.35))))).Put("wide", Arr(Arr(((V)(0D)), ((V)(0.35))))).Put("blush", Arr(Arr(((V)(0D)), ((V)(0.4))))).Spread(Call(ER_58, V.Undef, Arr(Arr(((V)(0D)), ((V)(12D)))))).V).V).Put("sortJoy", NewObj(3).Put("dur", ((V)(1500D))).Put("blend", ((V)(80D))).Put("k", NewObj(5).Put("hap", Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(1200D)), ((V)(1D))), Arr(((V)(1500D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(1200D)), ((V)(1D))), Arr(((V)(1500D)), ((V)(0D)), ((V)("io"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(1100D)), ((V)(0.6))), Arr(((V)(1500D)), ((V)(0D)), ((V)("io"))))).Put("blush", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(1200D)), ((V)(0.6))), Arr(((V)(1500D)), ((V)(0D)), ((V)("io"))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(18D)), ((V)("io"))), Arr(((V)(400D)), ((V)((-18D))), ((V)("io"))), Arr(((V)(600D)), ((V)(18D)), ((V)("io"))), Arr(((V)(800D)), ((V)((-12D))), ((V)("io"))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).V).Put("sortNope", NewObj(3).Put("dur", ((V)(1700D))).Put("blend", ((V)(70D))).Put("k", NewObj(5).Put("frown", Arr(Arr(((V)(0D)), ((V)(1D))), Arr(((V)(1400D)), ((V)(1D))), Arr(((V)(1700D)), ((V)(0D)), ((V)("io"))))).Put("wide", Arr(Arr(((V)(0D)), ((V)(0.35))), Arr(((V)(1400D)), ((V)(0.35))), Arr(((V)(1700D)), ((V)(0D)), ((V)("io"))))).Put("teary", Arr(Arr(((V)(0D)), ((V)(0.35))), Arr(((V)(1400D)), ((V)(0.35))), Arr(((V)(1700D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))))).Spread(Call(ER_58, V.Undef, Arr(Arr(((V)(0D)), ((V)((-16D)))), Arr(((V)(1400D)), ((V)((-12D)))), Arr(((V)(1700D)), ((V)(0D)), ((V)("io")))))).V).V).Put("sortCaught", NewObj(3).Put("dur", ((V)(1400D))).Put("blend", ((V)(50D))).Put("k", NewObj(6).Put("wide", Arr(Arr(((V)(0D)), ((V)(1D))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0.75))))).Put("frown", Arr(Arr(((V)(0D)), ((V)(0.55))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))))).Put("blush", Arr(Arr(((V)(0D)), ((V)(0.8))))).Spread(Call(ER_58, V.Undef, Arr(Arr(((V)(0D)), ((V)((-18D))))))).V).V).Put("sortHuh", NewObj(3).Put("dur", ((V)(1600D))).Put("blend", ((V)(160D))).Put("k", NewObj(4).Put("frown", Arr(Arr(((V)(0D)), ((V)(0.3))), Arr(((V)(1300D)), ((V)(0.3))), Arr(((V)(1600D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))))).Put("htilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(7D)), ((V)("io"))), Arr(((V)(700D)), ((V)(7D))), Arr(((V)(1000D)), ((V)((-7D))), ((V)("io"))), Arr(((V)(1400D)), ((V)((-7D)))), Arr(((V)(1600D)), ((V)(0D)), ((V)("io"))))).Put("lx", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)((-0.9))), ((V)("io"))), Arr(((V)(700D)), ((V)((-0.9)))), Arr(((V)(1000D)), ((V)(0.9)), ((V)("io"))), Arr(((V)(1400D)), ((V)(0.9))), Arr(((V)(1600D)), ((V)(0D)), ((V)("io"))))).V).V).Put("sortDroop", NewObj(4).Put("dur", ((V)(760D))).Put("blend", ((V)(120D))).Put("next", ((V)("sortSad"))).Put("k", NewObj(9).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)((-0.12))), ((V)("o"))), Arr(((V)(520D)), ((V)(0.24)), ((V)("io"))), Arr(((V)(760D)), ((V)(0.16)), ((V)("io"))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(280D)), ((V)(0.15)), ((V)("o"))), Arr(((V)(600D)), ((V)((-0.6))), ((V)("io"))))).Put("ly", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(500D)), ((V)(0.6)), ((V)("io"))))).Put("frown", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(1D)), ((V)("io"))))).Put("teary", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(600D)), ((V)(0.7)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)(0.5)), ((V)("io"))), Arr(((V)(520D)), ((V)(0.25)), ((V)("io"))))).Spread(Call(ER_58, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(600D)), ((V)((-18D))), ((V)("io")))))).Spread(Call(AR_57, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(600D)), ((V)((-16D))), ((V)("io")))))).V).V).Put("sortSad", NewObj(4).Put("loop", ((V)(2600D))).Put("blend", ((V)(220D))).Put("noBlink", (true ? V.True : V.False)).Put("k", NewObj(9).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.16))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)((-0.6)))))).Put("ly", Arr(Arr(((V)(0D)), ((V)(0.6))))).Put("frown", Arr(Arr(((V)(0D)), ((V)(1D))))).Put("teary", Arr(Arr(((V)(0D)), ((V)(0.7))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0.25))))).Spread(Call(ER_58, V.Undef, Arr(Arr(((V)(0D)), ((V)((-18D))))))).Spread(Call(AR_57, V.Undef, Arr(Arr(((V)(0D)), ((V)((-16D))))))).V).V).V);
return default;
}, 0, "addStates", false);
mount_68 = Fn((V _self247, int _argc248, V c_254, V _a251, V _a252, V _a253, V[] _rest249) => {
if (_self247.IsNullish) _self247 = GlobalV;
Set(c_254, "sh", Invoke(G("document"), "createElement", ((V)("div"))));
Set(Get(c_254, "sh"), "className", ((V)("sh")));
Set(Get(Get(c_254, "sh"), "style"), "opacity", ((V)("0")));
Invoke(board_48, "appendChild", Get(c_254, "sh"));
Set(c_254, "el", Invoke(G("document"), "createElement", ((V)("div"))));
Set(Get(c_254, "el"), "className", ((V)("ch")));
Set(c_254, "inner", Invoke(G("document"), "createElement", ((V)("div"))));
Invoke(Get(c_254, "el"), "appendChild", Get(c_254, "inner"));
Invoke(board_48, "appendChild", Get(c_254, "el"));
Set(Get(Get(c_254, "el"), "style"), "opacity", ((V)("0")));
if (Truthy(Get(window_39, "__rgI"))) {
DeleteK(Get(window_39, "__rgI"), Get(c_254, "key"));
}
Set(c_254, "ctrl", Invoke(Get(window_39, "RiveRig"), "mount", Get(c_254, "inner"), Get(c_254, "key"), NewObj(1).Put("fidgets", (false ? V.True : V.False)).V));
Set(c_254, "I", Get(Get(c_254, "ctrl"), "_I"));
Set(c_254, "t0", Invoke(G("performance"), "now"));
return default;
}, 1, "mount", false);
unmount_69 = Fn((V _self255, int _argc256, V c_262, V _a259, V _a260, V _a261, V[] _rest257) => {
if (_self255.IsNullish) _self255 = GlobalV;
if (Truthy(Get(c_262, "ctrl"))) {
Invoke(Get(c_262, "ctrl"), "destroy");
}
if (Truthy(Get(c_262, "el"))) {
Invoke(Get(c_262, "el"), "remove");
}
if (Truthy(Get(c_262, "sh"))) {
Invoke(Get(c_262, "sh"), "remove");
}
return default;
}, 1, "unmount", false);
measure_70 = Fn((V _self263, int _argc264, V c_270, V _a267, V _a268, V _a269, V[] _rest265) => {
V svg_271 = default;
V b_272 = default;
if (_self263.IsNullish) _self263 = GlobalV;
svg_271 = Invoke(Get(c_270, "inner"), "querySelector", ((V)("svg")));
if (!(Truthy(svg_271))) {
return V.Null;
}
b_272 = V.Null;
try {
b_272 = Invoke(svg_271, "getBBox");
} catch (System.Exception _ex273) {
V e_274 = default;
e_274 = Caught(_ex273);

}
if ((!(Truthy(b_272)) || !(GtN(Get(b_272, "width"), 1D)))) {
return V.Null;
}
return NewObj(4).Put("cx", Add(Get(b_272, "x"), ((V)((ToNum(Get(b_272, "width")) / 2D))))).Put("gy", Add(Get(b_272, "y"), Get(b_272, "height"))).Put("bw", Get(b_272, "width")).Put("top", Get(b_272, "y")).V;
return default;
}, 1, "measure", false);
ready_71 = Fn((V _self275, int _argc276, V c_282, V _a279, V _a280, V _a281, V[] _rest277) => {
V bb_283 = default;
if (_self275.IsNullish) _self275 = GlobalV;
if (Truthy(Get(c_282, "bb"))) {
return (true ? V.True : V.False);
}
if (!(Truthy(Get(c_282, "I")))) {
return (false ? V.True : V.False);
}
if (Truthy((Get(Get(c_282, "I"), "generic") is var _t284 && !Truthy(_t284) ? _t284 : (!(Truthy(Get(Get(c_282, "I"), "ready"))) ? V.True : V.False)))) {
return (false ? V.True : V.False);
}
Invoke(Get(c_282, "ctrl"), "_pose", ((V)("idle")), ((V)(0D)));
bb_283 = Call(measure_70, V.Undef, c_282);
if (!(Truthy(bb_283))) {
return (false ? V.True : V.False);
}
Set(c_282, "bb", bb_283);
Call(bakeGrain_64, V.Undef, Invoke(Get(c_282, "inner"), "querySelector", ((V)("svg"))));
Set(c_282, "settle", Add(Invoke(G("performance"), "now"), ((V)(80D))));
return (true ? V.True : V.False);
return default;
}, 1, "ready", false);
draw_72 = Fn((V _self285, int _argc286, V c_292, V b_293, V _a290, V _a291, V[] _rest287) => {
V m_294 = default;
double side_295 = 0;
double k_296 = 0;
double x_297 = 0;
double y_298 = 0;
V fx_299 = default;
V fy_300 = default;
V sq_301 = default;
double sx_302 = 0;
double sy_303 = 0;
JsStrBuf tf_304 = null;
V z_305 = default;
double o_306 = 0;
V up_307 = default;
double f_308 = 0;
double w_309 = 0;
double h_310 = 0;
double shx_311 = 0;
double shy_312 = 0;
if (_self285.IsNullish) _self285 = GlobalV;
if ((!(Truthy(Get(c_292, "bb"))) || !(Truthy(Get(c_292, "el"))))) {
return default;
}
m_294 = (Get(c_292, "cur") is var _t313 && Truthy(_t313) ? _t313 : NewObj(0).V);
side_295 = ((ToNum(Get(c_292, "P")) * ToNum(Get(c_292, "s"))) * ToNum((Get(m_294, "k").IsNullish ? ((V)(1D)) : Get(m_294, "k"))));
k_296 = ((0.88 * side_295) / 100D);
x_297 = ((ToNum(Add(Add(Get(c_292, "x"), ((V)((ToNum(Get(c_292, "P")) / 2D)))), (Get(m_294, "dx") is var _t314 && Truthy(_t314) ? _t314 : ((V)(0D))))) - (side_295 / 2D)) + (0.06 * side_295));
y_298 = ((ToNum(Add(Add(Get(c_292, "y"), ((V)((ToNum(Get(c_292, "P")) / 2D)))), (Get(m_294, "dy") is var _t315 && Truthy(_t315) ? _t315 : ((V)(0D))))) - (side_295 / 2D)) + (0.06 * side_295));
fx_299 = Get(Get(c_292, "bb"), "cx");
fy_300 = Get(Get(c_292, "bb"), "gy");
sq_301 = Call(clamp_49, V.Undef, (Get(b_293, "sq") is var _t316 && Truthy(_t316) ? _t316 : ((V)(0D))), ((V)((-0.45))), ((V)(0.45)));
sx_302 = (1D + (ToNum(sq_301) * 0.42));
sy_303 = (1D - (ToNum(sq_301) * 0.5));
tf_304 = new JsStrBuf(JsStrBuf.Begin().S("translate(").V(Invoke(((V)(x_297)), "toFixed", ((V)(2D)))).S("px,").V(Invoke(((V)((y_298 - ToNum((Get(b_293, "lift") is var _t317 && Truthy(_t317) ? _t317 : ((V)(0D))))))), "toFixed", ((V)(2D)))).S("px) scale(").V(Invoke(((V)(k_296)), "toFixed", ((V)(4D)))).S(")").End());
if (Truthy((sq_301 is var _t318 && Truthy(_t318) ? _t318 : Get(b_293, "tilt")))) {
tf_304.S(" translate(").V(Invoke(fx_299, "toFixed", ((V)(2D)))).S("px,").V(Invoke(fy_300, "toFixed", ((V)(2D)))).S("px) rotate(").V(Invoke((Get(b_293, "tilt") is var _t319 && Truthy(_t319) ? _t319 : ((V)(0D))), "toFixed", ((V)(2D)))).S("deg) scale(").V(Invoke(((V)(sx_302)), "toFixed", ((V)(3D)))).S(",").V(Invoke(((V)(sy_303)), "toFixed", ((V)(3D)))).S(") translate(").V(Invoke(((V)((-ToNum(fx_299)))), "toFixed", ((V)(2D)))).S("px,").V(Invoke(((V)((-ToNum(fy_300)))), "toFixed", ((V)(2D)))).S("px)");
}
Set(Get(Get(c_292, "el"), "style"), "transform", ((V)(tf_304.Str)));
z_305 = (!Get(m_294, "z").IsNullish ? Get(m_294, "z") : Get(c_292, "z"));
Set(Get(Get(c_292, "el"), "style"), "zIndex", ((V)(ToStrS(z_305))));
o_306 = (ToNum(Get(c_292, "o")) * ToNum((Get(m_294, "o").IsNullish ? ((V)(1D)) : Get(m_294, "o"))));
Set(Get(Get(c_292, "el"), "style"), "opacity", ((V)(ToStrS(((V)((Round((o_306 * 100D)) / 100D)))))));
Set(c_292, "kNow", ((V)(k_296)));
up_307 = Add((Get(b_293, "lift") is var _t320 && Truthy(_t320) ? _t320 : ((V)(0D))), ((V)((ToNum((Get(b_293, "rigLift") is var _t321 && Truthy(_t321) ? _t321 : ((V)(0D)))) * k_296))));
f_308 = (1D - ToNum(Call(clamp_49, V.Undef, ((V)((ToNum(up_307) / (ToNum(Get(c_292, "P")) * 0.9)))), ((V)(0D)), ((V)(0.55)))));
w_309 = (((ToNum(Get(Get(c_292, "bb"), "bw")) * k_296) * 0.94) * f_308);
h_310 = (w_309 * 0.2);
shx_311 = ((x_297 + (ToNum(fx_299) * k_296)) - (w_309 / 2D));
shy_312 = ((y_298 + (ToNum(fy_300) * k_296)) - (h_310 * 0.55));
Set(Get(Get(c_292, "sh"), "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").V(Invoke(((V)(shx_311)), "toFixed", ((V)(2D)))).S("px,").V(Invoke(((V)(shy_312)), "toFixed", ((V)(2D)))).S("px) scale(").V(Invoke(((V)((w_309 / 100D))), "toFixed", ((V)(4D)))).S(",").V(Invoke(((V)((h_310 / 100D))), "toFixed", ((V)(4D)))).S(")").End())));
Set(Get(Get(c_292, "sh"), "style"), "zIndex", ((V)(ToStrS(((V)((ToNum(z_305) - 1D)))))));
Set(Get(Get(c_292, "sh"), "style"), "opacity", ((V)((Truthy(Invoke(Get(Get(c_292, "el"), "classList"), "contains", ((V)("air")))) ? "0" : ToStrS(((V)((Round(((o_306 * f_308) * 100D)) / 100D))))))));
return default;
}, 2, "draw", false);
start_74 = Fn((V _self322, int _argc323, V c_329, V mv_330, V _a327, V _a328, V[] _rest324) => {
if (_self322.IsNullish) _self322 = GlobalV;
Set(mv_330, "t0", Add(Invoke(G("performance"), "now"), (Get(mv_330, "delay") is var _t331 && Truthy(_t331) ? _t331 : ((V)(0D)))));
if (Get(mv_330, "prio").IsNullish) {
Set(mv_330, "prio", ((V)(2D)));
}
Invoke(Get(c_329, "moves"), "push", mv_330);
Call(kick_93, V.Undef);
return mv_330;
return default;
}, 2, "start", false);
stop_75 = Fn((V _self332, int _argc333, V c_339, V kinds_340, V _a337, V _a338, V[] _rest334) => {
V hit_341 = default;
if (_self332.IsNullish) _self332 = GlobalV;
hit_341 = Fn((V _arrowThis349, int _argc342, V m_348, V _a345, V _a346, V _a347, V[] _rest343) => {
return ((!(Truthy(kinds_340)) ? V.True : V.False) is var _t350 && Truthy(_t350) ? _t350 : Invoke(kinds_340, "includes", Get(m_348, "kind")));
}, 1, "", true);
Invoke(Get(c_339, "moves"), "forEach", Fn((V _arrowThis358, int _argc351, V m_357, V _a354, V _a355, V _a356, V[] _rest352) => {
if (Truthy(Call(hit_341, V.Undef, m_357))) {
Set(m_357, "dead", (true ? V.True : V.False));
}
return default;
}, 1, "", true));
if (Truthy(Get(c_339, "iter"))) {
Invoke(Get(c_339, "iter"), "forEach", Fn((V _arrowThis366, int _argc359, V m_365, V _a362, V _a363, V _a364, V[] _rest360) => {
if (Truthy(Call(hit_341, V.Undef, m_365))) {
Set(m_365, "dead", (true ? V.True : V.False));
}
return default;
}, 1, "", true));
}
Set(c_339, "moves", Invoke(Get(c_339, "moves"), "filter", Fn((V _arrowThis374, int _argc367, V m_373, V _a370, V _a371, V _a372, V[] _rest368) => {
return (!(Truthy(Get(m_373, "dead"))) ? V.True : V.False);
}, 1, "", true)));
return default;
}, 2, "stop", false);
land_77 = Fn((V _self375, int _argc376, V c_382, V _a379, V _a380, V _a381, V[] _rest377) => {
double D_387 = 0;
V sq_388 = default;
V arms_389 = default;
V hard_384 = default;
V crowd_386 = default;
if (_self375.IsNullish) _self375 = GlobalV;
{ V _t383 = _a379; if (_t383.IsUndef) _t383 = ((V)(0.3));
hard_384 = _t383; }
{ V _t385 = _a380; if (_t385.IsUndef) _t385 = (false ? V.True : V.False);
crowd_386 = _t385; }
D_387 = 380D;
sq_388 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(40D)), hard_384, ((V)("o"))), Arr(((V)(140D)), ((V)(((-ToNum(hard_384)) * 0.45))), ((V)("io"))), Arr(((V)(240D)), ((V)((ToNum(hard_384) * 0.2))), ((V)("io"))), Arr(((V)(320D)), ((V)(((-ToNum(hard_384)) * 0.08))), ((V)("io"))), Arr(((V)(D_387)), ((V)(0D)), ((V)("io"))));
arms_389 = Arr(Arr(((V)(0D)), ((V)(16D))), Arr(((V)(60D)), ((V)((-16D))), ((V)("o"))), Arr(((V)(200D)), ((V)(8D)), ((V)("io"))), Arr(((V)(D_387)), ((V)(0D)), ((V)("io"))));
return Call(start_74, V.Undef, c_382, NewObj(4).Put("kind", ((V)("land"))).Put("dur", ((V)(D_387))).Put("prio", ((V)((Truthy(crowd_386) ? 1D : 2D)))).Put("run", Fn((V _self390, int _argc391, V c_397, V t_398, V _a395, V _a396, V[] _rest392) => {
V s_399 = default;
V a_400 = default;
if (_self390.IsNullish) _self390 = GlobalV;
s_399 = Call(kv_56, V.Undef, sq_388, t_398);
a_400 = Call(kv_56, V.Undef, arms_389, t_398);
return (Truthy(crowd_386) ? NewObj(2).Put("body", NewObj(1).Put("sq", s_399).V).Put("ext", NewObj(2).Put("armL", a_400).Put("armR", a_400).V).V : NewObj(1).Put("ext", NewObj(3).Put("sq", s_399).Put("armL", a_400).Put("armR", a_400).V).V);
return default;
}, 2, "run", false)).V);
return default;
}, 3, "land", false);
travel_78 = Fn((V _self401, int _argc402, V c_408, V to_409, V o_410, V then_411, V[] _rest403) => {
V from_412 = default;
double dist_413 = 0;
V D_414 = default;
V H_415 = default;
double side_416 = 0;
V ease_417 = default;
V crowd_418 = default;
if (_self401.IsNullish) _self401 = GlobalV;
from_412 = NewObj(3).Put("x", Get(c_408, "x")).Put("y", Get(c_408, "y")).Put("s", Get(c_408, "s")).V;
dist_413 = Hypot((ToNum(Get(to_409, "x")) - ToNum(Get(from_412, "x"))), (ToNum(Get(to_409, "y")) - ToNum(Get(from_412, "y"))));
D_414 = (Get(o_410, "ms") is var _t419 && Truthy(_t419) ? _t419 : Call(clamp_49, V.Undef, ((V)((200D + (dist_413 * 0.6)))), ((V)(220D)), ((V)(520D))));
H_415 = (!Get(o_410, "h").IsNullish ? Get(o_410, "h") : ((V)(Min((ToNum(Get(c_408, "P")) * 0.7), (8D + (dist_413 * 0.25))))));
side_416 = (Sign((ToNum(Get(to_409, "x")) - ToNum(Get(from_412, "x")))) * Min(1D, (System.Math.Abs((ToNum(Get(to_409, "x")) - ToNum(Get(from_412, "x")))) / (ToNum(Get(c_408, "P")) * 1.5))));
ease_417 = (Truthy(Get(o_410, "back")) ? outBack_53 : outQ_52);
crowd_418 = (!(!(Truthy(Get(o_410, "crowd")))) ? V.True : V.False);
return Call(start_74, V.Undef, c_408, NewObj(6).Put("kind", (Get(o_410, "kind") is var _t420 && Truthy(_t420) ? _t420 : ((V)("go")))).Put("delay", Get(o_410, "delay")).Put("dur", D_414).Put("prio", ((V)((Truthy(crowd_418) ? 1D : 2D)))).Put("run", Fn((V _self421, int _argc422, V c_428, V t_429, V _a426, V _a427, V[] _rest423) => {
V u_430 = default;
V e_431 = default;
V air_432 = default;
V arms_433 = default;
if (_self421.IsNullish) _self421 = GlobalV;
u_430 = Call(clamp_49, V.Undef, ((V)((ToNum(t_429) / ToNum(D_414)))), ((V)(0D)), ((V)(1D)));
e_431 = Call(ease_417, V.Undef, u_430);
air_432 = Call(parab_55, V.Undef, u_430);
Set(c_428, "x", Call(lerp_50, V.Undef, Get(from_412, "x"), Get(to_409, "x"), e_431));
Set(c_428, "y", Call(lerp_50, V.Undef, Get(from_412, "y"), Get(to_409, "y"), e_431));
Set(c_428, "s", Call(lerp_50, V.Undef, Get(from_412, "s"), (Get(to_409, "s").IsNullish ? Get(from_412, "s") : Get(to_409, "s")), Call(outQ_52, V.Undef, u_430)));
arms_433 = NewObj(3).Put("armL", ((V)((34D * ToNum(air_432))))).Put("armR", ((V)((34D * ToNum(air_432))))).Put("lean", ((V)(((side_416 * 2.5) * ToNum(air_432))))).V;
return (Truthy(crowd_418) ? NewObj(3).Put("z", ((V)(40D))).Put("body", NewObj(3).Put("lift", ((V)((ToNum(H_415) * ToNum(air_432))))).Put("sq", ((V)(((-0.24) * ToNum(air_432))))).Put("tilt", ((V)(((side_416 * 10D) * ToNum(air_432))))).V).Put("ext", arms_433).V : NewObj(2).Put("z", ((V)(40D))).Put("ext", Object_assign(NewObj(3).Put("lift", Call(toU_73, V.Undef, c_428, ((V)((ToNum(H_415) * ToNum(air_432)))))).Put("sq", ((V)(((-0.24) * ToNum(air_432))))).Put("tilt", ((V)(((side_416 * 10D) * ToNum(air_432))))).V, arms_433)).V);
return default;
}, 2, "run", false)).Put("done", Fn((V _self434, int _argc435, V _a437, V _a438, V _a439, V _a440, V[] _rest436) => {
if (_self434.IsNullish) _self434 = GlobalV;
Set(c_408, "x", Get(to_409, "x"));
Set(c_408, "y", Get(to_409, "y"));
if (!Get(to_409, "s").IsNullish) {
Set(c_408, "s", Get(to_409, "s"));
}
Set(c_408, "z", (!Get(to_409, "z").IsNullish ? Get(to_409, "z") : ((V)(10D))));
if (!SEq(Get(o_410, "land"), (false ? V.True : V.False))) {
Call(land_77, V.Undef, c_408, (Get(o_410, "land") is var _t441 && Truthy(_t441) ? _t441 : ((V)(0.3))), crowd_418);
}
if (Truthy(then_411)) {
Call(then_411, V.Undef);
}
return default;
}, 0, "done", false)).V);
return default;
}, 4, "travel", false);
burst_79 = Fn((V _self442, int _argc443, V c_449, V kind_450, V where_451, V n_452, V[] _rest444) => {
V b_453 = default;
V W_454 = default;
V p_455 = default;
if (_self442.IsNullish) _self442 = GlobalV;
if ((!(Truthy(Get(c_449, "I"))) || !(Truthy(Get(c_449, "bb"))))) {
return default;
}
b_453 = Get(c_449, "bb");
W_454 = (Get(Get(c_449, "I"), "W") is var _t456 && Truthy(_t456) ? _t456 : NewObj(0).V);
p_455 = (SEqS(where_451, "feet") ? Arr(Get(b_453, "cx"), ((V)((ToNum(Get(b_453, "gy")) - 2D)))) : (SEqS(where_451, "head") ? Arr(Get(b_453, "cx"), Add(Get(b_453, "top"), ((V)(4D)))) : (SEqS(where_451, "temple") ? Arr(Add(Get(b_453, "cx"), ((V)((ToNum(Get(b_453, "bw")) * 0.34)))), Add(Get(b_453, "top"), ((V)((ToNum(Get(b_453, "bw")) * 0.2))))) : (GetK(W_454, where_451) is var _t457 && Truthy(_t457) ? _t457 : Arr(((V)(50D)), ((V)(50D)))))));
try {
V e_458 = default;
e_458 = Get(Get(window_39, "RiveRig"), "emit");
if (Truthy(e_458)) {
Call(e_458, V.Undef, Get(c_449, "I"), kind_450, p_455, n_452);
}
} catch (System.Exception _ex459) {
V x_460 = default;
x_460 = Caught(_ex459);

}
return default;
}, 4, "burst", false);
edgeOf_85 = Fn((V _self461, int _argc462, V d_468, V th_469, V p_470, V _a467, V[] _rest463) => {
double f_471 = 0;
double r_472 = 0;
if (_self461.IsNullish) _self461 = GlobalV;
f_471 = (ToNum(p_470) / (ToNum(p_470) - (ToNum(Get(d_468, "w")) * FdLibm.Sin(ToNum(th_469)))));
r_472 = (((ToNum(Get(d_468, "w")) * FdLibm.Cos(ToNum(th_469))) - (ToNum(Get(d_468, "w")) / 2D)) * f_471);
return (SEqS(Get(d_468, "hinge"), "left") ? Add(Add(Get(d_468, "x0"), ((V)((ToNum(Get(d_468, "w")) / 2D)))), ((V)(r_472))) : ((V)((ToNum(Add(Get(d_468, "x0"), ((V)((ToNum(Get(d_468, "w")) / 2D))))) - r_472))));
return default;
}, 3, "edgeOf", false);
doorClip_86 = Fn((V _self473, int _argc474, V now_480, V _a477, V _a478, V _a479, V[] _rest475) => {
double t_481 = 0;
V u_482 = default;
double open_483 = 0;
double th_484 = 0;
double L_485 = 0;
double R_486 = 0;
V W_487 = default;
if (_self473.IsNullish) _self473 = GlobalV;
if (!(Truthy(shut_84))) {
return (false ? V.True : V.False);
}
t_481 = (ToNum(now_480) - ToNum(Get(shut_84, "t0")));
if ((t_481 < 0D)) {
return (true ? V.True : V.False);
}
u_482 = Call(clamp_49, V.Undef, ((V)((t_481 / ToNum(Get(shut_84, "ms"))))), ((V)(0D)), ((V)(1D)));
open_483 = (1D - (ToNum(u_482) * ToNum(u_482)));
th_484 = (((ToNum(Get(shut_84, "deg")) * open_483) * System.Math.PI) / 180D);
L_485 = (-10000D);
R_486 = 10000D;
{
foreach (V _k488 in new JsIter(Get(shut_84, "list"))) {
V d_489 = default;
d_489 = _k488;
V e_490 = default;
e_490 = Call(edgeOf_85, V.Undef, d_489, ((V)(th_484)), Get(shut_84, "persp"));
if (SEqS(Get(d_489, "hinge"), "left")) {
if (Gt(e_490, Get(d_489, "x0"))) {
L_485 = Max(L_485, ToNum(Add(e_490, Get(shut_84, "lead"))));
}
} else {
if (Lt(e_490, Add(Get(d_489, "x0"), Get(d_489, "w")))) {
R_486 = Min(R_486, (ToNum(e_490) - ToNum(Get(shut_84, "lead"))));
}
}
}
}
W_487 = Get(window_39, "innerWidth");
Set(Get(board_48, "style"), "clipPath", ((V)(((L_485 >= R_486) ? "inset(0 0 0 100%)" : JsStrBuf.Begin().S("inset(0px ").V(Invoke(((V)(Max(0D, (ToNum(W_487) - R_486)))), "toFixed", ((V)(1D)))).S("px 0px ").V(Invoke(((V)(Max(0D, L_485))), "toFixed", ((V)(1D)))).S("px)").End()))));
return (LtN(u_482, 1D) ? V.True : V.False);
return default;
}, 1, "doorClip", false);
frame_92 = Fn((V _self491, int _argc492, V _a494, V _a495, V _a496, V _a497, V[] _rest493) => {
V now_498 = default;
V busy_499 = default;
V allReady_500 = default;
V want_501 = default;
V must_502 = default;
V rest_503 = default;
V on_504 = default;
if (_self491.IsNullish) _self491 = GlobalV;
now_498 = Invoke(G("performance"), "now");
busy_499 = Call(doorClip_86, V.Undef, now_498);
allReady_500 = (true ? V.True : V.False);
want_501 = Arr();
{
foreach (V _k505 in new JsIter(Invoke(C_66, "values"))) {
V c_506 = default;
c_506 = _k505;
V ext_507 = default;
V body_508 = default;
V cur_509 = default;
double prio_510 = 0;
V list_511 = default;
V kept_512 = default;
if (!(Truthy(Call(ready_71, V.Undef, c_506)))) {
if (((((ToNum(now_498) - ToNum(Get(c_506, "t0"))) > 9000D) && !castTag_67.IsNullish) && !SEq(Get(api_87, "_sent"), castTag_67))) {
Set(api_87, "_sent", castTag_67);
Call(post_47, V.Undef, NewObj(4).Put("type", ((V)("cast"))).Put("tag", castTag_67).Put("ok", (false ? V.True : V.False)).Put("key", Get(c_506, "key")).V);
}
allReady_500 = (false ? V.True : V.False);
busy_499 = (busy_499 is var _t513 && Truthy(_t513) ? _t513 : (((ToNum(now_498) - ToNum(Get(c_506, "t0"))) < 9000D) ? V.True : V.False));
continue;
}
ext_507 = NewObj(0).V;
body_508 = NewObj(0).V;
cur_509 = NewObj(2).Put("dx", ((V)(0D))).Put("dy", ((V)(0D))).V;
prio_510 = 0D;
list_511 = Get(c_506, "moves");
Set(c_506, "moves", Arr());
Set(c_506, "iter", list_511);
kept_512 = Arr();
{
foreach (V _k514 in new JsIter(list_511)) {
V m_515 = default;
m_515 = _k514;
double t_516 = 0;
V r_517 = default;
if (Truthy(Get(m_515, "dead"))) {
continue;
}
t_516 = (ToNum(now_498) - ToNum(Get(m_515, "t0")));
if ((t_516 < 0D)) {
if (Truthy(Get(m_515, "before"))) {
Object_assign(cur_509, Get(m_515, "before"));
}
Invoke(kept_512, "push", m_515);
continue;
}
if (Ge(((V)(t_516)), Get(m_515, "dur"))) {
Invoke(m_515, "run", c_506, Get(m_515, "dur"));
if (Truthy(((!(Truthy(Get(m_515, "dead"))) ? V.True : V.False) is var _t518 && !Truthy(_t518) ? _t518 : Get(m_515, "done")))) {
Invoke(m_515, "done");
}
continue;
}
r_517 = (Invoke(m_515, "run", c_506, ((V)(t_516))) is var _t519 && Truthy(_t519) ? _t519 : NewObj(0).V);
if (Truthy(Get(m_515, "fin"))) {
continue;
}
prio_510 = Max(prio_510, ToNum(Get(m_515, "prio")));
if (Truthy(Get(r_517, "dx"))) {
OpSet(cur_509, "dx", 0, Get(r_517, "dx"));
}
if (Truthy(Get(r_517, "dy"))) {
OpSet(cur_509, "dy", 0, Get(r_517, "dy"));
}
if (!Get(r_517, "k").IsNullish) {
Set(cur_509, "k", ((V)((ToNum((Get(cur_509, "k").IsNullish ? ((V)(1D)) : Get(cur_509, "k"))) * ToNum(Get(r_517, "k"))))));
}
if (!Get(r_517, "o").IsNullish) {
Set(cur_509, "o", ((V)((ToNum((Get(cur_509, "o").IsNullish ? ((V)(1D)) : Get(cur_509, "o"))) * ToNum(Get(r_517, "o"))))));
}
if (!Get(r_517, "z").IsNullish) {
Set(cur_509, "z", ((V)(Max(ToNum((Get(cur_509, "z") is var _t520 && Truthy(_t520) ? _t520 : ((V)(0D)))), ToNum(Get(r_517, "z"))))));
}
if (Truthy(Get(r_517, "ext"))) {
{
foreach (V _k521 in ForInKeys(Get(r_517, "ext"))) {
V k_522 = default;
k_522 = _k521;
SetK(ext_507, k_522, Add((GetK(ext_507, k_522) is var _t523 && Truthy(_t523) ? _t523 : ((V)(0D))), GetK(Get(r_517, "ext"), k_522)));
}
}
}
if (Truthy(Get(r_517, "body"))) {
{
foreach (V _k524 in ForInKeys(Get(r_517, "body"))) {
V k_525 = default;
k_525 = _k524;
SetK(body_508, k_525, Add((GetK(body_508, k_525) is var _t526 && Truthy(_t526) ? _t526 : ((V)(0D))), GetK(Get(r_517, "body"), k_525)));
}
}
}
Invoke(kept_512, "push", m_515);
}
}
Set(c_506, "iter", V.Null);
Set(c_506, "moves", Invoke(Invoke(kept_512, "filter", Fn((V _arrowThis534, int _argc527, V m_533, V _a530, V _a531, V _a532, V[] _rest528) => {
return (!(Truthy(Get(m_533, "dead"))) ? V.True : V.False);
}, 1, "", true)), "concat", Get(c_506, "moves")));
OpSet(c_506, "vx", 2, ((V)(0.86)));
OpSet(c_506, "vy", 2, ((V)(0.86)));
if (Truthy((Get(c_506, "sway") is var _t535 && !Truthy(_t535) ? _t535 : (Gt(now_498, Get(Get(c_506, "sway"), "t0")) ? V.True : V.False)))) {
double w_536 = 0;
w_536 = ((ToNum(now_498) - ToNum(Get(Get(c_506, "sway"), "t0"))) / 1000D);
Set(body_508, "tilt", Add((Get(body_508, "tilt") is var _t537 && Truthy(_t537) ? _t537 : ((V)(0D))), ((V)((3D * FdLibm.Sin(ToNum(Add(((V)((w_536 * 2.4))), Get(Get(c_506, "sway"), "ph")))))))));
Set(body_508, "sq", Add((Get(body_508, "sq") is var _t538 && Truthy(_t538) ? _t538 : ((V)(0D))), ((V)((0.02 * FdLibm.Sin(ToNum(Add(((V)((w_536 * 4.8))), Get(Get(c_506, "sway"), "ph")))))))));
busy_499 = (true ? V.True : V.False);
}
if (!Get(ext_507, "sq").IsNullish) {
Set(ext_507, "sq", Call(clamp_49, V.Undef, Get(ext_507, "sq"), ((V)((-0.45))), ((V)(0.45))));
}
if (GtN(Get(ext_507, "lift"), LIFT_CAP_60)) {
Set(body_508, "lift", Add((Get(body_508, "lift") is var _t539 && Truthy(_t539) ? _t539 : ((V)(0D))), ((V)(((ToNum(Get(ext_507, "lift")) - LIFT_CAP_60) * ToNum((Get(c_506, "kNow") is var _t540 && Truthy(_t540) ? _t540 : ((V)(0D)))))))));
Set(ext_507, "lift", ((V)(LIFT_CAP_60)));
}
Set(body_508, "rigLift", (Get(ext_507, "lift") is var _t541 && Truthy(_t541) ? _t541 : ((V)(0D))));
Set(c_506, "cur", cur_509);
if (Truthy(Get(c_506, "ctrl"))) {
Invoke(Get(c_506, "ctrl"), "ext", ext_507);
}
Call(draw_72, V.Undef, c_506, body_508);
if (Truthy(Get(Get(c_506, "moves"), "length"))) {
Set(c_506, "settle", Add(now_498, ((V)(450D))));
busy_499 = (true ? V.True : V.False);
}
Set(c_506, "prio", ((V)(prio_510)));
if (Truthy((Get(Get(c_506, "moves"), "length") is var _t542 && Truthy(_t542) ? _t542 : (Lt(now_498, Get(c_506, "settle")) ? V.True : V.False)))) {
Invoke(want_501, "push", c_506);
if (Truthy(Get(c_506, "I"))) {
Set(Get(c_506, "I"), "blinkAt", ((V)(Max(ToNum(Get(Get(c_506, "I"), "blinkAt")), ToNum(Add(now_498, ((V)(700D))))))));
if (!(Truthy(Get(Get(c_506, "moves"), "length")))) {
Set(Get(c_506, "I"), "gl", Arr(((V)(0D)), ((V)(0D))));
Set(Get(c_506, "I"), "glAt", Add(now_498, ((V)(4000D))));
}
}
busy_499 = (true ? V.True : V.False);
}
}
}
must_502 = Invoke(want_501, "filter", Fn((V _arrowThis550, int _argc543, V c_549, V _a546, V _a547, V _a548, V[] _rest544) => {
return (GeN(Get(c_549, "prio"), 2D) ? V.True : V.False);
}, 1, "", true));
rest_503 = Invoke(Invoke(Invoke(want_501, "filter", Fn((V _arrowThis567, int _argc560, V c_566, V _a563, V _a564, V _a565, V[] _rest561) => {
return (LtN(Get(c_566, "prio"), 2D) ? V.True : V.False);
}, 1, "", true)), "sort", Fn((V _arrowThis559, int _argc551, V a_557, V b_558, V _a555, V _a556, V[] _rest552) => {
return ((V)((ToNum(Get(a_557, "lastR")) - ToNum(Get(b_558, "lastR")))));
}, 2, "", true)), "slice", ((V)(0D)), ((V)(BUDGET_59)));
on_504 = New(G("Set"), Invoke(must_502, "concat", rest_503));
{
foreach (V _k568 in new JsIter(Invoke(C_66, "values"))) {
V c_569 = default;
c_569 = _k568;
if (((!(Truthy(Get(c_569, "bb"))) || !(Truthy(Get(c_569, "I")))) || !(Truthy(Get(Get(c_569, "I"), "generic"))))) {
continue;
}
Set(Get(c_569, "I"), "ready", Invoke(on_504, "has", c_569));
if (Truthy(Get(Get(c_569, "I"), "ready"))) {
Set(c_569, "lastR", now_498);
}
}
}
if (Truthy((((allReady_500 is var _t570 && !Truthy(_t570) ? _t570 : (!castTag_67.IsNullish ? V.True : V.False)) is var _t571 && !Truthy(_t571) ? _t571 : Get(C_66, "size")) is var _t572 && !Truthy(_t572) ? _t572 : (!(Truthy(Get(api_87, "_sent"))) ? V.True : V.False)))) {
Set(api_87, "_sent", castTag_67);
Call(post_47, V.Undef, NewObj(3).Put("type", ((V)("cast"))).Put("tag", castTag_67).Put("ok", (true ? V.True : V.False)).V);
}
if (Truthy(busy_499)) {
Call(G("requestAnimationFrame"), V.Undef, frame_92);
} else {
running_88 = (false ? V.True : V.False);
sleeping_90 = (true ? V.True : V.False);
Call(sync_91, V.Undef);
}
return default;
}, 0, "frame", false);
kick_93 = Fn((V _self573, int _argc574, V _a576, V _a577, V _a578, V _a579, V[] _rest575) => {
if (_self573.IsNullish) _self573 = GlobalV;
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
post_47 = Fn((V _arrowThis587, int _argc580, V m_586, V _a583, V _a584, V _a585, V[] _rest581) => {
V s_588 = default;
s_588 = Invoke(G("JSON"), "stringify", m_586);
if (Truthy(Get(window_39, "ReactNativeWebView"))) {
Invoke(Get(window_39, "ReactNativeWebView"), "postMessage", s_588);
} else {
Invoke(Set(window_39, "__sortOut", (Get(window_39, "__sortOut") is var _t589 && Truthy(_t589) ? _t589 : Arr())), "push", m_586);
}
return default;
}, 1, "", true);
board_48 = Invoke(G("document"), "getElementById", ((V)("board")));
clamp_49 = Fn((V _arrowThis599, int _argc590, V v_596, V a_597, V b_598, V _a595, V[] _rest591) => {
return ((V)(Max(ToNum(a_597), Min(ToNum(b_598), ToNum(v_596)))));
}, 3, "", true);
lerp_50 = Fn((V _arrowThis609, int _argc600, V a_606, V b_607, V t_608, V _a605, V[] _rest601) => {
return Add(a_606, ((V)(((ToNum(b_607) - ToNum(a_606)) * ToNum(t_608)))));
}, 3, "", true);
SM_51 = Fn((V _arrowThis617, int _argc610, V x_616, V _a613, V _a614, V _a615, V[] _rest611) => {
x_616 = Call(clamp_49, V.Undef, x_616, ((V)(0D)), ((V)(1D)));
return ((V)(((ToNum(x_616) * ToNum(x_616)) * (3D - (2D * ToNum(x_616))))));
return default;
}, 1, "", true);
outQ_52 = Fn((V _arrowThis625, int _argc618, V u_624, V _a621, V _a622, V _a623, V[] _rest619) => {
return ((V)((1D - ((1D - ToNum(u_624)) * (1D - ToNum(u_624))))));
}, 1, "", true);
outBack_53 = Fn((V _arrowThis633, int _argc626, V u_632, V _a629, V _a630, V _a631, V[] _rest627) => {
double v_634 = 0;
v_634 = (ToNum(u_632) - 1D);
return ((V)(((1D + (((2.70158 * v_634) * v_634) * v_634)) + ((1.70158 * v_634) * v_634))));
return default;
}, 1, "", true);
bounce_54 = Fn((V _arrowThis642, int _argc635, V t_641, V _a638, V _a639, V _a640, V[] _rest636) => {
double u_643 = 0;
if (LtN(t_641, (1D / 2.75))) {
return ((V)(((7.5625 * ToNum(t_641)) * ToNum(t_641))));
}
if (LtN(t_641, (2D / 2.75))) {
double u_644 = 0;
u_644 = (ToNum(t_641) - (1.5 / 2.75));
return ((V)((((7.5625 * u_644) * u_644) + 0.75)));
}
if (LtN(t_641, (2.5 / 2.75))) {
double u_645 = 0;
u_645 = (ToNum(t_641) - (2.25 / 2.75));
return ((V)((((7.5625 * u_645) * u_645) + 0.9375)));
}
u_643 = (ToNum(t_641) - (2.625 / 2.75));
return ((V)((((7.5625 * u_643) * u_643) + 0.984375)));
return default;
}, 1, "", true);
parab_55 = Fn((V _arrowThis653, int _argc646, V u_652, V _a649, V _a650, V _a651, V[] _rest647) => {
return ((V)(((LeN(u_652, 0D) || GeN(u_652, 1D)) ? 0D : ((4D * ToNum(u_652)) * (1D - ToNum(u_652))))));
}, 1, "", true);
kv_56 = V.Null;
AR_57 = Fn((V _arrowThis661, int _argc654, V K_660, V _a657, V _a658, V _a659, V[] _rest655) => {
return NewObj(2).Put("armL", K_660).Put("armR", K_660).V;
}, 1, "", true);
ER_58 = Fn((V _arrowThis669, int _argc662, V K_668, V _a665, V _a666, V _a667, V[] _rest663) => {
return NewObj(2).Put("earL", K_668).Put("earR", K_668).V;
}, 1, "", true);
BUDGET_59 = 2D;
LIFT_CAP_60 = 40D;
FAB_61 = V.Null;
isGrain_63 = Fn((V _arrowThis677, int _argc670, V f_676, V _a673, V _a674, V _a675, V[] _rest671) => {
return (((f_676 is var _t678 && !Truthy(_t678) ? _t678 : Invoke(f_676, "querySelector", ((V)("feTurbulence")))) is var _t679 && !Truthy(_t679) ? _t679 : (!(Truthy(Invoke(f_676, "querySelector", ((V)("feDisplacementMap"))))) ? V.True : V.False)) is var _t680 && !Truthy(_t680) ? _t680 : Invoke(f_676, "querySelector", ((V)("feBlend[mode=\"multiply\"]"))));
}, 1, "", true);
C_66 = New(G("Map"));
castTag_67 = V.Null;
toU_73 = Fn((V _arrowThis689, int _argc681, V c_687, V dp_688, V _a685, V _a686, V[] _rest682) => {
return ((V)((Truthy(Get(c_687, "kNow")) ? (ToNum(dp_688) / ToNum(Get(c_687, "kNow"))) : 0D)));
}, 2, "", true);
TRAVEL_76 = Arr(((V)("go")), ((V)("tumble")), ((V)("correct")), ((V)("wrong")), ((V)("caught")), ((V)("win")), ((V)("land")), ((V)("huh")), ((V)("sad")));
glow_80 = Fn((V _arrowThis698, int _argc690, V c_696, V ms_697, V _a694, V _a695, V[] _rest691) => {
return Call(start_74, V.Undef, c_696, NewObj(3).Put("kind", ((V)("glow"))).Put("dur", ms_697).Put("run", Fn((V _self699, int _argc700, V _a702, V _a703, V _a704, V _a705, V[] _rest701) => {
if (_self699.IsNullish) _self699 = GlobalV;
return NewObj(0).V;
return default;
}, 0, "run", false)).V);
}, 2, "", true);
later_81 = Fn((V _arrowThis714, int _argc706, V ms_712, V fn_713, V _a710, V _a711, V[] _rest707) => {
return Call(G("setTimeout"), V.Undef, fn_713, ms_712);
}, 2, "", true);
letGo_82 = Fn((V _arrowThis722, int _argc715, V c_721, V _a718, V _a719, V _a720, V[] _rest716) => {
if (Truthy((Get(c_721, "held") is var _t723 && !Truthy(_t723) ? _t723 : (!(Truthy(Get(Get(c_721, "held"), "rel"))) ? V.True : V.False)))) {
Set(Get(c_721, "held"), "rel", Invoke(G("performance"), "now"));
}
Set(c_721, "held", V.Null);
Invoke(Get(Get(c_721, "el"), "classList"), "remove", ((V)("air")));
return default;
}, 1, "", true);
play_83 = Fn((V _arrowThis732, int _argc724, V c_730, V name_731, V _a728, V _a729, V[] _rest725) => {
if (Truthy(((Get(c_730, "ctrl") is var _t733 && !Truthy(_t733) ? _t733 : Get(c_730, "I")) is var _t734 && !Truthy(_t734) ? _t734 : (!SEq(Get(Get(Get(c_730, "I"), "cur"), "name"), name_731) ? V.True : V.False)))) {
Invoke(Get(c_730, "ctrl"), "play", name_731);
}
return default;
}, 2, "", true);
shut_84 = V.Null;
api_87 = NewObj(15).Put("cast", Fn((V _self735, int _argc736, V list_742, V tag_743, V _a740, V _a741, V[] _rest737) => {
V ids_744 = default;
if (_self735.IsNullish) _self735 = GlobalV;
castTag_67 = tag_743;
Set(api_87, "_sent", V.Null);
shut_84 = V.Null;
Set(Get(board_48, "style"), "clipPath", ((V)("")));
ids_744 = New(G("Set"), Invoke(list_742, "map", Fn((V _arrowThis752, int _argc745, V c_751, V _a748, V _a749, V _a750, V[] _rest746) => {
return Get(c_751, "id");
}, 1, "", true)));
{
foreach (V _k753 in new JsIter(C_66)) {
V id_754 = default;
V c_755 = default;
{ V _t756 = ListOf(_k753);
{ V _t757 = GetIdx(_t756, 0D);
id_754 = _t757; }
{ V _t758 = GetIdx(_t756, 1D);
c_755 = _t758; }
}
if (!(Truthy(Invoke(ids_744, "has", id_754)))) {
Call(unmount_69, V.Undef, c_755);
Invoke(C_66, "delete", id_754);
}
}
}
{
foreach (V _k759 in new JsIter(list_742)) {
V it_760 = default;
it_760 = _k759;
V c_761 = default;
c_761 = Invoke(C_66, "get", Get(it_760, "id"));
if (Truthy((c_761 is var _t762 && !Truthy(_t762) ? _t762 : (!SEq(Get(c_761, "key"), Get(it_760, "key")) ? V.True : V.False)))) {
Call(unmount_69, V.Undef, c_761);
Invoke(C_66, "delete", Get(it_760, "id"));
c_761 = V.Null;
}
if (!(Truthy(c_761))) {
c_761 = NewObj(7).Put("id", Get(it_760, "id")).Put("key", Get(it_760, "key")).Put("moves", Arr()).Put("vx", ((V)(0D))).Put("vy", ((V)(0D))).Put("lastR", ((V)(0D))).Put("settle", ((V)(0D))).V;
Invoke(C_66, "set", Get(it_760, "id"), c_761);
Call(mount_68, V.Undef, c_761);
}
Object_assign(c_761, NewObj(9).Put("P", Get(it_760, "P")).Put("x", ((V)((-1000D)))).Put("y", ((V)((-1000D)))).Put("s", ((V)(1D))).Put("o", ((V)(0D))).Put("z", ((V)(10D))).Put("held", V.Null).Put("cur", V.Null).Put("sway", V.Null).V);
Set(c_761, "moves", Arr());
Invoke(Get(Get(c_761, "el"), "classList"), "remove", ((V)("air")));
if (Truthy(Get(c_761, "bb"))) {
Call(play_83, V.Undef, c_761, ((V)("idle")));
Set(c_761, "settle", Add(Invoke(G("performance"), "now"), ((V)(300D))));
}
}
}
Call(kick_93, V.Undef);
return default;
}, 2, "cast", false)).Put("place", Fn((V _self763, int _argc764, V id_770, V p_771, V _a768, V _a769, V[] _rest765) => {
V c_772 = default;
if (_self763.IsNullish) _self763 = GlobalV;
c_772 = Invoke(C_66, "get", id_770);
if (!(Truthy(c_772))) {
return default;
}
Call(stop_75, V.Undef, c_772);
Set(c_772, "held", V.Null);
Set(c_772, "sway", V.Null);
Invoke(Get(Get(c_772, "el"), "classList"), "remove", ((V)("air")));
Object_assign(c_772, NewObj(4).Put("x", Get(p_771, "x")).Put("y", Get(p_771, "y")).Put("s", (Get(p_771, "s").IsNullish ? ((V)(1D)) : Get(p_771, "s"))).Put("z", (Get(p_771, "z").IsNullish ? ((V)(10D)) : Get(p_771, "z"))).V);
if (!Get(p_771, "o").IsNullish) {
Set(c_772, "o", Get(p_771, "o"));
}
Call(play_83, V.Undef, c_772, ((V)("idle")));
Set(c_772, "settle", Add(Invoke(G("performance"), "now"), ((V)(300D))));
Call(kick_93, V.Undef);
return default;
}, 2, "place", false)).Put("hideAll", Fn((V _self773, int _argc774, V _a776, V _a777, V _a778, V _a779, V[] _rest775) => {
if (_self773.IsNullish) _self773 = GlobalV;
{
foreach (V _k780 in new JsIter(Invoke(C_66, "values"))) {
V c_781 = default;
c_781 = _k780;
Call(stop_75, V.Undef, c_781);
Set(c_781, "held", V.Null);
Set(c_781, "sway", V.Null);
Set(c_781, "o", ((V)(0D)));
}
}
shut_84 = V.Null;
Set(Get(board_48, "style"), "clipPath", ((V)("")));
Call(kick_93, V.Undef);
return default;
}, 0, "hideAll", false)).Put("tumble", Fn((V _self782, int _argc783, V id_789, V from_790, V to_791, V delay_792, V[] _rest784) => {
V c_795 = default;
double D_796 = 0;
double up_797 = 0;
V peak_793 = default;
V inside_794 = default;
if (_self782.IsNullish) _self782 = GlobalV;
peak_793 = (_argc783 > 4 ? _rest784[0] : V.Undef);
inside_794 = (_argc783 > 5 ? _rest784[1] : V.Undef);
c_795 = Invoke(C_66, "get", id_789);
if (!(Truthy(c_795))) {
return default;
}
Call(stop_75, V.Undef, c_795);
Set(c_795, "held", V.Null);
Set(c_795, "sway", V.Null);
Call(play_83, V.Undef, c_795, ((V)("idle")));
if (Truthy(inside_794)) {
Object_assign(c_795, NewObj(5).Put("x", Get(to_791, "x")).Put("y", Get(to_791, "y")).Put("s", Get(to_791, "s")).Put("z", ((V)(10D))).Put("o", ((V)(1D))).V);
Call(start_74, V.Undef, c_795, NewObj(4).Put("kind", ((V)("tumble"))).Put("dur", ((V)(140D))).Put("prio", ((V)(1D))).Put("run", Fn((V _self798, int _argc799, V c_805, V t_806, V _a803, V _a804, V[] _rest800) => {
if (_self798.IsNullish) _self798 = GlobalV;
return NewObj(1).Put("o", ((V)((ToNum(t_806) / 140D)))).V;
return default;
}, 2, "run", false)).V);
return default;
}
Object_assign(c_795, NewObj(5).Put("x", Get(from_790, "x")).Put("y", Get(from_790, "y")).Put("s", Get(from_790, "s")).Put("z", ((V)(30D))).Put("o", ((V)(1D))).V);
D_796 = 560D;
up_797 = 230D;
Call(start_74, V.Undef, c_795, NewObj(7).Put("kind", ((V)("tumble"))).Put("delay", delay_792).Put("dur", ((V)(D_796))).Put("prio", ((V)(1D))).Put("before", NewObj(1).Put("o", ((V)(0D))).V).Put("run", Fn((V _self807, int _argc808, V c_814, V t_815, V _a812, V _a813, V[] _rest809) => {
double u_816 = 0;
V fall_817 = default;
if (_self807.IsNullish) _self807 = GlobalV;
u_816 = (ToNum(t_815) / D_796);
Set(c_814, "x", Call(lerp_50, V.Undef, Get(from_790, "x"), Get(to_791, "x"), Call(outQ_52, V.Undef, ((V)(u_816)))));
Set(c_814, "y", (LtN(t_815, up_797) ? Call(lerp_50, V.Undef, Get(from_790, "y"), peak_793, Call(outQ_52, V.Undef, ((V)((ToNum(t_815) / up_797))))) : Call(lerp_50, V.Undef, peak_793, Get(to_791, "y"), Call(bounce_54, V.Undef, ((V)(((ToNum(t_815) - up_797) / (D_796 - up_797))))))));
Set(c_814, "s", Call(lerp_50, V.Undef, Get(from_790, "s"), Get(to_791, "s"), ((V)(u_816))));
fall_817 = (LtN(t_815, up_797) ? ((V)(1D)) : Call(clamp_49, V.Undef, ((V)((1D - ((ToNum(t_815) - up_797) / 160D)))), ((V)(0D)), ((V)(1D))));
return NewObj(3).Put("o", Call(clamp_49, V.Undef, ((V)((ToNum(t_815) / 90D))), ((V)(0D)), ((V)(1D)))).Put("body", NewObj(2).Put("sq", ((V)(((-0.2) * ToNum(fall_817))))).Put("tilt", ((V)(((9D * ToNum(fall_817)) * FdLibm.Sin((ToNum(t_815) / 45D)))))).V).Put("ext", NewObj(4).Put("armL", ((V)((44D * ToNum(fall_817))))).Put("armR", ((V)((44D * ToNum(fall_817))))).Put("wide", fall_817).Put("open", ((V)((0.5 * ToNum(fall_817))))).V).V;
return default;
}, 2, "run", false)).Put("done", Fn((V _self818, int _argc819, V _a821, V _a822, V _a823, V _a824, V[] _rest820) => {
if (_self818.IsNullish) _self818 = GlobalV;
Set(c_795, "x", Get(to_791, "x"));
Set(c_795, "y", Get(to_791, "y"));
Set(c_795, "s", Get(to_791, "s"));
Set(c_795, "z", ((V)(10D)));
Call(land_77, V.Undef, c_795, ((V)(0.26)), (true ? V.True : V.False));
return default;
}, 0, "done", false)).V);
return default;
}, 6, "tumble", false)).Put("hold", Fn((V _self825, int _argc826, V id_832, V mode_833, V _a830, V _a831, V[] _rest827) => {
V c_834 = default;
V h_835 = default;
if (_self825.IsNullish) _self825 = GlobalV;
c_834 = Invoke(C_66, "get", id_832);
if (!(Truthy(c_834))) {
return default;
}
if (!(Truthy(mode_833))) {
if (!(Truthy(Get(c_834, "held")))) {
return default;
}
Set(Get(c_834, "held"), "rel", Invoke(G("performance"), "now"));
Set(c_834, "held", V.Null);
Invoke(Get(Get(c_834, "el"), "classList"), "remove", ((V)("air")));
Call(play_83, V.Undef, c_834, ((V)("idle")));
Call(kick_93, V.Undef);
return default;
}
Call(stop_75, V.Undef, c_834, Invoke(TRAVEL_76, "concat", ((V)("held"))));
Set(c_834, "sway", V.Null);
Set(c_834, "vx", ((V)(0D)));
Set(c_834, "vy", ((V)(0D)));
if (SEqS(mode_833, "drag")) {
Invoke(Get(Get(c_834, "el"), "classList"), "add", ((V)("air")));
} else {
Invoke(Get(Get(c_834, "el"), "classList"), "remove", ((V)("air")));
}
Call(play_83, V.Undef, c_834, ((V)("sortHeld")));
h_835 = NewObj(2).Put("mode", mode_833).Put("rel", ((V)(0D))).V;
Set(c_834, "held", h_835);
Call(start_74, V.Undef, c_834, NewObj(4).Put("kind", ((V)("held"))).Put("dur", ((V)(1000000000D))).Put("prio", ((V)(3D))).Put("run", Fn((V _self836, int _argc837, V c_843, V t_844, V _a841, V _a842, V[] _rest838) => {
V now_845 = default;
V env_846 = default;
V drag_847 = default;
double w_848 = 0;
V pop_849 = default;
double wig_850 = 0;
V sway_851 = default;
double lift_852 = 0;
double kick_853 = 0;
if (_self836.IsNullish) _self836 = GlobalV;
now_845 = Invoke(G("performance"), "now");
env_846 = (Truthy(Get(h_835, "rel")) ? ((V)((1D - ToNum(Call(clamp_49, V.Undef, ((V)(((ToNum(now_845) - ToNum(Get(h_835, "rel"))) / 160D))), ((V)(0D)), ((V)(1D))))))) : Call(clamp_49, V.Undef, ((V)((ToNum(t_844) / 110D))), ((V)(0D)), ((V)(1D))));
if (Truthy((Get(h_835, "rel") is var _t854 && !Truthy(_t854) ? _t854 : (LeN(env_846, 0D) ? V.True : V.False)))) {
Set(_self836, "fin", (true ? V.True : V.False));
return NewObj(0).V;
}
drag_847 = (SEqS(Get(h_835, "mode"), "drag") ? V.True : V.False);
w_848 = (ToNum(t_844) / 1000D);
pop_849 = Call(kv_56, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(90D)), ((V)((-0.36))), ((V)("o"))), Arr(((V)(220D)), ((V)((-0.18))), ((V)("io"))), Arr(((V)(340D)), ((V)((-0.24))), ((V)("io")))), ((V)(Min(ToNum(t_844), 340D))));
wig_850 = FdLibm.Sin((((w_848 * System.Math.PI) * 2D) * (Truthy(drag_847) ? 3.2 : 2.2)));
sway_851 = Call(clamp_49, V.Undef, ((V)(((-ToNum(Get(c_843, "vx"))) * 0.022))), ((V)((-16D))), ((V)(16D)));
lift_852 = (Truthy(drag_847) ? 5D : (6D + (2D * FdLibm.Sin((((w_848 * System.Math.PI) * 2D) * 1.2)))));
kick_853 = (Truthy(drag_847) ? FdLibm.Sin((((w_848 * System.Math.PI) * 2D) * 3.2)) : 0D);
return NewObj(2).Put("z", ((V)(60D))).Put("ext", NewObj(11).Put("lift", Call(toU_73, V.Undef, c_843, ((V)((lift_852 * ToNum(env_846)))))).Put("sq", ((V)((ToNum(Add(pop_849, ((V)(((Truthy(drag_847) ? 0.04 : 0.03) * FdLibm.Sin((((w_848 * System.Math.PI) * 2D) * 4.4))))))) * ToNum(env_846))))).Put("tilt", ((V)((ToNum(Add(((V)(((Truthy(drag_847) ? 7D : 4D) * wig_850))), sway_851)) * ToNum(env_846))))).Put("lean", ((V)(((((Truthy(drag_847) ? 1.6 : 1D) * wig_850) + (ToNum(sway_851) * 0.12)) * ToNum(env_846))))).Put("x", ((V)((ToNum(Call(clamp_49, V.Undef, ((V)(((-ToNum(Get(c_843, "vx"))) * 0.004))), ((V)((-3D))), ((V)(3D)))) * ToNum(env_846))))).Put("armL", ((V)((((38D + (10D * wig_850)) - (ToNum(sway_851) * 0.8)) * ToNum(env_846))))).Put("armR", ((V)((((38D - (10D * wig_850)) - (ToNum(sway_851) * 0.8)) * ToNum(env_846))))).Put("earL", ((V)((((-ToNum(sway_851)) * 0.7) * ToNum(env_846))))).Put("earR", ((V)((((-ToNum(sway_851)) * 0.7) * ToNum(env_846))))).Put("footL", ((V)(((2.4 * Max(0D, kick_853)) * ToNum(env_846))))).Put("footR", ((V)(((2.4 * Max(0D, (-kick_853))) * ToNum(env_846))))).V).V;
return default;
}, 2, "run", false)).V);
return default;
}, 2, "hold", false)).Put("drag", Fn((V _self855, int _argc856, V id_862, V x_863, V y_864, V _a861, V[] _rest857) => {
V c_865 = default;
V now_866 = default;
double dt_867 = 0;
double vx_868 = 0;
double vy_869 = 0;
if (_self855.IsNullish) _self855 = GlobalV;
c_865 = Invoke(C_66, "get", id_862);
if (!(Truthy(c_865))) {
return default;
}
now_866 = Invoke(G("performance"), "now");
dt_867 = Max(8D, (ToNum(now_866) - ToNum((Get(c_865, "dragAt") is var _t870 && Truthy(_t870) ? _t870 : ((V)((ToNum(now_866) - 16D)))))));
vx_868 = (((ToNum(x_863) - ToNum(Get(c_865, "x"))) / dt_867) * 1000D);
vy_869 = (((ToNum(y_864) - ToNum(Get(c_865, "y"))) / dt_867) * 1000D);
Set(c_865, "vx", Call(lerp_50, V.Undef, Get(c_865, "vx"), Call(clamp_49, V.Undef, ((V)(vx_868)), ((V)((-2500D))), ((V)(2500D))), ((V)(0.35))));
Set(c_865, "vy", Call(lerp_50, V.Undef, Get(c_865, "vy"), Call(clamp_49, V.Undef, ((V)(vy_869)), ((V)((-2500D))), ((V)(2500D))), ((V)(0.35))));
Set(c_865, "dragAt", now_866);
Set(c_865, "x", x_863);
Set(c_865, "y", y_864);
Set(c_865, "s", ((V)(1D)));
Call(kick_93, V.Undef);
return default;
}, 3, "drag", false)).Put("go", Fn((V _self871, int _argc872, V id_878, V to_879, V o_880, V _a877, V[] _rest873) => {
V c_881 = default;
if (_self871.IsNullish) _self871 = GlobalV;
c_881 = Invoke(C_66, "get", id_878);
if (!(Truthy(c_881))) {
return default;
}
Call(stop_75, V.Undef, c_881, TRAVEL_76);
Call(letGo_82, V.Undef, c_881);
Set(c_881, "sway", V.Null);
Call(travel_78, V.Undef, c_881, to_879, (o_880 is var _t882 && Truthy(_t882) ? _t882 : NewObj(0).V));
return default;
}, 3, "go", false)).Put("correct", Fn((V _self883, int _argc884, V id_890, V to_891, V _a888, V _a889, V[] _rest885) => {
V c_892 = default;
double dist_893 = 0;
if (_self883.IsNullish) _self883 = GlobalV;
c_892 = Invoke(C_66, "get", id_890);
if (!(Truthy(c_892))) {
return default;
}
Call(stop_75, V.Undef, c_892, TRAVEL_76);
Call(letGo_82, V.Undef, c_892);
Set(c_892, "sway", V.Null);
dist_893 = Hypot((ToNum(Get(to_891, "x")) - ToNum(Get(c_892, "x"))), (ToNum(Get(to_891, "y")) - ToNum(Get(c_892, "y"))));
Call(travel_78, V.Undef, c_892, to_891, NewObj(5).Put("kind", ((V)("correct"))).Put("ms", Call(clamp_49, V.Undef, ((V)((170D + (dist_893 * 0.5)))), ((V)(200D)), ((V)(440D)))).Put("h", ((V)(Min((ToNum(Get(c_892, "P")) * 0.6), (dist_893 * 0.3))))).Put("back", (true ? V.True : V.False)).Put("land", (false ? V.True : V.False)).V, Fn((V _arrowThis900, int _argc894, V _a896, V _a897, V _a898, V _a899, V[] _rest895) => {
V sq_901 = default;
V lift_902 = default;
V arms_903 = default;
Call(play_83, V.Undef, c_892, ((V)("sortJoy")));
sq_901 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(50D)), ((V)(0.34)), ((V)("o"))), Arr(((V)(150D)), ((V)(0.3)), ((V)("io"))), Arr(((V)(200D)), ((V)((-0.3))), ((V)("o"))), Arr(((V)(380D)), ((V)((-0.12))), ((V)("io"))), Arr(((V)(520D)), ((V)(0.3)), ((V)("o"))), Arr(((V)(620D)), ((V)((-0.1))), ((V)("io"))), Arr(((V)(720D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))));
lift_902 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(170D)), ((V)(0D))), Arr(((V)(360D)), ((V)((ToNum(Get(c_892, "P")) * 0.34))), ((V)("o"))), Arr(((V)(520D)), ((V)(0D)), ((V)("i"))), Arr(((V)(800D)), ((V)(0D))));
arms_903 = Arr(Arr(((V)(0D)), ((V)((-12D)))), Arr(((V)(150D)), ((V)((-14D)))), Arr(((V)(220D)), ((V)(50D)), ((V)("o"))), Arr(((V)(480D)), ((V)(44D))), Arr(((V)(560D)), ((V)((-10D))), ((V)("o"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))));
Call(start_74, V.Undef, c_892, NewObj(3).Put("kind", ((V)("correct"))).Put("dur", ((V)(800D))).Put("run", Fn((V _self904, int _argc905, V c_911, V t_912, V _a909, V _a910, V[] _rest906) => {
V L_913 = default;
if (_self904.IsNullish) _self904 = GlobalV;
L_913 = Call(kv_56, V.Undef, lift_902, t_912);
return NewObj(1).Put("ext", NewObj(6).Put("sq", Call(kv_56, V.Undef, sq_901, t_912)).Put("lift", Call(toU_73, V.Undef, c_911, L_913)).Put("armL", Call(kv_56, V.Undef, arms_903, t_912)).Put("armR", Call(kv_56, V.Undef, arms_903, t_912)).Put("close", Call(kv_56, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(40D)), ((V)(0.7)), ((V)("o"))), Arr(((V)(160D)), ((V)(0.7))), Arr(((V)(220D)), ((V)(0D)), ((V)("o")))), t_912)).Put("tilt", Call(kv_56, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)(6D)), ((V)("io"))), Arr(((V)(420D)), ((V)((-6D))), ((V)("io"))), Arr(((V)(560D)), ((V)(0D)), ((V)("io")))), t_912)).V).V;
return default;
}, 2, "run", false)).V);
Call(glow_80, V.Undef, c_892, ((V)(1600D)));
Call(later_81, V.Undef, ((V)(240D)), Fn((V _arrowThis920, int _argc914, V _a916, V _a917, V _a918, V _a919, V[] _rest915) => {
return Call(burst_79, V.Undef, c_892, ((V)("sortSpark")), ((V)("head")), ((V)(7D)));
}, 0, "", true));
Call(later_81, V.Undef, ((V)(520D)), Fn((V _arrowThis927, int _argc921, V _a923, V _a924, V _a925, V _a926, V[] _rest922) => {
return Call(burst_79, V.Undef, c_892, ((V)("sortSpark")), ((V)("feet")), ((V)(5D)));
}, 0, "", true));
Call(later_81, V.Undef, ((V)(300D)), Fn((V _arrowThis934, int _argc928, V _a930, V _a931, V _a932, V _a933, V[] _rest929) => {
return Call(burst_79, V.Undef, c_892, ((V)("sortHeart")), ((V)("head")), ((V)(1D)));
}, 0, "", true));
return default;
}, 0, "", true));
return default;
}, 2, "correct", false)).Put("wrong", Fn((V _self935, int _argc936, V id_942, V at_943, V back_944, V _a941, V[] _rest937) => {
V c_945 = default;
V shake_946 = default;
if (_self935.IsNullish) _self935 = GlobalV;
c_945 = Invoke(C_66, "get", id_942);
if (!(Truthy(c_945))) {
return default;
}
Call(stop_75, V.Undef, c_945, TRAVEL_76);
Call(letGo_82, V.Undef, c_945);
Set(c_945, "sway", V.Null);
shake_946 = Fn((V _arrowThis953, int _argc947, V _a949, V _a950, V _a951, V _a952, V[] _rest948) => {
V no_954 = default;
Call(play_83, V.Undef, c_945, ((V)("sortNope")));
Call(burst_79, V.Undef, c_945, ((V)("sortSweat")), ((V)("temple")));
Call(later_81, V.Undef, ((V)(380D)), Fn((V _arrowThis961, int _argc955, V _a957, V _a958, V _a959, V _a960, V[] _rest956) => {
return Call(burst_79, V.Undef, c_945, ((V)("sortSweat")), ((V)("temple")));
}, 0, "", true));
no_954 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(70D)), ((V)(0.95)), ((V)("io"))), Arr(((V)(170D)), ((V)((-0.95))), ((V)("io"))), Arr(((V)(270D)), ((V)(0.85)), ((V)("io"))), Arr(((V)(370D)), ((V)((-0.65))), ((V)("io"))), Arr(((V)(460D)), ((V)(0.3)), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))));
Call(start_74, V.Undef, c_945, NewObj(4).Put("kind", ((V)("wrong"))).Put("dur", ((V)(560D))).Put("run", Fn((V _self962, int _argc963, V c_969, V t_970, V _a967, V _a968, V[] _rest964) => {
V n_971 = default;
if (_self962.IsNullish) _self962 = GlobalV;
n_971 = Call(kv_56, V.Undef, no_954, t_970);
return NewObj(1).Put("ext", NewObj(5).Put("turn", n_971).Put("lx", n_971).Put("htilt", ((V)((ToNum(n_971) * 5D)))).Put("sq", Call(kv_56, V.Undef, Arr(Arr(((V)(0D)), ((V)(0.2))), Arr(((V)(80D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(560D)), ((V)(0.04)))), t_970)).Spread(Call(AR_57, V.Undef, Call(kv_56, V.Undef, Arr(Arr(((V)(0D)), ((V)((-6D)))), Arr(((V)(120D)), ((V)((-14D))), ((V)("io"))), Arr(((V)(560D)), ((V)((-12D))))), t_970))).V).V;
return default;
}, 2, "run", false)).Put("done", Fn((V _self972, int _argc973, V _a975, V _a976, V _a977, V _a978, V[] _rest974) => {
if (_self972.IsNullish) _self972 = GlobalV;
Call(travel_78, V.Undef, c_945, back_944, NewObj(4).Put("kind", ((V)("wrong"))).Put("ms", ((V)(460D))).Put("h", ((V)((ToNum(Get(c_945, "P")) * 0.75)))).Put("land", ((V)(0.34))).V, Fn((V _arrowThis985, int _argc979, V _a981, V _a982, V _a983, V _a984, V[] _rest980) => {
Call(burst_79, V.Undef, c_945, ((V)("sortSweat")), ((V)("temple")));
Call(glow_80, V.Undef, c_945, ((V)(1000D)));
return default;
}, 0, "", true));
return default;
}, 0, "done", false)).V);
return default;
}, 0, "", true);
Call(glow_80, V.Undef, c_945, ((V)(2400D)));
if ((Hypot((ToNum(Get(at_943, "x")) - ToNum(Get(c_945, "x"))), (ToNum(Get(at_943, "y")) - ToNum(Get(c_945, "y")))) > 3D)) {
Call(travel_78, V.Undef, c_945, at_943, NewObj(4).Put("kind", ((V)("wrong"))).Put("ms", ((V)(200D))).Put("h", ((V)(10D))).Put("land", (false ? V.True : V.False)).V, shake_946);
} else {
Call(shake_946, V.Undef);
}
return default;
}, 3, "wrong", false)).Put("caught", Fn((V _self986, int _argc987, V id_993, V dir_994, V delay_995, V _a992, V[] _rest988) => {
V c_996 = default;
double J_997 = 0;
double D_998 = 0;
V from_999 = default;
V W_1000 = default;
double off_1001 = 0;
V up_1002 = default;
if (_self986.IsNullish) _self986 = GlobalV;
c_996 = Invoke(C_66, "get", id_993);
if (!(Truthy(c_996))) {
return default;
}
Call(stop_75, V.Undef, c_996, TRAVEL_76);
Call(letGo_82, V.Undef, c_996);
Set(c_996, "sway", V.Null);
Call(later_81, V.Undef, (delay_995 is var _t1003 && Truthy(_t1003) ? _t1003 : ((V)(0D))), Fn((V _arrowThis1010, int _argc1004, V _a1006, V _a1007, V _a1008, V _a1009, V[] _rest1005) => {
Call(play_83, V.Undef, c_996, ((V)("sortCaught")));
Call(burst_79, V.Undef, c_996, ((V)("sortSweat")), ((V)("temple")));
Call(later_81, V.Undef, ((V)(160D)), Fn((V _arrowThis1017, int _argc1011, V _a1013, V _a1014, V _a1015, V _a1016, V[] _rest1012) => {
return Call(burst_79, V.Undef, c_996, ((V)("sortSweat")), ((V)("temple")));
}, 0, "", true));
return default;
}, 0, "", true));
J_997 = 420D;
D_998 = 1150D;
from_999 = NewObj(2).Put("x", Get(c_996, "x")).Put("y", Get(c_996, "y")).V;
W_1000 = Get(window_39, "innerWidth");
off_1001 = (LtN(dir_994, 0D) ? (((-ToNum(Get(c_996, "P"))) * 1.6) - ToNum(Get(from_999, "x"))) : ((ToNum(W_1000) - ToNum(Get(from_999, "x"))) + (ToNum(Get(c_996, "P")) * 0.6)));
up_1002 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(70D)), ((V)(0D))), Arr(((V)((J_997 * 0.55))), ((V)((ToNum(Get(c_996, "P")) * 0.5))), ((V)("o"))), Arr(((V)(J_997)), ((V)((ToNum(Get(c_996, "P")) * 0.38))), ((V)("io"))), Arr(((V)(D_998)), ((V)((ToNum(Get(c_996, "P")) * 0.38)))));
Call(start_74, V.Undef, c_996, NewObj(5).Put("kind", ((V)("caught"))).Put("delay", delay_995).Put("dur", ((V)(D_998))).Put("run", Fn((V _self1018, int _argc1019, V c_1025, V t_1026, V _a1023, V _a1024, V[] _rest1020) => {
V lift_1027 = default;
V away_1028 = default;
if (_self1018.IsNullish) _self1018 = GlobalV;
lift_1027 = Call(kv_56, V.Undef, up_1002, t_1026);
away_1028 = (LtN(t_1026, (J_997 * 0.75)) ? ((V)(0D)) : Call(SM_51, V.Undef, ((V)(((ToNum(t_1026) - (J_997 * 0.75)) / (D_998 - (J_997 * 0.75)))))));
Set(c_1025, "x", Add(Get(from_999, "x"), ((V)((off_1001 * ToNum(away_1028))))));
Set(c_1025, "y", ((V)((ToNum(Get(from_999, "y")) - ((ToNum(Get(c_1025, "P")) * 0.9) * FdLibm.Sin(((ToNum(away_1028) * System.Math.PI) * 0.6)))))));
return NewObj(4).Put("z", ((V)(70D))).Put("k", Call(lerp_50, V.Undef, ((V)(1D)), ((V)(0.45)), away_1028)).Put("o", ((V)((LtN(away_1028, 0.7) ? 1D : (1D - ((ToNum(away_1028) - 0.7) / 0.3)))))).Put("ext", NewObj(6).Put("lift", Call(toU_73, V.Undef, c_1025, lift_1027)).Put("sq", Call(kv_56, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(60D)), ((V)(0.3)), ((V)("o"))), Arr(((V)(140D)), ((V)((-0.34))), ((V)("o"))), Arr(((V)(J_997)), ((V)((-0.2))), ((V)("io"))), Arr(((V)(D_998)), ((V)((-0.1))))), t_1026)).Spread(Call(AR_57, V.Undef, Call(kv_56, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)(52D)), ((V)("o"))), Arr(((V)(J_997)), ((V)(46D))), Arr(((V)(D_998)), ((V)(40D)))), t_1026))).Put("wide", ((V)(1D))).Put("spin", Call(kv_56, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((J_997 * 0.8))), ((V)(0D))), Arr(((V)(D_998)), ((V)((ToNum(dir_994) * 900D))), ((V)("i")))), t_1026)).Put("tilt", Call(kv_56, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((J_997 * 0.8))), ((V)(0D))), Arr(((V)(D_998)), ((V)((ToNum(dir_994) * 40D))), ((V)("i")))), t_1026)).V).V;
return default;
}, 2, "run", false)).Put("done", Fn((V _self1029, int _argc1030, V _a1032, V _a1033, V _a1034, V _a1035, V[] _rest1031) => {
if (_self1029.IsNullish) _self1029 = GlobalV;
Set(c_996, "o", ((V)(0D)));
return default;
}, 0, "done", false)).V);
return default;
}, 3, "caught", false)).Put("huh", Fn((V _self1036, int _argc1037, V id_1043, V _a1040, V _a1041, V _a1042, V[] _rest1038) => {
V c_1044 = default;
if (_self1036.IsNullish) _self1036 = GlobalV;
c_1044 = Invoke(C_66, "get", id_1043);
if (Truthy((((!(Truthy(c_1044)) ? V.True : V.False) is var _t1045 && Truthy(_t1045) ? _t1045 : Get(c_1044, "held")) is var _t1046 && Truthy(_t1046) ? _t1046 : Get(Get(c_1044, "moves"), "length")))) {
return default;
}
Call(play_83, V.Undef, c_1044, ((V)("sortHuh")));
Call(start_74, V.Undef, c_1044, NewObj(3).Put("kind", ((V)("huh"))).Put("dur", ((V)(1700D))).Put("run", Fn((V _self1047, int _argc1048, V _a1050, V _a1051, V _a1052, V _a1053, V[] _rest1049) => {
if (_self1047.IsNullish) _self1047 = GlobalV;
return NewObj(0).V;
return default;
}, 0, "run", false)).V);
return default;
}, 1, "huh", false)).Put("win", Fn((V _self1054, int _argc1055, V list_1061, V doors_1062, V _a1059, V _a1060, V[] _rest1056) => {
V now_1063 = default;
if (_self1054.IsNullish) _self1054 = GlobalV;
now_1063 = Invoke(G("performance"), "now");
{
foreach (V _k1064 in new JsIter(list_1061)) {
V it0_1065 = default;
it0_1065 = _k1064;
V c_1066 = default;
V rem_1067 = default;
V it_1068 = default;
double D_1069 = 0;
double h_1070 = 0;
V sq_1071 = default;
V lift_1072 = default;
V wave_1073 = default;
c_1066 = Invoke(C_66, "get", Get(it0_1065, "id"));
if (!(Truthy(c_1066))) {
continue;
}
Call(letGo_82, V.Undef, c_1066);
Set(c_1066, "sway", V.Null);
rem_1067 = Invoke(Invoke(Get(c_1066, "moves"), "filter", Fn((V _arrowThis1090, int _argc1083, V m_1089, V _a1086, V _a1087, V _a1088, V[] _rest1084) => {
return (((!(Truthy(Get(m_1089, "dead"))) && LtN(Get(m_1089, "dur"), 100000000D)) && !SEqS(Get(m_1089, "kind"), "glow")) ? V.True : V.False);
}, 1, "", true)), "reduce", Fn((V _arrowThis1082, int _argc1074, V a_1080, V m_1081, V _a1078, V _a1079, V[] _rest1075) => {
return ((V)(Max(ToNum(a_1080), (ToNum(Add(Get(m_1081, "t0"), Get(m_1081, "dur"))) - ToNum(now_1063)))));
}, 2, "", true), ((V)(0D)));
it_1068 = NewObj(2).Put("id", Get(it0_1065, "id")).Put("delay", ((V)(Max(ToNum(Get(it0_1065, "delay")), ToNum(rem_1067))))).V;
Call(later_81, V.Undef, Get(it_1068, "delay"), Fn((V _arrowThis1097, int _argc1091, V _a1093, V _a1094, V _a1095, V _a1096, V[] _rest1092) => {
return Call(play_83, V.Undef, c_1066, ((V)("sortJoy")));
}, 0, "", true));
D_1069 = 760D;
h_1070 = (ToNum(Get(c_1066, "P")) * 0.42);
sq_1071 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(70D)), ((V)(0.26)), ((V)("o"))), Arr(((V)(150D)), ((V)((-0.32))), ((V)("o"))), Arr(((V)(330D)), ((V)((-0.12))), ((V)("io"))), Arr(((V)(420D)), ((V)(0.3)), ((V)("o"))), Arr(((V)(480D)), ((V)((-0.1))), ((V)("io"))), Arr(((V)(600D)), ((V)(0.18)), ((V)("o"))), Arr(((V)(680D)), ((V)((-0.05))), ((V)("io"))), Arr(((V)(D_1069)), ((V)(0D)), ((V)("io"))));
lift_1072 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(80D)), ((V)(0D))), Arr(((V)(250D)), ((V)(h_1070)), ((V)("o"))), Arr(((V)(420D)), ((V)(0D)), ((V)("i"))), Arr(((V)(480D)), ((V)(0D))), Arr(((V)(540D)), ((V)((h_1070 * 0.3))), ((V)("o"))), Arr(((V)(600D)), ((V)(0D)), ((V)("i"))), Arr(((V)(D_1069)), ((V)(0D))));
wave_1073 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(90D)), ((V)(54D)), ((V)("o"))), Arr(((V)(200D)), ((V)(40D)), ((V)("io"))), Arr(((V)(300D)), ((V)(56D)), ((V)("io"))), Arr(((V)(420D)), ((V)(30D)), ((V)("io"))), Arr(((V)(D_1069)), ((V)(0D)), ((V)("io"))));
Call(start_74, V.Undef, c_1066, NewObj(5).Put("kind", ((V)("win"))).Put("delay", Get(it_1068, "delay")).Put("dur", ((V)(D_1069))).Put("prio", ((V)(1D))).Put("run", Fn((V _self1098, int _argc1099, V c_1105, V t_1106, V _a1103, V _a1104, V[] _rest1100) => {
V wv_1107 = default;
if (_self1098.IsNullish) _self1098 = GlobalV;
wv_1107 = Call(kv_56, V.Undef, wave_1073, t_1106);
return NewObj(2).Put("body", NewObj(3).Put("sq", Call(kv_56, V.Undef, sq_1071, t_1106)).Put("lift", Call(kv_56, V.Undef, lift_1072, t_1106)).Put("tilt", Call(kv_56, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)((-5D))), ((V)("io"))), Arr(((V)(330D)), ((V)(5D)), ((V)("io"))), Arr(((V)(480D)), ((V)(0D)), ((V)("io")))), t_1106)).V).Put("ext", NewObj(2).Put("armL", wv_1107).Put("armR", ((V)((ToNum(wv_1107) * 0.85)))).V).V;
return default;
}, 2, "run", false)).V);
}
}
if (Truthy(doors_1062)) {
shut_84 = NewObj(6).Put("t0", Add(Invoke(G("performance"), "now"), (Get(doors_1062, "delay") is var _t1108 && Truthy(_t1108) ? _t1108 : ((V)(0D))))).Put("ms", Get(doors_1062, "ms")).Put("deg", Get(doors_1062, "deg")).Put("persp", Get(doors_1062, "persp")).Put("list", Get(doors_1062, "list")).Put("lead", (Get(doors_1062, "lead") is var _t1109 && Truthy(_t1109) ? _t1109 : ((V)(3D)))).V;
Call(kick_93, V.Undef);
}
return default;
}, 2, "win", false)).Put("unshut", Fn((V _self1110, int _argc1111, V _a1113, V _a1114, V _a1115, V _a1116, V[] _rest1112) => {
if (_self1110.IsNullish) _self1110 = GlobalV;
shut_84 = V.Null;
Set(Get(board_48, "style"), "clipPath", ((V)("")));
return default;
}, 0, "unshut", false)).Put("lose", Fn((V _self1117, int _argc1118, V list_1124, V _a1121, V _a1122, V _a1123, V[] _rest1119) => {
if (_self1117.IsNullish) _self1117 = GlobalV;
{
foreach (V _k1125 in new JsIter(list_1124)) {
V it_1126 = default;
it_1126 = _k1125;
V c_1127 = default;
c_1127 = Invoke(C_66, "get", Get(it_1126, "id"));
if (!(Truthy(c_1127))) {
continue;
}
Call(letGo_82, V.Undef, c_1127);
Call(later_81, V.Undef, Get(it_1126, "delay"), Fn((V _arrowThis1134, int _argc1128, V _a1130, V _a1131, V _a1132, V _a1133, V[] _rest1129) => {
Call(stop_75, V.Undef, c_1127, Arr(((V)("huh"))));
Call(play_83, V.Undef, c_1127, ((V)("sortDroop")));
Call(start_74, V.Undef, c_1127, NewObj(4).Put("kind", ((V)("sad"))).Put("dur", ((V)(1100D))).Put("prio", ((V)(1D))).Put("run", Fn((V _self1135, int _argc1136, V _a1138, V _a1139, V _a1140, V _a1141, V[] _rest1137) => {
if (_self1135.IsNullish) _self1135 = GlobalV;
return NewObj(0).V;
return default;
}, 0, "run", false)).V);
Set(c_1127, "sway", NewObj(2).Put("t0", Add(Invoke(G("performance"), "now"), ((V)(700D)))).Put("ph", ((V)(((ToNum(Invoke(G("Math"), "random")) * System.Math.PI) * 2D)))).V);
Call(later_81, V.Undef, ((V)(800D)), Fn((V _arrowThis1148, int _argc1142, V _a1144, V _a1145, V _a1146, V _a1147, V[] _rest1143) => {
Call(burst_79, V.Undef, c_1127, ((V)("sortTear")), ((V)("eyeL")));
Call(glow_80, V.Undef, c_1127, ((V)(1200D)));
return default;
}, 0, "", true));
return default;
}, 0, "", true));
}
}
return default;
}, 1, "lose", false)).Put("pause", Fn((V _self1149, int _argc1150, V on_1156, V _a1153, V _a1154, V _a1155, V[] _rest1151) => {
if (_self1149.IsNullish) _self1149 = GlobalV;
userPaused_89 = (!(!(Truthy(on_1156))) ? V.True : V.False);
Call(sync_91, V.Undef);
return default;
}, 1, "pause", false)).V;
running_88 = (false ? V.True : V.False);
userPaused_89 = (false ? V.True : V.False);
sleeping_90 = (false ? V.True : V.False);
sync_91 = Fn((V _arrowThis1163, int _argc1157, V _a1159, V _a1160, V _a1161, V _a1162, V[] _rest1158) => {
return Invoke(window_39, "__rigPause", (userPaused_89 is var _t1164 && Truthy(_t1164) ? _t1164 : sleeping_90));
}, 0, "", true);
Set(window_39, "sortStage", api_87);
Set(api_87, "_C", C_66);
Set(api_87, "_state", Fn((V _arrowThis1171, int _argc1165, V _a1167, V _a1168, V _a1169, V _a1170, V[] _rest1166) => {
return NewObj(3).Put("sleeping", sleeping_90).Put("userPaused", userPaused_89).Put("drawn", Invoke(Invoke(new ArrBuilder().Spread(Invoke(C_66, "values")).V, "filter", Fn((V _arrowThis1187, int _argc1180, V c_1186, V _a1183, V _a1184, V _a1185, V[] _rest1181) => {
return (Get(c_1186, "I") is var _t1188 && !Truthy(_t1188) ? _t1188 : Get(Get(c_1186, "I"), "ready"));
}, 1, "", true)), "map", Fn((V _arrowThis1179, int _argc1172, V c_1178, V _a1175, V _a1176, V _a1177, V[] _rest1173) => {
return Get(c_1178, "id");
}, 1, "", true))).V;
}, 0, "", true));
boot_94 = Fn((V _arrowThis1195, int _argc1189, V _a1191, V _a1192, V _a1193, V _a1194, V[] _rest1190) => {
V R_1196 = default;
R_1196 = Get(window_39, "RiveRig");
if (Truthy((((((R_1196 is var _t1197 && !Truthy(_t1197) ? _t1197 : Get(R_1196, "REST")) is var _t1198 && !Truthy(_t1198) ? _t1198 : Get(R_1196, "DEFS")) is var _t1199 && !Truthy(_t1199) ? _t1199 : Get(Get(R_1196, "DEFS"), "prickle")) is var _t1200 && !Truthy(_t1200) ? _t1200 : Get(R_1196, "movesV")) is var _t1201 && !Truthy(_t1201) ? _t1201 : Get(window_39, "RiveGeneric")))) {
kv_56 = Get(R_1196, "kv");
Call(addStates_65, V.Undef);
Call(post_47, V.Undef, NewObj(1).Put("type", ((V)("ready"))).V);
} else {
Call(G("setTimeout"), V.Undef, boot_94, ((V)(25D)));
}
return default;
}, 0, "", true);
Call(boot_94, V.Undef);
Set(window_39, "onerror", Fn((V _arrowThis1209, int _argc1202, V m_1208, V _a1205, V _a1206, V _a1207, V[] _rest1203) => {
return Call(post_47, V.Undef, NewObj(2).Put("type", ((V)("error"))).Put("message", ((V)(ToStrS(m_1208)))).V);
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
