// yard-host.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_yard_host_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("rotate\\(([-\\d.e]+)deg\\)", "");
        static readonly System.Text.RegularExpressions.Regex RX1 = JsRegExp.Compile("yg-intro", "");
        static readonly System.Text.RegularExpressions.Regex RX2 = JsRegExp.Compile("yg-show", "");
        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V G_8, V _a5, V _a6, V _a7, V[] _rest3) => {
V s0_9 = default;
V root_10 = default;
V app_11 = default;
V closed_12 = default;
V sfx_13 = default;
V hooked_14 = default;
V tid_15 = default;
V f0_16 = default;
V Y_17 = default;
V q_18 = default;
V ev_19 = default;
V txt_20 = default;
V cls_21 = default;
V hook_22 = default;
V pc_23 = default;
Y_17 = Fn((V _self24, int _argc25, V _a27, V _a28, V _a29, V _a30, V[] _rest26) => {
return Get(G_8, "YardGames");
return default;
}, 0, "Y", false);
q_18 = Fn((V _self31, int _argc32, V sel_38, V _a35, V _a36, V _a37, V[] _rest33) => {
return (Truthy(root_10) ? Invoke(root_10, "querySelector", sel_38) : V.Null);
return default;
}, 1, "q", false);
ev_19 = Fn((V _self39, int _argc40, V type_46, V x_47, V y_48, V _a45, V[] _rest41) => {
return NewObj(7).Put("type", type_46).Put("clientX", (x_47 is var _t49 && Truthy(_t49) ? _t49 : ((V)(0D)))).Put("clientY", (y_48 is var _t50 && Truthy(_t50) ? _t50 : ((V)(0D)))).Put("pointerId", ((V)(1D))).Put("button", ((V)(0D))).Put("preventDefault", f0_16).Put("stopPropagation", f0_16).V;
return default;
}, 3, "ev", false);
txt_20 = Fn((V _self51, int _argc52, V el_58, V _a55, V _a56, V _a57, V[] _rest53) => {
return (Truthy(el_58) ? Get(el_58, "textContent") : ((V)("")));
return default;
}, 1, "txt", false);
cls_21 = Fn((V _self59, int _argc60, V el_66, V c_67, V _a64, V _a65, V[] _rest61) => {
return (!(!(Truthy(((el_66 is var _t68 && !Truthy(_t68) ? _t68 : Get(el_66, "classList")) is var _t69 && !Truthy(_t69) ? _t69 : Invoke(Get(el_66, "classList"), "contains", c_67))))) ? V.True : V.False);
return default;
}, 2, "cls", false);
hook_22 = Fn((V _self70, int _argc71, V _a73, V _a74, V _a75, V _a76, V[] _rest72) => {
V y_77 = default;
y_77 = Call(Y_17, V.Undef);
if (Truthy(((!(Truthy(y_77)) ? V.True : V.False) is var _t78 && Truthy(_t78) ? _t78 : hooked_14))) {
return default;
}
hooked_14 = (true ? V.True : V.False);
Invoke(Object_keys(Get(y_77, "SFX")), "forEach", Fn((V _self79, int _argc80, V k_86, V _a83, V _a84, V _a85, V[] _rest81) => {
SetK(Get(y_77, "SFX"), k_86, Fn((V _self87, int _argc88, V _a90, V _a91, V _a92, V _a93, V[] _rest89) => {
Invoke(sfx_13, "push", k_86);
return default;
}, 0, "", false));
return default;
}, 1, "", false));
return default;
}, 0, "hook", false);
pc_23 = Fn((V _self94, int _argc95, V v_101, V _a98, V _a99, V _a100, V[] _rest96) => {
V n_102 = default;
n_102 = ((V)(ParseFloat(v_101)));
return (double.IsNaN(ToNum(n_102)) ? ((V)(0D)) : n_102);
return default;
}, 1, "pc", false);
try {
s0_9 = (Get(G_8, "__readFile") is var _t103 && !Truthy(_t103) ? _t103 : Invoke(G_8, "__readFile", ((V)("local/yardgames.v1"))));
if (Truthy(s0_9)) {
Invoke(Get(G_8, "localStorage"), "setItem", ((V)("yardgames.v1")), s0_9);
}
} catch (System.Exception _ex104) {
V e_105 = default;
e_105 = Caught(_ex104);

}
root_10 = V.Null;
app_11 = V.Null;
closed_12 = (true ? V.True : V.False);
sfx_13 = Arr();
hooked_14 = (false ? V.True : V.False);
tid_15 = ((V)(0D));
f0_16 = Fn((V _self106, int _argc107, V _a109, V _a110, V _a111, V _a112, V[] _rest108) => {

return default;
}, 0, "", false);
Set(G_8, "__yard", NewObj(12).Put("open", Fn((V _self113, int _argc114, V id_120, V key_121, V _a118, V _a119, V[] _rest115) => {
V y_122 = default;
V g_123 = default;
V SQ_124 = default;
V c_125 = default;
V picks_126 = default;
V i_127 = default;
V hub0_128 = default;
Call(hook_22, V.Undef);
y_122 = Call(Y_17, V.Undef);
if ((!(Truthy(y_122)) || !(Truthy(Get(y_122, "mount"))))) {
return (false ? V.True : V.False);
}
g_123 = GetIdx(Invoke(Get(y_122, "GAMES"), "filter", Fn((V _self129, int _argc130, V x_136, V _a133, V _a134, V _a135, V[] _rest131) => {
return (SEq(Get(x_136, "id"), id_120) ? V.True : V.False);
return default;
}, 1, "", false)), 0D);
if (!(Truthy(g_123))) {
return (false ? V.True : V.False);
}
if (!(Truthy(root_10))) {
root_10 = Invoke(G("document"), "createElement", ((V)("div")));
Set(root_10, "className", ((V)("sq-yard-host")));
Invoke(Get(G("document"), "body"), "appendChild", root_10);
}
sfx_13 = Arr();
app_11 = Invoke(y_122, "mount", root_10);
SQ_124 = Get(G_8, "SquishSquad");
c_125 = (Truthy((SQ_124 is var _t146 && !Truthy(_t146) ? _t146 : Get(SQ_124, "ROSTER"))) ? GetIdx(Invoke(Get(SQ_124, "ROSTER"), "filter", Fn((V _self137, int _argc138, V x_144, V _a141, V _a142, V _a143, V[] _rest139) => {
return (x_144 is var _t145 && !Truthy(_t145) ? _t145 : (SEq(Get(x_144, "key"), key_121) ? V.True : V.False));
return default;
}, 1, "", false)), 0D) : V.Null);
if (Truthy(c_125)) {
picks_126 = Invoke(root_10, "querySelectorAll", ((V)(".yg-pick")));
{
i_127 = ((V)(0D));
while (true) {
if (!(Lt(i_127, Get(picks_126, "length")))) break;
if (SEq(Get(GetK(picks_126, i_127), "title"), Get(c_125, "name"))) {
Invoke(GetK(picks_126, i_127), "dispatchEvent", Call(ev_19, V.Undef, ((V)("click"))));
break;
}
PostInc(ref i_127, 1D);
}
}
}
hub0_128 = Get(app_11, "hub");
Set(app_11, "hub", Fn((V _self148, int _argc149, V _a151, V _a152, V _a153, V _a154, V[] _rest150) => {
Call(hub0_128, V.Undef);
closed_12 = (true ? V.True : V.False);
return default;
}, 0, "", false));
closed_12 = (false ? V.True : V.False);
Invoke(app_11, "play", g_123);
return (true ? V.True : V.False);
return default;
}, 2, "open", false)).Put("close", Fn((V _self155, int _argc156, V _a158, V _a159, V _a160, V _a161, V[] _rest157) => {
if (Truthy((app_11 is var _t162 && !Truthy(_t162) ? _t162 : (!(Truthy(closed_12)) ? V.True : V.False)))) {
try {
Invoke(app_11, "hub");
} catch (System.Exception _ex163) {
V e_164 = default;
e_164 = Caught(_ex163);

}
}
closed_12 = (true ? V.True : V.False);
return default;
}, 0, "close", false)).Put("closed", Fn((V _self165, int _argc166, V _a168, V _a169, V _a170, V _a171, V[] _rest167) => {
return closed_12;
return default;
}, 0, "closed", false)).Put("stage", Fn((V _self172, int _argc173, V _a175, V _a176, V _a177, V _a178, V[] _rest174) => {
V st_179 = default;
st_179 = Call(q_18, V.Undef, ((V)(".yg-stage")));
return (Truthy(st_179) ? Get(st_179, "childNodes") : Arr());
return default;
}, 0, "stage", false)).Put("box", Fn((V _self180, int _argc181, V h_187, V _a184, V _a185, V _a186, V[] _rest182) => {
V s_188 = default;
V m_189 = default;
V o_190 = default;
s_188 = Get(h_187, "style");
m_189 = Invoke(NewRegExp(RX0, "rotate\\(([-\\d.e]+)deg\\)", ""), "exec", (Get(s_188, "transform") is var _t191 && Truthy(_t191) ? _t191 : ((V)(""))));
o_190 = Invoke((Get(s_188, "transformOrigin") is var _t192 && Truthy(_t192) ? _t192 : ((V)("50% 93%"))), "split", ((V)(" ")));
return Arr(Call(pc_23, V.Undef, Get(s_188, "left")), Call(pc_23, V.Undef, Get(s_188, "top")), Call(pc_23, V.Undef, Get(s_188, "width")), Call(pc_23, V.Undef, Get(s_188, "height")), ((V)((Truthy(m_189) ? ToNum(GetIdx(m_189, 1D)) : 0D))), Call(pc_23, V.Undef, GetIdx(o_190, 0D)), Call(pc_23, V.Undef, GetIdx(o_190, 1D)), (((V)(ToNum(Get(s_188, "zIndex")))) is var _t193 && Truthy(_t193) ? _t193 : ((V)(0D))), ((V)((SEqS(Get(s_188, "visibility"), "hidden") ? 1D : 0D))), ((V)((SEqS(Get(s_188, "display"), "none") ? 1D : 0D))));
return default;
}, 1, "box", false)).Put("ui", Fn((V _self194, int _argc195, V _a197, V _a198, V _a199, V _a200, V[] _rest196) => {
V y_201 = default;
V o_202 = default;
V ov_203 = default;
V oc_204 = default;
V tm_205 = default;
V hud_206 = default;
V i_207 = default;
V e_208 = default;
V spans_209 = default;
V kids_210 = default;
V j_211 = default;
V bs_212 = default;
V btns_213 = default;
V b_214 = default;
V ic_215 = default;
V bl_216 = default;
V tl_217 = default;
V t_218 = default;
V te_219 = default;
V how_220 = default;
V li_221 = default;
V opts_222 = default;
V ob_223 = default;
V k_224 = default;
V p_225 = default;
V st_226 = default;
V bt_227 = default;
V labels_228 = default;
V r_229 = default;
V te2_230 = default;
V svgT_231 = default;
y_201 = Call(Y_17, V.Undef);
o_202 = NewObj(2).Put("W", Get(y_201, "W")).Put("H", Get(y_201, "H")).V;
ov_203 = Call(q_18, V.Undef, ((V)(".yg-ov")));
oc_204 = (Truthy(ov_203) ? Get(ov_203, "className") : ((V)("")));
Set(o_202, "phase", ((V)((Truthy(Invoke(NewRegExp(RX2, "yg-show", ""), "test", oc_204)) ? (Truthy(Invoke(NewRegExp(RX1, "yg-intro", ""), "test", oc_204)) ? "intro" : (Truthy(Call(q_18, V.Undef, ((V)(".yg-res")))) ? "result" : "card")) : "play"))));
tm_205 = Call(q_18, V.Undef, ((V)(".yg-time")));
Set(o_202, "ttl", Call(txt_20, V.Undef, Call(q_18, V.Undef, ((V)(".yg-ttl")))));
Set(o_202, "score", Call(txt_20, V.Undef, Call(q_18, V.Undef, ((V)(".yg-score")))));
Set(o_202, "time", (Truthy((tm_205 is var _t232 && !Truthy(_t232) ? _t232 : (!SEqS(Get(Get(tm_205, "style"), "display"), "none") ? V.True : V.False))) ? Call(txt_20, V.Undef, tm_205) : ((V)(""))));
Set(o_202, "hurry", Call(cls_21, V.Undef, tm_205, ((V)("yg-hurry"))));
Set(o_202, "hint", Call(txt_20, V.Undef, Call(q_18, V.Undef, ((V)(".yg-hint")))));
Set(o_202, "extra", Arr());
hud_206 = Call(q_18, V.Undef, ((V)(".yg-hud")));
if (Truthy(hud_206)) {
{
i_207 = ((V)(0D));
while (true) {
if (!(Lt(i_207, Get(Get(hud_206, "childNodes"), "length")))) break;
e_208 = GetK(Get(hud_206, "childNodes"), i_207);
if (Truthy((((!(Truthy(Get(e_208, "classList"))) ? V.True : V.False) is var _t234 && Truthy(_t234) ? _t234 : Call(cls_21, V.Undef, e_208, ((V)("yg-top")))) is var _t235 && Truthy(_t235) ? _t235 : Call(cls_21, V.Undef, e_208, ((V)("yg-hint")))))) {
goto _cont233;
}
if (Truthy(Call(cls_21, V.Undef, e_208, ((V)("yg-pill"))))) {
spans_209 = Arr();
kids_210 = Get(e_208, "childNodes");
{
j_211 = ((V)(0D));
while (true) {
if (!(Lt(j_211, Get(kids_210, "length")))) break;
if (SEqN(Get(GetK(kids_210, j_211), "nodeType"), 1D)) {
Invoke(spans_209, "push", Arr(Get(GetK(kids_210, j_211), "textContent"), (Get(Get(GetK(kids_210, j_211), "style"), "color") is var _t237 && Truthy(_t237) ? _t237 : ((V)("")))));
}
PostInc(ref j_211, 1D);
}
}
Invoke(Get(o_202, "extra"), "push", NewObj(4).Put("kind", ((V)("pill"))).Put("css", Get(Get(e_208, "style"), "cssText")).Put("text", Get(e_208, "textContent")).Put("spans", spans_209).V);
} else {
bs_212 = Arr();
btns_213 = Invoke(e_208, "querySelectorAll", ((V)("button")));
{
b_214 = ((V)(0D));
while (true) {
if (!(Lt(b_214, Get(btns_213, "length")))) break;
ic_215 = Invoke(GetK(btns_213, b_214), "querySelector", ((V)("svg")));
bl_216 = GetIdx(Get(GetK(btns_213, b_214), "childNodes"), (ToNum(Get(Get(GetK(btns_213, b_214), "childNodes"), "length")) - 1D));
Invoke(bs_212, "push", NewObj(4).Put("label", (Truthy(bl_216) ? Get(bl_216, "textContent") : ((V)("")))).Put("color", Get(Get(GetK(btns_213, b_214), "style"), "color")).Put("css", Get(Get(GetK(btns_213, b_214), "style"), "cssText")).Put("icon", (Truthy(ic_215) ? Get(ic_215, "outerHTML") : ((V)("")))).V);
PostInc(ref b_214, 1D);
}
}
Invoke(Get(o_202, "extra"), "push", NewObj(3).Put("kind", ((V)("buttons"))).Put("css", Get(Get(e_208, "style"), "cssText")).Put("buttons", bs_212).V);
}
_cont233: ;
PostInc(ref i_207, 1D);
}
}
}
Set(o_202, "toasts", Arr());
tl_217 = Call(q_18, V.Undef, ((V)(".yg-toasts")));
if (Truthy(tl_217)) {
{
t_218 = ((V)(0D));
while (true) {
if (!(Lt(t_218, Get(Get(tl_217, "childNodes"), "length")))) break;
te_219 = GetK(Get(tl_217, "childNodes"), t_218);
if (!(Truthy(Get(te_219, "__tid")))) {
Set(te_219, "__tid", ((V)(PreInc(ref tid_15, 1D))));
}
Invoke(Get(o_202, "toasts"), "push", NewObj(6).Put("id", Get(te_219, "__tid")).Put("text", Get(te_219, "textContent")).Put("x", Call(pc_23, V.Undef, Get(Get(te_219, "style"), "left"))).Put("y", Call(pc_23, V.Undef, Get(Get(te_219, "style"), "top"))).Put("col", (Get(Get(te_219, "style"), "color") is var _t240 && Truthy(_t240) ? _t240 : ((V)("#ffffff")))).Put("big", Call(cls_21, V.Undef, te_219, ((V)("yg-big")))).V);
PostInc(ref t_218, 1D);
}
}
}
if (SEqS(Get(o_202, "phase"), "intro")) {
how_220 = Arr();
li_221 = Invoke(root_10, "querySelectorAll", ((V)(".yg-isheet .yg-how li")));
opts_222 = Arr();
ob_223 = Invoke(root_10, "querySelectorAll", ((V)(".yg-isheet .yg-opt")));
{
k_224 = ((V)(0D));
while (true) {
if (!(Lt(k_224, Get(li_221, "length")))) break;
Invoke(how_220, "push", Get(GetK(li_221, k_224), "textContent"));
PostInc(ref k_224, 1D);
}
}
{
p_225 = ((V)(0D));
while (true) {
if (!(Lt(p_225, Get(ob_223, "length")))) break;
Invoke(opts_222, "push", NewObj(2).Put("label", Get(GetK(ob_223, p_225), "textContent")).Put("on", Call(cls_21, V.Undef, GetK(ob_223, p_225), ((V)("on")))).V);
PostInc(ref p_225, 1D);
}
}
Set(o_202, "intro", NewObj(4).Put("how", how_220).Put("opts", opts_222).Put("best", Call(txt_20, V.Undef, Call(q_18, V.Undef, ((V)(".yg-isheet .yg-best"))))).Put("color", (Truthy(Get(Get(ov_203, "style"), "getPropertyValue")) ? Invoke(Get(ov_203, "style"), "getPropertyValue", ((V)("--gc"))) : ((V)("")))).V);
} else {
if (SEqS(Get(o_202, "phase"), "result")) {
st_226 = Get(Invoke(root_10, "querySelectorAll", ((V)(".yg-res .yg-star.on"))), "length");
bt_227 = Invoke(root_10, "querySelectorAll", ((V)(".yg-res .yg-btn")));
labels_228 = Arr();
{
r_229 = ((V)(0D));
while (true) {
if (!(Lt(r_229, Get(bt_227, "length")))) break;
Invoke(labels_228, "push", Get(GetK(bt_227, r_229), "textContent"));
PostInc(ref r_229, 1D);
}
}
te2_230 = Call(q_18, V.Undef, ((V)(".yg-res-t")));
svgT_231 = (te2_230 is var _t244 && !Truthy(_t244) ? _t244 : Invoke(te2_230, "querySelector", ((V)("svg"))));
Set(o_202, "result", NewObj(6).Put("title", (Truthy(svgT_231) ? Invoke(svgT_231, "getAttribute", ((V)("aria-label"))) : Call(txt_20, V.Undef, te2_230))).Put("stars", st_226).Put("score", Call(txt_20, V.Undef, Call(q_18, V.Undef, ((V)(".yg-res-score"))))).Put("sub", Call(txt_20, V.Undef, Call(q_18, V.Undef, ((V)(".yg-res-sub"))))).Put("coins", Call(txt_20, V.Undef, Call(q_18, V.Undef, ((V)(".yg-res-coins"))))).Put("buttons", labels_228).V);
}
}
return Invoke(G("JSON"), "stringify", o_202);
return default;
}, 0, "ui", false)).Put("el", Fn((V _self245, int _argc246, V what_252, V i_253, V _a250, V _a251, V[] _rest247) => {
V hud_254 = default;
V all_255 = default;
if (SEqS(what_252, "play")) {
return Call(q_18, V.Undef, ((V)(".yg-isheet .yg-go")));
}
if (SEqS(what_252, "iback")) {
return Call(q_18, V.Undef, ((V)(".yg-iback")));
}
if (SEqS(what_252, "back")) {
return Call(q_18, V.Undef, ((V)(".yg-back")));
}
if (SEqS(what_252, "opt")) {
return (GetK((Truthy(root_10) ? Invoke(root_10, "querySelectorAll", ((V)(".yg-isheet .yg-opt"))) : Arr()), i_253) is var _t256 && Truthy(_t256) ? _t256 : V.Null);
}
if (SEqS(what_252, "res")) {
return (GetK((Truthy(root_10) ? Invoke(root_10, "querySelectorAll", ((V)(".yg-res .yg-btn"))) : Arr()), i_253) is var _t257 && Truthy(_t257) ? _t257 : V.Null);
}
if (SEqS(what_252, "btn")) {
hud_254 = Call(q_18, V.Undef, ((V)(".yg-hud")));
all_255 = (Truthy(hud_254) ? Invoke(hud_254, "querySelectorAll", ((V)("button"))) : Arr());
return (GetK(all_255, i_253) is var _t258 && Truthy(_t258) ? _t258 : V.Null);
}
if (SEqS(what_252, "art")) {
return Call(q_18, V.Undef, ((V)(".yg-iart")));
}
return V.Null;
return default;
}, 2, "el", false)).Put("click", Fn((V _self259, int _argc260, V el_266, V _a263, V _a264, V _a265, V[] _rest261) => {
if (Truthy(el_266)) {
Invoke(el_266, "dispatchEvent", Call(ev_19, V.Undef, ((V)("click"))));
}
return default;
}, 1, "click", false)).Put("press", Fn((V _self267, int _argc268, V el_274, V _a271, V _a272, V _a273, V[] _rest269) => {
if (Truthy(el_274)) {
Invoke(el_274, "dispatchEvent", Call(ev_19, V.Undef, ((V)("pointerdown"))));
}
return default;
}, 1, "press", false)).Put("pointer", Fn((V _self275, int _argc276, V type_282, V x_283, V y_284, V _a281, V[] _rest277) => {
V inp_285 = default;
inp_285 = Call(q_18, V.Undef, ((V)(".yg-input")));
if (!(Truthy(inp_285))) {
return default;
}
Set(inp_285, "__rect", NewObj(4).Put("left", ((V)(0D))).Put("top", ((V)(0D))).Put("width", Get(Call(Y_17, V.Undef), "W")).Put("height", Get(Call(Y_17, V.Undef), "H")).V);
Invoke(inp_285, "dispatchEvent", Call(ev_19, V.Undef, type_282, x_283, y_284));
return default;
}, 3, "pointer", false)).Put("sfx", Fn((V _self286, int _argc287, V _a289, V _a290, V _a291, V _a292, V[] _rest288) => {
V s_293 = default;
s_293 = sfx_13;
sfx_13 = Arr();
return s_293;
return default;
}, 0, "sfx", false)).Put("saved", Fn((V _self294, int _argc295, V _a297, V _a298, V _a299, V _a300, V[] _rest296) => {
try {
return Invoke(Get(G_8, "localStorage"), "getItem", ((V)("yardgames.v1")));
} catch (System.Exception _ex301) {
V e_302 = default;
e_302 = Caught(_ex301);
return V.Null;
}
return default;
}, 0, "saved", false)).V);
Set(G_8, "SquishApp", (Get(G_8, "SquishApp") is var _t303 && Truthy(_t303) ? _t303 : NewObj(0).V));
return default;
}, 1, "", false), V.Undef, (!string.Equals(GTypeof("globalThis"), "undefined") ? G("globalThis") : GlobalV));
        }
    }
}
