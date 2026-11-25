// club-fx.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_club_fx_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V TIER_8 = default;
V ON_9 = default;
double CAP_10 = 0;
V R_11 = default;
V pick_12 = default;
V hexA_13 = default;
V tr_14 = default;
V mk_15 = default;
V busy_16 = default;
V run_17 = default;
V puff_18 = default;
V bubble_19 = default;
V CONF_20 = default;
V confetti_21 = default;
V layers_22 = default;
V fadeOut_23 = default;
V start_24 = default;
V stop_25 = default;
V toggle_26 = default;
if (_self1.IsNullish) _self1 = GlobalV;
puff_18 = Fn((V _self27, int _argc28, V job_34, V A_35, V _a32, V _a33, V[] _rest29) => {
V t_36 = default;
V s_37 = default;
V st_38 = default;
V q_39 = default;
double sz_40 = 0;
double life_41 = 0;
V col_42 = default;
double op_43 = 0;
double h_44 = 0;
V el_45 = default;
double x0_46 = 0;
double y0_47 = 0;
V d_48 = default;
double px_49 = 0;
V py_50 = default;
double sp_51 = 0;
V k_52 = default;
V ease_53 = default;
if (_self27.IsNullish) _self27 = GlobalV;
t_36 = Get(job_34, "T");
s_37 = Get(A_35, "s");
st_38 = (Get(Get(job_34, "cfg"), "style") is var _t54 && Truthy(_t54) ? _t54 : ((V)("jet")));
q_39 = Call(pick_12, V.Undef, Get(A_35, "pts"));
sz_40 = (ToNum(Call(R_11, V.Undef, GetIdx(Get(t_36, "size"), 0D), GetIdx(Get(t_36, "size"), 1D))) * ToNum(s_37));
life_41 = ((ToNum(Get(t_36, "life")) * ToNum(Call(R_11, V.Undef, ((V)(0.8)), ((V)(1.15))))) * 1000D);
col_42 = Call(pick_12, V.Undef, Get(Get(job_34, "cfg"), "tint"));
op_43 = (ToNum(Get(t_36, "op")) * ToNum(Call(R_11, V.Undef, ((V)(0.7)), ((V)(1D)))));
h_44 = (sz_40 / 2D);
el_45 = Call(mk_15, V.Undef, Get(A_35, "el"), ((V)(JsStrBuf.Begin().S("width:").V(Invoke(((V)(sz_40)), "toFixed", ((V)(0D)))).S("px;height:").V(Invoke(((V)(sz_40)), "toFixed", ((V)(0D)))).S("px;border-radius:50%;background:radial-gradient(closest-side,").V(Call(hexA_13, V.Undef, col_42, ((V)(op_43)))).S(" 0%,").V(Call(hexA_13, V.Undef, col_42, ((V)((op_43 * 0.6))))).S(" 42%,").V(Call(hexA_13, V.Undef, col_42, ((V)((op_43 * 0.18))))).S(" 72%,").V(Call(hexA_13, V.Undef, col_42, ((V)(0D)))).S(" 100%);").End())));
x0_46 = (ToNum(Get(q_39, "x")) - h_44);
y0_47 = (ToNum(Get(q_39, "y")) - h_44);
d_48 = Get(A_35, "dir");
px_49 = (-ToNum(GetIdx(d_48, 1D)));
py_50 = GetIdx(d_48, 0D);
sp_51 = ((ToNum(Get(t_36, "spd")) * ToNum(s_37)) * ToNum(Get(t_36, "life")));
k_52 = V.Undef;
ease_53 = V.Undef;
if (SEqS(st_38, "jet")) {
V a_55 = default;
double L_56 = 0;
a_55 = Call(R_11, V.Undef, ((V)((-0.4))), ((V)(0.4)));
L_56 = (sp_51 * ToNum(Call(R_11, V.Undef, ((V)(0.45)), ((V)(0.75)))));
k_52 = Arr(NewObj(2).Put("transform", Call(tr_14, V.Undef, ((V)(x0_46)), ((V)(y0_47)), ((V)(0.22)))).Put("opacity", ((V)(0D))).V, NewObj(3).Put("transform", Call(tr_14, V.Undef, ((V)(((x0_46 + ((ToNum(GetIdx(d_48, 0D)) * L_56) * 0.5)) + (((px_49 * ToNum(a_55)) * L_56) * 0.25)))), ((V)(((y0_47 + ((ToNum(GetIdx(d_48, 1D)) * L_56) * 0.5)) + (((ToNum(py_50) * ToNum(a_55)) * L_56) * 0.25)))), ((V)(0.9)))).Put("opacity", ((V)(1D))).Put("offset", ((V)(0.16))).V, NewObj(2).Put("transform", Call(tr_14, V.Undef, ((V)(((x0_46 + (ToNum(GetIdx(d_48, 0D)) * L_56)) + (((px_49 * ToNum(a_55)) * L_56) * 0.8)))), ((V)((((y0_47 + (ToNum(GetIdx(d_48, 1D)) * L_56)) + (((ToNum(py_50) * ToNum(a_55)) * L_56) * 0.8)) - (L_56 * 0.16)))), ((V)(2.1)))).Put("opacity", ((V)(0D))).V);
} else {
if (SEqS(st_38, "haze")) {
double L_57 = 0;
double ex_58 = 0;
double ey_59 = 0;
L_57 = (sp_51 * ToNum(Call(R_11, V.Undef, ((V)(0.35)), ((V)(0.7)))));
ex_58 = (ToNum(Call(R_11, V.Undef, ((V)((-1D))), ((V)(1D)))) * L_57);
ey_59 = ((-ToNum(Call(R_11, V.Undef, ((V)(0.05)), ((V)(0.35))))) * L_57);
k_52 = Arr(NewObj(2).Put("transform", Call(tr_14, V.Undef, ((V)(x0_46)), ((V)(y0_47)), ((V)(0.3)))).Put("opacity", ((V)(0D))).V, NewObj(3).Put("transform", Call(tr_14, V.Undef, ((V)(((x0_46 + ((ToNum(GetIdx(d_48, 0D)) * L_57) * 0.4)) + (ex_58 * 0.3)))), ((V)(((y0_47 + ((ToNum(GetIdx(d_48, 1D)) * L_57) * 0.3)) + (ey_59 * 0.3)))), ((V)(1D)))).Put("opacity", ((V)(1D))).Put("offset", ((V)(0.2))).V, NewObj(2).Put("transform", Call(tr_14, V.Undef, ((V)(((x0_46 + ((ToNum(GetIdx(d_48, 0D)) * L_57) * 0.6)) + ex_58))), ((V)(((y0_47 + ((ToNum(GetIdx(d_48, 1D)) * L_57) * 0.2)) + ey_59))), ((V)(2.4)))).Put("opacity", ((V)(0D))).V);
} else {
if (SEqS(st_38, "up")) {
double H_60 = 0;
double jx_61 = 0;
H_60 = ((150D * ToNum(s_37)) * ToNum(Call(R_11, V.Undef, ((V)(0.8)), ((V)(1.2)))));
jx_61 = (ToNum(Call(R_11, V.Undef, ((V)((-8D))), ((V)(8D)))) * ToNum(s_37));
k_52 = Arr(NewObj(2).Put("transform", Call(tr_14, V.Undef, ((V)(x0_46)), ((V)(y0_47)), ((V)(0.18)))).Put("opacity", ((V)(0D))).V, NewObj(3).Put("transform", Call(tr_14, V.Undef, ((V)((x0_46 + jx_61))), ((V)((y0_47 - (H_60 * 0.55)))), ((V)(0.85)))).Put("opacity", ((V)(1D))).Put("offset", ((V)(0.14))).V, NewObj(2).Put("transform", Call(tr_14, V.Undef, ((V)((x0_46 + (jx_61 * 4D)))), ((V)((y0_47 - H_60))), ((V)(2.3)))).Put("opacity", ((V)(0D))).V);
ease_53 = ((V)("cubic-bezier(0.1,0.8,0.3,1)"));
} else {
if ((SEqS(st_38, "ring") || SEqS(st_38, "mist"))) {
V a_62 = default;
double L_63 = 0;
V up_64 = default;
V sw_65 = default;
a_62 = Call(R_11, V.Undef, ((V)(0D)), ((V)((System.Math.PI * 2D))));
L_63 = (sp_51 * ToNum(Call(R_11, V.Undef, ((V)(0.3)), ((V)(0.6)))));
up_64 = (SEqS(st_38, "mist") ? Call(R_11, V.Undef, ((V)(0.15)), ((V)(0.45))) : ((V)(0.05)));
sw_65 = Call(R_11, V.Undef, ((V)((-0.6))), ((V)(0.6)));
k_52 = Arr(NewObj(2).Put("transform", Call(tr_14, V.Undef, ((V)((x0_46 + ((FdLibm.Cos(ToNum(a_62)) * 6D) * ToNum(s_37))))), ((V)((y0_47 + ((FdLibm.Sin(ToNum(a_62)) * 2D) * ToNum(s_37))))), ((V)(0.3)))).Put("opacity", ((V)(0D))).V, NewObj(3).Put("transform", Call(tr_14, V.Undef, ((V)((x0_46 + ((FdLibm.Cos(ToNum(Add(a_62, sw_65))) * L_63) * 0.45)))), ((V)(((y0_47 + ((FdLibm.Sin(ToNum(Add(a_62, sw_65))) * L_63) * 0.16)) - ((L_63 * ToNum(up_64)) * 0.5)))), ((V)(1D)))).Put("opacity", ((V)(1D))).Put("offset", ((V)(0.2))).V, NewObj(2).Put("transform", Call(tr_14, V.Undef, ((V)((x0_46 + (FdLibm.Cos(ToNum(a_62)) * L_63)))), ((V)(((y0_47 + ((FdLibm.Sin(ToNum(a_62)) * L_63) * 0.34)) - (L_63 * ToNum(up_64))))), ((V)(2.3)))).Put("opacity", ((V)(0D))).V);
} else {
return default;
}
}
}
}
Call(run_17, V.Undef, el_45, k_52, ((V)(life_41)), ease_53);
return default;
}, 2, "puff", false);
bubble_19 = Fn((V _self66, int _argc67, V job_73, V A_74, V small_75, V _a72, V[] _rest68) => {
V s_76 = default;
V q_77 = default;
double sz_78 = 0;
double h_79 = 0;
V d_80 = default;
double px_81 = 0;
V py_82 = default;
double L_83 = 0;
double life_84 = 0;
double w_85 = 0;
V el_86 = default;
V P_87 = default;
V k_88 = default;
V e_89 = default;
if (_self66.IsNullish) _self66 = GlobalV;
s_76 = Get(A_74, "s");
q_77 = Call(pick_12, V.Undef, Get(A_74, "pts"));
sz_78 = (ToNum(Call(R_11, V.Undef, ((V)((Truthy(small_75) ? 6D : 9D))), ((V)((Truthy(small_75) ? 12D : 20D))))) * ToNum(s_76));
h_79 = (sz_78 / 2D);
d_80 = Get(A_74, "dir");
px_81 = (-ToNum(GetIdx(d_80, 1D)));
py_82 = GetIdx(d_80, 0D);
L_83 = (ToNum(Call(R_11, V.Undef, ((V)(70D)), ((V)(150D)))) * ToNum(s_76));
life_84 = (ToNum(Call(R_11, V.Undef, ((V)(3.2)), ((V)(5.2)))) * 1000D);
w_85 = ((ToNum(Call(R_11, V.Undef, ((V)(4D)), ((V)(10D)))) * ToNum(s_76)) * (LtN(Invoke(G("Math"), "random"), 0.5) ? (-1D) : 1D));
el_86 = Call(mk_15, V.Undef, Get(A_74, "el"), ((V)(JsStrBuf.Begin().S("width:").V(Invoke(((V)(sz_78)), "toFixed", ((V)(0D)))).S("px;height:").V(Invoke(((V)(sz_78)), "toFixed", ((V)(0D)))).S("px;border-radius:50%;box-shadow:inset 0 0 0 ").V(Invoke(((V)(Max(1D, (sz_78 * 0.06)))), "toFixed", ((V)(1D)))).S("px rgba(255,255,255,0.75), inset ").V(Invoke(((V)((sz_78 * 0.12))), "toFixed", ((V)(1D)))).S("px ").V(Invoke(((V)(((-sz_78) * 0.1))), "toFixed", ((V)(1D)))).S("px ").V(Invoke(((V)((sz_78 * 0.2))), "toFixed", ((V)(1D)))).S("px rgba(120,220,255,0.45), inset ").V(Invoke(((V)(((-sz_78) * 0.1))), "toFixed", ((V)(1D)))).S("px ").V(Invoke(((V)((sz_78 * 0.12))), "toFixed", ((V)(1D)))).S("px ").V(Invoke(((V)((sz_78 * 0.2))), "toFixed", ((V)(1D)))).S("px rgba(255,140,220,0.4);background:radial-gradient(circle at 32% 28%, rgba(255,255,255,0.95) 0 9%, rgba(255,255,255,0) 24%), radial-gradient(circle, rgba(200,240,255,0.06) 60%, rgba(255,255,255,0.18) 100%);").End())));
P_87 = Fn((V _arrowThis97, int _argc90, V f_96, V _a93, V _a94, V _a95, V[] _rest91) => {
double ux_98 = 0;
double uy_99 = 0;
ux_98 = (((ToNum(GetIdx(d_80, 0D)) * L_83) * ToNum(f_96)) + ((px_81 * FdLibm.Sin((ToNum(f_96) * 6.3))) * w_85));
uy_99 = ((((ToNum(GetIdx(d_80, 1D)) * L_83) * ToNum(f_96)) + ((ToNum(py_82) * FdLibm.Sin((ToNum(f_96) * 6.3))) * w_85)) - ((L_83 * 0.55) * Pow(ToNum(f_96), 1.25)));
return Arr(((V)(((ToNum(Get(q_77, "x")) - h_79) + ux_98))), ((V)(((ToNum(Get(q_77, "y")) - h_79) + uy_99))));
return default;
}, 1, "", true);
k_88 = Invoke(Arr(((V)(0D)), ((V)(0.25)), ((V)(0.5)), ((V)(0.75)), ((V)(0.93))), "map", Fn((V _arrowThis108, int _argc100, V f_106, V i_107, V _a104, V _a105, V[] _rest101) => {
V x_109 = default;
V y_110 = default;
{ V _t111 = Call(P_87, V.Undef, f_106);
{ V _t112 = ListOf(_t111);
{ V _t113 = GetIdx(_t112, 0D);
x_109 = _t113; }
{ V _t114 = GetIdx(_t112, 1D);
y_110 = _t114; }
} }
return NewObj(3).Put("transform", Call(tr_14, V.Undef, x_109, y_110, ((V)((Truthy(i_107) ? 1D : 0.4))))).Put("opacity", ((V)((Truthy(i_107) ? 0.95 : 0D)))).Put("offset", f_106).V;
return default;
}, 2, "", true));
e_89 = Call(P_87, V.Undef, ((V)(0.93)));
Invoke(k_88, "push", NewObj(3).Put("transform", Call(tr_14, V.Undef, GetIdx(e_89, 0D), GetIdx(e_89, 1D), ((V)(1.35)))).Put("opacity", ((V)(0D))).Put("offset", ((V)(1D))).V);
Call(run_17, V.Undef, el_86, k_88, ((V)(life_84)), ((V)("linear")));
return default;
}, 3, "bubble", false);
confetti_21 = Fn((V _self115, int _argc116, V job_122, V A_123, V _a120, V _a121, V[] _rest117) => {
V c_124 = default;
V s_125 = default;
if (_self115.IsNullish) _self115 = GlobalV;
c_124 = Get(A_123, "cf");
if (!(Truthy(c_124))) {
return default;
}
s_125 = Get(A_123, "s");
{
double i_126 = 0;
i_126 = 0D;
while (true) {
if (!((i_126 < 22D))) break;
double w_128 = 0;
double hh_129 = 0;
double vx_130 = 0;
double H_131 = 0;
double life_132 = 0;
V el_133 = default;
w_128 = (ToNum(Call(R_11, V.Undef, ((V)(3D)), ((V)(6D)))) * ToNum(s_125));
hh_129 = (w_128 * ToNum(Call(R_11, V.Undef, ((V)(0.45)), ((V)(0.7)))));
vx_130 = (ToNum(Call(R_11, V.Undef, ((V)((-70D))), ((V)(70D)))) * ToNum(s_125));
H_131 = (ToNum(Call(R_11, V.Undef, ((V)(110D)), ((V)(190D)))) * ToNum(s_125));
life_132 = (ToNum(Call(R_11, V.Undef, ((V)(2.2)), ((V)(3.4)))) * 1000D);
el_133 = Call(mk_15, V.Undef, Get(A_123, "el"), ((V)(JsStrBuf.Begin().S("width:").V(Invoke(((V)(w_128)), "toFixed", ((V)(0D)))).S("px;height:").V(Invoke(((V)(hh_129)), "toFixed", ((V)(0D)))).S("px;border-radius:1px;background:").V(Call(pick_12, V.Undef, CONF_20)).S(";").End())));
Call(run_17, V.Undef, el_133, Arr(NewObj(2).Put("transform", Call(tr_14, V.Undef, Get(c_124, "x"), Get(c_124, "y"), ((V)(0.6)), ((V)(0D)))).Put("opacity", ((V)(1D))).V, NewObj(3).Put("transform", Call(tr_14, V.Undef, Add(Get(c_124, "x"), ((V)((vx_130 * 0.6)))), ((V)((ToNum(Get(c_124, "y")) - H_131))), ((V)(1D)), Call(R_11, V.Undef, ((V)(200D)), ((V)(500D))))).Put("opacity", ((V)(1D))).Put("offset", ((V)(0.32))).V, NewObj(2).Put("transform", Call(tr_14, V.Undef, Add(Get(c_124, "x"), ((V)(vx_130))), ((V)(((ToNum(Get(c_124, "y")) - (H_131 * 0.35)) + (ToNum(Call(R_11, V.Undef, ((V)(0D)), ((V)(50D)))) * ToNum(s_125))))), ((V)(1D)), Call(R_11, V.Undef, ((V)(700D)), ((V)(1200D))))).Put("opacity", ((V)(0D))).V), ((V)(life_132)), ((V)("cubic-bezier(0.15,0.75,0.4,1)")));
i_126++;
}
}
return default;
}, 2, "confetti", false);
layers_22 = Fn((V _self134, int _argc135, V job_141, V A_142, V _a139, V _a140, V[] _rest136) => {
V t_143 = default;
V s_144 = default;
V f_145 = default;
if (_self134.IsNullish) _self134 = GlobalV;
t_143 = Get(job_141, "T");
s_144 = Get(A_142, "s");
f_145 = (Get(A_142, "fl") is var _t146 && Truthy(_t146) ? _t146 : GetIdx(Get(A_142, "pts"), 0D));
if (Truthy(Get(t_143, "dim"))) {
Set(job_141, "dim", Call(mk_15, V.Undef, Get(A_142, "el"), ((V)(JsStrBuf.Begin().S("inset:0;width:auto;height:auto;background:radial-gradient(ellipse at ").V(Invoke(Get(f_145, "x"), "toFixed", ((V)(0D)))).S("px ").V(Invoke(Get(f_145, "y"), "toFixed", ((V)(0D)))).S("px, rgba(24,18,48,").V(Invoke(((V)((ToNum(Get(t_143, "dim")) * 0.55))), "toFixed", ((V)(2D)))).S("), rgba(12,10,26,").V(Invoke(Get(t_143, "dim"), "toFixed", ((V)(2D)))).S(") 70%);opacity:0;transition:opacity 1.6s;").End()))));
Call(G("requestAnimationFrame"), V.Undef, Fn((V _arrowThis160, int _argc154, V _a156, V _a157, V _a158, V _a159, V[] _rest155) => {
if (Truthy(Get(job_141, "dim"))) {
Set(Get(Get(job_141, "dim"), "style"), "opacity", ((V)("1")));
}
return default;
}, 0, "", true));
}
if (Truthy(Get(t_143, "bank"))) {
double w_161 = 0;
double h_162 = 0;
V col_163 = default;
w_161 = ((150D + (ToNum(Get(Get(job_141, "cfg"), "t")) * 40D)) * ToNum(s_144));
h_162 = (w_161 * 0.3);
col_163 = GetIdx(Get(Get(job_141, "cfg"), "tint"), 0D);
Set(job_141, "bank", Call(mk_15, V.Undef, Get(A_142, "el"), ((V)(JsStrBuf.Begin().S("width:").V(Invoke(((V)(w_161)), "toFixed", ((V)(0D)))).S("px;height:").V(Invoke(((V)(h_162)), "toFixed", ((V)(0D)))).S("px;border-radius:50%;left:").V(Invoke(((V)((ToNum(Get(f_145, "x")) - (w_161 / 2D)))), "toFixed", ((V)(0D)))).S("px;top:").V(Invoke(((V)((ToNum(Get(f_145, "y")) - (h_162 * 0.6)))), "toFixed", ((V)(0D)))).S("px;opacity:0;transition:opacity 3s;background:radial-gradient(closest-side,").V(Call(hexA_13, V.Undef, col_163, Get(t_143, "bank"))).S(" 0%,").V(Call(hexA_13, V.Undef, col_163, ((V)((ToNum(Get(t_143, "bank")) * 0.7))))).S(" 45%,").V(Call(hexA_13, V.Undef, col_163, ((V)(0D)))).S(" 100%);").End()))));
Invoke(Get(job_141, "bank"), "animate", Arr(NewObj(1).Put("transform", ((V)("translateX(-4%) scale(1,1)"))).V, NewObj(1).Put("transform", ((V)("translateX(4%) scale(1.14,1.08)"))).V), NewObj(4).Put("duration", ((V)(5200D))).Put("direction", ((V)("alternate"))).Put("iterations", ((V)(double.PositiveInfinity))).Put("easing", ((V)("ease-in-out"))).V);
Call(G("requestAnimationFrame"), V.Undef, Fn((V _arrowThis177, int _argc171, V _a173, V _a174, V _a175, V _a176, V[] _rest172) => {
if (Truthy(Get(job_141, "bank"))) {
Set(Get(Get(job_141, "bank"), "style"), "opacity", ((V)("1")));
}
return default;
}, 0, "", true));
}
return default;
}, 2, "layers", false);
fadeOut_23 = Fn((V _self178, int _argc179, V el_185, V ms_186, V _a183, V _a184, V[] _rest180) => {
if (_self178.IsNullish) _self178 = GlobalV;
if (!(Truthy(el_185))) {
return default;
}
Set(Get(el_185, "style"), "transition", ((V)(JsStrBuf.Begin().S("opacity ").V(ms_186).S("ms ease-in").End())));
Set(Get(el_185, "style"), "opacity", ((V)("0")));
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis200, int _argc194, V _a196, V _a197, V _a198, V _a199, V[] _rest195) => {
return Invoke(el_185, "remove");
}, 0, "", true), Add(ms_186, ((V)(80D))));
return default;
}, 2, "fadeOut", false);
start_24 = Fn((V _self201, int _argc202, V key_208, V getA_209, V cfg_210, V _a207, V[] _rest203) => {
V T_211 = default;
V job_212 = default;
V A0_213 = default;
if (_self201.IsNullish) _self201 = GlobalV;
Call(stop_25, V.Undef, key_208, (true ? V.True : V.False));
T_211 = (GetIdx(TIER_8, Max(1D, Min(5D, ((double)(ToInt32(ToNum(Get(cfg_210, "t"))) | ToInt32(0D)))))) is var _t214 && Truthy(_t214) ? _t214 : GetIdx(TIER_8, 2D));
job_212 = NewObj(8).Put("key", key_208).Put("getA", getA_209).Put("cfg", Object_assign(NewObj(0).V, cfg_210, NewObj(2).Put("tint", (Truthy((Get(cfg_210, "tint") is var _t215 && !Truthy(_t215) ? _t215 : Get(Get(cfg_210, "tint"), "length"))) ? Get(cfg_210, "tint") : Arr(((V)("#f4f6fa"))))).Put("style", (Get(cfg_210, "style") is var _t216 && Truthy(_t216) ? _t216 : ((V)("jet")))).V)).Put("T", T_211).Put("acc", ((V)(0D))).Put("bacc", ((V)(0D))).Put("t0", Invoke(G("performance"), "now")).Put("miss", ((V)(0D))).V;
A0_213 = Call(getA_209, V.Undef);
if (!(Truthy(A0_213))) {
return (false ? V.True : V.False);
}
Call(layers_22, V.Undef, job_212, A0_213);
Set(job_212, "iv", Call(G("setInterval"), V.Undef, Fn((V _arrowThis239, int _argc233, V _a235, V _a236, V _a237, V _a238, V[] _rest234) => {
V A_224 = default;
double el_225 = 0;
V rate_226 = default;
V now_227 = default;
double dt_228 = 0;
A_224 = Call(getA_209, V.Undef);
if ((!(Truthy(A_224)) || !(Truthy(Get(Get(A_224, "el"), "isConnected"))))) {
if ((IncM(job_212, "miss", 1D, true) > 4D)) {
Call(stop_25, V.Undef, key_208, (true ? V.True : V.False));
}
return default;
}
Set(job_212, "miss", ((V)(0D)));
el_225 = ((ToNum(Invoke(G("performance"), "now")) - ToNum(Get(job_212, "t0"))) / 1000D);
rate_226 = Get(T_211, "rate");
if (SEqS(Get(Get(job_212, "cfg"), "style"), "up")) {
double ph_229 = 0;
ph_229 = (el_225 % 2.4);
rate_226 = ((V)(((ph_229 < 0.7) ? (ToNum(Get(T_211, "rate")) * 3.2) : (ToNum(Get(T_211, "rate")) * 0.12))));
if (Truthy(((Get(A_224, "cf") is var _t240 && !Truthy(_t240) ? _t240 : ((ph_229 < 0.1) ? V.True : V.False)) is var _t241 && !Truthy(_t241) ? _t241 : (!(Truthy(Get(job_212, "cfDone"))) ? V.True : V.False)))) {
Set(job_212, "cfDone", ((V)(1D)));
Call(confetti_21, V.Undef, job_212, A_224);
}
if ((ph_229 > 0.2)) {
Set(job_212, "cfDone", ((V)(0D)));
}
}
if (Truthy(Call(busy_16, V.Undef, Get(A_224, "el")))) {
return default;
}
now_227 = Invoke(G("performance"), "now");
dt_228 = Min(0.5, ((ToNum(now_227) - ToNum((Get(job_212, "last") is var _t242 && Truthy(_t242) ? _t242 : ((V)((ToNum(now_227) - 100D)))))) / 1000D));
Set(job_212, "last", now_227);
OpSet(job_212, "acc", 0, ((V)((ToNum(rate_226) * dt_228))));
while (GeN(Get(job_212, "acc"), 1D)) {
OpSet(job_212, "acc", 1, ((V)(1D)));
Call(puff_18, V.Undef, job_212, A_224);
}
OpSet(job_212, "bacc", 0, ((V)((ToNum(Get(T_211, "bub")) * dt_228))));
while (GeN(Get(job_212, "bacc"), 1D)) {
OpSet(job_212, "bacc", 1, ((V)(1D)));
Call(bubble_19, V.Undef, job_212, A_224, (GtN(Get(cfg_210, "t"), 1D) ? V.True : V.False));
}
return default;
}, 0, "", true), ((V)(100D))));
Invoke(ON_9, "set", key_208, job_212);
return (true ? V.True : V.False);
return default;
}, 3, "start", false);
stop_25 = Fn((V _self243, int _argc244, V key_250, V quick_251, V _a248, V _a249, V[] _rest245) => {
V job_252 = default;
double ms_253 = 0;
if (_self243.IsNullish) _self243 = GlobalV;
job_252 = Invoke(ON_9, "get", key_250);
if (!(Truthy(job_252))) {
return default;
}
Call(G("clearInterval"), V.Undef, Get(job_252, "iv"));
Invoke(ON_9, "delete", key_250);
ms_253 = (Truthy(quick_251) ? 300D : Round((ToNum(Get(Get(job_252, "T"), "linger")) * 1000D)));
Call(fadeOut_23, V.Undef, Get(job_252, "bank"), ((V)(ms_253)));
Call(fadeOut_23, V.Undef, Get(job_252, "dim"), ((V)(Max(600D, (ms_253 * 0.7)))));
return default;
}, 2, "stop", false);
toggle_26 = Fn((V _self254, int _argc255, V key_261, V getA_262, V cfg_263, V _a260, V[] _rest256) => {
if (_self254.IsNullish) _self254 = GlobalV;
if (Truthy(Invoke(ON_9, "has", key_261))) {
Call(stop_25, V.Undef, key_261);
return (false ? V.True : V.False);
}
return Call(start_24, V.Undef, key_261, getA_262, cfg_263);
return default;
}, 3, "toggle", false);
if (Truthy(Get(G("window"), "ClubFog"))) {
return default;
}
TIER_8 = NewObj(5).Put("1", NewObj(9).Put("rate", ((V)(0D))).Put("size", Arr(((V)(0D)), ((V)(0D)))).Put("life", ((V)(4.6))).Put("op", ((V)(0D))).Put("spd", ((V)(0D))).Put("bank", ((V)(0D))).Put("linger", ((V)(0.4))).Put("dim", ((V)(0D))).Put("bub", ((V)(6D))).V).Put("2", NewObj(9).Put("rate", ((V)(4D))).Put("size", Arr(((V)(24D)), ((V)(42D)))).Put("life", ((V)(3.6))).Put("op", ((V)(0.5))).Put("spd", ((V)(70D))).Put("bank", ((V)(0D))).Put("linger", ((V)(1.2))).Put("dim", ((V)(0.1))).Put("bub", ((V)(0D))).V).Put("3", NewObj(9).Put("rate", ((V)(7D))).Put("size", Arr(((V)(34D)), ((V)(62D)))).Put("life", ((V)(6D))).Put("op", ((V)(0.56))).Put("spd", ((V)(52D))).Put("bank", ((V)(0.32))).Put("linger", ((V)(6D))).Put("dim", ((V)(0.18))).Put("bub", ((V)(0D))).V).Put("4", NewObj(9).Put("rate", ((V)(10D))).Put("size", Arr(((V)(42D)), ((V)(80D)))).Put("life", ((V)(7.6))).Put("op", ((V)(0.62))).Put("spd", ((V)(48D))).Put("bank", ((V)(0.44))).Put("linger", ((V)(9D))).Put("dim", ((V)(0.24))).Put("bub", ((V)(0D))).V).Put("5", NewObj(9).Put("rate", ((V)(14D))).Put("size", Arr(((V)(56D)), ((V)(104D)))).Put("life", ((V)(10.5))).Put("op", ((V)(0.7))).Put("spd", ((V)(38D))).Put("bank", ((V)(0.56))).Put("linger", ((V)(14D))).Put("dim", ((V)(0.3))).Put("bub", ((V)(3D))).V).V;
ON_9 = New(G("Map"));
CAP_10 = 170D;
R_11 = Fn((V _arrowThis272, int _argc264, V a_270, V b_271, V _a268, V _a269, V[] _rest265) => {
return Add(a_270, ((V)((ToNum(Invoke(G("Math"), "random")) * (ToNum(b_271) - ToNum(a_270))))));
}, 2, "", true);
pick_12 = Fn((V _arrowThis280, int _argc273, V a_279, V _a276, V _a277, V _a278, V[] _rest274) => {
return GetIdx(a_279, System.Math.Floor((ToNum(Invoke(G("Math"), "random")) * ToNum(Get(a_279, "length")))));
}, 1, "", true);
hexA_13 = Fn((V _arrowThis289, int _argc281, V h_287, V a_288, V _a285, V _a286, V[] _rest282) => {
double n_290 = 0;
n_290 = ParseInt(Invoke(h_287, "slice", ((V)(1D))), ((V)(16D)));
return ((V)(JsStrBuf.Begin().S("rgba(").N(((double)(ToInt32(((double)(ToInt32(n_290) >> (int)(ToUint32(16D) & 31)))) & ToInt32(255D)))).S(",").N(((double)(ToInt32(((double)(ToInt32(n_290) >> (int)(ToUint32(8D) & 31)))) & ToInt32(255D)))).S(",").N(((double)(ToInt32(n_290) & ToInt32(255D)))).S(",").V(Invoke(a_288, "toFixed", ((V)(3D)))).S(")").End()));
return default;
}, 2, "", true);
tr_14 = Fn((V _arrowThis301, int _argc291, V x_297, V y_298, V s_299, V r_300, V[] _rest292) => {
return ((V)(JsStrBuf.Begin().S("translate(").V(Invoke(x_297, "toFixed", ((V)(1D)))).S("px,").V(Invoke(y_298, "toFixed", ((V)(1D)))).S("px) scale(").V(Invoke(s_299, "toFixed", ((V)(3D)))).S(")").S((Truthy(r_300) ? JsStrBuf.Begin().S(" rotate(").V(Invoke(r_300, "toFixed", ((V)(0D)))).S("deg)").End() : "")).End()));
}, 4, "", true);
mk_15 = Fn((V _arrowThis310, int _argc302, V box_308, V css_309, V _a306, V _a307, V[] _rest303) => {
V d_311 = default;
d_311 = Invoke(G("document"), "createElement", ((V)("div")));
Set(d_311, "className", ((V)("cfog")));
Set(Get(d_311, "style"), "cssText", ((V)(JsStrBuf.Begin().S("position:absolute;left:0;top:0;pointer-events:none;will-change:transform,opacity;").V(css_309).End())));
Invoke(box_308, "appendChild", d_311);
return d_311;
return default;
}, 2, "", true);
busy_16 = Fn((V _arrowThis319, int _argc312, V box_318, V _a315, V _a316, V _a317, V[] _rest313) => {
return (GtN(Get(box_318, "childElementCount"), CAP_10) ? V.True : V.False);
}, 1, "", true);
run_17 = Fn((V _arrowThis330, int _argc320, V el_326, V k_327, V ms_328, V ease_329, V[] _rest321) => {
V a_331 = default;
a_331 = Invoke(el_326, "animate", k_327, NewObj(3).Put("duration", ms_328).Put("easing", (ease_329 is var _t332 && Truthy(_t332) ? _t332 : ((V)("cubic-bezier(0.22,0.6,0.35,1)")))).Put("fill", ((V)("forwards"))).V);
Set(a_331, "onfinish", Fn((V _arrowThis339, int _argc333, V _a335, V _a336, V _a337, V _a338, V[] _rest334) => {
return Invoke(el_326, "remove");
}, 0, "", true));
return a_331;
return default;
}, 4, "", true);
CONF_20 = Arr(((V)("#ff4f6a")), ((V)("#ffd84f")), ((V)("#3ff0ff")), ((V)("#7dff6a")), ((V)("#b04bff")), ((V)("#ffffff")), ((V)("#ff9d3c")));
Set(G("window"), "ClubFog", NewObj(6).Put("toggle", toggle_26).Put("start", start_24).Put("stop", stop_25).Put("isOn", Fn((V _arrowThis347, int _argc340, V k_346, V _a343, V _a344, V _a345, V[] _rest341) => {
return Invoke(ON_9, "has", k_346);
}, 1, "isOn", true)).Put("stopAll", Fn((V _arrowThis355, int _argc348, V pre_354, V _a351, V _a352, V _a353, V[] _rest349) => {
return Invoke(new ArrBuilder().Spread(Invoke(ON_9, "keys")).V, "forEach", Fn((V _arrowThis363, int _argc356, V k_362, V _a359, V _a360, V _a361, V[] _rest357) => {
if (Truthy(((!(Truthy(pre_354)) ? V.True : V.False) is var _t364 && Truthy(_t364) ? _t364 : Invoke(k_362, "startsWith", pre_354)))) {
Call(stop_25, V.Undef, k_362, (true ? V.True : V.False));
}
return default;
}, 1, "", true));
}, 1, "stopAll", true)).Put("TIER", TIER_8).V);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
