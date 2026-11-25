// reno-plus15.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus15_js
    {

        public static void Run()
        {
Call(Named(boot_45 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V K_10 = default;
V shade_11 = default;
V slab_12 = default;
V N_13 = default;
V H_14 = default;
V cam_15 = default;
V FR_16 = default;
V an_17 = default;
V at_18 = default;
V SPL_19 = default;
V f1_20 = default;
V n4_21 = default;
V rep_22 = default;
V P2_23 = default;
V FONT_24 = default;
V shadow_25 = default;
V isPlay_26 = default;
V yawA_27 = default;
V DEF11_28 = default;
V ext_29 = default;
V zsort_30 = default;
V WD_31 = default;
V box3_32 = default;
V cyl3_33 = default;
V DEF15_34 = default;
V HAND_35 = default;
V cone_36 = default;
V curve_37 = default;
V edit14_38 = default;
if (_self1.IsNullish) _self1 = GlobalV;
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy(((((((RD_8 is var _t39 && !Truthy(_t39) ? _t39 : Get(RD_8, "PLUS14")) is var _t40 && !Truthy(_t40) ? _t40 : Get(RD_8, "H12")) is var _t41 && !Truthy(_t41) ? _t41 : Get(RD_8, "H11")) is var _t42 && !Truthy(_t42) ? _t42 : Get(RD_8, "H10")) is var _t43 && !Truthy(_t43) ? _t43 : X_9) is var _t44 && !Truthy(_t44) ? _t44 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_45.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS15"))) {
return default;
}
K_10 = Get(X_9, "K");
shade_11 = Get(K_10, "shade");
slab_12 = Get(K_10, "slab");
N_13 = Get(RD_8, "N");
H_14 = Get(RD_8, "H10");
{ V _t46 = H_14;
if (_t46.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t46));
{ V _t47 = Get(_t46, "cam");
cam_15 = _t47; }
{ V _t48 = Get(_t46, "FR");
FR_16 = _t48; }
{ V _t49 = Get(_t46, "an");
an_17 = _t49; }
{ V _t50 = Get(_t46, "at");
at_18 = _t50; }
{ V _t51 = Get(_t46, "SPL");
SPL_19 = _t51; }
{ V _t52 = Get(_t46, "f1");
f1_20 = _t52; }
{ V _t53 = Get(_t46, "n4");
n4_21 = _t53; }
{ V _t54 = Get(_t46, "rep");
rep_22 = _t54; }
{ V _t55 = Get(_t46, "P2");
P2_23 = _t55; }
{ V _t56 = Get(_t46, "FONT");
FONT_24 = _t56; }
{ V _t57 = Get(_t46, "shadow");
shadow_25 = _t57; }
{ V _t58 = Get(_t46, "isPlay");
isPlay_26 = _t58; }
{ V _t59 = Get(_t46, "yawA");
yawA_27 = _t59; } }
{ V _t60 = Get(RD_8, "H11");
if (_t60.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t60));
{ V _t61 = Get(_t60, "DEF11");
DEF11_28 = _t61; }
{ V _t62 = Get(_t60, "ext");
ext_29 = _t62; }
{ V _t63 = Get(_t60, "zsort");
zsort_30 = _t63; } }
{ V _t64 = Get(RD_8, "H12");
if (_t64.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t64));
{ V _t65 = Get(_t64, "WD");
WD_31 = _t65; } }
box3_32 = Fn((V _arrowThis74, int _argc66, V C_72, V o_73, V _a70, V _a71, V[] _rest67) => {
return Invoke(H_14, "box3", C_72, Object_assign(NewObj(0).V, o_73, NewObj(7).Put("mat", V.Null).Put("tpat", V.Null).Put("gl", ((V)((Truthy(Get(o_73, "gl")) ? Min(ToNum(Get(o_73, "gl")), 0.2) : 0D)))).Put("olw", ((V)(1D))).Put("olo", ((V)(0.95))).Put("olc", Call(shade_11, V.Undef, Get(o_73, "col"), ((V)(0.32)))).Put("edge", ((V)(0.5))).V));
}, 2, "", true);
cyl3_33 = Fn((V _arrowThis87, int _argc75, V C_81, V a_82, V b_83, V r_84, V[] _rest76) => {
V col_85 = default;
V o_86 = default;
col_85 = (_argc75 > 4 ? _rest76[0] : V.Undef);
o_86 = (_argc75 > 5 ? _rest76[1] : V.Undef);
return Invoke(H_14, "cyl3", C_81, a_82, b_83, r_84, col_85, Object_assign(NewObj(0).V, (o_86 is var _t88 && Truthy(_t88) ? _t88 : NewObj(0).V), NewObj(4).Put("mat", ((V)((Truthy((o_86 is var _t89 && !Truthy(_t89) ? _t89 : (SEqS(Get(o_86, "mat"), "gloss") ? V.True : V.False))) ? "gloss" : "plastic")))).Put("pat", V.Null).Put("olw", ((V)(0.8))).Put("olo", ((V)(0.95))).V));
}, 6, "", true);
DEF15_34 = ((V)(JsStrBuf.Begin().V(DEF11_28).S("<radialGradient id=\"p15cn\" cx=\"40%\" cy=\"35%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#7a6e60\"/><stop offset=\"1\" stop-color=\"#2a241e\"/></radialGradient>").S("<radialGradient id=\"p15lens\" cx=\"40%\" cy=\"36%\" r=\"65%\"><stop offset=\"0\" stop-color=\"#6a74c8\"/><stop offset=\"0.5\" stop-color=\"#1d2246\"/><stop offset=\"1\" stop-color=\"#06070c\"/></radialGradient>").S("<radialGradient id=\"p15glow\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.95\"/><stop offset=\"0.35\" stop-color=\"#dff0ff\" stop-opacity=\"0.6\"/><stop offset=\"1\" stop-color=\"#bfe0ff\" stop-opacity=\"0\"/></radialGradient>").S("<linearGradient id=\"p15scr\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fdfdfb\"/><stop offset=\"0.6\" stop-color=\"#f2f2ed\"/><stop offset=\"1\" stop-color=\"#e2e2dc\"/></linearGradient>").S("<linearGradient id=\"p15shn\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0.6\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient>").S("<linearGradient id=\"p15gls\" x1=\"0\" y1=\"0\" x2=\"0.4\" y2=\"1\"><stop offset=\"0\" stop-color=\"#262a40\"/><stop offset=\"0.5\" stop-color=\"#0d0e18\"/><stop offset=\"1\" stop-color=\"#05060a\"/></linearGradient>").S("<linearGradient id=\"p15bm\" x1=\"0\" y1=\"1\" x2=\"0\" y2=\"0\"><stop offset=\"0\" stop-color=\"#8ff6ff\" stop-opacity=\"0.5\"/><stop offset=\"1\" stop-color=\"#8ff6ff\" stop-opacity=\"0\"/></linearGradient>").S("<pattern id=\"p15px\" width=\"2.4\" height=\"2.4\" patternUnits=\"userSpaceOnUse\"><path d=\"M0 0.1H2.4M0.1 0V2.4\" stroke=\"#000000\" stroke-opacity=\"0.35\" stroke-width=\"0.25\"/></pattern>").V(Invoke(Invoke(Arr(((V)("#3fd0ff")), ((V)("#9a5bff")), ((V)("#ff5fb4")), ((V)("#5bffc8"))), "map", Fn((V _arrowThis98, int _argc90, V c_96, V i_97, V _a94, V _a95, V[] _rest91) => {
return ((V)(JsStrBuf.Begin().S("<radialGradient id=\"p15o").V(i_97).S("\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"").V(c_96).S("\" stop-opacity=\"1\"/><stop offset=\"0.55\" stop-color=\"").V(c_96).S("\" stop-opacity=\"0.75\"/><stop offset=\"1\" stop-color=\"").V(c_96).S("\" stop-opacity=\"0\"/></radialGradient>").End()));
}, 2, "", true)), "join", ((V)("")))).S("<radialGradient id=\"p15em\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#3fd0ff\" stop-opacity=\"0.6\"/><stop offset=\"1\" stop-color=\"#3fd0ff\" stop-opacity=\"0\"/></radialGradient>").S("<filter id=\"p15b1\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"0.8\"/></filter><filter id=\"p15b2\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"2.4\"/></filter>").S("<filter id=\"p15b3\" x=\"-60%\" y=\"-60%\" width=\"220%\" height=\"220%\"><feGaussianBlur stdDeviation=\"6\"/></filter><filter id=\"p15b4\" x=\"-40%\" y=\"-40%\" width=\"180%\" height=\"180%\"><feGaussianBlur stdDeviation=\"12\"/></filter>").End()));
HAND_35 = ((V)(string.Concat("font-family=\"'Comic Sans MS','Chalkboard SE',cursive\" font-weight=\"700\"", "")));
cone_36 = Fn((V _arrowThis110, int _argc99, V cx_105, V cy_106, V r_107, V on_108, V[] _rest100) => {
V ph_109 = default;
ph_109 = (_argc99 > 4 ? _rest100[0] : V.Undef);
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(f1_20, V.Undef, cx_105)), " ", ToStr(Call(f1_20, V.Undef, cy_106)), ")\"><circle r=\"", ToStr(Call(f1_20, V.Undef, r_107)), "\" fill=\"#2b2622\"/><g>", ToStr((Truthy(on_108) ? Call(at_18, V.Undef, ((V)("scale")), ((V)("1;1.12;0.95;1")), ((V)(0.46)), (ph_109 is var _t111 && Truthy(_t111) ? _t111 : ((V)(0D))), Call(SPL_19, V.Undef, ((V)(3D)))) : ((V)("")))), "<circle r=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(r_107) * 0.84))))), "\" fill=\"url(#p15cn)\"/><circle r=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(r_107) * 0.62))))), "\" fill=\"none\" stroke=\"#1c1916\" stroke-opacity=\"0.5\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(r_107) * 0.08))))), "\"/><circle r=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(r_107) * 0.3))))), "\" fill=\"#1c1916\"/><circle cx=\"", ToStr(Call(f1_20, V.Undef, ((V)(((-ToNum(r_107)) * 0.12))))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, ((V)(((-ToNum(r_107)) * 0.12))))), "\" r=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(r_107) * 0.1))))), "\" fill=\"#ffffff\" opacity=\"0.5\"/></g></g>")));
}, 5, "", true);
curve_37 = Fn((V _arrowThis122, int _argc112, V C_118, V P_119, V col_120, V w_121, V[] _rest113) => {
V q_123 = default;
q_123 = Invoke(P_119, "map", Get(C_118, "P"));
return ((V)(string.Concat("<path d=\"M", ToStr(Call(P2_23, V.Undef, GetIdx(q_123, 0D))), "C", ToStr(Call(P2_23, V.Undef, GetIdx(q_123, 1D))), " ", ToStr(Call(P2_23, V.Undef, GetIdx(q_123, 2D))), " ", ToStr(Call(P2_23, V.Undef, GetIdx(q_123, 3D))), "\" stroke=\"", ToStr(col_120), "\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(w_121) * ToNum(Get(C_118, "k"))))))), "\" fill=\"none\" stroke-linecap=\"round\"/>")));
return default;
}, 4, "", true);
Set(N_13, "vhs15", Fn((V _arrowThis131, int _argc124, V S_130, V _a127, V _a128, V _a129, V[] _rest125) => {
V on_132 = default;
V CB_133 = default;
V DK_134 = default;
V PJ_135 = default;
double BX_136 = 0;
double PX_137 = 0;
double LX_138 = 0;
double LY_139 = 0;
double LZ_140 = 0;
V D_141 = default;
V boxF_142 = default;
V boxT_143 = default;
V boxR_144 = default;
V disp_145 = default;
V deckF_146 = default;
V deckT_147 = default;
V pjF_148 = default;
V pjT_149 = default;
V pjR_150 = default;
on_132 = Call(isPlay_26, V.Undef, S_130);
CB_133 = ((V)("#c9995a"));
DK_134 = ((V)("#3a3b41"));
PJ_135 = ((V)("#e8dec6"));
BX_136 = (-8D);
PX_137 = (BX_136 - 1D);
LX_138 = (PX_137 + 4D);
LY_139 = 26.5;
LZ_140 = 10D;
D_141 = NewObj(3).Put("w", ((V)(70D))).Put("d", ((V)(34D))).Put("build", Fn((V _arrowThis157, int _argc151, V _a153, V _a154, V _a155, V _a156, V[] _rest152) => {
return Arr();
}, 0, "build", true)).V;
boxF_142 = ((V)(string.Concat(string.Concat("<rect x=\"18.4\" width=\"3.2\" height=\"14\" fill=\"#e6cf9c\" opacity=\"0.9\"/><path d=\"M4 9.6l2 -2.4 2 2.4M6 7.3v4.4M31 9.6l2 -2.4 2 2.4M33 7.3v4.4\" stroke=\"#5a3e1c\" stroke-width=\"0.6\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/>", ""), string.Concat("<g transform=\"rotate(-8 29 4.4)\"><rect x=\"23.2\" y=\"2.4\" width=\"11.6\" height=\"3.8\" rx=\"0.4\" fill=\"none\" stroke=\"#c0392b\" stroke-width=\"0.5\"/><text x=\"29\" y=\"5.25\" text-anchor=\"middle\" ", ToStr(FONT_24), " font-size=\"2.4\" fill=\"#c0392b\">FRAGILE</text></g>"))));
boxT_143 = ((V)(string.Concat("<rect x=\"18.4\" width=\"3.2\" height=\"28\" fill=\"#e6cf9c\" opacity=\"0.9\"/><path d=\"M0 14H40\" stroke=\"#8a6334\" stroke-width=\"0.45\"/>", "")));
boxR_144 = ((V)(string.Concat("<path d=\"M4 4H24\" stroke=\"#8a6334\" stroke-width=\"0.4\" stroke-dasharray=\"1.2 0.8\"/><text x=\"14\" y=\"10\" text-anchor=\"middle\" ", ToStr(HAND_35), " font-size=\"2.2\" fill=\"#5a3e1c\">MOVIES</text>")));
disp_145 = ((V)((Truthy(on_132) ? string.Concat("<text x=\"25.8\" y=\"3.95\" text-anchor=\"middle\" ", ToStr(FONT_24), " font-size=\"2.4\" fill=\"#7dff9e\">\u25b6 0:12</text>") : string.Concat("<text x=\"25.8\" y=\"3.95\" text-anchor=\"middle\" ", ToStr(FONT_24), " font-size=\"2.6\" fill=\"#7dff9e\">12:00<animate attributeName=\"opacity\" values=\"1;0\" dur=\"1.1s\" calcMode=\"discrete\" repeatCount=\"indefinite\"/></text>"))));
deckF_146 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"2.4\" y=\"1.2\" width=\"15\" height=\"3.5\" rx=\"0.5\" fill=\"#141418\"/><path d=\"M2.9 2H16.9\" stroke=\"#5a5b63\" stroke-width=\"0.4\"/>", "")).S(string.Concat("<rect x=\"20\" y=\"1.1\" width=\"11.6\" height=\"3.7\" rx=\"0.5\" fill=\"#0b1310\"/>", ToStr(disp_145))).V(Invoke(Call(rep_22, V.Undef, ((V)(5D)), Fn((V _arrowThis165, int _argc158, V i_164, V _a161, V _a162, V _a163, V[] _rest159) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_20, V.Undef, ((V)((2.6 + (ToNum(i_164) * 3D)))))), "\" y=\"5.35\" width=\"2.4\" height=\"0.9\" rx=\"0.3\" fill=\"#9a9ca4\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<circle cx=\"18.6\" cy=\"5.8\" r=\"0.55\" fill=\"#d03a30\"/>", "")).S(string.Concat("<text x=\"33.4\" y=\"6.35\" text-anchor=\"middle\" ", ToStr(FONT_24), " font-size=\"1.4\" fill=\"#b9bcc4\">VHS</text><circle cx=\"33.4\" cy=\"2.6\" r=\"0.6\" fill=\"", (Truthy(on_132) ? "#5dff7a" : "#ff5a4a"), "\"/>")).End()));
deckT_147 = ((V)(JsStrBuf.Begin().V(Invoke(Call(rep_22, V.Undef, ((V)(8D)), Fn((V _arrowThis173, int _argc166, V i_172, V _a169, V _a170, V _a171, V[] _rest167) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_20, V.Undef, ((V)((20D + (ToNum(i_172) * 1.6)))))), "\" y=\"3\" width=\"0.8\" height=\"7\" rx=\"0.4\" fill=\"#000000\" fill-opacity=\"0.35\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<path d=\"M2 21H34\" stroke=\"#55565e\" stroke-width=\"0.4\"/>", "")).End()));
pjF_148 = ((V)(JsStrBuf.Begin().V(Invoke(Call(rep_22, V.Undef, ((V)(5D)), Fn((V _arrowThis181, int _argc174, V i_180, V _a177, V _a178, V _a179, V[] _rest175) => {
return ((V)(string.Concat("<rect x=\"1.6\" y=\"", ToStr(Call(f1_20, V.Undef, ((V)((1.8 + (ToNum(i_180) * 1.5)))))), "\" width=\"6.4\" height=\"0.75\" rx=\"0.35\" fill=\"#8a826e\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<text x=\"4.8\" y=\"10.2\" text-anchor=\"middle\" ", ToStr(FONT_24), " font-size=\"1.2\" fill=\"#8a826e\">MINI\u00b7PRO</text>")).End()));
pjT_149 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"11.5\" y=\"3\" width=\"4.6\" height=\"2.2\" rx=\"0.6\" fill=\"#b5ab92\"/>", "")).V(Invoke(Call(rep_22, V.Undef, ((V)(5D)), Fn((V _arrowThis189, int _argc182, V i_188, V _a185, V _a186, V _a187, V[] _rest183) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_20, V.Undef, ((V)((12.2 + (ToNum(i_188) * 0.8)))))), " 3.2v1.8\" stroke=\"#8a826e\" stroke-width=\"0.25\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<g transform=\"rotate(-10 6 10)\"><rect x=\"1.8\" y=\"8.2\" width=\"8.6\" height=\"3.8\" fill=\"#fff6a8\" stroke=\"#d8c860\" stroke-width=\"0.25\"/><text x=\"6.1\" y=\"10.9\" text-anchor=\"middle\" ", ToStr(HAND_35), " font-size=\"2.1\" fill=\"#3a2a7a\">MOM'S</text></g>")).End()));
pjR_150 = Invoke(Call(rep_22, V.Undef, ((V)(4D)), Fn((V _arrowThis197, int _argc190, V i_196, V _a193, V _a194, V _a195, V[] _rest191) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_20, V.Undef, ((V)((4D + (ToNum(i_196) * 2.6)))))), "\" cy=\"5.5\" r=\"0.75\" fill=\"#8a826e\"/>")));
}, 1, "", true)), "join", ((V)("")));
Set(D_141, "fx", Fn((V _arrowThis205, int _argc198, V ctx_204, V _a201, V _a202, V _a203, V[] _rest199) => {
V C_206 = default;
V L_207 = default;
V st_208 = default;
V G_209 = default;
V tape_210 = default;
C_206 = Call(cam_15, V.Undef, ctx_204);
L_207 = Arr();
st_208 = Call(shadow_25, V.Undef, C_206, ((V)(BX_136)), ((V)(0D)), ((V)(27D)), ((V)(19D)), ((V)(0.85)));
st_208 = Add(st_208, Call(box3_32, V.Undef, C_206, NewObj(7).Put("c", Arr(((V)(BX_136)), ((V)(0D)), ((V)(0D)))).Put("w", ((V)(40D))).Put("h", ((V)(14D))).Put("d", ((V)(28D))).Put("r", ((V)(1D))).Put("col", CB_133).Put("dec", NewObj(3).Put("f", boxF_142).Put("t", boxT_143).Put("r", boxR_144).V).V));
st_208 = Add(st_208, Call(box3_32, V.Undef, C_206, NewObj(7).Put("c", Arr(((V)(BX_136)), ((V)(14D)), ((V)(0D)))).Put("w", ((V)(36D))).Put("h", ((V)(7D))).Put("d", ((V)(24D))).Put("r", ((V)(1.2))).Put("col", DK_134).Put("dec", NewObj(2).Put("f", deckF_146).Put("t", deckT_147).V).V));
st_208 = Add(st_208, Call(box3_32, V.Undef, C_206, NewObj(7).Put("c", Arr(((V)(PX_137)), ((V)(21D)), ((V)(2D)))).Put("w", ((V)(18D))).Put("h", ((V)(11D))).Put("d", ((V)(16D))).Put("r", ((V)(2.2))).Put("col", PJ_135).Put("dec", NewObj(3).Put("f", pjF_148).Put("t", pjT_149).Put("r", pjR_150).V).V));
st_208 = Add(st_208, Add(Call(cyl3_33, V.Undef, C_206, Arr(((V)(LX_138)), ((V)(LY_139)), ((V)(LZ_140))), Arr(((V)(LX_138)), ((V)(LY_139)), ((V)((LZ_140 + 2.6)))), ((V)(3.5)), ((V)("#2b2b30"))), Call(cyl3_33, V.Undef, C_206, Arr(((V)(LX_138)), ((V)(LY_139)), ((V)((LZ_140 + 2.6)))), Arr(((V)(LX_138)), ((V)(LY_139)), ((V)((LZ_140 + 3.1)))), ((V)(3.2)), ((V)("#4a4b52")))));
G_209 = ((V)(string.Concat(string.Concat("<g transform=\"", ToStr(Call(FR_16, V.Undef, C_206, Arr(((V)(LX_138)), ((V)(LY_139)), ((V)((LZ_140 + 3.15)))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))), "\"><circle r=\"2.7\" fill=\"url(#p15lens)\"/><circle r=\"2.7\" fill=\"none\" stroke=\"#6a6c75\" stroke-width=\"0.35\"/><ellipse cx=\"-0.9\" cy=\"-0.95\" rx=\"0.9\" ry=\"0.55\" fill=\"#ffffff\" opacity=\"0.8\" transform=\"rotate(-35 -0.9 -0.95)\"/>"), (Truthy(on_132) ? string.Concat("<circle r=\"8\" fill=\"url(#p15glow)\">", ToStr(Call(an_17, V.Undef, ((V)("opacity")), ((V)("0.75;1;0.8;0.95;0.75")), ((V)(1.6)))), "</circle><circle r=\"2.4\" fill=\"#ffffff\" opacity=\"0.9\"/>") : ""), "</g>")));
st_208 = Add(st_208, G_209);
Invoke(L_207, "push", NewObj(2).Put("q", Arr(((V)(BX_136)), ((V)(14D)), ((V)(0D)))).Put("s", st_208).V);
tape_210 = Fn((V _arrowThis221, int _argc211, V y_217, V yaw_218, V lab_219, V col_220, V[] _rest212) => {
return Call(box3_32, V.Undef, C_206, NewObj(8).Put("c", Arr(((V)(24D)), y_217, ((V)(6D)))).Put("ax", Call(yawA_27, V.Undef, yaw_218)).Put("w", ((V)(19.5))).Put("h", ((V)(2.6))).Put("d", ((V)(11D))).Put("r", ((V)(0.4))).Put("col", ((V)("#1d1d21"))).Put("dec", NewObj(2).Put("f", ((V)(string.Concat("<rect x=\"2\" y=\"0.45\" width=\"15.5\" height=\"1.7\" fill=\"", ToStr(col_220), "\"/><text x=\"9.75\" y=\"1.75\" text-anchor=\"middle\" ", ToStr(HAND_35), " font-size=\"1.3\" fill=\"#222222\">", ToStr(lab_219), "</text>")))).Put("t", ((V)(string.Concat("<rect x=\"4\" y=\"2.5\" width=\"11.5\" height=\"6\" rx=\"0.6\" fill=\"#2a2a30\"/><circle cx=\"7\" cy=\"5.5\" r=\"1.4\" fill=\"#111114\"/><circle cx=\"12.5\" cy=\"5.5\" r=\"1.4\" fill=\"#111114\"/>", "")))).V).V);
}, 4, "", true);
Invoke(L_207, "push", NewObj(2).Put("q", Arr(((V)(24D)), ((V)(2D)), ((V)(6D)))).Put("s", Add(Add(Call(shadow_25, V.Undef, C_206, ((V)(24D)), ((V)(6D)), ((V)(13D)), ((V)(8D)), ((V)(0.7))), Call(tape_210, V.Undef, ((V)(0D)), ((V)(0.18)), ((V)("HOME MOVIES")), ((V)("#f4f1e6")))), Call(tape_210, V.Undef, ((V)(2.6)), ((V)((-0.08))), ((V)("SQUISH TOONS")), ((V)("#ffe27a"))))).V);
Invoke(L_207, "push", NewObj(2).Put("q", Arr(((V)((-30D))), ((V)(3D)), ((V)((-6D))))).Put("s", Call(curve_37, V.Undef, C_206, Arr(Arr(((V)((BX_136 - 16D))), ((V)(17D)), ((V)((-10D)))), Arr(((V)((-36D))), ((V)(8D)), ((V)((-10D)))), Arr(((V)((-36D))), ((V)(0.3)), ((V)(4D))), Arr(((V)((-26D))), ((V)(0.3)), ((V)(14D)))), ((V)("#1a1a1d")), ((V)(1.5)))).V);
return NewObj(3).Put("defs", DEF15_34).Put("front", Call(zsort_30, V.Undef, C_206, L_207)).Put("bb", Invoke(C_206, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_141;
return default;
}, 1, "", true));
Set(N_13, "pcspk15", Fn((V _arrowThis229, int _argc222, V S_228, V _a225, V _a226, V _a227, V[] _rest223) => {
V on_230 = default;
V BG_231 = default;
V D_232 = default;
V led_233 = default;
V knob_234 = default;
V stk_235 = default;
V fr_236 = default;
V top_237 = default;
V side_238 = default;
V book_239 = default;
on_230 = Call(isPlay_26, V.Undef, S_228);
BG_231 = ((V)("#dcd2b9"));
D_232 = NewObj(3).Put("w", ((V)(62D))).Put("d", ((V)(26D))).Put("build", Fn((V _arrowThis246, int _argc240, V _a242, V _a243, V _a244, V _a245, V[] _rest241) => {
return Arr();
}, 0, "build", true)).V;
led_233 = ((V)(string.Concat("<circle cx=\"2.8\" cy=\"14.6\" r=\"0.6\" fill=\"#5dff7a\">", (Truthy(on_230) ? "" : string.Concat("<animate attributeName=\"opacity\" values=\"1;1;0.2;1;0.3;1;1\" keyTimes=\"0;0.56;0.6;0.64;0.68;0.72;1\" dur=\"2.6s\" repeatCount=\"indefinite\"/>", "")), "</circle><circle cx=\"2.8\" cy=\"14.6\" r=\"1.4\" fill=\"#5dff7a\" opacity=\"0.25\"/>")));
knob_234 = ((V)(string.Concat("<circle cx=\"7.9\" cy=\"14.4\" r=\"1.3\" fill=\"#8a8270\"/><circle cx=\"7.9\" cy=\"14.4\" r=\"1\" fill=\"#c4baa2\"/><path d=\"M7.9 14.4l-0.6 -0.75\" stroke=\"#3a342a\" stroke-width=\"0.4\" stroke-linecap=\"round\"/>", "")));
stk_235 = ((V)(string.Concat("<g transform=\"rotate(-7 5.5 15)\"><rect x=\"2.3\" y=\"13.8\" width=\"6.4\" height=\"1.9\" fill=\"#c8ccd4\"/><text x=\"5.5\" y=\"15.2\" text-anchor=\"middle\" ", ToStr(FONT_24), " font-size=\"1.05\" fill=\"#2a2a7a\">MEGA BASS</text><path d=\"M8.7 13.8h-1.1l1.1 1.1z\" fill=\"#f4f4f4\"/></g>")));
fr_236 = Fn((V _arrowThis254, int _argc247, V left_253, V _a250, V _a251, V _a252, V[] _rest248) => {
return ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"1\" y=\"1\" width=\"9\" height=\"15.2\" rx=\"1.3\" fill=\"", ToStr(Call(shade_11, V.Undef, BG_231, ((V)(0.9)))), "\"/><circle cx=\"5.5\" cy=\"3.8\" r=\"1.6\" fill=\"#2b2622\"/><circle cx=\"5.5\" cy=\"3.8\" r=\"0.9\" fill=\"#6a6052\"/><circle cx=\"5.2\" cy=\"3.5\" r=\"0.3\" fill=\"#ffffff\" opacity=\"0.6\"/>")).V(Call(cone_36, V.Undef, ((V)(5.5)), ((V)(9.3)), ((V)(3.7)), on_230, ((V)((Truthy(left_253) ? 0D : 0.23))))).V((Truthy(left_253) ? Add(led_233, knob_234) : stk_235)).End()));
}, 1, "", true);
top_237 = ((V)(string.Concat("<path d=\"M1 5H10\" stroke=\"#000000\" stroke-opacity=\"0.12\" stroke-width=\"0.4\"/>", "")));
side_238 = Invoke(Call(rep_22, V.Undef, ((V)(3D)), Fn((V _arrowThis262, int _argc255, V i_261, V _a258, V _a259, V _a260, V[] _rest256) => {
return ((V)(string.Concat("<path d=\"M2.5 ", ToStr(Call(f1_20, V.Undef, ((V)((4D + (ToNum(i_261) * 1.3)))))), "H7.5\" stroke=\"#000000\" stroke-opacity=\"0.18\" stroke-width=\"0.5\" stroke-linecap=\"round\"/>")));
}, 1, "", true)), "join", ((V)("")));
book_239 = Fn((V _arrowThis275, int _argc263, V C_269, V x_270, V y_271, V yaw_272, V[] _rest264) => {
V col_273 = default;
V lab_274 = default;
col_273 = (_argc263 > 4 ? _rest264[0] : V.Undef);
lab_274 = (_argc263 > 5 ? _rest264[1] : V.Undef);
return Call(box3_32, V.Undef, C_269, NewObj(8).Put("c", Arr(x_270, y_271, ((V)(0D)))).Put("ax", Call(yawA_27, V.Undef, yaw_272)).Put("w", ((V)(15D))).Put("h", ((V)(2.8))).Put("d", ((V)(13D))).Put("r", ((V)(0.5))).Put("col", col_273).Put("dec", NewObj(2).Put("f", ((V)(string.Concat("<rect x=\"0.6\" y=\"0.45\" width=\"13.8\" height=\"1.9\" fill=\"#f3ecd8\"/><path d=\"M0.8 1H14.2M0.8 1.5H14.2M0.8 2H14.2\" stroke=\"#c9bfa4\" stroke-width=\"0.15\"/>", "")))).Put("t", ((V)((Truthy(lab_274) ? string.Concat("<text x=\"7.5\" y=\"11.6\" text-anchor=\"middle\" ", ToStr(FONT_24), " font-size=\"1.6\" fill=\"#3a2a10\">", ToStr(lab_274), "</text>") : "")))).V).V);
}, 6, "", true);
Set(D_232, "fx", Fn((V _arrowThis283, int _argc276, V ctx_282, V _a279, V _a280, V _a281, V[] _rest277) => {
V C_284 = default;
V L_285 = default;
JsStrBuf s_286 = null;
V pe_287 = default;
V pa_288 = default;
C_284 = Call(cam_15, V.Undef, ctx_282);
L_285 = Arr();
s_286 = new JsStrBuf("");
s_286.V(Add(Call(curve_37, V.Undef, C_284, Arr(Arr(((V)((-12D))), ((V)(9D)), ((V)((-5D)))), Arr(((V)((-8D))), ((V)(0.3)), ((V)((-13D)))), Arr(((V)(8D)), ((V)(0.3)), ((V)((-13D)))), Arr(((V)(12D)), ((V)(9D)), ((V)((-5D))))), ((V)("#8a8270")), ((V)(1.6))), Call(curve_37, V.Undef, C_284, Arr(Arr(((V)((-12D))), ((V)(9D)), ((V)((-5D)))), Arr(((V)((-8D))), ((V)(0.3)), ((V)((-13D)))), Arr(((V)(8D)), ((V)(0.3)), ((V)((-13D)))), Arr(((V)(12D)), ((V)(9D)), ((V)((-5D))))), ((V)("#d6ccb2")), ((V)(0.9)))));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis296, int _argc289, V sg_295, V _a292, V _a293, V _a294, V[] _rest290) => {
double x_297 = 0;
double yaw_298 = 0;
V g_299 = default;
x_297 = (ToNum(sg_295) * 14D);
yaw_298 = ((-ToNum(sg_295)) * 0.22);
g_299 = Add(Add(Add(Call(shadow_25, V.Undef, C_284, ((V)(x_297)), ((V)(0D)), ((V)(10D)), ((V)(8.5)), ((V)(0.8))), Call(book_239, V.Undef, C_284, ((V)(x_297)), ((V)(0D)), ((V)(((yaw_298 * 0.5) + (0.06 * ToNum(sg_295))))), ((V)("#f0cd45")), ((V)("PHONE BOOK")))), Call(book_239, V.Undef, C_284, ((V)((x_297 + (ToNum(sg_295) * 0.5)))), ((V)(2.8)), ((V)((yaw_298 - (0.1 * ToNum(sg_295))))), ((V)("#5a9fd6")), ((V)("")))), Call(box3_32, V.Undef, C_284, NewObj(8).Put("c", Arr(((V)(x_297)), ((V)(5.6)), ((V)(0D)))).Put("ax", Call(yawA_27, V.Undef, ((V)(yaw_298)))).Put("w", ((V)(11D))).Put("h", ((V)(17D))).Put("d", ((V)(10D))).Put("r", ((V)(1.8))).Put("col", BG_231).Put("dec", NewObj(4).Put("f", Call(fr_236, V.Undef, (LtN(sg_295, 0D) ? V.True : V.False))).Put("t", top_237).Put("r", side_238).Put("l", side_238).V).V));
if ((GtN(sg_295, 0D) && !(Truthy(on_230)))) {
g_299 = ((V)(string.Concat("<g>", ToStr(Call(at_18, V.Undef, ((V)("translate")), ((V)("0 0;0 0;0.35 0;-0.35 0;0.3 -0.1;0 0;0 0")), ((V)(2.6)), ((V)(0D)), ((V)(" keyTimes=\"0;0.56;0.6;0.64;0.68;0.72;1\"")))), ToStr(g_299), "</g>")));
}
Invoke(L_285, "push", NewObj(2).Put("q", Arr(((V)(x_297)), ((V)(8D)), ((V)(0D)))).Put("s", g_299).V);
return default;
}, 1, "", true));
s_286.V(Call(zsort_30, V.Undef, C_284, L_285));
pe_287 = Invoke(C_284, "p", ((V)((-24D))), ((V)(0.3)), ((V)(13D)));
pa_288 = Invoke(C_284, "p", ((V)((-21D))), ((V)(0.3)), ((V)(16.5)));
s_286.V(Add(Call(curve_37, V.Undef, C_284, Arr(Arr(((V)((-19D))), ((V)(7D)), ((V)((-2D)))), Arr(((V)((-26D))), ((V)(2D)), ((V)((-3D)))), Arr(((V)((-30D))), ((V)(0.3)), ((V)(8D))), Arr(((V)((-24D))), ((V)(0.3)), ((V)(13D)))), ((V)("#8a8270")), ((V)(1.4))), Call(curve_37, V.Undef, C_284, Arr(Arr(((V)((-19D))), ((V)(7D)), ((V)((-2D)))), Arr(((V)((-26D))), ((V)(2D)), ((V)((-3D)))), Arr(((V)((-30D))), ((V)(0.3)), ((V)(8D))), Arr(((V)((-24D))), ((V)(0.3)), ((V)(13D)))), ((V)("#d6ccb2")), ((V)(0.75))))).S(string.Concat("<path d=\"M", ToStr(Call(P2_23, V.Undef, pe_287)), "L", ToStr(Call(P2_23, V.Undef, pa_288)), "\" stroke=\"#5a5550\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((1.8 * ToNum(Get(C_284, "k"))))))), "\" stroke-linecap=\"round\"/><path d=\"M", ToStr(Call(P2_23, V.Undef, pe_287)), "L", ToStr(Call(P2_23, V.Undef, pa_288)), "\" stroke=\"#d9dce2\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.9 * ToNum(Get(C_284, "k"))))))), "\" stroke-linecap=\"round\"/>"));
if (!(Truthy(on_230))) {
V b_300 = default;
V k_301 = default;
V z_302 = default;
b_300 = Invoke(C_284, "p", ((V)(21D)), ((V)(21D)), ((V)(2D)));
k_301 = Get(C_284, "k");
z_302 = ((V)(string.Concat("l", ToStr(Call(f1_20, V.Undef, ((V)((0.9 * ToNum(k_301)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)(((-1.1) * ToNum(k_301)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((0.9 * ToNum(k_301)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((1.1 * ToNum(k_301)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((0.9 * ToNum(k_301)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)(((-1.1) * ToNum(k_301)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((0.9 * ToNum(k_301)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((1.1 * ToNum(k_301)))))))));
s_286.S(string.Concat("<g fill=\"none\" stroke=\"#5a4a2a\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.5 * ToNum(k_301)))))), "\" stroke-linecap=\"round\" stroke-linejoin=\"round\" opacity=\"0\"><animate attributeName=\"opacity\" values=\"0;0;1;1;0;0\" keyTimes=\"0;0.55;0.58;0.72;0.76;1\" dur=\"2.6s\" repeatCount=\"indefinite\"/>")).S(string.Concat("<path d=\"M", ToStr(Call(f1_20, V.Undef, GetIdx(b_300, 0D))), " ", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(b_300, 1D)) - (2D * ToNum(k_301))))))), ToStr(z_302), "\" transform=\"rotate(-25 ", ToStr(Call(f1_20, V.Undef, GetIdx(b_300, 0D))), " ", ToStr(Call(f1_20, V.Undef, GetIdx(b_300, 1D))), ")\"/><path d=\"M", ToStr(Call(f1_20, V.Undef, Add(GetIdx(b_300, 0D), ((V)((1D * ToNum(k_301))))))), " ", ToStr(Call(f1_20, V.Undef, Add(GetIdx(b_300, 1D), ((V)((1.2 * ToNum(k_301))))))), ToStr(z_302), "\"/><path d=\"M", ToStr(Call(f1_20, V.Undef, GetIdx(b_300, 0D))), " ", ToStr(Call(f1_20, V.Undef, Add(GetIdx(b_300, 1D), ((V)((4.6 * ToNum(k_301))))))), ToStr(z_302), "\" transform=\"rotate(22 ", ToStr(Call(f1_20, V.Undef, GetIdx(b_300, 0D))), " ", ToStr(Call(f1_20, V.Undef, Add(GetIdx(b_300, 1D), ((V)((4.6 * ToNum(k_301))))))), ")\"/>")).S(string.Concat("<text x=\"", ToStr(Call(f1_20, V.Undef, Add(GetIdx(b_300, 0D), ((V)((5.4 * ToNum(k_301))))))), "\" y=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(b_300, 1D)) - (2.2 * ToNum(k_301))))))), "\" ", ToStr(FONT_24), " font-size=\"", ToStr(Call(f1_20, V.Undef, ((V)((2.2 * ToNum(k_301)))))), "\" fill=\"#5a4a2a\" stroke=\"none\">bzz</text></g>"));
Call(ext_29, V.Undef, C_284, Arr(Arr(((V)(30D)), ((V)(26D)), ((V)(2D)))));
}
return NewObj(3).Put("defs", DEF15_34).Put("front", ((V)(s_286.Str))).Put("bb", Invoke(C_284, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_232;
return default;
}, 1, "", true));
Set(N_13, "drop15", Fn((V _arrowThis310, int _argc303, V S_309, V _a306, V _a307, V _a308, V[] _rest304) => {
double SW_311 = 0;
double SH_312 = 0;
double BD_313 = 0;
double DR_314 = 0;
double FW_315 = 0;
double FH_316 = 0;
double Y0_317 = 0;
double YH_318 = 0;
double HH_319 = 0;
double HW_320 = 0;
double ZS_321 = 0;
V D_322 = default;
V fab_323 = default;
V hsF_324 = default;
V capF_325 = default;
SW_311 = 252D;
SH_312 = 141.75;
BD_313 = 4D;
DR_314 = 12D;
FW_315 = (SW_311 + (2D * BD_313));
FH_316 = ((BD_313 + SH_312) + DR_314);
Y0_317 = 4D;
YH_318 = (Y0_317 + FH_316);
HH_319 = 9D;
HW_320 = (FW_315 + 14D);
ZS_321 = 6D;
D_322 = NewObj(6).Put("w", ((V)((HW_320 + 12D)))).Put("d", ((V)(12D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(22D))).Put("act", ((V)("watch"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(180D))).V).V;
Set(D_322, "build", Fn((V _arrowThis332, int _argc326, V _a328, V _a329, V _a330, V _a331, V[] _rest327) => {
return Arr(Call(slab_12, V.Undef, ((V)(0D)), ((V)((Y0_317 + BD_313))), ((V)((ZS_321 + 0.4))), ((V)(SW_311)), ((V)(SH_312)), ((V)(0.2)), ((V)("#000000")), NewObj(5).Put("scr", ((V)(1D))).Put("r", ((V)(0.3))).Put("emit", ((V)(1D))).Put("noOut", ((V)(1D))).Put("op", ((V)(0D))).V));
}, 0, "", true));
fab_323 = ((V)(string.Concat(string.Concat("<rect width=\"", NumStr(FW_315), "\" height=\"", NumStr(FH_316), "\" fill=\"#16171b\"/><rect x=\"", NumStr(BD_313), "\" y=\"", NumStr(DR_314), "\" width=\"", NumStr(SW_311), "\" height=\"", ToStr(Call(f1_20, V.Undef, ((V)(SH_312)))), "\" fill=\"url(#p15scr)\"/>"), string.Concat("<rect x=\"", NumStr(BD_313), "\" y=\"", NumStr(DR_314), "\" width=\"", NumStr(SW_311), "\" height=\"", ToStr(Call(f1_20, V.Undef, ((V)(SH_312)))), "\" fill=\"none\" stroke=\"#000000\" stroke-opacity=\"0.2\" stroke-width=\"0.6\"/>"), string.Concat("<defs><clipPath id=\"dp15c\"><rect x=\"", NumStr(BD_313), "\" y=\"", NumStr(DR_314), "\" width=\"", NumStr(SW_311), "\" height=\"", ToStr(Call(f1_20, V.Undef, ((V)(SH_312)))), "\"/></clipPath></defs><g clip-path=\"url(#dp15c)\"><rect x=\"-60\" y=\"", NumStr(DR_314), "\" width=\"40\" height=\"", ToStr(Call(f1_20, V.Undef, ((V)(SH_312)))), "\" fill=\"url(#p15shn)\" opacity=\"0.45\" transform=\"skewX(-14)\">", ToStr(Call(an_17, V.Undef, ((V)("x")), ((V)(string.Concat("-60;", NumStr((FW_315 + 80D))))), ((V)(9D)))), "</rect></g>"), string.Concat("<path d=\"M", NumStr(BD_313), " ", NumStr((DR_314 + 0.4)), "H", NumStr((BD_313 + SW_311)), "\" stroke=\"#ffffff\" stroke-opacity=\"0.6\" stroke-width=\"0.4\"/>"))));
hsF_324 = ((V)(string.Concat("<rect x=\"6\" y=\"", NumStr((HH_319 - 1.4)), "\" width=\"", NumStr((HW_320 - 12D)), "\" height=\"1\" rx=\"0.5\" fill=\"#08080a\"/><path d=\"M3 0.6H", NumStr((HW_320 - 3D)), "\" stroke=\"#ffffff\" stroke-opacity=\"0.2\" stroke-width=\"0.4\"/><text x=\"", NumStr((HW_320 - 22D)), "\" y=\"5.4\" text-anchor=\"middle\" ", ToStr(FONT_24), " font-size=\"2.4\" letter-spacing=\"0.8\" fill=\"#8a8e98\">LUMA 150</text>")));
capF_325 = ((V)(string.Concat("<circle cx=\"2.5\" cy=\"3\" r=\"0.7\" fill=\"#4ab8ff\">", ToStr(Call(an_17, V.Undef, ((V)("opacity")), ((V)("1;0.35;1")), ((V)(2.4)))), "</circle><circle cx=\"2.5\" cy=\"3\" r=\"1.6\" fill=\"#4ab8ff\" opacity=\"0.25\"/><rect x=\"1.4\" y=\"5.6\" width=\"2.2\" height=\"2.2\" rx=\"0.4\" fill=\"#3a1414\"/>")));
Set(D_322, "fx", Fn((V _arrowThis340, int _argc333, V ctx_339, V _a336, V _a337, V _a338, V[] _rest334) => {
V C_341 = default;
JsStrBuf s_342 = null;
C_341 = Call(cam_15, V.Undef, ctx_339);
s_342 = new JsStrBuf("");
s_342.V(Call(WD_31, V.Undef, C_341, ((V)((((-FW_315) / 2D) + 1D))), ((V)((YH_318 - 3D))), ((V)(0.1)), ((V)(string.Concat("<rect width=\"", NumStr((FW_315 + 4D)), "\" height=\"", NumStr((FH_316 + 4D)), "\" rx=\"3\" fill=\"#000000\" opacity=\"0.1\"/><rect x=\"2\" y=\"1.5\" width=\"", NumStr(FW_315), "\" height=\"", NumStr((FH_316 + 1D)), "\" rx=\"2\" fill=\"#000000\" opacity=\"0.14\"/>"))), ((V)(FW_315)), ((V)(FH_316))));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis350, int _argc343, V sg_349, V _a346, V _a347, V _a348, V[] _rest344) => {
return ((V)(s_342.V(Call(box3_32, V.Undef, C_341, NewObj(6).Put("c", Arr(((V)((ToNum(sg_349) * ((HW_320 / 2D) - 24D)))), ((V)((YH_318 - 2D))), ((V)(0.6)))).Put("w", ((V)(6D))).Put("h", ((V)(13D))).Put("d", ((V)(1.2))).Put("r", ((V)(0.3))).Put("col", ((V)("#3a3c42"))).V)).Str));
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis358, int _argc351, V sg_357, V _a354, V _a355, V _a356, V[] _rest352) => {
return ((V)(s_342.V(Call(cyl3_33, V.Undef, C_341, Arr(((V)((ToNum(sg_357) * ((FW_315 / 2D) + 1.4)))), ((V)(Y0_317)), ((V)((ZS_321 + 0.4)))), Arr(((V)((ToNum(sg_357) * ((FW_315 / 2D) + 1.4)))), ((V)(YH_318)), ((V)((ZS_321 + 0.4)))), ((V)(0.35)), ((V)("#4a4c52")))).Str));
}, 1, "", true));
s_342.V(Call(box3_32, V.Undef, C_341, NewObj(7).Put("c", Arr(((V)(0D)), ((V)(Y0_317)), ((V)(ZS_321)))).Put("w", ((V)(FW_315))).Put("h", ((V)(FH_316))).Put("d", ((V)(0.6))).Put("r", ((V)(0.1))).Put("col", ((V)("#eeeee8"))).Put("dec", NewObj(1).Put("f", fab_323).V).V));
s_342.V(Call(cyl3_33, V.Undef, C_341, Arr(((V)((((-FW_315) / 2D) - 2D))), ((V)(Y0_317)), ((V)((ZS_321 + 0.4)))), Arr(((V)(((FW_315 / 2D) + 2D))), ((V)(Y0_317)), ((V)((ZS_321 + 0.4)))), ((V)(2D)), ((V)("#1d1e22")), NewObj(1).Put("mat", ((V)("gloss"))).V));
s_342.V(Call(box3_32, V.Undef, C_341, NewObj(7).Put("c", Arr(((V)(0D)), ((V)(YH_318)), ((V)(5D)))).Put("w", ((V)(HW_320))).Put("h", ((V)(HH_319))).Put("d", ((V)(10D))).Put("r", ((V)(2D))).Put("col", ((V)("#2a2c31"))).Put("dec", NewObj(1).Put("f", hsF_324).V).V));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis366, int _argc359, V sg_365, V _a362, V _a363, V _a364, V[] _rest360) => {
return ((V)(s_342.V(Call(box3_32, V.Undef, C_341, NewObj(7).Put("c", Arr(((V)((ToNum(sg_365) * ((HW_320 / 2D) + 2.4)))), ((V)((YH_318 - 0.5))), ((V)(5D)))).Put("w", ((V)(5D))).Put("h", ((V)(10D))).Put("d", ((V)(11D))).Put("r", ((V)(1.4))).Put("col", ((V)("#1c1d21"))).Put("dec", (GtN(sg_365, 0D) ? NewObj(1).Put("f", capF_325).V : V.Null)).V)).Str));
}, 1, "", true));
return NewObj(3).Put("defs", DEF15_34).Put("front", ((V)(s_342.Str))).Put("bb", Invoke(C_341, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_322;
return default;
}, 1, "", true));
Set(N_13, "holo15", Fn((V _arrowThis374, int _argc367, V S_373, V _a370, V _a371, V _a372, V[] _rest368) => {
double SW_375 = 0;
double SH_376 = 0;
double BZ_377 = 0;
double PW_378 = 0;
double PH_379 = 0;
double WW_380 = 0;
double A_381 = 0;
double NS_382 = 0;
double SL_383 = 0;
double Y0_384 = 0;
double ZC_385 = 0;
V D_386 = default;
V top_387 = default;
V panF_388 = default;
V BLOB_389 = default;
V wingC_390 = default;
V seg_391 = default;
SW_375 = 300D;
SH_376 = 168.75;
BZ_377 = 1.6;
PW_378 = (SW_375 + (2D * BZ_377));
PH_379 = (SH_376 + (2D * BZ_377));
WW_380 = 84D;
A_381 = 0.8;
NS_382 = 3D;
SL_383 = (WW_380 / NS_382);
Y0_384 = 18D;
ZC_385 = 10D;
D_386 = NewObj(6).Put("w", ((V)(((PW_378 + ((2D * WW_380) * 0.8)) + 24D)))).Put("d", ((V)(14D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(16D))).Put("act", ((V)("watch"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(200D))).V).V;
Set(D_386, "build", Fn((V _arrowThis398, int _argc392, V _a394, V _a395, V _a396, V _a397, V[] _rest393) => {
return Arr(Call(slab_12, V.Undef, ((V)(0D)), ((V)((Y0_384 + BZ_377))), ((V)((ZC_385 + 1.55))), ((V)(SW_375)), ((V)(SH_376)), ((V)(0.2)), ((V)("#000000")), NewObj(5).Put("scr", ((V)(1D))).Put("r", ((V)(0.3))).Put("emit", ((V)(1D))).Put("noOut", ((V)(1D))).Put("op", ((V)(0D))).V));
}, 0, "", true));
top_387 = Fn((V _arrowThis407, int _argc399, V w_405, V d_406, V _a403, V _a404, V[] _rest400) => {
return ((V)(string.Concat("<path d=\"M0 0.5H", ToStr(Call(f1_20, V.Undef, w_405)), "\" stroke=\"#8ff6ff\" stroke-width=\"0.7\" stroke-dasharray=\"7 11\" stroke-linecap=\"round\">", ToStr(Call(an_17, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;-36")), ((V)(3D)))), "</path>")));
}, 2, "", true);
panF_388 = ((V)(string.Concat(string.Concat("<rect width=\"", ToStr(Call(f1_20, V.Undef, ((V)(PW_378)))), "\" height=\"", ToStr(Call(f1_20, V.Undef, ((V)(PH_379)))), "\" fill=\"#0b0c12\"/><rect x=\"", NumStr(BZ_377), "\" y=\"", NumStr(BZ_377), "\" width=\"", NumStr(SW_375), "\" height=\"", ToStr(Call(f1_20, V.Undef, ((V)(SH_376)))), "\" fill=\"url(#p15gls)\"/>"), string.Concat("<path d=\"M", ToStr(Call(f1_20, V.Undef, ((V)((PW_378 * 0.52))))), " ", NumStr(BZ_377), "H", ToStr(Call(f1_20, V.Undef, ((V)((PW_378 * 0.7))))), "L", ToStr(Call(f1_20, V.Undef, ((V)((PW_378 * 0.5))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((PH_379 - BZ_377))))), "H", ToStr(Call(f1_20, V.Undef, ((V)((PW_378 * 0.32))))), "Z\" fill=\"#ffffff\" opacity=\"0.045\"/>"), string.Concat("<rect x=\"0.3\" y=\"0.3\" width=\"", ToStr(Call(f1_20, V.Undef, ((V)((PW_378 - 0.6))))), "\" height=\"", ToStr(Call(f1_20, V.Undef, ((V)((PH_379 - 0.6))))), "\" fill=\"none\" stroke=\"#8ff6ff\" stroke-opacity=\"0.5\" stroke-width=\"0.5\">", ToStr(Call(an_17, V.Undef, ((V)("stroke-opacity")), ((V)("0.3;0.7;0.3")), ((V)(3.6)))), "</rect>"))));
BLOB_389 = Arr(Arr(((V)("#3fd0ff")), ((V)(9D))), Arr(((V)("#9a5bff")), ((V)(11D))), Arr(((V)("#ff5fb4")), ((V)(8D))), Arr(((V)("#5bffc8")), ((V)(12.5))));
wingC_390 = Fn((V _arrowThis416, int _argc408, V right_414, V uid_415, V _a412, V _a413, V[] _rest409) => {
double W_417 = 0;
double Hh_418 = 0;
V fd_419 = default;
W_417 = WW_380;
Hh_418 = PH_379;
fd_419 = ((V)(JsStrBuf.Begin().V(uid_415).S("f").End()));
return ((V)(JsStrBuf.Begin().S(string.Concat("<defs><linearGradient id=\"", ToStr(fd_419), "\" x1=\"", NumStr((Truthy(right_414) ? 1D : 0D)), "\" y1=\"0\" x2=\"", NumStr((Truthy(right_414) ? 0D : 1D)), "\" y2=\"0\"><stop offset=\"0\" stop-color=\"#05060c\" stop-opacity=\"0.9\"/><stop offset=\"1\" stop-color=\"#05060c\" stop-opacity=\"0\"/></linearGradient></defs>")).S(string.Concat("<rect width=\"", NumStr(W_417), "\" height=\"", ToStr(Call(f1_20, V.Undef, ((V)(Hh_418)))), "\" fill=\"#0a0c1c\"/><g>")).V(Invoke(Invoke(BLOB_389, "map", Fn((V _arrowThis432, int _argc420, V _a422, V i_426, V _a424, V _a425, V[] _rest421) => {
double y0_433 = 0;
double x0_434 = 0;
V c_429 = default;
V T_431 = default;
{ V _t427 = ListOf(_a422);
{ V _t428 = GetIdx(_t427, 0D);
c_429 = _t428; }
{ V _t430 = GetIdx(_t427, 1D);
T_431 = _t430; }
}
y0_433 = (Hh_418 * (0.2 + (0.22 * ToNum(i_426))));
x0_434 = (W_417 * (Truthy(right_414) ? 0.3 : 0.7));
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, ((V)(x0_434)))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, ((V)(y0_433)))), "\" rx=\"36\" ry=\"46\" fill=\"url(#p15o", ToStr(i_426), ")\">", ToStr(Call(an_17, V.Undef, ((V)("cy")), ((V)(string.Concat(ToStr(Call(f1_20, V.Undef, ((V)(y0_433)))), ";", ToStr(Call(f1_20, V.Undef, ((V)(((y0_433 + (Hh_418 * 0.45)) % Hh_418))))), ";", ToStr(Call(f1_20, V.Undef, ((V)(y0_433))))))), T_431, ((V)(((-ToNum(i_426)) * 1.7))), Call(SPL_19, V.Undef, ((V)(2D))))), ToStr(Call(an_17, V.Undef, ((V)("cx")), ((V)(string.Concat(ToStr(Call(f1_20, V.Undef, ((V)(x0_434)))), ";", ToStr(Call(f1_20, V.Undef, ((V)((W_417 - x0_434))))), ";", ToStr(Call(f1_20, V.Undef, ((V)(x0_434))))))), ((V)((ToNum(T_431) * 1.3))), ((V)((-ToNum(i_426)))), Call(SPL_19, V.Undef, ((V)(2D))))), "</ellipse>")));
return default;
}, 2, "", true)), "join", ((V)("")))).S(string.Concat("</g><rect width=\"", NumStr(W_417), "\" height=\"", ToStr(Call(f1_20, V.Undef, ((V)(Hh_418)))), "\" fill=\"url(#p15px)\"/><rect width=\"", NumStr(W_417), "\" height=\"", ToStr(Call(f1_20, V.Undef, ((V)(Hh_418)))), "\" fill=\"url(#", ToStr(fd_419), ")\"/>")).S(string.Concat("<rect x=\"-24\" width=\"16\" height=\"", ToStr(Call(f1_20, V.Undef, ((V)(Hh_418)))), "\" fill=\"url(#p15shn)\" opacity=\"0.35\">", ToStr(Call(an_17, V.Undef, ((V)("x")), ((V)(string.Concat("-24;", NumStr((W_417 + 24D))))), ((V)(5.5)), ((V)((Truthy(right_414) ? (-2.75) : 0D))))), "</rect>")).End()));
return default;
}, 2, "", true);
seg_391 = Fn((V _arrowThis444, int _argc435, V cnt_441, V off_442, V cl_443, V _a440, V[] _rest436) => {
return ((V)(string.Concat("<defs><clipPath id=\"", ToStr(cl_443), "\"><rect width=\"", ToStr(Call(f1_20, V.Undef, ((V)(SL_383)))), "\" height=\"", ToStr(Call(f1_20, V.Undef, ((V)(PH_379)))), "\"/></clipPath></defs><g clip-path=\"url(#", ToStr(cl_443), ")\"><g transform=\"translate(", ToStr(Call(f1_20, V.Undef, ((V)((-ToNum(off_442)))))), " 0)\">", ToStr(cnt_441), "</g></g><rect x=\"0.3\" y=\"0.3\" width=\"", ToStr(Call(f1_20, V.Undef, ((V)((SL_383 - 0.6))))), "\" height=\"", ToStr(Call(f1_20, V.Undef, ((V)((PH_379 - 0.6))))), "\" fill=\"none\" stroke=\"#8ff6ff\" stroke-opacity=\"0.3\" stroke-width=\"0.4\"/>")));
}, 3, "", true);
Set(D_386, "fx", Fn((V _arrowThis452, int _argc445, V ctx_451, V _a448, V _a449, V _a450, V[] _rest446) => {
V C_453 = default;
JsStrBuf s_454 = null;
V GC_455 = default;
V gs_456 = default;
V k_457 = default;
double ty_458 = 0;
double ey_459 = 0;
V b0_460 = default;
V b1_461 = default;
V t0_462 = default;
V t1_463 = default;
V emF_464 = default;
C_453 = Call(cam_15, V.Undef, ctx_451);
s_454 = new JsStrBuf("");
GC_455 = ((V)("#5b6cff;#b04dff;#ff5a8a;#33c9d6;#5b6cff"));
gs_456 = Fn((V _arrowThis473, int _argc465, V o_471, V op_472, V _a469, V _a470, V[] _rest466) => {
return ((V)(string.Concat("<stop offset=\"", ToStr(o_471), "\" stop-color=\"#5b6cff\" stop-opacity=\"", ToStr(op_472), "\">", ToStr(Call(an_17, V.Undef, ((V)("stop-color")), GC_455, ((V)(16D)))), "</stop>")));
}, 2, "", true);
s_454.V(Call(WD_31, V.Undef, C_453, ((V)((((-PW_378) / 2D) - 70D))), ((V)(((Y0_384 + PH_379) + 34D))), ((V)(0.05)), ((V)(string.Concat("<defs><radialGradient id=\"hl15g\" cx=\"50%\" cy=\"50%\" r=\"50%\">", ToStr(Call(gs_456, V.Undef, ((V)(0D)), ((V)(0.8)))), ToStr(Call(gs_456, V.Undef, ((V)(0.66)), ((V)(0.6)))), ToStr(Call(gs_456, V.Undef, ((V)(1D)), ((V)(0D)))), "</radialGradient></defs><rect width=\"", ToStr(Call(f1_20, V.Undef, ((V)((PW_378 + 140D))))), "\" height=\"", ToStr(Call(f1_20, V.Undef, ((V)((PH_379 + 64D))))), "\" fill=\"url(#hl15g)\"/>"))), ((V)((PW_378 + 140D))), ((V)((PH_379 + 64D)))));
s_454.V(Call(WD_31, V.Undef, C_453, ((V)((((-PW_378) / 2D) + 1D))), ((V)(((Y0_384 + PH_379) - 2D))), ((V)(0.1)), ((V)(string.Concat("<rect width=\"", ToStr(Call(f1_20, V.Undef, ((V)((PW_378 + 4D))))), "\" height=\"", ToStr(Call(f1_20, V.Undef, ((V)((PH_379 + 4D))))), "\" rx=\"3\" fill=\"#000000\" opacity=\"0.12\"/><rect x=\"2\" y=\"1.5\" width=\"", ToStr(Call(f1_20, V.Undef, ((V)(PW_378)))), "\" height=\"", ToStr(Call(f1_20, V.Undef, ((V)((PH_379 + 1D))))), "\" rx=\"2\" fill=\"#000000\" opacity=\"0.16\"/>")))));
s_454.V(Call(box3_32, V.Undef, C_453, NewObj(7).Put("c", Arr(((V)(0D)), ((V)(Y0_384)), ((V)(ZC_385)))).Put("w", ((V)(PW_378))).Put("h", ((V)(PH_379))).Put("d", ((V)(3D))).Put("r", ((V)(0.4))).Put("col", ((V)("#15161c"))).Put("dec", NewObj(2).Put("f", panF_388).Put("t", Call(top_387, V.Undef, ((V)(PW_378)))).V).V));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis481, int _argc474, V sg_480, V _a477, V _a478, V _a479, V[] _rest475) => {
V cnt_482 = default;
double px_483 = 0;
double pz_484 = 0;
cnt_482 = Call(wingC_390, V.Undef, (GtN(sg_480, 0D) ? V.True : V.False), Invoke(C_453, "u", ((V)("hw"))));
px_483 = ((ToNum(sg_480) * PW_378) / 2D);
pz_484 = ZC_385;
{
double i_485 = 0;
i_485 = 0D;
while (true) {
if (!((i_485 < NS_382))) break;
double a_487 = 0;
double dx_488 = 0;
double dz_489 = 0;
V c_490 = default;
double off_491 = 0;
a_487 = ((A_381 * (i_485 + 1D)) / NS_382);
dx_488 = (ToNum(sg_480) * FdLibm.Cos(a_487));
dz_489 = FdLibm.Sin(a_487);
c_490 = Arr(((V)((px_483 + ((dx_488 * SL_383) / 2D)))), ((V)(Y0_384)), ((V)((pz_484 + ((dz_489 * SL_383) / 2D)))));
off_491 = (LtN(sg_480, 0D) ? (WW_380 - ((i_485 + 1D) * SL_383)) : (i_485 * SL_383));
s_454.V(Call(box3_32, V.Undef, C_453, NewObj(8).Put("c", c_490).Put("ax", Call(yawA_27, V.Undef, ((V)((LtN(sg_480, 0D) ? a_487 : (-a_487)))))).Put("w", ((V)((SL_383 + 0.4)))).Put("h", ((V)(PH_379))).Put("d", ((V)(3D))).Put("r", ((V)(0.2))).Put("col", ((V)("#15161c"))).Put("dec", NewObj(2).Put("f", Call(seg_391, V.Undef, cnt_482, ((V)(off_491)), Invoke(C_453, "u", ((V)("hs"))))).Put("t", Call(top_387, V.Undef, ((V)(SL_383)))).V).V));
px_483 = (px_483 + (dx_488 * SL_383));
pz_484 = (pz_484 + (dz_489 * SL_383));
i_485++;
}
}
return default;
}, 1, "", true));
k_457 = Get(C_453, "k");
ty_458 = ((Y0_384 + PH_379) + 1D);
s_454.V(Invoke(Call(rep_22, V.Undef, ((V)(12D)), Fn((V _arrowThis499, int _argc492, V i_498, V _a495, V _a496, V _a497, V[] _rest493) => {
double x_500 = 0;
V p_501 = default;
double d_502 = 0;
x_500 = ((((-PW_378) / 2D) + ((PW_378 * ToNum(Add(i_498, ((V)(0.5))))) / 12D)) + (NumTruthy((ToNum(i_498) % 2D)) ? 6D : (-4D)));
p_501 = Invoke(C_453, "p", ((V)(x_500)), ((V)(ty_458)), ((V)((ZC_385 + 1.5))));
d_502 = (3D + (((ToNum(i_498) * 7D) % 5D) * 0.6));
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.8 * ToNum(k_457)))))), "\" fill=\"#dffcff\" opacity=\"0\"><animate attributeName=\"opacity\" values=\"0;0.95;0\" dur=\"", ToStr(Call(n4_21, V.Undef, ((V)(d_502)))), "s\" begin=\"", ToStr(Call(n4_21, V.Undef, ((V)(((-ToNum(i_498)) * 0.37))))), "s\" repeatCount=\"indefinite\"/><animateMotion dur=\"", ToStr(Call(n4_21, V.Undef, ((V)(d_502)))), "s\" begin=\"", ToStr(Call(n4_21, V.Undef, ((V)(((-ToNum(i_498)) * 0.37))))), "s\" repeatCount=\"indefinite\" path=\"M", ToStr(Call(P2_23, V.Undef, p_501)), "l", ToStr(Call(f1_20, V.Undef, ((V)(((((ToNum(i_498) % 3D) - 1D) * 2D) * ToNum(k_457)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)(((-18D) * ToNum(k_457)))))), "\"/></circle>")));
return default;
}, 1, "", true)), "join", ((V)(""))));
Call(ext_29, V.Undef, C_453, Arr(Arr(((V)(0D)), ((V)((ty_458 + 20D))), ((V)(ZC_385)))));
ey_459 = (Y0_384 - 15D);
b0_460 = Invoke(C_453, "p", ((V)((-80D))), ((V)((ey_459 + 4.4))), ((V)(ZC_385)));
b1_461 = Invoke(C_453, "p", ((V)(80D)), ((V)((ey_459 + 4.4))), ((V)(ZC_385)));
t0_462 = Invoke(C_453, "p", ((V)(((-SW_375) / 2D))), ((V)(Y0_384)), ((V)((ZC_385 + 1.5))));
t1_463 = Invoke(C_453, "p", ((V)((SW_375 / 2D))), ((V)(Y0_384)), ((V)((ZC_385 + 1.5))));
s_454.S(string.Concat("<path d=\"M", ToStr(Call(P2_23, V.Undef, b0_460)), "L", ToStr(Call(P2_23, V.Undef, t0_462)), "L", ToStr(Call(P2_23, V.Undef, t1_463)), "L", ToStr(Call(P2_23, V.Undef, b1_461)), "Z\" fill=\"url(#p15bm)\">", ToStr(Call(an_17, V.Undef, ((V)("opacity")), ((V)("0.5;0.9;0.6;0.85;0.5")), ((V)(2.8)))), "</path>"));
emF_464 = ((V)(string.Concat("<rect x=\"6\" y=\"1.6\" width=\"148\" height=\"1.2\" rx=\"0.6\" fill=\"#8ff6ff\">", ToStr(Call(an_17, V.Undef, ((V)("opacity")), ((V)("0.55;1;0.55")), ((V)(2.2)))), "</rect><text x=\"80\" y=\"4.1\" text-anchor=\"middle\" ", ToStr(FONT_24), " font-size=\"1.1\" letter-spacing=\"0.8\" fill=\"#6a7088\">16K MicroLED</text>")));
s_454.S(string.Concat("<g>", ToStr(Call(at_18, V.Undef, ((V)("translate")), ((V)(string.Concat("0 0;0 ", ToStr(Call(f1_20, V.Undef, ((V)(((-1.2) * ToNum(k_457)))))), ";0 0"))), ((V)(3.4)), ((V)(0D)), Call(SPL_19, V.Undef, ((V)(2D))))), ToStr(Call(WD_31, V.Undef, C_453, ((V)((-60D))), ((V)((ey_459 - 6D))), ((V)(0.05)), ((V)(string.Concat("<ellipse cx=\"60\" cy=\"3\" rx=\"70\" ry=\"6\" fill=\"url(#p15em)\"/>", ""))))), ToStr(Call(box3_32, V.Undef, C_453, NewObj(7).Put("c", Arr(((V)(0D)), ((V)(ey_459)), ((V)(ZC_385)))).Put("w", ((V)(160D))).Put("h", ((V)(4.4))).Put("d", ((V)(7D))).Put("r", ((V)(2D))).Put("col", ((V)("#1c1e28"))).Put("dec", NewObj(1).Put("f", emF_464).V).V)), "</g>"));
return NewObj(3).Put("defs", DEF15_34).Put("front", ((V)(s_454.Str))).Put("bb", Invoke(C_453, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_386;
return default;
}, 1, "", true));
Set(RD_8, "SET15", NewObj(4).Put("MOV-006", NewObj(2).Put("spec", ((V)("vhs15"))).Put("note", ((V)("A chunky old VHS deck with its clock stuck blinking 12:00, a boxy beige mini projector on top with a hand-written \"MOM'S\" sticker, all stacked on a FRAGILE moving box. Two labelled tapes lie beside it and the cable trails off to the wall."))).V).Put("MOV-010", NewObj(3).Put("spec", ((V)("pcspk15"))).Put("live", ((V)("Buzzing"))).Put("note", ((V)("Two yellowed beige PC speakers propped up on old phone books, toed in toward the sofa: little tweeters, a volume knob with a green power light and a peeling MEGA BASS sticker. Every few seconds the right one buzzes and shakes. Tap it to play music: the cones pump."))).V).Put("MOV-062", NewObj(3).Put("spec", ((V)("drop15"))).Put("live", ((V)("Sheen sweeps"))).Put("note", ((V)("A 150-inch matte white screen hanging from a black motor housing with a blue status light, black masking borders, tab-tension side cables and a weighted bottom bar that keeps it perfectly flat."))).V).Put("MOV-082", NewObj(3).Put("spec", ((V)("holo15"))).Put("live", ((V)("Holo wings"))).Put("note", ((V)("A curved wall-to-wall MicroLED screen: the black glass centre shows the movie while the two wings curve toward you, flowing with holographic colour. Light sparkles rise off the top edge and a floating 16K emitter beams up from below, with a colour glow on the wall behind."))).V).V);
edit14_38 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis510, int _argc503, V rows_509, V _a506, V _a507, V _a508, V[] _rest504) => {
return Invoke(Call(edit14_38, V.Undef, rows_509), "map", Fn((V _arrowThis518, int _argc511, V r_517, V _a514, V _a515, V _a516, V[] _rest512) => {
return (Truthy(GetK(Get(RD_8, "SET15"), Get(r_517, "id"))) ? Object_assign(NewObj(0).V, r_517, GetK(Get(RD_8, "SET15"), Get(r_517, "id"))) : r_517);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "H15", NewObj(5).Put("DEF15", DEF15_34).Put("cone", cone_36).Put("curve", curve_37).Put("box3", box3_32).Put("cyl3", cyl3_33).V);
Set(RD_8, "PLUS15", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
