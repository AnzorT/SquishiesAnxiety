// movie-t5.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_movie_t5_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V SM_8 = default;
V K_9 = default;
V D_10 = default;
V P_11 = default;
V E_12 = default;
V kf_13 = default;
V win_14 = default;
V put_15 = default;
V show_16 = default;
V actor_17 = default;
V pose_18 = default;
V go_19 = default;
V dance_20 = default;
V bub_21 = default;
V lines_22 = default;
V parts_23 = default;
V glow_24 = default;
V film_25 = default;
V snd_26 = default;
V rnd_27 = default;
V cl_28 = default;
V lerp_29 = default;
V stars_30 = default;
V el_31 = default;
V art_32 = default;
V SPIN_33 = default;
double B_34 = 0;
double FY_35 = 0;
double W_36 = 0;
V CH_37 = default;
V seg_38 = default;
V arc_39 = default;
V land_40 = default;
V wrapR_41 = default;
V tw_42 = default;
V bp_43 = default;
V FLAME_44 = default;
V PUFF_45 = default;
V SMOKE_46 = default;
V DROP_47 = default;
V BUB_48 = default;
V RING_49 = default;
V FX_50 = default;
V spray_51 = default;
V sliced_52 = default;
V posA_53 = default;
V toastOf_54 = default;
V tf_55 = default;
double PL_56 = 0;
V SIG_57 = default;
V popPose_58 = default;
V popGlint_59 = default;
V stage_60 = default;
V lyr_61 = default;
V banner_62 = default;
V wash_63 = default;
V beatW_64 = default;
V verse_65 = default;
V guests_66 = default;
V andList_67 = default;
V mk_68 = default;
V POPS_69 = default;
V score_70 = default;
if (_self1.IsNullish) _self1 = GlobalV;
FX_50 = Fn((V _self71, int _argc72, V p_78, V defs_79, V _a76, V _a77, V[] _rest73) => {
V U_80 = default;
V S_81 = default;
V ON_82 = default;
V CHo_83 = default;
V ps_84 = default;
if (_self71.IsNullish) _self71 = GlobalV;
U_80 = ((V)(0D));
S_81 = V.Null;
ON_82 = (false ? V.True : V.False);
CHo_83 = (false ? V.True : V.False);
ps_84 = Invoke(defs_79, "map", Fn((V _arrowThis100, int _argc85, V _a87, V _a88, V _a89, V _a90, V[] _rest86) => {
V n_93 = default;
V css_95 = default;
V html_97 = default;
V f_99 = default;
{ V _t91 = ListOf(_a87);
{ V _t92 = GetIdx(_t91, 0D);
n_93 = _t92; }
{ V _t94 = GetIdx(_t91, 1D);
css_95 = _t94; }
{ V _t96 = GetIdx(_t91, 2D);
html_97 = _t96; }
{ V _t98 = GetIdx(_t91, 3D);
f_99 = _t98; }
}
return Call(parts_23, V.Undef, p_78, n_93, css_95, html_97, Fn((V _arrowThis108, int _argc101, V i_107, V _a104, V _a105, V _a106, V[] _rest102) => {
return (Truthy(ON_82) ? Call(f_99, V.Undef, i_107, U_80, S_81, CHo_83) : V.Null);
}, 1, "", true));
}, 1, "", true));
return Fn((V _arrowThis119, int _argc109, V u_115, V s_116, V on_117, V ch_118, V[] _rest110) => {
U_80 = u_115;
S_81 = s_116;
ON_82 = (!(!(Truthy((on_117 is var _t120 && !Truthy(_t120) ? _t120 : s_116)))) ? V.True : V.False);
CHo_83 = (!(!(Truthy(ch_118))) ? V.True : V.False);
Invoke(ps_84, "forEach", Fn((V _arrowThis128, int _argc121, V q_127, V _a124, V _a125, V _a126, V[] _rest122) => {
return Call(q_127, V.Undef, u_115);
}, 1, "", true));
return default;
}, 4, "", true);
return default;
}, 2, "FX", false);
sliced_52 = Fn((V _self129, int _argc130, V p_136, V k_137, V w_138, V cuts_139, V[] _rest131) => {
V sd_140 = default;
V n_141 = default;
if (_self129.IsNullish) _self129 = GlobalV;
sd_140 = Call(D_10, V.Undef, p_136, ((V)(JsStrBuf.Begin().S("left:0;top:0;width:").N((ToNum(w_138) * 0.72)).S("px;height:").N((ToNum(w_138) * 0.12)).S("px;border-radius:50%;background:rgba(10,8,30,0.3);display:none;").End())));
n_141 = Call(D_10, V.Undef, p_136, ((V)(JsStrBuf.Begin().S("left:0;top:0;width:").V(w_138).S("px;height:").V(w_138).S("px;transform-origin:50% 94%;display:none;").End())));
Set(n_141, "_k", k_137);
Set(n_141, "_w", w_138);
Set(n_141, "_v", ((V)("")));
Set(n_141, "_sd", sd_140);
Set(n_141, "_sl", Invoke(Invoke(cuts_139, "slice", ((V)(1D))), "map", Fn((V _arrowThis150, int _argc142, V c_148, V j_149, V _a146, V _a147, V[] _rest143) => {
V a_151 = default;
V b_152 = default;
V im_153 = default;
a_151 = GetK(cuts_139, j_149);
b_152 = Call(D_10, V.Undef, n_141, ((V)(JsStrBuf.Begin().S("left:0;top:").V(Invoke(((V)((ToNum(a_151) * ToNum(w_138)))), "toFixed", ((V)(2D)))).S("px;width:").V(w_138).S("px;height:").V(Invoke(((V)((((ToNum(c_148) - ToNum(a_151)) * ToNum(w_138)) + 0.6))), "toFixed", ((V)(2D)))).S("px;overflow:hidden;z-index:").N((ToNum(Get(cuts_139, "length")) - ToNum(j_149))).S(";").End())));
im_153 = Call(el_31, V.Undef, ((V)("img")), ((V)(JsStrBuf.Begin().S("position:absolute;left:0;top:").V(Invoke(((V)(((-ToNum(a_151)) * ToNum(w_138)))), "toFixed", ((V)(2D)))).S("px;width:").V(w_138).S("px;height:").V(w_138).S("px;").End())), b_152);
Set(im_153, "alt", ((V)("")));
Set(im_153, "draggable", (false ? V.True : V.False));
return NewObj(2).Put("b", b_152).Put("im", im_153).V;
return default;
}, 2, "", true)));
Invoke(SPIN_33, "forEach", Fn((V _arrowThis161, int _argc154, V v_160, V _a157, V _a158, V _a159, V[] _rest155) => {
V i_162 = default;
i_162 = New(G("Image"));
Set(i_162, "src", Call(art_32, V.Undef, k_137, v_160));
return default;
}, 1, "", true));
return n_141;
return default;
}, 4, "sliced", false);
posA_53 = Fn((V _self163, int _argc164, V n_170, V s_171, V _a168, V _a169, V[] _rest165) => {
if (_self163.IsNullish) _self163 = GlobalV;
if (Truthy((Get(n_170, "_sl") is var _t172 && !Truthy(_t172) ? _t172 : s_171))) {
V v_173 = default;
V o_174 = default;
v_173 = (Get(s_171, "v") is var _t175 && Truthy(_t175) ? _t175 : ((V)("front")));
if (!SEq(Get(n_170, "_sv"), v_173)) {
Set(n_170, "_sv", v_173);
Invoke(Get(n_170, "_sl"), "forEach", Fn((V _arrowThis183, int _argc176, V q_182, V _a179, V _a180, V _a181, V[] _rest177) => {
Set(Get(q_182, "im"), "src", Call(art_32, V.Undef, Get(n_170, "_k"), v_173));
return default;
}, 1, "", true));
}
o_174 = (Get(s_171, "sl") is var _t184 && Truthy(_t184) ? _t184 : Arr());
Invoke(Get(n_170, "_sl"), "forEach", Fn((V _arrowThis193, int _argc185, V q_191, V j_192, V _a189, V _a190, V[] _rest186) => {
V d_194 = default;
d_194 = (GetK(o_174, j_192) is var _t195 && Truthy(_t195) ? _t195 : Arr(((V)(0D)), ((V)(0D))));
Set(Get(Get(q_191, "b"), "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").V(Invoke(GetIdx(d_194, 0D), "toFixed", ((V)(1D)))).S("px,").V(Invoke(GetIdx(d_194, 1D), "toFixed", ((V)(1D)))).S("px)").End())));
return default;
}, 2, "", true));
}
Call(pose_18, V.Undef, n_170, s_171);
return default;
}, 2, "posA", false);
popPose_58 = Fn((V _self196, int _argc197, V p_203, V X_204, V _a201, V _a202, V[] _rest198) => {
V q_205 = default;
if (_self196.IsNullish) _self196 = GlobalV;
if (LtN(p_203, 0.15)) {
V e_206 = default;
e_206 = Call(seg_38, V.Undef, p_203, ((V)(0D)), ((V)(0.15)));
return NewObj(5).Put("x", X_204).Put("y", ((V)(FY_35))).Put("v", ((V)("front"))).Put("sx", ((V)((1D + (0.12 * ToNum(e_206)))))).Put("sy", ((V)((1D - (0.16 * ToNum(e_206)))))).V;
}
if (LtN(p_203, 0.5)) {
V e_207 = default;
e_207 = Invoke(E_12, "in", Call(seg_38, V.Undef, p_203, ((V)(0.15)), ((V)(0.5))));
return NewObj(7).Put("x", Add(X_204, ((V)((((160D - ToNum(X_204)) * 0.2) * ToNum(e_207)))))).Put("y", ((V)((FY_35 - (150D * ToNum(e_207)))))).Put("gy", ((V)(FY_35))).Put("v", ((V)("front"))).Put("k", ((V)((1D + (1.8 * ToNum(e_207)))))).Put("sx", ((V)(0.94))).Put("sy", ((V)(1.08))).V;
}
if (LtN(p_203, 2D)) {
return V.Null;
}
if (LtN(p_203, 2.4)) {
V e_208 = default;
e_208 = Invoke(E_12, "in", Call(seg_38, V.Undef, p_203, ((V)(2D)), ((V)(2.4))));
return NewObj(7).Put("x", X_204).Put("y", Call(lerp_29, V.Undef, ((V)((-20D))), ((V)(FY_35)), e_208)).Put("gy", ((V)(FY_35))).Put("v", ((V)("front"))).Put("k", ((V)((1.6 - (0.6 * ToNum(e_208)))))).Put("sx", ((V)(0.95))).Put("sy", ((V)(1.06))).V;
}
q_205 = Call(land_40, V.Undef, p_203, ((V)(2.4)));
return NewObj(5).Put("x", X_204).Put("y", ((V)(FY_35))).Put("v", ((V)("front"))).Put("sx", ((V)((1D + (0.16 * ToNum(q_205)))))).Put("sy", ((V)((1D - (0.2 * ToNum(q_205)))))).V;
return default;
}, 2, "popPose", false);
stage_60 = Fn((V _self209, int _argc210, V L_216, V back_217, V _a214, V _a215, V[] _rest211) => {
V bd_218 = default;
V fl_219 = default;
V fo_220 = default;
V act_221 = default;
V cones_222 = default;
V dark_223 = default;
V cur_224 = default;
V val_225 = default;
V cap_226 = default;
V ct_227 = default;
if (_self209.IsNullish) _self209 = GlobalV;
bd_218 = Call(D_10, V.Undef, L_216, ((V)("inset:0;")));
if (Truthy(back_217)) {
Call(back_217, V.Undef, bd_218);
}
fl_219 = Call(D_10, V.Undef, L_216, ((V)("left:0;top:136px;width:320px;height:44px;background:repeating-linear-gradient(90deg,#8a5a3a 0 26px,#7a4e32 26px 28px);")));
Call(D_10, V.Undef, fl_219, ((V)("left:0;top:0;width:320px;height:4px;background:#c8905a;")));
fo_220 = Array_from(NewObj(1).Put("length", ((V)(9D))).V, Fn((V _arrowThis236, int _argc228, V __234, V i_235, V _a232, V _a233, V[] _rest229) => {
return Call(D_10, V.Undef, L_216, ((V)(JsStrBuf.Begin().S("left:").N((14D + (ToNum(i_235) * 36D))).S("px;top:172px;width:12px;height:6px;border-radius:6px 6px 0 0;background:#ffe9a0;box-shadow:0 0 8px 3px rgba(255,220,140,0.7);").End())));
}, 2, "", true));
act_221 = Call(D_10, V.Undef, L_216, ((V)("inset:0;")));
cones_222 = Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis244, int _argc237, V i_243, V _a240, V _a241, V _a242, V[] _rest238) => {
return Call(D_10, V.Undef, L_216, ((V)("left:0;top:-10px;width:90px;height:190px;transform-origin:50% 0;clip-path:polygon(44% 0,56% 0,100% 100%,0 100%);background:linear-gradient(rgba(255,250,220,0.5),rgba(255,250,220,0.08));mix-blend-mode:screen;pointer-events:none;")));
}, 1, "", true));
dark_223 = Call(D_10, V.Undef, L_216, ((V)("inset:0;pointer-events:none;")));
cur_224 = Invoke(Arr(((V)(0D)), ((V)(1D))), "map", Fn((V _arrowThis252, int _argc245, V i_251, V _a248, V _a249, V _a250, V[] _rest246) => {
return Call(D_10, V.Undef, L_216, ((V)(JsStrBuf.Begin().S("top:0;width:170px;height:180px;").S((Truthy(i_251) ? "right:0;" : "left:0;")).S("background:repeating-linear-gradient(90deg,#a0182a 0 12px,#c8283a 12px 20px,#a0182a 20px 26px);box-shadow:inset ").S((Truthy(i_251) ? "6px" : "-6px")).S(" 0 10px rgba(0,0,0,0.4);z-index:50;").End())));
}, 1, "", true));
val_225 = Call(D_10, V.Undef, L_216, ((V)("left:-10px;top:0;width:340px;height:18px;background:repeating-radial-gradient(circle at 10px 0,#c8283a 0 9px,#a0182a 9px 10px) 0 0/20px 18px;z-index:51;box-shadow:0 3px 4px rgba(0,0,0,0.4);")));
cap_226 = Call(D_10, V.Undef, L_216, ((V)("left:0;bottom:8px;width:320px;text-align:center;font-weight:700;font-size:13px;line-height:1.1;z-index:60;padding:0 10px;box-sizing:border-box;-webkit-text-stroke:3px #2a0f4f;paint-order:stroke fill;color:#fff;")), ((V)("")));
ct_227 = ((V)(""));
return NewObj(3).Put("act", act_221).Put("bd", bd_218).Put("upd", Fn((V _self253, int _argc254, V t_260, V _a257, V _a258, V _a259, V[] _rest255) => {
V c_263 = default;
V sp_264 = default;
V dk_265 = default;
V ds_266 = default;
V tx_267 = default;
V q_262 = default;
if (_self253.IsNullish) _self253 = GlobalV;
{ V _t261 = _a257; if (_t261.IsUndef) _t261 = NewObj(0).V;
q_262 = _t261; }
c_263 = (Get(q_262, "cur") is var _t268 && !_t268.IsNullish ? _t268 : ((V)(1D)));
Set(Get(GetIdx(cur_224, 0D), "style"), "transform", ((V)(JsStrBuf.Begin().S("translateX(").V(Invoke(((V)(((-ToNum(c_263)) * 165D))), "toFixed", ((V)(1D)))).S("px) scaleX(").V(Invoke(((V)((1D - (ToNum(c_263) * 0.35)))), "toFixed", ((V)(3D)))).S(")").End())));
Set(Get(GetIdx(cur_224, 1D), "style"), "transform", ((V)(JsStrBuf.Begin().S("translateX(").V(Invoke(((V)((ToNum(c_263) * 165D))), "toFixed", ((V)(1D)))).S("px) scaleX(").V(Invoke(((V)((1D - (ToNum(c_263) * 0.35)))), "toFixed", ((V)(3D)))).S(")").End())));
Set(Get(GetIdx(cur_224, 0D), "style"), "transformOrigin", ((V)("0 0")));
Set(Get(GetIdx(cur_224, 1D), "style"), "transformOrigin", ((V)("100% 0")));
Invoke(fo_220, "forEach", Fn((V _arrowThis277, int _argc269, V f_275, V i_276, V _a273, V _a274, V[] _rest270) => {
Set(Get(f_275, "style"), "opacity", Invoke(((V)((0.6 + (0.4 * System.Math.Abs(FdLibm.Sin(ToNum(Add(((V)((ToNum(t_260) * 2D))), i_276)))))))), "toFixed", ((V)(2D))));
return default;
}, 2, "", true));
sp_264 = (Get(q_262, "sp") is var _t278 && Truthy(_t278) ? _t278 : Arr());
Invoke(cones_222, "forEach", Fn((V _arrowThis287, int _argc279, V n_285, V i_286, V _a283, V _a284, V[] _rest280) => {
V s_288 = default;
s_288 = GetK(sp_264, i_286);
if (!(Truthy(s_288))) {
Call(show_16, V.Undef, n_285, (false ? V.True : V.False));
return default;
}
Call(show_16, V.Undef, n_285, (true ? V.True : V.False));
Set(Get(n_285, "style"), "transform", ((V)(JsStrBuf.Begin().S("translateX(").V(Invoke(((V)((ToNum(GetIdx(s_288, 0D)) - 45D))), "toFixed", ((V)(1D)))).S("px) rotate(").V(Invoke((GetIdx(s_288, 1D) is var _t289 && Truthy(_t289) ? _t289 : ((V)(0D))), "toFixed", ((V)(1D)))).S("deg)").End())));
Set(Get(n_285, "style"), "opacity", Invoke((GetIdx(s_288, 2D) is var _t290 && !_t290.IsNullish ? _t290 : ((V)(1D))), "toFixed", ((V)(2D))));
return default;
}, 2, "", true));
dk_265 = (Get(q_262, "dark") is var _t291 && Truthy(_t291) ? _t291 : ((V)(0D)));
ds_266 = Get(q_262, "ds");
Set(Get(dark_223, "style"), "background", ((V)((Truthy(ds_266) ? JsStrBuf.Begin().S("radial-gradient(ellipse 60px 80px at ").V(GetIdx(ds_266, 0D)).S("px ").V(GetIdx(ds_266, 1D)).S("px, rgba(8,4,20,0) 60%, rgba(8,4,20,").V(dk_265).S(") 100%)").End() : JsStrBuf.Begin().S("rgba(8,4,20,").V(dk_265).S(")").End()))));
tx_267 = (Truthy(Get(q_262, "cap")) ? GetIdx(Get(q_262, "cap"), 0D) : ((V)("")));
if (!SEq(tx_267, ct_227)) {
ct_227 = tx_267;
Set(cap_226, "textContent", tx_267);
}
Set(Get(cap_226, "style"), "opacity", (Truthy(Get(q_262, "cap")) ? Invoke(GetIdx(Get(q_262, "cap"), 1D), "toFixed", ((V)(3D))) : ((V)("0"))));
if (Truthy(Get(q_262, "cap"))) {
Set(Get(cap_226, "style"), "color", (GetIdx(Get(q_262, "cap"), 2D) is var _t292 && Truthy(_t292) ? _t292 : ((V)("#fff"))));
}
return default;
}, 2, "upd", false)).V;
return default;
}, 2, "stage", false);
verse_65 = Fn((V _self293, int _argc294, V o_300, V _a297, V _a298, V _a299, V[] _rest295) => {
if (_self293.IsNullish) _self293 = GlobalV;
return NewObj(5).Put("a", Get(o_300, "a")).Put("b", Add(Get(o_300, "a"), ((V)(50D)))).Put("rgb", Get(o_300, "rgb")).Put("lit", Fn((V _arrowThis308, int _argc301, V t_307, V _a304, V _a305, V _a306, V[] _rest302) => {
return ((V)((0.85 + (0.15 * FdLibm.Exp(((-((ToNum(t_307) / B_34) % 1D)) * 5D))))));
}, 1, "lit", true)).Put("mk", Fn((V _self309, int _argc310, V L_316, V _a313, V _a314, V _a315, V[] _rest311) => {
V S_317 = default;
V ns_318 = default;
V fxs_319 = default;
V bn_320 = default;
V nm_321 = default;
V wa_322 = default;
V pg_323 = default;
V fx_324 = default;
V X3_325 = default;
if (_self309.IsNullish) _self309 = GlobalV;
S_317 = Call(stage_60, V.Undef, L_316, Get(o_300, "back"));
ns_318 = Invoke(Get(o_300, "who"), "map", Fn((V _arrowThis333, int _argc326, V w_332, V _a329, V _a330, V _a331, V[] _rest327) => {
return (Truthy(Get(GetK(SIG_57, GetIdx(w_332, 0D)), "sl")) ? Call(sliced_52, V.Undef, Get(S_317, "act"), GetIdx(w_332, 0D), ((V)(W_36)), Get(GetK(SIG_57, GetIdx(w_332, 0D)), "sl")) : Call(actor_17, V.Undef, Get(S_317, "act"), GetIdx(w_332, 0D), ((V)(W_36))));
}, 1, "", true));
fxs_319 = Invoke(Get(o_300, "who"), "map", Fn((V _arrowThis341, int _argc334, V w_340, V _a337, V _a338, V _a339, V[] _rest335) => {
return (Truthy(Get(GetK(SIG_57, GetIdx(w_340, 0D)), "fx")) ? Invoke(GetK(SIG_57, GetIdx(w_340, 0D)), "fx", Get(S_317, "act")) : V.Null);
}, 1, "", true));
bn_320 = Call(banner_62, V.Undef, L_316, Get(o_300, "title"), Get(o_300, "c1"), Get(o_300, "c2"));
nm_321 = Call(D_10, V.Undef, L_316, ((V)("left:0;top:22px;width:320px;text-align:center;z-index:40;display:none;font-weight:700;-webkit-text-stroke:3px #2a0f4f;paint-order:stroke fill;color:#fff;")), ((V)("")));
wa_322 = Call(wash_63, V.Undef, L_316, Get(o_300, "c2"));
pg_323 = Call(glow_24, V.Undef, L_316, ((V)("rgba(170,245,255,0.95)")), ((V)(26D)), ((V)("z-index:46;")));
fx_324 = (Truthy(Get(o_300, "fx")) ? Invoke(o_300, "fx", Get(S_317, "act")) : V.Null);
X3_325 = Arr(((V)(74D)), ((V)(160D)), ((V)(246D)));
return Fn((V _arrowThis349, int _argc342, V t_348, V _a345, V _a346, V _a347, V[] _rest343) => {
double sol_350 = 0;
V gr_351 = default;
double shk_352 = 0;
double sw_353 = 0;
sol_350 = ((GeN(t_348, 4D) && LtN(t_348, 28D)) ? System.Math.Floor(((ToNum(t_348) - 4D) / 8D)) : (-1D));
gr_351 = (GeN(t_348, 28D) ? V.True : V.False);
shk_352 = 0D;
Call(put_15, V.Undef, bn_320, ((V)(160D)), ((V)(40D)), ((V)((ToNum(Call(P_11, V.Undef, t_348, ((V)(0.2)), ((V)(0.8)), Get(E_12, "back"))) * (1D + (0.04 * FdLibm.Sin((ToNum(t_348) * 6D))))))), ((V)(0D)), ((V)((LtN(t_348, 4D) ? (1D - ToNum(Call(P_11, V.Undef, t_348, ((V)(3.4)), ((V)(4D))))) : 0D))));
if ((sol_350 >= 0D)) {
V w_354 = default;
double u_355 = 0;
w_354 = GetIdx(Get(o_300, "who"), sol_350);
u_355 = ((ToNum(t_348) - 4D) - (sol_350 * 8D));
Set(nm_321, "innerHTML", ((V)(JsStrBuf.Begin().S("<div style=\"font-size:20px;\">").V(GetIdx(w_354, 1D)).S("</div><div style=\"font-size:11px;color:").V(Get(o_300, "c1")).S(";\">").V(GetIdx(w_354, 2D)).S("</div>").End())));
Call(put_15, V.Undef, nm_321, ((V)(160D)), (Get(GetK(SIG_57, GetIdx(w_354, 0D)), "nmY") is var _t356 && Truthy(_t356) ? _t356 : ((V)(36D))), ((V)(1D)), ((V)(0D)), ((V)((ToNum(Call(win_14, V.Undef, t_348, ((V)((4D + (sol_350 * 8D)))), ((V)((12D + (sol_350 * 8D)))), ((V)(0.3)))) * ((u_355 < 3.4) ? 1D : (1D - ToNum(Call(P_11, V.Undef, ((V)(u_355)), ((V)(3.4)), ((V)(4D))))))))));
} else {
Call(show_16, V.Undef, nm_321, (false ? V.True : V.False));
}
Invoke(ns_318, "forEach", Fn((V _arrowThis365, int _argc357, V n_363, V i_364, V _a361, V _a362, V[] _rest358) => {
V w_366 = default;
V sg_367 = default;
V X_368 = default;
V s_369 = default;
double u_370 = 0;
V ch_371 = default;
w_366 = GetK(Get(o_300, "who"), i_364);
sg_367 = GetK(SIG_57, GetIdx(w_366, 0D));
X_368 = GetK(X3_325, i_364);
s_369 = V.Undef;
u_370 = (-1D);
ch_371 = (false ? V.True : V.False);
if (LtN(t_348, 3D)) {
s_369 = (Call(go_19, V.Undef, t_348, Arr(Arr(((V)(0D)), ((V)((SEqN(i_364, 0D) ? (-40D) : (SEqN(i_364, 2D) ? 360D : 160D)))), ((V)((SEqN(i_364, 1D) ? 210D : FY_35)))), Arr(((V)((1.6 + (ToNum(i_364) * 0.3)))), X_368, ((V)(FY_35)))), NewObj(3).Put("y", ((V)(FY_35))).Put("f", ((V)("front"))).Put("ph", i_364).V) is var _t372 && Truthy(_t372) ? _t372 : NewObj(3).Put("x", X_368).Put("y", ((V)(FY_35))).Put("v", ((V)("front"))).V);
} else {
if (LtN(t_348, 4D)) {
s_369 = Call(dance_20, V.Undef, t_348, X_368, ((V)(FY_35)), ((V)("bounce")), ((V)(B_34)), ((V)((ToNum(i_364) * 0.3))));
} else {
if (SEqN(i_364, sol_350)) {
double m_373 = 0;
u_370 = ((ToNum(t_348) - 4D) - (sol_350 * 8D));
m_373 = (ToNum(Call(P_11, V.Undef, ((V)(u_370)), ((V)(0D)), ((V)(0.8)))) * (1D - ToNum(Call(P_11, V.Undef, ((V)(u_370)), ((V)(7.2)), ((V)(8D))))));
s_369 = Invoke(sg_367, "m", ((V)(u_370)), Call(lerp_29, V.Undef, X_368, ((V)(160D)), ((V)(m_373))), ((V)(FY_35)), (false ? V.True : V.False));
Set(s_369, "k", ((V)((ToNum((Get(s_369, "k") is var _t374 && Truthy(_t374) ? _t374 : ((V)(1D)))) * (1D + (0.25 * m_373))))));
} else {
if ((sol_350 >= 0D)) {
V sl_375 = default;
double uu_376 = 0;
double m_377 = 0;
sl_375 = Invoke(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "filter", Fn((V _arrowThis385, int _argc378, V j_384, V _a381, V _a382, V _a383, V[] _rest379) => {
return (!SEqN(j_384, sol_350) ? V.True : V.False);
}, 1, "", true)), "indexOf", i_364);
uu_376 = ((ToNum(t_348) - 4D) - (sol_350 * 8D));
m_377 = (ToNum(Call(P_11, V.Undef, ((V)(uu_376)), ((V)(0D)), ((V)(0.8)))) * (1D - ToNum(Call(P_11, V.Undef, ((V)(uu_376)), ((V)(7.2)), ((V)(8D))))));
s_369 = Call(dance_20, V.Undef, t_348, Call(lerp_29, V.Undef, X_368, ((V)((Truthy(sl_375) ? 268D : 52D))), ((V)(m_377))), ((V)(FY_35)), ((V)("sway")), ((V)(B_34)), i_364);
Set(s_369, "k", ((V)(0.85)));
} else {
double pu_386 = 0;
pu_386 = (ToNum(t_348) - 28D);
if ((SEq(i_364, Get(o_300, "pop")) && (pu_386 < 2.8))) {
s_369 = Call(popPose_58, V.Undef, ((V)(pu_386)), X_368);
Call(popGlint_59, V.Undef, pg_323, ((V)(pu_386)), Add(X_368, ((V)(((160D - ToNum(X_368)) * 0.2)))));
} else {
u_370 = (pu_386 % 8D);
ch_371 = (true ? V.True : V.False);
s_369 = Invoke(sg_367, "m", ((V)(u_370)), X_368, ((V)(FY_35)), (true ? V.True : V.False));
}
}
}
}
}
Call(posA_53, V.Undef, n_363, s_369);
if (Truthy(GetK(fxs_319, i_364))) {
InvokeK(fxs_319, i_364, ((V)(u_370)), s_369, ((u_370 >= 0D) ? V.True : V.False), ch_371);
}
if (Truthy((s_369 is var _t387 && !Truthy(_t387) ? _t387 : Get(s_369, "shk")))) {
shk_352 = Max(shk_352, ToNum(Get(s_369, "shk")));
}
return default;
}, 2, "", true));
if (!(Truthy((gr_351 is var _t388 && !Truthy(_t388) ? _t388 : (((ToNum(t_348) - 28D) < 2.8) ? V.True : V.False))))) {
Call(show_16, V.Undef, pg_323, (false ? V.True : V.False));
}
if (Truthy(fx_324)) {
Call(fx_324, V.Undef, t_348, ((V)(sol_350)));
}
Set(Get(wa_322, "style"), "opacity", Invoke(((V)(((Truthy(gr_351) ? 0.34 : 0.14) * ToNum(Call(beatW_64, V.Undef, t_348))))), "toFixed", ((V)(3D))));
Set(Get(L_316, "style"), "transform", ((V)(((shk_352 > 0.05) ? JsStrBuf.Begin().S("translate(").V(Invoke(((V)((FdLibm.Sin((ToNum(t_348) * 90D)) * shk_352))), "toFixed", ((V)(1D)))).S("px,").V(Invoke(((V)(((FdLibm.Cos((ToNum(t_348) * 77D)) * shk_352) * 0.6))), "toFixed", ((V)(1D)))).S("px)").End() : ""))));
sw_353 = (FdLibm.Sin((ToNum(t_348) * 1.3)) * 18D);
Invoke(S_317, "upd", t_348, NewObj(4).Put("sp", ((sol_350 >= 0D) ? Arr(Arr(((V)(160D)), ((V)(0D)), ((V)(1D)))) : Arr(Arr(((V)(74D)), ((V)(sw_353)), ((V)(0.8))), Arr(((V)(160D)), ((V)(((-sw_353) * 0.6))), ((V)(0.8))), Arr(((V)(246D)), ((V)((-sw_353))), ((V)(0.8)))))).Put("dark", ((V)(((sol_350 >= 0D) ? 0.35 : 0.1)))).Put("ds", ((sol_350 >= 0D) ? Arr(((V)(160D)), ((V)(120D))) : V.Null)).Put("cap", Call(lyr_61, V.Undef, t_348, Get(o_300, "lyr"))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V;
return default;
}, 1, "verse", false);
mk_68 = Fn((V _self389, int _argc390, V _a392, V _a393, V _a394, V _a395, V[] _rest391) => {
V S_396 = default;
V BK_397 = default;
V FR_398 = default;
if (_self389.IsNullish) _self389 = GlobalV;
S_396 = Arr();
Invoke(S_396, "push", NewObj(5).Put("a", ((V)(0D))).Put("b", ((V)(30D))).Put("rgb", ((V)("255,220,170"))).Put("lit", Fn((V _arrowThis406, int _argc399, V t_405, V _a402, V _a403, V _a404, V[] _rest400) => {
return ((V)((0.5 + (0.4 * ToNum(Call(P_11, V.Undef, t_405, ((V)(2D)), ((V)(5D))))))));
}, 1, "lit", true)).Put("mk", Fn((V _self407, int _argc408, V L_414, V _a411, V _a412, V _a413, V[] _rest409) => {
V St_415 = default;
V mi_416 = default;
V sp_417 = default;
V ti_418 = default;
if (_self407.IsNullish) _self407 = GlobalV;
St_415 = Call(stage_60, V.Undef, L_414, Fn((V _arrowThis426, int _argc419, V bd_425, V _a422, V _a423, V _a424, V[] _rest420) => {
return Call(D_10, V.Undef, bd_425, ((V)("inset:0;background:radial-gradient(ellipse at 50% 30%,#5a2a8a,#1a0a3a 75%);")));
}, 1, "", true));
mi_416 = Call(actor_17, V.Undef, Get(St_415, "act"), ((V)("mittens")), ((V)((W_36 + 8D))));
sp_417 = Call(bub_21, V.Undef, L_414);
ti_418 = Call(D_10, V.Undef, L_414, ((V)("left:0;top:46px;width:320px;text-align:center;font-weight:700;z-index:55;-webkit-text-stroke:4px #2a0f4f;paint-order:stroke fill;color:#ffd66b;")), ((V)("<div style=\"font-size:30px;\">SQUISH SQUAD</div><div style=\"font-size:15px;color:#fff;\">THE MUSICAL</div>")));
return Fn((V _arrowThis434, int _argc427, V t_433, V _a430, V _a431, V _a432, V[] _rest428) => {
V c_435 = default;
c_435 = Call(P_11, V.Undef, t_433, ((V)(3.6)), ((V)(6.4)), Get(E_12, "io"));
Set(Get(ti_418, "style"), "opacity", Invoke(((V)((ToNum(Call(P_11, V.Undef, t_433, ((V)(0.4)), ((V)(1.2)))) * (1D - ToNum(Call(P_11, V.Undef, t_433, ((V)(3.4)), ((V)(4D)))))))), "toFixed", ((V)(3D))));
Set(Get(ti_418, "style"), "transform", ((V)(JsStrBuf.Begin().S("scale(").V(Invoke(((V)((1D + (0.03 * FdLibm.Sin((ToNum(t_433) * 3D)))))), "toFixed", ((V)(3D)))).S(")").End())));
Call(pose_18, V.Undef, mi_416, (LtN(t_433, 22D) ? NewObj(2).Spread(Call(dance_20, V.Undef, t_433, ((V)(160D)), ((V)(FY_35)), ((V)((LtN(t_433, 14D) ? "sway" : "bounce"))), ((V)(B_34)))).Put("k", ((V)(1.15))).V : NewObj(2).Spread(Call(dance_20, V.Undef, t_433, ((V)(160D)), ((V)(FY_35)), ((V)("jump")), ((V)(B_34)))).Put("k", ((V)(1.15))).V));
Invoke(St_415, "upd", t_433, NewObj(5).Put("cur", c_435).Put("sp", Arr(Arr(((V)(160D)), ((V)((FdLibm.Sin(ToNum(t_433)) * 4D))), Call(P_11, V.Undef, t_433, ((V)(5D)), ((V)(6D)))))).Put("dark", ((V)((0.55 * (1D - ToNum(Call(P_11, V.Undef, t_433, ((V)(22D)), ((V)(23D))))))))).Put("ds", Arr(((V)(160D)), ((V)(120D)))).Put("cap", Call(lyr_61, V.Undef, t_433, Arr(Arr(((V)(7D)), ((V)(11D)), ((V)("Every friend has got a groove,"))), Arr(((V)(11D)), ((V)(15D)), ((V)("every paw has got a move!"))), Arr(((V)(15D)), ((V)(19D)), ((V)("Squish in close and feel the beat,"))), Arr(((V)(19D)), ((V)(23D)), ((V)("jump up, friends, get on your feet!"))), Arr(((V)(23D)), ((V)(30D)), ((V)("Squish, squish, SQUAD! Everybody move!")), ((V)("#ffd66b")))))).V);
Call(sp_417, V.Undef, V.Null);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_396, "push", Call(verse_65, V.Undef, NewObj(10).Put("a", ((V)(30D))).Put("rgb", ((V)("255,170,190"))).Put("title", ((V)("SNACK SHACK!"))).Put("c1", ((V)("#ffd66b"))).Put("c2", ((V)("#ff6fa8"))).Put("pop", ((V)(2D))).Put("who", Arr(Arr(((V)("mallow")), ((V)("Mallow")), ((V)("Toasty Twirl"))), Arr(((V)("frybo")), ((V)("Frybo")), ((V)("Fry Shuffle"))), Arr(((V)("bunbun")), ((V)("Bunbun")), ((V)("Stack Attack"))))).Put("back", Fn((V _arrowThis443, int _argc436, V bd_442, V _a439, V _a440, V _a441, V[] _rest437) => {
Call(D_10, V.Undef, bd_442, ((V)("inset:0;background:linear-gradient(#ff9ab8,#ffd0a0);")));
Call(D_10, V.Undef, bd_442, ((V)("left:0;top:60px;width:320px;height:80px;background:repeating-linear-gradient(90deg,#fff 0 16px,#ff6f8a 16px 32px);opacity:0.5;")));
Call(D_10, V.Undef, bd_442, ((V)("left:12px;top:26px;width:78px;height:20px;border-radius:6px;background:#2a0f4f;border:2px solid #ffd66b;box-shadow:0 0 10px #ff6fa8;color:#ffd66b;font-weight:700;font-size:10px;text-align:center;line-height:20px;")), ((V)("SNACK SHACK")));
return default;
}, 1, "back", true)).Put("fx", Fn((V _arrowThis451, int _argc444, V p_450, V _a447, V _a448, V _a449, V[] _rest445) => {
return Call(parts_23, V.Undef, p_450, ((V)(14D)), ((V)("width:5px;height:2px;border-radius:1px;background:#fff6c8;")), V.Null, Fn((V _arrowThis460, int _argc452, V i_458, V t_459, V _a456, V _a457, V[] _rest453) => {
double a_461 = 0;
a_461 = (((ToNum(t_459) * 0.35) + (ToNum(i_458) / 14D)) % 1D);
return NewObj(4).Put("x", ((V)((20D + ((ToNum(i_458) * 47D) % 290D))))).Put("y", ((V)((a_461 * 150D)))).Put("r", ((V)(((ToNum(t_459) * 200D) + (ToNum(i_458) * 40D))))).Put("o", ((V)(0.9))).V;
return default;
}, 2, "", true));
}, 1, "fx", true)).Put("lyr", Arr(Arr(((V)(4D)), ((V)(12D)), ((V)("Toast it up and twirl around!"))), Arr(((V)(12D)), ((V)(20D)), ((V)("Fry-shuffle sliding on the ground!"))), Arr(((V)(20D)), ((V)(28D)), ((V)("Stack it, smack it, burger high!"))), Arr(((V)(30D)), ((V)(38D)), ((V)("Squish, squish, SQUAD!")), ((V)("#ffd66b"))), Arr(((V)(38D)), ((V)(46D)), ((V)("Snack Shack in the groove!")), ((V)("#ffd66b"))))).V));
Invoke(S_396, "push", Call(verse_65, V.Undef, NewObj(10).Put("a", ((V)(80D))).Put("rgb", ((V)("110,200,255"))).Put("title", ((V)("UNDER THE SEA!"))).Put("c1", ((V)("#8fe8ff"))).Put("c2", ((V)("#3a8ac8"))).Put("pop", ((V)(0D))).Put("who", Arr(Arr(((V)("finn")), ((V)("Finn")), ((V)("Splash Dance"))), Arr(((V)("octo")), ((V)("Octo")), ((V)("Tentacle Tango"))), Arr(((V)("marina")), ((V)("Marina")), ((V)("Mermaid Splash"))))).Put("back", Fn((V _arrowThis469, int _argc462, V bd_468, V _a465, V _a466, V _a467, V[] _rest463) => {
Call(D_10, V.Undef, bd_468, ((V)("inset:0;background:linear-gradient(#5ac8f0,#1a5aa0);")));
Call(D_10, V.Undef, bd_468, ((V)("left:0;top:0;width:320px;height:140px;background:repeating-linear-gradient(100deg,rgba(255,255,255,0.08) 0 10px,rgba(255,255,255,0) 10px 40px);")));
Invoke(Arr(((V)(30D)), ((V)(70D)), ((V)(250D)), ((V)(290D))), "forEach", Fn((V _arrowThis478, int _argc470, V x_476, V i_477, V _a474, V _a475, V[] _rest471) => {
return Call(D_10, V.Undef, bd_468, ((V)(JsStrBuf.Begin().S("left:").V(x_476).S("px;top:").N((70D + ((ToNum(i_477) % 2D) * 14D))).S("px;width:10px;height:70px;border-radius:10px;background:#3ab07a;transform-origin:50% 100%;transform:rotate(").N((NumTruthy((ToNum(i_477) % 2D)) ? 6D : (-6D))).S("deg);").End())));
}, 2, "", true));
return default;
}, 1, "back", true)).Put("fx", Fn((V _arrowThis486, int _argc479, V p_485, V _a482, V _a483, V _a484, V[] _rest480) => {
return Call(parts_23, V.Undef, p_485, ((V)(16D)), ((V)("width:7px;height:7px;border-radius:50%;border:1.5px solid rgba(255,255,255,0.8);box-sizing:border-box;")), V.Null, Fn((V _arrowThis495, int _argc487, V i_493, V t_494, V _a491, V _a492, V[] _rest488) => {
double a_496 = 0;
a_496 = (((ToNum(t_494) * 0.25) + (ToNum(i_493) / 16D)) % 1D);
return NewObj(4).Put("x", ((V)(((14D + ((ToNum(i_493) * 41D) % 300D)) + (FdLibm.Sin(ToNum(Add(((V)((ToNum(t_494) * 2D))), i_493))) * 4D))))).Put("y", ((V)((150D - (a_496 * 150D))))).Put("k", ((V)((0.6 + ((ToNum(i_493) % 3D) * 0.4))))).Put("o", ((V)(0.9))).V;
return default;
}, 2, "", true));
}, 1, "fx", true)).Put("lyr", Arr(Arr(((V)(4D)), ((V)(12D)), ((V)("Splashing waves and dolphin flips,"))), Arr(((V)(12D)), ((V)(20D)), ((V)("eight arms tango, swirls and dips,"))), Arr(((V)(20D)), ((V)(28D)), ((V)("mermaid tail goes flick-flick-flash!"))), Arr(((V)(30D)), ((V)(38D)), ((V)("Squish, squish, SQUAD!")), ((V)("#8fe8ff"))), Arr(((V)(38D)), ((V)(46D)), ((V)("Make a splash!")), ((V)("#8fe8ff"))))).V));
Invoke(S_396, "push", Call(verse_65, V.Undef, NewObj(10).Put("a", ((V)(130D))).Put("rgb", ((V)("255,220,120"))).Put("title", ((V)("FRUIT PATCH!"))).Put("c1", ((V)("#a6f06a"))).Put("c2", ((V)("#ffb84a"))).Put("pop", ((V)(1D))).Put("who", Arr(Arr(((V)("pina")), ((V)("Pina")), ((V)("Tropical Sway"))), Arr(((V)("berri")), ((V)("Berri")), ((V)("Berry Bop"))), Arr(((V)("peachy")), ((V)("Peachy")), ((V)("Orchard Drop"))))).Put("back", Fn((V _arrowThis504, int _argc497, V bd_503, V _a500, V _a501, V _a502, V[] _rest498) => {
Call(D_10, V.Undef, bd_503, ((V)("inset:0;background:linear-gradient(#8fe0ff,#fff2b0);")));
Call(D_10, V.Undef, bd_503, ((V)("left:250px;top:14px;width:36px;height:36px;border-radius:50%;background:#ffd23a;box-shadow:0 0 20px 8px rgba(255,210,58,0.6);")));
Call(D_10, V.Undef, bd_503, ((V)("left:-20px;top:96px;width:360px;height:44px;border-radius:50% 50% 0 0;background:#7ac85a;")));
Invoke(Arr(((V)(40D)), ((V)(120D)), ((V)(200D))), "forEach", Fn((V _arrowThis512, int _argc505, V x_511, V _a508, V _a509, V _a510, V[] _rest506) => {
return Call(D_10, V.Undef, bd_503, ((V)(JsStrBuf.Begin().S("left:").V(x_511).S("px;top:72px;width:46px;height:40px;border-radius:50%;background:radial-gradient(circle at 30% 40%,#ff5a6a 0 4px,transparent 5px),radial-gradient(circle at 70% 60%,#ffb84a 0 4px,transparent 5px),#4a9a4a;").End())));
}, 1, "", true));
return default;
}, 1, "back", true)).Put("fx", Fn((V _arrowThis520, int _argc513, V p_519, V _a516, V _a517, V _a518, V[] _rest514) => {
return Call(parts_23, V.Undef, p_519, ((V)(8D)), ((V)("width:6px;height:9px;border-radius:50% 0;background:#6ac04a;")), V.Null, Fn((V _arrowThis529, int _argc521, V i_527, V t_528, V _a525, V _a526, V[] _rest522) => {
double a_530 = 0;
a_530 = (((ToNum(t_528) * 0.18) + (ToNum(i_527) / 8D)) % 1D);
return NewObj(4).Put("x", ((V)((((((ToNum(i_527) * 53D) + (ToNum(t_528) * 14D)) % 330D) - 5D) + (FdLibm.Sin(ToNum(Add(((V)((ToNum(t_528) * 2D))), i_527))) * 8D))))).Put("y", ((V)((a_530 * 140D)))).Put("r", ((V)((FdLibm.Sin(ToNum(Add(((V)((ToNum(t_528) * 2D))), i_527))) * 60D)))).Put("o", ((V)(0.8))).V;
return default;
}, 2, "", true));
}, 1, "fx", true)).Put("lyr", Arr(Arr(((V)(4D)), ((V)(12D)), ((V)("Tropical sway in the sun,"))), Arr(((V)(12D)), ((V)(20D)), ((V)("berry bop, the fun\u2019s begun,"))), Arr(((V)(20D)), ((V)(28D)), ((V)("peachy drops right off the tree!"))), Arr(((V)(30D)), ((V)(38D)), ((V)("Squish, squish, SQUAD!")), ((V)("#a6f06a"))), Arr(((V)(38D)), ((V)(46D)), ((V)("Fruity and free!")), ((V)("#a6f06a"))))).V));
Invoke(S_396, "push", Call(verse_65, V.Undef, NewObj(10).Put("a", ((V)(180D))).Put("rgb", ((V)("200,150,255"))).Put("title", ((V)("DREAMLAND!"))).Put("c1", ((V)("#c9a6ff"))).Put("c2", ((V)("#ff8fd0"))).Put("pop", ((V)(1D))).Put("who", Arr(Arr(((V)("pixie")), ((V)("Pixie")), ((V)("Pixie Jig"))), Arr(((V)("drako")), ((V)("Drako")), ((V)("Rawr Rumble"))), Arr(((V)("ember")), ((V)("Flicker")), ((V)("Phoenix Inferno"))))).Put("back", Fn((V _arrowThis538, int _argc531, V bd_537, V _a534, V _a535, V _a536, V[] _rest532) => {
Call(D_10, V.Undef, bd_537, ((V)("inset:0;background:linear-gradient(#2a1a6a,#8a5ac8);")));
Invoke(bd_537, "appendChild", Call(stars_30, V.Undef, bd_537, ((V)(60D)), ((V)(320D)), ((V)(120D)), ((V)(9D)), ((V)("#fff")), ((V)(1.3))));
Call(D_10, V.Undef, bd_537, ((V)("left:40px;top:30px;width:240px;height:240px;border-radius:50%;background:radial-gradient(circle,transparent 52%,#ff6f8a 52% 56%,#ffb84a 56% 60%,#ffe66b 60% 64%,#7ae07a 64% 68%,#6ab0ff 68% 72%,#b07aff 72% 76%,transparent 76%);opacity:0.75;")));
return default;
}, 1, "back", true)).Put("fx", Fn((V _arrowThis546, int _argc539, V p_545, V _a542, V _a543, V _a544, V[] _rest540) => {
return Call(parts_23, V.Undef, p_545, ((V)(14D)), ((V)("width:8px;height:8px;color:#fff6a0;")), CH_37, Fn((V _arrowThis555, int _argc547, V i_553, V t_554, V _a551, V _a552, V[] _rest548) => {
double a_556 = 0;
a_556 = (((ToNum(t_554) * 0.3) + (ToNum(i_553) / 14D)) % 1D);
return NewObj(5).Put("x", ((V)(((10D + ((ToNum(i_553) * 61D) % 300D)) + (FdLibm.Sin(ToNum(Add(t_554, i_553))) * 6D))))).Put("y", ((V)((10D + ((ToNum(i_553) * 37D) % 110D))))).Put("r", ((V)(((ToNum(t_554) * 90D) + (ToNum(i_553) * 30D))))).Put("k", ((V)((0.5 + (0.5 * FdLibm.Sin((System.Math.PI * a_556))))))).Put("o", ((V)(FdLibm.Sin((System.Math.PI * a_556))))).V;
return default;
}, 2, "", true));
}, 1, "fx", true)).Put("lyr", Arr(Arr(((V)(4D)), ((V)(12D)), ((V)("Pixie jig with sparkly dust,"))), Arr(((V)(12D)), ((V)(20D)), ((V)("dragon rumble, rawr we must,"))), Arr(((V)(20D)), ((V)(28D)), ((V)("phoenix flames light up the night!"))), Arr(((V)(30D)), ((V)(38D)), ((V)("Squish, squish, SQUAD!")), ((V)("#c9a6ff"))), Arr(((V)(38D)), ((V)(46D)), ((V)("Shining bright!")), ((V)("#c9a6ff"))))).V));
Invoke(S_396, "push", NewObj(5).Put("a", ((V)(230D))).Put("b", ((V)(240D))).Put("rgb", ((V)("120,120,200"))).Put("lit", Fn((V _arrowThis564, int _argc557, V t_563, V _a560, V _a561, V _a562, V[] _rest558) => {
return ((V)(0.1));
}, 1, "lit", true)).Put("mk", Fn((V _self565, int _argc566, V L_572, V _a569, V _a570, V _a571, V[] _rest567) => {
V St_573 = default;
V bo_574 = default;
V sp_575 = default;
if (_self565.IsNullish) _self565 = GlobalV;
St_573 = Call(stage_60, V.Undef, L_572, Fn((V _arrowThis583, int _argc576, V bd_582, V _a579, V _a580, V _a581, V[] _rest577) => {
return Call(D_10, V.Undef, bd_582, ((V)("inset:0;background:#120826;")));
}, 1, "", true));
bo_574 = Call(actor_17, V.Undef, Get(St_573, "act"), ((V)("boo")), ((V)(W_36)));
sp_575 = Call(bub_21, V.Undef, L_572);
return Fn((V _arrowThis591, int _argc584, V t_590, V _a587, V _a588, V _a589, V[] _rest585) => {
Call(pose_18, V.Undef, bo_574, Call(go_19, V.Undef, t_590, Arr(Arr(((V)(0D)), ((V)(360D)), ((V)(140D)), NewObj(1).Put("m", ((V)("float"))).V), Arr(((V)(3D)), ((V)(160D)), ((V)(140D)))), NewObj(2).Put("m", ((V)("float"))).Put("gy", ((V)(FY_35))).V));
Invoke(St_573, "upd", t_590, NewObj(3).Put("sp", Arr(Arr(((V)(160D)), ((V)(0D)), ((V)((0.7 * ToNum(Call(P_11, V.Undef, t_590, ((V)(2.5)), ((V)(3.5)))))))))).Put("dark", ((V)(0.85))).Put("ds", Arr(((V)(160D)), ((V)(118D)))).V);
Call(lines_22, V.Undef, sp_575, t_590, Arr(Arr(((V)(4D)), ((V)(9D)), ((V)("...one more time?")), ((V)("b")))), NewObj(1).Put("b", Arr(((V)(160D)), ((V)(84D)))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
BK_397 = Arr(((V)("frybo")), ((V)("octo")), ((V)("pina")), ((V)("pixie")), ((V)("peachy")), ((V)("marina")), ((V)("bunbun")));
FR_398 = Arr(((V)("mallow")), ((V)("finn")), ((V)("berri")), ((V)("mittens")), ((V)("boo")), ((V)("drako")), ((V)("ember")));
Invoke(S_396, "push", NewObj(6).Put("a", ((V)(240D))).Put("b", ((V)(285D))).Put("rgb", ((V)("255,200,240"))).Put("inF", (false ? V.True : V.False)).Put("lit", Fn((V _arrowThis599, int _argc592, V t_598, V _a595, V _a596, V _a597, V[] _rest593) => {
return ((V)((1D + (0.25 * FdLibm.Exp(((-((ToNum(t_598) / B_34) % 1D)) * 5D))))));
}, 1, "lit", true)).Put("mk", Fn((V _self600, int _argc601, V L_607, V _a604, V _a605, V _a606, V[] _rest602) => {
V St_608 = default;
V bn_609 = default;
V fn_610 = default;
V STY_611 = default;
V bg_612 = default;
V G_613 = default;
V gx_614 = default;
V gn_615 = default;
V wa_616 = default;
V pg_617 = default;
V gb_618 = default;
V cf_619 = default;
if (_self600.IsNullish) _self600 = GlobalV;
St_608 = Call(stage_60, V.Undef, L_607, Fn((V _arrowThis627, int _argc620, V bd_626, V _a623, V _a624, V _a625, V[] _rest621) => {
Call(D_10, V.Undef, bd_626, ((V)("inset:0;background:conic-gradient(from 0deg at 50% 100%,#ff6fa8,#ffd66b,#8fe8ff,#a6f06a,#c9a6ff,#ff6fa8);")));
return default;
}, 1, "", true));
bn_609 = Invoke(BK_397, "map", Fn((V _arrowThis635, int _argc628, V k_634, V _a631, V _a632, V _a633, V[] _rest629) => {
return Call(actor_17, V.Undef, Get(St_608, "act"), k_634, ((V)((W_36 - 12D))));
}, 1, "", true));
fn_610 = Invoke(FR_398, "map", Fn((V _arrowThis643, int _argc636, V k_642, V _a639, V _a640, V _a641, V[] _rest637) => {
return Call(actor_17, V.Undef, Get(St_608, "act"), k_642, ((V)((W_36 - 4D))));
}, 1, "", true));
STY_611 = Arr(((V)("bounce")), ((V)("sway")), ((V)("jump")), ((V)("twirl")), ((V)("shuffle")), ((V)("spin")), ((V)("wave")));
bg_612 = Get(Get(St_608, "bd"), "firstChild");
G_613 = Call(guests_66, V.Undef, Invoke(BK_397, "concat", FR_398));
gx_614 = Invoke(Invoke(Arr(((V)(138D)), ((V)(182D)), ((V)(94D)), ((V)(226D))), "slice", ((V)(0D)), Get(G_613, "length")), "sort", Fn((V _arrowThis652, int _argc644, V a_650, V b_651, V _a648, V _a649, V[] _rest645) => {
return ((V)((ToNum(a_650) - ToNum(b_651))));
}, 2, "", true));
gn_615 = Invoke(G_613, "map", Fn((V _arrowThis660, int _argc653, V c_659, V _a656, V _a657, V _a658, V[] _rest654) => {
return Call(actor_17, V.Undef, Get(St_608, "act"), Get(c_659, "key"), ((V)((W_36 + 2D))));
}, 1, "", true));
wa_616 = Call(wash_63, V.Undef, L_607, ((V)("#ffffff")));
pg_617 = Call(glow_24, V.Undef, L_607, ((V)("rgba(170,245,255,0.95)")), ((V)(26D)), ((V)("z-index:46;")));
gb_618 = Call(D_10, V.Undef, L_607, ((V)("left:0;top:14px;width:320px;text-align:center;font-weight:700;z-index:40;display:none;-webkit-text-stroke:3px #2a0f4f;paint-order:stroke fill;color:#fff;")), ((V)("<div style=\"font-size:22px;color:#ffd66b;text-shadow:0 0 10px #ff6fa8;\">GUEST STARS!</div><div style=\"font-size:12px;\"></div>")));
Set(Get(gb_618, "lastChild"), "textContent", Call(andList_67, V.Undef, Invoke(G_613, "map", Fn((V _arrowThis668, int _argc661, V c_667, V _a664, V _a665, V _a666, V[] _rest662) => {
return (Get(c_667, "name") is var _t669 && Truthy(_t669) ? _t669 : Get(c_667, "key"));
}, 1, "", true))));
cf_619 = Call(parts_23, V.Undef, Get(St_608, "act"), ((V)(30D)), ((V)("width:5px;height:3px;border-radius:1px;")), V.Null, Fn((V _arrowThis678, int _argc670, V i_676, V t_677, V _a674, V _a675, V[] _rest671) => {
double a_679 = 0;
a_679 = (((ToNum(t_677) * 0.3) + (ToNum(i_676) / 30D)) % 1D);
return NewObj(4).Put("x", ((V)((((ToNum(i_676) * 53D) + (FdLibm.Sin(ToNum(Add(t_677, i_676))) * 20D)) % 320D)))).Put("y", ((V)(((a_679 * 190D) - 10D)))).Put("r", ((V)(((ToNum(t_677) * 300D) + (ToNum(i_676) * 30D))))).Put("o", ((V)(0.95))).V;
return default;
}, 2, "", true));
Invoke(Invoke(Get(St_608, "act"), "querySelectorAll", ((V)("div"))), "forEach", Fn((V _arrowThis688, int _argc680, V n_686, V i_687, V _a684, V _a685, V[] _rest681) => {
if ((SEqS(Get(Get(n_686, "style"), "width"), "5px") && SEqS(Get(Get(n_686, "style"), "height"), "3px"))) {
Set(Get(n_686, "style"), "background", GetIdx(Arr(((V)("#ffd66b")), ((V)("#ff8fb8")), ((V)("#8fe8ff")), ((V)("#a6f06a")), ((V)("#c9a6ff"))), (ToNum(i_687) % 5D)));
}
return default;
}, 2, "", true));
return Fn((V _arrowThis696, int _argc689, V t_695, V _a692, V _a693, V _a694, V[] _rest690) => {
double all_697 = 0;
double pu_698 = 0;
double sw_699 = 0;
V gs_700 = default;
Set(Get(bg_612, "style"), "filter", ((V)(JsStrBuf.Begin().S("hue-rotate(").V(Invoke(((V)(((ToNum(t_695) * 40D) % 360D))), "toFixed", ((V)(0D)))).S("deg) brightness(0.8)").End())));
all_697 = (System.Math.Floor((ToNum(t_695) / 8D)) % 2D);
pu_698 = (ToNum(t_695) - 30D);
Invoke(bn_609, "forEach", Fn((V _arrowThis709, int _argc701, V n_707, V i_708, V _a705, V _a706, V[] _rest702) => {
return Call(pose_18, V.Undef, n_707, Call(dance_20, V.Undef, t_695, ((V)((40D + (ToNum(i_708) * 40D)))), ((V)(132D)), (NumTruthy(all_697) ? ((V)("jump")) : GetK(STY_611, i_708)), ((V)(B_34)), ((V)((ToNum(i_708) * 0.2)))));
}, 2, "", true));
Invoke(fn_610, "forEach", Fn((V _arrowThis718, int _argc710, V n_716, V i_717, V _a714, V _a715, V[] _rest711) => {
double x_719 = 0;
V st_720 = default;
x_719 = (28D + (ToNum(i_717) * 44D));
st_720 = (NumTruthy(all_697) ? GetIdx(STY_611, (ToNum(Add(i_717, ((V)(3D)))) % 7D)) : GetIdx(STY_611, (ToNum(Add(i_717, ((V)(2D)))) % 7D)));
if (((SEqN(i_717, 3D) && (pu_698 >= 0D)) && (pu_698 < 2.8))) {
Call(posA_53, V.Undef, n_716, Call(popPose_58, V.Undef, ((V)(pu_698)), ((V)(x_719))));
Call(popGlint_59, V.Undef, pg_617, ((V)(pu_698)), ((V)(x_719)));
return default;
}
Call(pose_18, V.Undef, n_716, (LtN(t_695, 2.4) ? Call(go_19, V.Undef, t_695, Arr(Arr(((V)(0D)), ((V)((LtN(i_717, 4D) ? (-40D) : 360D)))), Arr(((V)((1.5 + (System.Math.Abs((3D - ToNum(i_717))) * 0.2)))), ((V)(x_719)))), NewObj(3).Put("y", ((V)(FY_35))).Put("f", ((V)("front"))).Put("m", ((V)("run"))).V) : Call(dance_20, V.Undef, t_695, ((V)(x_719)), ((V)(FY_35)), st_720, ((V)(B_34)), ((V)((ToNum(i_717) * 0.3))))));
return default;
}, 2, "", true));
if (!(((pu_698 >= 0D) && (pu_698 < 2.8)))) {
Call(show_16, V.Undef, pg_617, (false ? V.True : V.False));
}
Invoke(gn_615, "forEach", Fn((V _arrowThis729, int _argc721, V n_727, V j_728, V _a725, V _a726, V[] _rest722) => {
double t0_730 = 0;
double y0_731 = 0;
V e_732 = default;
t0_730 = (20D + (ToNum(j_728) * 0.18));
y0_731 = (FY_35 + 12D);
if (LtN(t_695, t0_730)) {
Call(pose_18, V.Undef, n_727, V.Null);
return default;
}
e_732 = Call(seg_38, V.Undef, t_695, ((V)(t0_730)), ((V)((t0_730 + 1.1))));
Call(pose_18, V.Undef, n_727, (LtN(e_732, 1D) ? NewObj(6).Put("x", GetK(gx_614, j_728)).Put("y", ((V)((ToNum(Call(lerp_29, V.Undef, ((V)(232D)), ((V)(y0_731)), Invoke(E_12, "out", e_732))) - (FdLibm.Sin((System.Math.PI * ToNum(e_732))) * 34D))))).Put("gy", ((V)(y0_731))).Put("v", ((V)("front"))).Put("k", ((V)(1.06))).Put("r", ((V)((((NumTruthy((ToNum(j_728) % 2D)) ? 1D : (-1D)) * 10D) * FdLibm.Sin((System.Math.PI * ToNum(e_732))))))).V : NewObj(2).Spread(Call(dance_20, V.Undef, t_695, GetK(gx_614, j_728), ((V)(y0_731)), (NumTruthy(all_697) ? ((V)("jump")) : GetIdx(STY_611, (ToNum(Add(j_728, ((V)(4D)))) % 7D))), ((V)(B_34)), ((V)((ToNum(j_728) * 0.4))))).Put("k", ((V)(1.06))).V));
return default;
}, 2, "", true));
if (Truthy(Get(G_613, "length"))) {
Call(put_15, V.Undef, gb_618, ((V)(160D)), ((V)(34D)), Call(P_11, V.Undef, t_695, ((V)(20.4)), ((V)(21D)), Get(E_12, "back")), ((V)(0D)), Call(win_14, V.Undef, t_695, ((V)(20.4)), ((V)(27.5)), ((V)(0.4))));
} else {
Call(show_16, V.Undef, gb_618, (false ? V.True : V.False));
}
Call(cf_619, V.Undef, t_695);
Set(Get(wa_616, "style"), "opacity", Invoke(((V)((0.22 * ToNum(Call(beatW_64, V.Undef, t_695))))), "toFixed", ((V)(3D))));
sw_699 = (FdLibm.Sin((ToNum(t_695) * 2D)) * 26D);
gs_700 = ((Get(G_613, "length") is var _t733 && !Truthy(_t733) ? _t733 : (GeN(t_695, 20D) ? V.True : V.False)) is var _t734 && !Truthy(_t734) ? _t734 : (LtN(t_695, 28D) ? V.True : V.False));
Invoke(St_608, "upd", t_695, NewObj(2).Put("sp", (Truthy(gs_700) ? Invoke(Invoke(gx_614, "slice", ((V)(0D)), ((V)(3D))), "map", Fn((V _arrowThis742, int _argc735, V x_741, V _a738, V _a739, V _a740, V[] _rest736) => {
return Arr(x_741, ((V)(0D)), ((V)(1D)));
}, 1, "", true)) : Arr(Arr(((V)(70D)), ((V)(sw_699)), ((V)(0.9))), Arr(((V)(160D)), ((V)((-sw_699))), ((V)(0.9))), Arr(((V)(250D)), ((V)(sw_699)), ((V)(0.9)))))).Put("cap", Call(lyr_61, V.Undef, t_695, Arr(Arr(((V)(4D)), ((V)(12D)), ((V)("Every friend has got a groove!"))), Arr(((V)(12D)), ((V)(20D)), ((V)("Every paw has got a move!"))), Arr(((V)(22D)), ((V)(30D)), ((V)("Squish, squish, SQUAD!")), ((V)("#ffd66b"))), Arr(((V)(30D)), ((V)(38D)), ((V)("Everybody MOVE!")), ((V)("#ff8fb8"))), Arr(((V)(38D)), ((V)(45D)), ((V)("Squish, squish, SQUAD!")), ((V)("#8fe8ff")))))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_396, "push", NewObj(6).Put("a", ((V)(285D))).Put("b", ((V)(300D))).Put("rgb", ((V)("255,220,180"))).Put("inF", (false ? V.True : V.False)).Put("outF", (false ? V.True : V.False)).Put("mk", Fn((V _self743, int _argc744, V L_750, V _a747, V _a748, V _a749, V[] _rest745) => {
V St_751 = default;
V G_752 = default;
V ks_753 = default;
V nn_754 = default;
double gap_755 = 0;
double kk_756 = 0;
V ns_757 = default;
V sp_758 = default;
V fl_759 = default;
if (_self743.IsNullish) _self743 = GlobalV;
St_751 = Call(stage_60, V.Undef, L_750, Fn((V _arrowThis767, int _argc760, V bd_766, V _a763, V _a764, V _a765, V[] _rest761) => {
return Call(D_10, V.Undef, bd_766, ((V)("inset:0;background:radial-gradient(ellipse at 50% 40%,#6a2a9a,#1a0a3a 75%);")));
}, 1, "", true));
G_752 = Call(guests_66, V.Undef, Invoke(BK_397, "concat", FR_398));
ks_753 = Invoke(FR_398, "concat", Invoke(G_752, "map", Fn((V _arrowThis775, int _argc768, V c_774, V _a771, V _a772, V _a773, V[] _rest769) => {
return Get(c_774, "key");
}, 1, "", true)));
nn_754 = Get(ks_753, "length");
gap_755 = Min(44D, (300D / ToNum(nn_754)));
kk_756 = Max(0.72, Min(1D, (gap_755 / 42D)));
ns_757 = Invoke(ks_753, "map", Fn((V _arrowThis783, int _argc776, V k_782, V _a779, V _a780, V _a781, V[] _rest777) => {
return Call(actor_17, V.Undef, Get(St_751, "act"), k_782, ((V)((W_36 - 4D))));
}, 1, "", true));
sp_758 = Call(bub_21, V.Undef, L_750);
fl_759 = Call(parts_23, V.Undef, Get(St_751, "act"), ((V)(12D)), ((V)("width:9px;height:9px;color:#ff6f8a;")), ((V)("<svg viewBox=\"0 0 10 10\" width=\"9\" height=\"9\"><circle cx=\"5\" cy=\"5\" r=\"2\" fill=\"#ffd66b\"></circle><circle cx=\"5\" cy=\"1.8\" r=\"2\" fill=\"currentColor\"></circle><circle cx=\"8.2\" cy=\"5\" r=\"2\" fill=\"currentColor\"></circle><circle cx=\"5\" cy=\"8.2\" r=\"2\" fill=\"currentColor\"></circle><circle cx=\"1.8\" cy=\"5\" r=\"2\" fill=\"currentColor\"></circle></svg>")), Fn((V _arrowThis792, int _argc784, V i_790, V t_791, V _a788, V _a789, V[] _rest785) => {
double d_793 = 0;
d_793 = ((ToNum(t_791) - 2D) - ((ToNum(i_790) % 6D) * 0.4));
if (((d_793 < 0D) || (d_793 > 2D))) {
return V.Null;
}
return NewObj(4).Put("x", ((V)((20D + (ToNum(i_790) * 26D))))).Put("y", ((V)(((10D + (d_793 * 70D)) + ((d_793 * d_793) * 20D))))).Put("r", ((V)((d_793 * 300D)))).Put("o", ((V)(1D))).V;
return default;
}, 2, "", true));
return Fn((V _arrowThis801, int _argc794, V t_800, V _a797, V _a798, V _a799, V[] _rest795) => {
Invoke(ns_757, "forEach", Fn((V _arrowThis810, int _argc802, V n_808, V i_809, V _a806, V _a807, V[] _rest803) => {
double bw_811 = 0;
bw_811 = (FdLibm.Sin((System.Math.PI * ToNum(Call(cl_28, V.Undef, ((V)(((ToNum(t_800) % 4D) / 1.4))))))) * (LtN(t_800, 10D) ? 1D : 0D));
Call(pose_18, V.Undef, n_808, NewObj(7).Put("x", ((V)((160D + ((ToNum(i_809) - ((ToNum(nn_754) - 1D) / 2D)) * gap_755))))).Put("y", ((V)(FY_35))).Put("v", ((V)("front"))).Put("r", ((V)(0D))).Put("k", ((V)(kk_756))).Put("sy", ((V)((1D - (0.14 * bw_811))))).Put("sx", ((V)((1D + (0.06 * bw_811))))).V);
return default;
}, 2, "", true));
Call(fl_759, V.Undef, t_800);
Invoke(St_751, "upd", t_800, NewObj(3).Put("cur", ((V)((1D - ToNum(Call(P_11, V.Undef, t_800, ((V)(10.5)), ((V)(14D)), Get(E_12, "io"))))))).Put("sp", Arr(Arr(((V)(160D)), ((V)(0D)), ((V)((1D - ToNum(Call(P_11, V.Undef, t_800, ((V)(12D)), ((V)(14D)))))))))).Put("cap", Call(lyr_61, V.Undef, t_800, Arr(Arr(((V)(0.5)), ((V)(4D)), ((V)("Thank you!"))), Arr(((V)(4.4)), ((V)(9.6)), ((V)("Goodnight, Squish Squad!")), ((V)("#ffd66b")))))).V);
Call(sp_758, V.Undef, V.Null);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
return Call(film_25, V.Undef, S_396, NewObj(1).Put("rgb", ((V)("255,200,240"))).V);
return default;
}, 0, "mk", false);
score_70 = Fn((V _self812, int _argc813, V Q_819, V _a816, V _a817, V _a818, V[] _rest814) => {
V I_820 = default;
V PR_821 = default;
V A_822 = default;
V A2_823 = default;
V C_824 = default;
V sing_825 = default;
V band_826 = default;
V V_827 = default;
V so_828 = default;
if (_self812.IsNullish) _self812 = GlobalV;
I_820 = Call(snd_26, V.Undef, Q_819);
PR_821 = Arr(Arr(((V)(48D)), Arr(((V)(60D)), ((V)(64D)), ((V)(67D)))), Arr(((V)(45D)), Arr(((V)(60D)), ((V)(64D)), ((V)(69D)))), Arr(((V)(41D)), Arr(((V)(60D)), ((V)(65D)), ((V)(69D)))), Arr(((V)(43D)), Arr(((V)(59D)), ((V)(62D)), ((V)(67D)))));
A_822 = Arr(Arr(((V)(0D)), ((V)(67D)), ((V)(1D))), Arr(((V)(1D)), ((V)(67D)), ((V)(1D))), Arr(((V)(2D)), ((V)(69D)), ((V)(1D))), Arr(((V)(3D)), ((V)(67D)), ((V)(1D))), Arr(((V)(4D)), ((V)(72D)), ((V)(1.5))), Arr(((V)(5.5)), ((V)(71D)), ((V)(0.5))), Arr(((V)(6D)), ((V)(67D)), ((V)(2D))));
A2_823 = Arr(Arr(((V)(0D)), ((V)(69D)), ((V)(1D))), Arr(((V)(1D)), ((V)(69D)), ((V)(1D))), Arr(((V)(2D)), ((V)(71D)), ((V)(1D))), Arr(((V)(3D)), ((V)(69D)), ((V)(1D))), Arr(((V)(4D)), ((V)(74D)), ((V)(1.5))), Arr(((V)(5.5)), ((V)(72D)), ((V)(0.5))), Arr(((V)(6D)), ((V)(71D)), ((V)(2D))));
C_824 = Arr(Arr(((V)(0D)), ((V)(72D)), ((V)(1D))), Arr(((V)(1D)), ((V)(72D)), ((V)(1D))), Arr(((V)(2D)), ((V)(72D)), ((V)(2D))), Arr(((V)(4D)), ((V)(74D)), ((V)(1D))), Arr(((V)(5D)), ((V)(76D)), ((V)(1D))), Arr(((V)(6D)), ((V)(74D)), ((V)(1D))), Arr(((V)(7D)), ((V)(72D)), ((V)(1D))), Arr(((V)(8D)), ((V)(79D)), ((V)(2D))), Arr(((V)(10D)), ((V)(77D)), ((V)(1D))), Arr(((V)(11D)), ((V)(76D)), ((V)(1D))), Arr(((V)(12D)), ((V)(72D)), ((V)(4D))));
sing_825 = Fn((V _arrowThis843, int _argc829, V t0_835, V ph_836, V _a833, V _a834, V[] _rest830) => {
V tr_838 = default;
V v_840 = default;
V f_842 = default;
{ V _t837 = _a833; if (_t837.IsUndef) _t837 = ((V)(0D));
tr_838 = _t837; }
{ V _t839 = _a834; if (_t839.IsUndef) _t839 = ((V)(0.07));
v_840 = _t839; }
{ V _t841 = (_argc829 > 4 ? _rest830[0] : V.Undef); if (_t841.IsUndef) _t841 = Get(I_820, "voice");
f_842 = _t841; }
return Invoke(ph_836, "forEach", Fn((V _arrowThis857, int _argc844, V _a846, V _a847, V _a848, V _a849, V[] _rest845) => {
V o_852 = default;
V m_854 = default;
V d_856 = default;
{ V _t850 = ListOf(_a846);
{ V _t851 = GetIdx(_t850, 0D);
o_852 = _t851; }
{ V _t853 = GetIdx(_t850, 1D);
m_854 = _t853; }
{ V _t855 = GetIdx(_t850, 2D);
d_856 = _t855; }
}
return Call(f_842, V.Undef, Add(t0_835, ((V)((ToNum(o_852) * B_34)))), Add(m_854, tr_838), ((V)(((ToNum(d_856) * B_34) * 0.95))), v_840);
}, 1, "", true));
}, 5, "", true);
band_826 = Fn((V _arrowThis869, int _argc858, V t0_864, V t1_865, V sty_866, V _a863, V[] _rest859) => {
V tr_868 = default;
{ V _t867 = _a863; if (_t867.IsUndef) _t867 = ((V)(0D));
tr_868 = _t867; }
return Invoke(I_820, "beat", t0_864, t1_865, ((V)((B_34 / 2D))), Fn((V _arrowThis878, int _argc870, V t_876, V i_877, V _a874, V _a875, V[] _rest871) => {
double bar_879 = 0;
V p_880 = default;
V r_881 = default;
bar_879 = (System.Math.Floor((ToNum(i_877) / 8D)) % 4D);
p_880 = GetIdx(PR_821, bar_879);
r_881 = Add(GetIdx(p_880, 0D), tr_868);
if (((ToNum(i_877) % 4D) == 0D)) {
Invoke(I_820, "kick", t_876, ((V)(0.55)));
}
if (((ToNum(i_877) % 8D) == 4D)) {
Invoke(I_820, "snare", t_876, ((V)(0.18)));
if (SEqS(sty_866, "snack")) {
Invoke(I_820, "clap", t_876, ((V)(0.12)));
}
}
if (NumTruthy((ToNum(i_877) % 2D))) {
Invoke(I_820, "hat", t_876, ((V)(0.03)));
}
if (SEqS(sty_866, "snack")) {
if (((ToNum(i_877) % 2D) == 0D)) {
Invoke(I_820, "bass", t_876, ((V)(((ToNum(r_881) - 12D) + (((ToNum(i_877) % 4D) == 2D) ? 12D : 0D)))), ((V)(0.18)), ((V)(0.13)));
}
if ((((ToNum(i_877) % 8D) == 2D) || ((ToNum(i_877) % 8D) == 6D))) {
Invoke(I_820, "pad", t_876, Invoke(GetIdx(p_880, 1D), "map", Fn((V _arrowThis889, int _argc882, V m_888, V _a885, V _a886, V _a887, V[] _rest883) => {
return Add(m_888, tr_868);
}, 1, "", true)), ((V)((B_34 * 0.4))), ((V)(0.03)), ((V)("square")), ((V)(2000D)));
}
} else {
if (SEqS(sty_866, "sea")) {
Invoke(I_820, "pluck", t_876, Add(Add(GetIdx(GetIdx(p_880, 1D), (ToNum(i_877) % 3D)), ((V)(12D))), tr_868), ((V)(0.3)), ((V)(0.035)));
if (((ToNum(i_877) % 4D) == 0D)) {
Invoke(I_820, "sub", t_876, ((V)((ToNum(r_881) - 12D))), ((V)((B_34 * 2D))), ((V)(0.1)));
}
if (((ToNum(i_877) % 8D) == 0D)) {
Invoke(I_820, "pad", t_876, Invoke(GetIdx(p_880, 1D), "map", Fn((V _arrowThis897, int _argc890, V m_896, V _a893, V _a894, V _a895, V[] _rest891) => {
return Add(m_896, tr_868);
}, 1, "", true)), ((V)((B_34 * 4D))), ((V)(0.015)), ((V)("triangle")), ((V)(1500D)));
}
} else {
if (SEqS(sty_866, "fruit")) {
Invoke(I_820, "pluck", t_876, Add(Add(GetIdx(GetIdx(p_880, 1D), ((ToNum(i_877) * 2D) % 3D)), ((V)(12D))), tr_868), ((V)(0.18)), ((V)(0.05)));
if (((ToNum(i_877) % 2D) == 0D)) {
Invoke(I_820, "bass", t_876, ((V)((ToNum(r_881) - 12D))), ((V)(0.2)), ((V)(0.1)));
}
if (((ToNum(i_877) % 4D) == 3D)) {
Invoke(I_820, "tone", t_876, ((V)(900D)), ((V)(0.05)), NewObj(2).Put("type", ((V)("triangle"))).Put("vol", ((V)(0.03))).V);
}
} else {
if (SEqS(sty_866, "dream")) {
if (((ToNum(i_877) % 2D) == 0D)) {
Invoke(I_820, "bell", t_876, Add(Add(GetIdx(GetIdx(p_880, 1D), ((ToNum(i_877) / 2D) % 3D)), ((V)(24D))), tr_868), ((V)(0.6)), ((V)(0.025)));
}
if (((ToNum(i_877) % 2D) == 0D)) {
Invoke(I_820, "bass", t_876, ((V)((ToNum(r_881) - 12D))), ((V)(0.25)), ((V)(0.12)));
}
if (((ToNum(i_877) % 8D) == 0D)) {
Invoke(I_820, "pad", t_876, Invoke(GetIdx(p_880, 1D), "map", Fn((V _arrowThis905, int _argc898, V m_904, V _a901, V _a902, V _a903, V[] _rest899) => {
return Add(m_904, tr_868);
}, 1, "", true)), ((V)((B_34 * 4D))), ((V)(0.02)), ((V)("sawtooth")), ((V)(1200D)));
}
} else {
if (((ToNum(i_877) % 2D) == 0D)) {
Invoke(I_820, "bass", t_876, ((V)(((ToNum(r_881) - 12D) + (((ToNum(i_877) % 4D) == 2D) ? 12D : 0D)))), ((V)(0.2)), ((V)(0.14)));
}
if (((ToNum(i_877) % 8D) == 0D)) {
Invoke(I_820, "pad", t_876, Invoke(GetIdx(p_880, 1D), "map", Fn((V _arrowThis913, int _argc906, V m_912, V _a909, V _a910, V _a911, V[] _rest907) => {
return Add(m_912, tr_868);
}, 1, "", true)), ((V)((B_34 * 4D))), ((V)(0.022)), ((V)("sawtooth")), ((V)(1600D)));
}
Invoke(I_820, "pluck", t_876, Add(Add(GetIdx(GetIdx(p_880, 1D), (ToNum(i_877) % 3D)), ((V)(12D))), tr_868), ((V)(0.12)), ((V)(0.025)));
}
}
}
}
return default;
}, 2, "", true));
}, 4, "", true);
Invoke(I_820, "pad", ((V)(0D)), Arr(((V)(48D)), ((V)(55D)), ((V)(60D)), ((V)(64D))), ((V)(6D)), ((V)(0.02)), ((V)("sawtooth")), ((V)(700D)));
Invoke(I_820, "beat", ((V)(1D)), ((V)(3.6)), ((V)(0.12)), Fn((V _arrowThis922, int _argc914, V t_920, V i_921, V _a918, V _a919, V[] _rest915) => {
return Invoke(I_820, "noise", t_920, ((V)(0.08)), NewObj(3).Put("ft", ((V)("bandpass"))).Put("f", ((V)((300D + (ToNum(i_921) * 30D))))).Put("vol", ((V)(0.02))).V);
}, 2, "", true));
Invoke(I_820, "crash", ((V)(3.6)), ((V)(0.08)));
Invoke(Arr(((V)(60D)), ((V)(64D)), ((V)(67D)), ((V)(72D)), ((V)(76D)), ((V)(79D))), "forEach", Fn((V _arrowThis931, int _argc923, V m_929, V k_930, V _a927, V _a928, V[] _rest924) => {
return Invoke(I_820, "bell", ((V)((3.8 + (ToNum(k_930) * 0.12)))), Add(m_929, ((V)(12D))), ((V)(0.8)), ((V)(0.04)));
}, 2, "", true));
Invoke(I_820, "beat", ((V)(5D)), ((V)(7D)), ((V)(B_34)), Fn((V _arrowThis940, int _argc932, V t_938, V i_939, V _a936, V _a937, V[] _rest933) => {
return Invoke(I_820, "kick", t_938, ((V)(0.3)));
}, 2, "", true));
Call(band_826, V.Undef, ((V)(7D)), ((V)(30D)), ((V)("pop")));
Call(sing_825, V.Undef, ((V)(7D)), A_822);
Call(sing_825, V.Undef, ((V)(11D)), A2_823);
Call(sing_825, V.Undef, ((V)(15D)), A_822);
Call(sing_825, V.Undef, ((V)(19D)), A2_823);
Call(sing_825, V.Undef, ((V)(23D)), C_824, ((V)(0D)), ((V)(0.08)));
Invoke(I_820, "crash", ((V)(23D)), ((V)(0.1)));
V_827 = Fn((V _arrowThis950, int _argc941, V a_947, V sty_948, V tr_949, V _a946, V[] _rest942) => {
Invoke(I_820, "crash", a_947, ((V)(0.12)));
Invoke(I_820, "brass", a_947, Add(((V)(60D)), tr_949), ((V)(1D)), ((V)(0.04)));
Invoke(I_820, "brass", a_947, Add(((V)(64D)), tr_949), ((V)(1D)), ((V)(0.04)));
Call(band_826, V.Undef, Add(a_947, ((V)(1D))), Add(a_947, ((V)(50D))), sty_948, tr_949);
Call(sing_825, V.Undef, Add(a_947, ((V)(4D))), A_822, tr_949);
Call(sing_825, V.Undef, Add(a_947, ((V)(8D))), A2_823, tr_949, ((V)(0.05)), Get(I_820, "lead"));
Call(sing_825, V.Undef, Add(a_947, ((V)(12D))), A_822, tr_949);
Call(sing_825, V.Undef, Add(a_947, ((V)(16D))), A2_823, tr_949, ((V)(0.05)), Get(I_820, "lead"));
Call(sing_825, V.Undef, Add(a_947, ((V)(20D))), A_822, tr_949);
Call(sing_825, V.Undef, Add(a_947, ((V)(24D))), A2_823, tr_949, ((V)(0.05)), Get(I_820, "lead"));
Invoke(I_820, "crash", Add(a_947, ((V)(30D))), ((V)(0.1)));
Call(sing_825, V.Undef, Add(a_947, ((V)(30D))), C_824, tr_949, ((V)(0.08)));
Call(sing_825, V.Undef, Add(a_947, ((V)(38D))), C_824, tr_949, ((V)(0.08)));
Call(sing_825, V.Undef, Add(a_947, ((V)(38D))), C_824, Add(tr_949, ((V)(12D))), ((V)(0.03)), Get(I_820, "lead"));
return default;
}, 3, "", true);
Call(V_827, V.Undef, ((V)(30D)), ((V)("snack")), ((V)(0D)));
Call(V_827, V.Undef, ((V)(80D)), ((V)("sea")), ((V)(2D)));
Call(V_827, V.Undef, ((V)(130D)), ((V)("fruit")), ((V)((-3D))));
Invoke(I_820, "crash", ((V)(178D)), ((V)(0.2)));
Invoke(I_820, "boom", ((V)(178D)), ((V)(0.25)));
Call(V_827, V.Undef, ((V)(180D)), ((V)("dream")), ((V)(3D)));
so_828 = Fn((V _arrowThis960, int _argc951, V a_957, V n_958, V u_959, V _a956, V[] _rest952) => {
return Add(Add(Add(a_957, ((V)(4D))), ((V)((ToNum(n_958) * 8D)))), u_959);
}, 3, "", true);
Invoke(I_820, "poof", Call(so_828, V.Undef, ((V)(30D)), ((V)(0D)), ((V)(3.15))), ((V)(0.12)));
Invoke(I_820, "poof", Call(so_828, V.Undef, ((V)(30D)), ((V)(0D)), ((V)(7.05))), ((V)(0.1)));
Invoke(I_820, "beat", Call(so_828, V.Undef, ((V)(30D)), ((V)(1D)), ((V)(4D))), Call(so_828, V.Undef, ((V)(30D)), ((V)(1D)), ((V)(6D))), ((V)(0.065)), Fn((V _arrowThis968, int _argc961, V t_967, V _a964, V _a965, V _a966, V[] _rest962) => {
return Invoke(I_820, "hat", t_967, ((V)(0.035)));
}, 1, "", true));
Invoke(I_820, "whoosh", Call(so_828, V.Undef, ((V)(30D)), ((V)(1D)), ((V)(7D))), ((V)(0.6)), ((V)(0.06)));
Invoke(Arr(((V)(2D)), ((V)(3D)), ((V)(6D))), "forEach", Fn((V _arrowThis976, int _argc969, V u_975, V _a972, V _a973, V _a974, V[] _rest970) => {
return Invoke(I_820, "boing", Call(so_828, V.Undef, ((V)(30D)), ((V)(2D)), u_975), ((V)(0.05)));
}, 1, "", true));
Invoke(I_820, "timp", Call(so_828, V.Undef, ((V)(30D)), ((V)(2D)), ((V)(7.2))), ((V)(0.35)));
Invoke(I_820, "splash", Call(so_828, V.Undef, ((V)(80D)), ((V)(0D)), ((V)(3D))), ((V)(0.12)));
Invoke(I_820, "splash", Call(so_828, V.Undef, ((V)(80D)), ((V)(0D)), ((V)(5D))), ((V)(0.14)));
Invoke(I_820, "whoosh", Call(so_828, V.Undef, ((V)(80D)), ((V)(1D)), ((V)(3.5))), ((V)(0.4)), ((V)(0.07)));
Invoke(I_820, "poof", Call(so_828, V.Undef, ((V)(80D)), ((V)(1D)), ((V)(3.55))), ((V)(0.08)));
Invoke(I_820, "beat", Call(so_828, V.Undef, ((V)(80D)), ((V)(2D)), ((V)(3D))), Call(so_828, V.Undef, ((V)(80D)), ((V)(2D)), ((V)(5.5))), ((V)(0.3)), Fn((V _arrowThis984, int _argc977, V t_983, V _a980, V _a981, V _a982, V[] _rest978) => {
return Invoke(I_820, "pop", t_983, ((V)(0.04)));
}, 1, "", true));
Invoke(I_820, "beat", Call(so_828, V.Undef, ((V)(80D)), ((V)(2D)), ((V)(7D))), Call(so_828, V.Undef, ((V)(80D)), ((V)(2D)), ((V)(8D))), ((V)(0.2)), Fn((V _arrowThis992, int _argc985, V t_991, V _a988, V _a989, V _a990, V[] _rest986) => {
return Invoke(I_820, "pop", t_991, ((V)(0.05)));
}, 1, "", true));
Invoke(I_820, "beat", Call(so_828, V.Undef, ((V)(130D)), ((V)(0D)), ((V)(4D))), Call(so_828, V.Undef, ((V)(130D)), ((V)(0D)), ((V)(5D))), ((V)(0.07)), Fn((V _arrowThis1000, int _argc993, V t_999, V _a996, V _a997, V _a998, V[] _rest994) => {
return Invoke(I_820, "noise", t_999, ((V)(0.05)), NewObj(3).Put("ft", ((V)("bandpass"))).Put("f", ((V)(2600D))).Put("vol", ((V)(0.03))).V);
}, 1, "", true));
Invoke(I_820, "pop", Call(so_828, V.Undef, ((V)(130D)), ((V)(1D)), ((V)(6.4))), ((V)(0.08)));
Invoke(I_820, "boing", Call(so_828, V.Undef, ((V)(130D)), ((V)(1D)), ((V)(5.6))), ((V)(0.06)));
Invoke(I_820, "whoosh", Call(so_828, V.Undef, ((V)(130D)), ((V)(2D)), ((V)(3D))), ((V)(0.45)), ((V)(0.05)));
Invoke(I_820, "pop", Call(so_828, V.Undef, ((V)(130D)), ((V)(2D)), ((V)(3.45))), ((V)(0.1)));
Invoke(I_820, "pop", Call(so_828, V.Undef, ((V)(130D)), ((V)(2D)), ((V)(3.95))), ((V)(0.06)));
Invoke(I_820, "sparkle", Call(so_828, V.Undef, ((V)(180D)), ((V)(0D)), ((V)(0.2))), ((V)(88D)), ((V)(0.03)));
Invoke(I_820, "sparkle", Call(so_828, V.Undef, ((V)(180D)), ((V)(0D)), ((V)(2D))), ((V)(91D)), ((V)(0.03)));
Invoke(I_820, "whoosh", Call(so_828, V.Undef, ((V)(180D)), ((V)(0D)), ((V)(2D))), ((V)(2D)), ((V)(0.04)));
Invoke(I_820, "rumble", Call(so_828, V.Undef, ((V)(180D)), ((V)(1D)), ((V)(4.5))), ((V)(1.5)), ((V)(0.12)));
Invoke(I_820, "tone", Call(so_828, V.Undef, ((V)(180D)), ((V)(1D)), ((V)(4.5))), ((V)(220D)), ((V)(1.2)), NewObj(6).Put("to", ((V)(140D))).Put("slide", ((V)(1.2))).Put("type", ((V)("sawtooth"))).Put("lp", ((V)(1200D))).Put("vol", ((V)(0.06))).Put("vib", Arr(((V)(18D)), ((V)(20D)))).V);
Invoke(I_820, "noise", Call(so_828, V.Undef, ((V)(180D)), ((V)(1D)), ((V)(4.6))), ((V)(1.3)), NewObj(5).Put("ft", ((V)("bandpass"))).Put("f", ((V)(900D))).Put("q", ((V)(0.6))).Put("vol", ((V)(0.06))).Put("at", ((V)(0.1))).V);
Invoke(I_820, "whoosh", Call(so_828, V.Undef, ((V)(180D)), ((V)(2D)), ((V)(3D))), ((V)(2D)), ((V)(0.05)));
Invoke(I_820, "boom", Call(so_828, V.Undef, ((V)(180D)), ((V)(2D)), ((V)(6D))), ((V)(0.22)));
Invoke(I_820, "sparkle", Call(so_828, V.Undef, ((V)(180D)), ((V)(2D)), ((V)(6.05))), ((V)(84D)), ((V)(0.035)));
Invoke(POPS_69, "forEach", Fn((V _arrowThis1010, int _argc1001, V _a1003, V _a1004, V _a1005, V _a1006, V[] _rest1002) => {
V t_1009 = default;
{ V _t1007 = ListOf(_a1003);
{ V _t1008 = GetIdx(_t1007, 0D);
t_1009 = _t1008; }
}
Invoke(I_820, "whoosh", Add(t_1009, ((V)(0.15))), ((V)(0.4)), ((V)(0.07)));
Invoke(I_820, "sparkle", Add(t_1009, ((V)(0.45))), ((V)(88D)), ((V)(0.03)));
Invoke(I_820, "whoosh", Add(t_1009, ((V)(1.9))), ((V)(0.4)), ((V)(0.05)));
Invoke(I_820, "pop", Add(t_1009, ((V)(2.4))), ((V)(0.1)));
return default;
}, 1, "", true));
Invoke(I_820, "tone", ((V)(230D)), ((V)(400D)), ((V)(1.2)), NewObj(5).Put("to", ((V)(80D))).Put("slide", ((V)(1.1))).Put("type", ((V)("sawtooth"))).Put("lp", ((V)(900D))).Put("vol", ((V)(0.06))).V);
Invoke(I_820, "pad", ((V)(231D)), Arr(((V)(48D)), ((V)(51D)), ((V)(55D))), ((V)(8D)), ((V)(0.02)), ((V)("triangle")), ((V)(800D)));
Invoke(I_820, "voice", ((V)(234D)), ((V)(72D)), ((V)(0.6)), ((V)(0.05)));
Invoke(I_820, "voice", ((V)(234.6)), ((V)(71D)), ((V)(0.6)), ((V)(0.05)));
Invoke(I_820, "voice", ((V)(235.4)), ((V)(67D)), ((V)(1.4)), ((V)(0.05)));
Invoke(I_820, "beat", ((V)(236D)), ((V)(240D)), ((V)(0.25)), Fn((V _arrowThis1019, int _argc1011, V t_1017, V i_1018, V _a1015, V _a1016, V[] _rest1012) => {
return Invoke(I_820, "snare", t_1017, ((V)((0.04 + (ToNum(i_1018) * 0.012)))));
}, 2, "", true));
Invoke(I_820, "crash", ((V)(240D)), ((V)(0.2)));
Invoke(I_820, "boom", ((V)(240D)), ((V)(0.3)));
Call(band_826, V.Undef, ((V)(240D)), ((V)(285D)), ((V)("pop")), ((V)(2D)));
Call(sing_825, V.Undef, ((V)(244D)), A_822, ((V)(2D)));
Call(sing_825, V.Undef, ((V)(248D)), A2_823, ((V)(2D)));
Call(sing_825, V.Undef, ((V)(252D)), A_822, ((V)(2D)), ((V)(0.05)), Get(I_820, "lead"));
Call(sing_825, V.Undef, ((V)(256D)), A2_823, ((V)(2D)), ((V)(0.05)), Get(I_820, "lead"));
Invoke(I_820, "crash", ((V)(260D)), ((V)(0.1)));
Invoke(Arr(((V)(62D)), ((V)(66D)), ((V)(69D)), ((V)(74D))), "forEach", Fn((V _arrowThis1028, int _argc1020, V m_1026, V k_1027, V _a1024, V _a1025, V[] _rest1021) => {
return Invoke(I_820, "brass", ((V)((260D + (ToNum(k_1027) * 0.12)))), m_1026, ((V)(0.6)), ((V)(0.035)));
}, 2, "", true));
Call(sing_825, V.Undef, ((V)(262D)), C_824, ((V)(2D)), ((V)(0.09)));
Call(sing_825, V.Undef, ((V)(262D)), C_824, ((V)(14D)), ((V)(0.03)), Get(I_820, "lead"));
Invoke(I_820, "crash", ((V)(262D)), ((V)(0.14)));
Call(sing_825, V.Undef, ((V)(270D)), C_824, ((V)(2D)), ((V)(0.09)));
Call(sing_825, V.Undef, ((V)(278D)), C_824, ((V)(2D)), ((V)(0.09)));
Call(sing_825, V.Undef, ((V)(278D)), C_824, ((V)(14D)), ((V)(0.04)), Get(I_820, "lead"));
Invoke(I_820, "crash", ((V)(278D)), ((V)(0.14)));
Invoke(I_820, "crash", ((V)(285D)), ((V)(0.2)));
Invoke(Arr(((V)(50D)), ((V)(54D)), ((V)(57D)), ((V)(62D)), ((V)(66D)), ((V)(69D))), "forEach", Fn((V _arrowThis1036, int _argc1029, V m_1035, V _a1032, V _a1033, V _a1034, V[] _rest1030) => {
return Invoke(I_820, "brass", ((V)(285D)), m_1035, ((V)(3D)), ((V)(0.03)));
}, 1, "", true));
Invoke(I_820, "timp", ((V)(285D)), ((V)(0.4)));
Invoke(I_820, "beat", ((V)(286D)), ((V)(292D)), ((V)(0.1)), Fn((V _arrowThis1045, int _argc1037, V t_1043, V i_1044, V _a1041, V _a1042, V[] _rest1038) => {
return Invoke(I_820, "clap", Add(t_1043, ((V)((ToNum(Invoke(G("Math"), "random")) * 0.05)))), ((V)((0.03 + (0.02 * FdLibm.Sin(ToNum(i_1044)))))));
}, 2, "", true));
Invoke(Arr(((V)(86D)), ((V)(81D)), ((V)(78D)), ((V)(74D))), "forEach", Fn((V _arrowThis1054, int _argc1046, V m_1052, V k_1053, V _a1050, V _a1051, V[] _rest1047) => {
return Invoke(I_820, "bell", ((V)((292D + (ToNum(k_1053) * 0.6)))), m_1052, ((V)(1.4)), ((V)(0.04)));
}, 2, "", true));
Invoke(I_820, "pad", ((V)(294D)), Arr(((V)(50D)), ((V)(57D)), ((V)(62D)), ((V)(66D))), ((V)(6D)), ((V)(0.02)), ((V)("triangle")), ((V)(1200D)));
return default;
}, 1, "score", false);
SM_8 = Get(G("window"), "SquadMovies");
K_9 = Get(G("window"), "MK");
if (((!(Truthy(SM_8)) || !(Truthy(K_9))) || !(Truthy(Get(SM_8, "def"))))) {
return default;
}
{ V _t1055 = K_9;
if (_t1055.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1055));
{ V _t1056 = Get(_t1055, "D");
D_10 = _t1056; }
{ V _t1057 = Get(_t1055, "P");
P_11 = _t1057; }
{ V _t1058 = Get(_t1055, "E");
E_12 = _t1058; }
{ V _t1059 = Get(_t1055, "kf");
kf_13 = _t1059; }
{ V _t1060 = Get(_t1055, "win");
win_14 = _t1060; }
{ V _t1061 = Get(_t1055, "put");
put_15 = _t1061; }
{ V _t1062 = Get(_t1055, "show");
show_16 = _t1062; }
{ V _t1063 = Get(_t1055, "actor");
actor_17 = _t1063; }
{ V _t1064 = Get(_t1055, "pose");
pose_18 = _t1064; }
{ V _t1065 = Get(_t1055, "go");
go_19 = _t1065; }
{ V _t1066 = Get(_t1055, "dance");
dance_20 = _t1066; }
{ V _t1067 = Get(_t1055, "bub");
bub_21 = _t1067; }
{ V _t1068 = Get(_t1055, "lines");
lines_22 = _t1068; }
{ V _t1069 = Get(_t1055, "parts");
parts_23 = _t1069; }
{ V _t1070 = Get(_t1055, "glow");
glow_24 = _t1070; }
{ V _t1071 = Get(_t1055, "film");
film_25 = _t1071; }
{ V _t1072 = Get(_t1055, "snd");
snd_26 = _t1072; }
{ V _t1073 = Get(_t1055, "rnd");
rnd_27 = _t1073; }
{ V _t1074 = Get(_t1055, "cl");
cl_28 = _t1074; }
{ V _t1075 = Get(_t1055, "lerp");
lerp_29 = _t1075; }
{ V _t1076 = Get(_t1055, "stars");
stars_30 = _t1076; }
{ V _t1077 = Get(_t1055, "el");
el_31 = _t1077; }
{ V _t1078 = Get(_t1055, "art");
art_32 = _t1078; }
{ V _t1079 = Get(_t1055, "SPIN");
SPIN_33 = _t1079; } }
B_34 = 0.5;
FY_35 = 158D;
W_36 = 56D;
CH_37 = ((V)("<svg viewBox=\"0 0 10 10\" width=\"8\" height=\"8\"><path d=\"M5 0 L6 4 L10 5 L6 6 L5 10 L4 6 L0 5 L4 4Z\" fill=\"currentColor\"></path></svg>"));
seg_38 = Fn((V _arrowThis1089, int _argc1080, V u_1086, V a_1087, V b_1088, V _a1085, V[] _rest1081) => {
return Call(cl_28, V.Undef, ((V)(((ToNum(u_1086) - ToNum(a_1087)) / (ToNum(b_1088) - ToNum(a_1087))))));
}, 3, "", true);
arc_39 = Fn((V _arrowThis1100, int _argc1090, V u_1096, V a_1097, V b_1098, V h_1099, V[] _rest1091) => {
return ((V)(((Gt(u_1096, a_1097) && Lt(u_1096, b_1098)) ? (FdLibm.Sin(((System.Math.PI * (ToNum(u_1096) - ToNum(a_1097))) / (ToNum(b_1098) - ToNum(a_1097)))) * ToNum(h_1099)) : 0D)));
}, 4, "", true);
land_40 = Fn((V _arrowThis1111, int _argc1101, V u_1107, V a_1108, V _a1105, V _a1106, V[] _rest1102) => {
V d_1110 = default;
{ V _t1109 = _a1105; if (_t1109.IsUndef) _t1109 = ((V)(8D));
d_1110 = _t1109; }
return ((V)((Ge(u_1107, a_1108) ? FdLibm.Exp(((-(ToNum(u_1107) - ToNum(a_1108))) * ToNum(d_1110))) : 0D)));
}, 3, "", true);
wrapR_41 = Fn((V _arrowThis1119, int _argc1112, V a_1118, V _a1115, V _a1116, V _a1117, V[] _rest1113) => {
return ((V)(((((ToNum(a_1118) % 360D) + 540D) % 360D) - 180D)));
}, 1, "", true);
tw_42 = Fn((V _arrowThis1128, int _argc1120, V u_1126, V r_1127, V _a1124, V _a1125, V[] _rest1121) => {
return GetIdx(SPIN_33, (System.Math.Floor((Max(0D, ToNum(u_1126)) * ToNum(r_1127))) % 4D));
}, 2, "", true);
bp_43 = Fn((V _arrowThis1136, int _argc1129, V u_1135, V _a1132, V _a1133, V _a1134, V[] _rest1130) => {
double bt_1137 = 0;
double n_1138 = 0;
double f_1139 = 0;
bt_1137 = (ToNum(u_1135) / B_34);
n_1138 = System.Math.Floor(bt_1137);
f_1139 = (bt_1137 - n_1138);
return NewObj(6).Put("bt", ((V)(bt_1137))).Put("n", ((V)(n_1138))).Put("f", ((V)(f_1139))).Put("hp", ((V)(FdLibm.Sin((System.Math.PI * f_1139))))).Put("sq", ((V)(FdLibm.Exp(((-f_1139) * 8D))))).Put("s2", ((V)((NumTruthy((n_1138 % 2D)) ? 1D : (-1D))))).V;
return default;
}, 1, "", true);
FLAME_44 = ((V)("width:9px;height:13px;border-radius:50% 50% 50% 50%/60% 60% 40% 40%;background:radial-gradient(circle at 50% 70%,#fff6c8 0 25%,#ffb84a 55%,#ff5a2a);"));
PUFF_45 = ((V)("width:10px;height:10px;border-radius:50%;background:radial-gradient(circle at 35% 35%,#fff 0 40%,#f1e2ec);"));
SMOKE_46 = ((V)("width:10px;height:10px;border-radius:50%;background:radial-gradient(circle,#d8d0e0 0 40%,rgba(216,208,224,0) 72%);"));
DROP_47 = Fn((V _arrowThis1147, int _argc1140, V c_1146, V _a1143, V _a1144, V _a1145, V[] _rest1141) => {
return ((V)(JsStrBuf.Begin().S("width:4px;height:5px;border-radius:50% 50% 50% 50%/60% 60% 40% 40%;background:").V(c_1146).S(";").End()));
}, 1, "", true);
BUB_48 = ((V)("width:7px;height:7px;border-radius:50%;border:1.5px solid rgba(255,255,255,0.85);box-sizing:border-box;background:rgba(200,240,255,0.15);"));
RING_49 = Fn((V _arrowThis1155, int _argc1148, V c_1154, V _a1151, V _a1152, V _a1153, V[] _rest1149) => {
return ((V)(JsStrBuf.Begin().S("width:40px;height:10px;border-radius:50%;border:2px solid ").V(c_1154).S(";box-sizing:border-box;").End()));
}, 1, "", true);
spray_51 = Fn((V _arrowThis1173, int _argc1156, V i_1162, V n_1163, V d_1164, V x_1165, V[] _rest1157) => {
double a_1174 = 0;
V y_1166 = default;
V dur_1168 = default;
V v_1170 = default;
V wd_1172 = default;
y_1166 = (_argc1156 > 4 ? _rest1157[0] : V.Undef);
{ V _t1167 = (_argc1156 > 5 ? _rest1157[1] : V.Undef); if (_t1167.IsUndef) _t1167 = ((V)(0.6));
dur_1168 = _t1167; }
{ V _t1169 = (_argc1156 > 6 ? _rest1157[2] : V.Undef); if (_t1169.IsUndef) _t1169 = ((V)(60D));
v_1170 = _t1169; }
{ V _t1171 = (_argc1156 > 7 ? _rest1157[3] : V.Undef); if (_t1171.IsUndef) _t1171 = ((V)(2.4));
wd_1172 = _t1171; }
if ((LtN(d_1164, 0D) || Gt(d_1164, dur_1168))) {
return V.Null;
}
a_1174 = (((-System.Math.PI) / 2D) + (((ToNum(i_1162) / Max(1D, (ToNum(n_1163) - 1D))) - 0.5) * ToNum(wd_1172)));
return NewObj(3).Put("x", Add(x_1165, ((V)(((FdLibm.Cos(a_1174) * ToNum(v_1170)) * ToNum(d_1164)))))).Put("y", Add(Add(y_1166, ((V)((((FdLibm.Sin(a_1174) * ToNum(v_1170)) * 1.1) * ToNum(d_1164))))), ((V)(((150D * ToNum(d_1164)) * ToNum(d_1164)))))).Put("o", ((V)((1D - (ToNum(d_1164) / ToNum(dur_1168)))))).V;
return default;
}, 8, "", true);
toastOf_54 = Fn((V _arrowThis1182, int _argc1175, V u_1181, V _a1178, V _a1179, V _a1180, V[] _rest1176) => {
return ((V)((LtN(u_1181, 3D) ? (ToNum(u_1181) / 3D) : (LtN(u_1181, 4D) ? (1D - ToNum(Call(seg_38, V.Undef, u_1181, ((V)(3.15)), ((V)(3.5))))) : (LtN(u_1181, 7D) ? ((ToNum(u_1181) - 4D) / 3D) : (1D - ToNum(Call(seg_38, V.Undef, u_1181, ((V)(7D)), ((V)(7.35))))))))));
}, 1, "", true);
tf_55 = Fn((V _arrowThis1190, int _argc1183, V a_1189, V _a1186, V _a1187, V _a1188, V[] _rest1184) => {
return ((V)((GtN(a_1189, 0.01) ? JsStrBuf.Begin().S("sepia(").V(Invoke(((V)((0.6 * ToNum(a_1189)))), "toFixed", ((V)(2D)))).S(") saturate(").V(Invoke(((V)((1D + (0.9 * ToNum(a_1189))))), "toFixed", ((V)(2D)))).S(") brightness(").V(Invoke(((V)((1D - (0.14 * ToNum(a_1189))))), "toFixed", ((V)(2D)))).S(")").End() : "")));
}, 1, "", true);
PL_56 = 48D;
SIG_57 = NewObj(12).Put("mallow", NewObj(2).Put("m", Fn((V _self1191, int _argc1192, V u_1198, V x_1199, V y_1200, V _a1197, V[] _rest1193) => {
V bt_1201 = default;
V hp_1202 = default;
V f_1203 = default;
V j_1204 = default;
V q_1205 = default;
if (_self1191.IsNullish) _self1191 = GlobalV;
{ V _t1206 = Call(bp_43, V.Undef, u_1198);
if (_t1206.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1206));
{ V _t1207 = Get(_t1206, "bt");
bt_1201 = _t1207; }
{ V _t1208 = Get(_t1206, "hp");
hp_1202 = _t1208; } }
f_1203 = Call(tf_55, V.Undef, Call(toastOf_54, V.Undef, u_1198));
if (LtN(u_1198, 3D)) {
return NewObj(5).Put("x", Add(x_1199, ((V)((FdLibm.Sin(((ToNum(u_1198) * System.Math.PI) / 1.5)) * 6D))))).Put("y", ((V)((ToNum(y_1200) - (ToNum(hp_1202) * 4D))))).Put("v", Call(tw_42, V.Undef, u_1198, ((V)(4D)))).Put("r", ((V)((FdLibm.Sin((ToNum(bt_1201) * System.Math.PI)) * 5D)))).Put("f", f_1203).V;
}
if (LtN(u_1198, 4D)) {
V j_1209 = default;
V q_1210 = default;
double a_1211 = 0;
j_1209 = Call(arc_39, V.Undef, u_1198, ((V)(3D)), ((V)(3.9)), ((V)(30D)));
q_1210 = Add(Call(land_40, V.Undef, u_1198, ((V)(3.9))), (LtN(u_1198, 3.08) ? Call(seg_38, V.Undef, u_1198, ((V)(3D)), ((V)(3.04))) : ((V)(0D))));
a_1211 = (GtN(j_1209, 2D) ? 1D : 0D);
return NewObj(7).Put("x", x_1199).Put("y", ((V)((ToNum(y_1200) - ToNum(j_1209))))).Put("gy", y_1200).Put("v", ((V)("front"))).Put("sx", ((V)(((1D + (0.12 * ToNum(q_1210))) - (0.05 * a_1211))))).Put("sy", ((V)(((1D - (0.14 * ToNum(q_1210))) + (0.07 * a_1211))))).Put("f", f_1203).V;
}
if (LtN(u_1198, 7D)) {
return NewObj(4).Put("x", Add(x_1199, ((V)((FdLibm.Sin((((ToNum(u_1198) - 4D) * System.Math.PI) / 1.5)) * 10D))))).Put("y", ((V)((ToNum(y_1200) - (System.Math.Abs(FdLibm.Sin((ToNum(bt_1201) * System.Math.PI))) * 5D))))).Put("v", Call(tw_42, V.Undef, u_1198, ((V)(8D)))).Put("f", f_1203).V;
}
j_1204 = Call(arc_39, V.Undef, u_1198, ((V)(7D)), ((V)(7.5)), ((V)(18D)));
q_1205 = Call(land_40, V.Undef, u_1198, ((V)(7.5)));
return NewObj(7).Put("x", x_1199).Put("y", ((V)((ToNum(y_1200) - ToNum(j_1204))))).Put("gy", y_1200).Put("v", ((V)("front"))).Put("sx", ((V)((1D + (0.12 * ToNum(q_1205)))))).Put("sy", ((V)((1D - (0.14 * ToNum(q_1205)))))).Put("f", f_1203).V;
return default;
}, 3, "m", false)).Put("fx", Fn((V _arrowThis1219, int _argc1212, V p_1218, V _a1215, V _a1216, V _a1217, V[] _rest1213) => {
return Call(FX_50, V.Undef, p_1218, Arr(Arr(((V)(3D)), FLAME_44, V.Null, Fn((V _arrowThis1229, int _argc1220, V i_1226, V u_1227, V s_1228, V _a1225, V[] _rest1221) => {
V a_1230 = default;
a_1230 = Call(toastOf_54, V.Undef, u_1227);
if (((LtN(a_1230, 0.05) || (GeN(u_1227, 3.1) && LtN(u_1227, 4D))) || GeN(u_1227, 7D))) {
return V.Null;
}
return NewObj(4).Put("x", Add(Get(s_1228, "x"), ((V)(((ToNum(i_1226) - 1D) * 11D))))).Put("y", ((V)(((ToNum(Get(s_1228, "y")) - 2D) - (System.Math.Abs(FdLibm.Sin(ToNum(Add(((V)((ToNum(u_1227) * 13D))), i_1226)))) * 2D))))).Put("k", ((V)(((0.6 + (0.5 * ToNum(a_1230))) * (0.85 + (0.15 * FdLibm.Sin(((ToNum(u_1227) * 20D) + (ToNum(i_1226) * 2D))))))))).Put("o", ((V)((0.9 * ToNum(a_1230))))).V;
return default;
}, 3, "", true)), Arr(((V)(8D)), PUFF_45, V.Null, Fn((V _arrowThis1240, int _argc1231, V i_1237, V u_1238, V s_1239, V _a1236, V[] _rest1232) => {
double d_1241 = 0;
double a_1242 = 0;
d_1241 = (ToNum(u_1238) - (LtN(u_1238, 5D) ? 3.15 : 7.05));
if (((d_1241 < 0D) || (d_1241 > 0.8))) {
return V.Null;
}
a_1242 = (((ToNum(i_1237) / 8D) * System.Math.PI) * 2D);
return NewObj(4).Put("x", Add(Get(s_1239, "x"), ((V)((FdLibm.Cos(a_1242) * (10D + (d_1241 * 40D))))))).Put("y", ((V)((((ToNum(Get(s_1239, "y")) - 28D) + (FdLibm.Sin(a_1242) * (8D + (d_1241 * 24D)))) - (d_1241 * 10D))))).Put("k", ((V)((0.6 + (d_1241 * 1.2))))).Put("o", ((V)((1D - (d_1241 / 0.8))))).V;
return default;
}, 3, "", true))));
}, 1, "fx", true)).V).Put("frybo", NewObj(2).Put("m", Fn((V _self1243, int _argc1244, V u_1250, V x_1251, V y_1252, V _a1249, V[] _rest1245) => {
V hp_1253 = default;
V sq_1254 = default;
V j_1255 = default;
V q_1256 = default;
if (_self1243.IsNullish) _self1243 = GlobalV;
{ V _t1257 = Call(bp_43, V.Undef, u_1250);
if (_t1257.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1257));
{ V _t1258 = Get(_t1257, "hp");
hp_1253 = _t1258; }
{ V _t1259 = Get(_t1257, "sq");
sq_1254 = _t1259; } }
if (LtN(u_1250, 4D)) {
double d_1260 = 0;
d_1260 = ((FdLibm.Cos(((ToNum(u_1250) * System.Math.PI) / 2D)) >= 0D) ? 1D : (-1D));
return NewObj(6).Put("x", Add(x_1251, ((V)((16D * FdLibm.Sin(((ToNum(u_1250) * System.Math.PI) / 2D))))))).Put("y", ((V)((ToNum(y_1252) - (ToNum(hp_1253) * 3D))))).Put("v", ((V)(((d_1260 > 0D) ? "right" : "left")))).Put("r", ((V)(((d_1260 * 5D) * ToNum(hp_1253))))).Put("sx", ((V)((1D + (0.05 * ToNum(sq_1254)))))).Put("sy", ((V)((1D - (0.05 * ToNum(sq_1254)))))).V;
}
if (LtN(u_1250, 6D)) {
return NewObj(4).Put("x", x_1251).Put("y", ((V)((ToNum(y_1252) - (System.Math.Abs(FdLibm.Sin((ToNum(u_1250) * 19D))) * 3D))))).Put("v", ((V)("front"))).Put("r", ((V)((FdLibm.Sin((ToNum(u_1250) * 38D)) * 6D)))).V;
}
if (LtN(u_1250, 7D)) {
double e_1261 = 0;
e_1261 = FdLibm.Sin((System.Math.PI * ToNum(Call(seg_38, V.Undef, u_1250, ((V)(6D)), ((V)(7D))))));
return NewObj(4).Put("x", ((V)((ToNum(x_1251) - (8D * e_1261))))).Put("y", Add(y_1252, ((V)((2D * e_1261))))).Put("v", ((V)("front"))).Put("r", ((V)(((-30D) * e_1261)))).V;
}
j_1255 = Call(arc_39, V.Undef, u_1250, ((V)(7D)), ((V)(7.8)), ((V)(30D)));
q_1256 = Call(land_40, V.Undef, u_1250, ((V)(7.8)));
return NewObj(7).Put("x", x_1251).Put("y", ((V)((ToNum(y_1252) - ToNum(j_1255))))).Put("gy", y_1252).Put("v", ((V)("front"))).Put("r", Call(wrapR_41, V.Undef, ((V)((360D * ToNum(Invoke(E_12, "io", Call(seg_38, V.Undef, u_1250, ((V)(7.02)), ((V)(7.78)))))))))).Put("sx", ((V)((1D + (0.12 * ToNum(q_1256)))))).Put("sy", ((V)((1D - (0.14 * ToNum(q_1256)))))).V;
return default;
}, 3, "m", false)).Put("fx", Fn((V _arrowThis1269, int _argc1262, V p_1268, V _a1265, V _a1266, V _a1267, V[] _rest1263) => {
return Call(FX_50, V.Undef, p_1268, Arr(Arr(((V)(1D)), ((V)("width:10px;height:16px;")), ((V)("<svg viewBox=\"0 0 10 16\" width=\"10\" height=\"16\"><rect x=\"1\" y=\"4\" width=\"8\" height=\"11.5\" rx=\"2\" fill=\"#f4f4f8\" stroke=\"#8a94a6\" stroke-width=\"0.8\"></rect><rect x=\"1.5\" y=\"0.8\" width=\"7\" height=\"4\" rx=\"1.5\" fill=\"#b8c0cc\"></rect><circle cx=\"3.6\" cy=\"2.4\" r=\"0.6\" fill=\"#556\"></circle><circle cx=\"6.4\" cy=\"2.4\" r=\"0.6\" fill=\"#556\"></circle></svg>")), Fn((V _arrowThis1279, int _argc1270, V i_1276, V u_1277, V s_1278, V _a1275, V[] _rest1271) => {
return ((LtN(u_1277, 3.8) || GtN(u_1277, 6.1)) ? V.Null : NewObj(4).Put("x", Add(Get(s_1278, "x"), ((V)(14D)))).Put("y", ((V)(((ToNum(Get(s_1278, "y")) - 70D) + (FdLibm.Sin((ToNum(u_1277) * 38D)) * 3D))))).Put("r", ((V)((180D + (FdLibm.Sin((ToNum(u_1277) * 38D)) * 25D))))).Put("k", ((V)((1.3 * Min(1D, ((ToNum(u_1277) - 3.8) / 0.2), ((6.1 - ToNum(u_1277)) / 0.2)))))).V);
}, 3, "", true)), Arr(((V)(12D)), ((V)("width:2px;height:2px;border-radius:1px;background:#fff;")), V.Null, Fn((V _arrowThis1289, int _argc1280, V i_1286, V u_1287, V s_1288, V _a1285, V[] _rest1281) => {
double a_1290 = 0;
if ((LtN(u_1287, 4D) || GtN(u_1287, 6D))) {
return V.Null;
}
a_1290 = ((((ToNum(u_1287) - 4D) * 2.2) + (ToNum(i_1286) / 12D)) % 1D);
return NewObj(3).Put("x", Add(Add(Get(s_1288, "x"), ((V)(13D))), ((V)((FdLibm.Sin((ToNum(i_1286) * 2.7)) * 7D))))).Put("y", ((V)(((ToNum(Get(s_1288, "y")) - 60D) + (a_1290 * 28D))))).Put("o", ((V)((1D - (a_1290 * 0.5))))).V;
return default;
}, 3, "", true)), Arr(((V)(1D)), ((V)("width:15px;height:10px;border-radius:2px 2px 6px 6px;background:linear-gradient(#e23030 0 40%,#fff 40% 55%,#f4f4f4 55%);box-shadow:0 1px 2px rgba(0,0,0,0.3);")), V.Null, Fn((V _arrowThis1300, int _argc1291, V i_1297, V u_1298, V s_1299, V _a1296, V[] _rest1292) => {
return ((LtN(u_1298, 5.7) || GtN(u_1298, 7.2)) ? V.Null : NewObj(3).Put("x", ((V)((ToNum(Get(s_1299, "x")) - 22D)))).Put("y", ((V)((ToNum(Get(s_1299, "y")) - 5D)))).Put("k", ((V)(Min(1D, ((ToNum(u_1298) - 5.7) / 0.2), ((7.2 - ToNum(u_1298)) / 0.2))))).V);
}, 3, "", true))));
}, 1, "fx", true)).V).Put("bunbun", NewObj(3).Put("sl", Arr(((V)(0D)), ((V)(0.505)), ((V)(0.685)), ((V)(1D)))).Put("m", Fn((V _self1301, int _argc1302, V u_1308, V x_1309, V y_1310, V _a1307, V[] _rest1303) => {
V bt_1311 = default;
V hp_1312 = default;
V sq_1313 = default;
V q_1314 = default;
if (_self1301.IsNullish) _self1301 = GlobalV;
{ V _t1315 = Call(bp_43, V.Undef, u_1308);
if (_t1315.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1315));
{ V _t1316 = Get(_t1315, "bt");
bt_1311 = _t1316; }
{ V _t1317 = Get(_t1315, "hp");
hp_1312 = _t1317; }
{ V _t1318 = Get(_t1315, "sq");
sq_1313 = _t1318; } }
if (LtN(u_1308, 2D)) {
return NewObj(6).Put("x", x_1309).Put("y", ((V)((ToNum(y_1310) - (ToNum(hp_1312) * 6D))))).Put("v", ((V)("front"))).Put("sx", ((V)((1D + (0.06 * ToNum(sq_1313)))))).Put("sy", ((V)((1D - (0.07 * ToNum(sq_1313)))))).Put("sl", Arr(Arr(((V)(0D)), ((V)(((-ToNum(hp_1312)) * 2.5)))), Arr(((V)(0D)), ((V)((-ToNum(hp_1312))))), Arr(((V)(0D)), ((V)(0D))))).V;
}
if (LtN(u_1308, 4D)) {
double k2_1319 = 0;
double sp_1320 = 0;
double q_1321 = 0;
k2_1319 = ((ToNum(u_1308) - 2D) % 1D);
sp_1320 = FdLibm.Sin((System.Math.PI * k2_1319));
q_1321 = FdLibm.Exp(((-k2_1319) * 9D));
return NewObj(8).Put("x", x_1309).Put("y", ((V)((ToNum(y_1310) - (sp_1320 * 24D))))).Put("gy", y_1310).Put("v", ((V)("front"))).Put("r", ((V)((((NumTruthy((System.Math.Floor((ToNum(u_1308) - 2D)) % 2D)) ? 1D : (-1D)) * 8D) * sp_1320)))).Put("sx", ((V)((1D + (0.12 * q_1321))))).Put("sy", ((V)((1D - (0.14 * q_1321))))).Put("sl", Arr(Arr(((V)(0D)), ((V)(((-sp_1320) * 13D)))), Arr(((V)(0D)), ((V)(((-sp_1320) * 5.5)))), Arr(((V)(0D)), ((V)(0D))))).V;
}
if (LtN(u_1308, 6D)) {
double w_1322 = 0;
w_1322 = FdLibm.Sin((ToNum(bt_1311) * System.Math.PI));
return NewObj(4).Put("x", Add(x_1309, ((V)((w_1322 * 3D))))).Put("y", ((V)((ToNum(y_1310) - (ToNum(hp_1312) * 3D))))).Put("v", ((V)("front"))).Put("sl", Arr(Arr(((V)((w_1322 * 9D))), ((V)(((-1.5) * ToNum(hp_1312))))), Arr(((V)(((-w_1322) * 9D))), ((V)(0D))), Arr(((V)((w_1322 * 4D))), ((V)(0D))))).V;
}
if (LtN(u_1308, 7.2)) {
double sp_1323 = 0;
sp_1323 = FdLibm.Sin((System.Math.PI * ToNum(Call(seg_38, V.Undef, u_1308, ((V)(6D)), ((V)(7.2))))));
return NewObj(5).Put("x", x_1309).Put("y", ((V)((ToNum(y_1310) - (sp_1323 * 34D))))).Put("gy", y_1310).Put("v", Call(tw_42, V.Undef, ((V)((ToNum(u_1308) - 6D))), ((V)(8D)))).Put("sl", Arr(Arr(((V)(0D)), ((V)(((-sp_1323) * 16D)))), Arr(((V)(0D)), ((V)(((-sp_1323) * 7D)))), Arr(((V)(0D)), ((V)(0D))))).V;
}
q_1314 = Call(land_40, V.Undef, u_1308, ((V)(7.2)), ((V)(5D)));
return NewObj(6).Put("x", x_1309).Put("y", y_1310).Put("v", ((V)("front"))).Put("sx", ((V)((1D + (0.22 * ToNum(q_1314)))))).Put("sy", ((V)((1D - (0.26 * ToNum(q_1314)))))).Put("sl", Arr(Arr(((V)(0D)), ((V)((2D * ToNum(q_1314))))), Arr(((V)(0D)), q_1314), Arr(((V)(0D)), ((V)(0D))))).V;
return default;
}, 3, "m", false)).Put("fx", Fn((V _arrowThis1331, int _argc1324, V p_1330, V _a1327, V _a1328, V _a1329, V[] _rest1325) => {
return Call(FX_50, V.Undef, p_1330, Arr(Arr(((V)(1D)), Call(RING_49, V.Undef, ((V)("rgba(255,240,200,0.9)"))), V.Null, Fn((V _arrowThis1341, int _argc1332, V i_1338, V u_1339, V s_1340, V _a1337, V[] _rest1333) => {
double d_1342 = 0;
d_1342 = (ToNum(u_1339) - 7.2);
return (((d_1342 < 0D) || (d_1342 > 0.6)) ? V.Null : NewObj(4).Put("x", Get(s_1340, "x")).Put("y", Get(s_1340, "y")).Put("k", ((V)((1D + (d_1342 * 3D))))).Put("o", ((V)((1D - (d_1342 / 0.6))))).V);
return default;
}, 3, "", true)), Arr(((V)(6D)), ((V)("width:4px;height:3px;border-radius:50%;background:#fff3c4;")), V.Null, Fn((V _arrowThis1352, int _argc1343, V i_1349, V u_1350, V s_1351, V _a1348, V[] _rest1344) => {
return Call(spray_51, V.Undef, i_1349, ((V)(6D)), ((V)((ToNum(u_1350) - 7.2))), Get(s_1351, "x"), ((V)((ToNum(Get(s_1351, "y")) - 4D))), ((V)(0.55)), ((V)(70D)), ((V)(2.8)));
}, 3, "", true))));
}, 1, "fx", true)).V).Put("finn", NewObj(2).Put("m", Fn((V _self1353, int _argc1354, V u_1360, V x_1361, V y_1362, V _a1359, V[] _rest1355) => {
V bt_1363 = default;
double e_1364 = 0;
if (_self1353.IsNullish) _self1353 = GlobalV;
{ V _t1365 = Call(bp_43, V.Undef, u_1360);
if (_t1365.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1365));
{ V _t1366 = Get(_t1365, "bt");
bt_1363 = _t1366; } }
if (LtN(u_1360, 3D)) {
double ph_1367 = 0;
ph_1367 = (((ToNum(u_1360) * System.Math.PI) * 2D) / 3D);
return NewObj(4).Put("x", Add(x_1361, ((V)((FdLibm.Sin(ph_1367) * 14D))))).Put("y", ((V)((ToNum(y_1362) - (System.Math.Abs(FdLibm.Sin((ToNum(bt_1363) * System.Math.PI))) * 6D))))).Put("v", ((V)(((FdLibm.Cos(ph_1367) >= 0D) ? "right" : "left")))).Put("r", ((V)((FdLibm.Sin((ToNum(bt_1363) * System.Math.PI)) * 10D)))).V;
}
if (LtN(u_1360, 5D)) {
double j_1368 = 0;
V q_1369 = default;
j_1368 = (FdLibm.Sin((System.Math.PI * ToNum(Call(seg_38, V.Undef, u_1360, ((V)(3D)), ((V)(5D)))))) * 56D);
q_1369 = (LtN(u_1360, 3.08) ? Call(seg_38, V.Undef, u_1360, ((V)(3D)), ((V)(3.04))) : ((V)(0D)));
return NewObj(7).Put("x", x_1361).Put("y", ((V)((ToNum(y_1362) - j_1368)))).Put("gy", y_1362).Put("v", ((V)("right"))).Put("r", Call(wrapR_41, V.Undef, ((V)(((-360D) * ToNum(Invoke(E_12, "io", Call(seg_38, V.Undef, u_1360, ((V)(3.15)), ((V)(4.85)))))))))).Put("sx", ((V)((1D + (0.12 * ToNum(q_1369)))))).Put("sy", ((V)((1D - (0.14 * ToNum(q_1369)))))).V;
}
if (LtN(u_1360, 7D)) {
double e_1370 = 0;
V q_1371 = default;
e_1370 = FdLibm.Sin((System.Math.PI * ToNum(Call(seg_38, V.Undef, u_1360, ((V)(5D)), ((V)(7D))))));
q_1371 = Call(land_40, V.Undef, u_1360, ((V)(5D)));
return NewObj(7).Put("x", Add(x_1361, ((V)((18D * e_1370))))).Put("y", ((V)(((ToNum(y_1362) - (8D * e_1370)) - ((System.Math.Abs(FdLibm.Sin((ToNum(u_1360) * 16D))) * 3D) * e_1370))))).Put("gy", y_1362).Put("v", ((V)("left"))).Put("r", ((V)(((6D * FdLibm.Sin((ToNum(u_1360) * 16D))) * e_1370)))).Put("sx", ((V)((1D + (0.12 * ToNum(q_1371)))))).Put("sy", ((V)((1D - (0.14 * ToNum(q_1371)))))).V;
}
e_1364 = FdLibm.Sin((System.Math.PI * ToNum(Call(seg_38, V.Undef, u_1360, ((V)(7D)), ((V)(7.9))))));
return NewObj(5).Put("x", x_1361).Put("y", y_1362).Put("v", ((V)("front"))).Put("r", ((V)((20D * e_1364)))).Put("sy", ((V)((1D - (0.05 * e_1364))))).V;
return default;
}, 3, "m", false)).Put("fx", Fn((V _arrowThis1379, int _argc1372, V p_1378, V _a1375, V _a1376, V _a1377, V[] _rest1373) => {
return Call(FX_50, V.Undef, p_1378, Arr(Arr(((V)(9D)), Call(DROP_47, V.Undef, ((V)("#bff4ff"))), V.Null, Fn((V _arrowThis1389, int _argc1380, V i_1386, V u_1387, V s_1388, V _a1385, V[] _rest1381) => {
return Call(spray_51, V.Undef, i_1386, ((V)(9D)), ((V)((ToNum(u_1387) - (LtN(u_1387, 4.5) ? 3D : 5D)))), Get(s_1388, "x"), ((V)((ToNum((Get(s_1388, "gy") is var _t1390 && !_t1390.IsNullish ? _t1390 : Get(s_1388, "y"))) - 2D))), ((V)(0.7)), ((V)(64D)));
}, 3, "", true)), Arr(((V)(1D)), Call(RING_49, V.Undef, ((V)("rgba(220,250,255,0.9)"))), V.Null, Fn((V _arrowThis1400, int _argc1391, V i_1397, V u_1398, V s_1399, V _a1396, V[] _rest1392) => {
double d_1401 = 0;
d_1401 = (ToNum(u_1398) - (LtN(u_1398, 4.5) ? 3D : 5D));
return (((d_1401 < 0D) || (d_1401 > 0.6)) ? V.Null : NewObj(4).Put("x", Get(s_1399, "x")).Put("y", (Get(s_1399, "gy") is var _t1402 && !_t1402.IsNullish ? _t1402 : Get(s_1399, "y"))).Put("k", ((V)((1D + (d_1401 * 2.5))))).Put("o", ((V)((1D - (d_1401 / 0.6))))).V);
return default;
}, 3, "", true))));
}, 1, "fx", true)).V).Put("octo", NewObj(2).Put("m", Fn((V _self1403, int _argc1404, V u_1410, V x_1411, V y_1412, V _a1409, V[] _rest1405) => {
V hp_1413 = default;
double e_1414 = 0;
if (_self1403.IsNullish) _self1403 = GlobalV;
{ V _t1415 = Call(bp_43, V.Undef, u_1410);
if (_t1415.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1415));
{ V _t1416 = Get(_t1415, "hp");
hp_1413 = _t1416; } }
if (LtN(u_1410, 3D)) {
double w_1417 = 0;
double z_1418 = 0;
w_1417 = FdLibm.Sin((ToNum(u_1410) * System.Math.PI));
z_1418 = FdLibm.Sin(((ToNum(u_1410) * 2D) * System.Math.PI));
return NewObj(6).Put("x", Add(x_1411, ((V)((w_1417 * 8D))))).Put("y", ((V)((ToNum(y_1412) - (ToNum(hp_1413) * 2D))))).Put("v", ((V)("front"))).Put("r", ((V)((w_1417 * 16D)))).Put("sx", ((V)((1D + (0.06 * z_1418))))).Put("sy", ((V)((1D - (0.06 * z_1418))))).V;
}
if (LtN(u_1410, 3.5)) {
V e_1419 = default;
e_1419 = Call(seg_38, V.Undef, u_1410, ((V)(3D)), ((V)(3.5)));
return NewObj(5).Put("x", x_1411).Put("y", y_1412).Put("v", ((V)("front"))).Put("sx", ((V)((1D + (0.16 * ToNum(e_1419)))))).Put("sy", ((V)((1D - (0.22 * ToNum(e_1419)))))).V;
}
if (LtN(u_1410, 4.2)) {
V e_1420 = default;
e_1420 = Invoke(E_12, "out", Call(seg_38, V.Undef, u_1410, ((V)(3.5)), ((V)(4.2))));
return NewObj(6).Put("x", x_1411).Put("y", ((V)((ToNum(y_1412) - (70D * ToNum(e_1420)))))).Put("gy", y_1412).Put("v", ((V)("front"))).Put("sx", ((V)(0.9))).Put("sy", ((V)((1.18 - (0.18 * ToNum(e_1420)))))).V;
}
if (LtN(u_1410, 6.2)) {
V e_1421 = default;
e_1421 = Invoke(E_12, "io", Call(seg_38, V.Undef, u_1410, ((V)(4.2)), ((V)(6.2))));
return NewObj(7).Put("x", Add(x_1411, ((V)((FdLibm.Sin((ToNum(u_1410) * 3D)) * 6D))))).Put("y", ((V)((ToNum(y_1412) - (70D * (1D - ToNum(e_1421))))))).Put("gy", y_1412).Put("v", ((V)("front"))).Put("r", ((V)((FdLibm.Sin((ToNum(u_1410) * 3D)) * 8D)))).Put("sx", ((V)((1.14 - (0.14 * ToNum(e_1421)))))).Put("sy", ((V)((0.9 + (0.1 * ToNum(e_1421)))))).V;
}
if (LtN(u_1410, 7D)) {
V e_1422 = default;
e_1422 = Call(seg_38, V.Undef, u_1410, ((V)(6.2)), ((V)(6.5)));
return NewObj(4).Put("x", ((V)((ToNum(x_1411) - (10D * ToNum(e_1422)))))).Put("y", y_1412).Put("v", ((V)("left"))).Put("r", ((V)(((-18D) * ToNum(e_1422))))).V;
}
e_1414 = (ToNum(Call(seg_38, V.Undef, u_1410, ((V)(7D)), ((V)(7.3)))) * (1D - ToNum(Call(seg_38, V.Undef, u_1410, ((V)(7.7)), ((V)(8D))))));
return NewObj(4).Put("x", ((V)((((ToNum(x_1411) - 10D) + (20D * ToNum(Call(seg_38, V.Undef, u_1410, ((V)(7D)), ((V)(7.3)))))) - (10D * ToNum(Call(seg_38, V.Undef, u_1410, ((V)(7.7)), ((V)(8D))))))))).Put("y", y_1412).Put("v", ((V)((LtN(u_1410, 7.7) ? "right" : "front")))).Put("r", ((V)((18D * e_1414)))).V;
return default;
}, 3, "m", false)).Put("fx", Fn((V _arrowThis1430, int _argc1423, V p_1429, V _a1426, V _a1427, V _a1428, V[] _rest1424) => {
return Call(FX_50, V.Undef, p_1429, Arr(Arr(((V)(7D)), ((V)("width:14px;height:14px;border-radius:50%;background:radial-gradient(circle,#3a2050 0 45%,rgba(58,32,80,0) 70%);")), V.Null, Fn((V _arrowThis1440, int _argc1431, V i_1437, V u_1438, V s_1439, V _a1436, V[] _rest1432) => {
double d_1441 = 0;
double a_1442 = 0;
d_1441 = (ToNum(u_1438) - 3.5);
if (((d_1441 < 0D) || (d_1441 > 1.2))) {
return V.Null;
}
a_1442 = (((ToNum(i_1437) / 7D) * System.Math.PI) * 2D);
return NewObj(4).Put("x", Add(Get(s_1439, "x"), ((V)((FdLibm.Cos(a_1442) * (6D + (d_1441 * 22D))))))).Put("y", ((V)((((ToNum((Get(s_1439, "gy") is var _t1443 && !_t1443.IsNullish ? _t1443 : Get(s_1439, "y"))) - 10D) + (FdLibm.Sin(a_1442) * (4D + (d_1441 * 12D)))) + (d_1441 * 6D))))).Put("k", ((V)((0.8 + (d_1441 * 1.6))))).Put("o", ((V)(((1D - (d_1441 / 1.2)) * 0.85)))).V;
return default;
}, 3, "", true))));
}, 1, "fx", true)).V).Put("marina", NewObj(2).Put("m", Fn((V _self1444, int _argc1445, V u_1451, V x_1452, V y_1453, V _a1450, V[] _rest1446) => {
V bt_1454 = default;
V f_1455 = default;
if (_self1444.IsNullish) _self1444 = GlobalV;
{ V _t1456 = Call(bp_43, V.Undef, u_1451);
if (_t1456.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1456));
{ V _t1457 = Get(_t1456, "bt");
bt_1454 = _t1457; }
{ V _t1458 = Get(_t1456, "f");
f_1455 = _t1458; } }
if (LtN(u_1451, 3D)) {
double ph_1459 = 0;
ph_1459 = (((ToNum(u_1451) * System.Math.PI) * 2D) / 3D);
return NewObj(4).Put("x", Add(x_1452, ((V)((FdLibm.Sin(ph_1459) * 12D))))).Put("y", ((V)((ToNum(y_1453) - (System.Math.Abs(FdLibm.Sin((ToNum(bt_1454) * System.Math.PI))) * 5D))))).Put("v", ((V)("front"))).Put("r", ((V)(((-FdLibm.Sin(ph_1459)) * 10D)))).V;
}
if (LtN(u_1451, 5.5)) {
double e_1460 = 0;
e_1460 = FdLibm.Sin((System.Math.PI * ToNum(Call(seg_38, V.Undef, u_1451, ((V)(3D)), ((V)(5.5))))));
return NewObj(4).Put("x", x_1452).Put("y", ((V)((ToNum(y_1453) - (16D * e_1460))))).Put("gy", y_1453).Put("v", Call(tw_42, V.Undef, ((V)((ToNum(u_1451) - 3D))), ((V)(6D)))).V;
}
if (LtN(u_1451, 7D)) {
double s_1461 = 0;
s_1461 = (NumTruthy((System.Math.Floor(ToNum(bt_1454)) % 2D)) ? 1D : (-1D));
return NewObj(5).Put("x", x_1452).Put("y", ((V)((ToNum(y_1453) - (FdLibm.Sin((System.Math.PI * ToNum(f_1455))) * 8D))))).Put("gy", y_1453).Put("v", ((V)("front"))).Put("r", ((V)(((s_1461 * 14D) * FdLibm.Sin((System.Math.PI * ToNum(f_1455))))))).V;
}
return NewObj(4).Put("x", x_1452).Put("y", ((V)((ToNum(y_1453) - (System.Math.Abs(FdLibm.Sin((ToNum(u_1451) * 4D))) * 2D))))).Put("v", ((V)("front"))).Put("r", ((V)((4D * FdLibm.Sin((ToNum(u_1451) * 3D)))))).V;
return default;
}, 3, "m", false)).Put("fx", Fn((V _arrowThis1469, int _argc1462, V p_1468, V _a1465, V _a1466, V _a1467, V[] _rest1463) => {
return Call(FX_50, V.Undef, p_1468, Arr(Arr(((V)(8D)), BUB_48, V.Null, Fn((V _arrowThis1479, int _argc1470, V i_1476, V u_1477, V s_1478, V _a1475, V[] _rest1471) => {
double a_1480 = 0;
V fr_1481 = default;
if ((LtN(u_1477, 3D) || GtN(u_1477, 5.5))) {
return V.Null;
}
a_1480 = ((ToNum(u_1477) * 5D) + (((ToNum(i_1476) / 8D) * System.Math.PI) * 2D));
fr_1481 = ((FdLibm.Sin(a_1480) > 0D) ? V.True : V.False);
return NewObj(4).Put("x", Add(Get(s_1478, "x"), ((V)((FdLibm.Cos(a_1480) * 30D))))).Put("y", ((V)((((ToNum(Get(s_1478, "y")) - 22D) + (FdLibm.Sin(a_1480) * 8D)) - ((ToNum(u_1477) - 3D) * 4D))))).Put("k", ((V)(0.9))).Put("o", ((V)(((Truthy(fr_1481) ? 0.95 : 0.4) * Min(1D, ((ToNum(u_1477) - 3D) / 0.3), ((5.5 - ToNum(u_1477)) / 0.3)))))).V;
return default;
}, 3, "", true)), Arr(((V)(6D)), BUB_48, V.Null, Fn((V _arrowThis1491, int _argc1482, V i_1488, V u_1489, V s_1490, V _a1487, V[] _rest1483) => {
double a_1492 = 0;
if (LtN(u_1489, 7D)) {
return V.Null;
}
a_1492 = ((((ToNum(u_1489) - 7D) * 1.3) + (ToNum(i_1488) / 6D)) % 1D);
return NewObj(4).Put("x", Add(Add(Get(s_1490, "x"), ((V)(4D))), ((V)((FdLibm.Sin(((ToNum(i_1488) * 2D) + (ToNum(u_1489) * 4D))) * 4D))))).Put("y", ((V)(((ToNum(Get(s_1490, "y")) - 34D) - (a_1492 * 50D))))).Put("k", ((V)((0.6 + (a_1492 * 0.8))))).Put("o", ((V)(((1D - a_1492) * Min(1D, ((ToNum(u_1489) - 7D) / 0.2)))))).V;
return default;
}, 3, "", true)), Arr(((V)(4D)), Call(DROP_47, V.Undef, ((V)("#bff4ff"))), V.Null, Fn((V _arrowThis1502, int _argc1493, V i_1499, V u_1500, V s_1501, V _a1498, V[] _rest1494) => {
double d_1503 = 0;
double sd_1504 = 0;
if ((LtN(u_1500, 5.5) || GeN(u_1500, 7D))) {
return V.Null;
}
d_1503 = ((ToNum(u_1500) - 5.5) % B_34);
sd_1504 = (NumTruthy((System.Math.Floor(((ToNum(u_1500) - 5.5) / B_34)) % 2D)) ? 1D : (-1D));
return Call(spray_51, V.Undef, i_1499, ((V)(4D)), ((V)(d_1503)), Add(Get(s_1501, "x"), ((V)((sd_1504 * 16D)))), ((V)((ToNum(Get(s_1501, "y")) - 6D))), ((V)(0.45)), ((V)(50D)), ((V)(1.6)));
return default;
}, 3, "", true))));
}, 1, "fx", true)).V).Put("pina", NewObj(2).Put("m", Fn((V _self1505, int _argc1506, V u_1512, V x_1513, V y_1514, V _a1511, V[] _rest1507) => {
V bt_1515 = default;
V hp_1516 = default;
V sq_1517 = default;
V j_1518 = default;
V q_1519 = default;
if (_self1505.IsNullish) _self1505 = GlobalV;
{ V _t1520 = Call(bp_43, V.Undef, u_1512);
if (_t1520.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1520));
{ V _t1521 = Get(_t1520, "bt");
bt_1515 = _t1521; }
{ V _t1522 = Get(_t1520, "hp");
hp_1516 = _t1522; }
{ V _t1523 = Get(_t1520, "sq");
sq_1517 = _t1523; } }
if (LtN(u_1512, 4D)) {
double w_1524 = 0;
double z_1525 = 0;
w_1524 = FdLibm.Sin((ToNum(u_1512) * System.Math.PI));
z_1525 = FdLibm.Sin(((ToNum(u_1512) * 2D) * System.Math.PI));
return NewObj(6).Put("x", Add(x_1513, ((V)((w_1524 * 9D))))).Put("y", ((V)((ToNum(y_1514) - (System.Math.Abs(FdLibm.Sin((ToNum(bt_1515) * System.Math.PI))) * 2D))))).Put("v", ((V)("front"))).Put("r", ((V)(((-w_1524) * 11D)))).Put("sx", ((V)((1D + (0.04 * z_1525))))).Put("sy", ((V)((1D - (0.03 * z_1525))))).V;
}
if (LtN(u_1512, 5D)) {
return NewObj(4).Put("x", x_1513).Put("y", ((V)((ToNum(y_1514) - (System.Math.Abs(FdLibm.Sin((ToNum(u_1512) * 20D))) * 3D))))).Put("v", ((V)("front"))).Put("r", ((V)((FdLibm.Sin((ToNum(u_1512) * 40D)) * 7D)))).V;
}
if (LtN(u_1512, 7D)) {
return NewObj(5).Put("x", x_1513).Put("y", ((V)((ToNum(y_1514) - (ToNum(hp_1516) * 6D))))).Put("v", ((V)("front"))).Put("sx", ((V)((1D + (0.1 * ToNum(sq_1517)))))).Put("sy", ((V)((1D - (0.12 * ToNum(sq_1517)))))).V;
}
j_1518 = Call(arc_39, V.Undef, u_1512, ((V)(7D)), ((V)(7.8)), ((V)(30D)));
q_1519 = Call(land_40, V.Undef, u_1512, ((V)(7.8)));
return NewObj(7).Put("x", x_1513).Put("y", ((V)((ToNum(y_1514) - ToNum(j_1518))))).Put("gy", y_1514).Put("v", ((V)("front"))).Put("r", Call(wrapR_41, V.Undef, ((V)((360D * ToNum(Invoke(E_12, "io", Call(seg_38, V.Undef, u_1512, ((V)(7.02)), ((V)(7.78)))))))))).Put("sx", ((V)((1D + (0.12 * ToNum(q_1519)))))).Put("sy", ((V)((1D - (0.14 * ToNum(q_1519)))))).V;
return default;
}, 3, "m", false)).Put("fx", Fn((V _arrowThis1533, int _argc1526, V p_1532, V _a1529, V _a1530, V _a1531, V[] _rest1527) => {
return Call(FX_50, V.Undef, p_1532, Arr(Arr(((V)(8D)), ((V)("width:6px;height:10px;border-radius:50% 0;background:#4ab04a;")), V.Null, Fn((V _arrowThis1543, int _argc1534, V i_1540, V u_1541, V s_1542, V _a1539, V[] _rest1535) => {
double d_1544 = 0;
double a_1545 = 0;
d_1544 = (ToNum(u_1541) - 4D);
if (((d_1544 < 0D) || (d_1544 > 1.4))) {
return V.Null;
}
a_1545 = (((-System.Math.PI) / 2D) + (((ToNum(i_1540) / 7D) - 0.5) * 2.6));
return NewObj(4).Put("x", Add(Get(s_1542, "x"), ((V)(((FdLibm.Cos(a_1545) * 50D) * d_1544))))).Put("y", ((V)((((ToNum(Get(s_1542, "y")) - (54D * ToNum((Get(s_1542, "k") is var _t1546 && Truthy(_t1546) ? _t1546 : ((V)(1D)))))) + ((FdLibm.Sin(a_1545) * 55D) * d_1544)) + ((70D * d_1544) * d_1544))))).Put("r", ((V)(((d_1544 * 400D) + (ToNum(i_1540) * 40D))))).Put("o", ((V)((1D - (d_1544 / 1.4))))).V;
return default;
}, 3, "", true))));
}, 1, "fx", true)).V).Put("berri", NewObj(2).Put("m", Fn((V _self1547, int _argc1548, V u_1554, V x_1555, V y_1556, V _a1553, V[] _rest1549) => {
V hp_1557 = default;
V sq_1558 = default;
V s2_1559 = default;
if (_self1547.IsNullish) _self1547 = GlobalV;
{ V _t1560 = Call(bp_43, V.Undef, u_1554);
if (_t1560.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1560));
{ V _t1561 = Get(_t1560, "hp");
hp_1557 = _t1561; }
{ V _t1562 = Get(_t1560, "sq");
sq_1558 = _t1562; }
{ V _t1563 = Get(_t1560, "s2");
s2_1559 = _t1563; } }
if (LtN(u_1554, 3D)) {
return NewObj(7).Put("x", x_1555).Put("y", ((V)((ToNum(y_1556) - (ToNum(hp_1557) * 12D))))).Put("gy", y_1556).Put("v", ((V)("front"))).Put("r", ((V)(((ToNum(s2_1559) * 4D) * ToNum(hp_1557))))).Put("sx", ((V)((1D + (0.15 * ToNum(sq_1558)))))).Put("sy", ((V)((1D - (0.16 * ToNum(sq_1558)))))).V;
}
if (LtN(u_1554, 5D)) {
return NewObj(4).Put("x", x_1555).Put("y", ((V)((ToNum(y_1556) - (6D * FdLibm.Sin((System.Math.PI * ToNum(Call(seg_38, V.Undef, u_1554, ((V)(3D)), ((V)(5D))))))))))).Put("gy", y_1556).Put("v", Call(tw_42, V.Undef, ((V)((ToNum(u_1554) - 3D))), ((V)(8D)))).V;
}
if (LtN(u_1554, 5.6)) {
V e_1564 = default;
e_1564 = Invoke(E_12, "out", Call(seg_38, V.Undef, u_1554, ((V)(5D)), ((V)(5.6))));
return NewObj(5).Put("x", x_1555).Put("y", y_1556).Put("v", ((V)("front"))).Put("sx", ((V)((1D + (0.2 * ToNum(e_1564)))))).Put("sy", ((V)((1D - (0.3 * ToNum(e_1564)))))).V;
}
if (LtN(u_1554, 6.4)) {
return NewObj(6).Put("x", x_1555).Put("y", ((V)((ToNum(y_1556) - ToNum(Call(arc_39, V.Undef, u_1554, ((V)(5.6)), ((V)(6.4)), ((V)(34D)))))))).Put("gy", y_1556).Put("v", ((V)("front"))).Put("sx", ((V)(0.94))).Put("sy", ((V)(1.08))).V;
}
if (LtN(u_1554, 7.2)) {
double e_1565 = 0;
V q_1566 = default;
e_1565 = FdLibm.Sin((System.Math.PI * ToNum(Call(seg_38, V.Undef, u_1554, ((V)(6.4)), ((V)(7.2))))));
q_1566 = Call(land_40, V.Undef, u_1554, ((V)(6.4)));
return NewObj(6).Put("x", x_1555).Put("y", y_1556).Put("v", ((V)("front"))).Put("r", ((V)(((-8D) * e_1565)))).Put("sx", ((V)((1D + (0.15 * ToNum(q_1566)))))).Put("sy", ((V)(((1D - (0.1 * e_1565)) - (0.15 * ToNum(q_1566)))))).V;
}
return NewObj(3).Put("x", x_1555).Put("y", ((V)((ToNum(y_1556) - (System.Math.Abs(FdLibm.Sin((ToNum(u_1554) * 6D))) * 3D))))).Put("v", ((V)("front"))).V;
return default;
}, 3, "m", false)).Put("fx", Fn((V _arrowThis1574, int _argc1567, V p_1573, V _a1570, V _a1571, V _a1572, V[] _rest1568) => {
return Call(FX_50, V.Undef, p_1573, Arr(Arr(((V)(5D)), Call(DROP_47, V.Undef, ((V)("#ff3a5a"))), V.Null, Fn((V _arrowThis1584, int _argc1575, V i_1581, V u_1582, V s_1583, V _a1580, V[] _rest1576) => {
double d_1585 = 0;
d_1585 = (LtN(u_1582, 3D) ? (ToNum(u_1582) % B_34) : (ToNum(u_1582) - 6.4));
return Call(spray_51, V.Undef, i_1581, ((V)(5D)), ((V)(d_1585)), Get(s_1583, "x"), ((V)((ToNum((Get(s_1583, "gy") is var _t1586 && !_t1586.IsNullish ? _t1586 : Get(s_1583, "y"))) - 3D))), ((V)(0.42)), ((V)(55D)));
return default;
}, 3, "", true)), Arr(((V)(1D)), ((V)("width:12px;height:11px;")), ((V)("<svg viewBox=\"0 0 10 9\" width=\"12\" height=\"11\"><path d=\"M5 9 L1 5 A2.4 2.4 0 0 1 5 2 A2.4 2.4 0 0 1 9 5Z\" fill=\"#ff4a7a\"></path></svg>")), Fn((V _arrowThis1596, int _argc1587, V i_1593, V u_1594, V s_1595, V _a1592, V[] _rest1588) => {
double d_1597 = 0;
d_1597 = (ToNum(u_1594) - 7.2);
return ((d_1597 < 0D) ? V.Null : NewObj(4).Put("x", Get(s_1595, "x")).Put("y", ((V)(((ToNum(Get(s_1595, "y")) - (62D * ToNum((Get(s_1595, "k") is var _t1598 && Truthy(_t1598) ? _t1598 : ((V)(1D)))))) - (d_1597 * 20D))))).Put("k", ((V)((0.6 + (d_1597 * 0.9))))).Put("o", ((V)(Min(1D, (d_1597 / 0.15))))).V);
return default;
}, 3, "", true))));
}, 1, "fx", true)).V).Put("peachy", NewObj(3).Put("nmY", ((V)(112D))).Put("m", Fn((V _self1599, int _argc1600, V u_1606, V x_1607, V y_1608, V ch_1609, V[] _rest1601) => {
double e_1610 = 0;
if (_self1599.IsNullish) _self1599 = GlobalV;
if (Truthy(ch_1609)) {
u_1606 = ((V)((3.45 + (ToNum(u_1606) % 4.55))));
}
if (LtN(u_1606, 0.6)) {
V e_1611 = default;
e_1611 = Invoke(E_12, "out", Call(seg_38, V.Undef, u_1606, ((V)(0D)), ((V)(0.6))));
return NewObj(7).Put("x", x_1607).Put("px", x_1607).Put("y", Call(lerp_29, V.Undef, y_1608, ((V)((28D + PL_56))), e_1611)).Put("gy", y_1608).Put("v", ((V)("front"))).Put("sx", ((V)(0.95))).Put("sy", ((V)(1.06))).V;
}
if (LtN(u_1606, 3D)) {
double a_1612 = 0;
double ar_1613 = 0;
V b_1614 = default;
a_1612 = ((FdLibm.Sin(((ToNum(u_1606) - 0.6) * 3.4)) * 16D) * Min(1D, ((ToNum(u_1606) - 0.6) / 0.4)));
ar_1613 = ((a_1612 * System.Math.PI) / 180D);
b_1614 = Call(seg_38, V.Undef, u_1606, ((V)(0.6)), ((V)(3D)));
return NewObj(7).Put("x", ((V)((ToNum(x_1607) - (PL_56 * FdLibm.Sin(ar_1613)))))).Put("px", x_1607).Put("y", ((V)((28D + (PL_56 * FdLibm.Cos(ar_1613)))))).Put("gy", y_1608).Put("v", ((V)("front"))).Put("r", ((V)(a_1612))).Put("f", ((V)(JsStrBuf.Begin().S("saturate(").V(Invoke(((V)((1D + (0.5 * ToNum(b_1614))))), "toFixed", ((V)(2D)))).S(") hue-rotate(").V(Invoke(((V)(((-12D) * ToNum(b_1614)))), "toFixed", ((V)(0D)))).S("deg)").End()))).V;
}
if (LtN(u_1606, 3.45)) {
V e_1615 = default;
e_1615 = Invoke(E_12, "in", Call(seg_38, V.Undef, u_1606, ((V)(3D)), ((V)(3.45))));
return NewObj(7).Put("x", x_1607).Put("px", x_1607).Put("y", Call(lerp_29, V.Undef, ((V)((28D + PL_56))), y_1608, e_1615)).Put("gy", y_1608).Put("v", ((V)("front"))).Put("sx", ((V)(0.94))).Put("sy", ((V)(1.08))).V;
}
if (LtN(u_1606, 5D)) {
V j_1616 = default;
double q_1617 = 0;
j_1616 = ((V)(0D));
q_1617 = 0D;
Invoke(Arr(Arr(((V)(3.45)), ((V)(3.95)), ((V)(12D))), Arr(((V)(3.95)), ((V)(4.35)), ((V)(6D))), Arr(((V)(4.35)), ((V)(4.65)), ((V)(3D)))), "forEach", Fn((V _arrowThis1631, int _argc1618, V _a1620, V _a1621, V _a1622, V _a1623, V[] _rest1619) => {
V a_1626 = default;
V b_1628 = default;
V h_1630 = default;
{ V _t1624 = ListOf(_a1620);
{ V _t1625 = GetIdx(_t1624, 0D);
a_1626 = _t1625; }
{ V _t1627 = GetIdx(_t1624, 1D);
b_1628 = _t1627; }
{ V _t1629 = GetIdx(_t1624, 2D);
h_1630 = _t1629; }
}
j_1616 = Add(j_1616, Call(arc_39, V.Undef, u_1606, a_1626, b_1628, h_1630));
if (Ge(u_1606, a_1626)) {
q_1617 = Max(q_1617, ((FdLibm.Exp(((-(ToNum(u_1606) - ToNum(a_1626))) * 12D)) * ToNum(h_1630)) / 12D));
}
return default;
}, 1, "", true));
return NewObj(7).Put("x", x_1607).Put("px", x_1607).Put("y", ((V)((ToNum(y_1608) - ToNum(j_1616))))).Put("gy", y_1608).Put("v", ((V)("front"))).Put("sx", ((V)((1D + (0.2 * q_1617))))).Put("sy", ((V)((1D - (0.24 * q_1617))))).V;
}
if (LtN(u_1606, 7D)) {
double w_1632 = 0;
w_1632 = (ToNum(u_1606) - 5D);
return NewObj(5).Put("x", Add(x_1607, ((V)((FdLibm.Sin((w_1632 * System.Math.PI)) * 14D))))).Put("px", x_1607).Put("y", ((V)((ToNum(y_1608) - (System.Math.Abs(FdLibm.Sin(((w_1632 * 2D) * System.Math.PI))) * 4D))))).Put("v", Call(tw_42, V.Undef, ((V)(w_1632)), ((V)(2D)))).Put("r", ((V)((FdLibm.Sin(((w_1632 * 2D) * System.Math.PI)) * 4D)))).V;
}
e_1610 = FdLibm.Sin((System.Math.PI * ToNum(Call(seg_38, V.Undef, u_1606, ((V)(7D)), ((V)(7.9))))));
return NewObj(6).Put("x", x_1607).Put("px", x_1607).Put("y", y_1608).Put("v", ((V)("front"))).Put("r", ((V)(((-6D) * e_1610)))).Put("sy", ((V)((1D - (0.1 * e_1610))))).V;
return default;
}, 4, "m", false)).Put("fx", Fn((V _arrowThis1640, int _argc1633, V p_1639, V _a1636, V _a1637, V _a1638, V[] _rest1634) => {
return Call(FX_50, V.Undef, p_1639, Arr(Arr(((V)(1D)), ((V)("width:80px;height:20px;")), ((V)("<svg viewBox=\"0 0 80 20\" width=\"80\" height=\"20\"><path d=\"M0 9 Q40 4 80 10\" stroke=\"#7a4a2a\" stroke-width=\"5\" fill=\"none\" stroke-linecap=\"round\"></path><ellipse cx=\"14\" cy=\"6\" rx=\"7\" ry=\"3.5\" fill=\"#4a9a4a\" transform=\"rotate(-20 14 6)\"></ellipse><ellipse cx=\"64\" cy=\"7\" rx=\"7\" ry=\"3.5\" fill=\"#4a9a4a\" transform=\"rotate(20 64 7)\"></ellipse></svg>")), Fn((V _arrowThis1651, int _argc1641, V i_1647, V u_1648, V s_1649, V ch_1650, V[] _rest1642) => {
return (Truthy((ch_1650 is var _t1653 && Truthy(_t1653) ? _t1653 : (GtN(u_1648, 3.6) ? V.True : V.False))) ? V.Null : NewObj(4).Put("x", (Get(s_1649, "px") is var _t1652 && !_t1652.IsNullish ? _t1652 : Get(s_1649, "x"))).Put("y", ((V)(24D))).Put("r", ((V)((FdLibm.Sin((ToNum(u_1648) * 3.4)) * 2D)))).Put("o", ((V)(Min(1D, (ToNum(u_1648) / 0.3), ((3.6 - ToNum(u_1648)) / 0.3))))).V);
}, 4, "", true)), Arr(((V)(1D)), ((V)("width:7px;height:11px;border-radius:50% 0;background:#4a9a4a;")), V.Null, Fn((V _arrowThis1664, int _argc1654, V i_1660, V u_1661, V s_1662, V ch_1663, V[] _rest1655) => {
double d_1665 = 0;
d_1665 = (ToNum(u_1661) - 3D);
return (Truthy(((ch_1663 is var _t1667 && Truthy(_t1667) ? _t1667 : ((d_1665 < 0D) ? V.True : V.False)) is var _t1668 && Truthy(_t1668) ? _t1668 : ((d_1665 > 1.6) ? V.True : V.False))) ? V.Null : NewObj(4).Put("x", Add(Add((Get(s_1662, "px") is var _t1666 && !_t1666.IsNullish ? _t1666 : Get(s_1662, "x")), ((V)(12D))), ((V)((FdLibm.Sin((d_1665 * 6D)) * 10D))))).Put("y", ((V)((26D + (d_1665 * 70D))))).Put("r", ((V)((FdLibm.Sin((d_1665 * 6D)) * 50D)))).Put("o", ((V)((1D - (d_1665 / 1.6))))).V);
return default;
}, 4, "", true)), Arr(((V)(6D)), Call(DROP_47, V.Undef, ((V)("#ffb07a"))), V.Null, Fn((V _arrowThis1679, int _argc1669, V i_1675, V u_1676, V s_1677, V ch_1678, V[] _rest1670) => {
return Call(spray_51, V.Undef, i_1675, ((V)(6D)), ((V)((ToNum((Truthy(ch_1678) ? ((V)((3.45 + (ToNum(u_1676) % 4.55)))) : u_1676)) - 3.45))), Get(s_1677, "x"), ((V)((ToNum((Get(s_1677, "gy") is var _t1680 && !_t1680.IsNullish ? _t1680 : Get(s_1677, "y"))) - 3D))), ((V)(0.45)), ((V)(50D)));
}, 4, "", true))));
}, 1, "fx", true)).V).Put("pixie", NewObj(2).Put("m", Fn((V _self1681, int _argc1682, V u_1688, V x_1689, V y_1690, V _a1687, V[] _rest1683) => {
V f_1691 = default;
double e_1692 = 0;
if (_self1681.IsNullish) _self1681 = GlobalV;
{ V _t1693 = Call(bp_43, V.Undef, u_1688);
if (_t1693.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1693));
{ V _t1694 = Get(_t1693, "f");
f_1691 = _t1694; } }
if (LtN(u_1688, 2D)) {
return NewObj(5).Put("x", x_1689).Put("y", ((V)(((ToNum(y_1690) - (10D + (24D * ToNum(Invoke(E_12, "io", Call(seg_38, V.Undef, u_1688, ((V)(0D)), ((V)(2D)))))))) + (FdLibm.Sin((ToNum(u_1688) * 6D)) * 3D))))).Put("gy", y_1690).Put("v", ((V)("front"))).Put("r", ((V)((FdLibm.Sin((ToNum(u_1688) * 3D)) * 5D)))).V;
}
if (LtN(u_1688, 4D)) {
double a_1695 = 0;
a_1695 = ((2D * System.Math.PI) * ToNum(Invoke(E_12, "io", Call(seg_38, V.Undef, u_1688, ((V)(2D)), ((V)(4D))))));
return NewObj(5).Put("x", Add(x_1689, ((V)((FdLibm.Sin(a_1695) * 24D))))).Put("y", ((V)(((ToNum(y_1690) - 34D) - ((1D - FdLibm.Cos(a_1695)) * 24D))))).Put("gy", y_1690).Put("v", ((V)("front"))).Put("r", Call(wrapR_41, V.Undef, ((V)(((a_1695 * 180D) / System.Math.PI))))).V;
}
if (LtN(u_1688, 6D)) {
V h_1696 = default;
double w_1697 = 0;
h_1696 = Call(lerp_29, V.Undef, ((V)(34D)), ((V)(8D)), Invoke(E_12, "io", Call(seg_38, V.Undef, u_1688, ((V)(4D)), ((V)(4.5)))));
w_1697 = (ToNum(u_1688) - 4D);
return NewObj(4).Put("x", Add(x_1689, ((V)((FdLibm.Sin((w_1697 * System.Math.PI)) * 14D))))).Put("y", ((V)(((ToNum(y_1690) - ToNum(h_1696)) - (FdLibm.Sin((System.Math.PI * ToNum(f_1691))) * 10D))))).Put("gy", y_1690).Put("v", ((V)((LtN(u_1688, 4.5) ? "front" : ((FdLibm.Cos((w_1697 * System.Math.PI)) >= 0D) ? "right" : "left"))))).V;
}
if (LtN(u_1688, 7D)) {
return NewObj(4).Put("x", x_1689).Put("y", ((V)(((ToNum(y_1690) - 12D) - (FdLibm.Sin(((ToNum(u_1688) - 6D) * System.Math.PI)) * 6D))))).Put("gy", y_1690).Put("v", Call(tw_42, V.Undef, ((V)((ToNum(u_1688) - 6D))), ((V)(8D)))).V;
}
e_1692 = FdLibm.Sin((System.Math.PI * ToNum(Call(seg_38, V.Undef, u_1688, ((V)(7D)), ((V)(7.9))))));
return NewObj(6).Put("x", x_1689).Put("y", ((V)((ToNum(y_1690) - ToNum(Call(lerp_29, V.Undef, ((V)(12D)), ((V)(4D)), Call(seg_38, V.Undef, u_1688, ((V)(7D)), ((V)(7.3))))))))).Put("gy", y_1690).Put("v", ((V)("front"))).Put("r", ((V)(((-6D) * e_1692)))).Put("sy", ((V)((1D - (0.08 * e_1692))))).V;
return default;
}, 3, "m", false)).Put("fx", Fn((V _arrowThis1705, int _argc1698, V p_1704, V _a1701, V _a1702, V _a1703, V[] _rest1699) => {
return Call(FX_50, V.Undef, p_1704, Arr(Arr(((V)(12D)), ((V)("width:8px;height:8px;color:#fff6a0;")), CH_37, Fn((V _arrowThis1715, int _argc1706, V i_1712, V u_1713, V s_1714, V _a1711, V[] _rest1707) => {
double a_1716 = 0;
a_1716 = (((ToNum(u_1713) * 1.4) + (ToNum(i_1712) / 12D)) % 1D);
return NewObj(5).Put("x", Add(Get(s_1714, "x"), ((V)((FdLibm.Sin(ToNum(Add(((V)((ToNum(i_1712) * 2.1))), u_1713))) * 12D))))).Put("y", ((V)(((ToNum(Get(s_1714, "y")) - 18D) + (a_1716 * 34D))))).Put("r", ((V)((ToNum(u_1713) * 200D)))).Put("k", ((V)((0.6 + ((1D - a_1716) * 0.5))))).Put("o", ((V)(((1D - a_1716) * 0.95)))).V;
return default;
}, 3, "", true))));
}, 1, "fx", true)).V).Put("drako", NewObj(2).Put("m", Fn((V _self1717, int _argc1718, V u_1724, V x_1725, V y_1726, V _a1723, V[] _rest1719) => {
V hp_1727 = default;
V sq_1728 = default;
V s2_1729 = default;
double e_1730 = 0;
double z_1731 = 0;
if (_self1717.IsNullish) _self1717 = GlobalV;
{ V _t1732 = Call(bp_43, V.Undef, u_1724);
if (_t1732.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1732));
{ V _t1733 = Get(_t1732, "hp");
hp_1727 = _t1733; }
{ V _t1734 = Get(_t1732, "sq");
sq_1728 = _t1734; }
{ V _t1735 = Get(_t1732, "s2");
s2_1729 = _t1735; } }
if (LtN(u_1724, 2D)) {
return NewObj(6).Put("x", x_1725).Put("y", ((V)((ToNum(y_1726) - (ToNum(hp_1727) * 4D))))).Put("v", ((V)("front"))).Put("r", ((V)(((ToNum(s2_1729) * 6D) * ToNum(hp_1727))))).Put("sx", ((V)((1D + (0.1 * ToNum(sq_1728)))))).Put("sy", ((V)((1D - (0.1 * ToNum(sq_1728)))))).V;
}
if (LtN(u_1724, 4D)) {
double k2_1736 = 0;
double q_1737 = 0;
k2_1736 = ((ToNum(u_1724) - 2D) % 1D);
q_1737 = FdLibm.Exp(((-k2_1736) * 9D));
return NewObj(6).Put("x", x_1725).Put("y", ((V)((ToNum(y_1726) - (FdLibm.Sin((System.Math.PI * k2_1736)) * 20D))))).Put("gy", y_1726).Put("v", ((V)("front"))).Put("sx", ((V)((1D + (0.14 * q_1737))))).Put("sy", ((V)((1D - (0.16 * q_1737))))).V;
}
if (LtN(u_1724, 4.5)) {
V e_1738 = default;
e_1738 = Call(seg_38, V.Undef, u_1724, ((V)(4D)), ((V)(4.5)));
return NewObj(5).Put("x", x_1725).Put("y", y_1726).Put("v", ((V)("front"))).Put("sx", ((V)((1D + (0.08 * ToNum(e_1738)))))).Put("sy", ((V)((1D - (0.14 * ToNum(e_1738)))))).V;
}
if (LtN(u_1724, 6D)) {
V e_1739 = default;
e_1739 = Invoke(E_12, "back", Call(seg_38, V.Undef, u_1724, ((V)(4.5)), ((V)(4.8))));
return NewObj(8).Put("x", x_1725).Put("y", y_1726).Put("v", ((V)("front"))).Put("k", ((V)((1D + (0.12 * ToNum(e_1739)))))).Put("sx", ((V)(1.03))).Put("sy", ((V)(1.06))).Put("r", ((V)((FdLibm.Sin((ToNum(u_1724) * 40D)) * 2D)))).Put("shk", ((V)((2.2 * (1D - ToNum(Call(seg_38, V.Undef, u_1724, ((V)(5.5)), ((V)(6D))))))))).V;
}
if (LtN(u_1724, 7.2)) {
double w_1740 = 0;
w_1740 = ((((ToNum(u_1724) - 6D) / 1.2) * 2D) * System.Math.PI);
return NewObj(3).Put("x", Add(x_1725, ((V)((FdLibm.Sin(w_1740) * 10D))))).Put("y", ((V)((ToNum(y_1726) - (System.Math.Abs(FdLibm.Sin(w_1740)) * 3D))))).Put("v", Call(tw_42, V.Undef, ((V)((ToNum(u_1724) - 6D))), ((V)(10D)))).V;
}
e_1730 = (1D - ToNum(Call(seg_38, V.Undef, u_1724, ((V)(7.2)), ((V)(8D)))));
z_1731 = FdLibm.Sin((ToNum(u_1724) * 9D));
return NewObj(6).Put("x", x_1725).Put("y", y_1726).Put("v", ((V)("front"))).Put("r", ((V)(((z_1731 * 10D) * e_1730)))).Put("sx", ((V)((1D + (0.03 * z_1731))))).Put("sy", ((V)((1D - (0.03 * z_1731))))).V;
return default;
}, 3, "m", false)).Put("fx", Fn((V _arrowThis1748, int _argc1741, V p_1747, V _a1744, V _a1745, V _a1746, V[] _rest1742) => {
return Call(FX_50, V.Undef, p_1747, Arr(Arr(((V)(16D)), FLAME_44, V.Null, Fn((V _arrowThis1758, int _argc1749, V i_1755, V u_1756, V s_1757, V _a1754, V[] _rest1750) => {
double a_1759 = 0;
double g_1760 = 0;
V k_1761 = default;
if ((LtN(u_1756, 4.6) || GtN(u_1756, 6D))) {
return V.Null;
}
a_1759 = ((((ToNum(u_1756) - 4.6) * 2.2) + (ToNum(i_1755) / 16D)) % 1D);
g_1760 = (((-System.Math.PI) / 2D) + 0.35);
k_1761 = (Get(s_1757, "k") is var _t1762 && Truthy(_t1762) ? _t1762 : ((V)(1D)));
return NewObj(5).Put("x", Add(Add(Add(Get(s_1757, "x"), ((V)(4D))), ((V)(((FdLibm.Cos(g_1760) * a_1759) * 80D)))), ((V)(((FdLibm.Sin((ToNum(i_1755) * 3.1)) * a_1759) * 10D))))).Put("y", ((V)(((ToNum(Get(s_1757, "y")) - (24D * ToNum(k_1761))) + ((FdLibm.Sin(g_1760) * a_1759) * 80D))))).Put("k", ((V)((0.6 + (a_1759 * 1.6))))).Put("r", ((V)(20D))).Put("o", ((V)(((1D - a_1759) * Min(1D, ((ToNum(u_1756) - 4.6) / 0.15), ((6D - ToNum(u_1756)) / 0.2)))))).V;
return default;
}, 3, "", true)), Arr(((V)(3D)), ((V)("width:30px;height:30px;border-radius:50%;border:2px solid rgba(255,255,255,0.8);border-left-color:transparent;border-right-color:transparent;border-bottom-color:transparent;box-sizing:border-box;")), V.Null, Fn((V _arrowThis1772, int _argc1763, V i_1769, V u_1770, V s_1771, V _a1768, V[] _rest1764) => {
double d_1773 = 0;
if ((LtN(u_1770, 4.5) || GtN(u_1770, 6D))) {
return V.Null;
}
d_1773 = ((((ToNum(u_1770) - 4.5) * 2D) + (ToNum(i_1769) / 3D)) % 1D);
return NewObj(4).Put("x", Get(s_1771, "x")).Put("y", ((V)((ToNum(Get(s_1771, "y")) - (30D * ToNum((Get(s_1771, "k") is var _t1774 && Truthy(_t1774) ? _t1774 : ((V)(1D))))))))).Put("k", ((V)((0.6 + (d_1773 * 2.4))))).Put("o", ((V)((1D - d_1773)))).V;
return default;
}, 3, "", true)), Arr(((V)(3D)), SMOKE_46, V.Null, Fn((V _arrowThis1784, int _argc1775, V i_1781, V u_1782, V s_1783, V _a1780, V[] _rest1776) => {
double d_1785 = 0;
d_1785 = ((ToNum(u_1782) - 7.3) - (ToNum(i_1781) * 0.12));
return (((d_1785 < 0D) || (d_1785 > 0.8)) ? V.Null : NewObj(4).Put("x", Add(Get(s_1783, "x"), ((V)(((ToNum(i_1781) - 1D) * 4D))))).Put("y", ((V)(((ToNum(Get(s_1783, "y")) - 30D) - (d_1785 * 24D))))).Put("k", ((V)((0.6 + (d_1785 * 1.5))))).Put("o", ((V)((1D - (d_1785 / 0.8))))).V);
return default;
}, 3, "", true))));
}, 1, "fx", true)).V).Put("ember", NewObj(2).Put("m", Fn((V _self1786, int _argc1787, V u_1793, V x_1794, V y_1795, V _a1792, V[] _rest1788) => {
V bt_1796 = default;
V hp_1797 = default;
double k2_1798 = 0;
if (_self1786.IsNullish) _self1786 = GlobalV;
{ V _t1799 = Call(bp_43, V.Undef, u_1793);
if (_t1799.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1799));
{ V _t1800 = Get(_t1799, "bt");
bt_1796 = _t1800; }
{ V _t1801 = Get(_t1799, "hp");
hp_1797 = _t1801; } }
if (LtN(u_1793, 3D)) {
return NewObj(4).Put("x", Add(x_1794, ((V)((FdLibm.Sin((((ToNum(u_1793) * System.Math.PI) * 2D) / 3D)) * 8D))))).Put("y", ((V)((ToNum(y_1795) - (ToNum(hp_1797) * 5D))))).Put("v", ((V)("front"))).Put("r", ((V)((FdLibm.Sin((ToNum(bt_1796) * System.Math.PI)) * 4D)))).V;
}
if (LtN(u_1793, 5D)) {
return NewObj(4).Put("x", x_1794).Put("y", ((V)((ToNum(y_1795) - (12D * FdLibm.Sin((System.Math.PI * ToNum(Call(seg_38, V.Undef, u_1793, ((V)(3D)), ((V)(5D))))))))))).Put("gy", y_1795).Put("v", Call(tw_42, V.Undef, ((V)((ToNum(u_1793) - 3D))), ((V)(10D)))).V;
}
if (LtN(u_1793, 6D)) {
V e_1802 = default;
e_1802 = Call(seg_38, V.Undef, u_1793, ((V)(5D)), ((V)(5.4)));
return NewObj(6).Put("x", x_1794).Put("y", y_1795).Put("v", ((V)("front"))).Put("sx", ((V)((1D - (0.06 * ToNum(e_1802)))))).Put("sy", ((V)((1D - (0.1 * ToNum(e_1802)))))).Put("f", ((V)(JsStrBuf.Begin().S("brightness(").V(Invoke(((V)((1D + (0.5 * ToNum(Call(seg_38, V.Undef, u_1793, ((V)(5D)), ((V)(6D)))))))), "toFixed", ((V)(2D)))).S(") saturate(1.3)").End()))).V;
}
if (LtN(u_1793, 7D)) {
double b_1803 = 0;
b_1803 = (1D - ToNum(Call(seg_38, V.Undef, u_1793, ((V)(6D)), ((V)(6.7)))));
return NewObj(6).Put("x", x_1794).Put("y", ((V)((ToNum(y_1795) - ToNum(Call(arc_39, V.Undef, u_1793, ((V)(6D)), ((V)(7D)), ((V)(26D)))))))).Put("gy", y_1795).Put("v", ((V)("front"))).Put("k", ((V)((1D + (0.15 * FdLibm.Sin((System.Math.PI * ToNum(Call(seg_38, V.Undef, u_1793, ((V)(6D)), ((V)(7D))))))))))).Put("f", ((V)(((b_1803 > 0.01) ? JsStrBuf.Begin().S("brightness(").V(Invoke(((V)((1D + (1.3 * b_1803)))), "toFixed", ((V)(2D)))).S(")").End() : "")))).V;
}
k2_1798 = (((ToNum(u_1793) - 7D) % 0.25) / 0.25);
return NewObj(3).Put("x", Add(x_1794, ((V)((NumTruthy((System.Math.Floor(((ToNum(u_1793) - 7D) * 4D)) % 2D)) ? 3D : (-3D)))))).Put("y", ((V)((ToNum(y_1795) - (FdLibm.Sin((System.Math.PI * k2_1798)) * 6D))))).Put("v", ((V)("front"))).V;
return default;
}, 3, "m", false)).Put("fx", Fn((V _arrowThis1811, int _argc1804, V p_1810, V _a1807, V _a1808, V _a1809, V[] _rest1805) => {
return Call(FX_50, V.Undef, p_1810, Arr(Arr(((V)(2D)), ((V)("width:11px;height:11px;border-radius:50%;background:radial-gradient(circle at 40% 40%,#fff6c8 0 25%,#ffb84a 55%,#ff5a2a 80%);box-shadow:0 0 6px 2px rgba(255,140,40,0.7);")), V.Null, Fn((V _arrowThis1821, int _argc1812, V i_1818, V u_1819, V s_1820, V _a1817, V[] _rest1813) => {
double q_1822 = 0;
double d_1823 = 0;
if (GtN(u_1819, 3D)) {
return V.Null;
}
q_1822 = (ToNum(Add(u_1819, ((V)((ToNum(i_1818) * 0.5))))) % 1D);
d_1823 = (NumTruthy((System.Math.Floor(ToNum(Add(u_1819, ((V)((ToNum(i_1818) * 0.5)))))) % 2D)) ? 1D : (-1D));
return NewObj(3).Put("x", Add(Get(s_1820, "x"), ((V)((d_1823 * ((-16D) + (32D * q_1822))))))).Put("y", ((V)(((ToNum(Get(s_1820, "y")) - 44D) - (FdLibm.Sin((System.Math.PI * q_1822)) * 30D))))).Put("o", ((V)(Min(1D, (ToNum(u_1819) / 0.2), ((3D - ToNum(u_1819)) / 0.2))))).V;
return default;
}, 3, "", true)), Arr(((V)(10D)), FLAME_44, V.Null, Fn((V _arrowThis1833, int _argc1824, V i_1830, V u_1831, V s_1832, V _a1829, V[] _rest1825) => {
double a_1834 = 0;
if ((LtN(u_1831, 3D) || GtN(u_1831, 5D))) {
return V.Null;
}
a_1834 = ((ToNum(u_1831) * 9D) + (((ToNum(i_1830) / 10D) * System.Math.PI) * 2D));
return NewObj(4).Put("x", Add(Get(s_1832, "x"), ((V)((FdLibm.Cos(a_1834) * 26D))))).Put("y", ((V)((((ToNum((Get(s_1832, "gy") is var _t1835 && !_t1835.IsNullish ? _t1835 : Get(s_1832, "y"))) - 6D) - (ToNum(i_1830) * 4.5)) - ((ToNum(u_1831) - 3D) * 4D))))).Put("k", ((V)(0.9))).Put("o", ((V)((((FdLibm.Sin(a_1834) > 0D) ? 0.95 : 0.4) * Min(1D, ((ToNum(u_1831) - 3D) / 0.25), ((5D - ToNum(u_1831)) / 0.25)))))).V;
return default;
}, 3, "", true)), Arr(((V)(1D)), ((V)("width:70px;height:70px;border-radius:50%;background:radial-gradient(circle,rgba(255,200,90,0.9) 0 30%,rgba(255,110,40,0.5) 55%,rgba(255,80,20,0) 72%);")), V.Null, Fn((V _arrowThis1845, int _argc1836, V i_1842, V u_1843, V s_1844, V _a1841, V[] _rest1837) => {
return ((LtN(u_1843, 5D) || GtN(u_1843, 6.2)) ? V.Null : NewObj(4).Put("x", Get(s_1844, "x")).Put("y", ((V)((ToNum(Get(s_1844, "y")) - 26D)))).Put("k", ((V)((0.6 + (ToNum(Call(seg_38, V.Undef, u_1843, ((V)(5D)), ((V)(6D)))) * 0.6))))).Put("o", ((V)(Min(1D, ((ToNum(u_1843) - 5D) / 0.3), ((6.2 - ToNum(u_1843)) / 0.2))))).V);
}, 3, "", true)), Arr(((V)(1D)), ((V)("width:30px;height:30px;border-radius:50%;border:3px solid #ffd66b;box-sizing:border-box;box-shadow:0 0 8px #ff8a2a;")), V.Null, Fn((V _arrowThis1855, int _argc1846, V i_1852, V u_1853, V s_1854, V _a1851, V[] _rest1847) => {
double d_1856 = 0;
d_1856 = (ToNum(u_1853) - 6D);
return (((d_1856 < 0D) || (d_1856 > 0.7)) ? V.Null : NewObj(4).Put("x", Get(s_1854, "x")).Put("y", ((V)((ToNum((Get(s_1854, "gy") is var _t1857 && !_t1857.IsNullish ? _t1857 : Get(s_1854, "y"))) - 26D)))).Put("k", ((V)((1D + (d_1856 * 6D))))).Put("o", ((V)((1D - (d_1856 / 0.7))))).V);
return default;
}, 3, "", true)), Arr(((V)(10D)), ((V)("width:3px;height:3px;border-radius:50%;background:#ffe9a0;box-shadow:0 0 3px #ffb84a;")), V.Null, Fn((V _arrowThis1867, int _argc1858, V i_1864, V u_1865, V s_1866, V _a1863, V[] _rest1859) => {
return Call(spray_51, V.Undef, i_1864, ((V)(10D)), ((V)((ToNum(u_1865) - 6D))), Get(s_1866, "x"), ((V)((ToNum((Get(s_1866, "gy") is var _t1868 && !_t1868.IsNullish ? _t1868 : Get(s_1866, "y"))) - 26D))), ((V)(0.7)), ((V)(90D)), ((V)(5.6)));
}, 3, "", true))));
}, 1, "fx", true)).V).V;
popGlint_59 = Fn((V _arrowThis1878, int _argc1869, V g_1875, V p_1876, V X_1877, V _a1874, V[] _rest1870) => {
double o_1879 = 0;
o_1879 = Max(ToNum(Call(win_14, V.Undef, p_1876, ((V)(0.35)), ((V)(0.9)), ((V)(0.15)))), ToNum(Call(win_14, V.Undef, p_1876, ((V)(1.85)), ((V)(2.2)), ((V)(0.12)))));
if ((o_1879 <= 0D)) {
Call(show_16, V.Undef, g_1875, (false ? V.True : V.False));
return default;
}
Call(put_15, V.Undef, g_1875, X_1877, ((V)(2D)), ((V)((1D + (0.3 * FdLibm.Sin((ToNum(p_1876) * 20D)))))), ((V)(0D)), ((V)(o_1879)));
return default;
}, 3, "", true);
lyr_61 = Fn((V _arrowThis1888, int _argc1880, V t_1886, V L_1887, V _a1884, V _a1885, V[] _rest1881) => {
V q_1889 = default;
q_1889 = Invoke(L_1887, "find", Fn((V _arrowThis1897, int _argc1890, V l_1896, V _a1893, V _a1894, V _a1895, V[] _rest1891) => {
return ((Ge(t_1886, GetIdx(l_1896, 0D)) && Lt(t_1886, GetIdx(l_1896, 1D))) ? V.True : V.False);
}, 1, "", true));
return (Truthy(q_1889) ? Arr(GetIdx(q_1889, 2D), Call(win_14, V.Undef, t_1886, GetIdx(q_1889, 0D), GetIdx(q_1889, 1D), ((V)(0.2))), GetIdx(q_1889, 3D)) : V.Null);
return default;
}, 2, "", true);
banner_62 = Fn((V _arrowThis1908, int _argc1898, V p_1904, V txt_1905, V c1_1906, V c2_1907, V[] _rest1899) => {
return Call(D_10, V.Undef, p_1904, ((V)(JsStrBuf.Begin().S("left:0;top:20px;width:320px;text-align:center;font-weight:700;font-size:26px;letter-spacing:1px;z-index:40;-webkit-text-stroke:4px #2a0f4f;paint-order:stroke fill;color:").V(c1_1906).S(";text-shadow:0 0 12px ").V(c2_1907).S(";display:none;").End())), txt_1905);
}, 4, "", true);
wash_63 = Fn((V _arrowThis1917, int _argc1909, V L_1915, V c_1916, V _a1913, V _a1914, V[] _rest1910) => {
return Call(D_10, V.Undef, L_1915, ((V)(JsStrBuf.Begin().S("inset:0;pointer-events:none;mix-blend-mode:screen;z-index:45;opacity:0;background:radial-gradient(ellipse 70% 90% at 50% 100%,").V(c_1916).S(",rgba(0,0,0,0) 72%);").End())));
}, 2, "", true);
beatW_64 = Fn((V _arrowThis1925, int _argc1918, V t_1924, V _a1921, V _a1922, V _a1923, V[] _rest1919) => {
return ((V)(FdLibm.Exp(((-((ToNum(t_1924) / B_34) % 1D)) * 4D))));
}, 1, "", true);
guests_66 = Fn((V _arrowThis1933, int _argc1926, V skip_1932, V _a1929, V _a1930, V _a1931, V[] _rest1927) => {
V C_1934 = default;
V seen_1935 = default;
C_1934 = Arr();
try {
C_1934 = (((Get(G("window"), "MovieNight") is var _t1936 && !Truthy(_t1936) ? _t1936 : Get(Get(G("window"), "MovieNight"), "cast")) is var _t1937 && !Truthy(_t1937) ? _t1937 : Invoke(Get(G("window"), "MovieNight"), "cast")) is var _t1938 && Truthy(_t1938) ? _t1938 : Arr());
} catch (System.Exception _ex1939) {
V e_1940 = default;
e_1940 = Caught(_ex1939);

}
seen_1935 = NewObj(0).V;
return Invoke(Invoke(C_1934, "filter", Fn((V _arrowThis1948, int _argc1941, V c_1947, V _a1944, V _a1945, V _a1946, V[] _rest1942) => {
return ((((c_1947 is var _t1949 && !Truthy(_t1949) ? _t1949 : Get(c_1947, "key")) is var _t1950 && !Truthy(_t1950) ? _t1950 : (!(Truthy(Invoke(skip_1932, "includes", Get(c_1947, "key")))) ? V.True : V.False)) is var _t1951 && !Truthy(_t1951) ? _t1951 : (!(Truthy(GetK(seen_1935, Get(c_1947, "key")))) ? V.True : V.False)) is var _t1952 && !Truthy(_t1952) ? _t1952 : SetK(seen_1935, Get(c_1947, "key"), ((V)(1D))));
}, 1, "", true)), "slice", ((V)(0D)), ((V)(4D)));
return default;
}, 1, "", true);
andList_67 = Fn((V _arrowThis1960, int _argc1953, V a_1959, V _a1956, V _a1957, V _a1958, V[] _rest1954) => {
return (LtN(Get(a_1959, "length"), 2D) ? Invoke(a_1959, "join", ((V)(""))) : ((V)(JsStrBuf.Begin().V(Invoke(Invoke(a_1959, "slice", ((V)(0D)), ((V)((-1D)))), "join", ((V)(", ")))).S(" & ").V(GetIdx(a_1959, (ToNum(Get(a_1959, "length")) - 1D))).End())));
}, 1, "", true);
POPS_69 = Arr(Arr(((V)(58D)), ((V)("bunbun")), ((V)(246D))), Arr(((V)(108D)), ((V)("finn")), ((V)(74D))), Arr(((V)(158D)), ((V)("berri")), ((V)(160D))), Arr(((V)(208D)), ((V)("drako")), ((V)(160D))), Arr(((V)(270D)), ((V)("mittens")), ((V)(160D))));
Invoke(SM_8, "def", ((V)("musical")), NewObj(4).Put("mk", mk_68).Put("score", score_70).Put("beat", Fn((V _arrowThis1968, int _argc1961, V t_1967, V _a1964, V _a1965, V _a1966, V[] _rest1962) => {
V on_1969 = default;
double x_1970 = 0;
on_1969 = (((GeN(t_1967, 7D) && LtN(t_1967, 230D)) || (GeN(t_1967, 240D) && LtN(t_1967, 285D))) ? V.True : V.False);
if (!(Truthy(on_1969))) {
return V.Null;
}
x_1970 = (ToNum(t_1967) / B_34);
return NewObj(3).Put("n", ((V)(System.Math.Floor(x_1970)))).Put("ph", ((V)((x_1970 - System.Math.Floor(x_1970))))).Put("amp", ((V)(1D))).V;
return default;
}, 1, "beat", true)).Put("cues", Invoke(Invoke(Arr(Arr(((V)(6D)), ((V)("cheer"))), Arr(((V)(36D)), ((V)("cheer"))), Arr(((V)(57.2)), ((V)("laugh"))), Arr(((V)(60.5)), ((V)("cheer"))), Arr(((V)(87D)), ((V)("gasp"))), Arr(((V)(110.5)), ((V)("cheer"))), Arr(((V)(140D)), ((V)("doze"))), Arr(((V)(160.5)), ((V)("cheer"))), Arr(((V)(178D)), ((V)("wake"))), Arr(((V)(184D)), ((V)("gasp"))), Arr(((V)(196.5)), ((V)("gasp"))), Arr(((V)(206D)), ((V)("cheer"))), Arr(((V)(210.5)), ((V)("cheer"))), Arr(((V)(232D)), ((V)("hide"))), Arr(((V)(240.3)), ((V)("confetti"))), Arr(((V)(241D)), ((V)("cheer"))), Arr(((V)(252D)), ((V)("cheer"))), Arr(((V)(260.5)), ((V)("cheer"))), Arr(((V)(262D)), ((V)("confetti"))), Arr(((V)(272.5)), ((V)("cheer"))), Arr(((V)(278D)), ((V)("confetti"))), Arr(((V)(279D)), ((V)("cheer"))), Arr(((V)(285.6)), ((V)("dance")))), "concat", Invoke(POPS_69, "map", Fn((V _arrowThis1993, int _argc1980, V _a1982, V _a1983, V _a1984, V _a1985, V[] _rest1981) => {
V t_1988 = default;
V k_1990 = default;
V x_1992 = default;
{ V _t1986 = ListOf(_a1982);
{ V _t1987 = GetIdx(_t1986, 0D);
t_1988 = _t1987; }
{ V _t1989 = GetIdx(_t1986, 1D);
k_1990 = _t1989; }
{ V _t1991 = GetIdx(_t1986, 2D);
x_1992 = _t1991; }
}
return Arr(t_1988, ((V)("pop")), k_1990, x_1992);
}, 1, "", true))), "sort", Fn((V _arrowThis1979, int _argc1971, V a_1977, V b_1978, V _a1975, V _a1976, V[] _rest1972) => {
return ((V)((ToNum(GetIdx(a_1977, 0D)) - ToNum(GetIdx(b_1978, 0D)))));
}, 2, "", true))).V);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
