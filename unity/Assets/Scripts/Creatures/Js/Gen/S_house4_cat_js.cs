// house4-cat.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_house4_cat_js
    {

        public static void Run()
        {
Call(Named(boot_59 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V X_8 = default;
V K_9 = default;
V solid_10 = default;
V box_11 = default;
V cush_12 = default;
V cyl_13 = default;
V ball_14 = default;
V slab_15 = default;
V slabX_16 = default;
V arcW_17 = default;
V disc_18 = default;
V pillowY_19 = default;
V pillowZ_20 = default;
V quarters_21 = default;
V mix_22 = default;
V shade_23 = default;
V prism_24 = default;
V prismZ_25 = default;
V NE_26 = default;
V GOLD_27 = default;
V CH_28 = default;
V CR_29 = default;
V WH_30 = default;
V DK_31 = default;
V TIN_32 = default;
V OLD_33 = default;
V OLD2_34 = default;
V SCR_35 = default;
V BANDS_36 = default;
V BK_37 = default;
V legs_38 = default;
V spr_39 = default;
V drips_40 = default;
V patch_41 = default;
V jewel_42 = default;
V knob_43 = default;
V book_44 = default;
V flame_45 = default;
V sideL_46 = default;
V couch_47 = default;
V A_48 = default;
V prismX_49 = default;
V S__50 = default;
V Y__51 = default;
V LV_52 = default;
V HIDDEN_53 = default;
V WT_54 = default;
V SURF_55 = default;
V ITEMS_56 = default;
V add_57 = default;
if (_self1.IsNullish) _self1 = GlobalV;
X_8 = Get(G("window"), "House3D");
if (!(Truthy((X_8 is var _t58 && !Truthy(_t58) ? _t58 : Get(X_8, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_59.v, ((V)(20D)));
return default;
}
if (Truthy(Get(X_8, "ITEMS"))) {
return default;
}
K_9 = Get(X_8, "K");
{ V _t60 = K_9;
if (_t60.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t60));
{ V _t61 = Get(_t60, "solid");
solid_10 = _t61; }
{ V _t62 = Get(_t60, "box");
box_11 = _t62; }
{ V _t63 = Get(_t60, "cush");
cush_12 = _t63; }
{ V _t64 = Get(_t60, "cyl");
cyl_13 = _t64; }
{ V _t65 = Get(_t60, "ball");
ball_14 = _t65; }
{ V _t66 = Get(_t60, "slab");
slab_15 = _t66; }
{ V _t67 = Get(_t60, "slabX");
slabX_16 = _t67; }
{ V _t68 = Get(_t60, "arcW");
arcW_17 = _t68; }
{ V _t69 = Get(_t60, "disc");
disc_18 = _t69; }
{ V _t70 = Get(_t60, "pillowY");
pillowY_19 = _t70; }
{ V _t71 = Get(_t60, "pillowZ");
pillowZ_20 = _t71; }
{ V _t72 = Get(_t60, "quarters");
quarters_21 = _t72; }
{ V _t73 = Get(_t60, "mix");
mix_22 = _t73; }
{ V _t74 = Get(_t60, "shade");
shade_23 = _t74; }
{ V _t75 = Get(_t60, "prism");
prism_24 = _t75; }
{ V _t76 = Get(_t60, "prismZ");
prismZ_25 = _t76; } }
NE_26 = Get(K_9, "NEON");
GOLD_27 = ((V)("#e2b14a"));
CH_28 = ((V)("#d5dde2"));
CR_29 = ((V)("#fffaf1"));
WH_30 = ((V)("#ffffff"));
DK_31 = ((V)("#36373c"));
TIN_32 = ((V)("#a9b0b4"));
OLD_33 = ((V)("#9b7f62"));
OLD2_34 = ((V)("#a88660"));
SCR_35 = ((V)("#6cc6ee"));
BANDS_36 = Arr(NewObj(5).Put("k", ((V)("junk"))).Put("n", ((V)("Junk & Thrift"))).Put("lv", Arr(((V)(1D)), ((V)(5D)))).Put("ui", ((V)("#a88a6a"))).Put("cols", Arr(NewObj(3).Put("a", ((V)("#a99a84"))).Put("b", ((V)("#c9a85a"))).Put("w", ((V)("#9a7550"))).V, NewObj(3).Put("a", ((V)("#8fa8a0"))).Put("b", ((V)("#b8714a"))).Put("w", ((V)("#8a6a48"))).V, NewObj(3).Put("a", ((V)("#c4a27a"))).Put("b", ((V)("#8fa8a0"))).Put("w", ((V)("#a88660"))).V)).V, NewObj(5).Put("k", ((V)("cot"))).Put("n", ((V)("Cozy Cottage"))).Put("lv", Arr(((V)(6D)), ((V)(10D)))).Put("ui", ((V)("#7fb565"))).Put("cols", Arr(NewObj(3).Put("a", ((V)("#9fc684"))).Put("b", ((V)("#fffaf1"))).Put("w", ((V)("#d49a60"))).V, NewObj(3).Put("a", ((V)("#e3946a"))).Put("b", ((V)("#f2c255"))).Put("w", ((V)("#c98d58"))).V, NewObj(3).Put("a", ((V)("#84b6c9"))).Put("b", ((V)("#fffaf1"))).Put("w", ((V)("#e0b07a"))).V)).V, NewObj(5).Put("k", ((V)("retro"))).Put("n", ((V)("Retro Diner"))).Put("lv", Arr(((V)(11D)), ((V)(15D)))).Put("ui", ((V)("#e2554a"))).Put("cols", Arr(NewObj(3).Put("a", ((V)("#e2554a"))).Put("b", ((V)("#fffaf1"))).Put("w", ((V)("#d5dde2"))).V, NewObj(3).Put("a", ((V)("#5cc8c0"))).Put("b", ((V)("#ffd23f"))).Put("w", ((V)("#d5dde2"))).V, NewObj(3).Put("a", ((V)("#ffd23f"))).Put("b", ((V)("#e2554a"))).Put("w", ((V)("#d5dde2"))).V)).V, NewObj(5).Put("k", ((V)("mod"))).Put("n", ((V)("Modern"))).Put("lv", Arr(((V)(16D)), ((V)(20D)))).Put("ui", ((V)("#3a3c42"))).Put("cols", Arr(NewObj(3).Put("a", ((V)("#d9d5cd"))).Put("b", ((V)("#2c2d31"))).Put("w", ((V)("#c9a37a"))).V, NewObj(3).Put("a", ((V)("#3e4046"))).Put("b", ((V)("#c8c2b6"))).Put("w", ((V)("#d8bb92"))).V, NewObj(3).Put("a", ((V)("#8e9a84"))).Put("b", ((V)("#f1eee8"))).Put("w", ((V)("#2c2d31"))).V)).V, NewObj(5).Put("k", ((V)("candy"))).Put("n", ((V)("Dreamy Candy"))).Put("lv", Arr(((V)(21D)), ((V)(25D)))).Put("ui", ((V)("#a98be8"))).Put("cols", Arr(NewObj(3).Put("a", ((V)("#bff0dc"))).Put("b", ((V)("#cdb8f5"))).Put("w", ((V)("#fff1a0"))).V, NewObj(3).Put("a", ((V)("#cdb8f5"))).Put("b", ((V)("#fff1a0"))).Put("w", ((V)("#bfe4ff"))).V, NewObj(3).Put("a", ((V)("#bfe4ff"))).Put("b", ((V)("#ffcfa8"))).Put("w", ((V)("#bff0dc"))).V)).V, NewObj(5).Put("k", ((V)("royal"))).Put("n", ((V)("Royal Palace"))).Put("lv", Arr(((V)(26D)), ((V)(30D)))).Put("ui", ((V)("#7a1e2c"))).Put("cols", Arr(NewObj(3).Put("a", ((V)("#7f2030"))).Put("b", ((V)("#e2b14a"))).Put("w", ((V)("#f3ead6"))).V, NewObj(3).Put("a", ((V)("#1f5a44"))).Put("b", ((V)("#e2b14a"))).Put("w", ((V)("#5e321f"))).V, NewObj(3).Put("a", ((V)("#4b2763"))).Put("b", ((V)("#e2b14a"))).Put("w", ((V)("#f3ead6"))).V)).V);
BK_37 = NewObj(0).V;
Invoke(BANDS_36, "forEach", Fn((V _arrowThis84, int _argc77, V b_83, V _a80, V _a81, V _a82, V[] _rest78) => {
return SetK(BK_37, Get(b_83, "k"), b_83);
}, 1, "", true));
legs_38 = Fn((V _arrowThis98, int _argc85, V S_91, V P_92, V x_93, V z_94, V[] _rest86) => {
V o_99 = default;
V h_95 = default;
V r_97 = default;
h_95 = (_argc85 > 4 ? _rest86[0] : V.Undef);
{ V _t96 = (_argc85 > 5 ? _rest86[1] : V.Undef); if (_t96.IsUndef) _t96 = ((V)(4D));
r_97 = _t96; }
o_99 = Arr();
Invoke(Arr(Arr(((V)((-ToNum(x_93)))), ((V)((-ToNum(z_94))))), Arr(x_93, ((V)((-ToNum(z_94))))), Arr(((V)((-ToNum(x_93)))), z_94), Arr(x_93, z_94)), "forEach", Fn((V _arrowThis112, int _argc100, V _a102, V i_106, V _a104, V _a105, V[] _rest101) => {
V a_109 = default;
V b_111 = default;
{ V _t107 = ListOf(_a102);
{ V _t108 = GetIdx(_t107, 0D);
a_109 = _t108; }
{ V _t110 = GetIdx(_t107, 1D);
b_111 = _t110; }
}
if (SEqS(Get(S_91, "k"), "junk")) {
Invoke(o_99, "push", (SEqN(i_106, 3D) ? Call(cyl_13, V.Undef, a_109, ((V)(0D)), b_111, ((V)((ToNum(r_97) * 1.3))), h_95, TIN_32, NewObj(1).Put("n", ((V)(10D))).V) : Call(box_11, V.Undef, a_109, ((V)(0D)), b_111, ((V)((ToNum(r_97) * 2.4))), h_95, ((V)((ToNum(r_97) * 2.4))), OLD_33, NewObj(1).Put("r", ((V)(1D))).V)));
} else {
if (SEqS(Get(S_91, "k"), "cot")) {
Invoke(o_99, "push", Call(cyl_13, V.Undef, a_109, ((V)(0D)), b_111, r_97, h_95, Get(P_92, "wD"), NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)((ToNum(h_95) * 0.3))), ((V)(0D)), ((V)(1.15))), Arr(((V)((ToNum(h_95) * 0.55))), ((V)(0D)), ((V)(0.75))), Arr(h_95, ((V)(0D)), ((V)(1D))))).V));
} else {
if (SEqS(Get(S_91, "k"), "retro")) {
Invoke(o_99, "push", Call(cyl_13, V.Undef, a_109, ((V)(0D)), b_111, ((V)((ToNum(r_97) * 0.75))), h_95, CH_28, NewObj(2).Put("n", ((V)(8D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.5))), Arr(h_95, ((V)(0D)), ((V)(1D))))).V));
} else {
if (SEqS(Get(S_91, "k"), "mod")) {
Invoke(o_99, "push", Call(cyl_13, V.Undef, a_109, ((V)(0D)), b_111, ((V)((ToNum(r_97) * 0.55))), h_95, DK_31, NewObj(1).Put("n", ((V)(6D))).V));
} else {
if (SEqS(Get(S_91, "k"), "candy")) {
double R_113 = 0;
R_113 = Max((ToNum(r_97) * 1.3), 4D);
Invoke(o_99, "push", Call(ball_14, V.Undef, a_109, ((V)(0D)), b_111, ((V)(R_113)), GetK(NE_26, Add(i_106, ((V)(1D)))), NewObj(3).Put("sy", ((V)(Max(0.6, (ToNum(h_95) / (2D * R_113)))))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V));
} else {
double hh_114 = 0;
hh_114 = Max(1D, (ToNum(h_95) - (ToNum(r_97) * 1.2)));
Invoke(o_99, "push", Call(cyl_13, V.Undef, a_109, ((V)((ToNum(r_97) * 1.2))), b_111, ((V)((ToNum(r_97) * 0.8))), ((V)(hh_114)), GOLD_27, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(hh_114)), ((V)(0D)), ((V)(1.15))))).V), Call(ball_14, V.Undef, a_109, ((V)(0D)), b_111, ((V)((ToNum(r_97) * 1.1))), GOLD_27, NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V));
}
}
}
}
}
return default;
}, 2, "", true));
return o_99;
return default;
}, 6, "", true);
spr_39 = Fn((V _arrowThis128, int _argc115, V x_121, V y_122, V z_123, V w_124, V[] _rest116) => {
V o_129 = default;
V d_125 = default;
V n_127 = default;
d_125 = (_argc115 > 4 ? _rest116[0] : V.Undef);
{ V _t126 = (_argc115 > 5 ? _rest116[1] : V.Undef); if (_t126.IsUndef) _t126 = ((V)(10D));
n_127 = _t126; }
o_129 = Arr();
{
double i_130 = 0;
i_130 = 0D;
while (true) {
if (!(Lt(((V)(i_130)), n_127))) break;
double u_132 = 0;
double v_133 = 0;
u_132 = ((((i_130 * 37D) % 100D) / 100D) - 0.5);
v_133 = ((((i_130 * 61D) % 100D) / 100D) - 0.5);
Invoke(o_129, "push", Call(ball_14, V.Undef, Add(x_121, ((V)((u_132 * ToNum(w_124))))), y_122, Add(z_123, ((V)((v_133 * ToNum(d_125))))), ((V)(2D)), GetIdx(NE_26, (i_130 % 6D)), NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("sy", ((V)(0.6))).V));
i_130++;
}
}
return o_129;
return default;
}, 6, "", true);
drips_40 = Fn((V _arrowThis147, int _argc134, V x_140, V y_141, V z_142, V w_143, V[] _rest135) => {
V o_148 = default;
V col_144 = default;
V n_146 = default;
col_144 = (_argc134 > 4 ? _rest135[0] : V.Undef);
{ V _t145 = (_argc134 > 5 ? _rest135[1] : V.Undef); if (_t145.IsUndef) _t145 = ((V)(5D));
n_146 = _t145; }
o_148 = Arr();
{
double i_149 = 0;
i_149 = 0D;
while (true) {
if (!(Lt(((V)(i_149)), n_146))) break;
Invoke(o_148, "push", Call(ball_14, V.Undef, ((V)(((ToNum(x_140) - (ToNum(w_143) / 2D)) + ((ToNum(w_143) * (i_149 + 0.5)) / ToNum(n_146))))), ((V)(((ToNum(y_141) - 7D) - ((i_149 % 2D) * 4D)))), z_142, ((V)(4D)), col_144, NewObj(3).Put("sy", ((V)(1.5))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V));
i_149++;
}
}
return o_148;
return default;
}, 6, "", true);
patch_41 = Fn((V _arrowThis163, int _argc151, V x_157, V y_158, V z_159, V w_160, V[] _rest152) => {
V h_161 = default;
V col_162 = default;
h_161 = (_argc151 > 4 ? _rest152[0] : V.Undef);
col_162 = (_argc151 > 5 ? _rest152[1] : V.Undef);
return Call(box_11, V.Undef, x_157, y_158, z_159, w_160, h_161, ((V)(1.2)), col_162, NewObj(1).Put("r", ((V)(2D))).V);
}, 6, "", true);
jewel_42 = Fn((V _arrowThis175, int _argc164, V x_170, V y_171, V z_172, V _a169, V[] _rest165) => {
V r_174 = default;
{ V _t173 = _a169; if (_t173.IsUndef) _t173 = ((V)(5D));
r_174 = _t173; }
return Call(ball_14, V.Undef, x_170, y_171, z_172, r_174, GOLD_27);
}, 4, "", true);
knob_43 = Fn((V _arrowThis188, int _argc176, V S_182, V x_183, V y_184, V z_185, V[] _rest177) => {
V r_187 = default;
{ V _t186 = (_argc176 > 4 ? _rest177[0] : V.Undef); if (_t186.IsUndef) _t186 = ((V)(2.4));
r_187 = _t186; }
return Call(ball_14, V.Undef, x_183, y_184, z_185, r_187, (SEqS(Get(S_182, "k"), "candy") ? GetK(NE_26, Add((GtN(x_183, 0D) ? V.True : V.False), ((V)(3D)))) : ((SEqS(Get(S_182, "k"), "retro") || SEqS(Get(S_182, "k"), "mod")) ? (SEqS(Get(S_182, "k"), "mod") ? DK_31 : CH_28) : (SEqS(Get(S_182, "k"), "junk") ? ((V)("#8a8f94")) : GOLD_27))), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V);
}, 5, "", true);
book_44 = Fn((V _arrowThis199, int _argc189, V x_195, V y_196, V z_197, V C_198, V[] _rest190) => {
return Arr(Call(box_11, V.Undef, x_195, y_196, z_197, ((V)(26D)), ((V)(4D)), ((V)(18D)), GetIdx(C_198, 0D), NewObj(1).Put("r", ((V)(1D))).V), Call(box_11, V.Undef, Add(x_195, ((V)(1D))), Add(y_196, ((V)(4D))), z_197, ((V)(22D)), ((V)(4D)), ((V)(16D)), GetIdx(C_198, 1D), NewObj(1).Put("r", ((V)(1D))).V));
}, 4, "", true);
flame_45 = Fn((V _arrowThis211, int _argc200, V x_206, V y_207, V z_208, V _a205, V[] _rest201) => {
V s_210 = default;
{ V _t209 = _a205; if (_t209.IsUndef) _t209 = ((V)(1D));
s_210 = _t209; }
return Arr(Call(ball_14, V.Undef, x_206, y_207, z_208, ((V)((4D * ToNum(s_210)))), ((V)("#ffb347")), NewObj(4).Put("sy", ((V)(1.6))).Put("emit", ((V)(1D))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V), Call(ball_14, V.Undef, x_206, Add(y_207, ((V)((2D * ToNum(s_210))))), Add(z_208, ((V)(1D))), ((V)((2.2 * ToNum(s_210)))), ((V)("#fff1a8")), NewObj(4).Put("sy", ((V)(1.5))).Put("emit", ((V)(1D))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 4, "", true);
sideL_46 = Fn((V _arrowThis223, int _argc212, V x_218, V y_219, V h_220, V d_221, V[] _rest213) => {
V col_222 = default;
col_222 = (_argc212 > 4 ? _rest213[0] : V.Undef);
return Arr(Call(box_11, V.Undef, x_218, y_219, ((V)(0D)), ((V)(4D)), h_220, d_221, col_222, NewObj(1).Put("r", ((V)(1D))).V));
}, 5, "", true);
couch_47 = Fn((V _arrowThis232, int _argc224, V S_230, V n_231, V _a228, V _a229, V[] _rest225) => {
double W_233 = 0;
double ax_234 = 0;
V cx_235 = default;
V k_236 = default;
V fix_237 = default;
W_233 = (SEqN(n_231, 2D) ? 196D : 122D);
ax_234 = ((W_233 / 2D) - 14D);
cx_235 = (SEqN(n_231, 2D) ? Arr(((V)((-36D))), ((V)(36D))) : Arr(((V)(0D))));
k_236 = Get(S_230, "k");
fix_237 = Get(S_230, "fix");
return NewObj(5).Put("w", ((V)(W_233))).Put("d", ((V)(90D))).Put("act", ((V)("sit"))).Put("seats", Invoke(cx_235, "map", Fn((V _arrowThis245, int _argc238, V x_244, V _a241, V _a242, V _a243, V[] _rest239) => {
return NewObj(3).Put("x", x_244).Put("z", ((V)(12D))).Put("h", ((V)((SEqS(k_236, "junk") ? 34D : 40D)))).V;
}, 1, "", true))).Put("build", Fn((V _arrowThis253, int _argc246, V P_252, V _a249, V _a250, V _a251, V[] _rest247) => {
V o_254 = default;
double by_255 = 0;
double bH_256 = 0;
double IH_257 = 0;
V on_258 = default;
V F_259 = default;
double bh_260 = 0;
double br_261 = 0;
double st_262 = 0;
V BK_263 = default;
V SC_264 = default;
V BC_265 = default;
V AR_266 = default;
o_254 = Arr();
by_255 = (SEqS(k_236, "junk") ? 0D : 7D);
bH_256 = (SEqS(k_236, "junk") ? 14D : 18D);
IH_257 = (ax_234 - (SEqS(k_236, "candy") ? 14D : 12D));
on_258 = Fn((V _arrowThis276, int _argc267, V p_273, V L_274, V fn_275, V _a272, V[] _rest268) => {
return Invoke(L_274, "map", Fn((V _arrowThis284, int _argc277, V q_283, V _a280, V _a281, V _a282, V[] _rest278) => {
Set(q_283, "par", p_273);
if (Truthy(fn_275)) {
Set(q_283, "fn", fn_275);
}
Invoke(o_254, "push", q_283);
return q_283;
return default;
}, 1, "", true));
}, 3, "", true);
F_259 = Arr(((V)(0D)), ((V)(0D)), ((V)(1D)));
if (!SEqS(k_236, "junk")) {
InvokeSpread(o_254, "push", new ArrBuilder().Spread(Call(legs_38, V.Undef, S_230, P_252, ((V)(((W_233 / 2D) - 12D))), ((V)(34D)), ((V)(7D)))).V);
}
bh_260 = (SEqS(k_236, "mod") ? 44D : (SEqS(k_236, "royal") ? 72D : 58D));
br_261 = (SEqS(k_236, "mod") ? 8D : (SEqS(k_236, "retro") ? 12D : (SEqS(k_236, "candy") ? 30D : 24D)));
st_262 = ((by_255 + bH_256) + 16D);
Invoke(o_254, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(by_255)), ((V)(7D)), ((V)((2D * IH_257))), ((V)(bH_256)), ((V)(70D)), Get(P_252, "aD"), NewObj(2).Put("r", ((V)((SEqS(k_236, "mod") ? 6D : 12D)))).Put("bev", ((V)(4D))).V));
BK_263 = Call(slab_15, V.Undef, ((V)(0D)), ((V)(by_255)), ((V)((-35D))), ((V)((2D * IH_257))), ((V)((bh_260 + 7D))), ((V)(14D)), Get(P_252, "a"), NewObj(2).Put("r", ((V)(br_261))).Put("soft", ((V)(1D))).V);
Invoke(o_254, "push", BK_263);
if (SEqS(k_236, "royal")) {
V G_285 = default;
G_285 = Call(slab_15, V.Undef, ((V)(0D)), ((V)((by_255 + 5D))), ((V)((-43D))), ((V)((W_233 - 4D))), ((V)((bh_260 + 8D))), ((V)(2D)), GOLD_27, NewObj(1).Put("r", ((V)((br_261 + 4D)))).V);
Invoke(o_254, "push", G_285);
Call(on_258, V.Undef, G_285, Arr(Call(jewel_42, V.Undef, ((V)(0D)), ((V)(((by_255 + bh_260) + 10D))), ((V)((-40D))), ((V)(6D)))));
}
if (SEqS(k_236, "retro")) {
Call(on_258, V.Undef, BK_263, Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(((by_255 + 7D) + bh_260))), ((V)((-35D))), ((V)(((2D * IH_257) - 24D))), ((V)(1.4)), ((V)(12D)), CH_28, NewObj(1).Put("r", ((V)(1D))).V)));
}
SC_264 = Arr();
BC_265 = Arr();
Invoke(cx_235, "forEach", Fn((V _arrowThis294, int _argc286, V x_292, V i_293, V _a290, V _a291, V[] _rest287) => {
double sag_295 = 0;
double w_296 = 0;
sag_295 = (((SEqS(k_236, "junk") && !(Truthy(fix_237))) && SEqN(i_293, (ToNum(Get(cx_235, "length")) - 1D))) ? (-5D) : 0D);
w_296 = ((SEqN(n_231, 2D) ? (2D * Min((IH_257 - System.Math.Abs(ToNum(x_292))), System.Math.Abs(ToNum(x_292)))) : (2D * IH_257)) - 2D);
Invoke(o_254, "push", SetK(SC_264, i_293, Call(pillowY_19, V.Undef, x_292, ((V)((by_255 + bH_256))), ((V)(16D)), ((V)(w_296)), ((V)(((SEqS(k_236, "mod") ? 13D : 16D) + sag_295))), ((V)(52D)), (Truthy((((SEqS(k_236, "junk") ? V.True : V.False) is var _t297 && !Truthy(_t297) ? _t297 : i_293) is var _t298 && !Truthy(_t298) ? _t298 : (!(Truthy(fix_237)) ? V.True : V.False))) ? Get(P_252, "b") : Get(P_252, "aL")))));
Invoke(o_254, "push", SetK(BC_265, i_293, (SEqS(k_236, "mod") ? Call(box_11, V.Undef, x_292, ((V)((by_255 + bH_256))), ((V)((-21D))), ((V)((w_296 - 4D))), ((V)(38D)), ((V)(14D)), Get(P_252, "aL"), NewObj(2).Put("r", ((V)(6D))).Put("bev", ((V)(3D))).V) : Call(pillowZ_20, V.Undef, x_292, ((V)((by_255 + bH_256))), ((V)((-19D))), ((V)(w_296)), ((V)((40D + sag_295))), ((V)(18D)), Get(P_252, "aL")))));
return default;
}, 2, "", true));
AR_266 = NewObj(0).V;
if (SEqS(k_236, "candy")) {
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis306, int _argc299, V s_305, V _a302, V _a303, V _a304, V[] _rest300) => {
return Invoke(o_254, "push", SetK(AR_266, s_305, Call(ball_14, V.Undef, ((V)((ToNum(s_305) * (ax_234 + 2D)))), ((V)((by_255 - 2D))), ((V)(2D)), ((V)(22D)), Get(P_252, "b"), NewObj(5).Put("sx", ((V)(0.72))).Put("sy", ((V)(1.1))).Put("sz", ((V)(2D))).Put("k", ((V)(6D))).Put("n", ((V)(16D))).V)));
}, 1, "", true));
} else {
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis314, int _argc307, V s_313, V _a310, V _a311, V _a312, V[] _rest308) => {
return Invoke(o_254, "push", SetK(AR_266, s_313, Call(slab_15, V.Undef, ((V)((ToNum(s_313) * ax_234))), ((V)(by_255)), ((V)(2D)), ((V)(24D)), ((V)((SEqS(k_236, "mod") ? 32D : 44D))), ((V)(86D)), Get(P_252, "a"), NewObj(2).Put("r", ((V)((SEqS(k_236, "mod") ? 4D : 12D)))).Put("soft", ((V)(1D))).V)));
}, 1, "", true));
}
if ((SEqS(k_236, "junk") && !(Truthy(fix_237)))) {
Call(on_258, V.Undef, GetIdx(AR_266, (-1D)), Arr(Call(patch_41, V.Undef, ((V)(((-ax_234) + 3D))), ((V)((by_255 + 18D))), ((V)(45.6)), ((V)(12D)), ((V)(12D)), Get(P_252, "b"))), F_259);
Call(on_258, V.Undef, GetIdx(SC_264, 0D), Arr(Call(patch_41, V.Undef, ((V)((ToNum(GetIdx(cx_235, 0D)) - 12D))), ((V)((by_255 + 19D))), ((V)(42.6)), ((V)(18D)), ((V)(8D)), ((V)("#c9a85a")))), F_259);
Call(on_258, V.Undef, GetIdx(AR_266, 1D), Arr(Call(patch_41, V.Undef, ((V)((ax_234 - 4D))), ((V)((by_255 + 28D))), ((V)(45.6)), ((V)(10D)), ((V)(8D)), ((V)("#8fa8a0")))), F_259);
}
if (Truthy(fix_237)) {
double j_315 = 0;
V x_316 = default;
j_315 = (SEqN(n_231, 2D) ? 1D : 0D);
x_316 = GetIdx(cx_235, j_315);
Call(on_258, V.Undef, GetIdx(SC_264, j_315), Arr(Call(pillowY_19, V.Undef, x_316, ((V)((st_262 - 1D))), ((V)(4D)), ((V)(56D)), ((V)(8D)), ((V)(30D)), Get(P_252, "b"))));
Call(on_258, V.Undef, GetIdx(SC_264, j_315), Arr(Call(box_11, V.Undef, x_316, ((V)(((by_255 + bH_256) + 2D))), ((V)(42.6)), ((V)(56D)), ((V)(14D)), ((V)(1.2)), Get(P_252, "b"), NewObj(1).Put("r", ((V)(3D))).V)), F_259);
}
if (SEqS(k_236, "cot")) {
double px_317 = 0;
V TP_318 = default;
px_317 = (ToNum(GetIdx(cx_235, 0D)) - (SEqN(n_231, 2D) ? 12D : 0D));
{ V _t319 = Call(on_258, V.Undef, GetIdx(SC_264, 0D), Arr(Call(pillowZ_20, V.Undef, ((V)(px_317)), ((V)(st_262)), ((V)((-5D))), ((V)(30D)), ((V)(28D)), ((V)(10D)), Get(P_252, "b"))));
{ V _t320 = ListOf(_t319);
{ V _t321 = GetIdx(_t320, 0D);
TP_318 = _t321; }
} }
Call(on_258, V.Undef, TP_318, Arr(Call(ball_14, V.Undef, ((V)(px_317)), ((V)((st_262 + 11D))), ((V)((-0.2))), ((V)(3D)), Get(P_252, "a"), NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("sz", ((V)(0.5))).V)), F_259);
}
if (SEqS(k_236, "candy")) {
Call(on_258, V.Undef, BK_263, Call(spr_39, V.Undef, ((V)(0D)), ((V)(((by_255 + 5D) + bh_260))), ((V)((-35D))), ((V)(((2D * IH_257) - 30D))), ((V)(8D)), ((V)(9D))));
}
if (SEqS(k_236, "royal")) {
Invoke(cx_235, "forEach", Fn((V _arrowThis330, int _argc322, V x_328, V i_329, V _a326, V _a327, V[] _rest323) => {
return Call(on_258, V.Undef, GetK(BC_265, i_329), Invoke(Arr(((V)((-22D))), ((V)(0D)), ((V)(22D))), "map", Fn((V _arrowThis338, int _argc331, V t_337, V _a334, V _a335, V _a336, V[] _rest332) => {
return Call(ball_14, V.Undef, Add(x_328, t_337), ((V)((by_255 + 40D))), ((V)((-9.6))), ((V)(2.4)), GOLD_27, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("sz", ((V)(0.5))).V);
}, 1, "", true)), F_259);
}, 2, "", true));
}
if (SEqS(k_236, "mod")) {
Call(on_258, V.Undef, GetIdx(SC_264, (ToNum(Get(cx_235, "length")) - 1D)), Arr(Call(pillowZ_20, V.Undef, Add(GetIdx(cx_235, (ToNum(Get(cx_235, "length")) - 1D)), ((V)(14D))), ((V)((st_262 - 3D))), ((V)((-5D))), ((V)(28D)), ((V)(26D)), ((V)(9D)), Get(P_252, "b"))));
}
return o_254;
return default;
}, 1, "build", true)).V;
return default;
}, 2, "", true);
A_48 = NewObj(51).Put("sofa", Fn((V _arrowThis346, int _argc339, V S_345, V _a342, V _a343, V _a344, V[] _rest340) => {
return Call(couch_47, V.Undef, S_345, ((V)(2D)));
}, 1, "sofa", true)).Put("armchair", Fn((V _arrowThis354, int _argc347, V S_353, V _a350, V _a351, V _a352, V[] _rest348) => {
return Call(couch_47, V.Undef, S_353, ((V)(1D)));
}, 1, "armchair", true)).Put("coffee", Fn((V _arrowThis362, int _argc355, V S_361, V _a358, V _a359, V _a360, V[] _rest356) => {
return NewObj(4).Put("w", ((V)(122D))).Put("d", ((V)(66D))).Put("round", ((V)((Truthy(((SEqS(Get(S_361, "k"), "candy") ? V.True : V.False) is var _t363 && Truthy(_t363) ? _t363 : Get(S_361, "spool"))) ? 1D : 0D)))).Put("build", Fn((V _arrowThis371, int _argc364, V P_370, V _a367, V _a368, V _a369, V[] _rest365) => {
V k_372 = default;
V o_373 = default;
double h_374 = 0;
k_372 = Get(S_361, "k");
o_373 = Arr();
if (Truthy(Get(S_361, "spool"))) {
return new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(44D)), ((V)(6D)), OLD2_34, NewObj(2).Put("rz", ((V)(30D))).Put("n", ((V)(20D))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(18D)), ((V)(22D)), OLD_33, NewObj(1).Put("n", ((V)(14D))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(28D)), ((V)(0D)), ((V)(48D)), ((V)(7D)), OLD2_34, NewObj(2).Put("rz", ((V)(33D))).Put("n", ((V)(20D))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(35D)), ((V)(0D)), ((V)(40D)), ((V)(0.6)), ((V)("#c4a882")), NewObj(2).Put("rz", ((V)(27D))).Put("n", ((V)(18D))).V)).Add(Call(cyl_13, V.Undef, ((V)((-14D))), ((V)(35.6)), ((V)(4D)), ((V)(7D)), ((V)(10D)), CR_29, NewObj(1).Put("n", ((V)(10D))).V)).Spread(Call(book_44, V.Undef, ((V)(16D)), ((V)(35.6)), ((V)((-4D))), Arr(((V)("#8fa8a0")), ((V)("#c9a85a"))))).V;
}
if (SEqS(k_372, "junk")) {
Invoke(Arr(((V)((-30D))), ((V)(30D))), "forEach", Fn((V _arrowThis383, int _argc375, V x_381, V i_382, V _a379, V _a380, V[] _rest376) => {
V c_384 = default;
c_384 = (Truthy(i_382) ? OLD2_34 : OLD_33);
Invoke(o_373, "push", Call(box_11, V.Undef, x_381, ((V)(0D)), ((V)((-23D))), ((V)(56D)), ((V)(30D)), ((V)(4D)), Call(shade_23, V.Undef, c_384, ((V)(0.85)))), Call(box_11, V.Undef, ((V)((ToNum(x_381) - 26D))), ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(30D)), ((V)(50D)), c_384), Call(box_11, V.Undef, Add(x_381, ((V)(26D))), ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(30D)), ((V)(50D)), c_384), Call(box_11, V.Undef, x_381, ((V)(6D)), ((V)(23D)), ((V)(56D)), ((V)(7D)), ((V)(4D)), c_384), Call(box_11, V.Undef, x_381, ((V)(18D)), ((V)(23D)), ((V)(56D)), ((V)(7D)), ((V)(4D)), c_384), Call(box_11, V.Undef, x_381, ((V)(0D)), ((V)(0D)), ((V)(52D)), ((V)(3D)), ((V)(46D)), Call(shade_23, V.Undef, c_384, ((V)(0.7)))));
return default;
}, 2, "", true));
Invoke(o_373, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D)), ((V)(126D)), ((V)(4D)), ((V)(56D)), ((V)("#b89a74")), NewObj(1).Put("r", ((V)(2D))).V), Call(cyl_13, V.Undef, ((V)(26D)), ((V)(34D)), ((V)(4D)), ((V)(5D)), ((V)(9D)), TIN_32, NewObj(1).Put("n", ((V)(10D))).V), Call(box_11, V.Undef, ((V)((-24D))), ((V)(34D)), ((V)((-2D))), ((V)(26D)), ((V)(2D)), ((V)(18D)), ((V)("#e8dcc0")), NewObj(1).Put("r", ((V)(1D))).V));
return o_373;
}
if (SEqS(k_372, "retro")) {
return new ArrBuilder().Spread(Call(legs_38, V.Undef, S_361, P_370, ((V)(40D)), ((V)(16D)), ((V)(24D)), ((V)(4D)))).Add(Call(cyl_13, V.Undef, ((V)((-24D))), ((V)(24D)), ((V)(0D)), ((V)(40D)), ((V)(7D)), Get(P_370, "a"), NewObj(2).Put("rz", ((V)(28D))).Put("n", ((V)(18D))).V)).Add(Call(cyl_13, V.Undef, ((V)(26D)), ((V)(24D)), ((V)(3D)), ((V)(34D)), ((V)(7D)), Get(P_370, "a"), NewObj(2).Put("rz", ((V)(24D))).Put("n", ((V)(18D))).V)).Add(Call(cyl_13, V.Undef, ((V)((-24D))), ((V)(31D)), ((V)(0D)), ((V)(37D)), ((V)(0.6)), Get(P_370, "aL"), NewObj(2).Put("rz", ((V)(25D))).Put("n", ((V)(18D))).V)).Add(Call(ball_14, V.Undef, ((V)(28D)), ((V)(31D)), ((V)(2D)), ((V)(6D)), Get(P_370, "b"))).Add(Call(cyl_13, V.Undef, ((V)((-30D))), ((V)(31D)), ((V)(4D)), ((V)(6D)), ((V)(8D)), CH_28, NewObj(1).Put("n", ((V)(10D))).V)).V;
}
if (SEqS(k_372, "candy")) {
return new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(52D)), ((V)(12D)), Get(P_370, "a"), NewObj(3).Put("rz", ((V)(32D))).Put("n", ((V)(20D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(4D))), Arr(((V)(5D)), ((V)(0D))), Arr(((V)(12D)), ((V)(4D))))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(0D)), ((V)(47D)), ((V)(8D)), CR_29, NewObj(2).Put("rz", ((V)(28D))).Put("n", ((V)(20D))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(20D)), ((V)(0D)), ((V)(52D)), ((V)(12D)), Get(P_370, "a"), NewObj(3).Put("rz", ((V)(32D))).Put("n", ((V)(20D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(4D))), Arr(((V)(7D)), ((V)(0D))), Arr(((V)(12D)), ((V)(6D))))).V)).Spread(Call(spr_39, V.Undef, ((V)(0D)), ((V)(31D)), ((V)(0D)), ((V)(64D)), ((V)(32D)), ((V)(11D)))).V;
}
h_374 = (SEqS(k_372, "mod") ? 24D : 28D);
InvokeSpread(o_373, "push", new ArrBuilder().Spread(Call(legs_38, V.Undef, S_361, P_370, ((V)(50D)), ((V)(22D)), ((V)(h_374)), ((V)(3.5)))).V);
Invoke(o_373, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(h_374)), ((V)(0D)), ((V)(122D)), ((V)((SEqS(k_372, "mod") ? 6D : 8D))), ((V)(66D)), (SEqS(k_372, "royal") ? ((V)("#f4f1ea")) : Get(P_370, "w")), NewObj(2).Put("r", ((V)((SEqS(k_372, "mod") ? 4D : 12D)))).Put("bev", ((V)(2D))).V));
if (SEqS(k_372, "royal")) {
Invoke(o_373, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)((h_374 - 3D))), ((V)(0D)), ((V)(125D)), ((V)(3D)), ((V)(69D)), GOLD_27, NewObj(1).Put("r", ((V)(12D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)((h_374 + 8D))), ((V)(0D)), ((V)(16D)), ((V)(7D)), GOLD_27, NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(8D))), Arr(((V)(7D)), ((V)(0D))))).V), Call(ball_14, V.Undef, ((V)((-5D))), ((V)((h_374 + 13D))), ((V)(0D)), ((V)(6D)), ((V)("#e85a3a"))), Call(ball_14, V.Undef, ((V)(6D)), ((V)((h_374 + 13D))), ((V)(3D)), ((V)(6D)), ((V)("#9fc684"))), Call(ball_14, V.Undef, ((V)(0D)), ((V)((h_374 + 16D))), ((V)((-4D))), ((V)(5D)), ((V)("#8f7bff"))));
} else {
if (SEqS(k_372, "cot")) {
Invoke(o_373, "push", Call(cyl_13, V.Undef, ((V)((-24D))), ((V)((h_374 + 8D))), ((V)((-2D))), ((V)(18D)), ((V)(0.6)), CR_29, NewObj(1).Put("n", ((V)(16D))).V), Call(cyl_13, V.Undef, ((V)((-24D))), ((V)((h_374 + 8.6))), ((V)((-2D))), ((V)(9D)), ((V)(10D)), Get(P_370, "b"), NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(3D))), Arr(((V)(5D)), ((V)(0D))), Arr(((V)(10D)), ((V)(2D))))).V), Call(cyl_13, V.Undef, ((V)((-14D))), ((V)((h_374 + 13D))), ((V)((-2D))), ((V)(2D)), ((V)(2D)), Get(P_370, "b"), NewObj(1).Put("n", ((V)(6D))).V), Call(box_11, V.Undef, ((V)(26D)), ((V)((h_374 + 8D))), ((V)(4D)), ((V)(28D)), ((V)(4D)), ((V)(20D)), Get(P_370, "a"), NewObj(1).Put("r", ((V)(2D))).V));
} else {
InvokeSpread(o_373, "push", new ArrBuilder().Spread(Call(book_44, V.Undef, ((V)((-26D))), ((V)((h_374 + 6D))), ((V)((-4D))), Arr(Get(P_370, "b"), CR_29))).Add(Call(cyl_13, V.Undef, ((V)(28D)), ((V)((h_374 + 6D))), ((V)(6D)), ((V)(5D)), ((V)(12D)), ((V)("#c9c9c4")), NewObj(1).Put("n", ((V)(10D))).V)).Add(Call(ball_14, V.Undef, ((V)(28D)), ((V)((h_374 + 18D))), ((V)(6D)), ((V)(6D)), ((V)("#8fc176")))).V);
}
}
return o_373;
return default;
}, 1, "build", true)).V;
}, 1, "coffee", true)).Put("tv", Fn((V _arrowThis392, int _argc385, V S_391, V _a388, V _a389, V _a390, V[] _rest386) => {
return NewObj(4).Put("w", ((V)(110D))).Put("d", ((V)(44D))).Spread((Truthy(Get(S_391, "radio")) ? NewObj(0).V : NewObj(3).Put("act", ((V)("watch"))).Put("anim", ((V)("tv"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(112D))).V).V)).Put("build", Fn((V _arrowThis400, int _argc393, V P_399, V _a396, V _a397, V _a398, V[] _rest394) => {
V k_401 = default;
V o_402 = default;
V lg_403 = default;
double cy_404 = 0;
double ch_405 = 0;
double sy_406 = 0;
k_401 = Get(S_391, "k");
o_402 = Arr();
if (Truthy(Get(S_391, "radio"))) {
return Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(74D)), ((V)(92D)), ((V)(36D)), OLD2_34, NewObj(2).Put("r", ((V)(4D))).Put("bev", ((V)(2D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(70D)), ((V)(0D)), ((V)(74D)), ((V)(34D)), ((V)(36D)), OLD2_34, NewObj(1).Put("r", ((V)(30D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(50D)), ((V)(18.4)), ((V)(56D)), ((V)(34D)), ((V)(1D)), ((V)("#c9b48e")), NewObj(1).Put("r", ((V)(6D))).V), Call(disc_18, V.Undef, ((V)((-14D))), ((V)(32D)), ((V)(18D)), ((V)(7D)), ((V)(1.4)), ((V)("#5a4a40"))), Call(disc_18, V.Undef, ((V)(14D)), ((V)(32D)), ((V)(18D)), ((V)(7D)), ((V)(1.4)), ((V)("#5a4a40"))), Call(box_11, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(18.4)), ((V)(56D)), ((V)(16D)), ((V)(1D)), OLD_33, NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(70D)), ((V)(18.4)), ((V)(40D)), ((V)(6D)), ((V)(1D)), ((V)("#e8dcc0")), NewObj(2).Put("r", ((V)(2D))).Put("emit", ((V)(1D))).V));
}
if (SEqS(k_401, "junk")) {
return Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(70D)), ((V)(30D)), ((V)(40D)), OLD_33, NewObj(1).Put("r", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(20.3)), ((V)(64D)), ((V)(1.6)), ((V)(0.8)), ((V)("#7d6248"))), Call(box_11, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D)), ((V)(62D)), ((V)(48D)), ((V)(40D)), ((V)("#8a7d6c")), NewObj(2).Put("r", ((V)(10D))).Put("bev", ((V)(3D))).V), Call(box_11, V.Undef, ((V)((-7D))), ((V)(36D)), ((V)(20.2)), ((V)(42D)), ((V)(34D)), ((V)(1D)), ((V)("#9fc6c0")), NewObj(3).Put("r", ((V)(9D))).Put("emit", ((V)(1D))).Put("scr", ((V)(1D))).V), Call(ball_14, V.Undef, ((V)(22D)), ((V)(58D)), ((V)(20D)), ((V)(3D)), ((V)("#5a4a40")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(ball_14, V.Undef, ((V)(22D)), ((V)(46D)), ((V)(20D)), ((V)(3D)), ((V)("#5a4a40")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(cyl_13, V.Undef, ((V)((-10D))), ((V)(78D)), ((V)((-4D))), ((V)(1.2)), ((V)(24D)), CH_28, NewObj(1).Put("n", ((V)(6D))).V), Call(cyl_13, V.Undef, ((V)(12D)), ((V)(78D)), ((V)((-4D))), ((V)(1.2)), ((V)(20D)), CH_28, NewObj(1).Put("n", ((V)(6D))).V), Call(ball_14, V.Undef, ((V)((-10D))), ((V)(101D)), ((V)((-4D))), ((V)(2D)), CH_28, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(patch_41, V.Undef, ((V)((-28D))), ((V)(36D)), ((V)(20.6)), ((V)(8D)), ((V)(14D)), ((V)("#c9a85a"))));
}
lg_403 = ((SEqS(k_401, "retro") || SEqS(k_401, "mod")) ? V.True : V.False);
cy_404 = (Truthy(lg_403) ? 10D : 0D);
ch_405 = (SEqS(k_401, "mod") ? 16D : 30D);
if (Truthy(lg_403)) {
InvokeSpread(o_402, "push", new ArrBuilder().Spread(Call(legs_38, V.Undef, S_391, P_399, ((V)(46D)), ((V)(14D)), ((V)(10D)), ((V)(3D)))).V);
}
Invoke(o_402, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(cy_404)), ((V)(0D)), ((V)(110D)), ((V)(ch_405)), ((V)(40D)), (SEqS(k_401, "royal") ? ((V)("#f4f1ea")) : (SEqS(k_401, "candy") ? Get(P_399, "b") : Get(P_399, "w"))), NewObj(2).Put("r", ((V)((SEqS(k_401, "candy") ? 14D : 5D)))).Put("bev", ((V)(2D))).V));
if (!SEqS(k_401, "mod")) {
Invoke(o_402, "push", Call(box_11, V.Undef, ((V)((-27D))), ((V)((cy_404 + 4D))), ((V)(20.4)), ((V)(50D)), ((V)((ch_405 - 8D))), ((V)(1D)), (SEqS(k_401, "royal") ? GOLD_27 : Get(P_399, "wL")), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(27D)), ((V)((cy_404 + 4D))), ((V)(20.4)), ((V)(50D)), ((V)((ch_405 - 8D))), ((V)(1D)), (SEqS(k_401, "royal") ? GOLD_27 : Get(P_399, "wL")), NewObj(1).Put("r", ((V)(3D))).V));
} else {
Invoke(o_402, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)((cy_404 + 4D))), ((V)(20.4)), ((V)(100D)), ((V)(3D)), ((V)(0.6)), Get(P_399, "b"), NewObj(1).Put("r", ((V)(1D))).V));
}
sy_406 = (cy_404 + ch_405);
if (SEqS(k_401, "retro")) {
InvokeSpread(o_402, "push", new ArrBuilder().Spread(Invoke(Call(legs_38, V.Undef, S_391, P_399, ((V)(18D)), ((V)(4D)), ((V)(6D)), ((V)(2D))), "map", Fn((V _arrowThis414, int _argc407, V s_413, V _a410, V _a411, V _a412, V[] _rest408) => {
return s_413;
}, 1, "", true))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)((sy_406 + 6D))), ((V)((-4D))), ((V)(80D)), ((V)(56D)), ((V)(24D)), Get(P_399, "a"), NewObj(2).Put("r", ((V)(20D))).Put("bev", ((V)(5D))).V)).Add(Call(box_11, V.Undef, ((V)((-8D))), ((V)((sy_406 + 14D))), ((V)(8.4)), ((V)(52D)), ((V)(40D)), ((V)(1D)), SCR_35, NewObj(3).Put("r", ((V)(12D))).Put("emit", ((V)(1D))).Put("scr", ((V)(1D))).V)).Add(Call(ball_14, V.Undef, ((V)(30D)), ((V)((sy_406 + 42D))), ((V)(8D)), ((V)(3.5)), CH_28, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)).Add(Call(ball_14, V.Undef, ((V)(30D)), ((V)((sy_406 + 28D))), ((V)(8D)), ((V)(3.5)), CH_28, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)).Add(Call(cyl_13, V.Undef, ((V)((-14D))), ((V)((sy_406 + 62D))), ((V)((-4D))), ((V)(1D)), ((V)(18D)), CH_28, NewObj(1).Put("n", ((V)(6D))).V)).Add(Call(cyl_13, V.Undef, ((V)(14D)), ((V)((sy_406 + 62D))), ((V)((-4D))), ((V)(1D)), ((V)(18D)), CH_28, NewObj(1).Put("n", ((V)(6D))).V)).V);
} else {
if (SEqS(k_401, "mod")) {
Invoke(o_402, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(sy_406)), ((V)((-6D))), ((V)(104D)), ((V)(58D)), ((V)(5D)), ((V)("#2f2f3a")), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)((sy_406 + 3D))), ((V)((-3.4))), ((V)(98D)), ((V)(52D)), ((V)(0.6)), SCR_35, NewObj(3).Put("r", ((V)(2D))).Put("emit", ((V)(1D))).Put("scr", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(18D)), ((V)((sy_406 + 8D))), ((V)((-3D))), ((V)(44D)), ((V)(12D)), ((V)(0.4)), ((V)("#9fc684")), NewObj(2).Put("r", ((V)(6D))).Put("emit", ((V)(1D))).V));
} else {
if (SEqS(k_401, "candy")) {
InvokeSpread(o_402, "push", new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(sy_406)), ((V)((-4D))), ((V)(92D)), ((V)(60D)), ((V)(18D)), Get(P_399, "a"), NewObj(2).Put("r", ((V)(26D))).Put("bev", ((V)(5D))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)((sy_406 + 9D))), ((V)(5.4)), ((V)(70D)), ((V)(42D)), ((V)(0.8)), SCR_35, NewObj(3).Put("r", ((V)(16D))).Put("emit", ((V)(1D))).Put("scr", ((V)(1D))).V)).Add(Call(ball_14, V.Undef, ((V)((-36D))), ((V)((sy_406 + 56D))), ((V)((-4D))), ((V)(8D)), GetIdx(NE_26, 1D))).Add(Call(ball_14, V.Undef, ((V)(36D)), ((V)((sy_406 + 56D))), ((V)((-4D))), ((V)(8D)), GetIdx(NE_26, 4D))).Spread(Call(drips_40, V.Undef, ((V)(0D)), ((V)((sy_406 + 60D))), ((V)(5D)), ((V)(70D)), Get(P_399, "aL"), ((V)(5D)))).V);
} else {
if (SEqS(k_401, "royal")) {
Invoke(o_402, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(sy_406)), ((V)((-6D))), ((V)(102D)), ((V)(64D)), ((V)(6D)), GOLD_27, NewObj(1).Put("r", ((V)(6D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)((sy_406 + 5D))), ((V)((-2.8))), ((V)(92D)), ((V)(54D)), ((V)(0.6)), SCR_35, NewObj(3).Put("r", ((V)(4D))).Put("emit", ((V)(1D))).Put("scr", ((V)(1D))).V), Call(jewel_42, V.Undef, ((V)(0D)), ((V)((sy_406 + 64D))), ((V)((-6D))), ((V)(6D))), Call(ball_14, V.Undef, ((V)((-50D))), ((V)((sy_406 + 60D))), ((V)((-6D))), ((V)(4D)), GOLD_27), Call(ball_14, V.Undef, ((V)(50D)), ((V)((sy_406 + 60D))), ((V)((-6D))), ((V)(4D)), GOLD_27));
} else {
Invoke(o_402, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(sy_406)), ((V)((-4D))), ((V)(86D)), ((V)(58D)), ((V)(16D)), Get(P_399, "wD"), NewObj(2).Put("r", ((V)(8D))).Put("bev", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)((sy_406 + 7D))), ((V)(4.2)), ((V)(70D)), ((V)(44D)), ((V)(0.8)), SCR_35, NewObj(3).Put("r", ((V)(6D))).Put("emit", ((V)(1D))).Put("scr", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(16D)), ((V)((sy_406 + 12D))), ((V)(4.8)), ((V)(30D)), ((V)(10D)), ((V)(0.4)), ((V)("#e9f7fd")), NewObj(2).Put("r", ((V)(5D))).Put("emit", ((V)(1D))).V));
}
}
}
}
return o_402;
return default;
}, 1, "build", true)).V;
}, 1, "tv", true)).Put("shelf", Fn((V _arrowThis422, int _argc415, V S_421, V _a418, V _a419, V _a420, V[] _rest416) => {
return NewObj(3).Put("w", ((V)(102D))).Put("d", ((V)(36D))).Put("build", Fn((V _arrowThis430, int _argc423, V P_429, V _a426, V _a427, V _a428, V[] _rest424) => {
V k_431 = default;
V o_432 = default;
V C_433 = default;
V fc_434 = default;
double H_435 = 0;
double th_436 = 0;
k_431 = Get(S_421, "k");
o_432 = Arr();
C_433 = Arr(((V)("#e3946a")), ((V)("#84b6c9")), ((V)("#f2c255")), ((V)("#9fc684")), ((V)("#8f86c9")), ((V)("#fffaf1")));
if (SEqS(k_431, "junk")) {
Invoke(Arr(Arr(((V)((-24D))), ((V)(0D)), OLD_33), Arr(((V)(24D)), ((V)(0D)), OLD2_34), Arr(((V)((-12D))), ((V)(36D)), ((V)("#b89a74")))), "forEach", Fn((V _arrowThis451, int _argc437, V _a439, V i_443, V _a441, V _a442, V[] _rest438) => {
V x_446 = default;
V y_448 = default;
V c_450 = default;
{ V _t444 = ListOf(_a439);
{ V _t445 = GetIdx(_t444, 0D);
x_446 = _t445; }
{ V _t447 = GetIdx(_t444, 1D);
y_448 = _t447; }
{ V _t449 = GetIdx(_t444, 2D);
c_450 = _t449; }
}
Invoke(o_432, "push", Call(box_11, V.Undef, x_446, y_448, ((V)((-15D))), ((V)(46D)), ((V)(36D)), ((V)(4D)), Call(shade_23, V.Undef, c_450, ((V)(0.8)))), Call(box_11, V.Undef, ((V)((ToNum(x_446) - 21D))), y_448, ((V)(0D)), ((V)(4D)), ((V)(36D)), ((V)(34D)), c_450), Call(box_11, V.Undef, Add(x_446, ((V)(21D))), y_448, ((V)(0D)), ((V)(4D)), ((V)(36D)), ((V)(34D)), c_450), Call(box_11, V.Undef, x_446, y_448, ((V)(0D)), ((V)(46D)), ((V)(4D)), ((V)(34D)), c_450), Call(box_11, V.Undef, x_446, Add(y_448, ((V)(32D))), ((V)(0D)), ((V)(46D)), ((V)(4D)), ((V)(34D)), c_450), Call(box_11, V.Undef, ((V)((ToNum(x_446) - 8D))), Add(y_448, ((V)(4D))), ((V)((-2D))), ((V)(8D)), ((V)((24D - (ToNum(i_443) * 3D)))), ((V)(22D)), GetK(C_433, i_443), NewObj(1).Put("r", ((V)(1D))).V), Call(box_11, V.Undef, Add(x_446, ((V)(2D))), Add(y_448, ((V)(4D))), ((V)((-2D))), ((V)(7D)), ((V)(27D)), ((V)(22D)), GetK(C_433, Add(i_443, ((V)(2D)))), NewObj(1).Put("r", ((V)(1D))).V));
return default;
}, 2, "", true));
Invoke(o_432, "push", Call(cyl_13, V.Undef, ((V)(24D)), ((V)(36D)), ((V)(0D)), ((V)(7D)), ((V)(11D)), TIN_32, NewObj(1).Put("n", ((V)(10D))).V), Call(ball_14, V.Undef, ((V)(24D)), ((V)(45D)), ((V)(0D)), ((V)(9D)), ((V)("#8fc176"))));
return o_432;
}
fc_434 = (SEqS(k_431, "royal") ? ((V)("#f4f1ea")) : (SEqS(k_431, "mod") ? DK_31 : (SEqS(k_431, "retro") ? Get(P_429, "a") : (SEqS(k_431, "candy") ? Get(P_429, "a") : Get(P_429, "w")))));
H_435 = (SEqS(k_431, "mod") ? 120D : 130D);
th_436 = (SEqS(k_431, "mod") ? 3D : 8D);
Invoke(o_432, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-14D))), ((V)(86D)), ((V)(H_435)), ((V)(6D)), (SEqS(k_431, "mod") ? ((V)("#e9e5dc")) : Call(shade_23, V.Undef, fc_434, ((V)(0.8)))), NewObj(1).Put("r", ((V)(1D))).V), Call(box_11, V.Undef, ((V)((-46D))), ((V)(0D)), ((V)(0D)), ((V)(th_436)), ((V)(H_435)), ((V)(34D)), fc_434, NewObj(1).Put("r", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(46D)), ((V)(0D)), ((V)(0D)), ((V)(th_436)), ((V)(H_435)), ((V)(34D)), fc_434, NewObj(1).Put("r", ((V)(2D))).V));
if (SEqS(k_431, "candy")) {
InvokeSpread(o_432, "push", new ArrBuilder().Add(Call(slab_15, V.Undef, ((V)(0D)), ((V)((H_435 - 8D))), ((V)(0D)), ((V)(102D)), ((V)(26D)), ((V)(36D)), Get(P_429, "a"), NewObj(1).Put("r", ((V)(18D))).V)).Spread(Call(drips_40, V.Undef, ((V)(0D)), ((V)((H_435 - 6D))), ((V)(18D)), ((V)(90D)), Get(P_429, "aL"), ((V)(6D)))).Spread(Call(spr_39, V.Undef, ((V)(0D)), ((V)((H_435 + 18D))), ((V)(0D)), ((V)(60D)), ((V)(14D)), ((V)(6D)))).V);
} else {
Invoke(o_432, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)((H_435 - 4D))), ((V)(0D)), ((V)(102D)), ((V)(6D)), ((V)(36D)), fc_434, NewObj(2).Put("r", ((V)(3D))).Put("bev", ((V)(1.5))).V));
}
if (SEqS(k_431, "royal")) {
Invoke(o_432, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)((H_435 + 2D))), ((V)(0D)), ((V)(102D)), ((V)(3D)), ((V)(36D)), GOLD_27, NewObj(1).Put("r", ((V)(3D))).V), Call(jewel_42, V.Undef, ((V)(0D)), ((V)((H_435 + 5D))), ((V)(0D)), ((V)(7D))), Call(jewel_42, V.Undef, ((V)((-46D))), ((V)((H_435 + 5D))), ((V)(0D)), ((V)(4D))), Call(jewel_42, V.Undef, ((V)(46D)), ((V)((H_435 + 5D))), ((V)(0D)), ((V)(4D))));
}
if (SEqS(k_431, "retro")) {
Invoke(o_432, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)((H_435 - 10D))), ((V)(17.6)), ((V)(96D)), ((V)(3D)), ((V)(1D)), CH_28));
}
Invoke(Arr(((V)(0D)), ((V)(42D)), ((V)(84D))), "forEach", Fn((V _arrowThis460, int _argc452, V y_458, V s_459, V _a456, V _a457, V[] _rest453) => {
double x_461 = 0;
double i_462 = 0;
Invoke(o_432, "push", Call(box_11, V.Undef, ((V)(0D)), y_458, ((V)(1D)), ((V)(86D)), ((V)((SEqS(k_431, "mod") ? 3D : 4D))), ((V)(30D)), (SEqS(k_431, "mod") ? DK_31 : fc_434), NewObj(1).Put("r", ((V)(1D))).V));
x_461 = (-38D);
i_462 = 0D;
while (true) {
double w_463 = 0;
double h_464 = 0;
w_463 = (7D + (((i_462 * 5D) + (ToNum(s_459) * 3D)) % 4D));
h_464 = (24D + ((ToNum(Add(((V)((i_462 * 7D))), s_459)) % 4D) * 3D));
if (((x_461 + w_463) > (SEqN(s_459, 1D) ? 14D : 38D))) {
break;
}
Invoke(o_432, "push", Call(box_11, V.Undef, ((V)((x_461 + (w_463 / 2D)))), Add(y_458, ((V)(4D))), ((V)((-1D))), ((V)(w_463)), ((V)(h_464)), ((V)(22D)), GetIdx(C_433, ((i_462 + (ToNum(s_459) * 2D)) % 6D)), NewObj(1).Put("r", ((V)(1D))).V));
x_461 = (x_461 + (w_463 + 1D));
i_462++;
}
if (SEqN(s_459, 1D)) {
Invoke(o_432, "push", (SEqS(k_431, "royal") ? Call(jewel_42, V.Undef, ((V)(28D)), Add(y_458, ((V)(4D))), ((V)(0D)), ((V)(8D))) : Call(ball_14, V.Undef, ((V)(28D)), Add(y_458, ((V)(4D))), ((V)(0D)), ((V)(8D)), (SEqS(k_431, "candy") ? GetIdx(NE_26, 1D) : ((V)("#9fc684"))))));
}
return default;
}, 2, "", true));
if (SEqS(k_431, "mod")) {
Invoke(o_432, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(1D)), ((V)(86D)), ((V)(3D)), ((V)(30D)), DK_31));
}
return o_432;
return default;
}, 1, "build", true)).V;
}, 1, "shelf", true)).Put("lamp", Fn((V _arrowThis472, int _argc465, V S_471, V _a468, V _a469, V _a470, V[] _rest466) => {
return NewObj(5).Put("w", ((V)(44D))).Put("d", ((V)(44D))).Put("round", ((V)(1D))).Put("glow", Fn((V _arrowThis479, int _argc473, V _a475, V _a476, V _a477, V _a478, V[] _rest474) => {
return NewObj(2).Put("y", ((V)((SEqS(Get(S_471, "k"), "royal") ? 92D : 108D)))).Put("r", ((V)(80D))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis487, int _argc480, V P_486, V _a483, V _a484, V _a485, V[] _rest481) => {
V k_488 = default;
k_488 = Get(S_471, "k");
if (SEqS(k_488, "junk")) {
return Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(24D)), ((V)(4D)), ((V)(24D)), ((V)("#8a8f94")), NewObj(1).Put("r", ((V)(2D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(1.6)), ((V)(92D)), ((V)("#8a8f94")), NewObj(1).Put("n", ((V)(6D))).V), Call(ball_14, V.Undef, ((V)(0D)), ((V)(84D)), ((V)(3D)), ((V)(5D)), ((V)("#fff1a8")), NewObj(1).Put("emit", ((V)(1D))).V), Call(cyl_13, V.Undef, ((V)(2D)), ((V)(90D)), ((V)(2D)), ((V)(18D)), ((V)(20D)), ((V)("#c9b48e")), NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(20D)), ((V)(7D))))).V), Call(patch_41, V.Undef, ((V)((-8D))), ((V)(96D)), ((V)(14D)), ((V)(6D)), ((V)(8D)), ((V)("#a99a84"))));
}
if (SEqS(k_488, "retro")) {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(14D)), ((V)(28D)), CH_28, NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(28D)), ((V)(8D))))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(28D)), ((V)(0D)), ((V)(11D)), ((V)(54D)), ((V)("#ffb347")), NewObj(2).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(26D)), ((V)(0D)), ((V)(1D))), Arr(((V)(54D)), ((V)(0D)), ((V)(0.55))))).Put("emit", ((V)(1D))).V), Call(ball_14, V.Undef, ((V)((-3D))), ((V)(38D)), ((V)(0D)), ((V)(4.5)), Get(P_486, "a"), NewObj(1).Put("emit", ((V)(1D))).V), Call(ball_14, V.Undef, ((V)(3D)), ((V)(54D)), ((V)(1D)), ((V)(3.5)), Get(P_486, "a"), NewObj(1).Put("emit", ((V)(1D))).V), Call(ball_14, V.Undef, ((V)((-1D))), ((V)(66D)), ((V)(0D)), ((V)(3D)), Get(P_486, "a"), NewObj(1).Put("emit", ((V)(1D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(82D)), ((V)(0D)), ((V)(6D)), ((V)(10D)), CH_28, NewObj(1).Put("top", ((V)(3D))).V));
}
if (SEqS(k_488, "mod")) {
V o_489 = default;
o_489 = Arr(Call(box_11, V.Undef, ((V)(26D)), ((V)(0D)), ((V)(0D)), ((V)(22D)), ((V)(6D)), ((V)(22D)), DK_31, NewObj(1).Put("r", ((V)(3D))).V));
{
double i_490 = 0;
i_490 = 0D;
while (true) {
if (!((i_490 <= 16D))) break;
double t_492 = 0;
t_492 = (((i_490 / 16D) * System.Math.PI) * 0.62);
Invoke(o_489, "push", Call(ball_14, V.Undef, ((V)((26D - (44D * (1D - FdLibm.Cos(t_492)))))), ((V)(((6D + (120D * FdLibm.Sin(t_492))) - 3.4))), ((V)(0D)), ((V)(3.6)), DK_31, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(10D))).V));
i_490++;
}
}
Invoke(o_489, "push", Call(cyl_13, V.Undef, ((V)((-16D))), ((V)(100D)), ((V)(0D)), ((V)(17D)), ((V)(14D)), Get(P_486, "a"), NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(14D)), ((V)(10D))))).V), Call(ball_14, V.Undef, ((V)((-16D))), ((V)(96D)), ((V)(0D)), ((V)(5D)), ((V)("#fff1a8")), NewObj(1).Put("emit", ((V)(1D))).V));
return o_489;
}
if (SEqS(k_488, "candy")) {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(14D)), ((V)(5D)), Get(P_486, "b")), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(5D)), ((V)(0D)), ((V)(2.4)), ((V)(82D)), WH_30, NewObj(1).Put("n", ((V)(8D))).V), Call(ball_14, V.Undef, ((V)((-14D))), ((V)(84D)), ((V)(0D)), ((V)(14D)), ((V)("#fffdf5")), NewObj(1).Put("emit", ((V)(1D))).V), Call(ball_14, V.Undef, ((V)(10D)), ((V)(82D)), ((V)(2D)), ((V)(16D)), ((V)("#fffdf5")), NewObj(1).Put("emit", ((V)(1D))).V), Call(ball_14, V.Undef, ((V)(0D)), ((V)(96D)), ((V)((-2D))), ((V)(16D)), ((V)("#fffdf5")), NewObj(1).Put("emit", ((V)(1D))).V), Call(ball_14, V.Undef, ((V)((-4D))), ((V)(86D)), ((V)(12D)), ((V)(3D)), GetIdx(NE_26, 1D), NewObj(1).Put("emit", ((V)(1D))).V), Call(ball_14, V.Undef, ((V)(8D)), ((V)(92D)), ((V)(12D)), ((V)(3D)), GetIdx(NE_26, 4D), NewObj(1).Put("emit", ((V)(1D))).V));
}
if (SEqS(k_488, "royal")) {
return new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(16D)), ((V)(6D)), GOLD_27, NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(6D)), ((V)(6D))))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(3D)), ((V)(70D)), GOLD_27, NewObj(2).Put("n", ((V)(8D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.4))), Arr(((V)(30D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(70D)), ((V)(0D)), ((V)(1D))))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(72D)), ((V)(0D)), ((V)(56D)), ((V)(4D)), ((V)(5D)), GOLD_27, NewObj(1).Put("r", ((V)(2D))).V)).Spread(Invoke(Arr(((V)((-26D))), ((V)(0D)), ((V)(26D))), "flatMap", Fn((V _arrowThis500, int _argc493, V x_499, V _a496, V _a497, V _a498, V[] _rest494) => {
return new ArrBuilder().Add(Call(cyl_13, V.Undef, x_499, ((V)(76D)), ((V)(0D)), ((V)(3.5)), ((V)(3D)), GOLD_27, NewObj(1).Put("n", ((V)(8D))).V)).Add(Call(cyl_13, V.Undef, x_499, ((V)(79D)), ((V)(0D)), ((V)(2.4)), ((V)(14D)), CR_29, NewObj(1).Put("n", ((V)(8D))).V)).Spread(Call(flame_45, V.Undef, x_499, ((V)(93D)), ((V)(0D)), ((V)(0.9)))).V;
}, 1, "", true))).V;
}
return new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(16D)), ((V)(4D)), Get(P_486, "wD"))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(2.5)), ((V)(100D)), Get(P_486, "wD"), NewObj(2).Put("n", ((V)(8D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.4))), Arr(((V)(30D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(100D)), ((V)(0D)), ((V)(1D))))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(98D)), ((V)(0D)), ((V)(24D)), ((V)(30D)), Get(P_486, "a"), NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(30D)), ((V)(8D))))).V)).Spread(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(4D)), ((V)(5D)), ((V)(6D)), ((V)(7D))), "map", Fn((V _arrowThis508, int _argc501, V i_507, V _a504, V _a505, V _a506, V[] _rest502) => {
return Call(ball_14, V.Undef, ((V)((24D * FdLibm.Cos((ToNum(i_507) * 0.785))))), ((V)(94D)), ((V)((24D * FdLibm.Sin((ToNum(i_507) * 0.785))))), ((V)(2.4)), Get(P_486, "b"), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V);
}, 1, "", true))).V;
return default;
}, 1, "build", true)).V;
}, 1, "lamp", true)).Put("plant", Fn((V _arrowThis516, int _argc509, V S_515, V _a512, V _a513, V _a514, V[] _rest510) => {
return NewObj(4).Put("w", ((V)((SEqS(Get(S_515, "k"), "cot") ? 70D : 50D)))).Put("d", ((V)((SEqS(Get(S_515, "k"), "cot") ? 34D : 50D)))).Put("round", ((V)((SEqS(Get(S_515, "k"), "cot") ? 0D : 1D)))).Put("build", Fn((V _arrowThis524, int _argc517, V P_523, V _a520, V _a521, V _a522, V[] _rest518) => {
V k_525 = default;
k_525 = Get(S_515, "k");
if (SEqS(k_525, "junk")) {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(12D)), ((V)(20D)), TIN_32, NewObj(1).Put("n", ((V)(12D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(20D)), ((V)(0D)), ((V)(12.5)), ((V)(2D)), ((V)("#c9cfd2")), NewObj(1).Put("n", ((V)(12D))).V), Call(ball_14, V.Undef, ((V)((-6D))), ((V)(20D)), ((V)(0D)), ((V)(7D)), ((V)("#9fc684")), NewObj(1).Put("sy", ((V)(1.5))).V), Call(ball_14, V.Undef, ((V)(6D)), ((V)(22D)), ((V)(2D)), ((V)(6D)), ((V)("#8fc176")), NewObj(1).Put("sy", ((V)(1.4))).V), Call(ball_14, V.Undef, ((V)(0D)), ((V)(28D)), ((V)((-3D))), ((V)(5D)), ((V)("#a8d48a")), NewObj(1).Put("sy", ((V)(1.4))).V));
}
if (SEqS(k_525, "cot")) {
return new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(66D)), ((V)(22D)), ((V)(30D)), Get(P_523, "w"), NewObj(2).Put("r", ((V)(3D))).Put("bev", ((V)(2D))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(60D)), ((V)(0.6)), ((V)(24D)), ((V)("#6a4020")))).Spread(Invoke(Arr(((V)((-22D))), ((V)(0D)), ((V)(22D))), "flatMap", Fn((V _arrowThis534, int _argc526, V x_532, V i_533, V _a530, V _a531, V[] _rest527) => {
return Arr(Call(ball_14, V.Undef, x_532, ((V)(20D)), ((V)(0D)), ((V)(10D)), GetK(Arr(((V)("#7ab45c")), ((V)("#8fc176")), ((V)("#a8d48a"))), i_533), NewObj(1).Put("sy", ((V)(1.3))).V), Call(ball_14, V.Undef, ((V)((ToNum(x_532) - 4D))), ((V)(36D)), ((V)(4D)), ((V)(3D)), (SEqN(i_533, 1D) ? CR_29 : ((V)("#c4a0e0"))), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 2, "", true))).V;
}
if (SEqS(k_525, "retro")) {
return new ArrBuilder().Spread(Call(legs_38, V.Undef, S_515, P_523, ((V)(9D)), ((V)(9D)), ((V)(14D)), ((V)(2.5)))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(0D)), ((V)(16D)), ((V)(18D)), Get(P_523, "a"), NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(18D)), ((V)(0D)), ((V)(1D))))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(32D)), ((V)(0D)), ((V)(8D)), ((V)(34D)), ((V)("#6fae50")), NewObj(2).Put("n", ((V)(10D))).Put("top", ((V)(6D))).V)).Add(Call(ball_14, V.Undef, ((V)((-14D))), ((V)(44D)), ((V)(0D)), ((V)(5D)), ((V)("#6fae50")), NewObj(1).Put("sy", ((V)(2D))).V)).Add(Call(ball_14, V.Undef, ((V)(12D)), ((V)(50D)), ((V)(0D)), ((V)(5D)), ((V)("#6fae50")), NewObj(1).Put("sy", ((V)(1.8))).V)).Add(Call(ball_14, V.Undef, ((V)(0D)), ((V)(66D)), ((V)(0D)), ((V)(3D)), ((V)("#e2554a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)).V;
}
if (SEqS(k_525, "mod")) {
V o_535 = default;
o_535 = Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(17D)), ((V)(30D)), ((V)("#c9c9c4")), NewObj(1).Put("n", ((V)(16D))).V));
Invoke(Arr(Arr(((V)((-8D))), ((V)(70D)), ((V)(0.2))), Arr(((V)(0D)), ((V)(84D)), ((V)((-0.3)))), Arr(((V)(8D)), ((V)(66D)), ((V)(0.6))), Arr(((V)((-2D))), ((V)(58D)), ((V)(1.2))), Arr(((V)(6D)), ((V)(76D)), ((V)(2.2)))), "forEach", Fn((V _arrowThis550, int _argc536, V _a538, V i_542, V _a540, V _a541, V[] _rest537) => {
V x_545 = default;
V h_547 = default;
V y_549 = default;
{ V _t543 = ListOf(_a538);
{ V _t544 = GetIdx(_t543, 0D);
x_545 = _t544; }
{ V _t546 = GetIdx(_t543, 1D);
h_547 = _t546; }
{ V _t548 = GetIdx(_t543, 2D);
y_549 = _t548; }
}
return Invoke(o_535, "push", Call(box_11, V.Undef, x_545, ((V)(28D)), ((V)((((ToNum(i_542) % 2D) * 4D) - 2D))), ((V)(7D)), ((V)((ToNum(h_547) - 20D))), ((V)(3D)), ((V)((NumTruthy((ToNum(i_542) % 2D)) ? "#5a9a54" : "#6fae50"))), NewObj(2).Put("r", ((V)(3D))).Put("yaw", y_549).V));
}, 2, "", true));
return o_535;
}
if (SEqS(k_525, "candy")) {
return new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(16D)), ((V)(22D)), Get(P_523, "b"), NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(22D)), ((V)(0D)), ((V)(1D))))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(2.4)), ((V)(40D)), WH_30, NewObj(1).Put("n", ((V)(8D))).V)).Add(Call(disc_18, V.Undef, ((V)(0D)), ((V)(70D)), ((V)((-3D))), ((V)(20D)), ((V)(6D)), Get(P_523, "a"), NewObj(1).Put("top", ((V)(2D))).V)).Add(Call(disc_18, V.Undef, ((V)(0D)), ((V)(70D)), ((V)(3D)), ((V)(13D)), ((V)(0.6)), Get(P_523, "w"))).Add(Call(disc_18, V.Undef, ((V)(0D)), ((V)(70D)), ((V)(3.6)), ((V)(6D)), ((V)(0.6)), CR_29)).Spread(Call(spr_39, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(18D)), ((V)(18D)), ((V)(5D)))).V;
}
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(12D)), ((V)(8D)), ((V)("#f4f1ea"))), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(0D)), ((V)(18D)), ((V)(30D)), ((V)("#f4f1ea")), NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(16D)), ((V)(0D)), ((V)(1.1))), Arr(((V)(30D)), ((V)(0D)), ((V)(0.9))))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(19.5)), ((V)(3D)), GOLD_27), Call(ball_14, V.Undef, ((V)((-15D))), ((V)(34D)), ((V)(6D)), ((V)(14D)), ((V)("#5a9a54")), NewObj(1).Put("sy", ((V)(0.8))).V), Call(ball_14, V.Undef, ((V)(15D)), ((V)(36D)), ((V)(4D)), ((V)(14D)), ((V)("#5a9a54")), NewObj(1).Put("sy", ((V)(0.8))).V), Call(ball_14, V.Undef, ((V)(0D)), ((V)(38D)), ((V)(0D)), ((V)(18D)), ((V)("#6fae50"))), Call(ball_14, V.Undef, ((V)((-4D))), ((V)(60D)), ((V)((-4D))), ((V)(11D)), ((V)("#8fc176"))), Call(ball_14, V.Undef, ((V)(8D)), ((V)(56D)), ((V)(8D)), ((V)(10D)), ((V)("#8fc176"))));
return default;
}, 1, "build", true)).V;
}, 1, "plant", true)).Put("rug", Fn((V _arrowThis558, int _argc551, V S_557, V _a554, V _a555, V _a556, V[] _rest552) => {
return NewObj(6).Put("w", ((V)(((SEqS(Get(S_557, "k"), "cot") || SEqS(Get(S_557, "k"), "candy")) ? 180D : 200D)))).Put("d", ((V)(((SEqS(Get(S_557, "k"), "cot") || SEqS(Get(S_557, "k"), "candy")) ? 124D : 130D)))).Put("round", ((V)(((SEqS(Get(S_557, "k"), "cot") || SEqS(Get(S_557, "k"), "candy")) ? 1D : 0D)))).Put("flat", ((V)(1D))).Put("noBlock", ((V)(1D))).Put("build", Fn((V _arrowThis566, int _argc559, V P_565, V _a562, V _a563, V _a564, V[] _rest560) => {
V k_567 = default;
k_567 = Get(S_557, "k");
if (SEqS(k_567, "junk")) {
return new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(190D)), ((V)(2D)), ((V)(120D)), Get(P_565, "a"), NewObj(1).Put("r", ((V)(6D))).V)).Spread(Invoke(Arr(((V)((-44D))), ((V)((-22D))), ((V)(0D)), ((V)(22D)), ((V)(44D))), "map", Fn((V _arrowThis576, int _argc568, V z_574, V i_575, V _a572, V _a573, V[] _rest569) => {
return Call(box_11, V.Undef, ((V)(0D)), ((V)(2D)), z_574, ((V)(180D)), ((V)(0.6)), ((V)(12D)), GetK(Arr(Get(P_565, "b"), ((V)("#8fa8a0")), CR_29, ((V)("#b8714a")), Get(P_565, "b")), i_575), NewObj(1).Put("r", ((V)(2D))).V);
}, 2, "", true))).Add(Call(patch_41, V.Undef, ((V)((-60D))), ((V)(2.6)), ((V)(0D)), ((V)(1D)), ((V)(1D)), Get(P_565, "a"))).V;
}
if (SEqS(k_567, "cot")) {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(90D)), ((V)(2D)), Get(P_565, "a"), NewObj(2).Put("rz", ((V)(62D))).Put("n", ((V)(24D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(0D)), ((V)(76D)), ((V)(0.6)), CR_29, NewObj(2).Put("rz", ((V)(52D))).Put("n", ((V)(24D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(2.6)), ((V)(0D)), ((V)(62D)), ((V)(0.6)), Get(P_565, "b"), NewObj(2).Put("rz", ((V)(42D))).Put("n", ((V)(22D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(3.2)), ((V)(0D)), ((V)(46D)), ((V)(0.6)), Get(P_565, "a"), NewObj(2).Put("rz", ((V)(31D))).Put("n", ((V)(20D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(3.8)), ((V)(0D)), ((V)(28D)), ((V)(0.6)), CR_29, NewObj(2).Put("rz", ((V)(19D))).Put("n", ((V)(16D))).V));
}
if (SEqS(k_567, "retro")) {
V o_577 = default;
o_577 = Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(200D)), ((V)(2D)), ((V)(130D)), ((V)("#3d4048")), NewObj(1).Put("r", ((V)(6D))).V));
{
double i_578 = 0;
i_578 = 0D;
while (true) {
if (!((i_578 < 6D))) break;
{
double j_580 = 0;
j_580 = 0D;
while (true) {
if (!((j_580 < 4D))) break;
if ((((i_578 + j_580) % 2D) == 0D)) {
Invoke(o_577, "push", Call(box_11, V.Undef, ((V)(((-80D) + (32D * i_578)))), ((V)(2D)), ((V)(((-45D) + (30D * j_580)))), ((V)(31D)), ((V)(0.6)), ((V)(29D)), CR_29, NewObj(1).Put("r", ((V)(1D))).V));
}
j_580++;
}
}
i_578++;
}
}
return o_577;
}
if (SEqS(k_567, "mod")) {
return Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(200D)), ((V)(2D)), ((V)(130D)), Get(P_565, "a"), NewObj(1).Put("r", ((V)(4D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(0D)), ((V)(176D)), ((V)(0.6)), ((V)(106D)), Call(shade_23, V.Undef, Get(P_565, "a"), ((V)(0.9))), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(2.6)), ((V)(30D)), ((V)(176D)), ((V)(0.6)), ((V)(8D)), Get(P_565, "b"), NewObj(1).Put("r", ((V)(1D))).V));
}
if (SEqS(k_567, "candy")) {
return new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(90D)), ((V)(3D)), Get(P_565, "a"), NewObj(3).Put("rz", ((V)(62D))).Put("n", ((V)(24D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(3D))), Arr(((V)(3D)), ((V)(0D))))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(70D)), ((V)(0.6)), Get(P_565, "b"), NewObj(2).Put("rz", ((V)(48D))).Put("n", ((V)(22D))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(3.6)), ((V)(0D)), ((V)(40D)), ((V)(0.6)), Get(P_565, "w"), NewObj(2).Put("rz", ((V)(27D))).Put("n", ((V)(18D))).V)).Spread(Call(spr_39, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(130D)), ((V)(70D)), ((V)(12D)))).V;
}
return Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(200D)), ((V)(2D)), ((V)(130D)), Get(P_565, "a"), NewObj(1).Put("r", ((V)(6D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(0D)), ((V)(186D)), ((V)(0.6)), ((V)(116D)), GOLD_27, NewObj(1).Put("r", ((V)(4D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(2.6)), ((V)(0D)), ((V)(176D)), ((V)(0.6)), ((V)(106D)), Get(P_565, "a"), NewObj(1).Put("r", ((V)(3D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(3.2)), ((V)(0D)), ((V)(34D)), ((V)(0.6)), GOLD_27, NewObj(2).Put("rz", ((V)(24D))).Put("n", ((V)(16D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(3.8)), ((V)(0D)), ((V)(24D)), ((V)(0.6)), (SEq(Get(P_565, "b"), GOLD_27) ? CR_29 : Get(P_565, "b")), NewObj(2).Put("rz", ((V)(16D))).Put("n", ((V)(14D))).V));
return default;
}, 1, "build", true)).V;
}, 1, "rug", true)).Put("mat", Fn((V _arrowThis589, int _argc582, V S_588, V _a585, V _a586, V _a587, V[] _rest583) => {
return NewObj(5).Put("w", ((V)(120D))).Put("d", ((V)(72D))).Put("flat", ((V)(1D))).Put("noBlock", ((V)(1D))).Put("build", Fn((V _arrowThis597, int _argc590, V P_596, V _a593, V _a594, V _a595, V[] _rest591) => {
return new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(120D)), ((V)(3D)), ((V)(72D)), Get(P_596, "a"), NewObj(1).Put("r", ((V)(14D))).V)).Spread(Invoke(Arr(((V)((-36D))), ((V)((-12D))), ((V)(12D)), ((V)(36D))), "flatMap", Fn((V _arrowThis605, int _argc598, V x_604, V _a601, V _a602, V _a603, V[] _rest599) => {
return Invoke(Arr(((V)((-16D))), ((V)(0D)), ((V)(16D))), "map", Fn((V _arrowThis613, int _argc606, V z_612, V _a609, V _a610, V _a611, V[] _rest607) => {
return Call(cyl_13, V.Undef, x_604, ((V)(3D)), z_612, ((V)(4D)), ((V)(0.6)), Call(shade_23, V.Undef, Get(P_596, "a"), ((V)(0.86))), NewObj(1).Put("n", ((V)(8D))).V);
}, 1, "", true));
}, 1, "", true))).V;
}, 1, "build", true)).V;
}, 1, "mat", true)).Put("pouf", Fn((V _arrowThis621, int _argc614, V S_620, V _a617, V _a618, V _a619, V[] _rest615) => {
return NewObj(6).Put("w", ((V)((SEqS(Get(S_620, "k"), "junk") ? 96D : 70D)))).Put("d", ((V)((SEqS(Get(S_620, "k"), "junk") ? 86D : 70D)))).Put("round", ((V)(1D))).Put("act", ((V)((SEqS(Get(S_620, "k"), "junk") ? "nap" : "sit")))).Put("seats", Arr(NewObj(4).Put("x", ((V)(0D))).Put("z", ((V)((SEqS(Get(S_620, "k"), "junk") ? 10D : 0D)))).Put("h", ((V)((SEqS(Get(S_620, "k"), "junk") ? 34D : 36D)))).Put("k", ((V)((SEqS(Get(S_620, "k"), "junk") ? "nap" : "sit")))).V)).Put("build", Fn((V _arrowThis629, int _argc622, V P_628, V _a625, V _a626, V _a627, V[] _rest623) => {
return (SEqS(Get(S_620, "k"), "junk") ? Arr(Call(ball_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-14D))), ((V)(32D)), ((V)("#c4a882")), NewObj(5).Put("sx", ((V)(1.3))).Put("sy", ((V)(1.15))).Put("sz", ((V)(0.95))).Put("k", ((V)(8D))).Put("n", ((V)(20D))).V), Call(ball_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(10D)), ((V)(36D)), ((V)("#c4a882")), NewObj(5).Put("sx", ((V)(1.28))).Put("sy", ((V)(0.55))).Put("sz", ((V)(0.92))).Put("k", ((V)(8D))).Put("n", ((V)(20D))).V), Call(patch_41, V.Undef, ((V)((-18D))), ((V)(22D)), ((V)(42D)), ((V)(16D)), ((V)(12D)), Get(P_628, "b")), Call(ball_14, V.Undef, ((V)(26D)), ((V)(64D)), ((V)((-18D))), ((V)(6D)), ((V)("#b39a6c")), NewObj(1).Put("sy", ((V)(1.4))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(24D)), ((V)(43D)), ((V)(30D)), ((V)(6D)), ((V)(1D)), ((V)("#a88a66")), NewObj(1).Put("r", ((V)(2D))).V)) : new ArrBuilder().Add(Call(ball_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(32D)), Get(P_628, "a"), NewObj(4).Put("sy", ((V)(0.62))).Put("k", ((V)(7D))).Put("n", ((V)(20D))).Put("shine", ((V)(1D))).V)).Spread(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(4D)), ((V)(5D)), ((V)(6D)), ((V)(7D))), "map", Fn((V _arrowThis637, int _argc630, V i_636, V _a633, V _a634, V _a635, V[] _rest631) => {
return Call(ball_14, V.Undef, ((V)((22D * FdLibm.Cos((ToNum(i_636) * 0.8))))), ((V)((30D + ((ToNum(i_636) % 2D) * 3D)))), ((V)((22D * FdLibm.Sin((ToNum(i_636) * 0.8))))), ((V)(2.4)), WH_30, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V);
}, 1, "", true))).V);
}, 1, "build", true)).V;
}, 1, "pouf", true)).Put("bowl", Fn((V _arrowThis645, int _argc638, V S_644, V _a641, V _a642, V _a643, V[] _rest639) => {
return NewObj(7).Put("w", ((V)(40D))).Put("d", ((V)(40D))).Put("round", ((V)(1D))).Put("noBlock", ((V)(1D))).Put("act", ((V)("feed"))).Put("use", NewObj(2).Put("x", ((V)(42D))).Put("z", ((V)(6D))).V).Put("build", Fn((V _arrowThis653, int _argc646, V P_652, V _a649, V _a650, V _a651, V[] _rest647) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(18D)), ((V)(12D)), (SEqS(Get(S_644, "k"), "junk") ? TIN_32 : Get(P_652, "a")), NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(6D))), Arr(((V)(10D)), ((V)(0D))), Arr(((V)(12D)), ((V)(0D))))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(0D)), ((V)(15D)), ((V)(0.8)), ((V)("#c98a52"))), Call(ball_14, V.Undef, ((V)((-5D))), ((V)(12D)), ((V)((-2D))), ((V)(2.8)), ((V)("#a86b36")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(ball_14, V.Undef, ((V)(4D)), ((V)(12D)), ((V)(3D)), ((V)(2.8)), ((V)("#e2ad74")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(ball_14, V.Undef, ((V)(1D)), ((V)(12D)), ((V)((-5D))), ((V)(2.6)), ((V)("#c98a52")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), (SEqS(Get(S_644, "k"), "junk") ? Call(patch_41, V.Undef, ((V)((-10D))), ((V)(3D)), ((V)(17D)), ((V)(6D)), ((V)(5D)), ((V)("#8a8f94"))) : Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(1D)), ((V)(0.2)), Get(P_652, "a"))));
}, 1, "build", true)).V;
}, 1, "bowl", true)).Put("fridge", Fn((V _arrowThis661, int _argc654, V S_660, V _a657, V _a658, V _a659, V[] _rest655) => {
V k_662 = default;
double H_663 = 0;
double Wd_664 = 0;
k_662 = Get(S_660, "k");
H_663 = (SEqS(k_662, "junk") ? 110D : (SEqS(k_662, "mod") ? 146D : 136D));
Wd_664 = (SEqS(k_662, "mod") ? 84D : 70D);
return NewObj(5).Put("w", ((V)(Wd_664))).Put("d", ((V)(60D))).Put("act", ((V)("snack"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(62D))).V).Put("build", Fn((V _arrowThis673, int _argc665, V P_671, V v_672, V _a669, V _a670, V[] _rest666) => {
V op_674 = default;
double t_675 = 0;
V o_676 = default;
V body_677 = default;
op_674 = (SEqS(v_672, "open") ? V.True : V.False);
t_675 = ((100D * System.Math.PI) / 180D);
o_676 = Arr();
body_677 = (SEqS(k_662, "junk") ? OLD2_34 : (SEqS(k_662, "royal") ? ((V)("#f4f1ea")) : Get(P_671, "a")));
if ((SEqS(k_662, "mod") || SEqS(k_662, "junk"))) {
Invoke(o_676, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(Wd_664)), ((V)(4D)), ((V)(56D)), DK_31, NewObj(1).Put("r", ((V)(3D))).V));
} else {
InvokeSpread(o_676, "push", new ArrBuilder().Spread(Call(legs_38, V.Undef, S_660, P_671, ((V)(26D)), ((V)(22D)), ((V)(4D)), ((V)(3D)))).V);
}
Invoke(o_676, "push", ((SEqS(k_662, "retro") || SEqS(k_662, "candy")) ? Call(slab_15, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(Wd_664)), ((V)(H_663)), ((V)(60D)), body_677, NewObj(2).Put("r", ((V)(28D))).Put("rb", ((V)(6D))).V) : Call(box_11, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(Wd_664)), ((V)(H_663)), ((V)(60D)), body_677, NewObj(2).Put("r", ((V)((SEqS(k_662, "mod") ? 4D : 12D)))).Put("bev", ((V)(4D))).V)));
if (SEqS(k_662, "junk")) {
Invoke(o_676, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(62D)), ((V)(30.4)), ((V)(64D)), ((V)(2D)), ((V)(0.8)), ((V)("#7d6248"))), Call(box_11, V.Undef, ((V)(22D)), ((V)(74D)), ((V)(31D)), ((V)(8D)), ((V)(10D)), ((V)(3D)), GOLD_27, NewObj(1).Put("r", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(22D)), ((V)(36D)), ((V)(31D)), ((V)(8D)), ((V)(10D)), ((V)(3D)), GOLD_27, NewObj(1).Put("r", ((V)(2D))).V), Call(box_11, V.Undef, ((V)((-31D))), ((V)(90D)), ((V)(31D)), ((V)(4D)), ((V)(8D)), ((V)(3D)), ((V)("#8a8f94"))), Call(box_11, V.Undef, ((V)((-31D))), ((V)(20D)), ((V)(31D)), ((V)(4D)), ((V)(8D)), ((V)(3D)), ((V)("#8a8f94"))), Call(patch_41, V.Undef, ((V)((-14D))), ((V)(80D)), ((V)(30.6)), ((V)(14D)), ((V)(10D)), ((V)("#c9a85a"))));
} else {
if (SEqS(k_662, "mod")) {
Invoke(o_676, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(30.4)), ((V)(1.4)), ((V)((H_663 - 8D))), ((V)(0.8)), Call(shade_23, V.Undef, body_677, ((V)(0.8)))), Call(box_11, V.Undef, ((V)((-5D))), ((V)(70D)), ((V)(31D)), ((V)(3D)), ((V)(40D)), ((V)(3D)), CH_28, NewObj(1).Put("r", ((V)(1.5))).V), Call(box_11, V.Undef, ((V)(5D)), ((V)(70D)), ((V)(31D)), ((V)(3D)), ((V)(40D)), ((V)(3D)), CH_28, NewObj(1).Put("r", ((V)(1.5))).V), Call(box_11, V.Undef, ((V)((-22D))), ((V)(92D)), ((V)(30.6)), ((V)(18D)), ((V)(26D)), ((V)(0.8)), ((V)("#5a6270")), NewObj(1).Put("r", ((V)(3D))).V));
} else {
Invoke(o_676, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(93D)), ((V)(30.2)), ((V)((Wd_664 - 4D))), ((V)(2D)), ((V)(0.8)), Call(shade_23, V.Undef, body_677, ((V)(0.85))), NewObj(1).Put("r", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(24D)), ((V)(102D)), ((V)(31D)), ((V)(5D)), ((V)(24D)), ((V)(3D)), (SEqS(k_662, "royal") ? GOLD_27 : (SEqS(k_662, "retro") ? CH_28 : ((V)("#fbf7ee")))), NewObj(1).Put("r", ((V)(2D))).V));
if (!(Truthy(op_674))) {
Invoke(o_676, "push", Call(box_11, V.Undef, ((V)(24D)), ((V)(44D)), ((V)(31D)), ((V)(5D)), ((V)(40D)), ((V)(3D)), (SEqS(k_662, "royal") ? GOLD_27 : (SEqS(k_662, "retro") ? CH_28 : ((V)("#fbf7ee")))), NewObj(1).Put("r", ((V)(2D))).V));
}
}
}
if (SEqS(k_662, "retro")) {
Invoke(o_676, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(130D)), ((V)(30.6)), ((V)(40D)), ((V)(5D)), ((V)(0.8)), CH_28, NewObj(1).Put("r", ((V)(2D))).V));
}
if (SEqS(k_662, "candy")) {
InvokeSpread(o_676, "push", new ArrBuilder().Spread(Call(drips_40, V.Undef, ((V)(0D)), ((V)((H_663 + 4D))), ((V)(26D)), ((V)(66D)), Get(P_671, "b"), ((V)(6D)))).Add(Call(ball_14, V.Undef, ((V)(0D)), ((V)((H_663 + 2D))), ((V)(0D)), ((V)(9D)), ((V)("#e2554a")))).Spread(Call(spr_39, V.Undef, ((V)(0D)), ((V)(H_663)), ((V)(0D)), ((V)(40D)), ((V)(30D)), ((V)(6D)))).V);
}
if (SEqS(k_662, "royal")) {
Invoke(o_676, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)((Wd_664 + 2D))), ((V)(6D)), ((V)(62D)), GOLD_27, NewObj(1).Put("r", ((V)(12D))).V), Call(jewel_42, V.Undef, ((V)(0D)), ((V)((H_663 + 4D))), ((V)(0D)), ((V)(7D))), Call(disc_18, V.Undef, ((V)((-14D))), ((V)(112D)), ((V)(30D)), ((V)(7D)), ((V)(1D)), GOLD_27));
}
if (SEqS(k_662, "cot")) {
Invoke(o_676, "push", Call(box_11, V.Undef, ((V)((-14D))), ((V)(50D)), ((V)(30.4)), ((V)(14D)), ((V)(10D)), ((V)(1D)), CR_29, NewObj(1).Put("r", ((V)(2D))).V), Call(ball_14, V.Undef, ((V)((-18D))), ((V)(70D)), ((V)(30D)), ((V)(4D)), ((V)("#e3946a")), NewObj(1).Put("sz", ((V)(0.4))).V));
}
if (Truthy(op_674)) {
Invoke(o_676, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(30.6)), ((V)((Wd_664 - 12D))), ((V)(78D)), ((V)(1D)), ((V)("#fff8e2")), NewObj(2).Put("r", ((V)(4D))).Put("emit", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(36D)), ((V)(31.4)), ((V)((Wd_664 - 14D))), ((V)(2D)), ((V)(1D)), ((V)("#e6d6b4"))), Call(box_11, V.Undef, ((V)(0D)), ((V)(60D)), ((V)(31.4)), ((V)((Wd_664 - 14D))), ((V)(2D)), ((V)(1D)), ((V)("#e6d6b4"))), Call(ball_14, V.Undef, ((V)((-14D))), ((V)(12D)), ((V)(32D)), ((V)(6D)), ((V)("#e85a3a"))), Call(ball_14, V.Undef, ((V)(10D)), ((V)(12D)), ((V)(32D)), ((V)(7D)), ((V)("#ffb347"))), Call(box_11, V.Undef, ((V)(14D)), ((V)(38D)), ((V)(32D)), ((V)(14D)), ((V)(14D)), ((V)(2D)), CR_29, NewObj(1).Put("r", ((V)(2D))).V), Call(cyl_13, V.Undef, ((V)((-14D))), ((V)(38D)), ((V)(32D)), ((V)(5D)), ((V)(14D)), ((V)("#84b6c9")), NewObj(1).Put("n", ((V)(8D))).V), Call(box_11, V.Undef, ((V)((((-Wd_664) / 2D) + (33D * FdLibm.Cos(t_675))))), ((V)(8D)), ((V)((30D + (33D * FdLibm.Sin(t_675))))), ((V)((Wd_664 - 4D))), ((V)(84D)), ((V)(6D)), body_677, NewObj(2).Put("r", ((V)(10D))).Put("yaw", ((V)(t_675))).V));
}
return o_676;
return default;
}, 2, "build", true)).V;
return default;
}, 1, "fridge", true)).Put("stove", Fn((V _arrowThis685, int _argc678, V S_684, V _a681, V _a682, V _a683, V[] _rest679) => {
return NewObj(5).Put("w", ((V)(82D))).Put("d", ((V)(62D))).Put("act", ((V)("cook"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(60D))).V).Put("build", Fn((V _arrowThis694, int _argc686, V P_692, V v_693, V _a690, V _a691, V[] _rest687) => {
V k_695 = default;
V on_696 = default;
V o_697 = default;
V body_698 = default;
V top_699 = default;
k_695 = Get(S_684, "k");
on_696 = (SEqS(v_693, "on") ? V.True : V.False);
o_697 = Arr();
body_698 = (SEqS(k_695, "junk") ? ((V)("#5a5450")) : (SEqS(k_695, "royal") ? ((V)("#f4f1ea")) : (SEqS(k_695, "mod") ? ((V)("#e9e5dc")) : (SEqS(k_695, "cot") ? ((V)("#f4ead8")) : Get(P_692, "a")))));
top_699 = ((V)((SEqS(k_695, "mod") ? "#2b2b33" : "#4a3a30")));
Invoke(o_697, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(80D)), ((V)(64D)), ((V)(60D)), body_698, NewObj(2).Put("r", ((V)((SEqS(k_695, "mod") ? 3D : 8D)))).Put("bev", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(64D)), ((V)(0D)), ((V)(82D)), ((V)(4D)), ((V)(62D)), top_699, NewObj(1).Put("r", ((V)(4D))).V));
if (SEqS(k_695, "junk")) {
Invoke(o_697, "push", Call(cyl_13, V.Undef, ((V)((-26D))), ((V)(68D)), ((V)((-22D))), ((V)(6D)), ((V)(70D)), ((V)("#6a625c")), NewObj(1).Put("n", ((V)(10D))).V), Call(patch_41, V.Undef, ((V)(24D)), ((V)(40D)), ((V)(30.4)), ((V)(12D)), ((V)(9D)), ((V)("#b8714a"))), Call(patch_41, V.Undef, ((V)((-20D))), ((V)(14D)), ((V)(30.4)), ((V)(10D)), ((V)(8D)), ((V)("#b8714a"))));
} else {
if (SEqS(k_695, "candy")) {
InvokeSpread(o_697, "push", new ArrBuilder().Add(Call(slab_15, V.Undef, ((V)(0D)), ((V)(68D)), ((V)((-27D))), ((V)(82D)), ((V)(30D)), ((V)(8D)), Get(P_692, "b"), NewObj(2).Put("r", ((V)(14D))).Put("soft", ((V)(1D))).V)).Spread(Call(drips_40, V.Undef, ((V)(0D)), ((V)(98D)), ((V)((-23D))), ((V)(70D)), Get(P_692, "bL"), ((V)(5D)))).Add(Call(ball_14, V.Undef, ((V)(0D)), ((V)(96D)), ((V)((-27D))), ((V)(7D)), ((V)("#e2554a")))).V);
} else {
Invoke(o_697, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(68D)), ((V)((-27D))), ((V)(80D)), ((V)((SEqS(k_695, "mod") ? 8D : 22D))), ((V)(6D)), (SEqS(k_695, "royal") ? GOLD_27 : body_698), NewObj(1).Put("r", ((V)(6D))).V));
}
}
Invoke(Arr(((V)((-20D))), ((V)(20D))), "forEach", Fn((V _arrowThis707, int _argc700, V x_706, V _a703, V _a704, V _a705, V[] _rest701) => {
return Invoke(o_697, "push", Call(cyl_13, V.Undef, x_706, ((V)(68D)), ((V)(6D)), ((V)(11D)), ((V)(1D)), ((V)((SEqS(k_695, "mod") ? "#3d3d48" : "#2b211b")))));
}, 1, "", true));
if (Truthy(on_696)) {
Invoke(Arr(((V)((-20D))), ((V)(20D))), "forEach", Fn((V _arrowThis715, int _argc708, V x_714, V _a711, V _a712, V _a713, V[] _rest709) => {
return Invoke(o_697, "push", Call(cyl_13, V.Undef, x_714, ((V)(69D)), ((V)(6D)), ((V)(9.5)), ((V)(0.5)), ((V)("#ff8a3a")), NewObj(1).Put("emit", ((V)(1D))).V));
}, 1, "", true));
}
Invoke(o_697, "push", Call(cyl_13, V.Undef, ((V)((-20D))), ((V)(69.5)), ((V)(6D)), ((V)(13D)), ((V)(18D)), (SEqS(k_695, "junk") ? TIN_32 : ((SEq(Get(P_692, "b"), CR_29) || SEqS(Get(P_692, "b"), "#fffaf1")) ? Get(P_692, "a") : Get(P_692, "b")))), Call(cyl_13, V.Undef, ((V)((-20D))), ((V)(87.5)), ((V)(6D)), ((V)(13D)), ((V)(3D)), Call(shade_23, V.Undef, (SEqS(k_695, "junk") ? TIN_32 : Get(P_692, "b")), ((V)(0.86))), NewObj(1).Put("top", ((V)(5D))).V), Call(cyl_13, V.Undef, ((V)(20D)), ((V)(69.5)), ((V)(6D)), ((V)(12D)), ((V)(4D)), ((V)("#3b3b3b"))), Call(box_11, V.Undef, ((V)(37D)), ((V)(70D)), ((V)(6D)), ((V)(16D)), ((V)(3D)), ((V)(4D)), ((V)("#3b3b3b")), NewObj(1).Put("r", ((V)(1.5))).V));
Invoke(o_697, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(30.5)), ((V)(64D)), ((V)(40D)), ((V)(1.2)), ((V)((SEqS(k_695, "mod") ? "#2b2b33" : "#3b2e28"))), NewObj(1).Put("r", ((V)(5D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(16D)), ((V)(31.4)), ((V)(48D)), ((V)(26D)), ((V)(0.8)), ((V)((Truthy(on_696) ? "#ffb347" : "#5a4a40"))), NewObj(2).Put("r", ((V)(4D))).Put("emit", ((V)((Truthy(on_696) ? 1D : 0D)))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(54D)), ((V)(30.5)), ((V)(58D)), ((V)(3D)), ((V)(1.2)), (SEqS(k_695, "royal") ? GOLD_27 : (SEqS(k_695, "retro") ? CH_28 : ((V)("#cbbca2")))), NewObj(1).Put("r", ((V)(1.5))).V));
Invoke(Arr(((V)((-24D))), ((V)((-8D))), ((V)(8D)), ((V)(24D))), "forEach", Fn((V _arrowThis723, int _argc716, V x_722, V _a719, V _a720, V _a721, V[] _rest717) => {
return Invoke(o_697, "push", Call(knob_43, V.Undef, S_684, x_722, ((V)(58D)), ((V)(30.6)), ((V)(2.6))));
}, 1, "", true));
if (SEqS(k_695, "retro")) {
Invoke(o_697, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(30.6)), ((V)(76D)), ((V)(3D)), ((V)(0.8)), CH_28, NewObj(1).Put("r", ((V)(1D))).V));
}
if (SEqS(k_695, "royal")) {
Invoke(o_697, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(82D)), ((V)(5D)), ((V)(62D)), GOLD_27, NewObj(1).Put("r", ((V)(8D))).V), Call(jewel_42, V.Undef, ((V)(0D)), ((V)(90D)), ((V)((-27D))), ((V)(6D))));
}
return o_697;
return default;
}, 2, "build", true)).V;
}, 1, "stove", true)).Put("counter", Fn((V _arrowThis731, int _argc724, V S_730, V _a727, V _a728, V _a729, V[] _rest725) => {
return NewObj(5).Put("w", ((V)(124D))).Put("d", ((V)(54D))).Put("act", (Truthy(Get(S_730, "sink")) ? ((V)("wash")) : V.Undef)).Put("use", (Truthy(Get(S_730, "sink")) ? NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(54D))).V : V.Undef)).Put("build", Fn((V _arrowThis739, int _argc732, V P_738, V _a735, V _a736, V _a737, V[] _rest733) => {
V k_740 = default;
V o_741 = default;
V body_742 = default;
V top_743 = default;
k_740 = Get(S_730, "k");
o_741 = Arr();
body_742 = (SEqS(k_740, "junk") ? Get(P_738, "a") : (SEqS(k_740, "royal") ? ((V)("#f4f1ea")) : Get(P_738, "a")));
top_743 = (SEqS(k_740, "junk") ? ((V)("#b89a74")) : (SEqS(k_740, "royal") ? ((V)("#f4f1ea")) : (SEqS(k_740, "mod") ? ((V)("#3d4048")) : (SEqS(k_740, "retro") ? Get(P_738, "b") : (SEqS(k_740, "candy") ? Get(P_738, "b") : ((V)("#f4ead8")))))));
if (SEqS(k_740, "mod")) {
Invoke(o_741, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(116D)), ((V)(6D)), ((V)(46D)), DK_31, NewObj(1).Put("r", ((V)(2D))).V));
}
Invoke(o_741, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)((SEqS(k_740, "mod") ? 6D : 0D))), ((V)(0D)), ((V)(120D)), ((V)((SEqS(k_740, "mod") ? 42D : 48D))), ((V)(50D)), body_742, NewObj(1).Put("r", ((V)((SEqS(k_740, "mod") ? 3D : (SEqS(k_740, "candy") ? 12D : 4D))))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(48D)), ((V)(0D)), ((V)(124D)), ((V)(6D)), ((V)(54D)), top_743, NewObj(2).Put("r", ((V)(4D))).Put("bev", ((V)(1.5))).V));
if (SEqS(k_740, "junk")) {
Invoke(o_741, "push", Call(box_11, V.Undef, ((V)((-30D))), ((V)(6D)), ((V)(25D)), ((V)(52D)), ((V)(36D)), ((V)(1.2)), Get(P_738, "aL"), NewObj(1).Put("r", ((V)(4D))).V), Call(box_11, V.Undef, ((V)(32D)), ((V)(6D)), ((V)(34D)), ((V)(50D)), ((V)(36D)), ((V)(2D)), Get(P_738, "aL"), NewObj(2).Put("r", ((V)(4D))).Put("yaw", ((V)((-0.5)))).V), Call(patch_41, V.Undef, ((V)((-36D))), ((V)(30D)), ((V)(25.8)), ((V)(12D)), ((V)(8D)), Get(P_738, "b")), Call(cyl_13, V.Undef, ((V)((-34D))), ((V)(0D)), ((V)(34D)), ((V)(8D)), ((V)(12D)), TIN_32, NewObj(1).Put("n", ((V)(10D))).V));
} else {
if (SEqS(k_740, "mod")) {
Invoke(o_741, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(25.2)), ((V)(1D)), ((V)(20D)), ((V)(0.8)), Call(shade_23, V.Undef, body_742, ((V)(0.8)))), Call(box_11, V.Undef, ((V)((-30D))), ((V)(44D)), ((V)(25.6)), ((V)(30D)), ((V)(2D)), ((V)(1.4)), CH_28), Call(box_11, V.Undef, ((V)(30D)), ((V)(44D)), ((V)(25.6)), ((V)(30D)), ((V)(2D)), ((V)(1.4)), CH_28));
} else {
Invoke(o_741, "push", Call(box_11, V.Undef, ((V)((-30D))), ((V)(6D)), ((V)(25D)), ((V)(52D)), ((V)(36D)), ((V)(1.2)), Get(P_738, "aL"), NewObj(1).Put("r", ((V)(4D))).V), Call(box_11, V.Undef, ((V)(30D)), ((V)(6D)), ((V)(25D)), ((V)(52D)), ((V)(36D)), ((V)(1.2)), Get(P_738, "aL"), NewObj(1).Put("r", ((V)(4D))).V));
Invoke(o_741, "push", Call(knob_43, V.Undef, S_730, ((V)((-6D))), ((V)(28D)), ((V)(26D))), Call(knob_43, V.Undef, S_730, ((V)(6D)), ((V)(28D)), ((V)(26D))));
}
}
if (SEqS(k_740, "retro")) {
Invoke(o_741, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(46D)), ((V)(27.2)), ((V)(124D)), ((V)(2.4)), ((V)(0.8)), CH_28));
}
if (SEqS(k_740, "candy")) {
InvokeSpread(o_741, "push", new ArrBuilder().Spread(Call(drips_40, V.Undef, ((V)(0D)), ((V)(54D)), ((V)(27D)), ((V)(110D)), Get(P_738, "bL"), ((V)(7D)))).V);
}
if (SEqS(k_740, "royal")) {
Invoke(o_741, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(47D)), ((V)(0D)), ((V)(125D)), ((V)(2D)), ((V)(55D)), GOLD_27, NewObj(1).Put("r", ((V)(4D))).V));
}
if (Truthy(Get(S_730, "sink"))) {
Invoke(o_741, "push", Call(cyl_13, V.Undef, ((V)((-14D))), ((V)(54D)), ((V)(0D)), ((V)(22D)), ((V)(0.8)), ((V)("#9aa8ae")), NewObj(2).Put("rz", ((V)(16D))).Put("n", ((V)(14D))).V), Call(cyl_13, V.Undef, ((V)((-14D))), ((V)(54D)), ((V)((-20D))), ((V)(3D)), ((V)(14D)), (SEqS(k_740, "royal") ? GOLD_27 : CH_28), NewObj(1).Put("n", ((V)(8D))).V), Call(box_11, V.Undef, ((V)((-14D))), ((V)(66D)), ((V)((-14D))), ((V)(4D)), ((V)(3D)), ((V)(12D)), (SEqS(k_740, "royal") ? GOLD_27 : CH_28), NewObj(1).Put("r", ((V)(1.5))).V), (SEqS(k_740, "junk") ? Call(cyl_13, V.Undef, ((V)(30D)), ((V)(54D)), ((V)(0D)), ((V)(12D)), ((V)(14D)), TIN_32, NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.85))), Arr(((V)(14D)), ((V)(0D)), ((V)(1D))))).V) : Call(cyl_13, V.Undef, ((V)(32D)), ((V)(54D)), ((V)(2D)), ((V)(7D)), ((V)(10D)), CR_29, NewObj(1).Put("n", ((V)(10D))).V)));
} else {
Invoke(o_741, "push", Call(cyl_13, V.Undef, ((V)((-28D))), ((V)(54D)), ((V)(0D)), ((V)(14D)), ((V)(7D)), CR_29, NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(6D))), Arr(((V)(7D)), ((V)(0D))))).V), Call(ball_14, V.Undef, ((V)((-32D))), ((V)(59D)), ((V)(0D)), ((V)(5D)), ((V)("#ffb347"))), Call(ball_14, V.Undef, ((V)((-24D))), ((V)(59D)), ((V)(3D)), ((V)(5D)), ((V)("#e85a3a"))), Call(cyl_13, V.Undef, ((V)(30D)), ((V)(54D)), ((V)((-8D))), ((V)(6D)), ((V)(14D)), CR_29, NewObj(1).Put("n", ((V)(10D))).V), Call(cyl_13, V.Undef, ((V)(30D)), ((V)(68D)), ((V)((-8D))), ((V)(6D)), ((V)(3D)), (SEqS(k_740, "junk") ? TIN_32 : (SEq(Get(P_738, "b"), CR_29) ? Get(P_738, "a") : Get(P_738, "b"))), NewObj(1).Put("n", ((V)(10D))).V));
}
return o_741;
return default;
}, 1, "build", true)).V;
}, 1, "counter", true)).Put("hutch", Fn((V _arrowThis751, int _argc744, V S_750, V _a747, V _a748, V _a749, V[] _rest745) => {
return NewObj(3).Put("w", ((V)(104D))).Put("d", ((V)(46D))).Put("build", Fn((V _arrowThis759, int _argc752, V P_758, V _a755, V _a756, V _a757, V[] _rest753) => {
V k_760 = default;
V c_761 = default;
V o_762 = default;
k_760 = Get(S_750, "k");
c_761 = (SEqS(k_760, "junk") ? ((V)("#8fa8a0")) : Get(P_758, "w"));
o_762 = Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(104D)), ((V)(54D)), ((V)(46D)), c_761, NewObj(2).Put("r", ((V)(4D))).Put("bev", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(54D)), ((V)(0D)), ((V)(108D)), ((V)(4D)), ((V)(48D)), Call(shade_23, V.Undef, c_761, ((V)(0.9))), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(58D)), ((V)((-16D))), ((V)(96D)), ((V)(74D)), ((V)(6D)), Call(shade_23, V.Undef, c_761, ((V)(0.85)))), Call(box_11, V.Undef, ((V)((-46D))), ((V)(58D)), ((V)((-8D))), ((V)(6D)), ((V)(74D)), ((V)(22D)), c_761), Call(box_11, V.Undef, ((V)(46D)), ((V)(58D)), ((V)((-8D))), ((V)(6D)), ((V)(74D)), ((V)(22D)), c_761), Call(box_11, V.Undef, ((V)(0D)), ((V)(130D)), ((V)((-8D))), ((V)(104D)), ((V)(8D)), ((V)(26D)), c_761, NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(92D)), ((V)((-6D))), ((V)(92D)), ((V)(3D)), ((V)(18D)), c_761));
Invoke(o_762, "push", Call(box_11, V.Undef, ((V)((-25D))), ((V)(6D)), ((V)(23.2)), ((V)(46D)), ((V)(42D)), ((V)(1.2)), Call(mix_22, V.Undef, c_761, ((V)("#ffffff")), ((V)(0.25))), NewObj(1).Put("r", ((V)(4D))).V), Call(box_11, V.Undef, ((V)(25D)), ((V)(6D)), ((V)(23.2)), ((V)(46D)), ((V)(42D)), ((V)(1.2)), Call(mix_22, V.Undef, c_761, ((V)("#ffffff")), ((V)(0.25))), NewObj(1).Put("r", ((V)(4D))).V), Call(knob_43, V.Undef, S_750, ((V)((-5D))), ((V)(28D)), ((V)(24D))), Call(knob_43, V.Undef, S_750, ((V)(5D)), ((V)(28D)), ((V)(24D))));
Invoke(Arr(((V)((-30D))), ((V)((-10D))), ((V)(10D)), ((V)(30D))), "forEach", Fn((V _arrowThis771, int _argc763, V x_769, V i_770, V _a767, V _a768, V[] _rest764) => {
return Invoke(o_762, "push", Call(disc_18, V.Undef, x_769, ((V)(74D)), ((V)((-12D))), ((V)(8D)), ((V)(1.2)), (NumTruthy((ToNum(i_770) % 2D)) ? Get(P_758, "b") : CR_29), NewObj(1).Put("top", ((V)(1D))).V), Call(disc_18, V.Undef, x_769, ((V)(108D)), ((V)((-12D))), ((V)(7D)), ((V)(1.2)), (NumTruthy((ToNum(i_770) % 2D)) ? CR_29 : Get(P_758, "b")), NewObj(1).Put("top", ((V)(1D))).V));
}, 2, "", true));
if (SEqS(k_760, "junk")) {
Invoke(o_762, "push", Call(patch_41, V.Undef, ((V)(30D)), ((V)(30D)), ((V)(24D)), ((V)(10D)), ((V)(8D)), ((V)("#c9a85a"))), Call(box_11, V.Undef, ((V)((-25D))), ((V)(6D)), ((V)(24.4)), ((V)(2D)), ((V)(42D)), ((V)(0.6)), ((V)("#7d6248"))));
}
return o_762;
return default;
}, 1, "build", true)).V;
}, 1, "hutch", true)).Put("table", Fn((V _arrowThis779, int _argc772, V S_778, V _a775, V _a776, V _a777, V[] _rest773) => {
V k_780 = default;
V round_781 = default;
double W_782 = 0;
double D_783 = 0;
k_780 = Get(S_778, "k");
round_781 = ((SEqS(k_780, "retro") || SEqS(k_780, "candy")) ? V.True : V.False);
W_782 = (SEqS(k_780, "royal") ? 160D : 120D);
D_783 = (Truthy(round_781) ? 100D : 76D);
return NewObj(4).Put("w", ((V)(W_782))).Put("d", ((V)(D_783))).Put("round", ((V)((Truthy(round_781) ? 1D : 0D)))).Put("build", Fn((V _arrowThis791, int _argc784, V P_790, V _a787, V _a788, V _a789, V[] _rest785) => {
V o_792 = default;
double h_793 = 0;
o_792 = Arr();
h_793 = 48D;
if (Truthy(round_781)) {
Invoke(o_792, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(26D)), ((V)(4D)), (SEqS(k_780, "retro") ? CH_28 : Get(P_790, "b"))), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(6D)), ((V)((h_793 - 4D))), (SEqS(k_780, "retro") ? CH_28 : Get(P_790, "b")), NewObj(1).Put("n", ((V)(10D))).V));
Invoke(o_792, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(h_793)), ((V)(0D)), ((V)(52D)), ((V)(7D)), (SEqS(k_780, "candy") ? ((V)("#d49a60")) : Get(P_790, "a")), NewObj(3).Put("rz", ((V)(46D))).Put("n", ((V)(20D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(2D))), Arr(((V)(4D)), ((V)(0D))), Arr(((V)(7D)), ((V)(2D))))).V));
if (SEqS(k_780, "retro")) {
Invoke(o_792, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)((h_793 + 6.5))), ((V)(0D)), ((V)(51D)), ((V)(0.6)), Get(P_790, "b"), NewObj(2).Put("rz", ((V)(45D))).Put("n", ((V)(20D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)((h_793 - 0.5))), ((V)(0D)), ((V)(53D)), ((V)(2.4)), CH_28, NewObj(2).Put("rz", ((V)(47D))).Put("n", ((V)(20D))).V), Call(cyl_13, V.Undef, ((V)((-14D))), ((V)((h_793 + 7D))), ((V)(0D)), ((V)(5D)), ((V)(12D)), CR_29, NewObj(1).Put("n", ((V)(10D))).V), Call(cyl_13, V.Undef, ((V)((-14D))), ((V)((h_793 + 19D))), ((V)(0D)), ((V)(1.4)), ((V)(8D)), ((V)("#e2554a")), NewObj(1).Put("n", ((V)(6D))).V), Call(cyl_13, V.Undef, ((V)(14D)), ((V)((h_793 + 7D))), ((V)(6D)), ((V)(10D)), ((V)(2D)), CR_29, NewObj(1).Put("n", ((V)(12D))).V), Call(ball_14, V.Undef, ((V)(14D)), ((V)((h_793 + 9D))), ((V)(6D)), ((V)(6D)), ((V)("#ffb347")), NewObj(1).Put("sy", ((V)(0.5))).V));
} else {
InvokeSpread(o_792, "push", new ArrBuilder().Spread(Invoke(Arr(Arr(((V)((-24D))), ((V)((-10D)))), Arr(((V)(18D)), ((V)(14D))), Arr(((V)(6D)), ((V)((-24D)))), Arr(((V)((-10D))), ((V)(22D))), Arr(((V)(30D)), ((V)((-6D))))), "map", Fn((V _arrowThis805, int _argc794, V _a796, V _a797, V _a798, V _a799, V[] _rest795) => {
V x_802 = default;
V z_804 = default;
{ V _t800 = ListOf(_a796);
{ V _t801 = GetIdx(_t800, 0D);
x_802 = _t801; }
{ V _t803 = GetIdx(_t800, 1D);
z_804 = _t803; }
}
return Call(ball_14, V.Undef, x_802, ((V)((h_793 + 6D))), z_804, ((V)(4D)), ((V)("#6a4020")), NewObj(1).Put("sy", ((V)(0.5))).V);
}, 1, "", true))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)((h_793 + 7D))), ((V)(0D)), ((V)(22D)), ((V)(2D)), Get(P_790, "a"), NewObj(1).Put("n", ((V)(14D))).V)).Spread(Call(spr_39, V.Undef, ((V)(0D)), ((V)((h_793 + 9D))), ((V)(0D)), ((V)(30D)), ((V)(20D)), ((V)(6D)))).V);
}
return o_792;
}
if (SEqS(k_780, "junk")) {
Invoke(Arr(Arr(((V)((-50D))), ((V)((-30D)))), Arr(((V)(50D)), ((V)((-30D)))), Arr(((V)((-50D))), ((V)(30D))), Arr(((V)(50D)), ((V)(30D)))), "forEach", Fn((V _arrowThis817, int _argc806, V _a808, V _a809, V _a810, V _a811, V[] _rest807) => {
V x_814 = default;
V z_816 = default;
{ V _t812 = ListOf(_a808);
{ V _t813 = GetIdx(_t812, 0D);
x_814 = _t813; }
{ V _t815 = GetIdx(_t812, 1D);
z_816 = _t815; }
}
return Invoke(o_792, "push", Call(cyl_13, V.Undef, x_814, ((V)(0D)), z_816, ((V)(1.8)), ((V)(h_793)), ((V)("#8a8f94")), NewObj(1).Put("n", ((V)(6D))).V));
}, 1, "", true));
Invoke(o_792, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(h_793)), ((V)(0D)), ((V)(120D)), ((V)(4D)), ((V)(76D)), ((V)("#c9c1b0")), NewObj(1).Put("r", ((V)(2D))).V), Call(box_11, V.Undef, ((V)((-20D))), ((V)((h_793 + 4D))), ((V)(0D)), ((V)(40D)), ((V)(1D)), ((V)(30D)), ((V)("#e8e4dc")), NewObj(2).Put("r", ((V)(1D))).Put("yaw", ((V)(0.2))).V), Call(cyl_13, V.Undef, ((V)(26D)), ((V)((h_793 + 4D))), ((V)(8D)), ((V)(6D)), ((V)(10D)), TIN_32, NewObj(1).Put("n", ((V)(10D))).V));
return o_792;
}
InvokeSpread(o_792, "push", new ArrBuilder().Spread(Call(legs_38, V.Undef, S_778, P_790, ((V)(((W_782 / 2D) - 10D))), ((V)(28D)), ((V)(h_793)), ((V)(4D)))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(h_793)), ((V)(0D)), ((V)(W_782)), ((V)(6D)), ((V)(76D)), (SEqS(k_780, "royal") ? ((V)("#f4f1ea")) : (SEqS(k_780, "mod") ? ((V)("#cfe8f0")) : Get(P_790, "w"))), NewObj(2).Put("r", ((V)((SEqS(k_780, "mod") ? 4D : 8D)))).Put("bev", ((V)(2D))).V)).V);
if (SEqS(k_780, "cot")) {
InvokeSpread(o_792, "push", new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(0D)), ((V)((h_793 + 6D))), ((V)(0D)), ((V)(88D)), ((V)(0.8)), ((V)(80D)), Get(P_790, "b"), NewObj(1).Put("r", ((V)(2D))).V)).Spread(Invoke(Arr(((V)((-33D))), ((V)((-11D))), ((V)(11D)), ((V)(33D))), "map", Fn((V _arrowThis826, int _argc818, V x_824, V i_825, V _a822, V _a823, V[] _rest819) => {
return Call(box_11, V.Undef, x_824, ((V)((h_793 + 6.8))), ((V)(0D)), ((V)(11D)), ((V)(0.4)), ((V)(80D)), Get(P_790, "a"), NewObj(1).Put("r", ((V)(1D))).V);
}, 2, "", true))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)((h_793 + 7D))), ((V)(0D)), ((V)(7D)), ((V)(14D)), CR_29, NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(8D)), ((V)(0D)), ((V)(1.1))), Arr(((V)(14D)), ((V)(0D)), ((V)(0.6))))).V)).Add(Call(ball_14, V.Undef, ((V)((-3D))), ((V)((h_793 + 21D))), ((V)(0D)), ((V)(4D)), ((V)("#e3946a")))).Add(Call(ball_14, V.Undef, ((V)(4D)), ((V)((h_793 + 22D))), ((V)(2D)), ((V)(4D)), ((V)("#f2c255")))).V);
} else {
if (SEqS(k_780, "mod")) {
Invoke(o_792, "push", Call(cyl_13, V.Undef, ((V)(20D)), ((V)((h_793 + 6D))), ((V)(0D)), ((V)(10D)), ((V)(2D)), ((V)("#e9e5dc")), NewObj(1).Put("n", ((V)(12D))).V), Call(ball_14, V.Undef, ((V)(20D)), ((V)((h_793 + 8D))), ((V)(0D)), ((V)(5D)), ((V)("#9fc684"))), Call(cyl_13, V.Undef, ((V)((-22D))), ((V)((h_793 + 6D))), ((V)((-6D))), ((V)(4D)), ((V)(10D)), ((V)("#c9c9c4")), NewObj(1).Put("n", ((V)(8D))).V));
} else {
Invoke(o_792, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)((h_793 + 6D))), ((V)(0D)), ((V)(150D)), ((V)(1D)), ((V)(60D)), CR_29, NewObj(1).Put("r", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)((h_793 - 2D))), ((V)(0D)), ((V)(162D)), ((V)(3D)), ((V)(78D)), GOLD_27, NewObj(1).Put("r", ((V)(8D))).V));
Invoke(Arr(((V)((-40D))), ((V)(0D)), ((V)(40D))), "forEach", Fn((V _arrowThis835, int _argc827, V x_833, V i_834, V _a831, V _a832, V[] _rest828) => {
if (SEqN(i_834, 1D)) {
InvokeSpread(o_792, "push", new ArrBuilder().Add(Call(cyl_13, V.Undef, x_833, ((V)((h_793 + 7D))), ((V)(0D)), ((V)(5D)), ((V)(20D)), GOLD_27, NewObj(2).Put("n", ((V)(8D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.6))), Arr(((V)(6D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(20D)), ((V)(0D)), ((V)(1D))))).V)).Spread(Call(flame_45, V.Undef, x_833, ((V)((h_793 + 27D))), ((V)(0D)), ((V)(0.8)))).V);
} else {
Invoke(o_792, "push", Call(cyl_13, V.Undef, x_833, ((V)((h_793 + 7D))), ((V)(0D)), ((V)(12D)), ((V)(2D)), WH_30, NewObj(1).Put("n", ((V)(12D))).V), Call(ball_14, V.Undef, x_833, ((V)((h_793 + 9D))), ((V)(0D)), ((V)(6D)), ((V)((LtN(x_833, 0D) ? "#e85a3a" : "#9fc684")))));
}
return default;
}, 2, "", true));
}
}
return o_792;
return default;
}, 1, "build", true)).V;
return default;
}, 1, "table", true)).Put("chair", Fn((V _arrowThis843, int _argc836, V S_842, V _a839, V _a840, V _a841, V[] _rest837) => {
return NewObj(5).Put("w", ((V)(48D))).Put("d", ((V)(48D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(3D))).Put("h", ((V)((SEqS(Get(S_842, "k"), "candy") ? 38D : 40D)))).V)).Put("build", Fn((V _arrowThis851, int _argc844, V P_850, V _a847, V _a848, V _a849, V[] _rest845) => {
V k_852 = default;
V o_853 = default;
V lc_854 = default;
V sc_855 = default;
k_852 = Get(S_842, "k");
o_853 = Arr();
if (SEqS(k_852, "candy")) {
return new ArrBuilder().Add(Call(ball_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(2D)), ((V)(22D)), Get(P_850, "a"), NewObj(3).Put("sy", ((V)(0.8))).Put("k", ((V)(6D))).Put("n", ((V)(16D))).V)).Add(Call(ball_14, V.Undef, ((V)(0D)), ((V)(22D)), ((V)((-18D))), ((V)(18D)), Get(P_850, "b"), NewObj(4).Put("sy", ((V)(1.1))).Put("sz", ((V)(0.5))).Put("k", ((V)(6D))).Put("n", ((V)(16D))).V)).Spread(Call(spr_39, V.Undef, ((V)(0D)), ((V)(34D)), ((V)(6D)), ((V)(22D)), ((V)(16D)), ((V)(5D)))).V;
}
if (SEqS(k_852, "mod")) {
return new ArrBuilder().Spread(Call(legs_38, V.Undef, S_842, P_850, ((V)(17D)), ((V)(17D)), ((V)(26D)), ((V)(3D)))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(2D)), ((V)(46D)), ((V)(8D)), ((V)(44D)), Get(P_850, "a"), NewObj(2).Put("r", ((V)(14D))).Put("bev", ((V)(4D))).V)).Add(Call(slab_15, V.Undef, ((V)(0D)), ((V)(30D)), ((V)((-20D))), ((V)(46D)), ((V)(34D)), ((V)(6D)), Get(P_850, "a"), NewObj(2).Put("r", ((V)(18D))).Put("soft", ((V)(1D))).V)).V;
}
lc_854 = (SEqS(k_852, "retro") ? CH_28 : (SEqS(k_852, "royal") ? GOLD_27 : Get(P_850, "wD")));
sc_855 = (SEqS(k_852, "junk") ? ((V)("#b89a74")) : (SEqS(k_852, "royal") ? ((V)("#f4f1ea")) : Get(P_850, "w")));
InvokeSpread(o_853, "push", new ArrBuilder().Spread(Call(legs_38, V.Undef, S_842, P_850, ((V)(18D)), ((V)(18D)), ((V)(26D)), ((V)(3D)))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(0D)), ((V)(48D)), ((V)(6D)), ((V)(48D)), (SEqS(k_852, "retro") ? CH_28 : sc_855), NewObj(2).Put("r", ((V)(8D))).Put("bev", ((V)(2D))).V)).Add(Call(pillowY_19, V.Undef, ((V)(0D)), ((V)(32D)), ((V)(2D)), ((V)(40D)), ((V)(8D)), ((V)(38D)), (SEqS(k_852, "junk") ? ((V)("#8fa8a0")) : Get(P_850, "a")))).V);
if (SEqS(k_852, "retro")) {
Invoke(o_853, "push", Call(cyl_13, V.Undef, ((V)((-19D))), ((V)(32D)), ((V)((-21D))), ((V)(2.4)), ((V)(30D)), CH_28, NewObj(1).Put("n", ((V)(8D))).V), Call(cyl_13, V.Undef, ((V)(19D)), ((V)(32D)), ((V)((-21D))), ((V)(2.4)), ((V)(30D)), CH_28, NewObj(1).Put("n", ((V)(8D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(50D)), ((V)((-21D))), ((V)(46D)), ((V)(24D)), ((V)(8D)), Get(P_850, "a"), NewObj(2).Put("r", ((V)(12D))).Put("soft", ((V)(1D))).V));
} else {
if (SEqS(k_852, "royal")) {
Invoke(o_853, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(30D)), ((V)((-22D))), ((V)(48D)), ((V)(66D)), ((V)(6D)), Get(P_850, "a"), NewObj(2).Put("r", ((V)(24D))).Put("soft", ((V)(1D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(28D)), ((V)((-25.5))), ((V)(52D)), ((V)(72D)), ((V)(2D)), GOLD_27, NewObj(1).Put("r", ((V)(26D))).V), Call(jewel_42, V.Undef, ((V)(0D)), ((V)(100D)), ((V)((-23D))), ((V)(5D))));
} else {
Invoke(o_853, "push", Call(cyl_13, V.Undef, ((V)((-19D))), ((V)(32D)), ((V)((-21D))), ((V)(3D)), ((V)(40D)), lc_854, NewObj(1).Put("n", ((V)(10D))).V), Call(cyl_13, V.Undef, ((V)(19D)), ((V)(32D)), ((V)((-21D))), ((V)(3D)), ((V)(40D)), lc_854, NewObj(1).Put("n", ((V)(10D))).V));
if (SEqS(k_852, "junk")) {
Invoke(o_853, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(46D)), ((V)((-21D))), ((V)(38D)), ((V)(6D)), ((V)(4D)), OLD2_34, NewObj(1).Put("r", ((V)(3D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(62D)), ((V)((-21D))), ((V)(48D)), ((V)(12D)), ((V)(6D)), OLD_33, NewObj(1).Put("r", ((V)(4D))).V));
} else {
Invoke(o_853, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(46D)), ((V)((-21D))), ((V)(38D)), ((V)(5D)), ((V)(4D)), sc_855, NewObj(1).Put("r", ((V)(3D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(56D)), ((V)((-21D))), ((V)(38D)), ((V)(5D)), ((V)(4D)), sc_855, NewObj(1).Put("r", ((V)(3D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(66D)), ((V)((-21D))), ((V)(48D)), ((V)(12D)), ((V)(6D)), sc_855, NewObj(1).Put("r", ((V)(6D))).V));
}
}
}
return o_853;
return default;
}, 1, "build", true)).V;
}, 1, "chair", true)).Put("stool", Fn((V _arrowThis863, int _argc856, V S_862, V _a859, V _a860, V _a861, V[] _rest857) => {
V k_864 = default;
double h_865 = 0;
k_864 = Get(S_862, "k");
h_865 = (SEqS(k_864, "junk") ? 30D : (SEqS(k_864, "mod") ? 52D : (SEqS(k_864, "royal") ? 34D : 33D)));
return NewObj(6).Put("w", ((V)(40D))).Put("d", ((V)(40D))).Put("round", ((V)((!SEqS(k_864, "junk") ? 1D : 0D)))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(0D))).Put("h", ((V)((h_865 + 8D)))).V)).Put("build", Fn((V _arrowThis873, int _argc866, V P_872, V _a869, V _a870, V _a871, V[] _rest867) => {
if (SEqS(k_864, "junk")) {
return Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(38D)), ((V)(h_865)), ((V)(38D)), Get(P_872, "b"), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(19.3)), ((V)(34D)), ((V)(3D)), ((V)(0.8)), Call(shade_23, V.Undef, Get(P_872, "b"), ((V)(0.7)))), Call(box_11, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(19.3)), ((V)(34D)), ((V)(3D)), ((V)(0.8)), Call(shade_23, V.Undef, Get(P_872, "b"), ((V)(0.7)))), Call(box_11, V.Undef, ((V)(0D)), ((V)(20D)), ((V)(19.3)), ((V)(34D)), ((V)(3D)), ((V)(0.8)), Call(shade_23, V.Undef, Get(P_872, "b"), ((V)(0.7)))), Call(pillowY_19, V.Undef, ((V)(0D)), ((V)(h_865)), ((V)(0D)), ((V)(34D)), ((V)(6D)), ((V)(34D)), Get(P_872, "a")));
}
if ((SEqS(k_864, "retro") || SEqS(k_864, "mod"))) {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(16D)), ((V)(3D)), (SEqS(k_864, "mod") ? DK_31 : CH_28)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(2.6)), ((V)((h_865 - 3D))), (SEqS(k_864, "mod") ? DK_31 : CH_28), NewObj(1).Put("n", ((V)(8D))).V), (SEqS(k_864, "mod") ? Call(cyl_13, V.Undef, ((V)(0D)), ((V)((h_865 * 0.45))), ((V)(0D)), ((V)(12D)), ((V)(1.6)), DK_31, NewObj(1).Put("n", ((V)(12D))).V) : Call(cyl_13, V.Undef, ((V)(0D)), ((V)((h_865 - 4D))), ((V)(0D)), ((V)(18D)), ((V)(3D)), CH_28)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(h_865)), ((V)(0D)), ((V)(19D)), ((V)(9D)), Get(P_872, "a"), NewObj(2).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(5D)), ((V)(0D))), Arr(((V)(9D)), ((V)(4D))))).Put("soft", ((V)(1D))).V));
}
if (SEqS(k_864, "candy")) {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(14D)), ((V)(3D)), Get(P_872, "b")), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(2.6)), ((V)((h_865 - 3D))), WH_30, NewObj(1).Put("n", ((V)(8D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(h_865)), ((V)(0D)), ((V)(20D)), ((V)(8D)), Get(P_872, "a"), NewObj(2).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(5D)), ((V)(0D))), Arr(((V)(8D)), ((V)(5D))))).Put("soft", ((V)(1D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)((h_865 + 8D))), ((V)(0D)), ((V)(12D)), ((V)(0.6)), Get(P_872, "w"), NewObj(1).Put("n", ((V)(12D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)((h_865 + 8.6))), ((V)(0D)), ((V)(5D)), ((V)(0.6)), CR_29, NewObj(1).Put("n", ((V)(10D))).V));
}
return new ArrBuilder().Spread(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis881, int _argc874, V i_880, V _a877, V _a878, V _a879, V[] _rest875) => {
return Call(cyl_13, V.Undef, ((V)((12D * FdLibm.Cos(((ToNum(i_880) * 2.094) + 0.5))))), ((V)(0D)), ((V)((12D * FdLibm.Sin(((ToNum(i_880) * 2.094) + 0.5))))), ((V)(2.6)), ((V)(h_865)), (SEqS(k_864, "royal") ? GOLD_27 : ((V)("#a86b36"))), NewObj(1).Put("n", ((V)(8D))).V);
}, 1, "", true))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(h_865)), ((V)(0D)), ((V)(19D)), ((V)(9D)), Get(P_872, "a"), NewObj(2).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(5D)), ((V)(0D))), Arr(((V)(9D)), ((V)(4D))))).Put("soft", ((V)(1D))).V)).Spread((SEqS(k_864, "royal") ? Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)((h_865 - 1D))), ((V)(0D)), ((V)(20D)), ((V)(2D)), GOLD_27), Call(ball_14, V.Undef, ((V)(0D)), ((V)((h_865 + 8D))), ((V)(0D)), ((V)(2.6)), GOLD_27, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)) : Arr())).V;
return default;
}, 1, "build", true)).V;
return default;
}, 1, "stool", true)).Put("tub", Fn((V _arrowThis889, int _argc882, V S_888, V _a885, V _a886, V _a887, V[] _rest883) => {
V k_890 = default;
V box__891 = default;
k_890 = Get(S_888, "k");
box__891 = ((SEqS(k_890, "retro") || SEqS(k_890, "mod")) ? V.True : V.False);
return NewObj(6).Put("w", ((V)(172D))).Put("d", ((V)(90D))).Put("act", ((V)("bath"))).Put("inside", Arr(((V)(0D)), ((V)(14D)), ((V)(0D)))).Put("seats", Arr(NewObj(4).Put("x", ((V)((-36D)))).Put("z", ((V)(0D))).Put("h", ((V)(14D))).Put("k", ((V)("bath"))).V, NewObj(4).Put("x", ((V)(36D))).Put("z", ((V)(0D))).Put("h", ((V)(14D))).Put("k", ((V)("bath"))).V)).Put("build", Fn((V _arrowThis899, int _argc892, V P_898, V _a895, V _a896, V _a897, V[] _rest893) => {
V o_900 = default;
V sh_901 = default;
V bub_902 = default;
o_900 = Arr();
sh_901 = (SEqS(k_890, "junk") ? TIN_32 : (SEqS(k_890, "royal") ? GOLD_27 : (SEqS(k_890, "cot") ? ((V)("#ffffff")) : Get(P_898, "a"))));
if (SEqS(k_890, "junk")) {
Invoke(o_900, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(74D)), ((V)(4D)), Call(shade_23, V.Undef, TIN_32, ((V)(0.9))), NewObj(2).Put("rz", ((V)(36D))).Put("n", ((V)(20D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(70D)), ((V)(18D)), ((V)("#b9dbe4")), NewObj(3).Put("rz", ((V)(32D))).Put("n", ((V)(20D))).Put("emit", ((V)(1D))).V));
InvokeSpread(o_900, "push", new ArrBuilder().Spread(Call(quarters_21, V.Undef, Fn((V _arrowThis911, int _argc903, V a0_909, V a1_910, V _a907, V _a908, V[] _rest904) => {
return Call(arcW_17, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(78D)), ((V)(40D)), ((V)(6D)), ((V)(30D)), a0_909, a1_910, TIN_32);
}, 2, "", true))).V);
InvokeSpread(o_900, "push", new ArrBuilder().Add(Call(box_11, V.Undef, ((V)((-82D))), ((V)(18D)), ((V)(0D)), ((V)(6D)), ((V)(8D)), ((V)(16D)), ((V)("#8a8f94")), NewObj(1).Put("r", ((V)(2D))).V)).Add(Call(box_11, V.Undef, ((V)(82D)), ((V)(18D)), ((V)(0D)), ((V)(6D)), ((V)(8D)), ((V)(16D)), ((V)("#8a8f94")), NewObj(1).Put("r", ((V)(2D))).V)).Add(Call(patch_41, V.Undef, ((V)((-20D))), ((V)(10D)), ((V)(40.6)), ((V)(12D)), ((V)(8D)), ((V)("#b8714a")))).Spread(Invoke(Arr(Arr(((V)((-30D))), ((V)(6D)), ((V)(6D))), Arr(((V)(20D)), ((V)((-10D))), ((V)(5D))), Arr(((V)(40D)), ((V)(8D)), ((V)(5D)))), "map", Fn((V _arrowThis925, int _argc912, V _a914, V _a915, V _a916, V _a917, V[] _rest913) => {
V x_920 = default;
V z_922 = default;
V r_924 = default;
{ V _t918 = ListOf(_a914);
{ V _t919 = GetIdx(_t918, 0D);
x_920 = _t919; }
{ V _t921 = GetIdx(_t918, 1D);
z_922 = _t921; }
{ V _t923 = GetIdx(_t918, 2D);
r_924 = _t923; }
}
return Call(ball_14, V.Undef, x_920, ((V)(20D)), z_922, r_924, WH_30);
}, 1, "", true))).V);
return o_900;
}
if (Truthy(box__891)) {
double y0_926 = 0;
y0_926 = (SEqS(k_890, "retro") ? 8D : 0D);
if (SEqS(k_890, "retro")) {
InvokeSpread(o_900, "push", new ArrBuilder().Spread(Call(legs_38, V.Undef, S_888, P_898, ((V)(66D)), ((V)(28D)), ((V)(8D)), ((V)(4D)))).V);
}
Invoke(o_900, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(y0_926)), ((V)(0D)), ((V)(166D)), ((V)(6D)), ((V)(84D)), sh_901, NewObj(1).Put("r", ((V)(18D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)((y0_926 + 6D))), ((V)(0D)), ((V)(74D)), ((V)(22D)), ((V)("#a9def0")), NewObj(3).Put("rz", ((V)(32D))).Put("n", ((V)(20D))).Put("emit", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(y0_926)), ((V)((-38D))), ((V)(166D)), ((V)(36D)), ((V)(8D)), sh_901, NewObj(1).Put("r", ((V)(4D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(y0_926)), ((V)(38D)), ((V)(166D)), ((V)(36D)), ((V)(8D)), sh_901, NewObj(1).Put("r", ((V)(4D))).V), Call(box_11, V.Undef, ((V)((-79D))), ((V)(y0_926)), ((V)(0D)), ((V)(8D)), ((V)(36D)), ((V)(68D)), sh_901, NewObj(1).Put("r", ((V)(4D))).V), Call(box_11, V.Undef, ((V)(79D)), ((V)(y0_926)), ((V)(0D)), ((V)(8D)), ((V)(36D)), ((V)(68D)), sh_901, NewObj(1).Put("r", ((V)(4D))).V));
if (SEqS(k_890, "retro")) {
Invoke(o_900, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)((y0_926 + 30D))), ((V)(42.4)), ((V)(160D)), ((V)(3D)), ((V)(0.8)), CH_28));
} else {
Invoke(o_900, "push", Call(box_11, V.Undef, ((V)((-60D))), ((V)((y0_926 + 36D))), ((V)((-36D))), ((V)(30D)), ((V)(4D)), ((V)(12D)), ((V)("#e9e5dc")), NewObj(1).Put("r", ((V)(2D))).V), Call(cyl_13, V.Undef, ((V)((-72D))), ((V)((y0_926 + 36D))), ((V)((-38D))), ((V)(2.4)), ((V)(18D)), CH_28, NewObj(1).Put("n", ((V)(8D))).V), Call(box_11, V.Undef, ((V)((-66D))), ((V)((y0_926 + 52D))), ((V)((-38D))), ((V)(12D)), ((V)(3D)), ((V)(4D)), CH_28, NewObj(1).Put("r", ((V)(1.5))).V));
}
} else {
V ft_927 = default;
ft_927 = (SEqS(k_890, "royal") ? GOLD_27 : (SEqS(k_890, "candy") ? Get(P_898, "b") : ((SEq(Get(P_898, "b"), CR_29) || SEqS(Get(P_898, "b"), "#fffaf1")) ? ((V)("#c9d3d8")) : Get(P_898, "b"))));
InvokeSpread(o_900, "push", new ArrBuilder().Add(Call(ball_14, V.Undef, ((V)((-64D))), ((V)(0D)), ((V)((-26D))), ((V)(5D)), ft_927)).Add(Call(ball_14, V.Undef, ((V)(64D)), ((V)(0D)), ((V)((-26D))), ((V)(5D)), ft_927)).Add(Call(ball_14, V.Undef, ((V)((-64D))), ((V)(0D)), ((V)(26D)), ((V)(5D)), ft_927)).Add(Call(ball_14, V.Undef, ((V)(64D)), ((V)(0D)), ((V)(26D)), ((V)(5D)), ft_927)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(82D)), ((V)(6D)), sh_901, NewObj(2).Put("rz", ((V)(40D))).Put("n", ((V)(20D))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(77D)), ((V)(26D)), ((V)("#a9def0")), NewObj(3).Put("rz", ((V)(35D))).Put("n", ((V)(20D))).Put("emit", ((V)(1D))).V)).Spread(Call(quarters_21, V.Undef, Fn((V _arrowThis936, int _argc928, V a0_934, V a1_935, V _a932, V _a933, V[] _rest929) => {
return Call(arcW_17, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(85D)), ((V)(44D)), ((V)(8D)), ((V)(38D)), a0_934, a1_935, sh_901);
}, 2, "", true))).Add(Call(cyl_13, V.Undef, ((V)((-72D))), ((V)(44D)), ((V)(0D)), ((V)(3D)), ((V)(14D)), (SEqS(k_890, "royal") ? GOLD_27 : ((V)("#c9d3d8"))), NewObj(1).Put("n", ((V)(8D))).V)).Add(Call(box_11, V.Undef, ((V)((-66D))), ((V)(55D)), ((V)(0D)), ((V)(12D)), ((V)(3D)), ((V)(4D)), (SEqS(k_890, "royal") ? GOLD_27 : ((V)("#c9d3d8"))), NewObj(1).Put("r", ((V)(1.5))).V)).V);
if (SEqS(k_890, "royal")) {
Invoke(o_900, "push", Call(jewel_42, V.Undef, ((V)((-72D))), ((V)(58D)), ((V)(0D)), ((V)(4D))), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(43.5)), ((V)(0D)), ((V)(86D)), ((V)(1.5)), ((V)("#fff1a8")), NewObj(2).Put("rz", ((V)(45D))).Put("n", ((V)(20D))).V));
}
}
bub_902 = (SEqS(k_890, "candy") ? Arr(Arr(((V)((-40D))), ((V)(10D)), ((V)(9D))), Arr(((V)((-26D))), ((V)((-14D))), ((V)(8D))), Arr(((V)(30D)), ((V)(12D)), ((V)(10D))), Arr(((V)(46D)), ((V)((-8D))), ((V)(8D))), Arr(((V)(0D)), ((V)(18D)), ((V)(8D))), Arr(((V)((-10D))), ((V)((-20D))), ((V)(7D))), Arr(((V)(58D)), ((V)(12D)), ((V)(7D))), Arr(((V)((-56D))), ((V)((-4D))), ((V)(7D))), Arr(((V)(14D)), ((V)((-4D))), ((V)(9D))), Arr(((V)((-14D))), ((V)(6D)), ((V)(7D)))) : Arr(Arr(((V)((-40D))), ((V)(10D)), ((V)(7D))), Arr(((V)((-28D))), ((V)((-14D))), ((V)(6D))), Arr(((V)(30D)), ((V)(12D)), ((V)(8D))), Arr(((V)(46D)), ((V)((-8D))), ((V)(6D))), Arr(((V)(0D)), ((V)(18D)), ((V)(6D))), Arr(((V)(58D)), ((V)(12D)), ((V)(5D)))));
Invoke(bub_902, "forEach", Fn((V _arrowThis951, int _argc937, V _a939, V i_943, V _a941, V _a942, V[] _rest938) => {
V x_946 = default;
V z_948 = default;
V r_950 = default;
{ V _t944 = ListOf(_a939);
{ V _t945 = GetIdx(_t944, 0D);
x_946 = _t945; }
{ V _t947 = GetIdx(_t944, 1D);
z_948 = _t947; }
{ V _t949 = GetIdx(_t944, 2D);
r_950 = _t949; }
}
return Invoke(o_900, "push", Call(ball_14, V.Undef, x_946, ((V)(29D)), z_948, r_950, (SEqS(k_890, "candy") ? GetIdx(Arr(WH_30, ((V)("#e6ddff")), ((V)("#d8f3ff"))), (ToNum(i_943) % 3D)) : WH_30)));
}, 2, "", true));
return o_900;
return default;
}, 1, "build", true)).V;
return default;
}, 1, "tub", true)).Put("bsink", Fn((V _arrowThis959, int _argc952, V S_958, V _a955, V _a956, V _a957, V[] _rest953) => {
return NewObj(6).Put("w", ((V)(60D))).Put("d", ((V)(50D))).Put("round", ((V)(1D))).Put("act", ((V)("wash"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(44D))).V).Put("build", Fn((V _arrowThis967, int _argc960, V P_966, V _a963, V _a964, V _a965, V[] _rest961) => {
V k_968 = default;
V fc_969 = default;
V pc_970 = default;
k_968 = Get(S_958, "k");
fc_969 = (SEqS(k_968, "royal") ? GOLD_27 : CH_28);
if (SEqS(k_968, "junk")) {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(14D)), ((V)(40D)), TIN_32, NewObj(2).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(40D)), ((V)(0D)), ((V)(1D))))).Put("n", ((V)(12D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(0D)), ((V)(26D)), ((V)(12D)), CR_29, NewObj(2).Put("rz", ((V)(20D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(12D)), ((V)(0D)), ((V)(1D))))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(52D)), ((V)(0D)), ((V)(20D)), ((V)(0.6)), ((V)("#cfe6ee")), NewObj(1).Put("rz", ((V)(14D))).V), Call(patch_41, V.Undef, ((V)(10D)), ((V)(44D)), ((V)(19.6)), ((V)(6D)), ((V)(6D)), ((V)("#a99a84"))), Call(cyl_13, V.Undef, ((V)(16D)), ((V)(52D)), ((V)((-10D))), ((V)(5D)), ((V)(9D)), ((V)("#c9a85a")), NewObj(1).Put("n", ((V)(8D))).V));
}
if (SEqS(k_968, "cot")) {
return new ArrBuilder().Spread(Call(legs_38, V.Undef, S_958, P_966, ((V)(22D)), ((V)(16D)), ((V)(40D)), ((V)(3D)))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(0D)), ((V)(58D)), ((V)(5D)), ((V)(44D)), Get(P_966, "w"), NewObj(2).Put("r", ((V)(6D))).Put("bev", ((V)(1.5))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(45D)), ((V)(0D)), ((V)(20D)), ((V)(9D)), WH_30, NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(9D)), ((V)(0D)), ((V)(1D))))).V)).Add(Call(cyl_13, V.Undef, ((V)(18D)), ((V)(45D)), ((V)((-10D))), ((V)(6D)), ((V)(16D)), Get(P_966, "a"), NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(10D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(16D)), ((V)(0D)), ((V)(0.9))))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(0D)), ((V)(50D)), ((V)(3D)), ((V)(38D)), Get(P_966, "w"), NewObj(1).Put("r", ((V)(2D))).V)).V;
}
if (SEqS(k_968, "mod")) {
return Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(66D)), ((V)(8D)), ((V)(44D)), DK_31, NewObj(1).Put("r", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(0D)), ((V)(66D)), ((V)(34D)), ((V)(44D)), Get(P_966, "w"), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(24D)), ((V)(22.2)), ((V)(60D)), ((V)(1D)), ((V)(0.8)), Call(shade_23, V.Undef, Get(P_966, "w"), ((V)(0.8)))), Call(box_11, V.Undef, ((V)(0D)), ((V)(42D)), ((V)(0D)), ((V)(68D)), ((V)(4D)), ((V)(46D)), ((V)("#e9e5dc")), NewObj(1).Put("r", ((V)(2D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(46D)), ((V)(2D)), ((V)(16D)), ((V)(10D)), WH_30, NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(10D)), ((V)(0D)), ((V)(1D))))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(46D)), ((V)((-16D))), ((V)(2D)), ((V)(20D)), DK_31, NewObj(1).Put("n", ((V)(8D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(64D)), ((V)((-10D))), ((V)(3D)), ((V)(2D)), ((V)(12D)), DK_31, NewObj(1).Put("r", ((V)(1D))).V));
}
if (SEqS(k_968, "candy")) {
return new ArrBuilder().Add(Call(ball_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(18D)), Get(P_966, "b"), NewObj(3).Put("sy", ((V)(1.2))).Put("k", ((V)(6D))).Put("n", ((V)(14D))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(0D)), ((V)(30D)), ((V)(14D)), Get(P_966, "a"), NewObj(2).Put("rz", ((V)(24D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.55))), Arr(((V)(10D)), ((V)(0D)), ((V)(1D))), Arr(((V)(14D)), ((V)(0D)), ((V)(1D))))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(54D)), ((V)(0D)), ((V)(24D)), ((V)(0.6)), ((V)("#cfe6ee")), NewObj(1).Put("rz", ((V)(18D))).V)).Spread(Call(drips_40, V.Undef, ((V)(0D)), ((V)(54D)), ((V)(22D)), ((V)(40D)), Get(P_966, "aL"), ((V)(4D)))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(54D)), ((V)((-17D))), ((V)(3D)), ((V)(12D)), Get(P_966, "w"), NewObj(1).Put("n", ((V)(8D))).V)).Spread(Call(spr_39, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(18D)), ((V)(14D)), ((V)(4D)))).V;
}
pc_970 = (SEqS(k_968, "royal") ? ((V)("#f4f1ea")) : Get(P_966, "a"));
return new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(10D)), ((V)(46D)), pc_970, NewObj(2).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.3))), Arr(((V)(46D)), ((V)(0D)), ((V)(1D))))).Put("n", ((V)(12D))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(44D)), ((V)(0D)), ((V)(30D)), ((V)(14D)), pc_970, NewObj(2).Put("rz", ((V)(24D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.55))), Arr(((V)(10D)), ((V)(0D)), ((V)(1D))), Arr(((V)(14D)), ((V)(0D)), ((V)(1D))))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(58D)), ((V)(0D)), ((V)(24D)), ((V)(0.6)), ((V)("#cfe6ee")), NewObj(1).Put("rz", ((V)(18D))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(58D)), ((V)((-17D))), ((V)(3D)), ((V)(12D)), fc_969, NewObj(1).Put("n", ((V)(8D))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(68D)), ((V)((-12D))), ((V)(4D)), ((V)(3D)), ((V)(10D)), fc_969, NewObj(1).Put("r", ((V)(1.5))).V)).Add(Call(cyl_13, V.Undef, ((V)(18D)), ((V)(58D)), ((V)((-14D))), ((V)(4D)), ((V)(8D)), ((V)((SEqS(k_968, "royal") ? "#8f7bff" : "#f2c255"))), NewObj(1).Put("n", ((V)(8D))).V)).Spread((SEqS(k_968, "royal") ? Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(14D)), ((V)(4D)), GOLD_27), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(56D)), ((V)(0D)), ((V)(31D)), ((V)(2D)), GOLD_27, NewObj(1).Put("rz", ((V)(25D))).V)) : (SEqS(k_968, "retro") ? Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(54D)), ((V)(0D)), ((V)(31D)), ((V)(2D)), CH_28, NewObj(1).Put("rz", ((V)(25D))).V)) : Arr()))).V;
return default;
}, 1, "build", true)).V;
}, 1, "bsink", true)).Put("basket", Fn((V _arrowThis978, int _argc971, V S_977, V _a974, V _a975, V _a976, V[] _rest972) => {
return NewObj(4).Put("w", ((V)(50D))).Put("d", ((V)(50D))).Put("round", ((V)(1D))).Put("build", Fn((V _arrowThis986, int _argc979, V P_985, V _a982, V _a983, V _a984, V[] _rest980) => {
return new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(20D)), ((V)(36D)), (SEqS(Get(S_977, "k"), "junk") ? ((V)("#c4a882")) : Get(P_985, "w")), NewObj(2).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.82))), Arr(((V)(36D)), ((V)(0D)), ((V)(1D))))).Put("n", ((V)(14D))).V)).Spread(Invoke(Arr(((V)(8D)), ((V)(18D)), ((V)(28D))), "map", Fn((V _arrowThis994, int _argc987, V y_993, V _a990, V _a991, V _a992, V[] _rest988) => {
return Call(cyl_13, V.Undef, ((V)(0D)), y_993, ((V)(0D)), ((V)(((20D * (0.82 + ((0.18 * ToNum(y_993)) / 36D))) + 0.4))), ((V)(1.4)), Call(shade_23, V.Undef, (SEqS(Get(S_977, "k"), "junk") ? ((V)("#c4a882")) : Get(P_985, "w")), ((V)(0.8))), NewObj(1).Put("n", ((V)(14D))).V);
}, 1, "", true))).Add(Call(ball_14, V.Undef, ((V)((-6D))), ((V)(32D)), ((V)(2D)), ((V)(9D)), Get(P_985, "a"), NewObj(1).Put("sy", ((V)(0.7))).V)).Add(Call(ball_14, V.Undef, ((V)(6D)), ((V)(33D)), ((V)((-2D))), ((V)(8D)), (SEq(Get(P_985, "b"), CR_29) ? ((V)("#84b6c9")) : Get(P_985, "b")), NewObj(1).Put("sy", ((V)(0.7))).V)).Add(Call(ball_14, V.Undef, ((V)(2D)), ((V)(38D)), ((V)(4D)), ((V)(6D)), CR_29, NewObj(1).Put("sy", ((V)(0.6))).V)).V;
}, 1, "build", true)).V;
}, 1, "basket", true)).Put("rack", Fn((V _arrowThis1002, int _argc995, V S_1001, V _a998, V _a999, V _a1000, V[] _rest996) => {
return NewObj(3).Put("w", ((V)(74D))).Put("d", ((V)(30D))).Put("build", Fn((V _arrowThis1010, int _argc1003, V P_1009, V _a1006, V _a1007, V _a1008, V[] _rest1004) => {
V k_1011 = default;
V pc_1012 = default;
V o_1013 = default;
k_1011 = Get(S_1001, "k");
pc_1012 = (SEqS(k_1011, "junk") ? ((V)("#8a8f94")) : (SEqS(k_1011, "royal") ? GOLD_27 : (SEqS(k_1011, "mod") ? DK_31 : (SEqS(k_1011, "candy") ? WH_30 : (SEqS(k_1011, "retro") ? CH_28 : Get(P_1009, "wD"))))));
o_1013 = Arr(Call(box_11, V.Undef, ((V)((-32D))), ((V)(0D)), ((V)(0D)), ((V)(12D)), ((V)(4D)), ((V)(24D)), pc_1012, NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(32D)), ((V)(0D)), ((V)(0D)), ((V)(12D)), ((V)(4D)), ((V)(24D)), pc_1012, NewObj(1).Put("r", ((V)(3D))).V), Call(cyl_13, V.Undef, ((V)((-32D))), ((V)(4D)), ((V)(0D)), ((V)(2.4)), ((V)(80D)), pc_1012, NewObj(1).Put("n", ((V)(8D))).V), Call(cyl_13, V.Undef, ((V)(32D)), ((V)(4D)), ((V)(0D)), ((V)(2.4)), ((V)(80D)), pc_1012, NewObj(1).Put("n", ((V)(8D))).V));
if (SEqS(k_1011, "mod")) {
Invoke(Arr(((V)(30D)), ((V)(46D)), ((V)(62D))), "forEach", Fn((V _arrowThis1021, int _argc1014, V y_1020, V _a1017, V _a1018, V _a1019, V[] _rest1015) => {
return Invoke(o_1013, "push", Call(slabX_16, V.Undef, ((V)(0D)), y_1020, ((V)(0D)), ((V)(66D)), ((V)(3D)), ((V)(3D)), pc_1012, NewObj(1).Put("r", ((V)(1.5))).V));
}, 1, "", true));
} else {
Invoke(o_1013, "push", Call(slabX_16, V.Undef, ((V)(0D)), ((V)(80D)), ((V)(0D)), ((V)(70D)), ((V)(4D)), ((V)(4D)), pc_1012, NewObj(1).Put("r", ((V)(2D))).V), Call(slabX_16, V.Undef, ((V)(0D)), ((V)(50D)), ((V)(0D)), ((V)(66D)), ((V)(3D)), ((V)(3D)), pc_1012, NewObj(1).Put("r", ((V)(1.5))).V));
}
Invoke(o_1013, "push", Call(slab_15, V.Undef, ((V)((-12D))), ((V)(30D)), ((V)(2D)), ((V)(30D)), ((V)(52D)), ((V)(4D)), (SEqS(k_1011, "candy") ? Get(P_1009, "a") : Get(P_1009, "a")), NewObj(2).Put("r", ((V)(6D))).Put("soft", ((V)(1D))).V), Call(slab_15, V.Undef, ((V)(14D)), ((V)(40D)), ((V)(3D)), ((V)(26D)), ((V)(42D)), ((V)(4D)), (SEqS(k_1011, "junk") ? ((V)("#c9a85a")) : (SEq(Get(P_1009, "b"), CR_29) ? ((V)("#84b6c9")) : Get(P_1009, "b"))), NewObj(2).Put("r", ((V)(6D))).Put("soft", ((V)(1D))).V), Call(box_11, V.Undef, ((V)((-12D))), ((V)(34D)), ((V)(4.2)), ((V)(26D)), ((V)(3D)), ((V)(0.6)), Call(shade_23, V.Undef, Get(P_1009, "a"), ((V)(0.85)))));
if (SEqS(k_1011, "candy")) {
Invoke(o_1013, "push", Call(ball_14, V.Undef, ((V)((-32D))), ((V)(84D)), ((V)(0D)), ((V)(5D)), GetIdx(NE_26, 1D)), Call(ball_14, V.Undef, ((V)(32D)), ((V)(84D)), ((V)(0D)), ((V)(5D)), GetIdx(NE_26, 4D)));
}
if (SEqS(k_1011, "royal")) {
Invoke(o_1013, "push", Call(jewel_42, V.Undef, ((V)((-32D))), ((V)(84D)), ((V)(0D)), ((V)(4D))), Call(jewel_42, V.Undef, ((V)(32D)), ((V)(84D)), ((V)(0D)), ((V)(4D))));
}
return o_1013;
return default;
}, 1, "build", true)).V;
}, 1, "rack", true)).Put("shower", Fn((V _arrowThis1029, int _argc1022, V S_1028, V _a1025, V _a1026, V _a1027, V[] _rest1023) => {
return NewObj(6).Put("w", ((V)(90D))).Put("d", ((V)(86D))).Put("act", ((V)("wash"))).Put("use", NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(6D))).Put("inside", ((V)(1D))).V).Put("inside", Arr(((V)(0D)), ((V)(6D)), ((V)(0D)))).Put("build", Fn((V _arrowThis1037, int _argc1030, V P_1036, V _a1033, V _a1034, V _a1035, V[] _rest1031) => {
V k_1038 = default;
V pc_1039 = default;
V wall_1040 = default;
V o_1041 = default;
k_1038 = Get(S_1028, "k");
pc_1039 = (SEqS(k_1038, "royal") ? GOLD_27 : (SEqS(k_1038, "junk") ? ((V)("#8a8f94")) : (SEqS(k_1038, "mod") ? DK_31 : CH_28)));
wall_1040 = (SEqS(k_1038, "junk") ? ((V)("#e8e1ca")) : (SEqS(k_1038, "royal") ? ((V)("#f4f1ea")) : WH_30));
o_1041 = Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(90D)), ((V)(6D)), ((V)(86D)), (SEqS(k_1038, "candy") ? Get(P_1036, "b") : wall_1040), NewObj(1).Put("r", ((V)(6D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(30D)), ((V)(0.6)), ((V)("#b9dbe4")), NewObj(1).Put("rz", ((V)(28D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(6D)), ((V)((-40D))), ((V)(88D)), ((V)(150D)), ((V)(6D)), wall_1040, NewObj(1).Put("r", ((V)(2D))).V));
{
double y_1042 = 0;
y_1042 = 20D;
while (true) {
if (!((y_1042 < 150D))) break;
Invoke(o_1041, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(y_1042)), ((V)((-36.8))), ((V)(86D)), ((V)(1D)), ((V)(0.6)), (SEqS(k_1038, "candy") ? GetIdx(NE_26, (((double)(ToInt32((y_1042 / 18D)) | ToInt32(0D))) % 6D)) : Call(shade_23, V.Undef, wall_1040, ((V)(0.9))))));
y_1042 = (y_1042 + 18D);
}
}
Invoke(o_1041, "push", Call(cyl_13, V.Undef, ((V)((-28D))), ((V)(6D)), ((V)((-36D))), ((V)(2D)), ((V)(128D)), pc_1039, NewObj(1).Put("n", ((V)(8D))).V), Call(box_11, V.Undef, ((V)((-14D))), ((V)(132D)), ((V)((-34D))), ((V)(30D)), ((V)(3D)), ((V)(3D)), pc_1039, NewObj(1).Put("r", ((V)(1.5))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(124D)), ((V)((-30D))), ((V)((SEqS(k_1038, "mod") ? 14D : 8D))), ((V)(6D)), pc_1039, NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.5))), Arr(((V)(6D)), ((V)(0D)), ((V)(1D))))).V), Call(box_11, V.Undef, ((V)((-28D))), ((V)(64D)), ((V)((-34D))), ((V)(8D)), ((V)(6D)), ((V)(4D)), pc_1039, NewObj(1).Put("r", ((V)(2D))).V));
if (SEqS(k_1038, "mod")) {
Invoke(o_1041, "push", Call(box_11, V.Undef, ((V)(28D)), ((V)(6D)), ((V)(0D)), ((V)(2D)), ((V)(150D)), ((V)(80D)), ((V)("#cfe8f0")), NewObj(1).Put("r", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(41D)), ((V)(56D)), ((V)(150D)), ((V)(2D)), ((V)("#cfe8f0")), NewObj(1).Put("r", ((V)(1D))).V));
} else {
Invoke(o_1041, "push", Call(cyl_13, V.Undef, ((V)((-44D))), ((V)(6D)), ((V)(40D)), ((V)(1.6)), ((V)(152D)), pc_1039, NewObj(1).Put("n", ((V)(6D))).V), Call(cyl_13, V.Undef, ((V)(44D)), ((V)(6D)), ((V)(40D)), ((V)(1.6)), ((V)(152D)), pc_1039, NewObj(1).Put("n", ((V)(6D))).V), Call(slabX_16, V.Undef, ((V)(0D)), ((V)(156D)), ((V)(40D)), ((V)(92D)), ((V)(3D)), ((V)(3D)), pc_1039, NewObj(1).Put("r", ((V)(1.5))).V), Call(slab_15, V.Undef, ((V)((-24D))), ((V)(30D)), ((V)(40D)), ((V)(40D)), ((V)(124D)), ((V)(4D)), (SEqS(k_1038, "junk") ? ((V)("#c9a85a")) : Get(P_1036, "a")), NewObj(2).Put("r", ((V)(6D))).Put("soft", ((V)(1D))).V));
if (SEqS(k_1038, "candy")) {
InvokeSpread(o_1041, "push", new ArrBuilder().Spread(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(4D))), "map", Fn((V _arrowThis1051, int _argc1044, V i_1050, V _a1047, V _a1048, V _a1049, V[] _rest1045) => {
return Call(box_11, V.Undef, ((V)((-24D))), ((V)((50D + (ToNum(i_1050) * 20D)))), ((V)(42.2)), ((V)(40D)), ((V)(8D)), ((V)(0.6)), GetK(NE_26, i_1050), NewObj(1).Put("r", ((V)(2D))).V);
}, 1, "", true))).V);
}
if (SEqS(k_1038, "junk")) {
Invoke(o_1041, "push", Call(patch_41, V.Undef, ((V)((-30D))), ((V)(80D)), ((V)(42.2)), ((V)(12D)), ((V)(10D)), ((V)("#8fa8a0"))));
}
}
if (SEqS(k_1038, "royal")) {
Invoke(o_1041, "push", Call(jewel_42, V.Undef, ((V)(0D)), ((V)(158D)), ((V)((-40D))), ((V)(6D))), Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(92D)), ((V)(3D)), ((V)(88D)), GOLD_27, NewObj(1).Put("r", ((V)(6D))).V));
}
return o_1041;
return default;
}, 1, "build", true)).V;
}, 1, "shower", true)).Put("bed", Fn((V _arrowThis1059, int _argc1052, V S_1058, V _a1055, V _a1056, V _a1057, V[] _rest1053) => {
V k_1060 = default;
k_1060 = Get(S_1058, "k");
return NewObj(5).Put("w", ((V)(140D))).Put("d", ((V)(186D))).Put("act", ((V)("nap"))).Put("seats", Arr(NewObj(4).Put("x", ((V)((-30D)))).Put("z", ((V)((-30D)))).Put("h", ((V)((SEqS(k_1060, "junk") ? 26D : (SEqS(k_1060, "mod") ? 36D : 46D))))).Put("k", ((V)("nap"))).V, NewObj(4).Put("x", ((V)(30D))).Put("z", ((V)((-30D)))).Put("h", ((V)((SEqS(k_1060, "junk") ? 26D : (SEqS(k_1060, "mod") ? 36D : 46D))))).Put("k", ((V)("nap"))).V)).Put("build", Fn((V _arrowThis1068, int _argc1061, V P_1067, V _a1064, V _a1065, V _a1066, V[] _rest1062) => {
V o_1069 = default;
V fr_1070 = default;
V lo_1071 = default;
double y0_1072 = 0;
o_1069 = Arr();
if (SEqS(k_1060, "junk")) {
return Arr(Call(pillowY_19, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(134D)), ((V)(20D)), ((V)(176D)), ((V)("#e8e1ca"))), Call(patch_41, V.Undef, ((V)((-40D))), ((V)(6D)), ((V)(92.2)), ((V)(18D)), ((V)(8D)), ((V)("#c4a882"))), Call(cush_12, V.Undef, ((V)(0D)), ((V)(16D)), ((V)(36D)), ((V)(130D)), ((V)(10D)), ((V)(104D)), Get(P_1067, "a"), NewObj(1).Put("r", ((V)(14D))).V), Call(pillowY_19, V.Undef, ((V)((-26D))), ((V)(20D)), ((V)((-62D))), ((V)(54D)), ((V)(10D)), ((V)(30D)), ((V)("#f1ead6"))), Call(pillowY_19, V.Undef, ((V)(28D)), ((V)(18D)), ((V)((-58D))), ((V)(44D)), ((V)(8D)), ((V)(26D)), Get(P_1067, "b")), Call(box_11, V.Undef, ((V)((-50D))), ((V)(26D)), ((V)(40D)), ((V)(22D)), ((V)(1D)), ((V)(20D)), Get(P_1067, "b"), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(30D)), ((V)(26D)), ((V)(60D)), ((V)(18D)), ((V)(1D)), ((V)(16D)), ((V)("#8fa8a0")), NewObj(1).Put("r", ((V)(3D))).V));
}
fr_1070 = (SEqS(k_1060, "royal") ? ((V)("#f4f1ea")) : (SEqS(k_1060, "retro") ? Get(P_1067, "b") : (SEqS(k_1060, "candy") ? Get(P_1067, "b") : Get(P_1067, "w"))));
lo_1071 = (SEqS(k_1060, "mod") ? V.True : V.False);
if (Truthy(lo_1071)) {
Invoke(o_1069, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(156D)), ((V)(14D)), ((V)(196D)), Get(P_1067, "w"), NewObj(2).Put("r", ((V)(6D))).Put("bev", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(136D)), ((V)(4D)), ((V)(176D)), DK_31, NewObj(1).Put("r", ((V)(4D))).V));
} else {
InvokeSpread(o_1069, "push", new ArrBuilder().Spread(Call(legs_38, V.Undef, S_1058, P_1067, ((V)(62D)), ((V)(84D)), ((V)(6D)), ((V)(4D)))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(4D)), ((V)(136D)), ((V)(18D)), ((V)(172D)), fr_1070, NewObj(2).Put("r", ((V)(10D))).Put("bev", ((V)(3D))).V)).V);
}
y0_1072 = (Truthy(lo_1071) ? 0D : 0D);
Invoke(o_1069, "push", Call(pillowY_19, V.Undef, ((V)(0D)), ((V)(((20D + y0_1072) - (Truthy(lo_1071) ? 6D : 0D)))), ((V)(6D)), ((V)(128D)), ((V)(14D)), ((V)(164D)), WH_30), Call(box_11, V.Undef, ((V)(0D)), ((V)((18D - (Truthy(lo_1071) ? 6D : 0D)))), ((V)(30D)), ((V)(134D)), ((V)(26D)), ((V)(114D)), Get(P_1067, "a"), NewObj(3).Put("r", ((V)(14D))).Put("bev", ((V)(7D))).Put("soft", ((V)(1D))).V), Call(pillowY_19, V.Undef, ((V)(0D)), ((V)((41D - (Truthy(lo_1071) ? 6D : 0D)))), ((V)((-25D))), ((V)(134D)), ((V)(6D)), ((V)(16D)), Call(mix_22, V.Undef, Get(P_1067, "a"), ((V)("#ffffff")), ((V)(0.55)))), Call(pillowY_19, V.Undef, ((V)((-30D))), ((V)((33D - (Truthy(lo_1071) ? 6D : 0D)))), ((V)((-60D))), ((V)(50D)), ((V)(12D)), ((V)(28D)), WH_30), Call(pillowY_19, V.Undef, ((V)(30D)), ((V)((33D - (Truthy(lo_1071) ? 6D : 0D)))), ((V)((-60D))), ((V)(50D)), ((V)(12D)), ((V)(28D)), WH_30));
if (SEqS(k_1060, "cot")) {
Invoke(Arr(Arr(((V)((-44D))), ((V)(10D))), Arr(((V)(0D)), ((V)(40D))), Arr(((V)(44D)), ((V)(10D))), Arr(((V)((-22D))), ((V)(70D))), Arr(((V)(22D)), ((V)(70D))), Arr(((V)((-44D))), ((V)(60D))), Arr(((V)(44D)), ((V)(50D)))), "forEach", Fn((V _arrowThis1085, int _argc1073, V _a1075, V i_1079, V _a1077, V _a1078, V[] _rest1074) => {
V x_1082 = default;
V z_1084 = default;
{ V _t1080 = ListOf(_a1075);
{ V _t1081 = GetIdx(_t1080, 0D);
x_1082 = _t1081; }
{ V _t1083 = GetIdx(_t1080, 1D);
z_1084 = _t1083; }
}
return Invoke(o_1069, "push", Call(box_11, V.Undef, x_1082, ((V)(44.2)), z_1084, ((V)(26D)), ((V)(0.6)), ((V)(22D)), GetIdx(Arr(Get(P_1067, "b"), ((V)("#f2c255")), ((V)("#84b6c9")), ((V)("#e3946a"))), (ToNum(i_1079) % 4D)), NewObj(1).Put("r", ((V)(2D))).V));
}, 2, "", true));
}
if (SEqS(k_1060, "candy")) {
Invoke(Arr(((V)((-50D))), ((V)((-25D))), ((V)(0D)), ((V)(25D)), ((V)(50D))), "forEach", Fn((V _arrowThis1094, int _argc1086, V x_1092, V i_1093, V _a1090, V _a1091, V[] _rest1087) => {
return Invoke(o_1069, "push", Call(ball_14, V.Undef, x_1092, ((V)(20D)), ((V)((-92D))), ((V)((20D - (System.Math.Abs((ToNum(i_1093) - 2D)) * 2D)))), ((V)("#fffdf5")), NewObj(1).Put("sz", ((V)(0.6))).V));
}, 2, "", true));
InvokeSpread(o_1069, "push", new ArrBuilder().Spread(Call(spr_39, V.Undef, ((V)(0D)), ((V)(44D)), ((V)(30D)), ((V)(110D)), ((V)(90D)), ((V)(12D)))).V);
} else {
if (SEqS(k_1060, "royal")) {
Invoke(o_1069, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(6D)), ((V)((-91D))), ((V)(140D)), ((V)(76D)), ((V)(10D)), Get(P_1067, "a"), NewObj(2).Put("r", ((V)(40D))).Put("soft", ((V)(1D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(4D)), ((V)((-96.5))), ((V)(146D)), ((V)(82D)), ((V)(2D)), GOLD_27, NewObj(1).Put("r", ((V)(42D))).V), Call(jewel_42, V.Undef, ((V)(0D)), ((V)(86D)), ((V)((-93D))), ((V)(7D))));
Invoke(Arr(Arr(((V)((-68D))), ((V)((-88D)))), Arr(((V)(68D)), ((V)((-88D)))), Arr(((V)((-68D))), ((V)(88D))), Arr(((V)(68D)), ((V)(88D)))), "forEach", Fn((V _arrowThis1106, int _argc1095, V _a1097, V _a1098, V _a1099, V _a1100, V[] _rest1096) => {
V x_1103 = default;
V z_1105 = default;
{ V _t1101 = ListOf(_a1097);
{ V _t1102 = GetIdx(_t1101, 0D);
x_1103 = _t1102; }
{ V _t1104 = GetIdx(_t1101, 1D);
z_1105 = _t1104; }
}
return Invoke(o_1069, "push", Call(cyl_13, V.Undef, x_1103, ((V)(0D)), z_1105, ((V)(4D)), ((V)(168D)), GOLD_27, NewObj(1).Put("n", ((V)(10D))).V), Call(jewel_42, V.Undef, x_1103, ((V)(196D)), z_1105, ((V)(4D))));
}, 1, "", true));
InvokeSpread(o_1069, "push", new ArrBuilder().Add(Call(slabX_16, V.Undef, ((V)(0D)), ((V)(166D)), ((V)((-88D))), ((V)(140D)), ((V)(5D)), ((V)(5D)), GOLD_27, NewObj(1).Put("r", ((V)(2D))).V)).Add(Call(slabX_16, V.Undef, ((V)(0D)), ((V)(166D)), ((V)(88D)), ((V)(140D)), ((V)(5D)), ((V)(5D)), GOLD_27, NewObj(1).Put("r", ((V)(2D))).V)).Add(Call(box_11, V.Undef, ((V)((-68D))), ((V)(166D)), ((V)(0D)), ((V)(5D)), ((V)(5D)), ((V)(176D)), GOLD_27, NewObj(1).Put("r", ((V)(2D))).V)).Add(Call(box_11, V.Undef, ((V)(68D)), ((V)(166D)), ((V)(0D)), ((V)(5D)), ((V)(5D)), ((V)(176D)), GOLD_27, NewObj(1).Put("r", ((V)(2D))).V)).Add(Call(slab_15, V.Undef, ((V)(0D)), ((V)(140D)), ((V)((-88D))), ((V)(136D)), ((V)(28D)), ((V)(4D)), Get(P_1067, "a"), NewObj(2).Put("r", ((V)(10D))).Put("soft", ((V)(1D))).V)).Add(Call(slab_15, V.Undef, ((V)((-64D))), ((V)(40D)), ((V)((-84D))), ((V)(18D)), ((V)(126D)), ((V)(4D)), Get(P_1067, "a"), NewObj(2).Put("r", ((V)(8D))).Put("soft", ((V)(1D))).V)).Add(Call(slab_15, V.Undef, ((V)(64D)), ((V)(40D)), ((V)((-84D))), ((V)(18D)), ((V)(126D)), ((V)(4D)), Get(P_1067, "a"), NewObj(2).Put("r", ((V)(8D))).Put("soft", ((V)(1D))).V)).Spread(Invoke(Arr(((V)((-48D))), ((V)((-16D))), ((V)(16D)), ((V)(48D))), "map", Fn((V _arrowThis1114, int _argc1107, V x_1113, V _a1110, V _a1111, V _a1112, V[] _rest1108) => {
return Call(ball_14, V.Undef, x_1113, ((V)(140D)), ((V)((-85D))), ((V)(3D)), GOLD_27, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V);
}, 1, "", true))).V);
} else {
if (SEqS(k_1060, "retro")) {
Invoke(o_1069, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(6D)), ((V)((-91D))), ((V)(140D)), ((V)(70D)), ((V)(12D)), Get(P_1067, "a"), NewObj(2).Put("r", ((V)(46D))).Put("soft", ((V)(1D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(50D)), ((V)((-84.6))), ((V)(110D)), ((V)(4D)), ((V)(1D)), CH_28, NewObj(1).Put("r", ((V)(2D))).V));
} else {
if (Truthy(lo_1071)) {
Invoke(o_1069, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-96D))), ((V)(156D)), ((V)(48D)), ((V)(8D)), Get(P_1067, "w"), NewObj(1).Put("r", ((V)(4D))).V), Call(box_11, V.Undef, ((V)((-84D))), ((V)(0D)), ((V)((-60D))), ((V)(30D)), ((V)(30D)), ((V)(40D)), Get(P_1067, "w"), NewObj(1).Put("r", ((V)(3D))).V));
} else {
Invoke(o_1069, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(6D)), ((V)((-91D))), ((V)(136D)), ((V)(60D)), ((V)(10D)), Get(P_1067, "w"), NewObj(2).Put("r", ((V)(30D))).Put("soft", ((V)(1D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(26D)), ((V)((-85.6))), ((V)(106D)), ((V)(32D)), ((V)(1.4)), Get(P_1067, "wL"), NewObj(1).Put("r", ((V)(16D))).V), Call(cyl_13, V.Undef, ((V)((-70D))), ((V)(0D)), ((V)((-90D))), ((V)(6D)), ((V)(72D)), Get(P_1067, "wD"), NewObj(1).Put("n", ((V)(12D))).V), Call(cyl_13, V.Undef, ((V)(70D)), ((V)(0D)), ((V)((-90D))), ((V)(6D)), ((V)(72D)), Get(P_1067, "wD"), NewObj(1).Put("n", ((V)(12D))).V), Call(ball_14, V.Undef, ((V)((-70D))), ((V)(72D)), ((V)((-90D))), ((V)(7D)), Get(P_1067, "wD")), Call(ball_14, V.Undef, ((V)(70D)), ((V)(72D)), ((V)((-90D))), ((V)(7D)), Get(P_1067, "wD")));
}
}
}
}
if ((!(Truthy(lo_1071)) && !SEqS(k_1060, "royal"))) {
Invoke(o_1069, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(90D)), ((V)(140D)), ((V)(30D)), ((V)(8D)), fr_1070, NewObj(2).Put("r", ((V)(10D))).Put("soft", ((V)(1D))).V));
}
return o_1069;
return default;
}, 1, "build", true)).V;
return default;
}, 1, "bed", true)).Put("nightstand", Fn((V _arrowThis1122, int _argc1115, V S_1121, V _a1118, V _a1119, V _a1120, V[] _rest1116) => {
return NewObj(5).Put("w", ((V)(48D))).Put("d", ((V)(42D))).Put("act", ((V)("lights"))).Put("glow", Fn((V _arrowThis1130, int _argc1123, V v_1129, V _a1126, V _a1127, V _a1128, V[] _rest1124) => {
return (SEqS(v_1129, "on") ? NewObj(2).Put("y", ((V)(72D))).Put("r", ((V)(70D))).V : V.Null);
}, 1, "glow", true)).Put("build", Fn((V _arrowThis1139, int _argc1131, V P_1137, V v_1138, V _a1135, V _a1136, V[] _rest1132) => {
V k_1140 = default;
V on_1141 = default;
V o_1142 = default;
V c_1143 = default;
double lg_1144 = 0;
double y0_1145 = 0;
double ty_1146 = 0;
k_1140 = Get(S_1121, "k");
on_1141 = (SEqS(v_1138, "on") ? V.True : V.False);
o_1142 = Arr();
if (SEqS(k_1140, "junk")) {
InvokeSpread(o_1142, "push", new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-19D))), ((V)(46D)), ((V)(46D)), ((V)(4D)), Call(shade_23, V.Undef, OLD_33, ((V)(0.85))))).Add(Call(box_11, V.Undef, ((V)((-21D))), ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(46D)), ((V)(40D)), OLD_33)).Add(Call(box_11, V.Undef, ((V)(21D)), ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(46D)), ((V)(40D)), OLD_33)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(46D)), ((V)(4D)), ((V)(40D)), OLD_33)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(42D)), ((V)(0D)), ((V)(46D)), ((V)(4D)), ((V)(40D)), OLD_33)).Spread(Call(book_44, V.Undef, ((V)((-2D))), ((V)(4D)), ((V)((-2D))), Arr(((V)("#8fa8a0")), ((V)("#c9a85a"))))).Add(Call(cyl_13, V.Undef, ((V)((-6D))), ((V)(46D)), ((V)(0D)), ((V)(9D)), ((V)(2D)), TIN_32, NewObj(1).Put("n", ((V)(10D))).V)).Add(Call(cyl_13, V.Undef, ((V)((-6D))), ((V)(48D)), ((V)(0D)), ((V)(4D)), ((V)(12D)), CR_29, NewObj(1).Put("n", ((V)(10D))).V)).V);
if (Truthy(on_1141)) {
InvokeSpread(o_1142, "push", new ArrBuilder().Spread(Call(flame_45, V.Undef, ((V)((-6D))), ((V)(60D)), ((V)(0D)))).V);
}
return o_1142;
}
c_1143 = (SEqS(k_1140, "royal") ? ((V)("#f4f1ea")) : (SEqS(k_1140, "candy") ? Get(P_1137, "a") : Get(P_1137, "w")));
lg_1144 = (((!SEqS(k_1140, "cot") && !SEqS(k_1140, "royal")) && !SEqS(k_1140, "mod")) ? 0D : 8D);
y0_1145 = (SEqS(k_1140, "mod") ? 14D : lg_1144);
if (SEqS(k_1140, "mod")) {
Invoke(o_1142, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(2D)), ((V)(14D)), DK_31, NewObj(1).Put("n", ((V)(6D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(14D)), ((V)(2D)), DK_31));
} else {
if (NumTruthy(lg_1144)) {
InvokeSpread(o_1142, "push", new ArrBuilder().Spread(Call(legs_38, V.Undef, S_1121, P_1137, ((V)(18D)), ((V)(14D)), ((V)(lg_1144)), ((V)(3D)))).V);
}
}
Invoke(o_1142, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(y0_1145)), ((V)(0D)), ((V)(48D)), ((V)((SEqS(k_1140, "mod") ? 32D : 40D))), ((V)(42D)), c_1143, NewObj(2).Put("r", ((V)((SEqS(k_1140, "candy") ? 12D : 5D)))).Put("bev", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)((y0_1145 + 20D))), ((V)(21D)), ((V)(40D)), ((V)((SEqS(k_1140, "mod") ? 8D : 14D))), ((V)(1.2)), Call(mix_22, V.Undef, c_1143, ((V)("#ffffff")), ((V)(0.3))), NewObj(1).Put("r", ((V)(3D))).V), Call(knob_43, V.Undef, S_1121, ((V)(0D)), ((V)((y0_1145 + 25D))), ((V)(21.8))));
if (!SEqS(k_1140, "mod")) {
Invoke(o_1142, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)((y0_1145 + 4D))), ((V)(21D)), ((V)(40D)), ((V)(14D)), ((V)(1.2)), Call(mix_22, V.Undef, c_1143, ((V)("#ffffff")), ((V)(0.3))), NewObj(1).Put("r", ((V)(3D))).V), Call(knob_43, V.Undef, S_1121, ((V)(0D)), ((V)((y0_1145 + 9D))), ((V)(21.8))));
}
ty_1146 = (y0_1145 + (SEqS(k_1140, "mod") ? 32D : 40D));
if (SEqS(k_1140, "candy")) {
InvokeSpread(o_1142, "push", new ArrBuilder().Spread(Call(drips_40, V.Undef, ((V)(0D)), ((V)(ty_1146)), ((V)(21D)), ((V)(40D)), Get(P_1137, "b"), ((V)(4D)))).Add(Call(ball_14, V.Undef, ((V)((-6D))), ((V)(ty_1146)), ((V)((-4D))), ((V)(10D)), Get(P_1137, "b"), NewObj(1).Put("sy", ((V)(0.6))).V)).Add(Call(ball_14, V.Undef, ((V)((-6D))), ((V)((ty_1146 + 10D))), ((V)((-4D))), ((V)(4D)), ((V)("#e2554a")))).V);
}
if (SEqS(k_1140, "royal")) {
InvokeSpread(o_1142, "push", new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(0D)), ((V)((ty_1146 - 2D))), ((V)(0D)), ((V)(50D)), ((V)(3D)), ((V)(44D)), GOLD_27, NewObj(1).Put("r", ((V)(5D))).V)).Add(Call(cyl_13, V.Undef, ((V)((-6D))), ((V)(ty_1146)), ((V)((-4D))), ((V)(7D)), ((V)(3D)), GOLD_27)).Add(Call(cyl_13, V.Undef, ((V)((-6D))), ((V)((ty_1146 + 3D))), ((V)((-4D))), ((V)(2D)), ((V)(10D)), GOLD_27, NewObj(1).Put("n", ((V)(8D))).V)).Add(Call(cyl_13, V.Undef, ((V)((-6D))), ((V)((ty_1146 + 13D))), ((V)((-4D))), ((V)(3D)), ((V)(10D)), CR_29, NewObj(1).Put("n", ((V)(8D))).V)).Spread((Truthy(on_1141) ? Call(flame_45, V.Undef, ((V)((-6D))), ((V)((ty_1146 + 23D))), ((V)((-4D)))) : Arr())).V);
} else {
if (!SEqS(k_1140, "candy")) {
Invoke(o_1142, "push", Call(cyl_13, V.Undef, ((V)((-6D))), ((V)(ty_1146)), ((V)((-4D))), ((V)(8D)), ((V)(3D)), (SEqS(k_1140, "retro") ? CH_28 : Get(P_1137, "b"))), Call(cyl_13, V.Undef, ((V)((-6D))), ((V)((ty_1146 + 3D))), ((V)((-4D))), ((V)(2D)), ((V)(14D)), (SEqS(k_1140, "retro") ? CH_28 : Get(P_1137, "wD")), NewObj(1).Put("n", ((V)(8D))).V), Call(cyl_13, V.Undef, ((V)((-6D))), ((V)((ty_1146 + 14D))), ((V)((-4D))), ((V)((SEqS(k_1140, "retro") ? 10D : 14D))), ((V)(16D)), (Truthy(on_1141) ? ((V)("#fff1a8")) : (SEqS(k_1140, "retro") ? Get(P_1137, "a") : ((V)("#fff4cc")))), (SEqS(k_1140, "retro") ? NewObj(2).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(8D)), ((V)(0D)), ((V)(1D))), Arr(((V)(16D)), ((V)(0D)), ((V)(0.7))))).Put("emit", on_1141).V : NewObj(2).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(16D)), ((V)(5D))))).Put("emit", on_1141).V)));
} else {
if (Truthy(on_1141)) {
Invoke(o_1142, "push", Call(ball_14, V.Undef, ((V)((-6D))), ((V)((ty_1146 + 6D))), ((V)((-4D))), ((V)(6D)), ((V)("#fff1a8")), NewObj(1).Put("emit", ((V)(1D))).V));
}
}
}
return o_1142;
return default;
}, 2, "build", true)).V;
}, 1, "nightstand", true)).Put("wardrobe", Fn((V _arrowThis1154, int _argc1147, V S_1153, V _a1150, V _a1151, V _a1152, V[] _rest1148) => {
return NewObj(3).Put("w", ((V)(106D))).Put("d", ((V)(54D))).Put("build", Fn((V _arrowThis1162, int _argc1155, V P_1161, V _a1158, V _a1159, V _a1160, V[] _rest1156) => {
V k_1163 = default;
V o_1164 = default;
V c_1165 = default;
V dL_1166 = default;
double y0_1167 = 0;
k_1163 = Get(S_1153, "k");
o_1164 = Arr();
c_1165 = (SEqS(k_1163, "junk") ? OLD2_34 : (SEqS(k_1163, "royal") ? ((V)("#f4f1ea")) : ((SEqS(k_1163, "candy") || SEqS(k_1163, "retro")) ? Get(P_1161, "a") : Get(P_1161, "w"))));
dL_1166 = Call(mix_22, V.Undef, c_1165, ((V)("#ffffff")), ((V)(0.25)));
if (SEqS(k_1163, "mod")) {
Invoke(o_1164, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(104D)), ((V)(156D)), ((V)(52D)), c_1165, NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)((-24D))), ((V)(6D)), ((V)(26.6)), ((V)(52D)), ((V)(146D)), ((V)(1.2)), dL_1166, NewObj(1).Put("r", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(24D)), ((V)(6D)), ((V)(27.8)), ((V)(52D)), ((V)(146D)), ((V)(1.2)), Call(mix_22, V.Undef, c_1165, ((V)("#ffffff")), ((V)(0.1))), NewObj(1).Put("r", ((V)(2D))).V), Call(box_11, V.Undef, ((V)((-4D))), ((V)(60D)), ((V)(27.6)), ((V)(2D)), ((V)(40D)), ((V)(1.4)), DK_31), Call(box_11, V.Undef, ((V)(4D)), ((V)(60D)), ((V)(28.8)), ((V)(2D)), ((V)(40D)), ((V)(1.4)), DK_31));
return o_1164;
}
if (!SEqS(k_1163, "junk")) {
InvokeSpread(o_1164, "push", new ArrBuilder().Spread(Call(legs_38, V.Undef, S_1153, P_1161, ((V)(42D)), ((V)(18D)), ((V)(6D)), ((V)(3D)))).V);
}
y0_1167 = (SEqS(k_1163, "junk") ? 0D : 6D);
Invoke(o_1164, "push", ((SEqS(k_1163, "candy") || SEqS(k_1163, "retro")) ? Call(slab_15, V.Undef, ((V)(0D)), ((V)(y0_1167)), ((V)(0D)), ((V)(100D)), ((V)(152D)), ((V)(50D)), c_1165, NewObj(2).Put("r", ((V)(40D))).Put("rb", ((V)(6D))).V) : Call(box_11, V.Undef, ((V)(0D)), ((V)(y0_1167)), ((V)(0D)), ((V)(100D)), ((V)(152D)), ((V)(50D)), c_1165, NewObj(2).Put("r", ((V)(6D))).Put("bev", ((V)(3D))).V)));
if (SEqS(k_1163, "junk")) {
Invoke(o_1164, "push", Call(box_11, V.Undef, ((V)((-25D))), ((V)(8D)), ((V)(25.3)), ((V)(46D)), ((V)(136D)), ((V)(1.2)), dL_1166, NewObj(1).Put("r", ((V)(4D))).V), Call(box_11, V.Undef, ((V)(30D)), ((V)(8D)), ((V)(34D)), ((V)(44D)), ((V)(136D)), ((V)(2D)), dL_1166, NewObj(2).Put("r", ((V)(4D))).Put("yaw", ((V)((-0.45)))).V), Call(patch_41, V.Undef, ((V)((-30D))), ((V)(100D)), ((V)(26.2)), ((V)(14D)), ((V)(12D)), ((V)("#8fa8a0"))), Call(patch_41, V.Undef, ((V)((-20D))), ((V)(30D)), ((V)(26.2)), ((V)(10D)), ((V)(10D)), ((V)("#c9a85a"))), Call(ball_14, V.Undef, ((V)((-5D))), ((V)(76D)), ((V)(26D)), ((V)(2.6)), ((V)("#8a8f94")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(152D)), ((V)(0D)), ((V)(104D)), ((V)(6D)), ((V)(54D)), Call(shade_23, V.Undef, c_1165, ((V)(0.85))), NewObj(1).Put("r", ((V)(3D))).V));
} else {
Invoke(o_1164, "push", Call(box_11, V.Undef, ((V)((-25D))), ((V)((y0_1167 + 8D))), ((V)(25.3)), ((V)(46D)), ((V)(((SEqS(k_1163, "candy") || SEqS(k_1163, "retro")) ? 116D : 136D))), ((V)(1.2)), dL_1166, NewObj(1).Put("r", ((V)((SEqS(k_1163, "candy") ? 16D : 4D)))).V), Call(box_11, V.Undef, ((V)(25D)), ((V)((y0_1167 + 8D))), ((V)(25.3)), ((V)(46D)), ((V)(((SEqS(k_1163, "candy") || SEqS(k_1163, "retro")) ? 116D : 136D))), ((V)(1.2)), dL_1166, NewObj(1).Put("r", ((V)((SEqS(k_1163, "candy") ? 16D : 4D)))).V), Call(knob_43, V.Undef, S_1153, ((V)((-5D))), ((V)((y0_1167 + 74D))), ((V)(26D)), ((V)(2.8))), Call(knob_43, V.Undef, S_1153, ((V)(5D)), ((V)((y0_1167 + 74D))), ((V)(26D)), ((V)(2.8))));
if ((!SEqS(k_1163, "candy") && !SEqS(k_1163, "retro"))) {
Invoke(o_1164, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)((y0_1167 + 152D))), ((V)(0D)), ((V)(106D)), ((V)(8D)), ((V)(54D)), (SEqS(k_1163, "royal") ? GOLD_27 : Call(shade_23, V.Undef, c_1165, ((V)(0.85)))), NewObj(1).Put("r", ((V)(4D))).V));
}
}
if (SEqS(k_1163, "candy")) {
InvokeSpread(o_1164, "push", new ArrBuilder().Spread(Call(drips_40, V.Undef, ((V)(0D)), ((V)((y0_1167 + 150D))), ((V)(22D)), ((V)(80D)), Get(P_1161, "b"), ((V)(6D)))).Spread(Call(spr_39, V.Undef, ((V)(0D)), ((V)((y0_1167 + 154D))), ((V)(0D)), ((V)(50D)), ((V)(30D)), ((V)(6D)))).V);
}
if (SEqS(k_1163, "royal")) {
Invoke(o_1164, "push", Call(jewel_42, V.Undef, ((V)(0D)), ((V)((y0_1167 + 160D))), ((V)(0D)), ((V)(8D))), Call(jewel_42, V.Undef, ((V)((-48D))), ((V)((y0_1167 + 160D))), ((V)(0D)), ((V)(4D))), Call(jewel_42, V.Undef, ((V)(48D)), ((V)((y0_1167 + 160D))), ((V)(0D)), ((V)(4D))), Call(box_11, V.Undef, ((V)((-25D))), ((V)((y0_1167 + 70D))), ((V)(26D)), ((V)(30D)), ((V)(30D)), ((V)(0.6)), GOLD_27, NewObj(1).Put("r", ((V)(12D))).V), Call(box_11, V.Undef, ((V)(25D)), ((V)((y0_1167 + 70D))), ((V)(26D)), ((V)(30D)), ((V)(30D)), ((V)(0.6)), GOLD_27, NewObj(1).Put("r", ((V)(12D))).V));
}
if (SEqS(k_1163, "retro")) {
Invoke(o_1164, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)((y0_1167 + 20D))), ((V)(25.4)), ((V)(96D)), ((V)(3D)), ((V)(0.8)), CH_28));
}
return o_1164;
return default;
}, 1, "build", true)).V;
}, 1, "wardrobe", true)).Put("dresser", Fn((V _arrowThis1175, int _argc1168, V S_1174, V _a1171, V _a1172, V _a1173, V[] _rest1169) => {
return NewObj(3).Put("w", ((V)(104D))).Put("d", ((V)(46D))).Put("build", Fn((V _arrowThis1183, int _argc1176, V P_1182, V _a1179, V _a1180, V _a1181, V[] _rest1177) => {
V k_1184 = default;
V c_1185 = default;
V low_1186 = default;
double H_1187 = 0;
V o_1188 = default;
double y0_1189 = 0;
double n_1190 = 0;
double ty_1191 = 0;
k_1184 = Get(S_1174, "k");
c_1185 = (SEqS(k_1184, "royal") ? ((V)("#f4f1ea")) : (SEqS(k_1184, "candy") ? Get(P_1182, "a") : Get(P_1182, "w")));
low_1186 = (SEqS(k_1184, "mod") ? V.True : V.False);
H_1187 = (Truthy(low_1186) ? 40D : 60D);
o_1188 = Arr();
if (!(Truthy(low_1186))) {
InvokeSpread(o_1188, "push", new ArrBuilder().Spread(Call(legs_38, V.Undef, S_1174, P_1182, ((V)(44D)), ((V)(16D)), ((V)(6D)), ((V)(3D)))).V);
} else {
InvokeSpread(o_1188, "push", new ArrBuilder().Spread(Call(legs_38, V.Undef, S_1174, P_1182, ((V)(44D)), ((V)(16D)), ((V)(14D)), ((V)(3D)))).V);
}
y0_1189 = (Truthy(low_1186) ? 14D : 6D);
Invoke(o_1188, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(y0_1189)), ((V)(0D)), ((V)(104D)), ((V)(H_1187)), ((V)(46D)), c_1185, NewObj(2).Put("r", ((V)((SEqS(k_1184, "candy") ? 12D : 5D)))).Put("bev", ((V)(2D))).V));
n_1190 = (Truthy(low_1186) ? 2D : 3D);
{
double i_1192 = 0;
i_1192 = 0D;
while (true) {
if (!((i_1192 < n_1190))) break;
double hh_1194 = 0;
hh_1194 = ((H_1187 - 8D) / n_1190);
Invoke(o_1188, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(((y0_1189 + 4D) + (i_1192 * hh_1194)))), ((V)(23.2)), ((V)(94D)), ((V)((hh_1194 - 4D))), ((V)(1.2)), Call(mix_22, V.Undef, c_1185, ((V)("#ffffff")), ((V)(0.3))), NewObj(1).Put("r", ((V)(3D))).V), Call(knob_43, V.Undef, S_1174, ((V)((-24D))), ((V)(((((y0_1189 + 4D) + (i_1192 * hh_1194)) + (hh_1194 / 2D)) - 2D))), ((V)(24D))), Call(knob_43, V.Undef, S_1174, ((V)(24D)), ((V)(((((y0_1189 + 4D) + (i_1192 * hh_1194)) + (hh_1194 / 2D)) - 2D))), ((V)(24D))));
i_1192++;
}
}
ty_1191 = (y0_1189 + H_1187);
Invoke(o_1188, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)((ty_1191 - 2D))), ((V)(0D)), ((V)(106D)), ((V)(4D)), ((V)(48D)), (SEqS(k_1184, "royal") ? GOLD_27 : Call(shade_23, V.Undef, c_1185, ((V)(0.9)))), NewObj(1).Put("r", ((V)(4D))).V));
if (!(Truthy(low_1186))) {
Invoke(o_1188, "push", Call(disc_18, V.Undef, ((V)(0D)), ((V)((ty_1191 + 26D))), ((V)((-18D))), ((V)(22D)), ((V)(3D)), (SEqS(k_1184, "royal") ? GOLD_27 : (SEqS(k_1184, "candy") ? Get(P_1182, "b") : Get(P_1182, "wD")))), Call(disc_18, V.Undef, ((V)(0D)), ((V)((ty_1191 + 26D))), ((V)((-15D))), ((V)(18D)), ((V)(0.6)), ((V)("#cfe6ee"))), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(ty_1191)), ((V)((-18D))), ((V)(6D)), ((V)(6D)), (SEqS(k_1184, "royal") ? GOLD_27 : Get(P_1182, "wD"))));
}
Invoke(o_1188, "push", Call(cyl_13, V.Undef, ((V)(32D)), ((V)((ty_1191 + 2D))), ((V)(4D)), ((V)(6D)), ((V)(12D)), (SEqS(k_1184, "candy") ? Get(P_1182, "b") : CR_29), NewObj(1).Put("n", ((V)(10D))).V), Call(ball_14, V.Undef, ((V)((-30D))), ((V)((ty_1191 + 2D))), ((V)(6D)), ((V)(5D)), (SEqS(k_1184, "candy") ? GetIdx(NE_26, 3D) : Get(P_1182, "b"))));
if (SEqS(k_1184, "candy")) {
InvokeSpread(o_1188, "push", new ArrBuilder().Spread(Call(drips_40, V.Undef, ((V)(0D)), ((V)(ty_1191)), ((V)(23D)), ((V)(90D)), Get(P_1182, "b"), ((V)(6D)))).V);
}
if (SEqS(k_1184, "royal")) {
Invoke(o_1188, "push", Call(jewel_42, V.Undef, ((V)(0D)), ((V)((ty_1191 + 50D))), ((V)((-18D))), ((V)(5D))));
}
return o_1188;
return default;
}, 1, "build", true)).V;
}, 1, "dresser", true)).Put("desk", Fn((V _arrowThis1202, int _argc1195, V S_1201, V _a1198, V _a1199, V _a1200, V[] _rest1196) => {
return NewObj(5).Put("w", ((V)(116D))).Put("d", ((V)(58D))).Put("act", ((V)("play"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(50D))).V).Put("build", Fn((V _arrowThis1210, int _argc1203, V P_1209, V _a1206, V _a1207, V _a1208, V[] _rest1204) => {
V k_1211 = default;
V c_1212 = default;
V o_1213 = default;
k_1211 = Get(S_1201, "k");
c_1212 = (SEqS(k_1211, "royal") ? ((V)("#f4f1ea")) : (SEqS(k_1211, "candy") ? Get(P_1209, "a") : Get(P_1209, "w")));
o_1213 = Arr();
if (SEqS(k_1211, "retro")) {
Invoke(o_1213, "push", Call(cyl_13, V.Undef, ((V)((-34D))), ((V)(0D)), ((V)(0D)), ((V)(22D)), ((V)(4D)), CH_28, NewObj(1).Put("rz", ((V)(16D))).V), Call(cyl_13, V.Undef, ((V)((-34D))), ((V)(4D)), ((V)(0D)), ((V)(4D)), ((V)(44D)), CH_28, NewObj(1).Put("n", ((V)(8D))).V), Call(cyl_13, V.Undef, ((V)(34D)), ((V)(0D)), ((V)(0D)), ((V)(22D)), ((V)(4D)), CH_28, NewObj(1).Put("rz", ((V)(16D))).V), Call(cyl_13, V.Undef, ((V)(34D)), ((V)(4D)), ((V)(0D)), ((V)(4D)), ((V)(44D)), CH_28, NewObj(1).Put("n", ((V)(8D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(48D)), ((V)(0D)), ((V)(58D)), ((V)(6D)), Get(P_1209, "a"), NewObj(2).Put("rz", ((V)(29D))).Put("n", ((V)(22D))).V));
} else {
InvokeSpread(o_1213, "push", new ArrBuilder().Spread(Call(legs_38, V.Undef, S_1201, P_1209, ((V)(50D)), ((V)(22D)), ((V)(48D)), ((V)(3.5)))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(48D)), ((V)(0D)), ((V)(116D)), ((V)(6D)), ((V)(58D)), c_1212, NewObj(2).Put("r", ((V)((SEqS(k_1211, "candy") ? 14D : 4D)))).Put("bev", ((V)(2D))).V)).V);
if (!SEqS(k_1211, "mod")) {
Invoke(o_1213, "push", Call(box_11, V.Undef, ((V)((-34D))), ((V)(30D)), ((V)(2D)), ((V)(44D)), ((V)(18D)), ((V)(52D)), c_1212, NewObj(1).Put("r", ((V)(4D))).V), Call(box_11, V.Undef, ((V)((-34D))), ((V)(33D)), ((V)(28.2)), ((V)(38D)), ((V)(12D)), ((V)(1D)), Call(mix_22, V.Undef, c_1212, ((V)("#ffffff")), ((V)(0.3))), NewObj(1).Put("r", ((V)(3D))).V), Call(knob_43, V.Undef, S_1201, ((V)((-34D))), ((V)(38D)), ((V)(29D))));
}
}
InvokeSpread(o_1213, "push", new ArrBuilder().Spread(Call(book_44, V.Undef, ((V)(28D)), ((V)(54D)), ((V)(6D)), Arr((SEq(Get(P_1209, "b"), CR_29) ? ((V)("#84b6c9")) : Get(P_1209, "b")), CR_29))).Add(Call(cyl_13, V.Undef, ((V)((-36D))), ((V)(54D)), ((V)((-14D))), ((V)(7D)), ((V)(3D)), (SEqS(k_1211, "mod") ? DK_31 : Get(P_1209, "b")))).Add(Call(cyl_13, V.Undef, ((V)((-36D))), ((V)(57D)), ((V)((-14D))), ((V)(1.6)), ((V)(22D)), (SEqS(k_1211, "mod") ? DK_31 : CH_28), NewObj(1).Put("n", ((V)(6D))).V)).Add(Call(cyl_13, V.Undef, ((V)((-30D))), ((V)(76D)), ((V)((-14D))), ((V)(9D)), ((V)(8D)), (SEqS(k_1211, "mod") ? DK_31 : Get(P_1209, "b")), NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(8D)), ((V)(0D)), ((V)(0.5))))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(54D)), ((V)((-10D))), ((V)(30D)), ((V)(2D)), ((V)(22D)), CR_29, NewObj(1).Put("r", ((V)(1D))).V)).Add(Call(cyl_13, V.Undef, ((V)(10D)), ((V)(54D)), ((V)((-16D))), ((V)(3D)), ((V)(10D)), ((V)("#e3946a")), NewObj(1).Put("n", ((V)(6D))).V)).V);
if (SEqS(k_1211, "candy")) {
InvokeSpread(o_1213, "push", new ArrBuilder().Spread(Call(drips_40, V.Undef, ((V)(0D)), ((V)(54D)), ((V)(29D)), ((V)(100D)), Get(P_1209, "b"), ((V)(7D)))).V);
}
if (SEqS(k_1211, "royal")) {
Invoke(o_1213, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(47D)), ((V)(0D)), ((V)(118D)), ((V)(2D)), ((V)(60D)), GOLD_27, NewObj(1).Put("r", ((V)(4D))).V), Call(jewel_42, V.Undef, ((V)((-36D))), ((V)(84D)), ((V)((-14D))), ((V)(3D))));
}
return o_1213;
return default;
}, 1, "build", true)).V;
}, 1, "desk", true)).Put("chest", Fn((V _arrowThis1221, int _argc1214, V S_1220, V _a1217, V _a1218, V _a1219, V[] _rest1215) => {
return NewObj(5).Put("w", ((V)(94D))).Put("d", ((V)(58D))).Put("act", ((V)("play"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(54D))).V).Put("build", Fn((V _arrowThis1229, int _argc1222, V P_1228, V _a1225, V _a1226, V _a1227, V[] _rest1223) => {
return new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(90D)), ((V)(44D)), ((V)(54D)), Get(P_1228, "w"), NewObj(2).Put("r", ((V)(6D))).Put("bev", ((V)(2D))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(44D)), ((V)(0D)), ((V)(94D)), ((V)(10D)), ((V)(58D)), Get(P_1228, "a"), NewObj(2).Put("r", ((V)(8D))).Put("bev", ((V)(3D))).V)).Spread(Invoke(Arr(Arr(((V)((-30D))), ((V)(10D))), Arr(((V)(0D)), ((V)(40D))), Arr(((V)(30D)), ((V)(20D)))), "map", Fn((V _arrowThis1242, int _argc1230, V _a1232, V i_1236, V _a1234, V _a1235, V[] _rest1231) => {
V x_1239 = default;
V z_1241 = default;
{ V _t1237 = ListOf(_a1232);
{ V _t1238 = GetIdx(_t1237, 0D);
x_1239 = _t1238; }
{ V _t1240 = GetIdx(_t1237, 1D);
z_1241 = _t1240; }
}
return Call(box_11, V.Undef, x_1239, ((V)(54D)), ((V)((ToNum(z_1241) - 28D))), ((V)(22D)), ((V)(0.6)), ((V)(18D)), GetK(Arr(Get(P_1228, "b"), ((V)("#f2c255")), ((V)("#84b6c9"))), i_1236), NewObj(1).Put("r", ((V)(2D))).V);
}, 2, "", true))).Add(Call(ball_14, V.Undef, ((V)((-18D))), ((V)(50D)), ((V)((-8D))), ((V)(11D)), ((V)("#c98d58")))).Add(Call(ball_14, V.Undef, ((V)((-26D))), ((V)(68D)), ((V)((-8D))), ((V)(4D)), ((V)("#c98d58")))).Add(Call(ball_14, V.Undef, ((V)((-10D))), ((V)(68D)), ((V)((-8D))), ((V)(4D)), ((V)("#c98d58")))).Add(Call(ball_14, V.Undef, ((V)(22D)), ((V)(54D)), ((V)(0D)), ((V)(8D)), ((V)("#e3946a")))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(18D)), ((V)(27.2)), ((V)(26D)), ((V)(10D)), ((V)(1D)), Get(P_1228, "b"), NewObj(1).Put("r", ((V)(3D))).V)).V;
}, 1, "build", true)).V;
}, 1, "chest", true)).Put("swing", Fn((V _arrowThis1250, int _argc1243, V S_1249, V _a1246, V _a1247, V _a1248, V[] _rest1244) => {
V k_1251 = default;
k_1251 = Get(S_1249, "k");
return NewObj(7).Put("w", ((V)(184D))).Put("d", ((V)(56D))).Put("act", ((V)("swing"))).Put("anim", ((V)("swing"))).Put("pivot", Arr(((V)(0D)), ((V)(146D)), ((V)(0D)))).Put("seats", Arr(NewObj(4).Put("x", ((V)(0D))).Put("z", ((V)(0D))).Put("h", ((V)((SEqS(k_1251, "junk") ? 36D : 42D)))).Put("k", ((V)("swing"))).V)).Put("build", Fn((V _arrowThis1259, int _argc1252, V P_1258, V _a1255, V _a1256, V _a1257, V[] _rest1253) => {
V fc_1260 = default;
V o_1261 = default;
fc_1260 = (SEqS(k_1251, "junk") ? OLD_33 : (SEqS(k_1251, "royal") ? GOLD_27 : (SEqS(k_1251, "candy") ? WH_30 : (SEqS(k_1251, "retro") ? CH_28 : ((V)("#a86b36"))))));
o_1261 = Arr();
Invoke(Arr(((V)((-80D))), ((V)(80D))), "forEach", Fn((V _arrowThis1269, int _argc1262, V x_1268, V _a1265, V _a1266, V _a1267, V[] _rest1263) => {
return Invoke(Arr(((V)((-20D))), ((V)(20D))), "forEach", Fn((V _arrowThis1277, int _argc1270, V z_1276, V _a1273, V _a1274, V _a1275, V[] _rest1271) => {
return Invoke(o_1261, "push", Call(cyl_13, V.Undef, x_1268, ((V)(0D)), z_1276, ((V)(4D)), ((V)(148D)), fc_1260, NewObj(1).Put("n", ((V)(8D))).V));
}, 1, "", true));
}, 1, "", true));
if (SEqS(k_1251, "candy")) {
Invoke(Arr(((V)((-80D))), ((V)(80D))), "forEach", Fn((V _arrowThis1285, int _argc1278, V x_1284, V _a1281, V _a1282, V _a1283, V[] _rest1279) => {
return Invoke(Arr(((V)((-20D))), ((V)(20D))), "forEach", Fn((V _arrowThis1293, int _argc1286, V z_1292, V _a1289, V _a1290, V _a1291, V[] _rest1287) => {
return Invoke(Arr(((V)(20D)), ((V)(50D)), ((V)(80D)), ((V)(110D)), ((V)(140D))), "forEach", Fn((V _arrowThis1301, int _argc1294, V y_1300, V _a1297, V _a1298, V _a1299, V[] _rest1295) => {
return Invoke(o_1261, "push", Call(cyl_13, V.Undef, x_1284, y_1300, z_1292, ((V)(4.4)), ((V)(7D)), ((V)("#e2554a")), NewObj(1).Put("n", ((V)(8D))).V));
}, 1, "", true));
}, 1, "", true));
}, 1, "", true));
}
Invoke(o_1261, "push", Call(slabX_16, V.Undef, ((V)(0D)), ((V)(146D)), ((V)((-20D))), ((V)(172D)), ((V)(6D)), ((V)(6D)), fc_1260, NewObj(1).Put("r", ((V)(2D))).V), Call(slabX_16, V.Undef, ((V)(0D)), ((V)(146D)), ((V)(20D)), ((V)(172D)), ((V)(6D)), ((V)(6D)), fc_1260, NewObj(1).Put("r", ((V)(2D))).V), Call(slabX_16, V.Undef, ((V)(0D)), ((V)(148D)), ((V)(0D)), ((V)(184D)), ((V)(9D)), ((V)(46D)), (SEqS(k_1251, "junk") ? OLD2_34 : (SEqS(k_1251, "royal") ? Get(P_1258, "a") : (SEqS(k_1251, "candy") ? Get(P_1258, "a") : ((V)("#c98d58"))))), NewObj(1).Put("r", ((V)(4D))).V));
if (SEqS(k_1251, "royal")) {
Invoke(o_1261, "push", Call(jewel_42, V.Undef, ((V)((-80D))), ((V)(157D)), ((V)(0D)), ((V)(6D))), Call(jewel_42, V.Undef, ((V)(80D)), ((V)(157D)), ((V)(0D)), ((V)(6D))));
}
if (SEqS(k_1251, "junk")) {
InvokeSpread(o_1261, "push", new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(0D)), ((V)(1.6)), ((V)(106D)), ((V)("#8a6a3e")), NewObj(2).Put("n", ((V)(6D))).Put("part", ((V)(1D))).V)).Spread(Call(quarters_21, V.Undef, Fn((V _arrowThis1310, int _argc1302, V a0_1308, V a1_1309, V _a1306, V _a1307, V[] _rest1303) => {
return Call(arcW_17, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(0D)), ((V)(24D)), ((V)(24D)), ((V)(9D)), ((V)(12D)), a0_1308, a1_1309, ((V)("#3b3b3b")), NewObj(1).Put("part", ((V)(1D))).V);
}, 2, "", true))).V);
} else {
Invoke(o_1261, "push", Call(cyl_13, V.Undef, ((V)((-18D))), ((V)(40D)), ((V)(0D)), ((V)(1.4)), ((V)(106D)), (SEqS(k_1251, "royal") ? GOLD_27 : ((V)("#8a6a3e"))), NewObj(2).Put("n", ((V)(6D))).Put("part", ((V)(1D))).V), Call(cyl_13, V.Undef, ((V)(18D)), ((V)(40D)), ((V)(0D)), ((V)(1.4)), ((V)(106D)), (SEqS(k_1251, "royal") ? GOLD_27 : ((V)("#8a6a3e"))), NewObj(2).Put("n", ((V)(6D))).Put("part", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(36D)), ((V)(0D)), ((V)(50D)), ((V)(6D)), ((V)(24D)), Get(P_1258, "a"), NewObj(2).Put("r", ((V)(4D))).Put("part", ((V)(1D))).V));
}
return o_1261;
return default;
}, 1, "build", true)).V;
return default;
}, 1, "swing", true)).Put("sandbox", Fn((V _arrowThis1318, int _argc1311, V S_1317, V _a1314, V _a1315, V _a1316, V[] _rest1312) => {
return NewObj(6).Put("w", ((V)(132D))).Put("d", ((V)(100D))).Put("act", ((V)("dig"))).Put("inside", Arr(((V)(0D)), ((V)(10D)), ((V)(0D)))).Put("use", NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(0D))).Put("inside", ((V)(1D))).V).Put("build", Fn((V _arrowThis1326, int _argc1319, V P_1325, V _a1322, V _a1323, V _a1324, V[] _rest1320) => {
V k_1327 = default;
V fc_1328 = default;
V sand_1329 = default;
V o_1330 = default;
k_1327 = Get(S_1317, "k");
fc_1328 = (SEqS(k_1327, "junk") ? OLD_33 : (SEqS(k_1327, "candy") ? Get(P_1325, "a") : Get(P_1325, "w")));
sand_1329 = ((V)((SEqS(k_1327, "candy") ? "#fff1c8" : "#f3dca0")));
o_1330 = Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(116D)), ((V)(12D)), ((V)(84D)), sand_1329, NewObj(1).Put("r", ((V)(4D))).V), Call(ball_14, V.Undef, ((V)((-24D))), ((V)(12D)), ((V)((-12D))), ((V)(18D)), Call(shade_23, V.Undef, sand_1329, ((V)(0.94))), NewObj(1).Put("sy", ((V)(0.35))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-46D))), ((V)(132D)), ((V)(16D)), ((V)(8D)), fc_1328, NewObj(1).Put("r", ((V)(2D))).V), Call(box_11, V.Undef, ((V)((-62D))), ((V)(0D)), ((V)(0D)), ((V)(8D)), ((V)(16D)), ((V)(84D)), fc_1328, NewObj(1).Put("r", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(62D)), ((V)(0D)), ((V)(0D)), ((V)(8D)), ((V)(16D)), ((V)(84D)), fc_1328, NewObj(1).Put("r", ((V)(2D))).V));
if (SEqS(k_1327, "junk")) {
Invoke(o_1330, "push", Call(box_11, V.Undef, ((V)((-34D))), ((V)(0D)), ((V)(46D)), ((V)(64D)), ((V)(16D)), ((V)(8D)), fc_1328, NewObj(1).Put("r", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(40D)), ((V)(0D)), ((V)(50D)), ((V)(40D)), ((V)(12D)), ((V)(8D)), OLD2_34, NewObj(2).Put("r", ((V)(2D))).Put("yaw", ((V)(0.2))).V), Call(ball_14, V.Undef, ((V)(56D)), ((V)(12D)), ((V)((-40D))), ((V)(7D)), ((V)("#8fc176")), NewObj(1).Put("sy", ((V)(1.4))).V), Call(ball_14, V.Undef, ((V)((-60D))), ((V)(14D)), ((V)(38D)), ((V)(6D)), ((V)("#8fc176")), NewObj(1).Put("sy", ((V)(1.4))).V));
} else {
Invoke(o_1330, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(46D)), ((V)(132D)), ((V)(16D)), ((V)(8D)), fc_1328, NewObj(1).Put("r", ((V)(2D))).V), Call(cyl_13, V.Undef, ((V)(34D)), ((V)(12D)), ((V)(10D)), ((V)(8D)), ((V)(12D)), ((V)("#7cc4e8")), NewObj(2).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.75))), Arr(((V)(12D)), ((V)(0D)), ((V)(1D))))).Put("n", ((V)(10D))).V), Call(box_11, V.Undef, ((V)(16D)), ((V)(12D)), ((V)(22D)), ((V)(4D)), ((V)(2D)), ((V)(20D)), ((V)("#e3946a")), NewObj(1).Put("yaw", ((V)(0.6))).V));
}
if (SEqS(k_1327, "candy")) {
InvokeSpread(o_1330, "push", new ArrBuilder().Spread(Call(spr_39, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(0D)), ((V)(90D)), ((V)(60D)), ((V)(10D)))).V);
}
return o_1330;
return default;
}, 1, "build", true)).V;
}, 1, "sandbox", true)).Put("pool", Fn((V _arrowThis1338, int _argc1331, V S_1337, V _a1334, V _a1335, V _a1336, V[] _rest1332) => {
V k_1339 = default;
V rect_1340 = default;
k_1339 = Get(S_1337, "k");
rect_1340 = (SEqS(k_1339, "mod") ? V.True : V.False);
return NewObj(7).Put("w", ((V)(150D))).Put("d", ((V)(110D))).Put("round", ((V)((Truthy(rect_1340) ? 0D : 1D)))).Put("act", ((V)("splash"))).Put("inside", Arr(((V)(0D)), ((V)(4D)), ((V)(0D)))).Put("seats", Arr(NewObj(4).Put("x", ((V)((-26D)))).Put("z", ((V)(0D))).Put("h", ((V)(4D))).Put("k", ((V)("splash"))).V, NewObj(4).Put("x", ((V)(26D))).Put("z", ((V)(0D))).Put("h", ((V)(4D))).Put("k", ((V)("splash"))).V)).Put("build", Fn((V _arrowThis1348, int _argc1341, V P_1347, V _a1344, V _a1345, V _a1346, V[] _rest1342) => {
V o_1349 = default;
double wl_1350 = 0;
V rc_1351 = default;
o_1349 = Arr();
if (Truthy(rect_1340)) {
return Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(132D)), ((V)(12D)), ((V)(92D)), ((V)("#8fdcf5")), NewObj(2).Put("r", ((V)(6D))).Put("emit", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-50D))), ((V)(150D)), ((V)(18D)), ((V)(10D)), Get(P_1347, "a"), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(50D)), ((V)(150D)), ((V)(18D)), ((V)(10D)), Get(P_1347, "a"), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)((-70D))), ((V)(0D)), ((V)(0D)), ((V)(10D)), ((V)(18D)), ((V)(90D)), Get(P_1347, "a"), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(70D)), ((V)(0D)), ((V)(0D)), ((V)(10D)), ((V)(18D)), ((V)(90D)), Get(P_1347, "a"), NewObj(1).Put("r", ((V)(3D))).V), Call(cyl_13, V.Undef, ((V)((-50D))), ((V)(18D)), ((V)((-50D))), ((V)(2D)), ((V)(26D)), CH_28, NewObj(1).Put("n", ((V)(6D))).V), Call(box_11, V.Undef, ((V)((-50D))), ((V)(40D)), ((V)((-46D))), ((V)(4D)), ((V)(3D)), ((V)(10D)), CH_28));
}
wl_1350 = (SEqS(k_1339, "junk") ? 9D : 13D);
rc_1351 = (SEqS(k_1339, "junk") ? ((V)("#8fa8a0")) : (SEqS(k_1339, "royal") ? ((V)("#f4f1ea")) : Get(P_1347, "a")));
InvokeSpread(o_1349, "push", new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(62D)), ((V)(wl_1350)), ((V)("#8fdcf5")), NewObj(3).Put("rz", ((V)(42D))).Put("n", ((V)(20D))).Put("emit", ((V)(1D))).V)).Spread(Call(quarters_21, V.Undef, Fn((V _arrowThis1360, int _argc1352, V a0_1358, V a1_1359, V _a1356, V _a1357, V[] _rest1353) => {
return Call(arcW_17, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(75D)), ((V)(55D)), ((V)(16D)), ((V)(20D)), a0_1358, a1_1359, rc_1351, NewObj(1).Put("n", ((V)(6D))).V);
}, 2, "", true))).Spread(Call(quarters_21, V.Undef, Fn((V _arrowThis1369, int _argc1361, V a0_1367, V a1_1368, V _a1365, V _a1366, V[] _rest1362) => {
return Call(arcW_17, V.Undef, ((V)(0D)), ((V)(20D)), ((V)(0D)), ((V)(73D)), ((V)(53D)), ((V)(12D)), ((V)(4D)), a0_1367, a1_1368, (SEqS(k_1339, "royal") ? GOLD_27 : CR_29), NewObj(1).Put("n", ((V)(6D))).V);
}, 2, "", true))).V);
if (SEqS(k_1339, "junk")) {
Invoke(o_1349, "push", Call(patch_41, V.Undef, ((V)((-30D))), ((V)(6D)), ((V)(55.4)), ((V)(14D)), ((V)(10D)), ((V)("#c9a85a"))), Call(patch_41, V.Undef, ((V)(36D)), ((V)(8D)), ((V)(52D)), ((V)(12D)), ((V)(8D)), ((V)("#b8714a"))), Call(box_11, V.Undef, ((V)(60D)), ((V)(0D)), ((V)(30D)), ((V)(20D)), ((V)(2D)), ((V)(16D)), ((V)("#8fdcf5")), NewObj(2).Put("r", ((V)(6D))).Put("emit", ((V)(1D))).V));
}
if (SEqS(k_1339, "candy")) {
InvokeSpread(o_1349, "push", new ArrBuilder().Spread(Call(quarters_21, V.Undef, Fn((V _arrowThis1378, int _argc1370, V a0_1376, V a1_1377, V _a1374, V _a1375, V[] _rest1371) => {
return Call(arcW_17, V.Undef, ((V)((-30D))), ((V)(wl_1350)), ((V)((-8D))), ((V)(18D)), ((V)(14D)), ((V)(9D)), ((V)(6D)), a0_1376, a1_1377, Get(P_1347, "b"), NewObj(1).Put("n", ((V)(5D))).V);
}, 2, "", true))).V);
}
if (SEqS(k_1339, "royal")) {
Invoke(o_1349, "push", Call(jewel_42, V.Undef, ((V)(0D)), ((V)(24D)), ((V)((-55D))), ((V)(5D))));
}
return o_1349;
return default;
}, 1, "build", true)).V;
return default;
}, 1, "pool", true)).Put("bench", Fn((V _arrowThis1386, int _argc1379, V S_1385, V _a1382, V _a1383, V _a1384, V[] _rest1380) => {
V k_1387 = default;
k_1387 = Get(S_1385, "k");
return (SEqS(k_1387, "mod") ? NewObj(5).Put("w", ((V)(80D))).Put("d", ((V)(170D))).Put("act", ((V)("nap"))).Put("seats", Arr(NewObj(4).Put("x", ((V)(0D))).Put("z", ((V)(24D))).Put("h", ((V)(30D))).Put("k", ((V)("nap"))).V)).Put("build", Fn((V _arrowThis1395, int _argc1388, V P_1394, V _a1391, V _a1392, V _a1393, V[] _rest1389) => {
return new ArrBuilder().Spread(Call(legs_38, V.Undef, S_1385, P_1394, ((V)(32D)), ((V)(72D)), ((V)(16D)), ((V)(3D)))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(16D)), ((V)(0D)), ((V)(78D)), ((V)(8D)), ((V)(166D)), Get(P_1394, "w"), NewObj(1).Put("r", ((V)(4D))).V)).Add(Call(pillowY_19, V.Undef, ((V)(0D)), ((V)(24D)), ((V)(24D)), ((V)(72D)), ((V)(8D)), ((V)(110D)), Get(P_1394, "a"))).Add(Call(prism_24, V.Undef, ((V)((-36D))), ((V)(36D)), Arr(Arr(((V)((-82D))), ((V)(24D))), Arr(((V)((-34D))), ((V)(24D))), Arr(((V)((-70D))), ((V)(70D))), Arr(((V)((-84D))), ((V)(66D)))), Get(P_1394, "a"), NewObj(1).Put("soft", ((V)(1D))).V)).Add(Call(pillowZ_20, V.Undef, ((V)(0D)), ((V)(52D)), ((V)((-64D))), ((V)(50D)), ((V)(18D)), ((V)(8D)), Get(P_1394, "b"))).V;
}, 1, "build", true)).V : NewObj(5).Put("w", ((V)(144D))).Put("d", ((V)(50D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)((-34D)))).Put("z", ((V)(2D))).Put("h", ((V)(30D))).V, NewObj(3).Put("x", ((V)(34D))).Put("z", ((V)(2D))).Put("h", ((V)(30D))).V)).Put("build", Fn((V _arrowThis1403, int _argc1396, V P_1402, V _a1399, V _a1400, V _a1401, V[] _rest1397) => {
return new ArrBuilder().Spread(Call(legs_38, V.Undef, S_1385, P_1402, ((V)(60D)), ((V)(16D)), ((V)(22D)), ((V)(3.5)))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(144D)), ((V)(8D)), ((V)(46D)), Get(P_1402, "w"), NewObj(2).Put("r", ((V)(6D))).Put("bev", ((V)(2D))).V)).Add(Call(cyl_13, V.Undef, ((V)((-62D))), ((V)(30D)), ((V)((-21D))), ((V)(3D)), ((V)(34D)), Get(P_1402, "wD"), NewObj(1).Put("n", ((V)(10D))).V)).Add(Call(cyl_13, V.Undef, ((V)(62D)), ((V)(30D)), ((V)((-21D))), ((V)(3D)), ((V)(34D)), Get(P_1402, "wD"), NewObj(1).Put("n", ((V)(10D))).V)).Add(Call(slab_15, V.Undef, ((V)(0D)), ((V)(40D)), ((V)((-21D))), ((V)(118D)), ((V)(10D)), ((V)(5D)), Get(P_1402, "w"), NewObj(1).Put("r", ((V)(5D))).V)).Add(Call(slab_15, V.Undef, ((V)(0D)), ((V)(54D)), ((V)((-21D))), ((V)(118D)), ((V)(10D)), ((V)(5D)), Get(P_1402, "w"), NewObj(1).Put("r", ((V)(5D))).V)).Add(Call(slab_15, V.Undef, ((V)((-70D))), ((V)(30D)), ((V)(0D)), ((V)(6D)), ((V)(14D)), ((V)(40D)), Get(P_1402, "wD"), NewObj(1).Put("r", ((V)(6D))).V)).Add(Call(slab_15, V.Undef, ((V)(70D)), ((V)(30D)), ((V)(0D)), ((V)(6D)), ((V)(14D)), ((V)(40D)), Get(P_1402, "wD"), NewObj(1).Put("r", ((V)(6D))).V)).Add(Call(pillowY_19, V.Undef, ((V)((-34D))), ((V)(30D)), ((V)(2D)), ((V)(44D)), ((V)(6D)), ((V)(36D)), Get(P_1402, "a"))).V;
}, 1, "build", true)).V);
return default;
}, 1, "bench", true)).Put("hammock", Fn((V _arrowThis1411, int _argc1404, V S_1410, V _a1407, V _a1408, V _a1409, V[] _rest1405) => {
return NewObj(7).Put("w", ((V)(200D))).Put("d", ((V)(50D))).Put("act", ((V)("nap"))).Put("anim", ((V)("swing"))).Put("pivot", Arr(((V)(0D)), ((V)(110D)), ((V)(0D)))).Put("seats", Arr(NewObj(4).Put("x", ((V)(0D))).Put("z", ((V)(0D))).Put("h", ((V)(44D))).Put("k", ((V)("nap"))).V)).Put("build", Fn((V _arrowThis1419, int _argc1412, V P_1418, V _a1415, V _a1416, V _a1417, V[] _rest1413) => {
return new ArrBuilder().Add(Call(box_11, V.Undef, ((V)((-92D))), ((V)(0D)), ((V)(0D)), ((V)(14D)), ((V)(4D)), ((V)(30D)), Get(P_1418, "wD"), NewObj(1).Put("r", ((V)(3D))).V)).Add(Call(box_11, V.Undef, ((V)(92D)), ((V)(0D)), ((V)(0D)), ((V)(14D)), ((V)(4D)), ((V)(30D)), Get(P_1418, "wD"), NewObj(1).Put("r", ((V)(3D))).V)).Add(Call(cyl_13, V.Undef, ((V)((-92D))), ((V)(4D)), ((V)(0D)), ((V)(4D)), ((V)(110D)), Get(P_1418, "w"), NewObj(1).Put("n", ((V)(8D))).V)).Add(Call(cyl_13, V.Undef, ((V)(92D)), ((V)(4D)), ((V)(0D)), ((V)(4D)), ((V)(110D)), Get(P_1418, "w"), NewObj(1).Put("n", ((V)(8D))).V)).Add(Call(ball_14, V.Undef, ((V)((-92D))), ((V)(112D)), ((V)(0D)), ((V)(5D)), Get(P_1418, "wD"))).Add(Call(ball_14, V.Undef, ((V)(92D)), ((V)(112D)), ((V)(0D)), ((V)(5D)), Get(P_1418, "wD"))).Add(Call(prismZ_25, V.Undef, ((V)((-1D))), ((V)(1D)), Arr(Arr(((V)((-90D))), ((V)(108D))), Arr(((V)((-86D))), ((V)(110D))), Arr(((V)((-50D))), ((V)(52D))), Arr(((V)((-56D))), ((V)(50D)))), ((V)("#c4a882")), NewObj(1).Put("part", ((V)(1D))).V)).Add(Call(prismZ_25, V.Undef, ((V)((-1D))), ((V)(1D)), Arr(Arr(((V)(90D)), ((V)(108D))), Arr(((V)(86D)), ((V)(110D))), Arr(((V)(50D)), ((V)(52D))), Arr(((V)(56D)), ((V)(50D)))), ((V)("#c4a882")), NewObj(1).Put("part", ((V)(1D))).V)).Add(Call(cush_12, V.Undef, ((V)(0D)), ((V)(34D)), ((V)(0D)), ((V)(112D)), ((V)(14D)), ((V)(38D)), Get(P_1418, "a"), NewObj(2).Put("r", ((V)(14D))).Put("part", ((V)(1D))).V)).Spread(Invoke(Arr(((V)((-40D))), ((V)((-20D))), ((V)(0D)), ((V)(20D)), ((V)(40D))), "map", Fn((V _arrowThis1427, int _argc1420, V x_1426, V _a1423, V _a1424, V _a1425, V[] _rest1421) => {
return Call(box_11, V.Undef, x_1426, ((V)(47.5)), ((V)(0D)), ((V)(8D)), ((V)(0.6)), ((V)(36D)), Get(P_1418, "b"), NewObj(2).Put("r", ((V)(1D))).Put("part", ((V)(1D))).V);
}, 1, "", true))).Add(Call(pillowY_19, V.Undef, ((V)((-40D))), ((V)(46D)), ((V)(0D)), ((V)(26D)), ((V)(8D)), ((V)(24D)), CR_29, NewObj(1).Put("part", ((V)(1D))).V)).V;
}, 1, "build", true)).V;
}, 1, "hammock", true)).Put("slide", Fn((V _arrowThis1435, int _argc1428, V S_1434, V _a1431, V _a1432, V _a1433, V[] _rest1429) => {
return NewObj(5).Put("w", ((V)(180D))).Put("d", ((V)(50D))).Put("act", ((V)("slide"))).Put("use", NewObj(2).Put("x", ((V)(102D))).Put("z", ((V)(8D))).V).Put("build", Fn((V _arrowThis1443, int _argc1436, V P_1442, V _a1439, V _a1440, V _a1441, V[] _rest1437) => {
V k_1444 = default;
V fc_1445 = default;
V rc_1446 = default;
V o_1447 = default;
k_1444 = Get(S_1434, "k");
fc_1445 = (SEqS(k_1444, "royal") ? ((V)("#f4f1ea")) : (SEqS(k_1444, "candy") ? WH_30 : (SEqS(k_1444, "retro") ? CH_28 : Get(P_1442, "w"))));
rc_1446 = (SEqS(k_1444, "candy") ? Get(P_1442, "a") : Get(P_1442, "a"));
o_1447 = Arr();
Invoke(Arr(((V)((-14D))), ((V)(14D))), "forEach", Fn((V _arrowThis1455, int _argc1448, V z_1454, V _a1451, V _a1452, V _a1453, V[] _rest1449) => {
return Invoke(o_1447, "push", Call(cyl_13, V.Undef, ((V)((-76D))), ((V)(0D)), z_1454, ((V)(2.6)), ((V)(92D)), fc_1445, NewObj(1).Put("n", ((V)(8D))).V), Call(cyl_13, V.Undef, ((V)((-46D))), ((V)(0D)), z_1454, ((V)(3.5)), ((V)(92D)), fc_1445, NewObj(1).Put("n", ((V)(8D))).V));
}, 1, "", true));
{
double y_1456 = 0;
y_1456 = 14D;
while (true) {
if (!((y_1456 < 90D))) break;
Invoke(o_1447, "push", Call(slabX_16, V.Undef, ((V)((-76D))), ((V)(y_1456)), ((V)(0D)), ((V)(3D)), ((V)(3D)), ((V)(30D)), fc_1445, NewObj(1).Put("r", ((V)(1D))).V));
y_1456 = (y_1456 + 15D);
}
}
Invoke(o_1447, "push", Call(box_11, V.Undef, ((V)((-60D))), ((V)(86D)), ((V)(0D)), ((V)(36D)), ((V)(6D)), ((V)(34D)), (SEqS(k_1444, "royal") ? GOLD_27 : (SEq(Get(P_1442, "b"), CR_29) ? Get(P_1442, "aD") : Get(P_1442, "b"))), NewObj(1).Put("r", ((V)(3D))).V));
if (SEqS(k_1444, "candy")) {
InvokeSpread(o_1447, "push", new ArrBuilder().Spread(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(4D)), ((V)(5D))), "map", Fn((V _arrowThis1465, int _argc1458, V i_1464, V _a1461, V _a1462, V _a1463, V[] _rest1459) => {
return Call(prismZ_25, V.Undef, ((V)((-13D))), ((V)(13D)), Arr(Arr(((V)(((-42D) + (ToNum(i_1464) * 22D)))), ((V)((92D - (ToNum(i_1464) * 15.5))))), Arr(((V)(((-20D) + (ToNum(i_1464) * 22D)))), ((V)((92D - (ToNum(Add(i_1464, ((V)(1D)))) * 15.5))))), Arr(((V)(((-20D) + (ToNum(i_1464) * 22D)))), ((V)((98D - (ToNum(Add(i_1464, ((V)(1D)))) * 15.5))))), Arr(((V)(((-42D) + (ToNum(i_1464) * 22D)))), ((V)((98D - (ToNum(i_1464) * 15.5)))))), GetK(NE_26, i_1464));
}, 1, "", true))).V);
} else {
Invoke(o_1447, "push", Call(prismZ_25, V.Undef, ((V)((-13D))), ((V)(13D)), Arr(Arr(((V)((-42D))), ((V)(92D))), Arr(((V)(90D)), ((V)(0D))), Arr(((V)(90D)), ((V)(6D))), Arr(((V)((-42D))), ((V)(98D)))), rc_1446), Call(prismZ_25, V.Undef, ((V)((-15D))), ((V)((-11D))), Arr(Arr(((V)((-42D))), ((V)(98D))), Arr(((V)(90D)), ((V)(6D))), Arr(((V)(90D)), ((V)(14D))), Arr(((V)((-42D))), ((V)(106D)))), Call(shade_23, V.Undef, rc_1446, ((V)(0.9)))), Call(prismZ_25, V.Undef, ((V)(11D)), ((V)(15D)), Arr(Arr(((V)((-42D))), ((V)(98D))), Arr(((V)(90D)), ((V)(6D))), Arr(((V)(90D)), ((V)(14D))), Arr(((V)((-42D))), ((V)(106D)))), Call(shade_23, V.Undef, rc_1446, ((V)(0.9)))));
}
if (SEqS(k_1444, "royal")) {
Invoke(o_1447, "push", Call(prismX_49, V.Undef, ((V)((-78D))), ((V)((-42D))), Arr(Arr(((V)((-18D))), ((V)(92D))), Arr(((V)(18D)), ((V)(92D))), Arr(((V)(0D)), ((V)(126D)))), Get(P_1442, "a")), Call(jewel_42, V.Undef, ((V)((-60D))), ((V)(126D)), ((V)(0D)), ((V)(6D))), Call(prismZ_25, V.Undef, ((V)((-13D))), ((V)(13D)), Arr(Arr(((V)(90D)), ((V)(0D))), Arr(((V)(100D)), ((V)(0D))), Arr(((V)(100D)), ((V)(6D))), Arr(((V)(90D)), ((V)(6D)))), GOLD_27));
}
if (SEqS(k_1444, "retro")) {
Invoke(o_1447, "push", Call(cyl_13, V.Undef, ((V)((-60D))), ((V)(92D)), ((V)(0D)), ((V)(3D)), ((V)(34D)), CH_28, NewObj(1).Put("n", ((V)(6D))).V), Call(disc_18, V.Undef, ((V)((-60D))), ((V)(120D)), ((V)(0D)), ((V)(10D)), ((V)(1.4)), ((V)("#ffd23f"))));
}
return o_1447;
return default;
}, 1, "build", true)).V;
}, 1, "slide", true)).Put("seesaw", Fn((V _arrowThis1473, int _argc1466, V S_1472, V _a1469, V _a1470, V _a1471, V[] _rest1467) => {
return NewObj(7).Put("w", ((V)(180D))).Put("d", ((V)(40D))).Put("act", ((V)("ride"))).Put("anim", ((V)("rock"))).Put("pivot", Arr(((V)(0D)), ((V)(28D)), ((V)(0D)))).Put("seats", Arr(NewObj(4).Put("x", ((V)((-66D)))).Put("z", ((V)(0D))).Put("h", ((V)(34D))).Put("k", ((V)("ride"))).V, NewObj(4).Put("x", ((V)(66D))).Put("z", ((V)(0D))).Put("h", ((V)(34D))).Put("k", ((V)("ride"))).V)).Put("build", Fn((V _arrowThis1481, int _argc1474, V P_1480, V _a1477, V _a1478, V _a1479, V[] _rest1475) => {
V k_1482 = default;
k_1482 = Get(S_1472, "k");
return Arr(Call(prismZ_25, V.Undef, ((V)((-12D))), ((V)(12D)), Arr(Arr(((V)((-20D))), ((V)(0D))), Arr(((V)(20D)), ((V)(0D))), Arr(((V)(0D)), ((V)(28D)))), (SEqS(k_1482, "retro") ? CH_28 : Get(P_1480, "w"))), Call(box_11, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(0D)), ((V)(180D)), ((V)(6D)), ((V)(20D)), Get(P_1480, "a"), NewObj(2).Put("r", ((V)(4D))).Put("part", ((V)(1D))).V), Call(pillowY_19, V.Undef, ((V)((-66D))), ((V)(32D)), ((V)(0D)), ((V)(30D)), ((V)(5D)), ((V)(20D)), Get(P_1480, "b"), NewObj(1).Put("part", ((V)(1D))).V), Call(pillowY_19, V.Undef, ((V)(66D)), ((V)(32D)), ((V)(0D)), ((V)(30D)), ((V)(5D)), ((V)(20D)), Get(P_1480, "b"), NewObj(1).Put("part", ((V)(1D))).V), Call(cyl_13, V.Undef, ((V)((-50D))), ((V)(32D)), ((V)(0D)), ((V)(2D)), ((V)(18D)), (SEqS(k_1482, "retro") ? CH_28 : Get(P_1480, "wD")), NewObj(2).Put("n", ((V)(6D))).Put("part", ((V)(1D))).V), Call(cyl_13, V.Undef, ((V)(50D)), ((V)(32D)), ((V)(0D)), ((V)(2D)), ((V)(18D)), (SEqS(k_1482, "retro") ? CH_28 : Get(P_1480, "wD")), NewObj(2).Put("n", ((V)(6D))).Put("part", ((V)(1D))).V), Call(slabX_16, V.Undef, ((V)((-50D))), ((V)(48D)), ((V)(0D)), ((V)(4D)), ((V)(3D)), ((V)(22D)), (SEqS(k_1482, "retro") ? CH_28 : Get(P_1480, "wD")), NewObj(2).Put("r", ((V)(1.5))).Put("part", ((V)(1D))).V), Call(slabX_16, V.Undef, ((V)(50D)), ((V)(48D)), ((V)(0D)), ((V)(4D)), ((V)(3D)), ((V)(22D)), (SEqS(k_1482, "retro") ? CH_28 : Get(P_1480, "wD")), NewObj(2).Put("r", ((V)(1.5))).Put("part", ((V)(1D))).V), Call(ball_14, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(5D)), ((V)("#ffd23f")), NewObj(1).Put("part", ((V)(1D))).V));
return default;
}, 1, "build", true)).V;
}, 1, "seesaw", true)).Put("stand", Fn((V _arrowThis1490, int _argc1483, V S_1489, V _a1486, V _a1487, V _a1488, V[] _rest1484) => {
return NewObj(5).Put("w", ((V)(120D))).Put("d", ((V)(60D))).Put("act", ((V)("snack"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(56D))).V).Put("build", Fn((V _arrowThis1498, int _argc1491, V P_1497, V _a1494, V _a1495, V _a1496, V[] _rest1492) => {
V o_1499 = default;
o_1499 = Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(116D)), ((V)(50D)), ((V)(52D)), (SEqS(Get(P_1497, "w"), "#d5dde2") ? CR_29 : Get(P_1497, "w")), NewObj(2).Put("r", ((V)(3D))).Put("bev", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(50D)), ((V)(0D)), ((V)(120D)), ((V)(5D)), ((V)(56D)), (SEq(Get(P_1497, "b"), CR_29) ? ((V)("#ffd23f")) : Get(P_1497, "b")), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(18D)), ((V)(26.4)), ((V)(90D)), ((V)(22D)), ((V)(1D)), ((V)("#ffd23f")), NewObj(1).Put("r", ((V)(6D))).V), Call(cyl_13, V.Undef, ((V)((-56D))), ((V)(55D)), ((V)((-24D))), ((V)(2.6)), ((V)(66D)), CH_28, NewObj(1).Put("n", ((V)(6D))).V), Call(cyl_13, V.Undef, ((V)(56D)), ((V)(55D)), ((V)((-24D))), ((V)(2.6)), ((V)(66D)), CH_28, NewObj(1).Put("n", ((V)(6D))).V));
{
double i_1500 = 0;
i_1500 = 0D;
while (true) {
if (!((i_1500 < 6D))) break;
Invoke(o_1499, "push", Call(box_11, V.Undef, ((V)(((-50D) + (i_1500 * 20D)))), ((V)(120D)), ((V)((-12D))), ((V)(20D)), ((V)(4D)), ((V)(36D)), (NumTruthy((i_1500 % 2D)) ? CR_29 : Get(P_1497, "a")), NewObj(1).Put("r", ((V)(1D))).V));
i_1500++;
}
}
InvokeSpread(o_1499, "push", new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)((-26D))), ((V)(55D)), ((V)(4D)), ((V)(9D)), ((V)(22D)), ((V)("#fff4b8")), NewObj(2).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(22D)), ((V)(0D)), ((V)(1D))))).Put("n", ((V)(12D))).V)).Add(Call(cyl_13, V.Undef, ((V)((-26D))), ((V)(77D)), ((V)(4D)), ((V)(9D)), ((V)(2D)), ((V)("#fff1a0")), NewObj(1).Put("n", ((V)(12D))).V)).Spread(Invoke(Arr(((V)(0D)), ((V)(16D)), ((V)(32D))), "map", Fn((V _arrowThis1509, int _argc1502, V x_1508, V _a1505, V _a1506, V _a1507, V[] _rest1503) => {
return Call(cyl_13, V.Undef, x_1508, ((V)(55D)), ((V)(10D)), ((V)(4.5)), ((V)(11D)), ((V)("#ffe680")), NewObj(1).Put("n", ((V)(8D))).V);
}, 1, "", true))).Add(Call(ball_14, V.Undef, ((V)(38D)), ((V)(55D)), ((V)((-6D))), ((V)(7D)), ((V)("#ffd23f")))).Add(Call(ball_14, V.Undef, ((V)(28D)), ((V)(55D)), ((V)((-12D))), ((V)(6D)), ((V)("#ffd23f")))).V);
return o_1499;
return default;
}, 1, "build", true)).V;
}, 1, "stand", true)).Put("grill", Fn((V _arrowThis1517, int _argc1510, V S_1516, V _a1513, V _a1514, V _a1515, V[] _rest1511) => {
return NewObj(7).Put("w", ((V)(90D))).Put("d", ((V)(70D))).Put("round", ((V)(((SEqS(Get(S_1516, "k"), "mod") || SEqS(Get(S_1516, "k"), "retro")) ? 1D : 0D)))).Put("act", ((V)("cook"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(54D))).V).Put("glow", Fn((V _arrowThis1525, int _argc1518, V v_1524, V _a1521, V _a1522, V _a1523, V[] _rest1519) => {
return ((SEqS(Get(S_1516, "k"), "mod") || SEqS(v_1524, "on")) ? NewObj(2).Put("y", ((V)(30D))).Put("r", ((V)(60D))).V : V.Null);
}, 1, "glow", true)).Put("build", Fn((V _arrowThis1534, int _argc1526, V P_1532, V v_1533, V _a1530, V _a1531, V[] _rest1527) => {
V k_1535 = default;
V on_1536 = default;
V o_1537 = default;
k_1535 = Get(S_1516, "k");
on_1536 = (SEqS(v_1533, "on") ? V.True : V.False);
o_1537 = Arr();
if (SEqS(k_1535, "mod")) {
{
double i_1538 = 0;
i_1538 = 0D;
while (true) {
if (!((i_1538 < 10D))) break;
double a_1540 = 0;
a_1540 = (((i_1538 / 10D) * System.Math.PI) * 2D);
Invoke(o_1537, "push", Call(ball_14, V.Undef, ((V)((34D * FdLibm.Cos(a_1540)))), ((V)(0D)), ((V)((26D * FdLibm.Sin(a_1540)))), ((V)(9D)), ((V)((NumTruthy((i_1538 % 2D)) ? "#b8b2a6" : "#a59f94"))), NewObj(3).Put("sy", ((V)(0.8))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V));
i_1538++;
}
}
InvokeSpread(o_1537, "push", new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(26D)), ((V)(4D)), ((V)("#5a4a40")), NewObj(1).Put("rz", ((V)(18D))).V)).Add(Call(box_11, V.Undef, ((V)((-8D))), ((V)(4D)), ((V)(0D)), ((V)(30D)), ((V)(5D)), ((V)(6D)), ((V)("#8a5a34")), NewObj(2).Put("r", ((V)(2D))).Put("yaw", ((V)(0.6))).V)).Add(Call(box_11, V.Undef, ((V)(8D)), ((V)(4D)), ((V)(2D)), ((V)(30D)), ((V)(5D)), ((V)(6D)), ((V)("#8a5a34")), NewObj(2).Put("r", ((V)(2D))).Put("yaw", ((V)((-0.6)))).V)).Spread(Call(flame_45, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(0D)), ((V)((Truthy(on_1536) ? 2.2 : 1.6))))).Spread(Call(flame_45, V.Undef, ((V)((-8D))), ((V)(8D)), ((V)(4D)), ((V)((Truthy(on_1536) ? 1.4 : 1D))))).Spread(Call(flame_45, V.Undef, ((V)(8D)), ((V)(8D)), ((V)((-3D))), ((V)((Truthy(on_1536) ? 1.4 : 1D))))).V);
return o_1537;
}
if (SEqS(k_1535, "retro")) {
Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "forEach", Fn((V _arrowThis1548, int _argc1541, V i_1547, V _a1544, V _a1545, V _a1546, V[] _rest1542) => {
return Invoke(o_1537, "push", Call(cyl_13, V.Undef, ((V)((22D * FdLibm.Cos(((ToNum(i_1547) * 2.094) + 0.5))))), ((V)(0D)), ((V)((18D * FdLibm.Sin(((ToNum(i_1547) * 2.094) + 0.5))))), ((V)(2D)), ((V)(40D)), CH_28, NewObj(1).Put("n", ((V)(6D))).V));
}, 1, "", true));
Invoke(o_1537, "push", Call(ball_14, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(0D)), ((V)(30D)), Get(P_1532, "a"), NewObj(3).Put("sy", ((V)(0.5))).Put("k", ((V)(6D))).Put("n", ((V)(18D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(0D)), ((V)(31D)), ((V)(2D)), CH_28));
if (Truthy(on_1536)) {
Invoke(o_1537, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(42D)), ((V)(0D)), ((V)(26D)), ((V)(1D)), ((V)("#ff8a3a")), NewObj(1).Put("emit", ((V)(1D))).V));
} else {
Invoke(o_1537, "push", Call(ball_14, V.Undef, ((V)(0D)), ((V)(42D)), ((V)(0D)), ((V)(30D)), Get(P_1532, "a"), NewObj(3).Put("sy", ((V)(0.45))).Put("k", ((V)(6D))).Put("n", ((V)(18D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(68D)), ((V)(0D)), ((V)(3D)), ((V)(5D)), CH_28, NewObj(1).Put("n", ((V)(6D))).V));
}
return o_1537;
}
InvokeSpread(o_1537, "push", new ArrBuilder().Spread(Invoke(Arr(Arr(((V)((-36D))), ((V)((-20D)))), Arr(((V)(36D)), ((V)((-20D)))), Arr(((V)((-36D))), ((V)(20D))), Arr(((V)(36D)), ((V)(20D)))), "map", Fn((V _arrowThis1560, int _argc1549, V _a1551, V _a1552, V _a1553, V _a1554, V[] _rest1550) => {
V x_1557 = default;
V z_1559 = default;
{ V _t1555 = ListOf(_a1551);
{ V _t1556 = GetIdx(_t1555, 0D);
x_1557 = _t1556; }
{ V _t1558 = GetIdx(_t1555, 1D);
z_1559 = _t1558; }
}
return Call(cyl_13, V.Undef, x_1557, ((V)(0D)), z_1559, ((V)(2D)), ((V)(32D)), ((V)("#5a5450")), NewObj(1).Put("n", ((V)(6D))).V);
}, 1, "", true))).Add(Call(solid_10, V.Undef, NewObj(8).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(50D)))).Put("a", ((V)(28D))).Put("b", ((V)(22D))).Put("n", ((V)(16D))).Put("rings", Arr(Arr(((V)((-42D))), ((V)(0D))), Arr(((V)(42D)), ((V)(0D))))).Put("col", (SEqS(k_1535, "junk") ? ((V)("#6a625c")) : Get(P_1532, "a"))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(50D)), ((V)(0D)), ((V)(84D)), ((V)(2D)), ((V)(54D)), ((V)("#3b3b3b")), NewObj(1).Put("r", ((V)(2D))).V)).V);
if (SEqS(k_1535, "junk")) {
Invoke(o_1537, "push", Call(patch_41, V.Undef, ((V)((-20D))), ((V)(40D)), ((V)(27D)), ((V)(12D)), ((V)(10D)), ((V)("#b8714a"))), Call(patch_41, V.Undef, ((V)(16D)), ((V)(56D)), ((V)(27D)), ((V)(10D)), ((V)(8D)), ((V)("#b8714a"))));
}
if (Truthy(on_1536)) {
InvokeSpread(o_1537, "push", new ArrBuilder().Spread(Call(flame_45, V.Undef, ((V)((-16D))), ((V)(50D)), ((V)(0D)), ((V)(1.2)))).Spread(Call(flame_45, V.Undef, ((V)(14D)), ((V)(50D)), ((V)(4D)), ((V)(1.2)))).V);
}
Invoke(o_1537, "push", Call(box_11, V.Undef, ((V)((-12D))), ((V)(52D)), ((V)((-2D))), ((V)(18D)), ((V)(4D)), ((V)(8D)), ((V)("#a86b36")), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(12D)), ((V)(52D)), ((V)(6D)), ((V)(18D)), ((V)(4D)), ((V)(8D)), ((V)("#a86b36")), NewObj(1).Put("r", ((V)(3D))).V));
return o_1537;
return default;
}, 2, "build", true)).V;
}, 1, "grill", true)).Put("tramp", Fn((V _arrowThis1568, int _argc1561, V S_1567, V _a1564, V _a1565, V _a1566, V[] _rest1562) => {
return NewObj(7).Put("w", ((V)(150D))).Put("d", ((V)(120D))).Put("round", ((V)(1D))).Put("act", ((V)("bounce"))).Put("inside", Arr(((V)(0D)), ((V)(30D)), ((V)(0D)))).Put("use", NewObj(4).Put("x", ((V)(0D))).Put("z", ((V)(0D))).Put("inside", ((V)(1D))).Put("h", ((V)(30D))).V).Put("build", Fn((V _arrowThis1576, int _argc1569, V P_1575, V _a1572, V _a1573, V _a1574, V[] _rest1570) => {
V k_1577 = default;
V o_1578 = default;
k_1577 = Get(S_1567, "k");
o_1578 = Arr();
{
double i_1579 = 0;
i_1579 = 0D;
while (true) {
if (!((i_1579 < 6D))) break;
double a_1581 = 0;
a_1581 = (((i_1579 / 6D) * System.Math.PI) * 2D);
Invoke(o_1578, "push", Call(cyl_13, V.Undef, ((V)((64D * FdLibm.Cos(a_1581)))), ((V)(0D)), ((V)((50D * FdLibm.Sin(a_1581)))), ((V)(2.6)), ((V)(28D)), (SEqS(k_1577, "candy") ? GetIdx(NE_26, i_1579) : DK_31), NewObj(1).Put("n", ((V)(6D))).V));
i_1579++;
}
}
Invoke(o_1578, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(0D)), ((V)(72D)), ((V)(6D)), (SEqS(k_1577, "candy") ? Get(P_1575, "b") : Get(P_1575, "a")), NewObj(2).Put("rz", ((V)(56D))).Put("n", ((V)(24D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(31.5)), ((V)(0D)), ((V)(60D)), ((V)(0.6)), (SEqS(k_1577, "candy") ? Get(P_1575, "a") : ((V)("#3d4048"))), NewObj(2).Put("rz", ((V)(46D))).Put("n", ((V)(22D))).V));
if (SEqS(k_1577, "candy")) {
InvokeSpread(o_1578, "push", new ArrBuilder().Spread(Call(spr_39, V.Undef, ((V)(0D)), ((V)(32D)), ((V)(0D)), ((V)(80D)), ((V)(60D)), ((V)(8D)))).V);
} else {
Invoke(o_1578, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(32D)), ((V)(0D)), ((V)(30D)), ((V)(0.4)), Call(shade_23, V.Undef, ((V)("#3d4048")), ((V)(1.3))), NewObj(2).Put("rz", ((V)(23D))).Put("n", ((V)(18D))).V));
}
return o_1578;
return default;
}, 1, "build", true)).V;
}, 1, "tramp", true)).Put("house", Fn((V _arrowThis1589, int _argc1582, V S_1588, V _a1585, V _a1586, V _a1587, V[] _rest1583) => {
return NewObj(5).Put("w", ((V)(130D))).Put("d", ((V)(100D))).Put("act", ((V)("play"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(62D))).V).Put("build", Fn((V _arrowThis1597, int _argc1590, V P_1596, V _a1593, V _a1594, V _a1595, V[] _rest1591) => {
V k_1598 = default;
V wall_1599 = default;
V roof_1600 = default;
V o_1601 = default;
k_1598 = Get(S_1588, "k");
wall_1599 = (SEqS(k_1598, "candy") ? ((V)("#c98d52")) : (SEqS(k_1598, "royal") ? ((V)("#f4f1ea")) : Get(P_1596, "a")));
roof_1600 = (SEqS(k_1598, "candy") ? CR_29 : (SEqS(k_1598, "royal") ? (SEq(Get(P_1596, "b"), GOLD_27) ? ((V)("#4a6fd6")) : Get(P_1596, "a")) : (SEqS(Get(P_1596, "b"), "#f5f3ef") ? DK_31 : Get(P_1596, "b"))));
o_1601 = Arr();
Invoke(o_1601, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(110D)), ((V)(78D)), ((V)(80D)), wall_1599, NewObj(1).Put("r", ((V)(4D))).V));
if (SEqS(k_1598, "mod")) {
Invoke(o_1601, "push", Call(prism_24, V.Undef, ((V)((-60D))), ((V)(60D)), Arr(Arr(((V)((-48D))), ((V)(76D))), Arr(((V)(48D)), ((V)(76D))), Arr(((V)(48D)), ((V)(96D))), Arr(((V)((-48D))), ((V)(80D)))), roof_1600));
} else {
Invoke(o_1601, "push", Call(prism_24, V.Undef, ((V)((-62D))), ((V)(62D)), Arr(Arr(((V)((-50D))), ((V)(76D))), Arr(((V)(50D)), ((V)(76D))), Arr(((V)(0D)), ((V)(122D)))), roof_1600));
}
if (SEqS(k_1598, "royal")) {
Invoke(o_1601, "push", Call(cyl_13, V.Undef, ((V)((-58D))), ((V)(0D)), ((V)(42D)), ((V)(12D)), ((V)(130D)), wall_1599, NewObj(1).Put("n", ((V)(12D))).V), Call(cyl_13, V.Undef, ((V)((-58D))), ((V)(130D)), ((V)(42D)), ((V)(14D)), ((V)(26D)), Get(P_1596, "a"), NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(26D)), ((V)(13D))))).V), Call(jewel_42, V.Undef, ((V)((-58D))), ((V)(156D)), ((V)(42D)), ((V)(4D))), Call(cyl_13, V.Undef, ((V)(58D)), ((V)(0D)), ((V)(42D)), ((V)(12D)), ((V)(130D)), wall_1599, NewObj(1).Put("n", ((V)(12D))).V), Call(cyl_13, V.Undef, ((V)(58D)), ((V)(130D)), ((V)(42D)), ((V)(14D)), ((V)(26D)), Get(P_1596, "a"), NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(26D)), ((V)(13D))))).V), Call(jewel_42, V.Undef, ((V)(58D)), ((V)(156D)), ((V)(42D)), ((V)(4D))));
}
Invoke(o_1601, "push", Call(box_11, V.Undef, ((V)((-18D))), ((V)(0D)), ((V)(40.4)), ((V)(28D)), ((V)(48D)), ((V)(1D)), (SEqS(k_1598, "candy") ? Get(P_1596, "a") : Call(shade_23, V.Undef, wall_1599, ((V)(0.7)))), NewObj(1).Put("r", ((V)(12D))).V), Call(ball_14, V.Undef, ((V)((-10D))), ((V)(22D)), ((V)(41D)), ((V)(2.4)), GOLD_27, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(box_11, V.Undef, ((V)(24D)), ((V)(34D)), ((V)(40.4)), ((V)(30D)), ((V)(26D)), ((V)(1D)), ((V)("#cfe8f4")), NewObj(1).Put("r", ((V)((SEqS(k_1598, "royal") ? 13D : 3D)))).V), Call(box_11, V.Undef, ((V)(24D)), ((V)(34D)), ((V)(41.2)), ((V)(2D)), ((V)(26D)), ((V)(0.6)), CR_29), Call(box_11, V.Undef, ((V)(24D)), ((V)(46D)), ((V)(41.2)), ((V)(30D)), ((V)(2D)), ((V)(0.6)), CR_29));
if (SEqS(k_1598, "candy")) {
InvokeSpread(o_1601, "push", new ArrBuilder().Spread(Invoke(Arr(((V)((-36D))), ((V)(0D)), ((V)(36D))), "map", Fn((V _arrowThis1610, int _argc1602, V x_1608, V i_1609, V _a1606, V _a1607, V[] _rest1603) => {
return Call(ball_14, V.Undef, x_1608, ((V)(70D)), ((V)(40D)), ((V)(5D)), GetIdx(NE_26, (ToNum(i_1609) * 2D)));
}, 2, "", true))).Spread(Call(drips_40, V.Undef, ((V)(0D)), ((V)(78D)), ((V)(41D)), ((V)(100D)), CR_29, ((V)(7D)))).Spread(Call(spr_39, V.Undef, ((V)(0D)), ((V)(112D)), ((V)(0D)), ((V)(40D)), ((V)(40D)), ((V)(6D)))).V);
}
if (SEqS(k_1598, "mod")) {
Invoke(o_1601, "push", Call(box_11, V.Undef, ((V)(24D)), ((V)(34D)), ((V)(40.4)), ((V)(44D)), ((V)(34D)), ((V)(1D)), ((V)("#cfe8f4")), NewObj(1).Put("r", ((V)(2D))).V));
}
return o_1601;
return default;
}, 1, "build", true)).V;
}, 1, "house", true)).Put("merry", Fn((V _arrowThis1618, int _argc1611, V S_1617, V _a1614, V _a1615, V _a1616, V[] _rest1612) => {
return NewObj(8).Put("w", ((V)(140D))).Put("d", ((V)(120D))).Put("round", ((V)(1D))).Put("act", ((V)("ride"))).Put("anim", ((V)("rock"))).Put("pivot", Arr(((V)(0D)), ((V)(0D)), ((V)(0D)))).Put("seats", Arr(NewObj(4).Put("x", ((V)((-36D)))).Put("z", ((V)(10D))).Put("h", ((V)(14D))).Put("k", ((V)("ride"))).V, NewObj(4).Put("x", ((V)(36D))).Put("z", ((V)(10D))).Put("h", ((V)(14D))).Put("k", ((V)("ride"))).V)).Put("build", Fn((V _arrowThis1626, int _argc1619, V P_1625, V _a1622, V _a1623, V _a1624, V[] _rest1620) => {
V k_1627 = default;
V o_1628 = default;
k_1627 = Get(S_1617, "k");
o_1628 = Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(20D)), ((V)(6D)), DK_31, NewObj(1).Put("rz", ((V)(16D))).V));
Invoke(o_1628, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(66D)), ((V)(8D)), (SEqS(k_1627, "royal") ? ((V)("#f4f1ea")) : Get(P_1625, "a")), NewObj(3).Put("rz", ((V)(52D))).Put("n", ((V)(24D))).Put("part", ((V)(1D))).V));
{
double i_1629 = 0;
i_1629 = 0D;
while (true) {
if (!((i_1629 < 6D))) break;
double a_1631 = 0;
a_1631 = ((((i_1629 / 6D) * System.Math.PI) * 2D) + 0.3);
Invoke(o_1628, "push", Call(box_11, V.Undef, ((V)((40D * FdLibm.Cos(a_1631)))), ((V)(14D)), ((V)((32D * FdLibm.Sin(a_1631)))), ((V)(20D)), ((V)(0.6)), ((V)(14D)), (SEqS(k_1627, "royal") ? GOLD_27 : GetIdx(NE_26, i_1629)), NewObj(3).Put("r", ((V)(4D))).Put("part", ((V)(1D))).Put("yaw", ((V)((-a_1631)))).V));
i_1629++;
}
}
Invoke(o_1628, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(0D)), ((V)(4D)), ((V)((SEqS(k_1627, "royal") ? 110D : 40D))), (SEqS(k_1627, "royal") ? GOLD_27 : CH_28), NewObj(2).Put("n", ((V)(8D))).Put("part", ((V)(1D))).V));
if (SEqS(k_1627, "royal")) {
Invoke(o_1628, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(110D)), ((V)(0D)), ((V)(70D)), ((V)(6D)), Get(P_1625, "a"), NewObj(3).Put("rz", ((V)(54D))).Put("n", ((V)(24D))).Put("part", ((V)(1D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(116D)), ((V)(0D)), ((V)(70D)), ((V)(22D)), Get(P_1625, "a"), NewObj(4).Put("rz", ((V)(54D))).Put("n", ((V)(24D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(22D)), ((V)(60D))))).Put("part", ((V)(1D))).V), Call(jewel_42, V.Undef, ((V)(0D)), ((V)(136D)), ((V)(0D)), ((V)(7D))));
Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D))), "forEach", Fn((V _arrowThis1639, int _argc1632, V i_1638, V _a1635, V _a1636, V _a1637, V[] _rest1633) => {
double a_1640 = 0;
a_1640 = ((((ToNum(i_1638) / 4D) * System.Math.PI) * 2D) + 0.78);
Invoke(o_1628, "push", Call(cyl_13, V.Undef, ((V)((56D * FdLibm.Cos(a_1640)))), ((V)(14D)), ((V)((44D * FdLibm.Sin(a_1640)))), ((V)(2D)), ((V)(96D)), GOLD_27, NewObj(2).Put("n", ((V)(6D))).Put("part", ((V)(1D))).V));
return default;
}, 1, "", true));
} else {
Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D))), "forEach", Fn((V _arrowThis1648, int _argc1641, V i_1647, V _a1644, V _a1645, V _a1646, V[] _rest1642) => {
double a_1649 = 0;
a_1649 = ((((ToNum(i_1647) / 4D) * System.Math.PI) * 2D) + 0.78);
Invoke(o_1628, "push", Call(cyl_13, V.Undef, ((V)((46D * FdLibm.Cos(a_1649)))), ((V)(14D)), ((V)((36D * FdLibm.Sin(a_1649)))), ((V)(1.8)), ((V)(30D)), (SEqS(k_1627, "candy") ? WH_30 : CH_28), NewObj(2).Put("n", ((V)(6D))).Put("part", ((V)(1D))).V));
return default;
}, 1, "", true));
if (SEqS(k_1627, "candy")) {
InvokeSpread(o_1628, "push", new ArrBuilder().Add(Call(ball_14, V.Undef, ((V)(0D)), ((V)(44D)), ((V)(0D)), ((V)(50D)), Get(P_1625, "b"), NewObj(3).Put("sy", ((V)(0.32))).Put("sz", ((V)(0.8))).Put("part", ((V)(1D))).V)).Spread(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(4D)), ((V)(5D))), "map", Fn((V _arrowThis1657, int _argc1650, V i_1656, V _a1653, V _a1654, V _a1655, V[] _rest1651) => {
return Call(ball_14, V.Undef, ((V)((30D * FdLibm.Cos((ToNum(i_1656) * 1.05))))), ((V)(58D)), ((V)((22D * FdLibm.Sin((ToNum(i_1656) * 1.05))))), ((V)(6D)), GetK(NE_26, i_1656), NewObj(1).Put("part", ((V)(1D))).V);
}, 1, "", true))).Add(Call(ball_14, V.Undef, ((V)(0D)), ((V)(64D)), ((V)(0D)), ((V)(8D)), ((V)("#e2554a")), NewObj(1).Put("part", ((V)(1D))).V)).V);
} else {
Invoke(o_1628, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(54D)), ((V)(0D)), ((V)(48D)), ((V)(3D)), CH_28, NewObj(3).Put("rz", ((V)(38D))).Put("n", ((V)(20D))).Put("part", ((V)(1D))).V), Call(ball_14, V.Undef, ((V)(0D)), ((V)(50D)), ((V)(0D)), ((V)(10D)), Get(P_1625, "b"), NewObj(1).Put("part", ((V)(1D))).V));
}
}
return o_1628;
return default;
}, 1, "build", true)).V;
}, 1, "merry", true)).Put("fountain", Fn((V _arrowThis1665, int _argc1658, V S_1664, V _a1661, V _a1662, V _a1663, V[] _rest1659) => {
return NewObj(6).Put("w", ((V)(150D))).Put("d", ((V)(120D))).Put("round", ((V)(1D))).Put("act", ((V)("wash"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(70D))).V).Put("build", Fn((V _arrowThis1673, int _argc1666, V P_1672, V _a1669, V _a1670, V _a1671, V[] _rest1667) => {
return new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(72D)), ((V)(22D)), ((V)("#f4f1ea")), NewObj(3).Put("rz", ((V)(56D))).Put("n", ((V)(24D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(18D)), ((V)(0D))), Arr(((V)(22D)), ((V)(3D))))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(66D)), ((V)(0.6)), ((V)("#8fdcf5")), NewObj(3).Put("rz", ((V)(50D))).Put("n", ((V)(22D))).Put("emit", ((V)(1D))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(74D)), ((V)(4D)), GOLD_27, NewObj(2).Put("rz", ((V)(58D))).Put("n", ((V)(24D))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(9D)), ((V)(46D)), ((V)("#f4f1ea")), NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.4))), Arr(((V)(20D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(46D)), ((V)(0D)), ((V)(1D))))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(68D)), ((V)(0D)), ((V)(34D)), ((V)(10D)), ((V)("#f4f1ea")), NewObj(2).Put("rz", ((V)(28D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(10D)), ((V)(0D)), ((V)(1D))))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(78D)), ((V)(0D)), ((V)(30D)), ((V)(0.6)), ((V)("#8fdcf5")), NewObj(2).Put("rz", ((V)(24D))).Put("emit", ((V)(1D))).V)).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(78D)), ((V)(0D)), ((V)(6D)), ((V)(26D)), GOLD_27, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(26D)), ((V)(0D)), ((V)(0.6))))).V)).Add(Call(jewel_42, V.Undef, ((V)(0D)), ((V)(104D)), ((V)(0D)), ((V)(7D)))).Spread(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(4D)), ((V)(5D))), "map", Fn((V _arrowThis1681, int _argc1674, V i_1680, V _a1677, V _a1678, V _a1679, V[] _rest1675) => {
double a_1682 = 0;
a_1682 = (((ToNum(i_1680) / 6D) * System.Math.PI) * 2D);
return Call(ball_14, V.Undef, ((V)((28D * FdLibm.Cos(a_1682)))), ((V)(30D)), ((V)((22D * FdLibm.Sin(a_1682)))), ((V)(4D)), ((V)("#bfe8f6")), NewObj(2).Put("sy", ((V)(2.2))).Put("emit", ((V)(1D))).V);
return default;
}, 1, "", true))).Spread(Invoke(Arr(Arr(((V)((-40D))), ((V)(10D))), Arr(((V)(40D)), ((V)((-6D)))), Arr(((V)(10D)), ((V)(34D)))), "map", Fn((V _arrowThis1694, int _argc1683, V _a1685, V _a1686, V _a1687, V _a1688, V[] _rest1684) => {
V x_1691 = default;
V z_1693 = default;
{ V _t1689 = ListOf(_a1685);
{ V _t1690 = GetIdx(_t1689, 0D);
x_1691 = _t1690; }
{ V _t1692 = GetIdx(_t1689, 1D);
z_1693 = _t1692; }
}
return Call(ball_14, V.Undef, x_1691, ((V)(22D)), z_1693, ((V)(5D)), WH_30, NewObj(1).Put("sy", ((V)(0.5))).V);
}, 1, "", true))).V;
}, 1, "build", true)).V;
}, 1, "fountain", true)).Put("tree", Fn((V _arrowThis1702, int _argc1695, V S_1701, V _a1698, V _a1699, V _a1700, V[] _rest1696) => {
return NewObj(4).Put("w", ((V)(40D))).Put("d", ((V)(40D))).Put("round", ((V)(1D))).Put("build", Fn((V _arrowThis1710, int _argc1703, V P_1709, V _a1706, V _a1707, V _a1708, V[] _rest1704) => {
return (SEqS(Get(S_1701, "k"), "candy") ? new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(6D)), ((V)(100D)), WH_30, NewObj(1).Put("n", ((V)(10D))).V)).Spread(Invoke(Arr(((V)(20D)), ((V)(50D)), ((V)(80D))), "map", Fn((V _arrowThis1718, int _argc1711, V y_1717, V _a1714, V _a1715, V _a1716, V[] _rest1712) => {
return Call(cyl_13, V.Undef, ((V)(0D)), y_1717, ((V)(0D)), ((V)(6.4)), ((V)(8D)), ((V)("#e2554a")), NewObj(1).Put("n", ((V)(10D))).V);
}, 1, "", true))).Add(Call(ball_14, V.Undef, ((V)(0D)), ((V)(96D)), ((V)(0D)), ((V)(40D)), Get(P_1709, "a"))).Add(Call(ball_14, V.Undef, ((V)((-30D))), ((V)(88D)), ((V)(14D)), ((V)(22D)), Get(P_1709, "b"))).Add(Call(ball_14, V.Undef, ((V)(30D)), ((V)(92D)), ((V)(10D)), ((V)(24D)), Get(P_1709, "w"))).Add(Call(ball_14, V.Undef, ((V)(0D)), ((V)(134D)), ((V)((-2D))), ((V)(22D)), Get(P_1709, "b"))).Spread(Call(spr_39, V.Undef, ((V)(0D)), ((V)(120D)), ((V)(20D)), ((V)(50D)), ((V)(20D)), ((V)(8D)))).Spread(Invoke(Arr(Arr(((V)((-20D))), ((V)(120D)), ((V)(36D))), Arr(((V)(24D)), ((V)(112D)), ((V)(34D))), Arr(((V)(4D)), ((V)(146D)), ((V)(18D)))), "map", Fn((V _arrowThis1733, int _argc1719, V _a1721, V i_1725, V _a1723, V _a1724, V[] _rest1720) => {
V x_1728 = default;
V y_1730 = default;
V z_1732 = default;
{ V _t1726 = ListOf(_a1721);
{ V _t1727 = GetIdx(_t1726, 0D);
x_1728 = _t1727; }
{ V _t1729 = GetIdx(_t1726, 1D);
y_1730 = _t1729; }
{ V _t1731 = GetIdx(_t1726, 2D);
z_1732 = _t1731; }
}
return Call(ball_14, V.Undef, x_1728, y_1730, z_1732, ((V)(5D)), GetIdx(NE_26, (ToNum(i_1725) * 2D)));
}, 2, "", true))).V : Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(12D)), ((V)(112D)), ((V)("#a86b36")), NewObj(2).Put("rg", Arr(Arr(((V)(0D)), ((V)(4D))), Arr(((V)(10D)), ((V)(0D))), Arr(((V)(112D)), ((V)(3D))))).Put("n", ((V)(10D))).V), Call(ball_14, V.Undef, ((V)(0D)), ((V)(104D)), ((V)(0D)), ((V)(46D)), Get(P_1709, "a")), Call(ball_14, V.Undef, ((V)((-40D))), ((V)(96D)), ((V)(10D)), ((V)(32D)), Get(P_1709, "a")), Call(ball_14, V.Undef, ((V)(40D)), ((V)(100D)), ((V)(6D)), ((V)(34D)), Get(P_1709, "a")), Call(ball_14, V.Undef, ((V)((-14D))), ((V)(150D)), ((V)((-6D))), ((V)(30D)), Get(P_1709, "aL")), Call(ball_14, V.Undef, ((V)(18D)), ((V)(146D)), ((V)(10D)), ((V)(28D)), Get(P_1709, "aL")), Call(ball_14, V.Undef, ((V)((-22D))), ((V)(128D)), ((V)(40D)), ((V)(5D)), ((V)("#ffb347"))), Call(ball_14, V.Undef, ((V)(26D)), ((V)(118D)), ((V)(38D)), ((V)(5D)), ((V)("#ffb347")))));
}, 1, "build", true)).V;
}, 1, "tree", true)).Put("bush", Fn((V _arrowThis1741, int _argc1734, V S_1740, V _a1737, V _a1738, V _a1739, V[] _rest1735) => {
return NewObj(4).Put("w", ((V)(60D))).Put("d", ((V)(60D))).Put("round", ((V)(1D))).Put("build", Fn((V _arrowThis1749, int _argc1742, V P_1748, V _a1745, V _a1746, V _a1747, V[] _rest1743) => {
return (SEqS(Get(S_1740, "k"), "royal") ? Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(22D)), ((V)(26D)), ((V)("#f4f1ea")), NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(26D)), ((V)(0D)), ((V)(1D))))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(24D)), ((V)(0D)), ((V)(23D)), ((V)(3D)), GOLD_27), Call(ball_14, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(0D)), ((V)(24D)), ((V)("#6fae50"))), Call(ball_14, V.Undef, ((V)(0D)), ((V)(70D)), ((V)(0D)), ((V)(18D)), ((V)("#7ab45c"))), Call(ball_14, V.Undef, ((V)(0D)), ((V)(104D)), ((V)(0D)), ((V)(12D)), ((V)("#8fc176"))), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D)), ((V)(2D)), ((V)(80D)), ((V)("#a86b36")), NewObj(1).Put("n", ((V)(6D))).V), Call(jewel_42, V.Undef, ((V)(0D)), ((V)(128D)), ((V)(0D)), ((V)(5D)))) : Arr(Call(ball_14, V.Undef, ((V)((-22D))), ((V)(0D)), ((V)(8D)), ((V)(18D)), Get(P_1748, "aD")), Call(ball_14, V.Undef, ((V)(22D)), ((V)(0D)), ((V)(6D)), ((V)(18D)), Get(P_1748, "aD")), Call(ball_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(26D)), Get(P_1748, "a"), NewObj(1).Put("sy", ((V)(0.9))).V), Call(ball_14, V.Undef, ((V)((-8D))), ((V)(40D)), ((V)(18D)), ((V)(3.5)), CR_29, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(ball_14, V.Undef, ((V)(10D)), ((V)(36D)), ((V)(19D)), ((V)(3.5)), ((V)("#f2c255")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
}, 1, "build", true)).V;
}, 1, "bush", true)).Put("stage", Fn((V _arrowThis1757, int _argc1750, V S_1756, V _a1753, V _a1754, V _a1755, V[] _rest1751) => {
return NewObj(5).Put("w", ((V)(220D))).Put("d", ((V)(90D))).Put("act", ((V)("perform"))).Put("seats", Arr(NewObj(4).Put("x", ((V)((-50D)))).Put("z", ((V)(0D))).Put("h", ((V)(24D))).Put("k", ((V)("perform"))).V, NewObj(4).Put("x", ((V)(50D))).Put("z", ((V)(0D))).Put("h", ((V)(24D))).Put("k", ((V)("perform"))).V)).Put("build", Fn((V _arrowThis1765, int _argc1758, V P_1764, V _a1761, V _a1762, V _a1763, V[] _rest1759) => {
V k_1766 = default;
V o_1767 = default;
k_1766 = Get(S_1756, "k");
o_1767 = Arr();
if (SEqS(k_1766, "junk")) {
Invoke(Arr(((V)((-82D))), ((V)((-27D))), ((V)(28D)), ((V)(83D))), "forEach", Fn((V _arrowThis1776, int _argc1768, V x_1774, V i_1775, V _a1772, V _a1773, V[] _rest1769) => {
return Invoke(o_1767, "push", Call(box_11, V.Undef, x_1774, ((V)(0D)), ((V)(0D)), ((V)(54D)), ((V)(18D)), ((V)(88D)), (NumTruthy((ToNum(i_1775) % 2D)) ? OLD_33 : OLD2_34), NewObj(1).Put("r", ((V)(1D))).V), Call(box_11, V.Undef, x_1774, ((V)(6D)), ((V)(44.4)), ((V)(50D)), ((V)(3D)), ((V)(0.8)), ((V)("#7d6248"))));
}, 2, "", true));
Invoke(o_1767, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(18D)), ((V)(0D)), ((V)(222D)), ((V)(4D)), ((V)(90D)), ((V)("#b89a74")), NewObj(1).Put("r", ((V)(2D))).V), Call(cyl_13, V.Undef, ((V)((-90D))), ((V)(22D)), ((V)((-36D))), ((V)(1.4)), ((V)(50D)), ((V)("#8a8f94")), NewObj(1).Put("n", ((V)(6D))).V), Call(ball_14, V.Undef, ((V)((-90D))), ((V)(70D)), ((V)((-36D))), ((V)(5D)), ((V)("#fff1a8")), NewObj(1).Put("emit", ((V)(1D))).V));
return o_1767;
}
Invoke(o_1767, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(220D)), ((V)(24D)), ((V)(90D)), (SEqS(k_1766, "royal") ? ((V)("#f4f1ea")) : Get(P_1764, "a")), NewObj(2).Put("r", ((V)(12D))).Put("bev", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(52D)), ((V)(70D)), ((V)(10D)), ((V)(16D)), (SEqS(k_1766, "royal") ? GOLD_27 : Get(P_1764, "aD")), NewObj(1).Put("r", ((V)(4D))).V));
if (SEqS(k_1766, "royal")) {
InvokeSpread(o_1767, "push", new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(23D)), ((V)(0D)), ((V)(214D)), ((V)(2D)), ((V)(84D)), Get(P_1764, "a"), NewObj(1).Put("r", ((V)(10D))).V)).Add(Call(slab_15, V.Undef, ((V)((-96D))), ((V)(24D)), ((V)((-40D))), ((V)(30D)), ((V)(120D)), ((V)(8D)), Get(P_1764, "a"), NewObj(2).Put("r", ((V)(10D))).Put("soft", ((V)(1D))).V)).Add(Call(slab_15, V.Undef, ((V)(96D)), ((V)(24D)), ((V)((-40D))), ((V)(30D)), ((V)(120D)), ((V)(8D)), Get(P_1764, "a"), NewObj(2).Put("r", ((V)(10D))).Put("soft", ((V)(1D))).V)).Add(Call(slab_15, V.Undef, ((V)(0D)), ((V)(136D)), ((V)((-40D))), ((V)(222D)), ((V)(18D)), ((V)(10D)), Get(P_1764, "a"), NewObj(2).Put("r", ((V)(6D))).Put("soft", ((V)(1D))).V)).Spread(Invoke(Arr(((V)((-60D))), ((V)((-20D))), ((V)(20D)), ((V)(60D))), "map", Fn((V _arrowThis1784, int _argc1777, V x_1783, V _a1780, V _a1781, V _a1782, V[] _rest1778) => {
return Call(jewel_42, V.Undef, x_1783, ((V)(150D)), ((V)((-38D))), ((V)(4D)));
}, 1, "", true))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(224D)), ((V)(4D)), ((V)(94D)), GOLD_27, NewObj(1).Put("r", ((V)(12D))).V)).V);
} else {
InvokeSpread(o_1767, "push", new ArrBuilder().Spread(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(4D)), ((V)(5D)), ((V)(6D)), ((V)(7D)), ((V)(8D))), "map", Fn((V _arrowThis1792, int _argc1785, V i_1791, V _a1788, V _a1789, V _a1790, V[] _rest1786) => {
return Call(ball_14, V.Undef, ((V)(((-96D) + (24D * ToNum(i_1791))))), ((V)(8D)), ((V)(45.4)), ((V)(3.5)), (SEqS(k_1766, "candy") ? GetIdx(NE_26, (ToNum(Add(i_1791, ((V)(2D)))) % 6D)) : GetIdx(NE_26, (ToNum(i_1791) % 6D))), NewObj(3).Put("emit", ((V)(1D))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V);
}, 1, "", true))).V);
}
if (SEqS(k_1766, "mod")) {
Invoke(o_1767, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(24D)), ((V)(44D)), ((V)(216D)), ((V)(2D)), ((V)(2D)), ((V)("#4fe0d0")), NewObj(1).Put("emit", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(24D)), ((V)((-44D))), ((V)(216D)), ((V)(2D)), ((V)(2D)), ((V)("#8f7bff")), NewObj(1).Put("emit", ((V)(1D))).V));
}
if (SEqS(k_1766, "candy")) {
InvokeSpread(o_1767, "push", new ArrBuilder().Spread(Call(spr_39, V.Undef, ((V)(0D)), ((V)(24D)), ((V)(0D)), ((V)(180D)), ((V)(60D)), ((V)(14D)))).Spread(Call(drips_40, V.Undef, ((V)(0D)), ((V)(24D)), ((V)(46D)), ((V)(200D)), Get(P_1764, "aL"), ((V)(10D)))).V);
}
return o_1767;
return default;
}, 1, "build", true)).V;
}, 1, "stage", true)).Put("speaker", Fn((V _arrowThis1800, int _argc1793, V S_1799, V _a1796, V _a1797, V _a1798, V[] _rest1794) => {
return NewObj(3).Put("w", ((V)((SEqS(Get(S_1799, "k"), "junk") ? 70D : 54D)))).Put("d", ((V)(40D))).Put("build", Fn((V _arrowThis1808, int _argc1801, V P_1807, V _a1804, V _a1805, V _a1806, V[] _rest1802) => {
V k_1809 = default;
V body_1810 = default;
V cone_1811 = default;
V o_1812 = default;
V ys_1813 = default;
k_1809 = Get(S_1799, "k");
if (SEqS(k_1809, "junk")) {
return Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(70D)), ((V)(36D)), ((V)(30D)), ((V)("#5a5f6a")), NewObj(2).Put("r", ((V)(6D))).Put("bev", ((V)(2D))).V), Call(disc_18, V.Undef, ((V)((-18D))), ((V)(16D)), ((V)(15D)), ((V)(11D)), ((V)(2D)), ((V)("#3b3e46")), NewObj(1).Put("top", ((V)(2D))).V), Call(disc_18, V.Undef, ((V)(18D)), ((V)(16D)), ((V)(15D)), ((V)(11D)), ((V)(2D)), ((V)("#3b3e46")), NewObj(1).Put("top", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(15.2)), ((V)(16D)), ((V)(6D)), ((V)(1D)), ((V)("#9fc6c0")), NewObj(2).Put("r", ((V)(2D))).Put("emit", ((V)(1D))).V), Call(slabX_16, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(0D)), ((V)(50D)), ((V)(4D)), ((V)(4D)), DK_31, NewObj(1).Put("r", ((V)(2D))).V), Call(cyl_13, V.Undef, ((V)((-24D))), ((V)(36D)), ((V)(0D)), ((V)(2D)), ((V)(6D)), DK_31, NewObj(1).Put("n", ((V)(6D))).V), Call(cyl_13, V.Undef, ((V)(24D)), ((V)(36D)), ((V)(0D)), ((V)(2D)), ((V)(6D)), DK_31, NewObj(1).Put("n", ((V)(6D))).V), Call(patch_41, V.Undef, ((V)((-28D))), ((V)(28D)), ((V)(15.6)), ((V)(8D)), ((V)(6D)), ((V)("#c9a85a"))));
}
body_1810 = (SEqS(k_1809, "royal") ? GOLD_27 : (SEqS(k_1809, "candy") ? Get(P_1807, "a") : (SEqS(k_1809, "mod") ? ((V)("#2f2f3a")) : Get(P_1807, "a"))));
cone_1811 = (SEqS(k_1809, "royal") ? ((V)("#f4f1ea")) : (SEqS(k_1809, "candy") ? Get(P_1807, "b") : ((V)("#5a5f96"))));
o_1812 = Arr((SEqS(k_1809, "candy") ? Call(slab_15, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(54D)), ((V)(100D)), ((V)(40D)), body_1810, NewObj(1).Put("r", ((V)(26D))).V) : Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(54D)), ((V)((SEqS(k_1809, "mod") ? 120D : 96D))), ((V)(40D)), body_1810, NewObj(2).Put("r", ((V)(6D))).Put("bev", ((V)(2D))).V)));
ys_1813 = (SEqS(k_1809, "mod") ? Arr(((V)(96D)), ((V)(64D)), ((V)(30D))) : Arr(((V)(66D)), ((V)(28D))));
Invoke(ys_1813, "forEach", Fn((V _arrowThis1822, int _argc1814, V y_1820, V i_1821, V _a1818, V _a1819, V[] _rest1815) => {
return Invoke(o_1812, "push", Call(disc_18, V.Undef, ((V)(0D)), y_1820, ((V)(20D)), ((V)((SEqN(i_1821, (ToNum(Get(ys_1813, "length")) - 1D)) ? 19D : 14D))), ((V)(2D)), cone_1811, NewObj(1).Put("top", ((V)(3D))).V), Call(disc_18, V.Undef, ((V)(0D)), y_1820, ((V)(22D)), ((V)(6D)), ((V)(1D)), ((V)((SEqS(k_1809, "royal") ? "#8f7bff" : "#4fe0d0"))), NewObj(1).Put("emit", ((V)(1D))).V));
}, 2, "", true));
if (SEqS(k_1809, "royal")) {
Invoke(o_1812, "push", Call(jewel_42, V.Undef, ((V)(0D)), ((V)(96D)), ((V)(0D)), ((V)(7D))));
}
if (SEqS(k_1809, "candy")) {
InvokeSpread(o_1812, "push", new ArrBuilder().Spread(Invoke(Arr(Arr(((V)((-14D))), ((V)(100D))), Arr(((V)(12D)), ((V)(102D))), Arr(((V)(0D)), ((V)(108D)))), "map", Fn((V _arrowThis1834, int _argc1823, V _a1825, V _a1826, V _a1827, V _a1828, V[] _rest1824) => {
V x_1831 = default;
V y_1833 = default;
{ V _t1829 = ListOf(_a1825);
{ V _t1830 = GetIdx(_t1829, 0D);
x_1831 = _t1830; }
{ V _t1832 = GetIdx(_t1829, 1D);
y_1833 = _t1832; }
}
return Call(ball_14, V.Undef, x_1831, ((V)((ToNum(y_1833) - 10D))), ((V)(0D)), ((V)(12D)), ((V)("#fffdf5")));
}, 1, "", true))).V);
}
if (SEqS(k_1809, "retro")) {
Invoke(o_1812, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(92D)), ((V)(20.4)), ((V)(50D)), ((V)(3D)), ((V)(0.8)), CH_28), Call(box_11, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(20.4)), ((V)(50D)), ((V)(3D)), ((V)(0.8)), CH_28));
}
return o_1812;
return default;
}, 1, "build", true)).V;
}, 1, "speaker", true)).Put("juke", Fn((V _arrowThis1842, int _argc1835, V S_1841, V _a1838, V _a1839, V _a1840, V[] _rest1836) => {
return NewObj(5).Put("w", ((V)(64D))).Put("d", ((V)(44D))).Put("act", ((V)("party"))).Put("glow", Fn((V _arrowThis1850, int _argc1843, V v_1849, V _a1846, V _a1847, V _a1848, V[] _rest1844) => {
return (SEqS(v_1849, "on") ? NewObj(3).Put("y", ((V)(70D))).Put("r", ((V)(95D))).Put("c", ((V)("url(#gNeon)"))).V : V.Null);
}, 1, "glow", true)).Put("build", Fn((V _arrowThis1859, int _argc1851, V P_1857, V v_1858, V _a1855, V _a1856, V[] _rest1852) => {
V k_1860 = default;
V on_1861 = default;
V body_1862 = default;
V glow_1863 = default;
V o_1864 = default;
k_1860 = Get(S_1841, "k");
on_1861 = (SEqS(v_1858, "on") ? V.True : V.False);
if (SEqS(k_1860, "junk")) {
return new ArrBuilder().Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-19D))), ((V)(62D)), ((V)(46D)), ((V)(4D)), Call(shade_23, V.Undef, OLD_33, ((V)(0.85))))).Add(Call(box_11, V.Undef, ((V)((-29D))), ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(46D)), ((V)(40D)), OLD_33)).Add(Call(box_11, V.Undef, ((V)(29D)), ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(46D)), ((V)(40D)), OLD_33)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(62D)), ((V)(4D)), ((V)(40D)), OLD_33)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(42D)), ((V)(0D)), ((V)(62D)), ((V)(4D)), ((V)(40D)), OLD_33)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(46D)), ((V)(0D)), ((V)(56D)), ((V)(12D)), ((V)(38D)), ((V)("#8a5a34")), NewObj(1).Put("r", ((V)(3D))).V)).Add(Call(cyl_13, V.Undef, ((V)((-6D))), ((V)(58D)), ((V)(2D)), ((V)(15D)), ((V)(1.4)), ((V)("#2b2b2b")))).Add(Call(cyl_13, V.Undef, ((V)((-6D))), ((V)(59.4)), ((V)(2D)), ((V)(5D)), ((V)(0.6)), ((V)("#e3946a")))).Add(Call(cyl_13, V.Undef, ((V)(20D)), ((V)(58D)), ((V)(12D)), ((V)(2D)), ((V)(10D)), CH_28, NewObj(1).Put("n", ((V)(6D))).V)).Add(Call(cyl_13, V.Undef, ((V)(14D)), ((V)(58D)), ((V)((-12D))), ((V)(3D)), ((V)(26D)), GOLD_27, NewObj(1).Put("n", ((V)(8D))).V)).Add(Call(cyl_13, V.Undef, ((V)(14D)), ((V)(84D)), ((V)((-12D))), ((V)(16D)), ((V)(14D)), GOLD_27, NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.2))), Arr(((V)(14D)), ((V)(0D)), ((V)(1D))))).V)).Spread(Call(book_44, V.Undef, ((V)(0D)), ((V)(4D)), ((V)((-2D))), Arr(((V)("#8fa8a0")), ((V)("#c9a85a"))))).V;
}
body_1862 = (SEqS(k_1860, "royal") ? ((V)("#f4f1ea")) : (SEqS(k_1860, "candy") ? Get(P_1857, "b") : ((V)("#a86b36"))));
glow_1863 = (SEqS(k_1860, "candy") ? Get(P_1857, "a") : ((V)((SEqS(k_1860, "royal") ? "#8f7bff" : "#ffa940"))));
o_1864 = Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(64D)), ((V)(70D)), ((V)(44D)), body_1862, NewObj(2).Put("r", ((V)(8D))).Put("bev", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(22D)), ((V)(52D)), ((V)(58D)), ((V)(1.5)), glow_1863, NewObj(1).Put("r", ((V)(6D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(70D)), ((V)(0D)), ((V)(64D)), ((V)(36D)), ((V)(44D)), glow_1863, NewObj(2).Put("r", ((V)(32D))).Put("soft", ((V)(1D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(74D)), ((V)(22.6)), ((V)(46D)), ((V)(26D)), ((V)(1.5)), ((V)((Truthy(on_1861) ? "#fff1a8" : "#ffe2a6"))), NewObj(2).Put("r", ((V)(23D))).Put("emit", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(23.4)), ((V)(40D)), ((V)(18D)), ((V)(0.8)), Call(shade_23, V.Undef, body_1862, ((V)(0.6))), NewObj(1).Put("r", ((V)(3D))).V), Call(disc_18, V.Undef, ((V)(0D)), ((V)(46D)), ((V)(22.8)), ((V)(8D)), ((V)(1.2)), ((V)("#3b2e28"))), Call(disc_18, V.Undef, ((V)(0D)), ((V)(46D)), ((V)(24D)), ((V)(2.5)), ((V)(0.8)), GOLD_27));
if (SEqS(k_1860, "royal")) {
Invoke(o_1864, "push", Call(prismZ_25, V.Undef, ((V)((-4D))), ((V)(4D)), Invoke(Arr(Arr(((V)(0D)), ((V)(122D))), Arr(((V)(5D)), ((V)(110D))), Arr(((V)(16D)), ((V)(108D))), Arr(((V)(7D)), ((V)(100D))), Arr(((V)(10D)), ((V)(88D))), Arr(((V)(0D)), ((V)(95D))), Arr(((V)((-10D))), ((V)(88D))), Arr(((V)((-7D))), ((V)(100D))), Arr(((V)((-16D))), ((V)(108D))), Arr(((V)((-5D))), ((V)(110D)))), "filter", Fn((V _arrowThis1873, int _argc1865, V p_1871, V i_1872, V _a1869, V _a1870, V[] _rest1866) => {
return (((ToNum(i_1872) % 2D) == 0D) ? V.True : V.False);
}, 2, "", true)), GOLD_27), Call(jewel_42, V.Undef, ((V)(0D)), ((V)(106D)), ((V)(0D)), ((V)(4D))), Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(66D)), ((V)(4D)), ((V)(46D)), GOLD_27, NewObj(1).Put("r", ((V)(8D))).V));
}
if (SEqS(k_1860, "candy")) {
InvokeSpread(o_1864, "push", new ArrBuilder().Spread(Call(spr_39, V.Undef, ((V)(0D)), ((V)(104D)), ((V)(0D)), ((V)(40D)), ((V)(30D)), ((V)(7D)))).Add(Call(ball_14, V.Undef, ((V)(0D)), ((V)(104D)), ((V)(0D)), ((V)(8D)), ((V)("#e2554a")))).V);
}
if (SEqS(k_1860, "retro")) {
Invoke(o_1864, "push", Call(box_11, V.Undef, ((V)((-26D))), ((V)(6D)), ((V)(23D)), ((V)(3D)), ((V)(58D)), ((V)(1D)), CH_28), Call(box_11, V.Undef, ((V)(26D)), ((V)(6D)), ((V)(23D)), ((V)(3D)), ((V)(58D)), ((V)(1D)), CH_28));
}
return o_1864;
return default;
}, 2, "build", true)).V;
}, 1, "juke", true)).Put("arcade", Fn((V _arrowThis1881, int _argc1874, V S_1880, V _a1877, V _a1878, V _a1879, V[] _rest1875) => {
return NewObj(5).Put("w", ((V)(70D))).Put("d", ((V)(60D))).Put("act", ((V)("play"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(54D))).V).Put("build", Fn((V _arrowThis1889, int _argc1882, V P_1888, V _a1885, V _a1886, V _a1887, V[] _rest1883) => {
V k_1890 = default;
V body_1891 = default;
V o_1892 = default;
k_1890 = Get(S_1880, "k");
body_1891 = (SEqS(k_1890, "candy") ? Get(P_1888, "a") : (SEqS(k_1890, "royal") ? ((V)("#f4f1ea")) : Get(P_1888, "a")));
o_1892 = Arr();
Invoke(o_1892, "push", Call(prism_24, V.Undef, ((V)((-30D))), ((V)(30D)), Arr(Arr(((V)((-24D))), ((V)(0D))), Arr(((V)(24D)), ((V)(0D))), Arr(((V)(24D)), ((V)(62D))), Arr(((V)(14D)), ((V)(112D))), Arr(((V)((-24D))), ((V)(120D)))), body_1891), Call(box_11, V.Undef, ((V)((-31D))), ((V)(0D)), ((V)(0D)), ((V)(2D)), ((V)(118D)), ((V)(48D)), (SEqS(k_1890, "royal") ? GOLD_27 : Call(shade_23, V.Undef, body_1891, ((V)(0.8))))), Call(box_11, V.Undef, ((V)(31D)), ((V)(0D)), ((V)(0D)), ((V)(2D)), ((V)(118D)), ((V)(48D)), (SEqS(k_1890, "royal") ? GOLD_27 : Call(shade_23, V.Undef, body_1891, ((V)(0.8))))));
Invoke(o_1892, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(74D)), ((V)(14D)), ((V)(46D)), ((V)(32D)), ((V)(2D)), ((V)("#2b2b33")), NewObj(1).Put("r", ((V)(4D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(77D)), ((V)(15.2)), ((V)(40D)), ((V)(26D)), ((V)(0.6)), ((V)((SEqS(k_1890, "candy") ? "#bfe4ff" : "#5ad0ff"))), NewObj(2).Put("r", ((V)(3D))).Put("emit", ((V)(1D))).V), Call(box_11, V.Undef, ((V)((-6D))), ((V)(86D)), ((V)(15.8)), ((V)(14D)), ((V)(6D)), ((V)(0.4)), ((V)("#ffd23f")), NewObj(2).Put("r", ((V)(2D))).Put("emit", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(60D)), ((V)(22D)), ((V)(56D)), ((V)(5D)), ((V)(18D)), DK_31, NewObj(1).Put("r", ((V)(3D))).V), Call(ball_14, V.Undef, ((V)((-14D))), ((V)(65D)), ((V)(24D)), ((V)(3D)), ((V)("#e2554a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(cyl_13, V.Undef, ((V)((-14D))), ((V)(65D)), ((V)(24D)), ((V)(1D)), ((V)(6D)), DK_31, NewObj(1).Put("n", ((V)(6D))).V), Call(ball_14, V.Undef, ((V)(6D)), ((V)(65D)), ((V)(24D)), ((V)(3D)), GetIdx(NE_26, 0D), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(ball_14, V.Undef, ((V)(16D)), ((V)(65D)), ((V)(22D)), ((V)(3D)), GetIdx(NE_26, 1D), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(110D)), ((V)(4D)), ((V)(50D)), ((V)(12D)), ((V)(2D)), ((V)("#fff1a8")), NewObj(2).Put("r", ((V)(3D))).Put("emit", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(20D)), ((V)(24.2)), ((V)(20D)), ((V)(14D)), ((V)(0.8)), ((V)("#3b3b3b")), NewObj(1).Put("r", ((V)(2D))).V));
if (SEqS(k_1890, "candy")) {
InvokeSpread(o_1892, "push", new ArrBuilder().Spread(Call(drips_40, V.Undef, ((V)(0D)), ((V)(120D)), ((V)((-6D))), ((V)(46D)), Get(P_1888, "b"), ((V)(5D)))).Add(Call(ball_14, V.Undef, ((V)(0D)), ((V)(118D)), ((V)((-6D))), ((V)(8D)), ((V)("#e2554a")))).V);
}
if (SEqS(k_1890, "royal")) {
Invoke(o_1892, "push", Call(jewel_42, V.Undef, ((V)(0D)), ((V)(122D)), ((V)((-14D))), ((V)(6D))));
}
return o_1892;
return default;
}, 1, "build", true)).V;
}, 1, "arcade", true)).Put("dj", Fn((V _arrowThis1900, int _argc1893, V S_1899, V _a1896, V _a1897, V _a1898, V[] _rest1894) => {
return NewObj(5).Put("w", ((V)(130D))).Put("d", ((V)(56D))).Put("act", ((V)("party"))).Put("glow", Fn((V _arrowThis1908, int _argc1901, V v_1907, V _a1904, V _a1905, V _a1906, V[] _rest1902) => {
return (SEqS(v_1907, "on") ? NewObj(3).Put("y", ((V)(60D))).Put("r", ((V)(100D))).Put("c", ((V)("url(#gNeon)"))).V : V.Null);
}, 1, "glow", true)).Put("build", Fn((V _arrowThis1917, int _argc1909, V P_1915, V v_1916, V _a1913, V _a1914, V[] _rest1910) => {
V k_1918 = default;
V on_1919 = default;
V body_1920 = default;
V o_1921 = default;
k_1918 = Get(S_1899, "k");
on_1919 = (SEqS(v_1916, "on") ? V.True : V.False);
body_1920 = (SEqS(k_1918, "royal") ? ((V)("#f4f1ea")) : (SEqS(k_1918, "mod") ? ((V)("#2f2f3a")) : Get(P_1915, "a")));
o_1921 = Arr();
Invoke(o_1921, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(130D)), ((V)(50D)), ((V)(52D)), body_1920, NewObj(2).Put("r", ((V)(6D))).Put("bev", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(50D)), ((V)(0D)), ((V)(134D)), ((V)(6D)), ((V)(56D)), (SEqS(k_1918, "royal") ? GOLD_27 : ((V)("#3d4048"))), NewObj(1).Put("r", ((V)(4D))).V));
{
double i_1922 = 0;
i_1922 = 0D;
while (true) {
if (!((i_1922 < 6D))) break;
Invoke(o_1921, "push", Call(box_11, V.Undef, ((V)(((-50D) + (i_1922 * 20D)))), ((V)(10D)), ((V)(26.4)), ((V)(16D)), ((V)(30D)), ((V)(1D)), (SEqS(k_1918, "royal") ? GetIdx(Arr(((V)("#cfe6f7")), ((V)("#ffffff"))), (i_1922 % 2D)) : GetIdx(NE_26, i_1922)), NewObj(2).Put("r", ((V)(3D))).Put("emit", ((V)((Truthy(on_1919) ? 1D : 0D)))).V));
i_1922++;
}
}
Invoke(Arr(((V)((-34D))), ((V)(34D))), "forEach", Fn((V _arrowThis1931, int _argc1924, V x_1930, V _a1927, V _a1928, V _a1929, V[] _rest1925) => {
return Invoke(o_1921, "push", Call(cyl_13, V.Undef, x_1930, ((V)(56D)), ((V)(4D)), ((V)(18D)), ((V)(2D)), ((V)("#2b2b2b"))), Call(cyl_13, V.Undef, x_1930, ((V)(58D)), ((V)(4D)), ((V)(6D)), ((V)(0.6)), (SEqS(k_1918, "royal") ? GOLD_27 : ((V)("#4fe0d0"))), NewObj(1).Put("emit", ((V)(1D))).V), Call(cyl_13, V.Undef, Add(x_1930, ((V)(14D))), ((V)(58D)), ((V)((-8D))), ((V)(1.4)), ((V)(6D)), CH_28, NewObj(1).Put("n", ((V)(6D))).V));
}, 1, "", true));
Invoke(o_1921, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(56D)), ((V)(4D)), ((V)(24D)), ((V)(3D)), ((V)(20D)), ((V)("#5a5f6a")), NewObj(1).Put("r", ((V)(2D))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(56D)), ((V)((-18D))), ((V)(34D)), ((V)(22D)), ((V)(2D)), ((V)("#3d4048")), NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(59D)), ((V)((-16.6))), ((V)(30D)), ((V)(18D)), ((V)(0.4)), ((V)("#6cc6ee")), NewObj(2).Put("r", ((V)(2D))).Put("emit", ((V)(1D))).V));
if (SEqS(k_1918, "royal")) {
Invoke(o_1921, "push", Call(jewel_42, V.Undef, ((V)((-60D))), ((V)(56D)), ((V)(22D)), ((V)(4D))), Call(jewel_42, V.Undef, ((V)(60D)), ((V)(56D)), ((V)(22D)), ((V)(4D))));
}
if (SEqS(k_1918, "mod")) {
Invoke(o_1921, "push", Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(26.6)), ((V)(126D)), ((V)(3D)), ((V)(0.6)), ((V)("#4fe0d0")), NewObj(1).Put("emit", ((V)(1D))).V));
}
return o_1921;
return default;
}, 2, "build", true)).V;
}, 1, "dj", true)).Put("pillar", Fn((V _arrowThis1939, int _argc1932, V S_1938, V _a1935, V _a1936, V _a1937, V[] _rest1933) => {
return NewObj(5).Put("w", ((V)(44D))).Put("d", ((V)(44D))).Put("round", ((V)(1D))).Put("glow", Fn((V _arrowThis1946, int _argc1940, V _a1942, V _a1943, V _a1944, V _a1945, V[] _rest1941) => {
return NewObj(3).Put("y", ((V)(70D))).Put("r", ((V)(70D))).Put("c", ((V)("url(#gNeon)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis1954, int _argc1947, V P_1953, V _a1950, V _a1951, V _a1952, V[] _rest1948) => {
V k_1955 = default;
V c_1956 = default;
V o_1957 = default;
k_1955 = Get(S_1938, "k");
c_1956 = (SEqS(k_1955, "royal") ? ((V)("#cfe6f7")) : (SEqS(k_1955, "mod") ? ((V)("#4fe0d0")) : Get(P_1953, "a")));
o_1957 = Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(20D)), ((V)(8D)), (SEqS(k_1955, "royal") ? GOLD_27 : DK_31)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(0D)), ((V)(15D)), ((V)(110D)), c_1956, NewObj(2).Put("n", ((V)(16D))).Put("emit", ((V)(1D))).V), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(118D)), ((V)(0D)), ((V)(20D)), ((V)(8D)), (SEqS(k_1955, "royal") ? GOLD_27 : DK_31)));
{
double y_1958 = 0;
y_1958 = 22D;
while (true) {
if (!((y_1958 < 118D))) break;
Invoke(o_1957, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(y_1958)), ((V)(0D)), ((V)(15.6)), ((V)(2D)), (SEqS(k_1955, "candy") ? GetIdx(NE_26, (((double)(ToInt32((y_1958 / 18D)) | ToInt32(0D))) % 6D)) : Call(mix_22, V.Undef, c_1956, ((V)("#ffffff")), ((V)(0.5)))), NewObj(2).Put("n", ((V)(16D))).Put("emit", ((V)(1D))).V));
y_1958 = (y_1958 + 18D);
}
}
if (SEqS(k_1955, "royal")) {
Invoke(o_1957, "push", Call(jewel_42, V.Undef, ((V)(0D)), ((V)(126D)), ((V)(0D)), ((V)(8D))));
}
if (SEqS(k_1955, "candy")) {
Invoke(o_1957, "push", Call(ball_14, V.Undef, ((V)(0D)), ((V)(126D)), ((V)(0D)), ((V)(14D)), Get(P_1953, "b")));
}
return o_1957;
return default;
}, 1, "build", true)).V;
}, 1, "pillar", true)).Put("bar", Fn((V _arrowThis1967, int _argc1960, V S_1966, V _a1963, V _a1964, V _a1965, V[] _rest1961) => {
return NewObj(5).Put("w", ((V)(140D))).Put("d", ((V)(56D))).Put("act", ((V)("snack"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(54D))).V).Put("build", Fn((V _arrowThis1975, int _argc1968, V P_1974, V _a1971, V _a1972, V _a1973, V[] _rest1969) => {
V o_1976 = default;
o_1976 = Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(136D)), ((V)(50D)), ((V)(48D)), Get(P_1974, "a"), NewObj(2).Put("r", ((V)(8D))).Put("bev", ((V)(2D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(50D)), ((V)(0D)), ((V)(140D)), ((V)(6D)), ((V)(54D)), (SEqS(Get(P_1974, "b"), "#fffaf1") ? CR_29 : Get(P_1974, "b")), NewObj(1).Put("r", ((V)(6D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(24.4)), ((V)(130D)), ((V)(3D)), ((V)(0.8)), CH_28), Call(box_11, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(24.4)), ((V)(130D)), ((V)(3D)), ((V)(0.8)), CH_28));
Invoke(Arr(((V)((-46D))), ((V)((-24D)))), "forEach", Fn((V _arrowThis1985, int _argc1977, V x_1983, V i_1984, V _a1981, V _a1982, V[] _rest1978) => {
return Invoke(o_1976, "push", Call(cyl_13, V.Undef, x_1983, ((V)(56D)), ((V)(6D)), ((V)(6D)), ((V)(18D)), ((V)("#e2554a")), NewObj(2).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(18D)), ((V)(0D)), ((V)(1D))))).Put("n", ((V)(10D))).V), Call(cyl_13, V.Undef, x_1983, ((V)(74D)), ((V)(6D)), ((V)(6.5)), ((V)(3D)), CR_29, NewObj(1).Put("n", ((V)(10D))).V), Call(cyl_13, V.Undef, Add(x_1983, ((V)(3D))), ((V)(74D)), ((V)(6D)), ((V)(0.8)), ((V)(12D)), ((V)("#e2554a")), NewObj(1).Put("n", ((V)(4D))).V), Call(ball_14, V.Undef, x_1983, ((V)(77D)), ((V)(6D)), ((V)(2.4)), ((V)("#e2554a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}, 2, "", true));
InvokeSpread(o_1976, "push", new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(20D)), ((V)(56D)), ((V)(0D)), ((V)(13D)), ((V)(16D)), ((V)("#e2554a")), NewObj(1).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.75))), Arr(((V)(16D)), ((V)(0D)), ((V)(1D))))).V)).Spread(Invoke(Arr(Arr(((V)(16D)), ((V)(0D))), Arr(((V)(24D)), ((V)(3D))), Arr(((V)(20D)), ((V)((-4D)))), Arr(((V)(14D)), ((V)(4D))), Arr(((V)(26D)), ((V)((-2D))))), "map", Fn((V _arrowThis1997, int _argc1986, V _a1988, V _a1989, V _a1990, V _a1991, V[] _rest1987) => {
V x_1994 = default;
V z_1996 = default;
{ V _t1992 = ListOf(_a1988);
{ V _t1993 = GetIdx(_t1992, 0D);
x_1994 = _t1993; }
{ V _t1995 = GetIdx(_t1992, 1D);
z_1996 = _t1995; }
}
return Call(ball_14, V.Undef, x_1994, ((V)(70D)), z_1996, ((V)(4D)), ((V)("#fff6d6")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V);
}, 1, "", true))).Add(Call(box_11, V.Undef, ((V)(48D)), ((V)(56D)), ((V)(0D)), ((V)(30D)), ((V)(3D)), ((V)(20D)), CR_29, NewObj(1).Put("r", ((V)(2D))).V)).Add(Call(ball_14, V.Undef, ((V)(42D)), ((V)(59D)), ((V)(0D)), ((V)(5D)), ((V)("#c98d52")), NewObj(1).Put("sy", ((V)(0.6))).V)).Add(Call(ball_14, V.Undef, ((V)(54D)), ((V)(59D)), ((V)(2D)), ((V)(5D)), ((V)("#c98d52")), NewObj(1).Put("sy", ((V)(0.6))).V)).V);
return o_1976;
return default;
}, 1, "build", true)).V;
}, 1, "bar", true)).V;
prismX_49 = prism_24;
S__50 = ((V)("style"));
Y__51 = ((V)("backyard"));
LV_52 = Arr(Arr(Arr(((V)("saggySofa")), ((V)("Saggy Sofa")), ((V)("living")), ((V)("sofa")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("crateTable")), ((V)("Crate Table")), ((V)("living")), ((V)("coffee")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("boxTV")), ((V)("Box TV")), ((V)("living")), ((V)("tv")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("dentedBowl")), ((V)("Dented Bowl")), ((V)("living")), ((V)("bowl")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("w_peel")), ((V)("Peeling Wallpaper")), S__50, ((V)("s:wall")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("f_boards")), ((V)("Creaky Boards")), S__50, ((V)("s:floor")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("win_crack")), ((V)("Cracked Window")), S__50, ((V)("s:win")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("l_bulb")), ((V)("Bare Bulb")), S__50, ((V)("s:light")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V)), Arr(Arr(((V)("icebox")), ((V)("Old Icebox")), ((V)("kitchen")), ((V)("fridge")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("rustyStove")), ((V)("Rusty Stove")), ((V)("kitchen")), ((V)("stove")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("wobblyCounter")), ((V)("Wobbly Counter")), ((V)("kitchen")), ((V)("counter")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("crateStool")), ((V)("Milk Crate Stool")), ((V)("kitchen")), ((V)("stool")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("patchedChair")), ((V)("Patched Armchair")), ((V)("living")), ((V)("armchair")), ((V)("junk"))), Arr(((V)("ragRug")), ((V)("Rag Rug")), ((V)("living")), ((V)("rug")), ((V)("junk"))), Arr(((V)("d_plank")), ((V)("Plank Door")), S__50, ((V)("s:door")), ((V)("junk"))), Arr(((V)("tinPlant")), ((V)("Tin Can Sprout")), ((V)("living")), ((V)("plant")), ((V)("junk")))), Arr(Arr(((V)("palletShelf")), ((V)("Crate Shelf")), ((V)("living")), ((V)("shelf")), ((V)("junk"))), Arr(((V)("thriftLamp")), ((V)("Thrift Lamp")), ((V)("living")), ((V)("lamp")), ((V)("junk"))), Arr(((V)("foldTable")), ((V)("Folding Table")), ((V)("kitchen")), ((V)("table")), ((V)("junk"))), Arr(((V)("oddChair")), ((V)("Odd Chair")), ((V)("kitchen")), ((V)("chair")), ((V)("junk"))), Arr(((V)("bucketSink")), ((V)("Bucket Sink")), ((V)("kitchen")), ((V)("counter")), ((V)("junk")), NewObj(1).Put("sink", ((V)(1D))).V), Arr(((V)("w_plaster")), ((V)("Patched Plaster")), S__50, ((V)("s:wall")), ((V)("junk"))), Arr(((V)("f_lino")), ((V)("Old Linoleum")), S__50, ((V)("s:floor")), ((V)("junk"))), Arr(((V)("a_cards")), ((V)("Postcard Wall")), S__50, ((V)("s:art")), ((V)("junk")))), Arr(Arr(((V)("washtub")), ((V)("Tin Washtub")), ((V)("bathroom")), ((V)("tub")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("chipBasin")), ((V)("Chipped Basin")), ((V)("bathroom")), ((V)("bsink")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("oldBasket")), ((V)("Laundry Basket")), ((V)("bathroom")), ((V)("basket")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("sackBag")), ((V)("Potato Sack Beanbag")), ((V)("living")), ((V)("pouf")), ((V)("junk"))), Arr(((V)("towelHook")), ((V)("Towel Hooks")), ((V)("bathroom")), ((V)("rack")), ((V)("junk"))), Arr(((V)("l_jar")), ((V)("Jar Lantern")), S__50, ((V)("s:light")), ((V)("junk"))), Arr(((V)("win_oil")), ((V)("Oilcloth Curtains")), S__50, ((V)("s:win")), ((V)("junk"))), Arr(((V)("bathMat")), ((V)("Rubber Bath Mat")), ((V)("bathroom")), ((V)("mat")), ((V)("junk")))), Arr(Arr(((V)("thriftSofa")), ((V)("Thrift Store Sofa")), ((V)("living")), ((V)("sofa")), ((V)("junk")), NewObj(1).Put("fix", ((V)(1D))).V), Arr(((V)("spoolTable")), ((V)("Cable Spool Table")), ((V)("living")), ((V)("coffee")), ((V)("junk")), NewObj(1).Put("spool", ((V)(1D))).V), Arr(((V)("radio")), ((V)("Radio Cabinet")), ((V)("living")), ((V)("tv")), ((V)("junk")), NewObj(1).Put("radio", ((V)(1D))).V), Arr(((V)("paintHutch")), ((V)("Painted Hutch")), ((V)("kitchen")), ((V)("hutch")), ((V)("junk"))), Arr(((V)("bathStool")), ((V)("Bath Stool")), ((V)("bathroom")), ((V)("stool")), ((V)("junk"))), Arr(((V)("oldShower")), ((V)("Pipe Shower")), ((V)("bathroom")), ((V)("shower")), ((V)("junk"))), Arr(((V)("t_ging")), ((V)("Gingham Trim")), S__50, ((V)("s:trim")), ((V)("junk"))), Arr(((V)("a_map")), ((V)("Old Map Poster")), S__50, ((V)("s:art")), ((V)("junk")))), Arr(Arr(((V)("oldMattress")), ((V)("Old Mattress")), ((V)("bedroom")), ((V)("bed")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("crateStand")), ((V)("Crate Nightstand")), ((V)("bedroom")), ((V)("nightstand")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("rickWard")), ((V)("Rickety Wardrobe")), ((V)("bedroom")), ((V)("wardrobe")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("floralSofa")), ((V)("Floral Loveseat")), ((V)("living")), ((V)("sofa")), ((V)("cot"))), Arr(((V)("ginghamChair")), ((V)("Gingham Armchair")), ((V)("living")), ((V)("armchair")), ((V)("cot"))), Arr(((V)("w_daisy")), ((V)("Daisy Wallpaper")), S__50, ((V)("s:wall")), ((V)("cot"))), Arr(((V)("f_oak")), ((V)("Honey Oak Floor")), S__50, ((V)("s:floor")), ((V)("cot"))), Arr(((V)("win_lace")), ((V)("Lace Curtains")), S__50, ((V)("s:win")), ((V)("cot")))), Arr(Arr(((V)("cotFridge")), ((V)("Butter Fridge")), ((V)("kitchen")), ((V)("fridge")), ((V)("cot"))), Arr(((V)("enamelStove")), ((V)("Enamel Stove")), ((V)("kitchen")), ((V)("stove")), ((V)("cot"))), Arr(((V)("farmCounter")), ((V)("Farmhouse Counter")), ((V)("kitchen")), ((V)("counter")), ((V)("cot"))), Arr(((V)("cotBed")), ((V)("Patchwork Bed")), ((V)("bedroom")), ((V)("bed")), ((V)("cot"))), Arr(((V)("quiltChest")), ((V)("Quilt Chest")), ((V)("bedroom")), ((V)("chest")), ((V)("cot"))), Arr(((V)("braidRug")), ((V)("Braided Rug")), ((V)("living")), ((V)("rug")), ((V)("cot"))), Arr(((V)("a_flowers")), ((V)("Pressed Flowers")), S__50, ((V)("s:art")), ((V)("cot"))), Arr(((V)("l_wicker")), ((V)("Wicker Pendant")), S__50, ((V)("s:light")), ((V)("cot")))), Arr(Arr(((V)("tireSwing")), ((V)("Tire Swing")), Y__51, ((V)("swing")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("oldSandbox")), ((V)("Old Sandbox")), Y__51, ((V)("sandbox")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("leakyPool")), ((V)("Leaky Paddling Pool")), Y__51, ((V)("pool")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("y_picket")), ((V)("Picket Fence")), Y__51, ((V)("s:fence")), ((V)("cot"))), Arr(((V)("g_clover")), ((V)("Clover Lawn")), Y__51, ((V)("s:ground")), ((V)("cot"))), Arr(((V)("cotStand")), ((V)("Cottage Nightstand")), ((V)("bedroom")), ((V)("nightstand")), ((V)("cot"))), Arr(((V)("cotWard")), ((V)("Cottage Wardrobe")), ((V)("bedroom")), ((V)("wardrobe")), ((V)("cot"))), Arr(((V)("wickerChair")), ((V)("Reading Armchair")), ((V)("bedroom")), ((V)("armchair")), ((V)("cot")))), Arr(Arr(((V)("clawTub")), ((V)("Clawfoot Tub")), ((V)("bathroom")), ((V)("tub")), ((V)("cot"))), Arr(((V)("washstand")), ((V)("Washstand")), ((V)("bathroom")), ((V)("bsink")), ((V)("cot"))), Arr(((V)("towelLadder")), ((V)("Towel Stand")), ((V)("bathroom")), ((V)("rack")), ((V)("cot"))), Arr(((V)("swingSet")), ((V)("Wooden Swing Set")), Y__51, ((V)("swing")), ((V)("cot"))), Arr(((V)("gardenBench")), ((V)("Garden Bench")), Y__51, ((V)("bench")), ((V)("cot"))), Arr(((V)("herbBox")), ((V)("Herb Planter")), ((V)("kitchen")), ((V)("plant")), ((V)("cot"))), Arr(((V)("w_tile")), ((V)("Cottage Tiles")), S__50, ((V)("s:wall")), ((V)("cot"))), Arr(((V)("t_pastel")), ((V)("Pastel Trim")), S__50, ((V)("s:trim")), ((V)("cot")))), Arr(Arr(((V)("cotTable")), ((V)("Farm Table")), ((V)("kitchen")), ((V)("table")), ((V)("cot"))), Arr(((V)("ladderChair")), ((V)("Ladder-back Chair")), ((V)("kitchen")), ((V)("chair")), ((V)("cot"))), Arr(((V)("cotShelf")), ((V)("Cottage Bookcase")), ((V)("living")), ((V)("shelf")), ((V)("cot"))), Arr(((V)("fringeLamp")), ((V)("Fringe Lamp")), ((V)("living")), ((V)("lamp")), ((V)("cot"))), Arr(((V)("cotDresser")), ((V)("Chest of Drawers")), ((V)("bedroom")), ((V)("dresser")), ((V)("cot"))), Arr(((V)("win_flower")), ((V)("Flower Box Window")), S__50, ((V)("s:win")), ((V)("cot"))), Arr(((V)("hammock")), ((V)("Rope Hammock")), Y__51, ((V)("hammock")), ((V)("cot"))), Arr(((V)("d_arch")), ((V)("Arched Door")), S__50, ((V)("s:door")), ((V)("cot")))), Arr(Arr(((V)("crateStage")), ((V)("Pallet Stage")), ((V)("dance")), ((V)("stage")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("boombox")), ((V)("Boombox")), ((V)("dance")), ((V)("speaker")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("recPlayer")), ((V)("Record Player")), ((V)("dance")), ((V)("juke")), ((V)("junk")), NewObj(1).Put("start", ((V)(1D))).V), Arr(((V)("boothSofa")), ((V)("Diner Booth Sofa")), ((V)("living")), ((V)("sofa")), ((V)("retro"))), Arr(((V)("vinylChair")), ((V)("Vinyl Armchair")), ((V)("living")), ((V)("armchair")), ((V)("retro"))), Arr(((V)("f_check")), ((V)("Checker Floor")), S__50, ((V)("s:floor")), ((V)("retro"))), Arr(((V)("w_burst")), ((V)("Starburst Wallpaper")), S__50, ((V)("s:wall")), ((V)("retro"))), Arr(((V)("l_neon")), ((V)("Neon Ring Light")), S__50, ((V)("s:light")), ((V)("retro")))), Arr(Arr(((V)("dinerFridge")), ((V)("Diner Fridge")), ((V)("kitchen")), ((V)("fridge")), ((V)("retro"))), Arr(((V)("chromeStove")), ((V)("Chrome Range")), ((V)("kitchen")), ((V)("stove")), ((V)("retro"))), Arr(((V)("sodaCounter")), ((V)("Soda Counter")), ((V)("kitchen")), ((V)("counter")), ((V)("retro"))), Arr(((V)("spinStool")), ((V)("Spin Stool")), ((V)("kitchen")), ((V)("stool")), ((V)("retro"))), Arr(((V)("formicaTable")), ((V)("Formica Table")), ((V)("kitchen")), ((V)("table")), ((V)("retro"))), Arr(((V)("dinerChair")), ((V)("Diner Chair")), ((V)("kitchen")), ((V)("chair")), ((V)("retro"))), Arr(((V)("a_clock")), ((V)("Atomic Clock")), S__50, ((V)("s:art")), ((V)("retro"))), Arr(((V)("win_port")), ((V)("Porthole Window")), S__50, ((V)("s:win")), ((V)("retro")))), Arr(Arr(((V)("jukebox")), ((V)("Jukebox")), ((V)("dance")), ((V)("juke")), ((V)("retro"))), Arr(((V)("arcade")), ((V)("Arcade Cabinet")), ((V)("dance")), ((V)("arcade")), ((V)("retro"))), Arr(((V)("l_disco")), ((V)("Disco Ball")), S__50, ((V)("s:light")), ((V)("retro"))), Arr(((V)("f_lightup")), ((V)("Light-Up Tiles")), S__50, ((V)("s:floor")), ((V)("retro"))), Arr(((V)("retroTV")), ((V)("Rounded TV")), ((V)("living")), ((V)("tv")), ((V)("retro"))), Arr(((V)("lavaLamp")), ((V)("Lava Lamp")), ((V)("living")), ((V)("lamp")), ((V)("retro"))), Arr(((V)("kidneyTable")), ((V)("Boomerang Table")), ((V)("living")), ((V)("coffee")), ((V)("retro"))), Arr(((V)("a_records")), ((V)("Record Wall")), S__50, ((V)("s:art")), ((V)("retro")))), Arr(Arr(((V)("pastelTub")), ((V)("Pastel Tub")), ((V)("bathroom")), ((V)("tub")), ((V)("retro"))), Arr(((V)("mintSink")), ((V)("Diner Sink")), ((V)("bathroom")), ((V)("bsink")), ((V)("retro"))), Arr(((V)("retroBed")), ((V)("Jet-Age Bed")), ((V)("bedroom")), ((V)("bed")), ((V)("retro"))), Arr(((V)("retroStand")), ((V)("Jet-Age Nightstand")), ((V)("bedroom")), ((V)("nightstand")), ((V)("retro"))), Arr(((V)("tulipDesk")), ((V)("Tulip Desk")), ((V)("bedroom")), ((V)("desk")), ((V)("retro"))), Arr(((V)("retroWard")), ((V)("Jet-Age Wardrobe")), ((V)("bedroom")), ((V)("wardrobe")), ((V)("retro"))), Arr(((V)("t_stripe")), ((V)("Racing Stripe Trim")), S__50, ((V)("s:trim")), ((V)("retro"))), Arr(((V)("d_jet")), ((V)("Jet-Age Door")), S__50, ((V)("s:door")), ((V)("retro")))), Arr(Arr(((V)("rocketSlide")), ((V)("Rocket Slide")), Y__51, ((V)("slide")), ((V)("retro"))), Arr(((V)("seesaw")), ((V)("Seesaw")), Y__51, ((V)("seesaw")), ((V)("retro"))), Arr(((V)("kiddiePool")), ((V)("Kiddie Pool")), Y__51, ((V)("pool")), ((V)("retro"))), Arr(((V)("lemonStand")), ((V)("Lemonade Stand")), Y__51, ((V)("stand")), ((V)("retro"))), Arr(((V)("kettleGrill")), ((V)("Kettle Grill")), Y__51, ((V)("grill")), ((V)("retro"))), Arr(((V)("speakerTower")), ((V)("Speaker Tower")), ((V)("dance")), ((V)("speaker")), ((V)("retro"))), Arr(((V)("snackBar")), ((V)("Snack Bar")), ((V)("dance")), ((V)("bar")), ((V)("retro"))), Arr(((V)("yl_tiki")), ((V)("Party String Lights")), Y__51, ((V)("s:ylight")), ((V)("retro")))), Arr(Arr(((V)("sectional")), ((V)("Low Sectional")), ((V)("living")), ((V)("sofa")), ((V)("mod"))), Arr(((V)("loungeChair")), ((V)("Lounge Chair")), ((V)("living")), ((V)("armchair")), ((V)("mod"))), Arr(((V)("slabTable")), ((V)("Slab Coffee Table")), ((V)("living")), ((V)("coffee")), ((V)("mod"))), Arr(((V)("flatTV")), ((V)("Flat TV")), ((V)("living")), ((V)("tv")), ((V)("mod"))), Arr(((V)("cubeShelf")), ((V)("Cube Shelf")), ((V)("living")), ((V)("shelf")), ((V)("mod"))), Arr(((V)("arcLamp")), ((V)("Arc Lamp")), ((V)("living")), ((V)("lamp")), ((V)("mod"))), Arr(((V)("snakePlant")), ((V)("Snake Plant")), ((V)("living")), ((V)("plant")), ((V)("mod"))), Arr(((V)("f_herring")), ((V)("Herringbone Floor")), S__50, ((V)("s:floor")), ((V)("mod")))), Arr(Arr(((V)("smartFridge")), ((V)("Double Fridge")), ((V)("kitchen")), ((V)("fridge")), ((V)("mod"))), Arr(((V)("induction")), ((V)("Induction Range")), ((V)("kitchen")), ((V)("stove")), ((V)("mod"))), Arr(((V)("island")), ((V)("Kitchen Island")), ((V)("kitchen")), ((V)("counter")), ((V)("mod"))), Arr(((V)("barStool")), ((V)("Bar Stool")), ((V)("kitchen")), ((V)("stool")), ((V)("mod"))), Arr(((V)("glassTable")), ((V)("Glass Table")), ((V)("kitchen")), ((V)("table")), ((V)("mod"))), Arr(((V)("shellChair")), ((V)("Moulded Chair")), ((V)("kitchen")), ((V)("chair")), ((V)("mod"))), Arr(((V)("w_linen")), ((V)("Linen Wall")), S__50, ((V)("s:wall")), ((V)("mod"))), Arr(((V)("l_globe")), ((V)("Globe Pendant")), S__50, ((V)("s:light")), ((V)("mod")))), Arr(Arr(((V)("soakTub")), ((V)("Soaking Tub")), ((V)("bathroom")), ((V)("tub")), ((V)("mod"))), Arr(((V)("vanity")), ((V)("Vessel Vanity")), ((V)("bathroom")), ((V)("bsink")), ((V)("mod"))), Arr(((V)("rainShower")), ((V)("Rain Shower")), ((V)("bathroom")), ((V)("shower")), ((V)("mod"))), Arr(((V)("towelRail")), ((V)("Towel Rail")), ((V)("bathroom")), ((V)("rack")), ((V)("mod"))), Arr(((V)("platBed")), ((V)("Platform Bed")), ((V)("bedroom")), ((V)("bed")), ((V)("mod"))), Arr(((V)("floatStand")), ((V)("Pedestal Nightstand")), ((V)("bedroom")), ((V)("nightstand")), ((V)("mod"))), Arr(((V)("slideWard")), ((V)("Sliding Wardrobe")), ((V)("bedroom")), ((V)("wardrobe")), ((V)("mod"))), Arr(((V)("win_big")), ((V)("Picture Window")), S__50, ((V)("s:win")), ((V)("mod")))), Arr(Arr(((V)("trampoline")), ((V)("Trampoline")), Y__51, ((V)("tramp")), ((V)("mod"))), Arr(((V)("modHouse")), ((V)("Modern Playhouse")), Y__51, ((V)("house")), ((V)("mod"))), Arr(((V)("lounger")), ((V)("Sun Lounger")), Y__51, ((V)("bench")), ((V)("mod"))), Arr(((V)("firePit")), ((V)("Fire Pit")), Y__51, ((V)("grill")), ((V)("mod"))), Arr(((V)("splashPool")), ((V)("Splash Pool")), Y__51, ((V)("pool")), ((V)("mod"))), Arr(((V)("y_slat")), ((V)("Slat Fence")), Y__51, ((V)("s:fence")), ((V)("mod"))), Arr(((V)("g_patio")), ((V)("Stone Patio")), Y__51, ((V)("s:ground")), ((V)("mod"))), Arr(((V)("modDesk")), ((V)("Writing Desk")), ((V)("bedroom")), ((V)("desk")), ((V)("mod")))), Arr(Arr(((V)("djBooth")), ((V)("DJ Booth")), ((V)("dance")), ((V)("dj")), ((V)("mod"))), Arr(((V)("ledPillar")), ((V)("LED Pillar")), ((V)("dance")), ((V)("pillar")), ((V)("mod"))), Arr(((V)("glowStage")), ((V)("Glow Stage")), ((V)("dance")), ((V)("stage")), ((V)("mod"))), Arr(((V)("soundTower")), ((V)("Sound Tower")), ((V)("dance")), ((V)("speaker")), ((V)("mod"))), Arr(((V)("a_canvas")), ((V)("Gallery Canvas")), S__50, ((V)("s:art")), ((V)("mod"))), Arr(((V)("t_min")), ((V)("Minimal Trim")), S__50, ((V)("s:trim")), ((V)("mod"))), Arr(((V)("d_flush")), ((V)("Flush Door")), S__50, ((V)("s:door")), ((V)("mod"))), Arr(((V)("lowDresser")), ((V)("Low Dresser")), ((V)("bedroom")), ((V)("dresser")), ((V)("mod")))), Arr(Arr(((V)("marshSofa")), ((V)("Marshmallow Sofa")), ((V)("living")), ((V)("sofa")), ((V)("candy"))), Arr(((V)("gumPouf")), ((V)("Gumdrop Pouf")), ((V)("living")), ((V)("pouf")), ((V)("candy"))), Arr(((V)("macaronTable")), ((V)("Macaron Table")), ((V)("living")), ((V)("coffee")), ((V)("candy"))), Arr(((V)("cloudLamp")), ((V)("Cloud Lamp")), ((V)("living")), ((V)("lamp")), ((V)("candy"))), Arr(((V)("lollyPlant")), ((V)("Lollipop Plant")), ((V)("living")), ((V)("plant")), ((V)("candy"))), Arr(((V)("w_candy")), ((V)("Candy Stripe Wall")), S__50, ((V)("s:wall")), ((V)("candy"))), Arr(((V)("f_wafer")), ((V)("Wafer Floor")), S__50, ((V)("s:floor")), ((V)("candy"))), Arr(((V)("gummyRug")), ((V)("Gummy Rug")), ((V)("living")), ((V)("rug")), ((V)("candy")))), Arr(Arr(((V)("iceFridge")), ((V)("Ice-Cream Fridge")), ((V)("kitchen")), ((V)("fridge")), ((V)("candy"))), Arr(((V)("cupOven")), ((V)("Cupcake Oven")), ((V)("kitchen")), ((V)("stove")), ((V)("candy"))), Arr(((V)("candyCounter")), ((V)("Candy Counter")), ((V)("kitchen")), ((V)("counter")), ((V)("candy"))), Arr(((V)("cookieTable")), ((V)("Cookie Table")), ((V)("kitchen")), ((V)("table")), ((V)("candy"))), Arr(((V)("lollyStool")), ((V)("Lollipop Stool")), ((V)("kitchen")), ((V)("stool")), ((V)("candy"))), Arr(((V)("gumChair")), ((V)("Gumdrop Chair")), ((V)("kitchen")), ((V)("chair")), ((V)("candy"))), Arr(((V)("l_sprinkle")), ((V)("Sprinkle Lights")), S__50, ((V)("s:light")), ((V)("candy"))), Arr(((V)("win_bonbon")), ((V)("Bonbon Window")), S__50, ((V)("s:win")), ((V)("candy")))), Arr(Arr(((V)("bubbleTub")), ((V)("Bubble Tub")), ((V)("bathroom")), ((V)("tub")), ((V)("candy"))), Arr(((V)("gumSink")), ((V)("Gumball Sink")), ((V)("bathroom")), ((V)("bsink")), ((V)("candy"))), Arr(((V)("rainbowShower")), ((V)("Rainbow Shower")), ((V)("bathroom")), ((V)("shower")), ((V)("candy"))), Arr(((V)("taffyRack")), ((V)("Taffy Towel Rack")), ((V)("bathroom")), ((V)("rack")), ((V)("candy"))), Arr(((V)("cloudBed")), ((V)("Cloud Bed")), ((V)("bedroom")), ((V)("bed")), ((V)("candy"))), Arr(((V)("cupStand")), ((V)("Cupcake Nightstand")), ((V)("bedroom")), ((V)("nightstand")), ((V)("candy"))), Arr(((V)("candyWard")), ((V)("Candy Wardrobe")), ((V)("bedroom")), ((V)("wardrobe")), ((V)("candy"))), Arr(((V)("a_rainbow")), ((V)("Rainbow Art")), S__50, ((V)("s:art")), ((V)("candy")))), Arr(Arr(((V)("rainbowSlide")), ((V)("Rainbow Slide")), Y__51, ((V)("slide")), ((V)("candy"))), Arr(((V)("candySwing")), ((V)("Candy Cane Swing")), Y__51, ((V)("swing")), ((V)("candy"))), Arr(((V)("gumballGo")), ((V)("Gumball Spinner")), Y__51, ((V)("merry")), ((V)("candy"))), Arr(((V)("jellyTramp")), ((V)("Jelly Trampoline")), Y__51, ((V)("tramp")), ((V)("candy"))), Arr(((V)("gingerHouse")), ((V)("Gingerbread House")), Y__51, ((V)("house")), ((V)("candy"))), Arr(((V)("lollyTree")), ((V)("Lollipop Tree")), Y__51, ((V)("tree")), ((V)("candy"))), Arr(((V)("y_cane")), ((V)("Candy Cane Fence")), Y__51, ((V)("s:fence")), ((V)("candy"))), Arr(((V)("g_mint")), ((V)("Mint Meadow")), Y__51, ((V)("s:ground")), ((V)("candy")))), Arr(Arr(((V)("jellyStage")), ((V)("Jellybean Stage")), ((V)("dance")), ((V)("stage")), ((V)("candy"))), Arr(((V)("candyJuke")), ((V)("Candy Jukebox")), ((V)("dance")), ((V)("juke")), ((V)("candy"))), Arr(((V)("cloudSpeaker")), ((V)("Cloud Speaker")), ((V)("dance")), ((V)("speaker")), ((V)("candy"))), Arr(((V)("sweetArcade")), ((V)("Sweet Arcade")), ((V)("dance")), ((V)("arcade")), ((V)("candy"))), Arr(((V)("gummyPillar")), ((V)("Gummy Light Pillar")), ((V)("dance")), ((V)("pillar")), ((V)("candy"))), Arr(((V)("t_frost")), ((V)("Frosted Trim")), S__50, ((V)("s:trim")), ((V)("candy"))), Arr(((V)("d_ginger")), ((V)("Gingerbread Door")), S__50, ((V)("s:door")), ((V)("candy"))), Arr(((V)("candyDresser")), ((V)("Candy Dresser")), ((V)("bedroom")), ((V)("dresser")), ((V)("candy")))), Arr(Arr(((V)("throneSofa")), ((V)("Velvet Throne Sofa")), ((V)("living")), ((V)("sofa")), ((V)("royal"))), Arr(((V)("royalChair")), ((V)("Royal Armchair")), ((V)("living")), ((V)("armchair")), ((V)("royal"))), Arr(((V)("marbleTable")), ((V)("Marble Table")), ((V)("living")), ((V)("coffee")), ((V)("royal"))), Arr(((V)("royalTV")), ((V)("Gilded Screen")), ((V)("living")), ((V)("tv")), ((V)("royal"))), Arr(((V)("goldShelf")), ((V)("Golden Bookcase")), ((V)("living")), ((V)("shelf")), ((V)("royal"))), Arr(((V)("candelabra")), ((V)("Candelabra")), ((V)("living")), ((V)("lamp")), ((V)("royal"))), Arr(((V)("palmUrn")), ((V)("Palace Fern")), ((V)("living")), ((V)("plant")), ((V)("royal"))), Arr(((V)("w_damask")), ((V)("Damask Wallpaper")), S__50, ((V)("s:wall")), ((V)("royal")))), Arr(Arr(((V)("royalFridge")), ((V)("Royal Fridge")), ((V)("kitchen")), ((V)("fridge")), ((V)("royal"))), Arr(((V)("palaceRange")), ((V)("Palace Range")), ((V)("kitchen")), ((V)("stove")), ((V)("royal"))), Arr(((V)("marbleCounter")), ((V)("Marble Counter")), ((V)("kitchen")), ((V)("counter")), ((V)("royal"))), Arr(((V)("banquet")), ((V)("Banquet Table")), ((V)("kitchen")), ((V)("table")), ((V)("royal"))), Arr(((V)("throneChair")), ((V)("Throne Chair")), ((V)("kitchen")), ((V)("chair")), ((V)("royal"))), Arr(((V)("velvetStool")), ((V)("Velvet Stool")), ((V)("kitchen")), ((V)("stool")), ((V)("royal"))), Arr(((V)("l_chand")), ((V)("Crystal Chandelier")), S__50, ((V)("s:light")), ((V)("royal"))), Arr(((V)("f_marble")), ((V)("Marble Floor")), S__50, ((V)("s:floor")), ((V)("royal")))), Arr(Arr(((V)("goldTub")), ((V)("Golden Tub")), ((V)("bathroom")), ((V)("tub")), ((V)("royal"))), Arr(((V)("marbleBasin")), ((V)("Marble Basin")), ((V)("bathroom")), ((V)("bsink")), ((V)("royal"))), Arr(((V)("crystalShower")), ((V)("Crystal Shower")), ((V)("bathroom")), ((V)("shower")), ((V)("royal"))), Arr(((V)("canopyBed")), ((V)("Canopy Bed")), ((V)("bedroom")), ((V)("bed")), ((V)("royal"))), Arr(((V)("royalStand")), ((V)("Royal Nightstand")), ((V)("bedroom")), ((V)("nightstand")), ((V)("royal"))), Arr(((V)("armoire")), ((V)("Grand Armoire")), ((V)("bedroom")), ((V)("wardrobe")), ((V)("royal"))), Arr(((V)("win_arch")), ((V)("Palace Window")), S__50, ((V)("s:win")), ((V)("royal"))), Arr(((V)("a_portrait")), ((V)("Royal Portrait")), S__50, ((V)("s:art")), ((V)("royal")))), Arr(Arr(((V)("castleSlide")), ((V)("Castle Slide")), Y__51, ((V)("slide")), ((V)("royal"))), Arr(((V)("royalSwing")), ((V)("Royal Swing")), Y__51, ((V)("swing")), ((V)("royal"))), Arr(((V)("skyFountain")), ((V)("Sky Fountain")), Y__51, ((V)("fountain")), ((V)("royal"))), Arr(((V)("carousel")), ((V)("Carousel")), Y__51, ((V)("merry")), ((V)("royal"))), Arr(((V)("castleHouse")), ((V)("Castle Playhouse")), Y__51, ((V)("house")), ((V)("royal"))), Arr(((V)("topiary")), ((V)("Topiary")), Y__51, ((V)("bush")), ((V)("royal"))), Arr(((V)("y_gold")), ((V)("Golden Gate Fence")), Y__51, ((V)("s:fence")), ((V)("royal"))), Arr(((V)("g_cloud")), ((V)("Cloud Lawn")), Y__51, ((V)("s:ground")), ((V)("royal")))), Arr(Arr(((V)("royalStage")), ((V)("Royal Stage")), ((V)("dance")), ((V)("stage")), ((V)("royal"))), Arr(((V)("starJuke")), ((V)("Star Jukebox")), ((V)("dance")), ((V)("juke")), ((V)("royal"))), Arr(((V)("goldSpeaker")), ((V)("Golden Speaker")), ((V)("dance")), ((V)("speaker")), ((V)("royal"))), Arr(((V)("crystalDJ")), ((V)("Crystal DJ Booth")), ((V)("dance")), ((V)("dj")), ((V)("royal"))), Arr(((V)("skyPillar")), ((V)("Sky Pillar")), ((V)("dance")), ((V)("pillar")), ((V)("royal"))), Arr(((V)("t_gold")), ((V)("Gold Leaf Trim")), S__50, ((V)("s:trim")), ((V)("royal"))), Arr(((V)("d_palace")), ((V)("Palace Door")), S__50, ((V)("s:door")), ((V)("royal"))), Arr(((V)("f_ballroom")), ((V)("Starry Ballroom")), S__50, ((V)("s:floor")), ((V)("royal")))));
HIDDEN_53 = Arr(Arr(((V)("t_scuff")), ((V)("Scuffed Trim")), S__50, ((V)("s:trim")), ((V)("junk"))), Arr(((V)("d_scuff")), ((V)("Scuffed Door")), S__50, ((V)("s:door")), ((V)("junk"))), Arr(((V)("a_none")), ((V)("Bare Wall")), S__50, ((V)("s:art")), ((V)("junk"))), Arr(((V)("y_broken")), ((V)("Broken Fence")), Y__51, ((V)("s:fence")), ((V)("junk"))), Arr(((V)("g_patchy")), ((V)("Patchy Lawn")), Y__51, ((V)("s:ground")), ((V)("junk"))), Arr(((V)("yl_none")), ((V)("No Lights")), Y__51, ((V)("s:ylight")), ((V)("junk"))));
WT_54 = NewObj(61).Put("sofa", ((V)(1.8))).Put("armchair", ((V)(1.3))).Put("coffee", ((V)(1D))).Put("tv", ((V)(1.6))).Put("shelf", ((V)(1.3))).Put("lamp", ((V)(0.8))).Put("plant", ((V)(0.5))).Put("rug", ((V)(0.7))).Put("mat", ((V)(0.5))).Put("pouf", ((V)(0.8))).Put("bowl", ((V)(0.3))).Put("fridge", ((V)(1.8))).Put("stove", ((V)(1.6))).Put("counter", ((V)(1.2))).Put("hutch", ((V)(1.3))).Put("table", ((V)(1.2))).Put("chair", ((V)(0.7))).Put("stool", ((V)(0.5))).Put("tub", ((V)(2D))).Put("bsink", ((V)(1.1))).Put("basket", ((V)(0.4))).Put("rack", ((V)(0.5))).Put("shower", ((V)(1.6))).Put("bed", ((V)(2D))).Put("nightstand", ((V)(0.7))).Put("wardrobe", ((V)(1.5))).Put("dresser", ((V)(1.2))).Put("desk", ((V)(1.1))).Put("chest", ((V)(0.9))).Put("swing", ((V)(1.8))).Put("sandbox", ((V)(1.2))).Put("pool", ((V)(1.6))).Put("bench", ((V)(1D))).Put("hammock", ((V)(1.2))).Put("slide", ((V)(1.8))).Put("seesaw", ((V)(1.3))).Put("stand", ((V)(1.2))).Put("grill", ((V)(1.1))).Put("tramp", ((V)(1.8))).Put("house", ((V)(2.2))).Put("merry", ((V)(2D))).Put("fountain", ((V)(2D))).Put("tree", ((V)(1.2))).Put("bush", ((V)(0.6))).Put("stage", ((V)(2.2))).Put("speaker", ((V)(0.9))).Put("juke", ((V)(1.8))).Put("arcade", ((V)(1.8))).Put("dj", ((V)(2.2))).Put("pillar", ((V)(1D))).Put("bar", ((V)(1.3))).Put("wall", ((V)(1.2))).Put("floor", ((V)(1.3))).Put("trim", ((V)(0.6))).Put("win", ((V)(0.9))).Put("light", ((V)(0.7))).Put("art", ((V)(0.6))).Put("door", ((V)(0.8))).Put("fence", ((V)(1.2))).Put("ground", ((V)(1.3))).Put("ylight", ((V)(0.8))).V;
SURF_55 = NewObj(0).V;
ITEMS_56 = Arr();
add_57 = Fn((V _arrowThis2007, int _argc1998, V row_2004, V lv_2005, V hidden_2006, V _a2003, V[] _rest1999) => {
V id_2008 = default;
V n_2009 = default;
V room_2010 = default;
V arch_2011 = default;
V band_2012 = default;
V ex_2013 = default;
V e_2014 = default;
V isS_2015 = default;
V kind_2016 = default;
double price_2017 = 0;
V meta_2018 = default;
{ V _t2019 = row_2004;
{ V _t2020 = ListOf(_t2019);
{ V _t2021 = GetIdx(_t2020, 0D);
id_2008 = _t2021; }
{ V _t2022 = GetIdx(_t2020, 1D);
n_2009 = _t2022; }
{ V _t2023 = GetIdx(_t2020, 2D);
room_2010 = _t2023; }
{ V _t2024 = GetIdx(_t2020, 3D);
arch_2011 = _t2024; }
{ V _t2025 = GetIdx(_t2020, 4D);
band_2012 = _t2025; }
{ V _t2026 = GetIdx(_t2020, 5D);
ex_2013 = _t2026; }
} }
e_2014 = (ex_2013 is var _t2027 && Truthy(_t2027) ? _t2027 : NewObj(0).V);
isS_2015 = Invoke(arch_2011, "startsWith", ((V)("s:")));
kind_2016 = (Truthy(isS_2015) ? Invoke(arch_2011, "slice", ((V)(2D))) : arch_2011);
price_2017 = (Truthy((Get(e_2014, "start") is var _t2029 && Truthy(_t2029) ? _t2029 : hidden_2006)) ? 0D : (Round((((50D + (ToNum(lv_2005) * 28D)) * ToNum((GetK(WT_54, kind_2016) is var _t2028 && Truthy(_t2028) ? _t2028 : ((V)(1D))))) / 10D)) * 10D));
meta_2018 = NewObj(10).Put("id", id_2008).Put("n", n_2009).Put("room", room_2010).Put("lv", lv_2005).Put("band", band_2012).Put("arch", kind_2016).Put("price", ((V)(price_2017))).Put("start", (!(!(Truthy(Get(e_2014, "start")))) ? V.True : V.False)).Put("hidden", (!(!(Truthy(hidden_2006))) ? V.True : V.False)).Put("surf", isS_2015).V;
if (Truthy(isS_2015)) {
SetK(SURF_55, id_2008, meta_2018);
} else {
V S_2030 = default;
V D_2031 = default;
S_2030 = Object_assign(NewObj(1).Put("k", band_2012).V, e_2014);
D_2031 = InvokeK(A_48, kind_2016, S_2030);
Object_assign(D_2031, NewObj(10).Put("n", n_2009).Put("cat", room_2010).Put("price", ((V)(price_2017))).Put("cols", Get(GetK(BK_37, band_2012), "cols")).Put("lv", lv_2005).Put("band", band_2012).Put("arch", kind_2016).Put("room", room_2010).Put("start", (!(!(Truthy(Get(e_2014, "start")))) ? V.True : V.False)).Put("id", id_2008).V);
SetK(Get(X_8, "CAT"), id_2008, D_2031);
}
if (!(Truthy(hidden_2006))) {
Invoke(ITEMS_56, "push", meta_2018);
}
return default;
}, 3, "", true);
Invoke(LV_52, "forEach", Fn((V _arrowThis2040, int _argc2032, V rows_2038, V i_2039, V _a2036, V _a2037, V[] _rest2033) => {
return Invoke(rows_2038, "forEach", Fn((V _arrowThis2048, int _argc2041, V r_2047, V _a2044, V _a2045, V _a2046, V[] _rest2042) => {
return Call(add_57, V.Undef, r_2047, Add(i_2039, ((V)(1D))));
}, 1, "", true));
}, 2, "", true));
Invoke(HIDDEN_53, "forEach", Fn((V _arrowThis2056, int _argc2049, V r_2055, V _a2052, V _a2053, V _a2054, V[] _rest2050) => {
return Call(add_57, V.Undef, r_2055, ((V)(0D)), ((V)(1D)));
}, 1, "", true));
Set(X_8, "BANDS", BANDS_36);
Set(X_8, "SURF", SURF_55);
Set(X_8, "ITEMS", ITEMS_56);
Set(X_8, "ARCH", A_48);
Set(X_8, "bandOf", Fn((V _arrowThis2064, int _argc2057, V lv_2063, V _a2060, V _a2061, V _a2062, V[] _rest2058) => {
return (Invoke(BANDS_36, "find", Fn((V _arrowThis2072, int _argc2065, V b_2071, V _a2068, V _a2069, V _a2070, V[] _rest2066) => {
return ((Ge(lv_2063, GetIdx(Get(b_2071, "lv"), 0D)) && Le(lv_2063, GetIdx(Get(b_2071, "lv"), 1D))) ? V.True : V.False);
}, 1, "", true)) is var _t2073 && Truthy(_t2073) ? _t2073 : GetIdx(BANDS_36, 0D));
}, 1, "", true));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
