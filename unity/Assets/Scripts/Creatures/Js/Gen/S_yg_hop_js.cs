// yg-hop.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_yg_hop_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V go_8 = default;
if (_self1.IsNullish) _self1 = GlobalV;
go_8 = Fn((V _self1, int _argc9, V _a11, V _a12, V _a13, V _a14, V[] _rest10) => {
V YG_15 = default;
V S_16 = default;
V D_17 = default;
V cl_18 = default;
V lerp_19 = default;
V r2_20 = default;
V SFX_21 = default;
V ICON_22 = default;
V ROWS_23 = default;
V COL_24 = default;
V ACT_25 = default;
YG_15 = Get(G("window"), "YardGames");
if (((!(Truthy(YG_15)) || !(Truthy(Get(YG_15, "add")))) || !(Truthy(Get(YG_15, "cam"))))) {
return Call(G("setTimeout"), V.Undef, go_8, ((V)(30D)));
}
{ V _t26 = YG_15;
if (_t26.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t26));
{ V _t27 = Get(_t26, "S");
S_16 = _t27; }
{ V _t28 = Get(_t26, "D");
D_17 = _t28; }
{ V _t29 = Get(_t26, "cl");
cl_18 = _t29; }
{ V _t30 = Get(_t26, "lerp");
lerp_19 = _t30; }
{ V _t31 = Get(_t26, "r2");
r2_20 = _t31; }
{ V _t32 = Get(_t26, "SFX");
SFX_21 = _t32; } }
ICON_22 = ((V)(string.Concat("<svg viewBox=\"0 0 120 84\" aria-hidden=\"true\"><rect width=\"120\" height=\"84\" fill=\"#9fdc6e\"/><path d=\"M30 84L44 6H76L90 84Z\" fill=\"#d9d4cc\"/>", "<g stroke=\"#fff\" stroke-width=\"1.6\"><path d=\"M50 74H70V84H50Z\" fill=\"#ffd1e8\"/><path d=\"M51 62H69V74H51Z\" fill=\"#fff3a8\"/><path d=\"M52 51H68V62H52Z\" fill=\"#c8f0b6\"/><path d=\"M45 41H60V51H45ZM60 41H75V51H60Z\" fill=\"#cfe6ff\"/><path d=\"M53 32H67V41H53Z\" fill=\"#ffd9b8\"/><path d=\"M47 23H60V32H47ZM60 23H73V32H60Z\" fill=\"#e4d4ff\"/><path d=\"M54 15H66V23H54Z\" fill=\"#ffd1e8\"/><path d=\"M53 15Q60 4 67 15Z\" fill=\"#fff3a8\"/></g>", "<ellipse cx=\"60\" cy=\"57\" rx=\"4\" ry=\"2\" fill=\"#8a8f99\"/></svg>")));
ROWS_23 = Arr(Arr(((V)(1D))), Arr(((V)(2D))), Arr(((V)(3D))), Arr(((V)(4D)), ((V)(5D))), Arr(((V)(6D))), Arr(((V)(7D)), ((V)(8D))), Arr(((V)(9D))), Arr(((V)("HOME"))));
COL_24 = Arr(((V)("#ffd1e8")), ((V)("#fff3a8")), ((V)("#c8f0b6")), ((V)("#cfe6ff")), ((V)("#ffd9b8")), ((V)("#e4d4ff")), ((V)("#ffd1e8")), ((V)("#fff3a8")));
ACT_25 = NewObj(3).Put("hop", NewObj(3).Put("c", ((V)("#ff5cae"))).Put("t", ((V)("Hop"))).Put("k", Arr(((V)("ArrowLeft")), ((V)("a")), ((V)("A")))).V).Put("split", NewObj(3).Put("c", ((V)("#3d9bff"))).Put("t", ((V)("Split"))).Put("k", Arr(((V)("ArrowDown")), ((V)("s")), ((V)("S")))).V).Put("leap", NewObj(3).Put("c", ((V)("#ffb020"))).Put("t", ((V)("Leap"))).Put("k", Arr(((V)("ArrowUp")), ((V)("w")), ((V)("W")), ((V)(" ")))).V).V;
Invoke(YG_15, "add", NewObj(11).Put("id", ((V)("hop"))).Put("land", (true ? V.True : V.False)).Put("name", ((V)("Hopscotch"))).Put("item", ((V)("Hopscotch Court"))).Put("color", ((V)("#ff7fc0"))).Put("icon", ICON_22).Put("stars", Arr(((V)(180D)), ((V)(420D)), ((V)(700D)))).Put("coinK", ((V)(0.08))).Put("hint", ((V)("Pink = Hop \u00b7 Blue = Split \u00b7 Yellow = Leap over the stone"))).Put("how", Arr(((V)("Press the move as the ring closes on the next square.")), ((V)("Pink Hop for one square, blue Split for the double squares, yellow Leap over the stone.")), ((V)("Keys: \u2190 hop \u00b7 \u2193 split \u00b7 \u2191 leap. 3 hearts, the beat speeds up each lap.")))).Put("make", Fn((V _self33, int _argc34, V ctx_40, V _a37, V _a38, V _a39, V[] _rest35) => {
V bg_41 = default;
V fg_42 = default;
V W_43 = default;
V H_44 = default;
V P_45 = default;
double Z0_46 = 0;
double RL_47 = 0;
double SW_48 = 0;
V rowZ_49 = default;
V quad_50 = default;
V court_51 = default;
V chalk_52 = default;
V cells_53 = default;
V stoneG_54 = default;
V ringG_55 = default;
V shG_56 = default;
V me_57 = default;
V meSh_58 = default;
V bar_59 = default;
V btn_60 = default;
double lap_61 = 0;
double beat_62 = 0;
double hearts_63 = 0;
V moves_64 = default;
double mi_65 = 0;
V t0_66 = default;
V tNow_67 = default;
V cur_68 = default;
V hopA_69 = default;
JsStrBuf phase_70 = null;
V ph0_71 = default;
V stone_72 = default;
double combo_73 = 0;
double stumbles_74 = 0;
double perfect_75 = 0;
V STONES_76 = default;
V plan_77 = default;
V drawStone_78 = default;
V judge_79 = default;
V press_80 = default;
V api_81 = default;
if (_self33.IsNullish) _self33 = GlobalV;
plan_77 = Fn((V _self82, int _argc83, V _a85, V _a86, V _a87, V _a88, V[] _rest84) => {
double r_89 = 0;
if (_self82.IsNullish) _self82 = GlobalV;
stone_72 = GetIdx(STONES_76, (lap_61 % ToNum(Get(STONES_76, "length"))));
moves_64 = Arr();
r_89 = (-1D);
while ((r_89 < 7D)) {
double nx_90 = 0;
V a_91 = default;
nx_90 = (r_89 + 1D);
a_91 = V.Undef;
if (SEqN(stone_72, nx_90)) {
nx_90++;
a_91 = ((V)("leap"));
} else {
a_91 = ((V)((SEqN(Get(GetIdx(ROWS_23, nx_90), "length"), 2D) ? "split" : "hop")));
}
Invoke(moves_64, "push", NewObj(4).Put("row", ((V)(nx_90))).Put("act", a_91).Put("due", ((V)(0D))).Put("done", ((V)(0D))).V);
r_89 = nx_90;
}
beat_62 = Max(430D, (760D * Pow(0.92, lap_61)));
t0_66 = Add(tNow_67, ((V)((beat_62 * 2D))));
Invoke(moves_64, "forEach", Fn((V _self82, int _argc92, V m_98, V i_99, V _a96, V _a97, V[] _rest93) => {
return Set(m_98, "due", Add(t0_66, ((V)((beat_62 * ToNum(i_99))))));
}, 2, "", true));
mi_65 = 0D;
Call(drawStone_78, V.Undef);
Invoke(ctx_40, "timer", Add(Invoke(((V)("\u2665")), "repeat", ((V)(hearts_63))), Invoke(((V)("\u2661")), "repeat", ((V)((3D - hearts_63))))));
return default;
}, 0, "plan", false);
drawStone_78 = Fn((V _self100, int _argc101, V _a103, V _a104, V _a105, V _a106, V[] _rest102) => {
V c_107 = default;
V s_108 = default;
double k_109 = 0;
if (_self100.IsNullish) _self100 = GlobalV;
Set(stoneG_54, "innerHTML", ((V)("")));
c_107 = GetIdx(GetK(cells_53, stone_72), 0D);
s_108 = Call(P_45, V.Undef, Get(c_107, "x"), ((V)(0D)), Get(c_107, "z"));
k_109 = (ToNum(GetIdx(s_108, 2D)) / 245.7);
Call(S_16, V.Undef, ((V)("ellipse")), NewObj(5).Put("cx", Call(r2_20, V.Undef, GetIdx(s_108, 0D))).Put("cy", Call(r2_20, V.Undef, Add(GetIdx(s_108, 1D), ((V)((2D * k_109)))))).Put("rx", Call(r2_20, V.Undef, ((V)((11D * k_109))))).Put("ry", Call(r2_20, V.Undef, ((V)((4.2 * k_109))))).Put("fill", ((V)("#6f7480"))).V, stoneG_54);
Call(S_16, V.Undef, ((V)("ellipse")), NewObj(5).Put("cx", Call(r2_20, V.Undef, GetIdx(s_108, 0D))).Put("cy", Call(r2_20, V.Undef, GetIdx(s_108, 1D))).Put("rx", Call(r2_20, V.Undef, ((V)((10D * k_109))))).Put("ry", Call(r2_20, V.Undef, ((V)((4.6 * k_109))))).Put("fill", ((V)("#9aa0ab"))).V, stoneG_54);
Call(S_16, V.Undef, ((V)("ellipse")), NewObj(5).Put("cx", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(s_108, 0D)) - (3D * k_109)))))).Put("cy", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(s_108, 1D)) - (1.4 * k_109)))))).Put("rx", Call(r2_20, V.Undef, ((V)((4D * k_109))))).Put("ry", Call(r2_20, V.Undef, ((V)((1.6 * k_109))))).Put("fill", ((V)("#c9ced6"))).V, stoneG_54);
return default;
}, 0, "drawStone", false);
judge_79 = Fn((V _self110, int _argc111, V m_117, V act_118, V dt_119, V _a116, V[] _rest112) => {
V ok_120 = default;
double a_121 = 0;
V txt_122 = default;
V col_123 = default;
double pts_124 = 0;
V c_125 = default;
V s_126 = default;
if (_self110.IsNullish) _self110 = GlobalV;
Set(m_117, "done", ((V)(1D)));
mi_65++;
ok_120 = (SEq(act_118, Get(m_117, "act")) ? V.True : V.False);
a_121 = System.Math.Abs(ToNum(dt_119));
txt_122 = V.Undef;
col_123 = V.Undef;
pts_124 = 0D;
if (!(Truthy(ok_120))) {
txt_122 = ((V)((Truthy(act_118) ? "Oops!" : "Miss!")));
col_123 = ((V)("#ff7a8a"));
hearts_63--;
combo_73 = 0D;
stumbles_74 = 1D;
Invoke(SFX_21, "miss");
} else {
if ((a_121 < 85D)) {
txt_122 = ((V)("Perfect!"));
col_123 = ((V)("#ffe36e"));
pts_124 = 30D;
perfect_75++;
} else {
if ((a_121 < 165D)) {
txt_122 = ((V)("Good"));
col_123 = ((V)("#8fe0ff"));
pts_124 = 15D;
} else {
txt_122 = ((V)("OK"));
col_123 = ((V)("#ffffff"));
pts_124 = 5D;
}
}
}
if (Truthy(ok_120)) {
combo_73++;
pts_124 = (pts_124 + Min(20D, (System.Math.Floor((combo_73 / 4D)) * 5D)));
Invoke(SFX_21, "pop");
}
c_125 = GetIdx(GetK(cells_53, Get(m_117, "row")), 0D);
s_126 = Call(P_45, V.Undef, Get(c_125, "x"), ((V)(0D)), Get(c_125, "z"));
if (NumTruthy(pts_124)) {
Invoke(ctx_40, "add", ((V)(pts_124)), GetIdx(s_126, 0D), ((V)((ToNum(GetIdx(s_126, 1D)) - 50D))), ((V)(JsStrBuf.Begin().V(txt_122).S(((combo_73 >= 8D) ? JsStrBuf.Begin().S(" x").N(combo_73).End() : "")).End())), col_123);
} else {
Invoke(ctx_40, "toast", txt_122, GetIdx(s_126, 0D), ((V)((ToNum(GetIdx(s_126, 1D)) - 50D))), col_123);
}
Invoke(ctx_40, "timer", Add(Invoke(((V)("\u2665")), "repeat", ((V)(Max(0D, hearts_63)))), Invoke(((V)("\u2661")), "repeat", ((V)((3D - Max(0D, hearts_63)))))));
hopA_69 = NewObj(7).Put("from", Get(cur_68, "z")).Put("to", Get(GetIdx(GetK(cells_53, Get(m_117, "row")), 0D), "z")).Put("row", Get(m_117, "row")).Put("act", Get(m_117, "act")).Put("t0", tNow_67).Put("dur", ((V)((Min(400D, (beat_62 * 0.72)) * (SEqS(Get(m_117, "act"), "leap") ? 1.25 : 1D))))).Put("bad", (!(Truthy(ok_120)) ? V.True : V.False)).V;
Set(cur_68, "row", Get(m_117, "row"));
if ((hearts_63 <= 0D)) {
phase_70.Set("over");
ph0_71 = tNow_67;
}
return default;
}, 3, "judge", false);
press_80 = Fn((V _self127, int _argc128, V k_134, V _a131, V _a132, V _a133, V[] _rest129) => {
V m_135 = default;
double dt_136 = 0;
if (_self127.IsNullish) _self127 = GlobalV;
if ((!(Truthy(Get(ctx_40, "playing"))) || !string.Equals(phase_70.Str, "run"))) {
return default;
}
m_135 = GetIdx(moves_64, mi_65);
if (!(Truthy(m_135))) {
return default;
}
dt_136 = (ToNum(tNow_67) - ToNum(Get(m_135, "due")));
if ((dt_136 < (-230D))) {
Invoke(SFX_21, "tap");
return default;
}
Call(judge_79, V.Undef, m_135, k_134, ((V)(dt_136)));
return default;
}, 1, "press", false);
{ V _t137 = ctx_40;
if (_t137.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t137));
{ V _t138 = Get(_t137, "bg");
bg_41 = _t138; }
{ V _t139 = Get(_t137, "fg");
fg_42 = _t139; }
{ V _t140 = Get(_t137, "W");
W_43 = _t140; }
{ V _t141 = Get(_t137, "H");
H_44 = _t141; } }
P_45 = Invoke(YG_15, "cam", ((V)(2D)), ((V)(2.2)), ((V)(24D)), ((V)(160D)));
Z0_46 = 0.35;
RL_47 = 0.5;
SW_48 = 0.5;
Invoke(YG_15, "yard", bg_41, NewObj(2).Put("hz", ((V)(24D))).Put("trees", (false ? V.True : V.False)).V);
rowZ_49 = Fn((V _self33, int _argc142, V i_148, V _a145, V _a146, V _a147, V[] _rest143) => {
return ((V)((Z0_46 + (RL_47 * ToNum(Add(i_148, ((V)(0.5))))))));
}, 1, "", true);
quad_50 = Fn((V _self33, int _argc149, V pts_155, V a_156, V p_157, V _a154, V[] _rest150) => {
return Call(S_16, V.Undef, ((V)("path")), Object_assign(NewObj(1).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_155, "map", Fn((V _self33, int _argc158, V q_164, V _a161, V _a162, V _a163, V[] _rest159) => {
V s_165 = default;
s_165 = Call(P_45, V.Undef, GetIdx(q_164, 0D), ((V)(0D)), GetIdx(q_164, 1D));
return ((V)(JsStrBuf.Begin().V(Call(r2_20, V.Undef, GetIdx(s_165, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(s_165, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()))).V, a_156), (p_157 is var _t166 && Truthy(_t166) ? _t166 : bg_41));
}, 3, "", true);
Call(quad_50, V.Undef, Arr(Arr(((V)((-0.95))), ((V)((-0.4)))), Arr(((V)(0.95)), ((V)((-0.4)))), Arr(((V)(0.95)), ((V)(5.2))), Arr(((V)((-0.95))), ((V)(5.2)))), NewObj(1).Put("fill", ((V)("#dcd6cc"))).V);
{
double z_167 = 0;
z_167 = (-0.4);
while (true) {
if (!((z_167 < 5.2))) break;
Call(quad_50, V.Undef, Arr(Arr(((V)((-0.95))), ((V)(z_167))), Arr(((V)(0.95)), ((V)(z_167))), Arr(((V)(0.95)), ((V)((z_167 + 0.012)))), Arr(((V)((-0.95))), ((V)((z_167 + 0.012))))), NewObj(1).Put("fill", ((V)("#c7c0b4"))).V);
z_167 = (z_167 + 0.6);
}
}
Call(quad_50, V.Undef, Arr(Arr(((V)((-0.95))), ((V)((-0.4)))), Arr(((V)((-0.9))), ((V)((-0.4)))), Arr(((V)((-0.9))), ((V)(5.2))), Arr(((V)((-0.95))), ((V)(5.2)))), NewObj(1).Put("fill", ((V)("#c2bbae"))).V);
Call(quad_50, V.Undef, Arr(Arr(((V)(0.9)), ((V)((-0.4)))), Arr(((V)(0.95)), ((V)((-0.4)))), Arr(((V)(0.95)), ((V)(5.2))), Arr(((V)(0.9)), ((V)(5.2)))), NewObj(1).Put("fill", ((V)("#c2bbae"))).V);
court_51 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, bg_41);
chalk_52 = NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.2))).Put("stroke-linejoin", ((V)("round"))).Put("opacity", ((V)(0.92))).V;
cells_53 = Arr();
Invoke(ROWS_23, "forEach", Fn((V _self33, int _argc169, V r_175, V i_176, V _a173, V _a174, V[] _rest170) => {
double z0_177 = 0;
double z1_178 = 0;
z0_177 = (Z0_46 + (RL_47 * ToNum(i_176)));
z1_178 = (z0_177 + RL_47);
if (SEqS(GetIdx(r_175, 0D), "HOME")) {
JsStrBuf d_179 = null;
double n_180 = 0;
d_179 = new JsStrBuf("");
n_180 = 20D;
{
double k_181 = 0;
k_181 = 0D;
while (true) {
if (!((k_181 <= n_180))) break;
double a_183 = 0;
V s_184 = default;
a_183 = ((System.Math.PI * k_181) / n_180);
s_184 = Call(P_45, V.Undef, ((V)((((-FdLibm.Cos(a_183)) * SW_48) * 0.9))), ((V)(0D)), ((V)((z0_177 + ((FdLibm.Sin(a_183) * RL_47) * 1.3)))));
d_179.S((NumTruthy(k_181) ? "L" : "M")).V(Call(r2_20, V.Undef, GetIdx(s_184, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(s_184, 1D)));
k_181++;
}
}
Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(string.Concat(d_179.Str, "Z")))).Put("fill", GetK(COL_24, i_176)).Put("opacity", ((V)(0.75))).V, court_51);
Call(S_16, V.Undef, ((V)("path")), Object_assign(NewObj(1).Put("d", ((V)(string.Concat(d_179.Str, "Z")))).V, chalk_52), court_51);
Invoke(cells_53, "push", Arr(NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)((z0_177 + (RL_47 * 0.55))))).V));
} else {
V xs_185 = default;
xs_185 = (SEqN(Get(r_175, "length"), 2D) ? Arr(Arr(((V)((-SW_48))), ((V)(0D))), Arr(((V)(0D)), ((V)(SW_48)))) : Arr(Arr(((V)(((-SW_48) / 2D))), ((V)((SW_48 / 2D))))));
Invoke(cells_53, "push", Invoke(xs_185, "map", Fn((V _self33, int _argc186, V _a188, V _a189, V _a190, V _a191, V[] _rest187) => {
V a_194 = default;
V b_196 = default;
{ V _t192 = ListOf(_a188);
{ V _t193 = GetIdx(_t192, 0D);
a_194 = _t193; }
{ V _t195 = GetIdx(_t192, 1D);
b_196 = _t195; }
}
Call(quad_50, V.Undef, Arr(Arr(a_194, ((V)(z0_177))), Arr(b_196, ((V)(z0_177))), Arr(b_196, ((V)(z1_178))), Arr(a_194, ((V)(z1_178)))), NewObj(2).Put("fill", GetK(COL_24, i_176)).Put("opacity", ((V)(0.75))).V, court_51);
Call(quad_50, V.Undef, Arr(Arr(a_194, ((V)(z0_177))), Arr(b_196, ((V)(z0_177))), Arr(b_196, ((V)(z1_178))), Arr(a_194, ((V)(z1_178)))), chalk_52, court_51);
return NewObj(2).Put("x", ((V)((ToNum(Add(a_194, b_196)) / 2D)))).Put("z", ((V)(((z0_177 + z1_178) / 2D)))).V;
return default;
}, 1, "", true)));
}
Invoke(r_175, "forEach", Fn((V _self33, int _argc197, V lb_203, V j_204, V _a201, V _a202, V[] _rest198) => {
V c_205 = default;
V s_206 = default;
double k_207 = 0;
c_205 = (GetK(GetK(cells_53, i_176), j_204) is var _t208 && Truthy(_t208) ? _t208 : GetIdx(GetK(cells_53, i_176), 0D));
s_206 = Call(P_45, V.Undef, Get(c_205, "x"), ((V)(0D)), Get(c_205, "z"));
k_207 = (ToNum(GetIdx(s_206, 2D)) / 245.7);
Set(Call(S_16, V.Undef, ((V)("text")), NewObj(9).Put("x", ((V)(0D))).Put("y", ((V)(0D))).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_20, V.Undef, GetIdx(s_206, 0D))).S(" ").V(Call(r2_20, V.Undef, Add(GetIdx(s_206, 1D), ((V)((6D * k_207)))))).S(") scale(").V(Call(r2_20, V.Undef, ((V)((k_207 * 1.1))))).S(" ").V(Call(r2_20, V.Undef, ((V)((k_207 * 0.62))))).S(")").End()))).Put("text-anchor", ((V)("middle"))).Put("font-family", ((V)("Fredoka, sans-serif"))).Put("font-weight", ((V)(700D))).Put("font-size", ((V)((SEqS(lb_203, "HOME") ? 20D : 30D)))).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.9))).V, court_51), "textContent", lb_203);
return default;
}, 2, "", true));
return default;
}, 2, "", true));
{
double i_209 = 0;
i_209 = 0D;
while (true) {
if (!((i_209 < 8D))) break;
V s_211 = default;
s_211 = Call(P_45, V.Undef, ((V)(((NumTruthy((i_209 % 2D)) ? 1D : (-1D)) * (0.62 + ((i_209 * 0.07) % 0.2))))), ((V)(0D)), ((V)((0.5 + (i_209 * 0.55)))));
Call(S_16, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", Call(r2_20, V.Undef, GetIdx(s_211, 0D))).Put("cy", Call(r2_20, V.Undef, GetIdx(s_211, 1D))).Put("rx", Call(r2_20, V.Undef, ((V)(((9D * ToNum(GetIdx(s_211, 2D))) / 245.7))))).Put("ry", Call(r2_20, V.Undef, ((V)(((3D * ToNum(GetIdx(s_211, 2D))) / 245.7))))).Put("fill", GetIdx(COL_24, i_209)).Put("opacity", ((V)(0.4))).V, court_51);
i_209++;
}
}
{
V s_212 = default;
s_212 = Call(P_45, V.Undef, ((V)(0.7)), ((V)(0D)), ((V)(0.15)));
Call(S_16, V.Undef, ((V)("rect")), NewObj(7).Put("x", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(s_212, 0D)) - 9D))))).Put("y", Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(s_212, 1D)) - 3D))))).Put("width", ((V)(18D))).Put("height", ((V)(6D))).Put("rx", ((V)(3D))).Put("fill", ((V)("#ff8fc8"))).Put("transform", ((V)(JsStrBuf.Begin().S("rotate(-20 ").V(Call(r2_20, V.Undef, GetIdx(s_212, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(s_212, 1D))).S(")").End()))).V, court_51);
}
stoneG_54 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, bg_41);
ringG_55 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, bg_41);
shG_56 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, bg_41);
me_57 = Invoke(ctx_40, "creature", Get(ctx_40, "playerKey"), NewObj(1).Put("yaw", ((V)(180D))).V);
meSh_58 = Invoke(YG_15, "shadow", shG_56, ((V)(0D)), ((V)(0D)), ((V)(30D)), ((V)(0.2)));
bar_59 = Call(D_17, V.Undef, ((V)("div")), NewObj(1).Put("style", ((V)("position:absolute;left:auto;right:2.5%;width:40%;bottom:4%;display:flex;gap:3%;justify-content:center;pointer-events:none;z-index:6;"))).V, Invoke(Get(Get(ctx_40, "crl"), "parentNode"), "querySelector", ((V)(".yg-hud"))));
btn_60 = NewObj(0).V;
Invoke(ctx_40, "hint", ((V)("")));
Invoke(Object_keys(ACT_25), "forEach", Fn((V _self33, int _argc213, V k_219, V _a216, V _a217, V _a218, V[] _rest214) => {
V b_220 = default;
V ic_221 = default;
b_220 = Call(D_17, V.Undef, ((V)("button")), NewObj(2).Put("aria-label", Get(GetK(ACT_25, k_219), "t")).Put("style", ((V)(JsStrBuf.Begin().S("pointer-events:auto;flex:1;max-width:30%;aspect-ratio:1.65;border:0;border-radius:22%;background:#ffffff;color:").V(Get(GetK(ACT_25, k_219), "c")).S(";font:700 clamp(12px,4.6cqw,20px)/1 Fredoka,sans-serif;box-shadow:0 1.2cqw 0 ").V(Get(GetK(ACT_25, k_219), "c")).S(";cursor:pointer;display:flex;flex-direction:column;align-items:center;justify-content:center;gap:4%;touch-action:none;").End()))).V, bar_59);
ic_221 = Call(D_17, V.Undef, ((V)("div")), NewObj(1).Put("style", ((V)("width:46%;height:46%;"))).V, b_220);
Set(ic_221, "innerHTML", ((V)((SEqS(k_219, "hop") ? "<svg viewBox=\"0 0 24 24\"><ellipse cx=\"12\" cy=\"13\" rx=\"4.5\" ry=\"6.5\" fill=\"currentColor\"/><circle cx=\"9\" cy=\"4.5\" r=\"1.6\" fill=\"currentColor\"/><circle cx=\"12.5\" cy=\"3.6\" r=\"1.6\" fill=\"currentColor\"/><circle cx=\"15.6\" cy=\"4.8\" r=\"1.5\" fill=\"currentColor\"/></svg>" : (SEqS(k_219, "split") ? "<svg viewBox=\"0 0 24 24\"><ellipse cx=\"6.5\" cy=\"14\" rx=\"3.6\" ry=\"5.6\" fill=\"currentColor\"/><ellipse cx=\"17.5\" cy=\"14\" rx=\"3.6\" ry=\"5.6\" fill=\"currentColor\"/><circle cx=\"5\" cy=\"6.2\" r=\"1.3\" fill=\"currentColor\"/><circle cx=\"8\" cy=\"5.6\" r=\"1.3\" fill=\"currentColor\"/><circle cx=\"16\" cy=\"5.6\" r=\"1.3\" fill=\"currentColor\"/><circle cx=\"19\" cy=\"6.2\" r=\"1.3\" fill=\"currentColor\"/></svg>" : "<svg viewBox=\"0 0 24 24\"><path d=\"M3 19Q12 -2 21 19\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2.6\" stroke-linecap=\"round\"/><path d=\"M17.5 16.5L21 19.5L22 15\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2.6\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><ellipse cx=\"12\" cy=\"20\" rx=\"4\" ry=\"2\" fill=\"#8a8f99\"/></svg>")))));
Call(D_17, V.Undef, ((V)("div")), NewObj(0).V, b_220, Get(GetK(ACT_25, k_219), "t"));
Invoke(b_220, "addEventListener", ((V)("pointerdown")), Fn((V _self33, int _argc222, V e_228, V _a225, V _a226, V _a227, V[] _rest223) => {
Invoke(e_228, "preventDefault");
Invoke(e_228, "stopPropagation");
Call(press_80, V.Undef, k_219);
Set(Get(b_220, "style"), "transform", ((V)("translateY(3px)")));
Call(G("setTimeout"), V.Undef, Fn((V _self33, int _argc235, V _a237, V _a238, V _a239, V _a240, V[] _rest236) => {
return Set(Get(b_220, "style"), "transform", ((V)("")));
}, 0, "", true), ((V)(90D)));
return default;
}, 1, "", true));
SetK(btn_60, k_219, b_220);
return default;
}, 1, "", true));
lap_61 = 0D;
beat_62 = 760D;
hearts_63 = 3D;
moves_64 = Arr();
mi_65 = 0D;
t0_66 = ((V)(0D));
tNow_67 = ((V)(0D));
cur_68 = NewObj(2).Put("z", ((V)(0.2))).Put("row", ((V)((-1D)))).V;
hopA_69 = V.Null;
phase_70 = new JsStrBuf("idle");
ph0_71 = ((V)(0D));
stone_72 = ((V)(0D));
combo_73 = 0D;
stumbles_74 = 0D;
perfect_75 = 0D;
STONES_76 = Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(4D)), ((V)(6D)));
api_81 = NewObj(7).Put("start", Fn((V _self241, int _argc242, V _a244, V _a245, V _a246, V _a247, V[] _rest243) => {
if (_self241.IsNullish) _self241 = GlobalV;
lap_61 = 0D;
hearts_63 = 3D;
combo_73 = 0D;
perfect_75 = 0D;
cur_68 = NewObj(2).Put("z", ((V)(0.2))).Put("row", ((V)((-1D)))).V;
hopA_69 = V.Null;
phase_70.Set("run");
Call(plan_77, V.Undef);
Invoke(me_57, "yaw", ((V)(180D)));
return default;
}, 0, "start", false)).Put("key", Fn((V _self248, int _argc249, V k_255, V dn_256, V _a253, V _a254, V[] _rest250) => {
if (_self248.IsNullish) _self248 = GlobalV;
if (!(Truthy(dn_256))) {
return default;
}
{
foreach (V _k257 in ForInKeys(ACT_25)) {
V a_258 = default;
a_258 = _k257;
if (Truthy(Invoke(Get(GetK(ACT_25, a_258), "k"), "includes", k_255))) {
Call(press_80, V.Undef, a_258);
return (true ? V.True : V.False);
}
}
}
return default;
}, 2, "key", false)).Put("down", Fn((V _self259, int _argc260, V _a262, V _a263, V _a264, V _a265, V[] _rest261) => {
if (_self259.IsNullish) _self259 = GlobalV;

return default;
}, 0, "down", false)).Put("_press", press_80).Put("_state", Fn((V _self33, int _argc266, V _a268, V _a269, V _a270, V _a271, V[] _rest267) => {
return NewObj(6).Put("lap", ((V)(lap_61))).Put("hearts", ((V)(hearts_63))).Put("mi", ((V)(mi_65))).Put("phase", ((V)(phase_70.Str))).Put("due", (GetIdx(moves_64, mi_65) is var _t272 && !Truthy(_t272) ? _t272 : ((V)(Round((ToNum(Get(GetIdx(moves_64, mi_65), "due")) - ToNum(tNow_67))))))).Put("act", (GetIdx(moves_64, mi_65) is var _t273 && !Truthy(_t273) ? _t273 : Get(GetIdx(moves_64, mi_65), "act"))).V;
}, 0, "_state", true)).Put("celebrate", Fn((V _self274, int _argc275, V st_281, V _a278, V _a279, V _a280, V[] _rest276) => {
if (_self274.IsNullish) _self274 = GlobalV;
Invoke(me_57, "yaw", ((V)(0D)));
Invoke(me_57, "play", ((V)((GeN(st_281, 2D) ? "happy" : "idle"))));
return default;
}, 1, "celebrate", false)).Put("update", Fn((V _self282, int _argc283, V dt_289, V t_290, V _a287, V _a288, V[] _rest284) => {
V z_291 = default;
double lift_292 = 0;
V E_293 = default;
V s_294 = default;
V g_295 = default;
V m_296 = default;
if (_self282.IsNullish) _self282 = GlobalV;
tNow_67 = t_290;
if (string.Equals(phase_70.Str, "run")) {
V m_297 = default;
double bi_298 = 0;
m_297 = GetIdx(moves_64, mi_65);
if (Truthy((m_297 is var _t299 && !Truthy(_t299) ? _t299 : (Gt(t_290, Add(Get(m_297, "due"), ((V)(230D)))) ? V.True : V.False)))) {
Call(judge_79, V.Undef, m_297, V.Null, ((V)(999D)));
}
bi_298 = System.Math.Floor(((ToNum(t_290) - ToNum(t0_66)) / beat_62));
if ((!SEqN(Get(api_81, "_bi"), bi_298) && (bi_298 >= (-2D)))) {
Set(api_81, "_bi", ((V)(bi_298)));
if ((bi_298 < 0D)) {
Invoke(SFX_21, "tick");
}
}
if ((Ge(((V)(mi_65)), Get(moves_64, "length")) && !(Truthy(hopA_69)))) {
phase_70.Set("lap");
ph0_71 = t_290;
lap_61++;
Invoke(ctx_40, "add", ((V)((50D + (lap_61 * 10D)))), ((V)((ToNum(W_43) / 2D))), ((V)((ToNum(H_44) * 0.4))), ((V)(JsStrBuf.Begin().S("Lap ").N(lap_61).S("! +").N((50D + (lap_61 * 10D))).End())), ((V)("#ffe36e")));
Invoke(SFX_21, "score");
Invoke(me_57, "yaw", ((V)(0D)));
Invoke(me_57, "play", ((V)("happy")));
}
}
if (string.Equals(phase_70.Str, "lap")) {
double u_300 = 0;
u_300 = ((ToNum(t_290) - ToNum(ph0_71)) / 1000D);
if (((u_300 > 1.1) && (u_300 < 2.1))) {
Set(cur_68, "z", Call(lerp_19, V.Undef, Get(GetIdx(GetIdx(cells_53, 7D), 0D), "z"), ((V)(0.2)), Invoke(YG_15, "SM", ((V)(((u_300 - 1.1) / 1D))))));
Invoke(me_57, "yaw", ((V)(0D)));
Invoke(me_57, "walk", dt_289, ((V)(1D)), ((V)(0D)));
}
if ((u_300 >= 2.1)) {
Invoke(me_57, "yaw", ((V)(180D)));
Invoke(me_57, "play", ((V)("idle")));
Set(cur_68, "z", ((V)(0.2)));
Set(cur_68, "row", ((V)((-1D))));
if ((lap_61 >= 6D)) {
phase_70.Set("over");
Invoke(ctx_40, "finish", NewObj(2).Put("sub", ((V)(JsStrBuf.Begin().S("6 laps! ").N(perfect_75).S(" perfect").End()))).Put("title", ((V)("Champion!"))).V);
} else {
phase_70.Set("run");
Call(plan_77, V.Undef);
Invoke(ctx_40, "toast", ((V)("Faster!")), ((V)((ToNum(W_43) / 2D))), ((V)((ToNum(H_44) * 0.45))), ((V)("#ffffff")));
}
}
}
if (((string.Equals(phase_70.Str, "over") && ((ToNum(t_290) - ToNum(ph0_71)) > 300D)) && !(Truthy(Get(api_81, "_fin"))))) {
Set(api_81, "_fin", ((V)(1D)));
if ((hearts_63 <= 0D)) {
Invoke(me_57, "yaw", ((V)(0D)));
Invoke(me_57, "play", ((V)("surprised")));
Invoke(ctx_40, "finish", NewObj(1).Put("sub", ((V)(JsStrBuf.Begin().N(lap_61).S(" lap").S(((lap_61 == 1D) ? "" : "s")).S(" \u00b7 ").N(perfect_75).S(" perfect").End()))).V);
}
}
z_291 = Get(cur_68, "z");
lift_292 = 0D;
E_293 = NewObj(0).V;
if (Truthy(hopA_69)) {
V u_301 = default;
double hh_302 = 0;
u_301 = Call(cl_18, V.Undef, ((V)(((ToNum(t_290) - ToNum(Get(hopA_69, "t0"))) / ToNum(Get(hopA_69, "dur"))))), ((V)(0D)), ((V)(1D)));
z_291 = Call(lerp_19, V.Undef, Get(hopA_69, "from"), Get(hopA_69, "to"), Invoke(YG_15, "SM", u_301));
hh_302 = (SEqS(Get(hopA_69, "act"), "leap") ? 0.42 : 0.22);
lift_292 = (FdLibm.Sin((ToNum(u_301) * System.Math.PI)) * hh_302);
E_293 = (SEqS(Get(hopA_69, "act"), "split") ? NewObj(5).Put("armL", ((V)(((100D * FdLibm.Sin((ToNum(u_301) * System.Math.PI))) + 30D)))).Put("armR", ((V)(((100D * FdLibm.Sin((ToNum(u_301) * System.Math.PI))) + 30D)))).Put("footL", ((V)((2D * FdLibm.Sin((ToNum(u_301) * System.Math.PI)))))).Put("footR", ((V)((2D * FdLibm.Sin((ToNum(u_301) * System.Math.PI)))))).Put("sq", ((V)((GtN(u_301, 0.85) ? 0.12 : (-0.05))))).V : (SEqS(Get(hopA_69, "act"), "leap") ? NewObj(4).Put("armL", ((V)((150D * FdLibm.Sin((ToNum(u_301) * System.Math.PI)))))).Put("armR", ((V)((150D * FdLibm.Sin((ToNum(u_301) * System.Math.PI)))))).Put("spin", ((V)((360D * ToNum(Invoke(YG_15, "SM", u_301)))))).Put("sq", ((V)((GtN(u_301, 0.85) ? 0.1 : (-0.06))))).V : NewObj(4).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("footR", ((V)((3D * FdLibm.Sin((ToNum(u_301) * System.Math.PI)))))).Put("sq", ((V)((GtN(u_301, 0.85) ? 0.08 : (-0.04))))).V));
if (Truthy(Get(hopA_69, "bad"))) {
Set(E_293, "tilt", ((V)(((FdLibm.Sin((ToNum(u_301) * 20D)) * 6D) * (1D - (ToNum(u_301) * 0.5))))));
}
if (GeN(u_301, 1D)) {
Set(cur_68, "z", Get(hopA_69, "to"));
hopA_69 = V.Null;
}
} else {
if (string.Equals(phase_70.Str, "run")) {
V m_303 = default;
V pre_304 = default;
m_303 = GetIdx(moves_64, mi_65);
pre_304 = (Truthy(m_303) ? Call(cl_18, V.Undef, ((V)((1D - ((ToNum(Get(m_303, "due")) - ToNum(t_290)) / beat_62)))), ((V)(0D)), ((V)(1D))) : ((V)(0D)));
E_293 = NewObj(3).Put("sq", ((V)((0.06 * ToNum(pre_304))))).Put("armL", ((V)((20D + (25D * ToNum(pre_304)))))).Put("armR", ((V)((20D + (25D * ToNum(pre_304)))))).V;
}
}
if ((string.Equals(phase_70.Str, "run") || string.Equals(phase_70.Str, "lap"))) {
Invoke(me_57, "pose", E_293);
}
s_294 = Call(P_45, V.Undef, ((V)(0D)), ((V)(lift_292)), z_291);
g_295 = Call(P_45, V.Undef, ((V)(0D)), ((V)(0D)), z_291);
Invoke(me_57, "set", GetIdx(s_294, 0D), GetIdx(s_294, 1D), ((V)((1D * ToNum(GetIdx(s_294, 2D))))));
Invoke(meSh_58, "setAttribute", ((V)("cx")), Call(r2_20, V.Undef, GetIdx(g_295, 0D)));
Invoke(meSh_58, "setAttribute", ((V)("cy")), Call(r2_20, V.Undef, GetIdx(g_295, 1D)));
Invoke(meSh_58, "setAttribute", ((V)("rx")), Call(r2_20, V.Undef, ((V)(((0.3 * ToNum(GetIdx(g_295, 2D))) * (1D - lift_292))))));
Invoke(meSh_58, "setAttribute", ((V)("ry")), Call(r2_20, V.Undef, ((V)(((0.08 * ToNum(GetIdx(g_295, 2D))) * (1D - lift_292))))));
Set(ringG_55, "innerHTML", ((V)("")));
m_296 = ((string.Equals(phase_70.Str, "run") ? V.True : V.False) is var _t305 && !Truthy(_t305) ? _t305 : GetIdx(moves_64, mi_65));
if (Truthy(m_296)) {
V u_306 = default;
V A_307 = default;
V rad_308 = default;
V cs_309 = default;
V c_310 = default;
V q_311 = default;
V tag_312 = default;
u_306 = Call(cl_18, V.Undef, ((V)((1D - ((ToNum(Get(m_296, "due")) - ToNum(t_290)) / beat_62)))), ((V)(0D)), ((V)(1.2)));
A_307 = GetK(ACT_25, Get(m_296, "act"));
rad_308 = Call(lerp_19, V.Undef, ((V)(0.62)), ((V)(0.27)), ((V)(Min(1D, ToNum(u_306)))));
cs_309 = GetK(cells_53, Get(m_296, "row"));
Invoke(cs_309, "forEach", Fn((V _self282, int _argc313, V c_319, V _a316, V _a317, V _a318, V[] _rest314) => {
JsStrBuf d_320 = null;
d_320 = new JsStrBuf("");
{
double i_321 = 0;
i_321 = 0D;
while (true) {
if (!((i_321 <= 28D))) break;
double a_323 = 0;
V q_324 = default;
a_323 = (((i_321 / 28D) * System.Math.PI) * 2D);
q_324 = Call(P_45, V.Undef, Add(Get(c_319, "x"), ((V)(((FdLibm.Cos(a_323) * ToNum(rad_308)) * (SEqN(Get(cs_309, "length"), 2D) ? 0.55 : 1D))))), ((V)(0D)), Add(Get(c_319, "z"), ((V)(((FdLibm.Sin(a_323) * ToNum(rad_308)) * 0.8)))));
d_320.S((NumTruthy(i_321) ? "L" : "M")).V(Call(r2_20, V.Undef, GetIdx(q_324, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(q_324, 1D)));
i_321++;
}
}
Call(S_16, V.Undef, ((V)("path")), NewObj(6).Put("d", ((V)(string.Concat(d_320.Str, "Z")))).Put("fill", Get(A_307, "c")).Put("fill-opacity", ((V)((0.12 + (0.2 * ToNum(u_306)))))).Put("stroke", Get(A_307, "c")).Put("stroke-width", ((V)(3.2))).Put("opacity", Call(cl_18, V.Undef, ((V)((ToNum(u_306) * 2D))), ((V)(0D)), ((V)(1D)))).V, ringG_55);
return default;
}, 1, "", true));
c_310 = (SEqN(Get(cs_309, "length"), 2D) ? NewObj(2).Put("x", ((V)(0D))).Put("z", Get(GetIdx(cs_309, 0D), "z")).V : GetIdx(cs_309, 0D));
q_311 = Call(P_45, V.Undef, Get(c_310, "x"), ((V)(0D)), Get(c_310, "z"));
tag_312 = Call(S_16, V.Undef, ((V)("g")), NewObj(2).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_20, V.Undef, GetIdx(q_311, 0D))).S(" ").V(Call(r2_20, V.Undef, ((V)(((ToNum(GetIdx(q_311, 1D)) - ((22D * ToNum(GetIdx(q_311, 2D))) / 245.7)) - 8D))))).S(")").End()))).Put("opacity", Call(cl_18, V.Undef, ((V)((ToNum(u_306) * 2D))), ((V)(0D)), ((V)(1D)))).V, ringG_55);
Call(S_16, V.Undef, ((V)("rect")), NewObj(6).Put("x", ((V)((-22D)))).Put("y", ((V)((-11D)))).Put("width", ((V)(44D))).Put("height", ((V)(20D))).Put("rx", ((V)(10D))).Put("fill", Get(A_307, "c")).V, tag_312);
Set(Call(S_16, V.Undef, ((V)("text")), NewObj(6).Put("y", ((V)(4D))).Put("text-anchor", ((V)("middle"))).Put("font-family", ((V)("Fredoka, sans-serif"))).Put("font-weight", ((V)(700D))).Put("font-size", ((V)(12D))).Put("fill", ((V)("#ffffff"))).V, tag_312), "textContent", Get(A_307, "t"));
Invoke(Object_keys(btn_60), "forEach", Fn((V _self282, int _argc325, V k_331, V _a328, V _a329, V _a330, V[] _rest326) => {
Set(Get(GetK(btn_60, k_331), "style"), "background", ((V)(((SEq(k_331, Get(m_296, "act")) && GtN(u_306, 0.5)) ? JsStrBuf.Begin().V(Get(A_307, "c")).S("22").End() : "#ffffff"))));
return default;
}, 1, "", true));
}
return default;
}, 2, "update", false)).V;
Call(plan_77, V.Undef);
return api_81;
return default;
}, 1, "make", false)).V);
return default;
}, 0, "", true);
Call(go_8, V.Undef);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
