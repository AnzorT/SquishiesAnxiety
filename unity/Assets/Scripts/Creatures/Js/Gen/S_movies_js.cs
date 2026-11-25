// movies.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_movies_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V cl_8 = default;
V lerp_9 = default;
V E_10 = default;
V P_11 = default;
V kf_12 = default;
V hop_13 = default;
V el_14 = default;
V art_15 = default;
V actor_16 = default;
V pose_17 = default;
V put_18 = default;
V show_19 = default;
V rnd_20 = default;
V mtof_21 = default;
V kit_22 = default;
V RCH_23 = default;
V RMEL_24 = default;
V rag_25 = default;
V sneak_26 = default;
V look_27 = default;
double FY_28 = 0;
double W_29 = 0;
V CARDS_30 = default;
V SCN_31 = default;
V cakeCaper_32 = default;
V cakeScore_33 = default;
V beatsOf_34 = default;
V list_35 = default;
V record_36 = default;
V def_37 = default;
if (_self1.IsNullish) _self1 = GlobalV;
el_14 = Fn((V _self38, int _argc39, V tag_45, V css_46, V parent_47, V html_48, V[] _rest40) => {
V n_49 = default;
if (_self38.IsNullish) _self38 = GlobalV;
n_49 = Invoke(G("document"), "createElement", tag_45);
if (Truthy(css_46)) {
Set(Get(n_49, "style"), "cssText", css_46);
}
if (!html_48.IsNullish) {
Set(n_49, "innerHTML", html_48);
}
if (Truthy(parent_47)) {
Invoke(parent_47, "appendChild", n_49);
}
return n_49;
return default;
}, 4, "el", false);
actor_16 = Fn((V _self50, int _argc51, V p_57, V k_58, V w_59, V _a56, V[] _rest52) => {
V n_60 = default;
if (_self50.IsNullish) _self50 = GlobalV;
n_60 = Call(el_14, V.Undef, ((V)("img")), ((V)(JsStrBuf.Begin().S("position:absolute;left:0;top:0;width:").V(w_59).S("px;height:").V(w_59).S("px;transform-origin:50% 94%;display:none;").End())), p_57);
Set(n_60, "alt", ((V)("")));
Set(n_60, "draggable", (false ? V.True : V.False));
Set(n_60, "_k", k_58);
Set(n_60, "_w", w_59);
Set(n_60, "_v", ((V)("")));
Invoke(Arr(((V)("front")), ((V)("left")), ((V)("right"))), "forEach", Fn((V _arrowThis68, int _argc61, V v_67, V _a64, V _a65, V _a66, V[] _rest62) => {
V i_69 = default;
i_69 = New(G("Image"));
Set(i_69, "src", Call(art_15, V.Undef, k_58, v_67));
return default;
}, 1, "", true));
return n_60;
return default;
}, 3, "actor", false);
pose_17 = Fn((V _self70, int _argc71, V n_77, V s_78, V _a75, V _a76, V[] _rest72) => {
V w_79 = default;
double ra_80 = 0;
double ly_81 = 0;
if (_self70.IsNullish) _self70 = GlobalV;
if (!(Truthy(s_78))) {
if (!SEqS(Get(Get(n_77, "style"), "display"), "none")) {
Set(Get(n_77, "style"), "display", ((V)("none")));
}
return default;
}
if (!SEq(Get(n_77, "_v"), Get(s_78, "v"))) {
Set(n_77, "_v", Get(s_78, "v"));
Set(n_77, "src", Call(art_15, V.Undef, Get(n_77, "_k"), Get(s_78, "v")));
}
w_79 = Get(n_77, "_w");
ra_80 = ((Min(90D, System.Math.Abs(ToNum((Get(s_78, "r") is var _t82 && Truthy(_t82) ? _t82 : ((V)(0D)))))) * System.Math.PI) / 180D);
ly_81 = ((Pow(FdLibm.Sin(ra_80), 2D) * ToNum(w_79)) * 0.4);
Set(Get(n_77, "style"), "display", ((V)("block")));
Set(Get(n_77, "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").V(Invoke(((V)((ToNum(Get(s_78, "x")) - (ToNum(w_79) / 2D)))), "toFixed", ((V)(2D)))).S("px,").V(Invoke(((V)(((ToNum(Get(s_78, "y")) - ly_81) - (ToNum(w_79) * 0.94)))), "toFixed", ((V)(2D)))).S("px) rotate(").V(Invoke((Get(s_78, "r") is var _t83 && Truthy(_t83) ? _t83 : ((V)(0D))), "toFixed", ((V)(2D)))).S("deg) scale(").V(Invoke((Get(s_78, "sx") is var _t84 && Truthy(_t84) ? _t84 : ((V)(1D))), "toFixed", ((V)(3D)))).S(",").V(Invoke((Get(s_78, "sy") is var _t85 && Truthy(_t85) ? _t85 : ((V)(1D))), "toFixed", ((V)(3D)))).S(")").End())));
return default;
}, 2, "pose", false);
kit_22 = Fn((V _self86, int _argc87, V Q_93, V _a90, V _a91, V _a92, V[] _rest88) => {
V I_94 = default;
if (_self86.IsNullish) _self86 = GlobalV;
I_94 = NewObj(10).Put("piano", Fn((V _arrowThis107, int _argc95, V t_101, V m_102, V _a99, V _a100, V[] _rest96) => {
V d_104 = default;
V v_106 = default;
{ V _t103 = _a99; if (_t103.IsUndef) _t103 = ((V)(0.3));
d_104 = _t103; }
{ V _t105 = _a100; if (_t105.IsUndef) _t105 = ((V)(0.1));
v_106 = _t105; }
Invoke(Q_93, "tone", t_101, Call(mtof_21, V.Undef, m_102), d_104, NewObj(3).Put("type", ((V)("triangle"))).Put("vol", v_106).Put("at", ((V)(0.003))).V);
Invoke(Q_93, "tone", t_101, ((V)((ToNum(Call(mtof_21, V.Undef, m_102)) * 1.004))), ((V)((ToNum(d_104) * 0.8))), NewObj(2).Put("vol", ((V)((ToNum(v_106) * 0.55)))).Put("at", ((V)(0.003))).V);
Invoke(Q_93, "tone", t_101, ((V)((ToNum(Call(mtof_21, V.Undef, m_102)) * 2D))), ((V)((ToNum(d_104) * 0.3))), NewObj(2).Put("vol", ((V)((ToNum(v_106) * 0.16)))).Put("at", ((V)(0.002))).V);
return default;
}, 4, "piano", true)).Put("chord", Fn((V _arrowThis120, int _argc108, V t_114, V ms_115, V d_116, V v_117, V[] _rest109) => {
V roll_119 = default;
{ V _t118 = (_argc108 > 4 ? _rest109[0] : V.Undef); if (_t118.IsUndef) _t118 = ((V)(0D));
roll_119 = _t118; }
return Invoke(ms_115, "forEach", Fn((V _arrowThis129, int _argc121, V m_127, V i_128, V _a125, V _a126, V[] _rest122) => {
return Invoke(I_94, "piano", Add(t_114, ((V)((ToNum(i_128) * ToNum(roll_119))))), m_127, d_116, v_117);
}, 2, "", true));
}, 5, "chord", true)).Put("thud", Fn((V _arrowThis139, int _argc130, V t_136, V _a133, V _a134, V _a135, V[] _rest131) => {
V v_138 = default;
{ V _t137 = _a133; if (_t137.IsUndef) _t137 = ((V)(0.45));
v_138 = _t137; }
return Invoke(Q_93, "tone", t_136, ((V)(120D)), ((V)(0.2)), NewObj(4).Put("to", ((V)(48D))).Put("slide", ((V)(0.12))).Put("vol", v_138).Put("at", ((V)(0.002))).V);
}, 2, "thud", true)).Put("tok", Fn((V _arrowThis149, int _argc140, V t_146, V _a143, V _a144, V _a145, V[] _rest141) => {
V v_148 = default;
{ V _t147 = _a143; if (_t147.IsUndef) _t147 = ((V)(0.14));
v_148 = _t147; }
return Invoke(Q_93, "tone", t_146, ((V)(880D)), ((V)(0.05)), NewObj(5).Put("to", ((V)(600D))).Put("slide", ((V)(0.04))).Put("type", ((V)("triangle"))).Put("vol", v_148).Put("at", ((V)(0.001))).V);
}, 2, "tok", true)).Put("whistle", Fn((V _arrowThis162, int _argc150, V t_156, V f0_157, V f1_158, V d_159, V[] _rest151) => {
V v_161 = default;
{ V _t160 = (_argc150 > 4 ? _rest151[0] : V.Undef); if (_t160.IsUndef) _t160 = ((V)(0.08));
v_161 = _t160; }
return Invoke(Q_93, "tone", t_156, f0_157, d_159, NewObj(4).Put("to", f1_158).Put("slide", d_159).Put("vol", v_161).Put("at", ((V)(0.03))).V);
}, 5, "whistle", true)).Put("splat", Fn((V _arrowThis170, int _argc163, V t_169, V _a166, V _a167, V _a168, V[] _rest164) => {
Invoke(Q_93, "noise", t_169, ((V)(0.35)), NewObj(5).Put("ft", ((V)("lowpass"))).Put("f", ((V)(2200D))).Put("fTo", ((V)(180D))).Put("vol", ((V)(0.38))).Put("at", ((V)(0.002))).V);
Invoke(Q_93, "tone", t_169, ((V)(170D)), ((V)(0.22)), NewObj(3).Put("to", ((V)(55D))).Put("slide", ((V)(0.18))).Put("vol", ((V)(0.28))).V);
return default;
}, 1, "splat", true)).Put("crash", Fn((V _arrowThis180, int _argc171, V t_177, V _a174, V _a175, V _a176, V[] _rest172) => {
V v_179 = default;
{ V _t178 = _a174; if (_t178.IsUndef) _t178 = ((V)(0.14));
v_179 = _t178; }
return Invoke(Q_93, "noise", t_177, ((V)(1.2)), NewObj(2).Put("f", ((V)(4200D))).Put("vol", v_179).V);
}, 2, "crash", true)).Put("whoosh", Fn((V _arrowThis192, int _argc181, V t_187, V _a184, V _a185, V _a186, V[] _rest182) => {
V d_189 = default;
V v_191 = default;
{ V _t188 = _a184; if (_t188.IsUndef) _t188 = ((V)(0.4));
d_189 = _t188; }
{ V _t190 = _a185; if (_t190.IsUndef) _t190 = ((V)(0.09));
v_191 = _t190; }
return Invoke(Q_93, "noise", t_187, d_189, NewObj(6).Put("ft", ((V)("bandpass"))).Put("f", ((V)(700D))).Put("fTo", ((V)(3200D))).Put("q", ((V)(1.1))).Put("vol", v_191).Put("at", ((V)((ToNum(d_189) * 0.4)))).V);
}, 3, "whoosh", true)).Put("chirp", Fn((V _arrowThis202, int _argc193, V t_199, V _a196, V _a197, V _a198, V[] _rest194) => {
V v_201 = default;
{ V _t200 = _a196; if (_t200.IsUndef) _t200 = ((V)(0.05));
v_201 = _t200; }
return Invoke(Q_93, "tone", t_199, ((V)(2300D)), ((V)(0.09)), NewObj(4).Put("to", ((V)(3300D))).Put("slide", ((V)(0.07))).Put("vol", v_201).Put("at", ((V)(0.004))).V);
}, 2, "chirp", true)).Put("slurp", Fn((V _arrowThis212, int _argc203, V t_209, V _a206, V _a207, V _a208, V[] _rest204) => {
V v_211 = default;
{ V _t210 = _a206; if (_t210.IsUndef) _t210 = ((V)(0.1));
v_211 = _t210; }
return Invoke(Q_93, "tone", t_209, ((V)(420D)), ((V)(0.28)), NewObj(5).Put("to", ((V)(1500D))).Put("slide", ((V)(0.24))).Put("type", ((V)("triangle"))).Put("vol", v_211).Put("at", ((V)(0.01))).V);
}, 2, "slurp", true)).V;
return I_94;
return default;
}, 1, "kit", false);
rag_25 = Fn((V _self213, int _argc214, V I_220, V t0_221, V t1_222, V B_223, V[] _rest215) => {
V v_224 = default;
V bar0_226 = default;
if (_self213.IsNullish) _self213 = GlobalV;
v_224 = (_argc214 > 4 ? _rest215[0] : V.Undef);
{ V _t225 = (_argc214 > 5 ? _rest215[1] : V.Undef); if (_t225.IsUndef) _t225 = ((V)(0D));
bar0_226 = _t225; }
{
V b_227 = default;
V t_228 = default;
b_227 = bar0_226;
t_228 = t0_221;
while (true) {
V t_228_it = t_228;
if (!(LtN(t_228_it, (ToNum(t1_222) - 0.01)))) break;
double k_230 = 0;
V ch_231 = default;
k_230 = (ToNum(b_227) % 8D);
ch_231 = GetIdx(RCH_23, k_230);
{
double j_232 = 0;
j_232 = 0D;
while (true) {
if (!((j_232 < 4D))) break;
V tj_234 = default;
tj_234 = Add(t_228_it, ((V)((j_232 * ToNum(B_223)))));
if (Ge(tj_234, t1_222)) {
break;
}
if (((j_232 % 2D) == 0D)) {
Invoke(I_220, "piano", tj_234, GetIdx(ch_231, (j_232 / 2D)), ((V)((ToNum(B_223) * 0.95))), ((V)((ToNum(v_224) * 1.15))));
} else {
Invoke(I_220, "chord", tj_234, GetIdx(ch_231, 2D), ((V)((ToNum(B_223) * 0.5))), ((V)((ToNum(v_224) * 0.42))));
}
j_232++;
}
}
Invoke(GetIdx(RMEL_24, k_230), "forEach", Fn((V _arrowThis248, int _argc235, V _a237, V _a238, V _a239, V _a240, V[] _rest236) => {
V tm_249 = default;
V o_243 = default;
V m_245 = default;
V d_247 = default;
{ V _t241 = ListOf(_a237);
{ V _t242 = GetIdx(_t241, 0D);
o_243 = _t242; }
{ V _t244 = GetIdx(_t241, 1D);
m_245 = _t244; }
{ V _t246 = GetIdx(_t241, 2D);
d_247 = _t246; }
}
tm_249 = Add(t_228_it, ((V)((ToNum(o_243) * ToNum(B_223)))));
if (Lt(tm_249, t1_222)) {
Invoke(I_220, "piano", tm_249, m_245, ((V)(((ToNum(d_247) * ToNum(B_223)) * 1.15))), ((V)((ToNum(v_224) * 0.85))));
}
return default;
}, 1, "", true));
t_228 = t_228_it;
PostInc(ref b_227, 1D);
t_228 = Add(t_228, ((V)((4D * ToNum(B_223)))));
}
}
return default;
}, 6, "rag", false);
sneak_26 = Fn((V _self250, int _argc251, V I_257, V t0_258, V t1_259, V B_260, V[] _rest252) => {
V W_262 = default;
double i_263 = 0;
V v_261 = default;
if (_self250.IsNullish) _self250 = GlobalV;
v_261 = (_argc251 > 4 ? _rest252[0] : V.Undef);
W_262 = Arr(((V)(45D)), ((V)(48D)), ((V)(52D)), ((V)(51D)), ((V)(50D)), ((V)(49D)), ((V)(48D)), ((V)(47D)));
i_263 = 0D;
{
V t_264 = default;
t_264 = t0_258;
while (true) {
if (!(LtN(t_264, (ToNum(t1_259) - 0.01)))) break;
Invoke(I_257, "piano", t_264, GetIdx(W_262, (i_263 % 8D)), ((V)(0.13)), v_261);
if (NumTruthy((i_263 % 2D))) {
Invoke(I_257, "piano", Add(t_264, ((V)((ToNum(B_260) / 2D)))), Add(GetIdx(W_262, (i_263 % 8D)), ((V)(12D))), ((V)(0.08)), ((V)((ToNum(v_261) * 0.4))));
}
t_264 = Add(t_264, B_260);
i_263++;
}
}
return default;
}, 5, "sneak", false);
look_27 = Fn((V _self266, int _argc267, V tier_273, V st_274, V film_275, V _a272, V[] _rest268) => {
V L_276 = default;
V top_277 = default;
if (_self266.IsNullish) _self266 = GlobalV;
L_276 = NewObj(1).Put("upd", Fn((V _self278, int _argc279, V _a281, V _a282, V _a283, V _a284, V[] _rest280) => {
if (_self278.IsNullish) _self278 = GlobalV;

return default;
}, 0, "upd", false)).V;
top_277 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;inset:0;pointer-events:none;")), st_274);
if (LeN(tier_273, 1D)) {
V folds_285 = default;
V cv_286 = default;
V cx_287 = default;
V img_288 = default;
V fl_289 = default;
V sc_290 = default;
V hair_291 = default;
V last_292 = default;
V hairT_293 = default;
Set(Get(film_275, "style"), "filter", ((V)("blur(0.35px)")));
folds_285 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;inset:-20px;background:linear-gradient(103deg,rgba(0,0,0,0) 0 14%,rgba(0,0,0,0.13) 18%,rgba(255,255,255,0.07) 22%,rgba(0,0,0,0) 27% 52%,rgba(0,0,0,0.11) 57%,rgba(255,255,255,0.06) 61%,rgba(0,0,0,0) 66% 80%,rgba(0,0,0,0.09) 86%,rgba(0,0,0,0) 92%),linear-gradient(8deg,rgba(0,0,0,0) 0 60%,rgba(0,0,0,0.08) 70%,rgba(0,0,0,0) 78%);")), top_277);
cv_286 = Call(el_14, V.Undef, ((V)("canvas")), ((V)("position:absolute;inset:0;width:100%;height:100%;opacity:0.3;mix-blend-mode:overlay;")), top_277);
Set(cv_286, "width", ((V)(96D)));
Set(cv_286, "height", ((V)(54D)));
cx_287 = Invoke(cv_286, "getContext", ((V)("2d")));
img_288 = Invoke(cx_287, "createImageData", ((V)(96D)), ((V)(54D)));
fl_289 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;inset:0;background:#000;opacity:0;")), top_277);
sc_290 = Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _arrowThis300, int _argc294, V _a296, V _a297, V _a298, V _a299, V[] _rest295) => {
return Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;top:0;width:1px;height:180px;background:rgba(250,240,220,0.55);display:none;")), top_277);
}, 0, "", true));
hair_291 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:250px;top:120px;width:60px;height:60px;display:none;")), top_277, ((V)("<svg viewBox=\"0 0 60 60\" width=\"60\" height=\"60\"><path d=\"M58 58 C40 50 46 30 30 26 S12 18 6 4\" stroke=\"#1a120a\" stroke-width=\"0.8\" fill=\"none\" opacity=\"0.7\"></path></svg>")));
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;inset:0;background:radial-gradient(ellipse at 50% 50%,rgba(0,0,0,0) 52%,rgba(0,0,0,0.5) 100%);")), top_277);
last_292 = ((V)(0D));
hairT_293 = ((V)(0D));
Set(L_276, "upd", Fn((V _arrowThis308, int _argc301, V now_307, V _a304, V _a305, V _a306, V[] _rest302) => {
V d_309 = default;
if (((ToNum(now_307) - ToNum(last_292)) < 83D)) {
return default;
}
last_292 = now_307;
d_309 = Get(img_288, "data");
{
double i_310 = 0;
i_310 = 0D;
while (true) {
if (!(Lt(((V)(i_310)), Get(d_309, "length")))) break;
double g_312 = 0;
g_312 = (ToNum(Invoke(G("Math"), "random")) * 255D);
SetIdx(d_309, i_310, SetIdx(d_309, (i_310 + 1D), SetIdx(d_309, (i_310 + 2D), ((V)(g_312)))));
SetIdx(d_309, (i_310 + 3D), ((V)(255D)));
i_310 = (i_310 + 4D);
}
}
Invoke(cx_287, "putImageData", img_288, ((V)(0D)), ((V)(0D)));
Set(Get(fl_289, "style"), "opacity", Invoke(((V)((0.03 + (ToNum(Invoke(G("Math"), "random")) * 0.1)))), "toFixed", ((V)(3D))));
Set(Get(film_275, "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").V(Invoke(((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 1.4))), "toFixed", ((V)(2D)))).S("px,").V(Invoke(((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 1.8))), "toFixed", ((V)(2D)))).S("px) rotate(").V(Invoke(((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 0.3))), "toFixed", ((V)(2D)))).S("deg)").End())));
Set(Get(folds_285, "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").V(Invoke(((V)((FdLibm.Sin((ToNum(now_307) / 2300D)) * 4D))), "toFixed", ((V)(1D)))).S("px,").V(Invoke(((V)((FdLibm.Sin((ToNum(now_307) / 3100D)) * 2D))), "toFixed", ((V)(1D)))).S("px)").End())));
Invoke(sc_290, "forEach", Fn((V _arrowThis320, int _argc313, V s_319, V _a316, V _a317, V _a318, V[] _rest314) => {
V on_321 = default;
on_321 = (LtN(Invoke(G("Math"), "random"), 0.28) ? V.True : V.False);
Set(Get(s_319, "style"), "display", ((V)((Truthy(on_321) ? "block" : "none"))));
if (Truthy(on_321)) {
Set(Get(s_319, "style"), "left", ((V)(JsStrBuf.Begin().V(Invoke(((V)((ToNum(Invoke(G("Math"), "random")) * 320D))), "toFixed", ((V)(0D)))).S("px").End())));
}
return default;
}, 1, "", true));
if (Gt(now_307, hairT_293)) {
hairT_293 = Add(Add(now_307, ((V)(3000D))), ((V)((ToNum(Invoke(G("Math"), "random")) * 5000D))));
Set(Get(hair_291, "style"), "display", ((V)((LtN(Invoke(G("Math"), "random"), 0.35) ? "block" : "none"))));
}
return default;
}, 1, "", true));
} else {
if (SEqN(tier_273, 2D)) {
V roll_322 = default;
Set(Get(film_275, "style"), "filter", ((V)("saturate(1.25) blur(0.3px)")));
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;inset:0;background:repeating-linear-gradient(0deg,rgba(0,0,0,0.2) 0 1px,rgba(0,0,0,0) 1px 3px);")), top_277);
roll_322 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;width:100%;height:26px;background:linear-gradient(rgba(255,255,255,0),rgba(255,255,255,0.08),rgba(255,255,255,0));")), top_277);
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;inset:0;border-radius:10px;box-shadow:inset 0 0 22px 6px rgba(0,0,0,0.6);")), top_277);
Set(L_276, "upd", Fn((V _arrowThis330, int _argc323, V now_329, V _a326, V _a327, V _a328, V[] _rest324) => {
Set(Get(roll_322, "style"), "top", ((V)(JsStrBuf.Begin().V(Invoke(((V)(((((ToNum(now_329) / 6000D) % 1D) * 230D) - 30D))), "toFixed", ((V)(1D)))).S("px").End())));
Set(Get(film_275, "style"), "transform", ((V)((LtN(Invoke(G("Math"), "random"), 0.01) ? JsStrBuf.Begin().S("translateX(").V(Invoke(((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 3D))), "toFixed", ((V)(1D)))).S("px)").End() : ""))));
return default;
}, 1, "", true));
} else {
if (SEqN(tier_273, 4D)) {
Set(Get(film_275, "style"), "filter", ((V)("contrast(1.06) saturate(1.1)")));
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;width:100%;height:10px;background:#000;")), top_277);
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;bottom:0;width:100%;height:10px;background:#000;")), top_277);
} else {
if (GeN(tier_273, 5D)) {
V edge_331 = default;
V sheen_332 = default;
Set(Get(film_275, "style"), "filter", ((V)("contrast(1.04) saturate(1.15) brightness(1.03)")));
edge_331 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;inset:0;")), top_277);
sheen_332 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;top:-20px;width:60px;height:220px;background:linear-gradient(90deg,rgba(255,255,255,0),rgba(255,255,255,0.14),rgba(255,255,255,0));transform:rotate(18deg);")), top_277);
Set(L_276, "upd", Fn((V _arrowThis340, int _argc333, V now_339, V _a336, V _a337, V _a338, V[] _rest334) => {
double h_341 = 0;
h_341 = ((ToNum(now_339) / 20D) % 360D);
Set(Get(edge_331, "style"), "boxShadow", ((V)(JsStrBuf.Begin().S("inset 0 0 12px 2px hsla(").V(Invoke(((V)(h_341)), "toFixed", ((V)(0D)))).S(",90%,70%,0.55),inset 0 0 3px 1px hsla(").V(Invoke(((V)(((h_341 + 120D) % 360D))), "toFixed", ((V)(0D)))).S(",90%,75%,0.6)").End())));
Set(Get(sheen_332, "style"), "left", ((V)(JsStrBuf.Begin().V(Invoke(((V)(((((ToNum(now_339) / 5000D) % 1D) * 520D) - 100D))), "toFixed", ((V)(0D)))).S("px").End())));
return default;
}, 1, "", true));
}
}
}
}
return L_276;
return default;
}, 3, "look", false);
cakeCaper_32 = Fn((V _self342, int _argc343, V _a345, V _a346, V _a347, V _a348, V[] _rest344) => {
V root_349 = default;
V film_350 = default;
V ld_351 = default;
V ldW_352 = default;
V ldN_353 = default;
V cd_354 = default;
V cdT_355 = default;
V cdI_356 = default;
V sc_357 = default;
V set_358 = default;
V win_359 = default;
V clk_360 = default;
V hM_361 = default;
V hH_362 = default;
V pie_363 = default;
V bulb_364 = default;
V shade_365 = default;
V tsh_366 = default;
V tb_367 = default;
V ck_368 = default;
V flame_369 = default;
V bite1_370 = default;
V bite2_371 = default;
V cksh_372 = default;
V shd_373 = default;
V chef_374 = default;
V fry_375 = default;
V cak_376 = default;
V sil_377 = default;
V peel_378 = default;
V splat_379 = default;
V mark_380 = default;
V hearts_381 = default;
V stars_382 = default;
V dust_383 = default;
V lines_384 = default;
V slices_385 = default;
V burn_386 = default;
V flap_387 = default;
V bar_388 = default;
V walk_389 = default;
V run_390 = default;
V stand_391 = default;
V chefAt_392 = default;
V fryAt_393 = default;
V cakAt_394 = default;
V upd_395 = default;
if (_self342.IsNullish) _self342 = GlobalV;
chefAt_392 = Fn((V _self396, int _argc397, V t_403, V _a400, V _a401, V _a402, V[] _rest398) => {
if (_self396.IsNullish) _self396 = GlobalV;
if ((GeN(t_403, 8.6) && LtN(t_403, 11D))) {
return Call(walk_389, V.Undef, t_403, ((V)(8.6)), ((V)(11D)), ((V)((-40D))), ((V)(122D)), ((V)("right")));
}
if ((GeN(t_403, 11D) && LtN(t_403, 11.6))) {
return Call(stand_391, V.Undef, ((V)("right")), ((V)(122D)), NewObj(1).Put("r", ((V)(((-5D) * FdLibm.Sin((System.Math.PI * ToNum(Call(P_11, V.Undef, t_403, ((V)(11D)), ((V)(11.6)), Get(E_10, "lin"))))))))).V);
}
if ((GeN(t_403, 11.6) && LtN(t_403, 12.6))) {
V h_404 = default;
h_404 = Add(Call(hop_13, V.Undef, t_403, ((V)(11.7)), ((V)(0.38)), ((V)(8D))), Call(hop_13, V.Undef, t_403, ((V)(12.1)), ((V)(0.38)), ((V)(8D))));
return Call(stand_391, V.Undef, ((V)("front")), ((V)(122D)), NewObj(3).Put("y", ((V)((FY_28 - ToNum(h_404))))).Put("sy", ((V)((1D + (ToNum(h_404) * 0.008))))).Put("sx", ((V)((1D - (ToNum(h_404) * 0.006))))).V);
}
if ((GeN(t_403, 12.6) && LtN(t_403, 14.2))) {
return Call(walk_389, V.Undef, t_403, ((V)(12.6)), ((V)(14.2)), ((V)(122D)), ((V)(360D)), ((V)("right")));
}
if ((GeN(t_403, 23.8) && LtN(t_403, 24.8))) {
return Call(walk_389, V.Undef, t_403, ((V)(23.8)), ((V)(24.8)), ((V)((-40D))), ((V)(112D)), ((V)("right")));
}
if ((GeN(t_403, 24.8) && LtN(t_403, 25.6))) {
return Call(stand_391, V.Undef, ((V)("front")), ((V)(112D)), NewObj(1).Put("r", ((V)((FdLibm.Sin(((ToNum(t_403) - 24.8) * 9D)) * 4D)))).V);
}
if ((GeN(t_403, 25.6) && LtN(t_403, 26.3))) {
return Call(walk_389, V.Undef, t_403, ((V)(25.6)), ((V)(26.3)), ((V)(112D)), ((V)(210D)), ((V)("right")));
}
if ((GeN(t_403, 26.3) && LtN(t_403, 26.8))) {
return Call(stand_391, V.Undef, ((V)("right")), ((V)(210D)), NewObj(1).Put("r", ((V)((10D * FdLibm.Sin((System.Math.PI * ToNum(Call(P_11, V.Undef, t_403, ((V)(26.35)), ((V)(26.7)), Get(E_10, "lin"))))))))).V);
}
if ((GeN(t_403, 26.8) && LtN(t_403, 27.5))) {
return Call(walk_389, V.Undef, t_403, ((V)(26.8)), ((V)(27.5)), ((V)(210D)), ((V)(190D)), ((V)("left")), ((V)(1.5)));
}
if ((GeN(t_403, 27.5) && LtN(t_403, 28.1))) {
return Call(stand_391, V.Undef, ((V)("right")), ((V)(190D)), NewObj(1).Put("y", ((V)((FY_28 - ToNum(Call(hop_13, V.Undef, t_403, ((V)(27.5)), ((V)(0.22)), ((V)(5D)))))))).V);
}
if ((GeN(t_403, 28.1) && LtN(t_403, 28.7))) {
return Call(walk_389, V.Undef, t_403, ((V)(28.1)), ((V)(28.7)), ((V)(190D)), ((V)(172D)), ((V)("left")), ((V)(1.5)));
}
if ((GeN(t_403, 28.7) && LtN(t_403, 29.4))) {
return Call(stand_391, V.Undef, ((V)("right")), ((V)(172D)), NewObj(1).Put("y", ((V)((FY_28 - ToNum(Call(hop_13, V.Undef, t_403, ((V)(28.7)), ((V)(0.22)), ((V)(5D)))))))).V);
}
if ((GeN(t_403, 29.4) && LtN(t_403, 30D))) {
return Call(stand_391, V.Undef, ((V)("right")), ((V)(172D)), NewObj(1).Put("y", ((V)((FY_28 - ToNum(Call(hop_13, V.Undef, t_403, ((V)(29.5)), ((V)(0.35)), ((V)(10D)))))))).V);
}
if ((GeN(t_403, 31.6) && LtN(t_403, 33.6))) {
return Call(run_390, V.Undef, t_403, ((V)(31.6)), ((V)(33.6)), ((V)(420D)), ((V)((-50D))));
}
if ((GeN(t_403, 33.8) && LtN(t_403, 35.4))) {
return Call(run_390, V.Undef, t_403, ((V)(33.8)), ((V)(35.4)), ((V)((-50D))), ((V)(370D)));
}
if ((GeN(t_403, 35.9) && LtN(t_403, 36.85))) {
return Call(run_390, V.Undef, t_403, ((V)(35.9)), ((V)(36.85)), ((V)(380D)), ((V)(176D)));
}
if ((GeN(t_403, 36.85) && LtN(t_403, 37D))) {
return Call(stand_391, V.Undef, ((V)("left")), ((V)(176D)), NewObj(1).Put("r", ((V)((-8D)))).V);
}
if ((GeN(t_403, 37D) && LtN(t_403, 38.3))) {
double d_405 = 0;
double k_406 = 0;
d_405 = (ToNum(t_403) - 37D);
k_406 = FdLibm.Exp(((-d_405) * 6D));
return Call(stand_391, V.Undef, ((V)("left")), ((V)((176D + (6D * ToNum(Call(P_11, V.Undef, t_403, ((V)(37D)), ((V)(37.15)))))))), NewObj(3).Put("r", ((V)(((14D * FdLibm.Exp(((-d_405) * 3D))) * FdLibm.Cos((d_405 * 9D)))))).Put("sx", ((V)((1D + (0.1 * k_406))))).Put("sy", ((V)((1D - (0.1 * k_406))))).V);
}
if ((GeN(t_403, 38.3) && LtN(t_403, 39.4))) {
return Call(run_390, V.Undef, t_403, ((V)(38.3)), ((V)(39.4)), ((V)(182D)), ((V)(128D)));
}
if ((GeN(t_403, 39.4) && LtN(t_403, 41.8))) {
V r_407 = default;
r_407 = (LtN(t_403, 40.1) ? Call(kf_12, V.Undef, t_403, Arr(Arr(((V)(39.4)), ((V)(0D))), Arr(((V)(39.75)), ((V)(112D))), Arr(((V)(40.1)), ((V)(92D)))), Get(E_10, "io")) : ((V)(((GtN(t_403, 41.2) && LtN(t_403, 41.6)) ? (92D + (FdLibm.Sin(((ToNum(t_403) - 41.2) * 32D)) * 7D)) : 92D))));
return NewObj(4).Put("v", ((V)("left"))).Put("x", ((V)(128D))).Put("y", ((V)(((FY_28 - ToNum(Call(hop_13, V.Undef, t_403, ((V)(39.4)), ((V)(0.7)), ((V)(26D))))) + (GeN(t_403, 40.1) ? 2D : 0D))))).Put("r", r_407).V;
}
if ((GeN(t_403, 41.8) && LtN(t_403, 42.6))) {
return NewObj(4).Put("v", ((V)((LtN(t_403, 42.3) ? "left" : "front")))).Put("x", ((V)(128D))).Put("y", ((V)(FY_28))).Put("r", Call(kf_12, V.Undef, t_403, Arr(Arr(((V)(41.8)), ((V)(92D))), Arr(((V)(42.4)), ((V)(0D)))), Get(E_10, "io"))).V;
}
if ((GeN(t_403, 42.6) && LtN(t_403, 45D))) {
double ph_408 = 0;
ph_408 = (ToNum(t_403) * 12D);
return NewObj(4).Put("v", ((V)("front"))).Put("x", Call(kf_12, V.Undef, t_403, Arr(Arr(((V)(42.6)), ((V)(128D))), Arr(((V)(43.3)), ((V)(90D))), Arr(((V)(44D)), ((V)(200D))), Arr(((V)(44.6)), ((V)(104D))), Arr(((V)(45D)), ((V)(104D)))), Get(E_10, "io"))).Put("y", ((V)((FY_28 - (System.Math.Abs(FdLibm.Sin(ph_408)) * 3D))))).Put("r", ((V)((FdLibm.Sin(ph_408) * 5D)))).V;
}
if ((GeN(t_403, 45D) && LtN(t_403, 46.8))) {
return NewObj(4).Put("v", ((V)("front"))).Put("x", Call(kf_12, V.Undef, t_403, Arr(Arr(((V)(45D)), ((V)(104D))), Arr(((V)(45.45)), ((V)(122D)))), Get(E_10, "out"))).Put("y", ((V)((FY_28 - ToNum(Call(hop_13, V.Undef, t_403, ((V)(45D)), ((V)(0.45)), ((V)(12D)))))))).Put("r", Call(kf_12, V.Undef, t_403, Arr(Arr(((V)(45D)), ((V)(0D))), Arr(((V)(45.45)), ((V)(84D)))), Get(E_10, "in"))).V;
}
if ((GeN(t_403, 46.8) && LtN(t_403, 48D))) {
return NewObj(4).Put("v", ((V)("front"))).Put("x", Call(kf_12, V.Undef, t_403, Arr(Arr(((V)(46.8)), ((V)(122D))), Arr(((V)(47.2)), ((V)(112D)))))).Put("y", ((V)((FY_28 - (GtN(t_403, 47.2) ? (System.Math.Abs(FdLibm.Sin((((ToNum(t_403) - 47.2) * System.Math.PI) / 0.4))) * 7D) : 0D))))).Put("r", Call(kf_12, V.Undef, t_403, Arr(Arr(((V)(46.8)), ((V)(84D))), Arr(((V)(47.2)), ((V)(0D)))), Get(E_10, "io"))).V;
}
if ((GeN(t_403, 50.4) && LtN(t_403, 56.2))) {
double h_409 = 0;
double lf_410 = 0;
h_409 = ((System.Math.Abs(FdLibm.Sin((((ToNum(t_403) - 50.4) * System.Math.PI) / 0.4))) * 5D) * (LtN(t_403, 55.2) ? 1D : 0D));
lf_410 = (GeN(t_403, 55.3) ? FdLibm.Sin((ToNum(t_403) * 40D)) : 0D);
return NewObj(5).Put("v", ((V)("front"))).Put("x", ((V)(100D))).Put("y", ((V)((FY_28 - h_409)))).Put("r", ((V)((lf_410 * 3D)))).Put("sy", ((V)((1D + (0.04 * lf_410))))).V;
}
return V.Null;
return default;
}, 1, "chefAt", false);
fryAt_393 = Fn((V _self411, int _argc412, V t_418, V _a415, V _a416, V _a417, V[] _rest413) => {
if (_self411.IsNullish) _self411 = GlobalV;
if ((GeN(t_418, 16.4) && LtN(t_418, 19D))) {
double s_419 = 0;
double k_420 = 0;
double u_421 = 0;
s_419 = ((ToNum(t_418) - 16.4) / 0.52);
k_420 = Min(4D, System.Math.Floor(s_419));
u_421 = Min(1D, (s_419 - k_420));
return NewObj(5).Put("v", ((V)("left"))).Put("x", ((V)((350D - (30.8 * ToNum(Add(((V)(k_420)), Invoke(E_10, "io", ((V)(u_421)))))))))).Put("y", ((V)((FY_28 - (FdLibm.Sin((System.Math.PI * u_421)) * 9D))))).Put("r", ((V)((7D - (FdLibm.Sin((System.Math.PI * u_421)) * 4D))))).Put("sx", ((V)(0.96))).V;
}
if ((GeN(t_418, 19D) && LtN(t_418, 19.9))) {
return Call(stand_391, V.Undef, ((V)((LtN(t_418, 19.35) ? "left" : (LtN(t_418, 19.7) ? "right" : "front")))), ((V)(196D)));
}
if ((GeN(t_418, 19.9) && LtN(t_418, 20.6))) {
return Call(stand_391, V.Undef, ((V)("left")), ((V)((196D - (6D * ToNum(Call(P_11, V.Undef, t_418, ((V)(19.9)), ((V)(20.3)))))))), NewObj(1).Put("r", ((V)((((-16D) * ToNum(Call(P_11, V.Undef, t_418, ((V)(19.9)), ((V)(20.25))))) * (1D - ToNum(Call(P_11, V.Undef, t_418, ((V)(20.45)), ((V)(20.6))))))))).V);
}
if ((GeN(t_418, 20.6) && LtN(t_418, 22.4))) {
double w_422 = 0;
w_422 = (LtN(t_418, 21.8) ? 1D : (1D - ToNum(Call(P_11, V.Undef, t_418, ((V)(21.8)), ((V)(22.2))))));
return Call(stand_391, V.Undef, ((V)("front")), ((V)(190D)), NewObj(3).Put("r", ((V)(((FdLibm.Sin((ToNum(t_418) * 13D)) * 6D) * w_422)))).Put("sx", ((V)((1D + ((0.04 * FdLibm.Sin((ToNum(t_418) * 26D))) * w_422))))).Put("sy", ((V)((1D - ((0.04 * FdLibm.Sin((ToNum(t_418) * 26D))) * w_422))))).V);
}
if ((GeN(t_418, 22.4) && LtN(t_418, 22.9))) {
return Call(stand_391, V.Undef, ((V)("front")), ((V)(190D)), NewObj(1).Put("y", ((V)((FY_28 - ToNum(Call(hop_13, V.Undef, t_418, ((V)(22.5)), ((V)(0.32)), ((V)(12D)))))))).V);
}
if ((GeN(t_418, 22.9) && LtN(t_418, 23.5))) {
return Call(run_390, V.Undef, t_418, ((V)(22.9)), ((V)(23.5)), ((V)(190D)), ((V)(252D)));
}
if ((GeN(t_418, 23.5) && LtN(t_418, 29.35))) {
V x_423 = default;
V sl_424 = default;
double d_425 = 0;
double tap_426 = 0;
x_423 = Call(kf_12, V.Undef, t_418, Arr(Arr(((V)(23.5)), ((V)(252D))), Arr(((V)(26.8)), ((V)(252D))), Arr(((V)(27.5)), ((V)(240D))), Arr(((V)(28.1)), ((V)(240D))), Arr(((V)(28.7)), ((V)(228D)))));
sl_424 = (((GtN(t_418, 26.8) && LtN(t_418, 27.5)) || (GtN(t_418, 28.1) && LtN(t_418, 28.7))) ? V.True : V.False);
d_425 = (ToNum(t_418) - 26.5);
tap_426 = (((d_425 > 0D) && (d_425 < 0.8)) ? ((FdLibm.Sin((d_425 * 30D)) * 4D) * FdLibm.Exp(((-d_425) * 5D))) : 0D);
return Call(stand_391, V.Undef, ((V)("front")), x_423, NewObj(2).Put("y", ((V)((FY_28 - (Truthy(sl_424) ? (System.Math.Abs(FdLibm.Sin((ToNum(t_418) * 22D))) * 1.5) : 0D))))).Put("r", ((V)(tap_426))).V);
}
if ((GeN(t_418, 29.35) && LtN(t_418, 30D))) {
double d_427 = 0;
double w_428 = 0;
d_427 = (ToNum(t_418) - 29.35);
w_428 = ((d_427 < 0.12) ? (-d_427) : ((0.12 * FdLibm.Exp(((-(d_427 - 0.12)) * 5D))) * FdLibm.Cos(((d_427 - 0.12) * 20D))));
return Call(stand_391, V.Undef, ((V)("front")), ((V)(228D)), NewObj(2).Put("sx", ((V)((1D - (w_428 * 0.8))))).Put("sy", ((V)((1D + w_428)))).V);
}
if ((GeN(t_418, 31.6) && LtN(t_418, 33.2))) {
return Call(run_390, V.Undef, t_418, ((V)(31.6)), ((V)(33.2)), ((V)(290D)), ((V)((-50D))));
}
if ((GeN(t_418, 34.1) && LtN(t_418, 35.7))) {
return Call(run_390, V.Undef, t_418, ((V)(34.1)), ((V)(35.7)), ((V)((-50D))), ((V)(370D)));
}
if ((GeN(t_418, 35.8) && LtN(t_418, 36.4))) {
return Call(run_390, V.Undef, t_418, ((V)(35.8)), ((V)(36.4)), ((V)((-40D))), ((V)(78D)));
}
if ((GeN(t_418, 36.4) && LtN(t_418, 37D))) {
return Call(stand_391, V.Undef, ((V)("right")), ((V)(78D)), NewObj(1).Put("r", (LtN(t_418, 36.6) ? ((V)(0D)) : Call(kf_12, V.Undef, t_418, Arr(Arr(((V)(36.6)), ((V)((-10D)))), Arr(((V)(36.8)), ((V)(12D))), Arr(((V)(37D)), ((V)(0D))))))).V);
}
if ((GeN(t_418, 37D) && LtN(t_418, 38.2))) {
return Call(stand_391, V.Undef, ((V)("front")), ((V)(78D)), NewObj(2).Put("y", ((V)((FY_28 - (System.Math.Abs(FdLibm.Sin((ToNum(t_418) * 16D))) * 3D))))).Put("r", ((V)((FdLibm.Sin((ToNum(t_418) * 16D)) * 4D)))).V);
}
if ((GeN(t_418, 38.2) && LtN(t_418, 39D))) {
return Call(run_390, V.Undef, t_418, ((V)(38.2)), ((V)(39D)), ((V)(78D)), ((V)((-50D))));
}
if ((GeN(t_418, 41.8) && LtN(t_418, 42.6))) {
return Call(run_390, V.Undef, t_418, ((V)(41.8)), ((V)(42.6)), ((V)((-40D))), ((V)(84D)));
}
if ((GeN(t_418, 42.6) && LtN(t_418, 45D))) {
double ph_429 = 0;
ph_429 = ((ToNum(t_418) * 12D) + 1D);
return NewObj(4).Put("v", ((V)("front"))).Put("x", Call(kf_12, V.Undef, t_418, Arr(Arr(((V)(42.6)), ((V)(84D))), Arr(((V)(43.3)), ((V)(214D))), Arr(((V)(44D)), ((V)(150D))), Arr(((V)(44.6)), ((V)(232D))), Arr(((V)(45D)), ((V)(232D)))), Get(E_10, "io"))).Put("y", ((V)((FY_28 - (System.Math.Abs(FdLibm.Sin(ph_429)) * 3D))))).Put("r", ((V)((FdLibm.Sin(ph_429) * 5D)))).V;
}
if ((GeN(t_418, 45D) && LtN(t_418, 46.8))) {
return NewObj(4).Put("v", ((V)("front"))).Put("x", Call(kf_12, V.Undef, t_418, Arr(Arr(((V)(45D)), ((V)(232D))), Arr(((V)(45.45)), ((V)(214D)))), Get(E_10, "out"))).Put("y", ((V)((FY_28 - ToNum(Call(hop_13, V.Undef, t_418, ((V)(45D)), ((V)(0.45)), ((V)(12D)))))))).Put("r", Call(kf_12, V.Undef, t_418, Arr(Arr(((V)(45D)), ((V)(0D))), Arr(((V)(45.45)), ((V)((-84D))))), Get(E_10, "in"))).V;
}
if ((GeN(t_418, 46.8) && LtN(t_418, 48D))) {
return NewObj(4).Put("v", ((V)("front"))).Put("x", Call(kf_12, V.Undef, t_418, Arr(Arr(((V)(46.8)), ((V)(214D))), Arr(((V)(47.2)), ((V)(220D)))))).Put("y", ((V)((FY_28 - (GtN(t_418, 47.2) ? (System.Math.Abs(FdLibm.Sin((((ToNum(t_418) - 47D) * System.Math.PI) / 0.4))) * 7D) : 0D))))).Put("r", Call(kf_12, V.Undef, t_418, Arr(Arr(((V)(46.8)), ((V)((-84D)))), Arr(((V)(47.2)), ((V)(0D)))), Get(E_10, "io"))).V;
}
if ((GeN(t_418, 50.4) && LtN(t_418, 56.2))) {
double h_430 = 0;
if ((GeN(t_418, 54.8) && LtN(t_418, 55.5))) {
return Call(stand_391, V.Undef, ((V)("left")), ((V)((220D - (8D * ToNum(Call(P_11, V.Undef, t_418, ((V)(54.8)), ((V)(55.1)))))))), NewObj(1).Put("r", ((V)((((-18D) * ToNum(Call(P_11, V.Undef, t_418, ((V)(54.8)), ((V)(55.1))))) * (1D - ToNum(Call(P_11, V.Undef, t_418, ((V)(55.35)), ((V)(55.5))))))))).V);
}
h_430 = ((System.Math.Abs(FdLibm.Sin((((ToNum(t_418) - 50.2) * System.Math.PI) / 0.4))) * 5D) * (LtN(t_418, 54.8) ? 1D : 0D));
return Call(stand_391, V.Undef, ((V)("front")), ((V)(220D)), NewObj(2).Put("y", ((V)((FY_28 - h_430)))).Put("r", ((V)((GeN(t_418, 55.5) ? (FdLibm.Sin((ToNum(t_418) * 40D)) * 3D) : 0D)))).V);
}
return V.Null;
return default;
}, 1, "fryAt", false);
cakAt_394 = Fn((V _self431, int _argc432, V t_438, V _a435, V _a436, V _a437, V[] _rest433) => {
if (_self431.IsNullish) _self431 = GlobalV;
if ((GeN(t_438, 43.6) && LtN(t_438, 45.2))) {
return Call(walk_389, V.Undef, t_438, ((V)(43.6)), ((V)(45.2)), ((V)(380D)), ((V)(168D)), ((V)("left")));
}
if ((GeN(t_438, 45.2) && LtN(t_438, 48D))) {
double d_439 = 0;
double q_440 = 0;
double h_441 = 0;
d_439 = (ToNum(t_438) - 46.2);
q_440 = ((d_439 > 0D) ? ((0.2 * FdLibm.Exp(((-d_439) * 5D))) * FdLibm.Cos((d_439 * 18D))) : 0D);
h_441 = (GtN(t_438, 46.6) ? (System.Math.Abs(FdLibm.Sin((((ToNum(t_438) - 46.6) * System.Math.PI) / 0.4))) * 6D) : 0D);
return Call(stand_391, V.Undef, ((V)("front")), ((V)(168D)), NewObj(3).Put("y", ((V)((FY_28 - h_441)))).Put("sx", ((V)((1D + (q_440 * 0.7))))).Put("sy", ((V)((1D - q_440)))).V);
}
if ((GeN(t_438, 50.4) && LtN(t_438, 56.2))) {
double h_442 = 0;
h_442 = ((System.Math.Abs(FdLibm.Sin((((ToNum(t_438) - 50.3) * System.Math.PI) / 0.4))) * 5D) * (LtN(t_438, 55.2) ? 1D : 0D));
return Call(stand_391, V.Undef, ((V)(((GeN(t_438, 55.25) && LtN(t_438, 55.9)) ? "right" : "front"))), ((V)(160D)), NewObj(2).Put("y", ((V)((FY_28 - h_442)))).Put("r", ((V)((GtN(t_438, 55.9) ? (FdLibm.Sin((ToNum(t_438) * 40D)) * 2.5) : 0D)))).V);
}
return V.Null;
return default;
}, 1, "cakAt", false);
upd_395 = Fn((V _self443, int _argc444, V t_450, V _a447, V _a448, V _a449, V[] _rest445) => {
V lead_451 = default;
V ci_452 = default;
V inS_453 = default;
double lit_454 = 0;
if (_self443.IsNullish) _self443 = GlobalV;
lead_451 = ((GeN(t_450, 0D) && LtN(t_450, 3D)) ? V.True : V.False);
ci_452 = Invoke(CARDS_30, "findIndex", Fn((V _arrowThis462, int _argc455, V c_461, V _a458, V _a459, V _a460, V[] _rest456) => {
return ((Ge(t_450, GetIdx(c_461, 0D)) && Lt(t_450, GetIdx(c_461, 1D))) ? V.True : V.False);
}, 1, "", true));
inS_453 = Invoke(SCN_31, "some", Fn((V _arrowThis470, int _argc463, V s_469, V _a466, V _a467, V _a468, V[] _rest464) => {
return ((Ge(t_450, GetIdx(s_469, 0D)) && Lt(t_450, GetIdx(s_469, 1D))) ? V.True : V.False);
}, 1, "", true));
Call(show_19, V.Undef, ld_351, lead_451);
Call(show_19, V.Undef, cd_354, (GeN(ci_452, 0D) ? V.True : V.False));
Call(show_19, V.Undef, sc_357, inS_453);
if (Truthy(lead_451)) {
double n_471 = 0;
double f_472 = 0;
n_471 = (3D - System.Math.Floor(ToNum(t_450)));
f_472 = (ToNum(t_450) % 1D);
Set(ldN_353, "textContent", ((V)(ToStrS(((V)(n_471))))));
Set(Get(ldW_352, "style"), "background", ((V)(JsStrBuf.Begin().S("conic-gradient(rgba(40,30,20,0.38) 0deg ").V(Invoke(((V)((f_472 * 360D))), "toFixed", ((V)(1D)))).S("deg,rgba(0,0,0,0) ").V(Invoke(((V)((f_472 * 360D))), "toFixed", ((V)(1D)))).S("deg)").End())));
Set(Get(ld_351, "style"), "background", ((V)(((f_472 < 0.06) ? "#f6efe0" : "#d8cbb0"))));
}
if (GeN(ci_452, 0D)) {
V C_473 = default;
double o_474 = 0;
C_473 = GetK(CARDS_30, ci_452);
if (!SEq(cdI_356, ci_452)) {
cdI_356 = ci_452;
Set(cdT_355, "innerHTML", GetIdx(C_473, 2D));
}
o_474 = (ToNum(Call(P_11, V.Undef, t_450, GetIdx(C_473, 0D), Add(GetIdx(C_473, 0D), ((V)(0.3))))) * (SEqN(ci_452, (ToNum(Get(CARDS_30, "length")) - 1D)) ? 1D : (1D - ToNum(Call(P_11, V.Undef, t_450, ((V)((ToNum(GetIdx(C_473, 1D)) - 0.25))), GetIdx(C_473, 1D))))));
Set(Get(cdT_355, "style"), "opacity", Invoke(((V)(o_474)), "toFixed", ((V)(3D))));
Set(Get(cdT_355, "style"), "transform", ((V)((SEqN(ci_452, 3D) ? JsStrBuf.Begin().S("translate(").V(Invoke(((V)((FdLibm.Sin((ToNum(t_450) * 61D)) * 1.6))), "toFixed", ((V)(2D)))).S("px,").V(Invoke(((V)((FdLibm.Cos((ToNum(t_450) * 53D)) * 1.6))), "toFixed", ((V)(2D)))).S("px) scale(").V(Invoke(((V)((1D + (0.15 * FdLibm.Exp(((-(ToNum(t_450) - 30D)) * 6D)))))), "toFixed", ((V)(3D)))).S(")").End() : ""))));
}
if (Truthy(inS_453)) {
V ir_475 = default;
double ix_476 = 0;
double iy_477 = 0;
double quake_478 = 0;
V C_479 = default;
V F_480 = default;
V K_481 = default;
double sh_482 = 0;
V S_483 = default;
V L_484 = default;
V M_485 = default;
V R_486 = default;
ir_475 = V.Null;
ix_476 = 160D;
iy_477 = 112D;
if (LtN(t_450, 9.4)) {
ir_475 = ((V)((10D + (ToNum(Call(P_11, V.Undef, t_450, ((V)(8.6)), ((V)(9.4)), Get(E_10, "in"))) * 230D))));
} else {
if ((GeN(t_450, 16.4) && LtN(t_450, 16.9))) {
ir_475 = ((V)((10D + (ToNum(Call(P_11, V.Undef, t_450, ((V)(16.4)), ((V)(16.9)), Get(E_10, "in"))) * 230D))));
} else {
if (GeN(t_450, 55.6)) {
ir_475 = ((V)((230D * (1D - ToNum(Call(P_11, V.Undef, t_450, ((V)(55.6)), ((V)(56.15)), Get(E_10, "in")))))));
ix_476 = 160D;
iy_477 = 118D;
}
}
}
Set(Get(sc_357, "style"), "clipPath", ((V)((ir_475.IsNullish ? "none" : JsStrBuf.Begin().S("circle(").V(Invoke(ir_475, "toFixed", ((V)(1D)))).S("px at ").N(ix_476).S("px ").N(iy_477).S("px)").End()))));
quake_478 = ((GeN(t_450, 40.1) && LtN(t_450, 40.4)) ? ((FdLibm.Sin(((ToNum(t_450) - 40.1) * 70D)) * 2D) * (1D - ((ToNum(t_450) - 40.1) / 0.3))) : ((GeN(t_450, 46.2) && LtN(t_450, 46.5)) ? ((FdLibm.Sin(((ToNum(t_450) - 46.2) * 70D)) * 1.5) * (1D - ((ToNum(t_450) - 46.2) / 0.3))) : 0D));
Set(Get(set_358, "style"), "transform", ((V)((NumTruthy(quake_478) ? JsStrBuf.Begin().S("translateY(").V(Invoke(((V)(quake_478)), "toFixed", ((V)(2D)))).S("px)").End() : ""))));
Set(Get(hM_361, "style"), "transform", ((V)(JsStrBuf.Begin().S("rotate(").V(Invoke(((V)((ToNum(t_450) * 36D))), "toFixed", ((V)(1D)))).S("deg)").End())));
Set(Get(hH_362, "style"), "transform", ((V)(JsStrBuf.Begin().S("rotate(").V(Invoke(((V)((120D + (ToNum(t_450) * 3D)))), "toFixed", ((V)(1D)))).S("deg)").End())));
C_479 = Call(chefAt_392, V.Undef, t_450);
F_480 = Call(fryAt_393, V.Undef, t_450);
K_481 = Call(cakAt_394, V.Undef, t_450);
Call(pose_17, V.Undef, chef_374, C_479);
Call(pose_17, V.Undef, fry_375, F_480);
Call(pose_17, V.Undef, cak_376, K_481);
Invoke(Arr(C_479, F_480, K_481), "forEach", Fn((V _arrowThis495, int _argc487, V s_493, V i_494, V _a491, V _a492, V[] _rest488) => {
double k_496 = 0;
if ((!(Truthy(s_493)) || (System.Math.Abs(ToNum((Get(s_493, "r") is var _t497 && Truthy(_t497) ? _t497 : ((V)(0D))))) > 60D))) {
Call(show_19, V.Undef, GetK(shd_373, i_494), (false ? V.True : V.False));
return default;
}
k_496 = (1D - (ToNum(Call(cl_8, V.Undef, ((V)(((FY_28 - ToNum(Get(s_493, "y"))) / 40D))))) * 0.5));
Call(put_18, V.Undef, GetK(shd_373, i_494), Get(s_493, "x"), ((V)((FY_28 + 1D))), ((V)(k_496)), ((V)(0D)), ((V)((0.9 * k_496))));
return default;
}, 2, "", true));
sh_482 = ((GeN(t_450, 41.6) && LtN(t_450, 42D)) ? ((FdLibm.Sin(((ToNum(t_450) - 41.6) * 60D)) * 2.5) * (1D - ((ToNum(t_450) - 41.6) / 0.4))) : 0D);
Set(Get(tb_367, "style"), "transform", ((V)((NumTruthy(sh_482) ? JsStrBuf.Begin().S("translateX(").V(Invoke(((V)(sh_482)), "toFixed", ((V)(2D)))).S("px)").End() : ""))));
if ((GeN(t_450, 22.4) && LtN(t_450, 23.9))) {
Call(pose_17, V.Undef, sil_377, NewObj(5).Put("v", ((V)("right"))).Put("x", Call(lerp_9, V.Undef, ((V)((-30D))), ((V)(40D)), Call(P_11, V.Undef, t_450, ((V)(22.4)), ((V)(23.8)), Get(E_10, "lin")))).Put("y", ((V)(150D))).Put("sx", Call(lerp_9, V.Undef, ((V)(1.3)), ((V)(0.9)), Call(P_11, V.Undef, t_450, ((V)(22.4)), ((V)(23.8))))).Put("sy", Call(lerp_9, V.Undef, ((V)(1.3)), ((V)(0.9)), Call(P_11, V.Undef, t_450, ((V)(22.4)), ((V)(23.8))))).V);
} else {
Call(pose_17, V.Undef, sil_377, V.Null);
}
S_483 = V.Null;
if (Truthy(((C_479 is var _t498 && !Truthy(_t498) ? _t498 : (GeN(t_450, 8.6) ? V.True : V.False)) is var _t499 && !Truthy(_t499) ? _t499 : (LtN(t_450, 11D) ? V.True : V.False)))) {
S_483 = NewObj(3).Put("x", Add(Get(C_479, "x"), ((V)(3D)))).Put("yb", ((V)((ToNum(Get(C_479, "y")) - 53D)))).Put("r", Get(C_479, "r")).V;
} else {
if ((GeN(t_450, 11D) && LtN(t_450, 11.6))) {
V u_500 = default;
u_500 = Call(P_11, V.Undef, t_450, ((V)(11D)), ((V)(11.6)), Get(E_10, "io"));
S_483 = NewObj(2).Put("x", Call(lerp_9, V.Undef, ((V)(125D)), ((V)(160D)), u_500)).Put("yb", ((V)((ToNum(Call(lerp_9, V.Undef, ((V)((FY_28 - 53D))), ((V)(113D)), u_500)) - (FdLibm.Sin((System.Math.PI * ToNum(u_500))) * 8D))))).V;
} else {
if ((GeN(t_450, 11.6) && LtN(t_450, 41.6))) {
S_483 = NewObj(2).Put("x", ((V)((160D + sh_482)))).Put("yb", ((V)(113D))).V;
} else {
if ((GeN(t_450, 41.6) && LtN(t_450, 42.7))) {
V u_501 = default;
u_501 = Call(P_11, V.Undef, t_450, ((V)(41.6)), ((V)(42.7)), Get(E_10, "lin"));
S_483 = NewObj(3).Put("x", ((V)((160D + (ToNum(u_501) * 12D))))).Put("yb", ((V)((113D - (ToNum(Invoke(E_10, "out", u_501)) * 200D))))).Put("r", ((V)((ToNum(u_501) * 420D)))).V;
} else {
if (Truthy((((GeN(t_450, 45.4) && LtN(t_450, 46.2)) ? V.True : V.False) is var _t502 && !Truthy(_t502) ? _t502 : K_481))) {
V u_503 = default;
u_503 = Call(P_11, V.Undef, t_450, ((V)(45.4)), ((V)(46.2)), Get(E_10, "in"));
S_483 = NewObj(3).Put("x", Get(K_481, "x")).Put("yb", Call(lerp_9, V.Undef, ((V)((-40D))), ((V)((ToNum(Get(K_481, "y")) - 47D))), u_503)).Put("r", ((V)(((1D - ToNum(u_503)) * 200D)))).V;
} else {
if (Truthy((K_481 is var _t504 && !Truthy(_t504) ? _t504 : (GeN(t_450, 46.2) ? V.True : V.False)))) {
S_483 = NewObj(5).Put("x", Get(K_481, "x")).Put("yb", ((V)((ToNum(Get(K_481, "y")) - (47D * ToNum((Get(K_481, "sy") is var _t505 && Truthy(_t505) ? _t505 : ((V)(1D))))))))).Put("r", (Get(K_481, "r") is var _t506 && Truthy(_t506) ? _t506 : ((V)(0D)))).Put("sx", Get(K_481, "sx")).Put("sy", Get(K_481, "sy")).V;
}
}
}
}
}
}
if (Truthy(S_483)) {
Call(show_19, V.Undef, ck_368, (true ? V.True : V.False));
Set(Get(ck_368, "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").V(Invoke(((V)((ToNum(Get(S_483, "x")) - 15D))), "toFixed", ((V)(2D)))).S("px,").V(Invoke(((V)((ToNum(Get(S_483, "yb")) - 30D))), "toFixed", ((V)(2D)))).S("px) rotate(").V(Invoke((Get(S_483, "r") is var _t507 && Truthy(_t507) ? _t507 : ((V)(0D))), "toFixed", ((V)(1D)))).S("deg) scale(").V(Invoke((Get(S_483, "sx") is var _t508 && Truthy(_t508) ? _t508 : ((V)(1D))), "toFixed", ((V)(3D)))).S(",").V(Invoke((Get(S_483, "sy") is var _t509 && Truthy(_t509) ? _t509 : ((V)(1D))), "toFixed", ((V)(3D)))).S(")").End())));
} else {
Call(show_19, V.Undef, ck_368, (false ? V.True : V.False));
}
Call(show_19, V.Undef, bite1_370, (GeN(t_450, 20.3) ? V.True : V.False));
Call(show_19, V.Undef, bite2_371, (GeN(t_450, 55.1) ? V.True : V.False));
if (GeN(t_450, 50.6)) {
Call(show_19, V.Undef, flame_369, (true ? V.True : V.False));
Set(Get(flame_369, "style"), "transform", ((V)(JsStrBuf.Begin().S("scale(").V(Invoke(((V)((0.9 + (0.15 * FdLibm.Sin((ToNum(t_450) * 31D)))))), "toFixed", ((V)(3D)))).S(",").V(Invoke(((V)((0.9 + (0.2 * FdLibm.Sin(((ToNum(t_450) * 23D) + 1D)))))), "toFixed", ((V)(3D)))).S(") rotate(").V(Invoke(((V)((FdLibm.Sin((ToNum(t_450) * 17D)) * 8D))), "toFixed", ((V)(1D)))).S("deg)").End())));
} else {
Call(show_19, V.Undef, flame_369, (false ? V.True : V.False));
}
if ((GeN(t_450, 43.4) && LtN(t_450, 46.2))) {
V k_510 = default;
k_510 = Call(P_11, V.Undef, t_450, ((V)(43.4)), ((V)(46.2)), Get(E_10, "in"));
Call(put_18, V.Undef, cksh_372, Call(kf_12, V.Undef, t_450, Arr(Arr(((V)(43.4)), ((V)(180D))), Arr(((V)(44.2)), ((V)(140D))), Arr(((V)(44.8)), ((V)(176D))), Arr(((V)(45.4)), ((V)(168D)))), Get(E_10, "io")), ((V)((FY_28 + 1D))), ((V)((0.3 + (0.8 * ToNum(k_510))))), ((V)(0D)), ((V)((0.3 + (0.6 * ToNum(k_510))))));
} else {
Call(show_19, V.Undef, cksh_372, (false ? V.True : V.False));
}
L_484 = NewObj(3).Put("x", ((V)(272D))).Put("y", ((V)(87D))).Put("r", ((V)(0D))).V;
if (Truthy(((F_480 is var _t511 && !Truthy(_t511) ? _t511 : (GeN(t_450, 23.5) ? V.True : V.False)) is var _t512 && !Truthy(_t512) ? _t512 : (LtN(t_450, 23.8) ? V.True : V.False)))) {
V u_513 = default;
u_513 = Call(P_11, V.Undef, t_450, ((V)(23.5)), ((V)(23.8)), Get(E_10, "io"));
L_484 = NewObj(3).Put("x", Call(lerp_9, V.Undef, ((V)(272D)), Get(F_480, "x"), u_513)).Put("y", ((V)((ToNum(Call(lerp_9, V.Undef, ((V)(87D)), ((V)((ToNum(Get(F_480, "y")) - 44D))), u_513)) - (FdLibm.Sin((System.Math.PI * ToNum(u_513))) * 12D))))).Put("r", ((V)((ToNum(u_513) * (-20D))))).V;
} else {
if (Truthy(((F_480 is var _t514 && !Truthy(_t514) ? _t514 : (GeN(t_450, 23.8) ? V.True : V.False)) is var _t515 && !Truthy(_t515) ? _t515 : (LtN(t_450, 29.45) ? V.True : V.False)))) {
L_484 = NewObj(3).Put("x", ((V)((ToNum(Get(F_480, "x")) - (FdLibm.Sin(((ToNum((Get(F_480, "r") is var _t516 && Truthy(_t516) ? _t516 : ((V)(0D)))) * System.Math.PI) / 180D)) * 44D))))).Put("y", ((V)((ToNum(Get(F_480, "y")) - (44D * ToNum((Get(F_480, "sy") is var _t517 && Truthy(_t517) ? _t517 : ((V)(1D))))))))).Put("r", (Get(F_480, "r") is var _t518 && Truthy(_t518) ? _t518 : ((V)(0D)))).V;
} else {
if ((GeN(t_450, 29.45) && LtN(t_450, 30D))) {
double d_519 = 0;
d_519 = ((ToNum(t_450) - 29.45) / 0.55);
L_484 = NewObj(3).Put("x", ((V)((228D + (d_519 * 50D))))).Put("y", ((V)(((FY_28 - 44D) - (ToNum(Invoke(E_10, "out", ((V)(d_519)))) * 230D))))).Put("r", ((V)((d_519 * 720D)))).V;
}
}
}
Call(put_18, V.Undef, shade_365, Get(L_484, "x"), Get(L_484, "y"), ((V)(1D)), Get(L_484, "r"), ((V)(1D)));
Set(Get(bulb_364, "style"), "boxShadow", ((V)(((GeN(t_450, 23.5) && LtN(t_450, 30D)) ? "0 0 10px 5px rgba(255,248,215,0.9)" : "none"))));
if (LtN(t_450, 36.4)) {
Call(put_18, V.Undef, pie_363, ((V)(60D)), ((V)(79D)), ((V)(1D)), ((V)(0D)), ((V)(1D)));
} else {
if (Truthy((F_480 is var _t520 && !Truthy(_t520) ? _t520 : (LtN(t_450, 36.6) ? V.True : V.False)))) {
Call(put_18, V.Undef, pie_363, Add(Get(F_480, "x"), ((V)(10D))), ((V)((ToNum(Get(F_480, "y")) - 50D))), ((V)(1D)), ((V)((-10D))), ((V)(1D)));
} else {
if (LtN(t_450, 37D)) {
V u_521 = default;
u_521 = Call(P_11, V.Undef, t_450, ((V)(36.6)), ((V)(37D)), Get(E_10, "lin"));
Call(put_18, V.Undef, pie_363, Call(lerp_9, V.Undef, ((V)(92D)), ((V)(172D)), u_521), ((V)((ToNum(Call(lerp_9, V.Undef, ((V)(112D)), ((V)(138D)), u_521)) - (FdLibm.Sin((System.Math.PI * ToNum(u_521))) * 26D)))), ((V)(1D)), ((V)((ToNum(u_521) * 300D))), ((V)(1D)));
} else {
Call(show_19, V.Undef, pie_363, (false ? V.True : V.False));
}
}
}
if (Truthy(((C_479 is var _t522 && !Truthy(_t522) ? _t522 : (GeN(t_450, 37D) ? V.True : V.False)) is var _t523 && !Truthy(_t523) ? _t523 : (LtN(t_450, 38.3) ? V.True : V.False)))) {
Call(put_18, V.Undef, splat_379, ((V)((ToNum(Get(C_479, "x")) - 6D))), ((V)((ToNum(Get(C_479, "y")) - 24D))), Call(P_11, V.Undef, t_450, ((V)(37D)), ((V)(37.1)), Get(E_10, "back")), ((V)(0D)), ((V)((1D - ToNum(Call(P_11, V.Undef, t_450, ((V)(37.9)), ((V)(38.3))))))));
} else {
Call(show_19, V.Undef, splat_379, (false ? V.True : V.False));
}
if ((GeN(t_450, 38.4) && LtN(t_450, 38.75))) {
V u_524 = default;
u_524 = Call(P_11, V.Undef, t_450, ((V)(38.4)), ((V)(38.75)), Get(E_10, "lin"));
Call(put_18, V.Undef, peel_378, Call(lerp_9, V.Undef, ((V)(64D)), ((V)(128D)), u_524), ((V)((ToNum(Call(lerp_9, V.Undef, ((V)(126D)), ((V)(161D)), u_524)) - (FdLibm.Sin((System.Math.PI * ToNum(u_524))) * 18D)))), ((V)(1D)), ((V)((ToNum(u_524) * 360D))), ((V)(1D)));
} else {
if ((GeN(t_450, 38.75) && LtN(t_450, 39.4))) {
Call(put_18, V.Undef, peel_378, ((V)(128D)), ((V)(161D)), ((V)(1D)), ((V)(0D)), ((V)(1D)));
} else {
if ((GeN(t_450, 39.4) && LtN(t_450, 40.1))) {
V u_525 = default;
u_525 = Call(P_11, V.Undef, t_450, ((V)(39.4)), ((V)(40.1)), Get(E_10, "lin"));
Call(put_18, V.Undef, peel_378, Call(lerp_9, V.Undef, ((V)(128D)), ((V)(60D)), u_525), Add(Call(lerp_9, V.Undef, ((V)(161D)), ((V)(30D)), u_525), ((V)(((ToNum(u_525) * ToNum(u_525)) * 60D)))), ((V)(1D)), ((V)(((-ToNum(u_525)) * 700D))), ((V)(1D)));
} else {
Call(show_19, V.Undef, peel_378, (false ? V.True : V.False));
}
}
}
M_485 = V.Null;
if (Truthy(((F_480 is var _t526 && !Truthy(_t526) ? _t526 : (GeN(t_450, 22.5) ? V.True : V.False)) is var _t527 && !Truthy(_t527) ? _t527 : (LtN(t_450, 23D) ? V.True : V.False)))) {
M_485 = Arr(((V)("!")), Add(Get(F_480, "x"), ((V)(16D))), ((V)((ToNum(Get(F_480, "y")) - 64D))), ((V)((ToNum(t_450) - 22.5))));
} else {
if (Truthy(((C_479 is var _t528 && !Truthy(_t528) ? _t528 : (GeN(t_450, 24.9) ? V.True : V.False)) is var _t529 && !Truthy(_t529) ? _t529 : (LtN(t_450, 26.1) ? V.True : V.False)))) {
M_485 = Arr(((V)("?")), Add(Get(C_479, "x"), ((V)(14D))), ((V)((ToNum(Get(C_479, "y")) - 64D))), ((V)((ToNum(t_450) - 24.9))));
} else {
if (Truthy(((C_479 is var _t530 && !Truthy(_t530) ? _t530 : (GeN(t_450, 29.55) ? V.True : V.False)) is var _t531 && !Truthy(_t531) ? _t531 : (LtN(t_450, 30D) ? V.True : V.False)))) {
M_485 = Arr(((V)("!")), Add(Get(C_479, "x"), ((V)(14D))), ((V)((ToNum(Get(C_479, "y")) - 66D))), ((V)((ToNum(t_450) - 29.55))));
}
}
}
if (Truthy(M_485)) {
if (!SEq(Get(mark_380, "textContent"), GetIdx(M_485, 0D))) {
Set(mark_380, "textContent", GetIdx(M_485, 0D));
}
Call(put_18, V.Undef, mark_380, GetIdx(M_485, 1D), GetIdx(M_485, 2D), Call(P_11, V.Undef, GetIdx(M_485, 3D), ((V)(0D)), ((V)(0.15)), Get(E_10, "back")), ((V)(8D)), ((V)(1D)));
} else {
Call(show_19, V.Undef, mark_380, (false ? V.True : V.False));
}
Invoke(hearts_381, "forEach", Fn((V _arrowThis540, int _argc532, V h_538, V k_539, V _a536, V _a537, V[] _rest533) => {
V on_541 = default;
V x_542 = default;
double y_543 = 0;
double a_544 = 0;
on_541 = (false ? V.True : V.False);
x_542 = ((V)(0D));
y_543 = 0D;
a_544 = 0D;
if (((GeN(t_450, 20.7) && LtN(t_450, 22.4)) && LtN(k_539, 3D))) {
a_544 = ((((ToNum(t_450) - 20.7) * 0.8) + (ToNum(k_539) / 3D)) % 1D);
x_542 = ((V)(((188D + ((ToNum(k_539) - 1D) * 9D)) + (FdLibm.Sin(ToNum(Add(((V)((a_544 * 6D))), k_539))) * 4D))));
y_543 = (106D - (a_544 * 42D));
on_541 = (true ? V.True : V.False);
} else {
if ((GeN(t_450, 52.8) && LtN(t_450, 55.4))) {
a_544 = ((((ToNum(t_450) - 52.8) * 0.7) + (ToNum(k_539) / 6D)) % 1D);
x_542 = Add(Add(GetIdx(Arr(((V)(100D)), ((V)(160D)), ((V)(220D))), (ToNum(k_539) % 3D)), ((V)((GtN(k_539, 2D) ? 8D : (-8D))))), ((V)((FdLibm.Sin(ToNum(Add(((V)((a_544 * 6D))), k_539))) * 4D))));
y_543 = (104D - (a_544 * 46D));
on_541 = (true ? V.True : V.False);
}
}
if (Truthy(on_541)) {
Call(put_18, V.Undef, h_538, x_542, ((V)(y_543)), ((V)((0.7 + (0.5 * a_544)))), ((V)((FdLibm.Sin((a_544 * 8D)) * 12D))), ((V)(FdLibm.Sin((System.Math.PI * a_544)))));
} else {
Call(show_19, V.Undef, h_538, (false ? V.True : V.False));
}
return default;
}, 2, "", true));
Invoke(stars_382, "forEach", Fn((V _arrowThis553, int _argc545, V s_551, V k_552, V _a549, V _a550, V[] _rest546) => {
if ((GeN(t_450, 40.1) && LtN(t_450, 41.8))) {
double a_554 = 0;
a_554 = ((ToNum(t_450) * 7D) + (ToNum(k_552) * 2.1));
Call(put_18, V.Undef, s_551, ((V)((182D + (FdLibm.Cos(a_554) * 13D)))), ((V)((126D + (FdLibm.Sin(a_554) * 4D)))), ((V)(1D)), ((V)(0D)), ((V)(1D)));
} else {
Call(show_19, V.Undef, s_551, (false ? V.True : V.False));
}
return default;
}, 2, "", true));
R_486 = Invoke(Arr(C_479, F_480, K_481), "filter", Fn((V _arrowThis562, int _argc555, V s_561, V _a558, V _a559, V _a560, V[] _rest556) => {
return (s_561 is var _t563 && !Truthy(_t563) ? _t563 : Get(s_561, "run"));
}, 1, "", true));
Invoke(dust_383, "forEach", Fn((V _arrowThis572, int _argc564, V d_570, V i_571, V _a568, V _a569, V[] _rest565) => {
V s_573 = default;
double a_574 = 0;
s_573 = GetIdx(R_486, System.Math.Floor((ToNum(i_571) / 3D)));
if (!(Truthy(s_573))) {
Call(show_19, V.Undef, d_570, (false ? V.True : V.False));
return default;
}
a_574 = (((ToNum(t_450) * 5D) + ((ToNum(i_571) % 3D) / 3D)) % 1D);
Call(put_18, V.Undef, d_570, ((V)((ToNum(Get(s_573, "x")) - (ToNum(Get(s_573, "run")) * (10D + (a_574 * 20D)))))), ((V)(((FY_28 - 3D) - (a_574 * 6D)))), ((V)((0.5 + (a_574 * 0.9)))), ((V)(0D)), ((V)((0.7 * (1D - a_574)))));
return default;
}, 2, "", true));
Invoke(lines_384, "forEach", Fn((V _arrowThis583, int _argc575, V l_581, V i_582, V _a579, V _a580, V[] _rest576) => {
V s_584 = default;
double j_585 = 0;
s_584 = GetIdx(R_486, System.Math.Floor((ToNum(i_582) / 3D)));
if (!(Truthy(s_584))) {
Call(show_19, V.Undef, l_581, (false ? V.True : V.False));
return default;
}
j_585 = (ToNum(i_582) % 3D);
Call(put_18, V.Undef, l_581, ((V)((ToNum(Get(s_584, "x")) - (ToNum(Get(s_584, "run")) * (34D + (j_585 * 6D)))))), ((V)(((ToNum(Get(s_584, "y")) - 18D) - (j_585 * 10D)))), ((V)(1D)), ((V)(0D)), ((V)((0.55 * (0.6 + (0.4 * FdLibm.Sin(((ToNum(t_450) * 40D) + j_585))))))));
return default;
}, 2, "", true));
Invoke(slices_385, "forEach", Fn((V _arrowThis594, int _argc586, V n_592, V k_593, V _a590, V _a591, V[] _rest587) => {
double a_595 = 0;
a_595 = (52D + (ToNum(k_593) * 0.4));
if (GeN(t_450, a_595)) {
Call(put_18, V.Undef, n_592, ((V)((Truthy(k_593) ? 200D : 120D))), ((V)(144D)), ((V)((1.4 * ToNum(Call(P_11, V.Undef, t_450, ((V)(a_595)), ((V)((a_595 + 0.3))), Get(E_10, "back")))))), ((V)(0D)), ((V)(1D)));
} else {
Call(show_19, V.Undef, n_592, (false ? V.True : V.False));
}
return default;
}, 2, "", true));
}
if ((GeN(t_450, 58.4) && LtN(t_450, 59.2))) {
double R_596 = 0;
R_596 = (ToNum(Call(P_11, V.Undef, t_450, ((V)(58.4)), ((V)(59.2)), Get(E_10, "in"))) * 280D);
Call(show_19, V.Undef, burn_386, (true ? V.True : V.False));
Set(Get(burn_386, "style"), "background", ((V)(JsStrBuf.Begin().S("radial-gradient(circle at 196px 82px,#fffdf6 0,#fffdf6 ").V(Invoke(((V)(R_596)), "toFixed", ((V)(1D)))).S("px,#ffcf6a ").V(Invoke(((V)((R_596 + 2D))), "toFixed", ((V)(1D)))).S("px,#6a3008 ").V(Invoke(((V)((R_596 + 5D))), "toFixed", ((V)(1D)))).S("px,rgba(40,20,5,0) ").V(Invoke(((V)((R_596 + 12D))), "toFixed", ((V)(1D)))).S("px)").End())));
} else {
Call(show_19, V.Undef, burn_386, (false ? V.True : V.False));
}
if (GeN(t_450, 59.2)) {
Call(show_19, V.Undef, flap_387, (true ? V.True : V.False));
Set(Get(flap_387, "style"), "opacity", Invoke(((V)((0.92 + (0.08 * System.Math.Abs(FdLibm.Sin((ToNum(t_450) * 47D))))))), "toFixed", ((V)(3D))));
Set(Get(bar_388, "style"), "left", ((V)(JsStrBuf.Begin().V(Invoke(((V)(((((ToNum(t_450) * 14D) % 1D) * 340D) - 20D))), "toFixed", ((V)(1D)))).S("px").End())));
Set(Get(bar_388, "style"), "opacity", Invoke(((V)((0.5 + (0.5 * System.Math.Abs(FdLibm.Sin((ToNum(t_450) * 29D))))))), "toFixed", ((V)(2D))));
} else {
Call(show_19, V.Undef, flap_387, (false ? V.True : V.False));
}
lit_454 = (LtN(t_450, 0D) ? 0D : (GeN(t_450, 59.2) ? 1.25 : (GeN(t_450, 58.4) ? (0.4 + (ToNum(Call(P_11, V.Undef, t_450, ((V)(58.4)), ((V)(59.2)))) * 0.8)) : (Truthy(lead_451) ? 0.6 : (GeN(ci_452, 0D) ? 0.28 : 0.85)))));
return NewObj(2).Put("rgb", ((V)("240,220,180"))).Put("lit", ((V)(lit_454))).V;
return default;
}, 1, "upd", false);
root_349 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;width:320px;height:180px;overflow:hidden;background:#0d0a06;font-family:'Limelight',Georgia,serif;")));
film_350 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;inset:0;filter:sepia(0.85) saturate(0.65) contrast(1.22) brightness(0.96);")), root_349);
ld_351 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;inset:0;display:none;background:#d8cbb0;")), film_350);
ldW_352 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:90px;top:20px;width:140px;height:140px;border-radius:50%;")), ld_351);
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:159px;top:0;width:1.5px;height:180px;background:#3a2f22;")), ld_351);
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:89px;width:320px;height:1.5px;background:#3a2f22;")), ld_351);
Invoke(Arr(((V)(140D)), ((V)(112D))), "forEach", Fn((V _arrowThis604, int _argc597, V d_603, V _a600, V _a601, V _a602, V[] _rest598) => {
return Call(el_14, V.Undef, ((V)("div")), ((V)(JsStrBuf.Begin().S("position:absolute;left:").N((160D - (ToNum(d_603) / 2D))).S("px;top:").N((90D - (ToNum(d_603) / 2D))).S("px;width:").V(d_603).S("px;height:").V(d_603).S("px;border-radius:50%;border:2px solid #f6efe0;box-sizing:border-box;").End())), ld_351);
}, 1, "", true));
ldN_353 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;inset:0;display:flex;align-items:center;justify-content:center;font-size:78px;line-height:1;color:#241b12;")), ld_351, ((V)("3")));
cd_354 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;inset:0;display:none;background:#100c07;")), film_350);
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:10px;top:10px;right:10px;bottom:10px;border:1.5px solid #e9dfc6;border-radius:3px;")), cd_354);
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:15px;top:15px;right:15px;bottom:15px;border:0.75px solid #e9dfc6;")), cd_354);
Invoke(Arr(Arr(((V)(16D)), ((V)(16D))), Arr(((V)(304D)), ((V)(16D))), Arr(((V)(16D)), ((V)(164D))), Arr(((V)(304D)), ((V)(164D)))), "forEach", Fn((V _arrowThis616, int _argc605, V _a607, V _a608, V _a609, V _a610, V[] _rest606) => {
V x_613 = default;
V y_615 = default;
{ V _t611 = ListOf(_a607);
{ V _t612 = GetIdx(_t611, 0D);
x_613 = _t612; }
{ V _t614 = GetIdx(_t611, 1D);
y_615 = _t614; }
}
return Call(el_14, V.Undef, ((V)("div")), ((V)(JsStrBuf.Begin().S("position:absolute;left:").N((ToNum(x_613) - 4D)).S("px;top:").N((ToNum(y_615) - 4D)).S("px;width:8px;height:8px;background:#e9dfc6;transform:rotate(45deg);").End())), cd_354);
}, 1, "", true));
cdT_355 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;inset:0;display:flex;flex-direction:column;align-items:center;justify-content:center;text-align:center;color:#f3ebd8;font-size:16px;line-height:1.35;padding:0 24px;")), cd_354);
cdI_356 = ((V)((-1D)));
sc_357 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;inset:0;display:none;background:#0d0a06;")), film_350);
set_358 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;inset:0;")), sc_357);
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;width:320px;height:138px;background:repeating-linear-gradient(90deg,rgba(70,50,25,0.16) 0 6px,rgba(0,0,0,0) 6px 16px),#bfae8c;")), set_358);
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:112px;width:320px;height:26px;background:repeating-linear-gradient(90deg,rgba(40,25,10,0.35) 0 1px,rgba(0,0,0,0) 1px 22px),#8f7656;border-top:3px solid #8a7050;box-sizing:border-box;")), set_358);
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:138px;width:320px;height:42px;background:repeating-conic-gradient(#3d3024 0% 25%,#d6c9ae 0% 50%) 0 0/26px 14px;")), set_358);
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:138px;width:320px;height:10px;background:linear-gradient(rgba(30,20,10,0.35),rgba(30,20,10,0));")), set_358);
win_359 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:186px;top:20px;width:56px;height:54px;background:linear-gradient(#fbf8f0,#eee6d2);border:3px solid #6b5236;box-sizing:border-box;")), set_358);
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:23.5px;top:0;width:3px;height:100%;background:#6b5236;")), win_359);
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:22.5px;width:100%;height:3px;background:#6b5236;")), win_359);
Invoke(Arr(((V)(180D)), ((V)(230D))), "forEach", Fn((V _arrowThis624, int _argc617, V x_623, V _a620, V _a621, V _a622, V[] _rest618) => {
return Call(el_14, V.Undef, ((V)("div")), ((V)(JsStrBuf.Begin().S("position:absolute;left:").V(x_623).S("px;top:16px;width:18px;height:64px;background:repeating-linear-gradient(90deg,#d9c7a6 0 3px,#c8b38e 3px 6px);border-radius:0 0 8px 8px;").End())), set_358);
}, 1, "", true));
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:176px;top:13px;width:76px;height:5px;background:#6b5236;border-radius:3px;")), set_358);
clk_360 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:104px;top:24px;width:26px;height:26px;border-radius:50%;background:#f6f0e2;border:2.5px solid #5d4630;box-sizing:border-box;")), set_358);
hM_361 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:10.5px;top:2px;width:1.6px;height:9px;background:#2a2018;transform-origin:50% 100%;")), clk_360);
hH_362 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:10.3px;top:5px;width:2px;height:6px;background:#2a2018;transform-origin:50% 100%;")), clk_360);
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:26px;top:84px;width:68px;height:4px;background:#6b5236;border-radius:2px;")), set_358);
Invoke(Arr(((V)(32D)), ((V)(84D))), "forEach", Fn((V _arrowThis632, int _argc625, V x_631, V _a628, V _a629, V _a630, V[] _rest626) => {
return Call(el_14, V.Undef, ((V)("div")), ((V)(JsStrBuf.Begin().S("position:absolute;left:").V(x_631).S("px;top:88px;width:4px;height:8px;background:#6b5236;").End())), set_358);
}, 1, "", true));
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:30px;top:68px;width:12px;height:16px;border-radius:3px 3px 2px 2px;background:linear-gradient(90deg,#cfd8d8,#eef3f2 40%,#b9c4c4);border:1px solid #7a8282;box-sizing:border-box;")), set_358);
pie_363 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;width:26px;height:11px;")), sc_357, ((V)("<svg viewBox=\"0 0 26 11\" width=\"26\" height=\"11\"><path d=\"M1 5 L25 5 L22 10.5 L4 10.5Z\" fill=\"#8f8a80\"></path><ellipse cx=\"13\" cy=\"5\" rx=\"12.5\" ry=\"4.2\" fill=\"#d9a866\"></ellipse><path d=\"M4 4.5 Q13 0.5 22 4.5\" stroke=\"#f6e2b8\" stroke-width=\"1.6\" fill=\"none\"></path><circle cx=\"9\" cy=\"4\" r=\"0.9\" fill=\"#a8743a\"></circle><circle cx=\"15\" cy=\"3.4\" r=\"0.9\" fill=\"#a8743a\"></circle></svg>")));
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:259px;top:157px;width:26px;height:7px;border-radius:50%;background:#4a3826;")), set_358);
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:270.5px;top:94px;width:3px;height:66px;background:#4a3826;")), set_358);
bulb_364 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:266px;top:86px;width:12px;height:12px;border-radius:50%;background:#fffbe8;")), set_358);
shade_365 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;width:36px;height:24px;")), sc_357, ((V)("<svg viewBox=\"0 0 36 24\" width=\"36\" height=\"24\"><path d=\"M9 1 L27 1 L35 20 L1 20Z\" fill=\"#ead6a6\" stroke=\"#6b5236\" stroke-width=\"1.2\"></path><path d=\"M13 1 L10 20 M18 1 L18 20 M23 1 L26 20\" stroke=\"#c8ae78\" stroke-width=\"1\"></path><path d=\"M1 20 L35 20\" stroke=\"#6b5236\" stroke-width=\"1.6\"></path><path d=\"M3 21 v2.5 M7 21 v2.5 M11 21 v2.5 M15 21 v2.5 M19 21 v2.5 M23 21 v2.5 M27 21 v2.5 M31 21 v2.5\" stroke=\"#8a7050\" stroke-width=\"1.1\"></path></svg>")));
tsh_366 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:118px;top:154px;width:84px;height:10px;border-radius:50%;background:rgba(30,20,10,0.3);")), sc_357);
tb_367 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;width:320px;height:180px;")), sc_357);
Invoke(Arr(((V)(132D)), ((V)(184D))), "forEach", Fn((V _arrowThis640, int _argc633, V x_639, V _a636, V _a637, V _a638, V[] _rest634) => {
return Call(el_14, V.Undef, ((V)("div")), ((V)(JsStrBuf.Begin().S("position:absolute;left:").V(x_639).S("px;top:126px;width:4px;height:32px;background:#6b5236;").End())), tb_367);
}, 1, "", true));
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:124px;top:112px;width:72px;height:22px;border-radius:3px 3px 0 0;background:radial-gradient(circle at 4px 22px,rgba(0,0,0,0) 3.5px,#f2ead8 4px) -4px 0/8px 22px repeat-x;")), tb_367);
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:124px;top:112px;width:72px;height:4px;border-radius:2px;background:#fbf7ee;box-shadow:0 1px 0 rgba(90,70,40,0.35);")), tb_367);
ck_368 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;width:30px;height:30px;transform-origin:50% 100%;")), sc_357);
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:-2px;bottom:0;width:34px;height:4px;border-radius:50%;background:#fbf7ee;border:1px solid #b9a98a;box-sizing:border-box;")), ck_368);
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:2px;bottom:3px;width:26px;height:12px;border-radius:3px 3px 2px 2px;background:#f2b6c2;")), ck_368);
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:2px;bottom:11px;width:26px;height:5px;border-radius:3px;background:radial-gradient(circle at 2.2px 4px,#fffaf2 2.2px,rgba(0,0,0,0) 2.6px) 0 1px/4.33px 5px repeat-x,linear-gradient(#fffaf2 0 2px,rgba(0,0,0,0) 2px);")), ck_368);
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:7px;bottom:15px;width:16px;height:9px;border-radius:3px 3px 1px 1px;background:#bfe6d2;")), ck_368);
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:7px;bottom:20px;width:16px;height:4px;border-radius:2px;background:radial-gradient(circle at 2px 3px,#fffaf2 2px,rgba(0,0,0,0) 2.4px) 0 1px/4px 4px repeat-x,linear-gradient(#fffaf2 0 1.6px,rgba(0,0,0,0) 1.6px);")), ck_368);
Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:13.8px;bottom:24px;width:2.6px;height:7px;background:repeating-linear-gradient(160deg,#fffaf2 0 1.5px,#e88aa0 1.5px 3px);")), ck_368);
flame_369 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:12.6px;bottom:30.5px;width:5px;height:7px;border-radius:50% 50% 50% 50%/62% 62% 38% 38%;background:radial-gradient(circle at 50% 70%,#fffbe0 0 30%,#ffc94a 60%,#ff8a2a);transform-origin:50% 100%;display:none;")), ck_368);
bite1_370 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:23px;bottom:9px;width:9px;height:9px;border-radius:50%;background:#bfae8c;display:none;")), ck_368);
bite2_371 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:3.5px;bottom:18.5px;width:7px;height:7px;border-radius:50%;background:#bfae8c;display:none;")), ck_368);
cksh_372 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;width:40px;height:8px;border-radius:50%;background:rgba(30,20,10,0.4);display:none;")), sc_357);
shd_373 = Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis647, int _argc641, V _a643, V _a644, V _a645, V _a646, V[] _rest642) => {
return Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;width:44px;height:7px;border-radius:50%;background:rgba(30,20,10,0.32);display:none;")), sc_357);
}, 0, "", true));
chef_374 = Call(actor_16, V.Undef, sc_357, ((V)("chefbun")), ((V)(W_29)));
fry_375 = Call(actor_16, V.Undef, sc_357, ((V)("frybo")), ((V)(W_29)));
cak_376 = Call(actor_16, V.Undef, sc_357, ((V)("cakey")), ((V)(W_29)));
sil_377 = Call(actor_16, V.Undef, sc_357, ((V)("chefbun")), ((V)(120D)));
Set(Get(sil_377, "style"), "filter", ((V)("brightness(0) blur(1.5px)")));
Set(Get(sil_377, "style"), "opacity", ((V)("0.4")));
Invoke(Arr(sil_377, chef_374, fry_375, cak_376), "forEach", Fn((V _arrowThis656, int _argc648, V n_654, V i_655, V _a652, V _a653, V[] _rest649) => {
Set(Get(n_654, "style"), "zIndex", ((V)((Truthy(i_655) ? 5D : 1D))));
return default;
}, 2, "", true));
Invoke(Arr(ck_368, shade_365, pie_363), "forEach", Fn((V _arrowThis664, int _argc657, V n_663, V _a660, V _a661, V _a662, V[] _rest658) => {
Set(Get(n_663, "style"), "zIndex", ((V)(6D)));
return default;
}, 1, "", true));
peel_378 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;width:18px;height:10px;z-index:6;display:none;")), sc_357, ((V)("<svg viewBox=\"0 0 18 10\" width=\"18\" height=\"10\"><path d=\"M9 7 C6 2 3 2 1 4 C4 4 6 6 8 8Z M9 7 C12 2 15 2 17 4 C14 4 12 6 10 8Z M8 8 C8 4 9 1 10 1 C10 4 10 6 10 8Z\" fill=\"#f2d65a\" stroke=\"#6b5236\" stroke-width=\"0.7\"></path><ellipse cx=\"9\" cy=\"8.4\" rx=\"2.4\" ry=\"1.4\" fill=\"#d9b23a\"></ellipse></svg>")));
splat_379 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;width:36px;height:29px;z-index:7;display:none;")), sc_357, ((V)("<svg viewBox=\"0 0 30 24\" width=\"36\" height=\"29\"><path d=\"M15 2 C19 1 20 5 23 4 C27 3 29 8 26 10 C30 12 28 17 24 16 C25 21 20 23 17 20 C14 24 9 22 9 18 C4 20 1 15 4 12 C0 9 3 4 7 6 C8 2 12 0 15 2Z\" fill=\"#7a3a2a\" stroke=\"#2a1a10\" stroke-width=\"1\"></path><path d=\"M11 6 C14 4 18 6 20 8 C23 10 22 14 19 15 C16 17 11 16 9 13 C7 10 8 7 11 6Z\" fill=\"#fbf3e0\"></path><circle cx=\"22\" cy=\"6\" r=\"1.4\" fill=\"#d9a866\"></circle><circle cx=\"6\" cy=\"14\" r=\"1.4\" fill=\"#d9a866\"></circle><path d=\"M10 20 q0 3.5 1.5 3.5 q1.5 0 1.5-3.5\" fill=\"#7a3a2a\"></path></svg>")));
mark_380 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;font-size:20px;line-height:1;color:#241b12;text-shadow:0 0 2px #fff8e8,0 0 2px #fff8e8;z-index:8;display:none;")), sc_357, ((V)("!")));
hearts_381 = Array_from(NewObj(1).Put("length", ((V)(6D))).V, Fn((V _arrowThis671, int _argc665, V _a667, V _a668, V _a669, V _a670, V[] _rest666) => {
return Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;font-size:11px;line-height:1;color:#e05a7a;z-index:8;display:none;")), sc_357, ((V)("\u2665")));
}, 0, "", true));
stars_382 = Array_from(NewObj(1).Put("length", ((V)(3D))).V, Fn((V _arrowThis678, int _argc672, V _a674, V _a675, V _a676, V _a677, V[] _rest673) => {
return Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;font-size:9px;line-height:1;color:#f6d36a;text-shadow:0 0 1px #241b12;z-index:8;display:none;")), sc_357, ((V)("\u2726")));
}, 0, "", true));
dust_383 = Array_from(NewObj(1).Put("length", ((V)(6D))).V, Fn((V _arrowThis685, int _argc679, V _a681, V _a682, V _a683, V _a684, V[] _rest680) => {
return Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;width:9px;height:9px;border-radius:50%;background:#efe6d4;border:1px solid rgba(90,70,40,0.4);box-sizing:border-box;z-index:4;display:none;")), sc_357);
}, 0, "", true));
lines_384 = Array_from(NewObj(1).Put("length", ((V)(6D))).V, Fn((V _arrowThis692, int _argc686, V _a688, V _a689, V _a690, V _a691, V[] _rest687) => {
return Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;width:18px;height:1.5px;border-radius:1px;background:#3a2f22;z-index:4;display:none;")), sc_357);
}, 0, "", true));
slices_385 = Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _arrowThis699, int _argc693, V _a695, V _a696, V _a697, V _a698, V[] _rest694) => {
return Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;left:0;top:0;width:20px;height:12px;z-index:8;display:none;")), sc_357, ((V)("<svg viewBox=\"0 0 20 12\" width=\"20\" height=\"12\"><ellipse cx=\"10\" cy=\"10\" rx=\"9.5\" ry=\"2\" fill=\"#fbf7ee\" stroke=\"#b9a98a\" stroke-width=\"0.6\"></ellipse><path d=\"M4 9 L16 9 L16 4 L4 6.5Z\" fill=\"#f2b6c2\"></path><path d=\"M4 6.5 L16 4 L16 2.4 L4 5Z\" fill=\"#fffaf2\"></path></svg>")));
}, 0, "", true));
burn_386 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;inset:0;display:none;z-index:20;")), root_349);
flap_387 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;inset:0;display:none;background:#fff8e8;z-index:21;")), root_349);
bar_388 = Call(el_14, V.Undef, ((V)("div")), ((V)("position:absolute;top:0;width:16px;height:180px;background:#2a1e12;")), flap_387);
walk_389 = Fn((V _arrowThis714, int _argc700, V t_706, V t0_707, V t1_708, V x0_709, V[] _rest701) => {
double ph_715 = 0;
V x1_710 = default;
V v_711 = default;
V amp_713 = default;
x1_710 = (_argc700 > 4 ? _rest701[0] : V.Undef);
v_711 = (_argc700 > 5 ? _rest701[1] : V.Undef);
{ V _t712 = (_argc700 > 6 ? _rest701[2] : V.Undef); if (_t712.IsUndef) _t712 = ((V)(2.5));
amp_713 = _t712; }
ph_715 = ((ToNum(t_706) - ToNum(t0_707)) * 10D);
return NewObj(4).Put("v", v_711).Put("x", Call(lerp_9, V.Undef, x0_709, x1_710, Call(cl_8, V.Undef, ((V)(((ToNum(t_706) - ToNum(t0_707)) / (ToNum(t1_708) - ToNum(t0_707)))))))).Put("y", ((V)((FY_28 - (System.Math.Abs(FdLibm.Sin(ph_715)) * ToNum(amp_713)))))).Put("r", ((V)((FdLibm.Sin(ph_715) * 3D)))).V;
return default;
}, 7, "", true);
run_390 = Fn((V _arrowThis727, int _argc716, V t_722, V t0_723, V t1_724, V x0_725, V[] _rest717) => {
double d_728 = 0;
double ph_729 = 0;
V x1_726 = default;
x1_726 = (_argc716 > 4 ? _rest717[0] : V.Undef);
d_728 = (Gt(x1_726, x0_725) ? 1D : (-1D));
ph_729 = ((ToNum(t_722) - ToNum(t0_723)) * 19D);
return NewObj(5).Put("v", ((V)(((d_728 > 0D) ? "right" : "left")))).Put("x", Call(lerp_9, V.Undef, x0_725, x1_726, Call(cl_8, V.Undef, ((V)(((ToNum(t_722) - ToNum(t0_723)) / (ToNum(t1_724) - ToNum(t0_723)))))))).Put("y", ((V)((FY_28 - (System.Math.Abs(FdLibm.Sin(ph_729)) * 5D))))).Put("r", ((V)(((d_728 * 9D) + (FdLibm.Sin(ph_729) * 2D))))).Put("run", ((V)(d_728))).V;
return default;
}, 5, "", true);
stand_391 = Fn((V _arrowThis739, int _argc730, V v_736, V x_737, V o_738, V _a735, V[] _rest731) => {
return Object_assign(NewObj(4).Put("v", v_736).Put("x", x_737).Put("y", ((V)(FY_28))).Put("r", ((V)(0D))).V, o_738);
}, 3, "", true);
return NewObj(2).Put("root", root_349).Put("upd", upd_395).V;
return default;
}, 0, "cakeCaper", false);
cakeScore_33 = Fn((V _self740, int _argc741, V Q_747, V _a744, V _a745, V _a746, V[] _rest742) => {
V I_748 = default;
V r_749 = default;
if (_self740.IsNullish) _self740 = GlobalV;
I_748 = Call(kit_22, V.Undef, Q_747);
r_749 = Call(rnd_20, V.Undef, ((V)(7D)));
Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "forEach", Fn((V _arrowThis757, int _argc750, V s_756, V _a753, V _a754, V _a755, V[] _rest751) => {
return Invoke(Q_747, "tone", Add(s_756, ((V)(0.02))), ((V)(1000D)), ((V)(0.13)), NewObj(1).Put("vol", ((V)(0.07))).V);
}, 1, "", true));
{
double t_758 = 0;
t_758 = 0D;
while (true) {
if (!((t_758 < 59.2))) break;
Invoke(Q_747, "noise", ((V)(t_758)), ((V)(0.012)), NewObj(2).Put("f", ((V)(2600D))).Put("vol", ((V)((0.01 + (0.005 * (Round((t_758 * 12D)) % 2D)))))).V);
t_758 = (t_758 + (1D / 12D));
}
}
{
double i_760 = 0;
i_760 = 0D;
while (true) {
if (!((i_760 < 160D))) break;
Invoke(Q_747, "noise", ((V)((ToNum(Call(r_749, V.Undef)) * 59D))), ((V)(0.008)), NewObj(2).Put("f", ((V)(1200D))).Put("vol", ((V)((0.015 + (0.03 * ToNum(Call(r_749, V.Undef))))))).V);
i_760++;
}
}
Call(rag_25, V.Undef, I_748, ((V)(3D)), ((V)(16.4)), ((V)(0.4)), ((V)(0.085)));
Call(sneak_26, V.Undef, I_748, ((V)(16.4)), ((V)(20.3)), ((V)(0.3)), ((V)(0.1)));
{
double k_762 = 0;
k_762 = 0D;
while (true) {
if (!((k_762 < 5D))) break;
Invoke(I_748, "piano", ((V)(((16.4 + (k_762 * 0.52)) + 0.26))), ((V)(91D)), ((V)(0.1)), ((V)(0.05)));
k_762++;
}
}
Invoke(I_748, "slurp", ((V)(20.3)));
Invoke(Arr(((V)(72D)), ((V)(76D)), ((V)(79D)), ((V)(83D)), ((V)(84D)), ((V)(83D)), ((V)(79D)), ((V)(76D)), ((V)(72D)), ((V)(76D)), ((V)(79D)), ((V)(83D))), "forEach", Fn((V _arrowThis772, int _argc764, V m_770, V i_771, V _a768, V _a769, V[] _rest765) => {
return Invoke(I_748, "piano", ((V)((20.7 + (ToNum(i_771) * 0.14)))), m_770, ((V)(0.3)), ((V)(0.05)));
}, 2, "", true));
Invoke(I_748, "thud", ((V)(22.4)), ((V)(0.35)));
Invoke(I_748, "thud", ((V)(22.75)), ((V)(0.4)));
{
double k_773 = 0;
k_773 = 0D;
while (true) {
if (!((k_773 < 8D))) break;
Invoke(I_748, "chord", ((V)((22.55 + (k_773 * 0.06)))), Arr(((V)(56D)), ((V)(59D)), ((V)(62D)), ((V)(65D))), ((V)(0.1)), ((V)(0.04)));
k_773++;
}
}
{
double k_775 = 0;
k_775 = 0D;
while (true) {
if (!((k_775 < 5D))) break;
Invoke(I_748, "piano", ((V)((22.9 + (k_775 * 0.12)))), ((V)((84D + (k_775 * 2D)))), ((V)(0.08)), ((V)(0.05)));
k_775++;
}
}
Call(sneak_26, V.Undef, I_748, ((V)(23.9)), ((V)(29.3)), ((V)(0.6)), ((V)(0.07)));
Invoke(I_748, "tok", ((V)(26.5)));
Invoke(I_748, "tok", ((V)(26.62)), ((V)(0.1)));
Invoke(Arr(((V)(27.5)), ((V)(28.7))), "forEach", Fn((V _arrowThis784, int _argc777, V t_783, V _a780, V _a781, V _a782, V[] _rest778) => {
return Invoke(I_748, "chord", t_783, Arr(((V)(48D)), ((V)(54D)), ((V)(60D)), ((V)(63D))), ((V)(0.4)), ((V)(0.09)));
}, 1, "", true));
Invoke(Q_747, "tone", ((V)(29.05)), ((V)(300D)), ((V)(0.32)), NewObj(6).Put("to", ((V)(560D))).Put("slide", ((V)(0.3))).Put("type", ((V)("sawtooth"))).Put("lp", ((V)(1400D))).Put("vol", ((V)(0.04))).Put("at", ((V)(0.05))).V);
Invoke(Q_747, "noise", ((V)(29.4)), ((V)(0.25)), NewObj(4).Put("ft", ((V)("bandpass"))).Put("f", ((V)(2200D))).Put("q", ((V)(0.9))).Put("vol", ((V)(0.28))).V);
Invoke(I_748, "whistle", ((V)(29.45)), ((V)(600D)), ((V)(1900D)), ((V)(0.5)));
Invoke(I_748, "chord", ((V)(29.55)), Arr(((V)(55D)), ((V)(61D)), ((V)(64D)), ((V)(70D))), ((V)(0.5)), ((V)(0.08)));
Invoke(I_748, "chord", ((V)(30D)), Arr(((V)(36D)), ((V)(43D)), ((V)(48D)), ((V)(55D))), ((V)(1.2)), ((V)(0.1)));
Invoke(I_748, "crash", ((V)(30D)));
Call(rag_25, V.Undef, I_748, ((V)(31.6)), ((V)(39.4)), ((V)(0.25)), ((V)(0.08)));
Invoke(Arr(((V)(31.6)), ((V)(33.8))), "forEach", Fn((V _arrowThis792, int _argc785, V t_791, V _a788, V _a789, V _a790, V[] _rest786) => {
return Invoke(I_748, "whistle", t_791, ((V)(900D)), ((V)(1500D)), ((V)(0.25)), ((V)(0.05)));
}, 1, "", true));
Invoke(I_748, "whoosh", ((V)(36.6)));
Invoke(I_748, "splat", ((V)(37D)));
Invoke(I_748, "whistle", ((V)(38.4)), ((V)(1200D)), ((V)(1800D)), ((V)(0.3)), ((V)(0.05)));
Invoke(I_748, "whistle", ((V)(39.4)), ((V)(420D)), ((V)(1700D)), ((V)(0.35)), ((V)(0.1)));
Invoke(I_748, "thud", ((V)(40.1)), ((V)(0.55)));
Invoke(Q_747, "noise", ((V)(40.1)), ((V)(0.3)), NewObj(3).Put("ft", ((V)("lowpass"))).Put("f", ((V)(900D))).Put("vol", ((V)(0.2))).V);
{
double k_793 = 0;
k_793 = 0D;
while (true) {
if (!((k_793 < 5D))) break;
Invoke(I_748, "chirp", ((V)((40.3 + (k_793 * 0.24)))));
k_793++;
}
}
Invoke(I_748, "tok", ((V)(41.2)), ((V)(0.08)));
Invoke(I_748, "tok", ((V)(41.35)), ((V)(0.08)));
Invoke(I_748, "thud", ((V)(41.6)), ((V)(0.4)));
Invoke(I_748, "tok", ((V)(41.6)), ((V)(0.16)));
Invoke(I_748, "whistle", ((V)(41.6)), ((V)(500D)), ((V)(2100D)), ((V)(0.9)), ((V)(0.08)));
{
double t_795 = 0;
t_795 = 41.9;
while (true) {
if (!((t_795 < 46.2))) break;
Invoke(Q_747, "noise", ((V)(t_795)), ((V)(0.04)), NewObj(4).Put("ft", ((V)("bandpass"))).Put("f", ((V)(1600D))).Put("q", ((V)(0.8))).Put("vol", ((V)((0.025 + ((0.07 * (t_795 - 41.9)) / 4.3))))).V);
t_795 = (t_795 + 0.045);
}
}
Invoke(I_748, "whistle", ((V)(45.4)), ((V)(2000D)), ((V)(520D)), ((V)(0.8)), ((V)(0.08)));
Invoke(I_748, "thud", ((V)(45.45)), ((V)(0.3)));
Invoke(I_748, "thud", ((V)(45.5)), ((V)(0.3)));
Invoke(I_748, "crash", ((V)(46.2)), ((V)(0.16)));
Invoke(I_748, "chord", ((V)(46.2)), Arr(((V)(48D)), ((V)(55D)), ((V)(60D)), ((V)(64D)), ((V)(67D)), ((V)(72D))), ((V)(0.9)), ((V)(0.08)), ((V)(0.02)));
Invoke(Q_747, "tone", ((V)(46.2)), ((V)(200D)), ((V)(0.3)), NewObj(3).Put("to", ((V)(620D))).Put("slide", ((V)(0.25))).Put("vol", ((V)(0.12))).V);
Call(rag_25, V.Undef, I_748, ((V)(46.4)), ((V)(48D)), ((V)(0.4)), ((V)(0.08)));
Invoke(Arr(Arr(((V)(0D)), ((V)(67D)), ((V)(0.75))), Arr(((V)(0.75)), ((V)(67D)), ((V)(0.25))), Arr(((V)(1D)), ((V)(69D)), ((V)(1D))), Arr(((V)(2D)), ((V)(67D)), ((V)(1D))), Arr(((V)(3D)), ((V)(72D)), ((V)(1D))), Arr(((V)(4D)), ((V)(71D)), ((V)(2D)))), "forEach", Fn((V _arrowThis810, int _argc797, V _a799, V _a800, V _a801, V _a802, V[] _rest798) => {
V o_805 = default;
V m_807 = default;
V d_809 = default;
{ V _t803 = ListOf(_a799);
{ V _t804 = GetIdx(_t803, 0D);
o_805 = _t804; }
{ V _t806 = GetIdx(_t803, 1D);
m_807 = _t806; }
{ V _t808 = GetIdx(_t803, 2D);
d_809 = _t808; }
}
Invoke(I_748, "piano", ((V)((48.3 + (ToNum(o_805) * 0.32)))), Add(m_807, ((V)(12D))), ((V)(((ToNum(d_809) * 0.32) + 0.1))), ((V)(0.08)));
Invoke(I_748, "piano", ((V)((48.3 + (ToNum(o_805) * 0.32)))), m_807, ((V)((ToNum(d_809) * 0.32))), ((V)(0.04)));
return default;
}, 1, "", true));
Call(rag_25, V.Undef, I_748, ((V)(50.4)), ((V)(55.6)), ((V)(0.4)), ((V)(0.085)), ((V)(4D)));
Invoke(I_748, "slurp", ((V)(55.1)), ((V)(0.08)));
Invoke(Arr(((V)(84D)), ((V)(81D)), ((V)(79D)), ((V)(76D)), ((V)(72D)), ((V)(76D)), ((V)(79D))), "forEach", Fn((V _arrowThis819, int _argc811, V m_817, V i_818, V _a815, V _a816, V[] _rest812) => {
return Invoke(I_748, "piano", ((V)((55.4 + (ToNum(i_818) * 0.08)))), m_817, ((V)(0.1)), ((V)(0.06)));
}, 2, "", true));
Invoke(I_748, "chord", ((V)(56.2)), Arr(((V)(43D)), ((V)(53D)), ((V)(59D)), ((V)(62D)), ((V)(67D))), ((V)(0.7)), ((V)(0.07)), ((V)(0.04)));
Invoke(I_748, "chord", ((V)(56.9)), Arr(((V)(36D)), ((V)(48D)), ((V)(55D)), ((V)(60D)), ((V)(64D)), ((V)(72D))), ((V)(1.6)), ((V)(0.08)), ((V)(0.04)));
Invoke(Q_747, "noise", ((V)(58.4)), ((V)(0.8)), NewObj(5).Put("ft", ((V)("lowpass"))).Put("f", ((V)(400D))).Put("fTo", ((V)(3000D))).Put("vol", ((V)(0.06))).Put("at", ((V)(0.5))).V);
{
double t_820 = 0;
t_820 = 59.2;
while (true) {
if (!((t_820 < 60D))) break;
Invoke(Q_747, "noise", ((V)(t_820)), ((V)(0.015)), NewObj(2).Put("f", ((V)(1200D))).Put("vol", ((V)(0.06))).V);
t_820 = (t_820 + (1D / 14D));
}
}
return default;
}, 1, "cakeScore", false);
record_36 = Fn((V _self822, int _argc823, V mv_829, V _a826, V _a827, V _a828, V[] _rest824) => {
V R_830 = default;
V Q_831 = default;
if (_self822.IsNullish) _self822 = GlobalV;
if (Truthy(Get(mv_829, "_rec"))) {
return Get(mv_829, "_rec");
}
R_830 = Arr();
Q_831 = NewObj(2).Put("tone", Fn((V _arrowThis842, int _argc832, V t_838, V f_839, V d_840, V o_841, V[] _rest833) => {
return Invoke(R_830, "push", Arr(t_838, ((V)("t")), f_839, d_840, (o_841 is var _t843 && Truthy(_t843) ? _t843 : NewObj(0).V)));
}, 4, "tone", true)).Put("noise", Fn((V _arrowThis853, int _argc844, V t_850, V d_851, V o_852, V _a849, V[] _rest845) => {
return Invoke(R_830, "push", Arr(t_850, ((V)("n")), d_851, (o_852 is var _t854 && Truthy(_t854) ? _t854 : NewObj(0).V)));
}, 3, "noise", true)).V;
if (Truthy(Get(mv_829, "score"))) {
Invoke(mv_829, "score", Q_831);
}
Invoke(R_830, "sort", Fn((V _arrowThis863, int _argc855, V a_861, V b_862, V _a859, V _a860, V[] _rest856) => {
return ((V)((ToNum(GetIdx(a_861, 0D)) - ToNum(GetIdx(b_862, 0D)))));
}, 2, "", true));
return Set(mv_829, "_rec", R_830);
return default;
}, 1, "record", false);
if (Truthy(Get(G("window"), "SquadMovies"))) {
return default;
}
if (!(Truthy(Invoke(G("document"), "querySelector", ((V)("link[data-sm-font]")))))) {
V l_864 = default;
l_864 = Invoke(G("document"), "createElement", ((V)("link")));
Set(l_864, "rel", ((V)("stylesheet")));
Set(l_864, "href", ((V)("vendor/css/g-51f30313213d.css")));
Invoke(l_864, "setAttribute", ((V)("data-sm-font")), ((V)("1")));
Invoke(Get(G("document"), "head"), "appendChild", l_864);
}
cl_8 = Fn((V _arrowThis876, int _argc865, V v_871, V _a868, V _a869, V _a870, V[] _rest866) => {
V a_873 = default;
V b_875 = default;
{ V _t872 = _a868; if (_t872.IsUndef) _t872 = ((V)(0D));
a_873 = _t872; }
{ V _t874 = _a869; if (_t874.IsUndef) _t874 = ((V)(1D));
b_875 = _t874; }
return ((V)(Max(ToNum(a_873), Min(ToNum(b_875), ToNum(v_871)))));
}, 3, "", true);
lerp_9 = Fn((V _arrowThis886, int _argc877, V a_883, V b_884, V u_885, V _a882, V[] _rest878) => {
return Add(a_883, ((V)(((ToNum(b_884) - ToNum(a_883)) * ToNum(u_885)))));
}, 3, "", true);
E_10 = NewObj(5).Put("lin", Fn((V _arrowThis894, int _argc887, V x_893, V _a890, V _a891, V _a892, V[] _rest888) => {
return x_893;
}, 1, "lin", true)).Put("in", Fn((V _arrowThis902, int _argc895, V x_901, V _a898, V _a899, V _a900, V[] _rest896) => {
return ((V)((ToNum(x_901) * ToNum(x_901))));
}, 1, "in", true)).Put("out", Fn((V _arrowThis910, int _argc903, V x_909, V _a906, V _a907, V _a908, V[] _rest904) => {
return ((V)((1D - Pow((1D - ToNum(x_909)), 3D))));
}, 1, "out", true)).Put("io", Fn((V _arrowThis918, int _argc911, V x_917, V _a914, V _a915, V _a916, V[] _rest912) => {
return ((V)((LtN(x_917, 0.5) ? (((4D * ToNum(x_917)) * ToNum(x_917)) * ToNum(x_917)) : (1D - (Pow((((-2D) * ToNum(x_917)) + 2D), 3D) / 2D)))));
}, 1, "io", true)).Put("back", Fn((V _arrowThis926, int _argc919, V x_925, V _a922, V _a923, V _a924, V[] _rest920) => {
double c1_927 = 0;
double c3_928 = 0;
c1_927 = 1.70158;
c3_928 = (c1_927 + 1D);
return ((V)(((1D + (c3_928 * Pow((ToNum(x_925) - 1D), 3D))) + (c1_927 * Pow((ToNum(x_925) - 1D), 2D)))));
return default;
}, 1, "back", true)).V;
P_11 = Fn((V _arrowThis940, int _argc929, V t_935, V a_936, V b_937, V _a934, V[] _rest930) => {
V e_939 = default;
{ V _t938 = _a934; if (_t938.IsUndef) _t938 = Get(E_10, "out");
e_939 = _t938; }
return Call(e_939, V.Undef, Call(cl_8, V.Undef, ((V)(((ToNum(t_935) - ToNum(a_936)) / (ToNum(b_937) - ToNum(a_936)))))));
}, 4, "", true);
kf_12 = Fn((V _arrowThis951, int _argc941, V t_947, V K_948, V _a945, V _a946, V[] _rest942) => {
V e_950 = default;
{ V _t949 = _a945; if (_t949.IsUndef) _t949 = Get(E_10, "lin");
e_950 = _t949; }
if (Le(t_947, GetIdx(GetIdx(K_948, 0D), 0D))) {
return GetIdx(GetIdx(K_948, 0D), 1D);
}
{
double i_952 = 0;
i_952 = 1D;
while (true) {
if (!(Lt(((V)(i_952)), Get(K_948, "length")))) break;
if (Le(t_947, GetIdx(GetIdx(K_948, i_952), 0D))) {
V a_954 = default;
V b_955 = default;
a_954 = GetIdx(K_948, (i_952 - 1D));
b_955 = GetIdx(K_948, i_952);
return Call(lerp_9, V.Undef, GetIdx(a_954, 1D), GetIdx(b_955, 1D), Call(e_950, V.Undef, ((V)(((ToNum(t_947) - ToNum(GetIdx(a_954, 0D))) / ToNum((((V)((ToNum(GetIdx(b_955, 0D)) - ToNum(GetIdx(a_954, 0D))))) is var _t956 && Truthy(_t956) ? _t956 : ((V)(1D)))))))));
}
i_952++;
}
}
return GetIdx(GetIdx(K_948, (ToNum(Get(K_948, "length")) - 1D)), 1D);
return default;
}, 3, "", true);
hop_13 = Fn((V _arrowThis967, int _argc957, V t_963, V a_964, V d_965, V h_966, V[] _rest958) => {
return ((V)(((Gt(t_963, a_964) && Lt(t_963, Add(a_964, d_965))) ? (FdLibm.Sin(((System.Math.PI * (ToNum(t_963) - ToNum(a_964))) / ToNum(d_965))) * ToNum(h_966)) : 0D)));
}, 4, "", true);
art_15 = Fn((V _arrowThis976, int _argc968, V k_974, V v_975, V _a972, V _a973, V[] _rest969) => {
return ((V)(JsStrBuf.Begin().S("export/tripo/").V(k_974).S("/").V(k_974).S("-").V(v_975).S(".svg").End()));
}, 2, "", true);
put_18 = Fn((V _arrowThis992, int _argc977, V n_983, V x_984, V y_985, V _a982, V[] _rest978) => {
V k_987 = default;
V r_989 = default;
V o_991 = default;
{ V _t986 = _a982; if (_t986.IsUndef) _t986 = ((V)(1D));
k_987 = _t986; }
{ V _t988 = (_argc977 > 4 ? _rest978[0] : V.Undef); if (_t988.IsUndef) _t988 = ((V)(0D));
r_989 = _t988; }
{ V _t990 = (_argc977 > 5 ? _rest978[1] : V.Undef); if (_t990.IsUndef) _t990 = ((V)(1D));
o_991 = _t990; }
if (LeN(o_991, 0.001)) {
Set(Get(n_983, "style"), "display", ((V)("none")));
return default;
}
Set(Get(n_983, "style"), "display", ((V)("block")));
Set(Get(n_983, "style"), "opacity", Invoke(o_991, "toFixed", ((V)(3D))));
Set(Get(n_983, "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").V(Invoke(x_984, "toFixed", ((V)(2D)))).S("px,").V(Invoke(y_985, "toFixed", ((V)(2D)))).S("px) translate(-50%,-50%) rotate(").V(Invoke(r_989, "toFixed", ((V)(2D)))).S("deg) scale(").V(Invoke(k_987, "toFixed", ((V)(3D)))).S(")").End())));
return default;
}, 6, "", true);
show_19 = Fn((V _arrowThis1001, int _argc993, V n_999, V on_1000, V _a997, V _a998, V[] _rest994) => {
V d_1002 = default;
d_1002 = ((V)((Truthy(on_1000) ? "block" : "none")));
if (!SEq(Get(Get(n_999, "style"), "display"), d_1002)) {
Set(Get(n_999, "style"), "display", d_1002);
}
return default;
}, 2, "", true);
rnd_20 = Fn((V _arrowThis1010, int _argc1003, V s_1009, V _a1006, V _a1007, V _a1008, V[] _rest1004) => {
return Fn((V _arrowThis1017, int _argc1011, V _a1013, V _a1014, V _a1015, V _a1016, V[] _rest1012) => {
V x_1018 = default;
s_1009 = ((V)(((double)(ToInt32(ToNum(s_1009)) | ToInt32(0D)))));
s_1009 = ((V)(((double)(ToInt32(ToNum(Add(s_1009, ((V)(1831565813D))))) | ToInt32(0D)))));
x_1018 = Invoke(G("Math"), "imul", ((V)(((double)(ToInt32(ToNum(s_1009)) ^ ToInt32(((double)(ToUint32(ToNum(s_1009)) >> (int)(ToUint32(15D) & 31)))))))), ((V)(((double)(ToInt32(1D) | ToInt32(ToNum(s_1009)))))));
x_1018 = ((V)(((double)(ToInt32(ToNum(Add(x_1018, Invoke(G("Math"), "imul", ((V)(((double)(ToInt32(ToNum(x_1018)) ^ ToInt32(((double)(ToUint32(ToNum(x_1018)) >> (int)(ToUint32(7D) & 31)))))))), ((V)(((double)(ToInt32(61D) | ToInt32(ToNum(x_1018)))))))))) ^ ToInt32(ToNum(x_1018))))));
return ((V)((((double)(ToUint32(((double)(ToInt32(ToNum(x_1018)) ^ ToInt32(((double)(ToUint32(ToNum(x_1018)) >> (int)(ToUint32(14D) & 31))))))) >> (int)(ToUint32(0D) & 31))) / 4294967296D)));
return default;
}, 0, "", true);
}, 1, "", true);
mtof_21 = Fn((V _arrowThis1026, int _argc1019, V m_1025, V _a1022, V _a1023, V _a1024, V[] _rest1020) => {
return ((V)((440D * Pow(2D, ((ToNum(m_1025) - 69D) / 12D)))));
}, 1, "", true);
RCH_23 = Arr(Arr(((V)(36D)), ((V)(43D)), Arr(((V)(52D)), ((V)(55D)), ((V)(60D)))), Arr(((V)(36D)), ((V)(43D)), Arr(((V)(52D)), ((V)(55D)), ((V)(60D)))), Arr(((V)(41D)), ((V)(36D)), Arr(((V)(53D)), ((V)(57D)), ((V)(60D)))), Arr(((V)(41D)), ((V)(36D)), Arr(((V)(53D)), ((V)(57D)), ((V)(60D)))), Arr(((V)(36D)), ((V)(43D)), Arr(((V)(52D)), ((V)(55D)), ((V)(60D)))), Arr(((V)(45D)), ((V)(40D)), Arr(((V)(55D)), ((V)(61D)), ((V)(64D)))), Arr(((V)(38D)), ((V)(45D)), Arr(((V)(54D)), ((V)(57D)), ((V)(60D)))), Arr(((V)(43D)), ((V)(38D)), Arr(((V)(53D)), ((V)(59D)), ((V)(62D)))));
RMEL_24 = Arr(Arr(Arr(((V)(0D)), ((V)(76D)), ((V)(0.5))), Arr(((V)(0.5)), ((V)(79D)), ((V)(0.5))), Arr(((V)(1D)), ((V)(84D)), ((V)(0.75))), Arr(((V)(2D)), ((V)(83D)), ((V)(0.5))), Arr(((V)(2.5)), ((V)(84D)), ((V)(0.5))), Arr(((V)(3D)), ((V)(79D)), ((V)(1D)))), Arr(Arr(((V)(0D)), ((V)(76D)), ((V)(0.5))), Arr(((V)(0.5)), ((V)(77D)), ((V)(0.5))), Arr(((V)(1D)), ((V)(78D)), ((V)(0.5))), Arr(((V)(1.5)), ((V)(79D)), ((V)(1D))), Arr(((V)(3D)), ((V)(76D)), ((V)(0.5))), Arr(((V)(3.5)), ((V)(72D)), ((V)(0.5)))), Arr(Arr(((V)(0D)), ((V)(77D)), ((V)(0.5))), Arr(((V)(0.5)), ((V)(81D)), ((V)(0.5))), Arr(((V)(1D)), ((V)(84D)), ((V)(0.75))), Arr(((V)(2D)), ((V)(81D)), ((V)(0.5))), Arr(((V)(2.5)), ((V)(84D)), ((V)(0.5))), Arr(((V)(3D)), ((V)(86D)), ((V)(1D)))), Arr(Arr(((V)(0D)), ((V)(84D)), ((V)(0.5))), Arr(((V)(0.5)), ((V)(81D)), ((V)(0.5))), Arr(((V)(1D)), ((V)(77D)), ((V)(0.5))), Arr(((V)(1.5)), ((V)(81D)), ((V)(1D))), Arr(((V)(3D)), ((V)(80D)), ((V)(0.5))), Arr(((V)(3.5)), ((V)(81D)), ((V)(0.5)))), Arr(Arr(((V)(0D)), ((V)(79D)), ((V)(0.5))), Arr(((V)(0.5)), ((V)(76D)), ((V)(0.5))), Arr(((V)(1D)), ((V)(72D)), ((V)(0.5))), Arr(((V)(1.5)), ((V)(76D)), ((V)(0.5))), Arr(((V)(2D)), ((V)(79D)), ((V)(0.75))), Arr(((V)(3D)), ((V)(84D)), ((V)(1D)))), Arr(Arr(((V)(0D)), ((V)(85D)), ((V)(0.5))), Arr(((V)(0.5)), ((V)(84D)), ((V)(0.5))), Arr(((V)(1D)), ((V)(81D)), ((V)(0.5))), Arr(((V)(1.5)), ((V)(79D)), ((V)(0.5))), Arr(((V)(2D)), ((V)(76D)), ((V)(0.5))), Arr(((V)(2.5)), ((V)(79D)), ((V)(0.5))), Arr(((V)(3D)), ((V)(81D)), ((V)(1D)))), Arr(Arr(((V)(0D)), ((V)(78D)), ((V)(0.5))), Arr(((V)(0.5)), ((V)(81D)), ((V)(0.5))), Arr(((V)(1D)), ((V)(84D)), ((V)(0.5))), Arr(((V)(1.5)), ((V)(81D)), ((V)(0.5))), Arr(((V)(2D)), ((V)(78D)), ((V)(0.5))), Arr(((V)(2.5)), ((V)(74D)), ((V)(0.5))), Arr(((V)(3D)), ((V)(72D)), ((V)(1D)))), Arr(Arr(((V)(0D)), ((V)(71D)), ((V)(0.5))), Arr(((V)(0.5)), ((V)(74D)), ((V)(0.5))), Arr(((V)(1D)), ((V)(77D)), ((V)(0.5))), Arr(((V)(1.5)), ((V)(79D)), ((V)(1D))), Arr(((V)(2.5)), ((V)(83D)), ((V)(0.5))), Arr(((V)(3D)), ((V)(84D)), ((V)(1D)))));
FY_28 = 164D;
W_29 = 60D;
CARDS_30 = Arr(Arr(((V)(3D)), ((V)(6.2)), ((V)("<div style=\"font-size:10px;letter-spacing:3px;\">THE GREAT</div><div style=\"font-size:32px;line-height:1.05;margin-top:2px;\">CAKE CAPER</div><div style=\"font-size:7.5px;letter-spacing:2px;margin-top:10px;\">STARRING CHEF BUN &middot; FRYBO &middot; CAKEY</div>"))), Arr(((V)(6.2)), ((V)(8.6)), ((V)("Chef Bun baked a birthday cake<br>for Cakey..."))), Arr(((V)(14.2)), ((V)(16.4)), ((V)("...but somebody else<br>could smell frosting!"))), Arr(((V)(30D)), ((V)(31.6)), ((V)("<div style=\"font-size:42px;\">HEY!!</div>"))), Arr(((V)(48D)), ((V)(50.4)), ((V)("Happy Birthday,<br><span style=\"font-size:28px;\">Cakey!</span>"))), Arr(((V)(56.2)), ((V)(60D)), ((V)("<div style=\"font-size:36px;\">THE END</div><div style=\"font-size:7.5px;letter-spacing:2px;margin-top:8px;white-space:nowrap;\">A CUTEFUNNYCREATURES PICTURE</div>"))));
SCN_31 = Arr(Arr(((V)(8.6)), ((V)(14.2))), Arr(((V)(16.4)), ((V)(30D))), Arr(((V)(31.6)), ((V)(48D))), Arr(((V)(50.4)), ((V)(56.2))));
beatsOf_34 = Fn((V _arrowThis1034, int _argc1027, V S_1033, V _a1030, V _a1031, V _a1032, V[] _rest1028) => {
return Fn((V _arrowThis1042, int _argc1035, V t_1041, V _a1038, V _a1039, V _a1040, V[] _rest1036) => {
{
foreach (V _k1043 in new JsIter(S_1033)) {
V a_1044 = default;
V b_1045 = default;
V B_1046 = default;
{ V _t1047 = ListOf(_k1043);
{ V _t1048 = GetIdx(_t1047, 0D);
a_1044 = _t1048; }
{ V _t1049 = GetIdx(_t1047, 1D);
b_1045 = _t1049; }
{ V _t1050 = GetIdx(_t1047, 2D);
B_1046 = _t1050; }
}
if ((Ge(t_1041, a_1044) && Lt(t_1041, b_1045))) {
double x_1051 = 0;
x_1051 = ((ToNum(t_1041) - ToNum(a_1044)) / ToNum(B_1046));
return NewObj(3).Put("n", ((V)(System.Math.Floor(x_1051)))).Put("ph", ((V)((x_1051 - System.Math.Floor(x_1051))))).Put("amp", ((V)((LtN(B_1046, 0.3) ? 1D : 0.7)))).V;
}
}
}
return V.Null;
return default;
}, 1, "", true);
}, 1, "", true);
list_35 = Arr(NewObj(9).Put("id", ((V)("cake"))).Put("tier", ((V)(1D))).Put("title", ((V)("The Great Cake Caper"))).Put("dur", ((V)(60D))).Put("old", (true ? V.True : V.False)).Put("mk", cakeCaper_32).Put("score", cakeScore_33).Put("beat", Call(beatsOf_34, V.Undef, Arr(Arr(((V)(3D)), ((V)(16.4)), ((V)(0.4))), Arr(((V)(16.4)), ((V)(20.3)), ((V)(0.6))), Arr(((V)(23.9)), ((V)(29.3)), ((V)(0.6))), Arr(((V)(31.6)), ((V)(39.4)), ((V)(0.25))), Arr(((V)(46.4)), ((V)(48D)), ((V)(0.4))), Arr(((V)(50.4)), ((V)(55.6)), ((V)(0.4)))))).Put("cues", Arr(Arr(((V)(20.6)), ((V)("laugh"))), Arr(((V)(24.3)), ((V)("laugh"))), Arr(((V)(27.7)), ((V)("laugh"))), Arr(((V)(29.6)), ((V)("gasp"))), Arr(((V)(37.1)), ((V)("laugh"))), Arr(((V)(39.7)), ((V)("laugh"))), Arr(((V)(41.8)), ((V)("gasp"))), Arr(((V)(46.4)), ((V)("cheer"))), Arr(((V)(53.5)), ((V)("cheer"))), Arr(((V)(55.4)), ((V)("laugh"))), Arr(((V)(59.3)), ((V)("laugh"))))).V, NewObj(4).Put("id", ((V)("moonpie"))).Put("tier", ((V)(2D))).Put("title", ((V)("Who Ate the Moon Pie?"))).Put("dur", ((V)(120D))).V, NewObj(4).Put("id", ((V)("lantern"))).Put("tier", ((V)(3D))).Put("title", ((V)("The Lantern of Lost Woods"))).Put("dur", ((V)(180D))).V, NewObj(4).Put("id", ((V)("trek"))).Put("tier", ((V)(4D))).Put("title", ((V)("Squad Trek: Mission to Planet Sprinkle"))).Put("dur", ((V)(240D))).V, NewObj(4).Put("id", ((V)("musical"))).Put("tier", ((V)(5D))).Put("title", ((V)("Squish Squad: The Musical"))).Put("dur", ((V)(300D))).V);
def_37 = Fn((V _arrowThis1060, int _argc1052, V id_1058, V o_1059, V _a1056, V _a1057, V[] _rest1053) => {
V m_1061 = default;
m_1061 = Invoke(list_35, "find", Fn((V _arrowThis1069, int _argc1062, V x_1068, V _a1065, V _a1066, V _a1067, V[] _rest1063) => {
return (SEq(Get(x_1068, "id"), id_1058) ? V.True : V.False);
}, 1, "", true));
if (Truthy(m_1061)) {
Object_assign(m_1061, o_1059);
Set(m_1061, "_rec", V.Null);
}
return default;
}, 2, "", true);
Set(G("window"), "SquadMovies", NewObj(4).Put("list", list_35).Put("look", look_27).Put("record", record_36).Put("def", def_37).V);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
