// movies-kit.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_movies_kit_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V cl_8 = default;
V lerp_9 = default;
V E_10 = default;
V P_11 = default;
V kf_12 = default;
V win_13 = default;
V el_14 = default;
V D_15 = default;
V show_16 = default;
V put_17 = default;
V rnd_18 = default;
V art_19 = default;
V SPIN_20 = default;
V actor_21 = default;
V pose_22 = default;
V go_23 = default;
V dance_24 = default;
V bub_25 = default;
V lines_26 = default;
V parts_27 = default;
V stars_28 = default;
V rain_29 = default;
V lightning_30 = default;
V glow_31 = default;
V film_32 = default;
V mtof_33 = default;
V snd_34 = default;
if (_self1.IsNullish) _self1 = GlobalV;
el_14 = Fn((V _self35, int _argc36, V tag_42, V css_43, V p_44, V html_45, V[] _rest37) => {
V n_46 = default;
if (_self35.IsNullish) _self35 = GlobalV;
n_46 = Invoke(G("document"), "createElement", tag_42);
if (Truthy(css_43)) {
Set(Get(n_46, "style"), "cssText", css_43);
}
if (!html_45.IsNullish) {
Set(n_46, "innerHTML", html_45);
}
if (Truthy(p_44)) {
Invoke(p_44, "appendChild", n_46);
}
return n_46;
return default;
}, 4, "el", false);
actor_21 = Fn((V _self47, int _argc48, V p_54, V k_55, V _a52, V _a53, V[] _rest49) => {
V sd_58 = default;
V n_59 = default;
V w_57 = default;
if (_self47.IsNullish) _self47 = GlobalV;
{ V _t56 = _a52; if (_t56.IsUndef) _t56 = ((V)(58D));
w_57 = _t56; }
sd_58 = Call(D_15, V.Undef, p_54, ((V)(JsStrBuf.Begin().S("left:0;top:0;width:").N((ToNum(w_57) * 0.72)).S("px;height:").N((ToNum(w_57) * 0.12)).S("px;border-radius:50%;background:rgba(10,8,30,0.3);display:none;").End())));
n_59 = Call(el_14, V.Undef, ((V)("img")), ((V)(JsStrBuf.Begin().S("position:absolute;left:0;top:0;width:").V(w_57).S("px;height:").V(w_57).S("px;transform-origin:50% 94%;display:none;").End())), p_54);
Set(n_59, "alt", ((V)("")));
Set(n_59, "draggable", (false ? V.True : V.False));
Set(n_59, "_k", k_55);
Set(n_59, "_w", w_57);
Set(n_59, "_v", ((V)("")));
Set(n_59, "_sd", sd_58);
Invoke(SPIN_20, "forEach", Fn((V _arrowThis67, int _argc60, V v_66, V _a63, V _a64, V _a65, V[] _rest61) => {
V i_68 = default;
i_68 = New(G("Image"));
Set(i_68, "src", Call(art_19, V.Undef, k_55, v_66));
return default;
}, 1, "", true));
return n_59;
return default;
}, 3, "actor", false);
pose_22 = Fn((V _self69, int _argc70, V n_76, V s_77, V _a74, V _a75, V[] _rest71) => {
V v_78 = default;
V w_79 = default;
V k_80 = default;
double ra_81 = 0;
double ly_82 = 0;
V gy_83 = default;
double q_84 = 0;
if (_self69.IsNullish) _self69 = GlobalV;
if (!(Truthy(s_77))) {
Call(show_16, V.Undef, n_76, (false ? V.True : V.False));
Call(show_16, V.Undef, Get(n_76, "_sd"), (false ? V.True : V.False));
return default;
}
v_78 = (Get(s_77, "v") is var _t85 && Truthy(_t85) ? _t85 : ((V)("front")));
if (!SEq(Get(n_76, "_v"), v_78)) {
Set(n_76, "_v", v_78);
Set(n_76, "src", Call(art_19, V.Undef, Get(n_76, "_k"), v_78));
}
w_79 = Get(n_76, "_w");
k_80 = (Get(s_77, "k") is var _t86 && Truthy(_t86) ? _t86 : ((V)(1D)));
ra_81 = ((Min(90D, System.Math.Abs(ToNum((Get(s_77, "r") is var _t87 && Truthy(_t87) ? _t87 : ((V)(0D)))))) * System.Math.PI) / 180D);
ly_82 = (((Pow(FdLibm.Sin(ra_81), 2D) * ToNum(w_79)) * 0.4) * ToNum(k_80));
Call(show_16, V.Undef, n_76, (true ? V.True : V.False));
Set(Get(n_76, "style"), "opacity", (Get(s_77, "o").IsNullish ? ((V)("1")) : Invoke(Get(s_77, "o"), "toFixed", ((V)(3D)))));
Set(Get(n_76, "style"), "filter", (Get(s_77, "f") is var _t88 && Truthy(_t88) ? _t88 : ((V)(""))));
Set(Get(n_76, "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").V(Invoke(((V)((ToNum(Get(s_77, "x")) - (ToNum(w_79) / 2D)))), "toFixed", ((V)(2D)))).S("px,").V(Invoke(((V)(((ToNum(Get(s_77, "y")) - ly_82) - (ToNum(w_79) * 0.94)))), "toFixed", ((V)(2D)))).S("px) rotate(").V(Invoke((Get(s_77, "r") is var _t89 && Truthy(_t89) ? _t89 : ((V)(0D))), "toFixed", ((V)(2D)))).S("deg) scale(").V(Invoke(((V)((ToNum((Get(s_77, "sx") is var _t90 && Truthy(_t90) ? _t90 : ((V)(1D)))) * ToNum(k_80)))), "toFixed", ((V)(3D)))).S(",").V(Invoke(((V)((ToNum((Get(s_77, "sy") is var _t91 && Truthy(_t91) ? _t91 : ((V)(1D)))) * ToNum(k_80)))), "toFixed", ((V)(3D)))).S(")").End())));
if (SEq(Get(s_77, "sh"), (false ? V.True : V.False))) {
Call(show_16, V.Undef, Get(n_76, "_sd"), (false ? V.True : V.False));
return default;
}
gy_83 = (Get(s_77, "gy").IsNullish ? Get(s_77, "y") : Get(s_77, "gy"));
q_84 = (1D - (ToNum(Call(cl_8, V.Undef, ((V)(((ToNum(gy_83) - ToNum(Get(s_77, "y"))) / 50D))))) * 0.6));
Call(put_17, V.Undef, Get(n_76, "_sd"), Get(s_77, "x"), Add(gy_83, ((V)(1D))), ((V)((ToNum(k_80) * q_84))), ((V)(0D)), ((V)(((ToNum((Get(s_77, "o").IsNullish ? ((V)(1D)) : Get(s_77, "o"))) * 0.9) * q_84))));
return default;
}, 2, "pose", false);
go_23 = Fn((V _self92, int _argc93, V t_99, V K_100, V _a97, V _a98, V[] _rest94) => {
double i_103 = 0;
V A_104 = default;
V B_105 = default;
V o_106 = default;
V u_107 = default;
V m_108 = default;
V ya_109 = default;
V yb_110 = default;
V mv_111 = default;
double dir_112 = 0;
V e_113 = default;
V x_114 = default;
V y_115 = default;
V r_116 = default;
double sx_117 = 0;
double sy_118 = 0;
V v_119 = default;
V ph_120 = default;
V O_102 = default;
if (_self92.IsNullish) _self92 = GlobalV;
{ V _t101 = _a97; if (_t101.IsUndef) _t101 = NewObj(0).V;
O_102 = _t101; }
if ((Lt(t_99, GetIdx(GetIdx(K_100, 0D), 0D)) || (!Get(O_102, "gone").IsNullish && Ge(t_99, Get(O_102, "gone"))))) {
return V.Null;
}
i_103 = 0D;
while (((i_103 < (ToNum(Get(K_100, "length")) - 1D)) && Ge(t_99, GetIdx(GetIdx(K_100, (i_103 + 1D)), 0D)))) {
i_103++;
}
A_104 = GetIdx(K_100, i_103);
B_105 = (GetIdx(K_100, (i_103 + 1D)) is var _t121 && Truthy(_t121) ? _t121 : A_104);
o_106 = Object_assign(NewObj(0).V, O_102, (GetIdx(A_104, 3D) is var _t122 && Truthy(_t122) ? _t122 : NewObj(0).V));
u_107 = (SEq(B_105, A_104) ? ((V)(1D)) : Call(cl_8, V.Undef, ((V)(((ToNum(t_99) - ToNum(GetIdx(A_104, 0D))) / (ToNum(GetIdx(B_105, 0D)) - ToNum(GetIdx(A_104, 0D))))))));
m_108 = (Get(o_106, "m") is var _t123 && Truthy(_t123) ? _t123 : ((V)("walk")));
ya_109 = (GetIdx(A_104, 2D).IsNullish ? (Get(O_102, "y") is var _t124 && !_t124.IsNullish ? _t124 : ((V)(150D))) : GetIdx(A_104, 2D));
yb_110 = (GetIdx(B_105, 2D).IsNullish ? (Get(O_102, "y") is var _t125 && !_t125.IsNullish ? _t125 : ((V)(150D))) : GetIdx(B_105, 2D));
mv_111 = (((System.Math.Abs((ToNum(GetIdx(B_105, 1D)) - ToNum(GetIdx(A_104, 1D)))) > 1D) && LtN(u_107, 1D)) ? V.True : V.False);
dir_112 = (Gt(GetIdx(B_105, 1D), GetIdx(A_104, 1D)) ? 1D : (-1D));
e_113 = ((SEqS(m_108, "walk") || SEqS(m_108, "run")) ? u_107 : Invoke(E_10, "io", u_107));
x_114 = Call(lerp_9, V.Undef, GetIdx(A_104, 1D), GetIdx(B_105, 1D), e_113);
y_115 = Call(lerp_9, V.Undef, ya_109, yb_110, e_113);
r_116 = (Get(o_106, "r") is var _t126 && Truthy(_t126) ? _t126 : ((V)(0D)));
sx_117 = 1D;
sy_118 = 1D;
v_119 = (Get(o_106, "v") is var _t129 && Truthy(_t129) ? _t129 : (Truthy((mv_111 is var _t128 && !Truthy(_t128) ? _t128 : (!SEqS(m_108, "still") ? V.True : V.False))) ? ((V)(((dir_112 > 0D) ? "right" : "left"))) : (Get(O_102, "f") is var _t127 && Truthy(_t127) ? _t127 : ((V)("front")))));
ph_120 = Add(((V)((ToNum(t_99) * (SEqS(m_108, "run") ? 19D : 10D)))), (Get(O_102, "ph") is var _t130 && Truthy(_t130) ? _t130 : ((V)(0D))));
if (Truthy((mv_111 is var _t131 && !Truthy(_t131) ? _t131 : (SEqS(m_108, "walk") ? V.True : V.False)))) {
y_115 = ((V)((ToNum(y_115) - (System.Math.Abs(FdLibm.Sin(ToNum(ph_120))) * 2.4))));
r_116 = Add(r_116, ((V)((FdLibm.Sin(ToNum(ph_120)) * 3D))));
} else {
if (Truthy((mv_111 is var _t132 && !Truthy(_t132) ? _t132 : (SEqS(m_108, "run") ? V.True : V.False)))) {
y_115 = ((V)((ToNum(y_115) - (System.Math.Abs(FdLibm.Sin(ToNum(ph_120))) * 5D))));
r_116 = Add(r_116, ((V)(((dir_112 * 8D) + (FdLibm.Sin(ToNum(ph_120)) * 2D)))));
} else {
if ((SEqS(m_108, "hop") && !SEq(B_105, A_104))) {
V h_133 = default;
double q_134 = 0;
h_133 = (Get(o_106, "h") is var _t135 && Truthy(_t135) ? _t135 : ((V)(14D)));
y_115 = ((V)((ToNum(y_115) - (FdLibm.Sin((System.Math.PI * ToNum(u_107))) * ToNum(h_133)))));
q_134 = (LtN(u_107, 0.12) ? (1D - (ToNum(u_107) / 0.12)) : (GtN(u_107, 0.88) ? ((ToNum(u_107) - 0.88) / 0.12) : 0D));
sx_117 = (1D + (0.08 * q_134));
sy_118 = (1D - (0.1 * q_134));
}
}
}
if (SEqS(m_108, "float")) {
y_115 = Add(y_115, ((V)((FdLibm.Sin(ToNum(Add(((V)((ToNum(t_99) * 2.4))), (Get(O_102, "ph") is var _t136 && Truthy(_t136) ? _t136 : ((V)(0D)))))) * 3D))));
r_116 = Add(r_116, ((V)(((FdLibm.Sin(ToNum(Add(((V)((ToNum(t_99) * 1.7))), (Get(O_102, "ph") is var _t137 && Truthy(_t137) ? _t137 : ((V)(0D)))))) * 3D) + (Truthy(mv_111) ? (dir_112 * 6D) : 0D)))));
} else {
if (!(Truthy(mv_111))) {
double b_138 = 0;
b_138 = FdLibm.Sin(ToNum(Add(((V)((ToNum(t_99) * 3D))), (Get(O_102, "ph") is var _t139 && Truthy(_t139) ? _t139 : ((V)(0D))))));
sy_118 = (sy_118 * (1D + (0.014 * b_138)));
sx_117 = (sx_117 * (1D - (0.01 * b_138)));
}
}
return NewObj(9).Put("x", x_114).Put("y", y_115).Put("v", v_119).Put("r", r_116).Put("sx", ((V)(sx_117))).Put("sy", ((V)(sy_118))).Put("k", Get(o_106, "k")).Put("o", Get(o_106, "o")).Put("gy", ((SEqS(m_108, "float") || SEqS(m_108, "hop")) ? (Get(o_106, "gy") is var _t141 && !_t141.IsNullish ? _t141 : (Get(O_102, "gy") is var _t140 && !_t140.IsNullish ? _t140 : ((V)(Max(ToNum(ya_109), ToNum(yb_110)))))) : V.Undef)).V;
return default;
}, 3, "go", false);
dance_24 = Fn((V _self142, int _argc143, V t_149, V x_150, V y_151, V st_152, V[] _rest144) => {
V b_157 = default;
double n_158 = 0;
double f_159 = 0;
double hp_160 = 0;
double sq_161 = 0;
double s_162 = 0;
V B_154 = default;
V ph_156 = default;
if (_self142.IsNullish) _self142 = GlobalV;
{ V _t153 = (_argc143 > 4 ? _rest144[0] : V.Undef); if (_t153.IsUndef) _t153 = ((V)(0.5));
B_154 = _t153; }
{ V _t155 = (_argc143 > 5 ? _rest144[1] : V.Undef); if (_t155.IsUndef) _t155 = ((V)(0D));
ph_156 = _t155; }
b_157 = Add(((V)((ToNum(t_149) / ToNum(B_154)))), ph_156);
n_158 = System.Math.Floor(ToNum(b_157));
f_159 = (ToNum(b_157) - n_158);
hp_160 = FdLibm.Sin((System.Math.PI * f_159));
sq_161 = FdLibm.Exp(((-f_159) * 8D));
s_162 = (NumTruthy((n_158 % 2D)) ? 1D : (-1D));
{
V _sw163 = st_152; int _c164 = -1;
if (SEq(_sw163, ((V)("sway")))) _c164 = 0;
else if (SEq(_sw163, ((V)("spin")))) _c164 = 1;
else if (SEq(_sw163, ((V)("shuffle")))) _c164 = 2;
else if (SEq(_sw163, ((V)("twirl")))) _c164 = 3;
else if (SEq(_sw163, ((V)("jump")))) _c164 = 4;
else if (SEq(_sw163, ((V)("wave")))) _c164 = 5;
if (_c164 < 0) _c164 = 6;
switch (_c164) {
case 0: {

return NewObj(6).Put("x", Add(x_150, ((V)((FdLibm.Sin(((ToNum(b_157) * System.Math.PI) / 2D)) * 6D))))).Put("y", ((V)((ToNum(y_151) - (hp_160 * 2D))))).Put("v", ((V)("front"))).Put("r", ((V)((FdLibm.Sin(((ToNum(b_157) * System.Math.PI) / 2D)) * 10D)))).Put("sx", ((V)((1D + (0.05 * sq_161))))).Put("sy", ((V)((1D - (0.05 * sq_161))))).V;
}
goto case 1;
case 1: {

return NewObj(6).Put("x", x_150).Put("y", ((V)((ToNum(y_151) - (hp_160 * 10D))))).Put("v", GetIdx(SPIN_20, (n_158 % 4D))).Put("r", ((V)(0D))).Put("sx", ((V)((1D + (0.06 * sq_161))))).Put("sy", ((V)((1D - (0.07 * sq_161))))).V;
}
goto case 2;
case 2: {

{
double q_165 = 0;
q_165 = (NumTruthy((System.Math.Floor((n_158 / 2D)) % 2D)) ? 1D : (-1D));
return NewObj(4).Put("x", Add(x_150, ((V)(((q_165 * 10D) * FdLibm.Sin((System.Math.PI * ((ToNum(b_157) / 2D) % 1D)))))))).Put("y", ((V)((ToNum(y_151) - (hp_160 * 3D))))).Put("v", ((V)(((q_165 > 0D) ? "right" : "left")))).Put("r", ((V)((q_165 * 5D)))).V;
}
}
goto case 3;
case 3: {

return NewObj(4).Put("x", x_150).Put("y", ((V)((ToNum(y_151) - (hp_160 * 4D))))).Put("v", GetIdx(SPIN_20, (System.Math.Floor((ToNum(b_157) * 2D)) % 4D))).Put("r", ((V)((FdLibm.Sin((ToNum(b_157) * System.Math.PI)) * 6D)))).V;
}
goto case 4;
case 4: {

return NewObj(6).Put("x", x_150).Put("y", ((V)((ToNum(y_151) - (NumTruthy((n_158 % 2D)) ? (hp_160 * 20D) : (hp_160 * 4D)))))).Put("v", ((V)("front"))).Put("r", ((V)((NumTruthy((n_158 % 2D)) ? ((s_162 * 10D) * hp_160) : 0D)))).Put("sx", ((V)((1D + (0.1 * sq_161))))).Put("sy", ((V)((1D - (0.12 * sq_161))))).V;
}
goto case 5;
case 5: {

return NewObj(4).Put("x", Add(x_150, ((V)((FdLibm.Sin((ToNum(b_157) * System.Math.PI)) * 3D))))).Put("y", ((V)((ToNum(y_151) - (System.Math.Abs(FdLibm.Sin((ToNum(b_157) * System.Math.PI))) * 6D))))).Put("v", ((V)("front"))).Put("r", ((V)((FdLibm.Sin((ToNum(b_157) * System.Math.PI)) * 14D)))).V;
}
goto case 6;
case 6: {

return NewObj(6).Put("x", x_150).Put("y", ((V)((ToNum(y_151) - (hp_160 * 8D))))).Put("v", ((V)("front"))).Put("r", ((V)(((s_162 * 4D) * hp_160)))).Put("sx", ((V)((1D + (0.08 * sq_161))))).Put("sy", ((V)((1D - (0.09 * sq_161))))).V;
}
break;
}
}
return default;
}, 6, "dance", false);
bub_25 = Fn((V _self166, int _argc167, V p_173, V _a170, V _a171, V _a172, V[] _rest168) => {
V b_176 = default;
V tl_177 = default;
V cur_178 = default;
V z_175 = default;
if (_self166.IsNullish) _self166 = GlobalV;
{ V _t174 = _a170; if (_t174.IsUndef) _t174 = ((V)(30D));
z_175 = _t174; }
b_176 = Call(D_15, V.Undef, p_173, ((V)(JsStrBuf.Begin().S("left:0;top:0;display:none;max-width:168px;padding:4px 8px;border-radius:10px;background:#fffdf6;border:1.5px solid #2a1d3a;font-family:'Fredoka',sans-serif;font-weight:600;font-size:9.5px;line-height:1.2;color:#2a1d3a;text-align:center;white-space:nowrap;z-index:").V(z_175).S(";transform-origin:50% 100%;").End())));
tl_177 = Call(D_15, V.Undef, b_176, ((V)("left:50%;bottom:-6px;width:8px;height:8px;margin-left:-4px;background:#fffdf6;border-right:1.5px solid #2a1d3a;border-bottom:1.5px solid #2a1d3a;transform:rotate(45deg);")));
cur_178 = V.Null;
return Fn((V _arrowThis190, int _argc179, V tx_185, V x_186, V y_187, V _a184, V[] _rest180) => {
V w_191 = default;
V h_192 = default;
V xx_193 = default;
V o_189 = default;
{ V _t188 = _a184; if (_t188.IsUndef) _t188 = ((V)(1D));
o_189 = _t188; }
if ((!(Truthy(tx_185)) || LeN(o_189, 0.01))) {
Call(show_16, V.Undef, b_176, (false ? V.True : V.False));
return default;
}
if (!SEq(cur_178, tx_185)) {
cur_178 = tx_185;
Set(Get(b_176, "style"), "whiteSpace", ((V)((GtN(Get(tx_185, "length"), 30D) ? "normal" : "nowrap"))));
Set(Get(b_176, "style"), "width", ((V)((GtN(Get(tx_185, "length"), 30D) ? "150px" : ""))));
if (SEqN(Get(Get(b_176, "firstChild"), "nodeType"), 3D)) {
Set(Get(b_176, "firstChild"), "nodeValue", tx_185);
} else {
Invoke(b_176, "insertBefore", Invoke(G("document"), "createTextNode", tx_185), tl_177);
}
}
Call(show_16, V.Undef, b_176, (true ? V.True : V.False));
w_191 = (Get(b_176, "offsetWidth") is var _t194 && Truthy(_t194) ? _t194 : ((V)(60D)));
h_192 = (Get(b_176, "offsetHeight") is var _t195 && Truthy(_t195) ? _t195 : ((V)(18D)));
xx_193 = Call(cl_8, V.Undef, x_186, ((V)(((ToNum(w_191) / 2D) + 4D))), ((V)((316D - (ToNum(w_191) / 2D)))));
Set(Get(tl_177, "style"), "left", ((V)(JsStrBuf.Begin().N((50D + (((ToNum(x_186) - ToNum(xx_193)) / ToNum(w_191)) * 100D))).S("%").End())));
Set(Get(b_176, "style"), "opacity", Invoke(o_189, "toFixed", ((V)(3D))));
Set(Get(b_176, "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").V(Invoke(((V)((ToNum(xx_193) - (ToNum(w_191) / 2D)))), "toFixed", ((V)(1D)))).S("px,").V(Invoke(((V)(((ToNum(y_187) - ToNum(h_192)) - 7D))), "toFixed", ((V)(1D)))).S("px) scale(").V(Invoke(((V)((0.6 + (0.4 * Min(1D, (ToNum(o_189) * 1.6)))))), "toFixed", ((V)(3D)))).S(")").End())));
return default;
}, 4, "", true);
return default;
}, 2, "bub", false);
parts_27 = Fn((V _self196, int _argc197, V p_203, V n_204, V css_205, V html_206, V[] _rest198) => {
V N_208 = default;
V f_207 = default;
if (_self196.IsNullish) _self196 = GlobalV;
f_207 = (_argc197 > 4 ? _rest198[0] : V.Undef);
N_208 = Array_from(NewObj(1).Put("length", n_204).V, Fn((V _arrowThis215, int _argc209, V _a211, V _a212, V _a213, V _a214, V[] _rest210) => {
return Call(D_15, V.Undef, p_203, ((V)(JsStrBuf.Begin().S("left:0;top:0;display:none;").V(css_205).End())), html_206);
}, 0, "", true));
return Fn((V _arrowThis223, int _argc216, V t_222, V _a219, V _a220, V _a221, V[] _rest217) => {
return Invoke(N_208, "forEach", Fn((V _arrowThis232, int _argc224, V m_230, V i_231, V _a228, V _a229, V[] _rest225) => {
V s_233 = default;
s_233 = Call(f_207, V.Undef, i_231, t_222);
if (!(Truthy(s_233))) {
Call(show_16, V.Undef, m_230, (false ? V.True : V.False));
} else {
Call(put_17, V.Undef, m_230, Get(s_233, "x"), Get(s_233, "y"), (Get(s_233, "k") is var _t234 && Truthy(_t234) ? _t234 : ((V)(1D))), (Get(s_233, "r") is var _t235 && Truthy(_t235) ? _t235 : ((V)(0D))), (Get(s_233, "o").IsNullish ? ((V)(1D)) : Get(s_233, "o")));
}
return default;
}, 2, "", true));
}, 1, "", true);
return default;
}, 5, "parts", false);
stars_28 = Fn((V _self236, int _argc237, V p_243, V n_244, V w_245, V h_246, V[] _rest238) => {
V r_252 = default;
V sh_253 = default;
V seed_247 = default;
V col_249 = default;
V sz_251 = default;
if (_self236.IsNullish) _self236 = GlobalV;
seed_247 = (_argc237 > 4 ? _rest238[0] : V.Undef);
{ V _t248 = (_argc237 > 5 ? _rest238[1] : V.Undef); if (_t248.IsUndef) _t248 = ((V)("#ffffff"));
col_249 = _t248; }
{ V _t250 = (_argc237 > 6 ? _rest238[2] : V.Undef); if (_t250.IsUndef) _t250 = ((V)(1.2));
sz_251 = _t250; }
r_252 = Call(rnd_18, V.Undef, seed_247);
sh_253 = Invoke(Array_from(NewObj(1).Put("length", n_244).V, Fn((V _arrowThis260, int _argc254, V _a256, V _a257, V _a258, V _a259, V[] _rest255) => {
return ((V)(JsStrBuf.Begin().V(Invoke(((V)((ToNum(Call(r_252, V.Undef)) * ToNum(w_245)))), "toFixed", ((V)(0D)))).S("px ").V(Invoke(((V)((ToNum(Call(r_252, V.Undef)) * ToNum(h_246)))), "toFixed", ((V)(0D)))).S("px 0 ").V(Invoke(((V)((LtN(Call(r_252, V.Undef), 0.15) ? (ToNum(sz_251) * 0.6) : 0D))), "toFixed", ((V)(1D)))).S("px ").V(col_249).End()));
}, 0, "", true)), "join", ((V)(",")));
return Call(D_15, V.Undef, p_243, ((V)(JsStrBuf.Begin().S("left:0;top:0;width:").V(sz_251).S("px;height:").V(sz_251).S("px;border-radius:50%;box-shadow:").V(sh_253).S(";").End())));
return default;
}, 7, "stars", false);
rain_29 = Fn((V _self261, int _argc262, V p_268, V n_269, V seed_270, V _a267, V[] _rest263) => {
V r_273 = default;
V q_274 = default;
V col_272 = default;
if (_self261.IsNullish) _self261 = GlobalV;
{ V _t271 = _a267; if (_t271.IsUndef) _t271 = ((V)("rgba(200,220,255,0.5)"));
col_272 = _t271; }
r_273 = Call(rnd_18, V.Undef, seed_270);
q_274 = Array_from(NewObj(1).Put("length", n_269).V, Fn((V _arrowThis281, int _argc275, V _a277, V _a278, V _a279, V _a280, V[] _rest276) => {
return Arr(((V)((ToNum(Call(r_273, V.Undef)) * 360D))), Call(r_273, V.Undef), ((V)((0.7 + (ToNum(Call(r_273, V.Undef)) * 0.6)))));
}, 0, "", true));
return Call(parts_27, V.Undef, p_268, n_269, ((V)(JsStrBuf.Begin().S("width:1px;height:10px;background:").V(col_272).S(";").End())), V.Null, Fn((V _arrowThis290, int _argc282, V i_288, V t_289, V _a286, V _a287, V[] _rest283) => {
V x_291 = default;
V o_292 = default;
V s_293 = default;
double y_294 = 0;
{ V _t295 = GetK(q_274, i_288);
{ V _t296 = ListOf(_t295);
{ V _t297 = GetIdx(_t296, 0D);
x_291 = _t297; }
{ V _t298 = GetIdx(_t296, 1D);
o_292 = _t298; }
{ V _t299 = GetIdx(_t296, 2D);
s_293 = _t299; }
} }
y_294 = (((((ToNum(t_289) * 260D) * ToNum(s_293)) + (ToNum(o_292) * 220D)) % 220D) - 20D);
return NewObj(3).Put("x", ((V)(((ToNum(x_291) - (y_294 * 0.25)) % 330D)))).Put("y", ((V)(y_294))).Put("r", ((V)(14D))).V;
return default;
}, 2, "", true));
return default;
}, 4, "rain", false);
film_32 = Fn((V _self300, int _argc301, V S_307, V _a304, V _a305, V _a306, V[] _rest302) => {
V root_310 = default;
V blk_311 = default;
V upd_312 = default;
V o_309 = default;
if (_self300.IsNullish) _self300 = GlobalV;
{ V _t308 = _a304; if (_t308.IsUndef) _t308 = NewObj(0).V;
o_309 = _t308; }
upd_312 = Fn((V _self313, int _argc314, V t_320, V _a317, V _a318, V _a319, V[] _rest315) => {
V act_321 = default;
V r_322 = default;
if (_self313.IsNullish) _self313 = GlobalV;
act_321 = V.Null;
Invoke(S_307, "forEach", Fn((V _arrowThis330, int _argc323, V s_329, V _a326, V _a327, V _a328, V[] _rest324) => {
V on_331 = default;
on_331 = ((Ge(t_320, Get(s_329, "a")) && Lt(t_320, Get(s_329, "b"))) ? V.True : V.False);
if (Truthy((on_331 is var _t332 && !Truthy(_t332) ? _t332 : (!(Truthy(Get(s_329, "L"))) ? V.True : V.False)))) {
Set(s_329, "L", Call(D_15, V.Undef, root_310, ((V)("inset:0;overflow:hidden;"))));
Set(s_329, "u", (Invoke(s_329, "mk", Get(s_329, "L")) is var _t340 && Truthy(_t340) ? _t340 : Fn((V _arrowThis339, int _argc333, V _a335, V _a336, V _a337, V _a338, V[] _rest334) => {

return default;
}, 0, "", true)));
}
if (Truthy(Get(s_329, "L"))) {
Call(show_16, V.Undef, Get(s_329, "L"), on_331);
}
if (Truthy(on_331)) {
act_321 = s_329;
}
return default;
}, 1, "", true));
if (Truthy(act_321)) {
V f_341 = default;
double d_342 = 0;
Invoke(act_321, "u", ((V)((ToNum(t_320) - ToNum(Get(act_321, "a"))))), t_320);
f_341 = (Get(act_321, "fade") is var _t343 && !_t343.IsNullish ? _t343 : ((V)(0.4)));
d_342 = Min(((ToNum(t_320) - ToNum(Get(act_321, "a"))) + (SEq(Get(act_321, "inF"), (false ? V.True : V.False)) ? 9D : 0D)), ((ToNum(Get(act_321, "b")) - ToNum(t_320)) + (SEq(Get(act_321, "outF"), (false ? V.True : V.False)) ? 9D : 0D)));
Set(Get(blk_311, "style"), "opacity", Invoke(((V)((GtN(f_341, 0D) ? (1D - ToNum(Call(cl_8, V.Undef, ((V)((d_342 / ToNum(f_341))))))) : 0D))), "toFixed", ((V)(3D))));
} else {
Set(Get(blk_311, "style"), "opacity", ((V)("1")));
}
r_322 = (Truthy((act_321 is var _t344 && !Truthy(_t344) ? _t344 : Get(act_321, "lit"))) ? Invoke(act_321, "lit", ((V)((ToNum(t_320) - ToNum(Get(act_321, "a")))))) : V.Null);
return NewObj(2).Put("rgb", (((act_321 is var _t345 && !Truthy(_t345) ? _t345 : Get(act_321, "rgb")) is var _t346 && Truthy(_t346) ? _t346 : Get(o_309, "rgb")) is var _t347 && Truthy(_t347) ? _t347 : ((V)("200,210,255")))).Put("lit", ((V)((ToNum((r_322.IsNullish ? ((V)(0.8)) : r_322)) * (1D - ToNum(Get(Get(blk_311, "style"), "opacity"))))))).V;
return default;
}, 1, "upd", false);
root_310 = Call(el_14, V.Undef, ((V)("div")), ((V)(JsStrBuf.Begin().S("position:absolute;left:0;top:0;width:320px;height:180px;overflow:hidden;background:").V((Get(o_309, "bg") is var _t348 && Truthy(_t348) ? _t348 : ((V)("#000")))).S(";font-family:'Fredoka',sans-serif;font-weight:600;").End())));
blk_311 = Call(D_15, V.Undef, root_310, ((V)("inset:0;background:#000;opacity:0;z-index:90;pointer-events:none;")));
Invoke(S_307, "forEach", Fn((V _arrowThis356, int _argc349, V s_355, V _a352, V _a353, V _a354, V[] _rest350) => {
Set(s_355, "L", V.Null);
Set(s_355, "u", V.Null);
return default;
}, 1, "", true));
return NewObj(2).Put("root", root_310).Put("upd", upd_312).V;
return default;
}, 2, "film", false);
snd_34 = Fn((V _self357, int _argc358, V Q_364, V _a361, V _a362, V _a363, V[] _rest359) => {
V I_365 = default;
if (_self357.IsNullish) _self357 = GlobalV;
I_365 = NewObj(36).Put("tone", Fn((V _arrowThis376, int _argc366, V t_372, V f_373, V d_374, V o_375, V[] _rest367) => {
return Invoke(Q_364, "tone", t_372, f_373, d_374, o_375);
}, 4, "tone", true)).Put("noise", Fn((V _arrowThis386, int _argc377, V t_383, V d_384, V o_385, V _a382, V[] _rest378) => {
return Invoke(Q_364, "noise", t_383, d_384, o_385);
}, 3, "noise", true)).Put("pluck", Fn((V _arrowThis399, int _argc387, V t_393, V m_394, V _a391, V _a392, V[] _rest388) => {
V d_396 = default;
V v_398 = default;
{ V _t395 = _a391; if (_t395.IsUndef) _t395 = ((V)(0.25));
d_396 = _t395; }
{ V _t397 = _a392; if (_t397.IsUndef) _t397 = ((V)(0.08));
v_398 = _t397; }
Invoke(Q_364, "tone", t_393, Call(mtof_33, V.Undef, m_394), d_396, NewObj(3).Put("type", ((V)("triangle"))).Put("vol", v_398).Put("at", ((V)(0.003))).V);
Invoke(Q_364, "tone", t_393, ((V)((ToNum(Call(mtof_33, V.Undef, m_394)) * 2D))), ((V)((ToNum(d_396) * 0.4))), NewObj(2).Put("vol", ((V)((ToNum(v_398) * 0.2)))).Put("at", ((V)(0.002))).V);
return default;
}, 4, "pluck", true)).Put("piano", Fn((V _arrowThis412, int _argc400, V t_406, V m_407, V _a404, V _a405, V[] _rest401) => {
V d_409 = default;
V v_411 = default;
{ V _t408 = _a404; if (_t408.IsUndef) _t408 = ((V)(0.5));
d_409 = _t408; }
{ V _t410 = _a405; if (_t410.IsUndef) _t410 = ((V)(0.08));
v_411 = _t410; }
Invoke(Q_364, "tone", t_406, Call(mtof_33, V.Undef, m_407), d_409, NewObj(3).Put("type", ((V)("triangle"))).Put("vol", v_411).Put("at", ((V)(0.003))).V);
Invoke(Q_364, "tone", t_406, ((V)((ToNum(Call(mtof_33, V.Undef, m_407)) * 1.003))), ((V)((ToNum(d_409) * 0.8))), NewObj(2).Put("vol", ((V)((ToNum(v_411) * 0.5)))).Put("at", ((V)(0.003))).V);
return default;
}, 4, "piano", true)).Put("pad", Fn((V _arrowThis428, int _argc413, V t_419, V ms_420, V d_421, V _a418, V[] _rest414) => {
V v_423 = default;
V ty_425 = default;
V lp_427 = default;
{ V _t422 = _a418; if (_t422.IsUndef) _t422 = ((V)(0.03));
v_423 = _t422; }
{ V _t424 = (_argc413 > 4 ? _rest414[0] : V.Undef); if (_t424.IsUndef) _t424 = ((V)("sawtooth"));
ty_425 = _t424; }
{ V _t426 = (_argc413 > 5 ? _rest414[1] : V.Undef); if (_t426.IsUndef) _t426 = ((V)(900D));
lp_427 = _t426; }
return Invoke(ms_420, "forEach", Fn((V _arrowThis437, int _argc429, V m_435, V i_436, V _a433, V _a434, V[] _rest430) => {
return Invoke(Q_364, "tone", t_419, ((V)((ToNum(Call(mtof_33, V.Undef, m_435)) * (1D + (NumTruthy((ToNum(i_436) % 2D)) ? 0.003 : (-0.003)))))), d_421, NewObj(6).Put("type", ty_425).Put("lp", lp_427).Put("vol", v_423).Put("at", ((V)(Min(0.6, (ToNum(d_421) * 0.3))))).Put("sus", ((V)(1D))).Put("vib", Arr(((V)(4.5)), ((V)(1.5)))).V);
}, 2, "", true));
}, 6, "pad", true)).Put("str", Fn((V _arrowThis449, int _argc438, V t_444, V m_445, V d_446, V _a443, V[] _rest439) => {
V v_448 = default;
{ V _t447 = _a443; if (_t447.IsUndef) _t447 = ((V)(0.05));
v_448 = _t447; }
return Invoke(Q_364, "tone", t_444, Call(mtof_33, V.Undef, m_445), d_446, NewObj(6).Put("type", ((V)("sawtooth"))).Put("lp", ((V)(1700D))).Put("vol", v_448).Put("at", ((V)(Min(0.25, (ToNum(d_446) * 0.3))))).Put("sus", ((V)(1D))).Put("vib", Arr(((V)(5.5)), ((V)((ToNum(Call(mtof_33, V.Undef, m_445)) * 0.006))))).V);
}, 4, "str", true)).Put("brass", Fn((V _arrowThis461, int _argc450, V t_456, V m_457, V d_458, V _a455, V[] _rest451) => {
V v_460 = default;
{ V _t459 = _a455; if (_t459.IsUndef) _t459 = ((V)(0.06));
v_460 = _t459; }
return Invoke(Q_364, "tone", t_456, Call(mtof_33, V.Undef, m_457), d_458, NewObj(6).Put("type", ((V)("square"))).Put("lp", ((V)(1300D))).Put("vol", v_460).Put("at", ((V)(0.04))).Put("sus", ((V)(1D))).Put("vib", Arr(((V)(5D)), ((V)((ToNum(Call(mtof_33, V.Undef, m_457)) * 0.004))))).V);
}, 4, "brass", true)).Put("lead", Fn((V _arrowThis473, int _argc462, V t_468, V m_469, V d_470, V _a467, V[] _rest463) => {
V v_472 = default;
{ V _t471 = _a467; if (_t471.IsUndef) _t471 = ((V)(0.07));
v_472 = _t471; }
Invoke(Q_364, "tone", t_468, Call(mtof_33, V.Undef, m_469), d_470, NewObj(6).Put("type", ((V)("square"))).Put("lp", ((V)(2400D))).Put("vol", v_472).Put("at", ((V)(0.01))).Put("sus", ((V)(1D))).Put("vib", Arr(((V)(5.5)), ((V)((ToNum(Call(mtof_33, V.Undef, m_469)) * 0.005))))).V);
Invoke(Q_364, "tone", t_468, Call(mtof_33, V.Undef, Add(m_469, ((V)(12D)))), ((V)((ToNum(d_470) * 0.8))), NewObj(3).Put("type", ((V)("triangle"))).Put("vol", ((V)((ToNum(v_472) * 0.3)))).Put("at", ((V)(0.01))).V);
return default;
}, 4, "lead", true)).Put("voice", Fn((V _arrowThis485, int _argc474, V t_480, V m_481, V d_482, V _a479, V[] _rest475) => {
V v_484 = default;
{ V _t483 = _a479; if (_t483.IsUndef) _t483 = ((V)(0.07));
v_484 = _t483; }
Invoke(Q_364, "tone", t_480, Call(mtof_33, V.Undef, m_481), d_482, NewObj(6).Put("type", ((V)("triangle"))).Put("lp", ((V)(2000D))).Put("vol", v_484).Put("at", ((V)(0.04))).Put("sus", ((V)(1D))).Put("vib", Arr(((V)(5.8)), ((V)((ToNum(Call(mtof_33, V.Undef, m_481)) * 0.012))))).V);
Invoke(Q_364, "tone", t_480, ((V)((ToNum(Call(mtof_33, V.Undef, m_481)) * 2.01))), d_482, NewObj(3).Put("vol", ((V)((ToNum(v_484) * 0.25)))).Put("at", ((V)(0.05))).Put("sus", ((V)(1D))).V);
return default;
}, 4, "voice", true)).Put("theremin", Fn((V _arrowThis498, int _argc486, V t_492, V f0_493, V f1_494, V d_495, V[] _rest487) => {
V v_497 = default;
{ V _t496 = (_argc486 > 4 ? _rest487[0] : V.Undef); if (_t496.IsUndef) _t496 = ((V)(0.06));
v_497 = _t496; }
return Invoke(Q_364, "tone", t_492, f0_493, d_495, NewObj(6).Put("to", f1_494).Put("slide", d_495).Put("vol", v_497).Put("at", ((V)(0.15))).Put("sus", ((V)(1D))).Put("vib", Arr(((V)(6D)), ((V)((ToNum(f0_493) * 0.02))))).V);
}, 5, "theremin", true)).Put("bell", Fn((V _arrowThis511, int _argc499, V t_505, V m_506, V _a503, V _a504, V[] _rest500) => {
V d_508 = default;
V v_510 = default;
{ V _t507 = _a503; if (_t507.IsUndef) _t507 = ((V)(0.8));
d_508 = _t507; }
{ V _t509 = _a504; if (_t509.IsUndef) _t509 = ((V)(0.07));
v_510 = _t509; }
Invoke(Q_364, "tone", t_505, Call(mtof_33, V.Undef, m_506), d_508, NewObj(1).Put("vol", v_510).V);
Invoke(Q_364, "tone", t_505, ((V)((ToNum(Call(mtof_33, V.Undef, m_506)) * 2.76))), ((V)((ToNum(d_508) * 0.4))), NewObj(1).Put("vol", ((V)((ToNum(v_510) * 0.25)))).V);
return default;
}, 4, "bell", true)).Put("bass", Fn((V _arrowThis524, int _argc512, V t_518, V m_519, V _a516, V _a517, V[] _rest513) => {
V d_521 = default;
V v_523 = default;
{ V _t520 = _a516; if (_t520.IsUndef) _t520 = ((V)(0.25));
d_521 = _t520; }
{ V _t522 = _a517; if (_t522.IsUndef) _t522 = ((V)(0.16));
v_523 = _t522; }
return Invoke(Q_364, "tone", t_518, Call(mtof_33, V.Undef, m_519), d_521, NewObj(4).Put("type", ((V)("sawtooth"))).Put("lp", ((V)(480D))).Put("vol", v_523).Put("at", ((V)(0.008))).V);
}, 4, "bass", true)).Put("sub", Fn((V _arrowThis537, int _argc525, V t_531, V m_532, V _a529, V _a530, V[] _rest526) => {
V d_534 = default;
V v_536 = default;
{ V _t533 = _a529; if (_t533.IsUndef) _t533 = ((V)(0.5));
d_534 = _t533; }
{ V _t535 = _a530; if (_t535.IsUndef) _t535 = ((V)(0.2));
v_536 = _t535; }
return Invoke(Q_364, "tone", t_531, Call(mtof_33, V.Undef, m_532), d_534, NewObj(2).Put("vol", v_536).Put("at", ((V)(0.01))).V);
}, 4, "sub", true)).Put("kick", Fn((V _arrowThis547, int _argc538, V t_544, V _a541, V _a542, V _a543, V[] _rest539) => {
V v_546 = default;
{ V _t545 = _a541; if (_t545.IsUndef) _t545 = ((V)(0.7));
v_546 = _t545; }
return Invoke(Q_364, "tone", t_544, ((V)(150D)), ((V)(0.3)), NewObj(4).Put("to", ((V)(42D))).Put("slide", ((V)(0.12))).Put("vol", v_546).Put("at", ((V)(0.002))).V);
}, 2, "kick", true)).Put("snare", Fn((V _arrowThis557, int _argc548, V t_554, V _a551, V _a552, V _a553, V[] _rest549) => {
V v_556 = default;
{ V _t555 = _a551; if (_t555.IsUndef) _t555 = ((V)(0.25));
v_556 = _t555; }
Invoke(Q_364, "noise", t_554, ((V)(0.15)), NewObj(4).Put("ft", ((V)("bandpass"))).Put("f", ((V)(1800D))).Put("q", ((V)(0.8))).Put("vol", v_556).V);
Invoke(Q_364, "tone", t_554, ((V)(220D)), ((V)(0.08)), NewObj(3).Put("to", ((V)(160D))).Put("vol", ((V)((ToNum(v_556) * 0.5)))).Put("type", ((V)("triangle"))).V);
return default;
}, 2, "snare", true)).Put("hat", Fn((V _arrowThis567, int _argc558, V t_564, V _a561, V _a562, V _a563, V[] _rest559) => {
V v_566 = default;
{ V _t565 = _a561; if (_t565.IsUndef) _t565 = ((V)(0.05));
v_566 = _t565; }
return Invoke(Q_364, "noise", t_564, ((V)(0.04)), NewObj(2).Put("f", ((V)(7500D))).Put("vol", v_566).V);
}, 2, "hat", true)).Put("clap", Fn((V _arrowThis577, int _argc568, V t_574, V _a571, V _a572, V _a573, V[] _rest569) => {
V v_576 = default;
{ V _t575 = _a571; if (_t575.IsUndef) _t575 = ((V)(0.2));
v_576 = _t575; }
return Invoke(Arr(((V)(0D)), ((V)(0.012)), ((V)(0.024))), "forEach", Fn((V _arrowThis585, int _argc578, V d_584, V _a581, V _a582, V _a583, V[] _rest579) => {
return Invoke(Q_364, "noise", Add(t_574, d_584), ((V)(0.06)), NewObj(4).Put("ft", ((V)("bandpass"))).Put("f", ((V)(1400D))).Put("q", ((V)(1.2))).Put("vol", v_576).V);
}, 1, "", true));
}, 2, "clap", true)).Put("crash", Fn((V _arrowThis595, int _argc586, V t_592, V _a589, V _a590, V _a591, V[] _rest587) => {
V v_594 = default;
{ V _t593 = _a589; if (_t593.IsUndef) _t593 = ((V)(0.13));
v_594 = _t593; }
return Invoke(Q_364, "noise", t_592, ((V)(1.4)), NewObj(2).Put("f", ((V)(4200D))).Put("vol", v_594).V);
}, 2, "crash", true)).Put("timp", Fn((V _arrowThis605, int _argc596, V t_602, V _a599, V _a600, V _a601, V[] _rest597) => {
V v_604 = default;
{ V _t603 = _a599; if (_t603.IsUndef) _t603 = ((V)(0.4));
v_604 = _t603; }
return Invoke(Q_364, "tone", t_602, ((V)(90D)), ((V)(0.9)), NewObj(4).Put("to", ((V)(70D))).Put("slide", ((V)(0.6))).Put("vol", v_604).Put("at", ((V)(0.004))).V);
}, 2, "timp", true)).Put("boom", Fn((V _arrowThis615, int _argc606, V t_612, V _a609, V _a610, V _a611, V[] _rest607) => {
V v_614 = default;
{ V _t613 = _a609; if (_t613.IsUndef) _t613 = ((V)(0.5));
v_614 = _t613; }
Invoke(Q_364, "tone", t_612, ((V)(70D)), ((V)(1.2)), NewObj(4).Put("to", ((V)(30D))).Put("slide", ((V)(1D))).Put("vol", v_614).Put("at", ((V)(0.01))).V);
Invoke(Q_364, "noise", t_612, ((V)(1D)), NewObj(4).Put("ft", ((V)("lowpass"))).Put("f", ((V)(600D))).Put("fTo", ((V)(80D))).Put("vol", ((V)((ToNum(v_614) * 0.5)))).V);
return default;
}, 2, "boom", true)).Put("thunder", Fn((V _arrowThis625, int _argc616, V t_622, V _a619, V _a620, V _a621, V[] _rest617) => {
V v_624 = default;
{ V _t623 = _a619; if (_t623.IsUndef) _t623 = ((V)(0.35));
v_624 = _t623; }
Invoke(Q_364, "noise", t_622, ((V)(2.2)), NewObj(5).Put("ft", ((V)("lowpass"))).Put("f", ((V)(900D))).Put("fTo", ((V)(90D))).Put("vol", v_624).Put("at", ((V)(0.02))).V);
Invoke(Q_364, "noise", Add(t_622, ((V)(0.05))), ((V)(0.25)), NewObj(3).Put("ft", ((V)("bandpass"))).Put("f", ((V)(2400D))).Put("vol", ((V)((ToNum(v_624) * 0.5)))).V);
return default;
}, 2, "thunder", true)).Put("whoosh", Fn((V _arrowThis637, int _argc626, V t_632, V _a629, V _a630, V _a631, V[] _rest627) => {
V d_634 = default;
V v_636 = default;
{ V _t633 = _a629; if (_t633.IsUndef) _t633 = ((V)(0.5));
d_634 = _t633; }
{ V _t635 = _a630; if (_t635.IsUndef) _t635 = ((V)(0.08));
v_636 = _t635; }
return Invoke(Q_364, "noise", t_632, d_634, NewObj(6).Put("ft", ((V)("bandpass"))).Put("f", ((V)(600D))).Put("fTo", ((V)(3000D))).Put("q", ((V)(1.1))).Put("vol", v_636).Put("at", ((V)((ToNum(d_634) * 0.45)))).V);
}, 3, "whoosh", true)).Put("poof", Fn((V _arrowThis647, int _argc638, V t_644, V _a641, V _a642, V _a643, V[] _rest639) => {
V v_646 = default;
{ V _t645 = _a641; if (_t645.IsUndef) _t645 = ((V)(0.2));
v_646 = _t645; }
Invoke(Q_364, "noise", t_644, ((V)(0.5)), NewObj(5).Put("ft", ((V)("lowpass"))).Put("f", ((V)(3000D))).Put("fTo", ((V)(300D))).Put("vol", v_646).Put("at", ((V)(0.01))).V);
Invoke(Q_364, "tone", t_644, ((V)(300D)), ((V)(0.3)), NewObj(4).Put("to", ((V)(900D))).Put("slide", ((V)(0.2))).Put("vol", ((V)((ToNum(v_646) * 0.3)))).Put("type", ((V)("triangle"))).V);
return default;
}, 2, "poof", true)).Put("sparkle", Fn((V _arrowThis659, int _argc648, V t_654, V _a651, V _a652, V _a653, V[] _rest649) => {
V m_656 = default;
V v_658 = default;
{ V _t655 = _a651; if (_t655.IsUndef) _t655 = ((V)(84D));
m_656 = _t655; }
{ V _t657 = _a652; if (_t657.IsUndef) _t657 = ((V)(0.04));
v_658 = _t657; }
return Invoke(Arr(((V)(0D)), ((V)(4D)), ((V)(7D)), ((V)(12D)), ((V)(16D))), "forEach", Fn((V _arrowThis668, int _argc660, V d_666, V i_667, V _a664, V _a665, V[] _rest661) => {
return Invoke(I_365, "bell", Add(t_654, ((V)((ToNum(i_667) * 0.05)))), Add(m_656, d_666), ((V)(0.5)), v_658);
}, 2, "", true));
}, 3, "sparkle", true)).Put("zap", Fn((V _arrowThis678, int _argc669, V t_675, V _a672, V _a673, V _a674, V[] _rest670) => {
V v_677 = default;
{ V _t676 = _a672; if (_t676.IsUndef) _t676 = ((V)(0.08));
v_677 = _t676; }
return Invoke(Q_364, "tone", t_675, ((V)(1800D)), ((V)(0.18)), NewObj(6).Put("to", ((V)(220D))).Put("slide", ((V)(0.16))).Put("type", ((V)("square"))).Put("lp", ((V)(3000D))).Put("vol", v_677).Put("at", ((V)(0.002))).V);
}, 2, "zap", true)).Put("boing", Fn((V _arrowThis688, int _argc679, V t_685, V _a682, V _a683, V _a684, V[] _rest680) => {
V v_687 = default;
{ V _t686 = _a682; if (_t686.IsUndef) _t686 = ((V)(0.1));
v_687 = _t686; }
return Invoke(Q_364, "tone", t_685, ((V)(180D)), ((V)(0.4)), NewObj(5).Put("to", ((V)(520D))).Put("slide", ((V)(0.12))).Put("type", ((V)("triangle"))).Put("vol", v_687).Put("vib", Arr(((V)(14D)), ((V)(40D)))).V);
}, 2, "boing", true)).Put("pop", Fn((V _arrowThis698, int _argc689, V t_695, V _a692, V _a693, V _a694, V[] _rest690) => {
V v_697 = default;
{ V _t696 = _a692; if (_t696.IsUndef) _t696 = ((V)(0.12));
v_697 = _t696; }
return Invoke(Q_364, "tone", t_695, ((V)(600D)), ((V)(0.08)), NewObj(4).Put("to", ((V)(1400D))).Put("slide", ((V)(0.05))).Put("vol", v_697).Put("at", ((V)(0.002))).V);
}, 2, "pop", true)).Put("splash", Fn((V _arrowThis708, int _argc699, V t_705, V _a702, V _a703, V _a704, V[] _rest700) => {
V v_707 = default;
{ V _t706 = _a702; if (_t706.IsUndef) _t706 = ((V)(0.2));
v_707 = _t706; }
Invoke(Q_364, "noise", t_705, ((V)(0.6)), NewObj(6).Put("ft", ((V)("bandpass"))).Put("f", ((V)(1200D))).Put("fTo", ((V)(400D))).Put("q", ((V)(0.7))).Put("vol", v_707).Put("at", ((V)(0.01))).V);
{
double k_709 = 0;
k_709 = 0D;
while (true) {
if (!((k_709 < 4D))) break;
Invoke(Q_364, "tone", Add(Add(t_705, ((V)(0.1))), ((V)((k_709 * 0.07)))), ((V)((900D + (k_709 * 260D)))), ((V)(0.06)), NewObj(3).Put("to", ((V)((1400D + (k_709 * 200D))))).Put("slide", ((V)(0.05))).Put("vol", ((V)(0.04))).V);
k_709++;
}
}
return default;
}, 2, "splash", true)).Put("hoot", Fn((V _arrowThis720, int _argc711, V t_717, V _a714, V _a715, V _a716, V[] _rest712) => {
V v_719 = default;
{ V _t718 = _a714; if (_t718.IsUndef) _t718 = ((V)(0.08));
v_719 = _t718; }
Invoke(Q_364, "tone", t_717, ((V)(380D)), ((V)(0.3)), NewObj(4).Put("to", ((V)(330D))).Put("slide", ((V)(0.3))).Put("vol", v_719).Put("at", ((V)(0.04))).V);
Invoke(Q_364, "tone", Add(t_717, ((V)(0.38))), ((V)(360D)), ((V)(0.45)), NewObj(4).Put("to", ((V)(300D))).Put("slide", ((V)(0.4))).Put("vol", v_719).Put("at", ((V)(0.04))).V);
return default;
}, 2, "hoot", true)).Put("rumble", Fn((V _arrowThis731, int _argc721, V t_727, V d_728, V _a725, V _a726, V[] _rest722) => {
V v_730 = default;
{ V _t729 = _a725; if (_t729.IsUndef) _t729 = ((V)(0.1));
v_730 = _t729; }
return Invoke(Q_364, "noise", t_727, d_728, NewObj(5).Put("ft", ((V)("lowpass"))).Put("f", ((V)(220D))).Put("vol", v_730).Put("at", ((V)((ToNum(d_728) * 0.3)))).Put("sus", ((V)(1D))).V);
}, 3, "rumble", true)).Put("steam", Fn((V _arrowThis743, int _argc732, V t_738, V _a735, V _a736, V _a737, V[] _rest733) => {
V d_740 = default;
V v_742 = default;
{ V _t739 = _a735; if (_t739.IsUndef) _t739 = ((V)(0.8));
d_740 = _t739; }
{ V _t741 = _a736; if (_t741.IsUndef) _t741 = ((V)(0.08));
v_742 = _t741; }
return Invoke(Q_364, "noise", t_738, d_740, NewObj(3).Put("f", ((V)(3500D))).Put("vol", v_742).Put("at", ((V)(0.02))).V);
}, 3, "steam", true)).Put("alarm", Fn((V _arrowThis755, int _argc744, V t_750, V _a747, V _a748, V _a749, V[] _rest745) => {
V n_752 = default;
V v_754 = default;
{ V _t751 = _a747; if (_t751.IsUndef) _t751 = ((V)(4D));
n_752 = _t751; }
{ V _t753 = _a748; if (_t753.IsUndef) _t753 = ((V)(0.05));
v_754 = _t753; }
{
double k_756 = 0;
k_756 = 0D;
while (true) {
if (!(Lt(((V)(k_756)), n_752))) break;
Invoke(Q_364, "tone", Add(t_750, ((V)((k_756 * 0.5)))), ((V)(880D)), ((V)(0.45)), NewObj(5).Put("to", ((V)(620D))).Put("slide", ((V)(0.45))).Put("type", ((V)("square"))).Put("lp", ((V)(1800D))).Put("vol", v_754).V);
k_756++;
}
}
return default;
}, 3, "alarm", true)).Put("chirp", Fn((V _arrowThis767, int _argc758, V t_764, V _a761, V _a762, V _a763, V[] _rest759) => {
V v_766 = default;
{ V _t765 = _a761; if (_t765.IsUndef) _t765 = ((V)(0.04));
v_766 = _t765; }
return Invoke(Q_364, "tone", t_764, ((V)(2400D)), ((V)(0.08)), NewObj(3).Put("to", ((V)(3400D))).Put("slide", ((V)(0.06))).Put("vol", v_766).V);
}, 2, "chirp", true)).Put("bee", Fn((V _arrowThis778, int _argc768, V t_774, V d_775, V _a772, V _a773, V[] _rest769) => {
V v_777 = default;
{ V _t776 = _a772; if (_t776.IsUndef) _t776 = ((V)(0.025));
v_777 = _t776; }
return Invoke(Q_364, "tone", t_774, ((V)(220D)), d_775, NewObj(6).Put("type", ((V)("sawtooth"))).Put("lp", ((V)(900D))).Put("vol", v_777).Put("at", ((V)(0.05))).Put("sus", ((V)(1D))).Put("vib", Arr(((V)(22D)), ((V)(18D)))).V);
}, 3, "bee", true)).Put("sneeze", Fn((V _arrowThis786, int _argc779, V t_785, V _a782, V _a783, V _a784, V[] _rest780) => {
Invoke(Q_364, "tone", t_785, ((V)(500D)), ((V)(0.3)), NewObj(5).Put("to", ((V)(800D))).Put("slide", ((V)(0.3))).Put("type", ((V)("triangle"))).Put("vol", ((V)(0.05))).Put("at", ((V)(0.1))).V);
Invoke(Q_364, "noise", Add(t_785, ((V)(0.55))), ((V)(0.3)), NewObj(4).Put("ft", ((V)("bandpass"))).Put("f", ((V)(2500D))).Put("fTo", ((V)(900D))).Put("vol", ((V)(0.3))).V);
return default;
}, 1, "sneeze", true)).Put("beat", Fn((V _arrowThis797, int _argc787, V t0_793, V t1_794, V B_795, V fn_796, V[] _rest788) => {
{
double i_798 = 0;
V t_799 = default;
i_798 = 0D;
t_799 = t0_793;
while (true) {
if (!(LtN(t_799, (ToNum(t1_794) - 0.001)))) break;
Call(fn_796, V.Undef, t_799, ((V)(i_798)));
i_798++;
t_799 = Add(t_799, B_795);
}
}
return default;
}, 4, "beat", true)).V;
return I_365;
return default;
}, 1, "snd", false);
if (Truthy(Get(G("window"), "MK"))) {
return default;
}
if (!(Truthy(Invoke(G("document"), "querySelector", ((V)("link[data-mk-font]")))))) {
V l_801 = default;
l_801 = Invoke(G("document"), "createElement", ((V)("link")));
Set(l_801, "rel", ((V)("stylesheet")));
Set(l_801, "href", ((V)("vendor/css/g-4725e77b0cee.css")));
Invoke(l_801, "setAttribute", ((V)("data-mk-font")), ((V)("1")));
Invoke(Get(G("document"), "head"), "appendChild", l_801);
}
cl_8 = Fn((V _arrowThis813, int _argc802, V v_808, V _a805, V _a806, V _a807, V[] _rest803) => {
V a_810 = default;
V b_812 = default;
{ V _t809 = _a805; if (_t809.IsUndef) _t809 = ((V)(0D));
a_810 = _t809; }
{ V _t811 = _a806; if (_t811.IsUndef) _t811 = ((V)(1D));
b_812 = _t811; }
return ((V)(Max(ToNum(a_810), Min(ToNum(b_812), ToNum(v_808)))));
}, 3, "", true);
lerp_9 = Fn((V _arrowThis823, int _argc814, V a_820, V b_821, V u_822, V _a819, V[] _rest815) => {
return Add(a_820, ((V)(((ToNum(b_821) - ToNum(a_820)) * ToNum(u_822)))));
}, 3, "", true);
E_10 = NewObj(5).Put("lin", Fn((V _arrowThis831, int _argc824, V x_830, V _a827, V _a828, V _a829, V[] _rest825) => {
return x_830;
}, 1, "lin", true)).Put("in", Fn((V _arrowThis839, int _argc832, V x_838, V _a835, V _a836, V _a837, V[] _rest833) => {
return ((V)((ToNum(x_838) * ToNum(x_838))));
}, 1, "in", true)).Put("out", Fn((V _arrowThis847, int _argc840, V x_846, V _a843, V _a844, V _a845, V[] _rest841) => {
return ((V)((1D - Pow((1D - ToNum(x_846)), 3D))));
}, 1, "out", true)).Put("io", Fn((V _arrowThis855, int _argc848, V x_854, V _a851, V _a852, V _a853, V[] _rest849) => {
return ((V)((LtN(x_854, 0.5) ? (((4D * ToNum(x_854)) * ToNum(x_854)) * ToNum(x_854)) : (1D - (Pow((((-2D) * ToNum(x_854)) + 2D), 3D) / 2D)))));
}, 1, "io", true)).Put("back", Fn((V _arrowThis863, int _argc856, V x_862, V _a859, V _a860, V _a861, V[] _rest857) => {
double c1_864 = 0;
double c3_865 = 0;
c1_864 = 1.70158;
c3_865 = (c1_864 + 1D);
return ((V)(((1D + (c3_865 * Pow((ToNum(x_862) - 1D), 3D))) + (c1_864 * Pow((ToNum(x_862) - 1D), 2D)))));
return default;
}, 1, "back", true)).V;
P_11 = Fn((V _arrowThis877, int _argc866, V t_872, V a_873, V b_874, V _a871, V[] _rest867) => {
V e_876 = default;
{ V _t875 = _a871; if (_t875.IsUndef) _t875 = Get(E_10, "out");
e_876 = _t875; }
return Call(e_876, V.Undef, Call(cl_8, V.Undef, ((V)(((ToNum(t_872) - ToNum(a_873)) / (ToNum(b_874) - ToNum(a_873)))))));
}, 4, "", true);
kf_12 = Fn((V _arrowThis888, int _argc878, V t_884, V K_885, V _a882, V _a883, V[] _rest879) => {
V e_887 = default;
{ V _t886 = _a882; if (_t886.IsUndef) _t886 = Get(E_10, "io");
e_887 = _t886; }
if (Le(t_884, GetIdx(GetIdx(K_885, 0D), 0D))) {
return GetIdx(GetIdx(K_885, 0D), 1D);
}
{
double i_889 = 0;
i_889 = 1D;
while (true) {
if (!(Lt(((V)(i_889)), Get(K_885, "length")))) break;
if (Le(t_884, GetIdx(GetIdx(K_885, i_889), 0D))) {
V a_891 = default;
V b_892 = default;
a_891 = GetIdx(K_885, (i_889 - 1D));
b_892 = GetIdx(K_885, i_889);
return Call(lerp_9, V.Undef, GetIdx(a_891, 1D), GetIdx(b_892, 1D), Call(e_887, V.Undef, ((V)(((ToNum(t_884) - ToNum(GetIdx(a_891, 0D))) / ToNum((((V)((ToNum(GetIdx(b_892, 0D)) - ToNum(GetIdx(a_891, 0D))))) is var _t893 && Truthy(_t893) ? _t893 : ((V)(1D)))))))));
}
i_889++;
}
}
return GetIdx(GetIdx(K_885, (ToNum(Get(K_885, "length")) - 1D)), 1D);
return default;
}, 3, "", true);
win_13 = Fn((V _arrowThis905, int _argc894, V t_900, V a_901, V b_902, V _a899, V[] _rest895) => {
V f_904 = default;
{ V _t903 = _a899; if (_t903.IsUndef) _t903 = ((V)(0.3));
f_904 = _t903; }
return Call(cl_8, V.Undef, ((V)(Min(((ToNum(t_900) - ToNum(a_901)) / ToNum(f_904)), ((ToNum(b_902) - ToNum(t_900)) / ToNum(f_904))))));
}, 4, "", true);
D_15 = Fn((V _arrowThis915, int _argc906, V p_912, V css_913, V html_914, V _a911, V[] _rest907) => {
return Call(el_14, V.Undef, ((V)("div")), ((V)(JsStrBuf.Begin().S("position:absolute;").V(css_913).End())), p_912, html_914);
}, 3, "", true);
show_16 = Fn((V _arrowThis924, int _argc916, V n_922, V on_923, V _a920, V _a921, V[] _rest917) => {
V d_925 = default;
d_925 = ((V)((Truthy(on_923) ? "block" : "none")));
if (!SEq(Get(Get(n_922, "style"), "display"), d_925)) {
Set(Get(n_922, "style"), "display", d_925);
}
return default;
}, 2, "", true);
put_17 = Fn((V _arrowThis941, int _argc926, V n_932, V x_933, V y_934, V _a931, V[] _rest927) => {
V k_936 = default;
V r_938 = default;
V o_940 = default;
{ V _t935 = _a931; if (_t935.IsUndef) _t935 = ((V)(1D));
k_936 = _t935; }
{ V _t937 = (_argc926 > 4 ? _rest927[0] : V.Undef); if (_t937.IsUndef) _t937 = ((V)(0D));
r_938 = _t937; }
{ V _t939 = (_argc926 > 5 ? _rest927[1] : V.Undef); if (_t939.IsUndef) _t939 = ((V)(1D));
o_940 = _t939; }
if (LeN(o_940, 0.002)) {
Call(show_16, V.Undef, n_932, (false ? V.True : V.False));
return default;
}
Call(show_16, V.Undef, n_932, (true ? V.True : V.False));
Set(Get(n_932, "style"), "opacity", Invoke(o_940, "toFixed", ((V)(3D))));
Set(Get(n_932, "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").V(Invoke(x_933, "toFixed", ((V)(2D)))).S("px,").V(Invoke(y_934, "toFixed", ((V)(2D)))).S("px) translate(-50%,-50%) rotate(").V(Invoke(r_938, "toFixed", ((V)(2D)))).S("deg) scale(").V(Invoke(k_936, "toFixed", ((V)(3D)))).S(")").End())));
return default;
}, 6, "", true);
rnd_18 = Fn((V _arrowThis949, int _argc942, V s_948, V _a945, V _a946, V _a947, V[] _rest943) => {
return Fn((V _arrowThis956, int _argc950, V _a952, V _a953, V _a954, V _a955, V[] _rest951) => {
V x_957 = default;
s_948 = ((V)(((double)(ToInt32(ToNum(s_948)) | ToInt32(0D)))));
s_948 = ((V)(((double)(ToInt32(ToNum(Add(s_948, ((V)(1831565813D))))) | ToInt32(0D)))));
x_957 = Invoke(G("Math"), "imul", ((V)(((double)(ToInt32(ToNum(s_948)) ^ ToInt32(((double)(ToUint32(ToNum(s_948)) >> (int)(ToUint32(15D) & 31)))))))), ((V)(((double)(ToInt32(1D) | ToInt32(ToNum(s_948)))))));
x_957 = ((V)(((double)(ToInt32(ToNum(Add(x_957, Invoke(G("Math"), "imul", ((V)(((double)(ToInt32(ToNum(x_957)) ^ ToInt32(((double)(ToUint32(ToNum(x_957)) >> (int)(ToUint32(7D) & 31)))))))), ((V)(((double)(ToInt32(61D) | ToInt32(ToNum(x_957)))))))))) ^ ToInt32(ToNum(x_957))))));
return ((V)((((double)(ToUint32(((double)(ToInt32(ToNum(x_957)) ^ ToInt32(((double)(ToUint32(ToNum(x_957)) >> (int)(ToUint32(14D) & 31))))))) >> (int)(ToUint32(0D) & 31))) / 4294967296D)));
return default;
}, 0, "", true);
}, 1, "", true);
art_19 = Fn((V _arrowThis966, int _argc958, V k_964, V v_965, V _a962, V _a963, V[] _rest959) => {
return ((V)(JsStrBuf.Begin().S("export/tripo/").V(k_964).S("/").V(k_964).S("-").V(v_965).S(".svg").End()));
}, 2, "", true);
SPIN_20 = Arr(((V)("front")), ((V)("right")), ((V)("back")), ((V)("left")));
lines_26 = Fn((V _arrowThis977, int _argc967, V fn_973, V t_974, V L_975, V at_976, V[] _rest968) => {
V q_978 = default;
V p_979 = default;
q_978 = Invoke(L_975, "find", Fn((V _arrowThis987, int _argc980, V l_986, V _a983, V _a984, V _a985, V[] _rest981) => {
return ((Ge(t_974, GetIdx(l_986, 0D)) && Lt(t_974, GetIdx(l_986, 1D))) ? V.True : V.False);
}, 1, "", true));
if (!(Truthy(q_978))) {
Call(fn_973, V.Undef, V.Null);
return default;
}
p_979 = (GetK(at_976, GetIdx(q_978, 3D)) is var _t988 && Truthy(_t988) ? _t988 : Arr(((V)(160D)), ((V)(60D))));
Call(fn_973, V.Undef, GetIdx(q_978, 2D), GetIdx(p_979, 0D), GetIdx(p_979, 1D), Call(win_13, V.Undef, t_974, GetIdx(q_978, 0D), GetIdx(q_978, 1D), ((V)(0.18))));
return default;
}, 4, "", true);
lightning_30 = Fn((V _arrowThis997, int _argc989, V t_995, V T_996, V _a993, V _a994, V[] _rest990) => {
double v_998 = 0;
v_998 = 0D;
Invoke(T_996, "forEach", Fn((V _arrowThis1006, int _argc999, V a_1005, V _a1002, V _a1003, V _a1004, V[] _rest1000) => {
double d_1007 = 0;
d_1007 = (ToNum(t_995) - ToNum(a_1005));
if (((d_1007 >= 0D) && (d_1007 < 0.6))) {
v_998 = Max(v_998, (((d_1007 < 0.06) ? 1D : ((d_1007 < 0.12) ? 0.2 : ((d_1007 < 0.18) ? 0.9 : 0D))) + (Max(0D, (0.5 - d_1007)) * 0.6)));
}
return default;
}, 1, "", true));
return ((V)(v_998));
return default;
}, 2, "", true);
glow_31 = Fn((V _arrowThis1019, int _argc1008, V p_1014, V c_1015, V r_1016, V _a1013, V[] _rest1009) => {
V css_1018 = default;
{ V _t1017 = _a1013; if (_t1017.IsUndef) _t1017 = ((V)(""));
css_1018 = _t1017; }
return Call(D_15, V.Undef, p_1014, ((V)(JsStrBuf.Begin().S("left:0;top:0;width:").N((2D * ToNum(r_1016))).S("px;height:").N((2D * ToNum(r_1016))).S("px;border-radius:50%;background:radial-gradient(circle,").V(c_1015).S(" 0%,rgba(0,0,0,0) 68%);display:none;pointer-events:none;").V(css_1018).End())));
}, 4, "", true);
mtof_33 = Fn((V _arrowThis1027, int _argc1020, V m_1026, V _a1023, V _a1024, V _a1025, V[] _rest1021) => {
return ((V)((440D * Pow(2D, ((ToNum(m_1026) - 69D) / 12D)))));
}, 1, "", true);
Set(G("window"), "MK", NewObj(27).Put("cl", cl_8).Put("lerp", lerp_9).Put("E", E_10).Put("P", P_11).Put("kf", kf_12).Put("win", win_13).Put("el", el_14).Put("D", D_15).Put("show", show_16).Put("put", put_17).Put("rnd", rnd_18).Put("art", art_19).Put("SPIN", SPIN_20).Put("actor", actor_21).Put("pose", pose_22).Put("go", go_23).Put("dance", dance_24).Put("bub", bub_25).Put("lines", lines_26).Put("parts", parts_27).Put("stars", stars_28).Put("rain", rain_29).Put("lightning", lightning_30).Put("glow", glow_31).Put("film", film_32).Put("snd", snd_34).Put("mtof", mtof_33).V);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
