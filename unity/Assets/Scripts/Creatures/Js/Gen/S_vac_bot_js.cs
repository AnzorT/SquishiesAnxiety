// vac-bot.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_vac_bot_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V B_8 = default;
V r1_9 = default;
V mk_10 = default;
V put_11 = default;
V face_12 = default;
V dust_13 = default;
V go_14 = default;
V wander_15 = default;
V kill_16 = default;
V start_17 = default;
V stop_18 = default;
if (_self1.IsNullish) _self1 = GlobalV;
mk_10 = Fn((V _self19, int _argc20, V o_26, V _a23, V _a24, V _a25, V[] _rest21) => {
V d_27 = default;
V w_28 = default;
V im_29 = default;
if (_self19.IsNullish) _self19 = GlobalV;
d_27 = Invoke(G("document"), "createElement", ((V)("div")));
Set(Get(d_27, "style"), "cssText", ((V)("position:absolute;left:0;top:0;width:0;height:0;pointer-events:none;transform-origin:0 0")));
w_28 = Invoke(G("document"), "createElement", ((V)("div")));
Set(Get(w_28, "style"), "cssText", ((V)("position:absolute;left:0;top:0;width:0;height:0;transform-origin:0 0")));
im_29 = Invoke(G("document"), "createElement", ((V)("img")));
Set(im_29, "src", Get(o_26, "src"));
Set(im_29, "alt", ((V)("")));
Set(im_29, "draggable", (false ? V.True : V.False));
Set(Get(im_29, "style"), "cssText", ((V)(JsStrBuf.Begin().S("position:absolute;max-width:none;left:").V(GetIdx(Get(o_26, "bb"), 0D)).S("px;top:").V(GetIdx(Get(o_26, "bb"), 1D)).S("px;width:").V(GetIdx(Get(o_26, "bb"), 2D)).S("px;height:").V(GetIdx(Get(o_26, "bb"), 3D)).S("px").End())));
Invoke(w_28, "appendChild", im_29);
Invoke(d_27, "appendChild", w_28);
return NewObj(3).Put("d", d_27).Put("w", w_28).Put("im", im_29).V;
return default;
}, 1, "mk", false);
put_11 = Fn((V _self30, int _argc31, V b_37, V x_38, V y_39, V _a36, V[] _rest32) => {
V s_40 = default;
if (_self30.IsNullish) _self30 = GlobalV;
Set(b_37, "x", x_38);
Set(b_37, "y", y_39);
s_40 = Invoke(Get(b_37, "o"), "sAt", y_39);
Set(Get(Get(Get(b_37, "E"), "d"), "style"), "left", ((V)(JsStrBuf.Begin().V(Call(r1_9, V.Undef, x_38)).S("px").End())));
Set(Get(Get(Get(b_37, "E"), "d"), "style"), "top", ((V)(JsStrBuf.Begin().V(Call(r1_9, V.Undef, y_39)).S("px").End())));
Set(Get(Get(Get(b_37, "E"), "d"), "style"), "transform", ((V)(JsStrBuf.Begin().S("scale(").V(Invoke(s_40, "toFixed", ((V)(3D)))).S(")").End())));
Set(Get(Get(Get(b_37, "E"), "d"), "style"), "zIndex", ((V)(ToStrS(Invoke(Get(b_37, "o"), "z", y_39)))));
return default;
}, 3, "put", false);
face_12 = Fn((V _self41, int _argc42, V b_48, V dx_49, V _a46, V _a47, V[] _rest43) => {
double f_50 = 0;
if (_self41.IsNullish) _self41 = GlobalV;
if ((System.Math.Abs(ToNum(dx_49)) < 3D)) {
return default;
}
f_50 = (LtN(dx_49, 0D) ? (-1D) : 1D);
if (SEqN(Get(b_48, "f"), f_50)) {
return default;
}
Set(b_48, "f", ((V)(f_50)));
Invoke(Get(Get(b_48, "E"), "w"), "animate", Arr(NewObj(1).Put("transform", ((V)("rotate(0deg)"))).V, NewObj(1).Put("transform", ((V)(JsStrBuf.Begin().S("rotate(").N((f_50 * 7D)).S("deg) translateY(-1px)").End()))).V, NewObj(1).Put("transform", ((V)(JsStrBuf.Begin().S("rotate(").N(((-f_50) * 3D)).S("deg)").End()))).V, NewObj(1).Put("transform", ((V)("rotate(0deg)"))).V), NewObj(2).Put("duration", ((V)(420D))).Put("easing", ((V)("ease-out"))).V);
return default;
}, 2, "face", false);
dust_13 = Fn((V _self51, int _argc52, V b_58, V _a55, V _a56, V _a57, V[] _rest53) => {
V h_59 = default;
V cs_60 = default;
double x_61 = 0;
double y_62 = 0;
V s_63 = default;
V e_64 = default;
double sz_65 = 0;
V a_66 = default;
if (_self51.IsNullish) _self51 = GlobalV;
h_59 = Get(Get(b_58, "o"), "host");
if ((!(Truthy(h_59)) || !(Truthy(Get(Get(Get(b_58, "E"), "d"), "isConnected"))))) {
return default;
}
cs_60 = Call(G("getComputedStyle"), V.Undef, Get(Get(b_58, "E"), "d"));
x_61 = ParseFloat(Get(cs_60, "left"));
y_62 = ParseFloat(Get(cs_60, "top"));
s_63 = Invoke(Get(b_58, "o"), "sAt", ((V)(y_62)));
e_64 = Invoke(G("document"), "createElement", ((V)("div")));
sz_65 = ((9D * ToNum(s_63)) * ToNum((Get(Get(b_58, "o"), "k") is var _t67 && Truthy(_t67) ? _t67 : ((V)(1D)))));
Set(Get(e_64, "style"), "cssText", ((V)(JsStrBuf.Begin().S("position:absolute;pointer-events:none;left:").V(Call(r1_9, V.Undef, ((V)(((x_61 - (sz_65 / 2D)) + (((ToNum(Invoke(G("Math"), "random")) - 0.5) * 16D) * ToNum(s_63))))))).S("px;top:").V(Call(r1_9, V.Undef, ((V)(((y_62 - (sz_65 / 2D)) - (3D * ToNum(s_63))))))).S("px;width:").V(Call(r1_9, V.Undef, ((V)(sz_65)))).S("px;height:").V(Call(r1_9, V.Undef, ((V)(sz_65)))).S("px;z-index:").V(Invoke(Get(b_58, "o"), "z", ((V)((y_62 - 1D))))).S(";background:radial-gradient(circle,#ffffff 0,#ffffff 18%,rgba(223,246,255,0.7) 34%,rgba(223,246,255,0) 68%);clip-path:polygon(50% 0,61% 39%,100% 50%,61% 61%,50% 100%,39% 61%,0 50%,39% 39%)").End())));
Invoke(h_59, "appendChild", e_64);
a_66 = Invoke(e_64, "animate", Arr(NewObj(2).Put("opacity", ((V)(0D))).Put("transform", ((V)("scale(0.4)"))).V, NewObj(3).Put("opacity", ((V)(1D))).Put("transform", ((V)("scale(1.1)"))).Put("offset", ((V)(0.25))).V, NewObj(2).Put("opacity", ((V)(0D))).Put("transform", ((V)("scale(0.6) translateY(-6px)"))).V), NewObj(2).Put("duration", ((V)(1300D))).Put("easing", ((V)("ease-out"))).V);
Set(a_66, "onfinish", Fn((V _arrowThis74, int _argc68, V _a70, V _a71, V _a72, V _a73, V[] _rest69) => {
return Invoke(e_64, "remove");
}, 0, "", true));
return default;
}, 1, "dust", false);
go_14 = Fn((V _self75, int _argc76, V b_82, V p_83, V cb_84, V ms_85, V[] _rest77) => {
V x0_86 = default;
V y0_87 = default;
double dx_88 = 0;
double dy_89 = 0;
double dist_90 = 0;
V s0_91 = default;
V s1_92 = default;
V dur_93 = default;
if (_self75.IsNullish) _self75 = GlobalV;
if (Truthy(Get(b_82, "dead"))) {
return default;
}
x0_86 = Get(b_82, "x");
y0_87 = Get(b_82, "y");
dx_88 = (ToNum(Get(p_83, "x")) - ToNum(x0_86));
dy_89 = (ToNum(Get(p_83, "y")) - ToNum(y0_87));
dist_90 = Hypot(dx_88, dy_89);
s0_91 = Invoke(Get(b_82, "o"), "sAt", y0_87);
s1_92 = Invoke(Get(b_82, "o"), "sAt", Get(p_83, "y"));
Call(face_12, V.Undef, b_82, ((V)(dx_88)));
dur_93 = (ms_85 is var _t95 && Truthy(_t95) ? _t95 : ((V)(Max(350D, ((dist_90 / ToNum((Get(Get(b_82, "o"), "speed") is var _t94 && Truthy(_t94) ? _t94 : ((V)(42D))))) * 1000D)))));
Set(b_82, "an", Invoke(Get(Get(b_82, "E"), "d"), "animate", Arr(NewObj(4).Put("left", ((V)(JsStrBuf.Begin().V(Call(r1_9, V.Undef, x0_86)).S("px").End()))).Put("top", ((V)(JsStrBuf.Begin().V(Call(r1_9, V.Undef, y0_87)).S("px").End()))).Put("transform", ((V)(JsStrBuf.Begin().S("scale(").V(Invoke(s0_91, "toFixed", ((V)(3D)))).S(")").End()))).Put("zIndex", Invoke(Get(b_82, "o"), "z", y0_87)).V, NewObj(4).Put("left", ((V)(JsStrBuf.Begin().V(Call(r1_9, V.Undef, Get(p_83, "x"))).S("px").End()))).Put("top", ((V)(JsStrBuf.Begin().V(Call(r1_9, V.Undef, Get(p_83, "y"))).S("px").End()))).Put("transform", ((V)(JsStrBuf.Begin().S("scale(").V(Invoke(s1_92, "toFixed", ((V)(3D)))).S(")").End()))).Put("zIndex", Invoke(Get(b_82, "o"), "z", Get(p_83, "y"))).V), NewObj(3).Put("duration", dur_93).Put("easing", ((V)("cubic-bezier(.45,0,.55,1)"))).Put("fill", ((V)("forwards"))).V));
Set(Get(b_82, "an"), "onfinish", Fn((V _arrowThis102, int _argc96, V _a98, V _a99, V _a100, V _a101, V[] _rest97) => {
if (Truthy(Get(b_82, "dead"))) {
return default;
}
Set(b_82, "an", V.Null);
Call(put_11, V.Undef, b_82, Get(p_83, "x"), Get(p_83, "y"));
if (Truthy(cb_84)) {
Call(cb_84, V.Undef);
}
return default;
}, 0, "", true));
return default;
}, 4, "go", false);
wander_15 = Fn((V _self103, int _argc104, V b_110, V _a107, V _a108, V _a109, V[] _rest105) => {
V p_111 = default;
if (_self103.IsNullish) _self103 = GlobalV;
if (Truthy((Get(b_110, "dead") is var _t112 && Truthy(_t112) ? _t112 : (!SEqS(Get(b_110, "mode"), "out") ? V.True : V.False)))) {
return default;
}
p_111 = Invoke(Get(b_110, "o"), "spot");
if (!(Truthy(p_111))) {
Set(b_110, "tw", Call(G("setTimeout"), V.Undef, Fn((V _arrowThis126, int _argc120, V _a122, V _a123, V _a124, V _a125, V[] _rest121) => {
return Call(wander_15, V.Undef, b_110);
}, 0, "", true), ((V)(800D))));
return default;
}
Call(go_14, V.Undef, b_110, p_111, Fn((V _arrowThis133, int _argc127, V _a129, V _a130, V _a131, V _a132, V[] _rest128) => {
Set(b_110, "tw", Call(G("setTimeout"), V.Undef, Fn((V _arrowThis147, int _argc141, V _a143, V _a144, V _a145, V _a146, V[] _rest142) => {
return Call(wander_15, V.Undef, b_110);
}, 0, "", true), ((V)((250D + (ToNum(Invoke(G("Math"), "random")) * 700D))))));
return default;
}, 0, "", true));
return default;
}, 1, "wander", false);
kill_16 = Fn((V _self148, int _argc149, V key_155, V _a152, V _a153, V _a154, V[] _rest150) => {
V b_156 = default;
if (_self148.IsNullish) _self148 = GlobalV;
b_156 = Invoke(B_8, "get", key_155);
if (!(Truthy(b_156))) {
return default;
}
Set(b_156, "dead", (true ? V.True : V.False));
Call(G("clearTimeout"), V.Undef, Get(b_156, "tm"));
Call(G("clearTimeout"), V.Undef, Get(b_156, "tw"));
Call(G("clearInterval"), V.Undef, Get(b_156, "ti"));
if (Truthy(Get(b_156, "an"))) {
Invoke(Get(b_156, "an"), "cancel");
}
Invoke(Get(Get(b_156, "E"), "d"), "remove");
Invoke(B_8, "delete", key_155);
return default;
}, 1, "kill", false);
start_17 = Fn((V _self157, int _argc158, V key_164, V o_165, V _a162, V _a163, V[] _rest159) => {
V h_166 = default;
V b_167 = default;
if (_self157.IsNullish) _self157 = GlobalV;
if (Truthy(Invoke(B_8, "has", key_164))) {
return (false ? V.True : V.False);
}
h_166 = (Get(o_165, "home") is var _t168 && !Truthy(_t168) ? _t168 : Invoke(o_165, "home"));
if ((!(Truthy(h_166)) || !(Truthy(Get(o_165, "host"))))) {
return (false ? V.True : V.False);
}
b_167 = NewObj(6).Put("o", o_165).Put("E", Call(mk_10, V.Undef, o_165)).Put("mode", ((V)("out"))).Put("f", ((V)(1D))).Put("x", Get(h_166, "x")).Put("y", Get(h_166, "y")).V;
Invoke(B_8, "set", key_164, b_167);
Invoke(Get(o_165, "host"), "appendChild", Get(Get(b_167, "E"), "d"));
Call(put_11, V.Undef, b_167, Get(h_166, "x"), Get(h_166, "y"));
Invoke(Get(Get(b_167, "E"), "im"), "animate", Arr(NewObj(1).Put("transform", ((V)("rotate(-1.2deg)"))).V, NewObj(1).Put("transform", ((V)("rotate(1.2deg)"))).V), NewObj(4).Put("duration", ((V)(240D))).Put("direction", ((V)("alternate"))).Put("iterations", ((V)(double.PositiveInfinity))).Put("easing", ((V)("ease-in-out"))).V);
Set(b_167, "ti", Call(G("setInterval"), V.Undef, Fn((V _arrowThis182, int _argc176, V _a178, V _a179, V _a180, V _a181, V[] _rest177) => {
if (Truthy(Get(b_167, "an"))) {
Call(dust_13, V.Undef, b_167);
}
return default;
}, 0, "", true), ((V)(420D))));
Set(b_167, "tm", Call(G("setTimeout"), V.Undef, Fn((V _arrowThis197, int _argc191, V _a193, V _a194, V _a195, V _a196, V[] _rest192) => {
return Call(stop_18, V.Undef, key_164);
}, 0, "", true), (Get(o_165, "ms") is var _t198 && Truthy(_t198) ? _t198 : ((V)(300000D)))));
Call(go_14, V.Undef, b_167, NewObj(2).Put("x", Add(Get(h_166, "x"), (Truthy(Get(o_165, "out")) ? GetIdx(Get(o_165, "out"), 0D) : ((V)(0D))))).Put("y", Add(Get(h_166, "y"), (Truthy(Get(o_165, "out")) ? GetIdx(Get(o_165, "out"), 1D) : ((V)(34D))))).V, Fn((V _arrowThis205, int _argc199, V _a201, V _a202, V _a203, V _a204, V[] _rest200) => {
return Call(wander_15, V.Undef, b_167);
}, 0, "", true), ((V)(1100D)));
return (true ? V.True : V.False);
return default;
}, 2, "start", false);
stop_18 = Fn((V _self206, int _argc207, V key_213, V now_214, V _a211, V _a212, V[] _rest208) => {
V b_215 = default;
V h_216 = default;
V o_217 = default;
V ox_218 = default;
V oy_219 = default;
if (_self206.IsNullish) _self206 = GlobalV;
b_215 = Invoke(B_8, "get", key_213);
if (!(Truthy(b_215))) {
return default;
}
if (Truthy(now_214)) {
Call(kill_16, V.Undef, key_213);
return default;
}
if (SEqS(Get(b_215, "mode"), "back")) {
return default;
}
Set(b_215, "mode", ((V)("back")));
Call(G("clearTimeout"), V.Undef, Get(b_215, "tm"));
Call(G("clearTimeout"), V.Undef, Get(b_215, "tw"));
if (Truthy(Get(b_215, "an"))) {
V cs_220 = default;
double x_221 = 0;
double y_222 = 0;
cs_220 = Call(G("getComputedStyle"), V.Undef, Get(Get(b_215, "E"), "d"));
x_221 = ParseFloat(Get(cs_220, "left"));
y_222 = ParseFloat(Get(cs_220, "top"));
Invoke(Get(b_215, "an"), "cancel");
Set(b_215, "an", V.Null);
Call(put_11, V.Undef, b_215, ((V)(x_221)), ((V)(y_222)));
}
h_216 = (Get(Get(b_215, "o"), "home") is var _t223 && !Truthy(_t223) ? _t223 : Invoke(Get(b_215, "o"), "home"));
if (!(Truthy(h_216))) {
V cb_224 = default;
cb_224 = Get(Get(b_215, "o"), "onDone");
Call(kill_16, V.Undef, key_213);
if (Truthy(cb_224)) {
Call(cb_224, V.Undef);
}
return default;
}
o_217 = Get(b_215, "o");
ox_218 = (Truthy(Get(o_217, "out")) ? GetIdx(Get(o_217, "out"), 0D) : ((V)(0D)));
oy_219 = (Truthy(Get(o_217, "out")) ? GetIdx(Get(o_217, "out"), 1D) : ((V)(34D)));
Call(go_14, V.Undef, b_215, NewObj(2).Put("x", Add(Get(h_216, "x"), ox_218)).Put("y", Add(Get(h_216, "y"), oy_219)).V, Fn((V _arrowThis231, int _argc225, V _a227, V _a228, V _a229, V _a230, V[] _rest226) => {
V h2_232 = default;
h2_232 = (Invoke(o_217, "home") is var _t233 && Truthy(_t233) ? _t233 : h_216);
Call(go_14, V.Undef, b_215, h2_232, Fn((V _arrowThis240, int _argc234, V _a236, V _a237, V _a238, V _a239, V[] _rest235) => {
V cb_241 = default;
cb_241 = Get(o_217, "onDone");
if (Truthy(cb_241)) {
Call(cb_241, V.Undef);
}
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis255, int _argc249, V _a251, V _a252, V _a253, V _a254, V[] _rest250) => {
return Call(kill_16, V.Undef, key_213);
}, 0, "", true), ((V)(140D)));
return default;
}, 0, "", true), ((V)(1100D)));
return default;
}, 0, "", true));
return default;
}, 2, "stop", false);
if (Truthy(Get(G("window"), "VacBot"))) {
return default;
}
B_8 = New(G("Map"));
r1_9 = Fn((V _arrowThis263, int _argc256, V v_262, V _a259, V _a260, V _a261, V[] _rest257) => {
return ((V)((Round((ToNum(v_262) * 10D)) / 10D)));
}, 1, "", true);
Set(G("window"), "VacBot", NewObj(6).Put("start", start_17).Put("stop", stop_18).Put("isOn", Fn((V _arrowThis271, int _argc264, V k_270, V _a267, V _a268, V _a269, V[] _rest265) => {
return (Invoke(B_8, "has", k_270) is var _t272 && !Truthy(_t272) ? _t272 : (SEqS(Get(Invoke(B_8, "get", k_270), "mode"), "out") ? V.True : V.False));
}, 1, "isOn", true)).Put("busy", Fn((V _arrowThis280, int _argc273, V k_279, V _a276, V _a277, V _a278, V[] _rest274) => {
return Invoke(B_8, "has", k_279);
}, 1, "busy", true)).Put("stopAll", Fn((V _arrowThis288, int _argc281, V now_287, V _a284, V _a285, V _a286, V[] _rest282) => {
return Invoke(new ArrBuilder().Spread(Invoke(B_8, "keys")).V, "forEach", Fn((V _arrowThis296, int _argc289, V k_295, V _a292, V _a293, V _a294, V[] _rest290) => {
return (Truthy(now_287) ? Call(kill_16, V.Undef, k_295) : Call(stop_18, V.Undef, k_295));
}, 1, "", true));
}, 1, "stopAll", true)).Put("keys", Fn((V _arrowThis303, int _argc297, V _a299, V _a300, V _a301, V _a302, V[] _rest298) => {
return new ArrBuilder().Spread(Invoke(B_8, "keys")).V;
}, 0, "keys", true)).V);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
